<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgDonasi
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.objDonasi = New System.Windows.Forms.TextBox()
        Me.btnOk = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(197, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Donasi"
        '
        'objDonasi
        '
        Me.objDonasi.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objDonasi.Location = New System.Drawing.Point(106, 102)
        Me.objDonasi.Name = "objDonasi"
        Me.objDonasi.Size = New System.Drawing.Size(289, 35)
        Me.objDonasi.TabIndex = 2
        Me.objDonasi.Text = "0"
        Me.objDonasi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.Color.LightGray
        Me.btnOk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Location = New System.Drawing.Point(190, 191)
        Me.btnOk.Margin = New System.Windows.Forms.Padding(0)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(121, 29)
        Me.btnOk.TabIndex = 30
        Me.btnOk.Text = "OK [Enter]"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dlgDonasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 258)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.objDonasi)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgDonasi"
        Me.Text = "Donasi"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents objDonasi As TextBox
    Friend WithEvents btnOk As Label
End Class
