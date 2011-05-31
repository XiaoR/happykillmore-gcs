Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D
Imports System.io
Public Class _3DMesh
    Dim angle As Single 'rotation angle
    Dim model As oggX
    Dim nScaleFactor As Single
    Dim oBackColor As System.Drawing.Color
    Dim bHasRun As Boolean = False
    Dim bLocked As Boolean = False
    Private Sub CreateSettingsFile(ByVal rootpath As String, ByVal modelname As String, ByVal filename As String, ByVal scale As Integer, ByVal backcolor As String)
        Dim sOutputFile As StreamWriter

        If Dir(rootpath & modelname, FileAttribute.Directory) <> "" Then
            sOutputFile = New StreamWriter(rootpath & modelname & "\Settings.txt")
            sOutputFile.WriteLine("Filename=" & filename)
            sOutputFile.WriteLine("Scale=" & scale)
            sOutputFile.WriteLine("BackColor=" & backcolor)
            If UCase(sModelURL) <> UCase(g_Default_DAE_URL & sModelName & ".DAE") Then
                sOutputFile.WriteLine("Dae URL=" & sModelURL)
            End If
            If nDaeHeadingOffset = 180 Then
                sOutputFile.WriteLine("Dae Heading=R")
            Else
                sOutputFile.WriteLine("Dae Heading=N")
            End If
            If n3DHeadingOffset = 180 Then
                sOutputFile.WriteLine("3D Heading=R")
            Else
                sOutputFile.WriteLine("3D Heading=N")
            End If
            sOutputFile.Close()
            sOutputFile = Nothing
        End If
    End Sub
    Sub loadObject(ByVal modelName As String, ByVal rootPath As String)
        Dim sFilename As String
        Dim sFilePath As String
        Dim sFileContents As String
        Dim sSplit() As String
        Dim sSplit2() As String
        Dim nCount As Integer
        Dim sColor As String

        Try
            sFilename = modelName & ".x"
            sFilePath = rootPath & modelName
            nScaleFactor = 70
            oBackColor = Color.LightGray

            sModelURL = g_Default_DAE_URL & sModelName & ".dae"
            nDaeHeadingOffset = 0
            nDaePitchRollOffset = 1
            n3DHeadingOffset = 0
            n3DPitchRollOffset = 1

            If Dir(rootPath & modelName & "\Settings.txt", FileAttribute.Normal) = "" Then

                Select Case modelName
                    Case "AeroQuad"
                        CreateSettingsFile(rootPath, modelName, "aeroquad.x", 65, GetColor(Color.LightGray, , False))
                    Case "FunJet"
                        CreateSettingsFile(rootPath, modelName, "funjet.x", 75, GetColor(Color.LightGray, , False))
                    Case "T-Rex 450"
                        CreateSettingsFile(rootPath, modelName, "trex450.x", 70, GetColor(Color.LightGray, , False))
                    Case "EasyStar"
                        CreateSettingsFile(rootPath, modelName, "EasyStar.x", 75, GetColor(Color.LightGray, , False))
                    Case Else
                        CreateSettingsFile(rootPath, modelName, modelName & ".x", 70, GetColor(Color.LightGray, , False))
                End Select
            Else
                Try
                    sFileContents = GetFileContents(rootPath & modelName & "\Settings.txt")
                    sSplit = Split(sFileContents, vbCrLf)
                    For nCount = 0 To UBound(sSplit)
                        sSplit2 = Split(sSplit(nCount), "=")
                        Select Case UCase(sSplit2(0))
                            Case "FILENAME"
                                sFilename = sSplit2(1)
                                sFilePath = rootPath & modelName
                            Case "SCALE"
                                nScaleFactor = Convert.ToInt32(sSplit2(1))
                            Case "BACKCOLOR"
                                sColor = sSplit2(1)
                                oBackColor = Color.FromArgb(255, Convert.ToInt32(Mid(sColor, 5, 2), 16), Convert.ToInt32(Mid(sColor, 3, 2), 16), Convert.ToInt32(Mid(sColor, 1, 2), 16))
                            Case "DAE URL"
                                If Trim(sSplit2(1)) <> "" Then
                                    sModelURL = sSplit2(1)
                                End If
                            Case "DAE HEADING"
                                If sSplit2(1) = "R" Then
                                    nDaeHeadingOffset = 180
                                    nDaePitchRollOffset = -1
                                End If
                            Case "3D HEADING"
                                If sSplit2(1) = "R" Then
                                    n3DHeadingOffset = 180
                                    n3DPitchRollOffset = -1
                                End If
                        End Select
                    Next
                Catch
                End Try
            End If

            If Dir(sFilePath & "\" & sFilename, FileAttribute.Normal) = "" Then
                sFilename = "Easystar.x"
                sFilePath = rootPath & "Easystar"
            End If
            'create a model
            model = createMesh(sFilePath & "\" & sFilename, True, True, sFilePath)

        Catch
            Debug.Print("Here")
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
                Debug.Print(e2.Message)
                device.Clear(ClearFlags.Target Or ClearFlags.ZBuffer, oBackColor, 1, 0)
                resetDevice()
                defaultSetting()
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
