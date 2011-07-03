Module modcrc16
    Const X25_INIT_CRC As Integer = &HFFFF
    Const X25_VALIDATE_CRC As Integer = &HF0B8

    Private Function crc_accumulate(ByVal b As Byte, ByRef crc As UShort, Optional ByVal showDetails As Boolean = False) As UShort
        Dim ch As Byte
        ch = CByte(b Xor CByte(crc And &HFF))
        ch = CByte(ch Xor (ch << 4))
        crc_accumulate = ((CInt(crc) >> 8) Xor (CInt(ch) << 8) Xor (CInt(ch) << 3) Xor (CInt(ch) >> 4))
        If showDetails = True Then
            Debug.Print("b=" & b & ",crc=" & crc & ",crc_accumulate=" & crc_accumulate)
        End If
    End Function

    Public Function crc_calculate(ByVal InputString As String) As String
        Dim crcTmp As UShort
        Dim i As Integer

        Try
            crcTmp = X25_INIT_CRC

            For i = 2 To Len(InputString)
                crcTmp = crc_accumulate(Convert.ToByte(Asc(InputString.Substring(i - 1, 1))), crcTmp)
                'Debug.Print("Byte #" & i & " = " & Convert.ToByte(Asc(InputString.Substring(i - 1, 1))) & " crcTmp=" & crcTmp)
            Next

            'crc_calculate = Hex(crcTmp And &HFFFF).PadLeft(2, "0")

            'crc_calculate = crcTmp
            crc_calculate = Hex(crcTmp).PadLeft(4, "0")
            'crc_calculate = AddCharacter("&h" & Mid(crc_calculate, 3, 2)) & AddCharacter("&h" & Mid(crc_calculate, 1, 2))
            crc_calculate = Chr("&h" & Mid(crc_calculate, 3, 2)) & Chr("&h" & Mid(crc_calculate, 1, 2))
            'crc_calculate = Chr(Mid(crc_calculate, 3, 2)) & Chr(Mid(crc_calculate, 1, 2))
        Catch ex As Exception
        End Try
    End Function
    Public Function crc_calculate_byte2(ByVal InputString As String) As Byte()
        Dim crcTmp As UShort
        Dim i As Integer
        Dim sTemp As String
        Dim arr(0 To 1) As Byte

        Try
            crcTmp = X25_INIT_CRC

            For i = 2 To Len(InputString)
                crcTmp = crc_accumulate(Convert.ToByte(Asc(InputString.Substring(i - 1, 1))), crcTmp)
                'Debug.Print("Byte #" & i & " = " & Convert.ToByte(Asc(InputString.Substring(i - 1, 1))) & " crcTmp=" & crcTmp)
            Next

            'crc_calculate = Hex(crcTmp And &HFFFF).PadLeft(2, "0")

            'crc_calculate = crcTmp
            sTemp = Hex(crcTmp).PadLeft(4, "0")
            arr(0) = CInt("&H" & sTemp.Substring(0, 2))
            arr(1) = CInt("&H" & sTemp.Substring(2, 2))
            Return arr
            'crc_calculate = AddCharacter("&h" & Mid(crc_calculate, 3, 2)) & AddCharacter("&h" & Mid(crc_calculate, 1, 2))
            'crc_calculate = Chr("&h" & Mid(crc_calculate, 3, 2)) & Chr("&h" & Mid(crc_calculate, 1, 2))
            'crc_calculate = Chr(Mid(crc_calculate, 3, 2)) & Chr(Mid(crc_calculate, 1, 2))
        Catch ex As Exception
        End Try
    End Function
    Public Function crc_calculate_byte(ByVal inputBytes() As Byte, Optional ByVal showDetails As Boolean = False) As Byte()
        Dim crcTmp As UShort
        Dim nCount As Integer
        Dim arr(0 To 1) As Byte

        Try
            crcTmp = X25_INIT_CRC

            For nCount = 1 To inputBytes(1) + 5
                crcTmp = crc_accumulate(inputBytes(nCount), crcTmp, showDetails)
            Next

            arr(0) = crcTmp And 255
            arr(1) = (crcTmp >> 8) And 255
            If showDetails = True Then
                Debug.Print("arr0=" & Hex(arr(0)) & ",arr1=" & Hex(arr(1)) & ",arr0=" & (arr(0)) & ",arr1=" & (arr(1)))
            End If

            Return arr
        Catch ex As Exception
            Debug.Print("Warning: MAVlink packet size set incorrectly")
        End Try
    End Function
    Public Function crc_calculate_long(ByVal inputBytes() As Byte) As Long
        Dim crcTmp As UShort
        Dim nCount As Integer

        Try
            crcTmp = X25_INIT_CRC

            For nCount = 1 To inputBytes(1) + 5
                crcTmp = crc_accumulate(inputBytes(nCount), crcTmp)
            Next

            crc_calculate_long = crcTmp And &HFFFF
        Catch ex As Exception
        End Try
    End Function
    Public Function ConvertChrHex(ByVal inputHex As String) As String
        ConvertChrHex = Convert.ToChar(Convert.ToInt32(inputHex, 16), System.Globalization.CultureInfo.InvariantCulture)
    End Function
    Public Function ConvertChrDec(ByVal inputDec As String) As String
        ConvertChrDec = Convert.ToChar(Convert.ToInt32(inputDec, 10), System.Globalization.CultureInfo.InvariantCulture)
    End Function

End Module