Public Class dlgParameters

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub btn_Diag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Diag.Click
        Dim d As dlgDiag
        d = New dlgDiag()

        d.ShowInTaskbar = False
        d.StartPosition = FormStartPosition.CenterScreen
        d.WindowState = FormWindowState.Maximized
        d.ShowDialog(Me)


    End Sub
End Class