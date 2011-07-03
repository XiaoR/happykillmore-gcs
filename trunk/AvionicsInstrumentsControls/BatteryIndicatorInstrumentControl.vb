'***************************************************************************

' Project  : GK GCS                                
' File     : BatteryIndicatorInstrumentControl.cs                          
' Version  : 1                                                              
' Language : C#                                                             
' Summary  : Battery level indicator instrument control                     
' Creation : 12/14/2010                                                    
' Autor    : Paul Mather AKA HappyKillmore                                            
' History  :                                                                

'***************************************************************************


Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing
Imports System.Text
Imports System.Data

Namespace AvionicsInstrumentControlDemo
    Class BatteryIndicatorInstrumentControl
        Inherits InstrumentControl
#Region "Fields"

        ' Parameters
        Private sInstrumentName As String

        Private voltageStartingValue As Single
        Private voltageMoveIndex As Integer
        Private voltageTargetValue As Single
        'Private nBatteryValue As Single
        Private nBatteryMeterMax As Single
        Private nBatteryMeterMin As Single
        'Private oBatteryMeterColor As e_InstrumentColor

        Private ampStartingValue As Single
        Private ampMoveIndex As Integer
        Private ampTargetValue As Single
        'Private nAmpValue As Single
        Private nAmpMeterMax As Single
        Private nAmpMeterMin As Single
        'Private oAmpMeterColor As e_InstrumentColor

        Private mahStartingValue As Integer
        Private mahMoveIndex As Integer
        Private mahTargetValue As Integer
        'Private nMahValue As Long
        Private nMahMeterMax As Long
        Private nMahMeterMin As Long
        'Private oMahMeterColor As e_InstrumentColor

        Private throttleStartingValue As Single
        Private throttleMoveIndex As Integer
        Private throttleTargetValue As Single
        'Private nThrottleValue As Single
        'Private oThrottleMeterColor As e_InstrumentColor

        ' Images
        Private bmpBack As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.battery_bottom)
        Private bmpCadran As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.battery_mid)
        Private bmpScrollBattery As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.battery_cover_mid)
        Private bmpScrollAmperage As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.battery_cover_mid)
        Private bmpScrollMAH As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.battery_cover_mid)
        Private bmpScrollThro As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.battery_thr_mid)
        Private bmpGlass As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.glass_layer_3)

#End Region

#Region "Contructor"

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            ' Double bufferisation
            SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint, True)
        End Sub

#End Region

#Region "Component Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()
        End Sub
#End Region

