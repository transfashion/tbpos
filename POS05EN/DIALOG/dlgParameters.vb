Public Class dlgParameters

    Private WithEvents POS As TransStore.POS


    Public Sub SetPOS(pos As TransStore.POS)
        Me.POS = pos
    End Sub





    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub btn_Diag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Diag.Click
        Dim d As dlgDiag
        d = New dlgDiag()


        d.ShowInTaskbar = False
        d.StartPosition = FormStartPosition.CenterScreen
        d.WindowState = FormWindowState.Maximized
        d.SetPOS(Me.POS)
        d.ShowDialog(Me)


    End Sub
End Class