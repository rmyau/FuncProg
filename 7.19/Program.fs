﻿// Learn more about F# at http://fsharp.org

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
let findData str = 
    let rec date (strBase:string) (strNow: string) (strList: 'string List) = 
        match strBase with
        |"" -> strList
        |_-> 
            let newstr = 
                if strNow.Length<10 then
                    strNow+strBase.Remove(1 ,(strBase.Length -2)) String.
                else (strNow.Remove 0)+ strBase[0]
            let newList = 
                if newstr.Length = 10 && (newstr>"00.00.0000" && newstr<"31.12.9999") then strList @ [newstr]
                else strList
            date (strBase.Remove 0) newstr newList
    date str "" []

[<EntryPoint>]
let main argv =
    let str = Console.ReadLine()
    numRus str |>printf "Кол-во русских символов в строке: %O\n"
    isPalindrom str|>printf "Образуют ли строчные буквы палиндром: %O"


    0 // return an integer exit code
