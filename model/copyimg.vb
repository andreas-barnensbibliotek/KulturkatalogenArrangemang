
Imports System.IO
Public Class copyimg
    Private _saveurl As String = "D:\wwwroot\dnndev_v902.me\Portals\0\kulturkatalogenArrImages\"
    Public Function copyifimgexists(arrid As String, imgsrc As String) As Boolean

        Try
            Dim filnamnet As String = _saveurl & imgsrc
            If (File.Exists(filnamnet) And String.IsNullOrEmpty(arrid) = False) Then

                File.Copy(Path.Combine(_saveurl, imgsrc), Path.Combine(_saveurl, arrid & "_" & imgsrc), True)

            End If
            Return True

        Catch dirNotFound As DirectoryNotFoundException
            Return False
        End Try

    End Function
End Class
