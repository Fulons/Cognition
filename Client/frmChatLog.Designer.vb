<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChatLog
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
        Me.lbUsers = New System.Windows.Forms.ListBox()
        Me.rtxtChatLog = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'lbUsers
        '
        Me.lbUsers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbUsers.FormattingEnabled = True
        Me.lbUsers.Location = New System.Drawing.Point(737, 12)
        Me.lbUsers.Name = "lbUsers"
        Me.lbUsers.Size = New System.Drawing.Size(120, 524)
        Me.lbUsers.TabIndex = 3
        '
        'rtxtChatLog
        '
        Me.rtxtChatLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtxtChatLog.Location = New System.Drawing.Point(12, 12)
        Me.rtxtChatLog.Name = "rtxtChatLog"
        Me.rtxtChatLog.ReadOnly = True
        Me.rtxtChatLog.Size = New System.Drawing.Size(719, 524)
        Me.rtxtChatLog.TabIndex = 2
        Me.rtxtChatLog.Text = ""
        '
        'frmChatLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 543)
        Me.Controls.Add(Me.lbUsers)
        Me.Controls.Add(Me.rtxtChatLog)
        Me.Name = "frmChatLog"
        Me.Text = "frmChatLog"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lbUsers As ListBox
    Friend WithEvents rtxtChatLog As RichTextBox
End Class
