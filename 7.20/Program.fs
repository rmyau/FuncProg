// Learn more about F# at http://fsharp.org

open System
 let readListStr n = 
    let rec read n list = 
        match n with 
        |0-> list 
        |_->
            let newList = list @ [Console.ReadLine()]
            read (n-1) newList
    read n []

let rec writelist list=
    List.iter(fun x->printfn "%O" x) list
//1 В порядке увеличения разницы между средним количеством соглас-
//ных и средним количеством гласных букв в строке

let difference str = 
    let glasAverage = 
        Convert.ToSingle(String.length(String. filter (fun x -> x='а' ||x='о'||x='э'|| x='е'||x='и'||x='ы'||x='у'||x='ё'||x='ю'||x='я') str))/ Convert.ToSingle(String.length str)
    let soglAverage = 
        Convert.ToSingle(String.length (String. filter (fun x -> not(x='а' ||x='о'||x='э'||x='е'||x='и'||x='ы'||x='у'||x='ё'||x='ю'||x='я')) str)) / Convert.ToSingle(String.length str)
    Console.WriteLine(Math.Abs(glasAverage-soglAverage))
    Math.Abs(glasAverage-soglAverage)

let sortStrByDif strList = List.sortBy (fun x->difference x) strList

//6.В порядке увеличения медианного значения выборки строк
//(прошлое медианное значение удаляется из выборки и производится поиск
//нового медианного значения)

let findMedian list = List.item ((List.length list)/2) (List.sort list)

let sortMedian list = 
    let rec sort list sortList =
        match list with
        |[]->sortList
        |_ ->
            //Console.WriteLine("sort");
            //writelist (List.sort list)
            let nowMed = findMedian list
            //Console.WriteLine("NowMed = {0}", nowMed)
            let indMed =List.findIndex (fun x->x=nowMed) list
            let newList = List.removeAt(indMed) list
            sort newList (sortList @ [nowMed])
    sort list []
            
[<EntryPoint>]
let main argv =
    Console.ReadLine()|> Convert.ToInt32 |> readListStr |> sortMedian |> writelist 
    0 // return an integer exit code
