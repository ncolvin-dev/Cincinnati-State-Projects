Public Class frmFutureFlights

    Private Sub frmFutureFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' select command object
        Dim cmdInsert As New OleDb.OleDbCommand ' insert command object
        Dim drSourceTable As OleDb.OleDbDataReader ' data reader for pulling info
        Dim dtp As DataTable = New DataTable
        Dim dtt As DataTable = New DataTable
        Dim dtf As DataTable = New DataTable

        Try
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
            strSelect = "SELECT intPlaneTypeID, strPlaneType FROM TPlaneTypes"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

            drSourceTable = cmdSelect.ExecuteReader
            dtp.Load(drSourceTable)


            cboPlane.ValueMember = "intPlaneTypeID"
            cboPlane.DisplayMember = "strPlaneType"
            cboPlane.DataSource = dtp


            strSelect = "SELECT intAirportID, strAirportCity FROM TAirports"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

            drSourceTable = cmdSelect.ExecuteReader
            dtt.Load(drSourceTable)


            cboToAirport.ValueMember = "intAirportID"
            cboToAirport.DisplayMember = "strAirportCity"
            cboToAirport.DataSource = dtt


            strSelect = "SELECT intAirportID, strAirportCity FROM TAirports"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

            drSourceTable = cmdSelect.ExecuteReader
            dtf.Load(drSourceTable)


            cboFromAirport.ValueMember = "intAirportID"
            cboFromAirport.DisplayMember = "strAirportCity"
            cboFromAirport.DataSource = dtf





            CloseDatabaseConnection()       ' close connection if insert didn't work
            drSourceTable.Close()



        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnUpdateCustomer_Click(sender As Object, e As EventArgs) Handles btnAddFlight.Click
        Dim strSelect As String
        Dim strFlightNumber As String
        Dim FlightDate As Date
        Dim ExpectedTimeOfDepature As Date
        Dim ExpectedTimeOfLanding As Date
        Dim intToAirport As Integer
        Dim intFromAirport As Integer
        Dim intExpectedMilesFlown As Integer
        Dim intSelectPlane As Integer
        Dim cmdSelect As OleDb.OleDbCommand ' select command object
        Dim cmdInsert As New OleDb.OleDbCommand ' insert command object
        Dim drSourceTable As OleDb.OleDbDataReader ' data reader for pulling info
        Dim blnValidated As Boolean = True
        Dim intRowsAffected As Integer  ' how many rows were affected when sql executed
        Dim intNextPrimaryKey As Integer

        Dim result As New Object



        Call Get_Validate_Input(strFlightNumber, FlightDate, ExpectedTimeOfDepature, ExpectedTimeOfLanding, intToAirport, intFromAirport, intExpectedMilesFlown, intSelectPlane, blnValidated)
        If blnValidated = True Then




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

                intSelectPlane = cboPlane.SelectedValue
                intToAirport = cboToAirport.SelectedValue
                intFromAirport = cboFromAirport.SelectedValue

                strSelect = "SELECT MAX(intFlightID) + 1 AS intNextPrimaryKey " &
                        " FROM TFlights"
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



                cmdInsert.CommandText = "EXECUTE uspAddFutureFlight '" & intNextPrimaryKey & "','" & FlightDate & "','" & strFlightNumber & "','" & ExpectedTimeOfDepature & "','" & ExpectedTimeOfLanding & "','" & intToAirport & "','" & intFromAirport & "','" & intExpectedMilesFlown & "','" & intSelectPlane & "'"
                cmdInsert.CommandType = CommandType.StoredProcedure

                MessageBox.Show(cmdInsert.CommandText)

                cmdInsert = New OleDb.OleDbCommand(cmdInsert.CommandText, m_conAdministrator)

                intRowsAffected = cmdInsert.ExecuteNonQuery()

                If intRowsAffected = 1 Then
                    MessageBox.Show("Flight Added")
                Else
                    MessageBox.Show("Flight Failed")
                End If




                CloseDatabaseConnection()       ' close connection if insert didn't work
                Close()


            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub



    Private Sub Get_Validate_Input(ByRef strFlightNumber As String, ByRef FlightDate As Date, ByRef ExpectedTimeOfDepature As Date, ByRef ExpectedTimeOfLanding As Date, ByRef intToAirport As Integer, ByRef intFromAirport As Integer, ByRef intExpectedMilesFlown As Integer, ByRef intSelectPlane As Integer, ByRef blnValidated As Boolean)
        Call Get_Vaildate_FlightNumber(strFlightNumber, blnValidated)
        If blnValidated = True Then
            Call Get_Vaildate_FlightDate(FlightDate, blnValidated)
        End If
        'If blnValidated = True Then
        '    Call Get_Validate_ExpectedTimeOfDeparture(ExpectedTimeOfDepature, blnValidated)
        'End If
        'If blnValidated = True Then
        '    Call Get_Validate_ExpectedTimeOfLanding(ExpectedTimeOfLanding, blnValidated)
        'End If
        If blnValidated = True Then
            Call Get_Vaildate_intExpectedMilesFlown(intExpectedMilesFlown, blnValidated)
        End If

        If blnValidated = True Then
            Call Get_Vaildate_intToAirportAndintFromAirport(intToAirport, intFromAirport, blnValidated)
        End If

    End Sub

    Private Sub Get_Vaildate_FlightNumber(ByRef strFlightNumber As String, ByRef blnValidated As Boolean)
        If txtFlightNumber.Text = "" Then
            txtFlightNumber.Focus()
            MessageBox.Show("Please Enter A Flight Number")
            blnValidated = False
        Else
            strFlightNumber = txtFlightNumber.Text
        End If
    End Sub

    Private Sub Get_Vaildate_FlightDate(ByRef FlightDate As String, ByRef blnValidated As Boolean)
        If dtmFlightDate.Value > DateTime.Now Then
            FlightDate = dtmFlightDate.Value
        Else
            blnValidated = False
            MessageBox.Show("Please Enter A Future Date")
        End If
    End Sub

    Private Sub Get_Validate_ExpectedTimeOfDeparture(ByRef ExpectedTimeOfDepature As String, ByRef blnValidated As Boolean)

        If dtmTimeOfDeparture.Value < dtmTimeOfLanding.Value Then
            ExpectedTimeOfDepature = dtmTimeOfDeparture.Value
        Else
            blnValidated = False
            MessageBox.Show("Please Enter A Time Less Than Time Of Landing")
        End If
    End Sub

    Private Sub Get_Validate_ExpectedTimeOfLanding(ByRef ExpectedTimeOfLanding As String, ByRef blnValidated As Boolean)
        If dtmTimeOfLanding.Value > dtmTimeOfDeparture.Value Then
            ExpectedTimeOfLanding = dtmTimeOfLanding.Value
        Else
            blnValidated = False
            MessageBox.Show("Please Enter A Time Greater Than Time Of Departure ")
        End If
    End Sub

    Private Sub Get_Vaildate_intExpectedMilesFlown(ByRef intExpectedMilesFlown As String, ByRef blnValidated As Boolean)
        If Integer.TryParse(txtMilesFlown.Text, intExpectedMilesFlown) Then
            If txtMilesFlown.Text = "" Then
                blnValidated = False
                txtMilesFlown.Focus()
                MessageBox.Show("Please Enter A Number for Miles Flown")
            Else
                intExpectedMilesFlown = txtMilesFlown.Text
            End If
        Else
            blnValidated = False
            MessageBox.Show("Must Be Nurmeric")
        End If
    End Sub

    Private Sub Get_Vaildate_intToAirportAndintFromAirport(ByRef intToAirport As Integer, ByRef intFromAirport As Integer, ByRef blnValidated As Boolean)
        If cboToAirport.SelectedValue = cboFromAirport.SelectedValue Then
            blnValidated = False
            MessageBox.Show("Flight can not land in the same airport that it departs from")
        Else
            intToAirport = cboToAirport.SelectedValue
            intFromAirport = cboFromAirport.SelectedValue
        End If
    End Sub

End Class