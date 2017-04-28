Public Class arrangemangcontainerInfo

    Private _arrstatus As String
    Public Property ArrStatus() As String
        Get
            Return _arrstatus
        End Get
        Set(ByVal value As String)
            _arrstatus = value
        End Set
    End Property

    Private _arrangemanglist As List(Of arrangemangInfo)
    Public Property Arrangemanglist() As List(Of arrangemangInfo)
        Get
            Return _arrangemanglist
        End Get
        Set(ByVal value As List(Of arrangemangInfo))
            _arrangemanglist = value
        End Set
    End Property

    Private _arrangemanglistCount As String
    Public Property ArrangemanglistCount() As String
        Get
            Return _arrangemanglistCount
        End Get
        Set(ByVal value As String)
            _arrangemanglistCount = value
        End Set
    End Property

    Private _currentpage As String
    Public Property ArrangemangCurrentPage() As String
        Get
            Return _currentpage
        End Get
        Set(ByVal value As String)
            _currentpage = value
        End Set
    End Property

    Private _arrangemanglisttotalpages As String
    Public Property ArrangemangTotalPages() As String
        Get
            Return _arrangemanglisttotalpages
        End Get
        Set(ByVal value As String)
            _arrangemanglisttotalpages = value
        End Set
    End Property

    Private _nyaarrangemangCount As String
    Public Property NyaArrangemangCount() As String
        Get
            Return _nyaarrangemangCount
        End Get
        Set(ByVal value As String)
            _nyaarrangemangCount = value
        End Set
    End Property

    Private _approvedarrangemangCount As String
    Public Property ApprovedarrangemangCount() As String
        Get
            Return _approvedarrangemangCount
        End Get
        Set(ByVal value As String)
            _approvedarrangemangCount = value
        End Set
    End Property

    Private _deniedarrangemangCount As String
    Public Property DeniedarrangemangCount() As String
        Get
            Return _deniedarrangemangCount
        End Get
        Set(ByVal value As String)
            _deniedarrangemangCount = value
        End Set
    End Property

    Private _status As String
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property
End Class
