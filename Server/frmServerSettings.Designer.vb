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
        Me.ccXMLDBConnection = New Server.ctrlXMLDBConnection()
        Me.ccSQLDBConnection = New Server.ctrlSQLDBConnection()
        Me.ccAccessDBConnection = New Server.ctrlAccessDBConnection()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
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
        Me.cbDBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDBType.FormattingEnabled = True
        Me.cbDBType.Items.AddRange(New Object() {"MS SQL", "MS Access", "XML"})
        Me.cbDBType.Location = New System.Drawing.Point(88, 38)
        Me.cbDBType.Name = "cbDBType"
        Me.cbDBType.Size = New System.Drawing.Size(121, 21)
        Me.cbDBType.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ccXMLDBConnection)
        Me.Panel1.Controls.Add(Me.ccSQLDBConnection)
        Me.Panel1.Controls.Add(Me.ccAccessDBConnection)
        Me.Panel1.Location = New System.Drawing.Point(6, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(277, 115)
        Me.Panel1.TabIndex = 5
        '
        'ccXMLDBConnection
        '
        Me.ccXMLDBConnection.Location = New System.Drawing.Point(3, 3)
        Me.ccXMLDBConnection.Name = "ccXMLDBConnection"
        Me.ccXMLDBConnection.Size = New System.Drawing.Size(184, 25)
        Me.ccXMLDBConnection.TabIndex = 2
        '
        'ccSQLDBConnection
        '
        Me.ccSQLDBConnection.Location = New System.Drawing.Point(3, 3)
        Me.ccSQLDBConnection.Name = "ccSQLDBConnection"
        Me.ccSQLDBConnection.Size = New System.Drawing.Size(244, 107)
        Me.ccSQLDBConnection.TabIndex = 1
        '
        'ccAccessDBConnection
        '
        Me.ccAccessDBConnection.Location = New System.Drawing.Point(3, 2)
        Me.ccAccessDBConnection.Name = "ccAccessDBConnection"
        Me.ccAccessDBConnection.Size = New System.Drawing.Size(184, 52)
        Me.ccAccessDBConnection.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(174, 186)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(6, 186)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmServerSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(254, 216)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cbDBType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPort)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
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
    Friend WithEvents ccXMLDBConnection As ctrlXMLDBConnection
    Friend WithEvents ccSQLDBConnection As ctrlSQLDBConnection
    Friend WithEvents ccAccessDBConnection As ctrlAccessDBConnection
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
End Class
