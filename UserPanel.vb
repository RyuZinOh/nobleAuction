Public Class UserPanel

    Private Sub userDashboard_Click(sender As Object, e As EventArgs) Handles userDashboard.Click
        Dim customerManagerForm As New usersDashboard()

        customerManagerForm.TopLevel = False
        customerManagerForm.FormBorderStyle = FormBorderStyle.None
        customerManagerForm.Dock = DockStyle.Fill
        Panel1.Controls.Clear()
        Panel1.Controls.Add(customerManagerForm)
        customerManagerForm.Show()
    End Sub

    
    Private Sub UserPanel_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Panel1.Controls.Count > 0 Then
            Dim currentDashboard As usersDashboard = CType(Panel1.Controls(0), usersDashboard)
            currentDashboard.Size = Panel1.Size
            currentDashboard.Refresh()
        End If
    End Sub

End Class
