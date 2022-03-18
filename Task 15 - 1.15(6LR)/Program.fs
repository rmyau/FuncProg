// Learn more about F# at http://fsharp.org

open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    Console.WriteLine("Введите размерность списка:  ")
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Введите список: ")
    readList n

//1.15 Дан массив и индекс, 
//определить является ли элемент по указанному индексу локальным минимумом

let IsLocalMin Ind lint = 
    let rec LocalMin lint Ind ElByInd IndEl = //ElByInd - значение в списке с заданным индексом
        match lint with
        |[]->true //если лок миним - последний элемент
        |head::tail->
            let result=
                if (IndEl+1=Ind || IndEl=Ind) then
                    if (IndEl=Ind) then LocalMin tail Ind head (IndEl+1) 
                    else
                        if (head>=tail.Head && IndEl+1=Ind) then LocalMin tail Ind tail.Head (IndEl+1)
                        else false
                else               
                    if (IndEl-1=Ind && head>=ElByInd) then true
                        else false
            if (IndEl>=Ind-1 && IndEl<=Ind+1) then result
            else
                LocalMin tail Ind ElByInd (IndEl+1)
    LocalMin lint Ind 0 0 

       
[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите индекс: ")
    let ind = Convert.ToInt32(Console.ReadLine())
    readData |> IsLocalMin ind |> Console.WriteLine
    //{2,3,4,1} - 3
    //{1,2,3,4} - 0 
    //{2,3,1,4,5} - 2 / 3

    0 // return an integer exit code
