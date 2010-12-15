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
        Me.lblFlightOpacity = New System.Windows.Forms.Label
        Me.tbarFlightOpacity = New System.Windows.Forms.TrackBar
        Me.lblFlightExtrude = New System.Windows.Forms.Label
        Me.chkFlightExtrude = New System.Windows.Forms.CheckBox
        Me.cboMapUpdateRate = New System.Windows.Forms.ComboBox
        Me.lblMapUpdateRate = New System.Windows.Forms.Label
        Me.lblFlightPathThickness = New System.Windows.Forms.Label
        Me.lblFlightPathColor = New System.Windows.Forms.Label
        Me.tbarFlightWidth = New System.Windows.Forms.TrackBar
        Me.cmdFlightColor = New System.Windows.Forms.Button
        Me.grpGeneral = New System.Windows.Forms.GroupBox
        Me.cboThrottleChannel = New System.Windows.Forms.ComboBox
        Me.lblThrottleChannel = New System.Windows.Forms.Label
        Me.lblHeading = New System.Windows.Forms.Label
        Me.chkHeadingReverse = New System.Windows.Forms.CheckBox
        Me.lblYaw = New System.Windows.Forms.Label
        Me.chkYawReverse = New System.Windows.Forms.CheckBox
        Me.lblRoll = New System.Windows.Forms.Label
        Me.chkRollReverse = New System.Windows.Forms.CheckBox
        Me.lblPitch = New System.Windows.Forms.Label
        Me.chkPitchReverse = New System.Windows.Forms.CheckBox
        Me.cbo3DModel = New System.Windows.Forms.ComboBox
        Me.lbl3DModel = New System.Windows.Forms.Label
        Me.cboMaxSpeed = New System.Windows.Forms.ComboBox
        Me.lblMaxSpeed = New System.Windows.Forms.Label
        Me.lblSpeedUnits = New System.Windows.Forms.Label
        Me.cboSpeedUnits = New System.Windows.Forms.ComboBox
        Me.lblDistanceUnits = New System.Windows.Forms.Label
        Me.cboDistanceUnits = New System.Windows.Forms.ComboBox
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.grpMissionPath = New System.Windows.Forms.GroupBox
        Me.lblMissionOpacity = New System.Windows.Forms.Label
        Me.tbarMissionOpacity = New System.Windows.Forms.TrackBar
        Me.lblMissionExtrude = New System.Windows.Forms.Label
        Me.chkMissionExtrude = New System.Windows.Forms.CheckBox
        Me.lblMissionPathThickness = New System.Windows.Forms.Label
        Me.lblMissionPathColor = New System.Windows.Forms.Label
        Me.tbarMissionWidth = New System.Windows.Forms.TrackBar
        Me.cmdMissionColor = New System.Windows.Forms.Button
        Me.grpInstrumentSelection = New System.Windows.Forms.GroupBox
        Me.chkInstBattery = New System.Windows.Forms.CheckBox
        Me.chkInstTurn = New System.Windows.Forms.CheckBox
        Me.chkInst3DModel = New System.Windows.Forms.CheckBox
        Me.chkInstVertical = New System.Windows.Forms.CheckBox
        Me.chkInstHeading = New System.Windows.Forms.CheckBox
        Me.chkInstAttitude = New System.Windows.Forms.CheckBox
        Me.chkInstAltimeter = New System.Windows.Forms.CheckBox
        Me.chkInstSpeed = New System.Windows.Forms.CheckBox
        Me.grpBatteryThrottle = New System.Windows.Forms.GroupBox
        Me.cboThrottleColor = New System.Windows.Forms.ComboBox
        Me.lblThrottleColor = New System.Windows.Forms.Label
        Me.cboMAHColor = New System.Windows.Forms.ComboBox
        Me.lblMahColor = New System.Windows.Forms.Label
        Me.lblMahMax = New System.Windows.Forms.Label
        Me.txtMAHMax = New System.Windows.Forms.TextBox
        Me.lblMahMin = New System.Windows.Forms.Label
        Me.txtMAHMin = New System.Windows.Forms.TextBox
        Me.cboAmperageColor = New System.Windows.Forms.ComboBox
        Me.lblAmperageColor = New System.Windows.Forms.Label
        Me.lblAmperageMax = New System.Windows.Forms.Label
        Me.txtAmperageMax = New System.Windows.Forms.TextBox
        Me.cboVoltageColor = New System.Windows.Forms.ComboBox
        Me.lblVoltageColor = New System.Windows.Forms.Label
        Me.lblVoltageMax = New System.Windows.Forms.Label
        Me.txtVoltageMax = New System.Windows.Forms.TextBox
        Me.lblVoltageMin = New System.Windows.Forms.Label
        Me.txtVoltageMin = New System.Windows.Forms.TextBox
        Me.grpFlightPath.SuspendLayout()
        CType(Me.tbarFlightOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarFlightWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGeneral.SuspendLayout()
        Me.grpMissionPath.SuspendLayout()
        CType(Me.tbarMissionOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarMissionWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpInstrumentSelection.SuspendLayout()
        Me.grpBatteryThrottle.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpFlightPath
        '
        Me.grpFlightPath.Controls.Add(Me.lblFlightOpacity)
        Me.grpFlightPath.Controls.Add(Me.tbarFlightOpacity)
        Me.grpFlightPath.Controls.Add(Me.lblFlightExtrude)
        Me.grpFlightPath.Controls.Add(Me.chkFlightExtrude)
        Me.grpFlightPath.Controls.Add(Me.cboMapUpdateRate)
        Me.grpFlightPath.Controls.Add(Me.lblMapUpdateRate)
        Me.grpFlightPath.Controls.Add(Me.lblFlightPathThickness)
        Me.grpFlightPath.Controls.Add(Me.lblFlightPathColor)
        Me.grpFlightPath.Controls.Add(Me.tbarFlightWidth)
        Me.grpFlightPath.Controls.Add(Me.cmdFlightColor)
        resources.ApplyResources(Me.grpFlightPath, "grpFlightPath")
        Me.grpFlightPath.Name = "grpFlightPath"
        Me.grpFlightPath.TabStop = False
        '
        'lblFlightOpacity
        '
        resources.ApplyResources(Me.lblFlightOpacity, "lblFlightOpacity")
        Me.lblFlightOpacity.Name = "lblFlightOpacity"
        '
        'tbarFlightOpacity
        '
        resources.ApplyResources(Me.tbarFlightOpacity, "tbarFlightOpacity")
        Me.tbarFlightOpacity.BackColor = System.Drawing.SystemColors.Control
        Me.tbarFlightOpacity.LargeChange = 1
        Me.tbarFlightOpacity.Maximum = 255
        Me.tbarFlightOpacity.Minimum = 1
        Me.tbarFlightOpacity.Name = "tbarFlightOpacity"
        Me.tbarFlightOpacity.TickFrequency = 26
        Me.tbarFlightOpacity.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarFlightOpacity.Value = 1
        '
        'lblFlightExtrude
        '
        resources.ApplyResources(Me.lblFlightExtrude, "lblFlightExtrude")
        Me.lblFlightExtrude.Name = "lblFlightExtrude"
        '
        'chkFlightExtrude
        '
        resources.ApplyResources(Me.chkFlightExtrude, "chkFlightExtrude")
        Me.chkFlightExtrude.Name = "chkFlightExtrude"
        Me.chkFlightExtrude.UseVisualStyleBackColor = True
        '
        'cboMapUpdateRate
        '
        Me.cboMapUpdateRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMapUpdateRate.FormattingEnabled = True
        resources.ApplyResources(Me.cboMapUpdateRate, "cboMapUpdateRate")
        Me.cboMapUpdateRate.Name = "cboMapUpdateRate"
        '
        'lblMapUpdateRate
        '
        resources.ApplyResources(Me.lblMapUpdateRate, "lblMapUpdateRate")
        Me.lblMapUpdateRate.Name = "lblMapUpdateRate"
        '
        'lblFlightPathThickness
        '
        resources.ApplyResources(Me.lblFlightPathThickness, "lblFlightPathThickness")
        Me.lblFlightPathThickness.Name = "lblFlightPathThickness"
        '
        'lblFlightPathColor
        '
        resources.ApplyResources(Me.lblFlightPathColor, "lblFlightPathColor")
        Me.lblFlightPathColor.Name = "lblFlightPathColor"
        '
        'tbarFlightWidth
        '
        resources.ApplyResources(Me.tbarFlightWidth, "tbarFlightWidth")
        Me.tbarFlightWidth.BackColor = System.Drawing.SystemColors.Control
        Me.tbarFlightWidth.LargeChange = 1
        Me.tbarFlightWidth.Minimum = 1
        Me.tbarFlightWidth.Name = "tbarFlightWidth"
        Me.tbarFlightWidth.TickFrequency = 26
        Me.tbarFlightWidth.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarFlightWidth.Value = 1
        '
        'cmdFlightColor
        '
        resources.ApplyResources(Me.cmdFlightColor, "cmdFlightColor")
        Me.cmdFlightColor.Name = "cmdFlightColor"
        Me.cmdFlightColor.UseVisualStyleBackColor = False
        '
        'grpGeneral
        '
        Me.grpGeneral.Controls.Add(Me.cboThrottleChannel)
        Me.grpGeneral.Controls.Add(Me.lblThrottleChannel)
        Me.grpGeneral.Controls.Add(Me.lblHeading)
        Me.grpGeneral.Controls.Add(Me.chkHeadingReverse)
        Me.grpGeneral.Controls.Add(Me.lblYaw)
        Me.grpGeneral.Controls.Add(Me.chkYawReverse)
        Me.grpGeneral.Controls.Add(Me.lblRoll)
        Me.grpGeneral.Controls.Add(Me.chkRollReverse)
        Me.grpGeneral.Controls.Add(Me.lblPitch)
        Me.grpGeneral.Controls.Add(Me.chkPitchReverse)
        Me.grpGeneral.Controls.Add(Me.cbo3DModel)
        Me.grpGeneral.Controls.Add(Me.lbl3DModel)
        Me.grpGeneral.Controls.Add(Me.cboMaxSpeed)
        Me.grpGeneral.Controls.Add(Me.lblMaxSpeed)
        Me.grpGeneral.Controls.Add(Me.lblSpeedUnits)
        Me.grpGeneral.Controls.Add(Me.cboSpeedUnits)
        Me.grpGeneral.Controls.Add(Me.lblDistanceUnits)
        Me.grpGeneral.Controls.Add(Me.cboDistanceUnits)
        resources.ApplyResources(Me.grpGeneral, "grpGeneral")
        Me.grpGeneral.Name = "grpGeneral"
        Me.grpGeneral.TabStop = False
        '
        'cboThrottleChannel
        '
        Me.cboThrottleChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboThrottleChannel.FormattingEnabled = True
        resources.ApplyResources(Me.cboThrottleChannel, "cboThrottleChannel")
        Me.cboThrottleChannel.Name = "cboThrottleChannel"
        '
        'lblThrottleChannel
        '
        resources.ApplyResources(Me.lblThrottleChannel, "lblThrottleChannel")
        Me.lblThrottleChannel.Name = "lblThrottleChannel"
        '
        'lblHeading
        '
        resources.ApplyResources(Me.lblHeading, "lblHeading")
        Me.lblHeading.Name = "lblHeading"
        '
        'chkHeadingReverse
        '
        resources.ApplyResources(Me.chkHeadingReverse, "chkHeadingReverse")
        Me.chkHeadingReverse.Name = "chkHeadingReverse"
        Me.chkHeadingReverse.UseVisualStyleBackColor = True
        '
        'lblYaw
        '
        resources.ApplyResources(Me.lblYaw, "lblYaw")
        Me.lblYaw.Name = "lblYaw"
        '
        'chkYawReverse
        '
        resources.ApplyResources(Me.chkYawReverse, "chkYawReverse")
        Me.chkYawReverse.Name = "chkYawReverse"
        Me.chkYawReverse.UseVisualStyleBackColor = True
        '
        'lblRoll
        '
        resources.ApplyResources(Me.lblRoll, "lblRoll")
        Me.lblRoll.Name = "lblRoll"
        '
        'chkRollReverse
        '
        resources.ApplyResources(Me.chkRollReverse, "chkRollReverse")
        Me.chkRollReverse.Name = "chkRollReverse"
        Me.chkRollReverse.UseVisualStyleBackColor = True
        '
        'lblPitch
        '
        resources.ApplyResources(Me.lblPitch, "lblPitch")
        Me.lblPitch.Name = "lblPitch"
        '
        'chkPitchReverse
        '
        resources.ApplyResources(Me.chkPitchReverse, "chkPitchReverse")
        Me.chkPitchReverse.Name = "chkPitchReverse"
        Me.chkPitchReverse.UseVisualStyleBackColor = True
        '
        'cbo3DModel
        '
        Me.cbo3DModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo3DModel.FormattingEnabled = True
        resources.ApplyResources(Me.cbo3DModel, "cbo3DModel")
        Me.cbo3DModel.Name = "cbo3DModel"
        Me.cbo3DModel.Sorted = True
        '
        'lbl3DModel
        '
        resources.ApplyResources(Me.lbl3DModel, "lbl3DModel")
        Me.lbl3DModel.Name = "lbl3DModel"
        '
        'cboMaxSpeed
        '
        Me.cboMaxSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaxSpeed.FormattingEnabled = True
        resources.ApplyResources(Me.cboMaxSpeed, "cboMaxSpeed")
        Me.cboMaxSpeed.Name = "cboMaxSpeed"
        '
        'lblMaxSpeed
        '
        resources.ApplyResources(Me.lblMaxSpeed, "lblMaxSpeed")
        Me.lblMaxSpeed.Name = "lblMaxSpeed"
        '
        'lblSpeedUnits
        '
        resources.ApplyResources(Me.lblSpeedUnits, "lblSpeedUnits")
        Me.lblSpeedUnits.Name = "lblSpeedUnits"
        '
        'cboSpeedUnits
        '
        Me.cboSpeedUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSpeedUnits.FormattingEnabled = True
        resources.ApplyResources(Me.cboSpeedUnits, "cboSpeedUnits")
        Me.cboSpeedUnits.Name = "cboSpeedUnits"
        '
        'lblDistanceUnits
        '
        resources.ApplyResources(Me.lblDistanceUnits, "lblDistanceUnits")
        Me.lblDistanceUnits.Name = "lblDistanceUnits"
        '
        'cboDistanceUnits
        '
        Me.cboDistanceUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistanceUnits.FormattingEnabled = True
        resources.ApplyResources(Me.cboDistanceUnits, "cboDistanceUnits")
        Me.cboDistanceUnits.Name = "cboDistanceUnits"
        '
        'cmdSave
        '
        resources.ApplyResources(Me.cmdSave, "cmdSave")
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'grpMissionPath
        '
        Me.grpMissionPath.Controls.Add(Me.lblMissionOpacity)
        Me.grpMissionPath.Controls.Add(Me.tbarMissionOpacity)
        Me.grpMissionPath.Controls.Add(Me.lblMissionExtrude)
        Me.grpMissionPath.Controls.Add(Me.chkMissionExtrude)
        Me.grpMissionPath.Controls.Add(Me.lblMissionPathThickness)
        Me.grpMissionPath.Controls.Add(Me.lblMissionPathColor)
        Me.grpMissionPath.Controls.Add(Me.tbarMissionWidth)
        Me.grpMissionPath.Controls.Add(Me.cmdMissionColor)
        resources.ApplyResources(Me.grpMissionPath, "grpMissionPath")
        Me.grpMissionPath.Name = "grpMissionPath"
        Me.grpMissionPath.TabStop = False
        '
        'lblMissionOpacity
        '
        resources.ApplyResources(Me.lblMissionOpacity, "lblMissionOpacity")
        Me.lblMissionOpacity.Name = "lblMissionOpacity"
        '
        'tbarMissionOpacity
        '
        resources.ApplyResources(Me.tbarMissionOpacity, "tbarMissionOpacity")
        Me.tbarMissionOpacity.BackColor = System.Drawing.SystemColors.Control
        Me.tbarMissionOpacity.LargeChange = 1
        Me.tbarMissionOpacity.Maximum = 255
        Me.tbarMissionOpacity.Minimum = 1
        Me.tbarMissionOpacity.Name = "tbarMissionOpacity"
        Me.tbarMissionOpacity.TickFrequency = 26
        Me.tbarMissionOpacity.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarMissionOpacity.Value = 1
        '
        'lblMissionExtrude
        '
        resources.ApplyResources(Me.lblMissionExtrude, "lblMissionExtrude")
        Me.lblMissionExtrude.Name = "lblMissionExtrude"
        '
        'chkMissionExtrude
        '
        resources.ApplyResources(Me.chkMissionExtrude, "chkMissionExtrude")
        Me.chkMissionExtrude.Name = "chkMissionExtrude"
        Me.chkMissionExtrude.UseVisualStyleBackColor = True
        '
        'lblMissionPathThickness
        '
        resources.ApplyResources(Me.lblMissionPathThickness, "lblMissionPathThickness")
        Me.lblMissionPathThickness.Name = "lblMissionPathThickness"
        '
        'lblMissionPathColor
        '
        resources.ApplyResources(Me.lblMissionPathColor, "lblMissionPathColor")
        Me.lblMissionPathColor.Name = "lblMissionPathColor"
        '
        'tbarMissionWidth
        '
        resources.ApplyResources(Me.tbarMissionWidth, "tbarMissionWidth")
        Me.tbarMissionWidth.BackColor = System.Drawing.SystemColors.Control
        Me.tbarMissionWidth.LargeChange = 1
        Me.tbarMissionWidth.Minimum = 1
        Me.tbarMissionWidth.Name = "tbarMissionWidth"
        Me.tbarMissionWidth.TickFrequency = 26
        Me.tbarMissionWidth.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarMissionWidth.Value = 1
        '
        'cmdMissionColor
        '
        resources.ApplyResources(Me.cmdMissionColor, "cmdMissionColor")
        Me.cmdMissionColor.Name = "cmdMissionColor"
        Me.cmdMissionColor.UseVisualStyleBackColor = False
        '
        'grpInstrumentSelection
        '
        Me.grpInstrumentSelection.Controls.Add(Me.chkInstBattery)
        Me.grpInstrumentSelection.Controls.Add(Me.chkInstTurn)
        Me.grpInstrumentSelection.Controls.Add(Me.chkInst3DModel)
        Me.grpInstrumentSelection.Controls.Add(Me.chkInstVertical)
        Me.grpInstrumentSelection.Controls.Add(Me.chkInstHeading)
        Me.grpInstrumentSelection.Controls.Add(Me.chkInstAttitude)
        Me.grpInstrumentSelection.Controls.Add(Me.chkInstAltimeter)
        Me.grpInstrumentSelection.Controls.Add(Me.chkInstSpeed)
        resources.ApplyResources(Me.grpInstrumentSelection, "grpInstrumentSelection")
        Me.grpInstrumentSelection.Name = "grpInstrumentSelection"
        Me.grpInstrumentSelection.TabStop = False
        '
        'chkInstBattery
        '
        resources.ApplyResources(Me.chkInstBattery, "chkInstBattery")
        Me.chkInstBattery.Name = "chkInstBattery"
        Me.chkInstBattery.UseVisualStyleBackColor = True
        '
        'chkInstTurn
        '
        resources.ApplyResources(Me.chkInstTurn, "chkInstTurn")
        Me.chkInstTurn.Name = "chkInstTurn"
        Me.chkInstTurn.UseVisualStyleBackColor = True
        '
        'chkInst3DModel
        '
        resources.ApplyResources(Me.chkInst3DModel, "chkInst3DModel")
        Me.chkInst3DModel.Name = "chkInst3DModel"
        Me.chkInst3DModel.UseVisualStyleBackColor = True
        '
        'chkInstVertical
        '
        resources.ApplyResources(Me.chkInstVertical, "chkInstVertical")
        Me.chkInstVertical.Name = "chkInstVertical"
        Me.chkInstVertical.UseVisualStyleBackColor = True
        '
        'chkInstHeading
        '
        resources.ApplyResources(Me.chkInstHeading, "chkInstHeading")
        Me.chkInstHeading.Name = "chkInstHeading"
        Me.chkInstHeading.UseVisualStyleBackColor = True
        '
        'chkInstAttitude
        '
        resources.ApplyResources(Me.chkInstAttitude, "chkInstAttitude")
        Me.chkInstAttitude.Name = "chkInstAttitude"
        Me.chkInstAttitude.UseVisualStyleBackColor = True
        '
        'chkInstAltimeter
        '
        resources.ApplyResources(Me.chkInstAltimeter, "chkInstAltimeter")
        Me.chkInstAltimeter.Name = "chkInstAltimeter"
        Me.chkInstAltimeter.UseVisualStyleBackColor = True
        '
        'chkInstSpeed
        '
        resources.ApplyResources(Me.chkInstSpeed, "chkInstSpeed")
        Me.chkInstSpeed.Name = "chkInstSpeed"
        Me.chkInstSpeed.UseVisualStyleBackColor = True
        '
        'grpBatteryThrottle
        '
        Me.grpBatteryThrottle.Controls.Add(Me.cboThrottleColor)
        Me.grpBatteryThrottle.Controls.Add(Me.lblThrottleColor)
        Me.grpBatteryThrottle.Controls.Add(Me.cboMAHColor)
        Me.grpBatteryThrottle.Controls.Add(Me.lblMahColor)
        Me.grpBatteryThrottle.Controls.Add(Me.lblMahMax)
        Me.grpBatteryThrottle.Controls.Add(Me.txtMAHMax)
        Me.grpBatteryThrottle.Controls.Add(Me.lblMahMin)
        Me.grpBatteryThrottle.Controls.Add(Me.txtMAHMin)
        Me.grpBatteryThrottle.Controls.Add(Me.cboAmperageColor)
        Me.grpBatteryThrottle.Controls.Add(Me.lblAmperageColor)
        Me.grpBatteryThrottle.Controls.Add(Me.lblAmperageMax)
        Me.grpBatteryThrottle.Controls.Add(Me.txtAmperageMax)
        Me.grpBatteryThrottle.Controls.Add(Me.cboVoltageColor)
        Me.grpBatteryThrottle.Controls.Add(Me.lblVoltageColor)
        Me.grpBatteryThrottle.Controls.Add(Me.lblVoltageMax)
        Me.grpBatteryThrottle.Controls.Add(Me.txtVoltageMax)
        Me.grpBatteryThrottle.Controls.Add(Me.lblVoltageMin)
        Me.grpBatteryThrottle.Controls.Add(Me.txtVoltageMin)
        resources.ApplyResources(Me.grpBatteryThrottle, "grpBatteryThrottle")
        Me.grpBatteryThrottle.Name = "grpBatteryThrottle"
        Me.grpBatteryThrottle.TabStop = False
        '
        'cboThrottleColor
        '
        Me.cboThrottleColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboThrottleColor.FormattingEnabled = True
        resources.ApplyResources(Me.cboThrottleColor, "cboThrottleColor")
        Me.cboThrottleColor.Name = "cboThrottleColor"
        '
        'lblThrottleColor
        '
        resources.ApplyResources(Me.lblThrottleColor, "lblThrottleColor")
        Me.lblThrottleColor.Name = "lblThrottleColor"
        '
        'cboMAHColor
        '
        Me.cboMAHColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMAHColor.FormattingEnabled = True
        resources.ApplyResources(Me.cboMAHColor, "cboMAHColor")
        Me.cboMAHColor.Name = "cboMAHColor"
        '
        'lblMahColor
        '
        resources.ApplyResources(Me.lblMahColor, "lblMahColor")
        Me.lblMahColor.Name = "lblMahColor"
        '
        'lblMahMax
        '
        resources.ApplyResources(Me.lblMahMax, "lblMahMax")
        Me.lblMahMax.Name = "lblMahMax"
        '
        'txtMAHMax
        '
        resources.ApplyResources(Me.txtMAHMax, "txtMAHMax")
        Me.txtMAHMax.Name = "txtMAHMax"
        '
        'lblMahMin
        '
        resources.ApplyResources(Me.lblMahMin, "lblMahMin")
        Me.lblMahMin.Name = "lblMahMin"
        '
        'txtMAHMin
        '
        resources.ApplyResources(Me.txtMAHMin, "txtMAHMin")
        Me.txtMAHMin.Name = "txtMAHMin"
        '
        'cboAmperageColor
        '
        Me.cboAmperageColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAmperageColor.FormattingEnabled = True
        resources.ApplyResources(Me.cboAmperageColor, "cboAmperageColor")
        Me.cboAmperageColor.Name = "cboAmperageColor"
        '
        'lblAmperageColor
        '
        resources.ApplyResources(Me.lblAmperageColor, "lblAmperageColor")
        Me.lblAmperageColor.Name = "lblAmperageColor"
        '
        'lblAmperageMax
        '
        resources.ApplyResources(Me.lblAmperageMax, "lblAmperageMax")
        Me.lblAmperageMax.Name = "lblAmperageMax"
        '
        'txtAmperageMax
        '
        resources.ApplyResources(Me.txtAmperageMax, "txtAmperageMax")
        Me.txtAmperageMax.Name = "txtAmperageMax"
        '
        'cboVoltageColor
        '
        Me.cboVoltageColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVoltageColor.FormattingEnabled = True
        resources.ApplyResources(Me.cboVoltageColor, "cboVoltageColor")
        Me.cboVoltageColor.Name = "cboVoltageColor"
        '
        'lblVoltageColor
        '
        resources.ApplyResources(Me.lblVoltageColor, "lblVoltageColor")
        Me.lblVoltageColor.Name = "lblVoltageColor"
        '
        'lblVoltageMax
        '
        resources.ApplyResources(Me.lblVoltageMax, "lblVoltageMax")
        Me.lblVoltageMax.Name = "lblVoltageMax"
        '
        'txtVoltageMax
        '
        resources.ApplyResources(Me.txtVoltageMax, "txtVoltageMax")
        Me.txtVoltageMax.Name = "txtVoltageMax"
        '
        'lblVoltageMin
        '
        resources.ApplyResources(Me.lblVoltageMin, "lblVoltageMin")
        Me.lblVoltageMin.Name = "lblVoltageMin"
        '
        'txtVoltageMin
        '
        resources.ApplyResources(Me.txtVoltageMin, "txtVoltageMin")
        Me.txtVoltageMin.Name = "txtVoltageMin"
        '
        'frmSettings
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpBatteryThrottle)
        Me.Controls.Add(Me.grpInstrumentSelection)
        Me.Controls.Add(Me.grpMissionPath)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.grpGeneral)
        Me.Controls.Add(Me.grpFlightPath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSettings"
        Me.grpFlightPath.ResumeLayout(False)
        CType(Me.tbarFlightOpacity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarFlightWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGeneral.ResumeLayout(False)
        Me.grpMissionPath.ResumeLayout(False)
        CType(Me.tbarMissionOpacity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarMissionWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpInstrumentSelection.ResumeLayout(False)
        Me.grpInstrumentSelection.PerformLayout()
        Me.grpBatteryThrottle.ResumeLayout(False)
        Me.grpBatteryThrottle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpFlightPath As System.Windows.Forms.GroupBox
    Friend WithEvents lblFlightExtrude As System.Windows.Forms.Label
    Friend WithEvents chkFlightExtrude As System.Windows.Forms.CheckBox
    Friend WithEvents cboMapUpdateRate As System.Windows.Forms.ComboBox
    Friend WithEvents lblMapUpdateRate As System.Windows.Forms.Label
    Friend WithEvents lblFlightPathThickness As System.Windows.Forms.Label
    Friend WithEvents lblFlightPathColor As System.Windows.Forms.Label
    Friend WithEvents tbarFlightWidth As System.Windows.Forms.TrackBar
    Friend WithEvents cmdFlightColor As System.Windows.Forms.Button
    Friend WithEvents grpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents lblRoll As System.Windows.Forms.Label
    Friend WithEvents chkRollReverse As System.Windows.Forms.CheckBox
    Friend WithEvents lblPitch As System.Windows.Forms.Label
    Friend WithEvents chkPitchReverse As System.Windows.Forms.CheckBox
    Friend WithEvents cbo3DModel As System.Windows.Forms.ComboBox
    Friend WithEvents lbl3DModel As System.Windows.Forms.Label
    Friend WithEvents cboMaxSpeed As System.Windows.Forms.ComboBox
    Friend WithEvents lblMaxSpeed As System.Windows.Forms.Label
    Friend WithEvents lblSpeedUnits As System.Windows.Forms.Label
    Friend WithEvents cboSpeedUnits As System.Windows.Forms.ComboBox
    Friend WithEvents lblDistanceUnits As System.Windows.Forms.Label
    Friend WithEvents cboDistanceUnits As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents lblHeading As System.Windows.Forms.Label
    Friend WithEvents chkHeadingReverse As System.Windows.Forms.CheckBox
    Friend WithEvents lblYaw As System.Windows.Forms.Label
    Friend WithEvents chkYawReverse As System.Windows.Forms.CheckBox
    Friend WithEvents grpMissionPath As System.Windows.Forms.GroupBox
    Friend WithEvents lblMissionExtrude As System.Windows.Forms.Label
    Friend WithEvents chkMissionExtrude As System.Windows.Forms.CheckBox
    Friend WithEvents lblMissionPathThickness As System.Windows.Forms.Label
    Friend WithEvents lblMissionPathColor As System.Windows.Forms.Label
    Friend WithEvents tbarMissionWidth As System.Windows.Forms.TrackBar
    Friend WithEvents cmdMissionColor As System.Windows.Forms.Button
    Friend WithEvents lblFlightOpacity As System.Windows.Forms.Label
    Friend WithEvents tbarFlightOpacity As System.Windows.Forms.TrackBar
    Friend WithEvents lblMissionOpacity As System.Windows.Forms.Label
    Friend WithEvents tbarMissionOpacity As System.Windows.Forms.TrackBar
    Friend WithEvents cboThrottleChannel As System.Windows.Forms.ComboBox
    Friend WithEvents lblThrottleChannel As System.Windows.Forms.Label
    Friend WithEvents grpInstrumentSelection As System.Windows.Forms.GroupBox
    Friend WithEvents chkInst3DModel As System.Windows.Forms.CheckBox
    Friend WithEvents chkInstVertical As System.Windows.Forms.CheckBox
    Friend WithEvents chkInstHeading As System.Windows.Forms.CheckBox
    Friend WithEvents chkInstAttitude As System.Windows.Forms.CheckBox
    Friend WithEvents chkInstAltimeter As System.Windows.Forms.CheckBox
    Friend WithEvents chkInstSpeed As System.Windows.Forms.CheckBox
    Friend WithEvents chkInstBattery As System.Windows.Forms.CheckBox
    Friend WithEvents chkInstTurn As System.Windows.Forms.CheckBox
    Friend WithEvents grpBatteryThrottle As System.Windows.Forms.GroupBox
    Friend WithEvents txtVoltageMin As System.Windows.Forms.TextBox
    Friend WithEvents cboThrottleColor As System.Windows.Forms.ComboBox
    Friend WithEvents lblThrottleColor As System.Windows.Forms.Label
    Friend WithEvents cboMAHColor As System.Windows.Forms.ComboBox
    Friend WithEvents lblMahColor As System.Windows.Forms.Label
    Friend WithEvents lblMahMax As System.Windows.Forms.Label
    Friend WithEvents txtMAHMax As System.Windows.Forms.TextBox
    Friend WithEvents lblMahMin As System.Windows.Forms.Label
    Friend WithEvents txtMAHMin As System.Windows.Forms.TextBox
    Friend WithEvents cboAmperageColor As System.Windows.Forms.ComboBox
    Friend WithEvents lblAmperageColor As System.Windows.Forms.Label
    Friend WithEvents lblAmperageMax As System.Windows.Forms.Label
    Friend WithEvents txtAmperageMax As System.Windows.Forms.TextBox
    Friend WithEvents cboVoltageColor As System.Windows.Forms.ComboBox
    Friend WithEvents lblVoltageColor As System.Windows.Forms.Label
    Friend WithEvents lblVoltageMax As System.Windows.Forms.Label
    Friend WithEvents txtVoltageMax As System.Windows.Forms.TextBox
    Friend WithEvents lblVoltageMin As System.Windows.Forms.Label
End Class
