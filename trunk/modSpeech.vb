Imports System.Speech
Module modSpeech
    Dim speaker As New System.Speech.Synthesis.SpeechSynthesizer

    Public Sub PlayMessage(ByVal inputMessage As String, ByVal voiceName As String)
        Try
            speaker.Rate = 0
            speaker.Volume = 100
            speaker.SelectVoice(voiceName)
            speaker.SpeakAsync(ConvertSpeech(inputMessage))
        Catch
        End Try
    End Sub
    Public Function ReturnAllSpeechSynthesisVoices() As String()
        Dim oSpeech As New System.Speech.Synthesis.SpeechSynthesizer()
        Dim installedVoices As System.Collections.ObjectModel.ReadOnlyCollection(Of System.Speech.Synthesis.InstalledVoice) = oSpeech.GetInstalledVoices

        Dim names(installedVoices.Count - 1) As String
        For i As Integer = 0 To installedVoices.Count - 1
            names(i) = installedVoices(i).VoiceInfo.Name
        Next

        Return names
    End Function

End Module
