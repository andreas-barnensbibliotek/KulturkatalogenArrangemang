Public Class arrangemangInfo
    'TODO lägg till alla parametrar som behövs och tillkommer i arrangemangstabellen

    Private _arrid As Integer
    Private _datum As String
    Private _contentID As Integer
    Private _rubrik As String
    Private _underrubrik As String
    Private _innehall As String
    Private _publicerad As String
    Private _lookedAt As String
    Private _arrangemangstatus As String
    Private _arrangemangtyp As String
    Private _konstform As String
    Private _username As String
    Private _arrutovare As String
    Private _utovarid As Integer
    Private _utovarinfo As utovareInfo
    Private _mainimage As mediaInfo
    Private _movieclip As mediaInfo
    Private _medialist As List(Of mediaInfo)
    Private _faktalist As List(Of faktainfo)

    Public Sub New()
        _arrid = 0
        _datum = ""
        _contentID = 0
        _rubrik = ""
        _underrubrik = ""
        _innehall = ""
        _publicerad = "nej"
        _lookedAt = "nej"
        _arrangemangstatus = ""
        _arrangemangtyp = ""
        _konstform = ""
        _username = ""
        _utovarid = 0
        _arrutovare = ""
        _utovarinfo = New utovareInfo
        _mainimage = New mediaInfo
        _movieclip = New mediaInfo
        _faktalist = New List(Of faktainfo)
        _medialist = New List(Of mediaInfo)
    End Sub
    Public Property Arrid() As Integer
        Get
            Return _arrid
        End Get
        Set(ByVal value As Integer)
            _arrid = value
        End Set
    End Property

    Public Property Datum() As String
        Get
            Return _datum
        End Get
        Set(ByVal value As String)
            _datum = value
        End Set
    End Property


    Public Property ContentID() As Integer
        Get
            Return _contentID
        End Get
        Set(ByVal value As Integer)
            _contentID = value
        End Set
    End Property
    Public Property NewProperty() As Integer
        Get
            Return _contentID
        End Get
        Set(ByVal value As Integer)
            _contentID = value
        End Set
    End Property
    Public Property Rubrik() As String
        Get
            Return _rubrik
        End Get
        Set(ByVal value As String)
            _rubrik = value
        End Set
    End Property

    Public Property UnderRubrik() As String
        Get
            Return _underrubrik
        End Get
        Set(ByVal value As String)
            _underrubrik = value
        End Set
    End Property


    Public Property Innehall() As String
        Get
            Return _innehall
        End Get
        Set(ByVal value As String)
            _innehall = value
        End Set
    End Property

    Public Property Utovare() As String
        Get
            Return _arrutovare
        End Get
        Set(ByVal value As String)
            _arrutovare = value
        End Set
    End Property

    Public Property Utovarid() As Integer
        Get
            Return _utovarid
        End Get
        Set(ByVal value As Integer)
            _utovarid = value
        End Set
    End Property
    Public Property UtovareData() As utovareInfo
        Get
            Return _utovarinfo
        End Get
        Set(ByVal value As utovareInfo)
            _utovarinfo = value
        End Set
    End Property

    Public Property MainImage() As mediaInfo
        Get
            Return _mainimage
        End Get
        Set(ByVal value As mediaInfo)
            _mainimage = value
        End Set
    End Property

    Public Property MediaClip() As mediaInfo
        Get
            Return _movieclip
        End Get
        Set(ByVal value As mediaInfo)
            _movieclip = value
        End Set
    End Property

    Public Property MediaList() As List(Of mediaInfo)
        Get
            Return _medialist
        End Get
        Set(ByVal value As List(Of mediaInfo))
            _medialist = value
        End Set
    End Property
    Public Property Publicerad() As String
        Get
            Return _publicerad
        End Get
        Set(ByVal value As String)
            _publicerad = value
        End Set
    End Property

    Public Property Faktalist() As List(Of faktainfo)
        Get
            Return _faktalist
        End Get
        Set(ByVal value As List(Of faktainfo))
            _faktalist = value
        End Set
    End Property


    Public Property LookedAt() As String
        Get
            Return _lookedAt
        End Get
        Set(ByVal value As String)
            _lookedAt = value
        End Set
    End Property

    Public Property ArrangemangStatus() As String
        Get
            Return _arrangemangstatus
        End Get
        Set(ByVal value As String)
            _arrangemangstatus = value
        End Set
    End Property

    Public Property Arrangemangtyp() As String
        Get
            Return _arrangemangtyp
        End Get
        Set(ByVal value As String)
            _arrangemangtyp = value
        End Set
    End Property

    Public Property Konstform() As String
        Get
            Return _konstform
        End Get
        Set(ByVal value As String)
            _konstform = value
        End Set
    End Property

    Public Property Username() As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property
End Class
