<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Gestion_Véhicules
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Gestion_Véhicules))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RepVeh = New System.Windows.Forms.PictureBox()
        Me.DeleteVeh = New System.Windows.Forms.PictureBox()
        Me.UpdateVeh = New System.Windows.Forms.PictureBox()
        Me.AddTra = New System.Windows.Forms.PictureBox()
        Me.AddVeh = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TypVeh_Fil = New System.Windows.Forms.ComboBox()
        Me.Date_fil = New System.Windows.Forms.DateTimePicker()
        Me.CapVeh_Fil = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Dis_rd_Fil = New System.Windows.Forms.RadioButton()
        Me.Ind_rd_Fil = New System.Windows.Forms.RadioButton()
        Me.ImmVeh_Fil = New System.Windows.Forms.TextBox()
        Me.Eta_Veh = New System.Windows.Forms.Label()
        Me.typ_Veh = New System.Windows.Forms.Label()
        Me.Cap = New System.Windows.Forms.Label()
        Me.imm = New System.Windows.Forms.Label()
        Me.Veh = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DataGridVeh = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Admin = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Search = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        CType(Me.RepVeh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeleteVeh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpdateVeh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddTra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddVeh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridVeh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Admin.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RepVeh)
        Me.Panel2.Controls.Add(Me.DeleteVeh)
        Me.Panel2.Controls.Add(Me.UpdateVeh)
        Me.Panel2.Controls.Add(Me.AddTra)
        Me.Panel2.Controls.Add(Me.AddVeh)
        Me.Panel2.Location = New System.Drawing.Point(1217, 187)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(33, 502)
        Me.Panel2.TabIndex = 83
        '
        'RepVeh
        '
        Me.RepVeh.BackgroundImage = CType(resources.GetObject("RepVeh.BackgroundImage"), System.Drawing.Image)
        Me.RepVeh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RepVeh.Location = New System.Drawing.Point(3, 313)
        Me.RepVeh.Name = "RepVeh"
        Me.RepVeh.Size = New System.Drawing.Size(28, 50)
        Me.RepVeh.TabIndex = 9
        Me.RepVeh.TabStop = False
        '
        'DeleteVeh
        '
        Me.DeleteVeh.BackgroundImage = CType(resources.GetObject("DeleteVeh.BackgroundImage"), System.Drawing.Image)
        Me.DeleteVeh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.DeleteVeh.Location = New System.Drawing.Point(2, 438)
        Me.DeleteVeh.Name = "DeleteVeh"
        Me.DeleteVeh.Size = New System.Drawing.Size(28, 50)
        Me.DeleteVeh.TabIndex = 8
        Me.DeleteVeh.TabStop = False
        '
        'UpdateVeh
        '
        Me.UpdateVeh.BackgroundImage = CType(resources.GetObject("UpdateVeh.BackgroundImage"), System.Drawing.Image)
        Me.UpdateVeh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.UpdateVeh.Location = New System.Drawing.Point(3, 106)
        Me.UpdateVeh.Name = "UpdateVeh"
        Me.UpdateVeh.Size = New System.Drawing.Size(28, 50)
        Me.UpdateVeh.TabIndex = 7
        Me.UpdateVeh.TabStop = False
        '
        'AddTra
        '
        Me.AddTra.BackgroundImage = CType(resources.GetObject("AddTra.BackgroundImage"), System.Drawing.Image)
        Me.AddTra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.AddTra.Location = New System.Drawing.Point(3, 211)
        Me.AddTra.Name = "AddTra"
        Me.AddTra.Size = New System.Drawing.Size(28, 50)
        Me.AddTra.TabIndex = 6
        Me.AddTra.TabStop = False
        '
        'AddVeh
        '
        Me.AddVeh.BackgroundImage = CType(resources.GetObject("AddVeh.BackgroundImage"), System.Drawing.Image)
        Me.AddVeh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.AddVeh.Location = New System.Drawing.Point(3, 11)
        Me.AddVeh.Name = "AddVeh"
        Me.AddVeh.Size = New System.Drawing.Size(28, 50)
        Me.AddVeh.TabIndex = 5
        Me.AddVeh.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(784, 336)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 19)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Date du départ"
        '
        'TypVeh_Fil
        '
        Me.TypVeh_Fil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TypVeh_Fil.FormattingEnabled = True
        Me.TypVeh_Fil.Items.AddRange(New Object() {"Bicyclette", "Tricycle", "Moto", "Chariot", "Voiture", "Camion", "Train", "Avion", "Bateau"})
        Me.TypVeh_Fil.Location = New System.Drawing.Point(858, 225)
        Me.TypVeh_Fil.Name = "TypVeh_Fil"
        Me.TypVeh_Fil.Size = New System.Drawing.Size(249, 21)
        Me.TypVeh_Fil.TabIndex = 80
        '
        'Date_fil
        '
        Me.Date_fil.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date_fil.Location = New System.Drawing.Point(917, 336)
        Me.Date_fil.Name = "Date_fil"
        Me.Date_fil.Size = New System.Drawing.Size(190, 20)
        Me.Date_fil.TabIndex = 79
        '
        'CapVeh_Fil
        '
        Me.CapVeh_Fil.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CapVeh_Fil.Location = New System.Drawing.Point(433, 332)
        Me.CapVeh_Fil.Name = "CapVeh_Fil"
        Me.CapVeh_Fil.Size = New System.Drawing.Size(249, 26)
        Me.CapVeh_Fil.TabIndex = 78
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Dis_rd_Fil)
        Me.Panel1.Controls.Add(Me.Ind_rd_Fil)
        Me.Panel1.Location = New System.Drawing.Point(596, 267)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(318, 35)
        Me.Panel1.TabIndex = 77
        '
        'Dis_rd_Fil
        '
        Me.Dis_rd_Fil.AutoSize = True
        Me.Dis_rd_Fil.Font = New System.Drawing.Font("Poor Richard", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dis_rd_Fil.Location = New System.Drawing.Point(15, 6)
        Me.Dis_rd_Fil.Name = "Dis_rd_Fil"
        Me.Dis_rd_Fil.Size = New System.Drawing.Size(88, 22)
        Me.Dis_rd_Fil.TabIndex = 16
        Me.Dis_rd_Fil.TabStop = True
        Me.Dis_rd_Fil.Text = "Disponible"
        Me.Dis_rd_Fil.UseVisualStyleBackColor = True
        '
        'Ind_rd_Fil
        '
        Me.Ind_rd_Fil.AutoSize = True
        Me.Ind_rd_Fil.Font = New System.Drawing.Font("Poor Richard", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ind_rd_Fil.Location = New System.Drawing.Point(190, 6)
        Me.Ind_rd_Fil.Name = "Ind_rd_Fil"
        Me.Ind_rd_Fil.Size = New System.Drawing.Size(96, 22)
        Me.Ind_rd_Fil.TabIndex = 15
        Me.Ind_rd_Fil.TabStop = True
        Me.Ind_rd_Fil.Text = "Indisponible"
        Me.Ind_rd_Fil.UseVisualStyleBackColor = True
        '
        'ImmVeh_Fil
        '
        Me.ImmVeh_Fil.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImmVeh_Fil.Location = New System.Drawing.Point(433, 221)
        Me.ImmVeh_Fil.Name = "ImmVeh_Fil"
        Me.ImmVeh_Fil.Size = New System.Drawing.Size(249, 26)
        Me.ImmVeh_Fil.TabIndex = 76
        '
        'Eta_Veh
        '
        Me.Eta_Veh.AutoSize = True
        Me.Eta_Veh.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Eta_Veh.Location = New System.Drawing.Point(485, 273)
        Me.Eta_Veh.Name = "Eta_Veh"
        Me.Eta_Veh.Size = New System.Drawing.Size(97, 19)
        Me.Eta_Veh.TabIndex = 75
        Me.Eta_Veh.Text = "Etat_Véhicule"
        '
        'typ_Veh
        '
        Me.typ_Veh.AutoSize = True
        Me.typ_Veh.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.typ_Veh.Location = New System.Drawing.Point(734, 224)
        Me.typ_Veh.Name = "typ_Veh"
        Me.typ_Veh.Size = New System.Drawing.Size(102, 19)
        Me.typ_Veh.TabIndex = 74
        Me.typ_Veh.Text = "Type_Véhicule"
        '
        'Cap
        '
        Me.Cap.AutoSize = True
        Me.Cap.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cap.Location = New System.Drawing.Point(327, 335)
        Me.Cap.Name = "Cap"
        Me.Cap.Size = New System.Drawing.Size(64, 19)
        Me.Cap.TabIndex = 73
        Me.Cap.Text = "Capacité"
        '
        'imm
        '
        Me.imm.AutoSize = True
        Me.imm.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.imm.Location = New System.Drawing.Point(303, 224)
        Me.imm.Name = "imm"
        Me.imm.Size = New System.Drawing.Size(105, 19)
        Me.imm.TabIndex = 72
        Me.imm.Text = "Immatriculation"
        '
        'Veh
        '
        Me.Veh.AutoSize = True
        Me.Veh.Font = New System.Drawing.Font("Poor Richard", 20.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Veh.Location = New System.Drawing.Point(769, 71)
        Me.Veh.Name = "Veh"
        Me.Veh.Size = New System.Drawing.Size(115, 31)
        Me.Veh.TabIndex = 71
        Me.Veh.Text = "Véhicules"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(569, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(192, 152)
        Me.PictureBox1.TabIndex = 70
        Me.PictureBox1.TabStop = False
        '
        'DataGridVeh
        '
        Me.DataGridVeh.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGridVeh.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridVeh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridVeh.Location = New System.Drawing.Point(384, 368)
        Me.DataGridVeh.Name = "DataGridVeh"
        Me.DataGridVeh.ReadOnly = True
        Me.DataGridVeh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridVeh.Size = New System.Drawing.Size(735, 321)
        Me.DataGridVeh.TabIndex = 69
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.Admin)
        Me.Panel3.Controls.Add(Me.Panel7)
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.PictureBox5)
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Panel9)
        Me.Panel3.Controls.Add(Me.Panel10)
        Me.Panel3.Location = New System.Drawing.Point(4, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(220, 706)
        Me.Panel3.TabIndex = 84
        '
        'Admin
        '
        Me.Admin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Admin.Controls.Add(Me.Label9)
        Me.Admin.Controls.Add(Me.PictureBox2)
        Me.Admin.Location = New System.Drawing.Point(1, 540)
        Me.Admin.Name = "Admin"
        Me.Admin.Size = New System.Drawing.Size(215, 54)
        Me.Admin.TabIndex = 87
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(83, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 18)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Administration"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(3, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(65, 51)
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'Panel7
        '
        Me.Panel7.Location = New System.Drawing.Point(222, 168)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1022, 336)
        Me.Panel7.TabIndex = 2
        '
        'Panel8
        '
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Location = New System.Drawing.Point(219, 168)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1022, 426)
        Me.Panel8.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(92, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 18)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Mon Compte"
        '
        'PictureBox5
        '
        Me.PictureBox5.BackgroundImage = CType(resources.GetObject("PictureBox5.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox5.Location = New System.Drawing.Point(11, 21)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(74, 67)
        Me.PictureBox5.TabIndex = 2
        Me.PictureBox5.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Controls.Add(Me.PictureBox7)
        Me.Panel6.Location = New System.Drawing.Point(3, 427)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(213, 54)
        Me.Panel6.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(88, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 18)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Marchandises"
        '
        'PictureBox7
        '
        Me.PictureBox7.BackgroundImage = CType(resources.GetObject("PictureBox7.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox7.Location = New System.Drawing.Point(3, 0)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(65, 51)
        Me.PictureBox7.TabIndex = 1
        Me.PictureBox7.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.PictureBox8)
        Me.Panel5.Location = New System.Drawing.Point(3, 265)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(213, 54)
        Me.Panel5.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(88, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 18)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Historiques"
        '
        'PictureBox8
        '
        Me.PictureBox8.BackgroundImage = CType(resources.GetObject("PictureBox8.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox8.Location = New System.Drawing.Point(3, -1)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(65, 51)
        Me.PictureBox8.TabIndex = 1
        Me.PictureBox8.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.PictureBox9)
        Me.Panel4.Location = New System.Drawing.Point(3, 373)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(213, 54)
        Me.Panel4.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(88, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 18)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Véhicules"
        '
        'PictureBox9
        '
        Me.PictureBox9.BackgroundImage = CType(resources.GetObject("PictureBox9.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox9.Location = New System.Drawing.Point(3, 0)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(65, 51)
        Me.PictureBox9.TabIndex = 1
        Me.PictureBox9.TabStop = False
        '
        'Panel9
        '
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Controls.Add(Me.Label2)
        Me.Panel9.Controls.Add(Me.PictureBox10)
        Me.Panel9.Location = New System.Drawing.Point(3, 319)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(213, 54)
        Me.Panel9.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(88, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Trajet"
        '
        'PictureBox10
        '
        Me.PictureBox10.BackgroundImage = CType(resources.GetObject("PictureBox10.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox10.Location = New System.Drawing.Point(3, 0)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(65, 51)
        Me.PictureBox10.TabIndex = 1
        Me.PictureBox10.TabStop = False
        '
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.Label7)
        Me.Panel10.Controls.Add(Me.PictureBox11)
        Me.Panel10.Location = New System.Drawing.Point(3, 211)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(213, 54)
        Me.Panel10.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(88, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 18)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Conducteur"
        '
        'PictureBox11
        '
        Me.PictureBox11.BackgroundImage = CType(resources.GetObject("PictureBox11.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox11.Location = New System.Drawing.Point(3, 0)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(65, 51)
        Me.PictureBox11.TabIndex = 1
        Me.PictureBox11.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(688, 339)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 15)
        Me.Label8.TabIndex = 85
        Me.Label8.Text = "(En Kg)"
        '
        'Search
        '
        Me.Search.BackgroundImage = CType(resources.GetObject("Search.BackgroundImage"), System.Drawing.Image)
        Me.Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Search.Location = New System.Drawing.Point(1130, 270)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(33, 35)
        Me.Search.TabIndex = 86
        Me.Search.TabStop = False
        '
        'Gestion_Véhicules
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1252, 710)
        Me.Controls.Add(Me.Search)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TypVeh_Fil)
        Me.Controls.Add(Me.Date_fil)
        Me.Controls.Add(Me.CapVeh_Fil)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ImmVeh_Fil)
        Me.Controls.Add(Me.Eta_Veh)
        Me.Controls.Add(Me.typ_Veh)
        Me.Controls.Add(Me.Cap)
        Me.Controls.Add(Me.imm)
        Me.Controls.Add(Me.Veh)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.DataGridVeh)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Gestion_Véhicules"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion_Véhicules"
        Me.Panel2.ResumeLayout(False)
        CType(Me.RepVeh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeleteVeh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpdateVeh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddTra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddVeh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridVeh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Admin.ResumeLayout(False)
        Me.Admin.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents RepVeh As PictureBox
    Friend WithEvents DeleteVeh As PictureBox
    Friend WithEvents UpdateVeh As PictureBox
    Friend WithEvents AddTra As PictureBox
    Friend WithEvents AddVeh As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TypVeh_Fil As ComboBox
    Friend WithEvents Date_fil As DateTimePicker
    Friend WithEvents CapVeh_Fil As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Dis_rd_Fil As RadioButton
    Friend WithEvents Ind_rd_Fil As RadioButton
    Friend WithEvents ImmVeh_Fil As TextBox
    Friend WithEvents Eta_Veh As Label
    Friend WithEvents typ_Veh As Label
    Friend WithEvents Cap As Label
    Friend WithEvents imm As Label
    Friend WithEvents Veh As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents DataGridVeh As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox10 As PictureBox
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents PictureBox11 As PictureBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Search As PictureBox
    Friend WithEvents Admin As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents PictureBox2 As PictureBox
End Class
