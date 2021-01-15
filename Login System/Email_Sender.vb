Imports System.Net.Mail
Imports System
Imports System.IO
Imports System.Net
Imports System.Threading
Imports Login_System.Checker

Module Email_Sender


    Public Function emailSend(Code As String, des_email As String, task As Boolean)
        Try
            Dim Mail As New MailMessage
            Dim SMTP As New SmtpClient("smtp.gmail.com")


            Mail.From = New MailAddress("email")
            SMTP.Credentials = New NetworkCredential("email", "pass") '<-- Password Here

            Mail.To.Add(des_email)
            ServicePointManager.SecurityProtocol = 3072

            If task Then
                Mail.Subject = "Task code"
                Mail.Body = "Your Task Code Is : " & Code 'Message Here  
                SMTP.EnableSsl = True
                SMTP.Port = "587"
                SMTP.Send(Mail)
                ' MsgBox("Task No. Has Been Sent .")
                BotType("Task No. Has Been Sent Into Your Email" & vbCrLf & " Enter /Login user:pass:{TaskNo}")

            Else
                Mail.Subject = "Two Factor Code"
                Mail.Body = "Your twoFactor Code Is : " & Code 'Message Here
                SMTP.EnableSsl = True
                SMTP.Port = "587"
                SMTP.Send(Mail)

                ' MsgBox("twoFactor Code Has Been Sent .")
                BotType("twoFactor Code Has Been Sent Into Your Email" & vbCrLf & " Enter /2Fac {twoFactorCode}")
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function



End Module
