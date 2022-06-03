open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup

//главная форма
let mwXaml = "
<Window
xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
Title='MainForm' Height='250' Width='300'>
<Grid>
<Grid.ColumnDefinitions>
<ColumnDefinition Width='156*' />
</Grid.ColumnDefinitions>
<Button Content='Нажми!' Height='120' HorizontalAlignment='Center' Margin='
12,40,0,0' Name='button' VerticalAlignment='Top' Width='120' 
Grid.ColumnSpan='2' />
</Grid>
</Window>
"
let getWindow(mwXaml) = 
    let xamlObj=XamlReader.Parse(mwXaml)
    xamlObj :?> Window
let win = getWindow(mwXaml)

let btnMain = win.FindName("button") :?> Button

let form1= "
<Window
xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
    xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
    Title='Загадочка' Height='180' Width='351'>
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width='156*' />
    </Grid.ColumnDefinitions>
    <TextBlock Text = 'Чтобы в цель попасть хоть раз,' Height = '120' 
     Width = '300' Margin='80,5,0,0'/>
    <TextBlock Text = 'нужен меткий, зоркий...' Height = '130' 
    Width = '300' Margin='100,40,0,0'/>
    <Button Content = 'Топор' Height = '23' HorizontalAlignment = 'Left' Margin = '10,40,0,0'
    Width = '100' Name = 'button1'/>
    <Button Content = 'Глаз' Height = '23' HorizontalAlignment = 'Left' Margin = '120,40,0,0'
    Width = '100' Name = 'button2'/>
    <Button Content = 'Ум' Height = '23' HorizontalAlignment = 'Left' Margin = '230,40,0,0'
    Width = '100' Name = 'button3'/>
    </Grid>
</Window>
"
let win1 = getWindow(form1)
btnMain.Click.AddHandler(fun _ _ -> win1.Show())

let button1 = win1.FindName("button1") :?> Button
let button2 = win1.FindName("button2") :?> Button
let button3 = win1.FindName("button3") :?> Button

let formWrong= "
<Window
xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
    xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
    Title='Ха-ха!' Width = '300' Height = '100' >
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width='156*' />
    </Grid.ColumnDefinitions>
    <TextBlock Text = 'Ха! Неправильно!' Height = '120' 
     Width = '300' Margin='90,20,0,0' />
    </Grid>
</Window>
"
let winWrong = getWindow(formWrong)
button1.Click.AddHandler(fun _ _ -> winWrong.Show())
button3.Click.AddHandler(fun _ _ -> winWrong.Show())

let formRight= "
<Window
xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
    xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
    Title='Юху' Width = '300' Height = '100' >
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width='156*' />
    </Grid.ColumnDefinitions>
    <TextBlock Text = 'Молодец! Правильно!' Height = '120' 
     Width = '300' Margin='75,20,0,0' />
    </Grid>
</Window>
"
let winRight = getWindow(formRight)
button2.Click.AddHandler(fun _ _ -> winRight.Show())


//
[<STAThread>] 
[<EntryPoint>]
let main argv =
    ignore <| (new Application()).Run win
    0 