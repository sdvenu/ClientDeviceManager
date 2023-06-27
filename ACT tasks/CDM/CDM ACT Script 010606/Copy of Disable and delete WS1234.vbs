Option Explicit
Dim fEnableDelays
fEnableDelays = False

Sub SendRequest1()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (0)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/login.aspx"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/login.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest2()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (62)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/css/ClientDeviceMgr.css"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "*/*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/login.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=v2gwd02q4vp0fcemujxlzizq"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/css/ClientDeviceMgr.css"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest3()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (31)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/aspnet_client/system_web/1_1_4322/WebUIValidation.js"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "*/*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/login.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=v2gwd02q4vp0fcemujxlzizq"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/aspnet_client/system_web/1_1_4322/WebUIValidation.js"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest4()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (63)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/images/edslogo.gif"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "*/*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/login.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=v2gwd02q4vp0fcemujxlzizq"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/images/edslogo.gif"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest5()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (4875)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/login.aspx"
        oRequest.Verb = "POST"
        oRequest.HTTPVersion = "HTTP/1.0"
        oRequest.EncodeBody = False
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/login.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "Content-Type", "application/x-www-form-urlencoded"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=v2gwd02q4vp0fcemujxlzizq"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__VIEWSTATE=dDwtMjA0MzYwODQzO3Q8O2w8aTwxPjs%2BO2w8"
        oRequest.Body = oRequest.Body + "dDw7bDxpPDQ%2BOz47bDx0PHA8cDxsPFRleHQ7PjtsPFVzZXIg"
        oRequest.Body = oRequest.Body + "SUQ6Oz4%2BOz47Oz47Pj47Pj47Ppv2hh8HXDLZD3fiC%2Bcdvu"
        oRequest.Body = oRequest.Body + "qS7GUv&txtBoxUserID=a123&txtBoxPassword=123&btnLog"
        oRequest.Body = oRequest.Body + "in=Login"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/login.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest6()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (31)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/Welcome.aspx"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/login.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=v2gwd02q4vp0fcemujxlzizq"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/Welcome.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest7()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (78)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/images/line.gif"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "*/*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/Welcome.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=v2gwd02q4vp0fcemujxlzizq"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/images/line.gif"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest8()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (1625)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/WSSelect.aspx"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/Welcome.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=v2gwd02q4vp0fcemujxlzizq"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/WSSelect.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest9()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (2438)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/DisableWS.aspx"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/WSSelect.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=v2gwd02q4vp0fcemujxlzizq"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/DisableWS.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest10()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (1500)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/DisableWS.aspx"
        oRequest.Verb = "POST"
        oRequest.HTTPVersion = "HTTP/1.0"
        oRequest.EncodeBody = False
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/DisableWS.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "Content-Type", "application/x-www-form-urlencoded"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=v2gwd02q4vp0fcemujxlzizq"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__EVENTTARGET=AutoSelection&__EVENTARGUMENT=&__VIE"
        oRequest.Body = oRequest.Body + "WSTATE=dDwxMzE1NDM3MzkxO3Q8O2w8aTwxPjs%2BO2w8dDw7b"
        oRequest.Body = oRequest.Body + "DxpPDE%2BO2k8MTE%2BOz47bDx0PHA8cDxsPFZpc2libGU7Pjt"
        oRequest.Body = oRequest.Body + "sPG88Zj47Pj47Pjs7Pjt0PHA8cDxsPFRleHQ7VG9vbFRpcDs%2"
        oRequest.Body = oRequest.Body + "BO2w8UGxlYXNlIHNlbGVjdCB0aGUgd29ya3N0YXRpb24gbmFtZ"
        oRequest.Body = oRequest.Body + "SB5b3Ugd2lzaCB0byBtb2RpZnkuO1lvdSBtdXN0IHNlbGVjdCB"
        oRequest.Body = oRequest.Body + "hIFdvcmtzdGF0aW9uIG5hbWUgdG8gcGVyZm9ybSAgc3RhdGUgd"
        oRequest.Body = oRequest.Body + "XBkYXRlcyA7Pj47Pjs7Pjs%2BPjs%2BPjtsPERpc2FibGVTZWx"
        oRequest.Body = oRequest.Body + "lY3Rpb247RGlzYWJsZVNlbGVjdGlvbjtBdXRvU2VsZWN0aW9uO"
        oRequest.Body = oRequest.Body + "0F1dG9TZWxlY3Rpb247Pj7hxGJBwZZ51Ho8z98xFVw4TWqq0Q%"
        oRequest.Body = oRequest.Body + "3D%3D&SelectionMode=AutoSelection"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/DisableWS.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest11()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (3515)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/DisableWS.aspx"
        oRequest.Verb = "POST"
        oRequest.HTTPVersion = "HTTP/1.0"
        oRequest.EncodeBody = False
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/DisableWS.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "Content-Type", "application/x-www-form-urlencoded"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=v2gwd02q4vp0fcemujxlzizq"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=dDwxMz"
        oRequest.Body = oRequest.Body + "E1NDM3MzkxO3Q8O2w8aTwxPjs%2BO2w8dDw7bDxpPDE%2BO2k8"
        oRequest.Body = oRequest.Body + "Mz47aTwxMT47aTwxMz47PjtsPHQ8cDxwPGw8VmlzaWJsZTs%2B"
        oRequest.Body = oRequest.Body + "O2w8bzx0Pjs%2BPjtwPGw8c3R5bGU7PjtsPGxlZnQ6MjIycHhc"
        oRequest.Body = oRequest.Body + "O1RvcDoyNjJweFw7Oz4%2BPjtsPGk8MT47aTwzPjtpPDU%2BOz"
        oRequest.Body = oRequest.Body + "47bDx0PHA8cDxsPEZvcmVDb2xvcjtUZXh0O18hU0I7PjtsPDI8"
        oRequest.Body = oRequest.Body + "TmF2eT47QWxsIHdvcmtzdGF0aW9ucyBjdXJyZW50IGNvbmZpZ3"
        oRequest.Body = oRequest.Body + "VyZWQgaW4gdGhlIGRhdGFiYXNlOjtpPDQ%2BOz4%2BOz47Oz47"
        oRequest.Body = oRequest.Body + "dDx0PHA8cDxsPERhdGFUZXh0RmllbGQ7RGF0YVZhbHVlRmllbG"
        oRequest.Body = oRequest.Body + "Q7PjtsPFdTTmFtZTtXU05hbWU7Pj47Pjt0PGk8NDY%2BO0A8Mj"
        oRequest.Body = oRequest.Body + "cxO0JMVkFJUiowMDAwNjtCTFZBSVIqMDAwMDc7QkxWQUlSKjAw"
        oRequest.Body = oRequest.Body + "MDA4O0JMVkFJUiowMDAwOTtCTFZBSVIqMDAwMTA7QkxWQUlSKj"
        oRequest.Body = oRequest.Body + "AwMDExO0JMVkFJUiowMDAxMjtCTFZBSVIqMDAwMTM7QkxWQUlS"
        oRequest.Body = oRequest.Body + "KjAwMDE0O0JMVkFJUiowMDAxNTtERlc0Njg0NzQ7SFM0Njg0Nz"
        oRequest.Body = oRequest.Body + "Q7S1MxMjM0NTtUUzEyMzQ7VFVMTUUqMjA3Njc7VFVMTUUqMjA3"
        oRequest.Body = oRequest.Body + "Njg7VFVMTUUqMjA3Njk7VFVMTUUqMjA3NzA7VFVMTUUqMjA3Nz"
        oRequest.Body = oRequest.Body + "E7VFVMTUUqMjA3NzQ7VFVMTUUqMjA3NzU7VFVMTUUqMjA3NzY7"
        oRequest.Body = oRequest.Body + "VFVMTUUqMjA3Nzc7VFVMTUUqMjA3Nzg7VFVMTUUqMjA3Nzk7VF"
        oRequest.Body = oRequest.Body + "VMTUUqMjA3ODA7VFVMTUUqMjA3ODE7VFVMTUUqMjA3ODI7VFVM"
        oRequest.Body = oRequest.Body + "TUUqMjA3ODM7VFVMTUUqMjA3ODQ7VFVMTUUqMjA3ODU7VFVMTU"
        oRequest.Body = oRequest.Body + "UqMjA4MTA7VFVMTUUqMjA4MTE7VFVMTUUqMjA4MTI7VFVMTUUq"
        oRequest.Body = oRequest.Body + "MjA4MTM7VFVMTUUqMjA4MTQ7VFVMTUUqMjA4MTU7VFVMTUUqMj"
        oRequest.Body = oRequest.Body + "A4MTY7VFVMTUUqMjA4MTc7VFVMTUUqMjA4MTg7VFVMTUUqMjA4"
        oRequest.Body = oRequest.Body + "MTk7VFVMTUUqMjA4MjA7VFVMTUUqMjA4MjE7VFVMTUUqMjA4Mz"
        oRequest.Body = oRequest.Body + "A7V1MxMjM0Oz47QDwyNzE7QkxWQUlSKjAwMDA2O0JMVkFJUiow"
        oRequest.Body = oRequest.Body + "MDAwNztCTFZBSVIqMDAwMDg7QkxWQUlSKjAwMDA5O0JMVkFJUi"
        oRequest.Body = oRequest.Body + "owMDAxMDtCTFZBSVIqMDAwMTE7QkxWQUlSKjAwMDEyO0JMVkFJ"
        oRequest.Body = oRequest.Body + "UiowMDAxMztCTFZBSVIqMDAwMTQ7QkxWQUlSKjAwMDE1O0RGVz"
        oRequest.Body = oRequest.Body + "Q2ODQ3NDtIUzQ2ODQ3NDtLUzEyMzQ1O1RTMTIzNDtUVUxNRSoy"
        oRequest.Body = oRequest.Body + "MDc2NztUVUxNRSoyMDc2ODtUVUxNRSoyMDc2OTtUVUxNRSoyMD"
        oRequest.Body = oRequest.Body + "c3MDtUVUxNRSoyMDc3MTtUVUxNRSoyMDc3NDtUVUxNRSoyMDc3"
        oRequest.Body = oRequest.Body + "NTtUVUxNRSoyMDc3NjtUVUxNRSoyMDc3NztUVUxNRSoyMDc3OD"
        oRequest.Body = oRequest.Body + "tUVUxNRSoyMDc3OTtUVUxNRSoyMDc4MDtUVUxNRSoyMDc4MTtU"
        oRequest.Body = oRequest.Body + "VUxNRSoyMDc4MjtUVUxNRSoyMDc4MztUVUxNRSoyMDc4NDtUVU"
        oRequest.Body = oRequest.Body + "xNRSoyMDc4NTtUVUxNRSoyMDgxMDtUVUxNRSoyMDgxMTtUVUxN"
        oRequest.Body = oRequest.Body + "RSoyMDgxMjtUVUxNRSoyMDgxMztUVUxNRSoyMDgxNDtUVUxNRS"
        oRequest.Body = oRequest.Body + "oyMDgxNTtUVUxNRSoyMDgxNjtUVUxNRSoyMDgxNztUVUxNRSoy"
        oRequest.Body = oRequest.Body + "MDgxODtUVUxNRSoyMDgxOTtUVUxNRSoyMDgyMDtUVUxNRSoyMD"
        oRequest.Body = oRequest.Body + "gyMTtUVUxNRSoyMDgzMDtXUzEyMzQ7Pj47Pjs7Pjt0PHA8cDxs"
        oRequest.Body = oRequest.Body + "PFRleHQ7PjtsPERpc2FibGU7Pj47Pjs7Pjs%2BPjt0PHA8cDxs"
        oRequest.Body = oRequest.Body + "PFZpc2libGU7PjtsPG88Zj47Pj47Pjs7Pjt0PHA8cDxsPFRleH"
        oRequest.Body = oRequest.Body + "Q7VG9vbFRpcDs%2BO2w8UGxlYXNlIHNlbGVjdCB0aGUgd29ya3"
        oRequest.Body = oRequest.Body + "N0YXRpb24gbmFtZSB5b3Ugd2lzaCB0byBtb2RpZnkuO1lvdSBt"
        oRequest.Body = oRequest.Body + "dXN0IHNlbGVjdCBhIFdvcmtzdGF0aW9uIG5hbWUgdG8gcGVyZm"
        oRequest.Body = oRequest.Body + "9ybSAgc3RhdGUgdXBkYXRlcyA7Pj47Pjs7Pjt0PHA8cDxsPENo"
        oRequest.Body = oRequest.Body + "ZWNrZWQ7PjtsPG88dD47Pj47Pjs7Pjs%2BPjs%2BPjtsPERpc2"
        oRequest.Body = oRequest.Body + "FibGVTZWxlY3Rpb247RGlzYWJsZVNlbGVjdGlvbjtBdXRvU2Vs"
        oRequest.Body = oRequest.Body + "ZWN0aW9uOz4%2B%2BA67ORfJE2EOp73dpVWL28PegU8%3D&lbx"
        oRequest.Body = oRequest.Body + "WSNames=WS1234&btnAuto=Disable&SelectionMode=AutoS"
        oRequest.Body = oRequest.Body + "election"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/DisableWS.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest12()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (1750)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/DelWS.aspx"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/DisableWS.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=v2gwd02q4vp0fcemujxlzizq"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/DelWS.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest13()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (1157)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/DelWS.aspx"
        oRequest.Verb = "POST"
        oRequest.HTTPVersion = "HTTP/1.0"
        oRequest.EncodeBody = False
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/DelWS.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "Content-Type", "application/x-www-form-urlencoded"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=v2gwd02q4vp0fcemujxlzizq"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__EVENTTARGET=rbDelFromList&__EVENTARGUMENT=&__VIE"
        oRequest.Body = oRequest.Body + "WSTATE=dDwxNzQyMTYwNTIwOztsPHJiTWFudWFsRGVsO3JiRGV"
        oRequest.Body = oRequest.Body + "sRnJvbUxpc3Q7cmJEZWxGcm9tTGlzdDs%2BPs5pnLkmUgZL85c"
        oRequest.Body = oRequest.Body + "QCwtZHqGEPks8&Delete=rbDelFromList&txtboxWSName="
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/DelWS.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest14()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (3593)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/DelWS.aspx"
        oRequest.Verb = "POST"
        oRequest.HTTPVersion = "HTTP/1.0"
        oRequest.EncodeBody = False
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/DelWS.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "Content-Type", "application/x-www-form-urlencoded"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=v2gwd02q4vp0fcemujxlzizq"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=dDwxNz"
        oRequest.Body = oRequest.Body + "QyMTYwNTIwO3Q8O2w8aTwxPjs%2BO2w8dDw7bDxpPDE%2BO2k8"
        oRequest.Body = oRequest.Body + "Nz47aTw4PjtpPDk%2BOz47bDx0PHA8cDxsPFZpc2libGU7Pjts"
        oRequest.Body = oRequest.Body + "PG88dD47Pj47cDxsPHN0eWxlOz47bDxaLUlOREVYOjEwNlw7TE"
        oRequest.Body = oRequest.Body + "VGVDo4cHhcO1BPU0lUSU9OOmFic29sdXRlXDtUT1A6OHB4XDts"
        oRequest.Body = oRequest.Body + "ZWZ0OjI2MnB4XDtUb3A6MjkycHhcOzs%2BPj47bDxpPDM%2BOz"
        oRequest.Body = oRequest.Body + "47bDx0PHQ8cDxwPGw8RGF0YVRleHRGaWVsZDtEYXRhVmFsdWVG"
        oRequest.Body = oRequest.Body + "aWVsZDs%2BO2w8V1NOYW1lO1dTTmFtZTs%2BPjs%2BO3Q8aTwx"
        oRequest.Body = oRequest.Body + "PjtAPFdTMTIzNDs%2BO0A8V1MxMjM0Oz4%2BOz47Oz47Pj47dD"
        oRequest.Body = oRequest.Body + "xwPHA8bDxDaGVja2VkOz47bDxvPGY%2BOz4%2BOz47Oz47dDxw"
        oRequest.Body = oRequest.Body + "PHA8bDxDaGVja2VkOz47bDxvPHQ%2BOz4%2BOz47Oz47dDxwPH"
        oRequest.Body = oRequest.Body + "A8bDxWaXNpYmxlOz47bDxvPGY%2BOz4%2BOz47Oz47Pj47Pj47"
        oRequest.Body = oRequest.Body + "bDxyYk1hbnVhbERlbDtyYk1hbnVhbERlbDtyYkRlbEZyb21MaX"
        oRequest.Body = oRequest.Body + "N0Oz4%2B7%2BQPO0iltscl%2BArbWpr3XCVmeEg%3D&lbxWSNa"
        oRequest.Body = oRequest.Body + "mes=WS1234&btnAutoDel=Delete&Delete=rbDelFromList"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/DelWS.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest15()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (3641)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/LogOff.aspx"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/DelWS.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=v2gwd02q4vp0fcemujxlzizq"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/LogOff.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest16()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (47)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/Login.aspx"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/DelWS.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=v2gwd02q4vp0fcemujxlzizq"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/Login.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub




Sub Main()
    call SendRequest1()
    call SendRequest2()
    call SendRequest3()
    call SendRequest4()
    call SendRequest5()
    call SendRequest6()
    call SendRequest7()
    call SendRequest8()
    call SendRequest9()
    call SendRequest10()
    call SendRequest11()
    call SendRequest12()
    call SendRequest13()
    call SendRequest14()
    call SendRequest15()
    call SendRequest16()
End Sub
Main
