Imports System.Configuration
Imports System.Data.SqlClient

Public Class BYauctionUserBids
    Public Property UserName As String
    Private connString As String = ConfigurationManager.ConnectionStrings("nobleAuction.My.MySettings.NAconnect").ConnectionString

    Private Sub BYauctionUserBids_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 5000
        Timer1.Start()
        LoadAuctionItems()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LoadAuctionItems()
    End Sub

    Private Sub LoadAuctionItems()
        FlowLayoutPanel1.Controls.Clear()
        highestBIDDER.Controls.Clear()
        Dim query As String = "SELECT ItemID, ItemName, Description, StartingPrice, Category, ItemPicture FROM AuctionItems"

        Using connection As New SqlConnection(connString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                Dim reader As SqlDataReader = command.ExecuteReader()

                While reader.Read()
                    Dim itemPanel As New Panel With {
                        .Size = New Size(300, 300),
                        .Margin = New Padding(10),
                        .BorderStyle = BorderStyle.None,
                        .BackColor = Color.White,
                        .Padding = New Padding(10),
                        .Cursor = Cursors.Hand
                    }

                    Dim lblItemName As New Label With {
                        .Text = reader("ItemName").ToString(),
                        .Font = New Font("Poppins", 12, FontStyle.Bold),
                        .Location = New Point(10, 10),
                        .AutoSize = True
                    }

                    Dim lblDescription As New Label With {
                        .Text = reader("Description").ToString(),
                        .Font = New Font("Poppins", 10),
                        .Location = New Point(10, 40),
                        .AutoSize = True,
                        .MaximumSize = New Size(280, 50),
                        .ForeColor = Color.Gray
                    }

                    Dim lblPrice As New Label With {
                        .Text = "Starting Price: $" & reader("StartingPrice").ToString(),
                        .Font = New Font("Poppins", 10, FontStyle.Bold),
                        .Location = New Point(10, 100),
                        .AutoSize = True
                    }

                    If Not IsDBNull(reader("ItemPicture")) Then
                        Dim itemPicture As New PictureBox With {
                            .ImageLocation = reader("ItemPicture").ToString(),
                            .SizeMode = PictureBoxSizeMode.StretchImage,
                            .Location = New Point(10, 130),
                            .Size = New Size(100, 100)
                        }
                        itemPanel.Controls.Add(itemPicture)
                    End If

                    Dim btnPlaceBid As New Button With {
                        .Text = "Place Bid",
                        .Tag = reader("ItemID"),
                        .Location = New Point(150, 220),
                        .Size = New Size(120, 40),
                        .FlatStyle = FlatStyle.Flat,
                        .Font = New Font("Poppins", 10, FontStyle.Bold),
                        .BackColor = Color.FromArgb(0, 123, 255),
                        .ForeColor = Color.White,
                        .Cursor = Cursors.Hand
                    }
                    AddHandler btnPlaceBid.Click, AddressOf PlaceBid_Click

                    itemPanel.Controls.Add(lblItemName)
                    itemPanel.Controls.Add(lblDescription)
                    itemPanel.Controls.Add(lblPrice)
                    itemPanel.Controls.Add(btnPlaceBid)

                    FlowLayoutPanel1.Controls.Add(itemPanel)

                    Dim highestBidderPanel As Panel = CreateHighestBidderPanel(reader("ItemID"))
                    highestBIDDER.Controls.Add(highestBidderPanel)
                End While
            End Using
        End Using
    End Sub

    Private Function CreateHighestBidderPanel(itemId As Integer) As Panel
        Dim highestBidderPanel As New Panel With {
        .Size = New Size(280, 60),
        .Margin = New Padding(10, 5, 10, 10),
        .BackColor = Color.White,
        .Padding = New Padding(5),
        .BorderStyle = BorderStyle.FixedSingle
    }

        Dim highestBidderName As String = GetHighestBidderName(itemId)
        Dim highestBidAmount As Decimal = GetHighestBidAmount(itemId)
        Dim startingPrice As Decimal = GetStartingPrice(itemId)

        Dim lblHighestBidder As New Label With {
        .Text = $"{highestBidderName} - ${highestBidAmount:0.00} ({GetItemName(itemId)})",
        .Font = New Font("Poppins", 10, FontStyle.Bold),
        .AutoSize = True,
        .ForeColor = Color.Green
    }

        highestBidderPanel.Controls.Add(lblHighestBidder)

        Return highestBidderPanel
    End Function

    Private Function GetItemName(itemId As Integer) As String
        Dim query As String = "SELECT ItemName FROM AuctionItems WHERE ItemID = @ItemID"
        Dim itemName As String = "Unknown Item"

        Using connection As New SqlConnection(connString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ItemID", itemId)
                Dim result = command.ExecuteScalar()
                If result IsNot Nothing Then
                    itemName = result.ToString()
                End If
            End Using
        End Using

        Return itemName
    End Function

    Private Function GetHighestBidderName(itemId As Integer) As String
        Dim query As String = "SELECT UserName FROM Users INNER JOIN Bids ON Users.UserID = Bids.UserID WHERE Bids.ItemID = @ItemID ORDER BY BidAmount DESC"
        Dim highestBidderName As String = "No bids yet"

        Using connection As New SqlConnection(connString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ItemID", itemId)
                Dim result = command.ExecuteScalar()
                If result IsNot Nothing Then
                    highestBidderName = result.ToString()
                End If
            End Using
        End Using

        Return highestBidderName
    End Function

    Private Function GetHighestBidAmount(itemId As Integer) As Decimal
        Dim query As String = "SELECT TOP 1 BidAmount FROM Bids WHERE ItemID = @ItemID ORDER BY BidAmount DESC"
        Dim highestBidAmount As Decimal = 0

        Using connection As New SqlConnection(connString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ItemID", itemId)
                Dim result = command.ExecuteScalar()
                If result IsNot Nothing Then
                    highestBidAmount = Convert.ToDecimal(result)
                End If
            End Using
        End Using

        Return highestBidAmount
    End Function

    Private Function GetStartingPrice(itemId As Integer) As Decimal
        Dim query As String = "SELECT StartingPrice FROM AuctionItems WHERE ItemID = @ItemID"
        Dim startingPrice As Decimal = 0

        Using connection As New SqlConnection(connString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ItemID", itemId)
                Dim result = command.ExecuteScalar()
                If result IsNot Nothing Then
                    startingPrice = Convert.ToDecimal(result)
                End If
            End Using
        End Using

        Return startingPrice
    End Function

    Private Sub PlaceBid_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim itemId As Integer = CInt(btn.Tag)

        Dim bidAmountInput As String = InputBox("Enter your bid amount:", "Place Bid")
        Dim bidAmount As Decimal

        If Not Decimal.TryParse(bidAmountInput, bidAmount) OrElse bidAmount <= 0 Then
            MessageBox.Show("Invalid bid amount. Please enter a valid number.")
            Return
        End If

        Dim startingPrice As Decimal = GetStartingPrice(itemId)

        If bidAmount < startingPrice Then
            MessageBox.Show($"Your bid must be at least the starting price of ${startingPrice:0.00}.")
            Return
        End If

        Dim userId As Integer = GetUserIdByName(UserName)

        If HasSufficientBalance(userId, bidAmount) Then
            Dim highestBidderId As Integer
            Dim highestBidAmount As Decimal

            If GetHighestBidder(itemId, highestBidderId, highestBidAmount) Then
                If bidAmount > highestBidAmount Then
                    RefundPreviousBidder(highestBidderId, highestBidAmount)
                    PlaceBid(userId, itemId, bidAmount)
                    MessageBox.Show("You placed a higher bid and outbid the previous bidder.")
                Else
                    MessageBox.Show("Your bid must be higher than the current highest bid.")
                End If
            Else
                PlaceBid(userId, itemId, bidAmount)
                MessageBox.Show("Bid placed successfully.")
            End If
        Else
            MessageBox.Show("Insufficient balance. Please add more NobleCoins to place a bid.")
        End If
    End Sub

    Private Function GetUserIdByName(userName As String) As Integer
        Dim query As String = "SELECT UserID FROM Users WHERE UserName = @UserName"
        Dim userId As Integer

        Using connection As New SqlConnection(connString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@UserName", userName)
                userId = Convert.ToInt32(command.ExecuteScalar())
            End Using
        End Using

        Return userId
    End Function

    Private Function HasSufficientBalance(userId As Integer, bidAmount As Decimal) As Boolean
        Dim query As String = "SELECT NobleCoins FROM UserBalance WHERE UserID = @UserID"

        Using connection As New SqlConnection(connString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@UserID", userId)
                Dim balance = Convert.ToDecimal(command.ExecuteScalar())
                Return balance >= bidAmount
            End Using
        End Using
    End Function

    Private Sub PlaceBid(userId As Integer, itemId As Integer, bidAmount As Decimal)
        Dim query As String = "INSERT INTO Bids (UserID, ItemID, BidAmount) VALUES (@UserID, @ItemID, @BidAmount)"

        Using connection As New SqlConnection(connString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@UserID", userId)
                command.Parameters.AddWithValue("@ItemID", itemId)
                command.Parameters.AddWithValue("@BidAmount", bidAmount)
                command.ExecuteNonQuery()
            End Using
        End Using

        UpdateUserBalance(userId, bidAmount)
    End Sub

    Private Sub UpdateUserBalance(userId As Integer, bidAmount As Decimal)
        Dim query As String = "UPDATE UserBalance SET NobleCoins = NobleCoins - @BidAmount WHERE UserID = @UserID"

        Using connection As New SqlConnection(connString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@BidAmount", bidAmount)
                command.Parameters.AddWithValue("@UserID", userId)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub RefundPreviousBidder(previousBidderId As Integer, previousBidAmount As Decimal)
        Dim query As String = "UPDATE UserBalance SET NobleCoins = NobleCoins + @PreviousBidAmount WHERE UserID = @PreviousBidderID"

        Using connection As New SqlConnection(connString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@PreviousBidAmount", previousBidAmount)
                command.Parameters.AddWithValue("@PreviousBidderID", previousBidderId)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Function GetHighestBidder(itemId As Integer, ByRef highestBidderId As Integer, ByRef highestBidAmount As Decimal) As Boolean
        Dim query As String = "SELECT TOP 1 UserID, BidAmount FROM Bids WHERE ItemID = @ItemID ORDER BY BidAmount DESC"

        Using connection As New SqlConnection(connString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ItemID", itemId)
                Using reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        highestBidderId = Convert.ToInt32(reader("UserID"))
                        highestBidAmount = Convert.ToDecimal(reader("BidAmount"))
                        Return True
                    End If
                End Using
            End Using
        End Using

        Return False
    End Function
End Class
