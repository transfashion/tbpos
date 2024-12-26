Public Class dlgDiag

    Private WithEvents POS As TransStore.POS


    Public Sub SetPOS(pos As TransStore.POS)
        Me.POS = pos
    End Sub


    Private Sub btn_QRGenerateTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_QRGenerateTest.Click
        Dim dlgQRTest As dlgQRTest = New dlgQRTest
        dlgQRTest.Text = "Test Generate QR"
        dlgQRTest.ShowInTaskbar = False
        dlgQRTest.WindowState = FormWindowState.Normal
        dlgQRTest.SetPOS(Me.POS)
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


End Class