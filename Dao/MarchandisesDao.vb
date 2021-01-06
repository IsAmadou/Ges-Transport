Imports System.Data.SqlClient

Public Class MarchandisesDao

    Dim con As SqlConnection = ConnectionUtil.getInstance()

    ''' <summary>
    ''' Ajouter une Marchandise
    ''' </summary>
    ''' <param name="Mar"></param>
    Public Sub AddMarchandises(Mar As Marchandises)
        Try
            Dim cmd As SqlCommand = New SqlCommand("insert into Marchandises(Libelle,Nature,Valeur,Poids,Quantite,
                   Etat,Document,Date_Enregistrement,Statut) values (@Libelle,@Nature,@Valeur,@Poids,@Quantite,
                   @Etat,@Document,@Date_Enregistrement,@Statut) ", con)
            cmd.Parameters.AddWithValue("@Libelle", Mar.Libelle)
            cmd.Parameters.AddWithValue("@Nature", Mar.Nature)
            cmd.Parameters.AddWithValue("@Valeur", Mar.Valeur)
            cmd.Parameters.AddWithValue("@Poids", Mar.Poids)
            cmd.Parameters.AddWithValue("@Quantite", Mar.Quantite)
            cmd.Parameters.AddWithValue("@Etat", Mar.Etat)
            cmd.Parameters.AddWithValue("@Document", Mar.Documents)
            cmd.Parameters.AddWithValue("@Date_Enregistrement", Mar.Date_Enregistrement)
            cmd.Parameters.AddWithValue("@Statut", Mar.Statut)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Modifier les Caracteristiques d'une marchandise
    ''' </summary>
    ''' <param name="Mar"></param>
    Public Sub UpdateMarchandises(Mar As Marchandises)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Update Marchandises set Libelle=@Libelle,Nature=@Nature,
      Valeur=@Valeur,Poids=@Poids,Quantite=@Quantite,Etat=@Etat,Document=@Document,Date_Enregistrement=@Date_Enregistrement,
           Statut=@Statut where Id_Marchandise=@Id_Marchandise ", con)

            cmd.Parameters.AddWithValue("@Id_Marchandise", Mar.Id_Marchandises)
            cmd.Parameters.AddWithValue("@Libelle", Mar.Libelle)
            cmd.Parameters.AddWithValue("@Nature", Mar.Nature)
            cmd.Parameters.AddWithValue("@Valeur", Mar.Valeur)
            cmd.Parameters.AddWithValue("@Poids", Mar.Poids)
            cmd.Parameters.AddWithValue("@Quantite", Mar.Quantite)
            cmd.Parameters.AddWithValue("@Etat", Mar.Etat)
            cmd.Parameters.AddWithValue("@Document", Mar.Documents)
            cmd.Parameters.AddWithValue("@Date_Enregistrement", Mar.Date_Enregistrement)
            cmd.Parameters.AddWithValue("@Statut", Mar.Statut)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Supprimer une Marchandise
    ''' </summary>
    ''' <param name="Id_Marchandise"></param>
    Public Sub DeleteMarchandises(Id_Marchandise As Integer)
        Try
            Dim cmd As SqlCommand = New SqlCommand("delete from Marchandises where Id_Marchandise=@Id_Marchandise", con)
            cmd.Parameters.AddWithValue("@Id_Marchandise", Id_Marchandise)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Recuperer une marchandise par son Id
    ''' </summary>
    ''' <param name="Id_Marchandise"></param>
    ''' <returns></returns>
    Public Function getMarchandisesById(Id_Marchandise As Integer) As Marchandises
        Dim _Mar As Marchandises
        Try
            Dim cmd As SqlCommand =
                New SqlCommand("select * from Marchandises where Id_Marchandise=@Id_Marchandise", con)
            cmd.Parameters.AddWithValue("@Id_Marchandise", Id_Marchandise)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            If rd.Read() Then
                _Mar = New Marchandises(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetFloat(3), rd.GetFloat(4), rd.GetInt32(5),
                                        rd.GetString(6), rd.GetString(7), rd.GetDateTime(8), rd.GetString(9))
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return _Mar
    End Function

    ''' <summary>
    ''' Recuperer la liste de toutes les Marchanises
    ''' </summary>
    ''' <returns></returns>
    Public Function getAll() As List(Of Marchandises)
        Dim _listMar As List(Of Marchandises) = New List(Of Marchandises)
        Try
            Dim cmd As SqlCommand =
                New SqlCommand("select * from Marchandises", con)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While rd.Read()
                _listMar.Add(New Marchandises(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetFloat(3), rd.GetFloat(4), rd.GetInt32(5),
                                        rd.GetString(6), rd.GetString(7), rd.GetDateTime(8), rd.GetString(9)))
            End While
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return _listMar
    End Function

    ''' <summary>
    ''' Remplissage Du data gridview
    ''' </summary>
    ''' <returns></returns>
    Public Function getData() As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises", con)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "Marchandises")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function


    'Filtrer par Nature
    Public Function getDataByNat(Nat As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Nature like @Nat ", con)
            cmd.Parameters.AddWithValue("@Nat", "%" + Nat + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByNat")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Libelle
    Public Function getDataByLibe(Libe As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Libelle like @libe", con)
            cmd.Parameters.AddWithValue("@libe", "%" + Libe + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByLibe")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtre par Nature & libelle
    Public Function getDataByNat_Libe(Nat As String, Libe As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Nature like @Nat and Libelle like @libe", con)
            cmd.Parameters.AddWithValue("@Nat", "%" + Nat + "%")
            cmd.Parameters.AddWithValue("@libe", "%" + Libe + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByNat&Libe")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Document
    Public Function getDataByDoc(Doc As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Document like @Doc", con)
            cmd.Parameters.AddWithValue("@Doc", "%" + Doc + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByDoc")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature et Document
    Public Function getDataByNat_Doc(Nat As String, Doc As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Nature like @Nat and Document like @Doc", con)
            cmd.Parameters.AddWithValue("@Nat", "%" + Nat + "%")
            cmd.Parameters.AddWithValue("@Doc", "%" + Doc + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByNat&Doc")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Libelle et Document
    Public Function getDataByLibe_Doc(Libe As String, Doc As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Libelle like @libe and Document like @Doc", con)
            cmd.Parameters.AddWithValue("@libe", "%" + Libe + "%")
            cmd.Parameters.AddWithValue("@Doc", "%" + Doc + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByLibe&Doc")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature, libelle et Document 
    Public Function getDataByNat_Libe_Doc(Nat As String, Libe As String, Doc As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Nature like @Nat and Libelle like @libe
                                      and Document like @Doc", con)
            cmd.Parameters.AddWithValue("@Nat", "%" + Nat + "%")
            cmd.Parameters.AddWithValue("@libe", "%" + Libe + "%")
            cmd.Parameters.AddWithValue("@Doc", "%" + Doc + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByNat&Libe&Doc")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par Statut
    Public Function getDataBySta(Sta As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Statut like @Sta", con)
            cmd.Parameters.AddWithValue("@Sta", Sta(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesBySta")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature et Statut
    Public Function getDataByNat_Sta(Nat As String, Sta As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Nature like @Nat and Statut like @Sta", con)
            cmd.Parameters.AddWithValue("@Nat", "%" + Nat + "%")
            cmd.Parameters.AddWithValue("@Sta", Sta(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByNat&Sta")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par libelle et Statut
    Public Function getDataBylibe_Sta(libe As String, Sta As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Libelle like @libe and Statut like @Sta", con)
            cmd.Parameters.AddWithValue("@libe", "%" + libe + "%")
            cmd.Parameters.AddWithValue("@Sta", Sta(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByLibe&Sta")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Document et Statut
    Public Function getDataByDoc_Sta(Doc As String, Sta As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Document like @Doc and Statut like @Sta", con)
            cmd.Parameters.AddWithValue("@Doc", "%" + Doc + "%")
            cmd.Parameters.AddWithValue("@Sta", Sta(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "ChauffeurByDoc&Sta")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature, Libelle et Statu
    Public Function getDataByNat_Libe_Sta(Nat As String, Libe As String, sta As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Nature like @Nat and Libelle like @libe
                                      and Statut like @Sta", con)
            cmd.Parameters.AddWithValue("@Nat", "%" + Nat + "%")
            cmd.Parameters.AddWithValue("@libe", "%" + Libe + "%")
            cmd.Parameters.AddWithValue("@Sta", sta(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByNat&Libe&Sta")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature,Document et Statut
    Public Function getDataByNat_Doc_Sta(Nat As String, Doc As String, sta As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Nature like @Nat and Document like @Doc
                                      and Statut like @Sta", con)
            cmd.Parameters.AddWithValue("@Nat", "%" + Nat + "%")
            cmd.Parameters.AddWithValue("@Doc", "%" + Doc + "%")
            cmd.Parameters.AddWithValue("@Sta", sta(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByNat&Doc&Sta")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Libelle,Document et Statut
    Public Function getDataByLibe_Doc_Sta(Libe As String, Doc As String, sta As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Libelle like @libe and Document like @Doc
                                      and Statut like @Sta", con)
            cmd.Parameters.AddWithValue("@libe", "%" + Libe + "%")
            cmd.Parameters.AddWithValue("@Doc", "%" + Doc + "%")
            cmd.Parameters.AddWithValue("@Sta", sta(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByLibe&Doc&Sta")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature ,Libelle, Document et Statut
    Public Function getDataByNat_Libe_Doc_Sta(Nat As String, Libe As String, Doc As String, sta As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Nature like @Nat and Libelle like @libe
              and Document like @Doc and Statut like @Sta", con)
            cmd.Parameters.AddWithValue("@Nat", "%" + Nat + "%")
            cmd.Parameters.AddWithValue("@libe", "%" + Libe + "%")
            cmd.Parameters.AddWithValue("@Doc", "%" + Doc + "%")
            cmd.Parameters.AddWithValue("@Sta", sta(0) + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByNat&Libe&Doc&Sta")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par Poids
    Public Function getDataByPoi(Poi As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Quantite*Poids <= @Poi ", con)
            cmd.Parameters.AddWithValue("@Poi", Poi)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByPoi")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par Nature et Poids
    Public Function getDataByNat_Poi(Nat As String, Poi As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Nature like @Nat and Quantite*Poids <= @Poi ", con)
            cmd.Parameters.AddWithValue("@Nat", "%" + Nat + "%")
            cmd.Parameters.AddWithValue("@Poi", Poi)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByNat&Poi")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par Libelle et Poids
    Public Function getDataByLibe_Poi(Libe As String, Poi As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Libelle like @libe and Quantite*Poids <= @Poi ", con)
            cmd.Parameters.AddWithValue("@libe", "%" + Libe + "%")
            cmd.Parameters.AddWithValue("@Poi", Poi)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByLibe&Poi")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtre par Nature , libelle et poids
    Public Function getDataByNat_Libe_Poi(Nat As String, Libe As String, Poi As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Nature like @Nat and Libelle like @libe
                                   and Quantite*Poids <= @Poi", con)
            cmd.Parameters.AddWithValue("@Nat", "%" + Nat + "%")
            cmd.Parameters.AddWithValue("@libe", "%" + Libe + "%")
            cmd.Parameters.AddWithValue("@Poi", Poi)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByNat&Libe&Poi")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Document et Poids
    Public Function getDataByDoc_Poi(Doc As String, Poi As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Document like @Doc and Quantite*Poids <= @Poi", con)
            cmd.Parameters.AddWithValue("@Doc", "%" + Doc + "%")
            cmd.Parameters.AddWithValue("@Poi", Poi)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByDoc&Poi")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature, Document et Poids
    Public Function getDataByNat_Doc_Poi(Nat As String, Doc As String, Poi As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Nature like @Nat and Document like @Doc
                                    and Quantite*Poids <= @Poi", con)
            cmd.Parameters.AddWithValue("@Nat", "%" + Nat + "%")
            cmd.Parameters.AddWithValue("@Doc", "%" + Doc + "%")
            cmd.Parameters.AddWithValue("@Poi", Poi)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByNat&Doc&Poi")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Libelle ,Document et Poids
    Public Function getDataByLibe_Doc_Poi(Libe As String, Doc As String, Poi As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Libelle like @libe and Document like @Doc
                                and Quantite*Poids <= @Poi", con)
            cmd.Parameters.AddWithValue("@libe", "%" + Libe + "%")
            cmd.Parameters.AddWithValue("@Doc", "%" + Doc + "%")
            cmd.Parameters.AddWithValue("@Poi", Poi)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByLibe&Doc&Poi")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par nature,Libelle,Document et Poids
    Public Function getDataByNat_Libe_Doc_Poi(Nat As String, Libe As String, Doc As String, Poi As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Nature like @Nat and Libelle like @libe
                                      and Document like @Doc and Quantite*Poids <= @Poi", con)
            cmd.Parameters.AddWithValue("@Nat", "%" + Nat + "%")
            cmd.Parameters.AddWithValue("@libe", "%" + Libe + "%")
            cmd.Parameters.AddWithValue("@Doc", "%" + Doc + "%")
            cmd.Parameters.AddWithValue("@Poi", Poi)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByNat&Libe&Doc&Poi")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Filtrer par Statut et Poids
    Public Function getDataBySta_Poi(Sta As String, Poi As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Statut like @Sta and Quantite*Poids <= @Poi", con)
            cmd.Parameters.AddWithValue("@Sta", Sta(0) + "%")
            cmd.Parameters.AddWithValue("@Poi", Poi)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesBySta&Poi")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature , Statut et poids
    Public Function getDataByNat_Sta_Poi(Nat As String, Sta As String, Poi As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Nature like @Nat and Statut like @Sta
                          and Quantite*Poids <= @Poi", con)
            cmd.Parameters.AddWithValue("@Nat", "%" + Nat + "%")
            cmd.Parameters.AddWithValue("@Sta", Sta(0) + "%")
            cmd.Parameters.AddWithValue("@Poi", Poi)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByNat&Sta&Poi")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par libelle,Statut et Poids
    Public Function getDataBylibe_Sta_Poi(libe As String, Sta As String, Poi As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Libelle like @libe and Statut like @Sta 
                     and Quantite*Poids <= @Poi", con)
            cmd.Parameters.AddWithValue("@libe", "%" + libe + "%")
            cmd.Parameters.AddWithValue("@Sta", Sta(0) + "%")
            cmd.Parameters.AddWithValue("@Poi", Poi)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByLibe&Sta&Poi")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Document,Statut et Poids
    Public Function getDataByDoc_Sta_Poi(Doc As String, Sta As String, Poi As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Document like @Doc and Statut like @Sta
                            and Quantite*Poids <= @Poi", con)
            cmd.Parameters.AddWithValue("@Doc", "%" + Doc + "%")
            cmd.Parameters.AddWithValue("@Sta", Sta(0) + "%")
            cmd.Parameters.AddWithValue("@Poi", Poi)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByDoc&Sta&Poi")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature, Libelle, Statu et poids
    Public Function getDataByNat_Libe_Sta_Poi(Nat As String, Libe As String, sta As String, Poi As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Nature like @Nat and Libelle like @libe
                                      and Statut like @Sta and Quantite*Poids <= @Poi", con)
            cmd.Parameters.AddWithValue("@Nat", "%" + Nat + "%")
            cmd.Parameters.AddWithValue("@libe", "%" + Libe + "%")
            cmd.Parameters.AddWithValue("@Sta", sta(0) + "%")
            cmd.Parameters.AddWithValue("@Poi", Poi)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByNat&Libe&Sta&Poi")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature,Document, Statut et Poids
    Public Function getDataByNat_Doc_Sta_Poi(Nat As String, Doc As String, sta As String, Poi As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Nature like @Nat and Document like @Doc
                                      and Statut like @Sta and Quantite*Poids <= @Poi", con)
            cmd.Parameters.AddWithValue("@Nat", "%" + Nat + "%")
            cmd.Parameters.AddWithValue("@Doc", "%" + Doc + "%")
            cmd.Parameters.AddWithValue("@Sta", sta(0) + "%")
            cmd.Parameters.AddWithValue("@Poi", Poi)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByNat&Doc&Sta&Poi")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Libelle,Document,Statut et Poids
    Public Function getDataByLibe_Doc_Sta_Poi(Libe As String, Doc As String, sta As String, Poi As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Libelle like @libe and Document like @Doc
                                      and Statut like @Sta and Quantite*Poids <= @Poi", con)
            cmd.Parameters.AddWithValue("@libe", "%" + Libe + "%")
            cmd.Parameters.AddWithValue("@Doc", "%" + Doc + "%")
            cmd.Parameters.AddWithValue("@Sta", sta(0) + "%")
            cmd.Parameters.AddWithValue("@Poi", Poi)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByLibe&Doc&Sta&Poi")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par Nature ,Libelle, Document, Statut et poids
    Public Function getDataByNat_Libe_Doc_Sta_Poi(Nat As String, Libe As String, Doc As String, sta As String, Poi As Double) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Marchandises where Nature like @Nat and Libelle like @libe
              and Document like @Doc and Statut like @Sta and Quantite*Poids <= @Poi", con)
            cmd.Parameters.AddWithValue("@Nat", "%" + Nat + "%")
            cmd.Parameters.AddWithValue("@libe", "%" + Libe + "%")
            cmd.Parameters.AddWithValue("@Doc", "%" + Doc + "%")
            cmd.Parameters.AddWithValue("@Sta", sta(0) + "%")
            cmd.Parameters.AddWithValue("@Poi", Poi)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "MarchandisesByNat&Libe&Doc&Sta&Poi")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
