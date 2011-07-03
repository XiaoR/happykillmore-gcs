'***************************************************************************

' Project  : AvionicsInstrumentControlDemo                                  
' File     : HeadingIndicatorInstrumentControl.cs                           
' Version  : 1                                                              
' Language : C#                                                             
' Summary  : The heading indicator instrument control                       
' Creation : 25/06/2008                                                     
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
    Class HeadingIndicatorInstrumentControl
        Inherits InstrumentControl
#Region "Fields"

        ' Parameters
        'Private Heading As Integer
        Private headingStartingValue As Single
        Private headingMoveIndex As Integer
        Private headingTargetValue As Single

        Private bearingStartingValue As Single
        Private bearingMoveIndex As Integer
        Private bearingTargetValue As Single

        ' Images
        Private bmpCadran As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.Compass_2_layer_2)
        Private bmpHedingWeel As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.Compass_2_layer_1)
        'Private bmpAircaft As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.HeadingIndicator_Aircraft)
        'Private bmpGlass As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.glass_layer_3)


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
            Dim ptRotation As New Point(150, 150)
            Dim ptImgAircraft As New Point(73, 41)
            Dim ptImgHeadingWeel As New Point(0, 0)

            'Me.BackColor = GetSystemColor("F5F4F1")

            'bmpCadran.MakeTransparent(Color.Yellow)
            'bmpHedingWeel.MakeTransparent(Color.Yellow)
            'bmpAircaft.MakeTransparent(Color.Yellow)

            Dim alphaHeadingWeel As Double = InterpolPhyToAngle(GetCurrentEaseInstrument(headingStartingValue, headingTargetValue, headingMoveIndex, 360), 0, 360, 360, 0)
            'Dim alphaPlane As Double = InterpolPhyToAngle(GetCurrentEaseInstrument(headingStartingValue, headingTargetValue, headingMoveIndex, 360) - GetCurrentEaseInstrument(bearingStartingValue, bearingTargetValue, bearingMoveIndex, 360), 0, 360, 360, 0)

            Dim scale As Single = CSng(Me.Width) / bmpCadran.Width

            ' diplay mask
            Dim maskPen As New Pen(Me.BackColor, 30 * scale)
            pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpCadran.Width * scale, bmpCadran.Height * scale)

            ' display HeadingWeel
            RotateImage(pe, bmpHedingWeel, alphaHeadingWeel, ptImgHeadingWeel, ptRotation, scale)

            ' display border
            pe.Graphics.DrawImage(bmpBorder, 0, 0, CSng(bmpCadran.Width * scale), CSng(bmpCadran.Height * scale))

            ' display cadran
            'RotateImage(pe, bmpCadran, alphaPlane, ptImgHeadingWeel, ptRotation, scale)
            pe.Graphics.DrawImage(bmpCadran, 0, 0, CSng(bmpCadran.Width * scale), CSng(bmpCadran.Height * scale))

            ' display aircraft
            'pe.Graphics.DrawImage(bmpAircaft, CInt(Math.Truncate(ptImgAircraft.X * scale)), CInt(Math.Truncate(ptImgAircraft.Y * scale)), CSng(bmpAircaft.Width * scale), CSng(bmpAircaft.Height * scale))

            'pe.Graphics.DrawImage(bmpGlass, 0, 0, CSng(bmpGlass.Width * scale), CSng(bmpGlass.Height * scale))

        End Sub

#End Region

#Region "Methods"

        ''' Define the physical value to be displayed on the indicator
        ''' The aircraft heading in °deg
        Public Sub SetHeadingIndicatorParameters(ByVal aircraftHeading As Single, ByVal aircraftBearing As Single)
            Dim bFoundOne As Boolean = False

            If aircraftHeading <> headingTargetValue Then
                bFoundOne = True
                headingStartingValue = GetCurrentEaseInstrument(headingStartingValue, headingTargetValue, headingMoveIndex, 360)
                headingMoveIndex = 0

                If aircraftHeading < 0 Then
                    headingTargetValue = 0
                Else
                    headingTargetValue = aircraftHeading
                End If
            End If

            If aircraftBearing <> bearingTargetValue Then
                bFoundOne = True
                bearingStartingValue = GetCurrentEaseInstrument(bearingStartingValue, bearingTargetValue, bearingMoveIndex, 360)
                bearingMoveIndex = 0

                If aircraftBearing < 0 Then
                    bearingTargetValue = 0
                Else
                    bearingTargetValue = aircraftBearing
                End If
            End If

            If bFoundOne = True Then
                Me.Refresh()
            End If

            'Heading = aircraftHeading

            'Me.Refresh()
        End Sub
        Public Sub TickEase()
            Dim bFoundOne As Boolean = False
            If headingMoveIndex <= g_EaseSteps - 2 Then
                bFoundOne = True
                headingMoveIndex = headingMoveIndex + 1
            End If

            If bFoundOne = True Then
                Me.Refresh()
            End If
        End Sub
#End Region
    End Class
End Namespace