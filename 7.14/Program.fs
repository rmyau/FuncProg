// Learn more about F# at http://fsharp.org

open System
open Program

//1.31 Дан целочисленный массив. Найти количество чётных элементов.
let ChetNum list = List.length (List.filter (fun x -> x%2=0) list) 
[<EntryPoint>]
let main argv =

    readData |>ChetNum|>Console.WriteLine
    0 // return an integer exit code
