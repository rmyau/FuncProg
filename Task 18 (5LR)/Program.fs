// Learn more about F# at http://fsharp.org

open System

//М1: сумма простых делителей числа 
let PrimeNum n = 
    let rec Prime n del = 
        if del = 1 then true
        else 
            if n%del=0 then false
            else 
                let newDel=del-1
                Prime n newDel
    Prime n (n-1)

let SumDelPrime n = 
    let rec SumDelPr n sumInit del = 
        if del=1 then sumInit
        else 
            let NextSum=
                if n%del=0 && (PrimeNum del = true) then sumInit+del
                else sumInit
            let newDel=del-1
            SumDelPr n NextSum newDel
    SumDelPr n 0 n  

[<EntryPoint>]
let main argv =
    let res1 = SumDelPrime 6
    Console.WriteLine("Сумма простых делителей числа 6 = {0}",res1)
    0 // return an integer exit code
