// Learn more about F# at http://fsharp.org

open System


let NOD x y =
    let rec RNod x y del = 
        if del = 1 then true
        else 
            if (x%del=0 && y%del=0) then false
            else RNod x y (del-1)
    if x>y then RNod x y y
    else RNod x y x
//Обход взаимнопростых компонентов числа
let RoundPrimeNumP n f init predicate = 
    let rec PrimeNum n f init predicate num = 
        if num = 0 then init
        else 
            let nextInit=
                if ((NOD n num) = true && (predicate num)) then (f init num)
                else init
            let nextNum = num-1
            PrimeNum n f nextInit predicate nextNum
    PrimeNum n f init predicate (n-1)
//Обход делителей с условием
let DelP n f init predicate = 
    let rec FDel n f init predicate nowN = 
        if nowN=0 then init
        else 
            let NextInit=
                if (n%nowN=0 && (predicate nowN)) then f init nowN
                else init
            let newN=nowN-1
            FDel n f NextInit predicate newN
    FDel n f init predicate n   

[<EntryPoint>]
let main argv =
    let res1= RoundPrimeNumP 36 (fun x y -> x+y) 0 (fun x -> x>3&& x<=10)
    Console.WriteLine(res1) //5+7=12

    let res2 = DelP 12 (fun x y -> x*y) 1 (fun x -> x%2=1)
    Console.WriteLine(res2) //3
    0 // return an integer exit code
