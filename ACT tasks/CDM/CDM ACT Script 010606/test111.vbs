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
        oRequest.Path = "/ClientDeviceMgr/Login.aspx"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322)"
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

Sub SendRequest2()
	Dim Pos1, Pos2
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (46)
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
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/Login.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=13omfviuc3bf4xyadhls10fa"
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
    If fEnableDelays = True then Test.Sleep (26)
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
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/Login.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=13omfviuc3bf4xyadhls10fa"
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
    If fEnableDelays = True then Test.Sleep (47)
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
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/Login.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=13omfviuc3bf4xyadhls10fa"
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
    If fEnableDelays = True then Test.Sleep (4541)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/Login.aspx"
        oRequest.Verb = "POST"
        oRequest.HTTPVersion = "HTTP/1.0"
        oRequest.EncodeBody = False
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/Login.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "Content-Type", "application/x-www-form-urlencoded"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Pragma", "no-cache"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=13omfviuc3bf4xyadhls10fa"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
		oRequest.Body = "__VIEWSTATE=" & strViewState
        oRequest.Body = oRequest.Body + "&txtBoxUserID=A468474&txtBoxPassword=dev1726&b"
        oRequest.Body = oRequest.Body + "tnLogin=Login"


'        oRequest.Body = "__VIEWSTATE=dDwtMjA0MzYwODQzO3Q8O2w8aTwxPjs%2BO2w8"
'        oRequest.Body = oRequest.Body + "dDw7bDxpPDQ%2BOz47bDx0PHA8cDxsPFRleHQ7PjtsPFVzZXIg"
'        oRequest.Body = oRequest.Body + "SUQ6Oz4%2BOz47Oz47Pj47Pj47PlsNzuYVXUnIu4JhTY1kLr3v"
'        oRequest.Body = oRequest.Body + "XOm4&txtBoxUserID=A468474&txtBoxPassword=dev1726&b"
'        oRequest.Body = oRequest.Body + "tnLogin=Login"

        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/Login.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest6()
	Dim Pos1, Pos2
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (20)
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
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/Login.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Pragma", "no-cache"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=13omfviuc3bf4xyadhls10fa"
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
    If fEnableDelays = True then Test.Sleep (39)
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
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=13omfviuc3bf4xyadhls10fa"
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
    If fEnableDelays = True then Test.Sleep (3763)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/AddWS.aspx"
        oRequest.Verb = "GET"
        oRequest.HTTPVersion = "HTTP/1.0"
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/Welcome.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=13omfviuc3bf4xyadhls10fa"
        oHeaders.Add "Cookie", "(automatic)"
        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/AddWS.aspx"
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
	Dim Pos1, Pos2
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (264)
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
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/AddWS.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=13omfviuc3bf4xyadhls10fa"
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

Sub SendRequest10()
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (7500)
    Set oConnection = Test.CreateConnection("profileserver", 80, false)
    If (oConnection is Nothing) Then
        Test.Trace "Error: Unable to create connection to profileserver"
    Else
        Set oRequest = Test.CreateRequest
        oRequest.Path = "/ClientDeviceMgr/AddWS.aspx"
        oRequest.Verb = "POST"
        oRequest.HTTPVersion = "HTTP/1.0"
        oRequest.EncodeBody = False
        set oHeaders = oRequest.Headers
        oHeaders.RemoveAll
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/AddWS.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "Content-Type", "application/x-www-form-urlencoded"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        oHeaders.Add "Pragma", "no-cache"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=13omfviuc3bf4xyadhls10fa"
        oHeaders.Add "Cookie", "(automatic)"
        oHeaders.Add "Content-Length", "(automatic)" 
        oRequest.Body = "__EVENTTARGET=&__EVENTARGUMENT=&"
		oRequest.Body = "__VIEWSTATE=" & strViewState
        oRequest.Body = oRequest.Body + "&rbDefaultAZ=rbDefaultAZ&WSNam"
        oRequest.Body = oRequest.Body + "eToCreate=KS12345&btnCreate=Create"

