// Learn more about F# at http://fsharp.org

open System





let rec readList n =
    List.init(n) (fun index->Console.ReadLine()|>Int32.Parse)

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let rec writelist list=
    List.iter(fun x->printfn "%O" x) list

//1.13 Дан целочисленный массив. Необходимо разместить элементы,
//расположенные до минимального, в конце массива.

let ChangeList list =
    let indMin=List.findIndex(fun x-> x=List.min list) list
    let ListBeforeMin = list.[..(indMin-1)]
    let ListAfterMin = list.[indMin..]
    ListAfterMin @ ListBeforeMin

[<EntryPoint>]
let main argv =
    readData |>ChangeList |> writelist
    0 // return an integer exit code
