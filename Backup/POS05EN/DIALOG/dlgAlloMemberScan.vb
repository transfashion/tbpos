Public Class dlgAlloMemberScan


    Public Structure CustomerData
        Public Nama As String
        Public Telp As String
        Public Email As String
        Public MDC As String
    End Structure




    Private mPOS As TransStore.POS
    Private mData As New CustomerData


    Public ReadOnly Property Data() As CustomerData
        Get
            Return Me.mData
        End Get
    End Property


    Public ReadOnly Property POS() As TransStore.POS
        Get
            Return Me.mPOS
        End Get
    End Property



    Public Sub start(ByVal pos As TransStore.POS)
        Me.mPOS = pos

        Me.txt_Nama.Text = ""
        Me.txt_Telp.Text = ""
        Me.txt_Email.Text = ""
        Me.txt_MDC.Text = ""
    End Sub

    Private Sub dlgAlloMemberScan_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.POS.SecondDisplay.showDesk()
    End Sub



    Private Sub dlgAlloMemberScan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                btnCancel_Click(btnCancel, EventArgs.Empty)
        End Select
    End Sub



    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        ' Munculkan Greeting
        Me.POS.SecondDisplay.ShowGreeting(Me.txt_Nama.Text)

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub dlgAlloMemberScan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.POS.SecondDisplay.showTransFashionQR()




    End Sub



    Private Sub txt_Line_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Line.KeyDown
        Dim txtBox As TextBox = CType(sender, TextBox)

        If e.KeyCode = Keys.Enter Then
            Dim line As String = txtBox.Text

            '(0): "000201000000033282"
            '(1): "085885525565"
            '(2): "agung agung"
            '(3): "agung_dhewe@yahoo.com"

            Try
                Dim data() As String = line.Split("|")
                Me.txt_Nama.Text = data(2)
                Me.txt_Telp.Text = data(1)
                Me.txt_Email.Text = data(3)
                Me.txt_MDC.Text = data(0)

                With Me.mData
                    .Nama = Me.txt_Nama.Text
                    .Telp = Me.txt_Telp.Text
                    .Email = Me.txt_Email.Text
                    .MDC = Me.txt_MDC.Text
                End With

                Me.btnOk_Click(Me.btnOk, EventArgs.Empty)
            Catch ex As Exception
            End Try

            Me.txt_Line.Text = ""
        ElseIf e.KeyCode = Keys.Escape Then
            Me.btnCancel_Click(Me.btnOk, EventArgs.Empty)
        ElseIf e.KeyCode = Keys.F10 Then
            Me.btnOk_Click(Me.btnOk, EventArgs.Empty)
        End If

    End Sub

    Private Sub btn_Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Submit.Click

    End Sub
End Class