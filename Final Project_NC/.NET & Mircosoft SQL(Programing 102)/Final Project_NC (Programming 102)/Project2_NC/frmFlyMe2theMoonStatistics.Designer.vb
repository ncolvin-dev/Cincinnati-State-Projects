<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFlyMe2theMoonStatistics
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
        Me.lblTotalNumberOfCustomers = New System.Windows.Forms.Label()
        Me.lblAverageMilesFlown = New System.Windows.Forms.Label()
        Me.lblTotalFlights = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.label = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lstTotalMilesFlownPilots = New System.Windows.Forms.ListBox()
        Me.lstTotalMilesFlownAttendants = New System.Windows.Forms.ListBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTotalNumberOfCustomers
        '
        Me.lblTotalNumberOfCustomers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalNumberOfCustomers.Location = New System.Drawing.Point(215, 29)
        Me.lblTotalNumberOfCustomers.Name = "lblTotalNumberOfCustomers"
        Me.lblTotalNumberOfCustomers.Size = New System.Drawing.Size(175, 20)
        Me.lblTotalNumberOfCustomers.TabIndex = 1
        Me.lblTotalNumberOfCustomers.Text = "Label2"
        '
        'lblAverageMilesFlown
        '
        Me.lblAverageMilesFlown.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAverageMilesFlown.Location = New System.Drawing.Point(215, 110)
        Me.lblAverageMilesFlown.Name = "lblAverageMilesFlown"
        Me.lblAverageMilesFlown.Size = New System.Drawing.Size(175, 20)
        Me.lblAverageMilesFlown.TabIndex = 2
        Me.lblAverageMilesFlown.Text = "Label3"
        '
        'lblTotalFlights
        '
        Me.lblTotalFlights.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalFlights.Location = New System.Drawing.Point(215, 69)
        Me.lblTotalFlights.Name = "lblTotalFlights"
        Me.lblTotalFlights.Size = New System.Drawing.Size(175, 20)
        Me.lblTotalFlights.TabIndex = 3
        Me.lblTotalFlights.Text = "Label4"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.label)
        Me.GroupBox1.Controls.Add(Me.lblTotalNumberOfCustomers)
        Me.GroupBox1.Controls.Add(Me.lblAverageMilesFlown)
        Me.GroupBox1.Controls.Add(Me.lblTotalFlights)
        Me.GroupBox1.Location = New System.Drawing.Point(34, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(414, 154)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'label
        '
        Me.label.AutoSize = True
        Me.label.Location = New System.Drawing.Point(12, 28)
        Me.label.Name = "label"
        Me.label.Size = New System.Drawing.Size(140, 13)
        Me.label.TabIndex = 4
        Me.label.Text = "Total Number Of Customers:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(146, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Total Flights by all Customers:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(189, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Average Miles Flown for All Customers:"
        '
        'lstTotalMilesFlownPilots
        '
        Me.lstTotalMilesFlownPilots.FormattingEnabled = True
        Me.lstTotalMilesFlownPilots.Location = New System.Drawing.Point(39, 199)
        Me.lstTotalMilesFlownPilots.Name = "lstTotalMilesFlownPilots"
        Me.lstTotalMilesFlownPilots.Size = New System.Drawing.Size(249, 225)
        Me.lstTotalMilesFlownPilots.TabIndex = 7
        '
        'lstTotalMilesFlownAttendants
        '
        Me.lstTotalMilesFlownAttendants.FormattingEnabled = True
        Me.lstTotalMilesFlownAttendants.Location = New System.Drawing.Point(314, 199)
        Me.lstTotalMilesFlownAttendants.Name = "lstTotalMilesFlownAttendants"
        Me.lstTotalMilesFlownAttendants.Size = New System.Drawing.Size(246, 225)
        Me.lstTotalMilesFlownAttendants.TabIndex = 8
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(464, 33)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(117, 53)
        Me.btnExit.TabIndex = 9
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmFlyMe2theMoonStatistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 455)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lstTotalMilesFlownAttendants)
        Me.Controls.Add(Me.lstTotalMilesFlownPilots)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmFlyMe2theMoonStatistics"
        Me.Text = "frmFlyMe2theMoonStatistics"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTotalNumberOfCustomers As Label
    Friend WithEvents lblAverageMilesFlown As Label
    Friend WithEvents lblTotalFlights As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents label As Label
    Friend WithEvents lstTotalMilesFlownPilots As ListBox
    Friend WithEvents lstTotalMilesFlownAttendants As ListBox
    Friend WithEvents btnExit As Button
End Class
