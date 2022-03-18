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
//1.37 вывести индексы элементов, которые меньше левого соседа
//и кол-во таких чисел

let lessLeftInd (lint:'int list) = 
    let rec LessInd lint leftEl (indEl:int) num=
        match lint with
        |[] -> num
        |head::tail->
            let newNum = 
                if head<leftEl then num+1
                else num
            let newLeft = head
            if head<leftEl then Console.WriteLine("Index - {0}",indEl)
            LessInd tail newLeft (indEl+1) newNum
    LessInd lint.Tail lint.Head 1 0

[<EntryPoint>]
let main argv =
    Console.WriteLine("Индексы элементов, которые меньше соседа слева")
    readData |> lessLeftInd |> Console.WriteLine
    //[6,2,1,4,3]
    0 // return an integer exit code
