Public Class frmEmployeeLogin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim strLoginID As String
        Dim strPassword As String
        Dim blnValidated As Boolean = True
        Dim strSelect As String
        Dim cmdSelect As New OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim cmdInsert As New OleDb.OleDbCommand
        Dim ShowfrmPliotMainMenu As New frmPilotMainMenu
        Dim ShowfrmAttendantMainMenu As New frmAttendantMainMenu
        Dim ShowfrmAdminMainMenu As New frmAdminMainMenu
        Dim blnLoginID As Boolean
        Dim blnPassword As Boolean
        Dim strSelctedRole As String
        Dim blnFlag As Boolean

        Call Get_Validate_Input(strLoginID, strPassword, blnValidated)
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



                strSelect = "SELECT intEmployeeID, strEmployeeLoginID, strEmployeePassword, strEmployeeRole FROM TEmployees"
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

                drSourceTable = cmdSelect.ExecuteReader

                Do While drSourceTable.Read
                    If drSourceTable("strEmployeeLoginID") = strLoginID Then
                        blnLoginID = True
                    End If

                    If drSourceTable("strEmployeePassword") = strPassword Then
                        blnPassword = True
                    End If

                    If blnLoginID And blnPassword = True Then
                        strSelctedRole = drSourceTable("strEmployeeRole")
                        Select Case drSourceTable("strEmployeeRole")
                            Case "Pilot"
                                intPilotID = drSourceTable("intEmployeeID")
                            Case "Attendant"
                                intAttendantID = drSourceTable("intEmployeeID")
                        End Select
                        blnLoginID = False
                        blnPassword = False
                        blnFlag = True
                    End If
                Loop

                CloseDatabaseConnection()       ' close connection if insert didn't work
                drSourceTable.Close()

                If blnFlag = True Then
                    Select Case strSelctedRole
                        Case "Pilot"
                            Me.Hide()
                            ShowfrmPliotMainMenu.ShowDialog()
                            Me.Show()
                        Case "Attendant"
                            Me.Hide()
                            ShowfrmAttendantMainMenu.ShowDialog()
                            Me.Show()
                        Case "Admin"
                            Me.Hide()
                            ShowfrmAdminMainMenu.ShowDialog()
                            Me.Show()
                    End Select

                Else
                    MessageBox.Show(“Password or ID Invalid”)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If



    End Sub

    Private Sub Get_Validate_Input(ByRef strLoginID As String, ByRef strPassword As String, ByRef blnValidated As Boolean)

        Call Get_Vaildate_LoginID(strLoginID, blnValidated)
        If blnValidated = True Then
            Call Get_Vaildate_Password(strPassword, blnValidated)
        End If
    End Sub
    Private Sub Get_Vaildate_LoginID(ByRef strLoginID As String, ByRef blnValidated As Boolean)
        If txtID.Text = "" Then
            txtID.Focus()
            MessageBox.Show("Please Enter A Login ID ")
            blnValidated = False
        Else
            strLoginID = txtID.Text
        End If
    End Sub


    Private Sub Get_Vaildate_Password(ByRef strPassword As String, ByRef blnValidated As Boolean)
        If txtPassword.Text = "" Then
            txtPassword.Focus()
            MessageBox.Show("Please Enter A Password ")
            blnValidated = False
        Else
            strPassword = txtPassword.Text
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class