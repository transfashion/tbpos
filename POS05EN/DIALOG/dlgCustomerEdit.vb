Public Class dlgCustomerEdit

    Private _POS As TransStore.POS
    Private objError As ErrorProvider

    Private _CustomerDisc As Decimal = 0




    Public Property CustomerId() As String
        Get
            Return Me.obj_CustomerId.Text
        End Get
        Set(ByVal value As String)
            Me.obj_CustomerId.Text = value
        End Set
    End Property

    Public Property CustomerDisc() As Decimal
        Get
            Return Me._CustomerDisc
        End Get
        Set(ByVal value As Decimal)
            Me._CustomerDisc = value
        End Set
    End Property

    Public Property CustomerType() As String
        Get
            Return Me.obj_CustomerType.Text
        End Get
        Set(ByVal value As String)
            Me.obj_CustomerType.Text = value
        End Set
    End Property


    Public Property CustomerName() As String
        Get
            Return Me.obj_CustomerName.Text
        End Get
        Set(ByVal value As String)
            Me.obj_CustomerName.Text = value
        End Set
    End Property

    Public Property CustomerTelp() As String
        Get
            Return Me.obj_CustomerTelp.Text
        End Get
        Set(ByVal value As String)
            Me.obj_CustomerTelp.Text = value
        End Set

    End Property


    Public Property CustomerEmail() As String
        Get
            Return Me.obj_CustomerEmail.Text
        End Get
        Set(ByVal value As String)
            Me.obj_CustomerEmail.Text = value
        End Set
    End Property


    Public Property POS() As TransStore.POS
        Get
            Return Me._POS
        End Get
        Set(ByVal value As TransStore.POS)
            Me._POS = value
        End Set
    End Property



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.objError = New ErrorProvider()
    End Sub



    Public Shared Function EmailAddressChecker(ByVal emailAddress As String) As Boolean
        Dim r As System.Text.RegularExpressions.Regex = Nothing
        Dim regExPattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$"
        If System.Text.RegularExpressions.Regex.IsMatch(emailAddress, regExPattern) Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub btn_Ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Ok.Click

        ' Cek apakah customer harus diisi
        If Me.POS.CUSTOMERINFO_IS_MANDATORY Then

            If Trim(Me.obj_CustomerName.Text) = "" Then
                objError.SetError(Me.obj_CustomerName, "Nama Customer belum diisi")
                MessageBox.Show(objError.GetError(Me.obj_CustomerName), "POS - Transaksi Baru", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.obj_CustomerName.Focus()
                Exit Sub
            Else
                objError.SetError(Me.obj_CustomerName, "")
            End If

            If Trim(Me.obj_CustomerTelp.Text) = "" Then
                objError.SetError(Me.obj_CustomerTelp, "NoTelp Customer belum diisi")
                MessageBox.Show(objError.GetError(Me.obj_CustomerTelp), "POS - Transaksi Baru", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.obj_CustomerTelp.Focus()
                Exit Sub
            Else
                objError.SetError(Me.obj_CustomerTelp, "")
            End If

        End If



        ' Kalau no telp diisi
        If Trim(Me.obj_CustomerTelp.Text) <> "" Then
            If (Me.obj_CustomerTelp.Text.Substring(0, 1) <> "0") Then
                objError.SetError(Me.obj_CustomerTelp, "NoTelp Customer salah")
                MessageBox.Show(objError.GetError(Me.obj_CustomerTelp), "POS - Transaksi Baru", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.obj_CustomerTelp.Focus()
                Exit Sub
            Else
                objError.SetError(Me.obj_CustomerTelp, "")
            End If

            ' Cek apakah no telpon valid
            Dim phoneisvalid As Boolean = False
            Dim len = Me.obj_CustomerTelp.Text.Length
            If (len < 10) Then
                If (Me.obj_CustomerTelp.Text = "01") Then
                    phoneisvalid = True
                Else
                    phoneisvalid = False
                End If
            Else
                If (len > 12) Then
                    phoneisvalid = False
                Else
                    phoneisvalid = True
                End If
            End If

            If (Not phoneisvalid) Then
                objError.SetError(Me.obj_CustomerTelp, "NoTelp Customer salah." & vbCrLf & "Minimal nomor telpon adalah 10 digit, maximal 12 digit." & vbCrLf & "Apabila nomor telp tidak ada, isilah dengan '01'")
                MessageBox.Show(objError.GetError(Me.obj_CustomerTelp), "POS - Transaksi Baru", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.obj_CustomerTelp.Focus()
                Exit Sub
            Else
                objError.SetError(Me.obj_CustomerTelp, "")
            End If
        End If




        ' Cek apakah alamat email valid
        If Me.obj_CustomerEmail.Text.Trim() <> "" Then
            Dim email = Me.obj_CustomerEmail.Text.Trim()
            If Not EmailAddressChecker(email) Then
                objError.SetError(Me.obj_CustomerEmail, "Email salah." & vbCrLf & "Isikan email dengan format email benar!")
                MessageBox.Show(objError.GetError(Me.obj_CustomerEmail), "Edit Customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.obj_CustomerEmail.Focus()
                Exit Sub
            Else
                objError.SetError(Me.obj_CustomerEmail, "")
            End If
        End If




        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub obj_CustomerName_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles obj_CustomerName.KeyPress
        e.Handled = Not (Char.IsLetter(e.KeyChar) Or e.KeyChar = Chr(Keys.Back) Or e.KeyChar = " " Or e.KeyChar = "1" Or e.KeyChar = "2" Or e.KeyChar = "3" Or e.KeyChar = "4" Or e.KeyChar = "5" Or e.KeyChar = "6" Or e.KeyChar = "7" Or e.KeyChar = "8" Or e.KeyChar = "9" Or e.KeyChar = "0")
    End Sub

    Private Sub obj_CustomerTelp_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles obj_CustomerTelp.KeyPress
        e.Handled = Not (e.KeyChar = Chr(Keys.Back) Or e.KeyChar = "1" Or e.KeyChar = "2" Or e.KeyChar = "3" Or e.KeyChar = "4" Or e.KeyChar = "5" Or e.KeyChar = "6" Or e.KeyChar = "7" Or e.KeyChar = "8" Or e.KeyChar = "9" Or e.KeyChar = "0")
    End Sub



    Private Sub btnCustomerSearch_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnCustomerSearch.LinkClicked
        ' Me.POS.RPCAddress

        Dim dlg As dlgCustomerSearch = New dlgCustomerSearch()
        Dim res As DialogResult

        dlg.RPCAddress = Me.POS.RPCAddress
        dlg.POS = Me.POS

        res = dlg.ShowDialog(Me)
        If res = Windows.Forms.DialogResult.OK Then
            Me.obj_CustomerId.Text = dlg.CustomerId
            Me.obj_CustomerName.Text = dlg.CustomerName
            Me.obj_CustomerTelp.Text = dlg.CustomerTelp
            Me.obj_CustomerEmail.Text = dlg.CustomerEmail
        End If

        Me.btn_Ok.Focus()
    End Sub
End Class