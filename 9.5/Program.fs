open System
open System.Windows.Forms
open System.Drawing
Application.EnableVisualStyles()
//1 Разработать программу, которая будет выводить первый
//элемент списка, делящийся на 5

let form = new Form(Text = "9LR")
let font =  new System.Drawing.Font("Microsoft Sans Serif", 14.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)))
let label = new Label(Location = new Point(55,20), AutoSize = true, Font = font, Text = "Введите массив")

let textBox = new TextBox(Text = "", Location = new Point(60,60), Width = 160)
let label2 = new Label(Location = new Point(50,100), AutoSize = true, Font = font, Text = "Искомый элемент")
let textBox2 = new TextBox(Text = "", Location = new Point(100,140), Width = 80)

let getList() = 
    let str = textBox.Text.Trim()
    if String.IsNullOrEmpty str then []
    else 
        List.ofArray (str.Split(',')) |> List.map (fun x-> Int32.Parse x)

let findEl(list)=
    List.find (fun x -> x%5=0) list

let fontBtn =  new System.Drawing.Font("Microsoft Sans Serif", 12.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)))
let button = new Button(Text = "Вывести", Location = new Point(100,190),AutoSize = true, Font=fontBtn)
button.Click.AddHandler (fun _ _ ->
    let list = getList()
    let res = findEl list
    let run = textBox2.Text<-(res |> string)
    run)


form.Controls.Add(button)
form.Controls.Add(label)
form.Controls.Add(textBox)
form.Controls.Add(label2)
form.Controls.Add(textBox2)
Application.Run(form)