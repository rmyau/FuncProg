// Learn more about F# at http://fsharp.org

open System
let Del n f init = 
    let rec FDel n f init nowN = 
        if nowN=0 then init
        else 
            let NextInit=
                if n%nowN=0 then f init nowN
                else init
            let newN=nowN-1
            FDel n f NextInit newN
    FDel n f init n            
[<EntryPoint>]
let main argv =
    let n=Convert.ToInt32(Console.ReadLine())
    Console.WriteLine(Del n (fun x y -> x*y) 1)
    0 // return an integer exit code
