Public Class frmPilotMainMenu
    Private Sub btnUpdateProfileCustomer_Click(sender As Object, e As EventArgs) Handles btnUpdateProfileCustomer.Click
        Dim ShowfrmUpdatePilotProfile As New frmUpdatePilotProfile
        Me.Hide()
        ShowfrmUpdatePilotProfile.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnShowPastFlights_Click(sender As Object, e As EventArgs) Handles btnShowPastFlights.Click
        Dim ShowfrmShowPastFlights As New frmPastFlightsPilots
        Me.Hide()
        ShowfrmShowPastFlights.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnShowFutureFlights_Click(sender As Object, e As EventArgs) Handles btnShowFutureFlights.Click
        Dim ShowfrmShowFutureFlights As New frmFutureFlightsPilots
        Me.Hide()
        ShowfrmShowFutureFlights.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class