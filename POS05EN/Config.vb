Imports POS05EN.TransStore

Public Class Config

    ''''Development purpose only
    Public Shared BrowserVersion As String = "1.0.4.456"
    Public Shared DeveloperDefaultSessionID As String = "1234567890"
    Public Shared DeveloperDefaultUserName As String = "transdev"
    Public Shared DllServer As String = "http://webservice.transmahagaya.com/crossroads/frontend/lib"
    Public Shared WebserviceAddress As String = "http://localhost/crossroads/frontend"
    ' Public Shared WebserviceAddress As String = "http://webservice.transmahagaya.com/crossroads/frontend"


    Public Shared LocalDbServer As String = "localhost"
    Public Shared LocalDbUsername As String = "sa"
    Public Shared LocalDbPassword As String = "rahasia"
    Public Shared LocalDbname As String = "E_FRM2_POS"

    ' Runtime Config
    Public Shared DllPrint As String = "INV05TRPRN.DLL"
    Public Shared DllPrintRDLC As String = "INV05TRPRN.rptTrnInventorymovingPrint.rdlc"
    Public Shared WebserviceNSModule As String = "inv05"
    Public Shared WebserviceObjectModule As String = "uitrninventorymoving"



    Public Shared DevRegionId As String = "00900"
    Public Shared DevBranchId As String = "0000300"
    Public Shared DevMachineId As String = "DV"
    Public Shared DevBonType As String = "OUTLET02" 'BAZAR OUTLET01, OUTLET02, OUTLET03

    Public Shared ScanMode As String = "" 'TransStore.POS.MODE_BARCODESCAN

    Public Shared SalesPersonIsMandatory = False
    Public Shared CustomerInfoIsMandatory = False
    Public Shared ExtIdIsEnabled = False


End Class
