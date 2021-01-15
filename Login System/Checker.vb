Imports System.Text.RegularExpressions
Imports System.Threading

Module Checker




    Function AuthCheck(res As String)
        Dim loginf As String = Form1.TextBox1.Text & ":" & Form1.TextBox2.Text
        Dim count As Integer = 1




        If res.Contains(loginf) Then
            Dim pattern As String = loginf & ":(.*)"
            My.Settings.des_email = ""
            My.Settings.des_email = Regex.Match(res, pattern).Groups(1).Value.Trim()
            My.Settings.Save()
            Return True

        Else


            Return False
        End If










    End Function





    Sub IfTaskSeen()

        Dim userp As String
        userp = Form1.TextBox1.Text + ":" + Form1.TextBox2.Text

        Dim tcFound As Boolean = False

        While tcFound = False


b:

            getMessagesFromBot()

            Thread.Sleep(3500)
            Dim Response As String
            Response = My.Settings.msgres

            Dim cond As String = """/Login " & userp & ":" & My.Settings.TaskCode & ""","

            If Response.Contains(cond) Then



                tcFound = True
                GeneCodes(False)

                emailSend(My.Settings.twoFacCode, My.Settings.des_email, False) ' Send 2Fac To Email
                  Form1.Button3.Text = "2Fac No. Sending!"

                Dim t As New Thread(
      Sub()
          Dim Failed As String = "</Login Failed>" & vbCrLf & "Username : " & Form1.TextBox1.Text & vbCrLf & "Public IP : " & Form1.ip1 & vbCrLf & "Country : " & Form1.country & vbCrLf & "Computer Name : " & System.Net.Dns.GetHostName() & vbCrLf & "</>"


          Dim count As Integer = 1
a:

          Dim codee As String = InputBox("Enter 2F Code Chance No. " & count & "/3", "2F Code")
          If codee = My.Settings.twoFacCode Then
              Dim t1 As New Thread(AddressOf IftwofacSeen)
              t1.Start()
          Else
              count += 1

              If count > 3 Then

                  BotType(Failed)
                  MsgBox("Login Failed")

                  End
              Else
                  GoTo a
              End If
          End If
      End Sub)
                t.Start()

                Exit Sub
            Else

                GoTo b
            End If

            Exit While
        End While

    End Sub

    Sub IftwofacSeen()
        Try
            Form1.Button3.Text = "2Fac No. Wait!"
            Dim Failed As String = "</Login Failed>" & vbCrLf & "Username : " & Form1.TextBox1.Text & vbCrLf & "Public IP : " & Form1.ip1 & vbCrLf & "Country : " & Form1.country & vbCrLf & "Computer Name : " & System.Net.Dns.GetHostName() & vbCrLf & "</>"




            getMessagesFromBot()



            Dim Response As String = My.Settings.msgres
            If Response.Contains("""text"":""/2Fac " + My.Settings.twoFacCode + "") Then

                MsgBox("Login Successfully")
            Else

                MsgBox("Login Failed")

                BotType(Failed)
                End
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub








End Module
