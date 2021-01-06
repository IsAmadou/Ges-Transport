Public Class Gestion_Trajet
    Dim metierT As TrajetMetier = New TrajetMetier
    Dim metierD As DéplacementMetier = New DéplacementMetier
    Dim metierA As Affecter_ChauffeursMetier = New Affecter_ChauffeursMetier
    Dim metierV As VéhiculesMetier = New VéhiculesMetier
    Dim metierC As ChauffeursMetier = New ChauffeursMetier
    Dim metierM As MarchandisesMetier = New MarchandisesMetier
    Dim metierU As UtilisateursMetier = New UtilisateursMetier
    Dim metierH As Historiques_UsersMetier = New Historiques_UsersMetier



    'Ajouter un Conducteur au traje
    Private Sub AddCon_Tra_Click(sender As Object, e As EventArgs) Handles AddCon_Tra.Click
        Gestion_Conducteur.Show()
        Me.Hide()
    End Sub

    'Ajouter un Vehicule au Trajet
    Private Sub AddVeh_Tra_Click(sender As Object, e As EventArgs) Handles AddVeh_Tra.Click
        Gestion_Véhicules.Show()
        Me.Hide()
    End Sub


    'clique sue Enregistrer pour enregistrer le deplacement
    Private Sub Enr_Tra_Click(sender As Object, e As EventArgs) Handles Enr_Tra.Click
        Try
            Dim ch As Chauffeurs = metierC.getChauffeurById(Integer.Parse(IdCh.Text))
            If TypVeh_Tra.Text = ch.Type_Vehicule_Conduit Then
                If Integer.Parse(Poidsdep.Text) <= Integer.Parse(Capt_Veh.Text) Then
                    If DatFin_Tra.Value.Date >= DatArr_Tra.Value.Date Then
                        Try
                            Dim _Tra = New Trajet(RefTra_lbl.Text, PosDep_Tra.Text, PosArr_Tra.Text)
                            metierT.AddTrajet(_Tra)
                            For i As Int32 = 0 To DataGridMar_Tra.Rows.Count - 2
                                Dim IdMar As Int32 = DataGridMar_Tra.Rows(i).Cells(0).Value
                                Dim _Dep = New Deplacement(metierT.getTrajetByRef(RefTra_lbl.Text), metierV.getVehiculeByImm(ImmVeh_Tra.Text), metierM.getMarchandisesById(IdMar),
                                                   DatDep_Tra.Value.Date, DatArr_Tra.Value.Date, HeuDep_Tra.Value, HeuArr_Tra.Value, Poidsdep.Text)
                                metierD.AddDeplacement(_Dep)
                            Next
                            Dim _Aff = New Affecter_Chauffeurs(metierC.getChauffeurById(Integer.Parse(IdCh.Text)), metierV.getVehiculeByImm(ImmVeh_Tra.Text), DatDep_Tra.Value.Date, DatFin_Tra.Value)
                            metierA.AddChauffeurToVehicule(_Aff)
                            Dim re As String = RefTra_lbl.Text
                            Vider()
                            MessageBox.Show(Me, "Trajet ajouté avec succée", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Ajout d'un trajet", DateTime.Now, re)
                            metierH.AddHis_User(his)
                        Catch ex As Exception
                            metierT.DeleteTrajet(RefTra_lbl.Text)
                            MessageBox.Show(Me, ex.Message, "Error 505", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    Else
                        MessageBox.Show("L'estimation du retour doit être supérieur à la date fin de livraison ", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                ElseIf Poidsdep.Text > Integer.Parse(Capt_Veh.Text) Then
                    MessageBox.Show("Le poids Total doit être inferieur à la capacité du véhicule", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Le conducteur n'est pas adapté à ce type de véhicule", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Veuillez choisir le conducteur", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    'Vider tous les champs
    Private Sub Vider()
        RefTra_lbl.Text = ""
        PosDep_Tra.Text = ""
        PosArr_Tra.Text = ""
        HeuDep_Tra.Value = DateTime.Now
        HeuArr_Tra.Value = DateTime.Now.AddMinutes(20)
        DatDep_Tra.Value = Date.Now
        DatArr_Tra.Value = Date.Now
        DatFin_Tra.Value = Date.Now.AddDays(1)
        ImmVeh_Tra.Text = ""
        TypVeh_Tra.Text = ""
        ModVeh_Tra.Text = ""
        CapVeh_Tra.Text = ""
        Capt_Veh.Text = ""
        NomCon_Tra.Text = ""
        PreCon_Tra.Text = ""
        TelCon_Tra.Text = ""
        DataGridMar_Tra.Rows.Clear()
        Poidsdep.Text = 0
    End Sub

    'Supprimer une Marchandises au DataGrid du deplacement
    Private Sub DeleteMar_Tra_Click(sender As Object, e As EventArgs) Handles DeleteMar_Tra.Click
        Try
            For i As Int32 = 0 To DataGridMar_Tra.SelectedRows.Count - 1
                Dim PoiMar As Double = DataGridMar_Tra.SelectedRows(i).Cells(4).Value
                Dim QuaMar As Int32 = DataGridMar_Tra.SelectedRows(i).Cells(5).Value
                Poidsdep.Text = (Double.Parse(Poidsdep.Text) - (PoiMar * QuaMar)).ToString
            Next
            DataGridMar_Tra.Rows.Remove(DataGridMar_Tra.CurrentRow)
        Catch ex As Exception
            MessageBox.Show("Un élement selectionner au minimun est requis pour la Suppression", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    'Ajouter une Marchandises au DataGrid du deplacement
    Private Sub AddMar_tr_Click(sender As Object, e As EventArgs) Handles AddMar_tr.Click
        Gestion_Marchandises.Show()
        Me.Hide()
    End Sub

    Private Sub Ann_Tra_Click(sender As Object, e As EventArgs) Handles Ann_Tra.Click
        Vider()
    End Sub

    'clique sur Administration
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click, Label23.Click, Admin.Click
        Administration.Show()
        Me.Close()
        Gestion_Conducteur.Close()
        Gestion_garage.Close()
        Gestion_Marchandises.Close()
        Gestion_Véhicules.Close()
        Historiques.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur historique
    Private Sub Panel5_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click, Panel5.Click, Label4.Click
        Historiques.Show()
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
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click, Panel4.Click, Label3.Click
        Gestion_Véhicules.Show()
        Me.Close()
        Gestion_Conducteur.Close()
        Gestion_garage.Close()
        Gestion_Marchandises.Close()
        Administration.Close()
        Historiques.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur marchandise
    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click, Panel6.Click, Label5.Click
        Gestion_Marchandises.Show()
        Me.Close()
        Gestion_Conducteur.Close()
        Gestion_garage.Close()
        Gestion_Véhicules.Close()
        Historiques.Close()
        Administration.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur conducteur
    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click, Panel10.Click, Label7.Click
        Gestion_Conducteur.Show()
        Me.Close()
        Gestion_Marchandises.Close()
        Gestion_garage.Close()
        Gestion_Véhicules.Close()
        Historiques.Close()
        Administration.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'Au chargement
    Private Sub Gestion_Trajet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Authentification.use.Statut_User = "Administrateur" Then
            Admin.Visible = True
        Else
            Admin.Visible = False
        End If
    End Sub

    'pour deconnecter
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim rsult As DialogResult = MessageBox.Show("Etes-vous sûr(e) de vouloir vous deconnecter", "Confirmation",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If rsult = Windows.Forms.DialogResult.Yes Then
            metierU.UpdateDecallUser()
            Authentification.Show()
            Gestion_Conducteur.Close()
            Me.Close()
            Gestion_Marchandises.Close()
            Gestion_garage.Close()
            Gestion_Véhicules.Close()
            Historiques.Close()
            Administration.Close()
            Ajouter_un_Vehicule_et_ses_Pieces.Close()
            créer_un_Utilisateur.Close()
        End If
    End Sub

    'clique sur mon Compte
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