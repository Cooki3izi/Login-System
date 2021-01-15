Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Threading

Public Class Form1
    Public ip1 As String
    Public country As String
    Dim i As Boolean
    Dim y As Integer
    Private Property x As Integer
    Sub ip()
        Try
            Dim r As New WebClient
            r.Proxy = Nothing
            Dim response = r.DownloadString("http://ip-api.com/json/")
            Dim ip As Match = Regex.Match(response, """query"":""(.*?)""")
            Dim c As Match = Regex.Match(response, """country"":""(.*?)""")
            ip1 = ip.Groups(1).Value
            country = c.Groups(1).Value
            TextBox3.Text = ip.Groups(1).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Dim count As Integer = 1
    

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim emailth As New Thread(AddressOf GetEmail)
        emailth.Start()
        Thread.Sleep(3000)
        Dim a As String = My.Settings.emails
        Dim logged As Boolean = False



        If count > 3 Then
            End
        Else

            logged = AuthCheck(a)



            If logged Then
                Button3.Enabled = False
                GeneCodes(True)
                Button3.Text = "Task No. Sending!"

                emailSend(My.Settings.TaskCode, My.Settings.des_email, True)

                Thread.Sleep(2000)

                Button3.Text = "Task No. Wait!"

                IfTaskSeen()
            Else

                MsgBox("Auth Failed Chance " & count & "/3")
                count += 1

            End If

        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Starter()
        ip()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
    'design code
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        End
    End Sub


    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If (e.Button = MouseButtons.Left) Then
            Me.i = True
            Dim x As Integer = Control.MousePosition.X
            Dim location As Point = MyBase.Location
            Me.x = x - location.X
            Dim y As Integer = Control.MousePosition.Y
            location = MyBase.Location
            Me.y = y - location.Y
        End If
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If (Me.i) Then
            Dim mousePosition As System.Drawing.Point = Control.MousePosition
            Dim x As Integer = mousePosition.X - Me.x
            mousePosition = Control.MousePosition
            Dim point As System.Drawing.Point = New System.Drawing.Point(x, mousePosition.Y - Me.y)
            MyBase.Location = point
        End If
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        Me.i = False
    End Sub

    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
        If (e.Button = MouseButtons.Left) Then
            Me.i = True
            Dim x As Integer = Control.MousePosition.X
            Dim location As Point = MyBase.Location
            Me.x = x - location.X
            Dim y As Integer = Control.MousePosition.Y
            location = MyBase.Location
            Me.y = y - location.Y
        End If
    End Sub

    Private Sub Label1_MouseMove(sender As Object, e As MouseEventArgs) Handles Label1.MouseMove
        If (Me.i) Then
            Dim mousePosition As System.Drawing.Point = Control.MousePosition
            Dim x As Integer = mousePosition.X - Me.x
            mousePosition = Control.MousePosition
            Dim point As System.Drawing.Point = New System.Drawing.Point(x, mousePosition.Y - Me.y)
            MyBase.Location = point
        End If
    End Sub

    Private Sub Label1_MouseUp(sender As Object, e As MouseEventArgs) Handles Label1.MouseUp
        Me.i = False
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        MsgBox("Instagram : @0xCookieizi , @_IRizerX_", MsgBoxStyle.OkOnly, "Login System")
    End Sub
End Class
