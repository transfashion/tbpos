Public Class dlgTrnPosDataBrowse

    Private SQL As String
    Private myRetObj As Object
    Private ColumnsFormat As System.Windows.Forms.DataGridViewColumn()
    Private column_objid As String
    Private column_objname As String

    Private Commit As Boolean
    Private LastRowIndex As Integer
    Private mv As Boolean = False

    Private WithEvents POS As TransStore.POS


#Region " Constructor "

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, ByVal args As Object) As Object
        Dim ParamValue As TransStore.PosDataBrowseParamValue

        Try
            ParamValue = CType(args(0), TransStore.PosDataBrowseParamValue)
            Me.POS = ParamValue.POS
            Me.lblTitle.Text &= " " & ParamValue.Title
            Me.objId.Text = ParamValue.id
            Me.objName.Text = ParamValue.name

            Me.objName.Focus()
            Me.objName.SelectionStart = 1
            Me.objName.SelectionLength = Len(Me.objName.Text)

            Me.SQL = ParamValue.SQL
            Me.ColumnsFormat = ParamValue.ColumnsFormat
            Me.column_objid = ParamValue.column_objid
            Me.column_objname = ParamValue.column_objname
        Catch ex As Exception
            Me.Close()
            Throw ex
        End Try


        Me.objSelectedId.Text = ParamValue.id
        Me.objSelectedName.Text = ParamValue.name

        MyBase.ShowDialog(owner)
        Return myRetObj
    End Function

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region


#Region " Layout & UI "

    Public Function BindingStart() As Boolean
    End Function

#End Region

