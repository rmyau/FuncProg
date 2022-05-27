// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.Text.RegularExpressions;
type Passport (name: string, surname: string, number: int, series:int,birthday: string,birthPlace: string ) =
    member this.name 
        with get() = name
        and set(newName:string) =
            if (Regex.IsMatch(newName, "^\\s*[A-ZА-Я][а-яa-z]+\\s*$"))
            then this.name<-newName
            else printf"Данные некорректны"

          
    member this.surname 
        with get() = surname 
        and set(newSurname:string) = 
            if (Regex.IsMatch(newSurname, "^\\s*[A-ZА-Я][а-яa-z]+\\s*$"))
            then this.surname<-newSurname
            else printf"Данные некорректны"

    member this.number  
        with get() = number
        and set(num:int) = 
            if (Regex.IsMatch(num.ToString(), "^\\s*[0-9]{6}\\s*$"))
            then this.number<-num
            else printf"Данные некорректны"

    member this.series 
        with get() = series
        and set(seria:int) = 
            if (Regex.IsMatch(seria.ToString(), "^\\s*[0-9]{4}\\s*$"))
            then this.series<-seria
            else printf"Данные некорректны" 
    member this.birthday 
        with get() = birthday
        and set(birth: string) = 
            if (Regex.IsMatch(birth.ToString(), "^\\s*\\d{2}\\.\\d{2}\\.\\d{4}\\s*$"))
            then this.birthday <- birth
            else printf"Данные некорректны" 
    member this.birthPlace 
        with get() = birthPlace
        and set(place:string) = 
            if (Regex.IsMatch(place, "^\\s*[A-ZА-Я][а-яa-z]+\\s*$"))
            then this.birthPlace <- place
            else printf"Данные некорректны"

    override this.Equals(pas) = 
        match pas with
        | :? Passport as pas -> (pas.number) = (this.number) && (pas.series) = (this.series)
        |_ -> false

    interface IComparable with 
        member this.CompareTo(obj: obj):int =
            match obj with
            | :? Passport as pas ->
                if this.series = pas.series then 
                    this.number.CompareTo (pas.number)
                else this.series.CompareTo (pas.series)
            |_->invalidArg "obj" "Differnt types of arguments"


    override this.ToString() = $"Passport name: {this.name}, surname: {this.surname}, number: {this.number}, series: {this.series}, birthday: {this.birthday}, birthPlace: {this.birthPlace}."

[<AbstractClass>]
type DocCollection() = 
    abstract member searchDoc: Passport -> bool

type PassportArray(arr: Passport array) = 
    inherit DocCollection()
    member this.array = arr
    override this.searchDoc(passport) = 
        Array.exists (fun x -> x.Equals passport) this.array

type PassportList(list: Passport list) = 
    inherit DocCollection()
    member this.list = list
    override this.searchDoc(passport) = 
        List.exists (fun x -> x.Equals passport) this.list

type PassportBinList(binList: Passport list ) = 
    inherit DocCollection()
    let rec BinSearch(list: Passport list) (p:Passport) = 
        match List.length list with
        | 0 -> false
        |len -> 
            let mid = len/2
            let res = compare p list.[mid]
            match res with 
            |0 -> true
            |1->BinSearch list.[..mid - 1] p
            |_ -> BinSearch list.[mid + 1..] p

    member this.binList = List.sortBy(fun (pas:Passport) -> (pas.number,pas.series)) List
          
    override this.searchDoc(passport) = 
        BinSearch this.binList passport

type PassportSet(list: Passport list) = 
    inherit DocCollection()
    member this.set =Set.ofList list
    override this.searchDoc(passport) = 
        Set.contains passport this.set


    

[<EntryPoint>]
let main argv =
    let p = Passport("Егор","Иванов",0313, 455544, "09.09.3000", "ghjhfjfhjf")
    printfn "%O" (p.ToString())
    0 // return an integer exit code