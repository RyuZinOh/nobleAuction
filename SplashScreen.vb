Imports System.Media

Public NotInheritable Class SplashScreen
    Private player As SoundPlayer
    Private currentLabelIndex As Integer = 0
    Private labelMessages As String() = {
        "Welcome to Noble's Auction!",
        "Loading, please wait...",
        "Preparing your experience...",
        "Almost there...",
        "Enjoy your time with us!"
    }
    Private labelChangeTimer As Timer

    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        player = New SoundPlayer(My.Resources.noblessOblique)
        player.Play()

        ' Start the label update immediately
        UpdateLabelText()

        labelChangeTimer = New Timer()
        labelChangeTimer.Interval = 700
        AddHandler labelChangeTimer.Tick, AddressOf ChangeLabelText
        labelChangeTimer.Start()

        Timer1.Start()
        Panel2.Height = 0
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Panel2.Height += 3

        If Panel2.Height >= 628 Then
            Timer1.Stop()
            player.Stop()
            labelChangeTimer.Stop()
            Me.Hide()
            login.Show()
        End If
    End Sub

    Private Sub ChangeLabelText()
        currentLabelIndex = (currentLabelIndex + 1) Mod labelMessages.Length
        Label1.Text = labelMessages(currentLabelIndex)
    End Sub

    Private Sub UpdateLabelText()
        Label1.Text = labelMessages(currentLabelIndex)
        Label1.ForeColor = Color.White

    End Sub
End Class
