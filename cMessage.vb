Public Class cMessage
    Public Enum e_MessageType
        e_MessageType_Test = -2
        e_MessageType_HKO = -1
        e_MessageType_None = 0
        e_MessageType_NMEA = 1
        e_MessageType_SiRF
        e_MessageType_uBlox
        e_MessageType_MediaTek
        e_MessageType_MediaTekv16
        e_MessageType_ArduPilot_Attitude
        e_MessageType_ArduPilot_GPS
        e_MessageType_ArduIMU_Binary
        e_MessageType_ArduPilot_Home
        e_MessageType_ArduPilot_WP
        e_MessageType_ArduPilot_WPCount
        e_MessageType_ArduPilot_ModeChange
        e_MessageType_ArduPilotMega_Binary
        e_MessageType_UDB
        e_MessageType_UDB_SetHome
        e_MessageType_MAV
        e_MessageType_FY21AP
        e_MessageType_AttoPilot
        e_MessageType_AttoPilot18
        e_MessageType_GluonpilotT
        e_MessageType_GluonpilotC
        e_MessageType_GluonpilotD
        e_MessageType_Paparazzi
        e_MessageType_AttoSetParam
        e_MessageType_AttoOk
        e_MessageType_AUAV
    End Enum

    Public ValidMessage As Boolean
    Public RawMessage As String
    'Public RawBytes() As Byte
    Public MessageType As e_MessageType
    Public Checksum As String
    Public Header As String
    Public Packet As String
    Public PacketLength As Integer
    Public ID As Integer
    Public VisibleSentence As String
    Public GPSDateTime As Date
    Public ValidDateTime As Boolean
    Public VehicleID As Integer
    Public ValidCrop As Integer

    Public Sub New()
        'RawBytes = New Byte() {}
    End Sub
End Class
