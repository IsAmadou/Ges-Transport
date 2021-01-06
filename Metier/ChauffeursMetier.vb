Public Class ChauffeursMetier

    Dim dao As ChauffeursDao = New ChauffeursDao

    Public Sub AddChauffeurs(Chauf As Chauffeurs)
        If Not Chauf.Nom_Chauffeur.Trim().Equals("") And Not Chauf.Prenom_Chauffeur.Trim().Equals("") And Not Chauf.Sexe.Trim().Equals("") And Not Chauf.Type_Vehicule_Conduit.Trim().Equals("") Then
            If Chauf.Email_chauffeur.Contains("@") And Chauf.Email_chauffeur.Contains(".") Then
                If (Date.Now - Chauf.Date_naiss).Days >= 6570 Then
                    If Chauf.Tel_Chauffeur.Contains("+") Then
                        Try
                            dao.AddChauffeurs(Chauf)
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    Else
                        Throw New Exception("Format du numéro de téléphone invalide")
                    End If
                Else
                    Throw New Exception("Le chauffeur doit avoir au moins 18 ans")
                End If
            Else
                Throw New Exception("Email invalide")
            End If

        Else
            Throw New Exception("Veuillez remplir les champs obligatoires")
        End If
    End Sub

    Public Sub UpdateChauffeurs(Chauf As Chauffeurs)
        If Not Chauf.Nom_Chauffeur.Trim().Equals("") And Not Chauf.Prenom_Chauffeur.Trim().Equals("") And Not Chauf.Sexe.Trim().Equals("") And Not Chauf.Type_Vehicule_Conduit.Trim().Equals("") Then
            If Chauf.Email_chauffeur.Contains("@") And Chauf.Email_chauffeur.Contains(".") Then
                If (Date.Now - Chauf.Date_naiss).Days >= 6570 Then
                    If Chauf.Tel_Chauffeur.Contains("+") Then
                        Try
                            dao.UpdateChauffeurs(Chauf)
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    Else
                        Throw New Exception("Format du numéro de téléphone invalide")
                    End If
                Else
                    Throw New Exception("Le chauffeur doit avoir au moins 18 ans")
                End If
            Else
                Throw New Exception("Email invalide")
            End If

        Else
            Throw New Exception("Veuillez remplir les champs obligatoir")
        End If
    End Sub

    Public Sub DeleteChauffeurs(Id_Chauffeur As Integer)
        Try
            dao.DeleteChauffeurs(Id_Chauffeur)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function getChauffeurById(Id_Chauffeur As Integer) As Chauffeurs
        Try
            Return dao.getChauffeurById(Id_Chauffeur)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function getAll() As List(Of Chauffeurs)
        Try
            Return dao.getAll()
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

    Public Function getDataByNom(Nom As String) As DataSet
        Try
            Return dao.getDataByNom(Nom)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function getDataByPre(Pre As String) As DataSet
        Try
            Return dao.getDataByPre(Pre)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function getDataByNon_Pre(Nom As String, Pre As String) As DataSet
        Try
            Return dao.getDataByNon_Pre(Nom, Pre)
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

    'filtrer par Nom et Etat 
    Public Function getDataByNon_Eta(Nom As String, Eta As String) As DataSet
        Try
            Return dao.getDataByNon_Eta(Nom, Eta)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Prenom et Etat 
    Public Function getDataByPre_Eta(Pre As String, Eta As String) As DataSet
        Try
            Return dao.getDataByPre_Eta(Pre, Eta)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nom, Prenom et Etat 
    Public Function getDataByNom_Pre_Eta(Nom As String, Pre As String, Eta As String) As DataSet
        Try
            Return dao.getDataByNom_Pre_Eta(Nom, Pre, Eta)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par type de vehicule conduit
    Public Function getDataByTyp(Typ As String) As DataSet
        Try
            Return dao.getDataByTyp(Typ)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par nom et type de vehicule conduit
    Public Function getDataByNon_Typ(Nom As String, Typ As String) As DataSet
        Try
            Return dao.getDataByNon_Typ(Nom, Typ)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par prenom et type de vehicule conduit
    Public Function getDataByPre_Typ(Pre As String, Typ As String) As DataSet
        Try
            Return dao.getDataByPre_Typ(Pre, Typ)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par etat et type de vehicule conduit
    Public Function getDataByEta_Typ(Eta As String, Typ As String) As DataSet
        Try
            Return dao.getDataByEta_Typ(Eta, Typ)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par nom, prenom et type de vehicule conduit
    Public Function getDataByNom_Pre_Typ(Nom As String, Pre As String, Typ As String) As DataSet
        Try
            Return dao.getDataByNom_Pre_Typ(Nom, Pre, Typ)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par nom,etat et type de vehicule conduit
    Public Function getDataByNom_Eta_Typ(Nom As String, Eta As String, Typ As String) As DataSet
        Try
            Return dao.getDataByNom_Eta_Typ(Nom, Eta, Typ)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par prenom,etat et type de vehicule conduit
    Public Function getDataByPre_Eta_Typ(Pre As String, Eta As String, Typ As String) As DataSet
        Try
            Return dao.getDataByPre_Eta_Typ(Pre, Eta, Typ)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par nom ,prenom, etat et type de vehicule conduit
    Public Function getDataByNom_Pre_Eta_Typ(Nom As String, Pre As String, Eta As String, Typ As String) As DataSet
        Try
            Return dao.getDataByNom_Pre_Eta_Typ(Nom, Pre, Eta, Typ)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
