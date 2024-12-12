Public Class PosPromoData
    Public Rule As String  ' Procedure Promo
    Public PromoId As String
    Public PromoName As String
    Public ValidRegion As String
    Public ValidBranch As List(Of String)
    Public Descr As String
    Public startDate As Date
    Public endDate As Date
    Public PaymentDiscAllowed As Boolean
    Public PaymentTypeAllowed As List(Of String)
    Public TotalValueThreshold As Decimal
    Public isMemberOnly As Boolean

    Public groupA As PosPromoGroup
    Public DataA As List(Of String)

    Public groupB As PosPromoGroup
    Public DataB As List(Of String)


End Class
