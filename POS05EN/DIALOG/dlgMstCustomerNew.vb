Public Class dlgMstCustomerNew



#Region " Constructor "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.ds.Tables.Add(Me.CreateDatasetList("region"))

        Me.LayoutUI()

    End Sub

#End Region

#Region " Dataset "

    Public Function CreateDatasetList(ByVal tablename As String) As DataTable
        Dim tbl As DataTable = New DataTable
        tbl = uiTrnInventorymovingTR.CreateDatasetDetilRegion()
        tbl.TableName = tablename
        Return tbl
    End Function



#End Region

#Region " Layout & Init UI "
    Private Function LayoutUI() As Boolean
        Me.FormatDgvRegion(Me.DgvRegion)
    End Function

    Private Function FormatDgvRegion(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        uiTrnInventorymovingTR.FormatDgvDetilRegion(objDgv)
    End Function

#End Region






    Private Sub dlgMstCustomer_DialogOKClick(ByRef retObj As Object, ByRef cancel As Boolean) Handles Me.DialogOKClick
        Dim customertype_id As String = "C"

        If Me.rdbPersonal.Checked Then
            customertype_id = "P"
        End If
        retObj = New Object() {customertype_id, Me.ds.Tables("region")}

    End Sub

    Private Sub dlgMstCustomer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim service As String
        service = Translib.uiBase.CreateWebService("transbrowser", "uimaster", "load_region_byuser_login")
        Me.DataLoad(service, "", "region", "DgvRegion")

        Me.Text = "New Data - " & Me.Text
    End Sub
End Class
