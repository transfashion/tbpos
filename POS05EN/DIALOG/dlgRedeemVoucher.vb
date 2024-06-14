Public Class dlgRedeemVoucher
    Private WithEvents POS As TransStore.POS
    Private isOffline As Boolean = False
    Private isTfiVoucher As Boolean = True
    Private currentVoucherData As VoucherData = New VoucherData()

    Private Class VoucherUseArgument
        Public VoucherId As String
    End Class

    Private Class VoucherUseResult
        Public Argument As VoucherUseArgument
        Public Code As Integer = 0
        Public ErrorMessage As String
        Public Success As Boolean
    End Class

    Private Class VoucherCheckArgument
        Public VoucherId As String
    End Class

    Private Class VoucherCheckResult
        Public Argument As VoucherCheckArgument
        Public Code As Integer = 0
        Public ErrorMessage As String
        Public VoucherInfo As VoucherInfo
    End Class


    Public Class VoucherData
        Public Id As String
        Public Descr As String
        Public isValue As Boolean = True
        Public Value As Decimal = 0
        Public isCashVoucher = False
    End Class



    Public Function getVoucherData() As VoucherData
        Return Me.currentVoucherData
    End Function


    Public Sub setPOS(ByVal pos As TransStore.POS)
        Me.POS = pos
    End Sub



    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim CriteriaBuilder As Translib.QueryCriteria = New Translib.QueryCriteria
        Dim time As Date = Now()
        Dim clientdate As String = time.Year & "-" & time.Month.ToString.PadLeft(2, "0") & "-" & time.Day.ToString.PadLeft(2, "0") & " " & time.Hour.ToString.PadLeft(2, "0") & ":" & time.Minute.ToString.PadLeft(2, "0") & ":" & time.Second.ToString.PadLeft(2, "0")
        Dim script = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=cekvoucher"
        Dim wConn As Translib.WebConnection = Me.POS.getWebConnection()
        Dim responds As String = ""
        Dim args As VoucherCheckArgument = CType(e.Argument, VoucherCheckArgument)
        Dim result As VoucherCheckResult = New VoucherCheckResult
        Dim ErrorCode As Integer = 0

        result.Argument = args

        CriteriaBuilder = New Translib.QueryCriteria
        CriteriaBuilder.AddCriteria("region_id", True, Me.POS.RegionId)
        CriteriaBuilder.AddCriteria("branch_id", True, Me.POS.BranchId)
        CriteriaBuilder.AddCriteria("machine_id", True, Me.POS.MachineId)
        CriteriaBuilder.AddCriteria("vou_id", True, args.VoucherId)

        Try

            wConn.addtext("criteria", CriteriaBuilder.Serialize())
            responds = wConn.post(script)

            Dim res As WsVoucherInfoResult = Newtonsoft.Json.JavaScriptConvert.DeserializeObject(Of WsVoucherInfoResult)(responds)

            ErrorCode = res.code
            If res.code <> 0 Then
                Throw New Exception(res.message)
            End If

            result.VoucherInfo = res.voucher
        Catch ex As Exception
            result.Code = ErrorCode
            result.ErrorMessage = ex.Message
            Debug.Print(responds)
        Finally
            e.Result = result
        End Try

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Dim result As VoucherCheckResult = CType(e.Result, VoucherCheckResult)

        Try
            Dim isExpired As Boolean = False
            Dim isUsed As Boolean = False

            If result.Code <> 0 Then
                Throw New Exception(result.ErrorMessage)
            End If


            'Me.obj_txt_voucher_id.Text = result.VoucherInfo.Id
            'Me.obj_txt_descr.Text = result.VoucherInfo.Descr
            'Me.obj_txt_value.Text = String.Format("{0:#,##0}", result.VoucherInfo.Value)
            'Me.obj_txt_expireddate.Text = result.VoucherInfo.ExpireDate

            If (result.VoucherInfo.isUsed) Then
                Me.obj_txt_usedby.Text = result.VoucherInfo.UserId
                Me.obj_txt_useddate.Text = result.VoucherInfo.UsedDate
                isUsed = True
            Else
                Me.obj_txt_usedby.Text = "-"
                Me.obj_txt_useddate.Text = "-"
            End If

            ' Cek apakah voucher sudah expired
            Dim dtExpired As DateTime = New Date(result.VoucherInfo.ED_year, result.VoucherInfo.ED_month, result.VoucherInfo.ED_date, 23, 59, 59)
            If (dtExpired < Now()) Then
                isExpired = True
            End If


            If isExpired Then
                MessageBox.Show("Voucher telah expired", "Voucher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.btn_UseVoucher.Visible = False
            ElseIf isUsed Then
                MessageBox.Show("Voucher telah digunakan", "Voucher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.btn_UseVoucher.Visible = False
            Else
                Me.btn_UseVoucher.Visible = True
            End If

            Me.obj_txt_voucherid.Focus()
            Me.obj_txt_voucherid.Text = ""




            Me.currentVoucherData.Id = result.VoucherInfo.Id
            Me.currentVoucherData.Value = result.VoucherInfo.Value
            If Me.currentVoucherData.Value < 1 Then
                Me.currentVoucherData.isValue = False
            Else
                Me.currentVoucherData.isValue = True
            End If


            If Mid(Me.currentVoucherData.Id, 1, 1) = "1" Then
                Me.currentVoucherData.isCashVoucher = True
            Else
                Me.currentVoucherData.isCashVoucher = False
            End If



            Me.obj_txt_voucher_id.Text = Me.currentVoucherData.Id
            Me.obj_txt_descr.Text = result.VoucherInfo.Descr
            Me.obj_txt_expireddate.Text = result.VoucherInfo.ExpireDate


            If Me.currentVoucherData.Value < 1 Then
                Dim percent = 100 * Me.currentVoucherData.Value
                Me.obj_txt_value.Text = String.Format("{0:#,##0}%", percent)
            Else
                Me.obj_txt_value.Text = String.Format("{0:#,##0}", Me.currentVoucherData.Value)
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Voucher Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.btn_CheckVoucher.Enabled = True
            Me.btn_CheckVoucher.Text = "Check Voucher"
            Me.obj_txt_voucherid.Enabled = True
            Me.obj_txt_voucherid.BackColor = Color.White
            Me.Label1.BackColor = Color.White
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub

    Private Sub btn_CheckVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CheckVoucher.Click
     
        If Not Me.isTfiVoucher Then

            ' langsung terima aja
            Try
                Dim vouchervalue As Decimal = CDec(Me.obj_txt_manualvalue.Text)

                Me.currentVoucherData.Id = Me.obj_txt_voucherid.Text
                Me.currentVoucherData.Value = vouchervalue

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Catch ex As Exception
                MessageBox.Show("Voucher tidak valid", "Voucher", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        
        ElseIf Not Me.isOffline Then
            Dim param As VoucherCheckArgument = New VoucherCheckArgument()
            param.VoucherId = Me.obj_txt_voucherid.Text

            Me.btn_CheckVoucher.Enabled = False
            Me.btn_CheckVoucher.Text = "please wait..."
            Me.obj_txt_voucherid.Enabled = False
            Me.obj_txt_voucherid.BackColor = Color.Gainsboro
            Me.Label1.BackColor = Color.Gainsboro
            Me.Cursor = Cursors.WaitCursor

            Me.BackgroundWorker1.RunWorkerAsync(param)
        Else

            Try
                ' xxxxxcccyyyyrrpp
                ' Cek validitas kode vouhcher
                Dim vou_id As String = Me.obj_txt_voucherid.Text
                Dim v As VoucherData = Me.ValidateVoucher(vou_id)

                Me.currentVoucherData.isValue = v.isValue
                Me.currentVoucherData.Id = v.Id
                Me.currentVoucherData.Value = v.Value


                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Catch ex As Exception
                MessageBox.Show("Voucher tidak valid", "Voucher", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub


    Private Function ValidateVoucher(ByVal vou_id As String) As VoucherData
        Try
            If (vou_id.Length <> 16) Then
                Throw New Exception("Voucher tidak valid")
            End If


            Dim v As VoucherData = New VoucherData()

            Dim vou_batch As Integer = CInt(vou_id.Substring(0, 5))
            Dim vou_batchcode As Integer = CInt(vou_id.Substring(5, 3))
            Dim vou_batchblock As Integer = CInt(vou_id.Substring(5, 1))
            Dim vou_batchmul As Integer = CInt(vou_id.Substring(6, 2))
            Dim vou_no As Integer = CInt(vou_id.Substring(8, 4))
            Dim vou_ran As Integer = CInt(vou_id.Substring(12, 2))
            Dim vou_par As Integer = CInt(vou_id.Substring(14, 2))

            Dim vou_value As Decimal = 0

            If (vou_batchblock = 0) Then
                v.isValue = False
                vou_value = vou_batchmul / 100 'Discount %
            ElseIf vou_batchblock = 1 Then
                v.isValue = True
                vou_value = 10000 * vou_batchmul
            ElseIf vou_batchblock = 2 Then
                v.isValue = True
                vou_value = 25000 * vou_batchmul
            ElseIf vou_batchblock = 3 Then
                v.isValue = True
                vou_value = 50000 * vou_batchmul
            ElseIf vou_batchblock = 4 Then
                v.isValue = True
                vou_value = 100000 * vou_batchmul
            ElseIf vou_batchblock = 5 Then
                v.isValue = True
                vou_value = 500000 * vou_batchmul
            ElseIf vou_batchblock = 6 Then
                v.isValue = True
                vou_value = 1000000 * vou_batchmul
            End If

            Dim t As Integer = vou_no + vou_batch + vou_batchcode
            Dim b As Integer = vou_ran
            Dim n As Integer = Math.Floor(t / b)
            Dim p As Integer = n Mod b
            Dim parstr As String = "00000" & p.ToString()
            Dim parity As String = parstr.Substring(parstr.Length - 2)

            If (vou_par <> parity) Then
                Throw New Exception("Voucher tidak valid")
            End If

            v.Value = vou_value
            v.Id = vou_id

            Return v
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Sub obj_txt_voucherid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles obj_txt_voucherid.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not Me.isOffline Then
                btn_CheckVoucher_Click(sender, System.EventArgs.Empty)
            Else
                ' Validasi Voucher
                Try
                    Dim vou_id As String = Me.obj_txt_voucherid.Text
                    Dim v As VoucherData = ValidateVoucher(vou_id)
                    Me.currentVoucherData.isValue = v.isValue
                    Me.currentVoucherData.Id = v.Id
                    Me.currentVoucherData.Value = v.Value

                    Me.obj_txt_value.Text = String.Format("{0:#,##0}", v.Value)
                Catch ex As Exception
                    MessageBox.Show("Voucher tidak valid", "Voucher", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub


    Private Sub dlgRedeemVoucher_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.obj_txt_voucherid.Focus()
    End Sub

    Private Sub obj_txt_voucherid_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_txt_voucherid.Leave
        If Me.isTfiVoucher Then
            Me.obj_txt_voucherid.Focus()
        End If
    End Sub

    Private Sub dlgRedeemVoucher_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Enter
        Me.obj_txt_voucherid.Focus()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Me.obj_txt_voucherid.Focus()
    End Sub

    Private Sub dlgRedeemVoucher_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.obj_txt_voucherid.Focus()
    End Sub

    Private Sub dlgRedeemVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Me.obj_txt_voucherid.Focus()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_txt_value.Click, obj_txt_useddate.Click, obj_txt_usedby.Click, obj_txt_expireddate.Click, obj_txt_descr.Click, Label7.Click, Label6.Click, Label5.Click, Label4.Click, Label3.Click, Label2.Click
        Me.obj_txt_voucherid.Focus()
    End Sub

    Private Sub btn_OnlineOffline_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btn_OnlineOffline.LinkClicked
        Me.isOffline = Not Me.isOffline

        If Me.isOffline Then
            Me.btn_OnlineOffline.Text = "Set as Online validation"
            Me.btn_CheckVoucher.Text = "Use Voucher"
        Else
            Me.btn_OnlineOffline.Text = "Set as Offline validation"
            Me.btn_CheckVoucher.Text = "Check Voucher"
        End If
    End Sub

    Private Sub btn_vouchertfi_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btn_vouchertfi.LinkClicked
        Me.Label2.Text = "Scan / Input Voucher Trans Fashion"
        Me.btn_CheckVoucher.Text = "Check Voucher"
        Me.Panel1.Visible = True
        Me.isTfiVoucher = True
    End Sub

    Private Sub btn_voucherother_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btn_voucherother.LinkClicked
        Me.Label2.Text = "Kode Voucher"
        Me.btn_CheckVoucher.Text = "Use Voucher"
        Me.Panel1.Visible = False
        Me.isTfiVoucher = False
    End Sub

    Private Sub btn_UseVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_UseVoucher.Click

        Dim res As DialogResult
        res = MessageBox.Show("Apakah anda akan menggunakan voucher ini?", "Voucher", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If res = Windows.Forms.DialogResult.OK Then

            Me.btn_UseVoucher.Text = "Wait..."
            Me.btn_UseVoucher.Enabled = False

            Dim param As VoucherUseArgument = New VoucherUseArgument()
            param.VoucherId = Me.obj_txt_voucher_id.Text
            Me.BackgroundWorker2.RunWorkerAsync(param)

        End If

       
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        Me.obj_txt_manualvalue.Focus()
    End Sub



    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Dim CriteriaBuilder As Translib.QueryCriteria = New Translib.QueryCriteria
        Dim time As Date = Now()
        Dim clientdate As String = time.Year & "-" & time.Month.ToString.PadLeft(2, "0") & "-" & time.Day.ToString.PadLeft(2, "0") & " " & time.Hour.ToString.PadLeft(2, "0") & ":" & time.Minute.ToString.PadLeft(2, "0") & ":" & time.Second.ToString.PadLeft(2, "0")
        Dim script = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=markvoucher"
        Dim wConn As Translib.WebConnection = Me.POS.getWebConnection()
        Dim responds As String = ""
        Dim args As VoucherUseArgument = CType(e.Argument, VoucherUseArgument)
        Dim result As VoucherUseResult = New VoucherUseResult
        Dim ErrorCode As Integer = 0

        result.Argument = args

        CriteriaBuilder = New Translib.QueryCriteria
        CriteriaBuilder.AddCriteria("region_id", True, Me.POS.RegionId)
        CriteriaBuilder.AddCriteria("branch_id", True, Me.POS.BranchId)
        CriteriaBuilder.AddCriteria("machine_id", True, Me.POS.MachineId)
        CriteriaBuilder.AddCriteria("vou_id", True, args.VoucherId)

        Try

            wConn.addtext("criteria", CriteriaBuilder.Serialize())
            responds = wConn.post(script)

            Dim res As WsVoucherMarkResult = Newtonsoft.Json.JavaScriptConvert.DeserializeObject(Of WsVoucherMarkResult)(responds)

            ErrorCode = res.code
            If res.code <> 0 Then
                Throw New Exception(res.message)
            End If

            result.Success = res.success
        Catch ex As Exception
            result.Code = ErrorCode
            result.ErrorMessage = ex.Message
            Debug.Print(responds)
        Finally
            e.Result = result
        End Try
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        Dim result As VoucherUseResult = CType(e.Result, VoucherUseResult)

        Try
            If result.Code <> 0 Then
                Throw New Exception(result.ErrorMessage)
            End If

            If result.Success Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Voucher Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class