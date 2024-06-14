<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTfiMemberScan
    Inherits System.Windows.Forms.Form

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
        Me.txt_Telp = New System.Windows.Forms.Label
        Me.txt_Nama = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_Line = New System.Windows.Forms.TextBox
        Me.btn_Submit = New System.Windows.Forms.Label
        Me.btnOk = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txt_Telp
        '
        Me.txt_Telp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Telp.Location = New System.Drawing.Point(125, 199)
        Me.txt_Telp.Name = "txt_Telp"
        Me.txt_Telp.Size = New System.Drawing.Size(381, 23)
        Me.txt_Telp.TabIndex = 25
        Me.txt_Telp.Text = "txt_Telp"
        Me.txt_Telp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_Nama
        '
        Me.txt_Nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Nama.Location = New System.Drawing.Point(125, 160)
        Me.txt_Nama.Name = "txt_Nama"
        Me.txt_Nama.Size = New System.Drawing.Size(381, 23)
        Me.txt_Nama.TabIndex = 24
        Me.txt_Nama.Text = "txt_Nama"
        Me.txt_Nama.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(19, 200)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "No Telp"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Nama"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Line
        '
        Me.txt_Line.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Line.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Line.Location = New System.Drawing.Point(22, 99)
        Me.txt_Line.Name = "txt_Line"
        Me.txt_Line.Size = New System.Drawing.Size(457, 26)
        Me.txt_Line.TabIndex = 21
        '
        'btn_Submit
        '
        Me.btn_Submit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Submit.BackColor = System.Drawing.Color.LightGray
        Me.btn_Submit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btn_Submit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Submit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Submit.Location = New System.Drawing.Point(493, 99)
        Me.btn_Submit.Name = "btn_Submit"
        Me.btn_Submit.Padding = New System.Windows.Forms.Padding(2)
        Me.btn_Submit.Size = New System.Drawing.Size(78, 26)
        Me.btn_Submit.TabIndex = 20
        Me.btn_Submit.Text = "Submit"
        Me.btn_Submit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_Submit.Visible = False
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackColor = System.Drawing.Color.LightGray
        Me.btnOk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Location = New System.Drawing.Point(135, 311)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Padding = New System.Windows.Forms.Padding(2)
        Me.btnOk.Size = New System.Drawing.Size(167, 26)
        Me.btnOk.TabIndex = 19
        Me.btnOk.Text = "F10 - OK"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.LightGray
        Me.btnCancel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(308, 311)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Size = New System.Drawing.Size(167, 26)
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.Text = "ESC - Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(381, 23)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Scan QR member dari Customer"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dlgTfiMemberScan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 359)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_Telp)
        Me.Controls.Add(Me.txt_Nama)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_Line)
        Me.Controls.Add(Me.btn_Submit)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "dlgTfiMemberScan"
        Me.Text = "dlgTfiMemberScan"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_Telp As System.Windows.Forms.Label
    Friend WithEvents txt_Nama As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_Line As System.Windows.Forms.TextBox
    Friend WithEvents btn_Submit As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
