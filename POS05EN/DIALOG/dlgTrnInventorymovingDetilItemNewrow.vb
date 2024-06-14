Public Class dlgTrnInventorymovingDetilItemNewrow

    Private tbl As DataTable = uiTrnInventorymovingAJ.CreateDatasetDetilItem()


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.obj_inventorymovingdetil_line.DataBindings.Add(New Binding("Text", Me.tbl, "inventorymovingdetil_line"))
        Me.obj_iteminventory_id.DataBindings.Add(New Binding("Text", Me.tbl, "iteminventory_id"))
        Me.obj_inventorymovingdetil_descr.DataBindings.Add(New Binding("Text", Me.tbl, "inventorymovingdetil_descr"))
        Me.obj_inventorymovingdetil_article.DataBindings.Add(New Binding("Text", Me.tbl, "inventorymovingdetil_article"))
        Me.obj_inventorymovingdetil_mat.DataBindings.Add(New Binding("Text", Me.tbl, "inventorymovingdetil_mat"))
        Me.obj_inventorymovingdetil_col.DataBindings.Add(New Binding("Text", Me.tbl, "inventorymovingdetil_col"))
        Me.obj_inventorymovingdetil_size.DataBindings.Add(New Binding("Text", Me.tbl, "inventorymovingdetil_size"))
        Me.obj_iteminventoryunit_id.DataBindings.Add(New Binding("Text", Me.tbl, "iteminventoryunit_id"))



        Me.obj_inventorymovingdetil_qtypropose.DataBindings.Add(New Binding("Text", Me.tbl, "inventorymovingdetil_qtypropose", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.obj_inventorymovingdetil_qtyinit.DataBindings.Add(New Binding("Text", Me.tbl, "inventorymovingdetil_qtyinit", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.obj_inventorymovingdetil_qty.DataBindings.Add(New Binding("Text", Me.tbl, "inventorymovingdetil_qty", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.obj_inventorymovingdetil_idr.DataBindings.Add(New Binding("Text", Me.tbl, "inventorymovingdetil_idr", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))

        Me.lbl_inventorymovingdetil_idr.DataBindings.Add(New Binding("Visible", Me.obj_inventorymovingdetil_idr, "Visible"))


    End Sub

    Private Sub dlg_DialogOKClick(ByRef retObj As Object, ByRef cancel As Boolean) Handles Me.DialogOKClick
        Dim tbl As DataTable = Me.Argument(0)
        Dim row As DataRow = Me.PrepareDatarow(tbl)
        'Dim i As Integer
        'Dim columnname As String

        Me.BindingContext(Me.tbl).EndCurrentEdit()
        Me.tbl.AcceptChanges()

        row = Me.tbl.Rows(0)

        If Me.obj_iteminventory_id.Text = "" Then
            cancel = True
            Exit Sub
        End If



        retObj = New Object() {row}
    End Sub

    Private Sub dlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim newrow As DataRow

        If Me.Argument(1) IsNot Nothing Then
            Me.Text = "Edit Row - " & Me.Text
            If Me.Argument(1).GetType Is GetType(DataGridViewRow) Then
                Dim dgvrow As DataGridViewRow = CType(Me.Argument(1), DataGridViewRow)
                Dim i As Integer
                Dim columnname As String

                newrow = tbl.NewRow()
                For i = 0 To dgvrow.DataGridView.Columns.Count - 1
                    columnname = dgvrow.DataGridView.Columns(i).Name
                    If Me.tbl.Columns.Contains(columnname) Then
                        If dgvrow.Cells(columnname).Value IsNot DBNull.Value Then
                            newrow(columnname) = dgvrow.Cells(columnname).Value
                        End If
                    End If

                Next
                Me.tbl.Rows.Add(newrow)
                Me.BindingContext(Me.tbl).EndCurrentEdit()
                Me.tbl.AcceptChanges()

            End If
        Else
            Me.Text = "Add New Row - " & Me.Text

            newrow = tbl.NewRow()
            Me.tbl.Rows.Add(newrow)
            Me.BindingContext(Me.tbl).EndCurrentEdit()
            Me.tbl.AcceptChanges()

        End If

        'If CBool(Me.Argument(3)) Then
        '    Me.tbtnSave.Enabled()
        'End If


        Dim source As uiTrnInventorymovingAJ.SourceType = CType(Me.Argument(2), uiTrnInventorymovingAJ.SourceType)
        Dim btnSaveEnabled = CBool(Me.Argument(3))
        Dim openeddatasource As String = CStr(Me.Argument(4))




    End Sub

   
    Private Sub btnOpenItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenItem.Click
        Dim result As Object
        Dim o As Translib.GeneralObject = New Translib.GeneralObject()
        Dim services As String = Translib.uiBase.CreateWebService(Me.WebserviceNSGlobal, Me.WebserviceObjectGlobal, "load_iteminventory_byregion")
        Dim criteria As Translib.QueryCriteria = New Translib.QueryCriteria()
        Dim dlg As Translib.dlgBaseMaster = Me.CreateDialog(o.GetType().Assembly.GetType("Translib.dlgBaseMaster", True, True), "Item Inventory")
        dlg.SetSelected("iteminventory_id", Me.obj_iteminventory_id.Text, "iteminventory_name", Me.obj_inventorymovingdetil_descr.Text)
        'dlg.Argument = New Object() {services, criteria, dgvcols}

        'tanpa format dgvcol
        dlg.Width = 850
        dlg.Argument = New Object() {services, criteria, Nothing}
        result = dlg.OpenDialog(Me, Me.WebserviceAddress, Me.DLLServer, Me.UserName, Me.SessionID)

        If result Is Nothing Then Exit Sub
        Dim crow As System.Windows.Forms.DataGridViewRow = result(2)

        Me.obj_iteminventory_id.Text = result(0)
        Me.obj_inventorymovingdetil_descr.Text = result(1)
        Me.obj_inventorymovingdetil_article.Text = crow.Cells("iteminventory_article").Value
        Me.obj_inventorymovingdetil_col.Text = crow.Cells("iteminventory_color").Value
        Me.obj_inventorymovingdetil_mat.Text = crow.Cells("iteminventory_material").Value
        Me.obj_inventorymovingdetil_size.Text = crow.Cells("iteminventory_size").Value


    End Sub


    Private Sub obj_inventorymovingdetil_qtypropose_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_inventorymovingdetil_qtypropose.Validated
        Me.obj_inventorymovingdetil_qtyinit.Text = obj_inventorymovingdetil_qtypropose.Text
        Me.obj_inventorymovingdetil_qty.Text = obj_inventorymovingdetil_qtypropose.Text
    End Sub

    Private Sub obj_inventorymovingdetil_qtyinit_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_inventorymovingdetil_qtyinit.Validated
        Me.obj_inventorymovingdetil_qty.Text = obj_inventorymovingdetil_qtyinit.Text

        'Select Case CType(Me.Argument(2), uiTrnInventorymovingTR.SourceType)
        '    Case uiTrnInventorymovingTR.SourceType.TR_Send
        '    Case Else


        'End Select
    End Sub


End Class
