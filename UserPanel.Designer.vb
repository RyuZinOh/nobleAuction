﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserPanel
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.email = New System.Windows.Forms.Label()
        Me.UserNmae = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.wallett = New System.Windows.Forms.Button()
        Me.mycarts = New System.Windows.Forms.Button()
        Me.auction = New System.Windows.Forms.Button()
        Me.userDashboard = New System.Windows.Forms.Button()
        Me.setting = New System.Windows.Forms.Button()
        Me.maxmin = New System.Windows.Forms.Button()
        Me.exitLogin = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Location = New System.Drawing.Point(214, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(836, 619)
        Me.Panel1.TabIndex = 0
        '
        'email
        '
        Me.email.AutoSize = True
        Me.email.BackColor = System.Drawing.Color.Transparent
        Me.email.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.email.ForeColor = System.Drawing.Color.DarkGray
        Me.email.Location = New System.Drawing.Point(35, 162)
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(46, 23)
        Me.email.TabIndex = 19
        Me.email.Text = "email"
        '
        'UserNmae
        '
        Me.UserNmae.AutoSize = True
        Me.UserNmae.BackColor = System.Drawing.Color.Transparent
        Me.UserNmae.Font = New System.Drawing.Font("Poppins", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserNmae.ForeColor = System.Drawing.Color.White
        Me.UserNmae.Location = New System.Drawing.Point(31, 128)
        Me.UserNmae.Name = "UserNmae"
        Me.UserNmae.Size = New System.Drawing.Size(158, 48)
        Me.UserNmae.TabIndex = 18
        Me.UserNmae.Text = "username"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.wallett)
        Me.Panel2.Controls.Add(Me.mycarts)
        Me.Panel2.Controls.Add(Me.auction)
        Me.Panel2.Controls.Add(Me.userDashboard)
        Me.Panel2.Location = New System.Drawing.Point(39, 229)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(150, 163)
        Me.Panel2.TabIndex = 20
        '
        'wallett
        '
        Me.wallett.Dock = System.Windows.Forms.DockStyle.Top
        Me.wallett.FlatAppearance.BorderSize = 0
        Me.wallett.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.wallett.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.wallett.ForeColor = System.Drawing.Color.White
        Me.wallett.Location = New System.Drawing.Point(0, 129)
        Me.wallett.Name = "wallett"
        Me.wallett.Size = New System.Drawing.Size(150, 43)
        Me.wallett.TabIndex = 3
        Me.wallett.Text = "WALLETT"
        Me.wallett.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.wallett.UseVisualStyleBackColor = True
        '
        'mycarts
        '
        Me.mycarts.Dock = System.Windows.Forms.DockStyle.Top
        Me.mycarts.FlatAppearance.BorderSize = 0
        Me.mycarts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mycarts.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mycarts.ForeColor = System.Drawing.Color.White
        Me.mycarts.Location = New System.Drawing.Point(0, 86)
        Me.mycarts.Name = "mycarts"
        Me.mycarts.Size = New System.Drawing.Size(150, 43)
        Me.mycarts.TabIndex = 2
        Me.mycarts.Text = "MY BIDS"
        Me.mycarts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mycarts.UseVisualStyleBackColor = True
        '
        'auction
        '
        Me.auction.Dock = System.Windows.Forms.DockStyle.Top
        Me.auction.FlatAppearance.BorderSize = 0
        Me.auction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.auction.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.auction.ForeColor = System.Drawing.Color.White
        Me.auction.Location = New System.Drawing.Point(0, 43)
        Me.auction.Name = "auction"
        Me.auction.Size = New System.Drawing.Size(150, 43)
        Me.auction.TabIndex = 1
        Me.auction.Text = "AUCTION"
        Me.auction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.auction.UseVisualStyleBackColor = True
        '
        'userDashboard
        '
        Me.userDashboard.Dock = System.Windows.Forms.DockStyle.Top
        Me.userDashboard.FlatAppearance.BorderSize = 0
        Me.userDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.userDashboard.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.userDashboard.ForeColor = System.Drawing.Color.White
        Me.userDashboard.Location = New System.Drawing.Point(0, 0)
        Me.userDashboard.Name = "userDashboard"
        Me.userDashboard.Size = New System.Drawing.Size(150, 43)
        Me.userDashboard.TabIndex = 0
        Me.userDashboard.Text = "DASHBOARD"
        Me.userDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.userDashboard.UseVisualStyleBackColor = True
        '
        'setting
        '
        Me.setting.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.setting.FlatAppearance.BorderSize = 0
        Me.setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.setting.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.setting.ForeColor = System.Drawing.Color.White
        Me.setting.Image = Global.nobleAuction.My.Resources.Resources.Setting
        Me.setting.Location = New System.Drawing.Point(39, 625)
        Me.setting.Name = "setting"
        Me.setting.Size = New System.Drawing.Size(150, 46)
        Me.setting.TabIndex = 4
        Me.setting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.setting.UseVisualStyleBackColor = True
        '
        'maxmin
        '
        Me.maxmin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.maxmin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.maxmin.FlatAppearance.BorderSize = 0
        Me.maxmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.maxmin.Image = Global.nobleAuction.My.Resources.Resources.Maximize
        Me.maxmin.Location = New System.Drawing.Point(973, 1)
        Me.maxmin.Name = "maxmin"
        Me.maxmin.Size = New System.Drawing.Size(52, 31)
        Me.maxmin.TabIndex = 23
        Me.maxmin.UseVisualStyleBackColor = True
        '
        'exitLogin
        '
        Me.exitLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.exitLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.exitLogin.FlatAppearance.BorderSize = 0
        Me.exitLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.exitLogin.Image = Global.nobleAuction.My.Resources.Resources.cross
        Me.exitLogin.Location = New System.Drawing.Point(1031, 1)
        Me.exitLogin.Name = "exitLogin"
        Me.exitLogin.Size = New System.Drawing.Size(52, 31)
        Me.exitLogin.TabIndex = 22
        Me.exitLogin.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.nobleAuction.My.Resources.Resources.userIMAGE
        Me.PictureBox1.Location = New System.Drawing.Point(39, 52)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(97, 80)
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'UserPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1082, 695)
        Me.Controls.Add(Me.setting)
        Me.Controls.Add(Me.maxmin)
        Me.Controls.Add(Me.exitLogin)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.email)
        Me.Controls.Add(Me.UserNmae)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "UserPanel"
        Me.Text = "UserPanel"
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents email As Label
    Friend WithEvents UserNmae As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents userDashboard As Button
    Friend WithEvents mycarts As Button
    Friend WithEvents auction As Button
    Friend WithEvents setting As Button
    Friend WithEvents wallett As Button
    Friend WithEvents maxmin As Button
    Friend WithEvents exitLogin As Button
End Class
