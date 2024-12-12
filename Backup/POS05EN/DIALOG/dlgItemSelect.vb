Public Class dlgItemSelect

    Dim myRetObj As Object
    Dim tblItem As DataTable
    Dim title As String
    Dim id As String

#Region " Constructor "

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, ByVal args As Object) As Object
        Try
            title = args(0)
            id = args(1)
            tblItem = args(2)

            uiTrnPosEN.FormatDgvPOSItemSelect(Me.DgvItem)
            Me.DgvItem.DataSource = tblItem

        Catch ex As Exception
            Me.Close()
            Throw ex
        End Try

        MyBase.ShowDialog(owner)
        Return myRetObj
    End Function

#End Region


    Private Sub dlgItemSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SuspendLayout()

        Dim obj As Control
        For Each obj In Me.Controls
            If obj.Name <> Me.PnlFormMain.Name Then
                Me.Controls.Remove(obj)
            End If
        Next

        Me.DgvItem.Anchor = AnchorStyles.Top + AnchorStyles.Right + AnchorStyles.Left + AnchorStyles.Bottom

        Me.PnlFormMain.Dock = DockStyle.Fill
        Me.PnlFormMain.BackColor = Color.DarkGray
        'Me.PnlFormMain.BackgroundImageLayout = ImageLayout.Stretch
        'Me.PnlFormMain.BackgroundImage = My.Resources.bgf

        Me.Refresh()
        Me.ResumeLayout()


        uiTrnPosEN.BeepPopUp()

    End Sub


    Private Sub DgvItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgvItem.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                uiTrnPosEN.BeepPopDown()
                Me.Close()
            Case Keys.Enter
                dlgOK()
        End Select
    End Sub


    Private Sub dlgOK()
        Dim objItem As TransStore.POS.PosItemData = New TransStore.POS.PosItemData
        objItem.iteminventory_id = Me.DgvItem.CurrentRow.Cells("iteminventory_id").Value
        objItem.iteminventory_idsc = Me.DgvItem.CurrentRow.Cells("iteminventory_idsc").Value
        objItem.iteminventory_barcode = Me.DgvItem.CurrentRow.Cells("iteminventory_barcode").Value
        objItem.iteminventory_sizecode = Me.DgvItem.CurrentRow.Cells("iteminventory_sizecode").Value
        objItem.iteminventory_name = Me.DgvItem.CurrentRow.Cells("iteminventory_name").Value
        objItem.iteminventory_article = Me.DgvItem.CurrentRow.Cells("iteminventory_article").Value
        objItem.iteminventory_material = Me.DgvItem.CurrentRow.Cells("iteminventory_material").Value
        objItem.iteminventory_color = Me.DgvItem.CurrentRow.Cells("iteminventory_color").Value
        objItem.iteminventory_size = Me.DgvItem.CurrentRow.Cells("iteminventory_size").Value
        objItem.iteminventory_sellpricedefault = CDec(Me.DgvItem.CurrentRow.Cells("iteminventory_sellpricedefault").Value)
        objItem.iteminventory_discountdefault = CDec(Me.DgvItem.CurrentRow.Cells("iteminventory_discountdefault").Value)
        objItem.iteminventorygroup_id = Me.DgvItem.CurrentRow.Cells("iteminventorygroup_id").Value
        objItem.iteminventorysubgroup_id = Me.DgvItem.CurrentRow.Cells("iteminventorysubgroup_id").Value
        objItem.region_id = Me.DgvItem.CurrentRow.Cells("region_id").Value
        objItem.region_nameshort = Me.DgvItem.CurrentRow.Cells("region_nameshort").Value
        objItem.colname = Me.DgvItem.CurrentRow.Cells("colname").Value
        objItem.sizetag = Me.DgvItem.CurrentRow.Cells("sizetag").Value
        objItem.pricingrule = Me.DgvItem.CurrentRow.Cells("pricingrule").Value
        objItem.proc = Me.DgvItem.CurrentRow.Cells("proc").Value
        objItem.issp = Me.DgvItem.CurrentRow.Cells("pricing_issp").Value

        Me.myRetObj = New Object() {objItem}
        Me.Close()
    End Sub


    Private Sub DgvItem_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvItem.CellFormatting
        Dim colname As String = Me.DgvItem.Columns(e.ColumnIndex).Name


        ' Me.DgvPOSItem.Rows(e.RowIndex).Height = 48
        Select Case colname
            Case "displayed_id"
                e.Value = Me.DgvItem.Rows(e.RowIndex).Cells("iteminventory_id").Value
            Case "displayed_descr"
                Dim name, art, mat, col, size, region As String
                Dim price, disc As Decimal
                Dim pricerule As String
                Dim issp As Boolean

                name = Me.DgvItem.Rows(e.RowIndex).Cells("iteminventory_name").Value
                art = Me.DgvItem.Rows(e.RowIndex).Cells("iteminventory_article").Value
                mat = Me.DgvItem.Rows(e.RowIndex).Cells("iteminventory_material").Value
                col = Me.DgvItem.Rows(e.RowIndex).Cells("iteminventory_color").Value
                size = Me.DgvItem.Rows(e.RowIndex).Cells("iteminventory_size").Value
                price = CDec(Me.DgvItem.Rows(e.RowIndex).Cells("iteminventory_sellpricedefault").Value)
                disc = CDec(Me.DgvItem.Rows(e.RowIndex).Cells("iteminventory_discountdefault").Value)
                region = Me.DgvItem.Rows(e.RowIndex).Cells("region_nameshort").Value
                pricerule = Me.DgvItem.Rows(e.RowIndex).Cells("pricingrule").Value
                issp = Me.DgvItem.Rows(e.RowIndex).Cells("pricing_issp").Value


                e.Value = name & ", " & region & vbCrLf & _
                          art & "   " & mat & "   " & col & "   " & size & vbCrLf

                If (issp = True) Then
                    e.Value &= "-SP- "
                End If

                If (pricerule <> "01") Then
                    e.Value &= "PROMO "
                End If

        End Select

    End Sub


    Private Sub DgvItem_AdjustWidht(ByVal constant As Integer)
        If Me.DgvItem.Columns.Contains("displayed_descr") Then
            Dim i As Integer
            Dim colname As String = ""
            Dim dpwidth As Integer = 0
            For i = 0 To Me.DgvItem.Columns.Count - 1
                colname = Me.DgvItem.Columns(i).Name
                If Mid(colname, 1, 10) = "displayed_" Then
                    Me.DgvItem.Columns(colname).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    If colname <> "displayed_descr" Then
                        dpwidth += Me.DgvItem.Columns(colname).Width
                    End If
                Else
                    Me.DgvItem.Columns(colname).Visible = False
                End If
            Next

            If Me.DgvItem.Width > dpwidth + constant + 150 Then
                Me.DgvItem.Columns("displayed_descr").Width = Me.DgvItem.Width - (dpwidth + constant)
            End If
        End If

    End Sub

    Private Sub DgvItem_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvItem.Resize
        Me.DgvItem_AdjustWidht(35)
    End Sub


End Class
