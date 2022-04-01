// Learn more about F# at http://fsharp.org

open System
//1 Дана строка. Необходимо найти общее количество русских символов.
let numRus str = String.length (String.filter (fun x -> x>='А' && x<='я') str)
//9 Дана строка. Необходимо проверить образуют ли строчные
//символы латиницы палиндром.
let isPalindrom str = 
    let newStr = String.filter (fun x -> x>='а' && x<='я' || x>='a' && x<='z') str
    let rec palindrom str
[<EntryPoint>]
let main argv =
    let str = Console.ReadLine()
    numRus str |>printf "Кол-во русских символов в строке: %O"


    0 // return an integer exit code
