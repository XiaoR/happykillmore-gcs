'Imports System.Speech
'Imports System.Media
Module modSpeech

    Public Function PlaySoundFile(ByVal inputFile As String) As Boolean
        Try
            Dim MyPlayer As New System.Media.SoundPlayer()
            PlaySoundFile = True
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
        Dim sVoices() As String
        Dim speaker As System.Speech.Synthesis.SpeechSynthesizer
        Try
            speaker = New System.Speech.Synthesis.SpeechSynthesizer
            speaker.Rate = 0
            speaker.Volume = 100
            speaker.SelectVoice(voiceName)
            speaker.SpeakAsync(ConvertSpeech(inputMessage))
        Catch
            sVoices = ReturnAllSpeechSynthesisVoices()
            If UBound(sVoices) >= 0 Then
                speaker = New System.Speech.Synthesis.SpeechSynthesizer
                speaker.Rate = 0
                speaker.Volume = 100
                speaker.SelectVoice(sVoices(0))
                speaker.SpeakAsync(ConvertSpeech(inputMessage))
            End If
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
