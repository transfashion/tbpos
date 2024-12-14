Imports Finisar
Imports IST.DataHash

Namespace TransStore

    Public Class POSItem
        Private fielddata As DataRow
        Private POS As POS

#Region " Constructor "

        Public Sub New(ByVal pos As POS)
            Me.POS = pos
        End Sub

#End Region

        Public ReadOnly Property Fields(ByVal columnname As String) As Object
            Get
                Try
                    Return fielddata(columnname)
                Catch ex As Exception
                    Return Nothing
                End Try
            End Get
        End Property

        'Public Function GetItem(ByVal objItem As POS.PosItemData) As Boolean
        '    'Dim dsn As String = POS.DSN
        '    'Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
        '    'Dim sql As String = ""
        '    'Dim columnname As String = ""

        '    'Try
        '    '    Dim cmd As OleDb.OleDbCommand
        '    '    Dim da As OleDb.OleDbDataAdapter
        '    '    Dim tbl As DataTable = New DataTable()

        '    '    conn.Open()
        '    '    sql = "select * from master_iteminventory where iteminventory_id='" & id & "'"
        '    '    cmd = New OleDb.OleDbCommand(sql, conn)
        '    '    da = New OleDb.OleDbDataAdapter(cmd)
        '    '    da.Fill(tbl)
        '    '    If tbl.Rows.Count > 0 Then
        '    '        Me.fielddata = tbl.Rows(0)
        '    '    Else
        '    '        Me.fielddata = Nothing
        '    '        Return False
        '    '    End If

        '    '    Return True
        '    'Catch ex As Exception
        '    '    Throw ex
        '    'Finally
        '    '    conn.Close()
        '    'End Try
        'End Function

        Public Function ReadEmbedSql(ByVal filename As String) As String

            Dim path As String = "POS05EN." & filename & ".sql"

            Try
                Dim assembly As System.Reflection.Assembly = Me.GetType().Assembly
                Dim stream As System.IO.Stream = assembly.GetManifestResourceStream(path)
                Dim streamreader As System.IO.StreamReader = New IO.StreamReader(stream)
                Return streamreader.ReadToEnd()
            Catch ex As Exception
                Throw ex
            End Try


        End Function


        Public Function ScanItem(ByVal id As String) As DataTable
            Dim dsn As String = POS.DSN
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(dsn)
            Dim SQL As String = ""
            Dim columnname As String = ""
            Dim tbl As DataTable = New DataTable()


            Try
                Dim temptext As String = Trim(id) & "    "
                Dim [operator] As String = temptext.Substring(0, 4)
                Dim [operand] As String = ""
                Dim cmdScan As OleDb.OleDbCommand
                Dim da As OleDb.OleDbDataAdapter

                conn.Open()


                ' Cek Search shortcut
                If [operator].ToUpper = "ART:" Then

                    Dim ScanMode As String = Me.POS.SCANMODE
                    If uiTrnPosEN.StartInfo.EnvironmentVariables("POSENV") = "DEV" Then
                        ScanMode = Config.ScanMode
                    End If

                    If ScanMode = POS.MODE_BARCODESCAN Or ScanMode = POS.MODE_ORIGINALBARCODESCAN Then
                        Return New DataTable()
                    End If


                    [operand] = temptext.Substring(4, Len(temptext) - 4)
                    'break operand dengan |

                    Dim operands() As String = [operand].Split("|")
                    If operands.Length > 0 Then
                        Dim _art As String = ""
                        Dim _mat As String = ""
                        Dim _col As String = ""

                        Try
                            _art = Trim(operands(0))
                            _mat = Trim(operands(1))
                            _col = Trim(operands(2))
                        Catch ex As Exception
                        End Try

                        Dim criteria As String = ""
                        Dim SQLCriteria As String = ""
                        Dim matchlike As Boolean = False
                        Dim asterixpos As Integer = _art.IndexOf("%")
                        If asterixpos > 0 Then
                            matchlike = True
                        End If


                        If _art <> "" Then
                            If matchlike Then
                                criteria = String.Format("heinv_art LIKE '{0}'", _art)
                            Else
                                criteria = String.Format("heinv_art = '{0}'", _art)
                            End If

                            If SQLCriteria <> "" Then
                                SQLCriteria &= " AND " & criteria
                            Else
                                SQLCriteria = criteria
                            End If
                        Else
                            Exit Try
                        End If


                        If _mat <> "" Then
                            criteria = String.Format("heinv_mat = '{0}'", _mat)
                            If SQLCriteria <> "" Then
                                SQLCriteria &= " AND " & criteria
                            Else
                                SQLCriteria = criteria
                            End If
                        End If

                        If _col <> "" Then
                            criteria = String.Format("heinv_col = '{0}'", _col)
                            If SQLCriteria <> "" Then
                                SQLCriteria &= " AND " & criteria
                            Else
                                SQLCriteria = criteria
                            End If
                        End If


                        If SQLCriteria.Contains("DELETE ") Or SQLCriteria.Contains("INSERT ") Or SQLCriteria.Contains("UPDATE ") Or SQLCriteria.Contains("DROP ") Then
                        Else

                            SQL = Me.ReadEmbedSql("ScanBarcode03")
                            cmdScan = conn.CreateCommand()
                            cmdScan.CommandType = CommandType.Text
                            cmdScan.CommandText = SQL
                            cmdScan.Parameters.Add(New System.Data.OleDb.OleDbParameter("@criteria", System.Data.OleDb.OleDbType.VarWChar, 255))
                            cmdScan.Parameters("@criteria").Value = SQLCriteria
                            da = New OleDb.OleDbDataAdapter(cmdScan)
                            da.Fill(tbl)
                        End If

                    End If


                ElseIf [operator].ToUpper = "DES:" Then
                    If Me.POS.SCANMODE = POS.MODE_BARCODESCAN Or Me.POS.SCANMODE = POS.MODE_ORIGINALBARCODESCAN Then
                        Return New DataTable()
                    End If


                    [operand] = temptext.Substring(4, Len(temptext) - 4)
                    Dim _des As String = " " & [operand]
                    Dim criteria As String = ""
                    Dim SQLCriteria As String = ""
                    Dim matchlike As Boolean
                    Dim asterixpos As Integer = _des.IndexOf("%")
                    If asterixpos > 0 Then
                        matchlike = True
                    End If


                    _des = Trim(_des)
                    If _des = "%%" Then
                        Exit Try
                    End If
                    If _des <> "" Then
                        If matchlike Then
                            criteria = String.Format("heinv_name LIKE '{0}'", _des)
                        Else
                            criteria = String.Format("heinv_name = '{0}'", _des)
                        End If

                        If SQLCriteria <> "" Then
                            SQLCriteria &= " AND " & criteria
                        Else
                            SQLCriteria = criteria
                        End If
                    End If

                    If SQLCriteria.Contains("DELETE ") Or SQLCriteria.Contains("INSERT ") Or SQLCriteria.Contains("UPDATE ") Or SQLCriteria.Contains("DROP ") Then
                    Else
                        SQL = Me.ReadEmbedSql("ScanBarcode03")
                        cmdScan = conn.CreateCommand()
                        cmdScan.CommandType = CommandType.Text
                        cmdScan.CommandText = SQL
                        cmdScan.Parameters.Add(New System.Data.OleDb.OleDbParameter("@criteria", System.Data.OleDb.OleDbType.VarWChar, 255))
                        cmdScan.Parameters("@criteria").Value = SQLCriteria
                        da = New OleDb.OleDbDataAdapter(cmdScan)
                        da.Fill(tbl)
                    End If


                Else
                    ' Cek apakah Identifiernya TM
                    If Left(id, 2) = TransStore.POS.ItemIdentifier Then
                        If Me.POS.SCANMODE = POS.MODE_ORIGINALBARCODESCAN Then
                            Return New DataTable()
                        End If

                        ' Identifier TM
                        SQL = Me.ReadEmbedSql("ScanBarcode01")
                        cmdScan = conn.CreateCommand()
                        cmdScan.CommandType = CommandType.Text
                        cmdScan.CommandText = SQL
                        cmdScan.Parameters.Add(New System.Data.OleDb.OleDbParameter("@id", System.Data.OleDb.OleDbType.VarWChar, 13))
                        cmdScan.Parameters("@id").Value = id
                        da = New OleDb.OleDbDataAdapter(cmdScan)
                        da.Fill(tbl)
                    Else
                        ' Identifier bukan TM
                        SQL = Me.ReadEmbedSql("ScanBarcode02")
                        cmdScan = conn.CreateCommand()
                        cmdScan.CommandType = CommandType.Text
                        cmdScan.CommandText = SQL
                        cmdScan.Parameters.Add(New System.Data.OleDb.OleDbParameter("@id", System.Data.OleDb.OleDbType.VarWChar, 13))
                        cmdScan.Parameters("@id").Value = id
                        da = New OleDb.OleDbDataAdapter(cmdScan)
                        da.Fill(tbl)
                    End If
                End If


                'Hasilnya tbl
                Dim t As DataTable = tbl


                ' Cek Promo


            Catch ex As Exception
                Throw ex
            Finally
                conn.Close()
            End Try

            Return tbl

        End Function





    End Class



End Namespace