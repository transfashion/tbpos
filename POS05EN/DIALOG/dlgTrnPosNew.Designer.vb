<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnPosNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgTrnPosNew))
        Me.PnlFormMain = New System.Windows.Forms.Panel
        Me.lbl_itemfrom = New System.Windows.Forms.Label
        Me.cbo_ItemFrom = New System.Windows.Forms.ComboBox
        Me.objCboBonEventMain = New System.Windows.Forms.ComboBox
        Me.objBonEvent = New System.Windows.Forms.TextBox
        Me.lblBonStamp = New System.Windows.Forms.Label
        Me.btnESC = New System.Windows.Forms.Label
        Me.objBonExternal = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.btnF10 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnSalesBrowse = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.objSalesId = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.objSalesName = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnTfiMembership = New System.Windows.Forms.Label
        Me.btnCtcorpMpcScan = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnCustomerSearch = New System.Windows.Forms.LinkLabel
        Me.objCustomerName = New System.Windows.Forms.TextBox
        Me.objCustomerTitle = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.objCustomerDisc = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.objCustomerType = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.objCustomerPassport = New System.Windows.Forms.TextBox
        Me.objCustomerTelp = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.btnCustomerBrowse = New System.Windows.Forms.Button
        Me.objCustomerGenderId = New System.Windows.Forms.Label
        Me.objCustomerNPWP = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.objCustomerId = New System.Windows.Forms.TextBox
        Me.lblGender = New System.Windows.Forms.Label
        Me.objCustomerGender = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Group01 = New System.Windows.Forms.GroupBox
        Me.btn_PgDown = New System.Windows.Forms.Label
        Me.btn_PgUp = New System.Windows.Forms.Label
        Me.objVoucher01Method = New System.Windows.Forms.Label
        Me.objVoucher01TypeId = New System.Windows.Forms.TextBox
        Me.objVoucher01Disc = New System.Windows.Forms.Label
        Me.objVoucher01Type = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.objVoucher01TypeName = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.objPaymentVoucher01Code = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.objCustomerAgeId = New System.Windows.Forms.Label
        Me.objCustomerNationalityId = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.objCustomerNationality = New System.Windows.Forms.Label
        Me.objCustomerAge = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlFormMain.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Group01.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlFormMain
        '
        Me.PnlFormMain.Controls.Add(Me.lbl_itemfrom)
        Me.PnlFormMain.Controls.Add(Me.cbo_ItemFrom)
        Me.PnlFormMain.Controls.Add(Me.objCboBonEventMain)
        Me.PnlFormMain.Controls.Add(Me.objBonEvent)
        Me.PnlFormMain.Controls.Add(Me.lblBonStamp)
        Me.PnlFormMain.Controls.Add(Me.btnESC)
        Me.PnlFormMain.Controls.Add(Me.objBonExternal)
        Me.PnlFormMain.Controls.Add(Me.Label22)
        Me.PnlFormMain.Controls.Add(Me.btnF10)
        Me.PnlFormMain.Controls.Add(Me.GroupBox2)
        Me.PnlFormMain.Controls.Add(Me.GroupBox1)
        Me.PnlFormMain.Controls.Add(Me.Group01)
        Me.PnlFormMain.Controls.Add(Me.Label4)
        Me.PnlFormMain.Location = New System.Drawing.Point(1, 3)
        Me.PnlFormMain.Name = "PnlFormMain"
        Me.PnlFormMain.Size = New System.Drawing.Size(609, 600)
        Me.PnlFormMain.TabIndex = 0
        '
        'lbl_itemfrom
        '
        Me.lbl_itemfrom.AutoSize = True
        Me.lbl_itemfrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_itemfrom.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbl_itemfrom.Location = New System.Drawing.Point(15, 522)
        Me.lbl_itemfrom.Name = "lbl_itemfrom"
        Me.lbl_itemfrom.Size = New System.Drawing.Size(48, 12)
        Me.lbl_itemfrom.TabIndex = 12
        Me.lbl_itemfrom.Text = "Item From"
        '
        'cbo_ItemFrom
        '
        Me.cbo_ItemFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_ItemFrom.FormattingEnabled = True
        Me.cbo_ItemFrom.Items.AddRange(New Object() {"REGULER", "e-BAZAR", "STAMP", "ONLINE", "CHAT", "CUSTOM"})
        Me.cbo_ItemFrom.Location = New System.Drawing.Point(71, 518)
        Me.cbo_ItemFrom.Name = "cbo_ItemFrom"
        Me.cbo_ItemFrom.Size = New System.Drawing.Size(178, 21)
        Me.cbo_ItemFrom.TabIndex = 11
        '
        'objCboBonEventMain
        '
        Me.objCboBonEventMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.objCboBonEventMain.FormattingEnabled = True
        Me.objCboBonEventMain.Items.AddRange(New Object() {"REGULER", "e-BAZAR", "STAMP", "ONLINE", "CHAT", "CUSTOM"})
        Me.objCboBonEventMain.Location = New System.Drawing.Point(71, 488)
        Me.objCboBonEventMain.Name = "objCboBonEventMain"
        Me.objCboBonEventMain.Size = New System.Drawing.Size(86, 21)
        Me.objCboBonEventMain.TabIndex = 10
        '
        'objBonEvent
        '
        Me.objBonEvent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.objBonEvent.Enabled = False
        Me.objBonEvent.Location = New System.Drawing.Point(163, 488)
        Me.objBonEvent.MaxLength = 11
        Me.objBonEvent.Name = "objBonEvent"
        Me.objBonEvent.Size = New System.Drawing.Size(150, 20)
        Me.objBonEvent.TabIndex = 9
        '
        'lblBonStamp
        '
        Me.lblBonStamp.AutoSize = True
        Me.lblBonStamp.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBonStamp.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblBonStamp.Location = New System.Drawing.Point(15, 495)
        Me.lblBonStamp.Name = "lblBonStamp"
        Me.lblBonStamp.Size = New System.Drawing.Size(30, 12)
        Me.lblBonStamp.TabIndex = 8
        Me.lblBonStamp.Text = "Event"
        '
        'btnESC
        '
        Me.btnESC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnESC.AutoSize = True
        Me.btnESC.BackColor = System.Drawing.Color.LightGray
        Me.btnESC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnESC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnESC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnESC.Location = New System.Drawing.Point(277, 568)
        Me.btnESC.Name = "btnESC"
        Me.btnESC.Padding = New System.Windows.Forms.Padding(2)
        Me.btnESC.Size = New System.Drawing.Size(167, 26)
        Me.btnESC.TabIndex = 7
        Me.btnESC.Text = "     ESC - Cancel    "
        '
        'objBonExternal
        '
        Me.objBonExternal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.objBonExternal.Enabled = False
        Me.objBonExternal.Location = New System.Drawing.Point(443, 488)
        Me.objBonExternal.MaxLength = 50
        Me.objBonExternal.Name = "objBonExternal"
        Me.objBonExternal.Size = New System.Drawing.Size(140, 20)
        Me.objBonExternal.TabIndex = 5
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label22.Location = New System.Drawing.Point(383, 491)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(51, 12)
        Me.Label22.TabIndex = 4
        Me.Label22.Text = "External ID"
        '
        'btnF10
        '
        Me.btnF10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnF10.AutoSize = True
        Me.btnF10.BackColor = System.Drawing.Color.LightGray
        Me.btnF10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnF10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnF10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF10.Location = New System.Drawing.Point(456, 568)
        Me.btnF10.Name = "btnF10"
        Me.btnF10.Padding = New System.Windows.Forms.Padding(2)
        Me.btnF10.Size = New System.Drawing.Size(136, 26)
        Me.btnF10.TabIndex = 6
        Me.btnF10.Text = "     F10 - OK     "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.btnSalesBrowse)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.objSalesId)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.objSalesName)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 406)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(594, 73)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sales Person"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label24.Location = New System.Drawing.Point(199, 51)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(193, 12)
        Me.Label24.TabIndex = 24
        Me.Label24.Text = "Tekan [Alt] + [S] untuk shortcut ke Sales Code"
        Me.Label24.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label23.Location = New System.Drawing.Point(167, 51)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(30, 12)
        Me.Label23.TabIndex = 23
        Me.Label23.Text = "Tips:"
        Me.Label23.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(28, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(28, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "[F5 ]"
        '
        'btnSalesBrowse
        '
        Me.btnSalesBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalesBrowse.Location = New System.Drawing.Point(553, 26)
        Me.btnSalesBrowse.Name = "btnSalesBrowse"
        Me.btnSalesBrowse.Size = New System.Drawing.Size(21, 18)
        Me.btnSalesBrowse.TabIndex = 4
        Me.btnSalesBrowse.Text = "..."
        Me.btnSalesBrowse.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.DarkGray
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(169, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(405, 1)
        Me.Label9.TabIndex = 5
        '
        'objSalesId
        '
        Me.objSalesId.BackColor = System.Drawing.Color.Gainsboro
        Me.objSalesId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.objSalesId.Location = New System.Drawing.Point(169, 26)
        Me.objSalesId.MaxLength = 30
        Me.objSalesId.Name = "objSalesId"
        Me.objSalesId.ReadOnly = True
        Me.objSalesId.Size = New System.Drawing.Size(66, 20)
        Me.objSalesId.TabIndex = 2
        Me.objSalesId.Text = "0"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(91, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 15)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "&Sales.Code"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'objSalesName
        '
        Me.objSalesName.Location = New System.Drawing.Point(244, 29)
        Me.objSalesName.Name = "objSalesName"
        Me.objSalesName.Size = New System.Drawing.Size(288, 23)
        Me.objSalesName.TabIndex = 3
        Me.objSalesName.Text = "NONE"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnTfiMembership)
        Me.GroupBox1.Controls.Add(Me.btnCtcorpMpcScan)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.btnCustomerSearch)
        Me.GroupBox1.Controls.Add(Me.objCustomerName)
        Me.GroupBox1.Controls.Add(Me.objCustomerTitle)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.objCustomerDisc)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.objCustomerType)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.objCustomerPassport)
        Me.GroupBox1.Controls.Add(Me.objCustomerTelp)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.btnCustomerBrowse)
        Me.GroupBox1.Controls.Add(Me.objCustomerGenderId)
        Me.GroupBox1.Controls.Add(Me.objCustomerNPWP)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.objCustomerId)
        Me.GroupBox1.Controls.Add(Me.lblGender)
        Me.GroupBox1.Controls.Add(Me.objCustomerGender)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(594, 246)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Customer Information"
        '
        'btnTfiMembership
        '
        Me.btnTfiMembership.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTfiMembership.AutoSize = True
        Me.btnTfiMembership.BackColor = System.Drawing.Color.LightGray
        Me.btnTfiMembership.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnTfiMembership.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTfiMembership.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTfiMembership.Image = CType(resources.GetObject("btnTfiMembership.Image"), System.Drawing.Image)
        Me.btnTfiMembership.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTfiMembership.Location = New System.Drawing.Point(169, 127)
        Me.btnTfiMembership.Name = "btnTfiMembership"
        Me.btnTfiMembership.Padding = New System.Windows.Forms.Padding(2)
        Me.btnTfiMembership.Size = New System.Drawing.Size(194, 26)
        Me.btnTfiMembership.TabIndex = 34
        Me.btnTfiMembership.Text = "       TFI Membership   "
        Me.btnTfiMembership.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCtcorpMpcScan
        '
        Me.btnCtcorpMpcScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCtcorpMpcScan.AutoSize = True
        Me.btnCtcorpMpcScan.BackColor = System.Drawing.Color.LightGray
        Me.btnCtcorpMpcScan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnCtcorpMpcScan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCtcorpMpcScan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCtcorpMpcScan.Image = CType(resources.GetObject("btnCtcorpMpcScan.Image"), System.Drawing.Image)
        Me.btnCtcorpMpcScan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCtcorpMpcScan.Location = New System.Drawing.Point(371, 127)
        Me.btnCtcorpMpcScan.Name = "btnCtcorpMpcScan"
        Me.btnCtcorpMpcScan.Padding = New System.Windows.Forms.Padding(2)
        Me.btnCtcorpMpcScan.Size = New System.Drawing.Size(102, 26)
        Me.btnCtcorpMpcScan.TabIndex = 33
        Me.btnCtcorpMpcScan.Text = "       MPC   "
        Me.btnCtcorpMpcScan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Crimson
        Me.Label26.Location = New System.Drawing.Point(120, 179)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(409, 31)
        Me.Label26.TabIndex = 31
        Me.Label26.Text = "Apabila customer bersedia menerima copy bon ke email, isikan email customer pada " & _
            "text berikut:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(241, 105)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(115, 12)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = ")* harus terkoneksi internet"
        '
        'btnCustomerSearch
        '
        Me.btnCustomerSearch.AutoSize = True
        Me.btnCustomerSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCustomerSearch.Location = New System.Drawing.Point(169, 104)
        Me.btnCustomerSearch.Name = "btnCustomerSearch"
        Me.btnCustomerSearch.Size = New System.Drawing.Size(72, 13)
        Me.btnCustomerSearch.TabIndex = 29
        Me.btnCustomerSearch.TabStop = True
        Me.btnCustomerSearch.Text = "Cari Customer"
        '
        'objCustomerName
        '
        Me.objCustomerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.objCustomerName.Location = New System.Drawing.Point(209, 80)
        Me.objCustomerName.MaxLength = 30
        Me.objCustomerName.Name = "objCustomerName"
        Me.objCustomerName.Size = New System.Drawing.Size(174, 20)
        Me.objCustomerName.TabIndex = 16
        '
        'objCustomerTitle
        '
        Me.objCustomerTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerTitle.Location = New System.Drawing.Point(165, 81)
        Me.objCustomerTitle.Name = "objCustomerTitle"
        Me.objCustomerTitle.Size = New System.Drawing.Size(38, 20)
        Me.objCustomerTitle.TabIndex = 28
        Me.objCustomerTitle.Text = "Ms."
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(441, 104)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(82, 12)
        Me.Label25.TabIndex = 27
        Me.Label25.Text = "ex:  081563453234"
        '
        'objCustomerDisc
        '
        Me.objCustomerDisc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.objCustomerDisc.Enabled = False
        Me.objCustomerDisc.Location = New System.Drawing.Point(549, 52)
        Me.objCustomerDisc.MaxLength = 50
        Me.objCustomerDisc.Name = "objCustomerDisc"
        Me.objCustomerDisc.Size = New System.Drawing.Size(31, 20)
        Me.objCustomerDisc.TabIndex = 26
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label21.Location = New System.Drawing.Point(521, 57)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(24, 12)
        Me.Label21.TabIndex = 25
        Me.Label21.Text = "Disc"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label20.Location = New System.Drawing.Point(385, 56)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(25, 12)
        Me.Label20.TabIndex = 24
        Me.Label20.Text = "Type"
        '
        'objCustomerType
        '
        Me.objCustomerType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.objCustomerType.Enabled = False
        Me.objCustomerType.Location = New System.Drawing.Point(413, 52)
        Me.objCustomerType.MaxLength = 50
        Me.objCustomerType.Name = "objCustomerType"
        Me.objCustomerType.Size = New System.Drawing.Size(95, 20)
        Me.objCustomerType.TabIndex = 23
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label19.Location = New System.Drawing.Point(131, 217)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(28, 12)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = "&Email"
        '
        'objCustomerPassport
        '
        Me.objCustomerPassport.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.objCustomerPassport.Location = New System.Drawing.Point(172, 213)
        Me.objCustomerPassport.MaxLength = 50
        Me.objCustomerPassport.Name = "objCustomerPassport"
        Me.objCustomerPassport.Size = New System.Drawing.Size(321, 20)
        Me.objCustomerPassport.TabIndex = 21
        '
        'objCustomerTelp
        '
        Me.objCustomerTelp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.objCustomerTelp.Location = New System.Drawing.Point(440, 81)
        Me.objCustomerTelp.MaxLength = 15
        Me.objCustomerTelp.Name = "objCustomerTelp"
        Me.objCustomerTelp.Size = New System.Drawing.Size(140, 20)
        Me.objCustomerTelp.TabIndex = 18
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label18.Location = New System.Drawing.Point(412, 84)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(18, 12)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "HP"
        '
        'btnCustomerBrowse
        '
        Me.btnCustomerBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomerBrowse.Location = New System.Drawing.Point(306, 53)
        Me.btnCustomerBrowse.Name = "btnCustomerBrowse"
        Me.btnCustomerBrowse.Size = New System.Drawing.Size(21, 20)
        Me.btnCustomerBrowse.TabIndex = 14
        Me.btnCustomerBrowse.Text = "..."
        Me.btnCustomerBrowse.UseVisualStyleBackColor = True
        '
        'objCustomerGenderId
        '
        Me.objCustomerGenderId.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerGenderId.ForeColor = System.Drawing.Color.MidnightBlue
        Me.objCustomerGenderId.Location = New System.Drawing.Point(544, 33)
        Me.objCustomerGenderId.Name = "objCustomerGenderId"
        Me.objCustomerGenderId.Size = New System.Drawing.Size(35, 12)
        Me.objCustomerGenderId.TabIndex = 7
        Me.objCustomerGenderId.Text = "$$$$$"
        Me.objCustomerGenderId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'objCustomerNPWP
        '
        Me.objCustomerNPWP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.objCustomerNPWP.Location = New System.Drawing.Point(542, 213)
        Me.objCustomerNPWP.MaxLength = 30
        Me.objCustomerNPWP.Name = "objCustomerNPWP"
        Me.objCustomerNPWP.Size = New System.Drawing.Size(37, 20)
        Me.objCustomerNPWP.TabIndex = 20
        Me.objCustomerNPWP.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label16.Location = New System.Drawing.Point(499, 216)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(33, 12)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "N&PWP"
        Me.Label16.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label15.Location = New System.Drawing.Point(129, 84)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 12)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "&Name"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label14.Location = New System.Drawing.Point(144, 56)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(15, 12)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "&ID"
        '
        'objCustomerId
        '
        Me.objCustomerId.Enabled = False
        Me.objCustomerId.Location = New System.Drawing.Point(169, 53)
        Me.objCustomerId.MaxLength = 10
        Me.objCustomerId.Name = "objCustomerId"
        Me.objCustomerId.Size = New System.Drawing.Size(134, 20)
        Me.objCustomerId.TabIndex = 13
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGender.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblGender.Location = New System.Drawing.Point(124, 32)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(35, 12)
        Me.lblGender.TabIndex = 5
        Me.lblGender.Text = "Gender"
        '
        'objCustomerGender
        '
        Me.objCustomerGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerGender.Location = New System.Drawing.Point(165, 27)
        Me.objCustomerGender.Name = "objCustomerGender"
        Me.objCustomerGender.Size = New System.Drawing.Size(129, 20)
        Me.objCustomerGender.TabIndex = 6
        Me.objCustomerGender.Text = "NONE"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(28, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "[F2 ]"
        '
        'Group01
        '
        Me.Group01.Controls.Add(Me.btn_PgDown)
        Me.Group01.Controls.Add(Me.btn_PgUp)
        Me.Group01.Controls.Add(Me.objVoucher01Method)
        Me.Group01.Controls.Add(Me.objVoucher01TypeId)
        Me.Group01.Controls.Add(Me.objVoucher01Disc)
        Me.Group01.Controls.Add(Me.objVoucher01Type)
        Me.Group01.Controls.Add(Me.Label17)
        Me.Group01.Controls.Add(Me.Label3)
        Me.Group01.Controls.Add(Me.objVoucher01TypeName)
        Me.Group01.Controls.Add(Me.Label5)
        Me.Group01.Controls.Add(Me.Label2)
        Me.Group01.Controls.Add(Me.objPaymentVoucher01Code)
        Me.Group01.Location = New System.Drawing.Point(9, 278)
        Me.Group01.Name = "Group01"
        Me.Group01.Size = New System.Drawing.Size(595, 122)
        Me.Group01.TabIndex = 2
        Me.Group01.TabStop = False
        Me.Group01.Text = "Voucher Item Discount"
        '
        'btn_PgDown
        '
        Me.btn_PgDown.AutoSize = True
        Me.btn_PgDown.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_PgDown.Font = New System.Drawing.Font("Arial", 6.75!)
        Me.btn_PgDown.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btn_PgDown.Location = New System.Drawing.Point(22, 16)
        Me.btn_PgDown.Name = "btn_PgDown"
        Me.btn_PgDown.Size = New System.Drawing.Size(16, 12)
        Me.btn_PgDown.TabIndex = 11
        Me.btn_PgDown.Text = "[<]"
        '
        'btn_PgUp
        '
        Me.btn_PgUp.AutoSize = True
        Me.btn_PgUp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_PgUp.Font = New System.Drawing.Font("Arial", 6.75!)
        Me.btn_PgUp.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btn_PgUp.Location = New System.Drawing.Point(564, 16)
        Me.btn_PgUp.Name = "btn_PgUp"
        Me.btn_PgUp.Size = New System.Drawing.Size(16, 12)
        Me.btn_PgUp.TabIndex = 10
        Me.btn_PgUp.Text = "[>]"
        '
        'objVoucher01Method
        '
        Me.objVoucher01Method.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objVoucher01Method.ForeColor = System.Drawing.Color.MidnightBlue
        Me.objVoucher01Method.Location = New System.Drawing.Point(515, 78)
        Me.objVoucher01Method.Name = "objVoucher01Method"
        Me.objVoucher01Method.Size = New System.Drawing.Size(67, 12)
        Me.objVoucher01Method.TabIndex = 9
        Me.objVoucher01Method.Text = "$$$$$"
        Me.objVoucher01Method.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'objVoucher01TypeId
        '
        Me.objVoucher01TypeId.BackColor = System.Drawing.Color.Gainsboro
        Me.objVoucher01TypeId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.objVoucher01TypeId.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.objVoucher01TypeId.Location = New System.Drawing.Point(173, 31)
        Me.objVoucher01TypeId.MaxLength = 10
        Me.objVoucher01TypeId.Name = "objVoucher01TypeId"
        Me.objVoucher01TypeId.ReadOnly = True
        Me.objVoucher01TypeId.Size = New System.Drawing.Size(61, 23)
        Me.objVoucher01TypeId.TabIndex = 1
        Me.objVoucher01TypeId.Text = "00000"
        '
        'objVoucher01Disc
        '
        Me.objVoucher01Disc.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objVoucher01Disc.ForeColor = System.Drawing.Color.MidnightBlue
        Me.objVoucher01Disc.Location = New System.Drawing.Point(547, 54)
        Me.objVoucher01Disc.Name = "objVoucher01Disc"
        Me.objVoucher01Disc.Size = New System.Drawing.Size(35, 12)
        Me.objVoucher01Disc.TabIndex = 5
        Me.objVoucher01Disc.Text = "$$$$$"
        Me.objVoucher01Disc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'objVoucher01Type
        '
        Me.objVoucher01Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objVoucher01Type.ForeColor = System.Drawing.Color.MidnightBlue
        Me.objVoucher01Type.Location = New System.Drawing.Point(547, 40)
        Me.objVoucher01Type.Name = "objVoucher01Type"
        Me.objVoucher01Type.Size = New System.Drawing.Size(35, 12)
        Me.objVoucher01Type.TabIndex = 3
        Me.objVoucher01Type.Text = "$$$$$"
        Me.objVoucher01Type.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(29, 73)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(28, 13)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "[F4 ]"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DarkGray
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(20, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(560, 1)
        Me.Label3.TabIndex = 4
        '
        'objVoucher01TypeName
        '
        Me.objVoucher01TypeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objVoucher01TypeName.Location = New System.Drawing.Point(240, 33)
        Me.objVoucher01TypeName.Name = "objVoucher01TypeName"
        Me.objVoucher01TypeName.Size = New System.Drawing.Size(301, 21)
        Me.objVoucher01TypeName.TabIndex = 2
        Me.objVoucher01TypeName.Text = "Voucher Type"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 6.75!)
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(20, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(142, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Voucher Type  [PgUp] / [PgDwn]"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(92, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "&Voucher.Code"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'objPaymentVoucher01Code
        '
        Me.objPaymentVoucher01Code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.objPaymentVoucher01Code.Location = New System.Drawing.Point(170, 70)
        Me.objPaymentVoucher01Code.MaxLength = 30
        Me.objPaymentVoucher01Code.Name = "objPaymentVoucher01Code"
        Me.objPaymentVoucher01Code.Size = New System.Drawing.Size(337, 20)
        Me.objPaymentVoucher01Code.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.Black
        Me.Label4.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(603, 18)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = ":: Enter Next Transaction ::"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'objCustomerAgeId
        '
        Me.objCustomerAgeId.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerAgeId.ForeColor = System.Drawing.Color.MidnightBlue
        Me.objCustomerAgeId.Location = New System.Drawing.Point(533, 47)
        Me.objCustomerAgeId.Name = "objCustomerAgeId"
        Me.objCustomerAgeId.Size = New System.Drawing.Size(35, 12)
        Me.objCustomerAgeId.TabIndex = 11
        Me.objCustomerAgeId.Text = "$$$$$"
        Me.objCustomerAgeId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'objCustomerNationalityId
        '
        Me.objCustomerNationalityId.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerNationalityId.ForeColor = System.Drawing.Color.MidnightBlue
        Me.objCustomerNationalityId.Location = New System.Drawing.Point(533, 22)
        Me.objCustomerNationalityId.Name = "objCustomerNationalityId"
        Me.objCustomerNationalityId.Size = New System.Drawing.Size(35, 12)
        Me.objCustomerNationalityId.TabIndex = 3
        Me.objCustomerNationalityId.Text = "$$$$$"
        Me.objCustomerNationalityId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label13.Location = New System.Drawing.Point(126, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(22, 12)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Age"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label11.Location = New System.Drawing.Point(99, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 12)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Nationality"
        '
        'objCustomerNationality
        '
        Me.objCustomerNationality.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerNationality.Location = New System.Drawing.Point(154, 17)
        Me.objCustomerNationality.Name = "objCustomerNationality"
        Me.objCustomerNationality.Size = New System.Drawing.Size(129, 20)
        Me.objCustomerNationality.TabIndex = 2
        Me.objCustomerNationality.Text = "INDONESIA"
        '
        'objCustomerAge
        '
        Me.objCustomerAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objCustomerAge.Location = New System.Drawing.Point(154, 41)
        Me.objCustomerAge.Name = "objCustomerAge"
        Me.objCustomerAge.Size = New System.Drawing.Size(129, 20)
        Me.objCustomerAge.TabIndex = 10
        Me.objCustomerAge.Text = "0 s/d 10"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "[F3 ]"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "[F1 ]"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.objCustomerNationality)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.objCustomerNationalityId)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.objCustomerAge)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.objCustomerAgeId)
        Me.Panel1.Location = New System.Drawing.Point(616, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(665, 258)
        Me.Panel1.TabIndex = 3
        '
        'dlgTrnPosNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(614, 606)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PnlFormMain)
        Me.Name = "dlgTrnPosNew"
        Me.Controls.SetChildIndex(Me.PnlFormMain, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlFormMain.ResumeLayout(False)
        Me.PnlFormMain.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Group01.ResumeLayout(False)
        Me.Group01.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlFormMain As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Group01 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents objPaymentVoucher01Code As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents objVoucher01TypeName As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents objCustomerAge As System.Windows.Forms.Label
    Friend WithEvents objCustomerGender As System.Windows.Forms.Label
    Friend WithEvents objCustomerNationality As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents objCustomerId As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents objCustomerNPWP As System.Windows.Forms.TextBox
    Friend WithEvents objCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnF10 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents objCustomerAgeId As System.Windows.Forms.Label
    Friend WithEvents objCustomerGenderId As System.Windows.Forms.Label
    Friend WithEvents objCustomerNationalityId As System.Windows.Forms.Label
    Friend WithEvents objSalesId As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnSalesBrowse As System.Windows.Forms.Button
    Friend WithEvents objSalesName As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnCustomerBrowse As System.Windows.Forms.Button
    Friend WithEvents objCustomerTelp As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents objVoucher01Disc As System.Windows.Forms.Label
    Friend WithEvents objVoucher01Type As System.Windows.Forms.Label
    Friend WithEvents objVoucher01TypeId As System.Windows.Forms.TextBox
    Friend WithEvents objVoucher01Method As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents objCustomerPassport As System.Windows.Forms.TextBox
    Friend WithEvents objCustomerDisc As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents objCustomerType As System.Windows.Forms.TextBox
    Friend WithEvents objBonExternal As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents objCustomerTitle As System.Windows.Forms.Label
    Friend WithEvents btnCustomerSearch As System.Windows.Forms.LinkLabel
    Friend WithEvents btnESC As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents objBonEvent As System.Windows.Forms.TextBox
    Friend WithEvents lblBonStamp As System.Windows.Forms.Label
    Friend WithEvents objCboBonEventMain As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCtcorpMpcScan As System.Windows.Forms.Label
    Friend WithEvents btn_PgDown As System.Windows.Forms.Label
    Friend WithEvents btn_PgUp As System.Windows.Forms.Label
    Friend WithEvents lbl_itemfrom As System.Windows.Forms.Label
    Friend WithEvents cbo_ItemFrom As System.Windows.Forms.ComboBox
    Friend WithEvents btnTfiMembership As System.Windows.Forms.Label

End Class
