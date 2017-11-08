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
        Me.pnlTest.Size = New System.Drawing.Size(864, 423)
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
        'frmTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.CornflowerBlue
        Me.ClientSize = New System.Drawing.Size(888, 447)
        Me.Controls.Add(Me.pnlTest)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmTest"
        Me.Text = "frmTest"
        Me.pnlTest.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTest As Panel
    Friend WithEvents tstTest As TestingTest
End Class
