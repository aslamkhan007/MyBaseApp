Imports System.Net.Mail
Imports System.Data.SqlClient
Imports System.Data

Partial Class OPS_SendEmailNotification_SanctionNotes
    Inherits System.Web.UI.Page

    Dim obj As Connection = New Connection()
    Dim obj1 As Functions = New Functions()
    Dim obj2 As Connection = New Connection()
    Dim obj3 As Connection = New Connection()
    Private Sub SendMail()

        Dim sql As String
        Dim from As String, [to] As String, bcc As String, cc As String, subject As String, body As String
 

 

        sql = "  SELECT  DISTINCT SanctionNoteID " & _
              "FROM    dbo.jct_ops_material_request  a " & _
              "INNER JOIN dbo.Jct_Ops_SanctionNote_HDR  b ON CONVERT(VARCHAR, a.RequestID) = b.SanctionNoteID " & _
              "INNER JOIN dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING  c ON CONVERT(VARCHAR, a.RequestID) = c.ID " & _
                                                              " AND b.PendingAt = c.USERLEVEL " & _
              "WHERE   b.STATUS = 'A' " & _
              "AND b.AuthFlag = 'P' " & _
              "AND c.EMPCODE = 'R-01111' "

        Dim cmd As SqlCommand = New SqlCommand(sql, obj.Connection())
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        If (dr.HasRows) Then
            While dr.Read()


                Dim sb As New StringBuilder()
                sb.AppendLine("<html>")
                sb.AppendLine("<head>")
                sb.AppendLine("<style type=""text/css"">")
                sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}")
                sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}")
                sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}")
                sb.AppendLine("</style>")
                sb.AppendLine("</head>")
                sb.AppendLine("Hi,<br/><br/>")
                sb.AppendLine("Material Return Request has been generated in OPS.<br/><br/>")
                sb.AppendLine("RequestID for your request is : " + dr(0).ToString() + " <br/><br/>")


                sb.AppendLine("Please reply this email with 'YES'  to authorise and  'NO' to cancel and 'REMARKS'.<br/> <br/>")


                sb.AppendLine("Details are Shown below : <br/><br/>")
                sb.AppendLine("<table class=gridtable>")
                sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th> Auth. Pending At</th> </tr>")

                sql = "JCT_OPS_SANCTION_PENDING_AT_MATERIAL_RETURN"
                Dim cmd3 As SqlCommand = New SqlCommand(sql, obj3.Connection())
                cmd3.CommandType = CommandType.StoredProcedure
                cmd3.Parameters.Add("@RequestID", SqlDbType.Int).Value = dr(0).ToString()
                Dim Dr3 As SqlDataReader = cmd3.ExecuteReader()
                If (Dr3.HasRows) Then
                    While (Dr3.Read())

                        ViewState("Customer") = Dr3(2).ToString()

                        sb.AppendLine("<tr> <td> " & Dr3(0).ToString & " </td> <td> " & Dr3(1).ToString & "  </td>  <td> " & Dr3(2).ToString & "</td>  <td>" & Dr3(3).ToString & " </td>  <td>" & Dr3(4).ToString & " </td>  <td>" & Dr3(5).ToString & "</td>  <td>ROHIT SERU</td> </tr> ")


                    End While

                End If
                Dr3.Close()
                obj3.ConClose()
                sb.AppendLine("</table>")


                sb.AppendLine("<br /><br/>")
                sql = "SELECT distinct DESCRIPTION,reason FROM dbo.jct_ops_material_request  WHERE RequestID=" + dr(0).ToString()
                cmd3 = New SqlCommand(sql, obj3.Connection())
                Dr3 = cmd3.ExecuteReader()
                If (Dr3.HasRows) Then

                    While (Dr3.Read())

                        sb.AppendLine("Detailed Description (Entered by Marketing Executive) : " + Dr3(0).ToString().ToUpper())
                        sb.AppendLine("<br /><br />")
                        sb.AppendLine("Reason : " + Dr3(1).ToString().ToUpper())
                        sb.AppendLine("<br /><br />")

                    End While

                End If
                Dr3.Close()
                obj3.ConClose()

                sb.AppendLine("Authorisation History : ")
                sb.AppendLine("<table class=gridtable>")
                sb.AppendLine("<tr><th> UserLevel</th> <th> Authorised By</th> <th> Remarks</th> <th>Authorisation Date </th> </tr>")

                sql = "  SELECT USERLEVEL,b.empname AS AuthorisedBy,Remarks,AUTH_DATETIME AS  AuthorisationDate FROM dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING  a INNER JOIN dbo.JCT_EmpMast_Base b ON a.EMPCODE=b.empcode WHERE ID IN ('" + dr(0).ToString() + "') order by userlevel asc"
                cmd3 = New SqlCommand(sql, obj3.Connection())
                Dr3 = cmd3.ExecuteReader()
                If (Dr3.HasRows) Then

                    While (Dr3.Read())

                        sb.AppendLine("<tr><td> " + Dr3(0).ToString() + "</td> <td>" + Dr3(1).ToString() + "</td> <td>" + Dr3(2).ToString() + "</td> <td> " + Dr3(3).ToString() + "</td> </tr>")

                    End While

                End If
                Dr3.Close()
                obj3.ConClose()

                sb.AppendLine("</table><br />")


                sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>")
                sb.AppendLine("Thank you<br />")
                sb.AppendLine("</html>")

                body = sb.ToString()
                from = "approvals@jctltd.com"

                sql = "SELECT b.E_MailID FROM dbo.jct_ops_material_request  a INNER JOIN dbo.MISTEL b ON a.userid=b.empcode WHERE RequestID='" + dr(0).ToString() + "' "
                If (obj1.CheckRecordExistInTransaction(sql)) Then
                    cc = obj1.FetchValue(sql).ToString()
                    '  cc = "jagdeep@jctltd.com"
                Else

                    cc = "It.helpdesk@jctltd.com"

                End If



                [to] = ("rohits@jctltd.com")
                '[to] = "jatindutta@jctltd.com"
                subject = " Material Return Request  :- " + ViewState("Customer") + " with ID - " + dr(0).ToString()
                Dim mail As New MailMessage()
                mail.From = New MailAddress(from)
                If [to].Contains(",") Then
                    Dim tos As String() = [to].Split(","c)
                    For i As Integer = 0 To tos.Length - 1
                        mail.[To].Add(New MailAddress(tos(i)))
                    Next
                Else
                    mail.[To].Add(New MailAddress([to]))
                End If


                If Not String.IsNullOrEmpty(cc) Then
                    If cc.Contains(",") Then
                        Dim ccs As String() = cc.Split(","c)
                        For i As Integer = 0 To ccs.Length - 1
                            mail.CC.Add(New MailAddress(ccs(i)))
                        Next
                    Else
                        mail.CC.Add(New MailAddress(cc))
                    End If
                    mail.CC.Add(New MailAddress(cc))
                End If
	        mail.CC.Add("rbaksshi@jctltd.com")
                mail.Subject = subject
                mail.Body = body
                mail.IsBodyHtml = True
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                Dim SmtpMail As New SmtpClient("exchange2k7")
                SmtpMail.Send(mail)


            End While
        End If
        dr.Close()

        obj.ConClose()

        body = ""


    End Sub

    Protected Sub btnMail_Click(sender As Object, e As System.EventArgs) Handles btnMail.Click
        SendMail()
    End Sub
End Class
