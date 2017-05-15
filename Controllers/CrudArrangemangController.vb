
Public Class CrudArrangemangController
    Private _dalobj As New arrangemangDAL

    Public Function addArrangemang(userid As Integer, arrData As arrangemangInfo) As arrangemangcontainerInfo

        Dim ret As New arrangemangcontainerInfo
        Try
            arrData.Arrid = _dalobj.addArrangemang(userid, arrData)
            If arrData.Arrid > 0 Then

                If arrData.Utovare <= 0 Then
                    Dim tmputovarid As Integer = _dalobj.addutovare(arrData.UtovareData)
                    _dalobj.updateArrUtovare(arrData.Arrid, tmputovarid)
                End If

                Dim contentid As Integer = _dalobj.addArrangemangContent(arrData)
                If contentid > 0 Then
                    If _dalobj.addContentToArr(arrData.Arrid, contentid) Then

                        If _dalobj.addFaktaToArrangemang(arrData) Then
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
        Try
            If _dalobj.DeleteArrToContentID(arrid) Then
                Return _dalobj.DeleteArrangemang(arrid)
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

End Class
