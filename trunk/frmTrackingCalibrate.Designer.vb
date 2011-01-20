<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrackingCalibrate
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
        Me.cboLeft = New System.Windows.Forms.ComboBox
        Me.tbarUp = New System.Windows.Forms.TrackBar
        Me.tbarLeft = New System.Windows.Forms.TrackBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboRight = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboDown = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboUp = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.tbarDown = New System.Windows.Forms.TrackBar
        Me.tbarRight = New System.Windows.Forms.TrackBar
        Me.lblLeft = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblRight = New System.Windows.Forms.Label
        Me.lblUp = New System.Windows.Forms.Label
        Me.lblDown = New System.Windows.Forms.Label
        Me.chkBackLobe = New System.Windows.Forms.CheckBox
        Me.cmdCenterTilt = New System.Windows.Forms.Button
        Me.cmdCenterPan = New System.Windows.Forms.Button
        Me.lblTiltServo = New System.Windows.Forms.Label
        Me.cboTiltServo = New System.Windows.Forms.ComboBox
        Me.lblPanServo = New System.Windows.Forms.Label
        Me.cboPanServo = New System.Windows.Forms.ComboBox
        Me.lblMiniSSCNote = New System.Windows.Forms.Label
        CType(Me.tbarUp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboLeft
        '
        Me.cboLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLeft.FormattingEnabled = True
        Me.cboLeft.Location = New System.Drawing.Point(73, 33)
        Me.cboLeft.Name = "cboLeft"
        Me.cboLeft.Size = New System.Drawing.Size(58, 21)
        Me.cboLeft.TabIndex = 58
        '
        'tbarUp
        '
        Me.tbarUp.AutoSize = False
        Me.tbarUp.BackColor = System.Drawing.Color.White
        Me.tbarUp.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarUp.LargeChange = 1
        Me.tbarUp.Location = New System.Drawing.Point(135, 123)
        Me.tbarUp.Maximum = 2750
        Me.tbarUp.Minimum = 250
        Me.tbarUp.Name = "tbarUp"
        Me.tbarUp.Size = New System.Drawing.Size(332, 18)
        Me.tbarUp.TabIndex = 57
        Me.tbarUp.TabStop = False
        Me.tbarUp.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarUp.Value = 1500
        '
        'tbarLeft
        '
        Me.tbarLeft.AutoSize = False
        Me.tbarLeft.BackColor = System.Drawing.Color.White
        Me.tbarLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarLeft.LargeChange = 1
        Me.tbarLeft.Location = New System.Drawing.Point(135, 33)
        Me.tbarLeft.Maximum = 2750
        Me.tbarLeft.Minimum = 250
        Me.tbarLeft.Name = "tbarLeft"
        Me.tbarLeft.Size = New System.Drawing.Size(332, 18)
        Me.tbarLeft.TabIndex = 56
        Me.tbarLeft.TabStop = False
        Me.tbarLeft.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarLeft.Value = 1500
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 21)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "Left:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 21)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Right:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboRight
        '
        Me.cboRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRight.FormattingEnabled = True
        Me.cboRight.Location = New System.Drawing.Point(73, 59)
        Me.cboRight.Name = "cboRight"
        Me.cboRight.Size = New System.Drawing.Size(58, 21)
        Me.cboRight.TabIndex = 60
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(134, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(332, 21)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Pan end-point calibration"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 21)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "Down:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboDown
        '
        Me.cboDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDown.FormattingEnabled = True
        Me.cboDown.Location = New System.Drawing.Point(73, 147)
        Me.cboDown.Name = "cboDown"
        Me.cboDown.Size = New System.Drawing.Size(58, 21)
        Me.cboDown.TabIndex = 65
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(6, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 21)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Up:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboUp
        '
        Me.cboUp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUp.FormattingEnabled = True
        Me.cboUp.Location = New System.Drawing.Point(73, 120)
        Me.cboUp.Name = "cboUp"
        Me.cboUp.Size = New System.Drawing.Size(58, 21)
        Me.cboUp.TabIndex = 63
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(132, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(332, 21)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "Tilt end-point calibration"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbarDown
        '
        Me.tbarDown.AutoSize = False
        Me.tbarDown.BackColor = System.Drawing.Color.White
        Me.tbarDown.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarDown.LargeChange = 1
        Me.tbarDown.Location = New System.Drawing.Point(135, 148)
        Me.tbarDown.Maximum = 2750
        Me.tbarDown.Minimum = 250
        Me.tbarDown.Name = "tbarDown"
        Me.tbarDown.Size = New System.Drawing.Size(332, 18)
        Me.tbarDown.TabIndex = 68
        Me.tbarDown.TabStop = False
        Me.tbarDown.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarDown.Value = 1500
        '
        'tbarRight
        '
        Me.tbarRight.AutoSize = False
        Me.tbarRight.BackColor = System.Drawing.Color.White
        Me.tbarRight.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarRight.LargeChange = 1
        Me.tbarRight.Location = New System.Drawing.Point(135, 60)
        Me.tbarRight.Maximum = 2750
        Me.tbarRight.Minimum = 250
        Me.tbarRight.Name = "tbarRight"
        Me.tbarRight.Size = New System.Drawing.Size(332, 18)
        Me.tbarRight.TabIndex = 69
        Me.tbarRight.TabStop = False
        Me.tbarRight.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarRight.Value = 1500
        '
        'lblLeft
        '
        Me.lblLeft.Location = New System.Drawing.Point(473, 33)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(48, 21)
        Me.lblLeft.TabIndex = 70
        Me.lblLeft.Text = "1500"
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(98, 255)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(369, 36)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Warning!! Be CAREFUL when adjusting the sliders. Some servos may be damaged by ch" & _
            "anging the values too much!"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdSave
        '
        Me.cmdSave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdSave.Location = New System.Drawing.Point(12, 268)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(70, 23)
        Me.cmdSave.TabIndex = 72
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCancel.Location = New System.Drawing.Point(476, 268)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(70, 23)
        Me.cmdCancel.TabIndex = 73
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(70, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 21)
        Me.Label8.TabIndex = 74
        Me.Label8.Text = "Angle"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(473, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 21)
        Me.Label9.TabIndex = 75
        Me.Label9.Text = "Servo"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRight
        '
        Me.lblRight.Location = New System.Drawing.Point(473, 59)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(48, 21)
        Me.lblRight.TabIndex = 76
        Me.lblRight.Text = "1500"
        Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUp
        '
        Me.lblUp.Location = New System.Drawing.Point(473, 123)
        Me.lblUp.Name = "lblUp"
        Me.lblUp.Size = New System.Drawing.Size(48, 21)
        Me.lblUp.TabIndex = 77
        Me.lblUp.Text = "1500"
        Me.lblUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDown
        '
        Me.lblDown.Location = New System.Drawing.Point(473, 147)
        Me.lblDown.Name = "lblDown"
        Me.lblDown.Size = New System.Drawing.Size(48, 21)
        Me.lblDown.TabIndex = 78
        Me.lblDown.Text = "1500"
        Me.lblDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkBackLobe
        '
        Me.chkBackLobe.Location = New System.Drawing.Point(135, 176)
        Me.chkBackLobe.Name = "chkBackLobe"
        Me.chkBackLobe.Size = New System.Drawing.Size(332, 21)
        Me.chkBackLobe.TabIndex = 79
        Me.chkBackLobe.Text = "Use side && back lobes when flying behind antenna"
        Me.chkBackLobe.UseVisualStyleBackColor = True
        '
        'cmdCenterTilt
        '
        Me.cmdCenterTilt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCenterTilt.Location = New System.Drawing.Point(137, 97)
        Me.cmdCenterTilt.Name = "cmdCenterTilt"
        Me.cmdCenterTilt.Size = New System.Drawing.Size(58, 23)
        Me.cmdCenterTilt.TabIndex = 80
        Me.cmdCenterTilt.Text = "Center"
        Me.cmdCenterTilt.UseVisualStyleBackColor = True
        '
        'cmdCenterPan
        '
        Me.cmdCenterPan.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCenterPan.Location = New System.Drawing.Point(135, 7)
        Me.cmdCenterPan.Name = "cmdCenterPan"
        Me.cmdCenterPan.Size = New System.Drawing.Size(58, 23)
        Me.cmdCenterPan.TabIndex = 81
        Me.cmdCenterPan.Text = "Center"
        Me.cmdCenterPan.UseVisualStyleBackColor = True
        '
        'lblTiltServo
        '
        Me.lblTiltServo.Location = New System.Drawing.Point(277, 200)
        Me.lblTiltServo.Name = "lblTiltServo"
        Me.lblTiltServo.Size = New System.Drawing.Size(96, 21)
        Me.lblTiltServo.TabIndex = 85
        Me.lblTiltServo.Text = "Tilt Servo:"
        Me.lblTiltServo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboTiltServo
        '
        Me.cboTiltServo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTiltServo.FormattingEnabled = True
        Me.cboTiltServo.Location = New System.Drawing.Point(379, 200)
        Me.cboTiltServo.Name = "cboTiltServo"
        Me.cboTiltServo.Size = New System.Drawing.Size(58, 21)
        Me.cboTiltServo.TabIndex = 84
        '
        'lblPanServo
        '
        Me.lblPanServo.Location = New System.Drawing.Point(105, 200)
        Me.lblPanServo.Name = "lblPanServo"
        Me.lblPanServo.Size = New System.Drawing.Size(96, 21)
        Me.lblPanServo.TabIndex = 83
        Me.lblPanServo.Text = "Pan Servo:"
        Me.lblPanServo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboPanServo
        '
        Me.cboPanServo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPanServo.FormattingEnabled = True
        Me.cboPanServo.Location = New System.Drawing.Point(207, 200)
        Me.cboPanServo.Name = "cboPanServo"
        Me.cboPanServo.Size = New System.Drawing.Size(58, 21)
        Me.cboPanServo.TabIndex = 82
        '
        'lblMiniSSCNote
        '
        Me.lblMiniSSCNote.Location = New System.Drawing.Point(11, 226)
        Me.lblMiniSSCNote.Name = "lblMiniSSCNote"
        Me.lblMiniSSCNote.Size = New System.Drawing.Size(534, 20)
        Me.lblMiniSSCNote.TabIndex = 86
        Me.lblMiniSSCNote.Text = "Note: For MiniSSC, add 8 to your servo number to double your travel"
        Me.lblMiniSSCNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmTrackingCalibrate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 303)
        Me.Controls.Add(Me.lblMiniSSCNote)
        Me.Controls.Add(Me.lblTiltServo)
        Me.Controls.Add(Me.cboTiltServo)
        Me.Controls.Add(Me.lblPanServo)
        Me.Controls.Add(Me.cboPanServo)
        Me.Controls.Add(Me.cmdCenterPan)
        Me.Controls.Add(Me.cmdCenterTilt)
        Me.Controls.Add(Me.chkBackLobe)
        Me.Controls.Add(Me.lblDown)
        Me.Controls.Add(Me.lblUp)
        Me.Controls.Add(Me.lblRight)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblLeft)
        Me.Controls.Add(Me.tbarRight)
        Me.Controls.Add(Me.tbarDown)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboDown)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboUp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboRight)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboLeft)
        Me.Controls.Add(Me.tbarUp)
        Me.Controls.Add(Me.tbarLeft)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmTrackingCalibrate"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Tracking Calibrate"
        CType(Me.tbarUp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboLeft As System.Windows.Forms.ComboBox
    Friend WithEvents tbarUp As System.Windows.Forms.TrackBar
    Friend WithEvents tbarLeft As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboRight As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboDown As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboUp As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbarDown As System.Windows.Forms.TrackBar
    Friend WithEvents tbarRight As System.Windows.Forms.TrackBar
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblRight As System.Windows.Forms.Label
    Friend WithEvents lblUp As System.Windows.Forms.Label
    Friend WithEvents lblDown As System.Windows.Forms.Label
    Friend WithEvents chkBackLobe As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCenterTilt As System.Windows.Forms.Button
    Friend WithEvents cmdCenterPan As System.Windows.Forms.Button
    Friend WithEvents lblTiltServo As System.Windows.Forms.Label
    Friend WithEvents cboTiltServo As System.Windows.Forms.ComboBox
    Friend WithEvents lblPanServo As System.Windows.Forms.Label
    Friend WithEvents cboPanServo As System.Windows.Forms.ComboBox
    Friend WithEvents lblMiniSSCNote As System.Windows.Forms.Label
End Class
