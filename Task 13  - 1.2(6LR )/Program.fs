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

//1.2 Найти индекс минимального элемента
let FindMin lint = 
    let rec MinEl lint min =
        match lint with
        |[]->min
        |h::tail -> 
            let newMin =
                if h<min then h
                else min
            MinEl tail newMin
    MinEl lint lint.Head

[<EntryPoint>]
let main argv =
    let l=readData
    Console.WriteLine("Индекс минимального элемента списка: ")
    Console.WriteLine(List.findIndex (fun x -> x=FindMin l) l)
    //lint[8]={1,5,10,2,6,10,1,2}
    0 // return an integer exit code
