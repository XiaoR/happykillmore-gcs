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

    Public Const e_Instruments_Max = 7
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

    Public Enum e_MissionFileType
        e_MissionFileType_None = 0
        e_MissionFileType_GCS
        e_MissionFileType_UDB
        e_MissionFileType_FY21APII
    End Enum
    Public Enum e_InstrumentLayout
        e_InstrumentLayout_Horizontal = 0
        e_InstrumentLayout_Square
        e_InstrumentLayout_Vertical
        e_InstrumentLayout_SingleColumn
    End Enum

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

    Public resourceMgr As ResourceManager

    Public Delegate Sub MyDelegate()
    'Public Delegate Sub NewDataArrived()
    'Public dataDelegate 'As New NewDataArrived(AddressOf frmMain.NewDataReceived)

    Public bIsAdmin As Boolean
    Public bShutdown As Boolean = False
    Public sBuffer As String
    Public bConnected As Boolean = False
    Public bConnectedTracking As Boolean = False

    Public nPitch As Single
    Public nRoll As Single
    Public nYaw As Single

    Public eAltOffset As e_AltOffset
    Public nHomeOffset As Integer
    Public nSocketPortNumber As Long
    Public sSocketIPaddress As String
    Public nSocketType As Integer

    Public nYawOffset As Single
    Public sLanguageFile As String
    Public sLoadedLanguageFile As String
    Public oCulture As CultureInfo

    Public sSpeechVoice As String
    Public bAnnounceWaypoints As Boolean
    Public sSpeechWaypoint As String
    Public bAnnounceModeChange As Boolean
    Public sSpeechModeChange As String
    Public bAnnounceRegularInterval As Boolean
    Public sSpeechRegularInterval As String
    Public nSpeechInterval As Long

    Public nWaypoint As Integer
    Public nWaypointAlt As Single
    Public nDistance As Single

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

    Public bShowBinary As Boolean = True
    Public nLatitude As String
    Public nLongitude As String
    Public nAltitude As Single
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
    Public eMissionFileType As e_MissionFileType = e_MissionFileType.e_MissionFileType_None
    Public Function GetServoValue(ByVal inputString As String) As Double
        If IsNumeric(inputString) = True Then
            GetServoValue = Convert.ToDouble(inputString)
        Else
            GetServoValue = 0
        End If
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
            GetNMEADate = GetNMEADate.Parse(inputString.Substring(2, 2) & "/" & inputString.Substring(0, 2) & "/" & inputString.Substring(4, 2), cf).Date
        Catch
        End Try
    End Function
    Public Function GetNMEATime(ByVal inputString As String) As Date
        Try
            Dim cf As System.Globalization.CultureInfo
            cf = New System.Globalization.CultureInfo("en-US")
            inputString = inputString.Substring(0, InStr(inputString, ".") - 1)
            inputString = inputString.PadLeft(6, "0")
            GetNMEATime = GetNMEATime.Parse(inputString.Substring(0, 2) & ":" & inputString.Substring(2, 2) & ":" & inputString.Substring(4, 2), cf).ToLongTimeString
        Catch
        End Try
    End Function
    Public Function GetMediaTekv16Date(ByVal inputString As String) As Date
        Try
            Dim cf As System.Globalization.CultureInfo
            cf = New System.Globalization.CultureInfo("en-US")
            GetMediaTekv16Date = GetMediaTekv16Date.Parse(inputString.Substring(4, 2) & "/" & inputString.Substring(6, 2) & "/" & inputString.Substring(0, 4), cf).Date
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
            Debug.Print(err2.Message)
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
    Public Function ConvertSpeed(ByVal inputValue As String, ByVal inputFormat As e_SpeedFormat, ByVal outputFormat As e_SpeedFormat) As Single
        Dim nTemp As Double

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
                    ConvertSpeed = (nTemp / 1.852).ToString("#.00")
                Case e_SpeedFormat.e_SpeedFormat_KPH
                    ConvertSpeed = (nTemp).ToString("#.00")
                Case e_SpeedFormat.e_SpeedFormat_MPerSec
                    ConvertSpeed = (nTemp / 3.6).ToString("#.00")
                Case e_SpeedFormat.e_SpeedFormat_MPH
                    ConvertSpeed = (nTemp / 1.609344).ToString("#.00")
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
                    ConvertLatLongFormat = (Mid(inputValue, 1, InStr(inputValue, ".") - 1) & Convert.ToDouble(Mid(inputValue, InStr(inputValue, "."))) * 60)
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

        nTemp = CDec("&h" & Hex(Asc(Mid(inputValue, 1, 1))) & Hex(Asc(Mid(inputValue, 2, 1)))) And &H7FFF
        nTemp = (nTemp + CDec("&h" & Hex(Asc(Mid(inputValue, 3, 1))) & Hex(Asc(Mid(inputValue, 4, 1)))) * 0.00001) / 60
        If nTemp > 32768 Then
            nTemp = nTemp - 32768
        End If

        If CDec("&h" & Hex(Asc(Mid(inputValue, 1, 1))) & Hex(Asc(Mid(inputValue, 2, 1)))) And &H8000 Then
            nTemp = -nTemp
        End If
        ConvertLatLongFY21AP = nTemp.ToString("0.0000000")
    End Function
    Public Function GetNextSentence(ByRef sBuffer As String) As cMessage
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

            sHeaderCharacters = Chr(85)
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_MAV
            End If

            sHeaderCharacters = "T"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 And Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 2, 1) = ";" Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_Gluonpilot
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
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_uBlox
            End If

            sHeaderCharacters = Chr(&HD0) & Chr(&HDD)
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_MediaTekv16
            End If

            sHeaderCharacters = Chr(&HA5) & Chr(&H5A)
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_FY21AP
            End If

            sHeaderCharacters = "4D"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_ArduPilotMega_Binary
            End If

            sHeaderCharacters = Chr(&HA0) & Chr(&HA2)
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_SiRF
            End If

            sHeaderCharacters = "DIYd"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_ArduIMU_Binary
            End If

            sHeaderCharacters = " "
            Try
                If sBuffer.Substring(17, 1) = " " And IsNumeric(sBuffer.Substring(0, 17)) = True Then
                    nLastStart = InStr(sBuffer, sHeaderCharacters) - 17
                    nMessageType = cMessage.e_MessageType.e_MessageType_Paparazzi
                End If
            Catch
            End Try

            sHeaderCharacters = ":"
            Try
                If sBuffer.Substring(18, 1) = ":" And IsNumeric(sBuffer.Substring(0, 18)) = True Then
                    nLastStart = InStr(sBuffer, sHeaderCharacters) - 18
                    nMessageType = cMessage.e_MessageType.e_MessageType_HKO
                End If
            Catch
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
                                .RawMessage = sTemp
                                .MessageType = nMessageType
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
                                .RawMessage = sTemp
                                .MessageType = nMessageType
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
                                .RawMessage = sTemp
                                .MessageType = nMessageType
                                .ValidMessage = True
                                .Header = "Serial UDB Extra"
                                .Packet = Mid(sTemp, 5, Len(sTemp) - 7)
                                .PacketLength = Len(.Packet)
                                .VisibleSentence = .Header & " - " & Mid(sTemp, 1, Len(sTemp) - 2)
                            End With
                        End If

                    Case cMessage.e_MessageType.e_MessageType_ArduIMU_Binary
                        sHeaderCharacters = "DIYd"
                        If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) >= 5 Then
                            nPacketSize = Asc(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 4, 1))
                            If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) >= nPacketSize + 8 Then
                                nLastStart = InStr(sBuffer, sHeaderCharacters)
                                sTemp = Mid(sBuffer, nLastStart, nPacketSize + 8)
                                If bShowBinary = True Then
                                    For nCount = 1 To Len(sTemp)
                                        sOutput = sOutput & Hex(Asc(Mid(sTemp, nCount, 1))).PadLeft(2, "0") & " "
                                    Next
                                Else
                                    sOutput = "{Binary Message}"
                                End If
                                With GetNextSentence
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
                                .RawMessage = sTemp
                                .MessageType = nMessageType
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
                                .RawMessage = sTemp
                                .MessageType = nMessageType
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
                                .RawMessage = sTemp
                                .MessageType = nMessageType
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
                                            dGPSTime = GetuBloxTime(Convert.ToDouble(sValues(1) / 1000))
                                            .ValidDateTime = True
                                            Exit For
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
                                .RawMessage = sTemp
                                .MessageType = nMessageType
                                .Header = Mid(sTemp, 1, 6)
                                .Packet = Mid(sTemp, 2, Len(Mid(sTemp, 1, InStr(sTemp, "*") - 2)))
                                .PacketLength = Len(.Packet)
                                .Checksum = Mid(sTemp, InStr(sTemp, "*") + 1)
                                .VisibleSentence = "NMEA - " & sTemp
                                If .Checksum = GetChecksum(.Packet) Then
                                    .ValidMessage = True
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

                    Case cMessage.e_MessageType.e_MessageType_Gluonpilot
                        sHeaderCharacters = "T"
                        sFooterCharacters = vbLf
                        If InStr(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 1), sFooterCharacters) <> 0 Then
                            nLastStart = InStr(sBuffer, sHeaderCharacters)
                            sTemp = Mid(sBuffer, nLastStart)
                            sTemp = Mid(sTemp, 1, InStr(sTemp, sFooterCharacters) - 1)
                            If Strings.Right(sTemp, 1) = vbCr Then
                                sTemp = Mid(sTemp, 1, Len(sTemp) - 1)
                            End If
                            With GetNextSentence
                                .RawMessage = sTemp
                                .MessageType = nMessageType
                                .Header = Mid(sTemp, 1, 2)
                                .Packet = Mid(sTemp, 4)
                                .PacketLength = Len(.Packet)
                                .VisibleSentence = "Gluonpilot - " & sTemp
                                .ValidMessage = True

                                'Waiting on response from Tom on Date/Time field
                            End With
                        End If

                    Case cMessage.e_MessageType.e_MessageType_AttoPilot, cMessage.e_MessageType.e_MessageType_AttoPilot18
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
                                .RawMessage = sTemp
                                .MessageType = nMessageType
                                .Header = Mid(sTemp, 1, 3)
                                .Packet = Mid(sTemp, 2, Len(Mid(sTemp, 1, InStr(sTemp, "*") - 2)))
                                .PacketLength = Len(.Packet)
                                .Checksum = Mid(sTemp, InStr(sTemp, "*") + 1)
                                .VisibleSentence = "AttoPilot - " & sTemp
                                If .Checksum = GetChecksum(.Packet) Then
                                    .ValidMessage = True
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
                                .RawMessage = sTemp
                                .MessageType = nMessageType
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
                                .RawMessage = sTemp
                                .MessageType = nMessageType
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
                                .RawMessage = sTemp
                                .MessageType = nMessageType
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
                        If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) >= 5 Then
                            nPacketSize = Asc(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 3, 1))
                            If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) >= nPacketSize + 8 Then
                                nLastStart = InStr(sBuffer, sHeaderCharacters)
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
                        If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) >= 3 Then
                            nPacketSize = Asc(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 2, 1))
                            If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) >= nPacketSize + 2 Then
                                nLastStart = InStr(sBuffer, sHeaderCharacters)
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
                                        Try
                                            If .ID = 242 Then
                                                .GPSDateTime = CDate(GetNMEADate(Asc(Mid(.Packet, 33, 1)).ToString("00") & Asc(Mid(.Packet, 32, 1)).ToString("00") & Asc(Mid(.Packet, 34, 1)).ToString("00")) & " " & GetNMEATime(Asc(Mid(.Packet, 29, 1)).ToString("00") & Asc(Mid(.Packet, 30, 1)).ToString("00") & Asc(Mid(.Packet, 31, 1)).ToString("00")))
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

                    Case cMessage.e_MessageType.e_MessageType_MediaTekv16
                        sHeaderCharacters = Chr(&HD0) & Chr(&HDD)
                        If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) > 37 Then
                            With GetNextSentence
                                nPacketSize = 32
                                .MessageType = nMessageType
                                .Header = "MTK v1.6"
                                nSizeOffset = 5

                                nLastStart = InStr(sBuffer, sHeaderCharacters)
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
                                    .RawMessage = sTemp
                                    .Packet = Mid(sTemp, 4, Len(sTemp) - 5)
                                    .PacketLength = Len(.Packet)
                                    .Checksum = Strings.Right(sTemp, 2)
                                    .VisibleSentence = .Header & " - " & sOutput
                                    If .Checksum = GetuBloxChecksum(.Packet) Then
                                        .ValidMessage = True
                                        Try
                                            .GPSDateTime = CDate(GetMediaTekv16Date(ConvertHexToDec(Mid(.Packet, 23, 4), False)) & " " & GetMediaTekv16Time(Convert.ToInt32(ConvertHexToDec(Mid(.Packet, 27, 4), False))))
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
                        If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) > 4 Then
                            With GetNextSentence
                                If Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 2, 2) <> Chr("&H1") & Chr("&H5") Then
                                    nPacketSize = Asc(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 4, 1))
                                    .MessageType = cMessage.e_MessageType.e_MessageType_uBlox
                                    .Header = "uBlox"
                                    nSizeOffset = 8
                                Else
                                    nPacketSize = 28
                                    .MessageType = cMessage.e_MessageType.e_MessageType_MediaTek
                                    .Header = "MTK"
                                    nSizeOffset = 4
                                End If
                                If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) >= nPacketSize + nSizeOffset Then
                                    nLastStart = InStr(sBuffer, sHeaderCharacters)
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
                                        .RawMessage = sTemp
                                        .ID = Asc(Mid(sTemp, 4, 1))
                                        .Packet = Mid(sTemp, 3, Len(sTemp) - 4)
                                        .PacketLength = Len(.Packet)
                                        .Checksum = Strings.Right(sTemp, 2)
                                        .VisibleSentence = .Header & " - " & sOutput
                                        If .Checksum = GetuBloxChecksum(.Packet) Then
                                            .ValidMessage = True
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
                        If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) > 4 Then
                            With GetNextSentence
                                nPacketSize = Asc(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 2, 1)) + 2
                                .MessageType = nMessageType
                                .Header = "AP Mega"
                                nSizeOffset = 5
                                If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) >= nPacketSize + nSizeOffset Then
                                    nLastStart = InStr(sBuffer, sHeaderCharacters)
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
                                        .RawMessage = sTemp
                                        .ID = Asc(Mid(sTemp, 4, 1))
                                        .Packet = Mid(sTemp, 3, Len(sTemp) - 4)
                                        .PacketLength = Len(.Packet)
                                        .Checksum = Strings.Right(sTemp, 2)
                                        .VisibleSentence = .Header & " - " & Trim(sOutput)
                                        If .Checksum = GetuBloxChecksum(.Packet) Then
                                            .ValidMessage = True
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
                        If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) > 1 Then
                            With GetNextSentence
                                nPacketSize = Asc(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 1, 1)) + 2
                                .MessageType = nMessageType
                                .Header = "MAVlink"
                                nSizeOffset = 6
                                If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) >= nPacketSize + nSizeOffset Then
                                    nLastStart = InStr(sBuffer, sHeaderCharacters)
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
                                        .RawMessage = sTemp
                                        .ID = Asc(Mid(sTemp, 6, 1))
                                        .Packet = Mid(sTemp, 1, Len(sTemp) - 2)
                                        .PacketLength = Len(.Packet)
                                        .Checksum = Strings.Right(sTemp, 2)
                                        .VisibleSentence = .Header & " - " & Trim(sOutput)

                                        'Debug.Print(".checksum=" & Hex(Asc(Mid(.Checksum, 1, 1))).PadLeft(2, "0") & Hex(Asc(Mid(.Checksum, 2, 1))).PadLeft(2, "0"))
                                        If .Checksum = crc_calculate(.Packet) Then
                                            .ValidMessage = True
                                            Try
                                                Select Case Asc(Mid(.Packet, 6, 1))
                                                    Case 2, 28, 30, 32, 33
                                                        .GPSDateTime = CDate(GetMAVlinkTime(ConvertMavlinkToLong(Mid(.Packet, 7, 8))) & " " & GetMAVlinkTime(ConvertMavlinkToLong(Mid(.Packet, 7, 8))))
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
                End Select
            End If
        Catch e2 As Exception
            'System.Diagnostics.Debug.Assert(False)
            System.Diagnostics.Debug.Print("GetNextSentence - " & e2.Message)
        End Try

        If GetNextSentence.Packet <> "" Then
            'System.Diagnostics.Debug.Print("Len=" & Len(GetNextSentence.RawMessage))
            'GpS_Parser1_RawPacket1(GetNextSentence.RawMessage)
            sBuffer = Mid(sBuffer, nLastStart + Len(sTemp))
            Do While Strings.Left(sBuffer, 1) = vbCrLf Or Strings.Left(sBuffer, 1) = vbCr Or Strings.Left(sBuffer, 1) = vbLf
                sBuffer = Mid(sBuffer, 2)
            Loop
        End If
        If Len(sBuffer) > 500 Then
            sBuffer = Mid(sBuffer, Len(sBuffer) - 500)
            'System.Diagnostics.Debug.Assert(False)
            'System.Diagnostics.Debug.Print("GetNextSentence - Packet Empty")
        End If

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
        Try

            objReader = New StreamReader(FullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()
            Return strContents
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
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
        ConvertSpeech = inputString
        If nWaypoint = 0 Then
            ConvertSpeech = Replace(ConvertSpeech, "{wpn}", "home")
        Else
            ConvertSpeech = Replace(ConvertSpeech, "{wpn}", nWaypoint)
        End If
        ConvertSpeech = Replace(ConvertSpeech, "{asp}", Convert.ToInt32(nAirSpeed))
        ConvertSpeech = Replace(ConvertSpeech, "{gsp}", Convert.ToInt32(nGroundSpeed))
        ConvertSpeech = Replace(ConvertSpeech, "{mode}", sMode)
        ConvertSpeech = Replace(ConvertSpeech, "{alt}", Convert.ToInt32(nAltitude))
        ConvertSpeech = Replace(ConvertSpeech, "{wpa}", Convert.ToInt32(nWaypointAlt))
    End Function
    Public Function LoadLanguageFile()
        If sLanguageFile = "Default" Then
            oCulture = System.Globalization.CultureInfo.CurrentCulture
        Else
            oCulture = CultureInfo.CreateSpecificCulture(sLanguageFile)
        End If
        resourceMgr = ResourceManager.CreateFileBasedResourceManager("Strings", GetRootPath() & "Language", Nothing)
    End Function
    Public Function GetTrackingHeadingAngle(ByVal homeLat As String, ByVal homeLong As String, ByVal homealt As String, ByVal locationLat As Double, ByVal locationLong As Double, ByVal locationAlt As Single, ByVal headingOffset As Integer, ByVal speed As Single, ByVal heading As Single, ByVal predict As Boolean, ByRef newHeading As Single, ByRef newAngle As Single) As Boolean
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
End Module
