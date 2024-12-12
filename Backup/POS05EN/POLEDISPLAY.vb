Public Class POLEDISPLAY

    Public Shared Function Write(ByVal comport As String, ByVal line1 As String, ByVal line2 As String) As Boolean



        Try
            Using com As IO.Ports.SerialPort = My.Computer.Ports.OpenSerialPort(comport)

                line1 = line1.PadRight(20, " ")
                line2 = line2.PadRight(20, " ")

                com.BaudRate = 9600
                com.Parity = IO.Ports.Parity.None
                com.ReadTimeout = 10
                com.DataBits = 8
                com.StopBits = IO.Ports.StopBits.One
                com.Write(Chr(31))
                com.Write(Chr(12))
                com.Write(Chr(11))
                com.WriteLine(Mid(line1, 1, 20))
                com.Write(Chr(13))
                com.Write(Chr(21))
                com.Write(Mid(line2, 1, 20))
                com.Close()
            End Using
            Return True
        Catch ex As Exception
            Throw New Exception("Error using port " & comport & vbCrLf & ex.Message)
        End Try
    End Function

End Class