#Region "Paint"

        Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
            ' Calling the base class OnPaint
            MyBase.OnPaint(pe)

            ' Pre Display computings
            Dim ptBattery As New Point(68, 50)
            Dim ptMAH As New Point(128, 50)
            Dim ptAmperage As New Point(188, 50)
            Dim ptThro As New Point(0, 0)
            Dim ptRotation As New Point(150, 150)

            Dim alphaThrottle As Double = InterpolPhyToAngle(GetCurrentEaseInstrument(throttleStartingValue, throttleTargetValue, throttleMoveIndex), 0, 1, 0, 180)
            ' Debug.Print("throttleTargetValue=" & throttleTargetValue & ",alpha=" & alphaThrottle)

            'bmpCadran.MakeTransparent(Color.Yellow)

            'Me.BackColor = GetSystemColor("F5F4F1")

            Dim scale As Single = CSng(Me.Width) / bmpCadran.Width

            ' display cadran
            pe.Graphics.DrawImage(bmpBack, 0, 0, CSng(bmpBack.Width * scale), CSng(bmpBack.Height * scale))

            'bmpScrollBattery = GetInstrumentColor(oBatteryMeterColor)
            'bmpScrollAmperage = GetInstrumentColor(oAmpMeterColor)
            'bmpScrollMAH = GetInstrumentColor(oMahMeterColor)
            'bmpScrollThro = GetInstrumentColor(oThrottleMeterColor)

            ShowMeterLevel(pe, bmpScrollBattery, GetCurrentEaseInstrument(voltageStartingValue, voltageTargetValue, voltageMoveIndex), nBatteryMeterMin, nBatteryMeterMax, ptBattery, 100, scale)
            ShowMeterLevel(pe, bmpScrollAmperage, GetCurrentEaseInstrument(ampStartingValue, ampTargetValue, ampMoveIndex), nAmpMeterMin, nAmpMeterMax, ptAmperage, 100, scale)
            ShowMeterLevel(pe, bmpScrollMAH, nMahMeterMax - GetCurrentEaseInstrument(mahStartingValue, mahTargetValue, mahMoveIndex), nMahMeterMin, nMahMeterMax, ptMAH, 100, scale)
            'ShowMeterLevel(pe, bmpScrollThro, nThrottleValue * 100, 0, 100, ptThro, 85, scale)

            ' diplay mask
            Dim maskPen As New Pen(Me.BackColor, 30 * scale)
            pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpCadran.Width * scale, bmpCadran.Height * scale)

            ' display cadran
            pe.Graphics.DrawImage(bmpCadran, 0, 0, CSng(bmpCadran.Width * scale), CSng(bmpCadran.Height * scale))


            Dim fontSize As Single
            fontSize = Me.Width / 180 * 8
            Using string_format As New StringFormat()
                string_format.Alignment = StringAlignment.Center
                string_format.LineAlignment = StringAlignment.Near
                Using the_font As New Font("Arial", fontSize, FontStyle.Bold)
                    pe.Graphics.DrawString(sInstrumentName, the_font, Brushes.Azure, 150 * scale, 73 * scale, string_format)
                End Using
            End Using

            fontSize = Me.Width / 180 * 6
            Using string_format As New StringFormat()
                string_format.Alignment = StringAlignment.Center
                string_format.LineAlignment = StringAlignment.Near
                Using the_font As New Font("Arial", fontSize, FontStyle.Bold)
                    pe.Graphics.DrawString(GetCurrentEaseInstrument(voltageStartingValue, voltageTargetValue, voltageMoveIndex).ToString("0.00") & vbCrLf & GetResString(, "Volts", , , , , , , "Volts"), the_font, Brushes.Azure, (ptBattery.X + 20) * scale, 205 * scale, string_format)
                    pe.Graphics.DrawString(GetCurrentEaseInstrument(ampStartingValue, ampTargetValue, ampMoveIndex).ToString("0.00") & vbCrLf & GetResString(, "Amps", , , , , , , "Amps"), the_font, Brushes.Azure, (ptAmperage.X + 20) * scale, 205 * scale, string_format)
                    pe.Graphics.DrawString(Convert.ToInt32(nMahMeterMax - GetCurrentEaseInstrument(mahStartingValue, mahTargetValue, mahMoveIndex)) & vbCrLf & GetResString(, "mAh", , , , , , , "mAh"), the_font, Brushes.Azure, (ptMAH.X + 20) * scale, 205 * scale, string_format)
                    'pe.Graphics.DrawString(nThrottleValue.ToString("0%") & vbCrLf & GetResString(, "Thro", , , , , , , "Thro"), the_font, Brushes.Azure, (ptThro.X + 20) * scale, 200 * scale, string_format)
                End Using
            End Using

            ' display border
            pe.Graphics.DrawImage(bmpBorder, 0, 0, CSng(bmpCadran.Width * scale), CSng(bmpCadran.Height * scale))

            pe.Graphics.DrawImage(bmpGlass, 0, 0, CSng(bmpGlass.Width * scale), CSng(bmpGlass.Height * scale))

            ' display HeadingWeel
            RotateImage(pe, bmpScrollThro, alphaThrottle, ptThro, ptRotation, scale)

        End Sub

#End Region

