Public Class dlgSecondDisplay
    Private WithEvents POS As TransStore.POS

    Private ConsumableGoodPrefixCode As String
    Private colFiles As Collection = New Collection
    Private imgFileIndex As Integer
    Private currentFileIndex As Integer


    Public Sub setPOS(ByVal pos As TransStore.POS)
        Me.POS = pos
        Me.ConsumableGoodPrefixCode = Me.POS.CONSGOOD_CODE
    End Sub


    Private Sub dlgSecondDisplay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.pnl_SlideShow.Dock = DockStyle.Fill

        Me.pnl_Desk.Dock = DockStyle.Fill
        Me.pnl_QR.Hide()
        Me.pnl_tfiQR.Hide()


        Me.Timer1.Interval = 10000

        ' Cek apakah fideo ada
        Dim fileVideo As String = "C:\Users\agung\Documents\Transbrowser\video\video.avi"
        If System.IO.File.Exists(fileVideo) Then
            ' Play Video on pnlSlideShow
            Me.PictureBox2.Hide()
            '  Me.AxWindowsMediaPlayer1.Show()
            Me.Timer1.Start()
        Else
            ' Slide Show
            ' Me.AxWindowsMediaPlayer1.Hide()
            'Dim fileImage As String = "C:\Users\agung\Documents\Transbrowser\images\image1.jpg"
            'If System.IO.File.Exists(fileImage) Then
            '    Me.PictureBox2.Show()
            '    Me.PictureBox2.Dock = DockStyle.Fill
            '    Me.PictureBox2.ImageLocation = fileImage
            'Else
            '    Me.PictureBox2.Hide()
            'End If

            ' Dim dir As IO.Directory = IO.Directory(My.Computer.FileSystem.SpecialDirectories.MyDocuments)

            Dim filename As String
            Dim dirname As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Transbrowser\images"

            imgFileIndex = 0
            currentFileIndex = 0
            For Each filename In My.Computer.FileSystem.GetFiles(dirname)
                imgFileIndex = imgFileIndex + 1
                colFiles.Add(filename, imgFileIndex)
            Next
            currentFileIndex = imgFileIndex

            If (currentFileIndex > 0) Then
                Me.Timer2.Enabled = True
                Timer2_Tick(Me.Timer2, System.EventArgs.Empty)
            End If


        End If




        uiTrnPosEN.FormatDgvPOSItem(Me.DataGridView1)
        Me.DataGridView1.Columns("displayed_id").Visible = False
        Me.DataGridView1.Columns("displayed_net").Visible = False
        Me.DataGridView1.Columns("displayed_qty").Visible = False
        Me.DataGridView1.Columns("displayed_descr").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Me.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.ReadOnly = True


    End Sub



    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Me.currentFileIndex = Me.currentFileIndex + 1
        If Not Me.colFiles.Contains(Me.currentFileIndex) Then
            Me.currentFileIndex = 1
        End If

        Dim fileImageName As String = Me.colFiles.Item(Me.currentFileIndex)
        If System.IO.File.Exists(fileImageName) Then
            Me.PictureBox2.Show()
            Me.PictureBox2.Dock = DockStyle.Fill
            Me.PictureBox2.ImageLocation = fileImageName
        Else
            Me.PictureBox2.Hide()
        End If

    End Sub




    Public Sub setQR(ByVal amount As Decimal, ByVal storename As String, ByVal QRData As String)
        Me.pnl_tfiQR.Hide()
        Me.pnl_Desk.Hide()
        Me.pnl_QR.Show()
        Me.pnl_QR.Dock = DockStyle.Fill

        Me.lbl_StoreName.Text = storename
        Me.txt_PaymentTOTAL.Text = amount.ToString("#,##0")
        '  Me.PictureBox1.Image = image

        Dim qrCodeEncoder As ThoughtWorks.QRCode.Codec.QRCodeEncoder = New ThoughtWorks.QRCode.Codec.QRCodeEncoder()
        qrCodeEncoder.QRCodeEncodeMode = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ENCODE_MODE.BYTE
        qrCodeEncoder.QRCodeErrorCorrect = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.H
        qrCodeEncoder.QRCodeScale = 3
        qrCodeEncoder.QRCodeVersion = 17

        If (QRData <> "") Then
            Dim image As System.Drawing.Image = qrCodeEncoder.Encode(QRData)
            Me.PictureBox1.Image = image
        Else
            Throw New Exception("QR Data belum di set")
        End If

    End Sub


    Public Sub showDesk()
        Me.pnl_tfiQR.Hide()
        Me.pnl_QR.Hide()
        Me.pnl_Desk.Show()


        Me.pnl_Desk.Dock = DockStyle.Fill

    End Sub


    Public Sub showTransFashionQR()
        Me.pnl_tfiQR.Show()
        Me.pnl_QR.Hide()
        Me.pnl_Desk.Hide()


        Me.pnl_tfiQR.Dock = DockStyle.Fill

        Dim qrCodeEncoder As ThoughtWorks.QRCode.Codec.QRCodeEncoder = New ThoughtWorks.QRCode.Codec.QRCodeEncoder()
        qrCodeEncoder.QRCodeEncodeMode = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ENCODE_MODE.BYTE
        qrCodeEncoder.QRCodeErrorCorrect = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.H
        qrCodeEncoder.QRCodeScale = 4
        qrCodeEncoder.QRCodeVersion = 17

        Dim image As System.Drawing.Image = qrCodeEncoder.Encode("https://staging.transfashionindonesia.com/my-account/")
        Me.PictureBox3.Image = image

    End Sub

    Public Sub ShowGreeting(ByVal name As String)
        Me.txt_Greeting.Text = "Selamat Datang " & name
        Me.txt_Greeting.Show()
    End Sub



    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub

    Private Sub SplitContainer1_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Timer1.Stop()

        'Me.AxWindowsMediaPlayer1.Dock = DockStyle.Fill
        'Me.AxWindowsMediaPlayer1.URL = "C:\Users\agung\Documents\Transbrowser\video\video.avi"
        'Me.AxWindowsMediaPlayer1.settings.setMode("Loop", True)
        'Me.AxWindowsMediaPlayer1.uiMode = "none"
        'Me.AxWindowsMediaPlayer1.Ctlcontrols.play()
    End Sub


    Public Sub SetLocation(ByVal txt As String)
        Me.lbl_Location.Text = txt
    End Sub

    Public Sub SetTotal(ByVal subtotal As Decimal, ByVal paymdisc As Decimal, ByVal total As Decimal)
        Me.lbl_SubTotal.Text = subtotal.ToString("#,##0")
        Me.lbl_DiscountPayment.Text = paymdisc.ToString("#,##0")
        Me.lbl_Total.Text = total.ToString("#,##0")
    End Sub

    Public Sub SetGridDataSource(ByRef tbl As DataTable)



        Me.DataGridView1.DataSource = tbl
    End Sub




    Private Sub DgvPOSItem_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        Dim dgv As DataGridView = CType(sender, DataGridView)
        Dim colname As String = dgv.Columns(e.ColumnIndex).Name
        Dim vou01type As String
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
        subtotal = CDec(dgv.Rows(e.RowIndex).Cells("bondetil_subtotal").Value)
        artpref = Mid(dgv.Rows(e.RowIndex).Cells("bondetil_article").Value, 1, Len(ConsumableGoodPrefixCode))

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
                    If discrvou01 > 0 Then

                        Dim vouchername As String = "Voucher"
                        If (vou01type = "PROMO123") Then
                            vouchername = "PROMO123"
                        ElseIf vou01type = "PROMOMD1" Then
                            vouchername = "PROMOMD1 (" & String.Format("-{0:#,##0}", discrvou01) & ")"
                        ElseIf vou01type = "BUNDL-01" Then
                            vouchername = "BUNDL-01 (" & String.Format("-{0:#,##0}", discrvou01) & ")"
                        End If

                        If discpstd01 > 0 Then
                            e.Value &= " (+ AddDisc " & vouchername & " " & String.Format("{0:#,##0}", discpvou01) & "%)"
                        Else
                            e.Value &= "     (+ AddDisc " & vouchername & " " & String.Format("{0:#,##0}", discpvou01) & "%)"
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
                subtotal = CDec(dgv.Rows(e.RowIndex).Cells("bondetil_subtotal").Value)
                e.Value = String.Format("{0:#,##0}", subtotal)

        End Select
    End Sub



    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Me.DataGridView1.ClearSelection()
    End Sub


End Class