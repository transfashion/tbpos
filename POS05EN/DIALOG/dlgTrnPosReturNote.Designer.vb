<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnPosReturNote
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
        Me.components = New System.ComponentModel.Container
        Me.PnlPosMain = New System.Windows.Forms.Panel
        Me.PnlPosMainCenter = New System.Windows.Forms.SplitContainer
        Me.PanelPOSItem = New System.Windows.Forms.Panel
        Me.DgvPOSItem = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.objPaymentTOTAL = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.objPaymentDiscValue = New System.Windows.Forms.Label
        Me.objPaymentDiscDescr = New System.Windows.Forms.Label
        Me.objPaymentDiscVoucherTotal = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.objPaymentTotalQty = New System.Windows.Forms.Label
        Me.objPaymentTotalValue = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DgvPayments = New System.Windows.Forms.DataGridView
        Me.PanelRetur = New System.Windows.Forms.Panel
        Me.btnReturnCancel = New System.Windows.Forms.Button
        Me.PanelReturnConfirm = New System.Windows.Forms.Panel
        Me.objItemRetDescr = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.objItemRetQtyMax = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.objItemRetBonReplacement = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.objItemRetQty = New System.Windows.Forms.TextBox
        Me.btnReturnConfirmCancel = New System.Windows.Forms.Button
        Me.btnReturnConfirmExecute = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnReturn = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.objItemPrice = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.objItemSubtotal = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.objItemQty = New System.Windows.Forms.Label
        Me.objItemDescr = New System.Windows.Forms.Label
        Me.objItemArtMatCol = New System.Windows.Forms.Label
        Me.objItemId = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PnlPosMainF = New System.Windows.Forms.Panel
        Me.PnlPosMainH = New System.Windows.Forms.Panel
        Me.objBonId = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.objPosEventName = New System.Windows.Forms.Label
        Me.objPosCompanyName = New System.Windows.Forms.Label
        Me.lineItemDisplay = New System.Windows.Forms.Label
        Me.lineSubtotal = New System.Windows.Forms.Label
        Me.lineQuantity = New System.Windows.Forms.Label
        Me.lblQuantity = New System.Windows.Forms.Label
        Me.txtCount = New System.Windows.Forms.Label
        Me.lblSubtotal = New System.Windows.Forms.Label
        Me.txtSubtotal = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlPosMain.SuspendLayout()
        Me.PnlPosMainCenter.Panel1.SuspendLayout()
        Me.PnlPosMainCenter.Panel2.SuspendLayout()
        Me.PnlPosMainCenter.SuspendLayout()
        Me.PanelPOSItem.SuspendLayout()
        CType(Me.DgvPOSItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DgvPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelRetur.SuspendLayout()
        Me.PanelReturnConfirm.SuspendLayout()
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
        Me.PnlPosMain.Size = New System.Drawing.Size(787, 471)
        Me.PnlPosMain.TabIndex = 3
        '
        'PnlPosMainCenter
        '
        Me.PnlPosMainCenter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlPosMainCenter.Location = New System.Drawing.Point(6, 100)
        Me.PnlPosMainCenter.Name = "PnlPosMainCenter"
        '
        'PnlPosMainCenter.Panel1
        '
        Me.PnlPosMainCenter.Panel1.Controls.Add(Me.PanelPOSItem)
        Me.PnlPosMainCenter.Panel1.Controls.Add(Me.Panel1)
        '
        'PnlPosMainCenter.Panel2
        '
        Me.PnlPosMainCenter.Panel2.Controls.Add(Me.PanelRetur)
        Me.PnlPosMainCenter.Size = New System.Drawing.Size(772, 338)
        Me.PnlPosMainCenter.SplitterDistance = 433
        Me.PnlPosMainCenter.TabIndex = 2
        '
        'PanelPOSItem
        '
        Me.PanelPOSItem.Controls.Add(Me.DgvPOSItem)
        Me.PanelPOSItem.Location = New System.Drawing.Point(15, 13)
        Me.PanelPOSItem.Name = "PanelPOSItem"
        Me.PanelPOSItem.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.PanelPOSItem.Size = New System.Drawing.Size(329, 70)
        Me.PanelPOSItem.TabIndex = 2
        '
        'DgvPOSItem
        '
        Me.DgvPOSItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPOSItem.Location = New System.Drawing.Point(92, 14)
        Me.DgvPOSItem.Name = "DgvPOSItem"
        Me.DgvPOSItem.Size = New System.Drawing.Size(111, 42)
        Me.DgvPOSItem.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.objPaymentTOTAL)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.objPaymentDiscValue)
        Me.Panel1.Controls.Add(Me.objPaymentDiscDescr)
        Me.Panel1.Controls.Add(Me.objPaymentDiscVoucherTotal)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.objPaymentTotalQty)
        Me.Panel1.Controls.Add(Me.objPaymentTotalValue)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DgvPayments)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 130)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(10, 0, 0, 10)
        Me.Panel1.Size = New System.Drawing.Size(433, 208)
        Me.Panel1.TabIndex = 1
        '
        'objPaymentTOTAL
        '
        Me.objPaymentTOTAL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.objPaymentTOTAL.BackColor = System.Drawing.Color.Transparent
        Me.objPaymentTOTAL.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPaymentTOTAL.ForeColor = System.Drawing.Color.MidnightBlue
        Me.objPaymentTOTAL.Location = New System.Drawing.Point(278, 169)
        Me.objPaymentTOTAL.Name = "objPaymentTOTAL"
        Me.objPaymentTOTAL.Size = New System.Drawing.Size(155, 29)
        Me.objPaymentTOTAL.TabIndex = 52
        Me.objPaymentTOTAL.Text = "99,000,000"
        Me.objPaymentTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(336, 151)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 18)
        Me.Label11.TabIndex = 51
        Me.Label11.Text = "TOTAL"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'objPaymentDiscValue
        '
        Me.objPaymentDiscValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.objPaymentDiscValue.BackColor = System.Drawing.Color.Transparent
        Me.objPaymentDiscValue.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPaymentDiscValue.ForeColor = System.Drawing.Color.DimGray
        Me.objPaymentDiscValue.Location = New System.Drawing.Point(284, 127)
        Me.objPaymentDiscValue.Name = "objPaymentDiscValue"
        Me.objPaymentDiscValue.Size = New System.Drawing.Size(145, 24)
        Me.objPaymentDiscValue.TabIndex = 50
        Me.objPaymentDiscValue.Text = "99,000,000"
        Me.objPaymentDiscValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'objPaymentDiscDescr
        '
        Me.objPaymentDiscDescr.BackColor = System.Drawing.Color.Transparent
        Me.objPaymentDiscDescr.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPaymentDiscDescr.Location = New System.Drawing.Point(337, 112)
        Me.objPaymentDiscDescr.Name = "objPaymentDiscDescr"
        Me.objPaymentDiscDescr.Size = New System.Drawing.Size(303, 15)
        Me.objPaymentDiscDescr.TabIndex = 49
        Me.objPaymentDiscDescr.Text = "Using MEGA VISA with additioal disc 10%"
        Me.objPaymentDiscDescr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'objPaymentDiscVoucherTotal
        '
        Me.objPaymentDiscVoucherTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.objPaymentDiscVoucherTotal.BackColor = System.Drawing.Color.Transparent
        Me.objPaymentDiscVoucherTotal.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPaymentDiscVoucherTotal.ForeColor = System.Drawing.Color.DimGray
        Me.objPaymentDiscVoucherTotal.Location = New System.Drawing.Point(284, 86)
        Me.objPaymentDiscVoucherTotal.Name = "objPaymentDiscVoucherTotal"
        Me.objPaymentDiscVoucherTotal.Size = New System.Drawing.Size(145, 24)
        Me.objPaymentDiscVoucherTotal.TabIndex = 48
        Me.objPaymentDiscVoucherTotal.Text = "99,000,000"
        Me.objPaymentDiscVoucherTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(337, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(177, 15)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "Additional Disc / Voucher "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(378, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 15)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "item(s),  TOTAL VALUE"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'objPaymentTotalQty
        '
        Me.objPaymentTotalQty.BackColor = System.Drawing.Color.Transparent
        Me.objPaymentTotalQty.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPaymentTotalQty.Location = New System.Drawing.Point(335, 25)
        Me.objPaymentTotalQty.Name = "objPaymentTotalQty"
        Me.objPaymentTotalQty.Size = New System.Drawing.Size(56, 24)
        Me.objPaymentTotalQty.TabIndex = 45
        Me.objPaymentTotalQty.Text = "999"
        Me.objPaymentTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'objPaymentTotalValue
        '
        Me.objPaymentTotalValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.objPaymentTotalValue.BackColor = System.Drawing.Color.Transparent
        Me.objPaymentTotalValue.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPaymentTotalValue.Location = New System.Drawing.Point(284, 47)
        Me.objPaymentTotalValue.Name = "objPaymentTotalValue"
        Me.objPaymentTotalValue.Size = New System.Drawing.Size(145, 24)
        Me.objPaymentTotalValue.TabIndex = 44
        Me.objPaymentTotalValue.Text = "99,000,000"
        Me.objPaymentTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(316, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Payment"
        '
        'DgvPayments
        '
        Me.DgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPayments.Location = New System.Drawing.Point(10, 29)
        Me.DgvPayments.Name = "DgvPayments"
        Me.DgvPayments.Size = New System.Drawing.Size(313, 176)
        Me.DgvPayments.TabIndex = 7
        Me.DgvPayments.TabStop = False
        '
        'PanelRetur
        '
        Me.PanelRetur.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelRetur.Controls.Add(Me.btnReturnCancel)
        Me.PanelRetur.Controls.Add(Me.PanelReturnConfirm)
        Me.PanelRetur.Controls.Add(Me.btnReturn)
        Me.PanelRetur.Controls.Add(Me.Label17)
        Me.PanelRetur.Controls.Add(Me.objItemPrice)
        Me.PanelRetur.Controls.Add(Me.Label16)
        Me.PanelRetur.Controls.Add(Me.objItemSubtotal)
        Me.PanelRetur.Controls.Add(Me.Label13)
        Me.PanelRetur.Controls.Add(Me.objItemQty)
        Me.PanelRetur.Controls.Add(Me.objItemDescr)
        Me.PanelRetur.Controls.Add(Me.objItemArtMatCol)
        Me.PanelRetur.Controls.Add(Me.objItemId)
        Me.PanelRetur.Controls.Add(Me.Label5)
        Me.PanelRetur.Controls.Add(Me.Label4)
        Me.PanelRetur.Controls.Add(Me.Label3)
        Me.PanelRetur.Controls.Add(Me.Label2)
        Me.PanelRetur.Location = New System.Drawing.Point(17, 13)
        Me.PanelRetur.Name = "PanelRetur"
        Me.PanelRetur.Size = New System.Drawing.Size(299, 315)
        Me.PanelRetur.TabIndex = 0
        Me.PanelRetur.Visible = False
        '
        'btnReturnCancel
        '
        Me.btnReturnCancel.Location = New System.Drawing.Point(17, 149)
        Me.btnReturnCancel.Name = "btnReturnCancel"
        Me.btnReturnCancel.Size = New System.Drawing.Size(75, 20)
        Me.btnReturnCancel.TabIndex = 13
        Me.btnReturnCancel.Text = "Cancel"
        Me.btnReturnCancel.UseVisualStyleBackColor = True
        '
        'PanelReturnConfirm
        '
        Me.PanelReturnConfirm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelReturnConfirm.Controls.Add(Me.objItemRetDescr)
        Me.PanelReturnConfirm.Controls.Add(Me.Label14)
        Me.PanelReturnConfirm.Controls.Add(Me.objItemRetQtyMax)
        Me.PanelReturnConfirm.Controls.Add(Me.Label10)
        Me.PanelReturnConfirm.Controls.Add(Me.Label9)
        Me.PanelReturnConfirm.Controls.Add(Me.objItemRetBonReplacement)
        Me.PanelReturnConfirm.Controls.Add(Me.Label8)
        Me.PanelReturnConfirm.Controls.Add(Me.objItemRetQty)
        Me.PanelReturnConfirm.Controls.Add(Me.btnReturnConfirmCancel)
        Me.PanelReturnConfirm.Controls.Add(Me.btnReturnConfirmExecute)
        Me.PanelReturnConfirm.Controls.Add(Me.Label12)
        Me.PanelReturnConfirm.Location = New System.Drawing.Point(3, 174)
        Me.PanelReturnConfirm.Name = "PanelReturnConfirm"
        Me.PanelReturnConfirm.Size = New System.Drawing.Size(293, 138)
        Me.PanelReturnConfirm.TabIndex = 15
        Me.PanelReturnConfirm.Visible = False
        '
        'objItemRetDescr
        '
        Me.objItemRetDescr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.objItemRetDescr.Location = New System.Drawing.Point(105, 69)
        Me.objItemRetDescr.MaxLength = 30
        Me.objItemRetDescr.Name = "objItemRetDescr"
        Me.objItemRetDescr.Size = New System.Drawing.Size(176, 20)
        Me.objItemRetDescr.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(11, 72)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Keterangan"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'objItemRetQtyMax
        '
        Me.objItemRetQtyMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objItemRetQtyMax.ForeColor = System.Drawing.Color.Black
        Me.objItemRetQtyMax.Location = New System.Drawing.Point(211, 5)
        Me.objItemRetQtyMax.Name = "objItemRetQtyMax"
        Me.objItemRetQtyMax.Size = New System.Drawing.Size(30, 13)
        Me.objItemRetQtyMax.TabIndex = 50
        Me.objItemRetQtyMax.Text = "99"
        Me.objItemRetQtyMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(174, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Max"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(11, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Bon Pengganti"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'objItemRetBonReplacement
        '
        Me.objItemRetBonReplacement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.objItemRetBonReplacement.Location = New System.Drawing.Point(105, 28)
        Me.objItemRetBonReplacement.MaxLength = 40
        Me.objItemRetBonReplacement.Name = "objItemRetBonReplacement"
        Me.objItemRetBonReplacement.Size = New System.Drawing.Size(156, 20)
        Me.objItemRetBonReplacement.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(69, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Qty"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'objItemRetQty
        '
        Me.objItemRetQty.Location = New System.Drawing.Point(105, 2)
        Me.objItemRetQty.MaxLength = 3
        Me.objItemRetQty.Name = "objItemRetQty"
        Me.objItemRetQty.Size = New System.Drawing.Size(43, 20)
        Me.objItemRetQty.TabIndex = 1
        Me.objItemRetQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnReturnConfirmCancel
        '
        Me.btnReturnConfirmCancel.Location = New System.Drawing.Point(14, 112)
        Me.btnReturnConfirmCancel.Name = "btnReturnConfirmCancel"
        Me.btnReturnConfirmCancel.Size = New System.Drawing.Size(75, 20)
        Me.btnReturnConfirmCancel.TabIndex = 8
        Me.btnReturnConfirmCancel.Text = "Cancel"
        Me.btnReturnConfirmCancel.UseVisualStyleBackColor = True
        '
        'btnReturnConfirmExecute
        '
        Me.btnReturnConfirmExecute.Location = New System.Drawing.Point(95, 112)
        Me.btnReturnConfirmExecute.Name = "btnReturnConfirmExecute"
        Me.btnReturnConfirmExecute.Size = New System.Drawing.Size(75, 20)
        Me.btnReturnConfirmExecute.TabIndex = 9
        Me.btnReturnConfirmExecute.Text = "Return"
        Me.btnReturnConfirmExecute.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(105, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(304, 12)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Diisi dengan no bon pengganti, apabila tidak ada isi dengan 'NONE' / 'TBA'"
        '
        'btnReturn
        '
        Me.btnReturn.Location = New System.Drawing.Point(98, 149)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(75, 20)
        Me.btnReturn.TabIndex = 14
        Me.btnReturn.Text = "Confirm"
        Me.btnReturn.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(14, 122)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 13)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "Subtotal"
        '
        'objItemPrice
        '
        Me.objItemPrice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.objItemPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.objItemPrice.ForeColor = System.Drawing.Color.Black
        Me.objItemPrice.Location = New System.Drawing.Point(109, 92)
        Me.objItemPrice.Name = "objItemPrice"
        Me.objItemPrice.Size = New System.Drawing.Size(175, 16)
        Me.objItemPrice.TabIndex = 8
        Me.objItemPrice.Text = "99,000,000 / 0%"
        '
        'Label16
        '
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(14, 95)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 13)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "Price / Disc"
        '
        'objItemSubtotal
        '
        Me.objItemSubtotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.objItemSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.objItemSubtotal.ForeColor = System.Drawing.Color.Black
        Me.objItemSubtotal.Location = New System.Drawing.Point(190, 119)
        Me.objItemSubtotal.Name = "objItemSubtotal"
        Me.objItemSubtotal.Size = New System.Drawing.Size(96, 16)
        Me.objItemSubtotal.TabIndex = 12
        Me.objItemSubtotal.Text = "99,000,000"
        Me.objItemSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(139, 122)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 13)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "pcs,   Rp"
        '
        'objItemQty
        '
        Me.objItemQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.objItemQty.ForeColor = System.Drawing.Color.Black
        Me.objItemQty.Location = New System.Drawing.Point(109, 119)
        Me.objItemQty.Name = "objItemQty"
        Me.objItemQty.Size = New System.Drawing.Size(27, 16)
        Me.objItemQty.TabIndex = 10
        Me.objItemQty.Text = "99"
        Me.objItemQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'objItemDescr
        '
        Me.objItemDescr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.objItemDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.objItemDescr.ForeColor = System.Drawing.Color.Black
        Me.objItemDescr.Location = New System.Drawing.Point(109, 71)
        Me.objItemDescr.Name = "objItemDescr"
        Me.objItemDescr.Size = New System.Drawing.Size(175, 16)
        Me.objItemDescr.TabIndex = 6
        Me.objItemDescr.Text = "ID"
        '
        'objItemArtMatCol
        '
        Me.objItemArtMatCol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.objItemArtMatCol.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.objItemArtMatCol.ForeColor = System.Drawing.Color.Black
        Me.objItemArtMatCol.Location = New System.Drawing.Point(109, 50)
        Me.objItemArtMatCol.Name = "objItemArtMatCol"
        Me.objItemArtMatCol.Size = New System.Drawing.Size(175, 16)
        Me.objItemArtMatCol.TabIndex = 4
        Me.objItemArtMatCol.Text = "ID"
        '
        'objItemId
        '
        Me.objItemId.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.objItemId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.objItemId.ForeColor = System.Drawing.Color.Black
        Me.objItemId.Location = New System.Drawing.Point(109, 28)
        Me.objItemId.Name = "objItemId"
        Me.objItemId.Size = New System.Drawing.Size(175, 16)
        Me.objItemId.TabIndex = 2
        Me.objItemId.Text = "ID"
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(14, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Descr"
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(14, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Art / Mat / Col"
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(14, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "ID"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "RETURN NOTE"
        '
        'PnlPosMainF
        '
        Me.PnlPosMainF.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlPosMainF.Location = New System.Drawing.Point(0, 453)
        Me.PnlPosMainF.Name = "PnlPosMainF"
        Me.PnlPosMainF.Size = New System.Drawing.Size(787, 18)
        Me.PnlPosMainF.TabIndex = 1
        '
        'PnlPosMainH
        '
        Me.PnlPosMainH.BackColor = System.Drawing.Color.Transparent
        Me.PnlPosMainH.Controls.Add(Me.objBonId)
        Me.PnlPosMainH.Controls.Add(Me.btnExit)
        Me.PnlPosMainH.Controls.Add(Me.objPosEventName)
        Me.PnlPosMainH.Controls.Add(Me.objPosCompanyName)
        Me.PnlPosMainH.Controls.Add(Me.lineItemDisplay)
        Me.PnlPosMainH.Controls.Add(Me.lineSubtotal)
        Me.PnlPosMainH.Controls.Add(Me.lineQuantity)
        Me.PnlPosMainH.Controls.Add(Me.lblQuantity)
        Me.PnlPosMainH.Controls.Add(Me.txtCount)
        Me.PnlPosMainH.Controls.Add(Me.lblSubtotal)
        Me.PnlPosMainH.Controls.Add(Me.txtSubtotal)
        Me.PnlPosMainH.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlPosMainH.Location = New System.Drawing.Point(0, 0)
        Me.PnlPosMainH.Name = "PnlPosMainH"
        Me.PnlPosMainH.Size = New System.Drawing.Size(787, 77)
        Me.PnlPosMainH.TabIndex = 0
        '
        'objBonId
        '
        Me.objBonId.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objBonId.ForeColor = System.Drawing.Color.Black
        Me.objBonId.Location = New System.Drawing.Point(18, 46)
        Me.objBonId.Name = "objBonId"
        Me.objBonId.Size = New System.Drawing.Size(421, 25)
        Me.objBonId.TabIndex = 29
        Me.objBonId.Text = "BONID"
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(700, 4)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 20)
        Me.btnExit.TabIndex = 28
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'objPosEventName
        '
        Me.objPosEventName.ForeColor = System.Drawing.Color.Black
        Me.objPosEventName.Location = New System.Drawing.Point(17, 22)
        Me.objPosEventName.Name = "objPosEventName"
        Me.objPosEventName.Size = New System.Drawing.Size(99, 13)
        Me.objPosEventName.TabIndex = 1
        Me.objPosEventName.Text = "Return Note"
        '
        'objPosCompanyName
        '
        Me.objPosCompanyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPosCompanyName.ForeColor = System.Drawing.Color.Black
        Me.objPosCompanyName.Location = New System.Drawing.Point(17, 6)
        Me.objPosCompanyName.Name = "objPosCompanyName"
        Me.objPosCompanyName.Size = New System.Drawing.Size(412, 20)
        Me.objPosCompanyName.TabIndex = 0
        Me.objPosCompanyName.Text = "PT. Trans Mahagaya"
        '
        'lineItemDisplay
        '
        Me.lineItemDisplay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lineItemDisplay.BackColor = System.Drawing.Color.Gray
        Me.lineItemDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lineItemDisplay.ForeColor = System.Drawing.Color.Gray
        Me.lineItemDisplay.Location = New System.Drawing.Point(3, 72)
        Me.lineItemDisplay.Name = "lineItemDisplay"
        Me.lineItemDisplay.Size = New System.Drawing.Size(779, 1)
        Me.lineItemDisplay.TabIndex = 7
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
        Me.lineSubtotal.Visible = False
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
        Me.lblQuantity.Visible = False
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
        Me.txtCount.Visible = False
        '
        'lblSubtotal
        '
        Me.lblSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSubtotal.AutoSize = True
        Me.lblSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtotal.ForeColor = System.Drawing.Color.DimGray
        Me.lblSubtotal.Location = New System.Drawing.Point(466, 24)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(47, 13)
        Me.lblSubtotal.TabIndex = 1
        Me.lblSubtotal.Text = "TOTAL"
        Me.lblSubtotal.Visible = False
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
        Me.txtSubtotal.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'dlgTrnPosReturNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(811, 528)
        Me.Controls.Add(Me.PnlPosMain)
        Me.DoubleBuffered = True
        Me.Name = "dlgTrnPosReturNote"
        Me.Controls.SetChildIndex(Me.PnlPosMain, 0)
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlPosMain.ResumeLayout(False)
        Me.PnlPosMainCenter.Panel1.ResumeLayout(False)
        Me.PnlPosMainCenter.Panel2.ResumeLayout(False)
        Me.PnlPosMainCenter.ResumeLayout(False)
        Me.PanelPOSItem.ResumeLayout(False)
        CType(Me.DgvPOSItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DgvPayments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelRetur.ResumeLayout(False)
        Me.PanelReturnConfirm.ResumeLayout(False)
        Me.PanelReturnConfirm.PerformLayout()
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
    Friend WithEvents lineItemDisplay As System.Windows.Forms.Label
    Friend WithEvents objPosCompanyName As System.Windows.Forms.Label
    Friend WithEvents objPosEventName As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents PnlPosMainCenter As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DgvPayments As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PanelPOSItem As System.Windows.Forms.Panel
    Friend WithEvents DgvPOSItem As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents objPaymentTotalQty As System.Windows.Forms.Label
    Friend WithEvents objPaymentTotalValue As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents objPaymentDiscVoucherTotal As System.Windows.Forms.Label
    Friend WithEvents objPaymentDiscDescr As System.Windows.Forms.Label
    Friend WithEvents objPaymentDiscValue As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents objPaymentTOTAL As System.Windows.Forms.Label
    Friend WithEvents PanelRetur As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents objItemDescr As System.Windows.Forms.Label
    Friend WithEvents objItemArtMatCol As System.Windows.Forms.Label
    Friend WithEvents objItemId As System.Windows.Forms.Label
    Friend WithEvents objItemSubtotal As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents objItemQty As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents objItemPrice As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnReturn As System.Windows.Forms.Button
    Friend WithEvents PanelReturnConfirm As System.Windows.Forms.Panel
    Friend WithEvents btnReturnCancel As System.Windows.Forms.Button
    Friend WithEvents btnReturnConfirmCancel As System.Windows.Forms.Button
    Friend WithEvents btnReturnConfirmExecute As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents objItemRetQty As System.Windows.Forms.TextBox
    Friend WithEvents objItemRetBonReplacement As System.Windows.Forms.TextBox
    Friend WithEvents objItemRetQtyMax As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents objItemRetDescr As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents objBonId As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label

End Class
