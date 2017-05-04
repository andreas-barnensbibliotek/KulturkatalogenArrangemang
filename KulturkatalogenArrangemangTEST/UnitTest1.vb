Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports KulturkatalogenArrangemang

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMethod1()

        Dim testar As New kk_aj_arr_MainController
        Dim cmd As New commandTypeInfo

        cmd.CmdTyp = "bystatus"
        cmd.CmdtypUserid = 3
        cmd.cmdValue = "testarna"
        cmd.ArrStatusTyp = 4
        cmd.IsAdminRoll = 0
        cmd.CmdRoll1 = 6
        cmd.CmdRoll2 = 10


        Dim ret As arrangemangcontainerInfo = testar.getArrangemang(cmd)

        Dim x As arrangemangcontainerInfo = ret

    End Sub

    <TestMethod()> Public Sub updatetest()
        Dim cmdtyp As New updatearrcommand
        cmdtyp.Arrid = 1
        cmdtyp.ArrRollID = 1
        cmdtyp.arrUserid = 1
        cmdtyp.UpdValue = "ja"
        cmdtyp.CmdTyp = "pub" 'arrstat pub lookedat

        Dim testar As New kk_aj_arr_MainController

        Dim ret As arrangemangcontainerInfo = testar.updateArrPropeties(cmdtyp)

        Dim tmp As String = ret.Status

    End Sub

End Class