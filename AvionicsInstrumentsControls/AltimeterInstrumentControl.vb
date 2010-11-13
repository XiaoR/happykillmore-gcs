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
        Private altitude As Integer

        ' Images
        Private bmpCadran As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.Altimeter_Background)
        Private bmpSmallNeedle As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.SmallNeedleAltimeter)
        Private bmpLongNeedle As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.LongNeedleAltimeter)
        Private bmpScroll As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.Bandeau_Dérouleur)

        Private sUnitLabel As String = "Feet"
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
            Dim ptRotation As New Point(150, 150)
            Dim ptimgNeedle As New Point(136, 39)

            bmpCadran.MakeTransparent(Color.Yellow)
            bmpLongNeedle.MakeTransparent(Color.Yellow)
            bmpSmallNeedle.MakeTransparent(Color.Yellow)

            Dim alphaSmallNeedle As Double = InterpolPhyToAngle(altitude, 0, 10000, 0, 359)
            Dim alphaLongNeedle As Double = InterpolPhyToAngle(altitude Mod 1000, 0, 1000, 0, 359)

            Dim scale As Single = CSng(Me.Width) / bmpCadran.Width

            ' display counter
            ScrollCounter(pe, bmpScroll, 5, altitude, ptCounter, scale)

            ' diplay mask
            Dim maskPen As New Pen(Me.BackColor, 30 * scale)
            pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpCadran.Width * scale, bmpCadran.Height * scale)

            ' display cadran
            pe.Graphics.DrawImage(bmpCadran, 0, 0, CSng(bmpCadran.Width * scale), CSng(bmpCadran.Height * scale))

            Using the_font As New Font("Arial", 8, FontStyle.Regular)
                pe.Graphics.DrawString(sUnitLabel, the_font, Brushes.Azure, bmpCadran.Height * 0.3 * scale, bmpCadran.Width * 0.57 * scale)
            End Using

            ' display small needle
            RotateImage(pe, bmpSmallNeedle, alphaSmallNeedle, ptimgNeedle, ptRotation, scale)

            ' display long needle
            RotateImage(pe, bmpLongNeedle, alphaLongNeedle, ptimgNeedle, ptRotation, scale)

        End Sub

#End Region

#Region "Methods"


        ''' Define the physical value to be displayed on the indicator
        ''' The aircraft altitude in ft
        Public Sub SetAlimeterParameters(ByVal aircraftAltitude As Integer, ByVal unitString As String)
            altitude = aircraftAltitude
            sUnitLabel = unitString

            Me.Refresh()
        End Sub

#End Region

    End Class
End Namespace