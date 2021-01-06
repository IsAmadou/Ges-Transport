Imports System.Data.SqlClient

Public Class TrajetDao

    Dim con As SqlConnection = ConnectionUtil.getInstance()

    ''' <summary>
    ''' Ajouter un Trajet
    ''' </summary>
    ''' <param name="Tra"></param>
    Public Sub AddTrajet(Tra As Trajet)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Insert into Trajet (Ref,Position_Depart,Position_Arriver) values 
                           (@Ref,@Position_Depart,@Position_Arriver)", con)
            cmd.Parameters.AddWithValue("@Ref", Tra.Ref)
            cmd.Parameters.AddWithValue("@Position_Depart", Tra.Position_Depart)
            cmd.Parameters.AddWithValue("@Position_Arriver", Tra.Position_Arrivee)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Modifier les caracteristiques d'un trajet
    ''' </summary>
    ''' <param name="Tra"></param>
    Public Sub UpdateTrajet(Tra As Trajet)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Update Trajet set Ref=@Ref,Position_Depart=@Position_Depart,
                            Position_Arriver=@Position_Arriver where Ref=@Ref", con)

            cmd.Parameters.AddWithValue("@Ref", Tra.Ref)
            cmd.Parameters.AddWithValue("@Position_Depart", Tra.Position_Depart)
            cmd.Parameters.AddWithValue("@Position_Arriver", Tra.Position_Arrivee)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Supprimer un trajet
    ''' </summary>
    ''' <param name="Ref"></param>
    Public Sub DeleteTrajet(Ref As String)
        Try
            Dim cmd As SqlCommand = New SqlCommand("delete from Trajet where Ref=@Ref ", con)
            cmd.Parameters.AddWithValue("@Ref", Ref)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Recuperer un trajet par sa reference
    ''' </summary>
    ''' <param name="Ref"></param>
    ''' <returns></returns>
    Public Function getTrajetByRef(Ref As String) As Trajet
        Dim _Tra As Trajet
        Try
            Dim cmd As SqlCommand =
                New SqlCommand("select * from Trajet where Ref=@Ref", con)
            cmd.Parameters.AddWithValue("@Ref", Ref)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            If rd.Read() Then
                _Tra = New Trajet(rd.GetString(0), rd.GetString(1), rd.GetString(2))
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return _Tra
    End Function

    ''' <summary>
    ''' Recuperer la liste de tous les Trajets
    ''' </summary>
    ''' <returns></returns>
    Public Function getAll() As List(Of Trajet)
        Dim _listTraj As List(Of Trajet) = New List(Of Trajet)
        Try
            Dim cmd As SqlCommand =
                New SqlCommand("select * from Trajet", con)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While rd.Read()
                _listTraj.Add(New Trajet(rd.GetString(0), rd.GetString(1), rd.GetString(2)))
            End While
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return _listTraj
    End Function



End Class
