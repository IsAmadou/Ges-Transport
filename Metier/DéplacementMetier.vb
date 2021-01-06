Public Class DéplacementMetier

    Dim dao As DeplacementDao = New DeplacementDao

    Public Sub AddDeplacement(Dep As Deplacement)
        If Dep.Date_Arrivée >= Dep.Date_Départ Then
            If Dep.Heure_Arrivée > Dep.Heure_Départ Then
                Try
                    dao.AddDeplacement(Dep)
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            Else
                Throw New Exception("La Date d'arrivée doit être superieur ou égale à celle du depart")
            End If
        Else
            Throw New Exception("L'heure d'arrivée doit être superieur  à celle du depart")
        End If
    End Sub

    Public Sub UpdateDeplacement(Dep As Deplacement)
        If Dep.Date_Arrivée >= Dep.Date_Départ Then
            If Dep.Heure_Arrivée > Dep.Heure_Départ Then
                Try
                    dao.UpdateDeplacement(Dep)
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            Else
                Throw New Exception("La Date d'arrivée doit être superieur superieur ou égale à celle du depart")
            End If
        Else
            Throw New Exception("L'heure d'arrivée doit être superieur à celle du depart")
        End If
    End Sub

    Public Sub DeleteDeplacement(Id_Deplacement As Integer)
        Try
            dao.DeleteDeplacement(Id_Deplacement)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function getDaplacementById(Id_Deplacement As Integer) As Deplacement
        Try
            Return dao.getDaplacementById(Id_Deplacement)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'recuperer tous les trajet
    Public Function getData() As DataSet
        Try
            Return dao.getData()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer trajet par immatriculation
    Public Function getDataByImm(Imm As String) As DataSet
        Try
            Return dao.getDataByImm(Imm)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nom chauffeur
    Public Function getDataByNom(Nom As String) As DataSet
        Try
            Return dao.getDataByNom(Nom)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Prenom chauffeur
    Public Function getDataByPre(Pre As String) As DataSet
        Try
            Return dao.getDataByPre(Pre)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par libelle marchandises
    Public Function getDataByLib(Libe As String) As DataSet
        Try
            Return dao.getDataByLib(Libe)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Date deplacement
    Public Function getDataByDat(DateDep As DateTime) As DataSet
        Try
            Return dao.getDataByDat(DateDep)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
