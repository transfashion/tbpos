
Public Class dlgTrnPosReturNote

    Private DSNLocal As String
    Private WithEvents POS As TransStore.POS
    Private oBon As uiTrnPosEN.PosBonData

    Private Loaded As Boolean = False
    Private StatusVisible As Boolean = False
    Private ReShown As Boolean = False

#Region " constructor "

    Public Sub New(ByVal [dsn] As String, ByRef [pos] As TransStore.POS, ByVal o As uiTrnPosEN.PosBonData)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DSNLocal = [dsn]
        Me.POS = [pos]
        Me.oBon = o

    End Sub

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


    Private Sub dlgTrnPosEN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TransStore.POS.InstanceNumerator = 0

        Dim obj As Control
        For Each obj In Me.Controls
            If obj.Name <> Me.PnlPosMain.Name Then
                Me.Controls.Remove(obj)
            End If
        Next

        Me.Text = "POS"
        Me.ShowInTaskbar = True


        Me.txtSubtotal.Text = "0"
        Me.txtCount.Text = "0"

        ' Me.PaymentType_Change()
        ' Me.PaymentType_GetShortcut()



   
        Me.SuspendLayout()

        FormatDgvPOSPayments(Me.DgvPayments)
        FormatDgvPOSItem(Me.DgvPOSItem)


        Me.DgvPOSItem.DataSource = Me.oBon.Items
        Me.DgvPOSItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        Me.DgvPayments.DataSource = Me.oBon.Payments
        Me.DgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect


        Me.Dgv_AdjustWidht(Me.DgvPOSItem, 20)
        Me.Dgv_AdjustWidht(Me.DgvPayments, 20)


        ' Binding Value
        Me.objBonId.DataBindings.Add(New Binding("Text", Me.oBon.Header, "bon_id"))
        Me.objPaymentTotalQty.DataBindings.Add(New Binding("Text", Me.oBon.Header, "bon_itemqty"))
        Me.objPaymentTotalValue.DataBindings.Add(New Binding("Text", Me.oBon.Header, "bon_msubtotal", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))

        Me.objPaymentDiscVoucherTotal.DataBindings.Add(New Binding("Text", Me.oBon.Header, "bon_msubtracttotal", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.objPaymentDiscValue.DataBindings.Add(New Binding("Text", Me.oBon.Header, "bon_mdiscpayment", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.objPaymentTOTAL.DataBindings.Add(New Binding("Text", Me.oBon.Header, "bon_mtotal", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))




        Me.lineItemDisplay.BackColor = Color.DarkGray
        'Me.BackgroundImage = My.Resources.tbbg
        Me.BackColor = Color.DarkGray

        Me.PnlPosMain.Dock = DockStyle.Fill
        Me.PnlPosMainCenter.Dock = DockStyle.Fill
        Me.PanelPOSItem.Dock = DockStyle.Fill
        Me.DgvPOSItem.Dock = DockStyle.Fill
        Me.PanelRetur.Dock = DockStyle.Fill

        Me.PnlPosMainH.BackgroundImageLayout = ImageLayout.Stretch
        Me.PnlPosMainCenter.BackgroundImageLayout = ImageLayout.Stretch
        Me.PnlPosMainF.BackgroundImageLayout = ImageLayout.Stretch

        Me.PnlPosMainH.BackgroundImage = My.Resources.tbbg
        Me.PnlPosMainCenter.BackgroundImage = My.Resources.tbbg3
        Me.PnlPosMainCenter.BorderStyle = BorderStyle.None
        Me.PnlPosMainF.BackgroundImage = My.Resources.tbbg4

        Me.lineItemDisplay.BackColor = Color.FromArgb(161, 161, 161)

        Me.lblQuantity.ForeColor = Color.FromArgb(78, 78, 78)
        Me.lineSubtotal.BackColor = Color.FromArgb(100, 100, 100)
        Me.lineQuantity.BackColor = Color.FromArgb(100, 100, 100)

        Me.txtSubtotal.ForeColor = Color.FromArgb(32, 44, 102)
        Me.txtCount.ForeColor = Color.FromArgb(32, 44, 102)



        Me.ResumeLayout()



        Me.Loaded = True
    End Sub


    Private Sub DgvPOSItem_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvPOSItem.CellFormatting
        Dim dgv As DataGridView = CType(sender, DataGridView)
        Dim colname As String = dgv.Columns(e.ColumnIndex).Name

        'Me.DgvPOSItem.Rows(e.RowIndex).Height = 48
        Select Case colname
            Case "displayed_id"
                e.Value = dgv.Rows(e.RowIndex).Cells("bondetil_item").Value
            Case "displayed_descr"
                Dim name, art, mat, col, size, region As String
                Dim price, discpstd01, discrstd01, discpvou01, discrvou01 As Decimal

                name = dgv.Rows(e.RowIndex).Cells("bondetil_descr").Value
                art = Mid(dgv.Rows(e.RowIndex).Cells("bondetil_article").Value, 1, 10)
                mat = Mid(dgv.Rows(e.RowIndex).Cells("bondetil_material").Value, 1, 5)
                col = Mid(dgv.Rows(e.RowIndex).Cells("bondetil_color").Value, 1, 5)
                size = Mid(dgv.Rows(e.RowIndex).Cells("bondetil_size").Value, 1, 5)
                price = CDec(dgv.Rows(e.RowIndex).Cells("bondetil_pricegross").Value)
                discpstd01 = CDec(dgv.Rows(e.RowIndex).Cells("bondetil_discpstd01").Value)
                discrstd01 = CDec(dgv.Rows(e.RowIndex).Cells("bondetil_discrstd01").Value)
                discpvou01 = CDec(dgv.Rows(e.RowIndex).Cells("bondetil_discpvou01").Value)
                discrvou01 = CDec(dgv.Rows(e.RowIndex).Cells("bondetil_discrvou01").Value)

                region = dgv.Rows(e.RowIndex).Cells("region_nameshort").Value


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
                net = CDec(dgv.Rows(e.RowIndex).Cells("bondetil_pricenet").Value)
                e.Value = String.Format("{0:#,##0}", net)

            Case "displayed_qty"
                Dim qty As Decimal
                qty = CDec(dgv.Rows(e.RowIndex).Cells("bondetil_qty").Value)
                e.Value = String.Format("{0:#,##0}", qty)

            Case "displayed_subtotal"
                Dim subtotal As Decimal
                subtotal = CDec(dgv.Rows(e.RowIndex).Cells("bondetil_subtotal").Value)
                e.Value = String.Format("{0:#,##0}", subtotal)

        End Select
    End Sub

    Private Sub DgvPayments_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvPayments.CellFormatting
        Dim dgv As DataGridView = CType(sender, DataGridView)
        Dim colname As String = dgv.Columns(e.ColumnIndex).Name
        Select Case colname
            Case "displayed_descr"
                Dim type, typename, bank, cardnumber, cardholder As String
                Dim value, cash, refund As Decimal
                Dim iscash As Integer

                type = dgv.Rows(e.RowIndex).Cells("payment_type").Value
                typename = dgv.Rows(e.RowIndex).Cells("payment_typename").Value
                bank = dgv.Rows(e.RowIndex).Cells("payment_bankname").Value
                cardnumber = dgv.Rows(e.RowIndex).Cells("payment_cardnumber").Value
                cardholder = dgv.Rows(e.RowIndex).Cells("payment_cardholder").Value

                value = CDec(dgv.Rows(e.RowIndex).Cells("payment_value").Value)
                cash = CDec(dgv.Rows(e.RowIndex).Cells("payment_cash").Value)
                refund = CDec(dgv.Rows(e.RowIndex).Cells("payment_refund").Value)
                iscash = CInt(dgv.Rows(e.RowIndex).Cells("payment_iscash").Value)


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
                value = CDec(dgv.Rows(e.RowIndex).Cells("payment_value").Value)
                e.Value = String.Format("{0:#,##0}", value)
        End Select


    End Sub


    Private Sub DgvPOSItem_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvPOSItem.Resize
        Me.Dgv_AdjustWidht(sender, 20)
    End Sub

    Private Sub DgvPayments_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvPayments.Resize
        Me.Dgv_AdjustWidht(sender, 20)
    End Sub

    Private Sub Dgv_AdjustWidht(ByVal sender As Object, ByVal constant As Integer)
        Dim dgv As DataGridView = CType(sender, DataGridView)
        If dgv.Columns.Contains("displayed_descr") Then
            Dim i As Integer
            Dim colname As String = ""
            Dim dpwidth As Integer = 0
            For i = 0 To dgv.Columns.Count - 1
                colname = dgv.Columns(i).Name
                If Mid(colname, 1, 10) = "displayed_" Then
                    dgv.Columns(colname).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    If colname <> "displayed_descr" Then
                        dpwidth += dgv.Columns(colname).Width
                    End If
                Else
                    dgv.Columns(colname).Visible = False
                End If
            Next

            If dgv.Width > dpwidth + constant + 150 Then
                dgv.Columns("displayed_descr").Width = dgv.Width - (dpwidth + constant)
            End If
        End If

    End Sub

    Public Function POSTransactionPrepare() As Boolean
        Me.ReShown = True
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub





    Private Sub DgvPOSItem_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvPOSItem.CellDoubleClick
        Dim dgv As DataGridView = CType(sender, DataGridView)
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If dgv.CurrentRow IsNot Nothing Then
            dgv.Enabled = False
            Me.OpenPanelReturn(dgv.CurrentRow)
        End If
    End Sub

    Private Sub DgvPOSItem_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvPOSItem.RowHeaderMouseDoubleClick
        Dim dgv As DataGridView = CType(sender, DataGridView)
        If dgv.CurrentRow IsNot Nothing Then
            dgv.Enabled = False
            Me.OpenPanelReturn(dgv.CurrentRow)
        End If
    End Sub



    Private Sub OpenPanelReturn(ByVal row As DataGridViewRow)
        ' Isi Data


        Me.objItemId.Text = row.Cells("bondetil_item").Value
        Me.objItemArtMatCol.Text = row.Cells("bondetil_article").Value & "  |  " & row.Cells("bondetil_material").Value & "  |  " & row.Cells("bondetil_color").Value & "  |  " & row.Cells("bondetil_size").Value
        Me.objItemDescr.Text = row.Cells("bondetil_descr").Value
        Me.objItemPrice.Text = String.Format("{0:#,##0}", CDec(row.Cells("bondetil_pricegross").Value)) & "   /  " & row.Cells("bondetil_discpstd01").Value & "%"
        Me.objItemQty.Text = row.Cells("bondetil_qty").Value
        Me.objItemSubtotal.Text = String.Format("{0:#,##0}", CDec(row.Cells("bondetil_subtotal").Value))



        Me.PanelRetur.Visible = True
    End Sub

    Private Sub btnReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturn.Click


        If Me.DgvPOSItem.CurrentRow IsNot Nothing Then
            Me.btnReturn.Enabled = False
            Me.btnReturnCancel.Enabled = False
            Me.btnReturn.Visible = False
            Me.btnReturnCancel.Visible = False

            Dim row As DataGridViewRow = Me.DgvPOSItem.CurrentRow

            ' Ambil qty yang sudah dikembalikan
            Dim qty_ret As Integer = Me.POS.GetBonReturnedItem(oBon.Header.Rows(0).Item("bon_id").ToString, row.Cells("bondetil_item").Value)
            Me.objItemRetQtyMax.Text = row.Cells("bondetil_qty").Value + qty_ret
            Me.objItemRetQty.Text = row.Cells("bondetil_qty").Value + qty_ret





            Me.PanelReturnConfirm.Visible = True

        End If

        Me.objItemRetBonReplacement.Text = ""
        Me.objItemRetDescr.Text = ""

        Me.objItemRetQty.Focus()



        'Me.DgvPOSItem.Enabled = False


    End Sub


    Private Sub btnReturnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnCancel.Click
        Me.PanelRetur.Visible = False
        Me.DgvPOSItem.Enabled = True
    End Sub

    Private Sub btnReturnConfirmCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnConfirmCancel.Click
        Me.btnReturn.Enabled = True
        Me.btnReturnCancel.Enabled = True
        Me.btnReturn.Visible = True
        Me.btnReturnCancel.Visible = True
        Me.PanelReturnConfirm.Visible = False

    End Sub



    Private Sub Item_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
        DgvPOSItem.KeyDown, _
        DgvPayments.KeyDown, _
        btnReturnCancel.KeyDown, _
        btnReturn.KeyDown, _
        btnReturnConfirmCancel.KeyDown, _
        btnReturnConfirmExecute.KeyDown, _
        objItemRetQty.KeyDown, _
        objItemRetBonReplacement.KeyDown, _
        objItemRetDescr.KeyDown, _
        btnExit.KeyDown


        If e.KeyValue = 27 Then
            Me.Close()
            Exit Sub
        End If

    End Sub

    Private Sub btnReturnConfirmExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnConfirmExecute.Click
        If Trim(Me.objBonId.Text) = Trim(Me.objItemRetBonReplacement.Text) Then
            MessageBox.Show("No Bon Pengganti salah", "Nota Retur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        ' Cek Qty
        Try
            Dim qtyret As Integer = CInt(Me.objItemRetQty.Text)
            If qtyret < 1 Or qtyret > CInt(Me.objItemRetQtyMax.Text) Then
                Throw New Exception("Qty Retur tidak benar")
            End If

            ' Cek bon
            Dim obj As TransStore.POS.PosHeader = New TransStore.POS.PosHeader
            Dim oBon As uiTrnPosEN.PosBonData


            obj.bon_id = Trim(Me.objItemRetBonReplacement.Text)
            If obj.bon_id = "" Then
                Throw New Exception("Nomer bon baru belum diisi, apabila tidak diganti dengan transaksi lain, silakan isi dengan 'NONE'")
            End If

            If Trim(Me.objItemRetBonReplacement.Text) <> "NONE" And Trim(Me.objItemRetBonReplacement.Text) <> "TBA" Then
                oBon = Me.POS.GetBonData(obj)
                If oBon.Header.Rows.Count <= 0 Then
                    Throw New Exception("Bon pengganti " & obj.bon_id & " tidak terdaftar!" & vbCrLf & "Mungkin penulisan bon salah")
                End If
            End If

            ' Cek keterangan
            If Trim(Me.objItemRetDescr.Text) = "" Then
                Throw New Exception("Keterangan belum diisi.")
            End If



            ' Data ok, buat nota retur
            If MessageBox.Show("Apakah anda yakin akan membuat nota retur " & vbCrLf & "untuk bon '" & Me.objBonId.Text & "' item '" & Me.objItemDescr.Text & "' sebanyak " & qtyret & " pcs," & vbCrLf & "dan diganti dengan bon '" & obj.bon_id & "' ?", "Nota Retur", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Try
            End If


            Dim notaretur_id As String
            notaretur_id = Me.POS.SaveNotaRetur(Me.objBonId.Text, Me.objItemId.Text, qtyret, Me.objItemRetDescr.Text, Me.objItemRetBonReplacement.Text)


            If notaretur_id <> "" Then
                Me.PrintNotaRetur(notaretur_id)
                MessageBox.Show("Nota retur telah selesai dibuat", "Nota Retur", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If


            Me.PanelRetur.Visible = False
            Me.PanelReturnConfirm.Visible = False
            Me.btnReturnCancel.Visible = True
            Me.btnReturn.Visible = True
            Me.btnReturnCancel.Enabled = True
            Me.btnReturn.Enabled = True
            Me.DgvPOSItem.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Nota Retur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try


    End Sub






    Private Sub PrintNotaRetur(ByVal nr_id As String)
        ' 010.010.10.0500000161

        Dim bon As TransStore.POS.PosHeader = New TransStore.POS.PosHeader
        Dim o As uiTrnPosEN.PosBonData
        Dim txt As String = ""
        Dim txtPreview As String = ""
        Dim ret As Boolean
        Dim strs() As String
        Dim i As Integer


        bon.bon_id = nr_id

        txtPreview &= "             10        20        30        40        50        60        70        80        90       100       110       120       130       " & vbCrLf
        txtPreview &= "     12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567" & vbCrLf
        txtPreview &= vbCrLf

        o = Me.POS.GetBonData(bon)
        If o.Header.Rows.Count <= 0 Then
            MessageBox.Show("Bon '" & bon.bon_id & "' tidak ditemukan", "Bon", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        strs = Me.POS.FormatReturNote(o, False, False)
        For i = 0 To strs.Length - 1
            txtPreview &= (i + 1).ToString.PadLeft(3) & "  " & strs(i) & vbCrLf
            txt &= strs(i) & vbCrLf
        Next
        'txt = String.Join(vbCrLf, Me.POS.FormatBon(o))


        ret = uiTrnPosEN.SendTextToPrinter(Me.POS, txt, uiTrnPosEN.PrintMethod.PrintOnly, LX300.P_PAGE_07)

    End Sub

End Class
