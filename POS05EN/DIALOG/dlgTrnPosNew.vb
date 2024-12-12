Public Class dlgTrnPosNew

    Private posvouchertypeindex As Integer = 1
    Private nationalityindex As Integer = 1
    Private genderindex As Integer = 0
    Private ageindex As Integer = 1
    Private myRetObj As Object
    Private master_posvouchertype As DataTable
    Private master_poscustage As DataTable
    Private master_poscustnat As DataTable
    Private master_posvouchertype_cust As DataTable
    Private objError As ErrorProvider = New ErrorProvider

    Private WithEvents POS As TransStore.POS



#Region " Constructor "

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, ByVal args As Object) As Object
        Dim objParamValue As TransStore.PosNewTransactionParamValue

        Try
            objParamValue = CType(args(0), TransStore.PosNewTransactionParamValue)
            Me.POS = objParamValue.POS
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
    End Function

#End Region

#Region " Listener "

    Public Function KeyCheck(ByVal sender As Object, ByVal keycode As System.Windows.Forms.Keys, ByVal keyvalue As Integer, ByVal ctrl As Boolean, ByRef suppressglobalkeyprocess As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        Dim obj As Control = sender


        Select Case keycode
            Case Keys.F5
                If Me.objSalesId.Focused Then
                    If Me.objSalesId.ReadOnly Then
                        Me.objSalesId.ReadOnly = False
                        Me.objSalesId.BackColor = Color.White
                    Else
                        uiTrnPosEN.BrowseSalesPerson(Me, Me.objSalesId, Me.objSalesName, Me.POS)
                        Me.objSalesId.ReadOnly = True
                        Me.objSalesId.BackColor = Color.Gainsboro
                        Me.objError.SetError(Me.objSalesId, "")
                    End If
                Else
                    Me.objSalesId.Focus()
                    If Me.objSalesId.ReadOnly Then
                        Me.objSalesId.ReadOnly = False
                        Me.objSalesId.BackColor = Color.White
                    End If
                End If
                suppressglobalkeyprocess = False
                SuppressKeyPress = True
                Return True
        End Select


        Select Case obj.Name
            Case "objPaymentVoucher01Code"
            Case "objSalesId"
                Select Case keycode
                    Case Keys.Enter
                        Me.SetSalesCode()
                        Exit Function
                End Select

            Case "objCustomerName"
                Select Case keycode
                    Case Keys.Enter
                        Me.objCustomerTelp.Focus()
                        Exit Function
                End Select

            Case "objCustomerTelp"
                Select Case keycode
                    Case Keys.Enter
                        Me.objSalesId.Focus()
                        Exit Function
                End Select



        End Select

        Return True
    End Function

    Public Function Key(ByVal sender As Object, ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean) As Boolean
        Dim obj As Control = sender

        Select Case keycode
            Case Keys.Escape
                Me.dlgCancel()

            Case Keys.PageUp
                posvouchertypeindex += 1
                If posvouchertypeindex > Me.master_posvouchertype.Rows.Count Then
                    posvouchertypeindex = 1
                End If
                Me.objVoucher01TypeId.Text = Me.master_posvouchertype.Rows(posvouchertypeindex - 1).Item("posvouchertype_id").ToString
                Me.objVoucher01TypeName.Text = Me.master_posvouchertype.Rows(posvouchertypeindex - 1).Item("posvouchertype_descr").ToString
                Me.objVoucher01Type.Text = Me.master_posvouchertype.Rows(posvouchertypeindex - 1).Item("posvouchertype_selectedtype").ToString
                Me.objVoucher01Disc.Text = Me.master_posvouchertype.Rows(posvouchertypeindex - 1).Item("posvouchertype_disc").ToString
                Me.objVoucher01Method.Text = Me.master_posvouchertype.Rows(posvouchertypeindex - 1).Item("posvouchertype_method").ToString

            Case Keys.PageDown
                posvouchertypeindex -= 1
                If posvouchertypeindex < 1 Then
                    posvouchertypeindex = Me.master_posvouchertype.Rows.Count
                End If
                Me.objVoucher01TypeId.Text = Me.master_posvouchertype.Rows(posvouchertypeindex - 1).Item("posvouchertype_id").ToString
                Me.objVoucher01TypeName.Text = Me.master_posvouchertype.Rows(posvouchertypeindex - 1).Item("posvouchertype_descr").ToString
                Me.objVoucher01Type.Text = Me.master_posvouchertype.Rows(posvouchertypeindex - 1).Item("posvouchertype_selectedtype").ToString
                Me.objVoucher01Disc.Text = Me.master_posvouchertype.Rows(posvouchertypeindex - 1).Item("posvouchertype_disc").ToString
                Me.objVoucher01Method.Text = Me.master_posvouchertype.Rows(posvouchertypeindex - 1).Item("posvouchertype_method").ToString



            Case Keys.F1
                If nationalityindex > Me.master_poscustnat.Rows.Count Then
                    nationalityindex = 1
                End If
                Me.objCustomerNationalityId.Text = Me.master_poscustnat.Rows(nationalityindex - 1).Item("poscustnat_id").ToString
                Me.objCustomerNationality.Text = Me.master_poscustnat.Rows(nationalityindex - 1).Item("poscustnat_name").ToString
                nationalityindex += 1

            Case Keys.F2
                genderindex += 1
                If genderindex > 2 Then
                    genderindex = 1
                End If

                Select Case genderindex
                    Case 0
                        Me.objCustomerGenderId.Text = "N"
                        Me.objCustomerGender.Text = "NONE"
                        Me.objCustomerName.Left = 169
                        Me.objCustomerTitle.Text = ""
                    Case 1
                        Me.objCustomerGenderId.Text = "M"
                        Me.objCustomerGender.Text = "MALE"
                        Me.objCustomerName.Left = 200
                        Me.objCustomerTitle.Text = "Mr."
                        objError.SetError(Me.lblGender, "")

                        Me.objCustomerName.Focus()
                    Case 2
                        Me.objCustomerGenderId.Text = "F"
                        Me.objCustomerGender.Text = "FEMALE"
                        Me.objCustomerTitle.Text = "Ms."
                        Me.objCustomerName.Left = 200
                        objError.SetError(Me.lblGender, "")

                        Me.objCustomerName.Focus()
                End Select

            Case Keys.F3
                If ageindex > Me.master_poscustage.Rows.Count Then
                    ageindex = 1
                End If
                Me.objCustomerAgeId.Text = Me.master_poscustage.Rows(ageindex - 1).Item("poscustage_id").ToString
                Me.objCustomerAge.Text = Me.master_poscustage.Rows(ageindex - 1).Item("poscustage_name").ToString
                ageindex += 1


            Case Keys.F4
                Me.objPaymentVoucher01Code.Focus()



            Case Keys.F10
                If Me.objSalesId.ReadOnly = False Then
                    Me.SetSalesCode()
                Else
                    Me.dlgOK()
                End If
                


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

        Me.master_posvouchertype = Me.POS.LoadVoucherType()
        Me.master_poscustage = Me.POS.LoadCustAge()
        Me.master_poscustnat = Me.POS.LoadCustNat()

        Me.Refresh()
        Me.ResumeLayout()

        'uiTrnPosEN.BeepPopUp()

        If Me.master_posvouchertype.Rows.Count > 0 Then
            Me.objVoucher01TypeId.Text = Me.master_posvouchertype.Rows(0).Item("posvouchertype_id").ToString
            Me.objVoucher01TypeName.Text = Me.master_posvouchertype.Rows(0).Item("posvouchertype_descr").ToString
            Me.objVoucher01Type.Text = Me.master_posvouchertype.Rows(0).Item("posvouchertype_selectedtype").ToString
            Me.objVoucher01Disc.Text = Me.master_posvouchertype.Rows(0).Item("posvouchertype_disc").ToString
            Me.objVoucher01Method.Text = Me.master_posvouchertype.Rows(0).Item("posvouchertype_method").ToString
        Else
            Me.objVoucher01TypeId.Text = "000000"
            Me.objVoucher01TypeName.Text = "NONE"
            Me.objVoucher01Type.Text = "NONE"
            Me.objVoucher01Disc.Text = "0"
            Me.objVoucher01Method.Text = "NONE"
        End If


        If Me.master_poscustnat.Rows.Count > 0 Then
            Me.objCustomerNationalityId.Text = Me.master_poscustnat.Rows(0).Item("poscustnat_id").ToString
            Me.objCustomerNationality.Text = Me.master_poscustnat.Rows(0).Item("poscustnat_name").ToString
        Else
            Me.objCustomerNationalityId.Text = "WNI"
            Me.objCustomerNationality.Text = "INDONESIA"
        End If


        If Me.master_poscustage.Rows.Count > 0 Then
            Me.objCustomerAgeId.Text = Me.master_poscustage.Rows(0).Item("poscustage_id").ToString
            Me.objCustomerAge.Text = Me.master_poscustage.Rows(0).Item("poscustage_name").ToString
        Else
            Me.objCustomerAgeId.Text = "000000"
            Me.objCustomerAge.Text = "NONE"
        End If


        Me.objCustomerGenderId.Text = "N"
        Me.objCustomerGender.Text = "NONE"


        Me.objCustomerTelp.Enabled = True


        Me.master_posvouchertype_cust = New DataTable
        Me.master_posvouchertype_cust.Columns.Clear()
        Me.master_posvouchertype_cust.Columns.Add(New DataColumn("posvouchertype_id", GetType(System.String)))
        Me.master_posvouchertype_cust.Columns.Add(New DataColumn("customer_typename", GetType(System.String)))


        ' Masukkan ke link voucer customer
        Dim linksvc() As String = Me.POS.VOUCHER_LINKEDTO_CUSTOMERTYPE.Split(",")
        If linksvc.Length > 0 Then
            Dim iToken As Integer
            Dim token(2) As String
            Dim newrow As DataRow
            For iToken = 0 To linksvc.Length - 1
                token = linksvc(iToken).Split(":")
                If token.Length > 1 Then
                    newrow = Me.master_posvouchertype_cust.NewRow
                    newrow("posvouchertype_id") = Trim(token(0))
                    newrow("customer_typename") = Trim(token(1))
                    Me.master_posvouchertype_cust.Rows.Add(newrow)
                End If
            Next
            Me.master_posvouchertype_cust.AcceptChanges()
        End If



        ' ExtID
        If (Me.POS.EXTID_IS_ENABLED) Then
            Me.objBonExternal.Enabled = True
        Else
            Me.objBonExternal.Enabled = False
        End If



        ' SalesCode
        If (Me.POS.SALESPERSON_AUTOFILLTEXT <> "0" And Me.POS.SALESPERSON_AUTOFILLTEXT <> "") Then
            Me.objSalesId.Text = Me.POS.SALESPERSON_AUTOFILLTEXT
            Me.objSalesName.Text = Me.POS.SALESPERSON_AUTOFILLTEXT
        End If


        ' Stamp
        'If Me.POS.RegionId = "03400" Then
        '    Me.lblBonStamp.Visible = True
        '    Me.objBonStamp.Visible = True
        '    Me.objBonStamp.Enabled = True
        'Else
        '    Me.lblBonStamp.Visible = False
        '    Me.objBonStamp.Visible = False
        '    Me.objBonStamp.Enabled = False
        'End If


        Me.objBonEvent.Text = Me.POS.Event
        Me.objBonEvent.Visible = False


        ' Data di Combobox
        Me.objCboBonEventMain.Enabled = True
        Me.objCboBonEventMain.Items.Clear()
        Me.objCboBonEventMain.Items.Add("-- PILIH --")
        Me.objCboBonEventMain.Items.Add("REGULER")
        Me.objCboBonEventMain.Items.Add("ONLINE")
        Me.objCboBonEventMain.Items.Add("CHAT")
        Me.objCboBonEventMain.Items.Add("CHAT-AGENT")
        Me.objCboBonEventMain.Items.Add("STAMP")
        Me.objCboBonEventMain.Items.Add("CUSTOM")


        Me.objCboBonEventMain.SelectedIndex = 0

        Me.lbl_itemfrom.Visible = False
        Me.cbo_ItemFrom.Visible = False

        Me.cbo_ItemFrom.DataSource = Me.POS.GetSite()

        Me.cbo_ItemFrom.DisplayMember = "site_name"
        Me.cbo_ItemFrom.ValueMember = "site_id"

        Me.SelectOwnLocation()


        ' Me.cbo_ItemFrom.SelectedItem = dr(0)


    End Sub

    Private Sub dlgCancel()

        Me.Refresh()

        Dim args As Object = New Object() {}
        Dim f As dlgConfirmYesNo = New dlgConfirmYesNo
        Dim result As Object
        Dim fmask As Form = uiTrnPosEN.CreateMask(0.75)

        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Message = "Batalkan Transaksi ?"
        fmask.Show(Me)
        result = f.OpenDialog(fmask, args)
        fmask.Close()
        fmask.Dispose()
        f.Dispose()
        If result IsNot Nothing Then
            Me.POS = Nothing
            Me.myRetObj = Nothing
            Me.Close()
        End If

    End Sub

    Private Sub dlgOK()
        Dim startInfo As ProcessStartInfo = New ProcessStartInfo()


        ' Cek apakah pengisian kode voucher link ke customer
        Dim dr() As DataRow
        Dim site_id_from As String

        dr = Me.master_posvouchertype_cust.Select(String.Format("posvouchertype_id='{0}'", Me.objVoucher01TypeId.Text))
        If dr.Length > 0 Then
            If Me.objCustomerType.Text <> dr(0).Item("customer_typename") Then
                objError.SetError(Me.objVoucher01TypeId, "Voucher tidak diperbolekan")
                MessageBox.Show("Pemilihan voucher salah", "POS - Transaksi Baru", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                objError.SetError(Me.objVoucher01TypeId, "")
            End If
        End If

        Dim eventname As String = Me.POS.Event
        Dim eventtype = Me.objCboBonEventMain.Items(Me.objCboBonEventMain.SelectedIndex)
        Select Case eventtype
            Case "REGULER"
                eventname = Me.POS.Event

            Case "CHAT"
                eventname = "CHAT"

            Case "CHAT-AGENT"
                eventname = "AGENT"

            Case "ONLINE"
                eventname = "ONLINE"

            Case "STAMP"
                If Trim(Me.objBonEvent.Text) = "" Then
                    eventname = "STAMP:0"
                Else
                    eventname = "STAMP:" & Me.objBonEvent.Text
                End If

            Case "CUSTOM"
                eventname = Me.objBonEvent.Text

            Case Else
                'MessageBox.Show("Event harus dipilih", "Event", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'Return

        End Select



        site_id_from = Me.cbo_ItemFrom.SelectedValue
        If site_id_from = "0" Then
            MessageBox.Show("Sumber Item harus dipilih", "Item From", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If




        ' Cek diskon customer
        ' ada beberapa customer yang diberi privileges khusus, tambahan diskon apabila berbelanja
        ' caranya dengan menambahkan data customer tersebut, dan pada customer type name diberi kode VOU-xxxxxx
        ' xxxx adalah kode voucher, yang otomatis akan dipilih saat customer tersebut dipilih.
        ' masalahnya adalah apabila kasir memilih kode voucher dulu, dan customernya tidak diisi atau salah
        ' disini akan dicek, apakah voucher discount yang dipilih kasir bisa digunakan oleh customer
        Dim VOUCHERTYPE_PREFIX As String = Me.objVoucher01Type.Text.PadRight(6, " ").Substring(0, 6).ToUpper.Trim()
        If (VOUCHERTYPE_PREFIX = "VALID:") Then
            ' Jika type voucher diawali dengan VALID:.. maka, hanya customer tertentu yang bisa menggunakan voucher ini
            Dim CustomerVoucherStringInfo As String = Me.objVoucher01Type.Text.ToUpper().Replace(VOUCHERTYPE_PREFIX, "")
            Dim CustomerVoucherInfos As String() = CustomerVoucherStringInfo.Split("|")

            Dim CustomerVoucherCode
            If (CustomerVoucherInfos.Length > 1) Then
                CustomerVoucherCode = CustomerVoucherInfos(0)
                Dim masaberlakuvoucher = CustomerVoucherInfos(1)
                Dim dateinterval As TransStore.DateInterval = TransStore.DateInterval.FromFString(masaberlakuvoucher)
                If (Not TransStore.DateInterval.IsValidDate(Now, dateinterval)) Then
                    objError.SetError(Me.objVoucher01TypeId, "Kode voucher/promo yang dipilih tidak berlaku pada saat ini" & vbCrLf & String.Format("Masa berlaku voucher/promo {0:dd/MM/yyyy} s/d {1:dd/MM/yyyy}", dateinterval.DateStart, dateinterval.DateEnd))
                    MessageBox.Show(objError.GetError(Me.objVoucher01TypeId), "Kode voucher / promo invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Else
                    objError.SetError(Me.objVoucher01TypeId, "")
                End If
            Else
                CustomerVoucherCode = CustomerVoucherStringInfo
            End If

            ' Kode voucher yang valid adalah yang berawalan sama dengan variabel di CustomerVoucherCode
            If (Not Me.objCustomerType.Text.ToUpper().StartsWith(CustomerVoucherCode)) Then
                ' Customer yang dipilih tidak diperbolehkan menggunakan voucher ini
                objError.SetError(Me.objVoucher01TypeId, "Kode voucher/promo yang dipilih tidak bisa diberlakukan ke customer '" & Me.objCustomerName.Text & " '")
                MessageBox.Show(objError.GetError(Me.objVoucher01TypeId), "Kode voucher / promo invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                objError.SetError(Me.objVoucher01TypeId, "")
            End If
        ElseIf (VOUCHERTYPE_PREFIX = "PERIO:") Then
            ' Jika type voucher diawali dengan PERIO:, maka voucher berlaku untuk periode tanggal tertentu
            'format :YYYYMMDD000
            '        YYYYMMDD     -> Periode mulai berlaku voucher ini
            '                000  -> lama voucher berlaku
            Dim masaberlakuvoucher As String = Me.objVoucher01Type.Text.ToUpper().Replace(VOUCHERTYPE_PREFIX, "")
            Dim dateinterval As TransStore.DateInterval = TransStore.DateInterval.FromFString(masaberlakuvoucher)
            If (Not TransStore.DateInterval.IsValidDate(Now, dateinterval)) Then
                objError.SetError(Me.objVoucher01TypeId, "Kode voucher/promo yang dipilih tidak berlaku pada saat ini '" & Me.objCustomerName.Text & " '")
                MessageBox.Show(objError.GetError(Me.objVoucher01TypeId), "Kode voucher / promo invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                objError.SetError(Me.objVoucher01TypeId, "")
            End If
        End If


        Dim SALESPERSON_IS_MANDATORY As Boolean = Me.POS.SALESPERSON_IS_MANDATORY
        Dim EXTID_IS_ENABLED As Boolean = Me.POS.EXTID_IS_ENABLED
        Dim CUSTOMERINFO_IS_MANDATORY As Boolean = Me.POS.CUSTOMERINFO_IS_MANDATORY


        ' Untuk mode development, gak perlu input SalesPerson, ExternalId dan Customer Info
        If startInfo.EnvironmentVariables("POSENV") = "DEV" Then
            SALESPERSON_IS_MANDATORY = False
            EXTID_IS_ENABLED = False
            CUSTOMERINFO_IS_MANDATORY = False
        End If


        ' Cek apakah sales code sudah diisi
        If SALESPERSON_IS_MANDATORY Then
                If Trim(Me.objSalesId.Text) = "0" Or Trim(Me.objSalesId.Text) = "" Then
                    objError.SetError(Me.objSalesName, "Sales Code belum diisi")
                    MessageBox.Show("Sales Code belum diisi", "POS - Transaksi Baru", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Else
                    objError.SetError(Me.objSalesName, "")
                End If
            End If

            ' Cek apakah external id harus diisi
            If EXTID_IS_ENABLED Then
                If Me.POS.EXTID_IS_MANDATORY Then
                    If Trim(Me.objBonExternal.Text) = "0" Or Trim(Me.objBonExternal.Text) = "" Then
                        objError.SetError(Me.objBonExternal, "External ID belum diisi")
                        MessageBox.Show("External ID belum diisi", "POS - Transaksi Baru", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Me.objBonExternal.Focus()
                        Exit Sub
                    Else
                        objError.SetError(Me.objBonExternal, "")
                    End If
                End If
            End If


            ' Cek apakah customer harus diisi
            If CUSTOMERINFO_IS_MANDATORY Then

                If (Me.objCustomerGenderId.Text = "N") Then
                    objError.SetError(Me.lblGender, "Gender belum diisi")
                    MessageBox.Show(objError.GetError(Me.lblGender), "POS - Transaksi Baru", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Else
                    objError.SetError(Me.lblGender, "")
                End If


                If Trim(Me.objCustomerName.Text) = "" Then
                    objError.SetError(Me.objCustomerName, "Nama Customer belum diisi")
                    MessageBox.Show(objError.GetError(Me.objCustomerName), "POS - Transaksi Baru", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.objCustomerName.Focus()
                    Exit Sub
                Else
                    objError.SetError(Me.objCustomerName, "")
                End If

                If Trim(Me.objCustomerTelp.Text) = "" Then
                    objError.SetError(Me.objCustomerTelp, "NoTelp Customer belum diisi")
                    MessageBox.Show(objError.GetError(Me.objCustomerTelp), "POS - Transaksi Baru", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.objCustomerTelp.Focus()
                    Exit Sub
                Else
                    objError.SetError(Me.objCustomerTelp, "")
                End If

                If (Me.objCustomerTelp.Text.Substring(0, 1) <> "0") Then
                    objError.SetError(Me.objCustomerTelp, "NoTelp Customer salah")
                    MessageBox.Show(objError.GetError(Me.objCustomerTelp), "POS - Transaksi Baru", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.objCustomerTelp.Focus()
                    Exit Sub
                Else
                    objError.SetError(Me.objCustomerTelp, "")
                End If

                ' Cek apakah no telpon valid
                Dim phoneisvalid As Boolean = False
                Dim len = Me.objCustomerTelp.Text.Length
                If (len < 10) Then
                    If (Me.objCustomerTelp.Text = "01") Then
                        phoneisvalid = True
                    Else
                        phoneisvalid = False
                    End If
                Else
                    If (len > 12) Then
                        If Mid(Me.objCustomerTelp.Text.Trim(), 1, 2) = "08" Then
                            ' Nomor HP
                            phoneisvalid = True
                        Else
                            ' Bukan Nomor HP
                            phoneisvalid = False
                        End If

                    Else
                        ' Panjang nomor kurang
                        phoneisvalid = True
                    End If
                End If

                If (Not phoneisvalid) Then
                    objError.SetError(Me.objCustomerTelp, "No HP Customer salah." & vbCrLf & "Isilah dengan nomor HP. Minimal nomor adalah 10 digit, maximal 12 digit." & vbCrLf & "Apabila nomor HP tidak ada, isilah dengan '01'")
                    MessageBox.Show(objError.GetError(Me.objCustomerTelp), "POS - Transaksi Baru", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.objCustomerTelp.Focus()
                    Exit Sub
                Else
                    objError.SetError(Me.objCustomerTelp, "")
                End If
            End If




            ' Apabila no telpon diisi, cek nomor telponnya
            If Trim(Me.objCustomerTelp.Text) <> "" Then

                If (Me.objCustomerTelp.Text.Substring(0, 1) <> "0") Then
                    objError.SetError(Me.objCustomerTelp, "NoTelp Customer salah")
                    MessageBox.Show(objError.GetError(Me.objCustomerTelp), "POS - Transaksi Baru", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.objCustomerTelp.Focus()
                    Exit Sub
                Else
                    objError.SetError(Me.objCustomerTelp, "")
                End If

                ' Cek apakah no telpon valid
                Dim phoneisvalid As Boolean = False
                Dim len = Me.objCustomerTelp.Text.Length
                If (len < 10) Then
                    If (Me.objCustomerTelp.Text = "01") Then
                        phoneisvalid = True
                    Else
                        phoneisvalid = False
                    End If
                Else
                    If (len > 12) Then
                        If Mid(Me.objCustomerTelp.Text.Trim(), 1, 2) = "08" Then
                            ' Nomor HP
                            phoneisvalid = True
                        Else
                            ' Bukan Nomor HP
                            phoneisvalid = False
                        End If

                    Else
                        ' Panjang nomor kurang
                        phoneisvalid = True
                    End If

                End If

                If (Not phoneisvalid) Then
                    objError.SetError(Me.objCustomerTelp, "No HP Customer salah." & vbCrLf & "Isilah dengan nomor HP. Minimal nomor adalah 10 digit, maximal 12 digit." & vbCrLf & "Apabila nomor HP tidak ada, isilah dengan '01'")
                    MessageBox.Show(objError.GetError(Me.objCustomerTelp), "POS - Transaksi Baru", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.objCustomerTelp.Focus()
                    Exit Sub
                Else
                    objError.SetError(Me.objCustomerTelp, "")
                End If


            End If



            If Me.objCustomerPassport.Text.Trim() <> "" Then
                Dim email = Me.objCustomerPassport.Text.Trim()
                If Not Me.EmailAddressChecker(email) Then
                    objError.SetError(Me.objCustomerPassport, "Email salah." & vbCrLf & "Isikan email dengan format email benar!")
                    MessageBox.Show(objError.GetError(Me.objCustomerPassport), "POS - Transaksi Baru", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.objCustomerPassport.Focus()
                    Exit Sub
                Else
                    objError.SetError(Me.objCustomerPassport, "")
                End If
            End If


            Dim ReturnValue As TransStore.PosNewTransactionReturnValue = New TransStore.PosNewTransactionReturnValue
            With ReturnValue
                .CustomerNationalityId = Me.objCustomerNationalityId.Text
                .CustomerNationalityName = Me.objCustomerNationality.Text
                .CustomerGenderId = Me.objCustomerGenderId.Text
                .CustomerGenderName = Me.objCustomerGender.Text
                .CustomerAgeId = Me.objCustomerAgeId.Text
                .CustomerAgeName = Me.objCustomerAge.Text
                .CustomerId = Me.objCustomerId.Text
                .CustomerName = Me.objCustomerName.Text
                .CustomerNPWP = Me.objCustomerNPWP.Text
                .CustomerTelp = Me.objCustomerTelp.Text
                .CustomerType = IIf(Me.objCustomerType.Text <> "", Me.objCustomerType.Text, "CUSTOMER")
                .CustomerDisc = CDec(IIf(Me.objCustomerDisc.Text <> "", Me.objCustomerDisc.Text, "0"))
                .CustomerPassport = Me.objCustomerPassport.Text
                .Voucher01Id = Me.objVoucher01TypeId.Text
                .Voucher01Name = Me.objVoucher01TypeName.Text
                .Voucher01CodeNum = Me.objPaymentVoucher01Code.Text
                .Voucher01Type = Me.objVoucher01Type.Text
                .Voucher01Disc = Me.objVoucher01Disc.Text
                .Voucher01Method = Me.objVoucher01Method.Text
                .SalesId = Me.objSalesId.Text
                .SalesName = Me.objSalesName.Text
                .BonExternal = Me.objBonExternal.Text
                .BonEvent = eventname 'Me.objBonEvent.Text
                .SiteIdFrom = site_id_from
            End With
            Me.myRetObj = New Object() {ReturnValue}
            Me.POS = Nothing
            uiTrnPosEN.BeepDef2()
            Me.Close()
    End Sub

    Private Sub dlg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    End Sub

    Private Sub Object_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles objCustomerId.KeyDown, _
                objCustomerName.KeyDown, _
                objCustomerNPWP.KeyDown, _
                objPaymentVoucher01Code.KeyDown, _
                btnSalesBrowse.KeyDown, _
                objVoucher01TypeId.KeyDown, _
                objCustomerTelp.KeyDown, _
                btnCustomerBrowse.KeyDown, _
                objCustomerType.KeyDown, _
                objCustomerDisc.KeyDown, _
                objCustomerPassport.KeyDown, _
                objSalesId.KeyDown, _
                objBonExternal.KeyDown




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

    Private Sub btnF10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF10.Click
        Me.dlgOK()
    End Sub

    Private Sub objCustomerNationality_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles objCustomerNationality.TextChanged
        Dim obj As Label = CType(sender, Label)
        'If obj.Text = "ASING" Then
        '    obj.ForeColor = Color.SaddleBrown
        'Else
        '    obj.ForeColor = Color.Indigo
        'End If
    End Sub

    Private Sub btnSalesBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalesBrowse.Click
        uiTrnPosEN.BrowseSalesPerson(Me, Me.objSalesId, Me.objSalesName, Me.POS)
        Me.objSalesId.Focus()
        Me.objSalesId.SelectionStart = Len(Me.objSalesId.Text)
        Me.objSalesId.SelectionLength = 0
    End Sub

    Private Sub btnCustomerBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerBrowse.Click
        uiTrnPosEN.BrowseCustomer(Me, Me.objCustomerId, Me.objCustomerName, Me.objCustomerTelp, Me.objCustomerType, Me.objCustomerDisc, Me.POS)
        If Trim(Me.objCustomerName.Text) <> "" Then
            Me.objCustomerNPWP.Focus()
        Else
            Me.objCustomerName.Focus()
        End If
    End Sub


    Private Sub SetSalesCode()
        Dim salesid As String = Trim(Me.objSalesId.Text)
        Dim salesname As String
        If salesid <> "" Then
            salesname = Me.POS.GetSalesNameById(salesid)
            If salesname = "" Then
                Me.objSalesId.BackColor = Color.MistyRose
                Me.objError.SetError(Me.objSalesId, "SalesId '" & salesid & "' not found!")
            Else
                Me.objSalesId.BackColor = Color.Gainsboro
                Me.objSalesId.ReadOnly = True
                Me.objError.SetError(Me.objSalesId, "")
                Me.objSalesName.Text = salesname
            End If

        End If

    End Sub


    Private Sub objCustomerType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles objCustomerType.TextChanged
        Dim obj As TextBox = CType(sender, TextBox)
        If obj.Text = "" Then Exit Sub


        Dim fields() As String = obj.Text.Split("-")
        Dim typeprefix As String
        Dim vouchertypeid As String
        Dim i As Integer

        If fields.Length > 1 Then
            typeprefix = fields(0)
            If typeprefix = "VOU" Then
                vouchertypeid = fields(1)

                For i = 1 To Me.master_posvouchertype.Rows.Count
                    If Me.master_posvouchertype.Rows(i - 1).Item("posvouchertype_id").ToString = vouchertypeid Then
                        posvouchertypeindex = i
                        Me.objVoucher01TypeId.Text = Me.master_posvouchertype.Rows(i - 1).Item("posvouchertype_id").ToString
                        Me.objVoucher01TypeName.Text = Me.master_posvouchertype.Rows(i - 1).Item("posvouchertype_descr").ToString
                        Me.objVoucher01Type.Text = Me.master_posvouchertype.Rows(i - 1).Item("posvouchertype_selectedtype").ToString
                        Me.objVoucher01Disc.Text = Me.master_posvouchertype.Rows(i - 1).Item("posvouchertype_disc").ToString
                        Me.objVoucher01Method.Text = Me.master_posvouchertype.Rows(i - 1).Item("posvouchertype_method").ToString
                        Exit For
                    End If
                Next

            End If
        End If


    End Sub


    Private Sub objSalesName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles objSalesName.TextChanged
        Dim obj As Label = CType(sender, Label)
        If Trim(Me.objSalesId.Text) = "0" Or Trim(Me.objSalesId.Text) = "" Then
        Else
            Me.objError.SetError(Me.objSalesName, "")
        End If
    End Sub


    Private Sub objVoucher01TypeName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles objVoucher01TypeName.TextChanged
        Dim obj As Label = CType(sender, Label)

        If obj.Text = "NONE" Then
            Me.objPaymentVoucher01Code.Enabled = False
        Else
            Me.objPaymentVoucher01Code.Enabled = True
        End If
    End Sub


    Private Sub objCustomerTelp_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles objCustomerTelp.KeyPress
        e.Handled = Not (e.KeyChar = Chr(Keys.Back) Or e.KeyChar = "1" Or e.KeyChar = "2" Or e.KeyChar = "3" Or e.KeyChar = "4" Or e.KeyChar = "5" Or e.KeyChar = "6" Or e.KeyChar = "7" Or e.KeyChar = "8" Or e.KeyChar = "9" Or e.KeyChar = "0")
    End Sub

    Private Sub objCustomerName_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles objCustomerName.KeyPress
        e.Handled = Not (Char.IsLetter(e.KeyChar) Or e.KeyChar = Chr(Keys.Back) Or e.KeyChar = " " Or e.KeyChar = "1" Or e.KeyChar = "2" Or e.KeyChar = "3" Or e.KeyChar = "4" Or e.KeyChar = "5" Or e.KeyChar = "6" Or e.KeyChar = "7" Or e.KeyChar = "8" Or e.KeyChar = "9" Or e.KeyChar = "0")
    End Sub


    Private Sub btnCustomerSearch_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles btnCustomerSearch.LinkClicked
        ' Me.POS.RPCAddress

        Dim dlg As dlgCustomerSearch = New dlgCustomerSearch()
        Dim res As DialogResult

        dlg.RPCAddress = Me.POS.RPCAddress
        dlg.POS = Me.POS

        res = dlg.ShowDialog(Me)
        If res = Windows.Forms.DialogResult.OK Then
            Me.objCustomerId.Text = dlg.CustomerId
            Me.objCustomerName.Text = dlg.CustomerName
            Me.objCustomerTelp.Text = dlg.CustomerTelp
            Me.objCustomerGenderId.Text = dlg.GenderId
            Me.objCustomerType.Text = dlg.CustomerTypeName
            Me.objCustomerPassport.Text = dlg.CustomerEmail
            Me.objCustomerDisc.Text = dlg.Disc
            If (dlg.GenderId = "F" Or dlg.GenderId = "M") Then
                If (dlg.GenderId = "F") Then
                    Me.objCustomerGender.Text = "FEMALE"
                Else
                    Me.objCustomerGender.Text = "MALE"
                End If
            End If
        End If

        Me.objCustomerName.Focus()
        Me.objCustomerName.SelectionStart = Me.objCustomerName.Text.Length
        Me.objCustomerName.SelectionLength = 0

    End Sub



    Private Sub btnESC_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnESC.Click
        Me.dlgCancel()
    End Sub



    Function EmailAddressChecker(ByVal emailAddress As String) As Boolean
        Dim r As System.Text.RegularExpressions.Regex = Nothing
        Dim regExPattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$"
        If System.Text.RegularExpressions.Regex.IsMatch(emailAddress, regExPattern) Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles objCboBonEventMain.SelectedIndexChanged
        Dim eventname = Me.objCboBonEventMain.Items(Me.objCboBonEventMain.SelectedIndex)


        'REGULER
        'e-BAZAR
        'STAMP




        Select Case eventname
            Case "REGULER"
                Me.objBonEvent.Text = Me.POS.Event
                Me.objBonEvent.Visible = False
                Me.objBonEvent.Enabled = False
                Me.lbl_itemfrom.Visible = False
                Me.cbo_ItemFrom.Visible = False
                Me.SelectOwnLocation()


            Case "e-BAZAR"
                Me.objBonEvent.Text = "e-BAZAR"
                Me.objBonEvent.Visible = False
                Me.objBonEvent.Enabled = False
                Me.lbl_itemfrom.Visible = False
                Me.cbo_ItemFrom.Visible = False
                Me.SelectOwnLocation()

            Case "STAMP"
                Me.objBonEvent.Text = ""
                Me.objBonEvent.Visible = True
                Me.objBonEvent.Enabled = True
                Me.objBonEvent.MaxLength = 2
                Me.lbl_itemfrom.Visible = False
                Me.cbo_ItemFrom.Visible = False
                Me.SelectOwnLocation()

            Case "ONLINE"
                Me.objBonEvent.Text = Me.POS.Event
                Me.objBonEvent.Visible = False
                Me.objBonEvent.Enabled = False
                Me.lbl_itemfrom.Visible = False
                Me.cbo_ItemFrom.Visible = False
                Me.SelectOwnLocation()

            Case "CHAT"
                Me.objBonEvent.Text = Me.POS.Event
                Me.objBonEvent.Visible = False
                Me.objBonEvent.Enabled = False
                Me.lbl_itemfrom.Visible = False
                Me.cbo_ItemFrom.Visible = False
                Me.SelectOwnLocation()

            Case "CHAT-AGENT"
                Me.objBonEvent.Text = Me.POS.Event
                Me.objBonEvent.Visible = False
                Me.objBonEvent.Enabled = False
                Me.lbl_itemfrom.Visible = True
                Me.cbo_ItemFrom.Visible = True
                Me.cbo_ItemFrom.SelectedIndex = 0

            Case "CUSTOM"
                Me.objBonEvent.Text = Me.POS.Event
                Me.objBonEvent.Visible = True
                Me.objBonEvent.Enabled = True
                Me.objBonEvent.MaxLength = 13
                Me.lbl_itemfrom.Visible = False
                Me.cbo_ItemFrom.Visible = False
                Me.SelectOwnLocation()

        End Select
    End Sub


    Private Sub btnCtcorpMpcScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCtcorpMpcScan.Click
        Dim dlg As dlgAlloMemberScan
        dlg = New dlgAlloMemberScan()
        dlg.start(Me.POS)
        dlg.MaximizeBox = False
        dlg.MinimizeBox = False
        dlg.ShowInTaskbar = False
        dlg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        dlg.StartPosition = FormStartPosition.CenterScreen
        dlg.Size = Me.Size
        dlg.Top = Me.Top

        Dim res As DialogResult = dlg.ShowDialog(Me)
        If res = Windows.Forms.DialogResult.OK Then
            Me.objCustomerId.Text = dlg.Data.Telp
            Me.objCustomerName.Text = dlg.Data.Nama
            Me.objCustomerTelp.Text = dlg.Data.Telp
            Me.objCustomerType.Text = "MPC"
            Me.objCustomerDisc.Text = "0"
            Me.objCustomerPassport.Text = dlg.Data.Email
            Me.objCustomerNPWP.Text = dlg.Data.MDC


            ' Ambil data dari master customer
            Try
                Dim customer_id As String = Me.objCustomerId.Text
                Dim cust As TransStore.POS.CustomerData

                cust = Me.POS.GetCustomerData(customer_id)
                If cust.Id IsNot Nothing Then
                    Me.objVoucher01Type.Text = cust.Type
                    Me.objVoucher01Disc.Text = cust.Discount
                    Me.objVoucher01Method.Text = cust.Method
                    Me.objVoucher01TypeId.Text = cust.VoucherTypeId
                    Me.objVoucher01TypeName.Text = cust.VoucherTypeName

                    Me.objBonExternal.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Get Customer Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try


        End If


    End Sub

    Private Sub btn_PgDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PgDown.Click
        Me.Key(Me.btn_PgDown, Keys.PageDown, False)
    End Sub

    Private Sub btn_PgUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PgUp.Click
        Me.Key(Me.btn_PgUp, Keys.PageDown, False)
    End Sub

    Private Sub PnlFormMain_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PnlFormMain.Paint

    End Sub



    Public Sub SelectOwnLocation()
        For i As Integer = 1 To Me.cbo_ItemFrom.Items.Count
            Dim t As Integer = i

            Dim dv As DataRowView = Me.cbo_ItemFrom.Items(i)
            If dv.Item("site_id") = Me.POS.RegionId & ":" & Me.POS.BranchId Then
                Me.cbo_ItemFrom.SelectedItem = dv
                Exit For
            End If
        Next
    End Sub


    Private Sub btnTfiMembership_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTfiMembership.Click
        Dim dlg As dlgTfiMemberScan
        dlg = New dlgTfiMemberScan()
        dlg.start(Me.POS)
        dlg.MaximizeBox = False
        dlg.MinimizeBox = False
        dlg.ShowInTaskbar = False
        dlg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        dlg.StartPosition = FormStartPosition.CenterScreen
        dlg.Size = Me.Size
        dlg.Top = Me.Top

        Dim res As DialogResult = dlg.ShowDialog(Me)
        If res = Windows.Forms.DialogResult.OK Then
            Dim member As dlgTfiMemberScan.TfiMember = dlg.getMemberData()
            If member.event_id <> "" Then
                Me.objCboBonEventMain.Enabled = False
                Me.objCboBonEventMain.SelectedIndex = 6
                Me.objBonEvent.Enabled = False
                Me.objBonEvent.Visible = True
                Me.objBonEvent.Text = "EVT:" & member.event_id & ":" & member.voubatch_id & ":" & member.room_id
            End If


            Me.objCustomerTelp.Enabled = False


            Me.objCustomerTelp.Text = member.getPhoneNumber()
            Me.objCustomerName.Text = member.name

        End If
    End Sub
End Class
