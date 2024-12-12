<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnPosDataBrowse
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
        Me.Label9 = New System.Windows.Forms.Label
        Me.objSelectedId = New System.Windows.Forms.TextBox
        Me.pnlSearchCriteria = New System.Windows.Forms.Panel
        Me.objId = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.objName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.DgvResult = New System.Windows.Forms.DataGridView
        Me.lblSelected = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.objSelectedName = New System.Windows.Forms.Label
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlFormMain.SuspendLayout()
        Me.pnlSearchCriteria.SuspendLayout()
        CType(Me.DgvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnlFormMain
        '
        Me.PnlFormMain.Controls.Add(Me.Label9)
        Me.PnlFormMain.Controls.Add(Me.objSelectedId)
        Me.PnlFormMain.Controls.Add(Me.pnlSearchCriteria)
        Me.PnlFormMain.Controls.Add(Me.Label5)
        Me.PnlFormMain.Controls.Add(Me.DgvResult)
        Me.PnlFormMain.Controls.Add(Me.lblSelected)
        Me.PnlFormMain.Controls.Add(Me.lblTitle)
        Me.PnlFormMain.Controls.Add(Me.objSelectedName)
        Me.PnlFormMain.Location = New System.Drawing.Point(1, 3)
        Me.PnlFormMain.Name = "PnlFormMain"
        Me.PnlFormMain.Size = New System.Drawing.Size(459, 449)
        Me.PnlFormMain.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.DarkGray
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(27, 133)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(405, 1)
        Me.Label9.TabIndex = 14
        '
        'objSelectedId
        '
        Me.objSelectedId.Enabled = False
        Me.objSelectedId.Location = New System.Drawing.Point(10, 114)
        Me.objSelectedId.Name = "objSelectedId"
        Me.objSelectedId.ReadOnly = True
        Me.objSelectedId.Size = New System.Drawing.Size(100, 20)
        Me.objSelectedId.TabIndex = 13
        '
        'pnlSearchCriteria
        '
        Me.pnlSearchCriteria.Controls.Add(Me.objId)
        Me.pnlSearchCriteria.Controls.Add(Me.Label4)
        Me.pnlSearchCriteria.Controls.Add(Me.Label3)
        Me.pnlSearchCriteria.Controls.Add(Me.objName)
        Me.pnlSearchCriteria.Location = New System.Drawing.Point(6, 32)
        Me.pnlSearchCriteria.Name = "pnlSearchCriteria"
        Me.pnlSearchCriteria.Size = New System.Drawing.Size(443, 60)
        Me.pnlSearchCriteria.TabIndex = 11
        '
        'objId
        '
        Me.objId.AutoSize = True
        Me.objId.Location = New System.Drawing.Point(58, 14)
        Me.objId.Name = "objId"
        Me.objId.Size = New System.Drawing.Size(62, 13)
        Me.objId.TabIndex = 10
        Me.objId.Text = "IDIDIDIDID"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(7, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Name"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'objName
        '
        Me.objName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.objName.Location = New System.Drawing.Point(57, 33)
        Me.objName.Name = "objName"
        Me.objName.Size = New System.Drawing.Size(383, 20)
        Me.objName.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 153)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Result"
        '
        'DgvResult
        '
        Me.DgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvResult.Location = New System.Drawing.Point(10, 171)
        Me.DgvResult.Name = "DgvResult"
        Me.DgvResult.Size = New System.Drawing.Size(439, 275)
        Me.DgvResult.TabIndex = 7
        '
        'lblSelected
        '
        Me.lblSelected.AutoSize = True
        Me.lblSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelected.Location = New System.Drawing.Point(7, 98)
        Me.lblSelected.Name = "lblSelected"
        Me.lblSelected.Size = New System.Drawing.Size(57, 13)
        Me.lblSelected.TabIndex = 3
        Me.lblSelected.Text = "Selected"
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.BackColor = System.Drawing.Color.Black
        Me.lblTitle.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(3, 2)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(453, 18)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = ":: Browse ::"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'objSelectedName
        '
        Me.objSelectedName.AutoSize = True
        Me.objSelectedName.Location = New System.Drawing.Point(114, 118)
        Me.objSelectedName.Name = "objSelectedName"
        Me.objSelectedName.Size = New System.Drawing.Size(100, 13)
        Me.objSelectedName.TabIndex = 1
        Me.objSelectedName.Text = "NAMENAMENAME"
        '
        'dlgTrnPosDataBrowse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(462, 494)
        Me.Controls.Add(Me.PnlFormMain)
        Me.Name = "dlgTrnPosDataBrowse"
        Me.Controls.SetChildIndex(Me.PnlFormMain, 0)
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlFormMain.ResumeLayout(False)
        Me.PnlFormMain.PerformLayout()
        Me.pnlSearchCriteria.ResumeLayout(False)
        Me.pnlSearchCriteria.PerformLayout()
        CType(Me.DgvResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlFormMain As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents objName As System.Windows.Forms.TextBox
    Friend WithEvents lblSelected As System.Windows.Forms.Label
    Friend WithEvents objSelectedName As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DgvResult As System.Windows.Forms.DataGridView
    Friend WithEvents objId As System.Windows.Forms.Label
    Friend WithEvents pnlSearchCriteria As System.Windows.Forms.Panel
    Friend WithEvents objSelectedId As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label

End Class
