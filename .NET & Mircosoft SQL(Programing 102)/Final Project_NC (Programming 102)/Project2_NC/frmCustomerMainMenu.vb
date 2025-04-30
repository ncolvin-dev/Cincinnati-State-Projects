Public Class frmCustomerMainMenu
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnUpdateProfileCustomer_Click(sender As Object, e As EventArgs) Handles btnUpdateProfileCustomer.Click
        Dim showUpdateProfileCustomer As New frmUpdateCustomerProfile
        Me.Hide()
        showUpdateProfileCustomer.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnAddFlight_Click(sender As Object, e As EventArgs) Handles btnAddFlight.Click
        Dim ShowBookFlight As New frmBookFlight
        Me.Hide()
        ShowBookFlight.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnShowPastFlights_Click(sender As Object, e As EventArgs) Handles btnShowPastFlights.Click
        Dim ShowPastFlights As New frmPastFlightsCustomers
        Me.Hide()
        ShowPastFlights.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnShowFutureFlights_Click(sender As Object, e As EventArgs) Handles btnShowFutureFlights.Click
        Dim ShowFutureFlights As New frmFutureFlightsCustomers
        Me.Hide()
        ShowFutureFlights.ShowDialog()
        Me.Show()
    End Sub
End Class