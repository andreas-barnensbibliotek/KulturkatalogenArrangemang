
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

                            'skicka tillbaka dom nya värdena så som arrid till anropande funktion
                            nyttarr.Arrid = arrData.Arrid
                            tmparrlist.Add(nyttarr)
                            ret.Arrangemanglist = tmparrlist
                            ret.Status = "OK! Arrangemanget Inlagt!"
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
                    ret = _dalobj.DeleteArrangemang(arrid)
                Else
                    ret = False
                End If
            End If

        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function

End Class
