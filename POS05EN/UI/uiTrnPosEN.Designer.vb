<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnPosEN
    Inherits Translib.uiBase

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiTrnPosEN))
        Me.btnOpenPOSConsole = New System.Windows.Forms.Button()
        Me.btnRePrint = New System.Windows.Forms.Button()
        Me.btnClosing = New System.Windows.Forms.Button()
        Me.objBonId = New System.Windows.Forms.TextBox()
        Me.chkBonPreview = New System.Windows.Forms.CheckBox()
        Me.chkMachineOnly = New System.Windows.Forms.CheckBox()
        Me.objDate = New System.Windows.Forms.DateTimePicker()
        Me.groupClossing = New System.Windows.Forms.GroupBox()
        Me.chkClosingPreviewOnly = New System.Windows.Forms.CheckBox()
        Me.chkTransactionSummary = New System.Windows.Forms.CheckBox()
        Me.chkBonRekap = New System.Windows.Forms.CheckBox()
        Me.chkArticleBreakdown = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.groupTransaction = New System.Windows.Forms.GroupBox()
        Me.btnOpenPOSReturNote = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnViewDetil = New System.Windows.Forms.Button()
        Me.btnVoid = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSignOff = New System.Windows.Forms.Button()
        Me.groupSalesSend = New System.Windows.Forms.GroupBox()
        Me.obj_txt_senddatamode = New System.Windows.Forms.Label()
        Me.lblAutosendStatus = New System.Windows.Forms.Label()
        Me.LabelDataSend = New System.Windows.Forms.Label()
        Me.ProgressBarDataSend = New System.Windows.Forms.ProgressBar()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtSalesTobeSent = New System.Windows.Forms.DateTimePicker()
        Me.btnSignIn = New System.Windows.Forms.Button()
        Me.ProgressBarDataUpdate = New System.Windows.Forms.ProgressBar()
        Me.LabelDataUpdate = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.obj_last_synsign_id = New System.Windows.Forms.Label()
        Me.objKey = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.groupPOSConsole = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.LabelSignoff = New System.Windows.Forms.Label()
        Me.ProgressBarSignoff = New System.Windows.Forms.ProgressBar()
        Me.lblRemoteWebservice = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblLocationStatus = New System.Windows.Forms.Label()
        Me.pnlAuth2 = New System.Windows.Forms.Panel()
        Me.lblAuthClose = New System.Windows.Forms.LinkLabel()
        Me.lblReset = New System.Windows.Forms.LinkLabel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblAuthMsg = New System.Windows.Forms.Label()
        Me.btnVoidOpen = New System.Windows.Forms.Button()
        Me.objPassword = New System.Windows.Forms.TextBox()
        Me.objUsername = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlAuth2Shadow = New System.Windows.Forms.Panel()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.LabelUpdateBin = New System.Windows.Forms.Label()
        Me.ProgressBarUpdatebin = New System.Windows.Forms.ProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_TestQris = New System.Windows.Forms.Button()
        Me.btn_testVoucher = New System.Windows.Forms.Button()
        Me.btnShowParameter = New System.Windows.Forms.LinkLabel()
        Me.btnUpdateManual = New System.Windows.Forms.Button()
        Me.TimerAutosendData = New System.Windows.Forms.Timer(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        CType(Me.dsMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupClossing.SuspendLayout()
        Me.groupTransaction.SuspendLayout()
        Me.groupSalesSend.SuspendLayout()
        Me.groupPOSConsole.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlAuth2.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.fLoadingIndicator.Location = New System.Drawing.Point(178, 223)
        Me.fLoadingIndicator.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        '
        'btnOpenPOSConsole
        '
        Me.btnOpenPOSConsole.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenPOSConsole.ForeColor = System.Drawing.Color.Black
        Me.btnOpenPOSConsole.Location = New System.Drawing.Point(103, 61)
        Me.btnOpenPOSConsole.Name = "btnOpenPOSConsole"
        Me.btnOpenPOSConsole.Size = New System.Drawing.Size(185, 39)
        Me.btnOpenPOSConsole.TabIndex = 1
        Me.btnOpenPOSConsole.Text = "&Open POS Console"
        Me.btnOpenPOSConsole.UseVisualStyleBackColor = True
        '
        'btnRePrint
        '
        Me.btnRePrint.ForeColor = System.Drawing.Color.Black
        Me.btnRePrint.Location = New System.Drawing.Point(79, 43)
        Me.btnRePrint.Name = "btnRePrint"
        Me.btnRePrint.Size = New System.Drawing.Size(90, 23)
        Me.btnRePrint.TabIndex = 2
        Me.btnRePrint.Text = "Re-Print Bon"
        Me.btnRePrint.UseVisualStyleBackColor = True
        '
        'btnClosing
        '
        Me.btnClosing.Enabled = False
        Me.btnClosing.ForeColor = System.Drawing.Color.Black
        Me.btnClosing.Location = New System.Drawing.Point(78, 111)
        Me.btnClosing.Name = "btnClosing"
        Me.btnClosing.Size = New System.Drawing.Size(133, 23)
        Me.btnClosing.TabIndex = 3
        Me.btnClosing.Text = "Print Closing Report"
        Me.btnClosing.UseVisualStyleBackColor = True
        '
        'objBonId
        '
        Me.objBonId.Location = New System.Drawing.Point(79, 18)
        Me.objBonId.Name = "objBonId"
        Me.objBonId.Size = New System.Drawing.Size(142, 20)
        Me.objBonId.TabIndex = 5
        Me.objBonId.Text = "010.010.10.0600000024"
        '
        'chkBonPreview
        '
        Me.chkBonPreview.AutoSize = True
        Me.chkBonPreview.BackColor = System.Drawing.Color.Transparent
        Me.chkBonPreview.Checked = True
        Me.chkBonPreview.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBonPreview.Location = New System.Drawing.Point(227, 21)
        Me.chkBonPreview.Name = "chkBonPreview"
        Me.chkBonPreview.Size = New System.Drawing.Size(88, 17)
        Me.chkBonPreview.TabIndex = 6
        Me.chkBonPreview.Text = "Preview Only"
        Me.chkBonPreview.UseVisualStyleBackColor = False
        '
        'chkMachineOnly
        '
        Me.chkMachineOnly.AutoSize = True
        Me.chkMachineOnly.BackColor = System.Drawing.Color.Transparent
        Me.chkMachineOnly.Checked = True
        Me.chkMachineOnly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMachineOnly.Location = New System.Drawing.Point(214, 48)
        Me.chkMachineOnly.Name = "chkMachineOnly"
        Me.chkMachineOnly.Size = New System.Drawing.Size(114, 17)
        Me.chkMachineOnly.TabIndex = 7
        Me.chkMachineOnly.Text = "This Machine Only"
        Me.chkMachineOnly.UseVisualStyleBackColor = False
        '
        'objDate
        '
        Me.objDate.CustomFormat = "dd/MM/yyyy"
        Me.objDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.objDate.Location = New System.Drawing.Point(79, 19)
        Me.objDate.Name = "objDate"
        Me.objDate.Size = New System.Drawing.Size(93, 20)
        Me.objDate.TabIndex = 8
        '
        'groupClossing
        '
        Me.groupClossing.BackColor = System.Drawing.Color.Transparent
        Me.groupClossing.Controls.Add(Me.chkClosingPreviewOnly)
        Me.groupClossing.Controls.Add(Me.chkTransactionSummary)
        Me.groupClossing.Controls.Add(Me.chkBonRekap)
        Me.groupClossing.Controls.Add(Me.chkArticleBreakdown)
        Me.groupClossing.Controls.Add(Me.Label2)
        Me.groupClossing.Controls.Add(Me.Label1)
        Me.groupClossing.Controls.Add(Me.chkMachineOnly)
        Me.groupClossing.Controls.Add(Me.btnClosing)
        Me.groupClossing.Controls.Add(Me.objDate)
        Me.groupClossing.Location = New System.Drawing.Point(5, 174)
        Me.groupClossing.Name = "groupClossing"
        Me.groupClossing.Size = New System.Drawing.Size(350, 161)
        Me.groupClossing.TabIndex = 9
        Me.groupClossing.TabStop = False
        Me.groupClossing.Text = "Closing"
        '
        'chkClosingPreviewOnly
        '
        Me.chkClosingPreviewOnly.AutoSize = True
        Me.chkClosingPreviewOnly.BackColor = System.Drawing.Color.Transparent
        Me.chkClosingPreviewOnly.Checked = True
        Me.chkClosingPreviewOnly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkClosingPreviewOnly.Location = New System.Drawing.Point(79, 140)
        Me.chkClosingPreviewOnly.Name = "chkClosingPreviewOnly"
        Me.chkClosingPreviewOnly.Size = New System.Drawing.Size(88, 17)
        Me.chkClosingPreviewOnly.TabIndex = 10
        Me.chkClosingPreviewOnly.Text = "Preview Only"
        Me.chkClosingPreviewOnly.UseVisualStyleBackColor = False
        '
        'chkTransactionSummary
        '
        Me.chkTransactionSummary.AutoSize = True
        Me.chkTransactionSummary.BackColor = System.Drawing.Color.Transparent
        Me.chkTransactionSummary.Checked = True
        Me.chkTransactionSummary.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTransactionSummary.Location = New System.Drawing.Point(79, 48)
        Me.chkTransactionSummary.Name = "chkTransactionSummary"
        Me.chkTransactionSummary.Size = New System.Drawing.Size(128, 17)
        Me.chkTransactionSummary.TabIndex = 13
        Me.chkTransactionSummary.Text = "Transaction Summary"
        Me.chkTransactionSummary.UseVisualStyleBackColor = False
        '
        'chkBonRekap
        '
        Me.chkBonRekap.AutoSize = True
        Me.chkBonRekap.BackColor = System.Drawing.Color.Transparent
        Me.chkBonRekap.Enabled = False
        Me.chkBonRekap.Location = New System.Drawing.Point(79, 66)
        Me.chkBonRekap.Name = "chkBonRekap"
        Me.chkBonRekap.Size = New System.Drawing.Size(80, 17)
        Me.chkBonRekap.TabIndex = 12
        Me.chkBonRekap.Text = "Bon Rekap"
        Me.chkBonRekap.UseVisualStyleBackColor = False
        '
        'chkArticleBreakdown
        '
        Me.chkArticleBreakdown.AutoSize = True
        Me.chkArticleBreakdown.BackColor = System.Drawing.Color.Transparent
        Me.chkArticleBreakdown.Enabled = False
        Me.chkArticleBreakdown.Location = New System.Drawing.Point(79, 84)
        Me.chkArticleBreakdown.Name = "chkArticleBreakdown"
        Me.chkArticleBreakdown.Size = New System.Drawing.Size(112, 17)
        Me.chkArticleBreakdown.TabIndex = 11
        Me.chkArticleBreakdown.Text = "Article Breakdown"
        Me.chkArticleBreakdown.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Report"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Date"
        '
        'groupTransaction
        '
        Me.groupTransaction.BackColor = System.Drawing.Color.Transparent
        Me.groupTransaction.Controls.Add(Me.Label13)
        Me.groupTransaction.Controls.Add(Me.btnOpenPOSReturNote)
        Me.groupTransaction.Controls.Add(Me.Label4)
        Me.groupTransaction.Controls.Add(Me.btnViewDetil)
        Me.groupTransaction.Controls.Add(Me.btnVoid)
        Me.groupTransaction.Controls.Add(Me.Label3)
        Me.groupTransaction.Controls.Add(Me.objBonId)
        Me.groupTransaction.Controls.Add(Me.chkBonPreview)
        Me.groupTransaction.Controls.Add(Me.btnRePrint)
        Me.groupTransaction.Location = New System.Drawing.Point(379, 174)
        Me.groupTransaction.Name = "groupTransaction"
        Me.groupTransaction.Size = New System.Drawing.Size(374, 161)
        Me.groupTransaction.TabIndex = 10
        Me.groupTransaction.TabStop = False
        Me.groupTransaction.Text = "Transaction"
        '
        'btnOpenPOSReturNote
        '
        Me.btnOpenPOSReturNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btnOpenPOSReturNote.ForeColor = System.Drawing.Color.Black
        Me.btnOpenPOSReturNote.Location = New System.Drawing.Point(179, 43)
        Me.btnOpenPOSReturNote.Name = "btnOpenPOSReturNote"
        Me.btnOpenPOSReturNote.Size = New System.Drawing.Size(90, 23)
        Me.btnOpenPOSReturNote.TabIndex = 2
        Me.btnOpenPOSReturNote.Text = "&Nota Retur"
        Me.btnOpenPOSReturNote.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(176, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(173, 39)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Authentication Required *" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "dan hanya berlaku untuk transaksi " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "hari ini"
        '
        'btnViewDetil
        '
        Me.btnViewDetil.ForeColor = System.Drawing.Color.Black
        Me.btnViewDetil.Location = New System.Drawing.Point(79, 70)
        Me.btnViewDetil.Name = "btnViewDetil"
        Me.btnViewDetil.Size = New System.Drawing.Size(90, 23)
        Me.btnViewDetil.TabIndex = 13
        Me.btnViewDetil.Text = "View Detil Bon"
        Me.btnViewDetil.UseVisualStyleBackColor = True
        '
        'btnVoid
        '
        Me.btnVoid.ForeColor = System.Drawing.Color.Black
        Me.btnVoid.Location = New System.Drawing.Point(79, 110)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(90, 23)
        Me.btnVoid.TabIndex = 11
        Me.btnVoid.Text = "Void"
        Me.btnVoid.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Bon"
        '
        'btnSignOff
        '
        Me.btnSignOff.ForeColor = System.Drawing.Color.Black
        Me.btnSignOff.Location = New System.Drawing.Point(5, 408)
        Me.btnSignOff.Name = "btnSignOff"
        Me.btnSignOff.Size = New System.Drawing.Size(121, 26)
        Me.btnSignOff.TabIndex = 12
        Me.btnSignOff.Text = "Sign Off"
        Me.btnSignOff.UseVisualStyleBackColor = True
        '
        'groupSalesSend
        '
        Me.groupSalesSend.BackColor = System.Drawing.Color.Transparent
        Me.groupSalesSend.Controls.Add(Me.Label15)
        Me.groupSalesSend.Controls.Add(Me.obj_txt_senddatamode)
        Me.groupSalesSend.Controls.Add(Me.lblAutosendStatus)
        Me.groupSalesSend.Controls.Add(Me.LabelDataSend)
        Me.groupSalesSend.Controls.Add(Me.ProgressBarDataSend)
        Me.groupSalesSend.Controls.Add(Me.btnSend)
        Me.groupSalesSend.Controls.Add(Me.Label5)
        Me.groupSalesSend.Controls.Add(Me.dtSalesTobeSent)
        Me.groupSalesSend.Location = New System.Drawing.Point(5, 337)
        Me.groupSalesSend.Name = "groupSalesSend"
        Me.groupSalesSend.Size = New System.Drawing.Size(748, 63)
        Me.groupSalesSend.TabIndex = 13
        Me.groupSalesSend.TabStop = False
        Me.groupSalesSend.Text = "Data Sales"
        '
        'obj_txt_senddatamode
        '
        Me.obj_txt_senddatamode.Location = New System.Drawing.Point(668, 12)
        Me.obj_txt_senddatamode.Name = "obj_txt_senddatamode"
        Me.obj_txt_senddatamode.Size = New System.Drawing.Size(71, 13)
        Me.obj_txt_senddatamode.TabIndex = 36
        Me.obj_txt_senddatamode.Text = "obj_txt_senddatamode"
        Me.obj_txt_senddatamode.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblAutosendStatus
        '
        Me.lblAutosendStatus.AutoSize = True
        Me.lblAutosendStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblAutosendStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutosendStatus.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblAutosendStatus.Location = New System.Drawing.Point(79, 48)
        Me.lblAutosendStatus.Name = "lblAutosendStatus"
        Me.lblAutosendStatus.Size = New System.Drawing.Size(127, 12)
        Me.lblAutosendStatus.TabIndex = 35
        Me.lblAutosendStatus.Text = "autosend is on, inverval 5 min"
        '
        'LabelDataSend
        '
        Me.LabelDataSend.BackColor = System.Drawing.Color.Transparent
        Me.LabelDataSend.Location = New System.Drawing.Point(255, 19)
        Me.LabelDataSend.Name = "LabelDataSend"
        Me.LabelDataSend.Size = New System.Drawing.Size(322, 15)
        Me.LabelDataSend.TabIndex = 19
        Me.LabelDataSend.Text = "Updating..."
        Me.LabelDataSend.Visible = False
        '
        'ProgressBarDataSend
        '
        Me.ProgressBarDataSend.Location = New System.Drawing.Point(255, 37)
        Me.ProgressBarDataSend.Name = "ProgressBarDataSend"
        Me.ProgressBarDataSend.Size = New System.Drawing.Size(322, 10)
        Me.ProgressBarDataSend.TabIndex = 18
        Me.ProgressBarDataSend.Visible = False
        '
        'btnSend
        '
        Me.btnSend.ForeColor = System.Drawing.Color.Black
        Me.btnSend.Location = New System.Drawing.Point(178, 23)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(61, 23)
        Me.btnSend.TabIndex = 13
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(43, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Date"
        '
        'dtSalesTobeSent
        '
        Me.dtSalesTobeSent.CustomFormat = "dd/MM/yyyy"
        Me.dtSalesTobeSent.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtSalesTobeSent.Location = New System.Drawing.Point(79, 25)
        Me.dtSalesTobeSent.Name = "dtSalesTobeSent"
        Me.dtSalesTobeSent.Size = New System.Drawing.Size(93, 20)
        Me.dtSalesTobeSent.TabIndex = 10
        '
        'btnSignIn
        '
        Me.btnSignIn.ForeColor = System.Drawing.Color.Black
        Me.btnSignIn.Location = New System.Drawing.Point(5, 72)
        Me.btnSignIn.Name = "btnSignIn"
        Me.btnSignIn.Size = New System.Drawing.Size(121, 23)
        Me.btnSignIn.TabIndex = 14
        Me.btnSignIn.Text = "Sign In"
        Me.btnSignIn.UseVisualStyleBackColor = True
        '
        'ProgressBarDataUpdate
        '
        Me.ProgressBarDataUpdate.Location = New System.Drawing.Point(140, 85)
        Me.ProgressBarDataUpdate.Name = "ProgressBarDataUpdate"
        Me.ProgressBarDataUpdate.Size = New System.Drawing.Size(215, 10)
        Me.ProgressBarDataUpdate.TabIndex = 16
        Me.ProgressBarDataUpdate.Visible = False
        '
        'LabelDataUpdate
        '
        Me.LabelDataUpdate.BackColor = System.Drawing.Color.Transparent
        Me.LabelDataUpdate.Location = New System.Drawing.Point(140, 67)
        Me.LabelDataUpdate.Name = "LabelDataUpdate"
        Me.LabelDataUpdate.Size = New System.Drawing.Size(215, 15)
        Me.LabelDataUpdate.TabIndex = 17
        Me.LabelDataUpdate.Text = "Updating..."
        Me.LabelDataUpdate.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Location = New System.Drawing.Point(5, 28)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 13)
        Me.lblStatus.TabIndex = 18
        Me.lblStatus.Text = "Label6"
        '
        'obj_last_synsign_id
        '
        Me.obj_last_synsign_id.AutoSize = True
        Me.obj_last_synsign_id.BackColor = System.Drawing.Color.Transparent
        Me.obj_last_synsign_id.Location = New System.Drawing.Point(5, 45)
        Me.obj_last_synsign_id.Name = "obj_last_synsign_id"
        Me.obj_last_synsign_id.Size = New System.Drawing.Size(78, 13)
        Me.obj_last_synsign_id.TabIndex = 19
        Me.obj_last_synsign_id.Text = "last_synsign_id"
        '
        'objKey
        '
        Me.objKey.Location = New System.Drawing.Point(640, 411)
        Me.objKey.Name = "objKey"
        Me.objKey.Size = New System.Drawing.Size(113, 20)
        Me.objKey.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(607, 416)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 18)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Key"
        '
        'groupPOSConsole
        '
        Me.groupPOSConsole.BackColor = System.Drawing.Color.Transparent
        Me.groupPOSConsole.Controls.Add(Me.Label10)
        Me.groupPOSConsole.Controls.Add(Me.LabelVersion)
        Me.groupPOSConsole.Controls.Add(Me.btnOpenPOSConsole)
        Me.groupPOSConsole.Location = New System.Drawing.Point(379, 23)
        Me.groupPOSConsole.Name = "groupPOSConsole"
        Me.groupPOSConsole.Size = New System.Drawing.Size(374, 145)
        Me.groupPOSConsole.TabIndex = 22
        Me.groupPOSConsole.TabStop = False
        Me.groupPOSConsole.Text = "POS Console"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(6, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(359, 13)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Migrate ke .NET 4.8"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelVersion
        '
        Me.LabelVersion.BackColor = System.Drawing.Color.Transparent
        Me.LabelVersion.Location = New System.Drawing.Point(6, 13)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(359, 13)
        Me.LabelVersion.TabIndex = 34
        Me.LabelVersion.Text = "HE.POS v5.50124 rev 18"
        Me.LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelSignoff
        '
        Me.LabelSignoff.BackColor = System.Drawing.Color.Transparent
        Me.LabelSignoff.Location = New System.Drawing.Point(140, 407)
        Me.LabelSignoff.Name = "LabelSignoff"
        Me.LabelSignoff.Size = New System.Drawing.Size(215, 15)
        Me.LabelSignoff.TabIndex = 24
        Me.LabelSignoff.Text = "Updating..."
        Me.LabelSignoff.Visible = False
        '
        'ProgressBarSignoff
        '
        Me.ProgressBarSignoff.Location = New System.Drawing.Point(140, 425)
        Me.ProgressBarSignoff.Name = "ProgressBarSignoff"
        Me.ProgressBarSignoff.Size = New System.Drawing.Size(215, 10)
        Me.ProgressBarSignoff.TabIndex = 23
        Me.ProgressBarSignoff.Visible = False
        '
        'lblRemoteWebservice
        '
        Me.lblRemoteWebservice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRemoteWebservice.AutoSize = True
        Me.lblRemoteWebservice.BackColor = System.Drawing.Color.Transparent
        Me.lblRemoteWebservice.Location = New System.Drawing.Point(3, 0)
        Me.lblRemoteWebservice.Name = "lblRemoteWebservice"
        Me.lblRemoteWebservice.Size = New System.Drawing.Size(93, 13)
        Me.lblRemoteWebservice.TabIndex = 26
        Me.lblRemoteWebservice.Text = "remotewebservice"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.Controls.Add(Me.lblRemoteWebservice)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(5, 445)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(360, 19)
        Me.FlowLayoutPanel1.TabIndex = 27
        '
        'lblLocationStatus
        '
        Me.lblLocationStatus.AutoSize = True
        Me.lblLocationStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblLocationStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocationStatus.Location = New System.Drawing.Point(3, 0)
        Me.lblLocationStatus.Name = "lblLocationStatus"
        Me.lblLocationStatus.Size = New System.Drawing.Size(70, 26)
        Me.lblLocationStatus.TabIndex = 26
        Me.lblLocationStatus.Text = "status"
        '
        'pnlAuth2
        '
        Me.pnlAuth2.BackColor = System.Drawing.Color.PeachPuff
        Me.pnlAuth2.Controls.Add(Me.lblAuthClose)
        Me.pnlAuth2.Controls.Add(Me.lblReset)
        Me.pnlAuth2.Controls.Add(Me.Label11)
        Me.pnlAuth2.Controls.Add(Me.lblAuthMsg)
        Me.pnlAuth2.Controls.Add(Me.btnVoidOpen)
        Me.pnlAuth2.Controls.Add(Me.objPassword)
        Me.pnlAuth2.Controls.Add(Me.objUsername)
        Me.pnlAuth2.Controls.Add(Me.Label8)
        Me.pnlAuth2.Controls.Add(Me.Label7)
        Me.pnlAuth2.Controls.Add(Me.Label9)
        Me.pnlAuth2.Location = New System.Drawing.Point(473, 289)
        Me.pnlAuth2.Name = "pnlAuth2"
        Me.pnlAuth2.Size = New System.Drawing.Size(211, 107)
        Me.pnlAuth2.TabIndex = 28
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
        'btnVoidOpen
        '
        Me.btnVoidOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoidOpen.ForeColor = System.Drawing.Color.Black
        Me.btnVoidOpen.Location = New System.Drawing.Point(140, 81)
        Me.btnVoidOpen.Name = "btnVoidOpen"
        Me.btnVoidOpen.Size = New System.Drawing.Size(54, 21)
        Me.btnVoidOpen.TabIndex = 5
        Me.btnVoidOpen.Text = "&Void"
        Me.btnVoidOpen.UseVisualStyleBackColor = True
        '
        'objPassword
        '
        Me.objPassword.ForeColor = System.Drawing.Color.Black
        Me.objPassword.Location = New System.Drawing.Point(80, 53)
        Me.objPassword.MaxLength = 50
        Me.objPassword.Name = "objPassword"
        Me.objPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.objPassword.Size = New System.Drawing.Size(114, 20)
        Me.objPassword.TabIndex = 4
        '
        'objUsername
        '
        Me.objUsername.ForeColor = System.Drawing.Color.Black
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(6, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Login"
        '
        'pnlAuth2Shadow
        '
        Me.pnlAuth2Shadow.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlAuth2Shadow.Location = New System.Drawing.Point(478, 293)
        Me.pnlAuth2Shadow.Name = "pnlAuth2Shadow"
        Me.pnlAuth2Shadow.Size = New System.Drawing.Size(209, 106)
        Me.pnlAuth2Shadow.TabIndex = 29
        Me.pnlAuth2Shadow.Visible = False
        '
        'btnUpdate
        '
        Me.btnUpdate.ForeColor = System.Drawing.Color.Black
        Me.btnUpdate.Location = New System.Drawing.Point(5, 101)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(121, 23)
        Me.btnUpdate.TabIndex = 30
        Me.btnUpdate.Text = "Update Data"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'LabelUpdateBin
        '
        Me.LabelUpdateBin.BackColor = System.Drawing.Color.Transparent
        Me.LabelUpdateBin.Location = New System.Drawing.Point(140, 98)
        Me.LabelUpdateBin.Name = "LabelUpdateBin"
        Me.LabelUpdateBin.Size = New System.Drawing.Size(215, 15)
        Me.LabelUpdateBin.TabIndex = 32
        Me.LabelUpdateBin.Text = "Updating..."
        Me.LabelUpdateBin.Visible = False
        '
        'ProgressBarUpdatebin
        '
        Me.ProgressBarUpdatebin.Location = New System.Drawing.Point(140, 116)
        Me.ProgressBarUpdatebin.Name = "ProgressBarUpdatebin"
        Me.ProgressBarUpdatebin.Size = New System.Drawing.Size(215, 10)
        Me.ProgressBarUpdatebin.TabIndex = 31
        Me.ProgressBarUpdatebin.Visible = False
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.btn_TestQris)
        Me.Panel1.Controls.Add(Me.btn_testVoucher)
        Me.Panel1.Controls.Add(Me.btnShowParameter)
        Me.Panel1.Controls.Add(Me.btnUpdateManual)
        Me.Panel1.Controls.Add(Me.pnlAuth2)
        Me.Panel1.Controls.Add(Me.pnlAuth2Shadow)
        Me.Panel1.Controls.Add(Me.lblLocationStatus)
        Me.Panel1.Controls.Add(Me.groupClossing)
        Me.Panel1.Controls.Add(Me.LabelUpdateBin)
        Me.Panel1.Controls.Add(Me.groupTransaction)
        Me.Panel1.Controls.Add(Me.ProgressBarUpdatebin)
        Me.Panel1.Controls.Add(Me.groupSalesSend)
        Me.Panel1.Controls.Add(Me.btnUpdate)
        Me.Panel1.Controls.Add(Me.btnSignOff)
        Me.Panel1.Controls.Add(Me.btnSignIn)
        Me.Panel1.Controls.Add(Me.ProgressBarDataUpdate)
        Me.Panel1.Controls.Add(Me.LabelDataUpdate)
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel1.Controls.Add(Me.lblStatus)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.obj_last_synsign_id)
        Me.Panel1.Controls.Add(Me.LabelSignoff)
        Me.Panel1.Controls.Add(Me.groupPOSConsole)
        Me.Panel1.Controls.Add(Me.objKey)
        Me.Panel1.Controls.Add(Me.ProgressBarSignoff)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(764, 547)
        Me.Panel1.TabIndex = 33
        '
        'btn_TestQris
        '
        Me.btn_TestQris.ForeColor = System.Drawing.Color.Black
        Me.btn_TestQris.Location = New System.Drawing.Point(132, 504)
        Me.btn_TestQris.Name = "btn_TestQris"
        Me.btn_TestQris.Size = New System.Drawing.Size(121, 23)
        Me.btn_TestQris.TabIndex = 36
        Me.btn_TestQris.Text = "Test QRIS"
        Me.btn_TestQris.UseVisualStyleBackColor = True
        '
        'btn_testVoucher
        '
        Me.btn_testVoucher.ForeColor = System.Drawing.Color.Black
        Me.btn_testVoucher.Location = New System.Drawing.Point(5, 504)
        Me.btn_testVoucher.Name = "btn_testVoucher"
        Me.btn_testVoucher.Size = New System.Drawing.Size(121, 23)
        Me.btn_testVoucher.TabIndex = 35
        Me.btn_testVoucher.Text = "Test Voucher"
        Me.btn_testVoucher.UseVisualStyleBackColor = True
        '
        'btnShowParameter
        '
        Me.btnShowParameter.AutoSize = True
        Me.btnShowParameter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowParameter.LinkColor = System.Drawing.Color.White
        Me.btnShowParameter.Location = New System.Drawing.Point(629, 445)
        Me.btnShowParameter.Name = "btnShowParameter"
        Me.btnShowParameter.Size = New System.Drawing.Size(128, 13)
        Me.btnShowParameter.TabIndex = 34
        Me.btnShowParameter.TabStop = True
        Me.btnShowParameter.Text = "Show Running Parameter"
        '
        'btnUpdateManual
        '
        Me.btnUpdateManual.Enabled = False
        Me.btnUpdateManual.ForeColor = System.Drawing.Color.Black
        Me.btnUpdateManual.Location = New System.Drawing.Point(5, 130)
        Me.btnUpdateManual.Name = "btnUpdateManual"
        Me.btnUpdateManual.Size = New System.Drawing.Size(121, 23)
        Me.btnUpdateManual.TabIndex = 33
        Me.btnUpdateManual.Text = "Update Manual"
        Me.btnUpdateManual.UseVisualStyleBackColor = True
        '
        'TimerAutosendData
        '
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(387, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 13)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Pos Console"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, -1)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Transaction"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 173)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 13)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "Closing"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, -1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 13)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "Data Sales"
        '
        'uiTrnPosEN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.Color.Gray
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundworkerStatus = Translib.uiBase.EBackgroundworkerStatus.Done
        Me.Controls.Add(Me.Panel1)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.ForeColor = System.Drawing.Color.White
        Me.Message = "Done. "
        Me.MinimumSize = New System.Drawing.Size(755, 400)
        Me.Name = "uiTrnPosEN"
        Me.Progress = 20
        Me.Size = New System.Drawing.Size(764, 572)
        Me.Status = "Loading Data..."
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        CType(Me.dsMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupClossing.ResumeLayout(False)
        Me.groupClossing.PerformLayout()
        Me.groupTransaction.ResumeLayout(False)
        Me.groupTransaction.PerformLayout()
        Me.groupSalesSend.ResumeLayout(False)
        Me.groupSalesSend.PerformLayout()
        Me.groupPOSConsole.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.pnlAuth2.ResumeLayout(False)
        Me.pnlAuth2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOpenPOSConsole As System.Windows.Forms.Button
    Friend WithEvents btnRePrint As System.Windows.Forms.Button
    Friend WithEvents btnClosing As System.Windows.Forms.Button
    Friend WithEvents objBonId As System.Windows.Forms.TextBox
    Friend WithEvents chkBonPreview As System.Windows.Forms.CheckBox
    Friend WithEvents chkMachineOnly As System.Windows.Forms.CheckBox
    Friend WithEvents objDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents groupClossing As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkArticleBreakdown As System.Windows.Forms.CheckBox
    Friend WithEvents chkClosingPreviewOnly As System.Windows.Forms.CheckBox
    Friend WithEvents chkTransactionSummary As System.Windows.Forms.CheckBox
    Friend WithEvents chkBonRekap As System.Windows.Forms.CheckBox
    Friend WithEvents groupTransaction As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSignOff As System.Windows.Forms.Button
    Friend WithEvents btnVoid As System.Windows.Forms.Button
    Friend WithEvents groupSalesSend As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtSalesTobeSent As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents btnSignIn As System.Windows.Forms.Button
    Friend WithEvents ProgressBarDataUpdate As System.Windows.Forms.ProgressBar
    Friend WithEvents LabelDataUpdate As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents obj_last_synsign_id As System.Windows.Forms.Label
    Friend WithEvents objKey As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents groupPOSConsole As System.Windows.Forms.GroupBox
    Friend WithEvents LabelDataSend As System.Windows.Forms.Label
    Friend WithEvents ProgressBarDataSend As System.Windows.Forms.ProgressBar
    Friend WithEvents LabelSignoff As System.Windows.Forms.Label
    Friend WithEvents ProgressBarSignoff As System.Windows.Forms.ProgressBar
    Friend WithEvents lblRemoteWebservice As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnViewDetil As System.Windows.Forms.Button
    Friend WithEvents lblLocationStatus As System.Windows.Forms.Label
    Friend WithEvents pnlAuth2 As System.Windows.Forms.Panel
    Friend WithEvents lblAuthClose As System.Windows.Forms.LinkLabel
    Friend WithEvents lblReset As System.Windows.Forms.LinkLabel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblAuthMsg As System.Windows.Forms.Label
    Friend WithEvents btnVoidOpen As System.Windows.Forms.Button
    Friend WithEvents objPassword As System.Windows.Forms.TextBox
    Friend WithEvents objUsername As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlAuth2Shadow As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents LabelUpdateBin As System.Windows.Forms.Label
    Friend WithEvents ProgressBarUpdatebin As System.Windows.Forms.ProgressBar
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnOpenPOSReturNote As System.Windows.Forms.Button
    Friend WithEvents btnUpdateManual As System.Windows.Forms.Button
    Friend WithEvents TimerAutosendData As System.Windows.Forms.Timer
    Friend WithEvents lblAutosendStatus As System.Windows.Forms.Label
    Friend WithEvents btnShowParameter As System.Windows.Forms.LinkLabel
    Friend WithEvents obj_txt_senddatamode As System.Windows.Forms.Label
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents btn_testVoucher As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btn_TestQris As System.Windows.Forms.Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label12 As Label
End Class
