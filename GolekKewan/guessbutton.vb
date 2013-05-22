Public Class guessbutton
    Inherits Button
    Public Sub New()
        Me.Width = 48
        Me.Height = 48
    End Sub

    Private Sub guessbutton_Click(sender As Object, e As EventArgs) Handles Me.Click
        'Dim btn1 As String
        'btn1 = sender.text()
        'If btn1 = "g" Then
        '    MsgBox("you are wrong !")
        'End If
    End Sub
End Class
