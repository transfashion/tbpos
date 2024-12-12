Public Class dlgTrnPosVoid

    Dim myRetObj As Object

    Private oBon As uiTrnPosEN.PosBonData
    Private MODE As String
    Private POS As TransStore.POS
    Private voidby As String

#Region " Constructor "

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, ByVal args As Object) As Object

        Try
            Me.oBon = args(0)
            Me.MODE = args(1)
            Me.POS = args(2)
            Me.voidby = args(3)

            If Me.MODE = "VOID" Then
                Me.Text = "VOID BON - " & Me.oBon.obj.bon_id
                Me.lblVoidBy.Visible = True
                Me.objUsername.Visible = True
                Me.objUsername.Text = Me.voidby
                Me.lblVoidInfo.Text = "Click OK to VOID!! --->"
                Me.lblVoidInfo.ForeColor = Color.Red
            Else
                Me.Text = Me.oBon.obj.bon_id
                Me.lblVoidInfo.Text = "View Only"
                Me.lblVoidInfo.ForeColor = Color.DarkBlue
            End If

        Catch ex As Exception
            Me.Close()
            Throw ex
        End Try

        MyBase.ShowDialog(owner)
        Return myRetObj
    End Function

#End Region

#Region " layout and init UI "

    Public Shared Function FormatDgvPOSItem(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim col As System.Drawing.Color

        'col = Color.FromArgb(209, 181, 225)
        col = Color.Gainsboro

        objDgv.DefaultCellStyle.BackColor = col
        objDgv.DefaultCellStyle.ForeColor = Color.FromArgb(32, 44, 102)
        objDgv.DefaultCellStyle.Font = New Font("Courier New", 9, FontStyle.Regular, GraphicsUnit.Point)
        'objDgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(197, 144, 225)
        objDgv.DefaultCellStyle.SelectionBackColor = Color.DarkGray
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
         { _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "displayed_id", "ID", "", 130, DataGridViewContentAlignment.TopCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "displayed_descr", "Descr", "", 250, DataGridViewContentAlignment.TopLeft, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "displayed_net", "Net", "", 100, DataGridViewContentAlignment.TopRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "displayed_qty", "Qty", "", 60, DataGridViewContentAlignment.TopCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "displayed_subtotal", "Subtotal", "", 100, DataGridViewContentAlignment.TopRight, True, col), _
 _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_item", "ID", "heinvitem_id", 200, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_barcode", "ID", "heinvitem_barcode", 200, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_idsc", "ID", "bondetil_idsc", 200, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_descr", "Descr", "bondetil_descr", 250, DataGridViewContentAlignment.MiddleLeft, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_article", "Art", "bondetil_art", 100, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_material", "Material", "bondetil_mat", 60, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_color", "Color", "bondetil_col", 60, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_size", "Size", "bondetil_size", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_pricegross", "Price", "bondetil_mpricegross", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_discpstd01", "DiscStdP_01", "bondetil_mdiscpstd01", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_discrstd01", "DiscStdR_01", "bondetil_mdiscrstd01", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_pricenettstd01", "NettStd_01", "bondetil_mpricenettstd01", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_discpvou01", "DiscVouP_01", "bondetil_mdiscpvou01", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_discrvou01", "DiscVouR_01", "bondetil_mdiscrvou01", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_pricenettvou01", "NettVou_01", "bondetil_mpricecettvou01", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_vou01id", "Vou01Id", "bondetil_vou01id", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_vou01codenum", "Vou01Codenum", "bondetil_vou01codenum", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_vou01type", "Vou01Codenum", "bondetil_vou01type", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_vou01method", "Vou01Codenum", "bondetil_vou01method", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_vou01discp", "Vou01Codenum", "bondetil_vou01discp", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_pricenet", "Net", "bondetil_mpricenett", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_qty", "Qty", "bondetil_qty", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_subtotal", "Subtotal", "bondetil_msubtotal", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "region_id", "Region", "region_id", 70, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "region_nameshort", "Region", "region_nameshort", 70, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "colname", "colname", "colname", 70, DataGridViewContentAlignment.MiddleCenter, True, col) _
         })


        'Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_discountpercent", "DiscPercent", "bondetil_discountpercent", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
        'Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_discount", "Disc", "bondetil_discount", 60, DataGridViewContentAlignment.MiddleRight, True, col), _


        Dim i As Integer
        Dim colname As String = ""
        Dim dpwidth As Integer = 0
        For i = 0 To objDgv.Columns.Count - 1
            colname = objDgv.Columns(i).Name
            If Mid(colname, 1, 10) = "displayed_" Then
                objDgv.Columns(colname).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                If colname <> "displayed_descr" Then
                    dpwidth += objDgv.Columns(colname).Width
                    objDgv.Columns(colname).Resizable = DataGridViewTriState.False
                Else
                    objDgv.Columns(colname).Resizable = DataGridViewTriState.True
                End If
            Else
                objDgv.Columns(colname).Visible = False
            End If
        Next



        objDgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        objDgv.RowHeadersWidth = 15
        objDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing

        objDgv.RowTemplate.Height = 48

        objDgv.Columns("displayed_descr").HeaderCell.Style.Font = New Font("Courier New", 9, FontStyle.Regular, GraphicsUnit.Point)
        objDgv.Columns("displayed_net").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        objDgv.Columns("displayed_qty").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        objDgv.Columns("displayed_subtotal").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight


        objDgv.Columns("displayed_descr").HeaderText = "ART          MAT    COL    SIZE"


        ' DgvMstIteminventory Behaviours: 
        objDgv.MultiSelect = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AutoGenerateColumns = False

    End Function

    Public Shared Function FormatDgvPOSPayments(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim col As System.Drawing.Color

        objDgv.DefaultCellStyle.BackColor = col
        objDgv.DefaultCellStyle.ForeColor = Color.FromArgb(32, 44, 102)
        objDgv.DefaultCellStyle.Font = New Font("Courier New", 9, FontStyle.Regular, GraphicsUnit.Point)
        'objDgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(197, 144, 225)
        objDgv.DefaultCellStyle.SelectionBackColor = Color.DarkGray
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
         { _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "displayed_descr", "Descr", "", 310, DataGridViewContentAlignment.TopLeft, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "displayed_subtotal", "Subtotal", "", 100, DataGridViewContentAlignment.TopRight, True, col), _
 _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_line", "Line", "payment_line", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_iscash", "IsCash", "payment_iscash", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_type", "Type", "pospayment_id", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_typename", "TypeName", "pospayment_name", 60, DataGridViewContentAlignment.MiddleLeft, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_bankname", "BankName", "pospayment_bank", 60, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_cardnumber", "CardNumber", "payment_cardnumber", 60, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_cardholder", "CardHolder", "payment_cardholder", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_edc", "Price", "Price", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_installment", "Inst", "payment_installment", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_value", "Value", "payment_mvalue", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_cash", "Cash", "payment_mcash", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_refund", "Refund", "payment_refund", 60, DataGridViewContentAlignment.MiddleRight, True, col) _
         })


        Dim i As Integer
        Dim colname As String = ""
        Dim dpwidth As Integer = 0
        For i = 0 To objDgv.Columns.Count - 1
            colname = objDgv.Columns(i).Name
            If Mid(colname, 1, 10) = "displayed_" Then
                objDgv.Columns(colname).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                If colname <> "displayed_descr" Then
                    dpwidth += objDgv.Columns(colname).Width
                    objDgv.Columns(colname).Resizable = DataGridViewTriState.False
                Else
                    objDgv.Columns(colname).Resizable = DataGridViewTriState.True
                End If
            Else
                objDgv.Columns(colname).Visible = False
            End If
        Next



        objDgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        objDgv.RowHeadersWidth = 15
        objDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing

        objDgv.RowTemplate.Height = 48


        ' Behaviours: 
        objDgv.MultiSelect = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AutoGenerateColumns = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Function

   

