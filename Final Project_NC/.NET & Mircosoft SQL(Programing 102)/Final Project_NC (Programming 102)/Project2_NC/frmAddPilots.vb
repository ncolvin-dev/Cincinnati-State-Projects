Public Class frmAddPilots
    Private Sub btnUpdateCustomer_Click(sender As Object, e As EventArgs) Handles btnUpdateCustomer.Click
        Dim strFirstName As String
        Dim strLastName As String
        Dim intPilotRole As Integer
        Dim strEmployeeID As String
        Dim dtmDateofHire As Date
        Dim dtmDateofTermination As Date
        Dim dtmDateofLicense As Date
        Dim strLoginID As String
        Dim strPassword As String
        Dim blnValidated As Boolean = True
        Dim intRowsAffected As Integer
        Dim intRowsAffectedEmployee As Integer
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim cmdInsert As New OleDb.OleDbCommand
        Dim intNextPrimaryKey As Integer
        Dim intNextPrimaryKeyEmployee As Integer

        Call Get_Validate_Input(strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateofLicense, intPilotRole, strLoginID, strPassword, blnValidated)
        If blnValidated = True Then
            Try

                ' validate data is entered




                If OpenDatabaseConnectionSQLServer() = False Then

                    ' No, warn the user ...
                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                        "The application will now close.",
                                        Me.Text + " Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ' and close the form/application
                    Me.Close()

                End If

                strSelect = "SELECT MAX(intPilotID) + 1 AS intNextPrimaryKey " &
                        " FROM TPilots"
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

                cmdInsert.CommandText = "EXECUTE uspAddPilot '" & intNextPrimaryKey & "','" & strFirstName & "','" & strLastName & "','" & strEmployeeID & "','" & dtmDateofHire & "','" & dtmDateofTermination & "','" & dtmDateofLicense & "','" & intPilotRole & "'"
                cmdInsert.CommandType = CommandType.StoredProcedure

                'MessageBox.Show(cmdInsert.CommandText)

                ' use insert command with sql string and connection object
                cmdInsert = New OleDb.OleDbCommand(cmdInsert.CommandText, m_conAdministrator)

                ' execute query to insert data
                intRowsAffected = cmdInsert.ExecuteNonQuery()

                strSelect = "SELECT MAX(intEmployeeTableID) + 1 AS intNextPrimaryKey " &
                        " FROM TEmployees"
                ' Execute command
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                ' Read result( highest ID )
                drSourceTable.Read()

                ' Null? (empty table)
                If drSourceTable.IsDBNull(0) = True Then

                    ' Yes, start numbering at 1
                    intNextPrimaryKeyEmployee = 1

                Else

                    ' No, get the next highest ID
                    intNextPrimaryKeyEmployee = CInt(drSourceTable("intNextPrimaryKey"))
                End If


                cmdInsert.CommandText = "EXECUTE uspAddEmployee '" & intNextPrimaryKeyEmployee & "','" & strLoginID & "','" & strPassword & "','" & "Pilot" & "','" & intNextPrimaryKey & "'"
                cmdInsert.CommandType = CommandType.StoredProcedure

                cmdInsert = New OleDb.OleDbCommand(cmdInsert.CommandText, m_conAdministrator)

                intRowsAffectedEmployee = cmdInsert.ExecuteNonQuery()

                MessageBox.Show(cmdInsert.CommandText)

                If intRowsAffected And intRowsAffectedEmployee > 0 Then
                    MessageBox.Show("Pilot has been added")    ' let user know success
                    ' close new player form
                End If

                CloseDatabaseConnection()       ' close connection if insert didn't work
                drSourceTable.Close()
                Close()



            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
    Private Sub Get_Validate_Input(ByRef strFirstName As String, ByRef strLastName As String, ByRef strEmployeeID As String, ByRef dtmDateofHire As Date, ByRef dtmDateofTermination As Date, ByRef dtmDateofLicense As Date, ByRef intPilotRole As Integer, ByRef strLoginID As String, ByRef strPassword As String, ByRef blnValidated As Boolean)
        Call Get_Vaildate_FirstName(strFirstName, blnValidated)
        If blnValidated = True Then
            Call Get_Vaildate_LastName(strLastName, blnValidated)
        End If
        If blnValidated = True Then
            Call Get_Role(intPilotRole)
        End If
        If blnValidated = True Then
            Call Get_Date_Of_Hire(dtmDateofHire)
        End If
        If blnValidated = True Then
            Call Get_Date_Of_Termination(dtmDateofTermination)
        End If
        If blnValidated = True Then
            Call Get_Date_Of_License(dtmDateofLicense)
        End If
        If blnValidated = True Then
            Call Get_Vaildate_EmployeeID(strEmployeeID, blnValidated)
        End If

        If blnValidated = True Then
            Call Get_Vaildate_LoginID(strLoginID, blnValidated)
        End If

        If blnValidated = True Then
            Call Get_Vaildate_Password(strPassword, blnValidated)
        End If
    End Sub
    Private Sub Get_Vaildate_FirstName(ByRef strFirstName As String, ByRef blnValidated As Boolean)
        If txtFirstName.Text = "" Then
            txtFirstName.Focus()
            MessageBox.Show("Please Enter your first name")
            blnValidated = False
        Else
            strFirstName = txtFirstName.Text
        End If
    End Sub
    Private Sub Get_Vaildate_LastName(ByRef strLastName As String, ByRef blnValidated As Boolean)
        If txtLastName.Text = "" Then
            txtLastName.Focus()
            MessageBox.Show("Please Enter your last name")
            blnValidated = False
        Else
            strLastName = txtLastName.Text
        End If
    End Sub


    Private Sub Get_Role(ByRef intPilotRole As Integer)
        If radCaptain.Checked = True Then
            intPilotRole = 2
        Else
            intPilotRole = 1
        End If
    End Sub

    Private Sub Get_Date_Of_Hire(ByRef dtmDateofHire As String)
        dtmDateofHire = dteDateHired.Value
    End Sub

    Private Sub Get_Date_Of_Termination(ByRef dtmDateofTermination As String)
        dtmDateofTermination = dteDateOfTermination.Value
    End Sub

    Private Sub Get_Date_Of_License(ByRef dtmDateofLicense As String)
        dtmDateofLicense = dteDateOfLicense.Value
    End Sub


    Private Sub Get_Vaildate_EmployeeID(ByRef strEmployeeID As String, ByRef blnValidated As Boolean)
        If txtEmployeeID.Text = "" Then
            txtEmployeeID.Focus()
            MessageBox.Show("Please Enter your employee ID")
            blnValidated = False
        Else
            strEmployeeID = txtEmployeeID.Text
        End If
    End Sub


    Private Sub Get_Vaildate_LoginID(ByRef strLoginID As String, ByRef blnValidated As Boolean)
        If txtLoginID.Text = "" Then
            txtLoginID.Focus()
            MessageBox.Show("Please Enter A Login ID")
            blnValidated = False
        Else
            strLoginID = txtLoginID.Text
        End If
    End Sub


    Private Sub Get_Vaildate_Password(ByRef strPassword As String, ByRef blnValidated As Boolean)
        If txtPassword.Text = "" Then
            txtPassword.Focus()
            MessageBox.Show("Please Enter A Password")
            blnValidated = False
        Else
            strPassword = txtPassword.Text
        End If
    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class