Public Class dlgTrnPosVoucher

    Private Const __MEGAMAY_PROMO As String = "MEGAMAY14"


    Dim myRetObj As Object

    Private adddiscauto As Decimal
    Private adddiscminimaltotal As Decimal
    Private total As Decimal
    Private voucherid As String
    Private vouchercode As String
    Private voucher As Decimal
    Private adddisc As Decimal
    Private redeem As Decimal
    Private paymentname As String
    Private paymentdisc As Decimal
    Private IsVoucherDisabled As Boolean
    Private IsAddDiscDisabled As Boolean
    Private IsRedeemDisabled As Boolean

    Private temp_voucher As Decimal
    Private temp_adddisc As Decimal
    Private temp_redeem As Decimal


    Private POS As TransStore.POS


    Private tblDialog As DataTable = TransStore.POS.CreateDataTablePosVoucherDialog()
    Private objParamValue As TransStore.PosVoucherDialogParamValue = New TransStore.PosVoucherDialogParamValue



#Region " Constructor "

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, ByVal args As Object) As Object

        Try
            Me.objParamValue = CType(args(0), TransStore.PosVoucherDialogParamValue)
            With Me.objParamValue
                Me.adddiscauto = .AddDiscAuto
                Me.adddiscminimaltotal = .AddDiscMinimalTotal
                Me.total = .PaymentTotalValue
                Me.paymentname = .SelectedPaymentName
                Me.paymentdisc = .SelectedPaymentDisc
                Me.IsVoucherDisabled = .SelectedPaymentIsVoucherDisabled
                Me.IsAddDiscDisabled = .SelectedPaymentIsAddDiscDisabled
                Me.IsRedeemDisabled = .SelectedPaymentIsRedeemDisabled
                Me.voucherid = .VoucherId
                Me.vouchercode = .PaymentVoucherCode
                Me.voucher = .PaymentVoucher
                Me.adddisc = .PaymentAddDisc
                Me.redeem = .PaymentRedeem
                Me.POS = .POS
                Me.objUsername.Text = .authusername
            End With



            If Me.objParamValue.MODE = 1 Then
                'Me.Group01.Enabled = True
                Me.Group02.Enabled = False
            Else
                '  Me.Group01.Enabled = False
                Me.Group02.Enabled = True
            End If


        Catch ex As Exception
            Me.Close()
            Throw ex
        End Try

        MyBase.ShowDialog(owner)
        Return myRetObj
    End Function

#End Region


