Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Drawing.Imaging

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
            Using cmd As New SqlCommand("SELECT FirstName, LastName, Address, Bio, DateOfBirth, ProfilePic, ProfileBackground FROM UserProfile WHERE UserID = @UserID", conn)
                cmd.Parameters.AddWithValue("@UserID", userId)
                conn.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        FPLname.Text = $"{reader("FirstName")} {reader("LastName")}"
                        theaddress.Text = reader("Address").ToString()
                        userBIO.Text = reader("Bio").ToString()
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
            userPFP.ImageLocation = openFileDialog.FileName ' Save the path for later use
        End If
    End Sub

    Private Sub updateBG_Click(sender As Object, e As EventArgs) Handles updateBG.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            userBG.Image = Image.FromFile(openFileDialog.FileName)
            userBG.SizeMode = PictureBoxSizeMode.StretchImage
            userBG.ImageLocation = openFileDialog.FileName ' Save the path for later use
        End If
    End Sub

    Private Sub savethething_Click(sender As Object, e As EventArgs) Handles savethething.Click
        Dim userId As Integer = GetUserId(UserName)
        If userId <> -1 Then SaveUserProfile(userId)
    End Sub

    Private Sub SaveUserProfile(ByVal userId As Integer)
        Dim connString As String = ConfigurationManager.ConnectionStrings("nobleAuction.My.MySettings.NAconnect").ConnectionString

        Dim profilePicPath As String = Nothing
        Dim backgroundPath As String = Nothing

        ' Save the profile picture path if it's available
        If userPFP.Image IsNot Nothing AndAlso Not String.IsNullOrEmpty(userPFP.ImageLocation) Then
            profilePicPath = userPFP.ImageLocation
        End If

        ' Save the background image path if it's available
        If userBG.Image IsNot Nothing AndAlso Not String.IsNullOrEmpty(userBG.ImageLocation) Then
            backgroundPath = userBG.ImageLocation
        End If

        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand("UPDATE UserProfile SET ProfilePic = @ProfilePic, ProfileBackground = @ProfileBackground WHERE UserID = @UserID", conn)
                cmd.Parameters.AddWithValue("@ProfilePic", If(String.IsNullOrEmpty(profilePicPath), DBNull.Value, profilePicPath))
                cmd.Parameters.AddWithValue("@ProfileBackground", If(String.IsNullOrEmpty(backgroundPath), DBNull.Value, backgroundPath))
                cmd.Parameters.AddWithValue("@UserID", userId)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Profile updated successfully!")
    End Sub
End Class
