Public Class Affecter_ChauffeursMetier

    Dim dao As Affecter_ChauffeursDao = New Affecter_ChauffeursDao

    Public Sub AddChauffeurToVehicule(Aff As Affecter_Chauffeurs)
        If Aff.Date_FinAffectation >= Aff.Date_Affectation Then
            Try
                dao.AddChauffeurToVehicule(Aff)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        Else
            Throw New Exception("La Date d'arrivée doit être superieur à celle du depart")
        End If
    End Sub

    Public Sub UpdateChauffeurToVehicule(Aff As Affecter_Chauffeurs)
        If Aff.Date_FinAffectation >= Aff.Date_Affectation Then
            Try
                dao.UpdateChauffeurToVehicule(Aff)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        Else
            Throw New Exception("La Date d'arrivée doit être superieur à celle du depart")
        End If
    End Sub

    Public Sub DeleteChauffeurToVehicule(Id_Affectation As Integer)
        Try
            dao.DeleteChauffeurToVehicule(Id_Affectation)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function getAffectation_ChauffeurById(Id_Affectation As Integer) As Affecter_Chauffeurs
        Try
            Return dao.getAffectation_ChauffeurById(Id_Affectation)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function getAll() As List(Of Affecter_Chauffeurs)
        Try
            Return dao.getAll()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
