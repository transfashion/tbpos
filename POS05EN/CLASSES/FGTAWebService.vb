Public Class FGTAWebService

    Private _wsAddress As String
     Private _ProxyAddress As String = ""
    Private _ProxyPort As String = ""


    Public Sub New(ByVal wsaddress As String)
        Me._wsAddress = wsaddress
    End Sub

    Public Function AcceptAllCertifications(ByVal sender As Object, ByVal certification As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function

    Public Function Execute(ByVal endpoint As String, ByVal args As Object) As Newtonsoft.Json.JavaScriptObject
        Dim res As Newtonsoft.Json.JavaScriptObject = Nothing

        Dim address As String = Me._wsAddress & "/index.php/api/" & endpoint
        Dim request As System.Net.HttpWebRequest = Me.CreateConnectionRequest(address)


        System.Net.ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)


        Try
            ' OTP
            Dim otp As Newtonsoft.Json.JavaScriptObject = Me.GetOtp(endpoint)
            Dim otp_value As String = otp.Item("value")
            Dim otp_password As String = otp.Item("password")

            Dim strPost As String = ""
            For Each key As String In args.Keys
                Dim val As String

                If _
                       args.Item(key).GetType() Is GetType(Newtonsoft.Json.JavaScriptObject) _
                    Or args.Item(key).GetType() Is GetType(Newtonsoft.Json.JavaScriptArray) _
                    Or args.Item(key).GetType() Is GetType(Object) _
                    Or IsArray(args.Item(key)) _
                Then

                    val = Newtonsoft.Json.JavaScriptConvert.SerializeObject(args.Item(key))
                Else
                    val = args.Item(key)
                End If
                Dim valueencoded As String = System.Web.HttpUtility.UrlEncode(val)
                Dim keyencoded As String = System.Web.HttpUtility.UrlEncode(key)
                strPost = keyencoded & "=" & valueencoded & "&" & strPost
            Next


            request.Headers.Add("otp", otp_value)

            Dim postData As String = strPost
            Dim encoding As New System.Text.UTF8Encoding
            Dim byteData As Byte() = encoding.GetBytes(postData)

            Dim postreqstream As IO.Stream = request.GetRequestStream()
            postreqstream.Write(byteData, 0, byteData.Length)
            postreqstream.Close()

            Dim postresponse As System.Net.HttpWebResponse
            postresponse = DirectCast(request.GetResponse(), System.Net.HttpWebResponse)

            Dim postreqreader As New IO.StreamReader(postresponse.GetResponseStream())
            Dim result As String = postreqreader.ReadToEnd

            res = Newtonsoft.Json.JavaScriptConvert.DeserializeObject(result)

            Dim ajaxsuccess As Boolean = res.Item("ajaxsuccess")
            Dim errormessage = res.Item("errormessage")
            If Not ajaxsuccess Then
                Throw New Exception(errormessage)
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return res
    End Function



    Public Function GetOtp(ByVal endpoint As String) As Newtonsoft.Json.JavaScriptObject
        Dim res As Newtonsoft.Json.JavaScriptObject = Nothing
        Dim otp_address = Me._wsAddress & "/" & "getotp.php?api=" & endpoint

        Try
            Dim otp_request As System.Net.HttpWebRequest = Me.CreateConnectionRequest(otp_address)
            Dim postData As String = "data=123"
            Dim encoding As New System.Text.UTF8Encoding
            Dim byteData As Byte() = encoding.GetBytes(postData)


            Dim postreqstream As IO.Stream = otp_request.GetRequestStream()
            postreqstream.Write(byteData, 0, byteData.Length)
            postreqstream.Close()

            Dim postresponse As System.Net.HttpWebResponse
            postresponse = DirectCast(otp_request.GetResponse(), System.Net.HttpWebResponse)

            Dim postreqreader As New IO.StreamReader(postresponse.GetResponseStream())
            Dim result As String = postreqreader.ReadToEnd


            res = Newtonsoft.Json.JavaScriptConvert.DeserializeObject(result)

        Catch ex As Exception
            Throw New Exception(otp_address & vbCrLf & ex.Message)
        End Try

        Return res
    End Function


    Private Function CreateConnectionRequest(ByVal address As String) As System.Net.HttpWebRequest
        Dim Uri As Uri = New Uri(address)
        Dim request As System.Net.HttpWebRequest = DirectCast(System.Net.WebRequest.Create(Uri), System.Net.HttpWebRequest)

        request.KeepAlive = False
        request.ProtocolVersion = System.Net.HttpVersion.Version10
        request.Timeout = System.Threading.Timeout.Infinite
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"
        request.UserAgent = "Dhewe WebConnection"
        'request.ReadWriteTimeout = 2000
        request.Headers.Add("tokenid", "1234567890")
        request.Headers.Add("clientid", "534523434u234234h4234jh4324")
        request.Headers.Add("fgserid", "lts")
        request.Headers.Add("fgkey", "1234567890")
        request.ContentType = "application/x-www-form-urlencoded"


        If _ProxyAddress <> "" Then
            Dim proxyURI As New Uri(_ProxyAddress & ":" & _ProxyPort)
            request.Proxy = New System.Net.WebProxy(proxyURI)
        End If



        Return request
    End Function

End Class
