Imports System.ComponentModel

Public Class dlgCustomerSearch

    Private WithEvents bgwSearch As BackgroundWorker


#Region " Custructor "

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


#End Region

#Region " Properties"

    Private mPOS As TransStore.POS
    Private mRPCAddress As String

    Private mCustomerName As String
    Private mCustomerTelp As String
    Private mCustomerEmail As String
    Private mCustomerId As String
    Private mCustomerTypeName As String
    Private mGenderId As String
    Private mDisc As Integer

    Public Property POS() As TransStore.POS
        Get
            Return Me.mPOS
        End Get
        Set(ByVal value As TransStore.POS)
            Me.mPOS = value
        End Set
    End Property

    Public Property RPCAddress() As String
        Get
            Return Me.mRPCAddress
        End Get
        Set(ByVal value As String)
            Me.mRPCAddress = value
        End Set
    End Property

    Public Property CustomerName() As String
        Get
            Return Me.mCustomerName
        End Get
        Set(ByVal value As String)
            Me.mCustomerName = value
        End Set
    End Property

    Public Property CustomerTelp() As String
        Get
            Return Me.mCustomerTelp
        End Get
        Set(ByVal value As String)
            Me.mCustomerTelp = value
        End Set
    End Property


    Public Property CustomerEmail() As String
        Get
            Return Me.mCustomerEmail
        End Get
        Set(ByVal value As String)
            Me.mCustomerEmail = value
        End Set
    End Property

    Public Property CustomerId() As String
        Get
            Return Me.mCustomerId
        End Get
        Set(ByVal value As String)
            Me.mCustomerId = value
        End Set
    End Property

    Public Property CustomerTypeName() As String
        Get
            Return Me.mCustomerTypeName
        End Get
        Set(ByVal value As String)
            Me.mCustomerTypeName = value
        End Set
    End Property

    Public Property GenderId() As String
        Get
            Return Me.mGenderId
        End Get
        Set(ByVal value As String)
            Me.mGenderId = value
        End Set
    End Property

    Public Property Disc() As Integer
        Get
            Return Me.mDisc
        End Get
        Set(ByVal value As Integer)
            Me.mDisc = value
        End Set
    End Property


#End Region

#Region " Functions"

    Public Overrides Function LoadDataIntoDatatable(ByVal service As String, ByVal criteria As String, ByRef respond As String) As DataTable
        Dim wConn As Translib.WebConnection = New Translib.WebConnection(Me.RPCAddress, Me.POS.SessionId, Me.POS.UserName)
        Dim objWebResult As Translib.WebResultObject
        Dim obj As Newtonsoft.Json.JavaScriptObject
        Dim n, i As Integer
        Dim tbl As DataTable = New DataTable()

        Try
            wConn.addtext("clientname", Me.POS.ClientName)
            wConn.addtext("criteria", criteria)
            objWebResult = Translib.uiBase.WebserviceExecute(wConn, service, respond)
            n = objWebResult.data.Count
            If n > 0 Then
                For i = 0 To n - 1
                    obj = CType(objWebResult.data(i), Newtonsoft.Json.JavaScriptObject)
                    Me.AddRowFromJsonObject(tbl, obj, True)
                Next
            End If
        Catch ex As Exception
            Throw New Exception(Mid(respond, 1, 1000) & vbCrLf & vbCrLf & ex.Message)
        End Try

        Return tbl
    End Function

#End Region

