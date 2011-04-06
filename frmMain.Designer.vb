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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
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
        Me.cmdReloadTrackingPorts = New System.Windows.Forms.Button
        Me.tbarTilt = New System.Windows.Forms.TrackBar
        Me.tbarPan = New System.Windows.Forms.TrackBar
        Me.cboTrackingSet = New System.Windows.Forms.ComboBox
        Me.cmdReloadMissionDirectory = New System.Windows.Forms.Button
        Me.cmdReloadMissions = New System.Windows.Forms.Button
        Me.cmdMissionOverride = New System.Windows.Forms.Button
        Me.cmdSetHomeAlt = New System.Windows.Forms.Button
        Me.cmdMissionAttoAdd = New System.Windows.Forms.Button
        Me.cmdMissionMavlinkAdd = New System.Windows.Forms.Button
        Me.tmrComPort = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.mnuFile = New System.Windows.Forms.ToolStripDropDownButton
        Me.mnuSettings = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuJoystickCalibration = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHelp = New System.Windows.Forms.ToolStripDropDownButton
        Me.mnuOpenHomepage = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuOpenDownloads = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.tabInstrumentView = New System.Windows.Forms.TabControl
        Me.tabInstruments = New System.Windows.Forms.TabPage
        Me.cmdZeroYaw = New System.Windows.Forms.Button
        Me.BatteryIndicatorInstrumentControl1 = New HK_GCS.AvionicsInstrumentControlDemo.BatteryIndicatorInstrumentControl
        Me.TurnCoordinatorInstrumentControl1 = New HK_GCS.AvionicsInstrumentControlDemo.TurnCoordinatorInstrumentControl
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
        Me.tabMissionPlanning = New System.Windows.Forms.TabPage
        Me.grpMissionControlMavlink = New System.Windows.Forms.GroupBox
        Me.txtMissionAddressSearchMavlink = New System.Windows.Forms.TextBox
        Me.cboMissionMavlinkArg4 = New System.Windows.Forms.ComboBox
        Me.cboMissionMavlinkArg3 = New System.Windows.Forms.ComboBox
        Me.cboMissionMavlinkArg2 = New System.Windows.Forms.ComboBox
        Me.cboMissionMavlinkArg1 = New System.Windows.Forms.ComboBox
        Me.txtMissionMavlinkArg7 = New System.Windows.Forms.TextBox
        Me.txtMissionMavlinkArg6 = New System.Windows.Forms.TextBox
        Me.txtMissionMavlinkArg5 = New System.Windows.Forms.TextBox
        Me.lblMissionMavlinkArg5 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.cboMissionMavlinkCommand = New System.Windows.Forms.ComboBox
        Me.lblMissionStatusMavlink = New System.Windows.Forms.Label
        Me.prgMissionMavlink = New System.Windows.Forms.ProgressBar
        Me.cmdMissionMavlinkWrite = New System.Windows.Forms.Button
        Me.cmdMissionMavlinkRead = New System.Windows.Forms.Button
        Me.txtMissionMavlinkArg1 = New System.Windows.Forms.TextBox
        Me.lblMissionMavlinkArg1 = New System.Windows.Forms.Label
        Me.cmdMissionMavlinkSearch = New System.Windows.Forms.Button
        Me.lblMissionAddressSearchMavlink = New System.Windows.Forms.Label
        Me.txtMissionMavlinkArg2 = New System.Windows.Forms.TextBox
        Me.lblMissionMavlinkArg2 = New System.Windows.Forms.Label
        Me.txtMissionMavlinkArg4 = New System.Windows.Forms.TextBox
        Me.lblMissionMavlinkArg4 = New System.Windows.Forms.Label
        Me.txtMissionMavlinkArg3 = New System.Windows.Forms.TextBox
        Me.lblMissionMavlinkArg3 = New System.Windows.Forms.Label
        Me.lblMissionMavlinkArg6 = New System.Windows.Forms.Label
        Me.lblMissionMavlinkArg7 = New System.Windows.Forms.Label
        Me.grpMissionControlAtto = New System.Windows.Forms.GroupBox
        Me.txtMissionAttoDefaultSpeed = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboMissionAttoReversePath = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboMissionAttoAltitudeControl = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboMissionAttoTriggerControl = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboMissionAttoLoiterDirection = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboMissionAttoLoiterDuration = New System.Windows.Forms.ComboBox
        Me.lblMissionStatusAtto = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.prgMissionAtto = New System.Windows.Forms.ProgressBar
        Me.cboMissionAttoLoiter = New System.Windows.Forms.ComboBox
        Me.cmdMissionAttoWrite = New System.Windows.Forms.Button
        Me.cmdMissionAttoRead = New System.Windows.Forms.Button
        Me.txtMissionAttoSpeed = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdMissionAttoSearch = New System.Windows.Forms.Button
        Me.txtMissionAddressSearchAtto = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtMissionAttoAltitude = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtMissionAttoLongitude = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtMissionAttoLatitude = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblMissionAttoControlValue = New System.Windows.Forms.Label
        Me.lblMissionAttoDurationValue = New System.Windows.Forms.Label
        Me.lblMissionAttoLoiterValue = New System.Windows.Forms.Label
        Me.lblMissionHomeAlt = New System.Windows.Forms.Label
        Me.grpMissionControlGeneric = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cboMissionGenericOffset = New System.Windows.Forms.ComboBox
        Me.cmdMissionGenericSearch = New System.Windows.Forms.Button
        Me.txtMissionAddressSearchGeneric = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtMissionGenericAlt = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtMissionGenericLong = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtMissionGenericLat = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.chkMissionInsert = New System.Windows.Forms.CheckBox
        Me.lblMissionDoubleClickLabel = New System.Windows.Forms.Label
        Me.txtMissionDefaultAlt = New System.Windows.Forms.TextBox
        Me.lblMissionDefaultAlt = New System.Windows.Forms.Label
        Me.lblMissionLabel = New System.Windows.Forms.Label
        Me.cboMission = New System.Windows.Forms.ComboBox
        Me.cmdMissionSaveAs = New System.Windows.Forms.Button
        Me.cmdMissionNew = New System.Windows.Forms.Button
        Me.dgMission = New System.Windows.Forms.DataGridView
        Me.tabMissionControl = New System.Windows.Forms.TabPage
        Me.grpControlMavlink = New System.Windows.Forms.GroupBox
        Me.txtControlMavlinkAltRTL = New System.Windows.Forms.TextBox
        Me.cmdControlMavlinkAltRTL = New System.Windows.Forms.Button
        Me.txtControlMavlinkWPRadius = New System.Windows.Forms.TextBox
        Me.cmdControlMavlinkWPRadius = New System.Windows.Forms.Button
        Me.txtControlMavlinkLoiterRadius = New System.Windows.Forms.TextBox
        Me.cmdControlMavlinkLoiterRadius = New System.Windows.Forms.Button
        Me.cmdControlMavlinkGotoCommand = New System.Windows.Forms.Button
        Me.cboControlMavlinkWPNumber = New System.Windows.Forms.ComboBox
        Me.cmdControlMavlinkRestartMission = New System.Windows.Forms.Button
        Me.cmdControlMavlinkSetHome = New System.Windows.Forms.Button
        Me.txtControlMavlinkSetAltitude = New System.Windows.Forms.TextBox
        Me.cboControlMavlinkAction = New System.Windows.Forms.ComboBox
        Me.cmdControlMavlinkAction = New System.Windows.Forms.Button
        Me.cmdControlMavlinkSetAltitude = New System.Windows.Forms.Button
        Me.cboControlMavlinkMode = New System.Windows.Forms.ComboBox
        Me.lblControlMavlinkStatus = New System.Windows.Forms.Label
        Me.cmdControlMavlinkMode = New System.Windows.Forms.Button
        Me.grpControlAtto = New System.Windows.Forms.GroupBox
        Me.cmdControlAttoTriggerServo = New System.Windows.Forms.Button
        Me.cboControlAttoWPNumber = New System.Windows.Forms.ComboBox
        Me.cmdControlAttoResetMission = New System.Windows.Forms.Button
        Me.cmdControlAttoResetReboot = New System.Windows.Forms.Button
        Me.cmdControlAttoResetSpeed = New System.Windows.Forms.Button
        Me.txtControlAttoSpeed = New System.Windows.Forms.TextBox
        Me.cmdControlAttoSpeed = New System.Windows.Forms.Button
        Me.lblControlAttoStatus = New System.Windows.Forms.Label
        Me.cmdControlAttoReturnRally = New System.Windows.Forms.Button
        Me.txtControlAttoPressure = New System.Windows.Forms.TextBox
        Me.cmdControlAttoReturnHome = New System.Windows.Forms.Button
        Me.cmdControlAttoResetBaro = New System.Windows.Forms.Button
        Me.cmdControlAttoLoiter = New System.Windows.Forms.Button
        Me.cmdControlAttoResume = New System.Windows.Forms.Button
        Me.tabConfiguration = New System.Windows.Forms.TabPage
        Me.lblConfigStatus = New System.Windows.Forms.Label
        Me.prgConfig = New System.Windows.Forms.ProgressBar
        Me.cmdConfigWrite = New System.Windows.Forms.Button
        Me.cmdConfigRead = New System.Windows.Forms.Button
        Me.dgConfigVariable = New System.Windows.Forms.DataGridView
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
        Me.tabPortJoystick = New System.Windows.Forms.TabPage
        Me.lblJoystickMode = New System.Windows.Forms.Label
        Me.tbarJoystickMode = New System.Windows.Forms.TrackBar
        Me.Label20 = New System.Windows.Forms.Label
        Me.cboJoystickOutput = New System.Windows.Forms.ComboBox
        Me.lblJoystickDevice = New System.Windows.Forms.Label
        Me.chkJoystickEnable = New System.Windows.Forms.CheckBox
        Me.cmdJoystickCalibrate = New System.Windows.Forms.Button
        Me.lblJoystickRudder = New System.Windows.Forms.Label
        Me.lblJoystickAileron = New System.Windows.Forms.Label
        Me.lblJoystickElevator = New System.Windows.Forms.Label
        Me.tbarJoystickRudder = New System.Windows.Forms.TrackBar
        Me.tbarJoystickAileron = New System.Windows.Forms.TrackBar
        Me.tbarJoystickElevator = New System.Windows.Forms.TrackBar
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblJoystickThrottle = New System.Windows.Forms.Label
        Me.tbarJoystickThrottle = New System.Windows.Forms.TrackBar
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblResolution = New System.Windows.Forms.Label
        Me.JoystickInstrumentControl1 = New HK_GCS.AvionicsInstrumentControlDemo.JoystickInstrumentControl
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdSetHome = New System.Windows.Forms.Button
        Me.cmdClearMap = New System.Windows.Forms.Button
        Me.cmdCenterOnPlane = New System.Windows.Forms.Button
        Me.tabMapView = New System.Windows.Forms.TabControl
        Me.tabViewMapView = New System.Windows.Forms.TabPage
        Me.chkViewHeadLock = New System.Windows.Forms.CheckBox
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
        Me.pnlDevice = New System.Windows.Forms.Panel
        Me.lblVehicle = New System.Windows.Forms.Label
        Me.cboConfigVehicle = New System.Windows.Forms.ComboBox
        Me.lblDevice = New System.Windows.Forms.Label
        Me.cboConfigDevice = New System.Windows.Forms.ComboBox
        Me.tmrJoystick = New System.Windows.Forms.Timer(Me.components)
        Me.pnlLinkLost = New System.Windows.Forms.Panel
        Me.lblLinkLostMessageType = New System.Windows.Forms.Label
        Me.lblLinkLostTime = New System.Windows.Forms.Label
        Me.lblLinkLostMessage = New System.Windows.Forms.Label
        Me.lblLinkLostLabel = New System.Windows.Forms.Label
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
        Me.tabMissionPlanning.SuspendLayout()
        Me.grpMissionControlMavlink.SuspendLayout()
        Me.grpMissionControlAtto.SuspendLayout()
        Me.grpMissionControlGeneric.SuspendLayout()
        CType(Me.dgMission, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMissionControl.SuspendLayout()
        Me.grpControlMavlink.SuspendLayout()
        Me.grpControlAtto.SuspendLayout()
        Me.tabConfiguration.SuspendLayout()
        CType(Me.dgConfigVariable, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.tabPortJoystick.SuspendLayout()
        CType(Me.tbarJoystickMode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarJoystickRudder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarJoystickAileron, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarJoystickElevator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarJoystickThrottle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMapView.SuspendLayout()
        Me.tabViewMapView.SuspendLayout()
        Me.tabViewLiveCamera.SuspendLayout()
        Me.pnlDevice.SuspendLayout()
        Me.pnlLinkLost.SuspendLayout()
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
        Me.serialPortIn.ReceivedBytesThreshold = 4096
        Me.serialPortIn.WriteTimeout = 25
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
        'cmdMissionOverride
        '
        resources.ApplyResources(Me.cmdMissionOverride, "cmdMissionOverride")
        Me.cmdMissionOverride.Name = "cmdMissionOverride"
        Me.ToolTip1.SetToolTip(Me.cmdMissionOverride, resources.GetString("cmdMissionOverride.ToolTip"))
        Me.cmdMissionOverride.UseVisualStyleBackColor = True
        '
        'cmdSetHomeAlt
        '
        resources.ApplyResources(Me.cmdSetHomeAlt, "cmdSetHomeAlt")
        Me.cmdSetHomeAlt.Name = "cmdSetHomeAlt"
        Me.ToolTip1.SetToolTip(Me.cmdSetHomeAlt, resources.GetString("cmdSetHomeAlt.ToolTip"))
        Me.cmdSetHomeAlt.UseVisualStyleBackColor = True
        '
        'cmdMissionAttoAdd
        '
        resources.ApplyResources(Me.cmdMissionAttoAdd, "cmdMissionAttoAdd")
        Me.cmdMissionAttoAdd.Name = "cmdMissionAttoAdd"
        Me.ToolTip1.SetToolTip(Me.cmdMissionAttoAdd, resources.GetString("cmdMissionAttoAdd.ToolTip"))
        Me.cmdMissionAttoAdd.UseVisualStyleBackColor = True
        '
        'cmdMissionMavlinkAdd
        '
        resources.ApplyResources(Me.cmdMissionMavlinkAdd, "cmdMissionMavlinkAdd")
        Me.cmdMissionMavlinkAdd.Name = "cmdMissionMavlinkAdd"
        Me.ToolTip1.SetToolTip(Me.cmdMissionMavlinkAdd, resources.GetString("cmdMissionMavlinkAdd.ToolTip"))
        Me.cmdMissionMavlinkAdd.UseVisualStyleBackColor = True
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblResolution)
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
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSettings, Me.mnuJoystickCalibration, Me.ToolStripMenuItem3, Me.ToolStripMenuItem2, Me.mnuExit})
        resources.ApplyResources(Me.mnuFile, "mnuFile")
        Me.mnuFile.Name = "mnuFile"
        '
        'mnuSettings
        '
        Me.mnuSettings.Name = "mnuSettings"
        resources.ApplyResources(Me.mnuSettings, "mnuSettings")
        '
        'mnuJoystickCalibration
        '
        Me.mnuJoystickCalibration.Name = "mnuJoystickCalibration"
        resources.ApplyResources(Me.mnuJoystickCalibration, "mnuJoystickCalibration")
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        resources.ApplyResources(Me.ToolStripMenuItem3, "ToolStripMenuItem3")
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
        Me.tabInstrumentView.Controls.Add(Me.tabMissionPlanning)
        Me.tabInstrumentView.Controls.Add(Me.tabMissionControl)
        Me.tabInstrumentView.Controls.Add(Me.tabConfiguration)
        resources.ApplyResources(Me.tabInstrumentView, "tabInstrumentView")
        Me.tabInstrumentView.Name = "tabInstrumentView"
        Me.tabInstrumentView.SelectedIndex = 0
        '
        'tabInstruments
        '
        Me.tabInstruments.BackColor = System.Drawing.Color.Transparent
        Me.tabInstruments.Controls.Add(Me.cmdSetHomeAlt)
        Me.tabInstruments.Controls.Add(Me.cmdZeroYaw)
        Me.tabInstruments.Controls.Add(Me.BatteryIndicatorInstrumentControl1)
        Me.tabInstruments.Controls.Add(Me.TurnCoordinatorInstrumentControl1)
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
        'cmdZeroYaw
        '
        resources.ApplyResources(Me.cmdZeroYaw, "cmdZeroYaw")
        Me.cmdZeroYaw.Name = "cmdZeroYaw"
        Me.cmdZeroYaw.UseVisualStyleBackColor = True
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
        'tabMissionPlanning
        '
        Me.tabMissionPlanning.Controls.Add(Me.grpMissionControlMavlink)
        Me.tabMissionPlanning.Controls.Add(Me.grpMissionControlAtto)
        Me.tabMissionPlanning.Controls.Add(Me.cmdMissionOverride)
        Me.tabMissionPlanning.Controls.Add(Me.lblMissionHomeAlt)
        Me.tabMissionPlanning.Controls.Add(Me.grpMissionControlGeneric)
        Me.tabMissionPlanning.Controls.Add(Me.chkMissionInsert)
        Me.tabMissionPlanning.Controls.Add(Me.lblMissionDoubleClickLabel)
        Me.tabMissionPlanning.Controls.Add(Me.txtMissionDefaultAlt)
        Me.tabMissionPlanning.Controls.Add(Me.lblMissionDefaultAlt)
        Me.tabMissionPlanning.Controls.Add(Me.cmdReloadMissionDirectory)
        Me.tabMissionPlanning.Controls.Add(Me.cmdMissionMavlinkAdd)
        Me.tabMissionPlanning.Controls.Add(Me.cmdReloadMissions)
        Me.tabMissionPlanning.Controls.Add(Me.lblMissionLabel)
        Me.tabMissionPlanning.Controls.Add(Me.cboMission)
        Me.tabMissionPlanning.Controls.Add(Me.cmdMissionSaveAs)
        Me.tabMissionPlanning.Controls.Add(Me.cmdMissionNew)
        Me.tabMissionPlanning.Controls.Add(Me.dgMission)
        resources.ApplyResources(Me.tabMissionPlanning, "tabMissionPlanning")
        Me.tabMissionPlanning.Name = "tabMissionPlanning"
        Me.tabMissionPlanning.UseVisualStyleBackColor = True
        '
        'grpMissionControlMavlink
        '
        Me.grpMissionControlMavlink.Controls.Add(Me.txtMissionAddressSearchMavlink)
        Me.grpMissionControlMavlink.Controls.Add(Me.cboMissionMavlinkArg4)
        Me.grpMissionControlMavlink.Controls.Add(Me.cboMissionMavlinkArg3)
        Me.grpMissionControlMavlink.Controls.Add(Me.cboMissionMavlinkArg2)
        Me.grpMissionControlMavlink.Controls.Add(Me.cboMissionMavlinkArg1)
        Me.grpMissionControlMavlink.Controls.Add(Me.txtMissionMavlinkArg7)
        Me.grpMissionControlMavlink.Controls.Add(Me.txtMissionMavlinkArg6)
        Me.grpMissionControlMavlink.Controls.Add(Me.txtMissionMavlinkArg5)
        Me.grpMissionControlMavlink.Controls.Add(Me.lblMissionMavlinkArg5)
        Me.grpMissionControlMavlink.Controls.Add(Me.Label19)
        Me.grpMissionControlMavlink.Controls.Add(Me.cboMissionMavlinkCommand)
        Me.grpMissionControlMavlink.Controls.Add(Me.lblMissionStatusMavlink)
        Me.grpMissionControlMavlink.Controls.Add(Me.prgMissionMavlink)
        Me.grpMissionControlMavlink.Controls.Add(Me.cmdMissionMavlinkWrite)
        Me.grpMissionControlMavlink.Controls.Add(Me.cmdMissionMavlinkRead)
        Me.grpMissionControlMavlink.Controls.Add(Me.txtMissionMavlinkArg1)
        Me.grpMissionControlMavlink.Controls.Add(Me.lblMissionMavlinkArg1)
        Me.grpMissionControlMavlink.Controls.Add(Me.cmdMissionMavlinkSearch)
        Me.grpMissionControlMavlink.Controls.Add(Me.lblMissionAddressSearchMavlink)
        Me.grpMissionControlMavlink.Controls.Add(Me.txtMissionMavlinkArg2)
        Me.grpMissionControlMavlink.Controls.Add(Me.lblMissionMavlinkArg2)
        Me.grpMissionControlMavlink.Controls.Add(Me.txtMissionMavlinkArg4)
        Me.grpMissionControlMavlink.Controls.Add(Me.lblMissionMavlinkArg4)
        Me.grpMissionControlMavlink.Controls.Add(Me.txtMissionMavlinkArg3)
        Me.grpMissionControlMavlink.Controls.Add(Me.lblMissionMavlinkArg3)
        Me.grpMissionControlMavlink.Controls.Add(Me.lblMissionMavlinkArg6)
        Me.grpMissionControlMavlink.Controls.Add(Me.lblMissionMavlinkArg7)
        resources.ApplyResources(Me.grpMissionControlMavlink, "grpMissionControlMavlink")
        Me.grpMissionControlMavlink.Name = "grpMissionControlMavlink"
        Me.grpMissionControlMavlink.TabStop = False
        '
        'txtMissionAddressSearchMavlink
        '
        resources.ApplyResources(Me.txtMissionAddressSearchMavlink, "txtMissionAddressSearchMavlink")
        Me.txtMissionAddressSearchMavlink.Name = "txtMissionAddressSearchMavlink"
        '
        'cboMissionMavlinkArg4
        '
        Me.cboMissionMavlinkArg4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMissionMavlinkArg4.FormattingEnabled = True
        resources.ApplyResources(Me.cboMissionMavlinkArg4, "cboMissionMavlinkArg4")
        Me.cboMissionMavlinkArg4.Name = "cboMissionMavlinkArg4"
        Me.cboMissionMavlinkArg4.Sorted = True
        '
        'cboMissionMavlinkArg3
        '
        Me.cboMissionMavlinkArg3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMissionMavlinkArg3.FormattingEnabled = True
        resources.ApplyResources(Me.cboMissionMavlinkArg3, "cboMissionMavlinkArg3")
        Me.cboMissionMavlinkArg3.Name = "cboMissionMavlinkArg3"
        Me.cboMissionMavlinkArg3.Sorted = True
        '
        'cboMissionMavlinkArg2
        '
        Me.cboMissionMavlinkArg2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMissionMavlinkArg2.FormattingEnabled = True
        resources.ApplyResources(Me.cboMissionMavlinkArg2, "cboMissionMavlinkArg2")
        Me.cboMissionMavlinkArg2.Name = "cboMissionMavlinkArg2"
        Me.cboMissionMavlinkArg2.Sorted = True
        '
        'cboMissionMavlinkArg1
        '
        Me.cboMissionMavlinkArg1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMissionMavlinkArg1.FormattingEnabled = True
        resources.ApplyResources(Me.cboMissionMavlinkArg1, "cboMissionMavlinkArg1")
        Me.cboMissionMavlinkArg1.Name = "cboMissionMavlinkArg1"
        Me.cboMissionMavlinkArg1.Sorted = True
        '
        'txtMissionMavlinkArg7
        '
        resources.ApplyResources(Me.txtMissionMavlinkArg7, "txtMissionMavlinkArg7")
        Me.txtMissionMavlinkArg7.Name = "txtMissionMavlinkArg7"
        '
        'txtMissionMavlinkArg6
        '
        resources.ApplyResources(Me.txtMissionMavlinkArg6, "txtMissionMavlinkArg6")
        Me.txtMissionMavlinkArg6.Name = "txtMissionMavlinkArg6"
        '
        'txtMissionMavlinkArg5
        '
        resources.ApplyResources(Me.txtMissionMavlinkArg5, "txtMissionMavlinkArg5")
        Me.txtMissionMavlinkArg5.Name = "txtMissionMavlinkArg5"
        '
        'lblMissionMavlinkArg5
        '
        resources.ApplyResources(Me.lblMissionMavlinkArg5, "lblMissionMavlinkArg5")
        Me.lblMissionMavlinkArg5.Name = "lblMissionMavlinkArg5"
        '
        'Label19
        '
        resources.ApplyResources(Me.Label19, "Label19")
        Me.Label19.Name = "Label19"
        '
        'cboMissionMavlinkCommand
        '
        Me.cboMissionMavlinkCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMissionMavlinkCommand.FormattingEnabled = True
        resources.ApplyResources(Me.cboMissionMavlinkCommand, "cboMissionMavlinkCommand")
        Me.cboMissionMavlinkCommand.Name = "cboMissionMavlinkCommand"
        Me.cboMissionMavlinkCommand.Sorted = True
        '
        'lblMissionStatusMavlink
        '
        resources.ApplyResources(Me.lblMissionStatusMavlink, "lblMissionStatusMavlink")
        Me.lblMissionStatusMavlink.Name = "lblMissionStatusMavlink"
        '
        'prgMissionMavlink
        '
        resources.ApplyResources(Me.prgMissionMavlink, "prgMissionMavlink")
        Me.prgMissionMavlink.Name = "prgMissionMavlink"
        '
        'cmdMissionMavlinkWrite
        '
        resources.ApplyResources(Me.cmdMissionMavlinkWrite, "cmdMissionMavlinkWrite")
        Me.cmdMissionMavlinkWrite.Name = "cmdMissionMavlinkWrite"
        Me.cmdMissionMavlinkWrite.UseVisualStyleBackColor = True
        '
        'cmdMissionMavlinkRead
        '
        resources.ApplyResources(Me.cmdMissionMavlinkRead, "cmdMissionMavlinkRead")
        Me.cmdMissionMavlinkRead.Name = "cmdMissionMavlinkRead"
        Me.cmdMissionMavlinkRead.UseVisualStyleBackColor = True
        '
        'txtMissionMavlinkArg1
        '
        resources.ApplyResources(Me.txtMissionMavlinkArg1, "txtMissionMavlinkArg1")
        Me.txtMissionMavlinkArg1.Name = "txtMissionMavlinkArg1"
        '
        'lblMissionMavlinkArg1
        '
        resources.ApplyResources(Me.lblMissionMavlinkArg1, "lblMissionMavlinkArg1")
        Me.lblMissionMavlinkArg1.Name = "lblMissionMavlinkArg1"
        '
        'cmdMissionMavlinkSearch
        '
        resources.ApplyResources(Me.cmdMissionMavlinkSearch, "cmdMissionMavlinkSearch")
        Me.cmdMissionMavlinkSearch.Name = "cmdMissionMavlinkSearch"
        Me.cmdMissionMavlinkSearch.UseVisualStyleBackColor = True
        '
        'lblMissionAddressSearchMavlink
        '
        resources.ApplyResources(Me.lblMissionAddressSearchMavlink, "lblMissionAddressSearchMavlink")
        Me.lblMissionAddressSearchMavlink.Name = "lblMissionAddressSearchMavlink"
        '
        'txtMissionMavlinkArg2
        '
        resources.ApplyResources(Me.txtMissionMavlinkArg2, "txtMissionMavlinkArg2")
        Me.txtMissionMavlinkArg2.Name = "txtMissionMavlinkArg2"
        '
        'lblMissionMavlinkArg2
        '
        resources.ApplyResources(Me.lblMissionMavlinkArg2, "lblMissionMavlinkArg2")
        Me.lblMissionMavlinkArg2.Name = "lblMissionMavlinkArg2"
        '
        'txtMissionMavlinkArg4
        '
        resources.ApplyResources(Me.txtMissionMavlinkArg4, "txtMissionMavlinkArg4")
        Me.txtMissionMavlinkArg4.Name = "txtMissionMavlinkArg4"
        '
        'lblMissionMavlinkArg4
        '
        resources.ApplyResources(Me.lblMissionMavlinkArg4, "lblMissionMavlinkArg4")
        Me.lblMissionMavlinkArg4.Name = "lblMissionMavlinkArg4"
        '
        'txtMissionMavlinkArg3
        '
        resources.ApplyResources(Me.txtMissionMavlinkArg3, "txtMissionMavlinkArg3")
        Me.txtMissionMavlinkArg3.Name = "txtMissionMavlinkArg3"
        '
        'lblMissionMavlinkArg3
        '
        resources.ApplyResources(Me.lblMissionMavlinkArg3, "lblMissionMavlinkArg3")
        Me.lblMissionMavlinkArg3.Name = "lblMissionMavlinkArg3"
        '
        'lblMissionMavlinkArg6
        '
        resources.ApplyResources(Me.lblMissionMavlinkArg6, "lblMissionMavlinkArg6")
        Me.lblMissionMavlinkArg6.Name = "lblMissionMavlinkArg6"
        '
        'lblMissionMavlinkArg7
        '
        resources.ApplyResources(Me.lblMissionMavlinkArg7, "lblMissionMavlinkArg7")
        Me.lblMissionMavlinkArg7.Name = "lblMissionMavlinkArg7"
        '
        'grpMissionControlAtto
        '
        Me.grpMissionControlAtto.Controls.Add(Me.cmdMissionAttoAdd)
        Me.grpMissionControlAtto.Controls.Add(Me.txtMissionAttoDefaultSpeed)
        Me.grpMissionControlAtto.Controls.Add(Me.Label12)
        Me.grpMissionControlAtto.Controls.Add(Me.Label11)
        Me.grpMissionControlAtto.Controls.Add(Me.cboMissionAttoReversePath)
        Me.grpMissionControlAtto.Controls.Add(Me.Label10)
        Me.grpMissionControlAtto.Controls.Add(Me.cboMissionAttoAltitudeControl)
        Me.grpMissionControlAtto.Controls.Add(Me.Label9)
        Me.grpMissionControlAtto.Controls.Add(Me.cboMissionAttoTriggerControl)
        Me.grpMissionControlAtto.Controls.Add(Me.Label8)
        Me.grpMissionControlAtto.Controls.Add(Me.cboMissionAttoLoiterDirection)
        Me.grpMissionControlAtto.Controls.Add(Me.Label7)
        Me.grpMissionControlAtto.Controls.Add(Me.cboMissionAttoLoiterDuration)
        Me.grpMissionControlAtto.Controls.Add(Me.lblMissionStatusAtto)
        Me.grpMissionControlAtto.Controls.Add(Me.Label6)
        Me.grpMissionControlAtto.Controls.Add(Me.prgMissionAtto)
        Me.grpMissionControlAtto.Controls.Add(Me.cboMissionAttoLoiter)
        Me.grpMissionControlAtto.Controls.Add(Me.cmdMissionAttoWrite)
        Me.grpMissionControlAtto.Controls.Add(Me.cmdMissionAttoRead)
        Me.grpMissionControlAtto.Controls.Add(Me.txtMissionAttoSpeed)
        Me.grpMissionControlAtto.Controls.Add(Me.Label5)
        Me.grpMissionControlAtto.Controls.Add(Me.cmdMissionAttoSearch)
        Me.grpMissionControlAtto.Controls.Add(Me.txtMissionAddressSearchAtto)
        Me.grpMissionControlAtto.Controls.Add(Me.Label4)
        Me.grpMissionControlAtto.Controls.Add(Me.txtMissionAttoAltitude)
        Me.grpMissionControlAtto.Controls.Add(Me.Label3)
        Me.grpMissionControlAtto.Controls.Add(Me.txtMissionAttoLongitude)
        Me.grpMissionControlAtto.Controls.Add(Me.Label2)
        Me.grpMissionControlAtto.Controls.Add(Me.txtMissionAttoLatitude)
        Me.grpMissionControlAtto.Controls.Add(Me.Label1)
        Me.grpMissionControlAtto.Controls.Add(Me.lblMissionAttoControlValue)
        Me.grpMissionControlAtto.Controls.Add(Me.lblMissionAttoDurationValue)
        Me.grpMissionControlAtto.Controls.Add(Me.lblMissionAttoLoiterValue)
        resources.ApplyResources(Me.grpMissionControlAtto, "grpMissionControlAtto")
        Me.grpMissionControlAtto.Name = "grpMissionControlAtto"
        Me.grpMissionControlAtto.TabStop = False
        '
        'txtMissionAttoDefaultSpeed
        '
        resources.ApplyResources(Me.txtMissionAttoDefaultSpeed, "txtMissionAttoDefaultSpeed")
        Me.txtMissionAttoDefaultSpeed.Name = "txtMissionAttoDefaultSpeed"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'cboMissionAttoReversePath
        '
        Me.cboMissionAttoReversePath.DropDownHeight = 150
        Me.cboMissionAttoReversePath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMissionAttoReversePath.FormattingEnabled = True
        resources.ApplyResources(Me.cboMissionAttoReversePath, "cboMissionAttoReversePath")
        Me.cboMissionAttoReversePath.Name = "cboMissionAttoReversePath"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'cboMissionAttoAltitudeControl
        '
        Me.cboMissionAttoAltitudeControl.DropDownHeight = 150
        Me.cboMissionAttoAltitudeControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMissionAttoAltitudeControl.FormattingEnabled = True
        resources.ApplyResources(Me.cboMissionAttoAltitudeControl, "cboMissionAttoAltitudeControl")
        Me.cboMissionAttoAltitudeControl.Name = "cboMissionAttoAltitudeControl"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'cboMissionAttoTriggerControl
        '
        Me.cboMissionAttoTriggerControl.DropDownHeight = 150
        Me.cboMissionAttoTriggerControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMissionAttoTriggerControl.FormattingEnabled = True
        resources.ApplyResources(Me.cboMissionAttoTriggerControl, "cboMissionAttoTriggerControl")
        Me.cboMissionAttoTriggerControl.Name = "cboMissionAttoTriggerControl"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'cboMissionAttoLoiterDirection
        '
        Me.cboMissionAttoLoiterDirection.DropDownHeight = 150
        Me.cboMissionAttoLoiterDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMissionAttoLoiterDirection.FormattingEnabled = True
        resources.ApplyResources(Me.cboMissionAttoLoiterDirection, "cboMissionAttoLoiterDirection")
        Me.cboMissionAttoLoiterDirection.Name = "cboMissionAttoLoiterDirection"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'cboMissionAttoLoiterDuration
        '
        Me.cboMissionAttoLoiterDuration.DropDownHeight = 150
        Me.cboMissionAttoLoiterDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMissionAttoLoiterDuration.FormattingEnabled = True
        resources.ApplyResources(Me.cboMissionAttoLoiterDuration, "cboMissionAttoLoiterDuration")
        Me.cboMissionAttoLoiterDuration.Name = "cboMissionAttoLoiterDuration"
        '
        'lblMissionStatusAtto
        '
        resources.ApplyResources(Me.lblMissionStatusAtto, "lblMissionStatusAtto")
        Me.lblMissionStatusAtto.Name = "lblMissionStatusAtto"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'prgMissionAtto
        '
        resources.ApplyResources(Me.prgMissionAtto, "prgMissionAtto")
        Me.prgMissionAtto.Name = "prgMissionAtto"
        '
        'cboMissionAttoLoiter
        '
        Me.cboMissionAttoLoiter.DropDownHeight = 150
        Me.cboMissionAttoLoiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMissionAttoLoiter.FormattingEnabled = True
        resources.ApplyResources(Me.cboMissionAttoLoiter, "cboMissionAttoLoiter")
        Me.cboMissionAttoLoiter.Name = "cboMissionAttoLoiter"
        '
        'cmdMissionAttoWrite
        '
        resources.ApplyResources(Me.cmdMissionAttoWrite, "cmdMissionAttoWrite")
        Me.cmdMissionAttoWrite.Name = "cmdMissionAttoWrite"
        Me.cmdMissionAttoWrite.UseVisualStyleBackColor = True
        '
        'cmdMissionAttoRead
        '
        resources.ApplyResources(Me.cmdMissionAttoRead, "cmdMissionAttoRead")
        Me.cmdMissionAttoRead.Name = "cmdMissionAttoRead"
        Me.cmdMissionAttoRead.UseVisualStyleBackColor = True
        '
        'txtMissionAttoSpeed
        '
        resources.ApplyResources(Me.txtMissionAttoSpeed, "txtMissionAttoSpeed")
        Me.txtMissionAttoSpeed.Name = "txtMissionAttoSpeed"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'cmdMissionAttoSearch
        '
        resources.ApplyResources(Me.cmdMissionAttoSearch, "cmdMissionAttoSearch")
        Me.cmdMissionAttoSearch.Name = "cmdMissionAttoSearch"
        Me.cmdMissionAttoSearch.UseVisualStyleBackColor = True
        '
        'txtMissionAddressSearchAtto
        '
        resources.ApplyResources(Me.txtMissionAddressSearchAtto, "txtMissionAddressSearchAtto")
        Me.txtMissionAddressSearchAtto.Name = "txtMissionAddressSearchAtto"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'txtMissionAttoAltitude
        '
        resources.ApplyResources(Me.txtMissionAttoAltitude, "txtMissionAttoAltitude")
        Me.txtMissionAttoAltitude.Name = "txtMissionAttoAltitude"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'txtMissionAttoLongitude
        '
        resources.ApplyResources(Me.txtMissionAttoLongitude, "txtMissionAttoLongitude")
        Me.txtMissionAttoLongitude.Name = "txtMissionAttoLongitude"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'txtMissionAttoLatitude
        '
        resources.ApplyResources(Me.txtMissionAttoLatitude, "txtMissionAttoLatitude")
        Me.txtMissionAttoLatitude.Name = "txtMissionAttoLatitude"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'lblMissionAttoControlValue
        '
        resources.ApplyResources(Me.lblMissionAttoControlValue, "lblMissionAttoControlValue")
        Me.lblMissionAttoControlValue.Name = "lblMissionAttoControlValue"
        '
        'lblMissionAttoDurationValue
        '
        resources.ApplyResources(Me.lblMissionAttoDurationValue, "lblMissionAttoDurationValue")
        Me.lblMissionAttoDurationValue.Name = "lblMissionAttoDurationValue"
        '
        'lblMissionAttoLoiterValue
        '
        resources.ApplyResources(Me.lblMissionAttoLoiterValue, "lblMissionAttoLoiterValue")
        Me.lblMissionAttoLoiterValue.Name = "lblMissionAttoLoiterValue"
        '
        'lblMissionHomeAlt
        '
        resources.ApplyResources(Me.lblMissionHomeAlt, "lblMissionHomeAlt")
        Me.lblMissionHomeAlt.Name = "lblMissionHomeAlt"
        '
        'grpMissionControlGeneric
        '
        Me.grpMissionControlGeneric.Controls.Add(Me.Label13)
        Me.grpMissionControlGeneric.Controls.Add(Me.cboMissionGenericOffset)
        Me.grpMissionControlGeneric.Controls.Add(Me.cmdMissionGenericSearch)
        Me.grpMissionControlGeneric.Controls.Add(Me.txtMissionAddressSearchGeneric)
        Me.grpMissionControlGeneric.Controls.Add(Me.Label21)
        Me.grpMissionControlGeneric.Controls.Add(Me.txtMissionGenericAlt)
        Me.grpMissionControlGeneric.Controls.Add(Me.Label22)
        Me.grpMissionControlGeneric.Controls.Add(Me.txtMissionGenericLong)
        Me.grpMissionControlGeneric.Controls.Add(Me.Label23)
        Me.grpMissionControlGeneric.Controls.Add(Me.txtMissionGenericLat)
        Me.grpMissionControlGeneric.Controls.Add(Me.Label24)
        resources.ApplyResources(Me.grpMissionControlGeneric, "grpMissionControlGeneric")
        Me.grpMissionControlGeneric.Name = "grpMissionControlGeneric"
        Me.grpMissionControlGeneric.TabStop = False
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'cboMissionGenericOffset
        '
        Me.cboMissionGenericOffset.DropDownHeight = 150
        Me.cboMissionGenericOffset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMissionGenericOffset.FormattingEnabled = True
        resources.ApplyResources(Me.cboMissionGenericOffset, "cboMissionGenericOffset")
        Me.cboMissionGenericOffset.Name = "cboMissionGenericOffset"
        '
        'cmdMissionGenericSearch
        '
        resources.ApplyResources(Me.cmdMissionGenericSearch, "cmdMissionGenericSearch")
        Me.cmdMissionGenericSearch.Name = "cmdMissionGenericSearch"
        Me.cmdMissionGenericSearch.UseVisualStyleBackColor = True
        '
        'txtMissionAddressSearchGeneric
        '
        resources.ApplyResources(Me.txtMissionAddressSearchGeneric, "txtMissionAddressSearchGeneric")
        Me.txtMissionAddressSearchGeneric.Name = "txtMissionAddressSearchGeneric"
        '
        'Label21
        '
        resources.ApplyResources(Me.Label21, "Label21")
        Me.Label21.Name = "Label21"
        '
        'txtMissionGenericAlt
        '
        resources.ApplyResources(Me.txtMissionGenericAlt, "txtMissionGenericAlt")
        Me.txtMissionGenericAlt.Name = "txtMissionGenericAlt"
        '
        'Label22
        '
        resources.ApplyResources(Me.Label22, "Label22")
        Me.Label22.Name = "Label22"
        '
        'txtMissionGenericLong
        '
        resources.ApplyResources(Me.txtMissionGenericLong, "txtMissionGenericLong")
        Me.txtMissionGenericLong.Name = "txtMissionGenericLong"
        '
        'Label23
        '
        resources.ApplyResources(Me.Label23, "Label23")
        Me.Label23.Name = "Label23"
        '
        'txtMissionGenericLat
        '
        resources.ApplyResources(Me.txtMissionGenericLat, "txtMissionGenericLat")
        Me.txtMissionGenericLat.Name = "txtMissionGenericLat"
        '
        'Label24
        '
        resources.ApplyResources(Me.Label24, "Label24")
        Me.Label24.Name = "Label24"
        '
        'chkMissionInsert
        '
        resources.ApplyResources(Me.chkMissionInsert, "chkMissionInsert")
        Me.chkMissionInsert.Name = "chkMissionInsert"
        Me.chkMissionInsert.UseVisualStyleBackColor = True
        '
        'lblMissionDoubleClickLabel
        '
        resources.ApplyResources(Me.lblMissionDoubleClickLabel, "lblMissionDoubleClickLabel")
        Me.lblMissionDoubleClickLabel.Name = "lblMissionDoubleClickLabel"
        '
        'txtMissionDefaultAlt
        '
        resources.ApplyResources(Me.txtMissionDefaultAlt, "txtMissionDefaultAlt")
        Me.txtMissionDefaultAlt.Name = "txtMissionDefaultAlt"
        '
        'lblMissionDefaultAlt
        '
        resources.ApplyResources(Me.lblMissionDefaultAlt, "lblMissionDefaultAlt")
        Me.lblMissionDefaultAlt.Name = "lblMissionDefaultAlt"
        '
        'lblMissionLabel
        '
        resources.ApplyResources(Me.lblMissionLabel, "lblMissionLabel")
        Me.lblMissionLabel.Name = "lblMissionLabel"
        '
        'cboMission
        '
        Me.cboMission.DropDownHeight = 300
        Me.cboMission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMission.FormattingEnabled = True
        resources.ApplyResources(Me.cboMission, "cboMission")
        Me.cboMission.Name = "cboMission"
        Me.cboMission.Sorted = True
        '
        'cmdMissionSaveAs
        '
        resources.ApplyResources(Me.cmdMissionSaveAs, "cmdMissionSaveAs")
        Me.cmdMissionSaveAs.Name = "cmdMissionSaveAs"
        Me.cmdMissionSaveAs.UseVisualStyleBackColor = True
        '
        'cmdMissionNew
        '
        resources.ApplyResources(Me.cmdMissionNew, "cmdMissionNew")
        Me.cmdMissionNew.Name = "cmdMissionNew"
        Me.cmdMissionNew.UseVisualStyleBackColor = True
        '
        'dgMission
        '
        Me.dgMission.AllowUserToAddRows = False
        Me.dgMission.AllowUserToDeleteRows = False
        Me.dgMission.AllowUserToResizeRows = False
        Me.dgMission.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgMission.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMission.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgMission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMission.DefaultCellStyle = DataGridViewCellStyle8
        resources.ApplyResources(Me.dgMission, "dgMission")
        Me.dgMission.MultiSelect = False
        Me.dgMission.Name = "dgMission"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMission.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgMission.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'tabMissionControl
        '
        Me.tabMissionControl.Controls.Add(Me.grpControlMavlink)
        Me.tabMissionControl.Controls.Add(Me.grpControlAtto)
        resources.ApplyResources(Me.tabMissionControl, "tabMissionControl")
        Me.tabMissionControl.Name = "tabMissionControl"
        Me.tabMissionControl.UseVisualStyleBackColor = True
        '
        'grpControlMavlink
        '
        Me.grpControlMavlink.Controls.Add(Me.txtControlMavlinkAltRTL)
        Me.grpControlMavlink.Controls.Add(Me.cmdControlMavlinkAltRTL)
        Me.grpControlMavlink.Controls.Add(Me.txtControlMavlinkWPRadius)
        Me.grpControlMavlink.Controls.Add(Me.cmdControlMavlinkWPRadius)
        Me.grpControlMavlink.Controls.Add(Me.txtControlMavlinkLoiterRadius)
        Me.grpControlMavlink.Controls.Add(Me.cmdControlMavlinkLoiterRadius)
        Me.grpControlMavlink.Controls.Add(Me.cmdControlMavlinkGotoCommand)
        Me.grpControlMavlink.Controls.Add(Me.cboControlMavlinkWPNumber)
        Me.grpControlMavlink.Controls.Add(Me.cmdControlMavlinkRestartMission)
        Me.grpControlMavlink.Controls.Add(Me.cmdControlMavlinkSetHome)
        Me.grpControlMavlink.Controls.Add(Me.txtControlMavlinkSetAltitude)
        Me.grpControlMavlink.Controls.Add(Me.cboControlMavlinkAction)
        Me.grpControlMavlink.Controls.Add(Me.cmdControlMavlinkAction)
        Me.grpControlMavlink.Controls.Add(Me.cmdControlMavlinkSetAltitude)
        Me.grpControlMavlink.Controls.Add(Me.cboControlMavlinkMode)
        Me.grpControlMavlink.Controls.Add(Me.lblControlMavlinkStatus)
        Me.grpControlMavlink.Controls.Add(Me.cmdControlMavlinkMode)
        resources.ApplyResources(Me.grpControlMavlink, "grpControlMavlink")
        Me.grpControlMavlink.Name = "grpControlMavlink"
        Me.grpControlMavlink.TabStop = False
        '
        'txtControlMavlinkAltRTL
        '
        resources.ApplyResources(Me.txtControlMavlinkAltRTL, "txtControlMavlinkAltRTL")
        Me.txtControlMavlinkAltRTL.Name = "txtControlMavlinkAltRTL"
        '
        'cmdControlMavlinkAltRTL
        '
        resources.ApplyResources(Me.cmdControlMavlinkAltRTL, "cmdControlMavlinkAltRTL")
        Me.cmdControlMavlinkAltRTL.Name = "cmdControlMavlinkAltRTL"
        Me.cmdControlMavlinkAltRTL.UseVisualStyleBackColor = True
        '
        'txtControlMavlinkWPRadius
        '
        resources.ApplyResources(Me.txtControlMavlinkWPRadius, "txtControlMavlinkWPRadius")
        Me.txtControlMavlinkWPRadius.Name = "txtControlMavlinkWPRadius"
        '
        'cmdControlMavlinkWPRadius
        '
        resources.ApplyResources(Me.cmdControlMavlinkWPRadius, "cmdControlMavlinkWPRadius")
        Me.cmdControlMavlinkWPRadius.Name = "cmdControlMavlinkWPRadius"
        Me.cmdControlMavlinkWPRadius.UseVisualStyleBackColor = True
        '
        'txtControlMavlinkLoiterRadius
        '
        resources.ApplyResources(Me.txtControlMavlinkLoiterRadius, "txtControlMavlinkLoiterRadius")
        Me.txtControlMavlinkLoiterRadius.Name = "txtControlMavlinkLoiterRadius"
        '
        'cmdControlMavlinkLoiterRadius
        '
        resources.ApplyResources(Me.cmdControlMavlinkLoiterRadius, "cmdControlMavlinkLoiterRadius")
        Me.cmdControlMavlinkLoiterRadius.Name = "cmdControlMavlinkLoiterRadius"
        Me.cmdControlMavlinkLoiterRadius.UseVisualStyleBackColor = True
        '
        'cmdControlMavlinkGotoCommand
        '
        resources.ApplyResources(Me.cmdControlMavlinkGotoCommand, "cmdControlMavlinkGotoCommand")
        Me.cmdControlMavlinkGotoCommand.Name = "cmdControlMavlinkGotoCommand"
        Me.cmdControlMavlinkGotoCommand.UseVisualStyleBackColor = True
        '
        'cboControlMavlinkWPNumber
        '
        Me.cboControlMavlinkWPNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboControlMavlinkWPNumber.FormattingEnabled = True
        resources.ApplyResources(Me.cboControlMavlinkWPNumber, "cboControlMavlinkWPNumber")
        Me.cboControlMavlinkWPNumber.Name = "cboControlMavlinkWPNumber"
        '
        'cmdControlMavlinkRestartMission
        '
        resources.ApplyResources(Me.cmdControlMavlinkRestartMission, "cmdControlMavlinkRestartMission")
        Me.cmdControlMavlinkRestartMission.Name = "cmdControlMavlinkRestartMission"
        Me.cmdControlMavlinkRestartMission.UseVisualStyleBackColor = True
        '
        'cmdControlMavlinkSetHome
        '
        resources.ApplyResources(Me.cmdControlMavlinkSetHome, "cmdControlMavlinkSetHome")
        Me.cmdControlMavlinkSetHome.Name = "cmdControlMavlinkSetHome"
        Me.cmdControlMavlinkSetHome.UseVisualStyleBackColor = True
        '
        'txtControlMavlinkSetAltitude
        '
        resources.ApplyResources(Me.txtControlMavlinkSetAltitude, "txtControlMavlinkSetAltitude")
        Me.txtControlMavlinkSetAltitude.Name = "txtControlMavlinkSetAltitude"
        '
        'cboControlMavlinkAction
        '
        Me.cboControlMavlinkAction.DropDownHeight = 300
        Me.cboControlMavlinkAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboControlMavlinkAction.FormattingEnabled = True
        resources.ApplyResources(Me.cboControlMavlinkAction, "cboControlMavlinkAction")
        Me.cboControlMavlinkAction.Name = "cboControlMavlinkAction"
        Me.cboControlMavlinkAction.Sorted = True
        '
        'cmdControlMavlinkAction
        '
        resources.ApplyResources(Me.cmdControlMavlinkAction, "cmdControlMavlinkAction")
        Me.cmdControlMavlinkAction.Name = "cmdControlMavlinkAction"
        Me.cmdControlMavlinkAction.UseVisualStyleBackColor = True
        '
        'cmdControlMavlinkSetAltitude
        '
        resources.ApplyResources(Me.cmdControlMavlinkSetAltitude, "cmdControlMavlinkSetAltitude")
        Me.cmdControlMavlinkSetAltitude.Name = "cmdControlMavlinkSetAltitude"
        Me.cmdControlMavlinkSetAltitude.UseVisualStyleBackColor = True
        '
        'cboControlMavlinkMode
        '
        Me.cboControlMavlinkMode.DropDownHeight = 300
        Me.cboControlMavlinkMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboControlMavlinkMode.FormattingEnabled = True
        resources.ApplyResources(Me.cboControlMavlinkMode, "cboControlMavlinkMode")
        Me.cboControlMavlinkMode.Name = "cboControlMavlinkMode"
        Me.cboControlMavlinkMode.Sorted = True
        '
        'lblControlMavlinkStatus
        '
        resources.ApplyResources(Me.lblControlMavlinkStatus, "lblControlMavlinkStatus")
        Me.lblControlMavlinkStatus.Name = "lblControlMavlinkStatus"
        '
        'cmdControlMavlinkMode
        '
        resources.ApplyResources(Me.cmdControlMavlinkMode, "cmdControlMavlinkMode")
        Me.cmdControlMavlinkMode.Name = "cmdControlMavlinkMode"
        Me.cmdControlMavlinkMode.UseVisualStyleBackColor = True
        '
        'grpControlAtto
        '
        Me.grpControlAtto.Controls.Add(Me.cmdControlAttoTriggerServo)
        Me.grpControlAtto.Controls.Add(Me.cboControlAttoWPNumber)
        Me.grpControlAtto.Controls.Add(Me.cmdControlAttoResetMission)
        Me.grpControlAtto.Controls.Add(Me.cmdControlAttoResetReboot)
        Me.grpControlAtto.Controls.Add(Me.cmdControlAttoResetSpeed)
        Me.grpControlAtto.Controls.Add(Me.txtControlAttoSpeed)
        Me.grpControlAtto.Controls.Add(Me.cmdControlAttoSpeed)
        Me.grpControlAtto.Controls.Add(Me.lblControlAttoStatus)
        Me.grpControlAtto.Controls.Add(Me.cmdControlAttoReturnRally)
        Me.grpControlAtto.Controls.Add(Me.txtControlAttoPressure)
        Me.grpControlAtto.Controls.Add(Me.cmdControlAttoReturnHome)
        Me.grpControlAtto.Controls.Add(Me.cmdControlAttoResetBaro)
        Me.grpControlAtto.Controls.Add(Me.cmdControlAttoLoiter)
        Me.grpControlAtto.Controls.Add(Me.cmdControlAttoResume)
        resources.ApplyResources(Me.grpControlAtto, "grpControlAtto")
        Me.grpControlAtto.Name = "grpControlAtto"
        Me.grpControlAtto.TabStop = False
        '
        'cmdControlAttoTriggerServo
        '
        resources.ApplyResources(Me.cmdControlAttoTriggerServo, "cmdControlAttoTriggerServo")
        Me.cmdControlAttoTriggerServo.Name = "cmdControlAttoTriggerServo"
        Me.cmdControlAttoTriggerServo.UseVisualStyleBackColor = True
        '
        'cboControlAttoWPNumber
        '
        Me.cboControlAttoWPNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboControlAttoWPNumber.FormattingEnabled = True
        resources.ApplyResources(Me.cboControlAttoWPNumber, "cboControlAttoWPNumber")
        Me.cboControlAttoWPNumber.Name = "cboControlAttoWPNumber"
        '
        'cmdControlAttoResetMission
        '
        resources.ApplyResources(Me.cmdControlAttoResetMission, "cmdControlAttoResetMission")
        Me.cmdControlAttoResetMission.Name = "cmdControlAttoResetMission"
        Me.cmdControlAttoResetMission.UseVisualStyleBackColor = True
        '
        'cmdControlAttoResetReboot
        '
        resources.ApplyResources(Me.cmdControlAttoResetReboot, "cmdControlAttoResetReboot")
        Me.cmdControlAttoResetReboot.Name = "cmdControlAttoResetReboot"
        Me.cmdControlAttoResetReboot.UseVisualStyleBackColor = True
        '
        'cmdControlAttoResetSpeed
        '
        resources.ApplyResources(Me.cmdControlAttoResetSpeed, "cmdControlAttoResetSpeed")
        Me.cmdControlAttoResetSpeed.Name = "cmdControlAttoResetSpeed"
        Me.cmdControlAttoResetSpeed.UseVisualStyleBackColor = True
        '
        'txtControlAttoSpeed
        '
        resources.ApplyResources(Me.txtControlAttoSpeed, "txtControlAttoSpeed")
        Me.txtControlAttoSpeed.Name = "txtControlAttoSpeed"
        '
        'cmdControlAttoSpeed
        '
        resources.ApplyResources(Me.cmdControlAttoSpeed, "cmdControlAttoSpeed")
        Me.cmdControlAttoSpeed.Name = "cmdControlAttoSpeed"
        Me.cmdControlAttoSpeed.UseVisualStyleBackColor = True
        '
        'lblControlAttoStatus
        '
        resources.ApplyResources(Me.lblControlAttoStatus, "lblControlAttoStatus")
        Me.lblControlAttoStatus.Name = "lblControlAttoStatus"
        '
        'cmdControlAttoReturnRally
        '
        resources.ApplyResources(Me.cmdControlAttoReturnRally, "cmdControlAttoReturnRally")
        Me.cmdControlAttoReturnRally.Name = "cmdControlAttoReturnRally"
        Me.cmdControlAttoReturnRally.UseVisualStyleBackColor = True
        '
        'txtControlAttoPressure
        '
        resources.ApplyResources(Me.txtControlAttoPressure, "txtControlAttoPressure")
        Me.txtControlAttoPressure.Name = "txtControlAttoPressure"
        '
        'cmdControlAttoReturnHome
        '
        resources.ApplyResources(Me.cmdControlAttoReturnHome, "cmdControlAttoReturnHome")
        Me.cmdControlAttoReturnHome.Name = "cmdControlAttoReturnHome"
        Me.cmdControlAttoReturnHome.UseVisualStyleBackColor = True
        '
        'cmdControlAttoResetBaro
        '
        resources.ApplyResources(Me.cmdControlAttoResetBaro, "cmdControlAttoResetBaro")
        Me.cmdControlAttoResetBaro.Name = "cmdControlAttoResetBaro"
        Me.cmdControlAttoResetBaro.UseVisualStyleBackColor = True
        '
        'cmdControlAttoLoiter
        '
        resources.ApplyResources(Me.cmdControlAttoLoiter, "cmdControlAttoLoiter")
        Me.cmdControlAttoLoiter.Name = "cmdControlAttoLoiter"
        Me.cmdControlAttoLoiter.UseVisualStyleBackColor = True
        '
        'cmdControlAttoResume
        '
        resources.ApplyResources(Me.cmdControlAttoResume, "cmdControlAttoResume")
        Me.cmdControlAttoResume.Name = "cmdControlAttoResume"
        Me.cmdControlAttoResume.UseVisualStyleBackColor = True
        '
        'tabConfiguration
        '
        Me.tabConfiguration.Controls.Add(Me.lblConfigStatus)
        Me.tabConfiguration.Controls.Add(Me.prgConfig)
        Me.tabConfiguration.Controls.Add(Me.cmdConfigWrite)
        Me.tabConfiguration.Controls.Add(Me.cmdConfigRead)
        Me.tabConfiguration.Controls.Add(Me.dgConfigVariable)
        resources.ApplyResources(Me.tabConfiguration, "tabConfiguration")
        Me.tabConfiguration.Name = "tabConfiguration"
        Me.tabConfiguration.UseVisualStyleBackColor = True
        '
        'lblConfigStatus
        '
        resources.ApplyResources(Me.lblConfigStatus, "lblConfigStatus")
        Me.lblConfigStatus.Name = "lblConfigStatus"
        '
        'prgConfig
        '
        resources.ApplyResources(Me.prgConfig, "prgConfig")
        Me.prgConfig.Name = "prgConfig"
        '
        'cmdConfigWrite
        '
        resources.ApplyResources(Me.cmdConfigWrite, "cmdConfigWrite")
        Me.cmdConfigWrite.Name = "cmdConfigWrite"
        Me.cmdConfigWrite.UseVisualStyleBackColor = True
        '
        'cmdConfigRead
        '
        resources.ApplyResources(Me.cmdConfigRead, "cmdConfigRead")
        Me.cmdConfigRead.Name = "cmdConfigRead"
        Me.cmdConfigRead.UseVisualStyleBackColor = True
        '
        'dgConfigVariable
        '
        Me.dgConfigVariable.AllowUserToAddRows = False
        Me.dgConfigVariable.AllowUserToDeleteRows = False
        Me.dgConfigVariable.AllowUserToResizeRows = False
        Me.dgConfigVariable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgConfigVariable.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgConfigVariable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgConfigVariable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgConfigVariable.DefaultCellStyle = DataGridViewCellStyle11
        resources.ApplyResources(Me.dgConfigVariable, "dgConfigVariable")
        Me.dgConfigVariable.MultiSelect = False
        Me.dgConfigVariable.Name = "dgConfigVariable"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgConfigVariable.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgConfigVariable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
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
        Me.tabPortControl.Controls.Add(Me.tabPortJoystick)
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
        resources.ApplyResources(Me.cboOutputFiles, "cboOutputFiles")
        Me.cboOutputFiles.FormattingEnabled = True
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
        Me.cboOutputTypeTracking.Sorted = True
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
        'tabPortJoystick
        '
        Me.tabPortJoystick.Controls.Add(Me.lblJoystickMode)
        Me.tabPortJoystick.Controls.Add(Me.tbarJoystickMode)
        Me.tabPortJoystick.Controls.Add(Me.Label20)
        Me.tabPortJoystick.Controls.Add(Me.cboJoystickOutput)
        Me.tabPortJoystick.Controls.Add(Me.lblJoystickDevice)
        Me.tabPortJoystick.Controls.Add(Me.chkJoystickEnable)
        Me.tabPortJoystick.Controls.Add(Me.cmdJoystickCalibrate)
        Me.tabPortJoystick.Controls.Add(Me.lblJoystickRudder)
        Me.tabPortJoystick.Controls.Add(Me.lblJoystickAileron)
        Me.tabPortJoystick.Controls.Add(Me.lblJoystickElevator)
        Me.tabPortJoystick.Controls.Add(Me.tbarJoystickRudder)
        Me.tabPortJoystick.Controls.Add(Me.tbarJoystickAileron)
        Me.tabPortJoystick.Controls.Add(Me.tbarJoystickElevator)
        Me.tabPortJoystick.Controls.Add(Me.Label18)
        Me.tabPortJoystick.Controls.Add(Me.Label17)
        Me.tabPortJoystick.Controls.Add(Me.Label16)
        Me.tabPortJoystick.Controls.Add(Me.Label15)
        Me.tabPortJoystick.Controls.Add(Me.lblJoystickThrottle)
        Me.tabPortJoystick.Controls.Add(Me.tbarJoystickThrottle)
        Me.tabPortJoystick.Controls.Add(Me.Label14)
        resources.ApplyResources(Me.tabPortJoystick, "tabPortJoystick")
        Me.tabPortJoystick.Name = "tabPortJoystick"
        Me.tabPortJoystick.UseVisualStyleBackColor = True
        '
        'lblJoystickMode
        '
        resources.ApplyResources(Me.lblJoystickMode, "lblJoystickMode")
        Me.lblJoystickMode.Name = "lblJoystickMode"
        '
        'tbarJoystickMode
        '
        resources.ApplyResources(Me.tbarJoystickMode, "tbarJoystickMode")
        Me.tbarJoystickMode.BackColor = System.Drawing.Color.White
        Me.tbarJoystickMode.LargeChange = 1
        Me.tbarJoystickMode.Maximum = 10000
        Me.tbarJoystickMode.Minimum = -10000
        Me.tbarJoystickMode.Name = "tbarJoystickMode"
        Me.tbarJoystickMode.TabStop = False
        Me.tbarJoystickMode.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'Label20
        '
        resources.ApplyResources(Me.Label20, "Label20")
        Me.Label20.Name = "Label20"
        '
        'cboJoystickOutput
        '
        Me.cboJoystickOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJoystickOutput.FormattingEnabled = True
        resources.ApplyResources(Me.cboJoystickOutput, "cboJoystickOutput")
        Me.cboJoystickOutput.Name = "cboJoystickOutput"
        '
        'lblJoystickDevice
        '
        resources.ApplyResources(Me.lblJoystickDevice, "lblJoystickDevice")
        Me.lblJoystickDevice.Name = "lblJoystickDevice"
        '
        'chkJoystickEnable
        '
        resources.ApplyResources(Me.chkJoystickEnable, "chkJoystickEnable")
        Me.chkJoystickEnable.Name = "chkJoystickEnable"
        Me.chkJoystickEnable.UseVisualStyleBackColor = True
        '
        'cmdJoystickCalibrate
        '
        resources.ApplyResources(Me.cmdJoystickCalibrate, "cmdJoystickCalibrate")
        Me.cmdJoystickCalibrate.Name = "cmdJoystickCalibrate"
        Me.cmdJoystickCalibrate.UseVisualStyleBackColor = True
        '
        'lblJoystickRudder
        '
        resources.ApplyResources(Me.lblJoystickRudder, "lblJoystickRudder")
        Me.lblJoystickRudder.Name = "lblJoystickRudder"
        '
        'lblJoystickAileron
        '
        resources.ApplyResources(Me.lblJoystickAileron, "lblJoystickAileron")
        Me.lblJoystickAileron.Name = "lblJoystickAileron"
        '
        'lblJoystickElevator
        '
        resources.ApplyResources(Me.lblJoystickElevator, "lblJoystickElevator")
        Me.lblJoystickElevator.Name = "lblJoystickElevator"
        '
        'tbarJoystickRudder
        '
        resources.ApplyResources(Me.tbarJoystickRudder, "tbarJoystickRudder")
        Me.tbarJoystickRudder.BackColor = System.Drawing.Color.White
        Me.tbarJoystickRudder.LargeChange = 1
        Me.tbarJoystickRudder.Maximum = 10000
        Me.tbarJoystickRudder.Minimum = -10000
        Me.tbarJoystickRudder.Name = "tbarJoystickRudder"
        Me.tbarJoystickRudder.TabStop = False
        Me.tbarJoystickRudder.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbarJoystickAileron
        '
        resources.ApplyResources(Me.tbarJoystickAileron, "tbarJoystickAileron")
        Me.tbarJoystickAileron.BackColor = System.Drawing.Color.White
        Me.tbarJoystickAileron.LargeChange = 1
        Me.tbarJoystickAileron.Maximum = 10000
        Me.tbarJoystickAileron.Minimum = -10000
        Me.tbarJoystickAileron.Name = "tbarJoystickAileron"
        Me.tbarJoystickAileron.TabStop = False
        Me.tbarJoystickAileron.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbarJoystickElevator
        '
        resources.ApplyResources(Me.tbarJoystickElevator, "tbarJoystickElevator")
        Me.tbarJoystickElevator.BackColor = System.Drawing.Color.White
        Me.tbarJoystickElevator.LargeChange = 1
        Me.tbarJoystickElevator.Maximum = 10000
        Me.tbarJoystickElevator.Minimum = -10000
        Me.tbarJoystickElevator.Name = "tbarJoystickElevator"
        Me.tbarJoystickElevator.TabStop = False
        Me.tbarJoystickElevator.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.Name = "Label18"
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.Name = "Label17"
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.Name = "Label16"
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Name = "Label15"
        '
        'lblJoystickThrottle
        '
        resources.ApplyResources(Me.lblJoystickThrottle, "lblJoystickThrottle")
        Me.lblJoystickThrottle.Name = "lblJoystickThrottle"
        '
        'tbarJoystickThrottle
        '
        resources.ApplyResources(Me.tbarJoystickThrottle, "tbarJoystickThrottle")
        Me.tbarJoystickThrottle.BackColor = System.Drawing.Color.White
        Me.tbarJoystickThrottle.LargeChange = 1
        Me.tbarJoystickThrottle.Maximum = 10000
        Me.tbarJoystickThrottle.Minimum = -10000
        Me.tbarJoystickThrottle.Name = "tbarJoystickThrottle"
        Me.tbarJoystickThrottle.TabStop = False
        Me.tbarJoystickThrottle.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
        '
        'lblResolution
        '
        resources.ApplyResources(Me.lblResolution, "lblResolution")
        Me.lblResolution.Name = "lblResolution"
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
        Me.tabViewMapView.Controls.Add(Me.chkViewHeadLock)
        Me.tabViewMapView.Controls.Add(Me.tbarModelScale)
        Me.tabViewMapView.Controls.Add(Me.chkViewFirstPerson)
        Me.tabViewMapView.Controls.Add(Me.chkViewChaseCam)
        Me.tabViewMapView.Controls.Add(Me.chkViewOverhead)
        Me.tabViewMapView.Controls.Add(Me.chkViewNoTracking)
        Me.tabViewMapView.Controls.Add(Me.WebBrowser1)
        resources.ApplyResources(Me.tabViewMapView, "tabViewMapView")
        Me.tabViewMapView.Name = "tabViewMapView"
        Me.tabViewMapView.Tag = "Google Earth"
        Me.tabViewMapView.UseVisualStyleBackColor = True
        '
        'chkViewHeadLock
        '
        resources.ApplyResources(Me.chkViewHeadLock, "chkViewHeadLock")
        Me.chkViewHeadLock.Checked = True
        Me.chkViewHeadLock.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkViewHeadLock.Name = "chkViewHeadLock"
        Me.chkViewHeadLock.UseVisualStyleBackColor = True
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
        Me.tabViewLiveCamera.Tag = "Camera"
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
        'pnlDevice
        '
        Me.pnlDevice.BackColor = System.Drawing.Color.White
        Me.pnlDevice.Controls.Add(Me.lblVehicle)
        Me.pnlDevice.Controls.Add(Me.cboConfigVehicle)
        Me.pnlDevice.Controls.Add(Me.lblDevice)
        Me.pnlDevice.Controls.Add(Me.cboConfigDevice)
        resources.ApplyResources(Me.pnlDevice, "pnlDevice")
        Me.pnlDevice.Name = "pnlDevice"
        '
        'lblVehicle
        '
        resources.ApplyResources(Me.lblVehicle, "lblVehicle")
        Me.lblVehicle.Name = "lblVehicle"
        '
        'cboConfigVehicle
        '
        Me.cboConfigVehicle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConfigVehicle.FormattingEnabled = True
        resources.ApplyResources(Me.cboConfigVehicle, "cboConfigVehicle")
        Me.cboConfigVehicle.Name = "cboConfigVehicle"
        '
        'lblDevice
        '
        resources.ApplyResources(Me.lblDevice, "lblDevice")
        Me.lblDevice.Name = "lblDevice"
        '
        'cboConfigDevice
        '
        Me.cboConfigDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConfigDevice.FormattingEnabled = True
        resources.ApplyResources(Me.cboConfigDevice, "cboConfigDevice")
        Me.cboConfigDevice.Name = "cboConfigDevice"
        Me.cboConfigDevice.Sorted = True
        '
        'tmrJoystick
        '
        Me.tmrJoystick.Interval = 50
        '
        'pnlLinkLost
        '
        Me.pnlLinkLost.BackColor = System.Drawing.Color.Yellow
        Me.pnlLinkLost.Controls.Add(Me.lblLinkLostMessageType)
        Me.pnlLinkLost.Controls.Add(Me.lblLinkLostTime)
        Me.pnlLinkLost.Controls.Add(Me.lblLinkLostMessage)
        Me.pnlLinkLost.Controls.Add(Me.lblLinkLostLabel)
        resources.ApplyResources(Me.pnlLinkLost, "pnlLinkLost")
        Me.pnlLinkLost.Name = "pnlLinkLost"
        '
        'lblLinkLostMessageType
        '
        Me.lblLinkLostMessageType.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.lblLinkLostMessageType, "lblLinkLostMessageType")
        Me.lblLinkLostMessageType.Name = "lblLinkLostMessageType"
        '
        'lblLinkLostTime
        '
        Me.lblLinkLostTime.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.lblLinkLostTime, "lblLinkLostTime")
        Me.lblLinkLostTime.Name = "lblLinkLostTime"
        '
        'lblLinkLostMessage
        '
        Me.lblLinkLostMessage.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.lblLinkLostMessage, "lblLinkLostMessage")
        Me.lblLinkLostMessage.Name = "lblLinkLostMessage"
        '
        'lblLinkLostLabel
        '
        Me.lblLinkLostLabel.BackColor = System.Drawing.Color.White
        Me.lblLinkLostLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.lblLinkLostLabel, "lblLinkLostLabel")
        Me.lblLinkLostLabel.Name = "lblLinkLostLabel"
        '
        'frmMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlLinkLost)
        Me.Controls.Add(Me.pnlDevice)
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
        Me.tabMissionPlanning.ResumeLayout(False)
        Me.tabMissionPlanning.PerformLayout()
        Me.grpMissionControlMavlink.ResumeLayout(False)
        Me.grpMissionControlMavlink.PerformLayout()
        Me.grpMissionControlAtto.ResumeLayout(False)
        Me.grpMissionControlAtto.PerformLayout()
        Me.grpMissionControlGeneric.ResumeLayout(False)
        Me.grpMissionControlGeneric.PerformLayout()
        CType(Me.dgMission, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMissionControl.ResumeLayout(False)
        Me.grpControlMavlink.ResumeLayout(False)
        Me.grpControlMavlink.PerformLayout()
        Me.grpControlAtto.ResumeLayout(False)
        Me.grpControlAtto.PerformLayout()
        Me.tabConfiguration.ResumeLayout(False)
        CType(Me.dgConfigVariable, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.tabPortJoystick.ResumeLayout(False)
        CType(Me.tbarJoystickMode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarJoystickRudder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarJoystickAileron, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarJoystickElevator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarJoystickThrottle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMapView.ResumeLayout(False)
        Me.tabViewMapView.ResumeLayout(False)
        Me.tabViewLiveCamera.ResumeLayout(False)
        Me.pnlDevice.ResumeLayout(False)
        Me.pnlLinkLost.ResumeLayout(False)
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
    Friend WithEvents tabConfiguration As System.Windows.Forms.TabPage
    Friend WithEvents dgConfigVariable As System.Windows.Forms.DataGridView
    Friend WithEvents tabMissionPlanning As System.Windows.Forms.TabPage
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
    Friend WithEvents cmdConfigRead As System.Windows.Forms.Button
    Friend WithEvents cmdConfigWrite As System.Windows.Forms.Button
    Friend WithEvents prgConfig As System.Windows.Forms.ProgressBar
    Friend WithEvents lblConfigStatus As System.Windows.Forms.Label
    Friend WithEvents grpMissionControlAtto As System.Windows.Forms.GroupBox
    Friend WithEvents lblMissionStatusAtto As System.Windows.Forms.Label
    Friend WithEvents prgMissionAtto As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdMissionAttoWrite As System.Windows.Forms.Button
    Friend WithEvents cmdMissionAttoRead As System.Windows.Forms.Button
    Friend WithEvents dgMission As System.Windows.Forms.DataGridView
    Friend WithEvents pnlDevice As System.Windows.Forms.Panel
    Friend WithEvents lblVehicle As System.Windows.Forms.Label
    Friend WithEvents cboConfigVehicle As System.Windows.Forms.ComboBox
    Friend WithEvents lblDevice As System.Windows.Forms.Label
    Friend WithEvents cboConfigDevice As System.Windows.Forms.ComboBox
    Friend WithEvents txtMissionAttoLongitude As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMissionAttoLatitude As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMissionAttoSpeed As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdMissionAttoSearch As System.Windows.Forms.Button
    Friend WithEvents txtMissionAddressSearchAtto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMissionAttoAltitude As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboMissionAttoLoiterDirection As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboMissionAttoLoiterDuration As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboMissionAttoLoiter As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboMissionAttoReversePath As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboMissionAttoAltitudeControl As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboMissionAttoTriggerControl As System.Windows.Forms.ComboBox
    Friend WithEvents cmdMissionSaveAs As System.Windows.Forms.Button
    Friend WithEvents cmdMissionNew As System.Windows.Forms.Button
    Friend WithEvents txtMissionDefaultAlt As System.Windows.Forms.TextBox
    Friend WithEvents lblMissionDefaultAlt As System.Windows.Forms.Label
    Friend WithEvents cmdReloadMissionDirectory As System.Windows.Forms.Button
    Friend WithEvents cmdReloadMissions As System.Windows.Forms.Button
    Friend WithEvents lblMissionLabel As System.Windows.Forms.Label
    Friend WithEvents cboMission As System.Windows.Forms.ComboBox
    Friend WithEvents txtMissionAttoDefaultSpeed As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblMissionDoubleClickLabel As System.Windows.Forms.Label
    Friend WithEvents chkMissionInsert As System.Windows.Forms.CheckBox
    Friend WithEvents grpMissionControlGeneric As System.Windows.Forms.GroupBox
    Friend WithEvents cmdMissionGenericSearch As System.Windows.Forms.Button
    Friend WithEvents txtMissionAddressSearchGeneric As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtMissionGenericAlt As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtMissionGenericLong As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtMissionGenericLat As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboMissionGenericOffset As System.Windows.Forms.ComboBox
    Friend WithEvents lblMissionHomeAlt As System.Windows.Forms.Label
    Friend WithEvents lblResolution As System.Windows.Forms.Label
    Friend WithEvents tabMissionControl As System.Windows.Forms.TabPage
    Friend WithEvents cmdMissionOverride As System.Windows.Forms.Button
    Friend WithEvents grpControlAtto As System.Windows.Forms.GroupBox
    Friend WithEvents cmdControlAttoReturnHome As System.Windows.Forms.Button
    Friend WithEvents cmdControlAttoResetBaro As System.Windows.Forms.Button
    Friend WithEvents cmdControlAttoLoiter As System.Windows.Forms.Button
    Friend WithEvents cmdControlAttoResume As System.Windows.Forms.Button
    Friend WithEvents txtControlAttoPressure As System.Windows.Forms.TextBox
    Friend WithEvents cmdControlAttoReturnRally As System.Windows.Forms.Button
    Friend WithEvents lblControlAttoStatus As System.Windows.Forms.Label
    Friend WithEvents txtControlAttoSpeed As System.Windows.Forms.TextBox
    Friend WithEvents cmdControlAttoSpeed As System.Windows.Forms.Button
    Friend WithEvents cmdControlAttoResetSpeed As System.Windows.Forms.Button
    Friend WithEvents cmdControlAttoResetMission As System.Windows.Forms.Button
    Friend WithEvents cmdControlAttoResetReboot As System.Windows.Forms.Button
    Friend WithEvents cboControlAttoWPNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSetHomeAlt As System.Windows.Forms.Button
    Friend WithEvents cmdMissionAttoAdd As System.Windows.Forms.Button
    Friend WithEvents cmdControlAttoTriggerServo As System.Windows.Forms.Button
    Friend WithEvents mnuJoystickCalibration As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabPortJoystick As System.Windows.Forms.TabPage
    Friend WithEvents lblJoystickRudder As System.Windows.Forms.Label
    Friend WithEvents lblJoystickAileron As System.Windows.Forms.Label
    Friend WithEvents lblJoystickElevator As System.Windows.Forms.Label
    Friend WithEvents tbarJoystickRudder As System.Windows.Forms.TrackBar
    Friend WithEvents tbarJoystickAileron As System.Windows.Forms.TrackBar
    Friend WithEvents tbarJoystickElevator As System.Windows.Forms.TrackBar
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblJoystickThrottle As System.Windows.Forms.Label
    Friend WithEvents tbarJoystickThrottle As System.Windows.Forms.TrackBar
    Friend WithEvents tmrJoystick As System.Windows.Forms.Timer
    Friend WithEvents chkJoystickEnable As System.Windows.Forms.CheckBox
    Friend WithEvents cmdJoystickCalibrate As System.Windows.Forms.Button
    Friend WithEvents lblJoystickDevice As System.Windows.Forms.Label
    Friend WithEvents cboJoystickOutput As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblJoystickMode As System.Windows.Forms.Label
    Friend WithEvents tbarJoystickMode As System.Windows.Forms.TrackBar
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlLinkLost As System.Windows.Forms.Panel
    Friend WithEvents lblLinkLostTime As System.Windows.Forms.Label
    Friend WithEvents lblLinkLostMessage As System.Windows.Forms.Label
    Friend WithEvents lblLinkLostLabel As System.Windows.Forms.Label
    Friend WithEvents lblLinkLostMessageType As System.Windows.Forms.Label
    Friend WithEvents chkViewHeadLock As System.Windows.Forms.CheckBox
    Friend WithEvents grpMissionControlMavlink As System.Windows.Forms.GroupBox
    Friend WithEvents cmdMissionMavlinkAdd As System.Windows.Forms.Button
    Friend WithEvents lblMissionStatusMavlink As System.Windows.Forms.Label
    Friend WithEvents prgMissionMavlink As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdMissionMavlinkWrite As System.Windows.Forms.Button
    Friend WithEvents cmdMissionMavlinkRead As System.Windows.Forms.Button
    Friend WithEvents txtMissionMavlinkArg1 As System.Windows.Forms.TextBox
    Friend WithEvents lblMissionMavlinkArg1 As System.Windows.Forms.Label
    Friend WithEvents cmdMissionMavlinkSearch As System.Windows.Forms.Button
    Friend WithEvents txtMissionAddressSearchMavlink As System.Windows.Forms.TextBox
    Friend WithEvents lblMissionAddressSearchMavlink As System.Windows.Forms.Label
    Friend WithEvents txtMissionMavlinkArg2 As System.Windows.Forms.TextBox
    Friend WithEvents lblMissionMavlinkArg2 As System.Windows.Forms.Label
    Friend WithEvents txtMissionMavlinkArg4 As System.Windows.Forms.TextBox
    Friend WithEvents lblMissionMavlinkArg4 As System.Windows.Forms.Label
    Friend WithEvents txtMissionMavlinkArg3 As System.Windows.Forms.TextBox
    Friend WithEvents lblMissionMavlinkArg3 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboMissionMavlinkCommand As System.Windows.Forms.ComboBox
    Friend WithEvents grpControlMavlink As System.Windows.Forms.GroupBox
    Friend WithEvents cboControlMavlinkAction As System.Windows.Forms.ComboBox
    Friend WithEvents cmdControlMavlinkAction As System.Windows.Forms.Button
    Friend WithEvents cboControlMavlinkMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblControlMavlinkStatus As System.Windows.Forms.Label
    Friend WithEvents cmdControlMavlinkMode As System.Windows.Forms.Button
    Friend WithEvents txtControlMavlinkSetAltitude As System.Windows.Forms.TextBox
    Friend WithEvents cmdControlMavlinkSetAltitude As System.Windows.Forms.Button
    Friend WithEvents cmdControlMavlinkSetHome As System.Windows.Forms.Button
    Friend WithEvents lblMissionAttoControlValue As System.Windows.Forms.Label
    Friend WithEvents lblMissionAttoDurationValue As System.Windows.Forms.Label
    Friend WithEvents lblMissionAttoLoiterValue As System.Windows.Forms.Label
    Friend WithEvents txtMissionMavlinkArg7 As System.Windows.Forms.TextBox
    Friend WithEvents txtMissionMavlinkArg6 As System.Windows.Forms.TextBox
    Friend WithEvents txtMissionMavlinkArg5 As System.Windows.Forms.TextBox
    Friend WithEvents lblMissionMavlinkArg5 As System.Windows.Forms.Label
    Friend WithEvents lblMissionMavlinkArg6 As System.Windows.Forms.Label
    Friend WithEvents lblMissionMavlinkArg7 As System.Windows.Forms.Label
    Friend WithEvents cboMissionMavlinkArg4 As System.Windows.Forms.ComboBox
    Friend WithEvents cboMissionMavlinkArg3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboMissionMavlinkArg2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboMissionMavlinkArg1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmdControlMavlinkRestartMission As System.Windows.Forms.Button
    Friend WithEvents cmdControlMavlinkGotoCommand As System.Windows.Forms.Button
    Friend WithEvents cboControlMavlinkWPNumber As System.Windows.Forms.ComboBox
    Friend WithEvents txtControlMavlinkAltRTL As System.Windows.Forms.TextBox
    Friend WithEvents cmdControlMavlinkAltRTL As System.Windows.Forms.Button
    Friend WithEvents txtControlMavlinkWPRadius As System.Windows.Forms.TextBox
    Friend WithEvents cmdControlMavlinkWPRadius As System.Windows.Forms.Button
    Friend WithEvents txtControlMavlinkLoiterRadius As System.Windows.Forms.TextBox
    Friend WithEvents cmdControlMavlinkLoiterRadius As System.Windows.Forms.Button
End Class
