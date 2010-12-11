Imports System.IO
Imports DirectShowLib

Module modGlobal
    Public theDevice1 As IBaseFilter
    Public theDevice2 As IBaseFilter
    Public Const pi As Double = 3.14159265
    Public sRootRegistry As String = "SOFTWARE\HK_GCS"
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
    End Enum
    Public Enum e_InstrumentLayout
        e_InstrumentLayout_Horizontal = 0
        e_InstrumentLayout_Square
        e_InstrumentLayout_Vertical
    End Enum
    Public Enum e_SelectedInstrument
        e_SelectedInstrument_Attitude = 0
        e_SelectedInstrument_3DMesh
    End Enum

    Public nPitch As Single
    Public nRoll As Single
    Public nYaw As Single

    Public nYawOffset As Single

    Public bShowBinary As Boolean = True
    Public nLatitude As String
    Public nLongitude As String
    Public nAltitude As Single
    Public nGroundSpeed As Single
    Public nAirSpeed As Single
    Public nHeading As Single
    Public nSats As Integer
    Public nBattery As Single
    Public sMode As String
    Public sModeNumber As String
    Public nFix As Integer
    Public nHDOP As Single
    Public nWaypointIndex As Integer
    Public nWaypointTotal As Integer
    Public nServo(0 To 7) As Integer
    Public eMissionFileType As e_MissionFileType = e_MissionFileType.e_MissionFileType_None

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
            ConvertHexToDec = Convert.ToInt64(ConvertHexToDec) - Convert.ToInt64(sTwos, 16) - 1
        End If

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

        nLastStart = 999
        GetNextSentence = New cMessage
        GetNextSentence.ValidMessage = False

        Try
            sHeaderCharacters = "TEST:"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_Test
            End If

            sHeaderCharacters = AddCharacter(85)
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_MAV
            End If

            sHeaderCharacters = "F2:"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_UDB
            End If

            sHeaderCharacters = "F13:"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_UDB_SetHome
            End If

            sHeaderCharacters = "$GP"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_NMEA
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

            sHeaderCharacters = AddCharacter(&HB5) & AddCharacter(&H62)
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_uBlox
            End If

            sHeaderCharacters = "4D"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_ArduPilotMega_Binary
            End If

            sHeaderCharacters = AddCharacter(&HA0) & AddCharacter(&HA2)
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_SiRF
            End If

            sHeaderCharacters = "DIYd"
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_ArduIMU_Binary
            End If

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
                                .MessageType = cMessage.e_MessageType.e_MessageType_Test
                                .Header = "Test Msg"
                                .Packet = Mid(sTemp, 6, Len(sTemp) - 5)
                                .PacketLength = Len(.Packet) - 2
                                .VisibleSentence = .Header & " - " & sOutput
                                .ValidMessage = True
                            End With
                        End If
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
                            .MessageType = cMessage.e_MessageType.e_MessageType_UDB
                            .ValidMessage = True
                            .Header = "Serial UDB Extra"
                            .Packet = Mid(sTemp, 4, Len(sTemp) - 6)
                            .PacketLength = Len(.Packet)
                            .VisibleSentence = .Header & " - " & Mid(sTemp, 1, Len(sTemp) - 2)
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
                            .MessageType = cMessage.e_MessageType.e_MessageType_UDB_SetHome
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
                                .MessageType = cMessage.e_MessageType.e_MessageType_ArduIMU_Binary
                                .Header = "ArduIMU"
                                .ID = Asc(Mid(sTemp, 6, 1))
                                .Packet = Mid(sTemp, 5, Len(sTemp) - 6)
                                .PacketLength = Len(.Packet) - 2
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
                            .MessageType = cMessage.e_MessageType.e_MessageType_ArduPilot_Attitude
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
                            .MessageType = cMessage.e_MessageType.e_MessageType_ArduPilot_ModeChange
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
                            .MessageType = cMessage.e_MessageType.e_MessageType_ArduPilot_GPS
                            .ValidMessage = True
                            .Header = "AP GPS"
                            .Packet = Mid(sTemp, 4, Len(sTemp) - 6)
                            .PacketLength = Len(.Packet)
                            .VisibleSentence = .Header & " - " & sTemp
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
                            .MessageType = cMessage.e_MessageType.e_MessageType_NMEA
                            .Header = Mid(sTemp, 1, 6)
                            .Packet = Mid(sTemp, 2, Len(Mid(sTemp, 1, InStr(sTemp, "*") - 2)))
                            .PacketLength = Len(.Packet)
                            .Checksum = Mid(sTemp, InStr(sTemp, "*") + 1)
                            .VisibleSentence = "NMEA - " & sTemp
                            If .Checksum = GetChecksum(.Packet) Then
                                .ValidMessage = True
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
                            .MessageType = cMessage.e_MessageType.e_MessageType_ArduPilot_Home
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
                            .MessageType = cMessage.e_MessageType.e_MessageType_ArduPilot_WP
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
                            .MessageType = cMessage.e_MessageType.e_MessageType_ArduPilot_WPCount
                            .Header = ""
                            .Packet = sTemp
                            .PacketLength = Len(.Packet)
                            .VisibleSentence = "AP Waypoint Count - " & sTemp
                            .ValidMessage = True
                        End With
                    End If

                Case cMessage.e_MessageType.e_MessageType_SiRF
                    sHeaderCharacters = AddCharacter(&HA0) & AddCharacter(&HA2)
                    sFooterCharacters = AddCharacter(&HB0) & AddCharacter(&HB3)
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
                                .MessageType = cMessage.e_MessageType.e_MessageType_SiRF
                                .Header = "SiRF"
                                .ID = Asc(Mid(sTemp, 4, 1))
                                .Packet = Mid(sTemp, 5, nPacketSize)
                                .PacketLength = nPacketSize
                                .Checksum = Mid(sTemp, Len(sHeaderCharacters) + 3 + nPacketSize, 2)
                                .VisibleSentence = .Header & " - " & sOutput
                                If .Checksum = GetSiRFChecksum(.Packet) Then
                                    .ValidMessage = True
                                Else
                                    .ValidMessage = False
                                End If
                            End With
                        End If
                    End If
                Case cMessage.e_MessageType.e_MessageType_uBlox
                    sHeaderCharacters = AddCharacter(&HB5) & AddCharacter(&H62)
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
                                    Else
                                        Debug.Print(sOutput)
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
                            .MessageType = cMessage.e_MessageType.e_MessageType_ArduPilotMega_Binary
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
                    sHeaderCharacters = AddCharacter(85)
                    If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) > 1 Then
                        With GetNextSentence
                            nPacketSize = Asc(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 1, 1)) + 2
                            .MessageType = cMessage.e_MessageType.e_MessageType_MAV
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
End Module
