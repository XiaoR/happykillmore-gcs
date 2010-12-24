Public Class frmAbout
    Public bIsSplash As Boolean = False

    Public Sub ResetForm()
        LoadLanguageFile()

        mnuTitle.Text = "HappyKillmore's" & vbCrLf & GetResString(, "Ground_Control_Station")
        lblVersion.Text = GetResString(, "Version", True) & " " & Version

        If bIsSplash = True Then
            Me.Text = GetResString(, "Starting_GCS", , , , "HappyKillmore's GCS") & "..."
        Else
            Me.Text = GetResString(, "About")
            lblStatus.Text = GetResString(, "Current_Culture", True) & " " & System.Globalization.CultureInfo.CurrentCulture.Name
        End If

        GetResString(lblProjectHomepageLabel, "Project_Homepage")
        GetResString(lblHappyKillmoreEmailLabel, "HappyKillmores_Email")
        GetResString(lbl3DModelLabel, "_3D_Models_From")
        GetResString(lblSupportedProtocolsLabel, "Supported_Protocols")
        GetResString(lblOriginalInstrumentLabel, "Original_Instruments")

        GetResString(cmdOk, "OK")
    End Sub

    Private Sub lblGoogleCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblGoogleCode.Click
        System.Diagnostics.Process.Start(lblGoogleCode.Text)
    End Sub

    Private Sub lblEmailHappyKillmore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEmailHappyKillmore.Click
        System.Diagnostics.Process.Start("mailto:" & lblEmailHappyKillmore.Text)
    End Sub

    Private Sub lblInstruments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblInstruments.Click
        System.Diagnostics.Process.Start(lblInstruments.Text)
    End Sub

    Private Sub lblOpenPilot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblOpenPilot.Click
        System.Diagnostics.Process.Start(lblOpenPilot.Text)
    End Sub

    Private Sub frmAbout_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F9 And bIsSplash = False Then
            If Dir(GetRootPath() & "Language\StringResourceEditor.exe", FileAttribute.Normal) <> "" Then
                System.Diagnostics.Process.Start(GetRootPath() & "Language\StringResourceEditor.exe", """" & GetRootPath() & "Language\Strings.resx""")
            End If
        ElseIf e.KeyCode = Keys.F5 And bIsSplash = False Then
            sLanguageFile = GetRegSetting(sRootRegistry & "\Settings", "Language File", "Default")
            ResetForm()
        ElseIf e.KeyCode = Keys.F4 And bIsSplash = False Then
            sLanguageFile = "en"
            ResetForm()
        End If
    End Sub

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResetForm()

        cmdOk.Visible = Not bIsSplash
        ProgressBar1.Visible = bIsSplash
        'lblStatus.Visible = bIsSplash
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Me.Dispose()
    End Sub

    Public Sub UpdateStatus(ByVal caption As String, ByVal progress As Integer)
        lblStatus.Text = caption
        ProgressBar1.Value = progress
        Me.Refresh()
    End Sub

    Private Sub lblGoogleCode_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblGoogleCode.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub
    Private Sub lblGoogleCode_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblGoogleCode.MouseLeave
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lblOpenPilot_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblOpenPilot.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub
    Private Sub lblOpenPilot_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblOpenPilot.MouseLeave
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lblEmailHappyKillmore_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblEmailHappyKillmore.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub
    Private Sub lblEmailHappyKillmore_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblEmailHappyKillmore.MouseLeave
        Me.Cursor = Cursors.Arrow
    End Sub
End Class