'        oRequest.Body = "__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=dDwzNT"
'        oRequest.Body = oRequest.Body + "kwNDE4MjY7dDw7bDxpPDE%2BOz47bDx0PDtsPGk8MT47aTwzPj"
'        oRequest.Body = oRequest.Body + "tpPDU%2BO2k8MTA%2BO2k8MTI%2BO2k8MTY%2BO2k8MTc%2BO2"
'        oRequest.Body = oRequest.Body + "k8MTk%2BOz47bDx0PHA8cDxsPENoZWNrZWQ7R3JvdXBOYW1lOz"
'        oRequest.Body = oRequest.Body + "47bDxvPHQ%2BO3JiRGVmYXVsdEFaOz4%2BOz47Oz47dDxwPHA8"
'        oRequest.Body = oRequest.Body + "bDxDaGVja2VkO0dyb3VwTmFtZTs%2BO2w8bzxmPjtyYkFpcnBv"
'        oRequest.Body = oRequest.Body + "cnRab25lOz4%2BOz47Oz47dDxwPHA8bDxFbmFibGVkOz47bDxv"
'        oRequest.Body = oRequest.Body + "PGY%2BOz4%2BOz47Oz47dDxwPHA8bDxUZXh0Oz47bDxQbGVhc2"
'        oRequest.Body = oRequest.Body + "UgZW50ZXIgdGhlIG5hbWUgb2YgdGhlIHdvcmtzdGF0aW9uIHlv"
'        oRequest.Body = oRequest.Body + "dSB3aXNoIHRvIGFkZCB0byB0aGUgU2FicmUgQ29uZmlndXJhdG"
'        oRequest.Body = oRequest.Body + "lvbiBkYXRhYmFzZS47Pj47Pjs7Pjt0PHA8O3A8bDxvbktleVVw"
'        oRequest.Body = oRequest.Body + "Oz47bDxMaW1pdFRvVXBwZXJjYXNlKEFkZFdTRm9ybS5XU05hbW"
'        oRequest.Body = oRequest.Body + "VUb0NyZWF0ZSk7Pj4%2BOzs%2BO3Q8cDxwPGw8VGV4dDs%2BO2"
'        oRequest.Body = oRequest.Body + "w8XGU7Pj47Pjs7Pjt0PHA8cDxsPEVuYWJsZWQ7PjtsPG88Zj47"
'        oRequest.Body = oRequest.Body + "Pj47Pjs7Pjt0PHQ8cDxwPGw8RGF0YVRleHRGaWVsZDtEYXRhVm"
'        oRequest.Body = oRequest.Body + "FsdWVGaWVsZDtWaXNpYmxlOz47bDxBSVJQT1JUWk9ORTtBSVJQ"
'        oRequest.Body = oRequest.Body + "T1JUWk9ORTtvPGY%2BOz4%2BOz47dDxpPDY%2BO0A8MjcxO0RF"
'        oRequest.Body = oRequest.Body + "RkFVTFQ7REVGQVVMVF9NTkVfRlJPTlRfTElORTtERlc0Njg0Nz"
'        oRequest.Body = oRequest.Body + "Q7SFM0Njg0NzQ7VFMxMjM0Oz47QDwyNzE7REVGQVVMVDtERUZB"
'        oRequest.Body = oRequest.Body + "VUxUX01ORV9GUk9OVF9MSU5FO0RGVzQ2ODQ3NDtIUzQ2ODQ3ND"
'        oRequest.Body = oRequest.Body + "tUUzEyMzQ7Pj47Pjs7Pjs%2BPjs%2BPjtsPHJiRGVmYXVsdEFa"
'        oRequest.Body = oRequest.Body + "O3JiQWlycG9ydFpvbmU7cmJBaXJwb3J0Wm9uZTs%2BPjcxreub"
'        oRequest.Body = oRequest.Body + "pKRSc4QzQ7byKsXiv77u&rbDefaultAZ=rbDefaultAZ&WSNam"
'        oRequest.Body = oRequest.Body + "eToCreate=KS12345&btnCreate=Create"

        Set oResponse = oConnection.Send(oRequest)
        If (oResponse is Nothing) Then
            Test.Trace "Error: Failed to receive response for URL to " + "/ClientDeviceMgr/AddWS.aspx"
        Else
            strStatusCode = oResponse.ResultCode
        End If
        oConnection.Close
    End If
End Sub

Sub SendRequest11()
	Dim Pos1, Pos2
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (2356)
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
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/AddWS.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=13omfviuc3bf4xyadhls10fa"
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

Sub SendRequest12()
	Dim Pos1, Pos2
    Dim oConnection, oRequest, oResponse, oHeaders, strStatusCode
    If fEnableDelays = True then Test.Sleep (21)
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
        oHeaders.Add "Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*"
        oHeaders.Add "Referer", "http://profileserver/ClientDeviceMgr/AddWS.aspx"
        oHeaders.Add "Accept-Language", "en-us"
        oHeaders.Add "User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322)"
        'oHeaders.Add "Host", "profileserver"
        oHeaders.Add "Host", "(automatic)"
        'oHeaders.Add "Cookie", "ASP.NET_SessionId=13omfviuc3bf4xyadhls10fa"
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
End Sub
Main

