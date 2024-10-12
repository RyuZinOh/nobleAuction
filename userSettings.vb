Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class userSettings
    Public Property UserName As String

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)
        UpdateRegion()

        If String.IsNullOrEmpty(UserName) Then
            MessageBox.Show("UserName cannot be empty.")
            Return
        End If

        Dim userId As Integer = GetUserId(UserName)
        If userId <> -1 Then LoadUserProfile(userId)

        AddHandler thefirstname.Enter, AddressOf ClearTextBox
        AddHandler thelastname.Enter, AddressOf ClearTextBox
        AddHandler theaddr.Enter, AddressOf ClearTextBox
        AddHandler thephonenumber.Enter, AddressOf ClearTextBox
        AddHandler theemailuser.Enter, AddressOf ClearTextBox
        AddHandler thebio.Enter, AddressOf ClearRichTextBox
    End Sub

    Private Sub ClearTextBox(sender As Object, e As EventArgs)
        Dim textbox As TextBox = CType(sender, TextBox)
        textbox.Clear()
    End Sub

    Private Sub ClearRichTextBox(sender As Object, e As EventArgs)
        Dim richTextBox As RichTextBox = CType(sender, RichTextBox)
        richTextBox.Clear()
    End Sub

    Private Function GetUserId(ByVal username As String) As Integer
        Dim userId As Integer = -1
        Dim connString As String = ConfigurationManager.ConnectionStrings("nobleAuction.My.MySettings.NAconnect").ConnectionString

        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand("SELECT UserID FROM Users WHERE UserName = @UserName", conn)
                cmd.Parameters.AddWithValue("@UserName", username)
                conn.Open()
                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing Then userId = Convert.ToInt32(result)
            End Using
        End Using

        Return userId
    End Function

    Private Sub LoadUserProfile(ByVal userId As Integer)
        Dim connString As String = ConfigurationManager.ConnectionStrings("nobleAuction.My.MySettings.NAconnect").ConnectionString

        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand("SELECT FirstName, LastName, Address, Phone, Email, Bio, DateOfBirth, ProfilePic, ProfileBackground FROM UserProfile JOIN Users ON UserProfile.UserID = Users.UserID WHERE UserProfile.UserID = @UserID", conn)
                cmd.Parameters.AddWithValue("@UserID", userId)
                conn.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim cursiveFont As New Font("Comic Sans MS", 10, FontStyle.Italic)

                        thefirstname.Font = cursiveFont
                        thelastname.Font = cursiveFont
                        theaddr.Font = cursiveFont
                        thephonenumber.Font = cursiveFont
                        theemailuser.Font = cursiveFont
                        thebio.Font = cursiveFont

                        Dim firstName As String = reader("FirstName").ToString()
                        Dim lastName As String = reader("LastName").ToString()

                        FPLname.Text = $"{firstName} {lastName}"
                        thefirstname.Text = firstName
                        thelastname.Text = lastName
                        theaddress.Text = reader("Address").ToString()
                        userBIO.Text = reader("Bio").ToString()

                        theaddr.Text = reader("Address").ToString()
                        thephonenumber.Text = reader("Phone").ToString()
                        theemailuser.Text = reader("Email").ToString()
                        thebio.Text = reader("Bio").ToString()
                        theDOB.Text = Convert.ToDateTime(reader("DateOfBirth")).ToString("MM/dd/yyyy")

                        Dim profilePicPath = reader("ProfilePic").ToString()
                        If IO.File.Exists(profilePicPath) Then
                            userPFP.Image = Image.FromFile(profilePicPath)
                            userPFP.SizeMode = PictureBoxSizeMode.StretchImage
                        End If

                        Dim backgroundPath = reader("ProfileBackground").ToString()
                        If IO.File.Exists(backgroundPath) Then
                            userBG.Image = Image.FromFile(backgroundPath)
                            userBG.SizeMode = PictureBoxSizeMode.StretchImage
                        End If
                    End If
                End Using
            End Using
        End Using
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        UpdateRegion()
    End Sub

    Private Sub UpdateRegion()
        Dim path As New Drawing2D.GraphicsPath()
        Dim radius As Integer = 120

        path.StartFigure()
        path.AddArc(0, 0, radius, radius, 180, 90)
        path.AddArc(Me.Width - radius, 0, radius, radius, 270, 90)
        path.AddArc(Me.Width - radius, Me.Height - radius, radius, radius, 0, 90)
        path.AddArc(0, Me.Height - radius, radius, radius, 90, 90)
        path.CloseFigure()

        Me.Region = New Region(path)
    End Sub

    Private Sub updateAV_Click(sender As Object, e As EventArgs) Handles updateAV.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            userPFP.Image = Image.FromFile(openFileDialog.FileName)
            userPFP.SizeMode = PictureBoxSizeMode.StretchImage
            userPFP.ImageLocation = openFileDialog.FileName
        End If
    End Sub

    Private Sub updateBG_Click(sender As Object, e As EventArgs) Handles updateBG.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            userBG.Image = Image.FromFile(openFileDialog.FileName)
            userBG.SizeMode = PictureBoxSizeMode.StretchImage
            userBG.ImageLocation = openFileDialog.FileName
        End If
    End Sub

    Private Sub savethething_Click(sender As Object, e As EventArgs) Handles savethething.Click
        If Not ValidateEmail(theemailuser.Text) Then
            MessageBox.Show("Please enter a valid email address with '@'.")
            Return
        End If

        Dim userId As Integer = GetUserId(UserName)
        If userId <> -1 Then
            If Not String.IsNullOrEmpty(pskchnage.Text) Then
                If Not ValidatePassword(pskchnage.Text) Then
                    MessageBox.Show("Password must be at least 8 characters long, contain a number and a letter.")
                    Return
                End If

                ChangePassword(userId)
            End If
            SaveUserProfile(userId)
        End If
    End Sub

    Private Sub SaveUserProfile(ByVal userId As Integer)
        Dim connString As String = ConfigurationManager.ConnectionStrings("nobleAuction.My.MySettings.NAconnect").ConnectionString

        Dim profilePicPath As String = If(userPFP.Image IsNot Nothing AndAlso Not String.IsNullOrEmpty(userPFP.ImageLocation), userPFP.ImageLocation, Nothing)
        Dim backgroundPath As String = If(userBG.Image IsNot Nothing AndAlso Not String.IsNullOrEmpty(userBG.ImageLocation), userBG.ImageLocation, Nothing)

        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand("UPDATE UserProfile SET FirstName = @FirstName, LastName = @LastName, Address = @Address, Phone = @Phone, Bio = @Bio, ProfilePic = @ProfilePic, ProfileBackground = @ProfileBackground WHERE UserID = @UserID; UPDATE Users SET Email = @Email WHERE UserID = @UserID", conn)
                cmd.Parameters.AddWithValue("@FirstName", thefirstname.Text)
                cmd.Parameters.AddWithValue("@LastName", thelastname.Text)
                cmd.Parameters.AddWithValue("@Address", theaddr.Text)
                cmd.Parameters.AddWithValue("@Phone", thephonenumber.Text)
                cmd.Parameters.AddWithValue("@Bio", thebio.Text)
                cmd.Parameters.AddWithValue("@ProfilePic", If(String.IsNullOrEmpty(profilePicPath), DBNull.Value, profilePicPath))
                cmd.Parameters.AddWithValue("@ProfileBackground", If(String.IsNullOrEmpty(backgroundPath), DBNull.Value, backgroundPath))
                cmd.Parameters.AddWithValue("@Email", theemailuser.Text)
                cmd.Parameters.AddWithValue("@UserID", userId)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Profile updated successfully.")
    End Sub

    Private Sub ChangePassword(userId As Integer)
        Dim newPassword As String = pskchnage.Text
        Dim hashedPassword As String = HashPassword(newPassword)

        Dim connString As String = ConfigurationManager.ConnectionStrings("nobleAuction.My.MySettings.NAconnect").ConnectionString

        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand("UPDATE Users SET PasswordHash = @PasswordHash WHERE UserID = @UserID", conn)
                cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword)
                cmd.Parameters.AddWithValue("@UserID", userId)
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

    Private Function ValidateEmail(email As String) As Boolean
        Return email.Contains("@") And email.Contains(".")
    End Function

    Private Function ValidatePassword(password As String) As Boolean
        Return password.Length >= 8 And password.Any(AddressOf Char.IsLetter) And password.Any(AddressOf Char.IsDigit)
    End Function
End Class
