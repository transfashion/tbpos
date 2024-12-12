<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgConfirmSize
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
        Me.DgvSizing = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblOK = New System.Windows.Forms.Label
        Me.txtEntry = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.objSizetag = New System.Windows.Forms.Label
        Me.objColname = New System.Windows.Forms.Label
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlFormMain.SuspendLayout()
        CType(Me.DgvSizing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnlFormMain
        '
        Me.PnlFormMain.Controls.Add(Me.objColname)
        Me.PnlFormMain.Controls.Add(Me.objSizetag)
        Me.PnlFormMain.Controls.Add(Me.DgvSizing)
        Me.PnlFormMain.Controls.Add(Me.Label3)
        Me.PnlFormMain.Controls.Add(Me.Label2)
        Me.PnlFormMain.Controls.Add(Me.lblOK)
        Me.PnlFormMain.Controls.Add(Me.txtEntry)
        Me.PnlFormMain.Controls.Add(Me.Label1)
        Me.PnlFormMain.Location = New System.Drawing.Point(1, 3)
        Me.PnlFormMain.Name = "PnlFormMain"
        Me.PnlFormMain.Size = New System.Drawing.Size(718, 406)
        Me.PnlFormMain.TabIndex = 3
        '
        'DgvSizing
        '
        Me.DgvSizing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvSizing.Location = New System.Drawing.Point(24, 154)
        Me.DgvSizing.Name = "DgvSizing"
        Me.DgvSizing.Size = New System.Drawing.Size(684, 235)
        Me.DgvSizing.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(241, 24)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "NAME $$$$$ $$$$$ $$$$$$"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(212, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "ARTICLE $$$ $$$ $$$"
        '
        'lblOK
        '
        Me.lblOK.BackColor = System.Drawing.Color.DarkGray
        Me.lblOK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOK.Location = New System.Drawing.Point(182, 100)
        Me.lblOK.Name = "lblOK"
        Me.lblOK.Size = New System.Drawing.Size(53, 26)
        Me.lblOK.TabIndex = 2
        Me.lblOK.Text = "OK"
        Me.lblOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtEntry
        '
        Me.txtEntry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEntry.Location = New System.Drawing.Point(76, 100)
        Me.txtEntry.MaxLength = 5
        Me.txtEntry.Name = "txtEntry"
        Me.txtEntry.ReadOnly = True
        Me.txtEntry.Size = New System.Drawing.Size(100, 26)
        Me.txtEntry.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SIZE"
        '
        'objSizetag
        '
        Me.objSizetag.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objSizetag.Location = New System.Drawing.Point(601, 106)
        Me.objSizetag.Name = "objSizetag"
        Me.objSizetag.Size = New System.Drawing.Size(50, 20)
        Me.objSizetag.TabIndex = 6
        Me.objSizetag.Text = "Sizetag"
        '
        'objColname
        '
        Me.objColname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objColname.Location = New System.Drawing.Point(657, 106)
        Me.objColname.Name = "objColname"
        Me.objColname.Size = New System.Drawing.Size(50, 20)
        Me.objColname.TabIndex = 7
        Me.objColname.Text = "Colname"
        '
        'dlgConfirmSize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(720, 468)
        Me.Controls.Add(Me.PnlFormMain)
        Me.Name = "dlgConfirmSize"
        Me.Controls.SetChildIndex(Me.PnlFormMain, 0)
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlFormMain.ResumeLayout(False)
        Me.PnlFormMain.PerformLayout()
        CType(Me.DgvSizing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlFormMain As System.Windows.Forms.Panel
    Friend WithEvents txtEntry As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblOK As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DgvSizing As System.Windows.Forms.DataGridView
    Friend WithEvents objColname As System.Windows.Forms.Label
    Friend WithEvents objSizetag As System.Windows.Forms.Label

End Class
