Imports System.Runtime.InteropServices
Imports Finisar
Imports BitImageTest



Public Class uiTrnPosEN

    Const __CENTRALSERVER_IP = "172.18.10.20"

    Private SalesDateToBeSentEnable As Boolean = False

    Private startInfo As ProcessStartInfo

    Private objDlgTrnPosEN As dlgTrnPosEN
    Private iniFile As String = "C:\TransBrowser.pos.ini"
    Private _remotewebserviceaddress As String
    Private _wwwroot As String
    Private _AutosendTextStatus As String
    Private err As ErrorProvider = New ErrorProvider()

    'Private iniSetting As String = System.Windows.Forms.Application.StartupPath & "\TransBrowser.ini"
    ' Private _remotewebserviceaddress As String = "http://webservice.transamahagaya.com/crossroads/frontend"


    Private _another_region_to_be_update As String
    Private ClientName As String


    Private objErrorSend As ErrorProvider = New ErrorProvider

    Friend WithEvents POS As TransStore.POS
    Public WithEvents bgwHeposDataUpdater As System.ComponentModel.BackgroundWorker
    Public WithEvents bgwHeposDataSender As System.ComponentModel.BackgroundWorker
    Public WithEvents bgwHeposSignoff As System.ComponentModel.BackgroundWorker
    Public WithEvents bgwHeposUpdatebin As System.ComponentModel.BackgroundWorker
    Public WithEvents bgwHeposVoidRequest As System.ComponentModel.BackgroundWorker
    Public WithEvents bgwHeposUpdateDataManual As System.ComponentModel.BackgroundWorker


    Public Enum PrintMethod
        PrintOnly = 1
        PrintAndPreview = 2
        PreviewOnly = 3
    End Enum


    Public Structure PosPaymentEventArgument
        Dim objBon As TransStore.POS.PosHeader
    End Structure

    Public Structure PosBonData
        Dim obj As TransStore.POS.PosHeader
        Dim Header As DataTable
        Dim Items As DataTable
        Dim Payments As DataTable
    End Structure


#Region " Constructor "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MyBase.InitializeControl(Config.DeveloperDefaultSessionID, Config.DeveloperDefaultUserName, Config.WebserviceAddress, Config.DllServer, Nothing, Me.GetType().Assembly)
        MyBase.SetDSNLocal(Translib.uiBase.CreateDSN(Config.LocalDbServer, Config.LocalDbname, Config.LocalDbUsername, Config.LocalDbPassword))


        Dim b As ThoughtWorks.QRCode.Codec.QRCodeEncoder = New ThoughtWorks.QRCode.Codec.QRCodeEncoder()

    End Sub

#End Region

#Region " PC Speaker "

    <DllImport("KERNEL32.DLL", EntryPoint:="Beep", SetLastError:=True, _
        CharSet:=CharSet.Unicode, ExactSpelling:=True, _
        CallingConvention:=CallingConvention.StdCall)> _
        Public Shared Function _
           PCBeep(ByVal dwFreq As Integer, ByVal dwDuration As Integer) _
             As Boolean
        ' Leave the body of the function empty.
    End Function

#End Region

#Region " Sound "

    Public Shared Function BeepQtyEdit() As Boolean
        uiTrnPosEN.PCBeep(1000, 70)
    End Function

    Public Shared Function BeepItemFound() As Boolean
        uiTrnPosEN.PCBeep(800, 200)
    End Function

    Public Shared Function BeepItemNotFound() As Boolean
        uiTrnPosEN.PCBeep(800, 10)
        uiTrnPosEN.PCBeep(500, 10)
        uiTrnPosEN.PCBeep(1000, 10)
        uiTrnPosEN.PCBeep(800, 10)
        uiTrnPosEN.PCBeep(500, 10)
        uiTrnPosEN.PCBeep(1000, 10)
        uiTrnPosEN.PCBeep(800, 10)
        uiTrnPosEN.PCBeep(500, 10)
        uiTrnPosEN.PCBeep(1000, 10)
        uiTrnPosEN.PCBeep(800, 10)
        uiTrnPosEN.PCBeep(1000, 10)
        uiTrnPosEN.PCBeep(800, 10)
        uiTrnPosEN.PCBeep(500, 10)
        uiTrnPosEN.PCBeep(1000, 10)
        uiTrnPosEN.PCBeep(800, 10)
        uiTrnPosEN.PCBeep(800, 10)
        uiTrnPosEN.PCBeep(500, 10)
        uiTrnPosEN.PCBeep(1000, 10)
        uiTrnPosEN.PCBeep(800, 10)
        uiTrnPosEN.PCBeep(500, 10)
        uiTrnPosEN.PCBeep(1000, 10)
        uiTrnPosEN.PCBeep(800, 10)
        uiTrnPosEN.PCBeep(1000, 10)
        uiTrnPosEN.PCBeep(800, 10)
        uiTrnPosEN.PCBeep(500, 10)
        uiTrnPosEN.PCBeep(1000, 10)
        uiTrnPosEN.PCBeep(800, 10)
    End Function

    Public Shared Function BeepPopUp() As Boolean
        Dim i As Integer
        For i = 800 To 1600 Step 50
            uiTrnPosEN.PCBeep(i, 3)
        Next
    End Function

    Public Shared Function BeepPopDown() As Boolean
        Dim i As Integer
        For i = 1600 To 800 Step -50
            uiTrnPosEN.PCBeep(i, 3)
        Next
    End Function

    Public Shared Function BeepDef1() As Boolean
        uiTrnPosEN.PCBeep(1000, 70)
    End Function

    Public Shared Function BeepDef2() As Boolean
        uiTrnPosEN.PCBeep(800, 200)
    End Function


#End Region

#Region " API Calls "
    ' standard API declarations for INI access
    ' changing only "As Long" to "As Int32" (As Integer would work also)
    Private Declare Unicode Function WritePrivateProfileString Lib "kernel32" _
    Alias "WritePrivateProfileStringW" (ByVal lpApplicationName As String, _
    ByVal lpKeyName As String, ByVal lpString As String, _
    ByVal lpFileName As String) As Int32

    Private Declare Unicode Function GetPrivateProfileString Lib "kernel32" _
    Alias "GetPrivateProfileStringW" (ByVal lpApplicationName As String, _
    ByVal lpKeyName As String, ByVal lpDefault As String, _
    ByVal lpReturnedString As String, ByVal nSize As Int32, _
    ByVal lpFileName As String) As Int32
#End Region

#Region " Ini File "

    Public Overloads Function INIRead(ByVal INIPath As String, _
    ByVal SectionName As String, ByVal KeyName As String, _
    ByVal DefaultValue As String) As String
        ' primary version of call gets single value given all parameters
        Dim n As Int32
        Dim sData As String

        sData = Space$(1024) ' allocate some room 
        n = GetPrivateProfileString(SectionName, KeyName, DefaultValue, _
        sData, sData.Length, INIPath)

        If n > 0 Then ' return whatever it gave us
            INIRead = sData.Substring(0, n)
        Else
            INIRead = ""
        End If
    End Function

    Public Overloads Function INIRead(ByVal INIPath As String, _
    ByVal SectionName As String, ByVal KeyName As String) As String
        ' overload 1 assumes zero-length default
        Return INIRead(INIPath, SectionName, KeyName, "")
    End Function

    Public Overloads Function INIRead(ByVal INIPath As String, _
    ByVal SectionName As String) As String
        ' overload 2 returns all keys in a given section of the given file
        Return INIRead(INIPath, SectionName, Nothing, "")
    End Function

    Public Overloads Function INIRead(ByVal INIPath As String) As String
        ' overload 3 returns all section names given just path
        Return INIRead(INIPath, Nothing, Nothing, "")
    End Function

    Public Sub INIWrite(ByVal INIPath As String, ByVal SectionName As String, _
    ByVal KeyName As String, ByVal TheValue As String)
        Call WritePrivateProfileString(SectionName, KeyName, TheValue, INIPath)
    End Sub

    Public Overloads Sub INIDelete(ByVal INIPath As String, ByVal SectionName As String, _
    ByVal KeyName As String) ' delete single line from section
        Call WritePrivateProfileString(SectionName, KeyName, Nothing, INIPath)
    End Sub

    Public Overloads Sub INIDelete(ByVal INIPath As String, ByVal SectionName As String)
        ' delete section from INI file
        Call WritePrivateProfileString(SectionName, Nothing, Nothing, INIPath)
    End Sub

#End Region


#Region " Masking "

    Public Shared Function DI(ByVal img As System.Drawing.Image) As System.Drawing.Bitmap
        Dim brt As Single = -0.3
        Dim tempBitmap As System.Drawing.Bitmap = CType(img, System.Drawing.Bitmap)
        Dim NewBitmap As System.Drawing.Bitmap = New System.Drawing.Bitmap(tempBitmap.Width, tempBitmap.Height)
        Dim image_attr As New System.Drawing.Imaging.ImageAttributes
        Dim cm As System.Drawing.Imaging.ColorMatrix = New System.Drawing.Imaging.ColorMatrix(New Single()() _
            { _
            New Single() {1.0, 0.0, 0.0, 0.0, 0.0}, _
            New Single() {0.0, 1.0, 0.0, 0.0, 0.0}, _
            New Single() {0.0, 0.0, 1.0, 0.0, 0.0}, _
            New Single() {0.0, 0.0, 0.0, 1.0, 0.0}, _
            New Single() {brt, brt, brt, 1.0, 1.0}})

        image_attr.SetColorMatrix(cm)

        Dim rect As Rectangle = Rectangle.Round(img.GetBounds(GraphicsUnit.Pixel))
        Dim wid As Integer = img.Width
        Dim hgt As Integer = img.Height
        Dim NewGraphics As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(NewBitmap)

        NewGraphics.DrawImage(tempBitmap, New System.Drawing.Rectangle(0, 0, tempBitmap.Width, tempBitmap.Height), 0, 0, tempBitmap.Width, tempBitmap.Height, System.Drawing.GraphicsUnit.Pixel, image_attr)

        'Dim g As System.Drawing.Graphics = Me.CreateGraphics()
        'g.DrawImage(img, rect, 0, 0, wid, hgt, GraphicsUnit.Pixel, image_attr)
        image_attr.Dispose()
        NewGraphics.Dispose()

        Return NewBitmap
    End Function

    Public Shared Function CreateMask(ByVal opacity As Single) As Form
        'Dim fmask As Form = New Form()
        'fmask.ShowInTaskbar = False
        'fmask.WindowState = FormWindowState.Maximized
        'fmask.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'fmask.BackColor = Color.FromArgb(30, 30, 30)
        'fmask.BackgroundImage = My.Resources.dots3
        '' fmask.Opacity = opacity
        'Return fmask

        Dim ss As ScreenShot.ScreenCapture = New ScreenShot.ScreenCapture()
        Dim img As System.Drawing.Image = ss.CaptureScreen()
        Dim iBitmap As System.Drawing.Bitmap = DI(img)
        Dim fmaskimage As Form = New Form()
        Dim fmask As Form = New Form()
        Dim startInfo As ProcessStartInfo = New ProcessStartInfo()

        fmask.SuspendLayout()
        fmask.ShowInTaskbar = False
        fmask.WindowState = FormWindowState.Maximized
        fmask.BackColor = Color.FromArgb(0, 0, 0)
        fmask.BackgroundImageLayout = ImageLayout.Stretch

        If startInfo.EnvironmentVariables("POSENV") = "DEV" Then
            fmask.Opacity = 0.5
        Else
            fmask.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            fmask.BackgroundImage = iBitmap
        End If

        fmask.ResumeLayout()
        Return fmask
    End Function

#End Region

