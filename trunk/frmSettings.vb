Imports System.Speech
Public Class frmSettings
    Dim aLanguages(0) As String
    Private Sub ResetForm()
        LoadLanguageFile()

        GetResString(Me, "Settings")

        GetResString(tabGeneral, "General")
        GetResString(lblLanguage, "Language", True)
        GetResString(lblDistanceUnits, "Distance_Units", True)
        GetResString(lblSpeedUnits, "Speed_Units", True)
        GetResString(lblMaxSpeed, "Max_Speed", True)
        GetResString(lbl3DModel, "_3D_Model", True)
        GetResString(lblPitchReverse, "Pitch", True)
        GetResString(lblRollReverse, "Roll", True)
        GetResString(lblYawReverse, "Yaw", True)
        GetResString(lblHeadingReverse, "Heading", True)
        GetResString(lblThrottleChannel, "Throttle_Channel", True)
        GetResString(lblAltitudeOffset, "Altitude_Offset", True)

        GetResString(tabGoogleEarth, "Google_Earth")
        GetResString(grpFlightPath, "Google_Earth_Flight_Path")
        GetResString(lblMapUpdateRate, "Map_Update_Rate", True)
        GetResString(lblFlightPathColor, "Flight_Path_Color", True)
        GetResString(lblFlightPathThickness, "Path_Thickness", True)
        GetResString(lblFlightExtrude, "Extrude", True)
        GetResString(lblFlightOpacity, "Path_Opacity", True)

        GetResString(grpMissionPath, "Mission_Path")
        GetResString(lblMissionPathColor, "Flight_Path_Color", True)
        GetResString(lblMissionPathThickness, "Path_Thickness", True)
        GetResString(lblMissionExtrude, "Extrude", True)
        GetResString(lblMissionOpacity, "Path_Opacity", True)

        GetResString(grpGoogleEarthFeatures, "Features")
        GetResString(lblGEBorders, "GE_Borders", True)
        GetResString(lblGEBuildings, "GE_Buildings", True)
        GetResString(lblGERoads, "GE_Roads", True)
        GetResString(lblGETerrain, "GE_Terrain", True)
        GetResString(lblGETrees, "GE_Trees", True)

        GetResString(tabInstruments, "Instruments")
        GetResString(grpInstrumentSelection, "Instrument_Selection")
        GetResString(chkInstSpeed, "AirGround_Speed")
        GetResString(chkInstAltimeter, "Altimeter")
        GetResString(chkInstAttitude, "Attitude")
        GetResString(chkInstHeading, "Heading")
        GetResString(chkInstVertical, "Vertical_Speed")
        GetResString(chkInst3DModel, "_3D_Model")
        GetResString(chkInstTurn, "Turn_Coordinator")
        GetResString(chkInstBattery, "Battery_Throttle")

        GetResString(grpBatteryThrottle, "Battery_Throttle_Settings")
        GetResString(lblVoltageMin, "Min_Voltage", True)
        GetResString(lblVoltageMax, "Max_Voltage", True)
        GetResString(lblVoltageColor, "Voltage_Color", True)

        GetResString(lblAmperageMax, "Max_Amperage", True)
        GetResString(lblAmperageColor, "Amperage_Color", True)

        GetResString(lblMahMin, "Min_MAH", True)
        GetResString(lblMahMax, "Max_MAH", True)
        GetResString(lblMahColor, "MAH_Color", True)

        GetResString(lblThrottleColor, "Throttle_Color", True)

        GetResString(cmdSave, "Save")
        GetResString(cmdCancel, "Cancel")

        GetResString(chkPitchReverse, "Normal")
        GetResString(chkRollReverse, "Normal")
        GetResString(chkYawReverse, "Normal")
        GetResString(chkHeadingReverse, "Normal")

        GetResString(tabSpeech, "Speech")
        GetResString(lblVoice, "Voice", True)
        GetResString(chkAnnounceWaypoints, "Announce_Waypoints")
        GetResString(chkAnnounceModeChange, "Announce_ModeChange")
        GetResString(chkAnnounceRegularInterval, "Announce_Regular_Interval")
        GetResString(lblSpeechInterval, "Interval")
        GetResString(lblHelp, "Help")


    End Sub
    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nCount As Integer
        Dim sFolderName As String

        Dim strAllVoices() As String = ReturnAllSpeechSynthesisVoices()

        ResetForm()

        LoadLanguages(cboLanguage)

        With cboVoice
            .Items.Clear()
            For Each Str As String In strAllVoices
                .Items.Add(Str)
                If UCase(sSpeechVoice) = UCase(Str) Then
                    .SelectedIndex = .Items.Count - 1
                End If
            Next
            If .SelectedIndex = -1 And .Items.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With

        For nCount = 1 To 20
            If nCount <= 5 Then
                cboMapUpdateRate.Items.Add(nCount & " Hz")
            End If
        Next
        cboMapUpdateRate.SelectedIndex = nMapUpdateRate - 1

        With cbo3DModel
            .Items.Clear()
            sFolderName = Dir(GetRootPath() & "3D Models\", FileAttribute.Directory)
            Do While sFolderName <> ""
                If Microsoft.VisualBasic.Left(sFolderName, 1) <> "." Then
                    .Items.Add(sFolderName)
                End If
                sFolderName = Dir()
            Loop
            Try
                .Text = sModelName
            Catch
                .Text = "EasyStar"
            End Try
        End With

        With cboSpeechInterval
            .Items.Add("10 " & GetResString(, "secs"))
            .Items.Add("15 " & GetResString(, "secs"))
            .Items.Add("20 " & GetResString(, "secs"))
            .Items.Add("25 " & GetResString(, "secs"))
            .Items.Add("30 " & GetResString(, "secs"))
            .Items.Add("40 " & GetResString(, "secs"))
            .Items.Add("45 " & GetResString(, "secs"))
            .Items.Add("60 " & GetResString(, "secs"))
            .Items.Add("120 " & GetResString(, "secs"))
            .Items.Add("180 " & GetResString(, "secs"))
            .Items.Add("240 " & GetResString(, "secs"))
            .Text = nSpeechInterval & " " & GetResString(, "secs")
        End With

        With cboMaxSpeed
            For nCount = 40 To 280 Step 40
                .Items.Add(nCount)
            Next
            .Text = nMaxSpeed
        End With

        With cboThrottleChannel
            .Items.Clear()
            .Items.Add(GetResString(, "None"))
            For nCount = 1 To 8
                .Items.Add("CH#" & nCount)
            Next
            .SelectedIndex = nThrottleChannel
        End With

        cboVoltageColor.Items.Clear()
        cboAmperageColor.Items.Clear()
        cboMAHColor.Items.Clear()
        cboThrottleColor.Items.Clear()
        For nCount = 0 To e_InstrumentColor_Max
            cboVoltageColor.Items.Add(LookupInstrumentColorName(nCount))
            cboAmperageColor.Items.Add(LookupInstrumentColorName(nCount))
            cboMAHColor.Items.Add(LookupInstrumentColorName(nCount))
            cboThrottleColor.Items.Add(LookupInstrumentColorName(nCount))
        Next

        cboVoltageColor.SelectedIndex = oBatteryColor
        cboAmperageColor.SelectedIndex = oAmperageColor
        cboMAHColor.SelectedIndex = oMAHColor
        cboThrottleColor.SelectedIndex = oThrottleColor

        txtVoltageMax.Text = nBatteryMax
        txtVoltageMin.Text = nBatteryMin

        txtAmperageMax.Text = nAmperageMax

        txtMAHMax.Text = nMAHMax
        txtMAHMin.Text = nMAHMin

        chkPitchReverse.Checked = bPitchReverse
        chkRollReverse.Checked = bRollReverse
        chkYawReverse.Checked = bYawReverse
        chkHeadingReverse.Checked = bHeadingReverse

        chkFlightExtrude.Checked = bFlightExtrude
        cmdFlightColor.BackColor = Color.FromArgb(255, Convert.ToInt32(Mid(sFlightColor, 7, 2), 16), Convert.ToInt32(Mid(sFlightColor, 5, 2), 16), Convert.ToInt32(Mid(sFlightColor, 3, 2), 16))
        tbarFlightWidth.Value = nFlightWidth
        tbarFlightOpacity.Value = Convert.ToInt32(Mid(sFlightColor, 1, 2), 16)

        chkMissionExtrude.Checked = bMissionExtrude
        cmdMissionColor.BackColor = Color.FromArgb(255, Convert.ToInt32(Mid(sMissionColor, 7, 2), 16), Convert.ToInt32(Mid(sMissionColor, 5, 2), 16), Convert.ToInt32(Mid(sMissionColor, 3, 2), 16))
        tbarMissionWidth.Value = nMissionWidth
        tbarMissionOpacity.Value = Convert.ToInt32(Mid(sMissionColor, 1, 2), 16)

        chkGEBorders.Checked = bGEBorders
        chkGEBuildings.Checked = bGEBuildings
        chkGERoads.Checked = bGERoads
        chkGETerrain.Checked = bGETerrain
        chkGETrees.Checked = bGETrees

        With cboDistanceUnits
            .Items.Add(GetResString(, "Feet"))
            .Items.Add(GetResString(, "Meters"))
            .SelectedIndex = eDistanceUnits
        End With

        With cboSpeedUnits
            .Items.Add(GetResString(, "Knots"))
            .Items.Add(GetResString(, "KPH"))
            .Items.Add(GetResString(, "MPH"))
            .Items.Add(GetResString(, "m_s"))
            .SelectedIndex = eSpeedUnits
        End With

        With cboAltitudeOffset
            .Items.Add(GetResString(, "From_Sealevel", , , , , , , "From Sea Level"))
            .Items.Add(GetResString(, "From_HomeAlt", , , , , , , "From Home Alt"))
            .SelectedIndex = eAltOffset
        End With

        chkInst3DModel.Enabled = Not b3DModelFailed
        chkInstSpeed.Checked = bInstruments(e_Instruments.e_Instruments_Speed)
        chkInstAltimeter.Checked = bInstruments(e_Instruments.e_Instruments_Altimeter)
        chkInstAttitude.Checked = bInstruments(e_Instruments.e_Instruments_Attitude)
        chkInstHeading.Checked = bInstruments(e_Instruments.e_Instruments_Heading)
        chkInst3DModel.Checked = bInstruments(e_Instruments.e_Instruments_3DModel)
        chkInstVertical.Checked = bInstruments(e_Instruments.e_Instruments_Vertical)
        chkInstTurn.Checked = bInstruments(e_Instruments.e_Instruments_Turn)
        chkInstBattery.Checked = bInstruments(e_Instruments.e_Instruments_Battery)

        chkAnnounceWaypoints.Checked = bAnnounceWaypoints
        txtAnnounceWaypoints.Text = sSpeechWaypoint
        chkAnnounceWaypoints_CheckedChanged(Nothing, Nothing)
        chkAnnounceModeChange.Checked = bAnnounceModeChange
        txtAnnounceModeChange.Text = sSpeechModeChange
        chkAnnounceModeChange_CheckedChanged(Nothing, Nothing)
        chkAnnounceRegularInterval.Checked = bAnnounceRegularInterval
        txtAnnounceRegularInterval.Text = sSpeechRegularInterval
        chkAnnounceRegularInterval_CheckedChanged(Nothing, Nothing)

    End Sub
    Private Sub LoadLanguages(ByVal inputCombo As ComboBox)
        Dim sFileContents As String
        Dim sSplit() As String
        Dim sSplit2() As String
        Dim nCount As Integer
        Dim sRegistryLanguageFile As String

        sRegistryLanguageFile = GetRegSetting(sRootRegistry & "\Settings", "Language File", "Default")
        sFileContents = GetFileContents(GetRootPath() & "Language\Languages.txt")
        sSplit = Split(sFileContents, vbCrLf)
        ReDim aLanguages(0 To UBound(sSplit) + 1)
        With inputCombo
            .Items.Clear()
            .Items.Add(GetResString(, "Default Language", , , , , , , "Default Language"))
            aLanguages(0) = "Default"
            For nCount = 0 To UBound(sSplit)
                If Trim(sSplit(nCount)) <> "" Then
                    sSplit2 = Split(sSplit(nCount), ";")
                    .Items.Add(sSplit2(1))
                    aLanguages(.Items.Count - 1) = sSplit2(0)

                    If sRegistryLanguageFile = sSplit2(0) Then
                        .SelectedIndex = .Items.Count - 1
                    End If
                End If
            Next

            If .SelectedIndex = -1 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Dispose()
    End Sub
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim nCount As Integer

        eDistanceUnits = cboDistanceUnits.SelectedIndex
        eSpeedUnits = cboSpeedUnits.SelectedIndex
        nMaxSpeed = Convert.ToInt32(cboMaxSpeed.Text)
        bPitchReverse = chkPitchReverse.Checked
        bRollReverse = chkRollReverse.Checked
        bYawReverse = chkYawReverse.Checked
        bHeadingReverse = chkHeadingReverse.Checked
        nThrottleChannel = cboThrottleChannel.SelectedIndex
        eAltOffset = cboAltitudeOffset.SelectedIndex

        nMapUpdateRate = cboMapUpdateRate.SelectedIndex + 1

        sFlightColor = GetColor(cmdFlightColor.BackColor, tbarFlightOpacity.Value)
        nFlightWidth = tbarFlightWidth.Value
        bFlightExtrude = chkFlightExtrude.Checked

        sMissionColor = GetColor(cmdMissionColor.BackColor, tbarMissionOpacity.Value)
        nMissionWidth = tbarMissionWidth.Value
        bMissionExtrude = chkMissionExtrude.Checked

        If cbo3DModel.Text <> sModelName Then
            sModelName = cbo3DModel.Text
            frmMain._3DMesh1.DrawMesh(GetPitch(nPitch), GetRoll(nRoll), GetYaw(nYaw), True, sModelName, GetRootPath() & "3D Models\")
            frmMain.WebBrowser1.Invoke(New frmMain.MyDelegate(AddressOf frmMain.loadModel))
        End If

        sLanguageFile = aLanguages(cboLanguage.SelectedIndex)

        bInstruments(e_Instruments.e_Instruments_Speed) = chkInstSpeed.Checked
        bInstruments(e_Instruments.e_Instruments_Altimeter) = chkInstAltimeter.Checked
        bInstruments(e_Instruments.e_Instruments_Attitude) = chkInstAttitude.Checked
        bInstruments(e_Instruments.e_Instruments_Heading) = chkInstHeading.Checked
        bInstruments(e_Instruments.e_Instruments_3DModel) = chkInst3DModel.Checked
        bInstruments(e_Instruments.e_Instruments_Vertical) = chkInstVertical.Checked
        bInstruments(e_Instruments.e_Instruments_Turn) = chkInstTurn.Checked
        bInstruments(e_Instruments.e_Instruments_Battery) = chkInstBattery.Checked

        On Error Resume Next
        nBatteryMax = Convert.ToSingle(txtVoltageMax.Text)
        nBatteryMin = Convert.ToSingle(txtVoltageMin.Text)
        oBatteryColor = cboVoltageColor.SelectedIndex

        nAmperageMax = Convert.ToSingle(txtAmperageMax.Text)

        nMAHMax = Convert.ToSingle(txtMAHMax.Text)
        nMAHMin = Convert.ToSingle(txtMAHMin.Text)
        oMAHColor = cboMAHColor.SelectedIndex

        oThrottleColor = cboThrottleColor.SelectedIndex

        sSpeechVoice = cboVoice.Text
        bAnnounceWaypoints = chkAnnounceWaypoints.Checked
        sSpeechWaypoint = txtAnnounceWaypoints.Text
        bAnnounceModeChange = chkAnnounceModeChange.Checked
        sSpeechModeChange = txtAnnounceModeChange.Text
        bAnnounceRegularInterval = chkAnnounceRegularInterval.Checked
        sSpeechRegularInterval = txtAnnounceRegularInterval.Text
        nSpeechInterval = cboSpeechInterval.Text.Substring(0, InStr(cboSpeechInterval.Text, " ") - 1)

        bGEBorders = chkGEBorders.Checked
        bGEBuildings = chkGEBuildings.Checked
        bGERoads = chkGERoads.Checked
        bGETerrain = chkGETerrain.Checked
        bGETrees = chkGETrees.Checked
        frmMain.WebBrowser1.Invoke(New frmMain.MyDelegate(AddressOf frmMain.LoadGEFeatures))
        On Error GoTo 0

        SaveSettings()
        Me.Dispose()
    End Sub

    Private Sub cmdFlightColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFlightColor.Click
        If Me.ColorDialog1.ShowDialog = DialogResult.OK Then
            cmdFlightColor.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub chkRollReverse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRollReverse.CheckedChanged, chkPitchReverse.CheckedChanged, chkYawReverse.CheckedChanged, chkHeadingReverse.CheckedChanged
        If chkRollReverse.Checked = True Then
            GetResString(chkRollReverse, "Reversed")
        Else
            GetResString(chkRollReverse, "Normal")
        End If
    End Sub

    Private Sub cmdMissionColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMissionColor.Click
        If Me.ColorDialog1.ShowDialog = DialogResult.OK Then
            cmdMissionColor.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub chkAnnounceWaypoints_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAnnounceWaypoints.CheckedChanged
        txtAnnounceWaypoints.Enabled = chkAnnounceWaypoints.Checked
        cmdWaypointPlay.Enabled = chkAnnounceWaypoints.Checked
    End Sub

    Private Sub chkAnnounceRegularInterval_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAnnounceRegularInterval.CheckedChanged
        txtAnnounceRegularInterval.Enabled = chkAnnounceRegularInterval.Checked
        cmdRegularIntervalPlay.Enabled = chkAnnounceRegularInterval.Checked
        lblSpeechInterval.Enabled = chkAnnounceRegularInterval.Checked
        cboSpeechInterval.Enabled = chkAnnounceRegularInterval.Checked
    End Sub

    Private Sub cmdWaypointPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWaypointPlay.Click
        PlayMessage(txtAnnounceWaypoints.Text, cboVoice.Text)
    End Sub

    Private Sub cmdModeChangPlaye_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdModeChangePlay.Click
        PlayMessage(txtAnnounceModeChange.Text, cboVoice.Text)
    End Sub

    Private Sub chkAnnounceModeChange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAnnounceModeChange.CheckedChanged
        txtAnnounceModeChange.Enabled = chkAnnounceModeChange.Checked
        cmdModeChangePlay.Enabled = chkAnnounceModeChange.Checked
    End Sub

    Private Sub chkGERoads_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGERoads.CheckedChanged, chkGEBorders.CheckedChanged, chkGEBuildings.CheckedChanged, chkGETerrain.CheckedChanged, chkGETrees.CheckedChanged, chkFlightExtrude.CheckedChanged, chkMissionExtrude.CheckedChanged
        If sender.Checked = True Then
            sender.Text = GetResString(, "Yes")
        Else
            sender.Text = GetResString(, "No")
        End If
    End Sub

    Private Sub lblHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblHelp.Click
        System.Diagnostics.Process.Start("http://code.google.com/p/happykillmore-gcs/wiki/SpeechSettings")
    End Sub
    Private Sub frmSettings_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F9 Then
            If Dir(GetRootPath() & "Language\StringResourceEditor.exe", FileAttribute.Normal) <> "" Then
                System.Diagnostics.Process.Start(GetRootPath() & "Language\StringResourceEditor.exe", """" & GetRootPath() & "Language\Strings.resx""")
            End If
        ElseIf e.KeyCode = Keys.F5 Then
            sLanguageFile = GetRegSetting(sRootRegistry & "\Settings", "Language File", "Default")
            ResetForm()
        ElseIf e.KeyCode = Keys.F4 Then
            sLanguageFile = "en"
            ResetForm()
        End If
    End Sub

    Private Sub cmdRegularIntervalPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRegularIntervalPlay.Click
        PlayMessage(txtAnnounceRegularInterval.Text, cboVoice.Text)
    End Sub

End Class