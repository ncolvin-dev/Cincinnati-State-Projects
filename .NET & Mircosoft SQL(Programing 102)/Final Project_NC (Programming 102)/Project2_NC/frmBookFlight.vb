Public Class frmBookFlight
    Dim dblFlightCostReservedSeat As Double
    Dim dblFlightCostNOReservedSeat As Double
    Private Sub frmBookFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        '  On the event Form Load, we are going to populate the combobox State from 
        '  the database
        '


        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable
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

            strSelect = "SELECT TF.intFlightID, strFlightNumber FROM TFlights as TF WHERE TF.dtmFlightDate > '2023'"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)


            'load the State result set into the combobox.  For VB, we do this by binding the data to the combobox


            cboFlights.ValueMember = "intFlightID"
            cboFlights.DisplayMember = "strFlightNumber"
            cboFlights.DataSource = dt
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim objParam As OleDb.OleDbParameter
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

            result = MessageBox.Show("Are you sure you want to book this flight: " & cboFlights.Text & "?", "Confirm Flight", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow deletion
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes


                    cmdSelect = New OleDb.OleDbCommand("uspSelectFlight", m_conAdministrator)
                    cmdSelect.CommandType = CommandType.StoredProcedure

                    objParam = cmdSelect.Parameters.Add("@Flight_ID", OleDb.OleDbType.Integer)
                    objParam.Direction = ParameterDirection.Input
                    objParam.Value = cboFlights.SelectedValue.ToString

                    drSourceTable = cmdSelect.ExecuteReader
                    drSourceTable.Read()
                    intFlightID = drSourceTable("intFlightID")



                    strSelect = "SELECT MAX(intFlightPassengerID) + 1 AS intNextPrimaryKey  FROM TFlightPassengers"
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
                    If radReserved.Checked Then
                        cmdInsert.CommandText = "EXECUTE uspBookFlight '" & intNextPrimaryKey & "','" & intFlightID & "','" & intCustomerID & "','" & "Reserved Seat" & "','" & dblFlightCostReservedSeat & "'"
                    Else
                        cmdInsert.CommandText = "EXECUTE uspBookFlight '" & intNextPrimaryKey & "','" & intFlightID & "','" & intCustomerID & "','" & "Designated Seat" & "','" & dblFlightCostNOReservedSeat & "'"
                    End If
                    cmdInsert.CommandType = CommandType.StoredProcedure

                        'MessageBox.Show(cmdInsert.CommandText)

                        ' use insert command with sql string and connection object
                        cmdInsert = New OleDb.OleDbCommand(cmdInsert.CommandText, m_conAdministrator)

                    ' execute query to insert data
                    intRowsAffected = cmdInsert.ExecuteNonQuery()

                    ' If not 0 insert successful
                    If intRowsAffected > 0 Then
                        MessageBox.Show("Passenger has been added")    ' let user know success
                        ' close new player form
                    End If


                    CloseDatabaseConnection()       ' close connection if insert didn't work
                    drSourceTable.Close()
                    Close()

            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub cboFlights_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFlights.SelectedIndexChanged

        Dim intPassengerCount As Integer
        Dim strPlaneType As String
        Dim intPassengerAge As Integer
        Dim intFlightCount As Integer
        Dim intMilesFlown As Integer

        '
        '  On the event Form Load, we are going to populate the combobox State from 
        '  the database
        '


        Try

            Dim strSelect As String = ""
            Dim cmdSelect As New OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable
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

            cmdSelect.CommandText = "EXECUTE uspTotalPassengersOnFlight  " & intCustomerID
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect = New OleDb.OleDbCommand(cmdSelect.CommandText, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            intPassengerCount = drSourceTable("TotalPassengersOnFlight")


            cmdSelect.CommandText = "EXECUTE uspPlaneUsedOnFlight " & cboFlights.SelectedValue
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect = New OleDb.OleDbCommand(cmdSelect.CommandText, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            strPlaneType = drSourceTable("strPlaneType")

            cmdSelect.CommandText = "EXECUTE uspPassengerAge " & intCustomerID
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect = New OleDb.OleDbCommand(cmdSelect.CommandText, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            intPassengerAge = drSourceTable("Age")

            cmdSelect.CommandText = "EXECUTE uspPassengerPreviousFlights " & intCustomerID
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect = New OleDb.OleDbCommand(cmdSelect.CommandText, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            intFlightCount = drSourceTable("TotaFlights")

            strSelect = "SELECT intMilesFlown FROM TFlights as TF WHERE intFlightID = " & cboFlights.SelectedValue
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            intMilesFlown = drSourceTable("intMilesFlown")

            drSourceTable.Close()
            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try

        dblFlightCostReservedSeat = 375
        dblFlightCostNOReservedSeat = 250

        If intMilesFlown > 750 Then
            dblFlightCostReservedSeat += 50
            dblFlightCostNOReservedSeat += 50
        End If

        If intPassengerCount > 8 Then
            dblFlightCostReservedSeat += 100
            dblFlightCostNOReservedSeat += 100
        ElseIf intPassengerCount < 4 Then
            dblFlightCostReservedSeat -= 50
            dblFlightCostNOReservedSeat -= 50
        End If

        If strPlaneType = "Airbus A350" Then
            dblFlightCostReservedSeat += 35
            dblFlightCostNOReservedSeat += 35
        ElseIf strPlaneType = "Boeing 747-8" Then
            dblFlightCostReservedSeat -= 25
            dblFlightCostNOReservedSeat -= 25
        End If

        If intPassengerAge > 65 Then
            dblFlightCostReservedSeat -= (dblFlightCostReservedSeat * 0.25)
            dblFlightCostNOReservedSeat -= (dblFlightCostNOReservedSeat * 0.25)
        ElseIf intPassengerAge <= 5 Then
            dblFlightCostReservedSeat -= (dblFlightCostReservedSeat * 0.65)
            dblFlightCostNOReservedSeat -= (dblFlightCostNOReservedSeat * 0.65)
        End If

        If intFlightCount >= 10 Then
            dblFlightCostReservedSeat -= (dblFlightCostReservedSeat * 0.2)
            dblFlightCostNOReservedSeat -= (dblFlightCostNOReservedSeat * 0.2)
        ElseIf intFlightCount >= 5 Then
            dblFlightCostReservedSeat -= (dblFlightCostReservedSeat * 0.1)
            dblFlightCostNOReservedSeat -= (dblFlightCostNOReservedSeat * 0.1)
        End If

        lblDesignatedSeat.Text = "Total Cost:  " & dblFlightCostNOReservedSeat.ToString("C")
        lblReservedSeat.Text = "Total Cost:  " & dblFlightCostReservedSeat.ToString("C")

        radDesignatedSeat.Show()
        radReserved.Show()
        lblReservedSeat.Show()
        lblDesignatedSeat.Show()
    End Sub
End Class