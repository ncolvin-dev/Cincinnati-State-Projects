Public Class frmAdminMainMenu
    Private Sub btnUpdateProfileCustomer_Click(sender As Object, e As EventArgs) Handles btnManagePilots.Click
        Dim ShowfrmManagePilots As New frmManagePilots

        Me.Hide()
        ShowfrmManagePilots.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnAddFlight_Click(sender As Object, e As EventArgs) Handles btnManageAttendants.Click
        Dim ShowfrmManagePilots As New frmManageAttendants
        Me.Hide()
        ShowfrmManagePilots.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnStatistics_Click(sender As Object, e As EventArgs) Handles btnStatistics.Click
        Dim ShowFlyme2theMoonStatistics As New frmFlyMe2theMoonStatistics
        ShowFlyme2theMoonStatistics.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ShowfrmFutureFlights As New frmFutureFlights
        Me.Hide()
        ShowfrmFutureFlights.ShowDialog()
        Me.Show()
    End Sub
End Class