#End Region

    Private Sub dlgTrnPosVoid_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.POS = Nothing
    End Sub





    Private Sub dlgTrnPosVoid_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FormatDgvPOSPayments(Me.DgvPayments)
        FormatDgvPOSItem(Me.DgvPOSItem)

        Me.DgvPOSItem.DataSource = Me.oBon.Items
        Me.DgvPOSItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        Me.DgvPayments.DataSource = Me.oBon.Payments
        Me.DgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect


        Me.DgvPOSItem_AdjustWidht(20)


        Me.objID.Text = Me.oBon.Header.Rows(0).Item("bon_id")
        Me.chkVoid.Checked = Me.oBon.Header.Rows(0).Item("bon_isvoid")
        Me.objPaymentTOTAL.Text = String.Format("{0:#,##0}", CDec(Me.oBon.Header.Rows(0).Item("bon_mtotal")))



        ' Binding Value
        Me.objIDExt.DataBindings.Add(New Binding("Text", Me.oBon.Header, "bon_idext"))
        Me.objFakturPajak.DataBindings.Add(New Binding("Text", Me.oBon.Header, "bon_fakturpajak"))


        Me.objPaymentTotalQty.DataBindings.Add(New Binding("Text", Me.oBon.Header, "bon_itemqty"))
        Me.objPaymentTotalValue.DataBindings.Add(New Binding("Text", Me.oBon.Header, "bon_msubtotal", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.objPaymentDiscVoucherTotal.DataBindings.Add(New Binding("Text", Me.oBon.Header, "bon_msubtracttotal", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.objPaymentDiscValue.DataBindings.Add(New Binding("Text", Me.oBon.Header, "bon_mdiscpayment", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.objPaymentTOTAL.DataBindings.Add(New Binding("Text", Me.oBon.Header, "bon_mtotal", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))



        If Not Me.MODE = "VOID" Then
            If Me.chkVoid.Checked Then
                Me.lblVoidBy.Visible = True
                Me.objUsername.Visible = True
                Me.objUsername.Text = Me.oBon.Header.Rows(0).Item("bon_voidby")
            Else
                Me.lblVoidBy.Visible = False
                Me.objUsername.Visible = False
                Me.objUsername.Text = ""
            End If
        End If


    End Sub

    Private Sub DgvPOSItem_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvPOSItem.Resize
        Me.DgvPOSItem_AdjustWidht(20)
    End Sub

    Private Sub DgvPOSItem_AdjustWidht(ByVal constant As Integer)
        If Me.DgvPOSItem.Columns.Contains("displayed_descr") Then
            Dim i As Integer
            Dim colname As String = ""
            Dim dpwidth As Integer = 0
            For i = 0 To Me.DgvPOSItem.Columns.Count - 1
                colname = Me.DgvPOSItem.Columns(i).Name
                If Mid(colname, 1, 10) = "displayed_" Then
                    Me.DgvPOSItem.Columns(colname).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    If colname <> "displayed_descr" Then
                        dpwidth += Me.DgvPOSItem.Columns(colname).Width
                    End If
                Else
                    Me.DgvPOSItem.Columns(colname).Visible = False
                End If
            Next

            If Me.DgvPOSItem.Width > dpwidth + constant + 150 Then
                Me.DgvPOSItem.Columns("displayed_descr").Width = Me.DgvPOSItem.Width - (dpwidth + constant)
            End If
        End If

    End Sub


    Private Sub DgvPOSItem_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvPOSItem.CellFormatting
        Dim colname As String = Me.DgvPOSItem.Columns(e.ColumnIndex).Name


        'Me.DgvPOSItem.Rows(e.RowIndex).Height = 48
        Select Case colname
            Case "displayed_id"
                e.Value = Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_item").Value
            Case "displayed_descr"
                Dim name, art, mat, col, size, region As String
                Dim price, discpstd01, discrstd01, discpvou01, discrvou01 As Decimal

                name = Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_descr").Value
                art = Mid(Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_article").Value, 1, 10)
                mat = Mid(Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_material").Value, 1, 5)
                col = Mid(Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_color").Value, 1, 5)
                size = Mid(Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_size").Value, 1, 5)
                price = CDec(Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_pricegross").Value)
                discpstd01 = CDec(Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_discpstd01").Value)
                discrstd01 = CDec(Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_discrstd01").Value)
                discpvou01 = CDec(Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_discpvou01").Value)
                discrvou01 = CDec(Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_discrvou01").Value)

                region = Me.DgvPOSItem.Rows(e.RowIndex).Cells("region_nameshort").Value


                e.Value = art.PadRight(10) & "   " & mat.PadRight(5) & "  " & col.PadRight(5) & "  " & size.PadRight(5) & vbCrLf & _
                          name & ", " & region & vbCrLf & _
                          "      Rp " & String.Format("{0:#,##0}", price).ToString.PadLeft(12, " ")


                If discpstd01 > 0 Then
                    e.Value &= "     (Disc " & String.Format("{0:#,##0}", discpstd01) & "%)"
                End If

                If discpvou01 > 0 Then
                    If discpstd01 > 0 Then
                        e.Value &= " (+ AddDisc Voucher " & String.Format("{0:#,##0}", discpvou01) & "%)"
                    Else
                        e.Value &= "     (+ AddDisc Voucher " & String.Format("{0:#,##0}", discpvou01) & "%)"
                    End If
                End If


            Case "displayed_net"
                Dim net As Decimal
                net = CDec(Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_pricenet").Value)
                e.Value = String.Format("{0:#,##0}", net)

            Case "displayed_qty"
                Dim qty As Decimal
                qty = CDec(Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_qty").Value)
                e.Value = String.Format("{0:#,##0}", qty)

            Case "displayed_subtotal"
                Dim subtotal As Decimal
                subtotal = CDec(Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_subtotal").Value)
                e.Value = String.Format("{0:#,##0}", subtotal)

        End Select
    End Sub

    Private Sub DgvPayments_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvPayments.CellFormatting
        Dim colname As String = Me.DgvPayments.Columns(e.ColumnIndex).Name
        Select Case colname
            Case "displayed_descr"
                Dim type, typename, bank, cardnumber, cardholder As String
                Dim value, cash, refund As Decimal
                Dim iscash As Integer

                type = Me.DgvPayments.Rows(e.RowIndex).Cells("payment_type").Value
                typename = Me.DgvPayments.Rows(e.RowIndex).Cells("payment_typename").Value
                bank = Me.DgvPayments.Rows(e.RowIndex).Cells("payment_bankname").Value
                cardnumber = Me.DgvPayments.Rows(e.RowIndex).Cells("payment_cardnumber").Value
                cardholder = Me.DgvPayments.Rows(e.RowIndex).Cells("payment_cardholder").Value

                value = CDec(Me.DgvPayments.Rows(e.RowIndex).Cells("payment_value").Value)
                cash = CDec(Me.DgvPayments.Rows(e.RowIndex).Cells("payment_cash").Value)
                refund = CDec(Me.DgvPayments.Rows(e.RowIndex).Cells("payment_refund").Value)
                iscash = CInt(Me.DgvPayments.Rows(e.RowIndex).Cells("payment_iscash").Value)


                If iscash = 1 Then
                    e.Value = typename & " (" & type & ")" & vbCrLf & _
                              "    CASH: " & String.Format("{0:#,##0}", cash) & vbCrLf & _
                              "    REFN: " & String.Format("{0:#,##0}", refund)
                Else
                    e.Value = typename & " (" & type & ")" & ",  " & bank & vbCrLf & _
                              "    " & cardnumber & vbCrLf & _
                              "    " & cardholder
                End If

            Case "displayed_subtotal"
                Dim value
                value = CDec(Me.DgvPayments.Rows(e.RowIndex).Cells("payment_value").Value)
                e.Value = String.Format("{0:#,##0}", value)
        End Select


    End Sub

    Private Sub dlgTrnPosVoid_DialogCancelClick() Handles Me.DialogCancelClick
        Me.POS = Nothing
    End Sub

    Private Sub dlgTrnPosVoid_DialogOKClick(ByRef retObj As Object, ByRef cancel As Boolean) Handles Me.DialogOKClick
        Dim res As DialogResult
        If Me.MODE = "VOID" Then
            If Me.chkVoid.Checked Then
                MessageBox.Show("Bon '" & Me.objID.Text & "' telah di-void!")
                Exit Sub
            End If


            res = MessageBox.Show("Apakah anda yakin akan void bon '" & Me.objID.Text & "'", "VOID", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If res = Windows.Forms.DialogResult.OK Then
                Try
                    Me.POS.VoidBon(Me.objID.Text, Me.voidby)
                    Me.myRetObj = New Object() {Me.objID.Text}
                    Me.POS = Nothing
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "VOID", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    cancel = True
                End Try
            Else
                cancel = True
            End If
        End If
    End Sub


    Private Sub dlgTrnPosVoid_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.POS = Nothing
    End Sub

End Class
