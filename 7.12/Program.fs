// Learn more about F# at http://fsharp.org

open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n
//1.11 Дан целочисленный массив, в котором лишь один элемент
//отличается от остальных. Необходимо найти значение этого элемента.
let another list = 
    if List.findIndex (fun x-> x = (List.max list)) list = List.findIndexBack (fun x-> x = (List.max list)) list  then
        List.max list
    else List.min list

[<EntryPoint>]
let main argv =
    readData |> another|>Console.WriteLine;
    0 // return an integer exit code
