

Public Class MobilePaymentParameter
    Public Const CountDownDefault As Integer = 3 * 60

    Public RegionBranch As String
    Public QRData As String
    Public Amount As Decimal
    Public ReffNum As String
    Public mid As String
    Public tid As String
    Public storename As String
    Public payment_type As String

    Public CountDownSec As Integer


    Public Sub New()
        Me.CountDownSec = CountDownDefault
    End Sub

End Class
