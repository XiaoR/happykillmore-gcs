Module modSettings
    Public nMapUpdateRate As Integer = 2
    Public sModelName As String = "EasyStar"
    Public nMaxSpeed As Integer = 120
    Public bPitchReverse As Boolean = False
    Public bRollReverse As Boolean = False
    Public bYawReverse As Boolean = False
    Public bHeadingReverse As Boolean = False
    Public nThrottleChannel As Integer = 1

    Public bInstruments(0 To e_Instruments_Max) As Boolean
    Public b3DModelFailed As Boolean = False

    Public bFlightExtrude As Boolean = True
    Public sFlightColor As String
    Public nFlightWidth As Integer = 2

    Public bMissionExtrude As Boolean = True
    Public sMissionColor As String
    Public nMissionWidth As Integer = 1

    Public eDistanceUnits As e_DistanceFormat = e_DistanceFormat.e_DistanceFormat_Feet
    Public eSpeedUnits As e_SpeedFormat = e_SpeedFormat.e_SpeedFormat_MPH
    Public sSpeedUnits As String
    Public sDistanceUnits As String

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
        e_MapSelection_GoogleEarth = 0
        e_MapSelection_GoogleMaps
    End Enum

    Public Sub LoadSettings()
        Dim nCount As Integer

        sLanguageFile = GetRegSetting(sRootRegistry & "\Settings", "Language File", "Default")

        sModelName = GetRegSetting(sRootRegistry & "\Settings", "3D Model", "EasyStar")
        nMaxSpeed = GetRegSetting(sRootRegistry & "\Settings", "Max Speed", "120")
        bPitchReverse = GetRegSetting(sRootRegistry & "\Settings", "Pitch Reverse", False)
        bRollReverse = GetRegSetting(sRootRegistry & "\Settings", "Roll Reverse", False)
        bYawReverse = GetRegSetting(sRootRegistry & "\Settings", "Yaw Reverse", False)
        bHeadingReverse = GetRegSetting(sRootRegistry & "\Settings", "Heading Reverse", False)
        nThrottleChannel = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Throttle Channel", "1"))

        nMapUpdateRate = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Map Update Hz", "2"))

        bFlightExtrude = GetRegSetting(sRootRegistry & "\Settings", "Flight Extrude", True)
        sFlightColor = GetRegSetting(sRootRegistry & "\Settings", "Flight Color", "8A00FFFF")
        nFlightWidth = GetRegSetting(sRootRegistry & "\Settings", "Flight Width", 2)

        bMissionExtrude = GetRegSetting(sRootRegistry & "\Settings", "Mission Extrude", True)
        sMissionColor = GetRegSetting(sRootRegistry & "\Settings", "Mission Color", "720000FF")
        nMissionWidth = GetRegSetting(sRootRegistry & "\Settings", "Mission Width", 1)

        bGEBorders = GetRegSetting(sRootRegistry & "\Settings", "GE Borders", True)
        bGEBuildings = GetRegSetting(sRootRegistry & "\Settings", "GE Buildings", True)
        bGERoads = GetRegSetting(sRootRegistry & "\Settings", "GE Roads", True)
        bGETerrain = GetRegSetting(sRootRegistry & "\Settings", "GE Terrain", True)
        bGETrees = GetRegSetting(sRootRegistry & "\Settings", "GE Trees", True)

        eDistanceUnits = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Distance Units", "0"))
        Select Case eDistanceUnits
            Case e_DistanceFormat.e_DistanceFormat_Feet
                sDistanceUnits = GetResString(, "Feet")
            Case e_DistanceFormat.e_DistanceFormat_Meters
                sDistanceUnits = GetResString(, "Meters")
        End Select
        frmMain.AltimeterInstrumentControl1.SetAlimeterParameters(nAltitude, sDistanceUnits)

        eSpeedUnits = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Speed Units", "2"))
        Select Case eSpeedUnits
            Case e_SpeedFormat.e_SpeedFormat_Knots
                sSpeedUnits = GetResString(, "Knots")
            Case e_SpeedFormat.e_SpeedFormat_KPH
                sSpeedUnits = GetResString(, "KPH")
            Case e_SpeedFormat.e_SpeedFormat_MPerSec
                sSpeedUnits = GetResString(, "m_s")
            Case e_SpeedFormat.e_SpeedFormat_MPH
                sSpeedUnits = GetResString(, "MPH")
        End Select

        'If bInstruments(e_Instruments.e_Instruments_Speed) = True Then
        frmMain.AirSpeedIndicatorInstrumentControl1.SetAirSpeedIndicatorParameters(nGroundSpeed, nMaxSpeed, GetResString(, "Speed"), sSpeedUnits)
        'End If
        'If bInstruments(e_Instruments.e_Instruments_Turn) = True Then
        frmMain.TurnCoordinatorInstrumentControl1.SetTurnCoordinatorParameters(GetRoll(-nRoll), 0, UCase(GetResString(, "Turn_Coordinator")), GetResString(, "Left"), GetResString(, "Right"))
        'End If
        'If bInstruments(e_Instruments.e_Instruments_Vertical) = True Then
        frmMain.VerticalSpeedIndicatorInstrumentControl1.SetVerticalSpeedIndicatorParameters(nAltChange, LCase(GetResString(, "Vertical_Speed")), GetResString(, "Up"), GetResString(, "Down"), "100ft/min")
        'End If
        frmMain.BatteryIndicatorInstrumentControl1.SetBatteryIndicatorParameters(Replace(GetResString(, "Battery_Throttle"), "&&", "&"), nBattery, nBatteryMin, nBatteryMax, oBatteryColor, nAmperage, 0, nAmperageMax, oAmperageColor, nMAH, nMAHMin, nMAHMax, oMAHColor, nThrottle, oThrottleColor)


        For nCount = 0 To UBound(bInstruments)
            bInstruments(nCount) = GetRegSetting(sRootRegistry & "\Settings", "Show Instrument " & nCount, IIf(nCount <= 5, True, False))
        Next

        nBatteryMax = ConvertPeriodToLocal(GetRegSetting(sRootRegistry & "\Settings", "Battery Max", "12.5"))
        nBatteryMin = ConvertPeriodToLocal(GetRegSetting(sRootRegistry & "\Settings", "Battery Min", 9))
        oBatteryColor = GetRegSetting(sRootRegistry & "\Settings", "Battery Color", e_InstrumentColor.e_InstrumentColor_Green)

        nAmperageMax = ConvertPeriodToLocal(GetRegSetting(sRootRegistry & "\Settings", "Amperage Max", 30))
        oAmperageColor = GetRegSetting(sRootRegistry & "\Settings", "Amperage Color", e_InstrumentColor.e_InstrumentColor_Red)

        nMAHMax = ConvertPeriodToLocal(GetRegSetting(sRootRegistry & "\Settings", "MAH Max", 2500))
        nMAHMin = ConvertPeriodToLocal(GetRegSetting(sRootRegistry & "\Settings", "MAH Min", 0))
        oMAHColor = GetRegSetting(sRootRegistry & "\Settings", "MAH Color", e_InstrumentColor.e_InstrumentColor_Cyan)

        oThrottleColor = GetRegSetting(sRootRegistry & "\Settings", "Throttle Color", e_InstrumentColor.e_InstrumentColor_Orange)

        sSpeechVoice = GetRegSetting(sRootRegistry & "\Settings", "Speech Voice", "Microsoft Sam")
        bAnnounceWaypoints = GetRegSetting(sRootRegistry & "\Settings", "Speech Waypoint Enabled", False)
        sSpeechWaypoint = GetRegSetting(sRootRegistry & "\Settings", "Speech Waypoint", GetResString(, "Announce_Waypoints_Default"))
        bAnnounceModeChange = GetRegSetting(sRootRegistry & "\Settings", "Speech Mode Change Enabled", False)
        sSpeechModeChange = GetRegSetting(sRootRegistry & "\Settings", "Speech Mode Change", GetResString(, "Announce_ModeChange_Default"))

    End Sub

    Public Sub SaveSettings()
        Dim nCount As Integer

        SaveRegSetting(sRootRegistry & "\Settings", "Language File", sLanguageFile)

        SaveRegSetting(sRootRegistry & "\Settings", "3D Model", sModelName)
        SaveRegSetting(sRootRegistry & "\Settings", "Max Speed", nMaxSpeed)
        SaveRegSetting(sRootRegistry & "\Settings", "Pitch Reverse", bPitchReverse)
        SaveRegSetting(sRootRegistry & "\Settings", "Roll Reverse", bRollReverse)
        SaveRegSetting(sRootRegistry & "\Settings", "Yaw Reverse", bYawReverse)
        SaveRegSetting(sRootRegistry & "\Settings", "Heading Reverse", bHeadingReverse)
        SaveRegSetting(sRootRegistry & "\Settings", "Throttle Channel", nThrottleChannel)

        SaveRegSetting(sRootRegistry & "\Settings", "Flight Extrude", bFlightExtrude)
        SaveRegSetting(sRootRegistry & "\Settings", "Flight Color", sFlightColor)
        SaveRegSetting(sRootRegistry & "\Settings", "Flight Width", nFlightWidth)

        SaveRegSetting(sRootRegistry & "\Settings", "Mission Extrude", bMissionExtrude)
        SaveRegSetting(sRootRegistry & "\Settings", "Mission Color", sMissionColor)
        SaveRegSetting(sRootRegistry & "\Settings", "Mission Width", nMissionWidth)

        SaveRegSetting(sRootRegistry & "\Settings", "Distance Units", eDistanceUnits)
        SaveRegSetting(sRootRegistry & "\Settings", "Speed Units", eSpeedUnits)
        SaveRegSetting(sRootRegistry & "\Settings", "Map Update Hz", nMapUpdateRate)

        SaveRegSetting(sRootRegistry & "\Settings", "GE Borders", bGEBorders)
        SaveRegSetting(sRootRegistry & "\Settings", "GE Buildings", bGEBuildings)
        SaveRegSetting(sRootRegistry & "\Settings", "GE Roads", bGERoads)
        SaveRegSetting(sRootRegistry & "\Settings", "GE Terrain", bGETerrain)
        SaveRegSetting(sRootRegistry & "\Settings", "GE Trees", bGETrees)

        For nCount = 0 To UBound(bInstruments)
            SaveRegSetting(sRootRegistry & "\Settings", "Show Instrument " & nCount, bInstruments(nCount))
        Next

        SaveRegSetting(sRootRegistry & "\Settings", "Battery Max", nBatteryMax)
        SaveRegSetting(sRootRegistry & "\Settings", "Battery Min", nBatteryMin)
        SaveRegSetting(sRootRegistry & "\Settings", "Battery Color", oBatteryColor)

        SaveRegSetting(sRootRegistry & "\Settings", "Amperage Max", nAmperageMax)
        SaveRegSetting(sRootRegistry & "\Settings", "Amperage Color", oAmperageColor)

        SaveRegSetting(sRootRegistry & "\Settings", "MAH Max", nMAHMax)
        SaveRegSetting(sRootRegistry & "\Settings", "MAH Min", nMAHMin)
        SaveRegSetting(sRootRegistry & "\Settings", "MAH Color", oMAHColor)

        SaveRegSetting(sRootRegistry & "\Settings", "Throttle Color", oThrottleColor)

        SaveRegSetting(sRootRegistry & "\Settings", "Speech Voice", sSpeechVoice)
        SaveRegSetting(sRootRegistry & "\Settings", "Speech Waypoint Enabled", bAnnounceWaypoints)
        SaveRegSetting(sRootRegistry & "\Settings", "Speech Waypoint", sSpeechWaypoint)
        SaveRegSetting(sRootRegistry & "\Settings", "Speech Mode Change Enabled", bAnnounceModeChange)
        SaveRegSetting(sRootRegistry & "\Settings", "Speech Mode Change", sSpeechModeChange)

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
