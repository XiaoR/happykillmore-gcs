Public Class frmTrackingCalibrate
    Dim nStartup As Boolean

    Private Sub frmTrackingCalibrate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nCount As Integer
        Dim nMinServo As Integer
        Dim nMaxServo As Integer

        lblMiniSSCNote.Visible = False
        Select Case nTrackingOutputType
            Case 4
                nMinServo = 1
                nMaxServo = 6
                ShowServoSelect(True)
            Case 5
                nMinServo = 0
                nMaxServo = 7
                ShowServoSelect(True)
            Case 6
                lblMiniSSCNote.Visible = True
                nMinServo = 0
                nMaxServo = 255
                ShowServoSelect(True)
            Case Else
                ShowServoSelect(False)
        End Select

        If nTrackingOutputType >= 4 And nTrackingOutputType <= 6 Then
            cboPanServo.Items.Clear()
            cboTiltServo.Items.Clear()
            For nCount = nMinServo To nMaxServo
                cboPanServo.Items.Add(nCount)
                cboTiltServo.Items.Add(nCount)
            Next
            cboPanServo.Text = nTrackingServoNumberPan
            cboTiltServo.Text = nTrackingServoNumberTilt
        End If

        Me.Text = frmMain.cboOutputTypeTracking.Text & " " & GetResString(, "Tracking Calibration")

        nStartup = True
        With cboLeft
            For nCount = -180 To 0
                .Items.Add(nCount)
            Next
            .Text = nTrackingAngleLeft
        End With

        With cboRight
            For nCount = 0 To 180
                .Items.Add(nCount)
            Next
            .Text = nTrackingAngleRight
        End With

        With cboUp
            For nCount = 0 To 180
                .Items.Add(nCount)
            Next
            .Text = nTrackingAngleUp
        End With

        With cboDown
            For nCount = -180 To 0
                .Items.Add(nCount)
            Next
            .Text = nTrackingAngleDown
        End With

        If nTrackingOutputType = 5 Then
            tbarLeft.Minimum = 500
            tbarRight.Minimum = 500
            tbarUp.Minimum = 500
            tbarDown.Minimum = 500

            tbarLeft.Maximum = 5500
            tbarRight.Maximum = 5500
            tbarUp.Maximum = 5500
            tbarDown.Maximum = 5500
        ElseIf nTrackingOutputType = 6 Then
            tbarLeft.Minimum = 0
            tbarRight.Minimum = 0
            tbarUp.Minimum = 0
            tbarDown.Minimum = 0

            tbarLeft.Maximum = 254
            tbarRight.Maximum = 254
            tbarUp.Maximum = 254
            tbarDown.Maximum = 254
        End If

        tbarLeft.Value = nTrackingServoLeft
        tbarRight.Value = nTrackingServoRight
        tbarUp.Value = nTrackingServoUp
        tbarDown.Value = nTrackingServoDown

        lblLeft.Text = tbarLeft.Value
        lblRight.Text = tbarRight.Value
        lblUp.Text = tbarUp.Value
        lblDown.Text = tbarDown.Value

        chkBackLobe.Checked = bBackLobeTracker

        nStartup = False
    End Sub
    Private Sub ShowServoSelect(ByVal enabled As Boolean)
        lblPanServo.Visible = enabled
        lblTiltServo.Visible = enabled
        cboPanServo.Visible = enabled
        cboTiltServo.Visible = enabled
    End Sub
    Private Sub tbarLeft_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbarLeft.Scroll, tbarRight.Scroll, tbarUp.Scroll, tbarDown.Scroll
        Dim nPanServoLocal As Integer
        Dim nTiltServoLocal As Integer

        If nStartup = True Then
            Exit Sub
        End If

        If cboPanServo.Visible = True Then
            nPanServoLocal = Convert.ToInt32(cboPanServo.Text)
        Else
            nPanServoLocal = -1
        End If
        If cboTiltServo.Visible = True Then
            nTiltServoLocal = Convert.ToInt32(cboTiltServo.Text)
        Else
            nTiltServoLocal = -1
        End If

        Select Case sender.name
            Case "tbarLeft"
                frmMain.SendTrackerMessage(nPanServoLocal, sender.value)
                lblLeft.Text = sender.value
            Case "tbarRight"
                frmMain.SendTrackerMessage(nPanServoLocal, sender.value)
                lblRight.Text = sender.value
            Case "tbarUp"
                frmMain.SendTrackerMessage(nTiltServoLocal, , sender.value)
                lblUp.Text = sender.value
            Case "tbarDown"
                frmMain.SendTrackerMessage(nTiltServoLocal, , sender.value)
                lblDown.Text = sender.value
        End Select
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Dispose()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        nTrackingAngleLeft = CLng(cboLeft.Text)
        nTrackingAngleRight = CLng(cboRight.Text)
        nTrackingAngleUp = CLng(cboUp.Text)
        nTrackingAngleDown = CLng(cboDown.Text)

        nTrackingServoLeft = tbarLeft.Value
        nTrackingServoRight = tbarRight.Value
        nTrackingServoUp = tbarUp.Value
        nTrackingServoDown = tbarDown.Value

        If cboPanServo.Visible = True Then
            nTrackingServoNumberPan = cboPanServo.Text
        End If

        If cboTiltServo.Visible = True Then
            nTrackingServoNumberTilt = cboTiltServo.Text
        End If

        bBackLobeTracker = chkBackLobe.Checked

        SaveSettings()
        frmMain.cboOutputTypeTracking_SelectedIndexChanged(Nothing, Nothing)
        Me.Dispose()
    End Sub

    Private Sub cmdCenterPan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCenterPan.Click
        Dim nPanServoLocal As Integer
        If cboPanServo.Visible = True Then
            nPanServoLocal = Convert.ToInt32(cboPanServo.Text)
        Else
            nPanServoLocal = -1
        End If

        frmMain.SendTrackerMessage(nPanServoLocal, (tbarLeft.Value + tbarRight.Value) / 2, )
    End Sub

    Private Sub cmdCenterTilt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCenterTilt.Click
        Dim nTiltServoLocal As Integer
        If cboTiltServo.Visible = True Then
            nTiltServoLocal = Convert.ToInt32(cboTiltServo.Text)
        Else
            nTiltServoLocal = -1
        End If
        frmMain.SendTrackerMessage(nTiltServoLocal, , (tbarUp.Value + tbarDown.Value) / 2)
    End Sub
End Class