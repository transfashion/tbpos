Imports Finisar
Imports IST.DataHash

Namespace TransStore



    Public Class DataExporter

#Region "      Structure "

        Public Structure FieldDefinition
            Dim fieldname As String
            Dim fieldtype As String
        End Structure

        Public Structure TableQueue
            Dim name As String
            Dim tablename As String
            Dim method As String
            Dim keys As String()
            Dim SQL As String
            Dim fields As FieldDefinition()
            Dim DEFSQL As String
            Dim msg As String
        End Structure

#End Region

        Public Shared Function CreateFieldDefinition(ByVal fieldname As String, ByVal fieldtype As String) As DataExporter.FieldDefinition
            Dim obj As DataExporter.FieldDefinition = New DataExporter.FieldDefinition
            obj.fieldname = fieldname
            obj.fieldtype = fieldtype
            Return obj
        End Function

        Public Shared Function CreateTableQueue(ByVal name As String, ByVal tablename As String, ByVal SQL As String, ByVal method As String, ByVal keys As String(), ByVal fields As DataExporter.FieldDefinition(), ByVal DEFSQL As String) As TransStore.DataExporter.TableQueue
            Dim obj As TransStore.DataExporter.TableQueue = New TransStore.DataExporter.TableQueue
            With obj
                .name = name
                .tablename = tablename
                .SQL = SQL
                .method = method
                .keys = keys
                .fields = fields
                .DEFSQL = DEFSQL
            End With
            Return obj
        End Function

        Public Shared Function CreateDEFSQL(ByVal tablename As String, ByVal fields As DataExporter.FieldDefinition()) As String
            Dim defsql As String = ""
            Dim field As DataExporter.FieldDefinition
            Dim line As String
            Dim lines As String() = {}

            defsql = "CREATE TABLE " & tablename & " ( " & vbCrLf
            For Each field In fields
                line = field.fieldname & " " & field.fieldtype
                Array.Resize(lines, lines.Length + 1)
                lines(lines.Length - 1) = line
            Next
            defsql &= String.Join(", " & vbCrLf, lines) & vbCrLf
            defsql &= ") "

            Return defsql
        End Function

        Public Shared Function CreateInsertSQLFromDatarow(ByVal tablename As String, ByVal dr As DataRow) As String
            Dim sql As String = ""
            Dim i As Integer
            Dim fieldname As String = ""
            Dim value As String = ""
            Dim fields As String() = {}
            Dim values As String() = {}
            Dim linefield As String = ""
            Dim linevalue As String = ""


            For i = 0 To dr.Table.Columns.Count - 1
                fieldname = dr.Table.Columns(i).ColumnName
                linefield = "[" & fieldname & "]"
                Array.Resize(fields, fields.Length + 1)
                fields(fields.Length - 1) = linefield

                'If fieldname = "customer_id" Then
                '    Dim t = 0
                'End If

                If dr(fieldname) IsNot DBNull.Value Then
                    If (TypeOf (dr(fieldname)) Is DateTime) Then
                        Dim dt As DateTime = dr(fieldname)
                        value = dt.ToString("yyyy-MM-dd HH:mm:ss")
                    Else
                        value = dr(fieldname)
                    End If
                    linevalue = "'" & value.Replace("'", "") & "'"
                Else
                        value = "NULL"
                    linevalue = value
                End If
                Array.Resize(values, values.Length + 1)
                values(values.Length - 1) = linevalue
            Next

            sql = "INSERT INTO " & tablename & " " & vbCrLf
            sql &= "(" & String.Join(", ", fields) & ") " & vbCrLf
            sql &= "VALUES " & vbCrLf
            sql &= "(" & String.Join(", ", values) & ") " & vbCrLf

            Return sql
        End Function


