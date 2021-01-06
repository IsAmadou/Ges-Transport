Public Class Gestion_Véhicules

    Dim metierV As VéhiculesMetier = New VéhiculesMetier()
    Dim metierP As Pièces_VehiculeMetier = New Pièces_VehiculeMetier()
    Dim metierU As UtilisateursMetier = New UtilisateursMetier
    Dim metierH As Historiques_UsersMetier = New Historiques_UsersMetier

    'Chargement de la fenetre
    Private Sub Gestion_Véhicules_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Authentification.use.Statut_User = "Administrateur" Then
            Admin.Visible = True
            AddVeh.Visible = True
        Else
            Admin.Visible = False
            AddVeh.Visible = False
        End If

        Try
            charger()
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'clique sur ajouter un Véhicule
    Private Sub AddVeh_Click(sender As Object, e As EventArgs) Handles AddVeh.Click
        Ajouter_un_Vehicule_et_ses_Pieces.UpdateVeh.Visible = False
        Ajouter_un_Vehicule_et_ses_Pieces.Show()
        'Me.Hide()
    End Sub

    'clique sur modifier un vehicule
    Private Sub UpdateVeh_Click(sender As Object, e As EventArgs) Handles UpdateVeh.Click
        ' Try
        Dim Imm As String = DataGridVeh.SelectedRows(0).Cells(0).Value
            Dim IdP As Integer = DataGridVeh.SelectedRows(0).Cells(7).Value
            Ajouter_un_Vehicule_et_ses_Pieces.Show()
            Ajouter_un_Vehicule_et_ses_Pieces.TitrAddVeh.Text = "Modifier un Véhicule"
            Ajouter_un_Vehicule_et_ses_Pieces.UpdateVeh.Visible = True

            Dim _veh As Véhicules = metierV.getVehiculeByImm(Imm)
            Dim _Pie As Pièces_Vehicule = metierP.getPieces_VehiculeById(IdP)
            If _veh.Etat_Véhicule = "Indisponible" Then
                Ajouter_un_Vehicule_et_ses_Pieces.Ind_rb.Checked = True
                Ajouter_un_Vehicule_et_ses_Pieces.Disp_rb.Checked = False
            Else _veh.Etat_Véhicule = "Disponible"
                Ajouter_un_Vehicule_et_ses_Pieces.Ind_rb.Checked = False
                Ajouter_un_Vehicule_et_ses_Pieces.Disp_rb.Checked = True
            End If

            If _Pie.Carte_grise = "Oui" Then
                Ajouter_un_Vehicule_et_ses_Pieces.Oui_rb.Checked = True
                Ajouter_un_Vehicule_et_ses_Pieces.Non_rb.Checked = False
            ElseIf _Pie.Carte_grise = "Non" Then
                Ajouter_un_Vehicule_et_ses_Pieces.Oui_rb.Checked = False
                Ajouter_un_Vehicule_et_ses_Pieces.Non_rb.Checked = True
            End If
        Ajouter_un_Vehicule_et_ses_Pieces.Id_p.Text = IdP
        Ajouter_un_Vehicule_et_ses_Pieces.Imm_lbl.Text = _veh.Immatriculation
            Ajouter_un_Vehicule_et_ses_Pieces.Typ_lbl.Text = _veh.Type
            Ajouter_un_Vehicule_et_ses_Pieces.Mod_lbl.Text = _veh.Modèle
            Ajouter_un_Vehicule_et_ses_Pieces.Châ_lbl.Text = _veh.Nchâssis
            Ajouter_un_Vehicule_et_ses_Pieces.TypM_lbl.Text = _veh.Type_de_Moteur
            Ajouter_un_Vehicule_et_ses_Pieces.Cap_lbl.Text = _veh.Capacité
            Ajouter_un_Vehicule_et_ses_Pieces.Vig_lbl.Text = _Pie.Vignette
        Ajouter_un_Vehicule_et_ses_Pieces.Ass_lbl.Text = _Pie.Assurance

        If _Pie.Vignette = "Oui" Then
            Ajouter_un_Vehicule_et_ses_Pieces.DatExpVig_lbl.Value = _Pie.Date_ExpVignette
            Ajouter_un_Vehicule_et_ses_Pieces.DatExpVig_lbl.Visible = True
        Else
            Ajouter_un_Vehicule_et_ses_Pieces.DatExpVig_lbl.Visible = False
        End If
        If _Pie.Assurance = "Oui" Then
            Ajouter_un_Vehicule_et_ses_Pieces.DatExpAss_lbl.Value = _Pie.Date_ExpAssurance
            Ajouter_un_Vehicule_et_ses_Pieces.DatExpAss_lbl.Visible = True
        Else
            Ajouter_un_Vehicule_et_ses_Pieces.DatExpAss_lbl.Visible = False
        End If
        'Catch ex As Exception
        '    MessageBox.Show("Un élement selectionner au minimun est requis pour cette opération", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End Try

    End Sub

    'chargé data grid
    Public Sub charger()
        DataGridVeh.DataSource = metierV.getData().Tables("Vehicules")
        DataGridVeh.Columns()(7).Visible = False
    End Sub

    'filtrer le data grid
    Private Sub Search_Click_1(sender As Object, e As EventArgs) Handles Search.Click
        Dim _Eta As String
        If Dis_rd_Fil.Checked = True Then
            _Eta = "Disponible"
        ElseIf Ind_rd_Fil.Checked = True Then
            _Eta = "Indisponible"
        End If

        If Not ImmVeh_Fil.Text.Trim.Equals("") And TypVeh_Fil.Text.Trim.Equals("") And Dis_rd_Fil.Checked = False And Ind_rd_Fil.Checked = False And CapVeh_Fil.Text.Trim.Equals("") And Date_fil.Value.Date = Date.Now.Date Then
            Try
                DataGridVeh.DataSource = metierV.getDataByImm(ImmVeh_Fil.Text).Tables("VehiculesByImm")
                DataGridVeh.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un vehicule par l'immatriculation", DateTime.Now, ImmVeh_Fil.Text)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf ImmVeh_Fil.Text.Trim.Equals("") And Not TypVeh_Fil.Text.Trim.Equals("") And Dis_rd_Fil.Checked = False And Ind_rd_Fil.Checked = False And CapVeh_Fil.Text.Trim.Equals("") And Date_fil.Value.Date = Date.Now.Date Then
            Try
                DataGridVeh.DataSource = metierV.getDataByTypVeh(TypVeh_Fil.Text).Tables("VehiculesByTypVeh")
                DataGridVeh.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un vehicule par le type", DateTime.Now, TypVeh_Fil.Text)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not ImmVeh_Fil.Text.Trim.Equals("") And Not TypVeh_Fil.Text.Trim.Equals("") And Dis_rd_Fil.Checked = False And Ind_rd_Fil.Checked = False And CapVeh_Fil.Text.Trim.Equals("") And Date_fil.Value.Date = Date.Now.Date Then
            Try
                DataGridVeh.DataSource = metierV.getDataByImm_TypVeh(ImmVeh_Fil.Text, TypVeh_Fil.Text).Tables("VehiculesByImm&TypVeh")
                DataGridVeh.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un vehicule par l'immatriculation et le type", DateTime.Now, (ImmVeh_Fil.Text + "," + TypVeh_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf ImmVeh_Fil.Text.Trim.Equals("") And TypVeh_Fil.Text.Trim.Equals("") And (Dis_rd_Fil.Checked = True Or Ind_rd_Fil.Checked = True) And CapVeh_Fil.Text.Trim.Equals("") And Date_fil.Value.Date = Date.Now.Date Then
            Try
                DataGridVeh.DataSource = metierV.getDataByEta(_Eta).Tables("VehiculesByEta")
                DataGridVeh.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un vehicule par l'etat", DateTime.Now, _Eta)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not ImmVeh_Fil.Text.Trim.Equals("") And TypVeh_Fil.Text.Trim.Equals("") And (Dis_rd_Fil.Checked = True Or Ind_rd_Fil.Checked = True) And CapVeh_Fil.Text.Trim.Equals("") And Date_fil.Value.Date = Date.Now.Date Then
            Try
                DataGridVeh.DataSource = metierV.getDataByImm_Eta(ImmVeh_Fil.Text, _Eta).Tables("VehiculesByImm&Eta")
                DataGridVeh.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un vehicule par l'immatriculation et l'etat", DateTime.Now, (ImmVeh_Fil.Text + "," + _Eta))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf ImmVeh_Fil.Text.Trim.Equals("") And Not TypVeh_Fil.Text.Trim.Equals("") And (Dis_rd_Fil.Checked = True Or Ind_rd_Fil.Checked = True) And CapVeh_Fil.Text.Trim.Equals("") And Date_fil.Value.Date = Date.Now.Date Then
            Try
                DataGridVeh.DataSource = metierV.getDataByTypVeh_Eta(TypVeh_Fil.Text, _Eta).Tables("VehiculesByTypVeh&Eta")
                DataGridVeh.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un vehicule par le type et l'etat", DateTime.Now, (TypVeh_Fil.Text + "," + _Eta))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not ImmVeh_Fil.Text.Trim.Equals("") And Not TypVeh_Fil.Text.Trim.Equals("") And (Dis_rd_Fil.Checked = True Or Ind_rd_Fil.Checked = True) And CapVeh_Fil.Text.Trim.Equals("") And Date_fil.Value.Date = Date.Now.Date Then
            Try
                DataGridVeh.DataSource = metierV.getDataByImm_TypVeh_Eta(ImmVeh_Fil.Text, TypVeh_Fil.Text, _Eta).Tables("VehiculesByImm&TypVeh&Eta")
                DataGridVeh.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un vehicule par l'immatriculation,le type et l'etat", DateTime.Now,
                                                (ImmVeh_Fil.Text + "," + TypVeh_Fil.Text + "," + _Eta))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf ImmVeh_Fil.Text.Trim.Equals("") And TypVeh_Fil.Text.Trim.Equals("") And Dis_rd_Fil.Checked = False And Ind_rd_Fil.Checked = False And Not CapVeh_Fil.Text.Trim.Equals("") And Date_fil.Value.Date = Date.Now.Date Then
            Try
                DataGridVeh.DataSource = metierV.getDataByCap(CapVeh_Fil.Text).Tables("VehiculesByCap")
                DataGridVeh.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un vehicule par la capacité", DateTime.Now, CapVeh_Fil.Text)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not ImmVeh_Fil.Text.Trim.Equals("") And TypVeh_Fil.Text.Trim.Equals("") And Dis_rd_Fil.Checked = False And Ind_rd_Fil.Checked = False And Not CapVeh_Fil.Text.Trim.Equals("") And Date_fil.Value.Date = Date.Now.Date Then
            Try
                DataGridVeh.DataSource = metierV.getDataByImm_Cap(ImmVeh_Fil.Text, CapVeh_Fil.Text).Tables("VehiculesByImm&Cap")
                DataGridVeh.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un vehicule par l'immatriculation et la capacité", DateTime.Now,
                                                (ImmVeh_Fil.Text + "," + CapVeh_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf ImmVeh_Fil.Text.Trim.Equals("") And Not TypVeh_Fil.Text.Trim.Equals("") And Dis_rd_Fil.Checked = False And Ind_rd_Fil.Checked = False And Not CapVeh_Fil.Text.Trim.Equals("") And Date_fil.Value.Date = Date.Now.Date Then
            Try
                DataGridVeh.DataSource = metierV.getDataByTypVeh_Cap(TypVeh_Fil.Text, CapVeh_Fil.Text).Tables("VehiculesByTypVeh&Cap")
                DataGridVeh.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un vehicule par le type et la capacité", DateTime.Now,
                                               (TypVeh_Fil.Text + "," + CapVeh_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not ImmVeh_Fil.Text.Trim.Equals("") And Not TypVeh_Fil.Text.Trim.Equals("") And Dis_rd_Fil.Checked = False And Ind_rd_Fil.Checked = False And Not CapVeh_Fil.Text.Trim.Equals("") And Date_fil.Value.Date = Date.Now.Date Then
            Try
                DataGridVeh.DataSource = metierV.getDataByImm_TypVeh_Cap(ImmVeh_Fil.Text, TypVeh_Fil.Text, CapVeh_Fil.Text).Tables("VehiculesByImm&TypVeh&Cap")
                DataGridVeh.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un vehicule par l'immatriculation, le type et la capacité", DateTime.Now,
                                             (ImmVeh_Fil.Text + "," + TypVeh_Fil.Text + "," + CapVeh_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf ImmVeh_Fil.Text.Trim.Equals("") And TypVeh_Fil.Text.Trim.Equals("") And (Dis_rd_Fil.Checked = True Or Ind_rd_Fil.Checked = True) And Not CapVeh_Fil.Text.Trim.Equals("") And Date_fil.Value.Date = Date.Now.Date Then
            Try
                DataGridVeh.DataSource = metierV.getDataByEta_Cap(_Eta, CapVeh_Fil.Text).Tables("VehiculesByEta&Cap")
                DataGridVeh.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un vehicule par l'etat et la capacité", DateTime.Now,
                                            (_Eta + "," + CapVeh_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not ImmVeh_Fil.Text.Trim.Equals("") And TypVeh_Fil.Text.Trim.Equals("") And (Dis_rd_Fil.Checked = True Or Ind_rd_Fil.Checked = True) And Not CapVeh_Fil.Text.Trim.Equals("") And Date_fil.Value.Date = Date.Now.Date Then
            Try
                DataGridVeh.DataSource = metierV.getDataByImm_Eta_Cap(ImmVeh_Fil.Text, _Eta, CapVeh_Fil.Text).Tables("VehiculesByImm&Eta&Cap")
                DataGridVeh.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un vehicule par l'immatriculation, l'etat et la capacité", DateTime.Now,
                                            (ImmVeh_Fil.Text + "," + _Eta + "," + CapVeh_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf ImmVeh_Fil.Text.Trim.Equals("") And Not TypVeh_Fil.Text.Trim.Equals("") And (Dis_rd_Fil.Checked = True Or Ind_rd_Fil.Checked = True) And Not CapVeh_Fil.Text.Trim.Equals("") And Date_fil.Value.Date = Date.Now.Date Then
            Try
                DataGridVeh.DataSource = metierV.getDataByTypVeh_Eta_Cap(TypVeh_Fil.Text, _Eta, CapVeh_Fil.Text).Tables("VehiculesByTypVeh&Eta&Cap")
                DataGridVeh.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un vehicule par le type, l'etat et la capacité", DateTime.Now,
                                            (TypVeh_Fil.Text + "," + _Eta + "," + CapVeh_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not ImmVeh_Fil.Text.Trim.Equals("") And Not TypVeh_Fil.Text.Trim.Equals("") And (Dis_rd_Fil.Checked = True Or Ind_rd_Fil.Checked = True) And Not CapVeh_Fil.Text.Trim.Equals("") And Date_fil.Value.Date = Date.Now.Date Then
            Try
                DataGridVeh.DataSource = metierV.getDataByImm_TypVeh_Eta_Cap(ImmVeh_Fil.Text, TypVeh_Fil.Text, _Eta, CapVeh_Fil.Text).Tables("VehiculesByImm&TypVeh&Eta&Cap")
                DataGridVeh.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un vehicule par l'immatriculation, le type, l'etat et la capacité", DateTime.Now,
                                            (ImmVeh_Fil.Text + "," + TypVeh_Fil.Text + "," + _Eta + "," + CapVeh_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf ImmVeh_Fil.Text.Trim.Equals("") And TypVeh_Fil.Text.Trim.Equals("") And Dis_rd_Fil.Checked = False And Ind_rd_Fil.Checked = False And CapVeh_Fil.Text.Trim.Equals("") And Date_fil.Value.Date = Date.Now.Date Then
            Try
                charger()
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    ' bloqué la capacite à ne recevoir que chiffre
    Private Sub CapVeh_Fil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CapVeh_Fil.KeyPress
        Gestion_Marchandises.chiffre_onlyDouble(e)
    End Sub

    'Supprimer les elements du data
    Private Sub DeleteVeh_Click(sender As Object, e As EventArgs) Handles DeleteVeh.Click
        Dim rsult As DialogResult = MessageBox.Show("Cela entrainera la suppression de tout ce qui concerne ce(e) véhicule(s),Etes-vous sûr(e) de vouloir supprimer", "Confirmation",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If rsult = Windows.Forms.DialogResult.Yes Then
            For i As Int32 = 0 To DataGridVeh.SelectedRows.Count - 1
                Dim IdVeh As String
                Try
                    IdVeh = DataGridVeh.SelectedRows(i).Cells(0).Value
                    Try
                        metierV.DeleteVehicules(IdVeh)
                        Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Suppression d'un vehicule", DateTime.Now, IdVeh)
                        metierH.AddHis_User(his)
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Catch ex As Exception
                    MessageBox.Show("Selectionner un vehicule pour cette opération", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

    'Affecter vehicule à un trajet
    Private Sub AddTra_Click(sender As Object, e As EventArgs) Handles AddTra.Click
        Try
            Dim IdVeh As String = DataGridVeh.SelectedRows(0).Cells(0).Value
            Dim Veh As Véhicules = metierV.getVehiculeByImm(IdVeh)
            Dim Idp As Int32 = DataGridVeh.SelectedRows(0).Cells(7).Value
            Dim Pie As Pièces_Vehicule = metierP.getPieces_VehiculeById(Idp)
            If Veh.Etat_Véhicule = "Disponible" Then
                If Pie.Assurance = "Oui" And Pie.Carte_grise = "Oui" And Pie.Vignette = "Oui" And Pie.Date_ExpVignette > Date.Now And Pie.Date_ExpAssurance > Date.Now Then
                    Gestion_Trajet.ImmVeh_Tra.Text = Veh.Immatriculation
                    Gestion_Trajet.CapVeh_Tra.Text = Veh.Capacité
                    Gestion_Trajet.TypVeh_Tra.Text = Veh.Type
                    Gestion_Trajet.ModVeh_Tra.Text = Veh.Modèle
                    Gestion_Trajet.Capt_Veh.Text = Veh.Capacité
                    Gestion_Trajet.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Ce véhicule n'est pas en règle pour effectuer un déplacement", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Ce véhicule est indisponible", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Selectionner un vehicule pour cette opération", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    'Ajouter une visite technique
    Private Sub RepVeh_Click(sender As Object, e As EventArgs) Handles RepVeh.Click
        Try
            Dim IdVeh As String = DataGridVeh.SelectedRows(0).Cells(0).Value
            Dim Veh As Véhicules = metierV.getVehiculeByImm(IdVeh)
            Gestion_garage.ImmVeh_Rep.Text = Veh.Immatriculation
            Gestion_garage.ModVeh_Rep.Text = Veh.Modèle
            Gestion_garage.TypVeh_Rep.Text = Veh.Type
            Gestion_garage.Show()
        Catch ex As Exception
            MessageBox.Show("Selectionner un vehicule pour cette opération", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    'clique sur Administration
    Private Sub Admin_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click, Label9.Click, Admin.Click
        Administration.Show()
        Me.Close()
        Gestion_Conducteur.Close()
        Gestion_garage.Close()
        Gestion_Marchandises.Close()
        Gestion_Trajet.Close()
        Historiques.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur historique
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click, Panel5.Click, Label4.Click
        Historiques.Show()
        Me.Close()
        Gestion_Conducteur.Close()
        Gestion_garage.Close()
        Gestion_Marchandises.Close()
        Administration.Close()
        Gestion_Trajet.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur trajet
    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click, Panel9.Click, Label2.Click
        Gestion_Trajet.Show()
        Me.Close()
        Gestion_Conducteur.Close()
        Gestion_garage.Close()
        Gestion_Marchandises.Close()
        Historiques.Close()
        Administration.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur marchandise
    Private Sub Panel6_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click, Panel6.Click, Label5.Click
        Gestion_Marchandises.Show()
        Me.Close()
        Gestion_Conducteur.Close()
        Gestion_garage.Close()
        Historiques.Close()
        Gestion_Trajet.Close()
        Administration.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'Clique sur conducteur
    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click, Panel10.Click, Label7.Click
        Gestion_Conducteur.Show()
        Me.Close()
        Gestion_Marchandises.Close()
        Gestion_garage.Close()
        Historiques.Close()
        Gestion_Trajet.Close()
        Administration.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur mon compte
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click, Label6.Click
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