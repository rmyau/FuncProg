
open System

//c 11
let Answer11 = 
    Console.WriteLine("Какой у Вас любимый язык?")
    let ans=
        Console.ReadLine()
    if (ans.Trim()="F#" || ans.Trim()="Prolog") then
        Console.WriteLine("Подлиза!")
    else 
        Console.WriteLine("Интересно!")

[<EntryPoint>]
let main argv =
    
    0 // return an integer exit code
