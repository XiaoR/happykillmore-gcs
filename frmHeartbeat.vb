Public Class frmHeartbeat

    Private Sub frmHeartbeat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nCount As Integer

        AddToDeviceCombo("All", e_DeviceTypes.e_DeviceTypes_None, True)
        AddToDeviceCombo("NMEA", e_DeviceTypes.e_DeviceTypes_NMEA)
        AddToDeviceCombo("Mediatek", e_DeviceTypes.e_DeviceTypes_Mediatek)
        AddToDeviceCombo("Mediatek v1.6", e_DeviceTypes.e_DeviceTypes_Mediatek16)
        AddToDeviceCombo("SiRF (EM406)", e_DeviceTypes.e_DeviceTypes_SiRF)
        AddToDeviceCombo("uBlox", e_DeviceTypes.e_DeviceTypes_uBlox)

        AddToRateCombo("Once", -999, True)
        AddToRateCombo("Every 5 mins", -300)
        AddToRateCombo("Every 2 mins", -120)
        AddToRateCombo("Every minute", -60)
        AddToRateCombo("Every 30 secs", -30)
        AddToRateCombo("Every 20 secs", -20)
        AddToRateCombo("Every 10 secs", -10)
        AddToRateCombo("Every 5 secs", -5)
        AddToRateCombo("1 Hz", 1)
        AddToRateCombo("2 Hz", 2)

        For nCount = 0 To cboDeviceType1.Items.Count - 1
            If CType(cboDeviceType1.Items(nCount), cValueDesc).Value = nHeartbeatDevice1 Then
                cboDeviceType1.SelectedIndex = nCount
            End If
            If CType(cboDeviceType1.Items(nCount), cValueDesc).Value = nHeartbeatDevice2 Then
                cboDeviceType2.SelectedIndex = nCount
            End If
            If CType(cboDeviceType1.Items(nCount), cValueDesc).Value = nHeartbeatDevice3 Then
                cboDeviceType3.SelectedIndex = nCount
            End If
            If CType(cboDeviceType4.Items(nCount), cValueDesc).Value = nHeartbeatDevice4 Then
                cboDeviceType4.SelectedIndex = nCount
            End If
            If CType(cboDeviceType5.Items(nCount), cValueDesc).Value = nHeartbeatDevice5 Then
                cboDeviceType5.SelectedIndex = nCount
            End If
            If CType(cboDeviceType6.Items(nCount), cValueDesc).Value = nHeartbeatDevice6 Then
                cboDeviceType6.SelectedIndex = nCount
            End If
        Next nCount

        For nCount = 0 To cboHeatbeatRate1.Items.Count - 1
            If CType(cboHeatbeatRate1.Items(nCount), cValueDesc).Value = nHeartbeatRate1 Then
                cboHeatbeatRate1.SelectedIndex = nCount
            End If
            If CType(cboHeatbeatRate1.Items(nCount), cValueDesc).Value = nHeartbeatRate2 Then
                cboHeatbeatRate2.SelectedIndex = nCount
            End If
            If CType(cboHeatbeatRate1.Items(nCount), cValueDesc).Value = nHeartbeatRate3 Then
                cboHeatbeatRate3.SelectedIndex = nCount
            End If
            If CType(cboHeatbeatRate1.Items(nCount), cValueDesc).Value = nHeartbeatRate4 Then
                cboHeatbeatRate4.SelectedIndex = nCount
            End If
            If CType(cboHeatbeatRate1.Items(nCount), cValueDesc).Value = nHeartbeatRate5 Then
                cboHeatbeatRate5.SelectedIndex = nCount
            End If
            If CType(cboHeatbeatRate1.Items(nCount), cValueDesc).Value = nHeartbeatRate6 Then
                cboHeatbeatRate6.SelectedIndex = nCount
            End If
        Next nCount

        chkHeartbeat1.Checked = bHeartbeat1
        chkHeartbeat2.Checked = bHeartbeat2
        chkHeartbeat3.Checked = bHeartbeat3
        chkHeartbeat4.Checked = bHeartbeat4
        chkHeartbeat5.Checked = bHeartbeat5
        chkHeartbeat6.Checked = bHeartbeat6

        txtName1.Text = sHeartbeatName1
        txtName2.Text = sHeartbeatName2
        txtName3.Text = sHeartbeatName3
        txtName4.Text = sHeartbeatName4
        txtName5.Text = sHeartbeatName5
        txtName6.Text = sHeartbeatName6

        txtHeatbeat1.Text = Replace(Replace(sHeartbeat1, "<CR>", vbCr, , , CompareMethod.Text), "<LF>", vbLf, , , CompareMethod.Text)
        txtHeatbeat2.Text = Replace(Replace(sHeartbeat2, "<CR>", vbCr, , , CompareMethod.Text), "<LF>", vbLf, , , CompareMethod.Text)
        txtHeatbeat3.Text = Replace(Replace(sHeartbeat3, "<CR>", vbCr, , , CompareMethod.Text), "<LF>", vbLf, , , CompareMethod.Text)
        txtHeatbeat4.Text = Replace(Replace(sHeartbeat4, "<CR>", vbCr, , , CompareMethod.Text), "<LF>", vbLf, , , CompareMethod.Text)
        txtHeatbeat5.Text = Replace(Replace(sHeartbeat5, "<CR>", vbCr, , , CompareMethod.Text), "<LF>", vbLf, , , CompareMethod.Text)
        txtHeatbeat6.Text = Replace(Replace(sHeartbeat6, "<CR>", vbCr, , , CompareMethod.Text), "<LF>", vbLf, , , CompareMethod.Text)
    End Sub
    Private Sub AddToDeviceCombo(ByVal inputString As String, ByVal value As e_DeviceTypes, Optional ByVal clearAll As Boolean = False)
        If clearAll = True Then
            cboDeviceType1.Items.Clear()
            cboDeviceType2.Items.Clear()
            cboDeviceType3.Items.Clear()
            cboDeviceType4.Items.Clear()
            cboDeviceType5.Items.Clear()
            cboDeviceType6.Items.Clear()
        End If

        cboDeviceType1.Items.Add((New cValueDesc(value, inputString)))
        cboDeviceType2.Items.Add((New cValueDesc(value, inputString)))
        cboDeviceType3.Items.Add((New cValueDesc(value, inputString)))
        cboDeviceType4.Items.Add((New cValueDesc(value, inputString)))
        cboDeviceType5.Items.Add((New cValueDesc(value, inputString)))
        cboDeviceType6.Items.Add((New cValueDesc(value, inputString)))
    End Sub
    Private Sub AddToRateCombo(ByVal inputString As String, ByVal value As Integer, Optional ByVal clearAll As Boolean = False)
        If clearAll = True Then
            cboHeatbeatRate1.Items.Clear()
            cboHeatbeatRate2.Items.Clear()
            cboHeatbeatRate3.Items.Clear()
            cboHeatbeatRate4.Items.Clear()
            cboHeatbeatRate5.Items.Clear()
            cboHeatbeatRate6.Items.Clear()
        End If

        cboHeatbeatRate1.Items.Add((New cValueDesc(value, inputString)))
        cboHeatbeatRate2.Items.Add((New cValueDesc(value, inputString)))
        cboHeatbeatRate3.Items.Add((New cValueDesc(value, inputString)))
        cboHeatbeatRate4.Items.Add((New cValueDesc(value, inputString)))
        cboHeatbeatRate5.Items.Add((New cValueDesc(value, inputString)))
        cboHeatbeatRate6.Items.Add((New cValueDesc(value, inputString)))
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        bHeartbeat1 = chkHeartbeat1.Checked
        bHeartbeat2 = chkHeartbeat2.Checked
        bHeartbeat3 = chkHeartbeat3.Checked
        bHeartbeat4 = chkHeartbeat4.Checked
        bHeartbeat5 = chkHeartbeat5.Checked
        bHeartbeat6 = chkHeartbeat6.Checked

        sHeartbeatName1 = txtName1.Text
        sHeartbeatName2 = txtName2.Text
        sHeartbeatName3 = txtName3.Text
        sHeartbeatName4 = txtName4.Text
        sHeartbeatName5 = txtName5.Text
        sHeartbeatName6 = txtName6.Text

        nHeartbeatDevice1 = CType(cboDeviceType1.Items(cboDeviceType1.SelectedIndex), cValueDesc).Value
        nHeartbeatDevice2 = CType(cboDeviceType2.Items(cboDeviceType2.SelectedIndex), cValueDesc).Value
        nHeartbeatDevice3 = CType(cboDeviceType3.Items(cboDeviceType3.SelectedIndex), cValueDesc).Value
        nHeartbeatDevice4 = CType(cboDeviceType3.Items(cboDeviceType4.SelectedIndex), cValueDesc).Value
        nHeartbeatDevice5 = CType(cboDeviceType3.Items(cboDeviceType5.SelectedIndex), cValueDesc).Value
        nHeartbeatDevice6 = CType(cboDeviceType3.Items(cboDeviceType6.SelectedIndex), cValueDesc).Value

        nHeartbeatRate1 = CType(cboHeatbeatRate1.Items(cboHeatbeatRate1.SelectedIndex), cValueDesc).Value
        nHeartbeatRate2 = CType(cboHeatbeatRate2.Items(cboHeatbeatRate2.SelectedIndex), cValueDesc).Value
        nHeartbeatRate3 = CType(cboHeatbeatRate3.Items(cboHeatbeatRate3.SelectedIndex), cValueDesc).Value
        nHeartbeatRate4 = CType(cboHeatbeatRate3.Items(cboHeatbeatRate4.SelectedIndex), cValueDesc).Value
        nHeartbeatRate5 = CType(cboHeatbeatRate3.Items(cboHeatbeatRate5.SelectedIndex), cValueDesc).Value
        nHeartbeatRate6 = CType(cboHeatbeatRate3.Items(cboHeatbeatRate6.SelectedIndex), cValueDesc).Value

        sHeartbeat1 = Replace(Replace(txtHeatbeat1.Text, vbCr, "<CR>", , , CompareMethod.Text), vbLf, "<LF>", , , CompareMethod.Text)
        sHeartbeat2 = Replace(Replace(txtHeatbeat2.Text, vbCr, "<CR>", , , CompareMethod.Text), vbLf, "<LF>", , , CompareMethod.Text)
        sHeartbeat3 = Replace(Replace(txtHeatbeat3.Text, vbCr, "<CR>", , , CompareMethod.Text), vbLf, "<LF>", , , CompareMethod.Text)
        sHeartbeat4 = Replace(Replace(txtHeatbeat4.Text, vbCr, "<CR>", , , CompareMethod.Text), vbLf, "<LF>", , , CompareMethod.Text)
        sHeartbeat5 = Replace(Replace(txtHeatbeat5.Text, vbCr, "<CR>", , , CompareMethod.Text), vbLf, "<LF>", , , CompareMethod.Text)
        sHeartbeat6 = Replace(Replace(txtHeatbeat6.Text, vbCr, "<CR>", , , CompareMethod.Text), vbLf, "<LF>", , , CompareMethod.Text)

        frmMain.bStartup = True
        SaveSettings()
        frmMain.bStartup = False
        Me.Dispose()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Dispose()
    End Sub

    Private Sub cmdDefaults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDefaults.Click
        Dim nRet As Integer

        nRet = MsgBox("Are you sure you want to reset all heartbeats to defaults?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Reset to Defaults")
        If nRet = MsgBoxResult.Yes Then
            DeleteRegSetting(sRootRegistry & "\Settings", "Heartbeat")
            LoadSettings()
            frmHeartbeat_Load(Nothing, Nothing)
        End If
    End Sub
End Class