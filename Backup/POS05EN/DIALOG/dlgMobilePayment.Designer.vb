<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgMobilePayment
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgMobilePayment))
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.txt_PaymentTOTAL = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_ReffNum = New System.Windows.Forms.TextBox
        Me.txt_CountDown = New System.Windows.Forms.Label
        Me.tmr_CountDown = New System.Windows.Forms.Timer(Me.components)
        Me.lbl_StoreName = New System.Windows.Forms.Label
        Me.lbl_param_paymenttype = New System.Windows.Forms.Label
        Me.btn_Copy = New System.Windows.Forms.Button
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Controls.Add(Me.Label8)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label9)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label10)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label11)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label12)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(872, 107)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(278, 507)
        Me.FlowLayoutPanel1.TabIndex = 11
        Me.FlowLayoutPanel1.Visible = False
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.LightGray
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Image = CType(resources.GetObject("Label8.Image"), System.Drawing.Image)
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.Location = New System.Drawing.Point(3, 0)
        Me.Label8.Margin = New System.Windows.Forms.Padding(3, 0, 3, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Padding = New System.Windows.Forms.Padding(10, 2, 2, 2)
        Me.Label8.Size = New System.Drawing.Size(266, 50)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "       MEGA Credit Card"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.LightGray
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Image = CType(resources.GetObject("Label9.Image"), System.Drawing.Image)
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label9.Location = New System.Drawing.Point(3, 70)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3, 0, 3, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Padding = New System.Windows.Forms.Padding(10, 2, 2, 2)
        Me.Label9.Size = New System.Drawing.Size(266, 50)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "       MEGA Debit Card"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.LightGray
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Image = CType(resources.GetObject("Label10.Image"), System.Drawing.Image)
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label10.Location = New System.Drawing.Point(3, 140)
        Me.Label10.Margin = New System.Windows.Forms.Padding(3, 0, 3, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Padding = New System.Windows.Forms.Padding(10, 2, 2, 2)
        Me.Label10.Size = New System.Drawing.Size(266, 50)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "       Other Credit Card"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.LightGray
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Image = CType(resources.GetObject("Label11.Image"), System.Drawing.Image)
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label11.Location = New System.Drawing.Point(3, 210)
        Me.Label11.Margin = New System.Windows.Forms.Padding(3, 0, 3, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Padding = New System.Windows.Forms.Padding(10, 2, 2, 2)
        Me.Label11.Size = New System.Drawing.Size(266, 50)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "       Other Debit Card"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.LightGray
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Image = CType(resources.GetObject("Label12.Image"), System.Drawing.Image)
        Me.Label12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label12.Location = New System.Drawing.Point(3, 280)
        Me.Label12.Margin = New System.Windows.Forms.Padding(3, 0, 3, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Padding = New System.Windows.Forms.Padding(10, 2, 2, 2)
        Me.Label12.Size = New System.Drawing.Size(266, 50)
        Me.Label12.TabIndex = 18
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Image = CType(resources.GetObject("Label3.Image"), System.Drawing.Image)
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(3, 140)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3, 0, 3, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(10, 2, 2, 2)
        Me.Label3.Size = New System.Drawing.Size(266, 50)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "       BCA Virtual Account"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(3, 70)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3, 0, 3, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(10, 2, 2, 2)
        Me.Label4.Size = New System.Drawing.Size(266, 50)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "       MEGA Virtual Account"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(3, 210)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3, 0, 3, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(10, 2, 2, 2)
        Me.Label5.Size = New System.Drawing.Size(266, 50)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "       BNI Virtual Account"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Image = CType(resources.GetObject("Label6.Image"), System.Drawing.Image)
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.Location = New System.Drawing.Point(3, 280)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3, 0, 3, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(10, 2, 2, 2)
        Me.Label6.Size = New System.Drawing.Size(266, 50)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "       Mandiri Virtual Account"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.LightGray
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Image = CType(resources.GetObject("Label7.Image"), System.Drawing.Image)
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label7.Location = New System.Drawing.Point(3, 0)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3, 0, 3, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(10, 2, 2, 2)
        Me.Label7.Size = New System.Drawing.Size(266, 50)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "       BRI Virtual Account"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Label7)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label5)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label6)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(937, 53)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(200, 296)
        Me.FlowLayoutPanel2.TabIndex = 12
        Me.FlowLayoutPanel2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(66, 62)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(279, 279)
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'txt_PaymentTOTAL
        '
        Me.txt_PaymentTOTAL.BackColor = System.Drawing.Color.Transparent
        Me.txt_PaymentTOTAL.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PaymentTOTAL.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txt_PaymentTOTAL.Location = New System.Drawing.Point(76, 378)
        Me.txt_PaymentTOTAL.Name = "txt_PaymentTOTAL"
        Me.txt_PaymentTOTAL.Size = New System.Drawing.Size(255, 44)
        Me.txt_PaymentTOTAL.TabIndex = 28
        Me.txt_PaymentTOTAL.Text = "99,000,000"
        Me.txt_PaymentTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(66, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(279, 18)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Please Scan QR Code bellow"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_ReffNum
        '
        Me.txt_ReffNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ReffNum.Location = New System.Drawing.Point(66, 434)
        Me.txt_ReffNum.Name = "txt_ReffNum"
        Me.txt_ReffNum.ReadOnly = True
        Me.txt_ReffNum.Size = New System.Drawing.Size(279, 20)
        Me.txt_ReffNum.TabIndex = 30
        Me.txt_ReffNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_CountDown
        '
        Me.txt_CountDown.BackColor = System.Drawing.Color.Transparent
        Me.txt_CountDown.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CountDown.Location = New System.Drawing.Point(63, 457)
        Me.txt_CountDown.Name = "txt_CountDown"
        Me.txt_CountDown.Size = New System.Drawing.Size(282, 18)
        Me.txt_CountDown.TabIndex = 31
        Me.txt_CountDown.Text = "##"
        Me.txt_CountDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tmr_CountDown
        '
        '
        'lbl_StoreName
        '
        Me.lbl_StoreName.BackColor = System.Drawing.Color.Transparent
        Me.lbl_StoreName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_StoreName.Location = New System.Drawing.Point(12, 354)
        Me.lbl_StoreName.Name = "lbl_StoreName"
        Me.lbl_StoreName.Size = New System.Drawing.Size(388, 18)
        Me.lbl_StoreName.TabIndex = 32
        Me.lbl_StoreName.Text = "Store Name"
        Me.lbl_StoreName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_param_paymenttype
        '
        Me.lbl_param_paymenttype.Location = New System.Drawing.Point(2, 5)
        Me.lbl_param_paymenttype.Name = "lbl_param_paymenttype"
        Me.lbl_param_paymenttype.Size = New System.Drawing.Size(404, 17)
        Me.lbl_param_paymenttype.TabIndex = 33
        Me.lbl_param_paymenttype.Text = "paymenttype"
        Me.lbl_param_paymenttype.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_Copy
        '
        Me.btn_Copy.Location = New System.Drawing.Point(161, 501)
        Me.btn_Copy.Name = "btn_Copy"
        Me.btn_Copy.Size = New System.Drawing.Size(75, 23)
        Me.btn_Copy.TabIndex = 34
        Me.btn_Copy.Text = "Copy"
        Me.btn_Copy.UseVisualStyleBackColor = True
        '
        'dlgMobilePayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 536)
        Me.Controls.Add(Me.btn_Copy)
        Me.Controls.Add(Me.lbl_param_paymenttype)
        Me.Controls.Add(Me.lbl_StoreName)
        Me.Controls.Add(Me.txt_CountDown)
        Me.Controls.Add(Me.txt_ReffNum)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_PaymentTOTAL)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "dlgMobilePayment"
        Me.Text = "dlgMobilePayment"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txt_PaymentTOTAL As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_ReffNum As System.Windows.Forms.TextBox
    Friend WithEvents txt_CountDown As System.Windows.Forms.Label
    Friend WithEvents tmr_CountDown As System.Windows.Forms.Timer
    Friend WithEvents lbl_StoreName As System.Windows.Forms.Label
    Friend WithEvents lbl_param_paymenttype As System.Windows.Forms.Label
    Friend WithEvents btn_Copy As System.Windows.Forms.Button
End Class
