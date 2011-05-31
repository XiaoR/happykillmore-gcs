'*****************************************************************************
' * C# Joystick Library - Copyright (c) 2006 Mark Harris - MarkH@rris.com.au
' ******************************************************************************
' * You may use this library in your application, however please do give credit
' * to me for writing it and supplying it. If you modify this library you must
' * leave this notice at the top of this file. I'd love to see any changes you
' * do make, so please email them to me :)
' ****************************************************************************

Imports System.Collections.Generic
Imports System.Text
Imports System.Diagnostics
Imports Microsoft.DirectX
Imports Microsoft.DirectX.DirectInput

Namespace JoystickInterface
    ''' <summary>
    ''' Class to interface with a joystick device.
    ''' </summary>
    Public Class Joystick
        Private joystickDevice As Device
        Public state As JoystickState
        Private m_axis(0 To 7) As Integer
        Private m_buttons() As Boolean
        Private axisData As Integer() = Nothing


        Private pitchEffect As Effect
        Private pitchEffectObject As EffectObject
        Private rollEffect As Effect
        Private rollEffectObject As EffectObject

        Public ReadOnly Property Axis() As Integer()
            Get
                Return m_axis
            End Get
        End Property
        '''' Array of buttons availiable on the joystick. This also includes PoV hats.
        '''' </summary>
        Public ReadOnly Property Buttons() As Boolean()
            Get
                Return m_buttons
            End Get
        End Property

        Private systemJoysticks As String()
        Private hWnd As IntPtr

        ''' <summary>
        ''' Constructor for the class.
        ''' </summary>
        ''' <param name="window_handle">Handle of the window which the joystick will be "attached" to.</param>
        Public Sub New(ByVal window_handle As IntPtr)
            hWnd = window_handle
            m_axis(0) = -1
            m_axis(1) = -1
            m_axis(2) = -1
            m_axis(3) = -1
            m_axis(4) = -1
            m_axis(5) = -1
            m_axis(6) = -1
            m_axis(7) = -1
        End Sub
        Private Function ConstrainValue(ByVal inputValue As Integer, ByVal inputLower As Integer, ByVal inputUpper As Integer, ByVal outputLower As Integer, ByVal outputUpper As Integer) As Integer
            Dim nPct As Single
            Dim nMidPoint As Single
            Dim nHalfRange As Single

            nHalfRange = (outputUpper - outputLower) / 2
            nMidPoint = nHalfRange + outputLower

            If inputValue > 0 Then
                nPct = inputValue / inputUpper
                ConstrainValue = nMidPoint + (nHalfRange * nPct)
            ElseIf inputValue < 0 Then
                nPct = inputValue / inputLower
                ConstrainValue = nMidPoint - (nHalfRange * nPct)
            Else
                ConstrainValue = nMidPoint
            End If
        End Function

        Public Function InitializeForce(ByVal pitch As Integer, ByVal roll As Integer, ByVal Magnitude As Integer, ByVal Duration As Integer) As EffectObject
            Dim eo As EffectObject = Nothing
            Dim e As Effect
            Dim ei As EffectInformation

            If rollEffectObject = Nothing Then
                CreateEffect()
            End If
            Try
                'For Each ei In joystickDevice.GetEffects(EffectType.All)
                '    Try

                '        If DInputHelper.GetTypeCode(ei.EffectType) = CInt(EffectType.ConstantForce) Then
                'e = New Effect()

                'e.SetAxes(New Integer(0) {})
                'e.EffectType = EffectType.ConstantForce
                ''//         effect.u.constant.level = 0x7fff * max(fabs(nx), fabs(ny));
                'e.Constant = New ConstantForce()
                'e.Constant.Magnitude = ConstrainValue(pitch, -90, 90, -32767, 32768)
                '    e.CustomStruct...direction = 0
                '    '// printf("level: %04x direction: %04x\n", (unsigned int)effect.u.constant.level, (unsigned int)effect.direction);
                'effect.u.constant.envelope.attack_length = 0;
                'effect.u.constant.envelope.attack_level = 0;
                'effect.u.constant.envelope.fade_length = 0;
                'effect.u.constant.envelope.fade_level = 0;
                'effect.trigger.button = 0;
                'effect.trigger.interval = 0;
                'effect.replay.length = 0xffff;
                'effect.replay.delay = 0;
                'effect.id = -1;

                'e.SetDirection(New Integer(axisData.Length - 1) {})
                'e.SetAxes(New Integer(0) {})
                'e.EffectType = EffectType.ConstantForce
                'e.ConditionStruct = New Condition(Axis.Length - 1) {}
                'e.Duration = CInt(DI.Infinite)
                'e.Gain = 10000
                'e.Constant = New ConstantForce()
                'e.Constant.Magnitude = ConstrainValue(pitch, -90, 90, 0, 10)
                'e.SamplePeriod = 0
                'e.TriggerButton = CInt(Microsoft.DirectX.DirectInput.Button.NoTrigger)
                'e.TriggerRepeatInterval = CInt(DI.Infinite)
                'e.Flags = EffectFlags.Cartesian Or EffectFlags.ObjectOffsets
                'e.UsesEnvelope = False


                'Effect eff = new Effect();
                '// Allocate some memory for 
                '//directions and axis.
                'eff.SetDirection(
                'new int[this.mAxis.Length]);

                'eff.SetAxes(
                'new int[this.mAxis.Length]);

                'eff.EffectType = eif; 
                'eff.ConditionStruct = 
                'new Condition[this.mAxis.Length];
                'eff.Duration = (int)DI.Infinite;
                'eff.Gain = 10000;
                'eff.Constant = new ConstantForce();
                'eff.Constant.Magnitude = 0;
                'eff.SamplePeriod = 0;
                'eff.TriggerButton = 
                '(int)DI.Button.NoTrigger;
                'eff.TriggerRepeatInterval = 
                '(int)DI.Infinite;
                'eff.Flags =
                'EffectFlags.ObjectOffsets | EffectFlags.Cartesian; 
                'eff.UsesEnvelope = false; 



                'e.SetDirection(New Integer(axisData.Length - 1) {})
                'e.SetAxes(New Integer(0) {})

                'e.EffectType = EffectType.ConstantForce
                'e.ConditionStruct = New Condition(Axis.Length - 1) {}
                'e.Duration = 25000
                'e.Gain = 100000
                'e.Constant = New ConstantForce()
                'e.Constant.Magnitude = ConstrainValue(pitch, -90, 90, 0, 10)
                'e.SamplePeriod = 1000
                'e.TriggerButton = CInt(Microsoft.DirectX.DirectInput.Button.NoTrigger)
                'e.TriggerRepeatInterval = CInt(DI.Infinite)
                'e.Flags = EffectFlags.Spherical Or EffectFlags.ObjectOffsets
                'e.EnvelopeStruct.AttackLevel = 0
                'e.EnvelopeStruct.AttackTime = 0
                'e.EnvelopeStruct.FadeLevel = 0
                'e.EnvelopeStruct.FadeTime = 0
                'e.UsesEnvelope = True

                '' Create the effect, using the passed in guid.
                'Debug.Print(joystickDevice.ForceFeedbackState)
                'eo = New EffectObject(ei.EffectGuid, e, joystickDevice)

                rollEffect.SetAxes(New Integer(0) {0})
                rollEffect.Constant.Magnitude = ConstrainValue(roll, -45, 45, -10000, 10000)
                rollEffectObject.SetParameters(rollEffect, EffectParameterFlags.NoRestart)

                rollEffectObject.Start(10000, EffectStartFlags.NoDownload)

                rollEffect.SetAxes(New Integer(0) {4})
                rollEffect.Constant.Magnitude = ConstrainValue(pitch, -45, 45, -10000, 10000)
                rollEffectObject.SetParameters(rollEffect, EffectParameterFlags.NoRestart)

                rollEffectObject.Start(10000, EffectStartFlags.NoDownload)

                'pitchEffect.Constant.Magnitude = ConstrainValue(pitch, -45, 45, -10000, 10000)
                'pitchEffectObject.SetParameters(pitchEffect, EffectParameterFlags.NoRestart)
                'pitchEffectObject.Start(1000)
                Debug.Print("pitch=" & pitchEffect.Constant.Magnitude)
                'End If
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try

            '    Next
            'Catch ex As Exception
            'Debug.Print(ex.Message)
            'End Try
            Return eo
        End Function
        Private Sub CreateEffect()
            Dim e As Effect
            Dim ei As EffectInformation

            'e.SetDirection(New Integer(axisData.Length - 1) {})
            'e.SetAxes(New Integer(0) {})
            'e.EffectType = EffectType.ConstantForce
            'e.ConditionStruct = New Condition(axisData.Length - 1) {}
            'e.Duration = CInt(DI.Infinite)
            'e.Gain = 10000
            'e.Constant = New ConstantForce()
            'e.Constant.Magnitude = 0
            'e.SamplePeriod = 0
            'e.TriggerButton = CInt(Microsoft.DirectX.DirectInput.Button.NoTrigger)
            'e.TriggerRepeatInterval = CInt(DI.Infinite)
            'e.Flags = EffectFlags.Spherical Or EffectFlags.ObjectOffsets
            'e.UsesEnvelope = False
            For Each ei In joystickDevice.GetEffects(EffectType.All)
                Try

                    Debug.Print("Type=" & DInputHelper.GetTypeCode(ei.EffectType))
                    If DInputHelper.GetTypeCode(ei.EffectType) = CInt(EffectType.ConstantForce) Then
                        e = New Effect()

                        e.SetDirection(New Integer(axisData.Length - 1) {})
                        e.SetAxes(New Integer(0) {})

                        e.EffectType = EffectType.ConstantForce
                        e.ConditionStruct = New Condition(axisData.Length - 1) {}
                        e.Duration = 25000
                        e.Gain = 10000
                        e.Constant = New ConstantForce()
                        e.Constant.Magnitude = 0
                        e.SamplePeriod = 0
                        e.TriggerButton = CInt(Microsoft.DirectX.DirectInput.Button.NoTrigger)
                        e.TriggerRepeatInterval = CInt(DI.Infinite)
                        e.Flags = EffectFlags.Cartesian Or EffectFlags.ObjectOffsets
                        e.UsesEnvelope = False

                        'If rollEffectObject = Nothing Then
                        rollEffect = e
                        rollEffectObject = New EffectObject(ei.EffectGuid, e, joystickDevice)
                        'Else
                        '    pitchEffect = e
                        '    pitchEffectObject = New EffectObject(ei.EffectGuid, e, joystickDevice)
                        'End If
                    End If
                Catch ex As Exception
                End Try
            Next

        End Sub
        Private Function Poll() As Boolean
            Try
                ' poll the joystick
                joystickDevice.Poll()
                Poll = True
                ' update the joystick state field
                state = joystickDevice.CurrentJoystickState
            Catch err As Exception
                Poll = False
                ' we probably lost connection to the joystick
                ' was it unplugged or locked by another application?
                Debug.WriteLine("Poll()")
                Debug.WriteLine(err.Message)
                Debug.WriteLine(err.StackTrace)
            End Try
        End Function

        ''' <summary>
        ''' Retrieves a list of joysticks attached to the computer.
        ''' </summary>
        ''' <example>
        ''' [C#]
        ''' <code>
        ''' JoystickInterface.Joystick jst = new JoystickInterface.Joystick(this.Handle);
        ''' string[] sticks = jst.FindJoysticks();
        ''' </code>
        ''' </example>
        ''' <returns>A list of joysticks as an array of strings.</returns>
        Public Function FindJoysticks() As String()
            systemJoysticks = Nothing

            Try
                ' Find all the GameControl devices that are attached.
                Dim gameControllerList As DeviceList = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly)

                ' check that we have at least one device.
                If gameControllerList.Count > 0 Then
                    systemJoysticks = New String(gameControllerList.Count - 1) {}
                    Dim i As Integer = 0
                    ' loop through the devices.
                    For Each deviceInstance As DeviceInstance In gameControllerList
                        ' create a device from this controller so we can retrieve info.
                        joystickDevice = New Device(deviceInstance.InstanceGuid)
                        joystickDevice.SetCooperativeLevel(hWnd, CooperativeLevelFlags.Background Or CooperativeLevelFlags.NonExclusive)

                        systemJoysticks(i) = joystickDevice.DeviceInformation.InstanceName

                        i += 1
                    Next
                End If
            Catch err As Exception
                Debug.WriteLine("FindJoysticks()")
                Debug.WriteLine(err.Message)
                Debug.WriteLine(err.StackTrace)
            End Try

            Return systemJoysticks
        End Function

        ''' <summary>
        ''' Acquire the named joystick. You can find this joystick through the <see cref="FindJoysticks"/> method.
        ''' </summary>
        ''' <param name="name">Name of the joystick.</param>
        ''' <returns>The success of the connection.</returns>
        Public Function AcquireJoystick(ByVal name As String) As Boolean
            Try
                Dim gameControllerList As DeviceList = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly)
                Dim i As Integer = 0
                Dim found As Boolean = False

                joystickDevice = Nothing

                ' loop through the devices.
                For Each deviceInstance As DeviceInstance In gameControllerList
                    If deviceInstance.InstanceName = name Then
                        found = True
                        ' create a device from this controller so we can retrieve info.
                        joystickDevice = New Device(deviceInstance.InstanceGuid)
                        joystickDevice.SetCooperativeLevel(hWnd, CooperativeLevelFlags.Background Or CooperativeLevelFlags.NonExclusive)
                        Exit For
                    End If

                    i += 1
                Next

                If Not found Then
                    Return False
                End If

                joystickDevice.SetDataFormat(DeviceDataFormat.Joystick)
                'joystickDevice.SetCooperativeLevel(frmMain, CooperativeLevelFlags.Background Or CooperativeLevelFlags.Exclusive)
                'joystickDevice.Properties.AxisModeAbsolute = True
                'joystickDevice.Properties.AutoCenter = True

                ' Finally, acquire the device.
                joystickDevice.Acquire()

                ' Enumerate any axes
                'axisData = Nothing
                'For Each doi As DeviceObjectInstance In joystickDevice.Objects
                '    Dim temp As Integer()

                '    'If (doi.ObjectId And CInt(DeviceObjectTypeFlags.Axis)) <> 0 Then
                '    '    ' We found an axis, set the range to a max of 10,000
                '    '    joystickDevice.Properties.SetRange(ParameterHow.ById, doi.ObjectId, New InputRange(-32767, 32768))
                '    'End If

                '    ' Get info about first two FF axii on the device
                '    If (doi.Flags And CInt(ObjectInstanceFlags.Actuator)) <> 0 Then
                '        Debug.Print(doi.MaxForce)

                '        If axisData IsNot Nothing Then
                '            temp = New Integer(axisData.Length) {}
                '            axisData.CopyTo(temp, 0)
                '            axisData = temp
                '        Else
                '            axisData = New Integer(0) {}
                '        End If

                '        ' Store the offset of each axis.
                '        axisData(axisData.Length - 1) = doi.Offset
                '        If axisData.Length = 2 Then
                '            Exit For
                '        End If

                '    End If
                'Next


                ' How many axes?
                ' Find the capabilities of the joystick
                Dim cps As DeviceCaps = joystickDevice.Caps
                'Debug.Print("Joystick Axis: " & cps.NumberAxes)
                'Debug.Print("Joystick Buttons: " & cps.NumberButtons)

                'rollEffectObject = Nothing
                'rollEffect = Nothing

                'pitchEffectObject = Nothing
                'pitchEffect = Nothing

                UpdateStatus()
            Catch err As Exception
                Debug.WriteLine("FindJoysticks()")
                Debug.WriteLine(err.Message)
                Debug.WriteLine(err.StackTrace)
                Return False
            End Try

            Return True
        End Function

        ''' <summary>
        ''' Unaquire a joystick releasing it back to the system.
        ''' </summary>
        Public Sub ReleaseJoystick()
            joystickDevice.Unacquire()
        End Sub

        ''' <summary>
        ''' Update the properties of button and axis positions.
        ''' </summary>
        Public Function UpdateStatus() As Boolean

            UpdateStatus = Poll()
            If UpdateStatus = False Then
                Exit Function
            End If

            'Rz Rx X Y Axis1 Axis2
            m_axis(0) = state.Ry - 32767
            m_axis(1) = state.Rx - 32767
            m_axis(2) = state.Rz - 32767
            m_axis(3) = state.Y - 32767
            m_axis(4) = state.X - 32767
            m_axis(5) = state.Z - 32767
            Try
                m_axis(6) = state.GetSlider(0) - 32767
                m_axis(7) = state.GetSlider(1) - 32767
            Catch
            End Try

            ' not using buttons, so don't take the tiny amount of time it takes to get/parse
            Dim jsButtons As Byte() = state.GetButtons()
            If Not jsButtons Is Nothing Then
                m_buttons = New Boolean(jsButtons.Length - 1) {}

                Dim i As Integer = 0
                For Each button As Byte In jsButtons
                    m_buttons(i) = button >= 128
                    i += 1
                Next
            Else
                m_buttons = Nothing
            End If
        End Function
    End Class
End Namespace