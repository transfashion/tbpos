<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnPosVoucher
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
        Me.PnlFormMain = New System.Windows.Forms.Panel
        Me.btnF10 = New System.Windows.Forms.Label
        Me.pnlAuth2 = New System.Windows.Forms.Panel
        Me.lblAuthClose = New System.Windows.Forms.LinkLabel
        Me.lblReset = New System.Windows.Forms.LinkLabel
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblAuthMsg = New System.Windows.Forms.Label
        Me.btnOpen = New System.Windows.Forms.Button
        Me.objPassword = New System.Windows.Forms.TextBox
        Me.objUsername = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.pnlAuth2Shadow = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Group02 = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_disc5 = New System.Windows.Forms.Label
        Me.btn_disc30 = New System.Windows.Forms.Label
        Me.btn_disc25 = New System.Windows.Forms.Label
        Me.btn_disc20 = New System.Windows.Forms.Label
        Me.btn_disc15 = New System.Windows.Forms.Label
        Me.btn_disc10 = New System.Windows.Forms.Label
        Me.obj_VoucherId = New System.Windows.Forms.Label
        Me.pnlAuth1 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblAuthOpen = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.objPaymentAddDisc = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.objPaymentRedeem = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.objPaymentVoucherCode = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.objPaymentVoucher = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlFormMain.SuspendLayout()
        Me.pnlAuth2.SuspendLayout()
        Me.Group02.SuspendLayout()
        Me.pnlAuth1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlFormMain
        '
        Me.PnlFormMain.Controls.Add(Me.btnF10)
        Me.PnlFormMain.Controls.Add(Me.pnlAuth2)
        Me.PnlFormMain.Controls.Add(Me.pnlAuth2Shadow)
        Me.PnlFormMain.Controls.Add(Me.GroupBox1)
        Me.PnlFormMain.Controls.Add(Me.Group02)
        Me.PnlFormMain.Controls.Add(Me.Label4)
        Me.PnlFormMain.Location = New System.Drawing.Point(1, 3)
        Me.PnlFormMain.Name = "PnlFormMain"
        Me.PnlFormMain.Size = New System.Drawing.Size(807, 488)
        Me.PnlFormMain.TabIndex = 3
        '
        'btnF10
        '
        Me.btnF10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnF10.AutoSize = True
        Me.btnF10.BackColor = System.Drawing.Color.LightGray
        Me.btnF10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnF10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnF10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF10.Location = New System.Drawing.Point(641, 443)
        Me.btnF10.Name = "btnF10"
        Me.btnF10.Padding = New System.Windows.Forms.Padding(2)
        Me.btnF10.Size = New System.Drawing.Size(136, 26)
        Me.btnF10.TabIndex = 9
        Me.btnF10.Text = "     F10 - OK     "
        '
        'pnlAuth2
        '
        Me.pnlAuth2.BackColor = System.Drawing.Color.PeachPuff
        Me.pnlAuth2.Controls.Add(Me.lblAuthClose)
        Me.pnlAuth2.Controls.Add(Me.lblReset)
        Me.pnlAuth2.Controls.Add(Me.Label11)
        Me.pnlAuth2.Controls.Add(Me.lblAuthMsg)
        Me.pnlAuth2.Controls.Add(Me.btnOpen)
        Me.pnlAuth2.Controls.Add(Me.objPassword)
        Me.pnlAuth2.Controls.Add(Me.objUsername)
        Me.pnlAuth2.Controls.Add(Me.Label8)
        Me.pnlAuth2.Controls.Add(Me.Label7)
        Me.pnlAuth2.Controls.Add(Me.Label6)
        Me.pnlAuth2.Location = New System.Drawing.Point(445, 221)
        Me.pnlAuth2.Name = "pnlAuth2"
        Me.pnlAuth2.Size = New System.Drawing.Size(211, 107)
        Me.pnlAuth2.TabIndex = 7
        Me.pnlAuth2.Visible = False
        '
        'lblAuthClose
        '
        Me.lblAuthClose.AutoSize = True
        Me.lblAuthClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAuthClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuthClose.Location = New System.Drawing.Point(176, 5)
        Me.lblAuthClose.Name = "lblAuthClose"
        Me.lblAuthClose.Size = New System.Drawing.Size(29, 12)
        Me.lblAuthClose.TabIndex = 7
        Me.lblAuthClose.TabStop = True
        Me.lblAuthClose.Text = "Close"
        '
        'lblReset
        '
        Me.lblReset.AutoSize = True
        Me.lblReset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReset.Location = New System.Drawing.Point(140, 5)
        Me.lblReset.Name = "lblReset"
        Me.lblReset.Size = New System.Drawing.Size(30, 12)
        Me.lblReset.TabIndex = 8
        Me.lblReset.TabStop = True
        Me.lblReset.Text = "Reset"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(169, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(9, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "|"
        '
        'lblAuthMsg
        '
        Me.lblAuthMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuthMsg.ForeColor = System.Drawing.Color.Maroon
        Me.lblAuthMsg.Location = New System.Drawing.Point(5, 76)
        Me.lblAuthMsg.Name = "lblAuthMsg"
        Me.lblAuthMsg.Size = New System.Drawing.Size(129, 28)
        Me.lblAuthMsg.TabIndex = 6
        Me.lblAuthMsg.Text = "Bad user or password" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please Retry !" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblAuthMsg.Visible = False
        '
        'btnOpen
        '
        Me.btnOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpen.Location = New System.Drawing.Point(140, 81)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(54, 21)
        Me.btnOpen.TabIndex = 5
        Me.btnOpen.Text = "&Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'objPassword
        '
        Me.objPassword.Location = New System.Drawing.Point(80, 53)
        Me.objPassword.MaxLength = 50
        Me.objPassword.Name = "objPassword"
        Me.objPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.objPassword.Size = New System.Drawing.Size(114, 20)
        Me.objPassword.TabIndex = 4
        '
        'objUsername
        '
        Me.objUsername.Location = New System.Drawing.Point(80, 27)
        Me.objUsername.MaxLength = 30
        Me.objUsername.Name = "objUsername"
        Me.objUsername.Size = New System.Drawing.Size(114, 20)
        Me.objUsername.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(7, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 15)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "&Password"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(7, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 15)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "&Username"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(6, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Login"
        '
        'pnlAuth2Shadow
        '
        Me.pnlAuth2Shadow.BackColor = System.Drawing.Color.Silver
        Me.pnlAuth2Shadow.Location = New System.Drawing.Point(450, 225)
        Me.pnlAuth2Shadow.Name = "pnlAuth2Shadow"
        Me.pnlAuth2Shadow.Size = New System.Drawing.Size(209, 106)
        Me.pnlAuth2Shadow.TabIndex = 8
        Me.pnlAuth2Shadow.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(10, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(784, 106)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Customer Information"
        '
        'Group02
        '
        Me.Group02.Controls.Add(Me.Panel1)
        Me.Group02.Controls.Add(Me.btn_disc5)
        Me.Group02.Controls.Add(Me.btn_disc30)
        Me.Group02.Controls.Add(Me.btn_disc25)
        Me.Group02.Controls.Add(Me.btn_disc20)
        Me.Group02.Controls.Add(Me.btn_disc15)
        Me.Group02.Controls.Add(Me.btn_disc10)
        Me.Group02.Controls.Add(Me.obj_VoucherId)
        Me.Group02.Controls.Add(Me.pnlAuth1)
        Me.Group02.Controls.Add(Me.Label1)
        Me.Group02.Controls.Add(Me.objPaymentRedeem)
        Me.Group02.Controls.Add(Me.Label12)
        Me.Group02.Controls.Add(Me.objPaymentVoucherCode)
        Me.Group02.Controls.Add(Me.Label9)
        Me.Group02.Controls.Add(Me.objPaymentVoucher)
        Me.Group02.Location = New System.Drawing.Point(9, 145)
        Me.Group02.Name = "Group02"
        Me.Group02.Size = New System.Drawing.Size(785, 243)
        Me.Group02.TabIndex = 3
        Me.Group02.TabStop = False
        Me.Group02.Text = "Voucher / Rabat / Cash Discounts"
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(170, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(480, 82)
        Me.Panel1.TabIndex = 16
        '
        'btn_disc5
        '
        Me.btn_disc5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_disc5.BackColor = System.Drawing.Color.LightGray
        Me.btn_disc5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btn_disc5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_disc5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_disc5.Location = New System.Drawing.Point(702, 25)
        Me.btn_disc5.Name = "btn_disc5"
        Me.btn_disc5.Padding = New System.Windows.Forms.Padding(2)
        Me.btn_disc5.Size = New System.Drawing.Size(70, 26)
        Me.btn_disc5.TabIndex = 15
        Me.btn_disc5.Text = "5%"
        Me.btn_disc5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_disc30
        '
        Me.btn_disc30.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_disc30.BackColor = System.Drawing.Color.LightGray
        Me.btn_disc30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btn_disc30.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_disc30.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_disc30.Location = New System.Drawing.Point(702, 211)
        Me.btn_disc30.Name = "btn_disc30"
        Me.btn_disc30.Padding = New System.Windows.Forms.Padding(2)
        Me.btn_disc30.Size = New System.Drawing.Size(70, 26)
        Me.btn_disc30.TabIndex = 14
        Me.btn_disc30.Text = "30%"
        Me.btn_disc30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_disc25
        '
        Me.btn_disc25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_disc25.BackColor = System.Drawing.Color.LightGray
        Me.btn_disc25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btn_disc25.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_disc25.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_disc25.Location = New System.Drawing.Point(702, 174)
        Me.btn_disc25.Name = "btn_disc25"
        Me.btn_disc25.Padding = New System.Windows.Forms.Padding(2)
        Me.btn_disc25.Size = New System.Drawing.Size(70, 26)
        Me.btn_disc25.TabIndex = 13
        Me.btn_disc25.Text = "25%"
        Me.btn_disc25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_disc20
        '
        Me.btn_disc20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_disc20.BackColor = System.Drawing.Color.LightGray
        Me.btn_disc20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btn_disc20.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_disc20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_disc20.Location = New System.Drawing.Point(702, 137)
        Me.btn_disc20.Name = "btn_disc20"
        Me.btn_disc20.Padding = New System.Windows.Forms.Padding(2)
        Me.btn_disc20.Size = New System.Drawing.Size(70, 26)
        Me.btn_disc20.TabIndex = 12
        Me.btn_disc20.Text = "20%"
        Me.btn_disc20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_disc15
        '
        Me.btn_disc15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_disc15.BackColor = System.Drawing.Color.LightGray
        Me.btn_disc15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btn_disc15.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_disc15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_disc15.Location = New System.Drawing.Point(702, 100)
        Me.btn_disc15.Name = "btn_disc15"
        Me.btn_disc15.Padding = New System.Windows.Forms.Padding(2)
        Me.btn_disc15.Size = New System.Drawing.Size(70, 26)
        Me.btn_disc15.TabIndex = 11
        Me.btn_disc15.Text = "15%"
        Me.btn_disc15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_disc10
        '
        Me.btn_disc10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_disc10.BackColor = System.Drawing.Color.LightGray
        Me.btn_disc10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btn_disc10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_disc10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_disc10.Location = New System.Drawing.Point(702, 63)
        Me.btn_disc10.Name = "btn_disc10"
        Me.btn_disc10.Padding = New System.Windows.Forms.Padding(2)
        Me.btn_disc10.Size = New System.Drawing.Size(70, 26)
        Me.btn_disc10.TabIndex = 10
        Me.btn_disc10.Text = "10%"
        Me.btn_disc10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'obj_VoucherId
        '
        Me.obj_VoucherId.AutoSize = True
        Me.obj_VoucherId.Location = New System.Drawing.Point(591, 31)
        Me.obj_VoucherId.Name = "obj_VoucherId"
        Me.obj_VoucherId.Size = New System.Drawing.Size(39, 13)
        Me.obj_VoucherId.TabIndex = 7
        Me.obj_VoucherId.Text = "Label3"
        '
        'pnlAuth1
        '
        Me.pnlAuth1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.pnlAuth1.Controls.Add(Me.Label2)
        Me.pnlAuth1.Controls.Add(Me.lblAuthOpen)
        Me.pnlAuth1.Controls.Add(Me.Label10)
        Me.pnlAuth1.Controls.Add(Me.objPaymentAddDisc)
        Me.pnlAuth1.Location = New System.Drawing.Point(75, 137)
        Me.pnlAuth1.Name = "pnlAuth1"
        Me.pnlAuth1.Size = New System.Drawing.Size(575, 39)
        Me.pnlAuth1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(3, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "[F8]"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAuthOpen
        '
        Me.lblAuthOpen.AutoSize = True
        Me.lblAuthOpen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAuthOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuthOpen.ForeColor = System.Drawing.Color.Maroon
        Me.lblAuthOpen.Location = New System.Drawing.Point(401, 14)
        Me.lblAuthOpen.Name = "lblAuthOpen"
        Me.lblAuthOpen.Size = New System.Drawing.Size(144, 13)
        Me.lblAuthOpen.TabIndex = 2
        Me.lblAuthOpen.Text = "Authentication Required"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label10.Location = New System.Drawing.Point(43, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 15)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "&Add.Disc"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'objPaymentAddDisc
        '
        Me.objPaymentAddDisc.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPaymentAddDisc.Location = New System.Drawing.Point(97, 5)
        Me.objPaymentAddDisc.MaxLength = 10
        Me.objPaymentAddDisc.Name = "objPaymentAddDisc"
        Me.objPaymentAddDisc.Size = New System.Drawing.Size(250, 29)
        Me.objPaymentAddDisc.TabIndex = 1
        Me.objPaymentAddDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(98, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "&Redeem"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'objPaymentRedeem
        '
        Me.objPaymentRedeem.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPaymentRedeem.Location = New System.Drawing.Point(171, 103)
        Me.objPaymentRedeem.MaxLength = 10
        Me.objPaymentRedeem.Name = "objPaymentRedeem"
        Me.objPaymentRedeem.Size = New System.Drawing.Size(250, 29)
        Me.objPaymentRedeem.TabIndex = 5
        Me.objPaymentRedeem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label12.Location = New System.Drawing.Point(97, 33)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 15)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Voucher.&Code"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'objPaymentVoucherCode
        '
        Me.objPaymentVoucherCode.Location = New System.Drawing.Point(171, 28)
        Me.objPaymentVoucherCode.MaxLength = 30
        Me.objPaymentVoucherCode.Name = "objPaymentVoucherCode"
        Me.objPaymentVoucherCode.ReadOnly = True
        Me.objPaymentVoucherCode.Size = New System.Drawing.Size(410, 20)
        Me.objPaymentVoucherCode.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label9.Location = New System.Drawing.Point(98, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 15)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "&Voucher"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'objPaymentVoucher
        '
        Me.objPaymentVoucher.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objPaymentVoucher.Location = New System.Drawing.Point(171, 69)
        Me.objPaymentVoucher.MaxLength = 10
        Me.objPaymentVoucher.Name = "objPaymentVoucher"
        Me.objPaymentVoucher.ReadOnly = True
        Me.objPaymentVoucher.Size = New System.Drawing.Size(250, 29)
        Me.objPaymentVoucher.TabIndex = 3
        Me.objPaymentVoucher.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.Label4.Size = New System.Drawing.Size(801, 18)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = ":: Add Disc / Voucher ::"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dlgTrnPosVoucher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(812, 494)
        Me.Controls.Add(Me.PnlFormMain)
        Me.Name = "dlgTrnPosVoucher"
        Me.Controls.SetChildIndex(Me.PnlFormMain, 0)
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlFormMain.ResumeLayout(False)
        Me.PnlFormMain.PerformLayout()
        Me.pnlAuth2.ResumeLayout(False)
        Me.pnlAuth2.PerformLayout()
        Me.Group02.ResumeLayout(False)
        Me.Group02.PerformLayout()
        Me.pnlAuth1.ResumeLayout(False)
        Me.pnlAuth1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlFormMain As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents objPaymentVoucherCode As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents objPaymentAddDisc As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents objPaymentVoucher As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents objPaymentRedeem As System.Windows.Forms.TextBox
    Friend WithEvents Group02 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlAuth2 As System.Windows.Forms.Panel
    Friend WithEvents pnlAuth1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents objUsername As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents objPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblAuthMsg As System.Windows.Forms.Label
    Friend WithEvents lblAuthOpen As System.Windows.Forms.Label
    Friend WithEvents lblAuthClose As System.Windows.Forms.LinkLabel
    Friend WithEvents lblReset As System.Windows.Forms.LinkLabel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents pnlAuth2Shadow As System.Windows.Forms.Panel
    Friend WithEvents btnF10 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents obj_VoucherId As System.Windows.Forms.Label
    Friend WithEvents btn_disc30 As System.Windows.Forms.Label
    Friend WithEvents btn_disc25 As System.Windows.Forms.Label
    Friend WithEvents btn_disc20 As System.Windows.Forms.Label
    Friend WithEvents btn_disc15 As System.Windows.Forms.Label
    Friend WithEvents btn_disc10 As System.Windows.Forms.Label
    Friend WithEvents btn_disc5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
