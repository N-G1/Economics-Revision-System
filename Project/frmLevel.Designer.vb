<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLevel
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
        Me.btnBack = New System.Windows.Forms.Button()
        Me.txtQuestionNo = New System.Windows.Forms.TextBox()
        Me.btnShowAns = New System.Windows.Forms.Button()
        Me.grpAnswers = New System.Windows.Forms.GroupBox()
        Me.txtLongAnswer = New System.Windows.Forms.TextBox()
        Me.RadioAns4 = New System.Windows.Forms.RadioButton()
        Me.RadioAns1 = New System.Windows.Forms.RadioButton()
        Me.RadioAns2 = New System.Windows.Forms.RadioButton()
        Me.RadioAns5 = New System.Windows.Forms.RadioButton()
        Me.RadioAns3 = New System.Windows.Forms.RadioButton()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.txtQuestionDisplay = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBeginLevel = New System.Windows.Forms.Button()
        Me.grpAnswers.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(343, 339)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(89, 34)
        Me.btnBack.TabIndex = 1
        Me.btnBack.Text = "Back to level select"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'txtQuestionNo
        '
        Me.txtQuestionNo.BackColor = System.Drawing.SystemColors.Info
        Me.txtQuestionNo.Location = New System.Drawing.Point(77, 58)
        Me.txtQuestionNo.Name = "txtQuestionNo"
        Me.txtQuestionNo.Size = New System.Drawing.Size(268, 20)
        Me.txtQuestionNo.TabIndex = 19
        Me.txtQuestionNo.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txtQuestionNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnShowAns
        '
        Me.btnShowAns.Location = New System.Drawing.Point(90, 297)
        Me.btnShowAns.Name = "btnShowAns"
        Me.btnShowAns.Size = New System.Drawing.Size(96, 23)
        Me.btnShowAns.TabIndex = 18
        Me.btnShowAns.Text = "Show answers"
        Me.btnShowAns.UseVisualStyleBackColor = True
        '
        'grpAnswers
        '
        Me.grpAnswers.Controls.Add(Me.txtLongAnswer)
        Me.grpAnswers.Controls.Add(Me.RadioAns4)
        Me.grpAnswers.Controls.Add(Me.RadioAns1)
        Me.grpAnswers.Controls.Add(Me.RadioAns2)
        Me.grpAnswers.Controls.Add(Me.RadioAns5)
        Me.grpAnswers.Controls.Add(Me.RadioAns3)
        Me.grpAnswers.Location = New System.Drawing.Point(77, 142)
        Me.grpAnswers.Name = "grpAnswers"
        Me.grpAnswers.Size = New System.Drawing.Size(268, 149)
        Me.grpAnswers.TabIndex = 16
        Me.grpAnswers.TabStop = False
        Me.grpAnswers.Text = "Answers"
        '
        'txtLongAnswer
        '
        Me.txtLongAnswer.Location = New System.Drawing.Point(0, 0)
        Me.txtLongAnswer.Multiline = True
        Me.txtLongAnswer.Name = "txtLongAnswer"
        Me.txtLongAnswer.Size = New System.Drawing.Size(268, 149)
        Me.txtLongAnswer.TabIndex = 12
        '
        'RadioAns4
        '
        Me.RadioAns4.AutoSize = True
        Me.RadioAns4.Location = New System.Drawing.Point(6, 97)
        Me.RadioAns4.Name = "RadioAns4"
        Me.RadioAns4.Size = New System.Drawing.Size(90, 17)
        Me.RadioAns4.TabIndex = 7
        Me.RadioAns4.TabStop = True
        Me.RadioAns4.Text = "RadioButton4"
        Me.RadioAns4.UseVisualStyleBackColor = True
        '
        'RadioAns1
        '
        Me.RadioAns1.AutoSize = True
        Me.RadioAns1.Location = New System.Drawing.Point(6, 28)
        Me.RadioAns1.Name = "RadioAns1"
        Me.RadioAns1.Size = New System.Drawing.Size(90, 17)
        Me.RadioAns1.TabIndex = 4
        Me.RadioAns1.TabStop = True
        Me.RadioAns1.Text = "RadioButton1"
        Me.RadioAns1.UseVisualStyleBackColor = True
        '
        'RadioAns2
        '
        Me.RadioAns2.AutoSize = True
        Me.RadioAns2.Location = New System.Drawing.Point(6, 51)
        Me.RadioAns2.Name = "RadioAns2"
        Me.RadioAns2.Size = New System.Drawing.Size(90, 17)
        Me.RadioAns2.TabIndex = 5
        Me.RadioAns2.TabStop = True
        Me.RadioAns2.Text = "RadioButton2"
        Me.RadioAns2.UseVisualStyleBackColor = True
        '
        'RadioAns5
        '
        Me.RadioAns5.AutoSize = True
        Me.RadioAns5.Location = New System.Drawing.Point(6, 120)
        Me.RadioAns5.Name = "RadioAns5"
        Me.RadioAns5.Size = New System.Drawing.Size(90, 17)
        Me.RadioAns5.TabIndex = 8
        Me.RadioAns5.TabStop = True
        Me.RadioAns5.Text = "RadioButton5"
        Me.RadioAns5.UseVisualStyleBackColor = True
        '
        'RadioAns3
        '
        Me.RadioAns3.AutoSize = True
        Me.RadioAns3.Location = New System.Drawing.Point(6, 74)
        Me.RadioAns3.Name = "RadioAns3"
        Me.RadioAns3.Size = New System.Drawing.Size(90, 17)
        Me.RadioAns3.TabIndex = 6
        Me.RadioAns3.TabStop = True
        Me.RadioAns3.Text = "RadioButton3"
        Me.RadioAns3.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(231, 297)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(94, 23)
        Me.btnNext.TabIndex = 15
        Me.btnNext.Text = "Next Question"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'txtQuestionDisplay
        '
        Me.txtQuestionDisplay.BackColor = System.Drawing.SystemColors.Info
        Me.txtQuestionDisplay.Location = New System.Drawing.Point(77, 84)
        Me.txtQuestionDisplay.Multiline = True
        Me.txtQuestionDisplay.Name = "txtQuestionDisplay"
        Me.txtQuestionDisplay.Size = New System.Drawing.Size(268, 52)
        Me.txtQuestionDisplay.TabIndex = 17
        Me.txtQuestionDisplay.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txtQuestionDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Label1"
        '
        'btnBeginLevel
        '
        Me.btnBeginLevel.Location = New System.Drawing.Point(127, 339)
        Me.btnBeginLevel.Name = "btnBeginLevel"
        Me.btnBeginLevel.Size = New System.Drawing.Size(161, 28)
        Me.btnBeginLevel.TabIndex = 21
        Me.btnBeginLevel.UseVisualStyleBackColor = True
        '
        'frmLevel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 379)
        Me.Controls.Add(Me.btnBeginLevel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtQuestionNo)
        Me.Controls.Add(Me.btnShowAns)
        Me.Controls.Add(Me.grpAnswers)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.txtQuestionDisplay)
        Me.Controls.Add(Me.btnBack)
        Me.Name = "frmLevel"
        Me.Text = "frmLevel"
        Me.grpAnswers.ResumeLayout(False)
        Me.grpAnswers.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBack As Button
    Friend WithEvents txtQuestionNo As TextBox
    Friend WithEvents btnShowAns As Button
    Friend WithEvents grpAnswers As GroupBox
    Friend WithEvents txtLongAnswer As TextBox
    Friend WithEvents RadioAns4 As RadioButton
    Friend WithEvents RadioAns1 As RadioButton
    Friend WithEvents RadioAns2 As RadioButton
    Friend WithEvents RadioAns5 As RadioButton
    Friend WithEvents RadioAns3 As RadioButton
    Friend WithEvents btnNext As Button
    Friend WithEvents txtQuestionDisplay As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBeginLevel As Button
End Class
