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

        Private nBatteryValue As Single
        Private nBatteryMeterMax As Single
        Private nBatteryMeterMin As Single
        Private oBatteryMeterColor As e_InstrumentColor

        Private nAmpValue As Single
        Private nAmpMeterMax As Single
        Private nAmpMeterMin As Single
        Private oAmpMeterColor As e_InstrumentColor

        Private nMahValue As Long
        Private nMahMeterMax As Long
        Private nMahMeterMin As Long
        Private oMahMeterColor As e_InstrumentColor

        Private nThrottleValue As Single
        Private oThrottleMeterColor As e_InstrumentColor

        ' Images
        Private bmpCadran As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.BatteryIndicator_Background)
        Private bmpScrollBattery As Bitmap
        Private bmpScrollAmperage As Bitmap
        Private bmpScrollMAH As Bitmap
        Private bmpScrollThro As Bitmap

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
            Dim ptBattery As New Point(50, 105)
            Dim ptAmperage As New Point(103, 105)
            Dim ptMAH As New Point(157, 105)
            Dim ptThro As New Point(210, 105)

            bmpCadran.MakeTransparent(Color.Yellow)

            Me.BackColor = GetSystemColor("F5F4F1")

            Dim scale As Single = CSng(Me.Width) / bmpCadran.Width

            bmpScrollBattery = GetInstrumentColor(oBatteryMeterColor)
            bmpScrollAmperage = GetInstrumentColor(oAmpMeterColor)
            bmpScrollMAH = GetInstrumentColor(oMahMeterColor)
            bmpScrollThro = GetInstrumentColor(oThrottleMeterColor)

            ShowMeterLevel(pe, bmpScrollBattery, nBatteryValue, nBatteryMeterMin, nBatteryMeterMax, ptBattery, 85, scale)
            ShowMeterLevel(pe, bmpScrollAmperage, nAmpValue, nAmpMeterMin, nAmpMeterMax, ptAmperage, 85, scale)
            ShowMeterLevel(pe, bmpScrollMAH, nMahMeterMax - nMahValue, nMahMeterMin, nMahMeterMax, ptMAH, 85, scale)
            ShowMeterLevel(pe, bmpScrollThro, nThrottleValue * 100, 0, 100, ptThro, 85, scale)

            ' diplay mask
            Dim maskPen As New Pen(Me.BackColor, 30 * scale)
            pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpCadran.Width * scale, bmpCadran.Height * scale)

            ' display cadran
            pe.Graphics.DrawImage(bmpCadran, 0, 0, CSng(bmpCadran.Width * scale), CSng(bmpCadran.Height * scale))

            Dim fontSize As Single
            fontSize = Me.Width / 180 * 9
            Using string_format As New StringFormat()
                string_format.Alignment = StringAlignment.Center
                string_format.LineAlignment = StringAlignment.Near
                Using the_font As New Font("Arial", fontSize, FontStyle.Bold)
                    pe.Graphics.DrawString(sInstrumentName, the_font, Brushes.Azure, 150 * scale, 60 * scale, string_format)
                End Using
            End Using

            fontSize = Me.Width / 180 * 6
            Using string_format As New StringFormat()
                string_format.Alignment = StringAlignment.Center
                string_format.LineAlignment = StringAlignment.Near
                Using the_font As New Font("Arial", fontSize, FontStyle.Bold)
                    pe.Graphics.DrawString(nBatteryValue.ToString("0.00") & vbCrLf & GetResString(, "Volts", , , , , , , "Volts"), the_font, Brushes.Azure, (ptBattery.X + 20) * scale, 200 * scale, string_format)
                    pe.Graphics.DrawString(nAmperage.ToString("0.00") & vbCrLf & GetResString(, "Amps", , , , , , , "Amps"), the_font, Brushes.Azure, (ptAmperage.X + 20) * scale, 200 * scale, string_format)
                    pe.Graphics.DrawString(nMahMeterMax - nMahValue & vbCrLf & GetResString(, "mAh", , , , , , , "mAh"), the_font, Brushes.Azure, (ptMAH.X + 20) * scale, 200 * scale, string_format)
                    pe.Graphics.DrawString(nThrottleValue.ToString("0%") & vbCrLf & GetResString(, "Thro", , , , , , , "Thro"), the_font, Brushes.Azure, (ptThro.X + 20) * scale, 200 * scale, string_format)
                End Using
            End Using

        End Sub

#End Region

#Region "Methods"


        ''' Define the physical value to be displayed on the indicator
        ''' The aircraft air speed in kts
        Public Sub SetBatteryIndicatorParameters(ByVal instrumentName As String, ByVal batteryValue As Single, ByVal minBattery As Single, ByVal maxBattery As Single, ByVal batteryColor As e_InstrumentColor, ByVal ampValue As Single, ByVal minAmps As Single, ByVal maxAmps As Single, ByVal ampColor As e_InstrumentColor, ByVal mahValue As Long, ByVal minMah As Long, ByVal maxMah As Long, ByVal mahColor As e_InstrumentColor, ByVal throValue As Single, ByVal throColor As e_InstrumentColor)
            sInstrumentName = instrumentName

            nBatteryValue = batteryValue
            nBatteryMeterMax = maxBattery
            nBatteryMeterMin = minBattery
            oBatteryMeterColor = batteryColor
            If nBatteryValue < 0 Then
                nBatteryValue = 0
            End If

            nAmpValue = ampValue
            nAmpMeterMax = maxAmps
            nAmpMeterMin = minAmps
            oAmpMeterColor = ampColor
            If nAmpValue < 0 Then
                nAmpValue = 0
            End If

            nMahValue = mahValue
            nMahMeterMax = maxMah
            nMahMeterMin = minMah
            oMahMeterColor = mahColor
            If nMahValue > maxMah Then
                nMahValue = maxMah
            End If

            nThrottleValue = throValue
            oThrottleMeterColor = throColor

            Me.Refresh()
        End Sub

        Private Function GetInstrumentColor(ByVal inputColor As e_InstrumentColor) As Bitmap
            Select Case inputColor
                Case e_InstrumentColor.e_InstrumentColor_Blue
                    GetInstrumentColor = New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.BatteryBlue)
                Case e_InstrumentColor.e_InstrumentColor_Cyan
                    GetInstrumentColor = New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.BatteryCyan)
                Case e_InstrumentColor.e_InstrumentColor_Green
                    GetInstrumentColor = New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.BatteryGreen)
                Case e_InstrumentColor.e_InstrumentColor_Orange
                    GetInstrumentColor = New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.BatteryOrange)
                Case e_InstrumentColor.e_InstrumentColor_Purple
                    GetInstrumentColor = New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.BatteryPurple)
                Case e_InstrumentColor.e_InstrumentColor_Red
                    GetInstrumentColor = New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.BatteryRed)
                Case e_InstrumentColor.e_InstrumentColor_Yellow
                    GetInstrumentColor = New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.BatteryYellow)
            End Select
        End Function

#End Region

#Region "IDE"




#End Region

    End Class
End Namespace