#Region " layout and init UI "

    Public Shared Function FormatDgvPOSItem(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim col As System.Drawing.Color

        'col = Color.FromArgb(209, 181, 225)
        col = Color.Gainsboro

        objDgv.DefaultCellStyle.BackColor = col
        objDgv.DefaultCellStyle.ForeColor = Color.FromArgb(32, 44, 102)
        objDgv.DefaultCellStyle.Font = New Font("Courier New", 9, FontStyle.Regular, GraphicsUnit.Point)
        'objDgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(197, 144, 225)
        objDgv.DefaultCellStyle.SelectionBackColor = Color.DarkGray
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
         { _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "displayed_id", "ID", "", 130, DataGridViewContentAlignment.TopCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "displayed_descr", "Descr", "", 250, DataGridViewContentAlignment.TopLeft, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "displayed_net", "Net", "", 100, DataGridViewContentAlignment.TopRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "displayed_qty", "Qty", "", 60, DataGridViewContentAlignment.TopCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "displayed_subtotal", "Subtotal", "", 100, DataGridViewContentAlignment.TopRight, True, col), _
 _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_item", "ID", "bondetil_item", 200, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_barcode", "ID", "bondetil_barcode", 200, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_idsc", "ID", "bondetil_idsc", 200, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_descr", "Descr", "bondetil_descr", 250, DataGridViewContentAlignment.MiddleLeft, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_article", "Art", "bondetil_article", 100, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_material", "Material", "bondetil_material", 60, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_color", "Color", "bondetil_color", 60, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_size", "Size", "bondetil_size", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_pricegross", "Price", "bondetil_pricegross", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_discpstd01", "DiscStdP_01", "bondetil_discpstd01", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_discrstd01", "DiscStdR_01", "bondetil_discrstd01", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_pricenettstd01", "NettStd_01", "bondetil_pricenettstd01", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_discpvou01", "DiscVouP_01", "bondetil_discpvou01", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_discrvou01", "DiscVouR_01", "bondetil_discrvou01", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_pricenettvou01", "NettVou_01", "bondetil_pricenettvou01", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_vou01id", "Vou01Id", "bondetil_vou01id", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_vou01codenum", "Vou01Codenum", "bondetil_vou01codenum", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_vou01type", "Vou01Codenum", "bondetil_vou01type", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_vou01method", "Vou01Codenum", "bondetil_vou01method", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_vou01discp", "Vou01Codenum", "bondetil_vou01discp", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_pricenet", "Net", "bondetil_pricenet", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_qty", "Qty", "bondetil_qty", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_subtotal", "Subtotal", "bondetil_subtotal", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_rule", "bondetil_rule", "bondetil_rule", 70, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "region_id", "Region", "region_id", 70, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "region_nameshort", "Region", "region_nameshort", 70, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "colname", "colname", "colname", 70, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "promorule_id", "promorule_id", "promorule_id", 70, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "promo_line", "promo_line", "promo_line", 70, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "pricing_issp", "pricing_issp", "pricing_issp", 70, DataGridViewContentAlignment.MiddleCenter, True, col) _
         })


        'Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_discountpercent", "DiscPercent", "bondetil_discountpercent", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
        'Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "bondetil_discount", "Disc", "bondetil_discount", 60, DataGridViewContentAlignment.MiddleRight, True, col), _


        Dim i As Integer
        Dim colname As String = ""
        Dim dpwidth As Integer = 0
        For i = 0 To objDgv.Columns.Count - 1
            colname = objDgv.Columns(i).Name
            If Mid(colname, 1, 10) = "displayed_" Then
                objDgv.Columns(colname).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                If colname <> "displayed_descr" Then
                    dpwidth += objDgv.Columns(colname).Width
                    objDgv.Columns(colname).Resizable = DataGridViewTriState.False
                Else
                    objDgv.Columns(colname).Resizable = DataGridViewTriState.True
                End If
            Else
                objDgv.Columns(colname).Visible = False
            End If
        Next



        objDgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        objDgv.RowHeadersWidth = 15
        objDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing

        objDgv.RowTemplate.Height = 48

        objDgv.Columns("displayed_descr").HeaderCell.Style.Font = New Font("Courier New", 9, FontStyle.Regular, GraphicsUnit.Point)
        objDgv.Columns("displayed_net").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        objDgv.Columns("displayed_qty").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        objDgv.Columns("displayed_subtotal").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight


        objDgv.Columns("displayed_descr").HeaderText = "ART          MAT    COL    SIZE"


        ' DgvMstIteminventory Behaviours: 
        objDgv.MultiSelect = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AutoGenerateColumns = False

    End Function

    Public Shared Function FormatDgvPOSItemSelect(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim col As System.Drawing.Color

        'col = Color.FromArgb(209, 181, 225)
        col = Color.Gainsboro

        objDgv.DefaultCellStyle.BackColor = col
        objDgv.DefaultCellStyle.ForeColor = Color.FromArgb(32, 44, 102)
        objDgv.DefaultCellStyle.Font = New Font("Courier New", 9, FontStyle.Regular, GraphicsUnit.Point)
        objDgv.DefaultCellStyle.SelectionBackColor = Color.DarkGray
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
         { _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "displayed_id", "ID", "", 130, DataGridViewContentAlignment.TopCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "displayed_descr", "Descr", "", 250, DataGridViewContentAlignment.TopLeft, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "displayed_pricegross", "Price", "iteminventory_sellpricedefault", 100, DataGridViewContentAlignment.TopRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "displayed_pricedisc", "Disc", "iteminventory_discountdefault", 40, DataGridViewContentAlignment.TopRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "displayed_pricenet", "Net", "iteminventory_pricenet", 100, DataGridViewContentAlignment.TopRight, True, col), _
 _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "iteminventory_id", "ID", "iteminventory_id", 100, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "iteminventory_name", "Descr", "iteminventory_name", 250, DataGridViewContentAlignment.MiddleLeft, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "iteminventory_article", "Art", "iteminventory_article", 100, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "iteminventory_material", "Mat", "iteminventory_material", 60, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "iteminventory_color", "Color", "iteminventory_color", 60, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "iteminventory_size", "Size", "iteminventory_size", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "iteminventory_sellpricedefault", "Price", "iteminventory_sellpricedefault", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "iteminventory_discountdefault", "Disc", "iteminventory_discountdefault", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "iteminventory_pricenet", "Disc", "iteminventory_pricenet", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "iteminventory_idsc", "idsc", "iteminventory_idsc", 70, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "iteminventory_barcode", "Barcode", "iteminventory_barcode", 70, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "iteminventory_sizecode", "SizeCode", "iteminventory_sizecode", 70, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "iteminventorygroup_id", "Group", "iteminventorygroup_id", 70, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "iteminventorysubgroup_id", "SubGroup", "iteminventorysubgroup_id", 70, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "region_id", "Region", "region_id", 70, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "region_nameshort", "Region", "region_nameshort", 70, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "colname", "Colname", "colname", 70, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "sizetag", "sizetag", "sizetag", 70, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "pricingrule", "PrcingRule", "pricingrule", 70, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "proc", "Proc", "proc", 70, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "pricing_issp", "pricing_issp", "priceissp", 70, DataGridViewContentAlignment.MiddleCenter, True, col) _
         })

        Dim i As Integer
        Dim colname As String = ""
        Dim dpwidth As Integer = 0
        For i = 0 To objDgv.Columns.Count - 1
            colname = objDgv.Columns(i).Name
            objDgv.Columns(colname).Visible = False
            If Mid(colname, 1, 10) = "displayed_" Then
                objDgv.Columns(colname).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                objDgv.Columns(colname).Visible = True
                If colname <> "displayed_descr" Then
                    dpwidth += objDgv.Columns(colname).Width
                    objDgv.Columns(colname).Resizable = DataGridViewTriState.False
                Else
                    objDgv.Columns(colname).Resizable = DataGridViewTriState.True
                End If
            Else
                objDgv.Columns(colname).Visible = False
            End If
        Next



        objDgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        objDgv.RowHeadersWidth = 15
        objDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing

        objDgv.RowTemplate.Height = 48

        objDgv.Columns("displayed_pricegross").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        objDgv.Columns("displayed_pricegross").DefaultCellStyle.Format = "#,##0"
        objDgv.Columns("displayed_pricedisc").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        objDgv.Columns("displayed_pricedisc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
        objDgv.Columns("displayed_pricedisc").DefaultCellStyle.Format = "#,##0"
        objDgv.Columns("displayed_pricenet").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        objDgv.Columns("displayed_pricenet").DefaultCellStyle.Format = "#,##0"


        ' DgvMstIteminventory Behaviours: 
        objDgv.MultiSelect = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AutoGenerateColumns = False

        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function

    Public Shared Function FormatDgvPOSPayments(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim col As System.Drawing.Color

        objDgv.DefaultCellStyle.BackColor = col
        objDgv.DefaultCellStyle.ForeColor = Color.FromArgb(32, 44, 102)
        objDgv.DefaultCellStyle.Font = New Font("Courier New", 9, FontStyle.Regular, GraphicsUnit.Point)
        'objDgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(197, 144, 225)
        objDgv.DefaultCellStyle.SelectionBackColor = Color.DarkGray
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
         { _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "displayed_descr", "Descr", "", 310, DataGridViewContentAlignment.TopLeft, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "displayed_subtotal", "Subtotal", "", 100, DataGridViewContentAlignment.TopRight, True, col), _
 _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_line", "Line", "payment_line", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_iscash", "IsCash", "payment_iscash", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_type", "Type", "payment_type", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_typename", "TypeName", "payment_typename", 60, DataGridViewContentAlignment.MiddleLeft, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_bankname", "BankName", "payment_bankname", 60, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_cardnumber", "CardNumber", "payment_cardnumber", 60, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_cardholder", "CardHolder", "payment_cardholder", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_edc", "Price", "Price", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_installment", "Inst", "payment_installment", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_value", "Value", "payment_value", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_cash", "Cash", "payment_cash", 60, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "payment_refund", "Refund", "payment_refund", 60, DataGridViewContentAlignment.MiddleRight, True, col) _
         })


        Dim i As Integer
        Dim colname As String = ""
        Dim dpwidth As Integer = 0
        For i = 0 To objDgv.Columns.Count - 1
            colname = objDgv.Columns(i).Name
            If Mid(colname, 1, 10) = "displayed_" Then
                objDgv.Columns(colname).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                If colname <> "displayed_descr" Then
                    dpwidth += objDgv.Columns(colname).Width
                    objDgv.Columns(colname).Resizable = DataGridViewTriState.False
                Else
                    objDgv.Columns(colname).Resizable = DataGridViewTriState.True
                End If
            Else
                objDgv.Columns(colname).Visible = False
            End If
        Next



        objDgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        objDgv.RowHeadersWidth = 15
        objDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing

        objDgv.RowTemplate.Height = 48


        ' Behaviours: 
        objDgv.MultiSelect = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AutoGenerateColumns = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Function

    Public Shared Function FormatDgvPOSSizeSelect(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim col As System.Drawing.Color
        col = Color.Gainsboro
        objDgv.DefaultCellStyle.BackColor = col
        objDgv.DefaultCellStyle.ForeColor = Color.FromArgb(32, 44, 102)
        objDgv.DefaultCellStyle.Font = New Font("Courier New", 9, FontStyle.Regular, GraphicsUnit.Point)
        objDgv.DefaultCellStyle.SelectionBackColor = Color.DarkGray
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        { _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "region_id", "ID", "region_id", 30, DataGridViewContentAlignment.MiddleRight, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "SIZETAG", "ST", "SIZETAG", 30, DataGridViewContentAlignment.MiddleLeft, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "DESCR", "DESCR", "DESCR", 100, DataGridViewContentAlignment.MiddleLeft, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C01", "C01", "C01", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C02", "C02", "C02", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C03", "C03", "C03", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C04", "C04", "C04", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C05", "C05", "C05", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C06", "C06", "C06", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C07", "C07", "C07", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C08", "C08", "C08", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C09", "C09", "C09", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C10", "C10", "C10", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C11", "C11", "C11", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C12", "C12", "C12", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C13", "C13", "C13", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C14", "C14", "C14", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C15", "C15", "C15", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C16", "C16", "C16", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C17", "C17", "C17", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C18", "C18", "C18", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C19", "C19", "C19", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C20", "C20", "C20", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C21", "C21", "C21", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C22", "C22", "C22", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C23", "C23", "C23", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C24", "C24", "C24", 35, DataGridViewContentAlignment.MiddleCenter, True, col), _
            Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "C25", "C25", "C25", 35, DataGridViewContentAlignment.MiddleCenter, True, col) _
         })


        objDgv.Columns("region_id").Visible = False
        objDgv.Columns("SIZETAG").Visible = False

        objDgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        objDgv.RowHeadersWidth = 15
        objDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing

        objDgv.RowTemplate.Height = 25

        ' DgvMstIteminventory Behaviours: 
        objDgv.MultiSelect = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AutoGenerateColumns = False


    End Function

