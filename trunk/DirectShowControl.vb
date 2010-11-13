Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports DirectShowLib
Imports System.Runtime.InteropServices.ComTypes

Namespace DirectShowControl
    <Guid("43878F19-1E0E-42d2-B72B-88A94418A302"), ComVisible(True)> _
    Partial Public Class DirectShowControl

        Inherits UserControl
        Public Enum PlayState As Integer
            Stopped
            Paused
            Running
            Init
        End Enum

        Private CurrentState As PlayState = PlayState.Stopped
        Private WM_GRAPHNOTIFY As Integer = Convert.ToInt32("0X8000", 16) + 1
        Private videoWindow As IVideoWindow = Nothing
        Private mediaControl As IMediaControl = Nothing
        Private mediaEventEx As IMediaEventEx = Nothing
        Private graphBuilder As IGraphBuilder = Nothing
        Private captureGraphBuilder As ICaptureGraphBuilder2 = Nothing

        'Public Sub New()
        '    InitializeComponent()
        'End Sub

        Private Sub DirectShowControl_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            'AddHandler Me.Resize, New System.EventHandler(AddressOf WebCamControl_Resize)
            'CaptureVideo()
        End Sub

        Public Sub StartCapture()
            AddHandler Me.Resize, New System.EventHandler(AddressOf WebCamControl_Resize)
            CaptureVideo()

            components = New System.ComponentModel.Container()
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Dim resources As New System.Resources.ResourceManager(GetType(DirectShowControl))

            AddHandler Me.Load, New System.EventHandler(AddressOf DirectShowControl_Load)
        End Sub

        Private Sub CaptureVideo()
            Dim hr As Integer = 0
            Dim sourceFilter As IBaseFilter = Nothing
            Try
                ' create the necessary DirectShow interfaces
                GetInterfaces()

                hr = Me.captureGraphBuilder.SetFiltergraph(Me.graphBuilder)
                DsError.ThrowExceptionForHR(hr)

                sourceFilter = FindCaptureDevice()

                hr = Me.graphBuilder.AddFilter(sourceFilter, "HK GCS Video")
                DsError.ThrowExceptionForHR(hr)

                hr = Me.captureGraphBuilder.RenderStream(PinCategory.Preview, MediaType.Video, sourceFilter, Nothing, Nothing)
                Debug.WriteLine(DsError.GetErrorText(hr))
                DsError.ThrowExceptionForHR(hr)

                Marshal.ReleaseComObject(sourceFilter)

                SetupVideoWindow()

                hr = Me.mediaControl.Run()
                DsError.ThrowExceptionForHR(hr)

                Me.CurrentState = PlayState.Running
            Catch ex As Exception
                MessageBox.Show("An unrecoverable error has occurred." & vbCr & vbLf & ex.ToString())
            End Try
        End Sub

        Private Sub GetInterfaces()
            Me.graphBuilder = DirectCast(New FilterGraph(), IGraphBuilder)
            Me.captureGraphBuilder = DirectCast(New CaptureGraphBuilder2(), ICaptureGraphBuilder2)
            Me.mediaControl = DirectCast(Me.graphBuilder, IMediaControl)
            Me.videoWindow = DirectCast(Me.graphBuilder, IVideoWindow)
            Me.mediaEventEx = DirectCast(Me.graphBuilder, IMediaEventEx)

            ' send notification messages to the control window
            Dim hr As Integer = Me.mediaEventEx.SetNotifyWindow(Me.Handle, WM_GRAPHNOTIFY, IntPtr.Zero)

            DsError.ThrowExceptionForHR(hr)
        End Sub

        Private Function FindCaptureDevice() As IBaseFilter
            Dim classEnum As UCOMIEnumMoniker = Nothing
            Dim moniker As UCOMIMoniker() = New UCOMIMoniker(0) {}
            Dim source As Object = Nothing

            Dim devEnum As ICreateDevEnum = DirectCast(New CreateDevEnum(), ICreateDevEnum)
            Dim hr As Integer = devEnum.CreateClassEnumerator(FilterCategory.VideoInputDevice, classEnum, CDef.None)
            DsError.ThrowExceptionForHR(hr)
            Marshal.ReleaseComObject(devEnum)

            If classEnum Is Nothing Then
                Throw New ApplicationException("No video capture device was detected.\r\n\r\n" & "This sample requires a video capture device, such as a USB WebCam,\r\nto be installed and working properly.  The sample will now close.")
            End If

            Dim none As Integer = 0

            If classEnum.[Next](moniker.Length, moniker, none) = 0 Then
                Dim iid As Guid = GetType(IBaseFilter).GUID
                moniker(0).BindToObject(Nothing, Nothing, iid, source)
            Else
                Throw New ApplicationException("Unable to access video capture device!")
            End If

            Marshal.ReleaseComObject(moniker(0))
            Marshal.ReleaseComObject(classEnum)

            Return DirectCast(source, IBaseFilter)
        End Function

        Private Sub SetupVideoWindow()
            Dim hr As Integer = 0

            'set the video window to be a child of the main window
            'putowner : Sets the owning parent window for the video playback window. 
            hr = Me.videoWindow.put_Owner(Me.Handle)
            DsError.ThrowExceptionForHR(hr)

            hr = Me.videoWindow.put_WindowStyle(WindowStyle.Child Or WindowStyle.ClipChildren)
            DsError.ThrowExceptionForHR(hr)

            'Use helper function to position video window in client rect of main application window
            WebCamControl_Resize(Me, Nothing)

            'Make the video window visible, now that it is properly positioned
            'put_visible : This method changes the visibility of the video window. 
            hr = Me.videoWindow.put_Visible(OABool.[True])
            DsError.ThrowExceptionForHR(hr)
        End Sub

        Protected Overrides Sub WndProc(ByRef m As Message)
            If m.Msg = WM_GRAPHNOTIFY Then
                HandleGraphEvent()
            End If
            If Me.videoWindow IsNot Nothing Then
                Me.videoWindow.NotifyOwnerMessage(m.HWnd, m.Msg, m.WParam.ToInt32(), m.LParam.ToInt32())
            End If
            MyBase.WndProc(m)
        End Sub

        Private Sub HandleGraphEvent()
            Dim hr As Integer = 0
            Dim evCode As EventCode = 0
            Dim evParam1 As Integer = 0
            Dim evParam2 As Integer = 0

            While Me.mediaEventEx IsNot Nothing AndAlso Me.mediaEventEx.GetEvent(evCode, evParam1, evParam2, 0) = 0
                ' Free event parameters to prevent memory leaks associated with
                ' event parameter data.  While this application is not interested
                ' in the received events, applications should always process them.
                hr = Me.mediaEventEx.FreeEventParams(evCode, evParam1, evParam2)

                ' Insert event processing code here, if desired (see http://msdn2.microsoft.com/en-us/library/ms783649.aspx)
                DsError.ThrowExceptionForHR(hr)
            End While
        End Sub

        Private Sub ReleaseInterfaces()
            If Me.mediaControl IsNot Nothing Then
                Me.mediaControl.StopWhenReady()
            End If

            Me.CurrentState = PlayState.Stopped

            ' stop notifications of events
            If Me.mediaEventEx IsNot Nothing Then
                Me.mediaEventEx.SetNotifyWindow(IntPtr.Zero, WM_GRAPHNOTIFY, IntPtr.Zero)
            End If

            ' Relinquish ownership (IMPORTANT!) of the video window.
            ' Failing to call put_Owner can lead to assert failures within
            ' the video renderer, as it still assumes that it has a valid
            ' parent window.
            If Me.videoWindow IsNot Nothing Then
                Me.videoWindow.put_Visible(OABool.[False])
                Me.videoWindow.put_Owner(IntPtr.Zero)
            End If

            ' Release DirectShow interfaces
            Marshal.ReleaseComObject(Me.mediaControl)
            Me.mediaControl = Nothing

            Marshal.ReleaseComObject(Me.mediaEventEx)
            Me.mediaEventEx = Nothing

            Marshal.ReleaseComObject(Me.videoWindow)
            Me.videoWindow = Nothing

            Marshal.ReleaseComObject(Me.graphBuilder)
            Me.graphBuilder = Nothing

            Marshal.ReleaseComObject(Me.captureGraphBuilder)
            Me.captureGraphBuilder = Nothing
        End Sub

        Private Sub WebCamControl_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
            'Resize the video preview window to match owner window size
            If Me.videoWindow IsNot Nothing Then
                Me.videoWindow.SetWindowPosition(0, 0, Me.Width, Me.ClientSize.Height)
            End If
        End Sub
    End Class
End Namespace