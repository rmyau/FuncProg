// Learn more about F# at http://fsharp.org

open System
 let readListStr n = 
    let rec read n list = 
        match n with 
        |0-> list 
        |_->
            let newList = list @ [Console.ReadLine()]
            read (n-1) newList
    read n []

let rec writelist list=
    List.iter(fun x->printfn "%O" x) list
//1 В порядке увеличения разницы между средним количеством соглас-
//ных и средним количеством гласных букв в строке

let difference str = 
    let glasAverage = 
        Convert.ToSingle(String.length(String. filter (fun x -> x='а' ||x='о'||x='э'|| x='е'||x='и'||x='ы'||x='у'||x='ё'||x='ю'||x='я') str))/ Convert.ToSingle(String.length str)
    let soglAverage = 
        Convert.ToSingle(String.length (String. filter (fun x -> not(x='а' ||x='о'||x='э'||x='е'||x='и'||x='ы'||x='у'||x='ё'||x='ю'||x='я')) str)) / Convert.ToSingle(String.length str)
    Console.WriteLine(Math.Abs(glasAverage-soglAverage))
    Math.Abs(glasAverage-soglAverage)

let sortStr strList = List.sortBy (fun x->difference x) strList
[<EntryPoint>]
let main argv =
    Console.ReadLine()|> Convert.ToInt32 |> readListStr |> sortStr |> writelist 
    0 // return an integer exit code
