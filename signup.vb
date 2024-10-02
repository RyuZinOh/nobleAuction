Public Class signup
    '========
    'Flag to track dragging status
    '========
    Private isDragging As Boolean = False
    Private startPoint As Point

    Private Sub signup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '========
        'Set initial placeholders for signup fields
        '========
        SetPlaceholder(addUsername, "Enter Username")
        SetPlaceholder(addEmail, "Enter Email")
        SetPlaceholder(addPass, "Enter Password", False)
        SetPlaceholder(confirmPass, "Confirm Password", False)

        '========
        'Center the form on the screen when it loads
        '========
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    '========
    'Navigate to login form
    '========
    Private Sub gotoLogin_Click(sender As Object, e As EventArgs) Handles gotoLogin.Click
        Me.Hide()
        login.Show()
    End Sub

    '========
    'Sign up button click handler with error checking
    '========
    Private Sub dosignUp_Click(sender As Object, e As EventArgs) Handles dosignUp.Click
        Dim errorMessage As String = ""

        '========
        'Check if fields are valid
        '========
        If String.IsNullOrWhiteSpace(addUsername.Text) OrElse addUsername.Text = "Enter Username" Then
            errorMessage = "Username is required."
        ElseIf Not IsValidEmail(addEmail.Text) Then
            errorMessage = "Please enter a valid email"
        ElseIf Not IsValidPassword(addPass.Text) Then
            errorMessage = "password standard doesnt meet"
        ElseIf addPass.Text <> confirmPass.Text Then
            errorMessage = "Passwords do not match."
        End If

        '========
        'Display the error message in the label, or clear it if no errors
        '========
        If errorMessage <> "" Then
            errorsignuphandler.Text = errorMessage
            errorsignuphandler.ForeColor = Color.Red
        Else
            errorsignuphandler.Text = "Signup successful!"
            errorsignuphandler.ForeColor = Color.Green
            ' Optionally proceed with form submission logic here
        End If
    End Sub

    '========
    'Username placeholder handling
    '========
    Private Sub addUsername_Enter(sender As Object, e As EventArgs) Handles addUsername.Enter
        RemovePlaceholder(addUsername, "Enter Username")
    End Sub

    Private Sub addUsername_Leave(sender As Object, e As EventArgs) Handles addUsername.Leave
        SetPlaceholder(addUsername, "Enter Username")
    End Sub

    '========
    'Email placeholder and validation
    '========
    Private Sub addEmail_Enter(sender As Object, e As EventArgs) Handles addEmail.Enter
        RemovePlaceholder(addEmail, "Enter Email")
    End Sub

    Private Sub addEmail_Leave(sender As Object, e As EventArgs) Handles addEmail.Leave
        SetPlaceholder(addEmail, "Enter Email")
    End Sub

    '========
    'Password placeholder handling (no hiding password)
    '========
    Private Sub addPass_Enter(sender As Object, e As EventArgs) Handles addPass.Enter
        RemovePlaceholder(addPass, "Enter Password")
    End Sub

    Private Sub addPass_Leave(sender As Object, e As EventArgs) Handles addPass.Leave
        SetPlaceholder(addPass, "Enter Password", False)
    End Sub

    '========
    'Confirm Password placeholder handling
    '========
    Private Sub confirmPass_Enter(sender As Object, e As EventArgs) Handles confirmPass.Enter
        RemovePlaceholder(confirmPass, "Confirm Password")
    End Sub

    Private Sub confirmPass_Leave(sender As Object, e As EventArgs) Handles confirmPass.Leave
        SetPlaceholder(confirmPass, "Confirm Password", False)
    End Sub

    '========
    'Helper to set placeholder text without hiding password
    '========
    Private Sub SetPlaceholder(textBox As TextBox, placeholder As String, Optional isPassword As Boolean = True)
        If String.IsNullOrWhiteSpace(textBox.Text) Then
            textBox.Text = placeholder
            textBox.ForeColor = Color.Gray
            ' Do not hide the password using UseSystemPasswordChar
        End If
    End Sub

    '========
    'Helper to remove placeholder text
    '========
    Private Sub RemovePlaceholder(textBox As TextBox, placeholder As String)
        If textBox.Text = placeholder Then
            textBox.Text = ""
            textBox.ForeColor = Color.White
        End If
    End Sub

    '========
    'Email validation logic
    '========
    Private Function IsValidEmail(email As String) As Boolean
        If email.EndsWith("@gmail.com") AndAlso email.Length > "@gmail.com".Length Then
            Return True
        End If
        Return False
    End Function

    '========
    'Password validation logic
    '========
    Private Function IsValidPassword(password As String) As Boolean
        Dim hasUpper As Boolean = password.Any(Function(c) Char.IsUpper(c))
        Dim hasLower As Boolean = password.Any(Function(c) Char.IsLower(c))
        Dim hasDigit As Boolean = password.Any(Function(c) Char.IsDigit(c))
        Dim hasSpecial As Boolean = password.Any(Function(c) Not Char.IsLetterOrDigit(c))
        Return password.Length >= 8 AndAlso hasUpper AndAlso hasLower AndAlso hasDigit AndAlso hasSpecial
    End Function

    '========
    'Make the form draggable (click and drag anywhere)
    '========
    Private Sub signup_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            isDragging = True
            startPoint = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub signup_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If isDragging Then
            Dim newPosition As Point = Me.PointToScreen(New Point(e.X, e.Y))
            Me.Location = New Point(newPosition.X - startPoint.X, newPosition.Y - startPoint.Y)
        End If
    End Sub

    Private Sub signup_MouseUp(sender As Object, e As EventArgs) Handles Me.MouseUp
        isDragging = False
    End Sub

    Private Sub exitLogin_Click(sender As Object, e As EventArgs) Handles exitLogin.Click
        Application.Exit()
    End Sub
End Class
