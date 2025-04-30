Public Class frmChooseUserLogin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnPassengerLogin.Click
        Dim ShowfrmPassengerLogin As New frmPassengerLogin

        ShowfrmPassengerLogin.ShowDialog()
    End Sub

    Private Sub btnEmployeeLogin_Click(sender As Object, e As EventArgs) Handles btnEmployeeLogin.Click
        Dim ShowfrmEmployeeLogin As New frmEmployeeLogin

        ShowfrmEmployeeLogin.ShowDialog()
    End Sub
End Class