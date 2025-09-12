Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices

Public Class BonQR


    Public Shared Function GenerateQRDocument(text As String) As Byte()
        Using memoryStream As New MemoryStream()
            Using binaryWriter As New BinaryWriter(memoryStream)
                binaryWriter.Write(ChrW(&H1B)) ' ESC
                binaryWriter.Write("@"c)
                RenderQR(text, binaryWriter)
                binaryWriter.Flush()
                Return memoryStream.ToArray()
            End Using
        End Using

    End Function

    Public Shared Function GetQRBitmapData(text As String) As BitmapData
        Dim qrImage As Image = GenerateQRImage(text, 8, 0)
        Dim qrBitmap As Bitmap = ConvertToBlackWhiteBitmap(qrImage)

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


    Public Shared Sub RenderQR(text As String, bw As BinaryWriter)
        Dim bitmapData As BitmapData = GetQRBitmapData(text)

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
        qrCodeEncoder.QRCodeErrorCorrect = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.L
        qrCodeEncoder.QRCodeScale = scale
        qrCodeEncoder.QRCodeVersion = version
        Dim image As System.Drawing.Image = qrCodeEncoder.Encode(data)
        Return image
    End Function



    Public Shared Function ConvertToBlackWhiteBitmap(srcImage As Image) As Bitmap
        ' Konversi ke grayscale 24bpp
        Dim grayBmp As New Bitmap(srcImage.Width, srcImage.Height, PixelFormat.Format24bppRgb)
        Using g As Graphics = Graphics.FromImage(grayBmp)
            Dim colorMatrix As New Imaging.ColorMatrix(
            New Single()() {
                New Single() {0.299, 0.299, 0.299, 0, 0},
                New Single() {0.587, 0.587, 0.587, 0, 0},
                New Single() {0.114, 0.114, 0.114, 0, 0},
                New Single() {0, 0, 0, 1, 0},
                New Single() {0, 0, 0, 0, 1}
            })
            Dim ia As New Imaging.ImageAttributes()
            ia.SetColorMatrix(colorMatrix)
            g.DrawImage(srcImage, New Rectangle(0, 0, srcImage.Width, srcImage.Height),
                    0, 0, srcImage.Width, srcImage.Height, GraphicsUnit.Pixel, ia)
        End Using

        ' Konversi ke 1bpp dengan LockBits
        Dim width As Integer = grayBmp.Width
        Dim height As Integer = grayBmp.Height
        Dim bwBitmap As New Bitmap(width, height, PixelFormat.Format1bppIndexed)
        Dim rect As New Rectangle(0, 0, width, height)
        Dim grayData As System.Drawing.Imaging.BitmapData = grayBmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb)
        Dim bwData As System.Drawing.Imaging.BitmapData = bwBitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed)

        Try
            Dim threshold As Integer = 128
            Dim grayStride As Integer = grayData.Stride
            Dim bwStride As Integer = bwData.Stride

            For y As Integer = 0 To height - 1
                Dim grayPtr As IntPtr = IntPtr.Add(grayData.Scan0, y * grayStride)
                Dim bwPtr As IntPtr = IntPtr.Add(bwData.Scan0, y * bwStride)
                Dim bwByte As Byte = 0
                Dim bitPos As Integer = 7

                For x As Integer = 0 To width - 1
                    Dim b As Byte = Marshal.ReadByte(grayPtr, x * 3)
                    Dim g As Byte = Marshal.ReadByte(grayPtr, x * 3 + 1)
                    Dim r As Byte = Marshal.ReadByte(grayPtr, x * 3 + 2)
                    Dim gray As Integer = CInt(0.299 * r + 0.587 * g + 0.114 * b)
                    If gray < threshold Then
                        bwByte = bwByte Or CByte(1 << bitPos)
                    End If
                    bitPos -= 1
                    If bitPos < 0 Or x = width - 1 Then
                        Marshal.WriteByte(bwPtr, x \ 8, bwByte)
                        bwByte = 0
                        bitPos = 7
                    End If
                Next
            Next
        Finally
            grayBmp.UnlockBits(grayData)
            bwBitmap.UnlockBits(bwData)
        End Try

        Return bwBitmap
    End Function


End Class
