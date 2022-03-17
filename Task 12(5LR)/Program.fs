// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
let main argv =
    let Answer (lang:string)=
        match lang.Trim() with
        |"F#"|"Prolog" -> "Подлиза!"
        |"C++" -> "Здорово!"
        |"Python"->"Похоже, ты не ищешь сложных путей!)"
        |"C#" -> "А ты крутой!"
        |"Pascal" -> "Сразу видно - интеллектуал!"
        |_ ->"Интересно!" 
    //Суперпозиция
    Console.WriteLine("Какой у Вас любимый язык?")
    (Console.ReadLine>>Answer>>Console.WriteLine)()
   //Каррирование
    Console.WriteLine("Какой у Вас любимый язык?")
    let result answer func out = out(func(answer()))
    result Console.ReadLine Answer Console.WriteLine
    0 

   
