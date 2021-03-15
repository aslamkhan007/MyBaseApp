Imports System.IO
Imports System.Net
Imports System.Net.Mail

Partial Class Test_Page
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''Dim strURL As String
        ''Dim strResult As String
        ''Dim wbrq As HttpWebRequest
        ''Dim wbrs As HttpWebResponse
        ''Dim sr As StreamReader

        ' '' Set the URL (and add any querystring values)
        ''strURL = "http://www.yahoo.com"

        ' '' Create the web request   
        ''wbrq = WebRequest.Create(strURL)
        ''wbrq.Method = "GET"

        ' '' Read the returned data    
        ''wbrs = wbrq.GetResponse
        ''sr = New StreamReader(wbrs.GetResponseStream)
        ''strResult = sr.ReadToEnd.Trim
        ''sr.Close()

        ' '' Write the returned data out to the page   
        ''Label1.Text = strResult

        ''label1.text = Request.ServerVariables("HTTP_USER_AGENT")

        ''Dim fp As StreamReader

        ''Try
        ''    fp = File.OpenText(Server.MapPath("dali.txt"))
        ''    Label1.Text = fp.ReadToEnd()
        ''    'lblStatus.Text = "File Succesfully Read!"
        ''    fp.Close()
        ''Catch err As Exception
        ''    Label1.Text = err.Message
        ''    'lblStatus.Text = "File Read Failed. Reason is as follows  & err.ToString()
        ''Finally

        ''End Try

        'Const Filename As String = "dali.txt"    ' file to read
        ''Const ForReading = 1, ForWriting = 2, ForAppending = 3
        ''Const TristateUseDefault = -2, TristateTrue = -1, TristateFalse = 0

        '' Create a filesystem object
        'Dim FSO As Object
        'FSO = Server.CreateObject("Scripting.FileSystemObject")

        '' Map the logical path to the physical system path
        'Dim Filepath, textstream As Object
        'Filepath = Server.MapPath(Filename)

        'If FSO.FileExists(Filepath) Then

        '    textstream = FSO.OpenTextFile(Filepath, 1, False, -2)

        '    ' Read file in one hit
        '    Dim Contents As String
        '    Contents = TextStream.ReadAll
        '    Label1.Text = "<pre>" & Contents & "</pre><hr>"
        '    TextStream.Close()
        '    TextStream = Nothing

        'Else
        '    Label1.Text = Filename & " Does not exist."
        '    'Response.Write("<h3><i><font color=red> File " & Filename & _
        '    '" does not exist</font></i></h3>")

        'End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        '  Dim sm As SendMail = New SendMail
        '  sm.SendMail(txtTo.Text, txtFrom.Text, txtSubject.Text, txtMsg.Text)

        Dim message As New MailMessage()
            message.[To].Add(New MailAddress(txtTo.Text))
            'message.[To].Add(New MailAddress("recipient2@foo.bar.com"))
            'message.[To].Add(New MailAddress("recipient3@foo.bar.com"))

            ' message.CC.Add(New MailAddress("carboncopy@foo.bar.com"))
            message.From = New MailAddress(txtFrom.Text)
            message.Subject = txtSubject.Text
            message.Body = txtMsg.Text + i.ToString()
            Dim mail As MailMessage = New MailMessage(txtFrom.Text, txtTo.Text, txtSubject.Text, txtMsg.Text)

            Dim client As New SmtpClient("exchange2007", 25)
            ' client.Credentials = CredentialCache.DefaultNetworkCredentials
            client.Credentials = New System.Net.NetworkCredential("it.helpdesk", "hithit")
            client.Send(message)
    End Sub
End Class
