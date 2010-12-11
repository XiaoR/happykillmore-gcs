'***************************************************************************

' Project  : AvionicsInstrumentControlDemo                                  
' File     : AttitudeIndicatorInstrumentControl.cs                      
' Version  : 1                                                              
' Language : C#                                                             
' Summary  : The attitude indicator instrument control                      
' Creation : 22/06/2008                                                     
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
    Class AttitudeIndicatorInstrumentControl
        Inherits InstrumentControl
#Region "Fields"

        ' Parameters
        Private PitchAngle As Double = 0
        ' Phi
        Private RollAngle As Double = 0
        ' Theta
        ' Images
        Private bmpCadran As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.Horizon_Background)
        Private bmpBoule As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.Horizon_GroundSky)
        Private bmpAvion As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.Maquette_Avion)

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
            Try
                ' Calling the base class OnPaint
                MyBase.OnPaint(pe)

                ' Pre Display computings

                Dim ptBoule As New Point(25, -350)
                Dim ptRotation As New Point(150, 150)

                Dim scale As Single = CSng(Me.Width) / bmpCadran.Width

                Me.BackColor = GetSystemColor("F5F4F1")

                ' Affichages - - - - - - - - - - - - - - - - - - - - - - 

                bmpCadran.MakeTransparent(Color.Yellow)
                bmpAvion.MakeTransparent(Color.Yellow)

                ' display Horizon
                RotateAndTranslate(pe, bmpBoule, RollAngle, 0, ptBoule, CInt(Math.Truncate(4 * PitchAngle)), _
                 ptRotation, scale)

                ' diplay mask
                Dim maskPen As New Pen(Me.BackColor, 30 * scale)
                pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpCadran.Width * scale, bmpCadran.Height * scale)

                ' display cadran
                pe.Graphics.DrawImage(bmpCadran, 0, 0, CSng(bmpCadran.Width * scale), CSng(bmpCadran.Height * scale))

                ' display aircraft symbol
                pe.Graphics.DrawImage(bmpAvion, CSng((0.5 * bmpCadran.Width - 0.5 * bmpAvion.Width) * scale), CSng((0.5 * bmpCadran.Height - 0.5 * bmpAvion.Height) * scale), CSng(bmpAvion.Width * scale), CSng(bmpAvion.Height * scale))

            Catch
            End Try
        End Sub

#End Region

#Region "Methods"

        ''' Define the physical value to be displayed on the indicator
        ''' The aircraft pitch angle in °deg
        ''' The aircraft roll angle in °deg
        Public Sub SetAttitudeIndicatorParameters(ByVal aircraftPitchAngle As Double, ByVal aircraftRollAngle As Double)
            PitchAngle = aircraftPitchAngle
            RollAngle = aircraftRollAngle * Math.PI / 180

            Me.Refresh()
        End Sub

#End Region

    End Class
End Namespace