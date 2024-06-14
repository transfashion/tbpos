Public Class uiTrnPosUpdateArt

#Region " Constructor "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MyBase.InitializeControl(Config.DeveloperDefaultSessionID, Config.DeveloperDefaultUserName, Config.WebserviceAddress, Config.DllServer, Nothing, Me.GetType().Assembly)
        MyBase.SetDSNLocal(Translib.uiBase.CreateDSN(Config.LocalDbServer, Config.LocalDbname, Config.LocalDbUsername, Config.LocalDbPassword))


    End Sub

#End Region

    Private Sub uiTrnPosUpdateArt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim tblRegion As DataTable = New DataTable
        Dim dsn As String = Me.DSNLocal
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)


        Try
            dbConn.Open()

            Dim sql = "SELECT region_id, region_name FROM master_region WHERE region_isdisabled='0' ORDER BY region_name"
            Dim cmd As OleDb.OleDbCommand = dbConn.CreateCommand()

            cmd.CommandText = sql
            cmd.CommandType = CommandType.Text

            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(cmd)

            da.Fill(tblRegion)

            Me.obj_RegionId.DataSource = tblRegion
            Me.obj_RegionId.ValueMember = "region_id"
            Me.obj_RegionId.DisplayMember = "region_name"


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Update ART", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.obj_TxtArt.DataBindings.Add(New Binding("Enabled", Me.obj_ChkArt, "Checked"))
        Me.obj_TxtMat.DataBindings.Add(New Binding("Enabled", Me.obj_ChkMat, "Checked"))
        Me.obj_TxtCol.DataBindings.Add(New Binding("Enabled", Me.obj_ChkCol, "Checked"))
        Me.obj_ChkMat.DataBindings.Add(New Binding("Enabled", Me.obj_ChkArt, "Checked"))
        Me.obj_ChkCol.DataBindings.Add(New Binding("Enabled", Me.obj_ChkArt, "Checked"))
        Me.obj_GUpdate.DataBindings.Add(New Binding("Enabled", Me.obj_ChkUpdatePrice, "Checked"))


        Me.obj_ChkUpdatePrice.Enabled = False

    End Sub

    Private Sub btn_Query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Query.Click
        If (Not Me.obj_ChkArt.Checked And Not Me.obj_ChkCol.Checked And Not Me.obj_ChkMat.Checked) Then
            Exit Sub
        End If

        Dim region_id = Me.obj_RegionId.SelectedValue
        Dim heinv_art = Trim(Me.obj_TxtArt.Text)
        Dim heinv_mat = Trim(Me.obj_TxtMat.Text)
        Dim heinv_col = Trim(Me.obj_TxtCol.Text)

        Dim whereclause As String = " heinv_isdisabled='0' AND region_id='" & region_id & "' "

        If (Me.obj_ChkArt.Checked) Then
            whereclause &= " AND heinv_art = '" & heinv_art & "' "
        End If

        If (Me.obj_ChkMat.Checked) Then
            whereclause &= " AND heinv_mat = '" & heinv_mat & "' "
        End If

        If (Me.obj_ChkCol.Checked) Then
            whereclause &= " AND heinv_col = '" & heinv_col & "' "
        End If



        Dim tblItem As DataTable = New DataTable
        Dim dsn As String = Me.DSNLocal
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)


        Try
            dbConn.Open()

            Dim sql = " SELECT heinv_id, heinv_art, heinv_mat, heinv_col, heinv_descr, heinv_price01, heinv_pricedisc01 FROM master_heinv "
            sql &= " WHERE "
            sql &= whereclause

            Dim cmd As OleDb.OleDbCommand = dbConn.CreateCommand()

            cmd.CommandText = sql
            cmd.CommandType = CommandType.Text


            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(cmd)

            da.Fill(tblItem)

            Me.DataGridView1.DataSource = tblItem
            Me.DataGridView1.ReadOnly = True
            Me.DataGridView1.AllowUserToAddRows = False
            Me.DataGridView1.AllowUserToDeleteRows = False

            Try
                Me.DataGridView1.Columns("heinv_id").HeaderText = "ID"
                Me.DataGridView1.Columns("heinv_id").Width = 100
                Me.DataGridView1.Columns("heinv_art").HeaderText = "ART"
                Me.DataGridView1.Columns("heinv_art").Width = 80
                Me.DataGridView1.Columns("heinv_mat").HeaderText = "MAT"
                Me.DataGridView1.Columns("heinv_mat").Width = 80
                Me.DataGridView1.Columns("heinv_col").HeaderText = "COL"
                Me.DataGridView1.Columns("heinv_col").Width = 80
                Me.DataGridView1.Columns("heinv_descr").HeaderText = "DESCR"
                Me.DataGridView1.Columns("heinv_descr").Width = 200

                Me.DataGridView1.Columns("heinv_price01").HeaderText = "Price"
                Me.DataGridView1.Columns("heinv_price01").Width = 80
                Me.DataGridView1.Columns("heinv_price01").DefaultCellStyle.Format = "#,##0"
                Me.DataGridView1.Columns("heinv_price01").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.DataGridView1.Columns("heinv_pricedisc01").HeaderText = "Disc"
                Me.DataGridView1.Columns("heinv_pricedisc01").Width = 50
                Me.DataGridView1.Columns("heinv_pricedisc01").DefaultCellStyle.Format = "#,##0"
                Me.DataGridView1.Columns("heinv_pricedisc01").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Catch ex As Exception
            End Try

            If (tblItem.Rows.Count > 0) Then
                Me.obj_ChkUpdatePrice.Enabled = True
            Else
                Me.obj_ChkUpdatePrice.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Update ART", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub obj_ChkArt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_ChkArt.CheckedChanged
        If (Not Me.obj_ChkArt.Checked) Then
            Me.obj_ChkMat.Checked = False
            Me.obj_ChkCol.Checked = False
        End If
    End Sub

    Private Sub btn_Execute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Execute.Click
        Dim newprice As Decimal
        Dim newdisc As Integer

        Try
            newprice = CDec(Me.obj_TxtPrice.Text)
            newdisc = CInt(Me.obj_TxtDisc.Text)
        Catch ex As Exception
            MessageBox.Show("Entry price/discount salah", "Update ART", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try


        Dim txt As String = "Apakah anda mau update price item yang terpilih menjadi: " & vbCrLf
        txt &= "Price: " & String.Format("{0:#,##0}", newprice) & "      Disc: " & newdisc & "%"

        Dim res As DialogResult
        res = MessageBox.Show(txt, "Update Price", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If res = DialogResult.Cancel Then
            Exit Sub
        End If


        Dim dsn As String = Me.DSNLocal
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
        Try
            dbConn.Open()
            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                Dim heinv_id As String = row.Cells("heinv_id").Value.ToString
                Dim sql As String = "UPDATE master_heinv "
                sql &= "SET "
                sql &= "heinv_price01='" & newprice & "', "
                sql &= "heinv_pricedisc01='" & newdisc & "' "
                sql &= "WHERE "
                sql &= " heinv_id = '" & heinv_id & "' "

                Dim cmd As OleDb.OleDbCommand = dbConn.CreateCommand()
                cmd.CommandText = sql
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Update Price", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.btn_Query_Click(Me.btn_Execute, System.EventArgs.Empty)
        Me.obj_ChkUpdatePrice.Checked = False
        Me.obj_TxtPrice.Text = ""
        Me.obj_TxtDisc.Text = ""

    End Sub



End Class
