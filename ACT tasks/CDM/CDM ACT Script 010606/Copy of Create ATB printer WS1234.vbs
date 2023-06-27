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
    If fEnableDelays = True then Test.Sleep (63)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=srz5jt55jbs2tm2vwtewae45"
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
    If fEnableDelays = True then Test.Sleep (62)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=srz5jt55jbs2tm2vwtewae45"
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
    If fEnableDelays = True then Test.Sleep (94)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=srz5jt55jbs2tm2vwtewae45"
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
    If fEnableDelays = True then Test.Sleep (4015)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=srz5jt55jbs2tm2vwtewae45"
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
    If fEnableDelays = True then Test.Sleep (47)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=srz5jt55jbs2tm2vwtewae45"
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
    If fEnableDelays = True then Test.Sleep (63)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=srz5jt55jbs2tm2vwtewae45"
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
    If fEnableDelays = True then Test.Sleep (1375)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=srz5jt55jbs2tm2vwtewae45"
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
    If fEnableDelays = True then Test.Sleep (3859)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=srz5jt55jbs2tm2vwtewae45"
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
        oRequest.Body = oRequest.Body + "8CZwagdCR3xl72PFy0rqA2wEHv&txtboxWSName=ws1234&btn"
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

Sub SendRequest10()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (4235)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/ConfigurePtr.aspx"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/WSSelect.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=srz5jt55jbs2tm2vwtewae45"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/ConfigurePtr.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest11()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (7937)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/ConfigurePtr.aspx"
        oRequest.Verb = "POST"
        oRequest.HTTPVersion = "HTTP/1.0"
        oRequest.EncodeBody = False
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/ConfigurePtr.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "Content-Type", "application/x-www-form-urlencoded"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=srz5jt55jbs2tm2vwtewae45"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=dDw4NT"
        oRequest.Body = oRequest.Body + "g4NzA3NTQ7dDw7bDxpPDE%2BOz47bDx0PDtsPGk8Nz47aTw5Pj"
        oRequest.Body = oRequest.Body + "tpPDEzPjs%2BO2w8dDx0PDtwPGw8aTwwPjtpPDE%2BO2k8Mj47"
        oRequest.Body = oRequest.Body + "aTwzPjtpPDQ%2BOz47bDxwPEFFQUxpdGVEcnYuZGxsO0FFQUxp"
        oRequest.Body = oRequest.Body + "dGVEcnYuZGxsPjtwPEFUQjJEcnYuZGxsO0FUQjJEcnYuZGxsPj"
        oRequest.Body = oRequest.Body + "twPEZpbGVEcnYuZGxsO0ZpbGVEcnYuZGxsPjtwPFByaW50RHJ2"
        oRequest.Body = oRequest.Body + "LmRsbDtQcmludERydi5kbGw%2BO3A8U3lzUHRyRHJ2LmRsbDtT"
        oRequest.Body = oRequest.Body + "eXNQdHJEcnYuZGxsPjs%2BPjtsPGk8MD47Pj47Oz47dDxwPHA8"
        oRequest.Body = oRequest.Body + "bDxUZXh0Oz47bDxcZTs%2BPjtwPGw8b25LZXlVcDs%2BO2w8RG"
        oRequest.Body = oRequest.Body + "9LZXlVcCgpOz4%2BPjs7Pjt0PHQ8O3Q8aTwxPjtAPE5ldyBEZX"
        oRequest.Body = oRequest.Body + "ZpY2U7PjtAPE5ldyBEZXZpY2U7Pj47bDxpPDA%2BOz4%2BOzs%"
        oRequest.Body = oRequest.Body + "2BOz4%2BOz4%2BOz56RbCqqhOGNF4YBPTCe%2FDYAx%2FnEA%3"
        oRequest.Body = oRequest.Body + "D%3D&ddlDrivers=AEALiteDrv.dll&TextBoxDeviecName=A"
        oRequest.Body = oRequest.Body + "TB&buttonNext=Next+%3E%3E&ddlDeviceNames=New+Devic"
        oRequest.Body = oRequest.Body + "e"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/ConfigurePtr.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest12()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (47)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/ConfigPtrAEALiteDrv.aspx"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/ConfigurePtr.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=srz5jt55jbs2tm2vwtewae45"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/ConfigPtrAEALiteDrv.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest13()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (109)
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
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/ConfigPtrAEALiteDrv.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=srz5jt55jbs2tm2vwtewae45"
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

