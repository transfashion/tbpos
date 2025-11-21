Public Class dlgDonasi


    Private tempLastValue As String = ""


    Public Property NilaiDonasi As Decimal
        Get
            Dim nilai As Decimal
            Decimal.TryParse(objDonasi.Text, nilai)
            Return nilai
        End Get
        Set(value As Decimal)
            objDonasi.Text = value.ToString("#,###")
        End Set
    End Property


    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        DoDonasi()
    End Sub

    Private Sub objDonasi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles objDonasi.KeyPress
        ' Jika tombol enter ditekan, jalankan tombol OK
        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.DoDonasi()
        End If
    End Sub



    Private Sub DoDonasi()
        Dim MIN_DONASI As Decimal = 5000D


        ' conver nilai objDonasi ke decimal
        Dim nilaiDonasi As Decimal
        Decimal.TryParse(objDonasi.Text, nilaiDonasi)


        ' cek nilai donasi dari objDonasi, minimal harus 5000
        If nilaiDonasi < MIN_DONASI Then
            MsgBox(String.Format("Nilai donasi minimal adalah {0:#,##0}", MIN_DONASI), MsgBoxStyle.Exclamation, "Donasi")
            objDonasi.Focus()
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub



    Private Sub dlg_MoneyTyped(ByVal sender As Object, ByRef temp As String)
        Dim obj As TextBox = sender
        Dim selstart As Integer = obj.SelectionStart

        Try
            Dim strValue = obj.Text
            If (obj.TextLength = 0) Then
                temp = 0
                obj.Text = temp
                obj.Select(Len(obj.Text), -Len(obj.Text))
            Else
                ' remove space and set allowed formatting
                obj.Text = CDec(obj.Text).ToString("#,##0")
                obj.Select(Len(obj.Text), 1)
            End If

        Catch ex As Exception
            ' skip it for formatting 
            MessageBox.Show(ex.Message, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub objDonasi_TextChanged(sender As Object, e As EventArgs) Handles objDonasi.TextChanged
        Me.dlg_MoneyTyped(sender, Me.tempLastValue)
    End Sub
End Class