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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=azouag45ctkgsab3gb0lna45"
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
    If fEnableDelays = True then Test.Sleep (47)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=azouag45ctkgsab3gb0lna45"
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
    If fEnableDelays = True then Test.Sleep (62)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=azouag45ctkgsab3gb0lna45"
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
    If fEnableDelays = True then Test.Sleep (4828)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=azouag45ctkgsab3gb0lna45"
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
    If fEnableDelays = True then Test.Sleep (32)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=azouag45ctkgsab3gb0lna45"
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
    If fEnableDelays = True then Test.Sleep (93)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=azouag45ctkgsab3gb0lna45"
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
    If fEnableDelays = True then Test.Sleep (1469)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=azouag45ctkgsab3gb0lna45"
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
    If fEnableDelays = True then Test.Sleep (5063)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=azouag45ctkgsab3gb0lna45"
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

Sub SendRequest10()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (13421)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=azouag45ctkgsab3gb0lna45"
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
    If fEnableDelays = True then Test.Sleep (3547)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=azouag45ctkgsab3gb0lna45"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__EVENTTARGET=ddlDrivers&__EVENTARGUMENT=&__VIEWST"
        oRequest.Body = oRequest.Body + "ATE=dDw4NTg4NzA3NTQ7dDw7bDxpPDE%2BOz47bDx0PDtsPGk8"
        oRequest.Body = oRequest.Body + "Nz47aTw5PjtpPDEzPjs%2BO2w8dDx0PDtwPGw8aTwwPjtpPDE%"
        oRequest.Body = oRequest.Body + "2BO2k8Mj47aTwzPjtpPDQ%2BOz47bDxwPEFFQUxpdGVEcnYuZG"
        oRequest.Body = oRequest.Body + "xsO0FFQUxpdGVEcnYuZGxsPjtwPEFUQjJEcnYuZGxsO0FUQjJE"
        oRequest.Body = oRequest.Body + "cnYuZGxsPjtwPEZpbGVEcnYuZGxsO0ZpbGVEcnYuZGxsPjtwPF"
        oRequest.Body = oRequest.Body + "ByaW50RHJ2LmRsbDtQcmludERydi5kbGw%2BO3A8U3lzUHRyRH"
        oRequest.Body = oRequest.Body + "J2LmRsbDtTeXNQdHJEcnYuZGxsPjs%2BPjtsPGk8MD47Pj47Oz"
        oRequest.Body = oRequest.Body + "47dDxwPHA8bDxUZXh0Oz47bDxcZTs%2BPjtwPGw8b25LZXlVcD"
        oRequest.Body = oRequest.Body + "s%2BO2w8RG9LZXlVcCgpOz4%2BPjs7Pjt0PHQ8O3Q8aTwxPjtA"
        oRequest.Body = oRequest.Body + "PE5ldyBEZXZpY2U7PjtAPE5ldyBEZXZpY2U7Pj47bDxpPDA%2B"
        oRequest.Body = oRequest.Body + "Oz4%2BOzs%2BOz4%2BOz4%2BOz56RbCqqhOGNF4YBPTCe%2FDY"
        oRequest.Body = oRequest.Body + "Ax%2FnEA%3D%3D&ddlDrivers=PrintDrv.dll&TextBoxDevi"
        oRequest.Body = oRequest.Body + "ecName=&ddlDeviceNames=New+Device"
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
    If fEnableDelays = True then Test.Sleep (5657)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=azouag45ctkgsab3gb0lna45"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=dDw4NT"
        oRequest.Body = oRequest.Body + "g4NzA3NTQ7dDw7bDxpPDE%2BOz47bDx0PDtsPGk8Nz47aTw5Pj"
        oRequest.Body = oRequest.Body + "tpPDEzPjs%2BO2w8dDx0PDtwPGw8aTwwPjtpPDE%2BO2k8Mj47"
        oRequest.Body = oRequest.Body + "aTwzPjtpPDQ%2BOz47bDxwPEFFQUxpdGVEcnYuZGxsO0FFQUxp"
        oRequest.Body = oRequest.Body + "dGVEcnYuZGxsPjtwPEFUQjJEcnYuZGxsO0FUQjJEcnYuZGxsPj"
        oRequest.Body = oRequest.Body + "twPEZpbGVEcnYuZGxsO0ZpbGVEcnYuZGxsPjtwPFByaW50RHJ2"
        oRequest.Body = oRequest.Body + "LmRsbDtQcmludERydi5kbGw%2BO3A8U3lzUHRyRHJ2LmRsbDtT"
        oRequest.Body = oRequest.Body + "eXNQdHJEcnYuZGxsPjs%2BPjtsPGk8Mz47Pj47Oz47dDxwPHA8"
        oRequest.Body = oRequest.Body + "bDxUZXh0Oz47bDxcZTs%2BPjtwPGw8b25LZXlVcDs%2BO2w8RG"
        oRequest.Body = oRequest.Body + "9LZXlVcCgpOz4%2BPjs7Pjt0PHQ8O3Q8aTwxPjtAPE5ldyBEZX"
        oRequest.Body = oRequest.Body + "ZpY2U7PjtAPE5ldyBEZXZpY2U7Pj47bDxpPDA%2BOz4%2BOzs%"
        oRequest.Body = oRequest.Body + "2BOz4%2BOz4%2BOz6cKN6%2FZW%2F%2FGvGHHqDvI2ePgC43%2"
        oRequest.Body = oRequest.Body + "FQ%3D%3D&ddlDrivers=PrintDrv.dll&TextBoxDeviecName"
        oRequest.Body = oRequest.Body + "=PTR&buttonNext=Next+%3E%3E&ddlDeviceNames=New+Dev"
        oRequest.Body = oRequest.Body + "ice"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/ConfigurePtr.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest13()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (46)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=azouag45ctkgsab3gb0lna45"
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

