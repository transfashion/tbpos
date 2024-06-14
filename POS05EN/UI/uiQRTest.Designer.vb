<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiQRTest
    Inherits Translib.uiBase

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiQRTest))
        Me.Button1 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btn_newapi = New System.Windows.Forms.Button
        Me.txtVersion = New System.Windows.Forms.TextBox
        Me.btn_add = New System.Windows.Forms.Button
        Me.txtScale = New System.Windows.Forms.TextBox
        Me.txtQRCode = New System.Windows.Forms.TextBox
        Me.btnKalistaGenQR = New System.Windows.Forms.Button
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.tmrCheck = New System.Windows.Forms.Timer(Me.components)
        Me.txtMid = New System.Windows.Forms.TextBox
        Me.txtTid = New System.Windows.Forms.TextBox
        Me.txtPaymentType = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtRefNo = New System.Windows.Forms.TextBox
        Me.txtSeq = New System.Windows.Forms.TextBox
        Me.btnResetQR = New System.Windows.Forms.Button
        Me.txtResult = New System.Windows.Forms.TextBox
        CType(Me.dsMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bgwListLoader
        '
        Me.bgwListLoader.WorkerReportsProgress = True
        Me.bgwListLoader.WorkerSupportsCancellation = True
        '
        'bgwDataLoader
        '
        Me.bgwDataLoader.WorkerReportsProgress = True
        Me.bgwDataLoader.WorkerSupportsCancellation = True
        '
        'bgwSave
        '
        Me.bgwSave.WorkerReportsProgress = True
        Me.bgwSave.WorkerSupportsCancellation = True
        '
        'bgwNew
        '
        Me.bgwNew.WorkerReportsProgress = True
        Me.bgwNew.WorkerSupportsCancellation = True
        '
        'bgwMasterLoaderQueue
        '
        Me.bgwMasterLoaderQueue.WorkerReportsProgress = True
        Me.bgwMasterLoaderQueue.WorkerSupportsCancellation = True
        '
        'bgwMasterLoader
        '
        Me.bgwMasterLoader.WorkerReportsProgress = True
        Me.bgwMasterLoader.WorkerSupportsCancellation = True
        '
        'bgwPrintLoader
        '
        Me.bgwPrintLoader.WorkerReportsProgress = True
        Me.bgwPrintLoader.WorkerSupportsCancellation = True
        '
        'bgwPrintWeb
        '
        Me.bgwPrintWeb.WorkerReportsProgress = True
        Me.bgwPrintWeb.WorkerSupportsCancellation = True
        '
        'bgwDelete
        '
        Me.bgwDelete.WorkerReportsProgress = True
        Me.bgwDelete.WorkerSupportsCancellation = True
        '
        'fLoadingIndicator
        '
        Me.fLoadingIndicator.Location = New System.Drawing.Point(114, 109)
        Me.fLoadingIndicator.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LightGray
        Me.Button1.Location = New System.Drawing.Point(44, 62)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(148, 29)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(328, 62)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(279, 282)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'btn_newapi
        '
        Me.btn_newapi.Location = New System.Drawing.Point(21, 514)
        Me.btn_newapi.Name = "btn_newapi"
        Me.btn_newapi.Size = New System.Drawing.Size(148, 29)
        Me.btn_newapi.TabIndex = 3
        Me.btn_newapi.Text = "API Execute"
        Me.btn_newapi.UseVisualStyleBackColor = True
        '
        'txtVersion
        '
        Me.txtVersion.Location = New System.Drawing.Point(44, 116)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(48, 20)
        Me.txtVersion.TabIndex = 4
        Me.txtVersion.Text = "17"
        '
        'btn_add
        '
        Me.btn_add.Location = New System.Drawing.Point(98, 114)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(34, 23)
        Me.btn_add.TabIndex = 5
        Me.btn_add.Text = "+"
        Me.btn_add.UseVisualStyleBackColor = True
        '
        'txtScale
        '
        Me.txtScale.Location = New System.Drawing.Point(44, 142)
        Me.txtScale.Name = "txtScale"
        Me.txtScale.Size = New System.Drawing.Size(48, 20)
        Me.txtScale.TabIndex = 6
        Me.txtScale.Text = "3"
        '
        'txtQRCode
        '
        Me.txtQRCode.Location = New System.Drawing.Point(22, 193)
        Me.txtQRCode.Multiline = True
        Me.txtQRCode.Name = "txtQRCode"
        Me.txtQRCode.Size = New System.Drawing.Size(207, 163)
        Me.txtQRCode.TabIndex = 7
        Me.txtQRCode.Text = resources.GetString("txtQRCode.Text")
        '
        'btnKalistaGenQR
        '
        Me.btnKalistaGenQR.BackColor = System.Drawing.Color.Silver
        Me.btnKalistaGenQR.Location = New System.Drawing.Point(267, 514)
        Me.btnKalistaGenQR.Name = "btnKalistaGenQR"
        Me.btnKalistaGenQR.Size = New System.Drawing.Size(148, 29)
        Me.btnKalistaGenQR.TabIndex = 8
        Me.btnKalistaGenQR.Text = "Kalista Gen QR"
        Me.btnKalistaGenQR.UseVisualStyleBackColor = False
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(267, 474)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(48, 20)
        Me.txtAmount.TabIndex = 9
        Me.txtAmount.Text = "23"
        '
        'tmrCheck
        '
        Me.tmrCheck.Interval = 1000
        '
        'txtMid
        '
        Me.txtMid.Location = New System.Drawing.Point(267, 384)
        Me.txtMid.MaxLength = 11
        Me.txtMid.Name = "txtMid"
        Me.txtMid.Size = New System.Drawing.Size(148, 20)
        Me.txtMid.TabIndex = 10
        Me.txtMid.Text = "00000464644"
        '
        'txtTid
        '
        Me.txtTid.Location = New System.Drawing.Point(267, 410)
        Me.txtTid.MaxLength = 8
        Me.txtTid.Name = "txtTid"
        Me.txtTid.Size = New System.Drawing.Size(148, 20)
        Me.txtTid.TabIndex = 11
        Me.txtTid.Text = "70008746"
        '
        'txtPaymentType
        '
        Me.txtPaymentType.Location = New System.Drawing.Point(267, 436)
        Me.txtPaymentType.MaxLength = 6
        Me.txtPaymentType.Name = "txtPaymentType"
        Me.txtPaymentType.Size = New System.Drawing.Size(48, 20)
        Me.txtPaymentType.TabIndex = 12
        Me.txtPaymentType.Text = "000000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(234, 387)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "MID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(236, 413)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "TID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(186, 439)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Payment Type"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(218, 477)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Amount"
        '
        'txtRefNo
        '
        Me.txtRefNo.Location = New System.Drawing.Point(22, 362)
        Me.txtRefNo.MaxLength = 11
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(207, 20)
        Me.txtRefNo.TabIndex = 17
        '
        'txtSeq
        '
        Me.txtSeq.Location = New System.Drawing.Point(21, 388)
        Me.txtSeq.MaxLength = 11
        Me.txtSeq.Name = "txtSeq"
        Me.txtSeq.Size = New System.Drawing.Size(34, 20)
        Me.txtSeq.TabIndex = 18
        '
        'btnResetQR
        '
        Me.btnResetQR.BackColor = System.Drawing.Color.LightGray
        Me.btnResetQR.Location = New System.Drawing.Point(623, 514)
        Me.btnResetQR.Name = "btnResetQR"
        Me.btnResetQR.Size = New System.Drawing.Size(148, 29)
        Me.btnResetQR.TabIndex = 19
        Me.btnResetQR.Text = "Reset QR"
        Me.btnResetQR.UseVisualStyleBackColor = False
        '
        'txtResult
        '
        Me.txtResult.Location = New System.Drawing.Point(623, 362)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResult.Size = New System.Drawing.Size(330, 146)
        Me.txtResult.TabIndex = 20
        '
        'uiQRTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundworkerStatus = Translib.uiBase.EBackgroundworkerStatus.Done
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.btnResetQR)
        Me.Controls.Add(Me.txtSeq)
        Me.Controls.Add(Me.txtRefNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPaymentType)
        Me.Controls.Add(Me.txtTid)
        Me.Controls.Add(Me.txtMid)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.btnKalistaGenQR)
        Me.Controls.Add(Me.txtQRCode)
        Me.Controls.Add(Me.txtScale)
        Me.Controls.Add(Me.btn_add)
        Me.Controls.Add(Me.txtVersion)
        Me.Controls.Add(Me.btn_newapi)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Message = "Done. "
        Me.Name = "uiQRTest"
        Me.Progress = 20
        Me.Size = New System.Drawing.Size(968, 573)
        Me.Status = "Loading Data..."
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.Controls.SetChildIndex(Me.btn_newapi, 0)
        Me.Controls.SetChildIndex(Me.txtVersion, 0)
        Me.Controls.SetChildIndex(Me.btn_add, 0)
        Me.Controls.SetChildIndex(Me.txtScale, 0)
        Me.Controls.SetChildIndex(Me.txtQRCode, 0)
        Me.Controls.SetChildIndex(Me.btnKalistaGenQR, 0)
        Me.Controls.SetChildIndex(Me.txtAmount, 0)
        Me.Controls.SetChildIndex(Me.txtMid, 0)
        Me.Controls.SetChildIndex(Me.txtTid, 0)
        Me.Controls.SetChildIndex(Me.txtPaymentType, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtRefNo, 0)
        Me.Controls.SetChildIndex(Me.txtSeq, 0)
        Me.Controls.SetChildIndex(Me.btnResetQR, 0)
        Me.Controls.SetChildIndex(Me.txtResult, 0)
        CType(Me.dsMaster, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_newapi As System.Windows.Forms.Button
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents btn_add As System.Windows.Forms.Button
    Friend WithEvents txtScale As System.Windows.Forms.TextBox
    Friend WithEvents txtQRCode As System.Windows.Forms.TextBox
    Friend WithEvents btnKalistaGenQR As System.Windows.Forms.Button
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents tmrCheck As System.Windows.Forms.Timer
    Friend WithEvents txtMid As System.Windows.Forms.TextBox
    Friend WithEvents txtTid As System.Windows.Forms.TextBox
    Friend WithEvents txtPaymentType As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRefNo As System.Windows.Forms.TextBox
    Friend WithEvents txtSeq As System.Windows.Forms.TextBox
    Friend WithEvents btnResetQR As System.Windows.Forms.Button
    Friend WithEvents txtResult As System.Windows.Forms.TextBox

End Class
