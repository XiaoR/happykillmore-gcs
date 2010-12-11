Module modDirectShow
    Public Sub LoadComboWithCameras(ByVal inputCombo As ComboBox, Optional ByVal defaultCamera As String = "", Optional ByVal selectIndex As Boolean = False)
        Dim ds As DirectShowLib.DsDevice
        inputCombo.Items.Clear()
        For Each ds In DirectShowLib.DsDevice.GetDevicesOfCat(DirectShowLib.FilterCategory.VideoInputDevice)
            inputCombo.Items.Add(ds.Name)
            If defaultCamera <> "" Then
                If defaultCamera = ds.Name.ToString And selectIndex Then
                    inputCombo.SelectedIndex = inputCombo.Items.Count - 1
                End If
            End If
        Next
        If inputCombo.SelectedIndex = -1 And inputCombo.Items.Count > 0 And selectIndex Then
            inputCombo.SelectedIndex = 0
        End If
    End Sub
End Module
