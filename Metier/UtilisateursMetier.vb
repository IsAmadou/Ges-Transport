Public Class UtilisateursMetier

    Dim dao As UtilisateursDao = New UtilisateursDao

    Public Sub AddUser(User As Utilisateurs)
        If Not User.Nom_User.Trim.Equals("") And Not User.Prenom_User.Trim.Equals("") And Not User.Sexe_User.Trim.Equals("") And Not User.Telephone_User.Trim.Equals("") And Not User.Login_User.Trim.Equals("") And Not User.Password_User.Trim.Equals("") And Not User.Statut_User.Trim.Equals("") Then
            If User.Password_User.Trim.Length >= 8 Then
                If User.Email_User.Contains("@") And User.Email_User.Contains(".") Then
                    Try
                        dao.AddUser(User)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                Else
                    Throw New Exception("Email Invalide")
                End If
            Else
                Throw New Exception("Le Mot de passe doit être au moins superieur à 8 caractères")
            End If
        Else
            Throw New Exception("Veuillez remplir les autres champs")
        End If
    End Sub

    Public Sub UpdateUser(User As Utilisateurs)
        If Not User.Nom_User.Trim.Equals("") And Not User.Prenom_User.Trim.Equals("") And Not User.Sexe_User.Trim.Equals("") And Not User.Telephone_User.Trim.Equals("") And Not User.Login_User.Trim.Equals("") And Not User.Password_User.Trim.Equals("") And Not User.Statut_User.Trim.Equals("") Then
            If User.Password_User.Trim.Length >= 8 Then
                If User.Email_User.Contains("@") And User.Email_User.Contains(".") Then
                    Try
                        dao.UpdateUser(User)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                Else
                    Throw New Exception("Email Invalide")
                End If
            Else
                Throw New Exception("Le Mot de passe doit être au moins superieur à 8 caractères")
            End If
        Else
            Throw New Exception("Veuillez remplir les autres champs")
        End If
    End Sub

    Public Sub DeleteUser(Id_User As Integer)
        Try
            dao.DeleteUser(Id_User)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function getUserById(Id_User As Integer) As Utilisateurs
        Try
            Return dao.getUserById(Id_User)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function getAll() As List(Of Utilisateurs)
        Try
            Return dao.getAll()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'deconnecter les utilisateur non connecter
    Public Sub UpdateDecUser(Id_User As Integer)
        Try
            dao.UpdateDecUser(Id_User)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    'deconnecter tous les utilisateur 
    Public Sub UpdateDecallUser()
        Try
            dao.UpdateDecallUser()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    'connecte l'utilisateur
    Public Sub UpdateconUser(Id_User As Integer)
        Try
            dao.UpdateconUser(Id_User)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub


    Public Function getData() As DataSet
        Try
            Return dao.getData()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par Nom
    Public Function getDataByNom(Nom As String) As DataSet
        Try
            Return dao.getDataByNom(Nom)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Prenom
    Public Function getDataByPre(Pre As String) As DataSet
        Try
            Return dao.getDataByPre(Pre)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtre par Nom & Prenom
    Public Function getDataByNon_Pre(Nom As String, Pre As String) As DataSet
        Try
            Return dao.getDataByNon_Pre(Nom, Pre)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Login
    Public Function getDataByLog(Log As String) As DataSet
        Try
            Return dao.getDataByLog(Log)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nom et Login
    Public Function getDataByNon_Log(Nom As String, Log As String) As DataSet
        Try
            Return dao.getDataByNon_Log(Nom, Log)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Prenom et Login
    Public Function getDataByPre_Log(Pre As String, Log As String) As DataSet
        Try
            Return dao.getDataByPre_Log(Pre, Log)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nom, Prenom et Login
    Public Function getDataByNom_Pre_Log(Nom As String, Pre As String, Log As String) As DataSet
        Try
            Return dao.getDataByNom_Pre_Log(Nom, Pre, Log)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function



End Class
