Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Linq
Imports System.Drawing
Imports System.Security.Cryptography
Imports System.Text

Public Class signup
    Private isDragging As Boolean = False
    Private startPoint As Point
    Private hazime As New NotifyIcon()

    Private Sub signup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetPlaceholder(addUsername, "Enter Username")
        SetPlaceholder(addEmail, "Enter Email")
        SetPlaceholder(addPass, "Enter Password", False)
        SetPlaceholder(confirmPass, "Confirm Password", False)
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Initialize NotifyIcon (hazime)
        hazime.Icon = SystemIcons.Information ' Set an icon for the notification
        hazime.Visible = True
    End Sub

    Private Sub gotoLogin_Click(sender As Object, e As EventArgs) Handles gotoLogin.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub dosignUp_Click(sender As Object, e As EventArgs) Handles dosignUp.Click
        Dim errorMessage As String = ""

        If String.IsNullOrWhiteSpace(addUsername.Text) OrElse addUsername.Text = "Enter Username" Then
            errorMessage = "Username is required."
        ElseIf Not IsValidEmail(addEmail.Text) Then
            errorMessage = "Please enter a valid email."
        ElseIf Not IsValidPassword(addPass.Text) Then
            errorMessage = "Password standard doesn't meet."
        ElseIf addPass.Text <> confirmPass.Text Then
            errorMessage = "Passwords do not match."
        ElseIf IsUsernameTaken(addUsername.Text) Then
            errorMessage = "Username is already taken."
        End If

        If errorMessage <> "" Then
            errorsignuphandler.Text = errorMessage
            errorsignuphandler.ForeColor = Color.Red
        Else
            Dim confirmationCode As String = GenerateConfirmationCode()

            Clipboard.SetText(confirmationCode)

            ' Show balloon notification
            ShowBalloonNotification("Your confirmation code has been copied to the clipboard.")

            Dim userInput As String = InputBox("Please enter the confirmation code:", "Confirmation Required")

            If userInput = confirmationCode Then
                InsertUserIntoDatabase(addUsername.Text, addEmail.Text, HashPassword(addPass.Text), "User")
                errorsignuphandler.Text = "Signup successful!"
                errorsignuphandler.ForeColor = Color.Green
            Else
                errorsignuphandler.Text = "Invalid confirmation code. Please try again."
                errorsignuphandler.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub ShowBalloonNotification(message As String)
        hazime.BalloonTipTitle = "Confirmation Code"
        hazime.BalloonTipText = message
        hazime.BalloonTipIcon = ToolTipIcon.Info
        hazime.ShowBalloonTip(3000) ' Show for 3 seconds
    End Sub

    Private Function IsUsernameTaken(username As String) As Boolean
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("nobleAuction.My.MySettings.NAconnect").ConnectionString
        Dim query As String = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName"
        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@UserName", username)
                conn.Open()
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0 ' If count is greater than 0, the username is taken
            End Using
        End Using
    End Function

    Private Sub addUsername_Enter(sender As Object, e As EventArgs) Handles addUsername.Enter
        RemovePlaceholder(addUsername, "Enter Username")
    End Sub

    Private Sub addUsername_Leave(sender As Object, e As EventArgs) Handles addUsername.Leave
        SetPlaceholder(addUsername, "Enter Username")
    End Sub

    Private Sub addEmail_Enter(sender As Object, e As EventArgs) Handles addEmail.Enter
        RemovePlaceholder(addEmail, "Enter Email")
    End Sub

    Private Sub addEmail_Leave(sender As Object, e As EventArgs) Handles addEmail.Leave
        SetPlaceholder(addEmail, "Enter Email")
    End Sub

    Private Sub addPass_Enter(sender As Object, e As EventArgs) Handles addPass.Enter
        RemovePlaceholder(addPass, "Enter Password")
    End Sub

    Private Sub addPass_Leave(sender As Object, e As EventArgs) Handles addPass.Leave
        SetPlaceholder(addPass, "Enter Password", False)
    End Sub

    Private Sub confirmPass_Enter(sender As Object, e As EventArgs) Handles confirmPass.Enter
        RemovePlaceholder(confirmPass, "Confirm Password")
    End Sub

    Private Sub confirmPass_Leave(sender As Object, e As EventArgs) Handles confirmPass.Leave
        SetPlaceholder(confirmPass, "Confirm Password", False)
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
            If textBox Is confirmPass OrElse textBox Is addPass Then
                textBox.UseSystemPasswordChar = True
            End If
        End If
    End Sub

    Private Function IsValidEmail(email As String) As Boolean
        If email.EndsWith("@gmail.com") AndAlso email.Length > "@gmail.com".Length Then
            Return True
        End If
        Return False
    End Function

    Private Function IsValidPassword(password As String) As Boolean
        Dim hasUpper As Boolean = password.Any(Function(c) Char.IsUpper(c))
        Dim hasLower As Boolean = password.Any(Function(c) Char.IsLower(c))
        Dim hasDigit As Boolean = password.Any(Function(c) Char.IsDigit(c))
        Dim hasSpecial As Boolean = password.Any(Function(c) Not Char.IsLetterOrDigit(c))
        Return password.Length >= 8 AndAlso hasUpper AndAlso hasLower AndAlso hasDigit AndAlso hasSpecial
    End Function

    Private Function GenerateConfirmationCode() As String
        Dim rand As New Random()
        Dim confirmationCode As String = rand.Next(100000, 999999).ToString()
        Return confirmationCode
    End Function

    Private Sub InsertUserIntoDatabase(username As String, email As String, passwordHash As String, role As String)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("nobleAuction.My.MySettings.NAconnect").ConnectionString
        Dim query As String = "INSERT INTO Users (UserName, Email, PasswordHash, Role, CreatedAt) VALUES (@UserName, @Email, @PasswordHash, @Role, CURRENT_TIMESTAMP)"
        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@UserName", username)
                cmd.Parameters.AddWithValue("@Email", email)
                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash)
                cmd.Parameters.AddWithValue("@Role", role)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
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

    Private Sub signup_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            isDragging = True
            startPoint = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub signup_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If isDragging Then
            Dim newPosition As Point = Me.PointToScreen(New Point(e.X, e.Y))
            Me.Location = New Point(newPosition.X - startPoint.X, newPosition.Y - startPoint.Y)
        End If
    End Sub

    Private Sub signup_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        isDragging = False
    End Sub

    Private Sub exitLogin_Click(sender As Object, e As EventArgs) Handles exitLogin.Click
        Application.Exit()
    End Sub
End Class
