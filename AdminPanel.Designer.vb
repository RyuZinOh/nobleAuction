<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminPanel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdminPanel))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.adminName = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.goSEttingsAdmin = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.uploadImage = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.AuctionAddition = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.viewAnalysis = New System.Windows.Forms.Button()
        Me.customerManagement = New System.Windows.Forms.Button()
        Me.admindashboard = New System.Windows.Forms.Button()
        Me.maxmin = New System.Windows.Forms.Button()
        Me.exitLogin = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.SplitContainer1.Panel1.Controls.Add(Me.adminName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.uploadImage)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PictureBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.maxmin)
        Me.SplitContainer1.Panel2.Controls.Add(Me.exitLogin)
        Me.SplitContainer1.Size = New System.Drawing.Size(1024, 630)
        Me.SplitContainer1.SplitterDistance = 277
        Me.SplitContainer1.TabIndex = 0
        '
        'adminName
        '
        Me.adminName.AutoSize = True
        Me.adminName.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.adminName.ForeColor = System.Drawing.Color.Gray
        Me.adminName.Location = New System.Drawing.Point(105, 554)
        Me.adminName.Name = "adminName"
        Me.adminName.Size = New System.Drawing.Size(57, 26)
        Me.adminName.TabIndex = 23
        Me.adminName.Text = "Name"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.goSEttingsAdmin)
        Me.Panel5.Location = New System.Drawing.Point(69, 299)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(158, 41)
        Me.Panel5.TabIndex = 22
        '
        'goSEttingsAdmin
        '
        Me.goSEttingsAdmin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.goSEttingsAdmin.FlatAppearance.BorderSize = 0
        Me.goSEttingsAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.goSEttingsAdmin.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.goSEttingsAdmin.ForeColor = System.Drawing.Color.White
        Me.goSEttingsAdmin.Image = Global.nobleAuction.My.Resources.Resources.Setting
        Me.goSEttingsAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.goSEttingsAdmin.Location = New System.Drawing.Point(0, 0)
        Me.goSEttingsAdmin.Name = "goSEttingsAdmin"
        Me.goSEttingsAdmin.Size = New System.Drawing.Size(158, 42)
        Me.goSEttingsAdmin.TabIndex = 0
        Me.goSEttingsAdmin.Text = "SETTINGS"
        Me.goSEttingsAdmin.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(50, 270)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 26)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "SETTING"
        '
        'uploadImage
        '
        Me.uploadImage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.uploadImage.FlatAppearance.BorderSize = 0
        Me.uploadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uploadImage.Image = Global.nobleAuction.My.Resources.Resources.Plus
        Me.uploadImage.Location = New System.Drawing.Point(157, 510)
        Me.uploadImage.Name = "uploadImage"
        Me.uploadImage.Size = New System.Drawing.Size(41, 31)
        Me.uploadImage.TabIndex = 20
        Me.uploadImage.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(90, 474)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(84, 67)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.AuctionAddition)
        Me.Panel4.Location = New System.Drawing.Point(69, 225)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(158, 41)
        Me.Panel4.TabIndex = 18
        '
        'AuctionAddition
        '
        Me.AuctionAddition.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AuctionAddition.FlatAppearance.BorderSize = 0
        Me.AuctionAddition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AuctionAddition.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AuctionAddition.ForeColor = System.Drawing.Color.White
        Me.AuctionAddition.Image = Global.nobleAuction.My.Resources.Resources.Plus
        Me.AuctionAddition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AuctionAddition.Location = New System.Drawing.Point(0, 0)
        Me.AuctionAddition.Name = "AuctionAddition"
        Me.AuctionAddition.Size = New System.Drawing.Size(158, 42)
        Me.AuctionAddition.TabIndex = 0
        Me.AuctionAddition.Text = "ADD"
        Me.AuctionAddition.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(50, 196)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 26)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "AUCTION"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.viewAnalysis)
        Me.Panel3.Controls.Add(Me.customerManagement)
        Me.Panel3.Controls.Add(Me.admindashboard)
        Me.Panel3.Location = New System.Drawing.Point(69, 50)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(158, 119)
        Me.Panel3.TabIndex = 16
        '
        'viewAnalysis
        '
        Me.viewAnalysis.Cursor = System.Windows.Forms.Cursors.Hand
        Me.viewAnalysis.FlatAppearance.BorderSize = 0
        Me.viewAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.viewAnalysis.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.viewAnalysis.ForeColor = System.Drawing.Color.White
        Me.viewAnalysis.Image = Global.nobleAuction.My.Resources.Resources.Pie_chart
        Me.viewAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.viewAnalysis.Location = New System.Drawing.Point(0, 84)
        Me.viewAnalysis.Name = "viewAnalysis"
        Me.viewAnalysis.Size = New System.Drawing.Size(158, 42)
        Me.viewAnalysis.TabIndex = 2
        Me.viewAnalysis.Text = "ANALYTICS"
        Me.viewAnalysis.UseVisualStyleBackColor = True
        '
        'customerManagement
        '
        Me.customerManagement.Cursor = System.Windows.Forms.Cursors.Hand
        Me.customerManagement.FlatAppearance.BorderSize = 0
        Me.customerManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.customerManagement.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.customerManagement.ForeColor = System.Drawing.Color.White
        Me.customerManagement.Image = Global.nobleAuction.My.Resources.Resources.Users
        Me.customerManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.customerManagement.Location = New System.Drawing.Point(0, 42)
        Me.customerManagement.Name = "customerManagement"
        Me.customerManagement.Size = New System.Drawing.Size(158, 42)
        Me.customerManagement.TabIndex = 1
        Me.customerManagement.Text = "CUSTOMERS"
        Me.customerManagement.UseVisualStyleBackColor = True
        '
        'admindashboard
        '
        Me.admindashboard.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.admindashboard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.admindashboard.FlatAppearance.BorderSize = 0
        Me.admindashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admindashboard.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admindashboard.ForeColor = System.Drawing.Color.White
        Me.admindashboard.Image = Global.nobleAuction.My.Resources.Resources.Home
        Me.admindashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admindashboard.Location = New System.Drawing.Point(0, 0)
        Me.admindashboard.Name = "admindashboard"
        Me.admindashboard.Size = New System.Drawing.Size(158, 42)
        Me.admindashboard.TabIndex = 0
        Me.admindashboard.Text = "DASHBOARD"
        Me.admindashboard.UseVisualStyleBackColor = True
        '
        'maxmin
        '
        Me.maxmin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.maxmin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.maxmin.FlatAppearance.BorderSize = 0
        Me.maxmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.maxmin.Image = Global.nobleAuction.My.Resources.Resources.Maximize
        Me.maxmin.Location = New System.Drawing.Point(622, 12)
        Me.maxmin.Name = "maxmin"
        Me.maxmin.Size = New System.Drawing.Size(52, 31)
        Me.maxmin.TabIndex = 19
        Me.maxmin.UseVisualStyleBackColor = True
        '
        'exitLogin
        '
        Me.exitLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.exitLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.exitLogin.FlatAppearance.BorderSize = 0
        Me.exitLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.exitLogin.Image = Global.nobleAuction.My.Resources.Resources.cross
        Me.exitLogin.Location = New System.Drawing.Point(680, 12)
        Me.exitLogin.Name = "exitLogin"
        Me.exitLogin.Size = New System.Drawing.Size(52, 31)
        Me.exitLogin.TabIndex = 18
        Me.exitLogin.UseVisualStyleBackColor = True
        '
        'AdminPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1024, 630)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AdminPanel"
        Me.ShowInTaskbar = False
        Me.Text = "AdminPanel"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents maxmin As Button
    Friend WithEvents exitLogin As Button
    Friend WithEvents adminName As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents goSEttingsAdmin As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents uploadImage As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents AuctionAddition As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents viewAnalysis As Button
    Friend WithEvents customerManagement As Button
    Friend WithEvents admindashboard As Button
End Class
