Imports Gestion_transport

Public Class Historiques_Users


    Private _Id_Historique As Integer
    Private _Utilisateur As Utilisateurs
    Private _Type_Operation As String
    Private _Date_Operation As DateTime
    Private _Ref_Operation As String

    Public Sub New(Utilisateur As Utilisateurs, Type_Operation As String, Date_Operation As DateTime, Ref_Operation As String)
        _Utilisateur = Utilisateur
        _Type_Operation = Type_Operation
        _Date_Operation = Date_Operation
        _Ref_Operation = Ref_Operation
    End Sub

    Public Sub New(Id_Historique As Integer, Utilisateur As Utilisateurs, Type_Operation As String, Date_Operation As DateTime, Ref_Operation As String)
        _Utilisateur = Utilisateur
        _Id_Historique = Id_Historique
        _Type_Operation = Type_Operation
        _Date_Operation = Date_Operation
        _Ref_Operation = Ref_Operation
    End Sub

    Public Property Utilisateur As Utilisateurs
        Get
            Return _Utilisateur
        End Get
        Set(value As Utilisateurs)
            _Utilisateur = value
        End Set
    End Property

    Public Property Id_Historique As Integer
        Get
            Return _Id_Historique
        End Get
        Set(value As Integer)
            _Id_Historique = value
        End Set
    End Property

    Public Property Type_Operation As String
        Get
            Return _Type_Operation
        End Get
        Set(value As String)
            _Type_Operation = value
        End Set
    End Property

    Public Property Date_Operation As DateTime
        Get
            Return _Date_Operation
        End Get
        Set(value As DateTime)
            _Date_Operation = value
        End Set
    End Property

    Public Property Ref_Operation As String
        Get
            Return _Ref_Operation
        End Get
        Set(value As String)
            _Ref_Operation = value
        End Set
    End Property
End Class
