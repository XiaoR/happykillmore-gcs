Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D
Public Class _3DMesh
    Dim angle As Single 'rotation angle
    Dim model As oggX
    Dim nScaleFactor As Single
    Dim oBackColor As System.Drawing.Color
    Dim bHasRun As Boolean = False
    Dim bLocked As Boolean = False

    Sub loadObject(ByVal modelName As String, ByVal rootPath As String)
        Dim sFilename As String
        Dim sFilePath As String

        Try
            Select Case modelName
                Case "AeroQuad"
                    sFilename = "aeroquad.x"
                    sFilePath = rootPath & "aeroquad"
                    nScaleFactor = 65
                    oBackColor = Color.LightGray

                Case "FunJet"
                    sFilename = "funjet.x"
                    sFilePath = rootPath & "funjet"
                    nScaleFactor = 75
                    oBackColor = Color.LightGray

                Case "T-Rex 450"
                    sFilename = "trex450.x"
                    sFilePath = rootPath & "Trex450"
                    nScaleFactor = 70
                    oBackColor = Color.LightGray

                Case "Firecracker"
                    sFilename = "Firecracker.x"
                    sFilePath = rootPath & "Firecracker"
                    nScaleFactor = 70
                    oBackColor = Color.LightGray

                Case "-mi- Yellow Plane"
                    sFilename = "Mi Plane.x"
                    sFilePath = rootPath & "Mi Plane"
                    nScaleFactor = 50
                    oBackColor = Color.DarkGray

                Case Else
                    sFilename = "easystar.x"
                    sFilePath = rootPath & "easystar"
                    nScaleFactor = 75
                    oBackColor = Color.LightGray
            End Select

            'create a model
            model = createMesh(sFilePath & "\" & sFilename, True, True, sFilePath)

        Catch
        End Try

    End Sub

    Public Sub DrawMesh(ByVal pitch As Single, ByVal roll As Single, ByVal yaw As Single, Optional ByVal forceLoad As Boolean = False, Optional ByVal modelName As String = "EasyStar", Optional ByVal rootPath As String = "")
        'transformation matrix
        Dim tempMatrix As Matrix

        Try
            If bHasRun = False Or forceLoad = True Then
                'this function create directX for fullscreen of windowed mode
                'with true you'll use windowed mode
                createDevice(0, 0, 32, Me.Handle, True)
                defaultSetting()
                loadObject(modelName, rootPath)
                'this instruction avoid artefact
                Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.Opaque, True)
                Me.Invalidate() 'invalidate rendering area
            End If
            bHasRun = True

            'syncronize rotation angle with timer
            'angle = Environment.TickCount / 500.0F

            device.Clear(ClearFlags.Target Or ClearFlags.ZBuffer, oBackColor, 1, 0) 'clear the screen
            Try
                device.BeginScene() 'begin 3D scene

                'set transformation matrix
                tempMatrix = Matrix.Scaling(nScaleFactor, nScaleFactor, nScaleFactor)
                tempMatrix.Multiply(Matrix.RotationZ(-roll / 57.2957))
                tempMatrix.Multiply(Matrix.RotationX(-pitch / 57.2957))
                tempMatrix.Multiply(Matrix.RotationY((yaw - 180) / 57.2957))
                tempMatrix.Multiply(Matrix.Translation(0, 0, 1000))
                device.Transform.World = tempMatrix

                device.RenderState.Lighting = True
                device.Lights(0).Enabled = True

                device.Lights(0).Type = LightType.Point
                device.Lights(0).Diffuse = Color.White
                device.Lights(0).Direction = New Vector3(-250, -500, 0)
                device.Lights(0).Position = New Vector3(250, 500, 0)
                device.Lights(0).Range = 5000
                device.Lights(0).Attenuation0 = 0.1 / nScaleFactor
                device.Lights(0).Attenuation1 = device.Lights(0).Attenuation0 / 400

                'device.Lights(0).Direction = New Vector3(-100, -200, -100)
                'device.Lights(0).Position = New Vector3(100, 200, 100)
                'device.Lights(0).Range = 50000
                'device.Lights(0).Attenuation0 = 0.01

                device.Lights(0).Update()

                'loop all mesh subset
                Dim i As Integer
                For i = 0 To model.numX
                    'set material
                    device.Material = model.mat(i)
                    'set texture
                    device.SetTexture(0, model.tex(i))
                    'draw mesh
                    model.mesh.DrawSubset(i)
                Next

                device.EndScene() 'end 3D scene
                device.Present() 'send graphics to screen
                Me.Invalidate()
            Catch e2 As Exception
                device.Clear(ClearFlags.Target Or ClearFlags.ZBuffer, oBackColor, 1, 0)
            End Try
        Catch
        End Try

    End Sub

    Public Property Locked() As Boolean
        Get
            Locked = bLocked
        End Get
        Set(ByVal value As Boolean)
            bLocked = Locked
        End Set
    End Property
    Private Sub _3DMesh_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            If Not (device Is Nothing) And bLocked = False Then
                'device must be reset
                resetDevice()
                'all setting must be updated
                defaultSetting()
            End If
        Catch
        End Try

    End Sub
End Class
