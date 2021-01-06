Public Class Gestion_Conducteur

    Dim metierc As ChauffeursMetier = New ChauffeursMetier
    Dim metierH As Historiques_UsersMetier = New Historiques_UsersMetier
    Dim metierU As UtilisateursMetier = New UtilisateursMetier

    'chargement de la fenetre
    Private Sub Gestion_Conducteur_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Authentification.use.Statut_User = "Administrateur" Then
            Admin.Visible = True
        Else
            Admin.Visible = False
        End If
        Structurer_fenetre()
        Try
            charger()
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'clique sur Ajouter
    Private Sub AddCon_Click(sender As Object, e As EventArgs) Handles AddCon.Click
        retablir_fenetre()
        vider()
        Label2.Visible = True
        Updpic.Visible = False
        Titre_paneladdCon.Text = "Ajouter conducteur"
        UpdateCon.Enabled = False
        AffCon.Enabled = False
        DeleteCon.Enabled = False
    End Sub

    'clique sur Modifier
    Private Sub UpdateCon_Click(sender As Object, e As EventArgs) Handles UpdateCon.Click
        '''''Recuperer les info d'un conducteur pour les modifier''''''''''''
        Dim IdCon As Int32
        Try
            IdCon = DataGridCon.SelectedRows(0).Cells(0).Value
            retablir_fenetre()
            Label2.Visible = False
            Updpic.Visible = True
            Titre_paneladdCon.Text = "Modifier Conducteur"
            AddCon.Enabled = False
            AffCon.Enabled = False
            DeleteCon.Enabled = False
            Dim ch As Chauffeurs = metierc.getChauffeurById(IdCon)
            TypVehCon_lbl.Text = ch.Type_Vehicule_Conduit
            NomCon_lbl.Text = ch.Nom_Chauffeur
            PreCon_lbl.Text = ch.Prenom_Chauffeur
            SexCon_lbl.Text = ch.Sexe
            EmaCon_lbl.Text = ch.Email_chauffeur
            AdrCon_lbl.Text = ch.Adresse_chauffeur
            TelCon_lbl.Text = ch.Tel_Chauffeur
            DatNaiCon_lbl.Value = ch.Date_naiss
            If ch.Etat_Chauffeur = "Indisponible" Then
                Ind_rb_lbl.Checked = True
                Dis_rb_lbl.Checked = False
            ElseIf ch.Etat_Chauffeur = "Disponible" Then
                Ind_rb_lbl.Checked = False
                Dis_rb_lbl.Checked = True
            End If
        Catch ex As Exception
            MessageBox.Show("Selectionner un conducteur pour cette opération", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    'clique sur annuler sur le panel ajout Conducteur
    Private Sub AnnCon_Click(sender As Object, e As EventArgs) Handles AnnCon.Click
        Structurer_fenetre()
        vider()
        Try
            charger()
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        AddCon.Enabled = True
        UpdateCon.Enabled = True
        AffCon.Enabled = True
        DeleteCon.Enabled = True
    End Sub

    'Autoriser only les chiffres
    Dim chi() As Char = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", " "}
    Public Sub chiffre_only(e)
        If Not chi.Contains(e.keychar) And Not Asc(e.keychar) = 8 Then
            e.handled = True
        End If
    End Sub

    'fenetre avec data en grand
    Private Sub Structurer_fenetre()
        AddConPanel.Visible = False
        ConIma.Location = New Point(615, 16)
        ConIma.Size = New Size(183, 115)
        Cond.Location = New Point(836, 57)
        Cond.Size = New Size(101, 24)
        DataGridCon.Location = New Point(269, 353)
        DataGridCon.Size = New Size(1016, 329)
        Search.Visible = True
        Filt.Visible = True
        NomCon.Visible = True
        NomCon_fil.Visible = True
        PreCon.Visible = True
        PreCon_Fil.Visible = True
        EtaCon.Visible = True
        EtaCon_fil.Visible = True
        TypVehCon.Visible = True
        TypVehCon_Fil.Visible = True
        Filt.Location = New Point(284, 171)
        Filt.Size = New Size(88, 19)
        NomCon.Location = New Point(421, 220)
        NomCon.Size = New Size(38, 19)
        NomCon_fil.Location = New Point(484, 217)
        NomCon_fil.Size = New Size(171, 26)
        PreCon.Location = New Point(714, 222)
        PreCon.Size = New Size(55, 19)
        PreCon_Fil.Location = New Point(784, 216)
        PreCon_Fil.Size = New Size(171, 26)
        EtaCon.Location = New Point(326, 300)
        EtaCon.Size = New Size(34, 19)
        EtaCon_fil.Location = New Point(425, 297)
        EtaCon_fil.Size = New Size(300, 29)
        TypVehCon.Location = New Point(776, 301)
        TypVehCon.Size = New Size(165, 19)
        TypVehCon_Fil.Location = New Point(969, 297)
        TypVehCon_Fil.Size = New Size(131, 27)
        Search.Location = New Point(1024, 247)
        Search.Size = New Size(40, 40)

    End Sub

    'fenetre avec data redimentionner
    Private Sub retablir_fenetre()
        AddConPanel.Visible = True
        ConIma.Location = New Point(396, 14)
        ConIma.Size = New Size(169, 112)
        Cond.Location = New Point(596, 56)
        Cond.Size = New Size(101, 24)
        DataGridCon.Location = New Point(298, 166)
        DataGridCon.Size = New Size(564, 294)
        Search.Visible = False
        Filt.Visible = False
        NomCon.Visible = False
        NomCon_fil.Visible = False
        PreCon.Visible = False
        PreCon_Fil.Visible = False
        EtaCon.Visible = False
        EtaCon_fil.Visible = False
        Updpic.Visible = False
        TypVehCon.Visible = False
        TypVehCon_Fil.Visible = False
    End Sub

    'bloquer le champ de num telephone à recevoir que des chiffres
    Private Sub TelCon_lbl_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TelCon_lbl.KeyPress
        chiffre_only(e)
    End Sub

    'clique sur le boutton Enregistrer pour l'ajout ou La Modification d'un conducteur
    Private Sub EnrCon_Click(sender As Object, e As EventArgs) Handles EnrCon.Click
        Dim _EtaCon As String

        If Dis_rb_lbl.Checked = True Then
            _EtaCon = "Disponible"
        Else Ind_rb_lbl.Checked = True
            _EtaCon = "Indisponible"
        End If

        If Titre_paneladdCon.Text = "Ajouter conducteur" Then
            Try
                Dim _con = New Chauffeurs(TypVehCon_lbl.Text, NomCon_lbl.Text, PreCon_lbl.Text, SexCon_lbl.Text,
                           EmaCon_lbl.Text, AdrCon_lbl.Text, DatNaiCon_lbl.Value.Date, TelCon_lbl.Text, _EtaCon)
                metierc.AddChauffeurs(_con)
                Dim no As String = NomCon_lbl.Text
                vider()
                MessageBox.Show(Me, "Conducteur ajouté avec succée", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Ajout d'un conducteur", DateTime.Now, no)
                metierH.AddHis_User(his)
                charger()
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error 505", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf Titre_paneladdCon.Text = "Modifier Conducteur" Then
            Try
                Dim IdCon As Int32 = DataGridCon.SelectedRows(0).Cells(0).Value
                Dim _co = New Chauffeurs(IdCon, TypVehCon_lbl.Text, NomCon_lbl.Text, PreCon_lbl.Text, SexCon_lbl.Text,
                           EmaCon_lbl.Text, AdrCon_lbl.Text, DatNaiCon_lbl.Value.Date, TelCon_lbl.Text, _EtaCon)
                metierc.UpdateChauffeurs(_co)
                Dim no As String = NomCon_lbl.Text
                vider()
                MessageBox.Show(Me, "Modification réussite", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Modification des caracteristiques d'un conducteur", DateTime.Now, no)
                metierH.AddHis_User(his)
                charger()
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error 505", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    'Vider tous les champs
    Private Sub vider()
        TypVehCon_lbl.Text = ""
        NomCon_lbl.Text = ""
        PreCon_lbl.Text = ""
        SexCon_lbl.Text = ""
        EmaCon_lbl.Text = ""
        AdrCon_lbl.Text = ""
        TelCon_lbl.Text = "+"
        DatNaiCon_lbl.Value = Date.Now.AddDays(-6570)
        Ind_rb_lbl.Checked = False
        Dis_rb_lbl.Checked = False
    End Sub

    'chargé data grid
    Private Sub charger()
        DataGridCon.DataSource = metierc.getData().Tables("Chauffeur")
        DataGridCon.Columns()(0).Visible = False
    End Sub

    'Supprimer des élements
    Private Sub DeleteCon_Click(sender As Object, e As EventArgs) Handles DeleteCon.Click
        Dim rsult As DialogResult = MessageBox.Show("Etes-vous sûr(e) de vouloir supprimer", "Confirmation",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If rsult = Windows.Forms.DialogResult.Yes Then
            For i As Int32 = 0 To DataGridCon.SelectedRows.Count - 1
                Dim IdCon As Int32
                Try
                    IdCon = DataGridCon.SelectedRows(i).Cells(0).Value
                    Try
                        Dim no As String = DataGridCon.SelectedRows(i).Cells(2).Value
                        metierc.DeleteChauffeurs(IdCon)
                        Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Suppression d'un conducteur", DateTime.Now, no)
                        metierH.AddHis_User(his)
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Catch ex As Exception
                    MessageBox.Show("Selectionner un conducteur au moins pour cette opération", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            Next
            Try
                charger()
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Structurer_fenetre()
            Try
                charger()
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    'filtrer le data grid
    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click
        Dim etafil As String
        If Dis_fil_rb.Checked = True Then
            etafil = "Disponible"
        ElseIf Ind_fil_rb.Checked = True Then
            etafil = "Indisponible"
        End If

        If Not NomCon_fil.Text.Trim().Equals("") And PreCon_Fil.Text.Trim().Equals("") And Dis_fil_rb.Checked = False And Ind_fil_rb.Checked = False And TypVehCon_Fil.Text.Trim().Equals("") Then
            Try
                DataGridCon.DataSource = metierc.getDataByNom(NomCon_fil.Text).Tables("ChauffeurByNom")
                DataGridCon.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un conducteur par le nom", DateTime.Now, NomCon_fil.Text)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NomCon_fil.Text.Trim().Equals("") And Not PreCon_Fil.Text.Trim().Equals("") And Dis_fil_rb.Checked = False And Ind_fil_rb.Checked = False And TypVehCon_Fil.Text.Trim().Equals("") Then
            Try
                DataGridCon.DataSource = metierc.getDataByPre(PreCon_Fil.Text).Tables("ChauffeurByPre")
                DataGridCon.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un conducteur par le prenom", DateTime.Now, PreCon_Fil.Text)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NomCon_fil.Text.Trim().Equals("") And Not PreCon_Fil.Text.Trim().Equals("") And Dis_fil_rb.Checked = False And Ind_fil_rb.Checked = False And TypVehCon_Fil.Text.Trim().Equals("") Then
            Try
                DataGridCon.DataSource = metierc.getDataByNon_Pre(NomCon_fil.Text, PreCon_Fil.Text).Tables("ChauffeurByNom&Pre")
                DataGridCon.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un conducteur par le nom et le prenom", DateTime.Now, (NomCon_fil.Text + "," + PreCon_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NomCon_fil.Text.Trim().Equals("") And PreCon_Fil.Text.Trim().Equals("") And (Dis_fil_rb.Checked = True Or Ind_fil_rb.Checked = True) And TypVehCon_Fil.Text.Trim().Equals("") Then
            Try
                DataGridCon.DataSource = metierc.getDataByEta(etafil).Tables("ChauffeurByEta")
                DataGridCon.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un conducteur par son etat", DateTime.Now, etafil)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NomCon_fil.Text.Trim().Equals("") And PreCon_Fil.Text.Trim().Equals("") And (Dis_fil_rb.Checked = True Or Ind_fil_rb.Checked = True) And TypVehCon_Fil.Text.Trim().Equals("") Then
            Try
                DataGridCon.DataSource = metierc.getDataByNon_Eta(NomCon_fil.Text, etafil).Tables("ChauffeurByNom&Eta")
                DataGridCon.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un conducteur par le nom et l'etat", DateTime.Now, (NomCon_fil.Text + "," + etafil))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NomCon_fil.Text.Trim().Equals("") And Not PreCon_Fil.Text.Trim().Equals("") And (Dis_fil_rb.Checked = True Or Ind_fil_rb.Checked = True) And TypVehCon_Fil.Text.Trim().Equals("") Then
            Try
                DataGridCon.DataSource = metierc.getDataByPre_Eta(PreCon_Fil.Text, etafil).Tables("ChauffeurByPre&Eta")
                DataGridCon.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un conducteur par le prenom et l'etat", DateTime.Now, (PreCon_Fil.Text + "," + etafil))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NomCon_fil.Text.Trim().Equals("") And Not PreCon_Fil.Text.Trim().Equals("") And (Dis_fil_rb.Checked = True Or Ind_fil_rb.Checked = True) And TypVehCon_Fil.Text.Trim().Equals("") Then
            Try
                DataGridCon.DataSource = metierc.getDataByNom_Pre_Eta(NomCon_fil.Text, PreCon_Fil.Text, etafil).Tables("ChauffeurByNom&Pre&Eta")
                DataGridCon.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un conducteur par le nom, le prenom et l'etat", DateTime.Now,
                                                (NomCon_fil.Text + "," + PreCon_Fil.Text + "," + etafil))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NomCon_fil.Text.Trim().Equals("") And PreCon_Fil.Text.Trim().Equals("") And Dis_fil_rb.Checked = False And Ind_fil_rb.Checked = False And Not TypVehCon_Fil.Text.Trim().Equals("") Then
            Try
                DataGridCon.DataSource = metierc.getDataByTyp(TypVehCon_Fil.Text).Tables("ChauffeurByTyp")
                DataGridCon.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un conducteur par le type de vehicule conduit", DateTime.Now, TypVehCon_Fil.Text)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NomCon_fil.Text.Trim().Equals("") And PreCon_Fil.Text.Trim().Equals("") And Dis_fil_rb.Checked = False And Ind_fil_rb.Checked = False And Not TypVehCon_Fil.Text.Trim().Equals("") Then
            Try
                DataGridCon.DataSource = metierc.getDataByNon_Typ(NomCon_fil.Text, TypVehCon_Fil.Text).Tables("ChauffeurByNom&Typ")
                DataGridCon.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un conducteur par le nom et le type de vehicule conduit", DateTime.Now,
                                                 (NomCon_fil.Text + "," + TypVehCon_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NomCon_fil.Text.Trim().Equals("") And Not PreCon_Fil.Text.Trim().Equals("") And Dis_fil_rb.Checked = False And Ind_fil_rb.Checked = False And Not TypVehCon_Fil.Text.Trim().Equals("") Then
            Try
                DataGridCon.DataSource = metierc.getDataByPre_Typ(PreCon_Fil.Text, TypVehCon_Fil.Text).Tables("ChauffeurByPre&Typ")
                DataGridCon.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un conducteur par le prenom et le type de vehicule conduit", DateTime.Now,
                                               (PreCon_Fil.Text + "," + TypVehCon_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NomCon_fil.Text.Trim().Equals("") And PreCon_Fil.Text.Trim().Equals("") And (Dis_fil_rb.Checked = True Or Ind_fil_rb.Checked = True) And Not TypVehCon_Fil.Text.Trim().Equals("") Then
            Try
                DataGridCon.DataSource = metierc.getDataByEta_Typ(etafil, TypVehCon_Fil.Text).Tables("ChauffeurByEta&Typ")
                DataGridCon.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un conducteur par l'etat et le type de vehicule conduit", DateTime.Now,
                                              (etafil + "," + TypVehCon_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NomCon_fil.Text.Trim().Equals("") And Not PreCon_Fil.Text.Trim().Equals("") And Dis_fil_rb.Checked = False And Ind_fil_rb.Checked = False And Not TypVehCon_Fil.Text.Trim().Equals("") Then
            Try
                DataGridCon.DataSource = metierc.getDataByNom_Pre_Typ(NomCon_fil.Text, PreCon_Fil.Text, TypVehCon_Fil.Text).Tables("ChauffeurByNom&Pre&Typ")
                DataGridCon.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un conducteur par le nom,le prenom et le type de vehicule conduit", DateTime.Now,
                                              (NomCon_fil.Text + "," + PreCon_Fil.Text + "," + TypVehCon_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NomCon_fil.Text.Trim().Equals("") And PreCon_Fil.Text.Trim().Equals("") And (Dis_fil_rb.Checked = True Or Ind_fil_rb.Checked = True) And Not TypVehCon_Fil.Text.Trim().Equals("") Then
            Try
                DataGridCon.DataSource = metierc.getDataByNom_Eta_Typ(NomCon_fil.Text, etafil, TypVehCon_Fil.Text).Tables("ChauffeurByNom&Eta&Typ")
                DataGridCon.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un conducteur par le nom,l'etat et le type de vehicule conduit", DateTime.Now,
                                             (NomCon_fil.Text + "," + etafil + "," + TypVehCon_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NomCon_fil.Text.Trim().Equals("") And Not PreCon_Fil.Text.Trim().Equals("") And (Dis_fil_rb.Checked = True Or Ind_fil_rb.Checked = True) And Not TypVehCon_Fil.Text.Trim().Equals("") Then
            Try
                DataGridCon.DataSource = metierc.getDataByPre_Eta_Typ(PreCon_Fil.Text, etafil, TypVehCon_Fil.Text).Tables("ChauffeurByPre&Eta&Typ")
                DataGridCon.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un conducteur par le prenom,l'etat et le type de vehicule conduit", DateTime.Now,
                                             (PreCon_Fil.Text + "," + etafil + "," + TypVehCon_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NomCon_fil.Text.Trim().Equals("") And Not PreCon_Fil.Text.Trim().Equals("") And (Dis_fil_rb.Checked = True Or Ind_fil_rb.Checked = True) And Not TypVehCon_Fil.Text.Trim().Equals("") Then
            Try
                DataGridCon.DataSource = metierc.getDataByNom_Pre_Eta_Typ(NomCon_fil.Text, PreCon_Fil.Text, etafil, TypVehCon_Fil.Text).Tables("ChauffeurByNom&Pre&Eta&Typ")
                DataGridCon.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un conducteur par le nom, le prenom,l'etat et le type de vehicule conduit", DateTime.Now,
                                            (NomCon_fil.Text + "," + PreCon_Fil.Text + "," + etafil + "," + TypVehCon_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NomCon_fil.Text.Trim().Equals("") And PreCon_Fil.Text.Trim().Equals("") And Dis_fil_rb.Checked = False And Ind_fil_rb.Checked = False And TypVehCon_Fil.Text.Trim().Equals("") Then
            Try
                charger()
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    'affectation conducteur pour un trajet
    Private Sub AffCon_Click(sender As Object, e As EventArgs) Handles AffCon.Click
        Try
            Dim IdCon As Int32 = DataGridCon.SelectedRows(0).Cells(0).Value
            Dim Chauf As Chauffeurs = metierc.getChauffeurById(IdCon)
            If Chauf.Etat_Chauffeur = "Disponible" Then
                Gestion_Trajet.NomCon_Tra.Text = Chauf.Nom_Chauffeur
                Gestion_Trajet.PreCon_Tra.Text = Chauf.Prenom_Chauffeur
                Gestion_Trajet.TelCon_Tra.Text = Chauf.Tel_Chauffeur
                Gestion_Trajet.IdCh.Text = IdCon
                Gestion_Trajet.Show()
                Me.Hide()
            Else
                MessageBox.Show("Ce chauffeur est Indisponible", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Selectionner un conducteur pour cette opération", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    'Double clique sur le datagrid
    Private Sub DataGridCon_DoubleClick(sender As Object, e As EventArgs) Handles DataGridCon.DoubleClick
        For i As Int32 = 0 To DataGridCon.SelectedRows.Count - 1
            Dim IdCon As Int32
            Try
                IdCon = DataGridCon.SelectedRows(i).Cells(0).Value
                Dim ch As Chauffeurs = metierc.getChauffeurById(IdCon)
                DetailsDatagrid.L1.Visible = True
                DetailsDatagrid.L1.Text = "Nom"
                DetailsDatagrid.T1.Visible = True
                DetailsDatagrid.T1.Text = ch.Nom_Chauffeur
                DetailsDatagrid.L2.Visible = True
                DetailsDatagrid.L2.Text = "Prénom"
                DetailsDatagrid.T2.Visible = True
                DetailsDatagrid.T2.Text = ch.Prenom_Chauffeur
                DetailsDatagrid.L3.Visible = True
                DetailsDatagrid.L3.Text = "Type de véhicule conduit"
                DetailsDatagrid.T3.Visible = True
                DetailsDatagrid.T3.Text = ch.Type_Vehicule_Conduit
                DetailsDatagrid.L4.Visible = True
                DetailsDatagrid.L4.Text = "Sexe"
                DetailsDatagrid.T4.Visible = True
                DetailsDatagrid.T4.Text = ch.Sexe
                DetailsDatagrid.L5.Visible = True
                DetailsDatagrid.L5.Text = "Télephone"
                DetailsDatagrid.T5.Visible = True
                DetailsDatagrid.T5.Text = ch.Tel_Chauffeur
                DetailsDatagrid.L6.Visible = True
                DetailsDatagrid.L6.Text = "Email"
                DetailsDatagrid.T6.Visible = True
                DetailsDatagrid.T6.Text = ch.Email_chauffeur
                DetailsDatagrid.L7.Visible = True
                DetailsDatagrid.L7.Text = "Date naissance"
                DetailsDatagrid.T7.Visible = True
                DetailsDatagrid.T7.Text = ch.Date_naiss
                DetailsDatagrid.L8.Visible = True
                DetailsDatagrid.L8.Text = "Adresse"
                DetailsDatagrid.T8.Visible = True
                DetailsDatagrid.T8.Text = ch.Adresse_chauffeur
                DetailsDatagrid.L9.Visible = True
                DetailsDatagrid.L9.Text = "Etat"
                DetailsDatagrid.T9.Visible = True
                DetailsDatagrid.T9.Text = ch.Etat_Chauffeur
                DetailsDatagrid.Show()
            Catch ex As Exception
                MessageBox.Show("Le double-clic doit être sur un conducteur pour cette operation", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        Next
    End Sub

    'clique sur Administration
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click, Label8.Click, Admin.Click
        Administration.Show()
        Me.Close()
        Gestion_Trajet.Close()
        Gestion_garage.Close()
        Gestion_Marchandises.Close()
        Gestion_Véhicules.Close()
        Historiques.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur historiques
    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click, Panel5.Click, Label14.Click
        Historiques.Show()
        Me.Close()
        Administration.Close()
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
        Historiques.Close()
        Gestion_garage.Close()
        Gestion_Marchandises.Close()
        Gestion_Véhicules.Close()
        Administration.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur véhicule
    Private Sub Panel4_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click, Panel4.Click, Label15.Click
        Gestion_Véhicules.Show()
        Me.Close()
        Administration.Close()
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
        Historiques.Close()
        Gestion_garage.Close()
        Gestion_Véhicules.Close()
        Gestion_Trajet.Close()
        Administration.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur mon compte
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click, Label3.Click
        '''''Recuperer les info d'un Utilisateur pour les modifier''''''''''''
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