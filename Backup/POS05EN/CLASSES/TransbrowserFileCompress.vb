Imports System.IO
Imports System.IO.Compression



Public Class TransbrowserFileCompress

    Public Enum enuAlgorithm
        Deflate = 0
        GZip = 1
    End Enum

    Public Shared Sub CompressFile(ByVal pFileName As String, ByVal pAlgorithm As enuAlgorithm)
        Dim stmInFile, stmOutFile As FileStream
        Dim strExtension As String
        If pAlgorithm = enuAlgorithm.Deflate Then
            strExtension = ".compress"
        Else
            strExtension = ".gz"
        End If

        stmInFile = New FileStream(pFileName, FileMode.Open)
        stmOutFile = New FileStream(pFileName + strExtension, FileMode.Create)
        Dim stmCompressed As Stream
        If pAlgorithm = enuAlgorithm.Deflate Then
            stmCompressed = New DeflateStream(stmOutFile, CompressionMode.Compress)
        Else
            stmCompressed = New GZipStream(stmOutFile, CompressionMode.Compress)
        End If

        Dim arrBuffer(4095) As Byte
        Do
            Dim intReadBytes As Integer = stmInFile.Read(arrBuffer, 0, arrBuffer.Length)
            If intReadBytes = 0 Then Exit Do
            stmCompressed.Write(arrBuffer, 0, intReadBytes)
        Loop

        stmCompressed.Close()
        stmInFile.Close()
        stmOutFile.Close()
    End Sub


    Public Shared Sub UnCompressFile(ByVal pFileName As String, ByVal pAlgorithm As enuAlgorithm)
        Dim stmInFile, stmOutFile As FileStream
        Dim strExtension As String

        If pAlgorithm = enuAlgorithm.Deflate Then
            strExtension = ".txt"
        Else
            strExtension = ".txt"
        End If
        stmInFile = New FileStream(pFileName, FileMode.Open)
        stmOutFile = New FileStream(pFileName + strExtension, FileMode.Create)
        Dim stmCompressed As Stream
        If pAlgorithm = enuAlgorithm.Deflate Then
            stmCompressed = New DeflateStream(stmInFile, CompressionMode.Decompress)
        Else
            stmCompressed = New GZipStream(stmInFile, CompressionMode.Decompress)
        End If
        Dim arrBuffer(4095) As Byte
        Do
            Dim intReadBytes As Integer = stmCompressed.Read(arrBuffer, 0, arrBuffer.Length)
            If intReadBytes = 0 Then Exit Do
            stmOutFile.Write(arrBuffer, 0, intReadBytes)
        Loop
        stmCompressed.Close()
        stmInFile.Close()
        stmOutFile.Close()
    End Sub


End Class
