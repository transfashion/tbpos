<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgItemSelect
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
        Me.PnlFormMain = New System.Windows.Forms.Panel
        Me.DgvItem = New System.Windows.Forms.DataGridView
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlFormMain.SuspendLayout()
        CType(Me.DgvItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnlFormMain
        '
        Me.PnlFormMain.Controls.Add(Me.DgvItem)
        Me.PnlFormMain.Location = New System.Drawing.Point(22, 12)
        Me.PnlFormMain.Name = "PnlFormMain"
        Me.PnlFormMain.Size = New System.Drawing.Size(708, 382)
        Me.PnlFormMain.TabIndex = 3
        '
        'DgvItem
        '
        Me.DgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvItem.Location = New System.Drawing.Point(27, 82)
        Me.DgvItem.Name = "DgvItem"
        Me.DgvItem.Size = New System.Drawing.Size(653, 272)
        Me.DgvItem.TabIndex = 0
        '
        'dlgItemSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(825, 509)
        Me.Controls.Add(Me.PnlFormMain)
        Me.Name = "dlgItemSelect"
        Me.Controls.SetChildIndex(Me.PnlFormMain, 0)
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlFormMain.ResumeLayout(False)
        CType(Me.DgvItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlFormMain As System.Windows.Forms.Panel
    Friend WithEvents DgvItem As System.Windows.Forms.DataGridView

End Class
