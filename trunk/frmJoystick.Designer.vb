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
        Me.cboServo5 = New System.Windows.Forms.ComboBox
        Me.cboServo4 = New System.Windows.Forms.ComboBox
        Me.cboServo3 = New System.Windows.Forms.ComboBox
        Me.cboServo2 = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cboServo1 = New System.Windows.Forms.ComboBox
        Me.lblMin5 = New System.Windows.Forms.Label
        Me.lblMax5 = New System.Windows.Forms.Label
        Me.chkJoystickReverse5 = New System.Windows.Forms.CheckBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboJoystick5 = New System.Windows.Forms.ComboBox
        Me.tbarValue5 = New System.Windows.Forms.TrackBar
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboDefaultModes = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblMin4 = New System.Windows.Forms.Label
        Me.cboDevice = New System.Windows.Forms.ComboBox
        Me.lblMin3 = New System.Windows.Forms.Label
        Me.lblMin2 = New System.Windows.Forms.Label
        Me.lblMin1 = New System.Windows.Forms.Label
        Me.cmdCalibrate = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblMax4 = New System.Windows.Forms.Label
        Me.lblMax3 = New System.Windows.Forms.Label
        Me.lblMax2 = New System.Windows.Forms.Label
        Me.lblMax1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
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
        Me.grpJoystickMapping.SuspendLayout()
        CType(Me.tbarValue5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarValue4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarValue3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarValue2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarValue1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpJoystickMapping
        '
        Me.grpJoystickMapping.Controls.Add(Me.cboServo5)
        Me.grpJoystickMapping.Controls.Add(Me.cboServo4)
        Me.grpJoystickMapping.Controls.Add(Me.cboServo3)
        Me.grpJoystickMapping.Controls.Add(Me.cboServo2)
        Me.grpJoystickMapping.Controls.Add(Me.Label16)
        Me.grpJoystickMapping.Controls.Add(Me.cboServo1)
        Me.grpJoystickMapping.Controls.Add(Me.lblMin5)
        Me.grpJoystickMapping.Controls.Add(Me.lblMax5)
        Me.grpJoystickMapping.Controls.Add(Me.chkJoystickReverse5)
        Me.grpJoystickMapping.Controls.Add(Me.Label15)
        Me.grpJoystickMapping.Controls.Add(Me.cboJoystick5)
        Me.grpJoystickMapping.Controls.Add(Me.tbarValue5)
        Me.grpJoystickMapping.Controls.Add(Me.cmdSearch)
        Me.grpJoystickMapping.Controls.Add(Me.Label13)
        Me.grpJoystickMapping.Controls.Add(Me.Label12)
        Me.grpJoystickMapping.Controls.Add(Me.Label11)
        Me.grpJoystickMapping.Controls.Add(Me.PictureBox1)
        Me.grpJoystickMapping.Controls.Add(Me.Label10)
        Me.grpJoystickMapping.Controls.Add(Me.cboDefaultModes)
        Me.grpJoystickMapping.Controls.Add(Me.Label6)
        Me.grpJoystickMapping.Controls.Add(Me.lblMin4)
        Me.grpJoystickMapping.Controls.Add(Me.cboDevice)
        Me.grpJoystickMapping.Controls.Add(Me.lblMin3)
        Me.grpJoystickMapping.Controls.Add(Me.lblMin2)
        Me.grpJoystickMapping.Controls.Add(Me.lblMin1)
        Me.grpJoystickMapping.Controls.Add(Me.cmdCalibrate)
        Me.grpJoystickMapping.Controls.Add(Me.Label14)
        Me.grpJoystickMapping.Controls.Add(Me.lblMax4)
        Me.grpJoystickMapping.Controls.Add(Me.lblMax3)
        Me.grpJoystickMapping.Controls.Add(Me.lblMax2)
        Me.grpJoystickMapping.Controls.Add(Me.lblMax1)
        Me.grpJoystickMapping.Controls.Add(Me.Label9)
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
        Me.grpJoystickMapping.Size = New System.Drawing.Size(875, 440)
        Me.grpJoystickMapping.TabIndex = 0
        Me.grpJoystickMapping.TabStop = False
        Me.grpJoystickMapping.Text = "Joystick Mapping"
        '
        'cboServo5
        '
        Me.cboServo5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServo5.FormattingEnabled = True
        Me.cboServo5.Location = New System.Drawing.Point(788, 397)
        Me.cboServo5.Name = "cboServo5"
        Me.cboServo5.Size = New System.Drawing.Size(75, 21)
        Me.cboServo5.TabIndex = 93
        '
        'cboServo4
        '
        Me.cboServo4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServo4.FormattingEnabled = True
        Me.cboServo4.Location = New System.Drawing.Point(788, 370)
        Me.cboServo4.Name = "cboServo4"
        Me.cboServo4.Size = New System.Drawing.Size(75, 21)
        Me.cboServo4.TabIndex = 92
        '
        'cboServo3
        '
        Me.cboServo3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServo3.FormattingEnabled = True
        Me.cboServo3.Location = New System.Drawing.Point(788, 343)
        Me.cboServo3.Name = "cboServo3"
        Me.cboServo3.Size = New System.Drawing.Size(75, 21)
        Me.cboServo3.TabIndex = 91
        '
        'cboServo2
        '
        Me.cboServo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServo2.FormattingEnabled = True
        Me.cboServo2.Location = New System.Drawing.Point(788, 316)
        Me.cboServo2.Name = "cboServo2"
        Me.cboServo2.Size = New System.Drawing.Size(75, 21)
        Me.cboServo2.TabIndex = 90
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(788, 255)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(75, 23)
        Me.Label16.TabIndex = 89
        Me.Label16.Text = "Servo #"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboServo1
        '
        Me.cboServo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServo1.FormattingEnabled = True
        Me.cboServo1.Location = New System.Drawing.Point(788, 291)
        Me.cboServo1.Name = "cboServo1"
        Me.cboServo1.Size = New System.Drawing.Size(75, 21)
        Me.cboServo1.TabIndex = 88
        '
        'lblMin5
        '
        Me.lblMin5.Location = New System.Drawing.Point(228, 397)
        Me.lblMin5.Name = "lblMin5"
        Me.lblMin5.Size = New System.Drawing.Size(51, 23)
        Me.lblMin5.TabIndex = 87
        Me.lblMin5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMax5
        '
        Me.lblMax5.Location = New System.Drawing.Point(634, 397)
        Me.lblMax5.Name = "lblMax5"
        Me.lblMax5.Size = New System.Drawing.Size(51, 23)
        Me.lblMax5.TabIndex = 86
        Me.lblMax5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkJoystickReverse5
        '
        Me.chkJoystickReverse5.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkJoystickReverse5.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkJoystickReverse5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkJoystickReverse5.Location = New System.Drawing.Point(691, 396)
        Me.chkJoystickReverse5.Name = "chkJoystickReverse5"
        Me.chkJoystickReverse5.Size = New System.Drawing.Size(91, 24)
        Me.chkJoystickReverse5.TabIndex = 85
        Me.chkJoystickReverse5.Text = "Normal"
        Me.chkJoystickReverse5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkJoystickReverse5.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(10, 397)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 23)
        Me.Label15.TabIndex = 84
        Me.Label15.Text = "Mode:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboJoystick5
        '
        Me.cboJoystick5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJoystick5.FormattingEnabled = True
        Me.cboJoystick5.Location = New System.Drawing.Point(107, 399)
        Me.cboJoystick5.Name = "cboJoystick5"
        Me.cboJoystick5.Size = New System.Drawing.Size(115, 21)
        Me.cboJoystick5.TabIndex = 83
        '
        'tbarValue5
        '
        Me.tbarValue5.AutoSize = False
        Me.tbarValue5.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.tbarValue5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarValue5.LargeChange = 1
        Me.tbarValue5.Location = New System.Drawing.Point(285, 399)
        Me.tbarValue5.Maximum = 65535
        Me.tbarValue5.Name = "tbarValue5"
        Me.tbarValue5.Size = New System.Drawing.Size(343, 21)
        Me.tbarValue5.TabIndex = 82
        Me.tbarValue5.TickFrequency = 26
        Me.tbarValue5.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarValue5.Value = 1
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(353, 29)
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
        Me.Label13.Location = New System.Drawing.Point(716, 200)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 80
        Me.Label13.Text = "Right"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(633, 200)
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
        Me.Label11.Location = New System.Drawing.Point(588, 67)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 15)
        Me.Label11.TabIndex = 78
        Me.Label11.Text = "D-Pad"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(523, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(340, 213)
        Me.PictureBox1.TabIndex = 60
        Me.PictureBox1.TabStop = False
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(10, 211)
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
        Me.cboDefaultModes.Location = New System.Drawing.Point(107, 211)
        Me.cboDefaultModes.Name = "cboDefaultModes"
        Me.cboDefaultModes.Size = New System.Drawing.Size(115, 21)
        Me.cboDefaultModes.TabIndex = 76
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(10, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 23)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Device:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMin4
        '
        Me.lblMin4.Location = New System.Drawing.Point(228, 370)
        Me.lblMin4.Name = "lblMin4"
        Me.lblMin4.Size = New System.Drawing.Size(51, 23)
        Me.lblMin4.TabIndex = 75
        Me.lblMin4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboDevice
        '
        Me.cboDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDevice.FormattingEnabled = True
        Me.cboDevice.Location = New System.Drawing.Point(107, 29)
        Me.cboDevice.Name = "cboDevice"
        Me.cboDevice.Size = New System.Drawing.Size(240, 21)
        Me.cboDevice.TabIndex = 50
        '
        'lblMin3
        '
        Me.lblMin3.Location = New System.Drawing.Point(228, 345)
        Me.lblMin3.Name = "lblMin3"
        Me.lblMin3.Size = New System.Drawing.Size(51, 23)
        Me.lblMin3.TabIndex = 74
        Me.lblMin3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMin2
        '
        Me.lblMin2.Location = New System.Drawing.Point(228, 318)
        Me.lblMin2.Name = "lblMin2"
        Me.lblMin2.Size = New System.Drawing.Size(51, 23)
        Me.lblMin2.TabIndex = 73
        Me.lblMin2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMin1
        '
        Me.lblMin1.Location = New System.Drawing.Point(228, 291)
        Me.lblMin1.Name = "lblMin1"
        Me.lblMin1.Size = New System.Drawing.Size(51, 23)
        Me.lblMin1.TabIndex = 72
        Me.lblMin1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdCalibrate
        '
        Me.cmdCalibrate.Location = New System.Drawing.Point(107, 56)
        Me.cmdCalibrate.Name = "cmdCalibrate"
        Me.cmdCalibrate.Size = New System.Drawing.Size(115, 23)
        Me.cmdCalibrate.TabIndex = 58
        Me.cmdCalibrate.Text = "Calibrate"
        Me.cmdCalibrate.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(228, 255)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 23)
        Me.Label14.TabIndex = 71
        Me.Label14.Text = "Min"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMax4
        '
        Me.lblMax4.Location = New System.Drawing.Point(634, 370)
        Me.lblMax4.Name = "lblMax4"
        Me.lblMax4.Size = New System.Drawing.Size(51, 23)
        Me.lblMax4.TabIndex = 70
        Me.lblMax4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMax3
        '
        Me.lblMax3.Location = New System.Drawing.Point(634, 345)
        Me.lblMax3.Name = "lblMax3"
        Me.lblMax3.Size = New System.Drawing.Size(51, 23)
        Me.lblMax3.TabIndex = 69
        Me.lblMax3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMax2
        '
        Me.lblMax2.Location = New System.Drawing.Point(634, 318)
        Me.lblMax2.Name = "lblMax2"
        Me.lblMax2.Size = New System.Drawing.Size(51, 23)
        Me.lblMax2.TabIndex = 68
        Me.lblMax2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMax1
        '
        Me.lblMax1.Location = New System.Drawing.Point(634, 291)
        Me.lblMax1.Name = "lblMax1"
        Me.lblMax1.Size = New System.Drawing.Size(51, 23)
        Me.lblMax1.TabIndex = 67
        Me.lblMax1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(634, 255)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 23)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "Max"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(691, 255)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 23)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Reversing"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkJoystickReverse4
        '
        Me.chkJoystickReverse4.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkJoystickReverse4.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkJoystickReverse4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkJoystickReverse4.Location = New System.Drawing.Point(691, 369)
        Me.chkJoystickReverse4.Name = "chkJoystickReverse4"
        Me.chkJoystickReverse4.Size = New System.Drawing.Size(91, 24)
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
        Me.chkJoystickReverse3.Location = New System.Drawing.Point(691, 342)
        Me.chkJoystickReverse3.Name = "chkJoystickReverse3"
        Me.chkJoystickReverse3.Size = New System.Drawing.Size(91, 24)
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
        Me.chkJoystickReverse2.Location = New System.Drawing.Point(691, 315)
        Me.chkJoystickReverse2.Name = "chkJoystickReverse2"
        Me.chkJoystickReverse2.Size = New System.Drawing.Size(91, 24)
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
        Me.chkJoystickReverse1.Location = New System.Drawing.Point(691, 288)
        Me.chkJoystickReverse1.Name = "chkJoystickReverse1"
        Me.chkJoystickReverse1.Size = New System.Drawing.Size(91, 24)
        Me.chkJoystickReverse1.TabIndex = 61
        Me.chkJoystickReverse1.Text = "Normal"
        Me.chkJoystickReverse1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkJoystickReverse1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(10, 370)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 23)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "Rudder:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(10, 343)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 23)
        Me.Label7.TabIndex = 58
        Me.Label7.Text = "Aileron:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(10, 316)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 23)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Elevator:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(10, 289)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 23)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Throttle:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(107, 255)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 23)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Joystick Input"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboJoystick4
        '
        Me.cboJoystick4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJoystick4.FormattingEnabled = True
        Me.cboJoystick4.Location = New System.Drawing.Point(107, 372)
        Me.cboJoystick4.Name = "cboJoystick4"
        Me.cboJoystick4.Size = New System.Drawing.Size(115, 21)
        Me.cboJoystick4.TabIndex = 51
        '
        'cboJoystick3
        '
        Me.cboJoystick3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJoystick3.FormattingEnabled = True
        Me.cboJoystick3.Location = New System.Drawing.Point(107, 345)
        Me.cboJoystick3.Name = "cboJoystick3"
        Me.cboJoystick3.Size = New System.Drawing.Size(115, 21)
        Me.cboJoystick3.TabIndex = 50
        '
        'cboJoystick2
        '
        Me.cboJoystick2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJoystick2.FormattingEnabled = True
        Me.cboJoystick2.Location = New System.Drawing.Point(107, 318)
        Me.cboJoystick2.Name = "cboJoystick2"
        Me.cboJoystick2.Size = New System.Drawing.Size(115, 21)
        Me.cboJoystick2.TabIndex = 49
        '
        'cboJoystick1
        '
        Me.cboJoystick1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJoystick1.FormattingEnabled = True
        Me.cboJoystick1.Location = New System.Drawing.Point(107, 291)
        Me.cboJoystick1.Name = "cboJoystick1"
        Me.cboJoystick1.Size = New System.Drawing.Size(115, 21)
        Me.cboJoystick1.TabIndex = 48
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(285, 255)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(343, 23)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Current Value"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbarValue4
        '
        Me.tbarValue4.AutoSize = False
        Me.tbarValue4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.tbarValue4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarValue4.LargeChange = 1
        Me.tbarValue4.Location = New System.Drawing.Point(285, 372)
        Me.tbarValue4.Maximum = 65535
        Me.tbarValue4.Name = "tbarValue4"
        Me.tbarValue4.Size = New System.Drawing.Size(343, 21)
        Me.tbarValue4.TabIndex = 21
        Me.tbarValue4.TickFrequency = 26
        Me.tbarValue4.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarValue4.Value = 1
        '
        'tbarValue3
        '
        Me.tbarValue3.AutoSize = False
        Me.tbarValue3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.tbarValue3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarValue3.LargeChange = 1
        Me.tbarValue3.Location = New System.Drawing.Point(285, 345)
        Me.tbarValue3.Maximum = 65535
        Me.tbarValue3.Name = "tbarValue3"
        Me.tbarValue3.Size = New System.Drawing.Size(343, 21)
        Me.tbarValue3.TabIndex = 18
        Me.tbarValue3.TickFrequency = 26
        Me.tbarValue3.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarValue3.Value = 1
        '
        'tbarValue2
        '
        Me.tbarValue2.AutoSize = False
        Me.tbarValue2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.tbarValue2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarValue2.LargeChange = 1
        Me.tbarValue2.Location = New System.Drawing.Point(285, 318)
        Me.tbarValue2.Maximum = 65535
        Me.tbarValue2.Name = "tbarValue2"
        Me.tbarValue2.Size = New System.Drawing.Size(343, 21)
        Me.tbarValue2.TabIndex = 15
        Me.tbarValue2.TickFrequency = 26
        Me.tbarValue2.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarValue2.Value = 1
        '
        'tbarValue1
        '
        Me.tbarValue1.AutoSize = False
        Me.tbarValue1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.tbarValue1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbarValue1.LargeChange = 1
        Me.tbarValue1.Location = New System.Drawing.Point(285, 291)
        Me.tbarValue1.Maximum = 65535
        Me.tbarValue1.Name = "tbarValue1"
        Me.tbarValue1.Size = New System.Drawing.Size(343, 21)
        Me.tbarValue1.TabIndex = 12
        Me.tbarValue1.TickFrequency = 26
        Me.tbarValue1.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarValue1.Value = 1
        '
        'tmrJoystick
        '
        Me.tmrJoystick.Interval = 50
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(11, 464)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(111, 23)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(776, 464)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(111, 23)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lblCalibration
        '
        Me.lblCalibration.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalibration.Location = New System.Drawing.Point(128, 464)
        Me.lblCalibration.Name = "lblCalibration"
        Me.lblCalibration.Size = New System.Drawing.Size(642, 23)
        Me.lblCalibration.TabIndex = 59
        Me.lblCalibration.Text = "Please make several slow full rotations with all input joysticks"
        Me.lblCalibration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblCalibration.Visible = False
        '
        'frmJoystick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 500)
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
        CType(Me.tbarValue5, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblMin4 As System.Windows.Forms.Label
    Friend WithEvents lblMin3 As System.Windows.Forms.Label
    Friend WithEvents lblMin2 As System.Windows.Forms.Label
    Friend WithEvents lblMin1 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblMax4 As System.Windows.Forms.Label
    Friend WithEvents lblMax3 As System.Windows.Forms.Label
    Friend WithEvents lblMax2 As System.Windows.Forms.Label
    Friend WithEvents lblMax1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblCalibration As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboDefaultModes As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblMin5 As System.Windows.Forms.Label
    Friend WithEvents lblMax5 As System.Windows.Forms.Label
    Friend WithEvents chkJoystickReverse5 As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboJoystick5 As System.Windows.Forms.ComboBox
    Friend WithEvents tbarValue5 As System.Windows.Forms.TrackBar
    Friend WithEvents cboServo5 As System.Windows.Forms.ComboBox
    Friend WithEvents cboServo4 As System.Windows.Forms.ComboBox
    Friend WithEvents cboServo3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboServo2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboServo1 As System.Windows.Forms.ComboBox
End Class
