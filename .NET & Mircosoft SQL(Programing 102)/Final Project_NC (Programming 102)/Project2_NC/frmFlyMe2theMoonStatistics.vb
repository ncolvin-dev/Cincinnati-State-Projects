Public Class frmFlyMe2theMoonStatistics
    Private Sub frmFlyMe2theMoonStatistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim objParam As OleDb.OleDbParameter
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
            Dim dt As DataTable = New DataTable            ' this is the table we will load from our reader


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



            cmdSelect = New OleDb.OleDbCommand("uspCustomerCount", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure


            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()
            lblTotalNumberOfCustomers.Text = drSourceTable("TotalCustomerCount")

            ' Build the select statement
            strSelect = "SELECT COUNT(intFlightPassengerID) as TotalFlightsTaken FROM TFlightPassengers"


            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()
            lblTotalFlights.Text = drSourceTable("TotalFlightsTaken")

            ' Build the select statement
            strSelect = "SELECT AVG(intMilesFlown) as AverageMilesFlown FROM TFlightPassengers JOIN TFlights ON TFlightPassengers.intFlightID = TFlights.intFlightID"


            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()
            lblAverageMilesFlown.Text = drSourceTable("AverageMilesFlown")

            ' Retrieve all the records 

            cmdSelect = New OleDb.OleDbCommand("uspTotalMilesFlownPilots", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            lstTotalMilesFlownPilots.Items.Add("Total Miles Flown For Each Pilot:")
            lstTotalMilesFlownPilots.Items.Add("=======================================")

            While drSourceTable.Read()

                lstTotalMilesFlownPilots.Items.Add("  ")

                lstTotalMilesFlownPilots.Items.Add("First Name: " & vbTab & drSourceTable("strFirstName"))
                lstTotalMilesFlownPilots.Items.Add("Last Name: " & vbTab & drSourceTable("strLastName"))
                lstTotalMilesFlownPilots.Items.Add("Total Miles Flown: " & vbTab & drSourceTable("TotalMilesFlownForEachPilot"))

                lstTotalMilesFlownPilots.Items.Add("  ")
                lstTotalMilesFlownPilots.Items.Add("=============================")

            End While

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            ' Build the select statement

            cmdSelect = New OleDb.OleDbCommand("uspTotalMilesFlownAttendants", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            lstTotalMilesFlownAttendants.Items.Add("Total Miles Flown For Each Attendant:")
            lstTotalMilesFlownAttendants.Items.Add("=======================================")

            While drSourceTable.Read()

                lstTotalMilesFlownAttendants.Items.Add("  ")

                lstTotalMilesFlownAttendants.Items.Add("First Name: " & vbTab & drSourceTable("strFirstName"))
                lstTotalMilesFlownAttendants.Items.Add("Last Name: " & vbTab & drSourceTable("strLastName"))
                lstTotalMilesFlownAttendants.Items.Add("Total Miles Flown: " & vbTab & drSourceTable("TotalMilesFlownForEachAttendant"))

                lstTotalMilesFlownAttendants.Items.Add("  ")
                lstTotalMilesFlownAttendants.Items.Add("=============================")

            End While


            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class