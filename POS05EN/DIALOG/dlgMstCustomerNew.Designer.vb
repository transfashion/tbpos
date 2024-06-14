<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgMstCustomerNew
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.DgvRegion = New System.Windows.Forms.DataGridView
        Me.lblRegion = New System.Windows.Forms.Label
        Me.lblType = New System.Windows.Forms.Label
        Me.rdbCompany = New System.Windows.Forms.RadioButton
        Me.rdbPersonal = New System.Windows.Forms.RadioButton
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        CType(Me.DgvRegion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(488, 13)
        Me.Panel1.TabIndex = 1
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.DgvRegion)
        Me.pnlMain.Controls.Add(Me.lblRegion)
        Me.pnlMain.Controls.Add(Me.lblType)
        Me.pnlMain.Controls.Add(Me.rdbCompany)
        Me.pnlMain.Controls.Add(Me.rdbPersonal)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 13)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(488, 300)
        Me.pnlMain.TabIndex = 3
        '
        'DgvRegion
        '
        Me.DgvRegion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRegion.Location = New System.Drawing.Point(102, 84)
        Me.DgvRegion.Name = "DgvRegion"
        Me.DgvRegion.Size = New System.Drawing.Size(374, 210)
        Me.DgvRegion.TabIndex = 4
        '
        'lblRegion
        '
        Me.lblRegion.Location = New System.Drawing.Point(31, 84)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(56, 15)
        Me.lblRegion.TabIndex = 3
        Me.lblRegion.Text = "Region"
        Me.lblRegion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblType
        '
        Me.lblType.Location = New System.Drawing.Point(31, 19)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(56, 15)
        Me.lblType.TabIndex = 2
        Me.lblType.Text = "Type"
        Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rdbCompany
        '
        Me.rdbCompany.AutoSize = True
        Me.rdbCompany.Location = New System.Drawing.Point(102, 42)
        Me.rdbCompany.Name = "rdbCompany"
        Me.rdbCompany.Size = New System.Drawing.Size(78, 17)
        Me.rdbCompany.TabIndex = 1
        Me.rdbCompany.Text = "COMPANY"
        Me.rdbCompany.UseVisualStyleBackColor = True
        '
        'rdbPersonal
        '
        Me.rdbPersonal.AutoSize = True
        Me.rdbPersonal.Checked = True
        Me.rdbPersonal.Location = New System.Drawing.Point(102, 19)
        Me.rdbPersonal.Name = "rdbPersonal"
        Me.rdbPersonal.Size = New System.Drawing.Size(83, 17)
        Me.rdbPersonal.TabIndex = 0
        Me.rdbPersonal.TabStop = True
        Me.rdbPersonal.Text = "PERSONAL"
        Me.rdbPersonal.UseVisualStyleBackColor = True
        '
        'dlgMstCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(488, 352)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "dlgMstCustomer"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.pnlMain, 0)
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        CType(Me.DgvRegion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents rdbCompany As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPersonal As System.Windows.Forms.RadioButton
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents lblRegion As System.Windows.Forms.Label
    Friend WithEvents DgvRegion As System.Windows.Forms.DataGridView

End Class
