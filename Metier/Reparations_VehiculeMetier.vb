Public Class Reparations_VehiculeMetier

    Dim dao As Réparations_VehiculeDao = New Réparations_VehiculeDao

    Public Sub AddVehiculeToGarage(Rep As Réparations_Vehicule)
        If Not Rep.Date_Reparation.Equals("") And Not Rep.Date_Sortie.Equals("") And Not Rep.Type_Entretien.Trim.Equals("") And Not Rep.Cout_Reparation.Equals("") Then
            If Rep.Date_Sortie >= Rep.Date_Reparation Then
                Try
                    dao.AddVehiculeToGarage(Rep)
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            Else
                Throw New Exception("La date de sortie de doit être superieur ou égale à celle de l'entrée")
            End If
        Else
            Throw New Exception("Veuillez remplir tout les champs")
        End If

    End Sub

    Public Sub UpdateVehiculeToGarage(Rep As Réparations_Vehicule)
        If Not Rep.Date_Reparation.Equals("") And Not Rep.Date_Sortie.Equals("") And Not Rep.Type_Entretien.Trim.Equals("") And Not Rep.Cout_Reparation.Equals("") Then
            If Rep.Date_Sortie >= Rep.Date_Reparation Then
                Try
                    dao.UpdateVehiculeToGarage(Rep)
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            Else
                Throw New Exception("La date de sortie de doit être superieur ou égale à celle de l'entrée")
            End If
        Else
            Throw New Exception("Veuillez remplir tout les champs")
        End If
    End Sub

    Public Sub DeleteReparations_Vehicule(Id_Reparation As Integer)
        Try
            dao.DeleteReparations_Vehicule(Id_Reparation)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function getReparations_vehiculeById(Id_Reparation As Integer) As Réparations_Vehicule
        Try
            Return dao.getReparations_vehiculeById(Id_Reparation)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function


    Public Function getData() As DataSet
        Try
            Return dao.getData()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Immatriculation
    Public Function getDataByImm(Imm As String) As DataSet
        Try
            Return dao.getDataByImm(Imm)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nom garage
    Public Function getDataByNom(Nom As String) As DataSet
        Try
            Return dao.getDataByNom(Nom)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Immatriculation et Nom garage
    Public Function getDataByImm_Nom(Imm As String, Nom As String) As DataSet
        Try
            Return dao.getDataByImm_Nom(Imm, Nom)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function


End Class
