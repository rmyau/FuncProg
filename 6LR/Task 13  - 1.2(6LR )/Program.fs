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
let FindMinInd lint = 
    let rec MinEl lint min indM indEL =
        match lint with
        |[]->indM
        |h::tail -> 
            let newMin =if h<min then h else min
            let newInd = if h<min then indEL else indM
            MinEl tail newMin newInd (indEL+1)
    MinEl lint lint.Head 0 0

[<EntryPoint>]
let main argv =
    let l=readData
    Console.WriteLine("Индекс минимального элемента списка: ")
    Console.WriteLine(List.findIndex (fun x -> x=FindMin l) l)
    //lint[8]={1,5,10,2,6,10,1,2}
    0 // return an integer exit code
