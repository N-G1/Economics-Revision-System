<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTeachervb
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
        Me.DVGDisplay = New System.Windows.Forms.DataGridView()
        Me.cmbTableSelect = New System.Windows.Forms.ComboBox()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.grpSelect = New System.Windows.Forms.GroupBox()
        Me.grpFilter = New System.Windows.Forms.GroupBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.btnShowAll = New System.Windows.Forms.Button()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpDelete = New System.Windows.Forms.GroupBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.txtDelete = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.grpUpdate = New System.Windows.Forms.GroupBox()
        Me.txtUpdateNew = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtUpdateKey = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUpdateValue = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.btnStats = New System.Windows.Forms.Button()
        CType(Me.DVGDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSelect.SuspendLayout()
        Me.grpFilter.SuspendLayout()
        Me.grpDelete.SuspendLayout()
        Me.grpUpdate.SuspendLayout()
        Me.SuspendLayout()
        '
        'DVGDisplay
        '
        Me.DVGDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DVGDisplay.Location = New System.Drawing.Point(18, 12)
        Me.DVGDisplay.Name = "DVGDisplay"
        Me.DVGDisplay.Size = New System.Drawing.Size(940, 305)
        Me.DVGDisplay.TabIndex = 0
        '
        'cmbTableSelect
        '
        Me.cmbTableSelect.FormattingEnabled = True
        Me.cmbTableSelect.Items.AddRange(New Object() {"Members", "Questions", "Levels", "LevelUser", "SmartQuiz"})
        Me.cmbTableSelect.Location = New System.Drawing.Point(6, 24)
        Me.cmbTableSelect.Name = "cmbTableSelect"
        Me.cmbTableSelect.Size = New System.Drawing.Size(133, 21)
        Me.cmbTableSelect.TabIndex = 1
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(6, 50)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(96, 26)
        Me.btnSelect.TabIndex = 2
        Me.btnSelect.Text = "Select"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'grpSelect
        '
        Me.grpSelect.Controls.Add(Me.btnSelect)
        Me.grpSelect.Controls.Add(Me.cmbTableSelect)
        Me.grpSelect.Location = New System.Drawing.Point(12, 323)
        Me.grpSelect.Name = "grpSelect"
        Me.grpSelect.Size = New System.Drawing.Size(148, 101)
        Me.grpSelect.TabIndex = 3
        Me.grpSelect.TabStop = False
        Me.grpSelect.Text = "Select table"
        '
        'grpFilter
        '
        Me.grpFilter.Controls.Add(Me.btnFilter)
        Me.grpFilter.Controls.Add(Me.btnShowAll)
        Me.grpFilter.Controls.Add(Me.txtFilter)
        Me.grpFilter.Controls.Add(Me.Label1)
        Me.grpFilter.Location = New System.Drawing.Point(166, 323)
        Me.grpFilter.Name = "grpFilter"
        Me.grpFilter.Size = New System.Drawing.Size(227, 101)
        Me.grpFilter.TabIndex = 4
        Me.grpFilter.TabStop = False
        Me.grpFilter.Text = "Filter by"
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(125, 50)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(96, 26)
        Me.btnFilter.TabIndex = 4
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'btnShowAll
        '
        Me.btnShowAll.Location = New System.Drawing.Point(19, 50)
        Me.btnShowAll.Name = "btnShowAll"
        Me.btnShowAll.Size = New System.Drawing.Size(96, 26)
        Me.btnShowAll.TabIndex = 3
        Me.btnShowAll.Text = "Show all"
        Me.btnShowAll.UseVisualStyleBackColor = True
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(84, 24)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(136, 20)
        Me.txtFilter.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Primary Key:"
        '
        'grpDelete
        '
        Me.grpDelete.Controls.Add(Me.btnDelete)
        Me.grpDelete.Controls.Add(Me.txtDelete)
        Me.grpDelete.Controls.Add(Me.Label2)
        Me.grpDelete.Location = New System.Drawing.Point(399, 323)
        Me.grpDelete.Name = "grpDelete"
        Me.grpDelete.Size = New System.Drawing.Size(229, 101)
        Me.grpDelete.TabIndex = 5
        Me.grpDelete.TabStop = False
        Me.grpDelete.Text = "Delete a record"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(127, 50)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(96, 26)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'txtDelete
        '
        Me.txtDelete.Location = New System.Drawing.Point(84, 24)
        Me.txtDelete.Name = "txtDelete"
        Me.txtDelete.Size = New System.Drawing.Size(136, 20)
        Me.txtDelete.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Primary Key:"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(219, 126)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(96, 26)
        Me.btnUpdate.TabIndex = 3
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'grpUpdate
        '
        Me.grpUpdate.Controls.Add(Me.txtUpdateNew)
        Me.grpUpdate.Controls.Add(Me.Label5)
        Me.grpUpdate.Controls.Add(Me.txtUpdateKey)
        Me.grpUpdate.Controls.Add(Me.Label4)
        Me.grpUpdate.Controls.Add(Me.txtUpdateValue)
        Me.grpUpdate.Controls.Add(Me.Label3)
        Me.grpUpdate.Controls.Add(Me.btnUpdate)
        Me.grpUpdate.Location = New System.Drawing.Point(634, 323)
        Me.grpUpdate.Name = "grpUpdate"
        Me.grpUpdate.Size = New System.Drawing.Size(324, 164)
        Me.grpUpdate.TabIndex = 6
        Me.grpUpdate.TabStop = False
        Me.grpUpdate.Text = "Update a record"
        '
        'txtUpdateNew
        '
        Me.txtUpdateNew.Location = New System.Drawing.Point(179, 100)
        Me.txtUpdateNew.Name = "txtUpdateNew"
        Me.txtUpdateNew.Size = New System.Drawing.Size(136, 20)
        Me.txtUpdateNew.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "New value"
        '
        'txtUpdateKey
        '
        Me.txtUpdateKey.Location = New System.Drawing.Point(179, 28)
        Me.txtUpdateKey.Name = "txtUpdateKey"
        Me.txtUpdateKey.Size = New System.Drawing.Size(136, 20)
        Me.txtUpdateKey.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Primary Key:"
        '
        'txtUpdateValue
        '
        Me.txtUpdateValue.Location = New System.Drawing.Point(179, 63)
        Me.txtUpdateValue.Name = "txtUpdateValue"
        Me.txtUpdateValue.Size = New System.Drawing.Size(136, 20)
        Me.txtUpdateValue.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(157, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "What would you like to update?"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(18, 449)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(76, 24)
        Me.btnClear.TabIndex = 7
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(526, 449)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(102, 24)
        Me.btnCreate.TabIndex = 8
        Me.btnCreate.Text = "Create Question"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'btnStats
        '
        Me.btnStats.Location = New System.Drawing.Point(373, 449)
        Me.btnStats.Name = "btnStats"
        Me.btnStats.Size = New System.Drawing.Size(147, 24)
        Me.btnStats.TabIndex = 9
        Me.btnStats.Text = "View user statistics"
        Me.btnStats.UseVisualStyleBackColor = True
        '
        'frmTeachervb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(966, 493)
        Me.Controls.Add(Me.btnStats)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.grpUpdate)
        Me.Controls.Add(Me.grpDelete)
        Me.Controls.Add(Me.grpFilter)
        Me.Controls.Add(Me.grpSelect)
        Me.Controls.Add(Me.DVGDisplay)
        Me.Name = "frmTeachervb"
        Me.Text = "TeacherFormvb"
        CType(Me.DVGDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSelect.ResumeLayout(False)
        Me.grpFilter.ResumeLayout(False)
        Me.grpFilter.PerformLayout()
        Me.grpDelete.ResumeLayout(False)
        Me.grpDelete.PerformLayout()
        Me.grpUpdate.ResumeLayout(False)
        Me.grpUpdate.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DVGDisplay As DataGridView
    Friend WithEvents cmbTableSelect As ComboBox
    Friend WithEvents btnSelect As Button
    Friend WithEvents grpSelect As GroupBox
    Friend WithEvents grpFilter As GroupBox
    Friend WithEvents btnFilter As Button
    Friend WithEvents btnShowAll As Button
    Friend WithEvents txtFilter As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents grpDelete As GroupBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents txtDelete As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents grpUpdate As GroupBox
    Friend WithEvents txtUpdateValue As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtUpdateKey As TextBox
    Friend WithEvents txtUpdateNew As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents btnCreate As Button
    Friend WithEvents btnStats As Button
End Class
