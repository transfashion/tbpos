Public Class dlgTrnPosPayment

    Private myRetObj As Object

    Private BonExternalId As String
    Private SelectedDiscType As String
    Private SelectedPaymentId As String
    Private SelectedPaymentName As String
    Private SelectedPaymentBank As String
    Private SelectedPaymentDisc As Decimal
    Private SelectedPaymentDiscValue As Decimal
    Private SelectedPaymentDiscMinPurchase As Decimal
    Private SelectedPaymentPrefix As String
    Private SelectedPaymentIsMulti As Boolean
    Private SelectedPaymentIsVoucherDisabled As Boolean
    Private SelectedPaymentIsAddDiscDisabled As Boolean
    Private SelectedPaymentIsRedeemDisabled As Boolean
    Private SelectedPaymentEdc As String
    Private NewTransactionParamValue As TransStore.PosNewTransactionReturnValue

    Private objPaymentTypeIndex As Integer = 0
    Private objPaymentInEditMode As Boolean

    Private LastRowIndex As Integer
    Private objKeyPress As String = ""
    Private objErrorProvider As ErrorProvider = New ErrorProvider()


    Private hndPaymentValueKeyEv As Boolean = False
    Private isConfirmedExit As Boolean = False

    Private SweepingCard As Boolean = False


    Private tempLastValue As String = ""
    Private tempLastCash As String = ""

    Private _KybShortcut_F9 As String
    Private _KybShortcut_F10 As String
    Private _KybShortcut_F11 As String
    Private _KybShortcut_F12 As String


    Private _CardPrefixLength As Integer = 6



    Private objError As ErrorProvider = New ErrorProvider

    Private WithEvents POS As TransStore.POS

    Public Event PaymentType_IndexChanged(ByVal index As Integer, ByVal id As String, ByVal name As String, ByVal PaymentIsCash As String)



    Public WithEvents bgwQRGenerate As System.ComponentModel.BackgroundWorker



#Region " Constructor "

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, ByRef objPOS As TransStore.POS, ByVal args As Object) As Object

        Dim objParamValue As TransStore.PosPaymentDialogParamValue = New TransStore.PosPaymentDialogParamValue

        Try
            Me.POS = objPOS
            objParamValue = CType(args(0), TransStore.PosPaymentDialogParamValue)
            With objParamValue
                Me.SelectedPaymentId = .PaymentTypeId
                Me.SelectedPaymentName = .PaymentTypeName
                Me.SelectedPaymentBank = .PaymentBank
                Me.SelectedPaymentPrefix = .pospayment_prefix
                Me.SelectedPaymentDisc = .pospayment_disc
                Me.SelectedPaymentDiscValue = .pospayment_discvalue
                Me.SelectedPaymentDiscMinPurchase = .pospayment_discminpurchase
                Me.SelectedPaymentIsMulti = .pospayment_multi
                Me.SelectedPaymentIsVoucherDisabled = .pospayment_isvoucherdisabled
                Me.SelectedPaymentIsAddDiscDisabled = .pospayment_isadddiscdisabled
                Me.SelectedPaymentIsRedeemDisabled = .pospayment_isredeemdisabled
                Me.NewTransactionParamValue = .NewTransactionParamValue
            End With

            If Me.SelectedPaymentId = "100" Then ' Mega
                Me.btn_Allo.Enabled = False
                Me.btn_Qris.Enabled = True
            ElseIf Me.SelectedPaymentId = "104" Then ' Mega 2
                Me.btn_Allo.Enabled = False
                Me.btn_Qris.Enabled = True
            ElseIf Me.SelectedPaymentId = "300" Then ' Other
                Me.btn_Allo.Enabled = False
                Me.btn_Qris.Enabled = True
            ElseIf Me.SelectedPaymentBank = "ALLO" Then ' Allo
                Me.btn_Allo.Enabled = True
                Me.btn_Qris.Enabled = False
            ElseIf Me.SelectedPaymentId = "998" Then ' QRIS
                Me.btn_Allo.Enabled = False
                Me.btn_Qris.Enabled = True
            Else
                Me.btn_Allo.Enabled = False
                Me.btn_Qris.Enabled = False
            End If


        Catch ex As Exception
            Me.Close()
            Throw ex
        End Try

        MyBase.ShowDialog(owner)
        Return myRetObj
    End Function

#End Region

#Region " Layout & Init UI "

    Public Function BindingStop() As Boolean

    End Function

    Public Function BindingStart() As Boolean
        Me.objCustomerID.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "customer_id"))
        Me.objCustomerName.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "customer_name"))

        Me.objPaymentType.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_type"))
        Me.objPaymentTypeName.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_typename"))
        Me.objPaymentBank.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_bank"))
        Me.objPaymentCardNumber.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_cardnumber"))
        Me.objPaymentCardHolder.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_cardholder"))
        Me.objPaymentEdc.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_edc"))
        Me.objPaymentEdcName.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_edcname"))
        Me.objPaymentInstallment.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_installment"))
        Me.objPaymentValue.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_value", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))

        Me.objPaymentCash.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_cash", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))

        Me.objPaymentTotalValue.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_totalvalue", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.objPaymentDiscValue.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_discvalue", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.objPaymentDiscDescr.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_discdescr", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.objPaymentTOTAL.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_total", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.objPaymentTotalQty.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_totalqty", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.objPaymentTotalDue.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_totaldue", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.objPaymentTotalPaid.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_totalpaid", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.objPaymentTotalRefund.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_totalrefund", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))

        Me.objPaymentDiscVoucherTotal.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_discvouchertotal", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))

        Me.objPaymentVoucher.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_voucher", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.objPaymentVoucherCode.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_vouchercode"))
        Me.objPaymentAddDisc.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_adddisc", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.objPaymentRedeem.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_redeem", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))


        Me.objPaymentOutstanding.DataBindings.Add(New Binding("Text", Me.POS.PosPaymentDialog, "payment_outstanding", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))


    End Function


#End Region

