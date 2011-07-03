'***************************************************************************

' Project  : AvionicsInstrumentControlDemo                                  
' File     : AltimeterInstrumentControl.cs                                  
' Version  : 1                                                              
' Language : C#                                                             
' Summary  : The altimeter instrument control                     
' Creation : 16/06/2008                                                     
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
    Class AltimeterInstrumentControl
        Inherits InstrumentControl
#Region "Fields"

        ' Parameters
        'Private altitude As Integer
        Private altitudeStartingValue As Integer
        Private altitudeMoveIndex As Integer
        Private altitudeTargetValue As Integer

        ' Images
        Private bmpCadran As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.alt)
        Private bmpSmallNeedle As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.needle_09)
        Private bmpLongNeedle As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.needle_01)
        Private bmpScroll As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.Number_Scroll)
        Private bmpGlass As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.glass_layer_3)
        'Private bmpBorder As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.outside_bg)

        Private sUnitLabel As String '= GetResString(, "Feet")
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
            Dim ptCounter As New Point(35, 135)
            Dim ptRotation As New Point(149, 148)
            Dim ptimgNeedle As New Point(135, 32)
            Dim ptimgNeedle2 As New Point(135, 32)

            Me.BackColor = GetSystemColor("F5F4F1")

            bmpCadran.MakeTransparent(Color.Yellow)
            bmpLongNeedle.MakeTransparent(Color.Yellow)
            bmpSmallNeedle.MakeTransparent(Color.Yellow)
            'bmpBorder.MakeTransparent(Color.FromArgb(255, 27, 27, 27))

            'Debug.Print("Target=" & altitudeTargetValue & ",Inbdex=" & altitudeMoveIndex & ",CurrentEase=" & GetCurrentEaseInstrument(altitudeStartingValue, altitudeTargetValue, altitudeMoveIndex))
            Dim alphaSmallNeedle As Double = InterpolPhyToAngle(GetCurrentEaseInstrument(altitudeStartingValue, altitudeTargetValue, altitudeMoveIndex) Mod 10000, 0, 10000, 0, 359)
            Dim alphaLongNeedle As Double = InterpolPhyToAngle(GetCurrentEaseInstrument(altitudeStartingValue, altitudeTargetValue, altitudeMoveIndex) Mod 1000, 0, 1000, 0, 359)

            Dim scale As Single = CSng(Me.Width) / bmpCadran.Width

            ' display counter
            ScrollCounter(pe, bmpScroll, 5, GetCurrentEaseInstrument(altitudeStartingValue, altitudeTargetValue, altitudeMoveIndex), ptCounter, scale)

            ' diplay mask
            Dim maskPen As New Pen(Me.BackColor, 30 * scale)
            pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpCadran.Width * scale, bmpCadran.Height * scale)

            ' display border
            pe.Graphics.DrawImage(bmpBorder, 0, 0, CSng(bmpCadran.Width * scale), CSng(bmpCadran.Height * scale))

            ' display cadran
            pe.Graphics.DrawImage(bmpCadran, 0, 0, CSng(bmpCadran.Width * scale), CSng(bmpCadran.Height * scale))

            Dim fontSize As Single
            fontSize = Me.Width / 180 * 8
            Using the_font As New Font("Arial", fontSize, FontStyle.Regular)
                pe.Graphics.DrawString(sUnitLabel, the_font, Brushes.Azure, bmpCadran.Height * 0.3 * scale, bmpCadran.Width * 0.57 * scale)
            End Using

            ' display small needle
            RotateImage(pe, bmpSmallNeedle, alphaSmallNeedle, ptimgNeedle2, ptRotation, scale)

            ' display long needle
            RotateImage(pe, bmpLongNeedle, alphaLongNeedle, ptimgNeedle, ptRotation, scale)

            pe.Graphics.DrawImage(bmpGlass, 0, 0, CSng(bmpGlass.Width * scale), CSng(bmpGlass.Height * scale))
        End Sub

#End Region

#Region "Methods"


        ''' Define the physical value to be displayed on the indicator
        ''' The aircraft altitude in ft
        Public Sub SetAlimeterParameters(ByVal aircraftAltitude As Integer, ByVal unitString As String)
            If aircraftAltitude <> altitudeTargetValue Then

                altitudeStartingValue = GetCurrentEaseInstrument(altitudeStartingValue, altitudeTargetValue, altitudeMoveIndex)

                altitudeMoveIndex = 0

                If aircraftAltitude < 0 Then
                    altitudeTargetValue = 0
                Else
                    altitudeTargetValue = aircraftAltitude
                End If


                sUnitLabel = unitString

                Me.Refresh()
            End If
        End Sub

        Public Sub TickEase()
            Dim bFoundOne As Boolean = False
            If altitudeMoveIndex <= g_EaseSteps - 2 Then
                bFoundOne = True
                altitudeMoveIndex = altitudeMoveIndex + 1
            End If

            If bFoundOne = True Then
                Me.Refresh()
            End If
        End Sub
#End Region

    End Class
End Namespace