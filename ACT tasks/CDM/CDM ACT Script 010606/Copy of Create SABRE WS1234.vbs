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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
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
    If fEnableDelays = True then Test.Sleep (32)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
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
    If fEnableDelays = True then Test.Sleep (109)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
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
    If fEnableDelays = True then Test.Sleep (5156)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__VIEWSTATE=dDwtMjA0MzYwODQzO3Q8O2w8aTwxPjs%2BO2w8"
        oRequest.Body = oRequest.Body + "dDw7bDxpPDQ%2BOz47bDx0PHA8cDxsPFRleHQ7PjtsPFVzZXIg"
        oRequest.Body = oRequest.Body + "SUQ6Oz4%2BOz47Oz47Pj47Pj47Ppv2hh8HXDLZD3fiC%2Bcdvu"
        oRequest.Body = oRequest.Body + "qS7GUv&txtBoxUserID=a123&txtBoxPassword=1123&btnLo"
        oRequest.Body = oRequest.Body + "gin=Login"
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
    If fEnableDelays = True then Test.Sleep (5110)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__VIEWSTATE=dDwtMjA0MzYwODQzO3Q8O2w8aTwxPjs%2BO2w8"
        oRequest.Body = oRequest.Body + "dDw7bDxpPDQ%2BO2k8Nj47aTwxMT47PjtsPHQ8cDxwPGw8VGV4"
        oRequest.Body = oRequest.Body + "dDs%2BO2w8VXNlciBJRDo7Pj47Pjs7Pjt0PHA8cDxsPFRleHQ7"
        oRequest.Body = oRequest.Body + "PjtsPGExMjM7Pj47Pjs7Pjt0PHA8cDxsPFRleHQ7PjtsPEluY2"
        oRequest.Body = oRequest.Body + "9ycmVjdCBQYXNzd29yZCBzdXBwbGllZC47Pj47Pjs7Pjs%2BPj"
        oRequest.Body = oRequest.Body + "s%2BPjs%2BVjuP1LqypyZGnifFT9XC4qum58s%3D&txtBoxUse"
        oRequest.Body = oRequest.Body + "rID=a123&txtBoxPassword=123&btnLogin=Login"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/login.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest7()
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
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

Sub SendRequest8()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (94)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
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

Sub SendRequest9()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (2015)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
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

