Imports System.Data.SqlClient
Imports System.Configuration

Public Class CustomerManager
    Private connectionString As String = ConfigurationManager.ConnectionStrings("nobleAuction.My.MySettings.NAconnect").ConnectionString

    Private Sub CustomerManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Dim query As String = "
            SELECT DISTINCT
                u.UserID AS uid, 
                CONCAT(up.FirstName, ' ', up.LastName) AS fullName,
                up.DateOfBirth AS DOB,
                u.Email,
                up.Address,
                u.PasswordHash AS Password,
                ISNULL(ub.NobleCoins, 0) AS balance
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

                        DataGridView1.DataSource = dataTable

                        ' Set DataGridView column headers
                        DataGridView1.Columns("uid").HeaderText = "#"
                        DataGridView1.Columns("fullName").HeaderText = "FULL NAME"
                        DataGridView1.Columns("DOB").HeaderText = "DOB"
                        DataGridView1.Columns("Email").HeaderText = "EMAIL"
                        DataGridView1.Columns("Address").HeaderText = "ADDRESS"
                        DataGridView1.Columns("Password").HeaderText = "PASSWORD"
                        DataGridView1.Columns("balance").HeaderText = "BALANCE"

                        ' Create Edit image column
                        Dim editImageColumn As New DataGridViewImageColumn() With {
                            .Name = "Edit",
                            .HeaderText = "",
                            .Image = My.Resources.Edit_black,
                            .ImageLayout = DataGridViewImageCellLayout.Zoom
                        }
                        DataGridView1.Columns.Add(editImageColumn)

                        ' Create Delete image column
                        Dim deleteImageColumn As New DataGridViewImageColumn() With {
                            .Name = "Delete",
                            .HeaderText = "",
                            .Image = My.Resources.Trash_black,
                            .ImageLayout = DataGridViewImageCellLayout.Zoom
                        }
                        DataGridView1.Columns.Add(deleteImageColumn)

                        ' Handle the CellClick event
                        AddHandler DataGridView1.CellClick, AddressOf DataGridView1_CellClick

                    Catch ex As Exception
                        MessageBox.Show("An error occurred while loading data: " & ex.Message)
                    End Try
                End Using
            End Using
        End Using
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            Dim userId As Integer = Convert.ToInt32(DataGridView1.Rows(e.RowIndex).Cells("uid").Value)
            If e.ColumnIndex = DataGridView1.Columns("Edit").Index Then
                MessageBox.Show("Edit User with ID: " & userId)
                ' You can add logic here to open an edit form
            ElseIf e.ColumnIndex = DataGridView1.Columns("Delete").Index Then
                Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete User ID: " & userId & "?", "Confirm Delete", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    DeleteUser(userId)
                    LoadData() ' Reload the data after deletion
                End If
            End If
        End If
    End Sub

    Private Sub DeleteUser(userId As Integer)
        Dim query As String = "DELETE FROM Users WHERE UserID = @UserID"
        Dim checkBalanceQuery As String = "SELECT COUNT(*) FROM UserBalance WHERE UserID = @UserID"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(checkBalanceQuery, connection)
                command.Parameters.AddWithValue("@UserID", userId)

                Try
                    connection.Open()
                    Dim balanceCount As Integer = Convert.ToInt32(command.ExecuteScalar())

                    If balanceCount > 0 Then
                        Dim deleteBalanceQuery As String = "DELETE FROM UserBalance WHERE UserID = @UserID"
                        Using deleteCommand As New SqlCommand(deleteBalanceQuery, connection)
                            deleteCommand.Parameters.AddWithValue("@UserID", userId)
                            deleteCommand.ExecuteNonQuery()
                        End Using
                    End If

                    Using deleteCommand As New SqlCommand(query, connection)
                        deleteCommand.Parameters.AddWithValue("@UserID", userId)
                        deleteCommand.ExecuteNonQuery()
                        MessageBox.Show("User deleted successfully.")
                    End Using

                Catch ex As Exception
                    MessageBox.Show("An error occurred while deleting the user: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub
End Class
