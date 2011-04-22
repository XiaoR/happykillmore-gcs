<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJoystick
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJoystick))
        Me.grpJoystickMapping = New System.Windows.Forms.GroupBox
        Me.cmdSetEndpoints = New System.Windows.Forms.Button
        Me.numLower4 = New System.Windows.Forms.NumericUpDown
        Me.numLower3 = New System.Windows.Forms.NumericUpDown
        Me.numLower2 = New System.Windows.Forms.NumericUpDown
        Me.numLower1 = New System.Windows.Forms.NumericUpDown
        Me.numUpper4 = New System.Windows.Forms.NumericUpDown
        Me.numUpper3 = New System.Windows.Forms.NumericUpDown
        Me.numUpper2 = New System.Windows.Forms.NumericUpDown
        Me.numUpper1 = New System.Windows.Forms.NumericUpDown
        Me.chkEnable = New System.Windows.Forms.CheckBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.cboJoystickOutput = New System.Windows.Forms.ComboBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.lblOutput4 = New System.Windows.Forms.Label
        Me.lblOutput3 = New System.Windows.Forms.Label
        Me.lblOutput2 = New System.Windows.Forms.Label
        Me.lblOutput1 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.tbarOutput4 = New System.Windows.Forms.TrackBar
        Me.tbarOutput3 = New System.Windows.Forms.TrackBar
        Me.tbarOutput2 = New System.Windows.Forms.TrackBar
        Me.tbarOutput1 = New System.Windows.Forms.TrackBar
        Me.lblTrim4 = New System.Windows.Forms.Label
        Me.lblTrim3 = New System.Windows.Forms.Label
        Me.lblTrim2 = New System.Windows.Forms.Label
        Me.lblTrim1 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.cmdNudgeUp4 = New System.Windows.Forms.Button
        Me.cmdNudgeUp3 = New System.Windows.Forms.Button
        Me.cmdNudgeUp2 = New System.Windows.Forms.Button
        Me.cmdNudgeUp1 = New System.Windows.Forms.Button
        Me.cmdNudgeDown4 = New System.Windows.Forms.Button
        Me.cmdNudgeDown3 = New System.Windows.Forms.Button
        Me.cmdNudgeDown2 = New System.Windows.Forms.Button
        Me.cmdNudgeDown1 = New System.Windows.Forms.Button
        Me.lblValue4 = New System.Windows.Forms.Label
        Me.lblValue3 = New System.Windows.Forms.Label
        Me.lblValue2 = New System.Windows.Forms.Label
        Me.lblValue1 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.cmdClear4 = New System.Windows.Forms.Button
        Me.cmdClear3 = New System.Windows.Forms.Button
        Me.cmdClear2 = New System.Windows.Forms.Button
        Me.cmdClear1 = New System.Windows.Forms.Button
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.tbarSubTrim4 = New System.Windows.Forms.TrackBar
        Me.tbarSubTrim3 = New System.Windows.Forms.TrackBar
        Me.tbarSubTrim2 = New System.Windows.Forms.TrackBar
        Me.tbarSubTrim1 = New System.Windows.Forms.TrackBar
        Me.cboServo4 = New System.Windows.Forms.ComboBox
        Me.cboServo3 = New System.Windows.Forms.ComboBox
        Me.cboServo2 = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cboServo1 = New System.Windows.Forms.ComboBox
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboDefaultModes = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboDevice = New System.Windows.Forms.ComboBox
        Me.cmdCalibrate = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkJoystickReverse4 = New System.Windows.Forms.CheckBox
        Me.chkJoystickReverse3 = New System.Windows.Forms.CheckBox
        Me.chkJoystickReverse2 = New System.Windows.Forms.CheckBox
        Me.chkJoystickReverse1 = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboJoystick4 = New System.Windows.Forms.ComboBox
        Me.cboJoystick3 = New System.Windows.Forms.ComboBox
        Me.cboJoystick2 = New System.Windows.Forms.ComboBox
        Me.cboJoystick1 = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbarValue4 = New System.Windows.Forms.TrackBar
        Me.tbarValue3 = New System.Windows.Forms.TrackBar
        Me.tbarValue2 = New System.Windows.Forms.TrackBar
        Me.tbarValue1 = New System.Windows.Forms.TrackBar
        Me.tmrJoystick = New System.Windows.Forms.Timer(Me.components)
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.lblCalibration = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tmrTrimHold = New System.Windows.Forms.Timer(Me.components)
        Me.grpJoystickMapping.SuspendLayout()
        CType(Me.numLower4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLower3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLower2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLower1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numUpper4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numUpper3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numUpper2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numUpper1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarOutput4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarOutput3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarOutput2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarOutput1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarSubTrim4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarSubTrim3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarSubTrim2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarSubTrim1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarValue4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarValue3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarValue2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarValue1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpJoystickMapping
        '
        Me.grpJoystickMapping.Controls.Add(Me.cmdSetEndpoints)
        Me.grpJoystickMapping.Controls.Add(Me.numLower4)
        Me.grpJoystickMapping.Controls.Add(Me.numLower3)
        Me.grpJoystickMapping.Controls.Add(Me.numLower2)
        Me.grpJoystickMapping.Controls.Add(Me.numLower1)
        Me.grpJoystickMapping.Controls.Add(Me.numUpper4)
        Me.grpJoystickMapping.Controls.Add(Me.numUpper3)
        Me.grpJoystickMapping.Controls.Add(Me.numUpper2)
        Me.grpJoystickMapping.Controls.Add(Me.numUpper1)
        Me.grpJoystickMapping.Controls.Add(Me.chkEnable)
        Me.grpJoystickMapping.Controls.Add(Me.Label29)
        Me.grpJoystickMapping.Controls.Add(Me.cboJoystickOutput)
        Me.grpJoystickMapping.Controls.Add(Me.Label37)
        Me.grpJoystickMapping.Controls.Add(Me.Label38)
        Me.grpJoystickMapping.Controls.Add(Me.Label39)
        Me.grpJoystickMapping.Controls.Add(Me.Label40)
        Me.grpJoystickMapping.Controls.Add(Me.lblOutput4)
        Me.grpJoystickMapping.Controls.Add(Me.lblOutput3)
        Me.grpJoystickMapping.Controls.Add(Me.lblOutput2)
        Me.grpJoystickMapping.Controls.Add(Me.lblOutput1)
        Me.grpJoystickMapping.Controls.Add(Me.Label28)
        Me.grpJoystickMapping.Controls.Add(Me.Label35)
        Me.grpJoystickMapping.Controls.Add(Me.tbarOutput4)
        Me.grpJoystickMapping.Controls.Add(Me.tbarOutput3)
        Me.grpJoystickMapping.Controls.Add(Me.tbarOutput2)
        Me.grpJoystickMapping.Controls.Add(Me.tbarOutput1)
        Me.grpJoystickMapping.Controls.Add(Me.lblTrim4)
        Me.grpJoystickMapping.Controls.Add(Me.lblTrim3)
        Me.grpJoystickMapping.Controls.Add(Me.lblTrim2)
        Me.grpJoystickMapping.Controls.Add(Me.lblTrim1)
        Me.grpJoystickMapping.Controls.Add(Me.Label27)
        Me.grpJoystickMapping.Controls.Add(Me.cmdNudgeUp4)
        Me.grpJoystickMapping.Controls.Add(Me.cmdNudgeUp3)
        Me.grpJoystickMapping.Controls.Add(Me.cmdNudgeUp2)
        Me.grpJoystickMapping.Controls.Add(Me.cmdNudgeUp1)
        Me.grpJoystickMapping.Controls.Add(Me.cmdNudgeDown4)
        Me.grpJoystickMapping.Controls.Add(Me.cmdNudgeDown3)
        Me.grpJoystickMapping.Controls.Add(Me.cmdNudgeDown2)
        Me.grpJoystickMapping.Controls.Add(Me.cmdNudgeDown1)
        Me.grpJoystickMapping.Controls.Add(Me.lblValue4)
        Me.grpJoystickMapping.Controls.Add(Me.lblValue3)
        Me.grpJoystickMapping.Controls.Add(Me.lblValue2)
        Me.grpJoystickMapping.Controls.Add(Me.lblValue1)
        Me.grpJoystickMapping.Controls.Add(Me.Label26)
        Me.grpJoystickMapping.Controls.Add(Me.cmdClear4)
        Me.grpJoystickMapping.Controls.Add(Me.cmdClear3)
        Me.grpJoystickMapping.Controls.Add(Me.cmdClear2)
        Me.grpJoystickMapping.Controls.Add(Me.cmdClear1)
        Me.grpJoystickMapping.Controls.Add(Me.Label20)
        Me.grpJoystickMapping.Controls.Add(Me.Label19)
        Me.grpJoystickMapping.Controls.Add(Me.Label18)
        Me.grpJoystickMapping.Controls.Add(Me.Label17)
        Me.grpJoystickMapping.Controls.Add(Me.tbarSubTrim4)
        Me.grpJoystickMapping.Controls.Add(Me.tbarSubTrim3)
        Me.grpJoystickMapping.Controls.Add(Me.tbarSubTrim2)
        Me.grpJoystickMapping.Controls.Add(Me.tbarSubTrim1)
        Me.grpJoystickMapping.Controls.Add(Me.cboServo4)
        Me.grpJoystickMapping.Controls.Add(Me.cboServo3)
        Me.grpJoystickMapping.Controls.Add(Me.cboServo2)
        Me.grpJoystickMapping.Controls.Add(Me.Label16)
        Me.grpJoystickMapping.Controls.Add(Me.cboServo1)
        Me.grpJoystickMapping.Controls.Add(Me.cmdSearch)
        Me.grpJoystickMapping.Controls.Add(Me.Label13)
        Me.grpJoystickMapping.Controls.Add(Me.Label12)
        Me.grpJoystickMapping.Controls.Add(Me.Label11)
        Me.grpJoystickMapping.Controls.Add(Me.PictureBox1)
        Me.grpJoystickMapping.Controls.Add(Me.Label10)
        Me.grpJoystickMapping.Controls.Add(Me.cboDefaultModes)
        Me.grpJoystickMapping.Controls.Add(Me.Label6)
        Me.grpJoystickMapping.Controls.Add(Me.cboDevice)
        Me.grpJoystickMapping.Controls.Add(Me.cmdCalibrate)
        Me.grpJoystickMapping.Controls.Add(Me.Label4)
        Me.grpJoystickMapping.Controls.Add(Me.chkJoystickReverse4)
        Me.grpJoystickMapping.Controls.Add(Me.chkJoystickReverse3)
        Me.grpJoystickMapping.Controls.Add(Me.chkJoystickReverse2)
        Me.grpJoystickMapping.Controls.Add(Me.chkJoystickReverse1)
        Me.grpJoystickMapping.Controls.Add(Me.Label8)
        Me.grpJoystickMapping.Controls.Add(Me.Label7)
        Me.grpJoystickMapping.Controls.Add(Me.Label3)
        Me.grpJoystickMapping.Controls.Add(Me.Label1)
        Me.grpJoystickMapping.Controls.Add(Me.Label5)
        Me.grpJoystickMapping.Controls.Add(Me.cboJoystick4)
        Me.grpJoystickMapping.Controls.Add(Me.cboJoystick3)
        Me.grpJoystickMapping.Controls.Add(Me.cboJoystick2)
        Me.grpJoystickMapping.Controls.Add(Me.cboJoystick1)
        Me.grpJoystickMapping.Controls.Add(Me.Label2)
        Me.grpJoystickMapping.Controls.Add(Me.tbarValue4)
        Me.grpJoystickMapping.Controls.Add(Me.tbarValue3)
        Me.grpJoystickMapping.Controls.Add(Me.tbarValue2)
        Me.grpJoystickMapping.Controls.Add(Me.tbarValue1)
        Me.grpJoystickMapping.Location = New System.Drawing.Point(12, 12)
        Me.grpJoystickMapping.Name = "grpJoystickMapping"
        Me.grpJoystickMapping.Size = New System.Drawing.Size(872, 412)
        Me.grpJoystickMapping.TabIndex = 0
        Me.grpJoystickMapping.TabStop = False
        Me.grpJoystickMapping.Text = "Joystick Mapping"
        '
        'cmdSetEndpoints
        '
        Me.cmdSetEndpoints.Location = New System.Drawing.Point(105, 161)
        Me.cmdSetEndpoints.Name = "cmdSetEndpoints"
        Me.cmdSetEndpoints.Size = New System.Drawing.Size(141, 23)
        Me.cmdSetEndpoints.TabIndex = 187
        Me.cmdSetEndpoints.Text = "Set Endpoints"
        Me.cmdSetEndpoints.UseVisualStyleBackColor = True
        Me.cmdSetEndpoints.Visible = False
        '
        'numLower4
        '
        Me.numLower4.Location = New System.Drawing.Point(366, 373)
        Me.numLower4.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numLower4.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.numLower4.Name = "numLower4"
        Me.numLower4.Size = New System.Drawing.Size(48, 20)
        Me.numLower4.TabIndex = 185
        '
        'numLower3
        '
        Me.numLower3.Location = New System.Drawing.Point(366, 346)
        Me.numLower3.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numLower3.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.numLower3.Name = "numLower3"
        Me.numLower3.Size = New System.Drawing.Size(48, 20)
        Me.numLower3.TabIndex = 184
        '
        'numLower2
        '
        Me.numLower2.Location = New System.Drawing.Point(366, 319)
        Me.numLower2.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numLower2.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.numLower2.Name = "numLower2"
        Me.numLower2.Size = New System.Drawing.Size(48, 20)
        Me.numLower2.TabIndex = 183
        '
        'numLower1
        '
        Me.numLower1.Location = New System.Drawing.Point(366, 292)
        Me.numLower1.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numLower1.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.numLower1.Name = "numLower1"
        Me.numLower1.Size = New System.Drawing.Size(48, 20)
        Me.numLower1.TabIndex = 182
        '
        'numUpper4
        '
        Me.numUpper4.Location = New System.Drawing.Point(420, 373)
        Me.numUpper4.Maximum = New Decimal(New Integer() {900, 0, 0, 0})
        Me.numUpper4.Name = "numUpper4"
        Me.numUpper4.Size = New System.Drawing.Size(48, 20)
        Me.numUpper4.TabIndex = 180
        '
        'numUpper3
        '
        Me.numUpper3.Location = New System.Drawing.Point(420, 346)
        Me.numUpper3.Maximum = New Decimal(New Integer() {900, 0, 0, 0})
        Me.numUpper3.Name = "numUpper3"
        Me.numUpper3.Size = New System.Drawing.Size(48, 20)
        Me.numUpper3.TabIndex = 179
        '
        'numUpper2
        '
        Me.numUpper2.Location = New System.Drawing.Point(420, 319)
        Me.numUpper2.Maximum = New Decimal(New Integer() {900, 0, 0, 0})
        Me.numUpper2.Name = "numUpper2"
        Me.numUpper2.Size = New System.Drawing.Size(48, 20)
        Me.numUpper2.TabIndex = 178
        '
        'numUpper1
        '
        Me.numUpper1.Location = New System.Drawing.Point(420, 292)
        Me.numUpper1.Maximum = New Decimal(New Integer() {900, 0, 0, 0})
        Me.numUpper1.Name = "numUpper1"
        Me.numUpper1.Size = New System.Drawing.Size(48, 20)
        Me.numUpper1.TabIndex = 177
        '
        'chkEnable
        '
        Me.chkEnable.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkEnable.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkEnable.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkEnable.Location = New System.Drawing.Point(105, 131)
        Me.chkEnable.Name = "chkEnable"
        Me.chkEnable.Size = New System.Drawing.Size(141, 24)
        Me.chkEnable.TabIndex = 176
        Me.chkEnable.Text = "Enable"
        Me.chkEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkEnable.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(11, 103)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(89, 23)
        Me.Label29.TabIndex = 175
        Me.Label29.Text = "Output Device:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboJoystickOutput
        '
        Me.cboJoystickOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJoystickOutput.FormattingEnabled = True
        Me.cboJoystickOutput.Location = New System.Drawing.Point(106, 105)
        Me.cboJoystickOutput.Name = "cboJoystickOutput"
        Me.cboJoystickOutput.Size = New System.Drawing.Size(140, 21)
        Me.cboJoystickOutput.TabIndex = 174
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(255, 181)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(65, 23)
        Me.Label37.TabIndex = 172
        Me.Label37.Text = "Rudder:"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(255, 154)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(65, 23)
        Me.Label38.TabIndex = 171
        Me.Label38.Text = "Aileron:"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(255, 127)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(65, 23)
        Me.Label39.TabIndex = 170
        Me.Label39.Text = "Elevator:"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(255, 100)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(65, 23)
        Me.Label40.TabIndex = 169
        Me.Label40.Text = "Throttle:"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOutput4
        '
        Me.lblOutput4.Location = New System.Drawing.Point(450, 182)
        Me.lblOutput4.Name = "lblOutput4"
        Me.lblOutput4.Size = New System.Drawing.Size(37, 23)
        Me.lblOutput4.TabIndex = 167
        Me.lblOutput4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOutput3
        '
        Me.lblOutput3.Location = New System.Drawing.Point(450, 155)
        Me.lblOutput3.Name = "lblOutput3"
        Me.lblOutput3.Size = New System.Drawing.Size(37, 23)
        Me.lblOutput3.TabIndex = 166
        Me.lblOutput3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOutput2
        '
        Me.lblOutput2.Location = New System.Drawing.Point(450, 128)
        Me.lblOutput2.Name = "lblOutput2"
        Me.lblOutput2.Size = New System.Drawing.Size(37, 23)
        Me.lblOutput2.TabIndex = 165
        Me.lblOutput2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOutput1
        '
        Me.lblOutput1.Location = New System.Drawing.Point(450, 101)
        Me.lblOutput1.Name = "lblOutput1"
        Me.lblOutput1.Size = New System.Drawing.Size(37, 23)
        Me.lblOutput1.TabIndex = 164
        Me.lblOutput1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(450, 76)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(37, 23)
        Me.Label28.TabIndex = 163
        Me.Label28.Text = "Value"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(326, 76)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(118, 23)
        Me.Label35.TabIndex = 155
        Me.Label35.Text = "Current Output"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbarOutput4
        '
        Me.tbarOutput4.AutoSize = False
        Me.tbarOutput4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.tbarOutput4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarOutput4.LargeChange = 1
        Me.tbarOutput4.Location = New System.Drawing.Point(326, 183)
        Me.tbarOutput4.Maximum = 1000
        Me.tbarOutput4.Minimum = -1000
        Me.tbarOutput4.Name = "tbarOutput4"
        Me.tbarOutput4.Size = New System.Drawing.Size(118, 21)
        Me.tbarOutput4.TabIndex = 154
        Me.tbarOutput4.TickFrequency = 26
        Me.tbarOutput4.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbarOutput3
        '
        Me.tbarOutput3.AutoSize = False
        Me.tbarOutput3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.tbarOutput3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarOutput3.LargeChange = 1
        Me.tbarOutput3.Location = New System.Drawing.Point(326, 156)
        Me.tbarOutput3.Maximum = 1000
        Me.tbarOutput3.Minimum = -1000
        Me.tbarOutput3.Name = "tbarOutput3"
        Me.tbarOutput3.Size = New System.Drawing.Size(118, 21)
        Me.tbarOutput3.TabIndex = 153
        Me.tbarOutput3.TickFrequency = 26
        Me.tbarOutput3.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbarOutput2
        '
        Me.tbarOutput2.AutoSize = False
        Me.tbarOutput2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.tbarOutput2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarOutput2.LargeChange = 1
        Me.tbarOutput2.Location = New System.Drawing.Point(326, 129)
        Me.tbarOutput2.Maximum = 1000
        Me.tbarOutput2.Minimum = -1000
        Me.tbarOutput2.Name = "tbarOutput2"
        Me.tbarOutput2.Size = New System.Drawing.Size(118, 21)
        Me.tbarOutput2.TabIndex = 152
        Me.tbarOutput2.TickFrequency = 26
        Me.tbarOutput2.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbarOutput1
        '
        Me.tbarOutput1.AutoSize = False
        Me.tbarOutput1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.tbarOutput1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarOutput1.LargeChange = 1
        Me.tbarOutput1.Location = New System.Drawing.Point(326, 102)
        Me.tbarOutput1.Maximum = 1000
        Me.tbarOutput1.Minimum = -1000
        Me.tbarOutput1.Name = "tbarOutput1"
        Me.tbarOutput1.Size = New System.Drawing.Size(118, 21)
        Me.tbarOutput1.TabIndex = 151
        Me.tbarOutput1.TickFrequency = 26
        Me.tbarOutput1.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'lblTrim4
        '
        Me.lblTrim4.Location = New System.Drawing.Point(623, 371)
        Me.lblTrim4.Name = "lblTrim4"
        Me.lblTrim4.Size = New System.Drawing.Size(47, 23)
        Me.lblTrim4.TabIndex = 149
        Me.lblTrim4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTrim3
        '
        Me.lblTrim3.Location = New System.Drawing.Point(623, 344)
        Me.lblTrim3.Name = "lblTrim3"
        Me.lblTrim3.Size = New System.Drawing.Size(47, 23)
        Me.lblTrim3.TabIndex = 148
        Me.lblTrim3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTrim2
        '
        Me.lblTrim2.Location = New System.Drawing.Point(623, 317)
        Me.lblTrim2.Name = "lblTrim2"
        Me.lblTrim2.Size = New System.Drawing.Size(47, 23)
        Me.lblTrim2.TabIndex = 147
        Me.lblTrim2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTrim1
        '
        Me.lblTrim1.Location = New System.Drawing.Point(623, 290)
        Me.lblTrim1.Name = "lblTrim1"
        Me.lblTrim1.Size = New System.Drawing.Size(47, 23)
        Me.lblTrim1.TabIndex = 146
        Me.lblTrim1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(623, 256)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(47, 23)
        Me.Label27.TabIndex = 145
        Me.Label27.Text = "Trim"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdNudgeUp4
        '
        Me.cmdNudgeUp4.Location = New System.Drawing.Point(601, 371)
        Me.cmdNudgeUp4.Name = "cmdNudgeUp4"
        Me.cmdNudgeUp4.Size = New System.Drawing.Size(15, 23)
        Me.cmdNudgeUp4.TabIndex = 143
        Me.cmdNudgeUp4.Text = ">"
        Me.cmdNudgeUp4.UseVisualStyleBackColor = True
        '
        'cmdNudgeUp3
        '
        Me.cmdNudgeUp3.Location = New System.Drawing.Point(601, 344)
        Me.cmdNudgeUp3.Name = "cmdNudgeUp3"
        Me.cmdNudgeUp3.Size = New System.Drawing.Size(15, 23)
        Me.cmdNudgeUp3.TabIndex = 142
        Me.cmdNudgeUp3.Text = ">"
        Me.cmdNudgeUp3.UseVisualStyleBackColor = True
        '
        'cmdNudgeUp2
        '
        Me.cmdNudgeUp2.Location = New System.Drawing.Point(601, 317)
        Me.cmdNudgeUp2.Name = "cmdNudgeUp2"
        Me.cmdNudgeUp2.Size = New System.Drawing.Size(15, 23)
        Me.cmdNudgeUp2.TabIndex = 141
        Me.cmdNudgeUp2.Text = ">"
        Me.cmdNudgeUp2.UseVisualStyleBackColor = True
        '
        'cmdNudgeUp1
        '
        Me.cmdNudgeUp1.Location = New System.Drawing.Point(601, 292)
        Me.cmdNudgeUp1.Name = "cmdNudgeUp1"
        Me.cmdNudgeUp1.Size = New System.Drawing.Size(15, 23)
        Me.cmdNudgeUp1.TabIndex = 140
        Me.cmdNudgeUp1.Text = ">"
        Me.cmdNudgeUp1.UseVisualStyleBackColor = True
        '
        'cmdNudgeDown4
        '
        Me.cmdNudgeDown4.Location = New System.Drawing.Point(472, 371)
        Me.cmdNudgeDown4.Name = "cmdNudgeDown4"
        Me.cmdNudgeDown4.Size = New System.Drawing.Size(15, 23)
        Me.cmdNudgeDown4.TabIndex = 138
        Me.cmdNudgeDown4.Text = "<"
        Me.cmdNudgeDown4.UseVisualStyleBackColor = True
        '
        'cmdNudgeDown3
        '
        Me.cmdNudgeDown3.Location = New System.Drawing.Point(472, 344)
        Me.cmdNudgeDown3.Name = "cmdNudgeDown3"
        Me.cmdNudgeDown3.Size = New System.Drawing.Size(15, 23)
        Me.cmdNudgeDown3.TabIndex = 137
        Me.cmdNudgeDown3.Text = "<"
        Me.cmdNudgeDown3.UseVisualStyleBackColor = True
        '
        'cmdNudgeDown2
        '
        Me.cmdNudgeDown2.Location = New System.Drawing.Point(472, 317)
        Me.cmdNudgeDown2.Name = "cmdNudgeDown2"
        Me.cmdNudgeDown2.Size = New System.Drawing.Size(15, 23)
        Me.cmdNudgeDown2.TabIndex = 136
        Me.cmdNudgeDown2.Text = "<"
        Me.cmdNudgeDown2.UseVisualStyleBackColor = True
        '
        'cmdNudgeDown1
        '
        Me.cmdNudgeDown1.Location = New System.Drawing.Point(472, 292)
        Me.cmdNudgeDown1.Name = "cmdNudgeDown1"
        Me.cmdNudgeDown1.Size = New System.Drawing.Size(15, 23)
        Me.cmdNudgeDown1.TabIndex = 135
        Me.cmdNudgeDown1.Text = "<"
        Me.cmdNudgeDown1.UseVisualStyleBackColor = True
        '
        'lblValue4
        '
        Me.lblValue4.Location = New System.Drawing.Point(271, 372)
        Me.lblValue4.Name = "lblValue4"
        Me.lblValue4.Size = New System.Drawing.Size(47, 23)
        Me.lblValue4.TabIndex = 133
        Me.lblValue4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblValue3
        '
        Me.lblValue3.Location = New System.Drawing.Point(271, 345)
        Me.lblValue3.Name = "lblValue3"
        Me.lblValue3.Size = New System.Drawing.Size(47, 23)
        Me.lblValue3.TabIndex = 132
        Me.lblValue3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblValue2
        '
        Me.lblValue2.Location = New System.Drawing.Point(271, 318)
        Me.lblValue2.Name = "lblValue2"
        Me.lblValue2.Size = New System.Drawing.Size(47, 23)
        Me.lblValue2.TabIndex = 131
        Me.lblValue2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblValue1
        '
        Me.lblValue1.Location = New System.Drawing.Point(271, 291)
        Me.lblValue1.Name = "lblValue1"
        Me.lblValue1.Size = New System.Drawing.Size(47, 23)
        Me.lblValue1.TabIndex = 130
        Me.lblValue1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(271, 257)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(47, 23)
        Me.Label26.TabIndex = 129
        Me.Label26.Text = "Value"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdClear4
        '
        Me.cmdClear4.Location = New System.Drawing.Point(324, 372)
        Me.cmdClear4.Name = "cmdClear4"
        Me.cmdClear4.Size = New System.Drawing.Size(38, 23)
        Me.cmdClear4.TabIndex = 127
        Me.cmdClear4.Text = "X"
        Me.cmdClear4.UseVisualStyleBackColor = True
        '
        'cmdClear3
        '
        Me.cmdClear3.Location = New System.Drawing.Point(324, 345)
        Me.cmdClear3.Name = "cmdClear3"
        Me.cmdClear3.Size = New System.Drawing.Size(38, 23)
        Me.cmdClear3.TabIndex = 126
        Me.cmdClear3.Text = "X"
        Me.cmdClear3.UseVisualStyleBackColor = True
        '
        'cmdClear2
        '
        Me.cmdClear2.Location = New System.Drawing.Point(324, 318)
        Me.cmdClear2.Name = "cmdClear2"
        Me.cmdClear2.Size = New System.Drawing.Size(38, 23)
        Me.cmdClear2.TabIndex = 125
        Me.cmdClear2.Text = "X"
        Me.cmdClear2.UseVisualStyleBackColor = True
        '
        'cmdClear1
        '
        Me.cmdClear1.Location = New System.Drawing.Point(324, 291)
        Me.cmdClear1.Name = "cmdClear1"
        Me.cmdClear1.Size = New System.Drawing.Size(38, 23)
        Me.cmdClear1.TabIndex = 124
        Me.cmdClear1.Text = "X"
        Me.cmdClear1.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(324, 257)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(38, 23)
        Me.Label20.TabIndex = 123
        Me.Label20.Text = "Clear"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(420, 257)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 23)
        Me.Label19.TabIndex = 110
        Me.Label19.Text = "Upper"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(366, 257)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 23)
        Me.Label18.TabIndex = 104
        Me.Label18.Text = "Lower"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(493, 257)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(102, 23)
        Me.Label17.TabIndex = 98
        Me.Label17.Text = "Sub-Trim"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbarSubTrim4
        '
        Me.tbarSubTrim4.AutoSize = False
        Me.tbarSubTrim4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.tbarSubTrim4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarSubTrim4.LargeChange = 1
        Me.tbarSubTrim4.Location = New System.Drawing.Point(493, 373)
        Me.tbarSubTrim4.Maximum = 32768
        Me.tbarSubTrim4.Minimum = -32767
        Me.tbarSubTrim4.Name = "tbarSubTrim4"
        Me.tbarSubTrim4.Size = New System.Drawing.Size(102, 21)
        Me.tbarSubTrim4.TabIndex = 97
        Me.tbarSubTrim4.TickFrequency = 26
        Me.tbarSubTrim4.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbarSubTrim3
        '
        Me.tbarSubTrim3.AutoSize = False
        Me.tbarSubTrim3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.tbarSubTrim3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarSubTrim3.LargeChange = 1
        Me.tbarSubTrim3.Location = New System.Drawing.Point(493, 346)
        Me.tbarSubTrim3.Maximum = 32768
        Me.tbarSubTrim3.Minimum = -32767
        Me.tbarSubTrim3.Name = "tbarSubTrim3"
        Me.tbarSubTrim3.Size = New System.Drawing.Size(102, 21)
        Me.tbarSubTrim3.TabIndex = 96
        Me.tbarSubTrim3.TickFrequency = 26
        Me.tbarSubTrim3.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbarSubTrim2
        '
        Me.tbarSubTrim2.AutoSize = False
        Me.tbarSubTrim2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.tbarSubTrim2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarSubTrim2.LargeChange = 1
        Me.tbarSubTrim2.Location = New System.Drawing.Point(493, 319)
        Me.tbarSubTrim2.Maximum = 32768
        Me.tbarSubTrim2.Minimum = -32767
        Me.tbarSubTrim2.Name = "tbarSubTrim2"
        Me.tbarSubTrim2.Size = New System.Drawing.Size(102, 21)
        Me.tbarSubTrim2.TabIndex = 95
        Me.tbarSubTrim2.TickFrequency = 26
        Me.tbarSubTrim2.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbarSubTrim1
        '
        Me.tbarSubTrim1.AutoSize = False
        Me.tbarSubTrim1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.tbarSubTrim1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarSubTrim1.LargeChange = 1
        Me.tbarSubTrim1.Location = New System.Drawing.Point(493, 292)
        Me.tbarSubTrim1.Maximum = 32768
        Me.tbarSubTrim1.Minimum = -32767
        Me.tbarSubTrim1.Name = "tbarSubTrim1"
        Me.tbarSubTrim1.Size = New System.Drawing.Size(102, 21)
        Me.tbarSubTrim1.TabIndex = 94
        Me.tbarSubTrim1.TickFrequency = 26
        Me.tbarSubTrim1.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'cboServo4
        '
        Me.cboServo4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServo4.FormattingEnabled = True
        Me.cboServo4.Location = New System.Drawing.Point(760, 372)
        Me.cboServo4.Name = "cboServo4"
        Me.cboServo4.Size = New System.Drawing.Size(60, 21)
        Me.cboServo4.TabIndex = 92
        '
        'cboServo3
        '
        Me.cboServo3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServo3.FormattingEnabled = True
        Me.cboServo3.Location = New System.Drawing.Point(760, 345)
        Me.cboServo3.Name = "cboServo3"
        Me.cboServo3.Size = New System.Drawing.Size(60, 21)
        Me.cboServo3.TabIndex = 91
        '
        'cboServo2
        '
        Me.cboServo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServo2.FormattingEnabled = True
        Me.cboServo2.Location = New System.Drawing.Point(760, 318)
        Me.cboServo2.Name = "cboServo2"
        Me.cboServo2.Size = New System.Drawing.Size(60, 21)
        Me.cboServo2.TabIndex = 90
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(760, 256)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 23)
        Me.Label16.TabIndex = 89
        Me.Label16.Text = "Servo #"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboServo1
        '
        Me.cboServo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServo1.FormattingEnabled = True
        Me.cboServo1.Location = New System.Drawing.Point(760, 291)
        Me.cboServo1.Name = "cboServo1"
        Me.cboServo1.Size = New System.Drawing.Size(60, 21)
        Me.cboServo1.TabIndex = 88
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(330, 27)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(22, 23)
        Me.cmdSearch.TabIndex = 81
        Me.cmdSearch.Text = "<"
        Me.ToolTip1.SetToolTip(Me.cmdSearch, "Search for Controllers")
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(711, 208)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 80
        Me.Label13.Text = "Right"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(628, 208)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 13)
        Me.Label12.TabIndex = 79
        Me.Label12.Text = "Left"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.LightGray
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(583, 75)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 15)
        Me.Label11.TabIndex = 78
        Me.Label11.Text = "D-Pad"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(518, 25)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(340, 213)
        Me.PictureBox1.TabIndex = 60
        Me.PictureBox1.TabStop = False
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(11, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 23)
        Me.Label10.TabIndex = 77
        Me.Label10.Text = "Default Mode:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboDefaultModes
        '
        Me.cboDefaultModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDefaultModes.FormattingEnabled = True
        Me.cboDefaultModes.Location = New System.Drawing.Point(106, 54)
        Me.cboDefaultModes.Name = "cboDefaultModes"
        Me.cboDefaultModes.Size = New System.Drawing.Size(115, 21)
        Me.cboDefaultModes.TabIndex = 76
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(35, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 23)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Device:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboDevice
        '
        Me.cboDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDevice.FormattingEnabled = True
        Me.cboDevice.Location = New System.Drawing.Point(106, 27)
        Me.cboDevice.Name = "cboDevice"
        Me.cboDevice.Size = New System.Drawing.Size(218, 21)
        Me.cboDevice.TabIndex = 50
        '
        'cmdCalibrate
        '
        Me.cmdCalibrate.Location = New System.Drawing.Point(358, 27)
        Me.cmdCalibrate.Name = "cmdCalibrate"
        Me.cmdCalibrate.Size = New System.Drawing.Size(115, 23)
        Me.cmdCalibrate.TabIndex = 58
        Me.cmdCalibrate.Text = "Calibrate"
        Me.cmdCalibrate.UseVisualStyleBackColor = True
        Me.cmdCalibrate.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(676, 256)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 23)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Reversing"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkJoystickReverse4
        '
        Me.chkJoystickReverse4.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkJoystickReverse4.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkJoystickReverse4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkJoystickReverse4.Location = New System.Drawing.Point(676, 370)
        Me.chkJoystickReverse4.Name = "chkJoystickReverse4"
        Me.chkJoystickReverse4.Size = New System.Drawing.Size(78, 24)
        Me.chkJoystickReverse4.TabIndex = 64
        Me.chkJoystickReverse4.Text = "Normal"
        Me.chkJoystickReverse4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkJoystickReverse4.UseVisualStyleBackColor = True
        '
        'chkJoystickReverse3
        '
        Me.chkJoystickReverse3.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkJoystickReverse3.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkJoystickReverse3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkJoystickReverse3.Location = New System.Drawing.Point(676, 343)
        Me.chkJoystickReverse3.Name = "chkJoystickReverse3"
        Me.chkJoystickReverse3.Size = New System.Drawing.Size(78, 24)
        Me.chkJoystickReverse3.TabIndex = 63
        Me.chkJoystickReverse3.Text = "Normal"
        Me.chkJoystickReverse3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkJoystickReverse3.UseVisualStyleBackColor = True
        '
        'chkJoystickReverse2
        '
        Me.chkJoystickReverse2.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkJoystickReverse2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkJoystickReverse2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkJoystickReverse2.Location = New System.Drawing.Point(676, 316)
        Me.chkJoystickReverse2.Name = "chkJoystickReverse2"
        Me.chkJoystickReverse2.Size = New System.Drawing.Size(78, 24)
        Me.chkJoystickReverse2.TabIndex = 62
        Me.chkJoystickReverse2.Text = "Normal"
        Me.chkJoystickReverse2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkJoystickReverse2.UseVisualStyleBackColor = True
        '
        'chkJoystickReverse1
        '
        Me.chkJoystickReverse1.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkJoystickReverse1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkJoystickReverse1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkJoystickReverse1.Location = New System.Drawing.Point(676, 289)
        Me.chkJoystickReverse1.Name = "chkJoystickReverse1"
        Me.chkJoystickReverse1.Size = New System.Drawing.Size(78, 24)
        Me.chkJoystickReverse1.TabIndex = 61
        Me.chkJoystickReverse1.Text = "Normal"
        Me.chkJoystickReverse1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkJoystickReverse1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(10, 370)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 23)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "Rudder:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(10, 343)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 23)
        Me.Label7.TabIndex = 58
        Me.Label7.Text = "Aileron:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(10, 316)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 23)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Elevator:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(10, 289)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 23)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Throttle:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(78, 255)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 23)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Joystick Input"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboJoystick4
        '
        Me.cboJoystick4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJoystick4.FormattingEnabled = True
        Me.cboJoystick4.Location = New System.Drawing.Point(78, 371)
        Me.cboJoystick4.Name = "cboJoystick4"
        Me.cboJoystick4.Size = New System.Drawing.Size(105, 21)
        Me.cboJoystick4.TabIndex = 51
        '
        'cboJoystick3
        '
        Me.cboJoystick3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJoystick3.FormattingEnabled = True
        Me.cboJoystick3.Location = New System.Drawing.Point(78, 344)
        Me.cboJoystick3.Name = "cboJoystick3"
        Me.cboJoystick3.Size = New System.Drawing.Size(105, 21)
        Me.cboJoystick3.TabIndex = 50
        '
        'cboJoystick2
        '
        Me.cboJoystick2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJoystick2.FormattingEnabled = True
        Me.cboJoystick2.Location = New System.Drawing.Point(78, 317)
        Me.cboJoystick2.Name = "cboJoystick2"
        Me.cboJoystick2.Size = New System.Drawing.Size(105, 21)
        Me.cboJoystick2.TabIndex = 49
        '
        'cboJoystick1
        '
        Me.cboJoystick1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJoystick1.FormattingEnabled = True
        Me.cboJoystick1.Location = New System.Drawing.Point(78, 290)
        Me.cboJoystick1.Name = "cboJoystick1"
        Me.cboJoystick1.Size = New System.Drawing.Size(105, 21)
        Me.cboJoystick1.TabIndex = 48
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(189, 257)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 23)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Current"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbarValue4
        '
        Me.tbarValue4.AutoSize = False
        Me.tbarValue4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.tbarValue4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarValue4.LargeChange = 1
        Me.tbarValue4.Location = New System.Drawing.Point(189, 373)
        Me.tbarValue4.Maximum = 32768
        Me.tbarValue4.Minimum = -32767
        Me.tbarValue4.Name = "tbarValue4"
        Me.tbarValue4.Size = New System.Drawing.Size(76, 21)
        Me.tbarValue4.TabIndex = 21
        Me.tbarValue4.TickFrequency = 26
        Me.tbarValue4.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbarValue3
        '
        Me.tbarValue3.AutoSize = False
        Me.tbarValue3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.tbarValue3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarValue3.LargeChange = 1
        Me.tbarValue3.Location = New System.Drawing.Point(189, 346)
        Me.tbarValue3.Maximum = 32768
        Me.tbarValue3.Minimum = -32767
        Me.tbarValue3.Name = "tbarValue3"
        Me.tbarValue3.Size = New System.Drawing.Size(76, 21)
        Me.tbarValue3.TabIndex = 18
        Me.tbarValue3.TickFrequency = 26
        Me.tbarValue3.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbarValue2
        '
        Me.tbarValue2.AutoSize = False
        Me.tbarValue2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.tbarValue2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarValue2.LargeChange = 1
        Me.tbarValue2.Location = New System.Drawing.Point(189, 319)
        Me.tbarValue2.Maximum = 32768
        Me.tbarValue2.Minimum = -32767
        Me.tbarValue2.Name = "tbarValue2"
        Me.tbarValue2.Size = New System.Drawing.Size(76, 21)
        Me.tbarValue2.TabIndex = 15
        Me.tbarValue2.TickFrequency = 26
        Me.tbarValue2.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbarValue1
        '
        Me.tbarValue1.AutoSize = False
        Me.tbarValue1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.tbarValue1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarValue1.LargeChange = 1
        Me.tbarValue1.Location = New System.Drawing.Point(189, 292)
        Me.tbarValue1.Maximum = 32768
        Me.tbarValue1.Minimum = -32767
        Me.tbarValue1.Name = "tbarValue1"
        Me.tbarValue1.Size = New System.Drawing.Size(76, 21)
        Me.tbarValue1.TabIndex = 12
        Me.tbarValue1.TickFrequency = 26
        Me.tbarValue1.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tmrJoystick
        '
        Me.tmrJoystick.Interval = 50
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(11, 435)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(111, 23)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(775, 435)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(111, 23)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lblCalibration
        '
        Me.lblCalibration.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalibration.Location = New System.Drawing.Point(128, 435)
        Me.lblCalibration.Name = "lblCalibration"
        Me.lblCalibration.Size = New System.Drawing.Size(642, 23)
        Me.lblCalibration.TabIndex = 59
        Me.lblCalibration.Text = "Please make several slow full rotations with all input joysticks"
        Me.lblCalibration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblCalibration.Visible = False
        '
        'tmrTrimHold
        '
        Me.tmrTrimHold.Interval = 500
        '
        'frmJoystick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(897, 475)
        Me.Controls.Add(Me.lblCalibration)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.grpJoystickMapping)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmJoystick"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Joystick Setup"
        Me.grpJoystickMapping.ResumeLayout(False)
        Me.grpJoystickMapping.PerformLayout()
        CType(Me.numLower4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLower3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLower2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLower1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numUpper4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numUpper3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numUpper2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numUpper1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarOutput4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarOutput3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarOutput2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarOutput1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarSubTrim4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarSubTrim3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarSubTrim2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarSubTrim1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarValue4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarValue3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarValue2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarValue1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpJoystickMapping As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbarValue4 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarValue3 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarValue2 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarValue1 As System.Windows.Forms.TrackBar
    Friend WithEvents tmrJoystick As System.Windows.Forms.Timer
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboJoystick4 As System.Windows.Forms.ComboBox
    Friend WithEvents cboJoystick3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboJoystick2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboJoystick1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cboDevice As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCalibrate As System.Windows.Forms.Button
    Friend WithEvents chkJoystickReverse4 As System.Windows.Forms.CheckBox
    Friend WithEvents chkJoystickReverse3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkJoystickReverse2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkJoystickReverse1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCalibration As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboDefaultModes As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cboServo4 As System.Windows.Forms.ComboBox
    Friend WithEvents cboServo3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboServo2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboServo1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tbarSubTrim4 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarSubTrim3 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarSubTrim2 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarSubTrim1 As System.Windows.Forms.TrackBar
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmdClear4 As System.Windows.Forms.Button
    Friend WithEvents cmdClear3 As System.Windows.Forms.Button
    Friend WithEvents cmdClear2 As System.Windows.Forms.Button
    Friend WithEvents cmdClear1 As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblValue4 As System.Windows.Forms.Label
    Friend WithEvents lblValue3 As System.Windows.Forms.Label
    Friend WithEvents lblValue2 As System.Windows.Forms.Label
    Friend WithEvents lblValue1 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmdNudgeUp4 As System.Windows.Forms.Button
    Friend WithEvents cmdNudgeUp3 As System.Windows.Forms.Button
    Friend WithEvents cmdNudgeUp2 As System.Windows.Forms.Button
    Friend WithEvents cmdNudgeUp1 As System.Windows.Forms.Button
    Friend WithEvents cmdNudgeDown4 As System.Windows.Forms.Button
    Friend WithEvents cmdNudgeDown3 As System.Windows.Forms.Button
    Friend WithEvents cmdNudgeDown2 As System.Windows.Forms.Button
    Friend WithEvents cmdNudgeDown1 As System.Windows.Forms.Button
    Friend WithEvents lblTrim4 As System.Windows.Forms.Label
    Friend WithEvents lblTrim3 As System.Windows.Forms.Label
    Friend WithEvents lblTrim2 As System.Windows.Forms.Label
    Friend WithEvents lblTrim1 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents tmrTrimHold As System.Windows.Forms.Timer
    Friend WithEvents lblOutput4 As System.Windows.Forms.Label
    Friend WithEvents lblOutput3 As System.Windows.Forms.Label
    Friend WithEvents lblOutput2 As System.Windows.Forms.Label
    Friend WithEvents lblOutput1 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents tbarOutput4 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarOutput3 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarOutput2 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarOutput1 As System.Windows.Forms.TrackBar
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cboJoystickOutput As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents chkEnable As System.Windows.Forms.CheckBox
    Friend WithEvents numUpper1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numLower4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numLower3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numLower2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numLower1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numUpper4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numUpper3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numUpper2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmdSetEndpoints As System.Windows.Forms.Button
End Class
