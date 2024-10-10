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
                        If Not String.IsNullOrEmpty(profilePicPath) AndAlso IO.File.Exists(profilePicPath) Then
                            Dim img As Image = Image.FromFile(profilePicPath)
                            userPFP.Image = ResizeImage(img, userPFP.Size)
                        End If

                        Dim backgroundPath = reader("ProfileBackground").ToString()
                        If Not String.IsNullOrEmpty(backgroundPath) AndAlso IO.File.Exists(backgroundPath) Then
                            Dim img As Image = Image.FromFile(backgroundPath)
                            userBG.Image = CropAndResizeImage(img, userBG.Size)
                        End If
                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Function ResizeImage(ByVal img As Image, ByVal size As Size) As Image
        Dim ratioX As Double = size.Width / img.Width
        Dim ratioY As Double = size.Height / img.Height
        Dim ratio As Double = Math.Min(ratioX, ratioY)

        Dim newWidth As Integer = CInt(img.Width * ratio)
        Dim newHeight As Integer = CInt(img.Height * ratio)

        Dim newImage As New Bitmap(newWidth, newHeight)
        Using g As Graphics = Graphics.FromImage(newImage)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(img, 0, 0, newWidth, newHeight)
        End Using

        Return newImage
    End Function

    Private Function CropAndResizeImage(ByVal img As Image, ByVal size As Size) As Image
        Dim aspectRatio As Double = img.Width / img.Height
        Dim targetAspectRatio As Double = size.Width / size.Height
        Dim cropRect As Rectangle

        If aspectRatio > targetAspectRatio Then
            Dim newWidth As Integer = CInt(size.Height * aspectRatio)
            cropRect = New Rectangle((newWidth - size.Width) / 2, 0, size.Width, size.Height)
        Else
            Dim newHeight As Integer = CInt(size.Width / aspectRatio)
            cropRect = New Rectangle(0, (newHeight - size.Height) / 2, size.Width, size.Height)
        End If

        Dim newImage As New Bitmap(size.Width, size.Height)
        Using g As Graphics = Graphics.FromImage(newImage)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(img, New Rectangle(0, 0, size.Width, size.Height), cropRect, GraphicsUnit.Pixel)
        End Using

        Return newImage
    End Function

    Private Sub UpdateRegion()
        Dim path As New Drawing2D.GraphicsPath()
        Dim radius As Integer = 20

        path.StartFigure()
        path.AddArc(0, 0, radius, radius, 180, 90)
        path.AddArc(Me.Width - radius, 0, radius, radius, 270, 90)
        path.AddArc(Me.Width - radius, Me.Height - radius, radius, radius, 0, 90)
        path.AddArc(0, Me.Height - radius, radius, radius, 90, 90)
        path.CloseFigure()

        Me.Region = New Region(path)
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        UpdateRegion()
    End Sub

    Private Sub updateAV_Click(sender As Object, e As EventArgs) Handles updateAV.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            userPFP.Image = Image.FromFile(openFileDialog.FileName)
            userPFP.SizeMode = PictureBoxSizeMode.StretchImage
        End If
    End Sub

    Private Sub updateBG_Click(sender As Object, e As EventArgs) Handles updateBG.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim img As Image = Image.FromFile(openFileDialog.FileName)
            userBG.Image = CropAndResizeImage(img, userBG.Size)
        End If
    End Sub

    Private Sub savethething_Click(sender As Object, e As EventArgs) Handles savethething.Click
        Dim userId As Integer = GetUserId(UserName)
        If userId <> -1 Then SaveUserProfile(userId)
    End Sub

    Private Sub SaveUserProfile(ByVal userId As Integer)
        Dim connString As String = ConfigurationManager.ConnectionStrings("nobleAuction.My.MySettings.NAconnect").ConnectionString
        Dim profilePicPath As String = ""
        Dim backgroundPath As String = ""

        If userPFP.Image IsNot Nothing Then
            profilePicPath = $"{userId}_ProfilePic.jpg"
            userPFP.Image.Save(profilePicPath, ImageFormat.Jpeg)
        End If

        If userBG.Image IsNot Nothing Then
            backgroundPath = $"{userId}_Background.jpg"
            userBG.Image.Save(backgroundPath, ImageFormat.Jpeg)
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

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub
End Class
