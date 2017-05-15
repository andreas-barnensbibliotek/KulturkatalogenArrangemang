Public Class utovareInfo

    Public Sub New()
        _utivarid = 0
        _organisation = ""
        _fornamn = ""
        _efternamn = ""
        _telefon = ""
        _adress = ""
        _ort = ""
        _epost = ""
        _kommun = ""
        _weburl = ""
    End Sub

    Private _utivarid As Integer
    Public Property UtovarID() As Integer
        Get
            Return _utivarid
        End Get
        Set(ByVal value As Integer)
            _utivarid = value
        End Set
    End Property
    Private _organisation As String
    Public Property Organisation() As String
        Get
            Return _organisation
        End Get
        Set(ByVal value As String)
            _organisation = value
        End Set
    End Property

    Private _fornamn As String
    Public Property Fornamn() As String
        Get
            Return _fornamn
        End Get
        Set(ByVal value As String)
            _fornamn = value
        End Set
    End Property

    Private _efternamn As String
    Public Property Efternamn() As String
        Get
            Return _efternamn
        End Get
        Set(ByVal value As String)
            _efternamn = value
        End Set
    End Property

    Private _telefon As String
    Public Property Telefon() As String
        Get
            Return _telefon
        End Get
        Set(ByVal value As String)
            _telefon = value
        End Set
    End Property
    Private _adress As String
    Public Property Adress() As String
        Get
            Return _adress
        End Get
        Set(ByVal value As String)
            _adress = value
        End Set
    End Property
    Private _postnr As String
    Public Property Postnr() As String
        Get
            Return _postnr
        End Get
        Set(ByVal value As String)
            _postnr = value
        End Set
    End Property
    Private _ort As String
    Public Property Ort() As String
        Get
            Return _ort
        End Get
        Set(ByVal value As String)
            _ort = value
        End Set
    End Property
    Private _epost As String
    Public Property Epost() As String
        Get
            Return _epost
        End Get
        Set(ByVal value As String)
            _epost = value
        End Set
    End Property
    Private _kommun As String
    Public Property Kommun() As String
        Get
            Return _kommun
        End Get
        Set(ByVal value As String)
            _kommun = value
        End Set
    End Property
    Private _weburl As String
    Public Property Weburl() As String
        Get
            Return _weburl
        End Get
        Set(ByVal value As String)
            _weburl = value
        End Set
    End Property

End Class
