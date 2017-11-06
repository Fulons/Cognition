<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClient
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
        Me.components = New System.ComponentModel.Container()
        Me.rtxtChat = New System.Windows.Forms.RichTextBox()
        Me.lbUsers = New System.Windows.Forms.ListBox()
        Me.txtMessageInput = New System.Windows.Forms.TextBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuChatLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTest1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrConnectionTimeout = New System.Windows.Forms.Timer(Me.components)
        Me.mnuRightClick = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuStartSession = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.mnuRightClick.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtxtChat
        '
        Me.rtxtChat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtxtChat.Location = New System.Drawing.Point(12, 27)
        Me.rtxtChat.Name = "rtxtChat"
        Me.rtxtChat.ReadOnly = True
        Me.rtxtChat.Size = New System.Drawing.Size(583, 421)
        Me.rtxtChat.TabIndex = 0
        Me.rtxtChat.Text = ""
        '
        'lbUsers
        '
        Me.lbUsers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbUsers.FormattingEnabled = True
        Me.lbUsers.Location = New System.Drawing.Point(601, 27)
        Me.lbUsers.Name = "lbUsers"
        Me.lbUsers.Size = New System.Drawing.Size(120, 446)
        Me.lbUsers.TabIndex = 1
        '
        'txtMessageInput
        '
        Me.txtMessageInput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessageInput.Location = New System.Drawing.Point(12, 454)
        Me.txtMessageInput.Name = "txtMessageInput"
        Me.txtMessageInput.Size = New System.Drawing.Size(502, 20)
        Me.txtMessageInput.TabIndex = 2
        '
        'btnSend
        '
        Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSend.Location = New System.Drawing.Point(520, 452)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 23)
        Me.btnSend.TabIndex = 3
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.TestsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(733, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLogin, Me.mnuLogout, Me.mnuChatLog, Me.mnuHelp, Me.mnuExit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'mnuLogin
        '
        Me.mnuLogin.Name = "mnuLogin"
        Me.mnuLogin.Size = New System.Drawing.Size(152, 22)
        Me.mnuLogin.Text = "Login"
        '
        'mnuLogout
        '
        Me.mnuLogout.Name = "mnuLogout"
        Me.mnuLogout.Size = New System.Drawing.Size(152, 22)
        Me.mnuLogout.Text = "Logout"
        '
        'mnuChatLog
        '
        Me.mnuChatLog.Name = "mnuChatLog"
        Me.mnuChatLog.Size = New System.Drawing.Size(152, 22)
        Me.mnuChatLog.Text = "Chat log"
        '
        'mnuHelp
        '
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(152, 22)
        Me.mnuHelp.Text = "Help"
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(152, 22)
        Me.mnuExit.Text = "Exit"
        '
        'TestsToolStripMenuItem
        '
        Me.TestsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTest1})
        Me.TestsToolStripMenuItem.Name = "TestsToolStripMenuItem"
        Me.TestsToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.TestsToolStripMenuItem.Text = "Tests"
        '
        'mnuTest1
        '
        Me.mnuTest1.Name = "mnuTest1"
        Me.mnuTest1.Size = New System.Drawing.Size(171, 22)
        Me.mnuTest1.Text = "Test1(Placeholder)"
        '
        'tmrConnectionTimeout
        '
        Me.tmrConnectionTimeout.Interval = 2000
        '
        'mnuRightClick
        '
        Me.mnuRightClick.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuStartSession})
        Me.mnuRightClick.Name = "mnuRightClick"
        Me.mnuRightClick.Size = New System.Drawing.Size(179, 26)
        '
        'mnuStartSession
        '
        Me.mnuStartSession.Name = "mnuStartSession"
        Me.mnuStartSession.Size = New System.Drawing.Size(178, 22)
        Me.mnuStartSession.Text = "Start private session"
        '
        'frmClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 483)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.txtMessageInput)
        Me.Controls.Add(Me.lbUsers)
        Me.Controls.Add(Me.rtxtChat)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmClient"
        Me.Text = "frmClient"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.mnuRightClick.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rtxtChat As RichTextBox
    Friend WithEvents lbUsers As ListBox
    Friend WithEvents txtMessageInput As TextBox
    Friend WithEvents btnSend As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuLogin As ToolStripMenuItem
    Friend WithEvents mnuLogout As ToolStripMenuItem
    Friend WithEvents mnuChatLog As ToolStripMenuItem
    Friend WithEvents mnuHelp As ToolStripMenuItem
    Friend WithEvents mnuExit As ToolStripMenuItem
    Friend WithEvents tmrConnectionTimeout As Timer
    Friend WithEvents mnuRightClick As ContextMenuStrip
    Friend WithEvents mnuStartSession As ToolStripMenuItem
    Friend WithEvents TestsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuTest1 As ToolStripMenuItem
End Class
