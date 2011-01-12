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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tmrSearch = New System.Windows.Forms.Timer(Me.components)
        Me.tmrPlayback = New System.Windows.Forms.Timer(Me.components)
        Me.serialPortIn = New System.IO.Ports.SerialPort(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdExpandInstruments = New System.Windows.Forms.Button
        Me.cmdResetRuntime = New System.Windows.Forms.Button
        Me.cmdReloadComPorts = New System.Windows.Forms.Button
        Me.cmdReloadOutputFileList = New System.Windows.Forms.Button
        Me.chkFullDataFile = New System.Windows.Forms.CheckBox
        Me.chkStepForward = New System.Windows.Forms.CheckBox
        Me.chkStepBack = New System.Windows.Forms.CheckBox
        Me.chkReverse = New System.Windows.Forms.CheckBox
        Me.chkPause = New System.Windows.Forms.CheckBox
        Me.chkPlay = New System.Windows.Forms.CheckBox
        Me.cmdOutputFolder = New System.Windows.Forms.Button
        Me.chkRecord = New System.Windows.Forms.CheckBox
        Me.tbarModelScale = New System.Windows.Forms.TrackBar
        Me.cmdReloadMissionDirectory = New System.Windows.Forms.Button
        Me.cmdReloadMissions = New System.Windows.Forms.Button
        Me.cmdReloadTrackingPorts = New System.Windows.Forms.Button
        Me.tbarTilt = New System.Windows.Forms.TrackBar
        Me.tbarPan = New System.Windows.Forms.TrackBar
        Me.cboTrackingSet = New System.Windows.Forms.ComboBox
        Me.tmrComPort = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.mnuFile = New System.Windows.Forms.ToolStripDropDownButton
        Me.mnuSettings = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHelp = New System.Windows.Forms.ToolStripDropDownButton
        Me.mnuOpenHomepage = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuOpenDownloads = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.tabInstrumentView = New System.Windows.Forms.TabControl
        Me.tabInstruments = New System.Windows.Forms.TabPage
        Me.BatteryIndicatorInstrumentControl1 = New HK_GCS.AvionicsInstrumentControlDemo.BatteryIndicatorInstrumentControl
        Me.TurnCoordinatorInstrumentControl1 = New HK_GCS.AvionicsInstrumentControlDemo.TurnCoordinatorInstrumentControl
        Me.cmdZeroYaw = New System.Windows.Forms.Button
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
        Me.lblMaxWaypoint = New System.Windows.Forms.Label
        Me.lblMaxGPS = New System.Windows.Forms.Label
        Me.lblMaxAttitude = New System.Windows.Forms.Label
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
        Me.tabInstrumentLiveCamera = New System.Windows.Forms.TabPage
        Me.cmdLiveCameraProperties2 = New System.Windows.Forms.Button
        Me.cboLiveCameraSelect2 = New System.Windows.Forms.ComboBox
        Me.DirectShowControl2 = New HK_GCS.DirectShowControl.DirectShowControl
        Me.tabMissionControl = New System.Windows.Forms.TabPage
        Me.lblMissionLabel = New System.Windows.Forms.Label
        Me.cboMission = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.tabAtto = New System.Windows.Forms.TabPage
        Me.dgStringResources = New System.Windows.Forms.DataGridView
        Me.grpGPSTime = New System.Windows.Forms.GroupBox
        Me.lblGPSTime = New System.Windows.Forms.Label
        Me.grpMisc = New System.Windows.Forms.GroupBox
        Me.lblAmperage = New System.Windows.Forms.Label
        Me.lblAmpsLabel = New System.Windows.Forms.Label
        Me.lblRunTime = New System.Windows.Forms.Label
        Me.lblRunTimeLabel = New System.Windows.Forms.Label
        Me.lblDataPoints = New System.Windows.Forms.Label
        Me.lblDatapointsLabel = New System.Windows.Forms.Label
        Me.lblTargetAlt = New System.Windows.Forms.Label
        Me.lblTargetAltLabel = New System.Windows.Forms.Label
        Me.lblLongitude = New System.Windows.Forms.Label
        Me.lblLatitude = New System.Windows.Forms.Label
        Me.lblLongitudeLabel = New System.Windows.Forms.Label
        Me.lblLatitudeLabel = New System.Windows.Forms.Label
        Me.lblThrottle = New System.Windows.Forms.Label
        Me.lblMode = New System.Windows.Forms.Label
        Me.lblDistance = New System.Windows.Forms.Label
        Me.lblWaypoint = New System.Windows.Forms.Label
        Me.lblHDOP = New System.Windows.Forms.Label
        Me.lblBattery = New System.Windows.Forms.Label
        Me.lblSatellites = New System.Windows.Forms.Label
        Me.lblGPSLock = New System.Windows.Forms.Label
        Me.lblThrottleLabel = New System.Windows.Forms.Label
        Me.lblModeLabel = New System.Windows.Forms.Label
        Me.lblDistanceLabel = New System.Windows.Forms.Label
        Me.lblWaypointLabel = New System.Windows.Forms.Label
        Me.lblHDOPLabel = New System.Windows.Forms.Label
        Me.lblBatteryLabel = New System.Windows.Forms.Label
        Me.lblSatellitesLabel = New System.Windows.Forms.Label
        Me.lblGPSLockLabel = New System.Windows.Forms.Label
        Me.tabPortControl = New System.Windows.Forms.TabControl
        Me.tabPortComPort = New System.Windows.Forms.TabPage
        Me.txtSocket = New System.Windows.Forms.TextBox
        Me.cmdTest = New System.Windows.Forms.Button
        Me.lblBandwidth = New System.Windows.Forms.Label
        Me.lblComPortStatus = New System.Windows.Forms.Label
        Me.lblStatusLabel = New System.Windows.Forms.Label
        Me.cboBaudRate = New System.Windows.Forms.ComboBox
        Me.lblGPSMessage = New System.Windows.Forms.Label
        Me.lblGPSMessageLabel = New System.Windows.Forms.Label
        Me.lblGPSType = New System.Windows.Forms.Label
        Me.lblGPSTypeLabel = New System.Windows.Forms.Label
        Me.lblBaudRate = New System.Windows.Forms.Label
        Me.cmdConnect = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.lblComPort = New System.Windows.Forms.Label
        Me.cboComPort = New System.Windows.Forms.ComboBox
        Me.cmdSearchCOM = New System.Windows.Forms.Button
        Me.tabPortDataFile = New System.Windows.Forms.TabPage
        Me.cboOutputFiles = New System.Windows.Forms.ComboBox
        Me.TrackBar1 = New System.Windows.Forms.TrackBar
        Me.cmdViewFile = New System.Windows.Forms.Button
        Me.txtOutputFolder = New System.Windows.Forms.TextBox
        Me.tabPortTracking = New System.Windows.Forms.TabPage
        Me.lblTrackerAngle = New System.Windows.Forms.Label
        Me.cmdTrackingCalibrate = New System.Windows.Forms.Button
        Me.lblHertzTracking = New System.Windows.Forms.Label
        Me.cboHertzTracking = New System.Windows.Forms.ComboBox
        Me.cboOutputTypeTracking = New System.Windows.Forms.ComboBox
        Me.lblOutputTypeTracking = New System.Windows.Forms.Label
        Me.lblStatusTracking = New System.Windows.Forms.Label
        Me.lblStatusTrackingStatus = New System.Windows.Forms.Label
        Me.cboBaudRateTracking = New System.Windows.Forms.ComboBox
        Me.lblBaudRateTracking = New System.Windows.Forms.Label
        Me.cmdConnectTracking = New System.Windows.Forms.Button
        Me.lblComPortTracking = New System.Windows.Forms.Label
        Me.cboComPortTracking = New System.Windows.Forms.ComboBox
        Me.tabPortServos = New System.Windows.Forms.TabPage
        Me.cboServo8 = New System.Windows.Forms.ComboBox
        Me.cboServo7 = New System.Windows.Forms.ComboBox
        Me.cboServo6 = New System.Windows.Forms.ComboBox
        Me.cboServo5 = New System.Windows.Forms.ComboBox
        Me.cboServo4 = New System.Windows.Forms.ComboBox
        Me.cboServo3 = New System.Windows.Forms.ComboBox
        Me.cboServo2 = New System.Windows.Forms.ComboBox
        Me.cboServo1 = New System.Windows.Forms.ComboBox
        Me.lblServo8 = New System.Windows.Forms.Label
        Me.lblServo7 = New System.Windows.Forms.Label
        Me.lblServo6 = New System.Windows.Forms.Label
        Me.lblServo5 = New System.Windows.Forms.Label
        Me.lblServo4 = New System.Windows.Forms.Label
        Me.lblServo3 = New System.Windows.Forms.Label
        Me.lblServo2 = New System.Windows.Forms.Label
        Me.lblServo1 = New System.Windows.Forms.Label
        Me.tbarServo8 = New System.Windows.Forms.TrackBar
        Me.tbarServo7 = New System.Windows.Forms.TrackBar
        Me.tbarServo6 = New System.Windows.Forms.TrackBar
        Me.tbarServo5 = New System.Windows.Forms.TrackBar
        Me.tbarServo4 = New System.Windows.Forms.TrackBar
        Me.tbarServo3 = New System.Windows.Forms.TrackBar
        Me.tbarServo2 = New System.Windows.Forms.TrackBar
        Me.tbarServo1 = New System.Windows.Forms.TrackBar
        Me.tabPortSensors = New System.Windows.Forms.TabPage
        Me.cboSensors8 = New System.Windows.Forms.ComboBox
        Me.cboSensors7 = New System.Windows.Forms.ComboBox
        Me.cboSensors6 = New System.Windows.Forms.ComboBox
        Me.cboSensors5 = New System.Windows.Forms.ComboBox
        Me.cboSensors4 = New System.Windows.Forms.ComboBox
        Me.cboSensors3 = New System.Windows.Forms.ComboBox
        Me.cboSensors2 = New System.Windows.Forms.ComboBox
        Me.cboSensors1 = New System.Windows.Forms.ComboBox
        Me.lblSensor8 = New System.Windows.Forms.Label
        Me.lblSensor7 = New System.Windows.Forms.Label
        Me.lblSensor6 = New System.Windows.Forms.Label
        Me.lblSensor5 = New System.Windows.Forms.Label
        Me.lblSensor4 = New System.Windows.Forms.Label
        Me.lblSensor3 = New System.Windows.Forms.Label
        Me.lblSensor2 = New System.Windows.Forms.Label
        Me.lblSensor1 = New System.Windows.Forms.Label
        Me.tbarSensor8 = New System.Windows.Forms.TrackBar
        Me.tbarSensor7 = New System.Windows.Forms.TrackBar
        Me.tbarSensor6 = New System.Windows.Forms.TrackBar
        Me.tbarSensor5 = New System.Windows.Forms.TrackBar
        Me.tbarSensor4 = New System.Windows.Forms.TrackBar
        Me.tbarSensor3 = New System.Windows.Forms.TrackBar
        Me.tbarSensor2 = New System.Windows.Forms.TrackBar
        Me.tbarSensor1 = New System.Windows.Forms.TrackBar
        Me.JoystickInstrumentControl1 = New HK_GCS.AvionicsInstrumentControlDemo.JoystickInstrumentControl
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdSetHome = New System.Windows.Forms.Button
        Me.cmdClearMap = New System.Windows.Forms.Button
        Me.cmdCenterOnPlane = New System.Windows.Forms.Button
        Me.tabMapView = New System.Windows.Forms.TabControl
        Me.tabViewMapView = New System.Windows.Forms.TabPage
        Me.chkViewFirstPerson = New System.Windows.Forms.CheckBox
        Me.chkViewChaseCam = New System.Windows.Forms.CheckBox
        Me.chkViewOverhead = New System.Windows.Forms.CheckBox
        Me.chkViewNoTracking = New System.Windows.Forms.CheckBox
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.tabViewLiveCamera = New System.Windows.Forms.TabPage
        Me.cmdLiveCameraProperties1 = New System.Windows.Forms.Button
        Me.cboLiveCameraSelect1 = New System.Windows.Forms.ComboBox
        Me.DirectShowControl1 = New HK_GCS.DirectShowControl.DirectShowControl
        Me.tmrTracking = New System.Windows.Forms.Timer(Me.components)
        Me.serialPortTracking = New System.IO.Ports.SerialPort(Me.components)
        CType(Me.tbarModelScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarTilt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarPan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.tabInstrumentView.SuspendLayout()
        Me.tabInstruments.SuspendLayout()
        Me.tabSerialData.SuspendLayout()
        Me.grpSerialSettings.SuspendLayout()
        Me.tabCommandLine.SuspendLayout()
        Me.tabInstrumentLiveCamera.SuspendLayout()
        Me.tabMissionControl.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAtto.SuspendLayout()
        CType(Me.dgStringResources, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGPSTime.SuspendLayout()
        Me.grpMisc.SuspendLayout()
        Me.tabPortControl.SuspendLayout()
        Me.tabPortComPort.SuspendLayout()
        Me.tabPortDataFile.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPortTracking.SuspendLayout()
        Me.tabPortServos.SuspendLayout()
        CType(Me.tbarServo8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarServo7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarServo6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarServo5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarServo4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarServo3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarServo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarServo1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPortSensors.SuspendLayout()
        CType(Me.tbarSensor8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarSensor7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarSensor6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarSensor5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarSensor4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarSensor3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarSensor2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarSensor1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMapView.SuspendLayout()
        Me.tabViewMapView.SuspendLayout()
        Me.tabViewLiveCamera.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrSearch
        '
        '
        'tmrPlayback
        '
        '
        'serialPortIn
        '
        Me.serialPortIn.DtrEnable = True
        Me.serialPortIn.ReceivedBytesThreshold = 4096
        Me.serialPortIn.RtsEnable = True
        '
        'cmdExpandInstruments
        '
        resources.ApplyResources(Me.cmdExpandInstruments, "cmdExpandInstruments")
        Me.cmdExpandInstruments.Name = "cmdExpandInstruments"
        Me.ToolTip1.SetToolTip(Me.cmdExpandInstruments, resources.GetString("cmdExpandInstruments.ToolTip"))
        Me.cmdExpandInstruments.UseVisualStyleBackColor = True
        '
        'cmdResetRuntime
        '
        resources.ApplyResources(Me.cmdResetRuntime, "cmdResetRuntime")
        Me.cmdResetRuntime.Name = "cmdResetRuntime"
        Me.ToolTip1.SetToolTip(Me.cmdResetRuntime, resources.GetString("cmdResetRuntime.ToolTip"))
        Me.cmdResetRuntime.UseVisualStyleBackColor = True
        '
        'cmdReloadComPorts
        '
        resources.ApplyResources(Me.cmdReloadComPorts, "cmdReloadComPorts")
        Me.cmdReloadComPorts.Name = "cmdReloadComPorts"
        Me.ToolTip1.SetToolTip(Me.cmdReloadComPorts, resources.GetString("cmdReloadComPorts.ToolTip"))
        Me.cmdReloadComPorts.UseVisualStyleBackColor = True
        '
        'cmdReloadOutputFileList
        '
        resources.ApplyResources(Me.cmdReloadOutputFileList, "cmdReloadOutputFileList")
        Me.cmdReloadOutputFileList.Name = "cmdReloadOutputFileList"
        Me.ToolTip1.SetToolTip(Me.cmdReloadOutputFileList, resources.GetString("cmdReloadOutputFileList.ToolTip"))
        Me.cmdReloadOutputFileList.UseVisualStyleBackColor = True
        '
        'chkFullDataFile
        '
        resources.ApplyResources(Me.chkFullDataFile, "chkFullDataFile")
        Me.chkFullDataFile.Name = "chkFullDataFile"
        Me.ToolTip1.SetToolTip(Me.chkFullDataFile, resources.GetString("chkFullDataFile.ToolTip"))
        Me.chkFullDataFile.UseVisualStyleBackColor = True
        '
        'chkStepForward
        '
        resources.ApplyResources(Me.chkStepForward, "chkStepForward")
        Me.chkStepForward.Name = "chkStepForward"
        Me.ToolTip1.SetToolTip(Me.chkStepForward, resources.GetString("chkStepForward.ToolTip"))
        Me.chkStepForward.UseVisualStyleBackColor = True
        '
        'chkStepBack
        '
        resources.ApplyResources(Me.chkStepBack, "chkStepBack")
        Me.chkStepBack.Name = "chkStepBack"
        Me.ToolTip1.SetToolTip(Me.chkStepBack, resources.GetString("chkStepBack.ToolTip"))
        Me.chkStepBack.UseVisualStyleBackColor = True
        '
        'chkReverse
        '
        resources.ApplyResources(Me.chkReverse, "chkReverse")
        Me.chkReverse.Name = "chkReverse"
        Me.ToolTip1.SetToolTip(Me.chkReverse, resources.GetString("chkReverse.ToolTip"))
        Me.chkReverse.UseVisualStyleBackColor = True
        '
        'chkPause
        '
        resources.ApplyResources(Me.chkPause, "chkPause")
        Me.chkPause.Name = "chkPause"
        Me.ToolTip1.SetToolTip(Me.chkPause, resources.GetString("chkPause.ToolTip"))
        Me.chkPause.UseVisualStyleBackColor = True
        '
        'chkPlay
        '
        resources.ApplyResources(Me.chkPlay, "chkPlay")
        Me.chkPlay.Name = "chkPlay"
        Me.ToolTip1.SetToolTip(Me.chkPlay, resources.GetString("chkPlay.ToolTip"))
        Me.chkPlay.UseVisualStyleBackColor = True
        '
        'cmdOutputFolder
        '
        resources.ApplyResources(Me.cmdOutputFolder, "cmdOutputFolder")
        Me.cmdOutputFolder.Name = "cmdOutputFolder"
        Me.ToolTip1.SetToolTip(Me.cmdOutputFolder, resources.GetString("cmdOutputFolder.ToolTip"))
        Me.cmdOutputFolder.UseVisualStyleBackColor = True
        '
        'chkRecord
        '
        resources.ApplyResources(Me.chkRecord, "chkRecord")
        Me.chkRecord.Name = "chkRecord"
        Me.ToolTip1.SetToolTip(Me.chkRecord, resources.GetString("chkRecord.ToolTip"))
        Me.chkRecord.UseVisualStyleBackColor = True
        '
        'tbarModelScale
        '
        resources.ApplyResources(Me.tbarModelScale, "tbarModelScale")
        Me.tbarModelScale.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbarModelScale.Maximum = 50
        Me.tbarModelScale.Minimum = 1
        Me.tbarModelScale.Name = "tbarModelScale"
        Me.tbarModelScale.TickStyle = System.Windows.Forms.TickStyle.None
        Me.ToolTip1.SetToolTip(Me.tbarModelScale, resources.GetString("tbarModelScale.ToolTip"))
        Me.tbarModelScale.Value = 10
        '
        'cmdReloadMissionDirectory
        '
        resources.ApplyResources(Me.cmdReloadMissionDirectory, "cmdReloadMissionDirectory")
        Me.cmdReloadMissionDirectory.Name = "cmdReloadMissionDirectory"
        Me.ToolTip1.SetToolTip(Me.cmdReloadMissionDirectory, resources.GetString("cmdReloadMissionDirectory.ToolTip"))
        Me.cmdReloadMissionDirectory.UseVisualStyleBackColor = True
        '
        'cmdReloadMissions
        '
        resources.ApplyResources(Me.cmdReloadMissions, "cmdReloadMissions")
        Me.cmdReloadMissions.Name = "cmdReloadMissions"
        Me.ToolTip1.SetToolTip(Me.cmdReloadMissions, resources.GetString("cmdReloadMissions.ToolTip"))
        Me.cmdReloadMissions.UseVisualStyleBackColor = True
        '
        'cmdReloadTrackingPorts
        '
        resources.ApplyResources(Me.cmdReloadTrackingPorts, "cmdReloadTrackingPorts")
        Me.cmdReloadTrackingPorts.Name = "cmdReloadTrackingPorts"
        Me.ToolTip1.SetToolTip(Me.cmdReloadTrackingPorts, resources.GetString("cmdReloadTrackingPorts.ToolTip"))
        Me.cmdReloadTrackingPorts.UseVisualStyleBackColor = True
        '
        'tbarTilt
        '
        resources.ApplyResources(Me.tbarTilt, "tbarTilt")
        Me.tbarTilt.BackColor = System.Drawing.Color.White
        Me.tbarTilt.LargeChange = 1
        Me.tbarTilt.Maximum = 2000
        Me.tbarTilt.Minimum = 1000
        Me.tbarTilt.Name = "tbarTilt"
        Me.tbarTilt.TabStop = False
        Me.tbarTilt.TickStyle = System.Windows.Forms.TickStyle.None
        Me.ToolTip1.SetToolTip(Me.tbarTilt, resources.GetString("tbarTilt.ToolTip"))
        Me.tbarTilt.Value = 1500
        '
        'tbarPan
        '
        resources.ApplyResources(Me.tbarPan, "tbarPan")
        Me.tbarPan.BackColor = System.Drawing.Color.White
        Me.tbarPan.LargeChange = 1
        Me.tbarPan.Maximum = 2000
        Me.tbarPan.Minimum = 1000
        Me.tbarPan.Name = "tbarPan"
        Me.tbarPan.TabStop = False
        Me.tbarPan.TickStyle = System.Windows.Forms.TickStyle.None
        Me.ToolTip1.SetToolTip(Me.tbarPan, resources.GetString("tbarPan.ToolTip"))
        Me.tbarPan.Value = 1500
        '
        'cboTrackingSet
        '
        Me.cboTrackingSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTrackingSet.FormattingEnabled = True
        resources.ApplyResources(Me.cboTrackingSet, "cboTrackingSet")
        Me.cboTrackingSet.Name = "cboTrackingSet"
        Me.ToolTip1.SetToolTip(Me.cboTrackingSet, resources.GetString("cboTrackingSet.ToolTip"))
        '
        'tmrComPort
        '
        Me.tmrComPort.Interval = 50
        '
        'SplitContainer1
        '
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdExpandInstruments)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tabInstrumentView)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpGPSTime)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpMisc)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tabPortControl)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.JoystickInstrumentControl1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdExit)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdSetHome)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdClearMap)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdCenterOnPlane)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabMapView)
        '
        'ToolStrip1
        '
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuHelp})
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        '
        'mnuFile
        '
        Me.mnuFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSettings, Me.ToolStripMenuItem2, Me.mnuExit})
        resources.ApplyResources(Me.mnuFile, "mnuFile")
        Me.mnuFile.Name = "mnuFile"
        '
        'mnuSettings
        '
        Me.mnuSettings.Name = "mnuSettings"
        resources.ApplyResources(Me.mnuSettings, "mnuSettings")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        resources.ApplyResources(Me.mnuExit, "mnuExit")
        '
        'mnuHelp
        '
        Me.mnuHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpenHomepage, Me.mnuOpenDownloads, Me.ToolStripMenuItem1, Me.mnuAbout})
        resources.ApplyResources(Me.mnuHelp, "mnuHelp")
        Me.mnuHelp.Name = "mnuHelp"
        '
        'mnuOpenHomepage
        '
        Me.mnuOpenHomepage.Name = "mnuOpenHomepage"
        resources.ApplyResources(Me.mnuOpenHomepage, "mnuOpenHomepage")
        '
        'mnuOpenDownloads
        '
        Me.mnuOpenDownloads.Name = "mnuOpenDownloads"
        resources.ApplyResources(Me.mnuOpenDownloads, "mnuOpenDownloads")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuAbout
        '
        Me.mnuAbout.Name = "mnuAbout"
        resources.ApplyResources(Me.mnuAbout, "mnuAbout")
        '
        'tabInstrumentView
        '
        Me.tabInstrumentView.Controls.Add(Me.tabInstruments)
        Me.tabInstrumentView.Controls.Add(Me.tabSerialData)
        Me.tabInstrumentView.Controls.Add(Me.tabCommandLine)
        Me.tabInstrumentView.Controls.Add(Me.tabInstrumentLiveCamera)
        Me.tabInstrumentView.Controls.Add(Me.tabMissionControl)
        Me.tabInstrumentView.Controls.Add(Me.tabAtto)
        resources.ApplyResources(Me.tabInstrumentView, "tabInstrumentView")
        Me.tabInstrumentView.Name = "tabInstrumentView"
        Me.tabInstrumentView.SelectedIndex = 0
        '
        'tabInstruments
        '
        Me.tabInstruments.BackColor = System.Drawing.Color.Transparent
        Me.tabInstruments.Controls.Add(Me.BatteryIndicatorInstrumentControl1)
        Me.tabInstruments.Controls.Add(Me.TurnCoordinatorInstrumentControl1)
        Me.tabInstruments.Controls.Add(Me.cmdZeroYaw)
        Me.tabInstruments.Controls.Add(Me._3DMesh1)
        Me.tabInstruments.Controls.Add(Me.VerticalSpeedIndicatorInstrumentControl1)
        Me.tabInstruments.Controls.Add(Me.HeadingIndicatorInstrumentControl1)
        Me.tabInstruments.Controls.Add(Me.AttitudeIndicatorInstrumentControl1)
        Me.tabInstruments.Controls.Add(Me.AltimeterInstrumentControl1)
        Me.tabInstruments.Controls.Add(Me.AirSpeedIndicatorInstrumentControl1)
        resources.ApplyResources(Me.tabInstruments, "tabInstruments")
        Me.tabInstruments.Name = "tabInstruments"
        Me.tabInstruments.UseVisualStyleBackColor = True
        '
        'BatteryIndicatorInstrumentControl1
        '
        Me.BatteryIndicatorInstrumentControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(241, Byte), Integer))
        resources.ApplyResources(Me.BatteryIndicatorInstrumentControl1, "BatteryIndicatorInstrumentControl1")
        Me.BatteryIndicatorInstrumentControl1.Name = "BatteryIndicatorInstrumentControl1"
        '
        'TurnCoordinatorInstrumentControl1
        '
        Me.TurnCoordinatorInstrumentControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(241, Byte), Integer))
        resources.ApplyResources(Me.TurnCoordinatorInstrumentControl1, "TurnCoordinatorInstrumentControl1")
        Me.TurnCoordinatorInstrumentControl1.Name = "TurnCoordinatorInstrumentControl1"
        '
        'cmdZeroYaw
        '
        resources.ApplyResources(Me.cmdZeroYaw, "cmdZeroYaw")
        Me.cmdZeroYaw.Name = "cmdZeroYaw"
        Me.cmdZeroYaw.UseVisualStyleBackColor = True
        '
        '_3DMesh1
        '
        Me._3DMesh1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me._3DMesh1, "_3DMesh1")
        Me._3DMesh1.Name = "_3DMesh1"
        '
        'VerticalSpeedIndicatorInstrumentControl1
        '
        Me.VerticalSpeedIndicatorInstrumentControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(241, Byte), Integer))
        resources.ApplyResources(Me.VerticalSpeedIndicatorInstrumentControl1, "VerticalSpeedIndicatorInstrumentControl1")
        Me.VerticalSpeedIndicatorInstrumentControl1.Name = "VerticalSpeedIndicatorInstrumentControl1"
        '
        'HeadingIndicatorInstrumentControl1
        '
        Me.HeadingIndicatorInstrumentControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(241, Byte), Integer))
        resources.ApplyResources(Me.HeadingIndicatorInstrumentControl1, "HeadingIndicatorInstrumentControl1")
        Me.HeadingIndicatorInstrumentControl1.Name = "HeadingIndicatorInstrumentControl1"
        '
        'AttitudeIndicatorInstrumentControl1
        '
        Me.AttitudeIndicatorInstrumentControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(241, Byte), Integer))
        resources.ApplyResources(Me.AttitudeIndicatorInstrumentControl1, "AttitudeIndicatorInstrumentControl1")
        Me.AttitudeIndicatorInstrumentControl1.Name = "AttitudeIndicatorInstrumentControl1"
        '
        'AltimeterInstrumentControl1
        '
        Me.AltimeterInstrumentControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(241, Byte), Integer))
        resources.ApplyResources(Me.AltimeterInstrumentControl1, "AltimeterInstrumentControl1")
        Me.AltimeterInstrumentControl1.Name = "AltimeterInstrumentControl1"
        '
        'AirSpeedIndicatorInstrumentControl1
        '
        Me.AirSpeedIndicatorInstrumentControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(241, Byte), Integer))
        resources.ApplyResources(Me.AirSpeedIndicatorInstrumentControl1, "AirSpeedIndicatorInstrumentControl1")
        Me.AirSpeedIndicatorInstrumentControl1.Name = "AirSpeedIndicatorInstrumentControl1"
        '
        'tabSerialData
        '
        Me.tabSerialData.Controls.Add(Me.grpSerialSettings)
        Me.tabSerialData.Controls.Add(Me.lblTranslatedData)
        Me.tabSerialData.Controls.Add(Me.lblRawData)
        Me.tabSerialData.Controls.Add(Me.lstEvents)
        Me.tabSerialData.Controls.Add(Me.lstInbound)
        resources.ApplyResources(Me.tabSerialData, "tabSerialData")
        Me.tabSerialData.Name = "tabSerialData"
        Me.tabSerialData.UseVisualStyleBackColor = True
        '
        'grpSerialSettings
        '
        Me.grpSerialSettings.Controls.Add(Me.cboWaypoint)
        Me.grpSerialSettings.Controls.Add(Me.cboGPS)
        Me.grpSerialSettings.Controls.Add(Me.cboAttitude)
        Me.grpSerialSettings.Controls.Add(Me.lblMaxWaypoint)
        Me.grpSerialSettings.Controls.Add(Me.lblMaxGPS)
        Me.grpSerialSettings.Controls.Add(Me.lblMaxAttitude)
        resources.ApplyResources(Me.grpSerialSettings, "grpSerialSettings")
        Me.grpSerialSettings.Name = "grpSerialSettings"
        Me.grpSerialSettings.TabStop = False
        '
        'cboWaypoint
        '
        Me.cboWaypoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWaypoint.FormattingEnabled = True
        resources.ApplyResources(Me.cboWaypoint, "cboWaypoint")
        Me.cboWaypoint.Name = "cboWaypoint"
        '
        'cboGPS
        '
        Me.cboGPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGPS.FormattingEnabled = True
        resources.ApplyResources(Me.cboGPS, "cboGPS")
        Me.cboGPS.Name = "cboGPS"
        '
        'cboAttitude
        '
        Me.cboAttitude.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttitude.FormattingEnabled = True
        resources.ApplyResources(Me.cboAttitude, "cboAttitude")
        Me.cboAttitude.Name = "cboAttitude"
        '
        'lblMaxWaypoint
        '
        resources.ApplyResources(Me.lblMaxWaypoint, "lblMaxWaypoint")
        Me.lblMaxWaypoint.Name = "lblMaxWaypoint"
        '
        'lblMaxGPS
        '
        resources.ApplyResources(Me.lblMaxGPS, "lblMaxGPS")
        Me.lblMaxGPS.Name = "lblMaxGPS"
        '
        'lblMaxAttitude
        '
        resources.ApplyResources(Me.lblMaxAttitude, "lblMaxAttitude")
        Me.lblMaxAttitude.Name = "lblMaxAttitude"
        '
        'lblTranslatedData
        '
        resources.ApplyResources(Me.lblTranslatedData, "lblTranslatedData")
        Me.lblTranslatedData.Name = "lblTranslatedData"
        '
        'lblRawData
        '
        resources.ApplyResources(Me.lblRawData, "lblRawData")
        Me.lblRawData.Name = "lblRawData"
        '
        'lstEvents
        '
        resources.ApplyResources(Me.lstEvents, "lstEvents")
        Me.lstEvents.FormattingEnabled = True
        Me.lstEvents.Name = "lstEvents"
        '
        'lstInbound
        '
        resources.ApplyResources(Me.lstInbound, "lstInbound")
        Me.lstInbound.FormattingEnabled = True
        Me.lstInbound.Name = "lstInbound"
        '
        'tabCommandLine
        '
        Me.tabCommandLine.Controls.Add(Me.cmdCommandLineSend)
        Me.tabCommandLine.Controls.Add(Me.cboCommandLineCommand)
        Me.tabCommandLine.Controls.Add(Me.chkCommandLineAutoScroll)
        Me.tabCommandLine.Controls.Add(Me.cboCommandLineDelim)
        Me.tabCommandLine.Controls.Add(Me.lstCommandLineOutput)
        resources.ApplyResources(Me.tabCommandLine, "tabCommandLine")
        Me.tabCommandLine.Name = "tabCommandLine"
        Me.tabCommandLine.UseVisualStyleBackColor = True
        '
        'cmdCommandLineSend
        '
        resources.ApplyResources(Me.cmdCommandLineSend, "cmdCommandLineSend")
        Me.cmdCommandLineSend.Name = "cmdCommandLineSend"
        Me.cmdCommandLineSend.UseVisualStyleBackColor = True
        '
        'cboCommandLineCommand
        '
        Me.cboCommandLineCommand.FormattingEnabled = True
        resources.ApplyResources(Me.cboCommandLineCommand, "cboCommandLineCommand")
        Me.cboCommandLineCommand.Name = "cboCommandLineCommand"
        '
        'chkCommandLineAutoScroll
        '
        resources.ApplyResources(Me.chkCommandLineAutoScroll, "chkCommandLineAutoScroll")
        Me.chkCommandLineAutoScroll.Name = "chkCommandLineAutoScroll"
        Me.chkCommandLineAutoScroll.UseVisualStyleBackColor = True
        '
        'cboCommandLineDelim
        '
        Me.cboCommandLineDelim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCommandLineDelim.FormattingEnabled = True
        resources.ApplyResources(Me.cboCommandLineDelim, "cboCommandLineDelim")
        Me.cboCommandLineDelim.Name = "cboCommandLineDelim"
        '
        'lstCommandLineOutput
        '
        resources.ApplyResources(Me.lstCommandLineOutput, "lstCommandLineOutput")
        Me.lstCommandLineOutput.FormattingEnabled = True
        Me.lstCommandLineOutput.Name = "lstCommandLineOutput"
        '
        'tabInstrumentLiveCamera
        '
        Me.tabInstrumentLiveCamera.Controls.Add(Me.cmdLiveCameraProperties2)
        Me.tabInstrumentLiveCamera.Controls.Add(Me.cboLiveCameraSelect2)
        Me.tabInstrumentLiveCamera.Controls.Add(Me.DirectShowControl2)
        resources.ApplyResources(Me.tabInstrumentLiveCamera, "tabInstrumentLiveCamera")
        Me.tabInstrumentLiveCamera.Name = "tabInstrumentLiveCamera"
        Me.tabInstrumentLiveCamera.UseVisualStyleBackColor = True
        '
        'cmdLiveCameraProperties2
        '
        resources.ApplyResources(Me.cmdLiveCameraProperties2, "cmdLiveCameraProperties2")
        Me.cmdLiveCameraProperties2.Name = "cmdLiveCameraProperties2"
        Me.cmdLiveCameraProperties2.UseVisualStyleBackColor = True
        '
        'cboLiveCameraSelect2
        '
        Me.cboLiveCameraSelect2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLiveCameraSelect2.FormattingEnabled = True
        resources.ApplyResources(Me.cboLiveCameraSelect2, "cboLiveCameraSelect2")
        Me.cboLiveCameraSelect2.Name = "cboLiveCameraSelect2"
        '
        'DirectShowControl2
        '
        resources.ApplyResources(Me.DirectShowControl2, "DirectShowControl2")
        Me.DirectShowControl2.Name = "DirectShowControl2"
        '
        'tabMissionControl
        '
        Me.tabMissionControl.Controls.Add(Me.cmdReloadMissionDirectory)
        Me.tabMissionControl.Controls.Add(Me.cmdReloadMissions)
        Me.tabMissionControl.Controls.Add(Me.lblMissionLabel)
        Me.tabMissionControl.Controls.Add(Me.cboMission)
        Me.tabMissionControl.Controls.Add(Me.Label1)
        Me.tabMissionControl.Controls.Add(Me.ComboBox1)
        Me.tabMissionControl.Controls.Add(Me.Button1)
        Me.tabMissionControl.Controls.Add(Me.DataGridView1)
        resources.ApplyResources(Me.tabMissionControl, "tabMissionControl")
        Me.tabMissionControl.Name = "tabMissionControl"
        Me.tabMissionControl.UseVisualStyleBackColor = True
        '
        'lblMissionLabel
        '
        resources.ApplyResources(Me.lblMissionLabel, "lblMissionLabel")
        Me.lblMissionLabel.Name = "lblMissionLabel"
        '
        'cboMission
        '
        Me.cboMission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMission.FormattingEnabled = True
        resources.ApplyResources(Me.cboMission, "cboMission")
        Me.cboMission.Name = "cboMission"
        Me.cboMission.Sorted = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBox1, "ComboBox1")
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Sorted = True
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        resources.ApplyResources(Me.DataGridView1, "DataGridView1")
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        '
        'tabAtto
        '
        Me.tabAtto.Controls.Add(Me.dgStringResources)
        resources.ApplyResources(Me.tabAtto, "tabAtto")
        Me.tabAtto.Name = "tabAtto"
        Me.tabAtto.UseVisualStyleBackColor = True
        '
        'dgStringResources
        '
        Me.dgStringResources.AllowUserToAddRows = False
        Me.dgStringResources.AllowUserToDeleteRows = False
        Me.dgStringResources.AllowUserToResizeRows = False
        Me.dgStringResources.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgStringResources.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgStringResources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgStringResources.DefaultCellStyle = DataGridViewCellStyle5
        resources.ApplyResources(Me.dgStringResources, "dgStringResources")
        Me.dgStringResources.MultiSelect = False
        Me.dgStringResources.Name = "dgStringResources"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgStringResources.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgStringResources.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        '
        'grpGPSTime
        '
        Me.grpGPSTime.Controls.Add(Me.lblGPSTime)
        resources.ApplyResources(Me.grpGPSTime, "grpGPSTime")
        Me.grpGPSTime.Name = "grpGPSTime"
        Me.grpGPSTime.TabStop = False
        '
        'lblGPSTime
        '
        resources.ApplyResources(Me.lblGPSTime, "lblGPSTime")
        Me.lblGPSTime.Name = "lblGPSTime"
        '
        'grpMisc
        '
        Me.grpMisc.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.grpMisc.Controls.Add(Me.lblAmperage)
        Me.grpMisc.Controls.Add(Me.lblAmpsLabel)
        Me.grpMisc.Controls.Add(Me.cmdResetRuntime)
        Me.grpMisc.Controls.Add(Me.lblRunTime)
        Me.grpMisc.Controls.Add(Me.lblRunTimeLabel)
        Me.grpMisc.Controls.Add(Me.lblDataPoints)
        Me.grpMisc.Controls.Add(Me.lblDatapointsLabel)
        Me.grpMisc.Controls.Add(Me.lblTargetAlt)
        Me.grpMisc.Controls.Add(Me.lblTargetAltLabel)
        Me.grpMisc.Controls.Add(Me.lblLongitude)
        Me.grpMisc.Controls.Add(Me.lblLatitude)
        Me.grpMisc.Controls.Add(Me.lblLongitudeLabel)
        Me.grpMisc.Controls.Add(Me.lblLatitudeLabel)
        Me.grpMisc.Controls.Add(Me.lblThrottle)
        Me.grpMisc.Controls.Add(Me.lblMode)
        Me.grpMisc.Controls.Add(Me.lblDistance)
        Me.grpMisc.Controls.Add(Me.lblWaypoint)
        Me.grpMisc.Controls.Add(Me.lblHDOP)
        Me.grpMisc.Controls.Add(Me.lblBattery)
        Me.grpMisc.Controls.Add(Me.lblSatellites)
        Me.grpMisc.Controls.Add(Me.lblGPSLock)
        Me.grpMisc.Controls.Add(Me.lblThrottleLabel)
        Me.grpMisc.Controls.Add(Me.lblModeLabel)
        Me.grpMisc.Controls.Add(Me.lblDistanceLabel)
        Me.grpMisc.Controls.Add(Me.lblWaypointLabel)
        Me.grpMisc.Controls.Add(Me.lblHDOPLabel)
        Me.grpMisc.Controls.Add(Me.lblBatteryLabel)
        Me.grpMisc.Controls.Add(Me.lblSatellitesLabel)
        Me.grpMisc.Controls.Add(Me.lblGPSLockLabel)
        resources.ApplyResources(Me.grpMisc, "grpMisc")
        Me.grpMisc.Name = "grpMisc"
        Me.grpMisc.TabStop = False
        '
        'lblAmperage
        '
        resources.ApplyResources(Me.lblAmperage, "lblAmperage")
        Me.lblAmperage.Name = "lblAmperage"
        '
        'lblAmpsLabel
        '
        resources.ApplyResources(Me.lblAmpsLabel, "lblAmpsLabel")
        Me.lblAmpsLabel.Name = "lblAmpsLabel"
        '
        'lblRunTime
        '
        resources.ApplyResources(Me.lblRunTime, "lblRunTime")
        Me.lblRunTime.Name = "lblRunTime"
        '
        'lblRunTimeLabel
        '
        resources.ApplyResources(Me.lblRunTimeLabel, "lblRunTimeLabel")
        Me.lblRunTimeLabel.Name = "lblRunTimeLabel"
        '
        'lblDataPoints
        '
        resources.ApplyResources(Me.lblDataPoints, "lblDataPoints")
        Me.lblDataPoints.Name = "lblDataPoints"
        '
        'lblDatapointsLabel
        '
        resources.ApplyResources(Me.lblDatapointsLabel, "lblDatapointsLabel")
        Me.lblDatapointsLabel.Name = "lblDatapointsLabel"
        '
        'lblTargetAlt
        '
        resources.ApplyResources(Me.lblTargetAlt, "lblTargetAlt")
        Me.lblTargetAlt.Name = "lblTargetAlt"
        '
        'lblTargetAltLabel
        '
        resources.ApplyResources(Me.lblTargetAltLabel, "lblTargetAltLabel")
        Me.lblTargetAltLabel.Name = "lblTargetAltLabel"
        '
        'lblLongitude
        '
        resources.ApplyResources(Me.lblLongitude, "lblLongitude")
        Me.lblLongitude.Name = "lblLongitude"
        '
        'lblLatitude
        '
        resources.ApplyResources(Me.lblLatitude, "lblLatitude")
        Me.lblLatitude.Name = "lblLatitude"
        '
        'lblLongitudeLabel
        '
        resources.ApplyResources(Me.lblLongitudeLabel, "lblLongitudeLabel")
        Me.lblLongitudeLabel.Name = "lblLongitudeLabel"
        '
        'lblLatitudeLabel
        '
        resources.ApplyResources(Me.lblLatitudeLabel, "lblLatitudeLabel")
        Me.lblLatitudeLabel.Name = "lblLatitudeLabel"
        '
        'lblThrottle
        '
        resources.ApplyResources(Me.lblThrottle, "lblThrottle")
        Me.lblThrottle.Name = "lblThrottle"
        '
        'lblMode
        '
        resources.ApplyResources(Me.lblMode, "lblMode")
        Me.lblMode.Name = "lblMode"
        '
        'lblDistance
        '
        resources.ApplyResources(Me.lblDistance, "lblDistance")
        Me.lblDistance.Name = "lblDistance"
        '
        'lblWaypoint
        '
        resources.ApplyResources(Me.lblWaypoint, "lblWaypoint")
        Me.lblWaypoint.Name = "lblWaypoint"
        '
        'lblHDOP
        '
        resources.ApplyResources(Me.lblHDOP, "lblHDOP")
        Me.lblHDOP.Name = "lblHDOP"
        '
        'lblBattery
        '
        resources.ApplyResources(Me.lblBattery, "lblBattery")
        Me.lblBattery.Name = "lblBattery"
        '
        'lblSatellites
        '
        resources.ApplyResources(Me.lblSatellites, "lblSatellites")
        Me.lblSatellites.Name = "lblSatellites"
        '
        'lblGPSLock
        '
        resources.ApplyResources(Me.lblGPSLock, "lblGPSLock")
        Me.lblGPSLock.Name = "lblGPSLock"
        '
        'lblThrottleLabel
        '
        resources.ApplyResources(Me.lblThrottleLabel, "lblThrottleLabel")
        Me.lblThrottleLabel.Name = "lblThrottleLabel"
        '
        'lblModeLabel
        '
        resources.ApplyResources(Me.lblModeLabel, "lblModeLabel")
        Me.lblModeLabel.Name = "lblModeLabel"
        '
        'lblDistanceLabel
        '
        resources.ApplyResources(Me.lblDistanceLabel, "lblDistanceLabel")
        Me.lblDistanceLabel.Name = "lblDistanceLabel"
        '
        'lblWaypointLabel
        '
        resources.ApplyResources(Me.lblWaypointLabel, "lblWaypointLabel")
        Me.lblWaypointLabel.Name = "lblWaypointLabel"
        '
        'lblHDOPLabel
        '
        resources.ApplyResources(Me.lblHDOPLabel, "lblHDOPLabel")
        Me.lblHDOPLabel.Name = "lblHDOPLabel"
        '
        'lblBatteryLabel
        '
        resources.ApplyResources(Me.lblBatteryLabel, "lblBatteryLabel")
        Me.lblBatteryLabel.Name = "lblBatteryLabel"
        '
        'lblSatellitesLabel
        '
        resources.ApplyResources(Me.lblSatellitesLabel, "lblSatellitesLabel")
        Me.lblSatellitesLabel.Name = "lblSatellitesLabel"
        '
        'lblGPSLockLabel
        '
        resources.ApplyResources(Me.lblGPSLockLabel, "lblGPSLockLabel")
        Me.lblGPSLockLabel.Name = "lblGPSLockLabel"
        '
        'tabPortControl
        '
        Me.tabPortControl.Controls.Add(Me.tabPortComPort)
        Me.tabPortControl.Controls.Add(Me.tabPortDataFile)
        Me.tabPortControl.Controls.Add(Me.tabPortTracking)
        Me.tabPortControl.Controls.Add(Me.tabPortServos)
        Me.tabPortControl.Controls.Add(Me.tabPortSensors)
        resources.ApplyResources(Me.tabPortControl, "tabPortControl")
        Me.tabPortControl.Name = "tabPortControl"
        Me.tabPortControl.SelectedIndex = 0
        '
        'tabPortComPort
        '
        Me.tabPortComPort.Controls.Add(Me.txtSocket)
        Me.tabPortComPort.Controls.Add(Me.cmdTest)
        Me.tabPortComPort.Controls.Add(Me.lblBandwidth)
        Me.tabPortComPort.Controls.Add(Me.lblComPortStatus)
        Me.tabPortComPort.Controls.Add(Me.lblStatusLabel)
        Me.tabPortComPort.Controls.Add(Me.cmdReloadComPorts)
        Me.tabPortComPort.Controls.Add(Me.cboBaudRate)
        Me.tabPortComPort.Controls.Add(Me.lblGPSMessage)
        Me.tabPortComPort.Controls.Add(Me.lblGPSMessageLabel)
        Me.tabPortComPort.Controls.Add(Me.lblGPSType)
        Me.tabPortComPort.Controls.Add(Me.lblGPSTypeLabel)
        Me.tabPortComPort.Controls.Add(Me.lblBaudRate)
        Me.tabPortComPort.Controls.Add(Me.cmdConnect)
        Me.tabPortComPort.Controls.Add(Me.cmdSearch)
        Me.tabPortComPort.Controls.Add(Me.lblComPort)
        Me.tabPortComPort.Controls.Add(Me.cboComPort)
        Me.tabPortComPort.Controls.Add(Me.cmdSearchCOM)
        resources.ApplyResources(Me.tabPortComPort, "tabPortComPort")
        Me.tabPortComPort.Name = "tabPortComPort"
        Me.tabPortComPort.UseVisualStyleBackColor = True
        '
        'txtSocket
        '
        resources.ApplyResources(Me.txtSocket, "txtSocket")
        Me.txtSocket.Name = "txtSocket"
        '
        'cmdTest
        '
        resources.ApplyResources(Me.cmdTest, "cmdTest")
        Me.cmdTest.Name = "cmdTest"
        Me.cmdTest.UseVisualStyleBackColor = True
        '
        'lblBandwidth
        '
        resources.ApplyResources(Me.lblBandwidth, "lblBandwidth")
        Me.lblBandwidth.Name = "lblBandwidth"
        '
        'lblComPortStatus
        '
        resources.ApplyResources(Me.lblComPortStatus, "lblComPortStatus")
        Me.lblComPortStatus.Name = "lblComPortStatus"
        '
        'lblStatusLabel
        '
        resources.ApplyResources(Me.lblStatusLabel, "lblStatusLabel")
        Me.lblStatusLabel.Name = "lblStatusLabel"
        '
        'cboBaudRate
        '
        Me.cboBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBaudRate.FormattingEnabled = True
        resources.ApplyResources(Me.cboBaudRate, "cboBaudRate")
        Me.cboBaudRate.Name = "cboBaudRate"
        '
        'lblGPSMessage
        '
        resources.ApplyResources(Me.lblGPSMessage, "lblGPSMessage")
        Me.lblGPSMessage.Name = "lblGPSMessage"
        '
        'lblGPSMessageLabel
        '
        resources.ApplyResources(Me.lblGPSMessageLabel, "lblGPSMessageLabel")
        Me.lblGPSMessageLabel.Name = "lblGPSMessageLabel"
        '
        'lblGPSType
        '
        resources.ApplyResources(Me.lblGPSType, "lblGPSType")
        Me.lblGPSType.Name = "lblGPSType"
        '
        'lblGPSTypeLabel
        '
        resources.ApplyResources(Me.lblGPSTypeLabel, "lblGPSTypeLabel")
        Me.lblGPSTypeLabel.Name = "lblGPSTypeLabel"
        '
        'lblBaudRate
        '
        resources.ApplyResources(Me.lblBaudRate, "lblBaudRate")
        Me.lblBaudRate.Name = "lblBaudRate"
        '
        'cmdConnect
        '
        resources.ApplyResources(Me.cmdConnect, "cmdConnect")
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        resources.ApplyResources(Me.cmdSearch, "cmdSearch")
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'lblComPort
        '
        resources.ApplyResources(Me.lblComPort, "lblComPort")
        Me.lblComPort.Name = "lblComPort"
        '
        'cboComPort
        '
        Me.cboComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboComPort.FormattingEnabled = True
        resources.ApplyResources(Me.cboComPort, "cboComPort")
        Me.cboComPort.Name = "cboComPort"
        Me.cboComPort.Sorted = True
        '
        'cmdSearchCOM
        '
        resources.ApplyResources(Me.cmdSearchCOM, "cmdSearchCOM")
        Me.cmdSearchCOM.Name = "cmdSearchCOM"
        Me.cmdSearchCOM.UseVisualStyleBackColor = True
        '
        'tabPortDataFile
        '
        Me.tabPortDataFile.Controls.Add(Me.cmdReloadOutputFileList)
        Me.tabPortDataFile.Controls.Add(Me.chkFullDataFile)
        Me.tabPortDataFile.Controls.Add(Me.chkStepForward)
        Me.tabPortDataFile.Controls.Add(Me.chkStepBack)
        Me.tabPortDataFile.Controls.Add(Me.chkReverse)
        Me.tabPortDataFile.Controls.Add(Me.chkPause)
        Me.tabPortDataFile.Controls.Add(Me.chkPlay)
        Me.tabPortDataFile.Controls.Add(Me.cboOutputFiles)
        Me.tabPortDataFile.Controls.Add(Me.TrackBar1)
        Me.tabPortDataFile.Controls.Add(Me.cmdViewFile)
        Me.tabPortDataFile.Controls.Add(Me.cmdOutputFolder)
        Me.tabPortDataFile.Controls.Add(Me.chkRecord)
        Me.tabPortDataFile.Controls.Add(Me.txtOutputFolder)
        resources.ApplyResources(Me.tabPortDataFile, "tabPortDataFile")
        Me.tabPortDataFile.Name = "tabPortDataFile"
        Me.tabPortDataFile.UseVisualStyleBackColor = True
        '
        'cboOutputFiles
        '
        Me.cboOutputFiles.FormattingEnabled = True
        resources.ApplyResources(Me.cboOutputFiles, "cboOutputFiles")
        Me.cboOutputFiles.Name = "cboOutputFiles"
        '
        'TrackBar1
        '
        Me.TrackBar1.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.TrackBar1, "TrackBar1")
        Me.TrackBar1.Maximum = 9
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'cmdViewFile
        '
        resources.ApplyResources(Me.cmdViewFile, "cmdViewFile")
        Me.cmdViewFile.Name = "cmdViewFile"
        Me.cmdViewFile.UseVisualStyleBackColor = True
        '
        'txtOutputFolder
        '
        resources.ApplyResources(Me.txtOutputFolder, "txtOutputFolder")
        Me.txtOutputFolder.Name = "txtOutputFolder"
        '
        'tabPortTracking
        '
        Me.tabPortTracking.Controls.Add(Me.lblTrackerAngle)
        Me.tabPortTracking.Controls.Add(Me.cmdTrackingCalibrate)
        Me.tabPortTracking.Controls.Add(Me.cboTrackingSet)
        Me.tabPortTracking.Controls.Add(Me.tbarTilt)
        Me.tabPortTracking.Controls.Add(Me.tbarPan)
        Me.tabPortTracking.Controls.Add(Me.lblHertzTracking)
        Me.tabPortTracking.Controls.Add(Me.cboHertzTracking)
        Me.tabPortTracking.Controls.Add(Me.cboOutputTypeTracking)
        Me.tabPortTracking.Controls.Add(Me.lblOutputTypeTracking)
        Me.tabPortTracking.Controls.Add(Me.lblStatusTracking)
        Me.tabPortTracking.Controls.Add(Me.lblStatusTrackingStatus)
        Me.tabPortTracking.Controls.Add(Me.cmdReloadTrackingPorts)
        Me.tabPortTracking.Controls.Add(Me.cboBaudRateTracking)
        Me.tabPortTracking.Controls.Add(Me.lblBaudRateTracking)
        Me.tabPortTracking.Controls.Add(Me.cmdConnectTracking)
        Me.tabPortTracking.Controls.Add(Me.lblComPortTracking)
        Me.tabPortTracking.Controls.Add(Me.cboComPortTracking)
        resources.ApplyResources(Me.tabPortTracking, "tabPortTracking")
        Me.tabPortTracking.Name = "tabPortTracking"
        Me.tabPortTracking.UseVisualStyleBackColor = True
        '
        'lblTrackerAngle
        '
        resources.ApplyResources(Me.lblTrackerAngle, "lblTrackerAngle")
        Me.lblTrackerAngle.Name = "lblTrackerAngle"
        '
        'cmdTrackingCalibrate
        '
        resources.ApplyResources(Me.cmdTrackingCalibrate, "cmdTrackingCalibrate")
        Me.cmdTrackingCalibrate.Name = "cmdTrackingCalibrate"
        Me.cmdTrackingCalibrate.UseVisualStyleBackColor = True
        '
        'lblHertzTracking
        '
        resources.ApplyResources(Me.lblHertzTracking, "lblHertzTracking")
        Me.lblHertzTracking.Name = "lblHertzTracking"
        '
        'cboHertzTracking
        '
        Me.cboHertzTracking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHertzTracking.FormattingEnabled = True
        resources.ApplyResources(Me.cboHertzTracking, "cboHertzTracking")
        Me.cboHertzTracking.Name = "cboHertzTracking"
        '
        'cboOutputTypeTracking
        '
        Me.cboOutputTypeTracking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOutputTypeTracking.FormattingEnabled = True
        resources.ApplyResources(Me.cboOutputTypeTracking, "cboOutputTypeTracking")
        Me.cboOutputTypeTracking.Name = "cboOutputTypeTracking"
        '
        'lblOutputTypeTracking
        '
        resources.ApplyResources(Me.lblOutputTypeTracking, "lblOutputTypeTracking")
        Me.lblOutputTypeTracking.Name = "lblOutputTypeTracking"
        '
        'lblStatusTracking
        '
        resources.ApplyResources(Me.lblStatusTracking, "lblStatusTracking")
        Me.lblStatusTracking.Name = "lblStatusTracking"
        '
        'lblStatusTrackingStatus
        '
        resources.ApplyResources(Me.lblStatusTrackingStatus, "lblStatusTrackingStatus")
        Me.lblStatusTrackingStatus.Name = "lblStatusTrackingStatus"
        '
        'cboBaudRateTracking
        '
        Me.cboBaudRateTracking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBaudRateTracking.FormattingEnabled = True
        resources.ApplyResources(Me.cboBaudRateTracking, "cboBaudRateTracking")
        Me.cboBaudRateTracking.Name = "cboBaudRateTracking"
        '
        'lblBaudRateTracking
        '
        resources.ApplyResources(Me.lblBaudRateTracking, "lblBaudRateTracking")
        Me.lblBaudRateTracking.Name = "lblBaudRateTracking"
        '
        'cmdConnectTracking
        '
        resources.ApplyResources(Me.cmdConnectTracking, "cmdConnectTracking")
        Me.cmdConnectTracking.Name = "cmdConnectTracking"
        Me.cmdConnectTracking.UseVisualStyleBackColor = True
        '
        'lblComPortTracking
        '
        resources.ApplyResources(Me.lblComPortTracking, "lblComPortTracking")
        Me.lblComPortTracking.Name = "lblComPortTracking"
        '
        'cboComPortTracking
        '
        Me.cboComPortTracking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboComPortTracking.FormattingEnabled = True
        resources.ApplyResources(Me.cboComPortTracking, "cboComPortTracking")
        Me.cboComPortTracking.Name = "cboComPortTracking"
        Me.cboComPortTracking.Sorted = True
        '
        'tabPortServos
        '
        Me.tabPortServos.Controls.Add(Me.cboServo8)
        Me.tabPortServos.Controls.Add(Me.cboServo7)
        Me.tabPortServos.Controls.Add(Me.cboServo6)
        Me.tabPortServos.Controls.Add(Me.cboServo5)
        Me.tabPortServos.Controls.Add(Me.cboServo4)
        Me.tabPortServos.Controls.Add(Me.cboServo3)
        Me.tabPortServos.Controls.Add(Me.cboServo2)
        Me.tabPortServos.Controls.Add(Me.cboServo1)
        Me.tabPortServos.Controls.Add(Me.lblServo8)
        Me.tabPortServos.Controls.Add(Me.lblServo7)
        Me.tabPortServos.Controls.Add(Me.lblServo6)
        Me.tabPortServos.Controls.Add(Me.lblServo5)
        Me.tabPortServos.Controls.Add(Me.lblServo4)
        Me.tabPortServos.Controls.Add(Me.lblServo3)
        Me.tabPortServos.Controls.Add(Me.lblServo2)
        Me.tabPortServos.Controls.Add(Me.lblServo1)
        Me.tabPortServos.Controls.Add(Me.tbarServo8)
        Me.tabPortServos.Controls.Add(Me.tbarServo7)
        Me.tabPortServos.Controls.Add(Me.tbarServo6)
        Me.tabPortServos.Controls.Add(Me.tbarServo5)
        Me.tabPortServos.Controls.Add(Me.tbarServo4)
        Me.tabPortServos.Controls.Add(Me.tbarServo3)
        Me.tabPortServos.Controls.Add(Me.tbarServo2)
        Me.tabPortServos.Controls.Add(Me.tbarServo1)
        resources.ApplyResources(Me.tabPortServos, "tabPortServos")
        Me.tabPortServos.Name = "tabPortServos"
        Me.tabPortServos.UseVisualStyleBackColor = True
        '
        'cboServo8
        '
        Me.cboServo8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboServo8, "cboServo8")
        Me.cboServo8.FormattingEnabled = True
        Me.cboServo8.Name = "cboServo8"
        '
        'cboServo7
        '
        Me.cboServo7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboServo7, "cboServo7")
        Me.cboServo7.FormattingEnabled = True
        Me.cboServo7.Name = "cboServo7"
        '
        'cboServo6
        '
        Me.cboServo6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboServo6, "cboServo6")
        Me.cboServo6.FormattingEnabled = True
        Me.cboServo6.Name = "cboServo6"
        '
        'cboServo5
        '
        Me.cboServo5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboServo5, "cboServo5")
        Me.cboServo5.FormattingEnabled = True
        Me.cboServo5.Name = "cboServo5"
        '
        'cboServo4
        '
        Me.cboServo4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboServo4, "cboServo4")
        Me.cboServo4.FormattingEnabled = True
        Me.cboServo4.Name = "cboServo4"
        '
        'cboServo3
        '
        Me.cboServo3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboServo3, "cboServo3")
        Me.cboServo3.FormattingEnabled = True
        Me.cboServo3.Name = "cboServo3"
        '
        'cboServo2
        '
        Me.cboServo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboServo2, "cboServo2")
        Me.cboServo2.FormattingEnabled = True
        Me.cboServo2.Name = "cboServo2"
        '
        'cboServo1
        '
        Me.cboServo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboServo1, "cboServo1")
        Me.cboServo1.FormattingEnabled = True
        Me.cboServo1.Name = "cboServo1"
        '
        'lblServo8
        '
        resources.ApplyResources(Me.lblServo8, "lblServo8")
        Me.lblServo8.Name = "lblServo8"
        '
        'lblServo7
        '
        resources.ApplyResources(Me.lblServo7, "lblServo7")
        Me.lblServo7.Name = "lblServo7"
        '
        'lblServo6
        '
        resources.ApplyResources(Me.lblServo6, "lblServo6")
        Me.lblServo6.Name = "lblServo6"
        '
        'lblServo5
        '
        resources.ApplyResources(Me.lblServo5, "lblServo5")
        Me.lblServo5.Name = "lblServo5"
        '
        'lblServo4
        '
        resources.ApplyResources(Me.lblServo4, "lblServo4")
        Me.lblServo4.Name = "lblServo4"
        '
        'lblServo3
        '
        resources.ApplyResources(Me.lblServo3, "lblServo3")
        Me.lblServo3.Name = "lblServo3"
        '
        'lblServo2
        '
        resources.ApplyResources(Me.lblServo2, "lblServo2")
        Me.lblServo2.Name = "lblServo2"
        '
        'lblServo1
        '
        resources.ApplyResources(Me.lblServo1, "lblServo1")
        Me.lblServo1.Name = "lblServo1"
        '
        'tbarServo8
        '
        resources.ApplyResources(Me.tbarServo8, "tbarServo8")
        Me.tbarServo8.BackColor = System.Drawing.Color.White
        Me.tbarServo8.LargeChange = 1
        Me.tbarServo8.Maximum = 2000
        Me.tbarServo8.Minimum = 1000
        Me.tbarServo8.Name = "tbarServo8"
        Me.tbarServo8.TabStop = False
        Me.tbarServo8.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarServo8.Value = 1000
        '
        'tbarServo7
        '
        resources.ApplyResources(Me.tbarServo7, "tbarServo7")
        Me.tbarServo7.BackColor = System.Drawing.Color.White
        Me.tbarServo7.LargeChange = 1
        Me.tbarServo7.Maximum = 2000
        Me.tbarServo7.Minimum = 1000
        Me.tbarServo7.Name = "tbarServo7"
        Me.tbarServo7.TabStop = False
        Me.tbarServo7.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarServo7.Value = 1000
        '
        'tbarServo6
        '
        resources.ApplyResources(Me.tbarServo6, "tbarServo6")
        Me.tbarServo6.BackColor = System.Drawing.Color.White
        Me.tbarServo6.LargeChange = 1
        Me.tbarServo6.Maximum = 2000
        Me.tbarServo6.Minimum = 1000
        Me.tbarServo6.Name = "tbarServo6"
        Me.tbarServo6.TabStop = False
        Me.tbarServo6.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarServo6.Value = 1000
        '
        'tbarServo5
        '
        resources.ApplyResources(Me.tbarServo5, "tbarServo5")
        Me.tbarServo5.BackColor = System.Drawing.Color.White
        Me.tbarServo5.LargeChange = 1
        Me.tbarServo5.Maximum = 2000
        Me.tbarServo5.Minimum = 1000
        Me.tbarServo5.Name = "tbarServo5"
        Me.tbarServo5.TabStop = False
        Me.tbarServo5.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarServo5.Value = 1000
        '
        'tbarServo4
        '
        resources.ApplyResources(Me.tbarServo4, "tbarServo4")
        Me.tbarServo4.BackColor = System.Drawing.Color.White
        Me.tbarServo4.LargeChange = 1
        Me.tbarServo4.Maximum = 2000
        Me.tbarServo4.Minimum = 1000
        Me.tbarServo4.Name = "tbarServo4"
        Me.tbarServo4.TabStop = False
        Me.tbarServo4.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarServo4.Value = 1000
        '
        'tbarServo3
        '
        resources.ApplyResources(Me.tbarServo3, "tbarServo3")
        Me.tbarServo3.BackColor = System.Drawing.Color.White
        Me.tbarServo3.LargeChange = 1
        Me.tbarServo3.Maximum = 2000
        Me.tbarServo3.Minimum = 1000
        Me.tbarServo3.Name = "tbarServo3"
        Me.tbarServo3.TabStop = False
        Me.tbarServo3.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarServo3.Value = 1000
        '
        'tbarServo2
        '
        resources.ApplyResources(Me.tbarServo2, "tbarServo2")
        Me.tbarServo2.BackColor = System.Drawing.Color.White
        Me.tbarServo2.LargeChange = 1
        Me.tbarServo2.Maximum = 2000
        Me.tbarServo2.Minimum = 1000
        Me.tbarServo2.Name = "tbarServo2"
        Me.tbarServo2.TabStop = False
        Me.tbarServo2.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarServo2.Value = 1000
        '
        'tbarServo1
        '
        resources.ApplyResources(Me.tbarServo1, "tbarServo1")
        Me.tbarServo1.BackColor = System.Drawing.Color.White
        Me.tbarServo1.LargeChange = 1
        Me.tbarServo1.Maximum = 2000
        Me.tbarServo1.Minimum = 1000
        Me.tbarServo1.Name = "tbarServo1"
        Me.tbarServo1.TabStop = False
        Me.tbarServo1.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarServo1.Value = 1000
        '
        'tabPortSensors
        '
        Me.tabPortSensors.Controls.Add(Me.cboSensors8)
        Me.tabPortSensors.Controls.Add(Me.cboSensors7)
        Me.tabPortSensors.Controls.Add(Me.cboSensors6)
        Me.tabPortSensors.Controls.Add(Me.cboSensors5)
        Me.tabPortSensors.Controls.Add(Me.cboSensors4)
        Me.tabPortSensors.Controls.Add(Me.cboSensors3)
        Me.tabPortSensors.Controls.Add(Me.cboSensors2)
        Me.tabPortSensors.Controls.Add(Me.cboSensors1)
        Me.tabPortSensors.Controls.Add(Me.lblSensor8)
        Me.tabPortSensors.Controls.Add(Me.lblSensor7)
        Me.tabPortSensors.Controls.Add(Me.lblSensor6)
        Me.tabPortSensors.Controls.Add(Me.lblSensor5)
        Me.tabPortSensors.Controls.Add(Me.lblSensor4)
        Me.tabPortSensors.Controls.Add(Me.lblSensor3)
        Me.tabPortSensors.Controls.Add(Me.lblSensor2)
        Me.tabPortSensors.Controls.Add(Me.lblSensor1)
        Me.tabPortSensors.Controls.Add(Me.tbarSensor8)
        Me.tabPortSensors.Controls.Add(Me.tbarSensor7)
        Me.tabPortSensors.Controls.Add(Me.tbarSensor6)
        Me.tabPortSensors.Controls.Add(Me.tbarSensor5)
        Me.tabPortSensors.Controls.Add(Me.tbarSensor4)
        Me.tabPortSensors.Controls.Add(Me.tbarSensor3)
        Me.tabPortSensors.Controls.Add(Me.tbarSensor2)
        Me.tabPortSensors.Controls.Add(Me.tbarSensor1)
        resources.ApplyResources(Me.tabPortSensors, "tabPortSensors")
        Me.tabPortSensors.Name = "tabPortSensors"
        Me.tabPortSensors.UseVisualStyleBackColor = True
        '
        'cboSensors8
        '
        Me.cboSensors8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboSensors8, "cboSensors8")
        Me.cboSensors8.FormattingEnabled = True
        Me.cboSensors8.Name = "cboSensors8"
        '
        'cboSensors7
        '
        Me.cboSensors7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboSensors7, "cboSensors7")
        Me.cboSensors7.FormattingEnabled = True
        Me.cboSensors7.Name = "cboSensors7"
        '
        'cboSensors6
        '
        Me.cboSensors6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboSensors6, "cboSensors6")
        Me.cboSensors6.FormattingEnabled = True
        Me.cboSensors6.Name = "cboSensors6"
        '
        'cboSensors5
        '
        Me.cboSensors5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboSensors5, "cboSensors5")
        Me.cboSensors5.FormattingEnabled = True
        Me.cboSensors5.Name = "cboSensors5"
        '
        'cboSensors4
        '
        Me.cboSensors4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboSensors4, "cboSensors4")
        Me.cboSensors4.FormattingEnabled = True
        Me.cboSensors4.Name = "cboSensors4"
        '
        'cboSensors3
        '
        Me.cboSensors3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboSensors3, "cboSensors3")
        Me.cboSensors3.FormattingEnabled = True
        Me.cboSensors3.Name = "cboSensors3"
        '
        'cboSensors2
        '
        Me.cboSensors2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboSensors2, "cboSensors2")
        Me.cboSensors2.FormattingEnabled = True
        Me.cboSensors2.Name = "cboSensors2"
        '
        'cboSensors1
        '
        Me.cboSensors1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboSensors1, "cboSensors1")
        Me.cboSensors1.FormattingEnabled = True
        Me.cboSensors1.Name = "cboSensors1"
        '
        'lblSensor8
        '
        resources.ApplyResources(Me.lblSensor8, "lblSensor8")
        Me.lblSensor8.Name = "lblSensor8"
        '
        'lblSensor7
        '
        resources.ApplyResources(Me.lblSensor7, "lblSensor7")
        Me.lblSensor7.Name = "lblSensor7"
        '
        'lblSensor6
        '
        resources.ApplyResources(Me.lblSensor6, "lblSensor6")
        Me.lblSensor6.Name = "lblSensor6"
        '
        'lblSensor5
        '
        resources.ApplyResources(Me.lblSensor5, "lblSensor5")
        Me.lblSensor5.Name = "lblSensor5"
        '
        'lblSensor4
        '
        resources.ApplyResources(Me.lblSensor4, "lblSensor4")
        Me.lblSensor4.Name = "lblSensor4"
        '
        'lblSensor3
        '
        resources.ApplyResources(Me.lblSensor3, "lblSensor3")
        Me.lblSensor3.Name = "lblSensor3"
        '
        'lblSensor2
        '
        resources.ApplyResources(Me.lblSensor2, "lblSensor2")
        Me.lblSensor2.Name = "lblSensor2"
        '
        'lblSensor1
        '
        resources.ApplyResources(Me.lblSensor1, "lblSensor1")
        Me.lblSensor1.Name = "lblSensor1"
        '
        'tbarSensor8
        '
        resources.ApplyResources(Me.tbarSensor8, "tbarSensor8")
        Me.tbarSensor8.BackColor = System.Drawing.Color.White
        Me.tbarSensor8.LargeChange = 1
        Me.tbarSensor8.Maximum = 100
        Me.tbarSensor8.Minimum = -100
        Me.tbarSensor8.Name = "tbarSensor8"
        Me.tbarSensor8.TabStop = False
        Me.tbarSensor8.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbarSensor7
        '
        resources.ApplyResources(Me.tbarSensor7, "tbarSensor7")
        Me.tbarSensor7.BackColor = System.Drawing.Color.White
        Me.tbarSensor7.LargeChange = 1
        Me.tbarSensor7.Maximum = 100
        Me.tbarSensor7.Minimum = -100
        Me.tbarSensor7.Name = "tbarSensor7"
        Me.tbarSensor7.TabStop = False
        Me.tbarSensor7.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbarSensor6
        '
        resources.ApplyResources(Me.tbarSensor6, "tbarSensor6")
        Me.tbarSensor6.BackColor = System.Drawing.Color.White
        Me.tbarSensor6.LargeChange = 1
        Me.tbarSensor6.Maximum = 100
        Me.tbarSensor6.Minimum = -100
        Me.tbarSensor6.Name = "tbarSensor6"
        Me.tbarSensor6.TabStop = False
        Me.tbarSensor6.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbarSensor5
        '
        resources.ApplyResources(Me.tbarSensor5, "tbarSensor5")
        Me.tbarSensor5.BackColor = System.Drawing.Color.White
        Me.tbarSensor5.LargeChange = 1
        Me.tbarSensor5.Maximum = 100
        Me.tbarSensor5.Minimum = -100
        Me.tbarSensor5.Name = "tbarSensor5"
        Me.tbarSensor5.TabStop = False
        Me.tbarSensor5.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbarSensor4
        '
        resources.ApplyResources(Me.tbarSensor4, "tbarSensor4")
        Me.tbarSensor4.BackColor = System.Drawing.Color.White
        Me.tbarSensor4.LargeChange = 1
        Me.tbarSensor4.Maximum = 100
        Me.tbarSensor4.Minimum = -100
        Me.tbarSensor4.Name = "tbarSensor4"
        Me.tbarSensor4.TabStop = False
        Me.tbarSensor4.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbarSensor3
        '
        resources.ApplyResources(Me.tbarSensor3, "tbarSensor3")
        Me.tbarSensor3.BackColor = System.Drawing.Color.White
        Me.tbarSensor3.LargeChange = 1
        Me.tbarSensor3.Maximum = 100
        Me.tbarSensor3.Minimum = -100
        Me.tbarSensor3.Name = "tbarSensor3"
        Me.tbarSensor3.TabStop = False
        Me.tbarSensor3.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbarSensor2
        '
        resources.ApplyResources(Me.tbarSensor2, "tbarSensor2")
        Me.tbarSensor2.BackColor = System.Drawing.Color.White
        Me.tbarSensor2.LargeChange = 1
        Me.tbarSensor2.Maximum = 100
        Me.tbarSensor2.Minimum = -100
        Me.tbarSensor2.Name = "tbarSensor2"
        Me.tbarSensor2.TabStop = False
        Me.tbarSensor2.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbarSensor1
        '
        resources.ApplyResources(Me.tbarSensor1, "tbarSensor1")
        Me.tbarSensor1.BackColor = System.Drawing.Color.White
        Me.tbarSensor1.LargeChange = 1
        Me.tbarSensor1.Maximum = 100
        Me.tbarSensor1.Minimum = -100
        Me.tbarSensor1.Name = "tbarSensor1"
        Me.tbarSensor1.TabStop = False
        Me.tbarSensor1.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'JoystickInstrumentControl1
        '
        Me.JoystickInstrumentControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(241, Byte), Integer))
        resources.ApplyResources(Me.JoystickInstrumentControl1, "JoystickInstrumentControl1")
        Me.JoystickInstrumentControl1.Name = "JoystickInstrumentControl1"
        '
        'cmdExit
        '
        resources.ApplyResources(Me.cmdExit, "cmdExit")
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdSetHome
        '
        resources.ApplyResources(Me.cmdSetHome, "cmdSetHome")
        Me.cmdSetHome.Name = "cmdSetHome"
        Me.cmdSetHome.UseVisualStyleBackColor = True
        '
        'cmdClearMap
        '
        resources.ApplyResources(Me.cmdClearMap, "cmdClearMap")
        Me.cmdClearMap.Name = "cmdClearMap"
        Me.cmdClearMap.UseVisualStyleBackColor = True
        '
        'cmdCenterOnPlane
        '
        resources.ApplyResources(Me.cmdCenterOnPlane, "cmdCenterOnPlane")
        Me.cmdCenterOnPlane.Name = "cmdCenterOnPlane"
        Me.cmdCenterOnPlane.UseVisualStyleBackColor = True
        '
        'tabMapView
        '
        Me.tabMapView.Controls.Add(Me.tabViewMapView)
        Me.tabMapView.Controls.Add(Me.tabViewLiveCamera)
        resources.ApplyResources(Me.tabMapView, "tabMapView")
        Me.tabMapView.Name = "tabMapView"
        Me.tabMapView.SelectedIndex = 0
        '
        'tabViewMapView
        '
        Me.tabViewMapView.Controls.Add(Me.tbarModelScale)
        Me.tabViewMapView.Controls.Add(Me.chkViewFirstPerson)
        Me.tabViewMapView.Controls.Add(Me.chkViewChaseCam)
        Me.tabViewMapView.Controls.Add(Me.chkViewOverhead)
        Me.tabViewMapView.Controls.Add(Me.chkViewNoTracking)
        Me.tabViewMapView.Controls.Add(Me.WebBrowser1)
        resources.ApplyResources(Me.tabViewMapView, "tabViewMapView")
        Me.tabViewMapView.Name = "tabViewMapView"
        Me.tabViewMapView.UseVisualStyleBackColor = True
        '
        'chkViewFirstPerson
        '
        resources.ApplyResources(Me.chkViewFirstPerson, "chkViewFirstPerson")
        Me.chkViewFirstPerson.Name = "chkViewFirstPerson"
        Me.chkViewFirstPerson.UseVisualStyleBackColor = True
        '
        'chkViewChaseCam
        '
        resources.ApplyResources(Me.chkViewChaseCam, "chkViewChaseCam")
        Me.chkViewChaseCam.Name = "chkViewChaseCam"
        Me.chkViewChaseCam.UseVisualStyleBackColor = True
        '
        'chkViewOverhead
        '
        resources.ApplyResources(Me.chkViewOverhead, "chkViewOverhead")
        Me.chkViewOverhead.Name = "chkViewOverhead"
        Me.chkViewOverhead.UseVisualStyleBackColor = True
        '
        'chkViewNoTracking
        '
        resources.ApplyResources(Me.chkViewNoTracking, "chkViewNoTracking")
        Me.chkViewNoTracking.Checked = True
        Me.chkViewNoTracking.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkViewNoTracking.Name = "chkViewNoTracking"
        Me.chkViewNoTracking.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        resources.ApplyResources(Me.WebBrowser1, "WebBrowser1")
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScrollBarsEnabled = False
        '
        'tabViewLiveCamera
        '
        Me.tabViewLiveCamera.Controls.Add(Me.cmdLiveCameraProperties1)
        Me.tabViewLiveCamera.Controls.Add(Me.cboLiveCameraSelect1)
        Me.tabViewLiveCamera.Controls.Add(Me.DirectShowControl1)
        resources.ApplyResources(Me.tabViewLiveCamera, "tabViewLiveCamera")
        Me.tabViewLiveCamera.Name = "tabViewLiveCamera"
        Me.tabViewLiveCamera.UseVisualStyleBackColor = True
        '
        'cmdLiveCameraProperties1
        '
        resources.ApplyResources(Me.cmdLiveCameraProperties1, "cmdLiveCameraProperties1")
        Me.cmdLiveCameraProperties1.Name = "cmdLiveCameraProperties1"
        Me.cmdLiveCameraProperties1.UseVisualStyleBackColor = True
        '
        'cboLiveCameraSelect1
        '
        Me.cboLiveCameraSelect1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLiveCameraSelect1.FormattingEnabled = True
        resources.ApplyResources(Me.cboLiveCameraSelect1, "cboLiveCameraSelect1")
        Me.cboLiveCameraSelect1.Name = "cboLiveCameraSelect1"
        '
        'DirectShowControl1
        '
        resources.ApplyResources(Me.DirectShowControl1, "DirectShowControl1")
        Me.DirectShowControl1.Name = "DirectShowControl1"
        '
        'tmrTracking
        '
        '
        'serialPortTracking
        '
        Me.serialPortTracking.DtrEnable = True
        Me.serialPortTracking.ReceivedBytesThreshold = 4096
        Me.serialPortTracking.RtsEnable = True
        Me.serialPortTracking.WriteTimeout = 25
        '
        'frmMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.KeyPreview = True
        Me.Name = "frmMain"
        CType(Me.tbarModelScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarTilt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarPan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.tabInstrumentView.ResumeLayout(False)
        Me.tabInstruments.ResumeLayout(False)
        Me.tabSerialData.ResumeLayout(False)
        Me.tabSerialData.PerformLayout()
        Me.grpSerialSettings.ResumeLayout(False)
        Me.grpSerialSettings.PerformLayout()
        Me.tabCommandLine.ResumeLayout(False)
        Me.tabCommandLine.PerformLayout()
        Me.tabInstrumentLiveCamera.ResumeLayout(False)
        Me.tabMissionControl.ResumeLayout(False)
        Me.tabMissionControl.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAtto.ResumeLayout(False)
        CType(Me.dgStringResources, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGPSTime.ResumeLayout(False)
        Me.grpMisc.ResumeLayout(False)
        Me.tabPortControl.ResumeLayout(False)
        Me.tabPortComPort.ResumeLayout(False)
        Me.tabPortComPort.PerformLayout()
        Me.tabPortDataFile.ResumeLayout(False)
        Me.tabPortDataFile.PerformLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPortTracking.ResumeLayout(False)
        Me.tabPortServos.ResumeLayout(False)
        CType(Me.tbarServo8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarServo7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarServo6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarServo5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarServo4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarServo3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarServo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarServo1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPortSensors.ResumeLayout(False)
        CType(Me.tbarSensor8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarSensor7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarSensor6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarSensor5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarSensor4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarSensor3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarSensor2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarSensor1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMapView.ResumeLayout(False)
        Me.tabViewMapView.ResumeLayout(False)
        Me.tabViewLiveCamera.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tabInstrumentView As System.Windows.Forms.TabControl
    Friend WithEvents tabInstruments As System.Windows.Forms.TabPage
    Friend WithEvents _3DMesh1 As HK_GCS._3DMesh
    Friend WithEvents VerticalSpeedIndicatorInstrumentControl1 As HK_GCS.AvionicsInstrumentControlDemo.VerticalSpeedIndicatorInstrumentControl
    Friend WithEvents HeadingIndicatorInstrumentControl1 As HK_GCS.AvionicsInstrumentControlDemo.HeadingIndicatorInstrumentControl
    Friend WithEvents AttitudeIndicatorInstrumentControl1 As HK_GCS.AvionicsInstrumentControlDemo.AttitudeIndicatorInstrumentControl
    Friend WithEvents AltimeterInstrumentControl1 As HK_GCS.AvionicsInstrumentControlDemo.AltimeterInstrumentControl
    Friend WithEvents AirSpeedIndicatorInstrumentControl1 As HK_GCS.AvionicsInstrumentControlDemo.AirSpeedIndicatorInstrumentControl
    Friend WithEvents tabSerialData As System.Windows.Forms.TabPage
    Friend WithEvents grpSerialSettings As System.Windows.Forms.GroupBox
    Friend WithEvents cboWaypoint As System.Windows.Forms.ComboBox
    Friend WithEvents cboGPS As System.Windows.Forms.ComboBox
    Friend WithEvents cboAttitude As System.Windows.Forms.ComboBox
    Friend WithEvents lblMaxWaypoint As System.Windows.Forms.Label
    Friend WithEvents lblMaxGPS As System.Windows.Forms.Label
    Friend WithEvents lblMaxAttitude As System.Windows.Forms.Label
    Friend WithEvents lblTranslatedData As System.Windows.Forms.Label
    Friend WithEvents lblRawData As System.Windows.Forms.Label
    Friend WithEvents lstEvents As System.Windows.Forms.ListBox
    Friend WithEvents lstInbound As System.Windows.Forms.ListBox
    Friend WithEvents tabCommandLine As System.Windows.Forms.TabPage
    Friend WithEvents cmdCommandLineSend As System.Windows.Forms.Button
    Friend WithEvents cboCommandLineCommand As System.Windows.Forms.ComboBox
    Friend WithEvents chkCommandLineAutoScroll As System.Windows.Forms.CheckBox
    Friend WithEvents cboCommandLineDelim As System.Windows.Forms.ComboBox
    Friend WithEvents lstCommandLineOutput As System.Windows.Forms.ListBox
    Friend WithEvents tabInstrumentLiveCamera As System.Windows.Forms.TabPage
    Friend WithEvents DirectShowControl2 As HK_GCS.DirectShowControl.DirectShowControl
    Friend WithEvents cmdExpandInstruments As System.Windows.Forms.Button
    Friend WithEvents grpMisc As System.Windows.Forms.GroupBox
    Friend WithEvents cmdResetRuntime As System.Windows.Forms.Button
    Friend WithEvents lblRunTime As System.Windows.Forms.Label
    Friend WithEvents lblRunTimeLabel As System.Windows.Forms.Label
    Friend WithEvents lblDataPoints As System.Windows.Forms.Label
    Friend WithEvents lblDatapointsLabel As System.Windows.Forms.Label
    Friend WithEvents lblTargetAlt As System.Windows.Forms.Label
    Friend WithEvents lblTargetAltLabel As System.Windows.Forms.Label
    Friend WithEvents lblLongitude As System.Windows.Forms.Label
    Friend WithEvents lblLatitude As System.Windows.Forms.Label
    Friend WithEvents lblLongitudeLabel As System.Windows.Forms.Label
    Friend WithEvents lblLatitudeLabel As System.Windows.Forms.Label
    Friend WithEvents lblThrottle As System.Windows.Forms.Label
    Friend WithEvents lblMode As System.Windows.Forms.Label
    Friend WithEvents lblDistance As System.Windows.Forms.Label
    Friend WithEvents lblWaypoint As System.Windows.Forms.Label
    Friend WithEvents lblHDOP As System.Windows.Forms.Label
    Friend WithEvents lblBattery As System.Windows.Forms.Label
    Friend WithEvents lblSatellites As System.Windows.Forms.Label
    Friend WithEvents lblGPSLock As System.Windows.Forms.Label
    Friend WithEvents lblThrottleLabel As System.Windows.Forms.Label
    Friend WithEvents lblModeLabel As System.Windows.Forms.Label
    Friend WithEvents lblDistanceLabel As System.Windows.Forms.Label
    Friend WithEvents lblWaypointLabel As System.Windows.Forms.Label
    Friend WithEvents lblHDOPLabel As System.Windows.Forms.Label
    Friend WithEvents lblBatteryLabel As System.Windows.Forms.Label
    Friend WithEvents lblSatellitesLabel As System.Windows.Forms.Label
    Friend WithEvents lblGPSLockLabel As System.Windows.Forms.Label
    Friend WithEvents tabPortControl As System.Windows.Forms.TabControl
    Friend WithEvents tabPortComPort As System.Windows.Forms.TabPage
    Friend WithEvents lblBandwidth As System.Windows.Forms.Label
    Friend WithEvents lblComPortStatus As System.Windows.Forms.Label
    Friend WithEvents lblStatusLabel As System.Windows.Forms.Label
    Friend WithEvents cmdReloadComPorts As System.Windows.Forms.Button
    Friend WithEvents cboBaudRate As System.Windows.Forms.ComboBox
    Friend WithEvents lblGPSMessage As System.Windows.Forms.Label
    Friend WithEvents lblGPSMessageLabel As System.Windows.Forms.Label
    Friend WithEvents lblGPSType As System.Windows.Forms.Label
    Friend WithEvents lblGPSTypeLabel As System.Windows.Forms.Label
    Friend WithEvents lblBaudRate As System.Windows.Forms.Label
    Friend WithEvents cmdSearchCOM As System.Windows.Forms.Button
    Friend WithEvents cmdConnect As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents lblComPort As System.Windows.Forms.Label
    Friend WithEvents cboComPort As System.Windows.Forms.ComboBox
    Friend WithEvents tabPortDataFile As System.Windows.Forms.TabPage
    Friend WithEvents chkStepForward As System.Windows.Forms.CheckBox
    Friend WithEvents chkStepBack As System.Windows.Forms.CheckBox
    Friend WithEvents chkReverse As System.Windows.Forms.CheckBox
    Friend WithEvents chkPause As System.Windows.Forms.CheckBox
    Friend WithEvents chkPlay As System.Windows.Forms.CheckBox
    Friend WithEvents cboOutputFiles As System.Windows.Forms.ComboBox
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents cmdViewFile As System.Windows.Forms.Button
    Friend WithEvents cmdOutputFolder As System.Windows.Forms.Button
    Friend WithEvents chkRecord As System.Windows.Forms.CheckBox
    Friend WithEvents txtOutputFolder As System.Windows.Forms.TextBox
    Friend WithEvents tabPortTracking As System.Windows.Forms.TabPage
    Friend WithEvents cmdSetHome As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdClearMap As System.Windows.Forms.Button
    Friend WithEvents cmdCenterOnPlane As System.Windows.Forms.Button
    Friend WithEvents tabMapView As System.Windows.Forms.TabControl
    Friend WithEvents tabViewMapView As System.Windows.Forms.TabPage
    Friend WithEvents tbarModelScale As System.Windows.Forms.TrackBar
    Friend WithEvents chkViewFirstPerson As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewChaseCam As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewOverhead As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewNoTracking As System.Windows.Forms.CheckBox
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents tabViewLiveCamera As System.Windows.Forms.TabPage
    Friend WithEvents DirectShowControl1 As HK_GCS.DirectShowControl.DirectShowControl
    Friend WithEvents tmrSearch As System.Windows.Forms.Timer
    Friend WithEvents tmrPlayback As System.Windows.Forms.Timer
    Friend WithEvents serialPortIn As System.IO.Ports.SerialPort
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdLiveCameraProperties2 As System.Windows.Forms.Button
    Friend WithEvents cboLiveCameraSelect2 As System.Windows.Forms.ComboBox
    Friend WithEvents chkFullDataFile As System.Windows.Forms.CheckBox
    Friend WithEvents cmdReloadOutputFileList As System.Windows.Forms.Button
    Friend WithEvents tabPortServos As System.Windows.Forms.TabPage
    Friend WithEvents tbarServo8 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarServo7 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarServo6 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarServo5 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarServo4 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarServo3 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarServo2 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarServo1 As System.Windows.Forms.TrackBar
    Friend WithEvents lblServo8 As System.Windows.Forms.Label
    Friend WithEvents lblServo7 As System.Windows.Forms.Label
    Friend WithEvents lblServo6 As System.Windows.Forms.Label
    Friend WithEvents lblServo5 As System.Windows.Forms.Label
    Friend WithEvents lblServo4 As System.Windows.Forms.Label
    Friend WithEvents lblServo3 As System.Windows.Forms.Label
    Friend WithEvents lblServo2 As System.Windows.Forms.Label
    Friend WithEvents lblServo1 As System.Windows.Forms.Label
    Friend WithEvents tmrComPort As System.Windows.Forms.Timer
    Friend WithEvents cmdLiveCameraProperties1 As System.Windows.Forms.Button
    Friend WithEvents cboLiveCameraSelect1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboServo1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboServo8 As System.Windows.Forms.ComboBox
    Friend WithEvents cboServo7 As System.Windows.Forms.ComboBox
    Friend WithEvents cboServo6 As System.Windows.Forms.ComboBox
    Friend WithEvents cboServo5 As System.Windows.Forms.ComboBox
    Friend WithEvents cboServo4 As System.Windows.Forms.ComboBox
    Friend WithEvents cboServo3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboServo2 As System.Windows.Forms.ComboBox
    Friend WithEvents tabPortSensors As System.Windows.Forms.TabPage
    Friend WithEvents cboSensors8 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSensors7 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSensors6 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSensors5 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSensors4 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSensors3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSensors2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSensors1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblSensor8 As System.Windows.Forms.Label
    Friend WithEvents lblSensor7 As System.Windows.Forms.Label
    Friend WithEvents lblSensor6 As System.Windows.Forms.Label
    Friend WithEvents lblSensor5 As System.Windows.Forms.Label
    Friend WithEvents lblSensor4 As System.Windows.Forms.Label
    Friend WithEvents lblSensor3 As System.Windows.Forms.Label
    Friend WithEvents lblSensor2 As System.Windows.Forms.Label
    Friend WithEvents lblSensor1 As System.Windows.Forms.Label
    Friend WithEvents tbarSensor8 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarSensor7 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarSensor6 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarSensor5 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarSensor4 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarSensor3 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarSensor2 As System.Windows.Forms.TrackBar
    Friend WithEvents tbarSensor1 As System.Windows.Forms.TrackBar
    Friend WithEvents cmdTest As System.Windows.Forms.Button
    Friend WithEvents lblAmperage As System.Windows.Forms.Label
    Friend WithEvents lblAmpsLabel As System.Windows.Forms.Label
    Friend WithEvents TurnCoordinatorInstrumentControl1 As HK_GCS.AvionicsInstrumentControlDemo.TurnCoordinatorInstrumentControl
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuOpenHomepage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOpenDownloads As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BatteryIndicatorInstrumentControl1 As HK_GCS.AvionicsInstrumentControlDemo.BatteryIndicatorInstrumentControl
    Friend WithEvents grpGPSTime As System.Windows.Forms.GroupBox
    Friend WithEvents lblGPSTime As System.Windows.Forms.Label
    Friend WithEvents txtSocket As System.Windows.Forms.TextBox
    Friend WithEvents JoystickInstrumentControl1 As HK_GCS.AvionicsInstrumentControlDemo.JoystickInstrumentControl
    Friend WithEvents tabAtto As System.Windows.Forms.TabPage
    Friend WithEvents dgStringResources As System.Windows.Forms.DataGridView
    Friend WithEvents tabMissionControl As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdReloadMissionDirectory As System.Windows.Forms.Button
    Friend WithEvents cmdReloadMissions As System.Windows.Forms.Button
    Friend WithEvents lblMissionLabel As System.Windows.Forms.Label
    Friend WithEvents cboMission As System.Windows.Forms.ComboBox
    Friend WithEvents cboOutputTypeTracking As System.Windows.Forms.ComboBox
    Friend WithEvents lblOutputTypeTracking As System.Windows.Forms.Label
    Friend WithEvents lblStatusTracking As System.Windows.Forms.Label
    Friend WithEvents lblStatusTrackingStatus As System.Windows.Forms.Label
    Friend WithEvents cmdReloadTrackingPorts As System.Windows.Forms.Button
    Friend WithEvents cboBaudRateTracking As System.Windows.Forms.ComboBox
    Friend WithEvents lblBaudRateTracking As System.Windows.Forms.Label
    Friend WithEvents cmdConnectTracking As System.Windows.Forms.Button
    Friend WithEvents lblComPortTracking As System.Windows.Forms.Label
    Friend WithEvents cboComPortTracking As System.Windows.Forms.ComboBox
    Friend WithEvents tmrTracking As System.Windows.Forms.Timer
    Friend WithEvents lblHertzTracking As System.Windows.Forms.Label
    Friend WithEvents cboHertzTracking As System.Windows.Forms.ComboBox
    Friend WithEvents serialPortTracking As System.IO.Ports.SerialPort
    Friend WithEvents tbarTilt As System.Windows.Forms.TrackBar
    Friend WithEvents tbarPan As System.Windows.Forms.TrackBar
    Friend WithEvents cmdZeroYaw As System.Windows.Forms.Button
    Friend WithEvents cboTrackingSet As System.Windows.Forms.ComboBox
    Friend WithEvents cmdTrackingCalibrate As System.Windows.Forms.Button
    Friend WithEvents lblTrackerAngle As System.Windows.Forms.Label
End Class
