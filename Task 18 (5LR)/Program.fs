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

//М2: найти кол-во нечетных цифр числа, которые > 3

let NumOddCifr n = 
    let rec NumCifr n num = 
        if n = 0 then num
        else 
            let nextNum = 
                if (n%10)%2=1 && (n%10)>3 then (num+1)
                else num
            let NextN = n/10
            NumCifr NextN nextNum
    NumCifr n 0
[<EntryPoint>]
let main argv =
    let res1 = SumDelPrime 6
    Console.WriteLine("Сумма простых делителей числа 6 = {0}",res1)

    let res2=NumOddCifr 1234567
    Console.WriteLine("Кол-во нечетных цифр числа, которые больше 3 для числа 1234567 = {0}",res2)
    0 // return an integer exit code
