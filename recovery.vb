Public Class recovery
    Private mouseX As Integer
    Private mouseY As Integer

    Private Sub recovery_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        mouseX = e.X
        mouseY = e.Y
    End Sub

    Private Sub recovery_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If e.Button = MouseButtons.Left Then
            Me.Location = Me.Location + New Size(e.X - mouseX, e.Y - mouseY)
        End If
    End Sub
    Private Sub addUsername_Enter(sender As Object, e As EventArgs) Handles addUsername.Enter
        If addUsername.Text = "Enter your email" Then
            addUsername.Text = ""
            addUsername.ForeColor = Color.White
        End If
    End Sub

    Private Sub addUsername_Leave(sender As Object, e As EventArgs) Handles addUsername.Leave
        If String.IsNullOrWhiteSpace(addUsername.Text) Then
            addUsername.Text = "Enter your email"
            addUsername.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub recovery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        addUsername.Text = "Enter your email"
        addUsername.ForeColor = Color.Gray
    End Sub
End Class