#Region " Background Worker"

    Private Sub bgwSearch_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bgwSearch.DoWork
        Dim res As CustomerSeachResult = New CustomerSeachResult()
        Dim CriteriaBuilder As Translib.QueryCriteria = New Translib.QueryCriteria

        Try

            Dim arg As CustomerSeachArgument = DirectCast(e.Argument, CustomerSeachArgument)
            res.Argument = arg


            CriteriaBuilder = New Translib.QueryCriteria
            CriteriaBuilder.AddCriteria("searchkey", True, arg.Searchkey)

            Dim respond As String = Nothing
            Dim tbl As DataTable = Me.LoadDataIntoDatatable(arg.Service, CriteriaBuilder.Serialize(), respond)

            res.DataTable = tbl
            res.Success = True
        Catch ex As Exception
            res.Success = False
            res.ErrorMessage = ex.Message
        Finally
            e.Result = res
        End Try
    End Sub


    Private Sub bgwSearch_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bgwSearch.RunWorkerCompleted
        Try

            Dim res As CustomerSeachResult = DirectCast(e.Result, CustomerSeachResult)

            If Not res.Success Then
                Throw New Exception(res.ErrorMessage)
            End If

            Me.dgv_Customer.DataSource = res.DataTable


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Search Customer", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.UseWaitCursor = False
            Me.Panel1.Enabled = True
            Me.Label2.Visible = False
            Me.PictureBox1.Visible = False
        End Try
    End Sub



#End Region


    Private Sub dlgCustomerSearch_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.Label2.Visible = False
        Me.PictureBox1.Visible = False

        Dim obj As Control
        For Each obj In Me.Controls
            If obj.Name = Me.Panel1.Name Or obj.Name = Me.Panel2.Name Or obj.Name = Me.dgv_Customer.Name Then
            Else
                Me.Controls.Remove(obj)
            End If
        Next

        Me.ControlBox = True


        Dim col_customer_id As New DataGridViewTextBoxColumn()
        Dim col_customer_name As New DataGridViewTextBoxColumn()
        Dim col_customer_telp As New DataGridViewTextBoxColumn()
        Dim col_customer_telpview As New DataGridViewTextBoxColumn()
        Dim col_customer_email As New DataGridViewTextBoxColumn()
        Dim col_gender_id As New DataGridViewTextBoxColumn()
        Dim col_customer_typename As New DataGridViewTextBoxColumn()
        Dim col_customer_paymdisc As New DataGridViewTextBoxColumn()

        With col_customer_id
            .Name = "customer_id"
            .DataPropertyName = "customer_id"
            .HeaderText = "ID"
            .Width = 200
            .ReadOnly = True
            .Visible = False
        End With

        With col_customer_name
            .Name = "customer_name"
            .DataPropertyName = "customer_name"
            .HeaderText = "Name"
            .Width = 300
            .ReadOnly = True
        End With

        With col_customer_telp
            .Name = "customer_telp"
            .DataPropertyName = "customer_telp"
            .HeaderText = "Telp"
            .Width = 120
            .ReadOnly = True
            .Visible = False
        End With

        With col_customer_telpview
            .Name = "customer_telpview"
            .DataPropertyName = "customer_telpview"
            .HeaderText = "Telp"
            .Width = 120
            .ReadOnly = True
        End With

        With col_customer_email
            .Name = "customer_email"
            .DataPropertyName = "customer_email"
            .HeaderText = "Email"
            .Width = 120
            .ReadOnly = True
        End With

        With col_gender_id
            .Name = "gender_id"
            .DataPropertyName = "gender_id"
            .HeaderText = "Gen"
            .Width = 30
            .ReadOnly = True
        End With

        With col_customer_typename
            .Name = "customer_typename"
            .DataPropertyName = "customer_typename"
            .HeaderText = "Type"
            .Width = 100
            .ReadOnly = True
        End With

        With col_customer_paymdisc
            .Name = "customer_paymdisc"
            .DataPropertyName = "customer_paymdisc"
            .HeaderText = "Disc"
            .Width = 40
            .ReadOnly = True
        End With


        ' Format DataGrid
        With Me.dgv_Customer
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AutoGenerateColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With

        Me.dgv_Customer.Columns.Add(col_customer_id)
        Me.dgv_Customer.Columns.Add(col_customer_name)
        Me.dgv_Customer.Columns.Add(col_customer_telp)
        Me.dgv_Customer.Columns.Add(col_customer_telpview)
        Me.dgv_Customer.Columns.Add(col_customer_email)
        Me.dgv_Customer.Columns.Add(col_gender_id)
        Me.dgv_Customer.Columns.Add(col_customer_typename)
        Me.dgv_Customer.Columns.Add(col_customer_paymdisc)


    End Sub


    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.Enter
                Me.btn_Cari_Click(Me.btn_Cari, EventArgs.Empty)
                e.SuppressKeyPress = True

        End Select
    End Sub

    Private Sub dgv_Customer_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgv_Customer.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.Enter
                e.SuppressKeyPress = True

                Dim pos = Me.BindingContext(Me.dgv_Customer.DataSource).Position
                Dim ev As DataGridViewCellEventArgs = New DataGridViewCellEventArgs(1, pos)
                dgv_Customer_CellDoubleClick(Me.dgv_Customer, ev)

        End Select
    End Sub

    Private Sub btn_Cari_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Cari.Click

        If Me.bgwSearch Is Nothing Then
            Me.bgwSearch = New BackgroundWorker()
        End If

        Dim arg As CustomerSeachArgument = New CustomerSeachArgument()
        arg.Searchkey = Me.TextBox1.Text.Trim()
        arg.RPCAddress = Me.RPCAddress
        arg.Service = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=customersearch"

        If (arg.Searchkey.Length < 4) Then
            MessageBox.Show("Kunci pencarian minimal adalah 4 huruf", "Search Customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        Me.UseWaitCursor = True
        Me.Panel1.Enabled = False
        Me.Label2.Visible = True
        Me.PictureBox1.Visible = True
        Me.bgwSearch.RunWorkerAsync(arg)

    End Sub


    Private Sub dgv_Customer_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgv_Customer.CellDoubleClick
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)

        If (e.RowIndex < 0) Then
            Exit Sub
        End If


        Dim row As DataGridViewRow = dgv.Rows(e.RowIndex)

        Me.CustomerId = row.Cells("customer_id").Value.ToString()
        Me.CustomerName = row.Cells("customer_name").Value.ToString()
        Me.CustomerTelp = row.Cells("customer_telp").Value.ToString()
        Me.CustomerEmail = row.Cells("customer_email").Value.ToString()
        Me.GenderId = row.Cells("gender_id").Value.ToString()
        Me.CustomerTypeName = row.Cells("customer_typename").Value.ToString()
        Me.Disc = CInt(row.Cells("customer_paymdisc").Value)

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub




