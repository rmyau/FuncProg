open System
open Program
//1 Даны две последовательности, найти наибольшую по длине общую подпоследовательность.

let circleLeft (list: 'int list) =
    list.Tail @ [list.Head]

let findPosl1 list1 list2=
    fst (List.fold2 (fun s x1 x2->
        if x1=x2 then
            let new_c = (snd s)@[x1]
            if List.length new_c >= List.length (fst s) then
                (new_c, new_c)
            else 
                (fst s, new_c)
        else
            (fst s, [])    
    ) ([], []) list1 list2)

let findPosl list1 list2 = 
    let rec ff list1 list2 iter (posl:'int List)= 
        if iter=List.length list2 then posl
        else 
            let newPosl =
                if List.length posl<List.length (findPosl1 list1 list2) then findPosl1 list1 list2
                else posl
            ff list1 (circleLeft list2) (iter+1) newPosl
    ff list1 list2 1 []
            
//123465 and 658123
[<EntryPoint>]
let main argv =
    let list1= readData()
    let list2= readData()
    let result = findPosl list1 list2
    writelist result
    0
