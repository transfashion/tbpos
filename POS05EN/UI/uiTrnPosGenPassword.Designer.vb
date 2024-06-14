<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnPosGenPassword
    Inherits Translib.uiBase

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
        Me.btnPasswordGenerate = New System.Windows.Forms.Button
        Me.obj_region_id = New System.Windows.Forms.TextBox
        Me.obj_branch_id = New System.Windows.Forms.TextBox
        Me.password = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        CType(Me.dsMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bgwListLoader
        '
        Me.bgwListLoader.WorkerReportsProgress = True
        Me.bgwListLoader.WorkerSupportsCancellation = True
        '
        'bgwDataLoader
        '
        Me.bgwDataLoader.WorkerReportsProgress = True
        Me.bgwDataLoader.WorkerSupportsCancellation = True
        '
        'bgwSave
        '
        Me.bgwSave.WorkerReportsProgress = True
        Me.bgwSave.WorkerSupportsCancellation = True
        '
        'bgwNew
        '
        Me.bgwNew.WorkerReportsProgress = True
        Me.bgwNew.WorkerSupportsCancellation = True
        '
        'bgwMasterLoaderQueue
        '
        Me.bgwMasterLoaderQueue.WorkerReportsProgress = True
        Me.bgwMasterLoaderQueue.WorkerSupportsCancellation = True
        '
        'bgwMasterLoader
        '
        Me.bgwMasterLoader.WorkerReportsProgress = True
        Me.bgwMasterLoader.WorkerSupportsCancellation = True
        '
        'bgwPrintLoader
        '
        Me.bgwPrintLoader.WorkerReportsProgress = True
        Me.bgwPrintLoader.WorkerSupportsCancellation = True
        '
        'bgwPrintWeb
        '
        Me.bgwPrintWeb.WorkerReportsProgress = True
        Me.bgwPrintWeb.WorkerSupportsCancellation = True
        '
        'bgwDelete
        '
        Me.bgwDelete.WorkerReportsProgress = True
        Me.bgwDelete.WorkerSupportsCancellation = True
        '
        'fLoadingIndicator
        '
        Me.fLoadingIndicator.Location = New System.Drawing.Point(44, 58)
        Me.fLoadingIndicator.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        '
        'btnPasswordGenerate
        '
        Me.btnPasswordGenerate.Location = New System.Drawing.Point(30, 93)
        Me.btnPasswordGenerate.Name = "btnPasswordGenerate"
        Me.btnPasswordGenerate.Size = New System.Drawing.Size(157, 23)
        Me.btnPasswordGenerate.TabIndex = 1
        Me.btnPasswordGenerate.Text = "Generate Password"
        Me.btnPasswordGenerate.UseVisualStyleBackColor = True
        '
        'obj_region_id
        '
        Me.obj_region_id.Location = New System.Drawing.Point(30, 56)
        Me.obj_region_id.MaxLength = 5
        Me.obj_region_id.Name = "obj_region_id"
        Me.obj_region_id.Size = New System.Drawing.Size(100, 20)
        Me.obj_region_id.TabIndex = 2
        '
        'obj_branch_id
        '
        Me.obj_branch_id.Location = New System.Drawing.Point(136, 56)
        Me.obj_branch_id.MaxLength = 7
        Me.obj_branch_id.Name = "obj_branch_id"
        Me.obj_branch_id.Size = New System.Drawing.Size(168, 20)
        Me.obj_branch_id.TabIndex = 3
        '
        'password
        '
        Me.password.AutoSize = True
        Me.password.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.password.Location = New System.Drawing.Point(220, 99)
        Me.password.Name = "password"
        Me.password.Size = New System.Drawing.Size(57, 17)
        Me.password.TabIndex = 4
        Me.password.Text = "Label1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "RegionId"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(133, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "BranchId"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Location = New System.Drawing.Point(482, 180)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(48, 44)
        Me.Panel1.TabIndex = 7
        '
        'uiTrnPosGenPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackgroundworkerStatus = Translib.uiBase.EBackgroundworkerStatus.Done
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.password)
        Me.Controls.Add(Me.obj_branch_id)
        Me.Controls.Add(Me.btnPasswordGenerate)
        Me.Controls.Add(Me.obj_region_id)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Message = "Done. "
        Me.Name = "uiTrnPosGenPassword"
        Me.Progress = 20
        Me.Status = "Loading Data..."
        Me.Controls.SetChildIndex(Me.obj_region_id, 0)
        Me.Controls.SetChildIndex(Me.btnPasswordGenerate, 0)
        Me.Controls.SetChildIndex(Me.obj_branch_id, 0)
        Me.Controls.SetChildIndex(Me.password, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        CType(Me.dsMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPasswordGenerate As System.Windows.Forms.Button
    Friend WithEvents obj_region_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_branch_id As System.Windows.Forms.TextBox
    Friend WithEvents password As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
