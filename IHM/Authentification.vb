Public Class Authentification

    Public use As Utilisateurs
    Public w As Integer = 0
    Dim metierU As UtilisateursMetier = New UtilisateursMetier

    'au chargement
    Private Sub Authentification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Datacon.DataSource = metierU.getData().Tables("Utilisateurs")
    End Sub

    'cliquer sur se connecter
    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        Dim ver As Integer = 0
        For count As Int32 = 0 To Datacon.Rows.Count - 2
            Dim Cell As Integer = Datacon.Rows(count).Cells(0).Value
            Dim cell7 As String = Datacon.Rows(count).Cells(7).Value
            Dim cell8 As String = Datacon.Rows(count).Cells(8).Value
            Dim cell9 As String = Datacon.Rows(count).Cells(9).Value
            If LogUse_lbl.Text = cell7 And PasUse_lbl.Text = cell8 And StaUser_lbl.Text = cell9 Then
                ver = 1
                metierU.UpdateDecUser(Cell)
                metierU.UpdateconUser(Cell)
                use = metierU.getUserById(Cell)
                Gestion_Trajet.Show()
                Me.Hide()
            End If
        Next
        If ver = 0 Then
            MessageBox.Show("Statut,Login ou mot de password éronés,veuillez reéssayer s'il vous plait", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    'clique sur sortir
    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        Application.Exit()
    End Sub
End Class