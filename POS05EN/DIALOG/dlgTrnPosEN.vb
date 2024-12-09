
Public Class dlgTrnPosEN


    ' Tidak perlu dipakai lagi, tapi di set dari data development
    Public Sub SetRegionBranchDevelopment()
        If Me.POS.IsDevelopmentMode = True Then
            Me.objPosEventName.Text = Me.objPosEventName.Text & " (DevMode " & Me.POS.RegionId & ":" & Me.POS.BranchId & ")"
        End If
    End Sub

    Private startInfo As ProcessStartInfo


    Private DSNLocal As String
    Private WithEvents POS As TransStore.POS

    Private PaymentTypeIndex As Integer = 0
    Private LastRowIndex As Integer
    Private OperatorIndex As Integer = 0
    Private SkipCellEvent As Boolean
    Private SkipCellEventEnter As Boolean
    Private objErrProvItemNotFound As ErrorProvider = New ErrorProvider()
    Private ReShown As Boolean = False
    Private Loaded As Boolean = False
    Private StatusVisible As Boolean = False
    Private ConsumableGoodPrefixCode As String

    Private _KybShortcut_F9 As String
    Private _KybShortcut_F10 As String
    Private _KybShortcut_F11 As String
    Private _KybShortcut_F12 As String



    Private PromoItemHBS As DataTable
    Private PromoItemGeox As DataTable
    Private PromoItemEAG As DataTable
    Private PromoItemFKP As DataTable


    Private PromoItem As DataTable


    ' Private SaatIniAdaPromoTerpakai As Boolean


    Private CurrentRegionId As String
    Private CurrentBranchId As String


#Region " constructor "

    Public Sub New(ByVal [dsn] As String, ByRef [pos] As TransStore.POS)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DSNLocal = [dsn]
        Me.POS = [pos]


        Me.txt_INFO.Text = "-"

    End Sub


    Public Function getCurrentPaymentTypeIndex() As Integer
        Return Me.PaymentTypeIndex
    End Function

    Public Sub setTotal(ByVal sum_qty As Integer, ByVal sum_subtotal As Decimal)
        Me.txtSubtotal.Text = String.Format("{0:#,##0}", CDec(sum_subtotal))
        Me.txtCount.Text = String.Format("{0:#,##0}", CDec(sum_qty))
    End Sub

#End Region


