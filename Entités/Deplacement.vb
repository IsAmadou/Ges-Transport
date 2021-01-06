Imports Gestion_transport

Public Class Deplacement

    Private _Id_Déplacement As Integer
    Private _Trajets As Trajet
    Private _Vehicules As Véhicules
    Private _Marchandises As Marchandises
    Private _Date_Départ As DateTime
    Private _Date_Arrivée As DateTime
    Private _Heure_Départ As DateTime
    Private _Heure_Arrivée As DateTime
    Private _Quantité_Déplacée As Integer

    Public Sub New(Trajets As Trajet, Vehicules As Véhicules, Marchandises As Marchandises,
     Date_Départ As DateTime, Date_Arrivée As DateTime, Heure_Départ As DateTime, Heure_Arrivée As DateTime, Quantité_Déplacée As Integer)
        _Trajets = Trajets
        _Vehicules = Vehicules
        _Marchandises = Marchandises
        _Date_Départ = Date_Départ
        _Date_Arrivée = Date_Arrivée
        _Heure_Départ = Heure_Départ
        _Heure_Arrivée = Heure_Arrivée
        _Quantité_Déplacée = Quantité_Déplacée
    End Sub

    Public Sub New(Id_Déplacement As Integer, Trajets As Trajet, Vehicules As Véhicules, Marchandises As Marchandises,
                   Date_Départ As DateTime, Date_Arrivée As DateTime, Heure_Départ As DateTime,
                   Heure_Arrivée As DateTime, Quantité_Déplacée As Integer)

        _Id_Déplacement = Id_Déplacement
        _Trajets = Trajets
        _Vehicules = Vehicules
        _Marchandises = Marchandises
        _Date_Départ = Date_Départ
        _Date_Arrivée = Date_Arrivée
        _Heure_Départ = Heure_Départ
        _Heure_Arrivée = Heure_Arrivée
        _Quantité_Déplacée = Quantité_Déplacée
    End Sub

    Public Property Id_Déplacement As Integer
        Get
            Return _Id_Déplacement
        End Get
        Set(value As Integer)
            _Id_Déplacement = value
        End Set
    End Property

    Public Property Trajets As Trajet
        Get
            Return _Trajets
        End Get
        Set(value As Trajet)
            _Trajets = value
        End Set
    End Property

    Public Property Vehicules As Véhicules
        Get
            Return _Vehicules
        End Get
        Set(value As Véhicules)
            _Vehicules = value
        End Set
    End Property

    Public Property Marchandises As Marchandises
        Get
            Return _Marchandises
        End Get
        Set(value As Marchandises)
            _Marchandises = value
        End Set
    End Property

    Public Property Date_Départ As DateTime
        Get
            Return _Date_Départ
        End Get
        Set(value As DateTime)
            _Date_Départ = value
        End Set
    End Property

    Public Property Date_Arrivée As DateTime
        Get
            Return _Date_Arrivée
        End Get
        Set(value As DateTime)
            _Date_Arrivée = value
        End Set
    End Property

    Public Property Heure_Départ As Date
        Get
            Return _Heure_Départ
        End Get
        Set(value As Date)
            _Heure_Départ = value
        End Set
    End Property

    Public Property Heure_Arrivée As Date
        Get
            Return _Heure_Arrivée
        End Get
        Set(value As Date)
            _Heure_Arrivée = value
        End Set
    End Property

    Public Property Quantité_Déplacée As Integer
        Get
            Return _Quantité_Déplacée
        End Get
        Set(value As Integer)
            _Quantité_Déplacée = value
        End Set
    End Property
End Class
