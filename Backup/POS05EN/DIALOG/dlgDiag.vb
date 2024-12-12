Public Class dlgDiag


    Private Sub btn_QRGenerateTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_QRGenerateTest.Click
        Dim dlgQRTest As dlgQRTest = New dlgQRTest
        dlgQRTest.Text = "Test Generate QR"
        dlgQRTest.ShowInTaskbar = False
        dlgQRTest.WindowState = FormWindowState.Normal
        dlgQRTest.ShowDialog(Me)
    End Sub

    Private Sub btn_Test2ndMonitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Test2ndMonitor.Click
        ' Cek apakah mnitor ke dua ada
        Dim numofmonitor As Integer = Screen.AllScreens.Length
        If numofmonitor > 1 Then
            Dim frm As Form = New Form()
            frm.Text = "wndow do from kedua"
            frm.ShowInTaskbar = False
            frm.Show()
            frm.Location = Screen.AllScreens(UBound(Screen.AllScreens)).Bounds.Location
            frm.WindowState = FormWindowState.Maximized
        Else
            MessageBox.Show("Monitor hanya satu", "Monitor", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ReadPromo.Click
        ' https://www.codeproject.com/Articles/18478/Base64-Decoder-and-Encoder
    
        'Dim strXML As String

        'strXML = "<DECODER xmlns:dt=" & Chr(34) & _
        '        "urn:schemas-microsoft-com:datatypes" & Chr(34) & " " & _
        '        "dt:dt=" & Chr(34) & "bin.base64" & Chr(34) & ">" & _
        '        iStrbase64 & "</DECODER>"
        'With New MSXML2.DOMDocument30
        '    .loadXML(strXML)
        '    Decode = .selectSingleNode("DECODER").nodeTypedValue
        'End With
    End Sub
End Class