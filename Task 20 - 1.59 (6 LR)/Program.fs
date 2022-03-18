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
//1.59 Построить новый список из квадратов неотрицательных чисел
//меньших ста и встречающихся в массиве больше 2 раз
let RepeatEl elem lint= 
    let rec Repeat lint (el:int) num = 
        match lint with 
        |[]->num
        |h::tail->
            let newNum = 
                if el=h then (num+1)
                else num
            Repeat tail el newNum
    Repeat lint elem 0
        
let filter predicate f lint  =
    let rec filt lint pr newList = 
        match lint with
        |[]->newList
        |h::tail ->
            let nextNewList = 
                if pr h then (newList @ [f h])
                else newList
            filt tail pr nextNewList
    filt lint predicate []

let delEL list el = filter (fun x -> (x <> el)) (fun x->x) list 
let uniq list = 
    let rec uniq1 list newList = 
        match list with
            |[] -> newList
            | h::t -> 
                        let listWithout = delEL t h
                        let newnewList = newList @ [h]
                        uniq1 listWithout newnewList
    uniq1 list [] 
[<EntryPoint>]
let main argv =
    let l = readData
    filter (fun x -> x<100 && x>0 && (RepeatEl x l)>2) (fun x -> x*x) l|>uniq |>writeList
    0 // return an integer exit code
