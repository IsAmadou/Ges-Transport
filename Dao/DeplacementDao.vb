Imports System.Data.SqlClient

Public Class DeplacementDao
    Dim con As SqlConnection = ConnectionUtil.getInstance()

    ''' <summary>
    ''' Ajouter un Deplacement
    ''' </summary>
    ''' <param name="Dep"></param>
    Public Sub AddDeplacement(Dep As Deplacement)
        Try
            Dim cmd As SqlCommand = New SqlCommand("insert into Deplacement (Ref_trajet,Immatriculation,Id_Marchandise,
     Date_Départ,Date_Arriver, Heure_Depart,Heure_Arriver,Quantité_Dep) values (@Ref_trajet,@Immatriculation,
          @Id_Marchandise,@Date_Départ,@Date_Arriver,@Heure_Depart,@Heure_Arriver,@Quantite_Dep) ", con)

            cmd.Parameters.AddWithValue("@Ref_trajet", Dep.Trajets.Ref)
            cmd.Parameters.AddWithValue("@Immatriculation", Dep.Vehicules.Immatriculation)
            cmd.Parameters.AddWithValue("@Id_Marchandise", Dep.Marchandises.Id_Marchandises)
            cmd.Parameters.AddWithValue("@Date_Départ", Dep.Date_Départ)
            cmd.Parameters.AddWithValue("@Date_Arriver", Dep.Date_Arrivée)
            cmd.Parameters.AddWithValue("@Heure_Depart", Dep.Heure_Départ)
            cmd.Parameters.AddWithValue("@Heure_Arriver", Dep.Heure_Arrivée)
            cmd.Parameters.AddWithValue("@Quantite_Dep", Dep.Quantité_Déplacée)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Modifier les Carateristiques d'un deplacement
    ''' </summary>
    ''' <param name="Dep"></param>
    Public Sub UpdateDeplacement(Dep As Deplacement)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Update Deplacement set Ref_trajet=@Ref_trajet,Immatriculation=@Immatriculation,
          Id_Marchandise=@Id_Marchandise,Date_Départ=@Date_Départ,Date_Arriver=@Date_Arriver, 
               Heure_Depart=@Heure_Depart,Heure_Arriver=@Heure_Arriver,Quantite_Dep=@Quantité_Dep where 
                          Id_Deplacement=@Id_Deplacement", con)

            cmd.Parameters.AddWithValue("@Id_Deplacement", Dep.Id_Déplacement)
            cmd.Parameters.AddWithValue("@Ref_trajet", Dep.Trajets.Ref)
            cmd.Parameters.AddWithValue("@Immatriculation", Dep.Vehicules.Immatriculation)
            cmd.Parameters.AddWithValue("@Id_Marchandise", Dep.Marchandises.Id_Marchandises)
            cmd.Parameters.AddWithValue("@Date_Départ", Dep.Date_Départ)
            cmd.Parameters.AddWithValue("@Date_Arriver", Dep.Date_Arrivée)
            cmd.Parameters.AddWithValue("@Heure_Depart", Dep.Heure_Départ)
            cmd.Parameters.AddWithValue("@Heure_Arriver", Dep.Heure_Arrivée)
            cmd.Parameters.AddWithValue("@Quantite_Dep", Dep.Quantité_Déplacée)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Supprimer un deplacement
    ''' </summary>
    ''' <param name="Id_Deplacement"></param>
    Public Sub DeleteDeplacement(Id_Deplacement As Integer)
        Try
            Dim cmd As SqlCommand = New SqlCommand("delete from Deplacement where Id_Deplacement=@Id_Deplacement", con)
            cmd.Parameters.AddWithValue("@Id_Deplacement", Id_Deplacement)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' recuperer un eplacement par son Id
    ''' </summary>
    ''' <returns></returns>
    Public Function getDaplacementById(Id_Deplacement As Integer) As Deplacement
        Dim _dep As Deplacement
        Dim Tradao As TrajetDao = New TrajetDao
        Dim vehdao As VehiculesDao = New VehiculesDao
        Dim mardao As MarchandisesDao = New MarchandisesDao
        Try
            Dim cmd As SqlCommand =
                New SqlCommand("select * from Deplacement where Id_Deplacement=@Id_Deplacement", con)
            cmd.Parameters.AddWithValue("@Id_Deplacement", Id_Deplacement)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            If rd.Read() Then
                _dep = New Deplacement(rd.GetInt32(0), Tradao.getTrajetByRef(rd.GetString(1)), vehdao.getVehiculeByImm(rd.GetString(2)), mardao.getMarchandisesById(rd.GetInt32(3)),
                                       rd.GetDateTime(4), rd.GetDateTime(5), rd.GetDateTime(6), rd.GetDateTime(7), rd.GetInt32(8))
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return _dep
    End Function

    'recuperer tous les trajet
    Public Function getData() As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("SELECT Id_Deplacement,d.Immatriculation,Type_Vehicule,Modele_Vehicule,Nom_Chauffeur,Prenom_Chauffeur,Ref_trajet,Position_Depart,Position_Arriver,
                  Libelle,Nature,Quantite,Date_Affectation as 'Date de depart',Date_finAffectation as 'Date arrivée',Heure_Depart,Heure_Arriver 
             from Deplacement d, Vehicules v,Trajet t,Chauffeurs ch,Affecter_Chauffeurs af,Marchandises m where d.Immatriculation =v.Immatriculation
                    and d.Ref_trajet=t.Ref and d.Id_Marchandise =m.Id_Marchandise and af.Id_Chauffeur =ch.Id_Chauffeur ", con)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "Deplacement")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer trajet par immatriculation
    Public Function getDataByImm(Imm As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("SELECT Id_Deplacement,d.Immatriculation,Type_Vehicule,Modele_Vehicule,Nom_Chauffeur,Prenom_Chauffeur,Ref_trajet,Position_Depart,Position_Arriver,
                  Libelle,Nature,Quantite,Date_Affectation as 'Date de depart',Date_finAffectation as 'Date arrivée',Heure_Depart,Heure_Arriver 
             from Deplacement d, Vehicules v,Trajet t,Chauffeurs ch,Affecter_Chauffeurs af,Marchandises m where d.Immatriculation =v.Immatriculation
                    and d.Ref_trajet=t.Ref and d.Id_Marchandise =m.Id_Marchandise and af.Id_Chauffeur =ch.Id_Chauffeur and d.Immatriculation like @Imm", con)
            cmd.Parameters.AddWithValue("@Imm", "%" + Imm + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "DeplacementByImm")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nom chauffeur
    Public Function getDataByNom(Nom As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("SELECT Id_Deplacement,d.Immatriculation,Type_Vehicule,Modele_Vehicule,Nom_Chauffeur,Prenom_Chauffeur,Ref_trajet,Position_Depart,Position_Arriver,
                  Libelle,Nature,Quantite,Date_Affectation as 'Date de depart',Date_finAffectation as 'Date arrivée',Heure_Depart,Heure_Arriver 
             from Deplacement d, Vehicules v,Trajet t,Chauffeurs ch,Affecter_Chauffeurs af,Marchandises m where d.Immatriculation =v.Immatriculation
                    and d.Ref_trajet=t.Ref and d.Id_Marchandise =m.Id_Marchandise and af.Id_Chauffeur =ch.Id_Chauffeur  and Nom_Chauffeur like @Nom ", con)
            cmd.Parameters.AddWithValue("@Nom", "%" + Nom + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "DeplacementByNom")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Prenom chauffeur
    Public Function getDataByPre(Pre As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("SELECT Id_Deplacement,d.Immatriculation,Type_Vehicule,Modele_Vehicule,Nom_Chauffeur,Prenom_Chauffeur,Ref_trajet,Position_Depart,Position_Arriver,
                  Libelle,Nature,Quantite,Date_Affectation as 'Date de depart',Date_finAffectation as 'Date arrivée',Heure_Depart,Heure_Arriver 
             from Deplacement d, Vehicules v,Trajet t,Chauffeurs ch,Affecter_Chauffeurs af,Marchandises m where d.Immatriculation =v.Immatriculation
                    and d.Ref_trajet=t.Ref and d.Id_Marchandise =m.Id_Marchandise and af.Id_Chauffeur =ch.Id_Chauffeur and Prenom_Chauffeur like @Pre ", con)
            cmd.Parameters.AddWithValue("@Pre", "%" + Pre + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "DeplacementByPre")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par libelle marchandises
    Public Function getDataByLib(Libe As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("SELECT Id_Deplacement,d.Immatriculation,Type_Vehicule,Modele_Vehicule,Nom_Chauffeur,Prenom_Chauffeur,Ref_trajet,Position_Depart,Position_Arriver,
                  Libelle,Nature,Quantite,Date_Affectation as 'Date de depart',Date_finAffectation as 'Date arrivée',Heure_Depart,Heure_Arriver 
             from Deplacement d, Vehicules v,Trajet t,Chauffeurs ch,Affecter_Chauffeurs af,Marchandises m where d.Immatriculation =v.Immatriculation
                    and d.Ref_trajet=t.Ref and d.Id_Marchandise =m.Id_Marchandise and af.Id_Chauffeur =ch.Id_Chauffeur and  Libelle like @Libe ", con)
            cmd.Parameters.AddWithValue("@Libe", "%" + Libe + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "DeplacementByLibe")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Date deplacement
    Public Function getDataByDat(DateDep As DateTime) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("SELECT Id_Deplacement,d.Immatriculation,Type_Vehicule,Modele_Vehicule,Nom_Chauffeur,Prenom_Chauffeur,Ref_trajet,Position_Depart,Position_Arriver,
                  Libelle,Nature,Quantite,Date_Affectation as 'Date de depart',Date_finAffectation as 'Date arrivée',Heure_Depart,Heure_Arriver 
             from Deplacement d, Vehicules v,Trajet t,Chauffeurs ch,Affecter_Chauffeurs af,Marchandises m where d.Immatriculation =v.Immatriculation
                    and d.Ref_trajet=t.Ref and d.Id_Marchandise =m.Id_Marchandise and af.Id_Chauffeur =ch.Id_Chauffeur and Date_Affectation=@DateDep ", con)
            cmd.Parameters.AddWithValue("@DateDep", DateDep)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "DeplacementByDat")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    '''' <summary>
    '''' Recuperer la list de vehicule ayant parcourue un trajet
    '''' </summary>
    '''' <param name="Ref"></param>
    '''' <returns></returns>
    'Public Function getVehiculeByTrajet(Ref As String) As List(Of Véhicules)
    '    Dim Vehdao As VehiculesDao = New VehiculesDao()
    '    Dim listVeh As List(Of Véhicules) = New List(Of Véhicules)
    '    Try
    '        Dim cmd As SqlCommand = New SqlCommand("select distinct (Immatriculation) from Deplacement where Ref=@Ref", con)
    '        cmd.Parameters.AddWithValue("@Ref", Ref)
    '        Dim rd As SqlDataReader = cmd.ExecuteReader()
    '        While (rd.Read())
    '            listVeh.Add(Vehdao.getVehiculeByImm(rd.GetString(0)))
    '        End While
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    '    Return listVeh
    'End Function

    '''' <summary>
    '''' Recuperer la liste de tous les Trajets parcourue par un Vehicule
    '''' </summary>
    '''' <param name="Immatriculation"></param>
    '''' <returns></returns>
    'Public Function getTrajetByVehicule(Immatriculation As String) As List(Of Trajet)
    '    Dim Trajdao As TrajetDao = New TrajetDao()
    '    Dim listTraj As List(Of Trajet) = New List(Of Trajet)
    '    Try
    '        Dim cmd As SqlCommand = New SqlCommand("select distinct (Ref) from Deplacement where Immatriculation=@Immatriculation", con)
    '        cmd.Parameters.AddWithValue("@Immatriculation", Immatriculation)
    '        Dim rd As SqlDataReader = cmd.ExecuteReader()
    '        While (rd.Read())
    '            listTraj.Add(Trajdao.getTrajetByRef(rd.GetString(0)))
    '        End While
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    '    Return listTraj
    'End Function

    '''' <summary>
    '''' Recuperer la liste de toutes les Marchandises ayant parcourue un trajet
    '''' </summary>
    '''' <param name="Ref"></param>
    '''' <returns></returns>
    'Public Function getMarchandisesByTrajet(Ref As String) As List(Of Marchandises)
    '    Dim Mardao As MarchandisesDao = New MarchandisesDao()
    '    Dim listMar As List(Of Marchandises) = New List(Of Marchandises)
    '    Try
    '        Dim cmd As SqlCommand = New SqlCommand("select distinct (Id_Marchandises) from Deplacement where Ref=@Ref", con)
    '        cmd.Parameters.AddWithValue("@Ref", Ref)
    '        Dim rd As SqlDataReader = cmd.ExecuteReader()
    '        While (rd.Read())
    '            listMar.Add(Mardao.getMarchandisesById(rd.GetInt32(0)))
    '        End While
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    '    Return listMar
    'End Function

    '''' <summary>
    '''' Recuperer la liste des vehicules ayant deplacés une marchandise
    '''' </summary>
    '''' <param name="Id_Marchandises"></param>
    '''' <returns></returns>
    'Public Function getVehiculeByMarchandises(Id_Marchandises As Integer) As List(Of Véhicules)
    '    Dim Vehdao As VehiculesDao = New VehiculesDao()
    '    Dim listVeh As List(Of Véhicules) = New List(Of Véhicules)
    '    Try
    '        Dim cmd As SqlCommand = New SqlCommand("select distinct (Immatriculation) from Deplacement where 
    '                       Id_Marchandises=@Id_Marchandises", con)
    '        cmd.Parameters.AddWithValue("@Id_Marchandises", Id_Marchandises)
    '        Dim rd As SqlDataReader = cmd.ExecuteReader()
    '        While (rd.Read())
    '            listVeh.Add(Vehdao.getVehiculeByImm(rd.GetString(0)))
    '        End While
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    '    Return listVeh
    'End Function

    '''' <summary>
    '''' Recuperer la liste de toutes les Marchandises deplacées par un véhicule
    '''' </summary>
    '''' <param name="Immatriculation"></param>
    '''' <returns></returns>
    'Public Function getMarchandisesByVehicule(Immatriculation As String) As List(Of Marchandises)
    '    Dim Mardao As MarchandisesDao = New MarchandisesDao()
    '    Dim listMar As List(Of Marchandises) = New List(Of Marchandises)
    '    Try
    '        Dim cmd As SqlCommand = New SqlCommand("select distinct (Id_Marchandises) from Deplacement where Immatriculation=@Immatriculation", con)
    '        cmd.Parameters.AddWithValue("@Immatriculation", Immatriculation)
    '        Dim rd As SqlDataReader = cmd.ExecuteReader()
    '        While (rd.Read())
    '            listMar.Add(Mardao.getMarchandisesById(rd.GetInt32(0)))
    '        End While
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    '    Return listMar
    'End Function



    'Public Function getMarchandisesByVehicule(Immatriculation As String) As List(Of Deplacement)
    '    Dim Vehdao As VehiculesDao = New VehiculesDao()
    '    Dim Trajdao As TrajetDao = New TrajetDao()
    '    Dim Mardao As MarchandisesDao = New MarchandisesDao()
    '    Dim Presdao As PrestationsDao = New PrestationsDao()
    '    Dim _Veh As Véhicules = Vehdao.getVehiculeByImm(Immatriculation)
    '    Dim listMar As List(Of Deplacement) = New List(Of Deplacement)
    '    Try
    '        Dim cmd As SqlCommand = New SqlCommand("select * from Deplacement where Immatriculation=@Immatriculation", con)
    '        cmd.Parameters.AddWithValue("@Immatriculation", Immatriculation)
    '        Dim rd As SqlDataReader = cmd.ExecuteReader()
    '        While (rd.Read())
    '            listMar.Add(New Deplacement(rd.GetInt32(0), Trajdao.getTrajetByRef(rd.GetString(1)), _Veh,
    '         Mardao.getMarchandisesById(rd.GetInt32(3)), Presdao.getPrestationsById(rd.GetInt32(4)), rd.GetDateTime(5),
    '                          rd.GetDateTime(6), rd.GetDateTime(7), rd.GetDateTime(8), rd.GetInt32(9)))
    '        End While
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    '    Return listMar
    'End Function

End Class
