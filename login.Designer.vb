<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class login
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
        Me.loginPanel = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.forgetPortal = New System.Windows.Forms.LinkLabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.passwordBox = New System.Windows.Forms.TextBox()
        Me.usernameBox = New System.Windows.Forms.TextBox()
        Me.loginPortal = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.signupPortal = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.exitLogin = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pass_toggler = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.loginPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'loginPanel
        '
        Me.loginPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.loginPanel.Controls.Add(Me.Panel2)
        Me.loginPanel.Controls.Add(Me.Panel1)
        Me.loginPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.loginPanel.Location = New System.Drawing.Point(0, 0)
        Me.loginPanel.Name = "loginPanel"
        Me.loginPanel.Size = New System.Drawing.Size(421, 630)
        Me.loginPanel.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.forgetPortal)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.usernameBox)
        Me.Panel2.Controls.Add(Me.loginPortal)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(61, 143)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(293, 351)
        Me.Panel2.TabIndex = 13
        '
        'forgetPortal
        '
        Me.forgetPortal.AutoSize = True
        Me.forgetPortal.LinkColor = System.Drawing.Color.Gray
        Me.forgetPortal.Location = New System.Drawing.Point(17, 245)
        Me.forgetPortal.Name = "forgetPortal"
        Me.forgetPortal.Size = New System.Drawing.Size(104, 19)
        Me.forgetPortal.TabIndex = 19
        Me.forgetPortal.TabStop = True
        Me.forgetPortal.Text = "forget password?"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.pass_toggler)
        Me.Panel3.Controls.Add(Me.passwordBox)
        Me.Panel3.Location = New System.Drawing.Point(21, 186)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(253, 32)
        Me.Panel3.TabIndex = 18
        '
        'passwordBox
        '
        Me.passwordBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.passwordBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.passwordBox.Font = New System.Drawing.Font("Poppins", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordBox.ForeColor = System.Drawing.Color.White
        Me.passwordBox.Location = New System.Drawing.Point(0, 0)
        Me.passwordBox.Name = "passwordBox"
        Me.passwordBox.Size = New System.Drawing.Size(182, 32)
        Me.passwordBox.TabIndex = 18
        '
        'usernameBox
        '
        Me.usernameBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.usernameBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.usernameBox.Font = New System.Drawing.Font("Poppins", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usernameBox.ForeColor = System.Drawing.Color.White
        Me.usernameBox.Location = New System.Drawing.Point(21, 126)
        Me.usernameBox.Name = "usernameBox"
        Me.usernameBox.Size = New System.Drawing.Size(253, 32)
        Me.usernameBox.TabIndex = 16
        '
        'loginPortal
        '
        Me.loginPortal.BackColor = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.loginPortal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.loginPortal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.loginPortal.FlatAppearance.BorderSize = 0
        Me.loginPortal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.loginPortal.ForeColor = System.Drawing.Color.White
        Me.loginPortal.Location = New System.Drawing.Point(0, 304)
        Me.loginPortal.Name = "loginPortal"
        Me.loginPortal.Size = New System.Drawing.Size(293, 47)
        Me.loginPortal.TabIndex = 15
        Me.loginPortal.Text = "login"
        Me.loginPortal.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(17, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(165, 22)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "enter your account details"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Poppins", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(13, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 48)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Login"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.signupPortal)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(61, 549)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(293, 47)
        Me.Panel1.TabIndex = 12
        '
        'signupPortal
        '
        Me.signupPortal.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.signupPortal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.signupPortal.Dock = System.Windows.Forms.DockStyle.Right
        Me.signupPortal.FlatAppearance.BorderSize = 0
        Me.signupPortal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.signupPortal.ForeColor = System.Drawing.Color.White
        Me.signupPortal.Location = New System.Drawing.Point(188, 0)
        Me.signupPortal.Name = "signupPortal"
        Me.signupPortal.Size = New System.Drawing.Size(105, 47)
        Me.signupPortal.TabIndex = 14
        Me.signupPortal.Text = "signup"
        Me.signupPortal.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(17, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(151, 22)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Don't have an account?"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Poppins", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(506, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(441, 113)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Welcome to"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Poppins", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(520, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(370, 84)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Noble Auction"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(540, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(182, 22)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "login to access your account"
        '
        'exitLogin
        '
        Me.exitLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.exitLogin.FlatAppearance.BorderSize = 0
        Me.exitLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.exitLogin.Image = Global.nobleAuction.My.Resources.Resources.cross
        Me.exitLogin.Location = New System.Drawing.Point(973, 0)
        Me.exitLogin.Name = "exitLogin"
        Me.exitLogin.Size = New System.Drawing.Size(52, 31)
        Me.exitLogin.TabIndex = 8
        Me.exitLogin.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.nobleAuction.My.Resources.Resources.login_vector1
        Me.PictureBox4.Location = New System.Drawing.Point(892, 483)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(97, 113)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 7
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.nobleAuction.My.Resources.Resources.login_vector1
        Me.PictureBox3.Location = New System.Drawing.Point(427, 210)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(138, 113)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 6
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.nobleAuction.My.Resources.Resources.login_vector1
        Me.PictureBox2.Location = New System.Drawing.Point(870, 143)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(142, 119)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'pass_toggler
        '
        Me.pass_toggler.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.pass_toggler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pass_toggler.Dock = System.Windows.Forms.DockStyle.Right
        Me.pass_toggler.FlatAppearance.BorderSize = 0
        Me.pass_toggler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pass_toggler.ForeColor = System.Drawing.Color.White
        Me.pass_toggler.Image = Global.nobleAuction.My.Resources.Resources.pass_hide
        Me.pass_toggler.Location = New System.Drawing.Point(179, 0)
        Me.pass_toggler.Name = "pass_toggler"
        Me.pass_toggler.Size = New System.Drawing.Size(74, 32)
        Me.pass_toggler.TabIndex = 19
        Me.pass_toggler.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.nobleAuction.My.Resources.Resources.login_illu1
        Me.PictureBox1.Location = New System.Drawing.Point(476, 210)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(499, 408)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1024, 630)
        Me.Controls.Add(Me.exitLogin)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.loginPanel)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "login"
        Me.loginPanel.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents loginPanel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents signupPortal As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents loginPortal As Button
    Friend WithEvents usernameBox As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents passwordBox As TextBox
    Friend WithEvents pass_toggler As Button
    Friend WithEvents exitLogin As Button
    Friend WithEvents forgetPortal As LinkLabel
End Class
