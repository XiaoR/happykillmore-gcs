<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.grpFlightPath = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.tbarFlightOpacity = New System.Windows.Forms.TrackBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkFlightExtrude = New System.Windows.Forms.CheckBox
        Me.cboMapUpdateRate = New System.Windows.Forms.ComboBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.tbarFlightWidth = New System.Windows.Forms.TrackBar
        Me.cmdFlightColor = New System.Windows.Forms.Button
        Me.grpGeneral = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkHeadingReverse = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkYawReverse = New System.Windows.Forms.CheckBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.chkRollReverse = New System.Windows.Forms.CheckBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.chkPitchReverse = New System.Windows.Forms.CheckBox
        Me.cbo3DModel = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.cboMaxSpeed = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboSpeedUnits = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDistanceUnits = New System.Windows.Forms.ComboBox
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.tbarMissionOpacity = New System.Windows.Forms.TrackBar
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkMissionExtrude = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.tbarMissionWidth = New System.Windows.Forms.TrackBar
        Me.cmdMissionColor = New System.Windows.Forms.Button
        Me.grpFlightPath.SuspendLayout()
        CType(Me.tbarFlightOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarFlightWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGeneral.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tbarMissionOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarMissionWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpFlightPath
        '
        Me.grpFlightPath.Controls.Add(Me.Label11)
        Me.grpFlightPath.Controls.Add(Me.tbarFlightOpacity)
        Me.grpFlightPath.Controls.Add(Me.Label1)
        Me.grpFlightPath.Controls.Add(Me.chkFlightExtrude)
        Me.grpFlightPath.Controls.Add(Me.cboMapUpdateRate)
        Me.grpFlightPath.Controls.Add(Me.Label30)
        Me.grpFlightPath.Controls.Add(Me.Label25)
        Me.grpFlightPath.Controls.Add(Me.Label24)
        Me.grpFlightPath.Controls.Add(Me.tbarFlightWidth)
        Me.grpFlightPath.Controls.Add(Me.cmdFlightColor)
        Me.grpFlightPath.Location = New System.Drawing.Point(241, 12)
        Me.grpFlightPath.Name = "grpFlightPath"
        Me.grpFlightPath.Size = New System.Drawing.Size(217, 172)
        Me.grpFlightPath.TabIndex = 47
        Me.grpFlightPath.TabStop = False
        Me.grpFlightPath.Text = "Google Earth Flight Path"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(39, 143)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 55
        Me.Label11.Text = "Path Opacity:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbarFlightOpacity
        '
        Me.tbarFlightOpacity.AutoSize = False
        Me.tbarFlightOpacity.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbarFlightOpacity.LargeChange = 1
        Me.tbarFlightOpacity.Location = New System.Drawing.Point(115, 136)
        Me.tbarFlightOpacity.Maximum = 255
        Me.tbarFlightOpacity.Minimum = 1
        Me.tbarFlightOpacity.Name = "tbarFlightOpacity"
        Me.tbarFlightOpacity.Size = New System.Drawing.Size(90, 28)
        Me.tbarFlightOpacity.TabIndex = 13
        Me.tbarFlightOpacity.TickFrequency = 26
        Me.tbarFlightOpacity.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarFlightOpacity.Value = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(64, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Extrude:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkFlightExtrude
        '
        Me.chkFlightExtrude.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkFlightExtrude.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkFlightExtrude.Location = New System.Drawing.Point(116, 111)
        Me.chkFlightExtrude.Name = "chkFlightExtrude"
        Me.chkFlightExtrude.Size = New System.Drawing.Size(59, 21)
        Me.chkFlightExtrude.TabIndex = 12
        Me.chkFlightExtrude.Text = "No"
        Me.chkFlightExtrude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkFlightExtrude.UseVisualStyleBackColor = True
        '
        'cboMapUpdateRate
        '
        Me.cboMapUpdateRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMapUpdateRate.FormattingEnabled = True
        Me.cboMapUpdateRate.Location = New System.Drawing.Point(116, 25)
        Me.cboMapUpdateRate.Name = "cboMapUpdateRate"
        Me.cboMapUpdateRate.Size = New System.Drawing.Size(65, 21)
        Me.cboMapUpdateRate.TabIndex = 9
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(15, 28)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(95, 13)
        Me.Label30.TabIndex = 50
        Me.Label30.Text = "Map Update Rate:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(26, 86)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(84, 13)
        Me.Label25.TabIndex = 49
        Me.Label25.Text = "Path Thickness:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(23, 57)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(87, 13)
        Me.Label24.TabIndex = 48
        Me.Label24.Text = "Flight Path Color:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbarFlightWidth
        '
        Me.tbarFlightWidth.AutoSize = False
        Me.tbarFlightWidth.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbarFlightWidth.LargeChange = 1
        Me.tbarFlightWidth.Location = New System.Drawing.Point(116, 79)
        Me.tbarFlightWidth.Minimum = 1
        Me.tbarFlightWidth.Name = "tbarFlightWidth"
        Me.tbarFlightWidth.Size = New System.Drawing.Size(90, 28)
        Me.tbarFlightWidth.TabIndex = 11
        Me.tbarFlightWidth.TickFrequency = 26
        Me.tbarFlightWidth.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarFlightWidth.Value = 1
        '
        'cmdFlightColor
        '
        Me.cmdFlightColor.Location = New System.Drawing.Point(116, 50)
        Me.cmdFlightColor.Name = "cmdFlightColor"
        Me.cmdFlightColor.Size = New System.Drawing.Size(90, 23)
        Me.cmdFlightColor.TabIndex = 10
        Me.cmdFlightColor.UseVisualStyleBackColor = False
        '
        'grpGeneral
        '
        Me.grpGeneral.Controls.Add(Me.Label4)
        Me.grpGeneral.Controls.Add(Me.chkHeadingReverse)
        Me.grpGeneral.Controls.Add(Me.Label2)
        Me.grpGeneral.Controls.Add(Me.chkYawReverse)
        Me.grpGeneral.Controls.Add(Me.Label29)
        Me.grpGeneral.Controls.Add(Me.chkRollReverse)
        Me.grpGeneral.Controls.Add(Me.Label27)
        Me.grpGeneral.Controls.Add(Me.chkPitchReverse)
        Me.grpGeneral.Controls.Add(Me.cbo3DModel)
        Me.grpGeneral.Controls.Add(Me.Label21)
        Me.grpGeneral.Controls.Add(Me.cboMaxSpeed)
        Me.grpGeneral.Controls.Add(Me.Label8)
        Me.grpGeneral.Controls.Add(Me.Label7)
        Me.grpGeneral.Controls.Add(Me.cboSpeedUnits)
        Me.grpGeneral.Controls.Add(Me.Label3)
        Me.grpGeneral.Controls.Add(Me.cboDistanceUnits)
        Me.grpGeneral.Location = New System.Drawing.Point(12, 12)
        Me.grpGeneral.Name = "grpGeneral"
        Me.grpGeneral.Size = New System.Drawing.Size(223, 320)
        Me.grpGeneral.TabIndex = 48
        Me.grpGeneral.TabStop = False
        Me.grpGeneral.Text = "General"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(54, 220)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Heading:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkHeadingReverse
        '
        Me.chkHeadingReverse.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkHeadingReverse.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkHeadingReverse.Location = New System.Drawing.Point(110, 213)
        Me.chkHeadingReverse.Name = "chkHeadingReverse"
        Me.chkHeadingReverse.Size = New System.Drawing.Size(69, 24)
        Me.chkHeadingReverse.TabIndex = 8
        Me.chkHeadingReverse.Text = "Normal"
        Me.chkHeadingReverse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkHeadingReverse.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(73, 193)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Yaw:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkYawReverse
        '
        Me.chkYawReverse.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkYawReverse.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkYawReverse.Location = New System.Drawing.Point(111, 186)
        Me.chkYawReverse.Name = "chkYawReverse"
        Me.chkYawReverse.Size = New System.Drawing.Size(69, 24)
        Me.chkYawReverse.TabIndex = 7
        Me.chkYawReverse.Text = "Normal"
        Me.chkYawReverse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkYawReverse.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(76, 166)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(28, 13)
        Me.Label29.TabIndex = 55
        Me.Label29.Text = "Roll:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkRollReverse
        '
        Me.chkRollReverse.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkRollReverse.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkRollReverse.Location = New System.Drawing.Point(110, 159)
        Me.chkRollReverse.Name = "chkRollReverse"
        Me.chkRollReverse.Size = New System.Drawing.Size(69, 24)
        Me.chkRollReverse.TabIndex = 6
        Me.chkRollReverse.Text = "Normal"
        Me.chkRollReverse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkRollReverse.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(70, 138)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 53
        Me.Label27.Text = "Pitch:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkPitchReverse
        '
        Me.chkPitchReverse.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkPitchReverse.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkPitchReverse.Location = New System.Drawing.Point(110, 132)
        Me.chkPitchReverse.Name = "chkPitchReverse"
        Me.chkPitchReverse.Size = New System.Drawing.Size(70, 24)
        Me.chkPitchReverse.TabIndex = 5
        Me.chkPitchReverse.Text = "Normal"
        Me.chkPitchReverse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkPitchReverse.UseVisualStyleBackColor = True
        '
        'cbo3DModel
        '
        Me.cbo3DModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo3DModel.FormattingEnabled = True
        Me.cbo3DModel.Location = New System.Drawing.Point(110, 106)
        Me.cbo3DModel.Name = "cbo3DModel"
        Me.cbo3DModel.Size = New System.Drawing.Size(104, 21)
        Me.cbo3DModel.Sorted = True
        Me.cbo3DModel.TabIndex = 4
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(48, 112)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 13)
        Me.Label21.TabIndex = 50
        Me.Label21.Text = "3D Model:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboMaxSpeed
        '
        Me.cboMaxSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaxSpeed.FormattingEnabled = True
        Me.cboMaxSpeed.Location = New System.Drawing.Point(110, 80)
        Me.cboMaxSpeed.Name = "cboMaxSpeed"
        Me.cboMaxSpeed.Size = New System.Drawing.Size(65, 21)
        Me.cboMaxSpeed.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(40, 85)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = "Max Speed:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(36, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "Speed Units:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSpeedUnits
        '
        Me.cboSpeedUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSpeedUnits.FormattingEnabled = True
        Me.cboSpeedUnits.Location = New System.Drawing.Point(110, 54)
        Me.cboSpeedUnits.Name = "cboSpeedUnits"
        Me.cboSpeedUnits.Size = New System.Drawing.Size(65, 21)
        Me.cboSpeedUnits.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Units of Measure:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboDistanceUnits
        '
        Me.cboDistanceUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistanceUnits.FormattingEnabled = True
        Me.cboDistanceUnits.Location = New System.Drawing.Point(110, 28)
        Me.cboDistanceUnits.Name = "cboDistanceUnits"
        Me.cboDistanceUnits.Size = New System.Drawing.Size(65, 21)
        Me.cboDistanceUnits.TabIndex = 1
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(12, 338)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 18
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(383, 338)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 19
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.tbarMissionOpacity)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.chkMissionExtrude)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.tbarMissionWidth)
        Me.GroupBox1.Controls.Add(Me.cmdMissionColor)
        Me.GroupBox1.Location = New System.Drawing.Point(242, 190)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(216, 142)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mission Path"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(37, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Path Opacity:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbarMissionOpacity
        '
        Me.tbarMissionOpacity.AutoSize = False
        Me.tbarMissionOpacity.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbarMissionOpacity.LargeChange = 1
        Me.tbarMissionOpacity.Location = New System.Drawing.Point(114, 103)
        Me.tbarMissionOpacity.Maximum = 255
        Me.tbarMissionOpacity.Minimum = 1
        Me.tbarMissionOpacity.Name = "tbarMissionOpacity"
        Me.tbarMissionOpacity.Size = New System.Drawing.Size(90, 28)
        Me.tbarMissionOpacity.TabIndex = 17
        Me.tbarMissionOpacity.TickFrequency = 26
        Me.tbarMissionOpacity.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarMissionOpacity.Value = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(62, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Extrude:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkMissionExtrude
        '
        Me.chkMissionExtrude.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkMissionExtrude.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkMissionExtrude.Location = New System.Drawing.Point(114, 80)
        Me.chkMissionExtrude.Name = "chkMissionExtrude"
        Me.chkMissionExtrude.Size = New System.Drawing.Size(59, 21)
        Me.chkMissionExtrude.TabIndex = 16
        Me.chkMissionExtrude.Text = "No"
        Me.chkMissionExtrude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkMissionExtrude.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(24, 55)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 13)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Path Thickness:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 13)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Mission Path Color:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbarMissionWidth
        '
        Me.tbarMissionWidth.AutoSize = False
        Me.tbarMissionWidth.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbarMissionWidth.LargeChange = 1
        Me.tbarMissionWidth.Location = New System.Drawing.Point(114, 48)
        Me.tbarMissionWidth.Minimum = 1
        Me.tbarMissionWidth.Name = "tbarMissionWidth"
        Me.tbarMissionWidth.Size = New System.Drawing.Size(90, 28)
        Me.tbarMissionWidth.TabIndex = 15
        Me.tbarMissionWidth.TickFrequency = 26
        Me.tbarMissionWidth.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarMissionWidth.Value = 1
        '
        'cmdMissionColor
        '
        Me.cmdMissionColor.Location = New System.Drawing.Point(114, 19)
        Me.cmdMissionColor.Name = "cmdMissionColor"
        Me.cmdMissionColor.Size = New System.Drawing.Size(90, 23)
        Me.cmdMissionColor.TabIndex = 14
        Me.cmdMissionColor.UseVisualStyleBackColor = False
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 368)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.grpGeneral)
        Me.Controls.Add(Me.grpFlightPath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.grpFlightPath.ResumeLayout(False)
        Me.grpFlightPath.PerformLayout()
        CType(Me.tbarFlightOpacity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarFlightWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGeneral.ResumeLayout(False)
        Me.grpGeneral.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.tbarMissionOpacity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarMissionWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpFlightPath As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkFlightExtrude As System.Windows.Forms.CheckBox
    Friend WithEvents cboMapUpdateRate As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents tbarFlightWidth As System.Windows.Forms.TrackBar
    Friend WithEvents cmdFlightColor As System.Windows.Forms.Button
    Friend WithEvents grpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents chkRollReverse As System.Windows.Forms.CheckBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents chkPitchReverse As System.Windows.Forms.CheckBox
    Friend WithEvents cbo3DModel As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboMaxSpeed As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboSpeedUnits As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDistanceUnits As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkHeadingReverse As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkYawReverse As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkMissionExtrude As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbarMissionWidth As System.Windows.Forms.TrackBar
    Friend WithEvents cmdMissionColor As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbarFlightOpacity As System.Windows.Forms.TrackBar
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbarMissionOpacity As System.Windows.Forms.TrackBar
End Class
