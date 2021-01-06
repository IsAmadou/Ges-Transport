Public Class VéhiculesMetier

    Dim dao As VehiculesDao = New VehiculesDao

    Public Sub AddVehicules(Veh As Véhicules)
        If Not Veh.Immatriculation.Trim.Equals("") And Not Veh.Modèle.Trim.Equals("") And Not Veh.Capacité.Equals("") And Not Veh.Type_de_Moteur.Trim.Equals("") And Not Veh.Etat_Véhicule.Trim.Equals("") Then
            If Veh.Nchâssis.Trim.Length = 17 Then
                Try
                    dao.AddVehicules(Veh)
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            Else
                Throw New Exception("Le numéro de châssis doit avoir 17 caractères")
            End If
        Else
            Throw New Exception(" Veuillez remplir tous les champs ")
        End If

    End Sub

    Public Sub UpdateVehicules(Veh As Véhicules)
        If Not Veh.Immatriculation.Trim.Equals("") And Not Veh.Modèle.Trim.Equals("") And Not Veh.Capacité.Equals("") And Not Veh.Type_de_Moteur.Trim.Equals("") And Not Veh.Etat_Véhicule.Trim.Equals("") Then
            If Veh.Nchâssis.Trim.Length = 17 Then
                Try
                    dao.UpdateVehicules(Veh)
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            Else
                Throw New Exception("Le numéro de châssis doit avoir 17 caractères")
            End If
        Else
            Throw New Exception("Veuillez remplir les champs obligatoires")
        End If
    End Sub

    Public Sub DeleteVehicules(Immatriculation As String)
        Try
            dao.DeleteVehicules(Immatriculation)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function getVehiculeByImm(Immatriculation As String) As Véhicules
        Try
            Return dao.getVehiculeByImm(Immatriculation)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function getAll() As List(Of Véhicules)
        Try
            Return dao.getAll()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'charger le data 
    Public Function getData() As DataSet
        Try
            Return dao.getData()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par Immatriculation
    Public Function getDataByImm(Imm As String) As DataSet
        Try
            Return dao.getDataByImm(Imm)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Type_Vehicule
    Public Function getDataByTypVeh(TypVeh As String) As DataSet
        Try
            Return dao.getDataByTypVeh(TypVeh)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtre par Immatriculation & Type_Vehicule
    Public Function getDataByImm_TypVeh(Imm As String, TypVeh As String) As DataSet
        Try
            Return dao.getDataByImm_TypVeh(Imm, TypVeh)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Etat
    Public Function getDataByEta(Eta As String) As DataSet
        Try
            Return dao.getDataByEta(Eta)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Immatriculation et Etat 
    Public Function getDataByImm_Eta(Imm As String, Eta As String) As DataSet
        Try
            Return dao.getDataByImm_Eta(Imm, Eta)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Type_Vehicule et Etat 
    Public Function getDataByTypVeh_Eta(TypVeh As String, Eta As String) As DataSet
        Try
            Return dao.getDataByTypVeh_Eta(TypVeh, Eta)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Immatriculation, Type_Vehicule et Etat 
    Public Function getDataByImm_TypVeh_Eta(Imm As String, TypVeh As String, Eta As String) As DataSet
        Try
            Return dao.getDataByImm_TypVeh_Eta(Imm, TypVeh, Eta)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par Capacité
    Public Function getDataByCap(Cap As Double) As DataSet
        Try
            Return dao.getDataByCap(Cap)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Immatriculation et Capacite
    Public Function getDataByImm_Cap(Imm As String, Cap As Double) As DataSet
        Try
            Return dao.getDataByImm_Cap(Imm, Cap)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Type_Vehicule et Capacite
    Public Function getDataByTypVeh_Cap(TypVeh As String, Cap As Double) As DataSet
        Try
            Return dao.getDataByTypVeh_Cap(TypVeh, Cap)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par etat et Capacite
    Public Function getDataByEta_Cap(Eta As String, Cap As Double) As DataSet
        Try
            Return dao.getDataByEta_Cap(Eta, Cap)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Immatriculation, Type_Vehicule et Capacite
    Public Function getDataByImm_TypVeh_Cap(Imm As String, TypVeh As String, Cap As Double) As DataSet
        Try
            Return dao.getDataByImm_TypVeh_Cap(Imm, TypVeh, Cap)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Immatriculation,etat et Capacite
    Public Function getDataByImm_Eta_Cap(Imm As String, Eta As String, Cap As Double) As DataSet
        Try
            Return dao.getDataByImm_Eta_Cap(Imm, Eta, Cap)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Type_Vehicule,etat et Capacite
    Public Function getDataByTypVeh_Eta_Cap(TypVeh As String, Eta As String, Cap As Double) As DataSet
        Try
            Return dao.getDataByTypVeh_Eta_Cap(TypVeh, Eta, Cap)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Immatriculation, Type_Vehicule,etat et Capacite    
    Public Function getDataByImm_TypVeh_Eta_Cap(Imm As String, TypVeh As String, Eta As String, Cap As Double) As DataSet
        Try
            Return dao.getDataByImm_TypVeh_Eta_Cap(Imm, TypVeh, Eta, Cap)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function


End Class
