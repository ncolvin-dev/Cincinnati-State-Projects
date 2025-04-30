Public Class frmManagePilots
    Private Sub btnUpdateProfileCustomer_Click(sender As Object, e As EventArgs) Handles btnUpdateProfileCustomer.Click
        Dim ShowfrmAddPilots As New frmAddPilots

        Me.Hide()
        ShowfrmAddPilots.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnAddFlight_Click(sender As Object, e As EventArgs) Handles btnAddFlight.Click
        Dim ShowfrmDeletePilots As New frmDeletePilots

        Me.Hide()
        ShowfrmDeletePilots.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnShowPastFlights_Click(sender As Object, e As EventArgs) Handles btnShowPastFlights.Click
        Dim ShowfrmAddPilotsToFutureFlights As New frmAssignPilotFutureFlight

        Me.Hide()
        ShowfrmAddPilotsToFutureFlights.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class