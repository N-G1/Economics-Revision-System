<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelect
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
        Me.btnMicro = New System.Windows.Forms.Button()
        Me.btnMacro = New System.Windows.Forms.Button()
        Me.btnLogOut = New System.Windows.Forms.Button()
        Me.btnLeaderboard = New System.Windows.Forms.Button()
        Me.btnSmart = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnMicro
        '
        Me.btnMicro.Location = New System.Drawing.Point(39, 179)
        Me.btnMicro.Name = "btnMicro"
        Me.btnMicro.Size = New System.Drawing.Size(258, 203)
        Me.btnMicro.TabIndex = 0
        Me.btnMicro.Text = "Microeconomics"
        Me.btnMicro.UseVisualStyleBackColor = True
        '
        'btnMacro
        '
        Me.btnMacro.Location = New System.Drawing.Point(393, 179)
        Me.btnMacro.Name = "btnMacro"
        Me.btnMacro.Size = New System.Drawing.Size(258, 203)
        Me.btnMacro.TabIndex = 2
        Me.btnMacro.Text = "Macroecomics"
        Me.btnMacro.UseVisualStyleBackColor = True
        '
        'btnLogOut
        '
        Me.btnLogOut.Location = New System.Drawing.Point(612, 411)
        Me.btnLogOut.Name = "btnLogOut"
        Me.btnLogOut.Size = New System.Drawing.Size(91, 27)
        Me.btnLogOut.TabIndex = 4
        Me.btnLogOut.Text = "Log Out"
        Me.btnLogOut.UseVisualStyleBackColor = True
        '
        'btnLeaderboard
        '
        Me.btnLeaderboard.Location = New System.Drawing.Point(612, 12)
        Me.btnLeaderboard.Name = "btnLeaderboard"
        Me.btnLeaderboard.Size = New System.Drawing.Size(91, 27)
        Me.btnLeaderboard.TabIndex = 5
        Me.btnLeaderboard.Text = "Leaderboard"
        Me.btnLeaderboard.UseVisualStyleBackColor = True
        '
        'btnSmart
        '
        Me.btnSmart.Location = New System.Drawing.Point(514, 12)
        Me.btnSmart.Name = "btnSmart"
        Me.btnSmart.Size = New System.Drawing.Size(92, 27)
        Me.btnSmart.TabIndex = 6
        Me.btnSmart.Text = "Smart Quiz"
        Me.btnSmart.UseVisualStyleBackColor = True
        '
        'frmSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 450)
        Me.Controls.Add(Me.btnSmart)
        Me.Controls.Add(Me.btnLeaderboard)
        Me.Controls.Add(Me.btnLogOut)
        Me.Controls.Add(Me.btnMacro)
        Me.Controls.Add(Me.btnMicro)
        Me.Name = "frmSelect"
        Me.Text = "frmSelectTopic"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnMicro As Button
    Friend WithEvents btnMacro As Button
    Friend WithEvents btnLogOut As Button
    Friend WithEvents btnLeaderboard As Button
    Friend WithEvents btnSmart As Button
End Class
