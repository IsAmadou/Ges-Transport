Imports System.Data.SqlClient

Public Class Historiques_UsersDao

    Dim con As SqlConnection = ConnectionUtil.getInstance()

    Public Sub AddHis_User(His As Historiques_Users)
        Try
            Dim cmd As SqlCommand = New SqlCommand("insert into Historiques_Users (Id_User,Type_Operation,Date_Operation,Ref_Operation) values
                          (@Id_User,@Type_Operation,@Date_Operation,@Ref_Operation)", con)
            cmd.Parameters.AddWithValue("@Id_User", His.Utilisateur.Id_User)
            cmd.Parameters.AddWithValue("@Type_Operation", His.Type_Operation)
            cmd.Parameters.AddWithValue("@Date_Operation", His.Date_Operation)
            cmd.Parameters.AddWithValue("@Ref_Operation", His.Ref_Operation)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Supprimer un historique
    ''' </summary>
    ''' <param name="Id_His"></param>
    Public Sub DeleteHis_User(Id_His As Integer)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Delete from Historiques_Users where Id_Historique=@Id_His", con)
            cmd.Parameters.AddWithValue("@Id_His", Id_His)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Recuperer un historique par son  Id
    ''' </summary>
    ''' <param name="Id_His"></param>
    ''' <returns></returns>
    Public Function getHis_UserById(Id_His As Integer) As Historiques_Users
        Dim _his As Historiques_Users
        Dim dao As UtilisateursDao = New UtilisateursDao
        Try
            Dim cmd As SqlCommand =
                New SqlCommand("select * from Historiques_Users where Id_Historique=@Id_His", con)
            cmd.Parameters.AddWithValue("@Id_His", Id_His)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            If rd.Read() Then
                _his = New Historiques_Users(rd.GetInt32(0), dao.getUserById(rd.GetInt32(1)), rd.GetString(2), rd.GetDateTime(3), rd.GetString(4))
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return _his
    End Function

    ''' <summary>
    ''' Remplir le dataGredView
    ''' </summary>
    ''' <returns></returns>
    Public Function getData() As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select Id_Historique,Nom_User,Login_User,Type_Operation,Ref_Operation,Date_Operation from Historiques_Users h,
                                    Utilisateurs u where  h.Id_User =u.Id_User", con)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "Historiques_Users")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par login
    Public Function getDataByLog(Log As String) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select Id_Historique,Nom_User,Login_User,Type_Operation,Ref_Operation,Date_Operation from Historiques_Users h,
                                    Utilisateurs u where  h.Id_User =u.Id_User and Login_User like @Log", con)
            cmd.Parameters.AddWithValue("@Log", "%" + Log + "%")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "Historiques_UsersByLog")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par date
    Public Function getDataByDat(Dat As Date) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select Id_Historique,Nom_User,Login_User,Type_Operation,Ref_Operation,Date_Operation from Historiques_Users h,
                                    Utilisateurs u where  h.Id_User =u.Id_User and DATEPART(DAY,Date_Operation) = @dat and DATEPART(MONTH,Date_Operation) = @month 
                                            and DATEPART(YEAR,Date_Operation)=@year", con)
            cmd.Parameters.AddWithValue("@Dat", Dat.Day)
            cmd.Parameters.AddWithValue("@month", Dat.Month)
            cmd.Parameters.AddWithValue("@year", Dat.Year)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "Historiques_UsersByDat")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par date et login
    Public Function getDataByDat_Log(Log As String, Dat As Date) As DataSet
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select Id_Historique,Nom_User,Login_User,Type_Operation,Ref_Operation,Date_Operation from Historiques_Users h,
             Utilisateurs u where  h.Id_User =u.Id_User and Login_User like @Log and DATEPART(DAY,Date_Operation) = @dat and DATEPART(MONTH,Date_Operation) = @month 
                                            and DATEPART(YEAR,Date_Operation)=@year", con)
            cmd.Parameters.AddWithValue("@Log", "%" + Log + "%")
            cmd.Parameters.AddWithValue("@Dat", Dat.Day)
            cmd.Parameters.AddWithValue("@month", Dat.Month)
            cmd.Parameters.AddWithValue("@year", Dat.Year)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim data As DataSet = New DataSet()
            adapter.Fill(data, "Historiques_UsersByDat&Log")
            Return data
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function


End Class
