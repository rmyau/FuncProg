// Learn more about F# at http://fsharp.org

open System
open Program
//1.51. Для введенного списка построить два списка L1 и L2, где элементы L1
//это элементы исходного списка без повторений, а элемент списка L2 с
//номером i показывает, сколько раз элемент списка L1 с таким номером
//повторяется в исходном.

let findList list = 
  List.fold (
        fun m x -> 
            let f = fst(m) @ [fst(x)]
            let s = snd(m) @ [snd(x)]
            (f,s)) ([], [])(List.countBy (fun x->x) list)
    
    
[<EntryPoint>]
let main argv =
    let bigList = readData() |> findList
    Console.WriteLine("L1")
    writelist (fst(bigList))
    Console.WriteLine("L2")
    writelist (snd(bigList))
    0 // return an integer exit code
