<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeaderboard
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
        Me.DGVLeaderboard = New System.Windows.Forms.DataGridView()
        Me.clmUserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmPoints = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DGVLeaderboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGVLeaderboard
        '
        Me.DGVLeaderboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVLeaderboard.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmUserID, Me.clmPoints, Me.Column1})
        Me.DGVLeaderboard.Location = New System.Drawing.Point(-2, 12)
        Me.DGVLeaderboard.Name = "DGVLeaderboard"
        Me.DGVLeaderboard.Size = New System.Drawing.Size(342, 424)
        Me.DGVLeaderboard.TabIndex = 0
        '
        'clmUserID
        '
        Me.clmUserID.HeaderText = "UserID"
        Me.clmUserID.Name = "clmUserID"
        Me.clmUserID.ReadOnly = True
        '
        'clmPoints
        '
        Me.clmPoints.HeaderText = "Points"
        Me.clmPoints.Name = "clmPoints"
        Me.clmPoints.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Percentage Correct"
        Me.Column1.Name = "Column1"
        '
        'frmLeaderboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(338, 435)
        Me.Controls.Add(Me.DGVLeaderboard)
        Me.Name = "frmLeaderboard"
        Me.Text = "frmLeaderboard"
        CType(Me.DGVLeaderboard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGVLeaderboard As DataGridView
    Friend WithEvents clmUserID As DataGridViewTextBoxColumn
    Friend WithEvents clmPoints As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
End Class
