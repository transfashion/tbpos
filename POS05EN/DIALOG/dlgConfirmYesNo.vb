Public Class dlgConfirmYesNo

    Dim myRetObj As Object
    Dim mMessage As String
    Dim ActiveButton As String = "NO"

    Private mBeepOnOK As Boolean = True


#Region " Constructor "

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, ByVal args As Object) As Object

        ' Me.SuspendLayout()

        Try
        Catch ex As Exception
            Me.Close()
            Throw ex
        End Try

        MyBase.ShowDialog(owner)
        Return myRetObj
    End Function

#End Region


    Public Property Message() As String
        Get
            Return mMessage
        End Get
        Set(ByVal value As String)
            mMessage = value
            Me.objText.Text = value
            Me.objText.Refresh()
        End Set
    End Property

    Public Property BeepOnOK() As Boolean
        Get
            Return mBeepOnOK
        End Get
        Set(ByVal value As Boolean)
            mBeepOnOK = value
        End Set
    End Property


    Private Sub dlgOK()
        Me.myRetObj = New Object() {}
        If Me.BeepOnOK Then
            uiTrnPosEN.BeepDef2()
        End If

        Me.Close()
    End Sub

    Private Sub State()

        If ActiveButton = "YES" Then
            ActiveButton = "NO"
            Me.lblYES.BorderStyle = BorderStyle.None
            Me.lblNo.BorderStyle = BorderStyle.FixedSingle
        Else
            ActiveButton = "YES"
            Me.lblYES.BorderStyle = BorderStyle.FixedSingle
            Me.lblNo.BorderStyle = BorderStyle.None
        End If

        Me.lblYES.Refresh()
        Me.lblNo.Refresh()
        uiTrnPosEN.BeepDef1()

    End Sub

    Private Sub dlgConfirmYesNo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub dlgConfirmYesNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                uiTrnPosEN.BeepPopDown()
                Me.Close()
            Case Keys.N
                uiTrnPosEN.BeepPopDown()
                Me.Close()
            Case Keys.Y
                Me.dlgOK()
            Case Keys.Left
                State()
            Case Keys.Right
                State()
            Case Keys.Enter
                If Me.ActiveButton = "YES" Then
                    Me.dlgOK()
                Else
                    uiTrnPosEN.BeepPopDown()
                    Me.Close()
                End If

        End Select
    End Sub

    Private Sub dlgConfirmYesNo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SuspendLayout()

        Dim obj As Control
        For Each obj In Me.Controls
            If obj.Name <> Me.PnlFormMain.Name Then
                Me.Controls.Remove(obj)
            End If
        Next

        Me.lblNo.BorderStyle = BorderStyle.FixedSingle


        Me.PnlFormMain.Dock = DockStyle.Fill
        Me.PnlFormMain.BackColor = Color.DarkGray
        'Me.PnlFormMain.BackgroundImageLayout = ImageLayout.Stretch
        'Me.PnlFormMain.BackgroundImage = My.Resources.bgf

        Me.Refresh()
        Me.ResumeLayout()

        uiTrnPosEN.BeepPopUp()
    End Sub



    Private Sub lblYES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblYES.Click

        dlgOK()
    End Sub

    Private Sub lblNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblNo.Click
        Me.Close()
    End Sub

End Class