Sub SendRequest14()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (1641)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=azouag45ctkgsab3gb0lna45"
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

Sub SendRequest15()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (4625)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=azouag45ctkgsab3gb0lna45"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__EVENTTARGET=ComPortCtrl1%3AddlPort&__EVENTARGUME"
        oRequest.Body = oRequest.Body + "NT=&__VIEWSTATE=dDwtMzM3NzQ2OTA4O3Q8O2w8aTwxPjs%2B"
        oRequest.Body = oRequest.Body + "O2w8dDw7bDxpPDE%2BO2k8OD47aTwxMD47aTwxMj47aTwxND47"
        oRequest.Body = oRequest.Body + "aTwyMD47aTwyMj47aTwyMz47aTwyND47PjtsPHQ8cDxwPGw8VG"
        oRequest.Body = oRequest.Body + "V4dDs%2BO2w8UHJpbnREcnYuZGxsIENvbmZpZ3VyYXRpb247Pj"
        oRequest.Body = oRequest.Body + "47Pjs7Pjt0PHA8cDxsPENoZWNrZWQ7R3JvdXBOYW1lOz47bDxv"
        oRequest.Body = oRequest.Body + "PHQ%2BO3JiRGVidWdEaXNhYmxlZDs%2BPjs%2BOzs%2BO3Q8cD"
        oRequest.Body = oRequest.Body + "xwPGw8Q2hlY2tlZDtHcm91cE5hbWU7PjtsPG88Zj47cmJMb2dU"
        oRequest.Body = oRequest.Body + "b0ZpbGU7Pj47Pjs7Pjt0PHA8cDxsPENoZWNrZWQ7R3JvdXBOYW"
        oRequest.Body = oRequest.Body + "1lOz47bDxvPGY%2BO3JiRGVidWdXaW5kb3dFbmFibGVkOz4%2B"
        oRequest.Body = oRequest.Body + "Oz47Oz47dDxwPHA8bDxDaGVja2VkO0dyb3VwTmFtZTs%2BO2w8"
        oRequest.Body = oRequest.Body + "bzxmPjtyYkRlYnVnRmlsZUFuZFdpbmRvd0VuYWJsZWQ7Pj47Pj"
        oRequest.Body = oRequest.Body + "s7Pjt0PHA8cDxsPFRleHQ7PjtsPDEwMDAwMDs%2BPjtwPGw8b2"
        oRequest.Body = oRequest.Body + "5LZXlVcDs%2BO2w8TGltaXRUb051bWVyaWMoRm9ybTEudGV4dE"
        oRequest.Body = oRequest.Body + "JveE1heEZpbGVTaXplKTs%2BPj47Oz47dDw7bDxpPDE%2BO2k8"
        oRequest.Body = oRequest.Body + "Mz47PjtsPHQ8dDw7cDxsPGk8MD47PjtsPFBPUlRTLkRMTDs%2B"
        oRequest.Body = oRequest.Body + "Pjs%2BOzs%2BO3Q8cDxwPGw8Q2hlY2tlZDtFbmFibGVkOz47bD"
        oRequest.Body = oRequest.Body + "xvPHQ%2BO288Zj47Pj47Pjs7Pjs%2BPjt0PDtsPGk8MT47aTwz"
        oRequest.Body = oRequest.Body + "PjtpPDU%2BOz47bDx0PHA8cDxsPFRleHQ7PjtsPFBUUjs%2BPj"
        oRequest.Body = oRequest.Body + "s%2BOzs%2BO3Q8cDxwPGw8Q2hlY2tlZDtHcm91cE5hbWU7Pjts"
        oRequest.Body = oRequest.Body + "PG88dD47cmJFbmFibGVkOz4%2BOz47Oz47dDxwPHA8bDxDaGVj"
        oRequest.Body = oRequest.Body + "a2VkO0dyb3VwTmFtZTs%2BO2w8bzxmPjtyYkRpc2FibGVkOz4%"
        oRequest.Body = oRequest.Body + "2BOz47Oz47Pj47dDw7bDxpPDE%2BO2k8Mz47aTw1PjtpPDc%2B"
        oRequest.Body = oRequest.Body + "Oz47bDx0PHA8O3A8bDxvbktleVVwOz47bDxMaW1pdFRvTnVtZX"
        oRequest.Body = oRequest.Body + "JpYyhGb3JtMS50ZXh0Ym94Tm9PZkZGKTs%2BPj47Oz47dDw7bD"
        oRequest.Body = oRequest.Body + "xpPDU%2BOz47bDx0PHQ8OztsPGk8MD47Pj47Oz47Pj47dDxwPH"
        oRequest.Body = oRequest.Body + "A8bDxDaGVja2VkOz47bDxvPHQ%2BOz4%2BOz47Oz47dDxwPHA8"
        oRequest.Body = oRequest.Body + "bDxDaGVja2VkOz47bDxvPGY%2BOz4%2BOz47Oz47Pj47Pj47Pj"
        oRequest.Body = oRequest.Body + "47bDxyYkRlYnVnRGlzYWJsZWQ7cmJMb2dUb0ZpbGU7cmJMb2dU"
        oRequest.Body = oRequest.Body + "b0ZpbGU7cmJEZWJ1Z1dpbmRvd0VuYWJsZWQ7cmJEZWJ1Z1dpbm"
        oRequest.Body = oRequest.Body + "Rvd0VuYWJsZWQ7cmJEZWJ1Z0ZpbGVBbmRXaW5kb3dFbmFibGVk"
        oRequest.Body = oRequest.Body + "O3JiRGVidWdGaWxlQW5kV2luZG93RW5hYmxlZDtyYkVuYWJsZW"
        oRequest.Body = oRequest.Body + "Q7cmJEaXNhYmxlZDtyYkRpc2FibGVkO2NiSW5zZXJ0TEZBZnRl"
        oRequest.Body = oRequest.Body + "ckNSOz4%2B%2F8gBB2DfoxJ7eWKQHxZ29Kjy1Mk%3D&rbDebug"
        oRequest.Body = oRequest.Body + "Disabled=rbDebugDisabled&textBoxLogFileName=C%3A%5"
        oRequest.Body = oRequest.Body + "CDocuments+and+Settings%5CAll+Users%5CApplication+"
        oRequest.Body = oRequest.Body + "Data%5CCommonHostFiles%5CCSAPI.LOG&textBoxMaxFileS"
        oRequest.Body = oRequest.Body + "ize=100000&ddlIoDriver=PORTS.DLL&rbEnabled=rbEnabl"
        oRequest.Body = oRequest.Body + "ed&textboxNoOfFF=1&ComPortCtrl1%3AddlPort=LPT1&Com"
        oRequest.Body = oRequest.Body + "PortCtrl1%3AddlBaudRate=4800&ComPortCtrl1%3AddlDat"
        oRequest.Body = oRequest.Body + "aBits=7&ComPortCtrl1%3AddlParityBits=0&ComPortCtrl"
        oRequest.Body = oRequest.Body + "1%3AddlStopBits=1&ComPortCtrl1%3AddlFlowControl=1&"
        oRequest.Body = oRequest.Body + "cbInsertLFAfterCR=on"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/ConfigPtrAEALiteDrv.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest16()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (2516)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=azouag45ctkgsab3gb0lna45"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=dDwtMz"
        oRequest.Body = oRequest.Body + "M3NzQ2OTA4O3Q8O2w8aTwxPjs%2BO2w8dDw7bDxpPDE%2BO2k8"
        oRequest.Body = oRequest.Body + "OD47aTwxMD47aTwxMj47aTwxND47aTwyMD47aTwyMj47aTwyMz"
        oRequest.Body = oRequest.Body + "47aTwyND47PjtsPHQ8cDxwPGw8VGV4dDs%2BO2w8UHJpbnREcn"
        oRequest.Body = oRequest.Body + "YuZGxsIENvbmZpZ3VyYXRpb247Pj47Pjs7Pjt0PHA8cDxsPENo"
        oRequest.Body = oRequest.Body + "ZWNrZWQ7R3JvdXBOYW1lOz47bDxvPHQ%2BO3JiRGVidWdEaXNh"
        oRequest.Body = oRequest.Body + "YmxlZDs%2BPjs%2BOzs%2BO3Q8cDxwPGw8Q2hlY2tlZDtHcm91"
        oRequest.Body = oRequest.Body + "cE5hbWU7PjtsPG88Zj47cmJMb2dUb0ZpbGU7Pj47Pjs7Pjt0PH"
        oRequest.Body = oRequest.Body + "A8cDxsPENoZWNrZWQ7R3JvdXBOYW1lOz47bDxvPGY%2BO3JiRG"
        oRequest.Body = oRequest.Body + "VidWdXaW5kb3dFbmFibGVkOz4%2BOz47Oz47dDxwPHA8bDxDaG"
        oRequest.Body = oRequest.Body + "Vja2VkO0dyb3VwTmFtZTs%2BO2w8bzxmPjtyYkRlYnVnRmlsZU"
        oRequest.Body = oRequest.Body + "FuZFdpbmRvd0VuYWJsZWQ7Pj47Pjs7Pjt0PHA8cDxsPFRleHQ7"
        oRequest.Body = oRequest.Body + "PjtsPDEwMDAwMDs%2BPjtwPGw8b25LZXlVcDs%2BO2w8TGltaX"
        oRequest.Body = oRequest.Body + "RUb051bWVyaWMoRm9ybTEudGV4dEJveE1heEZpbGVTaXplKTs%"
        oRequest.Body = oRequest.Body + "2BPj47Oz47dDw7bDxpPDE%2BO2k8Mz47PjtsPHQ8dDw7cDxsPG"
        oRequest.Body = oRequest.Body + "k8MD47PjtsPFBPUlRTLkRMTDs%2BPjs%2BOzs%2BO3Q8cDxwPG"
        oRequest.Body = oRequest.Body + "w8Q2hlY2tlZDtFbmFibGVkOz47bDxvPHQ%2BO288Zj47Pj47Pj"
        oRequest.Body = oRequest.Body + "s7Pjs%2BPjt0PDtsPGk8MT47aTwzPjtpPDU%2BOz47bDx0PHA8"
        oRequest.Body = oRequest.Body + "cDxsPFRleHQ7PjtsPFBUUjs%2BPjs%2BOzs%2BO3Q8cDxwPGw8"
        oRequest.Body = oRequest.Body + "Q2hlY2tlZDtHcm91cE5hbWU7PjtsPG88dD47cmJFbmFibGVkOz"
        oRequest.Body = oRequest.Body + "4%2BOz47Oz47dDxwPHA8bDxDaGVja2VkO0dyb3VwTmFtZTs%2B"
        oRequest.Body = oRequest.Body + "O2w8bzxmPjtyYkRpc2FibGVkOz4%2BOz47Oz47Pj47dDw7bDxp"
        oRequest.Body = oRequest.Body + "PDE%2BO2k8Mz47aTw1PjtpPDc%2BOz47bDx0PHA8O3A8bDxvbk"
        oRequest.Body = oRequest.Body + "tleVVwOz47bDxMaW1pdFRvTnVtZXJpYyhGb3JtMS50ZXh0Ym94"
        oRequest.Body = oRequest.Body + "Tm9PZkZGKTs%2BPj47Oz47dDw7bDxpPDU%2BO2k8OT47aTwxMz"
        oRequest.Body = oRequest.Body + "47aTwxNz47aTwyMT47aTwyNT47PjtsPHQ8dDw7O2w8aTw0Pjs%"
        oRequest.Body = oRequest.Body + "2BPjs7Pjt0PHQ8cDxwPGw8RW5hYmxlZDs%2BO2w8bzxmPjs%2B"
        oRequest.Body = oRequest.Body + "Pjs%2BOztsPGk8OD47Pj47Oz47dDx0PHA8cDxsPEVuYWJsZWQ7"
        oRequest.Body = oRequest.Body + "PjtsPG88Zj47Pj47Pjs7bDxpPDM%2BOz4%2BOzs%2BO3Q8dDxw"
        oRequest.Body = oRequest.Body + "PHA8bDxFbmFibGVkOz47bDxvPGY%2BOz4%2BOz47O2w8aTwwPj"
        oRequest.Body = oRequest.Body + "s%2BPjs7Pjt0PHQ8cDxwPGw8RW5hYmxlZDs%2BO2w8bzxmPjs%"
        oRequest.Body = oRequest.Body + "2BPjs%2BOztsPGk8MD47Pj47Oz47dDx0PHA8cDxsPEVuYWJsZW"
        oRequest.Body = oRequest.Body + "Q7PjtsPG88Zj47Pj47Pjs7bDxpPDE%2BOz4%2BOzs%2BOz4%2B"
        oRequest.Body = oRequest.Body + "O3Q8cDxwPGw8Q2hlY2tlZDs%2BO2w8bzx0Pjs%2BPjs%2BOzs%"
        oRequest.Body = oRequest.Body + "2BO3Q8cDxwPGw8Q2hlY2tlZDs%2BO2w8bzxmPjs%2BPjs%2BOz"
        oRequest.Body = oRequest.Body + "s%2BOz4%2BOz4%2BOz4%2BO2w8cmJEZWJ1Z0Rpc2FibGVkO3Ji"
        oRequest.Body = oRequest.Body + "TG9nVG9GaWxlO3JiTG9nVG9GaWxlO3JiRGVidWdXaW5kb3dFbm"
        oRequest.Body = oRequest.Body + "FibGVkO3JiRGVidWdXaW5kb3dFbmFibGVkO3JiRGVidWdGaWxl"
        oRequest.Body = oRequest.Body + "QW5kV2luZG93RW5hYmxlZDtyYkRlYnVnRmlsZUFuZFdpbmRvd0"
        oRequest.Body = oRequest.Body + "VuYWJsZWQ7cmJFbmFibGVkO3JiRGlzYWJsZWQ7cmJEaXNhYmxl"
        oRequest.Body = oRequest.Body + "ZDtjYkluc2VydExGQWZ0ZXJDUjs%2BPlm%2F%2BvgSUABq4%2F"
        oRequest.Body = oRequest.Body + "i4P%2FP9mcjM%2F%2Brk&rbDebugDisabled=rbDebugDisabl"
        oRequest.Body = oRequest.Body + "ed&textBoxLogFileName=C%3A%5CDocuments+and+Setting"
        oRequest.Body = oRequest.Body + "s%5CAll+Users%5CApplication+Data%5CCommonHostFiles"
        oRequest.Body = oRequest.Body + "%5CCSAPI.LOG&textBoxMaxFileSize=100000&ddlIoDriver"
        oRequest.Body = oRequest.Body + "=PORTS.DLL&rbEnabled=rbEnabled&textboxNoOfFF=1&Com"
        oRequest.Body = oRequest.Body + "PortCtrl1%3AddlPort=LPT1&cbInsertLFAfterCR=on&butt"
        oRequest.Body = oRequest.Body + "onSave=Save"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/ConfigPtrAEALiteDrv.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest17()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (109)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=azouag45ctkgsab3gb0lna45"
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

Sub SendRequest18()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (4328)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=azouag45ctkgsab3gb0lna45"
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

Sub SendRequest19()
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=azouag45ctkgsab3gb0lna45"
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
End Sub
Main
