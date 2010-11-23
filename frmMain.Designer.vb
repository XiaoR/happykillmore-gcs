<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.cmdCenterOnPlane = New System.Windows.Forms.Button
        Me.cmdClearMap = New System.Windows.Forms.Button
        Me.tabInstrumentView = New System.Windows.Forms.TabControl
        Me.tabInstruments = New System.Windows.Forms.TabPage
        Me._3DMesh1 = New HK_GCS._3DMesh
        Me.VerticalSpeedIndicatorInstrumentControl1 = New HK_GCS.AvionicsInstrumentControlDemo.VerticalSpeedIndicatorInstrumentControl
        Me.HeadingIndicatorInstrumentControl1 = New HK_GCS.AvionicsInstrumentControlDemo.HeadingIndicatorInstrumentControl
        Me.AttitudeIndicatorInstrumentControl1 = New HK_GCS.AvionicsInstrumentControlDemo.AttitudeIndicatorInstrumentControl
        Me.AltimeterInstrumentControl1 = New HK_GCS.AvionicsInstrumentControlDemo.AltimeterInstrumentControl
        Me.AirSpeedIndicatorInstrumentControl1 = New HK_GCS.AvionicsInstrumentControlDemo.AirSpeedIndicatorInstrumentControl
        Me.tabSerialData = New System.Windows.Forms.TabPage
        Me.grpSerialSettings = New System.Windows.Forms.GroupBox
        Me.cboWaypoint = New System.Windows.Forms.ComboBox
        Me.cboGPS = New System.Windows.Forms.ComboBox
        Me.cboAttitude = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblTranslatedData = New System.Windows.Forms.Label
        Me.lblRawData = New System.Windows.Forms.Label
        Me.lstEvents = New System.Windows.Forms.ListBox
        Me.lstInbound = New System.Windows.Forms.ListBox
        Me.tabCommandLine = New System.Windows.Forms.TabPage
        Me.cmdCommandLineSend = New System.Windows.Forms.Button
        Me.cboCommandLineCommand = New System.Windows.Forms.ComboBox
        Me.chkCommandLineAutoScroll = New System.Windows.Forms.CheckBox
        Me.cboCommandLineDelim = New System.Windows.Forms.ComboBox
        Me.lstCommandLineOutput = New System.Windows.Forms.ListBox
        Me.tabSettings = New System.Windows.Forms.TabPage
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboMapUpdateRate = New System.Windows.Forms.ComboBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.chkRollReverse = New System.Windows.Forms.CheckBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.chkPitchReverse = New System.Windows.Forms.CheckBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.cbo3DModel = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.tbarFlightWidth = New System.Windows.Forms.TrackBar
        Me.cmdFlightColor = New System.Windows.Forms.Button
        Me.chkFlightExtrude = New System.Windows.Forms.CheckBox
        Me.cboMaxSpeed = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboSpeedUnits = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDistanceUnits = New System.Windows.Forms.ComboBox
        Me.tabInstrumentLiveCamera = New System.Windows.Forms.TabPage
        Me.DirectShowControl2 = New HK_GCS.DirectShowControl.DirectShowControl
        Me.tmrPlayback = New System.Windows.Forms.Timer(Me.components)
        Me.tmrSearch = New System.Windows.Forms.Timer(Me.components)
        Me.serialPortIn = New System.IO.Ports.SerialPort(Me.components)
        Me.tabPortControl = New System.Windows.Forms.TabControl
        Me.tabPortComPort = New System.Windows.Forms.TabPage
        Me.lblBandwidth = New System.Windows.Forms.Label
        Me.lblComPortStatus = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.cmdReloadComPorts = New System.Windows.Forms.Button
        Me.cboBaudRate = New System.Windows.Forms.ComboBox
        Me.lblGPSMessage = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblGPSType = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdSearchCOM = New System.Windows.Forms.Button
        Me.cmdConnect = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.lblComPort = New System.Windows.Forms.Label
        Me.cboComPort = New System.Windows.Forms.ComboBox
        Me.tabPortDataFile = New System.Windows.Forms.TabPage
        Me.chkStepForward = New System.Windows.Forms.CheckBox
        Me.chkStepBack = New System.Windows.Forms.CheckBox
        Me.chkFastForward = New System.Windows.Forms.CheckBox
        Me.chkReverse = New System.Windows.Forms.CheckBox
        Me.chkPause = New System.Windows.Forms.CheckBox
        Me.chkPlay = New System.Windows.Forms.CheckBox
        Me.cboOutputFiles = New System.Windows.Forms.ComboBox
        Me.TrackBar1 = New System.Windows.Forms.TrackBar
        Me.cmdViewFile = New System.Windows.Forms.Button
        Me.cmdOutputFolder = New System.Windows.Forms.Button
        Me.chkRecord = New System.Windows.Forms.CheckBox
        Me.txtOutputFolder = New System.Windows.Forms.TextBox
        Me.tabPortMissions = New System.Windows.Forms.TabPage
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmdReloadMissions = New System.Windows.Forms.Button
        Me.Label26 = New System.Windows.Forms.Label
        Me.cboMission = New System.Windows.Forms.ComboBox
        Me.cmdExit = New System.Windows.Forms.Button
        Me.grpMisc = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.lblRunTime = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.lblDataPoints = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.lblTargetAlt = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.lblLongitude = New System.Windows.Forms.Label
        Me.lblLatitude = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.lblLatitudeLabel = New System.Windows.Forms.Label
        Me.lblThrottle = New System.Windows.Forms.Label
        Me.lblMode = New System.Windows.Forms.Label
        Me.lblDistance = New System.Windows.Forms.Label
        Me.lblWaypoint = New System.Windows.Forms.Label
        Me.lblHDOP = New System.Windows.Forms.Label
        Me.lblBattery = New System.Windows.Forms.Label
        Me.lblSatellites = New System.Windows.Forms.Label
        Me.lblGPSLock = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdExpandInstruments = New System.Windows.Forms.Button
        Me.tabMapView = New System.Windows.Forms.TabControl
        Me.tabViewMapView = New System.Windows.Forms.TabPage
        Me.tbarModelScale = New System.Windows.Forms.TrackBar
        Me.chkViewFirstPerson = New System.Windows.Forms.CheckBox
        Me.chkViewChaseCam = New System.Windows.Forms.CheckBox
        Me.chkViewOverhead = New System.Windows.Forms.CheckBox
        Me.chkViewNoTracking = New System.Windows.Forms.CheckBox
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.tabViewLiveCamera = New System.Windows.Forms.TabPage
        Me.DirectShowControl1 = New HK_GCS.DirectShowControl.DirectShowControl
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.tabInstrumentView.SuspendLayout()
        Me.tabInstruments.SuspendLayout()
        Me.tabSerialData.SuspendLayout()
        Me.grpSerialSettings.SuspendLayout()
        Me.tabCommandLine.SuspendLayout()
        Me.tabSettings.SuspendLayout()
        CType(Me.tbarFlightWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabInstrumentLiveCamera.SuspendLayout()
        Me.tabPortControl.SuspendLayout()
        Me.tabPortComPort.SuspendLayout()
        Me.tabPortDataFile.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPortMissions.SuspendLayout()
        Me.grpMisc.SuspendLayout()
        Me.tabMapView.SuspendLayout()
        Me.tabViewMapView.SuspendLayout()
        CType(Me.tbarModelScale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabViewLiveCamera.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCenterOnPlane
        '
        Me.cmdCenterOnPlane.Location = New System.Drawing.Point(587, 549)
        Me.cmdCenterOnPlane.Name = "cmdCenterOnPlane"
        Me.cmdCenterOnPlane.Size = New System.Drawing.Size(100, 23)
        Me.cmdCenterOnPlane.TabIndex = 14
        Me.cmdCenterOnPlane.Text = "Center on Plane"
        Me.cmdCenterOnPlane.UseVisualStyleBackColor = True
        '
        'cmdClearMap
        '
        Me.cmdClearMap.Location = New System.Drawing.Point(693, 549)
        Me.cmdClearMap.Name = "cmdClearMap"
        Me.cmdClearMap.Size = New System.Drawing.Size(110, 23)
        Me.cmdClearMap.TabIndex = 15
        Me.cmdClearMap.Text = "Clear Map"
        Me.cmdClearMap.UseVisualStyleBackColor = True
        '
        'tabInstrumentView
        '
        Me.tabInstrumentView.Controls.Add(Me.tabInstruments)
        Me.tabInstrumentView.Controls.Add(Me.tabSerialData)
        Me.tabInstrumentView.Controls.Add(Me.tabCommandLine)
        Me.tabInstrumentView.Controls.Add(Me.tabSettings)
        Me.tabInstrumentView.Controls.Add(Me.tabInstrumentLiveCamera)
        Me.tabInstrumentView.Location = New System.Drawing.Point(8, 12)
        Me.tabInstrumentView.Name = "tabInstrumentView"
        Me.tabInstrumentView.SelectedIndex = 0
        Me.tabInstrumentView.Size = New System.Drawing.Size(573, 408)
        Me.tabInstrumentView.TabIndex = 17
        '
        'tabInstruments
        '
        Me.tabInstruments.BackColor = System.Drawing.Color.Transparent
        Me.tabInstruments.Controls.Add(Me._3DMesh1)
        Me.tabInstruments.Controls.Add(Me.VerticalSpeedIndicatorInstrumentControl1)
        Me.tabInstruments.Controls.Add(Me.HeadingIndicatorInstrumentControl1)
        Me.tabInstruments.Controls.Add(Me.AttitudeIndicatorInstrumentControl1)
        Me.tabInstruments.Controls.Add(Me.AltimeterInstrumentControl1)
        Me.tabInstruments.Controls.Add(Me.AirSpeedIndicatorInstrumentControl1)
        Me.tabInstruments.Location = New System.Drawing.Point(4, 22)
        Me.tabInstruments.Name = "tabInstruments"
        Me.tabInstruments.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInstruments.Size = New System.Drawing.Size(565, 382)
        Me.tabInstruments.TabIndex = 0
        Me.tabInstruments.Text = "Instruments"
        Me.tabInstruments.UseVisualStyleBackColor = True
        '
        '_3DMesh1
        '
        Me._3DMesh1.Location = New System.Drawing.Point(378, 192)
        Me._3DMesh1.Name = "_3DMesh1"
        Me._3DMesh1.Size = New System.Drawing.Size(180, 180)
        Me._3DMesh1.TabIndex = 13
        '
        'VerticalSpeedIndicatorInstrumentControl1
        '
        Me.VerticalSpeedIndicatorInstrumentControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.VerticalSpeedIndicatorInstrumentControl1.Location = New System.Drawing.Point(192, 192)
        Me.VerticalSpeedIndicatorInstrumentControl1.Name = "VerticalSpeedIndicatorInstrumentControl1"
        Me.VerticalSpeedIndicatorInstrumentControl1.Size = New System.Drawing.Size(180, 180)
        Me.VerticalSpeedIndicatorInstrumentControl1.TabIndex = 12
        Me.VerticalSpeedIndicatorInstrumentControl1.Text = "VerticalSpeedIndicatorInstrumentControl1"
        '
        'HeadingIndicatorInstrumentControl1
        '
        Me.HeadingIndicatorInstrumentControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.HeadingIndicatorInstrumentControl1.Location = New System.Drawing.Point(6, 192)
        Me.HeadingIndicatorInstrumentControl1.Name = "HeadingIndicatorInstrumentControl1"
        Me.HeadingIndicatorInstrumentControl1.Size = New System.Drawing.Size(180, 180)
        Me.HeadingIndicatorInstrumentControl1.TabIndex = 10
        Me.HeadingIndicatorInstrumentControl1.Text = "HeadingIndicatorInstrumentControl1"
        '
        'AttitudeIndicatorInstrumentControl1
        '
        Me.AttitudeIndicatorInstrumentControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.AttitudeIndicatorInstrumentControl1.Location = New System.Drawing.Point(378, 6)
        Me.AttitudeIndicatorInstrumentControl1.Name = "AttitudeIndicatorInstrumentControl1"
        Me.AttitudeIndicatorInstrumentControl1.Size = New System.Drawing.Size(180, 180)
        Me.AttitudeIndicatorInstrumentControl1.TabIndex = 9
        Me.AttitudeIndicatorInstrumentControl1.Text = "AttitudeIndicatorInstrumentControl1"
        '
        'AltimeterInstrumentControl1
        '
        Me.AltimeterInstrumentControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.AltimeterInstrumentControl1.Location = New System.Drawing.Point(192, 6)
        Me.AltimeterInstrumentControl1.Name = "AltimeterInstrumentControl1"
        Me.AltimeterInstrumentControl1.Size = New System.Drawing.Size(180, 180)
        Me.AltimeterInstrumentControl1.TabIndex = 8
        Me.AltimeterInstrumentControl1.Text = "AltimeterInstrumentControl1"
        '
        'AirSpeedIndicatorInstrumentControl1
        '
        Me.AirSpeedIndicatorInstrumentControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.AirSpeedIndicatorInstrumentControl1.Location = New System.Drawing.Point(6, 6)
        Me.AirSpeedIndicatorInstrumentControl1.Name = "AirSpeedIndicatorInstrumentControl1"
        Me.AirSpeedIndicatorInstrumentControl1.Size = New System.Drawing.Size(180, 180)
        Me.AirSpeedIndicatorInstrumentControl1.TabIndex = 7
        Me.AirSpeedIndicatorInstrumentControl1.Text = "AirSpeedIndicatorInstrumentControl1"
        '
        'tabSerialData
        '
        Me.tabSerialData.Controls.Add(Me.grpSerialSettings)
        Me.tabSerialData.Controls.Add(Me.lblTranslatedData)
        Me.tabSerialData.Controls.Add(Me.lblRawData)
        Me.tabSerialData.Controls.Add(Me.lstEvents)
        Me.tabSerialData.Controls.Add(Me.lstInbound)
        Me.tabSerialData.Location = New System.Drawing.Point(4, 22)
        Me.tabSerialData.Name = "tabSerialData"
        Me.tabSerialData.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSerialData.Size = New System.Drawing.Size(565, 382)
        Me.tabSerialData.TabIndex = 1
        Me.tabSerialData.Text = "Serial Data"
        Me.tabSerialData.UseVisualStyleBackColor = True
        '
        'grpSerialSettings
        '
        Me.grpSerialSettings.Controls.Add(Me.cboWaypoint)
        Me.grpSerialSettings.Controls.Add(Me.cboGPS)
        Me.grpSerialSettings.Controls.Add(Me.cboAttitude)
        Me.grpSerialSettings.Controls.Add(Me.Label4)
        Me.grpSerialSettings.Controls.Add(Me.Label5)
        Me.grpSerialSettings.Controls.Add(Me.Label6)
        Me.grpSerialSettings.Location = New System.Drawing.Point(7, 294)
        Me.grpSerialSettings.Name = "grpSerialSettings"
        Me.grpSerialSettings.Size = New System.Drawing.Size(538, 67)
        Me.grpSerialSettings.TabIndex = 11
        Me.grpSerialSettings.TabStop = False
        Me.grpSerialSettings.Text = "Serial Settings"
        '
        'cboWaypoint
        '
        Me.cboWaypoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWaypoint.FormattingEnabled = True
        Me.cboWaypoint.Location = New System.Drawing.Point(169, 35)
        Me.cboWaypoint.Name = "cboWaypoint"
        Me.cboWaypoint.Size = New System.Drawing.Size(65, 21)
        Me.cboWaypoint.TabIndex = 23
        '
        'cboGPS
        '
        Me.cboGPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGPS.FormattingEnabled = True
        Me.cboGPS.Location = New System.Drawing.Point(92, 35)
        Me.cboGPS.Name = "cboGPS"
        Me.cboGPS.Size = New System.Drawing.Size(65, 21)
        Me.cboGPS.TabIndex = 22
        '
        'cboAttitude
        '
        Me.cboAttitude.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttitude.FormattingEnabled = True
        Me.cboAttitude.Location = New System.Drawing.Point(14, 35)
        Me.cboAttitude.Name = "cboAttitude"
        Me.cboAttitude.Size = New System.Drawing.Size(65, 21)
        Me.cboAttitude.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(166, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Max Waypoint"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(89, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Max GPS"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Max Attitude"
        '
        'lblTranslatedData
        '
        Me.lblTranslatedData.AutoSize = True
        Me.lblTranslatedData.Location = New System.Drawing.Point(7, 138)
        Me.lblTranslatedData.Name = "lblTranslatedData"
        Me.lblTranslatedData.Size = New System.Drawing.Size(83, 13)
        Me.lblTranslatedData.TabIndex = 10
        Me.lblTranslatedData.Text = "Translated Data"
        '
        'lblRawData
        '
        Me.lblRawData.AutoSize = True
        Me.lblRawData.Location = New System.Drawing.Point(7, 10)
        Me.lblRawData.Name = "lblRawData"
        Me.lblRawData.Size = New System.Drawing.Size(55, 13)
        Me.lblRawData.TabIndex = 9
        Me.lblRawData.Text = "Raw Data"
        '
        'lstEvents
        '
        Me.lstEvents.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstEvents.FormattingEnabled = True
        Me.lstEvents.HorizontalScrollbar = True
        Me.lstEvents.ItemHeight = 14
        Me.lstEvents.Location = New System.Drawing.Point(7, 154)
        Me.lstEvents.Name = "lstEvents"
        Me.lstEvents.Size = New System.Drawing.Size(542, 130)
        Me.lstEvents.TabIndex = 8
        '
        'lstInbound
        '
        Me.lstInbound.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstInbound.FormattingEnabled = True
        Me.lstInbound.HorizontalScrollbar = True
        Me.lstInbound.ItemHeight = 14
        Me.lstInbound.Location = New System.Drawing.Point(7, 26)
        Me.lstInbound.Name = "lstInbound"
        Me.lstInbound.Size = New System.Drawing.Size(542, 102)
        Me.lstInbound.TabIndex = 7
        '
        'tabCommandLine
        '
        Me.tabCommandLine.Controls.Add(Me.cmdCommandLineSend)
        Me.tabCommandLine.Controls.Add(Me.cboCommandLineCommand)
        Me.tabCommandLine.Controls.Add(Me.chkCommandLineAutoScroll)
        Me.tabCommandLine.Controls.Add(Me.cboCommandLineDelim)
        Me.tabCommandLine.Controls.Add(Me.lstCommandLineOutput)
        Me.tabCommandLine.Location = New System.Drawing.Point(4, 22)
        Me.tabCommandLine.Name = "tabCommandLine"
        Me.tabCommandLine.Size = New System.Drawing.Size(565, 382)
        Me.tabCommandLine.TabIndex = 3
        Me.tabCommandLine.Text = "Command Line"
        Me.tabCommandLine.UseVisualStyleBackColor = True
        '
        'cmdCommandLineSend
        '
        Me.cmdCommandLineSend.Location = New System.Drawing.Point(477, 19)
        Me.cmdCommandLineSend.Name = "cmdCommandLineSend"
        Me.cmdCommandLineSend.Size = New System.Drawing.Size(75, 23)
        Me.cmdCommandLineSend.TabIndex = 18
        Me.cmdCommandLineSend.Text = "Send"
        Me.cmdCommandLineSend.UseVisualStyleBackColor = True
        '
        'cboCommandLineCommand
        '
        Me.cboCommandLineCommand.FormattingEnabled = True
        Me.cboCommandLineCommand.Location = New System.Drawing.Point(7, 19)
        Me.cboCommandLineCommand.Name = "cboCommandLineCommand"
        Me.cboCommandLineCommand.Size = New System.Drawing.Size(460, 21)
        Me.cboCommandLineCommand.TabIndex = 17
        '
        'chkCommandLineAutoScroll
        '
        Me.chkCommandLineAutoScroll.AutoSize = True
        Me.chkCommandLineAutoScroll.Location = New System.Drawing.Point(7, 355)
        Me.chkCommandLineAutoScroll.Name = "chkCommandLineAutoScroll"
        Me.chkCommandLineAutoScroll.Size = New System.Drawing.Size(77, 17)
        Me.chkCommandLineAutoScroll.TabIndex = 16
        Me.chkCommandLineAutoScroll.Text = "Auto Scroll"
        Me.chkCommandLineAutoScroll.UseVisualStyleBackColor = True
        '
        'cboCommandLineDelim
        '
        Me.cboCommandLineDelim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCommandLineDelim.FormattingEnabled = True
        Me.cboCommandLineDelim.Location = New System.Drawing.Point(398, 351)
        Me.cboCommandLineDelim.Name = "cboCommandLineDelim"
        Me.cboCommandLineDelim.Size = New System.Drawing.Size(154, 21)
        Me.cboCommandLineDelim.TabIndex = 15
        '
        'lstCommandLineOutput
        '
        Me.lstCommandLineOutput.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCommandLineOutput.FormattingEnabled = True
        Me.lstCommandLineOutput.HorizontalScrollbar = True
        Me.lstCommandLineOutput.ItemHeight = 14
        Me.lstCommandLineOutput.Location = New System.Drawing.Point(7, 55)
        Me.lstCommandLineOutput.Name = "lstCommandLineOutput"
        Me.lstCommandLineOutput.Size = New System.Drawing.Size(536, 284)
        Me.lstCommandLineOutput.TabIndex = 11
        '
        'tabSettings
        '
        Me.tabSettings.Controls.Add(Me.Label1)
        Me.tabSettings.Controls.Add(Me.cboMapUpdateRate)
        Me.tabSettings.Controls.Add(Me.Label30)
        Me.tabSettings.Controls.Add(Me.Label29)
        Me.tabSettings.Controls.Add(Me.chkRollReverse)
        Me.tabSettings.Controls.Add(Me.Label27)
        Me.tabSettings.Controls.Add(Me.chkPitchReverse)
        Me.tabSettings.Controls.Add(Me.Label25)
        Me.tabSettings.Controls.Add(Me.Label24)
        Me.tabSettings.Controls.Add(Me.cbo3DModel)
        Me.tabSettings.Controls.Add(Me.Label21)
        Me.tabSettings.Controls.Add(Me.tbarFlightWidth)
        Me.tabSettings.Controls.Add(Me.cmdFlightColor)
        Me.tabSettings.Controls.Add(Me.chkFlightExtrude)
        Me.tabSettings.Controls.Add(Me.cboMaxSpeed)
        Me.tabSettings.Controls.Add(Me.Label8)
        Me.tabSettings.Controls.Add(Me.Label7)
        Me.tabSettings.Controls.Add(Me.cboSpeedUnits)
        Me.tabSettings.Controls.Add(Me.Label3)
        Me.tabSettings.Controls.Add(Me.cboDistanceUnits)
        Me.tabSettings.Location = New System.Drawing.Point(4, 22)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.Size = New System.Drawing.Size(565, 382)
        Me.tabSettings.TabIndex = 2
        Me.tabSettings.Text = "Settings"
        Me.tabSettings.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(183, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Extrude:"
        '
        'cboMapUpdateRate
        '
        Me.cboMapUpdateRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMapUpdateRate.FormattingEnabled = True
        Me.cboMapUpdateRate.Location = New System.Drawing.Point(112, 117)
        Me.cboMapUpdateRate.Name = "cboMapUpdateRate"
        Me.cboMapUpdateRate.Size = New System.Drawing.Size(65, 21)
        Me.cboMapUpdateRate.TabIndex = 25
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(10, 124)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(95, 13)
        Me.Label30.TabIndex = 24
        Me.Label30.Text = "Map Update Rate:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(191, 40)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(28, 13)
        Me.Label29.TabIndex = 23
        Me.Label29.Text = "Roll:"
        '
        'chkRollReverse
        '
        Me.chkRollReverse.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkRollReverse.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkRollReverse.Location = New System.Drawing.Point(225, 34)
        Me.chkRollReverse.Name = "chkRollReverse"
        Me.chkRollReverse.Size = New System.Drawing.Size(69, 24)
        Me.chkRollReverse.TabIndex = 22
        Me.chkRollReverse.Text = "Normal"
        Me.chkRollReverse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkRollReverse.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(191, 12)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 21
        Me.Label27.Text = "Pitch:"
        '
        'chkPitchReverse
        '
        Me.chkPitchReverse.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkPitchReverse.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkPitchReverse.Location = New System.Drawing.Point(224, 8)
        Me.chkPitchReverse.Name = "chkPitchReverse"
        Me.chkPitchReverse.Size = New System.Drawing.Size(70, 24)
        Me.chkPitchReverse.TabIndex = 20
        Me.chkPitchReverse.Text = "Normal"
        Me.chkPitchReverse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkPitchReverse.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(10, 179)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(84, 13)
        Me.Label25.TabIndex = 19
        Me.Label25.Text = "Path Thickness:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(10, 149)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(87, 13)
        Me.Label24.TabIndex = 18
        Me.Label24.Text = "Flight Path Color:"
        '
        'cbo3DModel
        '
        Me.cbo3DModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo3DModel.FormattingEnabled = True
        Me.cbo3DModel.Location = New System.Drawing.Point(112, 90)
        Me.cbo3DModel.Name = "cbo3DModel"
        Me.cbo3DModel.Size = New System.Drawing.Size(90, 21)
        Me.cbo3DModel.TabIndex = 15
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(10, 96)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 13)
        Me.Label21.TabIndex = 14
        Me.Label21.Text = "3D Model:"
        '
        'tbarFlightWidth
        '
        Me.tbarFlightWidth.AutoSize = False
        Me.tbarFlightWidth.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbarFlightWidth.LargeChange = 1
        Me.tbarFlightWidth.Location = New System.Drawing.Point(112, 173)
        Me.tbarFlightWidth.Minimum = 1
        Me.tbarFlightWidth.Name = "tbarFlightWidth"
        Me.tbarFlightWidth.Size = New System.Drawing.Size(90, 30)
        Me.tbarFlightWidth.TabIndex = 13
        Me.tbarFlightWidth.TickFrequency = 26
        Me.tbarFlightWidth.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarFlightWidth.Value = 1
        '
        'cmdFlightColor
        '
        Me.cmdFlightColor.Location = New System.Drawing.Point(112, 144)
        Me.cmdFlightColor.Name = "cmdFlightColor"
        Me.cmdFlightColor.Size = New System.Drawing.Size(90, 23)
        Me.cmdFlightColor.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.cmdFlightColor, "Select Color")
        Me.cmdFlightColor.UseVisualStyleBackColor = False
        '
        'chkFlightExtrude
        '
        Me.chkFlightExtrude.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkFlightExtrude.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkFlightExtrude.Location = New System.Drawing.Point(235, 64)
        Me.chkFlightExtrude.Name = "chkFlightExtrude"
        Me.chkFlightExtrude.Size = New System.Drawing.Size(59, 21)
        Me.chkFlightExtrude.TabIndex = 8
        Me.chkFlightExtrude.Text = "No"
        Me.chkFlightExtrude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkFlightExtrude.UseVisualStyleBackColor = True
        '
        'cboMaxSpeed
        '
        Me.cboMaxSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaxSpeed.FormattingEnabled = True
        Me.cboMaxSpeed.Location = New System.Drawing.Point(112, 63)
        Me.cboMaxSpeed.Name = "cboMaxSpeed"
        Me.cboMaxSpeed.Size = New System.Drawing.Size(65, 21)
        Me.cboMaxSpeed.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Max Speed:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Speed Units:"
        '
        'cboSpeedUnits
        '
        Me.cboSpeedUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSpeedUnits.FormattingEnabled = True
        Me.cboSpeedUnits.Location = New System.Drawing.Point(112, 36)
        Me.cboSpeedUnits.Name = "cboSpeedUnits"
        Me.cboSpeedUnits.Size = New System.Drawing.Size(65, 21)
        Me.cboSpeedUnits.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Units of Measure:"
        '
        'cboDistanceUnits
        '
        Me.cboDistanceUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistanceUnits.FormattingEnabled = True
        Me.cboDistanceUnits.Location = New System.Drawing.Point(112, 9)
        Me.cboDistanceUnits.Name = "cboDistanceUnits"
        Me.cboDistanceUnits.Size = New System.Drawing.Size(65, 21)
        Me.cboDistanceUnits.TabIndex = 0
        '
        'tabInstrumentLiveCamera
        '
        Me.tabInstrumentLiveCamera.Controls.Add(Me.DirectShowControl2)
        Me.tabInstrumentLiveCamera.Location = New System.Drawing.Point(4, 22)
        Me.tabInstrumentLiveCamera.Name = "tabInstrumentLiveCamera"
        Me.tabInstrumentLiveCamera.Size = New System.Drawing.Size(565, 382)
        Me.tabInstrumentLiveCamera.TabIndex = 4
        Me.tabInstrumentLiveCamera.Text = "Live Camera"
        Me.tabInstrumentLiveCamera.UseVisualStyleBackColor = True
        '
        'DirectShowControl2
        '
        Me.DirectShowControl2.Location = New System.Drawing.Point(71, 9)
        Me.DirectShowControl2.Name = "DirectShowControl2"
        Me.DirectShowControl2.Size = New System.Drawing.Size(400, 360)
        Me.DirectShowControl2.TabIndex = 1
        '
        'tmrPlayback
        '
        Me.tmrPlayback.Interval = 1000
        '
        'tmrSearch
        '
        '
        'serialPortIn
        '
        Me.serialPortIn.DtrEnable = True
        '
        'tabPortControl
        '
        Me.tabPortControl.Controls.Add(Me.tabPortComPort)
        Me.tabPortControl.Controls.Add(Me.tabPortDataFile)
        Me.tabPortControl.Controls.Add(Me.tabPortMissions)
        Me.tabPortControl.Location = New System.Drawing.Point(8, 426)
        Me.tabPortControl.Name = "tabPortControl"
        Me.tabPortControl.SelectedIndex = 0
        Me.tabPortControl.Size = New System.Drawing.Size(272, 179)
        Me.tabPortControl.TabIndex = 19
        '
        'tabPortComPort
        '
        Me.tabPortComPort.Controls.Add(Me.lblBandwidth)
        Me.tabPortComPort.Controls.Add(Me.lblComPortStatus)
        Me.tabPortComPort.Controls.Add(Me.Label31)
        Me.tabPortComPort.Controls.Add(Me.cmdReloadComPorts)
        Me.tabPortComPort.Controls.Add(Me.cboBaudRate)
        Me.tabPortComPort.Controls.Add(Me.lblGPSMessage)
        Me.tabPortComPort.Controls.Add(Me.Label12)
        Me.tabPortComPort.Controls.Add(Me.lblGPSType)
        Me.tabPortComPort.Controls.Add(Me.Label11)
        Me.tabPortComPort.Controls.Add(Me.Label9)
        Me.tabPortComPort.Controls.Add(Me.cmdSearchCOM)
        Me.tabPortComPort.Controls.Add(Me.cmdConnect)
        Me.tabPortComPort.Controls.Add(Me.cmdSearch)
        Me.tabPortComPort.Controls.Add(Me.lblComPort)
        Me.tabPortComPort.Controls.Add(Me.cboComPort)
        Me.tabPortComPort.Location = New System.Drawing.Point(4, 22)
        Me.tabPortComPort.Name = "tabPortComPort"
        Me.tabPortComPort.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPortComPort.Size = New System.Drawing.Size(264, 153)
        Me.tabPortComPort.TabIndex = 0
        Me.tabPortComPort.Text = "COM Port Control"
        Me.tabPortComPort.UseVisualStyleBackColor = True
        '
        'lblBandwidth
        '
        Me.lblBandwidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBandwidth.Location = New System.Drawing.Point(174, 99)
        Me.lblBandwidth.Name = "lblBandwidth"
        Me.lblBandwidth.Size = New System.Drawing.Size(81, 12)
        Me.lblBandwidth.TabIndex = 29
        Me.lblBandwidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblComPortStatus
        '
        Me.lblComPortStatus.Location = New System.Drawing.Point(75, 121)
        Me.lblComPortStatus.Name = "lblComPortStatus"
        Me.lblComPortStatus.Size = New System.Drawing.Size(180, 29)
        Me.lblComPortStatus.TabIndex = 28
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(11, 121)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(40, 13)
        Me.Label31.TabIndex = 27
        Me.Label31.Text = "Status:"
        '
        'cmdReloadComPorts
        '
        Me.cmdReloadComPorts.Location = New System.Drawing.Point(158, 14)
        Me.cmdReloadComPorts.Name = "cmdReloadComPorts"
        Me.cmdReloadComPorts.Size = New System.Drawing.Size(16, 23)
        Me.cmdReloadComPorts.TabIndex = 26
        Me.cmdReloadComPorts.Text = "<"
        Me.ToolTip1.SetToolTip(Me.cmdReloadComPorts, "Reload COM Port List")
        Me.cmdReloadComPorts.UseVisualStyleBackColor = True
        '
        'cboBaudRate
        '
        Me.cboBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBaudRate.FormattingEnabled = True
        Me.cboBaudRate.Location = New System.Drawing.Point(75, 43)
        Me.cboBaudRate.Name = "cboBaudRate"
        Me.cboBaudRate.Size = New System.Drawing.Size(80, 21)
        Me.cboBaudRate.TabIndex = 25
        '
        'lblGPSMessage
        '
        Me.lblGPSMessage.AutoSize = True
        Me.lblGPSMessage.Location = New System.Drawing.Point(75, 98)
        Me.lblGPSMessage.Name = "lblGPSMessage"
        Me.lblGPSMessage.Size = New System.Drawing.Size(0, 13)
        Me.lblGPSMessage.TabIndex = 24
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 98)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "GPS Msg:"
        '
        'lblGPSType
        '
        Me.lblGPSType.AutoSize = True
        Me.lblGPSType.Location = New System.Drawing.Point(75, 72)
        Me.lblGPSType.Name = "lblGPSType"
        Me.lblGPSType.Size = New System.Drawing.Size(0, 13)
        Me.lblGPSType.TabIndex = 22
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "GPS Type:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Baud Rate:"
        '
        'cmdSearchCOM
        '
        Me.cmdSearchCOM.Location = New System.Drawing.Point(177, 14)
        Me.cmdSearchCOM.Name = "cmdSearchCOM"
        Me.cmdSearchCOM.Size = New System.Drawing.Size(78, 23)
        Me.cmdSearchCOM.TabIndex = 18
        Me.cmdSearchCOM.Text = "Search COM"
        Me.cmdSearchCOM.UseVisualStyleBackColor = True
        '
        'cmdConnect
        '
        Me.cmdConnect.Location = New System.Drawing.Point(177, 71)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(78, 23)
        Me.cmdConnect.TabIndex = 17
        Me.cmdConnect.Text = "Connect"
        Me.cmdConnect.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(177, 43)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(78, 23)
        Me.cmdSearch.TabIndex = 16
        Me.cmdSearch.Text = "Search Baud"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'lblComPort
        '
        Me.lblComPort.AutoSize = True
        Me.lblComPort.Location = New System.Drawing.Point(11, 17)
        Me.lblComPort.Name = "lblComPort"
        Me.lblComPort.Size = New System.Drawing.Size(56, 13)
        Me.lblComPort.TabIndex = 15
        Me.lblComPort.Text = "COM Port:"
        '
        'cboComPort
        '
        Me.cboComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboComPort.FormattingEnabled = True
        Me.cboComPort.Location = New System.Drawing.Point(75, 14)
        Me.cboComPort.Name = "cboComPort"
        Me.cboComPort.Size = New System.Drawing.Size(80, 21)
        Me.cboComPort.Sorted = True
        Me.cboComPort.TabIndex = 14
        '
        'tabPortDataFile
        '
        Me.tabPortDataFile.Controls.Add(Me.chkStepForward)
        Me.tabPortDataFile.Controls.Add(Me.chkStepBack)
        Me.tabPortDataFile.Controls.Add(Me.chkFastForward)
        Me.tabPortDataFile.Controls.Add(Me.chkReverse)
        Me.tabPortDataFile.Controls.Add(Me.chkPause)
        Me.tabPortDataFile.Controls.Add(Me.chkPlay)
        Me.tabPortDataFile.Controls.Add(Me.cboOutputFiles)
        Me.tabPortDataFile.Controls.Add(Me.TrackBar1)
        Me.tabPortDataFile.Controls.Add(Me.cmdViewFile)
        Me.tabPortDataFile.Controls.Add(Me.cmdOutputFolder)
        Me.tabPortDataFile.Controls.Add(Me.chkRecord)
        Me.tabPortDataFile.Controls.Add(Me.txtOutputFolder)
        Me.tabPortDataFile.Location = New System.Drawing.Point(4, 22)
        Me.tabPortDataFile.Name = "tabPortDataFile"
        Me.tabPortDataFile.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPortDataFile.Size = New System.Drawing.Size(264, 153)
        Me.tabPortDataFile.TabIndex = 1
        Me.tabPortDataFile.Text = "Data File"
        Me.tabPortDataFile.UseVisualStyleBackColor = True
        '
        'chkStepForward
        '
        Me.chkStepForward.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkStepForward.AutoSize = True
        Me.chkStepForward.Image = CType(resources.GetObject("chkStepForward.Image"), System.Drawing.Image)
        Me.chkStepForward.Location = New System.Drawing.Point(217, 39)
        Me.chkStepForward.Name = "chkStepForward"
        Me.chkStepForward.Size = New System.Drawing.Size(26, 26)
        Me.chkStepForward.TabIndex = 21
        Me.ToolTip1.SetToolTip(Me.chkStepForward, "Step Forward")
        Me.chkStepForward.UseVisualStyleBackColor = True
        '
        'chkStepBack
        '
        Me.chkStepBack.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkStepBack.AutoSize = True
        Me.chkStepBack.Image = CType(resources.GetObject("chkStepBack.Image"), System.Drawing.Image)
        Me.chkStepBack.Location = New System.Drawing.Point(190, 39)
        Me.chkStepBack.Name = "chkStepBack"
        Me.chkStepBack.Size = New System.Drawing.Size(26, 26)
        Me.chkStepBack.TabIndex = 20
        Me.ToolTip1.SetToolTip(Me.chkStepBack, "Step Back")
        Me.chkStepBack.UseVisualStyleBackColor = True
        '
        'chkFastForward
        '
        Me.chkFastForward.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkFastForward.AutoSize = True
        Me.chkFastForward.Enabled = False
        Me.chkFastForward.Image = CType(resources.GetObject("chkFastForward.Image"), System.Drawing.Image)
        Me.chkFastForward.Location = New System.Drawing.Point(158, 39)
        Me.chkFastForward.Name = "chkFastForward"
        Me.chkFastForward.Size = New System.Drawing.Size(26, 26)
        Me.chkFastForward.TabIndex = 19
        Me.chkFastForward.UseVisualStyleBackColor = True
        '
        'chkReverse
        '
        Me.chkReverse.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkReverse.AutoSize = True
        Me.chkReverse.Enabled = False
        Me.chkReverse.Image = CType(resources.GetObject("chkReverse.Image"), System.Drawing.Image)
        Me.chkReverse.Location = New System.Drawing.Point(131, 39)
        Me.chkReverse.Name = "chkReverse"
        Me.chkReverse.Size = New System.Drawing.Size(26, 26)
        Me.chkReverse.TabIndex = 18
        Me.chkReverse.UseVisualStyleBackColor = True
        '
        'chkPause
        '
        Me.chkPause.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkPause.AutoSize = True
        Me.chkPause.Image = CType(resources.GetObject("chkPause.Image"), System.Drawing.Image)
        Me.chkPause.Location = New System.Drawing.Point(83, 39)
        Me.chkPause.Name = "chkPause"
        Me.chkPause.Size = New System.Drawing.Size(26, 26)
        Me.chkPause.TabIndex = 17
        Me.ToolTip1.SetToolTip(Me.chkPause, "Pause")
        Me.chkPause.UseVisualStyleBackColor = True
        '
        'chkPlay
        '
        Me.chkPlay.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkPlay.AutoSize = True
        Me.chkPlay.Image = CType(resources.GetObject("chkPlay.Image"), System.Drawing.Image)
        Me.chkPlay.Location = New System.Drawing.Point(56, 39)
        Me.chkPlay.Name = "chkPlay"
        Me.chkPlay.Size = New System.Drawing.Size(26, 26)
        Me.chkPlay.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.chkPlay, "Play")
        Me.chkPlay.UseVisualStyleBackColor = True
        '
        'cboOutputFiles
        '
        Me.cboOutputFiles.FormattingEnabled = True
        Me.cboOutputFiles.Location = New System.Drawing.Point(17, 12)
        Me.cboOutputFiles.Name = "cboOutputFiles"
        Me.cboOutputFiles.Size = New System.Drawing.Size(137, 21)
        Me.cboOutputFiles.TabIndex = 13
        '
        'TrackBar1
        '
        Me.TrackBar1.BackColor = System.Drawing.Color.White
        Me.TrackBar1.Enabled = False
        Me.TrackBar1.Location = New System.Drawing.Point(12, 68)
        Me.TrackBar1.Maximum = 9
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(231, 45)
        Me.TrackBar1.TabIndex = 12
        Me.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'cmdViewFile
        '
        Me.cmdViewFile.Location = New System.Drawing.Point(160, 10)
        Me.cmdViewFile.Name = "cmdViewFile"
        Me.cmdViewFile.Size = New System.Drawing.Size(83, 23)
        Me.cmdViewFile.TabIndex = 11
        Me.cmdViewFile.Text = "View Data File"
        Me.cmdViewFile.UseVisualStyleBackColor = True
        '
        'cmdOutputFolder
        '
        Me.cmdOutputFolder.Location = New System.Drawing.Point(223, 116)
        Me.cmdOutputFolder.Name = "cmdOutputFolder"
        Me.cmdOutputFolder.Size = New System.Drawing.Size(23, 23)
        Me.cmdOutputFolder.TabIndex = 9
        Me.cmdOutputFolder.Text = "..."
        Me.cmdOutputFolder.UseVisualStyleBackColor = True
        '
        'chkRecord
        '
        Me.chkRecord.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkRecord.AutoSize = True
        Me.chkRecord.Image = CType(resources.GetObject("chkRecord.Image"), System.Drawing.Image)
        Me.chkRecord.Location = New System.Drawing.Point(17, 39)
        Me.chkRecord.Name = "chkRecord"
        Me.chkRecord.Size = New System.Drawing.Size(26, 26)
        Me.chkRecord.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.chkRecord, "Record")
        Me.chkRecord.UseVisualStyleBackColor = True
        '
        'txtOutputFolder
        '
        Me.txtOutputFolder.Location = New System.Drawing.Point(12, 119)
        Me.txtOutputFolder.Name = "txtOutputFolder"
        Me.txtOutputFolder.Size = New System.Drawing.Size(205, 20)
        Me.txtOutputFolder.TabIndex = 8
        '
        'tabPortMissions
        '
        Me.tabPortMissions.Controls.Add(Me.Button1)
        Me.tabPortMissions.Controls.Add(Me.cmdReloadMissions)
        Me.tabPortMissions.Controls.Add(Me.Label26)
        Me.tabPortMissions.Controls.Add(Me.cboMission)
        Me.tabPortMissions.Location = New System.Drawing.Point(4, 22)
        Me.tabPortMissions.Name = "tabPortMissions"
        Me.tabPortMissions.Size = New System.Drawing.Size(264, 153)
        Me.tabPortMissions.TabIndex = 2
        Me.tabPortMissions.Text = "Missions"
        Me.tabPortMissions.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(211, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 23)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "R"
        Me.ToolTip1.SetToolTip(Me.Button1, "Reload Mission")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdReloadMissions
        '
        Me.cmdReloadMissions.Location = New System.Drawing.Point(233, 14)
        Me.cmdReloadMissions.Name = "cmdReloadMissions"
        Me.cmdReloadMissions.Size = New System.Drawing.Size(20, 23)
        Me.cmdReloadMissions.TabIndex = 18
        Me.cmdReloadMissions.Text = "<"
        Me.ToolTip1.SetToolTip(Me.cmdReloadMissions, "Reload Mission List")
        Me.cmdReloadMissions.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(15, 17)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(45, 13)
        Me.Label26.TabIndex = 17
        Me.Label26.Text = "Mission:"
        '
        'cboMission
        '
        Me.cboMission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMission.FormattingEnabled = True
        Me.cboMission.Location = New System.Drawing.Point(66, 14)
        Me.cboMission.Name = "cboMission"
        Me.cboMission.Size = New System.Drawing.Size(141, 21)
        Me.cboMission.Sorted = True
        Me.cboMission.TabIndex = 16
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(978, 549)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(110, 23)
        Me.cmdExit.TabIndex = 20
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'grpMisc
        '
        Me.grpMisc.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.grpMisc.Controls.Add(Me.Button2)
        Me.grpMisc.Controls.Add(Me.lblRunTime)
        Me.grpMisc.Controls.Add(Me.Label33)
        Me.grpMisc.Controls.Add(Me.lblDataPoints)
        Me.grpMisc.Controls.Add(Me.Label32)
        Me.grpMisc.Controls.Add(Me.lblTargetAlt)
        Me.grpMisc.Controls.Add(Me.Label28)
        Me.grpMisc.Controls.Add(Me.lblLongitude)
        Me.grpMisc.Controls.Add(Me.lblLatitude)
        Me.grpMisc.Controls.Add(Me.Label22)
        Me.grpMisc.Controls.Add(Me.lblLatitudeLabel)
        Me.grpMisc.Controls.Add(Me.lblThrottle)
        Me.grpMisc.Controls.Add(Me.lblMode)
        Me.grpMisc.Controls.Add(Me.lblDistance)
        Me.grpMisc.Controls.Add(Me.lblWaypoint)
        Me.grpMisc.Controls.Add(Me.lblHDOP)
        Me.grpMisc.Controls.Add(Me.lblBattery)
        Me.grpMisc.Controls.Add(Me.lblSatellites)
        Me.grpMisc.Controls.Add(Me.lblGPSLock)
        Me.grpMisc.Controls.Add(Me.Label19)
        Me.grpMisc.Controls.Add(Me.Label18)
        Me.grpMisc.Controls.Add(Me.Label17)
        Me.grpMisc.Controls.Add(Me.Label16)
        Me.grpMisc.Controls.Add(Me.Label15)
        Me.grpMisc.Controls.Add(Me.Label14)
        Me.grpMisc.Controls.Add(Me.Label13)
        Me.grpMisc.Controls.Add(Me.Label10)
        Me.grpMisc.Location = New System.Drawing.Point(282, 438)
        Me.grpMisc.Name = "grpMisc"
        Me.grpMisc.Size = New System.Drawing.Size(299, 167)
        Me.grpMisc.TabIndex = 21
        Me.grpMisc.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(268, 141)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(26, 23)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "<"
        Me.ToolTip1.SetToolTip(Me.Button2, "Reset Run Time")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblRunTime
        '
        Me.lblRunTime.AutoSize = True
        Me.lblRunTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRunTime.Location = New System.Drawing.Point(196, 125)
        Me.lblRunTime.Name = "lblRunTime"
        Me.lblRunTime.Size = New System.Drawing.Size(30, 13)
        Me.lblRunTime.TabIndex = 25
        Me.lblRunTime.Text = "N/A"
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(136, 125)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(59, 13)
        Me.Label33.TabIndex = 24
        Me.Label33.Text = "Run Time:"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDataPoints
        '
        Me.lblDataPoints.AutoSize = True
        Me.lblDataPoints.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataPoints.Location = New System.Drawing.Point(196, 147)
        Me.lblDataPoints.Name = "lblDataPoints"
        Me.lblDataPoints.Size = New System.Drawing.Size(30, 13)
        Me.lblDataPoints.TabIndex = 23
        Me.lblDataPoints.Text = "N/A"
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(128, 147)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(67, 13)
        Me.Label32.TabIndex = 22
        Me.Label32.Text = "Data Points:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTargetAlt
        '
        Me.lblTargetAlt.AutoSize = True
        Me.lblTargetAlt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTargetAlt.Location = New System.Drawing.Point(63, 147)
        Me.lblTargetAlt.Name = "lblTargetAlt"
        Me.lblTargetAlt.Size = New System.Drawing.Size(30, 13)
        Me.lblTargetAlt.TabIndex = 21
        Me.lblTargetAlt.Text = "N/A"
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(6, 147)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(59, 13)
        Me.Label28.TabIndex = 20
        Me.Label28.Text = "Target Alt:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLongitude
        '
        Me.lblLongitude.AutoSize = True
        Me.lblLongitude.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLongitude.Location = New System.Drawing.Point(196, 78)
        Me.lblLongitude.Name = "lblLongitude"
        Me.lblLongitude.Size = New System.Drawing.Size(30, 13)
        Me.lblLongitude.TabIndex = 19
        Me.lblLongitude.Text = "N/A"
        '
        'lblLatitude
        '
        Me.lblLatitude.AutoSize = True
        Me.lblLatitude.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLatitude.Location = New System.Drawing.Point(196, 58)
        Me.lblLatitude.Name = "lblLatitude"
        Me.lblLatitude.Size = New System.Drawing.Size(30, 13)
        Me.lblLatitude.TabIndex = 18
        Me.lblLatitude.Text = "N/A"
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(136, 78)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(59, 13)
        Me.Label22.TabIndex = 17
        Me.Label22.Text = "Longitude:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLatitudeLabel
        '
        Me.lblLatitudeLabel.Location = New System.Drawing.Point(136, 58)
        Me.lblLatitudeLabel.Name = "lblLatitudeLabel"
        Me.lblLatitudeLabel.Size = New System.Drawing.Size(59, 13)
        Me.lblLatitudeLabel.TabIndex = 16
        Me.lblLatitudeLabel.Text = "Latitude:"
        Me.lblLatitudeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblThrottle
        '
        Me.lblThrottle.AutoSize = True
        Me.lblThrottle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThrottle.Location = New System.Drawing.Point(63, 80)
        Me.lblThrottle.Name = "lblThrottle"
        Me.lblThrottle.Size = New System.Drawing.Size(30, 13)
        Me.lblThrottle.TabIndex = 15
        Me.lblThrottle.Text = "N/A"
        '
        'lblMode
        '
        Me.lblMode.AutoSize = True
        Me.lblMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMode.Location = New System.Drawing.Point(63, 58)
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(30, 13)
        Me.lblMode.TabIndex = 14
        Me.lblMode.Text = "N/A"
        '
        'lblDistance
        '
        Me.lblDistance.AutoSize = True
        Me.lblDistance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDistance.Location = New System.Drawing.Point(63, 125)
        Me.lblDistance.Name = "lblDistance"
        Me.lblDistance.Size = New System.Drawing.Size(30, 13)
        Me.lblDistance.TabIndex = 13
        Me.lblDistance.Text = "N/A"
        '
        'lblWaypoint
        '
        Me.lblWaypoint.AutoSize = True
        Me.lblWaypoint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWaypoint.Location = New System.Drawing.Point(63, 103)
        Me.lblWaypoint.Name = "lblWaypoint"
        Me.lblWaypoint.Size = New System.Drawing.Size(30, 13)
        Me.lblWaypoint.TabIndex = 12
        Me.lblWaypoint.Text = "N/A"
        '
        'lblHDOP
        '
        Me.lblHDOP.AutoSize = True
        Me.lblHDOP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHDOP.Location = New System.Drawing.Point(196, 35)
        Me.lblHDOP.Name = "lblHDOP"
        Me.lblHDOP.Size = New System.Drawing.Size(30, 13)
        Me.lblHDOP.TabIndex = 11
        Me.lblHDOP.Text = "N/A"
        '
        'lblBattery
        '
        Me.lblBattery.AutoSize = True
        Me.lblBattery.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBattery.Location = New System.Drawing.Point(195, 14)
        Me.lblBattery.Name = "lblBattery"
        Me.lblBattery.Size = New System.Drawing.Size(30, 13)
        Me.lblBattery.TabIndex = 10
        Me.lblBattery.Text = "N/A"
        '
        'lblSatellites
        '
        Me.lblSatellites.AutoSize = True
        Me.lblSatellites.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSatellites.Location = New System.Drawing.Point(63, 36)
        Me.lblSatellites.Name = "lblSatellites"
        Me.lblSatellites.Size = New System.Drawing.Size(30, 13)
        Me.lblSatellites.TabIndex = 9
        Me.lblSatellites.Text = "N/A"
        '
        'lblGPSLock
        '
        Me.lblGPSLock.AutoSize = True
        Me.lblGPSLock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGPSLock.Location = New System.Drawing.Point(63, 14)
        Me.lblGPSLock.Name = "lblGPSLock"
        Me.lblGPSLock.Size = New System.Drawing.Size(30, 13)
        Me.lblGPSLock.TabIndex = 8
        Me.lblGPSLock.Text = "N/A"
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(6, 80)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(59, 13)
        Me.Label19.TabIndex = 7
        Me.Label19.Text = "Throttle:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(6, 58)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 13)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Mode:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(6, 125)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 13)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Distance:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(6, 103)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 13)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Waypoint:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(136, 36)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 13)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "HDOP:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(136, 14)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Battery:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(6, 36)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Satellites:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(6, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "GPS Lock:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdExpandInstruments
        '
        Me.cmdExpandInstruments.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExpandInstruments.Location = New System.Drawing.Point(6, 402)
        Me.cmdExpandInstruments.Name = "cmdExpandInstruments"
        Me.cmdExpandInstruments.Size = New System.Drawing.Size(24, 21)
        Me.cmdExpandInstruments.TabIndex = 31
        Me.cmdExpandInstruments.Text = ">>"
        Me.ToolTip1.SetToolTip(Me.cmdExpandInstruments, "Expand")
        Me.cmdExpandInstruments.UseVisualStyleBackColor = True
        '
        'tabMapView
        '
        Me.tabMapView.Controls.Add(Me.tabViewMapView)
        Me.tabMapView.Controls.Add(Me.tabViewLiveCamera)
        Me.tabMapView.Location = New System.Drawing.Point(587, 12)
        Me.tabMapView.Name = "tabMapView"
        Me.tabMapView.SelectedIndex = 0
        Me.tabMapView.Size = New System.Drawing.Size(501, 530)
        Me.tabMapView.TabIndex = 22
        '
        'tabViewMapView
        '
        Me.tabViewMapView.Controls.Add(Me.tbarModelScale)
        Me.tabViewMapView.Controls.Add(Me.chkViewFirstPerson)
        Me.tabViewMapView.Controls.Add(Me.chkViewChaseCam)
        Me.tabViewMapView.Controls.Add(Me.chkViewOverhead)
        Me.tabViewMapView.Controls.Add(Me.chkViewNoTracking)
        Me.tabViewMapView.Controls.Add(Me.WebBrowser1)
        Me.tabViewMapView.Location = New System.Drawing.Point(4, 22)
        Me.tabViewMapView.Name = "tabViewMapView"
        Me.tabViewMapView.Padding = New System.Windows.Forms.Padding(3)
        Me.tabViewMapView.Size = New System.Drawing.Size(493, 504)
        Me.tabViewMapView.TabIndex = 0
        Me.tabViewMapView.Text = "Map View"
        Me.tabViewMapView.UseVisualStyleBackColor = True
        '
        'tbarModelScale
        '
        Me.tbarModelScale.AutoSize = False
        Me.tbarModelScale.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbarModelScale.Location = New System.Drawing.Point(326, 472)
        Me.tbarModelScale.Maximum = 50
        Me.tbarModelScale.Minimum = 1
        Me.tbarModelScale.Name = "tbarModelScale"
        Me.tbarModelScale.Size = New System.Drawing.Size(104, 26)
        Me.tbarModelScale.TabIndex = 25
        Me.tbarModelScale.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarModelScale.Value = 10
        '
        'chkViewFirstPerson
        '
        Me.chkViewFirstPerson.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkViewFirstPerson.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkViewFirstPerson.Location = New System.Drawing.Point(246, 471)
        Me.chkViewFirstPerson.Name = "chkViewFirstPerson"
        Me.chkViewFirstPerson.Size = New System.Drawing.Size(74, 24)
        Me.chkViewFirstPerson.TabIndex = 24
        Me.chkViewFirstPerson.Text = "First Person"
        Me.chkViewFirstPerson.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkViewFirstPerson.UseVisualStyleBackColor = True
        '
        'chkViewChaseCam
        '
        Me.chkViewChaseCam.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkViewChaseCam.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkViewChaseCam.Location = New System.Drawing.Point(166, 471)
        Me.chkViewChaseCam.Name = "chkViewChaseCam"
        Me.chkViewChaseCam.Size = New System.Drawing.Size(74, 24)
        Me.chkViewChaseCam.TabIndex = 23
        Me.chkViewChaseCam.Text = "Chase Cam"
        Me.chkViewChaseCam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkViewChaseCam.UseVisualStyleBackColor = True
        '
        'chkViewOverhead
        '
        Me.chkViewOverhead.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkViewOverhead.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkViewOverhead.Location = New System.Drawing.Point(86, 471)
        Me.chkViewOverhead.Name = "chkViewOverhead"
        Me.chkViewOverhead.Size = New System.Drawing.Size(74, 24)
        Me.chkViewOverhead.TabIndex = 22
        Me.chkViewOverhead.Text = "Overhead"
        Me.chkViewOverhead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkViewOverhead.UseVisualStyleBackColor = True
        '
        'chkViewNoTracking
        '
        Me.chkViewNoTracking.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkViewNoTracking.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkViewNoTracking.Checked = True
        Me.chkViewNoTracking.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkViewNoTracking.Location = New System.Drawing.Point(6, 471)
        Me.chkViewNoTracking.Name = "chkViewNoTracking"
        Me.chkViewNoTracking.Size = New System.Drawing.Size(74, 24)
        Me.chkViewNoTracking.TabIndex = 21
        Me.chkViewNoTracking.Text = "No Tracking"
        Me.chkViewNoTracking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkViewNoTracking.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(6, 9)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScrollBarsEnabled = False
        Me.WebBrowser1.Size = New System.Drawing.Size(471, 471)
        Me.WebBrowser1.TabIndex = 12
        '
        'tabViewLiveCamera
        '
        Me.tabViewLiveCamera.Controls.Add(Me.DirectShowControl1)
        Me.tabViewLiveCamera.Location = New System.Drawing.Point(4, 22)
        Me.tabViewLiveCamera.Name = "tabViewLiveCamera"
        Me.tabViewLiveCamera.Padding = New System.Windows.Forms.Padding(3)
        Me.tabViewLiveCamera.Size = New System.Drawing.Size(493, 504)
        Me.tabViewLiveCamera.TabIndex = 1
        Me.tabViewLiveCamera.Text = "Live Camera"
        Me.tabViewLiveCamera.UseVisualStyleBackColor = True
        '
        'DirectShowControl1
        '
        Me.DirectShowControl1.Location = New System.Drawing.Point(7, 7)
        Me.DirectShowControl1.Name = "DirectShowControl1"
        Me.DirectShowControl1.Size = New System.Drawing.Size(540, 486)
        Me.DirectShowControl1.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1095, 615)
        Me.Controls.Add(Me.cmdExpandInstruments)
        Me.Controls.Add(Me.tabMapView)
        Me.Controls.Add(Me.grpMisc)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.tabPortControl)
        Me.Controls.Add(Me.tabInstrumentView)
        Me.Controls.Add(Me.cmdClearMap)
        Me.Controls.Add(Me.cmdCenterOnPlane)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 400)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "HappyKillmore's Ground Control Station"
        Me.tabInstrumentView.ResumeLayout(False)
        Me.tabInstruments.ResumeLayout(False)
        Me.tabSerialData.ResumeLayout(False)
        Me.tabSerialData.PerformLayout()
        Me.grpSerialSettings.ResumeLayout(False)
        Me.grpSerialSettings.PerformLayout()
        Me.tabCommandLine.ResumeLayout(False)
        Me.tabCommandLine.PerformLayout()
        Me.tabSettings.ResumeLayout(False)
        Me.tabSettings.PerformLayout()
        CType(Me.tbarFlightWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabInstrumentLiveCamera.ResumeLayout(False)
        Me.tabPortControl.ResumeLayout(False)
        Me.tabPortComPort.ResumeLayout(False)
        Me.tabPortComPort.PerformLayout()
        Me.tabPortDataFile.ResumeLayout(False)
        Me.tabPortDataFile.PerformLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPortMissions.ResumeLayout(False)
        Me.tabPortMissions.PerformLayout()
        Me.grpMisc.ResumeLayout(False)
        Me.grpMisc.PerformLayout()
        Me.tabMapView.ResumeLayout(False)
        Me.tabViewMapView.ResumeLayout(False)
        CType(Me.tbarModelScale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabViewLiveCamera.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents cmdCenterOnPlane As System.Windows.Forms.Button
    Friend WithEvents cmdClearMap As System.Windows.Forms.Button
    Friend WithEvents tabInstrumentView As System.Windows.Forms.TabControl
    Friend WithEvents tabInstruments As System.Windows.Forms.TabPage
    Friend WithEvents VerticalSpeedIndicatorInstrumentControl1 As HK_GCS.AvionicsInstrumentControlDemo.VerticalSpeedIndicatorInstrumentControl
    Friend WithEvents HeadingIndicatorInstrumentControl1 As HK_GCS.AvionicsInstrumentControlDemo.HeadingIndicatorInstrumentControl
    Friend WithEvents AttitudeIndicatorInstrumentControl1 As HK_GCS.AvionicsInstrumentControlDemo.AttitudeIndicatorInstrumentControl
    Friend WithEvents AltimeterInstrumentControl1 As HK_GCS.AvionicsInstrumentControlDemo.AltimeterInstrumentControl
    Friend WithEvents AirSpeedIndicatorInstrumentControl1 As HK_GCS.AvionicsInstrumentControlDemo.AirSpeedIndicatorInstrumentControl
    Friend WithEvents tabSerialData As System.Windows.Forms.TabPage
    Friend WithEvents tmrPlayback As System.Windows.Forms.Timer
    Friend WithEvents lblTranslatedData As System.Windows.Forms.Label
    Friend WithEvents lblRawData As System.Windows.Forms.Label
    Friend WithEvents lstEvents As System.Windows.Forms.ListBox
    Friend WithEvents lstInbound As System.Windows.Forms.ListBox
    Friend WithEvents grpSerialSettings As System.Windows.Forms.GroupBox
    Friend WithEvents cboWaypoint As System.Windows.Forms.ComboBox
    Friend WithEvents cboGPS As System.Windows.Forms.ComboBox
    Friend WithEvents cboAttitude As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tabSettings As System.Windows.Forms.TabPage
    Friend WithEvents tmrSearch As System.Windows.Forms.Timer
    Friend WithEvents tabPortControl As System.Windows.Forms.TabControl
    Friend WithEvents tabPortComPort As System.Windows.Forms.TabPage
    Friend WithEvents cmdSearchCOM As System.Windows.Forms.Button
    Friend WithEvents cmdConnect As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents lblComPort As System.Windows.Forms.Label
    Friend WithEvents cboComPort As System.Windows.Forms.ComboBox
    Friend WithEvents tabPortDataFile As System.Windows.Forms.TabPage
    Friend WithEvents cboOutputFiles As System.Windows.Forms.ComboBox
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents cmdViewFile As System.Windows.Forms.Button
    Friend WithEvents cmdOutputFolder As System.Windows.Forms.Button
    Friend WithEvents chkRecord As System.Windows.Forms.CheckBox
    Friend WithEvents txtOutputFolder As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboSpeedUnits As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDistanceUnits As System.Windows.Forms.ComboBox
    Friend WithEvents cboMaxSpeed As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblGPSMessage As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblGPSType As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cboBaudRate As System.Windows.Forms.ComboBox
    Public WithEvents serialPortIn As System.IO.Ports.SerialPort
    Friend WithEvents chkPlay As System.Windows.Forms.CheckBox
    Friend WithEvents grpMisc As System.Windows.Forms.GroupBox
    Friend WithEvents chkStepForward As System.Windows.Forms.CheckBox
    Friend WithEvents chkStepBack As System.Windows.Forms.CheckBox
    Friend WithEvents chkFastForward As System.Windows.Forms.CheckBox
    Friend WithEvents chkReverse As System.Windows.Forms.CheckBox
    Friend WithEvents chkPause As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblThrottle As System.Windows.Forms.Label
    Friend WithEvents lblMode As System.Windows.Forms.Label
    Friend WithEvents lblDistance As System.Windows.Forms.Label
    Friend WithEvents lblWaypoint As System.Windows.Forms.Label
    Friend WithEvents lblHDOP As System.Windows.Forms.Label
    Friend WithEvents lblBattery As System.Windows.Forms.Label
    Friend WithEvents lblSatellites As System.Windows.Forms.Label
    Friend WithEvents lblGPSLock As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblLongitude As System.Windows.Forms.Label
    Friend WithEvents lblLatitude As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblLatitudeLabel As System.Windows.Forms.Label
    Friend WithEvents _3DMesh1 As HK_GCS._3DMesh
    Friend WithEvents tabMapView As System.Windows.Forms.TabControl
    Friend WithEvents tabViewMapView As System.Windows.Forms.TabPage
    Friend WithEvents tabViewLiveCamera As System.Windows.Forms.TabPage
    Friend WithEvents DirectShowControl1 As HK_GCS.DirectShowControl.DirectShowControl
    Friend WithEvents chkFlightExtrude As System.Windows.Forms.CheckBox
    Friend WithEvents cmdFlightColor As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents tbarFlightWidth As System.Windows.Forms.TrackBar
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents cbo3DModel As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents tabPortMissions As System.Windows.Forms.TabPage
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cboMission As System.Windows.Forms.ComboBox
    Friend WithEvents cmdReloadMissions As System.Windows.Forms.Button
    Friend WithEvents lblTargetAlt As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents chkRollReverse As System.Windows.Forms.CheckBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents chkPitchReverse As System.Windows.Forms.CheckBox
    Friend WithEvents tabCommandLine As System.Windows.Forms.TabPage
    Friend WithEvents cmdCommandLineSend As System.Windows.Forms.Button
    Friend WithEvents cboCommandLineCommand As System.Windows.Forms.ComboBox
    Friend WithEvents chkCommandLineAutoScroll As System.Windows.Forms.CheckBox
    Friend WithEvents cboCommandLineDelim As System.Windows.Forms.ComboBox
    Friend WithEvents lstCommandLineOutput As System.Windows.Forms.ListBox
    Friend WithEvents cmdReloadComPorts As System.Windows.Forms.Button
    Friend WithEvents lblComPortStatus As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblDataPoints As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents lblRunTime As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents lblBandwidth As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cboMapUpdateRate As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents chkViewChaseCam As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewOverhead As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewNoTracking As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewFirstPerson As System.Windows.Forms.CheckBox
    Friend WithEvents tabInstrumentLiveCamera As System.Windows.Forms.TabPage
    Friend WithEvents DirectShowControl2 As HK_GCS.DirectShowControl.DirectShowControl
    Friend WithEvents tbarModelScale As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdExpandInstruments As System.Windows.Forms.Button
    'Friend WithEvents DirectShow1 As HK_GCS.DirectShow

End Class
