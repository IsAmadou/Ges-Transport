Imports System.Data.SqlClient

Public Class VehiculesDao

    Dim con As SqlConnection = ConnectionUtil.getInstance()

    ''' <summary>
    ''' ajouter un vehicule
    ''' </summary>
    ''' <param name="Veh"></param>
    Public Sub AddVehicules(Veh As Véhicules)
        Try
            Dim cmd As SqlCommand = New SqlCommand("insert into Vehicules (Immatriculation,Type_Vehicule,Modele_Vehicule,N_Chassis,Type_Moteur,Capacite,Etat_Vehicule)
               values (@Immatriculation,@Type,@Modele,@NChassis,@Type_Moteur,@Capacite,@Etat_Vehicule)", con)
            cmd.Parameters.AddWithValue("@Immatriculation", Veh.Immatriculation)
            cmd.Parameters.AddWithValue("@Type", Veh.Type)
            cmd.Parameters.AddWithValue("@Modele", Veh.Modèle)
            cmd.Parameters.AddWithValue("@NChassis", Veh.Nchâssis)
            cmd.Parameters.AddWithValue("@Type_Moteur", Veh.Type_de_Moteur)
            cmd.Parameters.AddWithValue("@Capacite", Veh.Capacité)
            cmd.Parameters.AddWithValue("@Etat_Vehicule", Veh.Etat_Véhicule)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub


    ''' <summary>
    ''' modifier les carractéristiques d'un vehicule
    ''' </summary>
    ''' <param name="Veh"></param>
    Public Sub UpdateVehicules(Veh As Véhicules)
        Try
            Dim cmd As SqlCommand = New SqlCommand("update Vehicules set Immatriculation=@Immatriculation,
                Type_Vehicule=@Type,Modele_Vehicule=@Modele,N_Chassis=@NChassis,Type_Moteur=@Type_Moteur,
                  Capacite=@Capacite,Etat_Vehicule=@Etat_Vehicule where Immatriculation=@Immatriculation", con)

            cmd.Parameters.AddWithValue("@Immatriculation", Veh.Immatriculation)
            cmd.Parameters.AddWithValue("@Type", Veh.Type)
            cmd.Parameters.AddWithValue("@Modele", Veh.Modèle)
            cmd.Parameters.AddWithValue("@NChassis", Veh.Nchâssis)
            cmd.Parameters.AddWithValue("@Type_Moteur", Veh.Type_de_Moteur)
            cmd.Parameters.AddWithValue("@Capacite", Veh.Capacité)
            cmd.Parameters.AddWithValue("@Etat_Vehicule", Veh.Etat_Véhicule)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' supprimer un vehicule
    ''' </summary>
    ''' <param name="Immatriculation"></param>
    Public Sub DeleteVehicules(Immatriculation As String)
        Try
            Dim cmd As SqlCommand = New SqlCommand("delete from Vehicules where Immatriculation=@Immatriculation ", con)
            cmd.Parameters.AddWithValue("@Immatriculation", Immatriculation)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' recuperer un vehicule par son immatriculation
    ''' </summary>
    ''' <param name="Immatriculation"></param>
    ''' <returns></returns>
    Public Function getVehiculeByImm(Immatriculation As String) As Véhicules
        Dim _Vehi As Véhicules
        Try
            Dim cmd As SqlCommand =
                New SqlCommand("select * from Vehicules where Immatriculation=@Immatriculation", con)
            cmd.Parameters.AddWithValue("@Immatriculation", Immatriculation)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            If rd.Read() Then
                _Vehi = New Véhicules(rd.GetString(0), rd.GetString(1), rd.GetString(2),
                                      rd.GetString(3), rd.GetString(4), rd.GetFloat(5), rd.GetString(6))
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return _Vehi
    End Function

    ''' <summary>
    ''' recuperer tous les vehicules
    ''' </summary>
    ''' <returns></returns>
    Public Function getAll() As List(Of Véhicules)
        Dim _Veh As List(Of Véhicules) = New List(Of Véhicules)
        Try
            Dim cmd As SqlCommand =
                New SqlCommand("select * from Vehicules ", con)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While rd.Read()
                _Veh.Add(New Véhicules(rd.GetString(0), rd.GetString(1), rd.GetString(2),
                     rd.GetString(3), rd.GetString(4), rd.GetFloat(5), rd.GetString(6)))
            End While
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return _Veh
    End Function

    'charger le data 
    Public Function getData() As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select v.immatriculation ,Type_Vehicule,Modele_Vehicule,N_Chassis,Type_Moteur,Capacite,
              Etat_Vehicule,Id_Pieces,Carte_Grise,Vignete,Date_ExpVignete,Assurance,date_ExpAssurance from Pieces_Vehicule p ,vehicules v
                    where p.Immatriculation = v.Immatriculation", con)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "Vehicules")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par Immatriculation
    Public Function getDataByImm(Imm As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select v.immatriculation ,Type_Vehicule,Modele_Vehicule,N_Chassis,Type_Moteur,Capacite,
              Etat_Vehicule,Id_Pieces,Carte_Grise,Vignete,Date_ExpVignete,Assurance,date_ExpAssurance from Pieces_Vehicule p ,vehicules v
                    where p.Immatriculation = v.Immatriculation and p.Immatriculation like @Imm", con)
            cmd.Parameters.AddWithValue("@Imm", "%" + Imm + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "VehiculesByImm")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Type_Vehicule
    Public Function getDataByTypVeh(TypVeh As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select v.immatriculation ,Type_Vehicule,Modele_Vehicule,N_Chassis,Type_Moteur,Capacite,
              Etat_Vehicule,Id_Pieces,Carte_Grise,Vignete,Date_ExpVignete,Assurance,date_ExpAssurance from Pieces_Vehicule p ,vehicules v
                    where p.Immatriculation = v.Immatriculation and Type_Vehicule like @TypVeh", con)
            cmd.Parameters.AddWithValue("@TypVeh", "%" + TypVeh + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "VehiculesByTypVeh")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtre par Immatriculation & Type_Vehicule
    Public Function getDataByImm_TypVeh(Imm As String, TypVeh As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select v.immatriculation ,Type_Vehicule,Modele_Vehicule,N_Chassis,Type_Moteur,Capacite,
              Etat_Vehicule,Id_Pieces,Carte_Grise,Vignete,Date_ExpVignete,Assurance,date_ExpAssurance from Pieces_Vehicule p ,vehicules v
                    where p.Immatriculation = v.Immatriculation and p.Immatriculation like @Imm and Type_Vehicule like @TypVeh", con)
            cmd.Parameters.AddWithValue("@Imm", "%" + Imm + "%")
            cmd.Parameters.AddWithValue("@TypVeh", "%" + TypVeh + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "VehiculesByImm&TypVeh")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Etat
    Public Function getDataByEta(Eta As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select v.immatriculation ,Type_Vehicule,Modele_Vehicule,N_Chassis,Type_Moteur,Capacite,
              Etat_Vehicule,Id_Pieces,Carte_Grise,Vignete,Date_ExpVignete,Assurance,date_ExpAssurance from Pieces_Vehicule p ,vehicules v
                    where p.Immatriculation = v.Immatriculation and Etat_Vehicule like @Eta", con)
            cmd.Parameters.AddWithValue("@Eta", Eta(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "VehiculesByEta")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Immatriculation et Etat 
    Public Function getDataByImm_Eta(Imm As String, Eta As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select v.immatriculation ,Type_Vehicule,Modele_Vehicule,N_Chassis,Type_Moteur,Capacite,
              Etat_Vehicule,Id_Pieces,Carte_Grise,Vignete,Date_ExpVignete,Assurance,date_ExpAssurance from Pieces_Vehicule p ,vehicules v
                    where p.Immatriculation = v.Immatriculation and p.Immatriculation like @Imm and Etat_Vehicule like @Eta", con)
            cmd.Parameters.AddWithValue("@Imm", "%" + Imm + "%")
            cmd.Parameters.AddWithValue("@Eta", Eta(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "VehiculesByImm&Eta")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Type_Vehicule et Etat 
    Public Function getDataByTypVeh_Eta(TypVeh As String, Eta As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select v.immatriculation ,Type_Vehicule,Modele_Vehicule,N_Chassis,Type_Moteur,Capacite,
              Etat_Vehicule,Id_Pieces,Carte_Grise,Vignete,Date_ExpVignete,Assurance,date_ExpAssurance from Pieces_Vehicule p ,vehicules v
                    where p.Immatriculation = v.Immatriculation and Type_Vehicule like @TypVeh and Etat_Vehicule like @Eta", con)
            cmd.Parameters.AddWithValue("@TypVeh", "%" + TypVeh + "%")
            cmd.Parameters.AddWithValue("@Eta", Eta(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "VehiculesByTypVeh&Eta")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Immatriculation, Type_Vehicule et Etat 
    Public Function getDataByImm_TypVeh_Eta(Imm As String, TypVeh As String, Eta As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select v.immatriculation ,Type_Vehicule,Modele_Vehicule,N_Chassis,Type_Moteur,Capacite,
              Etat_Vehicule,Id_Pieces,Carte_Grise,Vignete,Date_ExpVignete,Assurance,date_ExpAssurance from Pieces_Vehicule p ,vehicules v
                    where p.Immatriculation = v.Immatriculation and p.Immatriculation like @Imm and Type_Vehicule like @TypVeh 
                                 and Etat_Vehicule like @Eta", con)
            cmd.Parameters.AddWithValue("@Imm", "%" + Imm + "%")
            cmd.Parameters.AddWithValue("@TypVeh", "%" + TypVeh + "%")
            cmd.Parameters.AddWithValue("@Eta", Eta(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "VehiculesByImm&TypVeh&Eta")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par Capacité
    Public Function getDataByCap(Cap As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select v.immatriculation ,Type_Vehicule,Modele_Vehicule,N_Chassis,Type_Moteur,Capacite,
              Etat_Vehicule,Id_Pieces,Carte_Grise,Vignete,Date_ExpVignete,Assurance,date_ExpAssurance from Pieces_Vehicule p ,vehicules v
                    where p.Immatriculation = v.Immatriculation and Capacite >= @Cap", con)
            cmd.Parameters.AddWithValue("@Cap", Cap)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "VehiculesByCap")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Immatriculation et Capacite
    Public Function getDataByImm_Cap(Imm As String, Cap As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select v.immatriculation ,Type_Vehicule,Modele_Vehicule,N_Chassis,Type_Moteur,Capacite,
              Etat_Vehicule,Id_Pieces,Carte_Grise,Vignete,Date_ExpVignete,Assurance,date_ExpAssurance from Pieces_Vehicule p ,vehicules v
                    where p.Immatriculation = v.Immatriculation and p.Immatriculation like @Imm and Capacite >= @Cap", con)
            cmd.Parameters.AddWithValue("@Imm", "%" + Imm + "%")
            cmd.Parameters.AddWithValue("@Cap", Cap)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "VehiculesByImm&Cap")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Type_Vehicule et Capacite
    Public Function getDataByTypVeh_Cap(TypVeh As String, Cap As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select v.immatriculation ,Type_Vehicule,Modele_Vehicule,N_Chassis,Type_Moteur,Capacite,
              Etat_Vehicule,Id_Pieces,Carte_Grise,Vignete,Date_ExpVignete,Assurance,date_ExpAssurance from Pieces_Vehicule p ,vehicules v
                    where p.Immatriculation = v.Immatriculation and Type_Vehicule like @TypVeh and Capacite >= @Cap", con)
            cmd.Parameters.AddWithValue("@TypVeh", "%" + TypVeh + "%")
            cmd.Parameters.AddWithValue("@Cap", Cap)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "VehiculesByTypVeh&Cap")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par etat et Capacite
    Public Function getDataByEta_Cap(Eta As String, Cap As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select v.immatriculation ,Type_Vehicule,Modele_Vehicule,N_Chassis,Type_Moteur,Capacite,
              Etat_Vehicule,Id_Pieces,Carte_Grise,Vignete,Date_ExpVignete,Assurance,date_ExpAssurance from Pieces_Vehicule p ,vehicules v
                    where p.Immatriculation = v.Immatriculation and Etat_Vehicule like @Eta and Capacite >= @Cap", con)
            cmd.Parameters.AddWithValue("@Eta", Eta(0) + "%")
            cmd.Parameters.AddWithValue("@Cap", Cap)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "VehiculesByEta&Cap")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Immatriculation, Type_Vehicule et Capacite
    Public Function getDataByImm_TypVeh_Cap(Imm As String, TypVeh As String, Cap As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select v.immatriculation ,Type_Vehicule,Modele_Vehicule,N_Chassis,Type_Moteur,Capacite,
              Etat_Vehicule,Id_Pieces,Carte_Grise,Vignete,Date_ExpVignete,Assurance,date_ExpAssurance from Pieces_Vehicule p ,vehicules v
                    where p.Immatriculation = v.Immatriculation and p.Immatriculation like @Imm and
                      Type_Vehicule like @TypVeh and Capacite >= @Cap", con)
            cmd.Parameters.AddWithValue("@Imm", "%" + Imm + "%")
            cmd.Parameters.AddWithValue("@TypVeh", "%" + TypVeh + "%")
            cmd.Parameters.AddWithValue("@Cap", Cap)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "VehiculesByImm&TypVeh&Cap")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Immatriculation,etat et Capacite
    Public Function getDataByImm_Eta_Cap(Imm As String, Eta As String, Cap As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select v.immatriculation ,Type_Vehicule,Modele_Vehicule,N_Chassis,Type_Moteur,Capacite,
              Etat_Vehicule,Id_Pieces,Carte_Grise,Vignete,Date_ExpVignete,Assurance,date_ExpAssurance from Pieces_Vehicule p ,vehicules v
                    where p.Immatriculation = v.Immatriculation and p.Immatriculation like @Imm
                           and Etat_Vehicule like @Eta and Capacite >= @Cap", con)
            cmd.Parameters.AddWithValue("@Imm", "%" + Imm + "%")
            cmd.Parameters.AddWithValue("@Eta", Eta(0) + "%")
            cmd.Parameters.AddWithValue("@Cap", Cap)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "VehiculesByImm&Eta&Cap")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Type_Vehicule,etat et Capacite
    Public Function getDataByTypVeh_Eta_Cap(TypVeh As String, Eta As String, Cap As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select v.immatriculation ,Type_Vehicule,Modele_Vehicule,N_Chassis,Type_Moteur,Capacite,
              Etat_Vehicule,Id_Pieces,Carte_Grise,Vignete,Date_ExpVignete,Assurance,date_ExpAssurance from Pieces_Vehicule p ,vehicules v
                    where p.Immatriculation = v.Immatriculation and Type_Vehicule like @TypVeh
                      and Etat_Vehicule like @Eta and Capacite >= @Cap", con)
            cmd.Parameters.AddWithValue("@TypVeh", "%" + TypVeh + "%")
            cmd.Parameters.AddWithValue("@Eta", Eta(0) + "%")
            cmd.Parameters.AddWithValue("@Cap", Cap)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "VehiculesByTypVeh&Eta&Cap")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Immatriculation, Type_Vehicule,etat et Capacite
    Public Function getDataByImm_TypVeh_Eta_Cap(Imm As String, TypVeh As String, Eta As String, Cap As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select v.immatriculation ,Type_Vehicule,Modele_Vehicule,N_Chassis,Type_Moteur,Capacite,
              Etat_Vehicule,Id_Pieces,Carte_Grise,Vignete,Date_ExpVignete,Assurance,date_ExpAssurance from Pieces_Vehicule p ,vehicules v
                    where p.Immatriculation = v.Immatriculation and p.Immatriculation like @Imm and Type_Vehicule like @TypVeh
                      and Etat_Vehicule like @Eta and Capacite >= @Cap", con)
            cmd.Parameters.AddWithValue("@Imm", "%" + Imm + "%")
            cmd.Parameters.AddWithValue("@TypVeh", "%" + TypVeh + "%")
            cmd.Parameters.AddWithValue("@Eta", Eta(0) + "%")
            cmd.Parameters.AddWithValue("@Cap", Cap)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "VehiculesByImm&TypVeh&Eta&Cap")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function


End Class
