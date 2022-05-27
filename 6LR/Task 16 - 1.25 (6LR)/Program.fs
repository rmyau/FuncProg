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

//1.25 Дан массив и интервал. Найти максимальный из элементов в этом интервале
let MaxInInt (a,b) lint= 
    let rec InInt lint (a,b) max = 
        match lint with
        |[]->max
        |h::tail-> 
            let newMax = 
                if h>max && h>a && h<b then h
                else max
            InInt tail (a,b) newMax
    InInt lint (a,b) a
[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите границы интервала")
    let interval = (Convert.ToInt32(Console.ReadLine()),Convert.ToInt32(Console.ReadLine()))
    readData |> MaxInInt interval|> Console.WriteLine
    0 // return an integer exit code
