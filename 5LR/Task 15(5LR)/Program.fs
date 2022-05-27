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
let RoundPrimeNum n f init = 
    let rec PrimeNum n f init num = 
        if num = 0 then init
        else 
            let nextInit=
                if NOD n num then (f init num)
                else init
            let nextNum = num-1
            PrimeNum n f nextInit nextNum
    PrimeNum n f init (n-1)
//Функция Эйлера
let Eyler n = 
    RoundPrimeNum n (fun x y -> x+1) 0
[<EntryPoint>]
let main argv =
    Console.WriteLine(NOD 11 9);
    Console.WriteLine(RoundPrimeNum 6 (fun x y -> x+y) 0)
    Console.WriteLine(Eyler 36)
    0 // return an integer exit code
