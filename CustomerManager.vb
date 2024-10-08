Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Windows.Forms

Public Class CustomerManager
    Private connectionString As String = ConfigurationManager.ConnectionStrings("nobleAuction.My.MySettings.NAconnect").ConnectionString

    Private Sub CustomerManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Dim query As String = "
            SELECT DISTINCT
                u.UserID AS [UserID], 
                CONCAT(up.FirstName, ' ', up.LastName) AS FULLNAME,
                up.DateOfBirth AS DOB,
                u.Email as EMAIL,
                up.Address as ADDRESS,
                u.PasswordHash AS PASSWORD,
                ISNULL(ub.NobleCoins, 0) AS BALANCE
            FROM Users u
            INNER JOIN UserProfile up ON u.UserID = up.UserID
            LEFT JOIN UserBalance ub ON u.UserID = ub.UserID
        "

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                Using adapter As New SqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    Try
                        connection.Open()
                        adapter.Fill(dataTable)

                        DataGridView1.Columns.Clear()

                        DataGridView1.DataSource = dataTable

                        If Not DataGridView1.Columns.Contains("Delete") Then
                            Dim deleteColumn As New DataGridViewImageColumn()
                            deleteColumn.HeaderText = "Delete"
                            deleteColumn.Image = My.Resources.Trash_black
                            deleteColumn.Name = "Delete"
                            deleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
                            DataGridView1.Columns.Add(deleteColumn)
                        End If

                        Dim fontFamily As New FontFamily("Poppins")
                        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font(fontFamily, 12, FontStyle.Bold)
                        DataGridView1.DefaultCellStyle.Font = New Font(fontFamily, 8, FontStyle.Regular)

                        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                        DataGridView1.Columns("UserID").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        DataGridView1.Columns("UserID").Width = 50
                        DataGridView1.Columns("FULLNAME").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        DataGridView1.Columns("EMAIL").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        DataGridView1.Columns("ADDRESS").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                    Catch ex As Exception
                        MessageBox.Show("An error occurred while loading data: " & ex.Message)
                    End Try
                End Using
            End Using
        End Using
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridView1.Columns("Delete").Index Then
            Dim userID As Integer = Convert.ToInt32(DataGridView1.Rows(e.RowIndex).Cells("UserID").Value)
            Dim confirmResult = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo)
            If confirmResult = DialogResult.Yes Then
                DeleteUser(userID)
                LoadData()
            End If
        End If
    End Sub

    Private Sub DeleteUser(userID As Integer)
        Dim query As String = "
            BEGIN TRY
                BEGIN TRANSACTION;

                DELETE FROM UserBalance WHERE UserID = @UserID;
                DELETE FROM UserProfile WHERE UserID = @UserID;
                DELETE FROM Users WHERE UserID = @UserID;

                COMMIT TRANSACTION;
            END TRY
            BEGIN CATCH
                ROLLBACK TRANSACTION;
                THROW;
            END CATCH
        "

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@UserID", userID)
                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("An error occurred while deleting the user: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub CustomerManager_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

End Class
