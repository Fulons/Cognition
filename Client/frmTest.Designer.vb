<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTest
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlTest = New System.Windows.Forms.Panel()
        Me.tstTest = New Client.TestingTest()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.btnFinish = New System.Windows.Forms.Button()
        Me.pnlTest.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTest
        '
        Me.pnlTest.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTest.Controls.Add(Me.tstTest)
        Me.pnlTest.Location = New System.Drawing.Point(12, 12)
        Me.pnlTest.Name = "pnlTest"
        Me.pnlTest.Size = New System.Drawing.Size(864, 450)
        Me.pnlTest.TabIndex = 0
        '
        'tstTest
        '
        Me.tstTest.AllowDrop = True
        Me.tstTest.Location = New System.Drawing.Point(3, 3)
        Me.tstTest.Name = "tstTest"
        Me.tstTest.Size = New System.Drawing.Size(786, 847)
        Me.tstTest.TabIndex = 0
        '
        'btnQuit
        '
        Me.btnQuit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnQuit.Location = New System.Drawing.Point(12, 468)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(75, 23)
        Me.btnQuit.TabIndex = 1
        Me.btnQuit.Text = "Quit"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'btnFinish
        '
        Me.btnFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFinish.Location = New System.Drawing.Point(801, 468)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(75, 23)
        Me.btnFinish.TabIndex = 2
        Me.btnFinish.Text = "Finish"
        Me.btnFinish.UseVisualStyleBackColor = True
        '
        'frmTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(888, 503)
        Me.Controls.Add(Me.btnFinish)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.pnlTest)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmTest"
        Me.Text = "frmTest"
        Me.pnlTest.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTest As Panel
    Friend WithEvents btnQuit As Button
    Friend WithEvents btnFinish As Button
    Friend WithEvents tstTest As TestingTest
End Class
