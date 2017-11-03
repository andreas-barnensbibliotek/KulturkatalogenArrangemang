Public Class commandTypeSearchInfo
    Public Sub New()
        _arrtypid = Nothing
        _konstartid = Nothing
        _publiceradJaNej = "ja"
        _startyear = Nothing
        _stopyear = Nothing

    End Sub

    Private _cmdtyp As String
    Public Property cmdtyp() As String
        Get
            Return _cmdtyp
        End Get
        Set(ByVal value As String)
            _cmdtyp = value
        End Set
    End Property

    Private _arrtypid As Integer
    Public Property arrtypid() As Integer
        Get
            Return _arrtypid
        End Get
        Set(ByVal value As Integer)
            _arrtypid = value
        End Set
    End Property

    Private _konstartid As Integer
    Public Property konstartid() As Integer
        Get
            Return _konstartid
        End Get
        Set(ByVal value As integer)
            _konstartid = value
        End Set
    End Property

    Private _searchstr As String
    Public Property searchstr() As String
        Get
            Return _searchstr
        End Get
        Set(ByVal value As String)
            _searchstr = value
        End Set
    End Property

    Private _startyear As Integer
    Public Property startyear() As Integer
        Get
            Return _startyear
        End Get
        Set(ByVal value As Integer)
            _startyear = value
        End Set
    End Property
    Private _stopyear As Integer
    Public Property stopyear() As Integer
        Get
            Return _stopyear
        End Get
        Set(ByVal value As Integer)
            _stopyear = value
        End Set
    End Property

    Private _publiceradJaNej As String
    Public Property publiceradJaNej() As String
        Get
            Return _publiceradJaNej
        End Get
        Set(ByVal value As String)
            _publiceradJaNej = value
        End Set
    End Property
End Class
