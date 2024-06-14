Public Class uiTrnPosGenPassword

    Private Sub uiTrnPosGenPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.password.Text = ""
    End Sub

    Private Sub btnPasswordGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasswordGenerate.Click
        If Me.obj_region_id.Text.Length <> 5 Then
            MessageBox.Show("Kode Region belum diisi dengan benar", "Password Generator", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Me.obj_branch_id.Text.Length <> 7 Then
            MessageBox.Show("Kode Branch belum diisi dengan benar", "Password Generator", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim n As Decimal
        Try
            n = CDec(Me.obj_region_id.Text)
        Catch ex As Exception
            MessageBox.Show("Kode Region belum diisi dengan benar", "Password Generator", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try

        Try
            n = CDec(Me.obj_branch_id.Text)
        Catch ex As Exception
            MessageBox.Show("Kode Branch belum diisi dengan benar", "Password Generator", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try


        Me.password.Text = TransStore.Utilities.CreatePassword(Me.obj_region_id.Text, Me.obj_branch_id.Text, Now())
        Me.password.AutoSize = True
        Me.password.Refresh()

    End Sub
End Class
