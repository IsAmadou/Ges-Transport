Public Class Pièces_VehiculeMetier

    Dim dao As Pieces_VehiculeDao = New Pieces_VehiculeDao

    Public Sub AddPieces_Vehicule(Pie As Pièces_Vehicule)
        If Not Pie.Carte_grise.Trim.Equals("") And Not Pie.Assurance.Trim.Equals("") And Not Pie.Vignette.Trim.Equals("") Then
            Try
                dao.AddPieces_Vehicule(Pie)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        Else
            Throw New Exception(" Veuillez remplir tous les champs ")
        End If
    End Sub

    Public Sub UpdatePieces_Vehicule(Pie As Pièces_Vehicule)
        If Not Pie.Carte_grise.Trim.Equals("") And Not Pie.Assurance.Trim.Equals("") And Not Pie.Vignette.Trim.Equals("") Then
            Try
                dao.UpdatePieces_Vehicule(Pie)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        Else
            Throw New Exception(" Veuillez remplir tous les champs ")
        End If
    End Sub

    Public Function getPieces_VehiculeById(Id_Pieces As Integer) As Pièces_Vehicule
        Try
            Return dao.getPieces_VehiculeById(Id_Pieces)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function getAll() As List(Of Pièces_Vehicule)
        Try
            Return dao.getAll()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function getPiècesByVehicules(Immatriculation As String) As List(Of Pièces_Vehicule)
        Try
            Return dao.getPiècesByVehicules(Immatriculation)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
