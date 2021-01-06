Imports System.Data.SqlClient

Public Class Pieces_VehiculeDao

    Private con As SqlConnection = ConnectionUtil.getInstance()

    ''' <summary>
    ''' Ajouter des pièces au véhicule
    ''' </summary>
    ''' <param name="Pie"></param>
    Public Sub AddPieces_Vehicule(Pie As Pièces_Vehicule)
        Try
            Dim cmd As SqlCommand = New SqlCommand("insert into Pieces_Vehicule(Immatriculation,Carte_Grise,Vignete,
            Date_ExpVignete,Assurance,date_ExpAssurance) values(@Immatriculation,@Carte_Grise,@Vignete,@Date_ExpVignete,
               @Assurance,@date_ExpAssurance)", con)
            cmd.Parameters.AddWithValue("@Immatriculation", Pie.Véhicules.Immatriculation)
            cmd.Parameters.AddWithValue("@Carte_Grise", Pie.Carte_grise)
            cmd.Parameters.AddWithValue("@Vignete", Pie.Vignette)
            If Pie.Date_ExpVignette = CType(Nothing, DateTime) Then
                cmd.Parameters.AddWithValue("@Date_ExpVignete", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Date_ExpVignete", Pie.Date_ExpVignette)
            End If
            cmd.Parameters.AddWithValue("@Assurance", Pie.Assurance)
            If Pie.Date_ExpAssurance = CType(Nothing, DateTime) Then
                cmd.Parameters.AddWithValue("@date_ExpAssurance", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@date_ExpAssurance", Pie.Date_ExpAssurance)
            End If
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Modifier les caractéristiques des pièces du véhicule
    ''' </summary>
    ''' <param name="Pie"></param>
    Public Sub UpdatePieces_Vehicule(Pie As Pièces_Vehicule)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Update Pieces_Vehicule set Immatriculation=@Immatriculation,
            Carte_Grise=@Carte_Grise,Vignete=@Vignete,Date_ExpVignete=@Date_ExpVignete,Assurance=@Assurance,
                     date_ExpAssurance=@date_ExpAssurance where Id_Pieces=@Id_Pieces", con)
            cmd.Parameters.AddWithValue("@Id_Pieces", Pie.Id_Piece)
            cmd.Parameters.AddWithValue("@Immatriculation", Pie.Véhicules.Immatriculation)
            cmd.Parameters.AddWithValue("@Carte_Grise", Pie.Carte_grise)
            cmd.Parameters.AddWithValue("@Vignete", Pie.Vignette)
            If Pie.Date_ExpVignette = CType(Nothing, DateTime) Then
                cmd.Parameters.AddWithValue("@Date_ExpVignete", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Date_ExpVignete", Pie.Date_ExpVignette)
            End If
            cmd.Parameters.AddWithValue("@Assurance", Pie.Assurance)
            If Pie.Date_ExpAssurance = CType(Nothing, DateTime) Then
                cmd.Parameters.AddWithValue("@date_ExpAssurance", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@date_ExpAssurance", Pie.Date_ExpAssurance)
            End If
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Recuperer les piece par Id
    ''' </summary>
    ''' <param name="Id_Piece"></param>
    ''' <returns></returns>
    Public Function getPieces_VehiculeById(Id_Pieces As Integer) As Pièces_Vehicule
        Dim _Pie As Pièces_Vehicule
        Dim Vehdao As VehiculesDao = New VehiculesDao()
        Try
            Dim cmd As SqlCommand =
                New SqlCommand("select * from Pieces_Vehicule where Id_Pieces=@Id_Pieces", con)
            cmd.Parameters.AddWithValue("@Id_Pieces", Id_Pieces)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            If rd.Read() Then
                Dim _Veh As Véhicules = Vehdao.getVehiculeByImm(rd.GetString(1))

                If rd.IsDBNull(4) And rd.IsDBNull(6) Then
                    _Pie = New Pièces_Vehicule(rd.GetInt32(0), _Veh, rd.GetString(2), rd.GetString(3),
                                                  rd.GetString(5))
                ElseIf rd.IsDBNull(4) Then
                    _Pie = New Pièces_Vehicule(rd.GetInt32(0), _Veh, rd.GetString(2), rd.GetString(3),
                                                  rd.GetString(5), rd.GetDateTime(6))
                ElseIf rd.IsDBNull(6) Then
                    _Pie = New Pièces_Vehicule(rd.GetInt32(0), _Veh, rd.GetString(2), rd.GetString(3), rd.GetDateTime(4),
                                              rd.GetString(5))
                Else
                    _Pie = New Pièces_Vehicule(rd.GetInt32(0), _Veh, rd.GetString(2), rd.GetString(3), rd.GetDateTime(4),
                                                   rd.GetString(5), rd.GetDateTime(6))
                End If

            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return _Pie
    End Function

    ''' <summary>
    ''' Recuperer la liste de toutes les pièces
    ''' </summary>
    ''' <returns></returns>
    Public Function getAll() As List(Of Pièces_Vehicule)
        Dim ListPie As List(Of Pièces_Vehicule) = New List(Of Pièces_Vehicule)()
        Dim Vehdao As VehiculesDao = New VehiculesDao()
        Try
            Dim cmd As SqlCommand =
                New SqlCommand("select * from Pieces_Vehicule", con)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While (rd.Read())
                Dim _Veh As Véhicules = Vehdao.getVehiculeByImm(rd.GetString(1))
                ListPie.Add(New Pièces_Vehicule(rd.GetInt32(0), _Veh, rd.GetString(2), rd.GetString(3), rd.GetDateTime(4),
                                           rd.GetString(5), rd.GetDateTime(6)))
            End While
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return ListPie
    End Function

    ''' <summary>
    ''' Recuperer les pièces par Vehicule
    ''' </summary>
    ''' <param name="Immatriculation"></param>
    ''' <returns></returns>
    Public Function getPiècesByVehicules(Immatriculation As String) As List(Of Pièces_Vehicule)
        Dim listPie As List(Of Pièces_Vehicule) = New List(Of Pièces_Vehicule)
        Dim Vehdao As VehiculesDao = New VehiculesDao()
        Try
            Dim cmd As SqlCommand =
                New SqlCommand("select * from Pieces_Vehicule where Immatriculation = @Immatriculation", con)
            cmd.Parameters.AddWithValue("@Immatriculation", Immatriculation)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While (rd.Read())
                Dim _Veh As Véhicules = Vehdao.getVehiculeByImm(rd.GetString(1))
                listPie.Add(New Pièces_Vehicule(rd.GetInt32(0), _Veh, rd.GetString(2), rd.GetString(3), rd.GetDateTime(4),
                                           rd.GetString(5), rd.GetDateTime(6)))
            End While
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return listPie
    End Function

End Class
