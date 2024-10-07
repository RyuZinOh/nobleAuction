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

    End Sub


End Class
