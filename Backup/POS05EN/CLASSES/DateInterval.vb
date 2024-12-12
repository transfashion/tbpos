Namespace TransStore

    Public Class DateInterval

        Private _DateStart As Date
        Private _DateEnd As Date


        Public Property DateStart() As Date
            Get
                Return Me._DateStart
            End Get
            Set(value As Date)
                Me._DateStart = value
            End Set
        End Property


        Public Property DateEnd() As Date
            Get
                Return Me._DateEnd
            End Get
            Set(value As Date)
                Me._DateEnd = value
            End Set

        End Property


        Public Shared Function FromFString(fstring As String) As DateInterval
            Dim str_tahun = fstring.Substring(0, 4)
            Dim str_bulan = fstring.Substring(4, 2)
            Dim str_tanggal = fstring.Substring(6, 2)
            Dim str_interval = fstring.Substring(8, 3)

            Dim tahun = CInt(str_tahun)
            Dim bulan = CInt(str_bulan)
            Dim tanggal = CInt(str_tanggal)
            Dim interval = CInt(str_interval)

            Dim ds As Date = New Date(tahun, bulan, tanggal)
            Dim de As Date = ds.AddDays(interval)

            Dim obj As DateInterval
            obj = New DateInterval()
            obj.DateStart = ds
            obj.DateEnd = de

            Return obj
        End Function

        Public Shared Function IsValidDate(dt As Date, dateinterval As DateInterval) As Boolean
            Dim dtnow = New Date(dt.Year, dt.Month, dt.Day)
            Dim ret As Boolean = dtnow >= dateinterval.DateStart AndAlso dtnow <= dateinterval.DateEnd
            Return ret
        End Function

    End Class







End Namespace
