Imports System.Net
Imports System.IO
Imports System.Text
Module Encrypt
    Public Datas As New RichTextBox With {.Text = Nothing}
    Dim Letters As String() = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}
    Dim IrLetters As String() = {"DFH%#@JLNPRTVXZ", "CEGI3%#LMOQSUWY", "BFHJLNPR(*&%TVXZ", "AEGILMO!@#QSUWY", "BDHJLNP!@#%RTVXZ",
            "ACGILMOQSU^%@#WY", "BDFJLNP(**&RTVXZ", "ACE%$^O(&()QSUWY", "BDFHLNPR&*TVXZ", "ACEGLM%$*%OQSUWY", "BDFHJNPR^&*(TVXZ", "ACEGIM(&%$#OQSUWY",
            "BDGHJLPRT@#%$$@VXZ", "ACEGIKOQS!@@#%%UWY", "BDFHJL@#$%NRTVXZ", "ACE^$#$%GIKMQSUWY", "BDFH@#%JLNPTVXZ", "ACEG$^%#ILMOSUWY", "BDFHJLNPRVXZ",
            "ACEGILMO@#$%%QUWY", "BDFHJLN@%#%$PRTXZ", "ACEGILM@#$%^%OQSWY", "BDFHJ@#$%LNPRTVZ", "ACEGILMO%#$@!QSUY", "BDFHJLNPRTVX", "A@$%^CEGILMOQSUW"}
    Dim LLetters(25) As String
    Dim LIrLetters(25) As String
    Dim Numbers As String() = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
    Dim IrNumbers As String() = {"Ab", "Cd", "Ef", "Gh", "Ij", "Kl", "Mn", "Op", "Qr", "St"}
    Dim NewLine As String = vbNewLine
    Dim NewLines As String = "$####@"
    Dim Space As String = " "
    Dim Spaces As String = "@###$"
    Sub Starter()
        If LLetters(0) = Nothing Then
            For i As Integer = 0 To Letters.Length - 1
                LLetters(i) = Letters(i).ToUpper
            Next
        End If
        If LIrLetters(0) = Nothing Then
            For i As Integer = 0 To IrLetters.Length - 1
                LIrLetters(i) = IrLetters(i).ToLower
            Next
        End If
    End Sub


    Public Function GetData(link As String) As String
        Try
            Dim req As HttpWebRequest = WebRequest.Create(link)
            req.Proxy = Nothing
            req.UseDefaultCredentials = True
            Dim res As HttpWebResponse = req.GetResponse()
            Dim re As String = New StreamReader(res.GetResponseStream).ReadToEnd()
            Return re
        Catch ex As Exception
            Return "Connection error, Be sure your serial is actived or not wrong!"
        End Try
    End Function
    Function GetNumber(Data As String, AllData As String()) As Integer
        Try
            For i As Integer = 0 To AllData.Length - 1
                If Data = AllData(i) Then
                    Return i
                End If
            Next
        Catch ex As Exception
            Return 500000000
        End Try
    End Function
    Dim NNN As Integer
    Public Function GetString(Data As String) As String
        '  Try
        For i As Integer = 0 To IrLetters.Length - 1
            If Data.Contains(IrLetters(i)) Then
                Data = Data.Replace(IrLetters(i), Letters(i))
            End If
        Next
        For i As Integer = 0 To LIrLetters.Length - 1
            If Data.Contains(LIrLetters(i)) Then
                Data = Data.Replace(LIrLetters(i), LLetters(i))
            End If
        Next
        For i As Integer = 0 To IrNumbers.Length - 1
            If Data.Contains(IrNumbers(i)) Then
                Data = Data.Replace(IrNumbers(i), Numbers(i))
            End If
        Next
        If Data.Contains(NewLines) Then
            Data = Data.Replace(NewLines, NewLine)
        End If
        If Data.Contains(Spaces) Then
            Data = Data.Replace(Spaces, Space)
        End If

        Return Data
    End Function
    Public Function GetIrString(Data As String) As String
        Try

            For i As Integer = 0 To Data.Length - 1
                If Letters.Contains(Data(i)) Then
                    NNN = GetNumber(Data(i), Letters)
                    If Not NNN = 500000000 Then
                        Datas.AppendText(IrLetters(NNN))
                    End If
                ElseIf LLetters.Contains(Data(i)) Then
                    NNN = GetNumber(Data(i), LLetters)
                    If Not NNN = 500000000 Then
                        Datas.AppendText(LIrLetters(NNN))
                    End If
                ElseIf Numbers.Contains(Data(i)) Then
                    NNN = GetNumber(Data(i), Numbers)
                    If Not NNN = 500000000 Then
                        Datas.AppendText(IrNumbers(NNN))
                    End If
                ElseIf Space = Data(i) Then
                    Datas.AppendText(Spaces)
                ElseIf NewLine = Data(i) Then
                    Datas.AppendText(NewLines)
                Else
                    Datas.AppendText(Data(i))
                End If
            Next
            Data = Datas.Text
            Datas.Text = Nothing
            Return Data
        Catch ex As Exception
            Return "Error"
        End Try
    End Function
End Module
