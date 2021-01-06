<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class créer_un_Utilisateur
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(créer_un_Utilisateur))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TitrPanelAddUser = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NomUse_lbl = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TelUse_lbl = New System.Windows.Forms.TextBox()
        Me.EmaUse_lbl = New System.Windows.Forms.TextBox()
        Me.PreUse_lbl = New System.Windows.Forms.TextBox()
        Me.Fem_rd_lbl = New System.Windows.Forms.RadioButton()
        Me.Mas_rd_lbl = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.AddUse_lbl = New System.Windows.Forms.TextBox()
        Me.LogUse_lbl = New System.Windows.Forms.TextBox()
        Me.MotUse_Lbl = New System.Windows.Forms.TextBox()
        Me.MotConUse_lbl = New System.Windows.Forms.TextBox()
        Me.AnnUse = New System.Windows.Forms.Button()
        Me.EnrUse = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.StaUse_lbl = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(141, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(190, 186)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'TitrPanelAddUser
        '
        Me.TitrPanelAddUser.Font = New System.Drawing.Font("Modern No. 20", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitrPanelAddUser.Location = New System.Drawing.Point(347, 97)
        Me.TitrPanelAddUser.Name = "TitrPanelAddUser"
        Me.TitrPanelAddUser.Size = New System.Drawing.Size(248, 30)
        Me.TitrPanelAddUser.TabIndex = 1
        Me.TitrPanelAddUser.Text = "Créer un Utilisateur"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 221)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nom"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(348, 224)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 19)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Prénom"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(135, 384)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 19)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Téléphone"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 436)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 19)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Adresse"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(149, 491)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 19)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Statut"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 335)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 19)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Email"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 599)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 19)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Mot de passe"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(150, 541)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 19)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Login"
        '
        'NomUse_lbl
        '
        Me.NomUse_lbl.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NomUse_lbl.Location = New System.Drawing.Point(82, 221)
        Me.NomUse_lbl.Name = "NomUse_lbl"
        Me.NomUse_lbl.Size = New System.Drawing.Size(249, 26)
        Me.NomUse_lbl.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(155, 281)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 19)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Sexe"
        '
        'TelUse_lbl
        '
        Me.TelUse_lbl.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TelUse_lbl.Location = New System.Drawing.Point(214, 381)
        Me.TelUse_lbl.Name = "TelUse_lbl"
        Me.TelUse_lbl.Size = New System.Drawing.Size(300, 26)
        Me.TelUse_lbl.TabIndex = 12
        Me.TelUse_lbl.Text = "+"
        '
        'EmaUse_lbl
        '
        Me.EmaUse_lbl.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmaUse_lbl.Location = New System.Drawing.Point(82, 330)
        Me.EmaUse_lbl.Name = "EmaUse_lbl"
        Me.EmaUse_lbl.Size = New System.Drawing.Size(585, 26)
        Me.EmaUse_lbl.TabIndex = 13
        '
        'PreUse_lbl
        '
        Me.PreUse_lbl.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PreUse_lbl.Location = New System.Drawing.Point(418, 221)
        Me.PreUse_lbl.Name = "PreUse_lbl"
        Me.PreUse_lbl.Size = New System.Drawing.Size(249, 26)
        Me.PreUse_lbl.TabIndex = 14
        '
        'Fem_rd_lbl
        '
        Me.Fem_rd_lbl.AutoSize = True
        Me.Fem_rd_lbl.Font = New System.Drawing.Font("Poor Richard", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fem_rd_lbl.Location = New System.Drawing.Point(190, 1)
        Me.Fem_rd_lbl.Name = "Fem_rd_lbl"
        Me.Fem_rd_lbl.Size = New System.Drawing.Size(72, 22)
        Me.Fem_rd_lbl.TabIndex = 15
        Me.Fem_rd_lbl.TabStop = True
        Me.Fem_rd_lbl.Text = "Féminin"
        Me.Fem_rd_lbl.UseVisualStyleBackColor = True
        '
        'Mas_rd_lbl
        '
        Me.Mas_rd_lbl.AutoSize = True
        Me.Mas_rd_lbl.Font = New System.Drawing.Font("Poor Richard", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mas_rd_lbl.Location = New System.Drawing.Point(15, 1)
        Me.Mas_rd_lbl.Name = "Mas_rd_lbl"
        Me.Mas_rd_lbl.Size = New System.Drawing.Size(77, 22)
        Me.Mas_rd_lbl.TabIndex = 16
        Me.Mas_rd_lbl.TabStop = True
        Me.Mas_rd_lbl.Text = "Masculin"
        Me.Mas_rd_lbl.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Mas_rd_lbl)
        Me.Panel1.Controls.Add(Me.Fem_rd_lbl)
        Me.Panel1.Location = New System.Drawing.Point(214, 273)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(300, 29)
        Me.Panel1.TabIndex = 17
        '
        'AddUse_lbl
        '
        Me.AddUse_lbl.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddUse_lbl.Location = New System.Drawing.Point(82, 432)
        Me.AddUse_lbl.Name = "AddUse_lbl"
        Me.AddUse_lbl.Size = New System.Drawing.Size(585, 26)
        Me.AddUse_lbl.TabIndex = 18
        '
        'LogUse_lbl
        '
        Me.LogUse_lbl.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogUse_lbl.Location = New System.Drawing.Point(214, 538)
        Me.LogUse_lbl.Name = "LogUse_lbl"
        Me.LogUse_lbl.Size = New System.Drawing.Size(300, 26)
        Me.LogUse_lbl.TabIndex = 21
        '
        'MotUse_Lbl
        '
        Me.MotUse_Lbl.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MotUse_Lbl.Location = New System.Drawing.Point(128, 596)
        Me.MotUse_Lbl.Name = "MotUse_Lbl"
        Me.MotUse_Lbl.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.MotUse_Lbl.Size = New System.Drawing.Size(249, 26)
        Me.MotUse_Lbl.TabIndex = 22
        Me.MotUse_Lbl.UseSystemPasswordChar = True
        '
        'MotConUse_lbl
        '
        Me.MotConUse_lbl.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MotConUse_lbl.Location = New System.Drawing.Point(404, 596)
        Me.MotConUse_lbl.Name = "MotConUse_lbl"
        Me.MotConUse_lbl.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.MotConUse_lbl.Size = New System.Drawing.Size(249, 26)
        Me.MotConUse_lbl.TabIndex = 23
        Me.MotConUse_lbl.UseSystemPasswordChar = True
        '
        'AnnUse
        '
        Me.AnnUse.Font = New System.Drawing.Font("Segoe Marker", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnnUse.Location = New System.Drawing.Point(269, 679)
        Me.AnnUse.Name = "AnnUse"
        Me.AnnUse.Size = New System.Drawing.Size(124, 28)
        Me.AnnUse.TabIndex = 24
        Me.AnnUse.Text = "Annuler"
        Me.AnnUse.UseVisualStyleBackColor = True
        '
        'EnrUse
        '
        Me.EnrUse.Font = New System.Drawing.Font("Segoe Marker", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnrUse.Location = New System.Drawing.Point(475, 679)
        Me.EnrUse.Name = "EnrUse"
        Me.EnrUse.Size = New System.Drawing.Size(124, 28)
        Me.EnrUse.TabIndex = 25
        Me.EnrUse.Text = "Enregistrer"
        Me.EnrUse.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(533, 389)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 13)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "( Ex: +212 06......"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(182, 625)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(137, 13)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Saisir 8 caractères minimum"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(468, 625)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(131, 13)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "Confirmer le  mot de passe"
        '
        'StaUse_lbl
        '
        Me.StaUse_lbl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.StaUse_lbl.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StaUse_lbl.FormattingEnabled = True
        Me.StaUse_lbl.Items.AddRange(New Object() {"Utilisateur", "Administrateur"})
        Me.StaUse_lbl.Location = New System.Drawing.Point(214, 487)
        Me.StaUse_lbl.Name = "StaUse_lbl"
        Me.StaUse_lbl.Size = New System.Drawing.Size(300, 27)
        Me.StaUse_lbl.TabIndex = 29
        '
        'créer_un_Utilisateur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 714)
        Me.Controls.Add(Me.StaUse_lbl)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.EnrUse)
        Me.Controls.Add(Me.AnnUse)
        Me.Controls.Add(Me.MotConUse_lbl)
        Me.Controls.Add(Me.MotUse_Lbl)
        Me.Controls.Add(Me.LogUse_lbl)
        Me.Controls.Add(Me.AddUse_lbl)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PreUse_lbl)
        Me.Controls.Add(Me.EmaUse_lbl)
        Me.Controls.Add(Me.TelUse_lbl)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.NomUse_lbl)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TitrPanelAddUser)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "créer_un_Utilisateur"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "créer un Utilisateur"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TitrPanelAddUser As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents NomUse_lbl As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TelUse_lbl As TextBox
    Friend WithEvents EmaUse_lbl As TextBox
    Friend WithEvents PreUse_lbl As TextBox
    Friend WithEvents Fem_rd_lbl As RadioButton
    Friend WithEvents Mas_rd_lbl As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents AddUse_lbl As TextBox
    Friend WithEvents LogUse_lbl As TextBox
    Friend WithEvents MotUse_Lbl As TextBox
    Friend WithEvents MotConUse_lbl As TextBox
    Friend WithEvents AnnUse As Button
    Friend WithEvents EnrUse As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents StaUse_lbl As ComboBox
End Class
