Public Class cMessage
    Public Enum e_MessageType
        e_MessageType_None = 0
        e_MessageType_NMEA = 1
        e_MessageType_SiRF
        e_MessageType_uBlox
        e_MessageType_MediaTek
        e_MessageType_ArduPilot_Attitude
        e_MessageType_ArduPilot_GPS
        e_MessageType_ArduIMU_Binary
        e_MessageType_ArduPilot_Home
        e_MessageType_ArduPilot_WP
        e_MessageType_ArduPilot_WPCount
        e_MessageType_ArduPilot_ModeChange
    End Enum

    Public ValidMessage As Boolean
    Public RawMessage As String
    Public MessageType As e_MessageType
    Public Checksum As String
    Public Header As String
    Public Packet As String
    Public PacketLength As Integer
    Public ID As Integer
    Public VisibleSentence As String
End Class
