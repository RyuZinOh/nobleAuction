Imports System.Drawing.Drawing2D

Public Class usersDashboard
    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)
        UpdateRegion()
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
End Class
