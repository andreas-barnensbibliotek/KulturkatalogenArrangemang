Public Class logInfo

    Private _logid As Integer
    Private _logtypid As Integer
    Private _logtyp As String
    Private _datum As Date
    Private _arrid As Integer
    Private _arrrubrik As String
    Private _arrutovare As String
    Private _beskrivning As String
    Private _changebyuserid As Integer
    Private _ChangebyUsernamn As String
    Private _statustypid As Integer
    Private _statustyp As String

    Public Sub New()
        _logid = 0
        _logtypid = 0
        _logtyp = ""
        _datum = Date.Now
        _arrid = 0
        _arrrubrik = ""
        _arrutovare = ""
        _changebyuserid = 0
        _ChangebyUsernamn = ""
        _statustypid = 0
        _statustyp = ""
        _beskrivning = ""
    End Sub
    Public Property logid() As Integer
        Get
            Return _logid
        End Get
        Set(ByVal value As Integer)
            _logid = value
        End Set
    End Property


    Public Property logtypid() As Integer
        Get
            Return _logtypid
        End Get
        Set(ByVal value As Integer)
            _logtypid = value
        End Set
    End Property

    Public Property logtyp() As String
        Get
            Return _logtyp
        End Get
        Set(ByVal value As String)
            _logtyp = value
        End Set
    End Property

    Public Property Arrid() As Integer
        Get
            Return _arrid
        End Get
        Set(ByVal value As Integer)
            _arrid = value
        End Set
    End Property

    Public Property Arrrubrik() As String
        Get
            Return _arrrubrik
        End Get
        Set(ByVal value As String)
            _arrrubrik = value
        End Set
    End Property

    Public Property Arrutovare() As String
        Get
            Return _arrutovare
        End Get
        Set(ByVal value As String)
            _arrutovare = value
        End Set
    End Property

    Public Property Statustypid() As Integer
        Get
            Return _statustypid
        End Get
        Set(ByVal value As Integer)
            _statustypid = value
        End Set
    End Property

    Public Property Statustyp() As String
        Get
            Return _statustyp
        End Get
        Set(ByVal value As String)
            _statustyp = value
        End Set
    End Property

    Public Property ChangebyUserid() As Integer
        Get
            Return _changebyuserid
        End Get
        Set(ByVal value As Integer)
            _changebyuserid = value
        End Set
    End Property

    Public Property ChangebyUsernamn() As String
        Get
            Return _ChangebyUsernamn
        End Get
        Set(ByVal value As String)
            _ChangebyUsernamn = value
        End Set
    End Property

    Public Property Datum() As Date
        Get
            Return _datum
        End Get
        Set(ByVal value As Date)
            _datum = value
        End Set
    End Property

    Public Property Beskrivning() As String
        Get
            Return _beskrivning
        End Get
        Set(ByVal value As String)
            _beskrivning = value
        End Set
    End Property
End Class
