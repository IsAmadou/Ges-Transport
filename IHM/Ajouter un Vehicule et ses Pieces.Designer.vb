<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Ajouter_un_Vehicule_et_ses_Pieces
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ajouter_un_Vehicule_et_ses_Pieces))
        Me.imm = New System.Windows.Forms.Label()
        Me.Cap = New System.Windows.Forms.Label()
        Me.Typ_Mot = New System.Windows.Forms.Label()
        Me.Num_Cha = New System.Windows.Forms.Label()
        Me.Mod_Veh = New System.Windows.Forms.Label()
        Me.typ_Veh = New System.Windows.Forms.Label()
        Me.Eta_Veh = New System.Windows.Forms.Label()
        Me.Vig = New System.Windows.Forms.Label()
        Me.Car_Gri = New System.Windows.Forms.Label()
        Me.Exp_Vig = New System.Windows.Forms.Label()
        Me.Exp_Ass = New System.Windows.Forms.Label()
        Me.Ass = New System.Windows.Forms.Label()
        Me.TypM_lbl = New System.Windows.Forms.ComboBox()
        Me.TitrAddVeh = New System.Windows.Forms.Label()
        Me.Mod_lbl = New System.Windows.Forms.TextBox()
        Me.Imm_lbl = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Eta_lbl = New System.Windows.Forms.Panel()
        Me.Disp_rb = New System.Windows.Forms.RadioButton()
        Me.Ind_rb = New System.Windows.Forms.RadioButton()
        Me.Châ_lbl = New System.Windows.Forms.TextBox()
        Me.Cap_lbl = New System.Windows.Forms.TextBox()
        Me.CarGri_lbl = New System.Windows.Forms.Panel()
        Me.Oui_rb = New System.Windows.Forms.RadioButton()
        Me.Non_rb = New System.Windows.Forms.RadioButton()
        Me.Vig_lbl = New System.Windows.Forms.ComboBox()
        Me.Ass_lbl = New System.Windows.Forms.ComboBox()
        Me.DatExpVig_lbl = New System.Windows.Forms.DateTimePicker()
        Me.DatExpAss_lbl = New System.Windows.Forms.DateTimePicker()
        Me.Eng_veh = New System.Windows.Forms.Button()
        Me.AnnVeh = New System.Windows.Forms.Button()
        Me.Typ_lbl = New System.Windows.Forms.ComboBox()
        Me.UpdateVeh = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Id_p = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Eta_lbl.SuspendLayout()
        Me.CarGri_lbl.SuspendLayout()
        CType(Me.UpdateVeh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'imm
        '
        Me.imm.AutoSize = True
        Me.imm.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.imm.Location = New System.Drawing.Point(33, 192)
        Me.imm.Name = "imm"
        Me.imm.Size = New System.Drawing.Size(105, 19)
        Me.imm.TabIndex = 1
        Me.imm.Text = "Immatriculation"
        '
        'Cap
        '
        Me.Cap.AutoSize = True
        Me.Cap.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cap.Location = New System.Drawing.Point(57, 351)
        Me.Cap.Name = "Cap"
        Me.Cap.Size = New System.Drawing.Size(64, 19)
        Me.Cap.TabIndex = 2
        Me.Cap.Text = "Capacité"
        '
        'Typ_Mot
        '
        Me.Typ_Mot.AutoSize = True
        Me.Typ_Mot.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Typ_Mot.Location = New System.Drawing.Point(475, 349)
        Me.Typ_Mot.Name = "Typ_Mot"
        Me.Typ_Mot.Size = New System.Drawing.Size(91, 19)
        Me.Typ_Mot.TabIndex = 3
        Me.Typ_Mot.Text = "Type_Moteur"
        '
        'Num_Cha
        '
        Me.Num_Cha.AutoSize = True
        Me.Num_Cha.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Num_Cha.Location = New System.Drawing.Point(485, 291)
        Me.Num_Cha.Name = "Num_Cha"
        Me.Num_Cha.Size = New System.Drawing.Size(69, 19)
        Me.Num_Cha.TabIndex = 4
        Me.Num_Cha.Text = "N°Châssis"
        '
        'Mod_Veh
        '
        Me.Mod_Veh.AutoSize = True
        Me.Mod_Veh.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mod_Veh.Location = New System.Drawing.Point(57, 291)
        Me.Mod_Veh.Name = "Mod_Veh"
        Me.Mod_Veh.Size = New System.Drawing.Size(54, 19)
        Me.Mod_Veh.TabIndex = 5
        Me.Mod_Veh.Text = "Modèle"
        '
        'typ_Veh
        '
        Me.typ_Veh.AutoSize = True
        Me.typ_Veh.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.typ_Veh.Location = New System.Drawing.Point(464, 192)
        Me.typ_Veh.Name = "typ_Veh"
        Me.typ_Veh.Size = New System.Drawing.Size(102, 19)
        Me.typ_Veh.TabIndex = 6
        Me.typ_Veh.Text = "Type_Véhicule"
        '
        'Eta_Veh
        '
        Me.Eta_Veh.AutoSize = True
        Me.Eta_Veh.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Eta_Veh.Location = New System.Drawing.Point(215, 241)
        Me.Eta_Veh.Name = "Eta_Veh"
        Me.Eta_Veh.Size = New System.Drawing.Size(97, 19)
        Me.Eta_Veh.TabIndex = 7
        Me.Eta_Veh.Text = "Etat_Véhicule"
        '
        'Vig
        '
        Me.Vig.AutoSize = True
        Me.Vig.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Vig.Location = New System.Drawing.Point(57, 491)
        Me.Vig.Name = "Vig"
        Me.Vig.Size = New System.Drawing.Size(64, 19)
        Me.Vig.TabIndex = 8
        Me.Vig.Text = "Vignette"
        '
        'Car_Gri
        '
        Me.Car_Gri.AutoSize = True
        Me.Car_Gri.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Car_Gri.Location = New System.Drawing.Point(235, 416)
        Me.Car_Gri.Name = "Car_Gri"
        Me.Car_Gri.Size = New System.Drawing.Size(76, 19)
        Me.Car_Gri.TabIndex = 9
        Me.Car_Gri.Text = "Carte grise"
        '
        'Exp_Vig
        '
        Me.Exp_Vig.AutoSize = True
        Me.Exp_Vig.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Exp_Vig.Location = New System.Drawing.Point(409, 492)
        Me.Exp_Vig.Name = "Exp_Vig"
        Me.Exp_Vig.Size = New System.Drawing.Size(204, 19)
        Me.Exp_Vig.TabIndex = 10
        Me.Exp_Vig.Text = "Date d'expiration de la Vignette"
        '
        'Exp_Ass
        '
        Me.Exp_Ass.AutoSize = True
        Me.Exp_Ass.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Exp_Ass.Location = New System.Drawing.Point(415, 558)
        Me.Exp_Ass.Name = "Exp_Ass"
        Me.Exp_Ass.Size = New System.Drawing.Size(199, 19)
        Me.Exp_Ass.TabIndex = 11
        Me.Exp_Ass.Text = "Date d'expiration de l'assurance"
        '
        'Ass
        '
        Me.Ass.AutoSize = True
        Me.Ass.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ass.Location = New System.Drawing.Point(49, 560)
        Me.Ass.Name = "Ass"
        Me.Ass.Size = New System.Drawing.Size(72, 19)
        Me.Ass.TabIndex = 12
        Me.Ass.Text = "Assurance"
        '
        'TypM_lbl
        '
        Me.TypM_lbl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TypM_lbl.FormattingEnabled = True
        Me.TypM_lbl.Items.AddRange(New Object() {"Essence ", "Gazoil", "Kérozène", "Electrique ", "Vapeur", "Non motorisé"})
        Me.TypM_lbl.Location = New System.Drawing.Point(588, 347)
        Me.TypM_lbl.Name = "TypM_lbl"
        Me.TypM_lbl.Size = New System.Drawing.Size(249, 21)
        Me.TypM_lbl.TabIndex = 16
        '
        'TitrAddVeh
        '
        Me.TitrAddVeh.AutoSize = True
        Me.TitrAddVeh.Font = New System.Drawing.Font("Modern No. 20", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitrAddVeh.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TitrAddVeh.Location = New System.Drawing.Point(462, 67)
        Me.TitrAddVeh.Name = "TitrAddVeh"
        Me.TitrAddVeh.Size = New System.Drawing.Size(177, 24)
        Me.TitrAddVeh.TabIndex = 17
        Me.TitrAddVeh.Text = "Ajouter un véhicule"
        '
        'Mod_lbl
        '
        Me.Mod_lbl.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mod_lbl.Location = New System.Drawing.Point(163, 288)
        Me.Mod_lbl.Name = "Mod_lbl"
        Me.Mod_lbl.Size = New System.Drawing.Size(249, 26)
        Me.Mod_lbl.TabIndex = 19
        '
        'Imm_lbl
        '
        Me.Imm_lbl.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Imm_lbl.Location = New System.Drawing.Point(163, 189)
        Me.Imm_lbl.Name = "Imm_lbl"
        Me.Imm_lbl.Size = New System.Drawing.Size(249, 26)
        Me.Imm_lbl.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Modern No. 20", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(410, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 65)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "+"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(251, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(161, 140)
        Me.PictureBox1.TabIndex = 24
        Me.PictureBox1.TabStop = False
        '
        'Eta_lbl
        '
        Me.Eta_lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Eta_lbl.Controls.Add(Me.Disp_rb)
        Me.Eta_lbl.Controls.Add(Me.Ind_rb)
        Me.Eta_lbl.Location = New System.Drawing.Point(326, 235)
        Me.Eta_lbl.Name = "Eta_lbl"
        Me.Eta_lbl.Size = New System.Drawing.Size(318, 35)
        Me.Eta_lbl.TabIndex = 25
        '
        'Disp_rb
        '
        Me.Disp_rb.AutoSize = True
        Me.Disp_rb.Font = New System.Drawing.Font("Poor Richard", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Disp_rb.Location = New System.Drawing.Point(13, 6)
        Me.Disp_rb.Name = "Disp_rb"
        Me.Disp_rb.Size = New System.Drawing.Size(88, 22)
        Me.Disp_rb.TabIndex = 16
        Me.Disp_rb.TabStop = True
        Me.Disp_rb.Text = "Disponible"
        Me.Disp_rb.UseVisualStyleBackColor = True
        '
        'Ind_rb
        '
        Me.Ind_rb.AutoSize = True
        Me.Ind_rb.Font = New System.Drawing.Font("Poor Richard", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ind_rb.Location = New System.Drawing.Point(190, 6)
        Me.Ind_rb.Name = "Ind_rb"
        Me.Ind_rb.Size = New System.Drawing.Size(96, 22)
        Me.Ind_rb.TabIndex = 15
        Me.Ind_rb.TabStop = True
        Me.Ind_rb.Text = "Indisponible"
        Me.Ind_rb.UseVisualStyleBackColor = True
        '
        'Châ_lbl
        '
        Me.Châ_lbl.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Châ_lbl.Location = New System.Drawing.Point(588, 288)
        Me.Châ_lbl.Name = "Châ_lbl"
        Me.Châ_lbl.Size = New System.Drawing.Size(249, 26)
        Me.Châ_lbl.TabIndex = 26
        '
        'Cap_lbl
        '
        Me.Cap_lbl.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cap_lbl.Location = New System.Drawing.Point(163, 351)
        Me.Cap_lbl.Name = "Cap_lbl"
        Me.Cap_lbl.Size = New System.Drawing.Size(194, 26)
        Me.Cap_lbl.TabIndex = 27
        '
        'CarGri_lbl
        '
        Me.CarGri_lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CarGri_lbl.Controls.Add(Me.Oui_rb)
        Me.CarGri_lbl.Controls.Add(Me.Non_rb)
        Me.CarGri_lbl.Location = New System.Drawing.Point(326, 411)
        Me.CarGri_lbl.Name = "CarGri_lbl"
        Me.CarGri_lbl.Size = New System.Drawing.Size(318, 30)
        Me.CarGri_lbl.TabIndex = 26
        '
        'Oui_rb
        '
        Me.Oui_rb.AutoSize = True
        Me.Oui_rb.Font = New System.Drawing.Font("Poor Richard", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Oui_rb.Location = New System.Drawing.Point(31, 4)
        Me.Oui_rb.Name = "Oui_rb"
        Me.Oui_rb.Size = New System.Drawing.Size(48, 22)
        Me.Oui_rb.TabIndex = 16
        Me.Oui_rb.TabStop = True
        Me.Oui_rb.Text = "Oui"
        Me.Oui_rb.UseVisualStyleBackColor = True
        '
        'Non_rb
        '
        Me.Non_rb.AutoSize = True
        Me.Non_rb.Font = New System.Drawing.Font("Poor Richard", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Non_rb.Location = New System.Drawing.Point(227, 4)
        Me.Non_rb.Name = "Non_rb"
        Me.Non_rb.Size = New System.Drawing.Size(50, 22)
        Me.Non_rb.TabIndex = 15
        Me.Non_rb.TabStop = True
        Me.Non_rb.Text = "Non"
        Me.Non_rb.UseVisualStyleBackColor = True
        '
        'Vig_lbl
        '
        Me.Vig_lbl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Vig_lbl.FormattingEnabled = True
        Me.Vig_lbl.Items.AddRange(New Object() {"Oui", "Non"})
        Me.Vig_lbl.Location = New System.Drawing.Point(163, 489)
        Me.Vig_lbl.Name = "Vig_lbl"
        Me.Vig_lbl.Size = New System.Drawing.Size(194, 21)
        Me.Vig_lbl.TabIndex = 28
        '
        'Ass_lbl
        '
        Me.Ass_lbl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Ass_lbl.FormattingEnabled = True
        Me.Ass_lbl.Items.AddRange(New Object() {"Oui", "Non"})
        Me.Ass_lbl.Location = New System.Drawing.Point(163, 558)
        Me.Ass_lbl.Name = "Ass_lbl"
        Me.Ass_lbl.Size = New System.Drawing.Size(194, 21)
        Me.Ass_lbl.TabIndex = 29
        '
        'DatExpVig_lbl
        '
        Me.DatExpVig_lbl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatExpVig_lbl.Location = New System.Drawing.Point(647, 492)
        Me.DatExpVig_lbl.Name = "DatExpVig_lbl"
        Me.DatExpVig_lbl.Size = New System.Drawing.Size(190, 20)
        Me.DatExpVig_lbl.TabIndex = 30
        '
        'DatExpAss_lbl
        '
        Me.DatExpAss_lbl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatExpAss_lbl.Location = New System.Drawing.Point(647, 555)
        Me.DatExpAss_lbl.Name = "DatExpAss_lbl"
        Me.DatExpAss_lbl.Size = New System.Drawing.Size(190, 20)
        Me.DatExpAss_lbl.TabIndex = 31
        '
        'Eng_veh
        '
        Me.Eng_veh.Font = New System.Drawing.Font("Segoe Marker", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Eng_veh.Location = New System.Drawing.Point(588, 642)
        Me.Eng_veh.Name = "Eng_veh"
        Me.Eng_veh.Size = New System.Drawing.Size(124, 28)
        Me.Eng_veh.TabIndex = 33
        Me.Eng_veh.Text = "Enregistrer"
        Me.Eng_veh.UseVisualStyleBackColor = True
        '
        'AnnVeh
        '
        Me.AnnVeh.Font = New System.Drawing.Font("Segoe Marker", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnnVeh.Location = New System.Drawing.Point(386, 642)
        Me.AnnVeh.Name = "AnnVeh"
        Me.AnnVeh.Size = New System.Drawing.Size(124, 28)
        Me.AnnVeh.TabIndex = 32
        Me.AnnVeh.Text = "Annuler"
        Me.AnnVeh.UseVisualStyleBackColor = True
        '
        'Typ_lbl
        '
        Me.Typ_lbl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Typ_lbl.FormattingEnabled = True
        Me.Typ_lbl.Items.AddRange(New Object() {"Bicyclette", "Tricycle", "Moto", "Chariot", "Voiture", "Camion", "Train", "Avion", "Bateau"})
        Me.Typ_lbl.Location = New System.Drawing.Point(588, 193)
        Me.Typ_lbl.Name = "Typ_lbl"
        Me.Typ_lbl.Size = New System.Drawing.Size(249, 21)
        Me.Typ_lbl.TabIndex = 34
        '
        'UpdateVeh
        '
        Me.UpdateVeh.BackgroundImage = CType(resources.GetObject("UpdateVeh.BackgroundImage"), System.Drawing.Image)
        Me.UpdateVeh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.UpdateVeh.Location = New System.Drawing.Point(421, 54)
        Me.UpdateVeh.Name = "UpdateVeh"
        Me.UpdateVeh.Size = New System.Drawing.Size(28, 50)
        Me.UpdateVeh.TabIndex = 35
        Me.UpdateVeh.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(355, 351)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(57, 26)
        Me.Panel1.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Kg"
        '
        'Id_p
        '
        Me.Id_p.AutoSize = True
        Me.Id_p.Location = New System.Drawing.Point(714, 90)
        Me.Id_p.Name = "Id_p"
        Me.Id_p.Size = New System.Drawing.Size(0, 13)
        Me.Id_p.TabIndex = 37
        Me.Id_p.Visible = False
        '
        'Ajouter_un_Vehicule_et_ses_Pieces
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(874, 675)
        Me.Controls.Add(Me.Id_p)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.UpdateVeh)
        Me.Controls.Add(Me.Typ_lbl)
        Me.Controls.Add(Me.Eng_veh)
        Me.Controls.Add(Me.AnnVeh)
        Me.Controls.Add(Me.DatExpAss_lbl)
        Me.Controls.Add(Me.DatExpVig_lbl)
        Me.Controls.Add(Me.Ass_lbl)
        Me.Controls.Add(Me.Vig_lbl)
        Me.Controls.Add(Me.CarGri_lbl)
        Me.Controls.Add(Me.Cap_lbl)
        Me.Controls.Add(Me.Châ_lbl)
        Me.Controls.Add(Me.Eta_lbl)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Imm_lbl)
        Me.Controls.Add(Me.Mod_lbl)
        Me.Controls.Add(Me.TitrAddVeh)
        Me.Controls.Add(Me.TypM_lbl)
        Me.Controls.Add(Me.Ass)
        Me.Controls.Add(Me.Exp_Ass)
        Me.Controls.Add(Me.Exp_Vig)
        Me.Controls.Add(Me.Car_Gri)
        Me.Controls.Add(Me.Vig)
        Me.Controls.Add(Me.Eta_Veh)
        Me.Controls.Add(Me.typ_Veh)
        Me.Controls.Add(Me.Mod_Veh)
        Me.Controls.Add(Me.Num_Cha)
        Me.Controls.Add(Me.Typ_Mot)
        Me.Controls.Add(Me.Cap)
        Me.Controls.Add(Me.imm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Ajouter_un_Vehicule_et_ses_Pieces"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajouter_un_Vehicule_et_ses_Pieces"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Eta_lbl.ResumeLayout(False)
        Me.Eta_lbl.PerformLayout()
        Me.CarGri_lbl.ResumeLayout(False)
        Me.CarGri_lbl.PerformLayout()
        CType(Me.UpdateVeh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imm As Label
    Friend WithEvents Cap As Label
    Friend WithEvents Typ_Mot As Label
    Friend WithEvents Num_Cha As Label
    Friend WithEvents Mod_Veh As Label
    Friend WithEvents typ_Veh As Label
    Friend WithEvents Eta_Veh As Label
    Friend WithEvents Vig As Label
    Friend WithEvents Car_Gri As Label
    Friend WithEvents Exp_Vig As Label
    Friend WithEvents Exp_Ass As Label
    Friend WithEvents Ass As Label
    Friend WithEvents TypM_lbl As ComboBox
    Friend WithEvents TitrAddVeh As Label
    Friend WithEvents Mod_lbl As TextBox
    Friend WithEvents Imm_lbl As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Eta_lbl As Panel
    Friend WithEvents Disp_rb As RadioButton
    Friend WithEvents Ind_rb As RadioButton
    Friend WithEvents Châ_lbl As TextBox
    Friend WithEvents Cap_lbl As TextBox
    Friend WithEvents CarGri_lbl As Panel
    Friend WithEvents Oui_rb As RadioButton
    Friend WithEvents Non_rb As RadioButton
    Friend WithEvents Vig_lbl As ComboBox
    Friend WithEvents Ass_lbl As ComboBox
    Friend WithEvents DatExpVig_lbl As DateTimePicker
    Friend WithEvents DatExpAss_lbl As DateTimePicker
    Friend WithEvents Eng_veh As Button
    Friend WithEvents AnnVeh As Button
    Friend WithEvents Typ_lbl As ComboBox
    Friend WithEvents UpdateVeh As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Id_p As Label
End Class