#Region " Listener "

    Public Function KeyCheck(ByVal sender As Object, ByVal keycode As System.Windows.Forms.Keys, ByVal keyvalue As Integer, ByVal ctrl As Boolean, ByRef suppressglobalkeyprocess As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        Dim obj As Control = sender
        Dim ret As Boolean


        Select Case obj.Name
            Case "objCustomerID"
                ' Cuma boleh alphabet dan angka

            Case "objCustomerName"
                ' Cuma boleh alphabet dan spasi

            Case "objPaymentType"
                If keycode = 16 Or keycode = Keys.OemSemicolon Then
                    If keycode = 16 Then
                        Me.objPaymentCardNumber.Text = "%"
                    ElseIf keycode = Keys.OemSemicolon Then
                        Me.objPaymentCardNumber.Text = ";"
                    End If
                    Me.objPaymentCardNumber.Focus()
                    Me.objPaymentCardNumber.SelectionStart = 1
                    Me.objPaymentCardNumber.SelectionLength = 0
                End If
                Select Case keycode
                    Case Keys.PageUp
                        Me.PaymentType_IndexUp()
                    Case Keys.PageDown
                        Me.PaymentType_IndexDown()
                    Case Keys.Tab
                        Me.objPaymentCardNumber.Focus()
                        SuppressKeyPress = True
                        suppressglobalkeyprocess = True
                End Select

            Case "objPaymentBank"
                'Dim objTextbox As TextBox = CType(sender, TextBox)
                'If Len(objTextbox.Text) > 8 Then
                '    Dim sign As String = objTextbox.Text.Substring(0, 1)
                '    If sign = "%" Or sign = ";" Then
                '        'Scan Credit Card
                '        objTextbox.MaxLength = 100
                '    Else
                '        objTextbox.MaxLength = 30
                '    End If
                'End If
                Dim objTextbox As TextBox = CType(sender, TextBox)
                Dim usingcardreader As Boolean = False
                If Len(objTextbox.Text) > 1 Then
                    Dim sign As String = objTextbox.Text.Substring(0, 1)
                    If sign = "%" Or sign = ";" Then
                        'Scan Credit Card
                        SweepingCard = True
                        objTextbox.MaxLength = 200
                        usingcardreader = True
                    Else
                        objTextbox.MaxLength = 16
                    End If
                End If


                Select Case keycode
                    Case Keys.Enter
                        If Trim(objTextbox.Text) = "" Then Exit Select
                        ret = Me.ScanCard(objTextbox)
                        objTextbox.MaxLength = 30
                        If Not ret Then
                            Me.objPaymentCardNumber.Focus()
                        End If
                        Exit Function
                End Select


            Case "objPaymentCardNumber"
                ' Cuma boleh angka, dan titik
                'If keycode = 110 Or keycode = 190 Or keycode = Keys.Space _
                '   Or (keycode >= 96 And keycode <= 105) _
                '   Or (keycode >= 48 And keycode <= 57) _
                '   Or keycode = Keys.Back Or keycode = Keys.Left Or keycode = Keys.Right Or keycode = Keys.Delete Then
                'Else
                '    SuppressKeyPress = True
                'End If
                Dim objTextbox As TextBox = CType(sender, TextBox)
                Dim usingcardreader As Boolean = False
                If Len(objTextbox.Text) > 1 Then
                    Dim sign As String = objTextbox.Text.Substring(0, 1)
                    If sign = "%" Or sign = ";" Then
                        'Scan Credit Card
                        SweepingCard = True
                        objTextbox.MaxLength = 200
                        usingcardreader = True
                    Else
                        objTextbox.MaxLength = 16
                    End If
                End If

                Select Case keycode
                    'Case Keys.PageUp
                    '    Me.PaymentType_IndexUp()
                    'Case Keys.PageDown
                    '    Me.PaymentType_IndexDown()
                    Case Keys.Enter
                        If Trim(objTextbox.Text) = "" And Not usingcardreader Then Exit Select
                        ret = Me.ScanCard(objTextbox)
                        If Not ret Then
                            Me.objPaymentCardHolder.Focus()
                        End If
                        Exit Function
                End Select


            Case "objPaymentCardHolder"
                Dim objTextbox As TextBox = CType(sender, TextBox)
                Dim usingcardreader As Boolean = False
                If Len(objTextbox.Text) > 1 Then
                    Dim sign As String = objTextbox.Text.Substring(0, 1)
                    'If sign = "%" Or sign = ";" Then
                    '    'Scan Credit Card
                    '    objTextbox.MaxLength = 100
                    'Else
                    '    objTextbox.MaxLength = 30
                    'End If

                    If sign = "%" Or sign = ";" Then
                        'Scan Credit Card
                        SweepingCard = True
                        objTextbox.MaxLength = 200
                        usingcardreader = True
                    Else
                        objTextbox.MaxLength = 30
                    End If
                End If


                Select Case keycode
                    'Case Keys.PageUp
                    '    Me.PaymentType_IndexUp()
                    'Case Keys.PageDown
                    '    Me.PaymentType_IndexDown()
                    Case Keys.Enter
                        If Trim(objTextbox.Text) = "" And Not usingcardreader Then Exit Select
                        'ret = Me.ScanCard(objTextbox)
                        ret = Me.ScanCard(objTextbox)
                        If Not ret And Me.objPaymentBank.Text = "" Then
                            Me.objPaymentBank.Focus()
                        Else
                            Me.objApproval.Focus()
                        End If
                        Exit Function
                End Select


            Case "objApproval"
                Dim objTextbox As TextBox = CType(sender, TextBox)
                If keycode = Keys.Enter Then
                    If Trim(objTextbox.Text) <> "" Then
                        Me.objPaymentValue.Focus()
                    End If
                End If


            Case "objPaymentValue"

                Select Case keycode
                    Case Keys.Enter
                        If SweepingCard Then
                            SweepingCard = False
                            suppressglobalkeyprocess = True
                            SuppressKeyPress = True
                            Exit Function
                        End If
                End Select

                If SweepingCard Then
                    If keycode = Keys.OemQuestion Then
                    Else
                        suppressglobalkeyprocess = True
                        SuppressKeyPress = True
                    End If
                    Exit Function
                End If

                Select Case keycode
                    Case Keys.Escape
                        SweepingCard = False
                    Case Keys.OemSemicolon
                        SweepingCard = True
                    Case Keys.OemQuestion
                        SweepingCard = False
                    Case Keys.Enter
                        SweepingCard = False
                        Me.AddToPayments(sender, Keys.KeyCode, ctrl, Nothing)
                        suppressglobalkeyprocess = True
                        Exit Function
                End Select



            Case "objPaymentCash"
                Select Case keycode
                    Case Keys.Enter
                        Me.AddToPayments(sender, Keys.KeyCode, ctrl, Nothing)
                        suppressglobalkeyprocess = True
                        Exit Function
                End Select


        End Select


        Select Case keycode
            Case Keys.Escape
                dlgCancel()
        End Select

        Return True
    End Function

    Public Function Key(ByVal sender As Object, ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByVal paymintparam As PaymentInteractionParam) As Boolean
        Dim obj As Control = sender

        Select Case keycode
            Case Keys.F5
                ' Masukkan Data Payment 
                If ctrl Then
                    ' Pindahkan data dari CardHolder ke CardNumber
                    Me.objPaymentCardNumber.Text = Trim(Me.objPaymentCardHolder.Text) & "*"
                    Me.objPaymentCardNumber.BackColor = Color.Gainsboro
                Else
                    Me.AddToPayments(sender, Keys.KeyCode, ctrl, paymintparam)
                End If


            Case Keys.Up
                ' Me.txtItemEntry.Text = ""
                ' Me.DgvPosItemReadOnlyState()
                If Me.DgvPayments.Rows.Count > 0 Then
                    Dim currIndex As Integer = 0
                    If Me.DgvPayments.CurrentRow IsNot Nothing Then
                        currIndex = Me.DgvPayments.CurrentRow.Index
                        Me.DgvPayments.Rows(currIndex).Selected = True
                        If currIndex > 0 Then
                            currIndex -= 1
                        End If
                    Else
                        currIndex = 0
                        Me.DgvPayments.Rows(0).Selected = True
                    End If
                    Me.DgvPayments.CurrentCell = Me.DgvPayments.Rows(currIndex).Cells(0)
                    Me.DgvPayments.FirstDisplayedCell = Me.DgvPayments.CurrentCell
                    Me.LastRowIndex = currIndex
                End If


            Case Keys.Down
                ' Me.txtItemEntry.Text = ""
                ' Me.DgvPosItemReadOnlyState()
                If Me.DgvPayments.Rows.Count > 0 Then
                    Dim currIndex As Integer = 0
                    If Me.DgvPayments.CurrentRow IsNot Nothing Then
                        currIndex = Me.DgvPayments.CurrentRow.Index
                        Me.DgvPayments.Rows(currIndex).Selected = True
                        If currIndex < Me.DgvPayments.Rows.Count - 1 Then
                            currIndex += 1
                        End If
                    Else
                        currIndex = 0
                        Me.DgvPayments.Rows(0).Selected = True
                    End If
                    Me.DgvPayments.CurrentCell = Me.DgvPayments.Rows(currIndex).Cells(0)
                    Me.DgvPayments.FirstDisplayedCell = Me.DgvPayments.CurrentCell
                    Me.LastRowIndex = currIndex
                End If


            Case Keys.F8
                ' Cek apakah ada object active, tidak readonly dan diselect
                ' klo ada, skip
                Dim objTextbox As TextBox
                If TypeOf (sender) Is TextBox Then
                    objTextbox = CType(sender, TextBox)
                    If objTextbox.SelectionLength > 0 Then
                        Exit Select
                    End If
                End If


                Dim currIndex As Integer = 0
                If Me.DgvPayments.CurrentRow IsNot Nothing Then
                    currIndex = Me.DgvPayments.CurrentRow.Index

                    Dim line As Integer = Me.DgvPayments.Rows(currIndex).Cells("payment_line").Value
                    Dim objPym As TransStore.POS.PosPaymentRow = New TransStore.POS.PosPaymentRow
                    Dim retline As Integer
                    Dim args As Object = New Object() {}
                    Dim f As dlgConfirmYesNo = New dlgConfirmYesNo
                    Dim result As Object
                    Dim fmask As Form = uiTrnPosEN.CreateMask(0.75)

                    objPym.line = line
                    If line = 1 Then
                        MessageBox.Show("Main payment tidak dapat dihapus ")
                        Exit Select
                    End If


                    fmask.Show(Me)
                    f.BeepOnOK = False
                    f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                    f.Message = "Hapus Data ?"
                    result = f.OpenDialog(fmask, args)
                    fmask.Close()
                    fmask.Dispose()
                    f.Dispose()
                    If result IsNot Nothing Then
                        Me.POS.PaymentRemove(objPym, retline)
                    End If

                End If


            Case Keys.F2
                ' Tampilkan dialog voucher

                ' Dialog Voucher hanya akan ditampilkan apabila belum ada pembayaran
                If Me.DgvPayments.Rows.Count > 0 Then
                    MessageBox.Show("Nilai voucher hanya bisa diinput sebelum ada data pembayaran.", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Select
                End If


                Dim args As Object = New Object() {}
                Dim f As dlgTrnPosVoucher = New dlgTrnPosVoucher
                Dim result As Object
                Dim fmask As Form = uiTrnPosEN.CreateMask(0.75)

                f.FormBorderStyle = Windows.Forms.FormBorderStyle.None

                Dim objParamValue As TransStore.PosVoucherDialogParamValue = New TransStore.PosVoucherDialogParamValue
                With objParamValue
                    .MODE = 2
                    .AddDiscAuto = Me.POS.DISCADD_AUTO
                    .AddDiscMinimalTotal = Me.POS.DISCADD_MINTOTAL
                    .PaymentTotalValue = CDec(Me.objPaymentTotalValue.Text)
                    .SelectedPaymentName = Me.SelectedPaymentName
                    .SelectedPaymentDisc = CDec(Me.SelectedPaymentDisc)
                    .SelectedPaymentIsVoucherDisabled = Me.SelectedPaymentIsVoucherDisabled
                    .SelectedPaymentIsAddDiscDisabled = Me.SelectedPaymentIsAddDiscDisabled
                    .SelectedPaymentIsRedeemDisabled = Me.SelectedPaymentIsRedeemDisabled
                    .VoucherId = Me.NewTransactionParamValue.Voucher01Id
                    .PaymentVoucherCode = Me.objPaymentVoucherCode.Text
                    .PaymentVoucher = CDec(Me.objPaymentVoucher.Text)
                    .PaymentAddDisc = CDec(Me.objPaymentAddDisc.Text)
                    .PaymentRedeem = CDec(Me.objPaymentRedeem.Text)
                    .POS = Me.POS
                    .authusername = Me.objAuthName.Text
                End With
                args = New Object() {objParamValue}


                Dim customer_id As String = Me.objCustomerID.Text
                Dim customer_name As String = Me.objCustomerName.Text
                Dim customer_telp As String = Me.objCustomerTelp.Text

                fmask.Show(Me)
                result = f.OpenDialog(fmask, args)



                If IsArray(result) Then
                    If result.Length > 0 Then
                        objParamValue = CType(result(0), TransStore.PosVoucherDialogParamValue)

                        If objParamValue.PaymentAddDisc <> 0 Then
                            Me.lblAuthBy.Visible = True
                            Me.objAuthName.Visible = True
                            Me.objAuthName.Text = objParamValue.authusername
                        Else
                            Me.lblAuthBy.Visible = False
                            Me.objAuthName.Visible = False
                            Me.objAuthName.Text = ""
                        End If



                        Me.dlg_VoucherRecalculate( _
                            objParamValue.PaymentVoucherCode, _
                            objParamValue.PaymentVoucher, _
                            objParamValue.PaymentAddDisc, _
                            objParamValue.PaymentRedeem _
                        )


                        Me.objCustomerID.Text = customer_id
                        Me.objCustomerName.Text = customer_name
                        Me.objCustomerTelp.Text = customer_telp
                    End If
                End If

                fmask.Close()
                fmask.Dispose()
                f.Dispose()


            Case Keys.F3
                ' Edit payment
                Dim currIndex As Integer = 0
                If Me.DgvPayments.CurrentRow IsNot Nothing Then
                    currIndex = Me.DgvPayments.CurrentRow.Index
                    Me.objPaymentType.Text = ""



                End If



            Case Keys.F10
                'apabila salesid masih belum readonly, skip
                'If Not Me.objPaymentSalescode.ReadOnly Then
                '    Exit Select
                'End If


                ' Check Out Payment
                ' Simpan ke database, hasilnya no BON
                Dim objBon As TransStore.POS.PosHeader
                Dim total As Decimal
                Dim pay As Decimal


                Try

                    ' Cek apakah sudah dibayar sesuai dengan pembelian ?
                    total = CDec(Me.objPaymentTOTAL.Text)
                    pay = CDec(Me.objPaymentTotalPaid.Text)

                    If pay < total Then
                        Throw New Exception("Pembayaran masih kurang.")
                    End If


                    objBon = Me.SaveData()
                    Me.POS.ClearTransaction()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Select
                End Try

                ' No BON di unpankan ke printer
                Dim reprint As Boolean = True
                Dim doreprint As Boolean = False
                Dim args As Object = New Object() {}
                Dim fmask As Form = uiTrnPosEN.CreateMask(0.75)
                Dim objBonData As uiTrnPosEN.PosBonData
                Dim txt As String
                Dim ret As Boolean
                Dim copyprint As Integer = POS.BON_COPY

                Try

                    ' baca dari database, untuk no bon yang bersangkutan
                    objBonData = Me.POS.GetBonData(objBon)
                    fmask.Show(Me)
                    While reprint
                        ' Rutin untuk format bon
                        txt = String.Join(vbCrLf, Me.POS.FormatBon(objBonData, False, False))

                        If doreprint Then
                            copyprint = 1
                        End If

                        For ci As Integer = 1 To copyprint
                            ret = uiTrnPosEN.SendTextToPrinter(Me.POS, txt, uiTrnPosEN.PrintMethod.PrintOnly, LX300.P_PAGE_07)
                        Next

                        ' setelah selesai, tany, apakah akan reprint lagi
                        Dim result As Object
                        Dim f As dlgConfirmYesNo = New dlgConfirmYesNo
                        f.BeepOnOK = False
                        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                        f.Message = "Reprint ?"
                        result = f.OpenDialog(fmask, args)
                        If result IsNot Nothing Then
                            doreprint = True
                            reprint = True
                        Else
                            doreprint = False
                            reprint = False
                        End If
                        f.Dispose()
                    End While
                    fmask.Close()
                    fmask.Dispose()

                    ' Tutup dialog payment
                    Me.dlgPaymentCommitAndClose(objBon)
                Catch ex As Exception
                    MessageBox.Show("[dlgTrnPosPayment:Key] Keys.F10" & vbCrLf & ex.Message, "Payment Print", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            Case Keys.F12
                If Me.DgvPayments.Rows.Count > 0 Then
                    Me.PaymentType_IndexSet(Me._KybShortcut_F12)
                    Me.objPaymentCash.Focus()
                End If


        End Select


    End Function

#End Region


#Region " Payment Function "

    Public Function AddToPayments(ByVal sender As Object, ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean, ByVal paymintparam As PaymentInteractionParam) As Boolean
        Dim msg As String = ""
        Dim obj As TransStore.POS.PosPaymentRow = New TransStore.POS.PosPaymentRow()

        Try
            obj.Type = Me.objPaymentType.Text
            obj.TypeName = Me.objPaymentTypeName.Text
            obj.Bank = Me.objPaymentBank.Text
            obj.CardNumber = Me.objPaymentCardNumber.Text
            obj.CardHolder = IIf(Me.lblSCardHolder.Text <> "", Me.lblSCardHolder.Text, Me.objPaymentCardHolder.Text)
            obj.Edc = Me.objPaymentEdc.Text
            obj.EdcName = Me.objPaymentEdcName.Text
            obj.Installment = CInt(Me.objPaymentInstallment.Text)
            obj.Value = CDec(Me.objPaymentValue.Text)
            obj.Cash = CDec(Me.objPaymentCash.Text)
            obj.Approval = Me.objApproval.Text
        Catch ex As Exception
            Return False
        End Try


        Dim i As Integer
        Dim OutstandingPayment As Decimal = CDec(Me.objPaymentOutstanding.Text)

        Dim pospayment_id As String = ""
        Dim pospayment_name As String = ""
        Dim pospayment_disc As Decimal = 0
        Dim pospayment_isdisabled As Boolean = False
        Dim pospayment_iscash As Boolean = False
        Dim pospayment_isvoucher As Boolean = False
        Dim pospayment_vouchervalue As Decimal = 0
        Dim pospayment_order As Decimal = 0
        Dim pospayment_multi As Boolean = False
        Dim pospayment_prefix As String = ""
        Dim pospayment_minpaid As Decimal = 0
        Dim pospayment_shortcut As String = ""
        Dim pospayment_bankname As String = ""
        Dim pospayment_isvoucherdisabled As Boolean = False
        Dim pospayment_isadddiscdisabled As Boolean = False
        Dim pospayment_isredeemdisabled As Boolean = False


        ' Cari informasi mengenai metode pembayaran yang dipilih
        Dim drow() As DataRow
        drow = Me.POS.PaymentType.Select(String.Format("pospayment_id='{0}'", obj.Type))
        If drow.Length > 0 Then
            pospayment_id = drow(0).Item("pospayment_id").ToString
            pospayment_name = drow(0).Item("pospayment_name").ToString
            pospayment_disc = drow(0).Item("pospayment_disc")
            pospayment_isdisabled = drow(0).Item("pospayment_isdisabled")
            pospayment_iscash = drow(0).Item("pospayment_iscash")
            pospayment_isvoucher = drow(0).Item("pospayment_isvoucher")
            pospayment_vouchervalue = drow(0).Item("pospayment_vouchervalue")
            pospayment_order = drow(0).Item("pospayment_order")
            pospayment_multi = drow(0).Item("pospayment_multi")
            pospayment_prefix = drow(0).Item("pospayment_prefix").ToString
            pospayment_minpaid = drow(0).Item("pospayment_minpaid")
            pospayment_shortcut = drow(0).Item("pospayment_shortcut").ToString
            pospayment_bankname = drow(0).Item("pospayment_bankname").ToString
            pospayment_isvoucherdisabled = drow(0).Item("pospayment_isvoucherdisabled")
            pospayment_isadddiscdisabled = drow(0).Item("pospayment_isadddiscdisabled")
            pospayment_isredeemdisabled = drow(0).Item("pospayment_isredeemdisabled")
        End If

        Dim skipcek_digit As Boolean = pospayment_isvoucher Or pospayment_id = "997" Or pospayment_id = "998" Or pospayment_id = "300"
        Dim skipcek_prefix As Boolean = False

        If paymintparam IsNot Nothing Then
            skipcek_digit = paymintparam.skipcheck_digit
            skipcek_prefix = paymintparam.skipcheck_prefix
        End If

        ' Cek Data
        If Me.objPaymentCash.Enabled Then
            ' Pembayaran menggunakan CASH
            obj.IsCash = 1
            If obj.Cash <= 0 Then
                Exit Function
            End If

            ' Pembayaran menggunakan cash
            ' Harus sebagai penutup pembayaran, nilai cash minimal sama dengan 
            msg = "cash payment less than outstanding"
            If CDec(Me.objPaymentCash.Text) < OutstandingPayment Then
                Me.objPaymentCash.BackColor = Color.LightCoral
                Me.objPaymentCash.Focus()
                Me.objErrorProvider.SetError(Me.objPaymentCash, msg)
                MessageBox.Show(msg, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Function
            Else
                Me.objPaymentCash.BackColor = Nothing
                Me.objErrorProvider.SetError(Me.objPaymentCash, "")
            End If

            obj.Refund = obj.Cash - obj.Value

        Else

            ' Pembayaran menggunakan CC
            obj.IsCash = 0
            If obj.Value <= 0 Then
                Exit Function
            End If


            ' Cek Kode Kredit Card
            msg = "CardNumber still Blank"
            If Trim(obj.CardNumber) = "" Then
                Me.objPaymentCardNumber.BackColor = Color.LightCoral
                Me.objPaymentCardNumber.Focus()
                Me.objErrorProvider.SetError(Me.objPaymentCardNumber, msg)
                MessageBox.Show(msg, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Function
            Else
                Me.objPaymentCardNumber.BackColor = Nothing
                Me.objErrorProvider.SetError(Me.objPaymentCardNumber, "")
            End If

            ' Cek Nama Kredit Card
            msg = "CardHolder still Blank"
            If Trim(obj.CardHolder) = "" And Trim(Me.objPaymentCardHolder.Text) = "" Then
                Me.objPaymentCardHolder.BackColor = Color.LightCoral
                Me.objPaymentCardHolder.Focus()
                Me.objErrorProvider.SetError(Me.objPaymentCardHolder, msg)
                MessageBox.Show(msg, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Function
            Else
                Me.objPaymentCardHolder.BackColor = Nothing
                Me.objErrorProvider.SetError(Me.objPaymentCardHolder, "")
            End If

            If Trim(obj.CardHolder) = "" And Trim(Me.objPaymentCardHolder.Text) <> "" Then
                obj.CardHolder = Trim(Me.objPaymentCardHolder.Text)
            End If


            ' Cek Approval harus diisi
            msg = "Code approval belum diisi"
            If Trim(obj.Approval) = "" Then
                Me.objApproval.BackColor = Color.LightCoral
                Me.objApproval.Focus()
                Me.objErrorProvider.SetError(Me.objApproval, msg)
                MessageBox.Show(msg, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Function
            Else
                Me.objApproval.BackColor = Nothing
                Me.objErrorProvider.SetError(Me.objApproval, "")
            End If

            '' Cek Promo KArtu Metro
            '' Tambahan potongan harga dengan minimum transaksi :
            '' - FURLA : minimum transaksi Rp 3.000.000,- mendapatkan potongan harga sebesar Rp 150.000,-   
            '' - GEOX      : minimum transaksi Rp 2.000.000,- mendapatkan potongan harga sebesar Rp 100.000,-
            '' - FIND KAPOOR : minimum transaksi Rp 2.000.000,- mendapatkan potongan harga sebesar Rp 100.000,-
            'If Me.POS.RegionId = "02600" Or Me.POS.RegionId = "03400" Or Me.POS.RegionId = "03700" Then
            '    Dim startdate As Date = New Date(2021, 12, 29, 0, 0, 0)
            '    Dim enddate As Date = New Date(2022, 2, 28, 0, 0, 0)

            '    If (Now.Date >= startdate And Now.Date <= enddate) Then
            '        If Mid(obj.CardNumber, 1, 6) = "471439" Then
            '            MessageBox.Show("Masukkan tambahan diskon untuk Furla, Geox, Find Kapoor sesuai ketentuan", "Promo Mega Metro Card", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        End If
            '    Else
            '    End If
            'End If


            Dim MyPaymentType As String = Me.objPaymentTypeName.Text
            If Me.POS.ALLOW_MULTIPLE_PAYMENT_IN_FP = "1" Then
                Dim usingfilter As Boolean = False
                Dim sFiltered() As String = Me.POS.FP_PAYMENT_FILTER.Split(",")
                For i = 0 To sFiltered.Length - 1
                    If Me.SelectedPaymentId = Trim(sFiltered(i)) Then
                        usingfilter = True
                    End If
                Next

                If usingfilter Then
                    pospayment_minpaid = 0
                    pospayment_prefix = Me.SelectedPaymentPrefix
                    MyPaymentType = Me.SelectedPaymentName
                End If
            End If



            ' Cek Prefix
            If (Not skipcek_prefix) Then
                Dim prefix() As String
                Dim cardprefix As String
                Dim match As Integer = 0
                msg = String.Format("'{0}' is not a valid {1} Number!", Me.objPaymentCardNumber.Text, MyPaymentType)
                If Trim(pospayment_prefix) <> "" And Trim(pospayment_prefix) <> "OTHER" Then
                    prefix = pospayment_prefix.Split(",")
                    For i = 0 To prefix.Length - 1
                        cardprefix = prefix(i)
                        If Mid(obj.CardNumber, 1, Len(cardprefix)) = cardprefix Then
                            match += 1
                        End If
                    Next
                Else
                    match = 1
                End If

                If match <= 0 Then
                    Me.objPaymentCardNumber.BackColor = Color.LightCoral
                    Me.objPaymentCardNumber.Focus()
                    Me.objErrorProvider.SetError(Me.objPaymentCardNumber, msg)
                    MessageBox.Show(msg, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    'Set Focus ke Card Holder
                    If Me.POS.CARDNUMBER_ENTRY = "0" Then
                        Me.objPaymentCardHolder.Focus()
                    Else
                        Me.objPaymentCardNumber.Focus()
                    End If

                    Exit Function
                Else
                    Me.objPaymentCardNumber.BackColor = Nothing
                    Me.objErrorProvider.SetError(Me.objPaymentCardNumber, "")
                End If
            End If


            ' Cek apakah cardnumber panjang digitnya 12 atau 16
            '  If (Not pospayment_isvoucher) Then
            If (Not skipcek_digit) Then
                msg = String.Format("'{0}' is not a valid card number!", Me.objPaymentCardNumber.Text)
                If (Len(Trim(Me.objPaymentCardNumber.Text)) < 12) Then
                    Me.objPaymentCardNumber.BackColor = Color.LightCoral
                    Me.objPaymentCardNumber.Focus()
                    Me.objErrorProvider.SetError(Me.objPaymentCardNumber, msg)
                    MessageBox.Show(msg, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Function
                Else
                    Me.objPaymentCardNumber.BackColor = Nothing
                    Me.objErrorProvider.SetError(Me.objPaymentCardNumber, "")
                End If
            End If




            ' Cek Minimum payment, apabila bukan pembayaran utama
            If Me.DgvPayments.Rows.Count = 0 Then
                Dim minimumpaymentval As Decimal = 0
                Dim minpaymentcek As Boolean = False
                Dim minpayment_occ As Boolean = False
                Dim minimumpayment As Decimal = CDec(pospayment_minpaid)
                If minimumpayment <> 0 Then
                    minpaymentcek = True
                    minimumpaymentval = (minimumpayment / 100) * CDec(Me.objPaymentTOTAL.Text)
                    If obj.Value >= minimumpaymentval Then
                        minpayment_occ = True
                    Else
                        minpayment_occ = False
                    End If
                End If

                msg = "Minimum payment belum tercapai" & vbCrLf & "min: " & minimumpayment & "% (" & String.Format("{0:#,##0}", minimumpaymentval) & ")"
                If minpaymentcek And Not minpayment_occ Then
                    Me.objPaymentValue.BackColor = Color.LightCoral
                    Me.objPaymentValue.Focus()
                    Me.objErrorProvider.SetError(Me.objPaymentValue, msg)
                    MessageBox.Show(msg, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Function
                Else
                    Me.objPaymentValue.BackColor = Nothing
                    Me.objErrorProvider.SetError(Me.objPaymentValue, "")
                End If

            End If



            ' Cek Value pembayaran, maksimal adalah nilai outstanding, 
            ' Khusus untuk voucher, tidak perlu dicek maksimalnya, tapi nilainya harus sesuai dengan 
            ' kelipatan voucher
            If Not CBool(pospayment_isvoucher) Then
                ' Bukan Voucher
                msg = "Value max " & String.Format("{0:#,##0}", OutstandingPayment)
                If CDec(Me.objPaymentValue.Text) > OutstandingPayment Then
                    Me.objPaymentValue.BackColor = Color.LightCoral
                    Me.objPaymentValue.Focus()
                    Me.objErrorProvider.SetError(Me.objPaymentValue, msg)
                    MessageBox.Show(msg, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Function
                Else
                    Me.objPaymentValue.BackColor = Nothing
                    Me.objErrorProvider.SetError(Me.objPaymentValue, "")
                End If
            Else
                ' Voucher
                If pospayment_vouchervalue = 0 Then
                    ' Voucher Bebas

                ElseIf pospayment_vouchervalue < 0 Then
                    'Menggunakan metode verifikasi nomor voucher
                    Dim vouval As Decimal = 0
                    Dim vouvalcode As String = Mid(Me.objPaymentCardNumber.Text, 2, 2)
                    Dim paritycheck = Mid(Me.objPaymentCardNumber.Text, 13, 1)
                    Select Case vouvalcode
                        Case "01"
                            vouval = 500000
                    End Select






                Else
                    Dim modval As Decimal = CDec(Me.objPaymentValue.Text) Mod pospayment_vouchervalue
                    msg = "Value voucher harus kelipatan " & String.Format("{0:#,##0}", pospayment_vouchervalue)
                    If CDec(Me.objPaymentValue.Text) <= 0 Or Not modval = 0 Then
                        Me.objPaymentValue.BackColor = Color.LightCoral
                        Me.objPaymentValue.Focus()
                        Me.objErrorProvider.SetError(Me.objPaymentValue, msg)
                        MessageBox.Show(msg, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Function
                    Else
                        Me.objPaymentValue.BackColor = Nothing
                        Me.objErrorProvider.SetError(Me.objPaymentValue, "")
                    End If
                End If
            End If

            End If  'If Me.objPaymentCash.Enabled



            ' Masking no kartu kredit
            'Dim tempcclen = Len(Me.objPaymentCardNumber.Text)
            'If tempcclen > 0 Then
            '    Dim tempccprefix = Me.objPaymentCardNumber.Text.Substring(0, _CardPrefixLength)
            '    Dim tempccsuffix = Me.objPaymentCardNumber.Text.Substring(tempcclen - 4, 4)
            '    obj.CardNumber = tempccprefix & "------" & tempccsuffix
            'End If


            ' Masukkan ke Data
            Dim retline As Integer
            Me.POS.PaymentAdd(obj, retline)
            Me.lblSCardNumber.Text = ""
            Me.lblSCardHolder.Text = ""
            Me.objPaymentShortcut.Visible = True

            If Me.POS.CARDNUMBER_ENTRY = "0" Then
                Me.objPaymentCardHolder.Focus()
            End If




    End Function

    Public Function SaveData() As TransStore.POS.PosHeader
        Dim bon_id As String = ""
        Dim objBonHeaderData As New TransStore.POS.PosHeader
        Dim taxPercent As Decimal = Me.POS.TaxPercent


        Dim bonevent As String = ""
        If Trim(Me.NewTransactionParamValue.BonEvent) <> "" Then
            bonevent = ":" & Me.NewTransactionParamValue.BonEvent
        End If

        With objBonHeaderData

            .bon_id = ""
            .bon_idext = Me.BonExternalId
            .bon_event = bonevent
            .bon_date = Now()
            .bon_replacefromvoid = ""
            .site_id_from = Me.NewTransactionParamValue.SiteIdFrom

            .bon_createby = Me.POS.UserName
            .customer_id = Trim(Me.objCustomerID.Text)
            .customer_name = Trim(Me.objCustomerName.Text)
            .salesperson_id = Me.objPaymentSalescode.Text
            .salesperson_name = Me.objPaymentSalesname.Text

            .voucher01_id = Me.NewTransactionParamValue.Voucher01Id
            .voucher01_type = Me.NewTransactionParamValue.Voucher01Type
            .voucher01_codenum = Me.objPaymentVoucherCode.Text
            .voucher01_discp = Me.NewTransactionParamValue.Voucher01Disc
            .voucher01_name = Me.NewTransactionParamValue.Voucher01Name
            .voucher01_method = Me.NewTransactionParamValue.Voucher01Method

            .customer_ageid = Me.NewTransactionParamValue.CustomerAgeId
            .customer_agename = Me.NewTransactionParamValue.CustomerAgeName
            .customer_genderid = Me.NewTransactionParamValue.CustomerGenderId
            .customer_gendername = Me.NewTransactionParamValue.CustomerGenderName
            .customer_nationalityid = Me.NewTransactionParamValue.CustomerNationalityId
            .customer_nationalityname = Me.NewTransactionParamValue.CustomerNationalityName
            .customer_npwp = Me.NewTransactionParamValue.CustomerNPWP
            .customer_telp = Trim(Me.objCustomerTelp.Text)
            .customer_disc = Me.NewTransactionParamValue.CustomerDisc
            .customer_typename = Me.NewTransactionParamValue.CustomerType
            '.customer_passport = Me.NewTransactionParamValue.CustomerPassport
            .customer_passport = Trim(Me.objCustomerPassport.Text)
            '.customer_name = Me.NewTransactionParamValue.CustomerName

            .bon_itemqty = CInt(Me.objPaymentTotalQty.Text)
            .bon_msubtotal = CDec(Me.objPaymentTotalValue.Text)

            .bon_msubtvoucher = CDec(Me.objPaymentVoucher.Text)
            .bon_msubtredeem = CDec(Me.objPaymentRedeem.Text)

            .bon_msubtdiscadd = CDec(objPaymentAddDisc.Text)

            .bon_msubtracttotal = CDec(objPaymentDiscVoucherTotal.Text)
            .bon_msubtotaltobedisc = .bon_msubtotal - .bon_msubtracttotal
            .bon_mdiscpaympercent = Me.SelectedPaymentDisc
            .bon_mdiscpayment = CDec(Me.objPaymentDiscValue.Text)
            .bon_mtotal = CDec(Me.objPaymentTOTAL.Text)
            .bon_mpayment = CDec(Me.objPaymentTotalPaid.Text)
            .bon_mrefund = CDec(Me.objPaymentTotalRefund.Text)

            ' Perhitungan Pajak Gross Up
            .bon_msalegross = CDec(.bon_mtotal) + .bon_msubtvoucher + .bon_msubtredeem
            .bon_msalenet = (100 / (100 + taxPercent)) * .bon_msalegross
            .bon_msaletax = .bon_msalegross - .bon_msalenet
            .bon_npwp = POS.NPWP
            .bon_fakturpajak = "(auto)"
            .bon_adddisc_authusername = IIf(Trim(Me.objAuthName.Text) <> "", Trim(Me.objAuthName.Text), " ")

            .bon_disctype = Me.SelectedDiscType

            .bon_rowitem = Me.POS.PosItems.Rows.Count
            .bon_rowpayment = Me.POS.PosPayments.Rows.Count

            .pospayment_id = Me.SelectedPaymentId
            .pospayment_name = Me.SelectedPaymentName
            '.posedc_id = Me.SelectedPaymentEdc
            '.posedc_name = Me.SelectedPaymentEdc
            .posedc_id = ""
            .posedc_name = ""

            .machine_id = Me.POS.MachineId
            .region_id = Me.POS.RegionId
            .branch_id = Me.POS.BranchId
        End With



        Try

            ' Cek email apakah diisi
            ' Email ada di field passport
            If objBonHeaderData.customer_passport <> "" Then
                If Not dlgCustomerEdit.EmailAddressChecker(objBonHeaderData.customer_passport) Then
                    Throw New Exception("SaveData Error." & vbCrLf & "Format Email salah")
                End If
            End If



            Dim CustomerInfoIsMandatory As Boolean = Me.POS.CUSTOMERINFO_IS_MANDATORY
            If Me.POS.IsDevelopmentMode Then
                CustomerInfoIsMandatory = Config.CustomerInfoIsMandatory
            End If



            If CustomerInfoIsMandatory Then
                If objBonHeaderData.customer_name = "" Then
                    Throw New Exception("SaveData Error." & vbCrLf & "Nama Customer Kosong")
                End If
                If objBonHeaderData.customer_telp = "" Then
                    Throw New Exception("SaveData Error." & vbCrLf & "Telp Customer Kosong")
                End If
            End If


            Me.POS.Save(objBonHeaderData)

        Catch ex As Exception
            Throw New Exception("SaveData Error." & vbCrLf & "[dlgTrnPosPayment:SaveData()]" & vbCrLf & ex.Message)
        End Try

        Return objBonHeaderData
    End Function



    Public Function ValidateEmail(ByVal strCheck As String) As Boolean
        Try
            Dim vEmailAddress As New System.Net.Mail.MailAddress(strCheck)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
#End Region

#Region " Payment Event "


    Private Sub dlg_PaymentModified(ByVal action As TransStore.POS.PosItemAction, ByVal obj As TransStore.POS.PosPaymentRow) Handles POS.PaymentModified
        uiTrnPosEN.BeepDef2()

        'Reset Data
        Me.objPaymentCardNumber.Text = ""
        Me.objPaymentCardHolder.Text = ""
        Me.objPaymentInstallment.Text = "1"
        Me.objPaymentValue.Text = "0"
        Me.objPaymentCash.Text = "0"
        Me.objPaymentTotalRefund.Text = "0"


        ' Hitung refund, apabila cash
        ' disini, perhitungan refund harus diletakkan sebelum perhitungan outstanding
        ' untuk mendapatkan nilai outstanding sebelumnya
        Dim refund As Decimal = obj.Cash - obj.Value
        If Me.objPaymentCash.Enabled Then
            Me.objPaymentTotalRefund.Text = refund
        End If



        ' Hitung Outstanding Payment
        Dim OutstandingPayment As Decimal

        Me.objPaymentTotalDue.Text = Me.POS.PaymentSubtotal
        OutstandingPayment = CDec(Me.objPaymentTOTAL.Text) - Me.POS.PaymentSubtotal


        Me.objPaymentValue.Text = OutstandingPayment
        Me.objPaymentOutstanding.Text = OutstandingPayment


        Me.objPaymentType.Enabled = True
        Me.objPaymentTypeName.Enabled = True

        If OutstandingPayment <= 0 Then
            Me.objPaymentInformation.Enabled = False
            Me.objPaymentSalescode.SelectionStart = Len(Me.objPaymentSalescode.Text)
            Me.objPaymentSalescode.SelectionLength = 0
        Else
            Me.objPaymentInformation.Enabled = True
            Me.objPaymentType.SelectionStart = Len(Me.objPaymentType.Text)
            Me.objPaymentType.SelectionLength = 0
        End If


        Me.objPaymentAdditional.Enabled = False
        Me.objPaymentCustomerInformation.Enabled = False

        ' Hitung total paid
        Dim i As Integer
        Dim _iscash As Boolean
        Dim _val, _totval As Decimal
        If Me.DgvPayments.Rows.Count > 0 Then
            _totval = 0
            For i = 0 To Me.DgvPayments.Rows.Count - 1
                _iscash = CBool(Me.DgvPayments.Rows(i).Cells("payment_iscash").Value)
                If _iscash Then
                    _val = Me.DgvPayments.Rows(i).Cells("payment_cash").Value
                Else
                    _val = Me.DgvPayments.Rows(i).Cells("payment_value").Value
                End If
                _totval += _val
            Next
        End If

        Me.objPaymentTotalPaid.Text = _totval

        Me.BindingContext(Me.POS.PosPaymentDialog).EndCurrentEdit()
        Me.POS.PosPaymentDialog.AcceptChanges()


        Me.objPaymentType.SelectionLength = 0
        Me.objPaymentType.Focus()


    End Sub



#End Region

#Region " Payment Type "

    Private Function PaymentTypeCanBeChange() As Boolean
        Dim ret As Boolean

        ' apakah sudah ada pembayaran
        If Me.DgvPayments.Rows.Count <= 0 Then
            ret = False
        Else
            ret = True
        End If

        Return ret
    End Function


    Private Sub PaymentType_IndexUp()
        ' Tidak berfungsi pada single type payment
        If Not Me.SelectedPaymentIsMulti Then Exit Sub

        ' Pembayaran pertama harus sesuai dengan payment type dasar
        If Not PaymentTypeCanBeChange() Then Exit Sub



        If Me.objPaymentTypeIndex <= 0 Then
        Else
            Me.objPaymentTypeIndex -= 1
            Me.PaymentType_Change()
        End If
    End Sub

    Private Sub PaymentType_IndexDown()
        ' Tidak berfungsi pada single type payment
        If Not Me.SelectedPaymentIsMulti Then Exit Sub

        ' Pembayaran pertama harus sesuai dengan payment type dasar
        If Not PaymentTypeCanBeChange() Then Exit Sub



        If Me.objPaymentTypeIndex >= Me.POS.PaymentType.DefaultView.Count - 1 Then
        Else
            Me.objPaymentTypeIndex += 1
            Me.PaymentType_Change()
        End If
    End Sub

    Private Sub PaymentType_IndexSet(ByVal id As String)
        Dim i As Integer
        'For i = 0 To Me.POS.PaymentType.Rows.Count - 1
        '    If Me.POS.PaymentType.Rows(i).Item("pospayment_id") = id Then
        '        Me.objPaymentTypeIndex = i
        '        Me.PaymentType_Change()
        '        Exit Sub
        '    End If
        'Next

        For i = 0 To Me.POS.PaymentType.DefaultView.Count - 1
            If Me.POS.PaymentType.DefaultView.Item(i).Item("pospayment_id") = id Then
                Me.objPaymentTypeIndex = i
                Me.PaymentType_Change()
                Exit Sub
            End If
        Next
    End Sub

    Private Sub PaymentType_Change()
        'Dim PaymentIsCash As Boolean

        ''Default Payment Type
        'If Me.POS.PaymentType.Rows.Count > 0 Then
        '    Me.objPaymentTypeName.ForeColor = Color.Black
        '    Me.objPaymentType.Text = Me.POS.PaymentType.Rows(Me.objPaymentTypeIndex).Item("pospayment_id").ToString
        '    Me.objPaymentTypeName.Text = Me.POS.PaymentType.Rows(Me.objPaymentTypeIndex).Item("pospayment_name").ToString
        '    PaymentIsCash = Me.POS.PaymentType.Rows(Me.objPaymentTypeIndex).Item("pospayment_iscash")
        '    RaiseEvent PaymentType_IndexChanged(Me.objPaymentTypeIndex, Me.objPaymentType.Text, Me.objPaymentTypeName.Text, PaymentIsCash)
        'Else
        '    Me.objPaymentTypeName.ForeColor = Color.Red
        '    Me.objPaymentType.Text = "0"
        '    Me.objPaymentTypeName.Text = "***Paym.NotLoaded***"
        'End If

        ''Me.objPaymentTypeId.AutoSize = True
        'Me.objPaymentTypeName.AutoSize = True



        Dim PaymentIsCash As Boolean

        'Default Payment Type
        If Me.POS.PaymentType.DefaultView.Count > 0 Then
            Me.objPaymentTypeName.ForeColor = Color.Black
            Me.objPaymentType.Text = Me.POS.PaymentType.DefaultView.Item(Me.objPaymentTypeIndex).Item("pospayment_id").ToString
            Me.objPaymentTypeName.Text = Me.POS.PaymentType.DefaultView.Item(Me.objPaymentTypeIndex).Item("pospayment_name").ToString
            PaymentIsCash = Me.POS.PaymentType.DefaultView.Item(Me.objPaymentTypeIndex).Item("pospayment_iscash")
            RaiseEvent PaymentType_IndexChanged(Me.objPaymentTypeIndex, Me.objPaymentType.Text, Me.objPaymentTypeName.Text, PaymentIsCash)
        Else
            Me.objPaymentTypeName.ForeColor = Color.Red
            Me.objPaymentType.Text = "0"
            Me.objPaymentTypeName.Text = "***Paym.NotLoaded***"
        End If

        'Me.objPaymentTypeId.AutoSize = True
        Me.objPaymentTypeName.AutoSize = True

    End Sub

    Private Sub PaymentType_IndexChange(ByVal index As Integer, ByVal id As String, ByVal name As String, ByVal PaymentIsCash As String) Handles Me.PaymentType_IndexChanged
        Dim BankName As String = ""

        If Me.POS.PaymentType.DefaultView.Item(index).Item("pospayment_bankname") IsNot DBNull.Value Then
            BankName = Me.POS.PaymentType.DefaultView.Item(index).Item("pospayment_bankname")
        End If

        If PaymentIsCash Then
            Me.objPaymentBank.Text = ""

            Me.lblPaymentBank.Enabled = False
            Me.objPaymentBank.Enabled = False

            Me.lblPaymentCardNumber.Enabled = False
            Me.objPaymentCardNumber.Enabled = False
            Me.lblPaymentCardHolder.Enabled = False
            Me.objPaymentCardHolder.Enabled = False
            Me.lblPaymentEdc.Enabled = False
            Me.objPaymentEdc.Enabled = False
            Me.lblPaymentInstallment.Enabled = False
            Me.objPaymentInstallment.Enabled = False

            Me.lblPaymentValue.Enabled = False
            Me.objPaymentValue.Enabled = False
            Me.lblPaymentCash.Enabled = True
            Me.objPaymentCash.Enabled = True

            Me.objApproval.Enabled = False
            Me.lblApproval.Enabled = False

            ' Me.objPaymentCash.Focus()

            Me.objPaymentValue.Text = Me.objPaymentOutstanding.Text

        Else
            Me.objPaymentBank.Text = BankName
            If BankName <> "" Then
                Me.lblPaymentBank.Enabled = False
                Me.objPaymentBank.Enabled = False
            Else
                Me.lblPaymentBank.Enabled = True
                Me.objPaymentBank.Enabled = True
            End If


            Me.objPaymentCardNumber.Text = ""
            Me.objPaymentCardHolder.Text = ""

            Me.lblPaymentCardNumber.Enabled = True
            If Me.POS.CARDNUMBER_ENTRY = "0" Then
                If Me.objPaymentType.Text.StartsWith("1") = True Then
                    If Me.objPaymentType.Text = "199" Then
                        Me.objPaymentCardNumber.Enabled = True
                        Me.objPaymentCardHolder.Enabled = True
                    Else
                        Me.objPaymentCardNumber.Enabled = False
                        Me.objPaymentCardHolder.Enabled = True
                        If (Me.objPaymentType.Text = "191") Then
                            Me.objPaymentCardNumber.Text = "VOUCTC0000000000"
                            Me.objPaymentCardHolder.Text = "VOUCH CTCORP"
                            Me.objPaymentCardHolder.Enabled = False
                        End If
                    End If
                Else
                    Me.objPaymentCardNumber.Enabled = True
                    Me.objPaymentCardHolder.Enabled = True
                End If

            Else
                Me.objPaymentCardNumber.Enabled = True
                Me.objPaymentCardHolder.Enabled = True
            End If


            Me.objApproval.Enabled = Me.objPaymentCardNumber.Enabled
            Me.lblApproval.Enabled = Me.objApproval.Enabled

            Me.lblPaymentCardHolder.Enabled = True

            Me.lblPaymentEdc.Enabled = True
            Me.objPaymentEdc.Enabled = True
            Me.lblPaymentInstallment.Enabled = True
            Me.objPaymentInstallment.Enabled = True

            Me.lblPaymentValue.Enabled = True
            Me.objPaymentValue.Enabled = True
            Me.lblPaymentCash.Enabled = False
            Me.objPaymentCash.Enabled = False

            Me.objPaymentCash.Text = "0"


        End If

        Me.BindingContext(Me.POS.PosPaymentDialog).EndCurrentEdit()
        Me.POS.PosPaymentDialog.AcceptChanges()

    End Sub

    Private Sub PaymentType_GetShortcut()
        Me.objPaymentShortcut.Text = ""

        Dim i As Integer
        Dim shortcut As String = ""
        Dim paymentname As String = ""
        Dim iscash As Boolean
        Dim id As String = ""
        For i = 0 To Me.POS.PaymentType.DefaultView.Count - 1
            If Me.POS.PaymentType.DefaultView.Item(i).Item("pospayment_shortcut").ToString <> "" Then
                shortcut = Me.POS.PaymentType.DefaultView.Item(i).Item("pospayment_shortcut").ToString
                paymentname = Me.POS.PaymentType.DefaultView.Item(i).Item("pospayment_name").ToString
                iscash = Me.POS.PaymentType.DefaultView.Item(i).Item("pospayment_iscash")
                id = Me.POS.PaymentType.DefaultView.Item(i).Item("pospayment_id").ToString

                If iscash Then
                    Select Case shortcut
                        Case "F9"
                            Me._KybShortcut_F9 = id
                            Me.objPaymentShortcut.Text &= paymentname & " - [F9 ]" & vbCrLf
                        Case "F11"
                            Me._KybShortcut_F11 = id
                            Me.objPaymentShortcut.Text &= paymentname & " - [F11]" & vbCrLf
                        Case "F12"
                            Me._KybShortcut_F12 = id
                            Me.objPaymentShortcut.Text &= paymentname & " - [F12]" & vbCrLf
                    End Select
                End If

            End If
        Next
        'Me.POS.PaymentType.Rows(PaymentTypeIndex)
    End Sub


#End Region


    Private Function getVoucherValue(ByVal vouchercode As String) As Decimal
        Dim vouvalcode As String = Mid(vouchercode, 2, 2)
        Dim vouval As Decimal

        Select Case vouvalcode
            Case "01"
                vouval = 500000
        End Select

        Return vouval
    End Function

    Private Sub dlg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TransStore.POS.PaymentNumerator = 0

        Me.TimerRefundBlink.Enabled = False
        Me.SuspendLayout()

        Dim obj As Control
        For Each obj In Me.Controls
            If obj.Name <> Me.PnlFormMain.Name Then
                Me.Controls.Remove(obj)
            End If
        Next


        ' Bersihkan data
        Me.POS.PosPayments.Rows.Clear()
        Me.POS.PosPaymentDialog.Rows.Clear()
        Me.POS.PosPaymentDialog.Rows.Add(Me.POS.PosPaymentDialog.NewRow())
        Me.objAuthName.Text = ""

        Me.BindingStart()
        Me.BindingContext(Me.POS.PosPaymentDialog).EndCurrentEdit()
        Me.POS.PosPaymentDialog.AcceptChanges()

        If Me.SelectedPaymentDisc > 0 Then
            If Me.NewTransactionParamValue.CustomerDisc > Me.SelectedPaymentDisc Then
                Me.SelectedDiscType = Me.NewTransactionParamValue.CustomerType
                Me.SelectedPaymentDisc = Me.NewTransactionParamValue.CustomerDisc
                Me.objPaymentDiscDescr.Text = String.Format("Using {0} with additional {1} disc {2:#0}%", Me.SelectedPaymentName, Me.SelectedDiscType, Me.SelectedPaymentDisc)
            Else
                Me.SelectedDiscType = Me.SelectedPaymentName
                Me.objPaymentDiscDescr.Text = String.Format("Using {0} with additional disc {1:#0}%", Me.SelectedPaymentName, Me.SelectedPaymentDisc)
            End If
        Else
            If Me.NewTransactionParamValue.CustomerDisc > 0 Then
                Me.SelectedDiscType = Me.NewTransactionParamValue.CustomerType
                Me.SelectedPaymentDisc = Me.NewTransactionParamValue.CustomerDisc
                Me.objPaymentDiscDescr.Text = String.Format("Using {0} with additional {1} disc {2:#0}% ", Me.SelectedPaymentName, Me.SelectedDiscType, Me.SelectedPaymentDisc)
            Else
                Me.SelectedDiscType = "NONE"
                Me.objPaymentDiscDescr.Text = String.Format("Using {0} with no additional disc.", Me.SelectedPaymentName)
            End If
        End If

        Me.objPaymentType.Enabled = False
        Me.objPaymentTypeName.Enabled = False





        If Me.POS.ALLOW_MULTIPLE_PAYMENT_IN_FP = "1" Then
            ' Filter Payment hanya bank yang dipilih
            'if me.SelectedPaymentId IN me.POS.FP_PAYMENT_FILTER 
            Dim usingfilter As Boolean = False
            Dim sFiltered() As String = Me.POS.FP_PAYMENT_FILTER.Split(",")
            Dim i As Integer
            For i = 0 To sFiltered.Length - 1
                If Me.SelectedPaymentId = Trim(sFiltered(i)) Then
                    usingfilter = True
                End If
            Next

            If usingfilter Then
                Me.POS.PaymentType.DefaultView.RowFilter = String.Format("pospayment_bankname='{0}'", Me.SelectedPaymentBank)
            Else
                Me.POS.PaymentType.DefaultView.RowFilter = ""
            End If
        End If



        If Me.POS.CARDNUMBER_ENTRY = "0" Then
            ' Disable Entry Card Number Manual
            Me.objPaymentBank.Enabled = False
            Me.objPaymentCardNumber.Enabled = False
            Me.objPaymentCardHolder.Focus()
        Else
            Me.objPaymentBank.Enabled = False
            Me.objPaymentCardNumber.Enabled = True
            Me.objPaymentCardNumber.Focus()
        End If


        Me.PaymentType_GetShortcut()



        Me.PaymentType_IndexSet(Me.SelectedPaymentId)
        Me.dlg_ItemCalculate()



        Me.PnlFormMain.Dock = DockStyle.Fill
        Me.PnlFormMain.BackColor = Color.Gainsboro

        If Me.SelectedPaymentIsVoucherDisabled And Me.SelectedPaymentIsAddDiscDisabled And Me.SelectedPaymentIsRedeemDisabled Then
            Me.objPaymentAdditional.Enabled = False
        Else
            Me.objPaymentAdditional.Enabled = True
        End If

        With Me.DgvPayments
            .DataSource = Me.POS.PosPayments
            .ReadOnly = True
            .TabStop = False
            .Anchor = AnchorStyles.Top + AnchorStyles.Bottom + AnchorStyles.Left + AnchorStyles.Right
        End With


        Me.objCustomerID.Text = Me.NewTransactionParamValue.CustomerId
        Me.objCustomerName.Text = Me.NewTransactionParamValue.CustomerName
        Me.objCustomerPassport.Text = Me.NewTransactionParamValue.CustomerPassport
        Me.objPaymentSalescode.Text = Me.NewTransactionParamValue.SalesId
        Me.objPaymentSalesname.Text = Me.NewTransactionParamValue.SalesName
        Me.objCustomerDisc.Text = Me.NewTransactionParamValue.CustomerDisc
        Me.objCustomerType.Text = Me.NewTransactionParamValue.CustomerType
        Me.objCustomerTelp.Text = Me.NewTransactionParamValue.CustomerTelp
        Me.objCustomerPassport.Text = Me.NewTransactionParamValue.CustomerPassport
        Me.BonExternalId = Me.NewTransactionParamValue.BonExternal
        Me.objPaymentVoucherCode.Text = Me.NewTransactionParamValue.Voucher01CodeNum



        Me.Refresh()
        Me.ResumeLayout()

        uiTrnPosEN.FormatDgvPOSPayments(Me.DgvPayments)
        uiTrnPosEN.BeepPopUp()



        Dim salesid As String = Trim(Me.objPaymentSalescode.Text)
        If salesid = "0" Or salesid = "" Then
            Me.objError.SetError(Me.objPaymentSalescode, "Sales Code belum diisi")
            Me.objPaymentSalescode.BackColor = Color.MistyRose
        End If

        Me.lblSCardNumber.Text = ""
        Me.lblSCardHolder.Text = ""






    End Sub

    Private Sub objPaymentValue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles objPaymentValue.GotFocus
        If Me.POS.MCRLAYER = "SINGLE" Then
            Me.SweepingCard = False
        End If
    End Sub

    Private Sub dlg_ObjectKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles objCustomerID.KeyDown, _
            objCustomerName.KeyDown, _
            objCustomerDisc.KeyDown, _
            objCustomerType.KeyDown, _
            objCustomerPassport.KeyDown, _
            objPaymentType.KeyDown, _
            objPaymentBank.KeyDown, _
            objPaymentCardNumber.KeyDown, _
            objPaymentCardHolder.KeyDown, _
            objApproval.KeyDown, _
            objPaymentEdc.KeyDown, _
            objPaymentValue.KeyDown, _
            objPaymentInstallment.KeyDown, _
            objPaymentCash.KeyDown, _
            objPaymentVoucherCode.KeyDown, _
            objPaymentVoucher.KeyDown, _
            objPaymentAddDisc.KeyDown, _
            objPaymentSalescode.KeyDown, _
            btnSalesBrowse.KeyDown

        Dim suppressglobalkeyprocess As Boolean
        Dim SuppressKeyPress As Boolean

        ' Dim obj As TextBox = CType(sender, TextBox)



        If Me.KeyCheck(sender, e.KeyCode, e.KeyValue, e.Control, suppressglobalkeyprocess, SuppressKeyPress) Then
            e.SuppressKeyPress = SuppressKeyPress
            If Not suppressglobalkeyprocess Then
                Key(sender, e.KeyCode, e.Control, Nothing)
            End If
        Else
            e.SuppressKeyPress = True
        End If


    End Sub


    Private Sub dlg_ItemCalculate()


        ' Hitung total qty
        Dim sumqty As Object = Me.POS.PosItems.Compute("Sum(bondetil_qty)", "")
        If IsDBNull(sumqty) Then
            Me.objPaymentTotalQty.Text = "0"
        Else
            Me.objPaymentTotalQty.Text = CInt(sumqty)
        End If

        ' Hitung total price value
        Dim sumsubtotal As Object = Me.POS.PosItems.Compute("Sum(bondetil_subtotal)", "")
        If IsDBNull(sumsubtotal) Then
            Me.objPaymentTotalValue.Text = "0"
        Else
            Me.objPaymentTotalValue.Text = CDec(sumsubtotal)
        End If

        ' Hitung additional disc
        Dim adddiscvoucher As Decimal = CDec(Me.objPaymentDiscVoucherTotal.Text)




        ' inisiasi transaksi tanpa discount payment
        Dim discvalue As Decimal = 0
        Me.objPaymentDiscDescr.Text = String.Format("Using {0} with no additional disc.", Me.SelectedPaymentName)


        ' Cek apakah ada discount brand untuk payment yang dipilih
        ' pada GetPaymentDiscount akan ambil discount di brand dan tanggal tertentu
        Dim paymdisc As TransStore.DiscountPayment = Me.POS.GetPaymentDiscount(Me.SelectedPaymentId, Me.POS.RegionId)
        If paymdisc.DiscountPercentage > 0 Or paymdisc.DiscountValue > 0 Then
            Me.SelectedPaymentDiscValue = paymdisc.DiscountValue
            Me.SelectedPaymentDisc = paymdisc.DiscountPercentage
            Me.SelectedPaymentDiscMinPurchase = paymdisc.MinimumValuePurchase
        End If


        ' Hitung nilai discount payment dan tampilkan ke layar
        Dim limit As String
        If (Me.SelectedPaymentDiscValue > 0) Then
            If (sumsubtotal >= Me.SelectedPaymentDiscMinPurchase) Then
                ' Discount menggunakan fix angka rupiah
                discvalue = Me.SelectedPaymentDiscValue
                Me.objPaymentDiscDescr.Text = String.Format("Using {0} with additional disc {1:#0}", Me.SelectedPaymentName, Me.SelectedPaymentDiscValue)
            End If

        ElseIf (Me.SelectedPaymentDisc > 0) Then
            If (sumsubtotal >= Me.SelectedPaymentDiscMinPurchase) Then
                ' Discount menggunakan persentase
                discvalue = (Me.SelectedPaymentDisc / 100) * CDec(sumsubtotal)

                ' limit discount value
                limit = ""
                If discvalue > paymdisc.MaximumDiscountValue And paymdisc.MaximumDiscountValue > 0 Then
                    discvalue = paymdisc.MaximumDiscountValue
                    limit = String.Format("max {0:#,##0}", paymdisc.MaximumDiscountValue)
                End If
                Me.objPaymentDiscDescr.Text = String.Format("Using {0} with additional disc {1:#0}% {2}", Me.SelectedPaymentName, Me.SelectedPaymentDisc, limit)
            End If

        Else
            ' Tanpa discount
            discvalue = 0
            Me.objPaymentDiscDescr.Text = String.Format("Using {0} with no additional disc.", Me.SelectedPaymentName)

        End If

        Me.objPaymentDiscValue.Text = discvalue

        ' Yang harus dibayar & nilai outstanding
        Dim total As Decimal = CDec(sumsubtotal) - discvalue - adddiscvoucher
        Me.objPaymentTOTAL.Text = total
        Me.objPaymentOutstanding.Text = total


        ' Masukkan ke nilai pembayaran
        If Me.objPaymentCash.Enabled Then
            Me.objPaymentValue.Text = total
            Me.objPaymentCash.Text = total
        Else
            Me.objPaymentValue.Text = total
        End If


        Me.BindingContext(Me.POS.PosPaymentDialog).EndCurrentEdit()
        Me.POS.PosPaymentDialog.AcceptChanges()

    End Sub

    Private Sub dlg_VoucherRecalculate(ByVal vouchercode As String, ByVal voucher As Decimal, ByVal adddisc As Decimal, ByVal redeem As Decimal)
        Dim type As String = Me.objPaymentType.Text
        Dim typename As String = Me.objPaymentTypeName.Text
        Me.POS.PosPaymentDialog.AcceptChanges()

        Me.objPaymentType.Text = type
        Me.objPaymentTypeName.Text = typename

        Me.objPaymentVoucherCode.Text = vouchercode
        Me.objPaymentVoucher.Text = voucher
        Me.objPaymentAddDisc.Text = adddisc
        Me.objPaymentRedeem.Text = redeem


        ' Hitung kembali pembayaran
        Dim totalvalue As Decimal = CDec(Me.objPaymentTotalValue.Text)
        Dim carddisc As Decimal = CDec(Me.objPaymentDiscValue.Text)
        Dim adddiscvoucher As Decimal = voucher + adddisc + redeem

        If adddiscvoucher > totalvalue Then
            adddiscvoucher = totalvalue
        End If

        Dim sumsubtotal As Decimal = totalvalue - adddiscvoucher


        ' Hitung ulang additional payment disc
        Dim discvalue As Decimal = (Me.SelectedPaymentDisc / 100) * CDec(sumsubtotal)
        Dim total As Decimal = sumsubtotal - discvalue

        Me.objPaymentDiscValue.Text = discvalue
        Me.objPaymentDiscVoucherTotal.Text = adddiscvoucher
        Me.objPaymentTOTAL.Text = total
        Me.objPaymentOutstanding.Text = total



        If Me.SelectedPaymentDisc > 0 Then
            Me.objPaymentDiscDescr.Text = String.Format("Using {0} with additional disc {1:#0}% of {2:#,##0}", Me.SelectedPaymentName, Me.SelectedPaymentDisc, sumsubtotal)
        Else
            Me.objPaymentDiscDescr.Text = String.Format("Using {0} with no additional disc.", Me.SelectedPaymentName)
        End If


        If Me.objPaymentCash.Enabled Then
            Me.objPaymentValue.Text = total
            Me.objPaymentCash.Text = total
        Else
            Me.objPaymentValue.Text = total
        End If

        Me.BindingContext(Me.POS.PosPaymentDialog).EndCurrentEdit()
        Me.POS.PosPaymentDialog.AcceptChanges()



        Dim OutstandingPayment As Decimal
        OutstandingPayment = CDec(Me.objPaymentTOTAL.Text)
        If OutstandingPayment <= 0 Then
            Me.objPaymentInformation.Enabled = False
            Me.objPaymentSalescode.SelectionStart = Len(Me.objPaymentSalescode.Text)
            Me.objPaymentSalescode.SelectionLength = 0
            Me.btnSalesBrowse.Focus()
        End If
    End Sub


    Private Sub dlgPaymentCommitAndClose(ByVal objBon As TransStore.POS.PosHeader)
        Dim ret As uiTrnPosEN.PosPaymentEventArgument = New uiTrnPosEN.PosPaymentEventArgument
        ret.objBon = objBon
        Me.myRetObj = New Object() {ret}
        uiTrnPosEN.BeepDef2()
        Me.Close()
    End Sub

    Private Sub dlgCancel()
        ' Me.myRetObj = New Object() {}

        ' Confirm Exit
        Dim args As Object = New Object() {}
        Dim f As dlgConfirmYesNo = New dlgConfirmYesNo
        Dim result As Object
        Dim fmask As Form = uiTrnPosEN.CreateMask(0.75)

        f.BeepOnOK = False
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Message = "Batalkan Pembayaran ?"
        fmask.Show(Me)
        result = f.OpenDialog(fmask, args)
        fmask.Close()
        fmask.Dispose()
        f.Dispose()
        If result IsNot Nothing Then
            uiTrnPosEN.BeepPopDown()
            Me.POS = Nothing
            Me.Close()
        End If

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


    Private Sub dlgTrnPosPayment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If Me.Focused Then
            If e.KeyValue = 27 Then
                If Me.DgvPayments.ReadOnly Then
                    Me.dlgCancel()
                    Exit Sub
                End If
            End If
        End If

    End Sub

    Private Sub DgvPayments_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgvPayments.KeyDown

        If e.KeyValue = 27 Then
            If Me.DgvPayments.ReadOnly Then
                Me.dlgCancel()
                Exit Sub
            End If
        End If

        If Not Me.DgvPayments.ReadOnly Then
            If (e.KeyValue >= 48 And e.KeyValue <= 57) Or _
               (e.KeyValue >= 96 And e.KeyValue <= 105) _
            Then
                Exit Sub
            Else
                Me.Key(sender, Keys.F3, False, Nothing)
                ' Me.txtItemEntry.Focus()
                Exit Sub
            End If

        End If


        If e.KeyCode = Keys.Delete Then
            Me.Key(sender, Keys.Delete, False, Nothing)
        End If

        If e.KeyCode = Keys.F10 Then
            If Not Me.objPaymentInformation.Enabled Then
                Me.Key(sender, Keys.F10, False, Nothing)
            End If
        End If

        'If e.Control Or e.Alt Or e.Shift Then
        '    Me.txtItemEntry.Focus()
        '    Exit Sub
        'End If

        'If e.KeyValue = 9 Or e.KeyValue = 20 Then
        '    Me.txtItemEntry.Focus()
        '    Exit Sub
        'End If

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

    Private Sub objPaymentTypeName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles objPaymentTypeName.GotFocus
        Me.objPaymentCardNumber.Focus()
    End Sub

    Private Sub objPaymentValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles objPaymentValue.KeyPress
        Me.hndPaymentValueKeyEv = True
    End Sub

    Private Sub objPaymentValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles objPaymentValue.TextChanged
        Me.SweepingCard = False
        Me.dlg_MoneyTyped(sender, Me.tempLastValue)
    End Sub

    Private Sub objPaymentCash_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles objPaymentCash.TextChanged
        Me.dlg_MoneyTyped(sender, Me.tempLastCash)
    End Sub

    Private Sub TimerRefundBlink_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerRefundBlink.Tick
        Me.objPaymentTotalRefund.Visible = Not Me.objPaymentTotalRefund.Visible
    End Sub

    Private Sub objPaymentTotalRefund_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles objPaymentTotalRefund.TextChanged
        Dim refund As Decimal = CDec(Me.objPaymentTotalRefund.Text)

        If refund > 0 Then
            Me.TimerRefundBlink.Enabled = True
        Else
            Me.TimerRefundBlink.Enabled = False
        End If
    End Sub


    Private Function ScanCard(ByVal obj As TextBox) As Boolean
        Dim temptext As String = obj.Text
        Dim pospayment_prefix As String = ""
        Dim firstnamechar As String
        Dim firstpaymentprefix As String


        Try
            Select Case temptext.Substring(0, 1)
                Case "%"
                    firstpaymentprefix = obj.Text.Substring(2, 1)
                    If firstpaymentprefix = "0" Or firstpaymentprefix = "1" Or firstpaymentprefix = "2" Or firstpaymentprefix = "3" Or firstpaymentprefix = "4" Or firstpaymentprefix = "5" Or firstpaymentprefix = "6" Or firstpaymentprefix = "7" Or firstpaymentprefix = "8" Or firstpaymentprefix = "9" Then
                        Me.objPaymentCardNumber.Text = temptext.Substring(2, 16)
                    Else
                        Me.objPaymentCardNumber.Text = temptext.Substring(3, 16)
                    End If

                    firstnamechar = Trim(temptext.Substring(19, 1))
                    If firstnamechar = "^" Then
                        Me.objPaymentCardHolder.Text = temptext.Substring(20, 25)
                    Else
                        Me.objPaymentCardHolder.Text = temptext.Substring(19, 25)
                    End If

                Case ";"
                    firstpaymentprefix = obj.Text.Substring(1, 1)
                    If firstpaymentprefix = "0" Or firstpaymentprefix = "1" Or firstpaymentprefix = "2" Or firstpaymentprefix = "3" Or firstpaymentprefix = "4" Or firstpaymentprefix = "5" Or firstpaymentprefix = "6" Or firstpaymentprefix = "7" Or firstpaymentprefix = "8" Or firstpaymentprefix = "9" Then
                        Me.objPaymentCardNumber.Text = temptext.Substring(1, 16)
                    Else
                        Me.objPaymentCardNumber.Text = temptext.Substring(2, 16)
                    End If

                    firstnamechar = Trim(temptext.Substring(1, 1))
                    If firstnamechar = "^" Then
                        Me.objPaymentCardHolder.Text = temptext.Substring(2, 16)
                    Else
                        Me.objPaymentCardHolder.Text = temptext.Substring(1, 16)
                    End If
                Case Else
                    ' bukan scan kartu kredit
                    Return False
            End Select
            pospayment_prefix = Me.objPaymentCardNumber.Text.Substring(0, _CardPrefixLength)
        Catch ex As Exception
        End Try



        ' Masukkan ke S Label
        Me.lblSCardNumber.Text = Me.objPaymentCardNumber.Text
        Me.lblSCardHolder.Text = Me.objPaymentCardHolder.Text


        ' Cari kode untuk OTHER CARD
        Dim OtherCardPaymentType As String = ""
        Dim OtherCardPaymentTypeName As String = ""
        Dim UsingOtherCardMethod As Boolean = False
        Dim dr() As DataRow
        dr = Me.POS.PaymentType.Select("pospayment_prefix = 'OTHER'")
        If dr.Length > 0 Then
            OtherCardPaymentType = dr(0).Item("pospayment_id").ToString
            OtherCardPaymentTypeName = dr(0).Item("pospayment_name").ToString
            If Me.SelectedPaymentId = OtherCardPaymentType Then
                UsingOtherCardMethod = True
            End If
        End If


        ' -------------------------------------------------------------
        'Cek kartu apa yang digesek
        Dim scanned_paymenttype As String = ""
        Dim scanned_paymenttypename As String = ""
        Dim scanned_paymentbank As String = ""

        dr = Me.POS.PaymentType.Select(String.Format("pospayment_prefix LIKE '%{0}%'", pospayment_prefix))
        If dr.Length > 0 Then
            ' Payment Type diisi 
            scanned_paymenttype = dr(0).Item("pospayment_id").ToString
            scanned_paymenttypename = dr(0).Item("pospayment_name").ToString
            scanned_paymentbank = dr(0).Item("pospayment_bankname").ToString
            'Me.objPaymentBank.Enabled = False
        Else
            ' Kalo tidak ketemu diisi other CC
            scanned_paymenttype = OtherCardPaymentType
            scanned_paymenttypename = OtherCardPaymentTypeName
            scanned_paymentbank = ""
            'Me.objPaymentBank.Enabled = True
        End If



        ' Pada gesek kartu pertama, nama banknya harus sesuai
        ' Jika bukan kartu utama (DGV sudah diisi, baris payment > 0), isi type pembayaran
        If Me.DgvPayments.Rows.Count = 0 And Not UsingOtherCardMethod Then
            ' Cek kartu utama
            'Dim InvalidCard As Boolean = True
            'Dim drsb() As DataRow = Me.POS.PaymentType.Select(String.Format("pospayment_id='{0}'", Me.objPaymentType.Text))
            'Dim CurrentSelectedBankName As String
            'If drsb.Length > 0 Then
            '    CurrentSelectedBankName = drsb(0).Item("pospayment_bankname").ToString
            '    If CurrentBankName <> Me.SelectedPaymentBank Then
            '        InvalidCard = True
            '    Else
            '        InvalidCard = False
            '    End If
            'End If
            'If scanned_paymentbank <> Me.SelectedPaymentBank Then
            '    InvalidCard = True
            'Else
            '    InvalidCard = False
            'End If

            'If InvalidCard Then
            '    Dim msg = String.Format("'{0}' is not a valid {1} Card Number", Me.objPaymentCardNumber.Text, Me.SelectedPaymentBank)
            '    Me.objErrorProvider.SetError(Me.objPaymentCardNumber, msg)
            '    Me.objPaymentCardNumber.BackColor = Color.Coral
            '    Me.objPaymentCardNumber.Focus()
            '    MessageBox.Show(msg, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Else
            '    Me.objErrorProvider.SetError(Me.objPaymentCardNumber, "")
            '    Me.objPaymentCardNumber.BackColor = Color.White
            '    Me.objPaymentValue.Focus()
            'End If

        Else
            ' pembayaran kedua, atau lebih
            If Me.POS.CARDNUMBER_ENTRY = "0" Then
                Me.objPaymentCardNumber.Enabled = False
            End If

            Me.objPaymentType.Text = scanned_paymenttype
            Me.objPaymentTypeName.Text = scanned_paymenttypename
            Me.objPaymentBank.Text = scanned_paymentbank
            Me.PaymentType_IndexSet(scanned_paymenttype)
        End If



        'If Me.DgvPayments.Rows.Count > 0 Or UsingOtherCardMethod Then 'obj.Name = "objPaymentBank" Then
        '    Me.objPaymentType.Text = paymenttype
        '    Me.objPaymentTypeName.Text = paymenttypename
        '    Me.objPaymentBank.Text = paymentbank
        '    If Not isothercc Then
        '        Me.objPaymentValue.Focus()
        '    Else
        '        Me.objPaymentBank.Focus()
        '    End If
        'ElseIf Me.DgvPayments.Rows.Count = 0 Then
        '    'Menggunakan kartu utama, dan bukan other cek apakah prefixnya benar
        '    Dim InvalidCard As Boolean = True
        '    Dim drsb() As DataRow = Me.POS.PaymentType.Select(String.Format("pospayment_id='{0}'", Me.objPaymentType.Text))
        '    Dim CurrentBankName As String
        '    If drsb.Length > 0 Then
        '        CurrentBankName = drsb(0).Item("pospayment_bankname").ToString
        '        If CurrentBankName <> Me.SelectedPaymentBank Then
        '            InvalidCard = True
        '        Else
        '            InvalidCard = False
        '        End If
        '    End If


        '    If Not isothercc Then
        '        If Me.objPaymentType.Text <> paymenttype Then
        '            ' Ambil nama bank dari tipe payment yang dipilih


        '            ' If InvalidCard Then
        '            Dim msg = String.Format("'{0}' is not a valid {1} Card Number", Me.objPaymentCardNumber.Text, Me.objPaymentTypeName.Text)
        '            Me.objErrorProvider.SetError(Me.objPaymentCardNumber, msg)
        '            Me.objPaymentCardNumber.BackColor = Color.Coral
        '            MessageBox.Show(msg, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            Me.objPaymentCardNumber.Focus()
        '            ' End If


        '        Else

        '            Me.objErrorProvider.SetError(Me.objPaymentCardNumber, "")
        '            Me.objPaymentCardNumber.BackColor = Color.White
        '            Me.objPaymentValue.Focus()
        '        End If
        '    Else
        '        Me.objPaymentBank.Enabled = True
        '        Me.objPaymentBank.Focus()
        '    End If
        'End If


        ';4201910193174918=14052010000019900000?
        Return True

    End Function

    Private Sub btnSalesBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalesBrowse.Click
        uiTrnPosEN.BrowseSalesPerson(Me, Me.objPaymentSalescode, Me.objPaymentSalesname, Me.POS)
        If Me.objPaymentInformation.Enabled Then
            Me.objPaymentCardNumber.Focus()
        Else
            Me.objPaymentSalescode.Focus()
        End If

        If Trim(Me.objPaymentSalescode.Text) <> "" Then
            Me.objError.SetError(Me.objPaymentSalescode, "")
            Me.objPaymentSalescode.BackColor = Color.Gainsboro
        End If
    End Sub

    Private Sub dlg_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.POS = Nothing
    End Sub

    Private Sub dlgTrnPosPayment_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.POS = Nothing
    End Sub

    Private Sub objPaymentInformation_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles objPaymentInformation.EnabledChanged
        Dim pnl As Panel = CType(sender, Panel)
        If pnl.Enabled Then
            Me.TimerF10Blink.Enabled = False
            Me.lblFinish01.Visible = False
            Me.lblFinish02.Visible = False
            Me.lblFinish03.Visible = False
        Else
            Me.TimerF10Blink.Enabled = True
            Me.lblFinish01.Visible = True
            Me.lblFinish02.Visible = True
            Me.lblFinish03.Visible = True
        End If
    End Sub

    Private Sub TimerF10Blink_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerF10Blink.Tick
        Me.lblFinish02.Visible = Not Me.lblFinish02.Visible
    End Sub

    Private Sub lblExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblExit.Click
        dlgCancel()
    End Sub

    Private Sub objPaymentOutstanding_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles objPaymentOutstanding.Click
        If Me.objPaymentValue.Enabled Then
            Me.SweepingCard = False
            Me.objPaymentValue.Text = Me.objPaymentOutstanding.Text
        End If

    End Sub

    Private Sub btn_EditCustomer_Click(sender As Object, e As EventArgs) Handles btn_EditCustomer.Click
        Dim dlg As dlgCustomerEdit = New dlgCustomerEdit

        dlg.CustomerId = Me.objCustomerID.Text
        dlg.CustomerName = Me.objCustomerName.Text
        dlg.CustomerTelp = Me.objCustomerTelp.Text
        dlg.CustomerEmail = Me.objCustomerPassport.Text  ' yang ini memang email = passport, mbuh lah
        dlg.CustomerType = Me.objCustomerType.Text
        dlg.CustomerDisc = CDec(Me.objCustomerDisc.Text)

        dlg.StartPosition = FormStartPosition.CenterScreen
        dlg.WindowState = FormWindowState.Normal
        dlg.POS = Me.POS

        Dim res As DialogResult = dlg.ShowDialog(Me)
        If res = Windows.Forms.DialogResult.OK Then
            Me.objCustomerID.Text = dlg.CustomerId
            Me.objCustomerName.Text = dlg.CustomerName
            Me.objCustomerTelp.Text = dlg.CustomerTelp
            Me.objCustomerPassport.Text = dlg.CustomerEmail ' yang ini juga, aneh kan... rodo edan
        End If
    End Sub

    Private Sub objPaymentTypeName_TextChanged(sender As Object, e As EventArgs) Handles objPaymentTypeName.TextChanged
        Dim obj As Label = sender

        If obj.Text = "GARUDA" Then
            Me.objPaymentCardNumber.Text = "0000000000000000"
            Me.objPaymentCardHolder.Text = "GARUDA MILES CUST"
        Else
            Me.objPaymentCardNumber.Text = ""
            Me.objPaymentCardHolder.Text = ""
        End If

    End Sub

    Private Sub objPaymentCardNumber_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles objPaymentCardNumber.Validated
        Dim vouval = Me.getVoucherValue(Me.objPaymentCardNumber.Text)
        Try
            Me.objPaymentValue.Text = vouval.ToString("#,##0")
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub lblobjPaymentType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblobjPaymentType.Click
        ' Page Down

    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click
        ' Page Up

    End Sub



    Private Sub btn_Qris_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Qris.Click
        Dim param As New MobilePaymentParameter()
        If Me.objPaymentType.Text = "100" Then
            param.payment_type = "042630"
        ElseIf Me.objPaymentType.Text = "104" Then
            param.payment_type = "042600"
        Else
            param.payment_type = "000000"
        End If

        QRPayment(param)
    End Sub

    Private Sub btn_Allo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Allo.Click
        Dim param As New MobilePaymentParameter()
        param.payment_type = "000000"
        QRPayment(param)
    End Sub



    Private Sub QRPayment(ByVal param As MobilePaymentParameter)
        If (Me.DgvPayments.RowCount > 0) Then
            MessageBox.Show("Pembayaran dengan Qris tidak bisa split payment", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim dlg As dlgMobilePayment = New dlgMobilePayment
        dlg.ShowInTaskbar = False
        dlg.StartPosition = FormStartPosition.CenterScreen
        dlg.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        dlg.MaximizeBox = False
        dlg.MinimizeBox = False


        Dim outstanding As Decimal = CDec(Me.objPaymentOutstanding.Text)

        If Me.bgwQRGenerate Is Nothing Then
            Me.bgwQRGenerate = New System.ComponentModel.BackgroundWorker
            Me.bgwQRGenerate.WorkerReportsProgress = True
            Me.bgwQRGenerate.WorkerSupportsCancellation = True
        End If


        param.RegionBranch = Me.POS.RegionId & "-" & Me.POS.BranchId
        param.Amount = outstanding


        Me.objPaymentInformation.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Me.bgwQRGenerate.RunWorkerAsync(param)


        'param.mid = "5555"
        'param.tid = "1111"
        'param.QRData = "123455"
        'param.ReffNum = "MID65456456"

        'dlg.SetParameter(param)

        'Dim res As DialogResult = dlg.ShowDialog(Me)
        'Dim payresult As MobilePaymentResult = dlg.PaymentResult
        'dlg.Dispose()
        'dlg = Nothing

        'If res = Windows.Forms.DialogResult.Yes Then
        '    Me.objPaymentCardNumber.Text = payresult.PaymentSource
        '    Me.objPaymentCardHolder.Text = payresult.CustomerName
        '    Me.objPaymentValue.Text = payresult.PaymentValue
        '    Me.objPaymentCash.Text = "0"
        '    Me.objPaymentBank.Text = payresult.source_id
        '    Me.objApproval.Text = payresult.ApprovalCode
        '    Me.objPaymentEdc.Text = "ALLO"
        '    Me.objPaymentEdcName.text = payresult.ReffNo
        '    Me.Key(Me.objPaymentValue, Keys.F5, False) ' Add To Payment
        '    Me.Key(Me, Keys.F10, False) ' Save Transaction
        'End If

    End Sub


  
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



#Region " QR Generator "

    Private Sub bgwQRGenerate_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwQRGenerate.DoWork
        Dim res As MobilePaymentResult = New MobilePaymentResult

        Try
            Dim param As MobilePaymentParameter = CType(e.Argument, MobilePaymentParameter)
            Dim wsaddress As String = Me.POS.QrisProxy
            Dim ws As POS05EN.FGTAWebService = New POS05EN.FGTAWebService(wsaddress)



            ' Ambil data mid tid
            Dim args As New Newtonsoft.Json.JavaScriptObject()
            args.Item("region_id") = Me.POS.RegionId
            args.Item("branch_id") = Me.POS.BranchId
            args.Item("machine_id") = Me.POS.MachineId

            Dim apires As Newtonsoft.Json.JavaScriptObject = ws.Execute("pg/mega/qr/getmachineinfo", args)
            Dim result As Newtonsoft.Json.JavaScriptObject = apires.Item("result")
            Dim success As Boolean = result.Item("success")

            If Not success Then
                Throw New Exception("Kode MID dan TID tidak ditemukan")
            End If

            param.mid = result.Item("mid")
            param.tid = result.Item("tid")
            param.storename = result.Item("storename")



            Dim qrargs As New Newtonsoft.Json.JavaScriptObject()
            qrargs.Item("mid") = param.mid
            qrargs.Item("tid") = param.tid
            qrargs.Item("amount") = param.Amount
            qrargs.Item("payment_type") = param.payment_type

            Dim qrres As Newtonsoft.Json.JavaScriptObject = ws.Execute("pg/mega/qr/generate", qrargs)
            Dim qrresult As Newtonsoft.Json.JavaScriptObject = qrres.Item("result")
            Dim pgmessage As String = qrresult.Item("pgmessage")

            Dim txInfo As Newtonsoft.Json.JavaScriptObject = Newtonsoft.Json.JavaScriptConvert.DeserializeObject(pgmessage)
            success = txInfo.Item("success")
            If Not success Then
                Dim error_message = txInfo.Item("error_message")
                Throw New Exception("Generate QR Error" & vbCrLf & error_message)
            End If

            Dim RC As String = txInfo.Item("RC")
            Dim RCDesc As String = txInfo.Item("RCDesc")

            If RC = "00" Then
                Dim QRCode As String = txInfo.Item("QRCode")
                Dim ReffNo As String = txInfo.Item("ReffNo")
                Dim error_message As String = txInfo.Item("error_message")

                res.Parameter = param
                With res.Parameter
                    .QRData = QRCode
                    .ReffNum = ReffNo
                End With
                res.success = True
            Else
                res.success = False
                res.error_message = RCDesc
            End If

          
            e.Result = res
        Catch ex As Exception
            res.success = False
            res.error_message = ex.Message
            e.Result = res
        End Try
    End Sub

    Private Sub bgwQRGenerate_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwQRGenerate.RunWorkerCompleted
        Dim res As MobilePaymentResult = New MobilePaymentResult


        Try
            res = CType(e.Result, MobilePaymentResult)
            If Not res.success Then
                Throw New Exception(res.error_message)
            End If


            'MessageBox.Show(res.Parameter.QRData, res.Parameter.ReffNum)
            Dim dlg As dlgMobilePayment = New dlgMobilePayment
            dlg.ShowInTaskbar = False
            dlg.StartPosition = FormStartPosition.CenterScreen
            dlg.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            dlg.MaximizeBox = False
            dlg.MinimizeBox = False

            dlg.SetParameter(Me.POS, res.Parameter)

            Dim dlgres As DialogResult = dlg.ShowDialog(Me)
            Dim payresult As MobilePaymentResult = dlg.PaymentResult
            dlg.Dispose()
            dlg = Nothing

            If dlgres = Windows.Forms.DialogResult.Yes Then
                Me.objPaymentCardNumber.Text = payresult.PaymentSource
                Me.objPaymentCardHolder.Text = payresult.CustomerName
                Me.objPaymentValue.Text = payresult.PaymentValue
                Me.objPaymentCash.Text = "0"
                Me.objPaymentBank.Text = payresult.source_id
                Me.objApproval.Text = payresult.ApprovalCode
                Me.objPaymentEdc.Text = "QRIS"
                Me.objPaymentEdcName.Text = payresult.ReffNo

                Dim paymintparam As PaymentInteractionParam = New PaymentInteractionParam()
                paymintparam.skipcheck_digit = True
                paymintparam.skipcheck_prefix = True

                Me.Key(Me.objPaymentValue, Keys.F5, False, paymintparam) ' Add To Payment
                Me.Key(Me, Keys.F10, False, Nothing) ' Save Transaction

            End If

            Me.Cursor = Cursors.Default
            Me.objPaymentInformation.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mobile Payment", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub




#End Region


    Private Sub btn_redeemVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_redeemVoucher.Click
        Dim res As DialogResult
        Dim dlg As dlgRedeemVoucher = New dlgRedeemVoucher()
        dlg.setPOS(Me.POS)

        res = dlg.ShowDialog(Me)
        If res = Windows.Forms.DialogResult.OK Then
            Dim vou As dlgRedeemVoucher.VoucherData = dlg.getVoucherData()

            If vou.isValue Then

                If vou.isCashVoucher Then
                    ' Cash Voucher

                    MessageBox.Show("cash voucher not implemented")
                Else

                    Me.objPaymentAddDisc.Text = String.Format(vou.Value, "{0:#,##0}")
                    Me.objPaymentVoucherCode.Text = vou.Id

                    Dim PaymentVoucher As Decimal = CDec(Me.objPaymentVoucher.Text)
                    Dim PaymentAddDisc As Decimal = CDec(vou.Value)
                    Dim PaymentRedeem As Decimal = CDec(Me.objPaymentRedeem.Text)

                    Dim customername = Me.objCustomerName.Text
                    Me.dlg_VoucherRecalculate( _
                          Me.objPaymentVoucherCode.Text, _
                          PaymentVoucher, _
                          PaymentAddDisc, _
                          PaymentRedeem _
                    )
                    Me.objCustomerName.Text = customername
                End If

            Else
                Dim totalvalue As Decimal = CDec(Me.objPaymentTotalValue.Text)
                If (vou.Value < 1) Then
                    Dim adddisc = totalvalue * vou.Value
                    vou.Value = adddisc
                End If


                Me.objPaymentAddDisc.Text = String.Format(vou.Value, "{0:#,##0}")
                Me.objPaymentVoucherCode.Text = vou.Id

                Dim PaymentVoucher As Decimal = CDec(Me.objPaymentVoucher.Text)
                Dim PaymentAddDisc As Decimal = CDec(vou.Value)
                Dim PaymentRedeem As Decimal = CDec(Me.objPaymentRedeem.Text)

                Dim customername = Me.objCustomerName.Text
                Me.dlg_VoucherRecalculate( _
                      Me.objPaymentVoucherCode.Text, _
                      PaymentVoucher, _
                      PaymentAddDisc, _
                      PaymentRedeem _
                )
                Me.objCustomerName.Text = customername


            End If


        End If

    End Sub

    Private Sub lblFinish02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFinish02.Click

    End Sub

    Private Sub btnAddToPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToPayment.Click
        Me.Key(sender, Keys.F5, False, Nothing)
    End Sub
End Class
