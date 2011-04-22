Imports System.Speech
Imports System.Media
Module modSpeech
    Dim speaker As New System.Speech.Synthesis.SpeechSynthesizer

    Public Function PlaySoundFile(ByVal inputFile As String) As Boolean
        Dim MyPlayer As New SoundPlayer()
        PlaySoundFile = True
        Try
            If Dir(GetRootPath() & "Audio\" & inputFile & ".wav", FileAttribute.Normal) <> "" Then
                MyPlayer.SoundLocation = GetRootPath() & "Audio\" & inputFile & ".wav"
                MyPlayer.Play()
            Else
                PlaySoundFile = False
            End If
        Catch
            PlaySoundFile = False
        End Try
    End Function
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
        Try
            Dim oSpeech As New System.Speech.Synthesis.SpeechSynthesizer()
            Dim installedVoices As System.Collections.ObjectModel.ReadOnlyCollection(Of System.Speech.Synthesis.InstalledVoice) = oSpeech.GetInstalledVoices

            Dim names(installedVoices.Count - 1) As String
            For i As Integer = 0 To installedVoices.Count - 1
                names(i) = installedVoices(i).VoiceInfo.Name
            Next

            Return names
        Catch
        End Try
    End Function

End Module
