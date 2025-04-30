Public Class frmPastFlightsPilots
    Private Sub frmPastFlightsPilots_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

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

            ' Build the select statement
            strSelect = "SELECT dtmFlightDate, strFlightNumber, dtmTimeofDeparture, dtmTimeOfLanding, intMilesFlown, strPlaneType " &
            "FROM TFlights as TF " &
            "JOIN TPilotFlights as TPF ON TF.intFlightID = TPF.intFlightID " &
            "JOIN TPlanes as TP ON TP.intPlaneID = TF.intPlaneID " &
            "JOIN TPlaneTypes as TPT ON TPT.intPlaneTypeID = TP.intPlaneTypeID " &
            "WHERE TPF.intPilotID = " & intPilotID & " AND TF.dtmFlightDate < GETDATE()"

            'MessageBox.Show(strSelect)

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            'loop through result set and display in Listbox

            lstResultSet.Items.Add("Past Flights")
            lstResultSet.Items.Add("=============================")

            While drSourceTable.Read()

                lstResultSet.Items.Add("  ")

                lstResultSet.Items.Add("Flight Number: " & vbTab & drSourceTable("strFlightNumber"))
                lstResultSet.Items.Add("Flight Date: " & vbTab & drSourceTable("dtmFlightDate"))
                lstResultSet.Items.Add("Time Of Departure: " & vbTab & drSourceTable("dtmTimeofDeparture"))
                lstResultSet.Items.Add("Time Of Landing: " & vbTab & drSourceTable("dtmTimeOfLanding"))
                lstResultSet.Items.Add("Miles Flown: " & vbTab & drSourceTable("intMilesFlown"))
                lstResultSet.Items.Add("Plane: " & vbTab & vbTab & drSourceTable("strPlaneType"))

                lstResultSet.Items.Add("  ")
                lstResultSet.Items.Add("=============================")

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