<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class signup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.errorsignuphandler = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.confirmPass = New System.Windows.Forms.TextBox()
        Me.addPass = New System.Windows.Forms.TextBox()
        Me.addEmail = New System.Windows.Forms.TextBox()
        Me.addUsername = New System.Windows.Forms.TextBox()
        Me.dosignUp = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.gotoLogin = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.exitLogin = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.Panel1.Controls.Add(Me.errorsignuphandler)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(408, 630)
        Me.Panel1.TabIndex = 10
        '
        'errorsignuphandler
        '
        Me.errorsignuphandler.AutoSize = True
        Me.errorsignuphandler.BackColor = System.Drawing.Color.Transparent
        Me.errorsignuphandler.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.errorsignuphandler.ForeColor = System.Drawing.Color.Red
        Me.errorsignuphandler.Location = New System.Drawing.Point(49, 470)
        Me.errorsignuphandler.Name = "errorsignuphandler"
        Me.errorsignuphandler.Size = New System.Drawing.Size(0, 19)
        Me.errorsignuphandler.TabIndex = 15
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.confirmPass)
        Me.Panel2.Controls.Add(Me.addPass)
        Me.Panel2.Controls.Add(Me.addEmail)
        Me.Panel2.Controls.Add(Me.addUsername)
        Me.Panel2.Controls.Add(Me.dosignUp)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(53, 104)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(293, 351)
        Me.Panel2.TabIndex = 15
        '
        'confirmPass
        '
        Me.confirmPass.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.confirmPass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.confirmPass.Font = New System.Drawing.Font("Poppins", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.confirmPass.ForeColor = System.Drawing.Color.White
        Me.confirmPass.Location = New System.Drawing.Point(21, 250)
        Me.confirmPass.Name = "confirmPass"
        Me.confirmPass.Size = New System.Drawing.Size(253, 32)
        Me.confirmPass.TabIndex = 22
        '
        'addPass
        '
        Me.addPass.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.addPass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.addPass.Font = New System.Drawing.Font("Poppins", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addPass.ForeColor = System.Drawing.Color.White
        Me.addPass.Location = New System.Drawing.Point(21, 203)
        Me.addPass.Name = "addPass"
        Me.addPass.Size = New System.Drawing.Size(253, 32)
        Me.addPass.TabIndex = 21
        '
        'addEmail
        '
        Me.addEmail.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.addEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.addEmail.Font = New System.Drawing.Font("Poppins", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addEmail.ForeColor = System.Drawing.Color.White
        Me.addEmail.Location = New System.Drawing.Point(21, 156)
        Me.addEmail.Name = "addEmail"
        Me.addEmail.Size = New System.Drawing.Size(253, 32)
        Me.addEmail.TabIndex = 20
        '
        'addUsername
        '
        Me.addUsername.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.addUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.addUsername.Font = New System.Drawing.Font("Poppins", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addUsername.ForeColor = System.Drawing.Color.White
        Me.addUsername.Location = New System.Drawing.Point(21, 109)
        Me.addUsername.Name = "addUsername"
        Me.addUsername.Size = New System.Drawing.Size(253, 32)
        Me.addUsername.TabIndex = 16
        '
        'dosignUp
        '
        Me.dosignUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.dosignUp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dosignUp.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dosignUp.FlatAppearance.BorderSize = 0
        Me.dosignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.dosignUp.ForeColor = System.Drawing.Color.White
        Me.dosignUp.Location = New System.Drawing.Point(0, 304)
        Me.dosignUp.Name = "dosignUp"
        Me.dosignUp.Size = New System.Drawing.Size(293, 47)
        Me.dosignUp.TabIndex = 15
        Me.dosignUp.Text = "signup"
        Me.dosignUp.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(17, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 22)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "enter your details"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Poppins", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(13, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 48)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Signup"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.gotoLogin)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Location = New System.Drawing.Point(53, 510)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(293, 47)
        Me.Panel4.TabIndex = 14
        '
        'gotoLogin
        '
        Me.gotoLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.gotoLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.gotoLogin.Dock = System.Windows.Forms.DockStyle.Right
        Me.gotoLogin.FlatAppearance.BorderSize = 0
        Me.gotoLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gotoLogin.ForeColor = System.Drawing.Color.White
        Me.gotoLogin.Location = New System.Drawing.Point(188, 0)
        Me.gotoLogin.Name = "gotoLogin"
        Me.gotoLogin.Size = New System.Drawing.Size(105, 47)
        Me.gotoLogin.TabIndex = 14
        Me.gotoLogin.Text = "login"
        Me.gotoLogin.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(8, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(174, 22)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Already have and account?"
        '
        'exitLogin
        '
        Me.exitLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.exitLogin.FlatAppearance.BorderSize = 0
        Me.exitLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.exitLogin.Image = Global.nobleAuction.My.Resources.Resources.cross
        Me.exitLogin.Location = New System.Drawing.Point(972, -2)
        Me.exitLogin.Name = "exitLogin"
        Me.exitLogin.Size = New System.Drawing.Size(52, 31)
        Me.exitLogin.TabIndex = 9
        Me.exitLogin.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.nobleAuction.My.Resources.Resources.signup_illu1
        Me.PictureBox1.Location = New System.Drawing.Point(452, 169)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(534, 421)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Poppins", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(450, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(488, 113)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Signup Portal"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.nobleAuction.My.Resources.Resources.login_vector1
        Me.PictureBox2.Location = New System.Drawing.Point(844, 116)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(142, 119)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 13
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.nobleAuction.My.Resources.Resources.login_vector1
        Me.PictureBox3.Location = New System.Drawing.Point(414, 200)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(142, 119)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 14
        Me.PictureBox3.TabStop = False
        '
        'signup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1024, 630)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.exitLogin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "signup"
        Me.Text = "signup"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents exitLogin As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents addUsername As TextBox
    Friend WithEvents dosignUp As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents gotoLogin As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents addEmail As TextBox
    Friend WithEvents confirmPass As TextBox
    Friend WithEvents addPass As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents errorsignuphandler As Label
End Class
