Public Class ManualDiscVoucher
    Public region_id As String
    Public branch_id As String

    Public Title As String

    Public Value As Decimal
    Public Code As String
    Public MinimumPurchase As Decimal

    Public DateStart As Date?
    Public DateEnd As Date?
    Public TimeStart As DateTime?
    Public TimeEnd As DateTime?

End Class



Public Class VoucherDataResult
    Public [error] As Boolean
    Public message As String
    Public data As List(Of ManualDiscVoucher)
End Class