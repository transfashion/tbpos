<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnPosUpdateArt
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
        Me.obj_ChkArt = New System.Windows.Forms.CheckBox
        Me.obj_ChkMat = New System.Windows.Forms.CheckBox
        Me.obj_ChkCol = New System.Windows.Forms.CheckBox
        Me.lbl_Region = New System.Windows.Forms.Label
        Me.obj_TxtArt = New System.Windows.Forms.TextBox
        Me.obj_TxtMat = New System.Windows.Forms.TextBox
        Me.obj_TxtCol = New System.Windows.Forms.TextBox
        Me.obj_RegionId = New System.Windows.Forms.ComboBox
        Me.btn_Query = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.obj_ChkUpdatePrice = New System.Windows.Forms.CheckBox
        Me.obj_TxtPrice = New System.Windows.Forms.TextBox
        Me.obj_TxtDisc = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_Execute = New System.Windows.Forms.Button
        Me.obj_GUpdate = New System.Windows.Forms.GroupBox
        CType(Me.dsMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.obj_GUpdate.SuspendLayout()
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
        Me.fLoadingIndicator.Location = New System.Drawing.Point(44, 58)
        Me.fLoadingIndicator.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        '
        'obj_ChkArt
        '
        Me.obj_ChkArt.AutoSize = True
        Me.obj_ChkArt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_ChkArt.Location = New System.Drawing.Point(41, 48)
        Me.obj_ChkArt.Name = "obj_ChkArt"
        Me.obj_ChkArt.Size = New System.Drawing.Size(48, 17)
        Me.obj_ChkArt.TabIndex = 1
        Me.obj_ChkArt.Text = "ART"
        Me.obj_ChkArt.UseVisualStyleBackColor = True
        '
        'obj_ChkMat
        '
        Me.obj_ChkMat.AutoSize = True
        Me.obj_ChkMat.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_ChkMat.Location = New System.Drawing.Point(40, 74)
        Me.obj_ChkMat.Name = "obj_ChkMat"
        Me.obj_ChkMat.Size = New System.Drawing.Size(49, 17)
        Me.obj_ChkMat.TabIndex = 2
        Me.obj_ChkMat.Text = "MAT"
        Me.obj_ChkMat.UseVisualStyleBackColor = True
        '
        'obj_ChkCol
        '
        Me.obj_ChkCol.AutoSize = True
        Me.obj_ChkCol.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_ChkCol.Location = New System.Drawing.Point(42, 100)
        Me.obj_ChkCol.Name = "obj_ChkCol"
        Me.obj_ChkCol.Size = New System.Drawing.Size(47, 17)
        Me.obj_ChkCol.TabIndex = 3
        Me.obj_ChkCol.Text = "COL"
        Me.obj_ChkCol.UseVisualStyleBackColor = True
        '
        'lbl_Region
        '
        Me.lbl_Region.AutoSize = True
        Me.lbl_Region.Location = New System.Drawing.Point(382, 46)
        Me.lbl_Region.Name = "lbl_Region"
        Me.lbl_Region.Size = New System.Drawing.Size(41, 13)
        Me.lbl_Region.TabIndex = 4
        Me.lbl_Region.Text = "Region"
        '
        'obj_TxtArt
        '
        Me.obj_TxtArt.Location = New System.Drawing.Point(95, 46)
        Me.obj_TxtArt.MaxLength = 30
        Me.obj_TxtArt.Name = "obj_TxtArt"
        Me.obj_TxtArt.Size = New System.Drawing.Size(196, 20)
        Me.obj_TxtArt.TabIndex = 5
        '
        'obj_TxtMat
        '
        Me.obj_TxtMat.Location = New System.Drawing.Point(95, 72)
        Me.obj_TxtMat.MaxLength = 30
        Me.obj_TxtMat.Name = "obj_TxtMat"
        Me.obj_TxtMat.Size = New System.Drawing.Size(196, 20)
        Me.obj_TxtMat.TabIndex = 6
        '
        'obj_TxtCol
        '
        Me.obj_TxtCol.Location = New System.Drawing.Point(95, 98)
        Me.obj_TxtCol.MaxLength = 30
        Me.obj_TxtCol.Name = "obj_TxtCol"
        Me.obj_TxtCol.Size = New System.Drawing.Size(196, 20)
        Me.obj_TxtCol.TabIndex = 7
        '
        'obj_RegionId
        '
        Me.obj_RegionId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_RegionId.FormattingEnabled = True
        Me.obj_RegionId.Location = New System.Drawing.Point(438, 43)
        Me.obj_RegionId.Name = "obj_RegionId"
        Me.obj_RegionId.Size = New System.Drawing.Size(196, 21)
        Me.obj_RegionId.TabIndex = 8
        '
        'btn_Query
        '
        Me.btn_Query.Location = New System.Drawing.Point(539, 98)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(95, 23)
        Me.btn_Query.TabIndex = 9
        Me.btn_Query.Text = "Query"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(11, 137)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(736, 190)
        Me.DataGridView1.TabIndex = 10
        '
        'obj_ChkUpdatePrice
        '
        Me.obj_ChkUpdatePrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.obj_ChkUpdatePrice.AutoSize = True
        Me.obj_ChkUpdatePrice.Location = New System.Drawing.Point(30, 349)
        Me.obj_ChkUpdatePrice.Name = "obj_ChkUpdatePrice"
        Me.obj_ChkUpdatePrice.Size = New System.Drawing.Size(155, 17)
        Me.obj_ChkUpdatePrice.TabIndex = 11
        Me.obj_ChkUpdatePrice.Text = "Update Price And Discount"
        Me.obj_ChkUpdatePrice.UseVisualStyleBackColor = True
        '
        'obj_TxtPrice
        '
        Me.obj_TxtPrice.Location = New System.Drawing.Point(61, 23)
        Me.obj_TxtPrice.MaxLength = 30
        Me.obj_TxtPrice.Name = "obj_TxtPrice"
        Me.obj_TxtPrice.Size = New System.Drawing.Size(107, 20)
        Me.obj_TxtPrice.TabIndex = 12
        '
        'obj_TxtDisc
        '
        Me.obj_TxtDisc.Location = New System.Drawing.Point(219, 23)
        Me.obj_TxtDisc.MaxLength = 2
        Me.obj_TxtDisc.Name = "obj_TxtDisc"
        Me.obj_TxtDisc.Size = New System.Drawing.Size(48, 20)
        Me.obj_TxtDisc.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Price"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(185, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Disc"
        '
        'btn_Execute
        '
        Me.btn_Execute.Location = New System.Drawing.Point(61, 60)
        Me.btn_Execute.Name = "btn_Execute"
        Me.btn_Execute.Size = New System.Drawing.Size(95, 23)
        Me.btn_Execute.TabIndex = 16
        Me.btn_Execute.Text = "Execute"
        Me.btn_Execute.UseVisualStyleBackColor = True
        '
        'obj_GUpdate
        '
        Me.obj_GUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.obj_GUpdate.Controls.Add(Me.btn_Execute)
        Me.obj_GUpdate.Controls.Add(Me.Label2)
        Me.obj_GUpdate.Controls.Add(Me.Label1)
        Me.obj_GUpdate.Controls.Add(Me.obj_TxtDisc)
        Me.obj_GUpdate.Controls.Add(Me.obj_TxtPrice)
        Me.obj_GUpdate.Location = New System.Drawing.Point(29, 368)
        Me.obj_GUpdate.Name = "obj_GUpdate"
        Me.obj_GUpdate.Size = New System.Drawing.Size(303, 108)
        Me.obj_GUpdate.TabIndex = 17
        Me.obj_GUpdate.TabStop = False
        '
        'uiTrnPosUpdateArt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackgroundworkerStatus = Translib.uiBase.EBackgroundworkerStatus.Done
        Me.Controls.Add(Me.obj_GUpdate)
        Me.Controls.Add(Me.obj_ChkUpdatePrice)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btn_Query)
        Me.Controls.Add(Me.obj_RegionId)
        Me.Controls.Add(Me.obj_TxtCol)
        Me.Controls.Add(Me.obj_TxtMat)
        Me.Controls.Add(Me.obj_TxtArt)
        Me.Controls.Add(Me.lbl_Region)
        Me.Controls.Add(Me.obj_ChkCol)
        Me.Controls.Add(Me.obj_ChkMat)
        Me.Controls.Add(Me.obj_ChkArt)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Message = "Done. "
        Me.Name = "uiTrnPosUpdateArt"
        Me.Progress = 20
        Me.Status = "Loading Data..."
        Me.Controls.SetChildIndex(Me.obj_ChkArt, 0)
        Me.Controls.SetChildIndex(Me.obj_ChkMat, 0)
        Me.Controls.SetChildIndex(Me.obj_ChkCol, 0)
        Me.Controls.SetChildIndex(Me.lbl_Region, 0)
        Me.Controls.SetChildIndex(Me.obj_TxtArt, 0)
        Me.Controls.SetChildIndex(Me.obj_TxtMat, 0)
        Me.Controls.SetChildIndex(Me.obj_TxtCol, 0)
        Me.Controls.SetChildIndex(Me.obj_RegionId, 0)
        Me.Controls.SetChildIndex(Me.btn_Query, 0)
        Me.Controls.SetChildIndex(Me.DataGridView1, 0)
        Me.Controls.SetChildIndex(Me.obj_ChkUpdatePrice, 0)
        Me.Controls.SetChildIndex(Me.obj_GUpdate, 0)
        CType(Me.dsMaster, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.obj_GUpdate.ResumeLayout(False)
        Me.obj_GUpdate.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents obj_ChkArt As System.Windows.Forms.CheckBox
    Friend WithEvents obj_ChkMat As System.Windows.Forms.CheckBox
    Friend WithEvents obj_ChkCol As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Region As System.Windows.Forms.Label
    Friend WithEvents obj_TxtArt As System.Windows.Forms.TextBox
    Friend WithEvents obj_TxtMat As System.Windows.Forms.TextBox
    Friend WithEvents obj_TxtCol As System.Windows.Forms.TextBox
    Friend WithEvents obj_RegionId As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents obj_ChkUpdatePrice As System.Windows.Forms.CheckBox
    Friend WithEvents obj_TxtPrice As System.Windows.Forms.TextBox
    Friend WithEvents obj_TxtDisc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_Execute As System.Windows.Forms.Button
    Friend WithEvents obj_GUpdate As System.Windows.Forms.GroupBox

End Class