Sub SendRequest14()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (2500)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/ConfigPtrAEALiteDrv.aspx"
        oRequest.Verb = "POST"
        oRequest.HTTPVersion = "HTTP/1.0"
        oRequest.EncodeBody = False
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/ConfigPtrAEALiteDrv.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "Content-Type", "application/x-www-form-urlencoded"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=srz5jt55jbs2tm2vwtewae45"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=dDwtMz"
        oRequest.Body = oRequest.Body + "M3NzQ2OTA4O3Q8O2w8aTwxPjs%2BO2w8dDw7bDxpPDE%2BO2k8"
        oRequest.Body = oRequest.Body + "OD47aTwxMD47aTwxMj47aTwxND47aTwyMD47aTwyMj47aTwyMz"
        oRequest.Body = oRequest.Body + "47aTwyND47PjtsPHQ8cDxwPGw8VGV4dDs%2BO2w8QUVBTGl0ZU"
        oRequest.Body = oRequest.Body + "Rydi5kbGwgQ29uZmlndXJhdGlvbjs%2BPjs%2BOzs%2BO3Q8cD"
        oRequest.Body = oRequest.Body + "xwPGw8Q2hlY2tlZDtHcm91cE5hbWU7PjtsPG88dD47cmJEZWJ1"
        oRequest.Body = oRequest.Body + "Z0Rpc2FibGVkOz4%2BOz47Oz47dDxwPHA8bDxDaGVja2VkO0dy"
        oRequest.Body = oRequest.Body + "b3VwTmFtZTs%2BO2w8bzxmPjtyYkxvZ1RvRmlsZTs%2BPjs%2B"
        oRequest.Body = oRequest.Body + "Ozs%2BO3Q8cDxwPGw8Q2hlY2tlZDtHcm91cE5hbWU7PjtsPG88"
        oRequest.Body = oRequest.Body + "Zj47cmJEZWJ1Z1dpbmRvd0VuYWJsZWQ7Pj47Pjs7Pjt0PHA8cD"
        oRequest.Body = oRequest.Body + "xsPENoZWNrZWQ7R3JvdXBOYW1lOz47bDxvPGY%2BO3JiRGVidW"
        oRequest.Body = oRequest.Body + "dGaWxlQW5kV2luZG93RW5hYmxlZDs%2BPjs%2BOzs%2BO3Q8cD"
        oRequest.Body = oRequest.Body + "xwPGw8VGV4dDs%2BO2w8MTAwMDAwOz4%2BO3A8bDxvbktleVVw"
        oRequest.Body = oRequest.Body + "Oz47bDxMaW1pdFRvTnVtZXJpYyhGb3JtMS50ZXh0Qm94TWF4Rm"
        oRequest.Body = oRequest.Body + "lsZVNpemUpOz4%2BPjs7Pjt0PDtsPGk8MT47PjtsPHQ8dDw7cD"
        oRequest.Body = oRequest.Body + "xsPGk8MD47PjtsPFBPUlRTLkRMTDs%2BPjs%2BOzs%2BOz4%2B"
        oRequest.Body = oRequest.Body + "O3Q8O2w8aTwxPjtpPDM%2BO2k8NT47PjtsPHQ8cDxwPGw8VGV4"
        oRequest.Body = oRequest.Body + "dDs%2BO2w8QVRCOz4%2BOz47Oz47dDxwPHA8bDxDaGVja2VkO0"
        oRequest.Body = oRequest.Body + "dyb3VwTmFtZTs%2BO2w8bzx0PjtyYkVuYWJsZWQ7Pj47Pjs7Pj"
        oRequest.Body = oRequest.Body + "t0PHA8cDxsPENoZWNrZWQ7R3JvdXBOYW1lOz47bDxvPGY%2BO3"
        oRequest.Body = oRequest.Body + "JiRGlzYWJsZWQ7Pj47Pjs7Pjs%2BPjt0PDtsPGk8MT47aTwzPj"
        oRequest.Body = oRequest.Body + "tpPDU%2BO2k8Nz47PjtsPHQ8cDw7cDxsPG9uS2V5VXA7PjtsPE"
        oRequest.Body = oRequest.Body + "xpbWl0VG9OdW1lcmljKEZvcm0xLnRleHRib3hOb09mRkYpOz4%"
        oRequest.Body = oRequest.Body + "2BPjs7Pjt0PDtsPGk8NT47PjtsPHQ8dDw7O2w8aTwwPjs%2BPj"
        oRequest.Body = oRequest.Body + "s7Pjs%2BPjt0PHA8cDxsPENoZWNrZWQ7PjtsPG88dD47Pj47Pj"
        oRequest.Body = oRequest.Body + "s7Pjt0PHA8cDxsPENoZWNrZWQ7PjtsPG88Zj47Pj47Pjs7Pjs%"
        oRequest.Body = oRequest.Body + "2BPjs%2BPjs%2BPjtsPHJiRGVidWdEaXNhYmxlZDtyYkxvZ1Rv"
        oRequest.Body = oRequest.Body + "RmlsZTtyYkxvZ1RvRmlsZTtyYkRlYnVnV2luZG93RW5hYmxlZD"
        oRequest.Body = oRequest.Body + "tyYkRlYnVnV2luZG93RW5hYmxlZDtyYkRlYnVnRmlsZUFuZFdp"
        oRequest.Body = oRequest.Body + "bmRvd0VuYWJsZWQ7cmJEZWJ1Z0ZpbGVBbmRXaW5kb3dFbmFibG"
        oRequest.Body = oRequest.Body + "VkO2NiRG9wUFBDQ1RDO3JiRW5hYmxlZDtyYkRpc2FibGVkO3Ji"
        oRequest.Body = oRequest.Body + "RGlzYWJsZWQ7Y2JJbnNlcnRMRkFmdGVyQ1I7Pj503kgM1mDtr7"
        oRequest.Body = oRequest.Body + "koixPbRUbsaHs23Q%3D%3D&rbDebugDisabled=rbDebugDisa"
        oRequest.Body = oRequest.Body + "bled&textBoxLogFileName=C%3A%5CDocuments+and+Setti"
        oRequest.Body = oRequest.Body + "ngs%5CAll+Users%5CApplication+Data%5CCommonHostFil"
        oRequest.Body = oRequest.Body + "es%5CCSAPI.LOG&textBoxMaxFileSize=100000&ddlIoDriv"
        oRequest.Body = oRequest.Body + "er=PORTS.DLL&cbDopPPCCTC=on&rbEnabled=rbEnabled&te"
        oRequest.Body = oRequest.Body + "xtboxNoOfFF=1&ComPortCtrl1%3AddlPort=COM1&ComPortC"
        oRequest.Body = oRequest.Body + "trl1%3AddlBaudRate=9600&ComPortCtrl1%3AddlDataBits"
        oRequest.Body = oRequest.Body + "=8&ComPortCtrl1%3AddlParityBits=3&ComPortCtrl1%3Ad"
        oRequest.Body = oRequest.Body + "dlStopBits=1&ComPortCtrl1%3AddlFlowControl=1&cbIns"
        oRequest.Body = oRequest.Body + "ertLFAfterCR=on&buttonSave=Save"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/ConfigPtrAEALiteDrv.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest15()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (94)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/ConfigurePtr.aspx"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/ConfigPtrAEALiteDrv.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        oHeaders.Add "Pragma", "no-cache"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=srz5jt55jbs2tm2vwtewae45"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/ConfigurePtr.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest16()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (4922)
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
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/ConfigurePtr.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=srz5jt55jbs2tm2vwtewae45"
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

Sub SendRequest17()
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
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/ConfigurePtr.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "UA-CPU", "x86"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=srz5jt55jbs2tm2vwtewae45"
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
End Sub
Main