#Region "Methods"


        ''' Define the physical value to be displayed on the indicator
        ''' The aircraft air speed in kts
        Public Sub SetBatteryIndicatorParameters(ByVal instrumentName As String, ByVal batteryValue As Single, ByVal minBattery As Single, ByVal maxBattery As Single, ByVal batteryColor As e_InstrumentColor, ByVal ampValue As Single, ByVal minAmps As Single, ByVal maxAmps As Single, ByVal ampColor As e_InstrumentColor, ByVal mahValue As Long, ByVal minMah As Long, ByVal maxMah As Long, ByVal mahColor As e_InstrumentColor, ByVal throValue As Single, ByVal throColor As e_InstrumentColor)
            Dim bFoundOne As Boolean = False

            sInstrumentName = instrumentName
            nBatteryMeterMax = maxBattery
            nBatteryMeterMin = minBattery
            nAmpMeterMax = maxAmps
            nAmpMeterMin = minAmps
            nMahMeterMax = maxMah
            nMahMeterMin = minMah

            If batteryValue < 0 Then
                batteryValue = 0
            End If

            If ampValue < 0 Then
                ampValue = 0
            End If

            If mahValue > maxMah Then
                mahValue = maxMah
            End If

            'If throValue < 0 Then
            '    throValue = 0
            'End If

            If batteryValue <> voltageTargetValue Then
                voltageStartingValue = GetCurrentEaseInstrument(voltageStartingValue, voltageTargetValue, voltageMoveIndex)
                voltageMoveIndex = 0
                voltageTargetValue = batteryValue
                bFoundOne = True
            End If

            If ampValue <> ampTargetValue Then
                ampStartingValue = GetCurrentEaseInstrument(ampStartingValue, ampTargetValue, ampMoveIndex)
                ampMoveIndex = 0
                ampTargetValue = ampValue
                bFoundOne = True
            End If

            If mahValue <> mahTargetValue Then
                mahStartingValue = GetCurrentEaseInstrument(mahStartingValue, mahTargetValue, mahMoveIndex)
                mahMoveIndex = 0
                mahTargetValue = mahValue
                bFoundOne = True
            End If

            If throValue <> throttleTargetValue Then
                throttleStartingValue = GetCurrentEaseInstrument(throttleStartingValue, throttleTargetValue, throttleMoveIndex)
                throttleMoveIndex = 0
                throttleTargetValue = throValue
                bFoundOne = True
            End If

            'nBatteryValue = batteryValue
            ''oBatteryMeterColor = batteryColor
            'If nBatteryValue < 0 Then
            '    nBatteryValue = 0
            'End If

            'nAmpValue = ampValue
            ''oAmpMeterColor = ampColor
            'If nAmpValue < 0 Then
            '    nAmpValue = 0
            'End If

            'nMahValue = mahValue
            ''oMahMeterColor = mahColor
            'If nMahValue > maxMah Then
            '    nMahValue = maxMah
            'End If

            'nThrottleValue = throValue
            ''oThrottleMeterColor = throColor

            If bFoundOne = True Then
                Me.Refresh()
            End If
        End Sub
        Public Sub TickEase()
            Dim bFoundOne As Boolean = False
            If voltageMoveIndex <= g_EaseSteps - 2 Then
                bFoundOne = True
                voltageMoveIndex = voltageMoveIndex + 1
            End If

            If ampMoveIndex <= g_EaseSteps - 2 Then
                bFoundOne = True
                ampMoveIndex = ampMoveIndex + 1
            End If

            If mahMoveIndex <= g_EaseSteps - 2 Then
                bFoundOne = True
                mahMoveIndex = mahMoveIndex + 1
            End If

            If throttleMoveIndex <= g_EaseSteps - 2 Then
                bFoundOne = True
                throttleMoveIndex = throttleMoveIndex + 1
            End If

            If bFoundOne = True Then
                Me.Refresh()
            End If
        End Sub
        'Private Function GetInstrumentColor(ByVal inputColor As e_InstrumentColor) As Bitmap
        '    Select Case inputColor
        '        Case e_InstrumentColor.e_InstrumentColor_Blue
        '            GetInstrumentColor = New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.BatteryBlue)
        '        Case e_InstrumentColor.e_InstrumentColor_Cyan
        '            GetInstrumentColor = New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.BatteryCyan)
        '        Case e_InstrumentColor.e_InstrumentColor_Green
        '            GetInstrumentColor = New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.BatteryGreen)
        '        Case e_InstrumentColor.e_InstrumentColor_Orange
        '            GetInstrumentColor = New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.BatteryOrange)
        '        Case e_InstrumentColor.e_InstrumentColor_Purple
        '            GetInstrumentColor = New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.BatteryPurple)
        '        Case e_InstrumentColor.e_InstrumentColor_Red
        '            GetInstrumentColor = New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.BatteryRed)
        '        Case e_InstrumentColor.e_InstrumentColor_Yellow
        '            GetInstrumentColor = New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.BatteryYellow)
        '    End Select
        'End Function

#End Region

#Region "IDE"




#End Region

    End Class
End Namespace
