Public Class kk_aj_arr_MainController

    Public Function getArrangemang(cmdtyp As commandTypeInfo) As arrangemangcontainerInfo
        Dim obj As New ArrangemangController

        Return obj.getArrlist(cmdtyp)

    End Function

    Public Function test(val As String) As String
        Return "detta funkar. du skrev: " & val
    End Function
End Class
