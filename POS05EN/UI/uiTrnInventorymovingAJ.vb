Public Class uiTrnInventorymovingAJ

    Public Enum SourceType
        AJ_Manual = 0
        AJ_Propose = 1
        AJ_Send = 2
        AJ_Receive = 3
        AJ_Post = 4
        AJ_Unpost = 5
    End Enum


    Private tblDetilItem As DataTable
    Private tblDetilException As DataTable


    Public _SOURCE As SourceType
    Private errProvider As System.Windows.Forms.ErrorProvider = New System.Windows.Forms.ErrorProvider()
    Private WithEvents objBnTextStatus As ToolStripLabel = New ToolStripLabel


#Region " Constructor "

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MyBase.InitializeControl(Config.DeveloperDefaultSessionID, Config.DeveloperDefaultUserName, Config.WebserviceAddress, Config.DllServer, Nothing, Me.GetType().Assembly)

        Me.Title = "Master Customer"

        ' Customizable Form
        Me.tblList = CreateDatasetList()
        Me.tblList_Temp = CreateDatasetData()

        Me.tblDetilItem = CreateDatasetDetilItem()
        Me.tblDetilException = CreateDatasetDetilException()
        Me.tblProp = CreateDatasetProp()
        Me.tblLog = CreateDatasetLog()

        Me.LayoutUI()

        Me.PrimaryKeyObjectName = "obj_inventorymoving_id"

        Me.WebserviceNS = "inv05tr"
        Me.WebserviceObject = "uitrninventorymovingtr"
        Me.WebserviceNSModule = Config.WebserviceNSModule
        Me.WebserviceObjectModule = Config.WebserviceObjectModule

        Me.ddBinding.Add("DetilItem", Me.tblDetilItem, "ftabDataDetil_Item", "DgvItem", False, True)
        Me.ddBinding.Add("DetilException", Me.tblDetilException, "ftabDataDetil_Exception", "DgvException", False, True)
        Me.ddBinding.Add("Prop", Me.tblProp, "ftabDataDetil_Prop", "DgvProp", False, True)
        Me.ddBinding.Add("Log", Me.tblLog, "ftabDataDetil_Log", "DgvLog", True, False)


        'Data Master
        Me.dsMaster.Tables.Add("master_region")
        Me.dsMaster.Tables.Add("master_branch")
        'Me.dsMaster.Tables.Add("master_rekanan")

        'Master Loader
        Me.MasterLoaderDelay = 30
        Me.MasterDataLoaderQueue.Add("master_region", "master_region", CreateWebService(Me.WebserviceNSGlobal, Me.WebserviceObjectGlobal, "load_regiontopparent_byuser_login"), "")
        Me.MasterDataLoaderQueue.Add("master_branch", "master_branch", CreateWebService(Me.WebserviceNSGlobal, Me.WebserviceObjectGlobal, "load_branch_all"), "")
        'Me.MasterDataLoaderQueue.Add("master_rekanan", "master_rekanan", CreateWebService(Me.WebserviceNSGlobal, Me.WebserviceObjectGlobal, "load_rekanan_all"), "")


        'Printing
        Me.AllowPrintOnList = False
        Me.AllowPrintOnData = True
        Me.DllPrint = Config.DllPrint
        Me.DllPrintRDLC = Config.DllPrintRDLC
        Me.WebserviceDataprintLoader = CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "print")
        Me.WebserviceDataprintPageViewer = CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "print_web")

        Me._SOURCE = SourceType.AJ_Manual

        Me.objBnTextStatus.Name = "objBnTextStatus"
        Me.objBnTextStatus.Text = Me.WebserviceAddress
        Me.objBnTextStatus.Visible = True
        Me.bnList.Items.Add(Me.objBnTextStatus)

    End Sub

    Public Overrides Sub ConstructTableHeader()
        Me.tblList_Temp = CreateDatasetData()
    End Sub

    Public Overrides Sub ConstructTableDetil()
        Me.ddBinding.Tables("DetilItem").Table = CreateDatasetDetilItem()
        Me.ddBinding.Tables("DetilException").Table = CreateDatasetDetilException()
        Me.ddBinding.Tables("Prop").Table = CreateDatasetProp()
        Me.ddBinding.Tables("Log").Table = CreateDatasetLog()
    End Sub

    Public Overloads Function InitializeControl(ByVal session_id As String, ByVal username As String, ByVal webserviceaddress As String, ByVal dllserver As String, ByRef browser As Object) As Boolean
        MyBase.InitializeControl(session_id, username, webserviceaddress, dllserver, Nothing, Me.GetType().Assembly)
        Me.StartupMessage = " "
        Me.bnList.Items("objBnTextStatus").Text = webserviceaddress
        Return True
    End Function

#End Region

