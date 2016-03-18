module ReactHelper

open Fable.Core
open Fable.Import

[<Emit("this.state = $0")>]
let private setInitialState (state: obj): unit = failwith "JS only"

type Component<'P,'S>(props: 'P, ?state: 'S) =
    inherit React.Component<'P,'S>(props)
    do setInitialState state

let inline fn (f: 'Props -> React.ReactElement<obj>) (props: 'Props) (children: React.ReactElement<obj> list): React.ReactElement<obj> =
    unbox(React.Globals.createElement(U2.Case1(unbox f), props, unbox(List.toArray children)))

let inline com<'T,'P,'S when 'T :> React.Component<'P,'S>> (props: 'P) (children: React.ReactElement<obj> list): React.ReactElement<obj> =
    unbox(React.Globals.createElement(U2.Case1(unbox typeof<'T>), props, unbox(List.toArray children)))

let inline dom (tag: string) (props: (string*obj) list) (children: React.ReactElement<obj> list): React.ReactElement<obj> =
    unbox(React.Globals.createElement(tag, createObj props, unbox(List.toArray children)))

let inline a b c = dom "a" b c
let inline abbr b c = dom "abbr" b c
let inline address b c = dom "address" b c
let inline area b c = dom "area" b c
let inline article b c = dom "article" b c
let inline aside b c = dom "aside" b c
let inline audio b c = dom "audio" b c
let inline b b' c = dom "b" b' c
let inline ``base`` b c = dom "base" b c
let inline bdi b c = dom "bdi" b c
let inline bdo b c = dom "bdo" b c
let inline big b c = dom "big" b c
let inline blockquote b c = dom "blockquote" b c
let inline body b c = dom "body" b c
let inline br b c = dom "br" b c
let inline button b c = dom "button" b c
let inline canvas b c = dom "canvas" b c
let inline caption b c = dom "caption" b c
let inline cite b c = dom "cite" b c
let inline code b c = dom "code" b c
let inline col b c = dom "col" b c
let inline colgroup b c = dom "colgroup" b c
let inline data b c = dom "data" b c
let inline datalist b c = dom "datalist" b c
let inline dd b c = dom "dd" b c
let inline del b c = dom "del" b c
let inline details b c = dom "details" b c
let inline dfn b c = dom "dfn" b c
let inline dialog b c = dom "dialog" b c
let inline div b c = dom "div" b c
let inline dl b c = dom "dl" b c
let inline dt b c = dom "dt" b c
let inline em b c = dom "em" b c
let inline embed b c = dom "embed" b c
let inline fieldset b c = dom "fieldset" b c
let inline figcaption b c = dom "figcaption" b c
let inline figure b c = dom "figure" b c
let inline footer b c = dom "footer" b c
let inline form b c = dom "form" b c
let inline h1 b c = dom "h1" b c
let inline h2 b c = dom "h2" b c
let inline h3 b c = dom "h3" b c
let inline h4 b c = dom "h4" b c
let inline h5 b c = dom "h5" b c
let inline h6 b c = dom "h6" b c
let inline head b c = dom "head" b c
let inline header b c = dom "header" b c
let inline hgroup b c = dom "hgroup" b c
let inline hr b c = dom "hr" b c
let inline html b c = dom "html" b c
let inline i b c = dom "i" b c
let inline iframe b c = dom "iframe" b c
let inline img b c = dom "img" b c
let inline input b c = dom "input" b c
let inline ins b c = dom "ins" b c
let inline kbd b c = dom "kbd" b c
let inline keygen b c = dom "keygen" b c
let inline label b c = dom "label" b c
let inline legend b c = dom "legend" b c
let inline li b c = dom "li" b c
let inline link b c = dom "link" b c
let inline main b c = dom "main" b c
let inline map b c = dom "map" b c
let inline mark b c = dom "mark" b c
let inline menu b c = dom "menu" b c
let inline menuitem b c = dom "menuitem" b c
let inline meta b c = dom "meta" b c
let inline meter b c = dom "meter" b c
let inline nav b c = dom "nav" b c
let inline noscript b c = dom "noscript" b c
let inline ``object`` b c = dom "object" b c
let inline ol b c = dom "ol" b c
let inline optgroup b c = dom "optgroup" b c
let inline option b c = dom "option" b c
let inline output b c = dom "output" b c
let inline p b c = dom "p" b c
let inline param b c = dom "param" b c
let inline picture b c = dom "picture" b c
let inline pre b c = dom "pre" b c
let inline progress b c = dom "progress" b c
let inline q b c = dom "q" b c
let inline rp b c = dom "rp" b c
let inline rt b c = dom "rt" b c
let inline ruby b c = dom "ruby" b c
let inline s b c = dom "s" b c
let inline samp b c = dom "samp" b c
let inline script b c = dom "script" b c
let inline section b c = dom "section" b c
let inline select b c = dom "select" b c
let inline small b c = dom "small" b c
let inline source b c = dom "source" b c
let inline span b c = dom "span" b c
let inline strong b c = dom "strong" b c
let inline style b c = dom "style" b c
let inline sub b c = dom "sub" b c
let inline summary b c = dom "summary" b c
let inline sup b c = dom "sup" b c
let inline table b c = dom "table" b c
let inline tbody b c = dom "tbody" b c
let inline td b c = dom "td" b c
let inline textarea b c = dom "textarea" b c
let inline tfoot b c = dom "tfoot" b c
let inline th b c = dom "th" b c
let inline thead b c = dom "thead" b c
let inline time b c = dom "time" b c
let inline title b c = dom "title" b c
let inline tr b c = dom "tr" b c
let inline track b c = dom "track" b c
let inline u b c = dom "u" b c
let inline ul b c = dom "ul" b c
let inline var b c = dom "var" b c
let inline video b c = dom "video" b c
let inline wbr b c = dom "wbr" b c
let inline svg b c = dom "svg" b c
let inline circle b c = dom "circle" b c
let inline clipPath b c = dom "clipPath" b c
let inline defs b c = dom "defs" b c
let inline ellipse b c = dom "ellipse" b c
let inline g b c = dom "g" b c
let inline image b c = dom "image" b c
let inline line b c = dom "line" b c
let inline linearGradient b c = dom "linearGradient" b c
let inline mask b c = dom "mask" b c
let inline path b c = dom "path" b c
let inline pattern b c = dom "pattern" b c
let inline polygon b c = dom "polygon" b c
let inline polyline b c = dom "polyline" b c
let inline radialGradient b c = dom "radialGradient" b c
let inline rect b c = dom "rect" b c
let inline stop b c = dom "stop" b c
let inline text b c = dom "text" b c
let inline tspan b c = dom "tspan" b c
