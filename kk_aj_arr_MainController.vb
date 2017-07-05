Public Class kk_aj_arr_MainController

    Public Function getArrangemang(cmdtyp As commandTypeInfo) As arrangemangcontainerInfo
        Dim retobj As New arrangemangcontainerInfo
        Dim obj As New ArrangemangController

        retobj = obj.getArrlist(cmdtyp)

        Return retobj

    End Function

    Public Function updateArrPropeties(cmdtyp As updatearrcommand) As arrangemangcontainerInfo
        Dim retobj As New arrangemangcontainerInfo
        Dim obj As New ArrangemangController
        retobj = obj.updateArrStatusType(cmdtyp)

        Return retobj
    End Function

    Public Function addArrangemang(cmdtyp As updatearrcommand, arrData As arrangemangInfo) As arrangemangcontainerInfo
        Dim retobj As New arrangemangcontainerInfo
        Dim obj As New CrudArrangemangController

        arrData.ArrangemangStatus = 1 'Nytt"
        arrData.Datum = Date.Now
        retobj = obj.addArrangemang(arrData)

        Return retobj
    End Function

    Public Function DelArrangemang(cmdtyp As updatearrcommand) As arrangemangcontainerInfo
        Dim retobj As New arrangemangcontainerInfo
        Dim obj As New CrudArrangemangController

        If obj.delarrangemang(cmdtyp.Arrid) Then
            retobj.Status = "Arrid: " & cmdtyp.Arrid & " är nu borttaget!!"
        Else
            retobj.Status = "Error! Fel vid borttagning av Arrid: " & cmdtyp.Arrid
        End If
        Return retobj

    End Function

#Region "ADD functions"

    Public Function addmediaToArrangemang(arrid As Integer, mediaobj As mediaInfo) As arrangemangcontainerInfo
        Dim obj As New CrudArrangemangController
        Dim retstatus As String = ""

        If obj.addMediaToArrangemang(arrid, mediaobj) Then
            retstatus = "OK! Mediaid: " & mediaobj.MediaID & " till arrangemang Arrid: " & arrid & " är Inlagt"
        Else
            retstatus = "ERROR! Något gick fel när Mediaid: " & mediaobj.MediaID & "  till arrangemang Arrid: " & arrid & " skulle läggas till"
        End If

        Return getArrangemanHelper(arrid, retstatus)

    End Function

    Public Function addFaktaToArrangemang(arrid As Integer, faktaobj As faktainfo) As arrangemangcontainerInfo
        Dim obj As New CrudArrangemangController
        Dim retstatus As String = ""

        If obj.addFaktaToArrangemang(arrid, faktaobj) Then
            retstatus = "OK! Faktaid: " & faktaobj.Faktaid & " till arrangemang Arrid: " & arrid & " är Inlagt!"
        Else
            retstatus = "ERROR! Något gick fel när Faktaid: " & faktaobj.Faktaid & " till arrangemang Arrid: " & arrid & " skulle läggas till"
        End If

        Return getArrangemanHelper(arrid, retstatus)

    End Function

#End Region
#Region "EDIT functions"
    Public Function editArrangemang(arrobj As arrangemangInfo) As arrangemangcontainerInfo
        Dim obj As New CrudArrangemangController

        Dim retstatus As String = ""

        If obj.editArrangemang(arrobj) Then
            retstatus = "OK! Mainarrangemang Arrid: " & arrobj.Arrid & " är uppdaterat av user: " & arrobj.Username

            If obj.editcontent(arrobj) Then
                retstatus = "OK! Contentarrangemang Arrid: " & arrobj.Arrid & " är uppdaterat av user: " & arrobj.Username
            Else
                retstatus = "ERROR! Något gick fel när Arrid: " & arrobj.Arrid & " skulle uppdateras av user: " & arrobj.Username
            End If

        Else
            retstatus = "ERROR! Något gick fel när Arrid: " & arrobj.Arrid & " skulle uppdateras av user: " & arrobj.Username
        End If

        Return getArrangemanHelper(arrobj.Arrid, retstatus)

    End Function

    Public Function editMediaByMediaid(arrid As Integer, mediaobj As mediaInfo) As arrangemangcontainerInfo
        Dim obj As New CrudArrangemangController
        Dim retstatus As String = ""

        If obj.editmediabymediaid(mediaobj) Then
            retstatus = "OK! Mediaid: " & mediaobj.MediaID & " till arrangemang Arrid: " & arrid & " är uppdaterat"
        Else
            retstatus = "ERROR! Något gick fel när Mediaid: " & mediaobj.MediaID & "  till arrangemang Arrid: " & arrid & " skulle uppdateras"
        End If

        Return getArrangemanHelper(arrid, retstatus)

    End Function

    Public Function editFaktaByFaktaid(arrid As Integer, faktaobj As faktainfo) As arrangemangcontainerInfo
        Dim obj As New CrudArrangemangController
        Dim retstatus As String = ""

        If obj.editFaktabyfaktaid(faktaobj) Then
            retstatus = "OK! Faktaid: " & faktaobj.Faktaid & " till arrangemang Arrid: " & arrid & " är uppdaterat"
        Else
            retstatus = "ERROR! Något gick fel när Faktaid: " & faktaobj.Faktaid & " till arrangemang Arrid: " & arrid & " skulle uppdateras"
        End If

        Return getArrangemanHelper(arrid, retstatus)

    End Function

#End Region
#Region "Delete functions"
    Public Function deleteMediaByMediaid(arrid As Integer, mediaobj As mediaInfo) As arrangemangcontainerInfo
        Dim obj As New CrudArrangemangController
        Dim retstatus As String = ""

        If obj.delMediabyMediaid(mediaobj) Then
            retstatus = "OK! Mediaid: " & mediaobj.MediaID & " till arrangemang Arrid: " & arrid & " är uppdaterat"
        Else
            retstatus = "ERROR! Något gick fel när Mediaid: " & mediaobj.MediaID & "  till arrangemang Arrid: " & arrid & " skulle uppdateras"
        End If

        Return getArrangemanHelper(arrid, retstatus)

    End Function
    Public Function deleteFaktaByFaktaid(arrid As Integer, faktaobj As faktainfo) As arrangemangcontainerInfo
        Dim obj As New CrudArrangemangController
        Dim retstatus As String = ""

        If obj.delFaktabyFaktaid(faktaobj) Then
            retstatus = "OK! Faktaid: " & faktaobj.Faktaid & " till arrangemang Arrid: " & arrid & " är Borttaget"
        Else
            retstatus = "ERROR! Något gick fel när Faktaid: " & faktaobj.Faktaid & " till arrangemang Arrid: " & arrid & " skulle Tas bort"
        End If

        Return getArrangemanHelper(arrid, retstatus)

    End Function
#End Region


    Private Function getArrangemanHelper(arrid As Integer, status As String) As arrangemangcontainerInfo
        Dim tmpcmdtyp As New commandTypeInfo
        tmpcmdtyp.ArrID = arrid
        tmpcmdtyp.CmdTyp = "details"

        Dim retobj As arrangemangcontainerInfo = getArrangemang(tmpcmdtyp)
        retobj.Status = status

        Return retobj
    End Function
End Class
