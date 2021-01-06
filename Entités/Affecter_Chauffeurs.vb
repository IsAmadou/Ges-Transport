Imports Gestion_transport

Public Class Affecter_Chauffeurs

    Private _Id_Affectation As Integer
    Private _Chauffeur As Chauffeurs
    Private _Vehicule As Véhicules
    Private _Date_Affectation As DateTime
    Private _Date_FinAffectation As DateTime

    Public Sub New(Chauffeur As Chauffeurs, Vehicule As Véhicules, Date_Affectation As DateTime,
                   Date_FinAffectation As DateTime)
        _Chauffeur = Chauffeur
        _Vehicule = Vehicule
        _Date_Affectation = Date_Affectation
        _Date_FinAffectation = Date_FinAffectation
    End Sub

    Public Sub New(Id_Affectation As Integer, Chauffeur As Chauffeurs, Vehicule As Véhicules,
                   Date_Affectation As DateTime, Date_FinAffectation As DateTime)
        _Id_Affectation = Id_Affectation
        _Chauffeur = Chauffeur
        _Vehicule = Vehicule
        _Date_Affectation = Date_Affectation
        _Date_FinAffectation = Date_FinAffectation
    End Sub

    Public Property Id_Affectation As Integer
        Get
            Return _Id_Affectation
        End Get
        Set(value As Integer)
            _Id_Affectation = value
        End Set
    End Property

    Public Property Chauffeur As Chauffeurs
        Get
            Return _Chauffeur
        End Get
        Set(value As Chauffeurs)
            _Chauffeur = value
        End Set
    End Property

    Public Property Vehicule As Véhicules
        Get
            Return _Vehicule
        End Get
        Set(value As Véhicules)
            _Vehicule = value
        End Set
    End Property

    Public Property Date_Affectation As DateTime
        Get
            Return _Date_Affectation
        End Get
        Set(value As Date)
            _Date_Affectation = value
        End Set
    End Property

    Public Property Date_FinAffectation As DateTime
        Get
            Return _Date_FinAffectation
        End Get
        Set(value As Date)
            _Date_FinAffectation = value
        End Set
    End Property
End Class
