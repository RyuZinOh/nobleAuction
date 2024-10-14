<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BYauctionUserBids
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bidrefresh = New System.Windows.Forms.Button()
        Me.LOGOLABEL = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.highestBIDDER = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.bidrefresh)
        Me.Panel1.Controls.Add(Me.LOGOLABEL)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(836, 47)
        Me.Panel1.TabIndex = 1
        '
        'bidrefresh
        '
        Me.bidrefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bidrefresh.FlatAppearance.BorderSize = 0
        Me.bidrefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bidrefresh.Image = Global.nobleAuction.My.Resources.Resources.refresh
        Me.bidrefresh.Location = New System.Drawing.Point(779, 0)
        Me.bidrefresh.Name = "bidrefresh"
        Me.bidrefresh.Size = New System.Drawing.Size(45, 47)
        Me.bidrefresh.TabIndex = 24
        Me.bidrefresh.UseVisualStyleBackColor = True
        '
        'LOGOLABEL
        '
        Me.LOGOLABEL.AutoSize = True
        Me.LOGOLABEL.BackColor = System.Drawing.Color.Transparent
        Me.LOGOLABEL.Font = New System.Drawing.Font("Poppins", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LOGOLABEL.ForeColor = System.Drawing.Color.White
        Me.LOGOLABEL.Location = New System.Drawing.Point(28, -1)
        Me.LOGOLABEL.Name = "LOGOLABEL"
        Me.LOGOLABEL.Size = New System.Drawing.Size(135, 48)
        Me.LOGOLABEL.TabIndex = 20
        Me.LOGOLABEL.Text = "BIDDING"
        '
        'Timer1
        '
        '
        'highestBIDDER
        '
        Me.highestBIDDER.BackColor = System.Drawing.Color.White
        Me.highestBIDDER.Dock = System.Windows.Forms.DockStyle.Right
        Me.highestBIDDER.Location = New System.Drawing.Point(530, 47)
        Me.highestBIDDER.Name = "highestBIDDER"
        Me.highestBIDDER.Size = New System.Drawing.Size(306, 572)
        Me.highestBIDDER.TabIndex = 2
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 47)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(530, 572)
        Me.FlowLayoutPanel1.TabIndex = 3
        '
        'BYauctionUserBids
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(836, 619)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.highestBIDDER)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "BYauctionUserBids"
        Me.Text = "BYauctionUser"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents bidrefresh As Button
    Friend WithEvents LOGOLABEL As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents highestBIDDER As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
End Class
