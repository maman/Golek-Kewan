Public Class LogStage
    Dim lines() As String
    Dim filepath As String = "base.txt"
    Private Sub LogStage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Parent = PictureBox1
        Label1.BackColor = Color.Transparent
        DataGridView1.Columns.Add("a", "Name")
        DataGridView1.Columns.Add("b", "Definition")
        loadData()
    End Sub
    Public Sub removeData()
        DataGridView1.Rows.Clear()
    End Sub
    Public Sub loadData()
        Dim linecount = IO.File.ReadAllLines(filepath).Length
        For x As Integer = 0 To linecount - 1
            Dim line = System.IO.File.ReadAllLines(filepath)(x)
            lines = line.Split(",")
            If lines(3) = "R1" Then
                DataGridView1.Rows.Add(lines(0), lines(1))
            End If
        Next
    End Sub
    Public Sub resetData()
        Dim linecount = IO.File.ReadAllLines(filepath).Length
        For x As Integer = 0 To linecount - 1
            Dim line = System.IO.File.ReadAllLines(filepath)(x)
            lines = line.Split(",")
            Dim curStr As String = lines(0) + "," + lines(1) + "," + lines(2) + ",R1"
            Dim repStr As String = lines(0) + "," + lines(1) + "," + lines(2) + ",R0"
            My.Computer.FileSystem.WriteAllText(filepath, My.Computer.FileSystem.ReadAllText(filepath).Replace(curStr, repStr), False)
        Next
    End Sub
    Private Function GetWordCountInFile(ByVal filepath As String, ByVal word As String)
        Return System.Text.RegularExpressions.Regex.Matches(IO.File.ReadAllText(filepath), "(?i)\b(\s+)?" & word & "(\s+|\S{0})\b|^" & word & "\.?$|" & word & "[\.\,\;]").Count
    End Function
    Private Sub MainButton1_Click(sender As Object, e As EventArgs) Handles MainButton1.Click
        resetData()
        loadData()
        Me.Refresh()
    End Sub
End Class
