<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnPosEN
    Inherits Translib.dlgBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PnlPosMain = New System.Windows.Forms.Panel()
        Me.PnlPosMainCenter = New System.Windows.Forms.Panel()
        Me.DgvPOSItem = New System.Windows.Forms.DataGridView()
        Me.PnlPosMainF = New System.Windows.Forms.Panel()
        Me.txt_INFO = New System.Windows.Forms.Label()
        Me.btn_PgDown = New System.Windows.Forms.Label()
        Me.btn_PgUp = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.objCustomerNationalityId = New System.Windows.Forms.Label()
        Me.objCustomerNationalityName = New System.Windows.Forms.Label()
        Me.objCustomerGenderId = New System.Windows.Forms.Label()
        Me.objCustomerGenderName = New System.Windows.Forms.Label()
        Me.objCustomerAgeId = New System.Windows.Forms.Label()
        Me.objCustomerAgeName = New System.Windows.Forms.Label()
        Me.objCustomerId = New System.Windows.Forms.Label()
        Me.objCustomerName = New System.Windows.Forms.Label()
        Me.objCustomerNPWP = New System.Windows.Forms.Label()
        Me.objVoucher01Disc = New System.Windows.Forms.Label()
        Me.objVoucher01Type = New System.Windows.Forms.Label()
        Me.objVoucher01CodeNum = New System.Windows.Forms.Label()
        Me.objVoucher01Id = New System.Windows.Forms.Label()
        Me.objVoucher01Name = New System.Windows.Forms.Label()
        Me.objSalesId = New System.Windows.Forms.Label()
        Me.objSalesName = New System.Windows.Forms.Label()
        Me.objVoucher01Method = New System.Windows.Forms.Label()
        Me.objCustomerTelp = New System.Windows.Forms.Label()
        Me.objCustomerType = New System.Windows.Forms.Label()
        Me.objCustomerDisc = New System.Windows.Forms.Label()
        Me.objCustomerPassport = New System.Windows.Forms.Label()
        Me.objBonExternal = New System.Windows.Forms.Label()
        Me.objBonEvent = New System.Windows.Forms.Label()
        Me.objSiteIdFrom = New System.Windows.Forms.Label()
        Me.objStatusShow = New System.Windows.Forms.Label()
        Me.objVoucherInformation = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.objPaymentShortcut = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.objTime = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.objPaymentTypeName = New System.Windows.Forms.Label()
        Me.objPaymentTypeId = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.objPosOperator = New System.Windows.Forms.Label()
        Me.objPosMachineID = New System.Windows.Forms.Label()
        Me.objPosDate = New System.Windows.Forms.Label()
        Me.PnlPosMainH = New System.Windows.Forms.Panel()
        Me.lblLocationStatus = New System.Windows.Forms.Label()
        Me.objPosEventName = New System.Windows.Forms.Label()
        Me.objPosCompanyName = New System.Windows.Forms.Label()
        Me.lineItemDisplay = New System.Windows.Forms.Label()
        Me.txtItemSelectedPrice = New System.Windows.Forms.Label()
        Me.txtItemSelectedQty = New System.Windows.Forms.Label()
        Me.txtItemSelectedName = New System.Windows.Forms.Label()
        Me.txtItemEntry = New System.Windows.Forms.TextBox()
        Me.lineSubtotal = New System.Windows.Forms.Label()
        Me.lineQuantity = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.txtCount = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.txtSubtotal = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PromoListContainer = New System.Windows.Forms.FlowLayoutPanel()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlPosMain.SuspendLayout()
        Me.PnlPosMainCenter.SuspendLayout()
        CType(Me.DgvPOSItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlPosMainF.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.PnlPosMainH.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlPosMain
        '
        Me.PnlPosMain.BackColor = System.Drawing.Color.Transparent
        Me.PnlPosMain.Controls.Add(Me.PnlPosMainCenter)
        Me.PnlPosMain.Controls.Add(Me.PnlPosMainF)
        Me.PnlPosMain.Controls.Add(Me.PnlPosMainH)
        Me.PnlPosMain.Location = New System.Drawing.Point(12, 12)
        Me.PnlPosMain.Name = "PnlPosMain"
        Me.PnlPosMain.Size = New System.Drawing.Size(787, 544)
        Me.PnlPosMain.TabIndex = 3
        '
        'PnlPosMainCenter
        '
        Me.PnlPosMainCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlPosMainCenter.Controls.Add(Me.DgvPOSItem)
        Me.PnlPosMainCenter.Location = New System.Drawing.Point(39, 194)
        Me.PnlPosMainCenter.Name = "PnlPosMainCenter"
        Me.PnlPosMainCenter.Padding = New System.Windows.Forms.Padding(10)
        Me.PnlPosMainCenter.Size = New System.Drawing.Size(297, 91)
        Me.PnlPosMainCenter.TabIndex = 2
        '
        'DgvPOSItem
        '
        Me.DgvPOSItem.AllowUserToAddRows = False
        Me.DgvPOSItem.AllowUserToDeleteRows = False
        Me.DgvPOSItem.BackgroundColor = System.Drawing.Color.Gray
        Me.DgvPOSItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPOSItem.Location = New System.Drawing.Point(13, 27)
        Me.DgvPOSItem.Name = "DgvPOSItem"
        Me.DgvPOSItem.ReadOnly = True
        Me.DgvPOSItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPOSItem.Size = New System.Drawing.Size(53, 37)
        Me.DgvPOSItem.TabIndex = 2
        '
        'PnlPosMainF
        '
        Me.PnlPosMainF.Controls.Add(Me.PromoListContainer)
        Me.PnlPosMainF.Controls.Add(Me.Label12)
        Me.PnlPosMainF.Controls.Add(Me.txt_INFO)
        Me.PnlPosMainF.Controls.Add(Me.btn_PgDown)
        Me.PnlPosMainF.Controls.Add(Me.btn_PgUp)
        Me.PnlPosMainF.Controls.Add(Me.Label11)
        Me.PnlPosMainF.Controls.Add(Me.FlowLayoutPanel1)
        Me.PnlPosMainF.Controls.Add(Me.objStatusShow)
        Me.PnlPosMainF.Controls.Add(Me.objVoucherInformation)
        Me.PnlPosMainF.Controls.Add(Me.Label10)
        Me.PnlPosMainF.Controls.Add(Me.objPaymentShortcut)
        Me.PnlPosMainF.Controls.Add(Me.Label6)
        Me.PnlPosMainF.Controls.Add(Me.objTime)
        Me.PnlPosMainF.Controls.Add(Me.Label8)
        Me.PnlPosMainF.Controls.Add(Me.Label9)
        Me.PnlPosMainF.Controls.Add(Me.Label7)
        Me.PnlPosMainF.Controls.Add(Me.Label4)
        Me.PnlPosMainF.Controls.Add(Me.Label5)
        Me.PnlPosMainF.Controls.Add(Me.Label1)
        Me.PnlPosMainF.Controls.Add(Me.Label3)
        Me.PnlPosMainF.Controls.Add(Me.objPaymentTypeName)
        Me.PnlPosMainF.Controls.Add(Me.objPaymentTypeId)
        Me.PnlPosMainF.Controls.Add(Me.Label2)
        Me.PnlPosMainF.Controls.Add(Me.objPosOperator)
        Me.PnlPosMainF.Controls.Add(Me.objPosMachineID)
        Me.PnlPosMainF.Controls.Add(Me.objPosDate)
        Me.PnlPosMainF.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlPosMainF.Location = New System.Drawing.Point(0, 315)
        Me.PnlPosMainF.Name = "PnlPosMainF"
        Me.PnlPosMainF.Size = New System.Drawing.Size(787, 229)
        Me.PnlPosMainF.TabIndex = 1
        '
        'txt_INFO
        '
        Me.txt_INFO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_INFO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.txt_INFO.Location = New System.Drawing.Point(555, 81)
        Me.txt_INFO.Name = "txt_INFO"
        Me.txt_INFO.Size = New System.Drawing.Size(222, 30)
        Me.txt_INFO.TabIndex = 37
        Me.txt_INFO.Text = "<text>"
        Me.txt_INFO.Visible = False
        '
        'btn_PgDown
        '
        Me.btn_PgDown.AutoSize = True
        Me.btn_PgDown.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btn_PgDown.Location = New System.Drawing.Point(130, 15)
        Me.btn_PgDown.Name = "btn_PgDown"
        Me.btn_PgDown.Size = New System.Drawing.Size(48, 13)
        Me.btn_PgDown.TabIndex = 36
        Me.btn_PgDown.Text = "[PgDwn]"
        '
        'btn_PgUp
        '
        Me.btn_PgUp.AutoSize = True
        Me.btn_PgUp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btn_PgUp.Location = New System.Drawing.Point(84, 15)
        Me.btn_PgUp.Name = "btn_PgUp"
        Me.btn_PgUp.Size = New System.Drawing.Size(40, 13)
        Me.btn_PgUp.TabIndex = 35
        Me.btn_PgUp.Text = "[PgUp]"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(520, 82)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "INFO: "
        Me.Label11.Visible = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.objCustomerNationalityId)
        Me.FlowLayoutPanel1.Controls.Add(Me.objCustomerNationalityName)
        Me.FlowLayoutPanel1.Controls.Add(Me.objCustomerGenderId)
        Me.FlowLayoutPanel1.Controls.Add(Me.objCustomerGenderName)
        Me.FlowLayoutPanel1.Controls.Add(Me.objCustomerAgeId)
        Me.FlowLayoutPanel1.Controls.Add(Me.objCustomerAgeName)
        Me.FlowLayoutPanel1.Controls.Add(Me.objCustomerId)
        Me.FlowLayoutPanel1.Controls.Add(Me.objCustomerName)
        Me.FlowLayoutPanel1.Controls.Add(Me.objCustomerNPWP)
        Me.FlowLayoutPanel1.Controls.Add(Me.objVoucher01Disc)
        Me.FlowLayoutPanel1.Controls.Add(Me.objVoucher01Type)
        Me.FlowLayoutPanel1.Controls.Add(Me.objVoucher01CodeNum)
        Me.FlowLayoutPanel1.Controls.Add(Me.objVoucher01Id)
        Me.FlowLayoutPanel1.Controls.Add(Me.objVoucher01Name)
        Me.FlowLayoutPanel1.Controls.Add(Me.objSalesId)
        Me.FlowLayoutPanel1.Controls.Add(Me.objSalesName)
        Me.FlowLayoutPanel1.Controls.Add(Me.objVoucher01Method)
        Me.FlowLayoutPanel1.Controls.Add(Me.objCustomerTelp)
        Me.FlowLayoutPanel1.Controls.Add(Me.objCustomerType)
        Me.FlowLayoutPanel1.Controls.Add(Me.objCustomerDisc)
        Me.FlowLayoutPanel1.Controls.Add(Me.objCustomerPassport)
        Me.FlowLayoutPanel1.Controls.Add(Me.objBonExternal)
        Me.FlowLayoutPanel1.Controls.Add(Me.objBonEvent)
        Me.FlowLayoutPanel1.Controls.Add(Me.objSiteIdFrom)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(398, 192)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(366, 14)
        Me.FlowLayoutPanel1.TabIndex = 32
        Me.FlowLayoutPanel1.Visible = False
        '
        'objCustomerNationalityId
        '
        Me.objCustomerNationalityId.AutoSize = True
        Me.objCustomerNationalityId.BackColor = System.Drawing.Color.LightSteelBlue
        Me.objCustomerNationalityId.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objCustomerNationalityId.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerNationalityId.Location = New System.Drawing.Point(282, 0)
        Me.objCustomerNationalityId.Name = "objCustomerNationalityId"
        Me.objCustomerNationalityId.Size = New System.Drawing.Size(81, 9)
        Me.objCustomerNationalityId.TabIndex = 0
        Me.objCustomerNationalityId.Text = "CustomerNationalityId"
        '
        'objCustomerNationalityName
        '
        Me.objCustomerNationalityName.AutoSize = True
        Me.objCustomerNationalityName.BackColor = System.Drawing.Color.LightSteelBlue
        Me.objCustomerNationalityName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objCustomerNationalityName.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerNationalityName.Location = New System.Drawing.Point(180, 0)
        Me.objCustomerNationalityName.Name = "objCustomerNationalityName"
        Me.objCustomerNationalityName.Size = New System.Drawing.Size(96, 9)
        Me.objCustomerNationalityName.TabIndex = 1
        Me.objCustomerNationalityName.Text = "CustomerNationalityName"
        '
        'objCustomerGenderId
        '
        Me.objCustomerGenderId.AutoSize = True
        Me.objCustomerGenderId.BackColor = System.Drawing.Color.LightSteelBlue
        Me.objCustomerGenderId.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objCustomerGenderId.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerGenderId.Location = New System.Drawing.Point(104, 0)
        Me.objCustomerGenderId.Name = "objCustomerGenderId"
        Me.objCustomerGenderId.Size = New System.Drawing.Size(70, 9)
        Me.objCustomerGenderId.TabIndex = 2
        Me.objCustomerGenderId.Text = "CustomerGenderId"
        '
        'objCustomerGenderName
        '
        Me.objCustomerGenderName.AutoSize = True
        Me.objCustomerGenderName.BackColor = System.Drawing.Color.LightSteelBlue
        Me.objCustomerGenderName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objCustomerGenderName.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerGenderName.Location = New System.Drawing.Point(13, 0)
        Me.objCustomerGenderName.Name = "objCustomerGenderName"
        Me.objCustomerGenderName.Size = New System.Drawing.Size(85, 9)
        Me.objCustomerGenderName.TabIndex = 3
        Me.objCustomerGenderName.Text = "CustomerGenderName"
        '
        'objCustomerAgeId
        '
        Me.objCustomerAgeId.AutoSize = True
        Me.objCustomerAgeId.BackColor = System.Drawing.Color.LightSteelBlue
        Me.objCustomerAgeId.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objCustomerAgeId.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerAgeId.Location = New System.Drawing.Point(305, 9)
        Me.objCustomerAgeId.Name = "objCustomerAgeId"
        Me.objCustomerAgeId.Size = New System.Drawing.Size(58, 9)
        Me.objCustomerAgeId.TabIndex = 4
        Me.objCustomerAgeId.Text = "CustomerAgeId"
        '
        'objCustomerAgeName
        '
        Me.objCustomerAgeName.AutoSize = True
        Me.objCustomerAgeName.BackColor = System.Drawing.Color.LightSteelBlue
        Me.objCustomerAgeName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objCustomerAgeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerAgeName.Location = New System.Drawing.Point(226, 9)
        Me.objCustomerAgeName.Name = "objCustomerAgeName"
        Me.objCustomerAgeName.Size = New System.Drawing.Size(73, 9)
        Me.objCustomerAgeName.TabIndex = 5
        Me.objCustomerAgeName.Text = "CustomerAgeName"
        '
        'objCustomerId
        '
        Me.objCustomerId.AutoSize = True
        Me.objCustomerId.BackColor = System.Drawing.Color.LightSteelBlue
        Me.objCustomerId.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objCustomerId.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerId.Location = New System.Drawing.Point(175, 9)
        Me.objCustomerId.Name = "objCustomerId"
        Me.objCustomerId.Size = New System.Drawing.Size(45, 9)
        Me.objCustomerId.TabIndex = 6
        Me.objCustomerId.Text = "CustomerId"
        '
        'objCustomerName
        '
        Me.objCustomerName.AutoSize = True
        Me.objCustomerName.BackColor = System.Drawing.Color.LightSteelBlue
        Me.objCustomerName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerName.Location = New System.Drawing.Point(109, 9)
        Me.objCustomerName.Name = "objCustomerName"
        Me.objCustomerName.Size = New System.Drawing.Size(60, 9)
        Me.objCustomerName.TabIndex = 7
        Me.objCustomerName.Text = "CustomerName"
        '
        'objCustomerNPWP
        '
        Me.objCustomerNPWP.AutoSize = True
        Me.objCustomerNPWP.BackColor = System.Drawing.Color.LightSteelBlue
        Me.objCustomerNPWP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objCustomerNPWP.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerNPWP.Location = New System.Drawing.Point(40, 9)
        Me.objCustomerNPWP.Name = "objCustomerNPWP"
        Me.objCustomerNPWP.Size = New System.Drawing.Size(63, 9)
        Me.objCustomerNPWP.TabIndex = 8
        Me.objCustomerNPWP.Text = "CustomerNPWP"
        '
        'objVoucher01Disc
        '
        Me.objVoucher01Disc.AutoSize = True
        Me.objVoucher01Disc.BackColor = System.Drawing.Color.LightSalmon
        Me.objVoucher01Disc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objVoucher01Disc.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objVoucher01Disc.Location = New System.Drawing.Point(306, 18)
        Me.objVoucher01Disc.Name = "objVoucher01Disc"
        Me.objVoucher01Disc.Size = New System.Drawing.Size(57, 9)
        Me.objVoucher01Disc.TabIndex = 14
        Me.objVoucher01Disc.Text = "Voucher01Disc"
        '
        'objVoucher01Type
        '
        Me.objVoucher01Type.AutoSize = True
        Me.objVoucher01Type.BackColor = System.Drawing.Color.MistyRose
        Me.objVoucher01Type.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objVoucher01Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objVoucher01Type.Location = New System.Drawing.Point(242, 18)
        Me.objVoucher01Type.Name = "objVoucher01Type"
        Me.objVoucher01Type.Size = New System.Drawing.Size(58, 9)
        Me.objVoucher01Type.TabIndex = 15
        Me.objVoucher01Type.Text = "Voucher01Type"
        '
        'objVoucher01CodeNum
        '
        Me.objVoucher01CodeNum.AutoSize = True
        Me.objVoucher01CodeNum.BackColor = System.Drawing.Color.MistyRose
        Me.objVoucher01CodeNum.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objVoucher01CodeNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objVoucher01CodeNum.Location = New System.Drawing.Point(160, 18)
        Me.objVoucher01CodeNum.Name = "objVoucher01CodeNum"
        Me.objVoucher01CodeNum.Size = New System.Drawing.Size(76, 9)
        Me.objVoucher01CodeNum.TabIndex = 11
        Me.objVoucher01CodeNum.Text = "Voucher01CodeNum"
        '
        'objVoucher01Id
        '
        Me.objVoucher01Id.AutoSize = True
        Me.objVoucher01Id.BackColor = System.Drawing.Color.MistyRose
        Me.objVoucher01Id.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objVoucher01Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objVoucher01Id.Location = New System.Drawing.Point(107, 18)
        Me.objVoucher01Id.Name = "objVoucher01Id"
        Me.objVoucher01Id.Size = New System.Drawing.Size(47, 9)
        Me.objVoucher01Id.TabIndex = 9
        Me.objVoucher01Id.Text = "Voucher01Id"
        '
        'objVoucher01Name
        '
        Me.objVoucher01Name.AutoSize = True
        Me.objVoucher01Name.BackColor = System.Drawing.Color.MistyRose
        Me.objVoucher01Name.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objVoucher01Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objVoucher01Name.Location = New System.Drawing.Point(39, 18)
        Me.objVoucher01Name.Name = "objVoucher01Name"
        Me.objVoucher01Name.Size = New System.Drawing.Size(62, 9)
        Me.objVoucher01Name.TabIndex = 10
        Me.objVoucher01Name.Text = "Voucher01Name"
        '
        'objSalesId
        '
        Me.objSalesId.AutoSize = True
        Me.objSalesId.BackColor = System.Drawing.Color.Yellow
        Me.objSalesId.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objSalesId.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objSalesId.Location = New System.Drawing.Point(3, 18)
        Me.objSalesId.Name = "objSalesId"
        Me.objSalesId.Size = New System.Drawing.Size(30, 9)
        Me.objSalesId.TabIndex = 12
        Me.objSalesId.Text = "SalesId"
        '
        'objSalesName
        '
        Me.objSalesName.AutoSize = True
        Me.objSalesName.BackColor = System.Drawing.Color.Yellow
        Me.objSalesName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objSalesName.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objSalesName.Location = New System.Drawing.Point(318, 27)
        Me.objSalesName.Name = "objSalesName"
        Me.objSalesName.Size = New System.Drawing.Size(45, 9)
        Me.objSalesName.TabIndex = 13
        Me.objSalesName.Text = "SalesName"
        '
        'objVoucher01Method
        '
        Me.objVoucher01Method.AutoSize = True
        Me.objVoucher01Method.BackColor = System.Drawing.Color.MistyRose
        Me.objVoucher01Method.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objVoucher01Method.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objVoucher01Method.Location = New System.Drawing.Point(246, 27)
        Me.objVoucher01Method.Name = "objVoucher01Method"
        Me.objVoucher01Method.Size = New System.Drawing.Size(66, 9)
        Me.objVoucher01Method.TabIndex = 16
        Me.objVoucher01Method.Text = "Voucher01Method"
        '
        'objCustomerTelp
        '
        Me.objCustomerTelp.AutoSize = True
        Me.objCustomerTelp.BackColor = System.Drawing.Color.LightSteelBlue
        Me.objCustomerTelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objCustomerTelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerTelp.Location = New System.Drawing.Point(186, 27)
        Me.objCustomerTelp.Name = "objCustomerTelp"
        Me.objCustomerTelp.Size = New System.Drawing.Size(54, 9)
        Me.objCustomerTelp.TabIndex = 17
        Me.objCustomerTelp.Text = "CustomerTelp"
        '
        'objCustomerType
        '
        Me.objCustomerType.AutoSize = True
        Me.objCustomerType.BackColor = System.Drawing.Color.LightSteelBlue
        Me.objCustomerType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objCustomerType.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerType.Location = New System.Drawing.Point(114, 27)
        Me.objCustomerType.Name = "objCustomerType"
        Me.objCustomerType.Size = New System.Drawing.Size(66, 9)
        Me.objCustomerType.TabIndex = 18
        Me.objCustomerType.Text = "objCustomerType"
        '
        'objCustomerDisc
        '
        Me.objCustomerDisc.AutoSize = True
        Me.objCustomerDisc.BackColor = System.Drawing.Color.LightSteelBlue
        Me.objCustomerDisc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objCustomerDisc.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerDisc.Location = New System.Drawing.Point(43, 27)
        Me.objCustomerDisc.Name = "objCustomerDisc"
        Me.objCustomerDisc.Size = New System.Drawing.Size(65, 9)
        Me.objCustomerDisc.TabIndex = 19
        Me.objCustomerDisc.Text = "objCustomerDisc"
        '
        'objCustomerPassport
        '
        Me.objCustomerPassport.AutoSize = True
        Me.objCustomerPassport.BackColor = System.Drawing.Color.LightSteelBlue
        Me.objCustomerPassport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objCustomerPassport.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerPassport.Location = New System.Drawing.Point(284, 36)
        Me.objCustomerPassport.Name = "objCustomerPassport"
        Me.objCustomerPassport.Size = New System.Drawing.Size(79, 9)
        Me.objCustomerPassport.TabIndex = 20
        Me.objCustomerPassport.Text = "objCustomerPassport"
        '
        'objBonExternal
        '
        Me.objBonExternal.AutoSize = True
        Me.objBonExternal.BackColor = System.Drawing.Color.PaleGreen
        Me.objBonExternal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objBonExternal.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objBonExternal.Location = New System.Drawing.Point(222, 36)
        Me.objBonExternal.Name = "objBonExternal"
        Me.objBonExternal.Size = New System.Drawing.Size(56, 9)
        Me.objBonExternal.TabIndex = 21
        Me.objBonExternal.Text = "objBonExternal"
        '
        'objBonEvent
        '
        Me.objBonEvent.AutoSize = True
        Me.objBonEvent.BackColor = System.Drawing.Color.Plum
        Me.objBonEvent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objBonEvent.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objBonEvent.Location = New System.Drawing.Point(169, 36)
        Me.objBonEvent.Name = "objBonEvent"
        Me.objBonEvent.Size = New System.Drawing.Size(47, 9)
        Me.objBonEvent.TabIndex = 22
        Me.objBonEvent.Text = "objBonEvent"
        '
        'objSiteIdFrom
        '
        Me.objSiteIdFrom.AutoSize = True
        Me.objSiteIdFrom.BackColor = System.Drawing.Color.DarkKhaki
        Me.objSiteIdFrom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objSiteIdFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objSiteIdFrom.Location = New System.Drawing.Point(126, 36)
        Me.objSiteIdFrom.Name = "objSiteIdFrom"
        Me.objSiteIdFrom.Size = New System.Drawing.Size(37, 9)
        Me.objSiteIdFrom.TabIndex = 23
        Me.objSiteIdFrom.Text = "SiteFrom"
        '
        'objStatusShow
        '
        Me.objStatusShow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.objStatusShow.AutoSize = True
        Me.objStatusShow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.objStatusShow.Location = New System.Drawing.Point(765, 192)
        Me.objStatusShow.Name = "objStatusShow"
        Me.objStatusShow.Size = New System.Drawing.Size(13, 13)
        Me.objStatusShow.TabIndex = 33
        Me.objStatusShow.Text = "<"
        '
        'objVoucherInformation
        '
        Me.objVoucherInformation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.objVoucherInformation.Location = New System.Drawing.Point(597, 34)
        Me.objVoucherInformation.Name = "objVoucherInformation"
        Me.objVoucherInformation.Size = New System.Drawing.Size(174, 13)
        Me.objVoucherInformation.TabIndex = 31
        Me.objVoucherInformation.Text = "$$$$$$$$$$$"
        Me.objVoucherInformation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(635, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(151, 13)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Voucher Information  [F2]"
        '
        'objPaymentShortcut
        '
        Me.objPaymentShortcut.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPaymentShortcut.Location = New System.Drawing.Point(10, 134)
        Me.objPaymentShortcut.Name = "objPaymentShortcut"
        Me.objPaymentShortcut.Size = New System.Drawing.Size(175, 54)
        Me.objPaymentShortcut.TabIndex = 29
        Me.objPaymentShortcut.Text = "Shortcut"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Gray
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(10, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(217, 1)
        Me.Label6.TabIndex = 22
        '
        'objTime
        '
        Me.objTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objTime.ForeColor = System.Drawing.Color.DimGray
        Me.objTime.Location = New System.Drawing.Point(137, 79)
        Me.objTime.Margin = New System.Windows.Forms.Padding(0)
        Me.objTime.Name = "objTime"
        Me.objTime.Size = New System.Drawing.Size(107, 40)
        Me.objTime.TabIndex = 28
        Me.objTime.Text = "00:00"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Gray
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(10, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(200, 1)
        Me.Label8.TabIndex = 24
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(10, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Date"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(10, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Machine ID"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gray
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(10, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(217, 1)
        Me.Label4.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(10, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Operator"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(319, 209)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(462, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "[F3] - Edit     [F4] - Payment     [F6] - Promo     [F8] - Delete"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gray
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(10, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(500, 1)
        Me.Label3.TabIndex = 6
        '
        'objPaymentTypeName
        '
        Me.objPaymentTypeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPaymentTypeName.Location = New System.Drawing.Point(250, 3)
        Me.objPaymentTypeName.Name = "objPaymentTypeName"
        Me.objPaymentTypeName.Size = New System.Drawing.Size(182, 29)
        Me.objPaymentTypeName.TabIndex = 3
        Me.objPaymentTypeName.Text = "Payment Type"
        '
        'objPaymentTypeId
        '
        Me.objPaymentTypeId.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPaymentTypeId.Location = New System.Drawing.Point(184, 9)
        Me.objPaymentTypeId.Name = "objPaymentTypeId"
        Me.objPaymentTypeId.Size = New System.Drawing.Size(61, 20)
        Me.objPaymentTypeId.TabIndex = 2
        Me.objPaymentTypeId.Text = "00000"
        Me.objPaymentTypeId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(10, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Payment Type"
        '
        'objPosOperator
        '
        Me.objPosOperator.ForeColor = System.Drawing.Color.Black
        Me.objPosOperator.Location = New System.Drawing.Point(71, 44)
        Me.objPosOperator.Name = "objPosOperator"
        Me.objPosOperator.Size = New System.Drawing.Size(139, 13)
        Me.objPosOperator.TabIndex = 25
        Me.objPosOperator.Text = "----"
        '
        'objPosMachineID
        '
        Me.objPosMachineID.ForeColor = System.Drawing.Color.Black
        Me.objPosMachineID.Location = New System.Drawing.Point(71, 67)
        Me.objPosMachineID.Name = "objPosMachineID"
        Me.objPosMachineID.Size = New System.Drawing.Size(139, 13)
        Me.objPosMachineID.TabIndex = 26
        Me.objPosMachineID.Text = "----"
        '
        'objPosDate
        '
        Me.objPosDate.ForeColor = System.Drawing.Color.Black
        Me.objPosDate.Location = New System.Drawing.Point(71, 89)
        Me.objPosDate.Name = "objPosDate"
        Me.objPosDate.Size = New System.Drawing.Size(139, 13)
        Me.objPosDate.TabIndex = 27
        Me.objPosDate.Text = "----"
        '
        'PnlPosMainH
        '
        Me.PnlPosMainH.BackColor = System.Drawing.Color.Transparent
        Me.PnlPosMainH.Controls.Add(Me.lblLocationStatus)
        Me.PnlPosMainH.Controls.Add(Me.objPosEventName)
        Me.PnlPosMainH.Controls.Add(Me.objPosCompanyName)
        Me.PnlPosMainH.Controls.Add(Me.lineItemDisplay)
        Me.PnlPosMainH.Controls.Add(Me.txtItemSelectedPrice)
        Me.PnlPosMainH.Controls.Add(Me.txtItemSelectedQty)
        Me.PnlPosMainH.Controls.Add(Me.txtItemSelectedName)
        Me.PnlPosMainH.Controls.Add(Me.txtItemEntry)
        Me.PnlPosMainH.Controls.Add(Me.lineSubtotal)
        Me.PnlPosMainH.Controls.Add(Me.lineQuantity)
        Me.PnlPosMainH.Controls.Add(Me.lblQuantity)
        Me.PnlPosMainH.Controls.Add(Me.txtCount)
        Me.PnlPosMainH.Controls.Add(Me.lblSubtotal)
        Me.PnlPosMainH.Controls.Add(Me.txtSubtotal)
        Me.PnlPosMainH.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlPosMainH.Location = New System.Drawing.Point(0, 0)
        Me.PnlPosMainH.Name = "PnlPosMainH"
        Me.PnlPosMainH.Size = New System.Drawing.Size(787, 133)
        Me.PnlPosMainH.TabIndex = 0
        '
        'lblLocationStatus
        '
        Me.lblLocationStatus.AutoSize = True
        Me.lblLocationStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblLocationStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocationStatus.Location = New System.Drawing.Point(15, 49)
        Me.lblLocationStatus.Name = "lblLocationStatus"
        Me.lblLocationStatus.Size = New System.Drawing.Size(70, 26)
        Me.lblLocationStatus.TabIndex = 28
        Me.lblLocationStatus.Text = "status"
        '
        'objPosEventName
        '
        Me.objPosEventName.ForeColor = System.Drawing.Color.Black
        Me.objPosEventName.Location = New System.Drawing.Point(17, 33)
        Me.objPosEventName.Name = "objPosEventName"
        Me.objPosEventName.Size = New System.Drawing.Size(410, 13)
        Me.objPosEventName.TabIndex = 27
        Me.objPosEventName.Text = "----"
        '
        'objPosCompanyName
        '
        Me.objPosCompanyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPosCompanyName.ForeColor = System.Drawing.Color.Black
        Me.objPosCompanyName.Location = New System.Drawing.Point(17, 13)
        Me.objPosCompanyName.Name = "objPosCompanyName"
        Me.objPosCompanyName.Size = New System.Drawing.Size(412, 20)
        Me.objPosCompanyName.TabIndex = 26
        Me.objPosCompanyName.Text = "PT. Trans Mahagaya"
        '
        'lineItemDisplay
        '
        Me.lineItemDisplay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lineItemDisplay.BackColor = System.Drawing.Color.Gray
        Me.lineItemDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lineItemDisplay.ForeColor = System.Drawing.Color.Gray
        Me.lineItemDisplay.Location = New System.Drawing.Point(3, 127)
        Me.lineItemDisplay.Name = "lineItemDisplay"
        Me.lineItemDisplay.Size = New System.Drawing.Size(779, 1)
        Me.lineItemDisplay.TabIndex = 7
        '
        'txtItemSelectedPrice
        '
        Me.txtItemSelectedPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtItemSelectedPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemSelectedPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemSelectedPrice.ForeColor = System.Drawing.Color.DimGray
        Me.txtItemSelectedPrice.Location = New System.Drawing.Point(584, 106)
        Me.txtItemSelectedPrice.Name = "txtItemSelectedPrice"
        Me.txtItemSelectedPrice.Size = New System.Drawing.Size(145, 22)
        Me.txtItemSelectedPrice.TabIndex = 10
        Me.txtItemSelectedPrice.Text = "$$$$$$$"
        Me.txtItemSelectedPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtItemSelectedQty
        '
        Me.txtItemSelectedQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtItemSelectedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemSelectedQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemSelectedQty.ForeColor = System.Drawing.Color.DimGray
        Me.txtItemSelectedQty.Location = New System.Drawing.Point(511, 106)
        Me.txtItemSelectedQty.Name = "txtItemSelectedQty"
        Me.txtItemSelectedQty.Size = New System.Drawing.Size(67, 22)
        Me.txtItemSelectedQty.TabIndex = 9
        Me.txtItemSelectedQty.Text = "$$$$$$$"
        Me.txtItemSelectedQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtItemSelectedName
        '
        Me.txtItemSelectedName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtItemSelectedName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemSelectedName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemSelectedName.ForeColor = System.Drawing.Color.DimGray
        Me.txtItemSelectedName.Location = New System.Drawing.Point(224, 106)
        Me.txtItemSelectedName.Name = "txtItemSelectedName"
        Me.txtItemSelectedName.Size = New System.Drawing.Size(281, 22)
        Me.txtItemSelectedName.TabIndex = 8
        Me.txtItemSelectedName.Text = "$$$$$$$"
        Me.txtItemSelectedName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtItemEntry
        '
        Me.txtItemEntry.BackColor = System.Drawing.Color.Gainsboro
        Me.txtItemEntry.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtItemEntry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemEntry.ForeColor = System.Drawing.Color.DimGray
        Me.txtItemEntry.Location = New System.Drawing.Point(11, 101)
        Me.txtItemEntry.MaxLength = 30
        Me.txtItemEntry.Name = "txtItemEntry"
        Me.txtItemEntry.Size = New System.Drawing.Size(183, 22)
        Me.txtItemEntry.TabIndex = 6
        '
        'lineSubtotal
        '
        Me.lineSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lineSubtotal.BackColor = System.Drawing.Color.Gray
        Me.lineSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lineSubtotal.ForeColor = System.Drawing.Color.Gray
        Me.lineSubtotal.Location = New System.Drawing.Point(466, 38)
        Me.lineSubtotal.Name = "lineSubtotal"
        Me.lineSubtotal.Size = New System.Drawing.Size(312, 1)
        Me.lineSubtotal.TabIndex = 2
        '
        'lineQuantity
        '
        Me.lineQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lineQuantity.BackColor = System.Drawing.Color.Gray
        Me.lineQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lineQuantity.ForeColor = System.Drawing.Color.Gray
        Me.lineQuantity.Location = New System.Drawing.Point(467, 72)
        Me.lineQuantity.Name = "lineQuantity"
        Me.lineQuantity.Size = New System.Drawing.Size(312, 1)
        Me.lineQuantity.TabIndex = 5
        '
        'lblQuantity
        '
        Me.lblQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuantity.ForeColor = System.Drawing.Color.DimGray
        Me.lblQuantity.Location = New System.Drawing.Point(467, 58)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(70, 13)
        Me.lblQuantity.TabIndex = 4
        Me.lblQuantity.Text = "QUANTITY"
        '
        'txtCount
        '
        Me.txtCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCount.Font = New System.Drawing.Font("Lucida Console", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCount.ForeColor = System.Drawing.Color.DimGray
        Me.txtCount.Location = New System.Drawing.Point(533, 38)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(251, 38)
        Me.txtCount.TabIndex = 3
        Me.txtCount.Text = "10"
        Me.txtCount.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblSubtotal
        '
        Me.lblSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSubtotal.AutoSize = True
        Me.lblSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtotal.ForeColor = System.Drawing.Color.DimGray
        Me.lblSubtotal.Location = New System.Drawing.Point(466, 24)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(72, 13)
        Me.lblSubtotal.TabIndex = 1
        Me.lblSubtotal.Text = "SUBTOTAL"
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubtotal.Font = New System.Drawing.Font("Lucida Console", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotal.ForeColor = System.Drawing.Color.DimGray
        Me.txtSubtotal.Location = New System.Drawing.Point(532, 4)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.Size = New System.Drawing.Size(251, 38)
        Me.txtSubtotal.TabIndex = 0
        Me.txtSubtotal.Text = "29,060,000,000"
        Me.txtSubtotal.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(258, 42)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 13)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "Available Promo:"
        '
        'PromoListContainer
        '
        Me.PromoListContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.PromoListContainer.Location = New System.Drawing.Point(261, 60)
        Me.PromoListContainer.Margin = New System.Windows.Forms.Padding(0)
        Me.PromoListContainer.Name = "PromoListContainer"
        Me.PromoListContainer.Size = New System.Drawing.Size(200, 100)
        Me.PromoListContainer.TabIndex = 39
        '
        'dlgTrnPosEN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(811, 601)
        Me.Controls.Add(Me.PnlPosMain)
        Me.DoubleBuffered = True
        Me.Name = "dlgTrnPosEN"
        Me.Controls.SetChildIndex(Me.PnlPosMain, 0)
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlPosMain.ResumeLayout(False)
        Me.PnlPosMainCenter.ResumeLayout(False)
        CType(Me.DgvPOSItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlPosMainF.ResumeLayout(False)
        Me.PnlPosMainF.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.PnlPosMainH.ResumeLayout(False)
        Me.PnlPosMainH.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlPosMain As System.Windows.Forms.Panel
    Friend WithEvents PnlPosMainH As System.Windows.Forms.Panel
    Friend WithEvents PnlPosMainF As System.Windows.Forms.Panel
    Friend WithEvents txtSubtotal As System.Windows.Forms.Label
    Friend WithEvents lblSubtotal As System.Windows.Forms.Label
    Friend WithEvents lineSubtotal As System.Windows.Forms.Label
    Friend WithEvents lineQuantity As System.Windows.Forms.Label
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents txtCount As System.Windows.Forms.Label
    Friend WithEvents txtItemEntry As System.Windows.Forms.TextBox
    Friend WithEvents lineItemDisplay As System.Windows.Forms.Label
    Friend WithEvents txtItemSelectedQty As System.Windows.Forms.Label
    Friend WithEvents txtItemSelectedName As System.Windows.Forms.Label
    Friend WithEvents txtItemSelectedPrice As System.Windows.Forms.Label
    Friend WithEvents DgvPOSItem As System.Windows.Forms.DataGridView
    Friend WithEvents PnlPosMainCenter As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents objPaymentTypeId As System.Windows.Forms.Label
    Friend WithEvents objPaymentTypeName As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents objPosOperator As System.Windows.Forms.Label
    Friend WithEvents objPosMachineID As System.Windows.Forms.Label
    Friend WithEvents objPosDate As System.Windows.Forms.Label
    Friend WithEvents objPosCompanyName As System.Windows.Forms.Label
    Friend WithEvents objPosEventName As System.Windows.Forms.Label
    Friend WithEvents objTime As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents objPaymentShortcut As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents objVoucherInformation As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents objCustomerNationalityId As System.Windows.Forms.Label
    Friend WithEvents objCustomerNationalityName As System.Windows.Forms.Label
    Friend WithEvents objStatusShow As System.Windows.Forms.Label
    Friend WithEvents objCustomerGenderId As System.Windows.Forms.Label
    Friend WithEvents objCustomerGenderName As System.Windows.Forms.Label
    Friend WithEvents objCustomerAgeId As System.Windows.Forms.Label
    Friend WithEvents objCustomerAgeName As System.Windows.Forms.Label
    Friend WithEvents objCustomerId As System.Windows.Forms.Label
    Friend WithEvents objCustomerName As System.Windows.Forms.Label
    Friend WithEvents objCustomerNPWP As System.Windows.Forms.Label
    Friend WithEvents objVoucher01Id As System.Windows.Forms.Label
    Friend WithEvents objVoucher01Name As System.Windows.Forms.Label
    Friend WithEvents objVoucher01CodeNum As System.Windows.Forms.Label
    Friend WithEvents objSalesId As System.Windows.Forms.Label
    Friend WithEvents objSalesName As System.Windows.Forms.Label
    Friend WithEvents objVoucher01Disc As System.Windows.Forms.Label
    Friend WithEvents objVoucher01Type As System.Windows.Forms.Label
    Friend WithEvents objVoucher01Method As System.Windows.Forms.Label
    Friend WithEvents objCustomerTelp As System.Windows.Forms.Label
    Friend WithEvents objCustomerType As System.Windows.Forms.Label
    Friend WithEvents objCustomerDisc As System.Windows.Forms.Label
    Friend WithEvents objCustomerPassport As System.Windows.Forms.Label
    Friend WithEvents objBonExternal As System.Windows.Forms.Label
    Friend WithEvents lblLocationStatus As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btn_PgDown As System.Windows.Forms.Label
    Friend WithEvents btn_PgUp As System.Windows.Forms.Label
    Friend WithEvents objBonEvent As System.Windows.Forms.Label
    Friend WithEvents objSiteIdFrom As System.Windows.Forms.Label
    Friend WithEvents txt_INFO As System.Windows.Forms.Label
    Friend WithEvents Label12 As Label
    Friend WithEvents PromoListContainer As FlowLayoutPanel
End Class
