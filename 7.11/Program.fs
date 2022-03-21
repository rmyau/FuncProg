

open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n
//1.1 - найти кол-во элементов, расположенных после последнего максимального
let F list = List.length list - (List.findIndexBack (fun x-> x=(List.max list) ) list)-1 

[<EntryPoint>]
let main argv =
   readData |> F |>Console.WriteLine;
    0 // return an integer exit code
