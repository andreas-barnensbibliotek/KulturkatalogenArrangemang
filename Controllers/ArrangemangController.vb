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

    Private Function pagehandler(totposts As Integer) As Integer
        Dim ret As Double = 0

        ret = totposts / 12

        Return Math.Ceiling(ret)

    End Function

End Class
