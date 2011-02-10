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
    Public Function ConvertSingleToMavlink(ByVal inputNumber As Single) As String
        Dim sTemp As String = ""
        Dim nCount As Integer
        Dim bByte(0 To 3) As Byte

        bByte = BitConverter.GetBytes(inputNumber)
        ConvertSingleToMavlink = ""
        For nCount = 3 To 0 Step -1
            ConvertSingleToMavlink = ConvertSingleToMavlink & Chr(bByte(nCount))
        Next
    End Function
    Public Function ConvertMavlinkToInteger(ByVal inputString As String, Optional ByVal is2sCompliment As Boolean = False) As Integer
        ConvertMavlinkToInteger = CInt("&h" & Hex(Asc(Mid(inputString, 1, 1))).PadLeft(2, "0") & Hex(Asc(Mid(inputString, 2, 1))).PadLeft(2, "0"))

        If is2sCompliment = True Then
            If ConvertMavlinkToInteger > CInt("&h7FFF") Then
                ConvertMavlinkToInteger = -(((2 ^ (4 * 4) - 1) Xor ConvertMavlinkToInteger) + 1)
            End If
        End If
    End Function
    Public Function ConvertMavlinkToInteger32(ByVal inputString As String, Optional ByVal is2sCompliment As Boolean = False) As Integer
        ConvertMavlinkToInteger32 = CInt("&h" & Hex(Asc(Mid(inputString, 1, 1))).PadLeft(2, "0") & Hex(Asc(Mid(inputString, 2, 1))).PadLeft(2, "0") & Hex(Asc(Mid(inputString, 3, 1))).PadLeft(2, "0") & Hex(Asc(Mid(inputString, 4, 1))).PadLeft(2, "0"))

        If is2sCompliment = True Then
            If ConvertMavlinkToInteger32 > CInt("&h7FFFFFFF") Then
                ConvertMavlinkToInteger32 = -(((2 ^ (4 * 4) - 1) Xor ConvertMavlinkToInteger32) + 1)
            End If
        End If
    End Function
    Public Function ConvertIntegerToMavlink(ByVal inputValue As Integer, Optional ByVal is2sCompliment As Boolean = False) As String
        Dim sTemp As String
        If inputValue > CInt("&h7FFF") Then
            inputValue = -(((2 ^ (4 * 4) - 1) Xor inputValue) + 1)
        End If
        sTemp = Hex(inputValue).PadLeft(4, "0")
        ConvertIntegerToMavlink = Chr("&H" & Mid(sTemp, 1, 2)) & Chr("&H" & Mid(sTemp, 3, 2))
    End Function
    Public Function ConvertInteger32ToMavlink(ByVal inputValue As Integer, Optional ByVal is2sCompliment As Boolean = False) As String
        Dim sTemp As String
        If inputValue > CInt("&h7FFFFF") Then
            inputValue = -(((2 ^ (4 * 4) - 1) Xor inputValue) + 1)
        End If
        sTemp = Hex(inputValue).PadLeft(8, "0")
        ConvertInteger32ToMavlink = Chr("&H" & Mid(sTemp, 1, 2)) & Chr("&H" & Mid(sTemp, 3, 2)) & Chr("&H" & Mid(sTemp, 5, 2)) & Chr("&H" & Mid(sTemp, 7, 2))
    End Function
    Public Function ConvertMavlinkToLong(ByVal inputString As String, Optional ByVal is2sCompliment As Boolean = False) As Int64
        Dim sTemp As String = ""
        Dim bByte(0 To 7) As Byte
        Dim nCount As Integer

        Try
            sTemp = ""
            For nCount = 1 To Len(inputString)
                sTemp = sTemp & Hex(Asc(Mid(inputString, nCount, 1))).PadLeft(2, "0")
            Next
            'sTemp = "00000012DFFF55BD0"

            ConvertMavlinkToLong = CLng("&H" & sTemp)
            If is2sCompliment = True Then
                If ConvertMavlinkToLong > CInt("&h7FFFFFFF") Then
                    ConvertMavlinkToLong = -(((2 ^ (4 * 4) - 1) Xor ConvertMavlinkToLong) + 1)
                End If
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Function
    Public Function GetMAVlinkDate(ByVal inputValue As Int64) As Date
        Dim dTempDate As Date

        Dim cf As System.Globalization.CultureInfo
        cf = New System.Globalization.CultureInfo("en-US")
        dTempDate = DateAdd(DateInterval.Second, inputValue / 1000, dTempDate.Parse("1/1/1970", cf))
        GetMAVlinkDate = dTempDate.Date
    End Function
    Public Function GetMAVlinkTime(ByVal inputValue As Long) As Date
        Dim dTempDate As Date

        Try
            Dim cf As System.Globalization.CultureInfo
            cf = New System.Globalization.CultureInfo("en-US")
            dTempDate = DateAdd(DateInterval.Second, inputValue / 1000, dTempDate.Parse("1/1/1970", cf))
            GetMAVlinkTime = dTempDate.ToLongTimeString
        Catch ex2 As Exception
            Debug.Print(ex2.Message)
        End Try
    End Function
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
            Case 28
                GetMavAction = "Set Origin"
            Case 29
                GetMavAction = "Relay On"
            Case 30
                GetMavAction = "Relay Off"
            Case 31
                GetMavAction = "Get Image"
            Case 32
                GetMavAction = "Video Start"
            Case 33
                GetMavAction = "Video Stop"
            Case 34
                GetMavAction = "Reset Map"
            Case 35
                GetMavAction = "Reset Plan"
        End Select
    End Function
    Public Function GetMavMode(ByVal inputMode As Integer) As String
        Dim nCount As Integer

        For nCount = 0 To UBound(aCommandName)
            If inputMode = aCommandValue(nCount) Then
                GetMavMode = aCommandName(nCount)
                Exit For
            End If
        Next

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