#Region " Dataset Main "

    Public Shared Function CreateDatasetList() As DataTable
        Dim tbl As DataTable = New DataTable


        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("inventorymoving_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inventorymoving_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("inventorymoving_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inventorymoving_isproposed", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("inventorymoving_issent", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("inventorymoving_isreceived", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("inventorymoving_isposted", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("region_id_source", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("inventorymoving_id").DefaultValue = ""
        tbl.Columns("inventorymoving_date").DefaultValue = Now()
        tbl.Columns("inventorymoving_descr").DefaultValue = ""
        tbl.Columns("inventorymoving_isproposed").DefaultValue = False
        tbl.Columns("inventorymoving_issent").DefaultValue = False
        tbl.Columns("inventorymoving_isreceived").DefaultValue = False
        tbl.Columns("inventorymoving_isposted").DefaultValue = False
        tbl.Columns("region_id_source").DefaultValue = "0"

        tbl.PrimaryKey = New System.Data.DataColumn() {tbl.Columns("inventorymoving_id")}

        Return tbl
    End Function

    Public Shared Function CreateDatasetData() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("inventorymoving_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inventorymoving_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("inventorymoving_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inventorymoving_source", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inventorymoving_createby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inventorymoving_createdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("inventorymoving_modifyby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inventorymoving_modifydate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("inventorymoving_sendby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inventorymoving_senddate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("inventorymoving_receiveby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inventorymoving_receivedate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("inventorymoving_postby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inventorymoving_postdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("inventorymoving_isproposed", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("inventorymoving_issent", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("inventorymoving_isreceived", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("inventorymoving_isposted", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("inventorymoving_valuesent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("inventorymoving_valuereceived", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("inventorymoving_valuelost", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("inventorymoving_totalproposed", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("inventorymoving_totalsent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("inventorymoving_totalreceived", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("inventorymoving_totalbalance", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("inventorymovingtype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("region_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("branch_id_from", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("branch_id_to", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("iteminventorytype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("iteminventorysubtype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("transaction_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ref_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rowid", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("inventorymoving_id").DefaultValue = ""
        tbl.Columns("inventorymoving_date").DefaultValue = Now()
        tbl.Columns("inventorymoving_descr").DefaultValue = ""
        tbl.Columns("inventorymoving_source").DefaultValue = ""
        tbl.Columns("inventorymoving_createby").DefaultValue = ""
        tbl.Columns("inventorymoving_createdate").DefaultValue = Now()
        tbl.Columns("inventorymoving_modifyby").DefaultValue = ""
        tbl.Columns("inventorymoving_modifydate").DefaultValue = DBNull.Value
        tbl.Columns("inventorymoving_sendby").DefaultValue = ""
        tbl.Columns("inventorymoving_senddate").DefaultValue = DBNull.Value
        tbl.Columns("inventorymoving_receiveby").DefaultValue = ""
        tbl.Columns("inventorymoving_receivedate").DefaultValue = DBNull.Value
        tbl.Columns("inventorymoving_postby").DefaultValue = ""
        tbl.Columns("inventorymoving_postdate").DefaultValue = DBNull.Value
        tbl.Columns("inventorymoving_isproposed").DefaultValue = False
        tbl.Columns("inventorymoving_issent").DefaultValue = False
        tbl.Columns("inventorymoving_isreceived").DefaultValue = False
        tbl.Columns("inventorymoving_isposted").DefaultValue = False
        tbl.Columns("inventorymoving_valuesent").DefaultValue = 0
        tbl.Columns("inventorymoving_valuereceived").DefaultValue = 0
        tbl.Columns("inventorymoving_valuelost").DefaultValue = 0
        tbl.Columns("inventorymoving_totalproposed").DefaultValue = 0
        tbl.Columns("inventorymoving_totalsent").DefaultValue = 0
        tbl.Columns("inventorymoving_totalreceived").DefaultValue = 0
        tbl.Columns("inventorymoving_totalbalance").DefaultValue = 0
        tbl.Columns("inventorymovingtype_id").DefaultValue = "AJ"
        tbl.Columns("region_id").DefaultValue = "0"
        tbl.Columns("branch_id_from").DefaultValue = "0"
        tbl.Columns("branch_id_to").DefaultValue = "0"
        tbl.Columns("iteminventorytype_id").DefaultValue = "INV"
        tbl.Columns("iteminventorysubtype_id").DefaultValue = "INVMCH"
        tbl.Columns("rekanan_id").DefaultValue = "0"
        tbl.Columns("transaction_id").DefaultValue = "0"
        tbl.Columns("channel_id").DefaultValue = "MGP"
        tbl.Columns("ref_id").DefaultValue = "0"
        tbl.Columns("rowid").DefaultValue = "0"

        tbl.PrimaryKey = New System.Data.DataColumn() {tbl.Columns("inventorymoving_id")}

        Return tbl
    End Function

    Public Shared Function CreateDatasetDetilItem() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("inventorymoving_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inventorymovingdetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("inventorymovingdetil_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inventorymovingdetil_qtypropose", GetType(Long)))
        tbl.Columns.Add(New DataColumn("inventorymovingdetil_qtyinit", GetType(Long)))
        tbl.Columns.Add(New DataColumn("inventorymovingdetil_qty", GetType(Long)))
        tbl.Columns.Add(New DataColumn("inventorymovingdetil_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("inventorymovingdetil_idrsubtotal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("inventorymovingdetil_article", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inventorymovingdetil_mat", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inventorymovingdetil_col", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inventorymovingdetil_size", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("iteminventoryunit_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("iteminventory_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ref_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ref_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("rowid", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("inventorymoving_id").DefaultValue = ""
        tbl.Columns("inventorymovingdetil_line").DefaultValue = 0
        tbl.Columns("inventorymovingdetil_descr").DefaultValue = ""
        tbl.Columns("inventorymovingdetil_qtypropose").DefaultValue = 0
        tbl.Columns("inventorymovingdetil_qtyinit").DefaultValue = 0
        tbl.Columns("inventorymovingdetil_qty").DefaultValue = 0
        tbl.Columns("inventorymovingdetil_idr").DefaultValue = 0
        tbl.Columns("inventorymovingdetil_idrsubtotal").DefaultValue = 0
        tbl.Columns("inventorymovingdetil_article").DefaultValue = ""
        tbl.Columns("inventorymovingdetil_mat").DefaultValue = ""
        tbl.Columns("inventorymovingdetil_col").DefaultValue = ""
        tbl.Columns("inventorymovingdetil_size").DefaultValue = ""
        tbl.Columns("iteminventoryunit_id").DefaultValue = ""
        tbl.Columns("iteminventory_id").DefaultValue = ""
        tbl.Columns("ref_id").DefaultValue = ""
        tbl.Columns("ref_line").DefaultValue = 0
        tbl.Columns("rowid").DefaultValue = ""

        '--------------------------------
        ' Behaviours
        tbl.PrimaryKey = New System.Data.DataColumn() {tbl.Columns("inventorymoving_id"), tbl.Columns("inventorymovingdetil_line")}
        With tbl.Columns("inventorymovingdetil_line")
            .DefaultValue = DBNull.Value
            .AutoIncrement = True
            .AutoIncrementSeed = 10
            .AutoIncrementStep = 10
        End With

        Return tbl
    End Function

    Public Shared Function CreateDatasetDetilException() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("inventorymoving_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inventorymovingdetilex_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("inventorymovingdetilex_factorycode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inventorymovingdetilex_article", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rowid", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("inventorymoving_id").DefaultValue = ""
        tbl.Columns("inventorymovingdetilex_line").DefaultValue = 0
        tbl.Columns("inventorymovingdetilex_factorycode").DefaultValue = ""
        tbl.Columns("inventorymovingdetilex_article").DefaultValue = ""
        tbl.Columns("rowid").DefaultValue = ""


        '--------------------------------
        ' Behaviours
        tbl.PrimaryKey = New System.Data.DataColumn() {tbl.Columns("inventorymoving_id"), tbl.Columns("inventorymovingdetilex_line")}
        With tbl.Columns("inventorymovingdetilex_line")
            .DefaultValue = DBNull.Value
            .AutoIncrement = True
            .AutoIncrementSeed = 10
            .AutoIncrementStep = 10
        End With


        Return tbl
    End Function

    Public Shared Function CreateDatasetProp() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("prop_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("prop_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("prop_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("prop_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("prop_value", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rowid", GetType(System.String)))



        '-------------------------------
        'Default Value: 
        tbl.Columns("prop_id").DefaultValue = ""
        tbl.Columns("prop_line").DefaultValue = 0
        tbl.Columns("prop_name").DefaultValue = ""
        tbl.Columns("prop_descr").DefaultValue = ""
        tbl.Columns("prop_value").DefaultValue = ""
        tbl.Columns("rowid").DefaultValue = ""

        '--------------------------------
        ' Behaviours
        tbl.PrimaryKey = New System.Data.DataColumn() {tbl.Columns("prop_id"), tbl.Columns("prop_line")}
        With tbl.Columns("prop_line")
            .DefaultValue = DBNull.Value
            .AutoIncrement = True
            .AutoIncrementSeed = 10
            .AutoIncrementStep = 10
        End With


        Return tbl
    End Function

    Public Shared Function CreateDatasetLog() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("log_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("log_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("log_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("log_action", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("log_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("log_table", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("log_lastvalue", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("log_username", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rowid", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("log_id").DefaultValue = ""
        tbl.Columns("log_line").DefaultValue = 0
        tbl.Columns("log_date").DefaultValue = Now()
        tbl.Columns("log_action").DefaultValue = ""
        tbl.Columns("log_descr").DefaultValue = ""
        tbl.Columns("log_table").DefaultValue = ""
        tbl.Columns("log_lastvalue").DefaultValue = ""
        tbl.Columns("log_username").DefaultValue = ""
        tbl.Columns("rowid").DefaultValue = ""

        '--------------------------------
        ' Behaviours
        tbl.PrimaryKey = New System.Data.DataColumn() {tbl.Columns("log_id"), tbl.Columns("log_line")}
        With tbl.Columns("log_line")
            .DefaultValue = DBNull.Value
            .AutoIncrement = True
            .AutoIncrementSeed = 10
            .AutoIncrementStep = 10
        End With

        Return tbl
    End Function

#End Region

#Region " Layout & Init UI "

    Private Function LayoutUI() As Boolean
        Me.AnchorAll(New Object() { _
            Me.ftabMain, _
            Me.ftabDataDetil, _
            Me.DgvItem, _
            Me.DgvException, _
            Me.DgvProp, _
            Me.DgvLog _
        })

        Me.PnlDfMain.Dock = DockStyle.Fill
        Me.ftabMain_SelectedIndexChanged(Me.ftabMain, New System.EventArgs)

        FormatDgvList(Me.DgvList)
        FormatDgvDetilItem(Me.DgvItem)
        FormatDgvDetilException(Me.DgvException)
        FormatDgvProp(Me.DgvProp)
        FormatDgvLog(Me.DgvLog)

        Me.ToolStrip1.Enabled = True
        Me.ToolStrip1.Visible = True

    End Function

    Public Shared Function FormatDgvList(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvMstIteminventory Columns 
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
         { _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "inventorymoving_id", "ID", "inventorymoving_id", 210), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "inventorymoving_date", "Date", "inventorymoving_date", 90), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "inventorymoving_descr", "Descr", "inventorymoving_descr", 250), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "customer_address", "Adress", "customer_address", 250), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewCheckBoxColumn, "inventorymoving_isproposed", "Prop", "inventorymoving_isproposed", 30), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewCheckBoxColumn, "inventorymoving_issent", "Sent", "inventorymoving_issent", 30), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewCheckBoxColumn, "inventorymoving_isreceived", "Recv", "inventorymoving_isreceived", 30), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewCheckBoxColumn, "inventorymoving_isposted", "Post", "inventorymoving_isposted", 30), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "region_id_source", "RegionSource", "region_id_source", 100) _
         })


        ' DgvMstIteminventory Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.AutoGenerateColumns = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Function

    Public Shared Function FormatDgvDetilItem(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
         { _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "inventorymovingdetil_line", "Line", "inventorymovingdetil_line", 50, DataGridViewContentAlignment.MiddleRight, True), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "inventorymovingdetil_descr", "Descr", "inventorymovingdetil_descr", 250, DataGridViewContentAlignment.MiddleLeft, True, Color.LightYellow), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "iteminventory_id", "ItemID", "iteminventory_id", 100, DataGridViewContentAlignment.MiddleCenter, True, Color.LightYellow), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "iteminventoryunit_id", "Unit", "iteminventoryunit_id", 60, DataGridViewContentAlignment.MiddleCenter, True, Color.LightYellow), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "inventorymovingdetil_qtypropose", "Qty" & vbCrLf & "Prop", "inventorymovingdetil_qtypropose", 40, DataGridViewContentAlignment.MiddleRight, True, Color.LightYellow), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "inventorymovingdetil_qtyinit", "Qty" & vbCrLf & "Init", "inventorymovingdetil_qtyinit", 40, DataGridViewContentAlignment.MiddleRight, True, Color.LightYellow), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "inventorymovingdetil_qty", "Qty" & vbCrLf & "Actl", "inventorymovingdetil_qty", 40, DataGridViewContentAlignment.MiddleRight, True, Color.LightYellow), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "inventorymovingdetil_idr", "Value" & vbCrLf & "(IDR)", "inventorymovingdetil_idr", 130, DataGridViewContentAlignment.MiddleRight, True, Color.LightYellow), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "inventorymovingdetil_idrsubtotal", "Sub Total" & vbCrLf & "(IDR)", "inventorymovingdetil_idrsubtotal", 130, DataGridViewContentAlignment.MiddleRight, True, Color.Gainsboro), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "inventorymovingdetil_article", "ART", "inventorymovingdetil_article", 180, DataGridViewContentAlignment.MiddleCenter, True, Color.LightYellow), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "inventorymovingdetil_mat", "MAT", "inventorymovingdetil_mat", 70, DataGridViewContentAlignment.MiddleCenter, True, Color.LightYellow), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "inventorymovingdetil_col", "COL", "inventorymovingdetil_col", 70, DataGridViewContentAlignment.MiddleCenter, True, Color.LightYellow), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "inventorymovingdetil_size", "SIZE", "inventorymovingdetil_size", 70, DataGridViewContentAlignment.MiddleCenter, True, Color.LightYellow) _
         })

        With objDgv.Columns("inventorymovingdetil_line")
            .DefaultCellStyle.Padding = New Padding(0, 0, 5, 0)
        End With

        With objDgv.Columns("inventorymovingdetil_qtypropose")
            .DefaultCellStyle.Format = "#,##0"
        End With

        With objDgv.Columns("inventorymovingdetil_qtyinit")
            .DefaultCellStyle.Format = "#,##0"
        End With

        With objDgv.Columns("inventorymovingdetil_qty")
            .DefaultCellStyle.Format = "#,##0"
        End With

        With objDgv.Columns("inventorymovingdetil_idr")
            .DefaultCellStyle.Format = "#,##0.00"
        End With

        With objDgv.Columns("inventorymovingdetil_idrsubtotal")
            .DefaultCellStyle.Format = "#,##0.00"
        End With



        ' DgvMstIteminventory Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AutoGenerateColumns = False
    End Function

    Public Shared Function FormatDgvDetilException(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
         { _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "inventorymovingdetilex_line", "Line", "inventorymovingdetilex_line", 50), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "inventorymovingdetilex_factorycode", "FactoryCode", "inventorymovingdetilex_factorycode", 150), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "inventorymovingdetilex_article", "Article", "inventorymovingdetilex_article", 150) _
         })

        With objDgv.Columns("inventorymovingdetilex_line")
            .DefaultCellStyle.BackColor = Color.Gainsboro
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Padding = New Padding(0, 0, 5, 0)
            .ReadOnly = True
        End With

        ' DgvMstIteminventory Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AutoGenerateColumns = False
    End Function

    Public Shared Function FormatDgvProp(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
         { _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "prop_line", "Line", "prop_line", 50), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "prop_name", "Property", "prop_name", 150), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "prop_value", "Value", "prop_value", 100), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "prop_descr", "Descr", "prop_descr", 200) _
         })

        With objDgv.Columns("prop_line")
            .DefaultCellStyle.BackColor = Color.Gainsboro
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Padding = New Padding(0, 0, 5, 0)
            .ReadOnly = True
        End With

        ' DgvMstIteminventory Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AutoGenerateColumns = False
    End Function

    Public Shared Function FormatDgvLog(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
         { _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "log_line", "Line", "log_line", 50), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "log_date", "Date", "log_date", 100), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "log_action", "Action", "log_action", 150), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "log_descr", "Descr", "log_descr", 200), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "log_table", "Table", "log_table", 100), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "log_lastvalue", "LastValue", "log_lastvalue", 200), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "log_username", "Username", "log_username", 100) _
         })


        ' DgvMstIteminventory Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AutoGenerateColumns = False
        objDgv.DefaultCellStyle.BackColor = Color.Gainsboro
    End Function

    Public Overrides Function BindingStop() As Boolean
        Me.obj_inventorymoving_id.DataBindings.Clear()
        Me.obj_inventorymoving_date.DataBindings.Clear()
        Me.obj_inventorymoving_descr.DataBindings.Clear()
        Me.obj_inventorymoving_source.DataBindings.Clear()
        Me.obj_inventorymoving_createby.DataBindings.Clear()
        Me.obj_inventorymoving_createdate.DataBindings.Clear()
        Me.obj_inventorymoving_modifyby.DataBindings.Clear()
        Me.obj_inventorymoving_modifydate.DataBindings.Clear()
        Me.obj_inventorymoving_sendby.DataBindings.Clear()
        Me.obj_inventorymoving_senddate.DataBindings.Clear()
        Me.obj_inventorymoving_receiveby.DataBindings.Clear()
        Me.obj_inventorymoving_receivedate.DataBindings.Clear()
        Me.obj_inventorymoving_postby.DataBindings.Clear()
        Me.obj_inventorymoving_postdate.DataBindings.Clear()
        Me.obj_inventorymoving_isproposed.DataBindings.Clear()
        Me.obj_inventorymoving_issent.DataBindings.Clear()
        Me.obj_inventorymoving_isreceived.DataBindings.Clear()
        Me.obj_inventorymoving_isposted.DataBindings.Clear()
        Me.obj_inventorymoving_valuesent.DataBindings.Clear()
        Me.obj_inventorymoving_valuereceived.DataBindings.Clear()
        Me.obj_inventorymoving_valuelost.DataBindings.Clear()
        Me.obj_inventorymoving_totalproposed.DataBindings.Clear()
        Me.obj_inventorymoving_totalsent.DataBindings.Clear()
        Me.obj_inventorymoving_totalreceived.DataBindings.Clear()
        Me.obj_inventorymoving_totalbalance.DataBindings.Clear()
        Me.obj_inventorymovingtype_id.DataBindings.Clear()
        Me.obj_region_id.DataBindings.Clear()
        Me.obj_branch_id.DataBindings.Clear()
        Me.obj_iteminventorytype_id.DataBindings.Clear()
        Me.obj_iteminventorysubtype_id.DataBindings.Clear()
        Me.obj_transaction_id.DataBindings.Clear()
        Me.obj_channel_id.DataBindings.Clear()
        Me.obj_rowid.DataBindings.Clear()
        Me.FORMBINDED = False
    End Function

    Public Overrides Function BindingStart() As Boolean
        If Not Me.FORMBINDED Then
            Me.obj_inventorymoving_id.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_id"))
            Me.obj_inventorymoving_date.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_date"))
            Me.obj_inventorymoving_descr.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_descr"))
            Me.obj_inventorymoving_source.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_source"))
            Me.obj_inventorymoving_createby.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_createby"))
            Me.obj_inventorymoving_createdate.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_createdate"))
            Me.obj_inventorymoving_modifyby.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_modifyby"))
            Me.obj_inventorymoving_modifydate.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_modifydate"))
            Me.obj_inventorymoving_sendby.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_sendby"))
            Me.obj_inventorymoving_senddate.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_senddate"))
            Me.obj_inventorymoving_receiveby.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_receiveby"))
            Me.obj_inventorymoving_receivedate.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_receivedate"))
            Me.obj_inventorymoving_postby.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_postby"))
            Me.obj_inventorymoving_postdate.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_postdate"))
            Me.obj_inventorymoving_isproposed.DataBindings.Add(New Binding("Checked", Me.tblList_Temp, "inventorymoving_isproposed"))
            Me.obj_inventorymoving_issent.DataBindings.Add(New Binding("Checked", Me.tblList_Temp, "inventorymoving_issent"))
            Me.obj_inventorymoving_isreceived.DataBindings.Add(New Binding("Checked", Me.tblList_Temp, "inventorymoving_isreceived"))
            Me.obj_inventorymoving_isposted.DataBindings.Add(New Binding("Checked", Me.tblList_Temp, "inventorymoving_isposted"))
            Me.obj_inventorymoving_valuesent.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_valuesent", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
            Me.obj_inventorymoving_valuereceived.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_valuereceived", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
            Me.obj_inventorymoving_valuelost.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_valuelost", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
            Me.obj_inventorymoving_totalproposed.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_totalproposed", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
            Me.obj_inventorymoving_totalsent.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_totalsent", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
            Me.obj_inventorymoving_totalreceived.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_totalreceived", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
            Me.obj_inventorymoving_totalbalance.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymoving_totalbalance", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
            Me.obj_inventorymovingtype_id.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "inventorymovingtype_id"))
            Me.obj_region_id.DataBindings.Add(New Binding("SelectedValue", Me.tblList_Temp, "region_id"))
            Me.obj_branch_id.DataBindings.Add(New Binding("SelectedValue", Me.tblList_Temp, "branch_id_from"))
            Me.obj_iteminventorytype_id.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "iteminventorytype_id"))
            Me.obj_iteminventorysubtype_id.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "iteminventorysubtype_id"))
            Me.obj_transaction_id.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "transaction_id"))
            Me.obj_channel_id.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "channel_id"))
            Me.obj_rowid.DataBindings.Add(New Binding("Text", Me.tblList_Temp, "rowid"))
            Me.FORMBINDED = True
        End If

    End Function

