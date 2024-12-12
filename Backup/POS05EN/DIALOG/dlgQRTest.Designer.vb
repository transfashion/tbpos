<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgQRTest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgQRTest))
        Me.btn_QRGenerate = New System.Windows.Forms.Button
        Me.txtQRCode = New System.Windows.Forms.TextBox
        Me.picQRCode = New System.Windows.Forms.PictureBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPaymentType = New System.Windows.Forms.TextBox
        Me.txtTid = New System.Windows.Forms.TextBox
        Me.txtMid = New System.Windows.Forms.TextBox
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.btn_GenerateQris = New System.Windows.Forms.Button
        Me.btn_CheckStatus = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txt_QrisStatus = New System.Windows.Forms.TextBox
        Me.txt_GenerateQrisResult = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_Reference = New System.Windows.Forms.TextBox
        Me.txt_QrisProxy = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_QRCode = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtScale = New System.Windows.Forms.TextBox
        Me.txtVersion = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.btn_Reset = New System.Windows.Forms.Button
        Me.btn_StatusClear = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_QRGenerate
        '
        Me.btn_QRGenerate.Location = New System.Drawing.Point(90, 190)
        Me.btn_QRGenerate.Name = "btn_QRGenerate"
        Me.btn_QRGenerate.Size = New System.Drawing.Size(132, 32)
        Me.btn_QRGenerate.TabIndex = 0
        Me.btn_QRGenerate.Text = "Generate QR"
        Me.btn_QRGenerate.UseVisualStyleBackColor = True
        '
        'txtQRCode
        '
        Me.txtQRCode.Location = New System.Drawing.Point(15, 21)
        Me.txtQRCode.Multiline = True
        Me.txtQRCode.Name = "txtQRCode"
        Me.txtQRCode.Size = New System.Drawing.Size(207, 163)
        Me.txtQRCode.TabIndex = 9
        Me.txtQRCode.Text = resources.GetString("txtQRCode.Text")
        '
        'picQRCode
        '
        Me.picQRCode.Location = New System.Drawing.Point(265, 21)
        Me.picQRCode.Name = "picQRCode"
        Me.picQRCode.Size = New System.Drawing.Size(279, 282)
        Me.picQRCode.TabIndex = 8
        Me.picQRCode.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(23, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(870, 577)
        Me.TabControl1.TabIndex = 10
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtQRCode)
        Me.TabPage1.Controls.Add(Me.btn_QRGenerate)
        Me.TabPage1.Controls.Add(Me.picQRCode)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(862, 508)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "QR Generator"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btn_Reset)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.txtScale)
        Me.TabPage2.Controls.Add(Me.txtVersion)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.txt_QRCode)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.txt_QrisProxy)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.txt_Reference)
        Me.TabPage2.Controls.Add(Me.txt_GenerateQrisResult)
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Controls.Add(Me.btn_GenerateQris)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.txtPaymentType)
        Me.TabPage2.Controls.Add(Me.txtTid)
        Me.TabPage2.Controls.Add(Me.txtMid)
        Me.TabPage2.Controls.Add(Me.txtAmount)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(862, 551)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "QRIS"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(49, 155)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Amount"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Payment Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(67, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "TID"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(65, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "MID"
        '
        'txtPaymentType
        '
        Me.txtPaymentType.Location = New System.Drawing.Point(98, 114)
        Me.txtPaymentType.MaxLength = 6
        Me.txtPaymentType.Name = "txtPaymentType"
        Me.txtPaymentType.Size = New System.Drawing.Size(48, 20)
        Me.txtPaymentType.TabIndex = 20
        Me.txtPaymentType.Text = "000000"
        '
        'txtTid
        '
        Me.txtTid.Location = New System.Drawing.Point(98, 88)
        Me.txtTid.MaxLength = 8
        Me.txtTid.Name = "txtTid"
        Me.txtTid.Size = New System.Drawing.Size(148, 20)
        Me.txtTid.TabIndex = 19
        Me.txtTid.Text = "70008746"
        '
        'txtMid
        '
        Me.txtMid.Location = New System.Drawing.Point(98, 62)
        Me.txtMid.MaxLength = 11
        Me.txtMid.Name = "txtMid"
        Me.txtMid.Size = New System.Drawing.Size(148, 20)
        Me.txtMid.TabIndex = 18
        Me.txtMid.Text = "00000464644"
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(98, 152)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(48, 20)
        Me.txtAmount.TabIndex = 17
        Me.txtAmount.Text = "23"
        '
        'btn_GenerateQris
        '
        Me.btn_GenerateQris.Location = New System.Drawing.Point(98, 209)
        Me.btn_GenerateQris.Name = "btn_GenerateQris"
        Me.btn_GenerateQris.Size = New System.Drawing.Size(148, 29)
        Me.btn_GenerateQris.TabIndex = 25
        Me.btn_GenerateQris.Text = "Generate QRIS"
        Me.btn_GenerateQris.UseVisualStyleBackColor = True
        '
        'btn_CheckStatus
        '
        Me.btn_CheckStatus.Location = New System.Drawing.Point(18, 301)
        Me.btn_CheckStatus.Name = "btn_CheckStatus"
        Me.btn_CheckStatus.Size = New System.Drawing.Size(148, 29)
        Me.btn_CheckStatus.TabIndex = 26
        Me.btn_CheckStatus.Text = "Check Status"
        Me.btn_CheckStatus.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txt_QrisStatus)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(475, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(384, 545)
        Me.Panel1.TabIndex = 27
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(18, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(279, 282)
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.btn_StatusClear)
        Me.Panel2.Controls.Add(Me.btn_CheckStatus)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(5, 5)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(374, 413)
        Me.Panel2.TabIndex = 29
        '
        'txt_QrisStatus
        '
        Me.txt_QrisStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_QrisStatus.Location = New System.Drawing.Point(5, 418)
        Me.txt_QrisStatus.Multiline = True
        Me.txt_QrisStatus.Name = "txt_QrisStatus"
        Me.txt_QrisStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_QrisStatus.Size = New System.Drawing.Size(374, 122)
        Me.txt_QrisStatus.TabIndex = 30
        '
        'txt_GenerateQrisResult
        '
        Me.txt_GenerateQrisResult.Location = New System.Drawing.Point(98, 253)
        Me.txt_GenerateQrisResult.Multiline = True
        Me.txt_GenerateQrisResult.Name = "txt_GenerateQrisResult"
        Me.txt_GenerateQrisResult.ReadOnly = True
        Me.txt_GenerateQrisResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_GenerateQrisResult.Size = New System.Drawing.Size(361, 99)
        Me.txt_GenerateQrisResult.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 463)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Reference"
        '
        'txt_Reference
        '
        Me.txt_Reference.Location = New System.Drawing.Point(98, 460)
        Me.txt_Reference.MaxLength = 11
        Me.txt_Reference.Name = "txt_Reference"
        Me.txt_Reference.ReadOnly = True
        Me.txt_Reference.Size = New System.Drawing.Size(148, 20)
        Me.txt_Reference.TabIndex = 29
        '
        'txt_QrisProxy
        '
        Me.txt_QrisProxy.Location = New System.Drawing.Point(98, 18)
        Me.txt_QrisProxy.MaxLength = 11
        Me.txt_QrisProxy.Name = "txt_QrisProxy"
        Me.txt_QrisProxy.Size = New System.Drawing.Size(361, 20)
        Me.txt_QrisProxy.TabIndex = 31
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(59, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Proxy"
        '
        'txt_QRCode
        '
        Me.txt_QRCode.Location = New System.Drawing.Point(98, 358)
        Me.txt_QRCode.Multiline = True
        Me.txt_QRCode.Name = "txt_QRCode"
        Me.txt_QRCode.ReadOnly = True
        Me.txt_QRCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_QRCode.Size = New System.Drawing.Size(361, 93)
        Me.txt_QRCode.TabIndex = 33
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(55, 256)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Result"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(44, 361)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "QRCode"
        '
        'txtScale
        '
        Me.txtScale.Location = New System.Drawing.Point(411, 91)
        Me.txtScale.Name = "txtScale"
        Me.txtScale.Size = New System.Drawing.Size(48, 20)
        Me.txtScale.TabIndex = 37
        Me.txtScale.Text = "3"
        '
        'txtVersion
        '
        Me.txtVersion.Location = New System.Drawing.Point(411, 65)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(48, 20)
        Me.txtVersion.TabIndex = 36
        Me.txtVersion.Text = "17"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(363, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Version"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(371, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "Scale"
        '
        'btn_Reset
        '
        Me.btn_Reset.Location = New System.Drawing.Point(98, 497)
        Me.btn_Reset.Name = "btn_Reset"
        Me.btn_Reset.Size = New System.Drawing.Size(148, 29)
        Me.btn_Reset.TabIndex = 40
        Me.btn_Reset.Text = "Reset"
        Me.btn_Reset.UseVisualStyleBackColor = True
        '
        'btn_StatusClear
        '
        Me.btn_StatusClear.Location = New System.Drawing.Point(172, 301)
        Me.btn_StatusClear.Name = "btn_StatusClear"
        Me.btn_StatusClear.Size = New System.Drawing.Size(148, 29)
        Me.btn_StatusClear.TabIndex = 28
        Me.btn_StatusClear.Text = "Clear"
        Me.btn_StatusClear.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(18, 370)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(324, 20)
        Me.TextBox1.TabIndex = 29
        Me.TextBox1.Text = "https://merchant.bankmega.app/simulator/"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 354)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(189, 13)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "Simulasi Pembayaran (copas QRCode)"
        '
        'dlgQRTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 620)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "dlgQRTest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "dlgQRTest"
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_QRGenerate As System.Windows.Forms.Button
    Friend WithEvents txtQRCode As System.Windows.Forms.TextBox
    Friend WithEvents picQRCode As System.Windows.Forms.PictureBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPaymentType As System.Windows.Forms.TextBox
    Friend WithEvents txtTid As System.Windows.Forms.TextBox
    Friend WithEvents txtMid As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents btn_GenerateQris As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_CheckStatus As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txt_QrisStatus As System.Windows.Forms.TextBox
    Friend WithEvents txt_GenerateQrisResult As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_Reference As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_QrisProxy As System.Windows.Forms.TextBox
    Friend WithEvents txt_QRCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtScale As System.Windows.Forms.TextBox
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btn_Reset As System.Windows.Forms.Button
    Friend WithEvents btn_StatusClear As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
