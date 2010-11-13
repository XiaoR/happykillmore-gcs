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
        Private Heading As Integer

        ' Images
        Private bmpCadran As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.HeadingIndicator_Background)
        Private bmpHedingWeel As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.HeadingWeel)
        Private bmpAircaft As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.HeadingIndicator_Aircraft)

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
            Dim ptImgHeadingWeel As New Point(13, 13)

            bmpCadran.MakeTransparent(Color.Yellow)
            bmpHedingWeel.MakeTransparent(Color.Yellow)
            bmpAircaft.MakeTransparent(Color.Yellow)

            Dim alphaHeadingWeel As Double = InterpolPhyToAngle(Heading, 0, 360, 360, 0)

            Dim scale As Single = CSng(Me.Width) / bmpCadran.Width

            ' diplay mask
            Dim maskPen As New Pen(Me.BackColor, 30 * scale)
            pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpCadran.Width * scale, bmpCadran.Height * scale)

            ' display cadran
            pe.Graphics.DrawImage(bmpCadran, 0, 0, CSng(bmpCadran.Width * scale), CSng(bmpCadran.Height * scale))

            ' display HeadingWeel
            RotateImage(pe, bmpHedingWeel, alphaHeadingWeel, ptImgHeadingWeel, ptRotation, scale)

            ' display aircraft
            pe.Graphics.DrawImage(bmpAircaft, CInt(Math.Truncate(ptImgAircraft.X * scale)), CInt(Math.Truncate(ptImgAircraft.Y * scale)), CSng(bmpAircaft.Width * scale), CSng(bmpAircaft.Height * scale))

        End Sub

#End Region

#Region "Methods"

        ''' Define the physical value to be displayed on the indicator
        ''' The aircraft heading in °deg
        Public Sub SetHeadingIndicatorParameters(ByVal aircraftHeading As Integer)
            Heading = aircraftHeading

            Me.Refresh()
        End Sub

#End Region
    End Class
End Namespace