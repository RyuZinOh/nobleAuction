Public Class AdminPanel
    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub customerManagement_Click(sender As Object, e As EventArgs) Handles customerManagement.Click
        Dim customerManagerForm As New CustomerManager()
        customerManagerForm.TopLevel = False
        customerManagerForm.FormBorderStyle = FormBorderStyle.None
        customerManagerForm.Dock = DockStyle.Fill

        SplitContainer1.Panel2.Controls.Clear()
        SplitContainer1.Panel2.Controls.Add(customerManagerForm)
        customerManagerForm.Show()
    End Sub
End Class
