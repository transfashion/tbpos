<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnInventorymovingDetilItemNewrow
    Inherits Translib.dlgBase

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
        Me.lbl_inventorymoving_id = New System.Windows.Forms.Label
        Me.obj_inventorymovingdetil_line = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.obj_iteminventory_id = New System.Windows.Forms.TextBox
        Me.obj_inventorymovingdetil_article = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.obj_inventorymovingdetil_mat = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.obj_inventorymovingdetil_col = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.obj_inventorymovingdetil_size = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.obj_iteminventorygroup_id = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.obj_iteminventorysubgroup_id = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.obj_season_id = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.obj_inventorymovingdetil_qtypropose = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.obj_inventorymovingdetil_qtyinit = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.obj_inventorymovingdetil_qty = New System.Windows.Forms.TextBox
        Me.lbl_inventorymovingdetil_idr = New System.Windows.Forms.Label
        Me.obj_inventorymovingdetil_idr = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.obj_iteminventoryunit_id = New System.Windows.Forms.TextBox
        Me.btnOpenItem = New System.Windows.Forms.Button
        Me.obj_inventorymovingdetil_descr = New System.Windows.Forms.Label
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_inventorymoving_id
        '
        Me.lbl_inventorymoving_id.Location = New System.Drawing.Point(4, 12)
        Me.lbl_inventorymoving_id.Name = "lbl_inventorymoving_id"
        Me.lbl_inventorymoving_id.Size = New System.Drawing.Size(80, 20)
        Me.lbl_inventorymoving_id.TabIndex = 13
        Me.lbl_inventorymoving_id.Text = "Line"
        Me.lbl_inventorymoving_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_inventorymovingdetil_line
        '
        Me.obj_inventorymovingdetil_line.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_inventorymovingdetil_line.Location = New System.Drawing.Point(90, 12)
        Me.obj_inventorymovingdetil_line.Name = "obj_inventorymovingdetil_line"
        Me.obj_inventorymovingdetil_line.ReadOnly = True
        Me.obj_inventorymovingdetil_line.Size = New System.Drawing.Size(79, 20)
        Me.obj_inventorymovingdetil_line.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 20)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Item"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_iteminventory_id
        '
        Me.obj_iteminventory_id.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_iteminventory_id.Location = New System.Drawing.Point(90, 38)
        Me.obj_iteminventory_id.Name = "obj_iteminventory_id"
        Me.obj_iteminventory_id.ReadOnly = True
        Me.obj_iteminventory_id.Size = New System.Drawing.Size(136, 20)
        Me.obj_iteminventory_id.TabIndex = 14
        '
        'obj_inventorymovingdetil_article
        '
        Me.obj_inventorymovingdetil_article.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_inventorymovingdetil_article.Location = New System.Drawing.Point(90, 64)
        Me.obj_inventorymovingdetil_article.Name = "obj_inventorymovingdetil_article"
        Me.obj_inventorymovingdetil_article.ReadOnly = True
        Me.obj_inventorymovingdetil_article.Size = New System.Drawing.Size(228, 20)
        Me.obj_inventorymovingdetil_article.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(4, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 20)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Article"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(4, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 20)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Material"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_inventorymovingdetil_mat
        '
        Me.obj_inventorymovingdetil_mat.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_inventorymovingdetil_mat.Location = New System.Drawing.Point(90, 90)
        Me.obj_inventorymovingdetil_mat.Name = "obj_inventorymovingdetil_mat"
        Me.obj_inventorymovingdetil_mat.ReadOnly = True
        Me.obj_inventorymovingdetil_mat.Size = New System.Drawing.Size(89, 20)
        Me.obj_inventorymovingdetil_mat.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(4, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 20)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Color"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_inventorymovingdetil_col
        '
        Me.obj_inventorymovingdetil_col.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_inventorymovingdetil_col.Location = New System.Drawing.Point(90, 116)
        Me.obj_inventorymovingdetil_col.Name = "obj_inventorymovingdetil_col"
        Me.obj_inventorymovingdetil_col.ReadOnly = True
        Me.obj_inventorymovingdetil_col.Size = New System.Drawing.Size(89, 20)
        Me.obj_inventorymovingdetil_col.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(4, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 20)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Size"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_inventorymovingdetil_size
        '
        Me.obj_inventorymovingdetil_size.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_inventorymovingdetil_size.Location = New System.Drawing.Point(90, 142)
        Me.obj_inventorymovingdetil_size.Name = "obj_inventorymovingdetil_size"
        Me.obj_inventorymovingdetil_size.ReadOnly = True
        Me.obj_inventorymovingdetil_size.Size = New System.Drawing.Size(89, 20)
        Me.obj_inventorymovingdetil_size.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(301, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 20)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Group"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_iteminventorygroup_id
        '
        Me.obj_iteminventorygroup_id.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_iteminventorygroup_id.Location = New System.Drawing.Point(387, 117)
        Me.obj_iteminventorygroup_id.Name = "obj_iteminventorygroup_id"
        Me.obj_iteminventorygroup_id.ReadOnly = True
        Me.obj_iteminventorygroup_id.Size = New System.Drawing.Size(89, 20)
        Me.obj_iteminventorygroup_id.TabIndex = 25
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(301, 143)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 20)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Subgroup"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_iteminventorysubgroup_id
        '
        Me.obj_iteminventorysubgroup_id.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_iteminventorysubgroup_id.Location = New System.Drawing.Point(387, 143)
        Me.obj_iteminventorysubgroup_id.Name = "obj_iteminventorysubgroup_id"
        Me.obj_iteminventorysubgroup_id.ReadOnly = True
        Me.obj_iteminventorysubgroup_id.Size = New System.Drawing.Size(89, 20)
        Me.obj_iteminventorysubgroup_id.TabIndex = 27
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(331, 91)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 20)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Season"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_season_id
        '
        Me.obj_season_id.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_season_id.Location = New System.Drawing.Point(387, 91)
        Me.obj_season_id.Name = "obj_season_id"
        Me.obj_season_id.ReadOnly = True
        Me.obj_season_id.Size = New System.Drawing.Size(52, 20)
        Me.obj_season_id.TabIndex = 29
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(4, 180)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 20)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Propose"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_inventorymovingdetil_qtypropose
        '
        Me.obj_inventorymovingdetil_qtypropose.BackColor = System.Drawing.Color.White
        Me.obj_inventorymovingdetil_qtypropose.Location = New System.Drawing.Point(90, 180)
        Me.obj_inventorymovingdetil_qtypropose.Name = "obj_inventorymovingdetil_qtypropose"
        Me.obj_inventorymovingdetil_qtypropose.Size = New System.Drawing.Size(53, 20)
        Me.obj_inventorymovingdetil_qtypropose.TabIndex = 31
        Me.obj_inventorymovingdetil_qtypropose.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(4, 206)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 20)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "Init"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_inventorymovingdetil_qtyinit
        '
        Me.obj_inventorymovingdetil_qtyinit.BackColor = System.Drawing.Color.White
        Me.obj_inventorymovingdetil_qtyinit.Location = New System.Drawing.Point(90, 206)
        Me.obj_inventorymovingdetil_qtyinit.Name = "obj_inventorymovingdetil_qtyinit"
        Me.obj_inventorymovingdetil_qtyinit.Size = New System.Drawing.Size(53, 20)
        Me.obj_inventorymovingdetil_qtyinit.TabIndex = 33
        Me.obj_inventorymovingdetil_qtyinit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(4, 232)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 20)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "Qty"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_inventorymovingdetil_qty
        '
        Me.obj_inventorymovingdetil_qty.BackColor = System.Drawing.Color.White
        Me.obj_inventorymovingdetil_qty.Location = New System.Drawing.Point(90, 232)
        Me.obj_inventorymovingdetil_qty.Name = "obj_inventorymovingdetil_qty"
        Me.obj_inventorymovingdetil_qty.Size = New System.Drawing.Size(53, 20)
        Me.obj_inventorymovingdetil_qty.TabIndex = 35
        Me.obj_inventorymovingdetil_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_inventorymovingdetil_idr
        '
        Me.lbl_inventorymovingdetil_idr.Location = New System.Drawing.Point(4, 270)
        Me.lbl_inventorymovingdetil_idr.Name = "lbl_inventorymovingdetil_idr"
        Me.lbl_inventorymovingdetil_idr.Size = New System.Drawing.Size(80, 20)
        Me.lbl_inventorymovingdetil_idr.TabIndex = 38
        Me.lbl_inventorymovingdetil_idr.Text = "Value (IDR)"
        Me.lbl_inventorymovingdetil_idr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_inventorymovingdetil_idr
        '
        Me.obj_inventorymovingdetil_idr.BackColor = System.Drawing.Color.White
        Me.obj_inventorymovingdetil_idr.Location = New System.Drawing.Point(90, 270)
        Me.obj_inventorymovingdetil_idr.Name = "obj_inventorymovingdetil_idr"
        Me.obj_inventorymovingdetil_idr.Size = New System.Drawing.Size(162, 20)
        Me.obj_inventorymovingdetil_idr.TabIndex = 37
        Me.obj_inventorymovingdetil_idr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(331, 65)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 20)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Unit"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_iteminventoryunit_id
        '
        Me.obj_iteminventoryunit_id.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_iteminventoryunit_id.Location = New System.Drawing.Point(387, 65)
        Me.obj_iteminventoryunit_id.Name = "obj_iteminventoryunit_id"
        Me.obj_iteminventoryunit_id.ReadOnly = True
        Me.obj_iteminventoryunit_id.Size = New System.Drawing.Size(52, 20)
        Me.obj_iteminventoryunit_id.TabIndex = 39
        '
        'btnOpenItem
        '
        Me.btnOpenItem.Location = New System.Drawing.Point(229, 37)
        Me.btnOpenItem.Name = "btnOpenItem"
        Me.btnOpenItem.Size = New System.Drawing.Size(25, 22)
        Me.btnOpenItem.TabIndex = 41
        Me.btnOpenItem.Text = "..."
        Me.btnOpenItem.UseVisualStyleBackColor = True
        '
        'obj_inventorymovingdetil_descr
        '
        Me.obj_inventorymovingdetil_descr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_inventorymovingdetil_descr.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.obj_inventorymovingdetil_descr.Location = New System.Drawing.Point(264, 38)
        Me.obj_inventorymovingdetil_descr.Name = "obj_inventorymovingdetil_descr"
        Me.obj_inventorymovingdetil_descr.Size = New System.Drawing.Size(340, 20)
        Me.obj_inventorymovingdetil_descr.TabIndex = 42
        Me.obj_inventorymovingdetil_descr.Text = "Item Name"
        Me.obj_inventorymovingdetil_descr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dlgTrnInventorymovingDetilItemNewrow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(626, 442)
        Me.Controls.Add(Me.obj_inventorymovingdetil_descr)
        Me.Controls.Add(Me.btnOpenItem)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.obj_iteminventoryunit_id)
        Me.Controls.Add(Me.lbl_inventorymovingdetil_idr)
        Me.Controls.Add(Me.obj_inventorymovingdetil_idr)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.obj_inventorymovingdetil_qty)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.obj_inventorymovingdetil_qtyinit)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.obj_inventorymovingdetil_qtypropose)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.obj_season_id)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.obj_iteminventorysubgroup_id)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.obj_iteminventorygroup_id)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.obj_inventorymovingdetil_size)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.obj_inventorymovingdetil_col)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.obj_inventorymovingdetil_mat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.obj_inventorymovingdetil_article)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.obj_iteminventory_id)
        Me.Controls.Add(Me.lbl_inventorymoving_id)
        Me.Controls.Add(Me.obj_inventorymovingdetil_line)
        Me.Name = "dlgTrnInventorymovingDetilItemNewrow"
        Me.Controls.SetChildIndex(Me.obj_inventorymovingdetil_line, 0)
        Me.Controls.SetChildIndex(Me.lbl_inventorymoving_id, 0)
        Me.Controls.SetChildIndex(Me.obj_iteminventory_id, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.obj_inventorymovingdetil_article, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.obj_inventorymovingdetil_mat, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.obj_inventorymovingdetil_col, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.obj_inventorymovingdetil_size, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.obj_iteminventorygroup_id, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.obj_iteminventorysubgroup_id, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.obj_season_id, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.obj_inventorymovingdetil_qtypropose, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.obj_inventorymovingdetil_qtyinit, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.obj_inventorymovingdetil_qty, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.obj_inventorymovingdetil_idr, 0)
        Me.Controls.SetChildIndex(Me.lbl_inventorymovingdetil_idr, 0)
        Me.Controls.SetChildIndex(Me.obj_iteminventoryunit_id, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.btnOpenItem, 0)
        Me.Controls.SetChildIndex(Me.obj_inventorymovingdetil_descr, 0)
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_inventorymoving_id As System.Windows.Forms.Label
    Friend WithEvents obj_inventorymovingdetil_line As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_iteminventory_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_inventorymovingdetil_article As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents obj_inventorymovingdetil_mat As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents obj_inventorymovingdetil_col As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents obj_inventorymovingdetil_size As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents obj_iteminventorygroup_id As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents obj_iteminventorysubgroup_id As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents obj_season_id As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents obj_inventorymovingdetil_qtypropose As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents obj_inventorymovingdetil_qtyinit As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents obj_inventorymovingdetil_qty As System.Windows.Forms.TextBox
    Friend WithEvents lbl_inventorymovingdetil_idr As System.Windows.Forms.Label
    Friend WithEvents obj_inventorymovingdetil_idr As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents obj_iteminventoryunit_id As System.Windows.Forms.TextBox
    Friend WithEvents btnOpenItem As System.Windows.Forms.Button
    Friend WithEvents obj_inventorymovingdetil_descr As System.Windows.Forms.Label

End Class
