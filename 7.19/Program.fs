// Learn more about F# at http://fsharp.org

open System
//1 Дана строка. Необходимо найти общее количество русских символов.
let numRus str = String.length (String.filter (fun x -> x>='А' && x<='я') str)
//9 Дана строка. Необходимо проверить образуют ли строчные
//символы латиницы палиндром.
let isPalindrom str = 
    let newStr = String.filter (fun x -> x>='а' && x<='я' || x>='a' && x<='z') str
    let rec palindrom str =
        match str with
        |""-> true
        |_-> 
            if str.[0]<>str.[str.Length-1] then false
            else 
                palindrom str.[1..str.Length-2]
    palindrom newStr

//18 Найти в тексте даты формата «день.месяц.год».
//let findData str = 
  //  let rec f str = 
    //    let tchka = List.findIndex (String.)

[<EntryPoint>]
let main argv =
    let str = Console.ReadLine()
    numRus str |>printf "Кол-во русских символов в строке: %O\n"
    isPalindrom str|>printf "Образуют ли строчные буквы палиндром: %O"


    0 // return an integer exit code
