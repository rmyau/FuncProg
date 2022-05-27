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

//М3: произведение делителей числа, сумма цифр которых меньше сумма цифр исходного числа
let SumCifr n = 
    let rec Sum n init = 
        if n =0 then init
        else 
            let nextInit = init+(n%10)
            let nextN=n/10
            Sum nextN nextInit
    Sum n 0

let MultDel n = 
    let rec MultDelCifr n result del = 
        if del=1 then result
        else 
            let nextRes= 
                if n%del=0 && (SumCifr del < SumCifr n) then result*del
                else result
            let nextDel = del-1
            MultDelCifr n nextRes nextDel
    MultDelCifr n 1 n

[<EntryPoint>]
let main argv =
    let res1 = SumDelPrime 6
    Console.WriteLine("Сумма простых делителей числа 6 = {0}",res1)

    let res2=NumOddCifr 1234567
    Console.WriteLine("Кол-во нечетных цифр числа, которые больше 3 для числа 1234567 = {0}",res2)

    //del(32) = {32,16,8,4,2,1}
    let res3=MultDel 32
    Console.WriteLine("Произведение делителей 32, сумма цифр которых меньше суммы цифр 32 = {0}",res3)//4*2

    0 // return an integer exit code
