open System
open System.Windows.Forms
open System.Drawing
Application.EnableVisualStyles()
let form = new Form(Text = "Инвертирование массива")
let label = new Label()
label.Location<-new Point(55,20)
label.Text<-"Введите массив"
label.AutoSize<-true
let font =  new System.Drawing.Font("Microsoft Sans Serif", 14.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)))
label.Font<-font

let textBox = new TextBox(Text = "", Location = new Point(60,60), Width = 160)
let label2 = new Label(Location = new Point(37,100), AutoSize = true, Font = font, Text = "Перевернутый массив")
let textBox2 = new TextBox(Text = "", Location = new Point(60,140), Width = 160)

let fontBtn =  new System.Drawing.Font("Microsoft Sans Serif", 12.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)))
let button = new Button(Text = "Вывести", Location = new Point(90,190),AutoSize = true, Font=fontBtn)
button.Click.AddHandler(fun _ _ ->
    let stringRev(txt:string) = 
        System.String(Array.rev (txt.ToCharArray()))
    let run  =  textBox2.Text<-(stringRev(textBox.Text))
    run)

form.Controls.Add(button)
form.Controls.Add(label)
form.Controls.Add(textBox)
form.Controls.Add(label2)
form.Controls.Add(textBox2)
Application.Run(form)

