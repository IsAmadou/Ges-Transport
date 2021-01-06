Public Class Historiques

    Dim metierD As DéplacementMetier = New DéplacementMetier
    Dim metierR As Reparations_VehiculeMetier = New Reparations_VehiculeMetier
    Dim metierU As UtilisateursMetier = New UtilisateursMetier
    Dim metierH As Historiques_UsersMetier = New Historiques_UsersMetier
    Dim metierG As GarageMetier = New GarageMetier

    'au chargement
    Private Sub Historiques_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateDep_fil.Visible = False
        If Authentification.use.Statut_User = "Administrateur" Then
            Admin.Visible = True
        Else
            Admin.Visible = False
        End If
        Try
            DataGridTra.DataSource = metierD.getData().Tables("Deplacement")
            DataGridTra.Columns()(0).Visible = False
            charger()
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'charger data
    Private Sub charger()
        DataGridRep.DataSource = metierR.getData().Tables("Reparations_Vehicule")
        DataGridRep.Columns()(0).Visible = False
    End Sub

    'Filtrer le data
    Private Sub search_Click(sender As Object, e As EventArgs) Handles search.Click
        DateDep_fil.Visible = False
        If Imm_fil.Checked = True And Not reseach.Text.Trim.Equals("") Then
            DateDep_fil.Visible = False
            Try
                DataGridTra.DataSource = metierD.getDataByImm(reseach.Text).Tables("DeplacementByImm")
                DataGridTra.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un trajet par l'immatriculation", DateTime.Now, reseach.Text)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf Pre_chauf.Checked = True And Not reseach.Text.Trim.Equals("") Then
            DateDep_fil.Visible = False
            Try
                DataGridTra.DataSource = metierD.getDataByPre(reseach.Text).Tables("DeplacementByPre")
                DataGridTra.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un trajet par le prénom du chauffeur", DateTime.Now, reseach.Text)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf Nom_fil.Checked = True And Not reseach.Text.Trim.Equals("") Then
            DateDep_fil.Visible = False
            Try
                DataGridTra.DataSource = metierD.getDataByNom(reseach.Text).Tables("DeplacementByNom")
                DataGridTra.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un trajet par le nom du chauffeur", DateTime.Now, reseach.Text)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf lib_fil.Checked = True And Not reseach.Text.Trim.Equals("") Then
            DateDep_fil.Visible = False
            Try
                DataGridTra.DataSource = metierD.getDataByLib(reseach.Text).Tables("DeplacementByLibe")
                DataGridTra.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un trajet par le libelle de la marchandise", DateTime.Now, reseach.Text)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf dat_Fil.Checked = True Then
            Try
                DataGridTra.DataSource = metierD.getDataByDat(DateDep_fil.Value.Date).Tables("DeplacementByDat")
                DataGridTra.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'un trajet par la date de depart", DateTime.Now, (DateDep_fil.Value.Date).ToString)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf tou_Fil.Checked = True And reseach.Text.Trim.Equals("") Then
            DateDep_fil.Visible = False
            Try
                DataGridTra.DataSource = metierD.getData().Tables("Deplacement")
                DataGridTra.Columns()(0).Visible = False
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    'clique sur administration
    Private Sub Admin_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click, Label1.Click, Admin.Click
        Administration.Show()
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
    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click, Panel9.Click, Label16.Click
        Gestion_Trajet.Show()
        Me.Close()
        Gestion_Conducteur.Close()
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
        Gestion_Conducteur.Close()
        Gestion_garage.Close()
        Gestion_Marchandises.Close()
        Gestion_Trajet.Close()
        Administration.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    ' clique sur Marchandise
    Private Sub Panel6_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click, Panel6.Click, Label13.Click
        Gestion_Marchandises.Show()
        Me.Close()
        Gestion_Conducteur.Close()
        Gestion_garage.Close()
        Gestion_Véhicules.Close()
        Gestion_Trajet.Close()
        Administration.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'filtrer data grid
    Private Sub Search2_Click(sender As Object, e As EventArgs) Handles Search2.Click
        If Not Immveh_fil.Text.Trim.Equals("") And NomGar_fil.Text.Trim.Equals("") Then
            Try
                DataGridRep.DataSource = metierR.getDataByImm(Immveh_fil.Text).Tables("Reparations_VehiculeByImm")
                DataGridRep.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une visite par l'immatriculation", DateTime.Now, Immveh_fil.Text)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Immveh_fil.Text.Trim.Equals("") And Not NomGar_fil.Text.Trim.Equals("") Then
            Try
                DataGridRep.DataSource = metierR.getDataByNom(NomGar_fil.Text).Tables("Reparations_VehiculeByNom")
                DataGridRep.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une visite par le nom du garage", DateTime.Now, NomGar_fil.Text)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not Immveh_fil.Text.Trim.Equals("") And Not NomGar_fil.Text.Trim.Equals("") Then
            Try
                DataGridRep.DataSource = metierR.getDataByImm_Nom(Immveh_fil.Text, NomGar_fil.Text).Tables("Reparations_VehiculeByImm&Nom")
                DataGridRep.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une visite par l'immatriculation et le nom du garage", DateTime.Now, (Immveh_fil.Text + "," + NomGar_fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Immveh_fil.Text.Trim.Equals("") And NomGar_fil.Text.Trim.Equals("") Then
            Try
                charger()
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub

    'Details sur reparation des champs
    Private Sub DataGridRep_DoubleClick(sender As Object, e As EventArgs) Handles DataGridRep.DoubleClick
        For i As Int32 = 0 To DataGridRep.SelectedRows.Count - 1
            Dim Idr As Int32
            Try
                Idr = DataGridRep.SelectedRows(i).Cells(0).Value
                Dim re As Réparations_Vehicule = metierR.getReparations_vehiculeById(Idr)
                DetailsDatagrid.L1.Visible = True
                DetailsDatagrid.L1.Text = "Immatriculation"
                DetailsDatagrid.T1.Visible = True
                DetailsDatagrid.T1.Text = re.Vehicule.Immatriculation
                DetailsDatagrid.L3.Visible = True
                DetailsDatagrid.L3.Text = "Nom_Garage"
                DetailsDatagrid.T3.Visible = True
                DetailsDatagrid.T3.Text = re.Garage.Nom_Garage
                DetailsDatagrid.L4.Visible = True
                DetailsDatagrid.L4.Text = "Date d'entrée"
                DetailsDatagrid.T4.Visible = True
                DetailsDatagrid.T4.Text = re.Date_Reparation
                DetailsDatagrid.L5.Visible = True
                DetailsDatagrid.L5.Text = "Date de sortie"
                DetailsDatagrid.T5.Visible = True
                DetailsDatagrid.T5.Text = re.Date_Sortie
                DetailsDatagrid.L6.Visible = True
                DetailsDatagrid.L6.Text = "Coût"
                DetailsDatagrid.T6.Visible = True
                DetailsDatagrid.T6.Text = re.Cout_Reparation
                DetailsDatagrid.L7.Visible = True
                DetailsDatagrid.L7.Text = "type de reparation"
                DetailsDatagrid.T7.Visible = True
                DetailsDatagrid.T7.Text = re.Type_Entretien
                DetailsDatagrid.Show()
            Catch ex As Exception
                MessageBox.Show("Le double-clic doit être sur une marchandise pour cette operation", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        Next
    End Sub

    'details sur les trajets
    Private Sub DataGridTra_DoubleClick(sender As Object, e As EventArgs) Handles DataGridTra.DoubleClick
        For i As Int32 = 0 To DataGridTra.SelectedRows.Count - 1
            Dim IdD As Int32
            Try
                IdD = DataGridTra.SelectedRows(i).Cells(0).Value
                Dim nom As String = DataGridTra.SelectedRows(i).Cells(4).Value
                Dim pre As String = DataGridTra.SelectedRows(i).Cells(5).Value
                Dim de As Deplacement = metierD.getDaplacementById(IdD)
                DetailsDatagrid.L1.Visible = True
                DetailsDatagrid.L1.Text = "Immatriculation"
                DetailsDatagrid.T1.Visible = True
                DetailsDatagrid.T1.Text = de.Vehicules.Immatriculation
                DetailsDatagrid.L2.Visible = True
                DetailsDatagrid.L2.Text = "type_Vehicule"
                DetailsDatagrid.T2.Visible = True
                DetailsDatagrid.T2.Text = de.Vehicules.Type
                DetailsDatagrid.L3.Visible = True
                DetailsDatagrid.L3.Text = "Modele_vehicule"
                DetailsDatagrid.T3.Visible = True
                DetailsDatagrid.T3.Text = de.Vehicules.Modèle
                DetailsDatagrid.L4.Visible = True
                DetailsDatagrid.L4.Text = "libellé"
                DetailsDatagrid.T4.Visible = True
                DetailsDatagrid.T4.Text = de.Marchandises.Libelle
                DetailsDatagrid.L5.Visible = True
                DetailsDatagrid.L5.Text = "Nature"
                DetailsDatagrid.T5.Visible = True
                DetailsDatagrid.T5.Text = de.Marchandises.Nature
                DetailsDatagrid.L6.Visible = True
                DetailsDatagrid.L6.Text = "Quantité"
                DetailsDatagrid.T6.Visible = True
                DetailsDatagrid.T6.Text = de.Marchandises.Quantite
                DetailsDatagrid.L15.Visible = True
                DetailsDatagrid.L15.Text = "ref_Trajet"
                DetailsDatagrid.T15.Visible = True
                DetailsDatagrid.T15.Text = de.Trajets.Ref
                DetailsDatagrid.L8.Visible = True
                DetailsDatagrid.L8.Text = "Position de depart"
                DetailsDatagrid.T8.Visible = True
                DetailsDatagrid.T8.Text = de.Trajets.Position_Depart
                DetailsDatagrid.L9.Visible = True
                DetailsDatagrid.L9.Text = "Position d'arrivée"
                DetailsDatagrid.T9.Visible = True
                DetailsDatagrid.T9.Text = de.Trajets.Position_Arrivee
                DetailsDatagrid.L10.Visible = True
                DetailsDatagrid.L10.Text = "Date depart"
                DetailsDatagrid.T10.Visible = True
                DetailsDatagrid.T10.Text = de.Date_Départ
                DetailsDatagrid.L11.Visible = True
                DetailsDatagrid.L11.Text = "Date d'arrivée"
                DetailsDatagrid.T11.Visible = True
                DetailsDatagrid.T11.Text = de.Date_Arrivée
                DetailsDatagrid.L12.Visible = True
                DetailsDatagrid.L12.Text = "Heure de depart"
                DetailsDatagrid.T12.Visible = True
                DetailsDatagrid.T12.Text = (de.Heure_Départ.Hour).ToString + ":" + (de.Heure_Départ.Minute).ToString + ":" + (de.Heure_Départ.Second).ToString
                DetailsDatagrid.L7.Visible = True
                DetailsDatagrid.L7.Text = "Heure d'arrivée"
                DetailsDatagrid.T7.Visible = True
                DetailsDatagrid.T7.Text = (de.Heure_Arrivée.Hour).ToString + ":" + (de.Heure_Arrivée.Minute).ToString + ":" + (de.Heure_Arrivée.Second).ToString
                DetailsDatagrid.L14.Visible = True
                DetailsDatagrid.L14.Text = "Nom_chauffeur"
                DetailsDatagrid.T14.Visible = True
                DetailsDatagrid.T14.Text = nom
                DetailsDatagrid.L13.Visible = True
                DetailsDatagrid.L13.Text = "Prenom_chauffeur"
                DetailsDatagrid.T13.Visible = True
                DetailsDatagrid.T13.Text = pre
                DetailsDatagrid.Show()
            Catch ex As exception
                messagebox.show("le double-clic doit être sur une ligne pour cette operation", "avertissement", messageboxbuttons.ok, messageboxicon.warning)
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
        Administration.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur la filtre par date
    Private Sub dat_Fil_CheckedChanged(sender As Object, e As EventArgs) Handles dat_Fil.CheckedChanged
        If dat_Fil.Checked = True Then
            DateDep_fil.Visible = True
        Else
            DateDep_fil.Visible = False
        End If
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

    'Modifier une reparation
    Private Sub UpdateRep_Click(sender As Object, e As EventArgs) Handles UpdateRep.Click
        Dim IdR As Int32
        Try
            IdR = DataGridRep.SelectedRows(0).Cells(0).Value
            Gestion_garage.Show()
            Gestion_garage.Titre_paneladdRep.Text = "Modifier Réparation"
            Gestion_garage.Panel1.Visible = False
            Gestion_garage.Panel4.Visible = True
            Dim rep As Réparations_Vehicule = metierR.getReparations_vehiculeById(IdR)
            Gestion_garage.irep.Text = IdR
            Gestion_garage.NomGar_Rep.Text = rep.Garage.Nom_Garage
            Gestion_garage.AdrGar_Rep.Text = rep.Garage.Adresse_Garage
            Gestion_garage.TelGar_Rep.Text = rep.Garage.Tel_Garage
            Gestion_garage.TypVeh_Rep.Text = rep.Vehicule.Type
            Gestion_garage.ImmVeh_Rep.Text = rep.Vehicule.Immatriculation
            Gestion_garage.ModVeh_Rep.Text = rep.Vehicule.Modèle
            Gestion_garage.TypEnt_Rep.Text = rep.Type_Entretien
            Gestion_garage.Cout_Rep.Text = rep.Cout_Reparation
            Gestion_garage.DatEnt_Rep.Value = rep.Date_Reparation
            Gestion_garage.DatSor_Rep.Value = rep.Date_Sortie
        Catch ex As Exception
            MessageBox.Show("Selectionner une visite technique pour cette opération", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    'clique sur supprimer
    Private Sub DeleteRep_Click(sender As Object, e As EventArgs) Handles DeleteRep.Click
        Dim rsult As DialogResult = MessageBox.Show("Etes-vous sûr(e) de vouloir supprimer", "Confirmation",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If rsult = Windows.Forms.DialogResult.Yes Then
            For i As Int32 = 0 To DataGridRep.SelectedRows.Count - 1
                Dim IdR As Int32
                Try
                    Dim veh As String = DataGridRep.SelectedRows(i).Cells(1).Value
                    Dim no As String = DataGridRep.SelectedRows(i).Cells(2).Value
                    IdR = DataGridRep.SelectedRows(i).Cells(0).Value
                    Try
                        metierR.DeleteReparations_Vehicule(IdR)
                        Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Suppression d'une visite technique", DateTime.Now, veh + "," + no)
                        metierH.AddHis_User(his)
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Catch ex As Exception
                    MessageBox.Show("Selectionner une visite technique au moins pour cette opération", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

    'cique sur supprimer trajet
    Private Sub DeleteCon_Click(sender As Object, e As EventArgs) Handles DeleteCon.Click
        Dim rsult As DialogResult = MessageBox.Show("Etes-vous sûr(e) de vouloir supprimer", "Confirmation",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If rsult = Windows.Forms.DialogResult.Yes Then
            For i As Int32 = 0 To DataGridTra.SelectedRows.Count - 1
                Dim IdD As Int32
                Try
                    Dim no As String = DataGridTra.SelectedRows(i).Cells(6).Value
                    IdD = DataGridTra.SelectedRows(i).Cells(0).Value
                    Try
                        metierD.DeleteDeplacement(IdD)
                        Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Suppression d'une marchandise trajet", DateTime.Now, no)
                        metierH.AddHis_User(his)
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Catch ex As Exception
                    MessageBox.Show("Selectionner un trajet au moins pour cette opération", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            Next
            Try
                DataGridTra.DataSource = metierD.getData().Tables("Deplacement")
                DataGridTra.Columns()(0).Visible = False
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Try
                DataGridTra.DataSource = metierD.getData().Tables("Deplacement")
                DataGridTra.Columns()(0).Visible = False
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub


End Class