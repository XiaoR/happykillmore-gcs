Public Class frmSettings

    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nCount As Integer
        For nCount = 1 To 20
            If nCount <= 5 Then
                cboMapUpdateRate.Items.Add(nCount & " Hz")
            End If
        Next
        cboMapUpdateRate.SelectedIndex = nMapUpdateRate - 1

        With cbo3DModel
            .Items.Clear()
            .Items.Add("EasyStar")
            .Items.Add("FunJet")
            '.Items.Add("-mi- Yellow Plane")
            '.Items.Add("Firecracker")
            '.Items.Add("T-Rex 450")
            .Items.Add("AeroQuad")
            Try
                .Text = sModelName
            Catch
                .Text = "EasyStar"
            End Try
        End With

        With cboMaxSpeed
            For nCount = 40 To 200 Step 40
                .Items.Add(nCount)
            Next
            .Text = nMaxSpeed
        End With

        chkPitchReverse.Checked = bPitchReverse
        chkRollReverse.Checked = bRollReverse
        chkFlightExtrude.Checked = bFlightExtrude

        cmdFlightColor.BackColor = Color.FromArgb(255, Convert.ToInt32(Mid(sFlightColor, 7, 2), 16), Convert.ToInt32(Mid(sFlightColor, 5, 2), 16), Convert.ToInt32(Mid(sFlightColor, 3, 2), 16))
        tbarFlightWidth.Value = nFlightWidth

        With cboDistanceUnits
            .Items.Add("Feet")
            .Items.Add("Meters")
            .SelectedIndex = eDistanceUnits
        End With

        With cboSpeedUnits
            .Items.Add("Knots")
            .Items.Add("KPH")
            .Items.Add("MPH")
            .Items.Add("M/S")
            .SelectedIndex = eSpeedUnits
        End With
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Dispose()
    End Sub
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        eDistanceUnits = cboDistanceUnits.SelectedIndex
        eSpeedUnits = cboSpeedUnits.SelectedIndex
        nMaxSpeed = Convert.ToInt32(cboMaxSpeed.Text)
        bPitchReverse = chkPitchReverse.Checked
        bRollReverse = chkRollReverse.Checked

        nMapUpdateRate = cboMapUpdateRate.SelectedIndex + 1
        sFlightColor = GetColor(cmdFlightColor.BackColor)
        nFlightWidth = tbarFlightWidth.Value
        bFlightExtrude = chkFlightExtrude.Checked

        If cbo3DModel.Text <> sModelName Then
            sModelName = cbo3DModel.Text
            frmMain._3DMesh1.DrawMesh(IIf(bPitchReverse = True, -1, 1) * nPitch, IIf(bRollReverse = True, -1, 1) * nRoll, nYaw, True, sModelName, GetRootPath() & "3D Models\")
            frmMain.WebBrowser1.Invoke(New frmMain.MyDelegate(AddressOf frmMain.loadModel))
        End If

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
            chkPitchReverse.Text = "Reversed"
        Else
            chkPitchReverse.Text = "Normal"
        End If
    End Sub

    Private Sub chkRollReverse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRollReverse.CheckedChanged
        If chkRollReverse.Checked = True Then
            chkRollReverse.Text = "Reversed"
        Else
            chkRollReverse.Text = "Normal"
        End If
    End Sub
    Private Sub chkFlightExtrude_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFlightExtrude.CheckedChanged
        If chkFlightExtrude.Checked = True Then
            chkFlightExtrude.Text = "Yes"
        Else
            chkFlightExtrude.Text = "No"
        End If
    End Sub

End Class