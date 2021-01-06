Imports System.Data.SqlClient

Public Class Réparations_VehiculeDao

    Dim con As SqlConnection = ConnectionUtil.getInstance()

    ''' <summary>
    ''' Ajouter un Vehicule au Garage
    ''' </summary>
    ''' <param name="Rep"></param>
    Public Sub AddVehiculeToGarage(Rep As Réparations_Vehicule)
        Try
            Dim cmd As SqlCommand = New SqlCommand("insert into Reparations_Vehicule(Immatriculation,
            Id_visite,Date_Reparation,Date_Sortie ,Cout_Reparation,Type_Entretien) values (@Immatriculation,
            @Id_visite,@Date_Reparation, @Date_Sortie ,@Cout_Reparation,@Type_Entretien) ", con)
            cmd.Parameters.AddWithValue("@Immatriculation", Rep.Vehicule.Immatriculation)
            cmd.Parameters.AddWithValue("@Id_visite", Rep.Garage.Id_Visite)
            cmd.Parameters.AddWithValue("@Date_Reparation", Rep.Date_Reparation)
            cmd.Parameters.AddWithValue("@Date_Sortie", Rep.Date_Sortie)
            cmd.Parameters.AddWithValue("@Cout_Reparation", Rep.Cout_Reparation)
            cmd.Parameters.AddWithValue("@Type_Entretien", Rep.Type_Entretien)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Modifier les Caractéristiques de la visite
    ''' </summary>
    ''' <param name="Rep"></param>
    Public Sub UpdateVehiculeToGarage(Rep As Réparations_Vehicule)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Update Reparations_Vehicule set Immatriculation=@Immatriculation,
            Id_visite=@Id_visite,Date_Reparation=@Date_Reparation,Date_Sortie=@Date_Sortie,Cout_Reparation=@Cout_Reparation,
                          Type_Entretien=@Type_Entretien where Id_Reparation=@Id_Reparation ", con)

            cmd.Parameters.AddWithValue("@Id_Reparation", Rep.Id_Reparation)
            cmd.Parameters.AddWithValue("@Immatriculation", Rep.Vehicule.Immatriculation)
            cmd.Parameters.AddWithValue("@Id_visite", Rep.Garage.Id_Visite)
            cmd.Parameters.AddWithValue("@Date_Reparation", Rep.Date_Reparation)
            cmd.Parameters.AddWithValue("@Date_Sortie", Rep.Date_Sortie)
            cmd.Parameters.AddWithValue("@Cout_Reparation", Rep.Cout_Reparation)
            cmd.Parameters.AddWithValue("@Type_Entretien", Rep.Type_Entretien)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Supprimer une Visite techniques
    ''' </summary>
    ''' <param name="Id_Reparation"></param>
    Public Sub DeleteReparations_Vehicule(Id_Reparation As Integer)
        Try
            Dim cmd As SqlCommand = New SqlCommand("delete from Reparations_Vehicule where Id_Reparation=@Id_Reparation", con)
            cmd.Parameters.AddWithValue("@Id_Reparation", Id_Reparation)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' recurer une reparation par son id
    ''' </summary>
    ''' <param name="Id_Reparation"></param>
    ''' <returns></returns>
    Public Function getReparations_vehiculeById(Id_Reparation As Integer) As Réparations_Vehicule
        Dim _Rep As Réparations_Vehicule
        Dim Vehdao As VehiculesDao = New VehiculesDao
        Dim Gardao As GarageDao = New GarageDao
        Try
            Dim cmd As SqlCommand =
                New SqlCommand("select * from Reparations_Vehicule where Id_Reparation=@Id_Reparation", con)
            cmd.Parameters.AddWithValue("@Id_Reparation", Id_Reparation)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            If rd.Read() Then
                _Rep = New Réparations_Vehicule(rd.GetInt32(0), Vehdao.getVehiculeByImm(rd.GetString(1)), Gardao.getGarageById(rd.GetInt32(2)), rd.GetDateTime(3),
                                                rd.GetDateTime(4), rd.GetFloat(5), rd.GetString(6))
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return _Rep
    End Function

    ''' <summary>
    ''' Remplir le dataGredView
    ''' </summary>
    ''' <returns></returns>
    Public Function getData() As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select Id_Reparation,R.Immatriculation,Nom_Garage,Adresse_Garage,Date_Reparation,
                Date_Sortie,Cout_Reparation,Type_Entretien from Reparations_Vehicule R,Garage G, Vehicules v
                         where R.Id_visite=G.Id_visite and v.Immatriculation=R.Immatriculation", con)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "Reparations_Vehicule")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Immatriculation
    Public Function getDataByImm(Imm As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select Id_Reparation,R.Immatriculation,Nom_Garage,Adresse_Garage,Date_Reparation,
                Date_Sortie,Cout_Reparation,Type_Entretien from Reparations_Vehicule R,Garage G, Vehicules v
                         where R.Id_visite=G.Id_visite and v.Immatriculation=R.Immatriculation and R.Immatriculation like @Imm ", con)
            cmd.Parameters.AddWithValue("@Imm", "%" + Imm + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "Reparations_VehiculeByImm")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nom garage
    Public Function getDataByNom(Nom As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select Id_Reparation,R.Immatriculation,Nom_Garage,Adresse_Garage,Date_Reparation,
                Date_Sortie,Cout_Reparation,Type_Entretien from Reparations_Vehicule R,Garage G, Vehicules v
                         where R.Id_visite=G.Id_visite and v.Immatriculation=R.Immatriculation and Nom_Garage like @Nom ", con)
            cmd.Parameters.AddWithValue("@Nom", "%" + Nom + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "Reparations_VehiculeByNom")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Immatriculation et Nom garage
    Public Function getDataByImm_Nom(Imm As String, Nom As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select Id_Reparation,R.Immatriculation,Nom_Garage,Adresse_Garage,Date_Reparation,
                Date_Sortie,Cout_Reparation,Type_Entretien from Reparations_Vehicule R,Garage G, Vehicules v
                         where R.Id_visite=G.Id_visite and v.Immatriculation=R.Immatriculation and R.Immatriculation like @Imm and Nom_Garage like @Nom ", con)
            cmd.Parameters.AddWithValue("@Imm", "%" + Imm + "%")
            cmd.Parameters.AddWithValue("@Nom", "%" + Nom + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "Reparations_VehiculeByImm&Nom")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function




End Class
