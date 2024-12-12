Public Class LX300


    Public Const ESC As String = Chr(&H1B)
    Public Const SI As String = Chr(&HF)
    Public Const DC2 As String = Chr(&H12)


    Public Const INIT As String = ESC & "@"

    ' Printer Head Moving
    Public Const P_CR As String = Chr(&HD)
    Public Const P_LF As String = Chr(&HA)
    Public Const P_FF As String = Chr(&HC)

    Public Const P_NULL As String = Chr(&H0)
    Public Const P_PAPER_HALF As String = ESC & Chr(&H43) & "0" & "5.5"
    Public Const P_TEAR_OFF As String = ESC & Chr(&H25) & "R"

    'Set to Draft
    Public Const P_DRAFT As String = ESC & Chr(&H78) & "0"

    'Set Condensed
    Public Const P_CONDENSED As String = ESC & SI
    Public Const P_CONDENSED_CANCEL As String = DC2


    Public Const P_LOAD_FROM_REAR As String = ESC & Chr(25) & Chr(66)


    'Set CPI_12
    Public Const P_CPI_12 As String = ESC & Chr(&H4D)
    Public Const P_CPI_10 As String = ESC & Chr(&H50)


    ' Set Page 11
    Public Const P_PAGE_07 As String = ESC & Chr(&H43) & Chr(0) & Chr(7)
    Public Const P_PAGE_11 As String = ESC & Chr(&H43) & Chr(0) & Chr(11)


    'Set Bold
    Public Const P_BOLD As String = ESC & Chr(&H47)
    Public Const P_BOLD_CANCEL As String = ESC & Chr(&H48)
End Class

