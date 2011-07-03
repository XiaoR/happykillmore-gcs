'***************************************************************************

' Project  : AvionicsInstrumentControlDemo                                  
' File     : AirSpeedIndicatorInstrumentControl.cs                          
' Version  : 1                                                              
' Language : C#                                                             
' Summary  : The air speed indicator instrument control                     
' Creation : 19/06/2008                                                     
' Autor    : Guillaume CHOUTEAU                                             
' History  :                                                                

'***************************************************************************


Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing
Imports System.Text
Imports System.Data

Namespace AvionicsInstrumentControlDemo
    Class DialControl
        Inherits InstrumentControl
#Region "Fields"

        ' Parameters
        Private sInstrumentLabel As String
        Private nColorIndex As Integer

        Private dialTargetValue As Single
        Private dialMoveIndex As Integer
        Private dialStartingValue As Single

        Private bBeenRun As Boolean = False

        ' Images
        Private bmpCadran As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.blank_red)
        Private bmpNeedle As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.needle_03)
        Private bmpScroll As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.Number_Scroll)
        Private bmpGlass As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.glass_layer_3)
        'Private bmpBorder As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.outside_bg)

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
            Dim ptCounter As New Point(74, 135)
            Dim ptRotation As New Point(149, 150)
            'Dim ptimgNeedle As New Point(136, 39)
            Dim ptimgNeedle As New Point(135, 36)

            Dim nShowValue As Single
            Dim bNegative As Boolean = False
            Dim bFullRotation As Boolean

            nShowValue = GetCurrentEaseInstrument(dialStartingValue, dialTargetValue, dialMoveIndex, 360)

            Select Case Me.Name
                Case "PitchIndicator1"
                    bFullRotation = False
                    bmpCadran = New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.blank_green)
                    bmpNeedle = New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.needle_03)
                    If sInstrumentLabel = "" Then
                        sInstrumentLabel = "Pitch"
                    End If

                    If nShowValue > 180 Then
                        nShowValue = Math.Abs(360 - nShowValue)
                        bNegative = True
                    End If
                Case "RollIndicator1"
                    bFullRotation = False
                    bmpCadran = New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.blank_green)
                    bmpNeedle = New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.needle_08)
                    If sInstrumentLabel = "" Then
                        sInstrumentLabel = "Roll"
                    End If

                    If nShowValue > 180 Then
                        nShowValue = Math.Abs(360 - nShowValue)
                        bNegative = True
                    End If
                Case "YawIndicator1"
                    bFullRotation = True
                    bmpCadran = New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.blank_green)
                    bmpNeedle = New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.needle_02)
                    If sInstrumentLabel = "" Then
                        sInstrumentLabel = "Yaw"
                    End If
            End Select


            bmpCadran.MakeTransparent(Color.Yellow)
            bmpNeedle.MakeTransparent(Color.Yellow)
            bmpGlass.MakeTransparent(Color.Yellow)

            Me.BackColor = GetSystemColor("F5F4F1")

            Dim alphaNeedle As Double

            Dim scale As Single = CSng(Me.Width) / bmpCadran.Width

            ' diplay mask
            Dim maskPen As New Pen(Me.BackColor, 30 * scale)
            pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpCadran.Width * scale, bmpCadran.Height * scale)

            ' display counter
            ScrollCounter(pe, bmpScroll, 3, nShowValue, ptCounter, scale)

            ' display border
            pe.Graphics.DrawImage(bmpBorder, 0, 0, CSng(bmpCadran.Width * scale), CSng(bmpCadran.Height * scale))

            ' display cadran
            pe.Graphics.DrawImage(bmpCadran, 0, 0, CSng(bmpCadran.Width * scale), CSng(bmpCadran.Height * scale))


            Dim fontSize As Single
            fontSize = Me.Width / 180 * 8
            Using string_format As New StringFormat()
                string_format.Alignment = StringAlignment.Center
                string_format.LineAlignment = StringAlignment.Near
                Using the_font As New Font("Arial", fontSize, FontStyle.Bold)
                    pe.Graphics.DrawString("0", the_font, Brushes.Azure, bmpCadran.Height * 0.5 * scale, bmpCadran.Width * 0.16 * scale, string_format)
                    pe.Graphics.DrawString("45", the_font, Brushes.Azure, bmpCadran.Height * 0.69 * scale, bmpCadran.Width * 0.23 * scale, string_format)
                    pe.Graphics.DrawString("90", the_font, Brushes.Azure, bmpCadran.Height * 0.81 * scale, bmpCadran.Width * 0.47 * scale, string_format)
                    pe.Graphics.DrawString("135", the_font, Brushes.Azure, bmpCadran.Height * 0.69 * scale, bmpCadran.Width * 0.67 * scale, string_format)
                    pe.Graphics.DrawString("180", the_font, Brushes.Azure, bmpCadran.Height * 0.5 * scale, bmpCadran.Width * 0.77 * scale, string_format)
                    If bFullRotation = True Then
                        pe.Graphics.DrawString("225", the_font, Brushes.Azure, bmpCadran.Height * 0.31 * scale, bmpCadran.Width * 0.67 * scale, string_format)
                        'pe.Graphics.DrawString("270", the_font, Brushes.Azure, bmpCadran.Height * 0.2 * scale, bmpCadran.Width * 0.47 * scale, string_format)
                        pe.Graphics.DrawString("315", the_font, Brushes.Azure, bmpCadran.Height * 0.31 * scale, bmpCadran.Width * 0.23 * scale, string_format)
                    Else
                        pe.Graphics.DrawString("-135", the_font, Brushes.Azure, bmpCadran.Height * 0.31 * scale, bmpCadran.Width * 0.67 * scale, string_format)
                        'pe.Graphics.DrawString("-90", the_font, Brushes.Azure, bmpCadran.Height * 0.2 * scale, bmpCadran.Width * 0.47 * scale, string_format)
                        pe.Graphics.DrawString("-45", the_font, Brushes.Azure, bmpCadran.Height * 0.31 * scale, bmpCadran.Width * 0.23 * scale, string_format)
                    End If

                End Using
            End Using

            Using string_format As New StringFormat()
                string_format.Alignment = StringAlignment.Center
                string_format.LineAlignment = StringAlignment.Near

                fontSize = Me.Width / 180 * 9
                Using the_font As New Font("Arial", fontSize, FontStyle.Bold)
                    pe.Graphics.DrawString(sInstrumentLabel, the_font, Brushes.Azure, bmpCadran.Width * 0.5 * scale, bmpCadran.Height * 0.61 * scale, string_format)
                End Using
            End Using
            'fontSize = Me.Width / 180 * 8
            'Using the_font As New Font("Arial", fontSize, FontStyle.Bold)
            '    pe.Graphics.DrawString(sUnitLabel, the_font, Brushes.Azure, bmpCadran.Height * 0.54 * scale, bmpCadran.Width * 0.75 * scale)
            'End Using

            'If dialTargetValue > 0 Then
            'alphaNeedle = InterpolPhyToAngle(GetCurrentEaseInstrument(airSpeedStartingValue, airSpeedTargetValue, airSpeedMoveIndex), 0, nMaxSpeed, 180.0, 468.0)
            'RotateImage(pe, bmpAirNeedle, alphaNeedle, ptimgNeedle, ptRotation, scale)
            'End If

            If bNegative = True Then
                fontSize = Me.Width / 180 * 16
                Using the_font As New Font("Arial", fontSize, FontStyle.Bold)
                    pe.Graphics.DrawString("-", the_font, Brushes.Azure, bmpCadran.Width * 0.15 * scale, bmpCadran.Height * 0.43 * scale)
                End Using
            End If

            alphaNeedle = InterpolPhyToAngle(GetCurrentEaseInstrument(dialStartingValue, dialTargetValue, dialMoveIndex, 360), 0.0, 359, 0, 359.0)
            'alphaNeedle = InterpolPhyToAngle(groundSpeed, 0.0, nMaxSpeed, 180.0, 468.0)
            ' display small needle
            RotateImage(pe, bmpNeedle, alphaNeedle, ptimgNeedle, ptRotation, scale)
            'Debug.Print("alphaNeedle=" & alphaNeedle)

            pe.Graphics.DrawImage(bmpGlass, 0, 0, CSng(bmpGlass.Width * scale), CSng(bmpGlass.Height * scale))


        End Sub

