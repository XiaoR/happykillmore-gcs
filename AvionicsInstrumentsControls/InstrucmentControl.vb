'***************************************************************************

' Project  : AvionicsInstrumentControlDemo                                  
' File     : InstrumentControl.cs                                           
' Version  : 1                                                              
' Language : C#                                                             
' Summary  : Generic class for the instrument control design                
' Creation : 15/06/2008                                                     
' Autor    : Guillaume CHOUTEAU                                             
' History  :                                                                

'***************************************************************************


Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing
Imports System.Text
Imports System.Data


Namespace AvionicsInstrumentControlDemo
    Class InstrumentControl
        Inherits System.Windows.Forms.Control
#Region "Generic methodes"

        ''' Rotate an image on a point with a specified angle
        ''' The paint area event where the image will be displayed
        ''' The image to display
        ''' The angle of rotation in radian
        ''' The location of the left upper corner of the image to display in the paint area in nominal situation
        ''' The location of the rotation point in the paint area
        ''' Multiplication factor on the display image
        Protected Sub RotateImage(ByVal pe As PaintEventArgs, ByVal img As Image, ByVal alpha As [Double], ByVal ptImg As Point, ByVal ptRot As Point, ByVal scaleFactor As Single)
            Dim beta As Double = 0
            ' Angle between the Horizontal line and the line (Left upper corner - Rotation point)
            Dim d As Double = 0
            ' Distance between Left upper corner and Rotation point)		
            Dim deltaX As Single = 0
            ' X componant of the corrected translation
            Dim deltaY As Single = 0
            ' Y componant of the corrected translation
            ' Compute the correction translation coeff
            If ptImg <> ptRot Then
                '
                If ptRot.X <> 0 Then
                    beta = Math.Atan(CDbl(ptRot.Y) / CDbl(ptRot.X))
                End If

                d = Math.Sqrt((ptRot.X * ptRot.X) + (ptRot.Y * ptRot.Y))

                ' Computed offset
                deltaX = CSng(d * (Math.Cos(alpha - beta) - Math.Cos(alpha) * Math.Cos(alpha + beta) - Math.Sin(alpha) * Math.Sin(alpha + beta)))
                deltaY = CSng(d * (Math.Sin(beta - alpha) + Math.Sin(alpha) * Math.Cos(alpha + beta) - Math.Cos(alpha) * Math.Sin(alpha + beta)))
            End If

            ' Rotate image support
            pe.Graphics.RotateTransform(CSng(alpha * 180 / Math.PI))

            ' Dispay image
            pe.Graphics.DrawImage(img, (ptImg.X + deltaX) * scaleFactor, (ptImg.Y + deltaY) * scaleFactor, img.Width * scaleFactor, img.Height * scaleFactor)

            ' Put image support as found
            pe.Graphics.RotateTransform(CSng(-alpha * 180 / Math.PI))

        End Sub


        ''' Translate an image on line with a specified distance and a spcified angle
        ''' The paint area event where the image will be displayed
        ''' The image to display
        ''' The translation distance in pixel
        ''' The angle of translation direction in radian
        ''' The location of the left upper corner of the image to display in the paint area in nominal situation
        ''' Multiplication factor on the display image
        Protected Sub TranslateImage(ByVal pe As PaintEventArgs, ByVal img As Image, ByVal deltaPx As Integer, ByVal alpha As Single, ByVal ptImg As Point, ByVal scaleFactor As Single)
            ' Computed offset
            Dim deltaX As Single = CSng(deltaPx * (Math.Sin(alpha)))
            Dim deltaY As Single = CSng(-deltaPx * (Math.Cos(alpha)))

            ' Dispay image
            pe.Graphics.DrawImage(img, (ptImg.X + deltaX) * scaleFactor, (ptImg.Y + deltaY) * scaleFactor, img.Width * scaleFactor, img.Height * scaleFactor)
        End Sub


        ''' Rotate an image an apply a translation on the rotated image and the display it
        ''' The paint area event where the image will be displayed
        ''' The image to display
        ''' The angle of rotation in radian
        ''' The angle of translation direction in radian, expressed in the rotated image coordonate system
        ''' The location of the left upper corner of the image to display in the paint area in nominal situation
        ''' The location of the rotation point in the paint area
        ''' The translation distance in pixel
        ''' The location of the rotation point in the paint area
        ''' Multiplication factor on the display image
        Protected Sub RotateAndTranslate(ByVal pe As PaintEventArgs, ByVal img As Image, ByVal alphaRot As [Double], ByVal alphaTrs As [Double], ByVal ptImg As Point, ByVal deltaPx As Integer, _
        ByVal ptRot As Point, ByVal scaleFactor As Single)
            Dim beta As Double = 0
            Dim d As Double = 0
            Dim deltaXRot As Single = 0
            Dim deltaYRot As Single = 0
            Dim deltaXTrs As Single = 0
            Dim deltaYTrs As Single = 0

            ' Rotation

            Try
                If ptImg <> ptRot Then
                    ' Internals coeffs
                    If ptRot.X <> 0 Then
                        beta = Math.Atan(CDbl(ptRot.Y) / CDbl(ptRot.X))
                    End If

                    d = Math.Sqrt((ptRot.X * ptRot.X) + (ptRot.Y * ptRot.Y))

                    ' Computed offset
                    deltaXRot = CSng(d * (Math.Cos(alphaRot - beta) - Math.Cos(alphaRot) * Math.Cos(alphaRot + beta) - Math.Sin(alphaRot) * Math.Sin(alphaRot + beta)))
                    deltaYRot = CSng(d * (Math.Sin(beta - alphaRot) + Math.Sin(alphaRot) * Math.Cos(alphaRot + beta) - Math.Cos(alphaRot) * Math.Sin(alphaRot + beta)))
                End If

                ' Translation

                ' Computed offset
                deltaXTrs = CSng(deltaPx * (Math.Sin(alphaTrs)))
                deltaYTrs = CSng(-deltaPx * (-Math.Cos(alphaTrs)))

                ' Rotate image support
                pe.Graphics.RotateTransform(CSng(alphaRot * 180 / Math.PI))

                ' Dispay image
                pe.Graphics.DrawImage(img, (ptImg.X + deltaXRot + deltaXTrs) * scaleFactor, (ptImg.Y + deltaYRot + deltaYTrs) * scaleFactor, img.Width * scaleFactor, img.Height * scaleFactor)

                ' Put image support as found
                pe.Graphics.RotateTransform(CSng(-alphaRot * 180 / Math.PI))
            Catch
            End Try
        End Sub


        ''' Display a Scroll counter image like on gas  pumps 
        ''' The paint area event where the image will be displayed
        ''' The band counter image to display with digts : 0|1|2|3|4|5|6|7|8|9|0
        ''' The number of digits displayed by the counter
        ''' The value to dispay on the counter
        ''' The location of the left upper corner of the image to display in the paint area in nominal situation
        ''' Multiplication factor on the display image
        Protected Sub ScrollCounter(ByVal pe As PaintEventArgs, ByVal imgBand As Image, ByVal nbOfDigits As Integer, ByVal counterValue As Single, ByVal ptImg As Point, ByVal scaleFactor As Single)
            Dim indexDigit As Integer = 0
            Dim digitBoxHeight As Integer = CInt(imgBand.Height \ 11)
            Dim digitBoxWidth As Integer = imgBand.Width

            For indexDigit = 0 To nbOfDigits - 1
                Dim currentDigit As Single
                Dim prevDigit As Single
                Dim xOffset As Integer
                Dim yOffset As Integer
                Dim fader As Double

                'currentDigit = CInt(Math.Truncate((counterValue / Math.Pow(10, indexDigit)) Mod 10))
                currentDigit = (Math.Truncate((counterValue / Math.Pow(10, indexDigit)) Mod 10))

                'If indexDigit = 0 Then
                '    prevDigit = 0
                'Else
                '    prevDigit = CInt(Math.Truncate((counterValue / Math.Pow(10, indexDigit - 1)) Mod 10))
                'End If

                ' xOffset Computing
                xOffset = CInt(digitBoxWidth * (nbOfDigits - indexDigit - 1))

                ' yOffset Computing	
                'If prevDigit = 9 Then
                '    fader = 0 '0.33
                '    yOffset = CInt(Math.Truncate(-((fader + currentDigit) * digitBoxHeight))) - 1
                'Else
                'If indexDigit = 0 Then
                '    yOffset = CInt(-(currentDigit * digitBoxHeight + (counterValue - Math.Truncate(counterValue)) * digitBoxHeight)) - 1
                'Else
                yOffset = CInt(-(currentDigit * digitBoxHeight)) - 1
                'End If
                'End If

                ' Display Image
                pe.Graphics.DrawImage(imgBand, (ptImg.X + xOffset) * scaleFactor, (ptImg.Y + yOffset) * scaleFactor, imgBand.Width * scaleFactor, imgBand.Height * scaleFactor)
            Next
        End Sub

        Protected Sub ShowMeterLevel(ByVal pe As PaintEventArgs, ByVal imgBand As Image, ByVal meterValue As Single, ByVal minValue As Single, ByVal maxValue As Single, ByVal ptImg As Point, ByVal openingHeight As Integer, ByVal scaleFactor As Single)

            Dim yOffset As Integer

            If meterValue < minValue Then
                meterValue = minValue
            End If
            Try
                ' yOffset Computing	
                yOffset = (-(imgBand.Height / 2)) + openingHeight - ((meterValue - minValue) / (maxValue - minValue)) * (openingHeight)
            Catch
                yOffset = 0
            End Try
            'Debug.Print("yOffset=" & yOffset)
            'If yOffset > (-(imgBand.Height / 2)) + openingHeight Then
            '    yOffset = (-(imgBand.Height / 2)) + openingHeight
            'ElseIf yOffset < -imgBand.Height + openingHeight Then
            '    yOffset = -imgBand.Height + openingHeight
            'End If

            ' Display Image
            pe.Graphics.DrawImage(imgBand, (ptImg.X) * scaleFactor, (ptImg.Y + yOffset) * scaleFactor, imgBand.Width * scaleFactor, imgBand.Height * scaleFactor)
        End Sub

        Protected Sub DisplayRoundMark(ByVal pe As PaintEventArgs, ByVal imgMark As Image, ByVal insControlMarksDefinition As InstrumentControlMarksDefinition, ByVal ptImg As Point, ByVal radiusPx As Integer, ByVal displayText As [Boolean], _
        ByVal scaleFactor As Single)
            Dim alphaRot As [Double]
            Dim textBoxLength As Integer
            Dim textPointRadiusPx As Integer
            Dim textBoxHeight As Integer = CInt(Math.Truncate(insControlMarksDefinition.fontSize * 1.1 / scaleFactor))
            Dim textPoint As New Point()
            Dim rotatePoint As New Point()
            Dim markFont As New Font("Arial", insControlMarksDefinition.fontSize)
            Dim markBrush As New SolidBrush(insControlMarksDefinition.fontColor)
            Dim markArray As InstrumentControlMarkPoint() = New InstrumentControlMarkPoint(2 + (insControlMarksDefinition.numberOfDivisions - 1)) {}

            ' Buid the markArray
            markArray(0).value = insControlMarksDefinition.minPhy
            markArray(0).angle = insControlMarksDefinition.minAngle
            markArray(markArray.Length - 1).value = insControlMarksDefinition.maxPhy
            markArray(markArray.Length - 1).angle = insControlMarksDefinition.maxAngle

            For index As Integer = 1 To insControlMarksDefinition.numberOfDivisions
                markArray(index).value = (insControlMarksDefinition.maxPhy - insControlMarksDefinition.minPhy) / (insControlMarksDefinition.numberOfDivisions + 1) * index + insControlMarksDefinition.minPhy
                markArray(index).angle = (insControlMarksDefinition.maxAngle - insControlMarksDefinition.minAngle) / (insControlMarksDefinition.numberOfDivisions + 1) * index + insControlMarksDefinition.minAngle
            Next

            ' Define the rotate point (center of the indicator)
            rotatePoint.X = CInt(Math.Truncate((Me.Width \ 2) / scaleFactor))
            rotatePoint.Y = rotatePoint.X

            ' Display mark array
            For Each markPoint As InstrumentControlMarkPoint In markArray
                ' pre computings
                alphaRot = (Math.PI / 2) - markPoint.angle
                textBoxLength = CInt(Math.Truncate(Convert.ToString(markPoint.value).Length * insControlMarksDefinition.fontSize * 0.8 / scaleFactor))
                textPointRadiusPx = CInt(Math.Truncate(radiusPx - 1.2 * imgMark.Height - 0.5 * textBoxLength))
                textPoint.X = CInt(Math.Truncate((textPointRadiusPx * Math.Cos(markPoint.angle) - 0.5 * textBoxLength + rotatePoint.X) * scaleFactor))
                textPoint.Y = CInt(Math.Truncate((-textPointRadiusPx * Math.Sin(markPoint.angle) - 0.5 * textBoxHeight + rotatePoint.Y) * scaleFactor))

                ' Display mark
                RotateImage(pe, imgMark, alphaRot, ptImg, rotatePoint, scaleFactor)

                ' Display text
                If displayText = True Then
                    pe.Graphics.DrawString(Convert.ToString(markPoint.value), markFont, markBrush, textPoint)
                End If
            Next
        End Sub


        ''' Convert a physical value in an rad angle used by the rotate function
        ''' Physical value to interpol/param>
        ''' Minimum physical value
        ''' Maximum physical value
        ''' The angle related to the minumum value, in deg
        ''' The angle related to the maximum value, in deg
        ''' The angle in radian witch correspond to the physical value
        Protected Function InterpolPhyToAngle(ByVal phyVal As Single, ByVal minPhy As Single, ByVal maxPhy As Single, ByVal minAngle As Single, ByVal maxAngle As Single) As Single
            Dim a As Single
            Dim b As Single
            Dim y As Single
            Dim x As Single

            If phyVal < minPhy Then
                Return CSng(minAngle * Math.PI / 180)
            ElseIf phyVal > maxPhy Then
                Return CSng(maxAngle * Math.PI / 180)
            Else

                x = phyVal
                a = (maxAngle - minAngle) / (maxPhy - minPhy)
                b = CSng(0.5 * (maxAngle + minAngle - a * (maxPhy + minPhy)))
                y = a * x + b

                Return CSng(y * Math.PI / 180)
            End If
        End Function

        Protected Function FromCartRefToImgRef(ByVal cartPoint As Point) As Point
            Dim imgPoint As New Point()
            imgPoint.X = cartPoint.X + (Me.Width \ 2)
            imgPoint.Y = -cartPoint.Y + (Me.Height \ 2)
            Return (imgPoint)
        End Function

        Protected Function FromDegToRad(ByVal degAngle As Double) As Double
            Dim radAngle As Double = degAngle * Math.PI / 180
            Return radAngle
        End Function

        Protected Function GetCurrentEaseInstrument(ByVal startingValue As Single, ByVal targetValue As Single, ByVal moveIndex As Integer, Optional ByVal degreeRollAround As Integer = -1) As Single
            If bSmoothInstruments = True Then
                If degreeRollAround <> -1 Then
                    If Math.Abs(startingValue - targetValue) <= 180 Then
                        GetCurrentEaseInstrument = (targetValue - startingValue) * ((moveIndex + 1) / g_EaseSteps) + startingValue
                        'Debug.Print("Me=" & Me.Name & ",Starting=" & startingValue & ",Target=" & targetValue & ",Normal")
                    Else
                        If targetValue > startingValue Then
                            GetCurrentEaseInstrument = startingValue - Math.Abs(Math.Abs(targetValue - degreeRollAround) + startingValue) * ((moveIndex + 1) / g_EaseSteps)
                            'Debug.Print("Me=" & Me.Name & ",Starting=" & startingValue & ",Target=" & targetValue & ",RotatingLeft")
                        Else
                            GetCurrentEaseInstrument = Math.Abs(Math.Abs(startingValue - degreeRollAround) + targetValue) * ((moveIndex + 1) / g_EaseSteps) + startingValue
                            'Debug.Print("Me=" & Me.Name & ",Starting=" & startingValue & ",Target=" & targetValue & ",RotatingRight")
                        End If
                    End If
                    If GetCurrentEaseInstrument > degreeRollAround Then
                        GetCurrentEaseInstrument = GetCurrentEaseInstrument - degreeRollAround
                    ElseIf GetCurrentEaseInstrument < 0 Then
                        GetCurrentEaseInstrument = degreeRollAround + GetCurrentEaseInstrument
                    End If
                Else
                    GetCurrentEaseInstrument = (targetValue - startingValue) * ((moveIndex + 1) / g_EaseSteps) + startingValue
                End If
            Else
                GetCurrentEaseInstrument = targetValue
            End If
        End Function

