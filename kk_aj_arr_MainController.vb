Public Class kk_aj_arr_MainController

    Public Function getArrangemang(cmdtyp As commandTypeInfo) As arrangemangcontainerInfo
        Dim obj As New ArrangemangController
        Return obj.getArrlist(cmdtyp)

    End Function

    Public Function updateArrPropeties(cmdtyp As updatearrcommand) As arrangemangcontainerInfo
        Dim obj As New ArrangemangController
        Return obj.updateArrStatusType(cmdtyp)

    End Function

    Public Function addArrangemang(cmdtyp As updatearrcommand, arrData As arrangemangInfo) As arrangemangcontainerInfo

        Dim obj As New CrudArrangemangController

        arrData.ArrangemangStatus = 1 'Nytt"
        arrData.Datum = Date.Now
        Return obj.addArrangemang(arrData)

    End Function

    Public Function DelArrangemang(cmdtyp As updatearrcommand) As arrangemangcontainerInfo
        Dim ret As New arrangemangcontainerInfo
        Dim obj As New CrudArrangemangController

        If obj.delarrangemang(cmdtyp.Arrid) Then
            ret.Status = "Arrid: " & cmdtyp.Arrid & " är nu borttaget!!"
        Else
            ret.Status = "Error! Fel vid borttagning av Arrid: " & cmdtyp.Arrid
        End If
        Return ret

    End Function
End Class
