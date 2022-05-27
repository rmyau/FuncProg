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



[<EntryPoint>]
let main argv =
    
    0 // return an integer exit code