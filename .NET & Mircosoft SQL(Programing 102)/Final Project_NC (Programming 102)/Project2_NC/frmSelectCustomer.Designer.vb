<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectCustomer
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
        Me.btnAddPassenger = New System.Windows.Forms.Button()
        Me.cboCustomers = New System.Windows.Forms.ComboBox()
        Me.btnSelectCustomer = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(35, 328)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(301, 70)
        Me.btnExit.TabIndex = 9
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnAddPassenger
        '
        Me.btnAddPassenger.Location = New System.Drawing.Point(35, 219)
        Me.btnAddPassenger.Name = "btnAddPassenger"
        Me.btnAddPassenger.Size = New System.Drawing.Size(301, 70)
        Me.btnAddPassenger.TabIndex = 5
        Me.btnAddPassenger.Text = "New Customer"
        Me.btnAddPassenger.UseVisualStyleBackColor = True
        '
        'cboCustomers
        '
        Me.cboCustomers.FormattingEnabled = True
        Me.cboCustomers.Location = New System.Drawing.Point(35, 27)
        Me.cboCustomers.Name = "cboCustomers"
        Me.cboCustomers.Size = New System.Drawing.Size(301, 28)
        Me.cboCustomers.TabIndex = 10
        '
        'btnSelectCustomer
        '
        Me.btnSelectCustomer.Location = New System.Drawing.Point(35, 112)
        Me.btnSelectCustomer.Name = "btnSelectCustomer"
        Me.btnSelectCustomer.Size = New System.Drawing.Size(301, 70)
        Me.btnSelectCustomer.TabIndex = 11
        Me.btnSelectCustomer.Text = "Select Customer"
        Me.btnSelectCustomer.UseVisualStyleBackColor = True
        '
        'frmCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 429)
        Me.Controls.Add(Me.btnSelectCustomer)
        Me.Controls.Add(Me.cboCustomers)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnAddPassenger)
        Me.Name = "frmCustomer"
        Me.Text = "Customers"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnAddPassenger As Button
    Friend WithEvents cboCustomers As ComboBox
    Friend WithEvents btnSelectCustomer As Button
End Class
