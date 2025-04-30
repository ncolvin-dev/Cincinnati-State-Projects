Public Class frmSelectCustomer

    Private Sub frmCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader for Pasengers

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

            strSelect = "SELECT intPassengerID, strFirstName + ' ' + strLastName as PassengerName FROM TPassengers"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)


            'load the result set into the combobox.  For VB, we do this by binding the data to the combobox


            cboCustomers.ValueMember = "intPassengerID"
            cboCustomers.DisplayMember = "PassengerName"
            cboCustomers.DataSource = dt

            If cboCustomers.Items.Count < 0 Then
                cboCustomers.SelectedIndex = 0
            End If

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnAddPassenger_Click(sender As Object, e As EventArgs) Handles btnAddPassenger.Click
        Dim frmAddCustomer As New frmAddCustomers
        Me.Hide()
        frmAddCustomer.ShowDialog()
        frmCustomer_Load(sender, e)
        Me.Show()
    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSelectCustomer.Click
        Dim frmCustomerOptions As New frmCustomerMainMenu

        Try
            Dim objParam As OleDb.OleDbParameter
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader for Pasengers

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

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand("uspSelectCustomer", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@PassengerID", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = cboCustomers.SelectedValue.ToString

            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            intCustomerID = drSourceTable("intPassengerID")
            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try

        Me.Hide()
        frmCustomerOptions.ShowDialog()
        Me.Show()
    End Sub
End Class