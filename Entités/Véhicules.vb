Imports Gestion_transport

Public Class Véhicules


    Private _Immatriculation As String
    Private _Type As String
    Private _Modèle As String
    Private _Nchâssis As String
    Private _Type_de_Moteur As String
    Private _Capacité As Double
    Private _Etat_Véhicule As String
    Private _Pieces As List(Of Pièces_Vehicule)

    Public Sub New1(Immatriculation As String, Type As String, Modèle As String, Nchâssis As String,
                   Type_de_Moteur As String, Capacité As Double, Etat_Véhicule As String)
        _Immatriculation = Immatriculation
        _Type = Type
        _Modèle = Modèle
        _Nchâssis = Nchâssis
        _Type_de_Moteur = Type_de_Moteur
        _Capacité = Capacité
        _Etat_Véhicule = Etat_Véhicule
        _Pieces = New List(Of Pièces_Vehicule)
    End Sub

    Public Sub New(Immatriculation As String, Type As String, Modèle As String, Nchâssis As String,
                   Type_de_Moteur As String, Capacité As Double, Etat_Véhicule As String)
        _Immatriculation = Immatriculation
        _Type = Type
        _Modèle = Modèle
        _Nchâssis = Nchâssis
        _Type_de_Moteur = Type_de_Moteur
        _Capacité = Capacité
        _Etat_Véhicule = Etat_Véhicule
    End Sub

    Public Sub New(Immatriculation As String, Type As String, Modèle As String, Nchâssis As String,
     Type_de_Moteur As String, Capacité As Double, Etat_Véhicule As String, Pieces As List(Of Pièces_Vehicule))
        _Immatriculation = Immatriculation
        _Type = Type
        _Modèle = Modèle
        _Nchâssis = Nchâssis
        _Type_de_Moteur = Type_de_Moteur
        _Capacité = Capacité
        _Etat_Véhicule = Etat_Véhicule
        _Pieces = Pieces
    End Sub

    Public Property Pieces() As List(Of Pièces_Vehicule)
        Get
            Return _Pieces
        End Get
        Set(ByVal value As List(Of Pièces_Vehicule))
            _Pieces = value
        End Set
    End Property

    Public Property Immatriculation() As String
        Get
            Return _Immatriculation
        End Get
        Set(ByVal value As String)
            _Immatriculation = value
        End Set
    End Property

    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
        End Set
    End Property

    Public Property Modèle() As String
        Get
            Return _Modèle
        End Get
        Set(ByVal value As String)
            _Modèle = value
        End Set
    End Property

    Public Property Nchâssis() As String
        Get
            Return _Nchâssis
        End Get
        Set(ByVal value As String)
            _Nchâssis = value
        End Set
    End Property

    Public Property Type_de_Moteur() As String
        Get
            Return _Type_de_Moteur
        End Get
        Set(ByVal value As String)
            _Type_de_Moteur = value
        End Set
    End Property

    Public Property Capacité() As Double
        Get
            Return _Capacité
        End Get
        Set(ByVal value As Double)
            _Capacité = value
        End Set
    End Property

    Public Property Etat_Véhicule() As String
        Get
            Return _Etat_Véhicule
        End Get
        Set(ByVal value As String)
            _Etat_Véhicule = value
        End Set
    End Property

End Class
