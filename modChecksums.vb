Module modChecksums
    Public Function GetChecksum(ByVal inputString As String) As String
        Dim nCount As Integer
        Dim nHolder As Integer

        nHolder = 0
        For nCount = 1 To Len(inputString)
            nHolder = (nHolder Xor CByte(Asc(Mid(inputString, nCount, 1))))
        Next nCount
        GetChecksum = IIf(Len(Hex(nHolder)) = 1, "0", "") & Hex(nHolder)
    End Function
    Public Function GetSiRFChecksum(ByVal inputString As String) As String
        Dim nLength As Integer
        Dim nCount As Integer
        Dim nA As Long

        nA = 0

        nLength = Len(inputString)
        For nCount = 1 To nLength
            nA = nA + Asc(Mid(inputString, nCount, 1))
            nA = nA And ((2 ^ 15) - 1)
        Next nCount

        '    Debug.Print "nA=" & Hex(nA) & ",nB=" & Hex(nB)
        GetSiRFChecksum = Hex(nA)
        For nCount = Len(GetSiRFChecksum) + 1 To 4
            GetSiRFChecksum = "0" & GetSiRFChecksum
        Next nCount
        GetSiRFChecksum = Chr("&h" & Mid(GetSiRFChecksum, 1, 2)) & Chr("&h" & Mid(GetSiRFChecksum, 3, 2))
    End Function
    Public Function GetuBloxChecksum(ByVal inputString As String) As String
        Dim nLength As Integer
        Dim nCount As Integer
        Dim nA As Long
        Dim nB As Long

        nA = 0
        nB = 0

        nLength = Len(inputString)
        For nCount = 1 To nLength
            nA = nA + Asc(Mid(inputString, nCount, 1))
            nB = nB + nA
        Next nCount

        nA = nA And &HFF
        nB = nB And &HFF

        '    Debug.Print "nA=" & Hex(nA) & ",nB=" & Hex(nB)
        GetuBloxChecksum = Chr(nA) & Chr(nB)
    End Function
End Module
