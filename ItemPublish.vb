Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing

Public Class ItemPublish
    Private placeholders As New Dictionary(Of TextBox, String)
    Private random As New Random()
    Private connectionString As String = ConfigurationManager.ConnectionStrings("nobleAuction.My.MySettings.NAconnect").ConnectionString

    Private imagePath As String = String.Empty

    Private Sub ItemPublish_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializePlaceholders()
        SetupCategoryAutoComplete()
    End Sub

    Private Sub InitializePlaceholders()
        placeholders.Add(additemname, "Item Name")
        placeholders.Add(addstartingPrice, "Starting NC")
        placeholders.Add(addcategory, "Category")
        placeholders.Add(addendingTime, "Ending Time")
        For Each textbox In placeholders.Keys
            SetPlaceholder(textbox)
            AddHandler textbox.GotFocus, AddressOf TextBox_GotFocus
            AddHandler textbox.LostFocus, AddressOf TextBox_LostFocus
        Next
    End Sub

    Private Sub SetupCategoryAutoComplete()
        Dim categories As New AutoCompleteStringCollection()
        categories.AddRange(New String() {
            "Art", "Electronics", "Jewelry", "Books", "Furniture",
            "Clothing", "Antiques", "Vehicles", "Collectibles", "Toys",
            "Real Estate", "Musical Instruments", "Sports Memorabilia"
        })
        addcategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        addcategory.AutoCompleteSource = AutoCompleteSource.CustomSource
        addcategory.AutoCompleteCustomSource = categories
    End Sub

    Private Sub SetPlaceholder(textbox As TextBox)
        If String.IsNullOrWhiteSpace(textbox.Text) Then
            textbox.Text = placeholders(textbox)
            textbox.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub RemovePlaceholder(textbox As TextBox)
        If textbox.Text = placeholders(textbox) Then
            textbox.Text = ""
            textbox.ForeColor = Color.White
        End If
    End Sub

    Private Sub TextBox_GotFocus(sender As Object, e As EventArgs)
        RemovePlaceholder(DirectCast(sender, TextBox))
    End Sub

    Private Sub TextBox_LostFocus(sender As Object, e As EventArgs)
        Dim textbox = DirectCast(sender, TextBox)
        SetPlaceholder(textbox)
        If textbox Is addstartingPrice Then ValidateStartingNC()
        If textbox Is addendingTime Then ValidateEndingTime()
    End Sub

    Private Sub ValidateStartingNC()
        Dim value As Integer
        If Integer.TryParse(addstartingPrice.Text, value) Then
            addstartingPrice.Text = value.ToString() & " NC"
        Else
            addstartingPrice.Text = "0 NC"
        End If
    End Sub

    Private Sub ValidateEndingTime()
        Dim value As Integer
        If Integer.TryParse(addendingTime.Text.Replace("hr", "").Trim(), value) Then
            If value < 0 Then value = 0
            addendingTime.Text = value.ToString() & " hr"
        Else
            addendingTime.Text = "0 hr"
        End If
    End Sub

    Private Sub addstartingPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles addstartingPrice.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub addendingTime_KeyPress(sender As Object, e As KeyPressEventArgs) Handles addendingTime.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub generate_Click(sender As Object, e As EventArgs) Handles generate.Click
        Dim generatedIDValue As Integer = random.Next(1, 10000)
        Dim itemNameValue As String = additemname.Text
        Dim itemCategoryValue As String = addcategory.Text
        Dim startingPriceValue As String = addstartingPrice.Text
        itemName.Text = itemNameValue
        itemCAT.Text = itemCategoryValue
        Dim startingPriceInt As Decimal
        If Decimal.TryParse(startingPriceValue.Replace(" NC", ""), startingPriceInt) Then
            Dim createdTime As DateTime = DateTime.Now
            Dim starterTime As DateTime = createdTime.AddSeconds(60)
            starter.Text = starterTime.ToString("HH:mm:ss")
            Dim endingTimeInt As Integer
            If Integer.TryParse(addendingTime.Text.Replace(" hr", ""), endingTimeInt) Then
                If endingTimeInt < 0 Or endingTimeInt > 5 Then
                    MessageBox.Show("Ending time must be between 0 and 5 hours.", "Invalid Ending Time", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ender.Text = "Invalid End Time"
                Else
                    ender.Text = starterTime.AddHours(endingTimeInt).ToString("HH:mm:ss")
                End If
            Else
                ender.Text = "Invalid End Time"
            End If
        Else
            starter.Text = "0 NC"
        End If
        startingNC.Text = startingPriceValue
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.InitialDirectory = "C:\"
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            openFileDialog.Title = "Select an Image File"
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                imagePath = openFileDialog.FileName
                picIMAGE.Image = Image.FromFile(imagePath)
                picIMAGE.SizeMode = PictureBoxSizeMode.StretchImage
            End If
        End Using
    End Sub

    Private Sub confirm_Click(sender As Object, e As EventArgs) Handles confirm.Click
        Dim itemNameValue As String = additemname.Text
        Dim descriptionValue As String = RichtextIdemdesc.Text
        Dim startingPriceValue As Decimal
        Decimal.TryParse(addstartingPrice.Text.Replace(" NC", ""), startingPriceValue)
        Dim createdTime As DateTime = DateTime.Now
        Dim endingTime As DateTime = createdTime.AddSeconds(60).AddHours(Integer.Parse(addendingTime.Text.Replace(" hr", "")))

        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("INSERT INTO AuctionItems (AdminID, ItemName, Description, StartingPrice, AuctionStart, AuctionEnd, Category, ItemPicture) VALUES (@AdminID, @ItemName, @Description, @StartingPrice, @AuctionStart, @AuctionEnd, @Category, @ItemPicture)", connection)
            command.Parameters.AddWithValue("@AdminID", 8)
            command.Parameters.AddWithValue("@ItemName", itemNameValue)
            command.Parameters.AddWithValue("@Description", descriptionValue)
            command.Parameters.AddWithValue("@StartingPrice", startingPriceValue)
            command.Parameters.AddWithValue("@AuctionStart", createdTime.TimeOfDay)
            command.Parameters.AddWithValue("@AuctionEnd", endingTime.TimeOfDay)
            command.Parameters.AddWithValue("@Category", addcategory.Text)
            command.Parameters.AddWithValue("@ItemPicture", imagePath)
            command.ExecuteNonQuery()
        End Using

        MessageBox.Show("Item added successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ClearFields()
    End Sub


    Private Sub ClearFields()
        additemname.Clear()
        RichtextIdemdesc.Clear()
        addstartingPrice.Clear()
        addcategory.Clear()
        addendingTime.Clear()
        picIMAGE.Image = Nothing
        starter.Text = String.Empty
        ender.Text = String.Empty
        itemName.Text = String.Empty
        itemCAT.Text = String.Empty
        startingNC.Text = String.Empty
    End Sub


End Class
