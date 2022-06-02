open System
open System.Drawing
open System.IO
open System.Windows.Forms

//let InitForm() = 
[<EntryPoint>]
let main argv =
    let form = new Form(Width = 400, Height = 300, Text = "Меню", Menu = new MainMenu())
    let button1 = new Button(Text = "Нажми", Top = 50, Left = 125, Width = 150, Height = 140,
    BackColor = System.Drawing.Color.FloralWhite,
    Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    
    //1 Форма
    let form1 = new Form(Text = "Загадочка", Width = 400, Height = 250)
    let label1 = new Label(Text = "Чтобы в цель попасть хоть раз,
    нужен меткий, зоркий...", AutoSize = true, Location = new System.Drawing.Point(60, 50),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    form1.Controls.Add(label1)

    let opForm1 EventsArgs = do form1.ShowDialog()
    button1.Click.Add opForm1
    form.Controls.Add(button1)
    let button2 = new Button(Text = "Топор", Top=125, Left = 50, Width = 100, Height = 50)
    let button3 = new Button(Text = "Глаз", Top=125, Left = 150, Width = 100, Height = 50)
    let button4 = new Button(Text = "Ум", Top = 125, Left = 250, Width = 100, Height = 50)
    form1.Controls.Add(button2)
    form1.Controls.Add(button3)
    form1.Controls.Add(button4)

    //2 форма
    let wrong = new Form(Text= "Ха-ха!", Width = 300, Height = 160)
    let labelWrong = new Label(Text = "Ха! Неправильно!",AutoSize = true, Location = new System.Drawing.Point(60, 50),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    wrong.Controls.Add(labelWrong)
    //3 форма
    let right = new Form(Text="Юху" , Width = 300, Height = 160)
    let labelRight = new Label(Text = "Молодец! Правильно!",AutoSize = true, Location = new System.Drawing.Point(50, 50),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    right.Controls.Add(labelRight)


    let opForm2 EventsArgs = do wrong.ShowDialog()
    let opForm3 EventsArgs = do right.ShowDialog()

    button2.Click.Add(opForm2)
    button3.Click.Add(opForm3)
    button4.Click.Add(opForm2)

    Application.Run(form)
    0