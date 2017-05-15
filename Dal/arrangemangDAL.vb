﻿

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


    Public Function updateLookedAt(cmdtyp As updatearrcommand) As Boolean
        Dim ret As Boolean = False

        Try
            Dim upd = From e In _linqObj.kk_aj_tbl_Arrangemangs
                      Where e.ArrID = cmdtyp.Arrid
                      Select e

            For Each itm In upd
                itm.LookedAt = cmdtyp.UpdValue
            Next

            _linqObj.SubmitChanges()
            ret = True
        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function

    ' uppdatera om arrangemanget är: ny, godkännd, nekad, arkiv
    Public Function updateArrStatus(cmdtyp As updatearrcommand) As Boolean
        Dim ret As Boolean = False

        Try
            Dim upd = From e In _linqObj.kk_aj_tbl_Arrangemangs
                      Where e.ArrID = cmdtyp.Arrid
                      Select e

            For Each itm In upd
                itm.ArrangemangStatusID = cmdtyp.UpdValue
            Next

            _linqObj.SubmitChanges()
            ret = True
        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function

    'publicera endast om arrangemanget är godkänt. ArrangemangStatusID = 2
    Public Function updateArrPublicerad(cmdtyp As updatearrcommand) As Boolean
        Dim ret As Boolean = False

        Try
            Dim upd = From e In _linqObj.kk_aj_tbl_Arrangemangs
                      Where e.ArrID = cmdtyp.Arrid
                      Select e

            For Each itm In upd

                If itm.ArrangemangStatusID = 2 Then
                    itm.Publicerad = cmdtyp.UpdValue
                    ret = True
                Else
                    itm.Publicerad = "nej"
                End If

            Next

            _linqObj.SubmitChanges()

        Catch ex As Exception
            ret = False
        End Try

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
            If t.RoleID = 6 Or t.RoleID = 0 Then
                ret = True
                Exit For
            End If
        Next

        Return ret

    End Function