#End Region

#Region "Methods"


        ''' Define the physical value to be displayed on the indicator
        ''' The aircraft air speed in kts
        Public Sub SetDialIndicatorParameters(ByVal dialValue As Single, ByVal instrumentName As String, ByVal colorIndex As Integer)
            Dim bFoundOne As Boolean = False
            Dim nTempValue As Single

            If dialValue < 0 Then
                nTempValue = dialValue + 359
            Else
                nTempValue = dialValue
            End If

            If nTempValue <> dialTargetValue Or bBeenRun = False Then
                bFoundOne = True
                dialStartingValue = GetCurrentEaseInstrument(dialStartingValue, dialTargetValue, dialMoveIndex, 360)
                dialMoveIndex = 0
                dialTargetValue = nTempValue
            End If

            bBeenRun = True

            sInstrumentLabel = instrumentName
            If bFoundOne = True Then
                nColorIndex = colorIndex

                Me.Refresh()
            End If
        End Sub

        Public Sub TickEase()
            Dim bFoundOne As Boolean = False
            If dialMoveIndex <= g_EaseSteps - 2 Then
                bFoundOne = True
                dialMoveIndex = dialMoveIndex + 1
            End If

            If bFoundOne = True Then
                Me.Refresh()
            End If

        End Sub
#End Region

#Region "IDE"




#End Region

    End Class
End Namespace
