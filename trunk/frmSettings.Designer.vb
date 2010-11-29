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
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkFlightExtrude = New System.Windows.Forms.CheckBox
        Me.cboMapUpdateRate = New System.Windows.Forms.ComboBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.tbarFlightWidth = New System.Windows.Forms.TrackBar
        Me.cmdFlightColor = New System.Windows.Forms.Button
        Me.grpGeneral = New System.Windows.Forms.GroupBox
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
        Me.grpFlightPath.SuspendLayout()
        CType(Me.tbarFlightWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGeneral.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpFlightPath
        '
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
        Me.grpFlightPath.Size = New System.Drawing.Size(228, 152)
        Me.grpFlightPath.TabIndex = 47
        Me.grpFlightPath.TabStop = False
        Me.grpFlightPath.Text = "Google Earth Flight Path"
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
        Me.chkFlightExtrude.TabIndex = 52
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
        Me.cboMapUpdateRate.TabIndex = 51
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
        Me.tbarFlightWidth.TabIndex = 47
        Me.tbarFlightWidth.TickFrequency = 26
        Me.tbarFlightWidth.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarFlightWidth.Value = 1
        '
        'cmdFlightColor
        '
        Me.cmdFlightColor.Location = New System.Drawing.Point(116, 50)
        Me.cmdFlightColor.Name = "cmdFlightColor"
        Me.cmdFlightColor.Size = New System.Drawing.Size(90, 23)
        Me.cmdFlightColor.TabIndex = 46
        Me.cmdFlightColor.UseVisualStyleBackColor = False
        '
        'grpGeneral
        '
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
        Me.grpGeneral.Size = New System.Drawing.Size(223, 201)
        Me.grpGeneral.TabIndex = 48
        Me.grpGeneral.TabStop = False
        Me.grpGeneral.Text = "General"
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
        Me.chkRollReverse.Location = New System.Drawing.Point(110, 161)
        Me.chkRollReverse.Name = "chkRollReverse"
        Me.chkRollReverse.Size = New System.Drawing.Size(69, 24)
        Me.chkRollReverse.TabIndex = 54
        Me.chkRollReverse.Text = "Normal"
        Me.chkRollReverse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkRollReverse.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(70, 139)
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
        Me.chkPitchReverse.TabIndex = 52
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
        Me.cbo3DModel.Size = New System.Drawing.Size(90, 21)
        Me.cbo3DModel.TabIndex = 51
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
        Me.cboMaxSpeed.TabIndex = 49
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
        Me.cboSpeedUnits.TabIndex = 46
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
        Me.cboDistanceUnits.TabIndex = 44
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(12, 219)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 49
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(394, 219)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 50
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 252)
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
        CType(Me.tbarFlightWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGeneral.ResumeLayout(False)
        Me.grpGeneral.PerformLayout()
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
End Class
