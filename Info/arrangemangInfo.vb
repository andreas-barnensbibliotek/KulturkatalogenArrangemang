﻿Public Class arrangemangInfo
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
    Private _arrangemangtypid As String
    Private _konstformid As String
    Private _arrangemangtyp As String
    Private _konstform As String
    Private _username As String
    Private _arrutovare As String
    Private _arrgrupid As Integer
    Private _utovarid As Integer
    Private _utovarinfo As utovareInfo
    Private _mainimage As mediaInfo
    Private _movieclip As mediaInfo
    Private _medialist As List(Of mediaInfo)
    Private _faktalist As List(Of faktainfo)
    Private _startyear As String
    Private _stoppyear As String
    Private _inlagddatum As String
    Private _filterfakta As filterfaktaInfo
    Private _debug As String
    Private _konstform2 As String
    Private _konstform3 As String
    Private _kontatkid As String
    Private _kontaktFornamn As String
    Private _kontaktEfternamn As String
    Private _kontakttelefon As String
    Private _kontaktEpost As String

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
        _arrangemangtypid = 0
        _konstformid = 0
        _arrangemangtyp = ""
        _konstform = ""
        _username = ""
        _utovarid = 0
        _arrutovare = ""
        _arrgrupid = 0
        _utovarinfo = New utovareInfo
        _mainimage = New mediaInfo
        _movieclip = New mediaInfo
        _faktalist = New List(Of faktainfo)
        _medialist = New List(Of mediaInfo)
        _filterfakta = New filterfaktaInfo
        _startyear = ""
        _stoppyear = ""
        _inlagddatum = ""
        _debug = ""
        _konstform2 = "0"
        _konstform3 = "0"
        _kontatkid = ""
        _kontaktFornamn = ""
        _kontaktEfternamn = ""
        _kontakttelefon = ""
        _kontaktEpost = ""

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
    Public Property Arrgruppid() As Integer
        Get
            Return _arrgrupid
        End Get
        Set(ByVal value As Integer)
            _arrgrupid = value
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

    Public Property Arrangemangtypid() As String
        Get
            Return _arrangemangtypid
        End Get
        Set(ByVal value As String)
            _arrangemangtypid = value
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

    Public Property Konstformid() As String
        Get
            Return _konstformid
        End Get
        Set(ByVal value As String)
            _konstformid = value
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

    Public Property Startyear() As String
        Get
            Return _startyear
        End Get
        Set(ByVal value As String)
            _startyear = value
        End Set
    End Property

    Public Property Stoppyear() As String
        Get
            Return _stoppyear
        End Get
        Set(ByVal value As String)
            _stoppyear = value
        End Set
    End Property

    Public Property inlagddatum() As String
        Get
            Return _inlagddatum
        End Get
        Set(ByVal value As String)
            _inlagddatum = value
        End Set
    End Property
    Public Property debug() As String
        Get
            Return _debug
        End Get
        Set(ByVal value As String)
            _debug = value
        End Set
    End Property

    Public Property Filterfakta() As filterfaktaInfo
        Get
            Return _filterfakta
        End Get
        Set(ByVal value As filterfaktaInfo)
            _filterfakta = value
        End Set
    End Property

    Public Property Konstform2() As String
        Get
            Return _konstform2
        End Get
        Set(ByVal value As String)
            _konstform2 = value
        End Set
    End Property

    Public Property Konstform3() As String
        Get
            Return _konstform3
        End Get
        Set(ByVal value As String)
            _konstform3 = value
        End Set
    End Property
    Public Property KontaktId() As String
        Get
            Return _kontatkid
        End Get
        Set(ByVal value As String)
            _kontatkid = value
        End Set
    End Property

    Public Property Kontaktfornamn() As String
        Get
            Return _kontaktFornamn
        End Get
        Set(ByVal value As String)
            _kontaktFornamn = value
        End Set
    End Property

    Public Property KontaktEfternamn() As String
        Get
            Return _kontaktEfternamn
        End Get
        Set(ByVal value As String)
            _kontaktEfternamn = value
        End Set
    End Property
    Public Property KontaktTelefon() As String
        Get
            Return _kontakttelefon
        End Get
        Set(ByVal value As String)
            _kontakttelefon = value
        End Set
    End Property
    Public Property KontaktEpost() As String
        Get
            Return _kontaktEpost
        End Get
        Set(ByVal value As String)
            _kontaktEpost = value
        End Set
    End Property
End Class