#End Region
    End Class

    Structure InstrumentControlMarksDefinition
        Public Sub New(ByVal myMinPhy As Single, ByVal myMinAngle As Single, ByVal myMaxPhy As Single, ByVal myMaxAngle As Single, ByVal myNumberOfDivisions As Integer, ByVal myFontSize As Integer, _
        ByVal myFontColor As Color, ByVal myScaleStyle As InstumentMarkScaleStyle)
            Me.minPhy = myMinPhy
            Me.minAngle = myMinAngle
            Me.maxPhy = myMaxPhy
            Me.maxAngle = myMaxAngle
            Me.numberOfDivisions = myNumberOfDivisions
            Me.fontSize = myFontSize
            Me.fontColor = myFontColor
            Me.scaleStyle = myScaleStyle
        End Sub
        Friend minPhy As Single
        Friend minAngle As Single
        Friend maxPhy As Single
        Friend maxAngle As Single
        Friend numberOfDivisions As Integer
        Friend fontSize As Integer
        Friend fontColor As Color
        Friend scaleStyle As InstumentMarkScaleStyle

    End Structure

    Structure InstrumentControlMarkPoint
        Public Sub New(ByVal myValue As Single, ByVal myAngle As Single)
            Me.value = myValue
            Me.angle = myAngle
        End Sub
        Friend value As Single
        Friend angle As Single
    End Structure

    Enum InstumentMarkScaleStyle
        Linear = 0
        Log = 1
    End Enum
End Namespace