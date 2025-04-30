<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPilotMainMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnShowFutureFlights = New System.Windows.Forms.Button()
        Me.btnShowPastFlights = New System.Windows.Forms.Button()
        Me.btnUpdateProfileCustomer = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(25, 202)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(148, 45)
        Me.btnExit.TabIndex = 14
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnShowFutureFlights
        '
        Me.btnShowFutureFlights.Location = New System.Drawing.Point(25, 142)
        Me.btnShowFutureFlights.Margin = New System.Windows.Forms.Padding(2)
        Me.btnShowFutureFlights.Name = "btnShowFutureFlights"
        Me.btnShowFutureFlights.Size = New System.Drawing.Size(148, 45)
        Me.btnShowFutureFlights.TabIndex = 13
        Me.btnShowFutureFlights.Text = "Show Future Flights"
        Me.btnShowFutureFlights.UseVisualStyleBackColor = True
        '
        'btnShowPastFlights
        '
        Me.btnShowPastFlights.Location = New System.Drawing.Point(25, 82)
        Me.btnShowPastFlights.Margin = New System.Windows.Forms.Padding(2)
        Me.btnShowPastFlights.Name = "btnShowPastFlights"
        Me.btnShowPastFlights.Size = New System.Drawing.Size(148, 45)
        Me.btnShowPastFlights.TabIndex = 12
        Me.btnShowPastFlights.Text = "Show Past Flights"
        Me.btnShowPastFlights.UseVisualStyleBackColor = True
        '
        'btnUpdateProfileCustomer
        '
        Me.btnUpdateProfileCustomer.Location = New System.Drawing.Point(25, 20)
        Me.btnUpdateProfileCustomer.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdateProfileCustomer.Name = "btnUpdateProfileCustomer"
        Me.btnUpdateProfileCustomer.Size = New System.Drawing.Size(148, 45)
        Me.btnUpdateProfileCustomer.TabIndex = 10
        Me.btnUpdateProfileCustomer.Text = "Update Profile"
        Me.btnUpdateProfileCustomer.UseVisualStyleBackColor = True
        '
        'frmPilotMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(196, 263)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnShowFutureFlights)
        Me.Controls.Add(Me.btnShowPastFlights)
        Me.Controls.Add(Me.btnUpdateProfileCustomer)
        Me.Name = "frmPilotMainMenu"
        Me.Text = "frmPilotMainMenu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnShowFutureFlights As Button
    Friend WithEvents btnShowPastFlights As Button
    Friend WithEvents btnUpdateProfileCustomer As Button
End Class
