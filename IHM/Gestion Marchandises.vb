Public Class Gestion_Marchandises

    Dim metierM As MarchandisesMetier = New MarchandisesMetier
    Dim metierU As UtilisateursMetier = New UtilisateursMetier
    Dim metierH As Historiques_UsersMetier = New Historiques_UsersMetier

    'Au chargement de la forme
    Private Sub Gestion_Marchandises_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    'clique sur modifier pour changer les caracteristiques d'une marchandise
    Private Sub UpdateMar_Click(sender As Object, e As EventArgs) Handles UpdateMar.Click
        '''''recuperer les attribut de l'élement à modifier''''''''
        Dim IdMar As Int32
        Try
            IdMar = DataGridMar.SelectedRows(0).Cells(0).Value
            retablir_fenetre()
            Label2.Visible = False
            Updpic.Visible = True
            Titre_paneladdMar.Text = "Modifier Marchandise"
            AddMar.Enabled = False
            DeleteMar.Enabled = False
            AffMar.Enabled = False
            Dim Mar As Marchandises = metierM.getMarchandisesById(IdMar)
            LibMar_lbl.Text = Mar.Libelle
            NatMar_lbl.Text = Mar.Nature
            PoiMar_lbl.Text = Mar.Poids
            ValMar_lbl.Text = Mar.Valeur
            QuaMar_lbl.Text = Mar.Quantite
            EtaMar_lbl.Text = Mar.Etat
            If Mar.Documents = "Complet" Then
                Com_rd_lbl.Checked = True
                Man_rd_lbl.Checked = False
                Pas_rd_lbl.Checked = False
            ElseIf Mar.Documents = "Manque" Then
                Com_rd_lbl.Checked = False
                Man_rd_lbl.Checked = True
                Pas_rd_lbl.Checked = False
            ElseIf Mar.Documents = "Pas besoin" Then
                Com_rd_lbl.Checked = False
                Man_rd_lbl.Checked = False
                Pas_rd_lbl.Checked = True
            End If
        Catch ex As Exception
            MessageBox.Show("Selectionner une marchandise pour cette opération", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    'clique sur ajouter une Marchandise
    Private Sub AddMar_Click(sender As Object, e As EventArgs) Handles AddMar.Click
        retablir_fenetre()
        vider()
        Label2.Visible = True
        Updpic.Visible = False
        Titre_paneladdMar.Text = "Ajouter Marchandise"
        UpdateMar.Enabled = False
        DeleteMar.Enabled = False
        AffMar.Enabled = False
    End Sub

    'clique sur Annuler du panel ajout Marchandise
    Private Sub AnnMar_Click(sender As Object, e As EventArgs) Handles AnnMar.Click
        Structurer_fenetre()
        vider()
        Try
            charger()
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        AddMar.Enabled = True
        UpdateMar.Enabled = True
        DeleteMar.Enabled = True
        AffMar.Enabled = True
    End Sub

    'Afficher data en grand
    Private Sub Structurer_fenetre()
        AddMarPanel.Visible = False
        MarIma.Location = New Point(615, 16)
        MarIma.Size = New Size(183, 115)
        Mar.Location = New Point(836, 57)
        Mar.Size = New Size(101, 24)
        DataGridMar.Location = New Point(269, 353)
        DataGridMar.Size = New Size(1016, 329)
        Search.Visible = True
        Filt.Visible = True
        libMar.Visible = True
        LibMar_Fil.Visible = True
        NatMar.Visible = True
        NatMar_Fil.Visible = True
        DocMar.Visible = True
        DocMar_Fil.Visible = True
        StaMar.Visible = True
        StaMar_fil.Visible = True
        PoiTotMar.Visible = True
        PoiTotMar_Fil.Visible = True
        Filt.Location = New Point(277, 149)
        Filt.Size = New Size(88, 19)
        libMar.Location = New Point(669, 301)
        libMar.Size = New Size(51, 19)
        LibMar_Fil.Location = New Point(752, 296)
        LibMar_Fil.Size = New Size(174, 26)
        NatMar.Location = New Point(339, 301)
        NatMar.Size = New Size(52, 19)
        NatMar_Fil.Location = New Point(430, 296)
        NatMar_Fil.Size = New Size(174, 26)
        DocMar.Location = New Point(379, 202)
        DocMar.Size = New Size(121, 49)
        DocMar_Fil.Location = New Point(515, 194)
        DocMar_Fil.Size = New Size(273, 57)
        StaMar.Location = New Point(816, 212)
        StaMar.Size = New Size(49, 25)
        StaMar_fil.Location = New Point(871, 194)
        StaMar_fil.Size = New Size(273, 57)
        PoiTotMar.Location = New Point(993, 301)
        PoiTotMar.Size = New Size(77, 19)
        PoiTotMar_Fil.Location = New Point(1093, 297)
        PoiTotMar_Fil.Size = New Size(148, 26)
        Search.Location = New Point(1244, 233)
        Search.Size = New Size(40, 40)

    End Sub

    'Redimantionner le Data
    Private Sub retablir_fenetre()
        AddMarPanel.Visible = True
        MarIma.Location = New Point(436, 18)
        MarIma.Size = New Size(147, 109)
        Mar.Location = New Point(600, 65)
        Mar.Size = New Size(118, 24)
        DataGridMar.Location = New Point(317, 159)
        DataGridMar.Size = New Size(548, 317)
        Search.Visible = False
        Filt.Visible = False
        libMar.Visible = False
        LibMar_Fil.Visible = False
        NatMar.Visible = False
        NatMar_Fil.Visible = False
        DocMar.Visible = False
        DocMar_Fil.Visible = False
        StaMar.Visible = False
        StaMar_fil.Visible = False
        PoiTotMar.Visible = False
        PoiTotMar_Fil.Visible = False
        Updpic.Visible = False
    End Sub

    'clique sur enregistrer du panel ajout Marchandise
    Private Sub EnrMar_Click(sender As Object, e As EventArgs) Handles EnrMar.Click
        Dim _doc As String
        If Com_rd_lbl.Checked = True Then
            _doc = "Complet"
        ElseIf Pas_rd_lbl.Checked = True Then
            _doc = "Pas besoin"
        ElseIf Man_rd_lbl.Checked = True Then
            _doc = "Manque"
        End If

        If Titre_paneladdMar.Text = "Ajouter Marchandise" Then
            Try

                Dim _mar = New Marchandises(LibMar_lbl.Text, NatMar_lbl.Text, ValMar_lbl.Text, PoiMar_lbl.Text, QuaMar_lbl.Text, EtaMar_lbl.Text, _doc, Date.Now.Date, "Pas livré")
                metierM.AddMarchandises(_mar)
                Dim li As String = LibMar_lbl.Text
                vider()
                MessageBox.Show(Me, "Marchandises ajouté avec succée", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Ajout d'une marchandise", DateTime.Now, li)
                metierH.AddHis_User(his)
                charger()
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error 505", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf Titre_paneladdMar.Text = "Modifier Marchandise" Then
            Try
                Dim IdMar As Int32 = DataGridMar.SelectedRows(0).Cells(0).Value
                Dim _mar = New Marchandises(IdMar, LibMar_lbl.Text, NatMar_lbl.Text, ValMar_lbl.Text, PoiMar_lbl.Text, QuaMar_lbl.Text, EtaMar_lbl.Text, _doc, Date.Now.Date, "Pas livré")
                metierM.UpdateMarchandises(_mar)
                Dim li As String = LibMar_lbl.Text
                vider()
                MessageBox.Show(Me, "Modification réussite", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Modification des caracteristiques d'une marchandise", DateTime.Now, li)
                metierH.AddHis_User(his)
                charger()
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error 505", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    'vider les champs
    Private Sub vider()
        NatMar_lbl.Text = ""
        LibMar_lbl.Text = ""
        ValMar_lbl.Text = ""
        PoiMar_lbl.Text = ""
        QuaMar_lbl.Text = ""
        EtaMar_lbl.Text = ""
        Com_rd_lbl.Checked = False
        Pas_rd_lbl.Checked = False
        Man_rd_lbl.Checked = False
    End Sub

    'charger le data gridview
    Private Sub charger()
        DataGridMar.DataSource = metierM.getData().Tables("Marchandises")
        DataGridMar.Columns()(0).Visible = False
    End Sub

    'Autoriser only les chiffres et la virgule pour les Double
    Dim chif() As Char = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", " ", ","}
    Public Sub chiffre_onlyDouble(e)
        If Not chif.Contains(e.keychar) And Not Asc(e.keychar) = 8 Then
            e.handled = True
        End If
    End Sub

    'bloquer la quantité à ne recevoir que des chiffres
    Private Sub QuaMar_lbl_KeyPress(sender As Object, e As KeyPressEventArgs) Handles QuaMar_lbl.KeyPress
        Gestion_Conducteur.chiffre_only(e)
    End Sub

    'bloquer la valeur et le poids à ne recevoir  que des chiffre plus virgule 
    Private Sub PoiMar_lblandValMar_lbl_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ValMar_lbl.KeyPress, PoiMar_lbl.KeyPress
        chiffre_onlyDouble(e)
    End Sub

    'bloquer le poids à ne recevoir  que des chiffre plus virgule 
    Private Sub PoiTotMar_Fil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PoiTotMar_Fil.KeyPress
        chiffre_onlyDouble(e)
    End Sub

    'filtrer le datagrid
    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click
        Dim _Doc As String
        If Com_rd_Fil.Checked = True Then
            _Doc = "Complet"
        ElseIf Man_rd_Fil.Checked = True Then
            _Doc = "Manque"
        ElseIf Pas_rd_Fil.Checked = True Then
            _Doc = "Pas besoin"
        End If

        Dim _Sta As String
        If Liv_rd_Fil.Checked = True Then
            _Sta = "Livré"
        ElseIf Pasl_rd_Fil.Checked = True Then
            _Sta = "Pas livré"
        ElseIf Enc_rd_Fil.Checked = True Then
            _Sta = "En cours"
        End If

        If Not NatMar_Fil.Text.Trim().Equals("") And LibMar_Fil.Text.Trim().Equals("") And Com_rd_Fil.Checked = False And Man_rd_Fil.Checked = False And Pas_rd_Fil.Checked = False And Liv_rd_Fil.Checked = False And Pasl_rd_Fil.Checked = False And Enc_rd_Fil.Checked = False And PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByNat(NatMar_Fil.Text).Tables("MarchandisesByNat")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par la nature", DateTime.Now, NatMar_Fil.Text)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NatMar_Fil.Text.Trim().Equals("") And Not LibMar_Fil.Text.Trim().Equals("") And Com_rd_Fil.Checked = False And Man_rd_Fil.Checked = False And Pas_rd_Fil.Checked = False And Liv_rd_Fil.Checked = False And Pasl_rd_Fil.Checked = False And Enc_rd_Fil.Checked = False And PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByLibe(LibMar_Fil.Text).Tables("MarchandisesByLibe")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par le libelle", DateTime.Now, LibMar_Fil.Text)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NatMar_Fil.Text.Trim().Equals("") And Not LibMar_Fil.Text.Trim().Equals("") And Com_rd_Fil.Checked = False And Man_rd_Fil.Checked = False And Pas_rd_Fil.Checked = False And Liv_rd_Fil.Checked = False And Pasl_rd_Fil.Checked = False And Enc_rd_Fil.Checked = False And PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByNat_Libe(NatMar_Fil.Text, LibMar_Fil.Text).Tables("MarchandisesByNat&Libe")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par la nature et le libelle", DateTime.Now,
                                                (NatMar_Fil.Text + "," + LibMar_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NatMar_Fil.Text.Trim().Equals("") And LibMar_Fil.Text.Trim().Equals("") And (Com_rd_Fil.Checked = True Or Man_rd_Fil.Checked = True Or Pas_rd_Fil.Checked = True) And Liv_rd_Fil.Checked = False And Pasl_rd_Fil.Checked = False And Enc_rd_Fil.Checked = False And PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByDoc(_Doc).Tables("MarchandisesByDoc")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par les documents de transit", DateTime.Now, _Doc)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NatMar_Fil.Text.Trim().Equals("") And LibMar_Fil.Text.Trim().Equals("") And (Com_rd_Fil.Checked = True Or Man_rd_Fil.Checked = True Or Pas_rd_Fil.Checked = True) And Liv_rd_Fil.Checked = False And Pasl_rd_Fil.Checked = False And Enc_rd_Fil.Checked = False And PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByNat_Doc(NatMar_Fil.Text, _Doc).Tables("MarchandisesByNat&Doc")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par la nature et les documents de transit", DateTime.Now,
                                                (NatMar_Fil.Text + "," + _Doc))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NatMar_Fil.Text.Trim().Equals("") And Not LibMar_Fil.Text.Trim().Equals("") And (Com_rd_Fil.Checked = True Or Man_rd_Fil.Checked = True Or Pas_rd_Fil.Checked = True) And Liv_rd_Fil.Checked = False And Pasl_rd_Fil.Checked = False And Enc_rd_Fil.Checked = False And PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByLibe_Doc(LibMar_Fil.Text, _Doc).Tables("MarchandisesByLibe&Doc")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par le libelle et les documents de transit", DateTime.Now,
                                               (LibMar_Fil.Text + "," + _Doc))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NatMar_Fil.Text.Trim().Equals("") And Not LibMar_Fil.Text.Trim().Equals("") And (Com_rd_Fil.Checked = True Or Man_rd_Fil.Checked = True Or Pas_rd_Fil.Checked = True) And Liv_rd_Fil.Checked = False And Pasl_rd_Fil.Checked = False And Enc_rd_Fil.Checked = False And PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByNat_Libe_Doc(NatMar_Fil.Text, LibMar_Fil.Text, _Doc).Tables("MarchandisesByNat&Libe&Doc")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par la nature, le libelle et les documents de transit", DateTime.Now,
                                               (NatMar_Fil.Text + "," + LibMar_Fil.Text + "," + _Doc))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NatMar_Fil.Text.Trim().Equals("") And LibMar_Fil.Text.Trim().Equals("") And Com_rd_Fil.Checked = False And Man_rd_Fil.Checked = False And Pas_rd_Fil.Checked = False And (Liv_rd_Fil.Checked = True Or Pasl_rd_Fil.Checked = True Or Enc_rd_Fil.Checked = True) And PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataBySta(_Sta).Tables("MarchandisesBySta")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par le statut", DateTime.Now, _Sta)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NatMar_Fil.Text.Trim().Equals("") And LibMar_Fil.Text.Trim().Equals("") And Com_rd_Fil.Checked = False And Man_rd_Fil.Checked = False And Pas_rd_Fil.Checked = False And (Liv_rd_Fil.Checked = True Or Pasl_rd_Fil.Checked = True Or Enc_rd_Fil.Checked = True) And PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByNat_Sta(NatMar_Fil.Text, _Sta).Tables("MarchandisesByNat&Sta")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par la nature et le statut", DateTime.Now, (NatMar_Fil.Text + "," + _Sta))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NatMar_Fil.Text.Trim().Equals("") And Not LibMar_Fil.Text.Trim().Equals("") And Com_rd_Fil.Checked = False And Man_rd_Fil.Checked = False And Pas_rd_Fil.Checked = False And (Liv_rd_Fil.Checked = True Or Pasl_rd_Fil.Checked = True Or Enc_rd_Fil.Checked = True) And PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataBylibe_Sta(LibMar_Fil.Text, _Sta).Tables("MarchandisesByLibe&Sta")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par le libelle et le statut", DateTime.Now, (LibMar_Fil.Text + "," + _Sta))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NatMar_Fil.Text.Trim().Equals("") And LibMar_Fil.Text.Trim().Equals("") And (Com_rd_Fil.Checked = True Or Man_rd_Fil.Checked = True Or Pas_rd_Fil.Checked = True) And (Liv_rd_Fil.Checked = True Or Pasl_rd_Fil.Checked = True Or Enc_rd_Fil.Checked = True) And PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByDoc_Sta(_Doc, _Sta).Tables("MarchandisesByDoc&Sta")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par les documents de transit et le statut", DateTime.Now,
                                                (_Doc + "," + _Sta))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NatMar_Fil.Text.Trim().Equals("") And Not LibMar_Fil.Text.Trim().Equals("") And Com_rd_Fil.Checked = False And Man_rd_Fil.Checked = False And Pas_rd_Fil.Checked = False And (Liv_rd_Fil.Checked = True Or Pasl_rd_Fil.Checked = True Or Enc_rd_Fil.Checked = True) And PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByNat_Libe_Sta(NatMar_Fil.Text, LibMar_Fil.Text, _Sta).Tables("MarchandisesByNat&Libe&Sta")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par la nature, le libelle et le statut", DateTime.Now,
                                                (NatMar_Fil.Text + "," + LibMar_Fil.Text + "," + _Sta))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NatMar_Fil.Text.Trim().Equals("") And LibMar_Fil.Text.Trim().Equals("") And (Com_rd_Fil.Checked = True Or Man_rd_Fil.Checked = True Or Pas_rd_Fil.Checked = True) And (Liv_rd_Fil.Checked = True Or Pasl_rd_Fil.Checked = True Or Enc_rd_Fil.Checked = True) And PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByNat_Doc_Sta(NatMar_Fil.Text, _Doc, _Sta).Tables("MarchandisesByNat&Doc&Sta")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par la nature,les documents de transit et le statut", DateTime.Now,
                                               (NatMar_Fil.Text + "," + _Doc + "," + _Sta))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NatMar_Fil.Text.Trim().Equals("") And Not LibMar_Fil.Text.Trim().Equals("") And (Com_rd_Fil.Checked = True Or Man_rd_Fil.Checked = True Or Pas_rd_Fil.Checked = True) And (Liv_rd_Fil.Checked = True Or Pasl_rd_Fil.Checked = True Or Enc_rd_Fil.Checked = True) And PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByLibe_Doc_Sta(LibMar_Fil.Text, _Doc, _Sta).Tables("MarchandisesByLibe&Doc&Sta")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par le libelle,les documents de transit et le statut", DateTime.Now,
                                              (LibMar_Fil.Text + "," + _Doc + "," + _Sta))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NatMar_Fil.Text.Trim().Equals("") And Not LibMar_Fil.Text.Trim().Equals("") And (Com_rd_Fil.Checked = True Or Man_rd_Fil.Checked = True Or Pas_rd_Fil.Checked = True) And (Liv_rd_Fil.Checked = True Or Pasl_rd_Fil.Checked = True Or Enc_rd_Fil.Checked = True) And PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByNat_Libe_Doc_Sta(NatMar_Fil.Text, LibMar_Fil.Text, _Doc, _Sta).Tables("MarchandisesByNat&Libe&Doc&Sta")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par la nature, le libelle,les documents de transit et le statut", DateTime.Now,
                                             (NatMar_Fil.Text + "," + LibMar_Fil.Text + "," + _Doc + "," + _Sta))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NatMar_Fil.Text.Trim().Equals("") And LibMar_Fil.Text.Trim().Equals("") And Com_rd_Fil.Checked = False And Man_rd_Fil.Checked = False And Pas_rd_Fil.Checked = False And Liv_rd_Fil.Checked = False And Pasl_rd_Fil.Checked = False And Enc_rd_Fil.Checked = False And Not PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByPoi(PoiTotMar_Fil.Text).Tables("MarchandisesByPoi")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par le Poids total", DateTime.Now, PoiTotMar_Fil.Text)
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NatMar_Fil.Text.Trim().Equals("") And LibMar_Fil.Text.Trim().Equals("") And Com_rd_Fil.Checked = False And Man_rd_Fil.Checked = False And Pas_rd_Fil.Checked = False And Liv_rd_Fil.Checked = False And Pasl_rd_Fil.Checked = False And Enc_rd_Fil.Checked = False And Not PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByNat_Poi(NatMar_Fil.Text, PoiTotMar_Fil.Text).Tables("MarchandisesByNat&Poi")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par la nature et le Poids total", DateTime.Now,
                                                (NatMar_Fil.Text + "," + PoiTotMar_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NatMar_Fil.Text.Trim().Equals("") And Not LibMar_Fil.Text.Trim().Equals("") And Com_rd_Fil.Checked = False And Man_rd_Fil.Checked = False And Pas_rd_Fil.Checked = False And Liv_rd_Fil.Checked = False And Pasl_rd_Fil.Checked = False And Enc_rd_Fil.Checked = False And Not PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByLibe_Poi(LibMar_Fil.Text, PoiTotMar_Fil.Text).Tables("MarchandisesByLibe&Poi")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par le libelle et le Poids total", DateTime.Now,
                                                (LibMar_Fil.Text + "," + PoiTotMar_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NatMar_Fil.Text.Trim().Equals("") And Not LibMar_Fil.Text.Trim().Equals("") And Com_rd_Fil.Checked = False And Man_rd_Fil.Checked = False And Pas_rd_Fil.Checked = False And Liv_rd_Fil.Checked = False And Pasl_rd_Fil.Checked = False And Enc_rd_Fil.Checked = False And Not PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByNat_Libe_Poi(NatMar_Fil.Text, LibMar_Fil.Text, PoiTotMar_Fil.Text).Tables("MarchandisesByNat&Libe&Poi")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par la nature, le libelle et le Poids total", DateTime.Now,
                                               (NatMar_Fil.Text + "," + LibMar_Fil.Text + "," + PoiTotMar_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NatMar_Fil.Text.Trim().Equals("") And LibMar_Fil.Text.Trim().Equals("") And (Com_rd_Fil.Checked = True Or Man_rd_Fil.Checked = True Or Pas_rd_Fil.Checked = True) And Liv_rd_Fil.Checked = False And Pasl_rd_Fil.Checked = False And Enc_rd_Fil.Checked = False And Not PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByDoc_Poi(_Doc, PoiTotMar_Fil.Text).Tables("MarchandisesByDoc&Poi")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par les documents de transit et le Poids total", DateTime.Now,
                                              (_Doc + "," + PoiTotMar_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NatMar_Fil.Text.Trim().Equals("") And LibMar_Fil.Text.Trim().Equals("") And (Com_rd_Fil.Checked = True Or Man_rd_Fil.Checked = True Or Pas_rd_Fil.Checked = True) And Liv_rd_Fil.Checked = False And Pasl_rd_Fil.Checked = False And Enc_rd_Fil.Checked = False And Not PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByNat_Doc_Poi(NatMar_Fil.Text, _Doc, PoiTotMar_Fil.Text).Tables("MarchandisesByNat&Doc&Poi")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par la nature, les documents de transit et le Poids total", DateTime.Now,
                                              (NatMar_Fil.Text + "," + _Doc + "," + PoiTotMar_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NatMar_Fil.Text.Trim().Equals("") And Not LibMar_Fil.Text.Trim().Equals("") And (Com_rd_Fil.Checked = True Or Man_rd_Fil.Checked = True Or Pas_rd_Fil.Checked = True) And Liv_rd_Fil.Checked = False And Pasl_rd_Fil.Checked = False And Enc_rd_Fil.Checked = False And Not PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByLibe_Doc_Poi(LibMar_Fil.Text, _Doc, PoiTotMar_Fil.Text).Tables("MarchandisesByLibe&Doc&Poi")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par le libelle, les documents de transit et le Poids total", DateTime.Now,
                                             (LibMar_Fil.Text + "," + _Doc + "," + PoiTotMar_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NatMar_Fil.Text.Trim().Equals("") And Not LibMar_Fil.Text.Trim().Equals("") And (Com_rd_Fil.Checked = True Or Man_rd_Fil.Checked = True Or Pas_rd_Fil.Checked = True) And Liv_rd_Fil.Checked = False And Pasl_rd_Fil.Checked = False And Enc_rd_Fil.Checked = False And Not PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByNat_Libe_Doc_Poi(NatMar_Fil.Text, LibMar_Fil.Text, _Doc, PoiTotMar_Fil.Text).Tables("MarchandisesByNat&Libe&Doc&Poi")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par la nature, le libelle les documents de transit et le Poids total", DateTime.Now,
                                             (NatMar_Fil.Text + "," + LibMar_Fil.Text + "," + _Doc + "," + PoiTotMar_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NatMar_Fil.Text.Trim().Equals("") And LibMar_Fil.Text.Trim().Equals("") And Com_rd_Fil.Checked = False And Man_rd_Fil.Checked = False And Pas_rd_Fil.Checked = False And (Liv_rd_Fil.Checked = True Or Pasl_rd_Fil.Checked = True Or Enc_rd_Fil.Checked = True) And Not PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataBySta_Poi(_Sta, PoiTotMar_Fil.Text).Tables("MarchandisesBySta&Poi")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par le statut et le Poids total", DateTime.Now,
                                            (_Sta + "," + PoiTotMar_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NatMar_Fil.Text.Trim().Equals("") And LibMar_Fil.Text.Trim().Equals("") And Com_rd_Fil.Checked = False And Man_rd_Fil.Checked = False And Pas_rd_Fil.Checked = False And (Liv_rd_Fil.Checked = True Or Pasl_rd_Fil.Checked = True Or Enc_rd_Fil.Checked = True) And Not PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByNat_Sta_Poi(NatMar_Fil.Text, _Sta, PoiTotMar_Fil.Text).Tables("MarchandisesByNat&Sta&Poi")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par la nature, le statut et le Poids total", DateTime.Now,
                                            (NatMar_Fil.Text + "," + _Sta + "," + PoiTotMar_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NatMar_Fil.Text.Trim().Equals("") And Not LibMar_Fil.Text.Trim().Equals("") And Com_rd_Fil.Checked = False And Man_rd_Fil.Checked = False And Pas_rd_Fil.Checked = False And (Liv_rd_Fil.Checked = True Or Pasl_rd_Fil.Checked = True Or Enc_rd_Fil.Checked = True) And Not PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataBylibe_Sta_Poi(LibMar_Fil.Text, _Sta, PoiTotMar_Fil.Text).Tables("MarchandisesByLibe&Sta&Poi")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par le libelle, le statut et le Poids total", DateTime.Now,
                                            (LibMar_Fil.Text + "," + _Sta + "," + PoiTotMar_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NatMar_Fil.Text.Trim().Equals("") And Not LibMar_Fil.Text.Trim().Equals("") And Com_rd_Fil.Checked = False And Man_rd_Fil.Checked = False And Pas_rd_Fil.Checked = False And (Liv_rd_Fil.Checked = True Or Pasl_rd_Fil.Checked = True Or Enc_rd_Fil.Checked = True) And Not PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByNat_Libe_Sta_Poi(NatMar_Fil.Text, LibMar_Fil.Text, _Sta, PoiTotMar_Fil.Text).Tables("MarchandisesByNat&Libe&Sta&Poi")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par la nature, le libelle, le statut et le Poids total", DateTime.Now,
                                            (NatMar_Fil.Text + "," + LibMar_Fil.Text + "," + _Sta + "," + PoiTotMar_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NatMar_Fil.Text.Trim().Equals("") And LibMar_Fil.Text.Trim().Equals("") And (Com_rd_Fil.Checked = True Or Man_rd_Fil.Checked = True Or Pas_rd_Fil.Checked = True) And (Liv_rd_Fil.Checked = True Or Pasl_rd_Fil.Checked = True Or Enc_rd_Fil.Checked = True) And Not PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByDoc_Sta_Poi(_Doc, _Sta, PoiTotMar_Fil.Text).Tables("MarchandisesByDoc&Sta&Poi")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par les documents de transit, le statut et le Poids total", DateTime.Now,
                                            (_Doc + "," + _Sta + "," + PoiTotMar_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NatMar_Fil.Text.Trim().Equals("") And LibMar_Fil.Text.Trim().Equals("") And (Com_rd_Fil.Checked = True Or Man_rd_Fil.Checked = True Or Pas_rd_Fil.Checked = True) And (Liv_rd_Fil.Checked = True Or Pasl_rd_Fil.Checked = True Or Enc_rd_Fil.Checked = True) And Not PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByNat_Doc_Sta_Poi(NatMar_Fil.Text, _Doc, _Sta, PoiTotMar_Fil.Text).Tables("MarchandisesByNat&Doc&Sta&Poi")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par la nature, les documents de transit, le statut et le Poids total", DateTime.Now,
                                            (NatMar_Fil.Text + "," + _Doc + "," + _Sta + "," + PoiTotMar_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NatMar_Fil.Text.Trim().Equals("") And Not LibMar_Fil.Text.Trim().Equals("") And (Com_rd_Fil.Checked = True Or Man_rd_Fil.Checked = True Or Pas_rd_Fil.Checked = True) And (Liv_rd_Fil.Checked = True Or Pasl_rd_Fil.Checked = True Or Enc_rd_Fil.Checked = True) And Not PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByLibe_Doc_Sta_Poi(LibMar_Fil.Text, _Doc, _Sta, PoiTotMar_Fil.Text).Tables("MarchandisesByLibe&Doc&Sta&Poi")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par le libelle, les documents de transit,le statut et le Poids total", DateTime.Now,
                                            (LibMar_Fil.Text + "," + _Doc + "," + _Sta + "," + PoiTotMar_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Not NatMar_Fil.Text.Trim().Equals("") And Not LibMar_Fil.Text.Trim().Equals("") And (Com_rd_Fil.Checked = True Or Man_rd_Fil.Checked = True Or Pas_rd_Fil.Checked = True) And (Liv_rd_Fil.Checked = True Or Pasl_rd_Fil.Checked = True Or Enc_rd_Fil.Checked = True) And Not PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                DataGridMar.DataSource = metierM.getDataByNat_Libe_Doc_Sta_Poi(NatMar_Fil.Text, LibMar_Fil.Text, _Doc, _Sta, PoiTotMar_Fil.Text).Tables("MarchandisesByNat&Libe&Doc&Sta&Poi")
                DataGridMar.Columns()(0).Visible = False
                Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Recherche d'une Marchandise par la nature, le libelle, les documents de transit, le statut et le Poids total", DateTime.Now,
                                            (NatMar_Fil.Text + "," + LibMar_Fil.Text + "," + _Doc + "," + _Sta + "," + PoiTotMar_Fil.Text))
                metierH.AddHis_User(his)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf NatMar_Fil.Text.Trim().Equals("") And LibMar_Fil.Text.Trim().Equals("") And Com_rd_Fil.Checked = False And Man_rd_Fil.Checked = False And Pas_rd_Fil.Checked = False And Liv_rd_Fil.Checked = False And Pasl_rd_Fil.Checked = False And Enc_rd_Fil.Checked = False And PoiTotMar_Fil.Text.Trim().Equals("") Then
            Try
                charger()
            Catch ex As Exception
                    MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If




    End Sub

    'Supprimer des élements
    Private Sub DeleteMar_Click(sender As Object, e As EventArgs) Handles DeleteMar.Click

        Dim rsult As DialogResult = MessageBox.Show("Etes-vous sûr(e) de vouloir supprimer", "Confirmation",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If rsult = Windows.Forms.DialogResult.Yes Then
            For i As Int32 = 0 To DataGridMar.SelectedRows.Count - 1
                Dim IdMar As Int32
                Try
                    Dim li As String = DataGridMar.SelectedRows(i).Cells(1).Value
                    IdMar = DataGridMar.SelectedRows(i).Cells(0).Value
                    Try
                        metierM.DeleteMarchandises(IdMar)
                        Dim his = New Historiques_Users(metierU.getUserById(Authentification.use.Id_User), "Suppression d'une Marchandise", DateTime.Now, li)
                        metierH.AddHis_User(his)
                    Catch ex As Exception
                        MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Catch ex As Exception
                    MessageBox.Show("Selectionner une marchandise au moins pour cette opération", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

    Dim j As Integer = 0
    Dim tab(100) As Integer
    'Affecter Marchandises au trajet
    Private Sub AffMar_Click(sender As Object, e As EventArgs) Handles AffMar.Click

        'recuperer tous les Id du datagrid des marchandises a transportées
        For count As Int32 = 0 To Gestion_Trajet.DataGridMar_Tra.Rows.Count - 2
            Dim Cell As Integer = Gestion_Trajet.DataGridMar_Tra.Rows(count).Cells(0).Value
            tab(count) = Cell

        Next
        If j = 0 Then
            'créer des colunm pour le dataGrid
            Gestion_Trajet.DataGridMar_Tra.Columns.Add("Id_Marchandise", "Id_Marchandise")
            Gestion_Trajet.DataGridMar_Tra.Columns.Add("Libelle", "Libelle")
            Gestion_Trajet.DataGridMar_Tra.Columns.Add("Nature", "Nature")
            Gestion_Trajet.DataGridMar_Tra.Columns.Add("Valeur", "Valeur")
            Gestion_Trajet.DataGridMar_Tra.Columns.Add("Poids", "Poids")
            Gestion_Trajet.DataGridMar_Tra.Columns.Add("Quantite", "Quantite")
            Gestion_Trajet.DataGridMar_Tra.Columns.Add("Etat", "Etat")
            Gestion_Trajet.DataGridMar_Tra.Columns.Add("Document", "Id_Marchandise")
            Gestion_Trajet.DataGridMar_Tra.Columns.Add("Date_Enregistrement", "Date_Enregistrement")
            Gestion_Trajet.DataGridMar_Tra.Columns.Add("Statut", "Statut")
        End If
        j = j + 1


        Dim c As Integer = 0
        'transferer un DataGrid dans un Autre
        For i As Int32 = 0 To DataGridMar.SelectedRows.Count - 1
            Dim IdMar As Int32
            Try
                IdMar = DataGridMar.SelectedRows(i).Cells(0).Value
            Catch ex As Exception
                MessageBox.Show("Selectionner une marchandise au moins pour cette opération", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
            'tester si l'id existe dans l'autre data  
            For k As Integer = 0 To 100
                If IdMar = tab(k) Then
                    c = 1
                End If
            Next
            Dim Cell7 = DataGridMar.SelectedRows(i).Cells(7).Value
            Dim Cell9 = DataGridMar.SelectedRows(i).Cells(9).Value

            If Cell9 = "Pas livré" Then
                If Cell7 = "Manque" Then
                    MessageBox.Show("Les documents de transit sont incomplets", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    If c = 0 Then
                        Dim Cell1 = DataGridMar.SelectedRows(i).Cells(1).Value
                        Dim Cell2 = DataGridMar.SelectedRows(i).Cells(2).Value
                        Dim Cell3 = DataGridMar.SelectedRows(i).Cells(3).Value
                        Dim Cell4 = DataGridMar.SelectedRows(i).Cells(4).Value
                        Dim Cell5 = DataGridMar.SelectedRows(i).Cells(5).Value
                        Dim Cell6 = DataGridMar.SelectedRows(i).Cells(6).Value
                        Dim Cell8 = DataGridMar.SelectedRows(i).Cells(8).Value


                        Dim rows As String() = New String() {IdMar, Cell1, Cell2, Cell3, Cell4, Cell5, Cell6, Cell7, Cell8, Cell9}
                        Gestion_Trajet.DataGridMar_Tra.Columns()(0).Visible = False
                        Gestion_Trajet.DataGridMar_Tra.Rows.Add(rows)

                        Gestion_Trajet.Poidsdep.Text = "0"
                        'chargement du poid du deplacement
                        For d As Int32 = 0 To Gestion_Trajet.DataGridMar_Tra.Rows.Count - 2
                            Dim PoiMar As Double = Gestion_Trajet.DataGridMar_Tra.Rows(d).Cells(4).Value
                            Dim QuaMar As Int32 = Gestion_Trajet.DataGridMar_Tra.Rows(d).Cells(5).Value
                            Gestion_Trajet.Poidsdep.Text = (Double.Parse(Gestion_Trajet.Poidsdep.Text) + (PoiMar * QuaMar)).ToString
                        Next

                    Else
                        MessageBox.Show("Cet élement existe déjà dans les produits à acheminer", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Else
                MessageBox.Show("Vous ne pouvez que transporter les marchandises encore non livré ", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Next
        Gestion_Trajet.Show()
        Me.Hide()
    End Sub

    'details sur les champs
    Private Sub DataGridMar_DoubleClick(sender As Object, e As EventArgs) Handles DataGridMar.DoubleClick
        For i As Int32 = 0 To DataGridMar.SelectedRows.Count - 1
            Dim IdMar As Int32
            Try
                IdMar = DataGridMar.SelectedRows(i).Cells(0).Value
                Dim ma As Marchandises = metierM.getMarchandisesById(IdMar)
                DetailsDatagrid.L1.Visible = True
                DetailsDatagrid.L1.Text = "Nature"
                DetailsDatagrid.T1.Visible = True
                DetailsDatagrid.T1.Text = ma.Nature
                DetailsDatagrid.L2.Visible = True
                DetailsDatagrid.L2.Text = "Libelle"
                DetailsDatagrid.T2.Visible = True
                DetailsDatagrid.T2.Text = ma.Libelle
                DetailsDatagrid.L3.Visible = True
                DetailsDatagrid.L3.Text = "Valeur"
                DetailsDatagrid.T3.Visible = True
                DetailsDatagrid.T3.Text = ma.Valeur
                DetailsDatagrid.L4.Visible = True
                DetailsDatagrid.L4.Text = "Poids (Kg)"
                DetailsDatagrid.T4.Visible = True
                DetailsDatagrid.T4.Text = ma.Poids
                DetailsDatagrid.L5.Visible = True
                DetailsDatagrid.L5.Text = "Quantité"
                DetailsDatagrid.T5.Visible = True
                DetailsDatagrid.T5.Text = ma.Quantite
                DetailsDatagrid.L6.Visible = True
                DetailsDatagrid.L6.Text = "Document de transite"
                DetailsDatagrid.T6.Visible = True
                DetailsDatagrid.T6.Text = ma.Documents
                DetailsDatagrid.L7.Visible = True
                DetailsDatagrid.L7.Text = "Etat"
                DetailsDatagrid.T7.Visible = True
                DetailsDatagrid.T7.Text = ma.Etat
                DetailsDatagrid.L8.Visible = True
                DetailsDatagrid.L8.Text = "Date d'enregistrement"
                DetailsDatagrid.T8.Visible = True
                DetailsDatagrid.T8.Text = ma.Date_Enregistrement
                DetailsDatagrid.L9.Visible = True
                DetailsDatagrid.L9.Text = "Statut"
                DetailsDatagrid.T9.Visible = True
                DetailsDatagrid.T9.Text = ma.Statut
                DetailsDatagrid.Show()
            Catch ex As Exception
                MessageBox.Show("Le double-clic doit être sur une marchandise pour cette operation", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        Next
    End Sub

    'clique sur Administration
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click, Label17.Click, Admin.Click
        Administration.Show()
        Me.Close()
        Gestion_Conducteur.Close()
        Gestion_garage.Close()
        Gestion_Trajet.Close()
        Gestion_Véhicules.Close()
        Historiques.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur historique 
    Private Sub Panel5_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click, Panel5.Click, Label8.Click
        Historiques.Show()
        Me.Close()
        Gestion_Conducteur.Close()
        Gestion_garage.Close()
        Administration.Close()
        Gestion_Véhicules.Close()
        Gestion_Trajet.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur trajet
    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click, Panel9.Click, Label13.Click
        Gestion_Trajet.Show()
        Me.Close()
        Gestion_Conducteur.Close()
        Gestion_garage.Close()
        Historiques.Close()
        Gestion_Véhicules.Close()
        Administration.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur véhicule
    Private Sub Panel4_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click, Panel4.Click, Label9.Click
        Gestion_Véhicules.Show()
        Me.Close()
        Gestion_Conducteur.Close()
        Gestion_garage.Close()
        Administration.Close()
        Gestion_Trajet.Close()
        Historiques.Close()
        Ajouter_un_Vehicule_et_ses_Pieces.Close()
        créer_un_Utilisateur.Close()
    End Sub

    'clique sur conducteur
    Private Sub Panel10_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click, Panel10.Click, Label14.Click
        Gestion_Conducteur.Show()
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
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click, Label1.Click
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