Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices

Public Class BonQR


    Public Shared Function GenerateQRDocument(text As String) As Byte()
        Dim bitmapData As BitmapData = GetQRBitmapData(text)

        Using memoryStream As New MemoryStream()
            Using binaryWriter As New BinaryWriter(memoryStream)
                binaryWriter.Write(ChrW(&H1B)) ' ESC
                binaryWriter.Write("@"c)
                RenderQR(bitmapData, binaryWriter)
                binaryWriter.Flush()
                Return memoryStream.ToArray()
            End Using
        End Using
    End Function


    Public Shared Function ConvertToGrayscaleBitmap(sourceImage As Image) As Bitmap
        Dim bwBitmap As New Bitmap(sourceImage.Width, sourceImage.Height)

        Using g As Graphics = Graphics.FromImage(bwBitmap)
            Dim cm As New Imaging.ColorMatrix(New Single()() {
            New Single() {0.3, 0.3, 0.3, 0, 0},
            New Single() {0.59, 0.59, 0.59, 0, 0},
            New Single() {0.11, 0.11, 0.11, 0, 0},
            New Single() {0, 0, 0, 1, 0},
            New Single() {0, 0, 0, 0, 1}
        })

            Dim ia As New Imaging.ImageAttributes()
            ia.SetColorMatrix(cm)

            g.DrawImage(
                sourceImage,
                New Rectangle(0, 0, bwBitmap.Width, bwBitmap.Height),
                0, 0, sourceImage.Width, sourceImage.Height,
                GraphicsUnit.Pixel,
                ia
            )
        End Using

        Return bwBitmap
    End Function



    Public Shared Function GenerateQRDocument(qrImage As Image) As Byte()
        Dim bwBitmap As Bitmap = ConvertToGrayscaleBitmap(qrImage)
        Dim bitmapData As BitmapData = GetQRBitmapData(bwBitmap)

        Using memoryStream As New MemoryStream()
            Using binaryWriter As New BinaryWriter(memoryStream)
                binaryWriter.Write(ChrW(&H1B)) ' ESC
                binaryWriter.Write("@"c)
                RenderQR(bitmapData, binaryWriter)
                binaryWriter.Flush()
                Return memoryStream.ToArray()
            End Using
        End Using
    End Function

    Public Shared Function GetQRBitmapData(qrBitmap As Bitmap) As BitmapData

        Dim lebar As Integer = 500 'dot
        Dim tinggi As Integer = qrBitmap.Height
        Dim centeredBitmap As Bitmap = CenterQRInCanvas(qrBitmap, lebar, tinggi)


        Using bitmap As Bitmap = centeredBitmap
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


    Public Shared Function GetQRBitmapData(text As String) As BitmapData
        Dim qrImage As Image = GenerateQRImage(text, 4, 0)
        Return GetQRBitmapData(qrImage)
    End Function


    Public Shared Function CenterQRInCanvas(qrBitmap As Bitmap, canvasWidth As Integer, canvasHeight As Integer) As Bitmap
        Dim canvas As New Bitmap(canvasWidth, canvasHeight)
        Using g As Graphics = Graphics.FromImage(canvas)
            g.Clear(Color.White) ' Latar belakang putih

            ' Hitung posisi tengah
            Dim x As Integer = (canvasWidth - qrBitmap.Width) \ 2
            Dim y As Integer = (canvasHeight - qrBitmap.Height) \ 2

            ' Gambar QR ke posisi tengah
            g.DrawImage(qrBitmap, x, y, qrBitmap.Width, qrBitmap.Height)
        End Using
        Return canvas
    End Function


    Public Shared Sub RenderQR(bitmapData As BitmapData, bw As BinaryWriter)
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



    Public Shared Function GenerateQRImage(data As String, scale As Integer, version As Integer) As Image
        Dim qrCodeEncoder As ThoughtWorks.QRCode.Codec.QRCodeEncoder = New ThoughtWorks.QRCode.Codec.QRCodeEncoder()
        Dim utf8Encoding As New System.Text.UTF8Encoding(True)
        Dim encodedString() As Byte
        encodedString = utf8Encoding.GetBytes(data)
        qrCodeEncoder.QRCodeEncodeMode = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ENCODE_MODE.BYTE
        qrCodeEncoder.QRCodeErrorCorrect = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.H
        qrCodeEncoder.QRCodeScale = scale
        qrCodeEncoder.QRCodeVersion = version
        Dim image As System.Drawing.Image = qrCodeEncoder.Encode(data)
        Return image
    End Function





End Class
