Public Class mediaInfo
    Private _mediaid As Integer
    Private _mediaurl As String
    Private _mediafilename As String
    Private _mediasize As String
    Private _mediaalt As String
    Private _mediaFoto As String
    Private _mediatyp As String
    Private _mediaVald As String
    Private _mediaTitle As String
    Private _mediaBeskrivning As String
    Private _mediaLink As String
    Private _sortering As String


    Public Sub New()
        _mediaid = 0
        _mediaurl = ""
        _mediafilename = ""
        _mediasize = ""
        _mediaalt = ""
        _mediaFoto = ""
        _mediatyp = ""
        _mediaVald = "nej"
        _mediaTitle = ""
        _mediaBeskrivning = ""
        _mediaLink = ""
        _sortering = "0"

    End Sub
    Public Property MediaID() As Integer
        Get
            Return _mediaid
        End Get
        Set(ByVal value As Integer)
            _mediaid = value
        End Set
    End Property
    Public Property MediaUrl() As String
        Get
            Return _mediaurl
        End Get
        Set(ByVal value As String)
            _mediaurl = value
        End Set
    End Property


    Public Property MediaFilename() As String
        Get
            Return _mediafilename
        End Get
        Set(ByVal value As String)
            _mediafilename = value
        End Set
    End Property


    Public Property MediaSize() As String
        Get
            Return _mediasize
        End Get
        Set(ByVal value As String)
            _mediasize = value
        End Set
    End Property

    Public Property MediaAlt() As String
        Get
            Return _mediaalt
        End Get
        Set(ByVal value As String)
            _mediaalt = value
        End Set
    End Property

    Public Property MediaFoto() As String
        Get
            Return _mediaFoto
        End Get
        Set(ByVal value As String)
            _mediaFoto = value
        End Set
    End Property

    Public Property MediaTyp() As String
        Get
            Return _mediatyp
        End Get
        Set(ByVal value As String)
            _mediatyp = value
        End Set
    End Property

    Public Property MediaVald() As String
        Get
            Return _mediaVald
        End Get
        Set(ByVal value As String)
            _mediaVald = value
        End Set
    End Property

    Public Property mediaTitle() As String
        Get
            Return _mediaTitle
        End Get
        Set(ByVal value As String)
            _mediaTitle = value
        End Set
    End Property

    Public Property mediaBeskrivning() As String
        Get
            Return _mediaBeskrivning
        End Get
        Set(ByVal value As String)
            _mediaBeskrivning = value
        End Set
    End Property

    Public Property mediaLink() As String
        Get
            Return _mediaLink
        End Get
        Set(ByVal value As String)
            _mediaLink = value
        End Set
    End Property


    Public Property sortering() As String
        Get
            Return _sortering
        End Get
        Set(ByVal value As String)
            _sortering = value
        End Set
    End Property
End Class
