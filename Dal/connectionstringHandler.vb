Imports System.IO
Imports System.Configuration
Imports System.Globalization
Imports System.ComponentModel
Imports System.Collections.Specialized


Public Class connectionstringHandler
    Private _connectionstring As String

    Public Sub New()
        ' _connectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=kulturkatalogenDB_v1;Persist Security Info=True;User ID=dnndev_v902.me;Password=L0rda1f"
        ' _connectionString = "Data Source=DE-1896;Initial Catalog=kulturkatalogenDB_DEV;User ID=kulturkatalogenDB;Password=L0rda1f"
        '_connectionstring = "Data Source=.\SQLEXPRESS;Initial Catalog=dnndev_v902.me;Persist Security Info=True;User ID=dnndev_v902.me;Password=L0rda1f"
        '_connectionstring = "Data Source=DE-1896;Initial Catalog=kulturkatalogenDB;User ID=kulturkatalogenDB;Password=L0rda1f"
        '_connectionstring = "Data Source=DE-2697;Initial Catalog=kulturkatalogenDB_DEV;User ID=KulturkatalogenDB_DEV;Password=L0rda1f"
        'SKARP NYA SERVERN
        _connectionstring = "Data Source=DE-2697;Initial Catalog=kulturkatalogenDB;User ID=KulturkatalogenDB2;Password=L0rda1f"
    End Sub
    Public ReadOnly Property CurrentConnectionString() As String
        Get
            Return _connectionstring
        End Get

    End Property


End Class
