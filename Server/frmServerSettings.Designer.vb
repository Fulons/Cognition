<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServerSettings
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
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbDBType = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CtrlAccessDBConnection1 = New Server.ctrlAccessDBConnection()
        Me.CtrlSQLDBConnection1 = New Server.ctrlSQLDBConnection()
        Me.CtrlXMLDBConnection1 = New Server.ctrlXMLDBConnection()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(88, 12)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(121, 20)
        Me.txtPort.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Server Port"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "User DB type"
        '
        'cbDBType
        '
        Me.cbDBType.FormattingEnabled = True
        Me.cbDBType.Location = New System.Drawing.Point(88, 38)
        Me.cbDBType.Name = "cbDBType"
        Me.cbDBType.Size = New System.Drawing.Size(121, 21)
        Me.cbDBType.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CtrlXMLDBConnection1)
        Me.Panel1.Controls.Add(Me.CtrlSQLDBConnection1)
        Me.Panel1.Controls.Add(Me.CtrlAccessDBConnection1)
        Me.Panel1.Location = New System.Drawing.Point(6, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(259, 226)
        Me.Panel1.TabIndex = 5
        '
        'CtrlAccessDBConnection1
        '
        Me.CtrlAccessDBConnection1.Location = New System.Drawing.Point(3, 116)
        Me.CtrlAccessDBConnection1.Name = "CtrlAccessDBConnection1"
        Me.CtrlAccessDBConnection1.Size = New System.Drawing.Size(184, 52)
        Me.CtrlAccessDBConnection1.TabIndex = 0
        '
        'CtrlSQLDBConnection1
        '
        Me.CtrlSQLDBConnection1.Location = New System.Drawing.Point(3, 3)
        Me.CtrlSQLDBConnection1.Name = "CtrlSQLDBConnection1"
        Me.CtrlSQLDBConnection1.Size = New System.Drawing.Size(244, 107)
        Me.CtrlSQLDBConnection1.TabIndex = 1
        '
        'CtrlXMLDBConnection1
        '
        Me.CtrlXMLDBConnection1.Location = New System.Drawing.Point(3, 174)
        Me.CtrlXMLDBConnection1.Name = "CtrlXMLDBConnection1"
        Me.CtrlXMLDBConnection1.Size = New System.Drawing.Size(184, 25)
        Me.CtrlXMLDBConnection1.TabIndex = 2
        '
        'frmServerSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(271, 296)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cbDBType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPort)
        Me.Name = "frmServerSettings"
        Me.Text = "frmServerSettings"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPort As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbDBType As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CtrlXMLDBConnection1 As ctrlXMLDBConnection
    Friend WithEvents CtrlSQLDBConnection1 As ctrlSQLDBConnection
    Friend WithEvents CtrlAccessDBConnection1 As ctrlAccessDBConnection
End Class
