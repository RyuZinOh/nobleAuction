Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Public Class Login
    Private isPasswordVisible As Boolean = False
    Private isDragging As Boolean = False
    Private startPoint As Point

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetPlaceholder(usernameBox, "Enter Username")
        SetPlaceholder(passwordBox, "Enter Password", False)
        pass_toggler.Image = My.Resources.pass_hide
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub usernameBox_Enter(sender As Object, e As EventArgs) Handles usernameBox.Enter
        RemovePlaceholder(usernameBox, "Enter Username")
    End Sub

    Private Sub usernameBox_Leave(sender As Object, e As EventArgs) Handles usernameBox.Leave
        SetPlaceholder(usernameBox, "Enter Username")
    End Sub

    Private Sub passwordBox_Enter(sender As Object, e As EventArgs) Handles passwordBox.Enter
        RemovePlaceholder(passwordBox, "Enter Password")
    End Sub

    Private Sub passwordBox_Leave(sender As Object, e As EventArgs) Handles passwordBox.Leave
        SetPlaceholder(passwordBox, "Enter Password", False)
    End Sub

    Private Sub pass_toggler_Click(sender As Object, e As EventArgs) Handles pass_toggler.Click
        isPasswordVisible = Not isPasswordVisible
        passwordBox.UseSystemPasswordChar = Not isPasswordVisible
        pass_toggler.Image = If(isPasswordVisible, My.Resources.pass_hide, My.Resources.pass_show)
    End Sub

    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim builder As New StringBuilder()
            For Each b As Byte In bytes
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function

    Private Sub Login_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            isDragging = True
            startPoint = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub Login_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If isDragging Then
            Dim newPosition As Point = Me.PointToScreen(New Point(e.X, e.Y))
            Me.Location = New Point(newPosition.X - startPoint.X, newPosition.Y - startPoint.Y)
        End If
    End Sub

    Private Sub Login_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        isDragging = False
    End Sub

    Private Sub exitLogin_Click(sender As Object, e As EventArgs) Handles exitLogin.Click
        Application.Exit()
    End Sub

    Private Sub signupPortal_Click(sender As Object, e As EventArgs) Handles signupPortal.Click
        Me.Hide()
        signup.Show()
    End Sub

    Private Sub SetPlaceholder(textBox As TextBox, placeholder As String, Optional isPassword As Boolean = True)
        If String.IsNullOrWhiteSpace(textBox.Text) Then
            textBox.Text = placeholder
            textBox.ForeColor = Color.Gray
            If isPassword Then textBox.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub RemovePlaceholder(textBox As TextBox, placeholder As String)
        If textBox.Text = placeholder Then
            textBox.Text = ""
            textBox.ForeColor = Color.White
            If textBox Is passwordBox Then textBox.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub LogError(ex As Exception)
        Dim filePath As String = "C:\Logs\LoginErrors.log"
        Using writer As New StreamWriter(filePath, True)
            writer.WriteLine($"{DateTime.Now}: {ex.Message}")
        End Using
    End Sub

    Private Sub loginPortal_Click(sender As Object, e As EventArgs) Handles loginPortal.Click
        Dim username As String = usernameBox.Text.Trim()
        Dim password As String = passwordBox.Text.Trim()

        If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim hashedPassword As String = HashPassword(password)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("nobleAuction.My.MySettings.NAconnect").ConnectionString
        Dim query As String = "SELECT Role, Email FROM Users WHERE UserName = @UserName AND PasswordHash = @PasswordHash"

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@UserName", username)
                cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword)
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim role As String = reader("Role").ToString()
                        Dim email As String = reader("Email").ToString()
                        If role = "Admin" Then
                            Dim adminPanel As New AdminPanel()
                            adminPanel.AdminUsername = username
                            adminPanel.Show()
                            Me.Hide()

                        Else
                            Dim userPanel As New UserPanel()
                            userPanel.UserName = username
                            userPanel.UserEmail = email
                            userPanel.Show()
                            Me.Hide()
                        End If
                    Else
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    LogError(ex)
                    MessageBox.Show("An error occurred during login. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub forgetPortal_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles forgetPortal.LinkClicked
        Me.Hide()
        recovery.Show()
    End Sub
End Class
