﻿Public Class mediaInfo
    Private _mediaurl As String
    Private _mediafilename As String
    Private _mediasize As String
    Private _mediaalt As String
    Private _mediaFoto As String

    Public Sub New()
        _mediaurl = ""
        _mediafilename = ""
        _mediasize = ""
        _mediaalt = ""
        _mediaFoto = ""
    End Sub
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
End Class