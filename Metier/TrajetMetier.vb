Public Class TrajetMetier

    Dim dao As TrajetDao = New TrajetDao

    Public Sub AddTrajet(Tra As Trajet)
        If Not Tra.Ref.Trim.Equals("") And Not Tra.Position_Depart.Trim.Equals("") And Not Tra.Position_Arrivee.Trim.Equals("") Then
            If Tra.Position_Depart.Trim <> Tra.Position_Arrivee.Trim Then
                Try
                    dao.AddTrajet(Tra)
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            Else
                Throw New Exception("la position d'arrivée doit être différente de celle de depart")
            End If
        Else
            Throw New Exception("Veuillez preciser le trajet à faire")
        End If
    End Sub

    Public Sub UpdateTrajet(Tra As Trajet)
        If Not Tra.Ref.Trim.Equals("") And Not Tra.Position_Depart.Trim.Equals("") And Not Tra.Position_Arrivee.Trim.Equals("") Then
            If Tra.Position_Depart.Trim <> Tra.Position_Arrivee.Trim Then
                Try
                    dao.UpdateTrajet(Tra)
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            Else
                Throw New Exception("la position d'arrivée doit être différente de celle de depart")
            End If
        Else
            Throw New Exception("Veuillez preciser le trajet à faire")
        End If
    End Sub

    Public Sub DeleteTrajet(Ref As String)
        Try
            dao.DeleteTrajet(Ref)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function getTrajetByRef(Ref As String) As Trajet
        Try
            Return dao.getTrajetByRef(Ref)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function getAll() As List(Of Trajet)
        Try
            Return dao.getAll()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
