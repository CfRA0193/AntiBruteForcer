<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me._masterPasswordTextBox = New System.Windows.Forms.TextBox()
        Me._saltGenerationCheckBox = New System.Windows.Forms.CheckBox()
        Me._deriveKeyButton = New System.Windows.Forms.Button()
        Me._encryptedSaltRichTextBox = New System.Windows.Forms.RichTextBox()
        Me._saltPasswordTextBox = New System.Windows.Forms.TextBox()
        Me._keyRichTextBox = New System.Windows.Forms.RichTextBox()
        Me._saltPasswordTextBoxLabel = New System.Windows.Forms.Label()
        Me._masterPasswordTextBoxLabel = New System.Windows.Forms.Label()
        Me._keyCopyButton = New System.Windows.Forms.Button()
        Me._encryptedSaltCopyButton = New System.Windows.Forms.Button()
        Me._saltDecryptionCheckBox = New System.Windows.Forms.CheckBox()
        Me._128bitKeyCheckBox = New System.Windows.Forms.CheckBox()
        Me._256bitKeyCheckBox = New System.Windows.Forms.CheckBox()
        Me._IntelInsidePictureBox = New System.Windows.Forms.PictureBox()
        Me._helpButton = New System.Windows.Forms.Button()
        Me._fastCheckBox = New System.Windows.Forms.CheckBox()
        Me._saltPasswordRndButton = New System.Windows.Forms.Button()
        Me._masterPasswordRndButton = New System.Windows.Forms.Button()
        CType(Me._IntelInsidePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_masterPasswordTextBox
        '
        Me._masterPasswordTextBox.BackColor = System.Drawing.Color.LightSkyBlue
        Me._masterPasswordTextBox.Location = New System.Drawing.Point(11, 335)
        Me._masterPasswordTextBox.Name = "_masterPasswordTextBox"
        Me._masterPasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9632)
        Me._masterPasswordTextBox.Size = New System.Drawing.Size(457, 20)
        Me._masterPasswordTextBox.TabIndex = 5
        '
        '_saltGenerationCheckBox
        '
        Me._saltGenerationCheckBox.AutoSize = True
        Me._saltGenerationCheckBox.BackColor = System.Drawing.Color.Black
        Me._saltGenerationCheckBox.Checked = True
        Me._saltGenerationCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me._saltGenerationCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._saltGenerationCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me._saltGenerationCheckBox.ForeColor = System.Drawing.Color.Cornsilk
        Me._saltGenerationCheckBox.Location = New System.Drawing.Point(11, 478)
        Me._saltGenerationCheckBox.Name = "_saltGenerationCheckBox"
        Me._saltGenerationCheckBox.Size = New System.Drawing.Size(124, 17)
        Me._saltGenerationCheckBox.TabIndex = 9
        Me._saltGenerationCheckBox.Text = "SALT GENERATION"
        Me._saltGenerationCheckBox.UseVisualStyleBackColor = False
        '
        '_deriveKeyButton
        '
        Me._deriveKeyButton.BackColor = System.Drawing.Color.Black
        Me._deriveKeyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._deriveKeyButton.ForeColor = System.Drawing.Color.Cornsilk
        Me._deriveKeyButton.Location = New System.Drawing.Point(305, 388)
        Me._deriveKeyButton.Name = "_deriveKeyButton"
        Me._deriveKeyButton.Size = New System.Drawing.Size(163, 40)
        Me._deriveKeyButton.TabIndex = 12
        Me._deriveKeyButton.Text = "START TO DERIVE KEY"
        Me._deriveKeyButton.UseVisualStyleBackColor = False
        '
        '_encryptedSaltRichTextBox
        '
        Me._encryptedSaltRichTextBox.BackColor = System.Drawing.Color.LightSkyBlue
        Me._encryptedSaltRichTextBox.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me._encryptedSaltRichTextBox.ForeColor = System.Drawing.Color.Black
        Me._encryptedSaltRichTextBox.Location = New System.Drawing.Point(11, 11)
        Me._encryptedSaltRichTextBox.Name = "_encryptedSaltRichTextBox"
        Me._encryptedSaltRichTextBox.Size = New System.Drawing.Size(457, 127)
        Me._encryptedSaltRichTextBox.TabIndex = 0
        Me._encryptedSaltRichTextBox.TabStop = False
        Me._encryptedSaltRichTextBox.Text = ""
        '
        '_saltPasswordTextBox
        '
        Me._saltPasswordTextBox.BackColor = System.Drawing.Color.LightSkyBlue
        Me._saltPasswordTextBox.ForeColor = System.Drawing.Color.Black
        Me._saltPasswordTextBox.Location = New System.Drawing.Point(11, 144)
        Me._saltPasswordTextBox.Name = "_saltPasswordTextBox"
        Me._saltPasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9632)
        Me._saltPasswordTextBox.Size = New System.Drawing.Size(457, 20)
        Me._saltPasswordTextBox.TabIndex = 1
        '
        '_keyRichTextBox
        '
        Me._keyRichTextBox.BackColor = System.Drawing.Color.LightSkyBlue
        Me._keyRichTextBox.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me._keyRichTextBox.ForeColor = System.Drawing.Color.Black
        Me._keyRichTextBox.Location = New System.Drawing.Point(11, 217)
        Me._keyRichTextBox.Name = "_keyRichTextBox"
        Me._keyRichTextBox.ReadOnly = True
        Me._keyRichTextBox.Size = New System.Drawing.Size(457, 112)
        Me._keyRichTextBox.TabIndex = 4
        Me._keyRichTextBox.TabStop = False
        Me._keyRichTextBox.Text = ""
        '
        '_saltPasswordTextBoxLabel
        '
        Me._saltPasswordTextBoxLabel.AutoSize = True
        Me._saltPasswordTextBoxLabel.BackColor = System.Drawing.Color.Transparent
        Me._saltPasswordTextBoxLabel.Font = New System.Drawing.Font("Segoe Print", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._saltPasswordTextBoxLabel.ForeColor = System.Drawing.Color.Cornsilk
        Me._saltPasswordTextBoxLabel.Location = New System.Drawing.Point(38, 169)
        Me._saltPasswordTextBoxLabel.Name = "_saltPasswordTextBoxLabel"
        Me._saltPasswordTextBoxLabel.Size = New System.Drawing.Size(127, 23)
        Me._saltPasswordTextBoxLabel.TabIndex = 0
        Me._saltPasswordTextBoxLabel.Text = "SALT PASSWORD"
        '
        '_masterPasswordTextBoxLabel
        '
        Me._masterPasswordTextBoxLabel.AutoSize = True
        Me._masterPasswordTextBoxLabel.BackColor = System.Drawing.Color.Transparent
        Me._masterPasswordTextBoxLabel.Font = New System.Drawing.Font("Segoe Print", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me._masterPasswordTextBoxLabel.ForeColor = System.Drawing.Color.Cornsilk
        Me._masterPasswordTextBoxLabel.Location = New System.Drawing.Point(38, 360)
        Me._masterPasswordTextBoxLabel.Name = "_masterPasswordTextBoxLabel"
        Me._masterPasswordTextBoxLabel.Size = New System.Drawing.Size(149, 23)
        Me._masterPasswordTextBoxLabel.TabIndex = 0
        Me._masterPasswordTextBoxLabel.Text = "MASTER PASSWORD"
        '
        '_keyCopyButton
        '
        Me._keyCopyButton.BackColor = System.Drawing.Color.Black
        Me._keyCopyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._keyCopyButton.ForeColor = System.Drawing.Color.Cornsilk
        Me._keyCopyButton.Location = New System.Drawing.Point(305, 466)
        Me._keyCopyButton.Name = "_keyCopyButton"
        Me._keyCopyButton.Size = New System.Drawing.Size(163, 26)
        Me._keyCopyButton.TabIndex = 14
        Me._keyCopyButton.Text = "KEY COPY / CLEAR"
        Me._keyCopyButton.UseVisualStyleBackColor = False
        '
        '_encryptedSaltCopyButton
        '
        Me._encryptedSaltCopyButton.BackColor = System.Drawing.Color.Black
        Me._encryptedSaltCopyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._encryptedSaltCopyButton.ForeColor = System.Drawing.Color.Cornsilk
        Me._encryptedSaltCopyButton.Location = New System.Drawing.Point(305, 434)
        Me._encryptedSaltCopyButton.Name = "_encryptedSaltCopyButton"
        Me._encryptedSaltCopyButton.Size = New System.Drawing.Size(163, 26)
        Me._encryptedSaltCopyButton.TabIndex = 13
        Me._encryptedSaltCopyButton.Text = "SALT COPY / CLEAR"
        Me._encryptedSaltCopyButton.UseVisualStyleBackColor = False
        '
        '_saltDecryptionCheckBox
        '
        Me._saltDecryptionCheckBox.AutoSize = True
        Me._saltDecryptionCheckBox.BackColor = System.Drawing.Color.Black
        Me._saltDecryptionCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._saltDecryptionCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me._saltDecryptionCheckBox.ForeColor = System.Drawing.Color.Cornsilk
        Me._saltDecryptionCheckBox.Location = New System.Drawing.Point(375, 173)
        Me._saltDecryptionCheckBox.Name = "_saltDecryptionCheckBox"
        Me._saltDecryptionCheckBox.Size = New System.Drawing.Size(93, 17)
        Me._saltDecryptionCheckBox.TabIndex = 3
        Me._saltDecryptionCheckBox.Text = "DECRYPTION"
        Me._saltDecryptionCheckBox.UseVisualStyleBackColor = False
        '
        '_128bitKeyCheckBox
        '
        Me._128bitKeyCheckBox.AutoSize = True
        Me._128bitKeyCheckBox.BackColor = System.Drawing.Color.Black
        Me._128bitKeyCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._128bitKeyCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me._128bitKeyCheckBox.ForeColor = System.Drawing.Color.Cornsilk
        Me._128bitKeyCheckBox.Location = New System.Drawing.Point(11, 432)
        Me._128bitKeyCheckBox.Name = "_128bitKeyCheckBox"
        Me._128bitKeyCheckBox.Size = New System.Drawing.Size(85, 17)
        Me._128bitKeyCheckBox.TabIndex = 7
        Me._128bitKeyCheckBox.Text = "128 BIT KEY"
        Me._128bitKeyCheckBox.UseVisualStyleBackColor = False
        '
        '_256bitKeyCheckBox
        '
        Me._256bitKeyCheckBox.AutoSize = True
        Me._256bitKeyCheckBox.BackColor = System.Drawing.Color.Black
        Me._256bitKeyCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._256bitKeyCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me._256bitKeyCheckBox.ForeColor = System.Drawing.Color.Cornsilk
        Me._256bitKeyCheckBox.Location = New System.Drawing.Point(11, 455)
        Me._256bitKeyCheckBox.Name = "_256bitKeyCheckBox"
        Me._256bitKeyCheckBox.Size = New System.Drawing.Size(85, 17)
        Me._256bitKeyCheckBox.TabIndex = 8
        Me._256bitKeyCheckBox.Text = "256 BIT KEY"
        Me._256bitKeyCheckBox.UseVisualStyleBackColor = False
        '
        '_IntelInsidePictureBox
        '
        Me._IntelInsidePictureBox.BackColor = System.Drawing.Color.Transparent
        Me._IntelInsidePictureBox.BackgroundImage = Global.AntiBruteForcer.My.Resources.Resources.IntelInside
        Me._IntelInsidePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me._IntelInsidePictureBox.Location = New System.Drawing.Point(214, 385)
        Me._IntelInsidePictureBox.Name = "_IntelInsidePictureBox"
        Me._IntelInsidePictureBox.Size = New System.Drawing.Size(85, 110)
        Me._IntelInsidePictureBox.TabIndex = 11
        Me._IntelInsidePictureBox.TabStop = False
        '
        '_helpButton
        '
        Me._helpButton.BackColor = System.Drawing.Color.Black
        Me._helpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._helpButton.ForeColor = System.Drawing.Color.Cornsilk
        Me._helpButton.Location = New System.Drawing.Point(141, 466)
        Me._helpButton.Name = "_helpButton"
        Me._helpButton.Size = New System.Drawing.Size(66, 26)
        Me._helpButton.TabIndex = 10
        Me._helpButton.Text = "HELP!"
        Me._helpButton.UseVisualStyleBackColor = False
        '
        '_fastCheckBox
        '
        Me._fastCheckBox.AutoSize = True
        Me._fastCheckBox.BackColor = System.Drawing.Color.Black
        Me._fastCheckBox.Checked = True
        Me._fastCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me._fastCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._fastCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me._fastCheckBox.ForeColor = System.Drawing.Color.Cornsilk
        Me._fastCheckBox.Location = New System.Drawing.Point(305, 365)
        Me._fastCheckBox.Name = "_fastCheckBox"
        Me._fastCheckBox.Size = New System.Drawing.Size(50, 17)
        Me._fastCheckBox.TabIndex = 11
        Me._fastCheckBox.Text = "FAST"
        Me._fastCheckBox.UseVisualStyleBackColor = False
        '
        '_saltPasswordRndButton
        '
        Me._saltPasswordRndButton.BackColor = System.Drawing.Color.Transparent
        Me._saltPasswordRndButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._saltPasswordRndButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me._saltPasswordRndButton.ForeColor = System.Drawing.Color.Cornsilk
        Me._saltPasswordRndButton.Location = New System.Drawing.Point(12, 170)
        Me._saltPasswordRndButton.Name = "_saltPasswordRndButton"
        Me._saltPasswordRndButton.Size = New System.Drawing.Size(22, 22)
        Me._saltPasswordRndButton.TabIndex = 2
        Me._saltPasswordRndButton.Text = "*"
        Me._saltPasswordRndButton.UseVisualStyleBackColor = False
        '
        '_masterPasswordRndButton
        '
        Me._masterPasswordRndButton.BackColor = System.Drawing.Color.Transparent
        Me._masterPasswordRndButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._masterPasswordRndButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me._masterPasswordRndButton.ForeColor = System.Drawing.Color.Cornsilk
        Me._masterPasswordRndButton.Location = New System.Drawing.Point(12, 361)
        Me._masterPasswordRndButton.Name = "_masterPasswordRndButton"
        Me._masterPasswordRndButton.Size = New System.Drawing.Size(22, 22)
        Me._masterPasswordRndButton.TabIndex = 6
        Me._masterPasswordRndButton.Text = "*"
        Me._masterPasswordRndButton.UseVisualStyleBackColor = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.AntiBruteForcer.My.Resources.Resources.Background
        Me.ClientSize = New System.Drawing.Size(479, 504)
        Me.Controls.Add(Me._masterPasswordRndButton)
        Me.Controls.Add(Me._saltPasswordRndButton)
        Me.Controls.Add(Me._fastCheckBox)
        Me.Controls.Add(Me._helpButton)
        Me.Controls.Add(Me._IntelInsidePictureBox)
        Me.Controls.Add(Me._256bitKeyCheckBox)
        Me.Controls.Add(Me._128bitKeyCheckBox)
        Me.Controls.Add(Me._saltDecryptionCheckBox)
        Me.Controls.Add(Me._encryptedSaltCopyButton)
        Me.Controls.Add(Me._keyCopyButton)
        Me.Controls.Add(Me._masterPasswordTextBoxLabel)
        Me.Controls.Add(Me._saltPasswordTextBoxLabel)
        Me.Controls.Add(Me._keyRichTextBox)
        Me.Controls.Add(Me._saltPasswordTextBox)
        Me.Controls.Add(Me._encryptedSaltRichTextBox)
        Me.Controls.Add(Me._deriveKeyButton)
        Me.Controls.Add(Me._saltGenerationCheckBox)
        Me.Controls.Add(Me._masterPasswordTextBox)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AntiBruteForcer"
        CType(Me._IntelInsidePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents _masterPasswordTextBox As TextBox
    Friend WithEvents _saltGenerationCheckBox As CheckBox
    Friend WithEvents _deriveKeyButton As Button
    Friend WithEvents _encryptedSaltRichTextBox As RichTextBox
    Friend WithEvents _saltPasswordTextBox As TextBox
    Friend WithEvents _keyRichTextBox As RichTextBox
    Friend WithEvents _saltPasswordTextBoxLabel As Label
    Friend WithEvents _masterPasswordTextBoxLabel As Label
    Friend WithEvents _keyCopyButton As Button
    Friend WithEvents _encryptedSaltCopyButton As Button
    Friend WithEvents _saltDecryptionCheckBox As CheckBox
    Friend WithEvents _128bitKeyCheckBox As CheckBox
    Friend WithEvents _256bitKeyCheckBox As CheckBox
    Friend WithEvents _IntelInsidePictureBox As PictureBox
    Friend WithEvents _helpButton As Button
    Friend WithEvents _fastCheckBox As CheckBox
    Friend WithEvents _saltPasswordRndButton As Button
    Friend WithEvents _masterPasswordRndButton As Button
End Class
