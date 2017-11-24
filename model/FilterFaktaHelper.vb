Public Class FilterFaktaHelper

    Public Function getmorklaggning(convertdata As String) As String
        Dim ret As String

        Select Case LCase(convertdata)
            Case "ingen"
                ret = "1"
            Case "nej"
                ret = "1"
            Case "ja helst"
                ret = "2"
            Case "ja nödvändigt"
                ret = "3"
            Case Else
                ret = "0"
        End Select

        Return ret

    End Function

    Public Function gettakhojd(convertdata As String) As String
        Dim ret As String = 0
        Try
            Dim th As Integer = CInt(convertdata)

            If th <= 2 Then
                ret = "2"
            End If
            If th > 2 And th <= 3 Then
                ret = "3"
            End If

            If th > 3 And th <= 4 Then
                ret = "4"
            End If

            If th > 4 And th <= 5 Then
                ret = "5"
            End If

            If th > 5 Then
                ret = "6"
            End If
        Catch ex As Exception
            ret = 0
        End Try


        Return ret

    End Function

    Public Function getbokningsbar(convertdate As String) As String
        Dim th As Integer = 0
        Try
            Dim premiardate As Date = Date.ParseExact(convertdate, "yyyy-MM-dd",
                       System.Globalization.DateTimeFormatInfo.InvariantInfo)

            th = Math.Ceiling(premiardate.Month / 3)
        Catch ex As Exception 'värdet var inte ett datum
            th = 0
        End Try

        Return th.ToString

    End Function
End Class
