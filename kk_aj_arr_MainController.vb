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
End Class
