// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.Text.RegularExpressions;
type Passport (name: string, surname: string, number: int, series:int,birthday: string,birthPlace: string ) =
    member this.name = name
    member this.surname = surname
    member this.number = number
    member this.series = series
    member this.birthday = birthday
    member this.birthPlace = birthPlace

    override this.ToString() = $"Passport name: {this.name}, surname: {this.surname}, number: {this.number}, series: {this.series}, birthday: {this.birthday}, birthPlace: {this.birthPlace}."


[<EntryPoint>]
let main argv =
    let p = Passport("Егор","Иванов",0313, 455544, "09.09.3000", "ghjhfjfhjf")
    printfn "%O" (p.ToString())
    0 // return an integer exit code