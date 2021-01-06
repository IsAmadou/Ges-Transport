Public Class Garage

    Private _Id_Visite As Integer
    Private _Nom_Garage As String
    Private _Adresse_Garage As String
    Private _Tel_Garage As String

    Public Sub New(Nom_Garage As String, Adresse_Garage As String, Tel_Garage As String)
        _Nom_Garage = Nom_Garage
        _Adresse_Garage = Adresse_Garage
        _Tel_Garage = Tel_Garage
    End Sub

    Public Sub New(Id_Visite As Integer, Nom_Garage As String, Adresse_Garage As String, Tel_Garage As String)
        _Id_Visite = Id_Visite
        _Nom_Garage = Nom_Garage
        _Adresse_Garage = Adresse_Garage
        _Tel_Garage = Tel_Garage
    End Sub

    Public Property Id_Visite() As Integer
        Get
            Return _Id_Visite
        End Get
        Set(ByVal value As Integer)
            _Id_Visite = value
        End Set
    End Property

    Public Property Nom_Garage() As String
        Get
            Return _Nom_Garage
        End Get
        Set(ByVal value As String)
            _Nom_Garage = value
        End Set
    End Property

    Public Property Adresse_Garage() As String
        Get
            Return _Adresse_Garage
        End Get
        Set(ByVal value As String)
            _Adresse_Garage = value
        End Set
    End Property

    Public Property Tel_Garage As String
        Get
            Return _Tel_Garage
        End Get
        Set(value As String)
            _Tel_Garage = value
        End Set
    End Property
End Class
