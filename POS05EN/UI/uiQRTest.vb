Public Class uiQRTest


    '    Const PGAddress As String = "http://qris.transfashion.id:8765/pg/public"
    ' Const PGAddress As String = "http://qrisaws.transfashion.id/pg/public"
    Const PGAddress As String = "http://35.219.107.35/pg/public"



    Private Sub btnShowQR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' QRCode
        ' 02|10000|2sacawe12325|1|1|0002|p1MJpA9UFoJg48QpyujrD9WPMrn/7+KH9Aai5HlsuIU=


        Try

            Dim qrCodeEncoder As ThoughtWorks.QRCode.Codec.QRCodeEncoder = New ThoughtWorks.QRCode.Codec.QRCodeEncoder()


            'Dim data As String = "02|10000|2sacawe12325|1|1|0002|p1MJpA9UFoJg48QpyujrD9WPMrn/7+KH9Aai5HlsuIU="
            'qrCodeEncoder.QRCodeEncodeMode = qrCodeEncoder.ENCODE_MODE.BYTE
            'qrCodeEncoder.QRCodeErrorCorrect = qrCodeEncoder.ERROR_CORRECTION.M
            'qrCodeEncoder.QRCodeScale = 4
            'qrCodeEncoder.QRCodeVersion = 7


            Dim utf8Encoding As New System.Text.UTF8Encoding(True)
            Dim encodedString() As Byte

            ''BISA
            'Dim data As String = "00020101021226660018ID.CO.BANKMEGA.WWW01189360042600112810380211000001222640303UMI51410014ID.CO.QRIS.WWW0212ID12345678900303UMI5204581253033605403100550202560105802ID5923Trans Fashion Indonesia6007JAKARTA61051279062270123MID202111051433057btnYq63043FDE"
            'encodedString = utf8Encoding.GetBytes(data)
            'qrCodeEncoder.QRCodeEncodeMode = qrCodeEncoder.ENCODE_MODE.BYTE
            'qrCodeEncoder.QRCodeErrorCorrect = qrCodeEncoder.ERROR_CORRECTION.L
            'qrCodeEncoder.QRCodeScale = 3
            'qrCodeEncoder.QRCodeVersion = 10


            Dim verScale As String = Me.txtScale.Text
            Dim scale = CInt(verScale)

            Dim verStr As String = Me.txtVersion.Text
            Dim version = CInt(verStr)
            Dim data As String = Me.txtQRCode.Text    ' "00020101021226660018ID.CO.BANKMEGA.WWW01189360042600112810380211000001222640303UMI51410014ID.CO.QRIS.WWW0212ID12345678900303UMI5204581253033605403100550202560105802ID5923Trans Fashion Indonesia6007JAKARTA61051279062270123MID202111051433057btnYq63043FDE"
            encodedString = utf8Encoding.GetBytes(data)
            qrCodeEncoder.QRCodeEncodeMode = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ENCODE_MODE.BYTE
            qrCodeEncoder.QRCodeErrorCorrect = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.H
            qrCodeEncoder.QRCodeScale = scale
            qrCodeEncoder.QRCodeVersion = version



            Dim image As System.Drawing.Image = qrCodeEncoder.Encode(data)

            ' qrCodeEncoder.Encode(data)
            Me.PictureBox1.Image = image





        Catch ex As Exception
            MessageBox.Show("Data Error")
        End Try

    End Sub

    Private Sub btn_newapi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newapi.Click
        Dim wsaddress As String = PGAddress ' "http://dev.transbrowser.com/oss"

        Dim ws As POS05EN.FGTAWebService = New POS05EN.FGTAWebService(wsaddress)

        Dim args As New Newtonsoft.Json.JavaScriptObject()
        args.Item("data") = "empat dua satu"

        Try
            Cursor = Cursors.WaitCursor
            Dim res As Newtonsoft.Json.JavaScriptObject = ws.Execute("fgta/example/apicall/myapi", args)

            Dim result = res.Item("result")


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Arrow
        End Try



    End Sub

    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        Dim verStr As String = Me.txtVersion.Text
        Dim version = CInt(verStr)

        version = version + 1

        Me.txtVersion.Text = version
    End Sub

    Private Sub btnKalistaGenQR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKalistaGenQR.Click
        Dim wsaddress As String = PGAddress ' "http://qris.transfashion.id:8765/pg/public" ' "http://dev.transbrowser.com/oss"

        Dim ws As POS05EN.FGTAWebService = New POS05EN.FGTAWebService(wsaddress)



        Try
            Dim amount As Decimal = CDec(Me.txtAmount.Text)
            Dim strAmount As String = amount.ToString()


            Dim args As New Newtonsoft.Json.JavaScriptObject()
            args.Item("mid") = Me.txtMid.Text
            args.Item("tid") = Me.txtTid.Text
            args.Item("amount") = strAmount
            args.Item("payment_type") = Me.txtPaymentType.Text




            Cursor = Cursors.WaitCursor
            Dim res As Newtonsoft.Json.JavaScriptObject = ws.Execute("pg/mega/qr/generate", args)

            Dim result As Newtonsoft.Json.JavaScriptObject = res.Item("result")

            Dim pgmessage As String = result.Item("pgmessage")
            Dim txInfo As Newtonsoft.Json.JavaScriptObject = Newtonsoft.Json.JavaScriptConvert.DeserializeObject(pgmessage)

            Dim RC As String = txInfo.Item("RC")
            Dim QRCode As String = txInfo.Item("QRCode")
            Dim ReffNo As String = txInfo.Item("ReffNo")
            Dim RCDesc As String = txInfo.Item("RCDesc")
            Dim success As Boolean = txInfo.Item("success")
            Dim error_message As String = txInfo.Item("error_message")

            Me.txtQRCode.Text = QRCode
            Me.txtRefNo.Text = ReffNo

            Me.btnShowQR_Click(Me.Button1, System.EventArgs.Empty)


            Me.CekStatusStart(60 * 2)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Arrow
        End Try
    End Sub

    Private Sub tmrCheck_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCheck.Tick
        Dim seq = CInt(Me.txtSeq.Text)

        seq = seq - 1
        Me.txtSeq.Text = seq
        If seq <= 0 Then
            Me.CekStatusStop()
        End If


        ' Cek Status
        Dim wsaddress As String = PGAddress ' "http://dev.transbrowser.com/oss"
        Dim ws As POS05EN.FGTAWebService = New POS05EN.FGTAWebService(wsaddress)

        Dim args As New Newtonsoft.Json.JavaScriptObject()
        args.Item("mid") = Me.txtMid.Text
        args.Item("tid") = Me.txtTid.Text
        args.Item("reffnum") = Me.txtRefNo.Text


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
                Me.TransactionSuccess(ReffNo, CustName, PaymentSource, source_id, ApprovalCode)

            End If


            Me.txtResult.AppendText(RCDesc & vbCrLf)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Arrow
        End Try



    End Sub


    Private Sub TransactionSuccess(ByVal ReffNo As String, ByVal CustName As String, ByVal PaymentSource As String, ByVal source_id As String, ByVal ApprovalCode As String)

        Me.txtResult.AppendText("Transaction Sucess" & vbCrLf)
        Me.txtResult.AppendText(ReffNo & vbCrLf)
        Me.txtResult.AppendText(CustName & vbCrLf)
        Me.txtResult.AppendText(PaymentSource & vbCrLf)
        Me.txtResult.AppendText(source_id & vbCrLf)
        Me.txtResult.AppendText(ApprovalCode & vbCrLf)

    End Sub


    Private Sub CekStatusStart(ByVal seconds As Integer)
        Me.txtSeq.Text = seconds
        Me.tmrCheck.Enabled = True
        Me.tmrCheck.Interval = 1000
        Me.tmrCheck.Start()
    End Sub


    Private Sub CekStatusStop()
        Me.QRReset()
        Me.tmrCheck.Enabled = False
        Me.tmrCheck.Stop()
    End Sub


    Private Sub QRReset()
        Me.txtQRCode.Text = ""
        Me.txtRefNo.Text = ""
        Me.PictureBox1.Image = Nothing
    End Sub


    Private Sub btnResetQR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetQR.Click
        Me.QRReset()
    End Sub
End Class
