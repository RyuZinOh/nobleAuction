Public Class AdminPanel
    Public Property AdminUsername As String

    Private Sub AdminPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        adminName.Text = AdminUsername
    End Sub

    Private Sub customerManagement_Click(sender As Object, e As EventArgs) Handles customerManagement.Click
        Dim customerManagerForm As New CustomerManager()
        customerManagerForm.TopLevel = False
        customerManagerForm.FormBorderStyle = FormBorderStyle.None
        customerManagerForm.Dock = DockStyle.Fill

        Panel2.Controls.Clear()
        Panel2.Controls.Add(customerManagerForm)
        customerManagerForm.Show()
    End Sub

    Private Sub exitLogin_Click(sender As Object, e As EventArgs) Handles exitLogin.Click
        Application.Exit()
    End Sub


    Private Sub AuctionAddition_Click(sender As Object, e As EventArgs) Handles AuctionAddition.Click
        Dim skibidi As New ItemPublish()
        skibidi.TopLevel = ItemPublish.TopLevel = False
        skibidi.FormBorderStyle = FormBorderStyle.None
        skibidi.Dock = DockStyle.Fill

        Panel2.Controls.Clear()
        Panel2.Controls.Add(skibidi)
        skibidi.Show()
    End Sub
    Private Sub maxmin_Click(sender As Object, e As EventArgs) Handles maxmin.Click
        If Me.WindowState = FormWindowState.Normal Then
            ' Switch to fullscreen mode
            Me.WindowState = FormWindowState.Maximized
            maxmin.Image = My.Resources.Minimize ' Change to your restore image
        Else
            ' Switch back to normal mode
            Me.WindowState = FormWindowState.Normal
            maxmin.Image = My.Resources.Maximize ' Change to your maximize image
        End If
    End Sub

End Class
