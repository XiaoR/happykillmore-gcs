Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Class frmJoystick
    Private jst As JoystickInterface.Joystick
    Private bLocked As Boolean = False
    Private sticks As String()

    Private Sub frmJoystick_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nCount As Integer

        bLocked = True
        ' grab the joystick

        lblMin1.Text = nJoystickThrottleMin
        lblMin2.Text = nJoystickElevatorMin
        lblMin3.Text = nJoystickAileronMin
        lblMin4.Text = nJoystickRudderMin
        lblMin5.Text = nJoystickModeMin

        lblMax1.Text = nJoystickThrottleMax
        lblMax2.Text = nJoystickElevatorMax
        lblMax3.Text = nJoystickAileronMax
        lblMax4.Text = nJoystickRudderMax
        lblMax5.Text = nJoystickModeMax

        cmdSearch_Click(Nothing, Nothing)
        ' add the axis controls to the axis container
        AddToJoystickCombo("None", True)

        AddToJoystickCombo("Axis 1 (Right X)")
        AddToJoystickCombo("Axis 2 (Right Y)")
        AddToJoystickCombo("Axis 3 (Right Z)")

        AddToJoystickCombo("Axis 4 (Left X)")
        AddToJoystickCombo("Axis 5 (Left Y)")
        AddToJoystickCombo("Axis 6 (Left Z)")

        AddToJoystickCombo("Axis 7 (D-Pad X)")
        AddToJoystickCombo("Axis 8 (D-Pad Y)")

        ' add the button controls to the button container
        'For i As Integer = 1 To jst.Buttons.Length
        '    AddToJoystickCombo("Button" & i)
        'Next

        With cboDefaultModes
            .Items.Clear()
            .Items.Add("Custom")
            .Items.Add("Mode 1")
            .Items.Add("Mode 2")
            .Items.Add("Mode 3")
            .Items.Add("Mode 4")
        End With

        AddToServoCombo()

        'AddToCenterCombo("None", True)
        'AddToCenterCombo("Slow")
        'AddToCenterCombo("Fast")

        ' start updating positions

        cboJoystick1.SelectedIndex = nJoystickThrottle + 1
        cboJoystick2.SelectedIndex = nJoystickElevator + 1
        cboJoystick3.SelectedIndex = nJoystickAileron + 1
        cboJoystick4.SelectedIndex = nJoystickRudder + 1
        cboJoystick5.SelectedIndex = nJoystickMode + 1

        chkJoystickReverse1.Checked = bJoystickThrottleReverse
        chkJoystickReverse2.Checked = bJoystickElevatorReverse
        chkJoystickReverse3.Checked = bJoystickAileronReverse
        chkJoystickReverse4.Checked = bJoystickRudderReverse
        chkJoystickReverse5.Checked = bJoystickModeReverse

        cboServo1.SelectedIndex = nJoystickThrottleServo
        cboServo2.SelectedIndex = nJoystickElevatorServo
        cboServo3.SelectedIndex = nJoystickAileronServo
        cboServo4.SelectedIndex = nJoystickRudderServo
        cboServo5.SelectedIndex = nJoystickModeServo

        bLocked = False
        cboJoystick1_SelectedIndexChanged(Nothing, Nothing)

        tmrJoystick.Enabled = True

    End Sub

    Private Sub AddToJoystickCombo(ByVal inputString As String, Optional ByVal withClear As Boolean = False)
        If withClear = True Then
            cboJoystick1.Items.Clear()
            cboJoystick2.Items.Clear()
            cboJoystick3.Items.Clear()
            cboJoystick4.Items.Clear()
            cboJoystick5.Items.Clear()
        End If
        cboJoystick1.Items.Add(inputString)
        cboJoystick2.Items.Add(inputString)
        cboJoystick3.Items.Add(inputString)
        cboJoystick4.Items.Add(inputString)
        cboJoystick5.Items.Add(inputString)
    End Sub
    Private Sub AddToServoCombo()
        Dim nCount As Integer
        cboServo1.Items.Clear()
        cboServo2.Items.Clear()
        cboServo3.Items.Clear()
        cboServo4.Items.Clear()
        cboServo5.Items.Clear()

        cboServo1.Items.Add(GetResString(, "None"))
        cboServo2.Items.Add(GetResString(, "None"))
        cboServo3.Items.Add(GetResString(, "None"))
        cboServo4.Items.Add(GetResString(, "None"))
        cboServo5.Items.Add(GetResString(, "None"))

        For nCount = 0 To 126
            cboServo1.Items.Add("#" & nCount)
            cboServo2.Items.Add("#" & nCount)
            cboServo3.Items.Add("#" & nCount)
            cboServo4.Items.Add("#" & nCount)
            cboServo5.Items.Add("#" & nCount)
        Next nCount
    End Sub
    'Private Sub AddToCenterCombo(ByVal inputString As String, Optional ByVal withClear As Boolean = False)
    '    If withClear = True Then
    '        cboCenter1.Items.Clear()
    '        cboCenter2.Items.Clear()
    '        cboCenter3.Items.Clear()
    '        cboCenter4.Items.Clear()
    '    End If
    '    cboCenter1.Items.Add(inputString)
    '    cboCenter2.Items.Add(inputString)
    '    cboCenter3.Items.Add(inputString)
    '    cboCenter1.Items.Add(inputString)
    'End Sub

    Private Sub tmrJoystick_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrJoystick.Tick
        Dim nFoundIndex As Integer
        Dim nCount As Integer

        ' get status
        jst.UpdateStatus()

        Try
            ' update the axes positions
            If cboJoystick1.SelectedIndex > 0 Then
                tbarValue1.Value = IIf(chkJoystickReverse1.Checked = True, 65535 - jst.Axis(cboJoystick1.SelectedIndex - 1), jst.Axis(cboJoystick1.SelectedIndex - 1))
            End If
            If cboJoystick2.SelectedIndex > 0 Then
                tbarValue2.Value = IIf(chkJoystickReverse2.Checked = True, 65535 - jst.Axis(cboJoystick2.SelectedIndex - 1), jst.Axis(cboJoystick2.SelectedIndex - 1))
            End If
            If cboJoystick3.SelectedIndex > 0 Then
                tbarValue3.Value = IIf(chkJoystickReverse3.Checked = True, 65535 - jst.Axis(cboJoystick3.SelectedIndex - 1), jst.Axis(cboJoystick3.SelectedIndex - 1))
            End If
            If cboJoystick4.SelectedIndex > 0 Then
                tbarValue4.Value = IIf(chkJoystickReverse4.Checked = True, 65535 - jst.Axis(cboJoystick4.SelectedIndex - 1), jst.Axis(cboJoystick4.SelectedIndex - 1))
            End If
            If cboJoystick5.SelectedIndex > 0 Then
                tbarValue5.Value = IIf(chkJoystickReverse5.Checked = True, 65535 - jst.Axis(cboJoystick5.SelectedIndex - 1), jst.Axis(cboJoystick5.SelectedIndex - 1))
            End If
        Catch
        End Try

        If tbarValue1.Value < Convert.ToInt32(lblMin1.Text) Then
            lblMin1.Text = tbarValue1.Value
        ElseIf tbarValue1.Value > Convert.ToInt32(lblMax1.Text) Then
            lblMax1.Text = tbarValue1.Value
        End If

        If tbarValue2.Value < Convert.ToInt32(lblMin2.Text) Then
            lblMin2.Text = tbarValue2.Value
        ElseIf tbarValue2.Value > Convert.ToInt32(lblMax2.Text) Then
            lblMax2.Text = tbarValue2.Value
        End If

        If tbarValue3.Value < Convert.ToInt32(lblMin3.Text) Then
            lblMin3.Text = tbarValue3.Value
        ElseIf tbarValue3.Value > Convert.ToInt32(lblMax3.Text) Then
            lblMax3.Text = tbarValue3.Value
        End If

        If tbarValue4.Value < Convert.ToInt32(lblMin4.Text) Then
            lblMin4.Text = tbarValue4.Value
        ElseIf tbarValue4.Value > Convert.ToInt32(lblMax4.Text) Then
            lblMax4.Text = tbarValue4.Value
        End If

        If tbarValue5.Value < Convert.ToInt32(lblMin5.Text) Then
            lblMin5.Text = tbarValue5.Value
        ElseIf tbarValue5.Value > Convert.ToInt32(lblMax5.Text) Then
            lblMax5.Text = tbarValue5.Value
        End If

        ' update each button status
        'For Each btn As Control In flpButtons.Controls
        '    If TypeOf btn Is JoystickSample.Button Then
        '        DirectCast(btn, JoystickSample.Button).ButtonStatus = jst.Buttons(DirectCast(btn, JoystickSample.Button).ButtonId - 1)
        '    End If
        'Next
    End Sub
    Private Function GetControlByName(ByVal pobjParent As Control, ByVal pstrCtlName As String) As Object
        Dim objCtl As Object
        For Each objCtl In pobjParent.Controls
            If objCtl.Name = pstrCtlName Then
                Return (objCtl)
            End If
        Next
        ' if control is not found
        Return Nothing
    End Function

    Private Function GetControlByText(ByVal pobjParent As Control, ByVal controlName As String, ByVal selectedIndex As Integer, ByRef foundIndex As Integer) As Boolean
        foundIndex = -1
        GetControlByText = False
        Dim objCtl As Object
        For Each objCtl In pobjParent.Controls
            If UCase(Microsoft.VisualBasic.Left(objCtl.Name, Len(controlName))) = UCase(controlName) Then
                If objCtl.selectedindex = selectedIndex Then
                    GetControlByText = True
                    foundIndex = Convert.ToInt16(objCtl.name.ToString.Substring(Len(controlName)))
                    Exit Function
                End If
            End If
        Next
    End Function
    Private Sub chkJoystickReverse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkJoystickReverse1.CheckedChanged, chkJoystickReverse2.CheckedChanged, chkJoystickReverse3.CheckedChanged, chkJoystickReverse4.CheckedChanged, chkJoystickReverse5.CheckedChanged
        If sender.Checked = True Then
            GetResString(sender, "Reversed")
        Else
            GetResString(sender, "Normal")
        End If
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        frmMain.tabPortControl_SelectedIndexChanged(Nothing, Nothing)
        Me.Dispose()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        sJoystickDevice = cboDevice.Text

        nJoystickThrottle = cboJoystick1.SelectedIndex - 1
        nJoystickElevator = cboJoystick2.SelectedIndex - 1
        nJoystickAileron = cboJoystick3.SelectedIndex - 1
        nJoystickRudder = cboJoystick4.SelectedIndex - 1
        nJoystickMode = cboJoystick5.SelectedIndex - 1

        bJoystickThrottleReverse = chkJoystickReverse1.Checked
        bJoystickElevatorReverse = chkJoystickReverse2.Checked
        bJoystickAileronReverse = chkJoystickReverse3.Checked
        bJoystickRudderReverse = chkJoystickReverse4.Checked
        bJoystickModeReverse = chkJoystickReverse5.Checked

        nJoystickThrottleMin = Convert.ToInt32(lblMin1.Text)
        nJoystickElevatorMin = Convert.ToInt32(lblMin2.Text)
        nJoystickAileronMin = Convert.ToInt32(lblMin3.Text)
        nJoystickRudderMin = Convert.ToInt32(lblMin4.Text)
        nJoystickModeMin = Convert.ToInt32(lblMin5.Text)

        nJoystickThrottleMax = Convert.ToInt32(lblMax1.Text)
        nJoystickElevatorMax = Convert.ToInt32(lblMax2.Text)
        nJoystickAileronMax = Convert.ToInt32(lblMax3.Text)
        nJoystickRudderMax = Convert.ToInt32(lblMax4.Text)
        nJoystickModeMax = Convert.ToInt32(lblMax5.Text)

        nJoystickThrottleServo = cboServo1.SelectedIndex
        nJoystickElevatorServo = cboServo2.SelectedIndex
        nJoystickAileronServo = cboServo3.SelectedIndex
        nJoystickRudderServo = cboServo4.SelectedIndex
        nJoystickModeServo = cboServo5.SelectedIndex

        SaveSettings()
        frmMain.tabPortControl_SelectedIndexChanged(Nothing, Nothing)
        Me.Dispose()
    End Sub

    Private Sub cmdCalibrate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCalibrate.Click
        lblMin1.Text = "32767"
        lblMin2.Text = "32767"
        lblMin3.Text = "32767"
        lblMin4.Text = "32767"
        lblMin5.Text = "32767"

        lblMax1.Text = "32767"
        lblMax2.Text = "32767"
        lblMax3.Text = "32767"
        lblMax4.Text = "32767"
        lblMax5.Text = "32767"

        lblCalibration.Visible = True
    End Sub

    Private Sub cboDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDevice.SelectedIndexChanged
        jst.AcquireJoystick(cboDevice.Text)

        If cboDevice.Text <> sJoystickDevice And bLocked = False Then
            cmdCalibrate_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cboJoystick1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboJoystick1.SelectedIndexChanged, cboJoystick2.SelectedIndexChanged, cboJoystick3.SelectedIndexChanged, cboJoystick4.SelectedIndexChanged
        If bLocked = True Then
            Exit Sub
        End If
        bLocked = True
        If cboJoystick1.SelectedIndex = 1 And cboJoystick2.SelectedIndex = 4 And cboJoystick3.SelectedIndex = 2 And cboJoystick4.SelectedIndex = 5 Then
            cboDefaultModes.SelectedIndex = 1
        ElseIf cboJoystick1.SelectedIndex = 4 And cboJoystick2.SelectedIndex = 1 And cboJoystick3.SelectedIndex = 2 And cboJoystick4.SelectedIndex = 5 Then
            cboDefaultModes.SelectedIndex = 2
        ElseIf cboJoystick1.SelectedIndex = 1 And cboJoystick2.SelectedIndex = 4 And cboJoystick3.SelectedIndex = 5 And cboJoystick4.SelectedIndex = 2 Then
            cboDefaultModes.SelectedIndex = 3
        ElseIf cboJoystick1.SelectedIndex = 4 And cboJoystick2.SelectedIndex = 1 And cboJoystick3.SelectedIndex = 5 And cboJoystick4.SelectedIndex = 2 Then
            cboDefaultModes.SelectedIndex = 4
        Else
            cboDefaultModes.SelectedIndex = 0
        End If
        bLocked = False
    End Sub

    Private Sub cboDefaultModes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDefaultModes.SelectedIndexChanged
        If bLocked = True Then
            Exit Sub
        End If
        bLocked = True
        Select Case cboDefaultModes.SelectedIndex
            Case 1
                cboJoystick1.SelectedIndex = 1
                cboJoystick2.SelectedIndex = 4
                cboJoystick3.SelectedIndex = 2
                cboJoystick4.SelectedIndex = 5
            Case 2
                cboJoystick1.SelectedIndex = 4
                cboJoystick2.SelectedIndex = 1
                cboJoystick3.SelectedIndex = 2
                cboJoystick4.SelectedIndex = 5
            Case 3
                cboJoystick1.SelectedIndex = 1
                cboJoystick2.SelectedIndex = 4
                cboJoystick3.SelectedIndex = 5
                cboJoystick4.SelectedIndex = 2
            Case 4
                cboJoystick1.SelectedIndex = 4
                cboJoystick2.SelectedIndex = 1
                cboJoystick3.SelectedIndex = 5
                cboJoystick4.SelectedIndex = 2
        End Select
        bLocked = False
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim nCount As Integer

        tmrJoystick.Enabled = False
        jst = New JoystickInterface.Joystick(Me.Handle)
        sticks = jst.FindJoysticks()

        With cboDevice
            .Items.Clear()
            '.Items.Add("None")

            If Not sticks Is Nothing Then
                For nCount = 0 To UBound(sticks)
                    .Items.Add(sticks(nCount))
                    If sticks(nCount) = sJoystickDevice Then
                        .SelectedIndex = .Items.Count - 1
                    End If
                Next
                If .Items.Count > 0 And .SelectedIndex < 0 Then
                    .SelectedIndex = 0
                    'ElseIf .Items.Count = 1 Then
                    '    .SelectedIndex = 0

                End If
            Else
                Call MsgBox("Please connect a joystick to the computer and click calibrate again.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "No joysticks found")
                cboDevice.SelectedItem = 0
            End If
        End With

        cboDevice_SelectedIndexChanged(Nothing, Nothing)
        bLocked = False
        tmrJoystick.Enabled = True
    End Sub
End Class