Imports System.Data.SqlClient

Public Class ConnectionUtil
    Private Shared instance As SqlConnection

    Private Sub New()
    End Sub

    ''' <summary>
    ''' établir la connection avec la BD
    ''' </summary>
    ''' <returns>Instance de connection</returns>
    Public Shared Function getInstance() As SqlConnection
        If instance Is Nothing Then
            instance = New SqlConnection("Data Source=DESKTOP-5NU1RNV;Initial Catalog=TRANSPORT;Integrated Security=True;MultipleActiveResultSets=True")
            instance.Open()
        End If
        Return instance
    End Function

End Class
