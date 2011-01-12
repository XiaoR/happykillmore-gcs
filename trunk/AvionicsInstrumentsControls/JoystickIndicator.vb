

Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing
Imports System.Text
Imports System.Data

Namespace AvionicsInstrumentControlDemo
    Class JoystickInstrumentControl
        Inherits InstrumentControl
#Region "Fields"

        ' Parameters
        Private LeftX As Single
        Private LeftY As Single
        Private RightX As Single
        Private RightY As Single

        ' Images
        Private bmpLeftStick As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.Button)
        Private bmpRightStick As New Bitmap(HK_GCS.My.Resources.AvionicsInstrumentsControlsRessources.Button)

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

            Me.BackColor = GetSystemColor("F5F4F1")
            Me.Height = bmpLeftStick.Height + 24
            Me.Width = bmpLeftStick.Width * 2 + 36

            bmpLeftStick.MakeTransparent(Color.White)
            bmpRightStick.MakeTransparent(Color.White)

            '           Dim scale As Single = CSng(Me.Width) / bmpLeftStick.Width

            pe.Graphics.DrawLine(Pens.Orange, 12 + CSng(bmpLeftStick.Width) / 2, 0, 12 + CSng(bmpLeftStick.Width) / 2, Me.Height)
            pe.Graphics.DrawLine(Pens.Orange, 24 + (CSng(bmpLeftStick.Width) / 2) * 3, 0, 24 + (CSng(bmpLeftStick.Width) / 2) * 3, Me.Height)
            pe.Graphics.DrawLine(Pens.Orange, 0, 12 + CSng(bmpLeftStick.Height) / 2, Me.Width, 12 + CSng(bmpLeftStick.Height) / 2)

            ' display cadran
            pe.Graphics.DrawImage(bmpLeftStick, 12 + LeftX, 12 + LeftY, CSng(bmpLeftStick.Width), CSng(bmpLeftStick.Height))
            pe.Graphics.DrawImage(bmpRightStick, bmpRightStick.Width + 24 + LeftX + RightX, 12 + RightY, CSng(bmpLeftStick.Width), CSng(bmpLeftStick.Height))

        End Sub

#End Region

#Region "Methods"

        ''' Define the physical value to be displayed on the indicator
        ''' The aircraft turn rate in °deg per minutes
        ''' The aircraft turn quality
        Public Sub SetJoystickParameters(ByVal valueLeftX As Single, ByVal valueLeftY As Single, ByVal valueRightX As Single, ByVal valueRightY As Single)
            LeftX = valueLeftX
            LeftY = valueLeftY
            RightX = valueRightX
            RightY = valueRightY

            Me.Refresh()
        End Sub

#End Region
    End Class
End Namespace