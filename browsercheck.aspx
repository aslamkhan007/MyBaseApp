<%@ Page language="c#" %>

<!-- 2003-12-03, Rob Eberhardt - http://slingfive.com/demos/browserCaps/ -->
<!-- 2004-06-02, Chris Maunder - http://www.codeproject.com/aspnet/browserCaps.asp -->

<html>
<head><title>Request.Browser Info</title></head>
<body>

<h3>Request.Browser Info:</h3>
<table border=1>
<tr><td>User Agent</td><td><% Response.Write(Request.ServerVariables["http_user_agent"].ToString());%></td></tr>
<tr><td>Browser</td><td><% Response.Write(Request.Browser.Browser.ToString());%></td></tr>
<tr><td>Version</td><td><% Response.Write(Request.Browser.Version.ToString());%></td></tr>
<tr><td>Major Version</td><td><% Response.Write(Request.Browser.MajorVersion.ToString());%></td></tr>
<tr><td>Minor Version</td><td><% Response.Write(Request.Browser.MinorVersion.ToString());%></td></tr>
<tr><td>Platform</td><td><% Response.Write(Request.Browser.Platform.ToString());%></td></tr>
<tr><td>ECMA Script version</td><td><% Response.Write(Request.Browser.EcmaScriptVersion.ToString());%></td></tr>
<tr><td>Type</td><td><% Response.Write(Request.Browser.Type.ToString());%></td></tr>

<tr><td colspan=2>&nbsp;</td></tr>

<tr><td>ActiveX Controls</td><td><% Response.Write(Request.Browser.ActiveXControls.ToString());%></td></tr>
<tr><td>Background Sounds</td><td><% Response.Write(Request.Browser.BackgroundSounds.ToString());%></td></tr>
<tr><td>AOL</td><td><% Response.Write(Request.Browser.AOL.ToString());%></td></tr>
<tr><td>Beta</td><td><% Response.Write(Request.Browser.Beta.ToString());%></td></tr>
<tr><td>CDF</td><td><% Response.Write(Request.Browser.CDF.ToString());%></td></tr>
<tr><td>ClrVersion</td><td><% Response.Write(Request.Browser.ClrVersion.ToString());%></td></tr>
<tr><td>Cookies</td><td><% Response.Write(Request.Browser.Cookies.ToString());%></td></tr>
<tr><td>Crawler</td><td><% Response.Write(Request.Browser.Crawler.ToString());%></td></tr>
<tr><td>Frames</td><td><% Response.Write(Request.Browser.Frames.ToString());%></td></tr>
<tr><td>JavaApplets</td><td><% Response.Write(Request.Browser.JavaApplets.ToString());%></td></tr>
<tr><td>JavaScript</td><td><% Response.Write(Request.Browser.JavaScript.ToString());%></td></tr>
<tr><td>MSDomVersion</td><td><% Response.Write(Request.Browser.MSDomVersion.ToString());%></td></tr>
<tr><td>TagWriter</td><td><% Response.Write(Request.Browser.TagWriter.ToString());%></td></tr>
<tr><td>VBScript</td><td><% Response.Write(Request.Browser.VBScript.ToString());%></td></tr>
<tr><td>W3CDomVersion</td><td><% Response.Write(Request.Browser.W3CDomVersion.ToString());%></td></tr>
<tr><td>Win16</td><td><% Response.Write(Request.Browser.Win16.ToString());%></td></tr>
<tr><td>Win32</td><td><% Response.Write(Request.Browser.Win32.ToString());%></td></tr>

<tr><td>IP Address</td><td><% Response.Write( Request.ServerVariables["REMOTE_ADDR"].ToString());%></td></tr>
</table>

</body>
</html>