#Region " Listener "

    Public Function DgvReadOnlyState() As Boolean
        Me.DgvResult.ReadOnly = True
        Me.DgvResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        'Me.DgvPOSItem.DefaultCellStyle.SelectionBackColor = Color.DarkGray
    End Function

    Public Function KeyCheck(ByVal sender As Object, ByVal keycode As System.Windows.Forms.Keys, ByVal keyvalue As Integer, ByVal ctrl As Boolean, ByRef suppressglobalkeyprocess As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        Dim obj As Control = sender
        Select Case obj.Name
            Case "objName"
                Select Case keycode
                    Case Keys.Enter
                        Me.Search(obj.Text)
                    Case Keys.Up
                        SuppressKeyPress = True
                        If Not Me.mv Then
                            Me.DgvResult.Focus()
                            Me.mv = True
                            suppressglobalkeyprocess = True
                            If Me.DgvResult.Rows.Count > 0 Then
                                Me.DgvResult.Rows(0).Selected = True
                            End If
                        End If

                    Case Keys.Down
                        SuppressKeyPress = True
                        If Not Me.mv Then
                            Me.DgvResult.Focus()
                            Me.mv = True
                            suppressglobalkeyprocess = True
                            If Me.DgvResult.Rows.Count > 0 Then
                                Me.DgvResult.Rows(0).Selected = True
                            End If
                        End If
                End Select
        End Select

        Return True
    End Function

    Public Function Key(ByVal sender As Object, ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean) As Boolean
        Dim obj As Control = sender

        Select Case keycode
            Case Keys.Escape
                Me.dlgCancel()


            Case Keys.Up

                Me.DgvReadOnlyState()
                If Me.DgvResult.Rows.Count > 0 Then
                    Dim currIndex As Integer = 0
                    If Me.DgvResult.CurrentRow IsNot Nothing Then
                        currIndex = Me.DgvResult.CurrentRow.Index
                        If currIndex > 0 Then
                            currIndex -= 1
                        End If
                    Else
                        currIndex = 0
                    End If
                    Me.DgvResult.CurrentCell = Me.DgvResult.Rows(currIndex).Cells(0)
                    Me.DgvResult.Rows(currIndex).Selected = True
                    'Me.DgvHeitem.FirstDisplayedCell = Me.DgvHeitem.CurrentCell
                    Me.LastRowIndex = currIndex
                End If

            Case Keys.Down
                Me.DgvReadOnlyState()
                If Me.DgvResult.Rows.Count > 0 Then
                    Dim currIndex As Integer = 0
                    If Me.DgvResult.CurrentRow IsNot Nothing Then
                        currIndex = Me.DgvResult.CurrentRow.Index
                        If currIndex < Me.DgvResult.Rows.Count - 1 Then
                            currIndex += 1
                        End If
                    Else
                        currIndex = 0
                    End If
                    Me.DgvResult.CurrentCell = Me.DgvResult.Rows(currIndex).Cells(0)
                    Me.DgvResult.Rows(currIndex).Selected = True
                    'Me.DgvHeitem.FirstDisplayedCell = Me.DgvHeitem.CurrentCell
                    Me.LastRowIndex = currIndex
                End If





            Case Keys.F10
                Me.dlgOK()
        End Select
    End Function



#End Region


    Private Sub dlg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.SuspendLayout()

        Dim obj As Control
        For Each obj In Me.Controls
            If obj.Name <> Me.PnlFormMain.Name Then
                Me.Controls.Remove(obj)
            End If
        Next


        Me.DgvResult.Columns.Clear()
        If Me.ColumnsFormat IsNot Nothing Then
            Me.DgvResult.Columns.AddRange(Me.ColumnsFormat)
            Me.DgvResult.AutoGenerateColumns = False
        Else
            Me.DgvResult.AutoGenerateColumns = True
        End If
        Me.DgvResult.AllowUserToAddRows = False
        Me.DgvResult.AllowUserToDeleteRows = False
        Me.DgvResult.AllowUserToResizeRows = False
        Me.DgvResult.ReadOnly = True
        Me.DgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect

        Me.Refresh()
        Me.ResumeLayout()




        uiTrnPosEN.BeepPopUp()

        'Me.objName.SelectionStart = 1
        'Me.objName.SelectionLength = Len(Me.objName.Text)
        'Me.objName.Focus()

        Me.objName.Focus()
        Me.objName.Focus()
        Me.objName.Focus()
        'Me.objName.Focus()
        'Me.objName.SelectionStart = 1
        'Me.objName.SelectionLength = Len(Me.objName.Text)

    End Sub

    Private Sub dlgCancel()
        Me.myRetObj = Nothing
        Me.POS = Nothing
        Me.Close()
    End Sub

    Private Sub dlgOK()
        Dim i As Integer
        Dim colname As String
        Dim col As Collection = New Collection()
        Dim objReturnValue As TransStore.PosDataBrowseReturnValue = New TransStore.PosDataBrowseReturnValue


        If Me.DgvResult.CurrentRow IsNot Nothing Then
            For i = 0 To Me.DgvResult.CurrentRow.Cells.Count - 1
                colname = Me.DgvResult.Columns(Me.DgvResult.CurrentRow.Cells(i).ColumnIndex).Name
                col.Add(Me.DgvResult.CurrentRow.Cells(i).Value, colname)
            Next
        End If

        objReturnValue.id = Me.objSelectedId.Text
        objReturnValue.name = Me.objSelectedName.Text
        objReturnValue.fields = col

        Me.myRetObj = New Object() {objReturnValue}
        Me.POS = Nothing
        uiTrnPosEN.BeepDef2()
        Me.Close()
    End Sub

    Private Sub dlg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    End Sub

    Private Sub Object_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles objName.KeyDown
        Dim suppressglobalkeyprocess As Boolean
        Dim SuppressKeyPress As Boolean

        If Me.KeyCheck(sender, e.KeyCode, e.KeyValue, e.Control, suppressglobalkeyprocess, SuppressKeyPress) Then
            e.SuppressKeyPress = SuppressKeyPress
            If Not suppressglobalkeyprocess Then
                Key(sender, e.KeyCode, e.Control)
            End If
        Else
            e.SuppressKeyPress = True
        End If

    End Sub

    Private Sub Dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgvResult.KeyDown

        If e.KeyCode = Keys.Enter And Me.DgvResult.Rows.Count > 0 Then
            e.SuppressKeyPress = True
            If Not Commit Then
                Commit = True
                Me._CommitSearch()
                Me.pnlSearchCriteria.Enabled = False
                Me.DgvResult.Enabled = False
                'Me.obj_SelectedItem.Enabled = True
                'Me.obj_SelectedItem.Focus()
                Exit Sub
            End If
        End If


        If e.KeyValue = 27 Then
            Me.Close()
        End If

        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            Exit Sub
        End If

        If (e.KeyValue >= 48 And e.KeyValue <= 57) Or _
            (e.KeyValue >= 65 And e.KeyValue <= 90) Or _
            (e.KeyValue >= 96 And e.KeyValue <= 105) _
        Then
            '  (e.KeyValue >= 186 And e.KeyValue <= 191) Or _
            '  (e.KeyValue >= 219 And e.KeyValue <= 221) Or _
            '  e.KeyValue = 226 Then
            Me.objName.AppendText(Chr(e.KeyCode))
            Me.objName.Focus()
            Exit Sub
        End If

        Me.objName.Focus()

    End Sub


    Private Sub objSelectedId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles objSelectedId.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            e.SuppressKeyPress = True
            Exit Sub
        End If


        Select Case e.KeyCode
            Case Keys.Enter
                If Me.Commit & Trim(Me.objSelectedId.Text) <> "" Then
                    Me.dlgOK()
                End If

            Case Keys.Escape
                ' Cancel Pilih
                Me.objSelectedId.Text = ""
                Me.objSelectedName.Text = "NONE"

                Me.objSelectedId.Enabled = False
                Me.DgvResult.Enabled = True
                Me.pnlSearchCriteria.Enabled = True

                Me.DgvResult.Focus()
                Me.objName.SelectionStart = Len(Me.objName.Text)
                Me.objName.SelectionLength = 0

                Me.Commit = False


        End Select
    End Sub



    Public Sub Search(ByVal keystring As String)
        Dim key As String = Trim(keystring)
        If key = "" Then
            Exit Sub
        End If

        Dim query As String = SQL.Replace("[_SEARCHKEY_]", key)

        Try
            Dim tbl As DataTable = Me.POS.Execute(query)
            If tbl.Rows.Count <= 0 Then
                ' Ada hasil
                MessageBox.Show("Result not found, " & vbCrLf & "Search key: " & key, Me.lblTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Me.DgvResult.DataSource = tbl
            End If
            Me.DgvResult.ClearSelection()
            Me.objName.Focus()
            Me.mv = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.lblTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        

    End Sub

    Private Sub _CommitSearch()
        Dim currIndex As Integer

        If Me.DgvResult.CurrentRow IsNot Nothing Then
            currIndex = Me.DgvResult.CurrentRow.Index


            Me.objSelectedId.Text = Me.DgvResult.Rows(currIndex).Cells(Me.column_objid).Value
            Me.objSelectedName.Text = Me.DgvResult.Rows(currIndex).Cells(Me.column_objname).Value

            Me.objSelectedId.AutoSize = True
            Me.objSelectedName.AutoSize = True

            Me.objSelectedId.Enabled = True
            Me.objSelectedId.ReadOnly = True
            Me.objSelectedId.SelectionStart = Len(Me.objName.Text)
            Me.objSelectedId.SelectionLength = 0

        End If
    End Sub



 
End Class
