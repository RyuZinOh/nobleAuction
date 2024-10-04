Public Class AdminPanel
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
End Class
