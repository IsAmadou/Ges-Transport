

Public Class Historiques_UsersMetier

    Dim dao As Historiques_UsersDao = New Historiques_UsersDao

    Public Sub AddHis_User(His As Historiques_Users)
        Try
            dao.AddHis_User(His)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub DeleteHis_User(Id_His As Integer)
        Try
            dao.DeleteHis_User(Id_His)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function getHis_UserById(Id_His As Integer) As Historiques_Users
        Try
            Return dao.getHis_UserById(Id_His)
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

    'filtrer par login
    Public Function getDataByLog(Log As String) As DataSet
        Try
            Return dao.getDataByLog(Log)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par date
    Public Function getDataByDat(Dat As Date) As DataSet
        Try
            Return dao.getDataByDat(Dat)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'filtrer par date et login
    Public Function getDataByDat_Log(Log As String, Dat As Date) As DataSet
        Try
            Return dao.getDataByDat_Log(Log, Dat)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function


End Class
