Imports System.Drawing.Drawing2D
Imports System.Data.SqlClient
Imports System.Configuration

Public Class UserPanel
    Public Property UserName As String
    Public Property UserEmail As String

    Private Sub UserPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UserNmae.Text = UserName
        email.Text = UserEmail

        ' Load the user dashboard when the panel loads
        Dim dashboardForm As New usersDashboard()
        dashboardForm.TopLevel = False
        dashboardForm.FormBorderStyle = FormBorderStyle.None
        dashboardForm.Dock = DockStyle.Fill
        Panel1.Controls.Clear()
        Panel1.Controls.Add(dashboardForm)
        dashboardForm.Show()
    End Sub

    Private Sub userDashboard_Click(sender As Object, e As EventArgs) Handles userDashboard.Click
        Dim dashboardForm As New usersDashboard()
        dashboardForm.TopLevel = False
        dashboardForm.FormBorderStyle = FormBorderStyle.None
        dashboardForm.Dock = DockStyle.Fill
        Panel1.Controls.Clear()
        Panel1.Controls.Add(dashboardForm)
        dashboardForm.Show()
    End Sub

    Private Sub UserPanel_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Panel1.Controls.Count > 0 Then
            Dim currentControl As Form = CType(Panel1.Controls(0), Form)
            currentControl.Size = Panel1.Size
            currentControl.Refresh()
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

    Private Sub setting_Click(sender As Object, e As EventArgs) Handles setting.Click
        Dim userSettingsForm As New userSettings()
        userSettingsForm.UserName = Me.UserName ' Pass the UserName to userSettings
        userSettingsForm.TopLevel = False
        userSettingsForm.FormBorderStyle = FormBorderStyle.None
        userSettingsForm.Dock = DockStyle.Fill
        Panel1.Controls.Clear()
        Panel1.Controls.Add(userSettingsForm)
        userSettingsForm.Show()
    End Sub
End Class
