Public Class MenuStage
    Private Sub MenuStage_Load(sender As Object, e As EventArgs) Handles Me.Load
        For Each lbl As Control In Me.Controls
            If TypeOf lbl Is Label Then
                lbl.Parent = PictureBox1
                lbl.BackColor = Color.Transparent
                lbl.ForeColor = Color.White
                lbl.Font = New Font(lbl.Font, FontStyle.Bold)
            End If
        Next
    End Sub
End Class
