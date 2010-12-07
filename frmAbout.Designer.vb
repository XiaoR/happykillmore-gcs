<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblInstruments = New System.Windows.Forms.Label
        Me.cmdOk = New System.Windows.Forms.Button
        Me.lblVersion = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblOpenPilot = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblEmailHappyKillmore = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblGoogleCode = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.mnuTitle = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblStatus)
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblInstruments)
        Me.GroupBox1.Controls.Add(Me.cmdOk)
        Me.GroupBox1.Controls.Add(Me.lblVersion)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblOpenPilot)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblEmailHappyKillmore)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblGoogleCode)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.mnuTitle)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(607, 380)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(364, 325)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(233, 22)
        Me.lblStatus.TabIndex = 46
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(365, 355)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(232, 18)
        Me.ProgressBar1.TabIndex = 45
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(8, 307)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 16)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Supported Protocols"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(29, 323)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(330, 53)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "NMEA, uBlox, EM406 (SiRF), ArduPilot, ArduIMU Binary, MediaTek (Custom Binary), A" & _
            "rduPilot Mega, MatrixPilot, MAVlink"
        '
        'lblInstruments
        '
        Me.lblInstruments.AutoSize = True
        Me.lblInstruments.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstruments.ForeColor = System.Drawing.Color.Black
        Me.lblInstruments.Location = New System.Drawing.Point(33, 219)
        Me.lblInstruments.Name = "lblInstruments"
        Me.lblInstruments.Size = New System.Drawing.Size(392, 16)
        Me.lblInstruments.TabIndex = 36
        Me.lblInstruments.Text = "http://www.codeproject.com/KB/miscctrl/Avionic_Instruments.aspx"
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(526, 350)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 41
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'lblVersion
        '
        Me.lblVersion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.Black
        Me.lblVersion.Location = New System.Drawing.Point(36, 69)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(299, 22)
        Me.lblVersion.TabIndex = 40
        Me.lblVersion.Text = "Version"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 255)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(224, 16)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "3D Models from OpenPilot Project"
        '
        'lblOpenPilot
        '
        Me.lblOpenPilot.AutoSize = True
        Me.lblOpenPilot.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOpenPilot.ForeColor = System.Drawing.Color.Black
        Me.lblOpenPilot.Location = New System.Drawing.Point(29, 271)
        Me.lblOpenPilot.Name = "lblOpenPilot"
        Me.lblOpenPilot.Size = New System.Drawing.Size(146, 16)
        Me.lblOpenPilot.TabIndex = 38
        Me.lblOpenPilot.Text = "http://wiki.openpilot.org"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 203)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(323, 16)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Original Instrument Code by Guillaume CHOUTEAU"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 16)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "HappyKillmore's Email"
        '
        'lblEmailHappyKillmore
        '
        Me.lblEmailHappyKillmore.AutoSize = True
        Me.lblEmailHappyKillmore.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmailHappyKillmore.ForeColor = System.Drawing.Color.Black
        Me.lblEmailHappyKillmore.Location = New System.Drawing.Point(33, 167)
        Me.lblEmailHappyKillmore.Name = "lblEmailHappyKillmore"
        Me.lblEmailHappyKillmore.Size = New System.Drawing.Size(161, 16)
        Me.lblEmailHappyKillmore.TabIndex = 34
        Me.lblEmailHappyKillmore.Text = "happy@happykillmore.com"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 16)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Project Homepage"
        '
        'lblGoogleCode
        '
        Me.lblGoogleCode.AutoSize = True
        Me.lblGoogleCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGoogleCode.ForeColor = System.Drawing.Color.Black
        Me.lblGoogleCode.Location = New System.Drawing.Point(33, 115)
        Me.lblGoogleCode.Name = "lblGoogleCode"
        Me.lblGoogleCode.Size = New System.Drawing.Size(267, 16)
        Me.lblGoogleCode.TabIndex = 32
        Me.lblGoogleCode.Text = "http://code.google.com/p/happykillmore-gcs/"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(365, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(231, 279)
        Me.PictureBox1.TabIndex = 42
        Me.PictureBox1.TabStop = False
        '
        'mnuTitle
        '
        Me.mnuTitle.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuTitle.ForeColor = System.Drawing.Color.Red
        Me.mnuTitle.Location = New System.Drawing.Point(6, 12)
        Me.mnuTitle.Name = "mnuTitle"
        Me.mnuTitle.Size = New System.Drawing.Size(341, 61)
        Me.mnuTitle.TabIndex = 31
        Me.mnuTitle.Text = "HappyKillmore's                   Ground Control Station"
        Me.mnuTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(616, 385)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAbout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblInstruments As System.Windows.Forms.Label
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblOpenPilot As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblEmailHappyKillmore As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblGoogleCode As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents mnuTitle As System.Windows.Forms.Label
End Class