#End Region




    Public Function WebserviceExecuteX(ByVal wConn As Translib.WebConnection, ByVal script As String, ByRef responds As String) As Translib.WebResultObject
        Dim objWebResult As Translib.WebResultObject
        Dim resultParsed As Boolean = False

        responds = wConn.post(script)



        Try
            objWebResult = CType(Newtonsoft.Json.JavaScriptConvert.DeserializeObject(responds, GetType(Translib.WebResultObject)), Translib.WebResultObject)

            resultParsed = True
            If objWebResult Is Nothing Then Throw New Exception("Data Result Error" & vbCrLf & vbCrLf & script)
            If objWebResult.data Is Nothing Then Throw New Exception("Data Result Error, invalid object format." & vbCrLf & vbCrLf & script)
            'If Not objWebResult.success Then Throw New Exception(objWebResult.errors.ErrorMessage & vbCrLf & script)

            If Not objWebResult.success Then
                If objWebResult.errors IsNot Nothing Then
                    Throw New Exception(objWebResult.errors.ErrorMessage & vbCrLf & script)
                Else
                    Throw New Exception("Variable [objWebResult.errors] is not refrenced to an object." & vbCrLf & "Please check your web service, for value of $objResult->success" & vbCrLf & "If defined as false, you have to set $objResult->errors " & vbCrLf & vbCrLf & script)
                End If
            End If

            If objWebResult.data.Count < 0 Then Throw New Exception("Internal Error. objWebResult.data.Count < 0" & vbCrLf & script)
        Catch ex As System.Exception
            objWebResult = New Translib.WebResultObject()
            objWebResult.errors = New Translib.WebResultErrorObject()
            objWebResult.errors.ErrorId = "12"
            If resultParsed Then
                objWebResult.errors.ErrorMessage = ex.Message & vbCrLf & "WebResponse: [" & Mid(Trim(responds), 1, 1000) & "]"
            Else
                objWebResult.errors.ErrorMessage = "Result Cannot be Parsed." & vbCrLf & "Check whether response data contains apostrof(""), which cannot be parsed with json parser. " & vbCrLf & vbCrLf & "Web Respond:" & vbCrLf & Mid(Trim(responds), 1, 2000)
            End If
        End Try

        Return objWebResult
    End Function


    Public Overrides Function LoadDataIntoDatatable(ByVal service As String, ByVal criteria As String, ByRef respond As String) As DataTable
        Dim wConn As Translib.WebConnection = New Translib.WebConnection(Me._remotewebserviceaddress, Me.SessionID, Me.UserName)
        Dim objWebResult As Translib.WebResultObject
        Dim obj As Newtonsoft.Json.JavaScriptObject
        Dim n, i As Integer
        Dim tbl As DataTable = New DataTable()

        Try
            wConn.addtext("clientname", Me.ClientName)
            wConn.addtext("criteria", criteria)
            objWebResult = WebserviceExecute(wConn, service, respond)
            n = objWebResult.data.Count
            If n > 0 Then
                For i = 0 To n - 1
                    obj = CType(objWebResult.data(i), Newtonsoft.Json.JavaScriptObject)
                    Me.AddRowFromJsonObject(tbl, obj, True)
                Next
            End If
        Catch ex As Exception
            Throw New Exception(Mid(respond, 1, 1000) & vbCrLf & vbCrLf & ex.Message)
        End Try

        Return tbl
    End Function


    Public Function getWebConnection() As Translib.WebConnection
        Dim wConn As Translib.WebConnection = New Translib.WebConnection(Me._remotewebserviceaddress, Me.SessionID, Me.UserName)
        wConn.addtext("clientname", Me.ClientName)
        Return wConn
    End Function



    Public Shared Function SendTextToPrinter(ByVal objPOS As TransStore.POS, ByVal txt As String, ByVal pm As PrintMethod, ByVal _PAGELENGTH As String) As Boolean
        'MessageBox.Show("[uiTrnPosEN.SendTextToPrinter]" & vbCrLf & "Mencetak Data...." & vbCrLf & "[" & txt & "]", "Printing...", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dim str As String = ""
        Dim print As Boolean = False
        Dim preview As Boolean = False


        Select Case pm
            Case PrintMethod.PrintOnly
                print = True
                preview = False
            Case PrintMethod.PrintAndPreview
                print = True
                preview = True
            Case PrintMethod.PreviewOnly
                print = False
                preview = True
        End Select


        If preview Then
            Dim f As dlgPrintPreview = New dlgPrintPreview()
            f.SetText(txt)
            f.ShowDialog()
        End If

        'txt = ""
        'txt &= "        10        20        30        40        50        60        70        80        90       100       110       120       130       " & vbCrLf
        'txt &= "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567" & vbCrLf

        Dim printlogo As Boolean = False


        If objPOS.Logo <> "" Then
            printlogo = True
        End If

        If print Then

            Dim args() As String = New String() {}

            Dim prnSet As System.Drawing.Printing.PrinterSettings = New System.Drawing.Printing.PrinterSettings
            Dim hPrn As System.IntPtr = New IntPtr(0)
            Dim docinfo As Translib.RawPrinterHelper.DOCINFOW = New Translib.RawPrinterHelper.DOCINFOW()
            Dim dwError As Int32
            Dim PrinterName As String = prnSet.PrinterName


            If objPOS.ReceiptPrinter <> "" Then
                PrinterName = objPOS.ReceiptPrinter
            End If


            str = Nothing
            If Not printlogo Then
                str &= LX300.INIT
                str &= LX300.P_TEAR_OFF & LX300.P_NULL
                str &= LX300.P_CONDENSED
                str &= LX300.P_CPI_10
                str &= _PAGELENGTH
            Else
                BitImageTest.Program.Print(PrinterName, objPOS.Logo)
                str &= LX300.ESC
                str &= Chr(51)
                str &= Chr(60)

                str &= LX300.ESC
                str &= Chr(77)
                str &= Chr(0)
            End If


            ' Potong kertas
            str &= txt
            str &= LX300.P_CR & LX300.P_FF
            str &= Chr(&H1D) & "V" & Chr(66) & Chr(0)

            Try

                Dim bSuccess As Boolean = False
                If Translib.RawPrinterHelper.OpenPrinter(PrinterName, hPrn, 0&) Then
                    If Translib.RawPrinterHelper.StartDocPrinter(hPrn, 1, docinfo) Then
                        If Translib.RawPrinterHelper.StartPagePrinter(hPrn) Then
                            Translib.RawPrinterHelper.SendStringToPrinter(PrinterName, str)
                            Translib.RawPrinterHelper.EndPagePrinter(hPrn)
                        End If
                        Translib.RawPrinterHelper.EndDocPrinter(hPrn)
                    End If
                    Translib.RawPrinterHelper.ClosePrinter(hPrn)
                End If


                If bSuccess = False Then
                    dwError = Marshal.GetLastWin32Error()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End If





    End Function

    Public Shared Function BrowseSalesPerson(ByRef owner As System.Windows.Forms.IWin32Window, ByRef objid As TextBox, ByRef objname As Label, ByRef objPOS As TransStore.POS) As Boolean
        Dim ParamValue As TransStore.PosDataBrowseParamValue = New TransStore.PosDataBrowseParamValue
        Dim ReturnValue As TransStore.PosDataBrowseReturnValue = New TransStore.PosDataBrowseReturnValue

        Dim ColumnsFormat As System.Windows.Forms.DataGridViewColumn() = New System.Windows.Forms.DataGridViewColumn() _
        { _
           Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "possalesperson_id", "ID", "possalesperson_id", 75), _
           Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "possalesperson_name", "NAME", "possalesperson_name", 200), _
           Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "region_id", "REG", "region_id", 100) _
        }

        With ParamValue
            .POS = objPOS
            .Title = "Sales"
            .SQL = "SELECT * FROM master_possalesperson WHERE possalesperson_isdisabled=0 AND (possalesperson_id='[_SEARCHKEY_]' OR possalesperson_name LIKE '[_SEARCHKEY_]')"
            .ColumnsFormat = ColumnsFormat
            .column_objid = "possalesperson_id"
            .column_objname = "possalesperson_name"
        End With


        ReturnValue = TransStore.Utilities.OpenBrowseDialog(owner, objid, objname, ParamValue)

        ' Process Result

    End Function

    Public Shared Function BrowseCustomer(ByRef owner As System.Windows.Forms.IWin32Window, ByRef customerid As TextBox, ByRef customername As TextBox, ByRef customertelp As TextBox, ByRef customertype As TextBox, ByRef customerdisc As TextBox, ByRef objPOS As TransStore.POS) As Boolean
        Dim ParamValue As TransStore.PosDataBrowseParamValue = New TransStore.PosDataBrowseParamValue
        Dim ReturnValue As TransStore.PosDataBrowseReturnValue = New TransStore.PosDataBrowseReturnValue

        Dim ColumnsFormat As System.Windows.Forms.DataGridViewColumn() = New System.Windows.Forms.DataGridViewColumn() _
        { _
           Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "customer_id", "ID", "customer_id", 75), _
           Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "customer_typename", "Type", "customer_typename", 50), _
           Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "customer_namefull", "NAME", "customer_namefull", 200), _
           Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "customer_phonehome", "Ph.1", "customer_phonehome", 100), _
           Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "customer_phonework", "Ph.2", "customer_phonework", 100), _
           Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "customer_paymdisc", "Disc", "customer_paymdisc", 40), _
           Translib.uiBase.CreateDataGridViewColumn(New DataGridViewTextBoxColumn, "region_id", "REGION", "region_id", 100) _
        }

        With ParamValue
            .POS = objPOS
            .Title = "Customer"
            .SQL = "SELECT * FROM master_customer WHERE customer_isdisabled=0 AND customer_namefull LIKE '[_SEARCHKEY_]'"
            .ColumnsFormat = ColumnsFormat
            .column_objid = "customer_id"
            .column_objname = "customer_namefull"
        End With

        Dim objname As Windows.Forms.Label = New Windows.Forms.Label
        objname.Text = customername.Text

        ReturnValue = TransStore.Utilities.OpenBrowseDialog(owner, customerid, objname, ParamValue)
        customername.Text = objname.Text

        Dim ph1, ph2, type As String
        Dim disc As Decimal
        If ReturnValue.fields IsNot Nothing Then
            ph1 = ReturnValue.fields("customer_phonehome").ToString
            ph2 = ReturnValue.fields("customer_phonework").ToString
            type = ReturnValue.fields("customer_typename").ToString
            disc = CDec(ReturnValue.fields("customer_paymdisc").ToString)

            customertelp.Text = ph1
            customertype.Text = type
            customerdisc.Text = disc
        End If


        ' Process Result

    End Function

    Public Sub SetID(ByVal id As String)
        Me.objBonId.Text = id
    End Sub




    Private Sub uiTrnPosEN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'MessageBox.Show(Me.DSNLocal, "TEST", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dim last_synsign_id As String

       

        Try

            Dim param As TransStore.POSParameter = New TransStore.POSParameter

            TransStore.POS.DSN = Me.DSNLocal
            'Me.POS = New TransStore.POS(Me, param)
            Me.POS = New TransStore.POS(Me)
           


            Me.iniFile = Me.POS.INI_FILE

            param.DISABLED_PAYMENT_METHOD = Trim(Me.INIRead(Me.iniFile, "Machine", "DISABLED_PAYMENT_METHOD"))
            param.AUTO_KEY_NUMBER = Trim(Me.INIRead(Me.iniFile, "Machine", "AUTO_KEY_NUMBER"))
            param.SLAVE_MODE = Trim(Me.INIRead(Me.iniFile, "Machine", "SLAVE_MODE"))
            param.VOUCHER_LINKEDTO_CUSTOMERTYPE = Trim(Me.INIRead(Me.iniFile, "Machine", "VOUCHER_LINKEDTO_CUSTOMERTYPE"))
            param.DISABLED_VOUCHER = Trim(Me.INIRead(Me.iniFile, "Machine", "DISABLED_VOUCHER"))
            param.AUTOSENDPOSDATA = Trim(Me.INIRead(Me.iniFile, "Machine", "AUTOSENDPOSDATA"))
            param.AUTOSENDINTERVAL = Trim(Me.INIRead(Me.iniFile, "Machine", "AUTOSENDINTERVAL"))
            param.SENDDATAMODE = Trim(Me.INIRead(Me.iniFile, "Machine", "SENDDATAMODE"))
            param.SENDDATAVER = Trim(Me.INIRead(Me.iniFile, "Machine", "SENDDATAVER"))


            Me.POS.SetParam(param)

            ' LoadLocalPosData
            ' MachineID, BranchId, RegionId, Event, PrinterDefault, 
            Me.POS.MachineId = Me.INIRead(Me.iniFile, "Machine", "machine_id")
            Me.POS.BranchId = Me.INIRead(Me.iniFile, "Machine", "branch_id")
            Me.POS.RegionId = Me.INIRead(Me.iniFile, "Machine", "region_id")
            Me.POS.Event = Me.INIRead(Me.iniFile, "Machine", "event")
            Me.POS.PrinterDefault = Me.INIRead(Me.iniFile, "Machine", "printerdefault")
            Me.POS.ReceiptPrinter = Trim(Me.INIRead(Me.iniFile, "Machine", "receiptprinter"))
            Me.POS.Logo = Trim(Me.INIRead(Me.iniFile, "Machine", "logo"))
            Me.POS.RegionPathFilter = Me.INIRead(Me.iniFile, "Machine", "regionpathfilter")
            Me.POS.NPWP = Me.INIRead(Me.iniFile, "Machine", "npwp")
            Me.POS.RPCAddress = Me.INIRead(Me.iniFile, "Machine", "rpc_address")
            Me.POS.QrisProxy = Me.INIRead(Me.iniFile, "Machine", "qris_proxy")
            Me.POS.BONTYPE = Me.INIRead(Me.iniFile, "Machine", "BONTYPE")
            Me.POS.NOT_ALLOWED_PAYMENT = Me.INIRead(Me.iniFile, "Machine", "NOT_ALLOWED_PAYMENT")
            Me.POS.PRINTER_PORT = Trim(Me.INIRead(Me.iniFile, "Machine", "PRINTER_PORT"))
            Me.POS.POLE_PORT = Trim(Me.INIRead(Me.iniFile, "Machine", "POLE_PORT"))
            Me.POS.MCRLAYER = Trim(Me.INIRead(Me.iniFile, "Machine", "MCRLAYER"))
            Me.POS.CARDNUMBER_ENTRY = Trim(Me.INIRead(Me.iniFile, "Machine", "CARDNUMBER_ENTRY"))
            Me.POS.CARDNUMBER_OVRMANUAL = Trim(Me.INIRead(Me.iniFile, "Machine", "CARDNUMBER_OVRMANUAL"))
            Me.POS.ALLOW_MULTIPLE_PAYMENT_IN_FP = Trim(Me.INIRead(Me.iniFile, "Machine", "ALLOW_MULTIPLE_PAYMENT_IN_FP"))
            Me.POS.FP_PAYMENT_FILTER = Trim(Me.INIRead(Me.iniFile, "Machine", "FP_PAYMENT_FILTER"))

            Me._wwwroot = Me.INIRead(Me.iniFile, "Machine", "wwwroot")
            Me._another_region_to_be_update = Me.INIRead(Me.iniFile, "Machine", "another_region_to_be_update")

            ' TransStore.POS.AllowBackDatedEntry = Me.INIRead(Me.iniFile, "Machine", "AllowBackDatedEntry")


            Me.POS.UserName = Me.UserName
            TransStore.POS.PrinterName = Me.POS.PrinterDefault


            Me._remotewebserviceaddress = Me.POS.RPCAddress
            Me.ClientName = Me.INIRead(Me.iniFile, "Machine", "ClientName")

            If Me.POS.SignInStatusIsOpened() Then
                last_synsign_id = Me.POS.GetClientSignInData()
                If last_synsign_id <> "" Then
                    Me.obj_last_synsign_id.Text = "Signed In: " & last_synsign_id
                Else
                    Me.obj_last_synsign_id.Text = ""
                End If
            Else
                Me.obj_last_synsign_id.Text = ""
            End If



            


            ' Ambil setting untuk remote webservice
            Me.lblRemoteWebservice.Text = Me.POS.RPCAddress
            Me.lblRemoteWebservice.AutoSize = True
            Me.lblRemoteWebservice.Refresh()



            If Me.POS.GetServerName() = __CENTRALSERVER_IP Or Me.POS.SLAVE_MODE = "1" Then
                Me.btnSignIn.Enabled = False
                Me.btnSignOff.Enabled = False
                Me.btnUpdate.Enabled = False
                Me.btnSend.Enabled = False
            End If


            Me.POS.SiteName = Me.POS.GetLocationStatus()

            Me.objBonId.Text = Me.POS.GetLastID()
            Me.lblLocationStatus.Text = Me.POS.SiteName
            Me.lblLocationStatus.AutoSize = True
            Me.lblLocationStatus.Refresh()

            Me.POS.STATUS = Me.lblLocationStatus.Text



            ' CEK POLE DISPLAY
            Try
                Dim locs() As String = Me.lblLocationStatus.Text.Split("/")
                Dim line1 As String = Trim(locs(0))
                Dim line2 As String = Trim(locs(1))

                POLEDISPLAY.Write(Me.POS.POLE_PORT, line1, line2)
            Catch ex As Exception
            End Try




            Me.dtSalesTobeSent.Enabled = Me.SalesDateToBeSentEnable


            ' CEK APAKAH Tanggal Mesin lebih lama dari kode sequencer
            If Me.POS.IsMachineDateError(Me.POS.RegionId, Me.POS.BranchId, Me.POS.MachineId) Then
                MessageBox.Show("Tanggal Komputer Salah, mesin POS tidak bisa digunakan", "POS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Enabled = False
            End If

            If param.AUTOSENDPOSDATA = "1" Then
                _AutosendTextStatus = "Auto send is on, interval " & (CLng(param.AUTOSENDINTERVAL) / 60000) & " min"

                Me.TimerAutosendData.Enabled = True
                Me.TimerAutosendData.Interval = param.AUTOSENDINTERVAL
                Me.lblAutosendStatus.Text = Me._AutosendTextStatus
                Me.lblAutosendStatus.Visible = True
            Else
                Me.lblAutosendStatus.Visible = False
            End If


            Me.obj_txt_senddatamode.Text = Me.POS.SENDDATAMODE


            ' Cek Development MODE
            Me.startInfo = New ProcessStartInfo()
            If startInfo.EnvironmentVariables("POSENV") = "DEV" Then
                Me.POS.IsDevelopmentMode = True
                Me.lblLocationStatus.Text = "DEV MODE"
                Me.btnRePrint.Enabled = True
                Me.btn_testVoucher.Visible = True
                Me.btn_TestQris.Visible = True
            Else
                Me.btn_testVoucher.Visible = False
                Me.btn_TestQris.Visible = False
            End If


            ' Auto Key
            Dim key = TransStore.Utilities.CreatePassword(Me.POS.RegionId, Me.POS.BranchId, Now())
            If Me.POS.AUTO_KEY_NUMBER = "1" Then
                Me.objKey.Text = key
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


        Me.lblStatus.Text = "POS." & Me.POS.RegionId & "." & Me.POS.BranchId & "." & Me.POS.MachineId & ",  " & Me.POS.Event
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Refresh()

        Me.SuspendLayout()
        Me.objDlgTrnPosEN = New dlgTrnPosEN(Me.DSNLocal, Me.POS)
        With Me.objDlgTrnPosEN
            .FormBorderStyle = FormBorderStyle.None
            .WindowState = FormWindowState.Maximized
            ' .Show()
        End With
        Me.ResumeLayout()


        Me.POS.SessionId = Me.SessionID
        Me.POS.ClientName = Me.ClientName



        Me.POS.PrepareTable()





        ' DISPLAY KEDUA
        Me.POS.InitialiseSecondDisplay(Me.startInfo)
        Me.POS.SecondDisplay.SetLocation(Me.lblLocationStatus.Text)
        Me.POS.SecondDisplay.SetTotal(0, 0, 0)




        '  POS VERSION
        Dim fileDll = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(fileDll)

        Dim strMajor, strMinor, strRev, strBuild As String
        strMajor = myFileVersionInfo.FileMajorPart.ToString()
        strMinor = myFileVersionInfo.FileMinorPart.ToString()
        strRev = myFileVersionInfo.FileBuildPart.ToString
        strBuild = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version().Build.ToString()

        Me.LabelVersion.Text = "HEPOS (build " & strBuild & ") " & strMajor & "." & strMinor & " rev" & strRev




    End Sub

    Private Sub uiTrnPosEN_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.bgwHeposDataUpdater = Nothing
        Me.bgwHeposDataSender = Nothing
        Me.bgwHeposSignoff = Nothing
        Me.bgwHeposUpdatebin = Nothing
        Me.bgwHeposVoidRequest = Nothing

        Me.bgwSave = Nothing
        Me.bgwListLoader = Nothing
        Me.bgwNew = Nothing
        Me.bgwMasterLoaderQueue = Nothing
        Me.bgwPrintLoader = Nothing
        Me.bgwPrintWeb = Nothing
    End Sub




    Private Sub chkClosing_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTransactionSummary.CheckedChanged, chkBonRekap.CheckedChanged, chkArticleBreakdown.CheckedChanged
        If Not chkTransactionSummary.Checked And Not chkBonRekap.Checked And Not chkArticleBreakdown.Checked Then
            btnClosing.Enabled = False
        Else
            btnClosing.Enabled = True
        End If
    End Sub

    Private Sub btnOpenPOSConsole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenPOSConsole.Click
        ' Cek apakah ada perubahan tanggal di system



        'Masukkan password kalau belum di syn
        Dim key = TransStore.Utilities.CreatePassword(Me.POS.RegionId, Me.POS.BranchId, Now())
        If Me.obj_last_synsign_id.Text = "" Then
            If key <> Me.objKey.Text Then
                err.SetError(Me.objKey, "key required")
                Me.objKey.BackColor = Color.Coral
                MessageBox.Show("Anda belum Sign-In !" & vbCrLf & "Untuk membuka POS, anda diharuskan untuk mengisi key," & vbCrLf & "dan Anda belum memasukkan key dengan benar." & vbCrLf & vbCrLf & "Untuk mendapatkan kode key, hubungi bagian support anda.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                Me.objKey.BackColor = Color.White
                err.SetError(Me.objKey, "")
            End If
        End If

        err.SetError(Me.objKey, "")
        Me.objKey.BackColor = Color.White


        With Me.objDlgTrnPosEN
            .FormBorderStyle = FormBorderStyle.Fixed3D
            '.FormBorderStyle = FormBorderStyle.None
            .WindowState = FormWindowState.Maximized
            '.OpenDialog(Me, "", "", "", "", Nothing)
            .POSTransactionPrepare()
            .Show()
            .BringToFront()
        End With
    End Sub

    Private Sub btnOpenPOSReturNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenPOSReturNote.Click

        'Masukkan password kalau belum di syn
        Dim key = TransStore.Utilities.CreatePassword(Me.POS.RegionId, Me.POS.BranchId, Now())
        If Me.obj_last_synsign_id.Text = "" Then
            If key <> Me.objKey.Text Then
                err.SetError(Me.objKey, "key required")
                Me.objKey.BackColor = Color.Coral
                MessageBox.Show("Anda belum Sign-In !" & vbCrLf & "Untuk membuka Nota Retur, anda diharuskan untuk mengisi key," & vbCrLf & "dan Anda belum memasukkan key dengan benar." & vbCrLf & vbCrLf & "Untuk mendapatkan kode key, hubungi bagian support anda.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                Me.objKey.BackColor = Color.White
                err.SetError(Me.objKey, "")
            End If
        End If




        err.SetError(Me.objKey, "")
        Me.objKey.BackColor = Color.White


        Dim dlg As dlgTrnPosVoid = New dlgTrnPosVoid()
        Dim bon As TransStore.POS.PosHeader = New TransStore.POS.PosHeader
        Dim o As PosBonData
        Dim args As Object() = New Object() {}

        bon.bon_id = Me.objBonId.Text
        o = Me.POS.GetBonData(bon)

        If o.Header.Rows.Count <= 0 Then
            MessageBox.Show("Bon '" & bon.bon_id & "' tidak ditemukan", "Bon", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        ' Nota Retur maximal 14 hari

        Dim bon_date_timestamp As Date = o.Header.Rows(0).Item("bon_date")
        Dim now_date_timestamp As Date = Now.Date

        Dim now_date As Date = New Date(now_date_timestamp.Year, now_date_timestamp.Month, now_date_timestamp.Day)
        Dim bon_date As Date = New Date(bon_date_timestamp.Year, bon_date_timestamp.Month, bon_date_timestamp.Day)

        Dim latest_date As Date = DateAndTime.DateAdd(DateInterval.Day, -14, now_date_timestamp)


        If bon_date < latest_date Then
            MessageBox.Show("Retur barang tidak bisa dilakukan untuk bon tersebut," & vbCrLf & "karena sudah lebih dari 14 hari.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        Dim objDlgTrnPosReturNote As dlgTrnPosReturNote = New dlgTrnPosReturNote(Me.DSNLocal, Me.POS, o)
        With objDlgTrnPosReturNote
            .FormBorderStyle = FormBorderStyle.Fixed3D
            .WindowState = FormWindowState.Maximized
            '.OpenDialog(Me, "", "", "", "", Nothing)
            .POSTransactionPrepare()
            .Show()
            .BringToFront()
        End With
    End Sub




    Private Sub btnRePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRePrint.Click
        ' 010.010.10.0500000161

        Dim bon As TransStore.POS.PosHeader = New TransStore.POS.PosHeader
        Dim o As PosBonData
        Dim txt As String = ""
        Dim txtPreview As String = ""
        Dim ret As Boolean
        Dim strs() As String
        Dim i As Integer


        bon.bon_id = Me.objBonId.Text


        txtPreview &= "             10        20        30        40        50        60        70        80        90       100       110       120       130       " & vbCrLf
        txtPreview &= "     12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567" & vbCrLf
        txtPreview &= vbCrLf

        o = Me.POS.GetBonData(bon)
        If o.Header.Rows.Count <= 0 Then
            MessageBox.Show("Bon '" & bon.bon_id & "' tidak ditemukan", "Bon", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If




        strs = Me.POS.FormatBon(o, True, False)
        For i = 0 To strs.Length - 1
            txtPreview &= (i + 1).ToString.PadLeft(3) & "  " & strs(i) & vbCrLf
            txt &= strs(i) & vbCrLf
        Next
        'txt = String.Join(vbCrLf, Me.POS.FormatBon(o))

        Dim bon_date_timestamp As Date = o.Header.Rows(0).Item("bon_date")
        Dim now_date_timestamp As Date = Now.Date
        Dim now_date As Date = New Date(now_date_timestamp.Year, now_date_timestamp.Month, now_date_timestamp.Day)
        Dim bon_date As Date = New Date(bon_date_timestamp.Year, bon_date_timestamp.Month, bon_date_timestamp.Day)

        'If bon_date < now_date Then
        '    MessageBox.Show("Re-print bon tidak bisa dilakukan.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If


        If Me.chkBonPreview.Checked Then
            ret = uiTrnPosEN.SendTextToPrinter(Me.POS, txtPreview, PrintMethod.PreviewOnly, LX300.P_PAGE_07)
        Else
            ret = uiTrnPosEN.SendTextToPrinter(Me.POS, txt, PrintMethod.PrintOnly, LX300.P_PAGE_07)
        End If

    End Sub


    Private Sub btnViewDetil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewDetil.Click
        Dim dlg As dlgTrnPosVoid = New dlgTrnPosVoid()
        Dim ret As Object
        Dim bon As TransStore.POS.PosHeader = New TransStore.POS.PosHeader
        Dim o As PosBonData
        Dim args As Object() = New Object() {}

        bon.bon_id = Me.objBonId.Text
        o = Me.POS.GetBonData(bon)
        If o.Header.Rows.Count <= 0 Then
            MessageBox.Show("Bon '" & bon.bon_id & "' tidak ditemukan", "Bon", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        args = New Object() {o, "VIEW", Me.POS, ""}
        ret = dlg.OpenDialog(Me, args)
    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        ' Cek bon
        Dim bon As TransStore.POS.PosHeader = New TransStore.POS.PosHeader
        Dim o As PosBonData
        bon.bon_id = Me.objBonId.Text
        o = Me.POS.GetBonData(bon)
        If o.Header.Rows.Count <= 0 Then
            MessageBox.Show("Bon '" & bon.bon_id & "' tidak ditemukan", "Bon", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Me.pnlAuth2.Visible = True
        Me.pnlAuth2Shadow.Visible = True
        Me.objUsername.Focus()

        'Dim dlg As dlgTrnPosVoid = New dlgTrnPosVoid()
        'Dim ret As Object
        'Dim bon As TransStore.POS.PosHeader = New TransStore.POS.PosHeader
        'Dim o As PosBonData
        'Dim args As Object() = New Object() {}
        'Dim id As String
        'Dim strs() As String
        'Dim i As Integer
        'Dim txt As String = ""

        'bon.bon_id = Me.objBonId.Text
        'o = Me.POS.GetBonData(bon)

        'args = New Object() {o, "VOID", Me.POS}
        'ret = dlg.OpenDialog(Me, args)

        'If ret Is Nothing Then
        '    Exit Sub
        'End If

        'Try
        '    If ret.Length > 0 Then
        '        id = Trim(ret(0))
        '        If id <> "" Then
        '            strs = Me.POS.FormatBon(o, True, False)
        '            For i = 0 To strs.Length - 1
        '                txt &= strs(i) & vbCrLf
        '            Next
        '            ret = uiTrnPosEN.SendTextToPrinter(Me.POS, txt, PrintMethod.PrintOnly, LX300.P_PAGE_07)
        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Void", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub

    Private Sub btnClosing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClosing.Click
        Dim strs() As String = {}
        Dim txtPreview As String = ""
        Dim txt As String = ""

        Dim i As Integer

        txtPreview &= "             10        20        30        40        50        60        70        80        90       100       110       120       130       " & vbCrLf
        txtPreview &= "     12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567" & vbCrLf
        txtPreview &= vbCrLf

        Try
            strs = Me.POS.FormatClosingReport(Me.chkMachineOnly.Checked, Me.chkTransactionSummary.Checked, Me.chkBonRekap.Checked, Me.chkArticleBreakdown.Checked, Me.chkClosingPreviewOnly.Checked, Me.objDate.Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "POS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        For i = 0 To strs.Length - 1
            If Trim(strs(i)) = "{PRINTER_FF}" Then
                If Me.chkClosingPreviewOnly.Checked Then
                    txtPreview &= (i + 1).ToString.PadLeft(3) & "  " & "▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒end of page▒▒▒▒" & vbCrLf
                Else
                    txt &= LX300.P_FF
                End If
            Else
                txtPreview &= (i + 1).ToString.PadLeft(3) & "  " & strs(i) & vbCrLf
                txt &= strs(i) & vbCrLf
            End If
        Next

        If Me.chkClosingPreviewOnly.Checked Then
            SendTextToPrinter(Me.POS, txtPreview, PrintMethod.PreviewOnly, LX300.P_PAGE_07)
        Else
            SendTextToPrinter(Me.POS, txt, PrintMethod.PrintOnly, LX300.P_PAGE_07)
        End If

    End Sub

    Private Sub btnSignIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignIn.Click

        Try
            If Me.POS.GetServerName() = __CENTRALSERVER_IP Then
                MessageBox.Show("Sign In tidak perlu digunakan untuk lingkungan Duren Tiga", "Sign In", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ' Apakah bisa sign in
            If Me.POS.SignInStatusIsOpened() Then
                MessageBox.Show("Anda belum Belum sign off pada transaksi sebelumnya." & vbCrLf & "Silakan anda sign off terlebih dahulu", "Sign In", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sign In", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try



        If Me.bgwHeposDataUpdater Is Nothing Then
            Me.bgwHeposDataUpdater = New System.ComponentModel.BackgroundWorker
            Me.bgwHeposDataUpdater.WorkerReportsProgress = True
            Me.bgwHeposDataUpdater.WorkerSupportsCancellation = True
        End If

        If Me.btnSignIn.Text = "Sign In" Then
            Dim param As TransStore.PosDataUpdaterParam = New TransStore.PosDataUpdaterParam
            param.service_handshake = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=handshake"
            param.service_getupdater = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=getupdater"
            param.service_setclientupdatestatus = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=setclientupdatestatus"
            param.service_goodby = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=goodby"
            param.service_getmodifieditem = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=getmodifieditem"
            param.service_invinfoget = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=invinfoget"
            param.service_invinfopurge = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=invinfopurge"

            Me.LabelDataUpdate.Visible = True
            Me.ProgressBarDataUpdate.Visible = True
            Me.btnSignIn.Text = "Cancel"

            'Disable Item yg lain
            Me.groupPOSConsole.Enabled = False
            Me.groupClossing.Enabled = False
            Me.groupTransaction.Enabled = False
            Me.groupSalesSend.Enabled = False
            Me.btnSignOff.Enabled = False
            Me.btnUpdate.Enabled = False


            ' Run Asyncronous
            Me.bgwHeposDataUpdater.RunWorkerAsync(param)
        Else
            Me.bgwHeposDataUpdater.CancelAsync()
        End If
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        If Me.POS.GetServerName() = __CENTRALSERVER_IP Then
            MessageBox.Show("Sign In tidak perlu digunakan untuk lingkungan Duren Tiga")
            Exit Sub
        End If

        If Me.bgwHeposDataSender Is Nothing Then
            Me.bgwHeposDataSender = New System.ComponentModel.BackgroundWorker
            Me.bgwHeposDataSender.WorkerReportsProgress = True
            Me.bgwHeposDataSender.WorkerSupportsCancellation = True
        End If

        If Me.btnSend.Text = "Send" Then
            Dim param As TransStore.PosDataUpdaterParam = New TransStore.PosDataUpdaterParam
            param.dt = Me.dtSalesTobeSent.Value
            param.SENDDATAMODE = Me.POS.SENDDATAMODE
            param.SENDDATAVER = Me.POS.SENDDATAVER
            param.service_handshake = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=handshake"
            param.service_goodby = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=goodby"

            If param.SENDDATAVER <> "" Then
                param.service_getupdater = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=processuploadedsales" & param.SENDDATAVER
            Else
                param.service_getupdater = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=processuploadedsales"
            End If

            If TypeOf (sender) Is Timer Then
                param.auto = True
            Else
                param.auto = False
            End If

            Me.LabelDataSend.Visible = True
            Me.ProgressBarDataSend.Visible = True
            Me.btnSend.Text = "Cancel"

            'Disable Item yg lain
            Me.btnSignIn.Enabled = False
            Me.groupPOSConsole.Enabled = False
            Me.groupClossing.Enabled = False
            Me.groupTransaction.Enabled = False
            Me.dtSalesTobeSent.Enabled = False
            Me.btnSignOff.Enabled = False
            Me.btnUpdate.Enabled = False


            System.Net.ServicePointManager.Expect100Continue = False

            ' Run Asyncronous
            Me.bgwHeposDataSender.RunWorkerAsync(param)
        Else
            Me.bgwHeposDataSender.CancelAsync()
        End If

    End Sub

    Private Sub btnSignOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignOff.Click
        Try
            If Me.POS.GetServerName() = __CENTRALSERVER_IP Then
                MessageBox.Show("Sign Off tidak perlu digunakan untuk lingkungan Duren Tiga", "Sign Off", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            ' Cek apakah ada data yg belum dikirim
            If Me.POS.IfUnSyncronizedDataExist() Then
                MessageBox.Show("Anda harus mengirimkan data sebelum Sign Off", "Sign Off", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sign Off", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try




        If Me.bgwHeposSignoff Is Nothing Then
            Me.bgwHeposSignoff = New System.ComponentModel.BackgroundWorker
            Me.bgwHeposSignoff.WorkerReportsProgress = True
            Me.bgwHeposSignoff.WorkerSupportsCancellation = True
        End If

        If Me.btnSignOff.Text = "Sign Off" Then
            Dim param As TransStore.PosDataUpdaterParam = New TransStore.PosDataUpdaterParam
            param.service_handshake = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=handshake"
            param.service_getupdater = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=processuploadedsales"
            param.service_goodby = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=goodby"
            Me.LabelSignoff.Visible = True
            Me.ProgressBarSignoff.Visible = True
            Me.btnSignOff.Text = "Cancel"

            'Disable Item yg lain
            Me.btnSignIn.Enabled = False
            Me.groupPOSConsole.Enabled = False
            Me.groupClossing.Enabled = False
            Me.groupTransaction.Enabled = False
            Me.groupSalesSend.Enabled = False
            Me.btnUpdate.Enabled = False

            ' Run Asyncronous
            Me.bgwHeposSignoff.RunWorkerAsync(param)
        Else
            Me.bgwHeposSignoff.CancelAsync()
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Try
            If Me.POS.GetServerName() = __CENTRALSERVER_IP Then
                MessageBox.Show("Sign Off tidak perlu digunakan untuk lingkungan Duren Tiga", "Sign Off", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Update", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try




        If Me.bgwHeposUpdatebin Is Nothing Then
            Me.bgwHeposUpdatebin = New System.ComponentModel.BackgroundWorker
            Me.bgwHeposUpdatebin.WorkerReportsProgress = True
            Me.bgwHeposUpdatebin.WorkerSupportsCancellation = True
        End If

        If Me.btnUpdate.Text = "Update Data" Then
            'Dim param As TransStore.PosDataUpdaterParam = New TransStore.PosDataUpdaterParam
            'param.service_handshake = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=handshake"
            'param.service_getupdater = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=processuploadedsales"
            'param.service_goodby = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=goodby"


            Dim param As TransStore.PosDataUpdaterParam = New TransStore.PosDataUpdaterParam
            param.service_handshake = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=handshake"
            param.service_getupdater = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=getupdater"
            param.service_setclientupdatestatus = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=setclientupdatestatus"
            param.service_goodby = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=goodby"
            param.service_getmodifieditem = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=getmodifieditem"
            param.service_invinfoget = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=invinfoget"
            param.service_invinfopurge = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=invinfopurge"


            Me.LabelUpdateBin.Visible = True
            Me.ProgressBarUpdatebin.Visible = True
            Me.btnUpdate.Text = "Cancel"

            'Disable Item yg lain
            Me.btnSignIn.Enabled = False
            Me.btnSignOff.Enabled = False
            Me.groupPOSConsole.Enabled = False
            Me.groupClossing.Enabled = False
            Me.groupTransaction.Enabled = False
            Me.groupSalesSend.Enabled = False

            ' Run Asyncronous
            Me.bgwHeposUpdatebin.RunWorkerAsync(param)
            'Me.bgwHeposDataUpdater.RunWorkerAsync(param)
        Else
            Me.bgwHeposUpdatebin.CancelAsync()
            ' Me.bgwHeposDataUpdater.CancelAsync()
        End If
    End Sub


    Private Sub btnUpdateManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateManual.Click
        Try
            If Me.POS.GetServerName() = __CENTRALSERVER_IP Then
                MessageBox.Show("Sign Off tidak perlu digunakan untuk lingkungan Duren Tiga", "Sign Off", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Update Manual", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try


        'Browse file
        Dim filename As String

        Dim fd As OpenFileDialog = New OpenFileDialog()
        fd.Title = "File Updater"
        fd.Filter = "txt files (*.txt)|*.txt|Compressed txt files (*.txt.compressed)|*.txt.compressed|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.Multiselect = False
        filename = fd.ShowDialog()





    End Sub

    Private Sub btnVoidOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoidOpen.Click
        'Dim loginberhasil As Boolean
        Dim _username As String
        Dim _password As String

        _username = Me.objUsername.Text
        _password = Me.objPassword.Text



        If Trim(_username) = "" Then
            MessageBox.Show("Username belum diisi", "Void", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Me.btnVoidOpen.Enabled = False


        If Me.bgwHeposSignoff Is Nothing Then
            Me.bgwHeposVoidRequest = New System.ComponentModel.BackgroundWorker
            Me.bgwHeposVoidRequest.WorkerReportsProgress = True
            Me.bgwHeposVoidRequest.WorkerSupportsCancellation = True
        End If

        If Me.btnVoidOpen.Text = "&Void" Then
            ' Authentikasi password di server
            Dim param As TransStore.PosBonVoidRequestParam = New TransStore.PosBonVoidRequestParam
            param.service_handshake = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=handshake"
            param.service_voidrequest = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=voidrequest"
            param.service_goodby = "service.php?t=" & Now().Ticks & "&ns=transbrowser&object=client&act=goodby"
            param.username = _username
            param.password = _password
            param.systemdate = Now()
            param.bon_id = Me.objBonId.Text
            Me.btnVoidOpen.Text = "Cancel"

            'Disable Item yg lain
            Me.btnSignIn.Enabled = False
            Me.btnSignOff.Enabled = False
            Me.groupPOSConsole.Enabled = False
            Me.groupClossing.Enabled = False
            Me.groupTransaction.Enabled = False
            Me.groupSalesSend.Enabled = False
            Me.btnUpdate.Enabled = False

            Me.lblReset.Enabled = False
            Me.lblAuthClose.Enabled = False
            Me.objUsername.Enabled = False
            Me.objPassword.Enabled = False


            ' Run Asyncronous
            Me.bgwHeposVoidRequest.RunWorkerAsync(param)
        Else

            Me.bgwHeposVoidRequest.CancelAsync()
            'Me.bgwHeposVoidRequest.Dispose()
        End If




        'If Me.POS.IsAuthUsername(_username, _password) Then
        '    loginberhasil = True
        'Else
        '    loginberhasil = False
        'End If


        'If loginberhasil Then
        '    Me.objUsername.Text = ""
        '    Me.objPassword.Text = ""
        '    Me.lblAuthClose_LinkClicked(sender, New System.Windows.Forms.LinkLabelLinkClickedEventArgs(New System.Windows.Forms.LinkLabel.Link()))

        '    Me.lblAuthMsg.Visible = False


        '    Dim dlg As dlgTrnPosVoid = New dlgTrnPosVoid()
        '    Dim ret As Object
        '    Dim bon As TransStore.POS.PosHeader = New TransStore.POS.PosHeader
        '    Dim o As PosBonData
        '    Dim args As Object() = New Object() {}
        '    Dim id As String
        '    Dim strs() As String
        '    Dim i As Integer
        '    Dim txt As String = ""

        '    bon.bon_id = Me.objBonId.Text
        '    o = Me.POS.GetBonData(bon)

        '    args = New Object() {o, "VOID", Me.POS, _username}
        '    ret = dlg.OpenDialog(Me, args)

        '    If ret Is Nothing Then
        '        Exit Sub
        '    End If

        '    Try
        '        If ret.Length > 0 Then
        '            id = Trim(ret(0))
        '            If id <> "" Then
        '                strs = Me.POS.FormatBon(o, True, False)
        '                For i = 0 To strs.Length - 1
        '                    txt &= strs(i) & vbCrLf
        '                Next
        '                ret = uiTrnPosEN.SendTextToPrinter(Me.POS, txt, PrintMethod.PrintOnly, LX300.P_PAGE_07)
        '            End If
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "Void", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try




        'Else
        '    Me.lblAuthMsg.Visible = True
        '    Me.objPassword.Text = ""
        '    Me.objPassword.Focus()
        'End If




    End Sub



    Private Sub objUsername_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles objUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.objUsername.Text <> "" Then
                Me.objPassword.Focus()
            End If
        End If
    End Sub

    Private Sub objPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles objPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.objPassword.Text <> "" Then
                Me.btnVoidOpen_Click(sender, New System.EventArgs)
            End If
        End If
    End Sub

    Private Sub lblAuthClose_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblAuthClose.LinkClicked
        Me.pnlAuth2.Visible = False
        Me.pnlAuth2Shadow.Visible = False
    End Sub




#Region " Sign In Background worker "

    Private Sub bgwHeposDataUpdater_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles bgwHeposDataUpdater.Disposed
    End Sub

    Private Sub bgwHeposDataUpdater_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwHeposDataUpdater.DoWork
        Dim CriteriaBuilder As Translib.QueryCriteria = New Translib.QueryCriteria
        Dim result As TransStore.PosDataUpdaterResult = New TransStore.PosDataUpdaterResult
        Dim bgw As System.ComponentModel.BackgroundWorker = DirectCast(sender, System.ComponentModel.BackgroundWorker)
        Dim tblHandshake, tblUpdater, tblComplete, tblModifiedItem, tblInvUpdateInfo As DataTable
        Dim dr As DataRow
        Dim respond As String = ""
        Dim time As Date = Now()
        Dim clientdate As String = time.Year & "-" & time.Month.ToString.PadLeft(2, "0") & "-" & time.Day.ToString.PadLeft(2, "0") & " " & time.Hour.ToString.PadLeft(2, "0") & ":" & time.Minute.ToString.PadLeft(2, "0") & ":" & time.Second.ToString.PadLeft(2, "0")
        Dim synsign_id, updater_id As String
        Dim sqliteConn As SQLite.SQLiteConnection


        Try
            Dim param As TransStore.PosDataUpdaterParam = CType(e.Argument, TransStore.PosDataUpdaterParam)
            result.param = param

            CriteriaBuilder = New Translib.QueryCriteria
            CriteriaBuilder.AddCriteria("region_id", True, Me.POS.RegionId)
            CriteriaBuilder.AddCriteria("branch_id", True, Me.POS.BranchId)
            CriteriaBuilder.AddCriteria("machine_id", True, Me.POS.MachineId)
            CriteriaBuilder.AddCriteria("client_date", True, clientdate)
            CriteriaBuilder.AddCriteria("synsign_type", True, "SIGNIN")

            Me.Progress = 5
            Me.Message = "Connecting to " & param.service_handshake & "..."
            bgw.ReportProgress(1)
            tblHandshake = Me.LoadDataIntoDatatable(param.service_handshake, CriteriaBuilder.Serialize(), respond)
            If tblHandshake.Rows.Count <= 0 Then
                Throw New Exception("Handshake error. tblHandshake Return 0 row" & vbCrLf & Mid(respond, 1, 100))
            End If
            Me.Progress = 10
            Me.Message = "Connected."
            bgw.ReportProgress(1)

            System.Threading.Thread.Sleep(50)


            dr = tblHandshake.Rows(0)
            synsign_id = Me.POS.SynHandshake(dr)

            ' Ambil id updater
            Dim another_region_to_be_update As String = Me._another_region_to_be_update
            Dim region_to_be_update As String = Me.POS.RegionId & "|" & another_region_to_be_update
            Dim regions() As String = region_to_be_update.Split("|")
            Dim n As Integer = regions.Length
            Dim i As Integer
            Dim region_id As String = ""


            Me.Progress = 15
            Me.Message = "Getting Updater..."
            bgw.ReportProgress(1)
            For i = 0 To n - 1
                region_id = regions(i)

                CriteriaBuilder = New Translib.QueryCriteria
                CriteriaBuilder.AddCriteria("region_id", True, region_id)
                CriteriaBuilder.AddCriteria("branch_id", True, Me.POS.BranchId)
                CriteriaBuilder.AddCriteria("machine_id", True, Me.POS.MachineId)
                CriteriaBuilder.AddCriteria("client_date", True, clientdate)
                CriteriaBuilder.AddCriteria("synsign_type", True, "SIGNIN")
                CriteriaBuilder.AddCriteria("synsign_id", True, synsign_id)


                Me.Message = "Getting Updater for " & region_id & "..."
                bgw.ReportProgress(1)

                tblUpdater = Me.LoadDataIntoDatatable(param.service_getupdater, CriteriaBuilder.Serialize(), respond)
                If tblUpdater.Rows.Count > 0 Then
                    ' Ada data yang harus diupdate
                    dr = tblUpdater.Rows(0)
                    updater_id = dr("id")

                    CriteriaBuilder.AddCriteria("updater_id", True, updater_id)

                    Me.LoadDataIntoDatatable(param.service_setclientupdatestatus, CriteriaBuilder.Serialize(), respond)


                    If Not Me.POS.SynCheckUpdater(updater_id) Then
                        ' Client belum diupdate
                        ' Download data

                        'Cek apakah ada direktory Transbrowser di My Documents
                        Dim updaterfolder As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/Transbrowser"
                        Dim f As New IO.DirectoryInfo(updaterfolder)

                        If Not f.Exists Then
                            IO.Directory.CreateDirectory(updaterfolder)
                        End If


                        'Cek apakah ada direktory Transbrowser/updater di My Documents
                        updaterfolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/Transbrowser/Updater"
                        f = New IO.DirectoryInfo(updaterfolder)
                        If Not f.Exists Then
                            IO.Directory.CreateDirectory(updaterfolder)
                        End If


                        Dim fileupdater As String = Me._remotewebserviceaddress & "/updater/" & updater_id
                        Dim cachefile As String = updaterfolder & "/" & updater_id
                        Try
                            Me.Progress = 18
                            Me.Message = "Downloading Updater (" & updater_id & ")..."
                            bgw.ReportProgress(1)
                            My.Computer.Network.DownloadFile(fileupdater, cachefile, "", "", True, 100, True)
                        Catch ex As Exception
                            Throw New Exception(fileupdater & vbCrLf & ex.Message)
                        End Try


                        ' Extract cachefile apabila file nya tercompressy
                        If Strings.Right(cachefile, 9).ToLower = ".compress" Then
                            TransbrowserFileCompress.UnCompressFile(cachefile, TransbrowserFileCompress.enuAlgorithm.Deflate)
                            IO.File.Delete(cachefile)
                            cachefile = cachefile & ".txt"
                        End If

                        ' Baca DATA dari SQLite
                        Dim cmd As SQLite.SQLiteCommand
                        Dim drlite As SQLite.SQLiteDataReader
                        Dim tablename, updatemethod, keys As String

                        sqliteConn = New SQLite.SQLiteConnection("Data Source=" & cachefile & ";Version=2;Compress=True;")
                        Try
                            sqliteConn.Open()
                            cmd = sqliteConn.CreateCommand()
                            cmd.CommandText = "SELECT * FROM _UPDATEMETHOD_"
                            drlite = cmd.ExecuteReader()
                            While drlite.Read()
                                tablename = drlite("tablename")
                                updatemethod = drlite("updatemethod")
                                keys = drlite("keys")

                                Me.Progress = 20
                                Me.Message = "Updating " & tablename & "..."
                                bgw.ReportProgress(1)

                                Me.POS.UpdateTable(tablename, updatemethod, keys, sqliteConn, bgw)
                            End While
                        Catch ex As Exception
                            Throw New Exception("bgwHeposDataUpdater_DoWork:" & vbCrLf & cachefile & vbCrLf & ex.Message)
                        Finally
                            sqliteConn.Close()
                        End Try

                        ' Tandai bahwa data sudah berhasil diupdate

                        Me.Progress = 40
                        Me.Message = "Recording update..."
                        bgw.ReportProgress(1)
                        Me.POS.RecordUpdaterID(updater_id, Me.POS.RegionId, synsign_id)

                        ' Hapus lagi 
                        IO.File.Delete(cachefile)

                        ' Kasi tau ke server kalau updater telah berahasil diupdate
                        Me.LoadDataIntoDatatable(param.service_setclientupdatestatus & "&confirm=1", CriteriaBuilder.Serialize(), respond)


                    Else
                        Me.Progress = 30
                        Me.Message = "Data is up to date."
                        bgw.ReportProgress(1)
                        System.Threading.Thread.Sleep(300)
                    End If
                Else
                    Me.Progress = 30
                    Me.Message = "Nothing to update."
                    bgw.ReportProgress(1)
                    System.Threading.Thread.Sleep(300)
                End If




            Next


            'Dim ColRegUpdInf As Collection = New Collection
            'Dim objRegionUpdateInfo As TransStore.RegionUpdateInfo
            'Dim filename As String
            Dim row As DataRow
            Dim tblUpdateStockFile As DataTable = New DataTable
            tblUpdateStockFile.Columns.Add(New System.Data.DataColumn("region_id", GetType(System.String)))
            tblUpdateStockFile.Columns.Add(New System.Data.DataColumn("branch_id", GetType(System.String)))
            tblUpdateStockFile.Columns.Add(New System.Data.DataColumn("filename", GetType(System.String)))



            ' Update inventory
            For i = 0 To regions.Length - 1
                region_id = regions(i)
                CriteriaBuilder = New Translib.QueryCriteria
                CriteriaBuilder.AddCriteria("region_id", True, region_id)
                CriteriaBuilder.AddCriteria("branch_id", True, Me.POS.BranchId)
                CriteriaBuilder.AddCriteria("machine_id", True, Me.POS.MachineId)
                CriteriaBuilder.AddCriteria("client_date", True, clientdate)
                CriteriaBuilder.AddCriteria("synsign_type", True, "GET.STOCK")
                CriteriaBuilder.AddCriteria("synsign_id", True, synsign_id)

                Me.Progress = 45
                Me.Message = "Get Stock position Information (" & region_id & ")."
                bgw.ReportProgress(1)
                tblInvUpdateInfo = Me.LoadDataIntoDatatable(param.service_invinfoget, CriteriaBuilder.Serialize(), respond)

                'objRegionUpdateInfo = New TransStore.RegionUpdateInfo
                'objRegionUpdateInfo.region_id = region_id
                'objRegionUpdateInfo.filename = tblInvUpdateInfo.Rows(0).Item("filename")
                'ColRegUpdInf.Add(objRegionUpdateInfo, region_id)
                If tblInvUpdateInfo.Rows.Count > 0 Then
                    row = tblUpdateStockFile.NewRow()
                    row("region_id") = region_id
                    row("branch_id") = Me.POS.BranchId
                    row("filename") = tblInvUpdateInfo.Rows(0).Item("filename").ToString
                    tblUpdateStockFile.Rows.Add(row)
                End If
            Next
            tblUpdateStockFile.AcceptChanges()
            System.Threading.Thread.Sleep(50)

            Dim rows() As DataRow
            Dim filename As String
            ' Download invupdate
            For i = 0 To regions.Length - 1
                region_id = regions(i)
                CriteriaBuilder = New Translib.QueryCriteria
                CriteriaBuilder.AddCriteria("region_id", True, region_id)
                CriteriaBuilder.AddCriteria("branch_id", True, Me.POS.BranchId)
                CriteriaBuilder.AddCriteria("machine_id", True, Me.POS.MachineId)
                CriteriaBuilder.AddCriteria("client_date", True, clientdate)
                CriteriaBuilder.AddCriteria("synsign_type", True, "DL.STOCK")
                CriteriaBuilder.AddCriteria("synsign_id", True, synsign_id)

                Me.Progress = 50
                Me.Message = "Downloading Stock position Information (" & region_id & ")."
                bgw.ReportProgress(1)

                'objRegionUpdateInfo = CType(ColRegUpdInf(region_id), TransStore.RegionUpdateInfo)
                'filename = objRegionUpdateInfo.filename

                rows = tblUpdateStockFile.Select("region_id='" & region_id & "'")
                If rows.Length = 0 Then
                    Continue For
                End If


                filename = rows(0).Item("filename")


                'Cek apakah ada direktory Transbrowser di My Documents
                Dim updaterfolder As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/Transbrowser"
                Dim f As New IO.DirectoryInfo(updaterfolder)

                If Not f.Exists Then
                    IO.Directory.CreateDirectory(updaterfolder)
                End If


                'Cek apakah ada direktory Transbrowser/updater di My Documents
                updaterfolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/Transbrowser/Updater"
                f = New IO.DirectoryInfo(updaterfolder)
                If Not f.Exists Then
                    IO.Directory.CreateDirectory(updaterfolder)
                End If


                Dim fileupdater As String = Me._remotewebserviceaddress & "/updater/inv/" & filename
                Dim cachefile As String = updaterfolder & "/" & filename
                Try
                    My.Computer.Network.DownloadFile(fileupdater, cachefile, "", "", True, 100, True)
                Catch ex As Exception
                    Throw New Exception(fileupdater & vbCrLf & ex.Message)
                End Try


                ' Extract cachefile apabila file nya tercompressy
                If Strings.Right(cachefile, 9).ToLower = ".compress" Then
                    TransbrowserFileCompress.UnCompressFile(cachefile, TransbrowserFileCompress.enuAlgorithm.Deflate)
                    IO.File.Delete(cachefile)
                    cachefile = cachefile & ".txt"
                End If

            Next
            System.Threading.Thread.Sleep(50)



            ' Update local inventory
            For i = 0 To regions.Length - 1
                region_id = regions(i)
                CriteriaBuilder = New Translib.QueryCriteria
                CriteriaBuilder.AddCriteria("region_id", True, region_id)
                CriteriaBuilder.AddCriteria("branch_id", True, Me.POS.BranchId)
                CriteriaBuilder.AddCriteria("machine_id", True, Me.POS.MachineId)
                CriteriaBuilder.AddCriteria("client_date", True, clientdate)
                CriteriaBuilder.AddCriteria("synsign_type", True, "DL.STOCK")
                CriteriaBuilder.AddCriteria("synsign_id", True, synsign_id)

                Me.Progress = 55
                Me.Message = "Updating local stock position Information (" & region_id & ")."
                bgw.ReportProgress(1)


                rows = tblUpdateStockFile.Select("region_id='" & region_id & "'")
                If rows.Length = 0 Then
                    Continue For
                End If
                filename = rows(0).Item("filename")



                Dim updaterfolder As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Transbrowser\Updater"
                Dim cachefile As String = updaterfolder & "\" & filename & ".txt"

                ' Import Data Stock
                Me.POS.LoadStockFromFile(region_id, cachefile, Now())


            Next
            System.Threading.Thread.Sleep(50)





            ' Removing stock cache
            For i = 0 To regions.Length - 1
                region_id = regions(i)
                'objRegionUpdateInfo = CType(ColRegUpdInf(region_id), TransStore.RegionUpdateInfo)
                'filename = objRegionUpdateInfo.filename
                rows = tblUpdateStockFile.Select("region_id='" & region_id & "'")
                If rows.Length = 0 Then
                    Continue For
                End If
                filename = rows(0).Item("filename")


                CriteriaBuilder = New Translib.QueryCriteria
                CriteriaBuilder.AddCriteria("region_id", True, region_id)
                CriteriaBuilder.AddCriteria("filename", True, filename)
                CriteriaBuilder.AddCriteria("branch_id", True, Me.POS.BranchId)
                CriteriaBuilder.AddCriteria("machine_id", True, Me.POS.MachineId)
                CriteriaBuilder.AddCriteria("client_date", True, clientdate)
                CriteriaBuilder.AddCriteria("synsign_type", True, "DL.STOCK")
                CriteriaBuilder.AddCriteria("synsign_id", True, synsign_id)

                Me.Progress = 60
                Me.Message = "Removing stock cache (" & region_id & ")."
                bgw.ReportProgress(1)
                tblInvUpdateInfo = Me.LoadDataIntoDatatable(param.service_invinfopurge, CriteriaBuilder.Serialize(), respond)

            Next
            System.Threading.Thread.Sleep(50)




            ' Get updated data
            ' TODO: otomatis mencari data yang mengalami perubahan
            tblModifiedItem = New DataTable()




            ' Update Database sehubungan dengan voucher promo, dll
            Me.POS.InjectPromoData()



            ' Kembalikan lagi Criteria Builder
            CriteriaBuilder = New Translib.QueryCriteria
            CriteriaBuilder.AddCriteria("region_id", True, Me.POS.RegionId)
            CriteriaBuilder.AddCriteria("branch_id", True, Me.POS.BranchId)
            CriteriaBuilder.AddCriteria("machine_id", True, Me.POS.MachineId)
            CriteriaBuilder.AddCriteria("client_date", True, clientdate)
            CriteriaBuilder.AddCriteria("synsign_type", True, "SIGNIN")
            CriteriaBuilder.AddCriteria("synsign_id", True, synsign_id)


            ' Say goodby to server
            Me.Progress = 85
            Me.Message = "Finishing update..."
            bgw.ReportProgress(1)
            tblComplete = Me.LoadDataIntoDatatable(param.service_goodby, CriteriaBuilder.Serialize(), respond)
            If tblComplete.Rows.Count <= 0 Then
                Throw New Exception("Finishing Error. tblComplete Return 0 row" & vbCrLf & Mid(respond, 1, 100))
            End If

            Me.POS.SynComplete(synsign_id)
            Me.Progress = 100
            Me.Message = "Completed."
            bgw.ReportProgress(1)
            System.Threading.Thread.Sleep(300)


            result.success = True
            e.Result = result
        Catch ex As Exception
            Me.BackgroundworkerStatus = EBackgroundworkerStatus.Fail
            Me.Status = "Error"
            Me.Message = ex.Message
            result.success = False
            result.errormessage = ex.Message
            e.Result = result
        End Try
    End Sub

    Private Sub bgwHeposDataUpdater_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwHeposDataUpdater.ProgressChanged
        Me.ProgressBarDataUpdate.Value = Me.Progress
        Me.LabelDataUpdate.Text = Me.Message
        Me.ProgressBarDataUpdate.Refresh()
        Me.LabelDataUpdate.Refresh()


    End Sub

    Private Sub bgwHeposDataUpdater_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwHeposDataUpdater.RunWorkerCompleted
        Dim result As TransStore.PosDataUpdaterResult
        Dim last_synsign_id As String

        Try
            result = CType(e.Result, TransStore.PosDataUpdaterResult)
            If e.Cancelled Then
                MessageBox.Show("Cancel")
            End If

            If Not result.success Then Throw New Exception(result.errormessage)




            last_synsign_id = Me.POS.GetClientSignInData()
            If last_synsign_id <> "" Then
                Me.obj_last_synsign_id.Text = "Signed In: " & last_synsign_id
            Else
                Me.obj_last_synsign_id.Text = ""
            End If
            Me.obj_last_synsign_id.AutoSize = True
            Me.obj_last_synsign_id.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Update", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.LabelDataUpdate.Visible = False
            Me.ProgressBarDataUpdate.Visible = False
            Me.bgwHeposDataUpdater = Nothing
            Me.btnSignIn.Text = "Sign In"

            'Enable Item yg lain
            Me.groupPOSConsole.Enabled = True
            Me.groupClossing.Enabled = True
            Me.groupTransaction.Enabled = True
            Me.groupSalesSend.Enabled = True
            Me.btnSignOff.Enabled = True
            Me.btnUpdate.Enabled = True
        End Try

    End Sub





#End Region

#Region " Send Data Background Worker "

    Private Sub bgwHeposDataSender_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles bgwHeposDataSender.Disposed

    End Sub

    Private Sub bgwHeposDataSender_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwHeposDataSender.DoWork
        Dim CriteriaBuilder As Translib.QueryCriteria = New Translib.QueryCriteria
        Dim result As TransStore.PosDataUpdaterResult = New TransStore.PosDataUpdaterResult
        Dim bgw As System.ComponentModel.BackgroundWorker = DirectCast(sender, System.ComponentModel.BackgroundWorker)
        Dim exporter As TransStore.DataExporter = New TransStore.DataExporter()
        Dim queues As TransStore.DataExporter.TableQueue()
        Dim que As TransStore.DataExporter.TableQueue
        Dim dt As Date
        Dim tblHandshake, tblUpdate, tblComplete As DataTable
        Dim respond As String = ""
        Dim time As Date = Now()
        Dim clientdate As String = time.Year & "-" & time.Month.ToString.PadLeft(2, "0") & "-" & time.Day.ToString.PadLeft(2, "0") & " " & time.Hour.ToString.PadLeft(2, "0") & ":" & time.Minute.ToString.PadLeft(2, "0") & ":" & time.Second.ToString.PadLeft(2, "0")
        Dim synsign_id As String = ""
        Dim synsign_dateserver As Date
        Dim dr As DataRow
        Dim cmd As SQLite.SQLiteCommand
        Dim tblPOS As DataTable = New DataTable()
        Dim UploadDataShowUI As Boolean
        Dim UploadDataStatusText As String

        Me.bgwHeposDataSender_ReportProgress(bgw, 1, "Starting... ")
        Me.bgwHeposDataSender_ReportProgress(bgw, 2, "Starting... ")
        Me.bgwHeposDataSender_ReportProgress(bgw, 3, "Starting... ")


        Try
            Dim param As TransStore.PosDataUpdaterParam = CType(e.Argument, TransStore.PosDataUpdaterParam)
            result.param = param

            ' Setting jika autosend, Dilaog upload tidak perlu ditampilkan
            If param.auto Then
                UploadDataShowUI = True
                UploadDataStatusText = " (auto)"
            Else
                UploadDataShowUI = True
                UploadDataStatusText = ""
            End If

            If param.SENDDATAVER <> "" Then
                UploadDataStatusText &= " ver" & param.SENDDATAVER
            End If


            Dim dtSQL As String = param.dt.Year.ToString & "-" & param.dt.Month.ToString.PadLeft(2, "0") & "-" & param.dt.Day.ToString.PadLeft(2, "0")
            Dim intNumOfPrevBonEdited As Integer = Me.POS.NumOfPrevBonEdited(dtSQL)
            Dim strNumOfPrevBonEdited As String = ""
            If intNumOfPrevBonEdited > 0 Then
                strNumOfPrevBonEdited = ", plus " & intNumOfPrevBonEdited & " bon"
            End If

            Me.bgwHeposDataSender_ReportProgress(bgw, 4, "Connecting to " & param.service_handshake & "...")
            System.Threading.Thread.Sleep(100)
            CriteriaBuilder = New Translib.QueryCriteria
            CriteriaBuilder.AddCriteria("region_id", True, Me.POS.RegionId)
            CriteriaBuilder.AddCriteria("branch_id", True, Me.POS.BranchId)
            CriteriaBuilder.AddCriteria("machine_id", True, Me.POS.MachineId)
            CriteriaBuilder.AddCriteria("client_date", True, clientdate)
            CriteriaBuilder.AddCriteria("synsign_type", True, "SENDDATA")
            CriteriaBuilder.AddCriteria("synsign_note", True, "Data yg dikirim tgl :" & String.Format("{0:dd-MM-yyyy}{1}" & strNumOfPrevBonEdited, param.dt, UploadDataStatusText))
            tblHandshake = Me.LoadDataIntoDatatable(param.service_handshake, CriteriaBuilder.Serialize(), respond)
            If tblHandshake.Rows.Count <= 0 Then
                Throw New Exception("Handshake error. tblHandshake Return 0 row" & vbCrLf & Mid(respond, 1, 100))
            End If
            Me.bgwHeposDataSender_ReportProgress(bgw, 5, "Connected.")
            dr = tblHandshake.Rows(0)
            synsign_id = Me.POS.SynHandshake(dr)
            synsign_dateserver = dr("synsign_dateserver")
            CriteriaBuilder.AddCriteria("synsign_id", True, synsign_id)


            ' Check Folder
            'Cek apakah ada direktory Transbrowser di My Documents
            Dim senderfolder As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/Transbrowser"
            Dim f As New IO.DirectoryInfo(senderfolder)
            Me.bgwHeposDataSender_ReportProgress(bgw, 7, "Check folder: " & senderfolder)
            System.Threading.Thread.Sleep(100)
            If Not f.Exists Then
                IO.Directory.CreateDirectory(senderfolder)
            End If

            'Cek apakah ada direktory Transbrowser/updater di My Documents
            senderfolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/Transbrowser/Sender"
            f = New IO.DirectoryInfo(senderfolder)
            Me.bgwHeposDataSender_ReportProgress(bgw, 8, "Check folder: " & senderfolder)
            If Not f.Exists Then
                IO.Directory.CreateDirectory(senderfolder)
            End If

            queues = New TransStore.DataExporter.TableQueue() { _
                        exporter.__Create_transaksi_hepos(param, "MERGE", New String() {"bon_id"}), _
                        exporter.__Create_transaksi_heposdetil(param, "MERGE", New String() {"bon_id", "bondetil_line"}), _
                        exporter.__Create_transaksi_hepospayment(param, "MERGE", New String() {"bon_id", "payment_line"}) _
                  }

            ' Buat data SQlite
            Dim cachefile, cache As String
            Dim sqliteConn As SQLite.SQLiteConnection

            dt = param.dt
            cachefile = "SL." & Me.POS.RegionId & "." & Me.POS.BranchId & "." & dt.Year.ToString & dt.Month.ToString.PadLeft(2, "0") & dt.Day.ToString.PadLeft(2, "0") & "." & Now.Ticks().ToString & ".db"
            cache = senderfolder & "/" & cachefile
            sqliteConn = New SQLite.SQLiteConnection("Data Source=" & cache & ";New=True;Version=2;Compress=True")


            Try
                Dim portion As Integer = CInt(50 / queues.Length)
                Dim nstep As Integer = 0
                Dim tblresult As DataTable = New DataTable

                Me.bgwHeposDataSender_ReportProgress(bgw, 9, "Create cache :" & cachefile)
                sqliteConn.Open()

                ' Buat data method
                cmd = sqliteConn.CreateCommand()
                cmd.CommandText = "CREATE TABLE _UPDATEMETHOD_ (tablename varchar(50), updatemethod varchar(50), keys varchar(255))"
                cmd.ExecuteNonQuery()

                For Each que In queues
                    Me.bgwHeposDataSender_GetData(20 + (nstep * portion), portion, que, dt, sqliteConn, bgw, tblresult)
                    nstep += 1
                    If que.tablename = "transaksi_hepos" Then
                        tblPOS = tblresult.Copy()
                    End If
                Next
            Catch ex As Exception
                Throw ex
            Finally
                Me.bgwHeposDataSender_ReportProgress(bgw, 70, "Closing cache " & cachefile)
                sqliteConn.Close()
            End Try

            Try
                Dim uploader As String = Me._remotewebserviceaddress & "/uploadsales.php"
                Me.bgwHeposDataSender_ReportProgress(bgw, 75, "Uploading data... ")
                System.Net.ServicePointManager.Expect100Continue = False
                My.Computer.Network.UploadFile(cache, uploader, "", "", UploadDataShowUI, 3000)
            Catch ex As Exception
                Throw ex
            End Try


            CriteriaBuilder.AddCriteria("cachefile", True, cachefile)
            Me.bgwHeposDataSender_ReportProgress(bgw, 78, "Processing Uploaded data... ")
            tblUpdate = Me.LoadDataIntoDatatable(param.service_getupdater, CriteriaBuilder.Serialize(), respond)
            If tblHandshake.Rows.Count <= 0 Then
                Throw New Exception("Processing Uploaded data error. tblUpdate Return 0 row" & vbCrLf & Mid(respond, 1, 100))
            End If


            Me.bgwHeposDataSender_ReportProgress(bgw, 80, "Updating local data... ")
            Me.POS.UpdatingPOSLocalData(tblPOS, synsign_id, synsign_dateserver)

            Me.bgwHeposDataSender_ReportProgress(bgw, 80, "Closing server connection... ")
            tblComplete = Me.LoadDataIntoDatatable(param.service_goodby, CriteriaBuilder.Serialize(), respond)
            If tblComplete.Rows.Count <= 0 Then
                Throw New Exception("Finishing Error. tblComplete Return 0 row" & vbCrLf & Mid(respond, 1, 100))
            End If

            Me.bgwHeposDataSender_ReportProgress(bgw, 90, "Fializing local data... ")
            Me.POS.SynComplete(synsign_id)

            Me.bgwHeposDataSender_ReportProgress(bgw, 95, "Finishing")
            Me.bgwHeposDataSender_ReportProgress(bgw, 97, "Finishing")
            Me.bgwHeposDataSender_ReportProgress(bgw, 98, "Finishing")
            Me.bgwHeposDataSender_ReportProgress(bgw, 99, "Finishing")
            Me.bgwHeposDataSender_ReportProgress(bgw, 100, "Finishing")

            result.success = True
            e.Result = result
        Catch ex As Exception
            Me.BackgroundworkerStatus = EBackgroundworkerStatus.Fail
            Me.Status = "Error"
            Me.Message = ex.Message
            result.success = False
            result.errormessage = ex.Message
            e.Result = result
        End Try
    End Sub

    Private Sub bgwHeposDataSender_GetData(ByVal progresssofar As Integer, ByVal portion As Integer, ByVal que As TransStore.DataExporter.TableQueue, ByVal dt As Date, ByRef sqliteConn As SQLite.SQLiteConnection, ByRef bgw As System.ComponentModel.BackgroundWorker, ByRef tbl As DataTable)
        ' Jalan di dalam thread
        Dim percent As Integer = progresssofar
        Dim i, n As Integer
        Dim sqlinsert As String = ""
        Dim dr As DataRow
        Dim cmd As SQLite.SQLiteCommand = sqliteConn.CreateCommand()
        Dim lastpercent As Integer
        Dim keystring As String = String.Join("," & vbCrLf, que.keys)

        Try
            tbl = Me.POS.GetData(que.SQL)

            ' tabah data di _UPDATEMETHOD_
            Me.bgwHeposDataSender_ReportProgress(bgw, percent, "set table " & que.name & " method as " & que.method & "...")
            cmd.CommandText = "INSERT INTO _UPDATEMETHOD_ (tablename, updatemethod, keys) VALUES ('" & que.tablename & "', '" & que.method & "', '" & keystring & "')"
            cmd.ExecuteNonQuery()

            ' Buat table di SQLite
            Me.bgwHeposDataSender_ReportProgress(bgw, percent, "Creating table " & que.name & "...")
            cmd.CommandText = que.DEFSQL
            cmd.ExecuteNonQuery()

            ' Masukkan datanya
            n = tbl.Rows.Count
            For i = 0 To tbl.Rows.Count - 1
                percent = progresssofar + CInt(((i + 1) / n) * portion)
                dr = tbl.Rows(i)
                sqlinsert = TransStore.DataExporter.CreateInsertSQLFromDatarow(que.tablename, dr)

                cmd.CommandText = sqlinsert
                cmd.ExecuteNonQuery()

                If lastpercent <> percent Then
                    Me.bgwHeposDataSender_ReportProgress(bgw, percent, "Copying " & que.name & " ( row " & (i + 1) & " of " & n & ")", 0)
                    lastpercent = percent
                End If
            Next

            If tbl.Rows.Count = 0 Then
                For i = percent To percent + portion
                    Me.bgwHeposDataSender_ReportProgress(bgw, i, "NO DATA FOR " & que.name, 50)
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub bgwHeposDataSender_ReportProgress(ByRef bgw As System.ComponentModel.BackgroundWorker, ByVal percent As String, ByVal message As String, Optional ByVal sleep As Integer = 100)
        Me.Progress = percent
        Me.Message = message
        bgw.ReportProgress(1)
        System.Threading.Thread.Sleep(sleep)
    End Sub

    Private Sub bgwHeposDataSender_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwHeposDataSender.ProgressChanged
        Me.ProgressBarDataSend.Value = Me.Progress
        Me.LabelDataSend.Text = Me.Message
        Me.ProgressBarDataSend.Refresh()
        Me.LabelDataSend.Refresh()
    End Sub

    Private Sub bgwHeposDataSender_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwHeposDataSender.RunWorkerCompleted
        Dim result As TransStore.PosDataUpdaterResult


        Try
            result = CType(e.Result, TransStore.PosDataUpdaterResult)
            If e.Cancelled Then
                MessageBox.Show("Cancel")
            End If

            If Not result.success Then Throw New Exception(result.errormessage)

            Me.lblAutosendStatus.Text = Me._AutosendTextStatus & " (last sent: " & Now & ")"
            Me.lblAutosendStatus.AutoSize = True
            Me.objErrorSend.SetError(btnSend, "")

        Catch ex As Exception
            Me.objErrorSend.SetError(btnSend, "Cannot Send Data!!" & vbCrLf & ex.Message)
            MessageBox.Show("Cannot Send Data!!" & vbCrLf & ex.Message, "Send", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.LabelDataSend.Visible = False
            Me.ProgressBarDataSend.Visible = False
            Me.bgwHeposDataSender = Nothing
            Me.btnSend.Text = "Send"

            'enable Item yg lain
            Me.btnSignIn.Enabled = True
            Me.groupPOSConsole.Enabled = True
            Me.groupClossing.Enabled = True
            Me.groupTransaction.Enabled = True
            Me.dtSalesTobeSent.Enabled = Me.SalesDateToBeSentEnable And True
            Me.btnSignOff.Enabled = True
            Me.btnUpdate.Enabled = True
        End Try






    End Sub


#End Region

#Region " Sign Off Background worker "


    Private Sub bgwHeposSignoff_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles bgwHeposSignoff.Disposed

    End Sub

    Private Sub bgwHeposSignoff_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwHeposSignoff.DoWork
        Dim CriteriaBuilder As Translib.QueryCriteria = New Translib.QueryCriteria
        Dim result As TransStore.PosDataUpdaterResult = New TransStore.PosDataUpdaterResult
        Dim bgw As System.ComponentModel.BackgroundWorker = DirectCast(sender, System.ComponentModel.BackgroundWorker)
        Dim exporter As TransStore.DataExporter = New TransStore.DataExporter()
        Dim respond As String = ""
        Dim synsign_id As String = ""
        Dim tblHandshake, tblComplete As DataTable
        Dim dr As DataRow
        Dim time As Date = Now()
        Dim clientdate As String = time.Year & "-" & time.Month.ToString.PadLeft(2, "0") & "-" & time.Day.ToString.PadLeft(2, "0") & " " & time.Hour.ToString.PadLeft(2, "0") & ":" & time.Minute.ToString.PadLeft(2, "0") & ":" & time.Second.ToString.PadLeft(2, "0")



        Me.bgwHeposSignoff_ReportProgress(bgw, 1, "Starting... ")
        Me.bgwHeposSignoff_ReportProgress(bgw, 2, "Starting... ")
        Me.bgwHeposSignoff_ReportProgress(bgw, 3, "Starting... ")


        Try
            Dim param As TransStore.PosDataUpdaterParam = CType(e.Argument, TransStore.PosDataUpdaterParam)
            result.param = param


            CriteriaBuilder = New Translib.QueryCriteria
            CriteriaBuilder.AddCriteria("region_id", True, Me.POS.RegionId)
            CriteriaBuilder.AddCriteria("branch_id", True, Me.POS.BranchId)
            CriteriaBuilder.AddCriteria("machine_id", True, Me.POS.MachineId)
            CriteriaBuilder.AddCriteria("client_date", True, clientdate)
            CriteriaBuilder.AddCriteria("synsign_type", True, "SIGNOFF")


            Me.bgwHeposSignoff_ReportProgress(bgw, 10, "Connecting to " & param.service_handshake & "...", 200)
            tblHandshake = Me.LoadDataIntoDatatable(param.service_handshake, CriteriaBuilder.Serialize(), respond)
            If tblHandshake.Rows.Count <= 0 Then
                Throw New Exception("Handshake error. tblHandshake Return 0 row" & vbCrLf & Mid(respond, 1, 100))
            End If
            dr = tblHandshake.Rows(0)
            synsign_id = Me.POS.SynHandshake(dr)

            CriteriaBuilder.AddCriteria("synsign_id", True, synsign_id)
            Me.bgwHeposSignoff_ReportProgress(bgw, 70, "Finishing update...", 200)
            tblComplete = Me.LoadDataIntoDatatable(param.service_goodby, CriteriaBuilder.Serialize(), respond)
            If tblComplete.Rows.Count <= 0 Then
                Throw New Exception("Finishing Error. tblComplete Return 0 row" & vbCrLf & Mid(respond, 1, 100))
            End If
            Me.POS.SynComplete(synsign_id)


            Me.bgwHeposSignoff_ReportProgress(bgw, 100, "Completed. ", 800)


            result.success = True
            e.Result = result
        Catch ex As Exception
            Me.BackgroundworkerStatus = EBackgroundworkerStatus.Fail
            Me.Status = "Error"
            Me.Message = ex.Message
            result.success = False
            result.errormessage = ex.Message
            e.Result = result
        End Try
    End Sub

    Private Sub bgwHeposSignoff_ReportProgress(ByRef bgw As System.ComponentModel.BackgroundWorker, ByVal percent As String, ByVal message As String, Optional ByVal sleep As Integer = 100)
        Me.Progress = percent
        Me.Message = message
        bgw.ReportProgress(1)
        System.Threading.Thread.Sleep(sleep)
    End Sub

    Private Sub bgwHeposSignoff_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwHeposSignoff.ProgressChanged
        Me.ProgressBarSignoff.Value = Me.Progress
        Me.LabelSignoff.Text = Me.Message
        Me.ProgressBarSignoff.Refresh()
        Me.LabelSignoff.Refresh()
    End Sub

    Private Sub bgwHeposSignoff_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwHeposSignoff.RunWorkerCompleted
        Dim result As TransStore.PosDataUpdaterResult

        Try
            result = CType(e.Result, TransStore.PosDataUpdaterResult)
            If e.Cancelled Then
                MessageBox.Show("Cancel")
            End If

            If Not result.success Then Throw New Exception(result.errormessage)

            Me.obj_last_synsign_id.Text = ""

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sign Off", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            System.Threading.Thread.Sleep(1000)

            Me.LabelSignoff.Visible = False
            Me.ProgressBarSignoff.Visible = False
            Me.bgwHeposSignoff = Nothing
            Me.btnSignOff.Text = "Sign Off"

            'Enable Item yg lain
            Me.btnSignIn.Enabled = True
            Me.groupPOSConsole.Enabled = True
            Me.groupClossing.Enabled = True
            Me.groupTransaction.Enabled = True
            Me.groupSalesSend.Enabled = True
            Me.btnUpdate.Enabled = True
        End Try






    End Sub


#End Region

#Region " Update Data Background Worker "


    Private Sub bgwHeposUpdatebin_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles bgwHeposUpdatebin.Disposed

    End Sub

    Private Sub bgwUpdatebin_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwHeposUpdatebin.DoWork
        Dim CriteriaBuilder As Translib.QueryCriteria = New Translib.QueryCriteria
        Dim result As TransStore.PosDataUpdaterResult = New TransStore.PosDataUpdaterResult
        Dim bgw As System.ComponentModel.BackgroundWorker = DirectCast(sender, System.ComponentModel.BackgroundWorker)
        Dim tblHandshake, tblUpdater, tblComplete, tblModifiedItem, tblInvUpdateInfo As DataTable
        Dim dr As DataRow
        Dim respond As String = ""
        Dim time As Date = Now()
        Dim clientdate As String = time.Year & "-" & time.Month.ToString.PadLeft(2, "0") & "-" & time.Day.ToString.PadLeft(2, "0") & " " & time.Hour.ToString.PadLeft(2, "0") & ":" & time.Minute.ToString.PadLeft(2, "0") & ":" & time.Second.ToString.PadLeft(2, "0")
        Dim synsign_id, updater_id As String
        Dim sqliteConn As SQLite.SQLiteConnection


        Try
            Dim param As TransStore.PosDataUpdaterParam = CType(e.Argument, TransStore.PosDataUpdaterParam)
            result.param = param

            CriteriaBuilder = New Translib.QueryCriteria
            CriteriaBuilder.AddCriteria("region_id", True, Me.POS.RegionId)
            CriteriaBuilder.AddCriteria("branch_id", True, Me.POS.BranchId)
            CriteriaBuilder.AddCriteria("machine_id", True, Me.POS.MachineId)
            CriteriaBuilder.AddCriteria("client_date", True, clientdate)
            CriteriaBuilder.AddCriteria("synsign_type", True, "UPDATE")

            Me.Progress = 5
            Me.Message = "Connecting to " & param.service_handshake & "..."
            bgw.ReportProgress(1)
            tblHandshake = Me.LoadDataIntoDatatable(param.service_handshake, CriteriaBuilder.Serialize(), respond)
            If tblHandshake.Rows.Count <= 0 Then
                Throw New Exception("Handshake error. tblHandshake Return 0 row" & vbCrLf & Mid(respond, 1, 100))
            End If
            Me.Progress = 10
            Me.Message = "Connected."
            bgw.ReportProgress(1)

            System.Threading.Thread.Sleep(50)


            dr = tblHandshake.Rows(0)
            synsign_id = Me.POS.SynHandshake(dr)

            ' Ambil id updater
            Dim another_region_to_be_update As String = Me._another_region_to_be_update
            Dim region_to_be_update As String = Me.POS.RegionId & "|" & another_region_to_be_update
            Dim regions() As String = region_to_be_update.Split("|")
            Dim n As Integer = regions.Length
            Dim i As Integer
            Dim region_id As String = ""


            Me.Progress = 15
            Me.Message = "Getting Updater..."
            bgw.ReportProgress(1)
            For i = 0 To n - 1
                region_id = regions(i)

                CriteriaBuilder = New Translib.QueryCriteria
                CriteriaBuilder.AddCriteria("region_id", True, region_id)
                CriteriaBuilder.AddCriteria("branch_id", True, Me.POS.BranchId)
                CriteriaBuilder.AddCriteria("machine_id", True, Me.POS.MachineId)
                CriteriaBuilder.AddCriteria("client_date", True, clientdate)
                CriteriaBuilder.AddCriteria("synsign_type", True, "UPDATE")
                CriteriaBuilder.AddCriteria("synsign_id", True, synsign_id)


                Me.Message = "Getting Updater for " & region_id & "..."
                bgw.ReportProgress(1)

                tblUpdater = Me.LoadDataIntoDatatable(param.service_getupdater, CriteriaBuilder.Serialize(), respond)
                If tblUpdater.Rows.Count > 0 Then
                    ' Ada data yang harus diupdate
                    dr = tblUpdater.Rows(0)
                    updater_id = dr("id")

                    CriteriaBuilder.AddCriteria("updater_id", True, updater_id)

                    Me.LoadDataIntoDatatable(param.service_setclientupdatestatus, CriteriaBuilder.Serialize(), respond)


                    If Not Me.POS.SynCheckUpdater(updater_id) Then
                        ' Client belum diupdate
                        ' Download data

                        'Cek apakah ada direktory Transbrowser di My Documents
                        Dim updaterfolder As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/Transbrowser"
                        Dim f As New IO.DirectoryInfo(updaterfolder)

                        If Not f.Exists Then
                            IO.Directory.CreateDirectory(updaterfolder)
                        End If


                        'Cek apakah ada direktory Transbrowser/updater di My Documents
                        updaterfolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/Transbrowser/Updater"
                        f = New IO.DirectoryInfo(updaterfolder)
                        If Not f.Exists Then
                            IO.Directory.CreateDirectory(updaterfolder)
                        End If


                        Dim fileupdater As String = Me._remotewebserviceaddress & "/updater/" & updater_id
                        Dim cachefile As String = updaterfolder & "/" & updater_id
                        Try
                            Me.Progress = 18
                            Me.Message = "Downloading Updater (" & updater_id & ")..."
                            bgw.ReportProgress(1)
                            My.Computer.Network.DownloadFile(fileupdater, cachefile, "", "", True, 100, True)
                        Catch ex As Exception
                            Throw New Exception(fileupdater & vbCrLf & ex.Message)
                        End Try


                        ' Extract cachefile apabila file nya tercompressy
                        If Strings.Right(cachefile, 9).ToLower = ".compress" Then
                            TransbrowserFileCompress.UnCompressFile(cachefile, TransbrowserFileCompress.enuAlgorithm.Deflate)
                            IO.File.Delete(cachefile)
                            cachefile = cachefile & ".txt"
                        End If

                        ' Baca DATA dari SQLite
                        Dim cmd As SQLite.SQLiteCommand
                        Dim drlite As SQLite.SQLiteDataReader
                        Dim tablename, updatemethod, keys As String

                        sqliteConn = New SQLite.SQLiteConnection("Data Source=" & cachefile & ";Version=2;Compress=True;")
                        Try
                            sqliteConn.Open()
                            cmd = sqliteConn.CreateCommand()
                            cmd.CommandText = "SELECT * FROM _UPDATEMETHOD_"
                            drlite = cmd.ExecuteReader()
                            While drlite.Read()
                                tablename = drlite("tablename")
                                updatemethod = drlite("updatemethod")
                                keys = drlite("keys")

                                Me.Progress = 20
                                Me.Message = "Updating " & tablename & "..."
                                bgw.ReportProgress(1)

                                Me.POS.UpdateTable(tablename, updatemethod, keys, sqliteConn, bgw)
                            End While
                        Catch ex As Exception
                            Throw New Exception("bgwHeposDataUpdater_DoWork:" & vbCrLf & cachefile & vbCrLf & ex.Message)
                        Finally
                            sqliteConn.Close()
                        End Try

                        ' Tandai bahwa data sudah berhasil diupdate

                        Me.Progress = 80
                        Me.Message = "Recording update..."
                        bgw.ReportProgress(1)
                        Me.POS.RecordUpdaterID(updater_id, Me.POS.RegionId, synsign_id)

                        ' Hapus lagi 
                        IO.File.Delete(cachefile)

                        ' Kasi tau ke server kalau updater telah berahasil diupdate
                        Me.LoadDataIntoDatatable(param.service_setclientupdatestatus & "&confirm=1", CriteriaBuilder.Serialize(), respond)


                    Else
                        Me.Progress = 50
                        Me.Message = "Data is up to date."
                        bgw.ReportProgress(1)
                        System.Threading.Thread.Sleep(300)
                    End If
                Else
                    Me.Progress = 50
                    Me.Message = "Nothing to update."
                    bgw.ReportProgress(1)
                    System.Threading.Thread.Sleep(300)
                End If




            Next
            System.Threading.Thread.Sleep(50)


            Dim row As DataRow
            Dim tblUpdateStockFile As DataTable = New DataTable
            tblUpdateStockFile.Columns.Add(New System.Data.DataColumn("region_id", GetType(System.String)))
            tblUpdateStockFile.Columns.Add(New System.Data.DataColumn("branch_id", GetType(System.String)))
            tblUpdateStockFile.Columns.Add(New System.Data.DataColumn("filename", GetType(System.String)))


            ' Update inventory
            For i = 0 To regions.Length - 1
                region_id = regions(i)
                CriteriaBuilder = New Translib.QueryCriteria
                CriteriaBuilder.AddCriteria("region_id", True, region_id)
                CriteriaBuilder.AddCriteria("branch_id", True, Me.POS.BranchId)
                CriteriaBuilder.AddCriteria("machine_id", True, Me.POS.MachineId)
                CriteriaBuilder.AddCriteria("client_date", True, clientdate)
                CriteriaBuilder.AddCriteria("synsign_type", True, "GET.STOCK")
                CriteriaBuilder.AddCriteria("synsign_id", True, synsign_id)

                Me.Progress = 45
                Me.Message = "Get Stock position Information (" & region_id & ")."
                bgw.ReportProgress(1)
                tblInvUpdateInfo = Me.LoadDataIntoDatatable(param.service_invinfoget, CriteriaBuilder.Serialize(), respond)

                row = tblUpdateStockFile.NewRow()
                row("region_id") = region_id
                row("branch_id") = Me.POS.BranchId
                row("filename") = tblInvUpdateInfo.Rows(0).Item("filename").ToString
                tblUpdateStockFile.Rows.Add(row)

            Next
            tblUpdateStockFile.AcceptChanges()

            Me.Message = "Downloading inventory update."
            bgw.ReportProgress(1)
            System.Threading.Thread.Sleep(50)


            Dim rows() As DataRow
            Dim filename As String
            ' Download invupdate
            For i = 0 To regions.Length - 1
                region_id = regions(i)
                CriteriaBuilder = New Translib.QueryCriteria
                CriteriaBuilder.AddCriteria("region_id", True, region_id)
                CriteriaBuilder.AddCriteria("branch_id", True, Me.POS.BranchId)
                CriteriaBuilder.AddCriteria("machine_id", True, Me.POS.MachineId)
                CriteriaBuilder.AddCriteria("client_date", True, clientdate)
                CriteriaBuilder.AddCriteria("synsign_type", True, "DL.STOCK")
                CriteriaBuilder.AddCriteria("synsign_id", True, synsign_id)

                Me.Progress = 50
                Me.Message = "Downloading Stock position Information (" & region_id & ")."
                bgw.ReportProgress(1)


                rows = tblUpdateStockFile.Select("region_id='" & region_id & "'")
                filename = rows(0).Item("filename")


                'Cek apakah ada direktory Transbrowser di My Documents
                Dim updaterfolder As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/Transbrowser"
                Dim f As New IO.DirectoryInfo(updaterfolder)

                If Not f.Exists Then
                    IO.Directory.CreateDirectory(updaterfolder)
                End If


                'Cek apakah ada direktory Transbrowser/updater di My Documents
                updaterfolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/Transbrowser/Updater"
                f = New IO.DirectoryInfo(updaterfolder)
                If Not f.Exists Then
                    IO.Directory.CreateDirectory(updaterfolder)
                End If


                Dim fileupdater As String = Me._remotewebserviceaddress & "/updater/inv/" & filename
                Dim cachefile As String = updaterfolder & "/" & filename
                Try
                    My.Computer.Network.DownloadFile(fileupdater, cachefile, "", "", True, 100, True)
                Catch ex As Exception
                    Throw New Exception(fileupdater & vbCrLf & ex.Message)
                End Try


                ' Extract cachefile apabila file nya tercompressy
                If Strings.Right(cachefile, 9).ToLower = ".compress" Then
                    TransbrowserFileCompress.UnCompressFile(cachefile, TransbrowserFileCompress.enuAlgorithm.Deflate)
                    IO.File.Delete(cachefile)
                    cachefile = cachefile & ".txt"
                End If


            Next

            Me.Message = "Updating local stock position Information"
            bgw.ReportProgress(1)

            ' Update local inventory
            For i = 0 To regions.Length - 1
                region_id = regions(i)
                CriteriaBuilder = New Translib.QueryCriteria
                CriteriaBuilder.AddCriteria("region_id", True, region_id)
                CriteriaBuilder.AddCriteria("branch_id", True, Me.POS.BranchId)
                CriteriaBuilder.AddCriteria("machine_id", True, Me.POS.MachineId)
                CriteriaBuilder.AddCriteria("client_date", True, clientdate)
                CriteriaBuilder.AddCriteria("synsign_type", True, "DL.STOCK")
                CriteriaBuilder.AddCriteria("synsign_id", True, synsign_id)

                Me.Progress = 55
                Me.Message = "Updating local stock position Information (" & region_id & ")."
                bgw.ReportProgress(1)

                rows = tblUpdateStockFile.Select("region_id='" & region_id & "'")
                filename = rows(0).Item("filename")



                Dim updaterfolder As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Transbrowser\Updater"
                Dim cachefile As String = updaterfolder & "\" & filename & ".txt"

                ' Import Data Stock
                Me.POS.LoadStockFromFile(region_id, cachefile, Now())

            Next
            System.Threading.Thread.Sleep(50)





            ' Removing stock cache
            For i = 0 To regions.Length - 1
                region_id = regions(i)

                rows = tblUpdateStockFile.Select("region_id='" & region_id & "'")
                filename = rows(0).Item("filename")


                CriteriaBuilder = New Translib.QueryCriteria
                CriteriaBuilder.AddCriteria("region_id", True, region_id)
                CriteriaBuilder.AddCriteria("branch_id", True, Me.POS.BranchId)
                CriteriaBuilder.AddCriteria("machine_id", True, Me.POS.MachineId)
                CriteriaBuilder.AddCriteria("client_date", True, clientdate)
                CriteriaBuilder.AddCriteria("synsign_type", True, "DL.STOCK")
                CriteriaBuilder.AddCriteria("synsign_id", True, synsign_id)
                CriteriaBuilder.AddCriteria("filename", True, filename)

                Me.Progress = 60
                Me.Message = "Removing stock cache (" & region_id & ")."
                bgw.ReportProgress(1)

                tblInvUpdateInfo = Me.LoadDataIntoDatatable(param.service_invinfopurge, CriteriaBuilder.Serialize(), respond)



            Next
            System.Threading.Thread.Sleep(50)





            ' Get updated data
            'TODO: ambil item yg diupdate
            tblModifiedItem = New DataTable()




            ' Kembalikan lagi Criteria Builder
            CriteriaBuilder = New Translib.QueryCriteria
            CriteriaBuilder.AddCriteria("region_id", True, Me.POS.RegionId)
            CriteriaBuilder.AddCriteria("branch_id", True, Me.POS.BranchId)
            CriteriaBuilder.AddCriteria("machine_id", True, Me.POS.MachineId)
            CriteriaBuilder.AddCriteria("client_date", True, clientdate)
            CriteriaBuilder.AddCriteria("synsign_type", True, "SIGNIN")
            CriteriaBuilder.AddCriteria("synsign_id", True, synsign_id)



            ' Say goodby to server
            Me.Progress = 85
            Me.Message = "Finishing update..."
            bgw.ReportProgress(1)
            tblComplete = Me.LoadDataIntoDatatable(param.service_goodby, CriteriaBuilder.Serialize(), respond)
            If tblComplete.Rows.Count <= 0 Then
                Throw New Exception("Finishing Error. tblComplete Return 0 row" & vbCrLf & Mid(respond, 1, 100))
            End If

            Me.POS.SynComplete(synsign_id)
            Me.Progress = 100
            Me.Message = "Completed."
            bgw.ReportProgress(1)
            System.Threading.Thread.Sleep(300)


            result.success = True
            e.Result = result
        Catch ex As Exception
            Me.BackgroundworkerStatus = EBackgroundworkerStatus.Fail
            Me.Status = "Error"
            Me.Message = ex.Message
            result.success = False
            result.errormessage = ex.Message
            e.Result = result
        End Try


    End Sub

    Private Sub bgwUpdatebin_ReportProgress(ByRef bgw As System.ComponentModel.BackgroundWorker, ByVal percent As String, ByVal message As String, Optional ByVal sleep As Integer = 100)
        Me.Progress = percent
        Me.Message = message
        bgw.ReportProgress(1)
        System.Threading.Thread.Sleep(sleep)
    End Sub

    Private Sub bgwUpdatebin_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwHeposUpdatebin.ProgressChanged
        Me.ProgressBarUpdatebin.Value = Me.Progress
        Me.LabelUpdateBin.Text = Me.Message
        Me.ProgressBarUpdatebin.Refresh()
        Me.LabelUpdateBin.Refresh()
    End Sub

    Private Sub bgwUpdatebin_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwHeposUpdatebin.RunWorkerCompleted
        Dim result As TransStore.PosDataUpdaterResult

        Try
            result = CType(e.Result, TransStore.PosDataUpdaterResult)
            If e.Cancelled Then
                MessageBox.Show("Cancel")
            End If

            If Not result.success Then Throw New Exception(result.errormessage)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Update Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.LabelUpdateBin.Visible = False
            Me.ProgressBarUpdatebin.Visible = False
            Me.bgwHeposUpdatebin = Nothing
            Me.btnUpdate.Text = "Update Data"

            'Enable Item yg lain
            Me.btnSignIn.Enabled = True
            Me.btnSignOff.Enabled = True
            Me.groupPOSConsole.Enabled = True
            Me.groupClossing.Enabled = True
            Me.groupTransaction.Enabled = True
            Me.groupSalesSend.Enabled = True

        End Try






    End Sub


#End Region

#Region " VoidRequest Background worker "


    Private Sub bgwHeposVoidRequest_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles bgwHeposVoidRequest.Disposed

    End Sub

    Private Sub bgwHeposVoidRequest_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwHeposVoidRequest.DoWork
        Dim CriteriaBuilder As Translib.QueryCriteria = New Translib.QueryCriteria
        Dim result As TransStore.PosBonVoidRequestResult = New TransStore.PosBonVoidRequestResult
        Dim bgw As System.ComponentModel.BackgroundWorker = DirectCast(sender, System.ComponentModel.BackgroundWorker)
        Dim exporter As TransStore.DataExporter = New TransStore.DataExporter()
        Dim respond As String = ""
        Dim synsign_id As String = ""
        Dim tblHandshake, tblVoidReq, tblComplete As DataTable
        Dim dr As DataRow
        Dim time As Date = Now()
        Dim clientdate As String = time.Year & "-" & time.Month.ToString.PadLeft(2, "0") & "-" & time.Day.ToString.PadLeft(2, "0") & " " & time.Hour.ToString.PadLeft(2, "0") & ":" & time.Minute.ToString.PadLeft(2, "0") & ":" & time.Second.ToString.PadLeft(2, "0")


        Try
            Dim param As TransStore.PosBonVoidRequestParam = CType(e.Argument, TransStore.PosBonVoidRequestParam)
            result.param = param


            CriteriaBuilder = New Translib.QueryCriteria
            CriteriaBuilder.AddCriteria("region_id", True, Me.POS.RegionId)
            CriteriaBuilder.AddCriteria("branch_id", True, Me.POS.BranchId)
            CriteriaBuilder.AddCriteria("machine_id", True, Me.POS.MachineId)
            CriteriaBuilder.AddCriteria("client_date", True, clientdate)
            CriteriaBuilder.AddCriteria("synsign_type", True, "VOIDBON")
            CriteriaBuilder.AddCriteria("synsign_note", True, param.bon_id & " void req " & param.username)

            CriteriaBuilder.AddCriteria("username", True, param.username)
            CriteriaBuilder.AddCriteria("password", True, param.password)
            CriteriaBuilder.AddCriteria("systemdate", True, param.systemdate.ToString)
            CriteriaBuilder.AddCriteria("bon_id", True, param.bon_id)


            Me.bgwHeposVoidRequest_ReportProgress(bgw, 10, "Connecting to " & param.service_handshake & "...", 200)
            tblHandshake = Me.LoadDataIntoDatatable(param.service_handshake, CriteriaBuilder.Serialize(), respond)
            If tblHandshake.Rows.Count <= 0 Then
                Throw New Exception("Handshake error. tblHandshake Return 0 row" & vbCrLf & Mid(respond, 1, 100))
            End If
            dr = tblHandshake.Rows(0)
            synsign_id = Me.POS.SynHandshake(dr)

            CriteriaBuilder.AddCriteria("synsign_id", True, synsign_id)
            Me.bgwHeposVoidRequest_ReportProgress(bgw, 50, "Requesting void atuhentication...", 200)
            tblVoidReq = Me.LoadDataIntoDatatable(param.service_voidrequest, CriteriaBuilder.Serialize(), respond)
            Me.bgwHeposVoidRequest_ReportProgress(bgw, 70, "Finishing update...", 200)
            tblComplete = Me.LoadDataIntoDatatable(param.service_goodby, CriteriaBuilder.Serialize(), respond)
            If tblComplete.Rows.Count <= 0 Then
                Throw New Exception("Finishing Error. tblComplete Return 0 row" & vbCrLf & Mid(respond, 1, 100))
            End If
            Me.POS.SynComplete(synsign_id)


            Me.bgwHeposVoidRequest_ReportProgress(bgw, 100, "Completed. ", 500)


            If tblVoidReq.Rows(0).Item("canvoid").ToString = "1" Then
                result.canvoid = 1
                Me.bgwHeposVoidRequest_ReportProgress(bgw, 100, "Completed. ", 300)
            Else
                result.canvoid = 0
                Me.bgwHeposVoidRequest_ReportProgress(bgw, 100, "Bad user Or password." & "Please Retry !", 300)
            End If


            result.success = True
            e.Result = result
        Catch ex As Exception
            Me.BackgroundworkerStatus = EBackgroundworkerStatus.Fail
            Me.Status = "Error"
            Me.Message = ex.Message
            result.success = False
            result.errormessage = ex.Message
            e.Result = result
        End Try
    End Sub

    Private Sub bgwHeposVoidRequest_ReportProgress(ByRef bgw As System.ComponentModel.BackgroundWorker, ByVal percent As String, ByVal message As String, Optional ByVal sleep As Integer = 100)
        Me.Progress = percent
        Me.Message = message
        bgw.ReportProgress(1)
        System.Threading.Thread.Sleep(sleep)
    End Sub

    Private Sub bgwHeposVoidRequest_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwHeposVoidRequest.ProgressChanged
        Me.Cursor = Cursors.WaitCursor
        Me.lblAuthMsg.Text = Me.Message
        Me.lblAuthMsg.Visible = True
        Me.lblAuthMsg.Refresh()
    End Sub

    Private Sub bgwHeposVoidRequest_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwHeposVoidRequest.RunWorkerCompleted
        Dim result As TransStore.PosBonVoidRequestResult

        Try
            result = CType(e.Result, TransStore.PosBonVoidRequestResult)
            If e.Cancelled Then
                MessageBox.Show("Cancel")
            End If
            If Not result.success Then Throw New Exception(result.errormessage)
            If result.canvoid Then
                Me.lblAuthClose_LinkClicked(sender, New System.Windows.Forms.LinkLabelLinkClickedEventArgs(New System.Windows.Forms.LinkLabel.Link()))
                Me.Cursor = Cursors.Arrow



                Dim dlg As dlgTrnPosVoid = New dlgTrnPosVoid()
                Dim ret As Object
                Dim bon As TransStore.POS.PosHeader = New TransStore.POS.PosHeader
                Dim o As PosBonData
                Dim args As Object() = New Object() {}
                Dim id As String
                Dim strs() As String
                Dim i As Integer
                Dim txt As String = ""
                Dim bon_date As Date
                Dim date_now As Date = Now

                bon.bon_id = Me.objBonId.Text
                o = Me.POS.GetBonData(bon)

                bon_date = o.Header.Rows(0).Item("bon_date")
                If bon_date.Year = date_now.Year And bon_date.Month = date_now.Month And bon_date.Day = date_now.Day Then

                    args = New Object() {o, "VOID", Me.POS, result.param.username}
                    ret = dlg.OpenDialog(Me, args)

                    If ret Is Nothing Then
                        Exit Sub
                    End If

                    Try
                        If ret.Length > 0 Then
                            id = Trim(ret(0))
                            If id <> "" Then
                                strs = Me.POS.FormatBon(o, True, False)
                                For i = 0 To strs.Length - 1
                                    txt &= strs(i) & vbCrLf
                                Next
                                ret = uiTrnPosEN.SendTextToPrinter(Me.POS, txt, PrintMethod.PrintOnly, LX300.P_PAGE_07)
                            End If
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Void", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                Else
                    Throw New Exception("Bon Id: '" & bon.bon_id & "' tidak dapat divoid, karena sudah lewat hari.")
                End If


            Else
                Throw New Exception("'" & result.param.username & "' doesn't have void authorization!")
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Void", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.bgwHeposVoidRequest = Nothing
            Me.btnVoidOpen.Text = "&Void"

            'Enable Item yg lain
            Me.btnSignIn.Enabled = True
            Me.btnSignOff.Enabled = True
            Me.groupPOSConsole.Enabled = True
            Me.groupClossing.Enabled = True
            Me.groupTransaction.Enabled = True
            Me.groupSalesSend.Enabled = True
            Me.btnUpdate.Enabled = True

            Me.lblReset.Enabled = True
            Me.lblAuthClose.Enabled = True
            Me.objUsername.Enabled = True
            Me.objPassword.Enabled = True


            Me.objUsername.Text = ""
            Me.objPassword.Text = ""
            Me.btnVoidOpen.Enabled = True


            Me.Cursor = Cursors.Arrow

        End Try

    End Sub


#End Region



    Private Sub TimerAutosendData_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerAutosendData.Tick
        Call btnSend_Click(sender, e)

    End Sub

    Private Sub btnShowParameter_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnShowParameter.LinkClicked
        Dim parameters As String = ""

        parameters &= "*** Ini File ****" & vbCrLf
        parameters &= "POS.INI" & " : " & Me.iniFile & vbCrLf
        parameters &= "ClientName" & " : " & Me.ClientName & vbCrLf
        parameters &= "machine_id" & " : " & Me.POS.MachineId & vbCrLf
        parameters &= "branch_id" & " : " & Me.POS.BranchId & vbCrLf
        parameters &= "region_id" & " : " & Me.POS.RegionId & vbCrLf
        parameters &= "another_region_to_be_update" & " : " & Me._another_region_to_be_update & vbCrLf
        parameters &= "regionpathfilter" & " : " & Me.POS.RegionPathFilter & vbCrLf
        parameters &= "event" & " : " & Me.POS.Event & vbCrLf
        parameters &= "printerdefault" & " : " & Me.POS.PrinterDefault & vbCrLf
        parameters &= "receiptprinter" & " : " & Me.POS.ReceiptPrinter & vbCrLf
        parameters &= "logo" & " : " & Me.POS.Logo & vbCrLf
        parameters &= "rpc_address" & " : " & Me.POS.RPCAddress & vbCrLf
        parameters &= "qris_proxy" & " : " & Me.POS.QrisProxy & vbCrLf
        parameters &= "wwwroot" & " : " & Me._wwwroot & vbCrLf
        parameters &= "BONTYPE" & " : " & Me.POS.BONTYPE & vbCrLf
        parameters &= "NOT_ALLOWED_PAYMENT" & " : " & Me.POS.NOT_ALLOWED_PAYMENT & vbCrLf
        parameters &= "PRINTER_PORT" & " : " & Me.POS.PRINTER_PORT & vbCrLf
        parameters &= "POLE_PORT" & " : " & Me.POS.POLE_PORT & vbCrLf
        parameters &= "MCRLAYER" & " : " & Me.POS.MCRLAYER & vbCrLf
        parameters &= "CARDNUMBER_ENTRY" & " : " & Me.POS.CARDNUMBER_ENTRY & vbCrLf
        parameters &= "CARDNUMBER_OVRMANUAL" & " : " & Me.POS.CARDNUMBER_OVRMANUAL & vbCrLf
        parameters &= "ALLOW_MULTIPLE_PAYMENT_IN_FP" & " : " & Me.POS.ALLOW_MULTIPLE_PAYMENT_IN_FP & vbCrLf
        parameters &= "FP_PAYMENT_FILTER" & " : " & Me.POS.FP_PAYMENT_FILTER & vbCrLf
        parameters &= "DISABLED_PAYMENT_METHOD" & " : " & Me.POS.DISABLED_PAYMENT_METHOD & vbCrLf
        parameters &= "AUTO_KEY_NUMBER" & " : " & Me.POS.AUTO_KEY_NUMBER & vbCrLf
        parameters &= "SLAVE_MODE" & " : " & Me.POS.SLAVE_MODE & vbCrLf
        parameters &= "VOUCHER_LINKEDTO_CUSTOMERTYPE" & " : " & Me.POS.VOUCHER_LINKEDTO_CUSTOMERTYPE & vbCrLf
        parameters &= "DISABLED_VOUCHER" & " : " & Me.POS.DISABLED_VOUCHER & vbCrLf
        parameters &= "AUTOSENDPOSDATA" & " : " & Me.TimerAutosendData.Enabled & vbCrLf
        parameters &= "AUTOSENDINTERVAL" & " : " & Me.TimerAutosendData.Interval & vbCrLf
        parameters &= "SENDDATAMODE" & " : " & Me.POS.SENDDATAMODE & vbCrLf
        parameters &= "SENDDATAVER" & " : " & Me.POS.SENDDATAVER & vbCrLf


        parameters &= "" & vbCrLf
        parameters &= "*** DATABASE ***" & vbCrLf
        parameters &= "COMPANY_NAME" & " : " & Me.POS.COMPANY_NAME & vbCrLf
        parameters &= "COMPANY_INITIAL" & " : " & Me.POS.COMPANY_INITIAL & vbCrLf
        parameters &= "COMPANY_ADDRESS" & " : " & Me.POS.COMPANY_ADDRESS & vbCrLf
        parameters &= "COMPANY_TAXID" & " : " & Me.POS.COMPANY_TAXID & vbCrLf
        parameters &= "SALESPERSON_IS_MANDATORY" & " : " & Me.POS.SALESPERSON_IS_MANDATORY & vbCrLf
        parameters &= "SALESPERSON_AUTOFILLTEXT" & " : " & Me.POS.SALESPERSON_AUTOFILLTEXT & vbCrLf
        parameters &= "EXTID_IS_ENABLED" & " : " & Me.POS.EXTID_IS_ENABLED & vbCrLf
        parameters &= "EXTID_IS_MANDATORY" & " : " & Me.POS.EXTID_IS_MANDATORY & vbCrLf
        parameters &= "CONSGOOD_IS_MANDATORY" & ":" & Me.POS.CONSGOOD_IS_MANDATORY & vbCrLf
        parameters &= "BON_COPY" & ":" & Me.POS.BON_COPY & vbCrLf
        parameters &= "CUSTOMERINFO_IS_MANDATORY" & ":" & Me.POS.CUSTOMERINFO_IS_MANDATORY & vbCrLf
        parameters &= "SCANMODE" & ":" & Me.POS.SCANMODE & vbCrLf



        Dim dlg As dlgParameters = New dlgParameters()
        dlg.TextBox1.Text = parameters
        dlg.StartPosition = FormStartPosition.CenterScreen
        dlg.ShowInTaskbar = False
        dlg.ShowDialog(Me)


    End Sub


    Private Sub chkBonPreview_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBonPreview.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)

        If Me.POS Is Nothing Then
            If chk.Checked Then
                Me.btnRePrint.Enabled = False
            Else
                Me.btnRePrint.Enabled = True
            End If
            Return
        End If


        If chk.Checked Then
            If Me.POS.IsDevelopmentMode Then
                Me.btnRePrint.Enabled = True
            Else
                Me.btnRePrint.Enabled = False
            End If
        Else
            Me.btnRePrint.Enabled = True
        End If

    End Sub

    Private Sub btn_testVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_testVoucher.Click
        Dim dlg As dlgRedeemVoucher = New dlgRedeemVoucher()

        dlg.setPOS(Me.POS)
        dlg.ShowDialog(Me)


    End Sub

    Public Sub SendData()
        btnSend_Click(Me.btnSend, System.EventArgs.Empty)
    End Sub



    Private Sub btn_TestQris_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_TestQris.Click
        Dim dlg As dlgQRTest = New dlgQRTest()
        dlg.ShowInTaskbar = False
        dlg.WindowState = FormWindowState.Maximized

        dlg.SetParameter(Me.POS)
        dlg.ShowDialog(Me)



    End Sub
End Class
