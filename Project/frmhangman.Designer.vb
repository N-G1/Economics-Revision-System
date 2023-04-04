<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmhangman
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmhangman))
        Me.btnBeginSTART = New System.Windows.Forms.Button()
        Me.txtBeginSTART = New System.Windows.Forms.TextBox()
        Me.txtGuess = New System.Windows.Forms.TextBox()
        Me.ImgListHangman = New System.Windows.Forms.ImageList(Me.components)
        Me.picHangman = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnEnter = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lstGuessedLetters = New System.Windows.Forms.ListBox()
        Me.lblWord = New System.Windows.Forms.Label()
        Me.txtHold = New System.Windows.Forms.TextBox()
        CType(Me.picHangman, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBeginSTART
        '
        Me.btnBeginSTART.Location = New System.Drawing.Point(217, 204)
        Me.btnBeginSTART.Name = "btnBeginSTART"
        Me.btnBeginSTART.Size = New System.Drawing.Size(75, 23)
        Me.btnBeginSTART.TabIndex = 0
        Me.btnBeginSTART.Text = "Begin"
        Me.btnBeginSTART.UseVisualStyleBackColor = True
        '
        'txtBeginSTART
        '
        Me.txtBeginSTART.BackColor = System.Drawing.SystemColors.Info
        Me.txtBeginSTART.Location = New System.Drawing.Point(217, 137)
        Me.txtBeginSTART.Multiline = True
        Me.txtBeginSTART.Name = "txtBeginSTART"
        Me.txtBeginSTART.Size = New System.Drawing.Size(167, 61)
        Me.txtBeginSTART.TabIndex = 1
        Me.txtBeginSTART.Text = "Welcome to the hangman minigame, test your economics " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "knowledge with the followi" &
    "ng game!"
        Me.txtBeginSTART.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtGuess
        '
        Me.txtGuess.Location = New System.Drawing.Point(298, 248)
        Me.txtGuess.Name = "txtGuess"
        Me.txtGuess.Size = New System.Drawing.Size(59, 20)
        Me.txtGuess.TabIndex = 3
        '
        'ImgListHangman
        '
        Me.ImgListHangman.ImageStream = CType(resources.GetObject("ImgListHangman.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgListHangman.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgListHangman.Images.SetKeyName(0, "1.png")
        Me.ImgListHangman.Images.SetKeyName(1, "2.png")
        Me.ImgListHangman.Images.SetKeyName(2, "3.png")
        Me.ImgListHangman.Images.SetKeyName(3, "4.png")
        Me.ImgListHangman.Images.SetKeyName(4, "5.png")
        Me.ImgListHangman.Images.SetKeyName(5, "6.png")
        Me.ImgListHangman.Images.SetKeyName(6, "7.png")
        '
        'picHangman
        '
        Me.picHangman.Location = New System.Drawing.Point(12, 12)
        Me.picHangman.Name = "picHangman"
        Me.picHangman.Size = New System.Drawing.Size(256, 256)
        Me.picHangman.TabIndex = 4
        Me.picHangman.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(274, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Currently guessed letters:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(526, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(322, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Word"
        '
        'btnEnter
        '
        Me.btnEnter.Location = New System.Drawing.Point(363, 248)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(75, 20)
        Me.btnEnter.TabIndex = 10
        Me.btnEnter.Text = "Enter Letter"
        Me.btnEnter.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(309, 204)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 11
        Me.btnExit.Text = "Quit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lstGuessedLetters
        '
        Me.lstGuessedLetters.FormattingEnabled = True
        Me.lstGuessedLetters.Location = New System.Drawing.Point(277, 29)
        Me.lstGuessedLetters.Name = "lstGuessedLetters"
        Me.lstGuessedLetters.Size = New System.Drawing.Size(288, 30)
        Me.lstGuessedLetters.TabIndex = 12
        '
        'lblWord
        '
        Me.lblWord.BackColor = System.Drawing.SystemColors.Info
        Me.lblWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWord.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWord.Location = New System.Drawing.Point(322, 137)
        Me.lblWord.Name = "lblWord"
        Me.lblWord.Size = New System.Drawing.Size(185, 22)
        Me.lblWord.TabIndex = 13
        Me.lblWord.Text = "Label4"
        '
        'txtHold
        '
        Me.txtHold.Location = New System.Drawing.Point(338, 78)
        Me.txtHold.Name = "txtHold"
        Me.txtHold.Size = New System.Drawing.Size(100, 20)
        Me.txtHold.TabIndex = 14
        '
        'frmhangman
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 321)
        Me.Controls.Add(Me.txtHold)
        Me.Controls.Add(Me.lblWord)
        Me.Controls.Add(Me.lstGuessedLetters)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnEnter)
        Me.Controls.Add(Me.btnBeginSTART)
        Me.Controls.Add(Me.txtBeginSTART)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picHangman)
        Me.Controls.Add(Me.txtGuess)
        Me.Name = "frmhangman"
        Me.Text = "frmhangman"
        CType(Me.picHangman, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnBeginSTART As Button
    Friend WithEvents txtBeginSTART As TextBox
    Friend WithEvents txtGuess As TextBox
    Friend WithEvents ImgListHangman As ImageList
    Friend WithEvents picHangman As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnEnter As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents lstGuessedLetters As ListBox
    Friend WithEvents lblWord As Label
    Friend WithEvents txtHold As TextBox
End Class
