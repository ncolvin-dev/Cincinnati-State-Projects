<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChooseUserLogin
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
        Me.btnPassengerLogin = New System.Windows.Forms.Button()
        Me.btnEmployeeLogin = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnPassengerLogin
        '
        Me.btnPassengerLogin.Location = New System.Drawing.Point(49, 46)
        Me.btnPassengerLogin.Name = "btnPassengerLogin"
        Me.btnPassengerLogin.Size = New System.Drawing.Size(238, 99)
        Me.btnPassengerLogin.TabIndex = 0
        Me.btnPassengerLogin.Text = "Passenger Login"
        Me.btnPassengerLogin.UseVisualStyleBackColor = True
        '
        'btnEmployeeLogin
        '
        Me.btnEmployeeLogin.Location = New System.Drawing.Point(49, 276)
        Me.btnEmployeeLogin.Name = "btnEmployeeLogin"
        Me.btnEmployeeLogin.Size = New System.Drawing.Size(238, 99)
        Me.btnEmployeeLogin.TabIndex = 1
        Me.btnEmployeeLogin.Text = "Employee Login"
        Me.btnEmployeeLogin.UseVisualStyleBackColor = True
        '
        'frmChooseUserLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 429)
        Me.Controls.Add(Me.btnEmployeeLogin)
        Me.Controls.Add(Me.btnPassengerLogin)
        Me.Name = "frmChooseUserLogin"
        Me.Text = "frmChooseUserLogin"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnPassengerLogin As Button
    Friend WithEvents btnEmployeeLogin As Button
End Class
