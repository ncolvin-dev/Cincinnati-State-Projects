Public Class frmPassengerLogin
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click


        Try
            Dim ShowfrmCustomerMainMenu As New frmCustomerMainMenu
            Dim blnPassword As Boolean
            Dim blnLoginID As Boolean
            Dim strLoginID As String
            Dim strPassword As String
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dts As DataTable = New DataTable ' this is the table we will load from our reader for State
            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            strPassword = txtPassword.Text
            strLoginID = txtID.Text

            strSelect = "SELECT intPassengerID, strLoginID, strPassword FROM TPassengers"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

            drSourceTable = cmdSelect.ExecuteReader

            Do While drSourceTable.Read
                If drSourceTable("strLoginID") = strLoginID Then
                    blnLoginID = True

                End If
                If drSourceTable("strPassword") = strPassword Then
                    blnPassword = True
                    intCustomerID = drSourceTable("intPassengerID")
                End If
            Loop

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

            If blnPassword = True And blnLoginID = True Then
                Me.Hide()
                ShowfrmCustomerMainMenu.ShowDialog()
                Me.Show()
            Else
                MessageBox.Show(“Password or ID Invalid”)
            End If
        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub btnNewPassenger_Click(sender As Object, e As EventArgs) Handles btnNewPassenger.Click
        Dim ShowfrmAddCustomer As New frmAddCustomers

        Me.Hide()
        ShowfrmAddCustomer.ShowDialog()
        Me.Show()
    End Sub
End Class