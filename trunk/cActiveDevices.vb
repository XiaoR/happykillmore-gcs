Public Class cActiveDevices
    Public dLastDeviceTime() As Long
    Public bDeviceFound() As Boolean
    Public nHearbeatRun() As Long
    Public bAlarm As Boolean
    Public bWarning As Boolean
    Public nBrokenTime As Single
    Public bAlarmSpeechPlayed() As Boolean
    Public bWarningSpeecgPlayed() As Boolean
    Private bDeviceAlarm() As Boolean
    Private bDeviceWarning() As Boolean
    Public sDeviceType As String

    Public Const e_DeviceTypes_Max As Integer = 14
 
    Public Sub Initialize()
        Dim nCount As Integer

        bAlarm = False
        bWarning = False
        nBrokenTime = 0

        ReDim dLastDeviceTime(0 To e_DeviceTypes_Max)
        ReDim bDeviceFound(0 To e_DeviceTypes_Max)
        ReDim nHearbeatRun(0 To e_DeviceTypes_Max)
        'ReDim bAlarmSpeechPlayed(0 To e_DeviceTypes_Max)
        'ReDim bWarningSpeecgPlayed(0 To e_DeviceTypes_Max)
        ReDim bDeviceAlarm(0 To e_DeviceTypes_Max)
        ReDim bDeviceWarning(0 To e_DeviceTypes_Max)

        For nCount = 0 To e_DeviceTypes_Max
            dLastDeviceTime(nCount) = 0
            bDeviceFound(nCount) = False
            'bAlarmSpeechPlayed(nCount) = False
            'bWarningSpeecgPlayed(nCount) = False
            bDeviceAlarm(nCount) = False
            bDeviceWarning(nCount) = False
            nHearbeatRun(nCount) = 0
        Next
    End Sub
    Public Sub Validate()
        Dim ncount As Integer

        bAlarm = False
        bWarning = False
        nBrokenTime = 0
        sDeviceType = ""

        For ncount = 0 To e_DeviceTypes_Max
            If (dLastDeviceTime(ncount) + (nAlarmTimeout * 10000000)) < Now.Ticks And dLastDeviceTime(ncount) <> 0 And nAlarmTimeout <> 0 Then
                bAlarm = True
                bWarning = False

                If ((Now.Ticks - dLastDeviceTime(ncount)) / 10000000).ToString("0.00") > nBrokenTime Then
                    nBrokenTime = ((Now.Ticks - dLastDeviceTime(ncount)) / 10000000).ToString("0.00")
                End If

                If bDeviceAlarm(ncount) = False Then
                    bDeviceAlarm(ncount) = True
                    If bAnnounceLinkAlarm = True Then
                        PlayMessage(sSpeechAlarm, sSpeechVoice)
                    End If
                End If
                nHearbeatRun(ncount) = 0
                sDeviceType = GetDeviceTypeString(ncount)

                bDeviceFound(ncount) = False
            ElseIf (dLastDeviceTime(ncount) + (nWarningTimeout * 10000000)) < Now.Ticks And dLastDeviceTime(ncount) <> 0 And nWarningTimeout <> 0 Then
                bWarning = True
                bAlarm = False

                If ((Now.Ticks - dLastDeviceTime(ncount)) / 10000000).ToString("0.00") > nBrokenTime Then
                    nBrokenTime = ((Now.Ticks - dLastDeviceTime(ncount)) / 10000000).ToString("0.00")
                End If

                If bDeviceWarning(ncount) = False Then
                    bDeviceWarning(ncount) = True
                    If bAnnounceLinkWarning = True Then
                        PlayMessage(sSpeechWarning, sSpeechVoice)
                    End If
                End If
                nHearbeatRun(ncount) = 0
                sDeviceType = GetDeviceTypeString(ncount)

                bDeviceFound(ncount) = False
            ElseIf dLastDeviceTime(ncount) + nWarningTimeout * 10000000 > Now.Ticks Then
                bDeviceFound(ncount) = True
                bDeviceAlarm(ncount) = False
                bDeviceWarning(ncount) = False
                'Else
                '    bDeviceFound(ncount) = False
            End If
        Next
    End Sub
    Public Sub ClearAlarms()
        Dim nCount As Integer

        For nCount = 0 To e_DeviceTypes_Max
            dLastDeviceTime(nCount) = 0
        Next
    End Sub
    Private Function GetDeviceTypeString(ByVal deviceType As e_DeviceTypes) As String
        Select Case deviceType
            Case e_DeviceTypes.e_DeviceTypes_ArduIMU
                GetDeviceTypeString = "ArduIMU"
            Case e_DeviceTypes.e_DeviceTypes_ArduPilotLegacy
                GetDeviceTypeString = "ArduPilot Legacy"
            Case e_DeviceTypes.e_DeviceTypes_ArduPilotMega
                GetDeviceTypeString = "ArduPilot Mega"
            Case e_DeviceTypes.e_DeviceTypes_AttoPilot
                GetDeviceTypeString = "AttoPilot"
            Case e_DeviceTypes.e_DeviceTypes_FY21AP
                GetDeviceTypeString = "FY21AP"
            Case e_DeviceTypes.e_DeviceTypes_GluonPilot
                GetDeviceTypeString = "GluonPilot"
            Case e_DeviceTypes.e_DeviceTypes_MavLink
                GetDeviceTypeString = "MAVlink"
            Case e_DeviceTypes.e_DeviceTypes_Mediatek
                GetDeviceTypeString = "MediaTek Binary"
            Case e_DeviceTypes.e_DeviceTypes_Mediatek16
                GetDeviceTypeString = "MediaTek 1.6 Binary"
            Case e_DeviceTypes.e_DeviceTypes_NMEA
                GetDeviceTypeString = "NMEA"
            Case e_DeviceTypes.e_DeviceTypes_Paparazzi
                GetDeviceTypeString = "Paparazzi"
            Case e_DeviceTypes.e_DeviceTypes_SiRF
                GetDeviceTypeString = "SiRF (EM406)"
            Case e_DeviceTypes.e_DeviceTypes_uBlox
                GetDeviceTypeString = "uBlox Binary"
            Case e_DeviceTypes.e_DeviceTypes_UDB
                GetDeviceTypeString = "UavDevBoard (MatrixPilot)"
            Case Else
                GetDeviceTypeString = "None"
        End Select
    End Function
End Class
