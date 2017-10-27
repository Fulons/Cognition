<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlIP
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.txtIP1 = New System.Windows.Forms.TextBox()
        Me.txtIP2 = New System.Windows.Forms.TextBox()
        Me.txtIP3 = New System.Windows.Forms.TextBox()
        Me.txtIP4 = New System.Windows.Forms.TextBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtIP1
        '
        Me.txtIP1.Location = New System.Drawing.Point(3, 3)
        Me.txtIP1.Name = "txtIP1"
        Me.txtIP1.Size = New System.Drawing.Size(27, 20)
        Me.txtIP1.TabIndex = 0
        Me.txtIP1.Text = "127"
        '
        'txtIP2
        '
        Me.txtIP2.Location = New System.Drawing.Point(36, 3)
        Me.txtIP2.Name = "txtIP2"
        Me.txtIP2.Size = New System.Drawing.Size(27, 20)
        Me.txtIP2.TabIndex = 1
        Me.txtIP2.Text = "0"
        '
        'txtIP3
        '
        Me.txtIP3.Location = New System.Drawing.Point(69, 3)
        Me.txtIP3.Name = "txtIP3"
        Me.txtIP3.Size = New System.Drawing.Size(27, 20)
        Me.txtIP3.TabIndex = 2
        Me.txtIP3.Text = "0"
        '
        'txtIP4
        '
        Me.txtIP4.Location = New System.Drawing.Point(102, 3)
        Me.txtIP4.Name = "txtIP4"
        Me.txtIP4.Size = New System.Drawing.Size(27, 20)
        Me.txtIP4.TabIndex = 3
        Me.txtIP4.Text = "1"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(139, 3)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(38, 20)
        Me.txtPort.TabIndex = 4
        Me.txtPort.Text = "8379"
        '
        'ctrlIP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.txtIP4)
        Me.Controls.Add(Me.txtIP3)
        Me.Controls.Add(Me.txtIP2)
        Me.Controls.Add(Me.txtIP1)
        Me.Name = "ctrlIP"
        Me.Size = New System.Drawing.Size(179, 26)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtIP1 As Windows.Forms.TextBox
    Friend WithEvents txtIP2 As Windows.Forms.TextBox
    Friend WithEvents txtIP3 As Windows.Forms.TextBox
    Friend WithEvents txtIP4 As Windows.Forms.TextBox
    Friend WithEvents txtPort As Windows.Forms.TextBox
End Class
