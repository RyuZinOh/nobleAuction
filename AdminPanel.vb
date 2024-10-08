Imports System.Configuration
Imports System.Data.SqlClient

Public Class AdminPanel
    Public Property AdminUsername As String

    Private Sub AdminPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        adminName.Text = AdminUsername
        LoadUserProfileData(8)
    End Sub

    Private Sub LoadUserProfileData(userId As Integer)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("nobleAuction.My.MySettings.NAconnect").ConnectionString

        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT FirstName, LastName, ProfilePic FROM UserProfile WHERE UserID = @UserID"

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@UserID", userId)
                connection.Open()

                Using reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        adminName.Text = $"{reader("FirstName")} {reader("LastName")}"
                        Dim profilePic As String = reader("ProfilePic").ToString()
                        If Not String.IsNullOrEmpty(profilePic) AndAlso System.IO.File.Exists(profilePic) Then
                            PictureBox1.Image = Image.FromFile(profilePic)
                        End If
                    End If
                End Using
            End Using
        End Using
    End Sub

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

    Private Sub AuctionAddition_Click(sender As Object, e As EventArgs) Handles AuctionAddition.Click
        Dim skibidi As New ItemPublish()
        skibidi.TopLevel = False
        skibidi.FormBorderStyle = FormBorderStyle.None
        skibidi.Dock = DockStyle.Fill

        Panel2.Controls.Clear()
        Panel2.Controls.Add(skibidi)
        skibidi.Show()
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

    Private Sub uploadImage_Click(sender As Object, e As EventArgs) Handles uploadImage.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim imagePath As String = openFileDialog.FileName
            PictureBox1.Image = Image.FromFile(imagePath)
            UpdateProfilePicInDatabase(imagePath, 8)
        End If
    End Sub

    Private Sub UpdateProfilePicInDatabase(imagePath As String, userId As Integer)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("nobleAuction.My.MySettings.NAconnect").ConnectionString

        Using connection As New SqlConnection(connectionString)
            Dim query As String = "UPDATE UserProfile SET ProfilePic = @ProfilePic WHERE UserID = @UserID"

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ProfilePic", imagePath)
                command.Parameters.AddWithValue("@UserID", userId)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub logOFF_Click(sender As Object, e As EventArgs) Handles logOFF.Click
        Login.Show()
        Me.Hide()
    End Sub
End Class
