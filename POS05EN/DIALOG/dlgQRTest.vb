Public Class dlgQRTest

    Private WithEvents POS As TransStore.POS

    Public Sub SetParameter(ByVal objPOS As TransStore.POS)
        Me.POS = objPOS
    End Sub


    Private Sub btn_QRGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_QRGenerate.Click
        Dim qrCodeEncoder As ThoughtWorks.QRCode.Codec.QRCodeEncoder = New ThoughtWorks.QRCode.Codec.QRCodeEncoder()
        Dim utf8Encoding As New System.Text.UTF8Encoding(True)
        Dim encodedString() As Byte

        Dim QR_Version As Integer = 17
        Dim QR_Scale As Integer = 3

        Try
            Dim data As String = Me.txtQRCode.Text    ' "00020101021226660018ID.CO.BANKMEGA.WWW01189360042600112810380211000001222640303UMI51410014ID.CO.QRIS.WWW0212ID12345678900303UMI5204581253033605403100550202560105802ID5923Trans Fashion Indonesia6007JAKARTA61051279062270123MID202111051433057btnYq63043FDE"
            encodedString = utf8Encoding.GetBytes(data)
            qrCodeEncoder.QRCodeEncodeMode = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ENCODE_MODE.BYTE
            qrCodeEncoder.QRCodeErrorCorrect = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.H
            qrCodeEncoder.QRCodeScale = QR_Scale
            qrCodeEncoder.QRCodeVersion = QR_Version

            Dim image As System.Drawing.Image = qrCodeEncoder.Encode(data)
            Me.picQRCode.Image = image


        Catch ex As Exception
            MessageBox.Show(ex.Message, "QR Generate", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dlgQRTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TabControl1.Dock = DockStyle.Fill

        Dim wsaddress As String = Me.POS.QrisProxy

        Me.txt_QrisProxy.Text = wsaddress
        Me.Panel1.Visible = False


        Me.txtMid.Text = "00000016300"
        Me.txtTid.Text = "00000088"

    End Sub






    Private Sub btn_GenerateQris_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GenerateQris.Click
        Dim wsaddress As String = Me.txt_QrisProxy.Text

        Dim ws As POS05EN.FGTAWebService = New POS05EN.FGTAWebService(wsaddress)


        Cursor = Cursors.WaitCursor


        Try
            Dim amount As Decimal = CDec(Me.txtAmount.Text)
            Dim strAmount As String = amount.ToString()


            Dim args As New Newtonsoft.Json.JavaScriptObject()
            args.Item("mid") = Me.txtMid.Text
            args.Item("tid") = Me.txtTid.Text
            args.Item("amount") = strAmount
            args.Item("payment_type") = Me.txtPaymentType.Text





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


            Me.txt_GenerateQrisResult.Text = pgmessage
            Me.txt_QRCode.Text = QRCode
            Me.txt_Reference.Text = ReffNo
            Me.txt_QrisStatus.Text = ""

            ' Showing QRCode
            Dim qrCodeEncoder As ThoughtWorks.QRCode.Codec.QRCodeEncoder = New ThoughtWorks.QRCode.Codec.QRCodeEncoder()
            Dim utf8Encoding As New System.Text.UTF8Encoding(True)
            Dim encodedString() As Byte
            Dim verScale As String = Me.txtScale.Text
            Dim scale = CInt(verScale)
            Dim verStr As String = Me.txtVersion.Text
            Dim version = CInt(verStr)
            Dim data As String = Me.txt_QRCode.Text
            encodedString = utf8Encoding.GetBytes(data)
            qrCodeEncoder.QRCodeEncodeMode = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ENCODE_MODE.BYTE
            qrCodeEncoder.QRCodeErrorCorrect = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.H
            qrCodeEncoder.QRCodeScale = scale
            qrCodeEncoder.QRCodeVersion = version

            Dim image As System.Drawing.Image = qrCodeEncoder.Encode(data)
            Me.PictureBox1.Image = image

            Me.Panel1.Visible = True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Arrow
        End Try
    End Sub

    Private Sub btn_Reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Reset.Click

        Me.txt_GenerateQrisResult.Text = ""
        Me.txt_QRCode.Text = ""
        Me.txt_Reference.Text = ""
        Me.txt_QrisStatus.Text = ""

        Me.PictureBox1.Image = Nothing
        Me.Panel1.Visible = False

    End Sub

    Private Sub btn_StatusClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_StatusClear.Click
        Me.txt_QrisStatus.Clear()
    End Sub

    Private Sub btn_CheckStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CheckStatus.Click
        Dim wsaddress As String = Me.txt_QrisProxy.Text

        Dim ws As POS05EN.FGTAWebService = New POS05EN.FGTAWebService(wsaddress)

        Cursor = Cursors.WaitCursor

        Try
            Dim args As New Newtonsoft.Json.JavaScriptObject()
            args.Item("mid") = Me.txtMid.Text
            args.Item("tid") = Me.txtTid.Text
            args.Item("reffnum") = Me.txt_Reference.Text

            Dim res As Newtonsoft.Json.JavaScriptObject = ws.Execute("pg/mega/qr/checkstatus", args)
            Dim result As Newtonsoft.Json.JavaScriptObject = res.Item("result")
            Dim pgmessage As String = result.Item("pgmessage")
            Dim txInfo As Newtonsoft.Json.JavaScriptObject = Newtonsoft.Json.JavaScriptConvert.DeserializeObject(pgmessage)


            Me.txt_QrisStatus.AppendText(pgmessage)
            Me.txt_QrisStatus.AppendText(vbCrLf)
            Me.txt_QrisStatus.AppendText(vbCrLf)


            Dim RC As String = txInfo.Item("RC")
            Dim RCDesc As String = txInfo.Item("RCDesc")
            Dim CustName As String = txInfo.Item("CustName")
            Dim ReffNo As String = txInfo.Item("ReffNo")
            Dim PaymentSource As String = txInfo.Item("PaymentSource")
            Dim source_id As String = txInfo.Item("source_id")
            Dim ApprovalCode As String = txInfo.Item("ApprovalCode")
            Dim success As Boolean = txInfo.Item("success")
            Dim error_message As String = txInfo.Item("error_message")

            If RC = "00" Then
                Me.txt_QrisStatus.AppendText("===================" & vbCrLf)
                Me.txt_QrisStatus.AppendText("PEMBAYARAN BERHASIL" & vbCrLf)
                Me.txt_QrisStatus.AppendText("===================" & vbCrLf)
                Me.txt_QrisStatus.AppendText("Reff: " & ReffNo & vbCrLf)
                Me.txt_QrisStatus.AppendText("CustName: " & CustName & vbCrLf)
                Me.txt_QrisStatus.AppendText("PaymentSource: " & PaymentSource & vbCrLf)
                Me.txt_QrisStatus.AppendText("SourceId: " & source_id & vbCrLf)
                Me.txt_QrisStatus.AppendText("ApprovalCode: " & ApprovalCode & vbCrLf)
                Me.txt_QrisStatus.AppendText(vbCrLf)
                Me.txt_QrisStatus.AppendText(vbCrLf)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Arrow
        End Try
    End Sub
End Class