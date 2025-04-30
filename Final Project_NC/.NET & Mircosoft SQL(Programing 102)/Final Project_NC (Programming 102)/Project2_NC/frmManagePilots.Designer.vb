<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManagePilots
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
        Me.btnShowPastFlights = New System.Windows.Forms.Button()
        Me.btnAddFlight = New System.Windows.Forms.Button()
        Me.btnUpdateProfileCustomer = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(27, 196)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(148, 45)
        Me.btnExit.TabIndex = 18
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnShowPastFlights
        '
        Me.btnShowPastFlights.Location = New System.Drawing.Point(27, 136)
        Me.btnShowPastFlights.Margin = New System.Windows.Forms.Padding(2)
        Me.btnShowPastFlights.Name = "btnShowPastFlights"
        Me.btnShowPastFlights.Size = New System.Drawing.Size(148, 45)
        Me.btnShowPastFlights.TabIndex = 17
        Me.btnShowPastFlights.Text = "Add Pilots to Future Flights"
        Me.btnShowPastFlights.UseVisualStyleBackColor = True
        '
        'btnAddFlight
        '
        Me.btnAddFlight.Location = New System.Drawing.Point(27, 78)
        Me.btnAddFlight.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddFlight.Name = "btnAddFlight"
        Me.btnAddFlight.Size = New System.Drawing.Size(148, 45)
        Me.btnAddFlight.TabIndex = 16
        Me.btnAddFlight.Text = "Delete Pilots"
        Me.btnAddFlight.UseVisualStyleBackColor = True
        '
        'btnUpdateProfileCustomer
        '
        Me.btnUpdateProfileCustomer.Location = New System.Drawing.Point(27, 21)
        Me.btnUpdateProfileCustomer.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdateProfileCustomer.Name = "btnUpdateProfileCustomer"
        Me.btnUpdateProfileCustomer.Size = New System.Drawing.Size(148, 45)
        Me.btnUpdateProfileCustomer.TabIndex = 15
        Me.btnUpdateProfileCustomer.Text = "Add Pilots"
        Me.btnUpdateProfileCustomer.UseVisualStyleBackColor = True
        '
        'frmManagePilots
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(200, 262)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnShowPastFlights)
        Me.Controls.Add(Me.btnAddFlight)
        Me.Controls.Add(Me.btnUpdateProfileCustomer)
        Me.Name = "frmManagePilots"
        Me.Text = "frmManagePilots"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnShowPastFlights As Button
    Friend WithEvents btnAddFlight As Button
    Friend WithEvents btnUpdateProfileCustomer As Button
End Class
