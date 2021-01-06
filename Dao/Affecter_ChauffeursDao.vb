Imports System.Data.SqlClient

Public Class Affecter_ChauffeursDao
    Dim con As SqlConnection = ConnectionUtil.getInstance()

    ''' <summary>
    ''' Affecter un chauffeur à un Vehicule
    ''' </summary>
    ''' <param name="Aff"></param>
    Public Sub AddChauffeurToVehicule(Aff As Affecter_Chauffeurs)
        Try
            Dim cmd As SqlCommand = New SqlCommand("insert into Affecter_Chauffeurs (Id_Chauffeur,Immatriculation,
            Date_Affectation,Date_FinAffectation) values (@Id_Chauffeur,@Immatriculation,@Date_Affectation,
                                  @Date_FinAffectation) ", con)
            cmd.Parameters.AddWithValue("@Id_Chauffeur", Aff.Chauffeur.Id_Chauffeur)
            cmd.Parameters.AddWithValue("@Immatriculation", Aff.Vehicule.Immatriculation)
            cmd.Parameters.AddWithValue("@Date_Affectation", Aff.Date_Affectation)
            cmd.Parameters.AddWithValue("@Date_FinAffectation", Aff.Date_FinAffectation)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' modifier les caracteristiques de l'affectation du chauffeur au véhicule
    ''' </summary>
    ''' <param name="Aff"></param>
    Public Sub UpdateChauffeurToVehicule(Aff As Affecter_Chauffeurs)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Update Affecter_Chauffeurs set Id_Chauffeur=@Id_Chauffeur,
     Immatriculation=@Immatriculation,Date_Affectation=@Date_Affectation,Date_FinAffectation=@Date_FinAffectation
                        where Id_Affectation=@Id_Affectation", con)

            cmd.Parameters.AddWithValue("@Id_Affectation", Aff.Id_Affectation)
            cmd.Parameters.AddWithValue("@Id_Chauffeur", Aff.Chauffeur.Id_Chauffeur)
            cmd.Parameters.AddWithValue("@Immatriculation", Aff.Vehicule.Immatriculation)
            cmd.Parameters.AddWithValue("@Date_Affectation", Aff.Date_Affectation)
            cmd.Parameters.AddWithValue("@Date_FinAffectation", Aff.Date_FinAffectation)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Supprimer l'affectation d'un chauffeur à un vehicule
    ''' </summary>
    ''' <param name="Id_Affectation"></param>
    Public Sub DeleteChauffeurToVehicule(Id_Affectation As Integer)
        Try
            Dim cmd As SqlCommand = New SqlCommand("delete from Affecter_Chauffeurs where Id_Affectation=@Id_Affectation", con)
            cmd.Parameters.AddWithValue("@Id_Affectation", Id_Affectation)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Recuperer une affectation par son id
    ''' </summary>
    ''' <param name="Id_Affectation"></param>
    ''' <returns></returns>
    Public Function getAffectation_ChauffeurById(Id_Affectation As Integer) As Affecter_Chauffeurs
        Dim _Aff As Affecter_Chauffeurs
        Dim chaufdao As ChauffeursDao = New ChauffeursDao
        Dim vehdao As VehiculesDao = New VehiculesDao
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select * from Affecter_Chauffeurs where Id_Affectation=@Id_Affectation", con)
            cmd.Parameters.AddWithValue("@Id_Affectation", Id_Affectation)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            If rd.Read() Then
                _Aff = New Affecter_Chauffeurs(rd.GetInt32(0), chaufdao.getChauffeurById(rd.GetInt32(1)),
                      vehdao.getVehiculeByImm(rd.GetString(2)), rd.GetDateTime(3), rd.GetDateTime(4))
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return _Aff
    End Function

    ''' <summary>
    ''' Recuperer la liste des chauffeurs ayant conduit un vehicule
    ''' </summary>
    ''' <param name="Immatriculation"></param>
    ''' <returns></returns>
    Public Function getChauffeurByVehicule(Immatriculation As String) As List(Of Affecter_Chauffeurs)
        Dim Vehdao As VehiculesDao = New VehiculesDao()
        Dim Chaufdao As ChauffeursDao = New ChauffeursDao()
        Dim _Veh As Véhicules = Vehdao.getVehiculeByImm(Immatriculation)
        Dim listChauf As List(Of Affecter_Chauffeurs) = New List(Of Affecter_Chauffeurs)
        Try
            Dim cmd As SqlCommand = New SqlCommand("select* from Affecter_Chauffeurs where Immatriculation=@Immatriculation", con)
            cmd.Parameters.AddWithValue("@Immatriculation", Immatriculation)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While (rd.Read())
                listChauf.Add(New Affecter_Chauffeurs(rd.GetInt32(0), Chaufdao.getChauffeurById(rd.GetInt32(1)), _Veh,
                                                      rd.GetDateTime(3), rd.GetDateTime(4)))
            End While
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return listChauf
    End Function

    ''' <summary>
    ''' Recuperer la listes des vehicules ayant été conduis par un chauffeur
    ''' </summary>
    ''' <param name="Id_Chauffeur"></param>
    ''' <returns></returns>
    Public Function getVehiculeByChauffeur(Id_Chauffeur As Integer) As List(Of Affecter_Chauffeurs)
        Dim Vehdao As VehiculesDao = New VehiculesDao()
        Dim Chaufdao As ChauffeursDao = New ChauffeursDao()
        Dim _Chauf As Chauffeurs = Chaufdao.getChauffeurById(Id_Chauffeur)
        Dim listVeh As List(Of Affecter_Chauffeurs) = New List(Of Affecter_Chauffeurs)
        Try
            Dim cmd As SqlCommand = New SqlCommand("select* from Affecter_Chauffeurs where Id_Chauffeur=@Id_Chauffeur", con)
            cmd.Parameters.AddWithValue("@Id_Chauffeur", Id_Chauffeur)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While (rd.Read())
                listVeh.Add(New Affecter_Chauffeurs(rd.GetInt32(0), _Chauf, Vehdao.getVehiculeByImm(rd.GetString(2)),
                                                      rd.GetDateTime(3), rd.GetDateTime(4)))
            End While
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return listVeh
    End Function

    ''' <summary>
    ''' Recuperer l'historique de toutes les Affectations
    ''' </summary>
    ''' <returns></returns>
    Public Function getAll() As List(Of Affecter_Chauffeurs)
        Dim _listAffec As List(Of Affecter_Chauffeurs) = New List(Of Affecter_Chauffeurs)
        Dim chaufdao As ChauffeursDao = New ChauffeursDao
        Dim vehdao As VehiculesDao = New VehiculesDao
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select * from Affecter_Chauffeurs", con)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While rd.Read()
                _listAffec.Add(New Affecter_Chauffeurs(rd.GetInt32(0), chaufdao.getChauffeurById(rd.GetInt32(1)),
                      vehdao.getVehiculeByImm(rd.GetString(2)), rd.GetDateTime(3), rd.GetDateTime(4)))
            End While
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return _listAffec
    End Function

End Class
