Public Class frmUpdatePilotProfile

    Private Sub frmUpdatePilotProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

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

            strSelect = "SELECT intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateofLicense, strPilotRole" &
                        " FROM TPilots JOIN TPilotRoles on TPilots.intPilotRoleID = TPilotRoles.intPilotRoleID WHERE TPilots.intPilotID = " & intPilotID
            ' Retrieve all the records 

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            txtFirstName.Text = drSourceTable("strFirstName")
            txtLastName.Text = drSourceTable("strLastName")
            txtEmployeeID.Text = drSourceTable("strEmployeeID")
            dteDateHired.Text = drSourceTable("dtmDateofHire")
            dteDateOfLicense.Text = drSourceTable("dtmDateofLicense")

            If drSourceTable("strPilotRole") = "Captain" Then
                radCaptain.Checked = True
                radCoPilot.Checked = False
            Else
                radCaptain.Checked = False
                radCoPilot.Checked = True
            End If

            strSelect = "SELECT strEmployeeLoginID, strEmployeePassword FROM TEmployees WHERE strEmployeeRole = 'Pilot' and intEmployeeID = " & intPilotID

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            txtLoginID.Text = drSourceTable("strEmployeeLoginID")
            txtPassword.Text = drSourceTable("strEmployeePassword")

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnUpdateCustomer_Click(sender As Object, e As EventArgs) Handles btnUpdateCustomer.Click
        ' variables for new player data and select and insert statements
        Dim strUpdate As String
        Dim cmdUpdate As OleDb.OleDbCommand
        Dim strFirstName As String
        Dim strLastName As String
        Dim intPilotRole As Integer
        Dim strEmployeeID As String
        Dim dtmDateofHire As Date
        Dim dtmDateofTermination As Date
        Dim dtmDateofLicense As Date
        Dim blnValidated As Boolean = True
        Dim intRowsAffected As Integer
        Dim strLoginID As String
        Dim strPassword As String
        Dim intRowsAffectedEmployee As Integer
        Call Get_Validate_Input(strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateofLicense, intPilotRole, strLoginID, strPassword, blnValidated)
        If blnValidated = True Then

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

                strUpdate = "UPDATE TPilots Set " &
                 "strLastName = '" & strLastName & "', " &
                 "strFirstName = '" & strFirstName & "', " &
                 "strEmployeeID = '" & strEmployeeID & "', " &
                 "dtmDateofHire = '" & dtmDateofHire & "', " &
                 "dtmDateofTermination = '" & dtmDateofTermination & "', " &
                 "dtmDateofLicense = '" & dtmDateofLicense & "', " &
                 "intPilotRoleID = " & intPilotRole &
                 " WHERE intPilotID = " & intPilotID

                'MessageBox.Show(strUpdate)

                cmdUpdate = New OleDb.OleDbCommand(strUpdate, m_conAdministrator)

                ' execute query to insert data
                intRowsAffected = cmdUpdate.ExecuteNonQuery()

                cmdUpdate.CommandText = "EXECUTE uspUpdateEmployeePilot '" & strLoginID & "','" & strPassword & "','" & intPilotID & "'"
                cmdUpdate.CommandType = CommandType.StoredProcedure

                cmdUpdate = New OleDb.OleDbCommand(cmdUpdate.CommandText, m_conAdministrator)

                intRowsAffectedEmployee = cmdUpdate.ExecuteNonQuery()

                If intRowsAffected And intRowsAffectedEmployee = 1 Then
                    MessageBox.Show("Pilot has been Updated")
                Else
                    MessageBox.Show("Update Failed")
                End If


                CloseDatabaseConnection()       ' close connection if insert didn't work
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


End Class