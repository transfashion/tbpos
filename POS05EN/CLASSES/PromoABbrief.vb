Public Class PromoABbrief
    Public promoab_id As String
    Public promoab_descr As String
    Public brand_id As String
    Public region_id As String
End Class


Public Class PromoABresult
    Public [error] As Boolean
    Public message As String
    Public data As PosPromoData
End Class