Public Class dlgMobilePayment
    Const MaxExtendTime = 3

    Private _payresult As MobilePaymentResult
    Private _mid As String
    Private _tid As String
    Private extendTime As Integer

    Private Parameter As MobilePaymentParameter
    Private WithEvents POS As TransStore.POS

    Public ReadOnly Property PaymentResult() As MobilePaymentResult
        Get
            Return Me._payresult
        End Get
    End Property

    Private Sub dlgMobilePayment_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.POS.SecondDisplay.showDesk()
    End Sub


    Private Sub dlgMobilePayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txt_ReffNum.BorderStyle = BorderStyle.None
        Me.txt_CountDown.BorderStyle = BorderStyle.None

        Me.extendTime = MaxExtendTime
        Me._payresult = New MobilePaymentResult

        If uiTrnPosEN.StartInfo.EnvironmentVariables("POSENV") = "DEV" Then
            Me.btn_Copy.Visible = True
        Else
            Me.btn_Copy.Visible = False
        End If


    End Sub

    Private Sub dlgMobilePayment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub



    Public Sub SetParameter(ByVal objPOS As TransStore.POS, ByVal param As MobilePaymentParameter)

        Me.POS = objPOS
        Me.Parameter = param

        Dim QRData As String = param.QRData
        Dim ReffNum As String = param.ReffNum
        Dim amount As Decimal = param.Amount

        Me._mid = param.mid
        Me._tid = param.tid
        Me.lbl_StoreName.Text = param.storename
        Me.txt_PaymentTOTAL.Text = amount.ToString("#,##0")
        Me.txt_ReffNum.Text = param.ReffNum
        Me.txt_ReffNum.Select(1, 0)
        Me.lbl_param_paymenttype.Text = param.payment_type


        Me.CekStatusStart(param.CountDownSec)

        Try
            Dim qrCodeEncoder As ThoughtWorks.QRCode.Codec.QRCodeEncoder = New ThoughtWorks.QRCode.Codec.QRCodeEncoder()
            qrCodeEncoder.QRCodeEncodeMode = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ENCODE_MODE.BYTE
            qrCodeEncoder.QRCodeErrorCorrect = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.H
            qrCodeEncoder.QRCodeScale = 3
            qrCodeEncoder.QRCodeVersion = 17
            If (QRData <> "") Then
                Dim image As System.Drawing.Image = qrCodeEncoder.Encode(QRData)
                Me.PictureBox1.Image = image
                Me.POS.SecondDisplay.setQR(amount, param.storename, QRData)
            Else
                Throw New Exception("QR Data belum di set")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try

    End Sub









    Private Sub CekStatusStart(ByVal seconds As Integer)
        Me.txt_CountDown.Text = seconds

        Me.tmr_CountDown.Enabled = True
        Me.tmr_CountDown.Interval = 1000
        Me.tmr_CountDown.Start()
    End Sub


    Private Sub CekStatusStop()
        Me.tmr_CountDown.Enabled = False
        Me.tmr_CountDown.Stop()
    End Sub



    Private Sub QRCekStatus()


        ' Cek Status
        Dim wsaddress As String = Me.POS.QrisProxy
        Dim ws As POS05EN.FGTAWebService = New POS05EN.FGTAWebService(wsaddress)

        Dim args As New Newtonsoft.Json.JavaScriptObject()
        args.Item("mid") = Me.Parameter.mid
        args.Item("tid") = Me.Parameter.tid
        args.Item("reffnum") = Me.Parameter.ReffNum


        Try

            Cursor = Cursors.WaitCursor
            Dim res As Newtonsoft.Json.JavaScriptObject = ws.Execute("pg/mega/qr/checkstatus", args)
            Dim result As Newtonsoft.Json.JavaScriptObject = res.Item("result")
            Dim pgmessage As String = result.Item("pgmessage")
            Dim txInfo As Newtonsoft.Json.JavaScriptObject = Newtonsoft.Json.JavaScriptConvert.DeserializeObject(pgmessage)

            Dim RC As String = txInfo.Item("RC")
            Dim RCDesc As String = txInfo.Item("RCDesc")
            If RC = "00" Then
                Dim CustName As String = txInfo.Item("CustName")
                Dim ReffNo As String = txInfo.Item("ReffNo")
                Dim PaymentSource As String = txInfo.Item("PaymentSource")
                Dim source_id As String = txInfo.Item("source_id")
                Dim ApprovalCode As String = txInfo.Item("ApprovalCode")
                Dim success As Boolean = txInfo.Item("success")
                Dim error_message As String = txInfo.Item("error_message")

                Me.CekStatusStop()
                Me.TransactionSuccess(ReffNo, CustName, PaymentSource, source_id, ApprovalCode, Me.Parameter.Amount)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Arrow
        End Try


    End Sub



    Private Sub TransactionSuccess(ByVal ReffNo As String, ByVal CustName As String, ByVal PaymentSource As String, ByVal source_id As String, ByVal ApprovalCode As String, ByVal amount As Decimal)
        With Me.PaymentResult
            .CustomerName = CustName
            .ApprovalCode = ApprovalCode
            .source_id = source_id
            .PaymentSource = PaymentSource
            .PaymentValue = amount
            .ReffNo = ReffNo
        End With

        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub QRReset()
        Me.txt_ReffNum.Text = ""
        Me.PictureBox1.Image = Nothing
    End Sub


    Private Sub tmr_CountDown_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_CountDown.Tick
        Dim seq = CInt(Me.txt_CountDown.Text)

        seq = seq - 1
        Me.txt_CountDown.Text = seq
        If seq <= 0 Then
            Me.CekStatusStop()
            Me.PictureBox1.Visible = False
            If Me.extendTime > 0 Then
                Me.extendTime = Me.extendTime - 1
                Dim res As DialogResult = MessageBox.Show("Apakah anda akan memperpanjang proses " & MobilePaymentParameter.CountDownDefault & " detik lagi ? ", "Scan QR", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If res = Windows.Forms.DialogResult.Yes Then
                    Me.CekStatusStart(MobilePaymentParameter.CountDownDefault)
                    Me.PictureBox1.Visible = True
                Else
                    Me.Close()
                End If
            Else
                MessageBox.Show("Waktu habis", "Scan QR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Close()
            End If
        End If
        Me.QRCekStatus()
    End Sub


    Private Sub btn_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Copy.Click
        ' Me.Parameter.QRData
        If Me.Parameter.QRData <> "" Then
            Clipboard.SetText(Me.Parameter.QRData)
        End If
    End Sub
End Class