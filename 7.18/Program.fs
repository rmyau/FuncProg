// Learn more about F# at http://fsharp.org

open System

//1 Создать новый массив, в котором порядок элементов
//существующего массива будет изменен на обратный (Привет ->тевирП).
let readArray n =
    let rec read n arr = 
        match n with 
        |0 ->arr
        |_->
            let newEl=Console.ReadLine()|>Convert.ToInt32
            let newArr = Array.append arr [|newEl|]
            read (n-1) newArr
    read n [||]

let writeArray arr = 
    printfn "%A" arr

let reverse1 arr= 
    let rec rr arr revArr = 
        match arr with
        |[||] -> revArr
        |_-> 
            let lastEl = Array.last arr
            let newRevArr = Array.append revArr [|lastEl|]
            let newArr = Array.removeAt (Array.length arr-1) arr
            rr newArr newRevArr
    rr arr [||]


[<EntryPoint>]
let main argv =
    let arr = Console.ReadLine() |> Convert.ToInt32 |>readArray 
    let res1 = reverse1 arr 
    writeArray res1
    let res2 = Array.rev arr
    writeArray res2
    0 // return an integer exit code
