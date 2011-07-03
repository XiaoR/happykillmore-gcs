Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing
Imports System.Text
Imports System.Data

Namespace AvionicsInstrumentControlDemo
    Class StatusInstrument
        Inherits InstrumentControl
#Region "Fields"

        ' Parameters
        'Private nSats As Integer
        ''Private airSpeed As Single
        ''Private groundSpeed As Single

        ''Private groundSpeedTargetValue As Single
        ''Private groundSpeedMoveIndex As Integer
        ''Private groundSpeedStartingValue As Single

        ''Private airSpeedTargetValue As Single
        ''Private airSpeedMoveIndex As Integer
        ''Private airSpeedStartingValue As Single

        ' Images
        Private bmpCadran As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.blank_sq_bottom)
        Private bmpGlass As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.glass_layer_3)
        Private bmpBigBorder As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.blank_sq_top)
        'Private bmpGpsLock As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.icons_016.ToBitmap)
        'Private bmpGpsNoLock As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.icons_017.ToBitmap)

        Public sRunTime As String

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

            Dim scale As Single = CSng(Me.Width) / bmpCadran.Width

            ' display border
            pe.Graphics.DrawImage(bmpBigBorder, 0, 0, CSng(bmpBigBorder.Width * scale), CSng(bmpBigBorder.Height * scale))

            ' display cadran
            pe.Graphics.DrawImage(bmpCadran, 0, 0, CSng(bmpCadran.Width * scale), CSng(bmpCadran.Height * scale))

            'pe.Graphics.DrawImage(bmpGpsLock, CSng(bmpCadran.Width * scale * 0.6), CSng(bmpCadran.Width * scale * 0.15), CSng(bmpGpsLock.Width * scale * 1.2), CSng(bmpGpsLock.Height * scale * 1.2))

            Dim nDistanceLeft As Single = 0.15
            Dim nTopOffset As Single = 0.13
            Dim nDistanceDown As Single = 0.075
            Dim fontSize As Single
            fontSize = Me.Width / 180 * 8
            Using string_format As New StringFormat()
                'string_format.Alignment = StringAlignment.Center
                string_format.LineAlignment = StringAlignment.Near
                Using the_font As New Font("Arial", fontSize, FontStyle.Bold)
                    pe.Graphics.DrawString(GetResString(, "Latitude", True) & " " & Convert.ToDouble(nLatitude).ToString("0.000000"), the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 0) * scale, string_format)
                    pe.Graphics.DrawString(GetResString(, "Longitude", True) & " " & Convert.ToDouble(nLongitude).ToString("0.000000"), the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 1) * scale, string_format)
                    pe.Graphics.DrawString("Sats: " & nSats & " (" & GetGpsLockString(nFix) & ")", the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 2) * scale, string_format)
                    If nHDOP <> 0 Then
                        pe.Graphics.DrawString(GetResString(, "HDOP", True) & " " & nHDOP & GetHdopString(nHDOP), the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 3) * scale, string_format)
                    Else
                        pe.Graphics.DrawString(GetResString(, "HDOP", True) & " ", the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 3) * scale, string_format)
                    End If
                    If dStartTime <> Nothing Then
                        pe.Graphics.DrawString("Run: " & sRunTime, the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 4) * scale, string_format)
                    Else
                        pe.Graphics.DrawString("Run: ", the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 4) * scale, string_format)
                    End If
                    pe.Graphics.DrawString(GetResString(, "Mode", True) & " " & sMode, the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Width * (nTopOffset + nDistanceDown * 5) * scale, string_format)
                    pe.Graphics.DrawString(GetResString(, "Waypoint", True) & " " & GetWaypointString(nWaypoint), the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 6) * scale, string_format)
                    pe.Graphics.DrawString(GetResString(, "Distance", True) & " " & IIf(nDistance <> 0, nDistance.ToString("###,##0.0") & GetShortDistanceUnits(), ""), the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 7) * scale, string_format)
                    pe.Graphics.DrawString(GetResString(, "Throttle", True) & " " & nThrottle.ToString("0%"), the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 8) * scale, string_format)
                    If nRSSI <> 0 Then
                        pe.Graphics.DrawString("RSSI:" & " " & nRSSI.ToString("0.00%"), the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 9) * scale, string_format)
                    End If
                    If nProcessorLoad <> 0 Then
                        pe.Graphics.DrawString("L:" & nProcessorLoad.ToString("0%"), the_font, Brushes.Azure, bmpCadran.Width * 0.6 * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 9) * scale, string_format)
                    End If
                End Using
            End Using

            'pe.Graphics.DrawImage(bmpGlass, 0, 0, CSng(bmpGlass.Width * scale), CSng(bmpGlass.Height * scale))


        End Sub

#End Region

#Region "Methods"
        Public Sub UpdateStatus()
            Me.Refresh()
        End Sub
#End Region

#Region "IDE"




#End Region

    End Class
End Namespace

