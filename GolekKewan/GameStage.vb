Public Class GameStage
    Dim AnimalName As String
    Dim lines() As String
    Dim filepath As String = "base.txt"
    Dim linecount = IO.File.ReadAllLines(filepath).Length
    Dim xRand As Integer
    Dim rnd As New Random
    Public Property nama As String
        Get
            Return AnimalName
        End Get
        Set(ByVal value As String)
            AnimalName = value
        End Set
    End Property
    Public ReadOnly Property dscount As String
        Get
            Dim discCount As Integer = GetWordCountInFile(filepath, "R1")
            Return discCount
        End Get
    End Property
    Public Sub GameStage_Load(sender As Object, e As EventArgs) Handles Me.Load
        MainButton1.Visible = False
        Timer1.Enabled = True
        xRand = rnd.Next(0, linecount)
        Dim line = System.IO.File.ReadAllLines(filepath)(xRand)
        lines = line.Split(",")
        If lines(3) = "R1" Then
            baru()
        End If
        Dim angka As Integer = lines(2)
        picSoal.Image = ImageList1.Images(angka)
        Char1.Text = lines(0)(0)
        Char2.Text = lines(0)(1)
        Char3.Text = lines(0)(2)
        Char4.Text = lines(0)(3)
        Char5.Text = lines(0)(4)
        Char2.Visible = False
        Char3.Visible = False
        Char4.Visible = False
        Char5.Visible = False
        transLabel()
    End Sub
    Public Sub transLabel()
        For Each lbl As Control In Me.Controls
            If TypeOf lbl Is Label Then
                lbl.Parent = PictureBox1
                lbl.BackColor = Color.Transparent
                lbl.BringToFront()
                lbl.ForeColor = Color.Black
            End If
        Next
    End Sub
    Public Sub baru()
        MainButton1.Visible = False
        xRand = rnd.Next(0, linecount)
        Dim line = System.IO.File.ReadAllLines(filepath)(xRand)
        lines = line.Split(",")
        If lines(3) = "R1" Then
            baru()
        End If
        Dim angka As Integer = lines(2)
        picSoal.Image = ImageList1.Images(angka)
        Char1.Text = lines(0)(0)
        Char2.Text = lines(0)(1)
        Char3.Text = lines(0)(2)
        Char4.Text = lines(0)(3)
        Char5.Text = lines(0)(4)
        Char2.Visible = False
        Char3.Visible = False
        Char4.Visible = False
        Char5.Visible = False
        For Each j As Object In Me.Controls
            If TypeOf j Is Button Then
                j.foreColor = Color.Black
            End If
        Next
    End Sub
    Private Function GetWordCountInFile(ByVal filepath As String, ByVal word As String)
        Return System.Text.RegularExpressions.Regex.Matches(IO.File.ReadAllText(filepath), "(?i)\b(\s+)?" & word & "(\s+|\S{0})\b|^" & word & "\.?$|" & word & "[\.\,\;]").Count
    End Function
    Private Sub Guessbutton1_Click(sender As Object, e As EventArgs) Handles _
        Guessbutton1.Click, Guessbutton2.Click, Guessbutton3.Click, Guessbutton4.Click, _
        Guessbutton5.Click, Guessbutton6.Click, Guessbutton7.Click, Guessbutton8.Click,
        Guessbutton9.Click, Guessbutton10.Click, Guessbutton11.Click, Guessbutton12.Click,
        Guessbutton13.Click, Guessbutton14.Click, Guessbutton15.Click, Guessbutton16.Click,
        Guessbutton17.Click, Guessbutton18.Click, Guessbutton19.Click, Guessbutton20.Click,
        Guessbutton21.Click, Guessbutton22.Click, Guessbutton23.Click, Guessbutton24.Click,
        Guessbutton25.Click, Guessbutton26.Click
        Dim btnCheck As String
        btnCheck = sender.text()
        cek(btnCheck)
    End Sub
    Public Sub cek(i As String)
        If i = Char2.Text Then
            'MsgBox("Correct!")
            Char2.Visible = True
            Char2.Parent = PictureBox1
        End If
        If i = Char3.Text Then
            'MsgBox("Correct!")
            Char3.Visible = True
            Char3.Parent = PictureBox1
        End If
        If i = Char4.Text Then
            'MsgBox("Correct!")
            Char4.Visible = True
            Char4.Parent = PictureBox1
        End If
        If i = Char5.Text Then
            'MsgBox("Correct!")
            Char5.Visible = True
            Char5.Parent = PictureBox1
        End If
        For Each j As Object In Me.Controls
            If TypeOf j Is Button Then
                If j.text = i Then
                    j.foreColor = Color.Gray
                End If
            End If
        Next
        If Char2.Visible = True And Char3.Visible = True And Char4.Visible = True And Char5.Visible = True Then
            MsgBox(lines(1))
            Dim curStr As String = lines(0) + "," + lines(1) + "," + lines(2) + ",R0"
            Dim repStr As String = lines(0) + "," + lines(1) + "," + lines(2) + ",R1"
            My.Computer.FileSystem.WriteAllText(filepath, My.Computer.FileSystem.ReadAllText(filepath).Replace(curStr, repStr), False)
            Dim discCount As Integer = GetWordCountInFile(filepath, "R1")
            Label2.Text = discCount
            MainButton1.Visible = True
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = Me.dscount
    End Sub
    Private Sub MainButton1_Click(sender As Object, e As EventArgs) Handles MainButton1.Click
        baru()
        Me.Refresh()
    End Sub

    Private Sub Char5_Click(sender As Object, e As EventArgs) Handles Char5.Click

    End Sub

    Private Sub Char4_Click(sender As Object, e As EventArgs) Handles Char4.Click

    End Sub

    Private Sub Char3_Click(sender As Object, e As EventArgs) Handles Char3.Click

    End Sub

    Private Sub Char2_Click(sender As Object, e As EventArgs) Handles Char2.Click

    End Sub
End Class