#Region " Action "

    Private Function Key_Escape(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        Me.Hide()
    End Function

    Private Function Key_ArrowUp(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        'Me.txtItemEntry.Text = ""
        Me.DgvPosItemReadOnlyState()
        If Me.DgvPOSItem.Rows.Count > 0 Then
            Dim currIndex As Integer = 0
            If Me.DgvPOSItem.CurrentRow IsNot Nothing Then
                currIndex = Me.DgvPOSItem.CurrentRow.Index
                If currIndex > 0 Then
                    currIndex -= 1
                End If
            Else
                currIndex = 0
            End If
            Me.DgvPOSItem.CurrentCell = Me.DgvPOSItem.Rows(currIndex).Cells(0)
            Me.DgvPOSItem.FirstDisplayedCell = Me.DgvPOSItem.CurrentCell
            Me.LastRowIndex = currIndex
        End If
    End Function

    Private Function Key_ArrowDown(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        'Me.txtItemEntry.Text = ""
        Me.DgvPosItemReadOnlyState()
        If Me.DgvPOSItem.Rows.Count > 0 Then
            Dim currIndex As Integer = 0
            If Me.DgvPOSItem.CurrentRow IsNot Nothing Then
                currIndex = Me.DgvPOSItem.CurrentRow.Index
                If currIndex < Me.DgvPOSItem.Rows.Count - 1 Then
                    currIndex += 1
                End If
            Else
                currIndex = 0
            End If
            Me.DgvPOSItem.CurrentCell = Me.DgvPOSItem.Rows(currIndex).Cells(0)
            Me.DgvPOSItem.FirstDisplayedCell = Me.DgvPOSItem.CurrentCell
            Me.LastRowIndex = currIndex
        End If
    End Function

    Private Function Key_PageUp(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        Me.PaymentType_IndexUp()
    End Function

    Private Function Key_PageDown(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        Me.PaymentType_IndexDown()
    End Function

    Private Function Key_Enter(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        Dim searchArt As Boolean = False
        Dim searchInternalBarcode As Boolean = False

        'If Left(id, 2) = TransStore.POS.ItemIdentifier Then

        If Trim(Me.txtItemEntry.Text) = "" Then
            Return False
        End If

        Me.objErrProvItemNotFound.SetError(Me.txtItemSelectedName, "")
        Me.txtItemSelectedName.Text = "Searching..."
        Me.txtItemSelectedQty.Text = ""
        Me.txtItemSelectedPrice.Text = ""
        Me.txtItemSelectedName.Refresh()
        Me.txtItemSelectedQty.Refresh()
        Me.txtItemSelectedPrice.Refresh()

        Me.SuspendLayout()
        Dim n As Integer = 1
        Dim id As String = Me.txtItemEntry.Text
        Dim ret As Boolean
        Dim cancel As Boolean = False
        Dim insearchingmode As Boolean = False
        Dim selstart As Integer = Me.txtItemEntry.SelectionStart
        Dim vou01discpercent As Decimal
        Dim itempref As String = ""
        Dim ItemNotFoundWarning = "NOT FOUND!"


        Try
            ' SEARCH REGEX
            ' ART:NNN*/NN/NN
            ' DES:NNN*
            Dim temptext As String = Trim(Me.txtItemEntry.Text) & "    "
            Dim [operator] As String = temptext.Substring(0, 4)

            If [operator].ToUpper = "ART:" Or [operator].ToUpper = "DES:" Then
                searchArt = True
                insearchingmode = True
            Else
                ' Cek, key dimasukkan dengan syntax perkalian
                ' n * xxxxxxxx
                ' cari apakah ada tanda * dimasukkan
                Dim asterixpos As Integer = Me.txtItemEntry.Text.IndexOf("*")
                If asterixpos > 0 Then
                    Dim strs() As String = Me.txtItemEntry.Text.Split("*")
                    Try
                        n = CInt(Trim(strs(0)))
                    Catch ex As Exception
                        itempref = Trim(strs(0))
                    End Try
                    id = Trim(strs(1))
                End If
            End If

            Try
                vou01discpercent = CType(Me.objVoucher01Disc.Text, Decimal)
            Catch ex As Exception
                vou01discpercent = 0
            End Try

            Me.Cursor = Cursors.WaitCursor
            Me.SkipCellEvent = True

            If Strings.Left(id, 2) = TransStore.POS.ItemIdentifier Then
                searchInternalBarcode = True
            End If


            If itempref = "B" Then  ' User entry barang bonus
                ret = Me.POS.ItemAdd(id, n, "", "BONUS", "", 100, "BONUS", cancel)
            Else
                ret = Me.POS.ItemAdd(id, n, Me.objVoucher01Id.Text, Me.objVoucher01Type.Text, Me.objVoucher01CodeNum.Text, vou01discpercent, Me.objVoucher01Method.Text, cancel)
            End If

            Me.SkipCellEvent = False
        Catch ex As ItemNotAllowedException
            ItemNotFoundWarning = "NOT ALLOWED"
            Me.SkipCellEvent = False
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try

        If Me.txtItemSelectedName.Text = "Searching..." Then
            Me.txtItemSelectedName.Text = ""
        End If


        If Not insearchingmode Then
            Me.txtItemEntry.Text = ""
        Else
            Me.txtItemEntry.SelectionStart = selstart
            Me.txtItemEntry.SelectionLength = 0
        End If

        If Not cancel Then
            If Not ret Then
                Dim not_found_message As String = ItemNotFoundWarning & "   [" & id & "]"
                'If Me.POS.SCANMODE = POS.MODE_BARCODESCAN And (searchArt Or searchInternalBarcode) Then
                '    not_found_message = "Please search by Product Barcode"
                '    Me.txtItemEntry.Text = ""
                'End If

                If (Me.POS.SCANMODE = POS.MODE_BARCODESCAN Or Me.POS.SCANMODE = POS.MODE_ORIGINALBARCODESCAN) And searchArt Then
                    not_found_message = "Please search by Product Barcode"
                    Me.txtItemEntry.Text = ""
                ElseIf Me.POS.SCANMODE = POS.MODE_ORIGINALBARCODESCAN And searchInternalBarcode Then
                    not_found_message = "Please search by Product Barcode"
                    Me.txtItemEntry.Text = ""
                End If


                Me.txtItemSelectedName.Text = not_found_message
                Me.txtItemSelectedName.Refresh()
                Me.objErrProvItemNotFound.SetError(Me.txtItemSelectedName, not_found_message)
                Me.objErrProvItemNotFound.SetIconAlignment(Me.txtItemSelectedName, ErrorIconAlignment.MiddleLeft)
                uiTrnPosEN.BeepItemNotFound()
            Else
                Me.objErrProvItemNotFound.SetError(Me.txtItemSelectedName, "")
            End If
        End If

        Me.ResumeLayout()


    End Function

    Private Function Key_F1(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        Dim temptext As String = Trim(Me.txtItemEntry.Text)
        Dim [operator] As String
        Dim ops() As String = {"", "ART:", "DES:", "HLP:"}
        If Len(temptext) >= 4 Then
            [operator] = temptext.Substring(0, 4)
            If [operator] = "ART:" Or [operator] = "DES:" Or [operator] = "HLP:" Then
                OperatorIndex += 1
                If OperatorIndex = 4 Then OperatorIndex = 0
                Me.txtItemEntry.Text = Me.txtItemEntry.Text.Replace([operator], ops(OperatorIndex))
            Else
                OperatorIndex = 1
                Me.txtItemEntry.Text = ops(OperatorIndex) & Me.txtItemEntry.Text
            End If
        Else
            OperatorIndex = 1
            Me.txtItemEntry.Text = "ART:" & Me.txtItemEntry.Text
        End If
        Me.txtItemEntry.SelectionStart = Len(Me.txtItemEntry.Text)
        Me.txtItemEntry.SelectionLength = 0

    End Function

    Private Function Key_F3(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        ' Edit Qty
        Me.txtItemEntry.Text = ""
        If Me.DgvPOSItem.Rows.Count > 0 Then
            Dim currIndex As Integer = 0
            If Me.DgvPOSItem.CurrentRow IsNot Nothing Then
                currIndex = Me.DgvPOSItem.CurrentRow.Index

                If Me.DgvPOSItem.ReadOnly Then
                    Me.SkipCellEventEnter = True
                    Me.DgvPOSItem.ReadOnly = False
                    Me.DgvPOSItem.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
                    Me.DgvPOSItem.Columns("displayed_qty").ReadOnly = False
                    Me.DgvPOSItem.CurrentCell = Me.DgvPOSItem.Rows(currIndex).Cells("displayed_qty")
                    Me.DgvPOSItem.CurrentCell.Selected = True
                    Me.DgvPOSItem.CurrentCell.Style.BackColor = Color.WhiteSmoke
                    Me.DgvPOSItem.Focus()
                Else
                    Me.DgvPosItemReadOnlyState()
                    Me.DgvPOSItem.Columns("displayed_qty").ReadOnly = True
                    Me.DgvPOSItem.CurrentCell = Me.DgvPOSItem.Rows(currIndex).Cells("displayed_qty")
                    Me.DgvPOSItem.CurrentRow.Selected = True
                    Me.txtItemEntry.Focus()
                    Me.objErrProvItemNotFound.SetError(Me.txtItemSelectedName, "")
                End If

            End If
        End If
    End Function

    Private Function Key_F4(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        If Me.DgvPOSItem.Rows.Count <= 0 Then
            Return False
            Exit Function
        End If

        Dim pospayment_id As String = Me.objPaymentTypeId.Text
        Dim py As TransStore.PosPayment = Me.POS.GetPosPayment(pospayment_id)

        ' sorri, HARDCODE
        ' jika ada item yang diskon, paymentnnya tidak boleh infinit (108)
        'If Me.objPaymentTypeId.Text = "107" Then
        '    For Each row As DataGridViewRow In Me.DgvPOSItem.Rows
        '        Dim bondetil_pricegross As Decimal = CDec(row.Cells("bondetil_pricegross").Value)
        '        Dim bondetil_pricenet As Decimal = CDec(row.Cells("bondetil_pricenet").Value)
        '        Dim bondetil_qty As Integer = CInt(row.Cells("bondetil_qty").Value)
        '        If bondetil_pricenet < bondetil_pricegross Then
        '            MessageBox.Show("Pembayaran MEGA Infinit tidak bisa untuk item diskon", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            Return False
        '            Exit Function
        '        End If
        '    Next
        'End If



        '' Hitung Qty Real yang dibeli
        'Dim total_qty As Integer = 0
        'For Each row As DataGridViewRow In Me.DgvPOSItem.Rows
        '    Dim bondetil_qty As Integer = CInt(row.Cells("bondetil_qty").Value)
        '    Dim bondetil_pricenet As Decimal = CDec(row.Cells("bondetil_pricenet").Value)

        '    If bondetil_pricenet > 0 Then
        '        total_qty = total_qty + bondetil_qty
        '    End If
        'Next

        'If total_qty < 5 Then
        '    MessageBox.Show("Bazar Staff Sale minimal beli 5 pcs", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Return False
        '    Exit Function
        'End If


        Dim pospayment_disc As Integer = CDec(Me.POS.PaymentType.Rows(Me.PaymentTypeIndex).Item("pospayment_disc").ToString)
        If (pospayment_disc > 0) Then
            If (Me.POS.BolehDiscPayment = False) Then
                MessageBox.Show("Promo add discount tidak bisa digabung dengan disc payment", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            Else
                If Me.POS.PromoApplied Then
                    If Me.POS.AllowedPaymenttype.Count > 0 Then
                        If Not Me.POS.AllowedPaymenttype.Contains(Me.objPaymentTypeId.Text) Then
                            MessageBox.Show("Promo add discount tidak bisa menggunakan payment '" & Me.objPaymentTypeName.Text & "'", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return False
                        End If
                    End If
                End If
            End If
        End If


        ' Cek Kondisi Items
        Dim total_qty As Integer = 0
        Dim consgood_found As Boolean = False
        Dim maxdiscitem As Decimal = 0
        For Each row As DataGridViewRow In Me.DgvPOSItem.Rows
            Dim bondetil_art As String = CStr(row.Cells("bondetil_article").Value)
            Dim bondetil_qty As Integer = CInt(row.Cells("bondetil_qty").Value)
            Dim artpref = Mid(bondetil_art, 1, Len(ConsumableGoodPrefixCode))

            ' Ada Consumable goods
            If artpref = Me.ConsumableGoodPrefixCode Then
                consgood_found = consgood_found Or True
            Else
                ' Jumlah actual barang yang dibeli, untuk consumable goods tidak perlu dihitung
                total_qty = total_qty + bondetil_qty
            End If


            ' Cek discount item maximal selain GWP (100%)
            Dim bondetil_discpstd01 As Decimal = CDec(row.Cells("bondetil_discpstd01").Value)
            If bondetil_discpstd01 < 100 And bondetil_discpstd01 > maxdiscitem Then
                maxdiscitem = bondetil_discpstd01
            End If

        Next


        ' Cek Consumable Goods
        If Me.POS.CONSGOOD_IS_MANDATORY Then
            If Not consgood_found Then
                MessageBox.Show("Consumable Goods Belum di-entry", "Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
                Exit Function
            End If
        End If


        ' Cek maksimal discount based on payment method
        If maxdiscitem > py.MaximumItemDiscAllowed Then
            MessageBox.Show("Maksimum discount item untuk '" & py.Name & "' adalah " & py.MaximumItemDiscAllowed & "%", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If


        '' Cek apakah harus ada Consumable good
        'Dim ConsumableGoodIsMandatory As Boolean = Me.POS.CONSGOOD_IS_MANDATORY
        'Dim dtstart As Date = New Date(2013, 9, 1)
        'If (Now >= dtstart) Then
        '    If ConsumableGoodIsMandatory Then
        '        Dim consgood_found As Boolean = False
        '        For Each row As DataGridViewRow In Me.DgvPOSItem.Rows
        '            Dim bondetil_art As String = row.Cells("bondetil_article").Value.ToString()
        '            Dim artpref = Mid(bondetil_art, 1, Len(ConsumableGoodPrefixCode))
        '            If artpref = Me.ConsumableGoodPrefixCode Then
        '                consgood_found = True
        '                Exit For
        '            End If
        '        Next
        '        If Not consgood_found Then
        '            MessageBox.Show("Consumable Goods Belum di-entry", "Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            Return False
        '            Exit Function
        '        End If
        '    End If
        'End If

        ' Cek Voucher versus Payment Type
        Dim i As Integer
        Dim exist As Boolean = False
        Dim NOT_ALLOWED_PAYMENT As String = Trim(Me.POS.NOT_ALLOWED_PAYMENT)
        If NOT_ALLOWED_PAYMENT <> "" Then
            Dim tokens() As String
            tokens = NOT_ALLOWED_PAYMENT.Split(New String() {"USING"}, System.StringSplitOptions.RemoveEmptyEntries)
            If tokens.Length > 1 Then
                Dim vouchers() As String
                Dim payments() As String
                vouchers = tokens(0).Split(",")
                payments = tokens(1).Split(",")

                For i = 0 To vouchers.Length - 1
                    If Trim(vouchers(i).ToString).ToUpper = Me.objVoucher01Id.Text.ToUpper Then
                        exist = True
                        Exit For
                    End If
                Next

                If exist Then
                    exist = False
                    For i = 0 To payments.Length - 1
                        If Trim(payments(i).ToString).ToUpper = Me.objPaymentTypeId.Text.ToUpper Then
                            exist = True
                            Exit For
                        End If
                    Next
                Else
                    exist = False
                End If

                If exist Then
                    MessageBox.Show("Pembayaran '" & Me.objVoucher01Name.Text & "' tidak diperbolehkan menggunakan '" & Me.objPaymentTypeName.Text & "'", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                    Exit Function
                End If
            End If
        End If




        Me.SuspendLayout()

        Dim args As Object = New Object() {}
        Dim f As dlgTrnPosPayment = New dlgTrnPosPayment
        Dim result As Object
        Dim fmask As Form = uiTrnPosEN.CreateMask(0.75)
        Dim NewTransactionParamValue As TransStore.PosNewTransactionReturnValue = New TransStore.PosNewTransactionReturnValue
        With NewTransactionParamValue
            .SiteIdFrom = Me.objSiteIdFrom.Text
            .CustomerNationalityId = Me.objCustomerNationalityId.Text
            .CustomerNationalityName = Me.objCustomerNationalityName.Text
            .CustomerGenderId = Me.objCustomerGenderId.Text
            .CustomerGenderName = Me.objCustomerGenderName.Text
            .CustomerAgeId = Me.objCustomerAgeId.Text
            .CustomerAgeName = Me.objCustomerAgeName.Text
            .CustomerId = Me.objCustomerId.Text
            .CustomerName = Me.objCustomerName.Text
            .CustomerNPWP = Me.objCustomerNPWP.Text
            .CustomerTelp = Me.objCustomerTelp.Text
            .CustomerType = Me.objCustomerType.Text
            .CustomerPassport = Me.objCustomerPassport.Text
            .CustomerDisc = Me.objCustomerDisc.Text
            .Voucher01Id = Me.objVoucher01Id.Text
            .Voucher01Name = Me.objVoucher01Name.Text
            .Voucher01CodeNum = Me.objVoucher01CodeNum.Text
            .Voucher01Type = Me.objVoucher01Type.Text
            .Voucher01Method = Me.objVoucher01Method.Text
            .Voucher01Disc = Me.objVoucher01Disc.Text
            .SalesId = Me.objSalesId.Text
            .SalesName = Me.objSalesName.Text
            .BonExternal = Me.objBonExternal.Text
            .BonEvent = Me.objBonEvent.Text
        End With

        Dim objParamValue As TransStore.PosPaymentDialogParamValue = New TransStore.PosPaymentDialogParamValue
        With objParamValue
            .PaymentTypeId = Me.objPaymentTypeId.Text
            .PaymentTypeName = Me.objPaymentTypeName.Text
            .PaymentBank = Me.POS.PaymentType.Rows(PaymentTypeIndex).Item("pospayment_bankname").ToString
            .pospayment_disc = CDec(Me.POS.PaymentType.Rows(PaymentTypeIndex).Item("pospayment_disc").ToString)
            .pospayment_discvalue = CDec(Me.POS.PaymentType.Rows(PaymentTypeIndex).Item("pospayment_discvalue").ToString)
            .pospayment_discminpurchase = CDec(Me.POS.PaymentType.Rows(PaymentTypeIndex).Item("pospayment_discminpurchase").ToString)
            .pospayment_multi = CBool(Me.POS.PaymentType.Rows(PaymentTypeIndex).Item("pospayment_multi"))
            .pospayment_prefix = Me.POS.PaymentType.Rows(PaymentTypeIndex).Item("pospayment_prefix").ToString
            .pospayment_isvoucherdisabled = CBool(Me.POS.PaymentType.Rows(PaymentTypeIndex).Item("pospayment_isvoucherdisabled"))
            .pospayment_isadddiscdisabled = CBool(Me.POS.PaymentType.Rows(PaymentTypeIndex).Item("pospayment_isadddiscdisabled"))
            .pospayment_isredeemdisabled = CBool(Me.POS.PaymentType.Rows(PaymentTypeIndex).Item("pospayment_isredeemdisabled"))
            .NewTransactionParamValue = NewTransactionParamValue
        End With
        args = New Object() {objParamValue}


        fmask.SuspendLayout()
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        fmask.Show(Me)
        result = f.OpenDialog(fmask, Me.POS, args)


        'Dim res As DialogResult
        'Dim frmpaym As POS05PAYM.FormPayment = New POS05PAYM.FormPayment()
        'frmpaym.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmpaym.BackColor = Me.BackColor
        'frmpaym.ShowInTaskbar = False
        'frmpaym.StartPosition = FormStartPosition.CenterScreen
        'res = frmpaym.ShowDialog()
        'If res = Windows.Forms.DialogResult.Yes Then
        '    Me.POS.UI.SetID("")

        '    ' Kosongkan transaksi, buat transaksi baru
        '    Me.POS.NewTransaction()
        'End If


        fmask.Close()
        fmask.Dispose()
        f.Dispose()
        f = Nothing


        If result IsNot Nothing Then

            ' Set Display
            ' |..........|.........|
            ' |Next Custo mer,     |
            ' |Please...           |
            Me.txtItemSelectedName.Text = "Enter Next Transaction..."
            Me.POS_Display("", "Next Custo", "mer", "Please...", "")

            Me.Refresh()

            Dim resargs As uiTrnPosEN.PosPaymentEventArgument
            Dim objBon As TransStore.POS.PosHeader
            Try
                If TypeOf result(0) Is uiTrnPosEN.PosPaymentEventArgument Then
                    resargs = CType(result(0), uiTrnPosEN.PosPaymentEventArgument)
                    objBon = resargs.objBon

                    ' disini bon sudah tersimpan,
                    ' sudah di print, terus terserah mau diapain
                    Me.POS.UI.SetID(objBon.bon_id)


                Else
                    Throw New Exception("Cannot Convert result(0) to uiTrnPosEN.PosPaymentEventArgument")
                End If
            Catch ex As Exception
                MessageBox.Show("[dlgTrnPosEN:Key][Keys.F4]" & vbCrLf & ex.Message, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try


            Me.ResumeLayout()

            ' Kosongkan transaksi, buat transaksi baru
            Me.POS.NewTransaction()
        Else
            Me.ResumeLayout()
        End If



    End Function

    Private Function Key_F6(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        If Not Me.POS.PROMO_BUTTON Then
            Return False
        End If


        'Dim promomodel As String = "xxx"
        'Dim promoargs As PromoArguments = New PromoArguments()

        'Select Case promomodel
        '    Case "MD1"
        '        Me.SetPromo_MD1(promoargs)

        '    Case "PROMO123"
        '        Me.SetPromo_PROMO123(promoargs)

        '    Case "PROMOBUNDLING"
        '        Me.SetPromo_Bundling(promoargs)

        '    Case "PALINGMURAH"
        '        Me.SetPromo_PalingMurah(promoargs)

        '    Case "PURCHASEWITHDISC"
        '        Me.SetPromo_PurchaseWithDisc(promoargs)

        'End Select
    End Function


    Private Function Key_F7(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        Me.txtItemEntry.Text = "ART:TMCG%"
        Me.txtItemEntry.SelectionStart = Len(Me.txtItemEntry.Text)
        Me.txtItemEntry.SelectionLength = 0
        Me.Key(Keys.Enter, False, True)
    End Function

    Private Function Key_F8(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        Dim currIndex As Integer = 0
        If Me.DgvPOSItem.CurrentRow IsNot Nothing Then
            currIndex = Me.DgvPOSItem.CurrentRow.Index

            ' Dim id As String = Me.DgvPOSItem.Rows(currIndex).Cells("bondetil_item").Value
            Dim objItem As TransStore.POS.PosItemData = New TransStore.POS.PosItemData
            objItem.iteminventory_article = Me.DgvPOSItem.Rows(currIndex).Cells("bondetil_article").Value
            objItem.iteminventory_material = Me.DgvPOSItem.Rows(currIndex).Cells("bondetil_material").Value
            objItem.iteminventory_color = Me.DgvPOSItem.Rows(currIndex).Cells("bondetil_color").Value
            objItem.iteminventory_size = Me.DgvPOSItem.Rows(currIndex).Cells("bondetil_size").Value
            objItem.region_id = Me.DgvPOSItem.Rows(currIndex).Cells("region_id").Value
            objItem.rowindex = currIndex

            Dim curr_bondetil_rule = Me.DgvPOSItem.Rows(currIndex).Cells("bondetil_rule").Value


            ' cek apakah item bisa dihapus ?
            Dim tbl As DataTable = Me.DgvPOSItem.DataSource
            Dim dr() As DataRow = tbl.Select("bondetil_rule IN ('PD')")

            If (dr.Length > 0) Then
                If curr_bondetil_rule = "01" Or curr_bondetil_rule = "02" Or curr_bondetil_rule = "03" Then
                    MessageBox.Show("Ada item promo, item prasyarat tidak bisa dihapus", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Function
                End If
            End If


            Dim args As Object = New Object() {}
            Dim f As dlgConfirmYesNo = New dlgConfirmYesNo
            Dim result As Object

            Dim fmask As Form = uiTrnPosEN.CreateMask(0.75)
            fmask.Show(Me)
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            f.Message = "Hapus Data ?"
            result = f.OpenDialog(fmask, args)
            fmask.Close()
            fmask.Dispose()
            f.Dispose()
            If result IsNot Nothing Then
                Me.POS.ItemRemove(objItem)
            End If

        End If
        SuppressKeyPress = True
    End Function

    Private Function Key_F9(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        PaymentType_IndexSet(Me._KybShortcut_F9)
    End Function

    Private Function Key_F10(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        PaymentType_IndexSet(Me._KybShortcut_F10)
    End Function

    Private Function Key_F11(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        PaymentType_IndexSet(Me._KybShortcut_F11)
    End Function

    Private Function Key_F12(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        PaymentType_IndexSet(Me._KybShortcut_F12)
    End Function

    Private Function Key_B(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        Dim qty As Integer
        Dim vou01id As String = ""
        Dim vou01type As String = "BONUS"
        Dim vou01codenum As String = ""
        Dim vou01discp As Integer = 100
        Dim vou01method As String = "BONUS"

        If ctrl Then
            ' Bonus, price di nolkan
            Me.txtItemEntry.Text = ""
            If Me.DgvPOSItem.Rows.Count > 0 Then
                Dim currIndex As Integer = 0
                If Me.DgvPOSItem.CurrentRow IsNot Nothing Then
                    currIndex = Me.DgvPOSItem.CurrentRow.Index


                    Dim objItem As TransStore.POS.PosItemData = New TransStore.POS.PosItemData
                    objItem.iteminventory_article = Me.DgvPOSItem.CurrentRow.Cells("bondetil_article").Value
                    objItem.iteminventory_material = Me.DgvPOSItem.CurrentRow.Cells("bondetil_material").Value
                    objItem.iteminventory_color = Me.DgvPOSItem.CurrentRow.Cells("bondetil_color").Value
                    objItem.iteminventory_size = Me.DgvPOSItem.CurrentRow.Cells("bondetil_size").Value
                    objItem.region_id = Me.DgvPOSItem.CurrentRow.Cells("region_id").Value
                    objItem.rowindex = currIndex



                    ' Cek apakah sudah ada item ini yang di set sebagai bonus
                    Dim filter As String
                    Dim arrdr() As DataRow
                    filter = String.Format("bondetil_article='{0}' AND bondetil_material='{1}' AND bondetil_color='{2}' AND bondetil_size='{3}' AND region_id='{4}' AND bondetil_vou01type='BONUS'", objItem.iteminventory_article, objItem.iteminventory_material, objItem.iteminventory_color, objItem.iteminventory_size, objItem.region_id)
                    arrdr = Me.POS.PosItems.Select(filter)
                    If arrdr.Length > 0 Then
                        Exit Function
                    End If

                    Dim args As Object = New Object() {}
                    Dim f As dlgConfirmYesNo = New dlgConfirmYesNo
                    Dim result As Object

                    Dim fmask As Form = uiTrnPosEN.CreateMask(0.75)
                    fmask.Show(Me)
                    f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                    f.Message = "Set Article " & objItem.iteminventory_article & " sebagai bonus ?"
                    result = f.OpenDialog(fmask, args)
                    fmask.Close()
                    fmask.Dispose()
                    f.Dispose()
                    If result IsNot Nothing Then
                        Try
                            qty = CInt(Me.DgvPOSItem.CurrentRow.Cells("bondetil_qty").Value)
                            Me.DgvPOSItem.CurrentRow.Cells("bondetil_vou01type").Value = "BONUS"
                            Me.DgvPOSItem.CurrentRow.Cells("bondetil_vou01method").Value = "BONUS"
                            Me.POS.ItemEditToBonus(objItem, qty, vou01id, vou01type, vou01codenum, vou01discp, vou01method)
                            Me.POS.PosItems.AcceptChanges()
                            Me.DgvPOSItem.ReadOnly = False
                        Catch ex As Exception
                        End Try
                    End If

                End If
            End If

        End If
    End Function

    Private Function Key_G(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        If ctrl Then
            ' Bonus, price di nolkan
            Me.txtItemEntry.Text = ""
            If Me.DgvPOSItem.Rows.Count > 0 Then
                Dim currIndex As Integer = 0
                If Me.DgvPOSItem.CurrentRow IsNot Nothing Then
                    currIndex = Me.DgvPOSItem.CurrentRow.Index
                    Dim objItem As TransStore.POS.PosItemData = New TransStore.POS.PosItemData
                    objItem.iteminventory_article = Me.DgvPOSItem.CurrentRow.Cells("bondetil_article").Value
                    objItem.iteminventory_material = Me.DgvPOSItem.CurrentRow.Cells("bondetil_material").Value
                    objItem.iteminventory_color = Me.DgvPOSItem.CurrentRow.Cells("bondetil_color").Value
                    objItem.iteminventory_size = Me.DgvPOSItem.CurrentRow.Cells("bondetil_size").Value
                    objItem.region_id = Me.DgvPOSItem.CurrentRow.Cells("region_id").Value




                End If
            End If

        End If
    End Function

    Private Function Key_N(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        If ctrl Then
            ' Buat Transaksi Baru

            Dim args As Object = New Object() {}
            Dim f As dlgConfirmYesNo = New dlgConfirmYesNo
            Dim result As Object
            Dim fmask As Form = uiTrnPosEN.CreateMask(0.75)

            f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            f.Message = "Buat Transaksi Baru ?"
            fmask.Show(Me)
            result = f.OpenDialog(fmask, args)
            fmask.Close()
            fmask.Dispose()
            f.Dispose()
            If result IsNot Nothing Then
                Me.POS.NewTransaction()
            End If
        End If
    End Function

    Private Function Key_Back(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        If ctrl Then
            Me.txtItemEntry.Text = ""
            SuppressKeyPress = True
        End If
    End Function

#End Region

#Region " Listener "

    Public Function DgvPosItemReadOnlyState() As Boolean
        Me.DgvPOSItem.ReadOnly = True
        Me.DgvPOSItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        'Me.DgvPOSItem.DefaultCellStyle.SelectionBackColor = Color.DarkGray
    End Function

    Public Function Key(ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        Select Case keycode
            Case Keys.Escape
                Return Me.Key_Escape(Keys.KeyCode, ctrl, SuppressKeyPress)

            Case Keys.Up
                If ctrl Then
                    Return Me.Key_PageUp(Keys.KeyCode, ctrl, SuppressKeyPress)
                Else
                    Return Me.Key_ArrowUp(Keys.KeyCode, ctrl, SuppressKeyPress)
                End If

            Case Keys.Down
                If ctrl Then
                    Return Me.Key_PageUp(Keys.KeyCode, ctrl, SuppressKeyPress)
                Else
                    Return Me.Key_ArrowDown(Keys.KeyCode, ctrl, SuppressKeyPress)
                End If

            Case Keys.Enter
                Return Me.Key_Enter(Keys.KeyCode, ctrl, SuppressKeyPress)
            Case Keys.F1
                Return Me.Key_F1(Keys.KeyCode, ctrl, SuppressKeyPress)
            Case Keys.F3
                Return Me.Key_F3(Keys.KeyCode, ctrl, SuppressKeyPress)
            Case Keys.F4
                Return Me.Key_F4(Keys.KeyCode, ctrl, SuppressKeyPress)
            Case Keys.F6
                Return Me.Key_F6(Keys.KeyCode, ctrl, SuppressKeyPress)
            Case Keys.F7
                Return Me.Key_F7(Keys.KeyCode, ctrl, SuppressKeyPress)
            Case Keys.F8
                Return Me.Key_F8(Keys.KeyCode, ctrl, SuppressKeyPress)
            Case Keys.PageUp
                Return Me.Key_PageUp(Keys.KeyCode, ctrl, SuppressKeyPress)
            Case Keys.PageDown
                Return Me.Key_PageDown(Keys.KeyCode, ctrl, SuppressKeyPress)
            Case Keys.F9
                Return Me.Key_F9(Keys.KeyCode, ctrl, SuppressKeyPress)
            Case Keys.F10
                Return Me.Key_F10(Keys.KeyCode, ctrl, SuppressKeyPress)
            Case Keys.F11
                Return Me.Key_F11(Keys.KeyCode, ctrl, SuppressKeyPress)
            Case Keys.F12
                Return Me.Key_F12(Keys.KeyCode, ctrl, SuppressKeyPress)

            Case Keys.G
                Return Me.Key_G(Keys.KeyCode, ctrl, SuppressKeyPress)
            Case Keys.B
                Return Me.Key_B(Keys.KeyCode, ctrl, SuppressKeyPress)
            Case Keys.N
                Return Me.Key_N(Keys.KeyCode, ctrl, SuppressKeyPress)


            Case Keys.Back
                Return Me.Key_Back(Keys.KeyCode, ctrl, SuppressKeyPress)
        End Select

    End Function

#End Region

#Region " POS events "

    Private Sub POS_SelectUnknownSize(ByVal region_id As String, ByVal art As String, ByVal mat As String, ByVal col As String, ByVal descr As String, ByRef size As String, ByRef colname As String, ByRef sizetag As String) Handles POS.SelectUnknownSize

        Me.Refresh()
        Me.SuspendLayout()


        Dim tblSizing As DataTable = Me.POS.LoadSizing(region_id)
        Dim args As Object = New Object() {}
        Dim f As dlgConfirmSize = New dlgConfirmSize()
        Dim result As Object
        Dim fmask As Form = uiTrnPosEN.CreateMask(0.75)


        args = New Object() {art, mat, col, descr, tblSizing}

        fmask.SuspendLayout()
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.BeepOnOK = False
        fmask.Show(Me)
        result = f.OpenDialog(fmask, args)
        fmask.Close()
        fmask.Dispose()
        f.Dispose()
        f = Nothing

        If result IsNot Nothing Then
            size = CStr(result(0))
            sizetag = CStr(result(1))
            colname = CStr(result(2))
        End If

    End Sub

    Private Sub POS_ScanFindMoreThanOneItem(ByVal tbl As System.Data.DataTable, ByRef objItem As TransStore.POS.PosItemData, ByRef cancel As Boolean) Handles POS.ScanFindMoreThanOneItem
        Dim title As String = ""
        Dim id As String = ""
        Dim result As Object = Nothing
        Dim f As dlgItemSelect = New dlgItemSelect
        Dim args As Object = New Object() {title, id, tbl}

        Dim fmask As Form = uiTrnPosEN.CreateMask(0.75)
        fmask.Show(Me)
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        result = f.OpenDialog(fmask, args)
        fmask.Close()
        fmask.Dispose()
        f.Dispose()
        If result Is Nothing Then
            cancel = True
        Else
            objItem = result(0)
            Me.txtItemEntry.Text = ""
        End If

    End Sub

    Private Sub POS_ItemAdded(ByVal qty As Integer) Handles POS.ItemAdded
        uiTrnPosEN.BeepItemFound()
    End Sub

    Private Sub POS_ItemEdited(ByVal qty As Integer) Handles POS.ItemEdited
        uiTrnPosEN.BeepQtyEdit()
        Me.SkipCellEventEnter = False
    End Sub

    Public Sub POS_ItemModified(ByVal action As TransStore.POS.PosItemAction, ByVal id As String, ByVal itemname As String, ByVal article As String, ByVal color As String, ByVal size As String, ByVal material As String, ByVal price As Decimal, ByVal discount As Decimal, ByVal qty As Decimal, ByVal subtotal As Decimal, ByVal sum_qty As Decimal, ByVal sum_subtotal As Decimal, ByVal vou01type As String) Handles POS.ItemModified


        ' Me.SaatIniAdaPromoTerpakai = False

        Me.txtItemEntry.Text = ""
        Me.txtItemSelectedName.Text = id & "    " & itemname
        Me.txtItemSelectedQty.Text = "x" & qty
        Me.txtItemSelectedPrice.Text = String.Format("{0:#,##0}", CDec(price))
        Me.txtSubtotal.Text = String.Format("{0:#,##0}", CDec(sum_subtotal))
        Me.txtCount.Text = String.Format("{0:#,##0}", CDec(sum_qty))

        Me.POS_Display(id, itemname, Me.txtItemSelectedPrice.Text, Me.txtCount.Text, Me.txtSubtotal.Text)


        If action <> TransStore.POS.PosItemAction.Remove Then
            If Me.DgvPOSItem.Rows.Count <= 0 Then
                Exit Sub
            End If

            Dim i As Integer
            Dim RowFound As Boolean

            For i = 0 To Me.DgvPOSItem.Rows.Count - 1
                If vou01type = "BONUS" Then
                    RowFound = Me.DgvPOSItem.Rows(i).Cells("bondetil_item").Value = id And Me.DgvPOSItem.Rows(i).Cells("bondetil_size").Value = size And Me.DgvPOSItem.Rows(i).Cells("bondetil_vou01type").Value = "BONUS"
                Else
                    RowFound = Me.DgvPOSItem.Rows(i).Cells("bondetil_item").Value = id And Me.DgvPOSItem.Rows(i).Cells("bondetil_size").Value = size And Me.DgvPOSItem.Rows(i).Cells("bondetil_vou01type").Value = vou01type
                End If

                If RowFound Then
                    Try
                        Me.DgvPOSItem.CurrentCell = Me.DgvPOSItem.Rows(i).Cells(0)
                        Me.DgvPOSItem.FirstDisplayedCell = Me.DgvPOSItem.CurrentCell
                        Exit For
                    Catch ex As Exception
                        Throw ex
                    End Try
                End If
            Next
        Else
            Me.objErrProvItemNotFound.SetIconAlignment(Me.txtItemSelectedName, ErrorIconAlignment.MiddleLeft)
            Me.objErrProvItemNotFound.SetError(Me.txtItemSelectedName, "REMOVED: " & id & "    " & itemname)
            Me.txtItemSelectedName.Text = "REMOVED: " & id & "    " & itemname
            Me.txtItemSelectedQty.Text = ""
            Me.txtItemSelectedPrice.Text = ""

        End If



        ' Calculate Items
        Me.RecalculateTotal()

        ' Calculate Promo
        Dim ci As PosPromo.CustomerInfo = Me.getCurrentCustomerInfo()
        Me.POS.PosPromo.CalculateCurrentActivePromo(ci)

        Me.POS_SecondMonitorDisplaySyncValue()


    End Sub



    Public Sub POS_SecondMonitorDisplaySyncValue()
        ' Set Display
        Dim tblitem As DataTable = CType(Me.DgvPOSItem.DataSource, DataTable)

        If tblitem Is Nothing Then
            Exit Sub
        End If


        Dim totalvalue As Decimal = 0
        Dim pospayment_disc As Integer = CDec(Me.POS.PaymentType.Rows(Me.PaymentTypeIndex).Item("pospayment_disc").ToString)
        Dim sumsubtotal As Object = tblitem.Compute("Sum(bondetil_subtotal)", "")

        If sumsubtotal Is DBNull.Value Then
            sumsubtotal = 0
            pospayment_disc = 0
            totalvalue = 0
        Else
            pospayment_disc = sumsubtotal * (pospayment_disc / 100)
            totalvalue = sumsubtotal - pospayment_disc
        End If
        Me.POS.SecondDisplay.SetTotal(sumsubtotal, pospayment_disc, totalvalue)

    End Sub


    Public Sub POS_Display(ByVal id As String, ByVal itemname As String, ByVal price As String, ByVal qty As String, ByVal subtotal As String)
        ' Set Display
        ' |..........|.........|
        ' |LOLY           3,500|
        ' |25 item    5,600,000|  
        Dim line1 As String = itemname
        Dim line2 As String = "SUBTTL " & String.Format("Rp {0:#,##0}", subtotal).PadLeft(12, " ")

        If Me.POS.POLE_PORT <> "" Then
            POLEDISPLAY.Write(Me.POS.POLE_PORT, line1, line2)
        End If

    End Sub

    Public Sub POS_TransactionCleared() Handles POS.TransactionCleared
        Me.txtItemSelectedName.Text = ""
        Me.txtItemSelectedQty.Text = ""
        Me.txtItemSelectedPrice.Text = ""
        Me.txtSubtotal.Text = "0"
        Me.txtCount.Text = "0"
        Me.Refresh()
    End Sub

    Public Sub POS_TransactionCreated() Handles POS.TransactionCreated
        Me.txtItemSelectedName.Text = ""
        Me.txtItemSelectedQty.Text = ""
        Me.txtItemSelectedPrice.Text = ""
        Me.txtSubtotal.Text = "0"
        Me.txtCount.Text = "0"

        Me.RecalculateTotal()
        Me.POS.BolehDiscPayment = True
        Me.POS.SecondDisplay.SetTotal(0, 0, 0)

    End Sub

    Public Sub POS_TransactionCreating() Handles POS.TransactionCreating

        Me.Refresh()

        Dim args As Object = New Object() {}
        Dim f As dlgTrnPosNew = New dlgTrnPosNew
        Dim result As Object
        Dim fmask As Form = uiTrnPosEN.CreateMask(0.75)

        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        Dim objParamValue As TransStore.PosNewTransactionParamValue = New TransStore.PosNewTransactionParamValue
        With objParamValue
            .POS = Me.POS
        End With
        args = New Object() {objParamValue}

        fmask.Show(Me)
        result = f.OpenDialog(fmask, args)
        fmask.Close()
        fmask.Dispose()
        f.Dispose()

        If result Is Nothing Then
            Me.Hide()
        Else

            Me.Refresh()
            Me.SuspendLayout()

            Dim tempFlowVis As Boolean = Me.FlowLayoutPanel1.Visible

            Me.FlowLayoutPanel1.Visible = True
            ' Data awal transaksi sudah tersedia
            Dim ReturnValue As TransStore.PosNewTransactionReturnValue = New TransStore.PosNewTransactionReturnValue
            ReturnValue = CType(result(0), TransStore.PosNewTransactionReturnValue)
            With ReturnValue
                Me.objSiteIdFrom.Text = .SiteIdFrom
                Me.objCustomerNationalityId.Text = .CustomerNationalityId
                Me.objCustomerNationalityName.Text = .CustomerNationalityName
                Me.objCustomerGenderId.Text = .CustomerGenderId
                Me.objCustomerGenderName.Text = .CustomerGenderName
                Me.objCustomerAgeId.Text = .CustomerAgeId
                Me.objCustomerAgeName.Text = .CustomerAgeName
                Me.objCustomerId.Text = .CustomerId
                Me.objCustomerName.Text = .CustomerName
                Me.objCustomerNPWP.Text = .CustomerNPWP
                Me.objCustomerTelp.Text = .CustomerTelp
                Me.objVoucher01Id.Text = .Voucher01Id
                Me.objVoucher01Name.Text = .Voucher01Name
                Me.objVoucher01CodeNum.Text = .Voucher01CodeNum
                Me.objVoucher01Disc.Text = .Voucher01Disc
                Me.objVoucher01Type.Text = .Voucher01Type
                Me.objVoucher01Method.Text = .Voucher01Method
                Me.objSalesId.Text = .SalesId
                Me.objSalesName.Text = .SalesName
                Me.objCustomerDisc.Text = .CustomerDisc
                Me.objCustomerPassport.Text = .CustomerPassport
                Me.objCustomerType.Text = .CustomerType
                Me.objVoucherInformation.Text = .Voucher01Name
                Me.objBonExternal.Text = .BonExternal
                Me.objBonEvent.Text = .BonEvent
            End With

            Me.FlowLayoutPanel1.Visible = tempFlowVis


            Me.ResumeLayout()

            Try
                POLEDISPLAY.Write(Me.POS.POLE_PORT, "New Transaction", "")
            Catch ex As Exception
            End Try

        End If
    End Sub



    Public Sub RecalculateTotal()
        Dim tblitem As DataTable = CType(Me.DgvPOSItem.DataSource, DataTable)
        If tblitem IsNot Nothing Then
            Dim totalvalue As Decimal = 0
            Dim pospayment_disc As Integer = CDec(Me.POS.PaymentType.Rows(Me.PaymentTypeIndex).Item("pospayment_disc").ToString)
            Dim sumsubtotal As Object = tblitem.Compute("Sum(bondetil_subtotal)", "")

            If sumsubtotal Is DBNull.Value Then
                sumsubtotal = 0
                pospayment_disc = 0
                totalvalue = 0
            Else
                pospayment_disc = sumsubtotal * (pospayment_disc / 100)
                totalvalue = sumsubtotal - pospayment_disc
            End If

            Me.POS.PosPromo.CURRENT_SUBTOTAL = sumsubtotal
            Me.POS.PosPromo.CURRENT_DISCOUNT = pospayment_disc
            Me.POS.PosPromo.CURRENT_TOTAL = totalvalue

        End If
    End Sub


#End Region


#Region " Deprecated PromoModel "

    Private Function SetPromo_Voucher(ByVal promoargs As PromoArguments) As Boolean
        Dim PromoItem As DataTable = CType(Me.DgvPOSItem.DataSource, DataTable).Copy()

        ' Buy 2 or more disc 30%
        Dim disc_A_threshold As Integer = promoargs.qty_threshold_A
        Dim disc_A_percent As Decimal = promoargs.percent_discount_A
        Dim disc_A = disc_A_percent / 100

        Dim disc_B_threshold As Integer = promoargs.qty_threshold_B
        Dim disc_B_percent As Decimal = promoargs.percent_discount_B
        Dim disc_B = disc_B_percent / 100

        Dim payment_disc_Allowed = promoargs.payment_disc_Allowed  ' Apakah diperbolehkan tambahan disc payment lagi ?


        Dim startdate As Date = promoargs.startdate
        Dim enddate As Date = promoargs.enddate

        If (Now.Date >= startdate And Now.Date <= enddate) Then
        Else
            ' Kalau tanggal tidak cocok
            Exit Function
        End If

        Dim dr() As DataRow = {}

        Dim dr2_A() As DataRow = {}
        Dim dr2_B() As DataRow = {}


        ' Cek data basket apakah ada di list promo
        Dim nA As Integer = 0
        Dim nB As Integer = 0


        ' Me.POS.PromoApplied = False



        Dim dtitem As DataTable = Me.DgvPOSItem.DataSource
        For Each rowbasket As DataRow In dtitem.Rows
            Dim heinv_id = rowbasket("heinv_id")
            Dim qty As Integer = rowbasket("bondetil_qty")

            Dim ada_di_listpromo_A As Boolean = False
            Dim ada_di_listpromo_B As Boolean = False

            Dim dr_promoexist_A() As DataRow = PromoItem.Select(String.Format("heinv_id='{0}' AND bondetil_pricenettstd01<>0 ", heinv_id))
            Dim dr_promoexist_B() As DataRow = PromoItem.Select(String.Format("heinv_id='{0}' AND bondetil_pricenettstd01<>0 ", heinv_id))

            If dr_promoexist_A.Length > 0 Then
                ada_di_listpromo_A = True
            End If


            If dr_promoexist_B.Length > 0 Then
                ada_di_listpromo_B = True
            End If

            If ada_di_listpromo_A Then
                nA = nA + qty

                'Tambahkan ke dr, barang2 yang masuk kategori
                Array.Resize(dr, dr.Length + 1)
                dr(dr.Length - 1) = rowbasket

                Array.Resize(dr2_A, dr2_A.Length + 1)
                dr2_A(dr2_A.Length - 1) = rowbasket

            End If

            If ada_di_listpromo_B Then
                nB = nB + qty

                'Tambahkan ke dr, barang2 yang masuk kategori
                Array.Resize(dr, dr.Length + 1)
                dr(dr.Length - 1) = rowbasket

                Array.Resize(dr2_B, dr2_B.Length + 1)
                dr2_B(dr2_B.Length - 1) = rowbasket

            End If
        Next


        'Normalkan dulu discount yang masuk di list
        For Each row As DataRow In dr
            Dim bondetil_qty As Integer = row("bondetil_qty")
            Dim bondetil_pricegross As Decimal = row("bondetil_pricegross")
            Dim bondetil_discpstd01 As Decimal = row("bondetil_discpstd01")
            Dim bondetil_discrstd01 As Decimal = row("bondetil_discrstd01")
            Dim bondetil_pricenettstd01 As Decimal = row("bondetil_pricenettstd01") 'bondetil_pricegross
            Dim bondetil_discpvou01 As Decimal = 0
            Dim bondetil_discrvou01 As Decimal
            Dim bondetil_pricenettvou01 As Decimal


            Dim pricing_disc = row("pricing_disc")

            ' Normalkan Harga
            bondetil_discpstd01 = pricing_disc
            bondetil_discrstd01 = (pricing_disc / 100) * bondetil_pricegross
            bondetil_pricenettstd01 = bondetil_pricegross - bondetil_discrstd01
            bondetil_discpvou01 = 0
            bondetil_discrvou01 = 0
            bondetil_pricenettvou01 = bondetil_pricenettstd01

            Dim bondetil_pricenet As Decimal = bondetil_pricenettstd01
            Dim bondetil_subtotal As Decimal = bondetil_qty * bondetil_pricenet

            row("bondetil_discpstd01") = bondetil_discpstd01
            row("bondetil_discrstd01") = bondetil_discrstd01
            row("bondetil_pricenettstd01") = bondetil_pricenettstd01
            row("bondetil_vou01type") = ""
            row("bondetil_vou01method") = ""
            row("bondetil_discpvou01") = bondetil_discpvou01
            row("bondetil_discrvou01") = bondetil_discrvou01
            row("bondetil_pricenettvou01") = bondetil_pricenettvou01
            row("bondetil_pricenet") = bondetil_pricenet
            row("bondetil_subtotal") = bondetil_subtotal

        Next



        Dim SaatIniBolehDiscPayment As Boolean = Me.POS.BolehDiscPayment

        'If dr.Length >= disc_20_threshold Or n >= disc_20_threshold Then
        If nA >= disc_A_threshold Then
            Dim i As Integer = 0
            For Each row As DataRow In dr2_A
                ' LEveling Discount
                Dim pricing_disc = row("pricing_disc")


                Dim disc_additional = 0
                disc_additional = IIf(nA >= disc_A_threshold, disc_A, 0)

                i = i + 1
                If promoargs.ForSecondItem_A Then
                    If i Mod 2 <> 0 Then
                        Continue For
                    End If
                End If


                Dim bondetil_qty As Integer = row("bondetil_qty")
                Dim bondetil_pricegross As Decimal = row("bondetil_pricegross")
                Dim bondetil_discpstd01 As Decimal = row("bondetil_discpstd01")
                Dim bondetil_discrstd01 As Decimal = row("bondetil_discrstd01")
                Dim bondetil_pricenettstd01 As Decimal = row("bondetil_pricenettstd01") 'bondetil_pricegross
                Dim bondetil_discpvou01 As Decimal = 0
                Dim bondetil_discrvou01 As Decimal
                Dim bondetil_pricenettvou01 As Decimal



                If promoargs.replace_discount_A Then
                    ' Pricing standart
                    bondetil_discpstd01 = pricing_disc
                    bondetil_discrstd01 = (pricing_disc / 100) * bondetil_pricegross
                    bondetil_pricenettstd01 = bondetil_pricegross - bondetil_discrstd01
                    ' Replace Pricing
                    bondetil_discpvou01 = disc_additional * 100
                    bondetil_discrvou01 = disc_additional * bondetil_pricegross
                    bondetil_pricenettvou01 = bondetil_pricegross - bondetil_discrvou01

                Else
                    ' Pricing discount bertingkat
                    bondetil_discpstd01 = pricing_disc
                    bondetil_discrstd01 = (pricing_disc / 100) * bondetil_pricegross
                    bondetil_pricenettstd01 = bondetil_pricegross - bondetil_discrstd01
                    bondetil_discpvou01 = disc_additional * 100
                    bondetil_discrvou01 = disc_additional * bondetil_pricenettstd01
                    bondetil_pricenettvou01 = bondetil_pricenettstd01 - bondetil_discrvou01

                End If




                Dim bondetil_pricenet As Decimal = bondetil_pricenettvou01
                Dim bondetil_subtotal As Decimal = bondetil_qty * bondetil_pricenet

                row("bondetil_discpstd01") = bondetil_discpstd01
                row("bondetil_discrstd01") = bondetil_discrstd01
                row("bondetil_pricenettstd01") = bondetil_pricenettstd01
                row("bondetil_vou01type") = "BUNDL-02"
                row("bondetil_vou01method") = "ALL"
                row("bondetil_discpvou01") = bondetil_discpvou01
                row("bondetil_discrvou01") = bondetil_discrvou01
                row("bondetil_pricenettvou01") = bondetil_pricenettvou01
                row("bondetil_pricenet") = bondetil_pricenet
                row("bondetil_subtotal") = bondetil_subtotal

            Next

            Me.POS.PromoApplied = Me.POS.PromoApplied Or True
            If Not payment_disc_Allowed Then
                Me.POS.BolehDiscPayment = False
            Else
                Me.POS.BolehDiscPayment = True
            End If

        Else

            Me.POS.PromoApplied = Me.POS.PromoApplied Or False
            SaatIniBolehDiscPayment = True
            Me.POS.BolehDiscPayment = True
        End If


        If nB >= disc_B_threshold Then
            Dim i As Integer = 0
            For Each row As DataRow In dr2_B
                ' LEveling Discount
                Dim pricing_disc = row("pricing_disc")


                Dim disc_additional = 0
                disc_additional = IIf(nB >= disc_B_threshold, disc_B, 0)

                i = i + 1
                If promoargs.ForSecondItem_B Then
                    If i Mod 2 <> 0 Then
                        Continue For
                    End If
                End If


                Dim bondetil_qty As Integer = row("bondetil_qty")
                Dim bondetil_pricegross As Decimal = row("bondetil_pricegross")
                Dim bondetil_discpstd01 As Decimal = row("bondetil_discpstd01")
                Dim bondetil_discrstd01 As Decimal = row("bondetil_discrstd01")
                Dim bondetil_pricenettstd01 As Decimal = row("bondetil_pricenettstd01") 'bondetil_pricegross
                Dim bondetil_discpvou01 As Decimal = 0
                Dim bondetil_discrvou01 As Decimal
                Dim bondetil_pricenettvou01 As Decimal


                If promoargs.replace_discount_B Then
                    ' Pricing standart
                    bondetil_discpstd01 = pricing_disc
                    bondetil_discrstd01 = (pricing_disc / 100) * bondetil_pricegross
                    bondetil_pricenettstd01 = bondetil_pricegross - bondetil_discrstd01
                    ' Replace Pricing
                    bondetil_discpvou01 = disc_additional * 100
                    bondetil_discrvou01 = disc_additional * bondetil_pricegross
                    bondetil_pricenettvou01 = bondetil_pricegross - bondetil_discrvou01
                Else
                    ' Discount bertingkat
                    ' Pricing standart
                    bondetil_discpstd01 = pricing_disc
                    bondetil_discrstd01 = (pricing_disc / 100) * bondetil_pricegross
                    bondetil_pricenettstd01 = bondetil_pricegross - bondetil_discrstd01
                    ' Tambahan Discount
                    bondetil_discpvou01 = disc_additional * 100
                    bondetil_discrvou01 = disc_additional * bondetil_pricenettstd01
                    bondetil_pricenettvou01 = bondetil_pricenettstd01 - bondetil_discrvou01
                End If




                Dim bondetil_pricenet As Decimal = bondetil_pricenettvou01
                Dim bondetil_subtotal As Decimal = bondetil_qty * bondetil_pricenet

                row("bondetil_discpstd01") = bondetil_discpstd01
                row("bondetil_discrstd01") = bondetil_discrstd01
                row("bondetil_pricenettstd01") = bondetil_pricenettstd01
                row("bondetil_vou01type") = "BUNDL-02"
                row("bondetil_vou01method") = "ALL"
                row("bondetil_discpvou01") = bondetil_discpvou01
                row("bondetil_discrvou01") = bondetil_discrvou01
                row("bondetil_pricenettvou01") = bondetil_pricenettvou01
                row("bondetil_pricenet") = bondetil_pricenet
                row("bondetil_subtotal") = bondetil_subtotal

            Next

            Me.POS.PromoApplied = Me.POS.PromoApplied Or True
            If Not payment_disc_Allowed Then
                Me.POS.BolehDiscPayment = False
            Else
                Me.POS.BolehDiscPayment = True
            End If

        Else
            Me.POS.PromoApplied = Me.POS.PromoApplied Or False
            SaatIniBolehDiscPayment = True
            Me.POS.BolehDiscPayment = True
        End If



        Me.POS.BolehDiscPayment = Me.POS.BolehDiscPayment And SaatIniBolehDiscPayment
        If (Me.POS.BolehDiscPayment) Then
            Me.POS.AllowedPaymenttype = promoargs.paymenttype_allowed
        Else
            Me.POS.AllowedPaymenttype = Nothing
        End If


        Me.POS.PosItems.AcceptChanges()

        Dim sum_qty = Me.POS.Count
        Dim sum_subtotal = Me.POS.Subtotal

        Me.txtSubtotal.Text = String.Format("{0:#,##0}", CDec(sum_subtotal))
        Me.txtCount.Text = String.Format("{0:#,##0}", CDec(sum_qty))

    End Function

#End Region




    Public Function getCurrentCustomerInfo() As PosPromo.CustomerInfo
        Dim ci As New PosPromo.CustomerInfo()
        ci.Id = Me.objCustomerId.Text
        ci.Nama = Me.objCustomerName.Text
        ci.IsMember = Me.objCustomerType.Text = "MPC" And Me.objCustomerNPWP.Text <> "" ' MdcId <-- objCustomerNPWP
        Return ci
    End Function


    Private Sub dlgTrnPosEN_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.ReShown Then
            Me.ReShown = False
            If Loaded Then
                If Me.DgvPOSItem.RowCount = 0 Then
                    Me.POS.NewTransaction()
                End If
            End If
        End If
    End Sub



    Private Sub dlgTrnPosEN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TransStore.POS.InstanceNumerator = 0
        startInfo = New ProcessStartInfo()


        Dim obj As Control
        For Each obj In Me.Controls
            If obj.Name <> Me.PnlPosMain.Name Then
                Me.Controls.Remove(obj)
            End If
        Next

        Me.Text = "POS"
        Me.objPosCompanyName.Text = Me.POS.COMPANY_NAME
        Me.ShowInTaskbar = True

        Me.txtItemSelectedName.BorderStyle = BorderStyle.None
        Me.txtItemSelectedQty.BorderStyle = BorderStyle.None
        Me.txtItemSelectedPrice.BorderStyle = BorderStyle.None
        Me.txtItemSelectedName.Text = ""
        Me.txtItemSelectedQty.Text = ""
        Me.txtItemSelectedPrice.Text = ""
        Me.txtSubtotal.Text = "0"
        Me.txtCount.Text = "0"

        Me.PaymentType_Change()
        Me.PaymentType_GetShortcut()



        Me.objPosOperator.Text = Me.POS.UserName
        Me.objPosMachineID.Text = Me.POS.MachineId
        Me.objPosEventName.Text = Me.POS.Event
        Me.objPosDate.Text = Me.POS.GetDateString()


        With Me.DgvPOSItem
            .DataSource = Me.POS.PosItems
            .ReadOnly = True
            .TabStop = False
            .Anchor = AnchorStyles.Top + AnchorStyles.Bottom + AnchorStyles.Left + AnchorStyles.Right
        End With

        Me.SuspendLayout()



        Me.lineItemDisplay.BackColor = Color.DarkGray
        'Me.BackgroundImage = My.Resources.tbbg
        Me.BackColor = Color.DarkGray

        Me.PnlPosMain.Dock = DockStyle.Fill
        Me.PnlPosMainCenter.Dock = DockStyle.Fill
        Me.DgvPOSItem.Dock = DockStyle.Fill
        Me.DgvPOSItem.BorderStyle = BorderStyle.None

        Me.PnlPosMainH.BackgroundImageLayout = ImageLayout.Stretch
        Me.PnlPosMainCenter.BackgroundImageLayout = ImageLayout.Stretch
        Me.PnlPosMainF.BackgroundImageLayout = ImageLayout.Stretch

        'Dipindah ke size Changed
        'Me.PnlPosMainH.BackgroundImage = My.Resources.tbbg
        'Me.PnlPosMainCenter.BackgroundImage = My.Resources.tbbg3
        Me.PnlPosMainCenter.BorderStyle = BorderStyle.None
        'Me.PnlPosMainF.BackgroundImage = My.Resources.tbbg4

        Me.txtItemEntry.BackColor = Color.FromArgb(161, 161, 161)
        Me.lineItemDisplay.BackColor = Color.FromArgb(161, 161, 161)

        Me.lblQuantity.ForeColor = Color.FromArgb(78, 78, 78)
        Me.lineSubtotal.BackColor = Color.FromArgb(100, 100, 100)
        Me.lineQuantity.BackColor = Color.FromArgb(100, 100, 100)

        Me.txtSubtotal.ForeColor = Color.FromArgb(32, 44, 102)
        Me.txtCount.ForeColor = Color.FromArgb(32, 44, 102)


        Me.lblLocationStatus.Text = Me.POS.STATUS
        Me.lblLocationStatus.AutoSize = True
        Me.lblLocationStatus.Refresh()


        uiTrnPosEN.FormatDgvPOSItem(Me.DgvPOSItem)


        ' Me.FlowLayoutPanel1.Visible = StatusVisible
        Me.Refresh()
        Me.ResumeLayout()

        'Me.txtItemEntry.Enabled = False
        'Me.DgvPOSItem.Enabled = False



        Me.POS.NewTransaction()
        Me.Refresh()


        'Me.objVoucher01Disc.Text = "20"

        Me.ConsumableGoodPrefixCode = Me.POS.CONSGOOD_CODE

        Me.POS.SecondDisplay.SetGridDataSource(CType(Me.DgvPOSItem.DataSource, DataTable))

        Me.CurrentRegionId = Me.POS.RegionId
        Me.CurrentBranchId = Me.POS.BranchId
        Me.SetRegionBranchDevelopment()


        ' READ AVAILABLE PROMO
        Me.POS.PosPromo.setPOS(Me.POS)
        Me.POS.PosPromo.setTrnPOSEN(Me)
        Me.POS.PosPromo.setItemGrid(Me.DgvPOSItem)
        Me.POS.PosPromo.InitializeActivePromo(Me.CurrentRegionId, Me.CurrentBranchId)
        Me.txt_INFO.Text = ""
        For Each pd As PosPromoData In Me.POS.PosPromo.CurrentActivePromo
            Me.txt_INFO.Text &= pd.Descr & vbCrLf
        Next

        Me.Loaded = True
    End Sub



    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()
    End Sub



    Private Sub txtItemEntry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemEntry.KeyDown
        Dim SuppressKeyPress As Boolean = False
        Key(e.KeyCode, e.Control, SuppressKeyPress)
        e.SuppressKeyPress = SuppressKeyPress
    End Sub



    Private Sub DgvPOSItem_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvPOSItem.CellClick
        Dim SuppressKeyPress As Boolean = False
        Me.DgvPOSItem.ReadOnly = False
        Me.Key(Keys.F3, False, SuppressKeyPress)
        Me.txtItemEntry.Focus()
    End Sub

    Private Sub DgvPOSItem_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvPOSItem.CellDoubleClick
        Dim SuppressKeyPress As Boolean = False
        Dim colname = Me.DgvPOSItem.Columns(e.ColumnIndex).Name

        If colname = "displayed_qty" Then
            If Me.DgvPOSItem.ReadOnly Then
                Me.Key(Keys.F3, False, SuppressKeyPress)
            End If
        Else
            Me.txtItemEntry.Focus()
        End If
    End Sub

    Private Sub DgvPOSItem_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvPOSItem.CellEndEdit
        If Me.SkipCellEvent Then
            Exit Sub
        End If

        If Not Me.DgvPOSItem.ReadOnly Then
            ' Dim id As String = Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_item").Value
            Dim SuppressKeyPress As Boolean = False
            Dim objItem As TransStore.POS.PosItemData = New TransStore.POS.PosItemData
            Dim qty As Integer

            objItem.iteminventory_article = Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_article").Value
            objItem.iteminventory_material = Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_material").Value
            objItem.iteminventory_color = Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_color").Value
            objItem.iteminventory_size = Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_size").Value
            objItem.region_id = Me.DgvPOSItem.Rows(e.RowIndex).Cells("region_id").Value

            Try
                If Me.DgvPOSItem.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is Nothing Then
                    Exit Try
                End If
                qty = CInt(Me.DgvPOSItem.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                objItem.editingQty = True
                objItem.rowindex = e.RowIndex
                Me.POS.ItemEdit(objItem, qty)
                Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_qty").Value = qty
                Me.POS.PosItems.AcceptChanges()
                Me.DgvPOSItem.ReadOnly = False
            Catch ex As Exception
            End Try

            Me.DgvPOSItem.CurrentCell.Style.BackColor = Color.Gainsboro
            Me.Key(Keys.F3, False, SuppressKeyPress)
            Me.txtItemEntry.Focus()
        End If
    End Sub

    Private Sub DgvPOSItem_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvPOSItem.CellEnter
        If Me.SkipCellEvent Or Me.SkipCellEventEnter Then
            Exit Sub
        End If



        Dim colname As String = Me.DgvPOSItem.Columns(e.ColumnIndex).Name
        Dim settoreadonly As Boolean = False
        'Dim currcell As DataGridViewCell

        If Me.LastRowIndex <> e.RowIndex Then
            If Me.DgvPOSItem.ReadOnly = False Then
                settoreadonly = True
            End If
        Else
            If Me.DgvPOSItem.ReadOnly = False Then
                If colname <> "displayed_qty" Then
                    settoreadonly = True
                End If
            Else
                settoreadonly = True
            End If
        End If

        If settoreadonly Then
            Me.DgvPosItemReadOnlyState()
            Me.DgvPOSItem.CurrentRow.Selected = True
            Me.DgvPOSItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Me.txtItemEntry.Focus()

        End If

    End Sub

    Private Sub DgvPOSItem_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvPOSItem.CellFormatting
        Dim dgv As DataGridView = CType(sender, DataGridView)
        Dim colname As String = dgv.Columns(e.ColumnIndex).Name
        Dim vou01type As String
        Dim vou01method As String
        Dim rowcol, rowcol_selected, rowcol_normal, rowcol_normal_selected, rowcol_zero, rowcol_zero_selected, rowcol_bonus, rowcol_bonus_selected, rowcol_minus, rowcol_minus_selected, rowcol_cg, rowcol_cg_selected As System.Drawing.Color
        Dim subtotal As Decimal
        Dim artpref As String


        'col = Color.FromArgb(209, 181, 225)
        rowcol_normal = Color.Gainsboro
        rowcol_normal_selected = Color.DarkGray
        rowcol_zero = Color.Red
        rowcol_zero_selected = Color.DarkRed
        rowcol_bonus = Color.LightBlue
        rowcol_bonus_selected = Color.Teal
        rowcol_minus = Color.Yellow
        rowcol_minus_selected = Color.Gold
        rowcol_cg = Color.SandyBrown
        rowcol_cg_selected = Color.Peru

        'Ubah warna background
        vou01type = dgv.Rows(e.RowIndex).Cells("bondetil_vou01type").Value
        vou01method = dgv.Rows(e.RowIndex).Cells("bondetil_vou01method").Value
        subtotal = CDec(dgv.Rows(e.RowIndex).Cells("bondetil_subtotal").Value)
        artpref = Mid(dgv.Rows(e.RowIndex).Cells("bondetil_article").Value, 1, Len(ConsumableGoodPrefixCode))

        subtotal = CDec(dgv.Rows(e.RowIndex).Cells("bondetil_subtotal").Value)


        ' untuk consumable
        ' artpref = TM05.CON.xx

        If vou01type = "BONUS" Then
            If dgv.Rows(e.RowIndex).Selected Then
                dgv.DefaultCellStyle.SelectionBackColor = rowcol_bonus_selected
                dgv.DefaultCellStyle.SelectionForeColor = Color.Black
            Else
                dgv.Rows(e.RowIndex).Cells("displayed_id").Style.BackColor = rowcol_bonus
                dgv.Rows(e.RowIndex).Cells("displayed_descr").Style.BackColor = rowcol_bonus
                dgv.Rows(e.RowIndex).Cells("displayed_net").Style.BackColor = rowcol_bonus
                dgv.Rows(e.RowIndex).Cells("displayed_qty").Style.BackColor = rowcol_bonus
                dgv.Rows(e.RowIndex).Cells("displayed_subtotal").Style.BackColor = rowcol_bonus
            End If
        Else
            If subtotal < 0 Then
                If dgv.Rows(e.RowIndex).Selected Then
                    dgv.DefaultCellStyle.SelectionBackColor = rowcol_minus_selected
                    dgv.DefaultCellStyle.SelectionForeColor = Color.Black
                Else
                    dgv.Rows(e.RowIndex).Cells("displayed_id").Style.BackColor = rowcol_minus
                    dgv.Rows(e.RowIndex).Cells("displayed_descr").Style.BackColor = rowcol_minus
                    dgv.Rows(e.RowIndex).Cells("displayed_net").Style.BackColor = rowcol_minus
                    dgv.Rows(e.RowIndex).Cells("displayed_qty").Style.BackColor = rowcol_minus
                    dgv.Rows(e.RowIndex).Cells("displayed_subtotal").Style.BackColor = rowcol_minus
                End If
            ElseIf subtotal = 0 Then
                If artpref = Me.ConsumableGoodPrefixCode Then
                    rowcol = rowcol_cg
                    rowcol_selected = rowcol_cg_selected
                Else
                    rowcol = rowcol_zero
                    rowcol_selected = rowcol_zero_selected
                End If

                If dgv.Rows(e.RowIndex).Selected Then
                    dgv.DefaultCellStyle.SelectionBackColor = rowcol_selected
                    dgv.DefaultCellStyle.SelectionForeColor = Color.White
                Else
                    dgv.Rows(e.RowIndex).Cells("displayed_id").Style.BackColor = rowcol
                    dgv.Rows(e.RowIndex).Cells("displayed_descr").Style.BackColor = rowcol
                    dgv.Rows(e.RowIndex).Cells("displayed_net").Style.BackColor = rowcol
                    dgv.Rows(e.RowIndex).Cells("displayed_qty").Style.BackColor = rowcol
                    dgv.Rows(e.RowIndex).Cells("displayed_subtotal").Style.BackColor = rowcol
                End If
            Else
                If dgv.Rows(e.RowIndex).Selected Then
                    dgv.DefaultCellStyle.SelectionBackColor = rowcol_normal_selected
                    dgv.DefaultCellStyle.SelectionForeColor = Color.Black
                Else
                    dgv.Rows(e.RowIndex).Cells("displayed_id").Style.BackColor = rowcol_normal
                    dgv.Rows(e.RowIndex).Cells("displayed_descr").Style.BackColor = rowcol_normal
                    dgv.Rows(e.RowIndex).Cells("displayed_net").Style.BackColor = rowcol_normal
                    dgv.Rows(e.RowIndex).Cells("displayed_qty").Style.BackColor = rowcol_normal
                    dgv.Rows(e.RowIndex).Cells("displayed_subtotal").Style.BackColor = rowcol_normal
                End If
            End If
        End If




        'Me.DgvPOSItem.Rows(e.RowIndex).Height = 48
        Select Case colname
            Case "displayed_id"
                e.Value = Me.DgvPOSItem.Rows(e.RowIndex).Cells("bondetil_item").Value
            Case "displayed_descr"
                Dim name, art, mat, col, size, region As String
                Dim price, discpstd01, discrstd01, discpvou01, discrvou01 As Decimal
                Dim pricerule As String
                Dim issp As Boolean



                Try
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
                    pricerule = dgv.Rows(e.RowIndex).Cells("bondetil_rule").Value
                    issp = dgv.Rows(e.RowIndex).Cells("pricing_issp").Value


                   


                    e.Value = art.PadRight(10) & "   " & mat.PadRight(5) & "  " & col.PadRight(5) & "  " & size.PadRight(5) & vbCrLf & _
                              name & ", " & region & vbCrLf & _
                              "      Rp " & String.Format("{0:#,##0}", price).ToString.PadLeft(12, " ")



                    If discpstd01 > 0 Then
                        If (pricerule <> "01") Then
                            e.Value &= "     (PROMO Disc " & String.Format("{0:#,##0}", discpstd01) & "%)"
                        Else
                            e.Value &= "     (Disc " & String.Format("{0:#,##0}", discpstd01) & "%)"
                        End If
                    Else
                        If (issp = True) Then
                            e.Value &= "     SPECIAL PRICE "
                        End If
                    End If


                Catch ex As Exception
                End Try





                If vou01type = "BONUS" Then
                    e.Value &= " ( BONUS! )"
                Else
                    'If discrvou01 > 0 Then

                    '    Dim vouchername As String = "Voucher"
                    '    'If (vou01type = "PROMO123") Then
                    '    '    vouchername = "PROMO123"
                    '    'ElseIf vou01type = "PROMOMD1" Then
                    '    '    vouchername = "PROMOMD1 (" & String.Format("-{0:#,##0}", discrvou01) & ")"
                    '    'ElseIf vou01type = "BUNDL-01" Then
                    '    '    vouchername = "BUNDL-01 (" & String.Format("-{0:#,##0}", discrvou01) & ")"
                    '    'End If
                    '    If (vou01type <> "") Then
                    '        vouchername = vou01type
                    '        If vou01method <> "" Then
                    '            vouchername &= " " & vou01method
                    '        End If
                    '    End If


                    '    If discpstd01 > 0 Then
                    '        e.Value &= " (+ AddDisc " & String.Format("{0:#,##0}", discpvou01) & "%) " & vouchername
                    '    Else
                    '        e.Value &= "     (+ AddDisc " & String.Format("{0:#,##0}", discpvou01) & "%)" & vouchername
                    '    End If
                    'End If


                    If (vou01type <> "") Then
                        Dim vouchername = ""
                        If vou01type <> "NONE" Then
                            vouchername = "[" & vou01type & "]"
                            If vou01method <> "" Then
                                vouchername &= " " & vou01method
                            End If
                        End If
     

                        Dim adddiscdescr = ""
                        If discpvou01 > 0 Then
                            adddiscdescr = "(+ AddDisc " & String.Format("{0:#,##0}", discpvou01) & "%)"
                        End If

                        If discpstd01 > 0 Then
                            e.Value &= " " & adddiscdescr & " " & vouchername
                        Else
                            e.Value &= "     " & adddiscdescr & " " & vouchername
                        End If

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
                ' subtotal = CDec(dgv.Rows(e.RowIndex).Cells("bondetil_subtotal").Value)
                e.Value = String.Format("{0:#,##0}", subtotal)

        End Select
    End Sub

    Private Sub DgvPOSItem_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvPOSItem.CellLeave
        If Me.SkipCellEvent Then
            Exit Sub
        End If

        Me.DgvPOSItem.CurrentCell.Style.BackColor = Color.Gainsboro
        Me.LastRowIndex = e.RowIndex
    End Sub

    Private Sub DgvPOSItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvPOSItem.Click
        Me.txtItemEntry.Focus()
    End Sub

    Private Sub DgvPOSItem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvPOSItem.DoubleClick
        Me.txtItemEntry.Focus()
    End Sub

    Private Sub DgvPOSItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgvPOSItem.KeyDown

        ' Key(e.KeyCode)
        ' MessageBox.Show(e.KeyValue)
        ' Me.txtItemEntry.Focus()
        Dim SuppressKeyPress As Boolean = False

        If e.KeyValue = 27 Then
            If Me.DgvPOSItem.ReadOnly Then
                Me.Hide()
                Exit Sub
            End If
        End If

        If Not Me.DgvPOSItem.ReadOnly Then
            If (e.KeyValue >= 48 And e.KeyValue <= 57) Or _
               (e.KeyValue >= 96 And e.KeyValue <= 105) _
            Then
                Exit Sub
            Else
                Me.Key(Keys.F3, False, SuppressKeyPress)
                Me.txtItemEntry.Focus()
                Exit Sub
            End If


        End If

        If e.Control Or e.Alt Or e.Shift Then
            Me.txtItemEntry.Focus()
            Exit Sub
        End If

        If e.KeyValue = 9 Or e.KeyValue = 20 Then
            Me.txtItemEntry.Focus()
            Exit Sub
        End If

        If (e.KeyValue >= 48 And e.KeyValue <= 57) Or _
           (e.KeyValue >= 65 And e.KeyValue <= 90) Or _
           (e.KeyValue >= 96 And e.KeyValue <= 105) _
        Then
            '  (e.KeyValue >= 186 And e.KeyValue <= 191) Or _
            '  (e.KeyValue >= 219 And e.KeyValue <= 221) Or _
            '  e.KeyValue = 226 Then

            Me.txtItemEntry.AppendText(Chr(e.KeyCode))
            Me.txtItemEntry.Focus()
            Exit Sub
        End If

        Me.txtItemEntry.Focus()

    End Sub

    Private Sub DgvPOSItem_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvPOSItem.Resize
        DgvPOSItem_AdjustWidht(15)
    End Sub

    Private Sub DgvPOSItem_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles DgvPOSItem.Scroll
        DgvPOSItem_AdjustWidht(32)
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




    Private Sub PaymentType_IndexUp()
        If Me.PaymentTypeIndex <= 0 Then
        Else
            Me.PaymentTypeIndex -= 1
            Me.PaymentType_Change()
        End If
    End Sub

    Private Sub PaymentType_IndexDown()
        If Me.PaymentTypeIndex >= Me.POS.PaymentType.Rows.Count - 1 Then
        Else
            Me.PaymentTypeIndex += 1
            Me.PaymentType_Change()
        End If
    End Sub

    Private Sub PaymentType_IndexSet(ByVal id As String)
        Dim i As Integer
        For i = 0 To Me.POS.PaymentType.Rows.Count - 1
            If Me.POS.PaymentType.Rows(i).Item("pospayment_id") = id Then
                Me.PaymentTypeIndex = i
                Me.PaymentType_Change()
                Exit Sub
            End If
        Next
    End Sub

    Private Sub PaymentType_Change()
        'Default Payment Type
        If Me.POS.PaymentType.Rows.Count > 0 Then
            Me.objPaymentTypeName.ForeColor = Color.Black
            Me.objPaymentTypeId.Text = Me.POS.PaymentType.Rows(Me.PaymentTypeIndex).Item("pospayment_id").ToString
            Me.objPaymentTypeName.Text = Me.POS.PaymentType.Rows(Me.PaymentTypeIndex).Item("pospayment_name").ToString
        Else
            Me.objPaymentTypeName.ForeColor = Color.Red
            Me.objPaymentTypeId.Text = "0"
            Me.objPaymentTypeName.Text = "***Paym.NotLoaded***"
        End If
        'Me.objPaymentTypeId.AutoSize = True
        Me.objPaymentTypeName.AutoSize = True

        ' Me.CalculatePromo()
        Me.RecalculateTotal()
        Dim ci As PosPromo.CustomerInfo = Me.getCurrentCustomerInfo()
        Me.POS.PosPromo.CalculateCurrentActivePromo(ci)


        ' Display ---xxxx----
        Me.POS_SecondMonitorDisplaySyncValue()

    End Sub

    Private Sub PaymentType_GetShortcut()
        Me.objPaymentShortcut.Text = ""

        Dim i As Integer
        Dim shortcut As String = ""
        Dim paymentname As String = ""
        Dim id As String = ""
        For i = 0 To Me.POS.PaymentType.Rows.Count - 1
            If Me.POS.PaymentType.Rows(i).Item("pospayment_shortcut").ToString <> "" Then
                shortcut = Me.POS.PaymentType.Rows(i).Item("pospayment_shortcut").ToString
                paymentname = Me.POS.PaymentType.Rows(i).Item("pospayment_name").ToString
                id = Me.POS.PaymentType.Rows(i).Item("pospayment_id").ToString


                Select Case shortcut
                    Case "F9"
                        Me._KybShortcut_F9 = id
                        Me.objPaymentShortcut.Text &= paymentname & " - [F9 ]" & vbCrLf
                    Case "F10"
                        Me._KybShortcut_F10 = id
                        Me.objPaymentShortcut.Text &= paymentname & " - [F10]" & vbCrLf
                    Case "F11"
                        Me._KybShortcut_F11 = id
                        Me.objPaymentShortcut.Text &= paymentname & " - [F11]" & vbCrLf
                    Case "F12"
                        Me._KybShortcut_F12 = id
                        Me.objPaymentShortcut.Text &= paymentname & " - [F12]" & vbCrLf
                End Select

            End If
        Next
        'Me.POS.PaymentType.Rows(PaymentTypeIndex)
    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.objTime.Text = Now.Hour.ToString.PadLeft(2, "0") & ":" & Now.Minute.ToString.PadLeft(2, "0")
    End Sub

    Public Function POSTransactionPrepare() As Boolean
        Me.ReShown = True
    End Function

    Private Sub objStatusShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles objStatusShow.Click
        Me.StatusVisible = Not Me.StatusVisible
        Me.FlowLayoutPanel1.Visible = Me.StatusVisible
        If Me.FlowLayoutPanel1.Visible Then
            Me.objStatusShow.Text = ">"
        Else
            Me.objStatusShow.Text = "<"
        End If
    End Sub


    Private Sub objLabelStatusCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                objCustomerGenderId.Click, _
                objCustomerNationalityName.Click, _
                objCustomerNationalityId.Click, _
                objCustomerId.Click, _
                objCustomerAgeName.Click, _
                objCustomerAgeId.Click, _
                objCustomerGenderName.Click, _
                objVoucher01Type.Click, _
                objVoucher01Disc.Click, _
                objCustomerNPWP.Click, _
                objCustomerName.Click, _
                objSalesName.Click, _
                objSalesId.Click, _
                objVoucher01Name.Click, _
                objVoucher01Id.Click, _
                objVoucher01CodeNum.Click, _
                objCustomerDisc.Click, _
                objCustomerType.Click, _
                objCustomerTelp.Click, _
                objVoucher01Method.Click, _
                objBonExternal.Click, _
                objCustomerPassport.Click


        Dim objLabel As Label = CType(sender, Label)
        MessageBox.Show(objLabel.Name, "Note", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub




    Private Sub btn_PgUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PgUp.Click
        Dim SuppressKeyPress As Boolean
        Me.Key_PageUp(Keys.PageUp, False, SuppressKeyPress)
    End Sub

    Private Sub btn_PgDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PgDown.Click
        Dim SuppressKeyPress As Boolean
        Me.Key_PageDown(Keys.PageDown, False, SuppressKeyPress)
    End Sub



End Class
