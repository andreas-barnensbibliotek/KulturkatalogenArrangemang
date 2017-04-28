Public Class faktainfo

    Private _faktarubrik As String
    Private _faktavalue As String
    Public Sub New()
        _faktarubrik = ""
        _faktavalue = ""
    End Sub

    Public Property Faktarubrik() As String
        Get
            Return _faktarubrik
        End Get
        Set(ByVal value As String)
            _faktarubrik = value
        End Set
    End Property
    
    Public Property FaktaValue() As String
        Get
            Return _faktavalue
        End Get
        Set(ByVal value As String)
            _faktavalue = value
        End Set
    End Property
End Class
