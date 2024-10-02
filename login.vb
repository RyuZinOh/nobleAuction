Public Class login
    '========
    'Flag to track password visibility
    '========
    Private isPasswordVisible As Boolean = False
    '========
    'Flag to track dragging status
    '========
    Private isDragging As Boolean = False
    Private startPoint As Point

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '========
        'Set initial placeholder and style
        '========
        SetPlaceholder(usernameBox, "Enter Username")
        SetPlaceholder(passwordBox, "Enter Password", False)

        '========
        'Set the default image for pass_toggler (show password icon)
        '========
        pass_toggler.Image = My.Resources.pass_hide

        '========
        'Center the form on the screen when it loads
        '========
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub usernameBox_Enter(sender As Object, e As EventArgs) Handles usernameBox.Enter
        '========
        'Remove username placeholder on focus
        '========
        RemovePlaceholder(usernameBox, "Enter Username")
    End Sub

    Private Sub usernameBox_Leave(sender As Object, e As EventArgs) Handles usernameBox.Leave
        '========
        'Set username placeholder when leaving the field if empty
        '========
        SetPlaceholder(usernameBox, "Enter Username")
    End Sub

    Private Sub password_Enter(sender As Object, e As EventArgs) Handles passwordBox.Enter
        '========
        'Remove password placeholder on focus
        '========
        RemovePlaceholder(passwordBox, "Enter Password")
    End Sub

    Private Sub password_Leave(sender As Object, e As EventArgs) Handles passwordBox.Leave
        '========
        'Set password placeholder when leaving the field if empty
        '========
        SetPlaceholder(passwordBox, "Enter Password", False)
    End Sub

    Private Sub pass_toggler_Click(sender As Object, e As EventArgs) Handles pass_toggler.Click
        '========
        'Toggle password visibility and update the icon
        '========
        isPasswordVisible = Not isPasswordVisible
        passwordBox.UseSystemPasswordChar = Not isPasswordVisible
        pass_toggler.Image = If(isPasswordVisible, My.Resources.pass_hide, My.Resources.pass_show)
    End Sub

    '========
    'Helper to set the placeholder
    '========
    Private Sub SetPlaceholder(textBox As TextBox, placeholder As String, Optional isPassword As Boolean = True)
        If String.IsNullOrWhiteSpace(textBox.Text) Then
            textBox.Text = placeholder
            textBox.ForeColor = Color.Gray
            If isPassword Then textBox.UseSystemPasswordChar = False
        End If
    End Sub

    '========
    'Helper to remove the placeholder
    '========
    Private Sub RemovePlaceholder(textBox As TextBox, placeholder As String)
        If textBox.Text = placeholder Then
            textBox.Text = ""
            textBox.ForeColor = Color.White
            If textBox Is passwordBox Then textBox.UseSystemPasswordChar = True
        End If
    End Sub

    '========
    'Handle application exit on exitLogin click
    '========
    Private Sub exitLogin_Click(sender As Object, e As EventArgs) Handles exitLogin.Click
        Application.Exit()
    End Sub

    '========
    'Make the form draggable (click and drag anywhere)
    '========
    Private Sub login_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            isDragging = True
            startPoint = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub login_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If isDragging Then
            Dim newPosition As Point = Me.PointToScreen(New Point(e.X, e.Y))
            Me.Location = New Point(newPosition.X - startPoint.X, newPosition.Y - startPoint.Y)
        End If
    End Sub

    Private Sub login_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        isDragging = False
    End Sub

    Private Sub signupPortal_Click(sender As Object, e As EventArgs) Handles signupPortal.Click
        Me.Hide()
        signup.Show()
    End Sub
End Class
