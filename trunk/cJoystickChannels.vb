Public Class cJoystickChannels
    Dim m_Joysticks As Collection
    Public DGPS As Boolean

    Default Public Property item(ByVal Index As Integer) As cJoystickChannel
        Get
            item = m_Joysticks(Index)
        End Get
        Set(ByVal value As cJoystickChannel)

        End Set
    End Property

    Public Sub add(ByVal newJoystick As cJoystickChannel)
        m_Joysticks.Add(newJoystick)
    End Sub

    Public Sub Delete(ByVal Index As Integer)
        m_Joysticks.Remove(Index)
    End Sub

    Public Sub New()
        m_Joysticks = New Collection
    End Sub
End Class
