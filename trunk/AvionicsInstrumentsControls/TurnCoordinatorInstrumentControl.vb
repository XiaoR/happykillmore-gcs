'***************************************************************************

' Project  : AvionicsInstrumentControlDemo                                  

' File     : TurnCoordinatorInstrumentControl.cs                            

' Version  : 1                                                              

' Language : C#                                                             

' Summary  : The turn coordinator instrument control                        

' Creation : 15/06/2008                                                     

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
    Class TurnCoordinatorInstrumentControl
        Inherits InstrumentControl
#Region "Fields"

        ' Parameters
        Private TurnRate As Single
        Private TurnQuality As Single

        ' Images
        Private bmpCadran As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.TurnCoordinator_Background)
        Private bmpBall As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.TurnCoordinatorBall)
        Private bmpAircraft As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.TurnCoordinatorAircraft)
        Private bmpMarks As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.TurnCoordinatorMarks)

        Private sTurnCoordLabel As String = "TURN COORDINATOR"
        Private sLeftLabel As String = "L"
        Private sRightLabel As String = "R"
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
            Dim ptRotationAircraft As New Point(150, 150)
            Dim ptImgAircraft As New Point(54, 114)
            Dim ptRotationBall As New Point(150, -155)
            Dim ptImgBall As New Point(136, 216)
            Dim ptMarks As New Point(134, 216)

            bmpCadran.MakeTransparent(Color.Yellow)
            bmpBall.MakeTransparent(Color.Yellow)
            bmpAircraft.MakeTransparent(Color.Yellow)
            bmpMarks.MakeTransparent(Color.Yellow)

            Dim alphaAircraft As Double = InterpolPhyToAngle(TurnRate, -45, 45, -45, 45)
            Dim alphaBall As Double = InterpolPhyToAngle(TurnQuality, -10, 10, -11, 11)

            Dim scale As Single = CSng(Me.Width) / bmpCadran.Width

            ' diplay mask
            Dim maskPen As New Pen(Me.BackColor, 30 * scale)
            pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpCadran.Width * scale, bmpCadran.Height * scale)

            ' display cadran
            pe.Graphics.DrawImage(bmpCadran, 0, 0, CSng(bmpCadran.Width * scale), CSng(bmpCadran.Height * scale))

            Using the_font As New Font("Small Fonts", 6, FontStyle.Regular)
                Using string_format As New StringFormat()
                    string_format.Alignment = StringAlignment.Center
                    string_format.LineAlignment = StringAlignment.Near
                    pe.Graphics.DrawString(sTurnCoordLabel, the_font, Brushes.Azure, bmpCadran.Height * scale * 0.5, bmpCadran.Height * scale * 0.6, string_format)
                End Using
            End Using

            Using the_font As New Font("Arial", 11, FontStyle.Bold)
                pe.Graphics.DrawString(sLeftLabel, the_font, Brushes.Azure, bmpCadran.Height * scale * 0.125, bmpCadran.Height * scale * 0.66)
                pe.Graphics.DrawString(sRightLabel, the_font, Brushes.Azure, bmpCadran.Height * scale * 0.8, bmpCadran.Height * scale * 0.66)
            End Using

            ' display Ball
            RotateImage(pe, bmpBall, alphaBall, ptImgBall, ptRotationBall, scale)

            ' display Aircraft
            RotateImage(pe, bmpAircraft, alphaAircraft, ptImgAircraft, ptRotationAircraft, scale)

            ' display Marks
            pe.Graphics.DrawImage(bmpMarks, CInt(Math.Truncate(ptMarks.X * scale)), CInt(Math.Truncate(ptMarks.Y * scale)), bmpMarks.Width * scale, bmpMarks.Height * scale)

        End Sub

#End Region

#Region "Methods"

        ''' Define the physical value to be displayed on the indicator
        ''' The aircraft turn rate in °deg per minutes
        ''' The aircraft turn quality
        Public Sub SetTurnCoordinatorParameters(ByVal aircraftTurnRate As Single, ByVal aircraftTurnQuality As Single, ByVal instrumentName As String, ByVal leftLabel As String, ByVal rightLabel As String)
            TurnRate = aircraftTurnRate
            TurnQuality = aircraftTurnQuality

            sTurnCoordLabel = instrumentName
            sLeftLabel = leftLabel
            sRightLabel = rightLabel

            Me.Refresh()
        End Sub

#End Region
    End Class
End Namespace