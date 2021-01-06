Public Class Administration

    Dim metierU As UtilisateursMetier = New UtilisateursMetier
    Dim metierH As Historiques_UsersMetier = New Historiques_UsersMetier

    'chargement de la form
    Private Sub Administration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dat_lbl.Visible = False
        Try
            charger()
            charger_his()
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'au clique de la page de controle
    Private Sub User_Click(sender As Object, e As EventArgs) Handles User.Click
        Try
            charger()
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'chargé data grid
    Public Sub charger()
        DataGridUser.DataSource = metierU.getData().Tables("Utilisateurs")
        DataGridUser.Columns()(0).Visible = False
    End Sub

    'Charger le data  Historique
    Private Sub charger_his()
        DataGridHis_User.DataSource = metierH.getData().Tables("Historiques_Users")
        DataGridHis_User.Columns()(0).Visible = False
    End Sub

    'filtrer datagid utilisateur
    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click
        If Not NomUse_fil.Text.Trim.Equals("") And PreUse_fil.Text.Trim.Equals("") And LogUse_Fil.Text.Trim.Equals("") Then
            Try
                DataGridUser.DataSource = metierU.getDataByNom(NomUse_fil.Text).Tables("UtilisateursByNom")
                DataGridUser.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un utilisateur par le nom", DateTime.Now, NomUse_fil.Text)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NomUse_fil.Text.Trim.Equals("") And Not PreUse_fil.Text.Trim.Equals("") And LogUse_Fil.Text.Trim.Equals("") Then
            Try
                DataGridUser.DataSource = metierU.getDataByPre(PreUse_fil.Text).Tables("UtilisateursByPre")
                DataGridUser.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un utilisateur par le prenom", DateTime.Now, PreUse_fil.Text)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NomUse_fil.Text.Trim.Equals("") And Not PreUse_fil.Text.Trim.Equals("") And LogUse_Fil.Text.Trim.Equals("") Then
            Try
                DataGridUser.DataSource = metierU.getDataByNon_Pre(NomUse_fil.Text, PreUse_fil.Text).Tables("UtilisateursByNom&Pre")
                DataGridUser.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un utilisateur par le nom et le prenom", DateTime.Now,
                                                (NomUse_fil.Text + "," + PreUse_fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NomUse_fil.Text.Trim.Equals("") And PreUse_fil.Text.Trim.Equals("") And Not LogUse_Fil.Text.Trim.Equals("") Then
            Try
                DataGridUser.DataSource = metierU.getDataByLog(LogUse_Fil.Text).Tables("UtilisateursByLog")
                DataGridUser.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un utilisateur par le login", DateTime.Now, LogUse_Fil.Text)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NomUse_fil.Text.Trim.Equals("") And PreUse_fil.Text.Trim.Equals("") And Not LogUse_Fil.Text.Trim.Equals("") Then
            Try
                DataGridUser.DataSource = metierU.getDataByNon_Log(NomUse_fil.Text, LogUse_Fil.Text).Tables("UtilisateursByNom&Log")
                DataGridUser.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un utilisateur par le nom et le login", DateTime.Now,
                                               (NomUse_fil.Text + "," + LogUse_Fil.Text))
                metierH.AddHis_User(his)


            Catch ex As exception
                messagebox.show(Me, ex.message, "error", messageboxbuttons.ok, messageboxicon.error)
            End Try

        ElseIf NomUse_fil.Text.Trim.Equals("") And Not PreUse_fil.Text.Trim.Equals("") And Not LogUse_Fil.Text.Trim.Equals("") Then
            Try
                DataGridUser.DataSource = metierU.getDataByPre_Log(PreUse_fil.Text, LogUse_Fil.Text).Tables("UtilisateursByPre&Log")
                DataGridUser.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un utilisateur par le prenom et le login", DateTime.Now,
                                               (PreUse_fil.Text + "," + LogUse_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NomUse_fil.Text.Trim.Equals("") And Not PreUse_fil.Text.Trim.Equals("") And Not LogUse_Fil.Text.Trim.Equals("") Then
            Try
                DataGridUser.DataSource = metierU.getDataByNom_Pre_Log(NomUse_fil.Text, PreUse_fil.Text, LogUse_Fil.Text).Tables("UtilisateursByNom&Pre&Log")
                DataGridUser.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un utilisateur par le nom, le prenom et le login", DateTime.Now,
                                               (NomUse_fil.Text + "," + PreUse_fil.Text + "," + LogUse_Fil.Text.Trim))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NomUse_fil.Text.Trim.Equals("") And PreUse_fil.Text.Trim.Equals("") And LogUse_Fil.Text.Trim.Equals("") Then
            Try
                charger()
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    'clique sur ajouter
    Private Sub AddUse_Click(sender As Object, e As EventArgs) Handles AddUse.Click
        créer_un_Utilisateur.Show()
        Me.Hide()
        DeleteUse.Enabled = False
        UpdateUse.Enabled = False
    End Sub

    'clique sur modifier
    Private Sub UpdateUse_Click(sender As Object, e As EventArgs) Handles UpdateUse.Click

        '''''Recuperer les info d'un Utilisateur pour les modifier''''''''''''
        Try
            Dim IdUser As Int32 = DataGridUser.SelectedRows(0).Cells(0).Value
            créer_un_Utilisateur.Show()
            Me.Hide()
            créer_un_Utilisateur.TitrPanelAddUser.Text = "Modifier un Utilisateur"
            DeleteUse.Enabled = False
            AddUse.Enabled = False
            Dim user As Utilisateurs = metierU.getUserById(IdUser)

            If user.Sexe_User = "Masculin" Then
                créer_un_Utilisateur.Mas_rd_lbl.Checked = True
                créer_un_Utilisateur.Fem_rd_lbl.Checked = False
            ElseIf user.Sexe_User = "Féminin" Then
                créer_un_Utilisateur.Fem_rd_lbl.Checked = True
                créer_un_Utilisateur.Mas_rd_lbl.Checked = False
            End If
            créer_un_Utilisateur.NomUse_lbl.Text = user.Nom_User
            créer_un_Utilisateur.PreUse_lbl.Text = user.Prenom_User
            créer_un_Utilisateur.TelUse_lbl.Text = user.Telephone_User
            créer_un_Utilisateur.EmaUse_lbl.Text = user.Email_User
            créer_un_Utilisateur.AddUse_lbl.Text = user.Adresse_User
            créer_un_Utilisateur.LogUse_lbl.Text = user.Login_User
            créer_un_Utilisateur.MotUse_Lbl.Text = user.Password_User
            créer_un_Utilisateur.MotConUse_lbl.Text = user.Password_User
            créer_un_Utilisateur.StaUse_lbl.Text = user.Statut_User
        Catch ex As Exception
            MessageBox.Show("L'utilisateur à modifier doit être selectionné", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            AddUse.Enabled = True
            DeleteUse.Enabled = True
        End Try
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    'clique sur supprimer
    Private Sub DeleteUse_Click(sender As Object, e As EventArgs) Handles DeleteUse.Click
        Dim rsult As DialogResult = MessageBox.Show("Cela entrainera aussi la supprission de son historique, etes-vous sûr(e) de vouloir supprimer", "Confirmation",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If rsult = Windows.Forms.DialogResult.Yes Then
            For i As Int32 = 0 To DataGridUser.SelectedRows.Count - 1
                Dim IdUser As Int32
                Try
                    Dim lo As String = DataGridUser.SelectedRows(0).Cells(7).Value
                    IdUser = DataGridUser.SelectedRows(0).Cells(0).Value
                    Try
                        metierU.DeleteUser(IdUser)
                        Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Suppression d'un utilisateur", DateTime.Now, lo)
                        metierH.AddHis_User(his)
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Catch ex As Exception
                    MessageBox.Show("L'utilisateur à supprimer doit être selectionné", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try
            Next
            Try
                charger()
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Try
                charger()
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    'Details sur les champs
    Private Sub DataGridUser_DoubleClick(sender As Object, e As EventArgs) Handles DataGridUser.DoubleClick
        For i As Int32 = 0 To DataGridUser.SelectedRows.Count - 1
            Dim IdUs As Int32
            Try
                IdUs = DataGridUser.SelectedRows(i).Cells(0).Value
                Dim us As Utilisateurs = metierU.getUserById(IdUs)
                DetailsDatagrid.L1.Visible = True
                DetailsDatagrid.L1.Text = "Nom"
                DetailsDatagrid.T1.Visible = True
                DetailsDatagrid.T1.Text = us.Nom_User
                DetailsDatagrid.L2.Visible = True
                DetailsDatagrid.L2.Text = "Prénom"
                DetailsDatagrid.T2.Visible = True
                DetailsDatagrid.T2.Text = us.Prenom_User
                DetailsDatagrid.L3.Visible = True
                DetailsDatagrid.L3.Text = "Sexe"
                DetailsDatagrid.T3.Visible = True
                DetailsDatagrid.T3.Text = us.Sexe_User
                DetailsDatagrid.L4.Visible = True
                DetailsDatagrid.L4.Text = "Email"
                DetailsDatagrid.T4.Visible = True
                DetailsDatagrid.T4.Text = us.Email_User
                DetailsDatagrid.L5.Visible = True
                DetailsDatagrid.L5.Text = "Telephone"
                DetailsDatagrid.T5.Visible = True
                DetailsDatagrid.T5.Text = us.Telephone_User
                DetailsDatagrid.L6.Visible = True
                DetailsDatagrid.L6.Text = "Adresse"
                DetailsDatagrid.T6.Visible = True
                DetailsDatagrid.T6.Text = us.Adresse_User
                DetailsDatagrid.L7.Visible = True
                DetailsDatagrid.L7.Text = "Statut"
                DetailsDatagrid.T7.Visible = True
                DetailsDatagrid.T7.Text = us.Statut_User
                DetailsDatagrid.L8.Visible = True
                DetailsDatagrid.L8.Text = "Etat"
                DetailsDatagrid.T8.Visible = True
                DetailsDatagrid.T8.Text = us.Etat_User
                DetailsDatagrid.L9.Visible = True
                DetailsDatagrid.L9.Text = "Login"
                DetailsDatagrid.T9.Visible = True
                DetailsDatagrid.T9.Text = us.Login_User
                DetailsDatagrid.L10.Visible = True
                DetailsDatagrid.L10.Text = "Password"
                DetailsDatagrid.T10.Visible = True
                DetailsDatagrid.T10.Text = us.Password_User
                DetailsDatagrid.Show()
            Catch ex As Exception
                MessageBox.Show("Le double-clic doit être sur un utilisateur pour cette operation", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        Next
    End Sub

    'clique sur historique
    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click, Panel5.Click, Label14.Click
        Historiques.Show()
        Me.Close()
        Gestion_Conducteur.Close()
        Gestion_garage.Close()
        Gestion_Marchandises.Close()
        Gestion_Véhicules.Close()
        Gestion_Trajet.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur trajet
    Private Sub Panel9_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click, Panel9.Click, Label16.Click
        Gestion_Trajet.Show()
        Me.Close()
        Gestion_Conducteur.Close()
        Gestion_garage.Close()
        Gestion_Marchandises.Close()
        Gestion_Véhicules.Close()
        Historiques.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur véhicule
    Private Sub Panel4_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click, Panel4.Click, Label15.Click
        Gestion_Véhicules.Show()
        Me.Close()
        Gestion_Conducteur.Close()
        Gestion_garage.Close()
        Gestion_Marchandises.Close()
        Gestion_Trajet.Close()
        Historiques.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur marchandise
    Private Sub Panel6_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click, Panel6.Click, Label13.Click
        Gestion_Marchandises.Show()
        Me.Close()
        Gestion_Conducteur.Close()
        Gestion_garage.Close()
        Gestion_Véhicules.Close()
        Gestion_Trajet.Close()
        Historiques.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur chargement de la deuXiemme fenetre  du tab control
    Private Sub His_User_Click(sender As Object, e As EventArgs) Handles His_User.Click
        charger_his()
    End Sub

    'afficher le datetimepicker
    Private Sub Rd_date_CheckedChanged_1(sender As Object, e As EventArgs) Handles Rd_date.CheckedChanged
        If Rd_date.Checked = True Then
            dat_lbl.Visible = True
        Else
            dat_lbl.Visible = False
        End If
    End Sub

    'filtrer l'historique
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        If Not log.Text.Trim.Equals("") And Rd_date.Checked = False Then
            Try
                DataGridHis_User.DataSource = metierH.getDataByLog(log.Text).Tables("Historiques_UsersByLog")
                DataGridHis_User.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un historique par le login de l'utilisateur", DateTime.Now, log.Text)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf log.Text.Trim.Equals("") And Rd_date.Checked = True Then
            Try
                DataGridHis_User.DataSource = metierH.getDataByDat(dat_lbl.Value).Tables("Historiques_UsersByDat")
                DataGridHis_User.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un historique par la date", DateTime.Now, (dat_lbl.Value.Date).ToString)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not log.Text.Trim.Equals("") And Rd_date.Checked = True Then
            Try
                DataGridHis_User.DataSource = metierH.getDataByDat_Log(log.Text, dat_lbl.Value).Tables("Historiques_UsersByDat&Log")
                DataGridHis_User.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un historique par le login de l'utilisateur et la date", DateTime.Now,
                                                (log.Text + "," + dat_lbl.Value.Date))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf log.Text.Trim.Equals("") And Rd_date.Checked = False Then
            Try
                charger_his()
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    'Afficher les details
    Private Sub DataGridHis_User_DoubleClick(sender As Object, e As EventArgs) Handles DataGridHis_User.DoubleClick
        For i As Int32 = 0 To DataGridHis_User.SelectedRows.Count - 1
            Dim IdH As Int32
            Try
                IdH = DataGridHis_User.SelectedRows(i).Cells(0).Value
                Dim his As Historiques_Users = metierH.getHis_UserById(IdH)
                DetailsDatagrid.L1.Visible = True
                DetailsDatagrid.L1.Text = "Nom_User"
                DetailsDatagrid.T1.Visible = True
                DetailsDatagrid.T1.Text = his.Utilisateur.Nom_User
                DetailsDatagrid.L4.Visible = True
                DetailsDatagrid.L4.Text = "Login"
                DetailsDatagrid.T4.Visible = True
                DetailsDatagrid.T4.Text = his.Utilisateur.Login_User
                DetailsDatagrid.L5.Visible = True
                DetailsDatagrid.L5.Text = "Type de l'opération"
                DetailsDatagrid.T5.Visible = True
                DetailsDatagrid.T5.Text = his.Type_Operation
                DetailsDatagrid.L8.Visible = True
                DetailsDatagrid.L8.Text = "Reference de l'opération"
                DetailsDatagrid.T8.Visible = True
                DetailsDatagrid.T8.Text = his.Ref_Operation
                DetailsDatagrid.L10.Visible = True
                DetailsDatagrid.L10.Text = "Date Opération"
                DetailsDatagrid.T10.Visible = True
                DetailsDatagrid.T10.Text = his.Date_Operation
                DetailsDatagrid.Show()
            Catch ex As Exception
                MessageBox.Show("le double-clic doit être sur une ligne pour cette operation", "avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        Next
    End Sub

    'clique sur conducteur
    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click, Panel10.Click, Label17.Click
        Gestion_Conducteur.Show()
        Me.Close()
        Gestion_Marchandises.Close()
        Gestion_garage.Close()
        Gestion_Véhicules.Close()
        Gestion_Trajet.Close()
        Historiques.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur mon compte
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click, Label3.Click
        Authentification.w = 1
        créer_un_Utilisateur.Show()
        Me.Hide()
        créer_un_Utilisateur.TitrPanelAddUser.Text = "Modifier un Utilisateur"
        If Authentification.use.Sexe_User = "Masculin" Then
            créer_un_Utilisateur.Mas_rd_lbl.Checked = True
            créer_un_Utilisateur.Fem_rd_lbl.Checked = False
        ElseIf Authentification.use.Sexe_User = "Féminin" Then
            créer_un_Utilisateur.Fem_rd_lbl.Checked = True
            créer_un_Utilisateur.Mas_rd_lbl.Checked = False
        End If
        créer_un_Utilisateur.NomUse_lbl.Text = Authentification.use.Nom_User
        créer_un_Utilisateur.PreUse_lbl.Text = Authentification.use.Prenom_User
        créer_un_Utilisateur.TelUse_lbl.Text = Authentification.use.Telephone_User
        créer_un_Utilisateur.EmaUse_lbl.Text = Authentification.use.Email_User
        créer_un_Utilisateur.AddUse_lbl.Text = Authentification.use.Adresse_User
        créer_un_Utilisateur.LogUse_lbl.Text = Authentification.use.Login_User
        créer_un_Utilisateur.MotUse_Lbl.Text = Authentification.use.Password_User
        créer_un_Utilisateur.MotConUse_lbl.Text = Authentification.use.Password_User
        créer_un_Utilisateur.StaUse_lbl.Enabled = False
        créer_un_Utilisateur.StaUse_lbl.Text = Authentification.use.Statut_User
    End Sub


End Class