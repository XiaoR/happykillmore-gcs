Imports System.IO
Module modGlobal
    Public sRootRegistry As String = "SOFTWARE\HK_GCS"
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
    Public Function ConvertSpeed(ByVal inputValue As VariantType, ByVal inputFormat As e_SpeedFormat, ByVal outputFormat As e_SpeedFormat) As Single
        Dim nTemp As Double

        If inputFormat = outputFormat Then
            ConvertSpeed = inputValue
        Else
            Select Case inputFormat
                Case e_SpeedFormat.e_SpeedFormat_Knots
                    nTemp = inputValue * 1.852
                Case e_SpeedFormat.e_SpeedFormat_KPH
                    nTemp = inputValue
                Case e_SpeedFormat.e_SpeedFormat_MPerSec
                    nTemp = inputValue * 3.6
                Case e_SpeedFormat.e_SpeedFormat_MPH
                    nTemp = inputValue * 1.609344
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
    Public Function ConvertDistance(ByVal inputValue As VariantType, ByVal inputFormat As e_DistanceFormat, ByVal outputFormat As e_DistanceFormat) As Single
        Dim nTemp As Double

        If inputFormat = outputFormat Then
            ConvertDistance = inputValue
        Else
            Select Case inputFormat
                Case e_DistanceFormat.e_DistanceFormat_Feet
                    nTemp = inputValue / 3.2808399
                Case e_DistanceFormat.e_DistanceFormat_Meters
                    nTemp = inputValue
            End Select

            Select Case outputFormat
                Case e_DistanceFormat.e_DistanceFormat_Feet
                    ConvertDistance = (nTemp * 3.2808399).ToString("#.00")
                Case e_DistanceFormat.e_DistanceFormat_Meters
                    ConvertDistance = (nTemp).ToString("#.00")
            End Select
        End If
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
                        ConvertLatLongFormat = Mid(inputValue, 1, InStr(inputValue, ".") - 3) & (Convert.ToDouble(Mid(inputValue, InStr(inputValue, ".") - 2)) / 60).ToString(".000000")
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

            sHeaderCharacters = Chr(&HB5) & Chr(&H62)
            If InStr(sBuffer, sHeaderCharacters) < nLastStart And InStr(sBuffer, sHeaderCharacters) <> 0 Then
                nLastStart = InStr(sBuffer, sHeaderCharacters)
                nMessageType = cMessage.e_MessageType.e_MessageType_uBlox
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

            Select Case nMessageType
                Case cMessage.e_MessageType.e_MessageType_ArduIMU_Binary
                    sHeaderCharacters = "DIYd"
                    If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) >= 5 Then
                        nPacketSize = Asc(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 4, 1))
                        If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) >= nPacketSize + 8 Then
                            nLastStart = InStr(sBuffer, sHeaderCharacters)
                            sTemp = Mid(sBuffer, nLastStart, nPacketSize + 8)
                            For nCount = 1 To Len(sTemp)
                                sOutput = sOutput & Hex(Asc(Mid(sTemp, nCount, 1))).PadLeft(2, "0") & " "
                            Next
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
                    sHeaderCharacters = Chr(&HA0) & Chr(&HA2)
                    If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) >= 5 Then
                        nPacketSize = Asc(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters) + 3, 1))
                        If Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) >= nPacketSize + 6 Then
                            nLastStart = InStr(sBuffer, sHeaderCharacters)
                            sTemp = Mid(sBuffer, nLastStart, nPacketSize + 6)
                            sOutput = ""
                            For nCount = 1 To Len(sTemp)
                                sOutput = sOutput & Hex(Asc(Mid(sTemp, nCount, 1))).PadLeft(2, "0") & " "
                            Next
                            With GetNextSentence
                                .RawMessage = sTemp
                                .MessageType = cMessage.e_MessageType.e_MessageType_SiRF
                                .Header = "SiRF"
                                .ID = Asc(Mid(sTemp, 4, 1))
                                .Packet = Mid(sTemp, 5, Len(sTemp) - 6)
                                .PacketLength = Len(.Packet) - 2
                                .Checksum = Strings.Right(sTemp, 2)
                                .VisibleSentence = .Header & " - " & sOutput
                                If .Checksum = GetSiRFChecksum(.Packet) Then
                                    .ValidMessage = True
                                End If
                            End With
                        End If
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
                                For nCount = 1 To Len(sTemp)
                                    sOutput = sOutput & Hex(Asc(Mid(sTemp, nCount, 1))).PadLeft(2, "0") & " "
                                Next
                                With GetNextSentence
                                    .RawMessage = sTemp
                                    .ID = Asc(Mid(sTemp, 4, 1))
                                    .Packet = Mid(sTemp, 3, Len(sTemp) - 4)
                                    .PacketLength = Len(.Packet)
                                    .Checksum = Strings.Right(sTemp, 2)
                                    .VisibleSentence = .Header & " - " & sOutput
                                    If .Checksum = GetuBloxChecksum(.Packet) Then
                                        .ValidMessage = True
                                    End If
                                End With
                            Else
                                System.Diagnostics.Debug.Print("Len=" & Len(Mid(sBuffer, InStr(sBuffer, sHeaderCharacters))) & ",PacketSize=" & nPacketSize)
                            End If
                        End With
                    End If
            End Select
        Catch e2 As Exception
            'System.Diagnostics.Debug.Assert(False)
            System.Diagnostics.Debug.Print("GetNextSentence - " & e2.ToString)
        End Try

        If GetNextSentence.Packet <> "" Then
            'System.Diagnostics.Debug.Print("Len=" & Len(GetNextSentence.RawMessage))
            'GpS_Parser1_RawPacket1(GetNextSentence.RawMessage)
            sBuffer = Mid(sBuffer, nLastStart + Len(sTemp))
            Do While Strings.Left(sBuffer, 1) = vbCrLf Or Strings.Left(sBuffer, 1) = vbCr Or Strings.Left(sBuffer, 1) = vbLf
                sBuffer = Mid(sBuffer, 2)
            Loop
        Else
            'System.Diagnostics.Debug.Assert(False)
            'System.Diagnostics.Debug.Print("GetNextSentence - Packet Empty")
        End If

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

End Module