#Region "     Table Definion "

        Public Function __Create_transaksi_hepos(ByVal param As TransStore.PosDataUpdaterParam, ByVal updatemethod As String, ByVal keys As String()) As TransStore.DataExporter.TableQueue
            Dim obj As TransStore.DataExporter.TableQueue = New TransStore.DataExporter.TableQueue
            Dim tablename As String
            Dim SQL As String
            Dim fields As DataExporter.FieldDefinition()
            Dim DEFSQL As String
            Dim dt As Date = param.dt
            Dim dtSQL As String = dt.Year.ToString & "-" & dt.Month.ToString.PadLeft(2, "0") & "-" & dt.Day.ToString.PadLeft(2, "0")

            tablename = "transaksi_hepos"
            SQL = "DECLARE @date AS smalldatetime; " & vbCrLf
            SQL &= "SET @date='" & dtSQL & "'; " & vbCrLf

            If param.SENDDATAMODE = "UNSENT" Then
                SQL &= "SELECT  * FROM " & tablename & " A WHERE  A.syncode IS NULL OR A.syncode='' "
            Else
                SQL &= "SELECT  * FROM " & tablename & " A WHERE (convert(varchar(10),A.bon_date,120)=convert(varchar(10),@date,120)) OR A.syncode IS NULL OR A.syncode='' "
            End If

            fields = New DataExporter.FieldDefinition() {
                                    CreateFieldDefinition("bon_id", "varchar(40)"),
                                    CreateFieldDefinition("bon_idext", "varchar(50)"),
                                    CreateFieldDefinition("bon_event", "varchar(30)"),
                                    CreateFieldDefinition("bon_date", "varchar(19)"),
                                    CreateFieldDefinition("bon_createby", "varchar(30)"),
                                    CreateFieldDefinition("bon_createdate", "varchar(19)"),
                                    CreateFieldDefinition("bon_modifyby", "varchar(30)"),
                                    CreateFieldDefinition("bon_modifydate", "varchar(19)"),
                                    CreateFieldDefinition("bon_isvoid", "int"),
                                    CreateFieldDefinition("bon_voidby", "varchar(30)"),
                                    CreateFieldDefinition("bon_voiddate", "varchar(19)"),
                                    CreateFieldDefinition("bon_replacefromvoid", "varchar(40)"),
                                    CreateFieldDefinition("bon_msubtotal", "decimal(18, 0)"),
                                    CreateFieldDefinition("bon_msubtvoucher", "decimal(18, 0)"),
                                    CreateFieldDefinition("bon_msubtdiscadd", "decimal(18, 0)"),
                                    CreateFieldDefinition("bon_msubtredeem", "decimal(18, 0)"),
                                    CreateFieldDefinition("bon_msubtracttotal", "decimal(18, 0)"),
                                    CreateFieldDefinition("bon_msubtotaltobedisc", "decimal(18, 0)"),
                                    CreateFieldDefinition("bon_mdiscpaympercent", "decimal(18, 0)"),
                                    CreateFieldDefinition("bon_mdiscpayment", "decimal(18, 0)"),
                                    CreateFieldDefinition("bon_mtotal", "decimal(18, 0)"),
                                    CreateFieldDefinition("bon_mpayment", "decimal(18, 0)"),
                                    CreateFieldDefinition("bon_mrefund", "decimal(18, 0)"),
                                    CreateFieldDefinition("bon_msalegross", "decimal(18, 0)"),
                                    CreateFieldDefinition("bon_msaletax", "decimal(18, 0)"),
                                    CreateFieldDefinition("bon_msalenet", "decimal(18, 0)"),
                                    CreateFieldDefinition("bon_itemqty", "int"),
                                    CreateFieldDefinition("bon_rowitem", "int"),
                                    CreateFieldDefinition("bon_rowpayment", "int"),
                                    CreateFieldDefinition("bon_npwp", "varchar(50)"),
                                    CreateFieldDefinition("bon_fakturpajak", "varchar(50)"),
                                    CreateFieldDefinition("bon_adddisc_authusername", "varchar(50)"),
                                    CreateFieldDefinition("bon_disctype", "varchar(30)"),
                                    CreateFieldDefinition("customer_id", "varchar(30) NOT NULL DEFAULT '0' "),
                                    CreateFieldDefinition("customer_name", "varchar(30)"),
                                    CreateFieldDefinition("customer_telp", "varchar(30)"),
                                    CreateFieldDefinition("customer_npwp", "varchar(30)"),
                                    CreateFieldDefinition("customer_ageid", "varchar(30)"),
                                    CreateFieldDefinition("customer_agename", "varchar(30)"),
                                    CreateFieldDefinition("customer_genderid", "varchar(30)"),
                                    CreateFieldDefinition("customer_gendername", "varchar(30)"),
                                    CreateFieldDefinition("customer_nationalityid", "varchar(30)"),
                                    CreateFieldDefinition("customer_nationalityname", "varchar(30)"),
                                    CreateFieldDefinition("customer_typename", "varchar(30)"),
                                    CreateFieldDefinition("customer_passport", "varchar(30)"),
                                    CreateFieldDefinition("customer_disc", "varchar(30)"),
                                    CreateFieldDefinition("voucher01_id", "varchar(30)"),
                                    CreateFieldDefinition("voucher01_name", "varchar(30)"),
                                    CreateFieldDefinition("voucher01_codenum", "varchar(30)"),
                                    CreateFieldDefinition("voucher01_method", "varchar(30)"),
                                    CreateFieldDefinition("voucher01_type", "varchar(30)"),
                                    CreateFieldDefinition("voucher01_discp", "decimal(18, 0)"),
                                    CreateFieldDefinition("salesperson_id", "varchar(10)"),
                                    CreateFieldDefinition("salesperson_name", "varchar(30)"),
                                    CreateFieldDefinition("pospayment_id", "varchar(10) NOT NULL DEFAULT '0' "),
                                    CreateFieldDefinition("pospayment_name", "varchar(30) NOT NULL DEFAULT '0' "),
                                    CreateFieldDefinition("posedc_id", "varchar(10)"),
                                    CreateFieldDefinition("posedc_name", "varchar(30)"),
                                    CreateFieldDefinition("machine_id", "varchar(10)"),
                                    CreateFieldDefinition("region_id", "varchar(5)"),
                                    CreateFieldDefinition("branch_id", "varchar(7)"),
                                    CreateFieldDefinition("syncode", "varchar(50)"),
                                    CreateFieldDefinition("syndate", "varchar(19)"),
                                    CreateFieldDefinition("rowid", "varchar(50)"),
                                    CreateFieldDefinition("site_id_from", "varchar(20)")
                      }
            DEFSQL = CreateDEFSQL(tablename, fields)
            obj = DataExporter.CreateTableQueue("pos", tablename, SQL, updatemethod, keys, fields, DEFSQL)
            Return obj
        End Function

        Public Function __Create_transaksi_heposdetil(ByVal param As TransStore.PosDataUpdaterParam, ByVal updatemethod As String, ByVal keys As String()) As TransStore.DataExporter.TableQueue
            Dim obj As TransStore.DataExporter.TableQueue = New TransStore.DataExporter.TableQueue
            Dim tablename As String
            Dim SQL As String
            Dim fields As DataExporter.FieldDefinition()
            Dim DEFSQL As String
            Dim dt As Date = param.dt
            Dim dtSQL As String = dt.Year.ToString & "-" & dt.Month.ToString.PadLeft(2, "0") & "-" & dt.Day.ToString.PadLeft(2, "0")

            tablename = "transaksi_heposdetil"
            SQL = "DECLARE @date AS smalldatetime; " & vbCrLf
            SQL &= "SET @date='" & dtSQL & "'; " & vbCrLf

            If param.SENDDATAMODE = "UNSENT" Then
                SQL &= "SELECT B.* FROM transaksi_hepos A INNER JOIN " & tablename & " B ON A.bon_id=B.bon_id WHERE  A.syncode IS NULL "
            Else
                SQL &= "SELECT B.* FROM transaksi_hepos A INNER JOIN " & tablename & " B ON A.bon_id=B.bon_id WHERE (convert(varchar(10),A.bon_date,120)=convert(varchar(10),@date,120)) OR A.syncode IS NULL "
            End If

            fields = New DataExporter.FieldDefinition() {
                                    CreateFieldDefinition("bon_id", "varchar(40)"),
                                    CreateFieldDefinition("bondetil_line", "int"),
                                    CreateFieldDefinition("bondetil_gro", "varchar(10)"),
                                    CreateFieldDefinition("bondetil_ctg", "varchar(10)"),
                                    CreateFieldDefinition("bondetil_art", "varchar(30)"),
                                    CreateFieldDefinition("bondetil_mat", "varchar(30)"),
                                    CreateFieldDefinition("bondetil_col", "varchar(30)"),
                                    CreateFieldDefinition("bondetil_size", "varchar(30)"),
                                    CreateFieldDefinition("bondetil_descr", "varchar(50)"),
                                    CreateFieldDefinition("bondetil_qty", "int"),
                                    CreateFieldDefinition("bondetil_mpricegross", "decimal(18, 0)"),
                                    CreateFieldDefinition("bondetil_mdiscpstd01", "decimal(18, 0)"),
                                    CreateFieldDefinition("bondetil_mdiscrstd01", "decimal(18, 0)"),
                                    CreateFieldDefinition("bondetil_mpricenettstd01", "decimal(18, 0)"),
                                    CreateFieldDefinition("bondetil_mdiscpvou01", "decimal(18, 0)"),
                                    CreateFieldDefinition("bondetil_mdiscrvou01", "decimal(18, 0)"),
                                    CreateFieldDefinition("bondetil_mpricecettvou01", "decimal(18, 0)"),
                                    CreateFieldDefinition("bondetil_vou01id", "varchar(10)"),
                                    CreateFieldDefinition("bondetil_vou01codenum", "varchar(30)"),
                                    CreateFieldDefinition("bondetil_vou01type", "varchar(10)"),
                                    CreateFieldDefinition("bondetil_vou01method", "varchar(50)"),
                                    CreateFieldDefinition("bondetil_vou01discp", "decimal(18, 0)"),
                                    CreateFieldDefinition("bondetil_mpricenett", "decimal(18, 0)"),
                                    CreateFieldDefinition("bondetil_msubtotal", "decimal(18, 0)"),
                                    CreateFieldDefinition("bondetil_rule", "varchar(2)"),
                                    CreateFieldDefinition("heinv_id", "varchar(13)"),
                                    CreateFieldDefinition("heinvitem_id", "varchar(13)"),
                                    CreateFieldDefinition("heinvitem_barcode", "varchar(30)"),
                                    CreateFieldDefinition("region_id", "varchar(5)"),
                                    CreateFieldDefinition("region_nameshort", "varchar(30)"),
                                    CreateFieldDefinition("colname", "varchar(50)"),
                                    CreateFieldDefinition("sizetag", "varchar(50)"),
                                    CreateFieldDefinition("[proc]", "varchar(50)"),
                                    CreateFieldDefinition("bon_idext", "varchar(50)"),
                                    CreateFieldDefinition("rowid", "varchar(50)")
                    }


            DEFSQL = CreateDEFSQL(tablename, fields)
            obj = DataExporter.CreateTableQueue("pos items", tablename, SQL, updatemethod, keys, fields, DEFSQL)
            Return obj
        End Function

        Public Function __Create_transaksi_hepospayment(ByVal param As TransStore.PosDataUpdaterParam, ByVal updatemethod As String, ByVal keys As String()) As TransStore.DataExporter.TableQueue
            Dim obj As TransStore.DataExporter.TableQueue = New TransStore.DataExporter.TableQueue
            Dim tablename As String
            Dim SQL As String
            Dim fields As DataExporter.FieldDefinition()
            Dim DEFSQL As String
            Dim dt As Date = param.dt
            Dim dtSQL As String = dt.Year.ToString & "-" & dt.Month.ToString.PadLeft(2, "0") & "-" & dt.Day.ToString.PadLeft(2, "0")

            tablename = "transaksi_hepospayment"
            SQL = "DECLARE @date AS smalldatetime; " & vbCrLf
            SQL &= "SET @date='" & dtSQL & "'; " & vbCrLf

            If param.SENDDATAMODE = "UNSENT" Then
                SQL &= "SELECT B.* FROM transaksi_hepos A INNER JOIN " & tablename & " B ON A.bon_id=B.bon_id WHERE  A.syncode IS NULL "
            Else
                SQL &= "SELECT B.* FROM transaksi_hepos A INNER JOIN " & tablename & " B ON A.bon_id=B.bon_id WHERE (convert(varchar(10),A.bon_date,120)=convert(varchar(10),@date,120)) OR A.syncode IS NULL "
            End If

            fields = New DataExporter.FieldDefinition() {
                                CreateFieldDefinition("bon_id", "varchar(40)"),
                                CreateFieldDefinition("payment_line", "int"),
                                CreateFieldDefinition("payment_cardnumber", "varchar(40)"),
                                CreateFieldDefinition("payment_cardholder", "varchar(40)"),
                                CreateFieldDefinition("payment_mvalue", "decimal(18, 0)"),
                                CreateFieldDefinition("payment_mcash", "decimal(18, 0)"),
                                CreateFieldDefinition("payment_installment", "int"),
                                CreateFieldDefinition("pospayment_id", "varchar(10)"),
                                CreateFieldDefinition("pospayment_name", "varchar(30)"),
                                CreateFieldDefinition("pospayment_bank", "varchar(30)"),
                                CreateFieldDefinition("posedc_id", "varchar(10)"),
                                CreateFieldDefinition("posedc_name", "varchar(30)"),
                                CreateFieldDefinition("posedc_approval", "varchar(30)"),
                                CreateFieldDefinition("bon_idext", "varchar(50)"),
                                CreateFieldDefinition("rowid", "varchar(50)")
                    }


            DEFSQL = CreateDEFSQL(tablename, fields)
            obj = DataExporter.CreateTableQueue("pos payments", tablename, SQL, updatemethod, keys, fields, DEFSQL)
            Return obj
        End Function

#End Region

    End Class





End Namespace