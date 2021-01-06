Public Class MarchandisesMetier

    Dim dao As MarchandisesDao = New MarchandisesDao

    Public Sub AddMarchandises(Mar As Marchandises)
        If Not Mar.Nature.Trim.Equals("") And Not Mar.Libelle.Trim.Equals("") And Not Mar.Documents.Trim.Equals("") And Not Mar.Poids.Equals("") And Not Mar.Quantite.Equals("") And Not Mar.Valeur.Equals("") Then
            Try
                dao.AddMarchandises(Mar)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        Else
            Throw New Exception(" Veuillez remplir tous les champs ")
        End If
    End Sub

    Public Sub UpdateMarchandises(Mar As Marchandises)
        If Not Mar.Nature.Trim.Equals("") And Not Mar.Libelle.Trim.Equals("") And Not Mar.Documents.Trim.Equals("") And Not Mar.Poids.Equals("") And Not Mar.Quantite.Equals("") And Not Mar.Valeur.Equals("") Then
            Try
                dao.UpdateMarchandises(Mar)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        Else
            Throw New Exception(" Veuillez remplir tous les champs ")
        End If
    End Sub

    Public Sub DeleteMarchandises(Id_Marchandise As Integer)
        Try
            dao.DeleteMarchandises(Id_Marchandise)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function getMarchandisesById(Id_Marchandise As Integer) As Marchandises
        Try
            Return dao.getMarchandisesById(Id_Marchandise)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function getAll() As List(Of Marchandises)
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

    'Filtrer par Nature
    Public Function getDataByNat(Nat As String) As DataSet
        Try
            Return dao.getDataByNat(Nat)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Libelle
    Public Function getDataByLibe(Libe As String) As DataSet
        Try
            Return dao.getDataByLibe(Libe)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtre par Nature & libelle
    Public Function getDataByNat_Libe(Nat As String, Libe As String) As DataSet
        Try
            Return dao.getDataByNat_Libe(Nat, Libe)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Document
    Public Function getDataByDoc(Doc As String) As DataSet
        Try
            Return dao.getDataByDoc(Doc)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature et Document
    Public Function getDataByNat_Doc(Nat As String, Doc As String) As DataSet
        Try
            Return dao.getDataByNat_Doc(Nat, Doc)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Libelle et Document
    Public Function getDataByLibe_Doc(Libe As String, Doc As String) As DataSet
        Try
            Return dao.getDataByLibe_Doc(Libe, Doc)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature, libelle et Document 
    Public Function getDataByNat_Libe_Doc(Nat As String, Libe As String, Doc As String) As DataSet
        Try
            Return dao.getDataByNat_Libe_Doc(Nat, Libe, Doc)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par Statut
    Public Function getDataBySta(Sta As String) As DataSet
        Try
            Return dao.getDataBySta(Sta)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature et Statut
    Public Function getDataByNat_Sta(Nat As String, Sta As String) As DataSet
        Try
            Return dao.getDataByNat_Sta(Nat, Sta)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par libelle et Statut
    Public Function getDataBylibe_Sta(libe As String, Sta As String) As DataSet
        Try
            Return dao.getDataBylibe_Sta(libe, Sta)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Document et Statut
    Public Function getDataByDoc_Sta(Doc As String, Sta As String) As DataSet
        Try
            Return dao.getDataByDoc_Sta(Doc, Sta)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature, Libelle et Statu
    Public Function getDataByNat_Libe_Sta(Nat As String, Libe As String, sta As String) As DataSet
        Try
            Return dao.getDataByNat_Libe_Sta(Nat, Libe, sta)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature,Document et Statut
    Public Function getDataByNat_Doc_Sta(Nat As String, Doc As String, sta As String) As DataSet
        Try
            Return dao.getDataByNat_Doc_Sta(Nat, Doc, sta)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Libelle,Document et Statut
    Public Function getDataByLibe_Doc_Sta(Libe As String, Doc As String, sta As String) As DataSet
        Try
            Return dao.getDataByLibe_Doc_Sta(Libe, Doc, sta)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature ,Libelle, Document et Statut
    Public Function getDataByNat_Libe_Doc_Sta(Nat As String, Libe As String, Doc As String, sta As String) As DataSet
        Try
            Return dao.getDataByNat_Libe_Doc_Sta(Nat, Libe, Doc, sta)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par Poids
    Public Function getDataByPoi(Poi As Double) As DataSet
        Try
            Return dao.getDataByPoi(Poi)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par Nature et Poids
    Public Function getDataByNat_Poi(Nat As String, Poi As Double) As DataSet
        Try
            Return dao.getDataByNat_Poi(Nat, Poi)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par Libelle et Poids
    Public Function getDataByLibe_Poi(Libe As String, Poi As Double) As DataSet
        Try
            Return dao.getDataByLibe_Poi(Libe, Poi)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtre par Nature , libelle et poids
    Public Function getDataByNat_Libe_Poi(Nat As String, Libe As String, Poi As Double) As DataSet
        Try
            Return dao.getDataByNat_Libe_Poi(Nat, Libe, Poi)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Document et Poids
    Public Function getDataByDoc_Poi(Doc As String, Poi As Double) As DataSet
        Try
            Return dao.getDataByDoc_Poi(Doc, Poi)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature, Document et Poids
    Public Function getDataByNat_Doc_Poi(Nat As String, Doc As String, Poi As Double) As DataSet
        Try
            Return dao.getDataByNat_Doc_Poi(Nat, Doc, Poi)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Libelle ,Document et Poids
    Public Function getDataByLibe_Doc_Poi(Libe As String, Doc As String, Poi As Double) As DataSet
        Try
            Return dao.getDataByLibe_Doc_Poi(Libe, Doc, Poi)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par nature,Libelle,Document et Poids
    Public Function getDataByNat_Libe_Doc_Poi(Nat As String, Libe As String, Doc As String, Poi As Double) As DataSet
        Try
            Return dao.getDataByNat_Libe_Doc_Poi(Nat, Libe, Doc, Poi)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par Statut et Poids
    Public Function getDataBySta_Poi(Sta As String, Poi As Double) As DataSet
        Try
            Return dao.getDataBySta_Poi(Sta, Poi)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature , Statut et poids
    Public Function getDataByNat_Sta_Poi(Nat As String, Sta As String, Poi As Double) As DataSet
        Try
            Return dao.getDataByNat_Sta_Poi(Nat, Sta, Poi)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par libelle,Statut et Poids
    Public Function getDataBylibe_Sta_Poi(libe As String, Sta As String, Poi As Double) As DataSet
        Try
            Return dao.getDataBylibe_Sta_Poi(libe, Sta, Poi)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Document,Statut et Poids
    Public Function getDataByDoc_Sta_Poi(Doc As String, Sta As String, Poi As Double) As DataSet
        Try
            Return dao.getDataByDoc_Sta_Poi(Doc, Sta, Poi)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature, Libelle, Statu et poids
    Public Function getDataByNat_Libe_Sta_Poi(Nat As String, Libe As String, sta As String, Poi As Double) As DataSet
        Try
            Return dao.getDataByNat_Libe_Sta_Poi(Nat, Libe, sta, Poi)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature,Document, Statut et Poids
    Public Function getDataByNat_Doc_Sta_Poi(Nat As String, Doc As String, sta As String, Poi As Double) As DataSet
        Try
            Return dao.getDataByNat_Doc_Sta_Poi(Nat, Doc, sta, Poi)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Libelle,Document,Statut et Poids
    Public Function getDataByLibe_Doc_Sta_Poi(Libe As String, Doc As String, sta As String, Poi As Double) As DataSet
        Try
            Return dao.getDataByLibe_Doc_Sta_Poi(Libe, Doc, sta, Poi)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature ,Libelle, Document, Statut et poids
    Public Function getDataByNat_Libe_Doc_Sta_Poi(Nat As String, Libe As String, Doc As String, sta As String, Poi As Double) As DataSet
        Try
            Return dao.getDataByNat_Libe_Doc_Sta_Poi(Nat, Libe, Doc, sta, Poi)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
