Public Class frmAssignPilotFutureFlight
    Private Sub frmAddPilotstoFutureFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dtp As DataTable = New DataTable ' this is the table we will load from our reader
        Dim dtf As DataTable = New DataTable
        Try

            ' open the DB this is in module
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
            strSelect = "SELECT intPilotID, strFirstName + ' ' + strLastName as PilotName FROM TPilots"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtp.Load(drSourceTable)

            cboPilots.ValueMember = "intPilotID"
            cboPilots.DisplayMember = "PilotName"
            cboPilots.DataSource = dtp

            strSelect = "SELECT intFlightID, strFlightNumber FROM TFlights WHERE dtmFlightDate > GETDATE() "

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtf.Load(drSourceTable)

            cboFlights.ValueMember = "intFlightID"
            cboFlights.DisplayMember = "strFlightNumber"
            cboFlights.DataSource = dtf

            ' Select the first item in the list by default
            If cboPilots.Items.Count > 0 Then
                cboPilots.SelectedIndex = 0
                cboFlights.SelectedIndex = 0
            End If

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strSelect As String
        Dim intFlightID As Integer
        Dim cmdSelect As OleDb.OleDbCommand ' select command object
        Dim cmdInsert As New OleDb.OleDbCommand ' insert command object
        Dim drSourceTable As OleDb.OleDbDataReader ' data reader for pulling info
        Dim intNextPrimaryKey As Integer ' holds next highest PK value
        Dim intRowsAffected As Integer  ' how many rows were affected when sql executed
        Dim result As New Object
        Try

            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                        "The application will now close.",
                                        Me.Text + " Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            strSelect = "SELECT intPilotID FROM TPilots"
            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()
            intPilotID = drSourceTable("intPilotID")

            result = MessageBox.Show("Are you sure you want to assign pilot to flight: " & cboFlights.Text & "?", "Confirm Flight", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow deletion
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes

                    intFlightID = cboFlights.SelectedValue

                    strSelect = "SELECT MAX(intPilotFlightID) + 1 AS intNextPrimaryKey  FROM TPilotFlights"
                    ' Execute command
                    cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                    drSourceTable = cmdSelect.ExecuteReader

                    ' Read result( highest ID )
                    drSourceTable.Read()

                    ' Null? (empty table)
                    If drSourceTable.IsDBNull(0) = True Then

                        ' Yes, start numbering at 1
                        intNextPrimaryKey = 1

                    Else

                        ' No, get the next highest ID
                        intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))
                    End If

                    'MessageBox.Show(strInsert)
                    cmdInsert.CommandText = "EXECUTE uspAssignPilotFlight '" & intNextPrimaryKey & "','" & cboPilots.SelectedValue & "','" & intFlightID & "'"
                    cmdInsert.CommandType = CommandType.StoredProcedure

                    MessageBox.Show(cmdInsert.CommandText)
                    ' use insert command with sql string and connection object
                    cmdInsert = New OleDb.OleDbCommand(cmdInsert.CommandText, m_conAdministrator)

                    ' execute query to insert data
                    intRowsAffected = cmdInsert.ExecuteNonQuery()

                    ' If not 0 insert successful
                    If intRowsAffected > 0 Then
                        MessageBox.Show("Pilot has been added to flight")    ' let user know success
                        ' close new player form
                    End If


                    CloseDatabaseConnection()       ' close connection if insert didn't work
                    drSourceTable.Close()


            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class