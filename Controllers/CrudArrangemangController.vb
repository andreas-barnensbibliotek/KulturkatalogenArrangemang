
Public Class CrudArrangemangController
    Private _dalobj As New arrangemangDAL


    Public Function addArrangemang(arrData As arrangemangInfo) As arrangemangcontainerInfo
        Dim tmparrlist As New List(Of arrangemangInfo)
        Dim nyttarr As New arrangemangInfo
        Dim ret As New arrangemangcontainerInfo
        Dim tmputovarid As Integer = 0
        Dim contentid As Integer = 0

        Try
            arrData.Arrid = _dalobj.addArrangemang(arrData)
            If arrData.Arrid > 0 Then
                If arrData.Utovare <= 0 Then
                    tmputovarid = _dalobj.addutovare(arrData.UtovareData)
                    _dalobj.updateArrUtovare(arrData.Arrid, tmputovarid)
                End If

                contentid = _dalobj.addArrangemangContent(arrData)
                If contentid > 0 Then
                    If _dalobj.addContentToArr(arrData.Arrid, contentid) Then
                        If _dalobj.addFaktaToArrangemang(arrData) Then
                            If _dalobj.addMediaToArrangemang(arrData) Then

                                'skicka tillbaka dom nya värdena så som arrid till anropande funktion
                                nyttarr.Arrid = arrData.Arrid
                                tmparrlist.Add(nyttarr)
                                ret.Arrangemanglist = tmparrlist
                                ret.Status = "OK! Arrangemanget Inlagt!"
                            Else
                                ret.Status = "Error fel vid inläggning av Media!"
                            End If
                        Else
                            ret.Status = "Error fel vid inläggning av fakta!"
                        End If
                    Else
                        ret.Status = "Error fel vid inläggning av Content till arrangemang!"
                    End If
                Else
                    ret.Status = "Error fel vid skapande av content!"
                End If
            Else
                ret.Status = "Error fel vid inläggning av arrangemang!"
            End If
        Catch ex As Exception
            ret.Status = "Error fel! Arrangemanget har inte lagts in!!"
        End Try

        Return ret

    End Function
    Public Function delarrangemang(arrid As Integer) As Boolean
        Dim ret As Boolean = False

        Try
            If _dalobj.DoArrangemangExist(arrid) Then
                If _dalobj.DeleteArrToContentID(arrid) Then
                    If _dalobj.DeleteFaktaByArrID(arrid) Then
                        If _dalobj.DeleteMediaByArrID(arrid) Then
                            ret = _dalobj.DeleteArrangemang(arrid)
                        End If
                    End If
                Else
                    ret = False
                End If
            End If

        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function


#Region "ADD funktioner"

    Public Function addMediaToArrangemang(arrid As Integer, mediaobj As mediaInfo) As Boolean
        Dim ret As Boolean = False
        Dim adddata As New arrangemangInfo

        Try
            adddata.Arrid = arrid
            adddata.MediaList.Add(mediaobj)
            ret = _dalobj.addMediaToArrangemang(adddata)
        Catch ex As Exception
            ret = False
        End Try

        Return ret

    End Function
    Public Function addFaktaToArrangemang(arrid As Integer, faktaobj As faktainfo) As Boolean
        Dim ret As Boolean = False
        Dim adddata As New arrangemangInfo

        Try
            adddata.Arrid = arrid
            adddata.Faktalist.Add(faktaobj)
            ret = _dalobj.addFaktaToArrangemang(adddata)
        Catch ex As Exception
            ret = False
        End Try

        Return ret

    End Function

#End Region

#Region "EDIT funktioner"

    Public Function editArrangemang(arrobj As arrangemangInfo) As Boolean
        If arrobj.Arrid > 0 Then
            Return _dalobj.EditArrangemangByArrID(arrobj)
        Else
            Return False
        End If

    End Function

    Public Function editcontent(arrobj As arrangemangInfo) As Boolean
        If arrobj.ContentID > 0 Then
            Return _dalobj.EditContentBycontentID(arrobj)
        Else
            Return False
        End If

    End Function

    Public Function editFaktabyfaktaid(fakta As faktainfo) As Boolean
        Dim retval As Boolean = False
        If fakta.Faktaid > 0 Then
            retval = _dalobj.EditFaktaByFaktaID(fakta)
        End If

        Return retval
    End Function
    Public Function editmediabymediaid(media As mediaInfo) As Boolean
        Dim retval As Boolean = False
        If media.MediaID > 0 Then
            retval = _dalobj.EditMediaByMediaID(media)
        End If

        Return retval
    End Function
#End Region

#Region "DELETE funktioner"

    Public Function delMediabyMediaid(mediaobj As mediaInfo) As Boolean
        Dim retval As Boolean = False
        If mediaobj.MediaID > 0 Then
            retval = _dalobj.DeleteMediaBymediaID(mediaobj.MediaID)
        End If

        Return retval

    End Function
    Public Function delFaktabyFaktaid(faktaobj As faktainfo) As Boolean
        Dim retval As Boolean = False
        If faktaobj.Faktaid > 0 Then
            retval = _dalobj.DeleteFaktaByFaktaID(faktaobj.Faktaid)
        End If

        Return retval

    End Function

#End Region
End Class
