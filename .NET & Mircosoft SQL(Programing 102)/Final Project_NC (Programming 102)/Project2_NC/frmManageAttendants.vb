Public Class frmManageAttendants
    Private Sub btnUpdateProfileCustomer_Click(sender As Object, e As EventArgs) Handles btnUpdateProfileCustomer.Click
        Dim ShowfrmAddAttendant As New frmAddAttendant

        Me.Hide()
        ShowfrmAddAttendant.ShowDialog()
        Me.Show()

    End Sub

    Private Sub btnAddFlight_Click(sender As Object, e As EventArgs) Handles btnAddFlight.Click
        Dim ShowfrmDeleteAttendant As New frmDeleteAttendant

        Me.Hide()
        ShowfrmDeleteAttendant.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnShowPastFlights_Click(sender As Object, e As EventArgs) Handles btnShowPastFlights.Click
        Dim ShowfrmAssignAttendantFutureFlight As New frmAssignAttendantFutureFlight

        Me.Hide()
        ShowfrmAssignAttendantFutureFlight.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class