Sub SendRequest10()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (5891)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/WSSelect.aspx"
        oRequest.Verb = "POST"
        oRequest.HTTPVersion = "HTTP/1.0"
        oRequest.EncodeBody = False
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/WSSelect.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "Content-Type", "application/x-www-form-urlencoded"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=dDwxND"
        oRequest.Body = oRequest.Body + "Y3MzI3NzA4O3Q8O2w8aTwxPjs%2BO2w8dDw7bDxpPDE%2BO2k8"
        oRequest.Body = oRequest.Body + "Mz47aTwxMj47PjtsPHQ8O2w8aTwxPjs%2BO2w8dDxwPHA8bDxU"
        oRequest.Body = oRequest.Body + "ZXh0Oz47bDxXb3Jrc3RhdGlvbiBOYW1lOz4%2BOz47Oz47Pj47"
        oRequest.Body = oRequest.Body + "dDxwPHA8bDxWaXNpYmxlOz47bDxvPGY%2BOz4%2BOz47Oz47dD"
        oRequest.Body = oRequest.Body + "xwPHA8bDxUZXh0O1Rvb2xUaXA7PjtsPFBsZWFzZSBzZWxlY3Qg"
        oRequest.Body = oRequest.Body + "dGhlIHdvcmtzdGF0aW9uIG5hbWUgeW91IHdpc2ggdG8gbW9kaW"
        oRequest.Body = oRequest.Body + "Z5LjtZb3UgbXVzdCBzZWxlY3QgYSBXb3Jrc3RhdGlvbiBuYW1l"
        oRequest.Body = oRequest.Body + "IHRvIHBlcmZvcm0gdXBkYXRlcyBvcnZpZXcgdGhlIGNvbmZpZ3"
        oRequest.Body = oRequest.Body + "VyYXRpb24gaW5mb3JtYXRpb24gYXNzb2NpYXRlZCB3aXRoIGEg"
        oRequest.Body = oRequest.Body + "d29ya3N0YXRpb24uOz4%2BOz47Oz47Pj47Pj47bDxEaXNhYmxl"
        oRequest.Body = oRequest.Body + "U2VsZWN0aW9uO0Rpc2FibGVTZWxlY3Rpb247TWFudWFsU2VsZW"
        oRequest.Body = oRequest.Body + "N0aW9uO0F1dG9TZWxlY3Rpb247QXV0b1NlbGVjdGlvbjs%2BPt"
        oRequest.Body = oRequest.Body + "8CZwagdCR3xl72PFy0rqA2wEHv&txtboxWSName=WS1234&btn"
        oRequest.Body = oRequest.Body + "Manual=Accept&SelectionMode=ManualSelection"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/WSSelect.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest11()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (3062)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/NewRoute.aspx"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/WSSelect.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/NewRoute.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest12()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (250)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/ClientDeviceMgr.js"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "*/*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/NewRoute.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/ClientDeviceMgr.js"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest13()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (5344)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/NewRoute.aspx"
        oRequest.Verb = "POST"
        oRequest.HTTPVersion = "HTTP/1.0"
        oRequest.EncodeBody = False
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/NewRoute.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "Content-Type", "application/x-www-form-urlencoded"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__VIEWSTATE=dDwxMzA3MzI1NzkxO3Q8O2w8aTwxPjs%2BO2w8"
        oRequest.Body = oRequest.Body + "dDw7bDxpPDU%2BO2k8Nz47aTwxMT47PjtsPHQ8cDxwPGw8Rm9y"
        oRequest.Body = oRequest.Body + "ZUNvbG9yO1RleHQ7XyFTQjs%2BO2w8MjxOYXZ5PjtQbGVhc2Ug"
        oRequest.Body = oRequest.Body + "ZW50ZXIgdGhlIFJvdXRlTmFtZSB5b3Ugd2lzaCB0byBjcmVhdG"
        oRequest.Body = oRequest.Body + "UgZm9yIHdvcmtzdGF0aW9uOiBXUzEyMzQuO2k8ND47Pj47Pjs7"
        oRequest.Body = oRequest.Body + "Pjt0PHA8O3A8bDxvbktleVVwOz47bDxMaW1pdFRvVXBwZXJjYX"
        oRequest.Body = oRequest.Body + "NlKE5ld1JvdXRlRm9ybS50eHRib3hOZXdSb3V0ZSk7Pj4%2BOz"
        oRequest.Body = oRequest.Body + "s%2BO3Q8dDxwPHA8bDxEYXRhVGV4dEZpZWxkO0RhdGFWYWx1ZU"
        oRequest.Body = oRequest.Body + "ZpZWxkOz47bDxQcm90b2NvbDtQcm90b2NvbDs%2BPjs%2BO3Q8"
        oRequest.Body = oRequest.Body + "aTwyPjtAPEhTU1A7T0ZFUDs%2BO0A8SFNTUDtPRkVQOz4%2BOz"
        oRequest.Body = oRequest.Body + "47Oz47Pj47Pj47PiL0tZv%2Fcznb6LQVXV45i4NwczMz&txtbo"
        oRequest.Body = oRequest.Body + "xNewRoute=SABRE&btnCreate=Create&ProtocolDropDownL"
        oRequest.Body = oRequest.Body + "ist=HSSP"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/NewRoute.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest14()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (63)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/HSSPRoute.aspx"+"?ROUTENAME=SABRE"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/NewRoute.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/HSSPRoute.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest15()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (1953)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/HSSPRoute.aspx"+"?ROUTENAME=SABRE"
        oRequest.Verb = "POST"
        oRequest.HTTPVersion = "HTTP/1.0"
        oRequest.EncodeBody = False
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/HSSPRoute.aspx?ROUTENAME=SABRE"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "Content-Type", "application/x-www-form-urlencoded"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__EVENTTARGET=rbTerminal&__EVENTARGUMENT=&__VIEWST"
        oRequest.Body = oRequest.Body + "ATE=dDwtMTM3ODM2NDA5Nzt0PDtsPGk8MT47PjtsPHQ8O2w8aT"
        oRequest.Body = oRequest.Body + "wzPjtpPDc%2BO2k8OT47PjtsPHQ8cDw7cDxsPHN0eWxlOz47bD"
        oRequest.Body = oRequest.Body + "xaLUlOREVYOjEwMVw7TEVGVDozMjBweFw7UE9TSVRJT046YWJz"
        oRequest.Body = oRequest.Body + "b2x1dGVcO1RPUDo4cHhcO2xlZnQ6MjQycHhcO1RvcDoxMDBweF"
        oRequest.Body = oRequest.Body + "w7Oz4%2BPjtsPGk8NT47aTwzOT47PjtsPHQ8cDxwPGw8R3JvdX"
        oRequest.Body = oRequest.Body + "BOYW1lOz47bDxyYlByaW50ZXI7Pj47Pjs7Pjt0PHA8cDxsPFZp"
        oRequest.Body = oRequest.Body + "c2libGU7PjtsPG88Zj47Pj47Pjs7Pjs%2BPjt0PHA8cDxsPFZp"
        oRequest.Body = oRequest.Body + "c2libGU7PjtsPG88Zj47Pj47Pjs7Pjt0PHA8cDxsPFZpc2libG"
        oRequest.Body = oRequest.Body + "U7PjtsPG88Zj47Pj47Pjs7Pjs%2BPjs%2BPjtsPHJiVGVybWlu"
        oRequest.Body = oRequest.Body + "YWw7cmJUZXJtaW5hbDtyYlByaW50ZXI7cmJQcmludGVyO3JiSG"
        oRequest.Body = oRequest.Body + "9zdFBvb2xpbmc7cmJIb3N0UG9vbGluZztyYkFnZW5jeVBvb2xp"
        oRequest.Body = oRequest.Body + "bmc7cmJBZ2VuY3lQb29saW5nOz4%2BLUjEfcnsw%2FZypiim9f"
        oRequest.Body = oRequest.Body + "jVFg3gSIo%3D&DevType=rbTerminal&txtboxLNIATA=&txtb"
        oRequest.Body = oRequest.Body + "oxBCC=&txtboxHostPoolName=&txtboxBranchPCC=&txtbox"
        oRequest.Body = oRequest.Body + "ProfileKey=&txtboxCityCode=&txtboxPartition="
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/HSSPRoute.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest16()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (7234)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/HSSPRoute.aspx"+"?ROUTENAME=SABRE"
        oRequest.Verb = "POST"
        oRequest.HTTPVersion = "HTTP/1.0"
        oRequest.EncodeBody = False
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/HSSPRoute.aspx?ROUTENAME=SABRE"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "Content-Type", "application/x-www-form-urlencoded"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=dDwtMT"
        oRequest.Body = oRequest.Body + "M3ODM2NDA5Nzt0PDtsPGk8MT47PjtsPHQ8O2w8aTwzPjtpPDc%"
        oRequest.Body = oRequest.Body + "2BO2k8OT47PjtsPHQ8cDw7cDxsPHN0eWxlOz47bDxaLUlOREVY"
        oRequest.Body = oRequest.Body + "OjEwMVw7TEVGVDozMjBweFw7UE9TSVRJT046YWJzb2x1dGVcO1"
        oRequest.Body = oRequest.Body + "RPUDo4cHhcO2xlZnQ6MjQycHhcO1RvcDoxMDBweFw7Oz4%2BPj"
        oRequest.Body = oRequest.Body + "tsPGk8Mz47aTw1PjtpPDM5Pjs%2BO2w8dDxwPHA8bDxDaGVja2"
        oRequest.Body = oRequest.Body + "VkOz47bDxvPHQ%2BOz4%2BOz47Oz47dDxwPHA8bDxHcm91cE5h"
        oRequest.Body = oRequest.Body + "bWU7Q2hlY2tlZDs%2BO2w8cmJQcmludGVyO288Zj47Pj47Pjs7"
        oRequest.Body = oRequest.Body + "Pjt0PHA8cDxsPFZpc2libGU7PjtsPG88Zj47Pj47Pjs7Pjs%2B"
        oRequest.Body = oRequest.Body + "Pjt0PHA8cDxsPFZpc2libGU7PjtsPG88Zj47Pj47Pjs7Pjt0PH"
        oRequest.Body = oRequest.Body + "A8cDxsPFZpc2libGU7PjtsPG88Zj47Pj47Pjs7Pjs%2BPjs%2B"
        oRequest.Body = oRequest.Body + "PjtsPHJiVGVybWluYWw7cmJQcmludGVyO3JiUHJpbnRlcjtyYk"
        oRequest.Body = oRequest.Body + "hvc3RQb29saW5nO3JiSG9zdFBvb2xpbmc7cmJBZ2VuY3lQb29s"
        oRequest.Body = oRequest.Body + "aW5nO3JiQWdlbmN5UG9vbGluZzs%2BPgjE1fHo%2FJwXZGIubX"
        oRequest.Body = oRequest.Body + "9Yvb2mJaKc&DevType=rbTerminal&txtboxLNIATA=abc123&"
        oRequest.Body = oRequest.Body + "txtboxBCC=&txtboxHostPoolName=&txtboxBranchPCC=&tx"
        oRequest.Body = oRequest.Body + "tboxProfileKey=&txtboxCityCode=&txtboxPartition=&p"
        oRequest.Body = oRequest.Body + "nlbasicbtnNext=Next%3E%3E"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/HSSPRoute.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest17()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (78)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/HsspRoute.aspx"+"?ROUTENAME=SABRE"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/HSSPRoute.aspx?ROUTENAME=SABRE"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/HsspRoute.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest18()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (1719)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/HsspRoute.aspx"+"?ROUTENAME=SABRE"
        oRequest.Verb = "POST"
        oRequest.HTTPVersion = "HTTP/1.0"
        oRequest.EncodeBody = False
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/HsspRoute.aspx?ROUTENAME=SABRE"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "Content-Type", "application/x-www-form-urlencoded"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__VIEWSTATE=dDwtMTM3ODM2NDA5Nzt0PDtsPGk8MT47PjtsPH"
        oRequest.Body = oRequest.Body + "Q8O2w8aTwzPjtpPDc%2BO2k8OT47PjtsPHQ8cDxwPGw8VmlzaW"
        oRequest.Body = oRequest.Body + "JsZTs%2BO2w8bzxmPjs%2BPjs%2BOzs%2BO3Q8cDw7cDxsPHN0"
        oRequest.Body = oRequest.Body + "eWxlOz47bDxaLUlOREVYOjEwMlw7TEVGVDoxMTJweFw7UE9TSV"
        oRequest.Body = oRequest.Body + "RJT046YWJzb2x1dGVcO1RPUDo1NTZweFw7bGVmdDoyNDJweFw7"
        oRequest.Body = oRequest.Body + "VG9wOjEwMHB4XDs7Pj4%2BO2w8aTwxMT47PjtsPHQ8cDxwPGw8"
        oRequest.Body = oRequest.Body + "VmlzaWJsZTs%2BO2w8bzxmPjs%2BPjs%2BOzs%2BOz4%2BO3Q8"
        oRequest.Body = oRequest.Body + "cDxwPGw8VmlzaWJsZTs%2BO2w8bzxmPjs%2BPjs%2BOzs%2BOz"
        oRequest.Body = oRequest.Body + "4%2BOz4%2BO2w8Y2tib3hTZWdPdmVycmlkZTtja2JveFNlc3Np"
        oRequest.Body = oRequest.Body + "b25QZXJzaXN0ZW50O2NrYm94TERBUDs%2BPoHQ3zlMgjFqhbQk"
        oRequest.Body = oRequest.Body + "8OMLJH6IbkuZ&txtboxDefaultHost=RES.SABRE.COM&btnNe"
        oRequest.Body = oRequest.Body + "tworkNext=Next%3E%3E"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/HsspRoute.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest19()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (62)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/HsspRoute.aspx"+"?ROUTENAME=SABRE"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/HsspRoute.aspx?ROUTENAME=SABRE"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/HsspRoute.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest20()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (2235)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/HsspRoute.aspx"+"?ROUTENAME=SABRE"
        oRequest.Verb = "POST"
        oRequest.HTTPVersion = "HTTP/1.0"
        oRequest.EncodeBody = False
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/HsspRoute.aspx?ROUTENAME=SABRE"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "Content-Type", "application/x-www-form-urlencoded"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__VIEWSTATE=dDwtMTM3ODM2NDA5Nzt0PDtsPGk8MT47PjtsPH"
        oRequest.Body = oRequest.Body + "Q8O2w8aTwzPjtpPDc%2BO2k8OT47PjtsPHQ8cDxwPGw8VmlzaW"
        oRequest.Body = oRequest.Body + "JsZTs%2BO2w8bzxmPjs%2BPjs%2BOzs%2BO3Q8cDxwPGw8Vmlz"
        oRequest.Body = oRequest.Body + "aWJsZTs%2BO2w8bzxmPjs%2BPjs%2BOzs%2BO3Q8cDw7cDxsPH"
        oRequest.Body = oRequest.Body + "N0eWxlOz47bDxaLUlOREVYOjEwM1w7TEVGVDoxMTJweFw7UE9T"
        oRequest.Body = oRequest.Body + "SVRJT046YWJzb2x1dGVcO1RPUDo4NDBweFw7bGVmdDoyNDJweF"
        oRequest.Body = oRequest.Body + "w7VG9wOjEwMHB4XDs7Pj4%2BOzs%2BOz4%2BOz4%2BO2w8Y2ti"
        oRequest.Body = oRequest.Body + "b3hUcmFjaW5nO2NrYm94T3B0N1RyYWNpbmc7Y2tib3hFMkVUcm"
        oRequest.Body = oRequest.Body + "FjaW5nOz4%2BWh539D%2Fu5BoHE5C1E%2BJxV5VnN7M%3D&txt"
        oRequest.Body = oRequest.Body + "boxLogFileSize=1000&txtboxLogFilePath=C%3A%5CDocum"
        oRequest.Body = oRequest.Body + "ents+and+Settings%5CAll+Users%5CApplication+Data%5"
        oRequest.Body = oRequest.Body + "CCommonHostFiles%5CHSSP.LOG&btnpnlDebugOK=OK"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/HsspRoute.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest21()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (172)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/ConfigureRoute.aspx"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/HsspRoute.aspx?ROUTENAME=SABRE"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/ConfigureRoute.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest22()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (359)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/Images/NET04.ico"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "*/*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/ConfigureRoute.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/Images/NET04.ico"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest23()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (3516)
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
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/ConfigureRoute.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
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

Sub SendRequest24()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (93)
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
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/ConfigureRoute.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=xw2z0w451smfyqmuokv024i1"
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
    call SendRequest17()
    call SendRequest18()
    call SendRequest19()
    call SendRequest20()
    call SendRequest21()
    call SendRequest22()
    call SendRequest23()
    call SendRequest24()
End Sub
Main
