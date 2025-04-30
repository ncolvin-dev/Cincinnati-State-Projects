Public Class frmUpdateCustomerProfile
    Private Sub frmUpdateCustomerProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim objParam As OleDb.OleDbParameter
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

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand("uspListStates", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            drSourceTable = cmdSelect.ExecuteReader
            dts.Load(drSourceTable)



            'load the State result set into the combobox.  For VB, we do this by binding the data to the combobox


            cboStates.ValueMember = "intStateID"
            cboStates.DisplayMember = "strState"
            cboStates.DataSource = dts

            cmdSelect = New OleDb.OleDbCommand("uspListCustomerInfo", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@PassengerID", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = intCustomerID

            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            txtFirstName.Text = drSourceTable("strFirstName")
            txtLastName.Text = drSourceTable("strLastName")
            txtAddress.Text = drSourceTable("strAddress")
            txtCity.Text = drSourceTable("strCity")
            cboStates.SelectedValue = drSourceTable("intStateID")
            txtZip.Text = drSourceTable("strZip")
            txtPhoneNumber.Text = drSourceTable("strPhoneNumber")
            txtEmail.Text = drSourceTable("strEmail")
            txtLoginID.Text = drSourceTable("strLoginID")
            txtPassword.Text = drSourceTable("strPassword")
            dteDateofBirth.Value = drSourceTable("dtmDateofBirth")



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
        Dim cmdUpdate As New OleDb.OleDbCommand
        Dim strFirstName As String
        Dim strLastName As String
        Dim strAddress As String
        Dim strCity As String
        Dim intState As Integer
        Dim strZip As String
        Dim strPhoneNumber As String
        Dim strEmail As String
        Dim strLoginID As String
        Dim strPassword As String
        Dim dtmDateofBirth As Date
        Dim blnValidated As Boolean = True
        Dim intRowsAffected As Integer
        Call Get_Validate_Input(strFirstName, strLastName, strAddress, strCity, intState, strZip, strPhoneNumber, strEmail, strLoginID, strPassword, dtmDateofBirth, blnValidated)
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


                'MessageBox.Show(strUpdate)
                cmdUpdate.CommandText = "EXECUTE uspUpdatePassenger '" & intCustomerID & "','" & strFirstName & "','" & strLastName & "','" & strAddress & "','" & strCity &
                                                                            "','" & intState & "','" & strZip & "','" & strPhoneNumber & "','" & strEmail & "','" & strLoginID & "','" & strPassword & "','" & dtmDateofBirth & "'"

                cmdUpdate.CommandType = CommandType.StoredProcedure

                'MessageBox.Show(cmdUpdate.CommandText)

                ' use insert command with sql string and connection object
                cmdUpdate = New OleDb.OleDbCommand(cmdUpdate.CommandText, m_conAdministrator)

                ' execute query to insert data
                intRowsAffected = cmdUpdate.ExecuteNonQuery()

                ' If not 0 insert successful
                If intRowsAffected = 1 Then
                    MessageBox.Show("Passenger has been Updated")
                Else
                    MessageBox.Show("Update Failed")
                End If

                CloseDatabaseConnection()       ' close connection if insert didn't work
                Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message)

            End Try
        End If

    End Sub

    Private Sub Get_Validate_Input(ByRef strFirstName As String, ByRef strLastName As String, ByRef strAddress As String, ByRef strCity As String, ByRef intState As Integer, ByRef strZip As String, ByRef strPhoneNumber As String, ByRef strEmail As String, ByRef strLoginID As String, ByRef strPassword As String, ByRef dtmDateofBirth As Date, ByRef blnValidated As Boolean)
        Call Get_Vaildate_FirstName(strFirstName, blnValidated)
        If blnValidated = True Then
            Call Get_Vaildate_LastName(strLastName, blnValidated)
        End If
        If blnValidated = True Then
            Call Get_Vaildate_Address(strAddress, blnValidated)
        End If
        If blnValidated = True Then
            Call Get_Vaildate_City(strCity, blnValidated)
        End If
        If blnValidated = True Then
            Call Get_Vaildate_Zip(strZip, blnValidated)
        End If
        If blnValidated = True Then
            Call Get_Vaildate_PhoneNumber(strPhoneNumber, blnValidated)
        End If
        If blnValidated = True Then
            Call Get_Vaildate_Email(strEmail, blnValidated)
        End If

        If blnValidated = True Then
            Call Get_Vaildate_LoginID(strLoginID, blnValidated)
        End If

        If blnValidated = True Then
            Call Get_Vaildate_Password(strPassword, blnValidated)
        End If
        intState = cboStates.SelectedValue
        dtmDateofBirth = dteDateofBirth.Value

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

    Private Sub Get_Vaildate_Address(ByRef strAddress As String, ByRef blnValidated As Boolean)
        If txtAddress.Text = "" Then
            txtAddress.Focus()
            MessageBox.Show("Please enter your address")
            blnValidated = False
        Else
            strAddress = txtAddress.Text
        End If

    End Sub
    Private Sub Get_Vaildate_City(ByRef strCity As String, ByRef blnValidated As Boolean)
        If txtCity.Text = "" Then
            txtLastName.Focus()
            MessageBox.Show("Please enter your city")
            blnValidated = False
        Else
            strCity = txtCity.Text
        End If
    End Sub
    Private Sub Get_Vaildate_Zip(ByRef strZip As String, ByRef blnValidated As Boolean)

        If txtZip.Text = "" Then
            txtZip.Focus()
            MessageBox.Show("Please enter your zip code")
            blnValidated = False
        Else
            strZip = txtZip.Text
        End If
    End Sub
    Private Sub Get_Vaildate_PhoneNumber(ByRef strPhoneNumber As String, ByRef blnValidated As Boolean)
        If txtPhoneNumber.Text = "" Then
            txtPhoneNumber.Focus()
            MessageBox.Show("Please enter your Phone Number")
            blnValidated = False
        Else
            strPhoneNumber = txtPhoneNumber.Text
        End If
    End Sub
    Private Sub Get_Vaildate_Email(ByRef strEmail As String, ByRef blnValidated As Boolean)


        If txtEmail.Text = "" Then
            txtEmail.Focus()
            MessageBox.Show("Please enter your email")
            blnValidated = False
        Else
            strEmail = txtEmail.Text
        End If
        If blnValidated = True Then
            If strEmail.IndexOf("@") >= 0 Then
            Else
                blnValidated = False
                MessageBox.Show("This email is invalid.")
                txtEmail.Focus()
            End If
        End If

    End Sub


    Private Sub Get_Vaildate_LoginID(ByRef strLoginID As String, ByRef blnValidated As Boolean)
        If txtFirstName.Text = "" Then
            txtFirstName.Focus()
            MessageBox.Show("Please Enter A Login ID ")
            blnValidated = False
        Else
            strLoginID = txtLoginID.Text
        End If
    End Sub


    Private Sub Get_Vaildate_Password(ByRef strPassword As String, ByRef blnValidated As Boolean)
        If txtFirstName.Text = "" Then
            txtFirstName.Focus()
            MessageBox.Show("Please Enter A Password ")
            blnValidated = False
        Else
            strPassword = txtPassword.Text
        End If
    End Sub




    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class