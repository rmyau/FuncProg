// Learn more about F# at http://fsharp.org

open System
open Program
//1.51. Для введенного списка построить два списка L1 и L2, где элементы L1
//это неповторяющиеся элементы исходного списка, а элемент списка L2 с
//номером i показывает, сколько раз элемент списка L1 с таким номером
//повторяется в исходном.
let findList list = 
    let rec f (listEl:'int list) list BigList =
        match listEl with
        |[]->BigList
        |_->
            let kk= List.length( List.filter (fun x->x=listEl.Head) list) 
            let newList1 = 
                if kk = 1 && (List.tryFind (fun x->x=listEl.Head) (fst(BigList))<>None) then 
                    (fst(BigList)) @ [listEl.Head] 
                else (snd(BigList))
            let newList2 = (snd(BigList)) @ [kk]
            f listEl.Tail list (newList1, newList2)
    f list list ([],[])
        
[<EntryPoint>]
let main argv =
    let bigList = readData() |> findList
    Console.WriteLine("L1")
    writelist (fst(bigList))
    Console.WriteLine("L2")
    writelist (snd(bigList))
    0 // return an integer exit code
