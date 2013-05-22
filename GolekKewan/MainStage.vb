Public Class MainStage
    Dim pstatus = 0
    Dim dscount As Integer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If pstatus = 0 Then
            If Panel1.Left < 0 Then
                Panel1.Left += 10
                Panel2.Left += 10
            End If
        ElseIf pstatus = 1 Then
            If Panel2.Left > 0 Then
                Panel2.Left -= 10
                Panel1.Left -= 10
            End If
        ElseIf pstatus = 2 Then
            If Panel1.Top < 0 Then
                Panel1.Top += 10
                Panel3.Top += 10
            End If
        ElseIf pstatus = 3 Then
            If Panel3.Top > 0 Then
                Panel3.Top -= 10
                Panel1.Top -= 10
            End If
        Else
            Timer1.Enabled = False
        End If
    End Sub
    Private Sub MainButton1_Click_1(sender As Object, e As EventArgs) Handles MainButton1.Click
        pstatus = 1
        Timer1.Enabled = True
    End Sub
    Private Sub MainButton2_Click(sender As Object, e As EventArgs) Handles MainButton2.Click
        pstatus = 3
        Timer1.Enabled = True
        LogStage1.removeData()
        LogStage1.loadData()
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        pstatus = 2
        Timer1.Enabled = True
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pstatus = 0
        Timer1.Enabled = True
    End Sub
    Private Sub MainStage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer2.Enabled = True
        Label2.Text = GameStage3.dscount
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label2.Text = GameStage3.dscount
    End Sub
End Class

