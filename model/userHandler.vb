Public Class userHandler
    Private _dalobj As New arrangemangDAL

    Public Function adUserRollToCmdtyp(cmdtyp As commandTypeInfo) As commandTypeInfo

        If _dalobj.isUserAdmin(cmdtyp.CmdtypUserid) Then
            cmdtyp.IsAdminRoll = 1
        Else
            Dim usrrolls As List(Of Integer) = _dalobj.getuserRolToKonstFormMapper(cmdtyp.CmdtypUserid)

            Dim i = 1
            For Each rol In usrrolls
                Select Case i
                    Case 1
                        cmdtyp.CmdRoll1 = rol
                    Case 2
                        cmdtyp.CmdRoll2 = rol
                    Case 3
                        cmdtyp.CmdRoll3 = rol
                    Case 4
                        cmdtyp.CmdRoll4 = rol
                    Case 5
                        cmdtyp.CmdRoll5 = rol
                    Case 6
                        cmdtyp.CmdRoll6 = rol
                    Case 7
                        cmdtyp.CmdRoll7 = rol
                    Case 8
                        cmdtyp.CmdRoll8 = rol
                    Case 9
                        cmdtyp.CmdRoll9 = rol
                    Case 10
                        cmdtyp.CmdRoll10 = rol
                    Case Else
                        cmdtyp.CmdRoll10 = rol
                End Select
                i += 1
            Next

        End If

        Return cmdtyp
    End Function


End Class
