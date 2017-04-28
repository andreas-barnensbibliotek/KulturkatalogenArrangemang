

Public Class arrangemangDAL
    Private _connectionString As String = "Data Source=.\SQLEXPRESS;Initial Catalog=dnndev_v902.me;Persist Security Info=True;User ID=dnndev_v902.me;Password=L0rda1f"
    'Private _connectionString As String = "Data Source=DE-1896;Initial Catalog=kulturkatalogenDB;User ID=kulturkatalogenDB;Password=L0rda1f"
    Private _linqObj As New kk_aj_ArrangemangLinqDataContext(_connectionString)

    Public Function getArrangemangByStatus(cmdtyp As commandTypeInfo) As List(Of arrangemangInfo)


        Dim tmpobj As New List(Of arrangemangInfo)

        Dim arr = From p In _linqObj.kk_aj_proc_GetArrby_ArrStatus(cmdtyp.ArrStatusTyp, cmdtyp.IsAdminRoll, cmdtyp.CmdRoll1, cmdtyp.CmdRoll2, cmdtyp.CmdRoll3, cmdtyp.CmdRoll4, cmdtyp.CmdRoll5, cmdtyp.CmdRoll6, cmdtyp.CmdRoll7, cmdtyp.CmdRoll8, cmdtyp.CmdRoll9, cmdtyp.CmdRoll10, cmdtyp.Visningsperiod)
                  Select p

        For Each t In arr
            Dim nobj As New arrangemangInfo
            nobj.Arrid = t.ArrID
            nobj.ArrangemangStatus = t.ArrangemangStatus
            nobj.Arrangemangtyp = t.arrangemangtyp
            nobj.Datum = t.Datum.ToString
            nobj.Rubrik = t.Rubrik
            nobj.UnderRubrik = t.UnderRubrik
            nobj.LookedAt = t.LookedAt
            nobj.Konstform = t.konstform
            nobj.Publicerad = t.Publicerad
            nobj.Utovare = t.Organisation
            nobj.Username = t.Username

            tmpobj.Add(nobj)
        Next

        If tmpobj.Count <= 0 Then
            Dim noresult As New arrangemangInfo
            noresult.Rubrik = "Finns inget att visa"
            tmpobj.Add(noresult)
        End If

        Return tmpobj

    End Function


    Public Function getArrangemangBySearch(cmdtyp As commandTypeInfo) As List(Of arrangemangInfo)

        Dim tmpobj As New List(Of arrangemangInfo)

        Dim arr = From p In _linqObj.kk_aj_proc_GetArrby_Search(cmdtyp.cmdValue, cmdtyp.ArrStatusTyp, cmdtyp.IsAdminRoll, cmdtyp.CmdRoll1, cmdtyp.CmdRoll2, cmdtyp.CmdRoll3, cmdtyp.CmdRoll4, cmdtyp.CmdRoll5, cmdtyp.CmdRoll6, cmdtyp.CmdRoll7, cmdtyp.CmdRoll8, cmdtyp.CmdRoll9, cmdtyp.CmdRoll10, cmdtyp.Visningsperiod)
                  Select p


        For Each t In arr
            Dim nobj As New arrangemangInfo
            nobj.Arrid = t.ArrID
            nobj.ArrangemangStatus = t.ArrangemangStatus
            nobj.Arrangemangtyp = t.arrangemangtyp
            nobj.Datum = t.Datum.ToString
            nobj.Rubrik = t.Rubrik
            nobj.UnderRubrik = t.UnderRubrik
            nobj.LookedAt = t.LookedAt
            nobj.Konstform = t.konstform
            nobj.Publicerad = t.Publicerad
            nobj.Utovare = t.Organisation
            nobj.Username = t.Username

            tmpobj.Add(nobj)
        Next

        If tmpobj.Count <= 0 Then
            Dim noresult As New arrangemangInfo
            noresult.ArrangemangStatus = getStatustyp(cmdtyp.ArrStatusTyp)
            noresult.Rubrik = "Finns inget att visa"
            tmpobj.Add(noresult)
        End If

        Return tmpobj

    End Function


    Public Function getantalposter(cmdtyp As commandTypeInfo) As Integer
        Dim ret As Integer = 0
        Dim arrCount = From p In _linqObj.kk_aj_proc_getStatusCount(cmdtyp.ArrStatusTyp, cmdtyp.IsAdminRoll, cmdtyp.CmdRoll1, cmdtyp.CmdRoll2, cmdtyp.CmdRoll3, cmdtyp.CmdRoll4, cmdtyp.CmdRoll5, cmdtyp.CmdRoll6, cmdtyp.CmdRoll7, cmdtyp.CmdRoll8, cmdtyp.CmdRoll9, cmdtyp.CmdRoll10, cmdtyp.Visningsperiod)
                       Select p
        For Each t In arrCount
            ret = t.antal
        Next

        Return ret

    End Function

    Private Function getkonstformtyp(konstformid As Integer) As String
        Dim tmpobj As String = ""

        Dim logs = From t In _linqObj.kk_aj_tbl_faktatyps
                   Where t.faktatypid = konstformid
                   Select t

        For Each t In logs
            tmpobj = t.Faktarubrik
        Next

        Return tmpobj

    End Function

    ' Arrangemangstyp är ex: resmål, Föreställning på tuné, Fortbildningar, Museilådor
    Private Function getarrangemangtyp(arrtypid As Integer) As String
        Dim tmpobj As String = ""

        Dim logs = From t In _linqObj.kk_aj_tbl_Arrangemangtyps
                   Where t.ArrangemangstypID = arrtypid
                   Select t

        For Each t In logs
            tmpobj = t.arrangemangtyp
        Next

        Return tmpobj

    End Function

    ' ArrangemangsSTATUStyp är: ny= 1, godkänd=2, nekad=3, arkiv=4
    Private Function getStatustyp(arrStatustypid As Integer) As String
        Dim tmpobj As String = ""

        Dim logs = From t In _linqObj.kk_aj_tbl_ArrangemangStatus
                   Where t.ArrangemangStatusID = arrStatustypid
                   Select t

        For Each t In logs
            tmpobj = t.ArrangemangStatus
        Next

        Return tmpobj

    End Function


    Public Function getuserRolToKonstFormMapper(userid As Integer) As List(Of Integer)
        Dim KonstformIDs As New List(Of Integer)

        Dim logs = From p In _linqObj.kk_aj_proc_MapRollToKonstform(userid)
                   Select p

        For Each t In logs
            KonstformIDs.Add(t.KonstformID)
        Next

        Return KonstformIDs
    End Function
    Public Function isUserAdmin(userid As Integer) As Boolean
        Dim ret As Boolean = False
        Dim logs = From t In _linqObj.UserRoles
                   Where t.UserID = userid
                   Select t
        For Each t In logs
            If t.RoleID = 6 Then
                ret = True
                Exit For
            End If
        Next

        Return ret

    End Function
End Class
