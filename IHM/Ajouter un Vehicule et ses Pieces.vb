Public Class Ajouter_un_Vehicule_et_ses_Pieces

    Dim metierv As VéhiculesMetier = New VéhiculesMetier
    Dim metierp As Pièces_VehiculeMetier = New Pièces_VehiculeMetier
    Dim metierU As UtilisateursMetier = New UtilisateursMetier
    Dim metierH As Historiques_UsersMetier = New Historiques_UsersMetier

    'cliquer sur enregistrer
    Private Sub Eng_veh_Click(sender As Object, e As EventArgs) Handles Eng_veh.Click
        Dim _Etat As String
        If Disp_rb.Checked = True Then
            _Etat = "Disponible"
        ElseIf Ind_rb.Checked = True Then
            _Etat = "Indisponible"
        End If

        Dim Cartegrise As String
        If Oui_rb.Checked = True Then
            Cartegrise = "Oui"
        ElseIf Non_rb.Checked = True Then
            Cartegrise = "Non"
        End If

        If TitrAddVeh.Text = "Ajouter un véhicule" Then
            Try
                Dim _veh = New Véhicules(Imm_lbl.Text, Typ_lbl.Text, Mod_lbl.Text, Châ_lbl.Text, TypM_lbl.Text, Cap_lbl.Text, _Etat)
                metierv.AddVehicules(_veh)
                Dim _Pie
                If Vig_lbl.Text = "Oui" And Ass_lbl.Text = "Oui" Then
                    _Pie = New Pièces_Vehicule(metierv.getVehiculeByImm(Imm_lbl.Text), Cartegrise, Vig_lbl.Text, DatExpVig_lbl.Value.Date,
                                               Ass_lbl.Text, DatExpAss_lbl.Value.Date)

                ElseIf Vig_lbl.Text = "Oui" And Ass_lbl.Text = "Non" Then
                    _Pie = New Pièces_Vehicule(metierv.getVehiculeByImm(Imm_lbl.Text), Cartegrise, Vig_lbl.Text, DatExpVig_lbl.Value.Date,
                                                   Ass_lbl.Text)

                ElseIf Vig_lbl.Text = "Non" And Ass_lbl.Text = "Oui" Then
                    _Pie = New Pièces_Vehicule(metierv.getVehiculeByImm(Imm_lbl.Text), Cartegrise, Vig_lbl.Text, Ass_lbl.Text, DatExpAss_lbl.Value.Date)

                ElseIf Vig_lbl.Text = "Non" And Ass_lbl.Text = "Non" Then
                    _Pie = New Pièces_Vehicule(metierv.getVehiculeByImm(Imm_lbl.Text), Cartegrise, Vig_lbl.Text, Ass_lbl.Text)
                End If
                metierp.AddPieces_Vehicule(_Pie)
                Dim im As String = Imm_lbl.Text
                vider()
                MessageBox.Show(Me, "Véhicule ajouté avec succée", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Ajout d'un véhicule", DateTime.Now, im)
                metierH.AddHis_User(his)
                Gestion_Véhicules.charger()
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error 505", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            ' Try
            Dim _veh = New Véhicules(Imm_lbl.Text, Typ_lbl.Text, Mod_lbl.Text, Châ_lbl.Text, TypM_lbl.Text, Cap_lbl.Text, _Etat)
                metierv.UpdateVehicules(_veh)

                Dim _Pie
                If Vig_lbl.Text = "Oui" And Ass_lbl.Text = "Oui" Then
                    _Pie = New Pièces_Vehicule(Integer.Parse(Id_p.Text), metierv.getVehiculeByImm(Imm_lbl.Text), Cartegrise, Vig_lbl.Text, DatExpVig_lbl.Value.Date,
                                               Ass_lbl.Text, DatExpAss_lbl.Value.Date)

                ElseIf Vig_lbl.Text = "Oui" And Ass_lbl.Text = "Non" Then
                    _Pie = New Pièces_Vehicule(Integer.Parse(Id_p.Text), metierv.getVehiculeByImm(Imm_lbl.Text), Cartegrise, Vig_lbl.Text, DatExpVig_lbl.Value.Date,
                                                   Ass_lbl.Text)

                ElseIf Vig_lbl.Text = "Non" And Ass_lbl.Text = "Oui" Then
                    _Pie = New Pièces_Vehicule(Integer.Parse(Id_p.Text), metierv.getVehiculeByImm(Imm_lbl.Text), Cartegrise, Vig_lbl.Text, Ass_lbl.Text, DatExpAss_lbl.Value.Date)

                ElseIf Vig_lbl.Text = "Non" And Ass_lbl.Text = "Non" Then
                    _Pie = New Pièces_Vehicule(Integer.Parse(Id_p.Text), metierv.getVehiculeByImm(Imm_lbl.Text), Cartegrise, Vig_lbl.Text, Ass_lbl.Text)
                End If
                metierp.UpdatePieces_Vehicule(_Pie)
                Dim im As String = Imm_lbl.Text
                vider()
                MessageBox.Show(Me, "Modification réussite", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Modification des caracteristique d'un véhicule", DateTime.Now, im)
                metierH.AddHis_User(his)
                Gestion_Véhicules.charger()
            'Catch ex As Exception
            '    MessageBox.Show(Me, ex.Message, "Error 505", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try
        End If
    End Sub

    'vider tous les champs
    Private Sub vider()
        Imm_lbl.Text = ""
        Typ_lbl.Text = ""
        Mod_lbl.Text = ""
        Châ_lbl.Text = ""
        TypM_lbl.Text = ""
        Cap_lbl.Text = ""
        Vig_lbl.Text = ""
        Ass_lbl.Text = ""
        DatExpVig_lbl.Value = Date.Now
        DatExpAss_lbl.Value = Date.Now
        Ind_rb.Checked = False
        Disp_rb.Checked = False
        Oui_rb.Checked = False
        Non_rb.Checked = False
    End Sub

    'au chargement de la page
    Private Sub Ajouter_un_Vehicule_et_ses_Pieces_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateVeh.Visible = False
    End Sub

    'cliquer sur annuler
    Private Sub AnnVeh_Click(sender As Object, e As EventArgs) Handles AnnVeh.Click
        Me.Hide()
    End Sub

    'changement du text 
    Private Sub Vig_lbl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Vig_lbl.SelectedIndexChanged
        If Vig_lbl.Text = "Oui" Then
            DatExpVig_lbl.Visible = True
        Else
            DatExpVig_lbl.Visible = False
        End If
    End Sub

    Private Sub Ass_lbl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Ass_lbl.SelectedIndexChanged
        If Ass_lbl.Text = "Oui" Then
            DatExpAss_lbl.Visible = True
        Else
            DatExpAss_lbl.Visible = False
        End If
    End Sub
End Class