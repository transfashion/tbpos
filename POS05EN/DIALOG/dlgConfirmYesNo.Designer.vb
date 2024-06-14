<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgConfirmYesNo
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
        Me.objText = New System.Windows.Forms.Label
        Me.lblNo = New System.Windows.Forms.Label
        Me.lblYES = New System.Windows.Forms.Label
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlFormMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlFormMain
        '
        Me.PnlFormMain.Controls.Add(Me.lblNo)
        Me.PnlFormMain.Controls.Add(Me.lblYES)
        Me.PnlFormMain.Controls.Add(Me.objText)
        Me.PnlFormMain.Location = New System.Drawing.Point(1, 3)
        Me.PnlFormMain.Name = "PnlFormMain"
        Me.PnlFormMain.Size = New System.Drawing.Size(364, 97)
        Me.PnlFormMain.TabIndex = 3
        '
        'objText
        '
        Me.objText.BackColor = System.Drawing.Color.Transparent
        Me.objText.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objText.Location = New System.Drawing.Point(21, 9)
        Me.objText.Name = "objText"
        Me.objText.Size = New System.Drawing.Size(331, 61)
        Me.objText.TabIndex = 2
        Me.objText.Text = "Hapus Data ?"
        '
        'lblNo
        '
        Me.lblNo.AutoSize = True
        Me.lblNo.BackColor = System.Drawing.Color.Transparent
        Me.lblNo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNo.Location = New System.Drawing.Point(194, 70)
        Me.lblNo.Name = "lblNo"
        Me.lblNo.Size = New System.Drawing.Size(77, 25)
        Me.lblNo.TabIndex = 1
        Me.lblNo.Text = "&TIDAK"
        '
        'lblYES
        '
        Me.lblYES.AutoSize = True
        Me.lblYES.BackColor = System.Drawing.Color.Transparent
        Me.lblYES.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblYES.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYES.Location = New System.Drawing.Point(97, 70)
        Me.lblYES.Name = "lblYES"
        Me.lblYES.Size = New System.Drawing.Size(41, 25)
        Me.lblYES.TabIndex = 0
        Me.lblYES.Text = "&YA"
        '
        'dlgConfirmYesNo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(365, 139)
        Me.Controls.Add(Me.PnlFormMain)
        Me.Name = "dlgConfirmYesNo"
        Me.Controls.SetChildIndex(Me.PnlFormMain, 0)
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlFormMain.ResumeLayout(False)
        Me.PnlFormMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlFormMain As System.Windows.Forms.Panel
    Friend WithEvents lblYES As System.Windows.Forms.Label
    Friend WithEvents lblNo As System.Windows.Forms.Label
    Friend WithEvents objText As System.Windows.Forms.Label

End Class
