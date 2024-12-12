Public Class CreditCard

    Public Function Checkroute(ByVal a_num_l As Long)
        Dim i_Digit_a(19) As Integer
        Dim i_Equals_a(19) As Integer
        Dim x As Integer = 0
        Dim i_num_i As Integer = 2
        Dim l_num_s As String = Format(a_num_l, "00000000000000000000")

        Do While Not x = 19
            i_Equals_a(x) = Mid(l_num_s, l_num_s.Length - x, 1) * MultipliedBy(x + 1)
            x += 1
        Loop

        Dim i_total_i(19) As Integer
        Dim i_total_a As Integer
        x = 0
        Do While Not x = 19
            Try
                If i_Equals_a(x) < 10 Then
                    i_total_i(x) = i_Equals_a(x)
                Else
                    i_total_i(x) = math(i_Equals_a(x) / 10) + (i_Equals_a(x) Mod 10)
                End If
            Catch ex As Exception
                i_total_i(x) = 0
            End Try
            i_total_a = i_total_a + i_total_i(x)
            x += 1
        Loop

        If i_total_a Mod 10 = 0 Then
            Return 1
        Else
            Return 0
        End If
    End Function
    Private Function MultipliedBy(ByVal a_num_i As Integer)
        If a_num_i Mod 2 Then
            Return 1
        Else
            Return 2
        End If
    End Function
    Private Function math(ByVal a_num_i As Double)
        If a_num_i < CInt(a_num_i) Then
            Return CInt(a_num_i) - 1
        Else
            Return a_num_i
        End If
    End Function
End Class