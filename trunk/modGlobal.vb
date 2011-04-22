Imports System.IO
Imports DirectShowLib
Imports System.Globalization
Imports System.Resources
Imports System.Net
Imports System.Net.Sockets

Module modGlobal
    Public theDevice1 As IBaseFilter
    Public theDevice2 As IBaseFilter
    Public Const pi As Double = 3.14159265
    Public sRootRegistry As String = "SOFTWARE\HK_GCS"

    Public objTabViewMapView As TabPage
    Public webDocument As Object

    Public Const e_Instruments_Max = 7
    Public bPlaneFirstFound As Boolean = False

    Public Enum e_MavlinkHandshake
        e_MavlinkHandshake_None = 0
        e_MavlinkHandshake_TotalCountRequest
        e_MavlinkHandshake_TotalCountRespond
        e_MavlinkHandshake_WaypointRequest
        e_MavlinkHandshake_WaypointRespond
        e_MavlinkHandshake_DoneRequesting
        e_MavlinkHandshake_TotalCountSet
        e_MavlinkHandshake_TotalCountSetRespond
        e_MavlinkHandshake_WaypointSet
        e_MavlinkHandshake_WaypointSetRespond
    End Enum
    Public Enum e_NewDevice_BootState
        e_NewDevice_BootState_None = 0
        e_NewDevice_BootState_RequestingParameters
        e_NewDevice_BootState_ParametersComplete
        e_NewDevice_BootState_RequestingMission
        e_NewDevice_BootState_MissionComplete
        e_NewDevice_BootState_StartComplete
    End Enum
    Public Enum e_DeviceTypes
        e_DeviceTypes_None = 0
        e_DeviceTypes_NMEA
        e_DeviceTypes_uBlox
        e_DeviceTypes_SiRF
        e_DeviceTypes_Mediatek
        e_DeviceTypes_Mediatek16
        e_DeviceTypes_ArduIMU
        e_DeviceTypes_ArduPilotLegacy
        e_DeviceTypes_ArduPilotMega
        e_DeviceTypes_UDB
        e_DeviceTypes_AttoPilot
        e_DeviceTypes_FY21AP
        e_DeviceTypes_GluonPilot
        e_DeviceTypes_Paparazzi
        e_DeviceTypes_MavLink
    End Enum
    Public Enum e_JoystickCenter
        e_JoystickCenter_None = 0
        e_JoystickCenter_Slow
        e_JoystickCenter_Fast
    End Enum
    Public Enum e_JoystickOutput
        e_JoystickOutput_None = 0
        e_JoystickOutput_Atto
        e_JoystickOutput_UDB
        e_JoystickOutput_Millswood
        e_JoystickOutput_APM
        'e_JoystickOutput_Pololu
    End Enum
    Public Enum e_Instruments
        e_Instruments_None = -1
        e_Instruments_3DModel = 0
        e_Instruments_Attitude
        e_Instruments_Speed
        e_Instruments_Altimeter
        e_Instruments_Heading
        e_Instruments_Vertical
        e_Instruments_Turn
        e_Instruments_Battery
    End Enum
    Public Enum e_PlayerState
        e_PlayerState_None = 0
        e_PlayerState_RecordReady
        e_PlayerState_Loaded
        e_PlayerState_Play
        e_PlayerState_Pause
        e_PlayerState_Record
        e_PlayerState_FastForward
        e_PlayerState_Reverse
        e_PlayerState_StepForward
        e_PlayerState_StepBack
    End Enum

    Public Enum e_ChannelType
        e_ChannelType_Throttle = 0
        e_ChannelType_Elevator
        e_ChannelType_Aileron
        e_ChannelType_Rudder
        e_ChannelType_Channel5
        e_ChannelType_Channel6
        e_ChannelType_Channel7
        e_ChannelType_Channel8
    End Enum

    Public Enum e_MissionFileType
        e_MissionFileType_None = 0
        e_MissionFileType_GCS
        e_MissionFileType_UDB
        e_MissionFileType_FY21APII
        e_MissionFileType_Atto
    End Enum
    Public Enum e_InstrumentLayout
        e_InstrumentLayout_Horizontal = 0
        e_InstrumentLayout_Square
        e_InstrumentLayout_Vertical
        e_InstrumentLayout_SingleColumn
    End Enum

    'Public Enum e_DeviceType
    '    e_DeviceType_Generic = 0
    '    e_DeviceType_AttoPilot
    '    e_DeviceType_APM
    'End Enum

    Public Const e_InstrumentColor_Max As Integer = 6
    Public Enum e_InstrumentColor
        e_InstrumentColor_Blue = 0
        e_InstrumentColor_Cyan
        e_InstrumentColor_Green
        e_InstrumentColor_Orange
        e_InstrumentColor_Purple
        e_InstrumentColor_Red
        e_InstrumentColor_Yellow
    End Enum

    Public Enum e_AltOffset
        e_AltOffset_SeaLevel = 0
        e_AltOffset_HomeALt = 1
    End Enum

    Public oActiveDevices As cActiveDevices

    Public resourceMgr As ResourceManager
    Public jst As JoystickInterface.Joystick = Nothing
    Public dLastJoystick As Long
    Public dLastAttoAileron As Long
    Public dLastAttoElevator As Long
    Public dLastAttoThrottle As Long
    Public nMaxPitchAngle As Integer = -1
    Public nMaxRollAngle As Integer = -1
    Public nMinThrottle As Integer = -1
    Public nMAxThrottle As Integer = -1

    Public bManuelMode As Boolean = False
    Public dManuelMode As Long

    Public Delegate Sub MyDelegate()
    'Public Delegate Sub NewDataArrived()
    'Public dataDelegate 'As New NewDataArrived(AddressOf frmMain.NewDataReceived)

    Public bIsAdmin As Boolean
    Public bShutdown As Boolean = False
    Public sBuffer As String
    'Public aBuffer() As Byte
    Public bConnected As Boolean = False
    Public bConnectedTracking As Boolean = False

    Public bWaitingAttoUpdate As Boolean = False
    Public bWaitingMavlinkUpdate As Boolean = False
    Public bWaitingMavlinkWrite As Boolean = False
    Public bWaitingGluonUpdate As Boolean = False
    Public bWaitingGluonWrite As Boolean = False

    Public nWPCount As Integer = -1
    Public aWPLat(0) As String
    Public aWPLon(0) As String
    Public aWPAlt(0) As String
    Public aWPTrigger(0) As String
    Public aWPSpeed(0) As String
    'Public aWPCommand(0) As String

    Public aCommandName() As String
    Public aCommandValue() As Integer
    Public aModeName() As String
    Public aModeValue() As Integer
    Public aCommandArg1() As String
    Public aCommandArg2() As String
    Public aCommandArg3() As String
    Public aCommandArg4() As String
    Public aCommandArg5() As String
    Public aCommandArg6() As String
    Public aCommandArg7() As String

    Public aCommandUnit1() As String
    Public aCommandUnit2() As String
    Public aCommandUnit3() As String
    Public aCommandUnit4() As String
    Public aCommandUnit5() As String
    Public aCommandUnit6() As String
    Public aCommandUnit7() As String

    Public aCommandMult1() As Single
    Public aCommandMult2() As Single
    Public aCommandMult3() As Single
    Public aCommandMult4() As Single
    Public aCommandMult5() As Single
    Public aCommandMult6() As Single
    Public aCommandMult7() As Single

    Public aCommandFormat1() As String
    Public aCommandFormat2() As String
    Public aCommandFormat3() As String
    Public aCommandFormat4() As String
    Public aCommandFormat5() As String
    Public aCommandFormat6() As String
    Public aCommandFormat7() As String

    Public nHomeAlt As Single
    Public nHomeAltIndicator As Single

    Public bGoogleLoaded As Boolean = False
    Public bGoogleFailed As Boolean = False

    Public bNewDevice As Boolean = True
    Public bNewConnect As Boolean = True

    Public nPitch As Single
    Public nRoll As Single
    Public nYaw As Single

    Public eAltOffset As e_AltOffset
    Public nHomeOffset As Integer
    Public nSocketPortNumber As Long
    Public sSocketIPaddress As String
    Public nSocketType As Integer
    Public bHeadLock As Boolean = True

    Public nYawOffset As Single
    Public sLanguageFile As String
    Public sLoadedLanguageFile As String
    Public oCulture As CultureInfo

    Public sHomeIcon As String

    Public sSpeechVoice As String
    Public bAnnounceWaypoints As Boolean
    Public sSpeechWaypoint As String
    Public bAnnounceModeChange As Boolean
    Public sSpeechModeChange As String
    Public bAnnounceRegularInterval As Boolean
    Public sSpeechRegularInterval As String
    Public nSpeechInterval As Long
    Public bAnnounceLinkWarning As Boolean
    Public sSpeechWarning As String
    Public bAnnounceLinkAlarm As Boolean
    Public sSpeechAlarm As String
    Public sSpeechAltitude As String
    Public bAnnouceAltitude As Boolean
    Public nSpeechAltitudeMin As Single

    Public n2WayRetries As Integer
    Public n2WayTimeout As Integer

    Public nNewWaypoint As Integer = 0
    Public nWaypoint As Integer = 0
    Public nWaypointAlt As Single
    Public nDistance As Single

    Public nAlarmTimeout As Integer
    Public nWarningTimeout As Integer

    Public aLastAtlitudes(0 To 9) As Single
    Public nLastAltIndex As Integer

    Public bGEBorders As Boolean
    Public bGEBuildings As Boolean
    Public bGERoads As Boolean
    Public bGETerrain As Boolean
    Public bGETrees As Boolean

    Public dGPSDate As Date
    Public dGPSTime As Date
    Public bUTCTime As Boolean
    Public nTOWDayOffset As Integer = 0

    Public nBattery As Single
    Public nBatteryMax As Single = 12.5
    Public nBatteryMin As Single = 9
    Public oBatteryColor As e_InstrumentColor

    Public nAmperage As Single
    Public nAmperageMax As Single = 30
    Public oAmperageColor As e_InstrumentColor

    Public nMAH As Long
    Public nMAHMax As Long = 2500
    Public nMAHMin As Long = 500
    Public oMAHColor As e_InstrumentColor
    Public oThrottleColor As e_InstrumentColor

    Public nAltChange As Single
    Public nThrottle As Single

    Public sLastSpeechMode As String
    Public nLastSpeechWaypoint As Integer = -1

    Public sCenterLat As String
    Public sCenterLong As String
    Public sCenterAlt As String

    Public bShowBinary As Boolean = True
    Public nLatitude As String
    Public nLongitude As String
    Public nAltitude As Single
    Public nBaro As Single
    Public nGroundSpeed As Single
    Public nAirSpeed As Single
    Public nHeading As Single
    Public nSats As Integer
    Public sMode As String
    Public sModeNumber As String
    Public nFix As Integer
    Public nHDOP As Single
    Public nWaypointIndex As Integer
    Public nWaypointTotal As Integer
    Public nServoInput(0 To 7) As Integer
    Public nServoOutput(0 To 7) As Integer
    Public nSensor(0 To 13) As Long

    Public cJoystick As cJoystickChannels

    Public nInvalidCount As Long

    Public nParameterCount As Integer
    Public nParameterCurrentIndex As Integer
    Public aIDs(0) As String
    Public aName(0) As String
    Public aMin(0) As String
    Public aMax(0) As String
    Public aValue(0) As String
    Public aVisible(0) As Boolean
    Public aDefault(0) As String
    Public aComments(0) As String
    Public aMultiplier(0) As String
    Public aAdder(0) As String
    Public aBit(0) As String
    Public aChanged(0) As Boolean
    Public aWPCommand(0) As Integer
    Public aWPOther(0) As String
    Public aWPOther2(0) As String
    Public aWPOther3(0) As String
    Public aWPOther4(0) As String


    Public eMissionFileType As e_MissionFileType = e_MissionFileType.e_MissionFileType_None
    Public Function StringToByte(ByVal inputString As String, Optional ByVal byteArrayLength As Integer = -1, Optional ByVal bytePadding As Byte = 0) As Byte()
        Dim arr() As Byte
        Dim encoding As New System.Text.UTF8Encoding()
        Dim nCount As Integer

        arr = encoding.GetBytes(inputString)

        If byteArrayLength <> -1 Then
            ReDim Preserve arr(0 To byteArrayLength - 1)
            For nCount = Len(inputString) To byteArrayLength - 1
                arr(nCount) = bytePadding
            Next
        End If
        Return arr
    End Function

    Public Function GetServoValue(ByVal inputString As String) As Double
        If IsNumeric(inputString) = True Then
            GetServoValue = Convert.ToDouble(inputString)
        Else
            GetServoValue = 0
        End If
    End Function
    Public Function GetDistanceUnitsText() As String
        Select Case eDistanceUnits
            Case e_DistanceFormat.e_DistanceFormat_Feet
                GetDistanceUnitsText = GetResString(, "Feet")
            Case e_DistanceFormat.e_DistanceFormat_Meters
                GetDistanceUnitsText = GetResString(, "Meters")
        End Select
    End Function
    Public Function GetSpeedUnitsText() As String
        Select Case eSpeedUnits
            Case e_SpeedFormat.e_SpeedFormat_Knots
                GetSpeedUnitsText = GetResString(, "Knots")
            Case e_SpeedFormat.e_SpeedFormat_KPH
                GetSpeedUnitsText = GetResString(, "KPH")
            Case e_SpeedFormat.e_SpeedFormat_MPerSec
                GetSpeedUnitsText = GetResString(, "m_s")
            Case e_SpeedFormat.e_SpeedFormat_MPH
                GetSpeedUnitsText = GetResString(, "MPH")
        End Select
    End Function

    Public Function ConCatArray(ByVal arrayOne() As Byte, ByVal arrayTwo() As Byte) As Byte()
        Dim nArrayOneLength As Long
        Dim nArrayTwoLength As Long
        Dim bArrayOneValid As Boolean
        Dim bArrayTwoValid As Boolean

        Try
            If IsNothing(arrayOne) = True Then
                nArrayOneLength = 0
                bArrayOneValid = False
            Else
                nArrayOneLength = UBound(arrayOne) + 1
                bArrayOneValid = True
            End If
            If IsNothing(arrayTwo) = True Then
                nArrayTwoLength = 0
                bArrayTwoValid = False
            Else
                nArrayTwoLength = UBound(arrayTwo) + 1
                bArrayTwoValid = True
            End If
            ReDim ConCatArray(0 To nArrayOneLength + nArrayTwoLength - 1)
            If bArrayOneValid = True Then
                arrayOne.CopyTo(ConCatArray, 0)
            End If
            If bArrayTwoValid = True Then
                arrayTwo.CopyTo(ConCatArray, nArrayOneLength)
            End If
        Catch ex As Exception
        End Try
    End Function

    Public Function ParseServerAndPort(ByVal inputString As String, ByRef ipaddress As String, ByRef portNumber As Long) As Boolean
        Dim bValidPort As Boolean = False
        Dim bValidIP As Boolean = True
        Dim sTempPortNumber As String
        Dim sTempIpAddress As String
        Dim sSplit() As String
        Dim nCount As Integer

        ParseServerAndPort = False
        If InStr(inputString, ":") <> 0 Then
            sTempPortNumber = inputString.Substring(InStr(inputString, ":"))
            If IsNumeric(sTempPortNumber) = True And Trim(sTempPortNumber) <> "" Then
                portNumber = CLng(sTempPortNumber)
                bValidPort = True
            End If

            sSplit = Split(inputString.Substring(0, InStr(inputString, ":") - 1), ".")
            If UBound(sSplit) = 3 Then
                For nCount = 0 To UBound(sSplit)
                    If IsNumeric(sSplit(nCount)) = False Or Trim(sSplit(nCount)) = "" Then
                        bValidIP = False
                        Exit For
                    End If
                Next
                If bValidIP = True Then
                    ipaddress = inputString.Substring(0, InStr(inputString, ":") - 1)
                End If
            Else
                Try
                    Dim ipHostInfo As IPHostEntry = Dns.GetHostEntry(inputString.Substring(0, InStr(inputString, ":") - 1))
                    ipaddress = ipHostInfo.AddressList(0).ToString
                Catch
                    bValidIP = False
                End Try
            End If
            If bValidIP = True And bValidPort = True Then
                ParseServerAndPort = True
            End If
        Else
            If IsNumeric(inputString) = True And Trim(inputString) <> "" Then
                ipaddress = "127.0.0.1"
                portNumber = CLng(inputString)
                ParseServerAndPort = True
            End If
        End If
    End Function

    Public Function GetNMEADate(ByVal inputString As String) As Date
        Try
            Dim cf As System.Globalization.CultureInfo
            cf = New System.Globalization.CultureInfo("en-US")
            inputString = inputString.PadLeft(6, "0")
            If inputString <> "000000" Then
                GetNMEADate = GetNMEADate.Parse(inputString.Substring(2, 2) & "/" & inputString.Substring(0, 2) & "/" & inputString.Substring(4, 2), cf).Date
            End If
        Catch
        End Try
    End Function
    Public Function GetNMEATime(ByVal inputString As String) As Date
        Try
            Dim cf As System.Globalization.CultureInfo
            cf = New System.Globalization.CultureInfo("en-US")
            If InStr(inputString, ".") <> 0 Then
                inputString = inputString.Substring(0, InStr(inputString, ".") - 1)
            End If
            inputString = inputString.PadLeft(6, "0")
            If inputString <> "000000" Then
                GetNMEATime = GetNMEATime.Parse(inputString.Substring(0, 2) & ":" & inputString.Substring(2, 2) & ":" & inputString.Substring(4, 2), cf).ToLongTimeString
            End If
        Catch
        End Try
    End Function
    Public Function GetMediaTekv16Date(ByVal inputString As String) As Date
        Try
            Dim cf As System.Globalization.CultureInfo
            cf = New System.Globalization.CultureInfo("en-US")
            GetMediaTekv16Date = GetMediaTekv16Date.Parse(inputString.Substring(2, 2) & "/" & inputString.Substring(0, 2) & "/" & inputString.Substring(4, 2), cf).Date
        Catch
        End Try
    End Function
    Public Function GetMediaTekv16Time(ByVal inputString As String) As Date
        Try
            Dim cf As System.Globalization.CultureInfo
            cf = New System.Globalization.CultureInfo("en-US")
            inputString = inputString.PadLeft(8, "0")
            GetMediaTekv16Time = GetMediaTekv16Time.Parse(inputString.Substring(0, 2) & ":" & inputString.Substring(2, 2) & ":" & inputString.Substring(4, 2), cf).ToLongTimeString
        Catch
        End Try
    End Function
    Public Function GetuBloxTime(ByVal inputValue As Double) As Date
        Try
            GetuBloxTime = DateAdd(DateInterval.Second, inputValue, DateAdd(DateInterval.Day, -DateInterval.Weekday + 1, Now).Date)
            nTOWDayOffset = DateDiff(DateInterval.Day, DateAdd(DateInterval.Day, -DateInterval.Weekday + 1, Now), GetuBloxTime)
            GetuBloxTime = GetuBloxTime.ToLongTimeString
        Catch
        End Try
    End Function
    Public Function GetuBloxDate(ByVal inputValue As Double) As Date
        Try
            Dim cf As System.Globalization.CultureInfo
            cf = New System.Globalization.CultureInfo("en-US")
            GetuBloxDate = DateAdd(DateInterval.Day, inputValue * 7 + nTOWDayOffset, GetuBloxDate.Parse("1/6/1980", cf)).Date
        Catch
        End Try
    End Function
    Public Function GetUnixDate(ByVal inputValue As Double) As Date
        Try
            Dim d As New DateTime(1970, 1, 1)
            GetUnixDate = d.AddSeconds(inputValue).Date
        Catch
        End Try
    End Function
    Public Function GetUnixTime(ByVal inputValue As Double) As Date
        Try
            Dim d As New DateTime(1970, 1, 1)
            GetUnixTime = d.AddSeconds(inputValue).ToLongTimeString
        Catch
        End Try
    End Function
    Public Function GetUnixDateTime(ByVal inputValue As Double) As Date
        Try
            Dim d As New DateTime(1970, 1, 1)
            GetUnixDateTime = d.AddSeconds(inputValue)
        Catch
        End Try
    End Function
    Public Function LookupInstrumentColorName(ByVal inputColor As e_InstrumentColor) As String
        Select Case inputColor
            Case e_InstrumentColor.e_InstrumentColor_Blue
                LookupInstrumentColorName = GetResString(, "Blue")
            Case e_InstrumentColor.e_InstrumentColor_Cyan
                LookupInstrumentColorName = GetResString(, "Cyan")
            Case e_InstrumentColor.e_InstrumentColor_Green
                LookupInstrumentColorName = GetResString(, "Green")
            Case e_InstrumentColor.e_InstrumentColor_Orange
                LookupInstrumentColorName = GetResString(, "Orange")
            Case e_InstrumentColor.e_InstrumentColor_Purple
                LookupInstrumentColorName = GetResString(, "Purple")
            Case e_InstrumentColor.e_InstrumentColor_Red
                LookupInstrumentColorName = GetResString(, "Red")
            Case e_InstrumentColor.e_InstrumentColor_Yellow
                LookupInstrumentColorName = GetResString(, "Yellow")
        End Select
    End Function
    Public Function GetResString(Optional ByVal inputControl As Object = Nothing, Optional ByVal resString As String = "", Optional ByVal includeColon As Boolean = False, Optional ByVal stripUnderscore As Boolean = False, Optional ByVal blankIfMissing As Boolean = False, Optional ByVal firstReplace As String = "", Optional ByVal secondReplace As String = "", Optional ByVal addVerticalCarriageReturns As Boolean = False, Optional ByVal defaultValue As String = "") As String
        Dim sParentName As String
        Dim oControl As Object

        Try
            If resString <> "" Then
                GetResString = resourceMgr.GetString(Replace(resString, " ", "_"), oCulture).ToString
                If GetResString Is Nothing Then
                    GetResString = Replace(resString, " ", "_")
                    Debug.Print(resString)
                End If
            End If
        Catch err2 As Exception
            Debug.Print("Missing Word in Strings.resx" & vbCrLf & err2.Message)
            If GetResString = "" Then
                GetResString = defaultValue
            End If
        End Try
        If stripUnderscore = True Then
            GetResString = Replace(GetResString, "&&", Chr(1))
            GetResString = Replace(GetResString, "&", "")
            GetResString = Replace(GetResString, Chr(1), "&&")
        End If
        GetResString = Replace(GetResString, "^", vbCrLf)
        If firstReplace <> "" Then
            GetResString = Replace(GetResString, "&1", firstReplace)
        End If
        If secondReplace <> "" Then
            GetResString = Replace(GetResString, "&2", secondReplace)
        End If
        If GetResString Is Nothing Then
            If defaultValue <> "" Then
                GetResString = defaultValue
            Else
                GetResString = Replace(resString, " ", "_")
            End If
            Debug.Print(resString)
        End If
        If includeColon = True Then
            GetResString = GetResString & ":"
        End If
        If Not inputControl Is Nothing Then
            inputControl.text = GetResString
        End If
    End Function
    Public Function ConvertSpeed(ByVal inputValue As String, ByVal inputFormat As e_SpeedFormat, ByVal outputFormat As e_SpeedFormat, Optional ByVal formatString As String = "") As Single
        Dim nTemp As Double
        Dim sNewFormat As String

        If formatString <> "" Then
            sNewFormat = formatString
        Else
            sNewFormat = "#.00"
        End If

        If inputFormat = outputFormat Then
            ConvertSpeed = ConvertPeriodToLocal(inputValue)
        Else
            Select Case inputFormat
                Case e_SpeedFormat.e_SpeedFormat_Knots
                    nTemp = ConvertPeriodToLocal(inputValue) * 1.852
                Case e_SpeedFormat.e_SpeedFormat_KPH
                    nTemp = ConvertPeriodToLocal(inputValue)
                Case e_SpeedFormat.e_SpeedFormat_MPerSec
                    nTemp = ConvertPeriodToLocal(inputValue) * 3.6
                Case e_SpeedFormat.e_SpeedFormat_MPH
                    nTemp = ConvertPeriodToLocal(inputValue) * 1.609344
            End Select

            Select Case outputFormat
                Case e_SpeedFormat.e_SpeedFormat_Knots
                    ConvertSpeed = (nTemp / 1.852).ToString(sNewFormat)
                Case e_SpeedFormat.e_SpeedFormat_KPH
                    ConvertSpeed = (nTemp).ToString(sNewFormat)
                Case e_SpeedFormat.e_SpeedFormat_MPerSec
                    ConvertSpeed = (nTemp / 3.6).ToString(sNewFormat)
                Case e_SpeedFormat.e_SpeedFormat_MPH
                    ConvertSpeed = (nTemp / 1.609344).ToString(sNewFormat)
            End Select
        End If
    End Function

    Public Function GetShortDistanceUnits() As String
        Select Case eDistanceUnits
            Case e_DistanceFormat.e_DistanceFormat_Feet
                GetShortDistanceUnits = "ft"
            Case e_DistanceFormat.e_DistanceFormat_Meters
                GetShortDistanceUnits = "m"
        End Select
    End Function

    Public Function ConvertDistance(ByVal inputValue As String, ByVal inputFormat As e_DistanceFormat, ByVal outputFormat As e_DistanceFormat) As Single
        Dim nTemp As Double

        If inputFormat = outputFormat Then
            ConvertDistance = ConvertPeriodToLocal(inputValue)
        Else
            Select Case inputFormat
                Case e_DistanceFormat.e_DistanceFormat_Feet
                    nTemp = ConvertPeriodToLocal(inputValue) / 3.2808399
                Case e_DistanceFormat.e_DistanceFormat_Meters
                    nTemp = ConvertPeriodToLocal(inputValue)
            End Select

            Select Case outputFormat
                Case e_DistanceFormat.e_DistanceFormat_Feet
                    ConvertDistance = (nTemp * 3.2808399).ToString("#.00")
                Case e_DistanceFormat.e_DistanceFormat_Meters
                    ConvertDistance = (nTemp).ToString("#.00")
            End Select
        End If
    End Function
    Public Function ConvertPeriodToLocal(ByVal inputString As String) As Double
        Try
            ConvertPeriodToLocal = Convert.ToDouble(Replace(inputString, ".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
        Catch
            ConvertPeriodToLocal = 0
        End Try
    End Function
    Public Function ConvertLocalToPeriod(ByVal inputString As String) As String
        ConvertLocalToPeriod = Replace(inputString, System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".")
    End Function
    Public Function ConvertLatLongFormat(ByVal inputValue As String, ByVal inputFormat As e_LatLongFormat, ByVal outputFormat As e_LatLongFormat, ByVal isLat As Boolean) As String
        Dim sFormat As String

        If isLat = True Then
            If outputFormat = e_LatLongFormat.e_LatLongFormat_DD_DDDDDD Then
                sFormat = "00.000000"
            Else
                sFormat = "0000.0000"
            End If
        Else
            If outputFormat = e_LatLongFormat.e_LatLongFormat_DD_DDDDDD Then
                sFormat = "000.000000"
            Else
                sFormat = "00000.0000"
            End If
        End If

        If inputFormat = outputFormat Then
            ConvertLatLongFormat = inputValue
        Else
            Select Case inputFormat
                Case e_LatLongFormat.e_LatLongFormat_DD_DDDDDD
                    ConvertLatLongFormat = (Mid(inputValue, 1, InStr(inputValue, ".") - 1) & Convert.ToDouble(ConvertPeriodToLocal(Mid(inputValue, InStr(inputValue, "."))) * 60))
                Case e_LatLongFormat.e_LatLongFormat_DDMM_MMMM
                    If InStr(inputValue, ".") <> 0 Then
                        ConvertLatLongFormat = Mid(inputValue, 1, InStr(inputValue, ".") - 3) & (Convert.ToDouble(ConvertPeriodToLocal(Mid(inputValue, InStr(inputValue, ".") - 2))) / 60).ToString(".000000")
                    Else
                        ConvertLatLongFormat = 0
                    End If
                Case Else
                    ConvertLatLongFormat = inputValue.ToString(sFormat)
            End Select
        End If
    End Function
    Public Function ConvertHexToDec(ByVal inputValue As String, Optional ByVal reverseBytes As Boolean = True, Optional ByVal signedNumber As Boolean = True) As String
        Dim sTemp As String
        Dim sTemp2 As String
        Dim nCount As Integer
        Dim sTwos As String

        sTemp2 = ""
        sTwos = ""
        If reverseBytes = True Then
            sTemp = Strings.StrReverse(inputValue)
        Else
            sTemp = inputValue
        End If
        For nCount = 1 To Len(sTemp)
            sTemp2 = sTemp2 & Hex(Asc(Mid(sTemp, nCount, 1))).PadLeft(2, "0")
            sTwos = sTwos & "FF"
        Next
        ConvertHexToDec = Convert.ToInt64(sTemp2, 16)


        If ConvertHexToDec > 2 ^ (Len(inputValue) * 8 - 1) And signedNumber = True Then
            'ConvertHexToDec = 0 - (ConvertHexToDec And &H7FFF)
            ConvertHexToDec = Convert.ToInt64(ConvertHexToDec) - Convert.ToInt64(sTwos, 16) - 1
        End If

    End Function
    Public Function ConvertHexToDecFY21AP(ByVal inputValue As String, Optional ByVal twosCompilment As Boolean = True) As String
        ConvertHexToDecFY21AP = ConvertHexToDec(inputValue, False, twosCompilment)
        If ConvertHexToDecFY21AP And &H8000 And twosCompilment Then
            ConvertHexToDecFY21AP = 0 - (ConvertHexToDecFY21AP And &H7FFF)
        End If
    End Function
    Public Function ConvertLatLongFY21AP(ByVal inputValue As String) As String
        Dim nTemp As Double

        nTemp = (((Asc(Mid(inputValue, 1, 1)) * 256 + Asc(Mid(inputValue, 2, 1))) And &H7FFF) + ((Asc(Mid(inputValue, 3, 1)) * 256 + Asc(Mid(inputValue, 4, 1))) * 0.0001))
        nTemp = nTemp / 60

        If ((Asc(Mid(inputValue, 1, 1)) * 256 + Asc(Mid(inputValue, 2, 1))) And &H8000) = &H8000 Then
            nTemp = -nTemp
        End If
        'asdasdasdasd()

        'nTemp = CDec("&h" & Hex(Asc(Mid(inputValue, 1, 1))).PadLeft(2, "0") & Hex(Asc(Mid(inputValue, 2, 1))).PadLeft(2, "0")) And &H7FFF

        ''nTemp = CDec("&h" & Hex(Asc(Mid(inputValue, 1, 1))) & Hex(Asc(Mid(inputValue, 2, 1)))) And &H7FFF
        'nTemp = (nTemp + CDec("&h" & Hex(Asc(Mid(inputValue, 3, 1))) & Hex(Asc(Mid(inputValue, 4, 1)))) * 0.00001) / 60
        'If nTemp > 32768 Then
        '    nTemp = nTemp - 32768
        'End If

        'If CDec("&h" & Hex(Asc(Mid(inputValue, 1, 1))) & Hex(Asc(Mid(inputValue, 2, 1)))) And &H8000 Then
        '    nTemp = -nTemp
        'End If
        ConvertLatLongFY21AP = nTemp.ToString("0.0000000")
    End Function
    Public Function GetNextSentence(ByRef sBuffer As String) As cMessage ', ByRef aBuffer() As Byte
        Dim sTemp As String = ""
        Dim nLastStart As Integer
        Dim nCount As Integer
        Dim sOutput As String = ""
        Dim nPacketSize As Integer
        Dim sHeaderCharacters As String
        Dim sFooterCharacters As String
        Dim nMessageType As cMessage.e_MessageType
        Dim nSizeOffset As Integer
        Dim sSplit() As String
        Dim sValues() As String
        Dim nXBeeAPIStart As Integer
        Dim nXBeeAPIDataLength As Integer
        Dim dLocalDate As Date
        Dim dLocalTime As Date

        nLastStart = 999
        GetNextSentence = New cMessage
        GetNextSentence.ValidMessage = False
        GetNextSentence.ValidDateTime = False
        nMessageType = cMessage.e_MessageType.e_MessageType_None

        Try
            sHeaderCharacters = "TEST:"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_Test
            End If

            sHeaderCharacters = "DIYd"
            If NewInstr(sBuffer, sHeaderCharacters) < nLastStart And NewInstr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = NewInstr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_ArduIMU_Binary
            End If

            sHeaderCharacters = Chr(85)
            If NewInstr(sBuffer, sHeaderCharacters) < nLastStart And NewInstr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = NewInstr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_MAV
            End If

            sHeaderCharacters = "T"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 And Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 2, 1) = ";" Then
                If Len(sBuffer) >= InStr(sBuffer, sHeaderCharacters) + 2 Then
                    If Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 2, 1) = ";" Then
                        nLastStart = InStr(sBuffer, sHeaderCharacters)
                        nMessageType = cMessage.e_MessageType.e_MessageType_GluonpilotT
                    End If
                End If
            End If

            sHeaderCharacters = "CA"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 And Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 2, 1) = ";" Then
                If Len(sBuffer) >= InStr(sBuffer, sHeaderCharacters) + 2 Then
                    If Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 2, 1) = ";" Then
                        nLastStart = InStr(sBuffer, sHeaderCharacters)
                        nMessageType = cMessage.e_MessageType.e_MessageType_GluonpilotC
                    End If
                End If
            End If

            sHeaderCharacters = "D"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 And Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 2, 1) = ";" Then
                If Len(sBuffer) >= InStr(sBuffer, sHeaderCharacters) + 2 Then
                    If Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 2, 1) = ";" Then
                        nLastStart = InStr(sBuffer, sHeaderCharacters)
                        nMessageType = cMessage.e_MessageType.e_MessageType_GluonpilotD
                    End If
                End If
            End If

            sHeaderCharacters = "F13:"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_UDB_SetHome
            End If

            sHeaderCharacters = "F2:"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_UDB
            End If

            sHeaderCharacters = "$GP"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_NMEA
            End If

            sHeaderCharacters = "$A"
            If InStr(sBuffer, sHeaderCharacters) <= nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_AttoPilot
            End If

            sHeaderCharacters = "$ATTO"
            If InStr(sBuffer, sHeaderCharacters) <= nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_AttoPilot18
            End If

            sHeaderCharacters = "$D"
            If InStr(sBuffer, sHeaderCharacters) <= nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_AttoSetParam
            End If

            sHeaderCharacters = "$OK"
            If InStr(sBuffer, sHeaderCharacters) <= nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_AttoOk
            End If

            sHeaderCharacters = "$GPS"
            If InStr(sBuffer, sHeaderCharacters) <= nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_AttoPilot18
            End If

            sHeaderCharacters = "home:"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_ArduPilot_Home
            End If

            sHeaderCharacters = "wp #"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_ArduPilot_WP
            End If

            sHeaderCharacters = "WP Total:"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_ArduPilot_WPCount
            End If

            sHeaderCharacters = "+++"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_ArduPilot_Attitude
            End If

            sHeaderCharacters = "###"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_ArduPilot_ModeChange
            End If

            sHeaderCharacters = "!!!"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_ArduPilot_GPS
            End If

            sHeaderCharacters = Chr(&HB5) & Chr(&H62)
            If NewInstr(sBuffer, sHeaderCharacters) < nLastStart And NewInstr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = NewInstr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_uBlox
            End If

            sHeaderCharacters = Chr("&HD0") & Chr("&HDD")
            If NewInstr(sBuffer, sHeaderCharacters) < nLastStart And NewInstr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = NewInstr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_MediaTekv16
            End If

            sHeaderCharacters = Chr(&HA5) & Chr(&H5A)
            If NewInstr(sBuffer, sHeaderCharacters) < nLastStart And NewInstr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = NewInstr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_FY21AP
            End If

            sHeaderCharacters = "4D"
            If NewInstr(sBuffer, sHeaderCharacters) < nLastStart And NewInstr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = NewInstr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_ArduPilotMega_Binary
            End If

            sHeaderCharacters = Chr(&HA0) & Chr(&HA2)
            If NewInstr(sBuffer, sHeaderCharacters) < nLastStart And NewInstr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = NewInstr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_SiRF
            End If

            sHeaderCharacters = " "
            Try
                If Len(sBuffer) >= 18 Then
                    If sBuffer.Substring(17, 1) = " " And IsNumeric(sBuffer.Substring(0, 17)) = True Then
                        nLastStart = InStr(sBuffer, sHeaderCharacters) - 17
                        nMessageType = cMessage.e_MessageType.e_MessageType_Paparazzi
                    End If
                End If
            Catch
            End Try

            sHeaderCharacters = ":"
            Try
                If Len(sBuffer) >= 19 Then
                    If sBuffer.Substring(18, 1) = ":" And IsNumeric(sBuffer.Substring(0, 18)) = True Then
                        nLastStart = InStr(sBuffer, sHeaderCharacters) - 18
                        nMessageType = cMessage.e_MessageType.e_MessageType_HKO
                    End If
                End If
            Catch
            End Try

            'X-Bee API Filter
            Try
                Do While InStr(sBuffer, Chr(&H7E)) <> 0
                    nXBeeAPIStart = InStr(sBuffer, Chr(&H7E))
                    If Len(sBuffer) > nXBeeAPIStart + 2 Then
                        nXBeeAPIDataLength = Convert.ToInt32(Hex(Asc(Mid(sBuffer, nXBeeAPIStart + 1, 1))).PadLeft(2, "0") & Hex(Asc(Mid(sBuffer, nXBeeAPIStart + 2, 1))).PadLeft(2, "0"), 16)
                        If Len(sBuffer) >= nXBeeAPIStart + nXBeeAPIDataLength + 2 Then
                            If Mid(sBuffer, nXBeeAPIStart + nXBeeAPIDataLength + 2, 1) = GetXbeeChecksum(Mid(sBuffer, nXBeeAPIStart + 2, nXBeeAPIDataLength)) Then
                                sBuffer = Replace(sBuffer, Mid(sBuffer, nXBeeAPIStart, nXBeeAPIDataLength + 4), "")
                            Else
                                Exit Do
                            End If
                        Else
                            Exit Do
                        End If
                    Else
                        Exit Do
                    End If
                Loop
            Catch ex2 As Exception
                Debug.Print("X-Bee API Filter Error: " & ex2.Message)
            End Try

            If nMessageType <> cMessage.e_MessageType.e_MessageType_None Then
                Select Case nMessageType
                    Case cMessage.e_MessageType.e_MessageType_Test
                        sHeaderCharacters = "TEST:"
                        If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) >= 6 Then
                            nPacketSize = 255
                            If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) >= nPacketSize + 5 Then
                                nLastStart = InStr(sBuffer, sHeaderCharacters)
                                sTemp = Mid(sBuffer, nLastStart, nPacketSize + 5)
                                If bShowBinary = True Then
                                    For nCount = 1 To Len(sTemp)
                                        sOutput = sOutput & Hex(Asc(Mid(sTemp, nCount, 1))).PadLeft(2, "0") & " "
                                    Next
                                Else
                                    sOutput = "{Binary Message}"
                                End If
                                With GetNextSentence
                                    ReDim .RawBytes(0 To Len(sTemp) - 1)
                                    'If Not aBuffer Is Nothing Then
                                    '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                    'End If
                                    .RawMessage = sTemp
                                    .MessageType = nMessageType
                                    .Header = "Test Msg"
                                    .Packet = Mid(sTemp, 6, Len(sTemp) - 5)
                                    .PacketLength = Len(.Packet) - 2
                                    .VisibleSentence = .Header & " - " & sOutput
                                    .ValidMessage = True
                                End With
                            End If
                        End If

                    Case cMessage.e_MessageType.e_MessageType_HKO
                        sHeaderCharacters = ":"
                        sFooterCharacters = Chr(255)
                        If InStr(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 1), sFooterCharacters) <> 0 Then
                            nLastStart = InStr(sBuffer, sHeaderCharacters) - 18
                            sTemp = Mid(sBuffer, nLastStart)
                            sTemp = Mid(sTemp, 1, InStr(sTemp, sFooterCharacters) - 2)
                            With GetNextSentence
                                ReDim .RawBytes(0 To Len(sTemp) - 1)
                                'If Not aBuffer Is Nothing Then
                                '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                'End If
                                .RawMessage = sTemp
                                .MessageType = nMessageType
                                .ValidMessage = True
                                .Header = "HKO Output File"
                                .Packet = sTemp
                                .PacketLength = Len(.Packet)
                                .VisibleSentence = .Header & " - " & sTemp
                                Try
                                    .GPSDateTime = New Date(Mid(sTemp, 1, 18))
                                    .ValidDateTime = True
                                Catch
                                End Try
                            End With
                        End If

                    Case cMessage.e_MessageType.e_MessageType_Paparazzi
                        sHeaderCharacters = " "
                        sFooterCharacters = vbLf
                        If InStr(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 1), sFooterCharacters) <> 0 Then
                            nLastStart = InStr(sBuffer, sHeaderCharacters) - 17
                            sTemp = Mid(sBuffer, nLastStart)
                            sTemp = Mid(sTemp, 1, InStr(sTemp, sFooterCharacters) - 2)
                            With GetNextSentence
                                ReDim .RawBytes(0 To Len(sTemp) - 1)
                                'If Not aBuffer Is Nothing Then
                                '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                'End If
                                .RawMessage = sTemp
                                .MessageType = nMessageType
                                oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_Paparazzi) = Now.Ticks
                                .ValidMessage = True
                                .Header = "Paparazzi"
                                .Packet = sTemp
                                .PacketLength = Len(.Packet)
                                .VisibleSentence = .Header & " - " & sTemp
                                Try
                                    .GPSDateTime = GetUnixDateTime(.RawMessage.Substring(0, 17))
                                    .ValidDateTime = True
                                Catch ex As Exception
                                End Try
                            End With
                        End If

                    Case cMessage.e_MessageType.e_MessageType_UDB
                        sHeaderCharacters = "F2:"
                        sFooterCharacters = vbCrLf
                        If InStr(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 1), sFooterCharacters) <> 0 Then
                            nLastStart = InStr(sBuffer, sHeaderCharacters)
                            sTemp = Mid(sBuffer, nLastStart)
                            sTemp = Mid(sTemp, 1, InStr(sTemp, sFooterCharacters) + 2)
                            With GetNextSentence
                                ReDim .RawBytes(0 To Len(sTemp) - 1)
                                'If Not aBuffer Is Nothing Then
                                '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                'End If
                                .RawMessage = sTemp
                                .MessageType = nMessageType
                                oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_UDB) = Now.Ticks
                                .ValidMessage = True
                                .Header = "Serial UDB Extra"
                                .Packet = Mid(sTemp, 4, Len(sTemp) - 6)
                                .PacketLength = Len(.Packet)
                                .VisibleSentence = .Header & " - " & Mid(sTemp, 1, Len(sTemp) - 2)
                                Try
                                    sSplit = Split(.RawMessage, ":")
                                    .GPSDateTime = GetuBloxTime(Convert.ToDouble(Mid(sSplit(0), 2)) / 1000)
                                    .ValidDateTime = True
                                Catch
                                End Try
                            End With
                        End If

                    Case cMessage.e_MessageType.e_MessageType_UDB_SetHome
                        sHeaderCharacters = "F13:"
                        sFooterCharacters = vbCrLf
                        If InStr(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 1), sFooterCharacters) <> 0 Then
                            nLastStart = InStr(sBuffer, sHeaderCharacters)
                            sTemp = Mid(sBuffer, nLastStart)
                            sTemp = Mid(sTemp, 1, InStr(sTemp, sFooterCharacters) + 2)
                            With GetNextSentence
                                ReDim .RawBytes(0 To Len(sTemp) - 1)
                                'If Not aBuffer Is Nothing Then
                                '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                'End If
                                .RawMessage = sTemp
                                .MessageType = nMessageType
                                oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_UDB) = Now.Ticks
                                .ValidMessage = True
                                .Header = "Serial UDB Extra"
                                .Packet = Mid(sTemp, 5, Len(sTemp) - 7)
                                .PacketLength = Len(.Packet)
                                .VisibleSentence = .Header & " - " & Mid(sTemp, 1, Len(sTemp) - 2)
                            End With
                        End If

                    Case cMessage.e_MessageType.e_MessageType_ArduIMU_Binary
                        sHeaderCharacters = "DIYd"
                        If Len(Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters))) >= 5 Then
                            nPacketSize = Asc(Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters) + 4, 1))
                            If Len(Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters))) >= nPacketSize + 8 Then
                                nLastStart = NewInstr(sBuffer, sHeaderCharacters)
                                sTemp = Mid(sBuffer, nLastStart, nPacketSize + 8)
                                If bShowBinary = True Then
                                    For nCount = 1 To Len(sTemp)
                                        sOutput = sOutput & Hex(Asc(Mid(sTemp, nCount, 1))).PadLeft(2, "0") & " "
                                    Next
                                Else
                                    sOutput = "{Binary Message}"
                                End If
                                With GetNextSentence
                                    ReDim .RawBytes(0 To Len(sTemp) - 1)
                                    'If Not aBuffer Is Nothing Then
                                    '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                    'End If
                                    .RawMessage = sTemp
                                    .MessageType = nMessageType
                                    .Header = "ArduIMU"
                                    .ID = Asc(Mid(sTemp, 6, 1))
                                    .Packet = Mid(sTemp, 5, Len(sTemp) - 6)
                                    .PacketLength = Len(.Packet)
                                    .Checksum = Strings.Right(sTemp, 2)
                                    .VisibleSentence = .Header & " - " & sOutput
                                    If .Checksum = GetuBloxChecksum(.Packet) Then
                                        .ValidMessage = True
                                        oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_ArduIMU) = Now.Ticks
                                    Else
                                        .ValidMessage = False
                                    End If
                                End With
                            End If
                        End If

                    Case cMessage.e_MessageType.e_MessageType_ArduPilot_Attitude
                        sHeaderCharacters = "+++"
                        sFooterCharacters = "***"
                        If InStr(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 1), sFooterCharacters) <> 0 Then
                            nLastStart = InStr(sBuffer, sHeaderCharacters)
                            sTemp = Mid(sBuffer, nLastStart)
                            sTemp = Mid(sTemp, 1, InStr(sTemp, sFooterCharacters) + 2)
                            With GetNextSentence
                                ReDim .RawBytes(0 To Len(sTemp) - 1)
                                'If Not aBuffer Is Nothing Then
                                '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                'End If
                                .RawMessage = sTemp
                                .MessageType = nMessageType
                                oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_ArduPilotLegacy) = Now.Ticks
                                .ValidMessage = True
                                .Header = "AP Attitude"
                                .Packet = Mid(sTemp, 4, Len(sTemp) - 6)
                                .PacketLength = Len(.Packet)
                                .VisibleSentence = .Header & " - " & sTemp
                            End With
                        End If

                    Case cMessage.e_MessageType.e_MessageType_ArduPilot_ModeChange
                        sHeaderCharacters = "###"
                        sFooterCharacters = "***"
                        If InStr(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 1), sFooterCharacters) <> 0 Then
                            nLastStart = InStr(sBuffer, sHeaderCharacters)
                            sTemp = Mid(sBuffer, nLastStart)
                            sTemp = Mid(sTemp, 1, InStr(sTemp, sFooterCharacters) + 2)
                            With GetNextSentence
                                ReDim .RawBytes(0 To Len(sTemp) - 1)
                                'If Not aBuffer Is Nothing Then
                                '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                'End If
                                .RawMessage = sTemp
                                .MessageType = nMessageType
                                oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_ArduPilotLegacy) = Now.Ticks
                                .ValidMessage = True
                                .Header = "AP Mode Change"
                                .Packet = Mid(sTemp, 4, Len(sTemp) - 6)
                                .PacketLength = Len(.Packet)
                                .VisibleSentence = .Header & " - " & sTemp
                            End With
                        End If

                    Case cMessage.e_MessageType.e_MessageType_ArduPilot_GPS
                        sHeaderCharacters = "!!!"
                        sFooterCharacters = "***"
                        If InStr(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 1), sFooterCharacters) <> 0 Then
                            nLastStart = InStr(sBuffer, sHeaderCharacters)
                            sTemp = Mid(sBuffer, nLastStart)
                            sTemp = Mid(sTemp, 1, InStr(sTemp, sFooterCharacters) + 2)
                            With GetNextSentence
                                ReDim .RawBytes(0 To Len(sTemp) - 1)
                                'If Not aBuffer Is Nothing Then
                                '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                'End If
                                .RawMessage = sTemp
                                .MessageType = nMessageType
                                oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_ArduPilotLegacy) = Now.Ticks
                                .ValidMessage = True
                                .Header = "AP GPS"
                                .Packet = Mid(sTemp, 4, Len(sTemp) - 6)
                                .PacketLength = Len(.Packet)
                                .VisibleSentence = .Header & " - " & sTemp
                                Try
                                    sSplit = Split(.Packet, ",")
                                    For nCount = 0 To UBound(sSplit)
                                        sValues = Split(sSplit(nCount), ":")
                                        If UCase(sValues(0) = "TOW") Then
                                            If UBound(sValues) >= 1 Then
                                                If IsNumeric(sValues(1)) = True Then
                                                    dGPSTime = GetuBloxTime(Convert.ToDouble(sValues(1) / 1000))
                                                    .ValidDateTime = True
                                                    Exit For
                                                End If
                                            End If
                                        End If
                                    Next
                                Catch
                                End Try
                            End With
                        End If

                    Case cMessage.e_MessageType.e_MessageType_NMEA
                        sHeaderCharacters = "$GP"
                        sFooterCharacters = vbLf
                        If InStr(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 1), sFooterCharacters) <> 0 Then
                            nLastStart = InStr(sBuffer, sHeaderCharacters)
                            sTemp = Mid(sBuffer, nLastStart)
                            sTemp = Mid(sTemp, 1, InStr(sTemp, sFooterCharacters) - 1)
                            If Strings.Right(sTemp, 1) = vbCr Then
                                sTemp = Mid(sTemp, 1, Len(sTemp) - 1)
                            End If
                            With GetNextSentence
                                ReDim .RawBytes(0 To Len(sTemp) - 1)
                                'If Not aBuffer Is Nothing Then
                                '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                'End If
                                .RawMessage = sTemp
                                .MessageType = nMessageType
                                .Header = Mid(sTemp, 1, 6)
                                .Packet = Mid(sTemp, 2, Len(Mid(sTemp, 1, InStr(sTemp, "*") - 2)))
                                .PacketLength = Len(.Packet)
                                .Checksum = Mid(sTemp, InStr(sTemp, "*") + 1)
                                .VisibleSentence = "NMEA - " & sTemp
                                If .Checksum = GetChecksum(.Packet) Then
                                    .ValidMessage = True
                                    oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_NMEA) = Now.Ticks
                                    Try
                                        sSplit = Split(.Packet, ",")
                                        Select Case .Header
                                            Case "$GPGLL"
                                                .GPSDateTime = GetNMEATime(sSplit(5))
                                                .ValidDateTime = True
                                            Case "$GPZDA"
                                                .GPSDateTime = CDate(GetNMEADate(sSplit(2) & sSplit(3) & sSplit(4)) & " " & GetNMEATime(sSplit(1)))
                                                .ValidDateTime = True
                                        End Select
                                    Catch
                                    End Try
                                Else
                                    .ValidMessage = False
                                End If
                            End With
                        End If

                    Case cMessage.e_MessageType.e_MessageType_GluonpilotT, cMessage.e_MessageType.e_MessageType_GluonpilotC, cMessage.e_MessageType.e_MessageType_GluonpilotD
                        If nMessageType = cMessage.e_MessageType.e_MessageType_GluonpilotC Then
                            sHeaderCharacters = "CA"
                        ElseIf nMessageType = cMessage.e_MessageType.e_MessageType_GluonpilotD Then
                            sHeaderCharacters = "D"
                        ElseIf nMessageType = cMessage.e_MessageType.e_MessageType_GluonpilotT Then
                            sHeaderCharacters = "T"
                        End If
                        sFooterCharacters = vbLf
                        If InStr(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 1), sFooterCharacters) <> 0 Then
                            nLastStart = InStr(sBuffer, sHeaderCharacters)
                            sTemp = Mid(sBuffer, nLastStart)
                            sTemp = Mid(sTemp, 1, InStr(sTemp, sFooterCharacters) - 1)
                            If Strings.Right(sTemp, 1) = vbCr Then
                                sTemp = Mid(sTemp, 1, Len(sTemp) - 1)
                            End If
                            With GetNextSentence
                                ReDim .RawBytes(0 To Len(sTemp) - 1)
                                'If Not aBuffer Is Nothing Then
                                '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                'End If
                                .RawMessage = sTemp
                                .MessageType = nMessageType
                                .Header = Mid(sTemp, 1, 2)
                                .Packet = Mid(sTemp, 4)
                                .PacketLength = Len(.Packet)
                                .VisibleSentence = "Gluonpilot - " & sTemp
                                If Mid(sTemp, 3, 1) = ";" Then
                                    .ValidMessage = True
                                    oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_GluonPilot) = Now.Ticks
                                Else
                                    .ValidMessage = False
                                End If

                                'Waiting on response from Tom on Date/Time field
                            End With
                        End If

                    Case cMessage.e_MessageType.e_MessageType_AttoPilot, cMessage.e_MessageType.e_MessageType_AttoPilot18, cMessage.e_MessageType.e_MessageType_AttoSetParam, cMessage.e_MessageType.e_MessageType_AttoOk
                        sHeaderCharacters = "$"
                        sFooterCharacters = vbCrLf
                        If InStr(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 1), sFooterCharacters) <> 0 Then
                            nLastStart = InStr(sBuffer, sHeaderCharacters)
                            sTemp = Mid(sBuffer, nLastStart)
                            sTemp = Mid(sTemp, 1, InStr(sTemp, sFooterCharacters) - 1)
                            If Strings.Right(sTemp, 1) = vbCr Then
                                sTemp = Mid(sTemp, 1, Len(sTemp) - 1)
                            End If
                            With GetNextSentence
                                ReDim .RawBytes(0 To Len(sTemp) - 1)
                                'If Not aBuffer Is Nothing Then
                                '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                'End If
                                .RawMessage = sTemp
                                .MessageType = nMessageType
                                .Header = Mid(sTemp, 1, 3)
                                .Packet = Mid(sTemp, 2, Len(Mid(sTemp, 1, InStr(sTemp, "*") - 2)))
                                .PacketLength = Len(.Packet)
                                .Checksum = Mid(sTemp, InStr(sTemp, "*") + 1)
                                .VisibleSentence = "AttoPilot - " & sTemp
                                If .Checksum = GetChecksum(.Packet) Then
                                    .ValidMessage = True
                                    oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_AttoPilot) = Now.Ticks
                                    Try
                                        sSplit = Split(.Packet, ",")
                                        If nMessageType = cMessage.e_MessageType.e_MessageType_AttoPilot Then
                                            If sSplit(0) = "A4" Then
                                                .GPSDateTime = CDate(GetNMEADate(sSplit(2)) & " " & GetNMEATime(sSplit(3)))
                                                .ValidDateTime = True
                                            End If
                                        ElseIf nMessageType = cMessage.e_MessageType.e_MessageType_AttoPilot18 Then
                                            If sSplit(0) = "GPS" Then
                                                .GPSDateTime = CDate(GetNMEADate(sSplit(1)) & " " & GetNMEATime(sSplit(2)))
                                                .ValidDateTime = True
                                            End If
                                        End If
                                    Catch
                                    End Try
                                Else
                                    .ValidMessage = False
                                End If
                            End With
                        End If

                    Case cMessage.e_MessageType.e_MessageType_ArduPilot_Home
                        sHeaderCharacters = "home:"
                        sFooterCharacters = vbLf
                        If InStr(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 1), sFooterCharacters) <> 0 Then
                            nLastStart = InStr(sBuffer, sHeaderCharacters)
                            sTemp = Mid(sBuffer, nLastStart)
                            sTemp = Mid(sTemp, 1, InStr(sTemp, sFooterCharacters) - 1)
                            If Strings.Right(sTemp, 1) = vbCr Then
                                sTemp = Mid(sTemp, 1, Len(sTemp) - 1)
                            End If
                            With GetNextSentence
                                ReDim .RawBytes(0 To Len(sTemp) - 1)
                                'If Not aBuffer Is Nothing Then
                                '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                'End If
                                .RawMessage = sTemp
                                .MessageType = nMessageType
                                oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_ArduPilotLegacy) = Now.Ticks
                                .Header = Mid(sTemp, 1, 5)
                                .Packet = sTemp
                                .PacketLength = Len(.Packet)
                                .VisibleSentence = "AP Home - " & sTemp
                                .ValidMessage = True
                            End With
                        End If

                    Case cMessage.e_MessageType.e_MessageType_ArduPilot_WP
                        sHeaderCharacters = "wp #"
                        sFooterCharacters = vbLf
                        If InStr(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 1), sFooterCharacters) <> 0 Then
                            nLastStart = InStr(sBuffer, sHeaderCharacters)
                            sTemp = Mid(sBuffer, nLastStart)
                            sTemp = Mid(sTemp, 1, InStr(sTemp, sFooterCharacters) - 1)
                            If Strings.Right(sTemp, 1) = vbCr Then
                                sTemp = Mid(sTemp, 1, Len(sTemp) - 1)
                            End If
                            With GetNextSentence
                                ReDim .RawBytes(0 To Len(sTemp) - 1)
                                'If Not aBuffer Is Nothing Then
                                '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                'End If
                                .RawMessage = sTemp
                                .MessageType = nMessageType
                                oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_ArduPilotLegacy) = Now.Ticks
                                .Header = Trim(Mid(sTemp, 1, 7))
                                .Packet = sTemp
                                .PacketLength = Len(.Packet)
                                .VisibleSentence = "AP Waypoint - " & sTemp
                                .ValidMessage = True
                            End With
                        End If

                    Case cMessage.e_MessageType.e_MessageType_ArduPilot_WPCount
                        sHeaderCharacters = "WP Total:"
                        sFooterCharacters = vbLf
                        If InStr(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 1), sFooterCharacters) <> 0 Then
                            nLastStart = InStr(sBuffer, sHeaderCharacters)
                            sTemp = Mid(sBuffer, nLastStart)
                            sTemp = Mid(sTemp, 1, InStr(sTemp, sFooterCharacters) - 1)
                            If Strings.Right(sTemp, 1) = vbCr Then
                                sTemp = Mid(sTemp, 1, Len(sTemp) - 1)
                            End If
                            With GetNextSentence
                                ReDim .RawBytes(0 To Len(sTemp) - 1)
                                'If Not aBuffer Is Nothing Then
                                '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                'End If
                                .RawMessage = sTemp
                                .MessageType = nMessageType
                                oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_ArduPilotLegacy) = Now.Ticks
                                .Header = ""
                                .Packet = sTemp
                                .PacketLength = Len(.Packet)
                                .VisibleSentence = "AP Waypoint Count - " & sTemp
                                .ValidMessage = True
                            End With
                        End If

                    Case cMessage.e_MessageType.e_MessageType_SiRF
                        sHeaderCharacters = Chr(&HA0) & Chr(&HA2)
                        sFooterCharacters = Chr(&HB0) & Chr(&HB3)
                        If Len(Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters))) >= 5 Then
                            nPacketSize = Asc(Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters) + 3, 1))
                            If Len(Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters))) >= nPacketSize + 8 Then
                                nLastStart = NewInstr(sBuffer, sHeaderCharacters)
                                sTemp = Mid(sBuffer, nLastStart, nPacketSize + 8)
                                sOutput = ""
                                If bShowBinary = True Then
                                    For nCount = 1 To Len(sTemp)
                                        sOutput = sOutput & Hex(Asc(Mid(sTemp, nCount, 1))).PadLeft(2, "0") & " "
                                    Next
                                Else
                                    sOutput = "{Binary Message}"
                                End If
                                'Debug.Print(sOutput)
                                With GetNextSentence
                                    ReDim .RawBytes(0 To Len(sTemp) - 1)
                                    'If Not aBuffer Is Nothing Then
                                    '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                    'End If
                                    .RawMessage = sTemp
                                    .MessageType = nMessageType
                                    .Header = "SiRF"
                                    .ID = Asc(Mid(sTemp, 4, 1))
                                    .Packet = Mid(sTemp, 5, nPacketSize)
                                    .PacketLength = nPacketSize
                                    .Checksum = Mid(sTemp, Len(sHeaderCharacters) + 3 + nPacketSize, 2)
                                    .VisibleSentence = .Header & " - " & sOutput
                                    If .Checksum = GetSiRFChecksum(.Packet) Then
                                        .ValidMessage = True
                                        oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_SiRF) = Now.Ticks
                                        Try
                                            If .ID = 91 Then
                                                .GPSDateTime = CDate(GetNMEADate(Asc(Mid(.Packet, 15, 1)).ToString("00") & Asc(Mid(.Packet, 14, 1)).ToString("00") & Microsoft.VisualBasic.Right(ConvertHexToDec(Mid(.Packet, 12, 2), False), 2)) & " " & GetNMEATime(Asc(Mid(.Packet, 16, 1)).ToString("00") & Asc(Mid(.Packet, 17, 1)).ToString("00") & Asc(Mid(.Packet, 18, 1)).ToString("00")))
                                                .ValidDateTime = True
                                            End If
                                        Catch
                                        End Try
                                    Else
                                        .ValidMessage = False
                                    End If
                                End With
                            End If
                        End If

                    Case cMessage.e_MessageType.e_MessageType_FY21AP
                        sHeaderCharacters = Chr(&HA5) & Chr(&H5A)
                        sFooterCharacters = Chr(&HAA)
                        If Len(Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters))) >= 3 Then
                            nPacketSize = Asc(Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters) + 2, 1))
                            If Len(Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters))) >= nPacketSize + 2 And nPacketSize <> 0 Then
                                nLastStart = NewInstr(sBuffer, sHeaderCharacters)
                                sTemp = Mid(sBuffer, nLastStart, nPacketSize + 2)
                                sOutput = ""
                                If bShowBinary = True Then
                                    For nCount = 1 To Len(sTemp)
                                        sOutput = sOutput & Hex(Asc(Mid(sTemp, nCount, 1))).PadLeft(2, "0") & " "
                                    Next
                                Else
                                    sOutput = "{Binary Message}"
                                End If
                                'Debug.Print(sOutput)
                                With GetNextSentence
                                    ReDim .RawBytes(0 To Len(sTemp) - 1)
                                    'If Not aBuffer Is Nothing Then
                                    '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                    'End If
                                    .RawMessage = sTemp
                                    .MessageType = nMessageType
                                    .Header = "FY21AP"
                                    .Packet = Mid(sTemp, 3, nPacketSize - 2)
                                    .PacketLength = Len(.Packet)
                                    .ID = Asc(Mid(.Packet, 2, 1))
                                    .Checksum = Mid(sTemp, Len(sTemp) - 1, 1)
                                    .VisibleSentence = .Header & " - " & Trim(sOutput)
                                    If .Checksum = GetFY21APChecksum(.Packet) Then
                                        .ValidMessage = True
                                        oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_FY21AP) = Now.Ticks
                                        Try
                                            If .ID = 242 Then
                                                dLocalDate = GetNMEADate(Asc(Mid(.Packet, 33, 1)).ToString("00") & Asc(Mid(.Packet, 32, 1)).ToString("00") & Asc(Mid(.Packet, 34, 1)).ToString("00"))
                                                dLocalTime = GetNMEATime(Asc(Mid(.Packet, 29, 1)).ToString("00") & Asc(Mid(.Packet, 30, 1)).ToString("00") & Asc(Mid(.Packet, 31, 1)).ToString("00"))
                                                If dLocalDate <> "12:00 AM" And dLocalTime <> "12:00 AM" Then
                                                    .GPSDateTime = CDate(dLocalDate & " " & dLocalTime)
                                                    .ValidDateTime = True
                                                Else
                                                    .ValidDateTime = False
                                                End If
                                            End If
                                        Catch
                                        End Try
                                    Else
                                        .ValidMessage = False
                                    End If
                                End With
                            End If
                        End If

                    Case cMessage.e_MessageType.e_MessageType_MediaTekv16
                        sHeaderCharacters = Chr(&HD0) & Chr(&HDD)
                        If Len(Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters))) >= 37 Then
                            With GetNextSentence
                                nPacketSize = 32
                                .MessageType = nMessageType
                                .Header = "MTK v1.6"
                                nSizeOffset = 5

                                nLastStart = NewInstr(sBuffer, sHeaderCharacters)
                                sTemp = Mid(sBuffer, nLastStart, nPacketSize + nSizeOffset)
                                sOutput = ""
                                If bShowBinary = True Then
                                    For nCount = 1 To Len(sTemp)
                                        sOutput = sOutput & Hex(Asc(Mid(sTemp, nCount, 1))).PadLeft(2, "0") & " "
                                    Next
                                Else
                                    sOutput = "{Binary Message}"
                                End If
                                With GetNextSentence
                                    ReDim .RawBytes(0 To Len(sTemp) - 1)
                                    Dim aChecksumBytes() As Byte
                                    'If Not aBuffer Is Nothing Then
                                    '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                    'End If
                                    .RawMessage = sTemp
                                    .Packet = Mid(sTemp, 3, Len(sTemp) - 4)
                                    .PacketLength = Len(.Packet)
                                    .Checksum = Strings.Right(sTemp, 2)
                                    .VisibleSentence = .Header & " - " & sOutput

                                    aChecksumBytes = GetuBloxChecksumByte(.Packet)
                                    'If .Checksum = GetuBloxChecksum(.Packet) Then
                                    If aChecksumBytes(0) = Asc(Mid(GetNextSentence.Checksum, 1, 1)) And aChecksumBytes(1) = Asc(Mid(GetNextSentence.Checksum, 2, 1)) Then

                                        .ValidMessage = True
                                        oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_Mediatek) = Now.Ticks
                                        Try
                                            'Debug.Print(.Packet)
                                            .GPSDateTime = CDate(GetMediaTekv16Date(ConvertHexToDec(Mid(.Packet, 24, 4), True)) & " " & GetMediaTekv16Time(Convert.ToInt32(ConvertHexToDec(Mid(.Packet, 28, 4), True))))
                                            .ValidDateTime = True
                                        Catch
                                        End Try
                                    Else
                                        .ValidMessage = False
                                    End If
                                End With
                            End With
                        End If

                    Case cMessage.e_MessageType.e_MessageType_uBlox
                        sHeaderCharacters = Chr(&HB5) & Chr(&H62)
                        If Len(Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters))) > 4 Then
                            With GetNextSentence
                                If Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters) + 2, 2) <> Chr("&H1") & Chr("&H5") Then
                                    nPacketSize = Asc(Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters) + 4, 1))
                                    .MessageType = cMessage.e_MessageType.e_MessageType_uBlox
                                    .Header = "uBlox"
                                    nSizeOffset = 8
                                Else
                                    nPacketSize = 28
                                    .MessageType = cMessage.e_MessageType.e_MessageType_MediaTek
                                    .Header = "MTK"
                                    nSizeOffset = 4
                                End If
                                If Len(Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters))) >= nPacketSize + nSizeOffset Then
                                    nLastStart = NewInstr(sBuffer, sHeaderCharacters)
                                    sTemp = Mid(sBuffer, nLastStart, nPacketSize + nSizeOffset)
                                    sOutput = ""
                                    If bShowBinary = True Then
                                        For nCount = 1 To Len(sTemp)
                                            sOutput = sOutput & Hex(Asc(Mid(sTemp, nCount, 1))).PadLeft(2, "0") & " "
                                        Next
                                    Else
                                        sOutput = "{Binary Message}"
                                    End If
                                    With GetNextSentence
                                        ReDim .RawBytes(0 To Len(sTemp) - 1)
                                        'If Not aBuffer Is Nothing Then
                                        '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                        'End If
                                        .RawMessage = sTemp
                                        .ID = Asc(Mid(sTemp, 4, 1))
                                        .Packet = Mid(sTemp, 3, Len(sTemp) - 4)
                                        .PacketLength = Len(.Packet)
                                        .Checksum = Strings.Right(sTemp, 2)
                                        .VisibleSentence = .Header & " - " & sOutput
                                        If .Checksum = GetuBloxChecksum(.Packet) Then
                                            .ValidMessage = True
                                            If .MessageType = cMessage.e_MessageType.e_MessageType_uBlox Then
                                                oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_uBlox) = Now.Ticks
                                            ElseIf .MessageType = cMessage.e_MessageType.e_MessageType_MediaTek Then
                                                oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_Mediatek) = Now.Ticks
                                            End If
                                            Try
                                                Select Case Asc(Mid(.Packet, 2, 1))
                                                    Case 2, 3, 4, 18
                                                        .GPSDateTime = GetuBloxTime(ConvertHexToDec(Mid(.Packet, 5, 4)) / 1000)
                                                        .ValidDateTime = True
                                                    Case 6
                                                        .GPSDateTime = CDate(GetuBloxDate(ConvertHexToDec(Mid(.Packet, 13, 2))) & " " & GetuBloxTime(ConvertHexToDec(Mid(.Packet, 5, 4)) / 1000))
                                                        .ValidDateTime = True
                                                End Select
                                            Catch
                                            End Try
                                        Else
                                            .ValidMessage = False
                                        End If
                                    End With
                                Else
                                    .ValidMessage = False
                                    'System.Diagnostics.Debug.Print("Len=" & Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) & ",PacketSize=" & nPacketSize)
                                End If
                            End With
                        End If

                    Case cMessage.e_MessageType.e_MessageType_ArduPilotMega_Binary
                        sHeaderCharacters = "4D"
                        If Len(Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters))) > 4 Then
                            With GetNextSentence
                                nPacketSize = Asc(Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters) + 2, 1)) + 2
                                .MessageType = nMessageType
                                .Header = "AP Mega"
                                nSizeOffset = 5
                                If Len(Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters))) >= nPacketSize + nSizeOffset Then
                                    nLastStart = NewInstr(sBuffer, sHeaderCharacters)
                                    sTemp = Mid(sBuffer, nLastStart, nPacketSize + nSizeOffset)
                                    sOutput = ""
                                    If bShowBinary = True Then
                                        For nCount = 1 To Len(sTemp)
                                            sOutput = sOutput & Hex(Asc(Mid(sTemp, nCount, 1))).PadLeft(2, "0") & " "
                                        Next
                                    Else
                                        sOutput = "{Binary Message}"
                                    End If
                                    With GetNextSentence
                                        ReDim .RawBytes(0 To Len(sTemp) - 1)
                                        'If Not aBuffer Is Nothing Then
                                        '    Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                        'End If
                                        .RawMessage = sTemp
                                        .ID = Asc(Mid(sTemp, 4, 1))
                                        .Packet = Mid(sTemp, 3, Len(sTemp) - 4)
                                        .PacketLength = Len(.Packet)
                                        .Checksum = Strings.Right(sTemp, 2)
                                        .VisibleSentence = .Header & " - " & Trim(sOutput)
                                        If .Checksum = GetuBloxChecksum(.Packet) Then
                                            .ValidMessage = True
                                            oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_ArduPilotMega) = Now.Ticks
                                        Else
                                            .ValidMessage = False
                                        End If
                                    End With
                                Else
                                    .ValidMessage = False
                                    'System.Diagnostics.Debug.Print("Len=" & Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) & ",PacketSize=" & nPacketSize)
                                End If
                            End With
                        End If

                    Case cMessage.e_MessageType.e_MessageType_MAV
                        sHeaderCharacters = Chr(85)
                        If Len(Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters))) > 1 Then
                            With GetNextSentence
                                nPacketSize = Asc(Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters) + 1, 1)) + 2
                                .MessageType = nMessageType
                                .Header = "MAVlink"
                                nSizeOffset = 6
                                If Len(Mid(sBuffer, NewInstr(sBuffer, sHeaderCharacters))) > nPacketSize + nSizeOffset Then
                                    nLastStart = NewInstr(sBuffer, sHeaderCharacters)
                                    sTemp = Mid(sBuffer, nLastStart, nPacketSize + nSizeOffset)
                                    sOutput = ""
                                    If bShowBinary = True Then
                                        For nCount = 0 To Len(sTemp) - 1
                                            'If Not aBuffer Is Nothing Then
                                            'sOutput = sOutput & Hex(aBuffer(nCount)).PadLeft(2, "0") & " "
                                            '    Else
                                            sOutput = sOutput & Hex(Asc(Mid(sTemp, nCount + 1, 1))).PadLeft(2, "0") & " "
                                            '    End If
                                        Next
                                        If Asc(Mid(sTemp, 6, 1)) = 39 Or Asc(Mid(sTemp, 6, 1)) = 44 Or Asc(Mid(sTemp, 6, 1)) = 40 Or Asc(Mid(sTemp, 6, 1)) = 43 Or Asc(Mid(sTemp, 6, 1)) = 47 Then
                                            Debug.Print(Now & ":IN =" & sOutput)
                                        End If
                                    Else
                                        sOutput = "{Binary Message}"
                                    End If
                                    With GetNextSentence

                                        'If Not aBuffer Is Nothing Then
                                        '    If nLastStart + Len(sTemp) - 2 + Len(sBuffer) > UBound(aBuffer) Then
                                        '        ReDim .RawBytes(0 To UBound(aBuffer))
                                        '        Array.ConstrainedCopy(aBuffer, 0, .RawBytes, 0, UBound(aBuffer))
                                        '    Else
                                        '        ReDim .RawBytes(0 To Len(sTemp) - 1)
                                        '        Array.ConstrainedCopy(aBuffer, nLastStart + Len(sTemp) - 1, .RawBytes, 0, Len(sTemp))
                                        '    End If
                                        'End If

                                        'Array.ConstrainedCopy(aBuffer, nLastStart - 1, .RawBytes, 0, Len(sTemp))
                                        .RawMessage = sTemp
                                        .VehicleID = Asc(Mid(sTemp, 4, 1))
                                        '.ID = .RawBytes(5)
                                        'Debug.Print("Index = " & Hex(.RawBytes(2)))
                                        .ID = Asc(Mid(sTemp, 6, 1))
                                        .Packet = Mid(sTemp, 1, Len(sTemp) - 2)
                                        .PacketLength = Len(.Packet)
                                        .Checksum = sTemp.Substring(Len(sTemp) - 2) 'Strings.Right(sTemp, 2)
                                        .VisibleSentence = .Header & " - " & Trim(sOutput)

                                        Dim nChecksumLong As Long
                                        Dim nChecksumLong2 As Long
                                        Dim aChecksumBytes() As Byte
                                        Dim sChecksumString As String

                                        'nChecksumLong = (((Convert.ToInt32(.RawBytes(.RawBytes(nLastStart) + 7))) << 8) + Convert.ToInt32(.RawBytes(.RawBytes(nLastStart) + 6)))
                                        ''If .RawBytes(2) = 209 Then
                                        ''    aChecksumBytes = crc_calculate_byte(.RawBytes, True)
                                        ''Else
                                        aChecksumBytes = crc_calculate_byte2(.Packet)
                                        ''End If
                                        'sChecksumString = crc_calculate(.Packet)
                                        'nChecksumLong2 = crc_calculate_long(.RawBytes)

                                        'Debug.Print(".checksum=" & Hex(Asc(Mid(.Checksum, 1, 1))).PadLeft(2, "0") & Hex(Asc(Mid(.Checksum, 2, 1))).PadLeft(2, "0"))
                                        'If nChecksumLong = nChecksumLong2 Then 'Or .Checksum = sChecksumString Then
                                        'If .Checksum = crc_calculate(.Packet) Then
                                        'If Asc(Mid(sChecksumString, 2, 1)) = Asc(Mid(.Checksum, 2, 1)) Or Asc(Mid(sChecksumString, 1, 1)) = Asc(Mid(.Checksum, 1, 1)) Then
                                        'If sChecksumString = .Checksum Then
                                        If aChecksumBytes(0) = Asc(Mid(GetNextSentence.Checksum, 2, 1)) And aChecksumBytes(1) = Asc(Mid(GetNextSentence.Checksum, 1, 1)) Then
                                            'If .RawBytes(nLastStart + Len(sTemp) - 3) = aChecksumBytes(0) Then 'And .RawBytes(nLastStart + Len(sTemp) - 2) = aChecksumBytes(1) Then
                                            .ValidMessage = True
                                            oActiveDevices.dLastDeviceTime(e_DeviceTypes.e_DeviceTypes_MavLink) = Now.Ticks
                                            'Debug.Print("Valid: Calc Checksum=" & Hex(aChecksumBytes(0)) & " " & Hex(aChecksumBytes(1)) & ", MAV=" & sOutput)
                                            Try
                                                Select Case .ID
                                                    Case 2, 28, 30, 32, 33
                                                        '.GPSDateTime = CDate(GetMAVlinkTime(ConvertMavlinkToLong(Mid(.Packet, 7, 8))) & " " & GetMAVlinkTime(ConvertMavlinkToLong(Mid(.Packet, 7, 8))))
                                                        'fix this!!!!
                                                        .ValidDateTime = True
                                                End Select
                                            Catch
                                            End Try
                                        Else
                                            Debug.Print("Invalid Count = " & nInvalidCount & ", MAV=" & sOutput)
                                            nInvalidCount = nInvalidCount + 1
                                            .ValidMessage = False
                                        End If
                                    End With
                                Else
                                    .ValidMessage = False
                                    'System.Diagnostics.Debug.Print("Len=" & Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) & ",PacketSize=" & nPacketSize)
                                End If
                            End With
                        End If
                End Select
            End If
        Catch e2 As Exception
            'System.Diagnostics.Debug.Assert(False)
            System.Diagnostics.Debug.Print("GetNextSentence - " & e2.Message)
        End Try

        Try
            Dim aNewArray() As Byte
            If GetNextSentence.Packet <> "" Then
                'Do While Asc(Mid(sBuffer, 1, 1)) = 10 Or Asc(Mid(sBuffer, 1, 1)) = 13
                '    sBuffer = Mid(sBuffer, 2)
                '    nLastStart = nLastStart - 1
                'Loop
                If nLastStart <> 1 Then
                    'If InStr(Mid(sBuffer, 1, nLastStart), vbCr) <> 0 Then
                    '    Do While InStr(Mid(sBuffer, 1, nLastStart), vbCr) <> 0
                    '        frmMain.UpdateSerialDataWindow("", "Unknown Message:" & Mid(sBuffer, 1, InStr(Mid(sBuffer, 1, nLastStart), vbCr) - 1))
                    '        sBuffer = Mid(sBuffer, InStr(Mid(sBuffer, 1, nLastStart), vbCr))
                    '    Loop
                    'Else
                    frmMain.UpdateSerialDataWindow("", "Unknown Message:" & Mid(sBuffer, 1, nLastStart - 1))
                    'End If
                End If
                sBuffer = Mid(sBuffer, nLastStart + Len(sTemp))

                'ReDim aNewArray(0 To Len(sBuffer) - 1)
                'If Len(sBuffer) > 0 Then
                '    'If nLastStart + Len(sTemp) - 2 + Len(sBuffer) > UBound(aBuffer) Then
                '    '    Array.ConstrainedCopy(aBuffer, UBound(aBuffer) - Len(sBuffer) + 1, aNewArray, 0, Len(sBuffer))
                '    'Else
                '    If Not aBuffer Is Nothing Then
                '        Array.ConstrainedCopy(aBuffer, nLastStart + Len(sTemp) - 1, aNewArray, 0, Len(sBuffer))
                '        'End If
                '        ReDim aBuffer(0 To UBound(aNewArray))
                '        Array.Copy(aNewArray, aBuffer, UBound(aNewArray))
                '    End If
                'Else
                '    aBuffer = Nothing
                'End If

                Do While Strings.Left(sBuffer, 1) = vbCrLf Or Strings.Left(sBuffer, 1) = vbCr Or Strings.Left(sBuffer, 1) = vbLf
                    sBuffer = Mid(sBuffer, 2)
                    'If Len(sBuffer) > 0 And Not aBuffer Is Nothing Then
                    '    ReDim aNewArray(0 To Len(sBuffer) - 1)
                    '    Array.ConstrainedCopy(aBuffer, 1, aNewArray, 0, Len(sBuffer))
                    '    ReDim aBuffer(0 To UBound(aNewArray))
                    '    Array.Copy(aNewArray, aBuffer, UBound(aNewArray))
                    'Else
                    '    aBuffer = Nothing
                    'End If
                Loop
            End If
            If Len(sBuffer) > 2000 Then
                frmMain.UpdateSerialDataWindow("", "Unknown Message:" & Mid(sBuffer, 1, 500))
                sBuffer = Mid(sBuffer, 501)
                'If Len(sBuffer) > 0 Then
                '    ReDim aNewArray(0 To Len(sBuffer) - 1)
                '    'If 500 + Len(sBuffer) > UBound(aBuffer) Then
                '    If Not aBuffer Is Nothing Then
                '        Array.ConstrainedCopy(aBuffer, 500, aNewArray, 0, Len(sBuffer))
                '        'Else
                '        '    Array.ConstrainedCopy(aBuffer, nLastStart + Len(sTemp) - 1, aNewArray, 0, Len(sBuffer))
                '        'End If

                '        'Array.ConstrainedCopy(aBuffer, 500, aNewArray, 0, Len(sBuffer))
                '        ReDim aBuffer(0 To UBound(aNewArray))
                '        Array.Copy(aNewArray, aBuffer, UBound(aNewArray))
                '    End If
                'Else
                '    aBuffer = Nothing
                'End If
                'System.Diagnostics.Debug.Assert(False)
                'System.Diagnostics.Debug.Print("GetNextSentence - Packet Empty")
            End If
            If Len(sBuffer) > 0 Then
                'Debug.Print("First String = " & Asc(Mid(sBuffer, 1, 1)) & ", First Byte = " & aBuffer(0))
            End If
        Catch ex As Exception
        End Try

    End Function
    Public Function NewInstr(ByVal strSearch As String, ByVal strWhat As String) As Integer
        '
        ' This function searches for the character strWhat in the string
        ' strSearch. It uses the ASCII value of strWhat, and therefore is
        ' not subject to Microsoft Access translation of special characters
        ' and ligatures. It returns the integer position of the strWhat in
        ' strSearch. It returns 0 if either strSearch or strWhat is empty,
        ' or if strWhat cannot be found.
        '
        ' Note: If strWhat contains more than one character, only the first
        ' character is searched for.

        Dim iLen As Integer, i As Integer
        Dim iRetVal As Integer

        If Trim(strSearch) = "" Or Trim(strWhat) = "" Then
            iRetVal = 0
        Else
            iRetVal = 0
            iLen = Len(strSearch)
            i = 1
            Do
                If Asc(Mid(strSearch, i, 1)) = Asc(strWhat) Then
                    iRetVal = i
                End If
                i = i + 1
            Loop While iRetVal = 0 And i <= iLen
        End If
        NewInstr = iRetVal

    End Function

    Public Function AddCharacter(ByVal inputIndex As Int32) As String
        'If inputIndex = 156 Then
        '    AddCharacter = System.Convert.ToChar(347)
        If inputIndex >= 128 And inputIndex <= 159 Then     '&H80<=indata<=&H9F
            AddCharacter = Chr(inputIndex)
        Else
            AddCharacter = ChrW(inputIndex)
        End If
    End Function
    '    unsigned short crc16(data_p, length)
    'char *data_p;
    'unsigned short length;
    '{
    '       unsigned char i;
    '       unsigned int data;
    '       unsigned int crc;

    '       crc = 0xffff;

    '       if (length == 0)
    '              return (~crc);

    '       do {
    '              for (i = 0 data = (unsigned int)0xff & *data_p++;i < 8;i++, data >>= 1) {
    '                    if ((crc & 0x0001) ^ (data & 0x0001))
    '                           crc = (crc >> 1) ^ POLY;
    '                    else
    '                           crc >>= 1;
    '              }
    '       } 
    'while (--length);

    '       crc = ~crc;

    '       data = crc;
    '       crc = (crc << 8) | (data >> 8 & 0xFF);

    '       return (crc);
    '}

    Public Function CRC16A(ByVal packet As String) As String
        Dim I As Long
        Dim Temp As Long
        Dim CRC As Long
        Dim J As Integer
        Dim sTemp As String
        For I = 1 To Len(packet)
            Temp = Asc("&h" & Mid(packet, I, 1)) * &H100&
            CRC = CRC Xor Temp
            For J = 0 To 7
                If (CRC And &H8000&) Then
                    CRC = ((CRC * 2) Xor &H1021&) And &HFFFF&
                Else
                    CRC = (CRC * 2) And &HFFFF&
                End If
            Next J
        Next I
        sTemp = Hex(CRC And &HFFFF).PadLeft(4, "0")
        CRC16A = AddCharacter("&h" & Mid(sTemp, 1, 2)) & AddCharacter("&h" & Mid(sTemp, 3, 2))
    End Function
    Public Function GetSystemColor(ByVal inputString As String) As System.Drawing.Color
        GetSystemColor = Color.FromArgb(255, (Convert.ToInt32(Mid(inputString, 1, 2), 16)), (Convert.ToInt32(Mid(inputString, 3, 2), 16)), (Convert.ToInt32(Mid(inputString, 5, 2), 16)))
    End Function

    Public Function GetFileContents(ByVal FullPath As String, Optional ByRef ErrInfo As String = "") As String

        Dim strContents As String
        Dim objReader As StreamReader

        If Dir(FullPath, FileAttribute.Normal) <> "" Then
            Try

                objReader = New StreamReader(FullPath)
                strContents = objReader.ReadToEnd()
                objReader.Close()
                Return strContents
            Catch Ex As Exception
                ErrInfo = Ex.Message
            End Try
        End If
    End Function
    Public Function GetRootPath() As String
        GetRootPath = Mid(Application.ExecutablePath, 1, InStrRev(Application.ExecutablePath, "\"))
    End Function
    Public ReadOnly Property Version() As String
        Get
            Dim sTemp As String
            sTemp = Trim(System.Reflection.Assembly.GetExecutingAssembly.FullName.Split(",")(1).Replace("Version=", ""))
            Return "v" & Mid(sTemp, 1, InStrRev(sTemp, ".") - 1) '& " - Build " & Mid(sTemp, InStrRev(sTemp, ".") + 1)


            'Return Application.ProductVersion.ToString()
            'Dim myBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(GetRootPath)
            'Return myBuildInfo.ProductVersion
        End Get

    End Property

    Public Function GetHeading(ByVal inputValue As Single) As Single
        If bHeadingReverse = True Then
            GetHeading = inputValue - 180
            If GetHeading < 0 Then
                GetHeading = GetHeading + 360
            End If
        Else
            GetHeading = inputValue
        End If
        If GetHeading < 0 Then
            GetHeading = GetHeading + 360
        ElseIf GetHeading >= 360 Then
            GetHeading = GetHeading - 360
        End If
    End Function
    Public Function GetYaw(ByVal inputValue As Single) As Single
        inputValue = inputValue - nYawOffset
        If bYawReverse = True Then
            GetYaw = inputValue - 180
            If GetYaw < 0 Then
                GetYaw = GetYaw + 360
            End If
        Else
            GetYaw = inputValue
        End If
        If GetYaw < 0 Then
            GetYaw = GetYaw + 360
        ElseIf GetYaw >= 360 Then
            GetYaw = GetYaw - 360
        End If
    End Function
    Public Function GetPitch(ByVal inputValue As Single) As Single
        If bPitchReverse = True Then
            GetPitch = inputValue * -1
        Else
            GetPitch = inputValue
        End If
    End Function
    Public Function GetRoll(ByVal inputValue As Single) As Single
        If bRollReverse = True Then
            GetRoll = inputValue * -1
        Else
            GetRoll = inputValue
        End If
    End Function
    Public Function ConvertSpeech(ByVal inputString As String) As String
        Dim nNewAlt As Single
        Dim sUnits As String

        nNewAlt = nAltitude - nHomeAltIndicator
        If nNewAlt < 0 Then
            nNewAlt = 0
        End If
        ConvertSpeech = inputString
        If nWaypoint = 0 And nConfigDevice <> e_ConfigDevice.e_ConfigDevice_AttoPilot Then
            ConvertSpeech = Replace(ConvertSpeech, "{wpn}", "home")
        Else
            ConvertSpeech = Replace(ConvertSpeech, "{wpn}", nWaypoint)
        End If
        ConvertSpeech = Replace(ConvertSpeech, "{asp}", Convert.ToSingle(nAirSpeed).ToString("0"))
        ConvertSpeech = Replace(ConvertSpeech, "{gsp}", Convert.ToSingle(nGroundSpeed).ToString("0"))
        ConvertSpeech = Replace(ConvertSpeech, "{mode}", sMode)
        ConvertSpeech = Replace(ConvertSpeech, "{alt}", Convert.ToSingle(nNewAlt).ToString("0"))
        ConvertSpeech = Replace(ConvertSpeech, "{wpa}", Convert.ToSingle(nWaypointAlt).ToString("0"))
        ConvertSpeech = Replace(ConvertSpeech, "{alarm}", Convert.ToInt32(nAlarmTimeout).ToString("0"))
        ConvertSpeech = Replace(ConvertSpeech, "{warning}", Convert.ToInt32(nWarningTimeout).ToString("0"))
        ConvertSpeech = Replace(ConvertSpeech, "{speed_units}", GetSpeedUnitsText)
        ConvertSpeech = Replace(ConvertSpeech, "{distance_units}", GetDistanceUnitsText)

    End Function
    Public Function LoadLanguageFile()
        If sLanguageFile = "Default" Then
            oCulture = System.Globalization.CultureInfo.CurrentCulture
        Else
            oCulture = CultureInfo.CreateSpecificCulture(sLanguageFile)
        End If
        resourceMgr = ResourceManager.CreateFileBasedResourceManager("Strings", GetRootPath() & "Language", Nothing)
    End Function
    Public Function GetTrackingHeadingAngle(ByVal homeLat As String, ByVal homeLong As String, ByVal homealt As String, ByVal locationLat As Double, ByVal locationLong As Double, ByVal locationAlt As Single, ByVal headingOffset As Integer, ByVal speed As Single, ByVal heading As Single, ByRef newHeading As Single, ByRef newAngle As Single) As Boolean
        Dim R As Long = 6371
        Dim dLat As Double
        Dim dLon As Double
        Dim a As Double
        Dim c As Double
        Dim d As Double
        Dim x As Double
        Dim y As Double
        Dim nLocalHomeLat As Double
        Dim nLocalHomeLong As Double
        Dim nLocalHomeAlt As Single

        GetTrackingHeadingAngle = True

        If homeLat = "" Or homeLong = "" Or homealt = "" Then
            GetTrackingHeadingAngle = False
            Exit Function
        ElseIf homeLat = "0" Or homeLong = "0" Then
            GetTrackingHeadingAngle = False
            Exit Function
        End If


        Try
            nLocalHomeLat = Convert.ToDouble(homeLat)
            nLocalHomeLong = Convert.ToDouble(homeLong)
            nLocalHomeAlt = Convert.ToSingle(homealt)

            dLat = (locationLat - nLocalHomeLat) * pi / 180
            dLon = (locationLong - nLocalHomeLong) * pi / 180

            a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(nLocalHomeLat * pi / 180) * Math.Cos(locationLat * pi / 180) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
            c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a))
            d = R * c

            y = Math.Sin(dLon) * Math.Cos(locationLat * pi / 180)
            x = Math.Cos(nLocalHomeLat * pi / 180) * Math.Sin(locationLat * pi / 180) - Math.Sin(nLocalHomeLat * pi / 180) * Math.Cos(locationLat * pi / 180) * Math.Cos(dLon)
            newHeading = Math.Atan2(y, x) * 180 / pi
            newHeading = newHeading - headingOffset
            If newHeading >= 360 Then
                newHeading = newHeading - 360
            ElseIf newHeading < 0 Then
                newHeading = newHeading + 360
            End If

            'Debug.WriteLine("Heading=" & heading)
            newAngle = Math.Atan((locationAlt - nLocalHomeAlt) / (d * 1000)) * 180 / pi
            If newAngle.IsNaN(newAngle) = True Then
                newAngle = 0
            End If
        Catch
            GetTrackingHeadingAngle = False
        End Try
    End Function
    Public Function NormalizeHeading(ByVal inputValue As Single) As Single
        If inputValue >= 180 Then
            NormalizeHeading = inputValue - 360
        ElseIf inputValue < -180 Then
            NormalizeHeading = 360 - inputValue
        Else
            NormalizeHeading = inputValue
        End If
    End Function
    Public Function GetPololuValue(ByVal inputValue As Long) As String
        Dim sLower As String
        Dim nUpper As Long
        Dim sUpper As String

        sLower = Chr(inputValue And &H7F)
        nUpper = inputValue And &HFF80
        nUpper = nUpper >> 7
        nUpper = nUpper And &H7F
        sUpper = Chr(nUpper)

        GetPololuValue = sUpper & sLower
    End Function
    Public Function ConstrainJoystick(ByVal inputValue As Integer, ByVal outputLowerContraint As Long, ByVal outputUpperContraint As Long) As Integer
        Dim nPct As Single
        Dim nMidPoint As Single
        Dim nHalfRange As Single

        nHalfRange = (outputUpperContraint - outputLowerContraint) / 2
        nMidPoint = nHalfRange + outputLowerContraint

        If inputValue > 0 Then
            nPct = inputValue / 1000
            ConstrainJoystick = nMidPoint + (nHalfRange * nPct)
        ElseIf inputValue < 0 Then
            nPct = inputValue / -1000
            ConstrainJoystick = nMidPoint - (nHalfRange * nPct)
        Else
            ConstrainJoystick = nMidPoint
        End If

        'nPct = (inputValue - lowerBound) / (upperBound - lowerBound)

        'nPct = inputValue / 65535
        'ConstrainJoystick = (maxValue - minValue) * nPct + minValue
    End Function
    Public Function GetJoystickValue(ByVal jstInput As JoystickInterface.Joystick, ByVal channelIndex As Integer, ByVal channelAxis As Integer, ByVal lowerBound As Long, ByVal upperBound As Long, ByVal subTrim As Long, ByVal reversed As Boolean, ByRef joystickCurrent As Long, ByRef sliderValue As Long, ByRef outputValue As Long) As Boolean

        Dim bEnabled As Boolean
        Dim nAxis As Integer
        Dim nValue As Integer
        'Dim nMin As Integer
        'Dim nMax As Integer
        'Dim nLower As Integer
        'Dim nUpper As Integer
        'Dim bReversed As Boolean
        'Dim nSubTrim As Integer

        Dim nReadValue As Long
        Dim nTemp As Long
        Dim nPct As Single

        'Dim nLowerBound As Integer
        'Dim nUpperBound As Integer

        bEnabled = IIf(channelAxis = -1, False, True)

        If bEnabled = True Then
            'If jstInput.UpdateStatus = True Then
            nReadValue = jstInput.Axis(channelAxis)
            joystickCurrent = nReadValue

            nTemp = nReadValue

            If reversed = True Then
                nTemp = nTemp - subTrim
            Else
                nTemp = nTemp + subTrim
            End If

            If nTemp > 32768 Then
                nTemp = 32768
            ElseIf nTemp < -32767 Then
                nTemp = -32767
            End If

            If nTemp > 0 Then
                nPct = nTemp / 32768
                sliderValue = IIf(reversed = True, -lowerBound, upperBound) * nPct
            ElseIf nTemp < 0 Then
                nPct = nTemp / -32767
                sliderValue = IIf(reversed = True, -upperBound, lowerBound) * nPct
            Else
                sliderValue = 0
            End If

            If reversed = True Then
                sliderValue = -sliderValue
            End If

            'If nTemp > channelMax Then
            '    nTemp = channelMax
            'ElseIf nTemp < channelMin Then
            '    nTemp = channelMin
            'End If

            'sliderValue = nTemp

            'If nTemp > 0 Then
            '    nPct = nTemp / (channelMax - 32767)
            '    sliderValue = (nTemp * nPct)
            '    nPct = nTemp / (channelUpper - 32767)
            '    outputValue = 32767 + (nTemp * nPct)
            'ElseIf nTemp < 0 Then
            '    nPct = nTemp / (channelMin - 32767)
            '    sliderValue = nTemp
            '    nPct = nTemp / (channelLower - 32767)
            '    outputValue = 32767 - (32767 * nPct)
            'Else
            '    sliderValue = nTemp
            '    outputValue = (nTemp / (channelUpper - channelLower)) * (channelMin - channelMax)
            'End If

            'If Convert.ToDouble(nPct).IsNaN(nPct) = False Then
            '    sliderValue = 32767 - (nTemp * nPct)
            'Else
            '    sliderValue = 65535 / 2
            'End If

            'If Convert.ToDouble(nPct).IsNaN(nPct) = False Then
            '    outputValue = ((nUpperBound - nLowerBound) * nPct + nLowerBound) + 32767
            'Else
            '    outputValue = (((nUpperBound - nLowerBound) / 2) + nLowerBound) + 32767
            'End If

            'cJoystick(channelIndex).CurrentValue = outputValue

            'Select Case channelType
            '    Case e_ChannelType.e_ChannelType_Throttle
            '        nJoystickThrottleNew = outputValue
            '    Case e_ChannelType.e_ChannelType_Elevator
            '        nJoystickElevatorNew = outputValue
            '        'Debug.Print(nJoystickElevatorNew & ",slider=" & sliderValue)
            '    Case e_ChannelType.e_ChannelType_Aileron
            '        nJoystickAileronNew = outputValue
            '    Case e_ChannelType.e_ChannelType_Rudder
            '        nJoystickRudderNew = outputValue
            '    Case e_ChannelType.e_ChannelType_Channel5
            '        nJoystickModeNew = outputValue
            'End Select

            GetJoystickValue = True
        Else
            GetJoystickValue = False
        End If
    End Function
    Public Function SendJoystickMessages(ByVal joystickOutputType As e_JoystickOutput)
        Dim nTimerWait As Long
        Dim sThrottle As String
        Dim sElevator As String
        Dim sAileron As String
        Dim sRudder As String
        Dim sMode As String

        Dim nCount As Integer
        Dim nCount2 As Integer

        Dim nChannels(0 To 7) As Integer

        Select Case joystickOutputType
            Case e_JoystickOutput.e_JoystickOutput_Atto
                nTimerWait = 2500000
            Case e_JoystickOutput.e_JoystickOutput_UDB, e_JoystickOutput.e_JoystickOutput_APM
                nTimerWait = 200000
            Case e_JoystickOutput.e_JoystickOutput_APM ' e_JoystickOutput.e_JoystickOutput_Pololu
                nTimerWait = 50000
            Case e_JoystickOutput.e_JoystickOutput_Millswood
                nTimerWait = 1000000
        End Select

        If bConnected = True And Now.Ticks > dLastJoystick + nTimerWait Then
            dLastJoystick = Now.Ticks
            Select Case joystickOutputType
                Case e_JoystickOutput.e_JoystickOutput_Atto
                    cJoystick(3).CurrentValue = ConstrainJoystick(cJoystick(3).SliderValue, -nMaxRollAngle * 100, nMaxRollAngle * 100)
                    If (cJoystick(3).LastPosition <> cJoystick(3).CurrentValue Or (dLastAttoAileron + 50000000) < Now.Ticks) And nMaxRollAngle > -1 Then
                        dLastAttoAileron = Now.Ticks
                        cJoystick(3).LastPosition = cJoystick(3).CurrentValue
                        frmMain.SendAttoPilot("E," & nConfigVehicle & "," & ConstrainJoystick(cJoystick(3).SliderValue, -nMaxRollAngle * 100, nMaxRollAngle * 100))
                    End If
                    cJoystick(2).CurrentValue = ConstrainJoystick(cJoystick(2).SliderValue, -nMaxPitchAngle * 100, nMaxPitchAngle * 100)
                    If (cJoystick(2).LastPosition <> cJoystick(2).CurrentValue Or (dLastAttoElevator + 50000000) < Now.Ticks) And nMaxPitchAngle > -1 Then
                        dLastAttoElevator = Now.Ticks
                        cJoystick(2).LastPosition = cJoystick(2).CurrentValue
                        frmMain.SendAttoPilot("F," & nConfigVehicle & "," & ConstrainJoystick(cJoystick(2).SliderValue, -nMaxPitchAngle * 100, nMaxPitchAngle * 100))
                    End If
                    cJoystick(1).CurrentValue = ConstrainJoystick(cJoystick(1).SliderValue, nMinThrottle, nMAxThrottle)
                    If (cJoystick(1).LastPosition <> cJoystick(1).CurrentValue Or (dLastAttoThrottle + 50000000) < Now.Ticks) And nMinThrottle > -1 And nMAxThrottle > -1 Then
                        dLastAttoThrottle = Now.Ticks
                        cJoystick(1).LastPosition = cJoystick(1).CurrentValue
                        frmMain.SendAttoPilot("H," & nConfigVehicle & "," & ConstrainJoystick(cJoystick(1).SliderValue, nMinThrottle, nMAxThrottle))
                    End If
                Case e_JoystickOutput.e_JoystickOutput_UDB
                    sThrottle = Hex(ConstrainJoystick(cJoystick(1).SliderValue, 2200, 3800)).PadLeft(4, "0")
                    sThrottle = Chr("&H" & sThrottle.Substring(0, 2)) & Chr("&H" & sThrottle.Substring(2, 2))
                    sElevator = Hex(ConstrainJoystick(cJoystick(2).SliderValue, 2200, 3800)).PadLeft(4, "0")
                    sElevator = Chr("&H" & sElevator.Substring(0, 2)) & Chr("&H" & sElevator.Substring(2, 2))
                    sAileron = Hex(ConstrainJoystick(cJoystick(3).SliderValue, 2200, 3800)).PadLeft(4, "0")
                    sAileron = Chr("&H" & sAileron.Substring(0, 2)) & Chr("&H" & sAileron.Substring(2, 2))
                    sRudder = Hex(ConstrainJoystick(cJoystick(4).SliderValue, 2200, 3800)).PadLeft(4, "0")
                    sRudder = Chr("&H" & sRudder.Substring(0, 2)) & Chr("&H" & sRudder.Substring(2, 2))
                    sMode = Hex(ConstrainJoystick(cJoystick(5).SliderValue, 2200, 3800)).PadLeft(4, "0")
                    sMode = Chr("&H" & sMode.Substring(0, 2)) & Chr("&H" & sMode.Substring(2, 2))
                    frmMain.WriteSerialIn("Joy" & sAileron & sElevator & sMode & sThrottle & sRudder & vbCrLf, True)
                Case e_JoystickOutput.e_JoystickOutput_Millswood
                    If cJoystick(1).Servo <> 0 Then
                        cJoystick(1).CurrentValue = ConstrainJoystick(cJoystick(1).SliderValue, 0, 254)
                        If cJoystick(1).LastPosition <> cJoystick(1).CurrentValue Then
                            cJoystick(1).LastPosition = cJoystick(1).CurrentValue
                            frmMain.SendAttoPilot("E,FF," & Hex(cJoystick(1).Servo - 1).PadLeft(2, "0") & "," & Hex(ConstrainJoystick(cJoystick(1).SliderValue, 0, 254)).PadLeft(2, "0"))
                        End If
                    End If
                    If cJoystick(2).Servo <> 0 Then
                        cJoystick(2).CurrentValue = ConstrainJoystick(cJoystick(2).SliderValue, 0, 254)
                        If cJoystick(2).LastPosition <> cJoystick(2).CurrentValue Then
                            cJoystick(2).LastPosition = cJoystick(2).CurrentValue
                            frmMain.SendAttoPilot("E,FF," & Hex(cJoystick(2).Servo - 1).PadLeft(2, "0") & "," & Hex(ConstrainJoystick(cJoystick(2).SliderValue, 0, 254)).PadLeft(2, "0"))
                        End If
                    End If
                    If cJoystick(3).Servo <> 0 Then
                        cJoystick(3).CurrentValue = ConstrainJoystick(cJoystick(3).SliderValue, 0, 254)
                        If cJoystick(3).LastPosition <> cJoystick(3).CurrentValue Then
                            cJoystick(3).LastPosition = cJoystick(3).CurrentValue
                            frmMain.SendAttoPilot("E,FF," & Hex(cJoystick(3).Servo - 1).PadLeft(2, "0") & "," & Hex(ConstrainJoystick(cJoystick(3).SliderValue, 0, 254)).PadLeft(2, "0"))
                        End If
                    End If
                    If cJoystick(4).Servo <> 0 Then
                        cJoystick(4).CurrentValue = ConstrainJoystick(cJoystick(4).SliderValue, 0, 254)
                        If cJoystick(4).LastPosition <> cJoystick(4).CurrentValue Then
                            cJoystick(4).LastPosition = cJoystick(4).CurrentValue
                            frmMain.SendAttoPilot("E,FF," & Hex(cJoystick(4).Servo - 1).PadLeft(2, "0") & "," & Hex(ConstrainJoystick(cJoystick(4).SliderValue, 0, 254)).PadLeft(2, "0"))
                        End If
                    End If
                    If cJoystick(5).Servo <> 0 Then
                        cJoystick(5).CurrentValue = ConstrainJoystick(cJoystick(5).SliderValue, 0, 254)
                        If cJoystick(5).LastPosition <> cJoystick(5).CurrentValue Then
                            cJoystick(5).LastPosition = cJoystick(5).CurrentValue
                            frmMain.SendAttoPilot("E,FF," & Hex(cJoystick(5).Servo - 1).PadLeft(2, "0") & "," & Hex(ConstrainJoystick(cJoystick(5).SliderValue, 0, 254)).PadLeft(2, "0"))
                        End If
                    End If
                Case e_JoystickOutput.e_JoystickOutput_APM
                    Dim nLocalThrottle As Integer
                    Dim nLocalElevator As Integer
                    Dim nLocalAileron As Integer
                    Dim nLocalRudder As Integer
                    Dim bLocalChanged As Boolean = False

                    nLocalThrottle = 65535
                    nLocalElevator = 65535
                    nLocalAileron = 65535
                    nLocalRudder = 65535

                    If cJoystick(1).Servo <> 0 Then
                        cJoystick(1).CurrentValue = ConstrainJoystick(cJoystick(1).SliderValue, 900, 2100)
                        If cJoystick(1).LastPosition <> cJoystick(1).CurrentValue Then
                            cJoystick(1).LastPosition = cJoystick(1).CurrentValue
                            bLocalChanged = True
                        End If
                    End If
                    If cJoystick(2).Servo <> 0 Then
                        cJoystick(2).CurrentValue = ConstrainJoystick(cJoystick(2).SliderValue, 900, 2100)
                        If cJoystick(2).LastPosition <> cJoystick(2).CurrentValue Then
                            cJoystick(2).LastPosition = cJoystick(2).CurrentValue
                            bLocalChanged = True
                        End If
                    End If
                    If cJoystick(3).Servo <> 0 Then
                        cJoystick(3).CurrentValue = ConstrainJoystick(cJoystick(3).SliderValue, 900, 2100)
                        If cJoystick(3).LastPosition <> cJoystick(3).CurrentValue Then
                            cJoystick(3).LastPosition = cJoystick(3).CurrentValue
                            bLocalChanged = True
                        End If
                    End If
                    If cJoystick(4).Servo <> 0 Then
                        cJoystick(4).CurrentValue = ConstrainJoystick(cJoystick(4).SliderValue, 900, 2100)
                        If cJoystick(4).LastPosition <> cJoystick(4).CurrentValue Then
                            cJoystick(4).LastPosition = cJoystick(4).CurrentValue
                            bLocalChanged = True
                        End If
                    End If

                    If bLocalChanged = True Then
                        For nCount = 0 To 7
                            nChannels(nCount) = 65535
                            For nCount2 = 1 To 8
                                If cJoystick(nCount2).Servo = nCount + 1 Then
                                    nChannels(nCount) = cJoystick(nCount2).CurrentValue
                                    Exit For
                                End If
                            Next
                        Next
                        frmMain.SendMavlinkRawServo(nChannels(0), nChannels(1), nChannels(2), nChannels(3), nChannels(4), nChannels(5), nChannels(6), nChannels(7))
                    End If

                    'Case e_JoystickOutput.e_JoystickOutput_Pololu
                    '    If nJoystickThrottleServo <> 0 Then
                    '        If nJoystickThrottlePosition <> nJoystickThrottleNew Then
                    '            nJoystickThrottlePosition = nJoystickThrottleNew
                    '            frmMain.WriteTrackingSerialPort(Chr("&h80") & Chr("&h1") & Chr("&h4") & Chr(nJoystickThrottleServo - 1) & GetPololuValue(ConstrainJoystick(nJoystickThrottlePosition, 500, 5500)), True)
                    '        End If
                    '    End If
                    '    If nJoystickElevatorServo <> 0 Then
                    '        If nJoystickElevatorPosition <> nJoystickElevatorNew Then
                    '            nJoystickElevatorPosition = nJoystickElevatorNew
                    '            frmMain.WriteTrackingSerialPort(Chr("&h80") & Chr("&h1") & Chr("&h4") & Chr(nJoystickElevatorServo - 1) & GetPololuValue(ConstrainJoystick(nJoystickElevatorPosition, 500, 5500)), True)
                    '        End If
                    '    End If
                    '    If nJoystickAileronServo <> 0 Then
                    '        If nJoystickAileronPosition <> nJoystickAileronNew Then
                    '            nJoystickAileronPosition = nJoystickAileronNew
                    '            frmMain.WriteTrackingSerialPort(Chr("&h80") & Chr("&h1") & Chr("&h4") & Chr(nJoystickAileronServo - 1) & GetPololuValue(ConstrainJoystick(nJoystickAileronPosition, 500, 5500)), True)
                    '        End If
                    '    End If
                    '    If nJoystickRudderServo <> 0 Then
                    '        If nJoystickRudderPosition <> nJoystickRudderNew Then
                    '            nJoystickRudderPosition = nJoystickRudderNew
                    '            frmMain.WriteTrackingSerialPort(Chr("&h80") & Chr("&h1") & Chr("&h4") & Chr(nJoystickRudderServo - 1) & GetPololuValue(ConstrainJoystick(nJoystickRudderPosition, 500, 5500)), True)
                    '        End If
                    '    End If
            End Select
        End If
    End Function
    Public Function ReleaseJoystick()
        Select Case nConfigDevice
            Case e_ConfigDevice.e_ConfigDevice_MAVlink
                frmMain.SendMavlinkRawServo(0, 0, 0, 0, 0, 0, 0, 0)
        End Select
    End Function
    'Public Function GetJoystickValue(ByVal inputValus As Integer, ByVal minValue As Integer, ByVal maxValue As Integer, ByVal absMin As Integer, ByVal absMax As Integer, ByVal subTrim As Integer, Optional ByVal reversedValue As Boolean = False) As Integer
    '    Dim nTemp As Integer
    '    Dim nPct As Single

    '    nTemp = inputValus + subTrim

    '    If nTemp < minValue Then
    '        nTemp = minValue
    '    ElseIf nTemp > maxValue Then
    '        nTemp = maxValue
    '    End If
    '    If reversedValue = True Then
    '        nTemp = minValue + (maxValue - nTemp)
    '    End If
    '    nPct = (nTemp - minValue) / (maxValue - minValue)
    '    If Convert.ToDouble(nPct).IsNaN(nPct) = False Then
    '        GetJoystickValue = (absMax - absMin) * nPct + absMin
    '    Else
    '        GetJoystickValue = ((maxValue - minValue) / 2) + minValue
    '    End If
    'End Function
End Module
