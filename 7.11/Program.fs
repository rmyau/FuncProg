

open System

let rec readList n =
    List.init(n) (fun index->Console.ReadLine()|>Int32.Parse)

let readData() = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let rec writelist list=
    List.iter(fun x->printfn "%O" x) list

//1.1 - найти кол-во элементов, расположенных после последнего максимального
let F list = List.length list - (List.findIndexBack (fun x-> x=(List.max list) ) list)-1 

[<EntryPoint>]
let main argv =
   readData() |> F |>Console.WriteLine;
    0 // return an integer exit code
