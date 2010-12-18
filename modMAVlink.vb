Module modMAVlink
    Public Function ConvertMavlinkToSingle(ByVal inputString As String) As Single
        Dim sTemp As String = ""
        Dim bByte(0 To 3) As Byte
        Dim nCount As Integer

        For nCount = Len(inputString) To 1 Step -1
            bByte(4 - nCount) = CByte(Asc(inputString.Substring(nCount - 1, 1)))
        Next
        ConvertMavlinkToSingle = BitConverter.ToSingle(bByte, 0)
        If Double.IsNaN(ConvertMavlinkToSingle) Then
            ConvertMavlinkToSingle = 0
        End If
    End Function
    Public Function ConvertMavlinkToInteger(ByVal inputString As String, Optional ByVal is2sCompliment As Boolean = False) As Integer
        ConvertMavlinkToInteger = CInt("&h" & Hex(Asc(Mid(inputString, 1, 1))).PadLeft(2, "0") & Hex(Asc(Mid(inputString, 2, 1))).PadLeft(2, "0"))
        If is2sCompliment = True Then
            If ConvertMavlinkToInteger > CInt("&h7FFF") Then
                ConvertMavlinkToInteger = -(((2 ^ (4 * 4) - 1) Xor ConvertMavlinkToInteger) + 1)
            End If
        End If
    End Function
    Public Function ConvertMavlinkToLong(ByVal inputString As String, Optional ByVal is2sCompliment As Boolean = False) As Long
        Dim sTemp As String = ""
        Dim bByte(0 To 7) As Byte
        Dim nCount As Integer

        sTemp = ""
        For nCount = 1 To Len(inputString)
            sTemp = sTemp & Hex(Asc(Mid(inputString, nCount, 1))).PadLeft(2, "0")
        Next

        ConvertMavlinkToLong = CLng("&h" & sTemp)
        If is2sCompliment = True Then
            If ConvertMavlinkToLong > CInt("&h7FFFFFFF") Then
                ConvertMavlinkToLong = -(((2 ^ (4 * 4) - 1) Xor ConvertMavlinkToLong) + 1)
            End If
        End If
    End Function
    Public Sub GetMAVlinkDateTime(ByVal inputValue As Long)
        Dim dTempDate As Date

        Dim cf As System.Globalization.CultureInfo
        cf = New System.Globalization.CultureInfo("en-US")
        dTempDate = DateAdd(DateInterval.Second, inputValue / 1000, dTempDate.Parse("1/1/1970", cf))
        dGPSDate = dTempDate.Date
        dGPSTime = dTempDate.ToLongTimeString
    End Sub
    Public Function MavlinkScaledToStandard(ByVal inputValue As Integer) As Integer
        MavlinkScaledToStandard = (((inputValue + 10000) / 20000) * 1000) + 1000
    End Function
    Public Function GetMavAction(ByVal inputAction As Integer) As String
        Select Case inputAction
            Case 1
                GetMavAction = "Motor Start"
            Case 2
                GetMavAction = "Launch"
            Case 3
                GetMavAction = "Return"
            Case 4
                GetMavAction = "Emergency Land"
            Case 5
                GetMavAction = "Emergency Kill"
            Case 6
                GetMavAction = "Confirm Kill"
            Case 7
                GetMavAction = "Continue"
            Case 8
                GetMavAction = "Motor Stop"
            Case 9
                GetMavAction = "Halt"
            Case 10
                GetMavAction = "Shutdown"
            Case 11
                GetMavAction = "Reboot"
            Case 12
                GetMavAction = "Manual Mode"
            Case 13
                GetMavAction = "Auto Mode"
            Case 14
                GetMavAction = "Storage Read"
            Case 15
                GetMavAction = "Storage Write"
            Case 16
                GetMavAction = "Calibrate R/C"
            Case 17
                GetMavAction = "Calibrate Gyro"
            Case 18
                GetMavAction = "Calibrate Mag"
            Case 19
                GetMavAction = "Calibrate Acc"
            Case 20
                GetMavAction = "Calibrate Pressure"
            Case 21
                GetMavAction = "Rec Start"
            Case 22
                GetMavAction = "Rec Pause"
            Case 23
                GetMavAction = "Rec Stop"
            Case 24
                GetMavAction = "Take-off"
            Case 25
                GetMavAction = "Navigate"
            Case 26
                GetMavAction = "Land"
            Case 27
                GetMavAction = "Loiter"
        End Select
    End Function
    Public Function GetMavMode(ByVal inputMode As Integer) As String
        Select Case inputMode
            Case 1
                GetMavMode = "Locked"
            Case 2
                GetMavMode = "Manual"
            Case 3
                GetMavMode = "Guided"
            Case 4
                GetMavMode = "Auto"
            Case 5
                GetMavMode = "Test1"
            Case 6
                GetMavMode = "Test2"
            Case 7
                GetMavMode = "Test3"
            Case 8
                GetMavMode = "Ready"
            Case 9
                GetMavMode = "R/C Training"
        End Select
    End Function
    Public Function GetMavState(ByVal inputState As Integer) As String
        Select Case inputState
            Case 0
                GetMavState = "Initializing"
            Case 1
                GetMavState = "Booting"
            Case 2
                GetMavState = "Calibrating"
            Case 3
                GetMavState = "Standby"
            Case 4
                GetMavState = "Active"
            Case 5
                GetMavState = "Critical"
            Case 6
                GetMavState = "Emergency"
            Case 7
                GetMavState = "Power Off"
        End Select
    End Function
    Public Function GetMavNav(ByVal inputNav As Integer) As String
        Select Case inputNav
            Case 0
                GetMavNav = "Grounded"
            Case 1
                GetMavNav = "Lift-off"
            Case 2
                GetMavNav = "Hold"
            Case 3
                GetMavNav = "Waypoint"
            Case 4
                GetMavNav = "Vector"
            Case 5
                GetMavNav = "Returning"
            Case 6
                GetMavNav = "Landing"
            Case 7
                GetMavNav = "Lost"
        End Select
    End Function
End Module
