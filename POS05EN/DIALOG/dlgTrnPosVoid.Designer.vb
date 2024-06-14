<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnPosVoid
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
        Me.objID = New System.Windows.Forms.TextBox
        Me.objIDExt = New System.Windows.Forms.TextBox
        Me.DgvPOSItem = New System.Windows.Forms.DataGridView
        Me.DgvPayments = New System.Windows.Forms.DataGridView
        Me.objPaymentTOTAL = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.chkVoid = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblVoidBy = New System.Windows.Forms.Label
        Me.objUsername = New System.Windows.Forms.Label
        Me.pnlVoidInfo = New System.Windows.Forms.Panel
        Me.lblVoidInfo = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.objPaymentDiscDescr = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.objPaymentDiscVoucherTotal = New System.Windows.Forms.Label
        Me.objPaymentTotalQty = New System.Windows.Forms.Label
        Me.objPaymentDiscValue = New System.Windows.Forms.Label
        Me.objPaymentTotalValue = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.objFakturPajak = New System.Windows.Forms.TextBox
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvPOSItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVoidInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'objID
        '
        Me.objID.Location = New System.Drawing.Point(81, 12)
        Me.objID.Name = "objID"
        Me.objID.ReadOnly = True
        Me.objID.Size = New System.Drawing.Size(200, 20)
        Me.objID.TabIndex = 3
        '
        'objIDExt
        '
        Me.objIDExt.Location = New System.Drawing.Point(81, 38)
        Me.objIDExt.Name = "objIDExt"
        Me.objIDExt.ReadOnly = True
        Me.objIDExt.Size = New System.Drawing.Size(65, 20)
        Me.objIDExt.TabIndex = 4
        '
        'DgvPOSItem
        '
        Me.DgvPOSItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPOSItem.Location = New System.Drawing.Point(8, 78)
        Me.DgvPOSItem.Name = "DgvPOSItem"
        Me.DgvPOSItem.Size = New System.Drawing.Size(847, 240)
        Me.DgvPOSItem.TabIndex = 5
        '
        'DgvPayments
        '
        Me.DgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPayments.Location = New System.Drawing.Point(8, 324)
        Me.DgvPayments.Name = "DgvPayments"
        Me.DgvPayments.Size = New System.Drawing.Size(427, 164)
        Me.DgvPayments.TabIndex = 6
        '
        'objPaymentTOTAL
        '
        Me.objPaymentTOTAL.BackColor = System.Drawing.Color.Transparent
        Me.objPaymentTOTAL.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPaymentTOTAL.ForeColor = System.Drawing.Color.MidnightBlue
        Me.objPaymentTOTAL.Location = New System.Drawing.Point(673, 444)
        Me.objPaymentTOTAL.Name = "objPaymentTOTAL"
        Me.objPaymentTOTAL.Size = New System.Drawing.Size(175, 44)
        Me.objPaymentTOTAL.TabIndex = 29
        Me.objPaymentTOTAL.Text = "99,000,000"
        Me.objPaymentTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(576, 457)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 18)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "TOTAL"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkVoid
        '
        Me.chkVoid.AutoSize = True
        Me.chkVoid.Enabled = False
        Me.chkVoid.Location = New System.Drawing.Point(287, 15)
        Me.chkVoid.Name = "chkVoid"
        Me.chkVoid.Size = New System.Drawing.Size(47, 17)
        Me.chkVoid.TabIndex = 30
        Me.chkVoid.Text = "Void"
        Me.chkVoid.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(57, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "ID Ext."
        '
        'lblVoidBy
        '
        Me.lblVoidBy.AutoSize = True
        Me.lblVoidBy.Location = New System.Drawing.Point(334, 16)
        Me.lblVoidBy.Name = "lblVoidBy"
        Me.lblVoidBy.Size = New System.Drawing.Size(18, 13)
        Me.lblVoidBy.TabIndex = 33
        Me.lblVoidBy.Text = "by"
        Me.lblVoidBy.Visible = False
        '
        'objUsername
        '
        Me.objUsername.AutoSize = True
        Me.objUsername.Location = New System.Drawing.Point(358, 16)
        Me.objUsername.Name = "objUsername"
        Me.objUsername.Size = New System.Drawing.Size(55, 13)
        Me.objUsername.TabIndex = 34
        Me.objUsername.Text = "Username"
        Me.objUsername.Visible = False
        '
        'pnlVoidInfo
        '
        Me.pnlVoidInfo.Controls.Add(Me.lblVoidInfo)
        Me.pnlVoidInfo.Location = New System.Drawing.Point(407, 495)
        Me.pnlVoidInfo.Name = "pnlVoidInfo"
        Me.pnlVoidInfo.Size = New System.Drawing.Size(278, 30)
        Me.pnlVoidInfo.TabIndex = 35
        '
        'lblVoidInfo
        '
        Me.lblVoidInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVoidInfo.ForeColor = System.Drawing.Color.Red
        Me.lblVoidInfo.Location = New System.Drawing.Point(103, 6)
        Me.lblVoidInfo.Name = "lblVoidInfo"
        Me.lblVoidInfo.Size = New System.Drawing.Size(172, 23)
        Me.lblVoidInfo.TabIndex = 0
        Me.lblVoidInfo.Text = "Click OK to VOID!! --->"
        Me.lblVoidInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(488, 340)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 15)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "item(s),  TOTAL VALUE"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'objPaymentDiscDescr
        '
        Me.objPaymentDiscDescr.BackColor = System.Drawing.Color.Transparent
        Me.objPaymentDiscDescr.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPaymentDiscDescr.Location = New System.Drawing.Point(448, 388)
        Me.objPaymentDiscDescr.Name = "objPaymentDiscDescr"
        Me.objPaymentDiscDescr.Size = New System.Drawing.Size(284, 15)
        Me.objPaymentDiscDescr.TabIndex = 47
        Me.objPaymentDiscDescr.Text = "Using MEGA VISA with additioal disc 10%"
        Me.objPaymentDiscDescr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(448, 363)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(233, 15)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Additional Disc / Voucher "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'objPaymentDiscVoucherTotal
        '
        Me.objPaymentDiscVoucherTotal.BackColor = System.Drawing.Color.Transparent
        Me.objPaymentDiscVoucherTotal.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPaymentDiscVoucherTotal.ForeColor = System.Drawing.Color.DimGray
        Me.objPaymentDiscVoucherTotal.Location = New System.Drawing.Point(677, 355)
        Me.objPaymentDiscVoucherTotal.Name = "objPaymentDiscVoucherTotal"
        Me.objPaymentDiscVoucherTotal.Size = New System.Drawing.Size(175, 24)
        Me.objPaymentDiscVoucherTotal.TabIndex = 53
        Me.objPaymentDiscVoucherTotal.Text = "99,000,000"
        Me.objPaymentDiscVoucherTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'objPaymentTotalQty
        '
        Me.objPaymentTotalQty.BackColor = System.Drawing.Color.Transparent
        Me.objPaymentTotalQty.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPaymentTotalQty.Location = New System.Drawing.Point(445, 332)
        Me.objPaymentTotalQty.Name = "objPaymentTotalQty"
        Me.objPaymentTotalQty.Size = New System.Drawing.Size(56, 24)
        Me.objPaymentTotalQty.TabIndex = 51
        Me.objPaymentTotalQty.Text = "999"
        Me.objPaymentTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'objPaymentDiscValue
        '
        Me.objPaymentDiscValue.BackColor = System.Drawing.Color.Transparent
        Me.objPaymentDiscValue.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPaymentDiscValue.ForeColor = System.Drawing.Color.DimGray
        Me.objPaymentDiscValue.Location = New System.Drawing.Point(677, 379)
        Me.objPaymentDiscValue.Name = "objPaymentDiscValue"
        Me.objPaymentDiscValue.Size = New System.Drawing.Size(175, 24)
        Me.objPaymentDiscValue.TabIndex = 48
        Me.objPaymentDiscValue.Text = "99,000,000"
        Me.objPaymentDiscValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'objPaymentTotalValue
        '
        Me.objPaymentTotalValue.BackColor = System.Drawing.Color.Transparent
        Me.objPaymentTotalValue.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPaymentTotalValue.Location = New System.Drawing.Point(673, 331)
        Me.objPaymentTotalValue.Name = "objPaymentTotalValue"
        Me.objPaymentTotalValue.Size = New System.Drawing.Size(179, 24)
        Me.objPaymentTotalValue.TabIndex = 46
        Me.objPaymentTotalValue.Text = "99,000,000"
        Me.objPaymentTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(163, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Faktur Pajak"
        '
        'objFakturPajak
        '
        Me.objFakturPajak.Location = New System.Drawing.Point(236, 38)
        Me.objFakturPajak.Name = "objFakturPajak"
        Me.objFakturPajak.ReadOnly = True
        Me.objFakturPajak.Size = New System.Drawing.Size(190, 20)
        Me.objFakturPajak.TabIndex = 56
        '
        'dlgTrnPosVoid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(860, 532)
        Me.Controls.Add(Me.objFakturPajak)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.objPaymentDiscDescr)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.objPaymentDiscVoucherTotal)
        Me.Controls.Add(Me.objPaymentTotalQty)
        Me.Controls.Add(Me.objPaymentDiscValue)
        Me.Controls.Add(Me.objPaymentTotalValue)
        Me.Controls.Add(Me.pnlVoidInfo)
        Me.Controls.Add(Me.objUsername)
        Me.Controls.Add(Me.lblVoidBy)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkVoid)
        Me.Controls.Add(Me.objPaymentTOTAL)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.DgvPayments)
        Me.Controls.Add(Me.objID)
        Me.Controls.Add(Me.DgvPOSItem)
        Me.Controls.Add(Me.objIDExt)
        Me.Name = "dlgTrnPosVoid"
        Me.Controls.SetChildIndex(Me.objIDExt, 0)
        Me.Controls.SetChildIndex(Me.DgvPOSItem, 0)
        Me.Controls.SetChildIndex(Me.objID, 0)
        Me.Controls.SetChildIndex(Me.DgvPayments, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.objPaymentTOTAL, 0)
        Me.Controls.SetChildIndex(Me.chkVoid, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblVoidBy, 0)
        Me.Controls.SetChildIndex(Me.objUsername, 0)
        Me.Controls.SetChildIndex(Me.pnlVoidInfo, 0)
        Me.Controls.SetChildIndex(Me.objPaymentTotalValue, 0)
        Me.Controls.SetChildIndex(Me.objPaymentDiscValue, 0)
        Me.Controls.SetChildIndex(Me.objPaymentTotalQty, 0)
        Me.Controls.SetChildIndex(Me.objPaymentDiscVoucherTotal, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.objPaymentDiscDescr, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.objFakturPajak, 0)
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvPOSItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvPayments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVoidInfo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents objID As System.Windows.Forms.TextBox
    Friend WithEvents objIDExt As System.Windows.Forms.TextBox
    Friend WithEvents DgvPOSItem As System.Windows.Forms.DataGridView
    Friend WithEvents DgvPayments As System.Windows.Forms.DataGridView
    Friend WithEvents objPaymentTOTAL As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkVoid As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblVoidBy As System.Windows.Forms.Label
    Friend WithEvents objUsername As System.Windows.Forms.Label
    Friend WithEvents pnlVoidInfo As System.Windows.Forms.Panel
    Friend WithEvents lblVoidInfo As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents objPaymentDiscDescr As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents objPaymentDiscVoucherTotal As System.Windows.Forms.Label
    Friend WithEvents objPaymentTotalQty As System.Windows.Forms.Label
    Friend WithEvents objPaymentDiscValue As System.Windows.Forms.Label
    Friend WithEvents objPaymentTotalValue As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents objFakturPajak As System.Windows.Forms.TextBox

End Class
