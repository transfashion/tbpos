Public Class PromoArguments

    Public Enum PosPromoModel
        BUNDL_AB = 1
        DISC_AB = 2
    End Enum

    Public Class PosPromoProcedure
        ' Maximal 5 Character
        Public Const None As String = ""
        Public Const BundlingAdd As String = "ADD"
        Public Const BundlingReplace As String = "REPLACE"
        Public Const GWPCondition As String = "GWP-CONDITION"
        Public Const GWPItem As String = "GWP-ITEM"
    End Class


    Public Model As PosPromoModel = PosPromoModel.BUNDL_AB
    Public PromoProcedure As PosPromoProcedure

    Public Descr As String = ""

    Public Data As DataTable

    Public total_value_threshold As Integer = 0


    Public qty_threshold_A As Integer = 1
    Public value_threshold_A As Decimal = 0
    Public percent_discount_A As Integer = 0

    Public qty_threshold_B As Integer = 1
    Public value_threshold_B As Decimal = 0
    Public percent_discount_B As Integer = 0


    Public payment_disc_Allowed As Boolean
    Public paymenttype_allowed As Collection = New Collection

    Public startdate As Date
    Public enddate As Date


    Public replace_discount_A As Boolean
    Public replace_discount_B As Boolean


    Public ForSecondItem_A As Boolean
    Public ForSecondItem_B As Boolean

    Public Branches As Collection = New Collection

    Public row_proc_A As String = PosPromoProcedure.None
    Public row_proc_B As String = PosPromoProcedure.None



End Class
