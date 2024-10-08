Public Class UserPanel
    Public Property UserName As String
    Public Property UserEmail As String

    Private Sub UserPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UserNmae.Text = UserName
        email.Text = UserEmail
    End Sub

    Private Sub userDashboard_Click(sender As Object, e As EventArgs) Handles userDashboard.Click
        Dim customerManagerForm As New usersDashboard()
        customerManagerForm.TopLevel = False
        customerManagerForm.FormBorderStyle = FormBorderStyle.None
        customerManagerForm.Dock = DockStyle.Fill
        Panel1.Controls.Clear()
        Panel1.Controls.Add(customerManagerForm)
        customerManagerForm.Show()
    End Sub

    Private Sub UserPanel_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Panel1.Controls.Count > 0 Then
            Dim currentDashboard As usersDashboard = CType(Panel1.Controls(0), usersDashboard)
            currentDashboard.Size = Panel1.Size
            currentDashboard.Refresh()
        End If
    End Sub

    Private Sub maxmin_Click(sender As Object, e As EventArgs) Handles maxmin.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
            maxmin.Image = My.Resources.Minimize
        Else
            Me.WindowState = FormWindowState.Normal
            maxmin.Image = My.Resources.Maximize
        End If
    End Sub

    Private Sub exitLogin_Click(sender As Object, e As EventArgs) Handles exitLogin.Click
        Application.Exit()
    End Sub
End Class
