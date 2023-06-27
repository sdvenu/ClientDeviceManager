Option Explicit
Dim fEnableDelays
fEnableDelays = False
Test.TraceLevel = -1
Dim strViewState

Sub SendRequest1()
	Dim Pos1, Pos2
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
			If InStr(oResponse.Body, "__VIEWSTATE") Then
        		Pos1 = InStr(InStr(oResponse.Body, "__VIEWSTATE"), oResponse.Body, "value=")
        		Pos2 = InStr(Pos1, oResponse.Body, ">")
        		strViewState = Mid(oResponse.Body, Pos1 + 7, Pos2 - Pos1 - 10)
        		strViewState = Replace(strViewState, "+", "%2B")
        		strViewState = Replace(strViewState, "=", "%3D")
      		End If
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest2()
	Dim Pos1, Pos2
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=2dakxxjgo4wadnjdx0hsuyfh"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/css/ClientDeviceMgr.css"
        Else
			If InStr(oResponse.Body, "__VIEWSTATE") Then
        		Pos1 = InStr(InStr(oResponse.Body, "__VIEWSTATE"), oResponse.Body, "value=")
        		Pos2 = InStr(Pos1, oResponse.Body, ">")
        		strViewState = Mid(oResponse.Body, Pos1 + 7, Pos2 - Pos1 - 10)
        		strViewState = Replace(strViewState, "+", "%2B")
        		strViewState = Replace(strViewState, "=", "%3D")
      		End If
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest3()
	Dim Pos1, Pos2
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=2dakxxjgo4wadnjdx0hsuyfh"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/aspnet_client/system_web/1_1_4322/WebUIValidation.js"
        Else
			If InStr(oResponse.Body, "__VIEWSTATE") Then
        		Pos1 = InStr(InStr(oResponse.Body, "__VIEWSTATE"), oResponse.Body, "value=")
        		Pos2 = InStr(Pos1, oResponse.Body, ">")
        		strViewState = Mid(oResponse.Body, Pos1 + 7, Pos2 - Pos1 - 10)
        		strViewState = Replace(strViewState, "+", "%2B")
        		strViewState = Replace(strViewState, "=", "%3D")
      		End If
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest4()
	Dim Pos1, Pos2
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (125)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=2dakxxjgo4wadnjdx0hsuyfh"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/images/edslogo.gif"
        Else
			If InStr(oResponse.Body, "__VIEWSTATE") Then
        		Pos1 = InStr(InStr(oResponse.Body, "__VIEWSTATE"), oResponse.Body, "value=")
        		Pos2 = InStr(Pos1, oResponse.Body, ">")
        		strViewState = Mid(oResponse.Body, Pos1 + 7, Pos2 - Pos1 - 10)
        		strViewState = Replace(strViewState, "+", "%2B")
        		strViewState = Replace(strViewState, "=", "%3D")
      		End If
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest5()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (4297)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=2dakxxjgo4wadnjdx0hsuyfh"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__VIEWSTATE=" & strViewState
        oRequest.Body = oRequest.Body + "&txtBoxUserID=a123&txtBoxPassword=123&btnLog"
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
	Dim Pos1, Pos2
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=2dakxxjgo4wadnjdx0hsuyfh"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/Welcome.aspx"
        Else
			If InStr(oResponse.Body, "__VIEWSTATE") Then
        		Pos1 = InStr(InStr(oResponse.Body, "__VIEWSTATE"), oResponse.Body, "value=")
        		Pos2 = InStr(Pos1, oResponse.Body, ">")
        		strViewState = Mid(oResponse.Body, Pos1 + 7, Pos2 - Pos1 - 10)
        		strViewState = Replace(strViewState, "+", "%2B")
        		strViewState = Replace(strViewState, "=", "%3D")
      		End If
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest7()
	Dim Pos1, Pos2
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=2dakxxjgo4wadnjdx0hsuyfh"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/images/line.gif"
        Else
			If InStr(oResponse.Body, "__VIEWSTATE") Then
        		Pos1 = InStr(InStr(oResponse.Body, "__VIEWSTATE"), oResponse.Body, "value=")
        		Pos2 = InStr(Pos1, oResponse.Body, ">")
        		strViewState = Mid(oResponse.Body, Pos1 + 7, Pos2 - Pos1 - 10)
        		strViewState = Replace(strViewState, "+", "%2B")
        		strViewState = Replace(strViewState, "=", "%3D")
      		End If
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest8()
	Dim Pos1, Pos2
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (1203)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=2dakxxjgo4wadnjdx0hsuyfh"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/WSSelect.aspx"
        Else
			If InStr(oResponse.Body, "__VIEWSTATE") Then
        		Pos1 = InStr(InStr(oResponse.Body, "__VIEWSTATE"), oResponse.Body, "value=")
        		Pos2 = InStr(Pos1, oResponse.Body, ">")
        		strViewState = Mid(oResponse.Body, Pos1 + 7, Pos2 - Pos1 - 10)
        		strViewState = Replace(strViewState, "+", "%2B")
        		strViewState = Replace(strViewState, "=", "%3D")
      		End If
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest9()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (4672)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=2dakxxjgo4wadnjdx0hsuyfh"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=" & strViewState
        oRequest.Body = oRequest.Body + "&txtboxWSName=WS1234&btn"
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
	Dim Pos1, Pos2
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (1765)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=2dakxxjgo4wadnjdx0hsuyfh"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/ConfigurePtr.aspx"
        Else
			If InStr(oResponse.Body, "__VIEWSTATE") Then
        		Pos1 = InStr(InStr(oResponse.Body, "__VIEWSTATE"), oResponse.Body, "value=")
        		Pos2 = InStr(Pos1, oResponse.Body, ">")
        		strViewState = Mid(oResponse.Body, Pos1 + 7, Pos2 - Pos1 - 10)
        		strViewState = Replace(strViewState, "+", "%2B")
        		strViewState = Replace(strViewState, "=", "%3D")
      		End If
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest11()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (6938)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=2dakxxjgo4wadnjdx0hsuyfh"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=" & strViewState
        oRequest.Body = oRequest.Body + "&ddlDrivers=AEALiteDrv.dll&TextBoxDeviecName=BAGTA"
        oRequest.Body = oRequest.Body + "G&buttonNext=Next+%3E%3E&ddlDeviceNames=New+Device"
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
	Dim Pos1, Pos2
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=2dakxxjgo4wadnjdx0hsuyfh"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/ConfigPtrAEALiteDrv.aspx"
        Else
			If InStr(oResponse.Body, "__VIEWSTATE") Then
        		Pos1 = InStr(InStr(oResponse.Body, "__VIEWSTATE"), oResponse.Body, "value=")
        		Pos2 = InStr(Pos1, oResponse.Body, ">")
        		strViewState = Mid(oResponse.Body, Pos1 + 7, Pos2 - Pos1 - 10)
        		strViewState = Replace(strViewState, "+", "%2B")
        		strViewState = Replace(strViewState, "=", "%3D")
      		End If
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest13()
	Dim Pos1, Pos2
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (94)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=2dakxxjgo4wadnjdx0hsuyfh"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/ClientDeviceMgr.js"
        Else
			If InStr(oResponse.Body, "__VIEWSTATE") Then
        		Pos1 = InStr(InStr(oResponse.Body, "__VIEWSTATE"), oResponse.Body, "value=")
        		Pos2 = InStr(Pos1, oResponse.Body, ">")
        		strViewState = Mid(oResponse.Body, Pos1 + 7, Pos2 - Pos1 - 10)
        		strViewState = Replace(strViewState, "+", "%2B")
        		strViewState = Replace(strViewState, "=", "%3D")
      		End If
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest14()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (2640)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=2dakxxjgo4wadnjdx0hsuyfh"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__EVENTTARGET=ComPortCtrl1%3AddlPort&__EVENTARGUME"
        oRequest.Body = oRequest.Body + "NT=&__VIEWSTATE=" & strViewState
        oRequest.Body = oRequest.Body + "&rbDebugDisabled=rbDebugDisabled&textBoxLogFileN"
        oRequest.Body = oRequest.Body + "ame=C%3A%5CDocuments+and+Settings%5CAll+Users%5CAp"
        oRequest.Body = oRequest.Body + "plication+Data%5CCommonHostFiles%5CCSAPI.LOG&textB"
        oRequest.Body = oRequest.Body + "oxMaxFileSize=100000&ddlIoDriver=PORTS.DLL&cbDopPP"
        oRequest.Body = oRequest.Body + "CCTC=on&rbEnabled=rbEnabled&textboxNoOfFF=1&ComPor"
        oRequest.Body = oRequest.Body + "tCtrl1%3AddlPort=COM2&ComPortCtrl1%3AddlBaudRate=9"
        oRequest.Body = oRequest.Body + "600&ComPortCtrl1%3AddlDataBits=8&ComPortCtrl1%3Add"
        oRequest.Body = oRequest.Body + "lParityBits=3&ComPortCtrl1%3AddlStopBits=1&ComPort"
        oRequest.Body = oRequest.Body + "Ctrl1%3AddlFlowControl=1&cbInsertLFAfterCR=on"
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
    If fEnableDelays = True then Test.Sleep (1547)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=2dakxxjgo4wadnjdx0hsuyfh"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=" & strViewState
        oRequest.Body = oRequest.Body + "&rbDebugDisabled=rbDebug"
        oRequest.Body = oRequest.Body + "Disabled&textBoxLogFileName=C%3A%5CDocuments+and+S"
        oRequest.Body = oRequest.Body + "ettings%5CAll+Users%5CApplication+Data%5CCommonHos"
        oRequest.Body = oRequest.Body + "tFiles%5CCSAPI.LOG&textBoxMaxFileSize=100000&ddlIo"
        oRequest.Body = oRequest.Body + "Driver=PORTS.DLL&cbDopPPCCTC=on&rbEnabled=rbEnable"
        oRequest.Body = oRequest.Body + "d&textboxNoOfFF=1&ComPortCtrl1%3AddlPort=COM2&ComP"
        oRequest.Body = oRequest.Body + "ortCtrl1%3AddlBaudRate=9600&ComPortCtrl1%3AddlData"
        oRequest.Body = oRequest.Body + "Bits=8&ComPortCtrl1%3AddlParityBits=3&ComPortCtrl1"
        oRequest.Body = oRequest.Body + "%3AddlStopBits=1&ComPortCtrl1%3AddlFlowControl=1&c"
        oRequest.Body = oRequest.Body + "bInsertLFAfterCR=on&buttonSave=Save"
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
	Dim Pos1, Pos2
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (78)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=2dakxxjgo4wadnjdx0hsuyfh"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/ConfigurePtr.aspx"
        Else
			If InStr(oResponse.Body, "__VIEWSTATE") Then
        		Pos1 = InStr(InStr(oResponse.Body, "__VIEWSTATE"), oResponse.Body, "value=")
        		Pos2 = InStr(Pos1, oResponse.Body, ">")
        		strViewState = Mid(oResponse.Body, Pos1 + 7, Pos2 - Pos1 - 10)
        		strViewState = Replace(strViewState, "+", "%2B")
        		strViewState = Replace(strViewState, "=", "%3D")
      		End If
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest17()
	Dim Pos1, Pos2
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (2453)
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=2dakxxjgo4wadnjdx0hsuyfh"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/LogOff.aspx"
        Else
			If InStr(oResponse.Body, "__VIEWSTATE") Then
        		Pos1 = InStr(InStr(oResponse.Body, "__VIEWSTATE"), oResponse.Body, "value=")
        		Pos2 = InStr(Pos1, oResponse.Body, ">")
        		strViewState = Mid(oResponse.Body, Pos1 + 7, Pos2 - Pos1 - 10)
        		strViewState = Replace(strViewState, "+", "%2B")
        		strViewState = Replace(strViewState, "=", "%3D")
      		End If
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest18()
	Dim Pos1, Pos2
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
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=2dakxxjgo4wadnjdx0hsuyfh"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/Login.aspx"
        Else
			If InStr(oResponse.Body, "__VIEWSTATE") Then
        		Pos1 = InStr(InStr(oResponse.Body, "__VIEWSTATE"), oResponse.Body, "value=")
        		Pos2 = InStr(Pos1, oResponse.Body, ">")
        		strViewState = Mid(oResponse.Body, Pos1 + 7, Pos2 - Pos1 - 10)
        		strViewState = Replace(strViewState, "+", "%2B")
        		strViewState = Replace(strViewState, "=", "%3D")
      		End If
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
End Sub
Main
