<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgCustomerEdit
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
        Me.obj_CustomerName = New System.Windows.Forms.TextBox
        Me.obj_CustomerTelp = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_Ok = New System.Windows.Forms.Button
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.obj_CustomerEmail = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnCustomerSearch = New System.Windows.Forms.LinkLabel
        Me.obj_CustomerId = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.obj_CustomerType = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'obj_CustomerName
        '
        Me.obj_CustomerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.obj_CustomerName.Location = New System.Drawing.Point(66, 58)
        Me.obj_CustomerName.MaxLength = 30
        Me.obj_CustomerName.Name = "obj_CustomerName"
        Me.obj_CustomerName.Size = New System.Drawing.Size(207, 20)
        Me.obj_CustomerName.TabIndex = 1
        '
        'obj_CustomerTelp
        '
        Me.obj_CustomerTelp.Location = New System.Drawing.Point(66, 109)
        Me.obj_CustomerTelp.MaxLength = 15
        Me.obj_CustomerTelp.Name = "obj_CustomerTelp"
        Me.obj_CustomerTelp.Size = New System.Drawing.Size(207, 20)
        Me.obj_CustomerTelp.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Telp"
        '
        'btn_Ok
        '
        Me.btn_Ok.Location = New System.Drawing.Point(176, 175)
        Me.btn_Ok.Name = "btn_Ok"
        Me.btn_Ok.Size = New System.Drawing.Size(75, 23)
        Me.btn_Ok.TabIndex = 4
        Me.btn_Ok.Text = "OK"
        Me.btn_Ok.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(95, 175)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 5
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Email"
        '
        'obj_CustomerEmail
        '
        Me.obj_CustomerEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.obj_CustomerEmail.Location = New System.Drawing.Point(66, 135)
        Me.obj_CustomerEmail.MaxLength = 100
        Me.obj_CustomerEmail.Name = "obj_CustomerEmail"
        Me.obj_CustomerEmail.Size = New System.Drawing.Size(207, 20)
        Me.obj_CustomerEmail.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(135, 82)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(115, 12)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = ")* harus terkoneksi internet"
        '
        'btnCustomerSearch
        '
        Me.btnCustomerSearch.AutoSize = True
        Me.btnCustomerSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCustomerSearch.Location = New System.Drawing.Point(63, 81)
        Me.btnCustomerSearch.Name = "btnCustomerSearch"
        Me.btnCustomerSearch.Size = New System.Drawing.Size(72, 13)
        Me.btnCustomerSearch.TabIndex = 31
        Me.btnCustomerSearch.TabStop = True
        Me.btnCustomerSearch.Text = "Cari Customer"
        '
        'obj_CustomerId
        '
        Me.obj_CustomerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.obj_CustomerId.Location = New System.Drawing.Point(66, 12)
        Me.obj_CustomerId.MaxLength = 30
        Me.obj_CustomerId.Name = "obj_CustomerId"
        Me.obj_CustomerId.ReadOnly = True
        Me.obj_CustomerId.Size = New System.Drawing.Size(142, 20)
        Me.obj_CustomerId.TabIndex = 33
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Id"
        '
        'obj_CustomerType
        '
        Me.obj_CustomerType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.obj_CustomerType.Location = New System.Drawing.Point(214, 12)
        Me.obj_CustomerType.MaxLength = 30
        Me.obj_CustomerType.Name = "obj_CustomerType"
        Me.obj_CustomerType.ReadOnly = True
        Me.obj_CustomerType.Size = New System.Drawing.Size(59, 20)
        Me.obj_CustomerType.TabIndex = 35
        '
        'dlgCustomerEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(294, 219)
        Me.Controls.Add(Me.obj_CustomerType)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.obj_CustomerId)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnCustomerSearch)
        Me.Controls.Add(Me.obj_CustomerEmail)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Ok)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.obj_CustomerTelp)
        Me.Controls.Add(Me.obj_CustomerName)
        Me.Name = "dlgCustomerEdit"
        Me.Text = "dlgCustomerEdit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents obj_CustomerName As System.Windows.Forms.TextBox
    Friend WithEvents obj_CustomerTelp As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_Ok As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents obj_CustomerEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnCustomerSearch As System.Windows.Forms.LinkLabel
    Friend WithEvents obj_CustomerId As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents obj_CustomerType As System.Windows.Forms.TextBox
End Class
