Imports System.IO
Imports System.Net

Module Pastebin






    Dim url As String = "pastebin url" ' url get info


    Function GetEmail() As String
        Try
            Dim httpPost = DirectCast(WebRequest.Create(url), HttpWebRequest)
            httpPost.Method = "GET"
            httpPost.Proxy = Nothing
            Dim POST_Response As HttpWebResponse
            POST_Response = DirectCast(httpPost.GetResponse(), HttpWebResponse)
            Dim Post_Reader As New StreamReader(POST_Response.GetResponseStream())
            Dim Response As String = GetString(Post_Reader.ReadToEnd())
            'Dim emails As New List(Of String)
            'While Response IsNot Nothing
            '    Dim line As String = GetString(Response)
            '    emails.Add(line)
            '    Response = Post_Reader.ReadLine()
            'End While
            My.Settings.emails = ""
            My.Settings.emails = Response
            My.Settings.Save()
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function






End Module