#Region "CRUD"

    Public Function addArrangemang(userid As Integer, arrData As arrangemangInfo) As Integer

        Dim maindata As New kk_aj_tbl_Arrangemang

        maindata.ArrangemangstypID = arrData.Arrangemangtyp
        maindata.KonstformID = arrData.Konstform
        maindata.AdminuserID = userid
        maindata.ArrangemangStatusID = arrData.ArrangemangStatus
        maindata.Publicerad = arrData.Publicerad
        maindata.LookedAt = arrData.LookedAt
        maindata.UtovarID = arrData.Utovare
        maindata.VisningsPeriod = Date.Now.Year
        maindata.Datum = Date.Now

        _linqObj.kk_aj_tbl_Arrangemangs.InsertOnSubmit(maindata)
        _linqObj.SubmitChanges()
        Dim arrid As Integer = maindata.ArrID

        Return arrid

    End Function

    Public Function addArrangemangContent(contentdata As arrangemangInfo) As Integer
        Dim tmpcd As New kk_aj_tbl_content

        tmpcd.ContentText = contentdata.Innehall
        tmpcd.Rubrik = contentdata.Rubrik
        tmpcd.Underrubrik = contentdata.UnderRubrik
        tmpcd.ImageUrl = contentdata.MainImage.MediaUrl
        tmpcd.ImageFilename = contentdata.MainImage.MediaFilename
        tmpcd.ImageFotograf = contentdata.MainImage.MediaFoto
        tmpcd.ImageSize = contentdata.MainImage.MediaSize
        tmpcd.ImageAlt = contentdata.MainImage.MediaAlt
        tmpcd.MovieClipAlt = contentdata.MediaClip.MediaAlt
        tmpcd.MovieClipCredits = contentdata.MediaClip.MediaFoto
        tmpcd.MovieClipFilename = contentdata.MediaClip.MediaFilename
        tmpcd.MovieClipSize = contentdata.MediaClip.MediaSize
        tmpcd.MovieClipUrl = contentdata.MediaClip.MediaUrl
        tmpcd.datum = Date.Now
        _linqObj.kk_aj_tbl_contents.InsertOnSubmit(tmpcd)
        _linqObj.SubmitChanges()

        Return tmpcd.Contentid
    End Function

    Public Function addFaktaToArrangemang(data As arrangemangInfo) As Integer

        Try
            Dim inslst As New List(Of kk_aj_tbl_fakta)

            For Each itm In data.Faktalist
                Dim tmp As New kk_aj_tbl_fakta

                tmp.arrid = data.Arrid
                tmp.faktatypid = itm.FaktaTypID
                tmp.faktaValue = itm.FaktaValue
                inslst.Add(tmp)
            Next

            _linqObj.kk_aj_tbl_faktas.InsertAllOnSubmit(inslst)
            _linqObj.SubmitChanges()
            Return True

        Catch ex As Exception
            Return False

        End Try

    End Function


    Public Function addContentToArr(arrid As Integer, contentid As Integer) As Boolean
        Dim tmpobj As New kk_aj_tbl_arridtoContent
        Try
            tmpobj.arrid = arrid
            tmpobj.contentid = contentid
            tmpobj.Version = 1
            tmpobj.datum = Date.Now

            _linqObj.kk_aj_tbl_arridtoContents.InsertOnSubmit(tmpobj)
            _linqObj.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function addutovare(utovare As utovareInfo) As Integer
        Dim tmpobj As New kk_aj_tbl_Utovare

        Try
            tmpobj.Organisation = utovare.Organisation
            tmpobj.Fornamn = utovare.Fornamn
            tmpobj.Efternamn = utovare.Efternamn
            tmpobj.Telefonnummer = utovare.Telefon
            tmpobj.Adress = utovare.Adress
            tmpobj.Postnr = utovare.Postnr
            tmpobj.Ort = utovare.Ort
            tmpobj.Epost = utovare.Epost
            tmpobj.Kommun = utovare.Kommun
            tmpobj.Hemsida = utovare.Weburl

            _linqObj.kk_aj_tbl_Utovares.InsertOnSubmit(tmpobj)
            _linqObj.SubmitChanges()
            Return tmpobj.UtovarID
        Catch ex As Exception
            Return 0
        End Try

    End Function

    Public Function updateArrUtovare(arrid As Integer, utovarid As Integer) As Boolean
        Dim ret As Boolean = False

        Try
            Dim upd = From e In _linqObj.kk_aj_tbl_Arrangemangs
                      Where e.ArrID = arrid
                      Select e

            For Each itm In upd
                itm.UtovarID = utovarid
            Next

            _linqObj.SubmitChanges()

        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function

#End Region

#Region "DELETE Arrangemang"
    Public Function DeleteArrangemang(arrid As Integer) As Boolean
        Dim deleted As Boolean = False
        Try
            Dim itm = From c In _linqObj.kk_aj_tbl_Arrangemangs
                      Where c.ArrID = arrid
                      Select c

            For Each i In itm
                _linqObj.kk_aj_tbl_Arrangemangs.DeleteOnSubmit(i)
            Next

            _linqObj.SubmitChanges()
            deleted = True
        Catch ex As Exception
            deleted = False
        End Try

        Return deleted
    End Function


    Public Function DeleteArrToContentID(arrid As Integer) As Boolean
        Try
            Dim itm = From c In _linqObj.kk_aj_tbl_arridtoContents
                      Where c.arrid = arrid
                      Select c

            For Each i In itm
                If delContentById(i.contentid) Then
                    _linqObj.kk_aj_tbl_arridtoContents.DeleteOnSubmit(i)
                    _linqObj.SubmitChanges()
                End If
            Next

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function delContentById(contentid As Integer) As Boolean
        Try
            Dim itm = From c In _linqObj.kk_aj_tbl_contents
                      Where c.Contentid = contentid
                      Select c

            For Each i In itm
                _linqObj.kk_aj_tbl_contents.DeleteOnSubmit(i)
            Next

            _linqObj.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

End Class
