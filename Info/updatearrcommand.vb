Public Class updatearrcommand

    Private _cmdtyp As String
    Public Property CmdTyp() As String
        Get
            Return _cmdtyp
        End Get
        Set(ByVal value As String)
            _cmdtyp = value
        End Set
    End Property
    Private _arrid As Integer
    Public Property Arrid() As Integer
        Get
            Return _arrid
        End Get
        Set(ByVal value As Integer)
            _arrid = value
        End Set
    End Property

    Private _updVal As String
    Public Property UpdValue() As String
        Get
            Return _updVal
        End Get
        Set(ByVal value As String)
            _updVal = value
        End Set
    End Property

    Private _arruserid As Integer
    Public Property arrUserid() As Integer
        Get
            Return _arruserid
        End Get
        Set(ByVal value As Integer)
            _arruserid = value
        End Set
    End Property

    Private _arrRollid As Integer
    Public Property ArrRollID() As Integer
        Get
            Return _arrRollid
        End Get
        Set(ByVal value As Integer)
            _arrRollid = value
        End Set
    End Property
End Class