#End Region

#Region " Overrides Function "

    Public Overrides Function btnSave_Click() As Boolean
        Dim errMsg As String = ""

        Me.obj_inventorymoving_descr.Text = Me.obj_inventorymoving_descr.Text.Replace("""", "")
        Me.obj_inventorymoving_descr.Text = Me.obj_inventorymoving_descr.Text.Replace("'", "")
        Me.obj_inventorymoving_descr.Text = Trim(Me.obj_inventorymoving_descr.Text)

        Try

            If Me.obj_inventorymoving_descr.Text = "" Then
                errMsg = "Deskripsi belum diisi"
                Me.errProvider.SetError(Me.obj_inventorymoving_descr, errMsg)
                Throw New Exception(errMsg)
            ElseIf Me.obj_region_id.SelectedValue = "0" Then
                Me.errProvider.SetError(Me.obj_inventorymoving_descr, "")
                errMsg = "Region Belum diisi"
                Me.errProvider.SetError(Me.obj_region_id, errMsg)
                Throw New Exception(errMsg)
            ElseIf Me.obj_branch_id.SelectedValue = "0" Then
                Me.errProvider.SetError(Me.obj_region_id, "")
                errMsg = "Branch asal Belum diisi"
                Me.errProvider.SetError(Me.obj_branch_id, errMsg)
                Throw New Exception(errMsg)
            Else
                Me.errProvider.SetError(Me.obj_branch_id, "")
            End If

            Return MyBase.btnSave_Click()
        Catch ex As Exception
            MessageBox.Show(errMsg, Me.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Dim CriteriaBuilder As Translib.QueryCriteria = Me.BuildListCriteria()
        Dim Criteria As String = CriteriaBuilder.Serialize()

        Me.List_CurrentPageIndex = 1
        Me.tblList.Rows.Clear()
        Me.DgvList.DataSource = Nothing
        Me.bgwListLoader.RunWorkerAsync(New Object() {CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "gridlistload"), Criteria, Me.bnRowLimit.Text})
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function RefreshList(ByRef bn As System.Windows.Forms.BindingNavigator, ByVal obj As System.Windows.Forms.ToolStripItem) As Boolean
        Dim CriteriaBuilder As Translib.QueryCriteria = Me.BuildListCriteria()
        Dim Criteria As String = CriteriaBuilder.Serialize()

        If Me.BindingNavigator_Click(bn, obj) Then
            Me.tblList.Rows.Clear()
            Me.DgvList.DataSource = Nothing
            Me.bgwListLoader.RunWorkerAsync(New Object() {CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "gridlistload"), Criteria, Me.bnRowLimit.Text})
        End If
    End Function

#End Region

#Region " User Defined Function "

    Public Overridable Function BuildListCriteria() As Translib.QueryCriteria
        Dim CriteriaBuilder As Translib.QueryCriteria = New Translib.QueryCriteria()

        ' Default Criteria
        CriteriaBuilder.AddCriteria(Me.obj_search_chk_channel_id.Name, Me.obj_search_chk_channel_id.Checked, Me.obj_search_txt_channel_id.Text)
        CriteriaBuilder.AddCriteria(Me.obj_search_chk_inventorymovingtype_id.Name, Me.obj_search_chk_inventorymovingtype_id.Checked, Me.obj_search_txt_inventorymovingtype_id.Text)
        CriteriaBuilder.AddCriteria(Me.obj_search_chk_iteminventorytype_id.Name, Me.obj_search_chk_iteminventorytype_id.Checked, Me.obj_search_txt_iteminventorytype_id.Text)
        CriteriaBuilder.AddCriteria(Me.obj_search_chk_iteminventorysubtype_id.Name, Me.obj_search_chk_iteminventorysubtype_id.Checked, Me.obj_search_txt_iteminventorysubtype_id.Text)


        ' User Criteria
        CriteriaBuilder.AddCriteria(Me.obj_search_chk_inventorymoving_id.Name, Me.obj_search_chk_inventorymoving_id.Checked, Me.obj_search_txt_inventorymoving_id.Text)
        CriteriaBuilder.AddCriteria(Me.obj_search_chk_inventorymoving_descr.Name, Me.obj_search_chk_inventorymoving_descr.Checked, Me.obj_search_txt_inventorymoving_descr.Text)
        CriteriaBuilder.AddCriteria(Me.obj_search_chk_inventorymoving_datestart.Name, Me.obj_search_chk_inventorymoving_datestart.Checked, Me.obj_search_dtp_inventorymoving_datestart.Text)
        CriteriaBuilder.AddCriteria(Me.obj_search_chk_inventorymoving_dateend.Name, Me.obj_search_chk_inventorymoving_dateend.Checked, Me.obj_search_dtp_inventorymoving_dateend.Text)
        CriteriaBuilder.AddCriteria(Me.obj_search_chk_region_id.Name, Me.obj_search_chk_region_id.Checked, Me.obj_search_cbo_region_id.SelectedValue)
        CriteriaBuilder.AddCriteria(Me.obj_search_chk_branch_id.Name, Me.obj_search_chk_branch_id.Checked, Me.obj_search_cbo_branch_id_from.SelectedValue)


        Return CriteriaBuilder
    End Function

    Public Overridable Function SetFormEnable(ByVal [enable] As Boolean) As Boolean
        Me.tbtnSave.Enabled = [enable]
        Me.tbtnDel.Enabled = [enable]
        Me.tbtnRowAdd.Enabled = [enable]
        Me.tbtnRowDel.Enabled = [enable]
        Me.ddBinding.Tables("DetilItem").SetAllowAddOrDeleteRows([enable])
    End Function

#End Region

#Region " Default Event "

    Private Sub bnList_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles bnList.ItemClicked
        Me.RefreshList(sender, e.ClickedItem)
    End Sub

    Private Sub ftabMain_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles ftabMain.Selecting
        If e.TabPage.Name = "ftabMain_Data" Then
            If Me.DgvList.CurrentRow Is Nothing Then
                If Not Me.IsNew Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
            If Not Me.IsNew Then
                MyBase.TabMain_OpenData(Me.DgvList, Me.tblList.PrimaryKey(0).ColumnName, CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "open"))
            End If
            If Me.BackgroundworkerStatus = EBackgroundworkerStatus.Fail Then
                e.Cancel = True
            End If
        Else
            Dim res As System.Windows.Forms.DialogResult
            Dim id As String = Me.GetActiveDocumentIDValue()
            If Me.DataIsChanged(Me.tblList_Temp, Me.ddBinding) Then
                res = System.Windows.Forms.MessageBox.Show("Data in document " & id & " has changed." & vbCrLf & vbCrLf & "Do you want to save the changes ?", Me.Title, System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Warning)
                Select Case res
                    Case System.Windows.Forms.DialogResult.Yes
                    Case System.Windows.Forms.DialogResult.No
                        Me.CancelAllData()
                    Case System.Windows.Forms.DialogResult.Cancel
                        e.Cancel = True
                End Select
            End If
            Me.IsNew = False
        End If
    End Sub

    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged
        Dim tab As FlatTabControl.FlatTabControl = CType(sender, FlatTabControl.FlatTabControl)
        MyBase.TabMain_SetSelected(tab)
    End Sub

    Private Sub ftabDataDetil_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabDataDetil.SelectedIndexChanged
        Dim tab As FlatTabControl.FlatTabControl = CType(sender, FlatTabControl.FlatTabControl)
        MyBase.TabDetil_SetSelected(tab)
    End Sub


    Private Sub DgvList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvList.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvList.CurrentRow IsNot Nothing Then
            Me.ClearData()
            Me.BackgroundworkerSaveStatus = EBackgroundworkerStatus.Init
            Me.IsNew = False
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub

    Private Sub DgvList_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvList.RowHeaderMouseDoubleClick
        If Me.DgvList.CurrentRow IsNot Nothing Then
            Me.ClearData()
            Me.BackgroundworkerSaveStatus = EBackgroundworkerStatus.Init
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub

    Private Sub DgvList_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvList.RowEnter
        Me.Datawalk_SetButtonState(sender, e.RowIndex)
    End Sub

    Private Sub DgvDetil_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)

    End Sub

    Private Sub DgvList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvList.CellFormatting
        ' Me.DgvListFormat(sender, e)
    End Sub


#End Region

#Region " General Event "

    Private Sub ui_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.obj_search_txt_inventorymoving_descr.DataBindings.Add(New Binding("Enabled", Me.obj_search_chk_inventorymoving_descr, "Checked"))
        Me.obj_search_txt_inventorymoving_id.DataBindings.Add(New Binding("Enabled", Me.obj_search_chk_inventorymoving_id, "Checked"))

        Me.obj_search_dtp_inventorymoving_datestart.DataBindings.Add(New Binding("Enabled", Me.obj_search_chk_inventorymoving_datestart, "Checked"))
        Me.obj_search_chk_inventorymoving_dateend.DataBindings.Add(New Binding("Enabled", Me.obj_search_chk_inventorymoving_datestart, "Checked"))
        Me.obj_search_dtp_inventorymoving_dateend.DataBindings.Add(New Binding("Enabled", Me.obj_search_chk_inventorymoving_dateend, "Checked"))

        Me.obj_search_cbo_region_id.DataBindings.Add(New Binding("Enabled", Me.obj_search_chk_region_id, "Checked"))
        'Me.obj_search_chk_branch_id_from.DataBindings.Add(New Binding("Enabled", Me.obj_search_chk_region_id, "Checked"))
        'Me.obj_search_chk_branch_id_to.DataBindings.Add(New Binding("Enabled", Me.obj_search_chk_region_id, "Checked"))
        Me.obj_search_cbo_branch_id_from.DataBindings.Add(New Binding("Enabled", Me.obj_search_chk_branch_id, "Checked"))



    End Sub

    Private Sub ui_FormMasterLoaderError(ByVal service As String, ByVal msg As String, ByVal request As String, ByVal respond As String) Handles Me.FormMasterLoaderError
        'MessageBox.Show(service & vbCrLf & msg & vbCrLf & request & vbCrLf & respond)
    End Sub

    Private Sub ui_FormMasterDataLoaded(ByVal status As Translib.uiBase.EBackgroundworkerStatus, ByVal message As String) Handles Me.FormMasterDataLoaded
        If status = EBackgroundworkerStatus.Fail Then
            MessageBox.Show(message, Me.Title, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
        Else
            Try
                Translib.uiBase.ComboLink(Me.obj_search_cbo_region_id, "region_id", "region_name", Me.dsMaster.Tables("master_region").Copy(), True, True)
                Translib.uiBase.ComboLink(Me.obj_search_cbo_branch_id_from, "branch_id", "branch_name", Me.dsMaster.Tables("master_branch").Copy(), True, False)
                Translib.uiBase.ComboLink(Me.obj_region_id, "region_id", "region_name", Me.dsMaster.Tables("master_region").Copy(), True, True)
                Translib.uiBase.ComboLink(Me.obj_branch_id, "branch_id", "branch_name", Me.dsMaster.Tables("master_branch").Copy(), True, False)
                'Me.btnLoad_Click()

                Me.obj_region_id.Enabled = False
                Me.obj_branch_id.Enabled = False
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ui_BackgroundworkerDataLoaderCompleted(ByRef tabMain As FlatTabControl.FlatTabControl, ByRef tabDetil As FlatTabControl.FlatTabControl, ByVal webrespond As String) Handles Me.BackgroundworkerDataLoaderCompleted
        Dim res As String = webrespond
    End Sub

    Private Sub ui_BackgroundworkerSaveCompleted(ByVal status As Translib.uiBase.EBackgroundworkerStatus, ByVal service As String, ByVal requestheader As String, ByVal webrespond As String) Handles Me.BackgroundworkerSaveCompleted
        Dim res As String = webrespond
    End Sub

    Private Sub ui_FormBeforeNew(ByRef result As Object, ByRef cancel As Boolean, ByRef args As Object) Handles Me.FormBeforeNew

    End Sub

    Private Sub ui_FormAfterNew(ByVal result As Object, ByVal args As Object) Handles Me.FormAfterNew
        Me.obj_inventorymoving_source.Text = Me._SOURCE.ToString
        Me.obj_inventorymoving_date.Enabled = True
        Me.obj_inventorymoving_descr.Enabled = True
        Me.obj_region_id.Enabled = True
        Me.obj_branch_id.Enabled = True

        Me.obj_region_id.SelectedValue = Me.obj_search_cbo_region_id.SelectedValue
        Me.obj_branch_id.SelectedValue = Me.obj_search_cbo_branch_id_from.SelectedValue

    End Sub

    Private Sub ui_FormRowAdding(ByVal tabname As String, ByVal table As System.Data.DataTable, ByRef dialogname As String, ByRef cancel As Boolean, ByRef args As Object) Handles Me.FormRowAdding
        Me.ui_FormRowEditing(tabname, table, dialogname, cancel, args)
    End Sub

    Private Sub ui_FormSaved(ByRef id As Object, ByVal respond As String, ByVal result As Translib.uiBase.EFormSaveResult, ByVal obj As Object, ByVal supressmessage As Boolean) Handles Me.FormSaved
        If Not supressmessage Then
            If result = EFormSaveResult.SaveSuccess Then
                MessageBox.Show("Data Saved", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub ui_FormRowEditing(ByVal tabname As String, ByVal table As System.Data.DataTable, ByRef dialogname As String, ByRef cancel As Boolean, ByRef args As Object) Handles Me.FormRowEditing
        Select Case tabname
            Case "ftabDataDetil_Item"
                args = New Object() {Me._SOURCE, Me.tbtnSave.Enabled, Me.obj_inventorymoving_source.Text}
                dialogname = "INV05AJ.dlgTrnInventorymovingDetilItemNewrow"
        End Select
    End Sub

    Private Sub ui_FormRowDeleting(ByVal tabname As String, ByVal row As System.Windows.Forms.DataGridViewRow, ByRef confirm As Boolean, ByRef msg As String, ByRef cancel As String, ByRef args As Object) Handles Me.FormRowDeleting

    End Sub

    Private Sub ui_FormRowModified(ByVal tabname As String) Handles Me.FormRowModified
        'Recalculate
        Select Case tabname
            Case "ftabDataDetil_Item"
                Dim i As Integer
                Dim qtypropose, qtytotalpropose As Decimal
                Dim qtysent, qtyreceived, qtytotalsent, qtytotalreceived As Decimal
                Dim idr, idrsubtotalsent, idrtotalsent, idrsubtotalreceived, idrtotalreceived As Decimal
                Dim adaselilih As Boolean = False
                qtytotalreceived = 0
                For i = 0 To Me.DgvItem.Rows.Count - 1
                    qtypropose = Me.DgvItem.Rows(i).Cells("inventorymovingdetil_qtypropose").Value
                    qtysent = Me.DgvItem.Rows(i).Cells("inventorymovingdetil_qtyinit").Value
                    qtyreceived = Me.DgvItem.Rows(i).Cells("inventorymovingdetil_qty").Value
                    qtytotalpropose = qtytotalpropose + qtypropose
                    qtytotalsent = qtytotalsent + qtysent
                    qtytotalreceived = qtytotalreceived + qtyreceived

                    idr = Me.DgvItem.Rows(i).Cells("inventorymovingdetil_idr").Value
                    idrsubtotalsent = qtysent * idr
                    idrsubtotalreceived = qtyreceived * idr
                    idrtotalsent += idrsubtotalsent
                    idrtotalreceived += idrsubtotalreceived

                    If qtysent <> qtyreceived Then
                        adaselilih = True
                    End If
                Next

                Me.obj_inventorymoving_valuesent.Text = String.Format("{0:" & Me.DgvItem.Columns("inventorymovingdetil_idr").DefaultCellStyle.Format & "}", idrtotalsent)
                Me.obj_inventorymoving_valuereceived.Text = String.Format("{0:" & Me.DgvItem.Columns("inventorymovingdetil_idr").DefaultCellStyle.Format & "}", idrtotalreceived)
                Me.obj_inventorymoving_valuelost.Text = String.Format("{0:" & Me.DgvItem.Columns("inventorymovingdetil_idr").DefaultCellStyle.Format & "}", Math.Abs(idrtotalsent - idrtotalreceived))

                Me.obj_inventorymoving_totalproposed.Text = String.Format("{0:" & Me.DgvItem.Columns("inventorymovingdetil_qtyinit").DefaultCellStyle.Format & "}", qtytotalpropose)
                Me.obj_inventorymoving_totalsent.Text = String.Format("{0:" & Me.DgvItem.Columns("inventorymovingdetil_qtyinit").DefaultCellStyle.Format & "}", qtytotalsent)
                Me.obj_inventorymoving_totalreceived.Text = String.Format("{0:" & Me.DgvItem.Columns("inventorymovingdetil_qtyinit").DefaultCellStyle.Format & "}", qtytotalreceived)
                Me.obj_inventorymoving_totalbalance.Text = String.Format("{0:" & Me.DgvItem.Columns("inventorymovingdetil_qtyinit").DefaultCellStyle.Format & "}", Math.Abs(qtytotalsent - qtytotalreceived))

                If adaselilih Then
                    Me.obj_inventorymoving_totalbalance.BackColor = Color.LightCoral
                    Me.obj_inventorymoving_valuelost.BackColor = Color.LightCoral
                Else
                    Me.obj_inventorymoving_totalbalance.BackColor = Color.PaleGreen
                    Me.obj_inventorymoving_valuelost.BackColor = Color.PaleGreen
                End If

        End Select


    End Sub

    Private Sub ui_FormDataOpening(ByRef id As Object) Handles Me.FormDataOpening
        Me.BindingStop()
        Me.tblList_Temp.Clear()
        Me.ConstructTableDetil()
    End Sub

    Private Sub ui_FormDataOpened(ByVal id As Object) Handles Me.FormDataOpened
        ' MessageBox.Show(id)
        'If Me.obj_inventorymoving_isproposed.Checked Then
        '    Me.tbtnSave.Enabled = False
        '    Me.tbtnDel.Enabled = False
        'Else
        '    Me.tbtnSave.Enabled = True
        '    If uiTrnInventorymovingTR._SOURCE = SourceType.TR_Propose Or uiTrnInventorymovingTR._SOURCE = SourceType.TR_Manual Then
        '        Me.tbtnDel.Enabled = True
        '    Else
        '        Me.tbtnDel.Enabled = False
        '    End If
        'End If

        'Me.tbtnSave.Enabled = False
        'Me.tbtnDel.Enabled = False

        'Select Case uiTrnInventorymovingTR._SOURCE
        '    Case SourceType.TR_Propose
        '        If Not Me.obj_inventorymoving_isproposed.Checked Then
        '            Me.tbtnSave.Enabled = True
        '            Me.tbtnDel.Enabled = True
        '        End If
        '    Case SourceType.TR_Send
        '        If Not Me.obj_inventorymoving_issent.Checked Then
        '            Me.tbtnSave.Enabled = True
        '        End If
        '    Case SourceType.TR_Receive
        '        If Not Me.obj_inventorymoving_isreceived.Checked Then
        '            Me.tbtnSave.Enabled = True
        '        End If
        '    Case SourceType.TR_Post
        '    Case SourceType.TR_Unpost
        '    Case SourceType.TR_Manual
        '        Me.tbtnSave.Enabled = True
        '        Me.tbtnDel.Enabled = True
        'End Select

    End Sub

    Private Sub ui_FormPrintPreviewExecuting(ByRef cancel As Boolean, ByRef args As Object, ByRef ids As Object, ByRef reportparams() As Microsoft.Reporting.WinForms.ReportParameter, ByRef dllfile As String, ByRef rdlcobjectname As String, ByRef webpage As String, ByRef customprinting As Boolean, ByRef customprintingclass As String) Handles Me.FormPrintPreviewExecuting
        Dim param1 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("PARAM_00", "PARAM 00 VALUE")

        reportparams = New Microsoft.Reporting.WinForms.ReportParameter() _
                            {param1}

        args = New Object() {"agung"}

        'Disini digunakan untuk mengatur setting tampilan report
        'mengarahkan dllfile dan object name nya
        'pop up untuk pilihan2 lain
        'atau mengirimkan args untuk di hack di funcsi PrintingCustom.Print
        'misalnya untuk mencetak di dot matrik

    End Sub

    Private Sub ui_FormTabdetilSelected(ByVal tabname As String) Handles Me.FormTabdetilSelected

    End Sub

#End Region



    Private Sub obj_search_cbo_region_id_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_search_cbo_region_id.SelectedIndexChanged
        If Me.MASTERLOADED Then
            Dim id As String
            Dim cbo As ComboBox = sender
            Try
                If cbo.SelectedValue IsNot Nothing Then
                    id = cbo.SelectedValue.ToString
                    If id <> "System.Data.DataRowView" And id <> "0" Then
                        Me.obj_search_cbo_branch_id_from.SelectedValue = "0"
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub obj_search_chk_region_id_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_search_chk_region_id.CheckedChanged
        Dim obj As CheckBox = CType(sender, CheckBox)
        If Not obj.Checked Then
            Me.obj_search_chk_branch_id.Checked = False
        End If
    End Sub


    Private Sub DgvItem_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvItem.CellMouseDoubleClick
        If e.ColumnIndex = -1 Or e.ColumnIndex = 1 Or e.ColumnIndex = 2 _
                  And e.RowIndex >= 0 _
                  Then
            btnRowEdit_Click()
        End If
    End Sub




End Class
