Public Class frmSettings
    Dim aLanguages(0) As String
    Private Sub ResetForm()
        GetResString(Me, "Settings")

        GetResString(grpGeneral, "General")
        GetResString(lblLanguageLabel, "Language", True)
        GetResString(lblDistanceUnits, "Distance_Units", True)
        GetResString(lblSpeedUnits, "Speed_Units", True)
        GetResString(lblMaxSpeed, "Max_Speed", True)
        GetResString(lbl3DModel, "_3D_Model", True)
        GetResString(lblPitch, "Pitch", True)
        GetResString(lblRoll, "Roll", True)
        GetResString(lblYaw, "Yaw", True)
        GetResString(lblHeading, "Heading", True)
        GetResString(lblThrottleChannel, "Throttle_Channel", True)

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

    End Sub
    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nCount As Integer
        Dim sFolderName As String

        ResetForm()

        LoadLanguages(cboLanguage)

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

        chkInst3DModel.Enabled = Not b3DModelFailed
        chkInstSpeed.Checked = bInstruments(e_Instruments.e_Instruments_Speed)
        chkInstAltimeter.Checked = bInstruments(e_Instruments.e_Instruments_Altimeter)
        chkInstAttitude.Checked = bInstruments(e_Instruments.e_Instruments_Attitude)
        chkInstHeading.Checked = bInstruments(e_Instruments.e_Instruments_Heading)
        chkInst3DModel.Checked = bInstruments(e_Instruments.e_Instruments_3DModel)
        chkInstVertical.Checked = bInstruments(e_Instruments.e_Instruments_Vertical)
        chkInstTurn.Checked = bInstruments(e_Instruments.e_Instruments_Turn)
        chkInstBattery.Checked = bInstruments(e_Instruments.e_Instruments_Battery)

    End Sub
    Private Sub LoadLanguages(ByVal inputCombo As ComboBox)
        Dim sFileContents As String
        Dim sSplit() As String
        Dim sSplit2() As String
        Dim nCount As Integer

        sFileContents = GetFileContents(GetRootPath() & "Language\Languages.txt")
        sSplit = Split(sFileContents, vbCrLf)
        ReDim aLanguages(0 To UBound(sSplit) + 1)
        With inputCombo
            .Items.Clear()
            .Items.Add(GetResString(, "Default Language"))
            aLanguages(0) = "Default"
            For nCount = 0 To UBound(sSplit)
                If Trim(sSplit(nCount)) <> "" Then
                    sSplit2 = Split(sSplit(nCount), ";")
                    .Items.Add(sSplit2(1))
                    aLanguages(.Items.Count - 1) = sSplit2(0)

                    If sLanguageFile = sSplit2(0) Then
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
        On Error GoTo 0

        SaveSettings()
        Me.Dispose()
    End Sub

    Private Sub cmdFlightColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFlightColor.Click
        If Me.ColorDialog1.ShowDialog = DialogResult.OK Then
            cmdFlightColor.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub chkPitchReverse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPitchReverse.CheckedChanged
        If chkPitchReverse.Checked = True Then
            GetResString(chkPitchReverse, "Reversed")
        Else
            GetResString(chkPitchReverse, "Normal")
        End If
    End Sub

    Private Sub chkRollReverse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRollReverse.CheckedChanged
        If chkRollReverse.Checked = True Then
            GetResString(chkRollReverse, "Reversed")
        Else
            GetResString(chkRollReverse, "Normal")
        End If
    End Sub
    Private Sub chkFlightExtrude_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFlightExtrude.CheckedChanged
        If chkFlightExtrude.Checked = True Then
            chkFlightExtrude.Text = GetResString(, "Yes")
        Else
            chkFlightExtrude.Text = GetResString(, "No")
        End If
    End Sub

    Private Sub chkYawReverse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkYawReverse.CheckedChanged
        If chkYawReverse.Checked = True Then
            GetResString(chkYawReverse, "Reversed")
        Else
            GetResString(chkYawReverse, "Normal")
        End If
    End Sub

    Private Sub chkHeadingReverse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHeadingReverse.CheckedChanged
        If chkHeadingReverse.Checked = True Then
            GetResString(chkHeadingReverse, "Reversed")
        Else
            GetResString(chkHeadingReverse, "Normal")
        End If
    End Sub

    Private Sub chkMissionExtrude_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMissionExtrude.CheckedChanged
        If chkMissionExtrude.Checked = True Then
            chkMissionExtrude.Text = GetResString(, "Yes")
        Else
            chkMissionExtrude.Text = GetResString(, "No")
        End If
    End Sub

    Private Sub cmdMissionColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMissionColor.Click
        If Me.ColorDialog1.ShowDialog = DialogResult.OK Then
            cmdMissionColor.BackColor = ColorDialog1.Color
        End If
    End Sub
End Class