Public Class kk_aj_arr_MainController

    Public Function getArrangemang(cmdtyp As commandTypeInfo) As arrangemangcontainerInfo
        Dim obj As New ArrangemangController
        Return obj.getArrlist(cmdtyp)

    End Function

    Public Function updateArrPropeties(cmdtyp As updatearrcommand) As arrangemangcontainerInfo
        Dim obj As New ArrangemangController
        Return obj.updateArrStatusType(cmdtyp)

    End Function
End Class
