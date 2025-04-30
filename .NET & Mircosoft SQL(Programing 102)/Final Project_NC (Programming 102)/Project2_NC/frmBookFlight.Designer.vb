<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBookFlight
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
        Me.cboFlights = New System.Windows.Forms.ComboBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.radReserved = New System.Windows.Forms.RadioButton()
        Me.radDesignatedSeat = New System.Windows.Forms.RadioButton()
        Me.lblReservedSeat = New System.Windows.Forms.Label()
        Me.lblDesignatedSeat = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboFlights
        '
        Me.cboFlights.FormattingEnabled = True
        Me.cboFlights.Location = New System.Drawing.Point(34, 27)
        Me.cboFlights.Margin = New System.Windows.Forms.Padding(2)
        Me.cboFlights.Name = "cboFlights"
        Me.cboFlights.Size = New System.Drawing.Size(308, 21)
        Me.cboFlights.TabIndex = 0
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(36, 209)
        Me.btnSubmit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(95, 40)
        Me.btnSubmit.TabIndex = 1
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(234, 209)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(95, 40)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Available Flights:"
        '
        'radReserved
        '
        Me.radReserved.AutoSize = True
        Me.radReserved.Location = New System.Drawing.Point(34, 88)
        Me.radReserved.Margin = New System.Windows.Forms.Padding(2)
        Me.radReserved.Name = "radReserved"
        Me.radReserved.Size = New System.Drawing.Size(96, 17)
        Me.radReserved.TabIndex = 4
        Me.radReserved.TabStop = True
        Me.radReserved.Text = "Reserved Seat"
        Me.radReserved.UseVisualStyleBackColor = True
        Me.radReserved.Visible = False
        '
        'radDesignatedSeat
        '
        Me.radDesignatedSeat.AutoSize = True
        Me.radDesignatedSeat.Location = New System.Drawing.Point(34, 156)
        Me.radDesignatedSeat.Margin = New System.Windows.Forms.Padding(2)
        Me.radDesignatedSeat.Name = "radDesignatedSeat"
        Me.radDesignatedSeat.Size = New System.Drawing.Size(162, 17)
        Me.radDesignatedSeat.TabIndex = 5
        Me.radDesignatedSeat.TabStop = True
        Me.radDesignatedSeat.Text = "Designated Seat at Check In"
        Me.radDesignatedSeat.UseVisualStyleBackColor = True
        Me.radDesignatedSeat.Visible = False
        '
        'lblReservedSeat
        '
        Me.lblReservedSeat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblReservedSeat.Location = New System.Drawing.Point(208, 79)
        Me.lblReservedSeat.Name = "lblReservedSeat"
        Me.lblReservedSeat.Size = New System.Drawing.Size(134, 26)
        Me.lblReservedSeat.TabIndex = 6
        Me.lblReservedSeat.Visible = False
        '
        'lblDesignatedSeat
        '
        Me.lblDesignatedSeat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDesignatedSeat.Location = New System.Drawing.Point(208, 149)
        Me.lblDesignatedSeat.Name = "lblDesignatedSeat"
        Me.lblDesignatedSeat.Size = New System.Drawing.Size(134, 26)
        Me.lblDesignatedSeat.TabIndex = 7
        Me.lblDesignatedSeat.Visible = False
        '
        'frmBookFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 282)
        Me.Controls.Add(Me.lblDesignatedSeat)
        Me.Controls.Add(Me.lblReservedSeat)
        Me.Controls.Add(Me.radDesignatedSeat)
        Me.Controls.Add(Me.radReserved)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.cboFlights)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmBookFlight"
        Me.Text = "Book Flight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboFlights As ComboBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents radReserved As RadioButton
    Friend WithEvents radDesignatedSeat As RadioButton
    Friend WithEvents lblReservedSeat As Label
    Friend WithEvents lblDesignatedSeat As Label
End Class
