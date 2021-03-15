Imports System
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Net.Mail
Imports System.IO
Imports System.Data
Partial Class OPS_ReInvoicing_Stock_Authorization
    Inherits System.Web.UI.Page
    Dim qry As String
    Dim objFun As Functions = New Functions
    Dim obj As Connection = New Connection
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand = New SqlCommand
    Dim con As SqlConnection = New SqlConnection
    Dim Tran As SqlTransaction
    Dim ObjSendMail As SendMail

    Protected Sub GrdRequestDEtails_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GrdRequestDEtails.SelectedIndexChanged

        qry = "Exec Jct_Ops_ReInvoicing_SanctionNote_Detail_Fetch '" & Trim(GrdRequestDEtails.SelectedRow.Cells(1).Text) & "'" ','" & Trim(GridView1.SelectedRow.Cells(2).Text) & "'"
        objFun.FillGrid(qry, GrdBasicDetail)
        qry = "exec Jct_Ops_SanctionNote_Authrization_Detail '" & Trim(GrdRequestDEtails.SelectedRow.Cells(1).Text) & "'"
        objFun.FillGrid(qry, GrdAuthHistory)


    End Sub

    Protected Sub CmdAuthorize_Click(sender As Object, e As System.EventArgs) Handles CmdAuthorize.Click


        Try


            Dim NextAuthLevel As String = "None"
            Dim MaxAuthLevel As String = "None"
            Dim CurrentUserLevel As String = ""
            Dim AreaCode As String = ""
            Dim SanctionNote As String = ""
            Dim SalePersonCode As String = ""
            Dim SalePersonEmail As String = "ashish@jctltd.com"
            Dim Body As String = ""
            Dim Body3 As String = ""
            Dim AuthorizedBy As String, SendMailTo As String, Shade As String, Lineno As Int16 = 0
            Dim Subject As String = ""
            Dim Qty As Int32 = 0
            Dim Reqd_Date As String = ""
            Dim Area As String = ""
            Dim UserName As String = ""
            Dim Scrpt As String = ""

            Dim sb As New StringBuilder()

            UserName = objFun.FetchValue("Select empname from jct_empmast_base where empcode='" & Session("Empcode") & "'")
            AuthorizedBy = objFun.FetchValue("SELECT E_MailID FROM MISTEL WHERE empcode='" & Session("Empcode") & "'")
            Dim FinalNotify As String = ""
            SendMailTo = ""
            Shade = ""
            Lineno = 0
            Try

                sb.AppendLine("<html>")
                sb.AppendLine("<head>")
                sb.AppendLine("<style type=""text/css"">")
                sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}")
                sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}")
                sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}")
                sb.AppendLine("</style>")
                sb.AppendLine("</head>")


                With GrdRequestDEtails

                    If .SelectedIndex > -1 Then
                        If GrdRequestDEtails.SelectedRow.Cells(1).Text <> "" Or GrdRequestDEtails.Rows.Count >= 1 Then
                            SanctionNote = Trim(.SelectedRow.Cells(1).Text)
                            AreaCode = Trim(.SelectedRow.Cells(2).Text)
                            Subject = Trim(.SelectedRow.Cells(5).Text)



                            Tran = obj.Connection.BeginTransaction
                            con = obj.Connection

                            If AreaCode <> 9999 Then


                                qry = "SELECT STUFF((SELECT ',' + s.E_MailID FROM (SELECT 1 ID,E_MailID from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,MISTEL c  WHERE id='" & SanctionNote & "' AND a.EMPCODE=c.empcode  UNION SELECT  1 ID,E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,MISTEL c  WHERE SanctionID='" & SanctionNote & "' AND a.NotifyUser=c.empcode ) s WHERE s.id = t.id FOR XML PATH('')),1,1,'') AS CSV FROM (SELECT 1 ID,E_MailID FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,MISTEL c  WHERE id='" & SanctionNote & "' AND a.EMPCODE=c.empcode  UNION SELECT  1 ID,E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,MISTEL c  WHERE SanctionID='" & SanctionNote & "' AND a.NotifyUser=c.empcode ) AS t GROUP BY t.id"
                                FinalNotify = objFun.FetchValue(qry, con, Tran)
                                qry = "Select isnull(convert(varchar,UserLevel),'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE AreaCode='" & AreaCode & "' and id='" & SanctionNote & "' and empcode='" & Session("Empcode") & "'"
                                CurrentUserLevel = objFun.FetchValue(qry, con, Tran)

                                If CurrentUserLevel Is Nothing Then CurrentUserLevel = "None"


                                If CurrentUserLevel <> "None" Then
                                    qry = "Select top 1 isnull(convert(varchar,UserLevel),'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE AreaCode='" & AreaCode & "'  and id='" & SanctionNote & "' and empcode<>'" & Session("Empcode") & "' and userlevel>'" & Val(CurrentUserLevel) & "' order by userlevel"
                                    NextAuthLevel = objFun.FetchValue(qry, con, Tran)
                                Else
                                    objFun.Alert("Unable to Your Authoirze...!!!")

                                    Tran.Rollback()
                                    Exit Sub
                                End If

                                qry = "Select top 1 isnull(E_MailID,'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,mistel b WHERE AreaCode='" & AreaCode & "'  and id='" & SanctionNote & "' and a.empcode<>'" & Session("Empcode") & "' and userlevel>'" & Val(CurrentUserLevel) & "' and a.empcode=b.empcode order by userlevel"
                                SendMailTo = objFun.FetchValue(qry, obj.Connection, Tran)


                                qry = "Select top 1 isnull(convert(varchar,max(UserLevel)),'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE AreaCode='" & AreaCode & "' and  id='" & SanctionNote & "'  AND STATUS is NULL"
                                MaxAuthLevel = objFun.FetchValue(qry, con, Tran)


                                If NextAuthLevel Is Nothing And MaxAuthLevel Is Nothing Then
                                    NextAuthLevel = "None"
                                    objFun.Alert("Unable to Your Peform Action...!!!")
                                    Tran.Rollback()
                                    Exit Sub

                                ElseIf NextAuthLevel <> "None" And CurrentUserLevel <> MaxAuthLevel And Left(ddlAction.SelectedItem.Text, 1) = "A" Then

                                    qry = "Update Jct_Ops_SanctionNote_HDR set AuthFlag='P',PendingAt='" & NextAuthLevel & "',LastAuthBy='" & CurrentUserLevel & "',LastAuthOn=getdate() where SanctionNoteID='" & SanctionNote & "' and status='A' and AuthFlag='P'"
                                    objFun.UpdateRecord(qry, Tran, con)


                                    qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set AUTH_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "'"

                                    objFun.UpdateRecord(qry, Tran, con)

                                    'Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & SanctionNote & " Is " & ddlAction.SelectedItem.Text & " </h3></b> By <b> " & UserName & " and is now Pending for your Approval" ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                                    sb.AppendLine("" & Body)
                                Else ' Else part will be executed in case when either maxauthlevel is achevied or some one wants to cancel any sanctionnote
                                    qry = "Update Jct_Ops_SanctionNote_HDR set AuthFlag='" & Left(ddlAction.SelectedItem.Text, 1) & "',PendingAt='',LastAuthBy='" & CurrentUserLevel & "',LastAuthOn=getdate() where SanctionNoteID='" & SanctionNote & "' and status='A'  and AuthFlag='P'"
                                    objFun.UpdateRecord(qry, Tran, con)

                                    If Left(ddlAction.SelectedItem.Text, 1) = "A" Then
                                        qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set AUTH_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "' and status is null"
                                        objFun.InsertRecord(qry, Tran, con)

                                    Else
                                        qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set CANCEL_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "' and status is null"
                                        objFun.InsertRecord(qry, Tran, con)
                                    End If


                                    objFun.InsertRecord(qry, Tran, con)

                                    'Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & SanctionNote & " Is " & ddlAction.SelectedItem.Text & " </h3></b> By <b> " & UserName & " and is now Pending for your Approval" ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                                    sb.AppendLine("" & Body)
                                End If
                            End If


                            Tran.Commit()
                            Scrpt = "alert('SanctionNote ' + '" + ddlAction.SelectedItem.Text + "'+'ed...!!!');"
                            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
                            objFun.Alert("SanctionNote " & ddlAction.SelectedItem.Text & "ed...!!!")
                            Dim j As Integer
                            If AreaCode <> 9999 Then

                                Dim Body1 As String = ""
                                'Dim Val1 As String = ""
                                Dim ParmName As String = ""
                                sb.AppendLine("Hi,<br/><br/>")
                                sb.AppendLine("Goods ReInvoicing Request is Pending for your Authorization <br/><br/>")
                                sb.AppendLine("RequestID  is : " + Trim(GrdRequestDEtails.SelectedRow.Cells(1).Text) + " <br/><br/>")
                                sb.AppendLine("Details are Shown below : <br/><br/>")
                                sb.AppendLine("<table class=gridtable>")
                                sb.AppendLine("<tr><th> SortNo</th> <th> Variant</th> <th> LastSoldAt</th> <th> Proposed_SellingPrice</th><th> Qty</th> </tr>")
                                'sb.AppendLine("<tr><th> SortNo</th> <th> Variant</th> <th> LastSoldAt</th> <th> Last Sold At</th><th> Proposed_SellingPrice(Qty)</th> </tr>")
                                Dim rwformation As String = ""
                                Dim cellFormation As String = ""
                                For i = 0 To GrdBasicDetail.Rows.Count - 1

                                    rwformation = "<tr>"
                                    'ParmName = GrdSanctionNoteDetail.Rows(i).Cells(0).Text
                                    'Val1 = GrdSanctionNoteDetail.Rows(i).Cells(1).Text
                                    'Body1 = Body1 & "<p> <b>" & ParmName & " :-</b> " & Val1 & " </p> "

                                    ' sb.Append("<head>");
                                    For j = 0 To GrdBasicDetail.Rows(i).Cells.Count - 1 '.Rows(i).Cells.Count - 1
                                        cellFormation = cellFormation & "<td> " & GrdBasicDetail.Rows(i).Cells(j).Text & " </td> " '& dr(1).ToString & "  </td>  <td> " & dr(2).ToString & "</td>  <td>" & dr(3).ToString & " </td>  <td>" & dr(4).ToString & " </td>  <td>" & dr(5).ToString & "</td>  <td> CEO </td> </tr> ")
                                    Next
                                    rwformation = rwformation & cellFormation & "</tr>"
                                    sb.AppendLine("" & rwformation)

                                Next


                                sb.AppendLine("</table>")
                                sb.AppendLine("<br />")
                                sb.AppendLine("<b> Authorization detail against this request is as below")




                                sb.AppendLine("<table class=gridtable>")


                                sb.AppendLine("<tr><th> SanctionID </th> <th> AuthorizedOn</th> <th> USERLEVEL</th> <th> empname</th> <th> Remarks</th> </tr>")
                                qry = "exec Jct_Ops_SanctionNote_Authrization_Detail '" & Trim(GrdRequestDEtails.SelectedRow.Cells(1).Text) & "'"
                                cmd = New SqlCommand(qry, obj.Connection)
                                dr = cmd.ExecuteReader
                                While dr.Read
                                    sb.AppendLine("<tr> <td> " & dr(0).ToString & " </td> <td> " & dr(1).ToString & "  </td>  <td> " & dr(2).ToString & "</td>  <td>" & dr(3).ToString & " </td>  <td>" & dr(4).ToString & " </td>  </tr> ")
                                End While

                                sb.AppendLine("</table>")
                                sb.AppendLine("<br />")




                                Body3 = " <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                                sb.AppendLine("" & Body3)

                                


                                sb.AppendLine("</table><br />")

                                sb.AppendLine("<br/><br />")

                                'sb.AppendLine("Thank you<br />")
                                sb.AppendLine("</html>")


                                SendMail(sb, "", SendMailTo, AuthorizedBy, "Ashish@jctltd.com,jagdeep@jctltd.com,rbaksshi@jctltd.com", "Goods ReInvoicing Request :-" & SanctionNote & "  has been " & ddlAction.SelectedItem.Text & "", SanctionNote, CurrentUserLevel, MaxAuthLevel, FinalNotify, ddlAction.SelectedItem.Text)
                            End If
                            'RefreshLists()

                        Else
                            Scrpt = "alert('Please Select any SanctionNote from the List and then Proceed !!!');"
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", Scrpt, True)
                            objFun.Alert("Please Select any SanctionNote from the List and then Proceed !!!")
                            Exit Sub
                        End If
                    Else
                        Scrpt = "alert('Please Select any SanctionNote from the List and then Proceed !!!');"
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", Scrpt, True)
                        objFun.Alert("Please Select any SanctionNote from the List and then Proceed !!!")
                        Exit Sub
                    End If
                End With
            Catch ex As Exception
                Scrpt = "alert('Unable to Complete Transaction...');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", Scrpt, True)
                objFun.Alert("Unable to Complete Transaction...")
                Tran.Rollback()
            End Try

        Catch ex As Exception

            Dim Scrpt As String = "alert('" + ex.Message + "');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)

        End Try





    End Sub


    Private Sub SendMail(sb As StringBuilder, RaisedBy_Email As String, [to] As String, cc As String, bcc As String, Subject As String, SanctionNote As String, CurrentLevel As Int16, MaxLevel As Int16, NotifyAllList As String, Action As String)
        Try
            Dim from As String
            If CurrentLevel < MaxLevel Then
                from = "noreply@jctltd.com"
            Else
                from = "approvals@jctltd.com"
            End If
            Dim query As String = ""
            Dim SenderEmail As String = ""
            'cc = "jagdeep@jctltd.com"
            If RaisedBy_Email Is Nothing Then
                RaisedBy_Email = ""
            End If


            SenderEmail = [to]
            If SenderEmail Is Nothing Then SenderEmail = ""

            If SenderEmail <> "" Then

                'Email Address of Receiver
                [to] = SenderEmail

            Else
                [to] = RaisedBy_Email

            End If
            If CurrentLevel = MaxLevel And CurrentLevel > 0 And Action = "Authorize" Then
                sb.AppendLine("" & NotifyAllList)
                [to] = NotifyAllList
            End If


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

            If Not String.IsNullOrEmpty(bcc) Then
                If bcc.Contains(",") Then
                    Dim bccs As String() = bcc.Split(","c)
                    For i As Integer = 0 To bccs.Length - 1
                        mail.Bcc.Add(New MailAddress(bccs(i)))
                    Next
                Else
                    mail.Bcc.Add(New MailAddress(bcc))
                End If
            End If
            If Not String.IsNullOrEmpty(cc) Then
                If cc.Contains(",") Then
                    Dim ccs As String() = cc.Split(","c)
                    For i As Integer = 0 To ccs.Length - 1
                        mail.CC.Add(New MailAddress(ccs(i)))
                    Next
                    'Else
                    '    mail.CC.Add(New MailAddress(bcc))
                End If
                mail.CC.Add(New MailAddress(cc))
            End If

            mail.Subject = Subject
            mail.Body = sb.ToString()
            mail.IsBodyHtml = True
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            '       MailAttachment attach = new MailAttachment(Server.MapPath(strFileName));
            '/* Attach the newly created email attachment */      
            'mailMessage.Attachments.Add(attach);
            If CurrentLevel = MaxLevel And CurrentLevel > 0 And Action = "Authorize" Then
                qry = "SELECT ImgName FROM Jct_Ops_SanctionNote_Attachments WHERE STATUS='A' AND SanctionNoteID='" & SanctionNote & "'"
                cmd = New SqlCommand(qry, obj.Connection)
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    While dr.Read
                        Dim Atchment As Attachment = New Attachment(Server.MapPath("~\OPS\Upload\") & dr.Item(0))
                        mail.Attachments.Add(Atchment)
                    End While
                End If
                dr.Close()

            End If






            Dim SmtpMail As New SmtpClient("exchange2k7")

            '
            SmtpMail.Send(mail)
        Catch ex As Exception
            Dim Scrpt As String = "alert('" + ex.Message + "');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
        End Try
    End Sub

    'Private Sub SendMail(sb As StringBuilder, p2 As String, SendMailTo As String, AuthorizedBy As String, p5 As String, p6 As String, SanctionNote As String, CurrentUserLevel As String, MaxAuthLevel As String, FinalNotify As String, p11 As String)
    '    Throw New NotImplementedException
    'End Sub

End Class
