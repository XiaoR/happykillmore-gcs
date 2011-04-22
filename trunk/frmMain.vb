Imports System.IO
Imports DirectShowLib
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System
Imports System.Globalization
Imports System.Resources
Imports System.Xml
Imports System.Data
Imports GEPlugin
Imports System.Security.Permissions
Imports System.Net.Sockets

<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
<System.Runtime.InteropServices.ComVisibleAttribute(True)> _
<ProgId("HK_GCS")> _
<ClassInterface(ClassInterfaceType.AutoDual)> _
Public Class frmMain
    'Public Declare Function OleCreatePropertyFrame Lib "oleaut32.dll" (ByVal hwndOwner As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal lpszCaption As String, ByVal cObjects As Integer, ByRef ppUnk As Object, ByVal cPages As Integer, ByVal lpPageClsID As IntPtr, ByVal lcid As Integer, ByVal dwReserved As Integer, ByVal lpvReserved As IntPtr) As Integer
    'Declare Function OleCreatePropertyFrame Lib "oleaut32.dll" (ByVal hwndOwner As IntPtr, ByVal x As Long, ByVal y As Long, <MarshalAs(UnmanagedType.LPWStr)> ByVal lpszCaption As String, ByVal cObjects As Integer, <MarshalAs(UnmanagedType.Interface, ArraySubType:=UnmanagedType.IUnknown)> ByRef ppUnk As System.IntPtr, ByVal cPages As Long, ByVal pPageClsID As IntPtr, ByVal lcid As Integer, ByVal dwReserved As Integer, ByVal pvReserved As IntPtr) As Integer
    Declare Function OleCreatePropertyFrame Lib "oleaut32.dll" (ByVal hwndOwner As IntPtr, ByVal x As Long, ByVal y As Long, <MarshalAs(UnmanagedType.LPWStr)> ByVal lpszCaption As String, ByVal cObjects As Integer, ByRef ppUnk As Object, ByVal cPages As Long, ByVal pPageClsID As IntPtr, ByVal lcid As Integer, ByVal dwReserved As Integer, ByVal pvReserved As IntPtr) As Integer

    Const g_DefaultAttoTrigger As String = "00000010"

    Private mediaControl As IMediaControl = Nothing
    'Private graphBuilder As IGraphBuilder = Nothing
    Private theCompressor As IBaseFilter = Nothing
    Public caGUID As DsCAUUID = New DsCAUUID()

    Dim m_ge As IGEPlugin = Nothing

    Dim ds As DataSet = New DataSet
    Dim dt As DataTable = New DataTable
    Dim drow As DataRow

    Dim nMavlinkHandshake As e_MavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_None
    Dim nMavlinkCurrentWaypointSend As Integer
    Dim dLastMavlinkCommandTime As Long
    Dim nMavlinkRetryAttempts As Integer

    Dim nHomeLat As String = ""
    Dim nHomeLong As String
    Dim nLastGPS As Long
    Dim nLastMapUpdate As Long

    Dim sOutputFile As StreamWriter
    Dim rawData(0) As String
    Dim nDataIndex As Long

    Dim bLockMissionReload As Boolean = False
    Dim bLockMissionCenter As Boolean = False

    'Public Event AttitudeChange(ByVal pitch As Single, ByVal roll As Single, ByVal yaw As Single)
    'Public Event GpsData(ByVal latitude As String, ByVal longitude As String, ByVal altitude As Single, ByVal speed As Single, ByVal heading As Single, ByVal satellites As Integer, ByVal fix As Integer, ByVal hdop As Single, ByVal verticalChange As Single)
    'Public Event Waypoints(ByVal waypointNumber As Integer, ByVal distance As Single)
    'Public Event RawPacket(ByVal messageString As String)

    Dim baudRates() As Long = {4800, 9600, 19200, 38400, 57600, 115200, 230400, 460800, 921600}
    'Dim baudRates() As Long = {38400, 57600, 19200, 9600, 115200, 4800}
    Dim nBaudRateIndex As Integer = 3
    Dim sCommandLineBuffer As String

    Dim nMaxListboxRecords As Integer = 200

    Dim eSelectedInstrument As e_Instruments = e_Instruments.e_Instruments_None

    Public bStartup As Boolean = True
    Dim bButtonStateLocked As Boolean = False

    Dim bNewGPS As Boolean
    Dim bNewAttitude As Boolean
    Dim bNewWaypoint As Boolean
    Dim bNewServo As Boolean
    Dim bNewDateTime As Boolean
    Dim dStartTime As Date
    Dim dLastAtto As Long

    Dim dLastHeartbeat1 As Long
    Dim dLastHeartbeat2 As Long
    Dim dLastHeartbeat3 As Long
    Dim dLastHeartbeat4 As Long
    Dim dLastHeartbeat5 As Long
    Dim dLastHeartbeat6 As Long

    Dim dLastNewDevice As Long
    Dim eNewDeviceBootState As e_NewDevice_BootState

    Dim nAttitudeInterval As Integer
    Dim nWaypointInterval As Integer
    Dim nGPSInterval As Integer
    Dim nLastAttitude As Long
    Dim nLastWaypoint As Long
    Dim nLastSpeechInterval As Long
    Dim nLastServos As Long
    Dim nLastTimeDate As Long
    'Dim nLastGPS As Long
    Dim nLastAlt As Single
    Dim nDataPoints As Long
    Dim bIsRecording As Boolean = False

    Dim sSelectedCamera1 As String
    Dim sSelectedCamera2 As String

    'Dim eOutputDistance As e_DistanceFormat
    'Dim eOutputSpeed As e_SpeedFormat
    Dim eOutputLatLongFormat As e_LatLongFormat = e_LatLongFormat.e_LatLongFormat_DD_DDDDDD

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
    Dim nTimeZoneOffset As Double
    'Dim SocketServer As TCPSrv
    Dim SocketServer As AsynchronousSocketListener


    Public Sub ResetForm()

        LoadLanguageFile()

        Me.Text = "HappyKillmore's " & GetResString(, "Ground_Control_Station") & " - " & Version

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

        GetResString(cmdZeroYaw, "Zero Yaw")
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
        GetResString(tabPortTracking, "Tracking")
        GetResString(tabPortServos, "Servos")
        GetResString(tabPortSensors, "Sensors")

        'COM Port
        GetResString(lblComPort, "COM Port", True)
        If cboComPort.Text = "TCP" Or cboComPort.Text = "UDP" Then
            GetResString(lblBaudRate, "Socket_Num", True)
        Else
            GetResString(lblBaudRate, "Baud Rate", True)
        End If
        GetResString(lblGPSTypeLabel, "GPS Type", True)
        GetResString(lblGPSMessageLabel, "GPS Message", True)
        GetResString(lblStatusLabel, "Status", True)

        GetResString(cmdSearch, "Search Baud")
        GetResString(cmdSearchCOM, "Search COM")
        If serialPortIn.IsOpen = True Then
            GetResString(cmdConnect, "Disconnect")
        Else
            GetResString(cmdConnect, "Connect")
        End If

        'Tracking
        GetResString(lblComPortTracking, "COM Port", True)
        GetResString(lblBaudRateTracking, "Baud Rate", True)
        GetResString(lblOutputTypeTracking, "Protocol", True)
        GetResString(lblHertzTracking, "Hertz", True)
        GetResString(lblStatusLabel, "Status", True)

        If serialPortTracking.IsOpen = True Then
            GetResString(cmdConnectTracking, "Disconnect")
        Else
            GetResString(cmdConnectTracking, "Connect")
        End If

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

        If bStartup = False Then
            ResizeForm()
        End If
    End Sub
    Public Sub LoadGEFeatures()
        If Not webDocument Is Nothing And bGoogleLoaded = True Then
            webDocument.InvokeScript("setFeatures", New Object() {bGEBorders, bGEBuildings, bGERoads, bGETerrain, bGETrees})
        End If
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
            _3DMesh1.DrawMesh(GetPitch(nPitch * n3DPitchRollOffset), GetRoll(nRoll * n3DPitchRollOffset), GetYaw(nYaw + n3DHeadingOffset), False, sModelName, GetRootPath() & "3D Models\")
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

            SocketServer.CloseAll()

            tmrSearch.Enabled = False
            If serialPortIn.IsOpen = True Then
                serialPortIn.Close()
            End If
        Catch e2 As Exception
        End Try
    End Sub
    Public Sub SetupWebBroswer()
        Select Case eMapSelection
            Case e_MapSelection.e_MapSelection_GoogleEarth
                WebBrowser1.DocumentText = Replace(My.Resources.GoogleResources.pluginhost.ToString, "<GoogleEarthKey>", sGoogleEarthKey)
            Case e_MapSelection.e_MapSelection_GoogleMaps
                WebBrowser1.DocumentText = My.Resources.GoogleResources.Maps.ToString
            Case e_MapSelection.e_MapSelection_None
                webDocument = Nothing
                WebBrowser1.DocumentText = ""
                WebBrowser1.ObjectForScripting = Nothing
                WebBrowser1.Visible = False
        End Select

        If eMapSelection <> e_MapSelection.e_MapSelection_None Then
            webDocument = WebBrowser1.Document
            WebBrowser1.ObjectForScripting = Me
            WebBrowser1.Visible = True
            'While WebBrowser1.ReadyState <> 4
            'Application.DoEvents()
            'System.Threading.Thread.Sleep(20)
            'End While

            If eMapSelection = e_MapSelection.e_MapSelection_GoogleMaps Then
                'webDocument.GetElementById("lockDragDrop").SetAttribute("value", "Locked")
            End If
        End If

    End Sub
    Public Sub JSInitSuccessCallback_(ByVal pluginInstance As Object)
        m_ge = pluginInstance
        'WebBrowser1.Invoke(New MyDelegate(AddressOf buildPlaneModel))
        bGoogleLoaded = True
        bGoogleFailed = False
        cmdConnect.Enabled = True
        cboOutputFiles.Enabled = True
        chkViewChaseCam.Checked = True
        LoadGEFeatures()

    End Sub
    Public Sub JSInitErrorCallback_(ByVal errorObj As Object)
        Debug.Print(errorObj.ToString())
        If errorObj.ToString() = "ERR_API_KEY" Then
            webDocument = Nothing
            WebBrowser1.Dispose()
            WebBrowser1.ObjectForScripting = Nothing
            eMapSelection = e_MapSelection.e_MapSelection_None
        End If
    End Sub
    Public Sub JSGoogleLoadFail_()
        bGoogleLoaded = False
        bGoogleFailed = True
        cmdConnect.Enabled = True
        cboOutputFiles.Enabled = True
        SetMapMode()
    End Sub


    Public Sub JSClick_(ByVal index As String)
        Dim nIndex As Integer
        Dim sTemp As String
        Dim firstVisibleRow As Integer
        Dim lastVisibleRow As Integer

        bLockMissionCenter = True
        sTemp = index.Substring(0, InStrRev(index, ".") - 1)
        If sTemp.Substring(Len(sTemp) - 1) = "H" Then
            nIndex = 0
        Else
            nIndex = Convert.ToInt32(sTemp.Substring(Len(sTemp) - 2))
        End If
        dgMission.Rows(nIndex).Selected = True
        firstVisibleRow = dgMission.HitTest(dgMission.RowTemplate.Height, dgMission.Columns(0).Width).RowIndex
        lastVisibleRow = firstVisibleRow + dgMission.DisplayedRowCount(False)

        If nIndex < firstVisibleRow Or nIndex > lastVisibleRow Then
            dgMission.FirstDisplayedScrollingRowIndex = nIndex
        End If
        bLockMissionCenter = False
    End Sub
    Public Sub JSHomeAlt_(ByVal altitude As Single, ByVal offset As Integer)
        lblMissionHomeAlt.Text = "Home Alt:" & ConvertDistance(altitude.ToString("0.00"), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits) '& ",Offset:" & offset
    End Sub
    'Public Sub JSGoogleLicenseFail_()
    '    Debug.Print("Failed")

    '    'WebBrowser1.Stop()
    'End Sub

    Public Sub AddWaypoint(ByVal latitude As String, ByVal longitude As String, ByVal altitude As String, Optional ByVal speed As Single = -1, Optional ByVal trigger As String = g_DefaultAttoTrigger, Optional ByVal commandValue As Integer = -1, Optional ByVal otherValue As String = "")
        Dim nIndex As Integer
        Dim sTemp As String
        Dim nCount As Integer
        Dim bPrevValue As Boolean

        'If tabInstrumentView.SelectedIndex = 4 Then
        bPrevValue = bLockMissionCenter
        bLockMissionCenter = True
        nWPCount = nWPCount + 1

        RedimWaypointArray(nWPCount)

        If chkMissionInsert.Checked = True And dgMission.SelectedRows.Count > 0 Then
            nIndex = dgMission.SelectedRows(0).Index
            For nCount = nWPCount - 1 To nIndex Step -1
                SwapArrayGroup(nCount, nCount + 1)
            Next
        Else
            nIndex = nWPCount
        End If

        'If nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot Or nConfigDevice = e_ConfigDevice.e_ConfigDevice_Generic Then
        If latitude <> "" Then
            aWPLat(nIndex) = Convert.ToDouble(latitude).ToString(sConfigFormatString)
        End If
        If longitude <> "" Then
            aWPLon(nIndex) = Convert.ToDouble(longitude).ToString(sConfigFormatString)
        End If
        If altitude <> "" Then
            aWPAlt(nIndex) = altitude.ToString
        End If
        'ElseIf nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink Then
        'aWPLat(nIndex) = latitude
        'aWPLon(nIndex) = longitude
        'aWPAlt(nIndex) = altitude
        'End If

        aWPTrigger(nIndex) = trigger
        If speed = -1 Then
            aWPSpeed(nIndex) = txtMissionAttoDefaultSpeed.Text
        Else
            aWPSpeed(nIndex) = speed
        End If
        If commandValue <> -1 Then
            aWPCommand(nIndex) = commandValue
        Else
            aWPCommand(nIndex) = 16
        End If
        aWPOther(nIndex) = otherValue

        nNewWaypoint = nIndex
        LoadMissionGrid(nIndex)
        UpdateMissionGE(nIndex)
        bLockMissionCenter = bPrevValue
        'End If
    End Sub

    Public Sub JSDoubleClick_(ByVal latitude As String, ByVal longitude As String)
        AddWaypoint(latitude, longitude, Convert.ToSingle(txtMissionDefaultAlt.Text), txtMissionAttoDefaultSpeed.Text, g_DefaultAttoTrigger)
        chkViewNoTracking.Checked = True
        chkViewNoTracking_CheckedChanged(Nothing, Nothing)
        bLockMissionCenter = False
        If nWPCount >= nNewWaypoint Then
            'CenterAndTilt(nWaypoint, 0)
            '    'UpdateMissionGE(nWaypoint, , 0)
        End If
    End Sub

    Public Sub JSDragDrop_(ByVal iconString As String, ByVal latitude As String, ByVal longitude As String, ByVal altitude As Single)
        Dim nIndex As Integer
        Dim sTemp As String
        Dim bPrevValue As Boolean

        bPrevValue = bLockMissionCenter
        bLockMissionCenter = True
        sTemp = iconString.Substring(0, InStrRev(iconString, ".") - 1)
        If sTemp.Substring(Len(sTemp) - 1) = "H" Then
            nIndex = 0
        Else
            nIndex = Convert.ToInt32(sTemp.Substring(Len(sTemp) - 2))
        End If

        aWPLat(nIndex) = Convert.ToDouble(latitude).ToString(sConfigFormatString)
        aWPLon(nIndex) = Convert.ToDouble(longitude).ToString(sConfigFormatString)
        'aWPAlt(nIndex) = Convert.ToDouble(altitude).ToString("0.00")
        If dgMission.RowCount > nIndex Then
            If tabInstrumentView.SelectedIndex = 4 Then
                LoadMissionGrid(nIndex)
                UpdateMissionGE(nIndex, , 0)
            Else
                LoadMissionGrid()
                UpdateMissionGE()
            End If
        End If
        lblMissionHomeAlt.Text = "Home Alt:" & ConvertDistance(altitude.ToString("0.00"), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits) '& ",Offset:" & offset

        bLockMissionCenter = bPrevValue
    End Sub
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nCount As Integer
        Dim nTop As Long
        Dim nLeft As Long
        Dim nWidth As Long
        Dim nHeight As Long
        Dim nSplitter As Long
        Dim aLanguages() As String

        oActiveDevices = New cActiveDevices
        oActiveDevices.Initialize()

        sLanguageFile = GetRegSetting(sRootRegistry & "\Settings", "Language File", "Default")

        serialPortIn.Encoding = System.Text.Encoding.GetEncoding(28591)
        'serialPortIn.Encoding = System.Text.Encoding.Default
        'serialPortIn.Encoding = System.Text.Encoding.GetEncoding(1252)

        Try
            'Call SaveRegSetting("TypeLib\{EAB22AC0-30C1-11CF-A7EB-0000C05BAE0B}\1.1\0\win32", "", Environment.GetEnvironmentVariable("WINDIR") & "\system32\ieframe.dll", Microsoft.Win32.RegistryHive.ClassesRoot)
            'Call SaveRegSetting("TypeLib\{EAB22AC0-30C1-11CF-A7EB-0000C05BAE0B}\1.1\0\win32", "", "", Microsoft.Win32.RegistryHive.ClassesRoot)
            Call SaveRegSetting("Software\Microsoft\Windows\CurrentVersion\Internet Settings\Cache", "Persistent", 1, Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryValueKind.DWord)
        Catch
        End Try

        Me.Visible = False
        ResetForm()

        bStartup = True
        frmAbout.bIsSplash = True
        frmAbout.Show()

        nTimeZoneOffset = DateDiff(DateInterval.Hour, Now, Now.ToUniversalTime)

        If Screen.PrimaryScreen.Bounds.Height = 600 And Screen.PrimaryScreen.Bounds.Width = 1024 Then
            nWidth = GetRegSetting(sRootRegistry & "\Settings", "Form Width", 900)
            nHeight = GetRegSetting(sRootRegistry & "\Settings", "Form Height", 550)
            nTop = GetRegSetting(sRootRegistry & "\Settings", "Form Top", 0)
            nLeft = GetRegSetting(sRootRegistry & "\Settings", "Form Left", 0)
            nSplitter = GetRegSetting(sRootRegistry & "\Settings", "Splitter Location 0", 497)
        Else
            nWidth = GetRegSetting(sRootRegistry & "\Settings", "Form Width", 1100)
            nHeight = GetRegSetting(sRootRegistry & "\Settings", "Form Height", 675)
            nTop = GetRegSetting(sRootRegistry & "\Settings", "Form Top", Screen.PrimaryScreen.WorkingArea.Height / 2 - nHeight / 2)
            nLeft = GetRegSetting(sRootRegistry & "\Settings", "Form Left", Screen.PrimaryScreen.WorkingArea.Width / 2 - nWidth / 2)
            nSplitter = GetRegSetting(sRootRegistry & "\Settings", "Splitter Location 0", 590)
        End If

        bUTCTime = GetRegSetting(sRootRegistry & "\Settings", "UTC Time", False)

        If nWidth > Screen.PrimaryScreen.WorkingArea.Width Then
            nWidth = Screen.PrimaryScreen.WorkingArea.Width
        End If
        If nHeight > Screen.PrimaryScreen.WorkingArea.Height Then
            nHeight = Screen.PrimaryScreen.WorkingArea.Width
        End If

        SplitContainer1.Panel1MinSize = 320

        If Screen.PrimaryScreen.Bounds.Height = 600 And Screen.PrimaryScreen.Bounds.Width = 1024 Then
            eSelectedInstrument = GetRegSetting(sRootRegistry & "\Settings", "Selected Instrument", e_Instruments.e_Instruments_3DModel)
        Else
            eSelectedInstrument = GetRegSetting(sRootRegistry & "\Settings", "Selected Instrument", e_Instruments.e_Instruments_None)
        End If
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
            cboServo1.SelectedIndex = GetRegSetting(sRootRegistry & "\Settings\Servo", "1", 1)
            cboServo2.SelectedIndex = GetRegSetting(sRootRegistry & "\Settings\Servo", "2", 2)
            cboServo3.SelectedIndex = GetRegSetting(sRootRegistry & "\Settings\Servo", "3", 3)
            cboServo4.SelectedIndex = GetRegSetting(sRootRegistry & "\Settings\Servo", "4", 4)
            cboServo5.SelectedIndex = GetRegSetting(sRootRegistry & "\Settings\Servo", "5", 9)
            cboServo6.SelectedIndex = GetRegSetting(sRootRegistry & "\Settings\Servo", "6", 10)
            cboServo7.SelectedIndex = GetRegSetting(sRootRegistry & "\Settings\Servo", "7", 11)
            cboServo8.SelectedIndex = GetRegSetting(sRootRegistry & "\Settings\Servo", "8", 12)

            cboSensors1.SelectedIndex = GetRegSetting(sRootRegistry & "\Settings\Sensor", "1", 17)
            cboSensors2.SelectedIndex = GetRegSetting(sRootRegistry & "\Settings\Sensor", "2", 18)
            cboSensors3.SelectedIndex = GetRegSetting(sRootRegistry & "\Settings\Sensor", "3", 19)
            cboSensors4.SelectedIndex = GetRegSetting(sRootRegistry & "\Settings\Sensor", "4", 20)
            cboSensors5.SelectedIndex = GetRegSetting(sRootRegistry & "\Settings\Sensor", "5", 21)
            cboSensors6.SelectedIndex = GetRegSetting(sRootRegistry & "\Settings\Sensor", "6", 22)
            cboSensors7.SelectedIndex = GetRegSetting(sRootRegistry & "\Settings\Sensor", "7", 0)
            cboSensors8.SelectedIndex = GetRegSetting(sRootRegistry & "\Settings\Sensor", "8", 0)
        Catch
        End Try

        txtOutputFolder.Text = GetRegSetting(sRootRegistry & "\Settings", "OutputFolder", GetRootPath)
        LoadOutputFiles()

        Dim i As Integer

        Control.CheckForIllegalCrossThreadCalls = False

        frmAbout.UpdateStatus(GetResString(, "Setting_Up_Comboboxes"), 20)

        LoadSettings()
        If eMapSelection = e_MapSelection.e_MapSelection_None Then
            SetMapMode()
        Else
            frmAbout.UpdateStatus(GetResString(, "Setting_Up_Webbrowser"), 30)
            SetupWebBroswer()
        End If

        cboAttitude.Items.Add(GetResString(, "None"))
        cboGPS.Items.Add(GetResString(, "None"))
        cboWaypoint.Items.Add(GetResString(, "None"))
        cboHertzTracking.Items.Add(GetResString(, "None"))
        For i = 1 To 20
            cboAttitude.Items.Add(i & " Hz")
            If i <= 10 Then
                cboGPS.Items.Add(i & " Hz")
                cboWaypoint.Items.Add(i & " Hz")
            End If
            If i <= 5 Then
                cboHertzTracking.Items.Add(i & " Hz")
            End If
        Next

        cboAttitude.SelectedIndex = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Attitude Hz", "5"))
        cboGPS.SelectedIndex = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "GPS Hz", "2"))
        cboWaypoint.SelectedIndex = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Waypoint Hz", "2"))
        If Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings\Tracking", "Hz", "5")) > 5 Then
            cboHertzTracking.SelectedIndex = 5
        Else
            cboHertzTracking.SelectedIndex = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings\Tracking", "Hz", "5"))
        End If

        With cboCommandLineDelim
            .Items.Add(GetResString(, "No_line_ending"))
            .Items.Add(GetResString(, "Line Feed"))
            .Items.Add(GetResString(, "Carriage Return"))
            .Items.Add(GetResString(, "Line Feed Carriage Return"))
            .SelectedIndex = GetRegSetting(sRootRegistry & "\Settings", "Command Line Delim", "2")
            nCommandLineDelim = .SelectedIndex
        End With

        With cboConfigDevice
            .Items.Add(New cValueDesc(e_ConfigDevice.e_ConfigDevice_Generic, "Generic"))
            .Items.Add(New cValueDesc(e_ConfigDevice.e_ConfigDevice_AttoPilot, "AttoPilot"))
            .Items.Add(New cValueDesc(e_ConfigDevice.e_ConfigDevice_MAVlink, "ArduPilot Mega (MAVlink)"))
            .Items.Add(New cValueDesc(e_ConfigDevice.e_ConfigDevice_Gluonpilot, "Gluonpilot"))
            If bIsAdmin = True Then
                .Items.Add(New cValueDesc(e_ConfigDevice.e_ConfigDevice_FY21AP, "FY21AP II"))
            End If
            For i = 0 To .Items.Count - 1
                If CType(.Items(i), cValueDesc).Value = nConfigDevice Then
                    .SelectedIndex = i ' CType(.Items(i), cValueDesc).Description
                    Exit For
                End If
            Next
        End With

        With cboJoystickOutput
            .Items.Add("None")
            .Items.Add("AttoPilot")
            .Items.Add("UavDevBoard")
            .Items.Add("Millswood Eng.")
            .Items.Add("ArduPilot Mega")
            '.Items.Add("Pololu")

            .SelectedIndex = nJoystickOutput
        End With

        For i = 0 To 254
            cboConfigVehicle.Items.Add(i)
        Next
        cboConfigVehicle.SelectedIndex = nConfigVehicle

        With cboOutputTypeTracking
            .Items.Add(New cValueDesc(0, "ArduTracker"))
            .Items.Add(New cValueDesc(1, "Heading"))
            .Items.Add(New cValueDesc(2, "LatLong"))
            .Items.Add(New cValueDesc(3, "ArduStation"))
            .Items.Add(New cValueDesc(4, "Melih"))
            .Items.Add(New cValueDesc(5, "Pololu"))
            .Items.Add(New cValueDesc(6, "MiniSSC"))
            For i = 0 To .Items.Count - 1
                If CType(.Items(i), cValueDesc).Value = nTrackingOutputType Then
                    .SelectedIndex = i ' CType(.Items(i), cValueDesc).Description
                    Exit For
                End If
            Next
        End With

        With cboTrackingSet
            .Items.Clear()
            For nCount = 0 To 359
                .Items.Add(nCount)
            Next
            '.Items.Add("N")
            '.Items.Add("NE")
            '.Items.Add("E")
            '.Items.Add("SE")
            '.Items.Add("S")
            '.Items.Add("SW")
            '.Items.Add("W")
            '.Items.Add("NW")
            .SelectedIndex = 0
        End With

        frmAbout.UpdateStatus(GetResString(, "Loading Settings"), 40)

        LoadComboEntries(cboCommandLineCommand)
        LoadMissions()

        tbarModelScale.Value = GetRegSetting(sRootRegistry & "\Settings", "Model Scale", "10")

        chkCommandLineAutoScroll.Checked = GetRegSetting(sRootRegistry & "\Settings", "Command Line Auto Scroll", True)

        'UpdateLineColor()

        'bWaypointExtrude = GetRegSetting(sRootRegistry & "\Settings", "WP Extrude", True)
        'chkWaypointExtrude.Checked = bWaypointExtrude

        'SetupWebBroswer()

        frmAbout.UpdateStatus(GetResString(, "Loading_COM_Ports"), 50)

        LoadComPorts()
        SetPlayerState(e_PlayerState.e_PlayerState_None)

        For nCount = LBound(baudRates) To UBound(baudRates)
            cboBaudRate.Items.Add(baudRates(nCount))
            cboBaudRateTracking.Items.Add(baudRates(nCount))
            If GetRegSetting(sRootRegistry & "\Settings", "Baud Rate", "38400") = baudRates(nCount) Then
                cboBaudRate.SelectedIndex = nCount
            End If
            If GetRegSetting(sRootRegistry & "\Settings\Tracking", "Baud Rate", "38400") = baudRates(nCount) Then
                cboBaudRateTracking.SelectedIndex = nCount
            End If
        Next
        If cboBaudRate.SelectedIndex = -1 Then
            cboBaudRate.SelectedIndex = 3
        End If
        If cboBaudRateTracking.SelectedIndex = -1 Then
            cboBaudRateTracking.SelectedIndex = 3
        End If
        txtSocket.Text = GetRegSetting(sRootRegistry & "\Settings", "Socket Port", "localhost:30300")

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
        If Screen.PrimaryScreen.Bounds.Height = 600 And Screen.PrimaryScreen.Bounds.Width = 1024 Then
            Me.WindowState = GetRegSetting(sRootRegistry & "\Settings", "Form WindowState", FormWindowState.Maximized)
        Else
            Me.WindowState = GetRegSetting(sRootRegistry & "\Settings", "Form WindowState", FormWindowState.Normal)
        End If

        If Me.WindowState = FormWindowState.Normal Then
            Me.Width = nWidth
            Me.Height = nHeight
            Me.Left = nLeft
            Me.Top = nTop
        End If
        bStartup = False

        frmAbout.UpdateStatus(GetResString(, "Resizing_Form"), 80)

        ResizeForm()
        Application.DoEvents()

        cmdTest.Visible = False ' bIsAdmin

        frmAbout.UpdateStatus("", 100)
        frmAbout.Dispose()
        Me.Visible = True

        'If cboComPort.Items.Count > 0 Then
        '    cboComPort.SelectedIndex = 0
        'End If

        'DirectShowControl1.StartCapture()

    End Sub

    Private Sub LoadComPorts(Optional ByVal defaultComPort As String = "", Optional ByVal defaultTrackingPort As String = "", Optional ByVal loadType As Integer = 0)
        Dim i As Integer
        Dim sSavedComPort As String
        Dim sSavedTrackingPort As String

        If loadType = 0 Or loadType = 1 Then
            cboComPort.Items.Clear()
            cboComPort.Items.Add("TCP")
            cboComPort.Items.Add("UDP")
        End If
        If loadType = 0 Or loadType = 2 Then
            cboComPortTracking.Items.Clear()
        End If
        Try
            For i = 0 To My.Computer.Ports.SerialPortNames.Count - 1
                If Strings.Left(My.Computer.Ports.SerialPortNames(i), 3) = "COM" Then
                    If loadType = 0 Or loadType = 1 Then
                        cboComPort.Items.Add(My.Computer.Ports.SerialPortNames(i))
                    End If
                    If loadType = 0 Or loadType = 2 Then
                        cboComPortTracking.Items.Add(My.Computer.Ports.SerialPortNames(i))
                    End If
                End If
            Next
            sSavedComPort = GetRegSetting(sRootRegistry & "\Settings", "COM Port", "")
            sSavedTrackingPort = GetRegSetting(sRootRegistry & "\Settings\Tracking", "Port", "")
            For i = 0 To cboComPort.Items.Count - 3
                If defaultComPort = "" And (loadType = 0 Or loadType = 1) Then
                    If cboComPort.Items(i) = sSavedComPort Then
                        cboComPort.Text = sSavedComPort
                    End If
                ElseIf (loadType = 0 Or loadType = 1) Then
                    If My.Computer.Ports.SerialPortNames(i) = defaultComPort Then
                        cboComPort.Text = defaultComPort
                        Exit For
                    End If
                End If

                If i < cboComPortTracking.Items.Count Then
                    If defaultTrackingPort = "" And (loadType = 0 Or loadType = 2) Then
                        If cboComPortTracking.Items(i) = sSavedTrackingPort Then
                            cboComPortTracking.Text = sSavedTrackingPort
                        End If
                    ElseIf (loadType = 0 Or loadType = 2) Then
                        If My.Computer.Ports.SerialPortNames(i) = defaultComPort Then
                            cboComPortTracking.Text = defaultTrackingPort
                            Exit For
                        End If
                    End If
                End If
            Next
            If cboComPort.Items.Count > 0 And cboComPort.SelectedIndex = -1 And (loadType = 0 Or loadType = 1) Then
                cboComPort.SelectedIndex = 0
                'Else
                '    cmdSearch_Click(sender, e)
            End If
            If cboComPortTracking.Items.Count > 0 And cboComPortTracking.SelectedIndex = -1 And (loadType = 0 Or loadType = 2) Then
                cboComPortTracking.SelectedIndex = 0
                'Else
                '    cmdSearch_Click(sender, e)
            End If
        Catch e2 As Exception
        End Try
        nBaudRateIndex = 0

    End Sub
    Private Sub LoadMissions(Optional ByVal selectMission As String = "")
        Dim sMission As String
        Dim nCount As Integer

        With cboMission
            .Items.Clear()
            .Items.Add("{" & GetResString(, "None") & "}")
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
            If selectMission <> "" Then
                For nCount = 0 To .Items.Count - 1
                    If UCase(.Items(nCount)) = UCase(selectMission) Then
                        .SelectedIndex = nCount
                        Exit For
                    End If
                Next
            End If

            If .SelectedIndex < 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub LoadOutputFiles(Optional ByVal selectedFile As String = "")
        Dim nCount As Int16
        Dim sFilename As String
        With cboOutputFiles
            sFilename = Dir(txtOutputFolder.Text & "*.*", FileAttribute.Normal)
            .Items.Clear()
            Do While sFilename <> ""
                .Items.Add(sFilename)
                sFilename = Dir()
            Loop
            'sFilename = Dir(txtOutputFolder.Text & "*.txt", FileAttribute.Normal)
            'Do While sFilename <> ""
            '    .Items.Add(sFilename)
            '    sFilename = Dir()
            'Loop

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
                cmdReloadOutputFileList_Click(Nothing, Nothing)
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
            ElseIf eMapSelection = e_MapSelection.e_MapSelection_GoogleEarth Then
                If Not webDocument Is Nothing And bGoogleLoaded = True Then
                    webDocument.InvokeScript("centerOnPlane", New Object() {})
                End If
            End If
        Catch e2 As Exception
        End Try
    End Sub

    Private Sub cmdClearMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearMap.Click
        Try
            If eMapSelection = e_MapSelection.e_MapSelection_GoogleMaps Then
                webDocument.GetElementById("ClearButton").InvokeMember("click")
            ElseIf eMapSelection = e_MapSelection.e_MapSelection_GoogleEarth Then
                If Not webDocument Is Nothing And bGoogleLoaded = True Then
                    webDocument.InvokeScript("clearMap", New Object() {})
                End If
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

            If InStr(sFileContents, "F2:") <> 0 Then
                eMissionFileType = e_MissionFileType.e_MissionFileType_UDB
                rawData = Split(sFileContents, vbCrLf)
            ElseIf (Mid(sFileContents, 18, 1) = ":" Or Mid(sFileContents, 19, 1) = ":") Then
                eMissionFileType = e_MissionFileType.e_MissionFileType_GCS
                rawData = Split(sFileContents, vbCrLf)
                'ElseIf InStr(sFileContents, Chr(&HA5) & Chr(&H5A)) <> 0 Then
                '    eMissionFileType = e_MissionFileType.e_MissionFileType_FY21APII
                '    rawData = Split(sFileContents, Chr(&HAA))
            ElseIf InStr(sFileContents, "$A1,") <> 0 Then
                eMissionFileType = e_MissionFileType.e_MissionFileType_Atto
                rawData = Split(sFileContents, vbCrLf)
            End If

            If eMissionFileType <> e_MissionFileType.e_MissionFileType_None Then
                If eMissionFileType = e_MissionFileType.e_MissionFileType_GCS Then
                    dStartTime = New Date(Mid(rawData(0), 1, InStr(rawData(0), ":") - 1))
                ElseIf eMissionFileType = e_MissionFileType.e_MissionFileType_UDB Then
                    For nCount = 0 To UBound(rawData)
                        If InStr(rawData(nCount), "F2:") <> 0 Then
                            If InStr(rawData(nCount), "F2:T0:") = 0 Then
                                Try
                                    sTemp = Mid(rawData(nCount), InStr(rawData(nCount), "F2:") + 4)
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
        tmrPlayback.Enabled = False
        SetPlayerState(e_PlayerState.e_PlayerState_Pause)
        txtOutputFolder.Text = Replace(txtOutputFolder.Text, "\\", "\")
        LoadDataFile(txtOutputFolder.Text & cboOutputFiles.Text)
        SetPlayerState(e_PlayerState.e_PlayerState_Loaded)
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
        Dim nCount As Integer

        Try
            nSensor(9) = pitch
            nSensor(10) = roll
            nSensor(11) = yaw

            If bInstruments(e_Instruments.e_Instruments_Attitude) Then
                AttitudeIndicatorInstrumentControl1.SetAttitudeIndicatorParameters(GetPitch(-pitch), GetRoll(roll))
            End If
            If bInstruments(e_Instruments.e_Instruments_3DModel) Then
                _3DMesh1.DrawMesh(GetPitch(pitch * n3DPitchRollOffset), GetRoll(roll * n3DPitchRollOffset), GetYaw(yaw + n3DHeadingOffset))
            End If
            If bInstruments(e_Instruments.e_Instruments_Turn) Then
                TurnCoordinatorInstrumentControl1.SetTurnCoordinatorParameters(GetRoll(-nRoll), 0, UCase(GetResString(, "Turn_Coordinator")), GetResString(, "Left"), GetResString(, "Right"))
            End If

            'If chkJoystickEnable.Checked = True Then ' And nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot Then
            '    jst.InitializeForce(pitch, roll, 10000, 250000)
            'End If
        Catch
        End Try
    End Sub
    Private Sub GPS_Parser1_Waypoints(ByVal waypointNumber As Integer, ByVal distance As Single, ByVal battery As Single, ByVal mode As String, ByVal throttle As Single)
        Dim bWasPlayed As Boolean

        If bInstruments(e_Instruments.e_Instruments_Battery) Then
            BatteryIndicatorInstrumentControl1.SetBatteryIndicatorParameters(Replace(GetResString(, "Battery_Throttle"), "&&", "&"), nBattery, nBatteryMin, nBatteryMax, oBatteryColor, nAmperage, 0, nAmperageMax, oAmperageColor, nMAH, nMAHMin, nMAHMax, oMAHColor, throttle, oThrottleColor)
            'Debug.Print(Now)
        End If

        If waypointNumber = -1 Then
            lblWaypoint.Text = ""
        Else
            If nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot Then
                lblWaypoint.Text = "#" & waypointNumber
            Else
                lblWaypoint.Text = IIf(waypointNumber <> 0, "#" & waypointNumber, "Home")
            End If
        End If

        lblDistance.Text = IIf(distance <> 0, distance.ToString("###,##0.0") & GetShortDistanceUnits(), "")
        lblTargetAlt.Text = IIf(nWaypoint <> 0, nWaypointAlt.ToString("###,##0.0") & GetShortDistanceUnits(), "")
        lblBattery.Text = battery.ToString("0.00") & IIf(battery <> 0, "v", "")
        lblAmperage.Text = nAmperage.ToString("0.00") & IIf(nAmperage <> 0, "A", "")
        If sMode <> "" Then
            lblMode.Text = sMode
        ElseIf sModeNumber = "" Then
            lblMode.Text = ""
        Else
            lblMode.Text = mode
        End If
        If sLastSpeechMode <> lblMode.Text Then
            If sLastSpeechMode <> "" Then
                If bAnnounceModeChange = True Then
                    bWasPlayed = False
                    If bManuelMode = True Then
                        If InStr(UCase(lblMode.Text), "MANUAL") <> 0 Then
                            bWasPlayed = PlaySoundFile("Manual")
                            If bWasPlayed = True Then
                                dManuelMode = Now.Ticks
                                imgManuel.Left = tabMapView.Left + 12
                                imgManuel.Top = tabMapView.Top + 34
                                If tabMapView.SelectedIndex = 0 Then
                                    imgManuel.Visible = True
                                End If
                            End If
                        ElseIf InStr(UCase(lblMode.Text), "LOITER") <> 0 Then
                            bWasPlayed = PlaySoundFile("Loiter")
                        ElseIf InStr(UCase(lblMode.Text), "STABILIZE") <> 0 Then
                            bWasPlayed = PlaySoundFile("Stabilize")
                        ElseIf InStr(UCase(lblMode.Text), "WIRE") <> 0 And InStr(UCase(lblMode.Text), " A") <> 0 Then
                            bWasPlayed = PlaySoundFile("Flybywirea")
                        ElseIf InStr(UCase(lblMode.Text), "WIRE") <> 0 And InStr(UCase(lblMode.Text), " B") <> 0 Then
                            bWasPlayed = PlaySoundFile("Flybywireb")
                        ElseIf InStr(UCase(lblMode.Text), "RETURN") <> 0 Then
                            bWasPlayed = PlaySoundFile("Return")
                        ElseIf InStr(UCase(lblMode.Text), "HIGHLY") <> 0 Then
                            bWasPlayed = PlaySoundFile("Highly")
                        ElseIf InStr(UCase(lblMode.Text), "ASSISTED") <> 0 Then
                            bWasPlayed = PlaySoundFile("Assisted")
                        ElseIf InStr(UCase(lblMode.Text), "AUTO") <> 0 Then
                            bWasPlayed = PlaySoundFile("Auto")
                        End If
                    End If
                    If bWasPlayed = False Then
                        imgManuel.Visible = False
                        PlayMessage(sSpeechModeChange, sSpeechVoice)
                    End If
                End If
            End If
            sLastSpeechMode = lblMode.Text
        End If
        'Debug.Print("nLastSpeechWaypoint=" & nLastSpeechWaypoint)
        If nLastSpeechWaypoint <> nWaypoint And nLastSpeechWaypoint <> -1 Then
            nLastSpeechWaypoint = nWaypoint
            If nLastSpeechWaypoint <> -1 Then
                If bAnnounceWaypoints = True Then
                    nLastSpeechInterval = Now.Ticks
                    PlayMessage(sSpeechWaypoint, sSpeechVoice)
                End If
            End If
        ElseIf nLastSpeechWaypoint = -1 Then
            nLastSpeechWaypoint = nWaypoint
        End If
        'If nLastSpeechAltitude < nLastSpeechAltitude Then
        '    If nLastSpeechWaypoint <> -1 Then
        '        If bAnnounceWaypoints = True Then
        '            nLastSpeechInterval = Now.Ticks
        '            PlayMessage(sSpeechWaypoint, sSpeechVoice)
        '        End If
        '    End If
        '    nLastSpeechWaypoint = nWaypoint
        'End If
        If bAnnounceRegularInterval = True And Now.Ticks - nLastSpeechInterval > (1000 * nSpeechInterval) * 10000 And nWPCount <> -1 Then
            nLastSpeechInterval = Now.Ticks
            PlayMessage(sSpeechRegularInterval, sSpeechVoice)
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
                If InStr(rawData(nCount), "F2:") <> 0 Then
                    If InStr(rawData(nCount), "F2:T0:") = 0 Then
                        sTemp = Mid(rawData(nCount), InStr(rawData(nCount), "F2:") + 4)
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
                    AltimeterInstrumentControl1.SetAlimeterParameters(altitude - nHomeAltIndicator, sDistanceUnits)
                End If
                If bInstruments(e_Instruments.e_Instruments_Heading) Then
                    HeadingIndicatorInstrumentControl1.SetHeadingIndicatorParameters(GetHeading(heading))
                End If
                If bInstruments(e_Instruments.e_Instruments_Vertical) Then
                    VerticalSpeedIndicatorInstrumentControl1.SetVerticalSpeedIndicatorParameters(verticalChange, LCase(GetResString(, "Vertical_Speed")), GetResString(, "Up"), GetResString(, "Down"), "100ft/min")
                End If
                If bInstruments(e_Instruments.e_Instruments_3DModel) Then
                    _3DMesh1.DrawMesh(GetPitch(nPitch * n3DPitchRollOffset), GetRoll(nRoll * n3DPitchRollOffset), GetYaw(nYaw + n3DHeadingOffset))
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
                        lblGPSLock.Text = GetResString(, "_2D_Lock")
                    Case Else
                        lblGPSLock.Text = GetResString(, "_3D_Lock")
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
                        'If nHomeLat = "" Then
                        '    nHomeLat = latitude
                        '    nHomeLong = longitude
                        '    nHomeAlt = altitude
                        '    webDocument.GetElementById("homeLat").SetAttribute("value", latitude)
                        '    webDocument.GetElementById("homeLng").SetAttribute("value", longitude)
                        '    webDocument.GetElementById("setHomeLatLngButton").InvokeMember("click")
                        '    webDocument.GetElementById("centerMapHomeButton").InvokeMember("click")
                        'End If

                        'webDocument.GetElementById("heading").SetAttribute("value", heading)
                        'webDocument.GetElementById("segmentInterval").SetAttribute("value", "1")
                        'webDocument.GetElementById("segmentLat").SetAttribute("value", latitude)
                        'webDocument.GetElementById("segmentLng").SetAttribute("value", longitude)
                        'webDocument.GetElementById("addSegementButton").InvokeMember("click")
                    ElseIf eMapSelection = e_MapSelection.e_MapSelection_GoogleEarth Then
                        'nAltitude = ConvertDistance(nAltitude, eOutputDistance, e_DistanceFormat.e_DistanceFormat_Meters)
                        'If nHomeLat = "" And (latitude <> 0 Or nLongitude <> 0) Then
                        '    nHomeLat = latitude
                        '    nHomeLong = longitude
                        '    nHomeAlt = altitude
                        '    WebBrowser1.Invoke(New MyDelegate(AddressOf setHomeLatLng))
                        '    If cboMission.Text <> "" Then
                        '        cboMission_SelectedIndexChanged(Nothing, Nothing)
                        '    End If
                        'End If
                        ''WebBrowser1.Invoke(New MyDelegate(AddressOf LoadGEFeatures))
                        'WebBrowser1.Invoke(New MyDelegate(AddressOf setPlaneLocation))
                        If bPlaneFirstFound = False And latitude <> 0 And nLongitude <> 0 And bGoogleLoaded = True Then
                            bPlaneFirstFound = True
                            cmdSetHome.Enabled = True
                            webDocument.InvokeScript("initPlaneCamera", New Object() {ConvertPeriodToLocal(nLatitude), ConvertPeriodToLocal(nLongitude), ConvertPeriodToLocal(ConvertDistance(nAltitude, eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters)), sModelURL, tbarModelScale.Value, GetPitch(nPitch * nDaePitchRollOffset), GetRoll(nRoll * nDaePitchRollOffset), nCameraTracking, eAltOffset, True})
                            'webDocument.InvokeScript("initPlaneCamera", New Object() {nLatitude, nLongitude, nAltitude, sModelURL, tbarModelScale.Value, eAltOffset})
                            'WebBrowser1.Invoke(New MyDelegate(AddressOf setPlaneLocation))
                            'webDocument.InvokeScript("setHomeLatLng", New Object() {ConvertPeriodToLocal(nLatitude), ConvertPeriodToLocal(nLongitude), ConvertPeriodToLocal(ConvertDistance(nAltitude, eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters)), sModelURL, tbarModelScale.Value, GetPitch(nPitch * nDaePitchRollOffset), GetRoll(nRoll * nDaePitchRollOffset), nCameraTracking, eAltOffset, True})
                        ElseIf bGoogleLoaded = True Then
                            WebBrowser1.Invoke(New MyDelegate(AddressOf setPlaneLocation))
                        End If
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
            ConvertToRunTime = ConvertToRunTime & nMinutes & " " & IIf(nMinutes > 1, GetResString(, "mins"), GetResString(, "min"))
        End If
        nSeconds = nSeconds - (nMinutes * 60)

        If ConvertToRunTime <> "" Then
            ConvertToRunTime = ConvertToRunTime & ","
        End If
        ConvertToRunTime = ConvertToRunTime & nSeconds & " " & IIf(nSeconds > 1, GetResString(, "secs"), GetResString(, "sec"))

    End Function
    Public Sub setHomeLatLng()
        If webDocument Is Nothing Or bGoogleLoaded = False Then
            Exit Sub
        End If

        Try
            webDocument.InvokeScript("setHomeLatLng", New Object() {ConvertPeriodToLocal(nLatitude), ConvertPeriodToLocal(nLongitude), ConvertPeriodToLocal(ConvertDistance(nAltitude, eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters)), sModelURL, tbarModelScale.Value, GetPitch(nPitch * nDaePitchRollOffset), GetRoll(nRoll * nDaePitchRollOffset), nCameraTracking, eAltOffset, True, sHomeIcon})
            'lblHomeAltitude.Text = webDocument.GetElementById("homeGroundAltitude").ToString
        Catch e2 As Exception
        End Try
    End Sub
    'Public Sub buildPlaneModel()
    '    If webDocument Is Nothing Or bGoogleLoaded = False Then
    '        Exit Sub
    '    End If
    '    Try
    '        webDocument.InvokeScript("buildPlaneModel", New Object() {sModelURL})
    '    Catch e2 As Exception
    '    End Try
    'End Sub
    Public Sub centerOnLocation()
        If webDocument Is Nothing Or bGoogleLoaded = False Then
            Exit Sub
        End If
        Try
            webDocument.InvokeScript("centerOnLocation", New Object() {ConvertPeriodToLocal(nLatitude), ConvertPeriodToLocal(nLongitude), ConvertPeriodToLocal(nAltitude), -1, False})
            'lblHomeAltitude.Text = webDocument.GetElementById("homeGroundAltitude").ToString
        Catch e2 As Exception
        End Try
    End Sub
    Public Sub loadModel()
        If webDocument Is Nothing Or bGoogleLoaded = False Then
            Exit Sub
        End If
        Try
            webDocument.InvokeScript("loadModel", New Object() {sModelURL, nDaeHeadingOffset})
            'lblHomeAltitude.Text = webDocument.GetElementById("homeGroundAltitude").ToString
        Catch e2 As Exception
        End Try
    End Sub
    Public Sub addWaypoint()
        If webDocument Is Nothing Or bGoogleLoaded = False Then
            Exit Sub
        End If
        Try
            webDocument.InvokeScript("addWaypoint", New Object() {ConvertPeriodToLocal(nLatitude), ConvertPeriodToLocal(nLongitude), ConvertPeriodToLocal(ConvertDistance(nAltitude, eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters)), nNewWaypoint.ToString.PadLeft(2, "0"), bMissionExtrude, sMissionColor, nMissionWidth, eAltOffset, bMissionClampToGround})
        Catch e2 As Exception
        End Try
    End Sub
    Public Sub centerOnPlane()
        If webDocument Is Nothing Or bGoogleLoaded = False Then
            Exit Sub
        End If
        Try
            webDocument.InvokeScript("centerOnPlane", New Object() {})
        Catch e2 As Exception
        End Try
    End Sub
    Public Sub drawHomeLine()
        If webDocument Is Nothing Or bGoogleLoaded = False Then
            Exit Sub
        End If
        Try
            webDocument.InvokeScript("drawHomeLine", New Object() {})
        Catch e2 As Exception
        End Try
    End Sub
    Public Sub changeModelScale()
        If webDocument Is Nothing Or bGoogleLoaded = False Then
            Exit Sub
        End If
        Try
            webDocument.InvokeScript("changeModelScale", New Object() {tbarModelScale.Value})
        Catch e2 As Exception
        End Try
    End Sub
    Public Sub updateAttitude()
        If webDocument Is Nothing Or bGoogleLoaded = False Then
            Exit Sub
        End If
        Try
            webDocument.InvokeScript("updateAttitude", New Object() {ConvertPeriodToLocal(GetHeading(nHeading + nDaeHeadingOffset)), nDaeHeadingOffset, ConvertPeriodToLocal(GetPitch(nPitch * nDaePitchRollOffset)), ConvertPeriodToLocal(GetRoll(nRoll * nDaePitchRollOffset))})
        Catch e2 As Exception
        End Try
    End Sub
    Public Sub setPlaneLocation()
        If webDocument Is Nothing Or bGoogleLoaded = False Then
            Exit Sub
        End If
        Try
            webDocument.InvokeScript("drawAndCenter", New Object() {ConvertPeriodToLocal(nLatitude), ConvertPeriodToLocal(nLongitude), ConvertPeriodToLocal(ConvertDistance(nAltitude, eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters)), bFlightExtrude, sFlightColor, nFlightWidth, nCameraTracking, IIf(eDistanceUnits = e_DistanceFormat.e_DistanceFormat_Feet, True, False), GetHeading(nHeading + nDaeHeadingOffset), nDaeHeadingOffset, GetPitch(nPitch * nDaePitchRollOffset), GetRoll(nRoll * nDaePitchRollOffset), eAltOffset, bHeadLock})
            'lblHomeAltitude.Text = webDocument.GetElementById("homeGroundAltitude").ToString
        Catch ex As Exception
            Debug.Print("HERE")
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
        Dim dDateTime As Date

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
                dDateTime = New Date(nThisTime)
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

        If eMissionFileType = e_MissionFileType.e_MissionFileType_GCS Then
            dGPSDate = dDateTime.Date
            dGPSTime = dDateTime.ToLongTimeString
            sMessage = Mid(rawData(nDataIndex), 20)
            sMessage = sMessage.Substring(0, Len(sMessage) - 1) & vbCrLf
        Else
            sMessage = rawData(nDataIndex) & vbCrLf
        End If
        TrackBar1.Value = nDataIndex

        'aBuffer = System.Text.UTF8Encoding.UTF8.GetBytes(sMessage)
        UpdateSerialDataWindow(sMessage, sMessage)
        oMessage = GetNextSentence(sMessage) ', aBuffer)
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
                If IsNumeric(Mid(rawData(index), 1, InStr(rawData(index), ":") - 1)) = True Then
                    GetMessageTime = Mid(rawData(index), 1, InStr(rawData(index), ":") - 1)
                End If
            End If
        ElseIf eMissionFileType = e_MissionFileType.e_MissionFileType_UDB Then
                If index < UBound(rawData) Then
                    If InStr(rawData(index), "F2:") <> 0 Then
                        If InStr(rawData(index), "F2:T0:") <> 0 Then
                            GetMessageTime = 0
                        Else
                            sTemp = Mid(rawData(index), InStr(rawData(index), "F2:") + 4)
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
    Public Sub ReadSerialData()
        Dim nReadCount As Integer
        Dim nReadResult As Integer
        Dim bWasSearching As Boolean
        Dim sNewString As String
        Dim ar As IAsyncResult
        Dim sOutput As String
        Dim nCount As Integer
        Dim sTempByte As Byte

        If bShutdown = True Then
            Exit Sub
        End If

        bWasSearching = tmrSearch.Enabled
        If bWasSearching Then
            tmrSearch.Enabled = False
        End If

        If cboComPort.Text = "TCP" Or cboComPort.Text = "UDP" Then
            SocketServer.ReceiveCallback(ar)
        End If

        Try
            If serialPortIn.IsOpen = True Then
                If serialPortIn.BytesToRead > 0 Then
                    nReadCount = serialPortIn.BytesToRead - 0  'Number of Bytes to read
                    If nReadCount > 0 Then
                        'Dim cData(nReadCount - 1) As Byte

                        serialPortIn.Encoding = System.Text.Encoding.GetEncoding(1252)
                        sNewString = serialPortIn.ReadExisting

                        'Do While serialPortIn.BytesToRead > 0
                        '    sTempByte = serialPortIn.ReadByte
                        '    sNewString = sNewString & Chr(sTempByte)
                        '    'ReDim Preserve aBuffer(0 To UBound(aBuffer) + 1)
                        '    'aBuffer(UBound(aBuffer)) = sTempByte
                        'Loop

                        'Dim encoding As New System.Text.UTF8Encoding
                        'cData = encoding.GetBytes(sNewString)

                        nInputStringLength = nInputStringLength + Len(sNewString)
                        'serialPortIn.Encoding = System.Text.Encoding.GetEncoding(28591) 'System.Text.Encoding.GetEncoding(28591) '65001) '28591

                        'serialPortIn.Encoding = System.Text.Encoding.GetEncoding(28591)

                        'nReadResult = serialPortIn.Read(cData, 0, nReadCount)  'Reading the Data

                        'sNewString = ""
                        'For nCount = 0 To cData.Length - 1
                        '    sNewString = sNewString & Chr(cData(nCount))
                        'Next nCount
                        ''sNewString = System.Text.Encoding.Default.GetString(cData, 0, cData.Length)
                        ''sNewString = System.Text.Encoding.ASCII.GetString(cData, 0, cData.Length)

                        sBuffer = sBuffer & sNewString
                        'If Len(sNewString) > 0 Then
                        '    aBuffer = ConCatArray(aBuffer, cData)
                        'End If
                        'For Each b As Byte In cData

                        '    'AddCharacter(b)
                        '    'If b >= 128 And b <= 159 Then     '&H80<=indata<=&H9F
                        '    '    sBuffer = sBuffer & Chr(b)
                        '    'Else
                        '    '    sBuffer = sBuffer & ChrW(b)
                        '    'End If
                        '    'sBuffer = sBuffer & Chr(b)        'Ascii String
                    End If
                End If

                If tabInstrumentView.SelectedIndex = 2 And Not sNewString Is Nothing Then
                    sCommandLineBuffer = sCommandLineBuffer & sNewString
                Else
                    sCommandLineBuffer = ""
                End If
            End If

            Try
                NewDataReceived()
            Catch
            End Try
            Try
                HeartbeatSend()
            Catch
            End Try
            Try
                oActiveDevices.Validate()
            Catch ex2 As Exception
                Debug.Print(ex2.Message)
            End Try

            Try
                If oActiveDevices.bAlarm = True Then
                    If (oActiveDevices.nBrokenTime * 5).ToString("0") Mod 2 = 0 Then
                        pnlLinkLost.BackColor = Color.LightCoral
                    Else
                        pnlLinkLost.BackColor = Color.Red
                    End If
                    lblLinkLostLabel.Text = "ALARM"
                    lblLinkLostMessageType.Text = oActiveDevices.sDeviceType
                    lblLinkLostTime.Text = oActiveDevices.nBrokenTime.ToString("0.00") & " " & GetResString(, "secs")
                    pnlLinkLost.Visible = True
                    pnlLinkLost.Show()
                ElseIf oActiveDevices.bWarning = True Then
                    If (oActiveDevices.nBrokenTime * 5).ToString("0") Mod 2 = 0 Then
                        pnlLinkLost.BackColor = Color.Yellow
                    Else
                        pnlLinkLost.BackColor = Color.LightGoldenrodYellow
                    End If
                    lblLinkLostLabel.Text = "WARNING"
                    lblLinkLostMessageType.Text = oActiveDevices.sDeviceType
                    lblLinkLostTime.Text = oActiveDevices.nBrokenTime.ToString("0.00") & " " & GetResString(, "secs")
                    pnlLinkLost.Visible = True
                    pnlLinkLost.Show()
                Else
                    pnlLinkLost.Visible = False
                End If
            Catch
            End Try

            If bWasSearching Then
                tmrSearch.Enabled = True
            End If

            If (Now.Ticks - 10000000) > dManuelMode And imgManuel.Visible = True Then
                imgManuel.Visible = False
            End If

            If bNewConnect = True Then
                SendAttoPilot("Q,0,0")
                bNewConnect = False
                bWaitingAttoUpdate = True
                bWaitingMavlinkUpdate = True
                bWaitingGluonUpdate = True
            End If
            If nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot Then
                If bWaitingAttoUpdate = False Then
                    If bNewDevice = True Then
                        cmdConfigRead_Click(Nothing, Nothing)
                        cmdMissionRead_Click(Nothing, Nothing)
                        bNewDevice = False
                    End If
                End If
                If cboConfigDevice.Enabled = False Then
                    If ((Now.Ticks > dLastAtto + 3000000) And bWaitingAttoUpdate = False) Or (Now.Ticks > dLastAtto + 10000000) Then
                        dLastAtto = Now.Ticks
                        SendAttoPilot("Q," & nConfigVehicle & ",0")
                    End If
                End If
            ElseIf nConfigDevice = e_ConfigDevice.e_ConfigDevice_Gluonpilot Then
                If bWaitingGluonUpdate = False Then
                    If bNewDevice = True Then
                        'cmdMissionRead_Click(Nothing, Nothing)
                        cmdConfigRead_Click(Nothing, Nothing)
                        bNewDevice = False
                    End If
                End If
            ElseIf nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink Then
                If bWaitingMavlinkUpdate = False Then
                    If eNewDeviceBootState = e_NewDevice_BootState.e_NewDevice_BootState_None And dLastNewDevice = 0 And bNewDevice = True Then
                        dLastNewDevice = Now.Ticks
                        eNewDeviceBootState = e_NewDevice_BootState.e_NewDevice_BootState_None
                    ElseIf Now.Ticks - dLastNewDevice > 40000000 And eNewDeviceBootState = e_NewDevice_BootState.e_NewDevice_BootState_None Then
                        eNewDeviceBootState = e_NewDevice_BootState.e_NewDevice_BootState_RequestingParameters
                        cmdConfigRead_Click(Nothing, Nothing)
                        bNewDevice = False
                    ElseIf eNewDeviceBootState = e_NewDevice_BootState.e_NewDevice_BootState_ParametersComplete Then
                        eNewDeviceBootState = e_NewDevice_BootState.e_NewDevice_BootState_RequestingMission
                        cmdMissionRead_Click(Nothing, Nothing)
                        bNewDevice = False
                    ElseIf eNewDeviceBootState = e_NewDevice_BootState.e_NewDevice_BootState_MissionComplete Then
                        eNewDeviceBootState = e_NewDevice_BootState.e_NewDevice_BootState_StartComplete
                        'UpdateMavlinkStatusRates()
                        bNewDevice = False
                    End If
                End If
                If nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_TotalCountRespond Or nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_WaypointRespond Then
                    If nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_TotalCountRespond Then
                        nWPCount = 0
                    Else
                        nWPCount = nWPCount + 1
                    End If
                    nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_WaypointRequest
                    SendMavlinkWPDetailRequest()
                ElseIf nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_DoneRequesting Then
                    nWPCount = nWaypointTotal - 1
                    nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_None
                    LoadMissionGrid()
                    SetMissionStatus("Mission commands successfully read")
                    'sOutput = Chr(85) & Chr(3) & Chr(0) & Chr("&H7F") & Chr(0) & Chr(44) & Chr(nConfigVehicle) & Chr(1) & Chr(0)
                    'FIX315
                    SendMavLink(New Byte() {85, 3, 0, 127, 0, 47, nConfigVehicle, 1, 0})
                    'SendMavLink(sOutput)
                    If bNewDevice = False And tabInstrumentView.SelectedIndex = 4 Then
                        chkViewNoTracking.Checked = True
                        chkViewNoTracking_CheckedChanged(Nothing, Nothing)
                        UpdateMissionGE(0, , 0, True)
                    Else
                        UpdateMissionGE(0, , -1, False)
                    End If

                    UpdateMavlinkStatusRates()

                    If tabMapView.TabPages(tabMapView.SelectedIndex).Tag = "Google Earth" Then
                        WebBrowser1.Focus()
                    End If
                    'FIX315
                ElseIf nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_TotalCountRequest Then
                    If Now.Ticks > (dLastMavlinkCommandTime + (n2WayTimeout * 20000000)) Then
                        dLastMavlinkCommandTime = Now.Ticks
                        nMavlinkRetryAttempts = nMavlinkRetryAttempts + 1
                        If nMavlinkRetryAttempts <= n2WayRetries Then
                            SetMissionStatus("APM failed to respond to mission request...retrying...", True)
                            Debug.Print("Retrying Request Count List (Try #" & n2WayRetries & ")")
                            SendMavlinkWPCountRequest()
                        Else
                            SetMissionStatus("Misson request failed", True)
                            nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_None
                        End If
                    End If
                ElseIf nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_WaypointRequest Then
                    If Now.Ticks > dLastMavlinkCommandTime + (n2WayTimeout * 20000000) Then
                        dLastMavlinkCommandTime = Now.Ticks
                        nMavlinkRetryAttempts = nMavlinkRetryAttempts + 1
                        If nMavlinkRetryAttempts <= n2WayRetries Then
                            SetMissionStatus("APM failed to respond to command request...retrying...", True)
                            If nWPCount = 0 Then
                                SendMavlinkWPCountRequest()
                            Else
                                SendMavlinkWPDetailRequest()
                            End If
                        Else
                            nWPCount = -1
                            SetMissionStatus("Command request failed", True)
                            nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_None
                            UpdateMavlinkStatusRates()
                        End If
                    End If
                ElseIf nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_WaypointSet Then
                    If Now.Ticks > dLastMavlinkCommandTime + (n2WayTimeout * 20000000) Then
                        dLastMavlinkCommandTime = Now.Ticks
                        nMavlinkRetryAttempts = nMavlinkRetryAttempts + 1
                        If nMavlinkRetryAttempts <= n2WayRetries Then
                            SetMissionStatus("APM failed to respond to write request...retrying...", True)
                            SendMavlinkWPDetailSet(nMavlinkCurrentWaypointSend)
                        Else
                            SetMissionStatus("Mission write failed", True)
                            nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_None
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub
    Private Sub SendMavlinkWPDetailSet(ByVal waypointNumber As Integer)
        'Dim sOutput As String
        Dim nCommandIndex As Integer
        'Dim sLatLocal As String = ""
        'Dim sLongLocal As String = ""
        'Dim sAltLocal As String = ""
        'Dim sOtherLocal1 As String = ""
        'Dim sOtherLocal2 As String = ""
        'Dim sOtherLocal3 As String = ""
        'Dim sOtherLocal4 As String = ""

        Dim aOutput() As Byte
        Dim aParam1() As Byte
        Dim aParam2() As Byte
        Dim aParam3() As Byte
        Dim aParam4() As Byte
        Dim aParam5() As Byte
        Dim aParam6() As Byte
        Dim aParam7() As Byte

        Try
            nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_WaypointSet
            prgMissionMavlink.Value = waypointNumber
            nCommandIndex = GetCommandIndex(aWPCommand(waypointNumber))

            If aCommandArg1(nCommandIndex) <> "" Then
                aParam1 = ConvertSingleToMavlinkByte(CorrectWriteMissionData(aWPOther(waypointNumber), aCommandMult1(nCommandIndex), aCommandUnit1(nCommandIndex)))
                'sOtherLocal1 = ConvertSingleToMavlink(CorrectWriteMissionData(aWPOther(waypointNumber), aCommandMult1(nCommandIndex), aCommandUnit1(nCommandIndex)))
            Else
                aParam1 = New Byte() {0, 0, 0, 0}
                'sOtherLocal1 = Chr(0) & Chr(0) & Chr(0) & Chr(0)
            End If

            If aCommandArg2(nCommandIndex) <> "" Then
                aParam2 = ConvertSingleToMavlinkByte(CorrectWriteMissionData(aWPOther2(waypointNumber), aCommandMult2(nCommandIndex), aCommandUnit2(nCommandIndex)))
                'sOtherLocal2 = ConvertSingleToMavlink(CorrectWriteMissionData(aWPOther2(waypointNumber), aCommandMult2(nCommandIndex), aCommandUnit2(nCommandIndex)))
            Else
                aParam2 = New Byte() {0, 0, 0, 0}
                'sOtherLocal2 = Chr(0) & Chr(0) & Chr(0) & Chr(0)
            End If

            If aCommandArg3(nCommandIndex) <> "" Then
                aParam3 = ConvertSingleToMavlinkByte(CorrectWriteMissionData(aWPOther3(waypointNumber), aCommandMult3(nCommandIndex), aCommandUnit3(nCommandIndex)))
                'sOtherLocal3 = ConvertSingleToMavlink(CorrectWriteMissionData(aWPOther3(waypointNumber), aCommandMult3(nCommandIndex), aCommandUnit3(nCommandIndex)))
            Else
                aParam3 = New Byte() {0, 0, 0, 0}
                'sOtherLocal3 = Chr(0) & Chr(0) & Chr(0) & Chr(0)
            End If

            If aCommandArg4(nCommandIndex) <> "" Then
                aParam4 = ConvertSingleToMavlinkByte(CorrectWriteMissionData(aWPOther4(waypointNumber), aCommandMult4(nCommandIndex), aCommandUnit4(nCommandIndex)))
                'sOtherLocal4 = ConvertSingleToMavlink(CorrectWriteMissionData(aWPOther4(waypointNumber), aCommandMult4(nCommandIndex), aCommandUnit4(nCommandIndex)))
            Else
                aParam4 = New Byte() {0, 0, 0, 0}
                'sOtherLocal4 = Chr(0) & Chr(0) & Chr(0) & Chr(0)
            End If

            If aCommandArg5(nCommandIndex) <> "" Then
                aParam5 = ConvertSingleToMavlinkByte(CorrectWriteMissionData(aWPLat(waypointNumber), aCommandMult5(nCommandIndex), aCommandUnit5(nCommandIndex)))
                'sLatLocal = ConvertSingleToMavlink(CorrectWriteMissionData(aWPLat(waypointNumber), aCommandMult5(nCommandIndex), aCommandUnit5(nCommandIndex)))
            Else
                aParam5 = New Byte() {0, 0, 0, 0}
                'sLatLocal = Chr(0) & Chr(0) & Chr(0) & Chr(0)
            End If

            If aCommandArg6(nCommandIndex) <> "" Then
                aParam6 = ConvertSingleToMavlinkByte(CorrectWriteMissionData(aWPLon(waypointNumber), aCommandMult6(nCommandIndex), aCommandUnit6(nCommandIndex)))
                'sLongLocal = ConvertSingleToMavlink(CorrectWriteMissionData(aWPLon(waypointNumber), aCommandMult6(nCommandIndex), aCommandUnit6(nCommandIndex)))
            Else
                aParam6 = New Byte() {0, 0, 0, 0}
                'sLongLocal = Chr(0) & Chr(0) & Chr(0) & Chr(0)
            End If

            If aCommandArg7(nCommandIndex) <> "" Then
                aParam7 = ConvertSingleToMavlinkByte(CorrectWriteMissionData(aWPAlt(waypointNumber), aCommandMult7(nCommandIndex), aCommandUnit7(nCommandIndex)))
                'sAltLocal = ConvertSingleToMavlink(CorrectWriteMissionData(aWPAlt(waypointNumber), aCommandMult7(nCommandIndex), aCommandUnit7(nCommandIndex)))
            Else
                aParam7 = New Byte() {0, 0, 0, 0}
                'sAltLocal = Chr(0) & Chr(0) & Chr(0) & Chr(0)
            End If

            aOutput = New Byte() {85, 36, 0, 127, 0, 39, nConfigVehicle, 1}
            aOutput = ConCatArray(aOutput, ConvertIntegerToMavlinkByte(waypointNumber))
            aOutput = ConCatArray(aOutput, New Byte() {0, aWPCommand(waypointNumber), 1, 1})
            aOutput = ConCatArray(aOutput, aParam1)
            aOutput = ConCatArray(aOutput, aParam2)
            aOutput = ConCatArray(aOutput, aParam3)
            aOutput = ConCatArray(aOutput, aParam4)
            aOutput = ConCatArray(aOutput, aParam5) 'Lat
            aOutput = ConCatArray(aOutput, aParam6) 'Long
            aOutput = ConCatArray(aOutput, aParam7) 'Alt

            'sOutput = Chr(85) & Chr(36) & Chr(0) & Chr("&H7F") & Chr(0) & Chr(39) & Chr(nConfigVehicle) & Chr(1) & ConvertIntegerToMavlink(waypointNumber) & Chr(0) & Chr(aWPCommand(waypointNumber)) & Chr(1) & Chr(1) & sOtherLocal1 & sOtherLocal2 & sOtherLocal3 & sOtherLocal4 & sLatLocal & sLongLocal & sAltLocal
            SendMavLink(aOutput)
            Debug.Print("Sent Waypoint Set Command #" & waypointNumber)
            'FIX 314

        Catch ex As Exception
        End Try

        'Debug.Print("Length=" & Len(.Packet))
        'Debug.Print("System=" & Asc(Mid(.Packet, 7, 1)))
        'Debug.Print("Component=" & Asc(Mid(.Packet, 8, 1)))
        'Debug.Print("Seq=" & ConvertMavlinkToInteger(Mid(.Packet, 9, 2)))
        'Debug.Print("Frame=" & Asc(Mid(.Packet, 11, 1)))
        'Debug.Print("Action=" & Asc(Mid(.Packet, 12, 1)))
        'Debug.Print("Orbit=" & ConvertMavlinkToSingle(Mid(.Packet, 13, 4)))
        'Debug.Print("orbit_direction=" & Asc(Mid(.Packet, 17, 1)))
        'Debug.Print("param1=" & ConvertMavlinkToSingle(Mid(.Packet, 18, 4)))
        'Debug.Print("param2=" & ConvertMavlinkToSingle(Mid(.Packet, 22, 4)))
        'Debug.Print("current=" & Asc(Mid(.Packet, 26, 1)))
        'Debug.Print("x=" & ConvertMavlinkToSingle(Mid(.Packet, 27, 4)))
        'Debug.Print("y=" & ConvertMavlinkToSingle(Mid(.Packet, 31, 4)))
        'Debug.Print("z=" & ConvertMavlinkToSingle(Mid(.Packet, 35, 4)))
        'Debug.Print("yaw=" & ConvertMavlinkToSingle(Mid(.Packet, 39, 4)))
        'Debug.Print("autocontinue=" & Asc(Mid(.Packet, 41, 1)))

        'aWPCommand(nWPCount) = Hex(ConvertMavlinkToSingle(Mid(.Packet, 18, 4)))
        'aWPAlt(nWPCount) = ConvertMavlinkToSingle(Mid(.Packet, 35, 4))
        'aWPOther(nWPCount) = ConvertMavlinkToSingle(Mid(.Packet, 39, 4))
        'aWPLat(nWPCount) = ConvertMavlinkToSingle(Mid(.Packet, 31, 4))
        'aWPLon(nWPCount) = ConvertMavlinkToSingle(Mid(.Packet, 27, 4))
    End Sub
    Private Sub SendMavlinkWPDetailRequest()
        Dim arr() As Byte
        'FIX314
        arr = New Byte() {85, 4, 0, 127, 0, 40, nConfigVehicle, 1}
        arr = ConCatArray(arr, ConvertIntegerToMavlinkByte(nWPCount))
        SendMavLink(arr)
        Debug.Print("Requested WP Detail #" & nWPCount)
    End Sub

    Private Sub HeartbeatSend()
        Dim nDelay As Long
        CheckHeartbeatSend(bHeartbeat1, nHeartbeatDevice1, bHeartbeatRun1, dLastHeartbeat1, nHeartbeatRate1, sHeartbeatName1, sHeartbeat1)
        CheckHeartbeatSend(bHeartbeat2, nHeartbeatDevice2, bHeartbeatRun2, dLastHeartbeat2, nHeartbeatRate2, sHeartbeatName2, sHeartbeat2)
        CheckHeartbeatSend(bHeartbeat3, nHeartbeatDevice3, bHeartbeatRun3, dLastHeartbeat3, nHeartbeatRate3, sHeartbeatName3, sHeartbeat3)
        CheckHeartbeatSend(bHeartbeat4, nHeartbeatDevice4, bHeartbeatRun4, dLastHeartbeat4, nHeartbeatRate4, sHeartbeatName4, sHeartbeat4)
        CheckHeartbeatSend(bHeartbeat5, nHeartbeatDevice5, bHeartbeatRun5, dLastHeartbeat5, nHeartbeatRate5, sHeartbeatName5, sHeartbeat5)
        CheckHeartbeatSend(bHeartbeat6, nHeartbeatDevice6, bHeartbeatRun6, dLastHeartbeat6, nHeartbeatRate6, sHeartbeatName6, sHeartbeat6)
    End Sub
    Private Sub CheckHeartbeatSend(ByVal isEnabled As Boolean, ByVal deviceType As e_DeviceTypes, ByRef hasHeartbeatRun As Boolean, ByRef lastChecked As Long, ByVal sendRate As Integer, ByVal heartbeatName As String, ByVal hearbeatMessage As String)
        Dim nDelay As Long

        If deviceType <> 0 Then
            If oActiveDevices.bDeviceFound(deviceType) = False Then
                Exit Sub
            End If
        End If

        If isEnabled = True Then
            If sendRate = -999 And oActiveDevices.nHearbeatRun(deviceType) = 0 Then
                nDelay = 0
            ElseIf sendRate = -999 Then
                Exit Sub
            Else
                If sendRate < 0 Then
                    nDelay = -sendRate * 10000000
                Else
                    nDelay = (1000 / sendRate) * 10000
                End If
            End If

            hasHeartbeatRun = True
            If (lastChecked + nDelay) < Now.Ticks Then
                lastChecked = Now.Ticks
                oActiveDevices.nHearbeatRun(deviceType) = oActiveDevices.nHearbeatRun(deviceType) + 1
                SendHeartbeat(IIf(heartbeatName <> "", "(" & heartbeatName & ") - ", "(Heartbeat #1) - "), hearbeatMessage)
                If deviceType = e_DeviceTypes.e_DeviceTypes_NMEA And InStr(hearbeatMessage, "$PGCMD") <> 0 Then
                    'oActiveDevices.nHearbeatRun(deviceType) = 0
                    oActiveDevices.dLastDeviceTime(deviceType) = 0
                End If
            End If
        End If
    End Sub
    Private Sub SendHeartbeat(ByVal heartbeatName As String, ByVal heartbeatMessage As String)
        Dim sTemp As String
        Dim sTemp2 As String
        Dim nDelay As Long

        'sTemp = Replace(heartbeatMessage, "<CR><LF>", vbCrLf, , , CompareMethod.Text)
        sTemp = Replace(Replace(heartbeatMessage, "<CR>", vbCr, , , CompareMethod.Text), "<LF>", vbLf, , , CompareMethod.Text)
        Do While True
            If InStr(sTemp, "<SLEEP", CompareMethod.Text) <> 0 Then
                sTemp2 = Mid(sTemp, 1, InStr(sTemp, "<SLEEP") - 1)
                WriteSerialIn(sTemp2, , heartbeatName)
                sTemp = Mid(sTemp, InStr(sTemp, "<SLEEP") + 7)
                Try
                    nDelay = Convert.ToUInt16(Mid(sTemp, 1, InStr(sTemp, ">") - 1))
                    System.Threading.Thread.Sleep(nDelay)
                Catch
                    Exit Do
                End Try
                sTemp = Mid(sTemp, InStr(sTemp, ">") + 1)
                If sTemp = "" Then
                    Exit Do
                End If
            Else
                WriteSerialIn(sTemp, , heartbeatName)
                Exit Do
            End If
        Loop
    End Sub
    Public Sub NewDataReceived()
        Dim nSentenceCount As Integer
        Dim oMessage As cMessage
        Dim nBandwith As Single

        'nInputStringLength = nInputStringLength + Len(sNewString)
        'Next

        Try
            nSentenceCount = 0
            If sBuffer <> "" Then
                Try
                    oMessage = GetNextSentence(sBuffer) ', aBuffer)
                Catch ex As Exception
                End Try
                'If Not oMessage.RawMessage Is Nothing Or Not oMessage.VisibleSentence Is Nothing Then
                UpdateSerialDataWindow(oMessage.RawMessage, oMessage.VisibleSentence, , oMessage.ValidMessage)
                'End If
                Do While oMessage.ValidMessage = True
                    If dStartTime.Ticks = 0 Then
                        dStartTime = Now
                    End If
                    tmrSearch.Enabled = False
                    cboBaudRate.Text = serialPortIn.BaudRate

                    'bWasSearching = False

                    Try
                        UpdateVariables(oMessage)
                        oMessage = GetNextSentence(sBuffer) ', aBuffer)
                        UpdateSerialDataWindow(oMessage.RawMessage, oMessage.VisibleSentence, , oMessage.ValidMessage)
                    Catch ex As Exception
                    End Try
                Loop
            End If
        Catch
        End Try


        Try
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
        Catch
        End Try

    End Sub
    Public Sub UpdateSerialDataWindow(ByVal rawString As String, ByVal visibleString As String, Optional ByVal isInbound As Boolean = True, Optional ByVal isValidMessage As Boolean = True)
        Dim nOldTop As Long
        Dim nExistingLen As Integer
        Dim nCount As Integer
        Dim bSomethingAdded As Boolean = False

        GpS_Parser1_RawPacket(rawString)
        If bConnected = False Then
            lstInbound.Items.Insert(0, IIf(isInbound = True, "IN:", "OUT:") & "#" & nDataIndex & " - " & Replace(Replace(visibleString, vbCr, ""), vbLf, ""))
        Else
            'If InStr(visibleString, vbCr) <> 0 Then
            '    Do While InStr(visibleString, vbCr) <> 0 Or InStr(visibleString, vbLf) <> 0
            '        lstInbound.Items.Insert(0, IIf(isInbound = True, "IN:", "OUT:") & Mid(visibleString, 1, InStr(visibleString, vbCr) - 1))
            '        visibleString = Mid(visibleString, InStr(visibleString, vbCr))
            '        Do While Microsoft.VisualBasic.Left(visibleString, 1) = vbLf Or Microsoft.VisualBasic.Left(visibleString, 1) = vbCr
            '            visibleString = Mid(visibleString, 2)
            '        Loop
            '    Loop
            'Else
            If Not visibleString Is Nothing And visibleString <> "" And isValidMessage = True Then
                lstInbound.Items.Insert(0, IIf(isInbound = True, "IN:", "OUT:") & Replace(Replace(visibleString, vbCr, ""), vbLf, ""))
            End If
        End If

        Try
            For nCount = nMaxListboxRecords To lstInbound.Items.Count - 1
                lstInbound.Items.RemoveAt(nMaxListboxRecords)
            Next
        Catch
        End Try

        nOldTop = lstCommandLineOutput.TopIndex

        If tabInstrumentView.SelectedIndex = 2 Then
            'lstCommandLineOutput.BeginUpdate()
            If nCommandLineDelim = 1 Then
                Do While InStr(sCommandLineBuffer, vbLf) <> 0
                    lstCommandLineOutput.Items.Add(Mid(sCommandLineBuffer, 1, InStr(sCommandLineBuffer, vbLf) - 1))
                    sCommandLineBuffer = Mid(sCommandLineBuffer, InStr(sCommandLineBuffer, vbLf) + 1)
                    bSomethingAdded = True
                Loop
            ElseIf nCommandLineDelim = 2 Then
                Do While InStr(sCommandLineBuffer, vbCr) <> 0
                    lstCommandLineOutput.Items.Add(Replace(Mid(sCommandLineBuffer, 1, InStr(sCommandLineBuffer, vbCr) - 1), vbLf, ""))
                    sCommandLineBuffer = Mid(sCommandLineBuffer, InStr(sCommandLineBuffer, vbCr) + 1)
                    bSomethingAdded = True
                Loop
            ElseIf nCommandLineDelim = 3 Then
                Do While InStr(sCommandLineBuffer, vbCrLf) <> 0
                    lstCommandLineOutput.Items.Add(Mid(sCommandLineBuffer, 1, InStr(sCommandLineBuffer, vbCrLf) - 1))
                    sCommandLineBuffer = Mid(sCommandLineBuffer, InStr(sCommandLineBuffer, vbCrLf) + 2)
                    bSomethingAdded = True
                Loop
            Else
                If lstCommandLineOutput.Items.Count = 0 Then
                    lstCommandLineOutput.Items.Add(sCommandLineBuffer)
                    bSomethingAdded = True
                Else
                    nExistingLen = Len(lstCommandLineOutput.Items(lstCommandLineOutput.Items.Count - 1))
                    If nExistingLen > 80 Then
                        lstCommandLineOutput.Items.Add(sCommandLineBuffer)
                        bSomethingAdded = True
                    Else
                        lstCommandLineOutput.Items(lstCommandLineOutput.Items.Count - 1) = lstCommandLineOutput.Items(lstCommandLineOutput.Items.Count - 1) & sCommandLineBuffer
                    End If
                End If
                sCommandLineBuffer = ""
            End If
            If sCommandLineBuffer <> "" Then
                lstCommandLineOutput.Items.Add(sCommandLineBuffer)
                bSomethingAdded = True
                sCommandLineBuffer = ""
            End If
        End If

        For nCount = nMaxListboxRecords To lstCommandLineOutput.Items.Count - 1
            lstCommandLineOutput.Items.RemoveAt(0)
        Next
        'lstCommandLineOutput.EndUpdate()

        If bSomethingAdded = True Then
            If chkCommandLineAutoScroll.Checked = True Then
                lstCommandLineOutput.TopIndex = lstCommandLineOutput.Items.Count - 1
            Else
                lstCommandLineOutput.TopIndex = nOldTop
            End If
        End If
    End Sub
    Private Sub UpdateVariables(ByVal oMessage As cMessage)
        Dim sSplit() As String
        Dim sSplit2() As String
        Dim sValues() As String
        Dim nCount As Integer
        Dim sTemp As String
        Dim nYawComponent1 As Single
        Dim nParameterMax As Integer

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

        Try

            With oMessage
                If .ValidMessage = True Then
                    Select Case .MessageType
                        Case cMessage.e_MessageType.e_MessageType_Paparazzi
                            lblGPSType.Text = "Paparazzi"
                            sSplit = Split(.Packet, " ")
                            dGPSTime = GetUnixTime(sSplit(0))
                            dGPSDate = GetUnixDate(sSplit(0))
                            bNewDateTime = True
                            Select Case UCase(sSplit(1))
                                Case "GPS"
                                    nLongitude = ConvertLatLongFormat(Convert.ToInt32(sSplit(4)) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                                    nLatitude = ConvertLatLongFormat(Convert.ToInt32(sSplit(5)) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                                    nGroundSpeed = ConvertSpeed(Convert.ToDouble(sSplit(8)), e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                    nAltitude = ConvertDistance(Convert.ToSingle(sSplit(7)), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                    nHeading = Convert.ToSingle(sSplit(6)) * 180 / Math.PI
                                    bNewGPS = True
                                Case "ATTITUDE"
                                    nRoll = -Convert.ToSingle(sSplit(3)) * 180 / Math.PI
                                    nYaw = Convert.ToSingle(sSplit(4)) * 180 / Math.PI
                                    nPitch = Convert.ToSingle(sSplit(5)) * 180 / Math.PI
                                    bNewAttitude = True
                                Case "BAT"
                                    nBattery = Convert.ToInt32(sSplit(3)) / 10
                                    nMAH = Convert.ToInt32(sSplit(3))
                                    bNewWaypoint = True
                                    'Debug.Print(oMessage.RawMessage)
                            End Select

                            'GLUONPILOT PARSE
                        Case cMessage.e_MessageType.e_MessageType_GluonpilotT, cMessage.e_MessageType.e_MessageType_GluonpilotC, cMessage.e_MessageType.e_MessageType_GluonpilotD
                            lblGPSType.Text = "Gluonpilot"
                            sSplit = Split(.Packet, ";")
                            bWaitingGluonUpdate = False
                            SetConfigDevice(e_ConfigDevice.e_ConfigDevice_Gluonpilot, , True)
                            Select Case UCase(.Header)
                                Case "CA"
                                    LoadGluonVariables()

                                    Try
                                        For nCount = 0 To UBound(aIDs)
                                            aChanged(nCount) = False
                                            If UBound(sSplit) >= aIDs(nCount) - 1 Then
                                                aValue(nCount) = Convert.ToSingle(sSplit(aIDs(nCount) - 1))
                                                'Debug.Print(aName(nCount))
                                                If IsNumeric(aMultiplier(nCount)) = True Then
                                                    aValue(nCount) = aValue(nCount) * aMultiplier(nCount)
                                                End If
                                                If IsNumeric(aAdder(nCount)) = True Then
                                                    aValue(nCount) = Convert.ToSingle(aValue(nCount)) + Convert.ToInt32(aAdder(nCount))
                                                End If
                                                If IsNumeric(aBit(nCount)) = True Then
                                                    aValue(nCount) = aValue(nCount) And aBit(nCount)
                                                    If aValue(nCount) > 0 Then
                                                        aValue(nCount) = 1
                                                    End If
                                                End If
                                            End If
                                            'prgConfig.Value = nCount
                                            'prgConfig.Refresh()
                                        Next
                                    Catch
                                    End Try
                                    LoadAttoParameterGrid()

                                    SetConfigStatus("Parameter read complete")

                                Case "TA"
                                    lblGPSMessage.Text = "TA - " & GetResString(, "Attitude")
                                    nRoll = Convert.ToInt32(sSplit(0)) / 1000 * 180 / Math.PI
                                    nPitch = Convert.ToInt32(sSplit(1)) / 1000 * 180 / Math.PI
                                    If IsNumeric(sSplit(2)) = True Then
                                        nYaw = Convert.ToInt32(sSplit(2)) / 1000 * 180 / Math.PI
                                    Else
                                        nYaw = 0
                                    End If
                                    bNewAttitude = True
                                Case "TG"
                                    lblGPSMessage.Text = "TG - " & GetResString(, "GPS_Data")
                                    nFix = 2 - Convert.ToInt32(sSplit(0))
                                    nLatitude = ConvertLatLongFormat(Convert.ToDouble(ConvertPeriodToLocal(sSplit(1))) * 180 / Math.PI, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                                    nLongitude = ConvertLatLongFormat(Convert.ToDouble(ConvertPeriodToLocal(sSplit(2))) * 180 / Math.PI, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                                    nGroundSpeed = ConvertSpeed(Convert.ToDouble(sSplit(3)) / 10, e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                    nHeading = Convert.ToDouble(sSplit(4)) / 100 * 180 / Math.PI
                                    nSats = Convert.ToInt32(sSplit(5))
                                    nAltitude = ConvertDistance(Convert.ToInt32(sSplit(6)), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                    bNewGPS = True
                                Case "TC"
                                    lblGPSMessage.Text = "TC - " & GetResString(, "Waypoint_Data")
                                    Select Case sSplit(0)
                                        Case "0"
                                            sMode = GetResString(, "Manual_Mode")
                                        Case "1"
                                            sMode = GetResString(, "Stabilized")
                                        Case "2"
                                            sMode = GetResString(, "Autonomous")
                                        Case "3"
                                            sMode = GetResString(, "Loiter")
                                        Case "4"
                                            sMode = GetResString(, "Return Home")
                                    End Select
                                    nWaypoint = Convert.ToInt32(sSplit(1))
                                    nWaypointAlt = ConvertDistance(Convert.ToInt32(sSplit(2)), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                    'Height above start ground
                                    'nAltitude = ConvertDistance(Convert.ToInt32(sSplit(6)), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                    If UBound(sSplit) >= 4 Then
                                        nBattery = Convert.ToInt32(sSplit(4)) / 10
                                    End If
                                    bNewWaypoint = True
                                Case "TR"
                                    lblGPSMessage.Text = "TR - " & GetResString(, "Sensors")
                                    nSensor(0) = GetServoValue(sSplit(0)) / 1000
                                    nSensor(1) = GetServoValue(sSplit(1)) / 1000
                                    nSensor(2) = GetServoValue(sSplit(2)) / 1000
                                    nSensor(3) = GetServoValue(sSplit(3)) / 1000 '* 180 / Math.PI
                                    nSensor(4) = GetServoValue(sSplit(4)) / 1000 '* 180 / Math.PI
                                    nSensor(5) = GetServoValue(sSplit(5)) / 1000 '* 180 / Math.PI
                                    bNewServo = True
                                Case "TT"
                                    lblGPSMessage.Text = "TT - " & GetResString(, "Servos")
                                    nServoInput(0) = GetServoValue(sSplit(0))
                                    If UBound(sSplit) >= 1 Then
                                        nServoInput(1) = GetServoValue(sSplit(1))
                                    End If
                                    If UBound(sSplit) >= 2 Then
                                        nServoInput(2) = GetServoValue(sSplit(2))
                                    End If
                                    If UBound(sSplit) >= 3 Then
                                        nServoInput(3) = GetServoValue(sSplit(3))
                                    End If
                                    If UBound(sSplit) >= 4 Then
                                        nServoInput(4) = GetServoValue(sSplit(4))
                                    End If
                                    If UBound(sSplit) >= 5 Then
                                        nServoInput(5) = GetServoValue(sSplit(5))
                                    End If
                                    If UBound(sSplit) >= 6 Then
                                        nServoInput(6) = GetServoValue(sSplit(6))
                                    End If
                                    If UBound(sSplit) >= 7 Then
                                        nServoInput(7) = GetServoValue(sSplit(7))
                                    End If
                                    bNewServo = True
                            End Select

                            'ATTOPILOT PARSE
                        Case cMessage.e_MessageType.e_MessageType_AttoPilot, cMessage.e_MessageType.e_MessageType_AttoSetParam, cMessage.e_MessageType.e_MessageType_AttoOk
                            lblGPSType.Text = "AttoPilot"
                            sSplit = Split(.Packet, ",")
                            Select Case UCase(sSplit(0))
                                Case "OK"
                                    Select Case sSplit(2)
                                        Case "D"
                                            LoadAttoParameterGrid()
                                        Case "Q"
                                            SetConfigDevice(e_ConfigDevice.e_ConfigDevice_AttoPilot, Convert.ToInt32(sSplit(1)), True)
                                            bWaitingAttoUpdate = False
                                    End Select
                                Case "D"
                                    For nCount = 0 To nParameterCount
                                        If sSplit(2) = aIDs(nCount).Substring(1) Then
                                            aValue(nCount) = sSplit(3)
                                            prgConfig.Value = prgConfig.Value + 1
                                            Exit For
                                        End If
                                    Next
                                Case "A1"
                                    lblGPSMessage.Text = "A1 - " & GetResString(, "Attitude Data")
                                    nRoll = -ConvertPeriodToLocal(sSplit(2))
                                    nPitch = -ConvertPeriodToLocal(sSplit(3))
                                    bNewAttitude = True
                                Case "A2"
                                    lblGPSMessage.Text = "A2 - " & GetResString(, "GPS_Data")
                                    nLatitude = ConvertLatLongFormat(Convert.ToDouble(ConvertPeriodToLocal(sSplit(2))), e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                                    nLongitude = ConvertLatLongFormat(Convert.ToDouble(ConvertPeriodToLocal(sSplit(3))), e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                                    nHeading = Convert.ToSingle(ConvertPeriodToLocal(sSplit(4)))
                                    nYaw = nHeading
                                    Select Case sSplit(5)
                                        Case "1"
                                            sMode = GetResString(, "Manual Mode")
                                            'If tmrComPort.Enabled = True And chkControlAttoAtuoMode.Checked <> False Then
                                            '    chkControlAttoAtuoMode.Checked = False
                                            'End If
                                        Case "2"
                                            sMode = GetResString(, "Assisted RC")
                                            'If tmrComPort.Enabled = True And chkControlAttoAtuoMode.Checked <> False Then
                                            '    chkControlAttoAtuoMode.Checked = False
                                            'End If
                                        Case "3"
                                            sMode = GetResString(, "Highly Assisted")
                                            'If tmrComPort.Enabled = True And chkControlAttoAtuoMode.Checked <> False Then
                                            '    chkControlAttoAtuoMode.Checked = False
                                            'End If
                                        Case "4"
                                            sMode = GetResString(, "Autonomous")
                                            'If tmrComPort.Enabled = True And chkControlAttoAtuoMode.Checked <> True Then
                                            '    chkControlAttoAtuoMode.Checked = True
                                            'End If
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
                                Case "A4"
                                    lblGPSMessage.Text = "A4 - Sats/Servo"
                                    dGPSDate = GetNMEADate(sSplit(2))
                                    dGPSTime = GetNMEATime(sSplit(3))
                                    nSats = Convert.ToInt32(sSplit(4))
                                    nFix = Convert.ToInt32(sSplit(5))
                                    If nFix = 6 Then
                                        nFix = 0
                                    End If
                                    nHDOP = Convert.ToSingle(ConvertPeriodToLocal(sSplit(6)))
                                    nServoOutput(0) = Convert.ToInt32(sSplit(7))
                                    nServoOutput(1) = Convert.ToInt32(sSplit(8))
                                    nServoOutput(2) = Convert.ToInt32(sSplit(9))
                                    nServoOutput(3) = Convert.ToInt32(sSplit(10))
                                    nServoOutput(4) = Convert.ToInt32(sSplit(11))
                                    nServoOutput(5) = Convert.ToInt32(sSplit(12))
                                    If UBound(sSplit) >= 13 Then
                                        nServoOutput(6) = Convert.ToInt32(sSplit(13))
                                    End If
                                    bNewGPS = True
                                    bNewServo = True
                                    bNewDateTime = True

                                    If nThrottleChannel > 0 Then
                                        If nServoOutput(nThrottleChannel - 1) <> 0 Then
                                            nThrottle = (nServoOutput(nThrottleChannel - 1) - tbarServo1.Minimum) / (tbarServo1.Maximum - tbarServo1.Minimum)
                                        Else
                                            nThrottle = 0
                                        End If
                                        bNewWaypoint = True
                                    End If
                            End Select

                        Case cMessage.e_MessageType.e_MessageType_AttoPilot18
                            lblGPSType.Text = "AttoPilot v1.8"
                            sSplit = Split(.Packet, ",")
                            Select Case UCase(sSplit(0))
                                Case "ATTO"
                                    lblGPSMessage.Text = "ATTO - " & GetResString(, "Attitude Data")
                                    sModeNumber = sSplit(1)
                                    nWaypoint = sSplit(5)
                                    nDistance = ConvertDistance(ConvertPeriodToLocal(sSplit(8)), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                    nServoOutput(0) = sSplit(9)
                                    nServoOutput(1) = sSplit(10)
                                    nServoOutput(2) = sSplit(11)
                                    nServoOutput(3) = sSplit(12)
                                    nServoOutput(4) = sSplit(13)
                                    nServoOutput(5) = sSplit(14)
                                    nServoInput(0) = sSplit(16)
                                    nBattery = ConvertPeriodToLocal(sSplit(24))
                                    nAmperage = ConvertPeriodToLocal(sSplit(25))
                                    nMAH = ConvertPeriodToLocal(sSplit(27))
                                    nAirSpeed = ConvertSpeed(ConvertPeriodToLocal(sSplit(29)), e_SpeedFormat.e_SpeedFormat_KPH, eSpeedUnits)
                                    nWaypointAlt = ConvertDistance(ConvertPeriodToLocal(sSplit(32)), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                    bNewServo = True

                                    If nThrottleChannel > 0 Then
                                        If nServoOutput(nThrottleChannel - 1) <> 0 Then
                                            nThrottle = (nServoOutput(nThrottleChannel - 1) - tbarServo1.Minimum) / (tbarServo1.Maximum - tbarServo1.Minimum)
                                        Else
                                            nThrottle = 0
                                        End If
                                    End If
                                    bNewWaypoint = True
                                Case "GPS"
                                    lblGPSMessage.Text = "GPS - " & GetResString(, "GPS_Data")
                                    dGPSDate = GetNMEADate(sSplit(1))
                                    dGPSTime = GetNMEATime(ConvertPeriodToLocal(sSplit(2)))
                                    nLatitude = ConvertLatLongFormat(Convert.ToDouble(ConvertPeriodToLocal(sSplit(3))), e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                                    nLongitude = ConvertLatLongFormat(Convert.ToDouble(ConvertPeriodToLocal(sSplit(4))), e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                                    nAltitude = ConvertDistance(ConvertPeriodToLocal(sSplit(5)), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                    nFix = Convert.ToInt32(sSplit(6))
                                    If nFix = 6 Then
                                        nFix = 0
                                    End If
                                    nSats = Convert.ToInt32(sSplit(7))
                                    nGroundSpeed = ConvertSpeed(ConvertPeriodToLocal(sSplit(8)), e_SpeedFormat.e_SpeedFormat_KPH, eSpeedUnits)
                                    nHeading = Convert.ToSingle(ConvertPeriodToLocal(sSplit(9)))
                                    nYaw = nHeading
                                    nRoll = Convert.ToSingle(ConvertPeriodToLocal(sSplit(19)))
                                    nPitch = Convert.ToSingle(ConvertPeriodToLocal(sSplit(20)))
                                    bNewAttitude = True
                                    bNewGPS = True
                                    bNewDateTime = True
                            End Select

                        Case cMessage.e_MessageType.e_MessageType_NMEA
                            lblGPSType.Text = "NMEA"
                            sSplit = Split(.Packet, ",")
                            lblGPSMessage.Text = UCase(sSplit(0))
                            Try
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
                                        dGPSDate = GetNMEADate(sSplit(9).PadLeft(6, "0"))
                                        nYaw = nHeading
                                        bNewGPS = True
                                        bNewDateTime = True
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
                                        dGPSTime = GetNMEATime(sSplit(5))
                                        bNewGPS = True
                                        bNewDateTime = True
                                    Case "GPVTG"
                                        nHeading = Convert.ToSingle(ConvertPeriodToLocal(sSplit(1)))
                                        nYaw = nHeading
                                        nGroundSpeed = ConvertSpeed(sSplit(5), e_SpeedFormat.e_SpeedFormat_Knots, eSpeedUnits)
                                        bNewGPS = True
                                    Case "GPZDA"
                                        dGPSTime = GetNMEATime(sSplit(1))
                                        dGPSDate = GetNMEADate(sSplit(2) & sSplit(3) & sSplit(4))
                                        bNewDateTime = True
                                End Select
                            Catch
                            End Try

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

                            WebBrowser1.Invoke(New MyDelegate(AddressOf AddWaypoint))

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
                            nLatitude = ConvertLatLongFormat(ConvertHexToDec(Mid(.Packet, 2, 4), True) / 1000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                            nLongitude = ConvertLatLongFormat(ConvertHexToDec(Mid(.Packet, 6, 4), True) / 1000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                            nAltitude = ConvertDistance(ConvertHexToDec(Mid(.Packet, 10, 4), True) / 100, e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                            nGroundSpeed = ConvertSpeed(ConvertHexToDec(Mid(.Packet, 14, 4), True) / 100, e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                            nHeading = ConvertHexToDec(Mid(.Packet, 18, 4), True) / 100
                            nYaw = nHeading
                            nSats = ConvertHexToDec(Mid(.Packet, 22, 1), False)
                            nFix = ConvertHexToDec(Mid(.Packet, 23, 1), False) - 1
                            dGPSDate = GetMediaTekv16Date(ConvertHexToDec(Mid(.Packet, 24, 4), True))
                            dGPSTime = GetMediaTekv16Time(Convert.ToInt32(ConvertHexToDec(Mid(.Packet, 28, 4), True)))
                            nHDOP = ConvertHexToDec(Mid(.Packet, 32, 2), True) / 100
                            bNewGPS = True
                            bNewDateTime = True

                        Case cMessage.e_MessageType.e_MessageType_FY21AP
                            lblGPSType.Text = "FY21AP II"
                            Select Case .ID
                                Case 241 'Telemetry data set1
                                    lblGPSMessage.Text = GetResString(, "Telemetry GPS")
                                    nFix = IIf(Asc(Mid(.Packet, 3, 1)) And &H40 = 64, 1, 0)
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
                                    nLatitude = ConvertLatLongFormat(ConvertLatLongFY21AP(Mid(.Packet, 6, 4)), e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                                    nLongitude = ConvertLatLongFormat(ConvertLatLongFY21AP(Mid(.Packet, 10, 4)), e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                                    nHeading = ConvertHexToDecFY21AP(Mid(.Packet, 14, 2), False) * 0.01
                                    If nHeading < 0 Then
                                        nHeading = nHeading + 360
                                    End If
                                    nYaw = nHeading
                                    nGroundSpeed = ConvertSpeed(ConvertHexToDecFY21AP(Mid(.Packet, 16, 2)) * 0.1, e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                    'nAltitude = ConvertHexToDecFY21AP(Mid(.Packet, 18, 2), False)
                                    'If nAltitude > 60000 Then
                                    '    nAltitude = (60000 - nAltitude) * 0.1
                                    'Else
                                    '    nAltitude = nAltitude * 0.1
                                    'End If
                                    'nAltitude = ConvertDistance(nAltitude, e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)

                                    nAltitude = Asc(Mid(.Packet, 18, 1)) * 256 + Asc(Mid(.Packet, 19, 1))
                                    'nAltitude = ConvertHexToDecFY21AP(Mid(.Packet, 18, 2), False)
                                    If nAltitude > 60000 Then
                                        nAltitude = (60000 - nAltitude) * 0.1
                                    Else
                                        nAltitude = nAltitude * 0.1
                                    End If
                                    nAltitude = ConvertDistance(nAltitude, e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)

                                    nDistance = ConvertDistance(ConvertHexToDecFY21AP(Mid(.Packet, 24, 2)) * 0.1, e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                    bNewGPS = True

                                Case 242 'Telemetry data set2
                                    lblGPSMessage.Text = GetResString(, "Waypoint Data")
                                    nWaypoint = Asc(Mid(.Packet, 3, 1))
                                    nWaypointAlt = ConvertHexToDecFY21AP(Mid(.Packet, 5, 2))
                                    dGPSTime = GetNMEATime(Asc(Mid(.Packet, 29, 1)).ToString("00") & Asc(Mid(.Packet, 30, 1)).ToString("00") & Asc(Mid(.Packet, 31, 1)).ToString("00"))
                                    dGPSDate = GetNMEADate(Asc(Mid(.Packet, 33, 1)).ToString("00") & Asc(Mid(.Packet, 32, 1)).ToString("00") & Asc(Mid(.Packet, 34, 1)).ToString("00"))
                                    bNewWaypoint = True
                                    bNewDateTime = True

                                Case 243 'Telemetry data set3
                                    lblGPSMessage.Text = GetResString(, "Attitude Data")
                                    nPitch = -ConvertHexToDecFY21AP(Mid(.Packet, 3, 2)) / 10
                                    nRoll = ConvertHexToDecFY21AP(Mid(.Packet, 5, 2)) / 10
                                    nServoInput(0) = ConvertHexToDecFY21AP(Mid(.Packet, 7, 2))
                                    nServoInput(1) = ConvertHexToDecFY21AP(Mid(.Packet, 9, 2))
                                    nServoInput(2) = ConvertHexToDecFY21AP(Mid(.Packet, 11, 2))
                                    nServoInput(3) = ConvertHexToDecFY21AP(Mid(.Packet, 13, 2))
                                    'nServoInput(4) = ConvertHexToDecFY21AP(Mid(.Packet, 15, 2))
                                    'nServoInput(5) = ConvertHexToDecFY21AP(Mid(.Packet, 17, 2))
                                    'nServoInput(6) = ConvertHexToDecFY21AP(Mid(.Packet, 19, 2))
                                    'nServoInput(7) = ConvertHexToDecFY21AP(Mid(.Packet, 21, 2))
                                    bNewServo = True
                                    bNewAttitude = True
                            End Select

                        Case cMessage.e_MessageType.e_MessageType_uBlox
                            lblGPSType.Text = GetResString(, "uBlox Binary")
                            Select Case Asc(Mid(.Packet, 2, 1))
                                Case 2 'NAV_POSLLH
                                    lblGPSMessage.Text = "NAV_POSLLH"
                                    dGPSTime = GetuBloxTime(ConvertHexToDec(Mid(.Packet, 5, 4)) / 1000)
                                    nLongitude = ConvertLatLongFormat(ConvertHexToDec(Mid(.Packet, 9, 4)) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                                    nLatitude = ConvertLatLongFormat(ConvertHexToDec(Mid(.Packet, 13, 4)) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                                    nAltitude = ConvertDistance(ConvertHexToDec(Mid(.Packet, 17, 4)) / 1000, e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                    bNewGPS = True
                                    bNewDateTime = True
                                Case 18 'NAV_VELNED
                                    lblGPSMessage.Text = "NAV_VELNED"
                                    dGPSTime = GetuBloxTime(ConvertHexToDec(Mid(.Packet, 5, 4)) / 1000)
                                    nGroundSpeed = (ConvertSpeed(ConvertHexToDec(Mid(.Packet, 25, 4)) / 100, e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)).ToString("#.0")
                                    nHeading = (ConvertHexToDec(Mid(.Packet, 29, 4)) / 100000).ToString("#.0")
                                    'Debug.Print("uBlox Heading = " & nHeading)
                                    nYaw = nHeading
                                    bNewGPS = True
                                    bNewDateTime = True
                                Case 3 'NAV_STATUS
                                    lblGPSMessage.Text = "NAV_STATUS"
                                    dGPSTime = GetuBloxTime(ConvertHexToDec(Mid(.Packet, 5, 4)) / 1000)
                                    nFix = ConvertHexToDec(Mid(.Packet, 9, 1))
                                    bNewGPS = True
                                    bNewDateTime = True
                                Case 6 'NAV_SOL
                                    lblGPSMessage.Text = "NAV_SOL"
                                    dGPSTime = GetuBloxTime(ConvertHexToDec(Mid(.Packet, 5, 4)) / 1000)
                                    dGPSDate = GetuBloxDate(ConvertHexToDec(Mid(.Packet, 13, 2)))
                                    nSats = ConvertHexToDec(Mid(.Packet, 52, 1))
                                    bNewGPS = True
                                    bNewDateTime = True
                                Case 4 'NAV_DOP
                                    lblGPSMessage.Text = "NAV_DOP"
                                    dGPSTime = GetuBloxTime(ConvertHexToDec(Mid(.Packet, 5, 4)) / 1000)
                                    nHDOP = ConvertHexToDec(Mid(.Packet, 17, 2)) / 100
                                    bNewGPS = True
                                    bNewDateTime = True
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
                                                nRoll = -Convert.ToSingle(ConvertPeriodToLocal(sValues(1)))
                                                bNewAttitude = True
                                            Case "PCH"
                                                nPitch = -Convert.ToSingle(ConvertPeriodToLocal(sValues(1)))
                                                bNewAttitude = True
                                            Case "YAW"
                                                nYaw = -GetHeading(Convert.ToSingle(ConvertPeriodToLocal(sValues(1))))
                                                bNewAttitude = True
                                            Case "CRS", "COG"
                                                nHeading = Convert.ToSingle(ConvertPeriodToLocal(sValues(1)))
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
                                                nGroundSpeed = ConvertSpeed(ConvertPeriodToLocal(sValues(1)), e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                                bNewGPS = True
                                            Case "ASP"
                                                nAirSpeed = ConvertSpeed(ConvertPeriodToLocal(sValues(1)), e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                                bNewGPS = True
                                            Case "FIX", "LOC"
                                                nFix = System.Math.Abs(Convert.ToInt32(sValues(1)) - 1)
                                                bNewGPS = True
                                            Case "ALT"
                                                nAltitude = ConvertDistance(ConvertPeriodToLocal(sValues(1)), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                                bNewGPS = True
                                            Case "SAT"
                                                nSats = Convert.ToInt32(sValues(1))
                                                bNewGPS = True
                                            Case "BTV"
                                                nBattery = (Convert.ToSingle(ConvertPeriodToLocal(sValues(1)))).ToString("#.00")
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
                                                nThrottle = Convert.ToSingle(ConvertPeriodToLocal(sValues(1))) / 100
                                                bNewWaypoint = True
                                            Case "AMP"
                                                nAmperage = Convert.ToSingle(ConvertPeriodToLocal(sValues(1))) / 100
                                                bNewWaypoint = True
                                            Case "MAH"
                                                nMAH = Convert.ToInt32(sValues(1))
                                                bNewWaypoint = True
                                            Case "DST"
                                                nDistance = ConvertDistance(sValues(1), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                                bNewWaypoint = True
                                            Case "ALH"
                                                nWaypointAlt = ConvertDistance(ConvertPeriodToLocal(sValues(1)), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                                bNewWaypoint = True

                                            Case "TOW"
                                                dGPSTime = GetuBloxTime(Convert.ToDouble(sValues(1) / 1000))
                                                bNewDateTime = True
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
                                    Select Case UCase(Microsoft.VisualBasic.Left(sSplit(nCount), 5))
                                        Case "ORIGN"
                                            sTemp = Mid(sSplit(nCount), 6)
                                            nLatitude = ConvertLatLongFormat(Convert.ToDouble(sTemp) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                                        Case "ORIGE"
                                            sTemp = Mid(sSplit(nCount), 6)
                                            nLongitude = ConvertLatLongFormat(Convert.ToDouble(sTemp) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                                        Case "ORIGA"
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
                                For nCount = 0 To UBound(sSplit)
                                    If InStr(sSplit(nCount), "p1i") <> 0 Then
                                        sSplit(nCount) = Mid(sSplit(nCount), InStr(sSplit(nCount), "p1i"))
                                    End If
                                    'Debug.Print(Microsoft.VisualBasic.Left(sSplit(nCount), 1))
                                    Select Case Microsoft.VisualBasic.Left(sSplit(nCount), 1)
                                        Case "T"
                                            sTemp = Mid(sSplit(nCount), 2)
                                            dGPSTime = GetuBloxTime(Convert.ToDouble(Mid(sSplit(nCount), 2)) / 1000)
                                        Case "S"
                                            nFix = Convert.ToInt32(Mid(sSplit(nCount), 3, 1) = "1")
                                            'If Mid(sSplit(nCount), 4, 1) = "1" Then
                                            '    sMode = GetResString(, "Manual_Mode")
                                            'ElseIf Mid(sSplit(nCount), 4, 1) = "2" Then
                                            '    sMode = GetResString(, "Stabilized")
                                            'ElseIf Mid(sSplit(nCount), 4, 1) = "3" Then
                                            '    sMode = GetResString(, "Autonomous")
                                            'Else
                                            '    sMode = GetResString(, "Return Home")
                                            'End If
                                            If Mid(sSplit(nCount), 4, 1) = "1" Then
                                                sMode = GetResString(, "Autonomous")
                                            Else
                                                sMode = GetResString(, "Manual Mode")
                                            End If

                                        Case "N"
                                            sTemp = Mid(sSplit(nCount), 2)
                                            nLatitude = ConvertLatLongFormat(Convert.ToDouble(sTemp) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                                        Case "E"
                                            sTemp = Mid(sSplit(nCount), 2)
                                            nLongitude = ConvertLatLongFormat(Convert.ToDouble(sTemp) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                                        Case "A"
                                            sTemp = Mid(sSplit(nCount), 2)
                                            nAltitude = ConvertDistance(Convert.ToDouble(sTemp) / 100, e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                        Case "W"
                                            sTemp = Mid(sSplit(nCount), 2)
                                            nWaypoint = Convert.ToInt32(sTemp)
                                        Case "a"
                                            If Microsoft.VisualBasic.Left(sSplit(nCount), 2) = "as" Then
                                                sTemp = Mid(sSplit(nCount), 3)
                                                If sTemp <> "" And sTemp <> "0" Then
                                                    nAirSpeed = ConvertSpeed(Convert.ToSingle(sTemp) / 100, e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                                Else
                                                    nAirSpeed = 0
                                                End If
                                            End If
                                        Case "b"
                                            If Microsoft.VisualBasic.Left(sSplit(nCount), 3) = "bmv" Then
                                                sTemp = Mid(sSplit(nCount), 4)
                                                If sTemp <> "" And sTemp <> "0" Then
                                                    nBattery = (Convert.ToSingle(sTemp) / 1000).ToString("#.00")
                                                Else
                                                    nBattery = 0
                                                End If
                                            Else
                                                sTemp = Mid(sSplit(nCount), 2)
                                                nYawComponent1 = Convert.ToSingle(sTemp)
                                            End If
                                        Case "e"
                                            sTemp = Mid(sSplit(nCount), 2)
                                            nYaw = (System.Math.Atan2(-nYawComponent1, Convert.ToSingle(sTemp)) / (2 * pi)) * 360
                                        Case "f"
                                            If Microsoft.VisualBasic.Left(sSplit(nCount), 3) = "fgs" Then
                                                'Debug.Print(sSplit(nCount))
                                            End If
                                        Case "g"
                                            sTemp = Mid(sSplit(nCount), 2)
                                            nRoll = (System.Math.Asin(sTemp / 16384.0) / (2 * pi)) * 360
                                        Case "h"
                                            If Microsoft.VisualBasic.Left(sSplit(nCount), 2) = "hd" Then
                                                sTemp = Mid(sSplit(nCount), 3)
                                                If sTemp <> "" And sTemp <> "0" Then
                                                    nHDOP = (Convert.ToSingle(sTemp) / 5).ToString("#.00")
                                                Else
                                                    nHDOP = 0
                                                End If
                                            Else
                                                sTemp = Mid(sSplit(nCount), 2)
                                                nPitch = (System.Math.Asin(sTemp / 16384.0) / (2 * pi)) * 360
                                            End If
                                        Case "i"
                                            If Microsoft.VisualBasic.Left(sSplit(nCount), 3) <> "imu" And Microsoft.VisualBasic.Left(sSplit(nCount), 3) <> "imx" And Microsoft.VisualBasic.Left(sSplit(nCount), 3) <> "imy" And Microsoft.VisualBasic.Left(sSplit(nCount), 3) <> "imz" Then
                                                sTemp = Mid(sSplit(nCount), 2)
                                                If Convert.ToSingle(sTemp) < 0 Then
                                                    nRoll = 180 - nRoll
                                                End If
                                            End If
                                        Case "c"
                                            If Microsoft.VisualBasic.Left(sSplit(nCount), 3) <> "cpu" Then
                                                sTemp = Mid(sSplit(nCount), 2)
                                                nHeading = Convert.ToSingle(sTemp) / 100
                                                'Debug.Print("Heading = " & nHeading)
                                                If nHeading < 0 Then
                                                    nHeading = nHeading + 360
                                                End If
                                            End If
                                        Case "s"
                                            If Microsoft.VisualBasic.Left(sSplit(nCount), 3) = "svs" Then
                                                sTemp = Mid(sSplit(nCount), 4)
                                                If sTemp <> "" Then
                                                    nSats = Convert.ToInt32(sTemp)
                                                Else
                                                    nSats = 0
                                                End If
                                            ElseIf Microsoft.VisualBasic.Left(sSplit(nCount), 3) = "stk" Then
                                            Else
                                                sTemp = Mid(sSplit(nCount), 2)
                                                nGroundSpeed = ConvertSpeed(Convert.ToSingle(sTemp) / 100, e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                            End If
                                        Case "p"
                                            Select Case Mid(sSplit(nCount), 2, 2)
                                                Case "1i"
                                                    sTemp = Mid(sSplit(nCount), 4)
                                                    nServoInput(0) = GetServoValue(sTemp) / 2
                                                Case "2i"
                                                    sTemp = Mid(sSplit(nCount), 4)
                                                    nServoInput(1) = GetServoValue(sTemp) / 2
                                                Case "3i"
                                                    sTemp = Mid(sSplit(nCount), 4)
                                                    nServoInput(2) = GetServoValue(sTemp) / 2
                                                Case "4i"
                                                    sTemp = Mid(sSplit(nCount), 4)
                                                    nServoInput(3) = GetServoValue(sTemp) / 2
                                                Case "5i"
                                                    sTemp = Mid(sSplit(nCount), 4)
                                                    nServoInput(4) = GetServoValue(sTemp) / 2
                                                Case "6i"
                                                    sTemp = Mid(sSplit(nCount), 4)
                                                    nServoInput(5) = GetServoValue(sTemp) / 2
                                                Case "7i"
                                                    sTemp = Mid(sSplit(nCount), 4)
                                                    nServoInput(6) = GetServoValue(sTemp) / 2
                                                Case "8i"
                                                    sTemp = Mid(sSplit(nCount), 4)
                                                    nServoInput(7) = GetServoValue(sTemp) / 2
                                                Case "1o"
                                                    sTemp = Mid(sSplit(nCount), 4)
                                                    nServoOutput(0) = GetServoValue(sTemp) / 2
                                                Case "2o"
                                                    sTemp = Mid(sSplit(nCount), 4)
                                                    nServoOutput(1) = GetServoValue(sTemp) / 2
                                                Case "3o"
                                                    sTemp = Mid(sSplit(nCount), 4)
                                                    nServoOutput(2) = GetServoValue(sTemp) / 2
                                                Case "4o"
                                                    sTemp = Mid(sSplit(nCount), 4)
                                                    nServoOutput(3) = GetServoValue(sTemp) / 2
                                                Case "5o"
                                                    sTemp = Mid(sSplit(nCount), 4)
                                                    nServoOutput(4) = GetServoValue(sTemp) / 2
                                                Case "6o"
                                                    sTemp = Mid(sSplit(nCount), 4)
                                                    nServoOutput(5) = GetServoValue(sTemp) / 2
                                                Case "7o"
                                                    sTemp = Mid(sSplit(nCount), 4)
                                                    nServoOutput(6) = GetServoValue(sTemp) / 2
                                                Case "8o"
                                                    sTemp = Mid(sSplit(nCount), 4)
                                                    nServoOutput(7) = GetServoValue(sTemp) / 2
                                            End Select
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
                                bNewServo = True
                                bNewDateTime = True
                            Catch e2 As Exception
                                Debug.Print("Invalid UDB Message= " & sSplit(nCount) & vbCrLf & e2.Message)
                            End Try

                        Case cMessage.e_MessageType.e_MessageType_SiRF
                            lblGPSType.Text = "SiRF"
                            Select Case .ID
                                Case 91
                                    lblGPSMessage.Text = GetResString(, "Geonavigation Data")
                                    nFix = ConvertHexToDec(Mid(.Packet, 4, 1)) And 3
                                    dGPSDate = GetNMEADate(Asc(Mid(.Packet, 15, 1)).ToString("00") & Asc(Mid(.Packet, 14, 1)).ToString("00") & Microsoft.VisualBasic.Right(ConvertHexToDec(Mid(.Packet, 12, 2), False), 2))
                                    dGPSTime = GetNMEATime(Asc(Mid(.Packet, 16, 1)).ToString("00") & Asc(Mid(.Packet, 17, 1)).ToString("00") & Asc(Mid(.Packet, 18, 1)).ToString("00"))
                                    nLatitude = ConvertLatLongFormat(ConvertHexToDec(Mid(.Packet, 24, 4), False) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, True)
                                    nLongitude = ConvertLatLongFormat(ConvertHexToDec(Mid(.Packet, 28, 4), False) / 10000000, e_LatLongFormat.e_LatLongFormat_DD_DDDDDD, eOutputLatLongFormat, False)
                                    nAltitude = ConvertDistance(ConvertHexToDec(Mid(.Packet, 36, 4), False) / 100, e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                    nGroundSpeed = ConvertSpeed(ConvertHexToDec(Mid(.Packet, 41, 2), False) / 100, e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                    nHeading = ConvertHexToDec(Mid(.Packet, 43, 2), False, False) / 100
                                    nYaw = nHeading
                                    nSats = ConvertHexToDec(Mid(.Packet, 89, 1))
                                    nHDOP = ConvertHexToDec(Mid(.Packet, 90, 1)) / 5
                                    bNewGPS = True
                                    bNewDateTime = True
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
                                        dGPSDate = GetNMEADate(ConvertHexToDec(Mid(.Packet, 22, 4)).PadLeft(6, "0"))
                                        dGPSTime = GetNMEATime(ConvertHexToDec(Mid(.Packet, 26, 4)).PadLeft(6, "0"))
                                        nSats = Asc(Mid(.Packet, 30))
                                        nFix = Asc(Mid(.Packet, 31))
                                    End If
                                    bNewGPS = True

                                    'System.Diagnostics.Debug.Print("Lat=" & sLatitude & ",Long=" & sLongitude)
                            End Select

                            'http://pixhawk.ethz.ch/wiki/mavlink/
                            'MAVLINK PARSE
                        Case cMessage.e_MessageType.e_MessageType_MAV
                            lblGPSType.Text = "MAVlink"
                            'Debug.Print("Message ID=" & Asc(Mid(.Packet, 6, 1)) & ",Length=" & Asc(Mid(.Packet, 2, 1))) '& ",Packet=" & .VisibleSentence)
                            nConfigVehicle = Asc(Mid(.Packet, 4, 1))
                            SetConfigDevice(e_ConfigDevice.e_ConfigDevice_MAVlink, nConfigVehicle, True)
                            bWaitingMavlinkUpdate = False
                            Select Case .ID
                                Case 0 'HEARTBEAT 
                                    lblGPSMessage.Text = "Heartbeat"
                                Case 2 'SYSTEM_TIME 
                                    lblGPSMessage.Text = "Date/Time"
                                    dGPSDate = GetMAVlinkDate(ConvertMavlinkToLong(Mid(.Packet, 7, 8)))
                                    dGPSTime = GetMAVlinkTime(ConvertMavlinkToLong(Mid(.Packet, 7, 8)))
                                    bNewDateTime = True
                                Case 4 'SYSTEM_TIME_UTC
                                    lblGPSMessage.Text = "UTC Date/Time"
                                    dGPSDate = GetNMEADate(ConvertMavlinkToInteger32(Mid(.Packet, 7, 4).ToString))
                                    dGPSTime = GetNMEATime(ConvertMavlinkToInteger32(Mid(.Packet, 11, 4).ToString))
                                    bNewDateTime = True
                                Case 22 'PARAM_VALUE 
                                    'Async Parameters
                                    dLastMavlinkCommandTime = Now.Ticks
                                    lblGPSMessage.Text = "Parameter Value"
                                    nParameterCount = ConvertMavlinkToInteger(Mid(.Packet, 26, 2), True) - 1
                                    If UBound(aValue) <> nParameterCount Then
                                        ReDim aIDs(0 To nParameterCount)
                                        ReDim aName(0 To nParameterCount)
                                        ReDim aMin(0 To nParameterCount)
                                        ReDim aMax(0 To nParameterCount)
                                        ReDim aValue(0 To nParameterCount)
                                        ReDim aVisible(0 To nParameterCount)
                                        ReDim aDefault(0 To nParameterCount)
                                        ReDim aComments(0 To nParameterCount)
                                        ReDim aChanged(0 To nParameterCount)
                                        ReDim aMultiplier(0 To nParameterCount)
                                    End If
                                    If ConvertMavlinkToInteger(Mid(.Packet, 28, 2), True) <> nParameterCurrentIndex + 1 And nParameterCurrentIndex <> 0 Then
                                        Debug.Print("Missing Values!!!!")
                                    End If
                                    nParameterCurrentIndex = ConvertMavlinkToInteger(Mid(.Packet, 28, 2), True)
                                    If nParameterCurrentIndex <> -1 Then
                                        aName(nParameterCurrentIndex) = Mid(.Packet, 7, 15)
                                        prgConfig.Maximum = nParameterCount
                                        prgConfig.Value = nParameterCurrentIndex
                                        If InStr(aName(nParameterCurrentIndex), Chr(0)) <> 0 Then
                                            aName(nParameterCurrentIndex) = Mid(aName(nParameterCurrentIndex), 1, InStr(aName(nParameterCurrentIndex), Chr(0)) - 1)
                                        End If
                                        SetConfigStatus("Reading " & aName(nParameterCurrentIndex))
                                        aValue(nParameterCurrentIndex) = ConvertMavlinkToSingle(Mid(.Packet, 22, 4))

                                        Select Case aName(nParameterCurrentIndex)
                                            Case "THROTTLE_MAX"
                                                cJoystick(1).UpperEndPoint = 100 * (aValue(nParameterCurrentIndex) - 1500) / 600
                                            Case "THROTTLE_MIN"
                                                cJoystick(1).LowerEndPoint = 100 * (aValue(nParameterCurrentIndex) - 1500) / 600
                                            Case "THROTTLE_TRIM"
                                                cJoystick(1).SubTrim = (aValue(nParameterCurrentIndex) * 32767 / 1500) - 32767

                                            Case "PITCH_MAX"
                                                cJoystick(2).UpperEndPoint = 100 * (aValue(nParameterCurrentIndex) - 1500) / 600
                                            Case "PITCH_MIN"
                                                cJoystick(2).LowerEndPoint = 100 * (aValue(nParameterCurrentIndex) - 1500) / 600
                                            Case "PITCH_TRIM"
                                                cJoystick(2).SubTrim = (aValue(nParameterCurrentIndex) * 32767 / 1500) - 32767

                                            Case "ROLL_MAX"
                                                cJoystick(3).UpperEndPoint = 100 * (aValue(nParameterCurrentIndex) - 1500) / 600
                                            Case "ROLL_MIN"
                                                cJoystick(3).LowerEndPoint = 100 * (aValue(nParameterCurrentIndex) - 1500) / 600
                                            Case "ROLL_TRIM"
                                                cJoystick(3).SubTrim = (aValue(nParameterCurrentIndex) * 32767 / 1500) - 32767

                                            Case "YAW_MAX"
                                                cJoystick(4).UpperEndPoint = 100 * (aValue(nParameterCurrentIndex) - 1500) / 600
                                            Case "YAW_MIN"
                                                cJoystick(4).LowerEndPoint = 100 * (aValue(nParameterCurrentIndex) - 1500) / 600
                                            Case "YAW_TRIM"
                                                cJoystick(4).SubTrim = (aValue(nParameterCurrentIndex) * 32767 / 1500) - 32767
                                        End Select
                                        '                                    Debug.Print("Parsing Parameter #" & nParameterCurrentIndex & ",Name=" & aName(nParameterCurrentIndex) & ",Value=" & aValue(nParameterCurrentIndex))
                                    End If

                                    If nParameterCurrentIndex = nParameterCount Or (bWaitingMavlinkWrite = False And nParameterCurrentIndex <> -1) Then
                                        SetConfigStatus("Parameter read or write complete")
                                        If eNewDeviceBootState = e_NewDevice_BootState.e_NewDevice_BootState_RequestingParameters Then
                                            eNewDeviceBootState = e_NewDevice_BootState.e_NewDevice_BootState_ParametersComplete
                                        End If
                                        If bWaitingMavlinkWrite = False Then
                                            LoadMavlinkParameterGrid(aName(nParameterCurrentIndex))
                                        Else
                                            LoadMavlinkParameterGrid()
                                        End If
                                        bWaitingMavlinkWrite = False
                                    End If
                                Case 27 'GPS_STATUS
                                    lblGPSMessage.Text = GetResString(, "GPS Status")
                                    nSats = Asc(Mid(.Packet, 7, 1))
                                    bNewGPS = True
                                Case 28 'RAW_IMU 
                                    lblGPSMessage.Text = GetResString(, "Raw IMU")
                                    Try
                                        dGPSDate = GetMAVlinkDate(ConvertMavlinkToLong(Mid(.Packet, 7, 8)))
                                        dGPSTime = GetMAVlinkTime(ConvertMavlinkToLong(Mid(.Packet, 7, 8)))
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
                                    bNewServo = True
                                    bNewDateTime = True
                                Case 29 'RAW_PRESSURE 
                                Case 30 'ATTITUDE 
                                    lblGPSMessage.Text = GetResString(, "Attitude")
                                    dGPSDate = GetMAVlinkDate(ConvertMavlinkToLong(Mid(.Packet, 7, 8)))
                                    dGPSTime = GetMAVlinkTime(ConvertMavlinkToLong(Mid(.Packet, 7, 8)))
                                    nRoll = -ConvertMavlinkToSingle(Mid(.Packet, 15, 4)) * 180 / Math.PI
                                    nPitch = -ConvertMavlinkToSingle(Mid(.Packet, 19, 4)) * 180 / Math.PI
                                    nYaw = ConvertMavlinkToSingle(Mid(.Packet, 23, 4)) * 180 / Math.PI
                                    bNewAttitude = True
                                    bNewDateTime = True
                                Case 32 'GPS_RAW
                                    lblGPSMessage.Text = GetResString(, "GPS Raw")
                                    dGPSDate = GetMAVlinkDate(ConvertMavlinkToLong(Mid(.Packet, 7, 8)))
                                    dGPSTime = GetMAVlinkTime(ConvertMavlinkToLong(Mid(.Packet, 7, 8)))
                                    nFix = Asc(Mid(.Packet, 15, 1)) - 1
                                    nLatitude = ConvertMavlinkToSingle(Mid(.Packet, 16, 4))
                                    nLongitude = ConvertMavlinkToSingle(Mid(.Packet, 20, 4))
                                    nAltitude = ConvertDistance(ConvertMavlinkToSingle(Mid(.Packet, 24, 4)), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                    nHDOP = ConvertMavlinkToSingle(Mid(.Packet, 28, 4)) / 100
                                    nGroundSpeed = ConvertSpeed(ConvertMavlinkToSingle(Mid(.Packet, 36, 4)), e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                    nHeading = ConvertMavlinkToSingle(Mid(.Packet, 40, 4))
                                    'Debug.Print("Heading = " & nHeading)
                                    bNewGPS = True
                                    bNewDateTime = True
                                Case 33 'GLOBAL_POSITION 
                                    lblGPSMessage.Text = GetResString(, "Global Position")
                                    dGPSDate = GetMAVlinkDate(ConvertMavlinkToLong(Mid(.Packet, 7, 8)))
                                    dGPSTime = GetMAVlinkTime(ConvertMavlinkToLong(Mid(.Packet, 7, 8)))
                                    nLatitude = ConvertMavlinkToSingle(Mid(.Packet, 15, 4))
                                    nLongitude = ConvertMavlinkToSingle(Mid(.Packet, 19, 4))
                                    nAltitude = ConvertDistance(ConvertMavlinkToSingle(Mid(.Packet, 23, 4)), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                    nGroundSpeed = ConvertSpeed(Math.Sqrt(ConvertMavlinkToSingle(Mid(.Packet, 27, 4)) ^ 2 + ConvertMavlinkToSingle(Mid(.Packet, 31, 4)) ^ 2), e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                    'nHeading = Math.Atan2(ConvertMavlinkToSingle(Mid(.Packet, 27, 4)), ConvertMavlinkToSingle(Mid(.Packet, 31, 4))) * 180 / Math.PI
                                    bNewGPS = True
                                    bNewDateTime = True
                                Case 34 'SYS_STATUS 
                                    lblGPSMessage.Text = GetResString(, "System Status")
                                    'sModeNumber = Mid(.Packet, 7, 2)
                                    sMode = GetAPMMode(Asc(Mid(.Packet, 7, 1)), Asc(Mid(.Packet, 8, 1)))
                                    'smode = GetMavMode(Asc(Mid(.Packet, 7, 1)))
                                    'sMode = sMode & GetMavNav(Asc(Mid(.Packet, 8, 1)))
                                    nBattery = CInt("&h" & Hex(Asc(Mid(.Packet, 12, 1))) & Hex(Asc(Mid(.Packet, 13, 1)))) / 1000
                                    nMAH = nMAHMax - ((CInt("&h" & Hex(Asc(Mid(.Packet, 14, 1))) & Hex(Asc(Mid(.Packet, 15, 1)))) / 1000) * nMAHMax)
                                    bNewGPS = True
                                    bNewWaypoint = True
                                Case 35 'RC_CHANNELS_RAW 
                                    lblGPSMessage.Text = GetResString(, "Channel Raw")
                                    nServoInput(0) = ConvertMavlinkToInteger(Mid(.Packet, 7, 2))
                                    nServoInput(1) = ConvertMavlinkToInteger(Mid(.Packet, 9, 2))
                                    nServoInput(2) = ConvertMavlinkToInteger(Mid(.Packet, 11, 2))
                                    nServoInput(3) = ConvertMavlinkToInteger(Mid(.Packet, 13, 2))
                                    nServoInput(4) = ConvertMavlinkToInteger(Mid(.Packet, 15, 2))
                                    nServoInput(5) = ConvertMavlinkToInteger(Mid(.Packet, 17, 2))
                                    nServoInput(6) = ConvertMavlinkToInteger(Mid(.Packet, 19, 2))
                                    nServoInput(7) = ConvertMavlinkToInteger(Mid(.Packet, 21, 2))
                                    bNewServo = True
                                Case 36 'RC_CHANNELS_SCALED 
                                    'This is wrong, 36 is inputs, not outputs
                                    'lblGPSMessage.Text = GetResString(, "RC Channels Scaled")
                                    'nServoOutput(0) = MavlinkScaledToStandard(ConvertMavlinkToInteger(Mid(.Packet, 7, 2)))
                                    'nServoOutput(1) = MavlinkScaledToStandard(ConvertMavlinkToInteger(Mid(.Packet, 9, 2)))
                                    'nServoOutput(2) = MavlinkScaledToStandard(ConvertMavlinkToInteger(Mid(.Packet, 11, 2)))
                                    'nServoOutput(3) = MavlinkScaledToStandard(ConvertMavlinkToInteger(Mid(.Packet, 13, 2)))
                                    'nServoOutput(4) = MavlinkScaledToStandard(ConvertMavlinkToInteger(Mid(.Packet, 15, 2)))
                                    'nServoOutput(5) = MavlinkScaledToStandard(ConvertMavlinkToInteger(Mid(.Packet, 17, 2)))
                                    'nServoOutput(6) = MavlinkScaledToStandard(ConvertMavlinkToInteger(Mid(.Packet, 19, 2)))
                                    'nServoOutput(7) = MavlinkScaledToStandard(ConvertMavlinkToInteger(Mid(.Packet, 21, 2)))

                                    'bNewServo = True
                                    'If nThrottleChannel > 0 Then
                                    '    If nServoInput(nThrottleChannel - 1) <> 0 Then
                                    '        nThrottle = (nServoInput(nThrottleChannel - 1) - tbarServo1.Minimum) / (tbarServo1.Maximum - tbarServo1.Minimum)
                                    '    Else
                                    '        nThrottle = 0
                                    '    End If
                                    '    bNewWaypoint = True
                                    'End If

                                Case 37 'SERVO_OUTPUT_RAW

                                    lblGPSMessage.Text = "Servo Output Raw"
                                    nServoOutput(0) = ConvertMavlinkToInteger(Mid(.Packet, 7, 2))
                                    nServoOutput(1) = ConvertMavlinkToInteger(Mid(.Packet, 9, 2))
                                    nServoOutput(2) = ConvertMavlinkToInteger(Mid(.Packet, 11, 2))
                                    nServoOutput(3) = ConvertMavlinkToInteger(Mid(.Packet, 13, 2))
                                    nServoOutput(4) = ConvertMavlinkToInteger(Mid(.Packet, 15, 2))
                                    nServoOutput(5) = ConvertMavlinkToInteger(Mid(.Packet, 17, 2))
                                    nServoOutput(6) = ConvertMavlinkToInteger(Mid(.Packet, 19, 2))
                                    nServoOutput(7) = ConvertMavlinkToInteger(Mid(.Packet, 21, 2))

                                    bNewServo = True
                                    If nThrottleChannel > 0 Then
                                        If nServoInput(nThrottleChannel - 1) <> 0 Then
                                            nThrottle = (nServoInput(nThrottleChannel - 1) - tbarServo1.Minimum) / (tbarServo1.Maximum - tbarServo1.Minimum)
                                        Else
                                            nThrottle = 0
                                        End If
                                        bNewWaypoint = True
                                    End If

                                Case 39 'WAYPOINT 
                                    Try
                                        dLastMavlinkCommandTime = Now.Ticks
                                        nMavlinkRetryAttempts = 0
                                        If ConvertMavlinkToInteger(Mid(.Packet, 9, 2)) < nWaypointTotal Then
                                            nWPCount = ConvertMavlinkToInteger(Mid(.Packet, 9, 2))
                                            SetMissionStatus("Reading Mission Command #" & nWPCount)
                                            prgMissionMavlink.Value = nWPCount
                                            lblGPSMessage.Text = "Waypoint #" & nWPCount & " Data"
                                            If UBound(aWPCommand) < nWPCount Then
                                                RedimWaypointArray(nWPCount)
                                            End If

                                            'aWPCommand(nWPCount) = Asc(Mid(.Packet, 12,1))
                                            aWPCommand(nWPCount) = Asc(Mid(.Packet, 12, 1))
                                            nCount = GetCommandIndex(aWPCommand(nWPCount))

                                            aWPOther(nWPCount) = CorrectReadMissionData(ConvertMavlinkToSingle(Mid(.Packet, 15, 4)), aCommandMult1(nCount), aCommandUnit1(nCount), aCommandFormat1(nCount))
                                            aWPOther2(nWPCount) = CorrectReadMissionData(ConvertMavlinkToSingle(Mid(.Packet, 19, 4)), aCommandMult2(nCount), aCommandUnit2(nCount), aCommandFormat2(nCount))
                                            aWPOther3(nWPCount) = CorrectReadMissionData(ConvertMavlinkToSingle(Mid(.Packet, 23, 4)), aCommandMult3(nCount), aCommandUnit3(nCount), aCommandFormat3(nCount))
                                            aWPOther4(nWPCount) = CorrectReadMissionData(ConvertMavlinkToSingle(Mid(.Packet, 27, 4)), aCommandMult4(nCount), aCommandUnit4(nCount), aCommandFormat4(nCount))
                                            aWPLat(nWPCount) = CorrectReadMissionData(ConvertMavlinkToSingle(Mid(.Packet, 31, 4)), aCommandMult5(nCount), aCommandUnit5(nCount), sConfigFormatString)
                                            aWPLon(nWPCount) = CorrectReadMissionData(ConvertMavlinkToSingle(Mid(.Packet, 35, 4)), aCommandMult6(nCount), aCommandUnit6(nCount), sConfigFormatString)
                                            aWPAlt(nWPCount) = CorrectReadMissionData(ConvertMavlinkToSingle(Mid(.Packet, 39, 4)), aCommandMult7(nCount), aCommandUnit7(nCount), aCommandFormat7(nCount))
                                        End If

                                        If nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_WaypointRequest Then
                                            If nWPCount = nWaypointTotal - 1 Then
                                                nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_DoneRequesting
                                                If eNewDeviceBootState = e_NewDevice_BootState.e_NewDevice_BootState_RequestingMission Then
                                                    eNewDeviceBootState = e_NewDevice_BootState.e_NewDevice_BootState_MissionComplete
                                                End If
                                            Else
                                                nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_WaypointRespond
                                            End If
                                        End If
                                        'Debug.Print("-------------------------------")
                                        'Debug.Print("WP#" & ConvertMavlinkToInteger(Mid(.Packet, 9, 2)))

                                        'Debug.Print("Length=" & Len(.Packet))
                                        'Debug.Print("System=" & Asc(Mid(.Packet, 7, 1)))
                                        'Debug.Print("Component=" & Asc(Mid(.Packet, 8, 1)))
                                        'Debug.Print("Seq=" & ConvertMavlinkToInteger(Mid(.Packet, 9, 2)))
                                        'Debug.Print("Frame=" & Asc(Mid(.Packet, 11, 1)))
                                        'Debug.Print("Action=" & Asc(Mid(.Packet, 12, 1)))
                                        'Debug.Print("Orbit=" & ConvertMavlinkToSingle(Mid(.Packet, 13, 4)))
                                        'Debug.Print("orbit_direction=" & Asc(Mid(.Packet, 17, 1)))
                                        'Debug.Print("param1=" & ConvertMavlinkToSingle(Mid(.Packet, 18, 4)))
                                        'Debug.Print("param2=" & ConvertMavlinkToSingle(Mid(.Packet, 22, 4)))
                                        'Debug.Print("current=" & Asc(Mid(.Packet, 26, 1)))
                                        'Debug.Print("x=" & ConvertMavlinkToSingle(Mid(.Packet, 27, 4)))
                                        'Debug.Print("y=" & ConvertMavlinkToSingle(Mid(.Packet, 31, 4)))
                                        'Debug.Print("z=" & ConvertMavlinkToSingle(Mid(.Packet, 35, 4)))
                                        'Debug.Print("yaw=" & ConvertMavlinkToSingle(Mid(.Packet, 39, 4)))
                                        'Debug.Print("autocontinue=" & Asc(Mid(.Packet, 41, 1)))
                                    Catch
                                    End Try
                                Case 40 'WAYPOINT_REQUEST 
                                    dLastMavlinkCommandTime = Now.Ticks
                                    nMavlinkRetryAttempts = 0
                                    'Debug.Print("Requesting Waypoint #" & ConvertMavlinkToInteger(Mid(.Packet, 9, 2)))
                                    If nMavlinkHandshake <> e_MavlinkHandshake.e_MavlinkHandshake_None Then
                                        'Debug.Print("Sending Waypoint #" & ConvertMavlinkToInteger(Mid(.Packet, 9, 2)))
                                        nMavlinkCurrentWaypointSend = ConvertMavlinkToInteger(Mid(.Packet, 9, 2))
                                        SetMissionStatus("APM Requesting Mission Command #" & nMavlinkCurrentWaypointSend)
                                        nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_WaypointSetRespond
                                        Debug.Print("Requesting Waypoint Data #" & nMavlinkCurrentWaypointSend)
                                        SendMavlinkWPDetailSet(nMavlinkCurrentWaypointSend)
                                        'Debug.Print("Sent Waypoint Set Command - B #" & nMavlinkCurrentWaypointSend)
                                    Else
                                        'Debug.Print("HERE")
                                    End If
                                Case 44 'WAYPOINT_COUNT 
                                    dLastMavlinkCommandTime = Now.Ticks
                                    nMavlinkRetryAttempts = 0
                                    nWaypointTotal = ConvertMavlinkToInteger(Mid(.Packet, 9, 2))
                                    prgMissionMavlink.Maximum = nWaypointTotal - 1
                                    lblGPSMessage.Text = "Waypoint Count: " & nWaypointTotal
                                    SetMissionStatus("APM Lists " & nWaypointTotal & " Mission Commands")
                                    If nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_TotalCountRequest Then
                                        nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_TotalCountRespond
                                    End If
                                Case 42, 46 'WAYPOINT_CURRENT  & WAYPOINT_REACHED 
                                    lblGPSMessage.Text = GetResString(, "Current Waypoint")
                                    nWaypoint = ConvertMavlinkToInteger(Mid(.Packet, 7, 2))
                                    bNewWaypoint = True
                                Case 47
                                    nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_None
                                    If Asc(Mid(.Packet, 9, 1)) = 1 Then
                                        SetMissionStatus("Mission write failed", True)
                                    Else
                                        SetMissionStatus("Mission write complete")
                                    End If
                                    UpdateMavlinkStatusRates()
                                Case 62
                                    'nRoll = -ConvertMavlinkToSingle(Mid(.Packet, 7, 4)) * 180 / Math.PI
                                    'nPitch = -ConvertMavlinkToSingle(Mid(.Packet, 11, 4)) * 180 / Math.PI
                                    nDistance = ConvertDistance(ConvertMavlinkToInteger(Mid(.Packet, 19, 2)), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)

                                Case 72 'AIRSPEED 
                                    nAirSpeed = ConvertMavlinkToSingle(Mid(.Packet, 7, 4))
                                    bNewGPS = True
                                Case 73 'GLOBAL_POSITION_INT
                                    '    nLatitude = ConvertMavlinkToLong(Mid(.Packet, 7, 4), True) / 10000000
                                    '    nLongitude = ConvertMavlinkToLong(Mid(.Packet, 11, 4), True) / 10000000
                                    '    nAltitude = ConvertDistance(ConvertMavlinkToLong(Mid(.Packet, 15, 4)) / 1000, e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                    '    nGroundSpeed = Math.Sqrt(Math.Abs((ConvertMavlinkToInteger(Mid(.Packet, 19, 2))) ^ 2) + Math.Abs((ConvertMavlinkToInteger(Mid(.Packet, 21, 2))) ^ 2))
                                    '    nGroundSpeed = ConvertSpeed(nGroundSpeed, e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                    '    nHeading = Math.Atan2(ConvertMavlinkToInteger(Mid(.Packet, 19, 2)), ConvertMavlinkToInteger(Mid(.Packet, 21, 2))) * 180 / Math.PI
                                    '    bNewGPS = True
                                Case 74 'VFR_HUD 
                                    nAirSpeed = ConvertSpeed(ConvertMavlinkToSingle(Mid(.Packet, 7, 4)), e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                    nGroundSpeed = ConvertSpeed(ConvertMavlinkToSingle(Mid(.Packet, 11, 4)), e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                                    'nHeading = ConvertMavlinkToInteger(Mid(.Packet, 15, 2)) '/ 100
                                    'nThrottle = ConvertMavlinkToInteger(Mid(.Packet, 17, 2), True)
                                    'nAltitude = ConvertDistance(ConvertMavlinkToSingle(Mid(.Packet, 19, 4)), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                Case 76
                                    If Asc(Mid(.Packet, 8, 1)) = 1 Then
                                        lblControlMavlinkStatus.Text = "Status: Action accepted - " & cboControlMavlinkAction.Text
                                    Else
                                        lblControlMavlinkStatus.Text = "Status: Action denied - " & cboControlMavlinkAction.Text
                                    End If
                                    Debug.Print("Action=" & ConvertMavlinkToInteger(Mid(.Packet, 7, 2)) & ",Status =" & ConvertMavlinkToInteger(Mid(.Packet, 9, 2)))
                                Case 254 'STATUSTEXT 
                                    'If Asc(Mid(.Packet, 7, 1)) = 0 Then
                                    lblGPSMessage.Text = Mid(.Packet, 8)
                                    lstEvents.Items.Insert(0, "Message=" & Mid(.Packet, 8))
                                    'End If
                                Case Else
                                    'Debug.Print(oMessage.RawBytes(0))
                                    Debug.Print("MAVlink ID=" & .ID)
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
                                    dGPSTime = GetuBloxTime(ConvertHexToDec(Mid(.Packet, 18, 4), , False))
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
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try

        If bNewAttitude = True And chkFullDataFile.Checked = False Then
            If Now.Ticks - nLastAttitude > (1000 / (cboAttitude.SelectedIndex)) * 10000 And cboAttitude.SelectedIndex <> 0 Then
                nLastAttitude = Now.Ticks
                bNewAttitude = False
                GpS_Parser1_AttitudeChange1(nPitch, nRoll, nYaw)
                lstEvents.Items.Insert(0, GetResString(, "Pitch") & "=" & nPitch & "," & GetResString(, "Roll") & "=" & nRoll & "," & GetResString(, "Yaw") & "=" & nYaw)
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

        If bNewServo = True Then
            If Now.Ticks - nLastServos > (1000 / (cboAttitude.SelectedIndex)) * 10000 And cboAttitude.SelectedIndex <> 0 Then
                nLastServos = Now.Ticks
                bNewServo = False
                UpdateServoSliders()
                lstEvents.Items.Insert(0, "Servo1=" & nServoInput(0) & ",Servo2=" & nServoInput(1) & ",Servo3=" & nServoInput(2) & ",Servo4=" & nServoInput(3) & ",Servo5=" & nServoInput(4) & ",Servo6=" & nServoInput(5) & ",Servo7=" & nServoInput(6) & ",Servo8=" & nServoInput(7))
            End If
        End If

        If bNewDateTime = True Then
            bNewDateTime = False
            nLastTimeDate = Now.Ticks
            UpdateGPSDateTime()
        Else
            If Now.Ticks - nLastTimeDate > (2000 * 10000) Then
                UpdateGPSDateTime(True)
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
    Private Sub RedimWaypointArray(ByVal upperBound As Integer)
        ReDim Preserve aWPLat(0 To upperBound)
        ReDim Preserve aWPLon(0 To upperBound)
        ReDim Preserve aWPAlt(0 To upperBound)

        ReDim Preserve aWPSpeed(0 To upperBound)
        ReDim Preserve aWPTrigger(0 To upperBound)

        ReDim Preserve aWPCommand(0 To upperBound)
        ReDim Preserve aWPOther(0 To upperBound)
        ReDim Preserve aWPOther2(0 To upperBound)
        ReDim Preserve aWPOther3(0 To upperBound)
        ReDim Preserve aWPOther4(0 To upperBound)
    End Sub
    Private Sub UpdateGPSDateTime(Optional ByVal clearTime As Boolean = False)
        Dim dDateTime As Date

        Try
            If clearTime = True Then
                lblGPSTime.Text = ""
            Else
                If dGPSDate.Date <> CDate("12:00:00 AM") Then
                    dDateTime = CDate(dGPSDate.Date & " " & dGPSTime.ToLongTimeString)
                Else
                    dDateTime = dGPSTime.ToLongTimeString
                End If

                If bUTCTime = False Then
                    If dDateTime.Month = 1 And dDateTime.Day = 1 And dDateTime.Year = 1 Then
                        dDateTime = DateAdd(DateInterval.Day, 1, dDateTime)
                        lblGPSTime.Text = "* " & GetResString(, "GPS Time", True) & " " & DateAdd(DateInterval.Hour, -nTimeZoneOffset, dDateTime).ToShortTimeString & " *"
                    Else
                        lblGPSTime.Text = "* " & GetResString(, "GPS Time", True) & " " & DateAdd(DateInterval.Hour, -nTimeZoneOffset, dDateTime) & " *"
                    End If
                Else
                    lblGPSTime.Text = "* " & GetResString(, "GPS Time", True) & " " & dDateTime & " (" & GetResString(, "UTC") & ")" & " *"
                End If
            End If
        Catch
        End Try
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
        SetServoValue(0, 0)

        SetServoValue(1, nServoInput(0), 2000, 1000)
        SetServoValue(2, nServoInput(1), 2000, 1000)
        SetServoValue(3, nServoInput(2), 2000, 1000)
        SetServoValue(4, nServoInput(3), 2000, 1000)
        SetServoValue(5, nServoInput(4), 2000, 1000)
        SetServoValue(6, nServoInput(5), 2000, 1000)
        SetServoValue(7, nServoInput(6), 2000, 1000)
        SetServoValue(8, nServoInput(7), 2000, 1000)

        SetServoValue(9, nServoOutput(0), 2000, 1000)
        SetServoValue(10, nServoOutput(1), 2000, 1000)
        SetServoValue(11, nServoOutput(2), 2000, 1000)
        SetServoValue(12, nServoOutput(3), 2000, 1000)
        SetServoValue(13, nServoOutput(4), 2000, 1000)
        SetServoValue(14, nServoOutput(5), 2000, 1000)
        SetServoValue(15, nServoOutput(6), 2000, 1000)
        SetServoValue(16, nServoOutput(7), 2000, 1000)

        SetServoValue(17, nSensor(0), 2500, -2500)
        SetServoValue(18, nSensor(1), 2500, -2500)
        SetServoValue(19, nSensor(2), 2500, -2500)

        SetServoValue(20, nSensor(3), 2000, 1500)
        SetServoValue(21, nSensor(4), 2000, 1500)
        SetServoValue(22, nSensor(5), 2000, 1500)

        SetServoValue(23, nSensor(6))
        SetServoValue(24, nSensor(7))
        SetServoValue(25, nSensor(8))

        SetServoValue(26, 90, -90)
        SetServoValue(27, 90, -90)
        SetServoValue(28, 360, 0)

        SetServoValue(29, nSensor(12), , 0)
        SetServoValue(30, nSensor(13), , 0)
    End Sub
    Private Sub SetServoValue(ByVal valueIndex As Integer, ByVal value As Long, Optional ByVal setMax As Integer = -1, Optional ByVal setMin As Integer = -1)
        If cboServo1.SelectedIndex = valueIndex Then
            UdpateServoSliderValue(cboServo1, tbarServo1, lblServo1, value, setMax, setMin)
        End If
        If cboServo2.SelectedIndex = valueIndex Then
            UdpateServoSliderValue(cboServo2, tbarServo2, lblServo2, value, setMax, setMin)
        End If
        If cboServo3.SelectedIndex = valueIndex Then
            UdpateServoSliderValue(cboServo3, tbarServo3, lblServo3, value, setMax, setMin)
        End If
        If cboServo4.SelectedIndex = valueIndex Then
            UdpateServoSliderValue(cboServo4, tbarServo4, lblServo4, value, setMax, setMin)
        End If
        If cboServo5.SelectedIndex = valueIndex Then
            UdpateServoSliderValue(cboServo5, tbarServo5, lblServo5, value, setMax, setMin)
        End If
        If cboServo6.SelectedIndex = valueIndex Then
            UdpateServoSliderValue(cboServo6, tbarServo6, lblServo6, value, setMax, setMin)
        End If
        If cboServo7.SelectedIndex = valueIndex Then
            UdpateServoSliderValue(cboServo7, tbarServo7, lblServo7, value, setMax, setMin)
        End If
        If cboServo8.SelectedIndex = valueIndex Then
            UdpateServoSliderValue(cboServo8, tbarServo8, lblServo8, value, setMax, setMin)
        End If

        If cboSensors1.SelectedIndex = valueIndex Then
            UdpateServoSliderValue(cboSensors1, tbarSensor1, lblSensor1, value, setMax, setMin)
        End If
        If cboSensors2.SelectedIndex = valueIndex Then
            UdpateServoSliderValue(cboSensors2, tbarSensor2, lblSensor2, value, setMax, setMin)
        End If
        If cboSensors3.SelectedIndex = valueIndex Then
            UdpateServoSliderValue(cboSensors3, tbarSensor3, lblSensor3, value, setMax, setMin)
        End If
        If cboSensors4.SelectedIndex = valueIndex Then
            UdpateServoSliderValue(cboSensors4, tbarSensor4, lblSensor4, value, setMax, setMin)
        End If
        If cboSensors5.SelectedIndex = valueIndex Then
            UdpateServoSliderValue(cboSensors5, tbarSensor5, lblSensor5, value, setMax, setMin)
        End If
        If cboSensors6.SelectedIndex = valueIndex Then
            UdpateServoSliderValue(cboSensors6, tbarSensor6, lblSensor6, value, setMax, setMin)
        End If
        If cboSensors7.SelectedIndex = valueIndex Then
            UdpateServoSliderValue(cboSensors7, tbarSensor7, lblSensor7, value, setMax, setMin)
        End If
        If cboSensors8.SelectedIndex = valueIndex Then
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
            Try
                If value > inputSlider.Maximum Then
                    inputSlider.Value = inputSlider.Maximum
                ElseIf value < inputSlider.Minimum Then
                    inputSlider.Value = inputSlider.Minimum
                Else
                    inputSlider.Value = value
                End If
            Catch
            End Try
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

        If cboComPort.Text = "TCP" Then
            GetResString(lblBaudRate, "Socket_Num", True, , , , , , "Socket Num:")
            nSocketType = System.Net.Sockets.ProtocolType.Tcp
            cboBaudRate.Visible = False
            txtSocket.Visible = True
        ElseIf cboComPort.Text = "UDP" Then
            GetResString(lblBaudRate, "Socket_Num", True, , , , , , "Socket Num:")
            nSocketType = System.Net.Sockets.ProtocolType.Udp
            cboBaudRate.Visible = False
            txtSocket.Visible = True
        Else
            GetResString(lblBaudRate, "Baud Rate", True)
            txtSocket.Visible = False
            cboBaudRate.Visible = True
            serialPortIn.PortName = cboComPort.Text
            If bOpenState Then
                serialPortIn.Open()
            End If
        End If
    End Sub

    Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click
        Dim sTempIP As String
        Dim sTempPort As Long

        bPlaneFirstFound = False
        cmdSetHome.Enabled = False
        oActiveDevices.Initialize()
        pnlLinkLost.Visible = False
        dLastNewDevice = 0
        nLastSpeechWaypoint = -1
        nWaypoint = -1
        eNewDeviceBootState = e_NewDevice_BootState.e_NewDevice_BootState_None

        tmrSearch.Enabled = False
        If cboComPort.Text = "TCP" Or cboComPort.Text = "UDP" Then
            If Not SocketServer Is Nothing Then
                cboConfigDevice.Enabled = True
                cboConfigVehicle.Enabled = True
                bConnected = False
                cmdConnect.Text = GetResString(, "Connect")
                tmrComPort.Enabled = False
                lblComPortStatus.Text = GetResString(, "Disconnect from", , , , serialPortIn.PortName)
                EnableComButtons(True)
                lblGPSType.Text = ""
                lblGPSMessage.Text = ""
                SocketServer.CloseAll()
                SocketServer = Nothing
            Else
                If ParseServerAndPort(txtSocket.Text, sTempIP, sTempPort) = True Then
                    sSocketIPaddress = sTempIP
                    nSocketPortNumber = sTempPort
                    SocketServer = New AsynchronousSocketListener(lstInbound)
                    cmdConnect.Text = GetResString(, "Disconnect")
                    bWaitingAttoUpdate = False
                    bWaitingMavlinkUpdate = False
                    bWaitingMavlinkWrite = False
                    bWaitingGluonUpdate = False
                    tmrComPort.Enabled = True
                    Call SaveRegSetting(sRootRegistry & "\Settings", "COM Port", cboComPort.Text)
                    Call SaveRegSetting(sRootRegistry & "\Settings", "Socket Port", txtSocket.Text)
                    EnableComButtons(False)
                    bConnected = True
                    bNewConnect = True
                    bNewDevice = True
                End If
            End If
        Else
            If serialPortIn.IsOpen = True Then
                cboConfigDevice.Enabled = True
                cboConfigVehicle.Enabled = True
                bConnected = False
                cmdConnect.Text = GetResString(, "Connect")
                tmrComPort.Enabled = False
                Try
                    serialPortIn.Close()
                Catch e2 As Exception
                End Try
                lblComPortStatus.Text = GetResString(, "Disconnect from", , , , serialPortIn.PortName)
                EnableComButtons(True)
                lblGPSType.Text = ""
                lblGPSMessage.Text = ""
            Else
                nLastComPort = -1
                nBaudRateIndex = -1
                lblGPSType.Text = ""
                lblGPSMessage.Text = ""
                tmrSearch_Tick(sender, e)
                bWaitingAttoUpdate = False
                bWaitingMavlinkUpdate = False
                bWaitingMavlinkWrite = False
                bWaitingGluonUpdate = False
                tmrComPort.Enabled = True
                bNewConnect = True
                bNewDevice = True
            End If

        End If
        lblBandwidth.Text = ""
    End Sub

    Private Sub EnableComButtons(ByVal enable As Boolean)
        cboComPort.Enabled = enable
        cboBaudRate.Enabled = enable
        cmdSearch.Enabled = enable
        cmdSearchCOM.Enabled = enable
        cmdReloadComPorts.Enabled = enable
        txtSocket.Enabled = enable
        cmdConfigRead.Enabled = Not enable
        cmdMissionAttoRead.Enabled = Not enable
        cmdMissionMavlinkRead.Enabled = Not enable

        If enable = True Then
            cmdMissionAttoWrite.Enabled = False
            cmdMissionMavlinkWrite.Enabled = False
            cmdConfigWrite.Enabled = False

            bHeartbeatRun1 = False
            bHeartbeatRun2 = False
            bHeartbeatRun3 = False
            bHeartbeatRun4 = False
            bHeartbeatRun5 = False
            bHeartbeatRun6 = False

            nMaxPitchAngle = -1
            nMaxRollAngle = -1
            nMinThrottle = -1
            nMAxThrottle = -1
        Else
            SetConfigStatus("", False)
            SetMissionStatus("", False)
            SetControlStatus("", False)
        End If

        'chkControlAttoAtuoMode.Enabled = Not enable
        cmdControlAttoTriggerServo.Enabled = Not enable
        cmdControlAttoLoiter.Enabled = Not enable
        cmdControlAttoResetBaro.Enabled = Not enable
        cmdControlAttoResume.Enabled = Not enable
        cmdControlAttoReturnHome.Enabled = Not enable
        cmdControlAttoReturnRally.Enabled = Not enable
        cmdControlAttoResetBaro.Enabled = Not enable
        cmdControlAttoSpeed.Enabled = Not enable
        cmdControlAttoResetSpeed.Enabled = Not enable
        cmdControlAttoResetMission.Enabled = Not enable
        cmdControlAttoResetReboot.Enabled = Not enable
        txtControlAttoPressure.Enabled = Not enable
        txtControlAttoSpeed.Enabled = Not enable
        cboControlAttoWPNumber.Enabled = Not enable

        cboControlMavlinkAction.Enabled = Not enable
        cboControlMavlinkMode.Enabled = False 'Not enable
        cmdControlMavlinkAction.Enabled = Not enable
        cmdControlMavlinkRestartMission.Enabled = Not enable
        cmdControlMavlinkGotoCommand.Enabled = Not enable

        cmdControlMavlinkAltRTL.Enabled = Not enable
        cmdControlMavlinkLoiterRadius.Enabled = Not enable
        cmdControlMavlinkWPRadius.Enabled = Not enable

        txtControlMavlinkAltRTL.Enabled = Not enable
        txtControlMavlinkLoiterRadius.Enabled = Not enable
        txtControlMavlinkWPRadius.Enabled = Not enable

        'cmdControlMavlinkMode.Enabled = Not enable
        'cmdControlMavlinkSetAltitude.Enabled = Not enable
        'cmdControlMavlinkSetHome.enabled = Not enable

        nWPCount = -1
    End Sub
    Private Sub EnableTrackingButtons(ByVal enable As Boolean)
        cboComPortTracking.Enabled = enable
        cboBaudRateTracking.Enabled = enable
        cmdReloadTrackingPorts.Enabled = enable
        tbarPan.Enabled = Not enable
        tbarTilt.Enabled = Not enable
        cmdSetHome.Enabled = Not enable
        cboTrackingSet.Enabled = Not enable
        cmdTrackingCalibrate.Enabled = Not enable
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

        If nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink And bConnected = True Then
            UpdateMavlinkStatusRates()
        End If
    End Sub

    Private Sub cboGPS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGPS.SelectedIndexChanged
        Call SaveRegSetting(sRootRegistry & "\Settings", "GPS Hz", cboGPS.SelectedIndex)

        If nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink And bConnected = True Then
            UpdateMavlinkStatusRates()
        End If
    End Sub

    Private Sub cboWaypoint_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWaypoint.SelectedIndexChanged
        Call SaveRegSetting(sRootRegistry & "\Settings", "Waypoint Hz", cboWaypoint.SelectedIndex)

        If nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink And bConnected = True Then
            UpdateMavlinkStatusRates()
        End If
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
                    bConnected = True
                End With
                'serialPortIn.BytesToRead()
                Call SaveRegSetting(sRootRegistry & "\Settings", "COM Port", cboComPort.Text)
                Call SaveRegSetting(sRootRegistry & "\Settings", "Baud Rate", cboBaudRate.Text)
                cmdConnect.Text = GetResString(, "Disconnect")
                lblComPortStatus.Text = GetResString(, "Connected_to", , , , serialPortIn.PortName, serialPortIn.BaudRate)
                EnableComButtons(False)
            Catch e3 As Exception
                lblComPortStatus.Text = e3.Message
                'nBaudRateIndex = UBound(baudRates)
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
            _3DMesh1.DrawMesh(GetPitch(nPitch * n3DPitchRollOffset), GetRoll(nRoll * n3DPitchRollOffset), GetYaw(nYaw + n3DHeadingOffset), False, sModelName, GetRootPath() & "3D Models\")
            'System.Diagnostics.Debug.Print("Paint " & Now)
        End If
    End Sub

    Private Sub tabMapView_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabMapView.SelectedIndexChanged
        ResizeForm()
        Select Case tabMapView.TabPages(tabMapView.SelectedIndex).Tag
            Case "Camera"
                If bFirstVideoCapture1 = False Then
                    LoadComboWithCameras(cboLiveCameraSelect1, sSelectedCamera1, True)
                    bFirstVideoCapture1 = True
                    'bFirstVideoCapture1 = DirectShowControl1.StartCapture(cboLiveCameraSelect2.SelectedIndex)
                End If
            Case "Google Earth"
                If bFirstVideoCapture1 = True Then
                    DirectShowControl1.ReleaseInterfaces()
                    bFirstVideoCapture1 = False
                End If
        End Select
    End Sub

    Private Sub cboMission_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMission.SelectedIndexChanged
        If Trim(cboMission.Text) <> "" Then
            If cboMission.SelectedIndex > 0 Then
                ReadMission(cboMission.Text)
                'ReadMission(cboMission.Text)
                If tabMapView.TabPages(tabMapView.SelectedIndex).Tag = "Google Earth" Then
                    WebBrowser1.Focus()
                End If
            End If
        End If
    End Sub
    Public Sub SetConfigDevice(ByVal deviceID As Integer, Optional ByVal vehicleID As Integer = -1, Optional ByVal lockDevice As Boolean = True)
        Dim nCount As Integer

        If vehicleID <> -1 Then
            cboConfigVehicle.SelectedIndex = vehicleID
        End If
        For nCount = 0 To cboConfigDevice.Items.Count - 1
            If CType(cboConfigDevice.Items(nCount), cValueDesc).Value = deviceID Then
                cboConfigDevice.SelectedIndex = nCount
                cboConfigDevice.Enabled = Not lockDevice
                cboConfigVehicle.Enabled = Not lockDevice
                Exit For
            End If
        Next
    End Sub
    Private Sub ReadMission(ByVal inputMission As String)
        Dim sMission As String
        Dim sSplit() As String
        Dim sSplit2() As String
        Dim nCount As Integer
        Dim nWPNumber As Integer
        Dim bFirstWaypoint As Boolean = False

        If inputMission = "{" & GetResString(, "None") & "}" Then
            Exit Sub
        End If
        sMission = GetFileContents(GetRootPath() & "Missions\" & inputMission)

        sSplit = Split(sMission, vbCrLf)
        If UCase(Mid(inputMission, InStr(inputMission, ".") + 1)) = "TXT" Then
            'If Mid(sSplit(0), 1, 5) <> "OPTIO" And Mid(sSplit(0), 1, 5) <> "HOME:" Then
            '    Call MsgBox(GetResString(, "Invalid Mission File Format"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, GetResString(, "Invalid File"))
            '    cboMission.SelectedIndex = 0
            '    Exit Sub
            'ElseIf (cboConfigDevice.Enabled = False And nConfigDevice <> e_ConfigDevice.e_ConfigDevice_Generic) Then
            '    Call MsgBox("Invalid mission file for this device type.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Invalid File")
            '    cboMission.SelectedIndex = 0
            '    Exit Sub
            'End If

            nWPCount = -1

            'nWPNumber = 0
            For nCount = 0 To UBound(sSplit)
                If Trim(sSplit(nCount)) <> "" Then
                    If Mid(sSplit(nCount), 1, 5) = "HOME:" Then
                        'SetConfigDevice(e_ConfigDevice.e_ConfigDevice_Generic, , False)

                        sSplit2 = Split(sSplit(nCount), ",")
                        'Try
                        '    webDocument.InvokeScript("clearMap", New Object() {})
                        '    If eMapSelection = e_MapSelection.e_MapSelection_GoogleEarth Then
                        '        webDocument.InvokeScript("setHomeLatLng", New Object() {Mid(sSplit2(0), 6), sSplit2(1), ConvertDistance(sSplit2(2), e_DistanceFormat.e_DistanceFormat_Meters, e_DistanceFormat.e_DistanceFormat_Feet), sModelURL, tbarModelScale.Value, GetPitch(nPitch * nDaePitchRollOffset), GetRoll(nRoll * nDaePitchRollOffset), nCameraTracking, eAltOffset, True})
                        '    End If
                        'Catch e2 As Exception
                        'End Try
                        nHomeLat = ConvertPeriodToLocal(Mid(sSplit2(0), 6))
                        nHomeLong = ConvertPeriodToLocal(sSplit2(1))

                        nWPCount = nWPCount + 1
                        RedimWaypointArray(nWPCount)

                        aWPLat(nWPCount) = nHomeLat
                        aWPLon(nWPCount) = nHomeLong
                        If UBound(sSplit2) > 1 Then
                            aWPAlt(nWPCount) = ConvertDistance(ConvertPeriodToLocal(sSplit2(2)), e_DistanceFormat.e_DistanceFormat_Feet, eDistanceUnits)
                            If nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot And UBound(sSplit2) > 2 Then
                                aWPTrigger(nWPCount) = sSplit2(3)
                                aWPSpeed(nWPCount) = ConvertSpeed(ConvertPeriodToLocal(sSplit2(4)), e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                            ElseIf nConfigDevice = e_ConfigDevice.e_ConfigDevice_Generic Then
                                aWPTrigger(nWPCount) = g_DefaultAttoTrigger
                                Select Case nConfigDevice
                                    Case e_ConfigDevice.e_ConfigDevice_AttoPilot
                                        aWPSpeed(nWPCount) = txtMissionAttoDefaultSpeed.Text
                                    Case Else
                                        aWPSpeed(nWPCount) = "0"
                                End Select
                            End If
                        Else
                            aWPAlt(nWPCount) = txtMissionDefaultAlt.Text
                        End If
                        If UBound(sSplit2) >= 6 And nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink Then
                            aWPCommand(nWPCount) = Convert.ToInt32(sSplit2(5))
                            aWPOther(nWPCount) = sSplit2(6)
                        End If

                    ElseIf Mid(sSplit(nCount), 1, 5) = "OPTIO" Then
                    ElseIf Trim(sSplit(nCount)) <> "" Then
                        'nWPNumber = nWPNumber + 1
                        sSplit2 = Split(sSplit(nCount), ",")
                        'Try
                        '    If eMapSelection = e_MapSelection.e_MapSelection_GoogleEarth Then
                        '        webDocument.InvokeScript("addWaypoint", New Object() {sSplit2(0), sSplit2(1), ConvertDistance(sSplit2(2), e_DistanceFormat.e_DistanceFormat_Meters, e_DistanceFormat.e_DistanceFormat_Feet), nWPNumber.ToString.PadLeft(2, "0"), bMissionExtrude, sMissionColor, nMissionWidth, eAltOffset})
                        '    End If
                        'Catch e2 As Exception
                        'End Try
                        nWPCount = nWPCount + 1
                        RedimWaypointArray(nWPCount)

                        aWPLat(nWPCount) = ConvertPeriodToLocal(sSplit2(0))
                        aWPLon(nWPCount) = ConvertPeriodToLocal(sSplit2(1))
                        If UBound(sSplit2) > 1 Then
                            aWPAlt(nWPCount) = ConvertDistance(ConvertPeriodToLocal(sSplit2(2)), e_DistanceFormat.e_DistanceFormat_Feet, eDistanceUnits)
                            If nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot And UBound(sSplit2) > 2 Then
                                aWPTrigger(nWPCount) = sSplit2(3)
                                aWPSpeed(nWPCount) = ConvertSpeed(ConvertPeriodToLocal(sSplit2(4)), e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)
                            Else
                                aWPTrigger(nWPCount) = g_DefaultAttoTrigger
                                Select Case nConfigDevice
                                    Case e_ConfigDevice.e_ConfigDevice_AttoPilot
                                        aWPSpeed(nWPCount) = txtMissionAttoDefaultSpeed.Text
                                    Case Else
                                        aWPSpeed(nWPCount) = "0"
                                End Select
                            End If
                        Else
                            aWPAlt(nWPCount) = txtMissionDefaultAlt.Text
                        End If
                        If UBound(sSplit2) >= 6 And nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink Then
                            aWPCommand(nWPCount) = Convert.ToInt32(sSplit2(5))
                            aWPOther(nWPCount) = sSplit2(6)
                        End If
                    End If
                End If
            Next
            LoadMissionGrid()
            UpdateMissionGE(0, , 0, True)
            'ElseIf UCase(Mid(inputMission, InStr(inputMission, ".") + 1)) = "H" Then
            '    'If Mid(sSplit(0), 1, 7) <> "#define" Then
            '    '    Call MsgBox("Invalid Mission File Format", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Invalid File")
            '    '    cboMission.SelectedIndex = 0
            '    '    Exit Sub
            '    'End If

            '    If (cboConfigDevice.Enabled = False And nConfigDevice <> e_ConfigDevice.e_ConfigDevice_Generic) Then
            '        SetConfigDevice(e_ConfigDevice.e_ConfigDevice_Generic, , False)

            '        webDocument.InvokeScript("clearMap", New Object() {})
            '        nWPNumber = 0
            '        For nCount = 0 To UBound(sSplit)
            '            If Trim(sSplit(nCount)) <> "" Then
            '                If Trim(Mid(sSplit(nCount), 1, 14)) = "{CMD_WAYPOINT," Then
            '                    sSplit2 = Split(sSplit(nCount), ",")
            '                    sSplit2(4) = Replace(sSplit2(4), "}", "")
            '                    Try
            '                        If nWPNumber = 0 Then
            '                            If eMapSelection = e_MapSelection.e_MapSelection_GoogleEarth Then
            '                                webDocument.InvokeScript("setHomeLatLng", New Object() {ConvertPeriodToLocal(sSplit2(3)), ConvertPeriodToLocal(sSplit2(4)), ConvertPeriodToLocal(ConvertDistance(sSplit2(2), e_DistanceFormat.e_DistanceFormat_Meters, e_DistanceFormat.e_DistanceFormat_Feet)), sModelURL, tbarModelScale.Value, GetPitch(nPitch * nDaePitchRollOffset), GetRoll(nRoll * nDaePitchRollOffset), nCameraTracking, eAltOffset, True})
            '                                nHomeLat = sSplit2(3)
            '                                nHomeLong = sSplit2(4)
            '                            End If
            '                        Else
            '                            If eMapSelection = e_MapSelection.e_MapSelection_GoogleEarth Then
            '                                webDocument.InvokeScript("addWaypoint", New Object() {ConvertPeriodToLocal(sSplit2(3)), ConvertPeriodToLocal(sSplit2(4)), ConvertPeriodToLocal(ConvertDistance(sSplit2(2), e_DistanceFormat.e_DistanceFormat_Meters, e_DistanceFormat.e_DistanceFormat_Feet)), nWPNumber.ToString.PadLeft(2, "0"), bMissionExtrude, sMissionColor, nMissionWidth, eAltOffset})
            '                            End If
            '                        End If
            '                    Catch e2 As Exception
            '                    End Try
            '                    nWPNumber = nWPNumber + 1
            '                End If
            '            End If
            '        Next
            '    End If

            '    If nWPCount > 0 Then
            '        Try
            '            If eMapSelection = e_MapSelection.e_MapSelection_GoogleEarth Then
            '                webDocument.InvokeScript("drawHomeLine")
            '                webDocument.InvokeScript("centerOnLocation", New Object() {ConvertPeriodToLocal(aWPLat(0)), ConvertPeriodToLocal(aWPLon(0)), ConvertPeriodToLocal(ConvertDistance(aWPAlt(0), eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters)), 0, nConfigAltOffset})

            '            End If
            '        Catch e2 As Exception
            '        End Try
            '    End If
        Else
            Call MsgBox("Invalid mission file for this device type.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Invalid File")
            cboMission.SelectedIndex = 0
            Exit Sub
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
            'serialPortIn.Encoding = System.Text.Encoding.GetEncoding(28591)
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

    Private Sub cmdReloadComPorts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReloadComPorts.Click, cmdReloadTrackingPorts.Click
        If sender.name = "cmdReloadComPorts" Then
            LoadComPorts(cboComPort.Text, cboComPortTracking.Text, 1)
        Else
            LoadComPorts(cboComPort.Text, cboComPortTracking.Text, 2)
        End If
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
        If Not webDocument Is Nothing And bGoogleLoaded = True Then
            webDocument.InvokeScript("changeView", New Object() {newValue, ConvertPeriodToLocal(nAltitude), ConvertPeriodToLocal(GetPitch(nPitch)), ConvertPeriodToLocal(GetRoll(nRoll)), sModelURL})
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
    Private Sub LoadSplitterSettings()
        Dim nDefault As Long
        Select Case tabInstrumentView.SelectedIndex
            Case 0
                SplitContainer1.Panel1MinSize = 320
                nDefault = 320
            Case 1
                SplitContainer1.Panel1MinSize = 320
                nDefault = Me.Width - SplitContainer1.Panel2MinSize
            Case 2
                SplitContainer1.Panel1MinSize = 320
                nDefault = Me.Width - SplitContainer1.Panel2MinSize
            Case 3
                SplitContainer1.Panel1MinSize = 320
                nDefault = 590
            Case 4
                SplitContainer1.Panel1MinSize = 575
                nDefault = 590
            Case 5
                SplitContainer1.Panel1MinSize = 575
                nDefault = 590
            Case 6
                SplitContainer1.Panel1MinSize = 325
                nDefault = 590
        End Select
        SplitContainer1.SplitterDistance = GetRegSetting(sRootRegistry & "\Settings", "Splitter Location " & tabInstrumentView.SelectedIndex, nDefault)

    End Sub
    Private Sub tabInstrumentView_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabInstrumentView.SelectedIndexChanged
        LoadSplitterSettings()
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
        If tabInstrumentView.SelectedIndex = 4 Then
            'If eDeviceType = e_DeviceType.e_DeviceType_AttoPilot Then
            '    LoadAttoMissionGrid()
            'End If
            chkViewNoTracking.Checked = True
            chkViewNoTracking_CheckedChanged(Nothing, Nothing)
            bLockMissionCenter = False
            If nWPCount >= nNewWaypoint Then
                CenterAndTilt(nNewWaypoint, 0)
                '    'UpdateMissionGE(nWaypoint, , 0)
            End If
        ElseIf tabInstrumentView.SelectedIndex = 5 Then
            bLockMissionCenter = True

            'Select Case nConfigDevice
            '    Case e_ConfigDevice.e_ConfigDevice_AttoPilot
            '        grpControlAtto.Visible = True
            '    Case Else
            '        grpControlAtto.Visible = False
            'End Select
        ElseIf tabInstrumentView.SelectedIndex = 6 Then
            bLockMissionCenter = True
            If nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot Then
                SetConfigSelectedRowCol(, 4)
            ElseIf nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink Then
                SetConfigSelectedRowCol(, 3)
            End If
        Else
            bLockMissionCenter = True
        End If
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

        pnlLinkLost.Left = SplitContainer1.Panel1.Width + SplitContainer1.Panel1.Left + 20

        bUltraSmall = False

        If SplitContainer1.Panel1.Width < 590 Then
            bUltraSmall = True
            tabPortControl.Width = SplitContainer1.Panel1.Width - 8
            'tabInstrumentView.Width = tabPortControl.Width
            tabInstrumentView.Width = SplitContainer1.Panel1.Width - 8
            grpMisc.Width = tabInstrumentView.Width - 12

            If tabPortControl.TabPages.Count < 7 Then
                tabPortControl.TabPages.Add("tabPortStatus", GetResString(, "Status"))
                oTab = tabPortControl.TabPages(tabPortControl.TabPages.Count - 1)
                oTab.BackColor = Color.FromName("Control")
            Else
                tabPortControl.TabPages(6).Text = GetResString(, "Status")
            End If
            grpMisc.Top = tabPortControl.Top + 21
            grpMisc.Left = tabPortControl.Left + 5
            grpGPSTime.Visible = False
            grpMisc.BackColor = GetSystemColor("F5F4F1")
        Else
            tabInstrumentView.Width = SplitContainer1.Panel1.Width - 8
            grpMisc.Width = 300
            tabPortControl.Width = SplitContainer1.Panel1.Width - grpMisc.Width - 15
            If tabPortControl.TabPages.Count >= 7 Then
                If tabPortControl.SelectedIndex = 6 Then
                    tabPortControl.SelectedIndex = 0
                End If
                tabPortControl.TabPages.Remove(tabPortControl.TabPages(6))
            End If
            grpMisc.Top = tabPortControl.Top + tabPortControl.Height - grpMisc.Height
            grpMisc.Left = tabPortControl.Left + tabPortControl.Width + 6
            grpGPSTime.Left = grpMisc.Left
            grpGPSTime.Top = grpMisc.Top - grpGPSTime.Height + 8
            grpGPSTime.Width = grpMisc.Width
            grpGPSTime.Visible = True
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
        dgConfigVariable.Width = lstInbound.Width
        prgConfig.Width = lstInbound.Width - prgConfig.Left + lstInbound.Left
        lblConfigStatus.Width = prgConfig.Width
        dgMission.Width = lstInbound.Width
        'prgMission.Width = lstInbound.Width - prgMission.Left + lstInbound.Left
        'lblMissionStatus.Width = prgMission.Width
        grpControlAtto.Width = tabInstrumentView.Width - grpControlAtto.Left - 16
        grpControlMavlink.Width = grpControlAtto.Width

        grpMissionControlGeneric.Width = dgMission.Width
        grpMissionControlAtto.Width = dgMission.Width
        grpMissionControlMavlink.Width = dgMission.Width

        txtMissionDefaultAlt.Left = dgMission.Left + dgMission.Width - txtMissionDefaultAlt.Width
        lblMissionDefaultAlt.Left = txtMissionDefaultAlt.Left - lblMissionDefaultAlt.Width - 4
        cmdReloadMissions.Left = dgMission.Left + dgMission.Width - cmdReloadMissions.Width
        cmdReloadMissionDirectory.Left = cmdReloadMissions.Left - cmdReloadMissionDirectory.Width - 4
        cboMission.Left = cmdReloadMissionDirectory.Left - cboMission.Width - 4
        lblMissionLabel.Left = cboMission.Left - lblMissionLabel.Width - 4
        chkMissionInsert.Left = dgMission.Width + dgMission.Left - chkMissionInsert.Width

        ResizePortControlTab()

        Select Case tabInstrumentView.SelectedIndex
            Case 0
                pnlDevice.Visible = False
                If bInstruments(e_Instruments.e_Instruments_3DModel) = True Then
                    '_3DMesh1.Locked = False
                    '_3DMesh1.Refresh()
                    'frmMain_Paint(Nothing, Nothing)
                    _3DMesh1.DrawMesh(GetPitch(nPitch * n3DPitchRollOffset), GetRoll(nRoll * n3DPitchRollOffset), GetYaw(nYaw + n3DHeadingOffset), False, sModelName, GetRootPath() & "3D Models\")
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
                            cmdZeroYaw.Visible = bInstruments(e_Instruments.e_Instruments_3DModel)
                            cmdZeroYaw.Left = _3DMesh1.Left + _3DMesh1.Width - cmdZeroYaw.Width - 2
                            cmdZeroYaw.Top = _3DMesh1.Top + _3DMesh1.Height - cmdZeroYaw.Height - 2
                        ElseIf nCount = e_Instruments.e_Instruments_Altimeter Then
                            cmdSetHomeAlt.Visible = bInstruments(e_Instruments.e_Instruments_Altimeter)
                            cmdSetHomeAlt.Left = AltimeterInstrumentControl1.Left + AltimeterInstrumentControl1.Width - cmdSetHomeAlt.Width
                            cmdSetHomeAlt.Top = AltimeterInstrumentControl1.Top + AltimeterInstrumentControl1.Height - cmdSetHomeAlt.Height
                        End If
                    Next
                Catch
                End Try

            Case 1
                pnlDevice.Visible = False
                grpSerialSettings.Top = tabInstrumentView.Height - grpSerialSettings.Height - 35
                lstEvents.Height = (grpSerialSettings.Top - 46) / 2
                lstInbound.Height = lstEvents.Height

                lblRawData.Top = 8
                lstInbound.Top = lblRawData.Top + lblRawData.Height + 4

                lblTranslatedData.Top = lstInbound.Top + lstInbound.Height + 4
                lstEvents.Top = lblTranslatedData.Top + lblTranslatedData.Height + 4
            Case 2
                pnlDevice.Visible = False
                chkCommandLineAutoScroll.Top = tabInstrumentView.Height - chkCommandLineAutoScroll.Height - 35
                cboCommandLineDelim.Top = chkCommandLineAutoScroll.Top

                lstCommandLineOutput.Height = chkCommandLineAutoScroll.Top - lstCommandLineOutput.Top - 6
            Case 3
                pnlDevice.Visible = False
                FitDirectShow(DirectShowControl2, tabInstrumentView.Width - 30, tabInstrumentView.Height - DirectShowControl2.Top - 48)
                cmdLiveCameraProperties2.Left = DirectShowControl2.Left + DirectShowControl2.Width - cmdLiveCameraProperties2.Width
                cboLiveCameraSelect2.Left = DirectShowControl2.Left
                cboLiveCameraSelect2.Width = cmdLiveCameraProperties2.Left - cboLiveCameraSelect2.Left - 6
            Case 4
                pnlDevice.Visible = True

                'cmdMissionRead.Top = tabInstrumentView.Height - cmdMissionRead.Height - 35
                'cmdMissionWrite.Top = cmdMissionRead.Top
                'prgMission.Top = cmdMissionRead.Top
                'lblMissionStatus.Top = prgMission.Top + prgMission.Height + 2

                Select Case nConfigDevice
                    Case e_ConfigDevice.e_ConfigDevice_Generic
                        grpMissionControlGeneric.Top = tabInstrumentView.Height - grpMissionControlGeneric.Height - 35
                        lblMissionDoubleClickLabel.Top = grpMissionControlGeneric.Top - lblMissionDoubleClickLabel.Height + 2
                    Case e_ConfigDevice.e_ConfigDevice_AttoPilot
                        grpMissionControlAtto.Top = tabInstrumentView.Height - grpMissionControlAtto.Height - 35
                        lblMissionDoubleClickLabel.Top = grpMissionControlAtto.Top - lblMissionDoubleClickLabel.Height + 2
                    Case e_ConfigDevice.e_ConfigDevice_MAVlink
                        grpMissionControlMavlink.Top = tabInstrumentView.Height - grpMissionControlMavlink.Height - 35
                        lblMissionDoubleClickLabel.Top = grpMissionControlMavlink.Top - lblMissionDoubleClickLabel.Height + 2
                End Select
                lblMissionHomeAlt.Top = lblMissionDoubleClickLabel.Top

                chkMissionInsert.Top = lblMissionDoubleClickLabel.Top + 3
                dgMission.Height = lblMissionDoubleClickLabel.Top - dgMission.Top - 2
            Case 5
                pnlDevice.Visible = True
                grpControlAtto.Height = tabInstrumentView.Height - grpControlAtto.Top - 35
                grpControlMavlink.Height = grpControlAtto.Height
            Case 6
                pnlDevice.Visible = True
                cmdConfigRead.Top = tabInstrumentView.Height - cmdConfigRead.Height - 35
                cmdConfigWrite.Top = cmdConfigRead.Top
                prgConfig.Top = cmdConfigRead.Top
                lblConfigStatus.Top = prgConfig.Top + prgConfig.Height + 2

                dgConfigVariable.Height = cmdConfigRead.Top - dgConfigVariable.Top - 6
        End Select

        'Lefts
        tabMapView.Left = 3
        tabMapView.Width = SplitContainer1.Panel2.Width - 9
        WebBrowser1.Width = tabMapView.Width - 22
        cmdCenterOnPlane.Left = tabMapView.Left
        cmdClearMap.Left = cmdCenterOnPlane.Left + cmdCenterOnPlane.Width + 2
        cmdSetHome.Left = cmdClearMap.Left + cmdClearMap.Width + 2
        cmdExit.Left = tabMapView.Left + tabMapView.Width - cmdExit.Width

        lblResolution.Left = tabMapView.Left + tabMapView.Width - lblResolution.Width
        lblResolution.Text = Me.Width & " X " & Me.Height

        JoystickInstrumentControl1.Left = 15

        Select Case tabMapView.TabPages(tabMapView.SelectedIndex).Tag
            Case "Google Earth"
                chkViewNoTracking.Top = tabMapView.Height - chkViewNoTracking.Height - 32
                chkViewOverhead.Top = chkViewNoTracking.Top
                chkViewChaseCam.Top = chkViewNoTracking.Top
                chkViewFirstPerson.Top = chkViewNoTracking.Top
                chkViewHeadLock.Top = tabMapView.Height - chkViewNoTracking.Height - 32
                tbarModelScale.Top = chkViewNoTracking.Top
                WebBrowser1.Height = chkViewNoTracking.Top - 15
                JoystickInstrumentControl1.Top = WebBrowser1.Top + WebBrowser1.Height - JoystickInstrumentControl1.Height - 5
                pnlLinkLost.Top = 40
            Case "Camera"
                FitDirectShow(DirectShowControl1, tabMapView.Width - 30, tabMapView.Height - 70)
                cmdLiveCameraProperties1.Left = DirectShowControl1.Left + DirectShowControl1.Width - cmdLiveCameraProperties1.Width
                cboLiveCameraSelect1.Left = DirectShowControl1.Left
                cboLiveCameraSelect1.Width = cmdLiveCameraProperties1.Left - cboLiveCameraSelect1.Left - 6
                JoystickInstrumentControl1.Top = DirectShowControl1.Top + DirectShowControl1.Height - JoystickInstrumentControl1.Height - 5
                pnlLinkLost.Top = 60
        End Select

        If bInstruments(e_Instruments.e_Instruments_3DModel) = True Then
            '_3DMesh1.Locked = False
            _3DMesh1.DrawMesh(GetPitch(nPitch * n3DPitchRollOffset), GetRoll(nRoll * n3DPitchRollOffset), GetYaw(nYaw + n3DHeadingOffset), False, sModelName, GetRootPath() & "3D Models\")
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
        tabInstrumentView.Refresh()
        tabMapView.Refresh()
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
            Case 5
                lblJoystickOutput1.Left = tabPortControl.Width - lblJoystickOutput1.Width - 6
                lblJoystickOutput2.Left = lblJoystickOutput1.Left
                lblJoystickOutput3.Left = lblJoystickOutput1.Left
                lblJoystickOutput4.Left = lblJoystickOutput1.Left
                'lblJoystickOutput5.Left = lblJoystickOutput1.Left

                tbarJoystickOutput1.Width = lblJoystickOutput1.Left - tbarJoystickOutput1.Left
                tbarJoystickOutput2.Width = tbarJoystickOutput1.Width
                tbarJoystickOutput3.Width = tbarJoystickOutput1.Width
                tbarJoystickOutput4.Width = tbarJoystickOutput1.Width
                'tbarJoystickOutput5.Width = tbarJoystickOutput1.Width

        End Select
        If bUltraSmall = True And bExpandInstruments = False Then
            Select Case tabPortControl.SelectedIndex
                Case 6
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
    Public Sub tabPortControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabPortControl.SelectedIndexChanged
        If tabPortControl.SelectedIndex = 5 Then
            Dim nCount As Int16

            If jst Is Nothing Then
                jst = New JoystickInterface.Joystick(Me.Handle)
            End If

            Dim sticks As String() = jst.FindJoysticks()
            Dim bFoundOne As Boolean = False

            If sticks Is Nothing Then
                cmdJoystickCalibrate.Enabled = False
                chkJoystickEnable.Enabled = False
                tmrJoystick.Enabled = False
                jst = Nothing
                lblJoystickDevice.Text = "No Joystick Found"
            Else
                cmdJoystickCalibrate.Enabled = True
                For nCount = 0 To UBound(sticks)
                    If sticks(nCount) = sJoystickDevice Then
                        jst.AcquireJoystick(sJoystickDevice)
                        bFoundOne = True
                        Exit For
                    End If
                Next

                lblJoystickDevice.Text = sJoystickDevice

                If bFoundOne = True And sJoystickDevice <> "" Then 'And nJoystickElevatorMin <> 32767 And nJoystickElevatorMax <> 32767 And nJoystickAileronMin <> 32767 And nJoystickAileronMax <> 32767 Then
                    chkJoystickEnable.Enabled = True
                Else
                    chkJoystickEnable.Enabled = False
                End If
            End If
        End If
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
            nHomeLat = nLatitude
            nHomeLong = nLongitude
            nHomeAlt = nAltitude
            'If cboConfigDevice.Enabled = False And nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot Then
            aWPLat(0) = nHomeLat
            aWPLon(0) = nHomeLong
            aWPAlt(0) = 0 'nHomeAlt
            aWPTrigger(0) = g_DefaultAttoTrigger
            aWPSpeed(0) = txtMissionAttoDefaultSpeed.Text
            If nWPCount = -1 Then
                nWPCount = 0
            End If
            LoadMissionGrid()
            If tabInstrumentView.SelectedIndex = 4 Then
                UpdateMissionGE(0, , 0, True)
            Else
                UpdateMissionGE(0, , 0, False)
            End If
            If Not webDocument Is Nothing And bGoogleLoaded = True And cboConfigDevice.Enabled = True Then
                webDocument.InvokeScript("setHomeLatLng", New Object() {ConvertPeriodToLocal(nLatitude), ConvertPeriodToLocal(nLongitude), ConvertPeriodToLocal(nAltitude), sModelURL, tbarModelScale.Value, GetPitch(nPitch * nDaePitchRollOffset), GetRoll(nRoll * nDaePitchRollOffset), nCameraTracking, eAltOffset, True, sHomeIcon})
            End If
            nDataPoints = 1
            lblStatusTracking.Text = "Home Set"
        Catch
        End Try
    End Sub

    Private Sub SplitContainer1_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        ToolStrip1.Width = SplitContainer1.Panel1.Width
        If bStartup = True Then
            Exit Sub
        End If
        SaveRegSetting(sRootRegistry & "\Settings", "Splitter Location " & tabInstrumentView.SelectedIndex, SplitContainer1.Panel1.Width)
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

    Private Sub cmdZeroYaw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZeroYaw.Click
        nYawOffset = nYaw
        _3DMesh1.DrawMesh(GetPitch(nPitch * n3DPitchRollOffset), GetRoll(nRoll * n3DPitchRollOffset), GetYaw(nYaw + n3DHeadingOffset), False, sModelName, GetRootPath() & "3D Models\")
    End Sub

    Private Sub tmrComPort_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrComPort.Tick
        If tmrComPort.Enabled = False Then
            Exit Sub
        End If
        ReadSerialData()
    End Sub

    Private Sub cboServo1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboServo1.SelectedIndexChanged, cboServo2.SelectedIndexChanged, cboServo3.SelectedIndexChanged, cboServo4.SelectedIndexChanged, cboServo5.SelectedIndexChanged, cboServo6.SelectedIndexChanged, cboServo7.SelectedIndexChanged, cboServo8.SelectedIndexChanged
        If bStartup = True Then
            Exit Sub
        End If

        UpdateServoSliders()

        SaveRegSetting(sRootRegistry & "\Settings\Servo", " 1", cboServo1.SelectedIndex)
        SaveRegSetting(sRootRegistry & "\Settings\Servo", " 2", cboServo2.SelectedIndex)
        SaveRegSetting(sRootRegistry & "\Settings\Servo", " 3", cboServo3.SelectedIndex)
        SaveRegSetting(sRootRegistry & "\Settings\Servo", " 4", cboServo4.SelectedIndex)
        SaveRegSetting(sRootRegistry & "\Settings\Servo", " 5", cboServo5.SelectedIndex)
        SaveRegSetting(sRootRegistry & "\Settings\Servo", " 6", cboServo6.SelectedIndex)
        SaveRegSetting(sRootRegistry & "\Settings\Servo", " 7", cboServo7.SelectedIndex)
        SaveRegSetting(sRootRegistry & "\Settings\Servo", " 8", cboServo8.SelectedIndex)
    End Sub

    Private Sub cboSensors1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSensors1.SelectedIndexChanged, cboSensors2.SelectedIndexChanged, cboSensors3.SelectedIndexChanged, cboSensors4.SelectedIndexChanged, cboSensors5.SelectedIndexChanged, cboSensors6.SelectedIndexChanged, cboSensors7.SelectedIndexChanged, cboSensors8.SelectedIndexChanged
        If bStartup = True Then
            Exit Sub
        End If

        UpdateServoSliders()

        SaveRegSetting(sRootRegistry & "\Settings\Sensor", "1", cboSensors1.SelectedIndex)
        SaveRegSetting(sRootRegistry & "\Settings\Sensor", "2", cboSensors2.SelectedIndex)
        SaveRegSetting(sRootRegistry & "\Settings\Sensor", "3", cboSensors3.SelectedIndex)
        SaveRegSetting(sRootRegistry & "\Settings\Sensor", "4", cboSensors4.SelectedIndex)
        SaveRegSetting(sRootRegistry & "\Settings\Sensor", "5", cboSensors5.SelectedIndex)
        SaveRegSetting(sRootRegistry & "\Settings\Sensor", "6", cboSensors6.SelectedIndex)
        SaveRegSetting(sRootRegistry & "\Settings\Sensor", "7", cboSensors7.SelectedIndex)
        SaveRegSetting(sRootRegistry & "\Settings\Sensor", "8", cboSensors8.SelectedIndex)
    End Sub

    Private Sub cmdTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTest.Click
        Dim sMission As String
        Dim sSplit() As String
        Dim sSplit2() As String
        Dim nCount As Integer
        Dim nCount2 As Int16
        Dim oMessage As cMessage
        Dim sOutput As String = ""
        Dim sFileContents As String
        Dim sNewString As String
        Dim sFilename As String

        'Debug.Print(ConvertLatLongFY21AP(Chr(&H80) & Chr(&HE1) & Chr(&H1) & Chr(&HD4)))
        'Debug.Print(ConvertLatLongFY21AP(Chr(&H9) & Chr(&H6D) & Chr(&H4) & Chr(&H51)))
        'Exit Sub

        'sFilename = "C:\Documents and Settings\Paul\My Documents\Visual Studio 2005\Projects\HK_GCS\HK_GCS\Save this\Output\test.hko" 'This GCS output
        'sFilename = "C:\Documents and Settings\Paul\Desktop\UDB\log_05_08_18__16_37_16\log_05_08_18__16_37_16_2.txt" ' Paparazzi
        'sFilename = "C:\Documents and Settings\Paul\My Documents\Visual Studio 2005\Projects\HK_GCS\HK_GCS\Save this\Output\gluonpilot.txt" ' Gluonpilot
        'sFilename = "C:\Documents and Settings\Paul\My Documents\Visual Studio 2005\Projects\HK_GCS\HK_GCS\Save this\Output\atto.txt" ' Attopilot
        'sFilename = "C:\Documents and Settings\Paul\My Documents\Visual Studio 2005\Projects\HK_GCS\HK_GCS\Save this\Output\FY-21_280-90.txt" 'FY21AP II
        sFilename = "C:\Documents and Settings\Paul\My Documents\Visual Studio 2005\Projects\HK_GCS\HK_GCS\Save this\Output\atto18.txt" 'FY21AP II

        'Dim FS As New FileStream("C:\Documents and Settings\Paul\My Documents\Visual Studio 2005\Projects\HK_GCS\HK_GCS\Save this\Output\test.hko", FileMode.Open)
        'Dim FS As New FileStream("C:\Documents and Settings\Paul\Desktop\UDB\log_05_08_18__16_37_16\log_05_08_18__16_37_16_2.txt", FileMode.Open)
        'Dim FS As New FileStream("C:\Documents and Settings\Paul\My Documents\Visual Studio 2005\Projects\HK_GCS\HK_GCS\Save this\Output\gluonpilot.txt", FileMode.Open)
        'Dim FS As New FileStream("C:\Documents and Settings\Paul\My Documents\Visual Studio 2005\Projects\HK_GCS\HK_GCS\Save this\Output\FY-21_280-90.txt", FileMode.Open)
        'Dim FS As New FileStream("C:\atto.txt", FileMode.Open)
        'Dim Buffer() As Byte
        ''Get the bytes from file to a byte array        
        'ReDim Buffer(FS.Length - 1)
        'FS.Read(Buffer, 0, Buffer.Length)
        'sFileContents = System.Text.Encoding.Default.GetString(Buffer)
        'FS.Close()

        sFileContents = GetFileContents(sFilename)


        'sSplit = Split(sFileContents, vbLf)
        'sSplit = Split(sFileContents, Chr(&HA5) & Chr(&H5A))
        sSplit = Split(sFileContents, vbCrLf)

        'For nCount2 = 1 To Len(sFileContents)
        '    sOutput = sOutput & Hex(Asc(Mid(sFileContents, nCount2, 1))).PadLeft(2, "0") & " "
        'Next
        'Debug.Print(sOutput)

        For nCount = 0 To UBound(sSplit)
            'sNewString = ""
            'sSplit2 = Split(sSplit(nCount), " ")
            'For nCount2 = 0 To UBound(sSplit2)
            '    If sSplit2(nCount2) <> "" Then
            '        sNewString = sNewString & Chr("&h" & sSplit2(nCount2))
            '    End If
            'Next

            'oMessage = GetNextSentence(sNewString & vbCrLf)
            'oMessage = GetNextSentence(Chr(&HA5) & Chr(&H5A) & sSplit(nCount))
            oMessage = GetNextSentence(sSplit(nCount) & vbCrLf) ', Nothing)
            UpdateVariables(oMessage)
            Application.DoEvents()

            System.Threading.Thread.Sleep(20)
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

    Private Sub lblGPSTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblGPSTime.Click
        bUTCTime = Not bUTCTime
        SaveRegSetting(sRootRegistry & "\Settings", "UTC Time", bUTCTime)
    End Sub
    Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F9 Then
            If Dir(GetRootPath() & "Language\StringResourceEditor.exe", FileAttribute.Normal) <> "" Then
                System.Diagnostics.Process.Start(GetRootPath() & "Language\StringResourceEditor.exe", """" & GetRootPath() & "Language\Strings.resx""")
            End If
        ElseIf e.KeyCode = Keys.F5 Then
            sLanguageFile = GetRegSetting(sRootRegistry & "\Settings", "Language File", "Default")
            ResetForm()
            LoadSettings()
            ResizeForm()
        ElseIf e.KeyCode = Keys.F4 Then
            sLanguageFile = "en"
            ResetForm()
            LoadSettings()
            ResizeForm()
        End If
    End Sub

    Private Sub frmMain_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        If bInstruments(e_Instruments.e_Instruments_3DModel) = True Then
            _3DMesh1.DrawMesh(GetPitch(nPitch * n3DPitchRollOffset), GetRoll(nRoll * n3DPitchRollOffset), GetYaw(nYaw + n3DHeadingOffset), False, sModelName, GetRootPath() & "3D Models\")
            'System.Diagnostics.Debug.Print("Actvated " & Now)
        End If
    End Sub

    Private Sub frmMain_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        If bInstruments(e_Instruments.e_Instruments_3DModel) = True Then
            _3DMesh1.DrawMesh(GetPitch(nPitch * n3DPitchRollOffset), GetRoll(nRoll * n3DPitchRollOffset), GetYaw(nYaw + n3DHeadingOffset), False, sModelName, GetRootPath() & "3D Models\")
            'System.Diagnostics.Debug.Print("Actvated " & Now)
        End If
    End Sub

    Private Sub cmdConnectTracking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnectTracking.Click
        If serialPortTracking.IsOpen = True Then
            tmrTracking.Enabled = False
            bConnectedTracking = False
            cmdConnectTracking.Text = GetResString(, "Connect")
            tmrTracking.Enabled = False
            Try
                serialPortTracking.Close()
            Catch e2 As Exception
            End Try
            lblStatusTracking.Text = GetResString(, "Disconnect from", , , , serialPortTracking.PortName)
            EnableTrackingButtons(True)
        Else
            Try

                If serialPortTracking.IsOpen = True Then
                    serialPortTracking.Close()
                End If
                serialPortTracking.PortName = cboComPortTracking.Text
                serialPortTracking.BaudRate = cboBaudRateTracking.Text
                Try
                    With serialPortTracking
                        '.BaseStream.Dispose()
                        '.DataBits = 8
                        '.StopBits = 1
                        '.Parity = Ports.Parity.None
                        '.ReadTimeout = 20
                        .Open()
                    End With
                    bConnectedTracking = True
                    Call SaveRegSetting(sRootRegistry & "\Settings\Tracking", "Port", cboComPortTracking.Text)
                    Call SaveRegSetting(sRootRegistry & "\Settings\Tracking", "Baud Rate", cboBaudRateTracking.Text)
                    cmdConnectTracking.Text = GetResString(, "Disconnect")
                    lblStatusTracking.Text = GetResString(, "Connected_to", , , , serialPortTracking.PortName, serialPortTracking.BaudRate)
                    EnableTrackingButtons(False)

                    tmrTracking_Tick(sender, e)
                    tmrTracking.Enabled = True
                Catch e3 As Exception
                    bConnectedTracking = False
                    lblStatusTracking.Text = e3.Message
                    cmdConnectTracking.Text = GetResString(, "Connect")
                    EnableTrackingButtons(True)
                End Try
            Catch e2 As Exception
            End Try
        End If
    End Sub

    Private Sub tmrTracking_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrTracking.Tick
        Dim nLocalHeading As Single
        Dim nLocalAngle As Single
        Dim nLocalPan As Integer
        Dim nLocalTilt As Integer
        Dim nMiddleTilt As Integer
        Dim nMiddlePan As Integer
        Dim nLocalCourse As Integer

        If cboHertzTracking.SelectedIndex = 0 Or serialPortTracking.IsOpen = False Then
            Exit Sub
        End If

        tmrTracking.Interval = 1000 / cboHertzTracking.SelectedIndex

        If nTrackingOutputType = 0 Or nTrackingOutputType >= 4 Then
            tbarPan.Visible = True
            tbarTilt.Visible = True
            cmdTrackingCalibrate.Visible = True
        Else
            tbarPan.Visible = False
            tbarTilt.Visible = False
            cmdTrackingCalibrate.Visible = False
        End If

        If serialPortTracking.IsOpen = False Then
            If bConnectedTracking = True Then
                cmdConnectTracking_Click(sender, e)
            End If
            tmrTracking.Enabled = False
        Else
            Debug.Print(nLatitude)
            nLocalHeading = 0
            nLocalAngle = 0
            If nTrackingOutputType < 2 Or nTrackingOutputType >= 4 Then
                If nHomeLat <> "" And nHomeLong <> "" Then
                    If GetTrackingHeadingAngle(nHomeLat, nHomeLong, ConvertDistance(nHomeAlt, eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters), nLatitude, nLongitude, ConvertDistance(nAltitude, eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters), cboTrackingSet.SelectedIndex, nGroundSpeed, nHeading, nLocalHeading, nLocalAngle) = True Then
                        nLocalHeading = NormalizeHeading(nLocalHeading)

                        If bBackLobeTracker = True Then
                            If nLocalHeading > nTrackingAngleRight Then
                                nLocalHeading = nLocalHeading - 90
                            ElseIf nLocalHeading < nTrackingAngleLeft Then
                                nLocalHeading = nLocalHeading + 90
                            End If

                            nLocalHeading = NormalizeHeading(nLocalHeading)

                            If nLocalHeading > nTrackingAngleRight Then
                                nLocalHeading = nLocalHeading - 90
                                nLocalAngle = -nLocalAngle
                            ElseIf nLocalHeading < nTrackingAngleLeft Then
                                nLocalHeading = nLocalHeading + 90
                                nLocalAngle = -nLocalAngle
                            End If

                            nLocalHeading = NormalizeHeading(nLocalHeading)

                            If nLocalAngle < nTrackingAngleDown Then
                                nLocalAngle = nTrackingAngleDown
                            ElseIf nLocalAngle > nTrackingAngleUp Then
                                nLocalAngle = nTrackingAngleUp
                            End If

                        Else
                            If nLocalHeading > nTrackingAngleRight Or nLocalHeading < nTrackingAngleLeft Then
                                If Math.Abs(nTrackingAngleRight - nLocalHeading) < Math.Abs(nTrackingAngleLeft - nLocalHeading) Then
                                    nLocalHeading = nTrackingAngleRight
                                Else
                                    nLocalHeading = nTrackingAngleLeft
                                End If
                            End If
                        End If

                        Select Case nTrackingOutputType
                            Case 0, 4, 5, 6 'PanTilt, Melih, Pololu, Mini SSC II
                                nMiddlePan = ((nTrackingServoRight - nTrackingServoLeft) / (nTrackingAngleRight - nTrackingAngleLeft)) * Math.Abs(nTrackingAngleLeft) + nTrackingServoLeft
                                nMiddleTilt = ((nTrackingServoUp - nTrackingServoDown) / (nTrackingAngleUp - nTrackingAngleDown)) * Math.Abs(nTrackingAngleDown) + nTrackingServoDown

                                nLocalPan = ((nTrackingServoRight - nTrackingServoLeft) / (nTrackingAngleRight - nTrackingAngleLeft)) * nLocalHeading + nMiddlePan
                                nLocalTilt = ((nTrackingServoUp - nTrackingServoDown) / (nTrackingAngleUp - nTrackingAngleDown)) * nLocalAngle + nMiddleTilt

                                Try
                                    tbarPan.Value = nLocalPan
                                    tbarTilt.Value = nLocalTilt
                                Catch
                                End Try
                                'SendTrackingServo(nLocalPan, nLocalTilt)
                            Case 1 'Heading
                                SendTrackingAngle(nLocalHeading, nLocalAngle)
                        End Select
                    End If
                Else
                    lblStatusTracking.Text = "Home not set"
                End If
            Else
                Select Case nTrackingOutputType
                    Case 2 'LatLong
                        WriteTrackingSerialPort("!!!LAT:" & ConvertLocalToPeriod(nLatitude * 1000000) & ",LON:" & ConvertLocalToPeriod(nLongitude * 1000000) & ",ALT:" & ConvertLocalToPeriod(nAltitude.ToString("0")) & ",OFF:" & ConvertLocalToPeriod(cboTrackingSet.SelectedIndex) & "***")
                    Case 3 'ArduStation
                        'If nHeading > 180 Then
                        '    nLocalCourse = nHeading - 360
                        'Else
                        nLocalCourse = nHeading
                        'End If
                        WriteTrackingSerialPort("!!!LAT:" & ConvertLocalToPeriod((nLatitude * 1000000).ToString("0")) & ",LON:" & ConvertLocalToPeriod((nLongitude * 1000000).ToString("0")) & ",ALT:" & ConvertLocalToPeriod(ConvertDistance(nAltitude, eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters).ToString("0")) & ",ALH:" & ConvertLocalToPeriod((ConvertDistance(nWaypointAlt.ToString, eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters).ToString("0"))) & ",CRS:" & ConvertLocalToPeriod(nHeading.ToString("0")) & ",BER:" & ConvertLocalToPeriod(nHeading.ToString("0")) & ",SPD:" & ConvertLocalToPeriod((ConvertSpeed(nGroundSpeed.ToString, eSpeedUnits, e_SpeedFormat.e_SpeedFormat_MPerSec).ToString("0"))) & ",WPN:" & nWaypoint & ",DST:" & ConvertLocalToPeriod(ConvertDistance(nDistance.ToString, eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters).ToString("0")) & ",BTV:" & ConvertLocalToPeriod(nBattery.ToString("0.00")) & ",SAT:" & nSats & ",LOC:" & IIf(nFix = 1, 0, 1) & ",HDO:" & ConvertLocalToPeriod((nHDOP * 100).ToString) & ",OFF:" & cboTrackingSet.SelectedIndex & "***")
                        WriteTrackingSerialPort("+++ASP:" & ConvertLocalToPeriod((ConvertSpeed(nAirSpeed, eSpeedUnits, e_SpeedFormat.e_SpeedFormat_MPerSec)).ToString("0")) & ",RLL:" & ConvertLocalToPeriod(-nRoll.ToString("0")) & ",PCH:" & ConvertLocalToPeriod(-nPitch.ToString("0")) & ",THH:" & ConvertLocalToPeriod((nThrottle * 100).ToString("0")) & ",CRS:" & ConvertLocalToPeriod(nLocalCourse.ToString("0")) & "***")
                End Select
            End If
        End If
    End Sub

    Private Sub cmdTrackingCalibrate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTrackingCalibrate.Click
        tmrTracking.Enabled = False
        frmTrackingCalibrate.ShowDialog()
        If serialPortTracking.IsOpen = True Then
            tmrTracking.Enabled = True
        End If
    End Sub

    Public Sub SendTrackingServoPanTilt(Optional ByVal panValue As Integer = 1500, Optional ByVal tiltValue As Integer = 1500)
        WriteTrackingSerialPort("!!!PAN:" & panValue & ",TLT:" & tiltValue & "***")
    End Sub
    Public Sub SendTrackingServoDriver(ByVal servoNumber As Integer, ByVal outputValue As Integer)
        WriteTrackingSerialPort(servoNumber & outputValue.ToString("0000") & vbCr, False)
    End Sub
    Public Sub SendTrackingPololuDriver(ByVal servoNumber As Integer, ByVal outputValue As Integer)
        WriteTrackingSerialPort(Chr("&h80") & Chr("&h1") & Chr("&h4") & Chr(servoNumber) & GetPololuValue(outputValue), False)
    End Sub
    Public Sub SendTrackingMiniSSCDriver(ByVal servoNumber As Integer, ByVal outputValue As Integer)
        WriteTrackingSerialPort(Chr(255) & Chr(servoNumber) & Chr(outputValue), False)
    End Sub
    Public Sub WriteTrackingSerialPort(ByVal inputString As String, Optional ByVal sendCrLf As Boolean = True)
        Dim nCount As Integer
        Try
            If sendCrLf = True Then
                inputString = inputString & vbCrLf
            End If
            Dim outputBytes(0 To Len(inputString) - 1) As Byte
            For nCount = 0 To Len(inputString) - 1
                outputBytes(nCount) = Asc(inputString.Substring(nCount, 1))
            Next nCount

            'Dim encoding As New System.Text.UTF8Encoding()
            'outputBytes = encoding.GetBytes(inputString & IIf(sendCrLf = True, vbCrLf, ""))

            'nInputStringLength = nInputStringLength + nReadCount
            'serialPortIn.Encoding = System.Text.Encoding.UTF8 'System.Text.Encoding.GetEncoding(28591) '65001) '28591
            'nReadResult = serialPortIn.Read(cData, 0, nReadCount)  'Reading the Data

            'sNewString = System.Text.Encoding.Default.GetString(cData)
            'sBuffer = sBuffer & sNewString

            serialPortTracking.Write(outputBytes, 0, UBound(outputBytes) + 1)


            'serialPortTracking.Write(inputString & IIf(sendCrLf = True, vbCrLf, ""))

        Catch ex As Exception
            lblStatusTracking.Text = ex.Message
            If tmrTracking.Enabled = True Then
                Try
                    serialPortTracking.Close()
                    serialPortTracking.Open()
                Catch
                End Try
            End If
        End Try
    End Sub
    Public Sub SendTrackingAngle(Optional ByVal headingValue As Single = 0, Optional ByVal angleValue As Single = 0)
        WriteTrackingSerialPort("!!!HED:" & ConvertLocalToPeriod(headingValue.ToString("0.0")) & ",ANG:" & ConvertLocalToPeriod(angleValue.ToString("0.0")) & "***")
    End Sub

    Public Sub cboOutputTypeTracking_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOutputTypeTracking.SelectedIndexChanged
        Dim nDefaultLeft As Integer
        Dim nDefaultRight As Integer
        Dim nDefaultUp As Integer
        Dim nDefaultDown As Integer
        Dim nDefaultPan As Integer
        Dim nDefaultTilt As Integer

        nTrackingOutputType = CType(cboOutputTypeTracking.SelectedItem, cValueDesc).Value
        SaveRegSetting(sRootRegistry & "\Settings\Tracking", "Output Type", nTrackingOutputType)

        If nTrackingOutputType = 0 Or nTrackingOutputType >= 4 Then
            tbarPan.Visible = True
            tbarTilt.Visible = True
            cmdTrackingCalibrate.Visible = True
        Else
            tbarPan.Visible = False
            tbarTilt.Visible = False
            cmdTrackingCalibrate.Visible = False
        End If

        Select Case nTrackingOutputType
            Case 0, 4, 5, 6
                nTrackingAngleLeft = GetRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Angle Left", -180)
                nTrackingAngleRight = GetRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Angle Right", 180)
                nTrackingAngleUp = GetRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Angle Up", 90)
                nTrackingAngleDown = GetRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Angle Down", 0)

                If nTrackingOutputType = 6 Then 'Mini SSC II
                    nDefaultLeft = 15
                    nDefaultRight = 239
                    nDefaultUp = 239
                    nDefaultDown = 127
                ElseIf nTrackingOutputType = 5 Then 'Pololu
                    nDefaultLeft = 1500
                    nDefaultRight = 4500
                    nDefaultUp = 1500
                    nDefaultDown = 3000
                Else
                    nDefaultLeft = 1000
                    nDefaultRight = 2000
                    nDefaultUp = 2000
                    nDefaultDown = 1500
                End If

                nTrackingServoLeft = GetRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Servo Left", nDefaultLeft)
                nTrackingServoRight = GetRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Servo Right", nDefaultRight)
                nTrackingServoUp = GetRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Servo Up", nDefaultUp)
                nTrackingServoDown = GetRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Servo Down", nDefaultDown)

                If nTrackingServoLeft < nTrackingServoRight Then
                    tbarPan.Minimum = nTrackingServoLeft
                    tbarPan.Maximum = nTrackingServoRight
                Else
                    tbarPan.Minimum = nTrackingServoRight
                    tbarPan.Maximum = nTrackingServoLeft
                End If

                If nTrackingServoUp < nTrackingServoDown Then
                    tbarTilt.Minimum = nTrackingServoUp
                    tbarTilt.Maximum = nTrackingServoDown
                Else
                    tbarTilt.Minimum = nTrackingServoDown
                    tbarTilt.Maximum = nTrackingServoUp
                End If

                If nTrackingOutputType = 4 Then 'Melih
                    nDefaultPan = 1
                    nDefaultTilt = 2
                ElseIf nTrackingOutputType = 5 Or nTrackingOutputType = 6 Then 'Pololu or MiniSSC
                    nDefaultPan = 0
                    nDefaultTilt = 1
                End If

                nTrackingServoNumberPan = GetRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Servo Number Pan", nDefaultPan)
                nTrackingServoNumberTilt = GetRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Servo Number Tilt", nDefaultTilt)

                Try
                    tbarPan.Value = (tbarPan.Maximum - tbarPan.Minimum) / 2 + tbarPan.Minimum
                    tbarTilt.Value = (tbarTilt.Maximum - tbarTilt.Minimum) / 2 + tbarTilt.Minimum
                Catch
                End Try
        End Select

        If bStartup = True Then
            Exit Sub
        End If

        tmrTracking_Tick(Nothing, Nothing)
    End Sub

    Private Sub cboHertzTracking_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHertzTracking.SelectedIndexChanged
        SaveRegSetting(sRootRegistry & "\Settings\Tracking", "Hz", cboHertzTracking.SelectedIndex)
        If cboHertzTracking.SelectedIndex = 0 Then
            tmrTracking.Enabled = False
        Else
            tmrTracking.Enabled = True
        End If
    End Sub

    Private Sub tbarPan_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbarPan.ValueChanged, tbarTilt.ValueChanged
        If bStartup = True Or serialPortTracking.IsOpen = False Then
            Exit Sub
        End If
        Select Case nTrackingOutputType
            Case 0 'Pan Tilt - ArduPilot/Arduino
                SendTrackerMessage(, tbarPan.Value, tbarTilt.Value)
            Case Else
                If sender.name = "tbarPan" Then
                    SendTrackerMessage(nTrackingServoNumberPan, tbarPan.Value)
                Else
                    SendTrackerMessage(nTrackingServoNumberTilt, , tbarTilt.Value)
                End If
        End Select
    End Sub
    Public Sub SendTrackerMessage(Optional ByVal servoIndex As Integer = -1, Optional ByVal panValue As Integer = -1, Optional ByVal tiltValue As Integer = -1)
        Select Case nTrackingOutputType
            Case 0 'Pan Tilt - ArduPilot/Arduino
                If panValue = -1 Then
                    SendTrackingServoPanTilt(, tiltValue)
                ElseIf tiltValue = -1 Then
                    SendTrackingServoPanTilt(panValue, )
                Else
                    SendTrackingServoPanTilt(panValue, tiltValue)
                End If
            Case 4 ' Melih Servo Driver
                If panValue <> -1 Then
                    SendTrackingServoDriver(servoIndex, panValue)
                Else
                    SendTrackingServoDriver(servoIndex, tiltValue)
                End If
            Case 5 'Pololu
                If panValue <> -1 Then
                    SendTrackingPololuDriver(servoIndex, panValue)
                Else
                    SendTrackingPololuDriver(servoIndex, tiltValue)
                End If
            Case 6 'MiniSSC II
                If panValue <> -1 Then
                    SendTrackingMiniSSCDriver(servoIndex, panValue)
                Else
                    SendTrackingMiniSSCDriver(servoIndex, tiltValue)
                End If
        End Select
    End Sub
    Private Sub cboConfigDevice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboConfigDevice.SelectedIndexChanged
        Dim nCount As Integer

        If cboConfigDevice.SelectedIndex = -1 Then
            Exit Sub
        End If
        nConfigDevice = CType(cboConfigDevice.Items(cboConfigDevice.SelectedIndex), cValueDesc).Value
        SaveRegSetting(sRootRegistry & "\Settings", "Config Device", nConfigDevice)

        Select Case nConfigDevice
            Case e_ConfigDevice.e_ConfigDevice_AttoPilot
                sHomeIcon = "red00"
            Case Else
                sHomeIcon = "blackH"
        End Select

        'nWPCount = -1
        'ReDim aWPLat(0)
        'ReDim aWPLon(0)
        'ReDim aWPAlt(0)
        'ReDim aWPTrigger(0)
        'ReDim aWPSpeed(0)

        Select Case nConfigDevice
            Case e_ConfigDevice.e_ConfigDevice_Gluonpilot
                lblVehicle.Visible = False
                cboConfigVehicle.Visible = False

                grpMissionControlAtto.Visible = False
                grpMissionControlMavlink.Visible = True
                cmdMissionOverride.Visible = False
                cmdMissionMavlinkAdd.Visible = True
                grpMissionControlGeneric.Visible = False
                grpControlAtto.Visible = False
                grpControlMavlink.Visible = True

                LoadAPMVariables()
                LoadGluonVariables()

                LoadAttoParameterGrid()

                With cboMissionMavlinkCommand
                    .Items.Clear()

                    For nCount = 0 To UBound(aCommandName)
                        .Items.Add(New cValueDesc(aCommandValue(nCount), aCommandName(nCount)))
                    Next
                End With
                'LoadAttoSetFile()
                nParameterCount = -1

            Case e_ConfigDevice.e_ConfigDevice_Generic
                sConfigFormatString = "0.000000"

                lblVehicle.Visible = False
                cboConfigVehicle.Visible = False
                grpMissionControlAtto.Visible = False
                grpMissionControlMavlink.Visible = False
                cmdMissionOverride.Visible = False
                cmdMissionMavlinkAdd.Visible = False
                grpMissionControlGeneric.Visible = True
                grpControlAtto.Visible = False
                grpControlMavlink.Visible = False
                With cboMissionGenericOffset
                    .Items.Clear()
                    .Items.Add(GetResString(, "From_Sealevel", , , , , , , "From Sea Level"))
                    .Items.Add(GetResString(, "From_HomeAlt", , , , , , , "From Home Alt"))
                    .SelectedIndex = nConfigAltOffset
                End With
                nParameterCount = -1
                LoadAttoParameterGrid()
            Case e_ConfigDevice.e_ConfigDevice_AttoPilot
                sConfigFormatString = "0.00000"

                nConfigAltOffset = e_AltOffset.e_AltOffset_HomeALt
                dgConfigVariable.Enabled = False
                cmdConfigWrite.Enabled = False
                'dgMission.Enabled = False
                cmdMissionAttoWrite.Enabled = False

                lblVehicle.Visible = True
                cboConfigVehicle.Visible = True
                grpMissionControlGeneric.Visible = False
                grpMissionControlAtto.Visible = True
                grpMissionControlMavlink.Visible = False
                cmdMissionOverride.Visible = False
                cmdMissionMavlinkAdd.Visible = False
                grpControlAtto.Visible = True
                grpControlMavlink.Visible = False

                LoadAttoCombos()

                With cboMissionAttoLoiterDirection
                    .Items.Clear()
                    .Items.Add("Clockwise")
                    .Items.Add("Counter Clockwise")
                End With

                With cboMissionAttoReversePath
                    .Items.Clear()
                    .Items.Add("Next Waypoint")
                    .Items.Add("Reverse Home")
                End With

                LoadAttoSetFile()
                LoadAttoParameterGrid()
            Case e_ConfigDevice.e_ConfigDevice_MAVlink
                LoadAPMVariables()

                With cboControlMavlinkMode
                    .Items.Clear()
                    For nCount = 1 To UBound(aModeName)
                        .Items.Add(New cValueDesc(aModeValue(nCount), aModeName(nCount)))
                    Next
                    .SelectedIndex = 0
                End With

                With cboControlMavlinkAction
                    .Items.Clear()
                    .Items.Add(New cValueDesc(11, GetMavAction(11)))
                    .Items.Add(New cValueDesc(12, GetMavAction(12)))
                    .Items.Add(New cValueDesc(13, GetMavAction(13)))
                    .Items.Add(New cValueDesc(27, GetMavAction(27)))
                    .Items.Add(New cValueDesc(3, GetMavAction(3)))
                    '.Items.Add(New cValueDesc(25, GetMavAction(25)))
                    'For nCount = 1 To 35
                    '    .Items.Add(New cValueDesc(nCount, GetMavAction(nCount)))
                    'Next
                    .SelectedIndex = 0
                End With

                sConfigFormatString = "0.000000"

                nConfigAltOffset = e_AltOffset.e_AltOffset_HomeALt
                dgConfigVariable.Enabled = False
                cmdConfigWrite.Enabled = False
                'dgMission.Enabled = False
                cmdMissionMavlinkWrite.Enabled = False

                lblVehicle.Visible = True
                cboConfigVehicle.Visible = True
                grpMissionControlGeneric.Visible = False
                grpMissionControlAtto.Visible = False
                grpMissionControlMavlink.Visible = True
                cmdMissionOverride.Visible = False
                cmdMissionMavlinkAdd.Visible = True
                grpControlAtto.Visible = False
                grpControlMavlink.Visible = True

                With cboMissionMavlinkCommand
                    .Items.Clear()

                    For nCount = 0 To UBound(aCommandName)
                        .Items.Add(New cValueDesc(aCommandValue(nCount), aCommandName(nCount)))
                    Next
                End With
                'LoadAttoSetFile()
                nParameterCount = -1
                LoadMavlinkSetFile()
                LoadMavlinkParameterGrid()
        End Select

        If bStartup = False Then
            ResetForm()
            'If nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot Then
            '    cboMission.SelectedIndex = 0
            'End If
        End If
        LoadMissionGrid()
        UpdateMissionGE()
    End Sub
    Public Function CintX(ByVal inputValue As VariantType) As Integer
        Try
            If IsNumeric(inputValue) = True Then
                CintX = Convert.ToInt32(inputValue)
            Else
                CintX = 0
            End If
        Catch
            CintX = 0
        End Try
    End Function
    Public Sub LoadAttoCombos()
        Dim nCount As Integer
        Dim sPartOne As String

        Try
            cboMissionAttoLoiter.Items.Clear()
            cboMissionAttoLoiter.Items.Add("No Loiter")

            cboMissionAttoLoiterDuration.Items.Clear()

            cboMissionAttoTriggerControl.Items.Clear()
            cboMissionAttoTriggerControl.Items.Add("None")
            cboMissionAttoTriggerControl.Items.Add("At Waypoint")

            cboMissionAttoAltitudeControl.Items.Clear()
            cboMissionAttoAltitudeControl.Items.Add("No Control")

            For nCount = 0 To UBound(aIDs)
                Select Case aIDs(nCount)
                    Case "$42"
                        sPartOne = aValue(nCount)
                    Case "$43"
                        cboMissionAttoAltitudeControl.Items.Add("Loiter " & sPartOne & "," & CintX(aValue(nCount)) & " ($42,$43)")

                    Case "$69"
                        cboMissionAttoLoiter.Items.Add("Radius " & CintX(aValue(nCount)) & GetShortDistanceUnits() & " (" & aIDs(nCount) & ")")
                    Case "$70"
                        cboMissionAttoLoiter.Items.Add("Radius " & CintX(aValue(nCount)) & GetShortDistanceUnits() & " (" & aIDs(nCount) & ")")
                    Case "$71"
                        cboMissionAttoLoiter.Items.Add("Radius " & CintX(aValue(nCount)) & GetShortDistanceUnits() & " (" & aIDs(nCount) & ")")
                    Case "$72"
                        cboMissionAttoLoiter.Items.Add("Radius " & CintX(aValue(nCount)) & GetShortDistanceUnits() & " (" & aIDs(nCount) & ")")
                    Case "$73"
                        cboMissionAttoLoiter.Items.Add("Radius " & CintX(aValue(nCount)) & GetShortDistanceUnits() & " (" & aIDs(nCount) & ")")
                    Case "$74"
                        cboMissionAttoLoiter.Items.Add("Radius " & CintX(aValue(nCount)) & GetShortDistanceUnits() & " (" & aIDs(nCount) & ")")
                    Case "$75"
                        cboMissionAttoLoiter.Items.Add("Radius " & CintX(aValue(nCount)) & GetShortDistanceUnits() & " (" & aIDs(nCount) & ")")
                    Case "$76"
                        cboMissionAttoLoiter.Items.Add("Radius " & CintX(aValue(nCount)) & GetShortDistanceUnits() & " (" & aIDs(nCount) & ")")
                    Case "$77"
                        cboMissionAttoLoiter.Items.Add("Radius " & CintX(aValue(nCount)) & GetShortDistanceUnits() & " (" & aIDs(nCount) & ")")

                    Case "$78"
                        cboMissionAttoLoiterDuration.Items.Add("Duration " & CintX(aValue(nCount)) & " " & GetResString(, "secs") & " (" & aIDs(nCount) & ")")
                    Case "$79"
                        cboMissionAttoLoiterDuration.Items.Add("Duration " & CintX(aValue(nCount)) & " " & GetResString(, "secs") & " (" & aIDs(nCount) & ")")
                    Case "$80"
                        cboMissionAttoLoiterDuration.Items.Add("Duration " & CintX(aValue(nCount)) & " " & GetResString(, "secs") & " (" & aIDs(nCount) & ")")
                    Case "$81"
                        cboMissionAttoLoiterDuration.Items.Add("Duration " & CintX(aValue(nCount)) & " " & GetResString(, "secs") & " (" & aIDs(nCount) & ")")
                    Case "$82"
                        cboMissionAttoLoiterDuration.Items.Add("Duration " & CintX(aValue(nCount)) & " " & GetResString(, "secs") & " (" & aIDs(nCount) & ")")
                    Case "$83"
                        cboMissionAttoLoiterDuration.Items.Add("Duration " & CintX(aValue(nCount)) & " " & GetResString(, "secs") & " (" & aIDs(nCount) & ")")
                    Case "$84"
                        cboMissionAttoLoiterDuration.Items.Add("Duration " & CintX(aValue(nCount)) & " " & GetResString(, "secs") & " (" & aIDs(nCount) & ")")
                    Case "$85"
                        cboMissionAttoLoiterDuration.Items.Add("Duration " & CintX(aValue(nCount)) & " " & GetResString(, "secs") & " (" & aIDs(nCount) & ")")

                    Case "$87"
                        cboMissionAttoTriggerControl.Items.Add("Time " & CintX(aValue(nCount)) & " " & GetResString(, "secs") & " (" & aIDs(nCount) & ")")
                    Case "$88"
                        cboMissionAttoTriggerControl.Items.Add("Time " & CintX(aValue(nCount)) & " " & GetResString(, "secs") & " (" & aIDs(nCount) & ")")
                    Case "$89"
                        cboMissionAttoTriggerControl.Items.Add("Time " & CintX(aValue(nCount)) & " " & GetResString(, "secs") & " (" & aIDs(nCount) & ")")
                    Case "$90"
                        cboMissionAttoTriggerControl.Items.Add("Time " & CintX(aValue(nCount)) & " " & GetResString(, "secs") & " (" & aIDs(nCount) & ")")

                    Case "$91"
                        cboMissionAttoTriggerControl.Items.Add("Distance " & CintX(aValue(nCount)) & GetShortDistanceUnits() & " (" & aIDs(nCount) & ")")
                    Case "$92"
                        cboMissionAttoTriggerControl.Items.Add("Distance " & CintX(aValue(nCount)) & GetShortDistanceUnits() & " (" & aIDs(nCount) & ")")
                    Case "$93"
                        cboMissionAttoTriggerControl.Items.Add("Distance " & CintX(aValue(nCount)) & GetShortDistanceUnits() & " (" & aIDs(nCount) & ")")
                    Case "$94"
                        cboMissionAttoTriggerControl.Items.Add("Distance " & CintX(aValue(nCount)) & GetShortDistanceUnits() & " (" & aIDs(nCount) & ")")

                End Select
            Next



            With cboMissionAttoAltitudeControl
                .Items.Clear()
                .Items.Add("No Control")
                .Items.Add("Loiter $42,$43")
            End With
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try

    End Sub
    Private Sub LoadGluonVariables()
        Dim sFileContents As String
        Dim sSplit() As String
        Dim sSplit2() As String
        Dim nCount As Integer
        Dim ncount2 As Integer
        Dim nNext As Integer
        Dim sComment As String

        ReDim aIDs(0)
        ReDim aName(0)
        ReDim aMin(0)
        ReDim aMax(0)
        ReDim aValue(0)
        ReDim aVisible(0)
        ReDim aMultiplier(0)
        ReDim aAdder(0)
        ReDim aBit(0)
        ReDim aDefault(0)
        ReDim aComments(0)

        nNext = 0
        'sFileContents = GetFileContents(GetRootPath() & "\SetConfig.txt")
        sFileContents = HK_GCS.My.Resources.TextFiles.GluonSetConfig.ToString

        If sFileContents <> "" Then
            sSplit = Split(sFileContents, vbCrLf)
            For nCount = 0 To UBound(sSplit)
                sComment = ""
                If Trim(sSplit(nCount)) <> "" And Microsoft.VisualBasic.Left(Trim(sSplit(nCount)), 2) <> "//" Then
                    sSplit2 = Split(sSplit(nCount), ",")

                    ReDim Preserve aIDs(0 To nNext)
                    ReDim Preserve aName(0 To nNext)
                    ReDim Preserve aMin(0 To nNext)
                    ReDim Preserve aMax(0 To nNext)
                    ReDim Preserve aDefault(0 To nNext)
                    ReDim Preserve aComments(0 To nNext)
                    ReDim Preserve aMultiplier(0 To nNext)
                    ReDim Preserve aAdder(0 To nNext)
                    ReDim Preserve aBit(0 To nNext)

                    aIDs(nNext) = sSplit2(0)
                    aName(nNext) = sSplit2(1)
                    aMin(nNext) = sSplit2(2)
                    aMax(nNext) = sSplit2(3)
                    aDefault(nNext) = sSplit2(4)
                    aMultiplier(nNext) = sSplit2(5)
                    aAdder(nNext) = sSplit2(6)
                    aBit(nNext) = sSplit2(7)
                    For ncount2 = 8 To UBound(sSplit2)
                        If sComment <> "" Then
                            sComment = sComment & ","
                        End If
                        sComment = sComment & sSplit2(ncount2)
                    Next ncount2
                    aComments(nNext) = sComment

                    nNext = nNext + 1
                End If
            Next nCount
        End If
        nParameterCount = UBound(aIDs)
        ReDim aValue(0 To nParameterCount)
        ReDim aChanged(0 To nParameterCount)

        For nCount = 0 To nParameterCount
            aValue(nCount) = ""
            aChanged(nCount) = False
        Next

        cmdConfigWrite.Enabled = False
    End Sub
    Private Sub LoadAPMVariables()
        ReDim aCommandName(0)
        ReDim aCommandValue(0)
        ReDim aModeName(0)
        ReDim aModeValue(0)
        ReDim aCommandArg1(0)
        ReDim aCommandArg2(0)
        ReDim aCommandArg3(0)
        ReDim aCommandArg4(0)
        ReDim aCommandArg5(0)
        ReDim aCommandArg6(0)
        ReDim aCommandArg7(0)

        ReDim aCommandUnit1(0)
        ReDim aCommandUnit2(0)
        ReDim aCommandUnit3(0)
        ReDim aCommandUnit4(0)
        ReDim aCommandUnit5(0)
        ReDim aCommandUnit6(0)
        ReDim aCommandUnit7(0)

        ReDim aCommandMult1(0)
        ReDim aCommandMult2(0)
        ReDim aCommandMult3(0)
        ReDim aCommandMult4(0)
        ReDim aCommandMult5(0)
        ReDim aCommandMult6(0)
        ReDim aCommandMult7(0)

        ReDim aCommandFormat1(0)
        ReDim aCommandFormat2(0)
        ReDim aCommandFormat3(0)
        ReDim aCommandFormat4(0)
        ReDim aCommandFormat5(0)
        ReDim aCommandFormat6(0)
        ReDim aCommandFormat7(0)

        Dim sFileContents As String
        Dim sSplit() As String
        Dim sSplit2() As String
        Dim nCount As Integer
        Dim ncount2 As Integer
        Dim nCount3 As Integer
        Dim nNext As Integer
        Dim sComment As String
        Dim sParamName As String

        Select Case nConfigDevice
            Case e_ConfigDevice.e_ConfigDevice_MAVlink
                sFileContents = HK_GCS.My.Resources.TextFiles.APMCommands.ToString
            Case e_ConfigDevice.e_ConfigDevice_Gluonpilot
                sFileContents = HK_GCS.My.Resources.TextFiles.GluonCommands.ToString
        End Select

        nNext = -1
        If sFileContents <> "" Then
            sSplit = Split(sFileContents, vbCrLf)
            For nCount = 0 To UBound(sSplit)
                sComment = ""
                If Trim(sSplit(nCount)) <> "" And Microsoft.VisualBasic.Left(Trim(sSplit(nCount)), 2) <> "//" Then
                    sSplit2 = Split(sSplit(nCount), ",")

                    nNext = nNext + 1
                    ReDim Preserve aCommandName(0 To nNext)
                    ReDim Preserve aCommandValue(0 To nNext)
                    ReDim Preserve aCommandArg1(0 To nNext)
                    ReDim Preserve aCommandArg2(0 To nNext)
                    ReDim Preserve aCommandArg3(0 To nNext)
                    ReDim Preserve aCommandArg4(0 To nNext)
                    ReDim Preserve aCommandArg5(0 To nNext)
                    ReDim Preserve aCommandArg6(0 To nNext)
                    ReDim Preserve aCommandArg7(0 To nNext)

                    ReDim Preserve aCommandUnit1(0 To nNext)
                    ReDim Preserve aCommandUnit2(0 To nNext)
                    ReDim Preserve aCommandUnit3(0 To nNext)
                    ReDim Preserve aCommandUnit4(0 To nNext)
                    ReDim Preserve aCommandUnit5(0 To nNext)
                    ReDim Preserve aCommandUnit6(0 To nNext)
                    ReDim Preserve aCommandUnit7(0 To nNext)

                    ReDim Preserve aCommandMult1(0 To nNext)
                    ReDim Preserve aCommandMult2(0 To nNext)
                    ReDim Preserve aCommandMult3(0 To nNext)
                    ReDim Preserve aCommandMult4(0 To nNext)
                    ReDim Preserve aCommandMult5(0 To nNext)
                    ReDim Preserve aCommandMult6(0 To nNext)
                    ReDim Preserve aCommandMult7(0 To nNext)

                    ReDim Preserve aCommandFormat1(0 To nNext)
                    ReDim Preserve aCommandFormat2(0 To nNext)
                    ReDim Preserve aCommandFormat3(0 To nNext)
                    ReDim Preserve aCommandFormat4(0 To nNext)
                    ReDim Preserve aCommandFormat5(0 To nNext)
                    ReDim Preserve aCommandFormat6(0 To nNext)
                    ReDim Preserve aCommandFormat7(0 To nNext)

                    aCommandValue(nNext) = CDec(sSplit2(0))
                    aCommandName(nNext) = sSplit2(1)

                    If UBound(sSplit2) >= 2 Then
                        aCommandArg1(nNext) = sSplit2(2)
                        ParseCommandMessage(aCommandArg1(nNext), aCommandUnit1(nNext), aCommandMult1(nNext), aCommandFormat1(nNext))
                    End If
                    If UBound(sSplit2) >= 3 Then
                        aCommandArg2(nNext) = sSplit2(3)
                        ParseCommandMessage(aCommandArg2(nNext), aCommandUnit2(nNext), aCommandMult2(nNext), aCommandFormat2(nNext))
                    End If
                    If UBound(sSplit2) >= 4 Then
                        aCommandArg3(nNext) = sSplit2(4)
                        ParseCommandMessage(aCommandArg3(nNext), aCommandUnit3(nNext), aCommandMult3(nNext), aCommandFormat3(nNext))
                    End If
                    If UBound(sSplit2) >= 5 Then
                        aCommandArg4(nNext) = sSplit2(5)
                        ParseCommandMessage(aCommandArg4(nNext), aCommandUnit4(nNext), aCommandMult4(nNext), aCommandFormat4(nNext))
                    End If
                    If UBound(sSplit2) >= 6 Then
                        aCommandArg5(nNext) = sSplit2(6)
                        ParseCommandMessage(aCommandArg5(nNext), aCommandUnit5(nNext), aCommandMult5(nNext), aCommandFormat5(nNext))
                    End If
                    If UBound(sSplit2) >= 7 Then
                        aCommandArg6(nNext) = sSplit2(7)
                        ParseCommandMessage(aCommandArg6(nNext), aCommandUnit6(nNext), aCommandMult6(nNext), aCommandFormat6(nNext))
                    End If
                    If UBound(sSplit2) >= 8 Then
                        aCommandArg7(nNext) = sSplit2(8)
                        ParseCommandMessage(aCommandArg7(nNext), aCommandUnit7(nNext), aCommandMult7(nNext), aCommandFormat7(nNext))
                    End If
                End If
            Next nCount
        End If

        Select Case nConfigDevice
            Case e_ConfigDevice.e_ConfigDevice_MAVlink
                sFileContents = HK_GCS.My.Resources.TextFiles.APMModes.ToString
                nNext = -1
                ReDim aModeName(0)
                ReDim aModeValue(0)
                If sFileContents <> "" Then
                    sSplit = Split(sFileContents, vbCrLf)
                    For nCount = 0 To UBound(sSplit)
                        sComment = ""
                        If Trim(sSplit(nCount)) <> "" And Microsoft.VisualBasic.Left(Trim(sSplit(nCount)), 2) <> "//" Then
                            sSplit2 = Split(sSplit(nCount), ",")

                            'For nCount3 = 0 To UBound(aValue)
                            nNext = nNext + 1
                            ReDim Preserve aModeName(0 To nNext)
                            ReDim Preserve aModeValue(0 To nNext)

                            aModeName(nNext) = sSplit2(0)
                            aModeValue(nNext) = CDec(sSplit2(1))
                            'Next nCount3
                        End If
                    Next nCount
                End If
        End Select
    End Sub

    Private Function GetCommandName(ByVal inputValue As Integer) As String
        Dim nCount As Integer
        GetCommandName = ""

        For nCount = 0 To UBound(aCommandValue)
            If aCommandValue(nCount) = inputValue Then
                GetCommandName = aCommandName(nCount)
                Exit For
            End If
        Next
        If GetCommandName = "" Then
            GetCommandName = "Unknown"
        End If
    End Function
    Private Function GetCommandIndex(ByVal inputValue As Integer) As Integer
        Dim nCount As Integer

        For nCount = 0 To UBound(aCommandValue)
            If aCommandValue(nCount) = inputValue Then
                GetCommandIndex = nCount
                Exit For
            End If
        Next
    End Function
    Private Function AddDataColumn(ByVal columnName As String, Optional ByVal readOnlyValue As Boolean = True, Optional ByVal columnDataType As String = "System.String") As DataColumn
        AddDataColumn = New DataColumn
        With AddDataColumn
            .DataType = System.Type.GetType(columnDataType)
            .ColumnName = columnName
            .ReadOnly = readOnlyValue
        End With
    End Function
    Private Function AddButtonColumn(ByVal columnName As String, ByVal buttonText As String, ByVal toolTipText As String, ByVal tagString As String) As DataGridViewImageColumn
        AddButtonColumn = New DataGridViewImageColumn
        With AddButtonColumn
            .Name = columnName
            '.Text = buttonText
            .ToolTipText = toolTipText
            .Tag = tagString
            '.UseColumnTextForButtonValue = True
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Image = My.Resources.Play
        End With
    End Function
    Public Sub LoadMissionGrid(Optional ByVal selectedIndex As Integer = 0)
        Dim nCount As Integer
        Dim nCount2 As Integer
        Dim nLastSelected As Integer
        Dim bPrevValue As Boolean
        Dim nLastTop As Integer
        Dim firstVisibleRow As Integer
        Dim lastVisibleRow As Integer
        Dim nCommandIndex As Integer

        bPrevValue = bLockMissionCenter
        bLockMissionCenter = True
        nLastTop = dgMission.FirstDisplayedScrollingRowIndex
        dgMission.SuspendLayout()
        'dgMission.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
        dgMission.ClearSelection()
        dgMission.Columns.Clear()
        dt = New DataTable
        dgMission.DataSource = dt
        Try
            If nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot Then
                dt.Columns.Add(AddDataColumn("#", False))
                dt.Columns.Add(AddDataColumn("Latitude", False))
                dt.Columns.Add(AddDataColumn("Longitude", False))
                dt.Columns.Add(AddDataColumn("Alt", False))
                dt.Columns.Add(AddDataColumn("Trigger", False))
                dt.Columns.Add(AddDataColumn("Speed", False))

                For nCount = 0 To nWPCount
                    drow = dt.NewRow

                    drow(0) = nCount ' aWPNum(nCount)
                    drow(1) = aWPLat(nCount)
                    drow(2) = aWPLon(nCount)
                    drow(3) = aWPAlt(nCount)
                    If nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot Then
                        drow(4) = aWPTrigger(nCount)
                        drow(5) = aWPSpeed(nCount)
                    End If

                    dt.Rows.Add(drow)
                Next
            ElseIf nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink Then
                dt.Columns.Add(AddDataColumn("#", False))
                dt.Columns.Add(AddDataColumn("Command", False))
                dt.Columns.Add(AddDataColumn("Var 1", False))
                dt.Columns.Add(AddDataColumn("Var 2", False))
                dt.Columns.Add(AddDataColumn("Var 3", False))
                dt.Columns.Add(AddDataColumn("Var 4", False))
                dt.Columns.Add(AddDataColumn("Latitude", False))
                dt.Columns.Add(AddDataColumn("Longitude", False))
                dt.Columns.Add(AddDataColumn("Altitude", False))

                For nCount = 0 To nWPCount
                    drow = dt.NewRow

                    drow(0) = nCount ' aWPNum(nCount)

                    nCommandIndex = GetCommandIndex(aWPCommand(nCount))

                    drow(1) = GetCommandName(aWPCommand(nCount))
                    If aCommandArg1(nCommandIndex) <> "" Then
                        drow(2) = aWPOther(nCount)
                    End If
                    If aCommandArg2(nCommandIndex) <> "" Then
                        drow(3) = aWPOther2(nCount)
                    End If
                    If aCommandArg3(nCommandIndex) <> "" Then
                        drow(4) = aWPOther3(nCount)
                    End If
                    If aCommandArg4(nCommandIndex) <> "" Then
                        drow(5) = aWPOther4(nCount)
                    End If
                    If aCommandArg5(nCommandIndex) <> "" Then
                        drow(6) = aWPLat(nCount)
                    End If
                    If aCommandArg6(nCommandIndex) <> "" Then
                        drow(7) = aWPLon(nCount)
                    End If
                    If aCommandArg7(nCommandIndex) <> "" Then
                        drow(8) = aWPAlt(nCount)
                    End If
                    dt.Rows.Add(drow)
                Next
            End If
        Catch
        End Try

        'Try

        dgMission.DataSource = dt
        'dgMission.FirstDisplayedScrollingRowIndex = selectedIndex

        'If dgMission.Columns.Count = 6 Then
        dgMission.Columns.Add(AddButtonColumn("Del", "X", "Delete Waypoint", "Delete"))
        dgMission.Columns.Add(AddButtonColumn("Up", "", "Move Waypoint Up", "Up"))
        dgMission.Columns.Add(AddButtonColumn("Dn", "", "Move Waypoint Down", "Down"))
        'End If
        'dgMission.Refresh()

        'dgMission.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        If dgMission.Rows.Count - 1 >= selectedIndex Then
            'dgMission.SelectedRows(selectedIndex).Selected = True
            dgMission.Rows(selectedIndex).Selected = True

            firstVisibleRow = dgMission.HitTest(dgMission.RowTemplate.Height, dgMission.Columns(0).Width).RowIndex
            lastVisibleRow = firstVisibleRow + dgMission.DisplayedRowCount(False)

            If selectedIndex < firstVisibleRow Or selectedIndex > lastVisibleRow Then
                dgMission.FirstDisplayedScrollingRowIndex = selectedIndex
            End If
        End If


        dgMission.ReadOnly = True
        dgMission.ResumeLayout()
        'Catch
        'End Try
        Select Case nConfigDevice
            Case e_ConfigDevice.e_ConfigDevice_AttoPilot
                nLastSelected = cboControlAttoWPNumber.SelectedIndex
                With cboControlAttoWPNumber
                    .Items.Clear()
                    For nCount = 0 To nWPCount
                        'Select Case nCount
                        'Case 0
                        '    .Items.Add(nCount) '& " (Home)")
                        'Case 1
                        '    .Items.Add(nCount) '& " (Rally)")
                        'Case Else
                        .Items.Add("WP #" & nCount)
                        'End Select
                        If .Items.Count - 1 = nLastSelected Then
                            .SelectedIndex = .Items.Count - 1
                        End If
                    Next
                    If .SelectedIndex = -1 And nWPCount > 0 Then
                        .SelectedIndex = 0
                    End If
                End With
            Case e_ConfigDevice.e_ConfigDevice_MAVlink
                nLastSelected = cboControlMavlinkWPNumber.SelectedIndex
                With cboControlMavlinkWPNumber
                    .Items.Clear()
                    For nCount = 0 To nWPCount
                        Select Case nCount
                            Case 0
                                .Items.Add(nCount & " (Home)")
                            Case Else
                                .Items.Add(nCount)
                        End Select
                        If .Items.Count - 1 = nLastSelected Then
                            .SelectedIndex = .Items.Count - 1
                        End If
                    Next
                    If .SelectedIndex = -1 And nWPCount > 0 Then
                        .SelectedIndex = 0
                    End If
                End With
        End Select

        If nWPCount >= 0 Then
            cmdMissionAttoWrite.Enabled = True
            cmdMissionMavlinkWrite.Enabled = True
            cmdMissionOverride.Enabled = True
            cmdMissionSaveAs.Enabled = True
        Else
            cmdMissionAttoWrite.Enabled = True
            cmdMissionMavlinkWrite.Enabled = False
            cmdMissionOverride.Enabled = False
            cmdMissionSaveAs.Enabled = False
        End If
        VerifyAddButton()
        bLockMissionCenter = bPrevValue
    End Sub
    Public Sub LoadMavlinkParameterGrid(Optional ByVal selectedRowID As String = "")
        Dim nCount As Integer
        Dim nCount2 As Integer
        Dim nLastSelected As Integer = -1

        Try
            If selectedRowID = "" Then
                If dgConfigVariable.SelectedCells.Count > 0 Then
                    nLastSelected = dgConfigVariable.SelectedCells(0).RowIndex
                End If
            End If

            If nParameterCount > 0 Then
                Try
                    dt = New DataTable

                    dt.Columns.Add(AddDataColumn("Name"))
                    dt.Columns.Add(AddDataColumn("Min"))
                    dt.Columns.Add(AddDataColumn("Max"))
                    dt.Columns.Add(AddDataColumn("Value", False))
                    dt.Columns.Add(AddDataColumn("Default"))
                    dt.Columns.Add(AddDataColumn("Comment"))
                Catch
                End Try

                LoadMavlinkSetFile()

                Try
                    For nCount = 0 To nParameterCount

                        If Not aName(nCount) Is Nothing Then
                            If aName(nCount) <> "" And aVisible(nCount) = True Then
                                drow = dt.NewRow
                                'Debug.Print(aName(nCount))
                                'drow(0) = Mid(aName(nCount), 1, InStr(aName(nCount), Chr(0)) - 1) 'aName(nCount)
                                drow(0) = aName(nCount)
                                drow(1) = aMin(nCount)
                                drow(2) = aMax(nCount)
                                If IsNumeric(aMultiplier(nCount)) = True Then
                                    If IsNumeric(aValue(nCount)) = True Then
                                        drow(3) = aValue(nCount) / aMultiplier(nCount)
                                    Else
                                        drow(3) = ""
                                    End If
                                    If IsNumeric(aDefault(nCount)) = True Then
                                        drow(4) = aDefault(nCount) / aMultiplier(nCount)
                                    Else
                                        drow(4) = ""
                                    End If
                                Else
                                    If Len(aName(nCount)) >= 12 Then
                                        If aName(nCount).Substring(0, 12) = "FLIGHT_MODE_" Then
                                            If IsNumeric(aValue(nCount)) = True Then
                                                drow(3) = GetControlModeByInteger(aValue(nCount))
                                                drow(4) = GetControlModeByInteger(aDefault(nCount))
                                            Else
                                                drow(3) = ""
                                                drow(4) = ""
                                            End If
                                        Else
                                            drow(3) = aValue(nCount)
                                            drow(4) = aDefault(nCount)
                                        End If
                                    Else
                                        drow(3) = aValue(nCount)
                                        drow(4) = aDefault(nCount)
                                    End If
                                End If
                                drow(5) = aComments(nCount)

                                dt.Rows.Add(drow)

                                If nLastSelected = -1 And selectedRowID <> "" Then
                                    If aName(nCount) = selectedRowID Then
                                        nLastSelected = nCount
                                    End If
                                End If
                            End If
                        End If
                    Next

                Catch
                End Try
                SetConfigStatus(lblConfigStatus.Text & " (" & dt.Rows.Count & " parameters)")
                dgConfigVariable.DataSource = dt
            Else
                dgConfigVariable.Visible = False
                dt.Rows.Clear()
                dgConfigVariable.DataSource = Nothing
            End If
            If nLastSelected = -1 Then
                SetConfigSelectedRowCol(0, 3)
            Else
                SetConfigSelectedRowCol(nLastSelected, 3)
            End If
            dgConfigVariable.Refresh()
            'dgConfigVariable.Columns("Comment").DisplayIndex = 6
            dgConfigVariable.Enabled = True
            dgConfigVariable.Visible = True

            dgConfigVariable.Focus()
        Catch ex As Exception
        End Try
    End Sub
    Private Function SetConfigSelectedRowCol(Optional ByVal row As Integer = -1, Optional ByVal col As Integer = -1)
        Dim nSelectedRow As Integer
        Dim nSelectedCol As Integer

        If bStartup = True Then
            Exit Function
        End If

        Try
            dgConfigVariable.Visible = True
            If dgConfigVariable.SelectedCells.Count > 0 Then
                If row = -1 Then
                    nSelectedRow = dgConfigVariable.SelectedCells(0).RowIndex
                Else
                    nSelectedRow = row
                End If
                If col = -1 Then
                    nSelectedCol = dgConfigVariable.SelectedCells(0).ColumnIndex
                Else
                    nSelectedCol = col
                End If
            Else
                nSelectedRow = row
                nSelectedCol = col
                If nSelectedRow = -1 Then
                    nSelectedRow = 0
                End If
                If nSelectedCol = -1 Then
                    nSelectedCol = 0
                End If
            End If
            If dgConfigVariable.Rows.Count - 1 >= nSelectedRow Then
                dgConfigVariable.CurrentCell.Selected = False
                dgConfigVariable.Rows(nSelectedRow).Cells(nSelectedCol).Selected = True
                dgConfigVariable.CurrentCell = dgConfigVariable.SelectedCells(0)
            End If
        Catch
        End Try
    End Function
    Private Function GetControlModeByInteger(ByVal inputNumber As Integer) As String
        Select Case inputNumber
            'Case 0
            '    GetControlModeByInteger = "MANUAL"
            Case 1
                GetControlModeByInteger = "CIRCLE"
            Case 2
                GetControlModeByInteger = "STABILIZE"
            Case 5
                GetControlModeByInteger = "FLY_BY_WIRE_A"
            Case 6
                GetControlModeByInteger = "FLY_BY_WIRE_B"
            Case 10
                GetControlModeByInteger = "AUTO"
            Case 11
                GetControlModeByInteger = "RTL"
            Case 12
                GetControlModeByInteger = "LOITER"
                'Case 13
                '    GetControlModeByInteger = "TAKEOFF"
                'Case 14
                '    GetControlModeByInteger = "LAND"
                'Case 16
                '    GetControlModeByInteger = "WAYPOINT"
            Case Else
                GetControlModeByInteger = "UNKNOWN!"
        End Select
    End Function
    Private Function GetControlModeByString(ByVal inputString As String) As Integer
        Select Case UCase(inputString)
            'Case "MANUAL"
            '    GetControlModeByString = 0
            Case "CIRCLE"
                GetControlModeByString = 1
            Case "STABILIZE"
                GetControlModeByString = 2
            Case "FLY_BY_WIRE_A"
                GetControlModeByString = 5
            Case "FLY_BY_WIRE_B"
                GetControlModeByString = 6
            Case "AUTO"
                GetControlModeByString = 10
            Case "RTL"
                GetControlModeByString = 11
                'Case "LOITER"
                '    GetControlModeByString = 12
                'Case "TAKEOFF"
                '    GetControlModeByString = 13
                'Case "LAND"
                '    GetControlModeByString = 14
            Case Else
                GetControlModeByString = -1
        End Select
    End Function

    Private Sub LoadMavlinkSetFile()
        Dim sFileContents As String
        Dim sSplit() As String
        Dim sSplit2() As String
        Dim nCount As Integer
        Dim ncount2 As Integer
        Dim nCount3 As Integer
        Dim nNext As Integer
        Dim sComment As String
        Dim sParamName As String


        'sFileContents = GetFileContents(GetRootPath() & "\SetConfig.txt")
        sFileContents = HK_GCS.My.Resources.TextFiles.APMSetConfig.ToString

        If sFileContents <> "" Then
            sSplit = Split(sFileContents, vbCrLf)
            For nCount = 0 To UBound(sSplit)
                sComment = ""
                If Trim(sSplit(nCount)) <> "" Then
                    sSplit2 = Split(sSplit(nCount), ",")

                    For nCount3 = 0 To UBound(aValue)
                        If Mid(aName(nCount3), 1, 2) <> "//" Then
                            'If InStr(aName(nCount3), Chr(0)) <> 0 Then
                            '    sParamName = UCase(Mid(aName(nCount3), 1, InStr(aName(nCount3), Chr(0)) - 1))
                            'Else
                            sParamName = UCase(aName(nCount3))
                            'End If
                            'If UCase(aName(nCount3)) = UCase(sSplit2(0)) Then
                            If sParamName = UCase(sSplit2(0)) Then
                                aMin(nCount3) = sSplit2(1)
                                aMax(nCount3) = sSplit2(2)
                                aDefault(nCount3) = sSplit2(3)
                                aMultiplier(nCount3) = sSplit2(4)
                                aVisible(nCount3) = IIf(sSplit2(5) = "1", True, False)
                                For ncount2 = 6 To UBound(sSplit2)
                                    If sComment <> "" Then
                                        sComment = sComment & ","
                                    End If
                                    sComment = sComment & sSplit2(ncount2)
                                Next ncount2
                                aComments(nCount3) = sComment

                                Select Case aName(nCount3)
                                    Case "WP_RADIUS"
                                        If IsNumeric(aValue(nCount3)) = True Then
                                            txtControlMavlinkWPRadius.Text = ConvertDistance(aValue(nCount3) / aMultiplier(nCount3), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                        End If
                                    Case "LOITER_RADIUS"
                                        If IsNumeric(aValue(nCount3)) = True Then
                                            txtControlMavlinkLoiterRadius.Text = ConvertDistance(aValue(nCount3) / aMultiplier(nCount3), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                        End If
                                    Case "ALT_HOLD_RTL"
                                        If IsNumeric(aValue(nCount3)) = True Then
                                            txtControlMavlinkAltRTL.Text = ConvertDistance(aValue(nCount3) / aMultiplier(nCount3), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                        End If
                                End Select

                                Exit For
                            End If
                        End If
                    Next nCount3
                End If
            Next nCount
        End If
        cmdConfigWrite.Enabled = False
    End Sub
    Private Sub LoadAttoParameterGrid(Optional ByVal selectedRowID As Integer = -1)
        Dim nCount As Integer
        Dim nCount2 As Integer
        Dim nLastSelected As Integer = -1

        If selectedRowID = -1 Then
            If dgConfigVariable.SelectedCells.Count > 0 Then
                nLastSelected = dgConfigVariable.SelectedCells(0).RowIndex
            End If
        End If

        If nParameterCount >= 0 Then
            Try
                dt = New DataTable

                dt.Columns.Add(AddDataColumn("ID"))
                dt.Columns.Add(AddDataColumn("Name"))
                dt.Columns.Add(AddDataColumn("Min"))
                dt.Columns.Add(AddDataColumn("Max"))
                dt.Columns.Add(AddDataColumn("Value", False))
                dt.Columns.Add(AddDataColumn("Default"))
                dt.Columns.Add(AddDataColumn("Comment"))
            Catch
            End Try

            Try
                For nCount = 0 To nParameterCount
                    drow = dt.NewRow

                    drow(0) = aIDs(nCount)
                    drow(1) = aName(nCount)
                    drow(2) = aMin(nCount)
                    drow(3) = aMax(nCount)
                    drow(4) = aValue(nCount)
                    drow(5) = aDefault(nCount)
                    drow(6) = aComments(nCount)

                    dt.Rows.Add(drow)

                    If nLastSelected = -1 And selectedRowID <> -1 Then
                        If aIDs(nCount) = selectedRowID Then
                            nLastSelected = nCount
                        End If
                    End If
                Next

                dgConfigVariable.DataSource = dt
                If nLastSelected = -1 Then
                    SetConfigSelectedRowCol(0, 4)
                Else
                    SetConfigSelectedRowCol(nLastSelected, 4)
                End If
                dgConfigVariable.Refresh()
                'dgConfigVariable.Columns("Comment").DisplayIndex = 6
                dgConfigVariable.Visible = True

                dgConfigVariable.Focus()
            Catch
            End Try
        Else
            dgConfigVariable.Visible = False
        End If
    End Sub
    Private Sub LoadAttoSetFile()
        Dim sFileContents As String
        Dim sSplit() As String
        Dim sSplit2() As String
        Dim nCount As Integer
        Dim ncount2 As Integer
        Dim nNext As Integer
        Dim sComment As String

        ReDim aIDs(0)
        ReDim aName(0)
        ReDim aMin(0)
        ReDim aMax(0)
        ReDim aValue(0)
        ReDim aMultiplier(0)
        ReDim aDefault(0)
        ReDim aComments(0)

        nNext = 0
        'sFileContents = GetFileContents(GetRootPath() & "\SetConfig.txt")
        sFileContents = HK_GCS.My.Resources.TextFiles.AttoSetConfig.ToString

        If sFileContents <> "" Then
            sSplit = Split(sFileContents, vbCrLf)
            For nCount = 0 To UBound(sSplit)
                sComment = ""
                If Trim(sSplit(nCount)) <> "" Then
                    sSplit2 = Split(sSplit(nCount), ",")

                    ReDim Preserve aIDs(0 To nNext)
                    ReDim Preserve aName(0 To nNext)
                    ReDim Preserve aMin(0 To nNext)
                    ReDim Preserve aMax(0 To nNext)
                    ReDim Preserve aDefault(0 To nNext)
                    ReDim Preserve aComments(0 To nNext)
                    ReDim Preserve aMultiplier(0 To nNext)

                    aIDs(nNext) = sSplit2(0)
                    aName(nNext) = sSplit2(1)
                    aMin(nNext) = sSplit2(2)
                    aMax(nNext) = sSplit2(3)
                    aDefault(nNext) = sSplit2(4)
                    For ncount2 = 5 To UBound(sSplit2)
                        If sComment <> "" Then
                            sComment = sComment & ","
                        End If
                        sComment = sComment & sSplit2(ncount2)
                    Next ncount2
                    aComments(nNext) = sComment

                    nNext = nNext + 1
                End If
            Next nCount
            nParameterCount = UBound(aIDs)
            ReDim aValue(0 To nParameterCount)
            ReDim aChanged(0 To nParameterCount)
        End If
        cmdConfigWrite.Enabled = False
    End Sub
    Private Sub cmdConfigRead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdConfigRead.Click
        Dim nCount As Integer
        Dim nCount2 As Integer
        Dim nCount3 As Integer
        Dim sSplit() As String
        Dim nLastIndex As Integer
        Dim sInput As String
        Dim bFoundOne As Boolean
        Dim nVehicle As Integer
        Dim nRet As Long
        Dim sOutput As String
        Dim nFailedCount As Integer
        Dim sResponse As String
        Dim sErrorMessage As String
        Dim nFailIndex As Integer
        Dim nStillFailed As Integer

        Dim nPacketCount As Integer
        Dim nLowerBound As Integer
        Dim nUpperBound As Integer

        Const g_PacketSize As Integer = 20

        cmdConfigRead.Enabled = False
        cmdConfigWrite.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        Select Case nConfigDevice
            Case e_ConfigDevice.e_ConfigDevice_AttoPilot

                SetConfigStatus("Clearing input buffer...")
                If ClearSerialInBuffer() = False Then
                    SetConfigStatus("Failed to clear input buffer... Data is not synchronous")

                    tmrComPort.Enabled = True
                    Me.Cursor = Cursors.Default
                    cmdConfigRead.Enabled = True
                    Exit Sub

                End If

                For nCount = 0 To nParameterCount
                    aValue(nCount) = ""
                Next

                SetConfigStatus("Sending request to vehicle #" & nConfigVehicle & "...")

                'cboConfigDevice_SelectedIndexChanged(Nothing, Nothing)
                With prgConfig
                    .Minimum = 0
                    .Value = 0
                    .Maximum = nParameterCount + 1
                End With

                For nPacketCount = 1 To (aIDs(nParameterCount).Substring(1) - 1) \ g_PacketSize + IIf(aIDs(nParameterCount).Substring(1) Mod g_PacketSize > 0, 1, 0)
                    nLowerBound = (nPacketCount * g_PacketSize) - (g_PacketSize - 1)
                    nUpperBound = nLowerBound + g_PacketSize - 1
                    If nUpperBound > aIDs(nParameterCount).Substring(1) Then
                        nUpperBound = aIDs(nParameterCount).Substring(1)
                    End If

                    sInput = serialPortIn.ReadExisting
                    sOutput = "D," & nConfigVehicle & "," & nLowerBound & "," & nUpperBound
                    'sOutput = "D," & nConfigVehicle & ",1," & aIDs(nParameterCount).Substring(1)
                    SendAttoPilot(sOutput)

                    Do While True
                        bFoundOne = False
                        For nCount = 0 To 100
                            If serialPortIn.IsOpen = False Then
                                Exit Sub
                            End If
                            If serialPortIn.BytesToRead > 0 Then
                                sInput = serialPortIn.ReadLine
                                UpdateSerialDataWindow(sInput, sInput)
                                'Debug.Print(sInput)
                                If (InStr(sInput, "$OK") <> 0 Or InStr(sInput, "$D") <> 0) And InStr(sInput, vbCr) <> 0 Then
                                    bFoundOne = True
                                    oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_AttoPilot) = Now.Ticks
                                    Exit For
                                End If
                            Else
                                Application.DoEvents()
                                System.Threading.Thread.Sleep(100)
                            End If
                        Next
                        If bFoundOne = False Then
                            SetConfigStatus("Failed to read parameters", True)
                            Exit Do
                        End If
                        sSplit = Split(sInput, ",")
                        If UBound(sSplit) >= 2 Then
                            nVehicle = -1
                            If IsNumeric(sSplit(1)) = True Then
                                nVehicle = Convert.ToInt16(sSplit(1))
                            End If
                            If sSplit(0) = "$OK" And Microsoft.VisualBasic.Left(sSplit(2), 2) = "D*" And ((nConfigVehicle <> 0 And nVehicle = nConfigVehicle) Or nConfigVehicle = 0) Then
                                SetConfigStatus("Parameter read " & nLowerBound & " to " & nUpperBound & " complete")

                                dgConfigVariable.Enabled = True
                                cmdConfigWrite.Enabled = False
                                bFoundOne = True
                                Exit Do
                            ElseIf InStr(sInput, vbCr) <> 0 Then
                                If sInput.Substring(0, 2) = "$D" And ((nConfigVehicle <> 0 And nVehicle = nConfigVehicle) Or nConfigVehicle = 0) Then
                                    For nCount3 = 0 To nParameterCount
                                        If Convert.ToString(sSplit(2)) = aIDs(nCount3).Substring(1) Then
                                            SetConfigStatus("Reading paramaeter " & aIDs(nCount3) & "...")

                                            aValue(nCount3) = sSplit(3).Substring(0, InStr(sSplit(3), "*") - 1)
                                            prgConfig.Value = prgConfig.Value + 1

                                            Select Case aIDs(nCount3)
                                                Case "$34"
                                                    nMaxRollAngle = aValue(nCount3)
                                                Case "$35"
                                                    nMaxPitchAngle = aValue(nCount3)
                                                Case "$65"
                                                    nMinThrottle = aValue(nCount3)
                                                Case "$66"
                                                    nMAxThrottle = aValue(nCount3)
                                            End Select

                                            sInput = ""
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        End If
                    Loop
                Next nPacketCount

                nFailedCount = 0
                nStillFailed = 0
                For nCount = 0 To nParameterCount
                    If aValue(nCount) = "" Then
                        nFailedCount = nFailedCount + 1
                    End If
                Next
                If nFailedCount > 0 Then
                    If nFailedCount = UBound(aValue) + 1 Then
                        nStillFailed = nFailedCount
                    Else
                        nFailIndex = 1
                        For nCount = 0 To nParameterCount
                            If aValue(nCount) = "" Then
                                SetConfigStatus("Retrying failed paramaeter " & aIDs(nCount) & "...(" & nFailIndex & " of " & nFailedCount & ")")
                                sResponse = ""
                                sOutput = "D," & nConfigVehicle & "," & aIDs(nCount).Substring(1) & "," & aIDs(nCount).Substring(1)
                                If SendToMessageAndWait(sOutput, sErrorMessage, sResponse) = True Then
                                    aValue(nCount) = sResponse
                                    oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_AttoPilot) = Now.Ticks
                                Else
                                    nStillFailed = nStillFailed + 1
                                End If
                                nFailIndex = nFailIndex + 1
                            End If
                        Next
                    End If
                End If
                If nStillFailed > 0 Then
                    SetConfigStatus(nStillFailed & " parameter" & IIf(nStillFailed > 1, "s", "") & " still failed to read", True)
                Else
                    SetConfigStatus("Parameter read complete")
                End If

                LoadAttoCombos()
                oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_AttoPilot) = Now.Ticks
                LoadAttoParameterGrid()
                bWaitingAttoUpdate = False

                'SendAttoPilot("D,2,1," & aIDs(UBound(aIDs)).Substring(1))
                'SendAttoPilot("Q,2,0")
            Case e_ConfigDevice.e_ConfigDevice_Gluonpilot
                For nCount = 0 To nParameterCount
                    aValue(nCount) = ""
                Next

                SetConfigStatus("Requesting parameters...")
                prgConfig.Value = 0

                bWaitingGluonWrite = True
                sOutput = vbLf & "RC;A" & vbLf
                WriteSerialIn(sOutput, False)

            Case e_ConfigDevice.e_ConfigDevice_MAVlink
                For nCount = 0 To nParameterCount
                    aValue(nCount) = ""
                Next
                'LoadMavlinkParameterGrid()

                nParameterCurrentIndex = 0
                bWaitingMavlinkWrite = True
                'sOutput = Chr(85) & Chr(2) & Chr(0) & ConvertChrHex("7F") & Chr(0) & Chr(21) & ConvertChrDec(nConfigVehicle) & Chr(1)
                'FIX314
                SendMavLink(New Byte() {85, 2, 0, 127, 0, 21, nConfigVehicle, 1})
        End Select

        tmrComPort.Enabled = True
        Me.Cursor = Cursors.Default
        cmdConfigRead.Enabled = True

        'If bFoundOne = False Then
        '    nRet = MsgBox("AttoPilot vehicle #" & nConfigVehicle & " failed to respond to parameter read request", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Read Failed")
        'End If
    End Sub

    Private Sub cmdMissionRead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdMissionAttoRead.Click, cmdMissionMavlinkRead.Click
        Dim nCount As Integer
        Dim nCount2 As Integer
        Dim nCount3 As Integer
        Dim sSplit() As String
        Dim nLastIndex As Integer
        Dim sInput As String
        Dim bFoundOne As Boolean
        Dim nVehicle As Integer
        Dim nWPNumber As Integer
        Dim bLastWP As Boolean = False
        Dim nRet As Long
        Dim sOutput As String

        If bConnected = True Then
            cmdMissionAttoRead.Enabled = False
            'cmdMissionAttoWrite.Enabled = False

            Me.Cursor = Cursors.WaitCursor

            ReDim aWPLat(0)
            ReDim aWPLon(0)
            ReDim aWPAlt(0)
            ReDim aWPTrigger(0)
            ReDim aWPSpeed(0)
            ReDim aWPCommand(0)
            ReDim aWPOther(0)
            ReDim aWPOther2(0)
            ReDim aWPOther3(0)
            ReDim aWPOther4(0)

            SetMissionStatus("Sending request to vehicle #" & nConfigVehicle & "...")
            Select Case nConfigDevice
                Case e_ConfigDevice.e_ConfigDevice_AttoPilot

                    SetMissionStatus("Clearing input buffer...")
                    If ClearSerialInBuffer() = False Then
                        SetMissionStatus("Failed to clear input buffer... Data is not synchronous")

                        tmrComPort.Enabled = True
                        Me.Cursor = Cursors.Default
                        cmdConfigRead.Enabled = True
                        Exit Sub
                    End If

                    With prgMissionAtto
                        .Minimum = 0
                        .Value = 0
                        .Maximum = 50
                    End With

                    sInput = serialPortIn.ReadExisting
                    sOutput = "I," & nConfigVehicle & ",0,49"
                    SendAttoPilot(sOutput)
                    'UpdateSerialDataWindow(sOutput, sOutput, False)
                    nWPCount = -1

                    Do While True
                        bFoundOne = False
                        For nCount = 0 To 100
                            If serialPortIn.IsOpen = False Then
                                Exit Sub
                            End If
                            If serialPortIn.BytesToRead > 0 Then
                                sInput = serialPortIn.ReadLine
                                UpdateSerialDataWindow(sInput, sInput)
                                'Debug.Print(sInput)
                                If (InStr(sInput, "$OK") <> 0 Or InStr(sInput, "$I") <> 0) And InStr(sInput, vbCr) <> 0 Then
                                    bFoundOne = True
                                    oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_AttoPilot) = Now.Ticks
                                    Exit For
                                End If
                            Else
                                Application.DoEvents()
                                System.Threading.Thread.Sleep(100)
                            End If
                        Next
                        If bFoundOne = False Then
                            SetMissionStatus("Failed to read waypoints", True)
                            Exit Do
                        End If
                        sSplit = Split(sInput, ",")
                        If UBound(sSplit) >= 2 Then
                            nVehicle = -1
                            If IsNumeric(sSplit(1)) = True Then
                                nVehicle = Convert.ToInt16(sSplit(1))
                            End If
                            If sSplit(0) = "$OK" And Microsoft.VisualBasic.Left(sSplit(2), 2) = "I*" And ((nConfigVehicle <> 0 And nVehicle = nConfigVehicle) Or nConfigVehicle = 0) Then
                                SetMissionStatus("Waypoint read complete")

                                'dgMission.Enabled = True
                                cmdMissionAttoWrite.Enabled = True
                                bFoundOne = True
                                Exit Do
                            ElseIf InStr(sInput, vbCr) <> 0 Then
                                If sInput.Substring(0, 2) = "$I" And ((nConfigVehicle <> 0 And nVehicle = nConfigVehicle) Or nConfigVehicle = 0) Then
                                    nWPNumber = Convert.ToInt16(sSplit(2))
                                    SetMissionStatus("Reading waypoint #" & nWPNumber & "...")

                                    If sSplit(3) <> "0" And sSplit(4) <> "0" And bLastWP = False Then
                                        nWPCount = nWPCount + 1

                                        RedimWaypointArray(UBound(aWPLat) + 1)

                                        'aWPNum(nWPCount) = sSplit(2)
                                        aWPLat(nWPCount) = ConvertPeriodToLocal(sSplit(3))
                                        aWPLon(nWPCount) = ConvertPeriodToLocal(sSplit(4))
                                        'If nWPCount = 0 Then
                                        '    aWPAlt(nWPCount) = 0
                                        'Else
                                        aWPAlt(nWPCount) = ConvertDistance(ConvertPeriodToLocal(sSplit(5)), e_DistanceFormat.e_DistanceFormat_Meters, eDistanceUnits)
                                        'End If
                                        aWPTrigger(nWPCount) = sSplit(6).PadLeft(8, "0")
                                        aWPSpeed(nWPCount) = ConvertSpeed(ConvertPeriodToLocal(sSplit(7).Substring(0, InStr(sSplit(7), "*") - 1)), e_SpeedFormat.e_SpeedFormat_KPH, eSpeedUnits)
                                        'Else
                                        '    bLastWP = True
                                        'End If
                                    End If

                                    prgMissionAtto.Value = prgMissionAtto.Value + 1
                                    sInput = ""
                                End If
                            End If
                        End If
                    Loop

                    oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_AttoPilot) = Now.Ticks
                    LoadMissionGrid()
                    bWaitingAttoUpdate = False
                Case e_ConfigDevice.e_ConfigDevice_MAVlink

                    With prgMissionMavlink
                        .Minimum = 0
                        .Value = 0
                        .Maximum = 50
                    End With

                    dLastMavlinkCommandTime = Now.Ticks
                    nMavlinkRetryAttempts = 0
                    SendMavlinkWPCountRequest()
            End Select

            tmrComPort.Enabled = True
            Me.Cursor = Cursors.Default
            cmdMissionAttoRead.Enabled = True

            If bFoundOne = False Then
                'nRet = MsgBox("AttoPilot vehicle #" & nConfigVehicle & " failed to respond to mission read request", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Read Failed")
            Else
                UpdateMissionGE(0, , 0) ', True)
                If tabMapView.TabPages(tabMapView.SelectedIndex).Tag = "Google Earth" Then
                    WebBrowser1.Focus()
                End If
            End If
        End If
    End Sub
    Public Sub SendMavlinkRawServo(ByVal channel1 As Integer, ByVal channel2 As Integer, ByVal channel3 As Integer, ByVal channel4 As Integer, ByVal channel5 As Integer, ByVal channel6 As Integer, ByVal channel7 As Integer, ByVal channel8 As Integer)
        Dim arr() As Byte

        'FIX314
        arr = New Byte() {85, 17, 0, 127, 0, 35}
        arr = ConCatArray(arr, ConvertIntegerToMavlinkByte(channel1))
        arr = ConCatArray(arr, ConvertIntegerToMavlinkByte(channel2))
        arr = ConCatArray(arr, ConvertIntegerToMavlinkByte(channel3))
        arr = ConCatArray(arr, ConvertIntegerToMavlinkByte(channel4))
        arr = ConCatArray(arr, ConvertIntegerToMavlinkByte(channel5))
        arr = ConCatArray(arr, ConvertIntegerToMavlinkByte(channel6))
        arr = ConCatArray(arr, ConvertIntegerToMavlinkByte(channel7))
        arr = ConCatArray(arr, ConvertIntegerToMavlinkByte(channel8))
        arr = ConCatArray(arr, New Byte() {0})

        bWaitingMavlinkWrite = True
        SendMavLink(arr)

    End Sub
    Private Sub SendMavlinkWPCountSet()
        Dim arr() As Byte

        'FIX314
        arr = New Byte() {85, 4, 0, 127, 0, 44, nConfigVehicle, 1}
        arr = ConCatArray(arr, ConvertIntegerToMavlinkByte(nWPCount + 1))

        bWaitingMavlinkWrite = True
        'sOutput = Chr(85) & Chr(4) & Chr(0) & Chr("&H7F") & Chr(0) & Chr(44) & Chr(nConfigVehicle) & Chr(1) & ConvertIntegerToMavlink(nWPCount + 1)
        nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_TotalCountSet
        SendMavLink(arr)
        'bWaitingMavlinkUpdate = False
    End Sub
    Private Sub SendMavlinkWPCountRequest()
        Dim arr() As Byte

        DisableMavlinkStatusRates()

        'FIX314
        arr = New Byte() {85, 2, 0, 127, 0, 43, nConfigVehicle, 1}

        bWaitingMavlinkWrite = True
        'sOutput = Chr(85) & Chr(2) & Chr(0) & Chr("&H7F") & Chr(0) & Chr(43) & Chr(nConfigVehicle) & Chr(1)
        nMavlinkHandshake = e_MavlinkHandshake.e_MavlinkHandshake_TotalCountRequest
        nWPCount = -1
        SendMavLink(arr)
        Debug.Print("Send Waypoint Count Request")
        'bWaitingMavlinkUpdate = False
    End Sub
    Public Sub SendAttoPilot(ByVal inputCommand As String)
        Dim sOutput As String
        Try
            'Debug.Print("$" & inputCommand & "*" & GetChecksum(inputCommand))
            sOutput = "$" & inputCommand & "*" & GetChecksum(inputCommand)
            'sOutput = "$" & inputCommand & "*FF"
            WriteSerialIn(sOutput & vbCr)
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub SendMavLink(ByVal inputCommand() As Byte)
        Dim aChecksum() As Byte
        Dim aOutputCommand() As Byte
        Dim nCount As Integer
        Dim sTemp As String

        Dim sTest As String
        Dim sTestCRC As String

        'Dim encoding As New System.Text.UTF8Encoding()

        Try
            'encoding.GetBytes(Str)
            aChecksum = crc_calculate_byte(inputCommand)

            aOutputCommand = ConCatArray(inputCommand, aChecksum)
            WriteSerialInBinary(aOutputCommand, "MAVlink - ")

            sTest = ""
            For nCount = 0 To UBound(inputCommand)
                sTest = sTest & Chr(inputCommand(nCount))
            Next
            sTest = crc_calculate(sTest)


            sTemp = ""
            For nCount = 0 To UBound(aOutputCommand)
                sTemp = sTemp & Hex(aOutputCommand(nCount)).PadLeft(2, "0") & " "
            Next
            Debug.Print(Now & ":OUT=" & sTemp)
            'Debug.Print("Old CRC=" & Hex(Asc(Mid(sTest, 1, 1))) & " " & Hex(Asc(Mid(sTest, 2, 1))))
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub
    Public Sub WriteSerialIn(ByVal inputCommand As String, Optional ByVal sendAsBinary As Boolean = False, Optional ByVal additionalText As String = "")
        Dim nCount As Integer
        Dim sOutput As String
        Dim handler As Socket

        If sendAsBinary = True Then
            'For nCount = 0 To UBound(binaryBytes)
            '    sOutput = sOutput & Hex(binaryBytes(nCount)).PadLeft(2, "0") & " "
            'Next
            For nCount = 1 To Len(inputCommand)
                sOutput = sOutput & Hex(Asc(Mid(inputCommand, nCount, 1))).PadLeft(2, "0") & " "
            Next
            UpdateSerialDataWindow(sOutput, additionalText & sOutput, False)
        Else
            UpdateSerialDataWindow(inputCommand, additionalText & inputCommand, False)
        End If

        If cboComPort.Text = "TCP" Then
            If SocketServer.clients.Count > 0 Then
                handler = SocketServer.clients(0).workSocket
                If SocketServer.clients(0).workSocket.Connected = True Then
                    SocketServer.Send(handler, inputCommand)
                End If
            End If
        ElseIf cboComPort.Text = "UDP" Then
            lblComPortStatus.Text = "Cannot send output message via UDP"
        Else
            If sendAsBinary = True Then
                'Dim outputBytes() As Byte

                Dim outputBytes(0 To Len(inputCommand) - 1) As Byte
                For nCount = 0 To Len(inputCommand) - 1
                    outputBytes(nCount) = Asc(inputCommand.Substring(nCount, 1))
                Next nCount

                'Dim encoding As New System.Text.UTF8Encoding()
                'outputBytes = encoding.GetBytes(inputString & IIf(sendCrLf = True, vbCrLf, ""))

                'nInputStringLength = nInputStringLength + nReadCount
                'serialPortIn.Encoding = System.Text.Encoding.UTF8 'System.Text.Encoding.GetEncoding(28591) '65001) '28591
                'nReadResult = serialPortIn.Read(cData, 0, nReadCount)  'Reading the Data

                'sNewString = System.Text.Encoding.Default.GetString(cData)
                'sBuffer = sBuffer & sNewString

                serialPortIn.Write(outputBytes, 0, UBound(outputBytes) + 1)

                'serialPortIn.Encoding = System.Text.Encoding.GetEncoding(1252)
                'Dim encoding As New System.Text.UTF8Encoding
                'outputBytes = System.Text.Encoding.UTF8.GetBytes(inputCommand)

                'nInputStringLength = nInputStringLength + nReadCount
                'serialPortIn.Encoding = System.Text.Encoding.UTF8 'System.Text.Encoding.GetEncoding(28591) '65001) '28591
                'nReadResult = serialPortIn.Read(cData, 0, nReadCount)  'Reading the Data

                'sNewString = System.Text.Encoding.Default.GetString(cData)
                'sBuffer = sBuffer & sNewString

                'serialPortIn.Write(binaryBytes, 0, UBound(binaryBytes))
                'serialPortIn.Write(inputCommand)
                'serialPortIn.Write(outputBytes, 0, UBound(outputBytes))
            Else
                If serialPortIn.IsOpen = True Then
                    Try
                        'serialPortIn.Encoding = System.Text.Encoding.ASCII
                        serialPortIn.Write(inputCommand)
                        'UpdateSerialDataWindow(inputCommand, inputCommand, False)
                    Catch

                    End Try
                End If
            End If
        End If
    End Sub
    Public Sub WriteSerialInBinary(ByVal inputCommand() As Byte, Optional ByVal additionalText As String = "")
        Dim nCount As Integer
        Dim sOutput As String
        Dim handler As Socket

        For nCount = 0 To UBound(inputCommand)
            sOutput = sOutput & Hex(inputCommand(nCount)).PadLeft(2, "0") & " "
        Next
        UpdateSerialDataWindow(sOutput, additionalText & sOutput, False)

        If cboComPort.Text = "TCP" Then
            If SocketServer.clients.Count > 0 Then
                handler = SocketServer.clients(0).workSocket
                If handler.Available > 0 Then
                    SocketServer.Send(handler, System.Text.Encoding.Default.GetString(inputCommand))
                    'FIX314 -a
                End If
            End If
        ElseIf cboComPort.Text = "UDP" Then
            lblComPortStatus.Text = "Cannot send output message via UDP"
        Else
            'serialPortIn.Encoding = System.Text.Encoding.UTF8
            serialPortIn.Encoding = System.Text.Encoding.GetEncoding(28591)
            serialPortIn.Write(inputCommand, 0, UBound(inputCommand) + 1)
        End If
    End Sub

    Public Sub cmdConfigWrite_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdConfigWrite.Click
        'Const RetryMax As Integer = 5
        'Const WaitForReplyTime As Long = 2000

        Dim nCount As Integer
        Dim nCount2 As Integer
        Dim nCount3 As Integer
        Dim sInput As String
        Dim nChangeCount As Integer
        Dim bFoundOne As Boolean
        Dim sSplit() As String
        Dim sOutput As String
        Dim aOutput() As Byte
        Dim aTemp() As Byte

        Me.Cursor = Cursors.WaitCursor

        nChangeCount = 0
        For nCount = 0 To UBound(aValue)
            If aChanged(nCount) = True Then
                nChangeCount = nChangeCount + 1
            End If
        Next

        If nChangeCount > 0 Then
            If nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot Then
                SetConfigStatus("Clearing input buffer...")
                If ClearSerialInBuffer() = False Then
                    SetConfigStatus("Failed to clear input buffer... Data is not synchronous")

                    tmrComPort.Enabled = True
                    Me.Cursor = Cursors.Default
                    cmdConfigRead.Enabled = True
                    Exit Sub

                End If

                SetConfigStatus("Looking for changes...")

                With prgConfig
                    .Minimum = 0
                    .Value = 0
                    .Maximum = nChangeCount
                End With

                For nCount = 0 To UBound(aValue)
                    If aValue(nCount) <> "" And IsNumeric(aValue(nCount)) = True And aChanged(nCount) = True Then
                        For nCount3 = 1 To n2WayRetries
                            sInput = ""
                            SetConfigStatus("Writing paramaeter #" & aIDs(nCount) & "..." & IIf(nCount3 > 1, "(Attempt #" & nCount3 & ")", ""))
                            sOutput = "S," & nConfigVehicle & "," & aIDs(nCount).Substring(1) & "," & aValue(nCount)
                            SendAttoPilot(sOutput)
                            'UpdateSerialDataWindow(sOutput, sOutput, False)

                            bFoundOne = False
                            For nCount2 = 0 To (n2WayTimeout * 1000) / 100
                                If serialPortIn.BytesToRead > 0 Then
                                    sInput = serialPortIn.ReadLine
                                    UpdateSerialDataWindow(sInput, sInput)
                                Else
                                    System.Threading.Thread.Sleep(100)
                                End If
                                sSplit = Split(sInput, ",")
                                If UBound(sSplit) >= 2 Then
                                    If sSplit(0) = "$OK" And Microsoft.VisualBasic.Left(sSplit(2), 2) = "S*" And ((nConfigVehicle <> 0 And sSplit(1) = nConfigVehicle) Or nConfigVehicle = 0) Then
                                        bFoundOne = True
                                        oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_AttoPilot) = Now.Ticks
                                        System.Threading.Thread.Sleep(250)
                                        Exit For
                                    End If
                                End If
                            Next
                            If bFoundOne = True Then
                                Exit For
                            End If
                        Next
                        If bFoundOne = True Then
                            prgConfig.Value = prgConfig.Value + 1
                        Else
                            Exit For 'Bombed out - failed to reply after RetryMax attempts
                        End If
                    End If
                Next
                If bFoundOne = True Then
                    sOutput = "A," & nConfigVehicle
                    SendAttoPilot(sOutput)
                    'UpdateSerialDataWindow(sOutput, sOutput, False)
                    For nCount = 0 To UBound(aValue)
                        If aChanged(nCount) = True Then
                            aChanged(nCount) = False
                        End If
                    Next
                    LoadAttoCombos()
                End If
                bWaitingAttoUpdate = False
            ElseIf nConfigDevice = e_ConfigDevice.e_ConfigDevice_Gluonpilot Then
                prgConfig.Maximum = 11
                prgConfig.Value = 0
                nChangeCount = 1
                bFoundOne = True

                Try
                    GetGluonParameterOutput("ST", 7, 12)
                    GetGluonParameterOutput("SA", 1, 3)
                    GetGluonParameterOutput("SY", 4, 6)
                    GetGluonParameterOutput("SI", 15, 19)
                    GetGluonParameterOutput("SG", 13, 14)
                    GetGluonParameterOutput("PP", 20, 25)
                    GetGluonParameterOutput("PR", 26, 31)
                    GetGluonParameterOutput("PH", 32, 37)
                    GetGluonParameterOutput("PA", 38, 43)
                    GetGluonParameterOutput("SR", 44, 44)
                    GetGluonParameterOutput("SC", 64, 69)

                    SetConfigStatus("Burning EEPROM...")
                    sOutput = vbLf & "FC;" & vbLf
                    WriteSerialIn(sOutput, False)

                    SetConfigStatus("Finished writing parameters")
                Catch
                    tmrComPort.Enabled = True
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End Try

            ElseIf nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink Then
                SetConfigStatus("Looking for changes...")

                With prgConfig
                    .Minimum = 0
                    .Value = 0
                    .Maximum = nChangeCount
                End With

                bWaitingMavlinkWrite = False
                For nCount = 0 To UBound(aValue)
                    If aValue(nCount) <> "" And aChanged(nCount) = True Then
                        'aOutput = New Byte() {85, 21, 0, 127, 0, 23, nConfigVehicle, 0}

                        'FIX314 -b
                        aOutput = New Byte() {85, 21, 0, 127, 0, 23, nConfigVehicle, 1}
                        aTemp = StringToByte(aName(nCount), 15, 0)
                        aOutput = ConCatArray(aOutput, aTemp)
                        aTemp = ConvertSingleToMavlinkByte(aValue(nCount))
                        aOutput = ConCatArray(aOutput, aTemp)

                        'sOutput = ConvertChrDec(85) & ConvertChrDec(21) & ConvertChrDec(0) & ConvertChrDec("&H7F") & ConvertChrDec(0) & ConvertChrDec(23) & ConvertChrDec(nConfigVehicle) & ConvertChrDec(1) & aName(nCount).PadRight(15, Chr(0)) & ConvertSingleToMavlink(aValue(nCount))
                        prgConfig.Value = prgConfig.Value + 1
                        SendMavLink(aOutput)
                        aChanged(nCount) = False
                        System.Threading.Thread.Sleep(50)
                        bFoundOne = True
                    End If
                Next nCount
            End If
        End If

        tmrComPort.Enabled = True
        Me.Cursor = Cursors.Default

        If nChangeCount = 0 Then
            SetConfigStatus("Nothing changed...nothing written")
            cmdConfigWrite.Enabled = False
        Else
            If bFoundOne = False Then
                SetConfigStatus("Failed to write parameters")
                MsgBox("AttoPilot vehicle #" & nConfigVehicle & " failed to respond to write request", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Write Failed")
            Else
                SetConfigStatus("Parameter write complete")
                cmdConfigWrite.Enabled = False
            End If

        End If
    End Sub
    Private Function GetGluonParameterOutput(ByVal headerString As String, ByVal startParameter As Integer, ByVal endParameter As Integer) As Boolean
        Dim nCount As Integer
        Dim sOutput As String
        Dim nTemp As Single
        Dim bBits As Boolean = False

        GetGluonParameterOutput = True
        SetConfigStatus("Writing " & headerString & " Variables...")
        sOutput = ""
        nTemp = 0
        For nCount = 0 To UBound(aIDs)
            If aIDs(nCount) >= startParameter And aIDs(nCount) <= endParameter Then
                If sOutput <> "" Then
                    sOutput = sOutput & ";"
                End If
                If IsNumeric(aBit(nCount)) = True Then
                    bBits = True
                    If aValue(nCount) = 1 Then
                        nTemp = nTemp + aBit(nCount)
                    End If
                Else
                    If IsNumeric(aValue(nCount)) = True Then
                        nTemp = aValue(nCount)
                    Else
                        SetConfigStatus("Invalid parameter value for index #" & aIDs(nCount) & "...", True)
                        LoadGluonVariables()
                        GetGluonParameterOutput = False
                        Err.Raise(1)
                        Exit Function
                    End If
                    If IsNumeric(aMultiplier(nCount)) = True Then
                        nTemp = nTemp / aMultiplier(nCount)
                    End If
                    If IsNumeric(aAdder(nCount)) = True Then
                        nTemp = nTemp - aAdder(nCount)
                    End If
                    sOutput = sOutput & nTemp
                End If
            End If
        Next
        If bBits = True Then
            sOutput = sOutput & Convert.ToInt32(nTemp)
        End If
        sOutput = vbLf & headerString & ";" & sOutput & vbLf
        prgConfig.Value = prgConfig.Value + 1
        WriteSerialIn(sOutput, False)
        System.Threading.Thread.Sleep(100)
    End Function
    Private Sub SetConfigStatus(ByVal inputString As String, Optional ByVal isError As Boolean = False)
        lblConfigStatus.Text = GetResString(, "Status", True) & ": " & inputString
        If isError = True Then
            lblConfigStatus.ForeColor = Color.Red
        Else
            lblConfigStatus.ForeColor = Color.Black
        End If
        lblConfigStatus.Refresh()
    End Sub
    Private Sub SetMissionStatus(ByVal inputString As String, Optional ByVal isError As Boolean = False)
        lblMissionStatusAtto.Text = GetResString(, "Status", True) & ": " & inputString
        lblMissionStatusMavlink.Text = GetResString(, "Status", True) & ": " & inputString
        If isError = True Then
            lblMissionStatusAtto.ForeColor = Color.Red
            lblMissionStatusMavlink.ForeColor = Color.Red
        Else
            lblMissionStatusAtto.ForeColor = Color.Black
            lblMissionStatusMavlink.ForeColor = Color.Black
        End If
        lblMissionStatusAtto.Refresh()
        lblMissionStatusMavlink.Refresh()
    End Sub
    Private Sub SetControlStatus(ByVal inputString As String, Optional ByVal isError As Boolean = False)
        lblControlAttoStatus.Text = GetResString(, "Status", True) & ": " & inputString
        If isError = True Then
            lblControlAttoStatus.ForeColor = Color.Red
        Else
            lblControlAttoStatus.ForeColor = Color.Black
        End If
        lblControlAttoStatus.Refresh()
    End Sub

    Private Sub dgConfigVariable_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgConfigVariable.CellValueChanged
        Dim sNewValue As String
        Dim nNewValue As Long
        Dim sMin As String
        Dim sMax As String
        Dim sDefault As String
        Dim nMin As Long
        Dim nMax As Long
        Dim bValid As Boolean = False
        Dim nRowIndex As Integer
        Dim nCount As Integer

        If nConfigDevice <> e_ConfigDevice.e_ConfigDevice_MAVlink Then
            sNewValue = Trim(dgConfigVariable.Rows(e.RowIndex).Cells("Value").Value.ToString)
            nRowIndex = e.RowIndex
        Else
            nRowIndex = -1
            For nCount = 0 To UBound(aName)
                If UCase(aName(nCount)) = Trim(dgConfigVariable.Rows(e.RowIndex).Cells("Name").Value.ToString) Then
                    nRowIndex = nCount
                    Exit For
                End If
            Next
            If nRowIndex = -1 Then
                Exit Sub
            End If
            sNewValue = Trim(dgConfigVariable.Rows(e.RowIndex).Cells("Value").Value.ToString)
        End If
        If sNewValue <> aValue(nRowIndex) Then
            Try
                sMin = Trim(dgConfigVariable.Rows(e.RowIndex).Cells("Min").Value.ToString)
                sMax = Trim(dgConfigVariable.Rows(e.RowIndex).Cells("Max").Value.ToString)
                sDefault = Trim(dgConfigVariable.Rows(e.RowIndex).Cells("Default").Value.ToString)

                If IsNumeric(sMin) = True And sMin <> "" Then
                    nMin = Convert.ToInt32(sMin)
                Else
                    nMin = -999999999
                End If
                If IsNumeric(sMax) = True And sMax <> "" Then
                    nMax = Convert.ToInt32(sMax)
                Else
                    nMax = 999999999
                End If
                If IsNumeric(sNewValue) = True And sNewValue <> "" Then
                    If nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot Then
                        nNewValue = Convert.ToInt32(sNewValue)
                    ElseIf nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink Or nConfigDevice = e_ConfigDevice.e_ConfigDevice_Gluonpilot Then
                        nNewValue = Convert.ToSingle(sNewValue)
                    End If
                    If nMin = -1 And nMax = 1 Then
                        If nNewValue = nMin Or nNewValue = nMax Then
                            bValid = True
                        End If
                    ElseIf nNewValue >= nMin And nNewValue <= nMax Then
                        bValid = True
                    End If
                End If
            Catch
            End Try

            If bValid = True Then
                If nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot Then
                    aValue(nRowIndex) = Convert.ToSingle(dgConfigVariable.Rows(e.RowIndex).Cells("Value").Value.ToString)
                    Select Case aIDs(nRowIndex)
                        Case "$34"
                            nMaxRollAngle = aValue(nRowIndex)
                        Case "$35"
                            nMaxPitchAngle = aValue(nRowIndex)
                        Case "$65"
                            nMinThrottle = aValue(nRowIndex)
                        Case "$66"
                            nMAxThrottle = aValue(nRowIndex)
                    End Select
                    aChanged(nRowIndex) = True
                ElseIf nConfigDevice = e_ConfigDevice.e_ConfigDevice_Gluonpilot Then
                    If IsNumeric(aMultiplier(nRowIndex)) = True Then
                        aValue(nRowIndex) = Convert.ToSingle(dgConfigVariable.Rows(e.RowIndex).Cells("Value").Value) * Convert.ToSingle(aMultiplier(nRowIndex))
                    Else
                        aValue(nRowIndex) = Convert.ToSingle(dgConfigVariable.Rows(e.RowIndex).Cells("Value").Value)
                    End If
                    aChanged(nRowIndex) = True
                ElseIf nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink Then
                    If IsNumeric(aMultiplier(nRowIndex)) = True Then
                        aValue(nRowIndex) = Convert.ToSingle(dgConfigVariable.Rows(e.RowIndex).Cells("Value").Value) * Convert.ToSingle(aMultiplier(nRowIndex))
                    Else
                        aValue(nRowIndex) = Convert.ToSingle(dgConfigVariable.Rows(e.RowIndex).Cells("Value").Value)
                    End If
                    aChanged(nRowIndex) = True
                End If
            Else
                If nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot Or nConfigDevice = e_ConfigDevice.e_ConfigDevice_Gluonpilot Then
                    Call MsgBox("Your value for " & dgConfigVariable.Rows(e.RowIndex).Cells("ID").Value.ToString & " (" & dgConfigVariable.Rows(e.RowIndex).Cells("Name").Value.ToString & ") is not valid." & vbCrLf & GetMinMaxString(sNewValue, sMin, sMax, sDefault), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Invalid Entry")
                ElseIf nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink Then
                    Call MsgBox("Your value for " & dgConfigVariable.Rows(e.RowIndex).Cells("Name").Value.ToString & " is not valid." & vbCrLf & GetMinMaxString(sNewValue, sMin, sMax, sDefault), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Invalid Entry")
                End If
                dgConfigVariable.Rows(e.RowIndex).Cells("Value").Value = aValue(nRowIndex)
            End If
            aChanged(nRowIndex) = True
        End If
        If nParameterCount >= 0 And cmdConfigRead.Enabled = True Then
            cmdConfigWrite.Enabled = True
        End If
    End Sub
    Private Function GetMinMaxString(ByVal value As String, ByVal min As String, ByVal max As String, ByVal defaultValue As String) As String
        GetMinMaxString = "Your Value: " & value

        If min <> "" Then
            GetMinMaxString = GetMinMaxString & ", Min: " & min
        End If
        If max <> "" Then
            GetMinMaxString = GetMinMaxString & ", Max: " & max
        End If
        If defaultValue <> "" Then
            GetMinMaxString = GetMinMaxString & ", Default: " & defaultValue
        End If
    End Function

    'Private Sub dgConfigVariable_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgConfigVariable.EditingControlShowing
    '    AddHandler dgConfigVariable.KeyPress, AddressOf dgConfigVariable_KeyPress
    'End Sub

    'Private Sub dgConfigVariable_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgConfigVariable.KeyPress
    '    If nParameterCount >= 0 And cmdConfigRead.Enabled = True Then
    '        If aValue(dgConfigVariable.CurrentRow.Index) <> dgConfigVariable.Rows(dgConfigVariable.CurrentRow.Index).Cells("Value").Value.ToString Then
    '            cmdConfigWrite.Enabled = True
    '        End If
    '    End If
    'End Sub

    Private Sub dgConfigVariable_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgConfigVariable.SelectionChanged
        prgConfig.Value = 0
    End Sub

    Private Sub cboConfigVehicle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboConfigVehicle.Click
        nConfigVehicle = cboConfigVehicle.SelectedIndex
        If nConfigVehicle >= 0 Then
            SaveRegSetting(sRootRegistry & "\Settings", "Config Vehicle", nConfigVehicle)
            cboConfigDevice_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub cboConfigVehicle_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboConfigVehicle.SelectedIndexChanged

    End Sub

    Private Sub dgMission_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMission.CellClick
        Dim nSelectedRow
        Dim nCount As Integer
        Dim nStartingIndex As Integer
        Dim nEndingIndex As Integer
        Dim bValid As Boolean

        If e.ColumnIndex = -1 Then
            Exit Sub
        End If

        bLockMissionReload = True
        nSelectedRow = e.RowIndex

        Select Case dgMission.Columns(e.ColumnIndex).Tag
            Case "Delete"
                For nCount = 0 To nWPCount - 1
                    If nCount >= nSelectedRow Then
                        aWPLat(nCount) = aWPLat(nCount + 1)
                        aWPLon(nCount) = aWPLon(nCount + 1)
                        aWPAlt(nCount) = aWPAlt(nCount + 1)

                        If nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot Then
                            aWPTrigger(nCount) = aWPTrigger(nCount + 1)
                            aWPSpeed(nCount) = aWPSpeed(nCount + 1)
                        ElseIf nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink Then
                            aWPCommand(nCount) = aWPCommand(nCount + 1)
                            aWPOther(nCount) = aWPOther(nCount + 1)
                            aWPOther2(nCount) = aWPOther2(nCount + 1)
                            aWPOther3(nCount) = aWPOther3(nCount + 1)
                            aWPOther4(nCount) = aWPOther4(nCount + 1)
                        End If
                    End If
                Next
                nWPCount = nWPCount - 1
                LoadMissionGrid(nSelectedRow)
                UpdateMissionGE(nSelectedRow)
            Case "Up", "Down"
                bValid = False
                If dgMission.Columns(e.ColumnIndex).Tag = "Up" Then
                    If nSelectedRow > 0 Then
                        nStartingIndex = nSelectedRow
                        nEndingIndex = nSelectedRow - 1
                        bValid = True
                    End If
                Else
                    If nSelectedRow < nWPCount Then
                        nStartingIndex = nSelectedRow
                        nEndingIndex = nSelectedRow + 1
                        bValid = True
                    End If
                End If

                If bValid = True Then
                    SwapArrayGroup(nStartingIndex, nEndingIndex)

                    nSelectedRow = nEndingIndex
                    LoadMissionGrid(nSelectedRow)
                    UpdateMissionGE(nSelectedRow, , 0)
                End If
        End Select
        bLockMissionReload = False
    End Sub
    Private Sub SwapArrayGroup(ByVal startingIndex As Integer, ByVal endingIndex As Integer)
        SwapArrayValues(aWPLat(startingIndex), aWPLat(endingIndex))
        SwapArrayValues(aWPLon(startingIndex), aWPLon(endingIndex))

        If startingIndex <> 0 And endingIndex <> 0 Then
            SwapArrayValues(aWPAlt(startingIndex), aWPAlt(endingIndex))
        End If

        If nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot Then
            SwapArrayValues(aWPTrigger(startingIndex), aWPTrigger(endingIndex))
            SwapArrayValues(aWPSpeed(startingIndex), aWPSpeed(endingIndex))
        ElseIf nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink Then
            SwapArrayValues(aWPOther(startingIndex), aWPOther(endingIndex))
            SwapArrayValues(aWPOther2(startingIndex), aWPOther2(endingIndex))
            SwapArrayValues(aWPOther3(startingIndex), aWPOther3(endingIndex))
            SwapArrayValues(aWPOther4(startingIndex), aWPOther4(endingIndex))
            SwapArrayValues(aWPCommand(startingIndex), aWPCommand(endingIndex))
        End If
    End Sub
    Private Sub SwapArrayValues(ByRef startingValue As String, ByRef endingValue As String)
        Dim nTemp As String
        nTemp = endingValue
        endingValue = startingValue
        startingValue = nTemp
    End Sub

    Private Sub dgMission_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgMission.CellFormatting
        If tabInstrumentView.SelectedIndex = 4 Then
            If e.RowIndex > 0 And dgMission.Columns(e.ColumnIndex).Tag = "Up" Then
                e.Value = My.Resources.up
            ElseIf e.RowIndex < nWPCount And e.RowIndex >= 0 And dgMission.Columns(e.ColumnIndex).Tag = "Down" Then
                e.Value = My.Resources.down
            ElseIf dgMission.Columns(e.ColumnIndex).Tag = "Delete" Then
                e.Value = My.Resources.Delete
            ElseIf dgMission.Columns(e.ColumnIndex).Tag = "Up" Or dgMission.Columns(e.ColumnIndex).Tag = "Down" Then
                e.Value = My.Resources.Blank
            End If
        End If
    End Sub

    Private Sub dgMission_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgMission.SelectionChanged
        Dim sTrigger As String
        Dim nCount As Integer
        Dim nSelectedIndex As Integer
        Dim sWP As String

        If dgMission.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        bLockMissionReload = True

        nSelectedIndex = dgMission.SelectedRows(0).Index

        'If nSelectedIndex = 0 Then
        '    sWP = "Home" ' aWPNum(nSelectedIndex)
        'Else
        If nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink Then
            sWP = "Mission Command #" & nSelectedIndex ' aWPNum(nSelectedIndex)
        Else
            sWP = "WP #" & nSelectedIndex ' aWPNum(nSelectedIndex)
        End If
        'End If

        Select Case nConfigDevice
            Case e_ConfigDevice.e_ConfigDevice_Generic
                grpMissionControlGeneric.Text = sWP
                txtMissionGenericLat.Text = aWPLat(nSelectedIndex)
                txtMissionGenericLong.Text = aWPLon(nSelectedIndex)
                txtMissionGenericAlt.Text = aWPAlt(nSelectedIndex)
            Case e_ConfigDevice.e_ConfigDevice_AttoPilot
                grpMissionControlAtto.Text = sWP
                txtMissionAttoLatitude.Text = aWPLat(nSelectedIndex)
                txtMissionAttoLongitude.Text = aWPLon(nSelectedIndex)
                txtMissionAttoAltitude.Text = aWPAlt(nSelectedIndex)
                txtMissionAttoSpeed.Text = aWPSpeed(nSelectedIndex)

                sTrigger = aWPTrigger(nSelectedIndex).PadLeft(8, "0")
                cboMissionAttoLoiterDuration.SelectedIndex = 0
                cboMissionAttoLoiterDirection.SelectedIndex = 0
                cboMissionAttoTriggerControl.SelectedIndex = 0
                cboMissionAttoAltitudeControl.SelectedIndex = 0
                cboMissionAttoReversePath.SelectedIndex = 0

                For nCount = 0 To Len(sTrigger) - 1
                    Select Case nCount
                        Case 7
                            cboMissionAttoLoiter.SelectedIndex = Convert.ToInt16(sTrigger.Substring(nCount, 1))
                        Case 6
                            If Convert.ToInt16(sTrigger.Substring(nCount, 1)) - 1 > 0 Then
                                cboMissionAttoLoiterDuration.SelectedIndex = Convert.ToInt16(sTrigger.Substring(nCount, 1)) - 1
                            End If
                        Case 5
                            cboMissionAttoLoiterDirection.SelectedIndex = Convert.ToInt16(sTrigger.Substring(nCount, 1))
                        Case 4
                            'If Convert.ToInt16(sTrigger.Substring(nCount, 1))  > 0 Then
                            cboMissionAttoTriggerControl.SelectedIndex = Convert.ToInt16(sTrigger.Substring(nCount, 1))
                            'End If
                        Case 3
                            cboMissionAttoAltitudeControl.SelectedIndex = Convert.ToInt16(sTrigger.Substring(nCount, 1))
                        Case 0
                            cboMissionAttoReversePath.SelectedIndex = Convert.ToInt16(sTrigger.Substring(nCount, 1))
                    End Select
                Next
            Case e_ConfigDevice.e_ConfigDevice_MAVlink
                grpMissionControlMavlink.Text = sWP

                For nCount = 0 To cboMissionMavlinkCommand.Items.Count - 1
                    If CType(cboMissionMavlinkCommand.Items(nCount), cValueDesc).Value = aWPCommand(nSelectedIndex) Then
                        cboMissionMavlinkCommand.SelectedIndex = nCount
                        cboMissionMavlinkCommand_SelectedIndexChanged(Nothing, Nothing)
                        Exit For
                    End If
                Next

                If cboMissionMavlinkArg1.Visible = True Then
                    For nCount = 0 To cboMissionMavlinkArg1.Items.Count - 1
                        If CType(cboMissionMavlinkArg1.Items(nCount), cValueDesc).Value = aWPOther(nSelectedIndex) Then
                            cboMissionMavlinkArg1.SelectedIndex = nCount
                            Exit For
                        End If
                    Next
                Else
                    txtMissionMavlinkArg1.Text = aWPOther(nSelectedIndex)
                End If
                If cboMissionMavlinkArg2.Visible = True Then
                    For nCount = 0 To cboMissionMavlinkArg2.Items.Count - 1
                        If CType(cboMissionMavlinkArg2.Items(nCount), cValueDesc).Value = aWPOther2(nSelectedIndex) Then
                            cboMissionMavlinkArg2.SelectedIndex = nCount
                            Exit For
                        End If
                    Next
                Else
                    txtMissionMavlinkArg2.Text = aWPOther2(nSelectedIndex)
                End If
                If cboMissionMavlinkArg3.Visible = True Then
                    For nCount = 0 To cboMissionMavlinkArg3.Items.Count - 1
                        If CType(cboMissionMavlinkArg3.Items(nCount), cValueDesc).Value = aWPOther3(nSelectedIndex) Then
                            cboMissionMavlinkArg3.SelectedIndex = nCount
                            Exit For
                        End If
                    Next
                Else
                    txtMissionMavlinkArg3.Text = aWPOther3(nSelectedIndex)
                End If
                If cboMissionMavlinkArg4.Visible = True Then
                    For nCount = 0 To cboMissionMavlinkArg4.Items.Count - 1
                        If CType(cboMissionMavlinkArg4.Items(nCount), cValueDesc).Value = aWPOther4(nSelectedIndex) Then
                            cboMissionMavlinkArg4.SelectedIndex = nCount
                            Exit For
                        End If
                    Next
                Else
                    txtMissionMavlinkArg4.Text = aWPOther4(nSelectedIndex)
                End If
                txtMissionMavlinkArg5.Text = aWPLat(nSelectedIndex)
                txtMissionMavlinkArg6.Text = aWPLon(nSelectedIndex)
                txtMissionMavlinkArg7.Text = aWPAlt(nSelectedIndex)
        End Select

        If Not webDocument Is Nothing And bGoogleLoaded = True And bLockMissionCenter = False Then
            If chkViewNoTracking.Checked <> True Then
                chkViewNoTracking.Checked = True
                chkViewNoTracking_CheckedChanged(Nothing, Nothing)
            End If
            'If bLockMissionCenter = False And nConfigDevice = e_ConfigDevice.e_ConfigDevice_Generic Then
            Select Case nConfigDevice
                Case e_ConfigDevice.e_ConfigDevice_Generic, e_ConfigDevice.e_ConfigDevice_AttoPilot
                    webDocument.InvokeScript("centerOnLocation", New Object() {ConvertPeriodToLocal(aWPLat(nSelectedIndex)), ConvertPeriodToLocal(aWPLon(nSelectedIndex)), ConvertPeriodToLocal(ConvertDistance(aWPAlt(nSelectedIndex), eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters)), 0, False})
                Case e_ConfigDevice.e_ConfigDevice_MAVlink
                    Select Case aWPCommand(nSelectedIndex)
                        Case 16, 17, 18, 19, 21, 22, 80, 81, 179
                            webDocument.InvokeScript("centerOnLocation", New Object() {ConvertPeriodToLocal(aWPLat(nSelectedIndex)), ConvertPeriodToLocal(aWPLon(nSelectedIndex)), ConvertPeriodToLocal(aWPAlt(nSelectedIndex)), 0, False})
                            'Case 44
                            '    webDocument.InvokeScript("centerOnLocation", New Object() {ConvertPeriodToLocal(aWPLat(nSelectedIndex)), ConvertPeriodToLocal(aWPLon(nSelectedIndex)), 0, 0, False})
                    End Select
            End Select
            'ElseIf bLockMissionCenter = False Then
            '    webDocument.InvokeScript("centerOnLocation", New Object() {ConvertPeriodToLocal(aWPLat(nSelectedIndex)), ConvertPeriodToLocal(aWPLon(nSelectedIndex)), ConvertPeriodToLocal(ConvertDistance(aWPAlt(nSelectedIndex), eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters)), -1, False})
            'End If
        End If
        bLockMissionReload = False
    End Sub

    'Private Sub cmdMissionAttoSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMissionAttoSave.Click
    '    Dim sTrigger As String
    '    Dim nCount As Integer
    '    Dim nSelectedIndex As Integer

    '    If dgMission.SelectedRows.Count = 0 Then
    '        Exit Sub
    '    End If
    '    nSelectedIndex = dgMission.SelectedRows(0).Index
    '    aWPLat(nSelectedIndex) = txtMissionLatitude.Text
    '    aWPLon(nSelectedIndex) = txtMissionLongitude.Text
    '    aWPAlt(nSelectedIndex) = txtMissionAltitude.Text
    '    aWPSpeed(nSelectedIndex) = txtMissionSpeed.Text

    '    aWPTrigger(nSelectedIndex) = cboMissionAttoReversePath.SelectedIndex & "00" & cboMissionAttoAltitudeControl.SelectedIndex & cboMissionAttoTriggerControl.SelectedIndex + 1 & cboMissionAttoLoiterDirection.SelectedIndex & cboMissionAttoLoiterDuration.SelectedIndex + 1 & cboMissionAttoLoiter.SelectedIndex

    '    LoadAttoMissionGrid(nSelectedIndex)
    '    dgMission.Refresh()
    'End Sub

    Private Sub cboMissionAttoLoiter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMissionAttoLoiter.SelectedIndexChanged
        Dim nCount As Integer
        If cboMissionAttoLoiter.SelectedIndex = 0 Then
            cboMissionAttoLoiterDirection.Enabled = False
            cboMissionAttoLoiterDuration.Enabled = False
            'lblMissionAttoLoiterValue.Text = ""
            'lblMissionAttoControlValue.Text = ""
            'lblMissionAttoDurationValue.Text = ""
        Else
            cboMissionAttoLoiterDirection.Enabled = True
            cboMissionAttoLoiterDuration.Enabled = True
            'For nCount = 0 To UBound(aIDs)
            '    If aIDs(nCount) = "$" & cboMissionAttoLoiter.SelectedIndex - 1 + 69 Then
            '        lblMissionAttoLoiterValue.Text = aValue(nCount)
            '        Exit For
            '    End If
            'Next
            cboMissionAttoLoiterDirection_SelectedIndexChanged(cboMissionAttoLoiterDuration, Nothing)
        End If
        UpdateTrigger()
    End Sub
    Private Function LimitLatLong(ByVal inputString As String, ByVal decimalPoints As Integer) As String
        inputString = ConvertPeriodToLocal(inputString)
        If IsNumeric(inputString) = True Then
            LimitLatLong = (Convert.ToDouble(inputString)).ToString("0." & ("0").PadRight(decimalPoints, "0"))
        Else
            LimitLatLong = "0." & ("0").PadLeft(decimalPoints, "0")
        End If
        LimitLatLong = ConvertLocalToPeriod(LimitLatLong)
    End Function
    Private Sub cmdMissionWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMissionAttoWrite.Click, cmdMissionMavlinkWrite.Click
        'Const RetryMax As Integer = 5
        'Const WaitForReplyTime As Long = 2000

        Dim nCount As Integer
        Dim nCount2 As Integer
        Dim nCount3 As Integer
        Dim sInput As String
        Dim nChangeCount As Integer
        Dim bFoundOne As Boolean
        Dim sSplit() As String
        Dim bLastWrite As Boolean = False
        Dim sOutput As String

        Me.Cursor = Cursors.WaitCursor

        If nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot Then
            SetMissionStatus("Clearing input buffer...")
            If ClearSerialInBuffer() = False Then
                SetMissionStatus("Failed to clear input buffer... Data is not synchronous")

                tmrComPort.Enabled = True
                Me.Cursor = Cursors.Default
                cmdConfigRead.Enabled = True
                Exit Sub
            End If

            If nWPCount = -1 Then
                bFoundOne = True
                sOutput = "N," & nConfigVehicle & ",0,0"
                SendAttoPilot(sOutput)
                bWaitingAttoUpdate = False
            Else

                With prgMissionAtto
                    .Minimum = 0
                    .Value = 0
                    .Maximum = nWPCount
                End With

                SetMissionStatus("Writing waypoints...")

                For nCount = 0 To nWPCount
                    For nCount3 = 1 To n2WayRetries
                        sInput = ""
                        SetMissionStatus("Writing waypoint #" & nCount & "..." & IIf(nCount3 > 1, "(Attempt #" & nCount3 & ")", ""))
                        sOutput = "M," & nConfigVehicle & "," & nCount & "," & LimitLatLong(aWPLat(nCount), 5) & "," & LimitLatLong(aWPLon(nCount), 5) & "," & ConvertLocalToPeriod(ConvertDistance(aWPAlt(nCount), eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters).ToString("0")) & "," & aWPTrigger(nCount) & "," & ConvertLocalToPeriod(ConvertSpeed(aWPSpeed(nCount), eSpeedUnits, e_SpeedFormat.e_SpeedFormat_KPH).ToString("0"))
                        SendAttoPilot(sOutput)
                        'UpdateSerialDataWindow(sOutput, sOutput, False)
                        'Debug.Print("Output: " & sOutput)

                        bFoundOne = False
                        For nCount2 = 0 To (n2WayTimeout * 1000) / 100
                            If serialPortIn.BytesToRead > 0 Then
                                sInput = serialPortIn.ReadLine
                                UpdateSerialDataWindow(sInput, sInput)
                                'Debug.Print("Input: " & sInput)
                            Else
                                System.Threading.Thread.Sleep(100)
                            End If
                            sSplit = Split(sInput, ",")
                            If UBound(sSplit) >= 2 Then
                                If sSplit(0) = "$OK" And Microsoft.VisualBasic.Left(sSplit(2), 2) = "M*" And ((nConfigVehicle <> 0 And sSplit(1) = nConfigVehicle) Or nConfigVehicle = 0) Then
                                    bFoundOne = True
                                    oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_AttoPilot) = Now.Ticks
                                    System.Threading.Thread.Sleep(250)
                                    Exit For
                                End If
                            End If
                        Next
                        If bFoundOne = True Then
                            Exit For
                        End If
                    Next
                    If bFoundOne = True Then
                        prgMissionAtto.Value = nCount
                    Else
                        Exit For 'Bomb out - failed to respond after RetryMax attempts
                    End If
                Next
                If bFoundOne = True Then
                    sOutput = "M," & nConfigVehicle & "," & nCount & ",0.00000,0.00000,0,0,0"
                    SendAttoPilot(sOutput)
                    'UpdateSerialDataWindow(sOutput, sOutput, False)
                    'Debug.Print("Output: " & sOutput)
                End If
                bWaitingAttoUpdate = False
            End If
        ElseIf nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink Then

            With prgMissionMavlink
                .Minimum = 0
                .Value = 0
                .Maximum = nWPCount
            End With

            dLastMavlinkCommandTime = Now.Ticks
            nMavlinkRetryAttempts = 0
            SendMavlinkWPCountSet()
            bFoundOne = True
            'bWaitingMavlinkUpdate = False
        End If
        tmrComPort.Enabled = True
        Me.Cursor = Cursors.Default

        If bFoundOne = False Then
            SetConfigStatus("Failed to write all waypoints", True)
            MsgBox("AttoPilot vehicle #" & nConfigVehicle & " failed to respond to write request", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Write Failed")
        ElseIf nConfigDevice <> e_ConfigDevice.e_ConfigDevice_MAVlink Then
            If nWPCount = -1 Then
                SetMissionStatus("Waypoints Cleared")
            Else
                SetMissionStatus("Waypoint write complete")
            End If
        End If
    End Sub

    Private Sub txtMissionLatitude_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMissionAttoLatitude.TextChanged, txtMissionGenericLat.TextChanged, txtMissionMavlinkArg5.TextChanged
        Dim sLat As String

        VerifyAddButton()
        If bLockMissionReload = True Or dgMission.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If IsNumeric(sender.Text) = True Then
            Try
                If sender.name <> "txtMissionMavlinkArg5" Then
                    sLat = Convert.ToDouble(sender.Text).ToString("0.000000")
                Else
                    sLat = sender.text
                End If
            Catch ex As Exception
            End Try
            dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Latitude")).Value = sLat
            aWPLat(dgMission.SelectedRows(0).Index) = sLat
            UpdateMissionGE(dgMission.SelectedRows(0).Index, , 0, False)
        End If
    End Sub
    Private Sub txtMissionLongitude_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMissionAttoLongitude.TextChanged, txtMissionGenericLong.TextChanged, txtMissionMavlinkArg6.TextChanged
        Dim sLong As String
        VerifyAddButton()
        If bLockMissionReload = True Or dgMission.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If IsNumeric(sender.Text) = True Then
            Try
                If sender.name <> "txtMissionMavlinkArg6" Then
                    sLong = Convert.ToDouble(sender.Text).ToString("0.000000")
                Else
                    sLong = sender.text
                End If
            Catch ex As Exception
            End Try
            dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Longitude")).Value = sLong
            aWPLon(dgMission.SelectedRows(0).Index) = sLong
            UpdateMissionGE(dgMission.SelectedRows(0).Index, , 0, False)
        End If
    End Sub
    Private Sub txtMissionAltitude_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMissionAttoAltitude.TextChanged, txtMissionGenericAlt.TextChanged
        Dim nAlt As Single

        VerifyAddButton()
        If bLockMissionReload = True Or bStartup = True Or dgMission.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If IsNumeric(sender.Text) = True Then
            Try
                nAlt = Convert.ToSingle(sender.Text)
            Catch ex As Exception
                nAlt = 0
            End Try
            dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Alt")).Value = nAlt
            aWPAlt(dgMission.SelectedRows(0).Index) = nAlt
            UpdateMissionGE(dgMission.SelectedRows(0).Index, , 0, False)
        End If
    End Sub
    Private Sub txtMissionSpeed_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMissionAttoSpeed.TextChanged
        Dim nSpeed As Single
        VerifyAddButton()
        If bLockMissionReload = True Or dgMission.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If IsNumeric(sender.Text) = True Then
            Try
                nSpeed = Convert.ToSingle(sender.Text)
            Catch ex As Exception
                nSpeed = 0
            End Try
            If dgMission.SelectedRows.Count > 0 Then
                dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Speed")).Value = nSpeed
                aWPSpeed(dgMission.SelectedRows(0).Index) = nSpeed
            End If
        End If
    End Sub
    Private Sub txtMissionMavlinkArg7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMissionMavlinkArg7.TextChanged
        Dim sAlt As String
        Dim nCommandIndex As Integer

        VerifyAddButton()
        If bLockMissionReload = True Or dgMission.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If IsNumeric(sender.Text) = True Then
            Try
                sAlt = sender.Text
            Catch ex As Exception
            End Try
            If dgMission.SelectedRows.Count > 0 Then
                nCommandIndex = GetCommandIndex(aWPCommand(dgMission.SelectedRows(0).Index))
                dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Altitude")).Value = sAlt
                aWPAlt(dgMission.SelectedRows(0).Index) = sAlt

                If aCommandArg1(nCommandIndex) = "Altitude" Then
                    UpdateMissionGE(dgMission.SelectedRows(0).Index, , 0, False)
                End If
            End If
        End If
    End Sub
    Private Sub txtMissionMavlinkArg1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMissionMavlinkArg1.TextChanged, txtMissionMavlinkArg2.TextChanged, txtMissionMavlinkArg3.TextChanged, txtMissionMavlinkArg4.TextChanged
        Dim nOther As String
        Dim sColname As String
        VerifyAddButton()
        If bLockMissionReload = True Or dgMission.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If IsNumeric(sender.Text) = True Then
            Select Case sender.name
                Case "txtMissionMavlinkArg1"
                    sColname = "Var 1"
                Case "txtMissionMavlinkArg2"
                    sColname = "Var 2"
                Case "txtMissionMavlinkArg3"
                    sColname = "Var 3"
                Case "txtMissionMavlinkArg4"
                    sColname = "Var 4"
            End Select

            Try
                nOther = sender.Text
            Catch ex As Exception
            End Try
            If dgMission.SelectedRows.Count > 0 Then
                dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, sColname)).Value = nOther

                Select Case sender.name
                    Case "txtMissionMavlinkArg1"
                        aWPOther(dgMission.SelectedRows(0).Index) = nOther
                    Case "txtMissionMavlinkArg2"
                        aWPOther2(dgMission.SelectedRows(0).Index) = nOther
                    Case "txtMissionMavlinkArg3"
                        aWPOther3(dgMission.SelectedRows(0).Index) = nOther
                    Case "txtMissionMavlinkArg4"
                        aWPOther4(dgMission.SelectedRows(0).Index) = nOther
                End Select
            End If
        End If
    End Sub
    Private Sub VerifyAddButton()
        If IsNumeric(txtMissionAttoLatitude.Text) = True And IsNumeric(txtMissionAttoLongitude.Text) = True And IsNumeric(txtMissionAttoAltitude.Text) = True And IsNumeric(txtMissionAttoSpeed.Text) = True Then
            cmdMissionAttoAdd.Enabled = True
        Else
            cmdMissionAttoAdd.Enabled = False
        End If
    End Sub
    Private Sub UpdateTrigger()
        If bLockMissionReload = True Or bStartup = True Or dgMission.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        aWPTrigger(dgMission.SelectedRows(0).Index) = cboMissionAttoReversePath.SelectedIndex & "00" & cboMissionAttoAltitudeControl.SelectedIndex & cboMissionAttoTriggerControl.SelectedIndex & cboMissionAttoLoiterDirection.SelectedIndex & cboMissionAttoLoiterDuration.SelectedIndex + 1 & cboMissionAttoLoiter.SelectedIndex
        dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Trigger")).Value = aWPTrigger(dgMission.SelectedRows(0).Index)
        UpdateMissionGE(dgMission.SelectedRows(0).Index)
    End Sub
    Private Function GetDataGridViewColumn(ByVal oGrid As DataGridView, ByVal tagString As String) As Integer
        Dim nCount As Int16
        For nCount = 0 To oGrid.Columns.Count - 1
            If oGrid.Columns(nCount).Tag = tagString Or oGrid.Columns(nCount).Name = tagString Then
                GetDataGridViewColumn = nCount
                Exit Function
            End If
        Next
    End Function
    Private Sub cboMissionAttoLoiterDirection_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMissionAttoLoiterDirection.SelectedIndexChanged, cboMissionAttoAltitudeControl.SelectedIndexChanged, cboMissionAttoLoiterDuration.SelectedIndexChanged, cboMissionAttoReversePath.SelectedIndexChanged, cboMissionAttoTriggerControl.SelectedIndexChanged
        Dim nCount As Integer

        If bLockMissionReload = True Then
            Exit Sub
        End If
        Select Case sender.name
            Case "cboMissionAttoLoiterDuration"
                'For nCount = 0 To UBound(aIDs)
                '    If aIDs(nCount) = "$" & cboMissionAttoLoiterDuration.SelectedIndex - 1 + 78 Then
                '        lblMissionAttoDurationValue.Text = aValue(nCount)
                '        Exit For
                '    End If
                'Next
            Case "cboMissionAttoTriggerControl"
                'For nCount = 0 To UBound(aIDs)
                '    If cboMissionAttoTriggerControl.SelectedIndex > 1 Then
                '        If aIDs(nCount) = "$" & cboMissionAttoTriggerControl.SelectedIndex - 2 + 87 Then
                '            lblMissionAttoControlValue.Text = aValue(nCount)
                '            Exit For
                '        End If
                '    Else
                '        Exit For
                '    End If
                'Next

        End Select
        UpdateTrigger()
    End Sub
    Private Sub CenterAndTilt(Optional ByVal centerPoint As Integer = -1, Optional ByVal updateTilt As Integer = -1)
        If centerPoint = -1 And dgMission.SelectedRows.Count > 0 Then
            centerPoint = dgMission.SelectedRows(0).Index
        End If
        If centerPoint <= UBound(aWPAlt) Then
            If centerPoint <> -1 And bLockMissionCenter = False And bNewDevice = False And bGoogleLoaded = True And Not webDocument Is Nothing Then
                webDocument.InvokeScript("centerOnLocation", New Object() {ConvertPeriodToLocal(aWPLat(centerPoint)), ConvertPeriodToLocal(aWPLon(centerPoint)), ConvertPeriodToLocal(ConvertDistance(aWPAlt(centerPoint), eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters)), updateTilt, False})
            End If
        End If
    End Sub
    Public Sub UpdateMissionGE(Optional ByVal centerPoint As Integer = -1, Optional ByVal singleWaypoint As Integer = -1, Optional ByVal updateTilt As Integer = -1, Optional ByVal forceCamera As Boolean = False)
        Dim nCount As Integer
        Dim nRunningWPCount As Integer = 0

        If bStartup = True Then
            Exit Sub
        End If

        Try
            'Debug.Print("Offset:" & nConfigAltOffset)
            If Not webDocument Is Nothing And bGoogleLoaded = True Then
                webDocument.InvokeScript("clearMap", New Object() {})
                If nWPCount >= 0 Then
                    'webDocument.InvokeScript("centerOnLocation", New Object() {ConvertPeriodToLocal(aWPLat(0)), ConvertPeriodToLocal(aWPLon(0)), ConvertPeriodToLocal(ConvertDistance(aWPAlt(0), eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters)), updateTilt})
                    'Do While WebBrowser1.ReadyState <> WebBrowserReadyState.Complete
                    '    Application.DoEvents()
                    '    System.Threading.Thread.Sleep(100)
                    'Loop
                    webDocument.InvokeScript("setHomeLatLng", New Object() {ConvertPeriodToLocal(aWPLat(0)), ConvertPeriodToLocal(aWPLon(0)), ConvertPeriodToLocal(ConvertDistance(aWPAlt(0), eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters)), sModelURL, tbarModelScale.Value, ConvertPeriodToLocal(GetPitch(nPitch * nDaePitchRollOffset)), ConvertPeriodToLocal(GetRoll(nRoll * nDaePitchRollOffset)), nCameraTracking, nConfigAltOffset, forceCamera, sHomeIcon})
                    If centerPoint = 0 And bLockMissionCenter = False Then ' And bNewDevice = False Then
                        If forceCamera = True Then
                            webDocument.InvokeScript("centerOnLocation", New Object() {ConvertPeriodToLocal(aWPLat(centerPoint)), ConvertPeriodToLocal(aWPLon(centerPoint)), ConvertPeriodToLocal(ConvertDistance(aWPAlt(centerPoint), eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters)), updateTilt, forceCamera})
                        End If
                    End If
                    For nCount = 1 To nWPCount
                        If aWPLat(nCount) <> 0 And aWPLon(nCount) <> 0 Then
                            'nRunningWPCount = nRunningWPCount + 1
                            webDocument.InvokeScript("addWaypoint", New Object() {ConvertPeriodToLocal(aWPLat(nCount)), ConvertPeriodToLocal(aWPLon(nCount)), ConvertPeriodToLocal(ConvertDistance(aWPAlt(nCount), eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters)), nCount.ToString.PadLeft(2, "0"), bMissionExtrude, sMissionColor, nMissionWidth, nConfigAltOffset, bMissionClampToGround})
                            If nCount = centerPoint And bLockMissionCenter = False Then ' And bNewDevice = False Then
                                webDocument.InvokeScript("centerOnLocation", New Object() {ConvertPeriodToLocal(aWPLat(centerPoint)), ConvertPeriodToLocal(aWPLon(centerPoint)), ConvertPeriodToLocal(ConvertDistance(aWPAlt(centerPoint), eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters)), updateTilt, forceCamera})
                            End If
                        End If
                    Next

                    If nWPCount >= 1 Then
                        If nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot Then
                            If Microsoft.VisualBasic.Left(aWPTrigger(nWPCount), 1) = "0" Then
                                webDocument.InvokeScript("drawHomeLine")
                            End If
                        ElseIf nConfigDevice = e_ConfigDevice.e_ConfigDevice_Generic Or nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink Then
                            webDocument.InvokeScript("drawHomeLine")
                        End If
                    End If
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub txtMissionDefaultAlt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMissionDefaultAlt.LostFocus
        If bStartup = True Then
            Exit Sub
        End If
        If IsNumeric(txtMissionDefaultAlt.Text) = False Then
            Call MsgBox("Invalid Default Altitude", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
            tabInstrumentView.SelectedIndex = 4
            txtMissionAttoAltitude.Focus()
        Else
            Call SaveRegSetting(sRootRegistry & "\Settings", "Default Mission Altitude", ConvertDistance(txtMissionDefaultAlt.Text, eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Feet))
        End If
    End Sub
    Private Sub txtMissionAttoDefaultSpeed_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMissionAttoDefaultSpeed.LostFocus
        If bStartup = True Then
            Exit Sub
        End If
        If IsNumeric(txtMissionAttoDefaultSpeed.Text) = False Then
            Call MsgBox("Invalid Default Altitude", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
            tabInstrumentView.SelectedIndex = 4
            txtMissionAttoDefaultSpeed.Focus()
        Else
            Call SaveRegSetting(sRootRegistry & "\Settings", "Default Mission Atto Speed", ConvertSpeed(txtMissionAttoDefaultSpeed.Text, eSpeedUnits, e_SpeedFormat.e_SpeedFormat_MPerSec))
        End If
    End Sub
    Private Sub cmdMissionNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMissionNew.Click
        nWPCount = -1
        LoadMissionGrid()
        UpdateMissionGE()
    End Sub

    Private Sub MissionSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMissionAttoSearch.Click, cmdMissionGenericSearch.Click, cmdMissionMavlinkSearch.Click
        If Not webDocument Is Nothing And bGoogleLoaded = True Then
            If sender.name = "cmdMissionAttoSearch" Then
                webDocument.InvokeScript("getAddress", New Object() {txtMissionAddressSearchAtto.Text})
            ElseIf sender.name = "cmdMissionGenericSearch" Then
                webDocument.InvokeScript("getAddress", New Object() {txtMissionAddressSearchGeneric.Text})
            ElseIf sender.name = "cmdMissionMavlinkSearch" Then
                webDocument.InvokeScript("getAddress", New Object() {txtMissionAddressSearchMavlink.Text})
            End If
        End If
    End Sub

    Private Sub MissionAddressSearch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMissionAddressSearchAtto.GotFocus, txtMissionAddressSearchGeneric.GotFocus, txtMissionAddressSearchMavlink.GotFocus
        If sender.name = "txtMissionAddressSearchAtto" Then
            Me.AcceptButton = cmdMissionAttoSearch
        ElseIf sender.name = "txtMissionAddressSearchGeneric" Then
            Me.AcceptButton = cmdMissionGenericSearch
        ElseIf sender.name = "txtMissionAddressSearchMavlink" Then
            Me.AcceptButton = cmdMissionMavlinkSearch
        End If
    End Sub

    Private Sub cmdMissionSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMissionSaveAs.Click
        'Declare a SaveFileDialog object
        Dim objSaveFileDialog As New SaveFileDialog

        'Set the Save dialog properties
        With objSaveFileDialog
            .DefaultExt = "txt"
            .FileName = ""
            .Filter = "Mission files (*.txt)|*.txt"
            .FilterIndex = 1
            .OverwritePrompt = True
            .Title = "Save Mission"
            .InitialDirectory = GetRootPath() & "Missions"
        End With

        'Show the Save dialog and if the user clicks the Save button,
        'save the file
        If objSaveFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                SaveMission(objSaveFileDialog.FileName)
            Catch fileException As Exception
                Throw fileException
            End Try
        End If

        'Clean up
        objSaveFileDialog.Dispose()
        objSaveFileDialog = Nothing


    End Sub
    Private Sub SaveMission(ByVal inputFilename As String)
        Dim sFileContents As String
        Dim nCount As Integer

        For nCount = 0 To nWPCount
            If nCount = 0 Then
                sFileContents = "HOME:" & ConvertLocalToPeriod(aWPLat(nCount)) & "," & ConvertLocalToPeriod(aWPLon(nCount)) & "," & ConvertLocalToPeriod(ConvertDistance(aWPAlt(nCount), eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Feet)) & "," & aWPTrigger(nCount) & "," & ConvertLocalToPeriod(ConvertSpeed(aWPSpeed(nCount), eDistanceUnits, e_SpeedFormat.e_SpeedFormat_MPerSec)) & "," & Convert.ToInt32(aWPCommand(nCount)) & "," & aWPOther(nCount) & vbCrLf
            Else
                sFileContents = sFileContents & ConvertLocalToPeriod(aWPLat(nCount)) & "," & ConvertLocalToPeriod(aWPLon(nCount)) & "," & ConvertLocalToPeriod(ConvertDistance(aWPAlt(nCount), eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Feet)) & "," & aWPTrigger(nCount) & "," & ConvertLocalToPeriod(ConvertSpeed(aWPSpeed(nCount), eSpeedUnits, e_SpeedFormat.e_SpeedFormat_MPerSec)) & "," & Convert.ToInt32(aWPCommand(nCount)) & "," & aWPOther(nCount) & vbCrLf
            End If
        Next
        Dim fs As New FileStream(inputFilename, FileMode.Create, FileAccess.Write)
        Dim sMissionFile As StreamWriter = New StreamWriter(fs)
        sMissionFile.WriteLine(sFileContents)
        sMissionFile.Close()

        LoadMissions(inputFilename.Substring(InStrRev(inputFilename, "\")))
    End Sub

    Private Sub cboMissionGenericOffset_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMissionGenericOffset.SelectedIndexChanged
        If bStartup = True Then
            Exit Sub
        End If
        If nConfigDevice = e_ConfigDevice.e_ConfigDevice_Generic Then
            nConfigAltOffset = cboMissionGenericOffset.SelectedIndex
            SaveRegSetting(sRootRegistry & "\Settings", "Config Generic Alt Offset", nConfigAltOffset)
            UpdateMissionGE()
        End If
    End Sub

    Private Sub cmdMissionOverride_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMissionOverride.Click
        Dim nSelectedIndex As Integer
        Dim sOutput As String
        Dim sErrorMessage As String

        nSelectedIndex = dgMission.SelectedRows(0).Index
        sOutput = "G," & nConfigVehicle & "," & LimitLatLong(aWPLat(nSelectedIndex), 5) & "," & LimitLatLong(aWPLon(nSelectedIndex), 5) & "," & ConvertLocalToPeriod(ConvertDistance(aWPAlt(nSelectedIndex), eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters).ToString("0")) & ",300,0," & aWPTrigger(nSelectedIndex)
        Debug.Print("Output: " & sOutput)
        If SendToMessageAndWait(sOutput, sErrorMessage) = True Then
            SetMissionStatus("Override Accepted")
        Else
            SetMissionStatus(sErrorMessage)
        End If
    End Sub
    Private Function SendToMessageAndWait(ByVal inputString As String, Optional ByRef errorMessage As String = "", Optional ByRef returnValue As String = "") As Boolean
        Dim bFoundOne As Boolean
        Dim nCount As Integer
        Dim nCount2 As Integer
        Dim sInput As String
        Dim sSplit() As String
        Dim sHeader As String
        Dim bByte() As Byte
        Dim bWasRunning As Boolean

        errorMessage = ""
        Me.Cursor = Cursors.WaitCursor

        bWasRunning = tmrComPort.Enabled
        tmrComPort.Enabled = False

        If ClearSerialInBuffer() = False Then
            errorMessage = "Failed to clear input buffer... data is not synchronous"
            SendToMessageAndWait = False
            Exit Function
        End If

        Select Case nConfigDevice
            Case e_ConfigDevice.e_ConfigDevice_AttoPilot
                'sInput = serialPortIn.ReadExisting
                'sInput = ""
                SendAttoPilot(inputString)
                'UpdateSerialDataWindow(inputString, inputString, False)
                sHeader = inputString.Substring(0, 1)

                For nCount2 = 1 To 3
                    Do While True
                        bFoundOne = False
                        For nCount = 0 To 20
                            If serialPortIn.IsOpen = False Then
                                Exit Function
                            End If
                            If serialPortIn.BytesToRead > 0 Then
                                sInput = serialPortIn.ReadLine
                                UpdateSerialDataWindow(sInput, sInput)
                                'Debug.Print(sInput)
                                If (InStr(sInput, "$OK") <> 0 Or InStr(sInput, "$" & sHeader) <> 0) And InStr(sInput, vbCr) <> 0 Then
                                    bFoundOne = True
                                    Exit For
                                End If
                            Else
                                Application.DoEvents()
                                System.Threading.Thread.Sleep(100)
                            End If
                        Next
                        If bFoundOne = False Then
                            errorMessage = "Atto failed to respond to message"
                            Exit Do
                        End If
                        sSplit = Split(sInput, ",")
                        If UBound(sSplit) >= 2 Then
                            nConfigVehicle = -1
                            If IsNumeric(sSplit(1)) = True Then
                                nConfigVehicle = Convert.ToInt16(sSplit(1))
                            End If
                            If sSplit(0) = "$OK" And Microsoft.VisualBasic.Left(sSplit(2), 1) = sHeader And ((nConfigVehicle <> 0 And nConfigVehicle = nConfigVehicle) Or nConfigVehicle = 0) Then
                                bFoundOne = True
                                Exit Do
                            ElseIf sSplit(0) = "$" & sHeader And ((nConfigVehicle <> 0 And nConfigVehicle = nConfigVehicle) Or nConfigVehicle = 0) Then
                                If UBound(sSplit) >= 3 Then
                                    returnValue = sSplit(3)
                                    If InStr(returnValue, "*") <> 0 Then
                                        returnValue = returnValue.Substring(0, InStr(returnValue, "*") - 1)
                                    End If
                                End If
                            End If
                        End If
                    Loop
                    If bFoundOne = True Then
                        Exit For
                    End If
                Next
        End Select

        If bFoundOne = True Then
            SendToMessageAndWait = True
        Else
            SendToMessageAndWait = False
        End If
        Me.Cursor = Cursors.Default
        tmrComPort.Enabled = bWasRunning
    End Function
    Public Sub SetMapMode()
        If eMapSelection = e_MapSelection.e_MapSelection_None Or bGoogleFailed = True Then
            cmdCenterOnPlane.Visible = False
            cmdClearMap.Visible = False
            lblMissionDoubleClickLabel.Visible = False
            cmdConnect.Enabled = True
            'Hides the second tabpage.
            If tabMapView.TabPages.Count = 2 Then
                objTabViewMapView = tabMapView.TabPages(0)
                tabMapView.Controls.Remove(tabMapView.TabPages(0))
            End If
            tabMapView_SelectedIndexChanged(Nothing, Nothing)
            SplitContainer1.Panel2MinSize = 120
        ElseIf eMapSelection = e_MapSelection.e_MapSelection_GoogleEarth Then
            cmdCenterOnPlane.Visible = True
            cmdClearMap.Visible = True
            lblMissionDoubleClickLabel.Visible = True
            If tabMapView.TabPages.Count = 1 Then
                tabMapView.TabPages.Insert(0, objTabViewMapView)
                objTabViewMapView = Nothing
            End If
            SplitContainer1.Panel2MinSize = 340
        End If
    End Sub

    Private Sub ControlAtto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdControlAttoResetBaro.Click, cmdControlAttoResume.Click, cmdControlAttoReturnHome.Click, cmdControlAttoLoiter.Click, cmdControlAttoReturnHome.Click, cmdControlAttoSpeed.Click, cmdControlAttoResetSpeed.Click, cmdControlAttoResetMission.Click, cmdControlAttoResetReboot.Click, cmdControlAttoTriggerServo.Click
        Dim nSelectedIndex As Integer
        Dim sOutput As String
        Dim sErrorMessage As String
        Dim sSuccessMessage As String
        Dim bValid As Boolean
        Dim sInvalidMessage As String
        Dim nRet As Long

        bValid = True
        Select Case sender.name
            Case "cmdControlAttoResetBaro"
                If IsNumeric(txtControlAttoPressure.Text) = False Then
                    sInvalidMessage = "Invalid Barometric Pressure Value"
                    bValid = False
                Else
                    sOutput = "P," & nConfigVehicle & "," & Convert.ToSingle(txtControlAttoPressure.Text).ToString("0")
                    sSuccessMessage = "Home Barometer Reset"
                End If
            Case "cmdControlAttoResume"
                sOutput = "R," & nConfigVehicle
                sSuccessMessage = "Mission Resumed"
            Case "cmdControlAttoReturnHome"
                sOutput = "V," & nConfigVehicle & ",0"
                sSuccessMessage = "Returning to Home"
            Case "cmdControlAttoReturnRally"
                sOutput = "V," & nConfigVehicle & ",1"
                sSuccessMessage = "Returning to Rally"
            Case "cmdControlAttoLoiter"
                sOutput = "L," & nConfigVehicle
                sSuccessMessage = "Loitering..."
            Case "cmdControlAttoSpeed"
                If IsNumeric(txtControlAttoSpeed.Text) = False Then
                    sInvalidMessage = "Invalid Speed Value"
                    bValid = False
                Else
                    sOutput = "H," & nConfigVehicle & "," & ConvertSpeed(ConvertPeriodToLocal(txtControlAttoSpeed.Text), eSpeedUnits, e_SpeedFormat.e_SpeedFormat_KPH, "0")
                    sSuccessMessage = "Speed Override Set to " & txtControlAttoSpeed.Text & " " & GetSpeedUnitsText()
                End If
            Case "cmdControlAttoResetSpeed"
                sOutput = "K," & nConfigVehicle & ",3"
                sSuccessMessage = "Speed control returned to AttoPilot"
                'Case "chkControlAttoAtuoMode"
                '    If chkControlAttoAtuoMode.Checked = True Then
                '        sOutput = "B," & nConfigVehicle
                '        sSuccessMessage = "Autonomous Mode Set"
                '    Else
                '        sOutput = "C," & nConfigVehicle
                '        sSuccessMessage = "Manual Mode Set"
                '    End If
            Case "cmdControlAttoResetMission"
                sOutput = "W," & nConfigVehicle & "," & cboControlAttoWPNumber.SelectedIndex
                sSuccessMessage = "Mission Restarted at WP #" & cboControlAttoWPNumber.Text
            Case "cmdControlAttoResetReboot"
                nRet = MsgBox("Are you sure you want to reboot your AttoPilot?" & vbCrLf & "This will cause a crash if done mid-flight!", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Warning!")
                If nRet <> MsgBoxResult.Yes Then
                    bValid = False
                Else
                    sOutput = "X," & nConfigVehicle
                    sSuccessMessage = "Rebooting AttoPilot..."
                End If
            Case "cmdControlAttoTriggerServo"
                sOutput = "T," & nConfigVehicle
                sSuccessMessage = "Servo triggered on AttoPilot"

        End Select

        If bValid = False Then
            SetControlStatus(sInvalidMessage, True)
        Else
            If SendToMessageAndWait(sOutput, sErrorMessage) = True Then
                SetControlStatus(sSuccessMessage)
            Else
                SetControlStatus(sErrorMessage, True)
                'If sender.name = "chkControlAttoAtuoMode" Then
                '    chkControlAttoAtuoMode.Checked = Not chkControlAttoAtuoMode.Checked
                'End If
            End If
        End If

    End Sub
    Public Function ClearSerialInBuffer() As Boolean
        Const MaxTime As Long = 3000
        Const ClearTime As Long = 300
        Dim nStartTime As Long = 0
        Dim nThisTime As Long = 0
        Dim sInput As String

        tmrComPort.Enabled = False
        nStartTime = Now.Ticks
        nThisTime = Now.Ticks
        Do While True
            If serialPortIn.IsOpen = True Then
                If serialPortIn.BytesToRead > 0 Then
                    nThisTime = Now.Ticks
                    sInput = serialPortIn.ReadLine()
                    UpdateSerialDataWindow(sInput, sInput)
                Else
                    System.Threading.Thread.Sleep(100)
                End If
                If Now.Ticks - nThisTime > ClearTime * 10000 Then
                    ClearSerialInBuffer = True
                    Exit Function
                ElseIf Now.Ticks - nStartTime > MaxTime * 10000 Then
                    ClearSerialInBuffer = False
                    Exit Function
                End If
            Else
                Exit Do
            End If
        Loop
    End Function

    Private Sub cmdSetHomeAlt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetHomeAlt.Click
        nHomeAlt = nAltitude
        nHomeAltIndicator = nAltitude
        AltimeterInstrumentControl1.SetAlimeterParameters(nAltitude - nHomeAltIndicator, sDistanceUnits)
    End Sub

    Private Sub cmdMissionAttoAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMissionAttoAdd.Click, cmdMissionMavlinkAdd.Click
        Dim sLatLocal As String = ""
        Dim sLongLocal As String = ""
        Dim nCommandLocal As Integer
        Dim sOtherLocal As String = ""
        Dim sAltLocal As String = ""

        If nConfigDevice = e_ConfigDevice.e_ConfigDevice_AttoPilot Then
            AddWaypoint(txtMissionAttoLatitude.Text, txtMissionAttoLongitude.Text, Convert.ToSingle(txtMissionAttoAltitude.Text), txtMissionAttoSpeed.Text, "")
            UpdateTrigger()
        ElseIf nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink Then
            If txtMissionMavlinkArg1.Visible = True Then
                sOtherLocal = txtMissionMavlinkArg1.Text
            End If
            If txtMissionMavlinkArg5.Visible = True Then
                sLatLocal = txtMissionMavlinkArg5.Text
            End If
            If txtMissionMavlinkArg6.Visible = True Then
                sLongLocal = txtMissionMavlinkArg6.Text
            End If
            If txtMissionMavlinkArg7.Visible = True Then
                sAltLocal = txtMissionMavlinkArg7.Text
            End If
            AddWaypoint(sLatLocal, sLongLocal, sAltLocal, -1, "", CType(cboMissionMavlinkCommand.SelectedItem, cValueDesc).Value, sOtherLocal)
            UpdateMissionGE(dgMission.SelectedRows(0).Index)
        End If
    End Sub

    Private Sub mnuJoystickCalibration_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuJoystickCalibration.Click
        frmJoystick.ShowDialog()
    End Sub

    Private Sub cmdJoystickCalibrate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJoystickCalibrate.Click
        frmJoystick.ShowDialog()
    End Sub

    Private Sub chkJoystickEnable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkJoystickEnable.CheckedChanged
        If chkJoystickEnable.Checked = False Then
            tmrJoystick.Enabled = False
            ReleaseJoystick()
        Else
            tmrJoystick.Enabled = True
        End If
    End Sub

    Private Sub tmrJoystick_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrJoystick.Tick
        Dim nFoundIndex As Integer
        Dim nCount As Integer

        'Dim nMinSlider As Long
        'Dim nMaxSlider As Long

        'nMinSlider = tbarJoystickThrottle.Minimum
        'nMaxSlider = tbarJoystickThrottle.Maximum

        Dim bSuccess As Boolean
        Dim nJoystickCurrent As Long
        Dim nSliderValue As Long
        Dim nOutputValue As Long

        ' get status
        If jst.UpdateStatus = True Then
            For nCount = 1 To 5
                With cJoystick(nCount)
                    bSuccess = GetJoystickValue(jst, nCount, .Axis, -1000, 1000, .SubTrim, .Reversed, nJoystickCurrent, nSliderValue, nOutputValue)

                    Select Case nCount
                        Case 1
                            tbarJoystickOutput1.Enabled = bSuccess
                            lblJoystickOutput1.Enabled = bSuccess
                            If bSuccess = True Then
                                tbarJoystickOutput1.Value = nSliderValue
                                cJoystick(1).CurrentValue = nJoystickCurrent
                                cJoystick(1).SliderValue = nSliderValue
                            Else
                                tbarJoystickOutput1.Value = 0
                            End If
                        Case 2
                            tbarJoystickOutput2.Enabled = bSuccess
                            lblJoystickOutput2.Enabled = bSuccess
                            If bSuccess = True Then
                                tbarJoystickOutput2.Value = nSliderValue
                                cJoystick(2).CurrentValue = nJoystickCurrent
                                cJoystick(2).SliderValue = nSliderValue
                            Else
                                tbarJoystickOutput2.Value = 0
                            End If
                        Case 3
                            tbarJoystickOutput3.Enabled = bSuccess
                            lblJoystickOutput3.Enabled = bSuccess
                            If bSuccess = True Then
                                tbarJoystickOutput3.Value = nSliderValue
                                cJoystick(3).CurrentValue = nJoystickCurrent
                                cJoystick(3).SliderValue = nSliderValue
                            Else
                                tbarJoystickOutput3.Value = 0
                            End If
                        Case 4
                            tbarJoystickOutput4.Enabled = bSuccess
                            lblJoystickOutput4.Enabled = bSuccess
                            If bSuccess = True Then
                                tbarJoystickOutput4.Value = nSliderValue
                                cJoystick(4).CurrentValue = nJoystickCurrent
                                cJoystick(4).SliderValue = nSliderValue
                            Else
                                tbarJoystickOutput4.Value = 0
                            End If
                            'Case 5
                            '    tbarJoystickOutput5.Enabled = bSuccess
                            '    lblJoystickOutput5.Enabled = bSuccess
                            '    If bSuccess = True Then
                            '        tbarJoystickOutput5.Value = nSliderValue
                            '        cJoystick(5).CurrentValue = nJoystickCurrent
                            '        cJoystick(5).SliderValue = nSliderValue
                            '    Else
                            '        tbarJoystickOutput5.Value = 0
                            '    End If

                    End Select
                End With
            Next nCount

            SendJoystickMessages(nJoystickOutput)

        Else
            tabPortControl_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        frmHeartbeat.ShowDialog()
    End Sub

    Private Sub pnlLinkLost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlLinkLost.Click, lblLinkLostLabel.Click, lblLinkLostMessage.Click, lblLinkLostMessageType.Click, lblLinkLostTime.Click
        oActiveDevices.ClearAlarms()
    End Sub

    Private Sub chkViewHeadLock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkViewHeadLock.CheckedChanged
        bHeadLock = chkViewHeadLock.Checked
    End Sub
    Private Function FindCommandIndex(ByVal inputNumber As Integer) As Integer
        Dim nCount As Integer
        For nCount = 0 To UBound(aCommandValue)
            If aCommandValue(nCount) = inputNumber Then
                FindCommandIndex = nCount
                Exit For
            End If
        Next
    End Function
    Private Sub SetMissionParameters(ByVal inputMessage As String, ByVal labelControl As Label, ByVal textControl As TextBox, ByVal comboControl As ComboBox, ByVal gridCell As DataGridViewCell)
        Dim sLabel As String
        Dim sToolTip As String
        Dim sCombo As String
        Dim sSplit() As String
        Dim sSplit2() As String
        Dim nCount As Integer

        Try
            If inputMessage = "" Then
                labelControl.Visible = False
                textControl.Visible = False
                If Not comboControl Is Nothing Then
                    comboControl.Visible = False
                End If
                gridCell.Value = ""
            Else
                sToolTip = ""
                If InStr(inputMessage, "(") <> 0 Then
                    sToolTip = Mid(inputMessage, InStr(inputMessage, "(") + 1)
                    sToolTip = Mid(sToolTip, 1, InStrRev(sToolTip, ")") - 1)
                    inputMessage = Replace(inputMessage, "(" & sToolTip & ")", "")

                End If

                sCombo = ""
                If InStr(inputMessage, "{") <> 0 Then
                    sCombo = Mid(inputMessage, InStr(inputMessage, "{") + 1)
                    sCombo = Mid(sCombo, 1, InStrRev(sCombo, "}") - 1)
                    inputMessage = Replace(inputMessage, "{" & sCombo & "}", "")

                    If Not comboControl Is Nothing Then

                        sSplit = Split(sCombo, ";")
                        With comboControl
                            .Items.Clear()
                            For nCount = 0 To UBound(sSplit)
                                sSplit2 = Split(sSplit(nCount), "=")
                                .Items.Add(New cValueDesc(sSplit2(0), sSplit2(1)))
                            Next
                            .Visible = True
                        End With
                        ToolTip1.SetToolTip(comboControl, sToolTip)
                    End If
                    textControl.Visible = False
                Else
                    textControl.Visible = True
                    If Not comboControl Is Nothing Then
                        comboControl.Visible = False
                    End If
                    ToolTip1.SetToolTip(textControl, sToolTip)
                End If

                labelControl.Visible = True
                labelControl.Text = Trim(inputMessage)
            End If
        Catch
        End Try
    End Sub
    Private Sub ParseCommandMessage(ByRef inputMessage As String, ByRef unitVar As String, ByRef multVar As Single, ByRef formatValue As String)
        Dim sUnit As String
        Dim sMult As String

        Try
            unitVar = ""
            If InStr(inputMessage, "[") <> 0 Then
                sUnit = Mid(inputMessage, InStr(inputMessage, "[") + 1)
                sUnit = Mid(sUnit, 1, InStrRev(sUnit, "]") - 1)
                inputMessage = Replace(inputMessage, "[" & sUnit & "]", "")

                unitVar = sUnit
            End If

            multVar = 1
            If InStr(inputMessage, "<") <> 0 Then
                sMult = Mid(inputMessage, InStr(inputMessage, "<") + 1)
                sMult = Mid(sMult, 1, InStrRev(sMult, ">") - 1)
                inputMessage = Replace(inputMessage, "<" & sMult & ">", "")
                If IsNumeric(sMult) = True Then
                    multVar = Convert.ToSingle(sMult)
                End If
            End If

            formatValue = ""
            If InStr(inputMessage, "~") <> 0 Then
                formatValue = Mid(inputMessage, InStr(inputMessage, "~") + 1)
                formatValue = Mid(formatValue, 1, InStrRev(formatValue, "~") - 1)
                inputMessage = Replace(inputMessage, "~" & formatValue & "~", "")
            End If
        Catch
        End Try
    End Sub
    Private Sub cboMissionMavlinkCommand_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMissionMavlinkCommand.SelectedIndexChanged
        'Dim sParam1 As String
        'Dim sParam2 As String
        'Dim sParam3 As String
        'Dim sParam4 As String
        'Dim sParam5 As String
        'Dim sParam6 As String
        'Dim sParam7 As String
        Dim nIndex As Integer

        If dgMission.SelectedRows.Count = 0 Then
            Exit Sub
        End If

        nIndex = FindCommandIndex(CType(cboMissionMavlinkCommand.SelectedItem, cValueDesc).Value)

        SetMissionParameters(aCommandArg1(nIndex), lblMissionMavlinkArg1, txtMissionMavlinkArg1, cboMissionMavlinkArg1, dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Var 1")))
        SetMissionParameters(aCommandArg2(nIndex), lblMissionMavlinkArg2, txtMissionMavlinkArg2, cboMissionMavlinkArg2, dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Var 2")))
        SetMissionParameters(aCommandArg3(nIndex), lblMissionMavlinkArg3, txtMissionMavlinkArg3, cboMissionMavlinkArg3, dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Var 3")))
        SetMissionParameters(aCommandArg4(nIndex), lblMissionMavlinkArg4, txtMissionMavlinkArg4, cboMissionMavlinkArg4, dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Var 4")))
        SetMissionParameters(aCommandArg5(nIndex), lblMissionMavlinkArg5, txtMissionMavlinkArg5, Nothing, dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Latitude")))
        SetMissionParameters(aCommandArg6(nIndex), lblMissionMavlinkArg6, txtMissionMavlinkArg6, Nothing, dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Longitude")))
        SetMissionParameters(aCommandArg7(nIndex), lblMissionMavlinkArg7, txtMissionMavlinkArg7, Nothing, dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Altitude")))

        lblMissionAddressSearchMavlink.Visible = txtMissionMavlinkArg5.Visible
        txtMissionAddressSearchMavlink.Visible = txtMissionMavlinkArg5.Visible
        cmdMissionMavlinkSearch.Visible = txtMissionMavlinkArg5.Visible

        'sParam1 = aCommandArg1(nIndex)
        'sParam2 = aCommandArg2(nIndex)
        'sParam3 = aCommandArg3(nIndex)
        'sParam4 = aCommandArg4(nIndex)
        'sParam5 = aCommandArg5(nIndex)
        'sParam6 = aCommandArg6(nIndex)
        'sParam7 = aCommandArg7(nIndex)


        'If sParam1 = "" Then
        '    lblMissionMavlinkArg1.Visible = False
        '    txtMissionMavlinkArg1.Visible = False
        '    cboMissionMavlinkArg1.Visible = False
        '    dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Var 1")).Value = ""
        'Else
        '    lblMissionMavlinkArg1.Text = sParam1
        '    lblMissionMavlinkArg1.Visible = True
        '    txtMissionMavlinkArg1.Visible = True
        '    dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Var 1")).Value = aWPOther(dgMission.SelectedRows(0).Index)
        'End If

        'If sParam2 = "" Then
        '    lblMissionMavlinkArg2.Visible = False
        '    txtMissionMavlinkArg2.Visible = False
        '    cboMissionMavlinkArg2.Visible = False
        '    dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Var 2")).Value = ""
        'Else
        '    lblMissionMavlinkArg2.Text = sParam2
        '    lblMissionMavlinkArg2.Visible = True
        '    txtMissionMavlinkArg2.Visible = True
        '    dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Var 2")).Value = aWPOther2(dgMission.SelectedRows(0).Index)
        'End If

        'If sParam3 = "" Then
        '    lblMissionMavlinkArg3.Visible = False
        '    txtMissionMavlinkArg3.Visible = False
        '    cboMissionMavlinkArg3.Visible = False
        '    dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Var 3")).Value = ""
        'Else
        '    lblMissionMavlinkArg3.Text = sParam3
        '    lblMissionMavlinkArg3.Visible = True
        '    txtMissionMavlinkArg3.Visible = True
        '    dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Var 3")).Value = aWPOther3(dgMission.SelectedRows(0).Index)
        'End If

        'If sParam4 = "" Then
        '    lblMissionMavlinkArg4.Visible = False
        '    txtMissionMavlinkArg4.Visible = False
        '    cboMissionMavlinkArg4.Visible = False
        '    dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Var 4")).Value = ""
        'Else
        '    lblMissionMavlinkArg4.Text = sParam4
        '    lblMissionMavlinkArg4.Visible = True
        '    txtMissionMavlinkArg4.Visible = True
        '    dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Var 4")).Value = aWPOther4(dgMission.SelectedRows(0).Index)
        'End If

        'If sParam5 = "" Then
        '    lblMissionMavlinkArg5.Visible = False
        '    txtMissionMavlinkArg5.Visible = False
        '    dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Latitude")).Value = ""
        'Else
        '    lblMissionMavlinkArg5.Text = sParam5
        '    lblMissionMavlinkArg5.Visible = True
        '    txtMissionMavlinkArg5.Visible = True
        '    dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Latitude")).Value = aWPLat(dgMission.SelectedRows(0).Index)
        'End If

        'If sParam6 = "" Then
        '    lblMissionMavlinkArg6.Visible = False
        '    txtMissionMavlinkArg6.Visible = False
        '    dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Longitude")).Value = ""
        'Else
        '    lblMissionMavlinkArg6.Text = sParam6
        '    lblMissionMavlinkArg6.Visible = True
        '    txtMissionMavlinkArg6.Visible = True
        '    dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Longitude")).Value = aWPLat(dgMission.SelectedRows(0).Index)
        'End If

        'If sParam7 = "" Then
        '    lblMissionMavlinkArg7.Visible = False
        '    txtMissionMavlinkArg7.Visible = False
        '    dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Altitude")).Value = ""
        'Else
        '    lblMissionMavlinkArg7.Text = sParam7
        '    lblMissionMavlinkArg7.Visible = True
        '    txtMissionMavlinkArg7.Visible = True
        '    dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Altitude")).Value = aWPLon(dgMission.SelectedRows(0).Index)
        'End If

        If dgMission.SelectedRows.Count > 0 Then
            dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, "Command")).Value = GetCommandName(CType(cboMissionMavlinkCommand.SelectedItem, cValueDesc).Value)
            aWPCommand(dgMission.SelectedRows(0).Index) = CType(cboMissionMavlinkCommand.SelectedItem, cValueDesc).Value
        End If

    End Sub

    Private Sub cmdControlMavlinkMode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdControlMavlinkMode.Click
        Dim aOutput() As Byte
        'FIX314
        aOutput = New Byte() {85, 2, 0, 127, 0, 11, nConfigVehicle, 1, CType(cboControlMavlinkMode.SelectedItem, cValueDesc).Value}
        'sOutput = Chr(85) & Chr(2) & Chr(0) & Chr("&H7F") & Chr(0) & Chr(11) & Chr(nConfigVehicle) & Chr(CType(cboControlMavlinkMode.SelectedItem, cValueDesc).Value)
        SendMavLink(aOutput)
        lblControlMavlinkStatus.Text = "Status: Mode change request sent - " & cboControlMavlinkMode.Text
    End Sub
    Private Sub cmdControlMavlinkAction_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdControlMavlinkAction.Click
        Dim aOutput() As Byte
        'FIX314
        If CType(cboControlMavlinkAction.SelectedItem, cValueDesc).Value = 11 Then
            If MsgBox("Are you sure you want to reboot the APM?" & vbCrLf & "Be VERY careful doing this in-flight as it will" & vbCrLf & "take about 12 seconds for the system to re-initialize", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Warning") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        aOutput = New Byte() {85, 3, 0, 127, 0, 10, nConfigVehicle, 1, CType(cboControlMavlinkAction.SelectedItem, cValueDesc).Value}
        'sOutput = Chr(85) & Chr(3) & Chr(0) & Chr("&H7F") & Chr(0) & Chr(10) & Chr(nConfigVehicle) & Chr(1) & Chr(CType(cboControlMavlinkAction.SelectedItem, cValueDesc).Value)
        SendMavLink(aOutput)
        lblControlMavlinkStatus.Text = "Status: Action request sent - " & cboControlMavlinkAction.Text
    End Sub
    Private Sub cmdControlMavlinkSetAltitude_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdControlMavlinkSetAltitude.Click
        Dim aOutput() As Byte
        'FIX314

        If IsNumeric(txtControlMavlinkSetAltitude.Text) = True Then
            aOutput = New Byte() {85, 5, 0, 127, 0, 65, nConfigVehicle, CType(cboControlMavlinkAction.SelectedItem, cValueDesc).Value}
            aOutput = ConCatArray(aOutput, ConvertInteger32ToMavlinkByte(txtControlMavlinkSetAltitude.Text))
            'sOutput = Chr(85) & Chr(5) & Chr(0) & Chr("&H7F") & Chr(0) & Chr(65) & Chr(nConfigVehicle) & ConvertInteger32ToMavlink(txtControlMavlinkSetAltitude.Text)
            SendMavLink(aOutput)
            lblControlMavlinkStatus.Text = "Status: Altitude set to " & txtControlMavlinkSetAltitude.Text
        Else
            lblControlMavlinkStatus.Text = "Status: Invalid altitude value"
        End If
    End Sub
    Private Sub cmdControlMavlinkSetHome_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdControlMavlinkSetHome.Click
        Dim aOutput() As Byte
        'FIX314
        aOutput = New Byte() {85, 18, 0, 127, 0, 50, nConfigVehicle, 1}
        aOutput = ConCatArray(aOutput, ConvertSingleToMavlinkByte(nLongitude))
        aOutput = ConCatArray(aOutput, ConvertSingleToMavlinkByte(nLatitude))
        aOutput = ConCatArray(aOutput, ConvertSingleToMavlinkByte(nAltitude))
        aOutput = ConCatArray(aOutput, New Byte() {0})
        'sOutput = Chr(85) & Chr(18) & Chr(0) & Chr("&H7F") & Chr(0) & Chr(50) & Chr(nConfigVehicle) & Chr(1) & ConvertSingleToMavlink(nLongitude) & ConvertSingleToMavlink(nLatitude) & ConvertSingleToMavlink(nAltitude) & Chr(0)
        SendMavLink(aOutput)
        lblControlMavlinkStatus.Text = "Status: Home set"
    End Sub

    Private Sub DisableMavlinkStatusRates()
        Dim aOutput() As Byte
        Dim nCount As Integer

        For nCount = 1 To 12
            aOutput = New Byte() {85, 6, 0, 127, 0, 66, nConfigVehicle, 1, nCount, 0, 0, 0}
            SendMavLink(aOutput)
        Next nCount
    End Sub
    Private Sub UpdateMavlinkStatusRates()
        Dim aOutput() As Byte
        Dim aGPSVariable() As Byte
        Dim aAttitudeVariable() As Byte
        Dim aWaypointVariable() As Byte

        If cboGPS.SelectedIndex = 0 Then
            aGPSVariable = New Byte() {0, 0, 0}
        Else
            aGPSVariable = ConvertIntegerToMavlinkByte(cboGPS.SelectedIndex)
            aGPSVariable = ConCatArray(aGPSVariable, New Byte() {1})
        End If

        If cboAttitude.SelectedIndex = 0 Then
            aAttitudeVariable = New Byte() {0, 0, 0}
        Else
            aAttitudeVariable = ConvertIntegerToMavlinkByte(cboAttitude.SelectedIndex)
            aAttitudeVariable = ConCatArray(aAttitudeVariable, New Byte() {1})
        End If

        If cboWaypoint.SelectedIndex = 0 Then
            aWaypointVariable = New Byte() {0, 0, 0}
        Else
            aWaypointVariable = ConvertIntegerToMavlinkByte(cboWaypoint.SelectedIndex)
            aWaypointVariable = ConCatArray(aWaypointVariable, New Byte() {1})
        End If

        If bStartup = True Then
            Exit Sub
        End If
        Try
            'sOutput = Chr(85) & Chr(6) & Chr(0) & Chr("&H7F") & Chr(0) & Chr(66) & Chr(nConfigVehicle) & Chr(1) & Chr(1) & sWaypointVariable
            'SendMavLink(sOutput)

            'MAV_DATA_STREAM_RAW_SENSORS
            aOutput = New Byte() {85, 6, 0, 127, 0, 66, nConfigVehicle, 1, 1}
            aOutput = ConCatArray(aOutput, aWaypointVariable)
            SendMavLink(aOutput)
            'System.Threading.Thread.Sleep(200)

            'MAV_DATA_STREAM_EXTENDED_STATUS
            aOutput = New Byte() {85, 6, 0, 127, 0, 66, nConfigVehicle, 1, 2}
            aOutput = ConCatArray(aOutput, aGPSVariable)
            SendMavLink(aOutput)
            'System.Threading.Thread.Sleep(200)

            'MAV_DATA_STREAM_RC_CHANNELS
            aOutput = New Byte() {85, 6, 0, 127, 0, 66, nConfigVehicle, 1, 3}
            aOutput = ConCatArray(aOutput, aWaypointVariable)
            SendMavLink(aOutput)
            'System.Threading.Thread.Sleep(200)

            'MAV_DATA_STREAM_RAW_CONTROLLER
            aOutput = New Byte() {85, 6, 0, 127, 0, 66, nConfigVehicle, 1, 4}
            aOutput = ConCatArray(aOutput, aWaypointVariable)
            SendMavLink(aOutput)
            'System.Threading.Thread.Sleep(200)

            'MAV_DATA_STREAM_POSITION
            aOutput = New Byte() {85, 6, 0, 127, 0, 66, nConfigVehicle, 1, 6}
            aOutput = ConCatArray(aOutput, aGPSVariable)
            SendMavLink(aOutput)
            'System.Threading.Thread.Sleep(200)

            'MAV_DATA_STREAM_EXTRA1
            aOutput = New Byte() {85, 6, 0, 127, 0, 66, nConfigVehicle, 1, 10}
            aOutput = ConCatArray(aOutput, aAttitudeVariable)
            SendMavLink(aOutput)
            'System.Threading.Thread.Sleep(200)

            'MAV_DATA_STREAM_EXTRA2
            aOutput = New Byte() {85, 6, 0, 127, 0, 66, nConfigVehicle, 1, 11}
            aOutput = ConCatArray(aOutput, aGPSVariable)
            'aOutput = ConCatArray(aOutput, New Byte() {0, 0, 0})
            SendMavLink(aOutput)
            'System.Threading.Thread.Sleep(200)

            'MAV_DATA_STREAM_EXTRA3
            aOutput = New Byte() {85, 6, 0, 127, 0, 66, nConfigVehicle, 1, 12}
            aOutput = ConCatArray(aOutput, New Byte() {0, 0, 0})
            SendMavLink(aOutput)
            'System.Threading.Thread.Sleep(200)

            'lblControlMavlinkStatus.Text = "Status: Telemetry rate change disabled for the moment"
            lblControlMavlinkStatus.Text = "Status: MAVlink Telemetry rate set"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cboMissionMavlinkArg1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMissionMavlinkArg1.SelectedIndexChanged, cboMissionMavlinkArg2.SelectedIndexChanged, cboMissionMavlinkArg3.SelectedIndexChanged, cboMissionMavlinkArg4.SelectedIndexChanged
        Dim nOther As String
        Dim sColname As String
        VerifyAddButton()
        If bLockMissionReload = True Or dgMission.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        Select Case sender.name
            Case "cboMissionMavlinkArg1"
                sColname = "Var 1"
            Case "cboMissionMavlinkArg2"
                sColname = "Var 2"
            Case "cboMissionMavlinkArg3"
                sColname = "Var 3"
            Case "cboMissionMavlinkArg4"
                sColname = "Var 4"
        End Select

        Try
            nOther = CType(sender.SelectedItem, cValueDesc).Value
        Catch ex As Exception
        End Try
        If dgMission.SelectedRows.Count > 0 Then
            dgMission.Rows(dgMission.SelectedRows(0).Index).Cells(GetDataGridViewColumn(dgMission, sColname)).Value = nOther

            Select Case sender.name
                Case "txtMissionMavlinkArg1", "cboMissionMavlinkArg1"
                    aWPOther(dgMission.SelectedRows(0).Index) = nOther
                Case "txtMissionMavlinkArg2", "cboMissionMavlinkArg2"
                    aWPOther2(dgMission.SelectedRows(0).Index) = nOther
                Case "txtMissionMavlinkArg3", "cboMissionMavlinkArg3"
                    aWPOther3(dgMission.SelectedRows(0).Index) = nOther
                Case "txtMissionMavlinkArg4", "cboMissionMavlinkArg1"
                    aWPOther4(dgMission.SelectedRows(0).Index) = nOther
            End Select
        End If
    End Sub

    Private Sub cmdControlMavlinkRestartMission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdControlMavlinkRestartMission.Click
        Dim aOutput() As Byte
        'FIX314
        aOutput = New Byte() {85, 4, 0, 127, 0, 41, nConfigVehicle, 1, 0, 0}
        'sOutput = Chr(85) & Chr(3) & Chr(0) & Chr("&H7F") & Chr(0) & Chr(10) & Chr(nConfigVehicle) & Chr(1) & Chr(CType(cboControlMavlinkAction.SelectedItem, cValueDesc).Value)
        SendMavLink(aOutput)
        lblControlMavlinkStatus.Text = "Status: Restart Mission Sent"
    End Sub

    Private Sub cmdControlMavlinkGotoCommand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdControlMavlinkGotoCommand.Click
        Dim aOutput() As Byte
        'FIX314
        aOutput = New Byte() {85, 4, 0, 127, 0, 41, nConfigVehicle, 1}
        aOutput = ConCatArray(aOutput, ConvertIntegerToMavlinkByte(cboControlMavlinkWPNumber.SelectedIndex, False))
        'sOutput = Chr(85) & Chr(3) & Chr(0) & Chr("&H7F") & Chr(0) & Chr(10) & Chr(nConfigVehicle) & Chr(1) & Chr(CType(cboControlMavlinkAction.SelectedItem, cValueDesc).Value)
        SendMavLink(aOutput)
        lblControlMavlinkStatus.Text = "Status: Goto Command " & cboControlMavlinkWPNumber.SelectedIndex & " Sent"
    End Sub

    Private Sub cmdControlMavlinkLoiterRadius_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdControlMavlinkLoiterRadius.Click, cmdControlMavlinkAltRTL.Click, cmdControlMavlinkWPRadius.Click
        Dim aOutput() As Byte
        Dim aTemp() As Byte
        Dim sValue As String
        Dim sVariable As String
        Dim nFoundIndex As Integer
        Dim nCount As Integer

        Select Case sender.name
            Case "cmdControlMavlinkLoiterRadius"
                sVariable = "LOITER_RADIUS"
                sValue = txtControlMavlinkLoiterRadius.Text
            Case "cmdControlMavlinkAltRTL"
                sVariable = "ALT_HOLD_RTL"
                sValue = txtControlMavlinkAltRTL.Text
            Case "cmdControlMavlinkWPRadius"
                sVariable = "WP_RADIUS"
                sValue = txtControlMavlinkWPRadius.Text
        End Select

        For nCount = 0 To UBound(aName)
            If aName(nCount) = sVariable Then
                nFoundIndex = nCount
                Exit For
            End If
        Next

        If sValue = "" Or IsNumeric(sValue) = False Then
            Exit Sub
        End If

        'FIX314
        aOutput = New Byte() {85, 21, 0, 127, 0, 23, nConfigVehicle, 1}
        aTemp = StringToByte(sVariable, 15, 0)
        aOutput = ConCatArray(aOutput, aTemp)
        aTemp = ConvertSingleToMavlinkByte(ConvertDistance(Convert.ToSingle(sValue) * aMultiplier(nFoundIndex), eDistanceUnits, e_DistanceFormat.e_DistanceFormat_Meters), True)
        aOutput = ConCatArray(aOutput, aTemp)
        SendMavLink(aOutput)
        lblControlMavlinkStatus.Text = "Status: Value Updated"
    End Sub

    Private Sub cboJoystickOutput_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboJoystickOutput.SelectedIndexChanged
        nJoystickOutput = cboJoystickOutput.SelectedIndex
        SaveRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " Output", nJoystickOutput)
    End Sub

    Private Sub tbarJoystickOutput1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbarJoystickOutput1.ValueChanged, tbarJoystickOutput2.ValueChanged, tbarJoystickOutput3.ValueChanged, tbarJoystickOutput4.ValueChanged
        Select Case sender.name
            Case "tbarJoystickOutput1"
                lblJoystickOutput1.Text = Convert.ToInt32(sender.value / 10)
            Case "tbarJoystickOutput2"
                lblJoystickOutput2.Text = Convert.ToInt32(sender.value / 10)
            Case "tbarJoystickOutput3"
                lblJoystickOutput3.Text = Convert.ToInt32(sender.value / 10)
            Case "tbarJoystickOutput4"
                lblJoystickOutput4.Text = Convert.ToInt32(sender.value / 10)
                'Case "tbarJoystickOutput5"
                '    lblJoystickOutput5.Text = Convert.ToInt32(sender.value / 10)
        End Select
    End Sub
End Class
