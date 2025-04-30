<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFutureFlights
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
        Me.btnAddFlight = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtmTimeOfDeparture = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtmTimeOfLanding = New System.Windows.Forms.DateTimePicker()
        Me.dtmFlightDate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFlightNumber = New System.Windows.Forms.TextBox()
        Me.txtMilesFlown = New System.Windows.Forms.TextBox()
        Me.cboFromAirport = New System.Windows.Forms.ComboBox()
        Me.cboToAirport = New System.Windows.Forms.ComboBox()
        Me.cboPlane = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAddFlight
        '
        Me.btnAddFlight.Location = New System.Drawing.Point(52, 430)
        Me.btnAddFlight.Name = "btnAddFlight"
        Me.btnAddFlight.Size = New System.Drawing.Size(91, 38)
        Me.btnAddFlight.TabIndex = 22
        Me.btnAddFlight.Text = "Add Flight"
        Me.btnAddFlight.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboPlane)
        Me.GroupBox1.Controls.Add(Me.cboToAirport)
        Me.GroupBox1.Controls.Add(Me.cboFromAirport)
        Me.GroupBox1.Controls.Add(Me.dtmTimeOfDeparture)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dtmTimeOfLanding)
        Me.GroupBox1.Controls.Add(Me.dtmFlightDate)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtFlightNumber)
        Me.GroupBox1.Controls.Add(Me.txtMilesFlown)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(399, 383)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        '
        'dtmTimeOfDeparture
        '
        Me.dtmTimeOfDeparture.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtmTimeOfDeparture.Location = New System.Drawing.Point(180, 112)
        Me.dtmTimeOfDeparture.Name = "dtmTimeOfDeparture"
        Me.dtmTimeOfDeparture.Size = New System.Drawing.Size(97, 20)
        Me.dtmTimeOfDeparture.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(34, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(140, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Expected Time of Depature:"
        '
        'dtmTimeOfLanding
        '
        Me.dtmTimeOfLanding.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtmTimeOfLanding.Location = New System.Drawing.Point(180, 152)
        Me.dtmTimeOfLanding.Name = "dtmTimeOfLanding"
        Me.dtmTimeOfLanding.Size = New System.Drawing.Size(97, 20)
        Me.dtmTimeOfLanding.TabIndex = 21
        '
        'dtmFlightDate
        '
        Me.dtmFlightDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtmFlightDate.Location = New System.Drawing.Point(180, 25)
        Me.dtmFlightDate.Name = "dtmFlightDate"
        Me.dtmFlightDate.Size = New System.Drawing.Size(100, 20)
        Me.dtmFlightDate.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(34, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Expected Time Of Landing:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Flight Date:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Flight Number:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 293)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Expected Miles Flown:"
        '
        'txtFlightNumber
        '
        Me.txtFlightNumber.Location = New System.Drawing.Point(180, 70)
        Me.txtFlightNumber.Name = "txtFlightNumber"
        Me.txtFlightNumber.Size = New System.Drawing.Size(100, 20)
        Me.txtFlightNumber.TabIndex = 2
        '
        'txtMilesFlown
        '
        Me.txtMilesFlown.Location = New System.Drawing.Point(180, 290)
        Me.txtMilesFlown.Name = "txtMilesFlown"
        Me.txtMilesFlown.Size = New System.Drawing.Size(100, 20)
        Me.txtMilesFlown.TabIndex = 1
        '
        'cboFromAirport
        '
        Me.cboFromAirport.FormattingEnabled = True
        Me.cboFromAirport.Location = New System.Drawing.Point(180, 201)
        Me.cboFromAirport.Name = "cboFromAirport"
        Me.cboFromAirport.Size = New System.Drawing.Size(121, 21)
        Me.cboFromAirport.TabIndex = 24
        '
        'cboToAirport
        '
        Me.cboToAirport.FormattingEnabled = True
        Me.cboToAirport.Location = New System.Drawing.Point(180, 246)
        Me.cboToAirport.Name = "cboToAirport"
        Me.cboToAirport.Size = New System.Drawing.Size(121, 21)
        Me.cboToAirport.TabIndex = 25
        '
        'cboPlane
        '
        Me.cboPlane.FormattingEnabled = True
        Me.cboPlane.Location = New System.Drawing.Point(180, 333)
        Me.cboPlane.Name = "cboPlane"
        Me.cboPlane.Size = New System.Drawing.Size(121, 21)
        Me.cboPlane.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 204)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "From Airport:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(34, 249)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "To Airport:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(34, 336)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Select Plane:"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(280, 430)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(91, 38)
        Me.btnExit.TabIndex = 23
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmFutureFlights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 497)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnAddFlight)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmFutureFlights"
        Me.Text = "frmFutureFlights"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAddFlight As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboPlane As ComboBox
    Friend WithEvents cboToAirport As ComboBox
    Friend WithEvents cboFromAirport As ComboBox
    Friend WithEvents dtmTimeOfDeparture As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents dtmTimeOfLanding As DateTimePicker
    Friend WithEvents dtmFlightDate As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFlightNumber As TextBox
    Friend WithEvents txtMilesFlown As TextBox
    Friend WithEvents btnExit As Button
End Class
