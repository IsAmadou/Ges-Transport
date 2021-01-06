Public Class Chauffeurs

    Private _Id_Chauffeur As Integer
    Private _Type_Vehicule_Conduit As String
    Private _Nom_Chauffeur As String
    Private _Prenom_Chauffeur As String
    Private _sexe As String
    Private _Email_chauffeur As String
    Private _Adresse_chauffeur As String
    Private _Date_naiss As DateTime
    Private _Tel_Chauffeur As String
    Private _Etat_Chauffeur As String

    Public Sub New(Type_Vehicule_Conduit As String, Nom_Chauffeur As String, Prenom_Chauffeur As String, sexe As String,
    Email_chauffeur As String, Adresse_chauffeur As String, Date_naiss As Date, Tel_Chauffeur As String, Etat_Chauffeur As String)
        _Type_Vehicule_Conduit = Type_Vehicule_Conduit
        _Nom_Chauffeur = Nom_Chauffeur
        _Prenom_Chauffeur = Prenom_Chauffeur
        _sexe = sexe
        _Email_chauffeur = Email_chauffeur
        _Adresse_chauffeur = Adresse_chauffeur
        _Date_naiss = Date_naiss
        _Tel_Chauffeur = Tel_Chauffeur
        _Etat_Chauffeur = Etat_Chauffeur
    End Sub

    Public Sub New(Id_Chauffeur As Integer, Type_Vehicule_Conduit As String, Nom_Chauffeur As String, Prenom_Chauffeur As String, sexe As String,
                   Email_chauffeur As String, Adresse_chauffeur As String, Date_naiss As Date, Tel_Chauffeur As String, Etat_Chauffeur As String)
        _Id_Chauffeur = Id_Chauffeur
        _Type_Vehicule_Conduit = Type_Vehicule_Conduit
        _Nom_Chauffeur = Nom_Chauffeur
        _Prenom_Chauffeur = Prenom_Chauffeur
        _sexe = sexe
        _Email_chauffeur = Email_chauffeur
        _Adresse_chauffeur = Adresse_chauffeur
        _Date_naiss = Date_naiss
        _Tel_Chauffeur = Tel_Chauffeur
        _Etat_Chauffeur = Etat_Chauffeur
    End Sub

    Public Property Id_Chauffeur As Integer
        Get
            Return _Id_Chauffeur
        End Get
        Set(value As Integer)
            _Id_Chauffeur = value
        End Set
    End Property

    Public Property Type_Vehicule_Conduit As String
        Get
            Return _Type_Vehicule_Conduit
        End Get
        Set(value As String)
            _Type_Vehicule_Conduit = value
        End Set
    End Property

    Public Property Nom_Chauffeur As String
        Get
            Return _Nom_Chauffeur
        End Get
        Set(value As String)
            _Nom_Chauffeur = value
        End Set
    End Property

    Public Property Prenom_Chauffeur As String
        Get
            Return _Prenom_Chauffeur
        End Get
        Set(value As String)
            _Prenom_Chauffeur = value
        End Set
    End Property

    Public Property Sexe As String
        Get
            Return _sexe
        End Get
        Set(value As String)
            _sexe = value
        End Set
    End Property

    Public Property Email_chauffeur As String
        Get
            Return _Email_chauffeur
        End Get
        Set(value As String)
            _Email_chauffeur = value
        End Set
    End Property

    Public Property Adresse_chauffeur As String
        Get
            Return _Adresse_chauffeur
        End Get
        Set(value As String)
            _Adresse_chauffeur = value
        End Set
    End Property

    Public Property Date_naiss As Date
        Get
            Return _Date_naiss
        End Get
        Set(value As Date)
            _Date_naiss = value
        End Set
    End Property

    Public Property Tel_Chauffeur As String
        Get
            Return _Tel_Chauffeur
        End Get
        Set(value As String)
            _Tel_Chauffeur = value
        End Set
    End Property

    Public Property Etat_Chauffeur As String
        Get
            Return _Etat_Chauffeur
        End Get
        Set(value As String)
            _Etat_Chauffeur = value
        End Set
    End Property
End Class
