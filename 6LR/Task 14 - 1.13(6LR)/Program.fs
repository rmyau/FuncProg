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
//1.13 Разместить элементы расположенные до минимального в конце массива
//Ищем индекс последнего максимального элемента
let FindMaxInd lint = 
    let rec MaxEl lint max indM indEL=
        match lint with
        |[]->indM
        |h::tail -> 
            let newMax = if h>=max then h else max
            let newInd = if h>=max then indEL else indM
            MaxEl tail newMax newInd (indEL+1)
    MaxEl lint lint.Head 0 0 

let ListBeforeMin lint = 
    let indexMin = FindMaxInd lint
    let rec BeforeMin lint indMin indEl ListBefMin ListAfter = 
        match lint with 
        |[]-> ListAfter @ ListBefMin
        |h::tail ->
            let newIndEl = indEl+1
            if indEl<indMin then 
                let NewList = ListBefMin @ [h]
                BeforeMin tail indMin newIndEl NewList ListAfter
            else 
                let NewList = ListAfter @ [lint.Head]
                BeforeMin tail indMin newIndEl ListBefMin NewList
    BeforeMin lint indexMin 0 [] []            
[<EntryPoint>]
let main argv =
    readData |> ListBeforeMin |>writeList
    //{2,3,4,1,5,6,7,8}
    0 // return an integer exit code
