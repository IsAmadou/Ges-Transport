Imports System.Data.SqlClient

Public Class ChauffeursDao
    Dim con As SqlConnection = ConnectionUtil.getInstance()

    ''' <summary>
    ''' Ajouter un Chauffeur
    ''' </summary>
    ''' <param name="Chauf"></param>
    Public Sub AddChauffeurs(Chauf As Chauffeurs)
        Try
            Dim cmd As SqlCommand = New SqlCommand("insert into Chauffeurs (Type_Vehicule_Conduit,Nom_Chauffeur,Prenom_Chauffeur,Sexe_Chauffeur,
                    Email_Chauffeur,Adresse_Chauffeur,Date_Naissance,Telephone_Chauffeur,Etat_Chauffeur) values (@Type_Vehicule_Conduit,@Nom_Chauffeur,
             @Prenom_Chauffeur,@Sexe,@Email_Chauffeur,@Adresse_Chauffeur,@Date_Naissance,@Telephone,@Etat_Chauffeur)", con)

            cmd.Parameters.AddWithValue("@Type_Vehicule_Conduit", Chauf.Type_Vehicule_Conduit)
            cmd.Parameters.AddWithValue("@Nom_Chauffeur", Chauf.Nom_Chauffeur)
            cmd.Parameters.AddWithValue("@Prenom_Chauffeur", Chauf.Prenom_Chauffeur)
            cmd.Parameters.AddWithValue("@Sexe", Chauf.Sexe)
            cmd.Parameters.AddWithValue("@Email_Chauffeur", Chauf.Email_chauffeur)
            cmd.Parameters.AddWithValue("@Adresse_Chauffeur", Chauf.Adresse_chauffeur)
            cmd.Parameters.AddWithValue("@Date_Naissance", Chauf.Date_naiss)
            cmd.Parameters.AddWithValue("@Telephone", Chauf.Tel_Chauffeur)
            cmd.Parameters.AddWithValue("@Etat_Chauffeur", Chauf.Etat_Chauffeur)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Modifier les caracteristiques d'un Chauffeur
    ''' </summary>
    ''' <param name="Chauf"></param>
    Public Sub UpdateChauffeurs(Chauf As Chauffeurs)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Update Chauffeurs set Type_Vehicule_Conduit=@Type_Vehicule_Conduit,
         Nom_Chauffeur=@Nom_Chauffeur,Prenom_Chauffeur=@Prenom_Chauffeur,Sexe_Chauffeur=@Sexe,Email_Chauffeur=@Email_Chauffeur,
          Adresse_Chauffeur=@Adresse_Chauffeur,Date_Naissance=@Date_Naissance,Telephone_Chauffeur=@Telephone,Etat_Chauffeur=@Etat_Chauffeur
                      where Id_Chauffeur=@Id_Chauffeur", con)

            cmd.Parameters.AddWithValue("@Id_Chauffeur", Chauf.Id_Chauffeur)
            cmd.Parameters.AddWithValue("@Type_Vehicule_Conduit", Chauf.Type_Vehicule_Conduit)
            cmd.Parameters.AddWithValue("@Nom_Chauffeur", Chauf.Nom_Chauffeur)
            cmd.Parameters.AddWithValue("@Prenom_Chauffeur", Chauf.Prenom_Chauffeur)
            cmd.Parameters.AddWithValue("@Sexe", Chauf.Sexe)
            cmd.Parameters.AddWithValue("@Email_Chauffeur", Chauf.Email_chauffeur)
            cmd.Parameters.AddWithValue("@Adresse_Chauffeur", Chauf.Adresse_chauffeur)
            cmd.Parameters.AddWithValue("@Date_Naissance", Chauf.Date_naiss)
            cmd.Parameters.AddWithValue("@Telephone", Chauf.Tel_Chauffeur)
            cmd.Parameters.AddWithValue("@Etat_Chauffeur", Chauf.Etat_Chauffeur)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Supprimer un chauffeur
    ''' </summary>
    ''' <param name="Id_Chauffeur"></param>
    Public Sub DeleteChauffeurs(Id_Chauffeur As Integer)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Delete from Chauffeurs where Id_Chauffeur=@Id_Chauffeur", con)
            cmd.Parameters.AddWithValue("@Id_Chauffeur", Id_Chauffeur)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Recuperer un Chauffeur par son Id
    ''' </summary>
    ''' <param name="Id_Chauffeur"></param>
    ''' <returns></returns>
    Public Function getChauffeurById(Id_Chauffeur As Integer) As Chauffeurs
        Dim _Chauf As Chauffeurs
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select * from Chauffeurs where Id_Chauffeur=@Id_Chauffeur", con)
            cmd.Parameters.AddWithValue("@Id_Chauffeur", Id_Chauffeur)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            If rd.Read() Then
                _Chauf = New Chauffeurs(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetString(3),
                                  rd.GetString(4), rd.GetString(5), rd.GetString(6), rd.GetDateTime(7), rd.GetString(8), rd.GetString(9))
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return _Chauf
    End Function

    ''' <summary>
    '''  Recuperer tous les chauffeurs
    ''' </summary>
    ''' <returns></returns>
    Public Function getAll() As List(Of Chauffeurs)
        Dim _Chauf As List(Of Chauffeurs) = New List(Of Chauffeurs)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select * from Chauffeurs", con)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While rd.Read()
                _Chauf.Add(New Chauffeurs(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetString(3),
                                  rd.GetString(4), rd.GetString(5), rd.GetString(6), rd.GetDateTime(7), rd.GetString(8), rd.GetString(9)))
            End While
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return _Chauf
    End Function

    ''' <summary>
    ''' Remplir le dataGredView
    ''' </summary>
    ''' <returns></returns>
    Public Function getData() As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Chauffeurs", con)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "Chauffeur")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par Nom
    Public Function getDataByNom(Nom As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Chauffeurs where Nom_Chauffeur like @Nom ", con)
            cmd.Parameters.AddWithValue("@Nom", "%" + Nom + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "ChauffeurByNom")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Prenom
    Public Function getDataByPre(Pre As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Chauffeurs where Prenom_Chauffeur like @Pre", con)
            cmd.Parameters.AddWithValue("@Pre", "%" + Pre + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "ChauffeurByPre")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtre par Nom & Prenom
    Public Function getDataByNon_Pre(Nom As String, Pre As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Chauffeurs where Nom_Chauffeur like @Nom and Prenom_Chauffeur like @Pre", con)
            cmd.Parameters.AddWithValue("@Nom", "%" + Nom + "%")
            cmd.Parameters.AddWithValue("@Pre", "%" + Pre + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "ChauffeurByNom&Pre")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Etat
    Public Function getDataByEta(Eta As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Chauffeurs where Etat_Chauffeur like @Eta", con)
            cmd.Parameters.AddWithValue("@Eta", Eta(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "ChauffeurByEta")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nom et Etat 
    Public Function getDataByNon_Eta(Nom As String, Eta As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Chauffeurs where Nom_Chauffeur like @Nom and Etat_Chauffeur like @Eta", con)
            cmd.Parameters.AddWithValue("@Nom", "%" + Nom + "%")
            cmd.Parameters.AddWithValue("@Eta", Eta(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "ChauffeurByNom&Eta")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Prenom et Etat 
    Public Function getDataByPre_Eta(Pre As String, Eta As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Chauffeurs where Prenom_Chauffeur like @Pre and Etat_Chauffeur like @Eta", con)
            cmd.Parameters.AddWithValue("@Pre", "%" + Pre + "%")
            cmd.Parameters.AddWithValue("@Eta", Eta(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "ChauffeurByPre&Eta")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nom, Prenom et Etat 
    Public Function getDataByNom_Pre_Eta(Nom As String, Pre As String, Eta As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Chauffeurs where Nom_Chauffeur like @Nom and
                       Prenom_Chauffeur like @Pre and Etat_Chauffeur like @Eta", con)
            cmd.Parameters.AddWithValue("@Nom", "%" + Nom + "%")
            cmd.Parameters.AddWithValue("@Pre", "%" + Pre + "%")
            cmd.Parameters.AddWithValue("@Eta", Eta(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "ChauffeurByNom&Pre&Eta")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par type de vehicule conduit
    Public Function getDataByTyp(Typ As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Chauffeurs where Type_Vehicule_Conduit like @Typ", con)
            cmd.Parameters.AddWithValue("@Typ", "%" + Typ + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "ChauffeurByTyp")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par nom et type de vehicule conduit
    Public Function getDataByNon_Typ(Nom As String, Typ As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Chauffeurs where Nom_Chauffeur like @Nom and Type_Vehicule_Conduit like @Typ", con)
            cmd.Parameters.AddWithValue("@Nom", "%" + Nom + "%")
            cmd.Parameters.AddWithValue("@Typ", "%" + Typ + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "ChauffeurByNom&Typ")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par prenom et type de vehicule conduit
    Public Function getDataByPre_Typ(Pre As String, Typ As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Chauffeurs where Prenom_Chauffeur like @Pre and Type_Vehicule_Conduit like @Typ", con)
            cmd.Parameters.AddWithValue("@Pre", "%" + Pre + "%")
            cmd.Parameters.AddWithValue("@Typ", "%" + Typ + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "ChauffeurByPre&Typ")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par etat et type de vehicule conduit
    Public Function getDataByEta_Typ(Eta As String, Typ As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Chauffeurs where Etat_Chauffeur like @Eta and Type_Vehicule_Conduit like @Typ", con)
            cmd.Parameters.AddWithValue("@Eta", Eta(0) + "%")
            cmd.Parameters.AddWithValue("@Typ", "%" + Typ + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "ChauffeurByEta&Typ")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par nom, prenom et type de vehicule conduit
    Public Function getDataByNom_Pre_Typ(Nom As String, Pre As String, Typ As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Chauffeurs where Nom_Chauffeur like @Nom and
                       Prenom_Chauffeur like @Pre and Type_Vehicule_Conduit like @Typ", con)
            cmd.Parameters.AddWithValue("@Nom", "%" + Nom + "%")
            cmd.Parameters.AddWithValue("@Pre", "%" + Pre + "%")
            cmd.Parameters.AddWithValue("@Typ", "%" + Typ + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "ChauffeurByNom&Pre&Typ")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par nom,etat et type de vehicule conduit
    Public Function getDataByNom_Eta_Typ(Nom As String, Eta As String, Typ As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Chauffeurs where Nom_Chauffeur like @Nom
                           and Etat_Chauffeur like @Eta and Type_Vehicule_Conduit like @Typ", con)
            cmd.Parameters.AddWithValue("@Nom", "%" + Nom + "%")
            cmd.Parameters.AddWithValue("@Eta", Eta(0) + "%")
            cmd.Parameters.AddWithValue("@Typ", "%" + Typ + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "ChauffeurByNom&Eta&Typ")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par prenom,etat et type de vehicule conduit
    Public Function getDataByPre_Eta_Typ(Pre As String, Eta As String, Typ As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Chauffeurs where Prenom_Chauffeur like @Pre
                      and Etat_Chauffeur like @Eta and Type_Vehicule_Conduit like @Typ", con)
            cmd.Parameters.AddWithValue("@Pre", "%" + Pre + "%")
            cmd.Parameters.AddWithValue("@Eta", Eta(0) + "%")
            cmd.Parameters.AddWithValue("@Typ", "%" + Typ + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "ChauffeurByPre&Eta&Typ")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par nom ,prenom, etat et type de vehicule conduit
    Public Function getDataByNom_Pre_Eta_Typ(Nom As String, Pre As String, Eta As String, Typ As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Chauffeurs where Nom_Chauffeur like @Nom and
                Prenom_Chauffeur like @Pre and Etat_Chauffeur like @Eta and Type_Vehicule_Conduit like @Typ", con)
            cmd.Parameters.AddWithValue("@Nom", "%" + Nom + "%")
            cmd.Parameters.AddWithValue("@Pre", "%" + Pre + "%")
            cmd.Parameters.AddWithValue("@Eta", Eta(0) + "%")
            cmd.Parameters.AddWithValue("@Typ", "%" + Typ + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "ChauffeurByNom&Pre&Eta&Typ")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
