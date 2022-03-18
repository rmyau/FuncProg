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

//1.43 Найти количество минимальных элементов
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

let NumMinEL lint = 
    let min = FindMin lint
    let rec NumMin lint minEl num =
        match lint with
        |[]->num
        |_->
            let newNum = 
                if lint.Head=minEl then (num+1)
                else num
            NumMin lint.Tail minEl newNum
    NumMin lint min 0

[<EntryPoint>]
let main argv =
    Console.WriteLine("Кол-во минимальных элементов: ")
    readData |> NumMinEL|>Console.WriteLine
    0 // return an integer exit code
