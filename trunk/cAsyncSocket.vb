Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports Microsoft.VisualBasic

' State object for reading client data asynchronously

Public Class StateObject
    Public SenderRemote As EndPoint
    ' Client  socket.
    Public workSocket As Socket = Nothing
    ' Size of receive buffer.
    Public Const BufferSize As Integer = 2048
    ' Receive buffer.
    Public buffer(BufferSize) As Byte
    'To-Do: Make a reference to some playerdata
End Class 'StateObject


Public Class AsynchronousSocketListener
    ' Thread signal.
    Public Shared allDone As New ManualResetEvent(False)
    'Mutex
    Private Shared mut As New Mutex()
    'Clients
    Public Shared clients As New List(Of StateObject)
    'Log
    Public Shared log As ListBox
    Public mainThread As Thread
    Public Shared senderRemote As EndPoint

    'Delegate Sub WriteToLogDelegate() '(ByVal entry As String)

    Public Sub New(ByRef log_ As ListBox)
        log = log_
        log.Text = "Asynchronous server socket initialized"
        mainThread = New Thread(AddressOf Main)
        mainThread.Start()
    End Sub

    'Delegate method to write to the data log
    Public Shared Sub WriteToLogMethod(ByVal entry As String)
        'log.Text.Insert(log.Text.Length - 2, Chr(13) & entry)
        log.Text = log.Items.Add(entry)
    End Sub
    'Simplified Subroutine to write to the data log
    'Public Shared Sub WriteToLog(ByVal entry As String)
    '    Dim logDelegate As New WriteToLogDelegate(AddressOf WriteToLogMethod)
    '    If log.InvokeRequired() Then
    '        log.Invoke(logDelegate, entry)
    '    Else
    '        logDelegate(entry)
    '    End If
    'End Sub

    ' This server waits for a connection and then uses  asychronous operations to
    ' accept the connection, get data from the connected client
    Public Shared Sub Main()
        'mut.WaitOne()
        'log.Text = "Started"
        'mut.ReleaseMutex()

        ' Data buffer for incoming data.
        Dim bytes() As Byte = New [Byte](2047) {}

        ' Establish the local endpoint for the socket.
        Dim ipHostInfo As IPHostEntry = Dns.GetHostEntry(sSocketIPaddress)
        Dim ipAddress As IPAddress = ipHostInfo.AddressList(0)
        Dim lEndPoint As IPEndPoint
        Dim listener As Socket

        ' Create a TCP/IP socket.
        If nSocketType = ProtocolType.Tcp Then
            listener = New Socket(AddressFamily.InterNetwork, SocketType.Stream, nSocketType)
            lEndPoint = New IPEndPoint(ipAddress.Any, nSocketPortNumber)
            listener.Bind(lEndPoint)
            listener.Listen(1)

            While bShutdown = False And bConnected = True
                ' Set the event to nonsignaled state.
                allDone.Reset()

                ' Start an asynchronous socket to listen for connections.
                listener.BeginAccept(New AsyncCallback(AddressOf AcceptCallback), listener)

                ' Wait until a connection is made and processed before continuing.

                allDone.WaitOne(100)
            End While
            If bShutdown = True Or bConnected = False Then
                If listener.IsBound = True Then
                    'listener.Shutdown(SocketShutdown.Both)
                    listener.Close()
                End If
            End If
        Else
            listener = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, nSocketType)
            lEndPoint = New IPEndPoint(ipAddress.Any, nSocketPortNumber)

            senderRemote = CType(lEndPoint, EndPoint)

            listener.Bind(lEndPoint)
            Dim state As New StateObject

            state.workSocket = listener
            state.SenderRemote = senderRemote

            mut.WaitOne()
            clients.Add(state)
            mut.ReleaseMutex()
            allDone.Set()
        End If


        ' Bind the socket to the local endpoint and listen for incoming connections.
        'WriteToLog("Waiting for a connection...")

    End Sub 'Main

    Public Shared Sub AcceptCallback(ByVal ar As IAsyncResult)
        ' Get the socket that handles the client request.
        Dim listener As Socket = CType(ar.AsyncState, Socket)
        ' End the operation.
        Try
            Dim handler As Socket = listener.EndAccept(ar)

            ' Create the state object for the async receive.
            Dim state As New StateObject
            state.workSocket = handler

            If bShutdown = True Or bConnected = False Then
                listener.Close()
            End If

            'state.workSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveCallback), state)

            'Add the client socket to a list for easy reference: Note: Not sure if the mutex is necessary
            mut.WaitOne()
            clients.Add(state)
            mut.ReleaseMutex()

            'WriteToLog("Connection")

            'I HAVE NO IDEA WHERE TO PUT THIS allDone.Set()
            'Signal the main thread to continue.
            allDone.Set()
        Catch
        End Try
    End Sub 'AcceptCallback

    Public Shared Sub ReceiveCallback(ByVal ar As IAsyncResult)
        Dim content As String = String.Empty
        Dim bytes() As Byte = New [Byte](2047) {}
        Dim ipHostInfo As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        Dim ipAddress As IPAddress = ipHostInfo.AddressList(0)
        Dim localEndPoint As IPEndPoint
        Dim listener As Socket
        Dim cpBytesRec As Int64
        Dim state As StateObject
        Dim handler As Socket
        Dim lEndPoint As IPEndPoint

        ' Retrieve the state object and the handler socket
        ' from the asynchronous state object.
        'Dim state As StateObject = CType(ar.AsyncState, StateObject)
        Try
            If nSocketType = ProtocolType.Tcp Then
                If clients.Count > 0 Then
                    state = clients(0)

                    ' Read data from the client socket. 
                    If (state.workSocket.Connected()) Then
                        'Dim bytesRead As Integer = handler.EndReceive(ar)
                        handler = state.workSocket

                        If handler.Available > 0 Then
                            cpBytesRec = state.workSocket.Receive(bytes)
                            content = Encoding.ASCII.GetString(bytes, 0, cpBytesRec)
                            'If state.workSocket.Receive(bytes, > 0 Then
                            '    ' There  might be more data, so store the data received so far.
                            '    content = Encoding.ASCII.GetString(state.buffer, 0, state.workSocket.ReceiveBufferSize)

                            '    'Send the Security Policy Data If Flash 9 Requests it
                            '    Dim policyFileNeeded As Boolean = False

                            sBuffer = sBuffer & content
                            'log.Invoke(dataDelegate)

                            'End If
                            'Begin waiting to receive on the socket
                            'handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveCallback), state)
                        End If
                    End If
                End If
            Else
                handler = clients(0).workSocket
                If handler.Available > 0 Then
                    cpBytesRec = clients(0).workSocket.ReceiveFrom(bytes, 0, bytes.Length, SocketFlags.None, clients(0).SenderRemote)
                End If
                content = Encoding.ASCII.GetString(bytes, 0, cpBytesRec)
                sBuffer = sBuffer & content

            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub 'ReceiveCallback

    Public Shared Sub Send(ByVal handler As Socket, ByVal data As String)
        ' Convert the string data to byte data using ASCII encoding.
        Dim byteData As Byte() = Encoding.ASCII.GetBytes(Data)

        ' Begin sending the data to the remote device.
        handler.BeginSend(byteData, 0, byteData.Length, 0, New AsyncCallback(AddressOf SendCallback), handler)
    End Sub 'Send

    Private Shared Sub SendCallback(ByVal ar As IAsyncResult)
        ' Retrieve the socket from the state object.
        Dim handler As Socket = CType(ar.AsyncState, Socket)

        ' Complete sending the data to the remote device.
        Dim bytesSent As Integer = handler.EndSend(ar)
        Console.WriteLine("Sent {0} bytes to client.", bytesSent)

        'WriteToLog("Data Sent Bytes: " & bytesSent)

        'handler.Shutdown(SocketShutdown.Both)
        'handler.Close()

        'I HAVE NO IDEA WHERE TO PUT THIS allDone.Set()
        'Signal the main thread to continue.
        'allDone.Set()
    End Sub 'SendCallback

    Public Sub PingAllClients()
        'Not sure if the mutex is necessary
        mut.WaitOne()
        For i As UInteger = 0 To clients.Count - 1
            Send(clients(i).workSocket, "ping")
        Next
        mut.ReleaseMutex()
    End Sub 'PingAllClients
    Public Sub CloseAll()
        Dim nCount As Integer
        'If nSocketType = ProtocolType.Tcp Then
        For nCount = 0 To clients.Count - 1
            Try
                clients(nCount).SenderRemote = Nothing
                If clients(nCount).workSocket.Connected = True Then
                    clients(nCount).workSocket.Disconnect(True)
                End If
                clients(nCount).workSocket.Close()
                clients(nCount).workSocket = Nothing
            Catch
            End Try
        Next
        'End If
        clients = New List(Of StateObject)
    End Sub
End Class 'AsynchronousSocketListener