#Region " Pembantu Private"

    Private Class CustomerSeachArgument
        Private mSearchkey As String
        Private mService As String
        Private mRPCAddress As String


        Public Property Searchkey() As String
            Get
                Return Me.mSearchkey
            End Get
            Set(ByVal value As String)
                Me.mSearchkey = value
            End Set
        End Property

        Public Property Service() As String
            Get
                Return Me.mService
            End Get
            Set(ByVal value As String)
                Me.mService = value
            End Set
        End Property

        Public Property RPCAddress() As String
            Get
                Return Me.mRPCAddress
            End Get
            Set(ByVal value As String)
                Me.mRPCAddress = value
            End Set
        End Property
    End Class

    Private Class CustomerSeachResult
        Private mArgument As CustomerSeachArgument
        Private mSuccess As Boolean
        Private mErrorMessage As String
        Private mDataTable As DataTable

        Public Property Argument() As CustomerSeachArgument
            Get
                Return Me.mArgument
            End Get
            Set(ByVal value As CustomerSeachArgument)
                Me.mArgument = value
            End Set
        End Property

        Public Property Success() As Boolean
            Get
                Return Me.mSuccess
            End Get
            Set(ByVal value As Boolean)
                Me.mSuccess = value
            End Set
        End Property

        Public Property ErrorMessage() As String
            Get
                Return Me.mErrorMessage
            End Get
            Set(ByVal value As String)
                Me.mErrorMessage = value
            End Set
        End Property

        Public Property DataTable() As DataTable
            Get
                Return Me.mDataTable
            End Get
            Set(ByVal value As DataTable)
                Me.mDataTable = value
            End Set
        End Property

    End Class

#End Region








End Class