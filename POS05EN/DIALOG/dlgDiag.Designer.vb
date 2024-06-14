<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgDiag
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
        Me.btn_QRGenerateTest = New System.Windows.Forms.Button
        Me.btn_Test2ndMonitor = New System.Windows.Forms.Button
        Me.btn_ReadPromo = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btn_QRGenerateTest
        '
        Me.btn_QRGenerateTest.Location = New System.Drawing.Point(36, 114)
        Me.btn_QRGenerateTest.Name = "btn_QRGenerateTest"
        Me.btn_QRGenerateTest.Size = New System.Drawing.Size(130, 30)
        Me.btn_QRGenerateTest.TabIndex = 0
        Me.btn_QRGenerateTest.Text = "QR Generate Test"
        Me.btn_QRGenerateTest.UseVisualStyleBackColor = True
        '
        'btn_Test2ndMonitor
        '
        Me.btn_Test2ndMonitor.Location = New System.Drawing.Point(36, 63)
        Me.btn_Test2ndMonitor.Name = "btn_Test2ndMonitor"
        Me.btn_Test2ndMonitor.Size = New System.Drawing.Size(130, 30)
        Me.btn_Test2ndMonitor.TabIndex = 1
        Me.btn_Test2ndMonitor.Text = "Test 2nd Monitor"
        Me.btn_Test2ndMonitor.UseVisualStyleBackColor = True
        '
        'btn_ReadPromo
        '
        Me.btn_ReadPromo.Location = New System.Drawing.Point(36, 202)
        Me.btn_ReadPromo.Name = "btn_ReadPromo"
        Me.btn_ReadPromo.Size = New System.Drawing.Size(130, 30)
        Me.btn_ReadPromo.TabIndex = 2
        Me.btn_ReadPromo.Text = "Read Promo"
        Me.btn_ReadPromo.UseVisualStyleBackColor = True
        '
        'dlgDiag
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 396)
        Me.Controls.Add(Me.btn_ReadPromo)
        Me.Controls.Add(Me.btn_Test2ndMonitor)
        Me.Controls.Add(Me.btn_QRGenerateTest)
        Me.Name = "dlgDiag"
        Me.Text = "Diagnostic"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_QRGenerateTest As System.Windows.Forms.Button
    Friend WithEvents btn_Test2ndMonitor As System.Windows.Forms.Button
    Friend WithEvents btn_ReadPromo As System.Windows.Forms.Button
End Class
