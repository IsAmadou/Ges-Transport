Imports Gestion_transport

Public Class Utilisateurs

    Private _Id_User As Integer
    Private _Nom_User As String
    Private _Prenom_User As String
    Private _Sexe_User As String
    Private _Telephone_User As String
    Private _Email_User As String
    Private _Adresse_User As String
    Private _Login_User As String
    Private _Password_User As String
    Private _Statut_User As String
    Private _Etat_User As String
    Private _Historiques_User As List(Of Historiques_Users)

    Public Sub New(Nom_User As String, Prenom_User As String, Sexe_User As String, Telephone_User As String, Email_User As String,
            Adresse_User As String, Login_User As String, Password_User As String, Statut_User As String, Etat_User As String)

        _Nom_User = Nom_User
        _Prenom_User = Prenom_User
        _Sexe_User = Sexe_User
        _Telephone_User = Telephone_User
        _Email_User = Email_User
        _Adresse_User = Adresse_User
        _Login_User = Login_User
        _Password_User = Password_User
        _Statut_User = Statut_User
        _Etat_User = Etat_User
        _Historiques_User = New List(Of Historiques_Users)
    End Sub

    Public Sub New(Id_User As Integer, Nom_User As String, Prenom_User As String, Sexe_User As String, Telephone_User As String, Email_User As String,
                   Adresse_User As String, Login_User As String, Password_User As String, Statut_User As String, Etat_User As String)
        _Id_User = Id_User
        _Nom_User = Nom_User
        _Prenom_User = Prenom_User
        _Sexe_User = Sexe_User
        _Telephone_User = Telephone_User
        _Email_User = Email_User
        _Adresse_User = Adresse_User
        _Login_User = Login_User
        _Password_User = Password_User
        _Statut_User = Statut_User
        _Etat_User = Etat_User
        _Historiques_User = New List(Of Historiques_Users)
    End Sub

    Public Sub New(Id_User As Integer, Nom_User As String, Prenom_User As String, Sexe_User As String, Telephone_User As String,
             Email_User As String, Adresse_User As String, Login_User As String, Password_User As String,
                   Statut_User As String, Etat_User As String, Historiques_User As List(Of Historiques_Users))

        _Id_User = Id_User
        _Nom_User = Nom_User
        _Prenom_User = Prenom_User
        _Sexe_User = Sexe_User
        _Telephone_User = Telephone_User
        _Email_User = Email_User
        _Adresse_User = Adresse_User
        _Login_User = Login_User
        _Password_User = Password_User
        _Statut_User = Statut_User
        _Etat_User = Etat_User
        _Historiques_User = Historiques_User
    End Sub

    Public Property Id_User As Integer
        Get
            Return _Id_User
        End Get
        Set(value As Integer)
            _Id_User = value
        End Set
    End Property

    Public Property Nom_User As String
        Get
            Return _Nom_User
        End Get
        Set(value As String)
            _Nom_User = value
        End Set
    End Property

    Public Property Prenom_User As String
        Get
            Return _Prenom_User
        End Get
        Set(value As String)
            _Prenom_User = value
        End Set
    End Property

    Public Property Sexe_User As String
        Get
            Return _Sexe_User
        End Get
        Set(value As String)
            _Sexe_User = value
        End Set
    End Property

    Public Property Telephone_User As String
        Get
            Return _Telephone_User
        End Get
        Set(value As String)
            _Telephone_User = value
        End Set
    End Property

    Public Property Email_User As String
        Get
            Return _Email_User
        End Get
        Set(value As String)
            _Email_User = value
        End Set
    End Property

    Public Property Adresse_User As String
        Get
            Return _Adresse_User
        End Get
        Set(value As String)
            _Adresse_User = value
        End Set
    End Property

    Public Property Login_User As String
        Get
            Return _Login_User
        End Get
        Set(value As String)
            _Login_User = value
        End Set
    End Property

    Public Property Password_User As String
        Get
            Return _Password_User
        End Get
        Set(value As String)
            _Password_User = value
        End Set
    End Property

    Public Property Statut_User As String
        Get
            Return _Statut_User
        End Get
        Set(value As String)
            _Statut_User = value
        End Set
    End Property

    Public Property Historiques_User As List(Of Historiques_Users)
        Get
            Return _Historiques_User
        End Get
        Set(value As List(Of Historiques_Users))
            _Historiques_User = value
        End Set
    End Property

    Public Property Etat_User As String
        Get
            Return _Etat_User
        End Get
        Set(value As String)
            _Etat_User = value
        End Set
    End Property
End Class
