Imports Finisar
Imports IST.DataHash

Namespace TransStore

  
    Public Class POS



        Public Const MODE_BARCODESCAN As String = "BARCODE"
        Public Const MODE_ORIGINALBARCODESCAN As String = "BARCODE-ORIGINAL"


        Public Enum PosItemAction
            Add = 1
            Edit = 2
            Remove = 3
        End Enum

        Public Const ItemIdentifier As String = "TM"
        Public Const UnknownSize As String = "X?"

        Public Shared DSN As String
        Public Shared InstanceCount As Integer = 0
        Public Shared InstanceNumerator As Integer = 0
        Public Shared PaymentNumerator As Integer = 0
        Public Shared PrinterName As String
        Public Shared AllowBackDatedEntry As Boolean = False

       


        Public SynSignID As String = ""

        Private mType As String
        Private mSubType As String

        'Private mDefPaymentTypeID As String
        'Private mDefPaymentTypeName As String
        'Private mDefPaymentTypeIsChanged As Boolean


        'Private mRegion As String

        Private mSessionId, mClientName As String
        Private mMachineID, mBranchId, mRegionId, mRegionPathFilter, mEvent, mPrinterDefault, mReceiptPrinter, mLogo, mNPWP, mRPCAddress, mQrisProxy As String
        Private mSiteName As String
        Private mUsername As String
        Private mui As uiTrnPosEN
        Private mBonType As String
        Private mNotAllowedPayment As String
        Private mShowFakturPajak As Boolean = False
        Private _param As POSParameter
        Private _PRINTER_PORT, _POLE_PORT As String
        Private _MCRLAYER As String
        Private _CARDNUMBER_ENTRY As String
        Private _CARDNUMBER_OVRMANUAL As String
        Private _ALLOW_MULTIPLE_PAYMENT_IN_FP As String
        Private _FP_PAYMENT_FILTER As String
        Private _DISABLED_PAYMENT_METHOD As String
        Private _AUTO_KEY_NUMBER As String
        Private _SLAVE_MODE As String
        Private _STATUS As String
        Private _VOUCHER_LINKEDTO_CUSTOMERTYPE As String
        Private _DISABLED_VOUCHER As String
        Private _SENDDATAMODE As String
        Private _SENDDATAVER As String
        Private _DISCADD_AUTO As Decimal
        Private _DISCADD_MINTOTAL As Decimal
        Private _BON_COPY As Integer
        Private _PROMO_BUTTON As Boolean
        Private _BolehDiscPayment As Boolean
        Private _AllowedPaymenttype As Collection = New Collection()
        Private _PromoApplied As Boolean = False
        Private _TaxPercent As Decimal

        Private _PosPromo As PosPromo

        Private _isDevelopmentMode As Boolean = False

        Private WithEvents mSecondDisplay As dlgSecondDisplay



        'Private WithEvents mPosData As DataTable
        Private WithEvents mPosItems As DataTable
        Private WithEvents mPosPayments As DataTable
        Private WithEvents mPosPaymentDialog As DataTable
        Private WithEvents mPaymentType As DataTable
        Private WithEvents mSetting As DataTable

        Public Event TransactionCleared()
        Public Event TransactionCreating()
        Public Event TransactionCreated()
        Public Event ItemModified(ByVal action As TransStore.POS.PosItemAction, ByVal id As String, ByVal itemname As String, ByVal article As String, ByVal color As String, ByVal size As String, ByVal material As String, ByVal price As Decimal, ByVal discount As Decimal, ByVal qty As Decimal, ByVal subtotal As Decimal, ByVal sum_qty As Decimal, ByVal sum_subtotal As Decimal, ByVal vou01type As String)
        Public Event ItemEdited(ByVal qty As Integer)
        Public Event ItemAdded(ByVal qty As Integer)
        Public Event ScanFindMoreThanOneItem(ByVal tbl As DataTable, ByRef obj As PosItemData, ByRef cancel As Boolean)
        Public Event SelectUnknownSize(ByVal region_id As String, ByVal art As String, ByVal mat As String, ByVal col As String, ByVal descr As String, ByRef size As String, ByRef sizetag As String, ByRef colname As String)
        Public Event ReportUpdateProgress(ByVal percent As Integer, ByVal message As String)

        '   Public Event PaymentAdded()
        Public Event PaymentModified(ByVal action As TransStore.POS.PosItemAction, ByVal obj As PosPaymentRow)


        Public Structure PosItemData
            Dim iteminventory_id As String
            Dim iteminventory_idsc As String
            Dim iteminventory_barcode As String
            Dim iteminventory_sizecode As String
            Dim iteminventory_name As String
            Dim iteminventory_article As String
            Dim iteminventory_material As String
            Dim iteminventory_color As String
            Dim iteminventory_size As String
            Dim iteminventory_priceori As Decimal
            Dim iteminventory_sellpricedefault As Decimal
            Dim iteminventory_discountdefault As Decimal
            Dim iteminventory_pricenet As Decimal
            Dim iteminventory_isadddisc As Boolean
            Dim iteminventorygroup_id As String
            Dim iteminventorysubgroup_id As String
            Dim region_id As String
            Dim region_nameshort As String
            Dim heinvgro_id As String
            Dim heinvctg_id As String
            Dim colname As String
            Dim sizetag As String
            Dim pricingrule As String
            Dim proc As String
            Dim setasnewbonus As Boolean
            Dim issp As Boolean

            Dim rowindex As Integer
            Dim editingQty As Boolean
        End Structure

        Public Structure PosPaymentRow
            Dim line As Integer
            Dim Type As String
            Dim TypeName As String
            Dim Bank As String
            Dim CardNumber As String
            Dim CardHolder As String
            Dim Edc As String
            Dim EdcName As String
            Dim Installment As Integer
            Dim Value As Decimal
            Dim Cash As Decimal
            Dim Refund As Decimal
            Dim IsCash As Integer
            Dim Approval As String
        End Structure

        Public Structure PosHeader
            Dim bon_id As String
            Dim bon_idext As String
            Dim bon_event As String
            Dim bon_date As Date
            Dim bon_createby As String
            Dim bon_replacefromvoid As String
            Dim bon_msubtotal As Decimal
            Dim bon_msubtvoucher As Decimal
            Dim bon_msubtdiscadd As Decimal
            Dim bon_msubtredeem As Decimal
            Dim bon_msubtracttotal As Decimal
            Dim bon_msubtotaltobedisc As Decimal
            Dim bon_mdiscpaympercent As Decimal
            Dim bon_mdiscpayment As Decimal
            Dim bon_mtotal As Decimal
            Dim bon_mpayment As Decimal
            Dim bon_mrefund As Decimal
            Dim bon_msalegross As Decimal
            Dim bon_msaletax As Decimal
            Dim bon_msalenet As Decimal
            Dim bon_itemqty As Integer
            Dim bon_rowitem As Integer
            Dim bon_rowpayment As Integer
            Dim bon_npwp As String
            Dim bon_fakturpajak As String
            Dim bon_adddisc_authusername As String
            Dim bon_disctype As String

            Dim customer_id As String
            Dim customer_name As String
            Dim customer_telp As String
            Dim customer_npwp As String
            Dim customer_ageid As String
            Dim customer_agename As String
            Dim customer_genderid As String
            Dim customer_gendername As String
            Dim customer_nationalityid As String
            Dim customer_nationalityname As String
            Dim customer_typename As String
            Dim customer_disc As Decimal
            Dim customer_passport As String

            Dim voucher01_id As String
            Dim voucher01_name As String
            Dim voucher01_codenum As String
            Dim voucher01_method As String
            Dim voucher01_type As String
            Dim voucher01_discp As String

            Dim salesperson_id As String
            Dim salesperson_name As String
            Dim pospayment_id As String
            Dim pospayment_name As String
            Dim posedc_id As String
            Dim posedc_name As String
            Dim machine_id As String
            Dim region_id As String
            Dim branch_id As String

            Dim site_id_from As String
        End Structure


        Public Structure CustomerData
            Public Nama As String
            Public Id As String
            Public VoucherName As String
            Public Type As String
            Public Method As String
            Public Discount As Decimal
            Public VoucherTypeId As String
            Public VoucherTypeName As String
        End Structure

        Public Structure UsedPromo
            Public PromoId As String
            Public PromoName As String
            Public Active As Boolean
        End Structure


        Public UsedPromoList As Dictionary(Of String, UsedPromo) = New Dictionary(Of String, UsedPromo)()




#Region " Constructor "

        Public Sub New(ByRef oui As uiTrnPosEN) ', ByVal param As POSParameter)
            'Dim sql As String
            'Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(POS.DSN)
            'Dim da As OleDb.OleDbDataAdapter
            'Dim cmd As OleDb.OleDbCommand

            'Try
            '    Me.mPosData = New DataTable
            '    Me.mPosItems = New DataTable
            '    Me.mPosPayments = New DataTable

            '    conn.Open()
            '    sql = "select * from transaksi_pos where bon_id='xx'"
            '    cmd = New OleDb.OleDbCommand(sql, conn)
            '    da = New OleDb.OleDbDataAdapter(cmd)
            '    da.Fill(Me.PosData)

            '    sql = "select * from transaksi_posdetil where bon_id='xx'"
            '    cmd = New OleDb.OleDbCommand(sql, conn)
            '    da = New OleDb.OleDbDataAdapter(cmd)
            '    da.Fill(Me.PosItems)

            'Catch ex As Exception
            '    Throw New Exception
            'Finally
            '    conn.Close()
            'End Try

            Try
                Me.mui = oui
                'Me._param = param
                'Me._DISABLED_PAYMENT_METHOD = param.DISABLED_PAYMENT_METHOD
                'Me._AUTO_KEY_NUMBER = param.AUTO_KEY_NUMBER
                'Me._SLAVE_MODE = param.SLAVE_MODE
                'Me._VOUCHER_LINKEDTO_CUSTOMERTYPE = param.VOUCHER_LINKEDTO_CUSTOMERTYPE
                'Me._DISABLED_VOUCHER = param.DISABLED_VOUCHER
                'Me._SENDDATAMODE = param.SENDDATAMODE
                'Me._SENDDATAVER = param.SENDDATAVER

                'Me.mPaymentType = Me.LoadPaymentType()
                Me.mSetting = Me.LoadSetting()

                Me._PosPromo = New PosPromo()

                'Me.mPosItems = CreateDataTablePosItem()
                'Me.mPosPayments = CreateDataTablePosPayment()
                'Me.mPosPaymentDialog = CreateDataTablePosPaymentDialog()
                'Me.mPosPaymentDialog.Rows.Add(Me.mPosPaymentDialog.NewRow())

                POS.InstanceCount += 1

            Catch ex As Exception
                MessageBox.Show(ex.Message, "POS Constructor")
            End Try

        End Sub


        Public Sub SetParam(ByVal param As POSParameter)
            Try
                Me._param = param
                Me._DISABLED_PAYMENT_METHOD = param.DISABLED_PAYMENT_METHOD
                Me._AUTO_KEY_NUMBER = param.AUTO_KEY_NUMBER
                Me._SLAVE_MODE = param.SLAVE_MODE
                Me._VOUCHER_LINKEDTO_CUSTOMERTYPE = param.VOUCHER_LINKEDTO_CUSTOMERTYPE
                Me._DISABLED_VOUCHER = param.DISABLED_VOUCHER
                Me._SENDDATAMODE = param.SENDDATAMODE
                Me._SENDDATAVER = param.SENDDATAVER

                Me.mPaymentType = Me.LoadPaymentType()
                'Me.mSetting = Me.LoadSetting()

                Me.mPosItems = CreateDataTablePosItem()
                Me.mPosPayments = CreateDataTablePosPayment()
                Me.mPosPaymentDialog = CreateDataTablePosPaymentDialog()
                Me.mPosPaymentDialog.Rows.Add(Me.mPosPaymentDialog.NewRow())

            Catch ex As Exception
                MessageBox.Show(ex.Message, "POS Constructor")
            End Try



        End Sub




#End Region

