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
        Me.tmrSearch = New System.Windows.Forms.Timer(Me.components)
        Me.tmrPlayback = New System.Windows.Forms.Timer(Me.components)
        Me.serialPortIn = New System.IO.Ports.SerialPort(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdExpandInstruments = New System.Windows.Forms.Button
        Me.cmdResetRuntime = New System.Windows.Forms.Button
        Me.cmdReloadComPorts = New System.Windows.Forms.Button
        Me.chkStepForward = New System.Windows.Forms.CheckBox
        Me.chkStepBack = New System.Windows.Forms.CheckBox
        Me.chkPause = New System.Windows.Forms.CheckBox
        Me.chkPlay = New System.Windows.Forms.CheckBox
        Me.cmdOutputFolder = New System.Windows.Forms.Button
        Me.chkRecord = New System.Windows.Forms.CheckBox
        Me.cmdReloadMissionDirectory = New System.Windows.Forms.Button
        Me.cmdReloadMissions = New System.Windows.Forms.Button
        Me.tbarModelScale = New System.Windows.Forms.TrackBar
        Me.chkReverse = New System.Windows.Forms.CheckBox
        Me.chkFullDataFile = New System.Windows.Forms.CheckBox
        Me.cmdReloadOutputFileList = New System.Windows.Forms.Button
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.mnuFile = New System.Windows.Forms.ToolStripDropDownButton
        Me.mnuSettings = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAbout = New System.Windows.Forms.ToolStripLabel
        Me.grpMisc = New System.Windows.Forms.GroupBox
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
        Me.tabPortControl = New System.Windows.Forms.TabControl
        Me.tabPortComPort = New System.Windows.Forms.TabPage
        Me.lblBandwidth = New System.Windows.Forms.Label
        Me.lblComPortStatus = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
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
        Me.cboOutputFiles = New System.Windows.Forms.ComboBox
        Me.TrackBar1 = New System.Windows.Forms.TrackBar
        Me.cmdViewFile = New System.Windows.Forms.Button
        Me.txtOutputFolder = New System.Windows.Forms.TextBox
        Me.tabPortMissions = New System.Windows.Forms.TabPage
        Me.Label26 = New System.Windows.Forms.Label
        Me.cboMission = New System.Windows.Forms.ComboBox
        Me.tabPortServos = New System.Windows.Forms.TabPage
        Me.lblServo8 = New System.Windows.Forms.Label
        Me.lblServo7 = New System.Windows.Forms.Label
        Me.lblServo6 = New System.Windows.Forms.Label
        Me.lblServo5 = New System.Windows.Forms.Label
        Me.lblServo4 = New System.Windows.Forms.Label
        Me.lblServo3 = New System.Windows.Forms.Label
        Me.lblServo2 = New System.Windows.Forms.Label
        Me.lblServo1 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbarServo8 = New System.Windows.Forms.TrackBar
        Me.tbarServo7 = New System.Windows.Forms.TrackBar
        Me.tbarServo6 = New System.Windows.Forms.TrackBar
        Me.tbarServo5 = New System.Windows.Forms.TrackBar
        Me.tbarServo4 = New System.Windows.Forms.TrackBar
        Me.tbarServo3 = New System.Windows.Forms.TrackBar
        Me.tbarServo2 = New System.Windows.Forms.TrackBar
        Me.tbarServo1 = New System.Windows.Forms.TrackBar
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
        Me.tabInstrumentLiveCamera = New System.Windows.Forms.TabPage
        Me.cmdLiveCameraProperties2 = New System.Windows.Forms.Button
        Me.cboLiveCameraSelect2 = New System.Windows.Forms.ComboBox
        Me.DirectShowControl2 = New HK_GCS.DirectShowControl.DirectShowControl
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
        Me.DirectShowControl1 = New HK_GCS.DirectShowControl.DirectShowControl
        CType(Me.tbarModelScale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.grpMisc.SuspendLayout()
        Me.tabPortControl.SuspendLayout()
        Me.tabPortComPort.SuspendLayout()
        Me.tabPortDataFile.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPortMissions.SuspendLayout()
        Me.tabPortServos.SuspendLayout()
        CType(Me.tbarServo8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarServo7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarServo6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarServo5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarServo4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarServo3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarServo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarServo1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabInstrumentView.SuspendLayout()
        Me.tabInstruments.SuspendLayout()
        Me.tabSerialData.SuspendLayout()
        Me.grpSerialSettings.SuspendLayout()
        Me.tabCommandLine.SuspendLayout()
        Me.tabInstrumentLiveCamera.SuspendLayout()
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
        '
        'cmdExpandInstruments
        '
        Me.cmdExpandInstruments.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExpandInstruments.Location = New System.Drawing.Point(3, 387)
        Me.cmdExpandInstruments.Name = "cmdExpandInstruments"
        Me.cmdExpandInstruments.Size = New System.Drawing.Size(24, 21)
        Me.cmdExpandInstruments.TabIndex = 34
        Me.cmdExpandInstruments.Text = ">>"
        Me.ToolTip1.SetToolTip(Me.cmdExpandInstruments, "Expand")
        Me.cmdExpandInstruments.UseVisualStyleBackColor = True
        '
        'cmdResetRuntime
        '
        Me.cmdResetRuntime.Location = New System.Drawing.Point(268, 141)
        Me.cmdResetRuntime.Name = "cmdResetRuntime"
        Me.cmdResetRuntime.Size = New System.Drawing.Size(26, 23)
        Me.cmdResetRuntime.TabIndex = 26
        Me.cmdResetRuntime.Text = "<"
        Me.ToolTip1.SetToolTip(Me.cmdResetRuntime, "Reset Run Timer")
        Me.cmdResetRuntime.UseVisualStyleBackColor = True
        '
        'cmdReloadComPorts
        '
        Me.cmdReloadComPorts.Location = New System.Drawing.Point(158, 13)
        Me.cmdReloadComPorts.Name = "cmdReloadComPorts"
        Me.cmdReloadComPorts.Size = New System.Drawing.Size(16, 23)
        Me.cmdReloadComPorts.TabIndex = 26
        Me.cmdReloadComPorts.Text = "<"
        Me.ToolTip1.SetToolTip(Me.cmdReloadComPorts, "Reload COM Port List")
        Me.cmdReloadComPorts.UseVisualStyleBackColor = True
        '
        'chkStepForward
        '
        Me.chkStepForward.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkStepForward.AutoSize = True
        Me.chkStepForward.Image = CType(resources.GetObject("chkStepForward.Image"), System.Drawing.Image)
        Me.chkStepForward.Location = New System.Drawing.Point(227, 40)
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
        Me.chkStepBack.Location = New System.Drawing.Point(200, 40)
        Me.chkStepBack.Name = "chkStepBack"
        Me.chkStepBack.Size = New System.Drawing.Size(26, 26)
        Me.chkStepBack.TabIndex = 20
        Me.ToolTip1.SetToolTip(Me.chkStepBack, "Step Back")
        Me.chkStepBack.UseVisualStyleBackColor = True
        '
        'chkPause
        '
        Me.chkPause.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkPause.AutoSize = True
        Me.chkPause.Image = CType(resources.GetObject("chkPause.Image"), System.Drawing.Image)
        Me.chkPause.Location = New System.Drawing.Point(78, 40)
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
        Me.chkPlay.Location = New System.Drawing.Point(51, 40)
        Me.chkPlay.Name = "chkPlay"
        Me.chkPlay.Size = New System.Drawing.Size(26, 26)
        Me.chkPlay.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.chkPlay, "Play")
        Me.chkPlay.UseVisualStyleBackColor = True
        '
        'cmdOutputFolder
        '
        Me.cmdOutputFolder.Location = New System.Drawing.Point(230, 119)
        Me.cmdOutputFolder.Name = "cmdOutputFolder"
        Me.cmdOutputFolder.Size = New System.Drawing.Size(23, 23)
        Me.cmdOutputFolder.TabIndex = 9
        Me.cmdOutputFolder.Text = "..."
        Me.ToolTip1.SetToolTip(Me.cmdOutputFolder, "Select Data File Directory")
        Me.cmdOutputFolder.UseVisualStyleBackColor = True
        '
        'chkRecord
        '
        Me.chkRecord.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkRecord.AutoSize = True
        Me.chkRecord.Image = CType(resources.GetObject("chkRecord.Image"), System.Drawing.Image)
        Me.chkRecord.Location = New System.Drawing.Point(12, 40)
        Me.chkRecord.Name = "chkRecord"
        Me.chkRecord.Size = New System.Drawing.Size(26, 26)
        Me.chkRecord.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.chkRecord, "Record")
        Me.chkRecord.UseVisualStyleBackColor = True
        '
        'cmdReloadMissionDirectory
        '
        Me.cmdReloadMissionDirectory.Location = New System.Drawing.Point(211, 14)
        Me.cmdReloadMissionDirectory.Name = "cmdReloadMissionDirectory"
        Me.cmdReloadMissionDirectory.Size = New System.Drawing.Size(20, 23)
        Me.cmdReloadMissionDirectory.TabIndex = 19
        Me.cmdReloadMissionDirectory.Text = "R"
        Me.ToolTip1.SetToolTip(Me.cmdReloadMissionDirectory, "Reload Mission")
        Me.cmdReloadMissionDirectory.UseVisualStyleBackColor = True
        '
        'cmdReloadMissions
        '
        Me.cmdReloadMissions.Location = New System.Drawing.Point(233, 14)
        Me.cmdReloadMissions.Name = "cmdReloadMissions"
        Me.cmdReloadMissions.Size = New System.Drawing.Size(20, 23)
        Me.cmdReloadMissions.TabIndex = 18
        Me.cmdReloadMissions.Text = "<"
        Me.ToolTip1.SetToolTip(Me.cmdReloadMissions, "Reload Mission Directory")
        Me.cmdReloadMissions.UseVisualStyleBackColor = True
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
        Me.ToolTip1.SetToolTip(Me.tbarModelScale, "Change Model Scale")
        Me.tbarModelScale.Value = 10
        '
        'chkReverse
        '
        Me.chkReverse.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkReverse.AutoSize = True
        Me.chkReverse.Enabled = False
        Me.chkReverse.Image = CType(resources.GetObject("chkReverse.Image"), System.Drawing.Image)
        Me.chkReverse.Location = New System.Drawing.Point(170, 40)
        Me.chkReverse.Name = "chkReverse"
        Me.chkReverse.Size = New System.Drawing.Size(26, 26)
        Me.chkReverse.TabIndex = 18
        Me.ToolTip1.SetToolTip(Me.chkReverse, "Rewind to Beginning")
        Me.chkReverse.UseVisualStyleBackColor = True
        '
        'chkFullDataFile
        '
        Me.chkFullDataFile.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkFullDataFile.Location = New System.Drawing.Point(121, 40)
        Me.chkFullDataFile.Name = "chkFullDataFile"
        Me.chkFullDataFile.Size = New System.Drawing.Size(43, 26)
        Me.chkFullDataFile.TabIndex = 22
        Me.chkFullDataFile.Text = "Full"
        Me.chkFullDataFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.chkFullDataFile, "Draw Full Mission")
        Me.chkFullDataFile.UseVisualStyleBackColor = True
        Me.chkFullDataFile.Visible = False
        '
        'cmdReloadOutputFileList
        '
        Me.cmdReloadOutputFileList.Location = New System.Drawing.Point(170, 12)
        Me.cmdReloadOutputFileList.Name = "cmdReloadOutputFileList"
        Me.cmdReloadOutputFileList.Size = New System.Drawing.Size(20, 23)
        Me.cmdReloadOutputFileList.TabIndex = 23
        Me.cmdReloadOutputFileList.Text = "R"
        Me.ToolTip1.SetToolTip(Me.cmdReloadOutputFileList, "Reload Output File List")
        Me.cmdReloadOutputFileList.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdExpandInstruments)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpMisc)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tabPortControl)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tabInstrumentView)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdExit)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdSetHome)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdClearMap)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdCenterOnPlane)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabMapView)
        Me.SplitContainer1.Size = New System.Drawing.Size(1222, 598)
        Me.SplitContainer1.SplitterDistance = 583
        Me.SplitContainer1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuAbout})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(583, 20)
        Me.ToolStrip1.TabIndex = 35
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSettings, Me.ToolStripMenuItem1, Me.mnuExit})
        Me.mnuFile.Image = CType(resources.GetObject("mnuFile.Image"), System.Drawing.Image)
        Me.mnuFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(36, 17)
        Me.mnuFile.Text = "File"
        '
        'mnuSettings
        '
        Me.mnuSettings.Name = "mnuSettings"
        Me.mnuSettings.Size = New System.Drawing.Size(124, 22)
        Me.mnuSettings.Text = "Settings"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(121, 6)
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(124, 22)
        Me.mnuExit.Text = "Exit"
        '
        'mnuAbout
        '
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(36, 17)
        Me.mnuAbout.Text = "About"
        '
        'grpMisc
        '
        Me.grpMisc.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.grpMisc.Controls.Add(Me.cmdResetRuntime)
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
        Me.grpMisc.Location = New System.Drawing.Point(279, 423)
        Me.grpMisc.Name = "grpMisc"
        Me.grpMisc.Size = New System.Drawing.Size(299, 167)
        Me.grpMisc.TabIndex = 33
        Me.grpMisc.TabStop = False
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
        'tabPortControl
        '
        Me.tabPortControl.Controls.Add(Me.tabPortComPort)
        Me.tabPortControl.Controls.Add(Me.tabPortDataFile)
        Me.tabPortControl.Controls.Add(Me.tabPortMissions)
        Me.tabPortControl.Controls.Add(Me.tabPortServos)
        Me.tabPortControl.Location = New System.Drawing.Point(5, 411)
        Me.tabPortControl.Name = "tabPortControl"
        Me.tabPortControl.SelectedIndex = 0
        Me.tabPortControl.Size = New System.Drawing.Size(272, 179)
        Me.tabPortControl.TabIndex = 32
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
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.lblGPSMessage.Location = New System.Drawing.Point(75, 93)
        Me.lblGPSMessage.Name = "lblGPSMessage"
        Me.lblGPSMessage.Size = New System.Drawing.Size(180, 13)
        Me.lblGPSMessage.TabIndex = 24
        Me.lblGPSMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(11, 95)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "GPS Msg:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGPSType
        '
        Me.lblGPSType.Location = New System.Drawing.Point(75, 72)
        Me.lblGPSType.Name = "lblGPSType"
        Me.lblGPSType.Size = New System.Drawing.Size(96, 13)
        Me.lblGPSType.TabIndex = 22
        Me.lblGPSType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(11, 69)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "GPS Type:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 43)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Baud Rate:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSearchCOM
        '
        Me.cmdSearchCOM.Location = New System.Drawing.Point(177, 13)
        Me.cmdSearchCOM.Name = "cmdSearchCOM"
        Me.cmdSearchCOM.Size = New System.Drawing.Size(78, 23)
        Me.cmdSearchCOM.TabIndex = 18
        Me.cmdSearchCOM.Text = "Search COM"
        Me.cmdSearchCOM.UseVisualStyleBackColor = True
        '
        'cmdConnect
        '
        Me.cmdConnect.Location = New System.Drawing.Point(177, 67)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(78, 23)
        Me.cmdConnect.TabIndex = 17
        Me.cmdConnect.Text = "Connect"
        Me.cmdConnect.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(177, 42)
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
        Me.lblComPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.tabPortDataFile.Location = New System.Drawing.Point(4, 22)
        Me.tabPortDataFile.Name = "tabPortDataFile"
        Me.tabPortDataFile.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPortDataFile.Size = New System.Drawing.Size(264, 153)
        Me.tabPortDataFile.TabIndex = 1
        Me.tabPortDataFile.Text = "Data File"
        Me.tabPortDataFile.UseVisualStyleBackColor = True
        '
        'cboOutputFiles
        '
        Me.cboOutputFiles.FormattingEnabled = True
        Me.cboOutputFiles.Location = New System.Drawing.Point(12, 13)
        Me.cboOutputFiles.Name = "cboOutputFiles"
        Me.cboOutputFiles.Size = New System.Drawing.Size(152, 21)
        Me.cboOutputFiles.TabIndex = 13
        '
        'TrackBar1
        '
        Me.TrackBar1.BackColor = System.Drawing.Color.White
        Me.TrackBar1.Enabled = False
        Me.TrackBar1.Location = New System.Drawing.Point(12, 69)
        Me.TrackBar1.Maximum = 9
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(241, 45)
        Me.TrackBar1.TabIndex = 12
        Me.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'cmdViewFile
        '
        Me.cmdViewFile.Location = New System.Drawing.Point(192, 12)
        Me.cmdViewFile.Name = "cmdViewFile"
        Me.cmdViewFile.Size = New System.Drawing.Size(61, 23)
        Me.cmdViewFile.TabIndex = 11
        Me.cmdViewFile.Text = "View File"
        Me.cmdViewFile.UseVisualStyleBackColor = True
        '
        'txtOutputFolder
        '
        Me.txtOutputFolder.Enabled = False
        Me.txtOutputFolder.Location = New System.Drawing.Point(12, 120)
        Me.txtOutputFolder.Name = "txtOutputFolder"
        Me.txtOutputFolder.Size = New System.Drawing.Size(212, 20)
        Me.txtOutputFolder.TabIndex = 8
        '
        'tabPortMissions
        '
        Me.tabPortMissions.Controls.Add(Me.cmdReloadMissionDirectory)
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
        'tabPortServos
        '
        Me.tabPortServos.Controls.Add(Me.lblServo8)
        Me.tabPortServos.Controls.Add(Me.lblServo7)
        Me.tabPortServos.Controls.Add(Me.lblServo6)
        Me.tabPortServos.Controls.Add(Me.lblServo5)
        Me.tabPortServos.Controls.Add(Me.lblServo4)
        Me.tabPortServos.Controls.Add(Me.lblServo3)
        Me.tabPortServos.Controls.Add(Me.lblServo2)
        Me.tabPortServos.Controls.Add(Me.lblServo1)
        Me.tabPortServos.Controls.Add(Me.Label23)
        Me.tabPortServos.Controls.Add(Me.Label21)
        Me.tabPortServos.Controls.Add(Me.Label20)
        Me.tabPortServos.Controls.Add(Me.Label8)
        Me.tabPortServos.Controls.Add(Me.Label7)
        Me.tabPortServos.Controls.Add(Me.Label3)
        Me.tabPortServos.Controls.Add(Me.Label2)
        Me.tabPortServos.Controls.Add(Me.Label1)
        Me.tabPortServos.Controls.Add(Me.tbarServo8)
        Me.tabPortServos.Controls.Add(Me.tbarServo7)
        Me.tabPortServos.Controls.Add(Me.tbarServo6)
        Me.tabPortServos.Controls.Add(Me.tbarServo5)
        Me.tabPortServos.Controls.Add(Me.tbarServo4)
        Me.tabPortServos.Controls.Add(Me.tbarServo3)
        Me.tabPortServos.Controls.Add(Me.tbarServo2)
        Me.tabPortServos.Controls.Add(Me.tbarServo1)
        Me.tabPortServos.Location = New System.Drawing.Point(4, 22)
        Me.tabPortServos.Name = "tabPortServos"
        Me.tabPortServos.Size = New System.Drawing.Size(264, 153)
        Me.tabPortServos.TabIndex = 3
        Me.tabPortServos.Text = "Servos"
        Me.tabPortServos.UseVisualStyleBackColor = True
        '
        'lblServo8
        '
        Me.lblServo8.Location = New System.Drawing.Point(207, 134)
        Me.lblServo8.Name = "lblServo8"
        Me.lblServo8.Size = New System.Drawing.Size(41, 12)
        Me.lblServo8.TabIndex = 23
        Me.lblServo8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblServo7
        '
        Me.lblServo7.Location = New System.Drawing.Point(207, 116)
        Me.lblServo7.Name = "lblServo7"
        Me.lblServo7.Size = New System.Drawing.Size(41, 12)
        Me.lblServo7.TabIndex = 22
        Me.lblServo7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblServo6
        '
        Me.lblServo6.Location = New System.Drawing.Point(207, 98)
        Me.lblServo6.Name = "lblServo6"
        Me.lblServo6.Size = New System.Drawing.Size(41, 12)
        Me.lblServo6.TabIndex = 21
        Me.lblServo6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblServo5
        '
        Me.lblServo5.Location = New System.Drawing.Point(207, 80)
        Me.lblServo5.Name = "lblServo5"
        Me.lblServo5.Size = New System.Drawing.Size(41, 12)
        Me.lblServo5.TabIndex = 20
        Me.lblServo5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblServo4
        '
        Me.lblServo4.Location = New System.Drawing.Point(207, 62)
        Me.lblServo4.Name = "lblServo4"
        Me.lblServo4.Size = New System.Drawing.Size(41, 12)
        Me.lblServo4.TabIndex = 19
        Me.lblServo4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblServo3
        '
        Me.lblServo3.Location = New System.Drawing.Point(207, 44)
        Me.lblServo3.Name = "lblServo3"
        Me.lblServo3.Size = New System.Drawing.Size(41, 12)
        Me.lblServo3.TabIndex = 18
        Me.lblServo3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblServo2
        '
        Me.lblServo2.Location = New System.Drawing.Point(207, 26)
        Me.lblServo2.Name = "lblServo2"
        Me.lblServo2.Size = New System.Drawing.Size(41, 12)
        Me.lblServo2.TabIndex = 17
        Me.lblServo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblServo1
        '
        Me.lblServo1.Location = New System.Drawing.Point(207, 9)
        Me.lblServo1.Name = "lblServo1"
        Me.lblServo1.Size = New System.Drawing.Size(41, 11)
        Me.lblServo1.TabIndex = 16
        Me.lblServo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(6, 134)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(24, 13)
        Me.Label23.TabIndex = 15
        Me.Label23.Text = "S8:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(6, 116)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(24, 13)
        Me.Label21.TabIndex = 14
        Me.Label21.Text = "S7:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(6, 98)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(24, 13)
        Me.Label20.TabIndex = 13
        Me.Label20.Text = "S6:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(6, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "S5:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(6, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "S4:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "S3:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "S2:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 14)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "S1:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbarServo8
        '
        Me.tbarServo8.AutoSize = False
        Me.tbarServo8.BackColor = System.Drawing.Color.White
        Me.tbarServo8.LargeChange = 1
        Me.tbarServo8.Location = New System.Drawing.Point(29, 131)
        Me.tbarServo8.Maximum = 2000
        Me.tbarServo8.Minimum = 1000
        Me.tbarServo8.Name = "tbarServo8"
        Me.tbarServo8.Size = New System.Drawing.Size(160, 18)
        Me.tbarServo8.TabIndex = 7
        Me.tbarServo8.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarServo8.Value = 1000
        '
        'tbarServo7
        '
        Me.tbarServo7.AutoSize = False
        Me.tbarServo7.BackColor = System.Drawing.Color.White
        Me.tbarServo7.LargeChange = 1
        Me.tbarServo7.Location = New System.Drawing.Point(29, 113)
        Me.tbarServo7.Maximum = 2000
        Me.tbarServo7.Minimum = 1000
        Me.tbarServo7.Name = "tbarServo7"
        Me.tbarServo7.Size = New System.Drawing.Size(160, 18)
        Me.tbarServo7.TabIndex = 6
        Me.tbarServo7.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarServo7.Value = 1000
        '
        'tbarServo6
        '
        Me.tbarServo6.AutoSize = False
        Me.tbarServo6.BackColor = System.Drawing.Color.White
        Me.tbarServo6.LargeChange = 1
        Me.tbarServo6.Location = New System.Drawing.Point(29, 95)
        Me.tbarServo6.Maximum = 2000
        Me.tbarServo6.Minimum = 1000
        Me.tbarServo6.Name = "tbarServo6"
        Me.tbarServo6.Size = New System.Drawing.Size(160, 18)
        Me.tbarServo6.TabIndex = 5
        Me.tbarServo6.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarServo6.Value = 1000
        '
        'tbarServo5
        '
        Me.tbarServo5.AutoSize = False
        Me.tbarServo5.BackColor = System.Drawing.Color.White
        Me.tbarServo5.LargeChange = 1
        Me.tbarServo5.Location = New System.Drawing.Point(29, 77)
        Me.tbarServo5.Maximum = 2000
        Me.tbarServo5.Minimum = 1000
        Me.tbarServo5.Name = "tbarServo5"
        Me.tbarServo5.Size = New System.Drawing.Size(160, 18)
        Me.tbarServo5.TabIndex = 4
        Me.tbarServo5.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarServo5.Value = 1000
        '
        'tbarServo4
        '
        Me.tbarServo4.AutoSize = False
        Me.tbarServo4.BackColor = System.Drawing.Color.White
        Me.tbarServo4.LargeChange = 1
        Me.tbarServo4.Location = New System.Drawing.Point(29, 59)
        Me.tbarServo4.Maximum = 2000
        Me.tbarServo4.Minimum = 1000
        Me.tbarServo4.Name = "tbarServo4"
        Me.tbarServo4.Size = New System.Drawing.Size(160, 18)
        Me.tbarServo4.TabIndex = 3
        Me.tbarServo4.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarServo4.Value = 1000
        '
        'tbarServo3
        '
        Me.tbarServo3.AutoSize = False
        Me.tbarServo3.BackColor = System.Drawing.Color.White
        Me.tbarServo3.LargeChange = 1
        Me.tbarServo3.Location = New System.Drawing.Point(29, 41)
        Me.tbarServo3.Maximum = 2000
        Me.tbarServo3.Minimum = 1000
        Me.tbarServo3.Name = "tbarServo3"
        Me.tbarServo3.Size = New System.Drawing.Size(160, 18)
        Me.tbarServo3.TabIndex = 2
        Me.tbarServo3.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarServo3.Value = 1000
        '
        'tbarServo2
        '
        Me.tbarServo2.AutoSize = False
        Me.tbarServo2.BackColor = System.Drawing.Color.White
        Me.tbarServo2.LargeChange = 1
        Me.tbarServo2.Location = New System.Drawing.Point(29, 23)
        Me.tbarServo2.Maximum = 2000
        Me.tbarServo2.Minimum = 1000
        Me.tbarServo2.Name = "tbarServo2"
        Me.tbarServo2.Size = New System.Drawing.Size(160, 18)
        Me.tbarServo2.TabIndex = 1
        Me.tbarServo2.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarServo2.Value = 1000
        '
        'tbarServo1
        '
        Me.tbarServo1.AutoSize = False
        Me.tbarServo1.BackColor = System.Drawing.Color.White
        Me.tbarServo1.LargeChange = 1
        Me.tbarServo1.Location = New System.Drawing.Point(29, 5)
        Me.tbarServo1.Maximum = 2000
        Me.tbarServo1.Minimum = 1000
        Me.tbarServo1.Name = "tbarServo1"
        Me.tbarServo1.Size = New System.Drawing.Size(160, 18)
        Me.tbarServo1.TabIndex = 0
        Me.tbarServo1.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbarServo1.Value = 1000
        '
        'tabInstrumentView
        '
        Me.tabInstrumentView.Controls.Add(Me.tabInstruments)
        Me.tabInstrumentView.Controls.Add(Me.tabSerialData)
        Me.tabInstrumentView.Controls.Add(Me.tabCommandLine)
        Me.tabInstrumentView.Controls.Add(Me.tabInstrumentLiveCamera)
        Me.tabInstrumentView.Location = New System.Drawing.Point(5, 28)
        Me.tabInstrumentView.Name = "tabInstrumentView"
        Me.tabInstrumentView.SelectedIndex = 0
        Me.tabInstrumentView.Size = New System.Drawing.Size(573, 395)
        Me.tabInstrumentView.TabIndex = 18
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
        Me.tabInstruments.Size = New System.Drawing.Size(565, 369)
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
        Me.tabSerialData.Size = New System.Drawing.Size(565, 369)
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
        Me.tabCommandLine.Size = New System.Drawing.Size(565, 369)
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
        'tabInstrumentLiveCamera
        '
        Me.tabInstrumentLiveCamera.Controls.Add(Me.cmdLiveCameraProperties2)
        Me.tabInstrumentLiveCamera.Controls.Add(Me.cboLiveCameraSelect2)
        Me.tabInstrumentLiveCamera.Controls.Add(Me.DirectShowControl2)
        Me.tabInstrumentLiveCamera.Location = New System.Drawing.Point(4, 22)
        Me.tabInstrumentLiveCamera.Name = "tabInstrumentLiveCamera"
        Me.tabInstrumentLiveCamera.Size = New System.Drawing.Size(565, 369)
        Me.tabInstrumentLiveCamera.TabIndex = 4
        Me.tabInstrumentLiveCamera.Text = "Live Camera"
        Me.tabInstrumentLiveCamera.UseVisualStyleBackColor = True
        '
        'cmdLiveCameraProperties2
        '
        Me.cmdLiveCameraProperties2.Location = New System.Drawing.Point(290, 13)
        Me.cmdLiveCameraProperties2.Name = "cmdLiveCameraProperties2"
        Me.cmdLiveCameraProperties2.Size = New System.Drawing.Size(84, 21)
        Me.cmdLiveCameraProperties2.TabIndex = 3
        Me.cmdLiveCameraProperties2.Text = "Properties"
        Me.cmdLiveCameraProperties2.UseVisualStyleBackColor = True
        '
        'cboLiveCameraSelect2
        '
        Me.cboLiveCameraSelect2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLiveCameraSelect2.FormattingEnabled = True
        Me.cboLiveCameraSelect2.Location = New System.Drawing.Point(62, 13)
        Me.cboLiveCameraSelect2.Name = "cboLiveCameraSelect2"
        Me.cboLiveCameraSelect2.Size = New System.Drawing.Size(221, 21)
        Me.cboLiveCameraSelect2.TabIndex = 2
        '
        'DirectShowControl2
        '
        Me.DirectShowControl2.Location = New System.Drawing.Point(65, 40)
        Me.DirectShowControl2.Name = "DirectShowControl2"
        Me.DirectShowControl2.Size = New System.Drawing.Size(400, 319)
        Me.DirectShowControl2.TabIndex = 1
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(509, 531)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(66, 23)
        Me.cmdExit.TabIndex = 44
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdSetHome
        '
        Me.cmdSetHome.Location = New System.Drawing.Point(187, 529)
        Me.cmdSetHome.Name = "cmdSetHome"
        Me.cmdSetHome.Size = New System.Drawing.Size(80, 23)
        Me.cmdSetHome.TabIndex = 45
        Me.cmdSetHome.Text = "Set Home"
        Me.cmdSetHome.UseVisualStyleBackColor = True
        '
        'cmdClearMap
        '
        Me.cmdClearMap.Location = New System.Drawing.Point(105, 529)
        Me.cmdClearMap.Name = "cmdClearMap"
        Me.cmdClearMap.Size = New System.Drawing.Size(80, 23)
        Me.cmdClearMap.TabIndex = 43
        Me.cmdClearMap.Text = "Clear Map"
        Me.cmdClearMap.UseVisualStyleBackColor = True
        '
        'cmdCenterOnPlane
        '
        Me.cmdCenterOnPlane.Location = New System.Drawing.Point(3, 529)
        Me.cmdCenterOnPlane.Name = "cmdCenterOnPlane"
        Me.cmdCenterOnPlane.Size = New System.Drawing.Size(100, 23)
        Me.cmdCenterOnPlane.TabIndex = 42
        Me.cmdCenterOnPlane.Text = "Center on Plane"
        Me.cmdCenterOnPlane.UseVisualStyleBackColor = True
        '
        'tabMapView
        '
        Me.tabMapView.Controls.Add(Me.tabViewMapView)
        Me.tabMapView.Controls.Add(Me.tabViewLiveCamera)
        Me.tabMapView.Location = New System.Drawing.Point(1, 6)
        Me.tabMapView.Name = "tabMapView"
        Me.tabMapView.SelectedIndex = 0
        Me.tabMapView.Size = New System.Drawing.Size(574, 517)
        Me.tabMapView.TabIndex = 36
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
        Me.tabViewMapView.Size = New System.Drawing.Size(566, 491)
        Me.tabViewMapView.TabIndex = 0
        Me.tabViewMapView.Text = "Map View"
        Me.tabViewMapView.UseVisualStyleBackColor = True
        '
        'chkViewFirstPerson
        '
        Me.chkViewFirstPerson.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkViewFirstPerson.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkViewFirstPerson.Location = New System.Drawing.Point(234, 471)
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
        Me.chkViewChaseCam.Location = New System.Drawing.Point(158, 471)
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
        Me.chkViewOverhead.Location = New System.Drawing.Point(82, 471)
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
        Me.tabViewLiveCamera.Size = New System.Drawing.Size(566, 491)
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
        Me.ClientSize = New System.Drawing.Size(1222, 598)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 400)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "HappyKillmore's Ground Control Station"
        CType(Me.tbarModelScale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grpMisc.ResumeLayout(False)
        Me.grpMisc.PerformLayout()
        Me.tabPortControl.ResumeLayout(False)
        Me.tabPortComPort.ResumeLayout(False)
        Me.tabPortComPort.PerformLayout()
        Me.tabPortDataFile.ResumeLayout(False)
        Me.tabPortDataFile.PerformLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPortMissions.ResumeLayout(False)
        Me.tabPortMissions.PerformLayout()
        Me.tabPortServos.ResumeLayout(False)
        CType(Me.tbarServo8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarServo7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarServo6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarServo5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarServo4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarServo3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarServo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarServo1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabInstrumentView.ResumeLayout(False)
        Me.tabInstruments.ResumeLayout(False)
        Me.tabSerialData.ResumeLayout(False)
        Me.tabSerialData.PerformLayout()
        Me.grpSerialSettings.ResumeLayout(False)
        Me.grpSerialSettings.PerformLayout()
        Me.tabCommandLine.ResumeLayout(False)
        Me.tabCommandLine.PerformLayout()
        Me.tabInstrumentLiveCamera.ResumeLayout(False)
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
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
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents lblDataPoints As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents lblTargetAlt As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lblLongitude As System.Windows.Forms.Label
    Friend WithEvents lblLatitude As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblLatitudeLabel As System.Windows.Forms.Label
    Friend WithEvents lblThrottle As System.Windows.Forms.Label
    Friend WithEvents lblMode As System.Windows.Forms.Label
    Friend WithEvents lblDistance As System.Windows.Forms.Label
    Friend WithEvents lblWaypoint As System.Windows.Forms.Label
    Friend WithEvents lblHDOP As System.Windows.Forms.Label
    Friend WithEvents lblBattery As System.Windows.Forms.Label
    Friend WithEvents lblSatellites As System.Windows.Forms.Label
    Friend WithEvents lblGPSLock As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tabPortControl As System.Windows.Forms.TabControl
    Friend WithEvents tabPortComPort As System.Windows.Forms.TabPage
    Friend WithEvents lblBandwidth As System.Windows.Forms.Label
    Friend WithEvents lblComPortStatus As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmdReloadComPorts As System.Windows.Forms.Button
    Friend WithEvents cboBaudRate As System.Windows.Forms.ComboBox
    Friend WithEvents lblGPSMessage As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblGPSType As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
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
    Friend WithEvents tabPortMissions As System.Windows.Forms.TabPage
    Friend WithEvents cmdReloadMissionDirectory As System.Windows.Forms.Button
    Friend WithEvents cmdReloadMissions As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cboMission As System.Windows.Forms.ComboBox
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
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.ToolStripLabel
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
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblServo8 As System.Windows.Forms.Label
    Friend WithEvents lblServo7 As System.Windows.Forms.Label
    Friend WithEvents lblServo6 As System.Windows.Forms.Label
    Friend WithEvents lblServo5 As System.Windows.Forms.Label
    Friend WithEvents lblServo4 As System.Windows.Forms.Label
    Friend WithEvents lblServo3 As System.Windows.Forms.Label
    Friend WithEvents lblServo2 As System.Windows.Forms.Label
    Friend WithEvents lblServo1 As System.Windows.Forms.Label
End Class
