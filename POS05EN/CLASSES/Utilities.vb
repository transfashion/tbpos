
Namespace TransStore

    Public Class Utilities

        Public Shared Function OpenBrowseDialog(ByRef owner As System.Windows.Forms.IWin32Window, ByRef objid As TextBox, ByRef objname As Label, ByVal ParamValue As PosDataBrowseParamValue) As PosDataBrowseReturnValue
            Dim args As Object
            Dim f As dlgTrnPosDataBrowse = New dlgTrnPosDataBrowse
            Dim result As Object
            Dim fmask As Form = uiTrnPosEN.CreateMask(0.75)
            Dim ReturnValue As TransStore.PosDataBrowseReturnValue = Nothing

            With ParamValue
                .id = objid.Text
                .name = objname.Text
            End With

            args = New Object() {ParamValue}
            fmask.SuspendLayout()
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            fmask.Show(owner)
            result = f.OpenDialog(fmask, args)
            fmask.Close()
            fmask.Dispose()
            f.Dispose()
            f = Nothing

            If result IsNot Nothing Then
                ReturnValue = CType(result(0), PosDataBrowseReturnValue)
                objid.Text = ReturnValue.id
                objname.Text = ReturnValue.name
            End If

            Return ReturnValue
        End Function

        Public Shared Function PosVoucherDiscountCalculate(ByVal item_pricegross As Decimal, ByVal item_qty As Decimal, ByVal item_discpercent As Decimal, ByVal item_flag As Boolean, ByVal vou01type As String, ByVal vou01method As String, ByVal vou01discpercent As Decimal, ByVal customertype As String, ByVal customerdisc As Decimal) As TransStore.PosItemPrice
            Dim obj As TransStore.PosItemPrice = New TransStore.PosItemPrice
            Dim discpstd01, discrstd01, pricenettstd01 As Decimal
            Dim discpvou01, discrvou01, pricenettvou01 As Decimal


            '' Discount Standart
            discpstd01 = item_discpercent
            discrstd01 = item_pricegross * (item_discpercent / 100)
            pricenettstd01 = item_pricegross * ((100 - item_discpercent) / 100)

            '' Discount Tambahan Voucher, hitung berdasar Type Voucher
            Select Case UCase(vou01type)
                Case "NONE"
                    discpvou01 = 0

                Case "ALL"
                    discpvou01 = vou01discpercent

                Case "FLAG"
                    If item_flag Then
                        discpvou01 = vou01discpercent
                    Else
                        discpvou01 = 0
                    End If

                Case "FULL"
                    If item_discpercent = 0 Then
                        discpvou01 = vou01discpercent
                    Else
                        discpvou01 = 0
                    End If

                Case "NONFULL"
                    If item_discpercent > 0 Then
                        discpvou01 = vou01discpercent
                    Else
                        discpvou01 = 0
                    End If

                Case Else
                    discpvou01 = 0
            End Select


            '' Metode Perhitungan discount
            Select Case vou01method
                Case "ADD"  ' Tambahkan discount 30% + 20%
                    discrvou01 = item_pricegross * (discpvou01 / 100)
                    pricenettvou01 = item_pricegross * ((100 - (item_discpercent + discpvou01)) / 100)


                Case "FPONLY"
                    ' Discount hanya berlaku untuk barang yang fullprice
                    If item_discpercent = 0 Then
                        discpvou01 = vou01discpercent
                        discrvou01 = item_pricegross * (discpvou01 / 100)
                        pricenettvou01 = item_pricegross - discrvou01
                    Else
                        discpvou01 = 0
                        discrvou01 = 0
                        pricenettvou01 = item_pricegross
                    End If


                Case "REPIFLESS"  ' Pilih Discount yang paling besar
                    If discpvou01 > item_discpercent Then
                        discrvou01 = item_pricegross * ((discpvou01 - item_discpercent) / 100)
                        pricenettvou01 = item_pricegross * ((100 - (discpvou01)) / 100)
                    Else
                        discrvou01 = 0
                        pricenettvou01 = item_pricegross * ((100 - (item_discpercent)) / 100)
                    End If



                Case "REPLACE"
                    discrvou01 = item_pricegross * ((discpvou01 - item_discpercent) / 100)
                    pricenettvou01 = item_pricegross * ((100 - (discpvou01)) / 100)

                Case Else ' MUL, dan yang lainnya Gunakan Perkalian
                    discrvou01 = pricenettstd01 * (discpvou01 / 100)
                    pricenettvou01 = pricenettstd01 * ((100 - discpvou01) / 100)


            End Select



            With obj
                .discpstd01 = discpstd01
                .discrstd01 = discrstd01
                .pricenettstd01 = pricenettstd01
                .discpvou01 = discpvou01
                .discrvou01 = discrvou01
                .pricenettvou01 = pricenettvou01
            End With


            Return obj
        End Function

        Public Shared Function StandartDiscount(ByVal price As Decimal, ByVal discpercent As Decimal, ByRef discvalue As Decimal, ByRef nettvalue As Decimal) As Decimal
            discvalue = price * (discpercent / 100)
            nettvalue = price * ((100 - discpercent) / 100)
        End Function

        Public Shared Function CreatePassword(ByVal region_id As String, ByVal branch_id As String, ByVal dt As Date) As String
            Dim str As String = region_id & dt.Day().ToString.PadLeft(2, "0") & dt.Month().ToString.PadLeft(2, "0") & dt.Year().ToString.PadLeft(2, "0") & branch_id
            Dim i As Integer
            Dim ch As String
            Dim num As Integer
            Dim tot As Integer
            Dim p1, p2, p3, p4 As Integer

            tot = 0
            For i = 1 To 6
                ch = str.Substring(i - 1, 1)
                num = CInt((CInt(ch) ^ 2) / 2)
                tot = tot + num
            Next
            p1 = CInt(Math.Sqrt(tot))

            tot = 0
            For i = 7 To 10
                ch = str.Substring(i - 1, 1)
                num = CInt(ch)
                tot = tot + num
            Next
            p2 = tot

            tot = 0
            For i = 11 To 14
                ch = str.Substring(i - 1, 1)
                num = CInt(ch)
                tot = tot + num
            Next
            p3 = tot


            tot = 0
            For i = 15 To 20
                ch = str.Substring(i - 1, 1)
                num = (CInt(ch) * 3) ^ 2
                tot = tot + num
            Next
            p4 = CInt(Math.Sqrt(tot))

            str = p1.ToString & p2.ToString & p3.ToString & p4.ToString
            Return str
        End Function

    End Class



End Namespace