Public Class frmTrackingCalibrate
    Dim nStartup As Boolean

    Private Sub frmTrackingCalibrate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nCount As Integer

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

        tbarLeft.Value = nTrackingServoLeft
        tbarRight.Value = nTrackingServoRight
        tbarUp.Value = nTrackingServoUp
        tbarDown.Value = nTrackingServoDown

        lblLeft.Text = tbarLeft.Value
        lblRight.Text = tbarRight.Value
        lblUp.Text = tbarUp.Value
        lblDown.Text = tbarDown.Value

        chkBackLobe.Checked = bBackLobeTracker
        chkPrediction.Checked = bTrackingPrediction

        nStartup = False
    End Sub

    Private Sub tbarLeft_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbarLeft.Scroll, tbarRight.Scroll, tbarUp.Scroll, tbarDown.Scroll
        If nStartup = True Then
            Exit Sub
        End If

        Select Case sender.name
            Case "tbarLeft"
                frmMain.SendTrackingServoPanTilt(sender.value, )
                lblLeft.Text = sender.value
            Case "tbarRight"
                frmMain.SendTrackingServoPanTilt(sender.value, )
                lblRight.Text = sender.value
            Case "tbarUp"
                frmMain.SendTrackingServoPanTilt(, sender.value)
                lblUp.Text = sender.value
            Case "tbarDown"
                frmMain.SendTrackingServoPanTilt(, sender.value)
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

        bBackLobeTracker = chkBackLobe.Checked
        bTrackingPrediction = chkPrediction.Checked

        SaveSettings()
        Me.Dispose()
    End Sub

    Private Sub cmdCenterPan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCenterPan.Click
        frmMain.SendTrackingServoPanTilt(1500, )
    End Sub

    Private Sub cmdCenterTilt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCenterTilt.Click
        frmMain.SendTrackingServoPanTilt(, 1500)
    End Sub
End Class