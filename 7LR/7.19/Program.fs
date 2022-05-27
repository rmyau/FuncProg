// Learn more about F# at http://fsharp.org

open System

let rec writelist list=
    List.iter(fun x->printfn "%O" x) list
//1 Дана строка. Необходимо найти общее количество русских символов.
let numRus str = Convert.ToString(String.length (String.filter (fun x -> x>='А' && x<='я') str))
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
    Convert.ToString(palindrom newStr) 

//18 Найти в тексте даты формата «день.месяц.год».
let isDate (str:string)= 
    let day = str.Remove(2,8)
    let month = str.Remove(0,3).Remove(2,5)
    let year = str.Remove(0,6)
    //Console.WriteLine ("day - {0}, month - {1}, year - {2}", day, month, year)
    day<="31"&&day>="01" && month>="01"&& month<="12" && year >"0000" && year<"9999"

let findData (str:string) = 
    let rec date (strBase:string) (strNow: string) (strList: string) = 
        match strBase with
        |"" -> strList
        |_-> 
            let newstr = 
                if strNow.Length<10 then
                    strNow + strBase.Remove(1,strBase.Length-1)
                else strNow.Remove(0,1)+(strBase.Remove(1,strBase.Length-1))
            let newList = 
                if (newstr.Length = 10 && isDate newstr) then strList+"\n"+newstr
                else strList
            date (strBase.Remove(0,1)) newstr newList
    if date str "" "" = "" then "Дат нет" else date str "" "" 

let choose = function
    |1 -> numRus
    |2 -> isPalindrom
    |3 -> findData


[<EntryPoint>]
let main argv =
    printfn"Введите строку"
    let str = Console.ReadLine()
    printfn"Выберите:"
    printfn"1. Общее количество русских символов в строке"
    printfn"2. Образуют ли строчные символы латиницы палиндром"
    printfn"3. Найти в тексте даты формата «день.месяц.год»"
    let func = Console.ReadLine() |>Convert.ToInt32 |> choose
    str |> func |> printfn "Результат: %O"
    

    0 // return an integer exit code
