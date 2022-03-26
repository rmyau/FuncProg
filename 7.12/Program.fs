// Learn more about F# at http://fsharp.org

open System

//1.11 Дан целочисленный массив, в котором лишь один элемент
//отличается от остальных. Необходимо найти значение этого элемента.
let another list = 
    if List.findIndex (fun x-> x = (List.max list)) list = List.findIndexBack (fun x-> x = (List.max list)) list  then
        List.max list
    else List.min list

[<EntryPoint>]
let main argv =
    Program.readData |> another|>Console.WriteLine;
    0 // return an integer exit code
