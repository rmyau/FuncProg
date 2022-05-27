// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

type Maybe<'a>=
    |Just of 'a
    |Nothing

//функтор 
let fmapMaybe f p = 
    match p with
    |Just a -> Just (f a)
    |Nothing -> Nothing

//аппликативный функтор  - и функция и значение в контексте
let applyMaybe mf mp = 
    match mf, mp with
    |Just f, Just a -> Just (f a)
    |_ ->Nothing

let monadMaybe f m = //f переводит значение в контекст -  bind
    match m with
    |Just p -> f p
    |_ -> Nothing

[<EntryPoint>]
let main argv =
    //проверка правил
    let id x = x
    let p1 = fmapMaybe (fun x -> x+x) (Just 3)
    //1 закон  - подъем id в контекст не влияет на вычисление
    printfn "1. %O = %O" (id p1) (fmapMaybe id p1)

    //2 закон - Для 2 функций f и g композиция их подъемов эквивалентна подъему композиции.
    let f x = x+3
    let g x = x*x
    let p2 = fmapMaybe f (Just 4)
    printfn "2. %O = %O" (fmapMaybe g p2) (fmapMaybe (f>>g) (Just 4)) 

    //аппликативный функтор
    //1 - применение id к поднятому знач эквивал неподнятой к неподнятому
    let p3 = applyMaybe (Just f) (Just 5)
    printfn "1. %O = %O" (id p3) (applyMaybe (Just id) p3)

    //2 - Если y=f(x), то подъем функции f и значения х и применение к ним
    //функции apply приведет к такому же результату, что и подъем y.
    let x = 2
    let y = g x
    printfn "2. %O = %O" (Just y) (applyMaybe (Just g) (Just x))

    //3 аргументы можно менять местами
    //не выполняется
    let p4 = applyMaybe (Just f) (Just 6)
    //let p5 = applyMaybe
    //4 - в f# не выполняется
    0 // return an integer exit code