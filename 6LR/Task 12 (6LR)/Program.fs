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
let FindMaxInd lint = 
    let rec MaxEl lint max indM indEL=
        match lint with
        |[]->indM
        |h::tail -> 
            let newMax = if h>=max then h else max
            let newInd = if h>=max then indEL else indM
            MaxEl tail newMax newInd (indEL+1)
    MaxEl lint lint.Head 0 0 
let ListLenght lint = 
    let rec len lint count =
        match lint with 
        |[]->count
        |h::tail->
            let newCount = count+1
            len tail newCount
    len lint 0
let NumAfterMax lint = 
    let indexMax =FindMaxInd lint 
    let result = ListLenght lint - indexMax-1
    result


[<EntryPoint>]
let main argv =
    readData|>NumAfterMax|>Console.WriteLine 
    //lint[8]={1,5,10,2,6,10,1,2}
    0 // return an integer exit code
