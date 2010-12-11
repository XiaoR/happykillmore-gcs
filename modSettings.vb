Module modSettings
    Public nMapUpdateRate As Integer = 2
    Public sModelName As String = "EasyStar"
    Public nMaxSpeed As Integer = 120
    Public bPitchReverse As Boolean = False
    Public bRollReverse As Boolean = False
    Public bYawReverse As Boolean = False
    Public bHeadingReverse As Boolean = False
    Public nThrottleChannel As Integer = 1

    Public bFlightExtrude As Boolean = True
    Public sFlightColor As String = "ff00ffff"
    Public nFlightWidth As Integer = 2

    Public bMissionExtrude As Boolean = True
    Public sMissionColor As String = "ff0000ff"
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
        sModelName = GetRegSetting(sRootRegistry & "\Settings", "3D Model", "EasyStar")
        nMaxSpeed = GetRegSetting(sRootRegistry & "\Settings", "Max Speed", "120")
        bPitchReverse = GetRegSetting(sRootRegistry & "\Settings", "Pitch Reverse", False)
        bRollReverse = GetRegSetting(sRootRegistry & "\Settings", "Roll Reverse", False)
        bYawReverse = GetRegSetting(sRootRegistry & "\Settings", "Yaw Reverse", False)
        bHeadingReverse = GetRegSetting(sRootRegistry & "\Settings", "Heading Reverse", False)
        nThrottleChannel = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Throttle Channel", "1"))

        nMapUpdateRate = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Map Update Hz", "2"))

        bFlightExtrude = GetRegSetting(sRootRegistry & "\Settings", "Flight Extrude", True)
        sFlightColor = GetRegSetting(sRootRegistry & "\Settings", "Flight Color", "FF00FFFF")
        nFlightWidth = GetRegSetting(sRootRegistry & "\Settings", "Flight Width", 2)

        bMissionExtrude = GetRegSetting(sRootRegistry & "\Settings", "Mission Extrude", True)
        sMissionColor = GetRegSetting(sRootRegistry & "\Settings", "Mission Color", "FF0000FF")
        nMissionWidth = GetRegSetting(sRootRegistry & "\Settings", "Mission Width", 1)

        eDistanceUnits = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Distance Units", "0"))
        Select Case eDistanceUnits
            Case e_DistanceFormat.e_DistanceFormat_Feet
                sDistanceUnits = "Feet"
            Case e_DistanceFormat.e_DistanceFormat_Meters
                sDistanceUnits = "Meters"
        End Select
        frmMain.AltimeterInstrumentControl1.SetAlimeterParameters(nAltitude, sDistanceUnits)

        eSpeedUnits = Convert.ToInt32(GetRegSetting(sRootRegistry & "\Settings", "Speed Units", "2"))
        Select Case eSpeedUnits
            Case e_SpeedFormat.e_SpeedFormat_Knots
                sSpeedUnits = "Knots"
            Case e_SpeedFormat.e_SpeedFormat_KPH
                sSpeedUnits = "KPH"
            Case e_SpeedFormat.e_SpeedFormat_MPerSec
                sSpeedUnits = "m/s"
            Case e_SpeedFormat.e_SpeedFormat_MPH
                sSpeedUnits = "MPH"
        End Select
        frmMain.AirSpeedIndicatorInstrumentControl1.SetAirSpeedIndicatorParameters(nGroundSpeed, nMaxSpeed, "Speed", sSpeedUnits)

    End Sub

    Public Sub SaveSettings()
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

        LoadSettings()
    End Sub

    Public Function GetColor(ByVal inputColor As System.Drawing.Color, ByVal opacity As Integer) As String
        GetColor = Hex(opacity).PadLeft(2, "0")
        GetColor = GetColor & Hex(inputColor.B).PadLeft(2, "0")
        GetColor = GetColor & Hex(inputColor.G).PadLeft(2, "0")
        GetColor = GetColor & Hex(inputColor.R).PadLeft(2, "0")
    End Function

    'Private Sub cboDistanceUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call SaveRegSetting(sRootRegistry & "\Settings", "Distance Units", asdasdasd)
    '    eOutputDistance = cboDistanceUnits.SelectedIndex
    '    If eMapSelection = e_MapSelection.e_MapSelection_GoogleMaps Then
    '        webDocument.GetElementById("metersFeet").SetAttribute("value", cboDistanceUnits.SelectedIndex.ToString)
    '        cmdClearMap_Click(sender, e)
    '    End If
    '    AltimeterInstrumentControl1.SetAlimeterParameters(nAltitude, cboDistanceUnits.Text)
    'End Sub

    'Private Sub cboSpeedUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call SaveRegSetting(sRootRegistry & "\Settings", "Speed Units", cboSpeedUnits.SelectedIndex)
    '    eOutputSpeed = cboSpeedUnits.SelectedIndex
    '    AirSpeedIndicatorInstrumentControl1.SetAirSpeedIndicatorParameters(nGroundSpeed, Convert.ToInt32(cboMaxSpeed.Text), "Speed", cboSpeedUnits.Text)
    'End Sub

    'Private Sub cboMaxSpeed_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call SaveRegSetting(sRootRegistry & "\Settings", "Max Speed", cboMaxSpeed.SelectedIndex)
    '    AirSpeedIndicatorInstrumentControl1.SetAirSpeedIndicatorParameters(nGroundSpeed, Convert.ToInt32(cboMaxSpeed.Text), "Speed", cboSpeedUnits.Text)
    'End Sub
    'Private Sub chkFlightExtrude_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    bFlightExtrude = chkFlightExtrude.Checked
    '    If chkFlightExtrude.Checked = True Then
    '        chkFlightExtrude.Text = "Yes"
    '    Else
    '        chkFlightExtrude.Text = "No"
    '    End If
    '    Call SaveRegSetting(sRootRegistry & "\Settings", "Flight Extrude", bFlightExtrude)
    'End Sub

    'Private Sub UpdateLineColor()
    '    Dim sTemp As String

    '    sTemp = Hex(cmdFlightColor.BackColor.ToArgb).PadLeft(8, "0")
    '    sFlightColor = Hex("255").PadLeft(2, "0") & Mid(sTemp, 7, 2) & Mid(sTemp, 5, 2) & Mid(sTemp, 3, 2)

    '    'sTemp = Hex(cmdWaypointColor.BackColor.ToArgb).PadLeft(8, "0")
    '    'sWaypointColor = Hex("255").PadLeft(2, "0") & Mid(sTemp, 7, 2) & Mid(sTemp, 5, 2) & Mid(sTemp, 3, 2)

    'End Sub

    'Private Sub tbarFlightWidth_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    nFlightWidth = tbarFlightWidth.Value
    '    Call SaveRegSetting(sRootRegistry & "\Settings", "Flight Width", nFlightWidth)
    'End Sub
    'Private Sub cbo3DModel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call SaveRegSetting(sRootRegistry & "\Settings", "3D Model", cbo3DModel.Text)
    '    s3DModel = cbo3DModel.Text
    '    _3DMesh1.DrawMesh(me.handle,IIf(bPitchReverse = True, -1, 1) * nPitch, IIf(bRollReverse = True, -1, 1) * nRoll, nYaw, True, s3DModel, GetRootPath & "3D Models\")
    '    WebBrowser1.Invoke(New MyDelegate(AddressOf loadModel))
    'End Sub

    'Private Sub chkPitchReverse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    bPitchReverse = chkPitchReverse.Checked
    '    If chkPitchReverse.Checked = True Then
    '        chkPitchReverse.Text = "Reversed"
    '    Else
    '        chkPitchReverse.Text = "Normal"
    '    End If
    '    Call SaveRegSetting(sRootRegistry & "\Settings", "Pitch Reverse", bPitchReverse)
    'End Sub

    'Private Sub chkRollReverse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    bRollReverse = chkRollReverse.Checked
    '    If chkRollReverse.Checked = True Then
    '        chkRollReverse.Text = "Reversed"
    '    Else
    '        chkRollReverse.Text = "Normal"
    '    End If
    '    Call SaveRegSetting(sRootRegistry & "\Settings", "Roll Reverse", bRollReverse)
    'End Sub
    'Private Sub cboMapUpdateRate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call SaveRegSetting(sRootRegistry & "\Settings", "Map Update Hz", nMapUpdateRate)
    'End Sub

End Module
