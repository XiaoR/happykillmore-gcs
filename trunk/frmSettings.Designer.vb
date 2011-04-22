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
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.tabSettings = New System.Windows.Forms.TabControl
        Me.tabGeneral = New System.Windows.Forms.TabPage
        Me.grpGeneral = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbo2wayTimeout = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbo2wayRetries = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboWarningTimeout = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboAlarmTimeout = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboMapSource = New System.Windows.Forms.ComboBox
        Me.lblAltitudeOffset = New System.Windows.Forms.Label
        Me.cboAltitudeOffset = New System.Windows.Forms.ComboBox
        Me.lblLanguage = New System.Windows.Forms.Label
        Me.cboLanguage = New System.Windows.Forms.ComboBox
        Me.cboThrottleChannel = New System.Windows.Forms.ComboBox
        Me.lblThrottleChannel = New System.Windows.Forms.Label
        Me.lblHeadingReverse = New System.Windows.Forms.Label
        Me.chkHeadingReverse = New System.Windows.Forms.CheckBox
        Me.lblYawReverse = New System.Windows.Forms.Label
        Me.chkYawReverse = New System.Windows.Forms.CheckBox
        Me.lblRollReverse = New System.Windows.Forms.Label
        Me.chkRollReverse = New System.Windows.Forms.CheckBox
        Me.lblPitchReverse = New System.Windows.Forms.Label
        Me.chkPitchReverse = New System.Windows.Forms.CheckBox
        Me.cbo3DModel = New System.Windows.Forms.ComboBox
        Me.lbl3DModel = New System.Windows.Forms.Label
        Me.lblSpeedUnits = New System.Windows.Forms.Label
        Me.cboSpeedUnits = New System.Windows.Forms.ComboBox
        Me.lblDistanceUnits = New System.Windows.Forms.Label
        Me.cboDistanceUnits = New System.Windows.Forms.ComboBox
        Me.tabGoogleEarth = New System.Windows.Forms.TabPage
        Me.grpGoogleEarthKey = New System.Windows.Forms.GroupBox
        Me.txtGoogleEarthKey = New System.Windows.Forms.TextBox
        Me.grpGoogleEarthFeatures = New System.Windows.Forms.GroupBox
        Me.lblGETerrain = New System.Windows.Forms.Label
        Me.chkGETerrain = New System.Windows.Forms.CheckBox
        Me.lblGEBorders = New System.Windows.Forms.Label
        Me.chkGEBorders = New System.Windows.Forms.CheckBox
        Me.lblGETrees = New System.Windows.Forms.Label
        Me.chkGETrees = New System.Windows.Forms.CheckBox
        Me.lblGEBuildings = New System.Windows.Forms.Label
        Me.chkGEBuildings = New System.Windows.Forms.CheckBox
        Me.lblGERoads = New System.Windows.Forms.Label
        Me.chkGERoads = New System.Windows.Forms.CheckBox
        Me.grpMissionPath = New System.Windows.Forms.GroupBox
        Me.lblClamptoGround = New System.Windows.Forms.Label
        Me.chkClampToGround = New System.Windows.Forms.CheckBox
        Me.lblMissionOpacity = New System.Windows.Forms.Label
        Me.tbarMissionOpacity = New System.Windows.Forms.TrackBar
        Me.lblMissionExtrude = New System.Windows.Forms.Label
        Me.chkMissionExtrude = New System.Windows.Forms.CheckBox
        Me.lblMissionPathThickness = New System.Windows.Forms.Label
        Me.lblMissionPathColor = New System.Windows.Forms.Label
        Me.tbarMissionWidth = New System.Windows.Forms.TrackBar
        Me.cmdMissionColor = New System.Windows.Forms.Button
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
        Me.tabInstruments = New System.Windows.Forms.TabPage
        Me.grpBatteryThrottle = New System.Windows.Forms.GroupBox
        Me.cboMaxSpeed = New System.Windows.Forms.ComboBox
        Me.lblMaxSpeed = New System.Windows.Forms.Label
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
        Me.grpInstrumentSelection = New System.Windows.Forms.GroupBox
        Me.chkInstBattery = New System.Windows.Forms.CheckBox
        Me.chkInstTurn = New System.Windows.Forms.CheckBox
        Me.chkInst3DModel = New System.Windows.Forms.CheckBox
        Me.chkInstVertical = New System.Windows.Forms.CheckBox
        Me.chkInstHeading = New System.Windows.Forms.CheckBox
        Me.chkInstAttitude = New System.Windows.Forms.CheckBox
        Me.chkInstAltimeter = New System.Windows.Forms.CheckBox
        Me.chkInstSpeed = New System.Windows.Forms.CheckBox
        Me.tabSpeech = New System.Windows.Forms.TabPage
        Me.txtAltitudeMin = New System.Windows.Forms.TextBox
        Me.lblAltitudeMinValue = New System.Windows.Forms.Label
        Me.cmdAltitudeAlarm = New System.Windows.Forms.Button
        Me.txtAltitudeAlarm = New System.Windows.Forms.TextBox
        Me.chkAnnounceAltitudeAlarm = New System.Windows.Forms.CheckBox
        Me.cmdAlarmPlay = New System.Windows.Forms.Button
        Me.txtAnnounceAlarm = New System.Windows.Forms.TextBox
        Me.chkAnnounceLinkAlarm = New System.Windows.Forms.CheckBox
        Me.cmdWarningPlay = New System.Windows.Forms.Button
        Me.txtAnnounceWarning = New System.Windows.Forms.TextBox
        Me.chkAnnounceLinkWarning = New System.Windows.Forms.CheckBox
        Me.lblSpeechInterval = New System.Windows.Forms.Label
        Me.cboSpeechInterval = New System.Windows.Forms.ComboBox
        Me.cmdRegularIntervalPlay = New System.Windows.Forms.Button
        Me.txtAnnounceRegularInterval = New System.Windows.Forms.TextBox
        Me.chkAnnounceRegularInterval = New System.Windows.Forms.CheckBox
        Me.lblHelp = New System.Windows.Forms.Label
        Me.cmdModeChangePlay = New System.Windows.Forms.Button
        Me.txtAnnounceModeChange = New System.Windows.Forms.TextBox
        Me.chkAnnounceModeChange = New System.Windows.Forms.CheckBox
        Me.cmdWaypointPlay = New System.Windows.Forms.Button
        Me.txtAnnounceWaypoints = New System.Windows.Forms.TextBox
        Me.chkAnnounceWaypoints = New System.Windows.Forms.CheckBox
        Me.cboVoice = New System.Windows.Forms.ComboBox
        Me.lblVoice = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TrackBar1 = New System.Windows.Forms.TrackBar
        Me.Label12 = New System.Windows.Forms.Label
        Me.CheckBox5 = New System.Windows.Forms.CheckBox
        Me.ComboBox7 = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.TrackBar2 = New System.Windows.Forms.TrackBar
        Me.Button1 = New System.Windows.Forms.Button
        Me.chkManuelMode = New System.Windows.Forms.CheckBox
        Me.tabSettings.SuspendLayout()
        Me.tabGeneral.SuspendLayout()
        Me.grpGeneral.SuspendLayout()
        Me.tabGoogleEarth.SuspendLayout()
        Me.grpGoogleEarthKey.SuspendLayout()
        Me.grpGoogleEarthFeatures.SuspendLayout()
        Me.grpMissionPath.SuspendLayout()
        CType(Me.tbarMissionOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarMissionWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFlightPath.SuspendLayout()
        CType(Me.tbarFlightOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarFlightWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabInstruments.SuspendLayout()
        Me.grpBatteryThrottle.SuspendLayout()
        Me.grpInstrumentSelection.SuspendLayout()
        Me.tabSpeech.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'tabSettings
        '
        Me.tabSettings.Controls.Add(Me.tabGeneral)
        Me.tabSettings.Controls.Add(Me.tabGoogleEarth)
        Me.tabSettings.Controls.Add(Me.tabInstruments)
        Me.tabSettings.Controls.Add(Me.tabSpeech)
        resources.ApplyResources(Me.tabSettings, "tabSettings")
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.SelectedIndex = 0
        '
        'tabGeneral
        '
        Me.tabGeneral.Controls.Add(Me.grpGeneral)
        resources.ApplyResources(Me.tabGeneral, "tabGeneral")
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.UseVisualStyleBackColor = True
        '
        'grpGeneral
        '
        Me.grpGeneral.Controls.Add(Me.Label5)
        Me.grpGeneral.Controls.Add(Me.cbo2wayTimeout)
        Me.grpGeneral.Controls.Add(Me.Label4)
        Me.grpGeneral.Controls.Add(Me.cbo2wayRetries)
        Me.grpGeneral.Controls.Add(Me.Label3)
        Me.grpGeneral.Controls.Add(Me.cboWarningTimeout)
        Me.grpGeneral.Controls.Add(Me.Label2)
        Me.grpGeneral.Controls.Add(Me.cboAlarmTimeout)
        Me.grpGeneral.Controls.Add(Me.Label1)
        Me.grpGeneral.Controls.Add(Me.cboMapSource)
        Me.grpGeneral.Controls.Add(Me.lblAltitudeOffset)
        Me.grpGeneral.Controls.Add(Me.cboAltitudeOffset)
        Me.grpGeneral.Controls.Add(Me.lblLanguage)
        Me.grpGeneral.Controls.Add(Me.cboLanguage)
        Me.grpGeneral.Controls.Add(Me.cboThrottleChannel)
        Me.grpGeneral.Controls.Add(Me.lblThrottleChannel)
        Me.grpGeneral.Controls.Add(Me.lblHeadingReverse)
        Me.grpGeneral.Controls.Add(Me.chkHeadingReverse)
        Me.grpGeneral.Controls.Add(Me.lblYawReverse)
        Me.grpGeneral.Controls.Add(Me.chkYawReverse)
        Me.grpGeneral.Controls.Add(Me.lblRollReverse)
        Me.grpGeneral.Controls.Add(Me.chkRollReverse)
        Me.grpGeneral.Controls.Add(Me.lblPitchReverse)
        Me.grpGeneral.Controls.Add(Me.chkPitchReverse)
        Me.grpGeneral.Controls.Add(Me.cbo3DModel)
        Me.grpGeneral.Controls.Add(Me.lbl3DModel)
        Me.grpGeneral.Controls.Add(Me.lblSpeedUnits)
        Me.grpGeneral.Controls.Add(Me.cboSpeedUnits)
        Me.grpGeneral.Controls.Add(Me.lblDistanceUnits)
        Me.grpGeneral.Controls.Add(Me.cboDistanceUnits)
        resources.ApplyResources(Me.grpGeneral, "grpGeneral")
        Me.grpGeneral.Name = "grpGeneral"
        Me.grpGeneral.TabStop = False
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'cbo2wayTimeout
        '
        Me.cbo2wayTimeout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo2wayTimeout.FormattingEnabled = True
        resources.ApplyResources(Me.cbo2wayTimeout, "cbo2wayTimeout")
        Me.cbo2wayTimeout.Name = "cbo2wayTimeout"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'cbo2wayRetries
        '
        Me.cbo2wayRetries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo2wayRetries.FormattingEnabled = True
        resources.ApplyResources(Me.cbo2wayRetries, "cbo2wayRetries")
        Me.cbo2wayRetries.Name = "cbo2wayRetries"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'cboWarningTimeout
        '
        Me.cboWarningTimeout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWarningTimeout.FormattingEnabled = True
        resources.ApplyResources(Me.cboWarningTimeout, "cboWarningTimeout")
        Me.cboWarningTimeout.Name = "cboWarningTimeout"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'cboAlarmTimeout
        '
        Me.cboAlarmTimeout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlarmTimeout.FormattingEnabled = True
        resources.ApplyResources(Me.cboAlarmTimeout, "cboAlarmTimeout")
        Me.cboAlarmTimeout.Name = "cboAlarmTimeout"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'cboMapSource
        '
        Me.cboMapSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMapSource.FormattingEnabled = True
        resources.ApplyResources(Me.cboMapSource, "cboMapSource")
        Me.cboMapSource.Name = "cboMapSource"
        '
        'lblAltitudeOffset
        '
        resources.ApplyResources(Me.lblAltitudeOffset, "lblAltitudeOffset")
        Me.lblAltitudeOffset.Name = "lblAltitudeOffset"
        '
        'cboAltitudeOffset
        '
        Me.cboAltitudeOffset.DropDownHeight = 300
        Me.cboAltitudeOffset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAltitudeOffset.FormattingEnabled = True
        resources.ApplyResources(Me.cboAltitudeOffset, "cboAltitudeOffset")
        Me.cboAltitudeOffset.Name = "cboAltitudeOffset"
        '
        'lblLanguage
        '
        resources.ApplyResources(Me.lblLanguage, "lblLanguage")
        Me.lblLanguage.Name = "lblLanguage"
        '
        'cboLanguage
        '
        Me.cboLanguage.DropDownHeight = 300
        Me.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLanguage.FormattingEnabled = True
        resources.ApplyResources(Me.cboLanguage, "cboLanguage")
        Me.cboLanguage.Name = "cboLanguage"
        '
        'cboThrottleChannel
        '
        Me.cboThrottleChannel.DropDownHeight = 300
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
        'lblHeadingReverse
        '
        resources.ApplyResources(Me.lblHeadingReverse, "lblHeadingReverse")
        Me.lblHeadingReverse.Name = "lblHeadingReverse"
        '
        'chkHeadingReverse
        '
        resources.ApplyResources(Me.chkHeadingReverse, "chkHeadingReverse")
        Me.chkHeadingReverse.Name = "chkHeadingReverse"
        Me.chkHeadingReverse.UseVisualStyleBackColor = True
        '
        'lblYawReverse
        '
        resources.ApplyResources(Me.lblYawReverse, "lblYawReverse")
        Me.lblYawReverse.Name = "lblYawReverse"
        '
        'chkYawReverse
        '
        resources.ApplyResources(Me.chkYawReverse, "chkYawReverse")
        Me.chkYawReverse.Name = "chkYawReverse"
        Me.chkYawReverse.UseVisualStyleBackColor = True
        '
        'lblRollReverse
        '
        resources.ApplyResources(Me.lblRollReverse, "lblRollReverse")
        Me.lblRollReverse.Name = "lblRollReverse"
        '
        'chkRollReverse
        '
        resources.ApplyResources(Me.chkRollReverse, "chkRollReverse")
        Me.chkRollReverse.Name = "chkRollReverse"
        Me.chkRollReverse.UseVisualStyleBackColor = True
        '
        'lblPitchReverse
        '
        resources.ApplyResources(Me.lblPitchReverse, "lblPitchReverse")
        Me.lblPitchReverse.Name = "lblPitchReverse"
        '
        'chkPitchReverse
        '
        resources.ApplyResources(Me.chkPitchReverse, "chkPitchReverse")
        Me.chkPitchReverse.Name = "chkPitchReverse"
        Me.chkPitchReverse.UseVisualStyleBackColor = True
        '
        'cbo3DModel
        '
        Me.cbo3DModel.DropDownHeight = 300
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
        'tabGoogleEarth
        '
        Me.tabGoogleEarth.Controls.Add(Me.grpGoogleEarthKey)
        Me.tabGoogleEarth.Controls.Add(Me.grpGoogleEarthFeatures)
        Me.tabGoogleEarth.Controls.Add(Me.grpMissionPath)
        Me.tabGoogleEarth.Controls.Add(Me.grpFlightPath)
        resources.ApplyResources(Me.tabGoogleEarth, "tabGoogleEarth")
        Me.tabGoogleEarth.Name = "tabGoogleEarth"
        Me.tabGoogleEarth.UseVisualStyleBackColor = True
        '
        'grpGoogleEarthKey
        '
        Me.grpGoogleEarthKey.Controls.Add(Me.txtGoogleEarthKey)
        resources.ApplyResources(Me.grpGoogleEarthKey, "grpGoogleEarthKey")
        Me.grpGoogleEarthKey.Name = "grpGoogleEarthKey"
        Me.grpGoogleEarthKey.TabStop = False
        '
        'txtGoogleEarthKey
        '
        resources.ApplyResources(Me.txtGoogleEarthKey, "txtGoogleEarthKey")
        Me.txtGoogleEarthKey.Name = "txtGoogleEarthKey"
        '
        'grpGoogleEarthFeatures
        '
        Me.grpGoogleEarthFeatures.Controls.Add(Me.lblGETerrain)
        Me.grpGoogleEarthFeatures.Controls.Add(Me.chkGETerrain)
        Me.grpGoogleEarthFeatures.Controls.Add(Me.lblGEBorders)
        Me.grpGoogleEarthFeatures.Controls.Add(Me.chkGEBorders)
        Me.grpGoogleEarthFeatures.Controls.Add(Me.lblGETrees)
        Me.grpGoogleEarthFeatures.Controls.Add(Me.chkGETrees)
        Me.grpGoogleEarthFeatures.Controls.Add(Me.lblGEBuildings)
        Me.grpGoogleEarthFeatures.Controls.Add(Me.chkGEBuildings)
        Me.grpGoogleEarthFeatures.Controls.Add(Me.lblGERoads)
        Me.grpGoogleEarthFeatures.Controls.Add(Me.chkGERoads)
        resources.ApplyResources(Me.grpGoogleEarthFeatures, "grpGoogleEarthFeatures")
        Me.grpGoogleEarthFeatures.Name = "grpGoogleEarthFeatures"
        Me.grpGoogleEarthFeatures.TabStop = False
        '
        'lblGETerrain
        '
        resources.ApplyResources(Me.lblGETerrain, "lblGETerrain")
        Me.lblGETerrain.Name = "lblGETerrain"
        '
        'chkGETerrain
        '
        resources.ApplyResources(Me.chkGETerrain, "chkGETerrain")
        Me.chkGETerrain.Name = "chkGETerrain"
        Me.chkGETerrain.UseVisualStyleBackColor = True
        '
        'lblGEBorders
        '
        resources.ApplyResources(Me.lblGEBorders, "lblGEBorders")
        Me.lblGEBorders.Name = "lblGEBorders"
        '
        'chkGEBorders
        '
        resources.ApplyResources(Me.chkGEBorders, "chkGEBorders")
        Me.chkGEBorders.Name = "chkGEBorders"
        Me.chkGEBorders.UseVisualStyleBackColor = True
        '
        'lblGETrees
        '
        resources.ApplyResources(Me.lblGETrees, "lblGETrees")
        Me.lblGETrees.Name = "lblGETrees"
        '
        'chkGETrees
        '
        resources.ApplyResources(Me.chkGETrees, "chkGETrees")
        Me.chkGETrees.Name = "chkGETrees"
        Me.chkGETrees.UseVisualStyleBackColor = True
        '
        'lblGEBuildings
        '
        resources.ApplyResources(Me.lblGEBuildings, "lblGEBuildings")
        Me.lblGEBuildings.Name = "lblGEBuildings"
        '
        'chkGEBuildings
        '
        resources.ApplyResources(Me.chkGEBuildings, "chkGEBuildings")
        Me.chkGEBuildings.Name = "chkGEBuildings"
        Me.chkGEBuildings.UseVisualStyleBackColor = True
        '
        'lblGERoads
        '
        resources.ApplyResources(Me.lblGERoads, "lblGERoads")
        Me.lblGERoads.Name = "lblGERoads"
        '
        'chkGERoads
        '
        resources.ApplyResources(Me.chkGERoads, "chkGERoads")
        Me.chkGERoads.Name = "chkGERoads"
        Me.chkGERoads.UseVisualStyleBackColor = True
        '
        'grpMissionPath
        '
        Me.grpMissionPath.Controls.Add(Me.lblClamptoGround)
        Me.grpMissionPath.Controls.Add(Me.chkClampToGround)
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
        'lblClamptoGround
        '
        resources.ApplyResources(Me.lblClamptoGround, "lblClamptoGround")
        Me.lblClamptoGround.Name = "lblClamptoGround"
        '
        'chkClampToGround
        '
        resources.ApplyResources(Me.chkClampToGround, "chkClampToGround")
        Me.chkClampToGround.Name = "chkClampToGround"
        Me.chkClampToGround.UseVisualStyleBackColor = True
        '
        'lblMissionOpacity
        '
        resources.ApplyResources(Me.lblMissionOpacity, "lblMissionOpacity")
        Me.lblMissionOpacity.Name = "lblMissionOpacity"
        '
        'tbarMissionOpacity
        '
        resources.ApplyResources(Me.tbarMissionOpacity, "tbarMissionOpacity")
        Me.tbarMissionOpacity.BackColor = System.Drawing.SystemColors.ButtonHighlight
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
        Me.tbarMissionWidth.BackColor = System.Drawing.SystemColors.ButtonHighlight
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
        Me.tbarFlightOpacity.BackColor = System.Drawing.SystemColors.ButtonHighlight
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
        Me.tbarFlightWidth.BackColor = System.Drawing.SystemColors.ButtonHighlight
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
        'tabInstruments
        '
        Me.tabInstruments.Controls.Add(Me.grpBatteryThrottle)
        Me.tabInstruments.Controls.Add(Me.grpInstrumentSelection)
        resources.ApplyResources(Me.tabInstruments, "tabInstruments")
        Me.tabInstruments.Name = "tabInstruments"
        Me.tabInstruments.UseVisualStyleBackColor = True
        '
        'grpBatteryThrottle
        '
        Me.grpBatteryThrottle.Controls.Add(Me.cboMaxSpeed)
        Me.grpBatteryThrottle.Controls.Add(Me.lblMaxSpeed)
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
        'tabSpeech
        '
        Me.tabSpeech.Controls.Add(Me.chkManuelMode)
        Me.tabSpeech.Controls.Add(Me.cboVoice)
        Me.tabSpeech.Controls.Add(Me.chkAnnounceWaypoints)
        Me.tabSpeech.Controls.Add(Me.cboSpeechInterval)
        Me.tabSpeech.Controls.Add(Me.txtAltitudeMin)
        Me.tabSpeech.Controls.Add(Me.lblSpeechInterval)
        Me.tabSpeech.Controls.Add(Me.lblVoice)
        Me.tabSpeech.Controls.Add(Me.cmdRegularIntervalPlay)
        Me.tabSpeech.Controls.Add(Me.lblAltitudeMinValue)
        Me.tabSpeech.Controls.Add(Me.chkAnnounceLinkWarning)
        Me.tabSpeech.Controls.Add(Me.txtAnnounceRegularInterval)
        Me.tabSpeech.Controls.Add(Me.cmdAltitudeAlarm)
        Me.tabSpeech.Controls.Add(Me.txtAnnounceWarning)
        Me.tabSpeech.Controls.Add(Me.txtAnnounceWaypoints)
        Me.tabSpeech.Controls.Add(Me.chkAnnounceRegularInterval)
        Me.tabSpeech.Controls.Add(Me.txtAltitudeAlarm)
        Me.tabSpeech.Controls.Add(Me.cmdWarningPlay)
        Me.tabSpeech.Controls.Add(Me.cmdWaypointPlay)
        Me.tabSpeech.Controls.Add(Me.lblHelp)
        Me.tabSpeech.Controls.Add(Me.chkAnnounceAltitudeAlarm)
        Me.tabSpeech.Controls.Add(Me.chkAnnounceLinkAlarm)
        Me.tabSpeech.Controls.Add(Me.chkAnnounceModeChange)
        Me.tabSpeech.Controls.Add(Me.cmdModeChangePlay)
        Me.tabSpeech.Controls.Add(Me.cmdAlarmPlay)
        Me.tabSpeech.Controls.Add(Me.txtAnnounceAlarm)
        Me.tabSpeech.Controls.Add(Me.txtAnnounceModeChange)
        resources.ApplyResources(Me.tabSpeech, "tabSpeech")
        Me.tabSpeech.Name = "tabSpeech"
        Me.tabSpeech.UseVisualStyleBackColor = True
        '
        'txtAltitudeMin
        '
        resources.ApplyResources(Me.txtAltitudeMin, "txtAltitudeMin")
        Me.txtAltitudeMin.Name = "txtAltitudeMin"
        '
        'lblAltitudeMinValue
        '
        resources.ApplyResources(Me.lblAltitudeMinValue, "lblAltitudeMinValue")
        Me.lblAltitudeMinValue.Name = "lblAltitudeMinValue"
        '
        'cmdAltitudeAlarm
        '
        resources.ApplyResources(Me.cmdAltitudeAlarm, "cmdAltitudeAlarm")
        Me.cmdAltitudeAlarm.BackgroundImage = Global.HK_GCS.My.Resources.Resources.Play
        Me.cmdAltitudeAlarm.Name = "cmdAltitudeAlarm"
        Me.cmdAltitudeAlarm.UseVisualStyleBackColor = True
        '
        'txtAltitudeAlarm
        '
        resources.ApplyResources(Me.txtAltitudeAlarm, "txtAltitudeAlarm")
        Me.txtAltitudeAlarm.Name = "txtAltitudeAlarm"
        '
        'chkAnnounceAltitudeAlarm
        '
        resources.ApplyResources(Me.chkAnnounceAltitudeAlarm, "chkAnnounceAltitudeAlarm")
        Me.chkAnnounceAltitudeAlarm.Name = "chkAnnounceAltitudeAlarm"
        Me.chkAnnounceAltitudeAlarm.UseVisualStyleBackColor = True
        '
        'cmdAlarmPlay
        '
        resources.ApplyResources(Me.cmdAlarmPlay, "cmdAlarmPlay")
        Me.cmdAlarmPlay.BackgroundImage = Global.HK_GCS.My.Resources.Resources.Play
        Me.cmdAlarmPlay.Name = "cmdAlarmPlay"
        Me.cmdAlarmPlay.UseVisualStyleBackColor = True
        '
        'txtAnnounceAlarm
        '
        resources.ApplyResources(Me.txtAnnounceAlarm, "txtAnnounceAlarm")
        Me.txtAnnounceAlarm.Name = "txtAnnounceAlarm"
        '
        'chkAnnounceLinkAlarm
        '
        resources.ApplyResources(Me.chkAnnounceLinkAlarm, "chkAnnounceLinkAlarm")
        Me.chkAnnounceLinkAlarm.Name = "chkAnnounceLinkAlarm"
        Me.chkAnnounceLinkAlarm.UseVisualStyleBackColor = True
        '
        'cmdWarningPlay
        '
        resources.ApplyResources(Me.cmdWarningPlay, "cmdWarningPlay")
        Me.cmdWarningPlay.BackgroundImage = Global.HK_GCS.My.Resources.Resources.Play
        Me.cmdWarningPlay.Name = "cmdWarningPlay"
        Me.cmdWarningPlay.UseVisualStyleBackColor = True
        '
        'txtAnnounceWarning
        '
        resources.ApplyResources(Me.txtAnnounceWarning, "txtAnnounceWarning")
        Me.txtAnnounceWarning.Name = "txtAnnounceWarning"
        '
        'chkAnnounceLinkWarning
        '
        resources.ApplyResources(Me.chkAnnounceLinkWarning, "chkAnnounceLinkWarning")
        Me.chkAnnounceLinkWarning.Name = "chkAnnounceLinkWarning"
        Me.chkAnnounceLinkWarning.UseVisualStyleBackColor = True
        '
        'lblSpeechInterval
        '
        resources.ApplyResources(Me.lblSpeechInterval, "lblSpeechInterval")
        Me.lblSpeechInterval.Name = "lblSpeechInterval"
        '
        'cboSpeechInterval
        '
        Me.cboSpeechInterval.DropDownHeight = 300
        Me.cboSpeechInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboSpeechInterval, "cboSpeechInterval")
        Me.cboSpeechInterval.FormattingEnabled = True
        Me.cboSpeechInterval.Name = "cboSpeechInterval"
        '
        'cmdRegularIntervalPlay
        '
        resources.ApplyResources(Me.cmdRegularIntervalPlay, "cmdRegularIntervalPlay")
        Me.cmdRegularIntervalPlay.BackgroundImage = Global.HK_GCS.My.Resources.Resources.Play
        Me.cmdRegularIntervalPlay.Name = "cmdRegularIntervalPlay"
        Me.cmdRegularIntervalPlay.UseVisualStyleBackColor = True
        '
        'txtAnnounceRegularInterval
        '
        resources.ApplyResources(Me.txtAnnounceRegularInterval, "txtAnnounceRegularInterval")
        Me.txtAnnounceRegularInterval.Name = "txtAnnounceRegularInterval"
        '
        'chkAnnounceRegularInterval
        '
        resources.ApplyResources(Me.chkAnnounceRegularInterval, "chkAnnounceRegularInterval")
        Me.chkAnnounceRegularInterval.Name = "chkAnnounceRegularInterval"
        Me.chkAnnounceRegularInterval.UseVisualStyleBackColor = True
        '
        'lblHelp
        '
        resources.ApplyResources(Me.lblHelp, "lblHelp")
        Me.lblHelp.ForeColor = System.Drawing.Color.Black
        Me.lblHelp.Name = "lblHelp"
        '
        'cmdModeChangePlay
        '
        resources.ApplyResources(Me.cmdModeChangePlay, "cmdModeChangePlay")
        Me.cmdModeChangePlay.BackgroundImage = Global.HK_GCS.My.Resources.Resources.Play
        Me.cmdModeChangePlay.Name = "cmdModeChangePlay"
        Me.cmdModeChangePlay.UseVisualStyleBackColor = True
        '
        'txtAnnounceModeChange
        '
        resources.ApplyResources(Me.txtAnnounceModeChange, "txtAnnounceModeChange")
        Me.txtAnnounceModeChange.Name = "txtAnnounceModeChange"
        '
        'chkAnnounceModeChange
        '
        resources.ApplyResources(Me.chkAnnounceModeChange, "chkAnnounceModeChange")
        Me.chkAnnounceModeChange.Name = "chkAnnounceModeChange"
        Me.chkAnnounceModeChange.UseVisualStyleBackColor = True
        '
        'cmdWaypointPlay
        '
        resources.ApplyResources(Me.cmdWaypointPlay, "cmdWaypointPlay")
        Me.cmdWaypointPlay.BackgroundImage = Global.HK_GCS.My.Resources.Resources.Play
        Me.cmdWaypointPlay.Name = "cmdWaypointPlay"
        Me.cmdWaypointPlay.UseVisualStyleBackColor = True
        '
        'txtAnnounceWaypoints
        '
        resources.ApplyResources(Me.txtAnnounceWaypoints, "txtAnnounceWaypoints")
        Me.txtAnnounceWaypoints.Name = "txtAnnounceWaypoints"
        '
        'chkAnnounceWaypoints
        '
        resources.ApplyResources(Me.chkAnnounceWaypoints, "chkAnnounceWaypoints")
        Me.chkAnnounceWaypoints.Name = "chkAnnounceWaypoints"
        Me.chkAnnounceWaypoints.UseVisualStyleBackColor = True
        '
        'cboVoice
        '
        Me.cboVoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVoice.FormattingEnabled = True
        resources.ApplyResources(Me.cboVoice, "cboVoice")
        Me.cboVoice.Name = "cboVoice"
        '
        'lblVoice
        '
        resources.ApplyResources(Me.lblVoice, "lblVoice")
        Me.lblVoice.Name = "lblVoice"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'TrackBar1
        '
        resources.ApplyResources(Me.TrackBar1, "TrackBar1")
        Me.TrackBar1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TrackBar1.LargeChange = 1
        Me.TrackBar1.Maximum = 255
        Me.TrackBar1.Minimum = 1
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.TickFrequency = 26
        Me.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBar1.Value = 1
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'CheckBox5
        '
        resources.ApplyResources(Me.CheckBox5, "CheckBox5")
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'ComboBox7
        '
        Me.ComboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox7.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBox7, "ComboBox7")
        Me.ComboBox7.Name = "ComboBox7"
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Name = "Label15"
        '
        'TrackBar2
        '
        resources.ApplyResources(Me.TrackBar2, "TrackBar2")
        Me.TrackBar2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TrackBar2.LargeChange = 1
        Me.TrackBar2.Minimum = 1
        Me.TrackBar2.Name = "TrackBar2"
        Me.TrackBar2.TickFrequency = 26
        Me.TrackBar2.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBar2.Value = 1
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'chkManuelMode
        '
        resources.ApplyResources(Me.chkManuelMode, "chkManuelMode")
        Me.chkManuelMode.Name = "chkManuelMode"
        Me.chkManuelMode.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tabSettings)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmSettings"
        Me.ShowInTaskbar = False
        Me.tabSettings.ResumeLayout(False)
        Me.tabGeneral.ResumeLayout(False)
        Me.grpGeneral.ResumeLayout(False)
        Me.tabGoogleEarth.ResumeLayout(False)
        Me.grpGoogleEarthKey.ResumeLayout(False)
        Me.grpGoogleEarthKey.PerformLayout()
        Me.grpGoogleEarthFeatures.ResumeLayout(False)
        Me.grpMissionPath.ResumeLayout(False)
        CType(Me.tbarMissionOpacity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarMissionWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFlightPath.ResumeLayout(False)
        CType(Me.tbarFlightOpacity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarFlightWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabInstruments.ResumeLayout(False)
        Me.grpBatteryThrottle.ResumeLayout(False)
        Me.grpBatteryThrottle.PerformLayout()
        Me.grpInstrumentSelection.ResumeLayout(False)
        Me.grpInstrumentSelection.PerformLayout()
        Me.tabSpeech.ResumeLayout(False)
        Me.tabSpeech.PerformLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents tabSettings As System.Windows.Forms.TabControl
    Friend WithEvents tabGeneral As System.Windows.Forms.TabPage
    Friend WithEvents tabGoogleEarth As System.Windows.Forms.TabPage
    Friend WithEvents grpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents lblLanguage As System.Windows.Forms.Label
    Friend WithEvents cboLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents cboThrottleChannel As System.Windows.Forms.ComboBox
    Friend WithEvents lblThrottleChannel As System.Windows.Forms.Label
    Friend WithEvents lblHeadingReverse As System.Windows.Forms.Label
    Friend WithEvents chkHeadingReverse As System.Windows.Forms.CheckBox
    Friend WithEvents lblYawReverse As System.Windows.Forms.Label
    Friend WithEvents chkYawReverse As System.Windows.Forms.CheckBox
    Friend WithEvents lblRollReverse As System.Windows.Forms.Label
    Friend WithEvents chkRollReverse As System.Windows.Forms.CheckBox
    Friend WithEvents lblPitchReverse As System.Windows.Forms.Label
    Friend WithEvents chkPitchReverse As System.Windows.Forms.CheckBox
    Friend WithEvents cbo3DModel As System.Windows.Forms.ComboBox
    Friend WithEvents lbl3DModel As System.Windows.Forms.Label
    Friend WithEvents lblSpeedUnits As System.Windows.Forms.Label
    Friend WithEvents cboSpeedUnits As System.Windows.Forms.ComboBox
    Friend WithEvents lblDistanceUnits As System.Windows.Forms.Label
    Friend WithEvents cboDistanceUnits As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox7 As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TrackBar2 As System.Windows.Forms.TrackBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tabInstruments As System.Windows.Forms.TabPage
    Friend WithEvents grpBatteryThrottle As System.Windows.Forms.GroupBox
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
    Friend WithEvents txtVoltageMin As System.Windows.Forms.TextBox
    Friend WithEvents grpInstrumentSelection As System.Windows.Forms.GroupBox
    Friend WithEvents chkInstBattery As System.Windows.Forms.CheckBox
    Friend WithEvents chkInstTurn As System.Windows.Forms.CheckBox
    Friend WithEvents chkInst3DModel As System.Windows.Forms.CheckBox
    Friend WithEvents chkInstVertical As System.Windows.Forms.CheckBox
    Friend WithEvents chkInstHeading As System.Windows.Forms.CheckBox
    Friend WithEvents chkInstAttitude As System.Windows.Forms.CheckBox
    Friend WithEvents chkInstAltimeter As System.Windows.Forms.CheckBox
    Friend WithEvents chkInstSpeed As System.Windows.Forms.CheckBox
    Friend WithEvents tabSpeech As System.Windows.Forms.TabPage
    Friend WithEvents grpMissionPath As System.Windows.Forms.GroupBox
    Friend WithEvents lblMissionOpacity As System.Windows.Forms.Label
    Friend WithEvents tbarMissionOpacity As System.Windows.Forms.TrackBar
    Friend WithEvents lblMissionExtrude As System.Windows.Forms.Label
    Friend WithEvents chkMissionExtrude As System.Windows.Forms.CheckBox
    Friend WithEvents lblMissionPathThickness As System.Windows.Forms.Label
    Friend WithEvents lblMissionPathColor As System.Windows.Forms.Label
    Friend WithEvents tbarMissionWidth As System.Windows.Forms.TrackBar
    Friend WithEvents cmdMissionColor As System.Windows.Forms.Button
    Friend WithEvents grpFlightPath As System.Windows.Forms.GroupBox
    Friend WithEvents lblFlightOpacity As System.Windows.Forms.Label
    Friend WithEvents tbarFlightOpacity As System.Windows.Forms.TrackBar
    Friend WithEvents lblFlightExtrude As System.Windows.Forms.Label
    Friend WithEvents chkFlightExtrude As System.Windows.Forms.CheckBox
    Friend WithEvents cboMapUpdateRate As System.Windows.Forms.ComboBox
    Friend WithEvents lblMapUpdateRate As System.Windows.Forms.Label
    Friend WithEvents lblFlightPathThickness As System.Windows.Forms.Label
    Friend WithEvents lblFlightPathColor As System.Windows.Forms.Label
    Friend WithEvents tbarFlightWidth As System.Windows.Forms.TrackBar
    Friend WithEvents cmdFlightColor As System.Windows.Forms.Button
    Friend WithEvents grpGoogleEarthFeatures As System.Windows.Forms.GroupBox
    Friend WithEvents lblGERoads As System.Windows.Forms.Label
    Friend WithEvents chkGERoads As System.Windows.Forms.CheckBox
    Friend WithEvents lblGETerrain As System.Windows.Forms.Label
    Friend WithEvents chkGETerrain As System.Windows.Forms.CheckBox
    Friend WithEvents lblGEBorders As System.Windows.Forms.Label
    Friend WithEvents chkGEBorders As System.Windows.Forms.CheckBox
    Friend WithEvents lblGETrees As System.Windows.Forms.Label
    Friend WithEvents chkGETrees As System.Windows.Forms.CheckBox
    Friend WithEvents lblGEBuildings As System.Windows.Forms.Label
    Friend WithEvents chkGEBuildings As System.Windows.Forms.CheckBox
    Friend WithEvents cmdModeChangePlay As System.Windows.Forms.Button
    Friend WithEvents txtAnnounceModeChange As System.Windows.Forms.TextBox
    Friend WithEvents chkAnnounceModeChange As System.Windows.Forms.CheckBox
    Friend WithEvents cmdWaypointPlay As System.Windows.Forms.Button
    Friend WithEvents txtAnnounceWaypoints As System.Windows.Forms.TextBox
    Friend WithEvents chkAnnounceWaypoints As System.Windows.Forms.CheckBox
    Friend WithEvents cboVoice As System.Windows.Forms.ComboBox
    Friend WithEvents lblVoice As System.Windows.Forms.Label
    Friend WithEvents lblHelp As System.Windows.Forms.Label
    Friend WithEvents lblAltitudeOffset As System.Windows.Forms.Label
    Friend WithEvents cboAltitudeOffset As System.Windows.Forms.ComboBox
    Friend WithEvents cmdRegularIntervalPlay As System.Windows.Forms.Button
    Friend WithEvents txtAnnounceRegularInterval As System.Windows.Forms.TextBox
    Friend WithEvents chkAnnounceRegularInterval As System.Windows.Forms.CheckBox
    Friend WithEvents lblSpeechInterval As System.Windows.Forms.Label
    Friend WithEvents cboSpeechInterval As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboMapSource As System.Windows.Forms.ComboBox
    Friend WithEvents lblClamptoGround As System.Windows.Forms.Label
    Friend WithEvents chkClampToGround As System.Windows.Forms.CheckBox
    Friend WithEvents cmdAlarmPlay As System.Windows.Forms.Button
    Friend WithEvents txtAnnounceAlarm As System.Windows.Forms.TextBox
    Friend WithEvents chkAnnounceLinkAlarm As System.Windows.Forms.CheckBox
    Friend WithEvents cmdWarningPlay As System.Windows.Forms.Button
    Friend WithEvents txtAnnounceWarning As System.Windows.Forms.TextBox
    Friend WithEvents chkAnnounceLinkWarning As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboAlarmTimeout As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboWarningTimeout As System.Windows.Forms.ComboBox
    Friend WithEvents grpGoogleEarthKey As System.Windows.Forms.GroupBox
    Friend WithEvents txtGoogleEarthKey As System.Windows.Forms.TextBox
    Friend WithEvents cboMaxSpeed As System.Windows.Forms.ComboBox
    Friend WithEvents lblMaxSpeed As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo2wayTimeout As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo2wayRetries As System.Windows.Forms.ComboBox
    Friend WithEvents txtAltitudeMin As System.Windows.Forms.TextBox
    Friend WithEvents lblAltitudeMinValue As System.Windows.Forms.Label
    Friend WithEvents cmdAltitudeAlarm As System.Windows.Forms.Button
    Friend WithEvents txtAltitudeAlarm As System.Windows.Forms.TextBox
    Friend WithEvents chkAnnounceAltitudeAlarm As System.Windows.Forms.CheckBox
    Friend WithEvents chkManuelMode As System.Windows.Forms.CheckBox
End Class
