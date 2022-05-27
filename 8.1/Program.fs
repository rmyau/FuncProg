// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

//1 часть
[<AbstractClass>]
type GeomFigure() = 
    abstract member Area: unit ->double

type IPrint = interface
    abstract member Print: unit -> unit
    end
type Rectangle(height: double, width: double) = 
    inherit GeomFigure()
    let mutable propertyW = width
    let mutable propertyH = height

    member this.Width 
        with get() = propertyW
        and set(value) = propertyW <- value

    member this.Height
        with get() = propertyH
        and set(value) = propertyH <- value

    override this.Area() = (this.Width*this.Height)
    override this.ToString() = sprintf"Rectangle width = %f, height = %f, Area = %f" this.Width this.Height (this.Area())
    interface IPrint with
        member this.Print() = this.ToString() |> Console.WriteLine



type Square(a: double) = 
    inherit Rectangle(a,a)
    override this.ToString() = sprintf "Square side = %f, Area = %f" this.Height (this.Area())

    interface IPrint with
        member this.Print() = this.ToString() |> Console.WriteLine

type Circle(radius: double ) = 
    inherit GeomFigure()

    let mutable propertyR = radius

    member this.Radius
        with get()=propertyR
        and set(value) = propertyR <-value

    override this.Area() = (this.Radius* this.Radius * Math.PI)

    override this.ToString() = sprintf"Circle radius = %f, Area = %f" this.Radius (this.Area())
    interface IPrint with
        member this.Print() = this.ToString() |> Console.WriteLine

//part 2
type GeometryFigure = 
    |Rectangle of double * double
    |Square of double 
    |Circle of double

let GetArea (figure: GeometryFigure) =
    match figure with
    | Rectangle(w,h) -> w * h
    | Square(a) -> a*a
    | Circle(r) -> Math.PI * r * r




[<EntryPoint>]
let main argv =
    let circle = Circle(2.0)
    
    //printfn "Hello world %s" message
    0 // return an integer exit code