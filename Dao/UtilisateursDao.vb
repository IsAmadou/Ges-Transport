Imports System.Data.SqlClient

Public Class UtilisateursDao

    Dim con As SqlConnection = ConnectionUtil.getInstance()

    ''' <summary>
    ''' Ajouter un utilisateur
    ''' </summary>
    ''' <param name="User"></param>
    Public Sub AddUser(User As Utilisateurs)
        Try
            Dim cmd As SqlCommand = New SqlCommand("insert into Utilisateurs (Nom_User,Prenom_User,Sexe_User,Telephone_User,Email_User,
            Adresse_User,Login_User,Password_User,Statut,Etat_User) values (@Nom_User,@Prenom_User,@Sexe_User,@Telephone_User,@Email_User,
            @Adresse_User,@Login_User,@Password_User,@Statut_User,@Etat_User)", con)

            cmd.Parameters.AddWithValue("@Nom_User", User.Nom_User)
            cmd.Parameters.AddWithValue("@Prenom_User", User.Prenom_User)
            cmd.Parameters.AddWithValue("@Telephone_User", User.Telephone_User)
            cmd.Parameters.AddWithValue("@Sexe_User", User.Sexe_User)
            cmd.Parameters.AddWithValue("@Email_User", User.Email_User)
            cmd.Parameters.AddWithValue("@Adresse_User", User.Adresse_User)
            cmd.Parameters.AddWithValue("@Login_User", User.Login_User)
            cmd.Parameters.AddWithValue("@Password_User", User.Password_User)
            cmd.Parameters.AddWithValue("@Statut_User", User.Statut_User)
            cmd.Parameters.AddWithValue("@Etat_User", User.Etat_User)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Modifier les Caracteristiques d'un Utilisateur 
    ''' </summary>
    ''' <param name="User"></param>
    Public Sub UpdateUser(User As Utilisateurs)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Update Utilisateurs set Nom_User=@Nom_User,Prenom_User=@Prenom_User,Sexe_User=@Sexe_User,
             Telephone_User=@Telephone_User,Email_User=@Email_User,Adresse_User=@Adresse_User,Login_User=@Login_User,
                      Password_User=@Password_User,Statut=@Statut_User,Etat_User=@Etat_User where Id_User=@Id_User", con)

            cmd.Parameters.AddWithValue("@Id_User", User.Id_User)
            cmd.Parameters.AddWithValue("@Nom_User", User.Nom_User)
            cmd.Parameters.AddWithValue("@Prenom_User", User.Prenom_User)
            cmd.Parameters.AddWithValue("@Sexe_User", User.Sexe_User)
            cmd.Parameters.AddWithValue("@Telephone_User", User.Telephone_User)
            cmd.Parameters.AddWithValue("@Email_User", User.Email_User)
            cmd.Parameters.AddWithValue("@Adresse_User", User.Adresse_User)
            cmd.Parameters.AddWithValue("@Login_User", User.Login_User)
            cmd.Parameters.AddWithValue("@Password_User", User.Password_User)
            cmd.Parameters.AddWithValue("@Statut_User", User.Statut_User)
            cmd.Parameters.AddWithValue("@Etat_User", User.Etat_User)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Supprimer un Utilisateur
    ''' </summary>
    ''' <param name="Id_User"></param>
    Public Sub DeleteUser(Id_User As Integer)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Delete from Utilisateurs where Id_User=@Id_User", con)
            cmd.Parameters.AddWithValue("@Id_User", Id_User)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    'deconnecter les utilisateur non connecter
    Public Sub UpdateDecUser(Id_User As Integer)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Update Utilisateurs set Etat_User='Deconnecter' where Id_User <> @Id_User", con)
            cmd.Parameters.AddWithValue("@Id_User", Id_User)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    'deconnecter tous les utilisateur 
    Public Sub UpdateDecallUser()
        Try
            Dim cmd As SqlCommand = New SqlCommand("Update Utilisateurs set Etat_User='Deconnecter'", con)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    'connecte l'utilisateur
    Public Sub UpdateconUser(Id_User As Integer)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Update Utilisateurs set Etat_User='Connecter' where Id_User = @Id_User", con)
            cmd.Parameters.AddWithValue("@Id_User", Id_User)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub


    ''' <summary>
    ''' Recuperer un utilisateur par son Id
    ''' </summary>
    ''' <param name="Id_User"></param>
    ''' <returns></returns>
    Public Function getUserById(Id_User As Integer) As Utilisateurs
        Dim _User As Utilisateurs
        Try
            Dim cmd As SqlCommand =
                New SqlCommand("select * from Utilisateurs where Id_User=@Id_User", con)
            cmd.Parameters.AddWithValue("@Id_User", Id_User)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            If rd.Read() Then
                _User = New Utilisateurs(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(4),
                                   rd.GetString(5), rd.GetString(6), rd.GetString(7), rd.GetString(8), rd.GetString(9), rd.GetString(10))
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return _User
    End Function

    ''' <summary>
    ''' Recuperer la liste de tous les utilisateus
    ''' </summary>
    ''' <returns></returns>
    Public Function getAll() As List(Of Utilisateurs)
        Dim _listUser As List(Of Utilisateurs) = New List(Of Utilisateurs)
        Try
            Dim cmd As SqlCommand =
                New SqlCommand("select * from Utilisateurs", con)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While rd.Read()
                _listUser.Add(New Utilisateurs(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(4),
                                   rd.GetString(5), rd.GetString(6), rd.GetString(7), rd.GetString(8), rd.GetString(9), rd.GetString(10)))
            End While
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return _listUser
    End Function

    ''' <summary>
    ''' Remplir le dataGredView
    ''' </summary>
    ''' <returns></returns>
    Public Function getData() As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Utilisateurs", con)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "Utilisateurs")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par Nom
    Public Function getDataByNom(Nom As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Utilisateurs where Nom_User like @Nom ", con)
            cmd.Parameters.AddWithValue("@Nom", "%" + Nom + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "UtilisateursByNom")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Prenom
    Public Function getDataByPre(Pre As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Utilisateurs where Prenom_User like @Pre", con)
            cmd.Parameters.AddWithValue("@Pre", "%" + Pre + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "UtilisateursByPre")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtre par Nom & Prenom
    Public Function getDataByNon_Pre(Nom As String, Pre As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Utilisateurs where Nom_User like @Nom and Prenom_User like @Pre", con)
            cmd.Parameters.AddWithValue("@Nom", "%" + Nom + "%")
            cmd.Parameters.AddWithValue("@Pre", "%" + Pre + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "UtilisateursByNom&Pre")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Login
    Public Function getDataByLog(Log As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Utilisateurs where Login_User like @Log", con)
            cmd.Parameters.AddWithValue("@Log", Log(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "UtilisateursByLog")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nom et Login
    Public Function getDataByNon_Log(Nom As String, Log As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Utilisateurs where Nom_User like @Nom and Login_User like @Log", con)
            cmd.Parameters.AddWithValue("@Nom", "%" + Nom + "%")
            cmd.Parameters.AddWithValue("@Log", Log(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "UtilisateursByNom&Log")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Prenom et Login
    Public Function getDataByPre_Log(Pre As String, Log As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Utilisateurs where Prenom_User like @Pre and Login_User like @Log", con)
            cmd.Parameters.AddWithValue("@Pre", "%" + Pre + "%")
            cmd.Parameters.AddWithValue("@Log", Log(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "UtilisateursByPre&Log")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nom, Prenom et Login
    Public Function getDataByNom_Pre_Log(Nom As String, Pre As String, Log As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Utilisateurs where Nom_User like @Nom and
                       Prenom_User like @Pre and Login_User like @Log", con)
            cmd.Parameters.AddWithValue("@Nom", "%" + Nom + "%")
            cmd.Parameters.AddWithValue("@Pre", "%" + Pre + "%")
            cmd.Parameters.AddWithValue("@Log", Log(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "UtilisateursByNom&Pre&Log")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
