Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.InteropServices

Public Class PrintImage


    Public Shared Function GetDocument(bmpFileName As String) As Byte()
        Using memoryStream As New MemoryStream()
            Using binaryWriter As New BinaryWriter(memoryStream)
                binaryWriter.Write(ChrW(&H1B)) ' ESC
                binaryWriter.Write("@"c)
                RenderLogo(bmpFileName, binaryWriter)
                binaryWriter.Flush()
                Return memoryStream.ToArray()
            End Using
        End Using
    End Function


    Public Shared Sub RenderLogo(bmpFileName As String, bw As BinaryWriter)
        Dim bitmapData As BitmapData = GetBitmapData(bmpFileName)
        Dim dots As BitArray = bitmapData.Dots
        Dim bytes As Byte() = BitConverter.GetBytes(bitmapData.Width)

        bw.Write(ChrW(&H1B)) ' ESC
        bw.Write("3"c)
        bw.Write(CByte(24))

        Dim num As Integer = 0
        While num < bitmapData.Height
            bw.Write(ChrW(&H1B)) ' ESC
            bw.Write("*"c)
            bw.Write(CByte(33))
            bw.Write(bytes(0))
            bw.Write(bytes(1))

            For i As Integer = 0 To bitmapData.Width - 1
                For j As Integer = 0 To 2
                    Dim b As Byte = 0
                    For k As Integer = 0 To 7
                        Dim num2 As Integer = (num \ 8 + j) * 8 + k
                        Dim num3 As Integer = num2 * bitmapData.Width + i
                        Dim flag As Boolean = False

                        If num3 < dots.Length Then
                            flag = dots(num3)
                        End If

                        b = b Or CByte((If(flag, 1, 0)) << (7 - k))
                    Next
                    bw.Write(b)
                Next
            Next

            num += 24
            bw.Write(ControlChars.Lf)
        End While

        bw.Write(ChrW(&H1B)) ' ESC
        bw.Write("3"c)
        bw.Write(CByte(30))
    End Sub



    Public Shared Function GetBitmapData(bmpFileName As String) As BitmapData
        Using bitmap As Bitmap = CType(Image.FromFile(bmpFileName), Bitmap)
            Dim threshold As Integer = 127
            Dim index As Integer = 0
            Dim length As Integer = bitmap.Width * bitmap.Height
            Dim bitArray As New BitArray(length)

            For i As Integer = 0 To bitmap.Height - 1
                For j As Integer = 0 To bitmap.Width - 1
                    Dim pixel As Color = bitmap.GetPixel(j, i)
                    Dim brightness As Integer = CInt(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11)
                    bitArray(index) = brightness < threshold
                    index += 1
                Next
            Next

            Dim bitmapData As New BitmapData()
            bitmapData.Dots = bitArray
            bitmapData.Height = bitmap.Height
            bitmapData.Width = bitmap.Width
            Return bitmapData
        End Using
    End Function


End Class
