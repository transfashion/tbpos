Public Class dlgConfirmSize

    Dim myRetObj As Object
    Dim ActiveButton As String = "NO"

    Private mBeepOnOK As Boolean = True
    Private tblSizing As DataTable


#Region " Constructor "

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, ByVal args As Object) As Object

        ' Me.SuspendLayout()

        Try

            Dim art As String = args(0)
            Dim mat As String = args(1)
            Dim col As String = args(2)
            Dim des As String = args(3)
            Dim tbl As DataTable = args(4)


            Me.Label2.Text = art & "  " & mat & "  " & col
            Me.Label3.Text = des

            Me.Label2.AutoSize = True
            Me.Label2.Refresh()

            Me.Label3.AutoSize = True
            Me.Label3.Refresh()


            tblSizing = tbl


            uiTrnPosEN.FormatDgvPOSSizeSelect(Me.DgvSizing)
            Me.DgvSizing.DataSource = Me.tblSizing




        Catch ex As Exception
            Me.Close()
            Throw ex
        End Try

        MyBase.ShowDialog(owner)
        Return myRetObj
    End Function

#End Region

#Region " Listener "

    Public Function KeyCheck(ByVal sender As Object, ByVal keycode As System.Windows.Forms.Keys, ByVal keyvalue As Integer, ByVal ctrl As Boolean, ByRef suppressglobalkeyprocess As Boolean, ByRef SuppressKeyPress As Boolean) As Boolean
        Dim obj As Control = sender
        Select Case obj.Name
        End Select
        Return True
    End Function


    Public Function Key(ByVal sender As Object, ByVal keycode As System.Windows.Forms.Keys, ByVal ctrl As Boolean) As Boolean
        Dim obj As Control = sender

        Select Case keycode


        End Select
    End Function


#End Region


    Public Property BeepOnOK() As Boolean
        Get
            Return mBeepOnOK
        End Get
        Set(ByVal value As Boolean)
            mBeepOnOK = value
        End Set
    End Property


    Private Sub dlgOK()

        ' Cek Size
        If Trim(Me.txtEntry.Text) = "" Then
            Exit Sub
        Else
            Me.myRetObj = New Object() {Me.txtEntry.Text, Me.objColname.Text, Me.objSizetag.Text}
            Me.Close()
        End If
    End Sub


    Private Sub dlgConfirmYesNo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub dlgConfirmYesNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.dlgOK()
        End Select
    End Sub

    Private Sub txtEntry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEntry.KeyDown
        Dim currentcell As DataGridViewCell
        Dim currentrowindex, currentcolindex As Integer
        Dim donothing As Boolean = False
        currentcell = Me.DgvSizing.CurrentCell
        If Me.DgvSizing.RowCount > 0 And currentcell Is Nothing Then
            Me.DgvSizing.CurrentCell = Me.DgvSizing(1, 1)
        End If

        currentrowindex = Me.DgvSizing.CurrentCell.RowIndex
        currentcolindex = Me.DgvSizing.CurrentCell.ColumnIndex

        Select Case e.KeyCode
            Case Keys.Enter
                Me.dlgOK()
            Case Keys.Up
                If currentrowindex > 1 Then
                    currentrowindex = currentrowindex - 1
                End If
                Me.DgvSizing.ClearSelection()
                Me.DgvSizing.CurrentCell = Me.DgvSizing(currentcolindex, currentrowindex)
                Me.DgvSizing.CurrentCell.Selected = True
                Me.DgvSizing.Focus()
            Case Keys.Down
                If currentrowindex < Me.DgvSizing.RowCount Then
                    currentrowindex = currentrowindex + 1
                End If
                Me.DgvSizing.ClearSelection()
                Me.DgvSizing.CurrentCell = Me.DgvSizing(currentcolindex, currentrowindex)
                Me.DgvSizing.CurrentCell.Selected = True
                Me.DgvSizing.Focus()
            Case Keys.Left
                Me.DgvSizing.Focus()
            Case Keys.Right
                Me.DgvSizing.Focus()
            Case Else
                e.SuppressKeyPress = True
        End Select
    End Sub

    Private Sub lblOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblOK.Click
        Me.dlgOK()
    End Sub


    Private Sub dlgConfirmYesNo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SuspendLayout()

        Dim obj As Control
        For Each obj In Me.Controls
            If obj.Name <> Me.PnlFormMain.Name Then
                Me.Controls.Remove(obj)
            End If
        Next

        Me.PnlFormMain.Dock = DockStyle.Fill
        Me.PnlFormMain.BackColor = Color.DarkGray
        'Me.PnlFormMain.BackgroundImageLayout = ImageLayout.Stretch
        'Me.PnlFormMain.BackgroundImage = My.Resources.bgf


        Me.objColname.Text = ""
        Me.objSizetag.Text = ""


        Me.Refresh()
        Me.ResumeLayout()

        uiTrnPosEN.BeepPopUp()
    End Sub


    Private Sub DgvSizing_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvSizing.CurrentCellChanged
        Dim obj As DataGridView = CType(sender, DataGridView)
        Dim text As String
        Dim sizetag, colname As String

        If obj.CurrentCell IsNot Nothing Then
            If obj.CurrentCell.ColumnIndex < 3 Then
                Me.txtEntry.Text = ""
                Me.objColname.Text = ""
                Me.objSizetag.Text = ""
            Else
                text = obj.CurrentCell.Value
                sizetag = obj("SIZETAG", obj.CurrentCell.RowIndex).Value
                colname = obj.Columns(obj.CurrentCell.ColumnIndex).Name
                Me.txtEntry.Text = text
                Me.objColname.Text = colname
                Me.objSizetag.Text = sizetag
            End If

        End If


    End Sub

    Private Sub DgvSizing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgvSizing.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                e.SuppressKeyPress = True
                Me.txtEntry.Focus()
                Me.txtEntry.SelectionStart = Len(Me.txtEntry.Text)
                Me.txtEntry.SelectionLength = 0
        End Select
    End Sub
End Class
