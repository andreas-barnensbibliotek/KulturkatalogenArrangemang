Public Class filterfaktaInfo

    Public Sub New()
        _bokningsbar = "0"
        _morklaggning = "0"
        _speltid = "0"
        _takhojd = "0"
        _kostnad = "0"
    End Sub

    Private _bokningsbar As String
    Public Property Bokningsbar() As String
        Get
            Return _bokningsbar
        End Get
        Set(ByVal value As String)
            _bokningsbar = value
        End Set
    End Property

    Private _morklaggning As String
    Public Property Morklaggning() As String
        Get
            Return _morklaggning
        End Get
        Set(ByVal value As String)
            _morklaggning = value
        End Set
    End Property

    Private _takhojd As String
    Public Property Takhojd() As String
        Get
            Return _takhojd
        End Get
        Set(ByVal value As String)
            _takhojd = value
        End Set
    End Property

    Private _speltid As String
    Public Property Speltid() As String
        Get
            Return _speltid
        End Get
        Set(ByVal value As String)
            _speltid = value
        End Set
    End Property

    Private _kostnad As String
    Public Property Kostnad() As String
        Get
            Return _kostnad
        End Get
        Set(ByVal value As String)
            _kostnad = value
        End Set
    End Property
End Class
