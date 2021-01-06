Imports Gestion_transport

Public Class Pièces_Vehicule

    Private _Id_Piece As Integer
    Private _Véhicules As Véhicules
    Private _Carte_grise As String
    Private _Vignette As String
    Private _Date_ExpVignette As DateTime
    Private _Assurance As String
    Private _Date_ExpAssurance As DateTime

    Public Sub New(Véhicules As Véhicules, Carte_grise As String, Vignette As String, Date_ExpVignette As DateTime,
                   Assurance As String, Date_ExpAssurance As DateTime)
        _Véhicules = Véhicules
        _Carte_grise = Carte_grise
        _Vignette = Vignette
        _Date_ExpVignette = Date_ExpVignette
        _Assurance = Assurance
        _Date_ExpAssurance = Date_ExpAssurance
    End Sub

    Public Sub New(Véhicules As Véhicules, Carte_grise As String, Vignette As String, Assurance As String)
        _Véhicules = Véhicules
        _Carte_grise = Carte_grise
        _Vignette = Vignette
        _Assurance = Assurance
    End Sub

    Public Sub New(Véhicules As Véhicules, Carte_grise As String, Vignette As String,
                   Assurance As String, Date_ExpAssurance As DateTime)
        _Véhicules = Véhicules
        _Carte_grise = Carte_grise
        _Vignette = Vignette
        _Assurance = Assurance
        _Date_ExpAssurance = Date_ExpAssurance
    End Sub

    Public Sub New(Véhicules As Véhicules, Carte_grise As String, Vignette As String, Date_ExpVignette As DateTime,
                   Assurance As String)
        _Véhicules = Véhicules
        _Carte_grise = Carte_grise
        _Vignette = Vignette
        _Date_ExpVignette = Date_ExpVignette
        _Assurance = Assurance
    End Sub

    Public Sub New(Id_Piece As Integer, Véhicules As Véhicules, Carte_grise As String, Vignette As String,
                   Date_ExpVignette As DateTime, Assurance As String, Date_ExpAssurance As DateTime)
        _Id_Piece = Id_Piece
        _Véhicules = Véhicules
        _Carte_grise = Carte_grise
        _Vignette = Vignette
        _Date_ExpVignette = Date_ExpVignette
        _Assurance = Assurance
        _Date_ExpAssurance = Date_ExpAssurance
    End Sub

    Public Sub New(Id_Piece As Integer, Véhicules As Véhicules, Carte_grise As String, Vignette As String,
                  Assurance As String, Date_ExpAssurance As DateTime)
        _Id_Piece = Id_Piece
        _Véhicules = Véhicules
        _Carte_grise = Carte_grise
        _Vignette = Vignette
        _Assurance = Assurance
        _Date_ExpAssurance = Date_ExpAssurance
    End Sub

    Public Sub New(Id_Piece As Integer, Véhicules As Véhicules, Carte_grise As String, Vignette As String,
                   Date_ExpVignette As DateTime, Assurance As String)
        _Id_Piece = Id_Piece
        _Véhicules = Véhicules
        _Carte_grise = Carte_grise
        _Vignette = Vignette
        _Date_ExpVignette = Date_ExpVignette
        _Assurance = Assurance
    End Sub

    Public Sub New(Id_Piece As Integer, Véhicules As Véhicules, Carte_grise As String, Vignette As String,
                    Assurance As String)
        _Id_Piece = Id_Piece
        _Véhicules = Véhicules
        _Carte_grise = Carte_grise
        _Vignette = Vignette
        _Assurance = Assurance
    End Sub

    Public Property Id_Piece As Integer
        Get
            Return _Id_Piece
        End Get
        Set(value As Integer)
            _Id_Piece = value
        End Set
    End Property

    Public Property Véhicules As Véhicules
        Get
            Return _Véhicules
        End Get
        Set(value As Véhicules)
            _Véhicules = value
        End Set
    End Property

    Public Property Carte_grise As String
        Get
            Return _Carte_grise
        End Get
        Set(value As String)
            _Carte_grise = value
        End Set
    End Property

    Public Property Vignette As String
        Get
            Return _Vignette
        End Get
        Set(value As String)
            _Vignette = value
        End Set
    End Property

    Public Property Date_ExpVignette As DateTime
        Get
            Return _Date_ExpVignette
        End Get
        Set(value As DateTime)
            _Date_ExpVignette = value
        End Set
    End Property

    Public Property Assurance As String
        Get
            Return _Assurance
        End Get
        Set(value As String)
            _Assurance = value
        End Set
    End Property

    Public Property Date_ExpAssurance As DateTime
        Get
            Return _Date_ExpAssurance
        End Get
        Set(value As DateTime)
            _Date_ExpAssurance = value
        End Set
    End Property
End Class
