// Learn more about F# at http://fsharp.org

open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    Console.WriteLine("Введите размерность списка:  ")
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Введите список: ")
    readList n

let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail  
let FindMax lint = 
    let rec MaxEl lint max =
        match lint with
        |[]->max
        |h::tail -> 
            let newMax =
                if h>max then h
                else max
            MaxEl tail newMax
    MaxEl lint lint.Head
//1.28 - найти элементы, расположенные между первым и последним максимальным
let ListBetwMax lint  = 
    let Max = FindMax lint
    let indexFirst = List.findIndex (fun x -> x=Max) lint
    let indexLast = List.findIndexBack (fun x -> x=Max) lint
    let rec InList (lint:'int list) ind1 ind2 indEl newList = 
        if indEl = ind2 then newList
        else 
            let newNewList=
                if indEl> ind1 then newList @ [lint.Head]
                else newList
            InList lint.Tail ind1 ind2 (indEl+1) newNewList
    InList lint indexFirst indexLast 0 []

[<EntryPoint>]
let main argv =

    readData |> ListBetwMax|>writeList
    0 // return an integer exit code
