Imports System.IO
Imports DirectShowLib
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System
Imports System.Globalization
Imports System.Resources

Public Class frmMain
    'Public Declare Function OleCreatePropertyFrame Lib "oleaut32.dll" (ByVal hwndOwner As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal lpszCaption As String, ByVal cObjects As Integer, ByRef ppUnk As Object, ByVal cPages As Integer, ByVal lpPageClsID As IntPtr, ByVal lcid As Integer, ByVal dwReserved As Integer, ByVal lpvReserved As IntPtr) As Integer
    'Declare Function OleCreatePropertyFrame Lib "oleaut32.dll" (ByVal hwndOwner As IntPtr, ByVal x As Long, ByVal y As Long, <MarshalAs(UnmanagedType.LPWStr)> ByVal lpszCaption As String, ByVal cObjects As Integer, <MarshalAs(UnmanagedType.Interface, ArraySubType:=UnmanagedType.IUnknown)> ByRef ppUnk As System.IntPtr, ByVal cPages As Long, ByVal pPageClsID As IntPtr, ByVal lcid As Integer, ByVal dwReserved As Integer, ByVal pvReserved As IntPtr) As Integer
    Declare Function OleCreatePropertyFrame Lib "oleaut32.dll" (ByVal hwndOwner As IntPtr, ByVal x As Long, ByVal y As Long, <MarshalAs(UnmanagedType.LPWStr)> ByVal lpszCaption As String, ByVal cObjects As Integer, ByRef ppUnk As Object, ByVal cPages As Long, ByVal pPageClsID As IntPtr, ByVal lcid As Integer, ByVal dwReserved As Integer, ByVal pvReserved As IntPtr) As Integer

    Private mediaControl As IMediaControl = Nothing
    'Private graphBuilder As IGraphBuilder = Nothing
    Private theCompressor As IBaseFilter = Nothing
    Public caGUID As DsCAUUID = New DsCAUUID()

    Dim bShutdown As Boolean = False

    Dim nHomeLat As String = ""
    Dim nHomeLong As String
    Dim webDocument As Object
    Dim nLastGPS As Long
    Dim nLastMapUpdate As Long

    Dim sOutputFile As StreamWriter
    Dim rawData(0) As String
    Dim nDataIndex As Long

    'Public Event AttitudeChange(ByVal pitch As Single, ByVal roll As Single, ByVal yaw As Single)
    'Public Event GpsData(ByVal latitude As String, ByVal longitude As String, ByVal altitude As Single, ByVal speed As Single, ByVal heading As Single, ByVal satellites As Integer, ByVal fix As Integer, ByVal hdop As Single, ByVal verticalChange As Single)
    'Public Event Waypoints(ByVal waypointNumber As Integer, ByVal distance As Single)
    'Public Event RawPacket(ByVal messageString As String)

    Dim baudRates() As Long = {4800, 9600, 19200, 38400, 57600, 115200}
    'Dim baudRates() As Long = {38400, 57600, 19200, 9600, 115200, 4800}
    Dim nBaudRateIndex As Integer = 3
    Dim sBuffer As String
    Dim sCommandLineBuffer As String

    Dim nMaxListboxRecords As Integer = 200

    Dim eSelectedInstrument As e_Instruments = e_Instruments.e_Instruments_None

    Dim nWaypoint As Integer
    Dim nWaypointAlt As Single
    Dim nDistance As Single

    Dim bStartup As Boolean = True
    Dim bButtonStateLocked As Boolean = False

    Dim bNewGPS As Boolean
    Dim bNewAttitude As Boolean
    Dim bNewWaypoint As Boolean
    Dim bNewServo As Boolean
    Dim dStartTime As Date

    Dim nAttitudeInterval As Integer
    Dim nWaypointInterval As Integer
    Dim nGPSInterval As Integer
    Dim nLastAttitude As Long
    Dim nLastWaypoint As Long
    'Dim nLastGPS As Long
    Dim nLastAlt As Single
    Dim nDataPoints As Long
    Dim bIsRecording As Boolean = False

    Dim sSelectedCamera1 As String
    Dim sSelectedCamera2 As String

    'Dim eOutputDistance As e_DistanceFormat
    'Dim eOutputSpeed As e_SpeedFormat
    Dim eOutputLatLongFormat As e_LatLongFormat = e_LatLongFormat.e_LatLongFormat_DD_DDDDDD
    Dim eMapSelection As e_MapSelection = e_MapSelection.e_MapSelection_GoogleEarth

    Dim nLastComPort As Integer
    Dim bFirstPaint As Boolean = False
    Dim bFirstVideoCapture1 As Boolean = False
    Dim bFirstVideoCapture2 As Boolean = False

    Dim nPlayerState As e_PlayerState

    'Dim bWaypointExtrude As Boolean = True
    'Dim sWaypointColor As String = "00ffffff"
    'Dim nWaypointWidth As Integer = 1

    Dim nCameraTracking As Integer
    Dim nCommandLineDelim As Integer

    Dim nInputStringLength As Long
    Dim nLastBandwidthCheck As Long

    Dim bExpandInstruments As Boolean = False
    Dim bUltraSmall As Boolean = False

    'Private GraphBuilder2 As ICaptureGraphBuilder2 = New CaptureGraphBuilder2
    'Private GraphBuilder As IGraphBuilder = New FilterGraph
    'Private m_filtergraph As IFilterGraph2 = New FilterGraph
    'Private CapFilter As IBaseFilter = Nothing
    'Private mediaCtrl As DirectShowLib.IMediaControl = Nothing
    'Private vmr9 As IBaseFilter = New VideoMixingRenderer9
    'Private hr As Integer
    'Private SampGrabber As ISampleGrabber = New SampleGrabber
    'Private baseGrabFlt As IBaseFilter = SampGrabber
    'Private windowlessCtrl As IVMRWindowlessControl9 = Nothing
    'Private capGraph As ICaptureGraphBuilder2 = Nothing


    Public Sub ResetForm()
        GetResString(mnuFile, "File")
        GetResString(mnuSettings, "Settings")
        GetResString(mnuExit, "Exit_Label")
        GetResString(mnuHelp, "Help")
        GetResString(mnuOpenHomepage, "Open_Homepage")
        GetResString(mnuOpenDownloads, "Open_Downloads")
        GetResString(mnuAbout, "About")

        GetResString(tabInstruments, "Instruments")
        GetResString(tabSerialData, "Serial Data")
        GetResString(tabCommandLine, "Command Line")
        GetResString(tabInstrumentLiveCamera, "Live Camera")

        GetResString(tabViewMapView, "Map View")
        GetResString(tabViewLiveCamera, "Live Camera")

        GetResString(cmdSetNorth, "Zero Yaw")
        GetResString(lblRawData, "Raw Data")

        GetResString(lblTranslatedData, "Translated Data")
        GetResString(grpSerialSettings, "Serial Settings")
        GetResString(lblMaxAttitude, "Max Attitude")
        GetResString(lblMaxGPS, "Max GPS")
        GetResString(lblMaxWaypoint, "Max Waypoint")

        GetResString(cmdCommandLineSend, "Send")
        GetResString(chkCommandLineAutoScroll, "Auto Scroll")

        GetResString(cmdLiveCameraProperties1, "Properties")
        GetResString(cmdLiveCameraProperties2, "Properties")

        GetResString(chkViewNoTracking, "No Tracking")
        GetResString(chkViewOverhead, "Overhead")
        GetResString(chkViewChaseCam, "Chase Cam")
        GetResString(chkViewFirstPerson, "First Person")

        GetResString(cmdCenterOnPlane, "Center On Plane")
        GetResString(cmdSetHome, "Set Home")
        GetResString(cmdClearMap, "Clear Map")
        GetResString(cmdExit, "Exit_Label")

        GetResString(tabPortComPort, "COM Port")
        GetResString(tabPortDataFile, "Data File")
        GetResString(tabPortMissions, "Mission")
        GetResString(tabPortServos, "Servos")
        GetResString(tabPortSensors, "Sensors")

        GetResString(lblComPort, "COM Port", True)
        GetResString(lblBaudRate, "Baud Rate", True)
        GetResString(lblGPSTypeLabel, "GPS Type", True)
        GetResString(lblGPSMessageLabel, "GPS Message", True)
        GetResString(lblStatusLabel, "Status", True)

        GetResString(cmdSearch, "Search Baud")
        GetResString(cmdSearchCOM, "Search COM")
        GetResString(cmdConnect, "Connect")

        ToolTip1.SetToolTip(cmdReloadComPorts, GetResString(, "Reload_Com_Port_List"))
        ToolTip1.SetToolTip(cmdReloadOutputFileList, GetResString(, "Reload_Output_File_List"))
        GetResString(cmdReloadOutputFileList, "Reload_Letter")
        GetResString(cmdViewFile, "View File")
        ToolTip1.SetToolTip(chkPlay, GetResString(, "Play"))
        ToolTip1.SetToolTip(chkPause, GetResString(, "Pause"))
        ToolTip1.SetToolTip(chkFullDataFile, GetResString(, "Draw_Full_Mission"))
        GetResString(chkFullDataFile, GetResString(, "Full"))
        ToolTip1.SetToolTip(chkReverse, GetResString(, "Rewind_To_Beginning"))
        ToolTip1.SetToolTip(chkStepBack, GetResString(, "Step Back"))
        ToolTip1.SetToolTip(chkStepForward, GetResString(, "Step Forward"))
        ToolTip1.SetToolTip(cmdOutputFolder, GetResString(, "Select_Data_File_Directory"))

        GetResString(lblMissionLabel, "Mission", True)
        ToolTip1.SetToolTip(cmdReloadMissionDirectory, GetResString(, "Reload_Mission"))
        GetResString(cmdReloadMissionDirectory, "Reload_Letter")
        ToolTip1.SetToolTip(cmdReloadMissions, GetResString(, "Reload_Mission_Directory"))

        GetResString(lblGPSLockLabel, "GPS Lock", True)
        GetResString(lblSatellitesLabel, "Satellites", True)
        GetResString(lblModeLabel, "Mode", True)
        GetResString(lblThrottleLabel, "Throttle", True)
        GetResString(lblWaypointLabel, "Waypoint", True)
        GetResString(lblDistanceLabel, "Distance", True)
        GetResString(lblTargetAltLabel, "Target Alt", True)

        GetResString(lblBatteryLabel, "Battery", True)
        GetResString(lblAmpsLabel, "Amps", True)
        GetResString(lblHDOPLabel, "HDOP", True)
        GetResString(lblLatitudeLabel, "Latitude", True)
        GetResString(lblLongitudeLabel, "Longitude", True)
        GetResString(lblRunTimeLabel, "Run Time", True)
        GetResString(lblDatapointsLabel, "Data Points", True)

        ToolTip1.SetToolTip(cmdResetRuntime, GetResString(, "Reset_Run_Timer"))

        ToolTip1.SetToolTip(tbarModelScale, GetResString(, "Change_Model_Scale"))
    End Sub

    Private Sub SetPlayerState(ByVal newState As e_PlayerState, Optional ByVal fileExists As Boolean = False, Optional ByVal fullPlay As Boolean = False)
        Dim bRecord As Boolean
        Dim bPlay As Boolean
        Dim bPause As Boolean
        Dim bReverse As Boolean
        Dim bFastForward As Boolean
        Dim bStepReverse As Boolean
        Dim bStepForward As Boolean
        Dim bLoaded As Boolean
        Dim bRecordReady As Boolean
        Dim bFullPlay As Boolean

        nPlayerState = newState
        bFullPlay = fullPlay
        Select Case nPlayerState
            Case e_PlayerState.e_PlayerState_None
                bRecord = False
                bPlay = False
                bPause = False
                bReverse = False
                bFastForward = False
                bStepReverse = False
                bStepForward = False
                bLoaded = False
                bRecordReady = False
                bFullPlay = False
            Case e_PlayerState.e_PlayerState_Loaded
                bRecord = False
                bPlay = False
                bPause = False
                bReverse = False
                bFastForward = False
                bStepReverse = False
                bStepForward = False
                bLoaded = True
                bRecordReady = True
                bFullPlay = False
            Case e_PlayerState.e_PlayerState_RecordReady
                bRecord = False
                bPlay = False
                bPause = False
                bReverse = False
                bFastForward = False
                bStepReverse = False
                bStepForward = False
                bLoaded = False
                bRecordReady = True
                bFullPlay = False
            Case e_PlayerState.e_PlayerState_Play
                bRecord = False
                bPlay = True
                bPause = False
                bReverse = False
                bFastForward = False
                bStepReverse = False
                bStepForward = False
                bLoaded = True
                bRecordReady = False
            Case e_PlayerState.e_PlayerState_Record
                bRecord = True
                bPlay = False
                bPause = False
                bReverse = False
                bFastForward = False
                bStepReverse = False
                bStepForward = False
                bLoaded = fileExists
                bRecordReady = True
                bFullPlay = False
            Case e_PlayerState.e_PlayerState_Pause, e_PlayerState.e_PlayerState_StepBack, e_PlayerState.e_PlayerState_StepForward
                bRecord = False
                bPlay = False
                bPause = True
                bReverse = False
                bFastForward = False
                bStepReverse = False
                bStepForward = False
                bLoaded = True
                bRecordReady = True
                bFullPlay = False
        End Select

        If bRecord = True Then
            nDataIndex = 0
            TrackBar1.Value = 0
        End If

        bButtonStateLocked = True
        chkRecord.Checked = bRecord
        chkPlay.Checked = bPlay
        chkPause.Checked = bPause
        chkReverse.Checked = bReverse
        chkStepBack.Checked = False
        chkStepForward.Checked = False
        chkFullDataFile.Checked = bFullPlay

        chkRecord.Enabled = bRecordReady
        chkPlay.Enabled = bLoaded
        chkPause.Enabled = bLoaded
        chkReverse.Enabled = bLoaded
        If bLoaded = True And nDataIndex > 1 Then
            chkStepBack.Enabled = bLoaded
        Else
            chkStepBack.Enabled = False
        End If
        If bLoaded = True And nDataIndex < UBound(rawData) Then
            chkStepForward.Enabled = bLoaded
        Else
            chkStepForward.Enabled = False
        End If
        chkFullDataFile.Enabled = bLoaded
        If bRecord = True Then
            chkRecord.Image = My.Resources.AvionicsInstrumentsControlsRessources.StopRed
            ToolTip1.SetToolTip(chkRecord, GetResString(, "Stop Recording"))
        Else
            chkRecord.Image = My.Resources.AvionicsInstrumentsControlsRessources.Record
            ToolTip1.SetToolTip(chkRecord, GetResString(, "Record"))
        End If
        cmdViewFile.Enabled = bLoaded
        TrackBar1.Enabled = bLoaded

        bButtonStateLocked = False
    End Sub
    Private Sub FormClosing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub frmMain_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bInstruments(e_Instruments.e_Instruments_3DModel) = True Then
            _3DMesh1.DrawMesh(GetPitch(nPitch), GetRoll(nRoll), GetYaw(nYaw), False, sModelName, GetRootPath() & "3D Models\")
            'System.Diagnostics.Debug.Print("Actvated " & Now)
        End If
    End Sub

    Private Sub frmMain_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            bShutdown = True
            If Not sOutputFile Is Nothing Then
                sOutputFile.Close()
                sOutputFile = Nothing
            End If

            tmrSearch.Enabled = False
            If serialPortIn.IsOpen = True Then
                serialPortIn.Close()
            End If
        Catch e2 As Exception
        End Try
    End Sub
    Private Sub SetupWebBroswer()
        If eMapSelection = e_MapSelection.e_MapSelection_GoogleMaps Then
            WebBrowser1.Navigate(GetRootPath() & "Maps.html")
        Else
            WebBrowser1.DocumentText = My.Resources.GoogleResources.pluginhost.ToString
            'WebBrowser1.Navigate(GetRootPath & "pluginhost.html")
        End If

        While WebBrowser1.ReadyState <> 4
            Application.DoEvents()
        End While
        webDocument = WebBrowser1.Document

        If eMapSelection = e_MapSelection.e_MapSelection_GoogleMaps Then
            webDocument.GetElementById("lockDragDrop").SetAttribute("value", "Locked")
        End If

    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nCount As Integer
        Dim nTop As Long
        Dim nLeft As Long
        Dim nWidth As Long
        Dim nHeight As Long
        Dim nSplitter As Long

        resourceMgr = ResourceManager.CreateFileBasedResourceManager("Strings", GetRootPath() & "Language", Nothing)

        bStartup = True
        frmAbout.bIsSplash = True
        frmAbout.Show()

        ResetForm()

        Me.Visible = False
        nWidth = GetRegSetting(sRootRegistry & "\Settings", "Form Width", 1100)
        nHeight = GetRegSetting(sRootRegistry & "\Settings", "Form Height", 675)
        nTop = GetRegSetting(sRootRegistry & "\Settings", "Form Top", Screen.PrimaryScreen.WorkingArea.Height / 2 - nHeight / 2)
        nLeft = GetRegSetting(sRootRegistry & "\Settings", "Form Left", Screen.PrimaryScreen.WorkingArea.Width / 2 - nWidth / 2)
        nSplitter = GetRegSetting(sRootRegistry & "\Settings", "Splitter Location", 590)

        If nWidth > Screen.PrimaryScreen.WorkingArea.Width Then
            nWidth = Screen.PrimaryScreen.WorkingArea.Width
        End If
        If nHeight > Screen.PrimaryScreen.WorkingArea.Height Then
            nHeight = Screen.PrimaryScreen.WorkingArea.Width
        End If

        SplitContainer1.Panel1MinSize = 320
        SplitContainer1.Panel2MinSize = 340

        eSelectedInstrument = GetRegSetting(sRootRegistry & "\Settings", "Selected Instrument", e_Instruments.e_Instruments_None)
        sSelectedCamera1 = GetRegSetting(sRootRegistry & "\Settings", "Selected Camera 1", "")
        sSelectedCamera2 = GetRegSetting(sRootRegistry & "\Settings", "Selected Camera 2", "")

        frmAbout.UpdateStatus(GetResString(, "Building_Map_Files"), 10)
        If Dir(GetRootPath() & "Maps.html") = "" Then
            Dim sFileContents As String = HK_GCS.My.Resources.GoogleResources.Maps.ToString
            Dim fs As New FileStream(GetRootPath() & "Maps.html", FileMode.Create, FileAccess.Write)
            Dim sMapsFile As StreamWriter = New StreamWriter(fs)

            sMapsFile.WriteLine(sFileContents)
            sMapsFile.Close()
        End If

        If Dir(GetRootPath() & "Missions", FileAttribute.Directory) = "" Then
            MkDir(GetRootPath() & "Missions")
        End If

        Try
            InitServoCombos()
            cboServo1.Text = GetRegSetting(sRootRegistry & "\Settings", "Servo 1", "Servo 1 In")
            cboServo2.Text = GetRegSetting(sRootRegistry & "\Settings", "Servo 2", "Servo 2 In")
            cboServo3.Text = GetRegSetting(sRootRegistry & "\Settings", "Servo 3", "Servo 3 In")
            cboServo4.Text = GetRegSetting(sRootRegistry & "\Settings", "Servo 4", "Servo 4 In")
            cboServo5.Text = GetRegSetting(sRootRegistry & "\Settings", "Servo 5", "Servo 1 Out")
            cboServo6.Text = GetRegSetting(sRootRegistry & "\Settings", "Servo 6", "Servo 2 Out")
            cboServo7.Text = GetRegSetting(sRootRegistry & "\Settings", "Servo 7", "Servo 3 Out")
            cboServo8.Text = GetRegSetting(sRootRegistry & "\Settings", "Servo 8", "Servo 4 Out")

            cboSensors1.Text = GetRegSetting(sRootRegistry & "\Settings", "Sensor 1", "X Accel")
            cboSensors2.Text = GetRegSetting(sRootRegistry & "\Settings", "Sensor 2", "Y Accel")
            cboSensors3.Text = GetRegSetting(sRootRegistry & "\Settings", "Sensor 3", "Z Accel")
            cboSensors4.Text = GetRegSetting(sRootRegistry & "\Settings", "Sensor 4", "X Gyro")
            cboSensors5.Text = GetRegSetting(sRootRegistry & "\Settings", "Sensor 5", "Y Gyro")
            cboSensors6.Text = GetRegSetting(sRootRegistry & "\Settings", "Sensor 6", "Z Gyro")
            cboSensors7.Text = GetRegSetting(sRootRegistry & "\Settings", "Sensor 7", "None")
            cboSensors8.Text = GetRegSetting(sRootRegistry & "\Settings", "Sensor 8", "None")
        Catch
        End Try

        Me.Text = "HappyKillmore's " & GetResString(, "Ground_Control_Station") & " - " & Version

        txtOutputFolder.Text = GetRegSetting(sRootRegistry & "\Settings", "OutputFolder", GetRootPath)
        LoadOutputFiles()

        Dim i As Integer

        Control.CheckForIllegalCrossThreadCalls = False

        frmAbout.UpdateStatus(GetResString(, "Setting_Up_Comboboxes"), 20)

        cboAttitude.Items.Add(GetResString(, "None"))
        cboGPS.Items.Add(GetResString(, "None"))
        cboWaypoint.Items.Add(GetResString(, "None"))
        For i = 1 To 20
            cboAttitude.Items.Add(i & " Hz")
            If i <= 10 Then
                cboGPS.Items.Add(i & " Hz")
                cboWaypoint.Items.Add(i & " Hz")
            End If
        Next
        cboAttitude.SelectedIndex = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Attitude Hz", "5"))
        cboGPS.SelectedIndex = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "GPS Hz", "2"))
        cboWaypoint.SelectedIndex = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Waypoint Hz", "2"))

        With cboCommandLineDelim
            .Items.Add(GetResString(, "No_line_ending"))
            .Items.Add(GetResString(, "Line Feed"))
            .Items.Add(GetResString(, "Carriage Return"))
            .Items.Add(GetResString(, "Line Feed Carriage Return"))
            .SelectedIndex = GetRegSetting(sRootRegistry & "\Settings", "Command Line Delim", "2")
            nCommandLineDelim = .SelectedIndex
        End With

        frmAbout.UpdateStatus(GetResString(, "Loading Settings"), 30)

        LoadSettings()

        LoadComboEntries(cboCommandLineCommand)
        LoadMissions()

        tbarModelScale.Value = GetRegSetting(sRootRegistry & "\Settings", "Model Scale", "10")

        chkCommandLineAutoScroll.Checked = GetRegSetting(sRootRegistry & "\Settings", "Command Line Auto Scroll", True)

        'UpdateLineColor()

        'bWaypointExtrude = GetRegSetting(sRootRegistry & "\Settings", "WP Extrude", True)
        'chkWaypointExtrude.Checked = bWaypointExtrude

        frmAbout.UpdateStatus(GetResString(, "Setting_Up_Webbrowser"), 40)

        SetupWebBroswer()

        'WebBrowser1.Document().Body.InnerHtml = HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.Maps.ToString
        'WebBrowser1.Navigate(GetRootPath & "Maps.html")

        eMapSelection = e_MapSelection.e_MapSelection_GoogleEarth

        frmAbout.UpdateStatus(GetResString(, "Loading_COM_Ports"), 50)

        LoadComPorts()
        SetPlayerState(e_PlayerState.e_PlayerState_None)

        With cboBaudRate
            For nCount = LBound(baudRates) To UBound(baudRates)
                .Items.Add(baudRates(nCount))
                If GetRegSetting(sRootRegistry & "\Settings", "Baud Rate", "38400") = baudRates(nCount) Then
                    .SelectedIndex = nCount
                End If
            Next
            If .SelectedIndex = -1 Then
                .SelectedIndex = 3
            End If
        End With

        lblGPSLock.Text = ""
        lblSatellites.Text = ""
        lblHDOP.Text = ""
        lblAmperage.Text = ""
        lblBattery.Text = ""
        lblWaypoint.Text = ""
        lblDistance.Text = ""
        lblMode.Text = ""
        lblThrottle.Text = ""
        lblLatitude.Text = ""
        lblLongitude.Text = ""
        lblTargetAlt.Text = ""
        lblDataPoints.Text = ""
        lblRunTime.Text = ""
        nDataPoints = 1
        sMode = ""
        sModeNumber = ""

        SplitContainer1.SplitterDistance = nSplitter
        Me.WindowState = GetRegSetting(sRootRegistry & "\Settings", "Form WindowState", FormWindowState.Normal)
        If Me.WindowState = FormWindowState.Normal Then
            Me.Width = nWidth
            Me.Height = nHeight
            Me.Left = nLeft
            Me.Top = nTop
        End If
        bStartup = False

        frmAbout.UpdateStatus(GetResString(, "Resizing_Form"), 80)

        ResizeForm()

        frmAbout.UpdateStatus("", 100)
        frmAbout.Dispose()
        Me.Visible = True

        'If cboComPort.Items.Count > 0 Then
        '    cboComPort.SelectedIndex = 0
        'End If

        'DirectShowControl1.StartCapture()

    End Sub
    Private Sub LoadComPorts(Optional ByVal defaultComPort As String = "")
        Dim i As Integer
        Dim sSavedComPort As String

        cboComPort.Items.Clear()
        Try
            For i = 0 To My.Computer.Ports.SerialPortNames.Count - 1
                If Strings.Left(My.Computer.Ports.SerialPortNames(i), 3) = "COM" Then
                    cboComPort.Items.Add(My.Computer.Ports.SerialPortNames(i))
                End If
            Next
            sSavedComPort = GetRegSetting(sRootRegistry & "\Settings", "COM Port", "")
            For i = 0 To cboComPort.Items.Count - 1
                If defaultComPort = "" Then
                    If cboComPort.Items(i) = sSavedComPort Then
                        cboComPort.Text = sSavedComPort
                        Exit For
                    End If
                Else
                    If My.Computer.Ports.SerialPortNames(i) = defaultComPort Then
                        cboComPort.Text = defaultComPort
                        Exit For
                    End If
                End If
            Next
            If cboComPort.Items.Count > 0 And cboComPort.SelectedIndex = -1 Then
                cboComPort.SelectedIndex = 0
                'Else
                '    cmdSearch_Click(sender, e)
            End If
        Catch e2 As Exception
        End Try
        nBaudRateIndex = 0

    End Sub
    Private Sub LoadMissions()
        Dim sMission As String
        With cboMission
            .Items.Clear()
            sMission = Dir(GetRootPath() & "Missions\*.txt", FileAttribute.Normal)
            Do While sMission <> ""
                .Items.Add(sMission)
                sMission = Dir()
            Loop
            sMission = Dir(GetRootPath() & "Missions\*.h", FileAttribute.Normal)
            Do While sMission <> ""
                .Items.Add(sMission)
                sMission = Dir()
            Loop
        End With
    End Sub

    Private Sub LoadOutputFiles(Optional ByVal selectedFile As String = "")
        Dim nCount As Int16
        Dim sFilename As String
        With cboOutputFiles
            sFilename = Dir(txtOutputFolder.Text & "*.hko", FileAttribute.Normal)
            .Items.Clear()
            Do While sFilename <> ""
                .Items.Add(sFilename)
                sFilename = Dir()
            Loop
            sFilename = Dir(txtOutputFolder.Text & "*.txt", FileAttribute.Normal)
            Do While sFilename <> ""
                .Items.Add(sFilename)
                sFilename = Dir()
            Loop

            For nCount = 0 To .Items.Count - 1
                If selectedFile = .Items(nCount).ToString Then
                    .SelectedIndex = nCount
                    Exit For
                End If
            Next
        End With
    End Sub
    Private Sub cmdOutputFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOutputFolder.Click
        With FolderBrowserDialog1
            .SelectedPath = txtOutputFolder.Text
            .ShowNewFolderButton = True
            .ShowDialog()
            If .SelectedPath <> "" Then
                txtOutputFolder.Text = .SelectedPath & "\"
                Call SaveRegSetting(sRootRegistry & "\Settings", "OutputFolder", txtOutputFolder.Text)
                cmdOutputFolder_Click(Nothing, Nothing)
            End If
        End With
    End Sub

    Private Sub cmdViewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewFile.Click
        Shell("notepad.exe " & txtOutputFolder.Text & cboOutputFiles.Text, AppWinStyle.NormalFocus)
    End Sub

    Private Sub cmdCenterOnPlane_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCenterOnPlane.Click
        Try
            If eMapSelection = e_MapSelection.e_MapSelection_GoogleMaps Then
                webDocument.GetElementById("centerTravelEndButton").InvokeMember("click")
            Else
                webDocument.InvokeScript("centerOnPlane", New Object() {})
            End If
        Catch e2 As Exception
        End Try
    End Sub

    Private Sub cmdClearMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearMap.Click
        Try
            If eMapSelection = e_MapSelection.e_MapSelection_GoogleMaps Then
                webDocument.GetElementById("ClearButton").InvokeMember("click")
            Else
                webDocument.InvokeScript("clearMap", New Object() {})
            End If
            nDataPoints = 1
        Catch e2 As Exception
        End Try
    End Sub
    Private Function LoadDataFile(ByVal filename As String) As Boolean
        Dim nCount As Long
        Dim sTemp As String
        Dim dWeekStart As Date
        Dim sFileContents As String

        eMissionFileType = e_MissionFileType.e_MissionFileType_None
        If Dir(filename) <> "" Then
            'asdasd()
            'Dim FS As New FileStream(filename, FileMode.Open)
            'Dim Buffer() As Byte
            ''Get the bytes from file to a byte array        
            'ReDim Buffer(FS.Length - 1)
            'FS.Read(Buffer, 0, Buffer.Length)
            'sFileContents = System.Text.Encoding.Default.GetString(Buffer)
            'FS.Close()

            sFileContents = GetFileContents(filename)

            'Dim sFileName As String = filename
            'Dim myFileStream As New System.IO.FileStream(sFileName, FileMode.Open, FileAccess.Read, FileShare.Read)

            ''Create the StreamReader and associate the filestream with it
            'Dim myReader As New System.IO.StreamReader(myFileStream)

            ''Read the entire text, and set it to a string
            'Dim sFileContents As String = myReader.ReadToEnd()

            ''Close everything when you are finished
            'myReader.Close()
            'myFileStream.Close()

            If Microsoft.VisualBasic.Left(sFileContents, 1) = "F" Then
                eMissionFileType = e_MissionFileType.e_MissionFileType_UDB
                rawData = Split(sFileContents, vbCrLf)
            ElseIf (Mid(sFileContents, 18, 1) = ":" Or Mid(sFileContents, 19, 1) = ":") Then
                eMissionFileType = e_MissionFileType.e_MissionFileType_GCS
                rawData = Split(sFileContents, Chr(255) & vbCrLf)
                'ElseIf InStr(sFileContents, Chr(&HA5) & Chr(&H5A)) <> 0 Then
                '    eMissionFileType = e_MissionFileType.e_MissionFileType_FY21APII
                '    rawData = Split(sFileContents, Chr(&HAA))
            End If

            If eMissionFileType <> e_MissionFileType.e_MissionFileType_None Then
                If eMissionFileType = e_MissionFileType.e_MissionFileType_GCS Then
                    dStartTime = New Date(Mid(rawData(0), 1, InStr(rawData(0), ":") - 1))
                ElseIf eMissionFileType = e_MissionFileType.e_MissionFileType_UDB Then
                    For nCount = 0 To UBound(rawData)
                        If Microsoft.VisualBasic.Left(rawData(nCount), 3) = "F2:" Then
                            If Microsoft.VisualBasic.Left(rawData(nCount), 6) <> "F2:T0:" Then
                                Try
                                    sTemp = Mid(rawData(nCount), 5)
                                    sTemp = Mid(sTemp, 1, InStr(sTemp, ":") - 1)
                                    dWeekStart = DateAdd(DateInterval.Day, -DatePart(DateInterval.Weekday, Now), Convert.ToDateTime(FormatDateTime(Now, DateFormat.ShortDate) & " 12:00:00AM"))
                                    dStartTime = DateAdd(DateInterval.Second, Convert.ToInt32(sTemp / 1000), dWeekStart)
                                    Exit For
                                Catch
                                End Try
                            End If
                        End If
                    Next nCount
                End If

                nDataIndex = 0

                TrackBar1.Maximum = UBound(rawData)
                If nDataIndex <= UBound(rawData) Then
                    TrackBar1.Value = nDataIndex
                End If

                TrackBar1.TickFrequency = (UBound(rawData) - 1) / 10

                TrackBar1.Enabled = True
                chkPlay.Enabled = True
                chkPause.Enabled = True
                chkStepBack.Enabled = True
                chkStepForward.Enabled = True
            Else
                TrackBar1.Enabled = False
                chkPlay.Enabled = False
                chkPause.Enabled = False
                chkStepBack.Enabled = False
                chkStepForward.Enabled = False
            End If
        End If
    End Function

    Private Sub cboOutputFiles_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOutputFiles.LostFocus
        Dim sTemp As String

        sTemp = Trim(cboOutputFiles.Text)
        If sTemp <> "" Then
            sTemp = Replace(sTemp, "\", "")
            sTemp = Replace(sTemp, "/", "")
            If InStr(sTemp, ".") = 0 Then
                sTemp = sTemp & ".hko"
            End If
        End If
        cboOutputFiles.Text = sTemp
    End Sub
    Private Sub cboOutputFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOutputFiles.SelectedIndexChanged
        'tmrPlayback.Enabled = False
        'SetPlayerState(e_PlayerState.e_PlayerState_Pause)
        'LoadDataFile(txtOutputFolder.Text & cboOutputFiles.Text)
        'SetPlayerState(e_PlayerState.e_PlayerState_Loaded)
    End Sub
    Private Sub SetServoSlider(ByVal inputControl As TrackBar, ByVal inputLabel As Label, ByVal value As Integer)
        With inputControl
            If value < .Minimum Then
                .Value = .Minimum
                inputLabel.ForeColor = Color.Red
            ElseIf value > .Maximum Then
                .Value = .Maximum
                inputLabel.ForeColor = Color.Red
            Else
                inputLabel.ForeColor = Color.Black
                .Value = value
            End If
        End With
        If value = 0 Then
            inputLabel.Text = ""
        Else
            inputLabel.Text = value
        End If
    End Sub

    Private Sub GpS_Parser1_AttitudeChange1(ByVal pitch As Single, ByVal roll As Single, ByVal yaw As Single)
        Try
            nSensor(9) = pitch
            nSensor(10) = roll
            nSensor(11) = yaw

            If bInstruments(e_Instruments.e_Instruments_Attitude) Then
                AttitudeIndicatorInstrumentControl1.SetAttitudeIndicatorParameters(GetPitch(-pitch), GetRoll(roll))
            End If
            If bInstruments(e_Instruments.e_Instruments_3DModel) Then
                _3DMesh1.DrawMesh(GetPitch(pitch), GetRoll(roll), GetYaw(yaw))
            End If
            If bInstruments(e_Instruments.e_Instruments_Turn) Then
                TurnCoordinatorInstrumentControl1.SetTurnCoordinatorParameters(GetRoll(-nRoll), 0, UCase(GetResString(, "Turn_Coordinator")), GetResString(, "Left"), GetResString(, "Right"))
            End If

            If tabPortControl.SelectedIndex = 3 Or tabPortControl.SelectedIndex = 4 Then
                UpdateServoSliders()
            End If
        Catch
        End Try
    End Sub
    Private Sub GPS_Parser1_Waypoints(ByVal waypointNumber As Integer, ByVal distance As Single, ByVal battery As Single, ByVal mode As String, ByVal throttle As Single)
        If bInstruments(e_Instruments.e_Instruments_Battery) Then
            BatteryIndicatorInstrumentControl1.SetBatteryIndicatorParameters(Replace(GetResString(, "Battery_Throttle"), "&&", "&"), nBattery, nBatteryMin, nBatteryMax, oBatteryColor, nAmperage, 0, nAmperageMax, oAmperageColor, nMAH, nMAHMin, nMAHMax, oMAHColor, throttle, oThrottleColor)
            'Debug.Print(Now)
        End If

        lblWaypoint.Text = IIf(waypointNumber <> 0, "#" & waypointNumber, "")
        lblDistance.Text = IIf(distance <> 0, distance.ToString("0.0") & GetShortDistanceUnits(), "")
        lblTargetAlt.Text = IIf(nWaypoint <> 0, nWaypointAlt.ToString("0.0") & GetShortDistanceUnits(), "")
        lblBattery.Text = battery.ToString("0.00") & IIf(battery <> 0, "v", "")
        lblAmperage.Text = nAmperage.ToString("0.00") & IIf(nAmperage <> 0, "A", "")
        If sMode <> "" Then
            lblMode.Text = sMode
        ElseIf sModeNumber = "" Then
            lblMode.Text = ""
        Else
            lblMode.Text = mode
        End If
        lblThrottle.Text = throttle.ToString("0.00%")
    End Sub
    Private Function GetNextFileTime() As Date
        Dim nCount As Long
        Dim sTemp As String
        Dim dWeekStart As Date

        If eMissionFileType = e_MissionFileType.e_MissionFileType_GCS Then
            GetNextFileTime = New Date(Mid(rawData(nDataIndex), 1, InStr(rawData(nDataIndex), ":") - 1))
        Else
            For nCount = nDataIndex To UBound(rawData)
                If Microsoft.VisualBasic.Left(rawData(nCount), 3) = "F2:" Then
                    If Microsoft.VisualBasic.Left(rawData(nCount), 6) <> "F2:T0:" Then
                        sTemp = Mid(rawData(nCount), 5)
                        sTemp = Mid(sTemp, 1, InStr(sTemp, ":") - 1)
                        dWeekStart = DateAdd(DateInterval.Day, -DatePart(DateInterval.Weekday, Now), Convert.ToDateTime(FormatDateTime(Now, DateFormat.ShortDate) & " 12:00:00AM"))
                        GetNextFileTime = DateAdd(DateInterval.Second, Convert.ToInt32(sTemp / 1000), dWeekStart)
                        'Debug.Print("Next File Time = " & GetNextFileTime & ",Added = " & Convert.ToInt32(sTemp / 1000))
                        Exit For
                    End If
                End If
            Next nCount
        End If

    End Function
    Private Sub GpS_Parser1_GpsData1(ByVal latitude As String, ByVal longitude As String, ByVal altitude As Single, ByVal groundSpeed As Single, ByVal heading As Single, ByVal satellites As Integer, ByVal fix As Integer, ByVal hdop As Single, ByVal verticalChange As Single, Optional ByVal airSpeed As Single = -1)
        Dim dNextTime As Date
        Try
            nSensor(12) = groundSpeed
            nSensor(13) = airSpeed

            If chkFullDataFile.Checked = False Then
                If bInstruments(e_Instruments.e_Instruments_Speed) Then
                    AirSpeedIndicatorInstrumentControl1.SetAirSpeedIndicatorParameters(groundSpeed, nMaxSpeed, GetResString(, "Speed"), sSpeedUnits, airSpeed)
                End If
                If bInstruments(e_Instruments.e_Instruments_Altimeter) Then
                    AltimeterInstrumentControl1.SetAlimeterParameters(altitude, sDistanceUnits)
                End If
                If bInstruments(e_Instruments.e_Instruments_Heading) Then
                    HeadingIndicatorInstrumentControl1.SetHeadingIndicatorParameters(GetHeading(heading))
                End If
                If bInstruments(e_Instruments.e_Instruments_Vertical) Then
                    VerticalSpeedIndicatorInstrumentControl1.SetVerticalSpeedIndicatorParameters(verticalChange, LCase(GetResString(, "Vertical_Speed")), GetResString(, "Up"), GetResString(, "Down"), "100ft/min")
                End If
                If bInstruments(e_Instruments.e_Instruments_3DModel) Then
                    _3DMesh1.DrawMesh(GetPitch(nPitch), GetRoll(nRoll), GetYaw(nYaw))
                End If
                If bInstruments(e_Instruments.e_Instruments_Turn) Then
                    TurnCoordinatorInstrumentControl1.SetTurnCoordinatorParameters(GetRoll(-nRoll), 0, UCase(GetResString(, "Turn_Coordinator")), GetResString(, "Left"), GetResString(, "Right"))
                End If

                Select Case fix
                    Case 0
                        lblGPSLock.Text = GetResString(, "Not_Locked")
                    Case 1
                        lblGPSLock.Text = GetResString(, "Locked")
                    Case 2
                        lblGPSLock.Text = GetResString(, "2D_Lock")
                    Case Else
                        lblGPSLock.Text = GetResString(, "3D_Lock")
                End Select
                lblSatellites.Text = satellites
                lblHDOP.Text = hdop

                If Not latitude Is Nothing Then
                    lblLatitude.Text = Convert.ToDouble(latitude).ToString("0.000000")
                End If
                If Not longitude Is Nothing Then
                    lblLongitude.Text = Convert.ToDouble(longitude).ToString("0.000000")
                End If
            End If

            lblDataPoints.Text = nDataPoints.ToString("###,##0")
            nDataPoints = nDataPoints + 1

            If serialPortIn.IsOpen = True Then
                lblRunTime.Text = ConvertToRunTime(dStartTime, Now)
            Else
                dNextTime = GetNextFileTime()
                lblRunTime.Text = ConvertToRunTime(dStartTime, dNextTime)
            End If

            If Now.Ticks - nLastMapUpdate > (10000000 / (nMapUpdateRate)) Then
                nLastMapUpdate = Now.Ticks
                If latitude <> "" And longitude <> "" Then
                    If eMapSelection = e_MapSelection.e_MapSelection_GoogleMaps Then
                        If nHomeLat = "" Then
                            nHomeLat = latitude
                            nHomeLong = longitude
                            webDocument.GetElementById("homeLat").SetAttribute("value", latitude)
                            webDocument.GetElementById("homeLng").SetAttribute("value", longitude)
                            webDocument.GetElementById("setHomeLatLngButton").InvokeMember("click")
                            webDocument.GetElementById("centerMapHomeButton").InvokeMember("click")
                        End If

                        webDocument.GetElementById("heading").SetAttribute("value", heading)
                        webDocument.GetElementById("segmentInterval").SetAttribute("value", "1")
                        webDocument.GetElementById("segmentLat").SetAttribute("value", latitude)
                        webDocument.GetElementById("segmentLng").SetAttribute("value", longitude)
                        webDocument.GetElementById("addSegementButton").InvokeMember("click")
                    Else
                        'nAltitude = ConvertDistance(nAltitude, eOutputDistance, e_DistanceFormat.e_DistanceFormat_Meters)
                        If nHomeLat = "" And (latitude <> 0 Or nLongitude <> 0) Then
                            nHomeLat = latitude
                            nHomeLong = longitude
                            WebBrowser1.Invoke(New MyDelegate(AddressOf setHomeLatLng))
                            If cboMission.Text <> "" Then
                                cboMission_SelectedIndexChanged(Nothing, Nothing)
                            End If
                        End If
                        WebBrowser1.Invoke(New MyDelegate(AddressOf setPlaneLocation))
                    End If
                End If
            End If
        Catch e As Exception
            System.Diagnostics.Debug.Print(GetResString(, "Error_Message") & ": " & e.Message)
        End Try

    End Sub
    Public Function ConvertToRunTime(ByVal startTime As Date, ByVal endTime As Date)
        Dim nSeconds As Long
        Dim nDays As Long
        Dim nHours As Long
        Dim nMinutes As Long

        nSeconds = DateDiff(DateInterval.Second, startTime, endTime)

        'ConvertToRunTime = ""
        'nDays = nSeconds \ 86400
        'If nDays > 0 Then
        '    ConvertToRunTime = ConvertToRunTime & nDays & " day" & IIf(nDays > 1, "s", "")
        'End If
        'nSeconds = nSeconds - (nDays * 86400)


        'nHours = nSeconds \ 3600
        'If nHours > 0 Then
        '    If ConvertToRunTime <> "" Then
        '        ConvertToRunTime = ConvertToRunTime & ","
        '    End If
        '    ConvertToRunTime = ConvertToRunTime & nHours & " hour" & IIf(nHours > 1, "s", "")
        'End If
        'nSeconds = nSeconds - (nHours * 3600)

        nMinutes = nSeconds \ 60
        If nMinutes > 0 Then
            If ConvertToRunTime <> "" Then
                ConvertToRunTime = ConvertToRunTime & ","
            End If
            ConvertToRunTime = ConvertToRunTime & nMinutes & " min" & IIf(nMinutes > 1, "s", "")
        End If
        nSeconds = nSeconds - (nMinutes * 60)

        If ConvertToRunTime <> "" Then
            ConvertToRunTime = ConvertToRunTime & ","
        End If
        ConvertToRunTime = ConvertToRunTime & nSeconds & " sec" & IIf(nSeconds > 1, "s", "")

    End Function
    Public Delegate Sub MyDelegate()
    Public Sub setHomeLatLng()
        Try
            webDocument.InvokeScript("setHomeLatLng", New Object() {nLatitude, nLongitude, ConvertDistance(nAltitude, eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters), sModelName, tbarModelScale.Value, GetPitch(nPitch), GetRoll(nRoll), nCameraTracking})
            'lblHomeAltitude.Text = webDocument.GetElementById("homeGroundAltitude").ToString
        Catch e2 As Exception
        End Try
    End Sub
    Public Sub loadModel()
        Try
            webDocument.InvokeScript("loadModel", New Object() {sModelName})
            'lblHomeAltitude.Text = webDocument.GetElementById("homeGroundAltitude").ToString
        Catch e2 As Exception
        End Try
    End Sub
    Public Sub addWaypoint()
        Try
            webDocument.InvokeScript("addWaypoint", New Object() {nLatitude, nLongitude, ConvertDistance(nAltitude, eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters), nWaypoint.ToString.PadLeft(2, "0"), bMissionExtrude, sMissionColor, nMissionWidth})
        Catch e2 As Exception
        End Try
    End Sub
    Public Sub drawHomeLine()
        Try
            webDocument.InvokeScript("drawHomeLine", New Object() {})
        Catch e2 As Exception
        End Try
    End Sub
    Public Sub changeModelScale()
        Try
            webDocument.InvokeScript("changeModelScale", New Object() {tbarModelScale.Value})
        Catch e2 As Exception
        End Try
    End Sub
    Public Sub updateAttitude()
        Try
            webDocument.InvokeScript("updateAttitude", New Object() {GetHeading(nHeading), GetPitch(nPitch), GetRoll(nRoll)})
        Catch e2 As Exception
        End Try
    End Sub
    Public Sub setPlaneLocation()
        Try
            webDocument.InvokeScript("drawAndCenter", New Object() {ConvertPeriodToLocal(nLatitude), ConvertPeriodToLocal(nLongitude), ConvertDistance(nAltitude, eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters), bFlightExtrude, sFlightColor, nFlightWidth, nCameraTracking, IIf(eDistanceUnits = e_DistanceFormat.e_DistanceFormat_Feet, True, False), GetHeading(nHeading), GetPitch(nPitch), GetRoll(nRoll)})
            'lblHomeAltitude.Text = webDocument.GetElementById("homeGroundAltitude").ToString
        Catch
        End Try
    End Sub

    Private Sub GpS_Parser1_RawPacket(ByVal messageString As String)
        If bIsRecording = True Then
            If Not sOutputFile Is Nothing Then
                sOutputFile.WriteLine(Now.Ticks & ":" & messageString & Chr(255))
            End If
        End If
    End Sub

    Private Sub tmrPlayback_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPlayback.Tick
        Dim oMessage As cMessage
        Dim sMessage As String
        Dim nLastTime As Long
        Dim nThisTime As Long

        Do While True
            If nDataIndex > UBound(rawData) Then
                tmrPlayback.Enabled = False
                SetPlayerState(e_PlayerState.e_PlayerState_Pause)
                nDataIndex = UBound(rawData)
                'chkPlay.Checked = False
                Exit Sub
            ElseIf Trim(rawData(nDataIndex)) = "" Then
                nDataIndex = nDataIndex + 1
            ElseIf Len(rawData(nDataIndex)) < 18 Then
                nDataIndex = nDataIndex + 1
            ElseIf eMissionFileType = e_MissionFileType.e_MissionFileType_GCS Then
                If Mid(rawData(nDataIndex), 19, 1) <> ":" And Mid(rawData(nDataIndex), 20, 1) <> ":" Then
                    nDataIndex = nDataIndex + 1
                Else
                    Exit Do
                End If
            ElseIf eMissionFileType = e_MissionFileType.e_MissionFileType_UDB Then
                Exit Do
            Else
                Exit Do
            End If
        Loop
        nDataPoints = nDataIndex

        'System.Diagnostics.Debug.Print(GetMessageTime(nDataIndex + 1) - GetMessageTime(nDataIndex))
        If chkFullDataFile.Checked = True Then
            tmrPlayback.Interval = 75
        Else
            If GetMessageTime(nDataIndex + 1) > 0 And tmrPlayback.Enabled = True Then
                nLastTime = GetMessageTime(nDataIndex)
                nThisTime = GetMessageTime(nDataIndex + 1)
                If nLastTime = 0 Or nThisTime < nLastTime Then
                    nLastTime = nThisTime
                End If
                tmrPlayback.Interval = ((nThisTime - nLastTime) / 10000) + 1
                'Debug.Print("Interval=" & tmrPlayback.Interval)
            Else
                tmrPlayback.Interval = 5
            End If
        End If
        'If tmrPlayback.Interval = 0 Or tmrPlayback.Interval > 5000 Then
        '    Debug.Print("Error Interval=" & tmrPlayback.Interval)
        'End If
        sMessage = rawData(nDataIndex) & vbCrLf
        TrackBar1.Value = nDataIndex

        oMessage = GetNextSentence(sMessage)
        UpdateVariables(oMessage)

        nDataIndex = nDataIndex + 1
        'Debug.Print("New Data = " & nDataIndex)

    End Sub
    Private Function GetMessageTime(ByVal index As Long) As Long

        Dim sTemp As String
        Dim nSeconds As Int32
        Dim dWeekStart As Date

        If index > UBound(rawData) Then
            GetMessageTime = 0
            Exit Function
        End If

        If eMissionFileType = e_MissionFileType.e_MissionFileType_GCS Then
            If InStr(rawData(index), ":") = 0 Then
                GetMessageTime = 0
            Else
                GetMessageTime = Mid(rawData(index), 1, InStr(rawData(index), ":") - 1)
            End If
        ElseIf eMissionFileType = e_MissionFileType.e_MissionFileType_UDB Then
            If index < UBound(rawData) Then
                If Microsoft.VisualBasic.Left(rawData(index), 3) = "F2:" Then
                    If Microsoft.VisualBasic.Left(rawData(index), 6) = "F2:T0:" Then
                        GetMessageTime = 0
                    Else
                        sTemp = Mid(rawData(index), 5)
                        sTemp = Mid(sTemp, 1, InStr(sTemp, ":") - 1)
                        dWeekStart = DateAdd(DateInterval.Day, -DatePart(DateInterval.Weekday, Now), Convert.ToDateTime(FormatDateTime(Now, DateFormat.ShortDate) & " 12:00:00AM"))
                        nSeconds = Convert.ToInt32(Mid(Convert.ToDouble(sTemp / 1000).ToString, 1, Len(sTemp) - 3))
                        GetMessageTime = DateAdd(DateInterval.Second, nSeconds, dWeekStart).Ticks
                        GetMessageTime = GetMessageTime + (Convert.ToInt32(Microsoft.VisualBasic.Right(sTemp, 3)) * 10000)
                    End If
                Else
                    GetMessageTime = 0
                End If
            Else
                GetMessageTime = 0
            End If
        End If
    End Function
    Private Sub serialPortIn_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles serialPortIn.DataReceived
        'ReadSerialData()
    End Sub
    Private Sub ReadSerialData()
        Dim bWasSearching As Boolean
        Dim nReadCount As Integer
        Dim nReadResult As Integer
        Dim nSentenceCount As Integer
        Dim oMessage As cMessage
        Dim nCount As Integer
        Dim nExistingLen As Integer
        Dim nOldTop As Long
        Dim nBandwith As Single
        Dim sNewString As String

        If bShutdown = True Then
            Exit Sub
        End If

        bWasSearching = tmrSearch.Enabled
        If bWasSearching Then
            tmrSearch.Enabled = False
        End If
        If serialPortIn.IsOpen = True Then
            If serialPortIn.BytesToRead > 0 Then
                nReadCount = serialPortIn.BytesToRead 'Number of Bytes to read
                Dim cData(nReadCount - 1) As Byte

                nInputStringLength = nInputStringLength + nReadCount
                serialPortIn.Encoding = System.Text.Encoding.UTF8 'System.Text.Encoding.GetEncoding(28591) '65001) '28591
                nReadResult = serialPortIn.Read(cData, 0, nReadCount)  'Reading the Data

                sNewString = System.Text.Encoding.Default.GetString(cData)
                sBuffer = sBuffer & sNewString
                'For Each b As Byte In cData

                '    'AddCharacter(b)
                '    'If b >= 128 And b <= 159 Then     '&H80<=indata<=&H9F
                '    '    sBuffer = sBuffer & Chr(b)
                '    'Else
                '    '    sBuffer = sBuffer & ChrW(b)
                '    'End If
                '    'sBuffer = sBuffer & Chr(b)        'Ascii String
                If tabInstrumentView.SelectedIndex = 2 Then
                    sCommandLineBuffer = sCommandLineBuffer & sNewString
                Else
                    sCommandLineBuffer = ""
                End If
                'nInputStringLength = nInputStringLength + Len(sNewString)
                'Next

                nSentenceCount = 0
                oMessage = GetNextSentence(sBuffer)
                Do While oMessage.ValidMessage = True
                    If dStartTime.Ticks = 0 Then
                        dStartTime = Now
                    End If
                    tmrSearch.Enabled = False
                    cboBaudRate.Text = serialPortIn.BaudRate

                    bWasSearching = False

                    UpdateVariables(oMessage)
                    oMessage = GetNextSentence(sBuffer)
                Loop
                If bWasSearching Then
                    tmrSearch.Enabled = True
                End If

                nOldTop = lstCommandLineOutput.TopIndex

                Try
                    If tabInstrumentView.SelectedIndex = 2 Then
                        lstCommandLineOutput.BeginUpdate()
                        If nCommandLineDelim = 1 Then
                            Do While InStr(sCommandLineBuffer, vbLf) <> 0
                                lstCommandLineOutput.Items.Add(Mid(sCommandLineBuffer, 1, InStr(sCommandLineBuffer, vbLf) - 1))
                                sCommandLineBuffer = Mid(sCommandLineBuffer, InStr(sCommandLineBuffer, vbLf) + 1)
                            Loop
                        ElseIf nCommandLineDelim = 2 Then
                            Do While InStr(sCommandLineBuffer, vbCr) <> 0

                                lstCommandLineOutput.Items.Add(Replace(Mid(sCommandLineBuffer, 1, InStr(sCommandLineBuffer, vbCr) - 1), vbLf, ""))
                                sCommandLineBuffer = Mid(sCommandLineBuffer, InStr(sCommandLineBuffer, vbCr) + 1)
                            Loop
                        ElseIf nCommandLineDelim = 3 Then
                            Do While InStr(sCommandLineBuffer, vbCrLf) <> 0
                                lstCommandLineOutput.Items.Add(Mid(sCommandLineBuffer, 1, InStr(sCommandLineBuffer, vbCrLf) - 1))
                                sCommandLineBuffer = Mid(sCommandLineBuffer, InStr(sCommandLineBuffer, vbCrLf) + 2)
                            Loop
                        Else
                            If lstCommandLineOutput.Items.Count = 0 Then
                                lstCommandLineOutput.Items.Add(sCommandLineBuffer)
                            Else
                                nExistingLen = Len(lstCommandLineOutput.Items(lstCommandLineOutput.Items.Count - 1))
                                If nExistingLen > 80 Then
                                    lstCommandLineOutput.Items.Add(sCommandLineBuffer)
                                Else
                                    lstCommandLineOutput.Items(lstCommandLineOutput.Items.Count - 1) = lstCommandLineOutput.Items(lstCommandLineOutput.Items.Count - 1) & sCommandLineBuffer
                                End If
                            End If
                            sCommandLineBuffer = ""
                        End If
                        For nCount = nMaxListboxRecords To lstCommandLineOutput.Items.Count - 1
                            lstCommandLineOutput.Items.RemoveAt(0)
                        Next
                        lstCommandLineOutput.EndUpdate()
                    End If
                Catch
                End Try

                If chkCommandLineAutoScroll.Checked = True Then
                    lstCommandLineOutput.TopIndex = lstCommandLineOutput.Items.Count - 1
                Else
                    lstCommandLineOutput.TopIndex = nOldTop
                End If

                If nLastBandwidthCheck = 0 Then
                    nLastBandwidthCheck = Now.Ticks
                    nInputStringLength = 0
                ElseIf Now.Ticks - nLastBandwidthCheck > 10000000 Then
                    nBandwith = nInputStringLength / ((Now.Ticks - nLastBandwidthCheck) / 10000000) / (serialPortIn.BaudRate / 11)
                    'System.Diagnostics.Debug.Print("InputLength = " & nInputStringLength & ",Elapsed Time = " & ((Now.Ticks - nLastBandwidthCheck) / 10000000) & ",Baud Rate = " & serialPortIn.BaudRate)
                    If nBandwith > 0.9 Then
                        lblBandwidth.ForeColor = Color.Red
                    Else
                        lblBandwidth.ForeColor = Color.Black
                    End If
                    lblBandwidth.Text = (nBandwith).ToString("0.00%")
                    nLastBandwidthCheck = Now.Ticks
                    nInputStringLength = 0
                End If
            End If
            End If

    End Sub
    Private Sub UpdateVariables(ByVal oMessage As cMessage)
        Dim sSplit() As String
        Dim sValues() As String
        Dim nCount As Integer
        Dim sTemp As String
        Dim nYawComponent1 As Single

        Dim bFireAttitude As Boolean = False
        Dim bFireGPS As Boolean = False
        Dim bFireWaypoint As Boolean = False

        ''If Now.Ticks - nLastAttitude > (1000 / (cboAttitude.SelectedIndex)) * 10000 And cboAttitude.SelectedIndex <> 0 Then
        'bFireAttitude = True
        ''End If

        ''If Now.Ticks - nLastGPS > (1000 / (cboGPS.SelectedIndex)) * 10000 And cboGPS.SelectedIndex <> 0 Then
        'bFireGPS = True
        ''End If

        ''If Now.Ticks - nLastWaypoint > (1000 / (cboWaypoint.SelectedIndex)) * 10000 And cboWaypoint.SelectedIndex <> 0 Then
        'bFireWaypoint = True
        ''End If

        GpS_Parser1_RawPacket(oMessage.RawMessage)
        If serialPortIn.IsOpen = False Then
            lstInbound.Items.Insert(0, "#" & nDataIndex & " - " & oMessage.VisibleSentence)
        Else
            lstInbound.Items.Insert(0, oMessage.VisibleSentence)
        End If
        Try
            For nCount = nMaxListboxRecords To lstInbound.Items.Count - 1
                lstInbound.Items.RemoveAt(nMaxListboxRecords)
            Next
        Catch
        End Try

        With oMessage
            If .ValidMessage = True Then
                Select Case .MessageType
                    Case cMessage.e_MessageType.e_MessageType_AttoPilot
                        lblGPSType.Text = "AttoPilot"
                        sSplit = Split(.Packet, ",")
                        Select Case UCase(sSplit(0))
                            Case "A1"
                                lblGPSMessage.Text = "A1 - " & GetResString(, "Attitude Data")
                                nRoll = ConvertPeriodToLocal(sSplit(2))
                                nPitch = ConvertPeriodToLocal(sSplit(3))
                                bNewAttitude = True
                            Case "A2"
                                lblGPSMessage.Text = "A2 - " & GetResString(, "GPS_Data")
                                nLatitude = ConvertLatLongFormat(sSplit(2), e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                                nLongitude = ConvertLatLongFormat(sSplit(3), e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                                nHeading = Convert.ToSingle(ConvertPeriodToLocal(sSplit(4)))
                                nYaw = nHeading
                                Select Case sSplit(5)
                                    Case "1"
                                        sMode = GetResString(, "Manual Mode")
                                    Case "2"
                                        sMode = GetResString(, "Assisted RC")
                                    Case "3"
                                        sMode = GetResString(, "Highly Assisted")
                                    Case "4"
                                        sMode = GetResString(, "Autonomous")
                                End Select
                                nWaypoint = Convert.ToInt32(sSplit(6))
                                nAltitude = ConvertDistance(sSplit(9), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                nAirSpeed = ConvertSpeed(sSplit(10), e_SpeedFormat.e_SpeedFormat_KPH, eSpeedUnits)
                                nGroundSpeed = ConvertSpeed(sSplit(11), e_SpeedFormat.e_SpeedFormat_KPH, eSpeedUnits)
                                bNewGPS = True
                            Case "A3"
                                lblGPSMessage.Text = "A3 - Other Data"
                                nBattery = Convert.ToSingle(ConvertPeriodToLocal(sSplit(2)))
                                nAmperage = Convert.ToSingle(ConvertPeriodToLocal(sSplit(3)))
                                nMAH = Convert.ToInt32(ConvertPeriodToLocal(sSplit(4)))
                                bNewWaypoint = True
                        End Select

                    Case cMessage.e_MessageType.e_MessageType_NMEA
                        lblGPSType.Text = "NMEA"
                        sSplit = Split(.Packet, ",")
                        lblGPSMessage.Text = UCase(sSplit(0))
                        Select Case UCase(sSplit(0))
                            Case "GPRMC"
                                nLatitude = ConvertLatLongFormat(sSplit(3), e_LatLongFormat.e_LatLongFormat_DDMM_MMMM, eOutputLatLongFormat, True)
                                If sSplit(4) = "S" Then
                                    nLatitude = nLatitude * -1
                                End If
                                nLongitude = ConvertLatLongFormat(sSplit(5), e_LatLongFormat.e_LatLongFormat_DDMM_MMMM, eOutputLatLongFormat, False)
                                If sSplit(6) = "W" Then
                                    nLongitude = nLongitude * -1
                                End If
                                nGroundSpeed = ConvertSpeed(sSplit(7), e_SpeedFormat.e_SpeedFormat_Knots, eSpeedUnits)
                                nHeading = Convert.ToSingle(ConvertPeriodToLocal(sSplit(8)))
                                nYaw = nHeading
                                bNewGPS = True
                            Case "GPGGA"
                                nLatitude = ConvertLatLongFormat(sSplit(2), e_LatLongFormat.e_LatLongFormat_DDMM_MMMM, eOutputLatLongFormat, True)
                                If sSplit(3) = "S" Then
                                    nLatitude = nLatitude * -1
                                End If
                                nLongitude = ConvertLatLongFormat(sSplit(4), e_LatLongFormat.e_LatLongFormat_DDMM_MMMM, eOutputLatLongFormat, False)
                                If sSplit(5) = "W" Then
                                    nLongitude = nLongitude * -1
                                End If
                                nFix = Convert.ToInt32(sSplit(6))
                                nSats = ConvertPeriodToLocal(sSplit(7))
                                nHDOP = ConvertPeriodToLocal(sSplit(8))
                                nAltitude = ConvertDistance(sSplit(9), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                bNewGPS = True
                            Case "GPGLL"
                                nLatitude = ConvertLatLongFormat(sSplit(1), e_LatLongFormat.e_LatLongFormat_DDMM_MMMM, eOutputLatLongFormat, True)
                                If sSplit(2) = "S" Then
                                    nLatitude = nLatitude * -1
                                End If
                                nLongitude = ConvertLatLongFormat(sSplit(3), e_LatLongFormat.e_LatLongFormat_DDMM_MMMM, eOutputLatLongFormat, False)
                                If sSplit(4) = "W" Then
                                    nLongitude = nLongitude * -1
                                End If
                                bNewGPS = True
                            Case "GPVTG"
                                nHeading = Convert.ToSingle(ConvertPeriodToLocal(sSplit(1)))
                                nYaw = nHeading
                                nGroundSpeed = ConvertSpeed(sSplit(5), e_SpeedFormat.e_SpeedFormat_Knots, eSpeedUnits)
                                bNewGPS = True
                        End Select

                    Case cMessage.e_MessageType.e_MessageType_ArduPilot_WPCount
                        nWaypointTotal = Convert.ToInt32(Trim(Mid(.Packet, 10)))

                    Case cMessage.e_MessageType.e_MessageType_ArduPilot_Home
                        sSplit = Split(.Packet, vbTab)
                        nLatitude = ConvertLatLongFormat((Convert.ToDouble(sSplit(1)) / 10000000), e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                        nLongitude = ConvertLatLongFormat((Convert.ToDouble(sSplit(2)) / 10000000), e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                        nAltitude = ConvertDistance(Convert.ToSingle(sSplit(3)) / 100, e_DistanceFormat.e_DistanceFormat_Meters, e_DistanceFormat.e_DistanceFormat_Feet)

                        WebBrowser1.Invoke(New MyDelegate(AddressOf setHomeLatLng))

                    Case cMessage.e_MessageType.e_MessageType_ArduPilot_WP
                        sSplit = Split(.Packet, vbTab)
                        nWaypoint = Convert.ToUInt32(Trim(Mid(sSplit(0), 5, 2)))
                        nLatitude = ConvertLatLongFormat((Convert.ToDouble(sSplit(1)) / 10000000), e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                        nLongitude = ConvertLatLongFormat((Convert.ToDouble(sSplit(2)) / 10000000), e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                        nAltitude = ConvertDistance(Convert.ToSingle(sSplit(3)) / 100, e_DistanceFormat.e_DistanceFormat_Meters, e_DistanceFormat.e_DistanceFormat_Feet)
                        'nAltitude = Convert.ToSingle(sSplit(3)) / 100

                        WebBrowser1.Invoke(New MyDelegate(AddressOf addWaypoint))

                        If nWaypoint = nWaypointTotal Then
                            WebBrowser1.Invoke(New MyDelegate(AddressOf drawHomeLine))
                        End If

                    Case cMessage.e_MessageType.e_MessageType_MediaTek
                        lblGPSType.Text = "MediaTek/MTK"
                        lblGPSMessage.Text = GetResString(, "Custom Binary")
                        nLatitude = ConvertLatLongFormat(ConvertHexToDec(Mid(.Packet, 3, 4), False) / 1000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                        nLongitude = ConvertLatLongFormat(ConvertHexToDec(Mid(.Packet, 7, 4), False) / 1000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                        nAltitude = ConvertDistance(ConvertHexToDec(Mid(.Packet, 11, 4), False) / 100, e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                        nGroundSpeed = ConvertSpeed(ConvertHexToDec(Mid(.Packet, 15, 4), False) / 27.7777778, e_SpeedFormat.e_SpeedFormat_KPH, eSpeedUnits)
                        nHeading = ConvertHexToDec(Mid(.Packet, 19, 4), False) / 1000000
                        nYaw = nHeading
                        nSats = ConvertHexToDec(Mid(.Packet, 23, 1), False)
                        nFix = ConvertHexToDec(Mid(.Packet, 24, 1), False) - 1
                        bNewGPS = True

                    Case cMessage.e_MessageType.e_MessageType_MediaTekv16
                        lblGPSType.Text = "MediaTek v1.6"
                        lblGPSMessage.Text = "Custom Binary"
                        nLatitude = ConvertLatLongFormat(ConvertHexToDec(Mid(.Packet, 1, 4), False) / 1000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                        nLongitude = ConvertLatLongFormat(ConvertHexToDec(Mid(.Packet, 5, 4), False) / 1000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                        nAltitude = ConvertDistance(ConvertHexToDec(Mid(.Packet, 9, 4), False) / 100, e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                        nGroundSpeed = ConvertSpeed(ConvertHexToDec(Mid(.Packet, 13, 4), False), e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                        nHeading = ConvertHexToDec(Mid(.Packet, 17, 4), False) / 1000000
                        nYaw = nHeading
                        nSats = ConvertHexToDec(Mid(.Packet, 21, 1), False)
                        nFix = ConvertHexToDec(Mid(.Packet, 22, 1), False) - 1
                        nHDOP = ConvertHexToDec(Mid(.Packet, 30, 2), False) / 100
                        bNewGPS = True

                    Case cMessage.e_MessageType.e_MessageType_FY21AP
                        lblGPSType.Text = "FY21AP II"
                        Select Case Asc(Mid(.Packet, 2, 1))
                            Case 241 'Telemetry data set1
                                lblGPSMessage.Text = GetResString(, "Telemetry GPS")
                                nFix = Asc(Mid(.Packet, 3, 1)) And &HC0
                                nSats = Asc(Mid(.Packet, 3, 1)) And &HF
                                Select Case Asc(Mid(.Packet, 4, 1)) And &H3
                                    Case 0
                                        sMode = GetResString(, "Manual Mode")
                                    Case 1
                                        sMode = GetResString(, "Auto Balance Mode")
                                    Case 2
                                        sMode = GetResString(, "Altitude Hold Mode")
                                End Select
                                If Asc(Mid(.Packet, 5, 1)) And &H2 Then
                                    sMode = GetResString(, "Waypoint Mode")
                                End If
                                nLatitude = ConvertHexToDecFY21AP(Mid(.Packet, 6, 4)) * 0.0001
                                nLongitude = ConvertHexToDecFY21AP(Mid(.Packet, 10, 4)) * 0.0001
                                nHeading = ConvertHexToDecFY21AP(Mid(.Packet, 14, 2)) * 0.01
                                If nHeading < 0 Then
                                    nHeading = nHeading + 360
                                End If
                                nYaw = nHeading
                                nGroundSpeed = ConvertSpeed(ConvertHexToDecFY21AP(Mid(.Packet, 16, 2)) * 0.1, e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                nAltitude = ConvertDistance(ConvertHexToDecFY21AP(Mid(.Packet, 18, 2)) * 0.1, e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                nDistance = ConvertDistance(ConvertHexToDecFY21AP(Mid(.Packet, 24, 2)) * 0.1, e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                bNewGPS = True

                            Case 242 'Telemetry data set2
                                lblGPSMessage.Text = GetResString(, "Waypoint Data")
                                nWaypoint = Asc(Mid(.Packet, 3, 1))
                                nWaypointAlt = ConvertHexToDecFY21AP(Mid(.Packet, 5, 2))
                                bNewWaypoint = True

                            Case 243 'Telemetry data set3
                                lblGPSMessage.Text = GetResString(, "Attitude Data")
                                nPitch = ConvertHexToDecFY21AP(Mid(.Packet, 3, 2)) / 10
                                nRoll = ConvertHexToDecFY21AP(Mid(.Packet, 5, 2)) / 10
                                nServoInput(0) = ConvertHexToDecFY21AP(Mid(.Packet, 7, 2))
                                nServoInput(1) = ConvertHexToDecFY21AP(Mid(.Packet, 9, 2))
                                nServoInput(2) = ConvertHexToDecFY21AP(Mid(.Packet, 11, 2))
                                nServoInput(3) = ConvertHexToDecFY21AP(Mid(.Packet, 13, 2))
                                'nServoInput(4) = ConvertHexToDecFY21AP(Mid(.Packet, 15, 2))
                                'nServoInput(5) = ConvertHexToDecFY21AP(Mid(.Packet, 17, 2))
                                'nServoInput(6) = ConvertHexToDecFY21AP(Mid(.Packet, 19, 2))
                                'nServoInput(7) = ConvertHexToDecFY21AP(Mid(.Packet, 21, 2))
                                bNewAttitude = True
                        End Select

                    Case cMessage.e_MessageType.e_MessageType_uBlox
                        lblGPSType.Text = GetResString(, "uBlox Binary")
                        Select Case Asc(Mid(.Packet, 2, 1))
                            Case 2 'NAV_POSLLH
                                lblGPSMessage.Text = "NAV_POSLLH"
                                nLongitude = ConvertLatLongFormat(ConvertHexToDec(Mid(.Packet, 9, 4)) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                                nLatitude = ConvertLatLongFormat(ConvertHexToDec(Mid(.Packet, 13, 4)) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                                nAltitude = ConvertDistance(ConvertHexToDec(Mid(.Packet, 17, 4)) / 1000, e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                bNewGPS = True
                            Case 18 'NAV_VELNED
                                lblGPSMessage.Text = "NAV_VELNED"
                                nGroundSpeed = (ConvertSpeed(ConvertHexToDec(Mid(.Packet, 25, 4)) / 100, e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)).ToString("#.0")
                                nHeading = (ConvertHexToDec(Mid(.Packet, 29, 4)) / 100000).ToString("#.0")
                                nYaw = nHeading
                                bNewGPS = True
                            Case 3 'NAV_STATUS
                                lblGPSMessage.Text = "NAV_STATUS"
                                nFix = ConvertHexToDec(Mid(.Packet, 9, 1))
                                bNewGPS = True
                            Case 6 'NAV_SOL
                                lblGPSMessage.Text = "NAV_SOL"
                                nSats = ConvertHexToDec(Mid(.Packet, 52, 1))
                                bNewGPS = True
                            Case 4 'NAV_DOP
                                lblGPSMessage.Text = "NAV_DOP"
                                nHDOP = ConvertHexToDec(Mid(.Packet, 17, 2)) / 100
                                bNewGPS = True
                        End Select

                    Case cMessage.e_MessageType.e_MessageType_ArduPilot_ModeChange
                        lblGPSType.Text = "ArduPilot ASCII"
                        lblGPSMessage.Text = GetResString(, "Mode Change")
                        If InStr(.Packet, vbTab) <> 0 Then
                            sSplit = Split(.Packet, vbTab)
                            sMode = sSplit(0)
                            sModeNumber = sSplit(1)
                        Else
                            sMode = .Packet
                        End If
                        bNewWaypoint = True

                    Case cMessage.e_MessageType.e_MessageType_ArduPilot_Attitude, cMessage.e_MessageType.e_MessageType_ArduPilot_GPS
                        lblGPSType.Text = "ArduPilot ASCII"
                        lblGPSMessage.Text = GetResString(, "ArduPilot Message")
                        sSplit = Split(.Packet, ",")
                        Try
                            For nCount = 0 To UBound(sSplit)
                                sValues = Split(sSplit(nCount), ":")
                                If UBound(sValues) = 1 Then
                                    sValues(1) = ConvertPeriodToLocal(sValues(1))
                                    Select Case UCase(sValues(0))
                                        Case "RLL"
                                            nRoll = -Convert.ToSingle(sValues(1))
                                            bNewAttitude = True
                                        Case "PCH"
                                            nPitch = -Convert.ToSingle(sValues(1))
                                            bNewAttitude = True
                                        Case "CRS", "COG"
                                            nHeading = Convert.ToSingle(sValues(1))
                                            If nHeading < 0 Then
                                                nHeading = nHeading + 360
                                            End If
                                            nYaw = nHeading
                                            bNewAttitude = True

                                        Case "LAT"
                                            nLatitude = ConvertLatLongFormat(Convert.ToDouble(sValues(1)) / 1000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                                            bNewGPS = True
                                        Case "LON"
                                            nLongitude = ConvertLatLongFormat(Convert.ToDouble(sValues(1)) / 1000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                                            bNewGPS = True
                                        Case "SOG", "SPD"
                                            nGroundSpeed = ConvertSpeed(sValues(1), e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                            bNewGPS = True
                                        Case "ASP"
                                            nAirSpeed = ConvertSpeed(sValues(1), e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                            bNewGPS = True
                                        Case "FIX", "LOC"
                                            nFix = System.Math.Abs(Convert.ToInt32(sValues(1)) - 1)
                                            bNewGPS = True
                                        Case "ALT"
                                            nAltitude = ConvertDistance(sValues(1), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                            bNewGPS = True
                                        Case "SAT"
                                            nSats = Convert.ToInt32(sValues(1))
                                            bNewGPS = True
                                        Case "BTV"
                                            nBattery = (Convert.ToSingle(sValues(1)) / 1000).ToString("#.00")
                                            bNewWaypoint = True
                                        Case "HDO"
                                            nHDOP = (Convert.ToSingle(sValues(1)) / 100).ToString("#.00")
                                            bNewGPS = True

                                        Case "TXS", "STT"
                                            sModeNumber = sValues(1)
                                            'sMode = ""
                                            bNewWaypoint = True
                                        Case "WPN"
                                            nWaypoint = Convert.ToInt32(sValues(1))
                                            bNewWaypoint = True
                                        Case "THH"
                                            nThrottle = Convert.ToSingle(sValues(1)) / 100
                                            bNewWaypoint = True
                                        Case "AMP"
                                            nAmperage = Convert.ToSingle(sValues(1)) / 100
                                            bNewWaypoint = True
                                        Case "MAH"
                                            nMAH = Convert.ToInt32(sValues(1))
                                            bNewWaypoint = True
                                        Case "DST"
                                            nDistance = ConvertDistance(sValues(1), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                            bNewWaypoint = True
                                        Case "ALH"
                                            nWaypointAlt = ConvertDistance(sValues(1), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                            bNewWaypoint = True
                                    End Select
                                End If
                            Next
                        Catch err2 As Exception
                            Debug.Print(err2.Message)
                        End Try

                    Case cMessage.e_MessageType.e_MessageType_UDB_SetHome
                        lblGPSType.Text = GetResString(, "Type F13")
                        sSplit = Split(.Packet, ":")
                        Try
                            'Debug.Print("Time = " & sSplit(0))
                            For nCount = 1 To UBound(sSplit)
                                Select Case nCount
                                    Case 1
                                        sTemp = Mid(sSplit(nCount), 6)
                                        nLatitude = ConvertLatLongFormat(Convert.ToDouble(sTemp) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                                    Case 2
                                        sTemp = Mid(sSplit(nCount), 6)
                                        nLongitude = ConvertLatLongFormat(Convert.ToDouble(sTemp) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                                    Case 3
                                        sTemp = Mid(sSplit(nCount), 2)
                                        nAltitude = ConvertDistance(Convert.ToDouble(sTemp) / 100, e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                        WebBrowser1.Invoke(New MyDelegate(AddressOf setHomeLatLng))
                                End Select
                            Next nCount
                        Catch
                        End Try


                    Case cMessage.e_MessageType.e_MessageType_UDB
                        lblGPSType.Text = "Type F2"
                        sSplit = Split(.Packet, ":")
                        Try
                            'Debug.Print("Time = " & sSplit(0))
                            For nCount = 1 To UBound(sSplit) - 1
                                Select Case nCount
                                    Case 1
                                        nFix = Convert.ToInt32(Mid(sSplit(nCount), 3, 1) = "1")
                                        If Mid(sSplit(nCount), 4, 1) = "1" Then
                                            sMode = GetResString(, "Autonomous")
                                        Else
                                            sMode = GetResString(, "Manual_Mode")
                                        End If
                                    Case 2
                                        sTemp = Mid(sSplit(nCount), 2)
                                        nLatitude = ConvertLatLongFormat(Convert.ToDouble(sTemp) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                                    Case 3
                                        sTemp = Mid(sSplit(nCount), 2)
                                        nLongitude = ConvertLatLongFormat(Convert.ToDouble(sTemp) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                                    Case 4
                                        sTemp = Mid(sSplit(nCount), 2)
                                        nAltitude = ConvertDistance(Convert.ToDouble(sTemp) / 100, e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                    Case 5
                                        sTemp = Mid(sSplit(nCount), 2)
                                        nWaypoint = Convert.ToInt32(sTemp)
                                    Case 7
                                        sTemp = Mid(sSplit(nCount), 2)
                                        nYawComponent1 = Convert.ToSingle(sTemp)
                                    Case 10
                                        sTemp = Mid(sSplit(nCount), 2)
                                        nYaw = (System.Math.Atan2(-nYawComponent1, Convert.ToSingle(sTemp)) / (2 * pi)) * 360
                                    Case 12
                                        sTemp = Mid(sSplit(nCount), 2)
                                        nRoll = (System.Math.Asin(sTemp / 16384.0) / (2 * pi)) * 360
                                    Case 13
                                        sTemp = Mid(sSplit(nCount), 2)
                                        nPitch = (System.Math.Asin(sTemp / 16384.0) / (2 * pi)) * 360
                                    Case 14
                                        sTemp = Mid(sSplit(nCount), 2)
                                        If Convert.ToSingle(sTemp) < 0 Then
                                            nRoll = 180 - nRoll
                                        End If
                                    Case 15
                                        sTemp = Mid(sSplit(nCount), 2)
                                        nHeading = Convert.ToSingle(sTemp) / 100
                                        'Debug.Print("Heading = " & nHeading)
                                        If nHeading < 0 Then
                                            nHeading = nHeading + 360
                                        End If
                                    Case 16
                                        sTemp = Mid(sSplit(nCount), 2)
                                        nGroundSpeed = ConvertSpeed(Convert.ToSingle(sTemp) / 100, e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                    Case 18
                                        sTemp = Mid(sSplit(nCount), 4)
                                        If sTemp <> "" And sTemp <> "0" Then
                                            nBattery = (Convert.ToSingle(sTemp) / 1000).ToString("#.00")
                                        Else
                                            nBattery = 0
                                        End If
                                    Case 19
                                        sTemp = Mid(sSplit(nCount), 3)
                                        If sTemp <> "" And sTemp <> "0" Then
                                            nAirSpeed = ConvertSpeed(Convert.ToSingle(sTemp) / 100, e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                        Else
                                            nAirSpeed = 0
                                        End If
                                    Case 26
                                        sTemp = Mid(sSplit(nCount), 4)
                                        If sTemp <> "" Then
                                            nSats = Convert.ToInt32(sTemp)
                                        Else
                                            nSats = 0
                                        End If
                                    Case 27
                                        sTemp = Mid(sSplit(nCount), 3)
                                        If sTemp <> "" And sTemp <> "0" Then
                                            nHDOP = (Convert.ToSingle(sTemp) / 5).ToString("#.00")
                                        Else
                                            nHDOP = 0
                                        End If
                                    Case 28
                                        sTemp = Mid(sSplit(nCount), 4)
                                        nServoInput(0) = Convert.ToInt16(sTemp) / 2
                                    Case 29
                                        sTemp = Mid(sSplit(nCount), 4)
                                        nServoInput(1) = Convert.ToInt16(sTemp) / 2
                                    Case 30
                                        sTemp = Mid(sSplit(nCount), 4)
                                        nServoInput(2) = Convert.ToInt16(sTemp) / 2
                                    Case 31
                                        sTemp = Mid(sSplit(nCount), 4)
                                        nServoInput(3) = Convert.ToInt16(sTemp) / 2
                                    Case 32
                                        sTemp = Mid(sSplit(nCount), 4)
                                        nServoInput(4) = Convert.ToInt16(sTemp) / 2
                                    Case 33
                                        sTemp = Mid(sSplit(nCount), 4)
                                        nServoOutput(0) = Convert.ToInt16(sTemp) / 2
                                    Case 34
                                        sTemp = Mid(sSplit(nCount), 4)
                                        nServoOutput(1) = Convert.ToInt16(sTemp) / 2
                                    Case 35
                                        sTemp = Mid(sSplit(nCount), 4)
                                        nServoOutput(2) = Convert.ToInt16(sTemp) / 2
                                    Case 36
                                        sTemp = Mid(sSplit(nCount), 4)
                                        nServoOutput(3) = Convert.ToInt16(sTemp) / 2
                                    Case 37
                                        sTemp = Mid(sSplit(nCount), 4)
                                        nServoOutput(4) = Convert.ToInt16(sTemp) / 2
                                    Case 38
                                        sTemp = Mid(sSplit(nCount), 4)
                                        nServoOutput(5) = Convert.ToInt16(sTemp) / 2
                                End Select
                            Next nCount
                            If nThrottleChannel > 0 Then
                                If nServoOutput(nThrottleChannel - 1) <> 0 Then
                                    nThrottle = (nServoOutput(nThrottleChannel - 1) - tbarServo1.Minimum) / (tbarServo1.Maximum - tbarServo1.Minimum)
                                Else
                                    nThrottle = 0
                                End If
                                bFireWaypoint = True
                            End If
                            bNewGPS = True
                            bNewAttitude = True
                            bNewWaypoint = True
                        Catch e2 As Exception
                            Debug.Print(e2.Message)
                        End Try

                    Case cMessage.e_MessageType.e_MessageType_SiRF
                        lblGPSType.Text = "SiRF"
                        Select Case .ID
                            Case 91
                                lblGPSMessage.Text = GetResString(, "Geonavigation Data")
                                nFix = ConvertHexToDec(Mid(.Packet, 4, 1)) And 3
                                nLatitude = ConvertLatLongFormat(ConvertHexToDec(Mid(.Packet, 24, 4), False) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                                nLongitude = ConvertLatLongFormat(ConvertHexToDec(Mid(.Packet, 28, 4), False) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                                nAltitude = ConvertDistance(ConvertHexToDec(Mid(.Packet, 36, 4), False) / 100, e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                nGroundSpeed = ConvertSpeed(ConvertHexToDec(Mid(.Packet, 41, 2), False) / 100, e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                nHeading = ConvertHexToDec(Mid(.Packet, 43, 2), False, False) / 100
                                nYaw = nHeading
                                nSats = ConvertHexToDec(Mid(.Packet, 89, 1))
                                nHDOP = ConvertHexToDec(Mid(.Packet, 90, 1)) / 5
                                bNewGPS = True
                        End Select

                    Case cMessage.e_MessageType.e_MessageType_ArduIMU_Binary
                        lblGPSType.Text = GetResString(, "ArduIMU Binary")
                        Select Case Asc(Mid(.Packet, 2, 1))
                            Case 2
                                lblGPSMessage.Text = GetResString(, "Attitude Data")
                                nRoll = ConvertHexToDec(Mid(.Packet, 3, 2)) / 100
                                nPitch = ConvertHexToDec(Mid(.Packet, 5, 2)) / 100
                                nYaw = ConvertHexToDec(Mid(.Packet, 7, 2)) / 100
                                bNewAttitude = True
                            Case 3
                                lblGPSMessage.Text = GetResString(, "GPS Data")
                                nLongitude = ConvertLatLongFormat(ConvertHexToDec(Mid(.Packet, 3, 4)) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                                nLatitude = ConvertLatLongFormat(ConvertHexToDec(Mid(.Packet, 7, 4)) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                                nAltitude = ConvertDistance(ConvertHexToDec(Mid(.Packet, 11, 2)), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                'System.Diagnostics.Debug.Print("Speed=" & ConvertHexToDec(Mid(.Packet, 13, 2)) / 100)
                                nGroundSpeed = ConvertSpeed(ConvertHexToDec(Mid(.Packet, 13, 2), , False) / 100, e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                nHeading = ConvertHexToDec(Mid(.Packet, 15, 2), , False) / 100
                                If .PacketLength >= 31 Then
                                    nSats = Asc(Mid(.Packet, 30))
                                    nFix = Asc(Mid(.Packet, 31))
                                End If
                                bNewGPS = True

                                'System.Diagnostics.Debug.Print("Lat=" & sLatitude & ",Long=" & sLongitude)
                        End Select

                    Case cMessage.e_MessageType.e_MessageType_MAV
                        lblGPSType.Text = "MAVlink"
                        'Debug.Print("Message ID=" & Asc(Mid(.Packet, 6, 1)) & ",Length=" & Asc(Mid(.Packet, 2, 1))) '& ",Packet=" & .VisibleSentence)
                        Select Case Asc(Mid(.Packet, 6, 1))
                            Case 27
                                lblGPSMessage.Text = GetResString(, "GPS Status")
                                nSats = Asc(Mid(.Packet, 7, 1))
                                bNewGPS = True
                            Case 28
                                lblGPSMessage.Text = GetResString(, "Raw IMU")
                                Try
                                    nSensor(0) = ConvertMavlinkToInteger(Mid(.Packet, 15, 2), True)
                                    nSensor(1) = ConvertMavlinkToInteger(Mid(.Packet, 17, 2), True)
                                    nSensor(2) = ConvertMavlinkToInteger(Mid(.Packet, 19, 2), True)
                                    nSensor(3) = ConvertMavlinkToInteger(Mid(.Packet, 21, 2), True)
                                    nSensor(4) = ConvertMavlinkToInteger(Mid(.Packet, 23, 2), True)
                                    nSensor(5) = ConvertMavlinkToInteger(Mid(.Packet, 25, 2), True)
                                    nSensor(6) = ConvertMavlinkToInteger(Mid(.Packet, 27, 2), True)
                                    nSensor(7) = ConvertMavlinkToInteger(Mid(.Packet, 29, 2), True)
                                    nSensor(8) = ConvertMavlinkToInteger(Mid(.Packet, 31, 2), True)
                                Catch
                                End Try
                                bNewAttitude = True
                            Case 30
                                lblGPSMessage.Text = GetResString(, "Attitude")
                                nRoll = ConvertMavlinkToSingle(Mid(.Packet, 15, 4)) * 180 / Math.PI
                                nPitch = ConvertMavlinkToSingle(Mid(.Packet, 19, 4)) * 180 / Math.PI
                                nYaw = ConvertMavlinkToSingle(Mid(.Packet, 23, 4)) * 180 / Math.PI
                                bNewAttitude = True
                            Case 32
                                lblGPSMessage.Text = GetResString(, "GPS Raw")
                                nFix = Asc(Mid(.Packet, 15, 1)) - 1
                                nLatitude = ConvertMavlinkToSingle(Mid(.Packet, 16, 4))
                                nLongitude = ConvertMavlinkToSingle(Mid(.Packet, 20, 4))
                                nAltitude = ConvertDistance(ConvertMavlinkToSingle(Mid(.Packet, 24, 4)), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                nHDOP = ConvertMavlinkToSingle(Mid(.Packet, 32, 4))
                                nGroundSpeed = ConvertSpeed(ConvertMavlinkToSingle(Mid(.Packet, 36, 4)), e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                nHeading = ConvertMavlinkToSingle(Mid(.Packet, 40, 4))
                                bNewGPS = True
                            Case 33
                                lblGPSMessage.Text = GetResString(, "Global Position")
                                nLatitude = ConvertMavlinkToSingle(Mid(.Packet, 15, 4))
                                nLongitude = ConvertMavlinkToSingle(Mid(.Packet, 19, 4))
                                nAltitude = ConvertDistance(ConvertMavlinkToSingle(Mid(.Packet, 23, 4)), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                nGroundSpeed = ConvertSpeed(Math.Sqrt(ConvertMavlinkToSingle(Mid(.Packet, 27, 4) ^ 2 + ConvertMavlinkToSingle(Mid(.Packet, 31, 4) ^ 2))), e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                nHeading = Math.Atan2(ConvertMavlinkToSingle(Mid(.Packet, 27, 4)), ConvertMavlinkToSingle(Mid(.Packet, 31, 4))) * 180 / Math.PI
                                bNewGPS = True
                            Case 34
                                lblGPSMessage.Text = GetResString(, "System Status")
                                'sModeNumber = Mid(.Packet, 7, 2)
                                sMode = GetMavMode(Asc(Mid(.Packet, 7, 2)))
                                nBattery = CInt("&h" & Hex(Asc(Mid(.Packet, 12, 1))) & Hex(Asc(Mid(.Packet, 13, 1)))) / 1000
                                bNewWaypoint = True
                            Case 35
                                lblGPSMessage.Text = GetResString(, "Channel Raw")
                                nServoInput(0) = ConvertMavlinkToInteger(Mid(.Packet, 7, 2))
                                nServoInput(1) = ConvertMavlinkToInteger(Mid(.Packet, 9, 2))
                                nServoInput(2) = ConvertMavlinkToInteger(Mid(.Packet, 11, 2))
                                nServoInput(3) = ConvertMavlinkToInteger(Mid(.Packet, 13, 2))
                                nServoInput(4) = ConvertMavlinkToInteger(Mid(.Packet, 15, 2))
                                nServoInput(5) = ConvertMavlinkToInteger(Mid(.Packet, 17, 2))
                                nServoInput(6) = ConvertMavlinkToInteger(Mid(.Packet, 19, 2))
                                nServoInput(7) = ConvertMavlinkToInteger(Mid(.Packet, 21, 2))

                                bNewWaypoint = True
                                If nThrottleChannel > 0 Then
                                    If nServoInput(nThrottleChannel - 1) <> 0 Then
                                        nThrottle = (nServoInput(nThrottleChannel - 1) - tbarServo1.Minimum) / (tbarServo1.Maximum - tbarServo1.Minimum)
                                    Else
                                        nThrottle = 0
                                    End If
                                    bNewWaypoint = True
                                End If
                            Case 39
                                lblGPSMessage.Text = GetResString(, "Waypoint")
                                nWaypoint = ConvertMavlinkToInteger(Mid(.Packet, 9, 2))
                                'nLatitude = ConvertMavlinkToSingle(Mid(.Packet, 21, 4))
                                'nLongitude = ConvertMavlinkToSingle(Mid(.Packet, 25, 4))
                                nWaypointAlt = ConvertDistance(ConvertMavlinkToSingle(Mid(.Packet, 29, 4)), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                bNewWaypoint = True
                            Case 42, 46
                                lblGPSMessage.Text = GetResString(, "Current Waypoint")
                                nWaypoint = ConvertMavlinkToInteger(Mid(.Packet, 7, 2))
                                bNewWaypoint = True
                        End Select

                    Case cMessage.e_MessageType.e_MessageType_ArduPilotMega_Binary
                        lblGPSType.Text = GetResString(, "AP Mega Binary")
                        Select Case Asc(Mid(.Packet, 2, 1))
                            Case 1
                                System.Diagnostics.Debug.Print(oMessage.VisibleSentence)
                                lblGPSMessage.Text = GetResString(, "Heatbeat Data")
                                sModeNumber = Asc(Mid(.Packet, 3, 1))
                                nBattery = Convert.ToSingle(Asc(Mid(.Packet, 6, 2)) / 100).ToString("#.00")
                                bNewWaypoint = True
                            Case 2
                                lblGPSMessage.Text = GetResString(, "Attitude Data")
                                nRoll = ConvertHexToDec(Mid(.Packet, 4, 2)) / 100
                                nPitch = ConvertHexToDec(Mid(.Packet, 6, 2)) / 100
                                nYaw = ConvertHexToDec(Mid(.Packet, 8, 2)) / 100
                                bNewAttitude = True

                            Case 3
                                lblGPSMessage.Text = GetResString(, "Location Data")
                                nLatitude = ConvertLatLongFormat(ConvertHexToDec(Mid(.Packet, 4, 4)) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                                nLongitude = ConvertLatLongFormat(ConvertHexToDec(Mid(.Packet, 8, 4)) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                                nAltitude = ConvertDistance(ConvertHexToDec(Mid(.Packet, 12, 2)), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                'System.Diagnostics.Debug.Print("Speed=" & ConvertHexToDec(Mid(.Packet, 13, 2)) / 100)
                                nGroundSpeed = ConvertSpeed(ConvertHexToDec(Mid(.Packet, 14, 2), , False) / 100, e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                nHeading = ConvertHexToDec(Mid(.Packet, 16, 2), , False) / 100
                                'If .PacketLength >= 31 Then
                                '    nSats = Asc(Mid(.Packet, 30))
                                '    nFix = Asc(Mid(.Packet, 31))
                                'End If
                                bNewGPS = True
                            Case 6
                                nSats = ConvertHexToDec(Mid(.Packet, 13, 1))
                                bNewGPS = True
                            Case Else
                                System.Diagnostics.Debug.Print("ID=" & Asc(Mid(.Packet, 2, 1)) & ",Packet=" & .Packet & ",Message=" & .VisibleSentence & vbCrLf)
                                'System.Diagnostics.Debug.Print("Lat=" & sLatitude & ",Long=" & sLongitude)
                        End Select
                End Select
            End If
        End With

        If bNewAttitude = True And chkFullDataFile.Checked = False Then
            If Now.Ticks - nLastAttitude > (1000 / (cboAttitude.SelectedIndex)) * 10000 And cboAttitude.SelectedIndex <> 0 Then
                nLastAttitude = Now.Ticks
                bNewAttitude = False
                GpS_Parser1_AttitudeChange1(nPitch, nRoll, nYaw)
                If nServoInput(0) <> 0 Then
                    lstEvents.Items.Insert(0, GetResString(, "Pitch") & "=" & nPitch & "," & GetResString(, "Roll") & "=" & nRoll & "," & GetResString(, "Yaw") & "=" & nYaw & ",Servo1=" & nServoInput(0) & ",Servo2=" & nServoInput(1) & ",Servo3=" & nServoInput(2) & ",Servo4=" & nServoInput(3) & ",Servo5=" & nServoInput(4) & ",Servo6=" & nServoInput(5) & ",Servo7=" & nServoInput(6) & ",Servo8=" & nServoInput(7))
                Else
                    lstEvents.Items.Insert(0, GetResString(, "Pitch") & "=" & nPitch & "," & GetResString(, "Roll") & "=" & nRoll & "," & GetResString(, "Yaw") & "=" & nYaw)
                End If
            End If
        End If

        If bNewGPS = True Then
            If Now.Ticks - nLastGPS > (1000 / (cboGPS.SelectedIndex)) * 10000 And cboGPS.SelectedIndex <> 0 Then
                'System.Diagnostics.Debug.Print("Diff=" & Now.Ticks - nLastGPS)
                If nAltitude <> 0 And nLastAlt <> 0 Then
                    nAltChange = -(nLastAlt - nAltitude) / ((Now.Ticks - nLastGPS) / 600000000)
                    If Double.IsNaN(nAltChange) = True Then
                        nAltChange = 0
                    End If
                End If
                nLastAlt = nAltitude
                nLastGPS = Now.Ticks
                bNewGPS = False
                GpS_Parser1_GpsData1(nLatitude, nLongitude, nAltitude, nGroundSpeed, nHeading, nSats, nFix, nHDOP, nAltChange, nAirSpeed)
                lstEvents.Items.Insert(0, "Lat=" & Convert.ToDouble(nLatitude).ToString("0.000000") & ",Long=" & Convert.ToDouble(nLongitude).ToString("0.000000") & ",Alt=" & nAltitude & ",Spd=" & nGroundSpeed & ",Hdg=" & nHeading & ",Sats=" & nSats & ",Fix=" & nFix & ",HDOP=" & nHDOP)
            End If
        End If

        If bNewWaypoint = True And chkFullDataFile.Checked = False Then
            If Now.Ticks - nLastWaypoint > (1000 / (cboWaypoint.SelectedIndex)) * 10000 And cboWaypoint.SelectedIndex <> 0 Then
                nLastWaypoint = Now.Ticks
                bNewWaypoint = False
                GPS_Parser1_Waypoints(nWaypoint, nDistance, nBattery, sModeNumber, nThrottle)
                lstEvents.Items.Insert(0, "WP#=" & nWaypoint & ",Dist=" & nDistance & ",Battery=" & nBattery & ",Mode=" & sModeNumber & ",Throttle=" & nThrottle)
            End If
        End If
        Try
            For nCount = nMaxListboxRecords To lstEvents.Items.Count - 1
                lstEvents.Items.RemoveAt(nMaxListboxRecords)
            Next
        Catch
        End Try
        'System.Windows.Forms.Application.DoEvents()
    End Sub
    Private Sub InitServoCombos()
        Dim nCount As Integer
        Dim nCount2 As Integer

        AddItemToServoCombos("None")
        For nCount = 0 To 1
            For nCount2 = 1 To 8
                AddItemToServoCombos(GetResString(, "Servo_Mult", , , , nCount2) & IIf(nCount = 0, " " & GetResString(, "In_Label"), " " & GetResString(, "Out_Label")))
            Next
        Next

        AddItemToServoCombos(GetResString(, "Accel_Mult", , , , "X"))
        AddItemToServoCombos(GetResString(, "Accel_Mult", , , , "Y"))
        AddItemToServoCombos(GetResString(, "Accel_Mult", , , , "Z"))

        AddItemToServoCombos(GetResString(, "Gyro_Mult", , , , "X"))
        AddItemToServoCombos(GetResString(, "Gyro_Mult", , , , "Y"))
        AddItemToServoCombos(GetResString(, "Gyro_Mult", , , , "Z"))

        AddItemToServoCombos(GetResString(, "Mag_Mult", , , , "X"))
        AddItemToServoCombos(GetResString(, "Mag_Mult", , , , "Y"))
        AddItemToServoCombos(GetResString(, "Mag_Mult", , , , "Z"))

        AddItemToServoCombos(GetResString(, "Pitch"))
        AddItemToServoCombos(GetResString(, "Roll"))
        AddItemToServoCombos(GetResString(, "Yaw"))

        AddItemToServoCombos(GetResString(, "Ground Speed"))
        AddItemToServoCombos(GetResString(, "Air Speed"))

    End Sub
    Private Sub AddItemToServoCombos(ByVal itemName As String)
        cboServo1.Items.Add(itemName)
        cboServo2.Items.Add(itemName)
        cboServo3.Items.Add(itemName)
        cboServo4.Items.Add(itemName)
        cboServo5.Items.Add(itemName)
        cboServo6.Items.Add(itemName)
        cboServo7.Items.Add(itemName)
        cboServo8.Items.Add(itemName)

        cboSensors1.Items.Add(itemName)
        cboSensors2.Items.Add(itemName)
        cboSensors3.Items.Add(itemName)
        cboSensors4.Items.Add(itemName)
        cboSensors5.Items.Add(itemName)
        cboSensors6.Items.Add(itemName)
        cboSensors7.Items.Add(itemName)
        cboSensors8.Items.Add(itemName)
    End Sub
    Private Sub UpdateServoSliders()
        SetServoValue("None", 0)

        SetServoValue(GetResString(, "Servo_Mult") & " 1 " & GetResString(, "In_Label"), nServoInput(0), 2000, 1000)
        SetServoValue(GetResString(, "Servo_Mult") & " 2 " & GetResString(, "In_Label"), nServoInput(1), 2000, 1000)
        SetServoValue(GetResString(, "Servo_Mult") & " 3 " & GetResString(, "In_Label"), nServoInput(2), 2000, 1000)
        SetServoValue(GetResString(, "Servo_Mult") & " 4 " & GetResString(, "In_Label"), nServoInput(3), 2000, 1000)
        SetServoValue(GetResString(, "Servo_Mult") & " 5 " & GetResString(, "In_Label"), nServoInput(4), 2000, 1000)
        SetServoValue(GetResString(, "Servo_Mult") & " 6 " & GetResString(, "In_Label"), nServoInput(5), 2000, 1000)
        SetServoValue(GetResString(, "Servo_Mult") & " 7 " & GetResString(, "In_Label"), nServoInput(6), 2000, 1000)
        SetServoValue(GetResString(, "Servo_Mult") & " 8 " & GetResString(, "In_Label"), nServoInput(7), 2000, 1000)

        SetServoValue(GetResString(, "Servo_Mult") & " 1 " & GetResString(, "Out_Label"), nServoOutput(0), 2000, 1000)
        SetServoValue(GetResString(, "Servo_Mult") & " 2 " & GetResString(, "Out_Label"), nServoOutput(1), 2000, 1000)
        SetServoValue(GetResString(, "Servo_Mult") & " 3 " & GetResString(, "Out_Label"), nServoOutput(2), 2000, 1000)
        SetServoValue(GetResString(, "Servo_Mult") & " 4 " & GetResString(, "Out_Label"), nServoOutput(3), 2000, 1000)
        SetServoValue(GetResString(, "Servo_Mult") & " 5 " & GetResString(, "Out_Label"), nServoOutput(4), 2000, 1000)
        SetServoValue(GetResString(, "Servo_Mult") & " 6 " & GetResString(, "Out_Label"), nServoOutput(5), 2000, 1000)
        SetServoValue(GetResString(, "Servo_Mult") & " 7 " & GetResString(, "Out_Label"), nServoOutput(6), 2000, 1000)
        SetServoValue(GetResString(, "Servo_Mult") & " 8 " & GetResString(, "Out_Label"), nServoOutput(7), 2000, 1000)

        SetServoValue(GetResString(, "Accel_Mult", , , , "X"), nSensor(0), 2500, -2500)
        SetServoValue(GetResString(, "Accel_Mult", , , , "Y"), nSensor(1), 2500, -2500)
        SetServoValue(GetResString(, "Accel_Mult", , , , "Z"), nSensor(2), 2500, -2500)

        SetServoValue(GetResString(, "Gyro_Mult", , , , "X"), nSensor(3), 2000, 1500)
        SetServoValue(GetResString(, "Gyro_Mult", , , , "Y"), nSensor(4), 2000, 1500)
        SetServoValue(GetResString(, "Gyro_Mult", , , , "Z"), nSensor(5), 2000, 1500)

        SetServoValue(GetResString(, "Mag_Mult", , , , "X"), nSensor(6))
        SetServoValue(GetResString(, "Mag_Mult", , , , "Y"), nSensor(7))
        SetServoValue(GetResString(, "Mag_Mult", , , , "Z"), nSensor(8))

        SetServoValue(GetResString(, "Pitch"), nSensor(9), 90, -90)
        SetServoValue(GetResString(, "Roll"), nSensor(10), 90, -90)
        SetServoValue(GetResString(, "Yaw"), nSensor(11), 360, 0)

        SetServoValue(GetResString(, "Ground Speed"), nSensor(12), , 0)
        SetServoValue(GetResString("Air Speed"), nSensor(13), , 0)
    End Sub
    Private Sub SetServoValue(ByVal valueName As String, ByVal value As Long, Optional ByVal setMax As Integer = -1, Optional ByVal setMin As Integer = -1)
        If cboServo1.Text = valueName Then
            UdpateServoSliderValue(cboServo1, tbarServo1, lblServo1, value, setMax, setMin)
        End If
        If cboServo2.Text = valueName Then
            UdpateServoSliderValue(cboServo2, tbarServo2, lblServo2, value, setMax, setMin)
        End If
        If cboServo3.Text = valueName Then
            UdpateServoSliderValue(cboServo3, tbarServo3, lblServo3, value, setMax, setMin)
        End If
        If cboServo4.Text = valueName Then
            UdpateServoSliderValue(cboServo4, tbarServo4, lblServo4, value, setMax, setMin)
        End If
        If cboServo5.Text = valueName Then
            UdpateServoSliderValue(cboServo5, tbarServo5, lblServo5, value, setMax, setMin)
        End If
        If cboServo6.Text = valueName Then
            UdpateServoSliderValue(cboServo6, tbarServo6, lblServo6, value, setMax, setMin)
        End If
        If cboServo7.Text = valueName Then
            UdpateServoSliderValue(cboServo7, tbarServo7, lblServo7, value, setMax, setMin)
        End If
        If cboServo8.Text = valueName Then
            UdpateServoSliderValue(cboServo8, tbarServo8, lblServo8, value, setMax, setMin)
        End If

        If cboSensors1.Text = valueName Then
            UdpateServoSliderValue(cboSensors1, tbarSensor1, lblSensor1, value, setMax, setMin)
        End If
        If cboSensors2.Text = valueName Then
            UdpateServoSliderValue(cboSensors2, tbarSensor2, lblSensor2, value, setMax, setMin)
        End If
        If cboSensors3.Text = valueName Then
            UdpateServoSliderValue(cboSensors3, tbarSensor3, lblSensor3, value, setMax, setMin)
        End If
        If cboSensors4.Text = valueName Then
            UdpateServoSliderValue(cboSensors4, tbarSensor4, lblSensor4, value, setMax, setMin)
        End If
        If cboSensors5.Text = valueName Then
            UdpateServoSliderValue(cboSensors5, tbarSensor5, lblSensor5, value, setMax, setMin)
        End If
        If cboSensors6.Text = valueName Then
            UdpateServoSliderValue(cboSensors6, tbarSensor6, lblSensor6, value, setMax, setMin)
        End If
        If cboSensors7.Text = valueName Then
            UdpateServoSliderValue(cboSensors7, tbarSensor7, lblSensor7, value, setMax, setMin)
        End If
        If cboSensors8.Text = valueName Then
            UdpateServoSliderValue(cboSensors8, tbarSensor8, lblSensor8, value, setMax, setMin)
        End If

    End Sub
    Private Sub UdpateServoSliderValue(ByVal inputCombo As ComboBox, ByVal inputSlider As TrackBar, ByVal displayLabel As Label, ByVal value As Long, Optional ByVal setMax As Integer = -1, Optional ByVal setMin As Integer = -1)
        If inputCombo.SelectedIndex = 0 Then
            inputSlider.Visible = False
            displayLabel.Visible = False
        Else
            inputSlider.Visible = True
            displayLabel.Visible = True

            If setMin <> -1 Then
                inputSlider.Minimum = setMin
            End If
            If setMax <> -1 Then
                inputSlider.Maximum = setMax
            End If
            If value > inputSlider.Maximum Then
                inputSlider.Value = inputSlider.Maximum
            ElseIf value < inputSlider.Minimum Then
                inputSlider.Value = inputSlider.Minimum
            Else
                inputSlider.Value = value
            End If
            displayLabel.Text = value
        End If
    End Sub
    Private Sub serialPortIn_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles serialPortIn.Disposed
        tmrComPort.Enabled = False
        If bShutdown = True Then
            Exit Sub
        End If

        'System.Diagnostics.Debug.Print("Serial Port Disposed")
        EnableComButtons(True)
    End Sub

    Private Sub serialPortIn_ErrorReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialErrorReceivedEventArgs) Handles serialPortIn.ErrorReceived
        If bShutdown = True Then
            Exit Sub
        End If
        'System.Diagnostics.Debug.Assert(False)
        'System.Diagnostics.Debug.Print("serialPortIn_ErrorReceived - " & e.ToString)
    End Sub

    Private Sub cboComPort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboComPort.SelectedIndexChanged
        Dim bOpenState As Boolean

        bOpenState = serialPortIn.IsOpen
        If bOpenState Then
            serialPortIn.Close()
        End If
        serialPortIn.PortName = cboComPort.Text
        If bOpenState Then
            serialPortIn.Open()
        End If
    End Sub

    Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click

        tmrSearch.Enabled = False
        If serialPortIn.IsOpen = True Then
            cmdConnect.Text = GetResString(, "Connect")
            tmrComPort.Enabled = False
            Try
                serialPortIn.Close()
            Catch e2 As Exception
            End Try
            lblComPortStatus.Text = GetResString(, "Disconnected from", , , , serialPortIn.PortName)
            EnableComButtons(True)
            lblGPSType.Text = ""
            lblGPSMessage.Text = ""
        Else
            nLastComPort = -1
            nBaudRateIndex = -1
            lblGPSType.Text = ""
            lblGPSMessage.Text = ""
            tmrSearch_Tick(sender, e)
            tmrComPort.Enabled = True
        End If
        lblBandwidth.Text = ""
    End Sub

    Private Sub EnableComButtons(ByVal enable As Boolean)
        cboComPort.Enabled = enable
        cboBaudRate.Enabled = enable
        cmdSearch.Enabled = enable
        cmdSearchCOM.Enabled = enable
        cmdReloadComPorts.Enabled = enable
    End Sub
    Private Sub cmdSearchCOM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearchCOM.Click
        nLastComPort = 0
        nBaudRateIndex = cboBaudRate.SelectedIndex
        lblGPSType.Text = ""
        lblGPSMessage.Text = ""
        tmrSearch.Enabled = True
    End Sub

    Private Sub cboAttitude_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAttitude.SelectedIndexChanged
        Call SaveRegSetting(sRootRegistry & "\Settings", "Attitude Hz", cboAttitude.SelectedIndex)
    End Sub

    Private Sub cboGPS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGPS.SelectedIndexChanged
        Call SaveRegSetting(sRootRegistry & "\Settings", "GPS Hz", cboGPS.SelectedIndex)
    End Sub

    Private Sub cboWaypoint_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWaypoint.SelectedIndexChanged
        Call SaveRegSetting(sRootRegistry & "\Settings", "Waypoint Hz", cboWaypoint.SelectedIndex)
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        nLastComPort = -1
        'nLastComPort = cboBaudRate.SelectedIndex
        nBaudRateIndex = cboBaudRate.SelectedIndex
        lblGPSType.Text = ""
        lblGPSMessage.Text = ""
        tmrSearch.Enabled = True
    End Sub

    Private Sub tmrSearch_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSearch.Tick
        Try
            nAirSpeed = -1
            tmrSearch.Interval = 200
            If serialPortIn.IsOpen = True Then
                serialPortIn.Close()
            End If
            If nLastComPort = -1 Then
                serialPortIn.PortName = cboComPort.Text
            Else
                serialPortIn.PortName = cboComPort.Items(nLastComPort).ToString
            End If
            cboComPort.Text = serialPortIn.PortName
            lstInbound.Items.Insert(0, GetResString(, "Checking_baud", , , , cboBaudRate.Text))
            serialPortIn.BaudRate = cboBaudRate.Text
            Try
                With serialPortIn
                    '.BaseStream.Dispose()
                    '.DataBits = 8
                    '.StopBits = 1
                    '.Parity = Ports.Parity.None
                    '.ReadTimeout = 20
                    sBuffer = ""
                    sCommandLineBuffer = ""
                    lstCommandLineOutput.Items.Clear()
                    dStartTime = Nothing
                    .Open()
                End With
                'serialPortIn.BytesToRead()
                Call SaveRegSetting(sRootRegistry & "\Settings", "COM Port", cboComPort.Text)
                Call SaveRegSetting(sRootRegistry & "\Settings", "Baud Rate", cboBaudRate.Text)
                cmdConnect.Text = GetResString(, "Disconnect")
                lblComPortStatus.Text = GetResString(, "Connected_to", , , , serialPortIn.PortName, serialPortIn.BaudRate)
                EnableComButtons(False)
            Catch e3 As Exception
                lblComPortStatus.Text = e3.Message
                nBaudRateIndex = UBound(baudRates)
                cmdConnect.Text = GetResString(, "Connect")
                lblGPSType.Text = ""
                lblGPSMessage.Text = ""
                EnableComButtons(True)
            End Try
        Catch e2 As Exception
        End Try
        If nBaudRateIndex > -1 Then
            nBaudRateIndex = nBaudRateIndex + 1
            If nBaudRateIndex > UBound(baudRates) Then
                nBaudRateIndex = 0
                If nLastComPort > -1 Then
                    nLastComPort = nLastComPort + 1
                    If nLastComPort > cboComPort.Items.Count - 1 Then
                        nLastComPort = 0
                    End If
                End If
            End If
            cboBaudRate.Text = baudRates(nBaudRateIndex)
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Try
            bShutdown = True
            If serialPortIn.IsOpen = True Then
                serialPortIn.Close()
            End If
            Me.Dispose()
        Catch
        End Try
    End Sub

    Private Sub cboBaudRate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBaudRate.SelectedIndexChanged
        nBaudRateIndex = cboBaudRate.SelectedIndex
        serialPortIn.BaudRate = cboBaudRate.Text
    End Sub

    Private Sub chkPlay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPlay.CheckedChanged
        If bButtonStateLocked = True Then
            Exit Sub
        End If
        If chkPlay.Checked = True Then
            If serialPortIn.IsOpen = True Then
                cmdConnect_Click(sender, e)
            End If
            If nDataIndex >= UBound(rawData) Then
                nDataIndex = 0
            End If
            nHomeLat = ""
            nHomeLong = ""
            'If eMapSelection = e_MapSelection.e_MapSelection_GoogleMaps Then
            cmdClearMap_Click(sender, e)
            'End If

            SetPlayerState(e_PlayerState.e_PlayerState_Play)

            tmrPlayback.Enabled = True
            tmrPlayback_Tick(sender, e)

        Else
            tmrPlayback.Enabled = False
            SetPlayerState(e_PlayerState.e_PlayerState_Pause)
        End If
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        nDataIndex = TrackBar1.Value
        SetPlayerState(e_PlayerState.e_PlayerState_Pause)
        tmrPlayback.Enabled = False
        tmrPlayback_Tick(sender, e)
    End Sub

    Private Sub chkPause_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPause.CheckedChanged
        If bButtonStateLocked = True Then
            Exit Sub
        End If
        If chkPause.Checked = True Then
            tmrPlayback.Enabled = False
            SetPlayerState(e_PlayerState.e_PlayerState_Pause)
        End If
    End Sub

    Private Sub chkStepForward_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStepForward.CheckedChanged
        If bButtonStateLocked = True Then
            Exit Sub
        End If
        If chkStepForward.Checked = True Then
            'nDataIndex = nDataIndex + 1
            tmrPlayback.Enabled = False

            tmrPlayback_Tick(sender, e)
            SetPlayerState(e_PlayerState.e_PlayerState_Pause)
        End If
    End Sub

    Private Sub chkStepBack_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStepBack.CheckedChanged
        If bButtonStateLocked = True Then
            Exit Sub
        End If
        If chkStepBack.Checked = True Then
            tmrPlayback.Enabled = False

            nDataIndex = nDataIndex - 2
            tmrPlayback_Tick(sender, e)
            SetPlayerState(e_PlayerState.e_PlayerState_Pause)
        End If
    End Sub

    Private Sub cboOutputFiles_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOutputFiles.TextChanged
        tmrPlayback.Enabled = False
        SetPlayerState(e_PlayerState.e_PlayerState_Pause)
        If Trim(cboOutputFiles.Text) <> "" Then
            If Dir(txtOutputFolder.Text & cboOutputFiles.Text, FileAttribute.Normal) <> "" Then
                LoadDataFile(txtOutputFolder.Text & cboOutputFiles.Text)
                SetPlayerState(e_PlayerState.e_PlayerState_Loaded)
            Else
                SetPlayerState(e_PlayerState.e_PlayerState_RecordReady)
            End If
        End If
    End Sub

    Private Sub frmMain_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        If bStartup = True Then
            Exit Sub
        End If
        If Me.WindowState = FormWindowState.Normal Then
            Call SaveRegSetting(sRootRegistry & "\Settings", "Form Top", Me.Top)
            Call SaveRegSetting(sRootRegistry & "\Settings", "Form Left", Me.Left)
            Call SaveRegSetting(sRootRegistry & "\Settings", "Form Height", Me.Height)
            Call SaveRegSetting(sRootRegistry & "\Settings", "Form Width", Me.Width)
            Call SaveRegSetting(sRootRegistry & "\Settings", "Form WindowState", Me.WindowState)
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Call SaveRegSetting(sRootRegistry & "\Settings", "Form WindowState", Me.WindowState)
        End If
    End Sub

    Private Sub frmMain_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If bInstruments(e_Instruments.e_Instruments_3DModel) = True Then
            _3DMesh1.DrawMesh(GetPitch(nPitch), GetRoll(nRoll), GetYaw(nYaw), False, sModelName, GetRootPath() & "3D Models\")
            'System.Diagnostics.Debug.Print("Paint " & Now)
        End If
    End Sub

    Private Sub tabMapView_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabMapView.SelectedIndexChanged
        ResizeForm()
        Select Case tabMapView.SelectedIndex
            Case 1
                If bFirstVideoCapture1 = False Then
                    LoadComboWithCameras(cboLiveCameraSelect1, sSelectedCamera1, True)
                    bFirstVideoCapture1 = True
                    'bFirstVideoCapture1 = DirectShowControl1.StartCapture(cboLiveCameraSelect2.SelectedIndex)
                End If
            Case Else
                If bFirstVideoCapture1 = True Then
                    DirectShowControl1.ReleaseInterfaces()
                    bFirstVideoCapture1 = False
                End If
        End Select
    End Sub

    Private Sub cboMission_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMission.SelectedIndexChanged
        If Trim(cboMission.Text) <> "" Then
            ReadMission(cboMission.Text)
            If tabMapView.SelectedIndex = 0 Then
                WebBrowser1.Focus()
            End If
        End If
    End Sub
    Private Sub ReadMission(ByVal inputMission As String)
        Dim sMission As String
        Dim sSplit() As String
        Dim sSplit2() As String
        Dim nCount As Integer
        Dim nWPNumber As Integer
        Dim bFirstWaypoint As Boolean = False
        sMission = GetFileContents(GetRootPath() & "Missions\" & inputMission)

        sSplit = Split(sMission, vbCrLf)
        If Mid(inputMission, InStr(inputMission, ".") + 1) = "txt" Then
            If Mid(sSplit(0), 1, 5) <> "OPTIO" And Mid(sSplit(0), 1, 5) <> "HOME:" Then
                Call MsgBox(GetResString(, "Invalid Mission File Format"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, GetResString(, "Invalid File"))
                Exit Sub
            End If

            nWPNumber = 0
            For nCount = 0 To UBound(sSplit)
                If Trim(sSplit(nCount)) <> "" Then
                    If Mid(sSplit(nCount), 1, 5) = "HOME:" Then
                        sSplit2 = Split(sSplit(nCount), ",")
                        Try
                            webDocument.InvokeScript("clearMap", New Object() {})
                            If eMapSelection = e_MapSelection.e_MapSelection_GoogleEarth Then
                                webDocument.InvokeScript("setHomeLatLng", New Object() {Mid(sSplit2(0), 6), sSplit2(1), ConvertDistance(sSplit2(2), e_DistanceFormat.e_DistanceFormat_Meters, e_DistanceFormat.e_DistanceFormat_Feet), sModelName, tbarModelScale.Value, GetPitch(nPitch), GetRoll(nRoll), nCameraTracking})
                            End If
                        Catch e2 As Exception
                        End Try
                        nHomeLat = Mid(sSplit2(0), 6)
                        nHomeLong = sSplit2(1)
                    ElseIf Mid(sSplit(nCount), 1, 5) = "OPTIO" Then
                    Else
                        nWPNumber = nWPNumber + 1
                        sSplit2 = Split(sSplit(nCount), ",")
                        Try
                            If eMapSelection = e_MapSelection.e_MapSelection_GoogleEarth Then
                                webDocument.InvokeScript("addWaypoint", New Object() {sSplit2(0), sSplit2(1), ConvertDistance(sSplit2(2), e_DistanceFormat.e_DistanceFormat_Meters, e_DistanceFormat.e_DistanceFormat_Feet), nWPNumber.ToString.PadLeft(2, "0"), bMissionExtrude, sMissionColor, nMissionWidth})
                            End If
                        Catch e2 As Exception
                        End Try
                    End If
                End If
            Next
        ElseIf Mid(inputMission, InStr(inputMission, ".") + 1) = "h" Then
            If Mid(sSplit(0), 1, 7) <> "#define" Then
                Call MsgBox("Invalid Mission File Format", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Invalid File")
                Exit Sub
            End If

            webDocument.InvokeScript("clearMap", New Object() {})
            nWPNumber = 0
            For nCount = 0 To UBound(sSplit)
                If Trim(sSplit(nCount)) <> "" Then
                    If Trim(Mid(sSplit(nCount), 1, 14)) = "{CMD_WAYPOINT," Then
                        sSplit2 = Split(sSplit(nCount), ",")
                        sSplit2(4) = Replace(sSplit2(4), "}", "")
                        Try
                            If nWPNumber = 0 Then
                                If eMapSelection = e_MapSelection.e_MapSelection_GoogleEarth Then
                                    webDocument.InvokeScript("setHomeLatLng", New Object() {sSplit2(3), sSplit2(4), ConvertDistance(sSplit2(2), e_DistanceFormat.e_DistanceFormat_Meters, e_DistanceFormat.e_DistanceFormat_Feet), sModelName, tbarModelScale.Value, GetPitch(nPitch), GetRoll(nRoll), nCameraTracking})
                                    nHomeLat = sSplit2(3)
                                    nHomeLong = sSplit2(4)
                                End If
                            Else
                                If eMapSelection = e_MapSelection.e_MapSelection_GoogleEarth Then
                                    webDocument.InvokeScript("addWaypoint", New Object() {sSplit2(3), sSplit2(4), ConvertDistance(sSplit2(2), e_DistanceFormat.e_DistanceFormat_Meters, e_DistanceFormat.e_DistanceFormat_Feet), nWPNumber.ToString.PadLeft(2, "0"), bMissionExtrude, sMissionColor, nMissionWidth})
                                End If
                            End If
                        Catch e2 As Exception
                        End Try
                        nWPNumber = nWPNumber + 1
                    End If
                End If
            Next
        End If

        If nWPNumber > 0 Then
            Try
                If eMapSelection = e_MapSelection.e_MapSelection_GoogleEarth Then
                    webDocument.InvokeScript("drawHomeLine")
                End If
            Catch e2 As Exception
            End Try
        End If


    End Sub

    Private Sub cmdReloadMissions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReloadMissions.Click
        LoadMissions()
    End Sub

    Private Sub cmdReloadMissionDirectory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReloadMissionDirectory.Click
        cboMission_SelectedIndexChanged(sender, e)
    End Sub

    'Private Sub cboMapSelection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call SaveRegSetting(sRootRegistry & "\Settings", "Map Selection", cboMapSelection.SelectedIndex)
    '    nHomeLat = ""
    '    nHomeLong = ""
    '    eMapSelection = cboMapSelection.SelectedIndex
    '    SetupWebBroswer()
    'End Sub


    Private Sub cmdCommandLineSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCommandLineSend.Click
        If serialPortIn.IsOpen = True Then
            serialPortIn.Encoding = System.Text.Encoding.GetEncoding(28591)
            serialPortIn.Write(cboCommandLineCommand.Text & vbCr)
            SaveComboEntries(cboCommandLineCommand)

            cboCommandLineCommand.Text = ""
            cboCommandLineCommand.Focus()
        End If
    End Sub
    Private Sub SaveComboEntries(ByVal inputCombo As ComboBox)
        Dim nCount As Integer
        Dim nFoundIndex As Integer
        Dim sText As String

        With inputCombo
            sText = .Text
            nFoundIndex = -1
            For nCount = 0 To .Items.Count - 1
                If UCase(Trim(sText)) = UCase(Trim(.Items(nCount).ToString)) Then
                    nFoundIndex = nCount
                End If
            Next
            If nFoundIndex > -1 Then
                .Items.RemoveAt(nFoundIndex)
            End If
            .Items.Insert(0, Trim(sText))

            For nCount = 0 To .Items.Count - 1
                Call SaveRegSetting(sRootRegistry & "\Settings\ComboSaves\" & .Name, "Index " & nCount, .Items(nCount).ToString)
            Next
            Call SaveRegSetting(sRootRegistry & "\Settings\ComboSaves\" & .Name, "Total Count", .Items.Count)
            .Text = sText
        End With
    End Sub
    Private Sub LoadComboEntries(ByVal inputCombo As ComboBox)
        Dim nCount As Integer
        Dim nMax As Integer
        Dim sText As String
        With inputCombo
            nMax = GetRegSetting(sRootRegistry & "\Settings\ComboSaves\" & .Name, "Total Count", 0)

            For nCount = 0 To nMax - 1
                sText = GetRegSetting(sRootRegistry & "\Settings\ComboSaves\" & .Name, "Index " & nCount, "")
                If Trim(sText) <> "" Then
                    .Items.Add(Trim(sText))
                End If
            Next
        End With
    End Sub
    Private Sub cboCommandLineCommand_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCommandLineCommand.GotFocus
        Me.AcceptButton = cmdCommandLineSend
    End Sub

    Private Sub cboCommandLineDelim_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCommandLineDelim.SelectedIndexChanged
        SaveRegSetting(sRootRegistry & "\Settings", "Command Line Delim", cboCommandLineDelim.SelectedIndex)
        nCommandLineDelim = cboCommandLineDelim.SelectedIndex
    End Sub

    Private Sub cmdReloadComPorts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReloadComPorts.Click
        LoadComPorts(cboComPort.Text)
    End Sub

    Private Sub cmdResetRuntime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdResetRuntime.Click
        If serialPortIn.IsOpen = True Then
            dStartTime = Now
        Else
            If UBound(rawData) > 0 Then
                dStartTime = GetNextFileTime()
            End If
        End If
        lblRunTime.Text = ConvertToRunTime(dStartTime, dStartTime)
    End Sub

    Private Sub chkCommandLineAutoScroll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCommandLineAutoScroll.CheckedChanged
        SaveRegSetting(sRootRegistry & "\Settings", "Command Line Auto Scroll", chkCommandLineAutoScroll.Checked)
    End Sub


    Private Sub tbarModelScale_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbarModelScale.Scroll
        WebBrowser1.Invoke(New MyDelegate(AddressOf changeModelScale))
        Call SaveRegSetting(sRootRegistry & "\Settings", "Model Scale", tbarModelScale.Value)
    End Sub

    Private Sub chkViewNoTracking_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkViewNoTracking.CheckedChanged
        If chkViewNoTracking.Checked = True Then
            SetViewButtons(0)
        End If
    End Sub

    Private Sub chkViewOverhead_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkViewOverhead.CheckedChanged
        If chkViewOverhead.Checked = True Then
            SetViewButtons(1)
        End If
    End Sub

    Private Sub chkViewChaseCam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkViewChaseCam.CheckedChanged
        If chkViewChaseCam.Checked = True Then
            SetViewButtons(2)
        End If
    End Sub
    Private Sub SetViewButtons(ByVal newValue As Integer)
        If Not webDocument Is Nothing Then
            webDocument.InvokeScript("changeView", New Object() {newValue, nAltitude, GetPitch(nPitch), GetRoll(nRoll), sModelName})
        End If
        nCameraTracking = newValue
        chkViewNoTracking.Checked = IIf(nCameraTracking = 0, True, False)
        chkViewOverhead.Checked = IIf(nCameraTracking = 1, True, False)
        chkViewChaseCam.Checked = IIf(nCameraTracking = 2, True, False)
        chkViewFirstPerson.Checked = IIf(nCameraTracking = 3, True, False)
    End Sub

    Private Sub chkViewFirstPerson_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkViewFirstPerson.CheckedChanged
        If chkViewFirstPerson.Checked = True Then
            SetViewButtons(3)
        End If
    End Sub

    Private Sub tabInstrumentView_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabInstrumentView.SelectedIndexChanged
        ResizeForm()
        Select Case tabInstrumentView.SelectedIndex
            Case 3
                If bFirstVideoCapture2 = False Then
                    LoadComboWithCameras(cboLiveCameraSelect2, sSelectedCamera2, True)
                    bFirstVideoCapture2 = True
                    'bFirstVideoCapture2 = DirectShowControl2.StartCapture(cboLiveCameraSelect2.SelectedIndex)
                End If
            Case Else
                If bFirstVideoCapture2 = True Then
                    DirectShowControl2.ReleaseInterfaces()
                    bFirstVideoCapture2 = False
                End If
        End Select
    End Sub
    Private Sub MoveControl(ByRef inputObject As Object, ByVal height As Long, ByVal width As Long, ByVal top As Long, ByVal left As Long)
        With inputObject
            .height = height
            .width = width
            .left = left
            .top = top
            .refresh()
        End With
    End Sub
    Private Sub MoveControl2(ByRef instrumentIndex As e_Instruments, ByVal height As Long, ByVal top As Long, ByVal left As Long)
        Dim inputObject As Object
        Select Case instrumentIndex
            Case e_Instruments.e_Instruments_Speed
                inputObject = AirSpeedIndicatorInstrumentControl1
            Case e_Instruments.e_Instruments_Altimeter
                inputObject = AltimeterInstrumentControl1
            Case e_Instruments.e_Instruments_Attitude
                inputObject = AttitudeIndicatorInstrumentControl1
            Case e_Instruments.e_Instruments_Heading
                inputObject = HeadingIndicatorInstrumentControl1
            Case e_Instruments.e_Instruments_3DModel
                inputObject = _3DMesh1
            Case e_Instruments.e_Instruments_Vertical
                inputObject = VerticalSpeedIndicatorInstrumentControl1
            Case e_Instruments.e_Instruments_Turn
                inputObject = TurnCoordinatorInstrumentControl1
            Case e_Instruments.e_Instruments_Battery
                inputObject = BatteryIndicatorInstrumentControl1
        End Select

        With inputObject
            If bInstruments(instrumentIndex) = True Then
                .height = height
                .width = height
                .left = left
                .top = top
                .visible = True
                .refresh()
            Else
                .visible = False
            End If
        End With
    End Sub
    Private Sub FitDirectShow(ByRef inputObject As Object, ByVal maxWidth As Long, ByVal maxHeight As Long)
        With inputObject
            If maxWidth / maxHeight >= 1.11111 Then
                .height = maxHeight
                .width = maxHeight * 1.11111
                .left = (maxWidth - .width) / 2 + 10
            Else
                .width = maxWidth
                .height = maxWidth / 1.11111
                .left = 10
            End If
        End With
    End Sub
    Public Sub ResizeForm()
        Dim nInstrumentSize As Integer
        Dim nInstrumentHeight As Integer
        Dim nInstrumentWidth As Integer
        Dim eLayout As e_InstrumentLayout
        Dim oTab As System.Windows.Forms.TabPage
        Dim nTotalInstruments As Integer
        Dim nTotalInstrumentsSize As Integer
        Dim nCount As Integer
        Dim nCount2 As Integer
        Dim nCount3 As Integer
        Dim nLastTop As Long
        Dim nLastLeft As Long
        Dim nColIndex As Integer = 0
        Dim nRowIndex As Integer = 0
        Dim nColCount As Integer = 1
        Dim nRowCount As Integer = 1
        Dim nSampleInstHeight As Integer
        Dim nInstrumentArea As Long
        Dim bAllowBig As Boolean = False
        Dim bFoundOne As Boolean = False
        Dim nMinRowCol As Integer
        Dim nTest As Single
        Dim nTestCols As Single
        Dim nTestRows As Single

        If bStartup = True Then
            Exit Sub
        End If

        _3DMesh1.Locked = True
        'Tops
        tabInstrumentView.Top = ToolStrip1.Height + 6
        'tabMapView.Top = ToolStrip1.Height + 6

        If SplitContainer1.Panel1.Width < 590 Then
            tabPortControl.Height = grpMisc.Height + 26
        Else
            tabPortControl.Height = 180
        End If
        'System.Diagnostics.Debug.Print("SplitContainer1.Panel1.Width=" & SplitContainer1.Panel1.Width)
        tabPortControl.Top = SplitContainer1.Panel1.Height - tabPortControl.Height - 8
        'grpMisc.Top = tabPortControl.Top

        If bExpandInstruments = True Then
            tabInstrumentView.Height = tabPortControl.Top + tabPortControl.Height - tabInstrumentView.Top - 5
            grpMisc.Visible = False
            tabPortControl.Visible = False
        Else
            tabInstrumentView.Height = tabPortControl.Top - tabInstrumentView.Top - 8
            grpMisc.Visible = True
            tabPortControl.Visible = True
        End If
        cmdExpandInstruments.Top = tabInstrumentView.Top + tabInstrumentView.Height - cmdExpandInstruments.Height + 7

        cmdCenterOnPlane.Top = Me.Height - cmdCenterOnPlane.Height - 42
        cmdClearMap.Top = cmdCenterOnPlane.Top
        cmdExit.Top = cmdCenterOnPlane.Top
        cmdSetHome.Top = cmdCenterOnPlane.Top

        tabMapView.Height = cmdExit.Top - tabMapView.Top - 6

        bUltraSmall = False

        If SplitContainer1.Panel1.Width < 590 Then
            bUltraSmall = True
            tabPortControl.Width = SplitContainer1.Panel1.Width - 8
            tabInstrumentView.Width = tabPortControl.Width
            grpMisc.Width = tabInstrumentView.Width - 12

            If tabPortControl.TabPages.Count < 6 Then
                tabPortControl.TabPages.Add("tabPortStatus", GetResString("Status"))
                oTab = tabPortControl.TabPages(tabPortControl.TabPages.Count - 1)
                oTab.BackColor = Color.FromName("Control")
            End If
            grpMisc.Top = tabPortControl.Top + 22
            grpMisc.Left = tabPortControl.Left + 5
            grpMisc.BackColor = GetSystemColor("F5F4F1")
        Else
            tabInstrumentView.Width = SplitContainer1.Panel1.Width - 8
            grpMisc.Width = 300
            tabPortControl.Width = SplitContainer1.Panel1.Width - grpMisc.Width - 18
            If tabPortControl.TabPages.Count >= 6 Then
                tabPortControl.TabPages.RemoveAt(5)
            End If
            grpMisc.Top = tabPortControl.Top + tabPortControl.Height - grpMisc.Height
            grpMisc.Left = tabPortControl.Left + tabPortControl.Width + 6
            grpMisc.BackColor = Color.Transparent
        End If
        'cmdExpandInstruments.Left = tabInstrumentView.Width / 2 - cmdExpandInstruments.Width / 2

        lstInbound.Width = tabInstrumentView.Width - lstInbound.Left * 3
        lstEvents.Width = lstInbound.Width
        grpSerialSettings.Width = lstInbound.Width

        cmdCommandLineSend.Left = lstInbound.Width - cmdCommandLineSend.Width + 6
        cboCommandLineCommand.Width = cmdCommandLineSend.Left - cboCommandLineCommand.Left - 6
        lstCommandLineOutput.Width = lstInbound.Width
        cboCommandLineDelim.Left = lstInbound.Width - cboCommandLineDelim.Width + 6

        ResizePortControlTab()

        Select Case tabInstrumentView.SelectedIndex
            Case 0
                If bInstruments(e_Instruments.e_Instruments_3DModel) = True Then
                    '_3DMesh1.Locked = False
                    '_3DMesh1.Refresh()
                    'frmMain_Paint(Nothing, Nothing)
                    _3DMesh1.DrawMesh(GetPitch(nPitch), GetRoll(nRoll), GetYaw(nYaw), False, sModelName, GetRootPath() & "3D Models\")
                End If

                nTotalInstruments = 0
                For nCount = 0 To UBound(bInstruments)
                    If bInstruments(nCount) = True Then
                        nTotalInstruments = nTotalInstruments + 1
                    End If
                Next

                If eSelectedInstrument <> e_Instruments.e_Instruments_None Then
                    If bInstruments(eSelectedInstrument) = True Then
                        nTotalInstrumentsSize = nTotalInstruments + 3
                        nMinRowCol = 2
                    Else
                        nTotalInstrumentsSize = nTotalInstruments
                        nMinRowCol = 1
                    End If
                Else
                    nTotalInstrumentsSize = nTotalInstruments
                    nMinRowCol = 1
                End If

                nTest = 999
                For nCount = nMinRowCol To Convert.ToInt32(Math.Ceiling(nTotalInstrumentsSize / nMinRowCol))
                    nTestCols = tabInstrumentView.Width / nCount
                    nTestRows = tabInstrumentView.Height / (Math.Ceiling(nTotalInstrumentsSize / nCount))
                    If Math.Abs(nTestCols - nTestRows) < nTest Then
                        nTest = Math.Abs(nTestCols - nTestRows)
                        nColCount = nCount
                        nRowCount = (Math.Ceiling(nTotalInstrumentsSize / nCount))
                    End If
                Next

                nInstrumentHeight = (tabInstrumentView.Height - 17 - (9 * (nRowCount + 1))) / nRowCount
                nInstrumentWidth = (tabInstrumentView.Width - (9 * (nColCount + 1))) / nColCount

                If nInstrumentWidth < nInstrumentHeight Then
                    nInstrumentSize = nInstrumentWidth
                Else
                    nInstrumentSize = nInstrumentHeight
                End If

                Dim aInstrumentLocation(0, 0) As Boolean
                If eSelectedInstrument <> e_Instruments.e_Instruments_None Then
                    If bInstruments(eSelectedInstrument) = True Then
                        If nColCount = 1 Then
                            nColCount = 2
                        End If
                        ReDim aInstrumentLocation(0 To nColCount - 1, 0 To nRowCount - 1)
                        If bInstruments(eSelectedInstrument) = True Then
                            MoveControl2(eSelectedInstrument, nInstrumentSize * 2 + 6, 6, 6)
                            aInstrumentLocation(0, 0) = True
                            aInstrumentLocation(0, 1) = True
                            aInstrumentLocation(1, 0) = True
                            aInstrumentLocation(1, 1) = True

                            If nColCount = 2 Then
                                nColIndex = 0
                                nRowIndex = 2
                            Else
                                nColIndex = 2
                                nRowIndex = 0
                            End If
                        Else
                            MoveControl2(eSelectedInstrument, nInstrumentSize * 2 + 6, 6, 6)
                        End If
                    Else
                        MoveControl2(eSelectedInstrument, nInstrumentSize * 2 + 6, 6, 6)
                        ReDim aInstrumentLocation(0 To nColCount - 1, 0 To nRowCount - 1)
                    End If
                Else
                    ReDim aInstrumentLocation(0 To nColCount - 1, 0 To nRowCount - 1)
                End If

                Try
                    For nCount = 0 To UBound(bInstruments)
                        bFoundOne = False
                        If nCount <> eSelectedInstrument Then
                            nLastLeft = nColIndex * nInstrumentSize + ((nColIndex) * 6) + 6
                            nLastTop = nRowIndex * nInstrumentSize + ((nRowIndex) * 6) + 6
                            MoveControl2(nCount, nInstrumentSize, nLastTop, nLastLeft)
                            If bInstruments(nCount) = True Then
                                aInstrumentLocation(nColIndex, nRowIndex) = True
                                For nCount2 = 0 To nRowCount - 1
                                    For nCount3 = 0 To nColCount - 1
                                        If aInstrumentLocation(nCount3, nCount2) = False Then
                                            nColIndex = nCount3
                                            nRowIndex = nCount2
                                            bFoundOne = True
                                            Exit For
                                        End If
                                    Next
                                    If bFoundOne = True Then
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                        If nCount = e_Instruments.e_Instruments_3DModel Then
                            cmdSetNorth.Visible = bInstruments(e_Instruments.e_Instruments_3DModel)
                            cmdSetNorth.Left = _3DMesh1.Left + _3DMesh1.Width - cmdSetNorth.Width - 2
                            cmdSetNorth.Top = _3DMesh1.Top + _3DMesh1.Height - cmdSetNorth.Height - 2
                        End If
                    Next
                Catch
                End Try

            Case 1
                    grpSerialSettings.Top = tabInstrumentView.Height - grpSerialSettings.Height - 35
                    lstEvents.Height = (grpSerialSettings.Top - 46) / 2
                    lstInbound.Height = lstEvents.Height

                    lblRawData.Top = 8
                    lstInbound.Top = lblRawData.Top + lblRawData.Height + 4

                    lblTranslatedData.Top = lstInbound.Top + lstInbound.Height + 4
                    lstEvents.Top = lblTranslatedData.Top + lblTranslatedData.Height + 4
            Case 2
                    chkCommandLineAutoScroll.Top = tabInstrumentView.Height - chkCommandLineAutoScroll.Height - 35
                    cboCommandLineDelim.Top = chkCommandLineAutoScroll.Top

                    lstCommandLineOutput.Height = chkCommandLineAutoScroll.Top - lstCommandLineOutput.Top - 6
            Case 3
                    FitDirectShow(DirectShowControl2, tabInstrumentView.Width - 30, tabInstrumentView.Height - DirectShowControl2.Top - 48)
                    cmdLiveCameraProperties2.Left = DirectShowControl2.Left + DirectShowControl2.Width - cmdLiveCameraProperties2.Width
                    cboLiveCameraSelect2.Left = DirectShowControl2.Left
                    cboLiveCameraSelect2.Width = cmdLiveCameraProperties2.Left - cboLiveCameraSelect2.Left - 6
        End Select

        'Lefts
        tabMapView.Left = 3
        tabMapView.Width = SplitContainer1.Panel2.Width - 9
        WebBrowser1.Width = tabMapView.Width - 22
        cmdCenterOnPlane.Left = tabMapView.Left
        cmdClearMap.Left = cmdCenterOnPlane.Left + cmdCenterOnPlane.Width + 2
        cmdSetHome.Left = cmdClearMap.Left + cmdClearMap.Width + 2
        cmdExit.Left = tabMapView.Left + tabMapView.Width - cmdExit.Width

        Select Case tabMapView.SelectedIndex
            Case 0
                chkViewNoTracking.Top = tabMapView.Height - chkViewNoTracking.Height - 32
                chkViewOverhead.Top = chkViewNoTracking.Top
                chkViewChaseCam.Top = chkViewNoTracking.Top
                chkViewFirstPerson.Top = chkViewNoTracking.Top
                tbarModelScale.Top = chkViewNoTracking.Top
                WebBrowser1.Height = chkViewNoTracking.Top - 15
            Case 1
                FitDirectShow(DirectShowControl1, tabMapView.Width - 30, tabMapView.Height - 70)
                cmdLiveCameraProperties1.Left = DirectShowControl1.Left + DirectShowControl1.Width - cmdLiveCameraProperties1.Width
                cboLiveCameraSelect1.Left = DirectShowControl1.Left
                cboLiveCameraSelect1.Width = cmdLiveCameraProperties1.Left - cboLiveCameraSelect1.Left - 6
        End Select

        If bInstruments(e_Instruments.e_Instruments_3DModel) = True Then
            '_3DMesh1.Locked = False
            _3DMesh1.DrawMesh(GetPitch(nPitch), GetRoll(nRoll), GetYaw(nYaw), False, sModelName, GetRootPath() & "3D Models\")
        End If

        If Me.WindowState = FormWindowState.Normal Then
            Call SaveRegSetting(sRootRegistry & "\Settings", "Form Top", Me.Top)
            Call SaveRegSetting(sRootRegistry & "\Settings", "Form Left", Me.Left)
            Call SaveRegSetting(sRootRegistry & "\Settings", "Form Height", Me.Height)
            Call SaveRegSetting(sRootRegistry & "\Settings", "Form Width", Me.Width)
            Call SaveRegSetting(sRootRegistry & "\Settings", "Form WindowState", Me.WindowState)
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Call SaveRegSetting(sRootRegistry & "\Settings", "Form WindowState", Me.WindowState)
        End If
    End Sub
    Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ResizeForm()
    End Sub
    Private Sub ResizePortControlTab()
        Select Case tabPortControl.SelectedIndex
            Case 3
                lblServo1.Left = tabPortControl.Width - lblServo1.Width - 6
                lblServo2.Left = lblServo1.Left
                lblServo3.Left = lblServo1.Left
                lblServo4.Left = lblServo1.Left
                lblServo5.Left = lblServo1.Left
                lblServo6.Left = lblServo1.Left
                lblServo7.Left = lblServo1.Left
                lblServo8.Left = lblServo1.Left

                tbarServo1.Width = lblServo1.Left - tbarServo1.Left
                tbarServo2.Width = tbarServo1.Width
                tbarServo3.Width = tbarServo1.Width
                tbarServo4.Width = tbarServo1.Width
                tbarServo5.Width = tbarServo1.Width
                tbarServo6.Width = tbarServo1.Width
                tbarServo7.Width = tbarServo1.Width
                tbarServo8.Width = tbarServo1.Width
            Case 4
                lblSensor1.Left = tabPortControl.Width - lblSensor1.Width - 6
                lblSensor2.Left = lblSensor1.Left
                lblSensor3.Left = lblSensor1.Left
                lblSensor4.Left = lblSensor1.Left
                lblSensor5.Left = lblSensor1.Left
                lblSensor6.Left = lblSensor1.Left
                lblSensor7.Left = lblSensor1.Left
                lblSensor8.Left = lblSensor1.Left

                tbarSensor1.Width = lblSensor1.Left - tbarSensor1.Left
                tbarSensor2.Width = tbarSensor1.Width
                tbarSensor3.Width = tbarSensor1.Width
                tbarSensor4.Width = tbarSensor1.Width
                tbarSensor5.Width = tbarSensor1.Width
                tbarSensor6.Width = tbarSensor1.Width
                tbarSensor7.Width = tbarSensor1.Width
                tbarSensor8.Width = tbarSensor1.Width
        End Select
        If bUltraSmall = True And bExpandInstruments = False Then
            Select Case tabPortControl.SelectedIndex
                Case 5
                    grpMisc.Visible = True
                Case Else
                    grpMisc.Visible = False
            End Select
        ElseIf bExpandInstruments = False Then
            grpMisc.Visible = True
        Else
            grpMisc.Visible = False
        End If
    End Sub
    Private Sub tabPortControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabPortControl.SelectedIndexChanged
        ResizePortControlTab()
    End Sub

    Private Sub cmdExpandInstruments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExpandInstruments.Click
        bExpandInstruments = Not bExpandInstruments
        If bExpandInstruments = True Then
            cmdExpandInstruments.Text = "<<"
            ToolTip1.SetToolTip(cmdExpandInstruments, GetResString(, "Shrink"))
        Else
            cmdExpandInstruments.Text = ">>"
            ToolTip1.SetToolTip(cmdExpandInstruments, GetResString(, "Expand"))
        End If
        ResizeForm()
    End Sub


    Private Sub cmdSetHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetHome.Click
        Try
            webDocument.InvokeScript("setHomeLatLng", New Object() {nLatitude, nLongitude, nAltitude, sModelName, tbarModelScale.Value, GetPitch(nPitch), GetRoll(nRoll), nCameraTracking})
            nDataPoints = 1
        Catch
        End Try
    End Sub

    Private Sub SplitContainer1_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        ToolStrip1.Width = SplitContainer1.Panel1.Width
        If bStartup = True Then
            Exit Sub
        End If
        SaveRegSetting(sRootRegistry & "\Settings", "Splitter Location", SplitContainer1.Panel1.Width)
        ResizeForm()
    End Sub

    Private Sub cboLiveCameraSelect1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLiveCameraSelect1.SelectedIndexChanged
        sSelectedCamera1 = cboLiveCameraSelect1.Text
        SaveRegSetting(sRootRegistry & "\Settings", "Selected Camera 1", sSelectedCamera1)

        DirectShowControl1.ReleaseInterfaces()
        DirectShowControl1.StartCapture(cboLiveCameraSelect1.SelectedIndex)
    End Sub

    Private Sub cboLiveCameraSelect2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLiveCameraSelect2.SelectedIndexChanged
        sSelectedCamera2 = cboLiveCameraSelect2.Text
        SaveRegSetting(sRootRegistry & "\Settings", "Selected Camera 2", sSelectedCamera2)

        DirectShowControl2.ReleaseInterfaces()
        DirectShowControl2.StartCapture(cboLiveCameraSelect2.SelectedIndex)

        ''Release COM objects
        'If Not theDevice Is Nothing Then
        '    Marshal.ReleaseComObject(theDevice)
        '    theDevice = Nothing
        'End If
        ''Create the filter for the selected video input device
        'Dim devicepath As String = cboLiveCameraSelect2.SelectedItem.ToString()
        'theDevice = CreateFilter(FilterCategory.VideoInputDevice, devicepath)


        'Dim capdevices() As DirectShowLib.DsDevice
        'Dim VMR9filterconfig As DirectShowLib.IVMRFilterConfig9
        'Dim media As AMMediaType = New AMMediaType()



        '' Get the collection of video devices
        'capdevices = DirectShowLib.DsDevice.GetDevicesOfCat(DirectShowLib.FilterCategory.VideoInputDevice)



        '' Get the graphbuilder object
        'm_filtergraph = DirectCast(New FilterGraph(), IFilterGraph2)


        'mediaCtrl = DirectCast(m_filtergraph, IMediaControl)



        '' Get the ICaptureGraphBuilder2
        'capGraph = DirectCast(New CaptureGraphBuilder2(), ICaptureGraphBuilder2)



        '' Get the SampleGrabber interface
        'SampGrabber = DirectCast(New SampleGrabber(), ISampleGrabber)



        '' Start building the graph
        'hr = capGraph.SetFiltergraph(DirectCast(m_filtergraph, IGraphBuilder))
        'DsError.ThrowExceptionForHR(hr)



        '' Add the video device
        'hr = m_filtergraph.AddSourceFilterForMoniker(capdevices(0).Mon, Nothing, capdevices(0).Name, CapFilter)
        'DsError.ThrowExceptionForHR(hr)



        'baseGrabFlt = DirectCast(SampGrabber, IBaseFilter)

        'media.majorType = MediaType.Video
        'media.subType = MediaSubType.RGB24
        'media.formatType = FormatType.VideoInfo

        'hr = SampGrabber.SetMediaType(media)
        'DsError.ThrowExceptionForHR(hr)
        'hr = SampGrabber.SetOneShot(False)
        'hr = SampGrabber.SetBufferSamples(True)



        '' Add the frame grabber to the graph
        'hr = m_filtergraph.AddFilter(baseGrabFlt, "Ds.NET Grabber")
        'DsError.ThrowExceptionForHR(hr)



        '' Get the VRM9 video renderer sans window
        'VMR9filterconfig = DirectCast(vmr9, IVMRFilterConfig9)
        'hr = VMR9filterconfig.SetRenderingMode(VMR9Mode.Windowless)


        '' Ajout du renderer dans le graph
        'hr = m_filtergraph.AddFilter(vmr9, "Video Mixing Renderer 9")



        ''Get the VRM9 video renderer sans window
        'windowlessCtrl = DirectCast(vmr9, IVMRWindowlessControl9)
        'hr = windowlessCtrl.SetVideoClippingWindow(Me.Handle)


        '' Set position
        'hr = windowlessCtrl.SetVideoPosition(Nothing, New Rectangle(0, 0, Me.Width, Me.Height))
        '' Set Aspect-Ratio
        'hr = windowlessCtrl.SetAspectRatioMode(VMR9AspectRatioMode.LetterBox)



        'hr = capGraph.RenderStream(PinCategory.Preview, MediaType.Video, CapFilter, baseGrabFlt, vmr9)

        'hr = mediaCtrl.Run()


    End Sub

    Private Function CreateFilter(ByVal category As Guid, ByVal friendlyname As String) As IBaseFilter
        Dim source As Object = Nothing
        Dim iid As Guid = GetType(IBaseFilter).GUID
        For Each device As DsDevice In DsDevice.GetDevicesOfCat(category)
            If device.Name.CompareTo(friendlyname) = 0 Then
                device.Mon.BindToObject(Nothing, Nothing, iid, source)
                Exit For
            End If
        Next

        Return DirectCast(source, IBaseFilter)
    End Function



    '----------------------------------------------------------------
    ' Converted from C# to VB .NET using CSharpToVBConverter(1.2).
    ' Developed by: Kamal Patel (http://www.KamalPatel.net) 
    '----------------------------------------------------------------

    Private Sub DisplayPropertyPage(ByVal dev As IBaseFilter)
        'Get the ISpecifyPropertyPages for the filter
        Dim hr As Integer = 0
        Dim filter As Object = Nothing
        Dim cat As Guid
        Dim med As Guid
        Dim iid As Guid
        Dim pProp As ISpecifyPropertyPages
        Dim i As Short
        Dim iPointer As Long
        Dim oPointer As System.IntPtr

        'cat = PinCategory.Capture
        'med = MediaType.Interleaved
        'iid = GetType(IAMStreamConfig).GUID
        'hr = GraphBuilder2.FindInterface( _
        '    DsGuid.FromGuid(cat), DsGuid.FromGuid(med), CapFilter, DsGuid.FromGuid(iid), filter)
        'If Not (hr = 0) Then
        '    med = MediaType.Video
        '    hr = GraphBuilder2.FindInterface( _
        '        DsGuid.FromGuid(cat), DsGuid.FromGuid(med), CapFilter, DsGuid.FromGuid(iid), filter)
        '    If Not (hr = 0) Then
        '        filter = Nothing
        '    End If
        'End If

        'filter = CapFilter


        pProp = DirectCast(dev, ISpecifyPropertyPages)

        If pProp Is Nothing Then
            'If the filter doesn't implement ISpecifyPropertyPages, try displaying IAMVfwCompressDialogs instead!
            Dim compressDialog As IAMVfwCompressDialogs
            If compressDialog IsNot Nothing Then

                hr = compressDialog.ShowDialog(VfwCompressDialogs.Config, IntPtr.Zero)
                DsError.ThrowExceptionForHR(hr)
            End If
            Return
        End If

        'Get the name of the filter from the FilterInfo struct
        Dim filterInfo As FilterInfo
        hr = dev.QueryFilterInfo(filterInfo)
        DsError.ThrowExceptionForHR(hr)

        ' Get the propertypages from the property bag
        'Dim caGUID As DsCAUUID = New DsCAUUID()

        hr = pProp.GetPages(caGUID)
        DsError.ThrowExceptionForHR(hr)
        iPointer = caGUID.cElems
        oPointer = caGUID.pElems

        ' Create and display the OlePropertyFrame
        Dim oDevice As Object = filter
        hr = OleCreatePropertyFrame(Me.Handle, 30, 30, Nothing, 1, oDevice, iPointer, oPointer, 0, 0, IntPtr.Zero)
        DsError.ThrowExceptionForHR(hr)

        ' Release COM objects
        Marshal.FreeCoTaskMem(caGUID.pElems)
        Marshal.ReleaseComObject(pProp)
        If filterInfo.pGraph IsNot Nothing Then
            Marshal.ReleaseComObject(filterInfo.pGraph)
        End If
    End Sub

    Private Sub cmdLiveCameraProperties1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLiveCameraProperties1.Click
        DisplayPropertyPage(theDevice1)
    End Sub

    Private Sub cmdLiveCameraProperties2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLiveCameraProperties2.Click
        DisplayPropertyPage(theDevice2)
        'Dim filter As Object = Nothing
        'Dim cat As Guid
        'Dim med As Guid
        'Dim iid As Guid
        'Dim caGUID As DsCAUUID = New DsCAUUID()
        'Dim pProp As ISpecifyPropertyPages
        'Dim i As Short

        ''Get the ISpecifyPropertyPages for the filter
        'i = 0
        'Select Case i
        '    Case 0 ' 0. the video renderer
        '        filter = vmr9
        '    Case 1 ' 1. the video capture filter
        '        filter = CapFilter
        '    Case 2 ' 2. the video capture pin
        '        cat = PinCategory.Capture
        '        med = MediaType.Interleaved
        '        iid = GetType(IAMStreamConfig).GUID
        '        hr = GraphBuilder2.FindInterface( _
        '            DsGuid.FromGuid(cat), DsGuid.FromGuid(med), CapFilter, DsGuid.FromGuid(iid), filter)
        '        If Not (hr = 0) Then
        '            med = MediaType.Video
        '            hr = GraphBuilder2.FindInterface( _
        '                DsGuid.FromGuid(cat), DsGuid.FromGuid(med), CapFilter, DsGuid.FromGuid(iid), filter)
        '            If Not (hr = 0) Then
        '                filter = Nothing
        '            End If
        '        End If
        'End Select


        'pProp = DirectCast(filter, ISpecifyPropertyPages)

        'caGUID.cElems = 9
        'caGUID.pElems = New System.IntPtr

        '' Determine if the object supports the interface
        '' and has at least 1 property page
        'If Not (pProp Is Nothing) Then
        '    hr = pProp.GetPages(caGUID)
        '    If (Not (hr = 0) Or (caGUID.cElems <= 0)) Then
        '        pProp = Nothing
        '    End If


        '    Dim o As Object = filter
        '    hr = OleCreatePropertyFrame(Me.Handle, 30, 30, Nothing, 1, o, caGUID.cElems, caGUID.pElems, 0, 0, IntPtr.Zero)
        'End If

        'If Not (caGUID.pElems = IntPtr.Zero) Then
        '    Marshal.FreeCoTaskMem(caGUID.pElems)
        'End If
    End Sub

    Private Sub chkRecord_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRecord.CheckedChanged
        Dim ret As Long
        If bButtonStateLocked = True Then
            Exit Sub
        End If
        If chkRecord.Checked = True Then
            If Dir(txtOutputFolder.Text & cboOutputFiles.Text, FileAttribute.Normal) <> "" Then
                ret = MsgBox(GetResString(, "Already_Exists", , , , cboOutputFiles.Text), MsgBoxStyle.YesNo + MsgBoxStyle.Question, GetResString(, "Overwrite File"))
                If ret = MsgBoxResult.No Then
                    chkRecord.Checked = False
                    bIsRecording = False
                    SetPlayerState(e_PlayerState.e_PlayerState_Pause)
                Else
                    bIsRecording = True
                    If Not sOutputFile Is Nothing Then
                        sOutputFile.Close()
                        sOutputFile = Nothing
                    End If
                    sOutputFile = New StreamWriter(txtOutputFolder.Text & cboOutputFiles.Text)
                    SetPlayerState(e_PlayerState.e_PlayerState_Record)
                End If
            Else
                sOutputFile = New StreamWriter(txtOutputFolder.Text & cboOutputFiles.Text)
                bIsRecording = True
                SetPlayerState(e_PlayerState.e_PlayerState_Record)
            End If
        Else
            If Not sOutputFile Is Nothing Then
                sOutputFile.Close()
                sOutputFile = Nothing
            End If
            LoadOutputFiles(cboOutputFiles.Text)
            'cboOutputFiles_SelectedIndexChanged(sender, e)
            'SetPlayerState(e_PlayerState.e_PlayerState_Pause)
        End If
    End Sub

    Private Sub chkReverse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReverse.CheckedChanged
        If bButtonStateLocked = True Then
            Exit Sub
        End If
        tmrPlayback.Enabled = False
        nDataIndex = 0
        TrackBar1.Value = 0
        SetPlayerState(e_PlayerState.e_PlayerState_Pause)
    End Sub

    Private Sub txtOutputFolder_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOutputFolder.TextChanged
        If Microsoft.VisualBasic.Right(txtOutputFolder.Text, 1) <> "\" Then
            txtOutputFolder.Text = txtOutputFolder.Text & "\"
        End If
    End Sub

    Private Sub cmdReloadOutputFileList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReloadOutputFileList.Click
        LoadOutputFiles(cboOutputFiles.Text)
    End Sub

    Private Sub chkFullDataFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFullDataFile.CheckedChanged
        If bButtonStateLocked = True Then
            Exit Sub
        End If
        If chkFullDataFile.Checked = True Then
            cmdClearMap_Click(sender, e)
            nDataIndex = 0
            TrackBar1.Value = 0
            SetPlayerState(e_PlayerState.e_PlayerState_Play, , True)
            tmrPlayback.Enabled = True
        Else
            tmrPlayback.Enabled = False
            SetPlayerState(e_PlayerState.e_PlayerState_Pause)
        End If
    End Sub

    Private Sub cmdSetNorth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetNorth.Click
        nYawOffset = nYaw
    End Sub

    Private Sub tmrComPort_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrComPort.Tick
        ReadSerialData()
    End Sub

    Private Sub cboServo1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboServo1.SelectedIndexChanged, cboServo2.SelectedIndexChanged, cboServo3.SelectedIndexChanged, cboServo4.SelectedIndexChanged, cboServo5.SelectedIndexChanged, cboServo6.SelectedIndexChanged, cboServo7.SelectedIndexChanged, cboServo8.SelectedIndexChanged
        If bStartup = True Then
            Exit Sub
        End If

        UpdateServoSliders()

        SaveRegSetting(sRootRegistry & "\Settings", "Servo 1", cboServo1.Text)
        SaveRegSetting(sRootRegistry & "\Settings", "Servo 2", cboServo2.Text)
        SaveRegSetting(sRootRegistry & "\Settings", "Servo 3", cboServo3.Text)
        SaveRegSetting(sRootRegistry & "\Settings", "Servo 4", cboServo4.Text)
        SaveRegSetting(sRootRegistry & "\Settings", "Servo 5", cboServo5.Text)
        SaveRegSetting(sRootRegistry & "\Settings", "Servo 6", cboServo6.Text)
        SaveRegSetting(sRootRegistry & "\Settings", "Servo 7", cboServo7.Text)
        SaveRegSetting(sRootRegistry & "\Settings", "Servo 8", cboServo8.Text)
    End Sub

    Private Sub cboSensors1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSensors1.SelectedIndexChanged, cboSensors2.SelectedIndexChanged, cboSensors3.SelectedIndexChanged, cboSensors4.SelectedIndexChanged, cboSensors5.SelectedIndexChanged, cboSensors6.SelectedIndexChanged, cboSensors7.SelectedIndexChanged, cboSensors8.SelectedIndexChanged
        If bStartup = True Then
            Exit Sub
        End If

        UpdateServoSliders()

        SaveRegSetting(sRootRegistry & "\Settings", "Sensor 1", cboSensors1.Text)
        SaveRegSetting(sRootRegistry & "\Settings", "Sensor 2", cboSensors2.Text)
        SaveRegSetting(sRootRegistry & "\Settings", "Sensor 3", cboSensors3.Text)
        SaveRegSetting(sRootRegistry & "\Settings", "Sensor 4", cboSensors4.Text)
        SaveRegSetting(sRootRegistry & "\Settings", "Sensor 5", cboSensors5.Text)
        SaveRegSetting(sRootRegistry & "\Settings", "Sensor 6", cboSensors6.Text)
        SaveRegSetting(sRootRegistry & "\Settings", "Sensor 7", cboSensors7.Text)
        SaveRegSetting(sRootRegistry & "\Settings", "Sensor 8", cboSensors8.Text)
    End Sub

    Private Sub cmdTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTest.Click
        Dim sMission As String
        Dim sSplit() As String
        Dim nCount As Integer
        Dim oMessage As cMessage
        Dim sOutput As String = ""
        Dim sFileContents As String

        'Dim FS As New FileStream("C:\Documents and Settings\Paul\My Documents\Visual Studio 2005\Projects\HK_GCS\HK_GCS\Save this\Output\FY21AP hypert 2.txt", FileMode.Open)
        Dim FS As New FileStream("C:\atto.txt", FileMode.Open)
        Dim Buffer() As Byte
        'Get the bytes from file to a byte array        
        ReDim Buffer(FS.Length - 1)
        FS.Read(Buffer, 0, Buffer.Length)
        sFileContents = System.Text.Encoding.Default.GetString(Buffer)
        FS.Close()

        'sSplit = Split(sFileContents, Chr(&HA5) & Chr(&H5A))
        sSplit = Split(sFileContents, vbCrLf)

        'For nCount = 1 To Len(sFileContents)
        '    sOutput = sOutput & Hex(Asc(Mid(sFileContents, nCount, 1))).PadLeft(2, "0") & " "
        'Next
        'Debug.Print(sOutput)

        For nCount = 1 To UBound(sSplit)
            'oMessage = GetNextSentence(Chr(&HA5) & Chr(&H5A) & sSplit(nCount))
            oMessage = GetNextSentence(sSplit(nCount) & vbCrLf)
            UpdateVariables(oMessage)
            Application.DoEvents()
            System.Threading.Thread.Sleep(250)
        Next
    End Sub

    Private Sub TurnCoordinatorInstrumentControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TurnCoordinatorInstrumentControl1.Click
        SelectInstrument(e_Instruments.e_Instruments_Turn)
    End Sub

    Private Sub AltimeterInstrumentControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltimeterInstrumentControl1.Click
        SelectInstrument(e_Instruments.e_Instruments_Altimeter)
    End Sub

    Private Sub AirSpeedIndicatorInstrumentControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AirSpeedIndicatorInstrumentControl1.Click
        SelectInstrument(e_Instruments.e_Instruments_Speed)
    End Sub

    Private Sub VerticalSpeedIndicatorInstrumentControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalSpeedIndicatorInstrumentControl1.Click
        SelectInstrument(e_Instruments.e_Instruments_Vertical)
    End Sub

    Private Sub HeadingIndicatorInstrumentControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HeadingIndicatorInstrumentControl1.Click
        SelectInstrument(e_Instruments.e_Instruments_Heading)
    End Sub
    Private Sub AttitudeIndicatorInstrumentControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttitudeIndicatorInstrumentControl1.Click
        SelectInstrument(e_Instruments.e_Instruments_Attitude)
    End Sub

    Private Sub _3DMesh1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _3DMesh1.Click
        SelectInstrument(e_Instruments.e_Instruments_3DModel)
    End Sub
    Private Sub SelectInstrument(ByVal newSelected As e_Instruments)
        If eSelectedInstrument = newSelected Then
            eSelectedInstrument = e_Instruments.e_Instruments_None
        Else
            eSelectedInstrument = newSelected
        End If
        SaveRegSetting(sRootRegistry & "\Settings", "Selected Instrument", eSelectedInstrument)
        ResizeForm()
    End Sub

    Private Sub mnuOpenHomepage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpenHomepage.Click
        System.Diagnostics.Process.Start("http://code.google.com/p/happykillmore-gcs/")
    End Sub

    Private Sub mnuOpenDownloads_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpenDownloads.Click
        System.Diagnostics.Process.Start("http://code.google.com/p/happykillmore-gcs/downloads/list")
    End Sub
    Private Sub mnuSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSettings.Click
        frmSettings.ShowDialog()
    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Me.Dispose()
    End Sub
    Private Sub mnuAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub BatteryIndicatorInstrumentControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BatteryIndicatorInstrumentControl1.Click
        SelectInstrument(e_Instruments.e_Instruments_Battery)
    End Sub
End Class
