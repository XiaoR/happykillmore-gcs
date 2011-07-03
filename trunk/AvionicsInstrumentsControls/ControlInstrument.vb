Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing
Imports System.Text
Imports System.Data

Namespace AvionicsInstrumentControlDemo
    Class ControlInstrument
        Inherits InstrumentControl
#Region "Fields"

        ' Parameters

        ' Images
 


        Private bmpCadran As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.blank_sq_bottom)
        Private bmpGlass As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.glass_layer_3)
        Private bmpBigBorder As New Bitmap(HK_GCS_Lite.My.Resources.AvionicsInstrumentsControlsRessources.blank_sq_top)

        Public sRunTime As String

#End Region

#Region "Contructor"

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            Dim scale As Single = CSng(Me.Width) / bmpCadran.Width
            Dim nCount As Integer

            ' Double bufferisation
            SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint, True)

            Dim cmdRestartMission As New Button
            cmdRestartMission.Name = "cmdRestartMission"
            Me.Controls.Add(cmdRestartMission)

            Dim cmdSetCommandNumber As New Button
            cmdSetCommandNumber.Name = "cmdSetCommandNumber"
            Me.Controls.Add(cmdSetCommandNumber)

            Dim cboCommandIndex As New ComboBox
            cboCommandIndex.Name = "cboCommandIndex"
            cboCommandIndex.DropDownStyle = ComboBoxStyle.DropDownList
            Me.Controls.Add(cboCommandIndex)

            Dim cboSetMode As New ComboBox
            cboSetMode.Name = "cboSetMode"
            cboSetMode.DropDownStyle = ComboBoxStyle.DropDownList
            Me.Controls.Add(cboSetMode)

            Dim cmdSetMode As New Button
            cmdSetMode.Name = "cmdSetMode"
            Me.Controls.Add(cmdSetMode)

            Dim chkGuidedMode As New CheckBox
            chkGuidedMode.Name = "chkGuidedMode"
            chkGuidedMode.Appearance = Appearance.Button
            chkGuidedMode.TextAlign = ContentAlignment.MiddleCenter
            Me.Controls.Add(chkGuidedMode)

            Dim chkJoystick As New CheckBox
            chkJoystick.Name = "chkJoystick"
            chkJoystick.Appearance = Appearance.Button
            chkJoystick.TextAlign = ContentAlignment.MiddleCenter
            Me.Controls.Add(chkJoystick)

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

            'Dim nDistanceLeft As Single = 0.17
            'Dim nTopOffset As Single = 0.14
            'Dim nDistanceDown As Single = 0.08
            'Dim fontSize As Single
            'fontSize = Me.Width / 180 * 8
            'Using string_format As New StringFormat()
            '    'string_format.Alignment = StringAlignment.Center
            '    string_format.LineAlignment = StringAlignment.Near
            '    Using the_font As New Font("Arial", fontSize, FontStyle.Bold)
            '        pe.Graphics.DrawString(GetResString(, "Air Speed", True) & " " & Convert.ToInt32(nAirSpeed).ToString & " " & GetSpeedUnitsText(), the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 0) * scale, string_format)
            '        pe.Graphics.DrawString("Ground:" & " " & Convert.ToInt32(nGroundSpeed).ToString & " " & GetSpeedUnitsText(), the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 1) * scale, string_format)
            '        pe.Graphics.DrawString("Altitude:" & " " & Convert.ToInt32(nAltitude - nHomeAltIndicator).ToString("###,##0") & GetShortDistanceUnits(), the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 2) * scale, string_format)
            '        pe.Graphics.DrawString(GetResString(, "Heading", True) & " " & Convert.ToInt32(nHeading).ToString, the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 3) * scale, string_format)
            '        pe.Graphics.DrawString(GetResString(, "Pitch", True) & " " & GetPitch(-nPitch).ToString("##0.00"), the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 4) * scale, string_format)
            '        pe.Graphics.DrawString(GetResString(, "Roll", True) & " " & GetRoll(-nRoll).ToString("##0.00"), the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 5) * scale, string_format)
            '        pe.Graphics.DrawString(GetResString(, "Yaw", True) & " " & GetYaw(nYaw).ToString("##0.00"), the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Width * (nTopOffset + nDistanceDown * 6) * scale, string_format)
            '        pe.Graphics.DrawString(GetResString(, "Battery", True) & " " & nBattery & "v", the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 7) * scale, string_format)
            '        pe.Graphics.DrawString("Used:" & " " & nMAH & " mAh", the_font, Brushes.Azure, bmpCadran.Width * nDistanceLeft * scale, bmpCadran.Height * (nTopOffset + nDistanceDown * 8) * scale, string_format)
            '    End Using
            'End Using

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
        Private Sub SetControlLocation(ByVal controlObj As Control, ByVal top As Single, ByVal left As Single, ByVal height As Single, ByVal width As Single, ByVal text As String, ByVal fontSize As Single, ByVal backcolor As System.Drawing.Color, ByVal forecolor As System.Drawing.Color)
            Dim scale As Single = CSng(Me.Width) / bmpCadran.Width
            With controlObj
                .Top = bmpCadran.Width * scale * top
                .Left = bmpCadran.Width * scale * left
                .Height = bmpCadran.Width * scale * height
                .Width = bmpCadran.Width * scale * width
                .Text = text
                .Font = New Font("Microsoft Sans Serif", Me.Width / 180 * fontSize, FontStyle.Regular, GraphicsUnit.Point)
                .BackColor = backcolor
                .ForeColor = forecolor
            End With
        End Sub
        Private Sub ControlInstrument_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
            Dim nCount As Integer

            Dim nDistanceLeft As Single = 0.12
            Dim nTopOffset As Single = 0.13
            Dim nDistanceDown As Single = 0.075

            For nCount = 0 To Me.Controls.Count - 1
                With Me.Controls(nCount)
                    Select Case .Name
                        Case "cmdRestartMission"
                            SetControlLocation(Me.Controls(nCount), 0.2, 0.12, 0.09, 0.76, "Restart Mission", 6, Color.White, Color.Black)
                        Case "cmdSetCommandNumber"
                            SetControlLocation(Me.Controls(nCount), 0.3, 0.12, 0.09, 0.38, "Goto Command", 6, Color.White, Color.Black)
                        Case "cboCommandIndex"
                            SetControlLocation(Me.Controls(nCount), 0.3, 0.51, 0.09, 0.37, "", 6, Color.White, Color.Black)
                        Case "cboSetMode"
                            SetControlLocation(Me.Controls(nCount), 0.4, 0.12, 0.09, 0.57, "", 6, Color.White, Color.Black)
                        Case "cmdSetMode"
                            SetControlLocation(Me.Controls(nCount), 0.4, 0.7, 0.09, 0.18, "Mode", 6, Color.White, Color.Black)
                        Case "chkGuidedMode"
                            SetControlLocation(Me.Controls(nCount), 0.5, 0.12, 0.09, 0.76, "Enable Guided Mode", 6, Color.White, Color.Black)
                        Case "chkJoystick"
                            SetControlLocation(Me.Controls(nCount), 0.6, 0.12, 0.09, 0.76, "Enable Joystick", 6, Color.White, Color.Black)
                    End Select
                End With
            Next
        End Sub
        Public Sub SetDeviceType()
            Dim comboObj As ComboBox
            Dim nCount As Integer
            Dim nCount2 As Integer
            For nCount = 0 To Me.Controls.Count - 1
                With Me.Controls(nCount)
                    Select Case .Name
                        Case "cboSetMode"
                            comboObj = DirectCast(Me.Controls(nCount), ComboBox)
                            With comboObj
                                .Items.Clear()
                                For nCount2 = 0 To UBound(aModeName)
                                    .Items.Add(New cValueDesc(aModeValue(nCount2), aModeName(nCount2)))
                                Next

                                For nCount2 = 0 To .Items.Count - 1
                                    If UCase(sMode) = UCase(CType(.Items(nCount2), cValueDesc).Description) Then
                                        .SelectedIndex = nCount2
                                    End If
                                Next
                                If .SelectedIndex = 0 Then
                                    .SelectedIndex = 0
                                End If
                            End With
                    End Select

                End With
            Next
        End Sub
    End Class
End Namespace

