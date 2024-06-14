Public Class dlgTfiMemberScan
    Private mPOS As TransStore.POS
    Private mMember As TfiMember


    Public Class TfiMember
        ' event_id":"23001","voubatch_id":"","phone":"6285885525565","name":"Agung N","room_id":"57278907","date":"2023-10-24"
        Public event_id As String
        Public voubatch_id As String
        Public phone As String
        Public name As String
        Public room_id As String
        Public [date] As String

        Public Function getPhoneNumber() As String
            Dim cp As String = Me.phone.Remove(0, 2)
            Return "0" & cp
        End Function

        Public Function getMaxDate() As Date
            Return Now()
        End Function

    End Class


    Public ReadOnly Property POS() As TransStore.POS
        Get
            Return Me.mPOS
        End Get
    End Property



    Public Sub start(ByVal pos As TransStore.POS)
        Me.mPOS = pos
    End Sub




    Public Function getMemberData() As TfiMember
        Return mMember
    End Function




    Private Sub btn_Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Submit.Click

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub



    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txt_Line_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Line.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim txt = Me.txt_Line.Text
           
            Dim str() As String = Strings.Split(txt, "@@@TFI@@@")
            If str.Length = 2 Then
                Try
                    Dim jsonstring As String = str(1)
                    Dim res As TfiMember = Newtonsoft.Json.JavaScriptConvert.DeserializeObject(Of TfiMember)(jsonstring)

                    Me.txt_Nama.Text = res.name
                    Me.txt_Telp.Text = res.phone

                    Me.mMember = res

                    Me.txt_Line.Text = ""
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "MemberScan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            Me.btnCancel_Click(Me.btnCancel, EventArgs.Empty)
        ElseIf e.KeyCode = Keys.F10 Then
            Me.btnOk_Click(Me.btnOk, EventArgs.Empty)
        End If


    End Sub

    Private Sub dlgTfiMemberScan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txt_Nama.Text = ""
        Me.txt_Telp.Text = ""
    End Sub
End Class