#Region " Layout & UI "

    Public Function BindingStart() As Boolean
        Me.objPaymentVoucher.DataBindings.Add(New Binding("Text", Me.tblDialog, "payment_voucher", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.objPaymentVoucherCode.DataBindings.Add(New Binding("Text", Me.tblDialog, "payment_vouchercode"))
        Me.objPaymentAddDisc.DataBindings.Add(New Binding("Text", Me.tblDialog, "payment_adddisc", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
    End Function

#End Region

#Region " Listener "

    Public Function KeyCheck(ByVal sender As Object, ByVal keycode As System.Windows.Forms.Keys, ByVal keyvalue As Integer, ByVal ctrl As Boolean, ByRef suppressglobalkeyprocess As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        Dim obj As Control = sender
        Select Case obj.Name
            Case "objPaymentVoucher"
                If keycode = Keys.Enter Then
                    Me.dlgOK()
                End If
            Case "objPaymentAddDisc"
                If keycode = Keys.Enter Then
                    Me.dlgOK()
                End If
            Case "objPaymentRedeem"
                If keycode = Keys.Enter Then
                    Me.dlgOK()
                End If
            Case "objUsername"
                If keycode = Keys.Enter Then
                    If objUsername.Text <> "" Then
                        Me.objPassword.Focus()
                    End If
                End If

            Case "objPassword"
                If keycode = Keys.Enter Then
                    If objPassword.Text <> "" Then
                        Me.btnOpen_Click(sender, New System.EventArgs)
                    End If
                End If
        End Select

        Select Case keycode
            Case Keys.Escape
                dlgCancel()
        End Select

        Return True
    End Function

    Public Function Key(ByVal sender As Object, ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean) As Boolean
        Dim obj As Control = sender

        Select Case keycode
            Case Keys.F8
                If Me.total >= Me.adddiscminimaltotal Then
                    Me.lblAuthOpen_Click(sender, New System.EventArgs)
                    If Me.objUsername.Enabled Then
                        Me.objUsername.Focus()
                    Else
                        Me.objPassword.Focus()
                    End If
                Else
                    MessageBox.Show(String.Format("Untuk tambahan discount minimal belanja harus {0:#,##0}", Me.adddiscminimaltotal), "Additional Discount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If


            Case Keys.F10
                Me.dlgOK()

        End Select



    End Function



#End Region


    Private Sub dlg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SuspendLayout()

        Dim obj As Control
        For Each obj In Me.Controls
            If obj.Name <> Me.PnlFormMain.Name Then
                Me.Controls.Remove(obj)
            End If
        Next

        Dim dr As DataRow = Me.tblDialog.NewRow()
        Me.tblDialog.Rows.Add(dr)
        Me.BindingStart()


        Me.objPaymentVoucherCode.Enabled = Not Me.IsVoucherDisabled
        Me.objPaymentVoucher.Enabled = Not Me.IsVoucherDisabled
        Me.objPaymentAddDisc.Enabled = False


        If Me.voucherid = __MEGAMAY_PROMO Then
            Me.obj_VoucherId.Text = Me.voucherid
            'Me.objPaymentVoucherCode.Enabled = False
        Else
            Me.obj_VoucherId.Text = ""
        End If


        If Me.IsAddDiscDisabled Then
            Me.objUsername.Enabled = False
            Me.objPassword.Enabled = False
            Me.btnOpen.Enabled = False
            Me.pnlAuth1.Enabled = False
            Me.pnlAuth2.Enabled = False
        Else

            If Me.adddisc <> 0 Then
                Me.objUsername.Enabled = False
            Else
                Me.objUsername.Enabled = True
            End If

            Me.objPassword.Enabled = True
            Me.btnOpen.Enabled = True
            Me.pnlAuth1.Enabled = True
            Me.pnlAuth2.Enabled = True
        End If


        Me.objPaymentRedeem.Enabled = Not Me.IsRedeemDisabled

        Me.objPaymentVoucherCode.Text = Me.vouchercode
        Me.objPaymentVoucher.Text = Me.voucher
        Me.objPaymentAddDisc.Text = Me.adddisc
        Me.objPaymentRedeem.Text = Me.redeem
        Me.BindingContext(Me.tblDialog).EndCurrentEdit()
        Me.tblDialog.AcceptChanges()

        Me.PnlFormMain.Dock = DockStyle.Fill
        Me.PnlFormMain.BackColor = Color.Gainsboro
        'Me.PnlFormMain.BackColor = Color.DarkGray
        'Me.PnlFormMain.BackgroundImageLayout = ImageLayout.Stretch
        'Me.PnlFormMain.BackgroundImage = My.Resources.bgf

        Me.Refresh()
        Me.ResumeLayout()

        uiTrnPosEN.BeepPopUp()

    End Sub

    Private Sub dlgCancel()
        Me.myRetObj = New Object() {}
        uiTrnPosEN.BeepPopDown()
        Me.POS = Nothing
        Me.Close()
    End Sub

    Private Sub dlgOK()

        'Me.myRetObj = New Object() { _
        '                 Me.objPaymentVoucherCode.Text, _
        '                 CDec(Me.objPaymentVoucher.Text), _
        '                 CDec(Me.objPaymentAddDisc.Text), _
        '                 CDec(Me.objPaymentRedeem.Text) _
        '              }




        With Me.objParamValue
            .PaymentVoucherCode = Me.objPaymentVoucherCode.Text
            .PaymentVoucher = CDec(Me.objPaymentVoucher.Text)
            .PaymentAddDisc = CDec(Me.objPaymentAddDisc.Text)
            .PaymentRedeem = CDec(Me.objPaymentRedeem.Text)
            .authusername = Me.objUsername.Text
        End With

        If Me.voucherid = __MEGAMAY_PROMO Then
            Dim minimal_belanja As Decimal = objParamValue.PaymentVoucher * 2
            If Me.total < minimal_belanja Then
                MessageBox.Show(String.Format("Untuk menggunakan Voucher {0:#,##0}, minimal belanja harus {1:#,##0}", objParamValue.PaymentVoucher, minimal_belanja), "Voucher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        Me.myRetObj = New Object() {Me.objParamValue}

        ' Cek nilai valid
        Dim paymentsubtotal As Decimal = Me.total - (CDec(Me.objPaymentVoucher.Text) + CDec(Me.objPaymentAddDisc.Text) + CDec(Me.objPaymentRedeem.Text))
        Dim paymentdisc As Decimal = (paymentdisc / 100) * paymentsubtotal
        Dim paymenttotal As Decimal = paymentsubtotal - paymentdisc

        uiTrnPosEN.BeepDef2()
        Me.POS = Nothing
        Me.Close()

    End Sub

    Private Sub dlg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                uiTrnPosEN.BeepPopDown()
                Me.Close()
        End Select
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

    Private Sub Object_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles objPaymentAddDisc.KeyDown, objPaymentVoucher.KeyDown, objPaymentVoucherCode.KeyDown, objPaymentRedeem.KeyDown, objUsername.KeyDown, objPassword.KeyDown, btnOpen.KeyDown
        Dim suppressglobalkeyprocess As Boolean
        Dim SuppressKeyPress As Boolean

        If Me.KeyCheck(sender, e.KeyCode, e.KeyValue, e.Control, suppressglobalkeyprocess, SuppressKeyPress) Then
            e.SuppressKeyPress = SuppressKeyPress
            If Not suppressglobalkeyprocess Then
                Key(sender, e.KeyCode, e.Control)
            End If
        Else
            e.SuppressKeyPress = True
        End If

    End Sub

    Private Sub objPaymentAddDisc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles objPaymentAddDisc.TextChanged
        Me.dlg_MoneyTyped(sender, Me.temp_adddisc)
    End Sub

    Private Sub objPaymentRedeem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles objPaymentRedeem.TextChanged
        Me.dlg_MoneyTyped(sender, Me.temp_redeem)
    End Sub

    Private Sub objPaymentVoucher_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles objPaymentVoucher.TextChanged
        Me.dlg_MoneyTyped(sender, Me.temp_voucher)
    End Sub





    Private Sub dlgTrnPosVoucher_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.POS = Nothing
    End Sub

    Private Sub dlgTrnPosVoucher_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.POS = Nothing
    End Sub


    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Dim loginberhasil As Boolean
        Dim username As String
        Dim password As String



        ' Cek apakah akan dibuka kembali




        username = Me.objUsername.Text
        password = Me.objPassword.Text


        ' Process login
        If Me.POS.IsAuthUsername(username, password) Then
            loginberhasil = True
        Else
            loginberhasil = False
        End If


        If loginberhasil Then
            Me.lblAuthMsg.Visible = False
            Me.objUsername.Enabled = False
            Me.objPassword.Text = ""

            Me.pnlAuth2.Visible = False



            ' Berhasil
            If Me.btnOpen.Text = "&Open" Then
                Me.btnOpen.Text = "&Close"
                Me.objPaymentAddDisc.Enabled = True
                Me.objPaymentAddDisc.Focus()
            Else
                Me.objPaymentAddDisc.Enabled = False
                Me.btnOpen.Text = "&Open"
            End If


            If Me.adddiscauto > 0 Then
                Me.objPaymentAddDisc.Text = String.Format("{0:#,##0}", ((Me.adddiscauto / 100) * Me.total))
                Me.objPaymentAddDisc.ReadOnly = True
            End If

        Else
            Me.lblAuthMsg.Visible = True
            Me.objPassword.Text = ""
            Me.objPassword.Focus()
        End If





    End Sub

    Private Sub lblAuthOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAuthOpen.Click
        Me.pnlAuth2.Visible = True
        Me.pnlAuth2Shadow.Visible = True
        Me.objUsername.Focus()
    End Sub

    Private Sub lblAuthClose_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblAuthClose.LinkClicked
        Me.pnlAuth2.Visible = False
        Me.pnlAuth2Shadow.Visible = False
    End Sub

    Private Sub btnF10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF10.Click
        dlgOK()
    End Sub

    Private Sub lblReset_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblReset.LinkClicked
        Me.objUsername.Enabled = True
        Me.objPaymentAddDisc.Text = "0"
    End Sub




    Private Sub btn_VouchRegular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.objPaymentVoucherCode.Text = ""
    End Sub

    Private Sub btn_VouchPromo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.objPaymentVoucherCode.Text = "MEGA-MAY14"
    End Sub


    Private Sub Group02_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Group02.Enter

    End Sub


    Private Sub btn_disc5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_disc5.Click
        Me.do_disc(5)
    End Sub

    Private Sub btn_disc10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_disc10.Click
        Me.do_disc(10)
    End Sub

    Private Sub btn_disc15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_disc15.Click
        Me.do_disc(15)
    End Sub

    Private Sub btn_disc20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_disc20.Click
        Me.do_disc(20)
    End Sub

    Private Sub btn_disc25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_disc25.Click
        Me.do_disc(25)
    End Sub

    Private Sub btn_disc30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_disc30.Click
        Me.do_disc(30)
    End Sub


    Private Sub do_disc(ByVal disc As Integer)
        Dim discvalue As Decimal
        discvalue = (disc / 100) * Me.total

        Dim res As DialogResult
        res = MessageBox.Show("Anda akan menambahkan discount secara manual sebesar " & disc & "% pada transaksi ini. Apakah anda yakin ?", "Additional Disc", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If res = Windows.Forms.DialogResult.OK Then
            Me.objPaymentVoucherCode.Text = "MANUAL-ADD-DISC"
            Me.objPaymentVoucher.Text = 0
            Me.objPaymentAddDisc.Text = String.Format("{0:#,##0}", discvalue)
        End If

        'If (Me.objPaymentAddDisc.Enabled) Then
        'Me.objPaymentVoucherCode.Text = ""
        'Me.objPaymentVoucher.Text = 0
        'Me.objPaymentAddDisc.Text = String.Format("{0:#,##0}", discvalue)
        'Else
        'Me.objPaymentVoucher.Text = String.Format("{0:#,##0}", discvalue)
        'Me.objPaymentAddDisc.Text = 0
        'End If


    End Sub


End Class
