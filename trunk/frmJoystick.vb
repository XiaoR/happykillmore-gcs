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
    Const nNudgeAmount As Integer = 50

    Dim oHeldButton As Button
    Dim nHeldButtonType As Integer

    Private Sub frmJoystick_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
    End Sub

    Private Sub frmJoystick_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nCount As Integer

        bLocked = True
        ' grab the joystick

        chkEnable.Checked = frmMain.tmrJoystick.Enabled
        frmMain.tmrJoystick.Enabled = False

        'lblMin1.Text = cJoystick(1).MinJoystickMovement
        'lblMin2.Text = cJoystick(2).MinJoystickMovement
        'lblMin3.Text = cJoystick(3).MinJoystickMovement
        'lblMin4.Text = cJoystick(4).MinJoystickMovement
        'lblMin5.Text = cJoystick(5).MinJoystickMovement

        'lblMax1.Text = cJoystick(1).MaxJoystickMovement
        'lblMax2.Text = cJoystick(2).MaxJoystickMovement
        'lblMax3.Text = cJoystick(3).MaxJoystickMovement
        'lblMax4.Text = cJoystick(4).MaxJoystickMovement
        'lblMax5.Text = cJoystick(5).MaxJoystickMovement

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

        For nCount = 0 To frmMain.cboJoystickOutput.Items.Count - 1
            cboJoystickOutput.Items.Add(frmMain.cboJoystickOutput.Items(nCount).ToString)
        Next
        cboJoystickOutput.SelectedIndex = frmMain.cboJoystickOutput.SelectedIndex

        AddToServoCombo()

        'AddToCenterCombo("None", True)
        'AddToCenterCombo("Slow")
        'AddToCenterCombo("Fast")

        ' start updating positions

        cboJoystick1.SelectedIndex = cJoystick(1).Axis + 1
        cboJoystick2.SelectedIndex = cJoystick(2).Axis + 1
        cboJoystick3.SelectedIndex = cJoystick(3).Axis + 1
        cboJoystick4.SelectedIndex = cJoystick(4).Axis + 1
        'cboJoystick5.SelectedIndex = cJoystick(5).Axis + 1

        chkJoystickReverse1.Checked = cJoystick(1).Reversed
        chkJoystickReverse2.Checked = cJoystick(2).Reversed
        chkJoystickReverse3.Checked = cJoystick(3).Reversed
        chkJoystickReverse4.Checked = cJoystick(4).Reversed
        'chkJoystickReverse5.Checked = cJoystick(5).Reversed

        cboServo1.SelectedIndex = cJoystick(1).Servo
        cboServo2.SelectedIndex = cJoystick(2).Servo
        cboServo3.SelectedIndex = cJoystick(3).Servo
        cboServo4.SelectedIndex = cJoystick(4).Servo
        'cboServo5.SelectedIndex = cJoystick(5).Servo

        numLower1.Value = cJoystick(1).LowerEndPoint
        numLower2.Value = cJoystick(2).LowerEndPoint
        numLower3.Value = cJoystick(3).LowerEndPoint
        numLower4.Value = cJoystick(4).LowerEndPoint
        'numLower5.Value = cJoystick(5).LowerEndPoint

        numUpper1.Value = cJoystick(1).UpperEndPoint
        numUpper2.Value = cJoystick(2).UpperEndPoint
        numUpper3.Value = cJoystick(3).UpperEndPoint
        numUpper4.Value = cJoystick(4).UpperEndPoint
        'numUpper5.Value = cJoystick(5).UpperEndPoint

        tbarSubTrim1.Value = cJoystick(1).SubTrim
        tbarSubTrim2.Value = cJoystick(2).SubTrim
        tbarSubTrim3.Value = cJoystick(3).SubTrim
        tbarSubTrim4.Value = cJoystick(4).SubTrim
        'tbarSubTrim5.Value = cJoystick(5).SubTrim

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
            'cboJoystick5.Items.Clear()
        End If
        cboJoystick1.Items.Add(inputString)
        cboJoystick2.Items.Add(inputString)
        cboJoystick3.Items.Add(inputString)
        cboJoystick4.Items.Add(inputString)
        'cboJoystick5.Items.Add(inputString)
    End Sub
    Private Sub AddToServoCombo()
        Dim nCount As Integer
        cboServo1.Items.Clear()
        cboServo2.Items.Clear()
        cboServo3.Items.Clear()
        cboServo4.Items.Clear()
        'cboServo5.Items.Clear()

        cboServo1.Items.Add(GetResString(, "None"))
        cboServo2.Items.Add(GetResString(, "None"))
        cboServo3.Items.Add(GetResString(, "None"))
        cboServo4.Items.Add(GetResString(, "None"))
        'cboServo5.Items.Add(GetResString(, "None"))

        For nCount = 0 To 126
            cboServo1.Items.Add("#" & nCount)
            cboServo2.Items.Add("#" & nCount)
            cboServo3.Items.Add("#" & nCount)
            cboServo4.Items.Add("#" & nCount)
            'cboServo5.Items.Add("#" & nCount)
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
        'Dim nCount As Integer
        Dim bSuccess As Boolean
        Dim nSliderValue As Long
        Dim nJoystickCurrent As Long
        Dim nOutputvalue As Long

        ' get status
        If jst.UpdateStatus = True Then

            Try
                ' update the axes positions
                If cboJoystick1.SelectedIndex > 0 Then
                    tbarValue1.Value = jst.Axis(cboJoystick1.SelectedIndex - 1)
                End If
                If cboJoystick2.SelectedIndex > 0 Then
                    tbarValue2.Value = jst.Axis(cboJoystick2.SelectedIndex - 1)
                End If
                If cboJoystick3.SelectedIndex > 0 Then
                    tbarValue3.Value = jst.Axis(cboJoystick3.SelectedIndex - 1)
                End If
                If cboJoystick4.SelectedIndex > 0 Then
                    tbarValue4.Value = jst.Axis(cboJoystick4.SelectedIndex - 1)
                End If
                'If cboJoystick5.SelectedIndex > 0 Then
                '    tbarValue5.Value = jst.Axis(cboJoystick5.SelectedIndex - 1)
                'End If
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try

            If chkEnable.Checked = True Then

                Try
                    'Throttle
                    bSuccess = GetJoystickValue(jst, 1, (cboJoystick1.SelectedIndex - 1).ToString, numLower1.Value * 10, numUpper1.Value * 10, tbarSubTrim1.Value, chkJoystickReverse1.Checked, nJoystickCurrent, nSliderValue, nOutputvalue)
                    If bSuccess = True Then
                        tbarValue1.Value = nJoystickCurrent
                        tbarOutput1.Value = nSliderValue
                        cJoystick(1).CurrentValue = nJoystickCurrent
                        cJoystick(1).SliderValue = nSliderValue
                    Else
                        tbarValue1.Value = 0
                        tbarOutput1.Value = 0
                    End If
                Catch ex As Exception
                    Debug.Print(ex.Message)
                End Try

                Try
                    'Elevator
                    bSuccess = GetJoystickValue(jst, 2, (cboJoystick2.SelectedIndex - 1).ToString, numLower2.Value * 10, numUpper2.Value * 10, tbarSubTrim2.Value, chkJoystickReverse2.Checked, nJoystickCurrent, nSliderValue, nOutputvalue)
                    If bSuccess = True Then
                        tbarValue2.Value = nJoystickCurrent
                        tbarOutput2.Value = nSliderValue
                        cJoystick(2).CurrentValue = nJoystickCurrent
                        cJoystick(2).SliderValue = nSliderValue
                    Else
                        tbarValue2.Value = 0
                        tbarOutput2.Value = 0
                    End If
                Catch ex As Exception
                    Debug.Print(ex.Message)
                End Try

                Try
                    'Aileron
                    bSuccess = GetJoystickValue(jst, 3, (cboJoystick3.SelectedIndex - 1).ToString, numLower3.Value * 10, numUpper3.Value * 10, tbarSubTrim3.Value, chkJoystickReverse3.Checked, nJoystickCurrent, nSliderValue, nOutputvalue)
                    If bSuccess = True Then
                        tbarValue3.Value = nJoystickCurrent
                        tbarOutput3.Value = nSliderValue
                        cJoystick(3).CurrentValue = nJoystickCurrent
                        cJoystick(3).SliderValue = nSliderValue
                    Else
                        tbarValue3.Value = 0
                        tbarOutput3.Value = 0
                    End If
                Catch ex As Exception
                    Debug.Print(ex.Message)
                End Try

                Try
                    'Rudder
                    bSuccess = GetJoystickValue(jst, 4, (cboJoystick4.SelectedIndex - 1).ToString, numLower4.Value * 10, numUpper4.Value * 10, tbarSubTrim4.Value, chkJoystickReverse4.Checked, nJoystickCurrent, nSliderValue, nOutputvalue)
                    If bSuccess = True Then
                        tbarValue4.Value = nJoystickCurrent
                        tbarOutput4.Value = nSliderValue
                        cJoystick(4).CurrentValue = nJoystickCurrent
                        cJoystick(4).SliderValue = nSliderValue
                    Else
                        tbarValue4.Value = 0
                        tbarOutput4.Value = 0
                    End If
                Catch ex As Exception
                    Debug.Print(ex.Message)
                End Try

                Try
                    SendJoystickMessages(cboJoystickOutput.SelectedIndex)
                Catch ex As Exception
                    Debug.Print(ex.Message)
                End Try

                'End If
            End If
        Else
            cmdSearch_Click(Nothing, Nothing)
        End If
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
    Private Sub chkJoystickReverse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkJoystickReverse1.CheckedChanged, chkJoystickReverse2.CheckedChanged, chkJoystickReverse3.CheckedChanged, chkJoystickReverse4.CheckedChanged
        If sender.Checked = True Then
            GetResString(sender, "Reversed")
        Else
            GetResString(sender, "Normal")
        End If
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        frmMain.chkJoystickEnable.Checked = chkEnable.Checked
        frmMain.tmrJoystick.Enabled = chkEnable.Checked

        frmMain.cboJoystickOutput.SelectedIndex = cboJoystickOutput.SelectedIndex

        frmMain.tabPortControl_SelectedIndexChanged(Nothing, Nothing)
        Me.Dispose()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        sJoystickDevice = cboDevice.Text

        cJoystick(1).Axis = cboJoystick1.SelectedIndex - 1
        cJoystick(2).Axis = cboJoystick2.SelectedIndex - 1
        cJoystick(3).Axis = cboJoystick3.SelectedIndex - 1
        cJoystick(4).Axis = cboJoystick4.SelectedIndex - 1
        'cJoystick(5).Axis = cboJoystick5.SelectedIndex - 1

        cJoystick(1).Reversed = chkJoystickReverse1.Checked
        cJoystick(2).Reversed = chkJoystickReverse2.Checked
        cJoystick(3).Reversed = chkJoystickReverse3.Checked
        cJoystick(4).Reversed = chkJoystickReverse4.Checked
        'cJoystick(5).Reversed = chkJoystickReverse5.Checked

        cJoystick(1).MinJoystickMovement = -32767 'Convert.ToInt32(lblMin1.Text)
        cJoystick(2).MinJoystickMovement = -32767 'Convert.ToInt32(lblMin2.Text)
        cJoystick(3).MinJoystickMovement = -32767 'Convert.ToInt32(lblMin3.Text)
        cJoystick(4).MinJoystickMovement = -32767 'Convert.ToInt32(lblMin4.Text)
        cJoystick(5).MinJoystickMovement = -32767 'Convert.ToInt32(lblMin5.Text)

        cJoystick(1).MaxJoystickMovement = 32768 'Convert.ToInt32(lblMax1.Text)
        cJoystick(2).MaxJoystickMovement = 32768 'Convert.ToInt32(lblMax2.Text)
        cJoystick(3).MaxJoystickMovement = 32768 'Convert.ToInt32(lblMax3.Text)
        cJoystick(4).MaxJoystickMovement = 32768 'Convert.ToInt32(lblMax4.Text)
        cJoystick(5).MaxJoystickMovement = 32768 'Convert.ToInt32(lblMax5.Text)

        cJoystick(1).Servo = cboServo1.SelectedIndex
        cJoystick(2).Servo = cboServo2.SelectedIndex
        cJoystick(3).Servo = cboServo3.SelectedIndex
        cJoystick(4).Servo = cboServo4.SelectedIndex
        'cJoystick(5).Servo = cboServo5.SelectedIndex

        cJoystick(1).LowerEndPoint = numLower1.Value
        cJoystick(2).LowerEndPoint = numLower2.Value
        cJoystick(3).LowerEndPoint = numLower3.Value
        cJoystick(4).LowerEndPoint = numLower4.Value
        'cJoystick(5).LowerEndPoint = numLower5.Value

        cJoystick(1).UpperEndPoint = numUpper1.Value
        cJoystick(2).UpperEndPoint = numUpper2.Value
        cJoystick(3).UpperEndPoint = numUpper3.Value
        cJoystick(4).UpperEndPoint = numUpper4.Value
        'cJoystick(5).UpperEndPoint = numUpper5.Value

        cJoystick(1).SubTrim = tbarSubTrim1.Value
        cJoystick(2).SubTrim = tbarSubTrim2.Value
        cJoystick(3).SubTrim = tbarSubTrim3.Value
        cJoystick(4).SubTrim = tbarSubTrim4.Value
        'cJoystick(5).SubTrim = tbarSubTrim5.Value

        SaveSettings()

        frmMain.chkJoystickEnable.Checked = chkEnable.Checked
        frmMain.tmrJoystick.Enabled = chkEnable.Checked

        frmMain.cboJoystickOutput.SelectedIndex = cboJoystickOutput.SelectedIndex

        frmMain.tabPortControl_SelectedIndexChanged(Nothing, Nothing)
        Me.Dispose()
    End Sub

    'Public Function GetLowerUpper(ByVal buttonObj As Button, ByVal buttonType As Integer) As Integer
    '    If buttonType = 1 Then
    '        If buttonObj.Text = "" Then
    '            GetLowerUpper = -32767
    '        Else
    '            GetLowerUpper = Convert.ToInt32(buttonObj.Text) - 32767
    '        End If
    '    Else
    '        If buttonObj.Text = "" Then
    '            GetLowerUpper = 32768
    '        Else
    '            GetLowerUpper = Convert.ToInt32(buttonObj.Text) - 32767
    '        End If
    '    End If
    'End Function
    'Private Sub cmdCalibrate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCalibrate.Click
    '    lblMin1.Text = "0"
    '    lblMin2.Text = "0"
    '    lblMin3.Text = "0"
    '    lblMin4.Text = "0"
    '    lblMin5.Text = "0"

    '    lblMax1.Text = "0"
    '    lblMax2.Text = "0"
    '    lblMax3.Text = "0"
    '    lblMax4.Text = "0"
    '    lblMax5.Text = "0"

    '    lblCalibration.Visible = True
    'End Sub

    Private Sub cboDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDevice.SelectedIndexChanged
        jst.AcquireJoystick(cboDevice.Text)

        'If cboDevice.Text <> sJoystickDevice And bLocked = False Then
        '    cmdCalibrate_Click(Nothing, Nothing)
        'End If
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

    Private Sub cmdClear1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear1.Click, cmdClear2.Click, cmdClear3.Click, cmdClear4.Click
        Select Case sender.name
            Case "cmdClear1"
                numLower1.Value = -100
                numUpper1.Value = 100
                tbarSubTrim1.Value = 0
            Case "cmdClear2"
                numLower2.Value = -100
                numUpper2.Value = 100
                tbarSubTrim2.Value = 0
            Case "cmdClear3"
                numLower3.Value = -100
                numUpper3.Value = 100
                tbarSubTrim3.Value = 0
            Case "cmdClear4"
                numLower4.Value = -100
                numUpper4.Value = 100
                tbarSubTrim4.Value = 0
                'Case "cmdClear5"
                '    numLower5.Value = -100
                '    numUpper5.Value = 100
                '    tbarSubTrim5.Value = 0
        End Select

    End Sub

    'Private Sub cmdSetLower1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Select Case sender.name
    '        Case "cmdSetLower1"
    '            ChangeLowerUpper(cmdSetLower1, cmdSetUpper1, tbarValue1.Value)
    '        Case "cmdSetLower2"
    '            ChangeLowerUpper(cmdSetLower2, cmdSetUpper2, tbarValue2.Value)
    '        Case "cmdSetLower3"
    '            ChangeLowerUpper(cmdSetLower3, cmdSetUpper3, tbarValue3.Value)
    '        Case "cmdSetLower4"
    '            ChangeLowerUpper(cmdSetLower4, cmdSetUpper4, tbarValue4.Value)
    '        Case "cmdSetLower5"
    '            ChangeLowerUpper(cmdSetLower5, cmdSetUpper5, tbarValue5.Value)
    '    End Select
    'End Sub
    'Private Sub ChangeLowerUpper(ByVal buttonObjLower As Button, ByVal buttonObjUpper As Button, ByVal limitValue As Integer)
    '    If limitValue = 0 Then
    '        buttonObjLower.Text = ""
    '        buttonObjUpper.Text = ""
    '    ElseIf limitValue = -32767 Then
    '        buttonObjLower.Text = ""
    '    ElseIf limitValue = 32768 Then
    '        buttonObjUpper.Text = ""
    '    ElseIf limitValue > 0 Then
    '        buttonObjUpper.Text = (limitValue + 32767).ToString
    '    Else
    '        buttonObjLower.Text = (limitValue + 32767).ToString
    '    End If
    'End Sub
    'Private Function GetLowerUpperInteger(ByVal buttonObj As Button, ByVal buttonType As Integer) As Integer
    '    If buttonObj.Text = "" Then
    '        If buttonType = 1 Then
    '            GetLowerUpperInteger = -32767
    '        Else
    '            GetLowerUpperInteger = 32768
    '        End If
    '    Else
    '        GetLowerUpperInteger = Convert.ToInt32(buttonObj.Text) - 32767
    '    End If
    'End Function
    'Private Sub cmdSetUpper1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Select Case sender.name
    '        Case "cmdSetUpper1"
    '            ChangeLowerUpper(cmdSetLower1, cmdSetUpper1, tbarValue1.Value)
    '        Case "cmdSetUpper2"
    '            ChangeLowerUpper(cmdSetLower2, cmdSetUpper2, tbarValue2.Value)
    '        Case "cmdSetUpper3"
    '            ChangeLowerUpper(cmdSetLower3, cmdSetUpper3, tbarValue3.Value)
    '        Case "cmdSetUpper4"
    '            ChangeLowerUpper(cmdSetLower4, cmdSetUpper4, tbarValue4.Value)
    '        Case "cmdSetUpper5"
    '            ChangeLowerUpper(cmdSetLower5, cmdSetUpper5, tbarValue5.Value)
    '    End Select
    'End Sub

    Private Sub cmdNudgeDown1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNudgeDown1.Click, cmdNudgeDown2.Click, cmdNudgeDown3.Click, cmdNudgeDown4.Click
        Select Case sender.name
            Case "cmdNudgeDown1"
                If tbarSubTrim1.Value - nNudgeAmount >= tbarSubTrim1.Minimum Then
                    tbarSubTrim1.Value = tbarSubTrim1.Value - nNudgeAmount
                End If
            Case "cmdNudgeDown2"
                If tbarSubTrim2.Value - nNudgeAmount >= tbarSubTrim2.Minimum Then
                    tbarSubTrim2.Value = tbarSubTrim2.Value - nNudgeAmount
                End If
            Case "cmdNudgeDown3"
                If tbarSubTrim3.Value - nNudgeAmount >= tbarSubTrim3.Minimum Then
                    tbarSubTrim3.Value = tbarSubTrim3.Value - nNudgeAmount
                End If
            Case "cmdNudgeDown4"
                If tbarSubTrim4.Value - nNudgeAmount >= tbarSubTrim4.Minimum Then
                    tbarSubTrim4.Value = tbarSubTrim4.Value - nNudgeAmount
                End If
                'Case "cmdNudgeDown5"
                '    If tbarSubTrim5.Value - nNudgeAmount >= tbarSubTrim5.Minimum Then
                '        tbarSubTrim5.Value = tbarSubTrim5.Value - nNudgeAmount
                '    End If
        End Select
    End Sub

    Private Sub cmdNudgeUp1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNudgeUp1.Click, cmdNudgeUp2.Click, cmdNudgeUp3.Click, cmdNudgeUp4.Click
        Select Case sender.name
            Case "cmdNudgeUp1"
                If tbarSubTrim1.Value + nNudgeAmount <= tbarSubTrim1.Maximum Then
                    tbarSubTrim1.Value = tbarSubTrim1.Value + nNudgeAmount
                End If
            Case "cmdNudgeUp2"
                If tbarSubTrim2.Value + nNudgeAmount <= tbarSubTrim2.Maximum Then
                    tbarSubTrim2.Value = tbarSubTrim2.Value + nNudgeAmount
                End If
            Case "cmdNudgeUp3"
                If tbarSubTrim3.Value + nNudgeAmount <= tbarSubTrim3.Maximum Then
                    tbarSubTrim3.Value = tbarSubTrim3.Value + nNudgeAmount
                End If
            Case "cmdNudgeUp4"
                If tbarSubTrim4.Value + nNudgeAmount <= tbarSubTrim4.Maximum Then
                    tbarSubTrim4.Value = tbarSubTrim4.Value + nNudgeAmount
                End If
                'Case "cmdNudgeUp5"
                '    If tbarSubTrim5.Value + nNudgeAmount <= tbarSubTrim5.Maximum Then
                '        tbarSubTrim5.Value = tbarSubTrim5.Value + nNudgeAmount
                '    End If
        End Select
    End Sub

    Private Sub tbarSubTrim1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbarSubTrim1.ValueChanged, tbarSubTrim2.ValueChanged, tbarSubTrim3.ValueChanged, tbarSubTrim4.ValueChanged
        Select Case sender.name
            Case "tbarSubTrim1"
                lblTrim1.Text = IIf(tbarSubTrim1.Value = 0, "", tbarSubTrim1.Value)
            Case "tbarSubTrim2"
                lblTrim2.Text = IIf(tbarSubTrim2.Value = 0, "", tbarSubTrim2.Value)
            Case "tbarSubTrim3"
                lblTrim3.Text = IIf(tbarSubTrim3.Value = 0, "", tbarSubTrim3.Value)
            Case "tbarSubTrim4"
                lblTrim4.Text = IIf(tbarSubTrim4.Value = 0, "", tbarSubTrim4.Value)
                'Case "tbarSubTrim5"
                '    lblTrim5.Text = IIf(tbarSubTrim5.Value = 0, "", tbarSubTrim5.Value)
        End Select
    End Sub

    Private Sub cmdNudgeDown_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdNudgeDown1.MouseDown, cmdNudgeDown2.MouseDown, cmdNudgeDown3.MouseDown, cmdNudgeDown4.MouseDown, cmdNudgeUp1.MouseDown, cmdNudgeUp2.MouseDown, cmdNudgeUp3.MouseDown, cmdNudgeUp4.MouseDown
        oHeldButton = sender
        Select Case sender.name
            Case "cmdNudgeDown1", "cmdNudgeDown2", "cmdNudgeDown3", "cmdNudgeDown4", "cmdNudgeDown5"
                nHeldButtonType = 1
            Case Else
                nHeldButtonType = 2
        End Select
        tmrTrimHold.Interval = 500
        tmrTrimHold.Enabled = True
    End Sub

    Private Sub cmdNudgeDown_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdNudgeDown1.MouseUp, cmdNudgeDown2.MouseUp, cmdNudgeDown3.MouseUp, cmdNudgeDown4.MouseUp, cmdNudgeUp1.MouseUp, cmdNudgeUp2.MouseUp, cmdNudgeUp3.MouseUp, cmdNudgeUp4.MouseUp
        oHeldButton = Nothing
        tmrTrimHold.Enabled = False
    End Sub

    Private Sub tmrTrimHold_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTrimHold.Tick
        tmrTrimHold.Interval = 100
        If nHeldButtonType = 1 Then
            cmdNudgeDown1_Click(oHeldButton, Nothing)
        Else
            cmdNudgeUp1_Click(oHeldButton, Nothing)
        End If
    End Sub


    Private Sub FixMinMax(ByVal sender As System.Object)
        Dim nValue As Integer

        Select Case sender.name
            Case "numUpper1", "numLower1"
                If numUpper1.Value > 100 Or numLower1.Value < -100 Then
                    nValue = 1250
                Else
                    nValue = 1000
                End If
                tbarOutput1.Maximum = nValue
                tbarOutput1.Minimum = -nValue
            Case "numUpper2", "numLower2"
                If numUpper2.Value > 100 Or numLower2.Value < -100 Then
                    nValue = 1250
                Else
                    nValue = 1000
                End If
                tbarOutput2.Maximum = nValue
                tbarOutput2.Minimum = -nValue
            Case "numUpper3", "numLower3"
                If numUpper3.Value > 100 Or numLower3.Value < -100 Then
                    nValue = 1250
                Else
                    nValue = 1000
                End If
                tbarOutput3.Maximum = nValue
                tbarOutput3.Minimum = -nValue
            Case "numUpper4", "numLower4"
                If numUpper4.Value > 100 Or numLower4.Value < -100 Then
                    nValue = 1250
                Else
                    nValue = 1000
                End If
                tbarOutput4.Maximum = nValue
                tbarOutput4.Minimum = -nValue
                'Case "numUpper5", "numLower4"
                '    If numUpper5.Value > 100 Or numLower5.Value < -100 Then
                '        nValue = 1250
                '    Else
                '        nValue = 1000
                '    End If
                '    tbarOutput5.Maximum = nValue
                '    tbarOutput5.Minimum = -nValue
        End Select

    End Sub
    Private Sub numLower1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numLower1.ValueChanged
        FixMinMax(sender)
    End Sub
    Private Sub numUpper1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numUpper1.ValueChanged, numUpper2.ValueChanged, numUpper3.ValueChanged, numUpper4.ValueChanged
        FixMinMax(sender)
    End Sub

    Private Sub tbarValue1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbarValue1.ValueChanged, tbarValue2.ValueChanged, tbarValue3.ValueChanged, tbarValue4.ValueChanged
        Select Case sender.name
            Case "tbarValue1"
                lblValue1.Text = sender.value
            Case "tbarValue2"
                lblValue2.Text = sender.value
            Case "tbarValue3"
                lblValue3.Text = sender.value
            Case "tbarValue4"
                lblValue4.Text = sender.value
                'Case "tbarValue5"
                '    lblValue5.Text = sender.value
        End Select
    End Sub

    Private Sub tbarOutput1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbarOutput1.ValueChanged, tbarOutput2.ValueChanged, tbarOutput3.ValueChanged, tbarOutput4.ValueChanged
        Select Case sender.name
            Case "tbarOutput1"
                lblOutput1.Text = Convert.ToInt32(sender.value / 10)
            Case "tbarOutput2"
                lblOutput2.Text = Convert.ToInt32(sender.value / 10)
            Case "tbarOutput3"
                lblOutput3.Text = Convert.ToInt32(sender.value / 10)
            Case "tbarOutput4"
                lblOutput4.Text = Convert.ToInt32(sender.value / 10)
                'Case "tbarOutput5"
                '    lblOutput5.Text = Convert.ToInt32(sender.value / 10)
        End Select
    End Sub

    Private Sub cboServo1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboServo1.SelectedIndexChanged, cboServo2.SelectedIndexChanged, cboServo3.SelectedIndexChanged, cboServo4.SelectedIndexChanged
        Select Case sender.name
            Case "cboServo1"
                cJoystick(1).Servo = sender.selectedindex
            Case "cboServo2"
                cJoystick(2).Servo = sender.selectedindex
            Case "cboServo3"
                cJoystick(3).Servo = sender.selectedindex
            Case "cboServo4"
                cJoystick(4).Servo = sender.selectedindex
                'Case "cboServo5"
                '    cJoystick(5).Servo = sender.selectedindex
        End Select
    End Sub

    Private Sub cboJoystickOutput_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboJoystickOutput.SelectedIndexChanged
        If cboJoystickOutput.SelectedIndex = e_JoystickOutput.e_JoystickOutput_APM And bConnected = True And nConfigDevice = e_ConfigDevice.e_ConfigDevice_MAVlink Then
            cmdSetEndpoints.Visible = True
        Else
            cmdSetEndpoints.Visible = False
        End If
    End Sub

    Private Sub cmdSetEndpoints_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetEndpoints.Click
        Dim nRet As Long
        Dim nCount As Integer

        If MsgBox("Are you sure you want to overwrite min, max and sub trim values?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Update Radio Limits") = MsgBoxResult.Yes Then
            For nCount = 0 To UBound(aName)
                Select Case aName(nCount)
                    Case "RC3_MIN"
                        aValue(nCount) = 1500 + (600 * (numLower1.Value / 100))
                        aChanged(nCount) = True
                    Case "RC3_MAX"
                        aValue(nCount) = 1500 + (600 * (numUpper1.Value / 100))
                        aChanged(nCount) = True
                    Case "RC3_TRIM"
                        aValue(nCount) = Convert.ToInt32(1500 + (tbarSubTrim1.Value * 1500 / 32767))
                        aChanged(nCount) = True

                    Case "RC2_MIN"
                        aValue(nCount) = 1500 + (600 * (numLower2.Value / 100))
                        aChanged(nCount) = True
                    Case "RC2_MAX"
                        aValue(nCount) = 1500 + (600 * (numUpper2.Value / 100))
                        aChanged(nCount) = True
                    Case "RC2_TRIM"
                        aValue(nCount) = Convert.ToInt32(1500 + (tbarSubTrim2.Value * 1500 / 32767))
                        aChanged(nCount) = True

                    Case "RC1_MIN"
                        aValue(nCount) = 1500 + (600 * (numLower3.Value / 100))
                        aChanged(nCount) = True
                    Case "RC1_MAX"
                        aValue(nCount) = 1500 + (600 * (numUpper3.Value / 100))
                        aChanged(nCount) = True
                    Case "RC1_TRIM"
                        aValue(nCount) = Convert.ToInt32(1500 + (tbarSubTrim3.Value * 1500 / 32767))
                        aChanged(nCount) = True

                    Case "RC4_MIN"
                        aValue(nCount) = 1500 + (600 * (numLower4.Value / 100))
                        aChanged(nCount) = True
                    Case "RC4_MAX"
                        aValue(nCount) = 1500 + (600 * (numUpper4.Value / 100))
                        aChanged(nCount) = True
                    Case "RC4_TRIM"
                        aValue(nCount) = Convert.ToInt32(1500 + (tbarSubTrim4.Value * 1500 / 32767))
                        aChanged(nCount) = True
                End Select
            Next
            frmMain.cmdConfigWrite_Click(Nothing, Nothing)
            frmMain.LoadMavlinkParameterGrid()
        End If
    End Sub

    Private Sub chkEnable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnable.CheckedChanged
        If chkEnable.Checked = False Then
            ReleaseJoystick()
        End If
    End Sub
End Class