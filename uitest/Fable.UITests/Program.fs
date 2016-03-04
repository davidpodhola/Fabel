open canopy
open runner
open System

"opening todo and entering one" &&& fun _ ->
  url "http://localhost:8090/sample/browser/todomvc/"

[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    // firefox is reported to work very well on AppVeyor (phantomJS not)
    start firefox

    //run all tests
    run()

    quit()

    0 
