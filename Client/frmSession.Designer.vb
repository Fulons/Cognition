<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSession
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
        Me.rtxtChat = New System.Windows.Forms.RichTextBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.txtMessageInput = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'rtxtChat
        '
        Me.rtxtChat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtxtChat.Location = New System.Drawing.Point(12, 12)
        Me.rtxtChat.Name = "rtxtChat"
        Me.rtxtChat.Size = New System.Drawing.Size(899, 537)
        Me.rtxtChat.TabIndex = 3
        Me.rtxtChat.Text = ""
        '
        'btnSend
        '
        Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSend.Location = New System.Drawing.Point(836, 554)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 23)
        Me.btnSend.TabIndex = 5
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'txtMessageInput
        '
        Me.txtMessageInput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessageInput.Location = New System.Drawing.Point(12, 555)
        Me.txtMessageInput.Name = "txtMessageInput"
        Me.txtMessageInput.Size = New System.Drawing.Size(818, 20)
        Me.txtMessageInput.TabIndex = 4
        '
        'frmSession
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(923, 587)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.txtMessageInput)
        Me.Controls.Add(Me.rtxtChat)
        Me.Name = "frmSession"
        Me.Text = "frmSession"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rtxtChat As RichTextBox
    Friend WithEvents btnSend As Button
    Friend WithEvents txtMessageInput As TextBox
End Class
