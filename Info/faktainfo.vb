Public Class faktainfo

    Private _faktatypid As Integer
    Private _faktarubrik As String
    Private _faktavalue As String
    Public Sub New()
        _faktatypid = 0
        _faktarubrik = ""
        _faktavalue = ""
        _faktaid = 0
    End Sub

    Public Property FaktaTypID() As Integer
        Get
            Return _faktatypid
        End Get
        Set(ByVal value As Integer)
            _faktatypid = value
        End Set
    End Property
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

    Private _faktaid As Integer
    Public Property Faktaid() As Integer
        Get
            Return _faktaid
        End Get
        Set(ByVal value As Integer)
            _faktaid = value
        End Set
    End Property
End Class
