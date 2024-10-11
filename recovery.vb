Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms
Imports System.Configuration
Imports System.Drawing

Public Class recovery
    Private mouseX As Integer
    Private mouseY As Integer
    Private isDragging As Boolean = False
    Private generatedOtp As String = String.Empty
    Private userEmail As String = String.Empty

    ' Enable form dragging
    Private Sub recovery_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            isDragging = True
            mouseX = e.X
            mouseY = e.Y
        End If
    End Sub

    Private Sub recovery_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If isDragging Then
            Me.Location = New Point(Me.Location.X + e.X - mouseX, Me.Location.Y + e.Y - mouseY)
        End If
    End Sub

    Private Sub recovery_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        isDragging = False
    End Sub

    ' Handle email placeholder behavior
    Private Sub addVemail_Enter(sender As Object, e As EventArgs) Handles addVemail.Enter
        If addVemail.Text = "Enter your email" Then
            addVemail.Text = ""
            addVemail.ForeColor = Color.White
        End If
    End Sub

    Private Sub addVemail_Leave(sender As Object, e As EventArgs) Handles addVemail.Leave
        If String.IsNullOrWhiteSpace(addVemail.Text) Then
            addVemail.Text = "Enter your email"
            addVemail.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub recovery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        addVemail.Text = "Enter your email"
        addVemail.ForeColor = Color.Gray
    End Sub

    ' Generate OTP and reset password logic
    Private Sub getCode_Click(sender As Object, e As EventArgs) Handles getCode.Click
        userEmail = addVemail.Text.Trim()

        If String.IsNullOrWhiteSpace(userEmail) OrElse userEmail = "Enter your email" Then
            MessageBox.Show("Please enter a valid email.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Step 1: Verify the email exists in the database
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("nobleAuction.My.MySettings.NAconnect").ConnectionString
        Dim query As String = "SELECT COUNT(1) FROM Users WHERE Email = @Email"

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Email", userEmail)
                Try
                    conn.Open()
                    Dim emailExists As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If emailExists = 1 Then
                        ' Step 2: Generate OTP
                        generatedOtp = GenerateOTP()

                        ' Copy OTP to clipboard
                        Clipboard.SetText(generatedOtp)

                        ' Step 3: Show balloon notification with OTP information
                        Dim notifyIcon As New NotifyIcon()
                        notifyIcon.Icon = SystemIcons.Information
                        notifyIcon.Visible = True
                        notifyIcon.BalloonTipTitle = "OTP Copied"
                        notifyIcon.BalloonTipText = "Your OTP has been copied to the clipboard."
                        notifyIcon.ShowBalloonTip(3000)

                        ' Step 4: Prompt user to enter OTP
                        Dim enteredOtp As String = InputBox("Enter the OTP sent to your email:", "Verify OTP")

                        If enteredOtp = generatedOtp Then
                            ' Step 5: Prompt for new password
                            Dim newPassword As String = InputBox("Enter your new password:", "Reset Password")

                            If Not String.IsNullOrWhiteSpace(newPassword) Then
                                ' Step 6: Hash the new password and update the database
                                Dim hashedPassword As String = HashPassword(newPassword)
                                ResetPassword(hashedPassword)
                                MessageBox.Show("Password reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("Incorrect OTP entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If

                    Else
                        MessageBox.Show("Email not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' Function to generate a 6-digit OTP
    Private Function GenerateOTP() As String
        Dim random As New Random()
        Return random.Next(100000, 999999).ToString()
    End Function

    ' Function to hash the password using SHA-256
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

    ' Function to reset the password in the database
    Private Sub ResetPassword(hashedPassword As String)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("nobleAuction.My.MySettings.NAconnect").ConnectionString
        Dim query As String = "UPDATE Users SET PasswordHash = @PasswordHash WHERE Email = @Email"

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword)
                cmd.Parameters.AddWithValue("@Email", userEmail)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub exitLogin_Click(sender As Object, e As EventArgs) Handles exitLogin.Click
        Application.Exit()
    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Login.Show()
        Me.Hide()
    End Sub


End Class
