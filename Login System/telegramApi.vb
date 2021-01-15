Imports System
Imports System.Threading
Imports System.Net
Imports System.Web
Imports System.IO
Imports System.Text
Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports Login_System.Bot_Info
Module telegramApi

    Dim TOKEN = Bot_Info.TOKEN
    Dim user_id = Bot_Info.Chat_Id ' for send message
    Function getMessagesFromBot() As String

        Try
            ServicePointManager.SecurityProtocol = 3072
            Dim httpPost = DirectCast(WebRequest.Create("https://api.telegram.org/" & TOKEN & "/getupdates"), HttpWebRequest)
            httpPost.Method = "GET"
            httpPost.Proxy = Nothing
            Dim POST_Response As HttpWebResponse
            POST_Response = DirectCast(httpPost.GetResponse(), HttpWebResponse)
            Dim Post_Reader As New StreamReader(POST_Response.GetResponseStream())
            Dim Response As String = Post_Reader.ReadToEnd
            My.Settings.msgres = ""
            My.Settings.msgres = Response
            My.Settings.Save()

        Catch ex As Exception
            Return ex.Message
        End Try

    End Function



    Function BotType(text As String) As String

        Try
            ServicePointManager.SecurityProtocol = 3072
            Dim httpPost = DirectCast(WebRequest.Create("https://api.telegram.org/" & TOKEN & "/sendMessage?chat_id=" & user_id & "&text=" & text), HttpWebRequest) ' Send Message
            httpPost.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:74.0) Gecko/20100101 Firefox/74.0"
            httpPost.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8"
            httpPost.Proxy = Nothing
            httpPost.Method = "GET"
            Dim POST_Response As HttpWebResponse
            POST_Response = DirectCast(httpPost.GetResponse(), HttpWebResponse)
            Dim Post_Reader As New StreamReader(POST_Response.GetResponseStream())
            Dim Response As String = Post_Reader.ReadToEnd
            Return Response
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function



End Module
