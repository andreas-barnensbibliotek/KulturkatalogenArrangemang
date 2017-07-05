Imports KulturkatalogenArrangemang

Public Class ArrangemangController

    Private _dalobj As New arrangemangDAL
    Public Function getArrlist(cmdtyp As commandTypeInfo) As arrangemangcontainerInfo
        Dim retobj As New arrangemangcontainerInfo
        Try
            Dim rollobj As New userHandler
            cmdtyp = rollobj.adUserRollToCmdtyp(cmdtyp)

            Select Case cmdtyp.CmdTyp
                Case "bystatus"
                    retobj = getArrbyStatus(cmdtyp)

                Case "bysearch"
                    retobj = getArrbySearch(cmdtyp)

                Case "bylatest"
                    retobj = getArrbyLatest(cmdtyp)

                Case "details"
                    retobj = getArrangemangDetails(cmdtyp)
            End Select

            Return retobj
        Catch ex As Exception
            retobj.Status = "Fel när Arrangemangen listades! Error in: " & cmdtyp.CmdTyp
            Return retobj
        End Try
    End Function


    Public Function updateArrStatusType(cmdtyp As updatearrcommand) As arrangemangcontainerInfo
        Dim retobj As New arrangemangcontainerInfo

        If checkcmdtypvalues(cmdtyp) Then
            Try
                Select Case cmdtyp.CmdTyp
                    Case "lookedat"
                        If _dalobj.updateLookedAt(cmdtyp) Then
                            retobj.Status = "lookedAt uppdated to: " & cmdtyp.UpdValue
                        Else
                            retobj.Status = "Fel vid uppdatering av lookedat!"
                        End If
                    Case "arrstat"
                        If _dalobj.updateArrStatus(cmdtyp) Then
                            retobj.Status = "ArrStatus uppdated to: " & cmdtyp.UpdValue
                        Else
                            retobj.Status = "Fel vid uppdatering av ArrStatus!"
                        End If
                    Case "pub"
                        If _dalobj.updateArrPublicerad(cmdtyp) Then
                            retobj.Status = "Publicerad uppdated to arrid: " & cmdtyp.UpdValue
                        Else
                            retobj.Status = "Fel vid uppdatering av Publicerad!"
                        End If
                    Case Else
                        retobj.Status = "Fel vid uppdatering. command saknas!"
                End Select

            Catch ex As Exception
                retobj.Status = "Fel när Arrangemangen listades! Error in: " & cmdtyp.CmdTyp

            End Try
        Else
            retobj.Status = "Fel när Arrangemangen listades! Error in paramrange: " & cmdtyp.CmdTyp

        End If
        Return retobj
    End Function



    Private Function getArrbyStatus(cmdtyp As commandTypeInfo) As arrangemangcontainerInfo
        Dim retobj As New arrangemangcontainerInfo
        Dim arrList As New List(Of arrangemangInfo)

        Try
            arrList = _dalobj.getArrangemangByStatus(cmdtyp)
            retobj = getBaseArrangemangData(cmdtyp, arrList)

            Return retobj
        Catch ex As Exception
            retobj.Status = "Fel när Arrangemangen listades!"

            Return retobj
        End Try

    End Function

    Public Function getArrbySearch(cmdtyp As commandTypeInfo) As arrangemangcontainerInfo
        Dim retobj As New arrangemangcontainerInfo
        Dim arrList As New List(Of arrangemangInfo)

        Try
            arrList = _dalobj.getArrangemangBySearch(cmdtyp)
            retobj = getBaseArrangemangData(cmdtyp, arrList)

            Return retobj
        Catch ex As Exception
            retobj.Status = "Fel när Arrangemangen listades!"

            Return retobj
        End Try

    End Function

    Public Function getArrangemangDetails(cmdtyp As commandTypeInfo) As arrangemangcontainerInfo
        Dim retobj As New arrangemangcontainerInfo
        Dim retarrlist As New List(Of arrangemangInfo)
        Dim arritm As New arrangemangInfo
        Dim rollobj As New userHandler

        Try
            arritm = _dalobj.getArrangemangDetails(cmdtyp)
            retarrlist.Add(arritm)

            retobj = getBaseArrangemangData(cmdtyp, retarrlist)

            Return retobj
        Catch ex As Exception
            retobj.Status = "Fel när Arrangemangdetaljen skulle hämtas!"

            Return retobj
        End Try

    End Function

    Public Function getArrbyLatest(cmdtyp As commandTypeInfo) As arrangemangcontainerInfo
        Dim retobj As New arrangemangcontainerInfo
        Dim arrList As New List(Of arrangemangInfo)
        Dim antalToGet As Integer = 0

        Select Case cmdtyp.cmdValue
            Case "top5"
                antalToGet = 5
            Case "top10"
                antalToGet = 10
            Case "top30"
                antalToGet = 30
            Case "top50"
                antalToGet = 50
            Case Else
                antalToGet = 100
        End Select

        Try
            arrList = _dalobj.getArrangemangByLatest(cmdtyp, antalToGet)
            retobj = getBaseArrangemangData(cmdtyp, arrList)
            retobj.ArrStatus = "Latest"
            Return retobj
        Catch ex As Exception
            retobj.Status = "Fel när dom sena Arrangemangen listades!"

            Return retobj
        End Try

    End Function
    Private Function getBaseArrangemangData(cmdtyp As commandTypeInfo, arrList As List(Of arrangemangInfo)) As arrangemangcontainerInfo
        Dim retobj As New arrangemangcontainerInfo
        Dim tmpCmdtyp As commandTypeInfo = cmdtyp
        Try
            retobj.Arrangemanglist = arrList
            retobj.ArrangemanglistCount = retobj.Arrangemanglist.Count

            tmpCmdtyp.ArrStatusTyp = 1
            retobj.NyaArrangemangCount = _dalobj.getantalposter(tmpCmdtyp)
            tmpCmdtyp.ArrStatusTyp = 2
            retobj.ApprovedarrangemangCount = _dalobj.getantalposter(tmpCmdtyp)
            tmpCmdtyp.ArrStatusTyp = 3
            retobj.DeniedarrangemangCount = _dalobj.getantalposter(tmpCmdtyp)
            retobj.ArrangemangCurrentPage = 0
            retobj.ArrangemangTotalPages = pagehandler(retobj.ArrangemanglistCount)
            retobj.ArrStatus = retobj.Arrangemanglist(0).ArrangemangStatus

            Select Case cmdtyp.CmdTyp
                Case "details"
                    retobj.Status = "Arrangemangsdetaljer är listade!"
                Case Else
                    retobj.Status = "Arrangemangen är listade!"
            End Select

            Return retobj
        Catch ex As Exception
            retobj.Status = "Fel när Arrangemangen listades!"
            Return retobj
        End Try

    End Function




#Region "Privata funktioner"
    Private Function pagehandler(totposts As Integer) As Integer
        Dim ret As Double = 0

        ret = totposts / 10

        Return Math.Ceiling(ret)

    End Function
    Private Function checkcmdtypvalues(cmdtyp As updatearrcommand) As Boolean
        Dim ret As Boolean = False
        Select Case cmdtyp.CmdTyp
            Case "lookedat"
                If cmdtyp.UpdValue = "ja" Or cmdtyp.UpdValue = "nej" Then
                    ret = True
                End If
            Case "arrstat"
                If IsNumeric(cmdtyp.UpdValue) Then
                    If cmdtyp.UpdValue >= 1 And cmdtyp.UpdValue <= 4 Then
                        ret = True
                    End If
                End If

            Case "pub"
                If cmdtyp.UpdValue = "ja" Or cmdtyp.UpdValue = "nej" Then
                    ret = True
                End If
        End Select

        Return ret

    End Function
#End Region

End Class
