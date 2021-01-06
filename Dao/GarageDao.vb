Imports System.Data.SqlClient

Public Class GarageDao

    Dim con As SqlConnection = ConnectionUtil.getInstance()

    ''' <summary>
    ''' Ajouter un Garage ayant reparer un véhicule
    ''' </summary>
    ''' <param name="Gar"></param>
    Public Sub AddGarage(Gar As Garage)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Insert into Garage (Nom_Garage,Adresse_Garage,Tel_Garage)
             values(@Nom_Garage,@Adresse_Garage,@Tel_Garage)", con)

            cmd.Parameters.AddWithValue("@Nom_Garage", Gar.Nom_Garage)
            cmd.Parameters.AddWithValue("@Adresse_Garage", Gar.Adresse_Garage)
            cmd.Parameters.AddWithValue("@Tel_Garage", Gar.Tel_Garage)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Modifier les Caracteristiques d'un garage
    ''' </summary>
    ''' <param name="Gar"></param>
    Public Sub UpdateGarage(Gar As Garage)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Update Garage set Nom_Garage=@Nom_Garage,
              Adresse_Garage=@Adresse_Garage,Tel_Garage=@Tel_Garage where Id_visite=@Id_visite", con)

            cmd.Parameters.AddWithValue("@Id_visite", Gar.Id_Visite)
            cmd.Parameters.AddWithValue("@Nom_Garage", Gar.Nom_Garage)
            cmd.Parameters.AddWithValue("@Adresse_Garage", Gar.Adresse_Garage)
            cmd.Parameters.AddWithValue("@Tel_Garage", Gar.Tel_Garage)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Recuperer un Garage par son Id
    ''' </summary>
    ''' <param name="Id_visite"></param>
    ''' <returns></returns>
    Public Function getGarageById(Id_visite As Integer) As Garage
        Dim _Gar As Garage
        Try
            Dim cmd As SqlCommand =
                New SqlCommand("select * from Garage where Id_visite=@Id_visite", con)
            cmd.Parameters.AddWithValue("@Id_visite", Id_visite)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            If rd.Read() Then
                _Gar = New Garage(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetString(3))
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return _Gar
    End Function

    'recuperer tous les trajet
    Public Function getData() As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select *from Garage ", con)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "Garage")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtre par nom
    Public Function getDataByNom(Nom As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select *from Garage where Nom_Garage like @Nom ", con)
            cmd.Parameters.AddWithValue("@Nom", "%" + Nom + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "GarageByNom")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtre par Adresse
    Public Function getDataByAdr(Adr As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select *from Garage where Adresse_Garage like @Adr ", con)
            cmd.Parameters.AddWithValue("@Adr", "%" + Adr + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "GarageByAdr")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtre par nom et Adresse
    Public Function getDataByNom_Adr(Nom As String, Adr As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select *from Garage where Nom_Garage like @Nom and Adresse_Garage like @Adr ", con)
            cmd.Parameters.AddWithValue("@Nom", "%" + Nom + "%")
            cmd.Parameters.AddWithValue("@Adr", "%" + Adr + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "GarageByNom&Adr")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
