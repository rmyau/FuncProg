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

//1.1 Найти кол-во элементов, расположенных после последнего максимального
//Ищем индекс последнего максимального элемента
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

let NumAfterMax lint = 
    let indexMax = List.findIndexBack (fun x -> x =(FindMax lint)) lint 
    let rec Num lint indMax indEl number = 
        match lint with 
        |[]-> number
        |head::tail ->
            let newNum = 
                if indEl>indMax then number+1
                else number
            let newIndEl = indEl+1
            Num tail indMax newIndEl newNum
    Num lint indexMax 0 0


[<EntryPoint>]
let main argv =
    readData|>NumAfterMax|>Console.WriteLine 
    //lint[8]={1,5,10,2,6,10,1,2}
    0 // return an integer exit code
