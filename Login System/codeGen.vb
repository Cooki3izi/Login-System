Imports System.Text
Module codeGen


    Function GeneCodes(task As Boolean)
        If task Then
            Dim s As String = "0123456789"
            Dim r As New Random
            Dim code As New StringBuilder
            For i As Integer = 1 To 6
                Dim idx As Integer = r.Next(0, 9)
                code.Append(s.Substring(idx, 1))
            Next
            My.Settings.TaskCode = ""
            My.Settings.TaskCode = code.ToString()
            My.Settings.Save()
        Else
            Dim s As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            Dim r As New Random
            Dim code As New StringBuilder
            For i As Integer = 1 To 5
                Dim idx As Integer = r.Next(0, 9)
                code.Append(s.Substring(idx, 1))
            Next

            My.Settings.twoFacCode = ""
            My.Settings.twoFacCode = code.ToString()
            My.Settings.Save()
        End If

    End Function


End Module
