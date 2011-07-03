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
        'Private TurnRate As Single
        'Private TurnQuality As Single
        Private turnRateStartingValue As Single
        Private turnRateMoveIndex As Integer
        Private turnRateTargetValue As Single

        Private turnQualityStartingValue As Single
        Private turnQualityMoveIndex As Integer
        Private turnQualityTargetValue As Single

        Private nLastTurnRateTime As Long
        Private nLastYaw As Single

        ' Images
        Private bmpCadran As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.TC_bottom)
        Private bmpBall As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.TC_bub)
        Private bmpAircraft As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.TC_plane)
        Private bmpMarks As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.TC_marks)
        Private bmpGlass As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.TC_glass_top)
        'Private bmpBorder As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.outside_bg)


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
            Dim ptImgAircraft As New Point(30, 100)
            Dim ptRotationBall As New Point(150, -155)
            Dim ptImgBall As New Point(137, 201)
            Dim ptMarks As New Point(134, 201)

            Const nMaxRollAngle As Single = 21

            Me.BackColor = GetSystemColor("F5F4F1")

            bmpCadran.MakeTransparent(Color.Yellow)
            bmpBall.MakeTransparent(Color.Yellow)
            bmpAircraft.MakeTransparent(Color.Yellow)
            bmpMarks.MakeTransparent(Color.Yellow)

            Dim alphaAircraft As Double = InterpolPhyToAngle(GetCurrentEaseInstrument(turnRateStartingValue, turnRateTargetValue, turnRateMoveIndex), -nMaxRollAngle, nMaxRollAngle, -nMaxRollAngle, nMaxRollAngle)
            Dim alphaBall As Double = InterpolPhyToAngle(GetCurrentEaseInstrument(turnQualityStartingValue, turnQualityTargetValue, turnQualityMoveIndex), -10, 10, -11, 11)

            Dim scale As Single = CSng(Me.Width) / bmpCadran.Width

            ' diplay mask
            Dim maskPen As New Pen(Me.BackColor, 30 * scale)
            pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpCadran.Width * scale, bmpCadran.Height * scale)

            ' display border
            pe.Graphics.DrawImage(bmpBorder, 0, 0, CSng(bmpCadran.Width * scale), CSng(bmpCadran.Height * scale))

            ' display cadran
            pe.Graphics.DrawImage(bmpCadran, 0, 0, CSng(bmpCadran.Width * scale), CSng(bmpCadran.Height * scale))

            Dim fontSize As Single
            fontSize = Me.Width / 180 * 6
            Using the_font As New Font("Small Fonts", fontSize, FontStyle.Regular)
                Using string_format As New StringFormat()
                    string_format.Alignment = StringAlignment.Center
                    string_format.LineAlignment = StringAlignment.Near
                    pe.Graphics.DrawString(sTurnCoordLabel, the_font, Brushes.Azure, bmpCadran.Width * scale * 0.5, bmpCadran.Height * scale * 0.57, string_format)
                End Using
            End Using

            'fontSize = Me.Width / 180 * 11
            'Using the_font As New Font("Arial", fontSize, FontStyle.Bold)
            '    pe.Graphics.DrawString(sLeftLabel, the_font, Brushes.Azure, bmpCadran.Height * scale * 0.125, bmpCadran.Height * scale * 0.66)
            '    pe.Graphics.DrawString(sRightLabel, the_font, Brushes.Azure, bmpCadran.Height * scale * 0.8, bmpCadran.Height * scale * 0.66)
            'End Using

            ' display Ball
            RotateImage(pe, bmpBall, alphaBall, ptImgBall, ptRotationBall, scale)

            ' display Aircraft
            RotateImage(pe, bmpAircraft, alphaAircraft, ptImgAircraft, ptRotationAircraft, scale)

            ' display Marks
            pe.Graphics.DrawImage(bmpMarks, CInt(Math.Truncate(ptMarks.X * scale)), CInt(Math.Truncate(ptMarks.Y * scale)), bmpMarks.Width * scale, bmpMarks.Height * scale)

            pe.Graphics.DrawImage(bmpGlass, 0, 0, CSng(bmpGlass.Width * scale), CSng(bmpGlass.Height * scale))

        End Sub

#End Region

#Region "Methods"

        ''' Define the physical value to be displayed on the indicator
        ''' The aircraft turn rate in °deg per minutes
        ''' The aircraft turn quality
        Public Sub SetTurnCoordinatorParameters(ByVal aircraftTurnRate As Single, ByVal aircraftTurnQuality As Single, ByVal instrumentName As String, ByVal leftLabel As String, ByVal rightLabel As String)
            Dim bFoundOne As Boolean = False
            Dim nTimeDiff As Long
            Dim nTemp As Single

            If aircraftTurnRate <> nLastYaw Then
                If nLastTurnRateTime <> 0 Then
                    nTimeDiff = Now.Ticks - nLastTurnRateTime
                    nTemp = (aircraftTurnRate - nLastYaw) / (nTimeDiff / 10000000)
                Else
                    nTemp = 0
                End If
                'Debug.Print("yaw=" & aircraftTurnRate & ",nTemp=" & nTemp)
                nLastYaw = aircraftTurnRate
                nLastTurnRateTime = Now.Ticks
                'Debug.Print("aircraftTurnQuality=" & aircraftTurnQuality)
                If nTemp <> turnRateTargetValue Then
                    bFoundOne = True
                    turnRateStartingValue = GetCurrentEaseInstrument(turnRateStartingValue, turnRateTargetValue, turnRateMoveIndex)
                    turnRateMoveIndex = 0
                    turnRateTargetValue = nTemp
                End If
            ElseIf turnRateTargetValue <> 0 And Now.Ticks - nLastTurnRateTime > 5000000 Then
                bFoundOne = True
                turnRateStartingValue = GetCurrentEaseInstrument(turnRateStartingValue, turnRateTargetValue, turnRateMoveIndex)
                turnRateMoveIndex = 0
                turnRateTargetValue = 0
            End If

            If aircraftTurnQuality <> turnQualityTargetValue Then
                bFoundOne = True
                turnQualityStartingValue = GetCurrentEaseInstrument(turnQualityStartingValue, turnQualityTargetValue, turnQualityMoveIndex)
                turnQualityMoveIndex = 0
                turnQualityTargetValue = aircraftTurnQuality
            End If

            sTurnCoordLabel = instrumentName
            'sLeftLabel = leftLabel
            'sRightLabel = rightLabel

            If bFoundOne = True Then
                'TurnRate = aircraftTurnRate
                'TurnQuality = aircraftTurnQuality
                Me.Refresh()
            End If
        End Sub

        Public Sub TickEase()
            Dim bFoundOne As Boolean = False
            If turnRateMoveIndex <= g_EaseSteps - 2 Then
                bFoundOne = True
                turnRateMoveIndex = turnRateMoveIndex + 1
            End If

            If turnQualityMoveIndex <= g_EaseSteps - 2 Then
                bFoundOne = True
                turnQualityMoveIndex = turnQualityMoveIndex + 1
            End If

            If bFoundOne = True Then
                Me.Refresh()
            End If
        End Sub
#End Region
    End Class
End Namespace