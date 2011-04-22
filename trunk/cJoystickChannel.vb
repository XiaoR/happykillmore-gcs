Public Class cJoystickChannel
    Public Axis As Integer
    Public Servo As Integer
    Public Reversed As Boolean
    Public MinJoystickMovement As Long
    Public MaxJoystickMovement As Long
    Public LowerEndPoint As Integer
    Public UpperEndPoint As Integer
    Public SubTrim As Long
    Public LastPosition As Integer
    Public CurrentValue As Long
    Public SliderValue As Long
    Public OutputValue As Long

End Class
