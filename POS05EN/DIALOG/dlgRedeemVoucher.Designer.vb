<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgRedeemVoucher
    Inherits System.Windows.Forms.Form

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
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.btn_CheckVoucher = New System.Windows.Forms.Label
        Me.obj_txt_voucherid = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_UseVoucher = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.obj_txt_descr = New System.Windows.Forms.Label
        Me.obj_txt_value = New System.Windows.Forms.Label
        Me.obj_txt_expireddate = New System.Windows.Forms.Label
        Me.obj_txt_usedby = New System.Windows.Forms.Label
        Me.obj_txt_useddate = New System.Windows.Forms.Label
        Me.btn_OnlineOffline = New System.Windows.Forms.LinkLabel
        Me.btn_vouchertfi = New System.Windows.Forms.LinkLabel
        Me.btn_voucherother = New System.Windows.Forms.LinkLabel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.obj_txt_voucher_id = New System.Windows.Forms.Label
        Me.obj_txt_manualvalue = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        '
        'btn_CheckVoucher
        '
        Me.btn_CheckVoucher.BackColor = System.Drawing.Color.LightGray
        Me.btn_CheckVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btn_CheckVoucher.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_CheckVoucher.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CheckVoucher.Location = New System.Drawing.Point(371, 120)
        Me.btn_CheckVoucher.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_CheckVoucher.Name = "btn_CheckVoucher"
        Me.btn_CheckVoucher.Size = New System.Drawing.Size(158, 43)
        Me.btn_CheckVoucher.TabIndex = 20
        Me.btn_CheckVoucher.Text = "Check Voucher"
        Me.btn_CheckVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'obj_txt_voucherid
        '
        Me.obj_txt_voucherid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.obj_txt_voucherid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_txt_voucherid.Location = New System.Drawing.Point(17, 131)
        Me.obj_txt_voucherid.MaxLength = 32
        Me.obj_txt_voucherid.Name = "obj_txt_voucherid"
        Me.obj_txt_voucherid.Size = New System.Drawing.Size(338, 19)
        Me.obj_txt_voucherid.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 120)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(349, 43)
        Me.Label1.TabIndex = 22
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 89)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(353, 31)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Scan / Input Voucher Trans Fashion"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_UseVoucher
        '
        Me.btn_UseVoucher.BackColor = System.Drawing.Color.LightGray
        Me.btn_UseVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btn_UseVoucher.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_UseVoucher.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_UseVoucher.Location = New System.Drawing.Point(29, 436)
        Me.btn_UseVoucher.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_UseVoucher.Name = "btn_UseVoucher"
        Me.btn_UseVoucher.Size = New System.Drawing.Size(162, 43)
        Me.btn_UseVoucher.TabIndex = 24
        Me.btn_UseVoucher.Text = "Use Voucher"
        Me.btn_UseVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_UseVoucher.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 35)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 31)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Value"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 66)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 31)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Descr"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 143)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 31)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "UseBy"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 174)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 31)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "UseDate"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(22, 97)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 31)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Expired Date"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'obj_txt_descr
        '
        Me.obj_txt_descr.BackColor = System.Drawing.Color.Transparent
        Me.obj_txt_descr.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.obj_txt_descr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_txt_descr.Location = New System.Drawing.Point(147, 66)
        Me.obj_txt_descr.Margin = New System.Windows.Forms.Padding(0)
        Me.obj_txt_descr.Name = "obj_txt_descr"
        Me.obj_txt_descr.Size = New System.Drawing.Size(427, 31)
        Me.obj_txt_descr.TabIndex = 30
        Me.obj_txt_descr.Text = "-"
        Me.obj_txt_descr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'obj_txt_value
        '
        Me.obj_txt_value.BackColor = System.Drawing.Color.Transparent
        Me.obj_txt_value.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.obj_txt_value.Font = New System.Drawing.Font("Microsoft Sans Serif", 34.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_txt_value.Location = New System.Drawing.Point(147, 18)
        Me.obj_txt_value.Margin = New System.Windows.Forms.Padding(0)
        Me.obj_txt_value.Name = "obj_txt_value"
        Me.obj_txt_value.Size = New System.Drawing.Size(427, 48)
        Me.obj_txt_value.TabIndex = 31
        Me.obj_txt_value.Text = "-"
        Me.obj_txt_value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'obj_txt_expireddate
        '
        Me.obj_txt_expireddate.BackColor = System.Drawing.Color.Transparent
        Me.obj_txt_expireddate.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.obj_txt_expireddate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_txt_expireddate.Location = New System.Drawing.Point(147, 97)
        Me.obj_txt_expireddate.Margin = New System.Windows.Forms.Padding(0)
        Me.obj_txt_expireddate.Name = "obj_txt_expireddate"
        Me.obj_txt_expireddate.Size = New System.Drawing.Size(427, 31)
        Me.obj_txt_expireddate.TabIndex = 32
        Me.obj_txt_expireddate.Text = "-"
        Me.obj_txt_expireddate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'obj_txt_usedby
        '
        Me.obj_txt_usedby.BackColor = System.Drawing.Color.Transparent
        Me.obj_txt_usedby.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.obj_txt_usedby.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_txt_usedby.Location = New System.Drawing.Point(147, 143)
        Me.obj_txt_usedby.Margin = New System.Windows.Forms.Padding(0)
        Me.obj_txt_usedby.Name = "obj_txt_usedby"
        Me.obj_txt_usedby.Size = New System.Drawing.Size(427, 31)
        Me.obj_txt_usedby.TabIndex = 33
        Me.obj_txt_usedby.Text = "-"
        Me.obj_txt_usedby.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'obj_txt_useddate
        '
        Me.obj_txt_useddate.BackColor = System.Drawing.Color.Transparent
        Me.obj_txt_useddate.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.obj_txt_useddate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_txt_useddate.Location = New System.Drawing.Point(147, 174)
        Me.obj_txt_useddate.Margin = New System.Windows.Forms.Padding(0)
        Me.obj_txt_useddate.Name = "obj_txt_useddate"
        Me.obj_txt_useddate.Size = New System.Drawing.Size(427, 31)
        Me.obj_txt_useddate.TabIndex = 34
        Me.obj_txt_useddate.Text = "-"
        Me.obj_txt_useddate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_OnlineOffline
        '
        Me.btn_OnlineOffline.AutoSize = True
        Me.btn_OnlineOffline.Location = New System.Drawing.Point(8, 0)
        Me.btn_OnlineOffline.Name = "btn_OnlineOffline"
        Me.btn_OnlineOffline.Size = New System.Drawing.Size(119, 13)
        Me.btn_OnlineOffline.TabIndex = 35
        Me.btn_OnlineOffline.TabStop = True
        Me.btn_OnlineOffline.Text = "Set as Offline Validation"
        '
        'btn_vouchertfi
        '
        Me.btn_vouchertfi.AutoSize = True
        Me.btn_vouchertfi.Location = New System.Drawing.Point(14, 32)
        Me.btn_vouchertfi.Name = "btn_vouchertfi"
        Me.btn_vouchertfi.Size = New System.Drawing.Size(117, 13)
        Me.btn_vouchertfi.TabIndex = 36
        Me.btn_vouchertfi.TabStop = True
        Me.btn_vouchertfi.Text = "Trans Fashion Voucher"
        '
        'btn_voucherother
        '
        Me.btn_voucherother.AutoSize = True
        Me.btn_voucherother.Location = New System.Drawing.Point(213, 32)
        Me.btn_voucherother.Name = "btn_voucherother"
        Me.btn_voucherother.Size = New System.Drawing.Size(76, 13)
        Me.btn_voucherother.TabIndex = 37
        Me.btn_voucherother.TabStop = True
        Me.btn_voucherother.Text = "Other Voucher"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.obj_txt_voucher_id)
        Me.Panel1.Controls.Add(Me.btn_OnlineOffline)
        Me.Panel1.Controls.Add(Me.obj_txt_useddate)
        Me.Panel1.Controls.Add(Me.obj_txt_usedby)
        Me.Panel1.Controls.Add(Me.obj_txt_expireddate)
        Me.Panel1.Controls.Add(Me.obj_txt_value)
        Me.Panel1.Controls.Add(Me.obj_txt_descr)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(3, 170)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(594, 231)
        Me.Panel1.TabIndex = 38
        '
        'obj_txt_voucher_id
        '
        Me.obj_txt_voucher_id.BackColor = System.Drawing.Color.Transparent
        Me.obj_txt_voucher_id.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.obj_txt_voucher_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.obj_txt_voucher_id.Location = New System.Drawing.Point(447, 5)
        Me.obj_txt_voucher_id.Margin = New System.Windows.Forms.Padding(0)
        Me.obj_txt_voucher_id.Name = "obj_txt_voucher_id"
        Me.obj_txt_voucher_id.Size = New System.Drawing.Size(143, 20)
        Me.obj_txt_voucher_id.TabIndex = 36
        Me.obj_txt_voucher_id.Text = "-"
        Me.obj_txt_voucher_id.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'obj_txt_manualvalue
        '
        Me.obj_txt_manualvalue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.obj_txt_manualvalue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_txt_manualvalue.Location = New System.Drawing.Point(17, 218)
        Me.obj_txt_manualvalue.MaxLength = 32
        Me.obj_txt_manualvalue.Name = "obj_txt_manualvalue"
        Me.obj_txt_manualvalue.Size = New System.Drawing.Size(338, 19)
        Me.obj_txt_manualvalue.TabIndex = 39
        Me.obj_txt_manualvalue.Text = "0"
        Me.obj_txt_manualvalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 207)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(349, 43)
        Me.Label8.TabIndex = 40
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 175)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(353, 31)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Nilai Voucher (Rupiah)"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BackgroundWorker2
        '
        '
        'dlgRedeemVoucher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(613, 522)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.obj_txt_manualvalue)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btn_voucherother)
        Me.Controls.Add(Me.btn_vouchertfi)
        Me.Controls.Add(Me.btn_UseVoucher)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.obj_txt_voucherid)
        Me.Controls.Add(Me.btn_CheckVoucher)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "dlgRedeemVoucher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Voucher"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btn_CheckVoucher As System.Windows.Forms.Label
    Friend WithEvents obj_txt_voucherid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_UseVoucher As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents obj_txt_descr As System.Windows.Forms.Label
    Friend WithEvents obj_txt_value As System.Windows.Forms.Label
    Friend WithEvents obj_txt_expireddate As System.Windows.Forms.Label
    Friend WithEvents obj_txt_usedby As System.Windows.Forms.Label
    Friend WithEvents obj_txt_useddate As System.Windows.Forms.Label
    Friend WithEvents btn_OnlineOffline As System.Windows.Forms.LinkLabel
    Friend WithEvents btn_vouchertfi As System.Windows.Forms.LinkLabel
    Friend WithEvents btn_voucherother As System.Windows.Forms.LinkLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents obj_txt_manualvalue As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents obj_txt_voucher_id As System.Windows.Forms.Label
End Class
