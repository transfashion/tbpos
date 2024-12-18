Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.Reporting.WinForms

Public Class PosPromo
    Dim POS As TransStore.POS
    Dim mainPosDialog As dlgTrnPosEN
    Dim itemGrid As DataGridView
    Dim PromoRule As Collection

    Dim promoDirectory As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Transbrowser\promos"
    Dim CurrentRegionId As String
    Dim CurrentBranchId As String
    Dim _CurrentActivePromo As List(Of PosPromoData) = New List(Of PosPromoData)


    Public Structure CustomerInfo
        Public Nama As String
        Public Id As String
        Public IsMember As Boolean
    End Structure


    Public CURRENT_SUBTOTAL As Decimal = 0
    Public CURRENT_DISCOUNT As Decimal = 0
    Public CURRENT_TOTAL As Decimal = 0


    Public Sub New()
        PromoRule = New Collection()
        PromoRule.Add("do_BundlingAB", "02")
        PromoRule.Add("do_BuyA_GetB", "03")
        PromoRule.Add("do_Termurah", "04")

    End Sub


    Public ReadOnly Property CurrentActivePromo() As List(Of PosPromoData)
        Get
            Return _CurrentActivePromo
        End Get
    End Property

    Public Sub SetPOS(ByVal pos As TransStore.POS)
        Me.POS = pos
    End Sub

    Public Sub setTrnPOSEN(ByVal dlg As dlgTrnPosEN)
        Me.mainPosDialog = dlg
    End Sub

    Public Sub setItemGrid(ByVal grid As DataGridView)
        Me.itemGrid = grid
    End Sub


    Public Sub InitializeActivePromo(ByVal region_id As String, ByVal branch_id As String)
        Me.CurrentRegionId = region_id
        Me.CurrentBranchId = branch_id

        Dim promoFilePath As String
        Dim promoContentEncoded As String
        Dim promoJson As String

        ' Baca seluruh ada promo yang ada di promoDirectory
        Dim i As Integer
        For Each promoFilePath In My.Computer.FileSystem.GetFiles(promoDirectory)
            i = i + 1

            promoContentEncoded = System.IO.File.ReadAllText(promoFilePath)
            promoJson = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(promoContentEncoded))

            Dim pd As PosPromoData = Newtonsoft.Json.JavaScriptConvert.DeserializeObject(Of PosPromoData)(promoJson)
            Dim is_region_match As Boolean = False
            Dim is_branch_match As Boolean = False
            Dim is_date_match As Boolean = False

            ' Cek apabila Region Sesuai
            is_region_match = IIf(pd.ValidRegion = Me.CurrentRegionId, True, False)
            If Not is_region_match Then
                Continue For
            End If

            ' Cek apabila Tanggal Sesuai
            If (Now.Date >= pd.startDate And Now.Date <= pd.endDate) Then
            Else
                ' Kalau tanggal tidak cocok
                Continue For
            End If

            ' Cek apabila branch sesuai
            If pd.ValidBranch.Count > 0 Then
                If Not pd.ValidBranch.Contains(Me.CurrentBranchId) Then
                    Continue For
                End If
            End If
            CurrentActivePromo.Add(pd)

            Dim up As TransStore.POS.UsedPromo = New TransStore.POS.UsedPromo()
            up.PromoId = pd.PromoId
            up.PromoName = pd.PromoName
            up.Active = True
            If (Not Me.POS.UsedPromoList.ContainsKey(pd.PromoId)) Then
                Me.POS.UsedPromoList.Add(pd.PromoId, up)
            Else
                MessageBox.Show("Promo " & pd.PromoId & " is dupicated.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Next

    End Sub


    ' Public Sub CalculateCurrentActivePromo(ByVal ci As CustomerInfo)
    Public Sub CalculateCurrentActivePromo(pd As PosPromoData, ci As CustomerInfo)
        If Me.POS Is Nothing Then
            Return
        End If

        Dim dtitem As DataTable = Me.itemGrid.DataSource 'bondetil_pricenettstd01
        If dtitem Is Nothing Then
            Exit Sub
        End If


        Me.POS.PromoApplied = False
        Me.POS.BolehDiscPayment = True



        Try
            'For Each pd As PosPromoData In Me.CurrentActivePromo

            If Not Me.POS.UsedPromoList.Item(pd.PromoId).Active Then
                Exit Sub
            End If

            If pd.isMemberOnly And Not ci.IsMember Then
                Exit Sub
            End If

            ' Commit Change sebelum diproses
            dtitem.AcceptChanges()

            Dim promoapplied As Boolean = False
            If Me.PromoRule.Contains(pd.Rule) Then
                Dim rulename As String = Me.PromoRule.Item(pd.Rule)
                If rulename = "do_BundlingAB" Then
                    promoapplied = Me.do_BundlingAB(dtitem, pd)
                ElseIf rulename = "do_BuyA_GetB" Then
                    promoapplied = Me.do_BuyA_GetB(dtitem, pd)
                ElseIf rulename = "do_Termurah" Then
                    promoapplied = Me.do_Termurah(dtitem, pd)
                End If
            Else
                Throw New Exception(String.Format("Promo Rule {0} tidak ditemukan", pd.Rule))
            End If

            If promoapplied Then
                Me.POS.PromoApplied = Me.POS.PromoApplied Or True
                Me.POS.BolehDiscPayment = Me.POS.BolehDiscPayment And pd.PaymentDiscAllowed
                For Each paymenttype_id As String In pd.PaymentTypeAllowed
                    If Not Me.POS.AllowedPaymenttype.Contains(paymenttype_id) Then
                        Me.POS.AllowedPaymenttype.Add(paymenttype_id, paymenttype_id)
                    End If
                Next
            End If

            'Next

            Me.POS.PosItems.AcceptChanges()

            Dim sum_qty = Me.POS.Count
            Dim sum_subtotal = Me.POS.Subtotal

            Me.mainPosDialog.setTotal(sum_qty, sum_subtotal)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub ClearPromo()
        If Me.POS Is Nothing Then
            Return
        End If

        Dim dtitem As DataTable = Me.itemGrid.DataSource 'bondetil_pricenettstd01
        If dtitem Is Nothing Then
            Exit Sub
        End If


        Me.POS.PromoApplied = False
        Me.POS.BolehDiscPayment = True

        For Each row As DataRow In dtitem.Rows
            Dim bondetil_qty As Integer = row("bondetil_qty")
            Dim bondetil_pricegross As Decimal = row("bondetil_pricegross")
            Dim bondetil_discpstd01 As Decimal = row("bondetil_discpstd01")
            Dim bondetil_discrstd01 As Decimal = row("bondetil_discrstd01")
            Dim bondetil_pricenettstd01 As Decimal = row("bondetil_pricenettstd01") 'bondetil_pricegross
            Dim pricing_disc = row("pricing_disc")

            Dim bondetil_discpvou01 As Decimal = 0
            Dim bondetil_discrvou01 As Decimal = 0
            Dim bondetil_pricenettvou01 As Decimal = 0

            Dim bondetil_vou01type As String = row("bondetil_vou01type")

            If bondetil_vou01type = "BONUS" Then
                Exit Sub
            End If


            ' Normalkan Harga
            bondetil_discpstd01 = pricing_disc
            bondetil_discrstd01 = (pricing_disc / 100) * bondetil_pricegross
            bondetil_pricenettstd01 = bondetil_pricegross - bondetil_discrstd01
            bondetil_discpvou01 = 0
            bondetil_discrvou01 = 0
            bondetil_pricenettvou01 = bondetil_pricenettstd01

            Dim bondetil_pricenet As Decimal = bondetil_pricenettstd01
            Dim bondetil_subtotal As Decimal = bondetil_qty * bondetil_pricenet

            row("bondetil_discpstd01") = bondetil_discpstd01
            row("bondetil_discrstd01") = bondetil_discrstd01
            row("bondetil_pricenettstd01") = bondetil_pricenettstd01
            row("bondetil_vou01id") = ""
            row("bondetil_vou01codenum") = ""
            row("bondetil_vou01type") = ""
            row("bondetil_vou01method") = ""
            row("bondetil_discpvou01") = bondetil_discpvou01
            row("bondetil_discrvou01") = bondetil_discrvou01
            row("bondetil_pricenettvou01") = bondetil_pricenettvou01
            row("bondetil_pricenet") = bondetil_pricenet
            row("bondetil_subtotal") = bondetil_subtotal
            row("proc") = "01"
        Next

    End Sub


    Public Sub ResetAppliedromo(ByVal dtitem As DataTable, ByVal promo_id As String)
        Dim dr() As DataRow
        dr = dtitem.Select(String.Format("bondetil_vou01id='{0}'", promo_id))
        For Each row As DataRow In dr
            Dim bondetil_qty As Integer = row("bondetil_qty")
            Dim bondetil_pricegross As Decimal = row("bondetil_pricegross")
            Dim bondetil_discpstd01 As Decimal = row("bondetil_discpstd01")
            Dim bondetil_discrstd01 As Decimal = row("bondetil_discrstd01")
            Dim bondetil_pricenettstd01 As Decimal = row("bondetil_pricenettstd01") 'bondetil_pricegross
            Dim pricing_disc = row("pricing_disc")

            Dim bondetil_discpvou01 As Decimal = 0
            Dim bondetil_discrvou01 As Decimal = 0
            Dim bondetil_pricenettvou01 As Decimal = 0

            Dim bondetil_vou01type As String = row("bondetil_vou01type")

            If bondetil_vou01type = "BONUS" Then
                Exit Sub
            End If

            ' Normalkan Harga
            bondetil_discpstd01 = pricing_disc
            bondetil_discrstd01 = (pricing_disc / 100) * bondetil_pricegross
            bondetil_pricenettstd01 = bondetil_pricegross - bondetil_discrstd01
            bondetil_discpvou01 = 0
            bondetil_discrvou01 = 0
            bondetil_pricenettvou01 = bondetil_pricenettstd01

            Dim bondetil_pricenet As Decimal = bondetil_pricenettstd01
            Dim bondetil_subtotal As Decimal = bondetil_qty * bondetil_pricenet

            row("bondetil_discpstd01") = bondetil_discpstd01
            row("bondetil_discrstd01") = bondetil_discrstd01
            row("bondetil_pricenettstd01") = bondetil_pricenettstd01
            row("bondetil_vou01id") = ""
            row("bondetil_vou01codenum") = ""
            row("bondetil_vou01type") = ""
            row("bondetil_vou01method") = ""
            row("bondetil_discpvou01") = bondetil_discpvou01
            row("bondetil_discrvou01") = bondetil_discrvou01
            row("bondetil_pricenettvou01") = bondetil_pricenettvou01
            row("bondetil_pricenet") = bondetil_pricenet
            row("bondetil_subtotal") = bondetil_subtotal
            row("proc") = "01"
        Next
    End Sub

    Public Sub GetPromoItems(ByVal dtitem As DataTable, ByVal pd As PosPromoData, ByRef nA As Integer, ByRef vA As Integer, ByRef drA As List(Of DataRow), ByRef nB As Integer, ByRef vB As Integer, ByRef drB As List(Of DataRow))
        Dim itemPrev As List(Of String) = New List(Of String)


        ' Urutkan item sesuai harga termahal
        dtitem.DefaultView.Sort = "bondetil_pricegross DESC"

        For Each itemview As DataRowView In dtitem.DefaultView
            Dim rowbasket As DataRow = itemview.Row

            Dim heinv_id = rowbasket("heinv_id")
            Dim qty As Integer = rowbasket("bondetil_qty")
            Dim nett As Decimal = rowbasket("bondetil_pricenettstd01")
            Dim subtotal As Decimal = rowbasket("bondetil_subtotal")

            If pd.DataA.Contains(heinv_id) Then
                itemPrev.Add(heinv_id)
                nA = nA + qty
                vA = vA + subtotal
                drA.Add(rowbasket)
            End If


            If (pd.groupA.pricing_id = pd.groupB.pricing_id) Then
                If pd.DataB.Contains(heinv_id) Then
                    nB = nB + qty
                    vB = vB + subtotal
                    drB.Add(rowbasket)
                End If
            Else
                If pd.DataB.Contains(heinv_id) Then
                    If Not itemPrev.Contains(heinv_id) Then
                        nB = nB + qty
                        vB = vB + subtotal
                        drB.Add(rowbasket)
                    End If
                End If
            End If

        Next


        '' Ambil barang yang ada di list Promo
        'For Each rowbasket As DataRow In dtitem.Rows
        '    Dim heinv_id = rowbasket("heinv_id")
        '    Dim qty As Integer = rowbasket("bondetil_qty")
        '    Dim subtotal As Integer = rowbasket("bondetil_subtotal")



        '    If pd.DataA.Contains(heinv_id) Then
        '        itemPrev.Add(heinv_id)
        '        nA = nA + qty
        '        vA = vA + subtotal
        '        drA.Add(rowbasket)
        '    End If


        '    If (pd.groupA.pricing_id = pd.groupB.pricing_id) Then
        '        If pd.DataB.Contains(heinv_id) Then
        '            nB = nB + qty
        '            vB = vB + subtotal
        '            drB.Add(rowbasket)
        '        End If
        '    Else
        '        If pd.DataB.Contains(heinv_id) Then
        '            If Not itemPrev.Contains(heinv_id) Then
        '                nB = nB + qty
        '                vB = vB + subtotal
        '                drB.Add(rowbasket)
        '            End If
        '        End If
        '    End If


        'Next
    End Sub

    Public Sub ApplyPromo(ByVal promo_id As String, ByVal promo_name As String, ByVal pdgroup As PosPromoGroup, ByVal dr As List(Of DataRow))
        Me.ApplyPromo(promo_id, promo_name, pdgroup, Nothing, dr)
    End Sub


    Public Sub ApplyPromo(ByVal promo_id As String, ByVal promo_name As String, ByVal pdgroupA As PosPromoGroup, ByVal pdgroupB As PosPromoGroup, ByVal dr As List(Of DataRow))
        Try
            Dim applynextgrouppromo As Boolean = False
            Dim dv As DataView = Nothing

            Dim imax As Integer = dr.Count
            Dim i As Integer = 0
            Dim ir As Integer = imax
            For Each row As DataRow In dr
                Dim bondetil_vou01type = row("bondetil_vou01type")
                If bondetil_vou01type = "BONUS" Then
                    Continue For
                End If


                i = i + 1
                ir = imax - (i - 1)

                Dim pricing_disc = row("pricing_disc")
                Dim bondetil_qty As Integer = row("bondetil_qty")
                Dim bondetil_pricegross As Decimal = row("bondetil_pricegross")
                Dim bondetil_discpstd01 As Decimal = row("bondetil_discpstd01")
                Dim bondetil_discrstd01 As Decimal = row("bondetil_discrstd01")
                Dim bondetil_pricenettstd01 As Decimal = row("bondetil_pricenettstd01") 'bondetil_pricegross
                Dim bondetil_discpvou01 As Decimal = 0
                Dim bondetil_discrvou01 As Decimal = 0
                Dim bondetil_pricenettvou01 As Decimal = 0




                Dim current_promo_id = row("bondetil_vou01id")


                Dim disc_additional_A As Decimal = 0
                Dim disc_additional_B As Decimal = 0

                disc_additional_A = pdgroupA.percentDiscount / 100
                If (pdgroupB IsNot Nothing) Then
                    disc_additional_B = pdgroupB.percentDiscount / 100
                End If


                If pdgroupA.replaceDiscount Then
                    ' Replace std pricing using ricing yg ada di promo
                    bondetil_discpstd01 = disc_additional_A * 100
                    bondetil_discrstd01 = disc_additional_A * bondetil_pricegross
                    bondetil_pricenettstd01 = bondetil_pricegross - bondetil_discrstd01
                    bondetil_discpvou01 = 0
                    bondetil_discrvou01 = 0
                    bondetil_pricenettvou01 = bondetil_pricenettstd01
                Else
                    ' Pricing discount bertingkat
                    bondetil_discpstd01 = pricing_disc
                    bondetil_discrstd01 = (pricing_disc / 100) * bondetil_pricegross
                    bondetil_pricenettstd01 = bondetil_pricegross - bondetil_discrstd01
                    bondetil_discpvou01 = disc_additional_A * 100
                    bondetil_discrvou01 = disc_additional_A * bondetil_pricenettstd01
                    bondetil_pricenettvou01 = bondetil_pricenettstd01 - bondetil_discrvou01
                End If


                Dim bondetil_pricenet As Decimal = bondetil_pricenettvou01
                Dim bondetil_subtotal As Decimal = bondetil_qty * bondetil_pricenet


                If i <= pdgroupA.qtyMaxApllied Then
                    row("bondetil_discpstd01") = bondetil_discpstd01
                    row("bondetil_discrstd01") = bondetil_discrstd01
                    row("bondetil_pricenettstd01") = bondetil_pricenettstd01
                    row("bondetil_vou01id") = promo_id
                    row("bondetil_vou01type") = promo_name
                    row("bondetil_vou01method") = pdgroupA.rowProcedureInfo
                    row("bondetil_discpvou01") = bondetil_discpvou01
                    row("bondetil_discrvou01") = bondetil_discrvou01
                    row("bondetil_pricenettvou01") = bondetil_pricenettvou01
                    row("bondetil_pricenet") = bondetil_pricenet
                    row("bondetil_subtotal") = bondetil_subtotal
                End If

                If (pdgroupB IsNot Nothing) Then
                    If ir <= pdgroupB.qtyMaxApllied Then
                        applynextgrouppromo = True


                        dv = row.Table.DefaultView

                        '' Replace std pricing using ricing yg ada di promo
                        bondetil_discpstd01 = disc_additional_B * 100
                        bondetil_discrstd01 = disc_additional_B * bondetil_pricegross
                        bondetil_pricenettstd01 = bondetil_pricegross - bondetil_discrstd01
                        bondetil_discpvou01 = 0
                        bondetil_discrvou01 = 0
                        bondetil_pricenettvou01 = bondetil_pricenettstd01
                        bondetil_pricenet = bondetil_pricenettvou01
                        bondetil_subtotal = bondetil_qty * bondetil_pricenet

                        row("bondetil_discpstd01") = bondetil_discpstd01
                        row("bondetil_discrstd01") = bondetil_discrstd01
                        row("bondetil_pricenettstd01") = bondetil_pricenettstd01
                        row("bondetil_vou01id") = promo_id
                        row("bondetil_vou01type") = promo_name
                        row("bondetil_vou01method") = pdgroupB.rowProcedureInfo
                        row("bondetil_discpvou01") = bondetil_discpvou01
                        row("bondetil_discrvou01") = bondetil_discrvou01
                        row("bondetil_pricenettvou01") = bondetil_pricenettvou01
                        row("bondetil_pricenet") = bondetil_pricenet
                        row("bondetil_subtotal") = bondetil_subtotal



                    End If

                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub ApplySyaratPromo(ByVal pd As PosPromoData, ByVal dr As List(Of DataRow))
        Dim promo_id As String = pd.PromoId
        Dim promo_name As String = pd.PromoName
        Dim pdgroupA As PosPromoGroup = pd.groupA


        Dim qtyDiv As Integer = pd.groupA.qtyThreshold + pd.groupB.qtyThreshold
        Dim qtyExit As Decimal = dr.Count / qtyDiv
        Dim qtyExitInt As Integer = Math.Ceiling(qtyExit)


        Try
            Dim applynextgrouppromo As Boolean = False
            'Dim dv As DataView =

            Dim imax As Integer = dr.Count
            Dim i As Integer = 0
            Dim ir As Integer = imax
            For Each row As DataRow In dr
                Dim bondetil_vou01type = row("bondetil_vou01type")
                If bondetil_vou01type = "BONUS" Then
                    Continue For
                End If


                i = i + 1
                ir = imax - (i - 1)

                If i > qtyExitInt Then
                    Exit For
                End If

                Dim pricing_disc = row("pricing_disc")
                Dim bondetil_qty As Integer = row("bondetil_qty")
                Dim bondetil_pricegross As Decimal = row("bondetil_pricegross")
                Dim bondetil_discpstd01 As Decimal = row("bondetil_discpstd01")
                Dim bondetil_discrstd01 As Decimal = row("bondetil_discrstd01")
                Dim bondetil_pricenettstd01 As Decimal = row("bondetil_pricenettstd01") 'bondetil_pricegross
                Dim bondetil_discpvou01 As Decimal = 0
                Dim bondetil_discrvou01 As Decimal = 0
                Dim bondetil_pricenettvou01 As Decimal = 0



                Dim current_promo_id = row("bondetil_vou01id")


                Dim disc_additional_A As Decimal = 0
                Dim disc_additional_B As Decimal = 0
                disc_additional_A = pdgroupA.percentDiscount / 100

                If pdgroupA.replaceDiscount Then
                    ' Replace std pricing using ricing yg ada di promo
                    bondetil_discpstd01 = disc_additional_A * 100
                    bondetil_discrstd01 = disc_additional_A * bondetil_pricegross
                    bondetil_pricenettstd01 = bondetil_pricegross - bondetil_discrstd01
                    bondetil_discpvou01 = 0
                    bondetil_discrvou01 = 0
                    bondetil_pricenettvou01 = bondetil_pricenettstd01
                Else
                    ' Pricing discount bertingkat
                    bondetil_discpstd01 = pricing_disc
                    bondetil_discrstd01 = (pricing_disc / 100) * bondetil_pricegross
                    bondetil_pricenettstd01 = bondetil_pricegross - bondetil_discrstd01
                    bondetil_discpvou01 = disc_additional_A * 100
                    bondetil_discrvou01 = disc_additional_A * bondetil_pricenettstd01
                    bondetil_pricenettvou01 = bondetil_pricenettstd01 - bondetil_discrvou01
                End If


                Dim bondetil_pricenet As Decimal = bondetil_pricenettvou01
                Dim bondetil_subtotal As Decimal = bondetil_qty * bondetil_pricenet


                If i <= pdgroupA.qtyMaxApllied Then
                    row("bondetil_discpstd01") = bondetil_discpstd01
                    row("bondetil_discrstd01") = bondetil_discrstd01
                    row("bondetil_pricenettstd01") = bondetil_pricenettstd01
                    row("bondetil_vou01id") = promo_id
                    row("bondetil_vou01type") = promo_name
                    row("bondetil_vou01method") = pdgroupA.rowProcedureInfo
                    row("bondetil_discpvou01") = bondetil_discpvou01
                    row("bondetil_discrvou01") = bondetil_discrvou01
                    row("bondetil_pricenettvou01") = bondetil_pricenettvou01
                    row("bondetil_pricenet") = bondetil_pricenet
                    row("bondetil_subtotal") = bondetil_subtotal
                End If

            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub ApplyNextPromo(ByVal pd As PosPromoData, ByVal dr As List(Of DataRow))

        Dim promo_id As String = pd.PromoId
        Dim promo_name As String = pd.PromoName
        Dim pdgroupB As PosPromoGroup = pd.groupB


        Dim qtyExit As Decimal = (dr.Count / pd.groupA.qtyThreshold) * pd.groupB.qtyThreshold
        Dim qtyExitInt As Integer = Math.Floor(qtyExit)

        Try
            Dim applynextgrouppromo As Boolean = False
            Dim dv As DataView = Nothing

            Dim imax As Integer = dr.Count
            Dim i As Integer = 0
            Dim ir As Integer = imax
            For Each row As DataRow In dr
                Dim bondetil_vou01type = row("bondetil_vou01type")
                If bondetil_vou01type = "BONUS" Then
                    Continue For
                End If


                If row("bondetil_vou01method") = "Syarat" Then
                    Continue For
                End If


                i = i + 1
                ir = imax - (i - 1)


                If i > qtyExitInt Then
                    Exit For
                End If

                Dim pricing_disc = row("pricing_disc")
                Dim bondetil_qty As Integer = row("bondetil_qty")
                Dim bondetil_pricegross As Decimal = row("bondetil_pricegross")
                Dim bondetil_discpstd01 As Decimal = row("bondetil_discpstd01")
                Dim bondetil_discrstd01 As Decimal = row("bondetil_discrstd01")
                Dim bondetil_pricenettstd01 As Decimal = row("bondetil_pricenettstd01") 'bondetil_pricegross
                Dim bondetil_discpvou01 As Decimal = 0
                Dim bondetil_discrvou01 As Decimal = 0
                Dim bondetil_pricenettvou01 As Decimal = 0



                Dim current_promo_id = row("bondetil_vou01id")


                Dim disc_additional_B As Decimal = 0


                disc_additional_B = pdgroupB.percentDiscount / 100


                'If pdgroupA.replaceDiscount Then
                '    ' Replace std pricing using ricing yg ada di promo
                '    bondetil_discpstd01 = disc_additional_A * 100
                '    bondetil_discrstd01 = disc_additional_A * bondetil_pricegross
                '    bondetil_pricenettstd01 = bondetil_pricegross - bondetil_discrstd01
                '    bondetil_discpvou01 = 0
                '    bondetil_discrvou01 = 0
                '    bondetil_pricenettvou01 = bondetil_pricenettstd01
                'Else
                '    ' Pricing discount bertingkat
                '    bondetil_discpstd01 = pricing_disc
                '    bondetil_discrstd01 = (pricing_disc / 100) * bondetil_pricegross
                '    bondetil_pricenettstd01 = bondetil_pricegross - bondetil_discrstd01
                '    bondetil_discpvou01 = disc_additional_A * 100
                '    bondetil_discrvou01 = disc_additional_A * bondetil_pricenettstd01
                '    bondetil_pricenettvou01 = bondetil_pricenettstd01 - bondetil_discrvou01
                'End If


                Dim bondetil_pricenet As Decimal = bondetil_pricenettvou01
                Dim bondetil_subtotal As Decimal = bondetil_qty * bondetil_pricenet


                'If i <= pdgroupA.qtyMaxApllied Then
                '    row("bondetil_discpstd01") = bondetil_discpstd01
                '    row("bondetil_discrstd01") = bondetil_discrstd01
                '    row("bondetil_pricenettstd01") = bondetil_pricenettstd01
                '    row("bondetil_vou01id") = promo_id
                '    row("bondetil_vou01type") = promo_name
                '    row("bondetil_vou01method") = pdgroupA.rowProcedureInfo
                '    row("bondetil_discpvou01") = bondetil_discpvou01
                '    row("bondetil_discrvou01") = bondetil_discrvou01
                '    row("bondetil_pricenettvou01") = bondetil_pricenettvou01
                '    row("bondetil_pricenet") = bondetil_pricenet
                '    row("bondetil_subtotal") = bondetil_subtotal
                'End If

                If (pdgroupB IsNot Nothing) Then
                    If ir <= pdgroupB.qtyMaxApllied Then
                        applynextgrouppromo = True

                        dv = row.Table.DefaultView

                        '' Replace std pricing using ricing yg ada di promo
                        bondetil_discpstd01 = disc_additional_B * 100
                        bondetil_discrstd01 = disc_additional_B * bondetil_pricegross
                        bondetil_pricenettstd01 = bondetil_pricegross - bondetil_discrstd01
                        bondetil_discpvou01 = 0
                        bondetil_discrvou01 = 0
                        bondetil_pricenettvou01 = bondetil_pricenettstd01
                        bondetil_pricenet = bondetil_pricenettvou01
                        bondetil_subtotal = bondetil_qty * bondetil_pricenet

                        row("bondetil_discpstd01") = bondetil_discpstd01
                        row("bondetil_discrstd01") = bondetil_discrstd01
                        row("bondetil_pricenettstd01") = bondetil_pricenettstd01
                        row("bondetil_vou01id") = promo_id
                        row("bondetil_vou01type") = promo_name
                        row("bondetil_vou01method") = pdgroupB.rowProcedureInfo
                        row("bondetil_discpvou01") = bondetil_discpvou01
                        row("bondetil_discrvou01") = bondetil_discrvou01
                        row("bondetil_pricenettvou01") = bondetil_pricenettvou01
                        row("bondetil_pricenet") = bondetil_pricenet
                        row("bondetil_subtotal") = bondetil_subtotal



                    End If

                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub





    Public Function do_BundlingAB(ByVal dtitem As DataTable, ByVal pd As PosPromoData) As Boolean
        Try
            Dim nA As Integer = 0
            Dim nB As Integer = 0
            Dim vA As Decimal = 0
            Dim vB As Decimal = 0

            Dim drA As List(Of DataRow) = New List(Of DataRow)
            Dim drB As List(Of DataRow) = New List(Of DataRow)


            ' Reset dulu semua item yang sudah dihitung dengan PromoId ini
            Me.ResetAppliedromo(dtitem, pd.PromoId)
            Me.POS.PosItems.AcceptChanges()
            Me.mainPosDialog.RecalculateTotal()


            ' Ambil barang yang ada di list Promo
            Me.GetPromoItems(dtitem, pd, nA, vA, drA, nB, vB, drB)

            ' Kalau tidak item exit saja
            If drA.Count = 0 And drB.Count = 0 Then
                Exit Function
            End If

            If Me.CURRENT_TOTAL < pd.TotalValueThreshold Then
                Exit Function
            End If

            Dim promoapplied As Boolean = False
            If nA >= pd.groupA.qtyThreshold And vA >= pd.groupA.valueThreshold Then
                Me.ApplyPromo(pd.PromoId, pd.PromoName, pd.groupA, drA)
                promoapplied = promoapplied Or True
            End If

            If nB >= pd.groupB.qtyThreshold And vB >= pd.groupB.valueThreshold Then
                Me.ApplyPromo(pd.PromoId, pd.PromoName, pd.groupB, drB)
                promoapplied = promoapplied Or True
            End If

            Return promoapplied
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function do_BuyA_GetB(ByVal dtitem As DataTable, ByVal pd As PosPromoData) As Boolean
        Try
            Dim nA As Integer = 0
            Dim nB As Integer = 0
            Dim vA As Decimal = 0
            Dim vB As Decimal = 0
            Dim itemPrev As List(Of String) = New List(Of String)
            Dim drA As List(Of DataRow) = New List(Of DataRow)
            Dim drB As List(Of DataRow) = New List(Of DataRow)

            ' Ambil barang yang ada di list Promo
            Me.GetPromoItems(dtitem, pd, nA, vA, drA, nB, vB, drB)

            ' Kalau tidak item exit saja
            If drA.Count = 0 And drB.Count = 0 Then
                Exit Function
            End If


            ' Reset dulu semua item yang sudah dihitung dengan PromoId ini
            Me.ResetAppliedromo(dtitem, pd.PromoId)
            Me.POS.PosItems.AcceptChanges()
            Me.mainPosDialog.RecalculateTotal()


            'If Me.CURRENT_TOTAL < pd.TotalValueThreshold Then
            '    Exit Function
            'End If

            Dim promoapplied As Boolean = False

            ' Prasyarat
            Dim condition_meet = False
            If nA >= pd.groupA.qtyThreshold And vA >= pd.groupA.valueThreshold Then
                If Me.CURRENT_TOTAL > pd.TotalValueThreshold Then
                    ' Me.ApplyPromo(promo_id, promo_name, pdgroup, Nothing, dr)
                    Me.ApplySyaratPromo(pd, drA)
                    condition_meet = True
                End If
            End If

            If Me.CURRENT_TOTAL > pd.TotalValueThreshold Then
                If condition_meet Then
                    Me.ApplyNextPromo(pd, drB)
                    promoapplied = promoapplied Or True
                End If
            Else
                If nB > 0 Then
                    If pd.groupB.blockOnUnmeetCondition Then
                        ' Barang tidak boleh masuk, kalau group A tidak memenuhi sayarat
                        For Each row As DataRow In drB
                            dtitem.Rows.Remove(row)
                        Next
                        Me.POS.PosItems.AcceptChanges()
                        Dim sum_qty = Me.POS.Count
                        Dim sum_subtotal = Me.POS.Subtotal
                        Me.mainPosDialog.setTotal(sum_qty, sum_subtotal)
                        Throw New ItemNotAllowedException("Cannot add items using rule " & pd.PromoName)
                    End If
                End If
            End If


            Return promoapplied
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function do_Termurah(ByVal dtitem As DataTable, ByVal pd As PosPromoData) As Boolean
        Try
            Dim nA As Integer = 0
            Dim nB As Integer = 0
            Dim vA As Decimal = 0
            Dim vB As Decimal = 0
            Dim itemPrev As List(Of String) = New List(Of String)
            Dim drA As List(Of DataRow) = New List(Of DataRow)
            Dim drB As List(Of DataRow) = New List(Of DataRow)

            ' Ambil barang yang ada di list Promo
            Me.GetPromoItems(dtitem, pd, nA, vA, drA, nB, vB, drB)

            ' Kalau tidak item exit saja
            If drA.Count = 0 And drB.Count = 0 Then
                Exit Function
            End If




            ' Termurah hanya apabila listnya sama
            ' Syarat dan barang yg akan di diskon di satu list data pricing
            If (pd.groupA.pricing_id = pd.groupB.pricing_id) Then

                ' Reset dulu semua item yang sudah dihitung dengan PromoId ini
                Me.ResetAppliedromo(dtitem, pd.PromoId)
                Me.POS.PosItems.AcceptChanges()
                Me.mainPosDialog.RecalculateTotal()


                Dim promoapplied As Boolean = False


                ' Prasyarat
                Dim condition_meet = False
                Dim totalPromoItemQty = nA + nB

                ' apakah barang promo yang dibeli ada di list
                If nA >= pd.groupA.qtyThreshold And vA >= pd.groupA.valueThreshold Then
                    If Me.CURRENT_TOTAL > pd.TotalValueThreshold Then
                        condition_meet = True
                    End If
                End If

                ' Jika ada barang berikutnya
                If condition_meet And totalPromoItemQty > 1 Then
                    Me.ApplyPromo(pd.PromoId, pd.PromoName, pd.groupA, pd.groupB, drA)
                End If


            End If





        Catch ex As Exception

        End Try
    End Function



End Class
