Public Class cValueDesc

    Public Value As Object
    Public Description As String

    Public Sub New(ByVal NewValue As Object, ByVal NewDescription As String)
        Value = NewValue
        Description = NewDescription
    End Sub

    Public Overrides Function ToString() As String
        Return Description
    End Function

End Class

