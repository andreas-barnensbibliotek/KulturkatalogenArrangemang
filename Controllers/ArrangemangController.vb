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
        Dim tmpCmdtyp As commandTypeInfo = cmdtyp
        Try
            retobj.Arrangemanglist = _dalobj.getArrangemangByStatus(cmdtyp)
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
            retobj.Status = "Arrangemangen är listade!"
            Return retobj
        Catch ex As Exception
            retobj.Status = "Fel när Arrangemangen listades!"
            Return retobj
        End Try
    End Function

    Public Function getArrbySearch(cmdtyp As commandTypeInfo) As arrangemangcontainerInfo
        Dim retobj As New arrangemangcontainerInfo
        Dim tmpCmdtyp As commandTypeInfo = cmdtyp
        Try
            retobj.Arrangemanglist = _dalobj.getArrangemangBySearch(cmdtyp)
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
            retobj.Status = "Arrangemangen är listade!"
            Return retobj
        Catch ex As Exception
            retobj.Status = "Fel när Arrangemangen listades!"
            Return retobj
        End Try
    End Function

    Public Function getArrangemangDetails(cmdtyp As commandTypeInfo) As arrangemangcontainerInfo



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
