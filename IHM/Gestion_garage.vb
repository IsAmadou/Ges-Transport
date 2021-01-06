Public Class Gestion_garage

    Dim metierG As GarageMetier = New GarageMetier
    Dim metierR As Reparations_VehiculeMetier = New Reparations_VehiculeMetier
    Dim metierV As VéhiculesMetier = New VéhiculesMetier
    Dim metierU As UtilisateursMetier = New UtilisateursMetier
    Dim metierH As Historiques_UsersMetier = New Historiques_UsersMetier


    'chargement de la fenetre
    Private Sub Gestion_garage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel4.Visible = False
        Panel2.Enabled = False
        Updpic.Visible = False
        Try
            charger()
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'chargé data grid
    Private Sub charger()
        DataGridGar.DataSource = metierG.getData().Tables("Garage")
        DataGridGar.Columns()(0).Visible = False
    End Sub

    'filtrer le data grid
    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click
        If Not NomGar_fil.Text.Trim.Equals("") And AdrGar_Fil.Text.Trim.Equals("") Then
            Try
                DataGridGar.DataSource = metierG.getDataByNom(NomGar_fil.Text).Tables("GarageByNom")
                DataGridGar.Columns()(0).Visible = False
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NomGar_fil.Text.Trim.Equals("") And Not AdrGar_Fil.Text.Trim.Equals("") Then
            Try
                DataGridGar.DataSource = metierG.getDataByAdr(AdrGar_Fil.Text).Tables("GarageByAdr")
                DataGridGar.Columns()(0).Visible = False
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NomGar_fil.Text.Trim.Equals("") And Not AdrGar_Fil.Text.Trim.Equals("") Then
            Try
                DataGridGar.DataSource = metierG.getDataByNom_Adr(NomGar_fil.Text, AdrGar_Fil.Text).Tables("GarageByNom&Adr")
                DataGridGar.Columns()(0).Visible = False
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NomGar_fil.Text.Trim.Equals("") And AdrGar_Fil.Text.Trim.Equals("") Then
            Try
                charger()
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub


    'clique sur ajouter
    Private Sub AddGar_Click(sender As Object, e As EventArgs) Handles AddGar.Click
        Updpic.Visible = False
        Titre_paneladdGar.Text = "Ajouter garage"
        Panel2.Enabled = True
        vider()
    End Sub


    'clique sur modifier
    Private Sub UpdateGar_Click(sender As Object, e As EventArgs) Handles UpdateGar.Click
        '''''Recuperer les info d'un conducteur pour les modifier''''''''''''
        Try
            Dim IdGar As Int32 = DataGridGar.SelectedRows(0).Cells(0).Value
            Panel2.Enabled = True
            Updpic.Visible = True
            Titre_paneladdGar.Text = "Modifier garage"
            Dim ga As Garage = metierG.getGarageById(IdGar)
            NomGar_lbl.Text = ga.Nom_Garage
            AdrGar_lbl.Text = ga.Adresse_Garage
            TelGar_lbl.Text = ga.Tel_Garage
        Catch ex As Exception
            MessageBox.Show("Selectionner un garage pour cette opération", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    'Vider les champs
    Private Sub vider()
        NomGar_lbl.Text = ""
        AdrGar_lbl.Text = ""
        TelGar_lbl.Text = "+"
    End Sub

    'retour en arriere
    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Me.Close()
    End Sub

    'clique sur Annuler dans le panel Ajouter Garage
    Private Sub AnnGar_Click(sender As Object, e As EventArgs) Handles AnnGar.Click
        vider()
    End Sub

    'clique sur Enregistrer dans le panel Ajouter Garage
    Private Sub EnrGar_Click(sender As Object, e As EventArgs) Handles EnrGar.Click
        If Titre_paneladdGar.Text = "Ajouter garage" Then
            Try
                Dim gag = New Garage(NomGar_lbl.Text, AdrGar_lbl.Text, TelGar_lbl.Text)
                metierG.AddGarage(gag)
                Dim no As String = NomGar_lbl.Text
                vider()
                MessageBox.Show(Me, "garage ajouté avec succès", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Ajout d'un garage", DateTime.Now, no)
                metierH.AddHis_User(his)
                charger()
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error 505", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf Titre_paneladdGar.Text = "Modifier garage" Then
            Try
                Dim gag = New Garage(NomGar_lbl.Text, AdrGar_lbl.Text, TelGar_lbl.Text)
                metierG.UpdateGarage(gag)
                Dim no As String = NomGar_lbl.Text
                vider()
                MessageBox.Show(Me, "Modification bien effectuées", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Modification des caracteristiques d'un garage", DateTime.Now, no)
                metierH.AddHis_User(his)
                charger()
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message, "Error 505", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
        End If
    End Sub

    'cliquer sur ajouter une réparation
    Private Sub AddRep_Click(sender As Object, e As EventArgs) Handles AddRep.Click
        Try

            Dim IdGar As Int32 = DataGridGar.SelectedRows(0).Cells(0).Value
            Dim ga As Garage = metierG.getGarageById(IdGar)
            Idga_lbl.Text = IdGar
            NomGar_Rep.Text = ga.Nom_Garage
            AdrGar_Rep.Text = ga.Adresse_Garage
            TelGar_Rep.Text = ga.Tel_Garage
            Panel1.Visible = False
            updat.Visible = False
            Panel4.Visible = True
        Catch ex As Exception
            MessageBox.Show("Selectionner un garage pour cette opération", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    'bloquer à ne recevoir que des chiffres
    Private Sub TelGar_lbl_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TelGar_lbl.KeyPress
        Gestion_Conducteur.chiffre_only(e)
    End Sub

    'bloquer à ne recevoir que des chiffres pour double
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        Gestion_Marchandises.chiffre_onlyDouble(e)
    End Sub

    'clique sur le symbole de redirection retour en arriere
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Panel4.Visible = False
        Panel1.Visible = True
    End Sub

    'clique sur enregistrer pour sauvegarder une visite technique
    Private Sub EnrRep_Click(sender As Object, e As EventArgs) Handles EnrRep.Click
        If Titre_paneladdRep.Text = "Ajouter Réparation" Then
            Try
                Dim Rep = New Réparations_Vehicule(metierV.getVehiculeByImm(ImmVeh_Rep.Text), metierG.getGarageById(Integer.Parse(Idga_lbl.Text)),
                                                   DatEnt_Rep.Value.Date, DatSor_Rep.Value.Date, Double.Parse(Cout_Rep.Text), TypEnt_Rep.Text)
                metierR.AddVehiculeToGarage(Rep)
                MessageBox.Show(Me, "Visite technique ajouté avec succès", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Ajout d'une visite technique", DateTime.Now, (ImmVeh_Rep.Text + "," + NomGar_Rep.Text))
                metierH.AddHis_User(his)
                Me.Hide()
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error 505", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf Titre_paneladdRep.Text = "Modifier Réparation" Then
            'Try
            Dim Rep = New Réparations_Vehicule(Integer.Parse(irep.Text), metierV.getVehiculeByImm(ImmVeh_Rep.Text), metierG.getGarageById(Integer.Parse(Idga_lbl.Text)),
                                                   DatEnt_Rep.Value.Date, DatSor_Rep.Value.Date, Double.Parse(Cout_Rep.Text), TypEnt_Rep.Text)
            metierR.UpdateVehiculeToGarage(Rep)
                MessageBox.Show(Me, "Modification bien effectuées", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Modification des caracteristiques d'une visite technique", DateTime.Now, (ImmVeh_Rep.Text + "," + NomGar_Rep.Text))
                metierH.AddHis_User(his)
                Me.Hide()
            'Catch ex As Exception
            '    MessageBox.Show(Me, ex.Message, "Error 505", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try
        End If
    End Sub

End Class