// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.Text.RegularExpressions
open System.Diagnostics
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
    member this.list: (Passport list) = list
    override this.searchDoc(passport:Passport) = 
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

    member this.binList = List.sortBy(fun (pas:Passport) -> (pas.number,pas.series)) binList
          
    override this.searchDoc(passport) = 
        BinSearch this.binList passport

type PassportSet(list: Passport list) = 
    inherit DocCollection()
    member this.set =Set.ofList list
    override this.searchDoc(passport) = 
        Set.contains passport this.set


let charsForRandom = "абвгдежзиклмнопрстуфхчшщьыъэюя"
let randomStr len =
    let random = Random()
    let randomChars = [|for i in 0..len -> charsForRandom.[random.Next(charsForRandom.Length)]|]
    new System.String(randomChars)

let randPassport () = 
    let r = Random()
    let name = randomStr (r.Next(5,11))
    let surname = randomStr (r.Next(5,11))
    let number = r.Next(100000,999999)
    let series = r.Next(1000,9999)
    let birthday = r.Next(30).ToString()+"."+r.Next(1,12).ToString()+"."+r.Next(1925,2010).ToString()
    let place = randomStr (r.Next(10,20))
    Passport(name,surname,number,series, birthday,place)
let randPasList(len) = 
   [for i in 0..len -> randPassport() ]
    

[<EntryPoint>]
let main argv =
    let p = Passport("Егор","Иванов",0313, 455544, "09.09.3000", "ghjhfjfhjf")
    let passportList = randPasList (1000)

    let list = PassportList (passportList)
    let array = PassportArray(List.toArray passportList)
    let set = PassportSet(passportList)
    let binarylist = PassportBinList(passportList)
    
    let time = new Stopwatch()

    time.Restart()
    list.searchDoc(p)
    time.Stop()
    printfn "time list - %O" time.Elapsed

    time.Restart()
    array.searchDoc(p)
    time.Stop()
    printfn "time array - %O" time.Elapsed

    time.Restart()
    set.searchDoc(p)
    time.Stop()
    printfn "time set - %O" time.Elapsed

    time.Restart()
    binarylist.searchDoc(p)
    time.Stop()
    printfn "time binary list - %O" time.Elapsed

    
    0 // return an integer exit 
