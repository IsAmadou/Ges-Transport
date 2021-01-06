Public Class Marchandises

    Private _Id_Marchandises As Integer
    Private _Libelle As String
    Private _Nature As String
    Private _Valeur As Double
    Private _Poids As Double
    Private _Quantite As Integer
    Private _Etat As String
    Private _Documents As String
    Private _Date_Enregistrement As DateTime
    Private _Statut As String

    Public Sub New(Libelle As String, Nature As String, Valeur As Double, Poids As Double, Quantite As Integer,
                   Etat As String, Documents As String, Date_Enregistrement As DateTime, Statut As String)
        _Libelle = Libelle
        _Nature = Nature
        _Valeur = Valeur
        _Poids = Poids
        _Quantite = Quantite
        _Etat = Etat
        _Documents = Documents
        _Date_Enregistrement = Date_Enregistrement
        _Statut = Statut
    End Sub

    Public Sub New(Id_Marchandises As Integer, Libelle As String, Nature As String, Valeur As Double, Poids As Double, Quantite As Integer,
                   Etat As String, Documents As String, Date_Enregistrement As DateTime, Statut As String)
        _Id_Marchandises = Id_Marchandises
        _Libelle = Libelle
        _Nature = Nature
        _Valeur = Valeur
        _Poids = Poids
        _Quantite = Quantite
        _Etat = Etat
        _Documents = Documents
        _Date_Enregistrement = Date_Enregistrement
        _Statut = Statut
    End Sub

    Public Property Id_Marchandises As Integer
        Get
            Return _Id_Marchandises
        End Get
        Set(value As Integer)
            _Id_Marchandises = value
        End Set
    End Property

    Public Property Libelle As String
        Get
            Return _Libelle
        End Get
        Set(value As String)
            _Libelle = value
        End Set
    End Property

    Public Property Nature As String
        Get
            Return _Nature
        End Get
        Set(value As String)
            _Nature = value
        End Set
    End Property

    Public Property Valeur As Double
        Get
            Return _Valeur
        End Get
        Set(value As Double)
            _Valeur = value
        End Set
    End Property

    Public Property Poids As Double
        Get
            Return _Poids
        End Get
        Set(value As Double)
            _Poids = value
        End Set
    End Property

    Public Property Quantite As Integer
        Get
            Return _Quantite
        End Get
        Set(value As Integer)
            _Quantite = value
        End Set
    End Property

    Public Property Etat As String
        Get
            Return _Etat
        End Get
        Set(value As String)
            _Etat = value
        End Set
    End Property

    Public Property Documents As String
        Get
            Return _Documents
        End Get
        Set(value As String)
            _Documents = value
        End Set
    End Property

    Public Property Date_Enregistrement As DateTime
        Get
            Return _Date_Enregistrement
        End Get
        Set(value As DateTime)
            _Date_Enregistrement = value
        End Set
    End Property

    Public Property Statut As String
        Get
            Return _Statut
        End Get
        Set(value As String)
            _Statut = value
        End Set
    End Property
End Class
