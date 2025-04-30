Public Class frmAttendantMainMenu
    Private Sub btnUpdateProfileCustomer_Click(sender As Object, e As EventArgs) Handles btnUpdateProfileCustomer.Click
        Dim ShowfrmUpdateAttendantProfile As New frmUpdateAttendantProfile

        ShowfrmUpdateAttendantProfile.ShowDialog()

    End Sub

    Private Sub btnShowPastFlights_Click(sender As Object, e As EventArgs) Handles btnShowPastFlights.Click
        Dim ShowfrmPastFlightsAttendants As New frmPastFlightsAttendants

        ShowfrmPastFlightsAttendants.ShowDialog()

    End Sub

    Private Sub btnShowFutureFlights_Click(sender As Object, e As EventArgs) Handles btnShowFutureFlights.Click
        Dim ShowfrmFutureFlightsAttendants As New frmFutureFlightsAttendants

        ShowfrmFutureFlightsAttendants.ShowDialog()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class