Imports System.Web

Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Net.Mail

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class SendMail
     Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()> _
    Public Sub SendMail(ByVal sendTo As String, ByVal sendFrom As String, ByVal subject As String, ByVal text As String)
        Dim MailSmpt As New Mail.MailMessage
        Dim strMessage As String = text
        With MailSmpt
            .BodyFormat = Mail.MailFormat.Html
            .Subject = subject
            .Body = strMessage.ToString
            .From = sendFrom
            .To = sendTo
            '.Cc = cc

        End With
        Mail.SmtpMail.SmtpServer = "exchange2K7"
        Mail.SmtpMail.Send(MailSmpt)
    End Sub
    <WebMethod()> _
    Public Sub SendMail_ITHelpdesk(ByVal sendTo As String, ByVal sendFrom As String, ByVal subject As String, ByVal text As String)

        ' Dim strMessage As String = text
        Dim message As New MailMessage()
        message.From = New MailAddress(sendFrom)
        message.[To].Add(New MailAddress(sendTo))
        message.BCC.Add(New MailAddress("ashish@jctltd.com"))
        message.BCC.Add(New MailAddress("it.helpdesk@jctltd.com"))
        message.Subject = subject
        message.Body = text
        message.IsBodyHtml = True
        Dim mail As MailMessage = New MailMessage(sendFrom, sendTo, subject, text)
        Dim client As New SmtpClient("exchange2K7", 25)
        client.Credentials = New System.Net.NetworkCredential("it.helpdesk", "hithit")
        client.Send(message)
    End Sub

<WebMethod()> _
    Public Sub SendMailStringBuilder(ByVal sendTo As String, ByVal sendFrom As String, ByVal subject As String, ByVal text As StringBuilder, cc As String)
        Dim MailSmpt As New Mail.MailMessage
        Dim strMessage As StringBuilder = text
        With MailSmpt
            .BodyFormat = Mail.MailFormat.Html
            .Subject = subject
            .Body = strMessage.ToString
            .From = sendFrom
            .To = sendTo
            .Cc = cc

        End With
        Mail.SmtpMail.SmtpServer = "exchange2k7"
        Mail.SmtpMail.Send(MailSmpt)
    End Sub


    <WebMethod()> _
    Public Function SendEMail(ByVal sendTo As String, ByVal sendFrom As String, ByVal subject As String, ByVal text As String) As String
        Dim MailSmpt As New Mail.MailMessage
        Dim strMessage As String = text
        With MailSmpt
            .BodyFormat = Mail.MailFormat.Html
            .Subject = subject
            .Body = strMessage.ToString
            .From = sendFrom
            .To = sendTo
            '.Cc = cc

        End With
        Mail.SmtpMail.SmtpServer = "exchange2K7"
        Mail.SmtpMail.Send(MailSmpt)
        Return "Success"

    End Function

    <WebMethod()> _
    Public Sub SendMail2(ByVal sendTo As String, cc As String, bcc As String, ByVal sendFrom As String, ByVal subject As String, ByVal text As String)
        Dim MailSmpt As New System.Web.Mail.MailMessage
        Dim strMessage As String = text
        With MailSmpt
            .BodyFormat = System.Web.Mail.MailFormat.Html
            .Subject = subject
            .Body = strMessage.ToString
            .From = sendFrom
            .To = sendTo
            .Cc = cc
            .Bcc = bcc
            .Subject = subject
        End With
        System.Web.Mail.SmtpMail.SmtpServer = "exchange2K7"
        System.Web.Mail.SmtpMail.Send(MailSmpt)

    End Sub

    <WebMethod()> _
    Public Function SendSMS(ByVal companycode As String, ByVal sender As String, ByVal contacts As String, ByVal message As String, ByVal Subject As String) As String
        Dim client As New smscountry.Service
        Dim ofn As New Functions
        Dim result As String = ""
        Dim sql As String = ""
        result = client.SendTextSMS("JCTLTD", "jct@258", contacts, message, "JCTLTD")
        sql = "insert jct_sms_sentsms_log (CompanyCode,SMSID,Sender,Content,SMSTo,SMSDate,Subject) " & _
                "values ('" & companycode & "','" & result & "','" & sender & "','" & message & "','" & contacts & "',getdate(),'" & Subject & "')"
        ofn.InsertRecord(sql)
        Return result

    End Function

    <WebMethod()> _
    Public Function GetDeliveryStatus(ByVal smsid As String) As String
        Dim client As New smscountry.Service
        Dim status As String = client.GetDeliveryReport("JCTLTD", "jct@258", smsid)
        Return status

    End Function



End Class
