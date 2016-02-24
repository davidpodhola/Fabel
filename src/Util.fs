namespace Fable


module ExceptionPrettyPrinter =
  open System
  open System.Reflection
  open System.Text
  open Microsoft.FSharp.Core.Printf

  // from https://sergeytihon.wordpress.com/2013/04/08/f-exception-formatter/
  let formatDisplayMessage (e:Exception) =
    let sb = StringBuilder()
    let delimeter = String.replicate 50 "*"
    let nl = Environment.NewLine
    let rec printException (e:Exception) count =
        if (e :? TargetException && e.InnerException <> null)
        then printException (e.InnerException) count
        else
            if (count = 1) then bprintf sb "%s%s%s" e.Message nl delimeter
            else bprintf sb "%s%s%d)%s%s%s" nl nl count e.Message nl delimeter
            bprintf sb "%sType: %s" nl (e.GetType().FullName)
            // Loop through the public properties of the exception object
            // and record their values.
            e.GetType().GetProperties()
            |> Array.iter (fun p ->
                // Do not log information for the InnerException or StackTrace.
                // This information is captured later in the process.
                if (p.Name <> "InnerException" && p.Name <> "StackTrace" &&
                    p.Name <> "Message" && p.Name <> "Data") then
                    try
                        let value = p.GetValue(e, null)
                        if (value <> null)
                        then bprintf sb "%s%s: %s" nl p.Name (value.ToString())
                    with
                    | e2 -> bprintf sb "%s%s: %s" nl p.Name e2.Message
            )
            if (e.StackTrace <> null) then
                bprintf sb "%s%sStackTrace%s%s%s" nl nl nl delimeter nl
                bprintf sb "%s%s" nl e.StackTrace
            if (e.InnerException <> null)
            then printException e.InnerException (count+1)
    printException e 1
    sb.ToString()

type CompilerOptions = {
        code: string
        projFile: string
        symbols: string[]
        outDir: string
        lib: string
        watch: bool
    }
    
type CompilerError (ex:System.Exception) =
  member x.``type`` = "Error"
  member x.message: string = ExceptionPrettyPrinter.formatDisplayMessage ex

type ICompiler =
    abstract Options: CompilerOptions

module Naming =
    open System
    open System.IO
    open System.Text.RegularExpressions
    
    let (|StartsWith|_|) pattern (txt: string) =
        if txt.StartsWith pattern then Some pattern else None
    
    let knownInterfaces =
        set [ "System.Object"; "System.IComparable"; "System.IDisposable";
            "System.IObservable"; "System.IObserver"]
             
    let automaticInterfaces =
        set [ "System.IEquatable"; "System.Collections.IStructuralEquatable";
            "System.IComparable"; "System.Collections.IStructuralComparable" ]
    
    let ignoredCompilerGenerated =
        set [ "CompareTo"; "Equals"; "GetHashCode" ]
    
    let isJsCons = (=) "createNew"
    
    let removeParens, removeGetSetPrefix, sanitizeActivePattern =
        let reg1 = Regex(@"^\( (.*) \)$")
        let reg2 = Regex(@"^[gs]et_")
        let reg3 = Regex(@"^\|[^\|]+?(?:\|[^\|]+)*(?:\|_)?\|$")
        (fun s -> reg1.Replace(s, "$1")),
        (fun s -> reg2.Replace(s, "")),
        (fun (s: string) -> if reg3.IsMatch(s) then s.Replace("|", "$") else s)
        
    let lowerFirst (s: string) =
        s.Substring 1 |> (+) (Char.ToLowerInvariant s.[0] |> string)

    let getFieldIndex fieldName =
        match Regex.Match(fieldName, @"\d+$") with
        | m when m.Success -> int m.Value
        | _ -> 0
    
    let getCoreLibPath (com: ICompiler) =
        Path.Combine(com.Options.lib, "fable-core.js")

    let fromLib (com: ICompiler) path =
        Path.Combine(com.Options.lib, path)

    // TODO: Use $F for CoreLib?
    let getImportModuleIdent i = sprintf "$M%i" (i+1)
    
    let identForbiddenChars =
        Regex @"^[^a-zA-Z_$]|[^0-9a-zA-Z_$]"
        
    let trimDots (s: string) =
        match s.StartsWith ".", s.EndsWith "." with
        | true, true -> s.Substring(1, s.Length - 2)
        | true, false -> s.Substring(1)
        | false, true -> s.Substring(0, s.Length - 1)
        | false, false -> s

    // See https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Lexical_grammar#Keywords
    let jsKeywords =
        set["abstract"; "await"; "boolean"; "break"; "byte"; "case"; "catch"; "char"; "class"; "const"; "continue"; "debugger"; "default"; "delete"; "do"; "double";
            "else"; "enum"; "export"; "extends"; "false"; "final"; "finally"; "float"; "for"; "function"; "goto"; "if"; "implements"; "import"; "in"; "instanceof"; "int"; "interface";
            "let"; "long"; "native"; "new"; "null"; "package"; "private"; "protected"; "public"; "return"; "self"; "short"; "static"; "super"; "switch"; "synchronized";
            "this"; "throw"; "throws"; "transient"; "true"; "try"; "typeof"; "undefined"; "var"; "void"; "volatile"; "while"; "with"; "yield" ]
        
    let sanitizeIdent conflicts name =
        let preventConflicts conflicts name =
            let rec check n =
                let name = if n > 0 then sprintf "%s_%i" name n else name
                if not (conflicts name) then name else check (n+1)
            check 0
        // Replace Forbidden Chars
        let sanitizedName =
            identForbiddenChars.Replace(removeParens name, "_")
        // Check if it's a keyword
        jsKeywords.Contains sanitizedName
        |> function true -> "_" + sanitizedName | false -> sanitizedName
        // Check if it already exists in scope
        |> preventConflicts conflicts
        
    let getQueryParams (txt: string) =
        match txt.IndexOf("?") with
        | -1 -> txt, Map.empty<_,_>
        | i ->
            txt.Substring(i + 1).Split('&')
            |> Seq.choose (fun pair ->
                match pair.Split('=') with
                | [|key;value|] -> Some (key,value)
                | _ -> None)
            |> fun args -> txt.Substring(0, i), Map(args)

    /// Creates a relative path from one file or folder to another.
    /// from http://stackoverflow.com/a/340454/3922220
    let getRelativePath toPath fromPath =
        let fromUri = Uri(fromPath)
        let toUri = Uri(toPath)
        if fromUri.Scheme <> toUri.Scheme then
            toPath   // path can't be made relative.
        else
            let relativeUri = fromUri.MakeRelativeUri(toUri)
            let relativePath = Uri.UnescapeDataString(relativeUri.ToString())
            match toUri.Scheme.ToUpperInvariant() with
            | "FILE" -> relativePath.Replace(
                            IO.Path.AltDirectorySeparatorChar,
                            IO.Path.DirectorySeparatorChar)
            | _ -> relativePath        

module Json =
    open FSharp.Reflection
    open Newtonsoft.Json
            
    type ErasedUnionConverter() =
        inherit JsonConverter()
        override x.CanConvert t =
            t.Name = "FSharpOption`1" ||
            FSharpType.IsUnion t &&
                t.GetCustomAttributes true
                |> Seq.exists (fun a -> (a.GetType ()).Name = "EraseAttribute")
        override x.ReadJson(reader, t, v, serializer) =
            failwith "Not implemented"
        override x.WriteJson(writer, v, serializer) =
            match FSharpValue.GetUnionFields (v, v.GetType()) with
            | _, [|v|] -> serializer.Serialize(writer, v) 
            | _ -> writer.WriteNull()        

