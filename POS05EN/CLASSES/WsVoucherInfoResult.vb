Public Class WsVoucherInfoResult
    Inherits WsResult
    Public voucher As VoucherInfo
End Class

Public Class VoucherInfo
    Public Id As String
    Public BatchId As String
    Public Value As Decimal
    Public isActive As Boolean
    Public ActiveDate As String
    Public ExpireDate As String
    Public ED_year As Integer
    Public ED_month As Integer
    Public ED_date As Integer
    Public isUsed As Boolean
    Public UsedDate As String
    Public UserId As String
    Public Descr As String
End Class