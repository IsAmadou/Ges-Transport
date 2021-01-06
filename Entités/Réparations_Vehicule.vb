Imports Gestion_transport

Public Class Réparations_Vehicule

    Private _Id_Reparation As Integer
    Private _Vehicule As Véhicules
    Private _Garage As Garage
    Private _Date_Reparation As DateTime
    Private _Date_Sortie As DateTime
    Private _Cout_Reparation As Double
    Private _Type_Entretien As String

    Public Sub New(Vehicule As Véhicules, Garage As Garage, Date_Reparation As Date, Date_Sortie As Date,
                   Cout_Reparation As Double, Type_Entretien As String)
        _Vehicule = Vehicule
        _Garage = Garage
        _Date_Reparation = Date_Reparation
        _Date_Sortie = Date_Sortie
        _Cout_Reparation = Cout_Reparation
        _Type_Entretien = Type_Entretien
    End Sub

    Public Sub New(Id_Reparation As Integer, Vehicule As Véhicules, Garage As Garage, Date_Reparation As Date,
                   Date_Sortie As Date, Cout_Reparation As Double, Type_Entretien As String)
        _Id_Reparation = Id_Reparation
        _Vehicule = Vehicule
        _Garage = Garage
        _Date_Reparation = Date_Reparation
        _Date_Sortie = Date_Sortie
        _Cout_Reparation = Cout_Reparation
        _Type_Entretien = Type_Entretien
    End Sub

    Public Property Id_Reparation As Integer
        Get
            Return _Id_Reparation
        End Get
        Set(value As Integer)
            _Id_Reparation = value
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

    Public Property Garage As Garage
        Get
            Return _Garage
        End Get
        Set(value As Garage)
            _Garage = value
        End Set
    End Property

    Public Property Date_Reparation As DateTime
        Get
            Return _Date_Reparation
        End Get
        Set(value As DateTime)
            _Date_Reparation = value
        End Set
    End Property

    Public Property Date_Sortie As DateTime
        Get
            Return _Date_Sortie
        End Get
        Set(value As DateTime)
            _Date_Sortie = value
        End Set
    End Property

    Public Property Cout_Reparation As Double
        Get
            Return _Cout_Reparation
        End Get
        Set(value As Double)
            _Cout_Reparation = value
        End Set
    End Property

    Public Property Type_Entretien As String
        Get
            Return _Type_Entretien
        End Get
        Set(value As String)
            _Type_Entretien = value
        End Set
    End Property
End Class
