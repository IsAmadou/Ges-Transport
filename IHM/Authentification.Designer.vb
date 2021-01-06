<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Authentification
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Authentification))
        Me.LogUse_lbl = New System.Windows.Forms.TextBox()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.titre = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.StaUser_lbl = New System.Windows.Forms.ComboBox()
        Me.PasUse_lbl = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Datacon = New System.Windows.Forms.DataGridView()
        CType(Me.Datacon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LogUse_lbl
        '
        Me.LogUse_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.LogUse_lbl.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LogUse_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogUse_lbl.Location = New System.Drawing.Point(162, 118)
        Me.LogUse_lbl.Name = "LogUse_lbl"
        Me.LogUse_lbl.Size = New System.Drawing.Size(155, 19)
        Me.LogUse_lbl.TabIndex = 40
        '
        'button2
        '
        Me.button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.button2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button2.Location = New System.Drawing.Point(365, 309)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(75, 23)
        Me.button2.TabIndex = 39
        Me.button2.Text = "Sortir"
        Me.button2.UseVisualStyleBackColor = False
        '
        'button1
        '
        Me.button1.BackColor = System.Drawing.Color.Honeydew
        Me.button1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button1.Location = New System.Drawing.Point(220, 309)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(126, 23)
        Me.button1.TabIndex = 38
        Me.button1.Text = "Se Connecter"
        Me.button1.UseVisualStyleBackColor = False
        '
        'titre
        '
        Me.titre.AutoSize = True
        Me.titre.BackColor = System.Drawing.Color.Transparent
        Me.titre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.titre.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titre.ForeColor = System.Drawing.Color.PapayaWhip
        Me.titre.Location = New System.Drawing.Point(156, 21)
        Me.titre.Name = "titre"
        Me.titre.Size = New System.Drawing.Size(220, 26)
        Me.titre.TabIndex = 37
        Me.titre.Text = "AUTHENTIFICATION"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.BackColor = System.Drawing.Color.Transparent
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.SystemColors.Info
        Me.label3.Location = New System.Drawing.Point(153, 218)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(41, 16)
        Me.label3.TabIndex = 36
        Me.label3.Text = "Statut"
        '
        'StaUser_lbl
        '
        Me.StaUser_lbl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.StaUser_lbl.FormattingEnabled = True
        Me.StaUser_lbl.Items.AddRange(New Object() {"Utilisateur", "Administrateur"})
        Me.StaUser_lbl.Location = New System.Drawing.Point(211, 215)
        Me.StaUser_lbl.Name = "StaUser_lbl"
        Me.StaUser_lbl.Size = New System.Drawing.Size(121, 21)
        Me.StaUser_lbl.TabIndex = 35
        '
        'PasUse_lbl
        '
        Me.PasUse_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.PasUse_lbl.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PasUse_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasUse_lbl.Location = New System.Drawing.Point(166, 160)
        Me.PasUse_lbl.Name = "PasUse_lbl"
        Me.PasUse_lbl.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasUse_lbl.Size = New System.Drawing.Size(155, 19)
        Me.PasUse_lbl.TabIndex = 34
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.Color.Transparent
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.SystemColors.Info
        Me.label2.Location = New System.Drawing.Point(84, 163)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(68, 16)
        Me.label2.TabIndex = 33
        Me.label2.Text = "Password"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.BackColor = System.Drawing.Color.Transparent
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.SystemColors.Info
        Me.label1.Location = New System.Drawing.Point(102, 121)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(41, 16)
        Me.label1.TabIndex = 32
        Me.label1.Text = "Login"
        '
        'Datacon
        '
        Me.Datacon.BackgroundColor = System.Drawing.SystemColors.Control
        Me.Datacon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Datacon.GridColor = System.Drawing.Color.DarkGray
        Me.Datacon.Location = New System.Drawing.Point(12, 4)
        Me.Datacon.Name = "Datacon"
        Me.Datacon.Size = New System.Drawing.Size(240, 150)
        Me.Datacon.TabIndex = 41
        Me.Datacon.Visible = False
        '
        'Authentification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(444, 339)
        Me.Controls.Add(Me.Datacon)
        Me.Controls.Add(Me.LogUse_lbl)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.titre)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.StaUser_lbl)
        Me.Controls.Add(Me.PasUse_lbl)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Authentification"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Authentification"
        CType(Me.Datacon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LogUse_lbl As TextBox
    Private WithEvents button2 As Button
    Private WithEvents button1 As Button
    Private WithEvents titre As Label
    Private WithEvents label3 As Label
    Private WithEvents StaUser_lbl As ComboBox
    Private WithEvents PasUse_lbl As TextBox
    Private WithEvents label2 As Label
    Private WithEvents label1 As Label
    Friend WithEvents Datacon As DataGridView
End Class
