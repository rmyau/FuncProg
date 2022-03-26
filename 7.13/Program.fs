// Learn more about F# at http://fsharp.org

open System

//1.13 Дан целочисленный массив. Необходимо разместить элементы,
//расположенные до минимального, в конце массива.

let ChangeList list =
    let indMin=List.findIndex(fun x-> x=List.min list) list
    let ListBeforeMin = list.[..(indMin-1)]
    let ListAfterMin = list.[indMin..]
    ListAfterMin @ ListBeforeMin

[<EntryPoint>]
let main argv =
    Program.readData |>ChangeList |> Program.writelist
    0 // return an integer exit code
