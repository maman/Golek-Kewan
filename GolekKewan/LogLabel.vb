Public Class LogLabel
    Inherits Label
    Public Sub New()
        Me.Font = New Font(Me.Font, FontStyle.Bold)
        Me.Text = 0 & "Items"
    End Sub
End Class
