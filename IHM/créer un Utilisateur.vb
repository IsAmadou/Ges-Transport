Public Class créer_un_Utilisateur
    Dim metierU As UtilisateursMetier = New UtilisateursMetier
    Dim metierH As Historiques_UsersMetier = New Historiques_UsersMetier

    'clique sur le boutton Enregistrer pour l'ajout ou La Modification d'un utilisateur
    Private Sub EnrUse_Click(sender As Object, e As EventArgs) Handles EnrUse.Click
        Dim _sex As String
        If Mas_rd_lbl.Checked = True Then
            _sex = "Masculin"
        ElseIf Fem_rd_lbl.Checked = True Then
            _sex = "Féminin"
        End If
        If MotUse_Lbl.Text = MotConUse_lbl.Text Then
            If TitrPanelAddUser.Text = "Créer un Utilisateur" Then
                Try
                    Dim _use = New Utilisateurs(NomUse_lbl.Text, PreUse_lbl.Text, _sex, TelUse_lbl.Text, EmaUse_lbl.Text,
                                                AddUse_lbl.Text, LogUse_lbl.Text, MotUse_Lbl.Text, StaUse_lbl.Text, "Deconnecter")
                    metierU.AddUser(_use)
                    Dim lo As String = LogUse_lbl.Text
                    vider()
                    MessageBox.Show(Me, "Utilisateur ajouté avec succée", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Ajout d'un utilisateur", DateTime.Now, lo)
                    metierH.AddHis_User(his)
                    Administration.charger()
                    Administration.Show()
                    Me.Hide()
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message, "Error 505", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            ElseIf TitrPanelAddUser.Text = "Modifier un Utilisateur" Then
                Try
                    Dim _use = New Utilisateurs(NomUse_lbl.Text, PreUse_lbl.Text, _sex, TelUse_lbl.Text, EmaUse_lbl.Text,
                                                    AddUse_lbl.Text, LogUse_lbl.Text, MotUse_Lbl.Text, StaUse_lbl.Text, "Deconnecter")
                    metierU.UpdateUser(_use)
                    Dim lo As String = LogUse_lbl.Text
                    vider()
                    MessageBox.Show(Me, "modification bien éffectuée", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Modification des caracteristiques d'un utilisateur", DateTime.Now, lo)
                    metierH.AddHis_User(his)
                    Administration.charger()
                    If Authentification.w = 0 Then
                        Administration.Show()
                    Else
                        Gestion_Trajet.Show()
                    End If
                    Me.Hide()
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message, "Error 505", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Confirmation du mot de pase invalide", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Administration.AddUse.Enabled = True
        Administration.UpdateUse.Enabled = True
        Administration.DeleteUse.Enabled = True
    End Sub

    'Vider tous les champs
    Private Sub vider()
        NomUse_lbl.Text = ""
        PreUse_lbl.Text = ""
        TelUse_lbl.Text = "+"
        EmaUse_lbl.Text = ""
        AddUse_lbl.Text = ""
        LogUse_lbl.Text = ""
        MotUse_Lbl.Text = ""
        MotConUse_lbl.Text = ""
        StaUse_lbl.Text = ""
    End Sub

    'Bloquer tel a recevoir que des chiffres
    Private Sub TelUse_lbl_KeyPress(sender As Object, e As KeyPressEventArgs)
        Gestion_Conducteur.chiffre_only(e)
    End Sub

    ' cliquer sur annuler
    Private Sub AnnUse_Click(sender As Object, e As EventArgs) Handles AnnUse.Click
        If Authentification.w = 0 Then
            Administration.Show()
        Else
            Gestion_Trajet.Show()
        End If
        Me.Hide()
        vider()
        Administration.AddUse.Enabled = True
        Administration.UpdateUse.Enabled = True
        Administration.DeleteUse.Enabled = True

    End Sub

    'bloquer telephone à ne recevoir que des chiffres
    Private Sub TelUse_lbl_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles TelUse_lbl.KeyPress
        Gestion_Conducteur.chiffre_only(e)
    End Sub

End Class