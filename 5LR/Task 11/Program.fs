
open System

//c 11
let Answer11 = 
    Console.WriteLine("Какой у Вас любимый язык?")
    let ans=
        Console.ReadLine()
    match ans.Trim() with
    |"F#"|"Prolog" -> Console.WriteLine("Подлиза!")
    |"C++" -> Console.WriteLine("Здорово!")
    |"Python"->Console.WriteLine("Похоже, ты не ищешь сложных путей!)")
    |"C#" -> Console.WriteLine("А ты крутой!")
    |"Pascal" -> Console.WriteLine("А ты интеллектуал!")
    |_ ->Console.WriteLine("Интересно!")        

[<EntryPoint>]
let main argv =
    
    0 // return an integer exit code
