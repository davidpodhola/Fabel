module Main

// This just shows how a F# Console Application can be
// translated to node.js. The entry point we'll be called automatically
// with the arguments passed to the node script.
// Note that for this simple example no dependencies are needed

[<EntryPoint>]
let main argv =
    if argv.Length = 0 then
        printfn "Please provide an argument"
        1
    else
        argv.[0]
        |> Seq.rev
        |> Seq.map string
        |> String.concat ""
        |> Util.greet
        0
