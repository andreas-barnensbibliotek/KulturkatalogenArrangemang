Public Class commandTypeInfo

    Public Sub New()
        _cmdtyp = ""
        _searchstr = ""
        _arrstatustyp = 1
        _cmdroll1 = 0
        _cmdroll2 = 0
        _cmdroll3 = 0
        _cmdroll4 = 0
        _cmdroll5 = 0
        _cmdroll6 = 0
        _cmdroll7 = 0
        _cmdroll8 = 0
        _cmdroll9 = 0
        _cmdroll10 = 0
        _isadminroll = 0
        _visningsperiod = DatePart(DateInterval.Year, Date.Now).ToString
        _cmdtypuserid = 0
        _arrid = 0
    End Sub

    Private _cmdtyp As String
    Public Property CmdTyp() As String
        Get
            Return _cmdtyp
        End Get
        Set(ByVal value As String)
            _cmdtyp = value
        End Set
    End Property

    Private _arrstatustyp As Integer
    Public Property ArrStatusTyp() As Integer
        Get
            Return _arrstatustyp
        End Get
        Set(ByVal value As Integer)
            _arrstatustyp = value
        End Set
    End Property

    Private _searchstr As String
    Public Property cmdValue() As String
        Get
            Return _searchstr
        End Get
        Set(ByVal value As String)
            _searchstr = value
        End Set
    End Property

    Private _isadminroll As String
    Public Property IsAdminRoll() As String
        Get
            Return _isadminroll
        End Get
        Set(ByVal value As String)
            _isadminroll = value
        End Set
    End Property

    Private _cmdroll1 As Integer
    Public Property CmdRoll1() As Integer
        Get
            Return _cmdroll1
        End Get
        Set(ByVal value As Integer)
            _cmdroll1 = value
        End Set
    End Property

    Private _cmdroll2 As Integer
    Public Property CmdRoll2() As Integer
        Get
            Return _cmdroll2
        End Get
        Set(ByVal value As Integer)
            _cmdroll2 = value
        End Set
    End Property
    Private _cmdroll3 As Integer
    Public Property CmdRoll3() As Integer
        Get
            Return _cmdroll3
        End Get
        Set(ByVal value As Integer)
            _cmdroll3 = value
        End Set
    End Property
    Private _cmdroll4 As Integer
    Public Property CmdRoll4() As Integer
        Get
            Return _cmdroll4
        End Get
        Set(ByVal value As Integer)
            _cmdroll4 = value
        End Set
    End Property
    Private _cmdroll5 As Integer
    Public Property CmdRoll5() As Integer
        Get
            Return _cmdroll5
        End Get
        Set(ByVal value As Integer)
            _cmdroll5 = value
        End Set
    End Property
    Private _cmdroll6 As Integer
    Public Property CmdRoll6() As Integer
        Get
            Return _cmdroll6
        End Get
        Set(ByVal value As Integer)
            _cmdroll6 = value
        End Set
    End Property
    Private _cmdroll7 As Integer
    Public Property CmdRoll7() As Integer
        Get
            Return _cmdroll7
        End Get
        Set(ByVal value As Integer)
            _cmdroll7 = value
        End Set
    End Property
    Private _cmdroll8 As Integer
    Public Property CmdRoll8() As Integer
        Get
            Return _cmdroll8
        End Get
        Set(ByVal value As Integer)
            _cmdroll8 = value
        End Set
    End Property
    Private _cmdroll9 As Integer
    Public Property CmdRoll9() As Integer
        Get
            Return _cmdroll9
        End Get
        Set(ByVal value As Integer)
            _cmdroll9 = value
        End Set
    End Property

    Private _cmdroll10 As Integer
    Public Property CmdRoll10() As Integer
        Get
            Return _cmdroll10
        End Get
        Set(ByVal value As Integer)
            _cmdroll10 = value
        End Set

    End Property

    Private _visningsperiod As String
    Public Property Visningsperiod() As String
        Get
            Return _visningsperiod
        End Get
        Set(ByVal value As String)
            _visningsperiod = value
        End Set
    End Property

    Private _cmdtypuserid As Integer
    Public Property CmdtypUserid() As Integer
        Get
            Return _cmdtypuserid
        End Get
        Set(ByVal value As Integer)
            _cmdtypuserid = value
        End Set
    End Property
    Private _arrid As Integer
    Public Property ArrID() As Integer
        Get
            Return _arrid
        End Get
        Set(ByVal value As Integer)
            _arrid = value
        End Set
    End Property
End Class
