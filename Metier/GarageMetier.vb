Public Class GarageMetier

    Dim dao As GarageDao = New GarageDao

    Public Sub AddGarage(Gar As Garage)
        If Not Gar.Nom_Garage.Trim.Equals("") And Not Gar.Adresse_Garage.Trim.Equals("") Then
            If Gar.Tel_Garage.Contains("+") Then
                Try
                    dao.AddGarage(Gar)
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            Else
                Throw New Exception("Format du numéro de téléphone invalide")
            End If
        Else
            Throw New Exception("Veuillez remplir les champs")
        End If
    End Sub

    Public Sub UpdateGarage(Gar As Garage)
        If Not Gar.Nom_Garage.Trim.Equals("") And Not Gar.Adresse_Garage.Trim.Equals("") Then
            If Gar.Tel_Garage.Contains("+") Then
                Try
                    dao.UpdateGarage(Gar)
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            Else
                Throw New Exception("Format du numéro de téléphone invalide")
            End If
        Else
            Throw New Exception("Veuillez remplir les champs")
        End If
    End Sub

    Public Function getGarageById(Id_visite As Integer) As Garage
        Try
            Return dao.getGarageById(Id_visite)
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

    'filtre par nom
    Public Function getDataByNom(Nom As String) As DataSet
        Try
            Return dao.getDataByNom(Nom)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtre par Adresse
    Public Function getDataByAdr(Adr As String) As DataSet
        Try
            Return dao.getDataByAdr(Adr)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtre par nom et Adresse
    Public Function getDataByNom_Adr(Nom As String, Adr As String) As DataSet
        Try
            Return dao.getDataByNom_Adr(Nom, Adr)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
