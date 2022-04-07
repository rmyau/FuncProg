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

//1 В порядке увеличения разницы между средним количеством соглас-
//ных и средним количеством гласных букв в строке

let difference str = 
    let glasAverage = 
        String.length(String. filter (fun x -> x='а' ||x='о'||x='э'|| x='е'||x='и'||x='ы'||x='у'||x='ё'||x='ю'||x='я') str)/ String.length str
    let soglAverage = String.length (String. filter (fun x -> !(x='а' ||x='о'||x='э'||x='е'||x='и'||x='ы'||x='у'||x='ё'||x='ю'||x='я')) str) / String.length str
    Math.Abs(glasAverage-soglAverage)

[<EntryPoint>]
let main argv =
    
    0 // return an integer exit code
