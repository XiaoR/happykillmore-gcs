Imports System.Threading
Imports Toub.Sound.Midi

Public Class cVario
    Private noteNum As Integer
    'Private prevNote As Byte
    Private nInstrumentNumber As Byte
    Public nAltChange As Long
    Private bClosing As Boolean = False

    Private Declare Function Beep Lib "kernel32" Alias "Beep" (ByVal dwFreq As Integer, ByVal dwDuration As Integer) As Integer
    Public Property instrumentNumber() As Byte
        Get
            instrumentNumber = nInstrumentNumber
        End Get
        Set(ByVal value As Byte)
            nInstrumentNumber = value
            Try
                'Toub.Sound.Midi.MidiPlayer.Play(New ProgramChange(0, 0, DirectCast(value, Toub.Sound.Midi.GeneralMidiInstruments)))
            Catch
            End Try
        End Set
    End Property
    Public Sub ThreadTask()
        Dim bPlayNote As Boolean
        Dim d1, d2 As Byte
        d1 = 60
        d2 = 127
        Dim zero As Byte = 0
        Dim nMidTone As Integer = 700

        Do
            Try
                'If prevNote <> 0 Then
                '    'Toub.Sound.Midi.MidiPlayer.Play(New NoteOff(0, zero, Convert.ToByte(prevNote), d2))
                'End If

                If nAltChange < 32500 And nAltChange > -32500 Then
                    noteNum = nAltChange / 5 + nMidTone
                    bPlayNote = True
                    If noteNum > nMidTone + 500 Or noteNum < nMidTone - 500 Or (noteNum <= nMidTone + 10 And noteNum >= nMidTone - 10) Then
                        bPlayNote = False
                        ' prevNote = 0
                        'Else
                        '    prevNote = noteNum
                    End If

                    If noteNum <> 0 And bPlayNote = True Then
                        If nAltChange > 0 Then
                            Beep(noteNum, 130 - (nAltChange / 70))
                        Else
                            Beep(noteNum, 220 - (nAltChange / 70))
                        End If
                        'Toub.Sound.Midi.MidiPlayer.Play(New NoteOn(0, Convert.ToByte(0), Convert.ToByte(noteNum), Convert.ToByte(127)))
                    End If
                End If
                Thread.Sleep(20)
                If bClosing = True Then
                    Exit Sub
                End If
            Catch ex As Exception
                Debug.Print(ex.Message)
                Thread.Sleep(200)
            End Try
        Loop

    End Sub

    Public Sub New()
        Try
            'Toub.Sound.Midi.MidiPlayer.OpenMidi()
            'Toub.Sound.Midi.MidiPlayer.Play(New ProgramChange(0, 0, DirectCast(nInstrumentNumber, Toub.Sound.Midi.GeneralMidiInstruments)))
        Catch
        End Try
    End Sub

    Public Sub StopSound()
        Try
            bClosing = True
            'If prevNote <> 0 Then
            '    'Toub.Sound.Midi.MidiPlayer.Play(New NoteOff(0, Convert.ToByte(0), Convert.ToByte(prevNote), Convert.ToByte(127)))
            'End If
        Catch
        End Try
        'Try
        '    Toub.Sound.Midi.MidiPlayer.CloseMidi()
        'Catch
        'End Try
    End Sub
End Class
