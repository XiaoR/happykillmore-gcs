Public Class frmAbout
    Public bIsSplash As Boolean = False
    Dim nPitch As Integer = 15
    Dim nRoll As Integer = 15
    Dim nHeading As Integer = 70
    Dim sModelName As String = "EasyStar"

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

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mnuTitle.Text = "HappyKillmore's" & vbCrLf & "Ground Control Station"
        lblVersion.Text = "Version: " & Version

        cmdOk.Visible = Not bIsSplash
        ProgressBar1.Visible = bIsSplash
        lblStatus.Visible = bIsSplash
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Me.Dispose()
    End Sub

    Public Sub UpdateStatus(ByVal caption As String, ByVal progress As Integer)
        lblStatus.Text = caption
        ProgressBar1.Value = progress
        Me.Refresh()
    End Sub
End Class