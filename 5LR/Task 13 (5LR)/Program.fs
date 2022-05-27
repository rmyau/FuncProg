// Learn more about F# at http://fsharp.org

open System

//Произведение цифр числа

//Рекурсия вверх
let rec MultUp n = 
    if n=0 then 1
    else (n%10)*MultUp (n/10)

//Рекурсия вниз
let MultDown n =
    let rec MultIn n result = 
        if n=0 then result
        else 
            let NextResult= result*(n%10)
            let Next_n = n/10
            MultIn Next_n NextResult
    MultIn n 1

//Максимальная цифра
//Рекурсия вверх
let rec MaxCifrUp n = 
    if n <10 then n 
    else 
        if MaxCifrUp(n/10)>n%10 then MaxCifrUp(n/10)
        else n%10

//Рекурсия вниз
let MaxCifrDown n =
    let rec MaxCifr n res = 
        match n with
        |0->res
        |_->
            if n%10>res then (MaxCifr (n/10) (n%10))
            else MaxCifr (n/10) res
    MaxCifr n 0

//Минимальная цифра
//Рекурсия вверх
let rec MinCifrUp n = 
    if n <10 then n 
    else 
        if MinCifrUp(n/10)<n%10 then MinCifrUp(n/10)
        else n%10

//Рекурсия вниз
let MinCifrDown n =
    let rec MinCifr n res = 
        match n with
        |0->res
        |_->
            if n%10<res then (MinCifr (n/10) (n%10))
            else MinCifr (n/10) res
    MinCifr n 10
[<EntryPoint>]
let main argv =
    let n=Convert.ToInt32(Console.ReadLine())
    Console.WriteLine( "Произведение:")
    Console.WriteLine( MultUp n)
    Console.WriteLine( MultDown n)
    Console.WriteLine( "Максимальная цифра:")
    Console.WriteLine( MaxCifrUp n)
    Console.WriteLine( MaxCifrDown n)
    Console.WriteLine( "Минимальная цифра:")
    Console.WriteLine( MinCifrUp n)
    Console.WriteLine( MinCifrDown n)
    0 // return an integer exit code
