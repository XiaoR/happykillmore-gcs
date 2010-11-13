Imports Microsoft.Win32
Module modRegistry
    'Utility Class for Reading INI Files
    ' API functions
    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As System.Text.StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    Private Declare Ansi Function GetPrivateProfileInt Lib "kernel32.dll" Alias "GetPrivateProfileIntA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal nDefault As Integer, ByVal lpFileName As String) As Integer
    Private Declare Ansi Function FlushPrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As Integer, ByVal lpKeyName As Integer, ByVal lpString As Integer, ByVal lpFileName As String) As Integer
    Dim strFilename As String

    ' Read-only filename property
    Public Property FileName() As String
        Get
            Return strFilename
        End Get
        Set(ByVal Value As String)
            strFilename = FileName
        End Set
    End Property

    Public Function GetString(ByVal Section As String, ByVal Key As String, ByVal [Default] As String, Optional ByVal filename As String = "") As String
        ' Returns a string from your INI file
        Dim intCharCount As Integer
        Dim objResult As New System.Text.StringBuilder(256)
        intCharCount = GetPrivateProfileString(Section, Key, [Default], objResult, objResult.Capacity, IIf(filename <> "", filename, strFilename))
        If intCharCount > 0 Then
            GetString = Left(objResult.ToString, intCharCount)
        Else
            GetString = [Default]
        End If
    End Function

    Public Function GetInteger(ByVal Section As String, ByVal Key As String, ByVal [Default] As Integer, Optional ByVal filename As String = "") As Integer
        ' Returns an integer from your INI file
        Return GetPrivateProfileInt(Section, Key, [Default], IIf(filename <> "", filename, strFilename))
    End Function

    Public Function GetBoolean(ByVal Section As String, ByVal Key As String, ByVal [Default] As Boolean, Optional ByVal filename As String = "") As Boolean
        ' Returns a boolean from your INI file
        Return CBool(GetPrivateProfileInt(Section, Key, CInt([Default]), IIf(filename <> "", filename, strFilename)))
    End Function

    Public Sub WriteString(ByVal Section As String, ByVal Key As String, ByVal Value As String, Optional ByVal filename As String = "")
        ' Writes a string to your INI file
        WritePrivateProfileString(Section, Key, Value, IIf(filename <> "", filename, strFilename))
        Flush()
    End Sub

    Public Sub WriteInteger(ByVal Section As String, ByVal Key As String, ByVal Value As Integer, Optional ByVal filename As String = "")
        ' Writes an integer to your INI file
        WriteString(Section, Key, CStr(Value), IIf(filename <> "", filename, strFilename))
        Flush()
    End Sub

    Public Sub WriteBoolean(ByVal Section As String, ByVal Key As String, ByVal Value As Boolean, Optional ByVal filename As String = "")
        ' Writes a boolean to your INI file
        WriteString(Section, Key, CStr(CInt(Value)), IIf(filename <> "", filename, strFilename))
        Flush()
    End Sub

    Private Sub Flush(Optional ByVal filename As String = "")
        ' Stores all the cached changes to your INI file
        FlushPrivateProfileString(0, 0, 0, IIf(filename <> "", filename, strFilename))
    End Sub

    Public Function GetRegSetting(ByVal Section As String, ByVal Key As String, Optional ByVal defaultValue As String = "", Optional ByVal hKeyName As RegistryHive = RegistryHive.LocalMachine) As String
        Dim regKey As RegistryKey

        Select Case hKeyName
            Case RegistryHive.ClassesRoot
                regKey = Registry.ClassesRoot.OpenSubKey(Section, False)
            Case RegistryHive.CurrentConfig
                regKey = Registry.CurrentConfig.OpenSubKey(Section, False)
            Case RegistryHive.CurrentUser
                regKey = Registry.CurrentUser.OpenSubKey(Section, False)
            Case RegistryHive.DynData
                regKey = Registry.DynData.OpenSubKey(Section, False)
            Case RegistryHive.LocalMachine
                regKey = Registry.LocalMachine.OpenSubKey(Section, False)
            Case RegistryHive.PerformanceData
                regKey = Registry.PerformanceData.OpenSubKey(Section, False)
            Case RegistryHive.Users
                regKey = Registry.Users.OpenSubKey(Section, False)
            Case Else
                regKey = Registry.LocalMachine.OpenSubKey(Section, False)
        End Select

        If regKey Is Nothing Then
            GetRegSetting = defaultValue
        Else
            GetRegSetting = regKey.GetValue(Key, defaultValue)
            regKey.Close()
        End If
    End Function
    Public Sub SaveRegSetting(ByVal Section As String, ByVal Key As String, ByVal value As String, Optional ByVal hKeyName As RegistryHive = RegistryHive.LocalMachine)
        Dim regKey As RegistryKey

        Select Case hKeyName
            Case RegistryHive.ClassesRoot
                regKey = Registry.ClassesRoot.OpenSubKey(Section, True)
            Case RegistryHive.CurrentConfig
                regKey = Registry.CurrentConfig.OpenSubKey(Section, True)
            Case RegistryHive.CurrentUser
                regKey = Registry.CurrentUser.OpenSubKey(Section, True)
            Case RegistryHive.DynData
                regKey = Registry.DynData.OpenSubKey(Section, True)
            Case RegistryHive.LocalMachine
                regKey = Registry.LocalMachine.OpenSubKey(Section, True)
            Case RegistryHive.PerformanceData
                regKey = Registry.PerformanceData.OpenSubKey(Section, True)
            Case RegistryHive.Users
                regKey = Registry.Users.OpenSubKey(Section, True)
            Case Else
                regKey = Registry.LocalMachine.OpenSubKey(Section, True)
        End Select
        If regKey Is Nothing Then
            Select Case hKeyName
                Case RegistryHive.ClassesRoot
                    regKey = Registry.ClassesRoot.CreateSubKey(Section)
                Case RegistryHive.CurrentConfig
                    regKey = Registry.CurrentConfig.CreateSubKey(Section)
                Case RegistryHive.CurrentUser
                    regKey = Registry.CurrentUser.CreateSubKey(Section)
                Case RegistryHive.DynData
                    regKey = Registry.DynData.CreateSubKey(Section)
                Case RegistryHive.LocalMachine
                    regKey = Registry.LocalMachine.CreateSubKey(Section)
                Case RegistryHive.PerformanceData
                    regKey = Registry.PerformanceData.CreateSubKey(Section)
                Case RegistryHive.Users
                    regKey = Registry.Users.CreateSubKey(Section)
                Case Else
                    regKey = Registry.LocalMachine.CreateSubKey(Section)
            End Select
        End If

        regKey.SetValue(Key, value)
        regKey.Close()
    End Sub
End Module
