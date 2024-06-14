<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnInventorymovingAJ
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiTrnInventorymovingAJ))
        Me.ftabMain = New FlatTabControl.FlatTabControl
        Me.ftabMain_List = New System.Windows.Forms.TabPage
        Me.PnlDfMain = New System.Windows.Forms.Panel
        Me.DgvList = New System.Windows.Forms.DataGridView
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.bnList = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.bnPageCount = New System.Windows.Forms.ToolStripLabel
        Me.bnMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.bnMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.bnSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.bnPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.bnSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.bnMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.bnMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.bnSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.bnRefresh = New System.Windows.Forms.ToolStripButton
        Me.bnSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.bnRowCount = New System.Windows.Forms.ToolStripLabel
        Me.bnRowLimit = New System.Windows.Forms.ToolStripTextBox
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.obj_search_cbo_branch_id_from = New System.Windows.Forms.ComboBox
        Me.obj_search_chk_branch_id = New System.Windows.Forms.CheckBox
        Me.obj_search_cbo_region_id = New System.Windows.Forms.ComboBox
        Me.obj_search_chk_region_id = New System.Windows.Forms.CheckBox
        Me.obj_search_txt_iteminventorysubtype_id = New System.Windows.Forms.TextBox
        Me.obj_search_chk_iteminventorysubtype_id = New System.Windows.Forms.CheckBox
        Me.obj_search_txt_iteminventorytype_id = New System.Windows.Forms.TextBox
        Me.obj_search_chk_iteminventorytype_id = New System.Windows.Forms.CheckBox
        Me.obj_search_dtp_inventorymoving_dateend = New System.Windows.Forms.DateTimePicker
        Me.obj_search_chk_inventorymoving_dateend = New System.Windows.Forms.CheckBox
        Me.obj_search_dtp_inventorymoving_datestart = New System.Windows.Forms.DateTimePicker
        Me.obj_search_chk_inventorymoving_datestart = New System.Windows.Forms.CheckBox
        Me.lbl_id = New System.Windows.Forms.Label
        Me.obj_search_txt_channel_id = New System.Windows.Forms.TextBox
        Me.obj_search_chk_channel_id = New System.Windows.Forms.CheckBox
        Me.obj_search_txt_inventorymovingtype_id = New System.Windows.Forms.TextBox
        Me.obj_search_chk_inventorymovingtype_id = New System.Windows.Forms.CheckBox
        Me.obj_search_chk_inventorymoving_id = New System.Windows.Forms.CheckBox
        Me.obj_search_txt_inventorymoving_id = New System.Windows.Forms.TextBox
        Me.obj_search_txt_inventorymoving_descr = New System.Windows.Forms.TextBox
        Me.obj_search_chk_inventorymoving_descr = New System.Windows.Forms.CheckBox
        Me.ftabMain_Data = New System.Windows.Forms.TabPage
        Me.ftabDataDetil = New FlatTabControl.FlatTabControl
        Me.ftabDataDetil_Item = New System.Windows.Forms.TabPage
        Me.DgvItem = New System.Windows.Forms.DataGridView
        Me.ftabDataDetil_Exception = New System.Windows.Forms.TabPage
        Me.DgvException = New System.Windows.Forms.DataGridView
        Me.ftabDataDetil_Prop = New System.Windows.Forms.TabPage
        Me.DgvProp = New System.Windows.Forms.DataGridView
        Me.ftabDataDetil_Log = New System.Windows.Forms.TabPage
        Me.DgvLog = New System.Windows.Forms.DataGridView
        Me.ftabDataDetil_Record = New System.Windows.Forms.TabPage
        Me.lbl_inventorymoving_postdate = New System.Windows.Forms.Label
        Me.lbl_inventorymoving_postby = New System.Windows.Forms.Label
        Me.obj_inventorymoving_postdate = New System.Windows.Forms.TextBox
        Me.obj_inventorymoving_postby = New System.Windows.Forms.TextBox
        Me.lbl_inventorymoving_receivedate = New System.Windows.Forms.Label
        Me.lbl_rowid = New System.Windows.Forms.Label
        Me.lbl_inventorymoving_receiveby = New System.Windows.Forms.Label
        Me.lbl_inventorymoving_senddate = New System.Windows.Forms.Label
        Me.lbl_inventorymoving_modifieddate = New System.Windows.Forms.Label
        Me.lbl_inventorymoving_sendby = New System.Windows.Forms.Label
        Me.lbl_inventorymoving_createby = New System.Windows.Forms.Label
        Me.obj_inventorymoving_createby = New System.Windows.Forms.TextBox
        Me.obj_inventorymoving_receivedate = New System.Windows.Forms.TextBox
        Me.lbl_inventorymoving_modifiedby = New System.Windows.Forms.Label
        Me.obj_inventorymoving_receiveby = New System.Windows.Forms.TextBox
        Me.obj_inventorymoving_createdate = New System.Windows.Forms.TextBox
        Me.obj_inventorymoving_sendby = New System.Windows.Forms.TextBox
        Me.lbl_inventorymoving_createdate = New System.Windows.Forms.Label
        Me.obj_inventorymoving_senddate = New System.Windows.Forms.TextBox
        Me.obj_inventorymoving_modifyby = New System.Windows.Forms.TextBox
        Me.obj_rowid = New System.Windows.Forms.TextBox
        Me.obj_inventorymoving_modifydate = New System.Windows.Forms.TextBox
        Me.PnlDataMaster = New System.Windows.Forms.Panel
        Me.lbl_inventorymoving_branch_id = New System.Windows.Forms.Label
        Me.lbl_inventorymoving_region = New System.Windows.Forms.Label
        Me.lbl_transaction_id = New System.Windows.Forms.Label
        Me.obj_transaction_id = New System.Windows.Forms.TextBox
        Me.lbl_iteminventorytype_id = New System.Windows.Forms.Label
        Me.obj_iteminventorysubtype_id = New System.Windows.Forms.TextBox
        Me.obj_iteminventorytype_id = New System.Windows.Forms.TextBox
        Me.obj_branch_id = New System.Windows.Forms.ComboBox
        Me.obj_region_id = New System.Windows.Forms.ComboBox
        Me.lbl_channel_id = New System.Windows.Forms.Label
        Me.obj_channel_id = New System.Windows.Forms.TextBox
        Me.lbl_inventorymoving_type = New System.Windows.Forms.Label
        Me.obj_inventorymoving_source = New System.Windows.Forms.TextBox
        Me.obj_inventorymovingtype_id = New System.Windows.Forms.TextBox
        Me.obj_inventorymoving_date = New System.Windows.Forms.DateTimePicker
        Me.lbl_inventorymoving_date = New System.Windows.Forms.Label
        Me.lbl_inventorymoving_descr = New System.Windows.Forms.Label
        Me.lbl_inventorymoving_id = New System.Windows.Forms.Label
        Me.obj_inventorymoving_descr = New System.Windows.Forms.TextBox
        Me.obj_inventorymoving_id = New System.Windows.Forms.TextBox
        Me.PnlDataFooter = New System.Windows.Forms.Panel
        Me.obj_inventorymoving_totalproposed = New System.Windows.Forms.TextBox
        Me.obj_inventorymoving_isproposed = New System.Windows.Forms.CheckBox
        Me.lbl_inventorymoving_valuelost = New System.Windows.Forms.Label
        Me.lbl_inventorymoving_valuereceived = New System.Windows.Forms.Label
        Me.lbl_inventorymoving_valuesent = New System.Windows.Forms.Label
        Me.lbl_inventorymoving_totalbalance = New System.Windows.Forms.Label
        Me.lbl_inventorymoving_totalreceive = New System.Windows.Forms.Label
        Me.lbl_inventorymoving_totalsent = New System.Windows.Forms.Label
        Me.obj_inventorymoving_valuelost = New System.Windows.Forms.TextBox
        Me.obj_inventorymoving_valuereceived = New System.Windows.Forms.TextBox
        Me.obj_inventorymoving_valuesent = New System.Windows.Forms.TextBox
        Me.obj_inventorymoving_totalbalance = New System.Windows.Forms.TextBox
        Me.obj_inventorymoving_totalreceived = New System.Windows.Forms.TextBox
        Me.obj_inventorymoving_totalsent = New System.Windows.Forms.TextBox
        Me.lbl_inventorymoving_status = New System.Windows.Forms.Label
        Me.obj_inventorymoving_issent = New System.Windows.Forms.CheckBox
        Me.obj_inventorymoving_isposted = New System.Windows.Forms.CheckBox
        Me.obj_inventorymoving_isreceived = New System.Windows.Forms.CheckBox
        CType(Me.dsMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfFooter.SuspendLayout()
        CType(Me.bnList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnList.SuspendLayout()
        Me.PnlDfSearch.SuspendLayout()
        Me.ftabMain_Data.SuspendLayout()
        Me.ftabDataDetil.SuspendLayout()
        Me.ftabDataDetil_Item.SuspendLayout()
        CType(Me.DgvItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_Exception.SuspendLayout()
        CType(Me.DgvException, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_Prop.SuspendLayout()
        CType(Me.DgvProp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_Log.SuspendLayout()
        CType(Me.DgvLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_Record.SuspendLayout()
        Me.PnlDataMaster.SuspendLayout()
        Me.PnlDataFooter.SuspendLayout()
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
        Me.fLoadingIndicator.Location = New System.Drawing.Point(66, 87)
        Me.fLoadingIndicator.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        '
        'ftabMain
        '
        Me.ftabMain.Controls.Add(Me.ftabMain_List)
        Me.ftabMain.Controls.Add(Me.ftabMain_Data)
        Me.ftabMain.Location = New System.Drawing.Point(2, 27)
        Me.ftabMain.Margin = New System.Windows.Forms.Padding(2)
        Me.ftabMain.myBackColor = System.Drawing.Color.White
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedIndex = 0
        Me.ftabMain.Size = New System.Drawing.Size(747, 519)
        Me.ftabMain.TabIndex = 2
        '
        'ftabMain_List
        '
        Me.ftabMain_List.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ftabMain_List.Controls.Add(Me.PnlDfMain)
        Me.ftabMain_List.Controls.Add(Me.PnlDfFooter)
        Me.ftabMain_List.Controls.Add(Me.PnlDfSearch)
        Me.ftabMain_List.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_List.Name = "ftabMain_List"
        Me.ftabMain_List.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_List.Size = New System.Drawing.Size(739, 490)
        Me.ftabMain_List.TabIndex = 0
        Me.ftabMain_List.Text = "List"
        '
        'PnlDfMain
        '
        Me.PnlDfMain.Controls.Add(Me.DgvList)
        Me.PnlDfMain.Location = New System.Drawing.Point(20, 363)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 64)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvList
        '
        Me.DgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvList.Cursor = System.Windows.Forms.Cursors.Default
        Me.DgvList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvList.Location = New System.Drawing.Point(0, 0)
        Me.DgvList.Name = "DgvList"
        Me.DgvList.Size = New System.Drawing.Size(704, 64)
        Me.DgvList.TabIndex = 0
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.Controls.Add(Me.bnList)
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(3, 459)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(733, 28)
        Me.PnlDfFooter.TabIndex = 2
        '
        'bnList
        '
        Me.bnList.AddNewItem = Nothing
        Me.bnList.CountItem = Me.bnPageCount
        Me.bnList.DeleteItem = Nothing
        Me.bnList.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bnMoveFirstItem, Me.bnMovePreviousItem, Me.bnSeparator, Me.bnPositionItem, Me.bnPageCount, Me.bnSeparator1, Me.bnMoveNextItem, Me.bnMoveLastItem, Me.bnSeparator2, Me.bnRefresh, Me.bnSeparator3, Me.bnRowCount, Me.bnRowLimit})
        Me.bnList.Location = New System.Drawing.Point(0, 3)
        Me.bnList.MoveFirstItem = Me.bnMoveFirstItem
        Me.bnList.MoveLastItem = Me.bnMoveLastItem
        Me.bnList.MoveNextItem = Me.bnMoveNextItem
        Me.bnList.MovePreviousItem = Me.bnMovePreviousItem
        Me.bnList.Name = "bnList"
        Me.bnList.PositionItem = Me.bnPositionItem
        Me.bnList.Size = New System.Drawing.Size(733, 25)
        Me.bnList.TabIndex = 2
        Me.bnList.Text = "BindingNavigator1"
        '
        'bnPageCount
        '
        Me.bnPageCount.Name = "bnPageCount"
        Me.bnPageCount.Size = New System.Drawing.Size(36, 22)
        Me.bnPageCount.Text = "of {0}"
        Me.bnPageCount.ToolTipText = "Total number of items"
        '
        'bnMoveFirstItem
        '
        Me.bnMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bnMoveFirstItem.Image = CType(resources.GetObject("bnMoveFirstItem.Image"), System.Drawing.Image)
        Me.bnMoveFirstItem.Name = "bnMoveFirstItem"
        Me.bnMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.bnMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.bnMoveFirstItem.Text = "Move first"
        '
        'bnMovePreviousItem
        '
        Me.bnMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bnMovePreviousItem.Image = CType(resources.GetObject("bnMovePreviousItem.Image"), System.Drawing.Image)
        Me.bnMovePreviousItem.Name = "bnMovePreviousItem"
        Me.bnMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.bnMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.bnMovePreviousItem.Text = "Move previous"
        '
        'bnSeparator
        '
        Me.bnSeparator.Name = "bnSeparator"
        Me.bnSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'bnPositionItem
        '
        Me.bnPositionItem.AccessibleName = "Position"
        Me.bnPositionItem.AutoSize = False
        Me.bnPositionItem.MaxLength = 5
        Me.bnPositionItem.Name = "bnPositionItem"
        Me.bnPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.bnPositionItem.Text = "0"
        Me.bnPositionItem.ToolTipText = "Current position"
        '
        'bnSeparator1
        '
        Me.bnSeparator1.Name = "bnSeparator1"
        Me.bnSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'bnMoveNextItem
        '
        Me.bnMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bnMoveNextItem.Image = CType(resources.GetObject("bnMoveNextItem.Image"), System.Drawing.Image)
        Me.bnMoveNextItem.Name = "bnMoveNextItem"
        Me.bnMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.bnMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.bnMoveNextItem.Text = "Move next"
        '
        'bnMoveLastItem
        '
        Me.bnMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bnMoveLastItem.Image = CType(resources.GetObject("bnMoveLastItem.Image"), System.Drawing.Image)
        Me.bnMoveLastItem.Name = "bnMoveLastItem"
        Me.bnMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.bnMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.bnMoveLastItem.Text = "Move last"
        '
        'bnSeparator2
        '
        Me.bnSeparator2.Name = "bnSeparator2"
        Me.bnSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'bnRefresh
        '
        Me.bnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bnRefresh.Enabled = False
        Me.bnRefresh.Image = CType(resources.GetObject("bnRefresh.Image"), System.Drawing.Image)
        Me.bnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.bnRefresh.Name = "bnRefresh"
        Me.bnRefresh.Size = New System.Drawing.Size(23, 22)
        Me.bnRefresh.Text = "Refresh"
        '
        'bnSeparator3
        '
        Me.bnSeparator3.Name = "bnSeparator3"
        Me.bnSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'bnRowCount
        '
        Me.bnRowCount.Name = "bnRowCount"
        Me.bnRowCount.Size = New System.Drawing.Size(52, 22)
        Me.bnRowCount.Text = "{0} Rows"
        Me.bnRowCount.Visible = False
        '
        'bnRowLimit
        '
        Me.bnRowLimit.MaxLength = 3
        Me.bnRowLimit.Name = "bnRowLimit"
        Me.bnRowLimit.Size = New System.Drawing.Size(30, 25)
        Me.bnRowLimit.Text = "30"
        Me.bnRowLimit.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Controls.Add(Me.obj_search_cbo_branch_id_from)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_chk_branch_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_cbo_region_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_chk_region_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_txt_iteminventorysubtype_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_chk_iteminventorysubtype_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_txt_iteminventorytype_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_chk_iteminventorytype_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_dtp_inventorymoving_dateend)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_chk_inventorymoving_dateend)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_dtp_inventorymoving_datestart)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_chk_inventorymoving_datestart)
        Me.PnlDfSearch.Controls.Add(Me.lbl_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_txt_channel_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_chk_channel_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_txt_inventorymovingtype_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_chk_inventorymovingtype_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_chk_inventorymoving_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_txt_inventorymoving_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_txt_inventorymoving_descr)
        Me.PnlDfSearch.Controls.Add(Me.obj_search_chk_inventorymoving_descr)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 133)
        Me.PnlDfSearch.TabIndex = 0
        '
        'obj_search_cbo_branch_id_from
        '
        Me.obj_search_cbo_branch_id_from.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_search_cbo_branch_id_from.FormattingEnabled = True
        Me.obj_search_cbo_branch_id_from.Location = New System.Drawing.Point(455, 56)
        Me.obj_search_cbo_branch_id_from.Name = "obj_search_cbo_branch_id_from"
        Me.obj_search_cbo_branch_id_from.Size = New System.Drawing.Size(108, 21)
        Me.obj_search_cbo_branch_id_from.TabIndex = 87
        '
        'obj_search_chk_branch_id
        '
        Me.obj_search_chk_branch_id.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_branch_id.Location = New System.Drawing.Point(375, 57)
        Me.obj_search_chk_branch_id.Name = "obj_search_chk_branch_id"
        Me.obj_search_chk_branch_id.Size = New System.Drawing.Size(74, 19)
        Me.obj_search_chk_branch_id.TabIndex = 86
        Me.obj_search_chk_branch_id.Text = "Branch"
        Me.obj_search_chk_branch_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_branch_id.UseVisualStyleBackColor = True
        '
        'obj_search_cbo_region_id
        '
        Me.obj_search_cbo_region_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_search_cbo_region_id.FormattingEnabled = True
        Me.obj_search_cbo_region_id.Location = New System.Drawing.Point(455, 30)
        Me.obj_search_cbo_region_id.Name = "obj_search_cbo_region_id"
        Me.obj_search_cbo_region_id.Size = New System.Drawing.Size(133, 21)
        Me.obj_search_cbo_region_id.TabIndex = 85
        '
        'obj_search_chk_region_id
        '
        Me.obj_search_chk_region_id.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_region_id.Checked = True
        Me.obj_search_chk_region_id.CheckState = System.Windows.Forms.CheckState.Checked
        Me.obj_search_chk_region_id.Enabled = False
        Me.obj_search_chk_region_id.Location = New System.Drawing.Point(375, 31)
        Me.obj_search_chk_region_id.Name = "obj_search_chk_region_id"
        Me.obj_search_chk_region_id.Size = New System.Drawing.Size(74, 19)
        Me.obj_search_chk_region_id.TabIndex = 84
        Me.obj_search_chk_region_id.Text = "Region"
        Me.obj_search_chk_region_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_region_id.UseVisualStyleBackColor = True
        '
        'obj_search_txt_iteminventorysubtype_id
        '
        Me.obj_search_txt_iteminventorysubtype_id.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_search_txt_iteminventorysubtype_id.Location = New System.Drawing.Point(594, 5)
        Me.obj_search_txt_iteminventorysubtype_id.Name = "obj_search_txt_iteminventorysubtype_id"
        Me.obj_search_txt_iteminventorysubtype_id.ReadOnly = True
        Me.obj_search_txt_iteminventorysubtype_id.Size = New System.Drawing.Size(72, 20)
        Me.obj_search_txt_iteminventorysubtype_id.TabIndex = 83
        Me.obj_search_txt_iteminventorysubtype_id.Text = "INVMCH"
        '
        'obj_search_chk_iteminventorysubtype_id
        '
        Me.obj_search_chk_iteminventorysubtype_id.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_iteminventorysubtype_id.Checked = True
        Me.obj_search_chk_iteminventorysubtype_id.CheckState = System.Windows.Forms.CheckState.Checked
        Me.obj_search_chk_iteminventorysubtype_id.Enabled = False
        Me.obj_search_chk_iteminventorysubtype_id.Location = New System.Drawing.Point(499, 6)
        Me.obj_search_chk_iteminventorysubtype_id.Name = "obj_search_chk_iteminventorysubtype_id"
        Me.obj_search_chk_iteminventorysubtype_id.Size = New System.Drawing.Size(89, 19)
        Me.obj_search_chk_iteminventorysubtype_id.TabIndex = 82
        Me.obj_search_chk_iteminventorysubtype_id.Text = "Inv.SubType"
        Me.obj_search_chk_iteminventorysubtype_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_iteminventorysubtype_id.UseVisualStyleBackColor = True
        '
        'obj_search_txt_iteminventorytype_id
        '
        Me.obj_search_txt_iteminventorytype_id.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_search_txt_iteminventorytype_id.Location = New System.Drawing.Point(455, 5)
        Me.obj_search_txt_iteminventorytype_id.Name = "obj_search_txt_iteminventorytype_id"
        Me.obj_search_txt_iteminventorytype_id.ReadOnly = True
        Me.obj_search_txt_iteminventorytype_id.Size = New System.Drawing.Size(38, 20)
        Me.obj_search_txt_iteminventorytype_id.TabIndex = 81
        Me.obj_search_txt_iteminventorytype_id.Text = "INV"
        '
        'obj_search_chk_iteminventorytype_id
        '
        Me.obj_search_chk_iteminventorytype_id.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_iteminventorytype_id.Checked = True
        Me.obj_search_chk_iteminventorytype_id.CheckState = System.Windows.Forms.CheckState.Checked
        Me.obj_search_chk_iteminventorytype_id.Enabled = False
        Me.obj_search_chk_iteminventorytype_id.Location = New System.Drawing.Point(375, 6)
        Me.obj_search_chk_iteminventorytype_id.Name = "obj_search_chk_iteminventorytype_id"
        Me.obj_search_chk_iteminventorytype_id.Size = New System.Drawing.Size(74, 19)
        Me.obj_search_chk_iteminventorytype_id.TabIndex = 80
        Me.obj_search_chk_iteminventorytype_id.Text = "Inv.Type"
        Me.obj_search_chk_iteminventorytype_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_iteminventorytype_id.UseVisualStyleBackColor = True
        '
        'obj_search_dtp_inventorymoving_dateend
        '
        Me.obj_search_dtp_inventorymoving_dateend.CustomFormat = "dd/MM/yyyy"
        Me.obj_search_dtp_inventorymoving_dateend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_search_dtp_inventorymoving_dateend.Location = New System.Drawing.Point(603, 83)
        Me.obj_search_dtp_inventorymoving_dateend.Name = "obj_search_dtp_inventorymoving_dateend"
        Me.obj_search_dtp_inventorymoving_dateend.Size = New System.Drawing.Size(91, 20)
        Me.obj_search_dtp_inventorymoving_dateend.TabIndex = 79
        '
        'obj_search_chk_inventorymoving_dateend
        '
        Me.obj_search_chk_inventorymoving_dateend.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_inventorymoving_dateend.Location = New System.Drawing.Point(549, 85)
        Me.obj_search_chk_inventorymoving_dateend.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.obj_search_chk_inventorymoving_dateend.Name = "obj_search_chk_inventorymoving_dateend"
        Me.obj_search_chk_inventorymoving_dateend.Size = New System.Drawing.Size(51, 19)
        Me.obj_search_chk_inventorymoving_dateend.TabIndex = 78
        Me.obj_search_chk_inventorymoving_dateend.Text = "Until"
        Me.obj_search_chk_inventorymoving_dateend.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_inventorymoving_dateend.UseVisualStyleBackColor = True
        '
        'obj_search_dtp_inventorymoving_datestart
        '
        Me.obj_search_dtp_inventorymoving_datestart.CustomFormat = "dd/MM/yyyy"
        Me.obj_search_dtp_inventorymoving_datestart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_search_dtp_inventorymoving_datestart.Location = New System.Drawing.Point(455, 83)
        Me.obj_search_dtp_inventorymoving_datestart.Name = "obj_search_dtp_inventorymoving_datestart"
        Me.obj_search_dtp_inventorymoving_datestart.Size = New System.Drawing.Size(91, 20)
        Me.obj_search_dtp_inventorymoving_datestart.TabIndex = 77
        '
        'obj_search_chk_inventorymoving_datestart
        '
        Me.obj_search_chk_inventorymoving_datestart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_inventorymoving_datestart.Location = New System.Drawing.Point(375, 85)
        Me.obj_search_chk_inventorymoving_datestart.Name = "obj_search_chk_inventorymoving_datestart"
        Me.obj_search_chk_inventorymoving_datestart.Size = New System.Drawing.Size(74, 19)
        Me.obj_search_chk_inventorymoving_datestart.TabIndex = 75
        Me.obj_search_chk_inventorymoving_datestart.Text = "Date"
        Me.obj_search_chk_inventorymoving_datestart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_inventorymoving_datestart.UseVisualStyleBackColor = True
        '
        'lbl_id
        '
        Me.lbl_id.AutoSize = True
        Me.lbl_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_id.Location = New System.Drawing.Point(97, 113)
        Me.lbl_id.Name = "lbl_id"
        Me.lbl_id.Size = New System.Drawing.Size(263, 12)
        Me.lbl_id.TabIndex = 74
        Me.lbl_id.Text = "Use semicolone (;) to enter more than one references in textbox"
        '
        'obj_search_txt_channel_id
        '
        Me.obj_search_txt_channel_id.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_search_txt_channel_id.Location = New System.Drawing.Point(100, 5)
        Me.obj_search_txt_channel_id.Name = "obj_search_txt_channel_id"
        Me.obj_search_txt_channel_id.ReadOnly = True
        Me.obj_search_txt_channel_id.Size = New System.Drawing.Size(58, 20)
        Me.obj_search_txt_channel_id.TabIndex = 7
        Me.obj_search_txt_channel_id.Text = "MGP"
        '
        'obj_search_chk_channel_id
        '
        Me.obj_search_chk_channel_id.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_channel_id.Checked = True
        Me.obj_search_chk_channel_id.CheckState = System.Windows.Forms.CheckState.Checked
        Me.obj_search_chk_channel_id.Enabled = False
        Me.obj_search_chk_channel_id.Location = New System.Drawing.Point(6, 6)
        Me.obj_search_chk_channel_id.Name = "obj_search_chk_channel_id"
        Me.obj_search_chk_channel_id.Size = New System.Drawing.Size(88, 19)
        Me.obj_search_chk_channel_id.TabIndex = 6
        Me.obj_search_chk_channel_id.Text = "Channel"
        Me.obj_search_chk_channel_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_channel_id.UseVisualStyleBackColor = True
        '
        'obj_search_txt_inventorymovingtype_id
        '
        Me.obj_search_txt_inventorymovingtype_id.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_search_txt_inventorymovingtype_id.Location = New System.Drawing.Point(239, 5)
        Me.obj_search_txt_inventorymovingtype_id.Name = "obj_search_txt_inventorymovingtype_id"
        Me.obj_search_txt_inventorymovingtype_id.ReadOnly = True
        Me.obj_search_txt_inventorymovingtype_id.Size = New System.Drawing.Size(38, 20)
        Me.obj_search_txt_inventorymovingtype_id.TabIndex = 5
        Me.obj_search_txt_inventorymovingtype_id.Text = "AS"
        '
        'obj_search_chk_inventorymovingtype_id
        '
        Me.obj_search_chk_inventorymovingtype_id.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_inventorymovingtype_id.Checked = True
        Me.obj_search_chk_inventorymovingtype_id.CheckState = System.Windows.Forms.CheckState.Checked
        Me.obj_search_chk_inventorymovingtype_id.Enabled = False
        Me.obj_search_chk_inventorymovingtype_id.Location = New System.Drawing.Point(175, 6)
        Me.obj_search_chk_inventorymovingtype_id.Name = "obj_search_chk_inventorymovingtype_id"
        Me.obj_search_chk_inventorymovingtype_id.Size = New System.Drawing.Size(58, 19)
        Me.obj_search_chk_inventorymovingtype_id.TabIndex = 4
        Me.obj_search_chk_inventorymovingtype_id.Text = "Type"
        Me.obj_search_chk_inventorymovingtype_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_inventorymovingtype_id.UseVisualStyleBackColor = True
        '
        'obj_search_chk_inventorymoving_id
        '
        Me.obj_search_chk_inventorymoving_id.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_inventorymoving_id.Location = New System.Drawing.Point(6, 32)
        Me.obj_search_chk_inventorymoving_id.Name = "obj_search_chk_inventorymoving_id"
        Me.obj_search_chk_inventorymoving_id.Size = New System.Drawing.Size(88, 19)
        Me.obj_search_chk_inventorymoving_id.TabIndex = 3
        Me.obj_search_chk_inventorymoving_id.Text = "ID"
        Me.obj_search_chk_inventorymoving_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_inventorymoving_id.UseVisualStyleBackColor = True
        '
        'obj_search_txt_inventorymoving_id
        '
        Me.obj_search_txt_inventorymoving_id.Location = New System.Drawing.Point(100, 31)
        Me.obj_search_txt_inventorymoving_id.Multiline = True
        Me.obj_search_txt_inventorymoving_id.Name = "obj_search_txt_inventorymoving_id"
        Me.obj_search_txt_inventorymoving_id.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.obj_search_txt_inventorymoving_id.Size = New System.Drawing.Size(261, 79)
        Me.obj_search_txt_inventorymoving_id.TabIndex = 2
        Me.obj_search_txt_inventorymoving_id.WordWrap = False
        '
        'obj_search_txt_inventorymoving_descr
        '
        Me.obj_search_txt_inventorymoving_descr.Location = New System.Drawing.Point(455, 109)
        Me.obj_search_txt_inventorymoving_descr.Name = "obj_search_txt_inventorymoving_descr"
        Me.obj_search_txt_inventorymoving_descr.Size = New System.Drawing.Size(239, 20)
        Me.obj_search_txt_inventorymoving_descr.TabIndex = 1
        '
        'obj_search_chk_inventorymoving_descr
        '
        Me.obj_search_chk_inventorymoving_descr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_inventorymoving_descr.Location = New System.Drawing.Point(375, 110)
        Me.obj_search_chk_inventorymoving_descr.Name = "obj_search_chk_inventorymoving_descr"
        Me.obj_search_chk_inventorymoving_descr.Size = New System.Drawing.Size(74, 19)
        Me.obj_search_chk_inventorymoving_descr.TabIndex = 0
        Me.obj_search_chk_inventorymoving_descr.Text = "Descr"
        Me.obj_search_chk_inventorymoving_descr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_search_chk_inventorymoving_descr.UseVisualStyleBackColor = True
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ftabMain_Data.Controls.Add(Me.ftabDataDetil)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataMaster)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataFooter)
        Me.ftabMain_Data.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_Data.Name = "ftabMain_Data"
        Me.ftabMain_Data.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_Data.Size = New System.Drawing.Size(739, 490)
        Me.ftabMain_Data.TabIndex = 1
        Me.ftabMain_Data.Text = "Data"
        '
        'ftabDataDetil
        '
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Item)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Exception)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Prop)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Log)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Record)
        Me.ftabDataDetil.Location = New System.Drawing.Point(3, 193)
        Me.ftabDataDetil.Margin = New System.Windows.Forms.Padding(0)
        Me.ftabDataDetil.myBackColor = System.Drawing.Color.WhiteSmoke
        Me.ftabDataDetil.Name = "ftabDataDetil"
        Me.ftabDataDetil.SelectedIndex = 0
        Me.ftabDataDetil.Size = New System.Drawing.Size(733, 208)
        Me.ftabDataDetil.TabIndex = 3
        '
        'ftabDataDetil_Item
        '
        Me.ftabDataDetil_Item.BackColor = System.Drawing.Color.LightCyan
        Me.ftabDataDetil_Item.Controls.Add(Me.DgvItem)
        Me.ftabDataDetil_Item.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Item.Name = "ftabDataDetil_Item"
        Me.ftabDataDetil_Item.Size = New System.Drawing.Size(725, 179)
        Me.ftabDataDetil_Item.TabIndex = 8
        Me.ftabDataDetil_Item.Text = "Items"
        '
        'DgvItem
        '
        Me.DgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvItem.Location = New System.Drawing.Point(3, 3)
        Me.DgvItem.Name = "DgvItem"
        Me.DgvItem.Size = New System.Drawing.Size(719, 173)
        Me.DgvItem.TabIndex = 2
        '
        'ftabDataDetil_Exception
        '
        Me.ftabDataDetil_Exception.BackColor = System.Drawing.Color.Pink
        Me.ftabDataDetil_Exception.Controls.Add(Me.DgvException)
        Me.ftabDataDetil_Exception.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Exception.Name = "ftabDataDetil_Exception"
        Me.ftabDataDetil_Exception.Size = New System.Drawing.Size(725, 179)
        Me.ftabDataDetil_Exception.TabIndex = 7
        Me.ftabDataDetil_Exception.Text = "Exception"
        '
        'DgvException
        '
        Me.DgvException.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvException.Location = New System.Drawing.Point(3, 3)
        Me.DgvException.Name = "DgvException"
        Me.DgvException.Size = New System.Drawing.Size(719, 173)
        Me.DgvException.TabIndex = 3
        '
        'ftabDataDetil_Prop
        '
        Me.ftabDataDetil_Prop.BackColor = System.Drawing.Color.LemonChiffon
        Me.ftabDataDetil_Prop.Controls.Add(Me.DgvProp)
        Me.ftabDataDetil_Prop.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Prop.Name = "ftabDataDetil_Prop"
        Me.ftabDataDetil_Prop.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Prop.Size = New System.Drawing.Size(725, 179)
        Me.ftabDataDetil_Prop.TabIndex = 0
        Me.ftabDataDetil_Prop.Text = "Property"
        '
        'DgvProp
        '
        Me.DgvProp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvProp.Location = New System.Drawing.Point(3, 3)
        Me.DgvProp.Name = "DgvProp"
        Me.DgvProp.Size = New System.Drawing.Size(719, 173)
        Me.DgvProp.TabIndex = 2
        '
        'ftabDataDetil_Log
        '
        Me.ftabDataDetil_Log.BackColor = System.Drawing.Color.Beige
        Me.ftabDataDetil_Log.Controls.Add(Me.DgvLog)
        Me.ftabDataDetil_Log.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Log.Name = "ftabDataDetil_Log"
        Me.ftabDataDetil_Log.Size = New System.Drawing.Size(725, 179)
        Me.ftabDataDetil_Log.TabIndex = 6
        Me.ftabDataDetil_Log.Text = "Log"
        '
        'DgvLog
        '
        Me.DgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvLog.Location = New System.Drawing.Point(3, 3)
        Me.DgvLog.Name = "DgvLog"
        Me.DgvLog.Size = New System.Drawing.Size(719, 173)
        Me.DgvLog.TabIndex = 2
        '
        'ftabDataDetil_Record
        '
        Me.ftabDataDetil_Record.BackColor = System.Drawing.Color.Gainsboro
        Me.ftabDataDetil_Record.Controls.Add(Me.lbl_inventorymoving_postdate)
        Me.ftabDataDetil_Record.Controls.Add(Me.lbl_inventorymoving_postby)
        Me.ftabDataDetil_Record.Controls.Add(Me.obj_inventorymoving_postdate)
        Me.ftabDataDetil_Record.Controls.Add(Me.obj_inventorymoving_postby)
        Me.ftabDataDetil_Record.Controls.Add(Me.lbl_inventorymoving_receivedate)
        Me.ftabDataDetil_Record.Controls.Add(Me.lbl_rowid)
        Me.ftabDataDetil_Record.Controls.Add(Me.lbl_inventorymoving_receiveby)
        Me.ftabDataDetil_Record.Controls.Add(Me.lbl_inventorymoving_senddate)
        Me.ftabDataDetil_Record.Controls.Add(Me.lbl_inventorymoving_modifieddate)
        Me.ftabDataDetil_Record.Controls.Add(Me.lbl_inventorymoving_sendby)
        Me.ftabDataDetil_Record.Controls.Add(Me.lbl_inventorymoving_createby)
        Me.ftabDataDetil_Record.Controls.Add(Me.obj_inventorymoving_createby)
        Me.ftabDataDetil_Record.Controls.Add(Me.obj_inventorymoving_receivedate)
        Me.ftabDataDetil_Record.Controls.Add(Me.lbl_inventorymoving_modifiedby)
        Me.ftabDataDetil_Record.Controls.Add(Me.obj_inventorymoving_receiveby)
        Me.ftabDataDetil_Record.Controls.Add(Me.obj_inventorymoving_createdate)
        Me.ftabDataDetil_Record.Controls.Add(Me.obj_inventorymoving_sendby)
        Me.ftabDataDetil_Record.Controls.Add(Me.lbl_inventorymoving_createdate)
        Me.ftabDataDetil_Record.Controls.Add(Me.obj_inventorymoving_senddate)
        Me.ftabDataDetil_Record.Controls.Add(Me.obj_inventorymoving_modifyby)
        Me.ftabDataDetil_Record.Controls.Add(Me.obj_rowid)
        Me.ftabDataDetil_Record.Controls.Add(Me.obj_inventorymoving_modifydate)
        Me.ftabDataDetil_Record.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Record.Name = "ftabDataDetil_Record"
        Me.ftabDataDetil_Record.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Record.Size = New System.Drawing.Size(725, 179)
        Me.ftabDataDetil_Record.TabIndex = 0
        Me.ftabDataDetil_Record.Text = "Record"
        '
        'lbl_inventorymoving_postdate
        '
        Me.lbl_inventorymoving_postdate.Location = New System.Drawing.Point(399, 152)
        Me.lbl_inventorymoving_postdate.Name = "lbl_inventorymoving_postdate"
        Me.lbl_inventorymoving_postdate.Size = New System.Drawing.Size(80, 20)
        Me.lbl_inventorymoving_postdate.TabIndex = 32
        Me.lbl_inventorymoving_postdate.Text = "Post Date"
        Me.lbl_inventorymoving_postdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_inventorymoving_postby
        '
        Me.lbl_inventorymoving_postby.Location = New System.Drawing.Point(399, 126)
        Me.lbl_inventorymoving_postby.Name = "lbl_inventorymoving_postby"
        Me.lbl_inventorymoving_postby.Size = New System.Drawing.Size(80, 20)
        Me.lbl_inventorymoving_postby.TabIndex = 31
        Me.lbl_inventorymoving_postby.Text = "Post By"
        Me.lbl_inventorymoving_postby.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_inventorymoving_postdate
        '
        Me.obj_inventorymoving_postdate.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_inventorymoving_postdate.Location = New System.Drawing.Point(485, 152)
        Me.obj_inventorymoving_postdate.Name = "obj_inventorymoving_postdate"
        Me.obj_inventorymoving_postdate.ReadOnly = True
        Me.obj_inventorymoving_postdate.Size = New System.Drawing.Size(185, 20)
        Me.obj_inventorymoving_postdate.TabIndex = 30
        '
        'obj_inventorymoving_postby
        '
        Me.obj_inventorymoving_postby.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_inventorymoving_postby.Location = New System.Drawing.Point(485, 126)
        Me.obj_inventorymoving_postby.Name = "obj_inventorymoving_postby"
        Me.obj_inventorymoving_postby.ReadOnly = True
        Me.obj_inventorymoving_postby.Size = New System.Drawing.Size(185, 20)
        Me.obj_inventorymoving_postby.TabIndex = 29
        '
        'lbl_inventorymoving_receivedate
        '
        Me.lbl_inventorymoving_receivedate.Location = New System.Drawing.Point(399, 94)
        Me.lbl_inventorymoving_receivedate.Name = "lbl_inventorymoving_receivedate"
        Me.lbl_inventorymoving_receivedate.Size = New System.Drawing.Size(80, 20)
        Me.lbl_inventorymoving_receivedate.TabIndex = 28
        Me.lbl_inventorymoving_receivedate.Text = "Receive Date"
        Me.lbl_inventorymoving_receivedate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_rowid
        '
        Me.lbl_rowid.Location = New System.Drawing.Point(18, 152)
        Me.lbl_rowid.Name = "lbl_rowid"
        Me.lbl_rowid.Size = New System.Drawing.Size(80, 20)
        Me.lbl_rowid.TabIndex = 20
        Me.lbl_rowid.Text = "Rowid"
        Me.lbl_rowid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_inventorymoving_receiveby
        '
        Me.lbl_inventorymoving_receiveby.Location = New System.Drawing.Point(399, 68)
        Me.lbl_inventorymoving_receiveby.Name = "lbl_inventorymoving_receiveby"
        Me.lbl_inventorymoving_receiveby.Size = New System.Drawing.Size(80, 20)
        Me.lbl_inventorymoving_receiveby.TabIndex = 27
        Me.lbl_inventorymoving_receiveby.Text = "Receive By"
        Me.lbl_inventorymoving_receiveby.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_inventorymoving_senddate
        '
        Me.lbl_inventorymoving_senddate.Location = New System.Drawing.Point(399, 36)
        Me.lbl_inventorymoving_senddate.Name = "lbl_inventorymoving_senddate"
        Me.lbl_inventorymoving_senddate.Size = New System.Drawing.Size(80, 20)
        Me.lbl_inventorymoving_senddate.TabIndex = 26
        Me.lbl_inventorymoving_senddate.Text = "Send Date"
        Me.lbl_inventorymoving_senddate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_inventorymoving_modifieddate
        '
        Me.lbl_inventorymoving_modifieddate.Location = New System.Drawing.Point(18, 94)
        Me.lbl_inventorymoving_modifieddate.Name = "lbl_inventorymoving_modifieddate"
        Me.lbl_inventorymoving_modifieddate.Size = New System.Drawing.Size(80, 20)
        Me.lbl_inventorymoving_modifieddate.TabIndex = 19
        Me.lbl_inventorymoving_modifieddate.Text = "Modified Date"
        Me.lbl_inventorymoving_modifieddate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_inventorymoving_sendby
        '
        Me.lbl_inventorymoving_sendby.Location = New System.Drawing.Point(399, 10)
        Me.lbl_inventorymoving_sendby.Name = "lbl_inventorymoving_sendby"
        Me.lbl_inventorymoving_sendby.Size = New System.Drawing.Size(80, 20)
        Me.lbl_inventorymoving_sendby.TabIndex = 25
        Me.lbl_inventorymoving_sendby.Text = "Send By"
        Me.lbl_inventorymoving_sendby.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_inventorymoving_createby
        '
        Me.lbl_inventorymoving_createby.Location = New System.Drawing.Point(18, 10)
        Me.lbl_inventorymoving_createby.Name = "lbl_inventorymoving_createby"
        Me.lbl_inventorymoving_createby.Size = New System.Drawing.Size(80, 20)
        Me.lbl_inventorymoving_createby.TabIndex = 16
        Me.lbl_inventorymoving_createby.Text = "Create By"
        Me.lbl_inventorymoving_createby.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_inventorymoving_createby
        '
        Me.obj_inventorymoving_createby.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_inventorymoving_createby.Location = New System.Drawing.Point(104, 10)
        Me.obj_inventorymoving_createby.Name = "obj_inventorymoving_createby"
        Me.obj_inventorymoving_createby.ReadOnly = True
        Me.obj_inventorymoving_createby.Size = New System.Drawing.Size(185, 20)
        Me.obj_inventorymoving_createby.TabIndex = 10
        '
        'obj_inventorymoving_receivedate
        '
        Me.obj_inventorymoving_receivedate.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_inventorymoving_receivedate.Location = New System.Drawing.Point(485, 94)
        Me.obj_inventorymoving_receivedate.Name = "obj_inventorymoving_receivedate"
        Me.obj_inventorymoving_receivedate.ReadOnly = True
        Me.obj_inventorymoving_receivedate.Size = New System.Drawing.Size(185, 20)
        Me.obj_inventorymoving_receivedate.TabIndex = 24
        '
        'lbl_inventorymoving_modifiedby
        '
        Me.lbl_inventorymoving_modifiedby.Location = New System.Drawing.Point(18, 68)
        Me.lbl_inventorymoving_modifiedby.Name = "lbl_inventorymoving_modifiedby"
        Me.lbl_inventorymoving_modifiedby.Size = New System.Drawing.Size(80, 20)
        Me.lbl_inventorymoving_modifiedby.TabIndex = 18
        Me.lbl_inventorymoving_modifiedby.Text = "Modified By"
        Me.lbl_inventorymoving_modifiedby.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_inventorymoving_receiveby
        '
        Me.obj_inventorymoving_receiveby.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_inventorymoving_receiveby.Location = New System.Drawing.Point(485, 68)
        Me.obj_inventorymoving_receiveby.Name = "obj_inventorymoving_receiveby"
        Me.obj_inventorymoving_receiveby.ReadOnly = True
        Me.obj_inventorymoving_receiveby.Size = New System.Drawing.Size(185, 20)
        Me.obj_inventorymoving_receiveby.TabIndex = 23
        '
        'obj_inventorymoving_createdate
        '
        Me.obj_inventorymoving_createdate.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_inventorymoving_createdate.Location = New System.Drawing.Point(104, 36)
        Me.obj_inventorymoving_createdate.Name = "obj_inventorymoving_createdate"
        Me.obj_inventorymoving_createdate.ReadOnly = True
        Me.obj_inventorymoving_createdate.Size = New System.Drawing.Size(185, 20)
        Me.obj_inventorymoving_createdate.TabIndex = 11
        '
        'obj_inventorymoving_sendby
        '
        Me.obj_inventorymoving_sendby.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_inventorymoving_sendby.Location = New System.Drawing.Point(485, 10)
        Me.obj_inventorymoving_sendby.Name = "obj_inventorymoving_sendby"
        Me.obj_inventorymoving_sendby.ReadOnly = True
        Me.obj_inventorymoving_sendby.Size = New System.Drawing.Size(185, 20)
        Me.obj_inventorymoving_sendby.TabIndex = 21
        '
        'lbl_inventorymoving_createdate
        '
        Me.lbl_inventorymoving_createdate.Location = New System.Drawing.Point(18, 36)
        Me.lbl_inventorymoving_createdate.Name = "lbl_inventorymoving_createdate"
        Me.lbl_inventorymoving_createdate.Size = New System.Drawing.Size(80, 20)
        Me.lbl_inventorymoving_createdate.TabIndex = 17
        Me.lbl_inventorymoving_createdate.Text = "Create Date"
        Me.lbl_inventorymoving_createdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_inventorymoving_senddate
        '
        Me.obj_inventorymoving_senddate.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_inventorymoving_senddate.Location = New System.Drawing.Point(485, 36)
        Me.obj_inventorymoving_senddate.Name = "obj_inventorymoving_senddate"
        Me.obj_inventorymoving_senddate.ReadOnly = True
        Me.obj_inventorymoving_senddate.Size = New System.Drawing.Size(185, 20)
        Me.obj_inventorymoving_senddate.TabIndex = 22
        '
        'obj_inventorymoving_modifyby
        '
        Me.obj_inventorymoving_modifyby.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_inventorymoving_modifyby.Location = New System.Drawing.Point(104, 68)
        Me.obj_inventorymoving_modifyby.Name = "obj_inventorymoving_modifyby"
        Me.obj_inventorymoving_modifyby.ReadOnly = True
        Me.obj_inventorymoving_modifyby.Size = New System.Drawing.Size(185, 20)
        Me.obj_inventorymoving_modifyby.TabIndex = 12
        '
        'obj_rowid
        '
        Me.obj_rowid.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_rowid.Location = New System.Drawing.Point(104, 152)
        Me.obj_rowid.Name = "obj_rowid"
        Me.obj_rowid.ReadOnly = True
        Me.obj_rowid.Size = New System.Drawing.Size(234, 20)
        Me.obj_rowid.TabIndex = 14
        '
        'obj_inventorymoving_modifydate
        '
        Me.obj_inventorymoving_modifydate.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_inventorymoving_modifydate.Location = New System.Drawing.Point(104, 94)
        Me.obj_inventorymoving_modifydate.Name = "obj_inventorymoving_modifydate"
        Me.obj_inventorymoving_modifydate.ReadOnly = True
        Me.obj_inventorymoving_modifydate.Size = New System.Drawing.Size(185, 20)
        Me.obj_inventorymoving_modifydate.TabIndex = 13
        '
        'PnlDataMaster
        '
        Me.PnlDataMaster.AutoScroll = True
        Me.PnlDataMaster.Controls.Add(Me.lbl_inventorymoving_branch_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_inventorymoving_region)
        Me.PnlDataMaster.Controls.Add(Me.lbl_transaction_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_transaction_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_iteminventorytype_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_iteminventorysubtype_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_iteminventorytype_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_branch_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_region_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_channel_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_channel_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_inventorymoving_type)
        Me.PnlDataMaster.Controls.Add(Me.obj_inventorymoving_source)
        Me.PnlDataMaster.Controls.Add(Me.obj_inventorymovingtype_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_inventorymoving_date)
        Me.PnlDataMaster.Controls.Add(Me.lbl_inventorymoving_date)
        Me.PnlDataMaster.Controls.Add(Me.lbl_inventorymoving_descr)
        Me.PnlDataMaster.Controls.Add(Me.lbl_inventorymoving_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_inventorymoving_descr)
        Me.PnlDataMaster.Controls.Add(Me.obj_inventorymoving_id)
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(733, 185)
        Me.PnlDataMaster.TabIndex = 0
        '
        'lbl_inventorymoving_branch_id
        '
        Me.lbl_inventorymoving_branch_id.Location = New System.Drawing.Point(7, 88)
        Me.lbl_inventorymoving_branch_id.Name = "lbl_inventorymoving_branch_id"
        Me.lbl_inventorymoving_branch_id.Size = New System.Drawing.Size(80, 20)
        Me.lbl_inventorymoving_branch_id.TabIndex = 100
        Me.lbl_inventorymoving_branch_id.Text = "Branch"
        Me.lbl_inventorymoving_branch_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_inventorymoving_region
        '
        Me.lbl_inventorymoving_region.Location = New System.Drawing.Point(7, 59)
        Me.lbl_inventorymoving_region.Name = "lbl_inventorymoving_region"
        Me.lbl_inventorymoving_region.Size = New System.Drawing.Size(80, 20)
        Me.lbl_inventorymoving_region.TabIndex = 99
        Me.lbl_inventorymoving_region.Text = "Region"
        Me.lbl_inventorymoving_region.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_transaction_id
        '
        Me.lbl_transaction_id.Location = New System.Drawing.Point(409, 87)
        Me.lbl_transaction_id.Name = "lbl_transaction_id"
        Me.lbl_transaction_id.Size = New System.Drawing.Size(105, 20)
        Me.lbl_transaction_id.TabIndex = 97
        Me.lbl_transaction_id.Text = "Transaction"
        Me.lbl_transaction_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_transaction_id
        '
        Me.obj_transaction_id.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_transaction_id.Location = New System.Drawing.Point(520, 87)
        Me.obj_transaction_id.Name = "obj_transaction_id"
        Me.obj_transaction_id.ReadOnly = True
        Me.obj_transaction_id.Size = New System.Drawing.Size(61, 20)
        Me.obj_transaction_id.TabIndex = 96
        '
        'lbl_iteminventorytype_id
        '
        Me.lbl_iteminventorytype_id.Location = New System.Drawing.Point(409, 58)
        Me.lbl_iteminventorytype_id.Name = "lbl_iteminventorytype_id"
        Me.lbl_iteminventorytype_id.Size = New System.Drawing.Size(105, 20)
        Me.lbl_iteminventorytype_id.TabIndex = 95
        Me.lbl_iteminventorytype_id.Text = "Item Type"
        Me.lbl_iteminventorytype_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_iteminventorysubtype_id
        '
        Me.obj_iteminventorysubtype_id.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_iteminventorysubtype_id.Location = New System.Drawing.Point(569, 58)
        Me.obj_iteminventorysubtype_id.Name = "obj_iteminventorysubtype_id"
        Me.obj_iteminventorysubtype_id.ReadOnly = True
        Me.obj_iteminventorysubtype_id.Size = New System.Drawing.Size(98, 20)
        Me.obj_iteminventorysubtype_id.TabIndex = 94
        '
        'obj_iteminventorytype_id
        '
        Me.obj_iteminventorytype_id.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_iteminventorytype_id.Location = New System.Drawing.Point(520, 58)
        Me.obj_iteminventorytype_id.Name = "obj_iteminventorytype_id"
        Me.obj_iteminventorytype_id.ReadOnly = True
        Me.obj_iteminventorytype_id.Size = New System.Drawing.Size(43, 20)
        Me.obj_iteminventorytype_id.TabIndex = 93
        '
        'obj_branch_id
        '
        Me.obj_branch_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_branch_id.FormattingEnabled = True
        Me.obj_branch_id.Location = New System.Drawing.Point(93, 87)
        Me.obj_branch_id.Name = "obj_branch_id"
        Me.obj_branch_id.Size = New System.Drawing.Size(128, 21)
        Me.obj_branch_id.TabIndex = 91
        '
        'obj_region_id
        '
        Me.obj_region_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_region_id.FormattingEnabled = True
        Me.obj_region_id.Location = New System.Drawing.Point(93, 58)
        Me.obj_region_id.Name = "obj_region_id"
        Me.obj_region_id.Size = New System.Drawing.Size(133, 21)
        Me.obj_region_id.TabIndex = 90
        '
        'lbl_channel_id
        '
        Me.lbl_channel_id.Location = New System.Drawing.Point(409, 5)
        Me.lbl_channel_id.Name = "lbl_channel_id"
        Me.lbl_channel_id.Size = New System.Drawing.Size(105, 20)
        Me.lbl_channel_id.TabIndex = 87
        Me.lbl_channel_id.Text = "Channel"
        Me.lbl_channel_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_channel_id
        '
        Me.obj_channel_id.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_channel_id.Location = New System.Drawing.Point(520, 6)
        Me.obj_channel_id.Name = "obj_channel_id"
        Me.obj_channel_id.ReadOnly = True
        Me.obj_channel_id.Size = New System.Drawing.Size(98, 20)
        Me.obj_channel_id.TabIndex = 86
        '
        'lbl_inventorymoving_type
        '
        Me.lbl_inventorymoving_type.Location = New System.Drawing.Point(409, 32)
        Me.lbl_inventorymoving_type.Name = "lbl_inventorymoving_type"
        Me.lbl_inventorymoving_type.Size = New System.Drawing.Size(105, 20)
        Me.lbl_inventorymoving_type.TabIndex = 85
        Me.lbl_inventorymoving_type.Text = "Type / Source"
        Me.lbl_inventorymoving_type.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_inventorymoving_source
        '
        Me.obj_inventorymoving_source.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_inventorymoving_source.Location = New System.Drawing.Point(569, 32)
        Me.obj_inventorymoving_source.Name = "obj_inventorymoving_source"
        Me.obj_inventorymoving_source.ReadOnly = True
        Me.obj_inventorymoving_source.Size = New System.Drawing.Size(98, 20)
        Me.obj_inventorymoving_source.TabIndex = 84
        '
        'obj_inventorymovingtype_id
        '
        Me.obj_inventorymovingtype_id.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_inventorymovingtype_id.Location = New System.Drawing.Point(520, 32)
        Me.obj_inventorymovingtype_id.Name = "obj_inventorymovingtype_id"
        Me.obj_inventorymovingtype_id.ReadOnly = True
        Me.obj_inventorymovingtype_id.Size = New System.Drawing.Size(43, 20)
        Me.obj_inventorymovingtype_id.TabIndex = 83
        '
        'obj_inventorymoving_date
        '
        Me.obj_inventorymoving_date.CustomFormat = "dd/MM/yyyy"
        Me.obj_inventorymoving_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_inventorymoving_date.Location = New System.Drawing.Point(93, 32)
        Me.obj_inventorymoving_date.Name = "obj_inventorymoving_date"
        Me.obj_inventorymoving_date.Size = New System.Drawing.Size(91, 20)
        Me.obj_inventorymoving_date.TabIndex = 78
        '
        'lbl_inventorymoving_date
        '
        Me.lbl_inventorymoving_date.Location = New System.Drawing.Point(7, 32)
        Me.lbl_inventorymoving_date.Name = "lbl_inventorymoving_date"
        Me.lbl_inventorymoving_date.Size = New System.Drawing.Size(80, 20)
        Me.lbl_inventorymoving_date.TabIndex = 16
        Me.lbl_inventorymoving_date.Text = "Date"
        Me.lbl_inventorymoving_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_inventorymoving_descr
        '
        Me.lbl_inventorymoving_descr.Location = New System.Drawing.Point(7, 126)
        Me.lbl_inventorymoving_descr.Name = "lbl_inventorymoving_descr"
        Me.lbl_inventorymoving_descr.Size = New System.Drawing.Size(80, 20)
        Me.lbl_inventorymoving_descr.TabIndex = 14
        Me.lbl_inventorymoving_descr.Text = "Descr"
        Me.lbl_inventorymoving_descr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_inventorymoving_id
        '
        Me.lbl_inventorymoving_id.Location = New System.Drawing.Point(7, 6)
        Me.lbl_inventorymoving_id.Name = "lbl_inventorymoving_id"
        Me.lbl_inventorymoving_id.Size = New System.Drawing.Size(80, 20)
        Me.lbl_inventorymoving_id.TabIndex = 11
        Me.lbl_inventorymoving_id.Text = "ID"
        Me.lbl_inventorymoving_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_inventorymoving_descr
        '
        Me.obj_inventorymoving_descr.BackColor = System.Drawing.SystemColors.Info
        Me.obj_inventorymoving_descr.Location = New System.Drawing.Point(93, 126)
        Me.obj_inventorymoving_descr.Multiline = True
        Me.obj_inventorymoving_descr.Name = "obj_inventorymoving_descr"
        Me.obj_inventorymoving_descr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.obj_inventorymoving_descr.Size = New System.Drawing.Size(306, 50)
        Me.obj_inventorymoving_descr.TabIndex = 6
        '
        'obj_inventorymoving_id
        '
        Me.obj_inventorymoving_id.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_inventorymoving_id.Location = New System.Drawing.Point(93, 6)
        Me.obj_inventorymoving_id.Name = "obj_inventorymoving_id"
        Me.obj_inventorymoving_id.ReadOnly = True
        Me.obj_inventorymoving_id.Size = New System.Drawing.Size(210, 20)
        Me.obj_inventorymoving_id.TabIndex = 0
        '
        'PnlDataFooter
        '
        Me.PnlDataFooter.Controls.Add(Me.obj_inventorymoving_totalproposed)
        Me.PnlDataFooter.Controls.Add(Me.obj_inventorymoving_isproposed)
        Me.PnlDataFooter.Controls.Add(Me.lbl_inventorymoving_valuelost)
        Me.PnlDataFooter.Controls.Add(Me.lbl_inventorymoving_valuereceived)
        Me.PnlDataFooter.Controls.Add(Me.lbl_inventorymoving_valuesent)
        Me.PnlDataFooter.Controls.Add(Me.lbl_inventorymoving_totalbalance)
        Me.PnlDataFooter.Controls.Add(Me.lbl_inventorymoving_totalreceive)
        Me.PnlDataFooter.Controls.Add(Me.lbl_inventorymoving_totalsent)
        Me.PnlDataFooter.Controls.Add(Me.obj_inventorymoving_valuelost)
        Me.PnlDataFooter.Controls.Add(Me.obj_inventorymoving_valuereceived)
        Me.PnlDataFooter.Controls.Add(Me.obj_inventorymoving_valuesent)
        Me.PnlDataFooter.Controls.Add(Me.obj_inventorymoving_totalbalance)
        Me.PnlDataFooter.Controls.Add(Me.obj_inventorymoving_totalreceived)
        Me.PnlDataFooter.Controls.Add(Me.obj_inventorymoving_totalsent)
        Me.PnlDataFooter.Controls.Add(Me.lbl_inventorymoving_status)
        Me.PnlDataFooter.Controls.Add(Me.obj_inventorymoving_issent)
        Me.PnlDataFooter.Controls.Add(Me.obj_inventorymoving_isposted)
        Me.PnlDataFooter.Controls.Add(Me.obj_inventorymoving_isreceived)
        Me.PnlDataFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDataFooter.Location = New System.Drawing.Point(3, 404)
        Me.PnlDataFooter.Name = "PnlDataFooter"
        Me.PnlDataFooter.Size = New System.Drawing.Size(733, 83)
        Me.PnlDataFooter.TabIndex = 2
        '
        'obj_inventorymoving_totalproposed
        '
        Me.obj_inventorymoving_totalproposed.BackColor = System.Drawing.Color.LightSteelBlue
        Me.obj_inventorymoving_totalproposed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_inventorymoving_totalproposed.Location = New System.Drawing.Point(123, 5)
        Me.obj_inventorymoving_totalproposed.Name = "obj_inventorymoving_totalproposed"
        Me.obj_inventorymoving_totalproposed.ReadOnly = True
        Me.obj_inventorymoving_totalproposed.Size = New System.Drawing.Size(94, 20)
        Me.obj_inventorymoving_totalproposed.TabIndex = 110
        Me.obj_inventorymoving_totalproposed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'obj_inventorymoving_isproposed
        '
        Me.obj_inventorymoving_isproposed.Enabled = False
        Me.obj_inventorymoving_isproposed.Location = New System.Drawing.Point(43, 7)
        Me.obj_inventorymoving_isproposed.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.obj_inventorymoving_isproposed.Name = "obj_inventorymoving_isproposed"
        Me.obj_inventorymoving_isproposed.Size = New System.Drawing.Size(74, 18)
        Me.obj_inventorymoving_isproposed.TabIndex = 109
        Me.obj_inventorymoving_isproposed.Text = "Proposed"
        Me.obj_inventorymoving_isproposed.UseVisualStyleBackColor = True
        '
        'lbl_inventorymoving_valuelost
        '
        Me.lbl_inventorymoving_valuelost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_inventorymoving_valuelost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_inventorymoving_valuelost.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbl_inventorymoving_valuelost.Location = New System.Drawing.Point(274, 57)
        Me.lbl_inventorymoving_valuelost.Name = "lbl_inventorymoving_valuelost"
        Me.lbl_inventorymoving_valuelost.Size = New System.Drawing.Size(105, 20)
        Me.lbl_inventorymoving_valuelost.TabIndex = 108
        Me.lbl_inventorymoving_valuelost.Text = "Lost Value"
        Me.lbl_inventorymoving_valuelost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_inventorymoving_valuelost.Visible = False
        '
        'lbl_inventorymoving_valuereceived
        '
        Me.lbl_inventorymoving_valuereceived.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_inventorymoving_valuereceived.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_inventorymoving_valuereceived.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbl_inventorymoving_valuereceived.Location = New System.Drawing.Point(274, 31)
        Me.lbl_inventorymoving_valuereceived.Name = "lbl_inventorymoving_valuereceived"
        Me.lbl_inventorymoving_valuereceived.Size = New System.Drawing.Size(105, 20)
        Me.lbl_inventorymoving_valuereceived.TabIndex = 107
        Me.lbl_inventorymoving_valuereceived.Text = "Received Value"
        Me.lbl_inventorymoving_valuereceived.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_inventorymoving_valuereceived.Visible = False
        '
        'lbl_inventorymoving_valuesent
        '
        Me.lbl_inventorymoving_valuesent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_inventorymoving_valuesent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_inventorymoving_valuesent.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbl_inventorymoving_valuesent.Location = New System.Drawing.Point(274, 5)
        Me.lbl_inventorymoving_valuesent.Name = "lbl_inventorymoving_valuesent"
        Me.lbl_inventorymoving_valuesent.Size = New System.Drawing.Size(105, 20)
        Me.lbl_inventorymoving_valuesent.TabIndex = 106
        Me.lbl_inventorymoving_valuesent.Text = "Sent Value"
        Me.lbl_inventorymoving_valuesent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_inventorymoving_valuesent.Visible = False
        '
        'lbl_inventorymoving_totalbalance
        '
        Me.lbl_inventorymoving_totalbalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_inventorymoving_totalbalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_inventorymoving_totalbalance.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbl_inventorymoving_totalbalance.Location = New System.Drawing.Point(569, 56)
        Me.lbl_inventorymoving_totalbalance.Name = "lbl_inventorymoving_totalbalance"
        Me.lbl_inventorymoving_totalbalance.Size = New System.Drawing.Size(64, 20)
        Me.lbl_inventorymoving_totalbalance.TabIndex = 105
        Me.lbl_inventorymoving_totalbalance.Text = "Balance"
        Me.lbl_inventorymoving_totalbalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_inventorymoving_totalreceive
        '
        Me.lbl_inventorymoving_totalreceive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_inventorymoving_totalreceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_inventorymoving_totalreceive.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbl_inventorymoving_totalreceive.Location = New System.Drawing.Point(569, 31)
        Me.lbl_inventorymoving_totalreceive.Name = "lbl_inventorymoving_totalreceive"
        Me.lbl_inventorymoving_totalreceive.Size = New System.Drawing.Size(64, 20)
        Me.lbl_inventorymoving_totalreceive.TabIndex = 104
        Me.lbl_inventorymoving_totalreceive.Text = "Received"
        Me.lbl_inventorymoving_totalreceive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_inventorymoving_totalsent
        '
        Me.lbl_inventorymoving_totalsent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_inventorymoving_totalsent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_inventorymoving_totalsent.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbl_inventorymoving_totalsent.Location = New System.Drawing.Point(566, 4)
        Me.lbl_inventorymoving_totalsent.Name = "lbl_inventorymoving_totalsent"
        Me.lbl_inventorymoving_totalsent.Size = New System.Drawing.Size(67, 20)
        Me.lbl_inventorymoving_totalsent.TabIndex = 103
        Me.lbl_inventorymoving_totalsent.Text = "Sent"
        Me.lbl_inventorymoving_totalsent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_inventorymoving_valuelost
        '
        Me.obj_inventorymoving_valuelost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_inventorymoving_valuelost.BackColor = System.Drawing.Color.PaleGreen
        Me.obj_inventorymoving_valuelost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_inventorymoving_valuelost.Location = New System.Drawing.Point(385, 57)
        Me.obj_inventorymoving_valuelost.Name = "obj_inventorymoving_valuelost"
        Me.obj_inventorymoving_valuelost.ReadOnly = True
        Me.obj_inventorymoving_valuelost.Size = New System.Drawing.Size(164, 20)
        Me.obj_inventorymoving_valuelost.TabIndex = 102
        Me.obj_inventorymoving_valuelost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.obj_inventorymoving_valuelost.Visible = False
        '
        'obj_inventorymoving_valuereceived
        '
        Me.obj_inventorymoving_valuereceived.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_inventorymoving_valuereceived.BackColor = System.Drawing.Color.LightSteelBlue
        Me.obj_inventorymoving_valuereceived.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_inventorymoving_valuereceived.Location = New System.Drawing.Point(385, 31)
        Me.obj_inventorymoving_valuereceived.Name = "obj_inventorymoving_valuereceived"
        Me.obj_inventorymoving_valuereceived.ReadOnly = True
        Me.obj_inventorymoving_valuereceived.Size = New System.Drawing.Size(164, 20)
        Me.obj_inventorymoving_valuereceived.TabIndex = 101
        Me.obj_inventorymoving_valuereceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.obj_inventorymoving_valuereceived.Visible = False
        '
        'obj_inventorymoving_valuesent
        '
        Me.obj_inventorymoving_valuesent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_inventorymoving_valuesent.BackColor = System.Drawing.Color.LightSteelBlue
        Me.obj_inventorymoving_valuesent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_inventorymoving_valuesent.Location = New System.Drawing.Point(385, 5)
        Me.obj_inventorymoving_valuesent.Name = "obj_inventorymoving_valuesent"
        Me.obj_inventorymoving_valuesent.ReadOnly = True
        Me.obj_inventorymoving_valuesent.Size = New System.Drawing.Size(164, 20)
        Me.obj_inventorymoving_valuesent.TabIndex = 100
        Me.obj_inventorymoving_valuesent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.obj_inventorymoving_valuesent.Visible = False
        '
        'obj_inventorymoving_totalbalance
        '
        Me.obj_inventorymoving_totalbalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_inventorymoving_totalbalance.BackColor = System.Drawing.Color.PaleGreen
        Me.obj_inventorymoving_totalbalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_inventorymoving_totalbalance.Location = New System.Drawing.Point(639, 57)
        Me.obj_inventorymoving_totalbalance.Name = "obj_inventorymoving_totalbalance"
        Me.obj_inventorymoving_totalbalance.ReadOnly = True
        Me.obj_inventorymoving_totalbalance.Size = New System.Drawing.Size(94, 20)
        Me.obj_inventorymoving_totalbalance.TabIndex = 99
        Me.obj_inventorymoving_totalbalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'obj_inventorymoving_totalreceived
        '
        Me.obj_inventorymoving_totalreceived.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_inventorymoving_totalreceived.BackColor = System.Drawing.Color.LightSteelBlue
        Me.obj_inventorymoving_totalreceived.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_inventorymoving_totalreceived.Location = New System.Drawing.Point(639, 31)
        Me.obj_inventorymoving_totalreceived.Name = "obj_inventorymoving_totalreceived"
        Me.obj_inventorymoving_totalreceived.ReadOnly = True
        Me.obj_inventorymoving_totalreceived.Size = New System.Drawing.Size(94, 20)
        Me.obj_inventorymoving_totalreceived.TabIndex = 98
        Me.obj_inventorymoving_totalreceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'obj_inventorymoving_totalsent
        '
        Me.obj_inventorymoving_totalsent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_inventorymoving_totalsent.BackColor = System.Drawing.Color.LightSteelBlue
        Me.obj_inventorymoving_totalsent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_inventorymoving_totalsent.Location = New System.Drawing.Point(639, 5)
        Me.obj_inventorymoving_totalsent.Name = "obj_inventorymoving_totalsent"
        Me.obj_inventorymoving_totalsent.ReadOnly = True
        Me.obj_inventorymoving_totalsent.Size = New System.Drawing.Size(94, 20)
        Me.obj_inventorymoving_totalsent.TabIndex = 97
        Me.obj_inventorymoving_totalsent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_inventorymoving_status
        '
        Me.lbl_inventorymoving_status.Location = New System.Drawing.Point(-3, 5)
        Me.lbl_inventorymoving_status.Name = "lbl_inventorymoving_status"
        Me.lbl_inventorymoving_status.Size = New System.Drawing.Size(40, 20)
        Me.lbl_inventorymoving_status.TabIndex = 88
        Me.lbl_inventorymoving_status.Text = "Status"
        Me.lbl_inventorymoving_status.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_inventorymoving_issent
        '
        Me.obj_inventorymoving_issent.Enabled = False
        Me.obj_inventorymoving_issent.Location = New System.Drawing.Point(43, 26)
        Me.obj_inventorymoving_issent.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.obj_inventorymoving_issent.Name = "obj_inventorymoving_issent"
        Me.obj_inventorymoving_issent.Size = New System.Drawing.Size(74, 15)
        Me.obj_inventorymoving_issent.TabIndex = 79
        Me.obj_inventorymoving_issent.Text = "Sent"
        Me.obj_inventorymoving_issent.UseVisualStyleBackColor = True
        '
        'obj_inventorymoving_isposted
        '
        Me.obj_inventorymoving_isposted.Enabled = False
        Me.obj_inventorymoving_isposted.Location = New System.Drawing.Point(43, 62)
        Me.obj_inventorymoving_isposted.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.obj_inventorymoving_isposted.Name = "obj_inventorymoving_isposted"
        Me.obj_inventorymoving_isposted.Size = New System.Drawing.Size(74, 15)
        Me.obj_inventorymoving_isposted.TabIndex = 80
        Me.obj_inventorymoving_isposted.Text = "Posted"
        Me.obj_inventorymoving_isposted.UseVisualStyleBackColor = True
        '
        'obj_inventorymoving_isreceived
        '
        Me.obj_inventorymoving_isreceived.Enabled = False
        Me.obj_inventorymoving_isreceived.Location = New System.Drawing.Point(43, 44)
        Me.obj_inventorymoving_isreceived.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.obj_inventorymoving_isreceived.Name = "obj_inventorymoving_isreceived"
        Me.obj_inventorymoving_isreceived.Size = New System.Drawing.Size(74, 15)
        Me.obj_inventorymoving_isreceived.TabIndex = 81
        Me.obj_inventorymoving_isreceived.Text = "Received"
        Me.obj_inventorymoving_isreceived.UseVisualStyleBackColor = True
        '
        'uiTrnInventorymovingAS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackgroundworkerStatus = Translib.uiBase.EBackgroundworkerStatus.Done
        Me.Controls.Add(Me.ftabMain)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Message = "Done. "
        Me.Name = "uiTrnInventorymovingAS"
        Me.Progress = 20
        Me.Status = "Loading Data..."
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        CType(Me.dsMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfFooter.ResumeLayout(False)
        Me.PnlDfFooter.PerformLayout()
        CType(Me.bnList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnList.ResumeLayout(False)
        Me.bnList.PerformLayout()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain_Data.ResumeLayout(False)
        Me.ftabDataDetil.ResumeLayout(False)
        Me.ftabDataDetil_Item.ResumeLayout(False)
        CType(Me.DgvItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_Exception.ResumeLayout(False)
        CType(Me.DgvException, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_Prop.ResumeLayout(False)
        CType(Me.DgvProp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_Log.ResumeLayout(False)
        CType(Me.DgvLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_Record.ResumeLayout(False)
        Me.ftabDataDetil_Record.PerformLayout()
        Me.PnlDataMaster.ResumeLayout(False)
        Me.PnlDataMaster.PerformLayout()
        Me.PnlDataFooter.ResumeLayout(False)
        Me.PnlDataFooter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ftabMain_List As System.Windows.Forms.TabPage
    Friend WithEvents PnlDfMain As System.Windows.Forms.Panel
    Friend WithEvents DgvList As System.Windows.Forms.DataGridView
    Friend WithEvents PnlDfFooter As System.Windows.Forms.Panel
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents ftabMain_Data As System.Windows.Forms.TabPage
    Friend WithEvents ftabDataDetil As FlatTabControl.FlatTabControl
    Friend WithEvents ftabDataDetil_Prop As System.Windows.Forms.TabPage
    Friend WithEvents ftabDataDetil_Log As System.Windows.Forms.TabPage
    Friend WithEvents ftabDataDetil_Record As System.Windows.Forms.TabPage
    Friend WithEvents PnlDataMaster As System.Windows.Forms.Panel
    Friend WithEvents PnlDataFooter As System.Windows.Forms.Panel
    Friend WithEvents bnList As System.Windows.Forms.BindingNavigator
    Friend WithEvents bnPageCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents bnMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bnMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bnSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bnPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents bnSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bnMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bnMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bnSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bnRowCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents bnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents bnSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents obj_inventorymoving_id As System.Windows.Forms.TextBox
    Friend WithEvents DgvProp As System.Windows.Forms.DataGridView
    Friend WithEvents DgvLog As System.Windows.Forms.DataGridView
    Friend WithEvents obj_inventorymoving_descr As System.Windows.Forms.TextBox
    Friend WithEvents lbl_inventorymoving_descr As System.Windows.Forms.Label
    Friend WithEvents lbl_inventorymoving_id As System.Windows.Forms.Label
    Friend WithEvents obj_inventorymoving_modifydate As System.Windows.Forms.TextBox
    Friend WithEvents obj_inventorymoving_modifyby As System.Windows.Forms.TextBox
    Friend WithEvents obj_inventorymoving_createdate As System.Windows.Forms.TextBox
    Friend WithEvents obj_inventorymoving_createby As System.Windows.Forms.TextBox
    Friend WithEvents obj_rowid As System.Windows.Forms.TextBox
    Friend WithEvents lbl_rowid As System.Windows.Forms.Label
    Friend WithEvents lbl_inventorymoving_modifieddate As System.Windows.Forms.Label
    Friend WithEvents lbl_inventorymoving_modifiedby As System.Windows.Forms.Label
    Friend WithEvents lbl_inventorymoving_createdate As System.Windows.Forms.Label
    Friend WithEvents lbl_inventorymoving_createby As System.Windows.Forms.Label
    Friend WithEvents ftabDataDetil_Item As System.Windows.Forms.TabPage
    Friend WithEvents DgvItem As System.Windows.Forms.DataGridView
    Friend WithEvents ftabDataDetil_Exception As System.Windows.Forms.TabPage
    Friend WithEvents DgvException As System.Windows.Forms.DataGridView
    Friend WithEvents bnRowLimit As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents obj_search_chk_inventorymoving_descr As System.Windows.Forms.CheckBox
    Friend WithEvents obj_search_chk_inventorymoving_id As System.Windows.Forms.CheckBox
    Friend WithEvents obj_search_txt_inventorymoving_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_search_txt_inventorymoving_descr As System.Windows.Forms.TextBox
    Public WithEvents ftabMain As FlatTabControl.FlatTabControl
    Friend WithEvents obj_search_txt_inventorymovingtype_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_search_chk_inventorymovingtype_id As System.Windows.Forms.CheckBox
    Friend WithEvents obj_search_txt_channel_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_search_chk_channel_id As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_id As System.Windows.Forms.Label
    Friend WithEvents obj_search_chk_inventorymoving_datestart As System.Windows.Forms.CheckBox
    Friend WithEvents obj_search_dtp_inventorymoving_datestart As System.Windows.Forms.DateTimePicker
    Friend WithEvents obj_search_dtp_inventorymoving_dateend As System.Windows.Forms.DateTimePicker
    Friend WithEvents obj_search_chk_inventorymoving_dateend As System.Windows.Forms.CheckBox
    Friend WithEvents obj_search_txt_iteminventorysubtype_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_search_chk_iteminventorysubtype_id As System.Windows.Forms.CheckBox
    Friend WithEvents obj_search_txt_iteminventorytype_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_search_chk_iteminventorytype_id As System.Windows.Forms.CheckBox
    Friend WithEvents obj_search_chk_region_id As System.Windows.Forms.CheckBox
    Friend WithEvents obj_search_cbo_region_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_search_cbo_branch_id_from As System.Windows.Forms.ComboBox
    Friend WithEvents obj_search_chk_branch_id As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_inventorymoving_date As System.Windows.Forms.Label
    Friend WithEvents lbl_inventorymoving_postdate As System.Windows.Forms.Label
    Friend WithEvents lbl_inventorymoving_postby As System.Windows.Forms.Label
    Friend WithEvents obj_inventorymoving_postdate As System.Windows.Forms.TextBox
    Friend WithEvents obj_inventorymoving_postby As System.Windows.Forms.TextBox
    Friend WithEvents lbl_inventorymoving_receivedate As System.Windows.Forms.Label
    Friend WithEvents lbl_inventorymoving_receiveby As System.Windows.Forms.Label
    Friend WithEvents lbl_inventorymoving_senddate As System.Windows.Forms.Label
    Friend WithEvents lbl_inventorymoving_sendby As System.Windows.Forms.Label
    Friend WithEvents obj_inventorymoving_receivedate As System.Windows.Forms.TextBox
    Friend WithEvents obj_inventorymoving_receiveby As System.Windows.Forms.TextBox
    Friend WithEvents obj_inventorymoving_sendby As System.Windows.Forms.TextBox
    Friend WithEvents obj_inventorymoving_senddate As System.Windows.Forms.TextBox
    Friend WithEvents obj_inventorymoving_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents obj_inventorymoving_isreceived As System.Windows.Forms.CheckBox
    Friend WithEvents obj_inventorymoving_isposted As System.Windows.Forms.CheckBox
    Friend WithEvents obj_inventorymoving_issent As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_inventorymoving_type As System.Windows.Forms.Label
    Friend WithEvents obj_inventorymoving_source As System.Windows.Forms.TextBox
    Friend WithEvents obj_inventorymovingtype_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_channel_id As System.Windows.Forms.Label
    Friend WithEvents obj_channel_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_inventorymoving_status As System.Windows.Forms.Label
    Friend WithEvents obj_branch_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_region_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_iteminventorytype_id As System.Windows.Forms.Label
    Friend WithEvents obj_iteminventorysubtype_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_iteminventorytype_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_transaction_id As System.Windows.Forms.Label
    Friend WithEvents obj_transaction_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_inventorymoving_totalbalance As System.Windows.Forms.TextBox
    Friend WithEvents obj_inventorymoving_totalreceived As System.Windows.Forms.TextBox
    Friend WithEvents obj_inventorymoving_totalsent As System.Windows.Forms.TextBox
    Friend WithEvents obj_inventorymoving_valuelost As System.Windows.Forms.TextBox
    Friend WithEvents obj_inventorymoving_valuereceived As System.Windows.Forms.TextBox
    Friend WithEvents obj_inventorymoving_valuesent As System.Windows.Forms.TextBox
    Friend WithEvents lbl_inventorymoving_totalbalance As System.Windows.Forms.Label
    Friend WithEvents lbl_inventorymoving_totalreceive As System.Windows.Forms.Label
    Friend WithEvents lbl_inventorymoving_totalsent As System.Windows.Forms.Label
    Friend WithEvents lbl_inventorymoving_valuesent As System.Windows.Forms.Label
    Friend WithEvents lbl_inventorymoving_valuelost As System.Windows.Forms.Label
    Friend WithEvents lbl_inventorymoving_valuereceived As System.Windows.Forms.Label
    Friend WithEvents lbl_inventorymoving_branch_id As System.Windows.Forms.Label
    Friend WithEvents lbl_inventorymoving_region As System.Windows.Forms.Label
    Friend WithEvents obj_inventorymoving_isproposed As System.Windows.Forms.CheckBox
    Friend WithEvents obj_inventorymoving_totalproposed As System.Windows.Forms.TextBox

End Class
