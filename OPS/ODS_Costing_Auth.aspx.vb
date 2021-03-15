Imports System
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Net.Mail
Imports System.IO
Imports System.Data
Imports System.Web

Partial Class OPS_ODS_Costing_Auth
Inherits System.Web.UI.Page
    Dim objFun As Functions = New Functions
    Dim obj As Connection = New Connection
    Dim qry As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand = New SqlCommand
    Dim con As SqlConnection = New SqlConnection
    Dim Tran As SqlTransaction
    Dim ObjSendMail As SendMail

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        qry = "eXEC Jct_Ops_Pending_Authorization_Fetch_test '" & Session("Empcode") & "','ODS Request'"
        objFun.FillGrid(qry, grdPendingRequest)
    End Sub

    Protected Sub grdPendingRequest_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPendingRequest.RowDataBound
    'e.Row.Cells(9).Visible = False
    'e.Row.Cells(10).Visible = False
    End Sub

    Protected Sub grdPendingRequest_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grdPendingRequest.SelectedIndexChanged
        qry = "Exec Jct_Ops_ODS_RequestDetail_Fetch '" & grdPendingRequest.SelectedRow.Cells(1).Text & "','N'"
        objFun.FillGrid(qry, grdRequestDetail)
        qry = "Exec Jct_Ops_ODS_RequestDetail_Fetch '" & grdPendingRequest.SelectedRow.Cells(1).Text & "','Y'"
        objFun.FillGrid(qry, GrdAvgCost)
    End Sub

    Protected Sub cmdAction_Click(sender As Object, e As System.EventArgs) Handles cmdAction.Click
        Dim Body As String = ""
        Dim RequestID As String = ""
        Dim CurrentUserName As String = ""
        Dim RaisedByUserName As String = ""
        Dim AuthorizedBy As String, SendMailTo As String, Shade As String, Lineno As Int16 = 0
        Dim Scrpt As String = ""
        Dim AuthMob As String = ""


        CurrentUserName = objFun.FetchValue("Select empname from jct_empmast_base where empcode='" & Session("Empcode") & "'")
        AuthorizedBy = objFun.FetchValue("SELECT E_MailID FROM MISTEL WHERE empcode='" & Session("Empcode") & "'")
        With GrdAvgCost
            Try

                RequestID = grdPendingRequest.SelectedRow.Cells(1).Text
                RaisedByUserName = objFun.FetchValue("SELECT b.empname FROM Jct_Ops_SanctionNote_HDR a,dbo.JCT_EmpMast_Base b WHERE a.UserCode=b.empcode AND a.SanctionNoteID='" & RequestID & "'")
                Tran = obj.Connection.BeginTransaction
                For i = 0 To .Rows.Count - 1
                    Dim Ct As String = ""
                    Dim txtProposedSP As TextBox = New TextBox
                    Dim txtProposedDNV As TextBox = New TextBox

                    cmd = New SqlCommand("Jct_Ops_ODS_Avg_ItemCost_Insert", obj.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    txtProposedSP.Text = CType(.Rows(i).FindControl("txtProposedSP"), TextBox).Text
                    txtProposedDNV.Text = CType(.Rows(i).FindControl("txtProposedDNV"), TextBox).Text
                    cmd.Parameters.Add("@UserCode", SqlDbType.VarChar).Value = Session("Empcode")
                    cmd.Parameters.Add("@RequestID", SqlDbType.VarChar).Value = RequestID
                    cmd.Parameters.Add("@Item_no", SqlDbType.VarChar).Value = .Rows(i).Cells(0).Text
                    cmd.Parameters.Add("@Variant", SqlDbType.VarChar).Value = .Rows(i).Cells(1).Text
                    cmd.Parameters.Add("@PriceApproved", SqlDbType.Float).Value = txtProposedSP.Text
                    cmd.Parameters.Add("@QtyApproved", SqlDbType.Float).Value = txtProposedDNV.Text
                    cmd.Parameters.Add("@ApprovedBy", SqlDbType.VarChar).Value = Session("Empcode")
                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = txtRemarks.Text
                    cmd.Parameters.Add("@HostIP", SqlDbType.VarChar).Value = Request.ServerVariables("REMOTE_ADDR")
                    cmd.Parameters.Add("@UserLevel", SqlDbType.TinyInt).Value = 1
                    cmd.Transaction = Tran
                    cmd.ExecuteNonQuery()


                Next
                Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & RequestID & " Is " & ddlAction.SelectedItem.Text & " </h3></b> By <b> " & CurrentUserName & " and is now Pending for your Approval" ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                '  SendMail(Body, Body1, Body3, "", SendMailTo, AuthorizedBy, "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "This SanctionNote :-" & RequestID & "  has been " & ddlAction.SelectedItem.Text & "", RequestID, CurrentUserLevel, MaxAuthLevel, FinalNotify, ddlAction.SelectedItem.Text)


                Tran.Commit()


            Catch ex As Exception
                Tran.Rollback()
                MsgBox("" & ex.ToString)
            End Try
        End With
        '    @UserCode
        '@RequestID 
        '@Item_no 
        '@Variant 
        '@PriceApproved
        '@QtyApproved
        '@ApprovedBy 
        '@Remarks
        '@HostIP
        '@UserLevel
    End Sub

    Private Sub SendMail(Body1 As String, Body2 As String, body3 As String, RaisedBy_Email As String, [to] As String, cc As String, bcc As String, Subject As String, SanctionNote As String, CurrentLevel As Int16, MaxLevel As Int16, NotifyAllList As String, Action As String)
        Try
            Dim from As String
            from = "noreply@jctltd.com"
            Dim query As String = ""
            Dim SenderEmail As String = ""

            If RaisedBy_Email Is Nothing Then
                RaisedBy_Email = ""
            End If

            'query = "SELECT isnull(E_MailID,'') FROM dbo.MISTEL WHERE empcode='" & [to] & "' "
            SenderEmail = [to] 'objFun.FetchValue(query)
            If SenderEmail Is Nothing Then SenderEmail = ""

            If SenderEmail <> "" Then

                'Email Address of Receiver
                [to] = SenderEmail '& " Comented by Ashish on 2nd Feb," & RaisedBy_Email
                '[to] = "jatindutta@jctltd.com"
                ' "neeraj@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,rahuljindal@jctltd.com,karunarora@jctltd.com,lakhbir@jctltd.com,ramanjot@jctltd.com,WeavingGroup@jctltd.com"
                'Else
                '    'Email Address of Receiver
                '    [to] = "neeraj@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,rahuljindal@jctltd.com,karunarora@jctltd.com,lakhbir@jctltd.com,ramanjot@jctltd.com,WeavingGroup@jctltd.com," & Convert.ToString(SalesPerson_Email)
            Else
                [to] = RaisedBy_Email
            '[to] = "jatindutta@jctltd.com"
            End If
            If CurrentLevel = MaxLevel And CurrentLevel > 0 And Action = "Authorize" Then
                [to] = NotifyAllList
                '[to] = "jatindutta@jctltd.com"
            End If

            bcc = "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com"
            ' cc = "jatindutta@jctltd.com"
            '    subject = "Authorized Shortfall Request - " & Convert.ToString(OrderNo)

            'StringBuilder sb = new StringBuilder();
            'sb.Append("Hi,<br/>");
            'sb.Append("This is a test email. We are testing out email client. Please don't mind.<br/>");
            'sb.Append("We are sorry for this unexpected mail to your mail box.<br/>");
            'sb.Append("<br/>");
            'sb.Append("Thanking you<br/>");
            'sb.Append("IT");

            'body__2 = Body__1 

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
            mail.Body = Body1 & " " & Body2 & " " & body3
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

    Protected Sub DataList1_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.ItemCommand
        Try
            Dim AreaName As String = ""
            grdPendingRequest.DataSource = Nothing
            grdPendingRequest.DataBind()
            If (String.IsNullOrEmpty(Request.QueryString("AreaName")) = False) Then

                AreaName = Request.QueryString("AreaName")

                grdRequestDetail.DataSource = Nothing
                grdRequestDetail.DataBind()

                'qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' and b.areaName='" & AreaName & "'"
                'Comented on 31-Dec-2012 qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c,Jct_Ops_SanctioNote_Area_Emp_Auth_Listing d WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' AND a.authFlag='P' AND a.PendingAt=d.UserLevel and b.areaName='" & AreaName & "' AND ( 1 = ( SELECT TOP 1 1 FROM    production..role_user_mapping WHERE   role = '100' AND uname = '" & Session("Empcode") & "') OR d.EmpCode = '" & Session("Empcode") & "') AND b.AreaCode = d.AreaCode "

                qry = "eXEC Jct_Ops_Pending_Authorization_Fetch '" & Session("Empcode") & "','ODS Request'"
                objFun.FillGrid(qry, grdPendingRequest)


                GrdAvgCost.DataSource = Nothing
                GrdAvgCost.DataBind()

                Request.QueryString.Clear()
            Else

                If e.CommandName = "Select" Then
                    AreaName = CType(e.Item.FindControl("cmdArea"), LinkButton).Text
                    If AreaName <> "" And AreaName <> "Greigh Transfer" And AreaName <> "ODS Request" Then
                        'GridView1.DataSource = Nothing
                        'GridView1.DataBind()
                        'GridView1.SelectedIndex = -1
                        'GrdSanctionNoteDetail.DataSource = Nothing
                        'GrdSanctionNoteDetail.DataBind()
                        'qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' and b.areaName='" & AreaName & "'"
                        'Comented on 31-Dec-2012 qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c,Jct_Ops_SanctioNote_Area_Emp_Auth_Listing d WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' AND a.authFlag='P' AND a.PendingAt=d.UserLevel and b.areaName='" & AreaName & "' AND ( 1 = ( SELECT TOP 1 1 FROM    production..role_user_mapping WHERE   role = '100' AND uname = '" & Session("Empcode") & "') OR d.EmpCode = '" & Session("Empcode") & "') AND b.AreaCode = d.AreaCode "
                        Response.Redirect("AuthorizeSanction_Note.aspx?AreaName=" + AreaName.Replace(" ", "%20"))
                        
                    ElseIf AreaName = "ODS Request" Then
                        qry = "eXEC Jct_Ops_Pending_Authorization_Fetch_test '" & Session("Empcode") & "','ODS Request'"
                        objFun.FillGrid(qry, grdPendingRequest)
                    Else
                        Response.Redirect("AuthorizeSanctionNote10.aspx")
                    End If
                End If

            End If
        Catch ex As Exception

        End Try


    End Sub

End Class
