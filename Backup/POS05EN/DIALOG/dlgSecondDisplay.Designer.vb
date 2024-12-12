<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSecondDisplay
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.pnl_SlideShow = New System.Windows.Forms.Panel
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.pnl_Desk = New System.Windows.Forms.Panel
        Me.lbl_Location = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Label8 = New System.Windows.Forms.Label
        Me.lbl_Total = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbl_DiscountPayment = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbl_SubTotal = New System.Windows.Forms.Label
        Me.txt_Nama = New System.Windows.Forms.Label
        Me.txt_Greeting = New System.Windows.Forms.Label
        Me.pnl_tfiQR = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.pnl_QR = New System.Windows.Forms.Panel
        Me.lbl_StoreName = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_PaymentTOTAL = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.pnl_SlideShow.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_Desk.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_tfiQR.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_QR.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnl_SlideShow)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnl_Desk)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnl_tfiQR)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnl_QR)
        Me.SplitContainer1.Size = New System.Drawing.Size(995, 503)
        Me.SplitContainer1.SplitterDistance = 610
        Me.SplitContainer1.TabIndex = 0
        '
        'pnl_SlideShow
        '
        Me.pnl_SlideShow.Controls.Add(Me.PictureBox2)
        Me.pnl_SlideShow.Location = New System.Drawing.Point(70, 33)
        Me.pnl_SlideShow.Name = "pnl_SlideShow"
        Me.pnl_SlideShow.Size = New System.Drawing.Size(400, 285)
        Me.pnl_SlideShow.TabIndex = 1
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Location = New System.Drawing.Point(198, 20)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(117, 89)
        Me.PictureBox2.TabIndex = 35
        Me.PictureBox2.TabStop = False
        '
        'pnl_Desk
        '
        Me.pnl_Desk.Controls.Add(Me.lbl_Location)
        Me.pnl_Desk.Controls.Add(Me.DataGridView1)
        Me.pnl_Desk.Controls.Add(Me.Label8)
        Me.pnl_Desk.Controls.Add(Me.lbl_Total)
        Me.pnl_Desk.Controls.Add(Me.Label10)
        Me.pnl_Desk.Controls.Add(Me.Label5)
        Me.pnl_Desk.Controls.Add(Me.lbl_DiscountPayment)
        Me.pnl_Desk.Controls.Add(Me.Label7)
        Me.pnl_Desk.Controls.Add(Me.Label3)
        Me.pnl_Desk.Controls.Add(Me.lbl_SubTotal)
        Me.pnl_Desk.Controls.Add(Me.txt_Nama)
        Me.pnl_Desk.Controls.Add(Me.txt_Greeting)
        Me.pnl_Desk.Location = New System.Drawing.Point(23, 21)
        Me.pnl_Desk.Name = "pnl_Desk"
        Me.pnl_Desk.Size = New System.Drawing.Size(346, 317)
        Me.pnl_Desk.TabIndex = 0
        '
        'lbl_Location
        '
        Me.lbl_Location.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Location.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Location.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Location.Location = New System.Drawing.Point(14, 25)
        Me.lbl_Location.Name = "lbl_Location"
        Me.lbl_Location.Size = New System.Drawing.Size(341, 18)
        Me.lbl_Location.TabIndex = 49
        Me.lbl_Location.Text = "HUGO BOSS PLAZA INDONESIA"
        Me.lbl_Location.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(17, 103)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(304, 37)
        Me.DataGridView1.TabIndex = 48
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.Color.Silver
        Me.Label8.Location = New System.Drawing.Point(18, 268)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(313, 1)
        Me.Label8.TabIndex = 46
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Total
        '
        Me.lbl_Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Total.Location = New System.Drawing.Point(158, 239)
        Me.lbl_Total.Name = "lbl_Total"
        Me.lbl_Total.Size = New System.Drawing.Size(173, 34)
        Me.lbl_Total.TabIndex = 47
        Me.lbl_Total.Text = "2,992,500"
        Me.lbl_Total.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 237)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 34)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Total"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Silver
        Me.Label5.Location = New System.Drawing.Point(18, 231)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(313, 1)
        Me.Label5.TabIndex = 43
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_DiscountPayment
        '
        Me.lbl_DiscountPayment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_DiscountPayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DiscountPayment.Location = New System.Drawing.Point(154, 202)
        Me.lbl_DiscountPayment.Name = "lbl_DiscountPayment"
        Me.lbl_DiscountPayment.Size = New System.Drawing.Size(177, 34)
        Me.lbl_DiscountPayment.TabIndex = 44
        Me.lbl_DiscountPayment.Text = "157,000"
        Me.lbl_DiscountPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 200)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 34)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Paym Disc"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.Silver
        Me.Label3.Location = New System.Drawing.Point(18, 193)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(313, 1)
        Me.Label3.TabIndex = 40
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_SubTotal
        '
        Me.lbl_SubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_SubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SubTotal.Location = New System.Drawing.Point(150, 164)
        Me.lbl_SubTotal.Name = "lbl_SubTotal"
        Me.lbl_SubTotal.Size = New System.Drawing.Size(181, 34)
        Me.lbl_SubTotal.TabIndex = 41
        Me.lbl_SubTotal.Text = "3,150,000"
        Me.lbl_SubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Nama
        '
        Me.txt_Nama.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Nama.Location = New System.Drawing.Point(16, 162)
        Me.txt_Nama.Name = "txt_Nama"
        Me.txt_Nama.Size = New System.Drawing.Size(96, 34)
        Me.txt_Nama.TabIndex = 39
        Me.txt_Nama.Text = "Sub Total"
        Me.txt_Nama.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_Greeting
        '
        Me.txt_Greeting.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Greeting.BackColor = System.Drawing.Color.Transparent
        Me.txt_Greeting.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Greeting.Location = New System.Drawing.Point(14, 74)
        Me.txt_Greeting.Name = "txt_Greeting"
        Me.txt_Greeting.Size = New System.Drawing.Size(341, 18)
        Me.txt_Greeting.TabIndex = 38
        Me.txt_Greeting.Text = "greeting"
        Me.txt_Greeting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txt_Greeting.Visible = False
        '
        'pnl_tfiQR
        '
        Me.pnl_tfiQR.Controls.Add(Me.Label2)
        Me.pnl_tfiQR.Controls.Add(Me.PictureBox3)
        Me.pnl_tfiQR.Location = New System.Drawing.Point(338, 370)
        Me.pnl_tfiQR.Name = "pnl_tfiQR"
        Me.pnl_tfiQR.Size = New System.Drawing.Size(300, 295)
        Me.pnl_tfiQR.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(279, 18)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Please Scan QR to open TFI WebSite"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Location = New System.Drawing.Point(49, 104)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(200, 191)
        Me.PictureBox3.TabIndex = 35
        Me.PictureBox3.TabStop = False
        '
        'pnl_QR
        '
        Me.pnl_QR.Controls.Add(Me.lbl_StoreName)
        Me.pnl_QR.Controls.Add(Me.Label1)
        Me.pnl_QR.Controls.Add(Me.txt_PaymentTOTAL)
        Me.pnl_QR.Controls.Add(Me.PictureBox1)
        Me.pnl_QR.Location = New System.Drawing.Point(3, 12)
        Me.pnl_QR.Name = "pnl_QR"
        Me.pnl_QR.Size = New System.Drawing.Size(320, 443)
        Me.pnl_QR.TabIndex = 1
        '
        'lbl_StoreName
        '
        Me.lbl_StoreName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_StoreName.BackColor = System.Drawing.Color.Transparent
        Me.lbl_StoreName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_StoreName.Location = New System.Drawing.Point(23, 296)
        Me.lbl_StoreName.Name = "lbl_StoreName"
        Me.lbl_StoreName.Size = New System.Drawing.Size(279, 18)
        Me.lbl_StoreName.TabIndex = 37
        Me.lbl_StoreName.Text = "Store Name"
        Me.lbl_StoreName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(279, 18)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Please Scan QR Code bellow"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_PaymentTOTAL
        '
        Me.txt_PaymentTOTAL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_PaymentTOTAL.BackColor = System.Drawing.Color.Transparent
        Me.txt_PaymentTOTAL.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PaymentTOTAL.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txt_PaymentTOTAL.Location = New System.Drawing.Point(33, 320)
        Me.txt_PaymentTOTAL.Name = "txt_PaymentTOTAL"
        Me.txt_PaymentTOTAL.Size = New System.Drawing.Size(255, 44)
        Me.txt_PaymentTOTAL.TabIndex = 35
        Me.txt_PaymentTOTAL.Text = "99,000,000"
        Me.txt_PaymentTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Location = New System.Drawing.Point(60, 143)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(204, 131)
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        '
        'Timer2
        '
        Me.Timer2.Interval = 5000
        '
        'dlgSecondDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 503)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "dlgSecondDisplay"
        Me.Text = "dlgSecondDisplay"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.pnl_SlideShow.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_Desk.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_tfiQR.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_QR.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents pnl_SlideShow As System.Windows.Forms.Panel
    Friend WithEvents pnl_Desk As System.Windows.Forms.Panel
    Friend WithEvents pnl_QR As System.Windows.Forms.Panel
    Friend WithEvents lbl_StoreName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_PaymentTOTAL As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    'Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents pnl_tfiQR As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents txt_Greeting As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbl_Total As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_DiscountPayment As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_SubTotal As System.Windows.Forms.Label
    Friend WithEvents txt_Nama As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_Location As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
End Class
