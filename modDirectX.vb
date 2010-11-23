Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D

Module modDirectX
    Public device As Device
    Dim deviceSetting As New PresentParameters
    Structure oggX
        'contain mesh and material for an object
        Public mesh As mesh
        Public numX As Integer
        Public tex() As Texture
        Public mat() As Material
    End Structure

    Sub createDevice(ByVal width As Integer, ByVal height As Integer, ByVal bpp As Integer, ByVal fhWnd As System.IntPtr, ByVal windowed As Boolean)
        'screen description
        Try
            deviceSetting.BackBufferCount = 1 'backbuffer number
            deviceSetting.AutoDepthStencilFormat = DepthFormat.D16 'Z/Stencil buffer formats
            deviceSetting.EnableAutoDepthStencil = True 'active Z/Stencil buffer 
            deviceSetting.DeviceWindowHandle = fhWnd 'handle del form
            deviceSetting.SwapEffect = SwapEffect.Flip 'rendering type
            If windowed Then
                deviceSetting.Windowed = True 'setting for windowed mode 
            Else
                deviceSetting.Windowed = False 'setting for fullscreen
                deviceSetting.BackBufferWidth = width 'screen resolution 
                deviceSetting.BackBufferHeight = height 'screen resolution
                If bpp = 16 Then
                    deviceSetting.BackBufferFormat = Format.R5G6B5 'backbuffer format at 16Bit
                Else
                    deviceSetting.BackBufferFormat = Format.X8R8G8B8 'backbuffer format at 32Bit
                End If

            End If
            'presentation type
            deviceSetting.PresentationInterval = PresentInterval.Immediate
            'create device
            device = New Device(0, DeviceType.Hardware, fhWnd, CreateFlags.HardwareVertexProcessing, deviceSetting)
        Catch
        End Try


    End Sub

    'must be executed when form is resized
    Sub resetDevice()
        Try
            'you must putting them to zero to permit directX to change backbuffer size
            deviceSetting.BackBufferHeight = 0
            deviceSetting.BackBufferWidth = 0
            device.Reset(deviceSetting)
        Catch
        End Try
    End Sub

    Sub defaultSetting()
        Try
            device.RenderState.ZBufferEnable = True 'Z buffer on
            device.RenderState.Lighting = False 'lights off
            device.RenderState.ShadeMode = ShadeMode.Gouraud 'gouraud mode

            device.Transform.World = Matrix.Identity
            device.Transform.View = Matrix.LookAtLH(New Vector3(0, 0, -31), New Vector3(0, 0, 0), New Vector3(0, 1, 0))
            device.Transform.Projection = Matrix.PerspectiveFovLH(CSng(Math.PI / 3), CSng(3 / 3), 1, 2000)
        Catch
        End Try
    End Sub

    'create texture from file
    Function createTexture(ByVal filesrc As String, Optional ByVal colorKey As Integer = 0) As Texture
        Try
            Return TextureLoader.FromFile(device, filesrc, 0, 0, 0, 0, Format.Unknown, Pool.Managed, Filter.Linear, Filter.Linear, colorKey)
        Catch
        End Try

    End Function
    Function createMesh(ByVal fileSrc As String, ByVal materialOn As Boolean, ByVal textureOn As Boolean, ByVal TexPath As String) As oggX
        'create an oggX structure from file defining file path, if use material and texture and texture path 
        Try
            With createMesh
                'create a mesh
                Dim materials() As ExtendedMaterial
                If Dir(fileSrc, FileAttribute.Normal) = "" Then
                    MsgBox("Unable to load 3D Model - Model File Missing:" & vbCrLf & fileSrc, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Missing File")
                End If
                .mesh = Mesh.FromFile(fileSrc, MeshFlags.Managed, device, materials)
                'memorize material number
                .numX = UBound(materials)
                'create texture and material array
                ReDim .tex(.numX)
                ReDim .mat(.numX)
                Dim i As Integer
                'load all material
                For i = 0 To .numX
                    If textureOn Then
                        'load texture if presente in file X
                        If materials(i).TextureFilename <> "" Then
                            'System.Diagnostics.Debug.Print(materials(i).TextureFilename)
                            If Dir(TexPath & "\" & materials(i).TextureFilename, FileAttribute.Normal) = "" Then
                                MsgBox("Unable to load 3D Model - Texture File Missing:" & vbCrLf & TexPath & "\" & materials(i).TextureFilename, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Missing File")
                            End If
                            .tex(i) = TextureLoader.FromFile(device, TexPath & "\" & materials(i).TextureFilename)
                        End If
                    End If
                    If materialOn Then
                        .mat(i) = materials(i).Material3D
                    End If
                Next
            End With
        Catch
        End Try
    End Function
End Module
