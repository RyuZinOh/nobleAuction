Imports System.Drawing.Drawing2D
Imports System.Data.SqlClient
Imports System.Configuration

Public Class usersDashboard
    Private WithEvents Timer1 As New Timer()
    Private displayedItemIDs As New HashSet(Of Integer)()

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)
        UpdateRegion()
        LoadAuctionItems()
        Timer1.Interval = 10000
        Timer1.Start()
    End Sub

    Private Sub UpdateRegion()
        Dim path As New GraphicsPath()
        Dim radius As Integer = 120

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

    Private Sub LoadAuctionItems()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("nobleAuction.My.MySettings.NAconnect").ConnectionString
        Dim query As String = "SELECT ItemID, ItemName, Description, StartingPrice, Category, ItemPicture FROM AuctionItems"

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(query, connection)
            connection.Open()

            Using reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim itemID As Integer = reader.GetInt32(0)

                    ' Check if the item is already displayed
                    If displayedItemIDs.Contains(itemID) Then
                        Continue While ' Skip to the next item if it already exists
                    End If

                    Dim itemName As String = reader.GetString(1)
                    Dim description As String = reader.GetString(2)
                    Dim startingPrice As Decimal = reader.GetDecimal(3)
                    Dim category As String = reader.GetString(4)
                    Dim itemPicture As String = reader.GetString(5)

                    Dim itemPanel As New Panel() With {
                        .Size = New Size(200, 300),
                        .Margin = New Padding(10),
                        .BorderStyle = BorderStyle.FixedSingle,
                        .BackColor = Color.White
                    }

                    Dim path As New GraphicsPath()
                    Dim radius As Integer = 20
                    path.StartFigure()
                    path.AddArc(0, 0, radius, radius, 180, 90)
                    path.AddArc(itemPanel.Width - radius, 0, radius, radius, 270, 90)
                    path.AddArc(itemPanel.Width - radius, itemPanel.Height - radius, radius, radius, 0, 90)
                    path.AddArc(0, itemPanel.Height - radius, radius, radius, 90, 90)
                    path.CloseFigure()

                    itemPanel.Region = New Region(path)

                    Dim lblItemName As New Label() With {
                        .Text = itemName,
                        .Font = New Font("Poppins", 12, FontStyle.Bold),
                        .Dock = DockStyle.Top
                    }
                    Dim lblDescription As New Label() With {
                        .Text = description,
                        .Dock = DockStyle.Top,
                        .Height = 50,
                        .AutoSize = False,
                        .Font = New Font("Poppins", 9),
                        .BorderStyle = BorderStyle.FixedSingle,
                        .Padding = New Padding(5)
                    }
                    Dim lblStartingPrice As New Label() With {
                        .Text = $"Starting Price: ₹{startingPrice}",
                        .Dock = DockStyle.Top,
                        .Font = New Font("Poppins", 10)
                    }
                    Dim lblCategory As New Label() With {
                        .Text = $"Category: {category}",
                        .Dock = DockStyle.Top,
                        .Font = New Font("Poppins", 10)
                    }
                    Dim pictureBox As New PictureBox() With {
                        .ImageLocation = itemPicture,
                        .SizeMode = PictureBoxSizeMode.StretchImage,
                        .Height = 150,
                        .Dock = DockStyle.Top
                    }

                    itemPanel.Controls.Add(lblItemName)
                    itemPanel.Controls.Add(lblDescription)
                    itemPanel.Controls.Add(lblStartingPrice)
                    itemPanel.Controls.Add(lblCategory)
                    itemPanel.Controls.Add(pictureBox)

                    FlowLayoutPanel1.Controls.Add(itemPanel)
                    displayedItemIDs.Add(itemID)
                End While
            End Using
        End Using
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LoadAuctionItems() ' Reload items from the database
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadAuctionItems() ' Reload items from the database
    End Sub


End Class
