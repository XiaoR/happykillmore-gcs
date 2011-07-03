Module modSettings
    'Public Const g_Default_DAE_URL = "http://www.happykillmore.com/Software/HK_GCS/3D Models/"
    Public Const g_Default_DAE_URL = "http://127.0.0.1"

    Public nMapUpdateRate As Integer = 2
    Public sModelName As String = "EasyStar"
    Public sModelURL As String = ""
    Public nDaeHeadingOffset As Integer = 0
    Public nDaePitchRollOffset As Integer = 1
    Public n3DHeadingOffset As Integer = 0
    Public n3DPitchRollOffset As Integer = 1
    Public nMaxSpeed As Integer = 120
    Public bPitchReverse As Boolean = False
    Public bRollReverse As Boolean = False
    Public bYawReverse As Boolean = False
    Public bHeadingReverse As Boolean = False
    Public nThrottleChannel As Integer = 1
    Public eMapSelection As e_MapSelection = e_MapSelection.e_MapSelection_GoogleEarth

    Public sGoogleEarthKey As String

    Public bInstruments(0 To e_Instruments_Max) As Boolean
    Public b3DModelFailed As Boolean = False
    Public bSmoothInstruments As Boolean
    Public bSmooth3DModel As Boolean

    Public bFlightExtrude As Boolean = True
    Public sFlightColor As String
    Public nFlightWidth As Integer = 2

    Public nTinyWebPort As Integer

    Public bMissionExtrude As Boolean = True
    Public bMissionClampToGround As Boolean
    Public sMissionColor As String
    Public nMissionWidth As Integer = 1

    Public eDistanceUnits As e_DistanceFormat = e_DistanceFormat.e_DistanceFormat_Feet
    Public eSpeedUnits As e_SpeedFormat = e_SpeedFormat.e_SpeedFormat_MPH
    Public sSpeedUnits As String
    Public sDistanceUnits As String

    Public nMavlinkTelemetryRate As Integer

    Public nTrackingAngleLeft As Integer
    Public nTrackingAngleRight As Integer
    Public nTrackingAngleUp As Integer
    Public nTrackingAngleDown As Integer

    Public nTrackingServoLeft As Integer
    Public nTrackingServoRight As Integer
    Public nTrackingServoUp As Integer
    Public nTrackingServoDown As Integer

    Public nTrackingServoNumberPan As Integer
    Public nTrackingServoNumberTilt As Integer

    Public bBackLobeTracker As Boolean
    Public nTrackingOutputType As Integer

    Public nConfigDevice As e_ConfigDevice
    Public nConfigSubDevice As e_ConfigSubDevice
    Public nConfigVehicle As Integer
    Public sConfigFormatString As String = "0.000000"
    Public nConfigAltOffset As e_AltOffset

    Public sJoystickDevice As String
    Public nJoystickOutput As e_JoystickOutput

    Public nVarioInstrument As Byte

    Public bHeartbeat1 As Boolean
    Public bHeartbeat2 As Boolean
    Public bHeartbeat3 As Boolean
    Public bHeartbeat4 As Boolean
    Public bHeartbeat5 As Boolean
    Public bHeartbeat6 As Boolean

    Public bHeartbeatRun1 As Boolean = False
    Public bHeartbeatRun2 As Boolean = False
    Public bHeartbeatRun3 As Boolean = False
    Public bHeartbeatRun4 As Boolean = False
    Public bHeartbeatRun5 As Boolean = False
    Public bHeartbeatRun6 As Boolean = False

    Public bHeartbeatMAVlink As Boolean = False
    Public bHeartbeatMAVlinkJoystick As Boolean = False
    Public bHeartbeatMAVlinkJoystickForce As Boolean = False

    Public sHeartbeatName1 As String
    Public sHeartbeatName2 As String
    Public sHeartbeatName3 As String
    Public sHeartbeatName4 As String
    Public sHeartbeatName5 As String
    Public sHeartbeatName6 As String

    Public nHeartbeatDevice1 As Integer
    Public nHeartbeatDevice2 As Integer
    Public nHeartbeatDevice3 As Integer
    Public nHeartbeatDevice4 As Integer
    Public nHeartbeatDevice5 As Integer
    Public nHeartbeatDevice6 As Integer

    Public nHeartbeatRate1 As Integer
    Public nHeartbeatRate2 As Integer
    Public nHeartbeatRate3 As Integer
    Public nHeartbeatRate4 As Integer
    Public nHeartbeatRate5 As Integer
    Public nHeartbeatRate6 As Integer

    Public sHeartbeat1 As String
    Public sHeartbeat2 As String
    Public sHeartbeat3 As String
    Public sHeartbeat4 As String
    Public sHeartbeat5 As String
    Public sHeartbeat6 As String

    Public nHeartbeatMavlink As Integer

    Public eOldSpeedUnits As Integer
    Public eOldDistanceUnits As Integer

    Public Enum e_LatLongFormat
        e_LatLongFormat_DDMM_MMMM = 0
        e_LatLongFormat_DD_DDDDDD = 1
    End Enum
    Public Enum e_SpeedFormat
        e_SpeedFormat_Knots = 0
        e_SpeedFormat_KPH
        e_SpeedFormat_MPH
        e_SpeedFormat_MPerSec
    End Enum
    Public Enum e_DistanceFormat
        e_DistanceFormat_Feet = 0
        e_DistanceFormat_Meters
    End Enum
    Public Enum e_MapSelection
        e_MapSelection_None = 0
        e_MapSelection_GoogleEarth = 1
        e_MapSelection_GoogleMaps
    End Enum

    Public Enum e_ConfigDevice
        e_ConfigDevice_Generic = 0
        e_ConfigDevice_AttoPilot
        e_ConfigDevice_MAVlink
        e_ConfigDevice_Gluonpilot
        e_ConfigDevice_FY21AP
    End Enum

    Public Enum e_ConfigSubDevice
        e_ConfigSubDevice_APM = 0
        e_ConfigSubDevice_ACM
        e_ConfigSubDevice_UDB
    End Enum

    Public Sub LoadSettings()
        Dim nCount As Integer
        Dim eNewSpeedUnits As e_SpeedFormat
        Dim eNewDistanceUnits As e_DistanceFormat
        Dim oJoystickChannel As cJoystickChannel

        LoadLanguageFile()

        bIsAdmin = GetRegSetting(sRootRegistry & "\Settings", "Admin Mode", False)
        sLanguageFile = GetRegSetting(sRootRegistry & "\Settings", "Language File", "Default")

        sGoogleEarthKey = GetRegSetting(sRootRegistry & "\Settings", "Google Earth Key")

        sModelName = GetRegSetting(sRootRegistry & "\Settings", "3D Model", "EasyStar")
        nMaxSpeed = GetRegSetting(sRootRegistry & "\Settings", "Max Speed", "120")
        bPitchReverse = GetRegSetting(sRootRegistry & "\Settings", "Pitch Reverse", False)
        bRollReverse = GetRegSetting(sRootRegistry & "\Settings", "Roll Reverse", False)
        bYawReverse = GetRegSetting(sRootRegistry & "\Settings", "Yaw Reverse", False)
        bHeadingReverse = GetRegSetting(sRootRegistry & "\Settings", "Heading Reverse", False)
        nThrottleChannel = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Throttle Channel", "3"))
        eAltOffset = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Altitude Offset", "0"))
        nHomeOffset = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Home Offset", "0"))
        eMapSelection = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Map Source", "1"))

        n2WayRetries = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "2-way Reties", "3"))
        n2WayTimeout = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "2-way Timeout", "2"))

        nMapUpdateRate = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Map Update Hz", "2"))

        bFlightExtrude = GetRegSetting(sRootRegistry & "\Settings", "Flight Extrude", True)
        sFlightColor = GetRegSetting(sRootRegistry & "\Settings", "Flight Color", "8A00FFFF")
        nFlightWidth = GetRegSetting(sRootRegistry & "\Settings", "Flight Width", 2)

        nMavlinkTelemetryRate = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Mavlink Telemetry Rate", "4"))

        nVarioInstrument = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Vario Instrument", 0))

        bMissionExtrude = GetRegSetting(sRootRegistry & "\Settings", "Mission Extrude", True)
        sMissionColor = GetRegSetting(sRootRegistry & "\Settings", "Mission Color", "720000FF")
        nMissionWidth = GetRegSetting(sRootRegistry & "\Settings", "Mission Width", 1)
        bMissionClampToGround = GetRegSetting(sRootRegistry & "\Settings", "Mission Clamp To Ground", False)

        bGEBorders = GetRegSetting(sRootRegistry & "\Settings", "GE Borders", True)
        bGEBuildings = GetRegSetting(sRootRegistry & "\Settings", "GE Buildings", True)
        bGERoads = GetRegSetting(sRootRegistry & "\Settings", "GE Roads", True)
        bGETerrain = GetRegSetting(sRootRegistry & "\Settings", "GE Terrain", True)
        bGETrees = GetRegSetting(sRootRegistry & "\Settings", "GE Trees", True)

        eNewDistanceUnits = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Distance Units", "0"))
        If eNewDistanceUnits <> eOldDistanceUnits And nWPCount > -1 Then
            For nCount = 0 To nWPCount
                aWPAlt(nCount) = ConvertDistance(aWPAlt(nCount), eOldDistanceUnits, eNewDistanceUnits)
            Next
        End If
        eDistanceUnits = eNewDistanceUnits
        sDistanceUnits = getDistanceUnitsText
        frmMain.AltimeterInstrumentControl1.SetAlimeterParameters(nAltitude - nHomeAlt, sDistanceUnits)

        eNewSpeedUnits = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Speed Units", "2"))
        If eNewSpeedUnits <> eOldSpeedUnits And nWPCount > -1 Then
            For nCount = 0 To nWPCount
                aWPSpeed(nCount) = ConvertSpeed(aWPSpeed(nCount), eOldSpeedUnits, eNewSpeedUnits)
            Next
        End If
        eSpeedUnits = eNewSpeedUnits
        sSpeedUnits = GetSpeedUnitsText()

        'If bInstruments(e_Instruments.e_Instruments_Speed) = True Then
        frmMain.AirSpeedIndicatorInstrumentControl1.SetAirSpeedIndicatorParameters(nGroundSpeed, nMaxSpeed, GetResString(, "Speed"), sSpeedUnits)
        'End If
        'If bInstruments(e_Instruments.e_Instruments_Turn) = True Then
        frmMain.TurnCoordinatorInstrumentControl1.SetTurnCoordinatorParameters(nYaw, 0, UCase(GetResString(, "Turn_Coordinator")), GetResString(, "Left"), GetResString(, "Right"))
        'End If
        'If bInstruments(e_Instruments.e_Instruments_Vertical) = True Then
        frmMain.VerticalSpeedIndicatorInstrumentControl1.SetVerticalSpeedIndicatorParameters(nAltChange, LCase(GetResString(, "Vertical_Speed")), GetResString(, "Up"), GetResString(, "Down"), "100ft/min")
        'End If
        frmMain.BatteryIndicatorInstrumentControl1.SetBatteryIndicatorParameters(Replace(GetResString(, "Battery_Throttle"), "&&", "&"), nBattery, nBatteryMin, nBatteryMax, oBatteryColor, nAmperage, 0, nAmperageMax, oAmperageColor, nMAH, nMAHMin, nMAHMax, oMAHColor, nThrottle, oThrottleColor)

        For nCount = 0 To UBound(bInstruments)
            bInstruments(nCount) = GetRegSetting(sRootRegistry & "\Settings", "Show Instrument " & nCount, IIf(nCount <= 4 Or nCount = 7, True, False))
        Next

        nTinyWebPort = GetRegSetting(sRootRegistry & "\Settings", "TinyWeb Port", 8000)

        bSmoothInstruments = GetRegSetting(sRootRegistry & "\Settings", "Smooth Instruments", True)
        bSmooth3DModel = GetRegSetting(sRootRegistry & "\Settings", "Smooth 3D", False)

        nBatteryMax = ConvertPeriodToLocal(GetRegSetting(sRootRegistry & "\Settings", "Battery Max", "12.5"))
        nBatteryMin = ConvertPeriodToLocal(GetRegSetting(sRootRegistry & "\Settings", "Battery Min", 9))
        oBatteryColor = GetRegSetting(sRootRegistry & "\Settings", "Battery Color", e_InstrumentColor.e_InstrumentColor_Green)

        nAmperageMax = ConvertPeriodToLocal(GetRegSetting(sRootRegistry & "\Settings", "Amperage Max", 30))
        oAmperageColor = GetRegSetting(sRootRegistry & "\Settings", "Amperage Color", e_InstrumentColor.e_InstrumentColor_Red)

        nMAHMax = ConvertPeriodToLocal(GetRegSetting(sRootRegistry & "\Settings", "MAH Max", 2500))
        nMAHMin = ConvertPeriodToLocal(GetRegSetting(sRootRegistry & "\Settings", "MAH Min", 0))
        oMAHColor = GetRegSetting(sRootRegistry & "\Settings", "MAH Color", e_InstrumentColor.e_InstrumentColor_Cyan)

        oThrottleColor = GetRegSetting(sRootRegistry & "\Settings", "Throttle Color", e_InstrumentColor.e_InstrumentColor_Orange)

        sSpeechVoice = GetRegSetting(sRootRegistry & "\Settings\Speech", "Voice", "Microsoft Sam")
        bAnnounceWaypoints = GetRegSetting(sRootRegistry & "\Settings\Speech", "Waypoint Enabled", False)
        sSpeechWaypoint = GetRegSetting(sRootRegistry & "\Settings\Speech", "Waypoint", GetResString(, "Announce_Waypoints_Default"))
        bAnnounceModeChange = GetRegSetting(sRootRegistry & "\Settings\Speech", "Mode Change Enabled", False)
        sSpeechModeChange = GetRegSetting(sRootRegistry & "\Settings\Speech", "Mode Change", GetResString(, "Announce_ModeChange_Default"))
        bAnnounceRegularInterval = GetRegSetting(sRootRegistry & "\Settings\Speech", "Regular Interval Enabled", False)
        sSpeechRegularInterval = GetRegSetting(sRootRegistry & "\Settings\Speech", "Regular Interval", GetResString(, "Announce_Regular_Interval_Default"))
        nSpeechInterval = GetRegSetting(sRootRegistry & "\Settings\Speech", "Interval", 30)
        bAnnounceLinkWarning = GetRegSetting(sRootRegistry & "\Settings\Speech", "Warning Enabled", True)
        sSpeechWarning = GetRegSetting(sRootRegistry & "\Settings\Speech", "Warning", GetResString(, "Announce_Warning_Default"))
        bAnnounceLinkAlarm = GetRegSetting(sRootRegistry & "\Settings\Speech", "Alarm Enabled", True)
        sSpeechAlarm = GetRegSetting(sRootRegistry & "\Settings\Speech", "Alarm", GetResString(, "Announce_Alarm_Default"))
        bAnnouceAltitude = GetRegSetting(sRootRegistry & "\Settings\Speech", "Altitude Enabled", False)
        sSpeechAltitude = GetRegSetting(sRootRegistry & "\Settings\Speech", "Altitude", "Warning, your altitude is {alt} {distance_units}")
        nSpeechAltitudeMin = GetRegSetting(sRootRegistry & "\Settings\Speech", "Altitude Min", 100)

        bManuelMode = GetRegSetting(sRootRegistry & "\Settings\Speech", "Manuel Mode", False)

        nWarningTimeout = GetRegSetting(sRootRegistry & "\Settings", "Warning Timeout", 3)
        nAlarmTimeout = GetRegSetting(sRootRegistry & "\Settings", "Alarm Timeout", 10)

        bBackLobeTracker = GetRegSetting(sRootRegistry & "\Settings\Tracking", "Back Lobe", True)

        nTrackingOutputType = GetRegSetting(sRootRegistry & "\Settings\Tracking", "Output Type", 0)

        nConfigDevice = GetRegSetting(sRootRegistry & "\Settings", "Config Device", 0)
        nConfigVehicle = GetRegSetting(sRootRegistry & "\Settings", "Config Vehicle", 2)
        nConfigAltOffset = GetRegSetting(sRootRegistry & "\Settings", "Config Generic Alt Offset", 0)

        frmMain.txtMissionDefaultAlt.Text = ConvertDistance(GetRegSetting(sRootRegistry & "\Settings", "Default Mission Altitude", 200), e_DistanceFormat.e_DistanceFormat_Feet, eDistanceUnits)
        frmMain.txtMissionAttoDefaultSpeed.Text = ConvertSpeed(GetRegSetting(sRootRegistry & "\Settings", "Default Mission Atto Speed", 50), e_SpeedFormat.e_SpeedFormat_MPerSec, eSpeedUnits)

        frmMain.chkDataFileSaveBinary.Checked = GetRegSetting(sRootRegistry & "\Settings", "Save Data File Binary", False)
        frmMain.chkVarioenable.Checked = GetRegSetting(sRootRegistry & "\Settings", "Enable Vario", False)

        sJoystickDevice = GetRegSetting(sRootRegistry & "\Settings\Joystick", "Device", "")
        nJoystickOutput = GetRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " Output", 0)

        cJoystick = New cJoystickChannels
        For nCount = 1 To 8
            oJoystickChannel = New cJoystickChannel

            With oJoystickChannel
                .Axis = GetRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " " & nCount & " Input", nCount - 1)
                .Servo = GetRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " " & nCount & " Servo", nCount)
                .MinJoystickMovement = GetRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " " & nCount & " Min", -32767)
                .MaxJoystickMovement = GetRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " " & nCount & " Max", 32768)
                .LowerEndPoint = GetRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " " & nCount & " Lower", -100)
                .UpperEndPoint = GetRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " " & nCount & " Upper", 100)
                .Reversed = GetRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " " & nCount & " Reverse", False)
                .SubTrim = GetRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " " & nCount & " Sub Trim", 0)
            End With
            cJoystick.Add(oJoystickChannel)
        Next

        'nJoystickThrottle = GetRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " Throttle Input", 3)
        'nJoystickElevator = GetRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " Elevator Input", 0)
        'nJoystickAileron = GetRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " Aileron Input", 1)
        'nJoystickRudder = GetRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " Rudder Input", 4)
        'nJoystickMode = GetRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " Mode Input", 7)


        bHeartbeat1 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "1 Enabled", False)
        bHeartbeat2 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "2 Enabled", False)
        bHeartbeat3 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "3 Enabled", False)
        bHeartbeat4 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "4 Enabled", False)
        bHeartbeat5 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "5 Enabled", False)
        bHeartbeat6 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "6 Enabled", True)

        bHeartbeatMAVlink = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "MAVlink Enabled", True)

        sHeartbeatName1 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "1 Name", "")
        sHeartbeatName2 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "2 Name", "")
        sHeartbeatName3 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "3 Name", "")
        sHeartbeatName4 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "4 Name", "868 Xbee Reset")
        sHeartbeatName5 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "5 Name", "Mediatek Binary")
        sHeartbeatName6 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "6 Name", "NMEA Setup")

        nHeartbeatDevice1 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "1 Device", 0)
        nHeartbeatDevice2 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "2 Device", 0)
        nHeartbeatDevice3 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "3 Device", 0)
        nHeartbeatDevice4 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "4 Device", 0)
        nHeartbeatDevice5 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "5 Device", 1)
        nHeartbeatDevice6 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "6 Device", 1)

        nHeartbeatRate1 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "1 Rate", 1)
        nHeartbeatRate2 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "2 Rate", 1)
        nHeartbeatRate3 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "3 Rate", 1)
        nHeartbeatRate4 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "4 Rate", -60)
        nHeartbeatRate5 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "5 Rate", 1)
        nHeartbeatRate6 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "6 Rate", -999)

        sHeartbeat1 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "1 Output", "")
        sHeartbeat2 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "2 Output", "")
        sHeartbeat3 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "3 Output", "")
        sHeartbeat4 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "4 Output", "@@@<SLEEP 2>ATFR<CR><LF>")
        sHeartbeat5 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "5 Output", "$PMTK220,250*29<CR><LF>$PGCMD,16,0,0,0,0,0*6A<CR><LF>")
        sHeartbeat6 = GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "6 Output", "$PMTK330,220*2E<CR><LF>$PMTK313,1*2E<CR><LF>$PMTK301,2*2E<CR><LF>$PMTK220,200*2C<CR><LF>$PMTK314,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0*28<CR><LF>")

        nHeartbeatMavlink = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings\Heartbeat", "Mavlink Heartbeat Rate", "1"))

        If bSmooth3DModel = True Or bSmoothInstruments = True Then
            frmMain.tmrEase.Interval = 8
            frmMain.tmrEase.Enabled = True
        Else
            frmMain.tmrEase.Enabled = False
        End If

        If frmMain.bStartup = False Then
            'frmMain.SetMapMode()
            'If webDocument Is Nothing Then
            If eMapSelection = e_MapSelection.e_MapSelection_GoogleEarth Then
                'frmMain.SetupWebBroswer()
            End If
            'End If
        End If

        If frmMain.tabInstrumentView.SelectedIndex = 4 Then
            frmMain.LoadMissionGrid(frmMain.dgMission.SelectedRows(0).Index)
            frmMain.UpdateMissionGE(frmMain.dgMission.SelectedRows(0).Index)
        End If

    End Sub

    Public Sub SaveSettings()
        Dim nCount As Integer

        SaveRegSetting(sRootRegistry & "\Settings", "Google Earth Key", sGoogleEarthKey)

        SaveRegSetting(sRootRegistry & "\Settings", "Language File", sLanguageFile)

        SaveRegSetting(sRootRegistry & "\Settings", "TinyWeb Port", nTinyWebPort)

        SaveRegSetting(sRootRegistry & "\Settings", "3D Model", sModelName)
        SaveRegSetting(sRootRegistry & "\Settings", "Max Speed", nMaxSpeed)
        SaveRegSetting(sRootRegistry & "\Settings", "Pitch Reverse", bPitchReverse)
        SaveRegSetting(sRootRegistry & "\Settings", "Roll Reverse", bRollReverse)
        SaveRegSetting(sRootRegistry & "\Settings", "Yaw Reverse", bYawReverse)
        SaveRegSetting(sRootRegistry & "\Settings", "Heading Reverse", bHeadingReverse)
        SaveRegSetting(sRootRegistry & "\Settings", "Throttle Channel", nThrottleChannel)
        SaveRegSetting(sRootRegistry & "\Settings", "Altitude Offset", eAltOffset)
        SaveRegSetting(sRootRegistry & "\Settings", "Home Offset", nHomeOffset)

        SaveRegSetting(sRootRegistry & "\Settings", "Config Device", nConfigDevice)
        SaveRegSetting(sRootRegistry & "\Settings", "Config Vehicle", nConfigVehicle)
        SaveRegSetting(sRootRegistry & "\Settings", "Config Generic Alt Offset", nConfigAltOffset)

        SaveRegSetting(sRootRegistry & "\Settings", "2-way Reties", n2WayRetries)
        SaveRegSetting(sRootRegistry & "\Settings", "2-way Timeout", n2WayTimeout)

        SaveRegSetting(sRootRegistry & "\Settings", "Flight Extrude", bFlightExtrude)
        SaveRegSetting(sRootRegistry & "\Settings", "Flight Color", sFlightColor)
        SaveRegSetting(sRootRegistry & "\Settings", "Flight Width", nFlightWidth)

        SaveRegSetting(sRootRegistry & "\Settings", "Mission Extrude", bMissionExtrude)
        SaveRegSetting(sRootRegistry & "\Settings", "Mission Color", sMissionColor)
        SaveRegSetting(sRootRegistry & "\Settings", "Mission Width", nMissionWidth)
        SaveRegSetting(sRootRegistry & "\Settings", "Mission Clamp To Ground", bMissionClampToGround)

        SaveRegSetting(sRootRegistry & "\Settings", "Distance Units", eDistanceUnits)
        SaveRegSetting(sRootRegistry & "\Settings", "Speed Units", eSpeedUnits)
        SaveRegSetting(sRootRegistry & "\Settings", "Map Update Hz", nMapUpdateRate)
        SaveRegSetting(sRootRegistry & "\Settings", "Map Source", eMapSelection)

        SaveRegSetting(sRootRegistry & "\Settings", "GE Borders", bGEBorders)
        SaveRegSetting(sRootRegistry & "\Settings", "GE Buildings", bGEBuildings)
        SaveRegSetting(sRootRegistry & "\Settings", "GE Roads", bGERoads)
        SaveRegSetting(sRootRegistry & "\Settings", "GE Terrain", bGETerrain)
        SaveRegSetting(sRootRegistry & "\Settings", "GE Trees", bGETrees)

        For nCount = 0 To UBound(bInstruments)
            SaveRegSetting(sRootRegistry & "\Settings", "Show Instrument " & nCount, bInstruments(nCount))
        Next
        SaveRegSetting(sRootRegistry & "\Settings", "Smooth Instruments", bSmoothInstruments)
        SaveRegSetting(sRootRegistry & "\Settings", "Smooth 3D", bSmooth3DModel)

        SaveRegSetting(sRootRegistry & "\Settings", "Battery Max", nBatteryMax)
        SaveRegSetting(sRootRegistry & "\Settings", "Battery Min", nBatteryMin)
        SaveRegSetting(sRootRegistry & "\Settings", "Battery Color", oBatteryColor)

        SaveRegSetting(sRootRegistry & "\Settings", "Amperage Max", nAmperageMax)
        SaveRegSetting(sRootRegistry & "\Settings", "Amperage Color", oAmperageColor)

        SaveRegSetting(sRootRegistry & "\Settings", "MAH Max", nMAHMax)
        SaveRegSetting(sRootRegistry & "\Settings", "MAH Min", nMAHMin)
        SaveRegSetting(sRootRegistry & "\Settings", "MAH Color", oMAHColor)

        SaveRegSetting(sRootRegistry & "\Settings", "Throttle Color", oThrottleColor)

        SaveRegSetting(sRootRegistry & "\Settings\Speech", "Voice", sSpeechVoice)
        SaveRegSetting(sRootRegistry & "\Settings\Speech", "Waypoint Enabled", bAnnounceWaypoints)
        SaveRegSetting(sRootRegistry & "\Settings\Speech", "Waypoint", sSpeechWaypoint)
        SaveRegSetting(sRootRegistry & "\Settings\Speech", "Mode Change Enabled", bAnnounceModeChange)
        SaveRegSetting(sRootRegistry & "\Settings\Speech", "Mode Change", sSpeechModeChange)
        SaveRegSetting(sRootRegistry & "\Settings\Speech", "Regular Interval Enabled", bAnnounceRegularInterval)
        SaveRegSetting(sRootRegistry & "\Settings\Speech", "Regular Interval", sSpeechRegularInterval)
        SaveRegSetting(sRootRegistry & "\Settings\Speech", "Interval", nSpeechInterval)
        SaveRegSetting(sRootRegistry & "\Settings\Speech", "Altitude Enabled", bAnnounceLinkAlarm)
        SaveRegSetting(sRootRegistry & "\Settings\Speech", "Altitude", sSpeechAltitude)
        SaveRegSetting(sRootRegistry & "\Settings\Speech", "Altitude Min", nSpeechAltitudeMin)

        SaveRegSetting(sRootRegistry & "\Settings\Speech", "Manuel Mode", bManuelMode)

        SaveRegSetting(sRootRegistry & "\Settings\Speech", "Warning Enabled", bAnnounceLinkWarning)
        SaveRegSetting(sRootRegistry & "\Settings\Speech", "Warning", sSpeechWarning)
        SaveRegSetting(sRootRegistry & "\Settings\Speech", "Alarm Enabled", bAnnounceLinkAlarm)
        SaveRegSetting(sRootRegistry & "\Settings\Speech", "Alarm", sSpeechAlarm)

        SaveRegSetting(sRootRegistry & "\Settings", "Warning Timeout", nWarningTimeout)
        SaveRegSetting(sRootRegistry & "\Settings", "Alarm Timeout", nAlarmTimeout)

        SaveRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Angle Left", nTrackingAngleLeft)
        SaveRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Angle Right", nTrackingAngleRight)
        SaveRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Angle Up", nTrackingAngleUp)
        SaveRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Angle Down", nTrackingAngleDown)

        SaveRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Servo Left", nTrackingServoLeft)
        SaveRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Servo Right", nTrackingServoRight)
        SaveRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Servo Up", nTrackingServoUp)
        SaveRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Servo Down", nTrackingServoDown)

        If nTrackingOutputType >= 4 And nTrackingOutputType <= 6 Then
            SaveRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Servo Number Pan", nTrackingServoNumberPan)
            SaveRegSetting(sRootRegistry & "\Settings\Tracking\" & nTrackingOutputType, "Servo Number Tilt", nTrackingServoNumberTilt)
        End If

        SaveRegSetting(sRootRegistry & "\Settings\Tracking", "Back Lobe", bBackLobeTracker)

        SaveRegSetting(sRootRegistry & "\Settings\Joystick", "Device", sJoystickDevice)

        For nCount = 1 To 8
            With cJoystick(nCount)
                SaveRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " " & nCount & " Input", .Axis)
                SaveRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " " & nCount & " Servo", .Servo)
                SaveRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " " & nCount & " Min", .MinJoystickMovement)
                SaveRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " " & nCount & " Max", .MaxJoystickMovement)
                SaveRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " " & nCount & " Lower", .LowerEndPoint)
                SaveRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " " & nCount & " Upper", .UpperEndPoint)
                SaveRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " " & nCount & " Reverse", .Reversed)
                SaveRegSetting(sRootRegistry & "\Settings\Joystick", sJoystickDevice & " " & nCount & " Sub Trim", .SubTrim)
            End With
        Next

        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "1 Enabled", bHeartbeat1)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "2 Enabled", bHeartbeat2)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "3 Enabled", bHeartbeat3)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "4 Enabled", bHeartbeat4)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "5 Enabled", bHeartbeat5)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "6 Enabled", bHeartbeat6)

        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "MAVlink Enabled", bHeartbeatMAVlink)

        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "1 Name", sHeartbeatName1)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "2 Name", sHeartbeatName2)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "3 Name", sHeartbeatName3)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "4 Name", sHeartbeatName4)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "5 Name", sHeartbeatName5)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "6 Name", sHeartbeatName6)

        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "1 Device", nHeartbeatDevice1)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "2 Device", nHeartbeatDevice2)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "3 Device", nHeartbeatDevice3)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "4 Device", nHeartbeatDevice4)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "5 Device", nHeartbeatDevice5)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "6 Device", nHeartbeatDevice6)

        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "1 Rate", nHeartbeatRate1)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "2 Rate", nHeartbeatRate2)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "3 Rate", nHeartbeatRate3)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "4 Rate", nHeartbeatRate4)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "5 Rate", nHeartbeatRate5)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "6 Rate", nHeartbeatRate6)

        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "1 Output", sHeartbeat1)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "2 Output", sHeartbeat2)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "3 Output", sHeartbeat3)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "4 Output", sHeartbeat4)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "5 Output", sHeartbeat5)
        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "6 Output", sHeartbeat6)

        SaveRegSetting(sRootRegistry & "\Settings\Heartbeat", "Mavlink Heartbeat Rate", nHeartbeatMavlink)


        If nSpeechInterval < 10 Then
            nSpeechInterval = 10
        End If

        frmMain.ResetForm()
        LoadSettings()
        frmMain.ResizeForm()
    End Sub

    Public Function GetColor(ByVal inputColor As System.Drawing.Color, Optional ByVal opacity As Integer = 255, Optional ByVal withOpacity As Boolean = True) As String
        If withOpacity = True Then
            GetColor = Hex(opacity).PadLeft(2, "0")
        Else
            GetColor = ""
        End If
        GetColor = GetColor & Hex(inputColor.B).PadLeft(2, "0")
        GetColor = GetColor & Hex(inputColor.G).PadLeft(2, "0")
        GetColor = GetColor & Hex(inputColor.R).PadLeft(2, "0")
    End Function
End Module