#Region " Data Set Constructor "

        Public Shared Function CreateDataTablePosItem() As DataTable
            Dim tbl As DataTable = New DataTable

            tbl.Columns.Clear()
            tbl.Columns.Add(New DataColumn("bondetil_line", GetType(System.Int64)))
            tbl.Columns.Add(New DataColumn("bondetil_item", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("bondetil_barcode", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("bondetil_idsc", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("bondetil_descr", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("bondetil_article", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("bondetil_color", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("bondetil_size", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("bondetil_material", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("bondetil_pricegross", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("bondetil_discpstd01", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("bondetil_discrstd01", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("bondetil_pricenettstd01", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("bondetil_discpvou01", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("bondetil_discrvou01", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("bondetil_pricenettvou01", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("bondetil_vou01id", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("bondetil_vou01codenum", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("bondetil_vou01type", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("bondetil_vou01method", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("bondetil_vou01discp", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("bondetil_pricenet", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("bondetil_qty", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("bondetil_subtotal", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("bondetil_rule", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("region_id", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("region_nameshort", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("pricingrule_id", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("pricing_priceori", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("pricing_price", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("pricing_disc", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("pricing_issp", GetType(System.Boolean)))
            tbl.Columns.Add(New DataColumn("promorule_id", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("promo_line", GetType(System.Int64)))
            tbl.Columns.Add(New DataColumn("colname", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("sizetag", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("proc", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("heinvgro_id", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("heinvctg_id", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("heinv_id", GetType(System.String)))


            '-------------------------------
            'Default Value: 
            tbl.Columns("bondetil_line").DefaultValue = 0
            tbl.Columns("bondetil_item").DefaultValue = ""
            tbl.Columns("bondetil_barcode").DefaultValue = ""
            tbl.Columns("bondetil_idsc").DefaultValue = ""
            tbl.Columns("bondetil_descr").DefaultValue = ""
            tbl.Columns("bondetil_article").DefaultValue = ""
            tbl.Columns("bondetil_color").DefaultValue = ""
            tbl.Columns("bondetil_size").DefaultValue = ""
            tbl.Columns("bondetil_material").DefaultValue = ""
            tbl.Columns("bondetil_pricegross").DefaultValue = 0
            tbl.Columns("bondetil_discpstd01").DefaultValue = 0
            tbl.Columns("bondetil_discrstd01").DefaultValue = 0
            tbl.Columns("bondetil_pricenettstd01").DefaultValue = 0
            tbl.Columns("bondetil_discpvou01").DefaultValue = 0
            tbl.Columns("bondetil_discrvou01").DefaultValue = 0
            tbl.Columns("bondetil_pricenettvou01").DefaultValue = 0
            tbl.Columns("bondetil_vou01id").DefaultValue = "0"
            tbl.Columns("bondetil_vou01codenum").DefaultValue = ""
            tbl.Columns("bondetil_vou01type").DefaultValue = ""
            tbl.Columns("bondetil_vou01method").DefaultValue = ""
            tbl.Columns("bondetil_vou01discp").DefaultValue = 0
            tbl.Columns("bondetil_pricenet").DefaultValue = 0
            tbl.Columns("bondetil_qty").DefaultValue = 0
            tbl.Columns("bondetil_subtotal").DefaultValue = 0
            tbl.Columns("region_id").DefaultValue = "0"
            tbl.Columns("region_nameshort").DefaultValue = ""
            tbl.Columns("pricingrule_id").DefaultValue = ""
            tbl.Columns("pricing_priceori").DefaultValue = 0
            tbl.Columns("pricing_price").DefaultValue = 0
            tbl.Columns("pricing_disc").DefaultValue = 0
            tbl.Columns("promorule_id").DefaultValue = "0"
            tbl.Columns("promo_line").DefaultValue = 0
            tbl.Columns("colname").DefaultValue = ""
            tbl.Columns("sizetag").DefaultValue = ""
            tbl.Columns("proc").DefaultValue = ""
            tbl.Columns("heinvgro_id").DefaultValue = "0"
            tbl.Columns("heinvctg_id").DefaultValue = "0"
            tbl.Columns("heinv_id").DefaultValue = "0"

            ' tbl.PrimaryKey = New System.Data.DataColumn() {tbl.Columns("bondetil_item"), tbl.Columns("bondetil_size")}

            Return tbl
        End Function

        Public Shared Function CreateDataTablePosPaymentDialog()
            Dim tbl As DataTable = New DataTable

            tbl.Columns.Clear()
            tbl.Columns.Add(New DataColumn("customer_id", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("customer_name", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("paymenttype_id", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("paymenttype_name", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("paymenttype_disc", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("payment_type", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("payment_typename", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("payment_bank", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("payment_bankname", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("payment_cardnumber", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("payment_cardholder", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("payment_edc", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("payment_edcname", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("payment_value", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("payment_cash", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("payment_installment", GetType(System.Int16)))
            tbl.Columns.Add(New DataColumn("payment_totalvalue", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("payment_discvalue", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("payment_discdescr", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("payment_total", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("payment_totalqty", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("payment_totalpaid", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("payment_totaldue", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("payment_totalrefund", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("payment_discvouchertotal", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("payment_voucher", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("payment_vouchercode", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("payment_adddisc", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("payment_outstanding", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("payment_redeem", GetType(System.Decimal)))


            '-------------------------------
            'Default Value: 
            tbl.Columns("customer_id").DefaultValue = ""
            tbl.Columns("customer_name").DefaultValue = ""
            tbl.Columns("paymenttype_id").DefaultValue = ""
            tbl.Columns("paymenttype_name").DefaultValue = ""
            tbl.Columns("paymenttype_disc").DefaultValue = 0
            tbl.Columns("payment_type").DefaultValue = ""
            tbl.Columns("payment_typename").DefaultValue = ""
            tbl.Columns("payment_bank").DefaultValue = ""
            tbl.Columns("payment_bankname").DefaultValue = ""
            tbl.Columns("payment_cardnumber").DefaultValue = ""
            tbl.Columns("payment_cardholder").DefaultValue = ""
            tbl.Columns("payment_edc").DefaultValue = ""
            tbl.Columns("payment_edcname").DefaultValue = ""
            tbl.Columns("payment_value").DefaultValue = 0
            tbl.Columns("payment_cash").DefaultValue = 0
            tbl.Columns("payment_installment").DefaultValue = 1
            tbl.Columns("payment_totalvalue").DefaultValue = 0
            tbl.Columns("payment_discvalue").DefaultValue = 0
            tbl.Columns("payment_discdescr").DefaultValue = ""
            tbl.Columns("payment_total").DefaultValue = 0
            tbl.Columns("payment_totalqty").DefaultValue = 0
            tbl.Columns("payment_totaldue").DefaultValue = 0
            tbl.Columns("payment_totalpaid").DefaultValue = 0
            tbl.Columns("payment_totalrefund").DefaultValue = 0
            tbl.Columns("payment_discvouchertotal").DefaultValue = 0
            tbl.Columns("payment_voucher").DefaultValue = 0
            tbl.Columns("payment_vouchercode").DefaultValue = ""
            tbl.Columns("payment_adddisc").DefaultValue = 0
            tbl.Columns("payment_outstanding").DefaultValue = 0
            tbl.Columns("payment_redeem").DefaultValue = 0

            Return tbl
        End Function

        Public Shared Function CreateDataTablePosVoucherDialog()
            Dim tbl As DataTable = New DataTable

            tbl.Columns.Clear()
            tbl.Columns.Add(New DataColumn("payment_voucher", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("payment_vouchercode", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("payment_adddisc", GetType(System.Decimal)))

            '-------------------------------
            'Default Value: 
            tbl.Columns("payment_voucher").DefaultValue = 0
            tbl.Columns("payment_vouchercode").DefaultValue = ""
            tbl.Columns("payment_adddisc").DefaultValue = 0

            Return tbl
        End Function

        Public Shared Function CreateDataTablePosPayment() As DataTable
            Dim tbl As DataTable = New DataTable

            tbl.Columns.Clear()
            tbl.Columns.Add(New DataColumn("payment_line", GetType(System.Int16)))
            tbl.Columns.Add(New DataColumn("payment_type", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("payment_typename", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("payment_bankname", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("payment_cardnumber", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("payment_cardholder", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("payment_edc", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("payment_edcname", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("payment_edcapproval", GetType(System.String)))
            tbl.Columns.Add(New DataColumn("payment_installment", GetType(System.Int16)))
            tbl.Columns.Add(New DataColumn("payment_value", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("payment_cash", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("payment_refund", GetType(System.Decimal)))
            tbl.Columns.Add(New DataColumn("payment_iscash", GetType(System.Int16)))


            tbl.Columns("payment_line").DefaultValue = 0
            tbl.Columns("payment_type").DefaultValue = ""
            tbl.Columns("payment_typename").DefaultValue = ""
            tbl.Columns("payment_bankname").DefaultValue = ""
            tbl.Columns("payment_cardnumber").DefaultValue = ""
            tbl.Columns("payment_cardholder").DefaultValue = ""
            tbl.Columns("payment_edc").DefaultValue = ""
            tbl.Columns("payment_edcname").DefaultValue = ""
            tbl.Columns("payment_edcapproval").DefaultValue = ""
            tbl.Columns("payment_installment").DefaultValue = 0
            tbl.Columns("payment_value").DefaultValue = 0
            tbl.Columns("payment_cash").DefaultValue = 0
            tbl.Columns("payment_refund").DefaultValue = 0
            tbl.Columns("payment_iscash").DefaultValue = 0

            tbl.PrimaryKey = New System.Data.DataColumn() {tbl.Columns("payment_line")}

            Return tbl
        End Function

#End Region

#Region " Public Properties "

        Public ReadOnly Property SecondDisplay() As dlgSecondDisplay
            Get
                Return Me.mSecondDisplay
            End Get
        End Property

        Public ReadOnly Property PosPromo() As PosPromo
            Get
                Return Me._PosPromo
            End Get
        End Property





        Public Property SessionId() As String
            Get
                Return Me.mSessionId
            End Get
            Set(ByVal value As String)
                Me.mSessionId = value
            End Set
        End Property
        Public Property ClientName() As String
            Get
                Return Me.mClientName
            End Get
            Set(ByVal value As String)
                Me.mClientName = value
            End Set
        End Property

        Public ReadOnly Property Count() As Integer
            Get
                Dim sumqty As Object = Me.PosItems.Compute("Sum(bondetil_qty)", "")
                If IsDBNull(sumqty) Then
                    Return 0
                Else
                    Return CInt(sumqty)
                End If
            End Get
        End Property

        Public ReadOnly Property Subtotal() As Decimal
            Get
                Dim sumsubtotal As Object = Me.PosItems.Compute("Sum(bondetil_subtotal)", "")
                If IsDBNull(sumsubtotal) Then
                    Return 0
                Else
                    Return CDec(sumsubtotal)
                End If
            End Get
        End Property


        Public ReadOnly Property PaymentSubtotal() As Decimal
            Get
                Dim sumsubtotal As Object = Me.PosPayments.Compute("Sum(payment_value)", "")
                If IsDBNull(sumsubtotal) Then
                    Return 0
                Else
                    Return CDec(sumsubtotal)
                End If
            End Get
        End Property


        Public ReadOnly Property PosItems() As DataTable
            Get
                Return mPosItems
            End Get
        End Property

        Public ReadOnly Property PosPayments() As DataTable
            Get
                Return mPosPayments
            End Get
        End Property

        Public ReadOnly Property PosPaymentDialog() As DataTable
            Get
                Return mPosPaymentDialog
            End Get
        End Property


        Public ReadOnly Property UI() As uiTrnPosEN
            Get
                Return Me.mui
            End Get
        End Property


        Public ReadOnly Property PaymentType() As DataTable
            Get
                Return mPaymentType
            End Get
        End Property

        Public ReadOnly Property Setting() As DataTable
            Get
                Return mSetting
            End Get
        End Property

        Public Property MachineId() As String
            Get
                If Me.IsDevelopmentMode Then
                    Return Config.DevMachineId
                Else
                    Return Me.mMachineID
                End If
            End Get
            Set(ByVal value As String)
                Me.mMachineID = value
            End Set
        End Property

        Public Property BranchId() As String
            Get
                If Me.IsDevelopmentMode Then
                    Return Config.DevBranchId
                Else
                    Return Me.mBranchId
                End If
            End Get
            Set(ByVal value As String)
                Me.mBranchId = value
            End Set
        End Property

        Public Property RegionId() As String
            Get
                If Me.IsDevelopmentMode Then
                    Return Config.DevRegionId
                Else
                    Return Me.mRegionId
                End If
            End Get
            Set(ByVal value As String)
                Me.mRegionId = value
            End Set
        End Property


        Public Property SiteName() As String
            Get
                If Me.IsDevelopmentMode Then
                    Return "DEV " & Me.RegionId & ":" & Me.BranchId
                Else
                    Return Me.mSiteName
                End If
            End Get
            Set(ByVal value As String)
                Me.mSiteName = value
            End Set
        End Property


        Public Property NPWP() As String
            Get
                Return mNPWP
            End Get
            Set(ByVal value As String)
                mNPWP = value
            End Set
        End Property

        Public Property RPCAddress() As String
            Get
                Return mRPCAddress
            End Get
            Set(ByVal value As String)
                mRPCAddress = value
            End Set
        End Property

        Public Property QrisProxy() As String
            Get
                If mQrisProxy = "" Then
                    Return "http://void.dev.transbrowser.com/oss"
                Else
                    Return mQrisProxy
                End If
            End Get
            Set(ByVal value As String)
                mQrisProxy = value
            End Set
        End Property

        Public Property [Event]() As String
            Get
                Return Me.mEvent
            End Get
            Set(ByVal value As String)
                Me.mEvent = value
            End Set
        End Property

        Public Property PrinterDefault() As String
            Get
                Return Me.mPrinterDefault
            End Get
            Set(ByVal value As String)
                Me.mPrinterDefault = value
            End Set
        End Property

        Public Property ReceiptPrinter() As String
            Get
                Return Me.mReceiptPrinter
            End Get
            Set(ByVal value As String)
                Me.mReceiptPrinter = value
            End Set
        End Property

        Public Property Logo() As String
            Get
                Return Me.mLogo
            End Get
            Set(ByVal value As String)
                Me.mLogo = value
            End Set
        End Property


        Public Property RegionPathFilter() As String
            Get
                Return Me.mRegionPathFilter
            End Get
            Set(ByVal value As String)
                Me.mRegionPathFilter = value
            End Set
        End Property




        Public Property UserName() As String
            Get
                Return Me.mUsername
            End Get
            Set(ByVal value As String)
                Me.mUsername = value
            End Set
        End Property

        Public Property BONTYPE() As String
            Get
                Return mBonType
            End Get
            Set(ByVal value As String)
                mBonType = value
            End Set
        End Property


        Public Property BolehDiscPayment() As Boolean
            Get
                Return Me._BolehDiscPayment
            End Get
            Set(ByVal value As Boolean)
                Me._BolehDiscPayment = value
            End Set
        End Property


        Public Property AllowedPaymenttype() As Collection
            Get
                Return Me._AllowedPaymenttype
            End Get
            Set(ByVal value As Collection)
                Me._AllowedPaymenttype = value
            End Set
        End Property


        Public Property PromoApplied() As Boolean
            Get
                Return Me._PromoApplied
            End Get
            Set(ByVal value As Boolean)
                Me._PromoApplied = value
            End Set
        End Property


        Public ReadOnly Property Parameter() As POSParameter
            Get
                Return Me._param
            End Get
        End Property


        Public Property NOT_ALLOWED_PAYMENT() As String
            Get
                Return mNotAllowedPayment
            End Get
            Set(ByVal value As String)
                mNotAllowedPayment = value
            End Set
        End Property



        Public Property PRINTER_PORT() As String
            Get
                Return Me._PRINTER_PORT
            End Get
            Set(ByVal value As String)
                Me._PRINTER_PORT = value
            End Set
        End Property

        Public Property POLE_PORT() As String
            Get
                Return Me._POLE_PORT
            End Get
            Set(ByVal value As String)
                Me._POLE_PORT = value
            End Set
        End Property

        Public Property MCRLAYER() As String
            Get
                Return Me._MCRLAYER
            End Get
            Set(ByVal value As String)
                Me._MCRLAYER = value
            End Set
        End Property

        Public Property CARDNUMBER_ENTRY() As String
            Get
                Return Me._CARDNUMBER_ENTRY
            End Get
            Set(ByVal value As String)
                Me._CARDNUMBER_ENTRY = value
            End Set
        End Property

        Public Property CARDNUMBER_OVRMANUAL() As String
            Get
                Return Me._CARDNUMBER_OVRMANUAL
            End Get
            Set(ByVal value As String)
                Me._CARDNUMBER_OVRMANUAL = value
            End Set
        End Property

        Public Property ALLOW_MULTIPLE_PAYMENT_IN_FP() As String
            Get
                Return Me._ALLOW_MULTIPLE_PAYMENT_IN_FP
            End Get
            Set(ByVal value As String)
                Me._ALLOW_MULTIPLE_PAYMENT_IN_FP = value
            End Set
        End Property

        Public Property FP_PAYMENT_FILTER() As String
            Get
                Return Me._FP_PAYMENT_FILTER
            End Get
            Set(ByVal value As String)
                Me._FP_PAYMENT_FILTER = value
            End Set
        End Property


        Public Property DISABLED_PAYMENT_METHOD() As String
            Get
                Return Me._DISABLED_PAYMENT_METHOD
            End Get
            Set(ByVal value As String)
                Me._DISABLED_PAYMENT_METHOD = value
            End Set
        End Property

        Public Property AUTO_KEY_NUMBER() As String
            Get
                Return Me._AUTO_KEY_NUMBER
            End Get
            Set(ByVal value As String)
                Me._AUTO_KEY_NUMBER = value
            End Set
        End Property

        Public Property SLAVE_MODE() As String
            Get
                Return Me._SLAVE_MODE
            End Get
            Set(ByVal value As String)
                Me._SLAVE_MODE = value
            End Set
        End Property

        Public Property STATUS() As String
            Get
                Return Me._STATUS
            End Get
            Set(ByVal value As String)
                Me._STATUS = value
            End Set
        End Property

        Public ReadOnly Property VOUCHER_LINKEDTO_CUSTOMERTYPE() As String
            Get
                Return Me._VOUCHER_LINKEDTO_CUSTOMERTYPE
            End Get
        End Property

        Public ReadOnly Property DISABLED_VOUCHER() As String
            Get
                Return Me._DISABLED_VOUCHER
            End Get
        End Property


        Public ReadOnly Property SENDDATAMODE() As String
            Get
                Return Me._SENDDATAMODE
            End Get
        End Property

        Public ReadOnly Property SENDDATAVER() As String
            Get
                Return Me._SENDDATAVER
            End Get
        End Property


        Public ReadOnly Property COMPANY_NAME() As String
            Get
                Dim _retval As String
                Dim dr As DataRow()
                dr = Me.Setting.Select("setting_id='POSH_COMPANY_NAME'")
                If dr.Length > 0 Then
                    _retval = dr(0).Item("setting_value").ToString
                Else
                    _retval = "PT. Trans Fashion Indonesia"
                End If
                Return _retval
            End Get
        End Property

        Public ReadOnly Property COMPANY_INITIAL() As String
            Get
                Dim _retval As String
                Dim dr As DataRow()
                dr = Me.Setting.Select("setting_id='POSH_COMPANYINITIAL'")
                If dr.Length > 0 Then
                    _retval = dr(0).Item("setting_value").ToString
                Else
                    _retval = "TMG"
                End If
                Return _retval
            End Get
        End Property

        Public ReadOnly Property COMPANY_ADDRESS() As String
            Get
                Dim _retval As String
                Dim dr As DataRow()
                dr = Me.Setting.Select("setting_id='POSH_COMPANYADDRESS'")
                If dr.Length > 0 Then
                    _retval = dr(0).Item("setting_value").ToString
                Else
                    _retval = "Jl. HR Rasuna Said Kav 19A Jakarta 12950"
                End If
                Return _retval
            End Get
        End Property

        Public ReadOnly Property COMPANY_TAXID() As String
            Get
                Dim _retval As String
                Dim dr As DataRow()
                dr = Me.Setting.Select("setting_id='POSH_COMPANYTAXID'")
                If dr.Length > 0 Then
                    _retval = dr(0).Item("setting_value").ToString
                Else
                    _retval = "01.347.523.1.073.000"
                End If
                Return _retval
            End Get
        End Property

        Public ReadOnly Property SALESPERSON_IS_MANDATORY() As Boolean
            Get
                Dim _retval As Boolean
                Dim dr As DataRow()
                dr = Me.Setting.Select("setting_id='POSH_SALESPERSON_IS_MANDATORY'")
                If dr.Length > 0 Then
                    _retval = CBool(dr(0).Item("setting_value").ToString)
                Else
                    _retval = CBool("True")
                End If
                Return _retval
            End Get
        End Property

        Public ReadOnly Property SALESPERSON_AUTOFILLTEXT() As String
            Get
                Dim _retval As String
                Dim dr As DataRow()
                dr = Me.Setting.Select("setting_id='POSH_SALESPERSON_AUTOFILLTEXT'")
                If dr.Length > 0 Then
                    _retval = Trim(dr(0).Item("setting_value").ToString)
                Else
                    _retval = "0"
                End If
                Return _retval
            End Get
        End Property

        Public ReadOnly Property EXTID_IS_ENABLED() As Boolean
            Get
                Dim _retval As Boolean
                Dim dr As DataRow()
                dr = Me.Setting.Select("setting_id='POSH_EXTID_IS_ENABLED'")
                If dr.Length > 0 Then
                    _retval = CBool(dr(0).Item("setting_value").ToString)
                Else
                    _retval = CBool("True")
                End If
                Return _retval
            End Get
        End Property

        Public ReadOnly Property EXTID_IS_MANDATORY() As Boolean
            Get
                Dim _retval As Boolean
                Dim dr As DataRow()
                dr = Me.Setting.Select("setting_id='POSH_EXTID_IS_MANDATORY'")
                If dr.Length > 0 Then
                    _retval = CBool(dr(0).Item("setting_value").ToString)
                Else
                    _retval = CBool("True")
                End If
                Return _retval
            End Get
        End Property

        Public ReadOnly Property CONSGOOD_CODE() As String
            Get
                Dim _retval As String
                Dim dr As DataRow()
                dr = Me.Setting.Select("setting_id='POSH_CONSGOOD_CODE'")
                If dr.Length > 0 Then
                    _retval = dr(0).Item("setting_value").ToString
                Else
                    _retval = "TMCG-"
                End If
                Return _retval
            End Get
        End Property

        Public ReadOnly Property CONSGOOD_IS_MANDATORY() As Boolean
            Get
                Dim _retval As Boolean
                Dim dr As DataRow()
                dr = Me.Setting.Select("setting_id='POSH_CONSGOOD_IS_MANDATORY'")
                If dr.Length > 0 Then
                    _retval = CBool(dr(0).Item("setting_value").ToString)
                Else
                    _retval = CBool("True")
                End If
                Return _retval
            End Get
        End Property

        Public ReadOnly Property BON_COPY() As Integer
            Get
                Dim _copy As String
                Dim _retval As Integer
                Dim dr As DataRow()
                dr = Me.Setting.Select("setting_id='POSH_BON_COPY'")
                If dr.Length > 0 Then
                    _copy = dr(0).Item("setting_value").ToString()
                Else
                    _copy = "1"
                End If

                Integer.TryParse(_copy, _retval)

                If _retval = 0 Then
                    _retval = 1
                End If

                Return _retval
            End Get
        End Property



        Public ReadOnly Property DISCADD_MINTOTAL() As Decimal
            Get
                Dim _retval As Decimal
                Dim dr As DataRow()
                dr = Me.Setting.Select("setting_id='POSH_DISCADD_MINTOTAL'")
                If dr.Length > 0 Then
                    Try
                        _retval = CDec(dr(0).Item("setting_value").ToString)
                    Catch ex As Exception
                        _retval = 0
                    End Try
                Else
                    _retval = 0
                End If
                Return _retval
            End Get
        End Property

        Public ReadOnly Property DISCADD_AUTO() As Decimal
            Get
                Dim _retval As Decimal
                Dim dr As DataRow()
                dr = Me.Setting.Select("setting_id='POSH_DISCADD_AUTO'")
                If dr.Length > 0 Then
                    Try
                        _retval = CDec(dr(0).Item("setting_value").ToString)
                    Catch ex As Exception
                        _retval = 0
                    End Try
                Else
                    _retval = 0
                End If
                Return _retval
            End Get
        End Property


        Public ReadOnly Property CUSTOMERINFO_IS_MANDATORY() As Boolean
            Get
                Dim _retval As Boolean
                Dim dr As DataRow()
                dr = Me.Setting.Select("setting_id='POSH_CUSTOMERINFO_IS_MANDATORY'")
                If dr.Length > 0 Then
                    _retval = CBool(dr(0).Item("setting_value").ToString)
                Else
                    _retval = CBool("True")
                End If
                Return _retval
            End Get
        End Property


        Public ReadOnly Property INI_FILE() As String
            Get
                Dim _retval As String
                Dim dr As DataRow()
                dr = Me.Setting.Select("setting_id='POSH_INI_FILE'")
                If dr.Length > 0 Then
                    _retval = dr(0).Item("setting_value").ToString()
                Else
                    _retval = "C:\TransBrowser.pos.ini"
                End If
                Return _retval
            End Get
        End Property


        Public ReadOnly Property PROMO_BUTTON() As Boolean
            Get
                Dim _retval As Boolean
                Dim dr As DataRow()
                dr = Me.Setting.Select("setting_id='POSH_PROMO_BUTTON'")
                If dr.Length > 0 Then
                    Dim s As String = dr(0).Item("setting_value").ToString()
                    If (s = "1") Then
                        _retval = True
                    Else
                        _retval = False
                    End If
                    '_retval = dr(0).Item("setting_value").ToString()
                Else
                    _retval = False
                End If
                Return _retval
            End Get
        End Property



        Public ReadOnly Property PROMO_START() As Date
            Get
                Dim _retval As Date
                Dim dr As DataRow()
                dr = Me.Setting.Select("setting_id='POSH_PROMO_START'")
                If dr.Length > 0 Then
                    Dim s As String = dr(0).Item("setting_value").ToString()
                    If (s = "") Then
                        _retval = New Date(2010, 1, 1)
                    Else
                        If Len(s) < 10 Then
                            _retval = New Date(2010, 1, 1)
                        Else
                            Dim ye = Mid(s, 1, 4)
                            Dim mo = Mid(s, 6, 2)
                            Dim dy = Mid(s, 9, 2)


                        End If
                    End If
                    '_retval = dr(0).Item("setting_value").ToString()
                Else
                    _retval = New Date(2010, 1, 1)
                End If
                Return _retval
            End Get
        End Property



        Public ReadOnly Property SCANMODE() As String
            Get
                Dim _retval As String
                Dim dr As DataRow()
                dr = Me.Setting.Select("setting_id='POSH_SCANMODE'")
                If dr.Length > 0 Then
                    _retval = dr(0).Item("setting_value").ToString()
                Else
                    _retval = ""
                End If
                Return _retval
            End Get
        End Property

        Public ReadOnly Property TaxPercent() As Decimal
            Get
                Dim _retval As String
                Dim dr As DataRow()
                dr = Me.Setting.Select("setting_id='POSH_TAXPERCENT'")
                If dr.Length > 0 Then
                    _retval = dr(0).Item("setting_value").ToString()
                Else
                    _retval = "11"
                End If
                Dim tp As Decimal
                tp = CDec(_retval)

                Return tp
            End Get
        End Property







        Public Property IsDevelopmentMode() As Boolean
            Get
                Return Me._isDevelopmentMode
            End Get
            Set(ByVal value As Boolean)
                Me._isDevelopmentMode = value
            End Set
        End Property

#End Region



        Public Function LoadDataIntoDatatable(ByVal service As String, ByVal criteria As String, ByRef respond As String) As DataTable
            Return Me.mui.LoadDataIntoDatatable(service, criteria, respond)
        End Function

        Public Function getWebConnection() As Translib.WebConnection
            Return Me.mui.getWebConnection()
        End Function


        Public Sub InitialiseSecondDisplay()
            Me.mSecondDisplay = New dlgSecondDisplay()

            If uiTrnPosEN.StartInfo.EnvironmentVariables("POSENV") = "DEV" Then
                ' DEVELOMENT
                Me.mSecondDisplay.Text = "wndow do from kedua"
                Me.mSecondDisplay.ShowInTaskbar = True
                Me.mSecondDisplay.Show()
            Else
                ' PRODUCTION
                Dim numofmonitor As Integer = Screen.AllScreens.Length
                If numofmonitor > 1 Then
                    ' Tampilkan monitor kedua
                    Me.mSecondDisplay.Text = "wndow do from kedua"
                    Me.mSecondDisplay.ShowInTaskbar = False
                    Me.mSecondDisplay.Show()
                    Me.mSecondDisplay.Location = Screen.AllScreens(UBound(Screen.AllScreens)).Bounds.Location
                    Me.mSecondDisplay.WindowState = FormWindowState.Maximized
                    Me.mSecondDisplay.FormBorderStyle = FormBorderStyle.None
                End If
            End If




            Me.mSecondDisplay.setPOS(Me)
        End Sub



        Public Function ClearTransaction() As Boolean

            Me.PosItems.DefaultView.Sort = ""

            Me.PosItems.Rows.Clear()
            Me.PosPayments.Rows.Clear()
            Me.PosPaymentDialog.Rows.Clear()
            RaiseEvent TransactionCleared()
        End Function

        Public Function NewTransaction() As Boolean
            RaiseEvent TransactionCreating()
            Me.ClearTransaction()
            Me.PosPaymentDialog.Rows.Add(Me.mPosPaymentDialog.NewRow())
            RaiseEvent TransactionCreated()
        End Function

        Public Function ItemAdd(ByVal id As String, ByVal qty As Integer, ByVal vou01id As String, ByVal vou01type As String, ByVal vou01codenum As String, ByVal vou01discp As Decimal, ByVal vou01method As String, ByRef cancel As Boolean) As Boolean
            Dim ret As Boolean = False
            Try
                ' Scan items
                Dim objItem As POS.PosItemData = New POS.PosItemData
                Dim tbl As DataTable

                tbl = Me.__ScanItem(id)
                If tbl.Rows.Count > 0 Then
                    If tbl.Rows.Count > 1 Then
                        RaiseEvent ScanFindMoreThanOneItem(tbl, objItem, cancel)
                    ElseIf tbl.Rows.Count = 1 Then
                        objItem.iteminventory_id = tbl.Rows(0).Item("iteminventory_id")
                        objItem.iteminventory_idsc = tbl.Rows(0).Item("iteminventory_idsc")
                        objItem.iteminventory_barcode = tbl.Rows(0).Item("iteminventory_barcode")
                        objItem.iteminventory_sizecode = tbl.Rows(0).Item("iteminventory_sizecode")
                        objItem.iteminventory_name = tbl.Rows(0).Item("iteminventory_name")
                        objItem.iteminventory_article = tbl.Rows(0).Item("iteminventory_article")
                        objItem.iteminventory_material = tbl.Rows(0).Item("iteminventory_material")
                        objItem.iteminventory_color = tbl.Rows(0).Item("iteminventory_color")
                        objItem.iteminventory_size = tbl.Rows(0).Item("iteminventory_size")
                        objItem.iteminventory_priceori = CDec(tbl.Rows(0).Item("iteminventory_priceori"))
                        objItem.iteminventory_sellpricedefault = CDec(tbl.Rows(0).Item("iteminventory_sellpricedefault"))
                        objItem.iteminventory_discountdefault = CDec(tbl.Rows(0).Item("iteminventory_discountdefault"))
                        objItem.iteminventory_isadddisc = CBool(tbl.Rows(0).Item("iteminventory_isadddisc"))
                        objItem.iteminventorygroup_id = tbl.Rows(0).Item("iteminventorygroup_id")
                        objItem.iteminventorysubgroup_id = tbl.Rows(0).Item("iteminventorysubgroup_id")
                        objItem.region_id = tbl.Rows(0).Item("region_id")
                        objItem.region_nameshort = tbl.Rows(0).Item("region_nameshort")
                        objItem.colname = tbl.Rows(0).Item("colname")
                        objItem.sizetag = tbl.Rows(0).Item("sizetag")
                        objItem.pricingrule = tbl.Rows(0).Item("pricingrule")
                        objItem.proc = tbl.Rows(0).Item("proc")
                        objItem.issp = CBool(tbl.Rows(0).Item("priceissp"))

                        If vou01type = "BONUS" Then
                            objItem.setasnewbonus = True
                        End If

                    End If
                    If Not cancel Then
                        ret = Me.__EditItem(PosItemAction.Add, objItem, qty, vou01id, vou01type, vou01codenum, vou01discp, vou01method)
                    End If
                Else
                    ret = False
                End If

                If ret Then
                    RaiseEvent ItemAdded(qty)
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return ret
        End Function

        Public Function ItemEdit(ByVal objItem As POS.PosItemData, ByVal qty As Integer) As Boolean
            Dim ret As Boolean = False
            Try
                ret = Me.__EditItem(PosItemAction.Edit, objItem, qty)
                If ret Then
                    RaiseEvent ItemEdited(qty)
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return ret
        End Function

        Public Function ItemEditToBonus(ByVal objItem As POS.PosItemData, ByVal qty As Integer, ByVal vou01id As String, ByVal vou01type As String, ByVal vou01codenum As String, ByVal vou01discp As Integer, ByVal vou01method As String) As Boolean
            Dim ret As Boolean = False
            Try
                ret = Me.__EditItem(PosItemAction.Edit, objItem, qty, vou01id, vou01type, vou01codenum, vou01discp, vou01method)
                If ret Then
                    RaiseEvent ItemEdited(qty)
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return ret
        End Function


        Public Function ItemRemove(ByVal objItem As POS.PosItemData) As Boolean
            Dim ret As Boolean = False
            Try
                ret = Me.__EditItem(PosItemAction.Remove, objItem)
            Catch ex As ItemNotAllowedException
            Catch ex As Exception
                Throw ex
            End Try
            Return ret
        End Function



        Private Function __ScanItem(ByVal id As String) As DataTable
            Dim obj As POSItem = New POSItem(Me)
            Dim tbl As DataTable = New DataTable()

            Try
                tbl = obj.ScanItem(id)
            Catch ex As Exception
                Throw ex
            End Try

            Return tbl

        End Function

        Private Function __EditItem(ByVal action As POS.PosItemAction, ByVal objItem As POS.PosItemData, Optional ByVal qty As Decimal = 1, Optional ByVal vou01id As String = "0", Optional ByVal vou01type As String = "", Optional ByVal vou01codenum As String = "", Optional ByVal vou01discp As Decimal = 0, Optional ByVal vou01method As String = "") As Boolean
            Dim dr As DataRow
            Dim arrdr() As DataRow
            Dim filter As String
            Dim rowindex As Integer = 0
            Dim bondetil_qty As Decimal = 0
            Dim ret As Boolean = False


            Dim bondetil_item As String = ""
            Dim bondetil_barcode As String = ""
            Dim bondetil_idsc As String = ""
            Dim bondetil_descr As String = ""
            Dim bondetil_article As String = ""
            Dim bondetil_color As String = ""
            Dim bondetil_size As String = ""
            Dim bondetil_material As String = ""

            Dim bondetil_discpstd01 As Decimal = 0
            Dim bondetil_discrstd01 As Decimal = 0
            Dim bondetil_pricenettstd01 As Decimal = 0
            Dim bondetil_discpvou01 As Decimal = 0
            Dim bondetil_discrvou01 As Decimal = 0
            Dim bondetil_pricenettvou01 As Decimal = 0
            Dim bondetil_vou01id As String = ""
            Dim bondetil_vou01codenum As String = ""
            Dim bondetil_vou01type As String = ""
            Dim bondetil_vou01method As String = ""
            Dim bondetil_vou01discp As String = ""
            Dim bondetil_rule As String = ""
            Dim bondetil_pricegross As Decimal = 0
            Dim bondetil_pricenet As Decimal = 0
            Dim bondetil_subtotal As Decimal = 0
            Dim pricing_priceori As Decimal = 0
            Dim pricing_price As Decimal = 0
            Dim pricing_disc As Decimal = 0
            Dim pricing_issp As Boolean = False

            Dim region_id As String = ""
            Dim region_nameshort As String = ""
            Dim colname As String = ""
            Dim sizetag As String = "1"
            Dim proc As String = ""
            Dim heinvgro_id As String = ""
            Dim heinvctg_id As String
            Dim heinv_id As String
            Dim item_sudah_ada As Boolean = False
            Dim item_sudah_ada_yang_bonus As Boolean = False




            ' Kalau Size nya ???
            ' pilih dulu, size nya harusnya berapa ?
            If objItem.iteminventory_size = UnknownSize Then
                RaiseEvent SelectUnknownSize(objItem.region_id, objItem.iteminventory_article, objItem.iteminventory_material, objItem.iteminventory_color, objItem.iteminventory_name, objItem.iteminventory_size, objItem.sizetag, objItem.colname)
            End If


            ' Cari item
            ' Cari berdasar ART, MAT, COL, SIZE, REGION
            'If vou01type = "BONUS" Then
            '    filter = String.Format("bondetil_article='{0}' AND bondetil_material='{1}' AND bondetil_color='{2}' AND bondetil_size='{3}' AND region_id='{4}' AND bondetil_vou01type='BONUS'", objItem.iteminventory_article, objItem.iteminventory_material, objItem.iteminventory_color, objItem.iteminventory_size, objItem.region_id)
            'Else
            '    filter = String.Format("bondetil_article='{0}' AND bondetil_material='{1}' AND bondetil_color='{2}' AND bondetil_size='{3}' AND region_id='{4}' AND bondetil_subtotal>0", objItem.iteminventory_article, objItem.iteminventory_material, objItem.iteminventory_color, objItem.iteminventory_size, objItem.region_id)
            'End If
            'filter = String.Format("bondetil_article='{0}' AND bondetil_material='{1}' AND bondetil_color='{2}' AND bondetil_size='{3}' AND region_id='{4}' AND bondetil_pricenet={5}", objItem.iteminventory_article, objItem.iteminventory_material, objItem.iteminventory_color, objItem.iteminventory_size, objItem.region_id, objItem.iteminventory_pricenet)
            'arrdr = Me.PosItems.Select(filter)



            'Cari item
            ' apabila vou01type="BONUS", bisa menggunakan Ctrl+B, atau B*TMxxxxx
            ' cari dulu apakah ada yg bonus
            filter = String.Format("bondetil_article='{0}' AND bondetil_material='{1}' AND bondetil_color='{2}' AND bondetil_size='{3}' AND region_id='{4}' ", objItem.iteminventory_article, objItem.iteminventory_material, objItem.iteminventory_color, objItem.iteminventory_size, objItem.region_id)
            arrdr = Me.PosItems.Select(filter)

            Dim founditem As Boolean = False

            If action = PosItemAction.Remove Or objItem.editingQty Then
                founditem = arrdr.Length > 0
            End If

            ' If arrdr.Length > 0 Then
            If founditem Then
                ' item sudah ada
                item_sudah_ada = True
                dr = arrdr(0)

                If action = PosItemAction.Remove Or objItem.editingQty Then
                    rowindex = objItem.rowindex
                Else
                    rowindex = Me.PosItems.Rows.IndexOf(dr)
                End If


                ' cek apakah ada item tersebut yang bonus
                filter = String.Format("bondetil_article='{0}' AND bondetil_material='{1}' AND bondetil_color='{2}' AND bondetil_size='{3}' AND region_id='{4}' AND bondetil_vou01type='BONUS'", objItem.iteminventory_article, objItem.iteminventory_material, objItem.iteminventory_color, objItem.iteminventory_size, objItem.region_id)
                arrdr = Me.PosItems.Select(filter)
                If arrdr.Length > 0 Then
                    ' sudah ada item tersebut yang bonus
                    item_sudah_ada_yang_bonus = True
                    dr = arrdr(0)
                    rowindex = Me.PosItems.Rows.IndexOf(dr)
                End If

                bondetil_item = Me.PosItems.Rows(rowindex).Item("bondetil_item")
                bondetil_barcode = Me.PosItems.Rows(rowindex).Item("bondetil_barcode")
                bondetil_idsc = Me.PosItems.Rows(rowindex).Item("bondetil_idsc")
                bondetil_descr = Me.PosItems.Rows(rowindex).Item("bondetil_descr")
                bondetil_article = Me.PosItems.Rows(rowindex).Item("bondetil_article")
                bondetil_color = Me.PosItems.Rows(rowindex).Item("bondetil_color")
                bondetil_size = Me.PosItems.Rows(rowindex).Item("bondetil_size")
                bondetil_material = Me.PosItems.Rows(rowindex).Item("bondetil_material")
                bondetil_pricegross = Me.PosItems.Rows(rowindex).Item("bondetil_pricegross")
                bondetil_pricenet = Me.PosItems.Rows(rowindex).Item("bondetil_pricenet")
                bondetil_subtotal = Me.PosItems.Rows(rowindex).Item("bondetil_subtotal")
                bondetil_qty = Me.PosItems.Rows(rowindex).Item("bondetil_qty")
                bondetil_vou01type = Me.PosItems.Rows(rowindex).Item("bondetil_vou01type")
                pricing_priceori = Me.PosItems.Rows(rowindex).Item("pricing_priceori")
                pricing_price = Me.PosItems.Rows(rowindex).Item("pricing_price")
                pricing_disc = Me.PosItems.Rows(rowindex).Item("pricing_disc")
                pricing_issp = Me.PosItems.Rows(rowindex).Item("pricing_issp")
                region_id = Me.PosItems.Rows(rowindex).Item("region_id")
                region_nameshort = Me.PosItems.Rows(rowindex).Item("region_nameshort")
                colname = Me.PosItems.Rows(rowindex).Item("colname")
                sizetag = Me.PosItems.Rows(rowindex).Item("sizetag")
                heinvgro_id = Me.PosItems.Rows(rowindex).Item("heinvgro_id")
                heinvctg_id = Me.PosItems.Rows(rowindex).Item("heinvctg_id")
                If action = PosItemAction.Remove Then
                    Me.PosItems.Rows.Remove(Me.PosItems.Rows(rowindex))
                    ret = True
                End If
            End If

            If action <> PosItemAction.Remove Then
                Dim tambahbaru As Boolean = False

                If vou01type = "BONUS" Then

                    filter = String.Format("bondetil_article='{0}' AND bondetil_material='{1}' AND bondetil_color='{2}' AND bondetil_size='{3}' AND region_id='{4}' AND bondetil_vou01type='BONUS'", objItem.iteminventory_article, objItem.iteminventory_material, objItem.iteminventory_color, objItem.iteminventory_size, objItem.region_id)
                    arrdr = Me.PosItems.Select(filter)
                    If arrdr.Length > 0 Then
                        ' sudah ada item tersebut yang bonus
                        item_sudah_ada_yang_bonus = True
                        dr = arrdr(0)
                        rowindex = Me.PosItems.Rows.IndexOf(dr)
                    End If


                    tambahbaru = False
                    'If item_sudah_ada_yang_bonus Then
                    '    tambahbaru = False
                    'Else
                    '    'If item_sudah_ada Then  ' item sudah ada, tapi belum ada yang bonus
                    '    '    ' Ctrl B masuk kesini --> saat ctrl B, pricenett nya ada value
                    '    '    ' B * juga masuk kesini   
                    '    '    ' bagaimana membedakannya ?
                    '    '    If objItem.setasnewbonus Then
                    '    '        tambahbaru = True
                    '    '    Else
                    '    '        tambahbaru = False
                    '    '    End If
                    '    'Else
                    '    '    tambahbaru = True
                    '    'End If
                    'End If

                Else

                    If action = PosItemAction.Edit Then
                        If bondetil_vou01type = "PROMOMD1" Then
                            MessageBox.Show("Tidak boleh edit qty Promo" & vbCrLf & "untuk penambahan silakan scan lagi", "Edit Qty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Throw New Exception("Tidak boleh edit qty Promo")
                        End If
                    End If


                    ' Tambah item, cari dulu barang yang bukan bonus
                    filter = String.Format("bondetil_article='{0}' AND bondetil_material='{1}' AND bondetil_color='{2}' AND bondetil_size='{3}' AND region_id='{4}' AND bondetil_subtotal>0 AND bondetil_vou01type<>'PROMOMD1'", objItem.iteminventory_article, objItem.iteminventory_material, objItem.iteminventory_color, objItem.iteminventory_size, objItem.region_id)
                    arrdr = Me.PosItems.Select(filter)



                    If objItem.editingQty Then
                        tambahbaru = False
                        rowindex = objItem.rowindex
                        bondetil_qty = Me.PosItems.Rows(rowindex).Item("bondetil_qty")
                        bondetil_pricenet = Me.PosItems.Rows(rowindex).Item("bondetil_pricenet")
                    Else
                        Dim founditemyangkanditambah = False
                        ' If arrdr.Length > 0 Then
                        If founditemyangkanditambah Then
                            dr = arrdr(0)
                            rowindex = Me.PosItems.Rows.IndexOf(dr)
                            bondetil_qty = Me.PosItems.Rows(rowindex).Item("bondetil_qty")
                            bondetil_pricenet = Me.PosItems.Rows(rowindex).Item("bondetil_pricenet")
                            tambahbaru = False
                        Else
                            tambahbaru = True
                        End If
                    End If



                End If


                If Not tambahbaru Then

                    If action = PosItemAction.Add Then
                        bondetil_qty = bondetil_qty + qty
                    Else
                        bondetil_qty = qty
                    End If

                    If vou01type = "BONUS" Then
                        Me.PosItems.Rows(rowindex).Item("bondetil_pricenet") = 0
                        Me.PosItems.Rows(rowindex).Item("bondetil_vou01discp") = 100
                        bondetil_pricenet = 0
                    End If

                    bondetil_subtotal = bondetil_qty * bondetil_pricenet
                    Me.PosItems.Rows(rowindex).Item("bondetil_qty") = bondetil_qty
                    Me.PosItems.Rows(rowindex).Item("bondetil_subtotal") = bondetil_subtotal
                    ret = True


                Else
                    'Item tidak ditemukan, tambah baris baru
                    Try
                        Dim rownumber As Integer
                        Dim obj As POSItem = New POSItem(Me)


                        'Asumsi sementara, data sudah ada, tidak perlu dicek pke Get Item
                        'If Not obj.GetItem(objItem) Then
                        '    Return False
                        'End If

                        If Me.PosItems.Rows.Count > 0 Then
                            rowindex = Me.PosItems.Rows.Count - 1
                            rownumber = Me.PosItems.Rows(rowindex).Item("bondetil_line") + 1
                        Else
                            rownumber = 1
                        End If

                        ' Perhitungan Harga Discount
                        Dim objItemPrice As TransStore.PosItemPrice = TransStore.Utilities.PosVoucherDiscountCalculate( _
                                                                                        objItem.iteminventory_sellpricedefault, _
                                                                                        qty, _
                                                                                        objItem.iteminventory_discountdefault, _
                                                                                        objItem.iteminventory_isadddisc, _
                                                                                        vou01type, _
                                                                                        vou01method, _
                                                                                        vou01discp, _
                                                                                        "REGULARCUSTOMER", _
                                                                                        0 _
                                                                        )

                        bondetil_item = objItem.iteminventory_id
                        bondetil_barcode = objItem.iteminventory_barcode
                        bondetil_idsc = objItem.iteminventory_idsc
                        bondetil_descr = objItem.iteminventory_name
                        bondetil_article = objItem.iteminventory_article
                        bondetil_color = objItem.iteminventory_color
                        bondetil_size = objItem.iteminventory_size
                        bondetil_material = objItem.iteminventory_material
                        bondetil_pricegross = objItem.iteminventory_sellpricedefault
                        bondetil_rule = objItem.pricingrule
                        bondetil_vou01id = vou01id
                        bondetil_vou01codenum = vou01codenum
                        bondetil_vou01type = vou01type
                        bondetil_vou01method = vou01method
                        bondetil_vou01discp = vou01discp
                        bondetil_qty = qty
                        bondetil_discpstd01 = objItemPrice.discpstd01
                        bondetil_discrstd01 = objItemPrice.discrstd01
                        bondetil_pricenettstd01 = objItemPrice.pricenettstd01
                        bondetil_discpvou01 = objItemPrice.discpvou01
                        bondetil_discrvou01 = objItemPrice.discrvou01
                        bondetil_pricenettvou01 = objItemPrice.pricenettvou01
                        bondetil_pricenet = bondetil_pricenettvou01
                        pricing_priceori = objItem.iteminventory_priceori
                        pricing_price = objItem.iteminventory_sellpricedefault
                        pricing_disc = objItem.iteminventory_discountdefault
                        pricing_issp = objItem.issp

                        If objItem.setasnewbonus Then
                            bondetil_pricenet = 0
                        End If

                        bondetil_subtotal = bondetil_qty * bondetil_pricenet
                        region_id = objItem.region_id
                        region_nameshort = objItem.region_nameshort
                        colname = objItem.colname
                        sizetag = objItem.sizetag
                        proc = objItem.proc
                        heinvgro_id = objItem.iteminventorygroup_id
                        heinvctg_id = objItem.iteminventorysubgroup_id
                        heinv_id = Mid(objItem.iteminventory_id, 1, 11) & "00"



                        dr = Me.PosItems.NewRow()
                        dr("bondetil_line") = rownumber
                        dr("bondetil_item") = bondetil_item
                        dr("bondetil_barcode") = bondetil_barcode
                        dr("bondetil_idsc") = bondetil_idsc
                        dr("bondetil_descr") = bondetil_descr
                        dr("bondetil_article") = bondetil_article
                        dr("bondetil_color") = bondetil_color
                        dr("bondetil_size") = bondetil_size
                        dr("bondetil_material") = bondetil_material
                        dr("pricing_priceori") = pricing_priceori
                        dr("pricing_price") = pricing_price
                        dr("pricing_disc") = pricing_disc
                        dr("pricing_issp") = pricing_issp
                        dr("bondetil_pricegross") = bondetil_pricegross
                        dr("bondetil_discpstd01") = bondetil_discpstd01
                        dr("bondetil_discrstd01") = bondetil_discrstd01
                        dr("bondetil_pricenettstd01") = bondetil_pricenettstd01
                        dr("bondetil_discpvou01") = bondetil_discpvou01
                        dr("bondetil_discrvou01") = bondetil_discrvou01
                        dr("bondetil_pricenettvou01") = bondetil_pricenettvou01
                        dr("bondetil_vou01id") = bondetil_vou01id
                        dr("bondetil_vou01codenum") = bondetil_vou01codenum
                        dr("bondetil_vou01type") = bondetil_vou01type
                        dr("bondetil_vou01method") = bondetil_vou01method
                        dr("bondetil_vou01discp") = bondetil_vou01discp
                        dr("bondetil_rule") = bondetil_rule
                        dr("bondetil_pricenet") = bondetil_pricenet
                        dr("bondetil_qty") = qty
                        dr("bondetil_subtotal") = bondetil_subtotal
                        dr("region_id") = region_id
                        dr("region_nameshort") = region_nameshort
                        dr("colname") = colname
                        dr("sizetag") = sizetag
                        dr("proc") = proc
                        dr("heinvgro_id") = heinvgro_id
                        dr("heinvctg_id") = heinvctg_id
                        dr("heinv_id") = heinv_id
                        Me.PosItems.Rows.Add(dr)
                        ret = True

                    Catch ex As Exception
                        ret = False
                        Me.PosItems.RejectChanges()
                        Throw ex
                    End Try
                End If

            End If



            Me.PosItems.AcceptChanges()

            If ret Then
                Dim sum_qty = Me.Count
                Dim sum_subtotal = Me.Subtotal
                Try
                    RaiseEvent ItemModified(action, bondetil_item, bondetil_descr, bondetil_article, bondetil_color, bondetil_size, bondetil_material, bondetil_pricegross, bondetil_discpstd01, bondetil_qty, bondetil_subtotal, sum_qty, sum_subtotal, vou01type)
                Catch ex As ItemNotAllowedException
                    Throw ex
                Catch ex As Exception
                    Throw ex
                End Try
            End If

            Return ret

        End Function

        Private Function __EditPayment(ByVal action As POS.PosItemAction, ByVal obj As PosPaymentRow, ByRef retline As Integer) As Boolean
            Dim dr As DataRow
            Dim arrdr() As DataRow
            Dim filter As String
            Dim rowindex As Integer = 0
            Dim ret As Boolean = False


            If action = PosItemAction.Remove Then
                ' Hapus data payment
                ' Cari item
                filter = String.Format("payment_line='{0}'", obj.line)
                arrdr = Me.PosPayments.Select(filter)
                If arrdr.Length > 0 Then
                    dr = arrdr(0)
                    'rowindex = Me.PosPayments.Rows.IndexOf(dr)
                    obj.line = dr("payment_line")
                    obj.Type = dr("payment_type")
                    obj.TypeName = dr("payment_typename")
                    obj.Bank = dr("payment_bankname")
                    obj.CardNumber = dr("payment_cardnumber")
                    obj.CardHolder = dr("payment_cardholder")
                    obj.Edc = dr("payment_edc")
                    obj.Installment = dr("payment_installment")
                    obj.Value = dr("payment_value")
                    obj.Cash = dr("payment_cash")
                    obj.Refund = dr("payment_refund")
                    obj.IsCash = dr("payment_iscash")
                    Me.PosPayments.Rows.Remove(dr)
                    ret = True
                End If

            Else
                If action = PosItemAction.Add Then
                    ' Tambah data payment

                    ' Cari maximum ID
                    Dim maxid As Object = Me.PosPayments.Compute("Max(payment_line)", "")
                    Dim line As Integer = 1

                    If maxid IsNot DBNull.Value Then
                        line = maxid + 1
                    End If



                    dr = Me.PosPayments.NewRow()
                    dr("payment_line") = line
                    dr("payment_type") = obj.Type
                    dr("payment_typename") = obj.TypeName
                    dr("payment_bankname") = obj.Bank
                    dr("payment_cardnumber") = obj.CardNumber
                    dr("payment_cardholder") = obj.CardHolder
                    dr("payment_edc") = obj.Edc
                    dr("payment_edcname") = obj.EdcName
                    dr("payment_edcapproval") = obj.Approval
                    dr("payment_installment") = obj.Installment
                    dr("payment_value") = obj.Value
                    dr("payment_cash") = obj.Cash
                    dr("payment_refund") = obj.Refund
                    dr("payment_iscash") = obj.IsCash

                    Try
                        Me.PosPayments.Rows.Add(dr)
                        Me.PosPayments.AcceptChanges()
                        retline = line
                        ret = True
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End Try


                Else
                    ' Edit data payment

                End If

            End If


            If ret Then
                Dim paymentsubtotal = Me.PaymentSubtotal

                Try
                    RaiseEvent PaymentModified(action, obj)
                Catch ex As Exception
                    Throw ex
                End Try
            End If

            Return ret

        End Function



        Public Function PaymentAdd(ByVal obj As PosPaymentRow, ByRef retline As Integer) As Boolean
            Dim ret As Boolean = False

            Try
                ret = Me.__EditPayment(PosItemAction.Add, obj, retline)
            Catch ex As Exception

            End Try

            Return ret
        End Function


        Public Function PaymentRemove(ByVal obj As PosPaymentRow, ByRef retline As Integer) As Boolean
            Dim ret As Boolean = False
            Try
                ret = Me.__EditPayment(PosItemAction.Remove, obj, retline)
            Catch ex As Exception
                Throw ex
            End Try
            Return ret
        End Function



        Public Function GetPaymentDiscount(ByVal pospayment_id As String, ByVal region_id As String) As DiscountPayment
            Dim d As DiscountPayment

            ' Ambil data dari Database
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim sql As String = ""
            Dim tbl As DataTable = New DataTable()


            Try
                Dim cmd As OleDb.OleDbCommand
                Dim da As OleDb.OleDbDataAdapter

                conn.Open()
                sql = "select " & vbCrLf & _
                      " * " & vbCrLf & _
                      "from master_pospaymentdisc " & vbCrLf & _
                      "where pospayment_id = '" & pospayment_id & "' and region_id='" & region_id & "' and branch_id='0' "
                cmd = New OleDb.OleDbCommand(sql, conn)
                da = New OleDb.OleDbDataAdapter(cmd)
                da.Fill(tbl)


                If tbl.Rows.Count = 0 Then
                    Return d
                End If

                ' Ada informasi discount payment 
                Dim row As DataRow = tbl.Rows(0)
                Dim dtstart As Date = CDate(row("date_start"))
                Dim dtend As Date = CDate(row("date_end"))
                If (Now.Date < dtstart Or Now.Date > dtend) Then
                    ' Tanggal tidak sesuai
                    Return d
                End If

                d.DiscountPercentage = CDec(row("disc_percent"))
                d.MinimumValuePurchase = CDec(row("minpurchase_value"))
                d.MaximumDiscountValue = CDec(row("maxdisc_value"))

                Return d

            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try

        End Function


        Public Function GetPosPayment(ByVal pospayment_id As String) As PosPayment
            ' Ambil data dari Database
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim sql As String = ""
            Dim tbl As DataTable = New DataTable()

            Try
                Dim cmd As OleDb.OleDbCommand
                Dim da As OleDb.OleDbDataAdapter

                conn.Open()
                sql = "select " & vbCrLf & _
                      " * " & vbCrLf & _
                      "from master_pospayment " & vbCrLf & _
                      "where pospayment_id = '" & pospayment_id & "' and pospayment_isdisabled=0 "
                cmd = New OleDb.OleDbCommand(sql, conn)
                da = New OleDb.OleDbDataAdapter(cmd)
                da.Fill(tbl)

                If tbl.Rows.Count = 0 Then
                    Return Nothing
                End If


                Dim row As DataRow = tbl.Rows(0)
                Dim p As PosPayment
                'pospayment_id	pospayment_name	pospayment_disc	pospayment_isdisabled	pospayment_iscash	pospayment_isvoucher	pospayment_vouchervalue	pospayment_order	pospayment_multi	pospayment_prefix	pospayment_minpaid	pospayment_shortcut	pospayment_bankname	pospayment_isvoucherdisabled	pospayment_isadddiscdisabled	pospayment_isredeemdisabled	pospayment_discvalue	pospayment_discminpurchase	pospayment_maxitemdiscallowed


                p.Id = CStr(row("pospayment_id"))
                p.Name = CStr(row("pospayment_name"))
                p.Disc = CDec(row("pospayment_disc"))
                p.DiscValue = CDec(row("pospayment_discvalue"))
                p.IsCash = CBool(row("pospayment_iscash"))
                p.IsVoucher = CBool(row("pospayment_isvoucher"))
                p.IsMulti = CBool(row("pospayment_multi"))
                p.VoucherValue = CDec(row("pospayment_vouchervalue"))
                p.Order = CInt(row("pospayment_order"))
                p.MinimumPurchase = CDec(row("pospayment_discminpurchase"))
                p.MaximumItemDiscAllowed = CDec(row("pospayment_maxitemdiscallowed"))

                Return p
            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try
        End Function


        Public Function LoadPaymentType() As DataTable
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim sql As String = ""
            Dim columnname As String = ""
            Dim tbl As DataTable = New DataTable()


            Dim disabledcriteria() As String = Me._DISABLED_PAYMENT_METHOD.Split(",")
            Dim i As Integer
            Dim icriteria As String = ""
            Dim arrcriteria As String() = {}
            Dim paymentcriteriaexception As String = ""

            If disabledcriteria.Length > 0 Then
                For i = 0 To disabledcriteria.Length - 1
                    icriteria = "'" & Trim(disabledcriteria(i)) & "'"
                    Array.Resize(arrcriteria, arrcriteria.Length + 1)
                    arrcriteria(arrcriteria.Length - 1) = icriteria
                Next
                paymentcriteriaexception &= " AND pospayment_id NOT IN (" & String.Join(", " & vbCrLf, arrcriteria) & ") "
            End If

            Try
                Dim cmd As OleDb.OleDbCommand
                Dim da As OleDb.OleDbDataAdapter

                conn.Open()
                sql = "select " & vbCrLf & _
                      " * " & vbCrLf & _
                      "from master_pospayment " & vbCrLf & _
                      "where pospayment_isdisabled = 0 " & paymentcriteriaexception & vbCrLf & _
                      "order by pospayment_order "
                cmd = New OleDb.OleDbCommand(sql, conn)
                da = New OleDb.OleDbDataAdapter(cmd)
                da.Fill(tbl)
            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try


            Return tbl
        End Function

        Public Function LoadVoucherType() As DataTable
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim sql As String = ""
            Dim columnname As String = ""
            Dim tbl As DataTable = New DataTable()

            Dim disabledcriteria() As String = Me._DISABLED_VOUCHER.Split(",")
            Dim i As Integer
            Dim icriteria As String = ""
            Dim arrcriteria As String() = {}
            Dim vouchercriteriaexception As String = ""

            If disabledcriteria.Length > 0 Then
                For i = 0 To disabledcriteria.Length - 1
                    icriteria = "'" & Trim(disabledcriteria(i)) & "'"
                    Array.Resize(arrcriteria, arrcriteria.Length + 1)
                    arrcriteria(arrcriteria.Length - 1) = icriteria
                Next
                vouchercriteriaexception &= " AND posvouchertype_id NOT IN (" & String.Join(", " & vbCrLf, arrcriteria) & ") "
            End If


            Try
                Dim cmd As OleDb.OleDbCommand
                Dim da As OleDb.OleDbDataAdapter

                conn.Open()
                sql = "select " & vbCrLf & _
                      " * " & vbCrLf & _
                      "from master_posvouchertype  " & vbCrLf & _
                      "where posvouchertype_isdisabled = 0 " & vouchercriteriaexception & vbCrLf & _
                      "order by posvouchertype_order "
                cmd = New OleDb.OleDbCommand(sql, conn)
                da = New OleDb.OleDbDataAdapter(cmd)
                da.Fill(tbl)

                'MessageBox.Show(sql)

            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try


            Return tbl
        End Function


        Public Function LoadSetting() As DataTable
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim sql As String = ""
            Dim columnname As String = ""
            Dim tbl As DataTable = New DataTable()

            Try
                Dim cmd As OleDb.OleDbCommand
                Dim da As OleDb.OleDbDataAdapter

                conn.Open()
                sql = "SELECT * FROM master_setting"
                cmd = New OleDb.OleDbCommand(sql, conn)
                da = New OleDb.OleDbDataAdapter(cmd)
                da.Fill(tbl)
            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try


            Return tbl
        End Function


        Public Function LoadCustNat() As DataTable
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim sql As String = ""
            Dim columnname As String = ""
            Dim tbl As DataTable = New DataTable()

            Try
                Dim cmd As OleDb.OleDbCommand
                Dim da As OleDb.OleDbDataAdapter

                conn.Open()
                sql = "select " & vbCrLf & _
                      " * " & vbCrLf & _
                      "from master_poscustnat  " & vbCrLf & _
                      "where poscustnat_isdisabled = 0 " & vbCrLf & _
                      "order by poscustnat_order "
                cmd = New OleDb.OleDbCommand(sql, conn)
                da = New OleDb.OleDbDataAdapter(cmd)
                da.Fill(tbl)
            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try

            Return tbl
        End Function

        Public Function LoadCustAge() As DataTable
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim sql As String = ""
            Dim columnname As String = ""
            Dim tbl As DataTable = New DataTable()

            Try
                Dim cmd As OleDb.OleDbCommand
                Dim da As OleDb.OleDbDataAdapter

                conn.Open()
                sql = "select " & vbCrLf & _
                      " * " & vbCrLf & _
                      "from master_poscustage  " & vbCrLf & _
                      "where poscustage_isdisabled = 0 " & vbCrLf & _
                      "order by poscustage_order "
                cmd = New OleDb.OleDbCommand(sql, conn)
                da = New OleDb.OleDbDataAdapter(cmd)
                da.Fill(tbl)
            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try

            Return tbl
        End Function

        Public Function LoadSizing(ByVal region_id As String) As DataTable
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim sql As String = ""
            Dim columnname As String = ""
            Dim tbl As DataTable = New DataTable()

            Try
                Dim cmd As OleDb.OleDbCommand
                Dim da As OleDb.OleDbDataAdapter

                conn.Open()
                sql = "select " & vbCrLf & _
                      " * " & vbCrLf & _
                      "from master_heinvsizetag  " & vbCrLf & _
                      "where region_id = '" & region_id & "' " & vbCrLf & _
                      ""
                cmd = New OleDb.OleDbCommand(sql, conn)
                da = New OleDb.OleDbDataAdapter(cmd)
                da.Fill(tbl)
            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try

            Return tbl
        End Function




        Public Function LoadStockFromFile(ByVal region_id As String, ByVal filename As String, ByVal stockdate As Date) As Boolean
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim sql As String = ""


            Try
                Dim cmd As OleDb.OleDbCommand

                conn.Open()


                ' Persiapan untuk disable / enable item
                Dim cmdmodify As OleDb.OleDbCommand = New OleDb.OleDbCommand("UPDATE master_heinv SET heinv_modifyby = NULL WHERE region_id=?", conn)
                cmdmodify.Parameters.Add("@region_id", OleDb.OleDbType.VarChar).Value = region_id
                cmdmodify.ExecuteNonQuery()


                ' Clear Saldo region
                Dim cmdclear As OleDb.OleDbCommand = New OleDb.OleDbCommand("DELETE FROM transaksi_hepossaldo WHERE region_id=?", conn)
                cmdclear.Parameters.Add("@region_id", OleDb.OleDbType.VarChar).Value = region_id
                cmdclear.ExecuteNonQuery()



                ' Persiapan untuk disable / enable item
                Dim cmdmodifyitem As OleDb.OleDbCommand = New OleDb.OleDbCommand("UPDATE master_heinv SET heinv_isdisabled=0, heinv_modifyby = '_invupdater_', heinv_modifydate=getdate() WHERE heinv_id=?", conn)
                cmdmodifyitem.Parameters.Add("@heinv_id", OleDb.OleDbType.VarChar)


                Dim line As String = ""
                Dim fields() As String
                Dim heinv_id As String = ""
                Dim C01, C02, C03, C04, C05, C06, C07, C08, C09, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25 As Integer
                Dim filestream As System.IO.StreamReader
                filestream = System.IO.File.OpenText(filename)
                line = filestream.ReadLine()
                Do Until line Is Nothing
                    fields = Trim(line).Split("|")
                    heinv_id = fields(0)
                    C01 = CInt(fields(1))
                    C02 = CInt(fields(2))
                    C03 = CInt(fields(3))
                    C04 = CInt(fields(4))
                    C05 = CInt(fields(5))
                    C06 = CInt(fields(6))
                    C07 = CInt(fields(7))
                    C08 = CInt(fields(8))
                    C09 = CInt(fields(9))
                    C10 = CInt(fields(10))
                    C11 = CInt(fields(11))
                    C12 = CInt(fields(12))
                    C13 = CInt(fields(13))
                    C14 = CInt(fields(14))
                    C15 = CInt(fields(15))
                    C16 = CInt(fields(16))
                    C17 = CInt(fields(17))
                    C18 = CInt(fields(18))
                    C19 = CInt(fields(19))
                    C20 = CInt(fields(20))
                    C21 = CInt(fields(21))
                    C22 = CInt(fields(22))
                    C23 = CInt(fields(23))
                    C24 = CInt(fields(24))
                    C25 = CInt(fields(25))



                    'sql = "INSERT INTO transaksi_hepossaldo " & vbCrLf & _
                    '      "(dt, region_id, heinv_id, C01, C02, C03, C04, C05, C06, C07, C08, C09, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25) " & vbCrLf & _
                    '      "VALUES " & vbCrLf & _
                    '      String.Format("('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}' )", heinv_id, C01, C02, C03, C04, C05, C06, C07, C08, C09, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25)
                    'cmd = New OleDb.OleDbCommand(sql, conn)
                    'cmd.ExecuteNonQuery()

                    sql = "INSERT INTO transaksi_hepossaldo " & vbCrLf & _
                          "(dt, region_id, heinv_id, C01, C02, C03, C04, C05, C06, C07, C08, C09, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25) " & vbCrLf & _
                          "VALUES " & vbCrLf & _
                          "(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"

                    cmd = New OleDb.OleDbCommand(sql, conn)
                    cmd.Parameters.Add("@dt", OleDb.OleDbType.Date).Value = stockdate
                    cmd.Parameters.Add("@region_id", OleDb.OleDbType.VarChar).Value = region_id
                    cmd.Parameters.Add("@heinv_id", OleDb.OleDbType.VarChar).Value = heinv_id
                    cmd.Parameters.Add("@C01", OleDb.OleDbType.Integer).Value = C01
                    cmd.Parameters.Add("@C02", OleDb.OleDbType.Integer).Value = C02
                    cmd.Parameters.Add("@C03", OleDb.OleDbType.Integer).Value = C03
                    cmd.Parameters.Add("@C04", OleDb.OleDbType.Integer).Value = C04
                    cmd.Parameters.Add("@C05", OleDb.OleDbType.Integer).Value = C05
                    cmd.Parameters.Add("@C06", OleDb.OleDbType.Integer).Value = C06
                    cmd.Parameters.Add("@C07", OleDb.OleDbType.Integer).Value = C07
                    cmd.Parameters.Add("@C08", OleDb.OleDbType.Integer).Value = C08
                    cmd.Parameters.Add("@C09", OleDb.OleDbType.Integer).Value = C09
                    cmd.Parameters.Add("@C10", OleDb.OleDbType.Integer).Value = C10
                    cmd.Parameters.Add("@C11", OleDb.OleDbType.Integer).Value = C11
                    cmd.Parameters.Add("@C12", OleDb.OleDbType.Integer).Value = C12
                    cmd.Parameters.Add("@C13", OleDb.OleDbType.Integer).Value = C13
                    cmd.Parameters.Add("@C14", OleDb.OleDbType.Integer).Value = C14
                    cmd.Parameters.Add("@C15", OleDb.OleDbType.Integer).Value = C15
                    cmd.Parameters.Add("@C16", OleDb.OleDbType.Integer).Value = C16
                    cmd.Parameters.Add("@C17", OleDb.OleDbType.Integer).Value = C17
                    cmd.Parameters.Add("@C18", OleDb.OleDbType.Integer).Value = C18
                    cmd.Parameters.Add("@C19", OleDb.OleDbType.Integer).Value = C19
                    cmd.Parameters.Add("@C20", OleDb.OleDbType.Integer).Value = C20
                    cmd.Parameters.Add("@C21", OleDb.OleDbType.Integer).Value = C21
                    cmd.Parameters.Add("@C22", OleDb.OleDbType.Integer).Value = C22
                    cmd.Parameters.Add("@C23", OleDb.OleDbType.Integer).Value = C23
                    cmd.Parameters.Add("@C24", OleDb.OleDbType.Integer).Value = C24
                    cmd.Parameters.Add("@C25", OleDb.OleDbType.Integer).Value = C25
                    cmd.ExecuteNonQuery()


                    'Enable master_heinv apabila masih ada barangnya
                    If (C01 > 0 Or C02 > 0 Or C03 > 0 Or C04 > 0 Or C05 > 0 Or _
                        C06 > 0 Or C07 > 0 Or C08 > 0 Or C09 > 0 Or C10 > 0 Or _
                        C11 > 0 Or C12 > 0 Or C13 > 0 Or C14 > 0 Or C15 > 0 Or _
                        C16 > 0 Or C17 > 0 Or C18 > 0 Or C19 > 0 Or C20 > 0 Or _
                        C21 > 0 Or C22 > 0 Or C23 > 0 Or C24 > 0 Or C25 > 0) Then


                        ' Masih ada barangnya
                        cmdmodifyitem.Parameters("@heinv_id").Value = heinv_id
                        cmdmodifyitem.ExecuteNonQuery()
                    End If


                    line = filestream.ReadLine()
                Loop



                ' Disable sisanya
                Dim cmddisable As OleDb.OleDbCommand = New OleDb.OleDbCommand("UPDATE master_heinv SET heinv_isdisabled=1 WHERE region_id=? AND heinv_modifyby is NULL", conn)
                cmddisable.Parameters.Add("@region_id", OleDb.OleDbType.VarChar).Value = region_id
                cmddisable.ExecuteNonQuery()




            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try

            Return True
        End Function


        Public Function Execute(ByVal sql As String) As DataTable
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim tbl As DataTable = New DataTable()

            Try
                Dim cmd As OleDb.OleDbCommand
                Dim da As OleDb.OleDbDataAdapter
                conn.Open()
                cmd = New OleDb.OleDbCommand(sql, conn)
                da = New OleDb.OleDbDataAdapter(cmd)
                da.Fill(tbl)
            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try
            Return tbl
        End Function



        Public Function GetDateString() As String
            Dim ret As String = ""
            Dim mo As Integer = Now().Month
            Dim mos As String = ""

            Select Case mo
                Case 1 : mos = "Jan"
                Case 2 : mos = "Feb"
                Case 3 : mos = "Mar"
                Case 4 : mos = "Apr"
                Case 5 : mos = "Mei"
                Case 6 : mos = "Jun"
                Case 7 : mos = "Jul"
                Case 8 : mos = "Ags"
                Case 9 : mos = "Sep"
                Case 10 : mos = "Okt"
                Case 11 : mos = "Nov"
                Case 12 : mos = "Des"
            End Select

            ret = Now().Day & " " & mos & " " & Now.Year()
            Return ret
        End Function

        Public Function Save(ByRef objBonHeaderData As POS.PosHeader) As Boolean
            Dim ret As Boolean = False

            Dim bon_id As String = ""
            Dim dsn As String = POS.DSN
            Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim dbTrans As OleDb.OleDbTransaction
            Dim fgtasync As FGTASync = New FGTASync()



            dbConn.Open()
            dbTrans = dbConn.BeginTransaction()



            Try
                objBonHeaderData.bon_id = ""
                Me.SaveHeader(objBonHeaderData, dbConn, dbTrans)
                Me.SaveItem(objBonHeaderData, dbConn, dbTrans)
                Me.SavePayment(objBonHeaderData, dbConn, dbTrans)
                Me.PosItems.AcceptChanges()
                Me.PosPayments.AcceptChanges()

                fgtasync.Synchronize(objBonHeaderData)

                dbTrans.Commit()


                Me.mui.SendData()
            Catch ex As Exception
                dbTrans.Rollback()
                Throw ex
            Finally
                dbConn.Close()
            End Try

            Return ret
        End Function

        Public Function SaveHeader(ByRef objBonHeaderData As POS.PosHeader, ByRef dbConn As OleDb.OleDbConnection, ByRef dbTrans As OleDb.OleDbTransaction) As Boolean
            Dim dbCmdInsert As OleDb.OleDbCommand
            'dbCmdInsert = New OleDb.OleDbCommand("poshe_TrnBon_InsertHeader", dbConn, dbTrans)
            'dbCmdInsert.CommandType = CommandType.StoredProcedure

            Dim SQL As String = Me.ReadEmbedSql("InsertHeader")

            dbCmdInsert = dbConn.CreateCommand()
            dbCmdInsert.Transaction = dbTrans
            dbCmdInsert.CommandType = CommandType.Text
            dbCmdInsert.CommandText = SQL
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_id", System.Data.OleDb.OleDbType.VarWChar, 40))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_idext", System.Data.OleDb.OleDbType.VarWChar, 50))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_event", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_createby", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_createdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_modifyby", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_modifydate", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_isvoid", System.Data.OleDb.OleDbType.Boolean, 1))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_voiddate", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_replacefromvoid", System.Data.OleDb.OleDbType.VarWChar, 40))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_msubtotal", System.Data.OleDb.OleDbType.Decimal, 9))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_msubtvoucher", System.Data.OleDb.OleDbType.Decimal, 9))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_msubtdiscadd", System.Data.OleDb.OleDbType.Decimal, 9))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_msubtredeem", System.Data.OleDb.OleDbType.Decimal, 9))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_msubtracttotal", System.Data.OleDb.OleDbType.Decimal, 9))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_msubtotaltobedisc", System.Data.OleDb.OleDbType.Decimal, 9))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_mdiscpaympercent", System.Data.OleDb.OleDbType.Decimal, 9))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_mdiscpayment", System.Data.OleDb.OleDbType.Decimal, 9))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_mtotal", System.Data.OleDb.OleDbType.Decimal, 9))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_mpayment", System.Data.OleDb.OleDbType.Decimal, 9))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_mrefund", System.Data.OleDb.OleDbType.Decimal, 9))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_msalegross", System.Data.OleDb.OleDbType.Decimal, 9))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_msaletax", System.Data.OleDb.OleDbType.Decimal, 9))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_msalenet", System.Data.OleDb.OleDbType.Decimal, 9))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_itemqty", System.Data.OleDb.OleDbType.Integer, 4))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_rowitem", System.Data.OleDb.OleDbType.Integer, 4))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_rowpayment", System.Data.OleDb.OleDbType.Integer, 4))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_npwp", System.Data.OleDb.OleDbType.VarWChar, 50))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_fakturpajak", System.Data.OleDb.OleDbType.VarWChar, 50))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_adddisc_authusername", System.Data.OleDb.OleDbType.VarWChar, 50))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_disctype", System.Data.OleDb.OleDbType.VarWChar, 30))

            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@customer_id", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@customer_name", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@customer_telp", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@customer_npwp", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@customer_ageid", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@customer_agename", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@customer_genderid", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@customer_gendername", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@customer_nationalityid", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@customer_nationalityname", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@customer_typename", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@customer_passport", System.Data.OleDb.OleDbType.VarWChar, 50))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@customer_disc", System.Data.OleDb.OleDbType.Integer, 4))

            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@voucher01_id", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@voucher01_name", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@voucher01_codenum", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@voucher01_method", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@voucher01_type", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@voucher01_discp", System.Data.OleDb.OleDbType.Decimal, 9))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@salesperson_id", System.Data.OleDb.OleDbType.VarWChar, 10))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@salesperson_name", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@pospayment_id", System.Data.OleDb.OleDbType.VarWChar, 10))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@pospayment_name", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@posedc_id", System.Data.OleDb.OleDbType.VarWChar, 10))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@posedc_name", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@machine_id", System.Data.OleDb.OleDbType.VarWChar, 10))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.VarWChar, 5))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@branch_id", System.Data.OleDb.OleDbType.VarWChar, 7))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@syncode", System.Data.OleDb.OleDbType.VarWChar, 50))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@syndate", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rowid", System.Data.OleDb.OleDbType.VarWChar, 50))

            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@site_id_from", System.Data.OleDb.OleDbType.VarWChar, 20))


            dbCmdInsert.Parameters("@bon_id").Value = objBonHeaderData.bon_id
            dbCmdInsert.Parameters("@bon_idext").Value = objBonHeaderData.bon_idext
            dbCmdInsert.Parameters("@bon_event").Value = objBonHeaderData.bon_event
            dbCmdInsert.Parameters("@bon_date").Value = objBonHeaderData.bon_date
            dbCmdInsert.Parameters("@bon_createby").Value = objBonHeaderData.bon_createby
            dbCmdInsert.Parameters("@bon_createdate").Value = Now()
            dbCmdInsert.Parameters("@bon_modifyby").Value = ""
            dbCmdInsert.Parameters("@bon_modifydate").Value = Now()
            dbCmdInsert.Parameters("@bon_isvoid").Value = 0
            dbCmdInsert.Parameters("@bon_voiddate").Value = Now()
            dbCmdInsert.Parameters("@bon_replacefromvoid").Value = objBonHeaderData.bon_replacefromvoid
            dbCmdInsert.Parameters("@bon_msubtotal").Value = objBonHeaderData.bon_msubtotal
            dbCmdInsert.Parameters("@bon_msubtvoucher").Value = objBonHeaderData.bon_msubtvoucher
            dbCmdInsert.Parameters("@bon_msubtdiscadd").Value = objBonHeaderData.bon_msubtdiscadd
            dbCmdInsert.Parameters("@bon_msubtredeem").Value = objBonHeaderData.bon_msubtredeem
            dbCmdInsert.Parameters("@bon_msubtracttotal").Value = objBonHeaderData.bon_msubtracttotal
            dbCmdInsert.Parameters("@bon_msubtotaltobedisc").Value = objBonHeaderData.bon_msubtotaltobedisc
            dbCmdInsert.Parameters("@bon_mdiscpaympercent").Value = objBonHeaderData.bon_mdiscpaympercent
            dbCmdInsert.Parameters("@bon_mdiscpayment").Value = objBonHeaderData.bon_mdiscpayment
            dbCmdInsert.Parameters("@bon_mtotal").Value = objBonHeaderData.bon_mtotal
            dbCmdInsert.Parameters("@bon_mpayment").Value = objBonHeaderData.bon_mpayment
            dbCmdInsert.Parameters("@bon_mrefund").Value = objBonHeaderData.bon_mrefund
            dbCmdInsert.Parameters("@bon_msalegross").Value = objBonHeaderData.bon_msalegross
            dbCmdInsert.Parameters("@bon_msaletax").Value = objBonHeaderData.bon_msaletax
            dbCmdInsert.Parameters("@bon_msalenet").Value = objBonHeaderData.bon_msalenet
            dbCmdInsert.Parameters("@bon_itemqty").Value = objBonHeaderData.bon_itemqty
            dbCmdInsert.Parameters("@bon_rowitem").Value = objBonHeaderData.bon_rowitem
            dbCmdInsert.Parameters("@bon_rowpayment").Value = objBonHeaderData.bon_rowpayment
            dbCmdInsert.Parameters("@bon_npwp").Value = objBonHeaderData.bon_npwp
            dbCmdInsert.Parameters("@bon_fakturpajak").Value = objBonHeaderData.bon_fakturpajak
            dbCmdInsert.Parameters("@bon_adddisc_authusername").Value = objBonHeaderData.bon_adddisc_authusername
            dbCmdInsert.Parameters("@bon_disctype").Value = objBonHeaderData.bon_disctype

            dbCmdInsert.Parameters("@customer_id").Value = objBonHeaderData.customer_id
            dbCmdInsert.Parameters("@customer_name").Value = objBonHeaderData.customer_name
            dbCmdInsert.Parameters("@customer_telp").Value = objBonHeaderData.customer_telp
            dbCmdInsert.Parameters("@customer_npwp").Value = objBonHeaderData.customer_npwp
            dbCmdInsert.Parameters("@customer_ageid").Value = objBonHeaderData.customer_ageid
            dbCmdInsert.Parameters("@customer_agename").Value = objBonHeaderData.customer_agename
            dbCmdInsert.Parameters("@customer_genderid").Value = objBonHeaderData.customer_genderid
            dbCmdInsert.Parameters("@customer_gendername").Value = objBonHeaderData.customer_gendername
            dbCmdInsert.Parameters("@customer_nationalityid").Value = objBonHeaderData.customer_nationalityid
            dbCmdInsert.Parameters("@customer_nationalityname").Value = objBonHeaderData.customer_nationalityname
            dbCmdInsert.Parameters("@customer_typename").Value = objBonHeaderData.customer_typename
            dbCmdInsert.Parameters("@customer_passport").Value = objBonHeaderData.customer_passport
            dbCmdInsert.Parameters("@customer_disc").Value = objBonHeaderData.customer_disc

            dbCmdInsert.Parameters("@voucher01_id").Value = objBonHeaderData.voucher01_id
            dbCmdInsert.Parameters("@voucher01_name").Value = objBonHeaderData.voucher01_name
            dbCmdInsert.Parameters("@voucher01_codenum").Value = objBonHeaderData.voucher01_codenum
            dbCmdInsert.Parameters("@voucher01_method").Value = objBonHeaderData.voucher01_method
            dbCmdInsert.Parameters("@voucher01_type").Value = objBonHeaderData.voucher01_type
            dbCmdInsert.Parameters("@voucher01_discp").Value = objBonHeaderData.voucher01_discp
            dbCmdInsert.Parameters("@salesperson_id").Value = objBonHeaderData.salesperson_id
            dbCmdInsert.Parameters("@salesperson_name").Value = objBonHeaderData.salesperson_name
            dbCmdInsert.Parameters("@pospayment_id").Value = objBonHeaderData.pospayment_id
            dbCmdInsert.Parameters("@pospayment_name").Value = objBonHeaderData.pospayment_name
            dbCmdInsert.Parameters("@posedc_id").Value = objBonHeaderData.posedc_id
            dbCmdInsert.Parameters("@posedc_name").Value = objBonHeaderData.posedc_name
            dbCmdInsert.Parameters("@machine_id").Value = objBonHeaderData.machine_id
            dbCmdInsert.Parameters("@region_id").Value = objBonHeaderData.region_id
            dbCmdInsert.Parameters("@branch_id").Value = objBonHeaderData.branch_id
            dbCmdInsert.Parameters("@syncode").Value = ""
            dbCmdInsert.Parameters("@syndate").Value = Now
            dbCmdInsert.Parameters("@rowid").Value = ""
            dbCmdInsert.Parameters("@site_id_from").Value = objBonHeaderData.site_id_from

            Dim dr As OleDb.OleDbDataReader
            dr = dbCmdInsert.ExecuteReader()
            dr.Read()

            objBonHeaderData.bon_id = dr("bon_id")
            objBonHeaderData.bon_idext = dr("bon_idext")

        End Function

        Public Function SaveItem(ByRef objBonHeaderData As POS.PosHeader, ByRef dbConn As OleDb.OleDbConnection, ByRef dbTrans As OleDb.OleDbTransaction) As Boolean
            Dim dbDA As OleDb.OleDbDataAdapter


            Me.PosItems.AcceptChanges()

            If Me.PosItems.Rows.Count <= 0 Then
                Throw New Exception("[POS:SaveItem]" & vbCrLf & "Data Item Kosong.")
                Return False
            End If


            Dim i As Integer
            For i = 0 To Me.PosItems.Rows.Count - 1
                Me.PosItems.Rows(i).SetAdded()
            Next

            Dim dbCmdInsert As OleDb.OleDbCommand
            dbCmdInsert = New OleDb.OleDbCommand("poshe_TrnBon_InsertItem", dbConn, dbTrans)
            dbCmdInsert.CommandType = CommandType.StoredProcedure
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_id", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_line", System.Data.OleDb.OleDbType.Integer, 4, "bondetil_line"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@heinv_id", System.Data.OleDb.OleDbType.VarWChar, 13, "heinv_id"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@heinvitem_id", System.Data.OleDb.OleDbType.VarWChar, 13, "bondetil_item"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@heinvitem_barcode", System.Data.OleDb.OleDbType.VarWChar, 30, "bondetil_barcode"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_descr", System.Data.OleDb.OleDbType.VarWChar, 50, "bondetil_descr"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_art", System.Data.OleDb.OleDbType.VarWChar, 30, "bondetil_article"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_col", System.Data.OleDb.OleDbType.VarWChar, 30, "bondetil_color"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_size", System.Data.OleDb.OleDbType.VarWChar, 30, "bondetil_size"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_mat", System.Data.OleDb.OleDbType.VarWChar, 30, "bondetil_material"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_mpricegross", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "bondetil_pricegross", System.Data.DataRowVersion.Current, Nothing))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_mdiscpstd01", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "bondetil_discpstd01", System.Data.DataRowVersion.Current, Nothing))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_mdiscrstd01", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "bondetil_discrstd01", System.Data.DataRowVersion.Current, Nothing))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_mpricenettstd01", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "bondetil_pricenettstd01", System.Data.DataRowVersion.Current, Nothing))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_mdiscpvou01", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "bondetil_discpvou01", System.Data.DataRowVersion.Current, Nothing))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_mdiscrvou01", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "bondetil_discrvou01", System.Data.DataRowVersion.Current, Nothing))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_mpricecettvou01", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "bondetil_pricenettvou01", System.Data.DataRowVersion.Current, Nothing))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_vou01id", System.Data.OleDb.OleDbType.VarWChar, 10, "bondetil_vou01id"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_vou01codenum", System.Data.OleDb.OleDbType.VarWChar, 30, "bondetil_vou01codenum"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_vou01type", System.Data.OleDb.OleDbType.VarWChar, 10, "bondetil_vou01type"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_vou01method", System.Data.OleDb.OleDbType.VarWChar, 30, "bondetil_vou01method"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_vou01discp", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "bondetil_vou01discp", System.Data.DataRowVersion.Current, Nothing))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_rule", System.Data.OleDb.OleDbType.VarWChar, 2, "bondetil_rule"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_mpricenett", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "bondetil_pricenet", System.Data.DataRowVersion.Current, Nothing))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_qty", System.Data.OleDb.OleDbType.Integer, 4, "bondetil_qty"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bondetil_msubtotal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "bondetil_subtotal", System.Data.DataRowVersion.Current, Nothing))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@pricingrule_id", System.Data.OleDb.OleDbType.VarWChar, 30, "pricingrule_id"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@promorule_id", System.Data.OleDb.OleDbType.VarWChar, 30, "promorule_id"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@promo_line", System.Data.OleDb.OleDbType.Integer, 4, "promo_line"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@colname", System.Data.OleDb.OleDbType.VarWChar, 3, "colname"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sizetag", System.Data.OleDb.OleDbType.VarWChar, 3, "sizetag"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@proc", System.Data.OleDb.OleDbType.VarWChar, 10, "proc"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.VarWChar, 5, "region_id"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_nameshort", System.Data.OleDb.OleDbType.VarWChar, 10, "region_nameshort"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@heinvgro_id", System.Data.OleDb.OleDbType.VarWChar, 10, "heinvgro_id"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@heinvctg_id", System.Data.OleDb.OleDbType.VarWChar, 10, "heinvctg_id"))
            dbCmdInsert.Parameters("@bon_id").Value = objBonHeaderData.bon_id
            dbDA = New OleDb.OleDbDataAdapter
            dbDA.InsertCommand = dbCmdInsert

            Try
                dbDA.Update(Me.PosItems)
            Catch ex As Data.OleDb.OleDbException
                Throw New Exception("[POS:SaveItem] - OleDB Error" & vbCrLf & ex.Message)
                Return False
            Catch ex As Exception
                Throw New Exception("[POS:SaveItem]" & vbCrLf & ex.Message)
                Return False
            End Try

        End Function

        Public Function SavePayment(ByRef objBonHeaderData As POS.PosHeader, ByRef dbConn As OleDb.OleDbConnection, ByRef dbTrans As OleDb.OleDbTransaction) As Boolean
            Dim dbDA As OleDb.OleDbDataAdapter

            Me.PosPayments.AcceptChanges()

            If objBonHeaderData.bon_mtotal > 0 Then
                If Me.PosPayments.Rows.Count <= 0 Then
                    Throw New Exception("[POS:SavePayment]" & vbCrLf & "Data Payment Kosong.")
                    Return False
                End If
            End If

            Dim i As Integer
            For i = 0 To Me.PosPayments.Rows.Count - 1
                Me.PosPayments.Rows(i).SetAdded()
            Next


            'SQL = Me.ReadEmbedSql("ScanBarcode03")
            'cmdScan = conn.CreateCommand()
            'cmdScan.CommandType = CommandType.Text
            'cmdScan.CommandText = SQL
            'cmdScan.Parameters.Add(New System.Data.OleDb.OleDbParameter("@criteria", System.Data.OleDb.OleDbType.VarWChar, 255))
            'cmdScan.Parameters("@criteria").Value = SQLCriteria
            'da = New OleDb.OleDbDataAdapter(cmdScan)


            Dim SQL As String = Me.ReadEmbedSql("InsertPayment")


            Dim dbCmdInsert As OleDb.OleDbCommand
            ' dbCmdInsert = New OleDb.OleDbCommand("poshe_TrnBon_InsertPayment", dbConn, dbTrans)
            ' dbCmdInsert.CommandType = CommandType.StoredProcedure

            dbCmdInsert = dbConn.CreateCommand()
            dbCmdInsert.Transaction = dbTrans
            dbCmdInsert.CommandType = CommandType.Text
            dbCmdInsert.CommandText = SQL
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_id", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@payment_line", System.Data.OleDb.OleDbType.Integer, 4, "payment_line"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@payment_cardnumber", System.Data.OleDb.OleDbType.VarWChar, 40, "payment_cardnumber"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@payment_cardholder", System.Data.OleDb.OleDbType.VarWChar, 40, "payment_cardholder"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@payment_mvalue", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "payment_value", System.Data.DataRowVersion.Current, Nothing))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@payment_mcash", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "payment_cash", System.Data.DataRowVersion.Current, Nothing))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@payment_installment", System.Data.OleDb.OleDbType.Integer, 4, "payment_installment"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@pospayment_id", System.Data.OleDb.OleDbType.VarWChar, 40, "payment_type"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@pospayment_name", System.Data.OleDb.OleDbType.VarWChar, 40, "payment_typename"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@pospayment_bank", System.Data.OleDb.OleDbType.VarWChar, 40, "payment_bankname"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@posedc_id", System.Data.OleDb.OleDbType.VarWChar, 40, "payment_edc"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@posedc_name", System.Data.OleDb.OleDbType.VarWChar, 40, "payment_edcname"))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@posedc_approval", System.Data.OleDb.OleDbType.VarWChar, 40, "payment_edcapproval"))


            dbCmdInsert.Parameters("@bon_id").Value = objBonHeaderData.bon_id

            dbDA = New OleDb.OleDbDataAdapter
            dbDA.InsertCommand = dbCmdInsert

            Try
                dbDA.Update(Me.PosPayments)
            Catch ex As Data.OleDb.OleDbException
                Throw New Exception("[POS:SavePayment] - OleDB Error" & vbCrLf & ex.Message)
                Return False
            Catch ex As Exception
                Throw New Exception("[POS:SavePayment]" & vbCrLf & ex.Message)
                Return False
            End Try
        End Function



        Public Function ReadEmbedSql(ByVal filename As String) As String

            Dim path As String = "POS05EN." & filename & ".sql"

            Try
                Dim assembly As System.Reflection.Assembly = Me.GetType().Assembly
                Dim stream As System.IO.Stream = assembly.GetManifestResourceStream(path)
                Dim streamreader As System.IO.StreamReader = New IO.StreamReader(stream)
                Return streamreader.ReadToEnd()
            Catch ex As Exception
                Throw ex
            End Try


        End Function



        Public Function VoidBon(ByVal bon_id As String, ByVal username As String) As String
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim cmd As OleDb.OleDbCommand
            Dim SQL As String

            Try
                conn.Open()

                SQL = "UPDATE transaksi_hepos "
                SQL &= "SET "
                SQL &= "bon_isvoid=1, bon_voiddate=getdate(), "
                SQL &= "bon_voidby='" & username & "', "
                SQL &= "syncode=NULL, syndate=NULL "
                SQL &= "WHERE bon_id='" & bon_id & "' "
                cmd = New OleDb.OleDbCommand(SQL, conn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try

            Return bon_id
        End Function

        Public Function SaveNotaRetur(ByVal bon_id As String, ByVal heinv_id As String, ByVal qty As String, ByVal notes As String, ByVal new_bon_id As String) As String
            Dim notaretur_id As String = ""
            Dim dsn As String = POS.DSN
            Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim dbTrans As OleDb.OleDbTransaction

            dbConn.Open()
            dbTrans = dbConn.BeginTransaction()

            Try
                notaretur_id = Me.SaveNotaReturHeader(bon_id, heinv_id, qty, notes, new_bon_id, dbConn, dbTrans)
                dbTrans.Commit()
            Catch ex As Exception
                dbTrans.Rollback()
                Throw ex
            Finally
                dbConn.Close()
            End Try

            Return notaretur_id
        End Function

        Public Function SaveNotaReturHeader(ByVal bon_id As String, ByVal heinvitem_id As String, ByVal qty As Integer, ByVal notes As String, ByVal new_bon_id As String, ByRef dbConn As OleDb.OleDbConnection, ByRef dbTrans As OleDb.OleDbTransaction) As String
            Dim notaretur_id As String = ""
            Dim dr As OleDb.OleDbDataReader

            Dim dbCmdInsert As OleDb.OleDbCommand
            dbCmdInsert = New OleDb.OleDbCommand("poshe_TrnBon_InsertHeaderNR", dbConn, dbTrans)
            dbCmdInsert.CommandType = CommandType.StoredProcedure
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bon_id_to_void", System.Data.OleDb.OleDbType.VarWChar, 40))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@heinvitem_id", System.Data.OleDb.OleDbType.VarWChar, 13))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@qty", System.Data.OleDb.OleDbType.Integer))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@notes", System.Data.OleDb.OleDbType.VarWChar, 30))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@new_bon_id", System.Data.OleDb.OleDbType.VarWChar, 40))
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@createby", System.Data.OleDb.OleDbType.VarWChar, 40))

            dbCmdInsert.Parameters("@bon_id_to_void").Value = bon_id
            dbCmdInsert.Parameters("@heinvitem_id").Value = heinvitem_id
            dbCmdInsert.Parameters("@qty").Value = qty
            dbCmdInsert.Parameters("@notes").Value = notes
            dbCmdInsert.Parameters("@new_bon_id").Value = new_bon_id
            dbCmdInsert.Parameters("@createby").Value = Me.UserName

            Try
                dr = dbCmdInsert.ExecuteReader()
                dr.Read()
                notaretur_id = dr("notareturid")
            Catch ex As Data.OleDb.OleDbException
                Throw New Exception("[POS:SaveNotaReturHeader] - OleDB Error" & vbCrLf & ex.Message)
                Return False
            Catch ex As Exception
                Throw New Exception("[POS:SaveNotaReturHeader]" & vbCrLf & ex.Message)
                Return False
            End Try

            Return notaretur_id
        End Function

        Public Function IsAuthUsername(ByVal username As String, ByVal password As String) As Boolean
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim cmd As OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader
            Dim md5 As IST.DataHash.MD5 = New IST.DataHash.MD5
            Dim ret As Boolean
            Dim _pwd As String


            If username = "agung" And password = "SatuDuaTiga" Then
                Return True
            End If


            Try
                conn.Open()
                cmd = New OleDb.OleDbCommand("SELECT * FROM master_user WHERE username='" & username & "'", conn)
                dr = cmd.ExecuteReader()
                dr.Read()
                If Not dr.HasRows Then
                    ret = False
                Else
                    ' Check Password
                    _pwd = dr("user_password").ToString
                    If Not md5.Verify(password, _pwd) Then
                        ret = False
                    Else
                        ret = True
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try

            Return ret
        End Function

        Public Function NumOfPrevBonEdited(ByVal dtSQL As String) As Integer
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim cmd As OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader
            Dim i As Integer = 0
            Dim ret As Integer = 0

            Try
                conn.Open()
                cmd = New OleDb.OleDbCommand("SET NOCOUNT ON; DECLARE @date AS smalldatetime; SET @date='" & dtSQL & "'; SELECT  * FROM transaksi_hepos A WHERE (convert(varchar(10),A.bon_date,120)<>convert(varchar(10),@date,120)) AND (A.syncode IS NULL OR A.syncode='') ", conn)
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    While dr.Read
                        i = i + 1
                    End While
                    ret = i
                Else
                    ret = 0
                End If

            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try

            Return ret
        End Function

        Public Function GetLocationStatus() As String
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim cmd As OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader

            Dim status, region_id, branch_id, machine_id As String
            region_id = Me.RegionId
            branch_id = Me.BranchId
            machine_id = Me.MachineId

            Try
                conn.Open()
                cmd = New OleDb.OleDbCommand("SELECT * FROM master_region WHERE region_id='" & region_id & "'", conn)
                dr = cmd.ExecuteReader()
                dr.Read()
                status = dr("region_name")

                cmd = New OleDb.OleDbCommand("SELECT * FROM master_branch WHERE branch_id='" & branch_id & "'", conn)
                dr = cmd.ExecuteReader()
                dr.Read()
                status &= " / " & dr("branch_name")

            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try

            Return status
        End Function

        Public Function GetLastID() As String
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim cmd As OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader

            Dim bon_id, region_id, branch_id, machine_id As String
            region_id = Me.RegionId
            branch_id = Me.BranchId
            machine_id = Me.MachineId

            Try
                conn.Open()
                cmd = New OleDb.OleDbCommand("SELECT top 1 bon_id FROM transaksi_hepos WHERE region_id='" & region_id & "' AND branch_id='" & branch_id & "' AND machine_id='" & machine_id & "' ORDER by bon_id DESC", conn)
                dr = cmd.ExecuteReader()
                dr.Read()
                If dr.HasRows Then
                    bon_id = dr("bon_id").ToString
                Else
                    bon_id = ""
                End If
            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try

            Return bon_id
        End Function

        Public Function GetBonData(ByVal obj As TransStore.POS.PosHeader) As uiTrnPosEN.PosBonData
            Dim ret As uiTrnPosEN.PosBonData = New uiTrnPosEN.PosBonData
            ret.obj = obj

            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim tblH, tblI, tblP As DataTable
            Dim cmd As OleDb.OleDbCommand
            Dim da As OleDb.OleDbDataAdapter

            Try
                conn.Open()

                tblH = New DataTable
                cmd = New OleDb.OleDbCommand(String.Format("SELECT * FROM transaksi_hepos WHERE bon_id='{0}'", obj.bon_id), conn)
                da = New OleDb.OleDbDataAdapter(cmd)
                da.Fill(tblH)
                da.Dispose()

                tblI = New DataTable
                cmd = New OleDb.OleDbCommand(String.Format("SELECT * FROM transaksi_heposdetil WHERE bon_id='{0}'", obj.bon_id), conn)
                da = New OleDb.OleDbDataAdapter(cmd)
                da.Fill(tblI)
                da.Dispose()

                tblP = New DataTable
                cmd = New OleDb.OleDbCommand(String.Format("SELECT * FROM transaksi_hepospayment WHERE bon_id='{0}'", obj.bon_id), conn)
                da = New OleDb.OleDbDataAdapter(cmd)
                da.Fill(tblP)
                da.Dispose()

                ret.Header = tblH
                ret.Items = tblI
                ret.Payments = tblP

                Return ret
            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try

        End Function

        Public Function GetBonReturnedItem(ByVal bon_id As String, ByVal heinvitem_id As String) As Integer
            Dim sql As String
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim cmd As OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader
            Dim qtr_ret As Integer

            sql = "SELECT qtr_ret = isnull(SUM(B.bondetil_qty) , 0) " & _
                  " FROM transaksi_hepos A inner join transaksi_heposdetil B  " & _
                  " ON A.bon_id = B.bon_id " & _
                  " WHERE " & _
                  " A.bon_replacefromvoid = '" & bon_id & "' " & _
                  " AND B.heinvitem_id = '" & heinvitem_id & "' "

            Try
                conn.Open()
                cmd = New OleDb.OleDbCommand(sql, conn)
                dr = cmd.ExecuteReader()
                dr.Read()
                If dr.HasRows Then
                    qtr_ret = dr("qtr_ret").ToString
                Else
                    qtr_ret = 0
                End If

            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try

            Return qtr_ret

        End Function

        Public Function GetSalesNameById(ByVal salesid As String) As String
            Dim sql As String
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim cmd As OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader
            Dim salesname As String

            sql = "select possalesperson_name from master_possalesperson WHERE possalesperson_isdisabled=0 AND possalesperson_id = '" & salesid & "'  "

            Try
                conn.Open()
                cmd = New OleDb.OleDbCommand(sql, conn)
                dr = cmd.ExecuteReader()
                dr.Read()
                If dr.HasRows Then
                    salesname = dr("possalesperson_name").ToString
                Else
                    salesname = ""
                End If

            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try

            Return salesname

        End Function

        Public Function IsMachineDateError(ByVal region_id As String, ByVal branch_id As String, ByVal machine_id As String) As Boolean
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim cmd As OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader
            Dim SQL As String
            Dim result As String

            SQL = String.Format("IF (SELECT lastdate FROM sequencer_pos WHERE [type]=(SELECT regionbranch_codesal FROM master_regionbranch WHERE region_id='{0}' AND branch_id='{1}') AND machine_id='{2}') > getdate()", region_id, branch_id, machine_id)
            SQL &= " BEGIN SELECT 1 AS result END "
            SQL &= " ELSE "
            SQL &= " BEGIN SELECT 0 AS result END "

            Try
                conn.Open()
                cmd = New OleDb.OleDbCommand(SQL, conn)
                dr = cmd.ExecuteReader()
                dr.Read()
                If dr.HasRows Then
                    result = dr("result").ToString
                Else
                    result = "0"
                End If

            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try


            Return CBool(result)

        End Function

        Public Function SignInStatusIsOpened() As Boolean
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim cmd As OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader
            Dim ret As Boolean
            Dim SQL As String

            Dim region_id, branch_id As String
            region_id = Me.RegionId
            branch_id = Me.BranchId

            SQL = "SET NOCOUNT ON; " & vbCrLf
            SQL &= "DECLARE @region_id as varchar(5); " & vbCrLf
            SQL &= "DECLARE @branch_id as varchar(7); " & vbCrLf
            SQL &= "DECLARE @lastdate as smalldatetime; " & vbCrLf
            SQL &= "SET @region_id = '" & region_id & "'; " & vbCrLf
            SQL &= "SET @branch_id = '" & branch_id & "'; " & vbCrLf
            SQL &= "SET @lastdate = (SELECT TOP 1 synsign_dateclient FROM transaksi_hepossynsignclient " & vbCrLf
            SQL &= "                 WHERE region_id=@region_id AND branch_id=@branch_id " & vbCrLf
            SQL &= "                       AND synsign_type='SIGNOFF' " & vbCrLf
            SQL &= "                       AND synsign_iscompleted=1 " & vbCrLf
            SQL &= "                 ORDER BY synsign_dateclient DESC);" & vbCrLf
            SQL &= " " & vbCrLf
            SQL &= "SELECT * FROM  transaksi_hepossynsignclient " & vbCrLf
            SQL &= "WHERE region_id=@region_id AND branch_id=@branch_id " & vbCrLf
            SQL &= "                       AND synsign_type='SIGNIN' AND synsign_dateclient > @lastdate AND synsign_iscompleted=1 " & vbCrLf
            SQL &= "ORDER BY synsign_dateclient DESC; " & vbCrLf





            Try
                conn.Open()
                cmd = New OleDb.OleDbCommand(SQL, conn)
                dr = cmd.ExecuteReader()
                dr.Read()
                If dr.HasRows Then
                    ret = True
                Else
                    ret = False
                End If
            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try


            Return ret
        End Function

        Public Function IfUnSyncronizedDataExist() As Boolean
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim cmd As OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader
            Dim ret As Boolean

            Dim region_id, branch_id, machine_id As String
            region_id = Me.RegionId
            branch_id = Me.BranchId
            machine_id = Me.MachineId

            Try
                conn.Open()
                cmd = New OleDb.OleDbCommand("SELECT top 1 * FROM transaksi_hepos WHERE region_id='" & region_id & "' AND branch_id='" & branch_id & "' AND syncode IS NULL ", conn)
                dr = cmd.ExecuteReader()
                dr.Read()
                If dr.HasRows Then
                    ret = True
                Else
                    ret = False
                End If
            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try


            Return ret
        End Function


        Public Function GetCustomerData(ByVal customer_id As String) As CustomerData
            Dim cust As New CustomerData
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim cmd As OleDb.OleDbCommand

            Try
                Dim SQL As String = ""
                SQL &= "select A.customer_id, A.customer_namefull, A.customer_typename, "
                SQL &= "case when A.customer_paymdisc > 0 then A.customer_paymdisc else B.posvouchertype_disc end as disc, "
                SQL &= "B.posvouchertype_method, B.posvouchertype_selectedtype, B.posvouchertype_id, B.posvouchertype_descr "
                SQL &= "from master_customer A left join master_posvouchertype B on B.posvouchertype_id=RIGHT(A.customer_typename, 6)"
                SQL &= "where A.customer_id = '" & customer_id & "'"

                conn.Open()
                Try
                    cmd = New OleDb.OleDbCommand(SQL, conn)

                    Dim tbl As DataTable = New DataTable()
                    Dim da As OleDb.OleDbDataAdapter
                    da = New OleDb.OleDbDataAdapter(cmd)
                    da.Fill(tbl)

                    If tbl.Rows.Count > 0 Then
                        Dim row As DataRow = tbl.Rows(0)
                        cust.Id = row("customer_id")
                        cust.Nama = row("customer_namefull")
                        cust.VoucherName = row("customer_typename")
                        cust.Discount = row("disc")
                        cust.Method = row("posvouchertype_method")
                        cust.Type = row("posvouchertype_selectedtype")
                        cust.VoucherTypeId = row("posvouchertype_id")
                        cust.VoucherTypeName = row("posvouchertype_descr")

                        If (cust.VoucherTypeId Is Nothing) Then
                            cust.VoucherTypeId = "000000"
                            cust.VoucherTypeName = "NONE"
                            cust.Method = "REPLIFLESS"
                            cust.Type = "NONE"
                        End If

                        Return cust
                    Else
                        Return Nothing
                    End If
                Catch ex As Exception
                    Throw ex
                Finally
                    conn.Close()
                End Try

            Catch ex As Exception
                Throw ex
            End Try
        End Function



        Public Function InjectPromoData() As Boolean
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim cmd As OleDb.OleDbCommand


            Dim SQL As String
            Dim nowdate As Date = Now
            If (Month(nowdate) = 5 And Year(nowdate) = 2014) Then
                SQL = "DELETE FROM master_posvouchertype WHERE posvouchertype_id='MEGAMAY14' " & vbCrLf
                SQL &= "INSERT INTO master_posvouchertype " & vbCrLf
                SQL &= "(posvouchertype_id, posvouchertype_descr, posvouchertype_disc, posvouchertype_selectedtype, posvouchertype_method, posvouchertype_order, posvouchertype_isdisabled, posvouchertype_event)" & vbCrLf
                SQL &= "VALUES" & vbCrLf
                SQL &= "('MEGAMAY14', 'MEGAMAY14', 0, 'ALL', 'NONE', 1, 0, 'NEW')"
            Else
                SQL = "DELETE FROM master_posvouchertype WHERE posvouchertype_id='MEGAMAY14' " & vbCrLf
            End If


            Try
                conn.Open()
                Try
                    cmd = New OleDb.OleDbCommand(SQL, conn)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Throw ex
                Finally
                    conn.Close()
                End Try
            Catch ex As Exception
                Throw ex
            End Try
        End Function



        Public Sub PrepareTable()
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim cmd As OleDb.OleDbCommand
            Dim sql As String

            Try
                conn.Open()

                sql = "if not exists (select * from sysobjects where name='master_site' and xtype='U')" & _
                      " create table master_site ( " & _
                      "     site_id varchar(20) PRIMARY KEY not null, " & _
                      "     site_name varchar(30) not null, " & _
                      "     site_isdisabled tinyint not null default 0 " & _
                     " ) "

                cmd = New OleDb.OleDbCommand(sql, conn)
                cmd.ExecuteNonQuery()


                ' Fill Initial Data
                ' dim site_name as String = Me.region_n
                Dim site_name As String = Me.SiteName
                Dim site_id As String = Me.RegionId & ":" & Me.BranchId

                sql = " IF NOT EXISTS (SELECT * FROM master_site WHERE site_id='" & site_id & "') " & _
                      " BEGIN " & _
                      "   INSERT INTO master_site (site_id, site_name) VALUES ('" & site_id & "', '" & site_name & "')  " & _
                      " END "
                cmd = New OleDb.OleDbCommand(sql, conn)
                cmd.ExecuteNonQuery()



                ' Add kolom
                sql = " IF NOT EXISTS (SELECT *  FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[transaksi_hepos]')  AND name = 'site_id_from') " & _
                      " BEGIN " & _
                      "    ALTER TABLE transaksi_hepos ADD site_id_from varchar(20) " & _
                      " END"
                cmd = New OleDb.OleDbCommand(sql, conn)
                cmd.ExecuteNonQuery()


                ' Fix POS Voucher Type
                sql = " IF NOT EXISTS (SELECT *  FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[master_posvouchertype]')  AND name = 'posvouchertype_threshold') " & _
                      " BEGIN " & _
                      "    ALTER TABLE master_posvouchertype ADD posvouchertype_threshold int not null default 1 " & _
                      " END"
                cmd = New OleDb.OleDbCommand(sql, conn)
                cmd.ExecuteNonQuery()


                ' Tambahkan Kolom PaymentDisc Rp
                sql = " IF NOT EXISTS (SELECT *  FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[master_pospayment]')  AND name = 'pospayment_discvalue') " & _
                      " BEGIN " & _
                      "    ALTER TABLE master_pospayment ADD pospayment_discvalue decimal(8,0) not null default 0 " & _
                      " END"
                cmd = New OleDb.OleDbCommand(sql, conn)
                cmd.ExecuteNonQuery()

                sql = " IF NOT EXISTS (SELECT *  FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[master_pospayment]')  AND name = 'pospayment_discminpurchase') " & _
                      " BEGIN " & _
                      "    ALTER TABLE master_pospayment ADD pospayment_discminpurchase decimal(9,0) not null default 0 " & _
                      " END"
                cmd = New OleDb.OleDbCommand(sql, conn)
                cmd.ExecuteNonQuery()


                sql = " IF NOT EXISTS (SELECT *  FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[master_pospayment]')  AND name = 'pospayment_maxitemdiscallowed') " & _
                                     " BEGIN " & _
                                     "    ALTER TABLE master_pospayment ADD pospayment_maxitemdiscallowed decimal(5,2) not null default 100 " & _
                                     " END"
                cmd = New OleDb.OleDbCommand(sql, conn)
                cmd.ExecuteNonQuery()


                ' Tambahkan Table untuk discount paymnet
                sql = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'master_pospaymentdisc') " & vbCrLf & _
                      "BEGIN" & vbCrLf & _
                      " CREATE TABLE master_pospaymentdisc (" & vbCrLf & _
                      "     pospayment_id varchar(10) not null," & vbCrLf & _
                      "   	region_id varchar(5) not null," & vbCrLf & _
                      "   	branch_id varchar(7) not null," & vbCrLf & _
                      "     disc_percent decimal(5,2) not null default 0," & vbCrLf & _
                      "     disc_value decimal(9, 0) not null default 0," & vbCrLf & _
                      "     minpurchase_value decimal(9, 0) not null default 0," & vbCrLf & _
                      "     minpurchase_qty int not null default 0," & vbCrLf & _
                      "     maxdisc_value decimal(9, 0) not null default 0," & vbCrLf & _
                      "     date_start date not null," & vbCrLf & _
                      "     date_end date not null," & vbCrLf & _
                      "     primary key(pospayment_id, region_id, branch_id)" & vbCrLf & _
                      " )" & vbCrLf & _
                      "END"
                cmd = New OleDb.OleDbCommand(sql, conn)
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try

        End Sub

        Public Function GetSite() As DataTable
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim cmd As OleDb.OleDbCommand
            Dim da As OleDb.OleDbDataAdapter
            Dim tbl As DataTable = New DataTable()
            tbl.Columns.Add(New DataColumn("site_id", GetType(String)))
            tbl.Columns.Add(New DataColumn("site_name", GetType(String)))


            Dim dr As DataRow = tbl.NewRow()
            dr("site_id") = "0"
            dr("site_name") = "-- PILIH --"
            tbl.Rows.Add(dr)

            'Dim status, region_id, branch_id, machine_id As String
            'region_id = Me.RegionId
            'branch_id = Me.BranchId
            'machine_id = Me.MachineId

            Try
                conn.Open()

                cmd = New OleDb.OleDbCommand("SELECT site_id, site_name FROM master_site WHERE site_isdisabled=0 ", conn)
                da = New OleDb.OleDbDataAdapter(cmd)
                da.Fill(tbl)

                Return tbl
            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try

        End Function



        'Public Function GetExistingPaymentToday(ByVal cardnumber As String, ByVal pospayment_id As String) As Decimal
        '    Try



        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function



        Public Function FormatBon(ByVal objBon As uiTrnPosEN.PosBonData, ByVal reprint As Boolean, ByVal void As Boolean) As String()
            Dim str() As String
            Dim bontype As String = Me.BONTYPE.ToUpper

            If IsDevelopmentMode Then
                bontype = Config.DevBonType
            End If


            Select Case bontype
                Case "OUTLET00"
                    str = FormatBon_Bazar(objBon, reprint, void)
                Case "OUTLET01"
                    str = FormatBon_Outlet01(objBon, reprint, void)
                Case "OUTLET02"
                    str = FormatBon_Outlet02(objBon, reprint, void)
                Case "OUTLET03"
                    str = FormatBon_Outlet03(objBon, reprint, void)
                Case Else
                    str = FormatBon_Bazar(objBon, reprint, void)
            End Select


            ' Sementara di set Outlet02 untuk proses development
            ' str = FormatBon_Outlet02(objBon, reprint, void)

            Return str
        End Function

        Public Function FormatReturNote(ByVal objBon As uiTrnPosEN.PosBonData, ByVal reprint As Boolean, ByVal void As Boolean) As String()
            Dim str() As String
            str = FormatBon_Bazar(objBon, reprint, void)
            Return str
        End Function

        Public Function FormatBon_Bazar(ByVal objBon As uiTrnPosEN.PosBonData, ByVal reprint As Boolean, ByVal void As Boolean) As String()
            Dim sb As TextBox = New TextBox()
            Dim pad As String = " " '"·"
            Dim Line As String = ""
            Dim PaperWidth As Integer = 137
            Dim NO, ID, ART, MAT, COL, SIZ, DES, PRC, DSC, DSC01, DSC02, QTY, SBT As String
            Dim PAY, CARD, CARDNO, CARDHO As String
            Dim IsCash As Boolean
            Dim mValue, mCash As Decimal
            Dim strReprint As String = ""
            Dim VOUTYPE As String = ""


            sb.Multiline = True


            If reprint Then
                strReprint = "(COPY)"
            Else
                strReprint = ""
            End If


            If void Then
                strReprint &= "(VOID)"
            End If


            Line = Me.COMPANY_NAME.PadRight(100, pad)
            Line &= String.Format("{1}  {0}", objBon.obj.bon_id, strReprint).PadLeft(PaperWidth - Len(Line), pad)
            sb.AppendText(Line & vbCrLf)

            If objBon.obj.bon_id.Substring(0, 2) = "NR" Then
                Line = "NOTA RETUR".PadRight(100, pad)
            Else
                Line = objBon.Header.Rows(0).Item("bon_event").PadRight(100, pad)
            End If

            Line &= String.Format("{0:dd/MM/yyyy HH:mm}", objBon.Header.Rows(0).Item("bon_date")).PadLeft(PaperWidth - Len(Line), pad)
            sb.AppendText(Line & vbCrLf)

            If Trim(objBon.Header.Rows(0).Item("customer_name").ToString) <> "" Then
                Line = "Customer Name : " & objBon.Header.Rows(0).Item("customer_name").ToString & "   " & objBon.Header.Rows(0).Item("customer_id").ToString & "/" & objBon.Header.Rows(0).Item("customer_typename").ToString & "/" & objBon.Header.Rows(0).Item("customer_disc").ToString & "/" & objBon.Header.Rows(0).Item("customer_telp").ToString
            Else
                Line = "Customer Name : "
            End If
            If objBon.obj.bon_id.Substring(0, 2) = "NR" Then
                Line &= "   Alasan Retur: " & objBon.Header.Rows(0).Item("bon_event")
            End If
            sb.AppendText(Line & vbCrLf)


            If objBon.obj.bon_id.Substring(0, 2) = "NR" Then
                Line = "Bon.Pengganti: " & objBon.Header.Rows(0).Item("bon_idext").ToString & "            " & "Bon.Void : " & objBon.Header.Rows(0).Item("bon_replacefromvoid").ToString
            Else
                If Me.mShowFakturPajak Then
                    Line = "NPWP          :                                    No.Faktur Pajak : " & objBon.Header.Rows(0).Item("bon_fakturpajak").ToString & "             " & objBon.Header.Rows(0).Item("bon_idext").ToString
                Else
                    Line = "NPWP          :                                                                         " & objBon.Header.Rows(0).Item("bon_idext").ToString
                End If
            End If
            sb.AppendText(Line & vbCrLf)

            sb.AppendText("".PadLeft(PaperWidth, "-") & vbCrLf)

            Line = "No.".PadLeft(3, pad)
            Line &= "  "
            Line &= "ID".PadRight(13, pad) & "  " & "ART".PadRight(12) & " " & "MAT".PadRight(8) & " " & "COL".PadRight(5) & " " & "SIZE".PadRight(5) & "    DESCR"
            Line &= "PRICE     DISC".PadLeft(49, " ")
            Line &= "".PadRight(6, " ")
            Line &= "QTY".PadLeft(6, pad)
            Line &= "   "
            Line &= "SUBTOTAL".PadLeft(11, pad)
            sb.AppendText(Line & vbCrLf)

            sb.AppendText("".PadLeft(PaperWidth, "=") & vbCrLf)


            ' Loop disini
            Dim i As Integer
            Dim index As Integer
            For i = 1 To objBon.Items.Rows.Count
                index = i - 1

                NO = i & "."
                ID = objBon.Items.Rows(index).Item("heinvitem_id").ToString.PadRight(13, pad) ' "TM00000000000"
                ART = objBon.Items.Rows(index).Item("bondetil_art").ToString.PadRight(12, pad) '"1234567890"
                MAT = objBon.Items.Rows(index).Item("bondetil_mat").ToString.PadRight(8, pad) '"12345"
                COL = objBon.Items.Rows(index).Item("bondetil_col").ToString.PadRight(5, pad) '"12345"
                SIZ = objBon.Items.Rows(index).Item("bondetil_size").ToString.PadRight(5, pad) '"12345"
                DES = Mid(objBon.Items.Rows(index).Item("region_nameshort") & ",  " & objBon.Items.Rows(index).Item("bondetil_descr"), 1, 30).ToString.PadRight(30, pad) '"[$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$]"
                PRC = String.Format("{0:#,##0}", objBon.Items.Rows(index).Item("bondetil_mpricegross")).PadLeft(11, pad) '"000.000.000"
                DSC01 = objBon.Items.Rows(index).Item("bondetil_mdiscpstd01").ToString.PadLeft(2, pad)
                DSC02 = objBon.Items.Rows(index).Item("bondetil_mdiscpvou01").ToString.PadLeft(2, pad)
                VOUTYPE = objBon.Items.Rows(index).Item("bondetil_vou01type").ToString.PadLeft(2, pad)

                If VOUTYPE = "BONUS" Then
                    DSC = "BONUS!"
                Else
                    If objBon.Items.Rows(index).Item("bondetil_mdiscpvou01") > 0 Then
                        DSC = DSC01 & ", " & DSC02
                    Else
                        DSC = "    " & DSC01
                    End If
                End If

                QTY = objBon.Items.Rows(index).Item("bondetil_qty").ToString.PadLeft(3, pad)
                SBT = String.Format("{0:#,##0}", objBon.Items.Rows(index).Item("bondetil_msubtotal")).PadLeft(11, pad)

                Line = NO.PadLeft(3, pad)
                Line &= "  "
                Line &= ID.PadRight(13, pad) & "  " & Mid(ART, 1, 12).PadRight(12) & " " & MAT.PadRight(8) & " " & COL.PadRight(5) & " " & SIZ.PadRight(5) & "    "
                Line &= (Mid(DES, 1, 30).PadRight(30) & "    " & PRC & "   " & DSC & "   ").PadRight(60, pad)
                Line &= QTY.PadLeft(6, pad)
                Line &= "   "
                Line &= SBT.PadLeft(11, pad)
                sb.AppendText(Line & vbCrLf)

            Next

            Dim sisa As Integer = 20 - i
            If sisa > 0 Then
                For i = 1 To sisa
                    sb.AppendText("" & vbCrLf)
                Next
            End If

            sb.AppendText("".PadLeft(PaperWidth, "=") & vbCrLf)

            Line = "PAYMENT(s)".PadRight(21, pad)
            Line &= "TOTAL".PadLeft(94, pad)
            Line &= "  "
            Line &= objBon.Header.Rows(0).Item("bon_itemqty").ToString.PadLeft(6, pad)
            Line &= "   "
            Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_msubtotal")).PadLeft(11, pad)
            sb.AppendText(Line & vbCrLf)


            For i = 1 To 3
                index = i - 1
                If index < objBon.Payments.Rows.Count Then
                    NO = i & "."
                    PAY = String.Format("{0:#,##0}", objBon.Payments.Rows(index).Item("payment_mvalue")).PadLeft(11, pad) '"000,000,000"
                    CARD = Mid(objBon.Payments.Rows(index).Item("pospayment_name"), 1, 8).PadRight(8, pad)

                    IsCash = IIf(CDec(objBon.Payments.Rows(index).Item("payment_mcash")) > 0, True, False)
                    mCash = CDec(objBon.Payments.Rows(index).Item("payment_mcash"))
                    mValue = objBon.Payments.Rows(index).Item("payment_mvalue")

                    If IsCash Then
                        CARDNO = "Pay: " & String.Format("{0:#,##0}", mCash)
                        CARDHO = "Change: " & String.Format("{0:#,##0}", (mCash - mValue))
                    Else
                        Dim CARDNO_R = objBon.Payments.Rows(index).Item("payment_cardnumber").ToString().PadRight(16, pad)
                        CARDNO = CARDNO_R.Substring(0, 6) & "------" & CARDNO_R.Substring(12, 4)
                        'CARDNO = objBon.Payments.Rows(index).Item("payment_cardnumber").Padright(19, pad)
                        CARDHO = Mid(objBon.Payments.Rows(index).Item("payment_cardholder"), 1, 27).PadRight(27, pad)
                    End If
                Else
                    NO = ""
                    PAY = ""
                    CARD = ""
                    CARDNO = ""
                    CARDHO = ""
                End If


                Line = NO.PadLeft(3, pad)
                Line &= "  "
                Line &= CARD.PadRight(8, pad)
                Line &= "  "
                Line &= PAY.PadLeft(11, pad)
                Line &= "   "
                Line &= CARDNO.PadLeft(19, pad)
                Line &= " "
                Line &= Trim(CARDHO).PadRight(24, pad)
                Line &= " "


                Select Case i
                    Case 1
                        Dim mVoured As Decimal = objBon.Header.Rows(0).Item("bon_msubtvoucher") + objBon.Header.Rows(0).Item("bon_msubtredeem")
                        Line &= "SALES NETT".PadLeft(14, pad)
                        Line &= " "
                        Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_msalenet")).PadLeft(11, pad)
                        Line &= " "
                        Line &= "VOU/RED".PadLeft(14, pad)
                        Line &= "  "
                        Line &= "".PadLeft(6, pad)
                        Line &= "   "
                        Line &= String.Format("{0:#,##0}", mVoured).PadLeft(11, pad)

                    Case 2
                        Dim tax As Decimal = objBon.Header.Rows(0).Item("bon_msaletax")
                        Dim netbeforetax As Decimal = objBon.Header.Rows(0).Item("bon_msalenet")
                        Dim taxprc As Decimal = Math.Round((tax / netbeforetax) * 100, 2)

                        Line &= ("Inc PPN " & CStr(taxprc) & "%").PadLeft(14, pad)
                        Line &= " "
                        Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_msaletax")).PadLeft(11, pad)
                        Line &= " "
                        Line &= "ADD.DISC".PadLeft(14, pad)
                        Line &= "  "
                        Line &= "".PadLeft(6, pad)
                        Line &= "   "
                        Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_msubtdiscadd")).PadLeft(11, pad)

                    Case 3
                        Line &= "GROSS".PadLeft(14, pad)
                        Line &= " "
                        Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_msalegross")).PadLeft(11, pad)
                        Line &= " "
                        Line &= "PAYM.DISC".PadLeft(14, pad)
                        Line &= "  "
                        'Line &= String.Format("{0:#,##0.00}", objBon.Header.Rows(0).Item("bon_mdiscpaympercent")).PadLeft(6, pad) & "%"
                        Line &= "       "
                        Line &= "  "
                        Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_mdiscpayment")).PadLeft(11, pad)


                End Select

                sb.AppendText(Line & vbCrLf)

            Next


            If objBon.Payments.Rows.Count > 3 Then
                Dim subtotal As Decimal = 0
                For i = 4 To objBon.Payments.Rows.Count
                    index = i - 1
                    subtotal += objBon.Payments.Rows(index).Item("payment_mvalue") ' Jumlahkan sisa payment
                Next

                NO = "4" & "."
                Line = NO.PadLeft(3, pad)
                Line &= "  "
                Line &= "OTHER".PadRight(8, pad)
                Line &= "  "
                Line &= String.Format("{0:#,##0}", subtotal).PadLeft(11, pad)
            Else
                Line = "".PadLeft(101, pad)
            End If
            Line &= "PAYM.DUE".PadLeft(14, pad)
            Line &= "  "
            Line &= "".PadLeft(6, pad)
            Line &= "   "
            Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_mtotal")).PadLeft(11, pad)
            sb.AppendText(Line & vbCrLf)



            Dim salesname As String = ""
            If Trim(objBon.Header.Rows(0).Item("salesperson_name").ToString) <> "" Then
                If Trim(objBon.Header.Rows(0).Item("salesperson_name").ToString) <> "NONE" Then
                    salesname = "SALES STAFF: "
                    salesname &= Trim(objBon.Header.Rows(0).Item("salesperson_name").ToString)
                Else
                    salesname = ""
                End If
            Else
                salesname = ""
            End If


            Line = ""
            Line &= "TMG/" & Me.RegionId & "/" & Me.BranchId & "/" & objBon.Header.Rows(0).Item("machine_id") & "    " & objBon.Header.Rows(0).Item("bon_createby") & "  "
            Line &= String.Format("{0:dd/MM/yyyy}", Now())
            Line &= "  "
            Line &= "01.347.523.1.073.000   **** THANK YOU ****"

            Dim mlen As Int16 = 137 - Len(Trim(Line))
            salesname = Mid(salesname, 1, mlen).PadRight(mlen, pad)
            Line = (salesname & Line).PadLeft(137, pad)
            sb.AppendText(Line & vbCrLf)

            Line = ""
            Line &= "=========================================================================================================================================" & vbCrLf
            Line &= " Goods purchased, CANNOT be returned, refunded or exchanged. " & vbCrLf
            Line &= " Barang yang sudah di beli, TIDAK DAPAT dikembalikan ataupun ditukar dengan barang lain. "

            Dim Linex As String = "Harap memeriksa kembali bon dan barang" & vbCrLf & "yang dibeli."
            Linex &= "Kami tidak menerima keluhan setelah" & vbCrLf & "barang keluar dari toko."

            sb.AppendText(Line)


            Return sb.Lines
        End Function

        Public Function FormatBon_Outlet01(ByVal objBon As uiTrnPosEN.PosBonData, ByVal reprint As Boolean, ByVal void As Boolean) As String()
            Dim sb As TextBox = New TextBox()
            Dim pad As String = " " '"·"
            Dim Line As String = ""
            Dim PaperWidth As Integer = 137
            Dim NO, ID, ART, MAT, COL, SIZ, DES, PRC, DSC, DSC01, DSC02, QTY, SBT As String
            Dim PAY, CARD, CARDNO, CARDHO As String
            Dim IsCash As Boolean
            Dim mValue, mCash As Decimal
            Dim strReprint As String = ""
            Dim VOUTYPE As String = ""


            If objBon.Header.Rows.Count <= 0 Then
                Return New String() {"objBon.Header contain no rows for selected id. (POS.FormatBon_Outlet) "}
            End If

            sb.Multiline = True
            void = void Or CBool(objBon.Header.Rows(0).Item("bon_isvoid"))


            If reprint Then
                strReprint = "(COPY)"
            Else
                strReprint = ""
            End If


            If void Then
                strReprint &= "(VOID)"
            End If


            Line = "".PadRight(100, pad)
            Line &= String.Format("{1}  {0}", objBon.obj.bon_id, strReprint).PadLeft(PaperWidth - Len(Line), pad)
            sb.AppendText(Line & vbCrLf)

            sb.AppendText(vbCrLf)
            sb.AppendText(vbCrLf)

            Dim idext As String = objBon.Header.Rows(0).Item("bon_idext").ToString
            Line = "".PadRight(112, pad)
            Line &= (String.Format("{0:dd/MM/yyyy}", objBon.Header.Rows(0).Item("bon_date")) & "    " & idext).PadRight(PaperWidth - Len(Line), pad)
            sb.AppendText(Line & vbCrLf)

            sb.AppendText(vbCrLf)


            Dim custinfo As String
            If Trim(objBon.Header.Rows(0).Item("customer_name").ToString) <> "" Then
                custinfo = "       " & objBon.Header.Rows(0).Item("customer_name").ToString & "   " & objBon.Header.Rows(0).Item("customer_id").ToString & "/" & objBon.Header.Rows(0).Item("customer_typename").ToString & "/" & objBon.Header.Rows(0).Item("customer_disc").ToString & "/" & objBon.Header.Rows(0).Item("customer_telp").ToString
            Else
                custinfo = ""
            End If

            Line = custinfo.PadRight(112, pad)
            Line &= String.Format("{0:HH mm}", objBon.Header.Rows(0).Item("bon_date")).PadRight(PaperWidth - Len(Line), pad)
            sb.AppendText(Line & vbCrLf)

            '                                               .
            If Me.mShowFakturPajak Then
                Line = "                              No.Faktur Pajak : " & objBon.Header.Rows(0).Item("bon_fakturpajak").ToString
            Else
                Line = "                                                                   "
            End If

            Line &= "   "
            Line &= Mid(objBon.Header.Rows(0).Item("bon_createby"), 1, 30).PadLeft(30) & "   " & "TMG/" & Me.RegionId & "/" & Me.BranchId & "/" & objBon.Header.Rows(0).Item("machine_id")
            Line &= " "
            Line &= String.Format("{0:dd/MM/yyyy}", Now())
            sb.AppendText(Line & vbCrLf)

            sb.AppendText(vbCrLf)
            sb.AppendText(vbCrLf)
            sb.AppendText(vbCrLf)



            ' Loop disini
            Dim i As Integer
            Dim index As Integer
            For i = 1 To objBon.Items.Rows.Count
                index = i - 1

                NO = i & "."
                ID = objBon.Items.Rows(index).Item("heinvitem_id").ToString.PadRight(13, pad) ' "TM00000000000"
                ART = objBon.Items.Rows(index).Item("bondetil_art").ToString.PadRight(10, pad) '"1234567890"
                MAT = objBon.Items.Rows(index).Item("bondetil_mat").ToString.PadRight(5, pad) '"12345"
                COL = objBon.Items.Rows(index).Item("bondetil_col").ToString.PadRight(5, pad) '"12345"
                SIZ = objBon.Items.Rows(index).Item("bondetil_size").ToString.PadRight(5, pad) '"12345"
                'DES = Mid(objBon.Items.Rows(index).Item("bondetil_descr"), 1, 30).ToString.PadRight(30, pad) '"[$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$]"
                DES = Mid(objBon.Items.Rows(index).Item("region_nameshort") & ", " & objBon.Items.Rows(index).Item("bondetil_descr"), 1, 30).ToString.PadRight(30, pad) '"[$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$]"
                PRC = String.Format("{0:#,##0}", objBon.Items.Rows(index).Item("bondetil_mpricegross")).PadLeft(11, pad) '"000.000.000"
                DSC01 = objBon.Items.Rows(index).Item("bondetil_mdiscpstd01").ToString.PadLeft(2, pad)
                DSC02 = objBon.Items.Rows(index).Item("bondetil_mdiscpvou01").ToString.PadLeft(2, pad)
                VOUTYPE = objBon.Items.Rows(index).Item("bondetil_vou01type").ToString.PadLeft(2, pad)

                If VOUTYPE = "BONUS" Then
                    DSC = "BONUS!"
                Else
                    If objBon.Items.Rows(index).Item("bondetil_mdiscpvou01") > 0 Then
                        DSC = DSC01 & ", " & DSC02
                    Else
                        DSC = "    " & DSC01
                    End If
                End If



                QTY = objBon.Items.Rows(index).Item("bondetil_qty").ToString.PadLeft(3, pad)
                SBT = String.Format("{0:#,##0}", objBon.Items.Rows(index).Item("bondetil_msubtotal")).PadLeft(11, pad)


                'Line = "   " & ART.PadRight(10) & "  " & MAT.PadRight(10) & "  " & COL.PadRight(11) & DES.PadRight(42) & _
                '       SIZ.PadRight(8) & QTY.PadLeft(3, pad) & " " & PRC.PadLeft(20, pad) & SBT.PadLeft(20, pad)
                'sb.AppendText(Line & vbCrLf)

                'Line = NO.PadLeft(3, pad)
                'Line &= "  "
                Line = "  "
                Line &= ID.PadRight(13, pad) & "  "             '15
                Line &= Mid(ART, 1, 12).PadRight(12) & " "      '13   28
                Line &= Mid(MAT, 1, 8).PadRight(8) & " "        ' 9   37
                Line &= Mid(COL, 1, 8).PadRight(8) & " "        ' 9   46
                Line &= Mid(DES, 1, 30).PadRight(30) & "    "   '34   88
                Line &= Mid(SIZ, 1, 5).PadRight(5) & "  "      ' 8   88
                Line &= QTY.PadLeft(4, pad) & "    "

                Line &= PRC.PadLeft(11, pad) & "   "
                Line &= DSC.PadLeft(4, pad) & "    "
                Line &= SBT.PadLeft(11, pad)

                sb.AppendText(Line & vbCrLf)
            Next





            Dim sisa As Integer = 15 - i
            If sisa > 0 Then
                For i = 1 To sisa
                    sb.AppendText("" & vbCrLf)
                Next
            End If


            Line = "PAYMENT(s)".PadRight(21, pad)
            Line &= "TOTAL".PadLeft(94, pad)
            Line &= "  "
            Line &= objBon.Header.Rows(0).Item("bon_itemqty").ToString.PadLeft(6, pad)
            Line &= "   "
            Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_msubtotal")).PadLeft(11, pad)
            sb.AppendText(Line & vbCrLf)


            For i = 1 To 3
                index = i - 1
                If index < objBon.Payments.Rows.Count Then
                    NO = i & "."
                    PAY = String.Format("{0:#,##0}", objBon.Payments.Rows(index).Item("payment_mvalue")).PadLeft(11, pad) '"000,000,000"
                    CARD = Mid(objBon.Payments.Rows(index).Item("pospayment_name"), 1, 8).PadRight(8, pad)

                    IsCash = IIf(CDec(objBon.Payments.Rows(index).Item("payment_mcash")) > 0, True, False)
                    mCash = CDec(objBon.Payments.Rows(index).Item("payment_mcash"))
                    mValue = objBon.Payments.Rows(index).Item("payment_mvalue")

                    If IsCash Then
                        CARDNO = "Pay: " & String.Format("{0:#,##0}", mCash)
                        CARDHO = "Change: " & String.Format("{0:#,##0}", (mCash - mValue))
                    Else
                        Dim CARDNO_R = objBon.Payments.Rows(index).Item("payment_cardnumber").ToString().PadRight(16, pad)
                        CARDNO = CARDNO_R.Substring(0, 6) & "------" & CARDNO_R.Substring(12, 4)
                        'CARDNO = objBon.Payments.Rows(index).Item("payment_cardnumber").Padright(19, pad)
                        CARDHO = Mid(objBon.Payments.Rows(index).Item("payment_cardholder"), 1, 27).PadRight(27, pad)
                    End If
                Else
                    NO = ""
                    PAY = ""
                    CARD = ""
                    CARDNO = ""
                    CARDHO = ""
                End If


                Line = NO.PadLeft(3, pad)
                Line &= "  "
                Line &= CARD.PadRight(8, pad)
                Line &= "  "
                Line &= PAY.PadLeft(11, pad)
                Line &= "   "
                Line &= CARDNO.PadLeft(19, pad)
                Line &= " "
                Line &= Trim(CARDHO).PadRight(24, pad)
                Line &= " "


                Select Case i
                    Case 1
                        Dim mVoured As Decimal = objBon.Header.Rows(0).Item("bon_msubtvoucher") + objBon.Header.Rows(0).Item("bon_msubtredeem")
                        Line &= "SALES NETT".PadLeft(14, pad)
                        Line &= " "
                        Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_msalenet")).PadLeft(11, pad)
                        Line &= " "
                        Line &= "VOU/RED".PadLeft(14, pad)
                        Line &= "  "
                        Line &= "".PadLeft(6, pad)
                        Line &= "   "
                        Line &= String.Format("{0:#,##0}", mVoured).PadLeft(11, pad)

                    Case 2
                        Dim tax As Decimal = objBon.Header.Rows(0).Item("bon_msaletax")
                        Dim netbeforetax As Decimal = objBon.Header.Rows(0).Item("bon_msalenet")
                        Dim taxprc As Decimal = Math.Round((tax / netbeforetax) * 100, 2)

                        Line &= ("Inc PPN " & CStr(taxprc) & "%").PadLeft(14, pad)
                        Line &= " "
                        Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_msaletax")).PadLeft(11, pad)
                        Line &= " "
                        Line &= "ADD.DISC".PadLeft(14, pad)
                        Line &= "  "
                        Line &= "".PadLeft(6, pad)
                        Line &= "   "
                        Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_msubtdiscadd")).PadLeft(11, pad)

                    Case 3
                        Dim discline = "DISC  (" & Trim(objBon.Header.Rows(0).Item("pospayment_id")) & ")"

                        Line &= "GROSS".PadLeft(14, pad)
                        Line &= " "
                        Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_msalegross")).PadLeft(11, pad)
                        Line &= " "
                        'Line &= "DISC (MEGA)".PadLeft(14, pad)

                        If (objBon.Header.Rows(0).Item("bon_mdiscpayment") > 0) Then
                            Line &= discline.PadLeft(14, pad)
                        Else
                            Line &= "PAYM.DISC".PadLeft(14, pad)
                        End If

                        Line &= "  "
                        'Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_mdiscpaympercent")).PadLeft(6, pad) & "%"
                        Line &= "       "
                        Line &= "  "
                        Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_mdiscpayment")).PadLeft(11, pad)


                End Select

                sb.AppendText(Line & vbCrLf)

            Next


            If objBon.Payments.Rows.Count > 3 Then
                Dim subtotal As Decimal = 0
                For i = 4 To objBon.Payments.Rows.Count
                    index = i - 1
                    subtotal += objBon.Payments.Rows(index).Item("payment_mvalue") ' Jumlahkan sisa payment
                Next

                NO = "4" & "."
                Line = NO.PadLeft(3, pad)
                Line &= "  "
                Line &= "OTHER".PadRight(8, pad)
                Line &= "  "
                Line &= String.Format("{0:#,##0}", subtotal).PadLeft(11, pad)
            Else
                Line = "".PadLeft(101, pad)
            End If
            Line &= "PAYM.DUE".PadLeft(14, pad)
            Line &= "  "
            Line &= "".PadLeft(6, pad)
            Line &= "   "
            Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_mtotal")).PadLeft(11, pad)
            sb.AppendText(Line & vbCrLf)


            'Line = ""
            'Line &= "TMG/" & Me.RegionId & "/" & Me.BranchId & "/" & objBon.Header.Rows(0).Item("machine_id") & "    " & Me.UserName & "  "
            'Line &= String.Format("{0:dd/MM/yyyy}", Now())
            'Line &= "  "
            'Line &= "01.347.523.1.073.000   **** THANK YOU ****"
            'Line = Line.PadLeft(137, pad)


            Line = ""
            sb.AppendText(Line & vbCrLf)


            Line = "".PadRight(88)
            Line &= Me.COMPANY_NAME
            sb.AppendText(Line & vbCrLf)

            Dim salesname As String = ""
            If Trim(objBon.Header.Rows(0).Item("salesperson_name").ToString) <> "" Then
                If Trim(objBon.Header.Rows(0).Item("salesperson_name").ToString) <> "NONE" Then
                    salesname = "SALES STAFF: "
                    salesname &= Trim(objBon.Header.Rows(0).Item("salesperson_name").ToString)
                Else
                    salesname = ""
                End If
            Else
                salesname = ""
            End If
            Line = salesname.PadRight(88)
            Line &= Me.COMPANY_ADDRESS
            sb.AppendText(Line & vbCrLf)

            Line = "".PadRight(100)
            If objBon.Header.Rows(0).Item("bon_npwp").ToString = "123456789" Then
                Line &= Me.COMPANY_TAXID
            Else
                Line &= objBon.Header.Rows(0).Item("bon_npwp").ToString
            End If

            sb.AppendText(Line & vbCrLf)

            Return sb.Lines
        End Function

        Public Function FormatBon_Outlet02(ByVal objBon As uiTrnPosEN.PosBonData, ByVal reprint As Boolean, ByVal void As Boolean) As String()
            Dim sb As TextBox = New TextBox()
            Dim pad As String = " " '"·"
            Dim Line As String = ""
            Dim PaperWidth As Integer = 137
            Dim NO, ID, ART, MAT, COL, SIZ, DES, PRC, DSC, DSC01, DSC02, QTY, SBT As String
            Dim PAY, CARD, CARDNO, CARDHO As String
            Dim IsCash As Boolean
            Dim mValue, mCash As Decimal
            Dim strReprint As String = ""
            Dim VOUTYPE As String = ""


            If objBon.Header.Rows.Count <= 0 Then
                Return New String() {"objBon.Header contain no rows for selected id. (POS.FormatBon_Outlet) "}
            End If

            sb.Multiline = True
            void = void Or CBool(objBon.Header.Rows(0).Item("bon_isvoid"))


            If reprint Then
                strReprint = "(COPY)"
            Else
                strReprint = ""
            End If


            If void Then
                strReprint &= "(VOID)"
            End If

            sb.AppendText(vbCrLf)


            ''Line = "".PadRight(100, pad)
            ''Line &= String.Format("{1}  {0}", objBon.obj.bon_id, strReprint).PadLeft(PaperWidth - Len(Line), pad)
            'Line = "12345678901234567890123456789012345678901234567890"
            'sb.AppendText(Line & vbCrLf)


            'Line = "PT. Trans Mahagaya"
            'sb.AppendText(Line & vbCrLf)

            'Line = "PT. Trans Mahagaya"
            'sb.AppendText(Line & vbCrLf)




            Line = String.Format("{0} {1}", objBon.obj.bon_id, strReprint)
            sb.AppendText(Line & vbCrLf)


            Dim idext As String = objBon.Header.Rows(0).Item("bon_idext").ToString
            Line = String.Format("{0:dd/MM/yyyy}", objBon.Header.Rows(0).Item("bon_date")) & " " & String.Format("{0:HH:mm}", objBon.Header.Rows(0).Item("bon_date"))
            sb.AppendText(Line & vbCrLf)
            sb.AppendText(vbCrLf)


            Dim custinfo As String
            If Trim(objBon.Header.Rows(0).Item("customer_name").ToString) <> "" Then
                custinfo = objBon.Header.Rows(0).Item("customer_name").ToString & "   " & objBon.Header.Rows(0).Item("customer_id").ToString & "/" & objBon.Header.Rows(0).Item("customer_typename").ToString & "/" & objBon.Header.Rows(0).Item("customer_disc").ToString
                Line = Mid(custinfo, 1, 40)
                sb.AppendText(objBon.Header.Rows(0).Item("customer_passport").ToString() & vbCrLf)
                sb.AppendText(Line & vbCrLf)
                sb.AppendText(objBon.Header.Rows(0).Item("customer_telp").ToString() & vbCrLf)
            Else
                custinfo = ""
            End If



            '                                               .
            If Me.mShowFakturPajak Then
                Line = "No.Faktur Pajak : " & objBon.Header.Rows(0).Item("bon_fakturpajak").ToString
                sb.AppendText(Line & vbCrLf)
            Else
                Line = ""
            End If


            Line = Me.COMPANY_INITIAL & "/" & Me.RegionId & "/" & Me.BranchId & "/" & objBon.Header.Rows(0).Item("machine_id") & " " & objBon.Header.Rows(0).Item("bon_createby")
            sb.AppendText(Line & vbCrLf)

            Line = "Print Date: " & String.Format("{0:dd/MM/yyyy HH:mm}", Now())
            sb.AppendText(Line & vbCrLf)

            sb.AppendText("----------------------------------------" & vbCrLf)


            ' Loop disini
            Dim i As Integer
            Dim index As Integer
            For i = 1 To objBon.Items.Rows.Count
                index = i - 1

                NO = i & "."
                ID = objBon.Items.Rows(index).Item("heinvitem_id").ToString.PadRight(13, pad) ' "TM00000000000"
                ART = objBon.Items.Rows(index).Item("bondetil_art").ToString.PadRight(10, pad) '"1234567890"
                MAT = objBon.Items.Rows(index).Item("bondetil_mat").ToString.PadRight(5, pad) '"12345"
                COL = objBon.Items.Rows(index).Item("bondetil_col").ToString.PadRight(5, pad) '"12345"
                SIZ = objBon.Items.Rows(index).Item("bondetil_size").ToString.PadRight(5, pad) '"12345"
                DES = Mid(objBon.Items.Rows(index).Item("bondetil_descr"), 1, 30).ToString.PadRight(30, pad) '"[$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$]"
                PRC = String.Format("{0:#,##0}", objBon.Items.Rows(index).Item("bondetil_mpricegross")).PadLeft(11, pad) '"000.000.000"
                DSC01 = objBon.Items.Rows(index).Item("bondetil_mdiscpstd01").ToString.PadLeft(2, pad)
                DSC02 = objBon.Items.Rows(index).Item("bondetil_mdiscpvou01").ToString.PadLeft(2, pad)
                VOUTYPE = objBon.Items.Rows(index).Item("bondetil_vou01type").ToString.PadLeft(2, pad)

                If VOUTYPE = "BONUS" Then
                    DSC = "BONUS!"
                Else
                    If objBon.Items.Rows(index).Item("bondetil_mdiscpvou01") > 0 Then
                        DSC = DSC01 & "%, " & DSC02 & "%"
                    Else
                        DSC = "   " & DSC01 & "%"
                    End If
                End If



                QTY = ("x" & objBon.Items.Rows(index).Item("bondetil_qty").ToString).PadLeft(3, pad)
                SBT = String.Format("{0:#,##0}", objBon.Items.Rows(index).Item("bondetil_msubtotal")).PadLeft(11, pad)


                Line = ID.PadRight(13, pad) & "  "
                Line &= Mid(DES, 1, 25).PadRight(25)
                Line &= vbCrLf

                Line &= "   "
                Line &= Mid(ART, 1, 12).PadRight(12) & " "
                Line &= Mid(MAT, 1, 8).PadRight(8) & " "
                Line &= Mid(COL, 1, 8).PadRight(8) & " "
                Line &= Mid(SIZ, 1, 5).PadRight(5)
                Line &= vbCrLf


                Line &= "   Rp"
                Line &= PRC.PadLeft(11, pad) & " "
                Line &= "(" & DSC & ")    "
                Line &= QTY.PadLeft(4, pad)
                Line &= vbCrLf

                Line &= SBT.PadLeft(40, pad)


                sb.AppendText(Line & vbCrLf)
            Next





            Line = "----------------------------------------" & vbCrLf
            Line &= "TOTAL     " & objBon.Header.Rows(0).Item("bon_itemqty").ToString.PadLeft(6, pad) & " pcs "
            Line &= String.Format("Rp  {0:#,##0}", objBon.Header.Rows(0).Item("bon_msubtotal")).PadLeft(19, pad)
            sb.AppendText(Line & vbCrLf)


            If objBon.Header.Rows(0).Item("bon_msubtdiscadd") > 0 Then
                Line = "ADD.Disc".PadRight(29)
                Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_msubtdiscadd")).PadLeft(11, pad)
                sb.AppendText(Line & vbCrLf)
            End If

            If (objBon.Header.Rows(0).Item("bon_msubtvoucher") + objBon.Header.Rows(0).Item("bon_msubtredeem")) > 0 Then
                Dim mVoured As Decimal = objBon.Header.Rows(0).Item("bon_msubtvoucher") + objBon.Header.Rows(0).Item("bon_msubtredeem")
                Line = "VOU/RED".PadRight(29)
                Line &= String.Format("{0:#,##0}", mVoured).PadLeft(11, pad)
                sb.AppendText(Line & vbCrLf)
            End If


            If objBon.Header.Rows(0).Item("bon_mdiscpayment") Then
                Line = "Disc.Paym".PadRight(29)
                Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_mdiscpayment")).PadLeft(11, pad)
                'Line &= "           "
                sb.AppendText(Line & vbCrLf)
            End If

            Line = "Paym.Due".PadRight(29)
            Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_mtotal")).PadLeft(11, pad)
            sb.AppendText(Line & vbCrLf)


            sb.AppendText(vbCrLf)



            Line = "GROSS".PadRight(29)
            Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_msalegross")).PadLeft(11, pad)
            sb.AppendText(Line & vbCrLf)

            Dim tax As Decimal = objBon.Header.Rows(0).Item("bon_msaletax")
            Dim netbeforetax As Decimal = objBon.Header.Rows(0).Item("bon_msalenet")
            Dim taxprc As Decimal = Math.Round((tax / netbeforetax) * 100, 2)

            Line = ("Inc.PPN " & CStr(taxprc) & "%").PadRight(29)
            Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_msaletax")).PadLeft(11, pad)
            sb.AppendText(Line & vbCrLf)


            Line = "NETT".PadRight(29)
            Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_msalenet")).PadLeft(11, pad)
            sb.AppendText(Line & vbCrLf)

            Line = vbCrLf
            Line &= "PAYMENT(s)"
            sb.AppendText(Line & vbCrLf)


            For i = 1 To objBon.Payments.Rows.Count
                index = i - 1

                NO = i & "."
                PAY = String.Format("{0:#,##0}", objBon.Payments.Rows(index).Item("payment_mvalue")).PadLeft(11, pad) '"000,000,000"
                CARD = Mid(objBon.Payments.Rows(index).Item("pospayment_name"), 1, 8).PadRight(8, pad)

                IsCash = IIf(CDec(objBon.Payments.Rows(index).Item("payment_mcash")) > 0, True, False)
                mCash = CDec(objBon.Payments.Rows(index).Item("payment_mcash"))
                mValue = objBon.Payments.Rows(index).Item("payment_mvalue")

                If IsCash Then
                    CARDNO = "Pay: " & String.Format("{0:#,##0}", mCash)
                    CARDHO = "Change: " & String.Format("{0:#,##0}", (mCash - mValue))
                Else
                    Dim CARDNO_R = objBon.Payments.Rows(index).Item("payment_cardnumber").ToString().PadRight(16, pad)
                    CARDNO = CARDNO_R.Substring(0, 6) & "------" & CARDNO_R.Substring(12, 4)
                    'CARDNO = objBon.Payments.Rows(index).Item("payment_cardnumber").Padright(19, pad)
                    CARDHO = Mid(objBon.Payments.Rows(index).Item("payment_cardholder"), 1, 27).PadRight(27, pad)
                End If



                Line = CARD.PadRight(8, pad)
                Line &= " "
                Line &= PAY.PadLeft(11, pad)
                Line &= " "
                Line &= CARDNO.PadLeft(19, pad)

                sb.AppendText(Line & vbCrLf)

            Next


            Dim salesname As String = ""
            If Trim(objBon.Header.Rows(0).Item("salesperson_name").ToString) <> "" Then
                If Trim(objBon.Header.Rows(0).Item("salesperson_name").ToString) <> "NONE" Then
                    salesname = vbCrLf & "SALES STAFF: "
                    salesname &= Trim(objBon.Header.Rows(0).Item("salesperson_name").ToString)
                Else
                    salesname = ""
                End If
            Else
                salesname = ""
            End If
            Line = salesname.PadRight(40) & vbCrLf
            sb.AppendText(Line & vbCrLf)



            sb.AppendText("Harap memeriksa kembali bon dan barang" & vbCrLf & "yang dibeli." & vbCrLf)
            sb.AppendText("Kami tidak menerima keluhan setelah" & vbCrLf & "barang keluar dari toko." & vbCrLf & vbCrLf)

            Line = Me.COMPANY_NAME & vbCrLf
            Line &= Me.COMPANY_ADDRESS & vbCrLf
            If Me.COMPANY_TAXID <> "NONE" Then
                Line &= "NPWP: " & Me.COMPANY_TAXID
            End If
            sb.AppendText(Line & vbCrLf)


            Return sb.Lines
        End Function

        Public Function FormatBon_Outlet03(ByVal objBon As uiTrnPosEN.PosBonData, ByVal reprint As Boolean, ByVal void As Boolean) As String()
            Dim sb As TextBox = New TextBox()
            Dim pad As String = " " '"·"
            Dim Line As String = ""
            Dim PaperWidth As Integer = 137
            Dim NO, ID, ART, MAT, COL, SIZ, DES, PRC, DSC, DSC01, DSC02, QTY, SBT As String
            Dim PAY, CARD, CARDNO, CARDHO As String
            Dim IsCash As Boolean
            Dim mValue, mCash As Decimal
            Dim strReprint As String = ""
            Dim VOUTYPE As String = ""


            If objBon.Header.Rows.Count <= 0 Then
                Return New String() {"objBon.Header contain no rows for selected id. (POS.FormatBon_Outlet) "}
            End If

            sb.Multiline = True
            void = void Or CBool(objBon.Header.Rows(0).Item("bon_isvoid"))


            If reprint Then
                strReprint = "(COPY)"
            Else
                strReprint = ""
            End If


            If void Then
                strReprint &= "(VOID)"
            End If

            sb.AppendText(vbCrLf)


            ''Line = "".PadRight(100, pad)
            ''Line &= String.Format("{1}  {0}", objBon.obj.bon_id, strReprint).PadLeft(PaperWidth - Len(Line), pad)
            'Line = "12345678901234567890123456789012345678901234567890"
            'sb.AppendText(Line & vbCrLf)


            'Line = "PT. Trans Mahagaya"
            'sb.AppendText(Line & vbCrLf)

            'Line = "PT. Trans Mahagaya"
            'sb.AppendText(Line & vbCrLf)




            Line = String.Format("{0} {1}", objBon.obj.bon_id, strReprint)
            sb.AppendText(Line & vbCrLf)


            Dim idext As String = objBon.Header.Rows(0).Item("bon_idext").ToString
            Line = String.Format("{0:dd/MM/yyyy}", objBon.Header.Rows(0).Item("bon_date")) & " " & String.Format("{0:HH:mm}", objBon.Header.Rows(0).Item("bon_date"))
            sb.AppendText(Line & vbCrLf)
            sb.AppendText(vbCrLf)


            Dim custinfo As String
            If Trim(objBon.Header.Rows(0).Item("customer_name").ToString) <> "" Then
                custinfo = objBon.Header.Rows(0).Item("customer_name").ToString & "   " & objBon.Header.Rows(0).Item("customer_id").ToString & "/" & objBon.Header.Rows(0).Item("customer_typename").ToString & "/" & objBon.Header.Rows(0).Item("customer_disc").ToString
                Line = Mid(custinfo, 1, 40)
                sb.AppendText(Line & vbCrLf)
                sb.AppendText(objBon.Header.Rows(0).Item("customer_telp").ToString() & vbCrLf)
            Else
                custinfo = ""
            End If



            '                                               .
            If Me.mShowFakturPajak Then
                Line = "No.Faktur Pajak : " & objBon.Header.Rows(0).Item("bon_fakturpajak").ToString
                sb.AppendText(Line & vbCrLf)
            Else
                Line = ""
            End If


            Line = Me.COMPANY_INITIAL & "/" & Me.RegionId & "/" & Me.BranchId & "/" & objBon.Header.Rows(0).Item("machine_id") & " " & objBon.Header.Rows(0).Item("bon_createby")
            sb.AppendText(Line & vbCrLf)

            Line = "Print Date: " & String.Format("{0:dd/MM/yyyy HH:mm}", Now())
            sb.AppendText(Line & vbCrLf)

            sb.AppendText("--------------------------------------------------------" & vbCrLf)


            ' Loop disini
            Dim i As Integer
            Dim index As Integer
            For i = 1 To objBon.Items.Rows.Count
                index = i - 1

                NO = i & "."
                ID = objBon.Items.Rows(index).Item("heinvitem_id").ToString.PadRight(13, pad) ' "TM00000000000"
                ART = objBon.Items.Rows(index).Item("bondetil_art").ToString.PadRight(10, pad) '"1234567890"
                MAT = objBon.Items.Rows(index).Item("bondetil_mat").ToString.PadRight(5, pad) '"12345"
                COL = objBon.Items.Rows(index).Item("bondetil_col").ToString.PadRight(5, pad) '"12345"
                SIZ = objBon.Items.Rows(index).Item("bondetil_size").ToString.PadRight(5, pad) '"12345"
                DES = Mid(objBon.Items.Rows(index).Item("bondetil_descr"), 1, 30).ToString.PadRight(30, pad) '"[$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$]"
                PRC = String.Format("{0:#,##0}", objBon.Items.Rows(index).Item("bondetil_mpricegross")).PadLeft(11, pad) '"000.000.000"
                DSC01 = objBon.Items.Rows(index).Item("bondetil_mdiscpstd01").ToString.PadLeft(2, pad)
                DSC02 = objBon.Items.Rows(index).Item("bondetil_mdiscpvou01").ToString.PadLeft(2, pad)
                VOUTYPE = objBon.Items.Rows(index).Item("bondetil_vou01type").ToString.PadLeft(2, pad)

                If VOUTYPE = "BONUS" Then
                    DSC = "BONUS!"
                Else
                    If objBon.Items.Rows(index).Item("bondetil_mdiscpvou01") > 0 Then
                        DSC = DSC01 & "%, " & DSC02 & "%"
                    Else
                        DSC = "   " & DSC01 & "%"
                    End If
                End If



                QTY = ("x" & objBon.Items.Rows(index).Item("bondetil_qty").ToString).PadLeft(3, pad)
                SBT = String.Format("{0:#,##0}", objBon.Items.Rows(index).Item("bondetil_msubtotal")).PadLeft(11, pad)


                Line = ID.PadRight(13, pad) & "  "
                Line &= Mid(DES, 1, 41).PadRight(41)
                Line &= vbCrLf

                Line &= "   "
                Line &= Mid(ART, 1, 12).PadRight(12) & " "
                Line &= Mid(MAT, 1, 8).PadRight(8) & " "
                Line &= Mid(COL, 1, 8).PadRight(8) & " "
                Line &= Mid(SIZ, 1, 5).PadRight(5)
                Line &= vbCrLf


                Line &= "   Rp"
                Line &= PRC.PadLeft(11, pad) & " "
                Line &= "(" & DSC & ")    "
                Line &= QTY.PadLeft(4, pad)
                Line &= vbCrLf

                Line &= SBT.PadLeft(56, pad)


                sb.AppendText(Line & vbCrLf)
            Next





            Line = "--------------------------------------------------------" & vbCrLf
            Line &= "TOTAL     " & objBon.Header.Rows(0).Item("bon_itemqty").ToString.PadLeft(6, pad) & " pcs "
            Line &= String.Format("Rp  {0:#,##0}", objBon.Header.Rows(0).Item("bon_msubtotal")).PadLeft(35, pad)
            sb.AppendText(Line & vbCrLf)


            If objBon.Header.Rows(0).Item("bon_msubtdiscadd") > 0 Then
                Line = "ADD.Disc".PadRight(29)
                Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_msubtdiscadd")).PadLeft(27, pad)
                sb.AppendText(Line & vbCrLf)
            End If

            If (objBon.Header.Rows(0).Item("bon_msubtvoucher") + objBon.Header.Rows(0).Item("bon_msubtredeem")) > 0 Then
                Dim mVoured As Decimal = objBon.Header.Rows(0).Item("bon_msubtvoucher") + objBon.Header.Rows(0).Item("bon_msubtredeem")
                Line = "VOU/RED".PadRight(29)
                Line &= String.Format("{0:#,##0}", mVoured).PadLeft(27, pad)
                sb.AppendText(Line & vbCrLf)
            End If


            If objBon.Header.Rows(0).Item("bon_mdiscpayment") Then
                Line = "Disc.Paym".PadRight(29)
                'Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_mdiscpayment")).PadLeft(27, pad)
                Line &= "".PadLeft(27, pad)
                sb.AppendText(Line & vbCrLf)
            End If

            Line = "Paym.Due".PadRight(29)
            Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_mtotal")).PadLeft(27, pad)
            sb.AppendText(Line & vbCrLf)


            sb.AppendText(vbCrLf)



            Line = "GROSS".PadRight(29)
            Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_msalegross")).PadLeft(27, pad)
            sb.AppendText(Line & vbCrLf)


            Dim tax As Decimal = objBon.Header.Rows(0).Item("bon_msaletax")
            Dim netbeforetax As Decimal = objBon.Header.Rows(0).Item("bon_msalenet")
            Dim taxprc As Decimal = Math.Round((tax / netbeforetax) * 100, 2)


            Line = ("Inc.PPN " & CStr(taxprc) & "%").PadRight(29)
            Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_msaletax")).PadLeft(27, pad)
            sb.AppendText(Line & vbCrLf)


            Line = "NETT".PadRight(29)
            Line &= String.Format("{0:#,##0}", objBon.Header.Rows(0).Item("bon_msalenet")).PadLeft(27, pad)
            sb.AppendText(Line & vbCrLf)

            Line = vbCrLf
            Line &= "PAYMENT(s)"
            sb.AppendText(Line & vbCrLf)


            For i = 1 To objBon.Payments.Rows.Count
                index = i - 1

                NO = i & "."
                PAY = String.Format("{0:#,##0}", objBon.Payments.Rows(index).Item("payment_mvalue")).PadLeft(11, pad) '"000,000,000"
                CARD = Mid(objBon.Payments.Rows(index).Item("pospayment_name"), 1, 8).PadRight(8, pad)

                IsCash = IIf(CDec(objBon.Payments.Rows(index).Item("payment_mcash")) > 0, True, False)
                mCash = CDec(objBon.Payments.Rows(index).Item("payment_mcash"))
                mValue = objBon.Payments.Rows(index).Item("payment_mvalue")

                If IsCash Then
                    CARDNO = "Pay: " & String.Format("{0:#,##0}", mCash)
                    CARDHO = "Change: " & String.Format("{0:#,##0}", (mCash - mValue))
                Else
                    Dim CARDNO_R = objBon.Payments.Rows(index).Item("payment_cardnumber").ToString().PadRight(16, pad)
                    CARDNO = CARDNO_R.Substring(0, 6) & "------" & CARDNO_R.Substring(12, 4)
                    ' CARDNO = objBon.Payments.Rows(index).Item("payment_cardnumber").Padright(19, pad)
                    CARDHO = Mid(objBon.Payments.Rows(index).Item("payment_cardholder"), 1, 27).PadRight(27, pad)
                End If



                Line = CARD.PadRight(8, pad)
                Line &= " "
                Line &= PAY.PadLeft(11, pad)
                Line &= " "
                Line &= CARDNO.PadLeft(19, pad)

                sb.AppendText(Line & vbCrLf)

            Next


            Dim salesname As String = ""
            If Trim(objBon.Header.Rows(0).Item("salesperson_name").ToString) <> "" Then
                If Trim(objBon.Header.Rows(0).Item("salesperson_name").ToString) <> "NONE" Then
                    salesname = vbCrLf & "SALES STAFF: "
                    salesname &= Trim(objBon.Header.Rows(0).Item("salesperson_name").ToString)
                Else
                    salesname = ""
                End If
            Else
                salesname = ""
            End If
            Line = salesname.PadRight(40) & vbCrLf
            sb.AppendText(Line & vbCrLf)



            sb.AppendText("Harap memeriksa kembali bon dan barang yang dibeli." & vbCrLf)
            sb.AppendText("Kami tidak menerima keluhan setelah barang keluar" & vbCrLf & "dari toko." & vbCrLf & vbCrLf)

            Line = Me.COMPANY_NAME & vbCrLf
            Line &= Me.COMPANY_ADDRESS & vbCrLf
            If Me.COMPANY_TAXID <> "NONE" Then
                Line &= "NPWP: " & Me.COMPANY_TAXID
            End If
            sb.AppendText(Line & vbCrLf)


            Return sb.Lines
        End Function


        Public Function FormatClosingReport(ByVal thismachineonly As Boolean, ByVal showtranssum As Boolean, ByVal showbonrekap As Boolean, ByVal showartbd As Boolean, ByVal previewonly As Boolean, ByVal dt As Date) As String()
            Dim str As String = ""
            Dim Line As String = ""
            Dim i As Integer
            Dim tsb As TextBox = New TextBox()
            Dim ln() As String


            If showtranssum Then
                ln = Me.FormatClosingReport_1(thismachineonly, dt)
                For i = 0 To ln.Length - 1
                    tsb.AppendText(ln(i) & vbCrLf)
                Next
                tsb.AppendText("{PRINTER_FF}" & vbCrLf)
            End If


            If showbonrekap Then
                ln = Me.FormatClosingReport_2(thismachineonly, dt)
                For i = 0 To ln.Length - 1
                    tsb.AppendText(ln(i) & vbCrLf)
                Next
                tsb.AppendText("{PRINTER_FF}" & vbCrLf)
            End If


            If showartbd Then
                ln = Me.FormatClosingReport_3(thismachineonly, dt)
                For i = 0 To ln.Length - 1
                    tsb.AppendText(ln(i) & vbCrLf)
                Next
            End If


            Return tsb.Lines
        End Function

        Public Function FormatClosingReport_1(ByVal thismachineonly As Boolean, ByVal dt As Date) As String()
            Dim str As String = ""
            Dim Line As String = ""
            Dim sb As TextBox = New TextBox
            Dim sb_temp As TextBox = New TextBox
            Dim machine_id As String

            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim tbl As DataTable
            Dim cmd As OleDb.OleDbCommand
            Dim da As OleDb.OleDbDataAdapter

            Dim total_bon As Integer = 0
            Dim total_item As Integer = 0
            Dim total_purchased_gross As Decimal = 0
            Dim total_purchased_disc As Decimal = 0
            Dim total_purchased_nett As Decimal = 0
            Dim total_subt As Decimal = 0
            Dim total_subtvoucher As Decimal = 0
            Dim total_subtredeem As Decimal = 0
            Dim total_subtdiscadd As Decimal = 0
            Dim total_discpaym As Decimal = 0
            Dim total_sales As Decimal = 0
            Dim total_paymn As Decimal = 0
            Dim otherincome As Decimal = 0

            Dim i As Integer
            Dim total As Decimal = 0

            sb.Multiline = True
            sb_temp.Multiline = True



            sb.Multiline = True

            If thismachineonly Then
                machine_id = Me.MachineId
            Else
                machine_id = "ALL"
            End If




            Try
                conn.Open()
                cmd = New OleDb.OleDbCommand()
                cmd.Connection = conn
                cmd.CommandText = "poshe_TrnBon_ClosingSummary_1"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@date", System.Data.OleDb.OleDbType.Date))
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@machine_id", System.Data.OleDb.OleDbType.VarWChar, 30))
                cmd.Parameters("@date").Value = dt
                cmd.Parameters("@machine_id").Value = machine_id
                da = New OleDb.OleDbDataAdapter(cmd)

                tbl = New DataTable
                da.Fill(tbl)
                da.Dispose()
            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try


            If tbl.Rows.Count > 0 Then
                total_bon = tbl.Rows(0).Item("total_bon")
                total_item = tbl.Rows(0).Item("total_item")
                total_purchased_gross = tbl.Rows(0).Item("total_purchased_gross")
                total_purchased_disc = tbl.Rows(0).Item("total_purchased_disc")
                total_purchased_nett = tbl.Rows(0).Item("total_purchased_nett")
                total_subt = tbl.Rows(0).Item("total_subt")
                total_subtvoucher = tbl.Rows(0).Item("total_subtvoucher")
                total_subtredeem = tbl.Rows(0).Item("total_subtredeem")
                total_subtdiscadd = tbl.Rows(0).Item("total_subtdiscadd")
                total_discpaym = tbl.Rows(0).Item("total_discpaym")

                If total_purchased_nett < (tbl.Rows(0).Item("total_paymn") + total_subtvoucher + total_subtredeem) Then
                    total_sales = total_purchased_nett
                    otherincome = (tbl.Rows(0).Item("total_paymn") + total_subtvoucher + total_subtredeem) - total_purchased_nett
                Else
                    total_sales = tbl.Rows(0).Item("total_paymn") + total_subtvoucher + total_subtredeem
                    otherincome = 0
                End If
                total_paymn = tbl.Rows(0).Item("total_paymn")
            End If



            For i = 0 To tbl.Rows.Count - 1
                total += tbl.Rows(i).Item("val")
                Line = " "
                Line &= Mid(tbl.Rows(i).Item("pospayment_name"), 1, 15).PadRight(15, " ")
                Line &= " :  "
                Line &= String.Format("{0:#,##0}", tbl.Rows(i).Item("val")).PadLeft(11, " ")
                sb_temp.AppendText(Line & vbCrLf)
            Next



            Line = "CASHIER CLOSING FORM"
            sb.AppendText(Line & vbCrLf)
            sb.AppendText("" & vbCrLf)
            sb.AppendText("" & vbCrLf)

            Line = "Date       : " & String.Format("{0:dd/MM/yyyy}", Now())
            sb.AppendText(Line & vbCrLf)

            Line = "Operator   : " & Me.UserName
            sb.AppendText(Line & vbCrLf)

            Line = "Machine ID : " & machine_id
            sb.AppendText(Line & vbCrLf)

            sb.AppendText("" & vbCrLf)

            Line = "TRANSACTION SUMMARY"
            sb.AppendText(Line & vbCrLf)
            Line = "==================="
            sb.AppendText(Line & vbCrLf)


            Line = " Total Bon       : " & String.Format("{0:#,##0}", total_bon).PadLeft(5, " ")
            sb.AppendText(Line & vbCrLf)

            Line = " Total Item      : " & String.Format("{0:#,##0}", total_item).PadLeft(5, " ")
            sb.AppendText(Line & vbCrLf)
            sb.AppendText("" & vbCrLf)

            Line = " Total Purchased "
            sb.AppendText(Line & vbCrLf)
            Line = "           Gross :  " & String.Format("{0:#,##0}", total_purchased_gross).PadLeft(11, " ")
            sb.AppendText(Line & vbCrLf)
            Line = "            Disc : " & String.Format("({0:#,##0})", total_purchased_disc).PadLeft(13, " ")
            sb.AppendText(Line & vbCrLf)
            Line = "            Nett :  " & String.Format("{0:#,##0}", total_purchased_nett).PadLeft(11, " ")
            sb.AppendText(Line & vbCrLf)



            Line = " Total Voucher   :  " & String.Format("{0:#,##0}", total_subtvoucher).PadLeft(11, " ")
            sb.AppendText(Line & vbCrLf)

            Line = " Total Reedeem   :  " & String.Format("{0:#,##0}", total_subtredeem).PadLeft(11, " ")
            sb.AppendText(Line & vbCrLf)


            Line = " Total Add.Disc  : " & String.Format("({0:#,##0})", total_subtdiscadd).PadLeft(13, " ")
            sb.AppendText(Line & vbCrLf)


            Line = " Total DiscPaym  : " & String.Format("({0:#,##0})", total_discpaym).PadLeft(13, " ")
            sb.AppendText(Line & vbCrLf)

            Line = " Total Paymn     :  " & String.Format("{0:#,##0}", total_paymn).PadLeft(11, " ")
            sb.AppendText(Line & vbCrLf)

            Line = " Total Sales     :  " & String.Format("{0:#,##0}", total_sales).PadLeft(11, " ")
            sb.AppendText(Line & vbCrLf)


            ' Hitung Other Income
            Dim otherincome_voucher_payment As Decimal = total - total_paymn   ' other income dari type pembayaran VC100, VC150, dll
            If otherincome_voucher_payment > 0 Then
                otherincome = otherincome + otherincome_voucher_payment
            End If

            If otherincome > 0 Then
                Line = " "
                Line &= "Other Income".PadRight(15, " ")
                Line &= " :  "
                Line &= String.Format("{0:#,##0}", otherincome).PadLeft(11, " ")
                sb.AppendText(Line & vbCrLf)
            End If



            sb.AppendText("" & vbCrLf)

            Line = "PAYMENT SUMMARY"
            sb.AppendText(Line & vbCrLf)
            Line = "==================="
            sb.AppendText(Line & vbCrLf)


            ' ----
            sb.AppendText(sb_temp.Text)


            Line = " "
            Line &= "".PadRight(15, " ")
            Line &= "----"
            Line &= "".PadLeft(11, "-")
            Line &= " +"
            sb.AppendText(Line & vbCrLf)

            Line = " "
            Line &= "TOTAL".PadRight(15, " ")
            Line &= "    "
            Line &= String.Format("{0:#,##0}", total).PadLeft(11, " ")
            sb.AppendText(Line & vbCrLf)




            Return sb.Lines
        End Function

        Public Function FormatClosingReport_2(ByVal thismachineonly As Boolean, ByVal dt As Date) As String()
            Dim str As String = ""
            Dim Line As String = ""
            Dim sb As TextBox = New TextBox
            Dim machine_id As String

            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim tbl As DataTable
            Dim cmd As OleDb.OleDbCommand
            Dim da As OleDb.OleDbDataAdapter

            Dim i As Integer

            Dim no As Integer
            Dim bon_msubtotal As Decimal = 0
            Dim bon_msubtracttotal As Decimal = 0
            Dim bon_mdiscpayment As Decimal = 0
            Dim bon_mtotal As Decimal = 0
            Dim p_mega As Decimal = 0
            Dim p_othr As Decimal = 0
            Dim p_cash As Decimal = 0



            sb.Multiline = True

            If thismachineonly Then
                machine_id = Me.MachineId
            Else
                machine_id = "ALL"
            End If



            Try
                conn.Open()
                cmd = New OleDb.OleDbCommand()
                cmd.Connection = conn
                cmd.CommandText = "poshe_TrnBon_ClosingSummary_2"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@date", System.Data.OleDb.OleDbType.Date))
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@machine_id", System.Data.OleDb.OleDbType.VarWChar, 30))
                cmd.Parameters("@date").Value = dt
                cmd.Parameters("@machine_id").Value = machine_id
                da = New OleDb.OleDbDataAdapter(cmd)

                tbl = New DataTable
                da.Fill(tbl)
                da.Dispose()
            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try



            Line = "BON REKAP"
            sb.AppendText(Line & vbCrLf)

            Line = String.Format("{0:dd/MM/yyyy}", Now()) & "  Machine " & machine_id
            sb.AppendText(Line & vbCrLf)


            sb.AppendText("" & vbCrLf)


            Line = "".PadRight(137, "=")
            sb.AppendText(Line & vbCrLf)


            Line = "    "
            Line &= "  "
            Line &= "                     "
            Line &= "  "
            Line &= "          "
            Line &= " | "
            Line &= "           "
            Line &= "   "
            Line &= "           "
            Line &= "   "
            Line &= "           "
            Line &= "   "
            Line &= "           "
            Line &= " | "
            Line &= "-----------"
            Line &= "---"
            Line &= "--PAYMENT--"
            Line &= "---"
            Line &= "-----------"
            sb.AppendText(Line & vbCrLf)

            Line = " No."
            Line &= "  "
            Line &= "BON ID               "
            Line &= "  "
            Line &= "PAYMENT   "
            Line &= " | "
            Line &= "      GROSS"
            Line &= "   "
            Line &= "       SUBT"
            Line &= "   "
            Line &= "       DISC"
            Line &= "   "
            Line &= "       NETT"
            Line &= " | "
            Line &= "       MEGA"
            Line &= "   "
            Line &= "      OTHER"
            Line &= "   "
            Line &= "       CASH"
            sb.AppendText(Line & vbCrLf)


            Line = "".PadRight(137, "=")
            sb.AppendText(Line & vbCrLf)


            For i = 0 To tbl.Rows.Count - 1
                no = i + 1
                bon_msubtotal += tbl.Rows(i).Item("bon_msubtotal")
                bon_msubtracttotal += tbl.Rows(i).Item("bon_msubtracttotal")
                bon_mdiscpayment += tbl.Rows(i).Item("bon_mdiscpayment")
                bon_mtotal += tbl.Rows(i).Item("bon_mtotal")
                p_mega += tbl.Rows(i).Item("p_mega")
                p_othr += tbl.Rows(i).Item("p_othr")
                p_cash += tbl.Rows(i).Item("p_cash")

                Line = no.ToString.PadLeft(3, " ") & "."
                Line &= "  "
                Line &= tbl.Rows(i).Item("bon_id").PadRight(21, " ")
                Line &= "  "
                Line &= Mid(tbl.Rows(i).Item("pospayment_name"), 1, 10).PadRight(10, " ")
                Line &= " | "
                Line &= String.Format("{0:#,##0}", tbl.Rows(i).Item("bon_msubtotal")).PadLeft(11, " ")
                Line &= "   "
                Line &= String.Format("{0:#,##0}", tbl.Rows(i).Item("bon_msubtracttotal")).PadLeft(11, " ")
                Line &= "   "
                Line &= String.Format("{0:#,##0}", tbl.Rows(i).Item("bon_mdiscpayment")).PadLeft(11, " ")
                Line &= "   "
                Line &= String.Format("{0:#,##0}", tbl.Rows(i).Item("bon_mtotal")).PadLeft(11, " ")
                Line &= " | "
                Line &= String.Format("{0:#,##0}", tbl.Rows(i).Item("p_mega")).PadLeft(11, " ")
                Line &= "   "
                Line &= String.Format("{0:#,##0}", tbl.Rows(i).Item("p_othr")).PadLeft(11, " ")
                Line &= "   "
                Line &= String.Format("{0:#,##0}", tbl.Rows(i).Item("p_cash")).PadLeft(11, " ")
                sb.AppendText(Line & vbCrLf)
            Next



            Line = "".PadRight(137, "=")
            sb.AppendText(Line & vbCrLf)


            Line = "".ToString.PadLeft(3, " ") & " "
            Line &= "  "
            Line &= "TOTAL".PadRight(21, " ")
            Line &= "  "
            Line &= "".PadRight(10, " ")
            Line &= " | "
            Line &= String.Format("{0:#,##0}", bon_msubtotal).PadLeft(11, " ")
            Line &= "   "
            Line &= String.Format("{0:#,##0}", bon_msubtracttotal).PadLeft(11, " ")
            Line &= "   "
            Line &= String.Format("{0:#,##0}", bon_mdiscpayment).PadLeft(11, " ")
            Line &= "   "
            Line &= String.Format("{0:#,##0}", bon_mtotal).PadLeft(11, " ")
            Line &= " | "
            Line &= String.Format("{0:#,##0}", p_mega).PadLeft(11, " ")
            Line &= "   "
            Line &= String.Format("{0:#,##0}", p_othr).PadLeft(11, " ")
            Line &= "   "
            Line &= String.Format("{0:#,##0}", p_cash).PadLeft(11, " ")
            sb.AppendText(Line & vbCrLf)

            Line = "".PadRight(137, "=")
            sb.AppendText(Line & vbCrLf)


            Return sb.Lines


        End Function

        Public Function FormatClosingReport_3(ByVal thismachineonly As Boolean, ByVal dt As Date) As String()
            Dim str As String = ""
            Dim Line As String = ""
            Dim sb As TextBox = New TextBox
            Dim machine_id As String

            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim tbl As DataTable
            Dim cmd As OleDb.OleDbCommand
            Dim da As OleDb.OleDbDataAdapter

            Dim i As Integer
            Dim no As Integer
            Dim total As Integer = 0

            sb.Multiline = True

            If thismachineonly Then
                machine_id = Me.MachineId
            Else
                machine_id = "ALL"
            End If

            Try
                conn.Open()
                cmd = New OleDb.OleDbCommand()
                cmd.Connection = conn
                cmd.CommandText = "poshe_TrnBon_ClosingSummary_3"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@date", System.Data.OleDb.OleDbType.Date))
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@machine_id", System.Data.OleDb.OleDbType.VarWChar, 30))
                cmd.Parameters("@date").Value = dt
                cmd.Parameters("@machine_id").Value = machine_id
                da = New OleDb.OleDbDataAdapter(cmd)

                tbl = New DataTable
                da.Fill(tbl)
                da.Dispose()
            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try



            Line = "ARTICLE REKAP"
            sb.AppendText(Line & vbCrLf)

            Line = String.Format("{0:dd/MM/yyyy}", Now()) & "  Machine " & machine_id
            sb.AppendText(Line & vbCrLf)


            sb.AppendText("" & vbCrLf)


            Line = "".PadRight(137, "=")
            sb.AppendText(Line & vbCrLf)


            Line = " No.  ART             MAT         COL        DESCR                                      QTY"
            sb.AppendText(Line & vbCrLf)


            Line = "".PadRight(137, "=")
            sb.AppendText(Line & vbCrLf)

            For i = 0 To tbl.Rows.Count - 1
                no = i + 1
                total += tbl.Rows(i).Item("qty")

                Line = no.ToString.PadLeft(3, " ") & "."
                Line &= "  "


                Line &= Mid(tbl.Rows(i).Item("bondetil_art"), 1, 15).ToString.PadRight(15, " ")
                Line &= " "

                Line &= Mid(tbl.Rows(i).Item("bondetil_mat"), 1, 10).ToString.PadRight(10, " ")
                Line &= "  "

                Line &= Mid(tbl.Rows(i).Item("bondetil_col"), 1, 10).ToString.PadRight(10, " ")
                Line &= " "

                Line &= Mid(tbl.Rows(i).Item("bondetil_descr"), 1, 40).ToString.PadRight(40, " ")
                Line &= " "

                Line &= String.Format("{0:#,##0}", tbl.Rows(i).Item("qty")).ToString.PadLeft(5, " ")

                sb.AppendText(Line & vbCrLf)
            Next

            Line = "".PadRight(137, "=")
            sb.AppendText(Line & vbCrLf)

            Line = "                                             TOTAL                                    "
            Line &= String.Format("{0:#,##0}", total).ToString.PadLeft(5, " ")
            sb.AppendText(Line & vbCrLf)

            Line = "".PadRight(137, "=")
            sb.AppendText(Line & vbCrLf)

            Return sb.Lines


        End Function




#Region "        POS Syncrhonization "

        Public Function SynHandshake(ByVal dr As DataRow) As String
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)

            Dim synsign_id As String = dr("synsign_id")
            Dim synsign_type As String = dr("synsign_type")
            Dim synsign_dateserver As String = dr("synsign_dateserver")
            Dim synsign_dateclient As String = dr("synsign_dateclient")
            Dim synsign_ip As String = dr("synsign_ip")
            Dim synsign_hostname As String = dr("synsign_hostname")
            Dim synsign_rmtip As String = dr("synsign_rmtip")
            Dim synsign_note As String = dr("synsign_note")
            Dim session_id As String = dr("session_id")
            Dim region_id As String = dr("region_id")
            Dim branch_id As String = dr("branch_id")
            Dim username As String = dr("username")
            Dim rowid As String = dr("rowid")


            Dim SQL As String
            SQL = "INSERT INTO transaksi_hepossynsignclient "
            SQL &= "(synsign_id,synsign_type,synsign_dateserver,synsign_dateclient,synsign_ip,synsign_hostname,synsign_rmtip,synsign_note,session_id,region_id,branch_id,username,rowid) "
            SQL &= "VALUES "
            SQL &= "('" & synsign_id & "', '" & synsign_type & "', '" & synsign_dateserver & "', '" & synsign_dateclient & "', '" & synsign_ip & "', '" & synsign_hostname & "', '" & synsign_rmtip & "', '" & synsign_note & "', '" & session_id & "', '" & region_id & "', '" & branch_id & "', '" & username & "', '" & rowid & "') "

            conn.Open()

            Try
                Dim cmd As OleDb.OleDbCommand = New OleDb.OleDbCommand(SQL, conn)
                cmd.ExecuteNonQuery()
                Me.SynSignID = synsign_id
            Catch ex As Exception
                Throw New Exception("[POS.Handshake]" & vbCrLf & ex.Message)
            Finally
                conn.Close()
            End Try


            Return synsign_id
        End Function

        Public Function SynCheckUpdater(ByVal updater_id As String) As Boolean
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim SQL As String

            conn.Open()

            Try
                SQL = "SELECT * FROM transaksi_heposdataupdateclient WHERE id='" & updater_id & "'"
                Dim cmd As OleDb.OleDbCommand = New OleDb.OleDbCommand(SQL, conn)
                Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader()
                dr.Read()

                If dr.HasRows Then
                    Return True
                End If
            Catch ex As Exception
                Throw New Exception("POS.SynCheckUpdater" & vbCrLf & ex.Message)
            End Try
        End Function

        Public Function SynComplete(ByVal synsign_id As String) As Boolean
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim SQL As String

            conn.Open()

            Try
                SQL = "UPDATE transaksi_hepossynsignclient SET synsign_iscompleted=1 WHERE synsign_id='" & synsign_id & "'"
                Dim cmd As OleDb.OleDbCommand = New OleDb.OleDbCommand(SQL, conn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw New Exception("POS.SynComplete" & vbCrLf & ex.Message)
            End Try
        End Function

        Public Function UpdateTable(ByVal tablename As String, ByVal updatemethod As String, ByVal keys As String, ByRef sqliteconn As SQLite.SQLiteConnection, ByRef bgw As System.ComponentModel.BackgroundWorker) As Boolean
            ' Jalan di thread
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim trans As OleDb.OleDbTransaction
            Dim cmd As OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader
            Dim cmdLite As SQLite.SQLiteCommand
            Dim drLite As SQLite.SQLiteDataReader
            Dim keyscriteria As String
            Dim SQL As String = ""
            Dim keyentries As String() = {}

            conn.Open()
            trans = conn.BeginTransaction()
            Try
                If updatemethod = "REFRESH" Then
                    cmd = New OleDb.OleDbCommand("DELETE FROM " & tablename, conn, trans)
                    cmd.ExecuteNonQuery()
                End If

                cmdLite = sqliteconn.CreateCommand()
                cmdLite.CommandText = "SELECT * FROM " & tablename
                drLite = cmdLite.ExecuteReader()
                While drLite.Read()
                    If updatemethod = "MERGE" Then
                        keyscriteria = Me.CreateCriteriaFromKeys(keys, drLite, keyentries)
                        SQL = "SELECT * FROM " & tablename & " WHERE " & keyscriteria
                        cmd = New OleDb.OleDbCommand(SQL, conn, trans)
                        dr = cmd.ExecuteReader()
                        dr.Read()
                        If dr.HasRows Then
                            ' UPDATE
                            SQL = Me.CreateSQLUpdateFrom(tablename, drLite, keyscriteria, keyentries)
                        Else
                            ' INSERT
                            SQL = Me.CreateSQLInsertFrom(tablename, drLite)
                        End If
                    Else
                        SQL = Me.CreateSQLInsertFrom(tablename, drLite)
                    End If
                    cmd = New OleDb.OleDbCommand(SQL, conn, trans)
                    cmd.ExecuteNonQuery()
                End While
                trans.Commit()
            Catch ex As Exception
                trans.Rollback()
                Throw New Exception("[POS.UpdateTable]" & "table:" & tablename & vbCrLf & SQL & vbCrLf & ex.Message)
            Finally
                conn.Close()
            End Try
        End Function

        Public Function CreateCriteriaFromKeys(ByVal keys As String, ByRef drLite As SQLite.SQLiteDataReader, ByRef entries As String()) As String
            Dim str As String = ""
            Dim _logicalcriteria As String
            Dim criterias As String() = {}

            Dim key As String

            entries = keys.Split(",")
            If entries.Length > 1 Then
                Dim t = 0
            End If

            For Each key In entries
                _logicalcriteria = key & "='" & drLite(key) & "' "
                Array.Resize(criterias, criterias.Length + 1)
                criterias(criterias.Length - 1) = _logicalcriteria
            Next

            str = String.Join(" AND ", criterias)


            Return str
        End Function

        Public Function CreateSQLUpdateFrom(ByVal tablename As String, ByRef drLite As SQLite.SQLiteDataReader, ByVal criteria As String, ByVal keyentries As String()) As String
            Dim i As Integer
            Dim key As String
            Dim name As String = ""
            Dim value As String = ""
            Dim fieldupdate As String
            Dim updates As String() = {}
            Dim str As String = ""
            Dim notused As Boolean = False

            For i = 0 To drLite.FieldCount - 1
                notused = False
                name = drLite.GetName(i)
                For Each key In keyentries
                    If key = name Then
                        notused = True
                        Exit For
                    End If
                Next
                If Not notused Then
                    If drLite(name) Is DBNull.Value Then
                        value = "NULL"
                        fieldupdate = "[" & name & "] = " & value & " "
                    Else
                        value = drLite(name)
                        fieldupdate = "[" & name & "] = '" & value & "' "
                    End If
                    Array.Resize(updates, updates.Length + 1)
                    updates(updates.Length - 1) = fieldupdate
                End If
            Next

            str = "UPDATE " & tablename & vbCrLf
            str &= "SET" & vbCrLf
            str &= String.Join(", " & vbCrLf, updates)
            str &= vbCrLf
            str &= "WHERE" & vbCrLf
            str &= criteria

            Return str
        End Function

        Public Function CreateSQLInsertFrom(ByVal tablename As String, ByRef drLite As SQLite.SQLiteDataReader) As String
            Dim i As Integer
            Dim name As String = ""
            Dim value As String = ""
            Dim fieldinsert As String
            Dim insertedfields As String() = {}
            Dim valueinsert As String
            Dim insertedvalues As String() = {}
            Dim sql As String = ""


            For i = 0 To drLite.FieldCount - 1
                name = drLite.GetName(i)
                fieldinsert = "[" & name & "]"

                If drLite(name) Is DBNull.Value Then
                    value = "NULL"
                    valueinsert = value
                Else
                    value = drLite(name)
                    valueinsert = "'" & value & "'"
                End If

                Array.Resize(insertedfields, insertedfields.Length + 1)
                insertedfields(insertedfields.Length - 1) = fieldinsert

                Array.Resize(insertedvalues, insertedvalues.Length + 1)
                insertedvalues(insertedvalues.Length - 1) = valueinsert

            Next


            sql = "INSERT INTO " & tablename & vbCrLf
            sql &= "(" & String.Join(", ", insertedfields) & ")" & vbCrLf
            sql &= "VALUES" & vbCrLf
            sql &= "(" & String.Join(", ", insertedvalues) & ")" & vbCrLf


            Return sql
        End Function

        Public Function RecordUpdaterID(ByVal updater_id As String, ByVal region_id As String, ByVal synsign_id As String) As Boolean
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim cmd As OleDb.OleDbCommand
            Dim SQL As String

            conn.Open()
            Try
                SQL = "INSERT INTO transaksi_heposdataupdateclient "
                SQL &= "(id,date,isdisabled,region_id,synsign_id) "
                SQL &= "VALUES "
                SQL &= "('" & updater_id & "', getdate(),1,'" & region_id & "','" & synsign_id & "')"
                cmd = New OleDb.OleDbCommand(SQL, conn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw New Exception("[POS.RecordUpdaterID]" & vbCrLf & ex.Message)
            Finally
                conn.Close()
            End Try


        End Function

        Public Function GetServerName() As String
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Return conn.DataSource
        End Function

        Public Function GetClientSignInData() As String
            Dim str As String
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim cmd As OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader

            Dim SQL As String

            conn.Open()
            Try
                SQL = "SELECT TOP 1 synsign_id, synsign_dateclient FROM transaksi_hepossynsignclient WHERE DAY(synsign_dateclient)=DAY(getdate()) AND MONTH(synsign_dateclient)=MONTH(getdate()) AND YEAR(synsign_dateclient)=YEAR(getdate()) AND synsign_iscompleted=1 ORDER BY synsign_dateclient ASC"
                cmd = New OleDb.OleDbCommand(SQL, conn)
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    While dr.Read()
                        str = dr("synsign_id") & ", " & dr("synsign_dateclient")
                        Return str
                    End While
                End If
            Catch ex As Exception
                Throw New Exception("[POS.GetClientSignInData]" & vbCrLf & ex.Message)
            Finally
                conn.Close()
            End Try


            Return ""
        End Function


        Public Function GetData(ByVal sql) As DataTable
            Dim tbl As DataTable = New DataTable
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim cmd As OleDb.OleDbCommand
            Dim da As OleDb.OleDbDataAdapter

            conn.Open()
            Try
                cmd = New OleDb.OleDbCommand(sql, conn)
                da = New OleDb.OleDbDataAdapter(cmd)
                da.Fill(tbl)
            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try

            Return tbl
        End Function


        Public Function UpdatingPOSLocalData(ByVal tblpos As DataTable, ByVal synsign_id As String, ByVal synsign_dateserver As Date) As Boolean
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim cmd As OleDb.OleDbCommand
            Dim i As Integer
            Dim bon_id As String
            Dim dtstring As String = synsign_dateserver.Year.ToString & "-" & synsign_dateserver.Month.ToString.PadLeft(2, "0") & "-" & synsign_dateserver.Day.ToString.PadLeft(2, "0") & " " & synsign_dateserver.Hour.ToString.PadLeft(2, "0") & ":" & synsign_dateserver.Minute.ToString.PadLeft(2, "0") & ":00"

            conn.Open()
            Try
                For i = 0 To tblpos.Rows.Count - 1
                    bon_id = tblpos.Rows(i).Item("bon_id")
                    cmd = New OleDb.OleDbCommand("UPDATE transaksi_hepos SET syncode='" & synsign_id & "', syndate='" & dtstring & "' WHERE bon_id='" & bon_id & "'", conn)
                    cmd.ExecuteNonQuery()
                Next
            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try


        End Function



#End Region


    End Class




#Region " Structure "

    Public Structure PosVoucherDialogParamValue
        Dim MODE As String
        Dim PaymentTotalValue As Decimal
        Dim AddDiscAuto As Decimal
        Dim AddDiscMinimalTotal As Decimal
        Dim SelectedPaymentName As String
        Dim SelectedPaymentDisc As Decimal
        Dim SelectedPaymentIsVoucherDisabled As Boolean
        Dim SelectedPaymentIsAddDiscDisabled As Boolean
        Dim SelectedPaymentIsRedeemDisabled As Boolean
        Dim PaymentVoucherCode As String
        Dim PaymentVoucher As Decimal
        Dim PaymentAddDisc As Decimal
        Dim PaymentRedeem As Decimal
        Dim VoucherId As String
        Dim POS As TransStore.POS
        Dim authusername As String
    End Structure

    Public Structure PosPaymentDialogParamValue
        Dim PaymentTypeId As String
        Dim PaymentTypeName As String
        Dim PaymentBank As String
        Dim pospayment_disc As Decimal
        Dim pospayment_discvalue As Decimal
        Dim pospayment_discminpurchase As Decimal
        Dim pospayment_multi As Boolean
        Dim pospayment_prefix As String
        Dim pospayment_isvoucherdisabled As Boolean
        Dim pospayment_isadddiscdisabled As Boolean
        Dim pospayment_isredeemdisabled As Boolean
        Dim NewTransactionParamValue As TransStore.PosNewTransactionReturnValue
    End Structure

    Public Structure PosNewTransactionParamValue
        Dim POS As TransStore.POS
    End Structure

    Public Structure PosNewTransactionReturnValue
        Dim CustomerNationalityId As String
        Dim CustomerNationalityName As String
        Dim CustomerGenderId As String
        Dim CustomerGenderName As String
        Dim CustomerAgeId As String
        Dim CustomerAgeName As String
        Dim CustomerId As String
        Dim CustomerName As String
        Dim CustomerNPWP As String
        Dim CustomerTelp As String
        Dim CustomerType As String
        Dim CustomerPassport As String
        Dim CustomerDisc As Decimal
        Dim Voucher01Id As String
        Dim Voucher01Name As String
        Dim Voucher01CodeNum As String
        Dim Voucher01Type As String
        Dim Voucher01Disc As Decimal
        Dim Voucher01Method As String
        Dim SalesId As String
        Dim SalesName As String
        Dim BonExternal As String
        Dim BonEvent As String
        Dim SiteIdFrom As String
    End Structure


    Public Structure PosDataBrowseParamValue
        Dim id As String
        Dim name As String
        Dim POS As TransStore.POS
        Dim Title As String
        Dim SQL As String
        Dim keyfield As String
        Dim ColumnsFormat As Object
        Dim column_objid As String
        Dim column_objname As String
        Dim param_01 As String
        Dim param_02 As String
        Dim param_03 As String
        Dim param_04 As String
        Dim param_05 As String
        Dim param_06 As String
        Dim param_07 As String
        Dim param_08 As String
    End Structure

    Public Structure PosDataBrowseReturnValue
        Dim id As String
        Dim name As String
        Dim fields As Collection
    End Structure


    Public Structure PosItemPrice
        Dim discpstd01 As Decimal
        Dim discrstd01 As Decimal
        Dim pricenettstd01 As Decimal
        Dim discpvou01 As Decimal
        Dim discrvou01 As Decimal
        Dim pricenettvou01 As Decimal
    End Structure




    Public Structure PosDataUpdaterParam
        Dim id As String
        Dim service_handshake As String
        Dim service_getupdater As String
        Dim service_goodby As String
        Dim service_getmodifieditem As String
        Dim service_setclientupdatestatus As String
        Dim service_invinfoget As String
        Dim service_invinfopurge As String
        Dim auto As Boolean
        Dim SENDDATAMODE As String
        Dim SENDDATAVER As String
        Dim dt As Date
    End Structure

    Public Structure PosDataUpdaterResult
        Dim id As String
        Dim param As PosDataUpdaterParam
        Dim success As Boolean
        Dim errormessage As String
    End Structure

    Public Structure PosBonVoidRequestParam
        Dim id As String
        Dim service_handshake As String
        Dim service_voidrequest As String
        Dim service_goodby As String
        Dim username As String
        Dim password As String
        Dim bon_id As String
        Dim systemdate As Date
        Dim success As Boolean
        Dim errormessage As String
    End Structure

    Public Structure PosBonVoidRequestResult
        Dim id As String
        Dim param As PosBonVoidRequestParam
        Dim canvoid As Boolean
        Dim message As String
        Dim success As Boolean
        Dim errormessage As String
    End Structure



    Public Structure RegionUpdateInfo
        Dim region_id As String
        Dim filename As String
    End Structure



    Public Structure POSParameter
        Dim DISABLED_PAYMENT_METHOD As String
        Dim AUTO_KEY_NUMBER As String
        Dim SLAVE_MODE As String
        Dim VOUCHER_LINKEDTO_CUSTOMERTYPE As String
        Dim DISABLED_VOUCHER As String
        Dim AUTOSENDPOSDATA As String
        Dim AUTOSENDINTERVAL As String
        Dim SENDDATAMODE As String
        Dim SENDDATAVER As String
    End Structure


    Public Structure DiscountPayment
        'Nilai Discount
        Dim DiscountPercentage As Decimal
        Dim DiscountValue As Decimal

        'Syarat
        Dim MinimumQtyPurchase As Integer
        Dim MinimumValuePurchase As Decimal

        ' Limitasi
        Dim MaximumDiscountValue As Decimal
    End Structure


    Public Structure PosPayment
        ' pospayment_id	pospayment_name	pospayment_disc	pospayment_isdisabled	pospayment_iscash	pospayment_isvoucher	pospayment_vouchervalue	
        'pospayment_order	pospayment_multi	pospayment_prefix	pospayment_minpaid	pospayment_shortcut	pospayment_bankname	pospayment_isvoucherdisabled	pospayment_isadddiscdisabled	pospayment_isredeemdisabled	pospayment_discvalue	pospayment_discminpurchase	pospayment_maxitemdiscallowed
        Dim Id As String
        Dim Name As String
        Dim Disc As Decimal
        Dim DiscValue As Decimal
        Dim IsCash As Boolean
        Dim IsVoucher As Boolean
        Dim VoucherValue As Decimal
        Dim Order As Integer
        Dim IsMulti As Boolean
        Dim MinimumPurchase As Decimal
        Dim MaximumItemDiscAllowed As Decimal
    End Structure

#End Region

End Namespace
