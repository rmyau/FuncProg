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

let ListBeforeMin lint = 
    let indexMin = List.findIndexBack (fun x -> x =(FindMin lint)) lint 
    let rec BeforeMin lint indMin indEl ListBefMin ListAfter = 
        match lint with 
        |[]-> ListAfter @ ListBefMin
        |_ ->
            let newIndEl = indEl+1
            if indEl<indMin then 
                let NewList = ListBefMin @ [lint.Head]
                BeforeMin lint.Tail indMin newIndEl NewList ListAfter
            else 
                let NewList = ListAfter @ [lint.Head]
                BeforeMin lint.Tail indMin newIndEl ListBefMin NewList
    BeforeMin lint indexMin 0 [] []            
           
    BeforeMin lint indexMin 0 [] []
[<EntryPoint>]
let main argv =
    readData |> ListBeforeMin |>writeList
    //{2,3,4,1,5,6,7,8}
    0 // return an integer exit code
