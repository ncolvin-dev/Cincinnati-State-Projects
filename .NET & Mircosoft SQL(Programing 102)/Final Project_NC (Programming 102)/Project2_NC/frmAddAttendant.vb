Public Class frmAddAttendant
    Private Sub btnAddAttendant_Click(sender As Object, e As EventArgs) Handles btnAddAttendant.Click
        ' variables for new player data and select and insert statements
        Dim strFirstName As String
        Dim strLastName As String
        Dim strEmployeeID As String
        Dim dtmDateofHire As Date
        Dim dtmDateofTermination As Date
        Dim blnValidated As Boolean = True
        Dim intRowsAffected As Integer
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim strInsert As String = ""
        Dim cmdInsert As New OleDb.OleDbCommand
        Dim intNextPrimaryKey As Integer
        Dim strLoginID As String
        Dim strPassword As String
        Dim intNextPrimaryKeyEmployee
        Dim intRowsAffectedEmployee
        Call Get_Validate_Input(strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, strLoginID, strPassword, blnValidated)
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

                strSelect = "SELECT MAX(intAttendantID) + 1 AS intNextPrimaryKey " &
                        " FROM TAttendants"
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

                cmdInsert.CommandText = "EXECUTE uspAddAttendant '" & intNextPrimaryKey & "','" & strFirstName & "','" & strLastName & "','" & strEmployeeID & "','" & dtmDateofHire & "','" & dtmDateofTermination & "'"
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


                cmdInsert.CommandText = "EXECUTE uspAddEmployee '" & intNextPrimaryKeyEmployee & "','" & strLoginID & "','" & strPassword & "','" & "Attendant" & "','" & intNextPrimaryKey & "'"
                cmdInsert.CommandType = CommandType.StoredProcedure

                cmdInsert = New OleDb.OleDbCommand(cmdInsert.CommandText, m_conAdministrator)

                intRowsAffectedEmployee = cmdInsert.ExecuteNonQuery()

                MessageBox.Show(cmdInsert.CommandText)

                If intRowsAffected And intRowsAffectedEmployee > 0 Then
                    MessageBox.Show("Attendant has been added")    ' let user know success
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

    Private Sub Get_Validate_Input(ByRef strFirstName As String, ByRef strLastName As String, ByRef strEmployeeID As String, ByRef dtmDateofHire As Date, ByRef dtmDateofTermination As Date, ByRef strLoginID As String, ByRef strPassword As String, ByRef blnValidated As Boolean)
        Call Get_Vaildate_FirstName(strFirstName, blnValidated)
        If blnValidated = True Then
            Call Get_Vaildate_LastName(strLastName, blnValidated)
        End If
        If blnValidated = True Then
            Call Get_Date_Of_Hire(dtmDateofHire)
        End If
        If blnValidated = True Then
            Call Get_Date_Of_Termination(dtmDateofTermination)
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


    Private Sub Get_Date_Of_Hire(ByRef dtmDateofHire As String)
        dtmDateofHire = dteDateHired.Value
    End Sub

    Private Sub Get_Date_Of_Termination(ByRef dtmDateofTermination As String)
        dtmDateofTermination = dteDateOfTermination.Value
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
End Class