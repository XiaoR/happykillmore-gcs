Imports System.Runtime.InteropServices
Module modLoadFiles
    Public Sub LoadContent(ByVal inputBroswer As WebBrowser, ByVal Value As String)
        'Set the page to blank
        'inputBroswer.Navigate("javascript:document.write(" & Value & ")")
        inputBroswer.DocumentText = Value
        'set an interface reference of IHTMLDocument2 to the document
        'Dim iDocument As mshtml.IHTMLDocument2 = CType(inputBroswer.Document, mshtml.IHTMLDocument2)
        'Simply write to it
        'inputBroswer.Document.Write(Value)
    End Sub
End Module
