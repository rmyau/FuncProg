// Learn more about F# at http://fsharp.org

open System
open Program
//1.41 Дан целочисленный массив. Найти среднее арифметическое модулей его элементов.
let AverageAbsList list = List.average (List.map (fun (x:float)-> Math.Abs(x)) list )
[<EntryPoint>]
let main argv =
    readData|>AverageAbsList |> Console.WriteLine
    0 // return an integer exit code
