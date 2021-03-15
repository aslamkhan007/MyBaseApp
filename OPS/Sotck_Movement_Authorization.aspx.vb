Imports System
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Net.Mail
Imports System.IO
Imports System.Data
Imports System.Web
Partial Class OPS_Sotck_Movement_Authorization
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
        'qry = "eXEC Jct_Ops_Pending_Authorization_Fetch_test '" & Session("Empcode") & "','ODS Request'"
        'objFun.FillGrid(qry, grdPendingRequest)
    End Sub


#Region "backupCode"
    'Protected Sub grdPendingRequest_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPendingRequest.RowDataBound
    '    'e.Row.Cells(9).Visible = False
    '    'e.Row.Cells(10).Visible = False
    'End Sub

    'Protected Sub grdPendingRequest_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grdPendingRequest.SelectedIndexChanged
    '    qry = "Exec Jct_Ops_ODS_RequestDetail_Fetch '" & grdPendingRequest.SelectedRow.Cells(1).Text & "','N'"
    '    objFun.FillGrid(qry, grdRequestDetail)
    '    qry = "Exec Jct_Ops_ODS_RequestDetail_Fetch '" & grdPendingRequest.SelectedRow.Cells(1).Text & "','Y'"
    '    objFun.FillGrid(qry, GrdAvgCost)
    'End Sub

    'Protected Sub cmdAction_Click(sender As Object, e As System.EventArgs) Handles cmdAction.Click
    '    Dim Body As String = ""
    '    Dim RequestID As String = ""
    '    Dim CurrentUserName As String = ""
    '    Dim RaisedByUserName As String = ""
    '    Dim AuthorizedBy As String, SendMailTo As String, Shade As String, Lineno As Int16 = 0
    '    Dim Scrpt As String = ""
    '    Dim AuthMob As String = ""


    '    CurrentUserName = objFun.FetchValue("Select empname from jct_empmast_base where empcode='" & Session("Empcode") & "'")
    '    AuthorizedBy = objFun.FetchValue("SELECT E_MailID FROM MISTEL WHERE empcode='" & Session("Empcode") & "'")
    '    With GrdAvgCost
    '        Try

    '            RequestID = grdPendingRequest.SelectedRow.Cells(1).Text
    '            RaisedByUserName = objFun.FetchValue("SELECT b.empname FROM Jct_Ops_SanctionNote_HDR_Test a,dbo.JCT_EmpMast_Base b WHERE a.UserCode=b.empcode AND a.SanctionNoteID='" & RequestID & "'")
    '            Tran = obj.Connection.BeginTransaction
    '            For i = 0 To .Rows.Count - 1
    '                Dim Ct As String = ""
    '                Dim txtProposedSP As TextBox = New TextBox
    '                Dim txtProposedDNV As TextBox = New TextBox

    '                cmd = New SqlCommand("Jct_Ops_ODS_Avg_ItemCost_Insert", obj.Connection)
    '                cmd.CommandType = CommandType.StoredProcedure
    '                txtProposedSP.Text = CType(.Rows(i).FindControl("txtProposedSP"), TextBox).Text
    '                txtProposedDNV.Text = CType(.Rows(i).FindControl("txtProposedDNV"), TextBox).Text
    '                cmd.Parameters.Add("@UserCode", SqlDbType.VarChar).Value = Session("Empcode")
    '                cmd.Parameters.Add("@RequestID", SqlDbType.VarChar).Value = RequestID
    '                cmd.Parameters.Add("@Item_no", SqlDbType.VarChar).Value = .Rows(i).Cells(0).Text
    '                cmd.Parameters.Add("@Variant", SqlDbType.VarChar).Value = .Rows(i).Cells(1).Text
    '                cmd.Parameters.Add("@PriceApproved", SqlDbType.Float).Value = txtProposedSP.Text
    '                cmd.Parameters.Add("@QtyApproved", SqlDbType.Float).Value = txtProposedDNV.Text
    '                cmd.Parameters.Add("@ApprovedBy", SqlDbType.VarChar).Value = Session("Empcode")
    '                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = txtRemarks.Text
    '                cmd.Parameters.Add("@HostIP", SqlDbType.VarChar).Value = Request.ServerVariables("REMOTE_ADDR")
    '                cmd.Parameters.Add("@UserLevel", SqlDbType.TinyInt).Value = 1
    '                cmd.Transaction = Tran
    '                cmd.ExecuteNonQuery()


    '            Next
    '            Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & RequestID & " Is " & ddlAction.SelectedItem.Text & " </h3></b> By <b> " & CurrentUserName & " and is now Pending for your Approval" ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
    '            '  SendMail(Body, Body1, Body3, "", SendMailTo, AuthorizedBy, "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "This SanctionNote :-" & RequestID & "  has been " & ddlAction.SelectedItem.Text & "", RequestID, CurrentUserLevel, MaxAuthLevel, FinalNotify, ddlAction.SelectedItem.Text)


    '            Tran.Commit()


    '        Catch ex As Exception
    '            Tran.Rollback()
    '            MsgBox("" & ex.ToString)
    '        End Try
    '    End With
    '    '    @UserCode
    '    '@RequestID 
    '    '@Item_no 
    '    '@Variant 
    '    '@PriceApproved
    '    '@QtyApproved
    '    '@ApprovedBy 
    '    '@Remarks
    '    '@HostIP
    '    '@UserLevel
    'End Sub

    'Private Sub SendMail(Body1 As String, Body2 As String, body3 As String, RaisedBy_Email As String, [to] As String, cc As String, bcc As String, Subject As String, SanctionNote As String, CurrentLevel As Int16, MaxLevel As Int16, NotifyAllList As String, Action As String)
    '    Try
    '        Dim from As String
    '        from = "devlopment@jctltd.com"
    '        Dim query As String = ""
    '        Dim SenderEmail As String = ""

    '        If RaisedBy_Email Is Nothing Then
    '            RaisedBy_Email = ""
    '        End If

    '        'query = "SELECT isnull(E_MailID,'') FROM dbo.MISTEL WHERE empcode='" & [to] & "' "
    '        SenderEmail = [to] 'objFun.FetchValue(query)
    '        If SenderEmail Is Nothing Then SenderEmail = ""

    '        If SenderEmail <> "" Then

    '            'Email Address of Receiver
    '            [to] = SenderEmail '& " Comented by Ashish on 2nd Feb," & RaisedBy_Email
    '            '[to] = "jatindutta@jctltd.com"
    '            ' "neeraj@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,rahuljindal@jctltd.com,karunarora@jctltd.com,lakhbir@jctltd.com,ramanjot@jctltd.com,WeavingGroup@jctltd.com"
    '            'Else
    '            '    'Email Address of Receiver
    '            '    [to] = "neeraj@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,rahuljindal@jctltd.com,karunarora@jctltd.com,lakhbir@jctltd.com,ramanjot@jctltd.com,WeavingGroup@jctltd.com," & Convert.ToString(SalesPerson_Email)
    '        Else
    '            [to] = RaisedBy_Email
    '            '[to] = "jatindutta@jctltd.com"
    '        End If
    '        If CurrentLevel = MaxLevel And CurrentLevel > 0 And Action = "Authorize" Then
    '            [to] = NotifyAllList
    '            '[to] = "jatindutta@jctltd.com"
    '        End If

    '        bcc = "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com"
    '        ' cc = "jatindutta@jctltd.com"
    '        '    subject = "Authorized Shortfall Request - " & Convert.ToString(OrderNo)

    '        'StringBuilder sb = new StringBuilder();
    '        'sb.Append("Hi,<br/>");
    '        'sb.Append("This is a test email. We are testing out email client. Please don't mind.<br/>");
    '        'sb.Append("We are sorry for this unexpected mail to your mail box.<br/>");
    '        'sb.Append("<br/>");
    '        'sb.Append("Thanking you<br/>");
    '        'sb.Append("IT");

    '        'body__2 = Body__1 

    '        Dim mail As New MailMessage()
    '        mail.From = New MailAddress(from)
    '        If [to].Contains(",") Then
    '            Dim tos As String() = [to].Split(","c)
    '            For i As Integer = 0 To tos.Length - 1
    '                mail.[To].Add(New MailAddress(tos(i)))
    '            Next
    '        Else
    '            mail.[To].Add(New MailAddress([to]))
    '        End If

    '        If Not String.IsNullOrEmpty(bcc) Then
    '            If bcc.Contains(",") Then
    '                Dim bccs As String() = bcc.Split(","c)
    '                For i As Integer = 0 To bccs.Length - 1
    '                    mail.Bcc.Add(New MailAddress(bccs(i)))
    '                Next
    '            Else
    '                mail.Bcc.Add(New MailAddress(bcc))
    '            End If
    '        End If
    '        If Not String.IsNullOrEmpty(cc) Then
    '            If cc.Contains(",") Then
    '                Dim ccs As String() = cc.Split(","c)
    '                For i As Integer = 0 To ccs.Length - 1
    '                    mail.CC.Add(New MailAddress(ccs(i)))
    '                Next
    '                'Else
    '                '    mail.CC.Add(New MailAddress(bcc))
    '            End If
    '            mail.CC.Add(New MailAddress(cc))
    '        End If

    '        mail.Subject = Subject
    '        mail.Body = Body1 & " " & Body2 & " " & body3
    '        mail.IsBodyHtml = True
    '        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
    '        '       MailAttachment attach = new MailAttachment(Server.MapPath(strFileName));
    '        '/* Attach the newly created email attachment */      
    '        'mailMessage.Attachments.Add(attach);
    '        If CurrentLevel = MaxLevel And CurrentLevel > 0 And Action = "Authorize" Then
    '            qry = "SELECT ImgName FROM Jct_Ops_SanctionNote_Attachments WHERE STATUS='A' AND SanctionNoteID='" & SanctionNote & "'"
    '            cmd = New SqlCommand(qry, obj.Connection)
    '            dr = cmd.ExecuteReader
    '            If dr.HasRows = True Then
    '                While dr.Read
    '                    Dim Atchment As Attachment = New Attachment(Server.MapPath("~\OPS\Upload\") & dr.Item(0))
    '                    mail.Attachments.Add(Atchment)
    '                End While
    '            End If
    '            dr.Close()

    '        End If






    '        Dim SmtpMail As New SmtpClient("exchange2007")

    '        '
    '        SmtpMail.Send(mail)
    '    Catch ex As Exception
    '        Dim Scrpt As String = "alert('" + ex.Message + "');"
    '        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
    '    End Try
    'End Sub
#End Region

  

    Protected Sub DataList1_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.ItemCommand
        Try
            Dim AreaName As String = ""
            AreaName = CType(e.Item.FindControl("cmdArea"), LinkButton).Text
            GridView1.DataSource = Nothing
            GridView1.DataBind()


            grdRequestDetail.DataSource = Nothing
            grdRequestDetail.DataBind()


            GrdAuthHistory.DataSource = Nothing
            GrdAuthHistory.DataBind()
            'qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR_Test a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' and b.areaName='" & AreaName & "'"
            'Comented on 31-Dec-2012 qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR_Test a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c,Jct_Ops_SanctioNote_Area_Emp_Auth_Listing d WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' AND a.authFlag='P' AND a.PendingAt=d.UserLevel and b.areaName='" & AreaName & "' AND ( 1 = ( SELECT TOP 1 1 FROM    production..role_user_mapping WHERE   role = '100' AND uname = '" & Session("Empcode") & "') OR d.EmpCode = '" & Session("Empcode") & "') AND b.AreaCode = d.AreaCode "

            qry = "eXEC Jct_Ops_Stock_Movement_Pending_Authorization_Fetch '" & Session("Empcode") & "','" & AreaName & "'"
            objFun.FillGrid(qry, GridView1)


            'GrdAvgCost.DataSource = Nothing
            'GrdAvgCost.DataBind()



        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            GridView1.DataKeyNames.Equals("SanctionNoteID")
            Dim SanctionID As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SanctionNoteID"))

            Dim GridViewNested As GridView = DirectCast(e.Row.FindControl("nestedGridView"), GridView)
            GridViewNested.DataKeyNames.Equals("Description")
            qry = "Select Description from Jct_Ops_SanctionNote_HDR_Test where status='A' and AuthFlag='P' and  sanctionNoteID ='" & SanctionID & "' union Select Description from Jct_Ops_SanctionNote_HDR where status='A' and AuthFlag='P' and  sanctionNoteID ='" & SanctionID & "' "
            Dim cmd As New SqlCommand(qry, obj.Connection())
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            GridViewNested.DataSource = ds.Tables(0)
            GridViewNested.DataBind()


        End If
    End Sub


    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        'Comented on 31-Dec-2012   qry = "SELECT b.ParmName,b.ParmDesc,a.Val as [Values] FROM dbo.Jct_Ops_SanctionNote_Dtl a,dbo.Jct_Ops_SanctionNote_Parameters b WHERE SanctionNoteID='" & Trim(GridView1.SelectedRow.Cells(1).Text) & "' AND b.STATUS='A' AND GETDATE() BETWEEN b.Eff_From AND b.Eff_To  AND a.ParamCode=b.ParamCode"
        Try
            If GridView1.SelectedRow.Cells(3).Text = "1053" Then
                qry = "Exec Jct_Ops_ExcessStock_Selling_DEtail '" & GridView1.SelectedRow.Cells(2).Text & "'"
                'qry = "Exec Jct_Ops_ExcessStock_Selling_DEtail '1008'"
            Else

                qry = "Jct_Ops_ODS_Transfer_Sell_Items_Fetch '" & GridView1.SelectedRow.Cells(2).Text & "','','','','N','" & GridView1.SelectedRow.Cells(3).Text & "'"
            End If
            objFun.FillGrid(qry, grdRequestDetail)
            If GridView1.SelectedRow.Cells(3).Text = "1041" Then
                qry = "Jct_Ops_ODS_Transfer_Sell_Items_Fetch '" & GridView1.SelectedRow.Cells(2).Text & "','','','','Y','" & GridView1.SelectedRow.Cells(3).Text & "'"
                Dim da As SqlDataAdapter
                da = New SqlDataAdapter(qry, obj.Connection)
                Dim ds = New DataSet
                da.Fill(ds)
                DtlListSummary.DataSource = ds
                DtlListSummary.DataBind()
                qry = "Jct_Ops_Fetch_OrderDetails_For_Request '" & GridView1.SelectedRow.Cells(2).Text & "'"
                objFun.FillGrid(qry, GrdPricingDetail)






                'qry = "Jct_Ops_ODS_Transfer_Sell_Items_Fetch @RequestID,@p1,@p2,@p3"
                'SqlDataSource3.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
                'SqlDataSource3.SelectCommand = qry
                'SqlDataSource3.SelectParameters.Add("@RequestID", System.Data.DbType.String, GridView1.SelectedRow.Cells(2).Text)
                'SqlDataSource3.SelectParameters.Add("@p1", System.Data.DbType.String, "")
                'SqlDataSource3.SelectParameters.Add("@p2", System.Data.DbType.String, "")
                'SqlDataSource3.SelectParameters.Add("@p3", System.Data.DbType.String, "")
                ''SqlDataSource3.DataBind()
                'RadGrid1.DataSource = SqlDataSource3
                'RadGrid1.DataBind()

                '--objFun.FillGrid(qry, )
                qry = "exec Jct_Ops_SanctionNote_Authrization_Detail_ODS '" & Trim(GridView1.SelectedRow.Cells(2).Text) & "','Y'"
                objFun.FillGrid(qry, GrdPricingHIstory)
            End If
            qry = "exec Jct_Ops_SanctionNote_Authrization_Detail_ODS '" & Trim(GridView1.SelectedRow.Cells(2).Text) & "','N'"
            objFun.FillGrid(qry, GrdAuthHistory)


        Catch ex As Exception
            'MsgBox("" & ex.ToString)
            objFun.Alert(ex.Message.ToString)

        End Try


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
            Dim BodyAuthorizationGird As String = ""
            Dim AuthorizedBy As String, SendMailTo As String, Shade As String, Lineno As Int16 = 0
            Dim Subject As String = ""
            Dim Qty As Int32 = 0
            Dim Reqd_Date As String = ""
            Dim Area As String = ""
            Dim CurrentUserName As String = ""
            Dim RaisedByUserName As String = ""
            Dim Scrpt As String = ""
            Dim AuthMob As String = ""
            Dim OutOfOffice As Boolean = False


            CurrentUserName = objFun.FetchValue("Select empname from jct_empmast_base where empcode='" & Session("Empcode") & "'")
            AuthorizedBy = objFun.FetchValue("SELECT E_MailID FROM MISTEL WHERE empcode='" & Session("Empcode") & "'")

            If AuthMob Is Nothing Then
                AuthMob = 0
            End If

            Dim FinalNotify As String = ""
            SendMailTo = ""
            Shade = ""
            Lineno = 0
            Try

                With GridView1

                    If .SelectedIndex > -1 Then
                        If GridView1.SelectedRow.Cells(1).Text <> "" Or GridView1.Rows.Count >= 1 Then
                            SanctionNote = Trim(.SelectedRow.Cells(2).Text)
                            RaisedByUserName = objFun.FetchValue("SELECT b.empname FROM Jct_Ops_SanctionNote_HDR_Test a,dbo.JCT_EmpMast_Base b WHERE a.UserCode=b.empcode AND a.SanctionNoteID='" & SanctionNote & "'")
                            AreaCode = Trim(.SelectedRow.Cells(3).Text)
                            Subject = Trim(.SelectedRow.Cells(6).Text)

                            qry = "SELECT AreaName FROM dbo.Jct_Ops_SanctioNote_Area_Master WHERE Status='A' AND ParentArea='1015' AND AreaCode='" & AreaCode & "'"
                            Area = objFun.FetchValue(qry)
                            ViewState("ID") = SanctionNote



                            Tran = obj.Connection.BeginTransaction
                            con = obj.Connection


                            If AreaCode = "1047" Or AreaCode = "1053" Then
                                qry = "SELECT STUFF((SELECT ',' + s.E_MailID FROM (SELECT 1 ID,E_MailID from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,MISTEL c  WHERE id='" & SanctionNote & "' AND a.EMPCODE=c.empcode  and a.status is null UNION SELECT  1 ID,E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,MISTEL c  WHERE SanctionID='" & SanctionNote & "' AND a.NotifyUser=c.empcode UNION  SELECT  1 ID ,E_MailID FROM    dbo.Jct_Ops_SanctionNote_Notify a ,MISTEL c WHERE   SanctionID = '" & SanctionNote & "' AND a.Usercode = c.empcode  UNION  SELECT  1 ID ,E_MailID FROM  dbo.Jct_Ops_SanctionNote_HDR a , MISTEL c WHERE     SanctionNoteID = '" & SanctionNote & "' AND a.Usercode = c.empcode ) s WHERE s.id = t.id FOR XML PATH('')),1,1,'') AS CSV FROM (SELECT 1 ID,E_MailID FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,MISTEL c  WHERE id='" & SanctionNote & "' AND a.EMPCODE=c.empcode  and a.status is null  UNION SELECT  1 ID,E_MailID FROM dbo.Jct_Ops_SanctionNote_HDR a,MISTEL c  WHERE SanctionNoteID='" & SanctionNote & "' AND a.UserCode=c.empcode ) AS t GROUP BY t.id"
                            Else
                                qry = "SELECT STUFF((SELECT ',' + s.E_MailID FROM (SELECT 1 ID,E_MailID from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING_test a,MISTEL c  WHERE id='" & SanctionNote & "' AND a.EMPCODE=c.empcode  and a.status is null UNION SELECT  1 ID,E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,MISTEL c  WHERE SanctionID='" & SanctionNote & "' AND a.NotifyUser=c.empcode UNION  SELECT  1 ID ,E_MailID FROM    dbo.Jct_Ops_SanctionNote_Notify a ,MISTEL c WHERE   SanctionID = '" & SanctionNote & "' AND a.Usercode = c.empcode  UNION  SELECT  1 ID ,E_MailID FROM  dbo.Jct_Ops_SanctionNote_HDR_test a , MISTEL c WHERE     SanctionNoteID = '" & SanctionNote & "' AND a.Usercode = c.empcode ) s WHERE s.id = t.id FOR XML PATH('')),1,1,'') AS CSV FROM (SELECT 1 ID,E_MailID FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING_test a,MISTEL c  WHERE id='" & SanctionNote & "' AND a.EMPCODE=c.empcode  and a.status is null  UNION SELECT  1 ID,E_MailID FROM dbo.Jct_Ops_SanctionNote_HDR_Test a,MISTEL c  WHERE SanctionNoteID='" & SanctionNote & "' AND a.UserCode=c.empcode ) AS t GROUP BY t.id"
                            End If


                            FinalNotify = objFun.FetchValue(qry, con, Tran)

                            If AreaCode = "1047" Or AreaCode = "1053" Then
                                qry = "Select isnull(convert(varchar,UserLevel),'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE AreaCode='" & AreaCode & "' and id='" & SanctionNote & "' and empcode='" & Session("Empcode") & "'   and status is null"
                            Else
                                qry = "Select isnull(convert(varchar,UserLevel),'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING_test WHERE AreaCode='" & AreaCode & "' and id='" & SanctionNote & "' and empcode='" & Session("Empcode") & "'   and status is null"
                            End If

                            CurrentUserLevel = objFun.FetchValue(qry, con, Tran)

                            If CurrentUserLevel Is Nothing Then CurrentUserLevel = "None"


                            If CurrentUserLevel <> "None" Then
                                If AreaCode = "1047" Or AreaCode = "1053" Then
                                    qry = "Select top 1 isnull(convert(varchar,UserLevel),'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE AreaCode='" & AreaCode & "'  and id='" & SanctionNote & "' and empcode<>'" & Session("Empcode") & "' and userlevel>'" & Val(CurrentUserLevel) & "'  and status is null order by userlevel"
                                Else
                                    qry = "Select top 1 isnull(convert(varchar,UserLevel),'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING_test WHERE AreaCode='" & AreaCode & "'  and id='" & SanctionNote & "' and empcode<>'" & Session("Empcode") & "' and userlevel>'" & Val(CurrentUserLevel) & "'  and status is null order by userlevel"
                                End If
                                NextAuthLevel = objFun.FetchValue(qry, con, Tran)
                            Else
                                objFun.Alert("Unable to Your Authoirze...!!!")

                                Tran.Rollback()
                                Exit Sub
                            End If

                            If AreaCode = "1047" Or AreaCode = "1053" Then
                                qry = "Select top 1 isnull(E_MailID,'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,mistel b WHERE AreaCode='" & AreaCode & "'  and id='" & SanctionNote & "' and a.empcode<>'" & Session("Empcode") & "' and userlevel>='" & Val(CurrentUserLevel) & "' and a.empcode=b.empcode  and a.status is null order by userlevel"
                            Else
                                qry = "Select top 1 isnull(E_MailID,'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING_test a,mistel b WHERE AreaCode='" & AreaCode & "'  and id='" & SanctionNote & "' and a.empcode<>'" & Session("Empcode") & "' and userlevel>='" & Val(CurrentUserLevel) & "' and a.empcode=b.empcode  and a.status is null order by userlevel"
                            End If
                            SendMailTo = objFun.FetchValue(qry, obj.Connection, Tran)

                            If AreaCode = "1047" Or AreaCode = "1053" Then
                                qry = "Select top 1 isnull(convert(varchar,max(UserLevel)),'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE AreaCode='" & AreaCode & "' and  id='" & SanctionNote & "'  AND STATUS is NULL"
                            Else
                                qry = "Select top 1 isnull(convert(varchar,max(UserLevel)),'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING_test WHERE AreaCode='" & AreaCode & "' and  id='" & SanctionNote & "'  AND STATUS is NULL"
                            End If
                            MaxAuthLevel = objFun.FetchValue(qry, con, Tran)

                            If ddlAction.Text = "Cancel" Then
                                If AreaCode = "1047" Or AreaCode = "1053" Then
                                    qry = "SELECT  E_MailID FROM  dbo.Jct_Ops_SanctionNote_HDR a , MISTEL c WHERE     SanctionNoteID = '" & SanctionNote & "' AND a.Usercode = c.empcode "
                                Else
                                    qry = "SELECT  E_MailID FROM  dbo.Jct_Ops_SanctionNote_HDR_test a , MISTEL c WHERE     SanctionNoteID = '" & SanctionNote & "' AND a.Usercode = c.empcode "
                                End If
                                SendMailTo = objFun.FetchValue(qry, obj.Connection, Tran)
                            End If


                            If NextAuthLevel Is Nothing And MaxAuthLevel Is Nothing Then
                                NextAuthLevel = "None"
                                objFun.Alert("Unable to Your Peform Action...!!!")
                                Tran.Rollback()
                                Exit Sub

                            ElseIf NextAuthLevel <> "None" And CurrentUserLevel <> MaxAuthLevel And Left(ddlAction.SelectedItem.Text, 1) = "A" Then
                                Dim NxtAuthEmp As String = ""

                                If AreaCode = "1047" Or AreaCode = "1053" Then
                                    qry = "SELECT isnull(EMPCODE,'') FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE id='" & SanctionNote & "' AND USERLEVEL=" & NextAuthLevel & " AND STATUS IS null "
                                Else
                                    qry = "SELECT isnull(EMPCODE,'') FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING_test WHERE id='" & SanctionNote & "' AND USERLEVEL=" & NextAuthLevel & " AND STATUS IS null "
                                End If
                                NxtAuthEmp = objFun.FetchValue(qry)

                                If (NxtAuthEmp = Nothing Or NxtAuthEmp = "") Then
                                    OutOfOffice = False
                                End If
                                If LCase(NxtAuthEmp) = "m-00063" Then
                                    qry = "SELECT 'True' FROM JCT_OPS_SANCTIONNOTE_OUT_OF_OFFICE WHERE STATUS='A' AND GETDATE() BETWEEN DateFrom AND DateTo and USERCode='m-00063'"
                                    OutOfOffice = objFun.CheckRecordExistInTransaction(qry)
                                End If

                                If AreaCode = "1047" Or AreaCode = "1053" Then
                                    qry = "Update Jct_Ops_SanctionNote_HDR set AuthFlag='P',PendingAt='" & NextAuthLevel & "',LastAuthBy='" & CurrentUserLevel & "',LastAuthOn=getdate() where SanctionNoteID='" & SanctionNote & "' and status='A' and AuthFlag='P'"
                                Else
                                    qry = "Update Jct_Ops_SanctionNote_HDR_Test set AuthFlag='P',PendingAt='" & NextAuthLevel & "',LastAuthBy='" & CurrentUserLevel & "',LastAuthOn=getdate() where SanctionNoteID='" & SanctionNote & "' and status='A' and AuthFlag='P'"
                                End If
                                objFun.UpdateRecord(qry, Tran, con)

                                If AreaCode = "1047" Or AreaCode = "1053" Then
                                    qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set AUTH_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "' and status is null"
                                Else
                                    qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING_test Set AUTH_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "' and status is null"
                                End If
                                objFun.UpdateRecord(qry, Tran, con)



                                If CurrentUserLevel = MaxAuthLevel Then

                                    If ddlAction.Text = "Cancel" Then
                                        Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & SanctionNote & " Is <font color=""Red"">" & ddlAction.SelectedItem.Text & "</font> </h3></b> By <b> " & CurrentUserName & " " ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                                    Else
                                        Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & SanctionNote & " Is " & ddlAction.SelectedItem.Text & " </h3></b> By <b> " & CurrentUserName & " " ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                                    End If



                                Else
                                    If ddlAction.Text = "Cancel" Then
                                        Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & SanctionNote & " Is <font colour=""Red"">" & ddlAction.SelectedItem.Text & "</font> </h3></b> By <b> " & CurrentUserName & " and is now Pending for your Approval" ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                                    Else
                                        Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & SanctionNote & " Is " & ddlAction.SelectedItem.Text & " </h3></b> By <b> " & CurrentUserName & " and is now Pending for your Approval" ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                                    End If

                                End If
                            Else ' Else part will be executed in case when either maxauthlevel is achevied or some one wants to cancel any sanctionnote
                                If AreaCode = "1047" Or AreaCode = "1053" Then
                                    qry = "Update Jct_Ops_SanctionNote_HDR set AuthFlag='" & Left(ddlAction.SelectedItem.Text, 1) & "',PendingAt='',LastAuthBy='" & CurrentUserLevel & "',LastAuthOn=getdate() where SanctionNoteID='" & SanctionNote & "' and status='A'  and AuthFlag='P'"

                                Else
                                    qry = "Update Jct_Ops_SanctionNote_HDR_Test set AuthFlag='" & Left(ddlAction.SelectedItem.Text, 1) & "',PendingAt='',LastAuthBy='" & CurrentUserLevel & "',LastAuthOn=getdate() where SanctionNoteID='" & SanctionNote & "' and status='A'  and AuthFlag='P'"
                                End If
                                objFun.UpdateRecord(qry, Tran, con)



                                If Left(ddlAction.SelectedItem.Text, 1) = "A" Then
                                    If AreaCode = "1047" Or AreaCode = "1053" Then
                                        qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set AUTH_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "' and status is null"
                                    Else
                                        qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING_test Set AUTH_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "' and status is null"
                                    End If
                                    objFun.InsertRecord(qry, Tran, con)

                                    'Comented on 18Dec2013 to remove impact of Cost detail Enterred by HOD '' '' '' '' '' ''With GrdPricingDetail
                                    ' '' '' '' '' '' ''    For i = 0 To .Rows.Count - 1
                                    ' '' '' '' '' '' ''        Dim txtSellingPrice As Telerik.Web.UI.RadNumericTextBox = CType(.Rows(i).FindControl("NewPrice"), Telerik.Web.UI.RadNumericTextBox)
                                    ' '' '' '' '' '' ''        qry = "update Jct_Ops_SanctionNote_CostDetail set SellingPrice='" & txtSellingPrice.Text & "',remarks='" & txtRemarks.Text & "' where SanctionNoteID='" & SanctionNote & "' and UserLevel='" & CurrentUserLevel & "' and ItemNo='" & .Rows(i).Cells(0).Text & "' and variant='" & .Rows(i).Cells(1).Text & "'"
                                    ' '' '' '' '' '' ''        objFun.UpdateRecord(qry, Tran, con)
                                    ' '' '' '' '' '' ''    Next
                                    ' '' '' '' '' '' ''End With
                                Else

                                    If SendMailTo <> "" Then
                                        Dim Sp As String
                                        Sp = ""
                                        If AreaCode = "1047" Or AreaCode = "1053" Then
                                            qry = "Select top 1 isnull(E_MailID,'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,mistel b WHERE AreaCode='" & AreaCode & "'  and id='" & SanctionNote & "' and a.status is null and a.Usercode=b.empcode order by userlevel"
                                        Else
                                            qry = "Select top 1 isnull(E_MailID,'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING_test a,mistel b WHERE AreaCode='" & AreaCode & "'  and id='" & SanctionNote & "' and a.status is null and a.Usercode=b.empcode order by userlevel"
                                        End If
                                        Sp = objFun.FetchValue(qry, obj.Connection, Tran)
                                        If Sp Is Nothing Then Sp = ""
                                        If Sp <> "" Then SendMailTo = SendMailTo & "," & Sp
                                    End If
                                    If AreaCode = "1047" Or AreaCode = "1053" Then
                                        qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set CANCEL_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "' and status is null"
                                    Else
                                        qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING_test Set CANCEL_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "' and status is null"
                                    End If
                                    objFun.InsertRecord(qry, Tran, con)


                                    If AreaCode = "1053" Then
                                        '--Jct_Ops_Excess_Stock_Selling_Request_t
                                        qry = "Update Jct_Ops_Excess_Stock_Selling_Request_t set STATUS='D',DeletedBy='" & Session("Empcode") & "',DeletedOnHost='" & Request.ServerVariables("REMOTE_ADDR") & "',DeletionDate=GETDATE() WHERE RequestID='" & SanctionNote & "'"
                                        objFun.UpdateRecord(qry, Tran, obj.Connection)

                                        qry = "UPDATE b SET Marked=NULL from Jct_Ops_Excess_Stock_Selling_Request_t a, Production..Jct_Ops_Excess_Stock_Bale_Status_t  b WHERE a.Bale_No=b.Bale_no AND a.Varaint=b.Variant AND a.STATUS='A' AND b.STATUS='A' AND ISNULL(TransID,'')<>'' and RequestID='" & SanctionNote & "' "
                                        objFun.UpdateRecord(qry, Tran, obj.Connection)
                                    End If


                                End If

                                Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & SanctionNote & " Is " & ddlAction.SelectedItem.Text & " </h3></b> By <b> " & CurrentUserName & " " ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"


                                'qry = "UPDATE  Production..Jct_Ops_Excess_Stock_Bale_Status_t   SET     Deletedby = '" & Session("Empcode") & "' ,   DeletedOnHost = '" & Request.ServerVariables("REMOTE_ADDR") & "' ,  STATUS = 'D'   WHERE   TransID = '" & SanctionNote & "'   AND STATUS = 'A'     "
                                'cmd = New SqlCommand(qry, obj.Connection, Tran)
                                'cmd.ExecuteNonQuery()


                            End If

                            qry = "Exec Production..Jct_Ops_Excess_Stock_Log_insert '','','" & Session("Empcode") & "','','" & String.Concat("Request ", ddlAction.SelectedItem.Text) & "' ,'" & ddlAction.SelectedItem.Text.Substring(0, 1).ToString() & "','" & SanctionNote & "'"
                            cmd = New SqlCommand(qry, obj.Connection, Tran)
                            cmd.ExecuteNonQuery()


                         




                            Tran.Commit()
                            'Tran.Rollback()




                            If (Left(ddlAction.SelectedItem.Text, 1) = "A") Then

                                Scrpt = "alert('SanctionNote has been Authorized..!!');"
                            Else
                                Scrpt = "alert('SanctionNote has been Cancelled..!!');"

                            End If

                            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)

                            If (Left(ddlAction.SelectedItem.Text, 1) = "A") Then

                                objFun.Alert("SanctionNote has been Authorized..!!")
                            Else
                                objFun.Alert("SanctionNote has been Cancelled..!!")
                            End If


                            Try
                                Dim sm As New SendMail
                                If CurrentUserLevel = MaxAuthLevel Then
                                    'Code To Send SMS to SalePerson Raising the Sanction Note
                                    If AreaCode = "1047" Or AreaCode = "1053" Then
                                        AuthMob = objFun.FetchValue("SELECT b.mobile,b.name FROM mistel b,dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a WHERE a.Usercode=b.empcode  AND a.ID='" & SanctionNote & "' and a.status is null")
                                    Else
                                        AuthMob = objFun.FetchValue("SELECT b.mobile,b.name FROM mistel b,dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING_test a WHERE a.Usercode=b.empcode  AND a.ID='" & SanctionNote & "' and a.status is null")
                                    End If

                                Else
                                    If AreaCode = "1047" Or AreaCode = "1053" Then
                                        AuthMob = objFun.FetchValue("SELECT b.mobile,b.name FROM mistel b,dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a WHERE a.EMPCODE=b.empcode AND a.userlevel=" & NextAuthLevel & " AND a.ID='" & SanctionNote & "'  and a.status is null")
                                    Else
                                        AuthMob = objFun.FetchValue("SELECT b.mobile,b.name FROM mistel b,dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING_test a WHERE a.EMPCODE=b.empcode AND a.userlevel=" & NextAuthLevel & " AND a.ID='" & SanctionNote & "'  and a.status is null")
                                    End If


                                End If

                                Dim msg As String = "Sanction Note " & SanctionNote & " is due for approval. It was last approved by " & CurrentUserName & " and raised by " & RaisedByUserName

                                'If Len(AuthMob) >= 10 Then
                                '    sm.SendSMS(Session("CompanyCode"), Session("EmpCode"), AuthMob, msg, "SanctionNote " & ddlAction.SelectedItem.Text & "ation Sent")
                                'End If
                            Catch
                                Scrpt = "alert('Unable to Send SMS Alert...!!!');"
                                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
                            End Try

                            If AreaCode = 9999 Then

                            Else ' Else part executed for all sanction note other than Exceptions
                                Try
                                    If AreaCode = "1047" Or AreaCode = "1053" Then
                                        qry = "SELECT DESCRIPTION FROM dbo.Jct_Ops_SanctionNote_HDR WHERE SanctionNoteID='" & SanctionNote & "' AND STATUS='A'"
                                    Else
                                        qry = "SELECT DESCRIPTION FROM dbo.Jct_Ops_SanctionNote_HDR_Test WHERE SanctionNoteID='" & SanctionNote & "' AND STATUS='A'"
                                    End If

                                    Dim Body1 As String = "Subject Mentioned :- " & Subject & " <hr><br><br> Under Area :-" & Area & " <BR> <HR> <b>With below detailed Info :-</b>" & objFun.FetchValue(qry) & " <hr>"
                                    Dim BodyAuth As String
                                    Dim Val1 As String = ""
                                    Dim ParmName As String = ""
                                    'For i = 0 To grdRequestDetail.Rows.Count - 1
                                    '    ParmName = grdRequestDetail.Rows(i).Cells(0).Text
                                    '    Val1 = grdRequestDetail.Rows(i).Cells(1).Text
                                    '    Body1 = Body1 & "<p> <b>" & ParmName & " :-</b> " & Val1 & " </p> "
                                    'Next

                                    Body1 = Body1 & "<html>"
                                    Body1 = Body1 & "<head>"
                                    Body1 = Body1 & "<style type=""text/css"">"
                                    Body1 = Body1 & " table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}"
                                    Body1 = Body1 & " table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}"
                                    Body1 = Body1 & "table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}"
                                    Body1 = Body1 & "</style>"
                                    Body1 = Body1 & "</head>"

                                    Body1 = Body1 & "<table class=gridtable>"

                                    Dim GridHeader As String = ""
                                    Dim Q As String = ""
                                    Dim J As Int16 = 0
                                    Dim RequestDEtailCount As Int16 = 0
                                    If Area = "Excess Stock Transfer" Then
                                        RequestDEtailCount = 12
                                    Else
                                        RequestDEtailCount = 9
                                    End If
                                    With grdRequestDetail


                                        For i = 0 To grdRequestDetail.Rows.Count - 1

                                            Q = "<tr>"
                                            'This if is used to Fetch Header from Gridview
                                            If i = 0 Then
                                                For J = 1 To RequestDEtailCount '.Columns.Count

                                                    GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"

                                                Next
                                                Body1 = Body1 & GridHeader & " </tr>"
                                            End If

                                            'This loops feteches data from each cell of grid
                                            For J = 1 To RequestDEtailCount '.Columns.Count
                                                If i = 0 Then
                                                    'query += "<th>" & .Rows(i).Cells(J).Text & "</th>"
                                                    GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"
                                                End If
                                                Q += "<td>" & .Rows(i).Cells(J).Text & "</td>"
                                            Next
                                            Body1 = Body1 & Q & " </tr>"

                                        Next
                                    End With


                                    Body1 = Body1 & " </table>"
                                    Body1 = Body1 & " <br /></html>"
                                    BodyAuthorizationGird = ""
                                    BodyAuthorizationGird = BodyAuthorizationGird & " Authorization Remarks are Shown below: <br/><br/>"
                                    BodyAuthorizationGird = BodyAuthorizationGird & "<head>"
                                    BodyAuthorizationGird = BodyAuthorizationGird & "<style type=""text/css"">"
                                    BodyAuthorizationGird = BodyAuthorizationGird & "  table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}"
                                    BodyAuthorizationGird = BodyAuthorizationGird & " table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}"
                                    BodyAuthorizationGird = BodyAuthorizationGird & "table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}"
                                    BodyAuthorizationGird = BodyAuthorizationGird & "</style>"
                                    BodyAuthorizationGird = BodyAuthorizationGird & "</head>"


                                    BodyAuthorizationGird = BodyAuthorizationGird & "<table class=gridtable>"

                                    GridHeader = ""
                                    Q = ""
                                    J = 0
                                    BodyAuth = ""
                                    With GrdAuthHistory


                                        For i = 0 To GrdAuthHistory.Rows.Count - 2

                                            Q = "<tr>"
                                            'Q = ""
                                            'This if is used to Fetch Header from Gridview
                                            If i = 0 Then
                                                For J = 0 To 4 '.Columns.Count

                                                    GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"

                                                Next
                                                BodyAuth = BodyAuth & GridHeader & " </tr>"
                                            End If

                                        Next
                                        qry = "exec Jct_Ops_SanctionNote_Authrization_Detail_ODS '" & SanctionNote & "','N'"

                                        cmd = New SqlCommand(qry, obj.Connection)
                                        dr = cmd.ExecuteReader

                                        While dr.Read
                                            Q += "<tr><td>" & dr.Item(0).ToString & "</td>"
                                            Q += "<td>" & dr.Item(1).ToString & "</td>"
                                            Q += "<td>" & dr.Item(2).ToString & "</td>"
                                            Q += "<td>" & dr.Item(3).ToString & "</td>"
                                            Q += "<td>" & dr.Item(4).ToString & "</td></tr>"
                                        End While
                                        dr.Close()
                                        'This loops feteches data from each cell of grid
                                        '' '' '' '' '' '' '' '' '' '' ''For J = 0 To 4 '.Columns.Count
                                        '' '' '' '' '' '' '' '' '' '' ''    If i = 0 Then
                                        '' '' '' '' '' '' '' '' '' '' ''        'query += "<th>" & .Rows(i).Cells(J).Text & "</th>"
                                        '' '' '' '' '' '' '' '' '' '' ''        GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"
                                        '' '' '' '' '' '' '' '' '' '' ''    End If
                                        '' '' '' '' '' '' '' '' '' '' ''    Q += "<td>" & .Rows(i).Cells(J).Text & "</td>"
                                        '' '' '' '' '' '' '' '' '' '' ''Next
                                        BodyAuth = BodyAuth & Q
                                    End With
                                    BodyAuthorizationGird = BodyAuthorizationGird & " " & BodyAuth
                                    'BodyAuthorizationGird=BodyAuthorizationGird & " " "<table class=gridtable>")
                                    'BodyAuthorizationGird=BodyAuthorizationGird & " " "<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th> Auth. Pending At</th> </tr>")



                                    BodyAuthorizationGird = BodyAuthorizationGird & "</table>"
                                    BodyAuthorizationGird = BodyAuthorizationGird & "<br />"


                                    Dim BodyAuthorizationGird1 As String = ""

                                    If Area = "Excess Stock Sell Request" Then
                                        BodyAuthorizationGird1 = BodyAuthorizationGird1 & "<br /> <b> Remarks given :- </b> " & txtRemarks.Text & "<br/><br/>"
                                    Else
                                        BodyAuthorizationGird = BodyAuthorizationGird & "<br /> <b> Remarks given :- </b> " & txtRemarks.Text & "<br/><br/>"
                                    End If














                                    'Area = "Excess Stock Transfer"
                                    '  If Area = "Excess Stock Transfer" Then
                                    If Area = "Excess Stock Sell Request" Then

                                        BodyAuthorizationGird = ""
                                        BodyAuthorizationGird1 = BodyAuthorizationGird1 & "<br> Bale Wise Detail of the request is shown below <br/><br/>"
                                        BodyAuthorizationGird1 = BodyAuthorizationGird1 & "<head>"
                                        BodyAuthorizationGird1 = BodyAuthorizationGird1 & "<style type=""text/css"">"
                                        BodyAuthorizationGird1 = BodyAuthorizationGird1 & "table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}"
                                        BodyAuthorizationGird1 = BodyAuthorizationGird1 & " table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}"
                                        BodyAuthorizationGird1 = BodyAuthorizationGird1 & "table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}"
                                        BodyAuthorizationGird1 = BodyAuthorizationGird1 & "</style>"
                                        BodyAuthorizationGird1 = BodyAuthorizationGird1 & "</head>"


                                        BodyAuthorizationGird1 = BodyAuthorizationGird1 & "<table class=gridtable>"

                                        GridHeader = ""
                                        Q = ""
                                        J = 0
                                        BodyAuth = ""





                                        Q = "<tr>"
                                        'Q = ""
                                        'This if is used to Fetch Header from Gridview


                                        GridHeader += "<th> Item_no </th><th> Bale_No </th><th> Varaint </th><th> Meters </th><th> Shade </th><th> RequestID </th>"


                                        BodyAuth = BodyAuth & GridHeader & " </tr>"




                                        qry = "SELECT Item_no,Bale_No,Varaint,Meters,Shade,RequestID FROM Jct_Ops_Excess_Stock_Selling_Request_t WHERE RequestID ='" & SanctionNote & "'"
                                        cmd = New SqlCommand(qry, obj.Connection)
                                        dr = cmd.ExecuteReader

                                        While dr.Read
                                            Q += "<tr><td>" & dr.Item(0).ToString & "</td>"
                                            Q += "<td>" & dr.Item(1).ToString & "</td>"
                                            Q += "<td>" & dr.Item(2).ToString & "</td>"
                                            Q += "<td>" & dr.Item(3).ToString & "</td>"
                                            Q += "<td>" & dr.Item(4).ToString & "</td>"
                                            Q += "<td>" & dr.Item(5).ToString & "</td></tr>"
                                        End While
                                        dr.Close()
                                        'This loops feteches data from each cell of grid
                                        '' '' '' '' '' '' '' '' '' '' ''For J = 0 To 4 '.Columns.Count
                                        '' '' '' '' '' '' '' '' '' '' ''    If i = 0 Then
                                        '' '' '' '' '' '' '' '' '' '' ''        'query += "<th>" & .Rows(i).Cells(J).Text & "</th>"
                                        '' '' '' '' '' '' '' '' '' '' ''        GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"
                                        '' '' '' '' '' '' '' '' '' '' ''    End If
                                        '' '' '' '' '' '' '' '' '' '' ''    Q += "<td>" & .Rows(i).Cells(J).Text & "</td>"
                                        '' '' '' '' '' '' '' '' '' '' ''Next
                                        BodyAuth = BodyAuth & Q

                                        BodyAuthorizationGird1 = BodyAuthorizationGird1 & " " & BodyAuth
                                        'BodyAuthorizationGird=BodyAuthorizationGird & " " "<table class=gridtable>")
                                        'BodyAuthorizationGird=BodyAuthorizationGird & " " "<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th> Auth. Pending At</th> </tr>")



                                        BodyAuthorizationGird1 = BodyAuthorizationGird1 & "</table>"
                                        BodyAuthorizationGird1 = BodyAuthorizationGird1 & "<br />"

                                    End If



























                                    Body3 = "<br/><a href='http://misdev/fusionapps/OPS/AuthorizeSanction_Note.aspx'> Click here to view details... </a><br /><br /> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"

                                    SendMail(Body, Body1, Body3, "", SendMailTo, AuthorizedBy, "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "This SanctionNote :-" & SanctionNote & "  has been " & ddlAction.SelectedItem.Text & "", SanctionNote, CurrentUserLevel, MaxAuthLevel, FinalNotify, ddlAction.SelectedItem.Text, BodyAuthorizationGird & BodyAuthorizationGird1, Area)

                                Catch
                                    Scrpt = "alert('Unable to Send E-Mail Alert...!!!');"
                                    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
                                End Try
                            End If
                            RefreshLists()

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
                ' ObjSendMail.SendMail("Ashish@jctltd.com", "devlopment@jctltd.com", "Error in Authorizing SanctionNote !!!", "The sanction note no " & SanctionNote & "was under authorization process but some error was genrated.....<br> " & ex.ToString)
                Tran.Rollback()
            End Try

        Catch ex As Exception

            Dim Scrpt As String = "alert('" + ex.Message + "');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)

        End Try

    End Sub


    Private Sub RefreshLists()
        DataList1.DataSource = Nothing
        DataBind()

        DataList1.DataSourceID = "SqlDataSource2"
        DataBind()

        GridView1.DataSource = Nothing
        GridView1.DataBind()

        grdRequestDetail.DataSource = Nothing
        grdRequestDetail.DataBind()

        GrdAuthHistory.DataSource = Nothing
        GrdAuthHistory.DataBind()
    End Sub

    Private Sub SendMail(Body__1 As String, Body2 As String, body3 As String, RaisedBy_Email As String, [to] As String, cc As String, bcc As String, Subject As String, SanctionNote As String, CurrentLevel As Int16, MaxLevel As Int16, NotifyAllList As String, Action As String, BodyAuthorizationGird As String, AreaName As String)
        Try
            Dim from As String
            Dim sb As New StringBuilder()
            from = "ODS@jctltd.com"
            Dim query As String = ""
            Dim SenderEmail As String = ""

            If RaisedBy_Email Is Nothing Then
                RaisedBy_Email = ""
            End If

            SenderEmail = [to] 'objFun.FetchValue(query)
            If SenderEmail Is Nothing Then SenderEmail = ""

            If SenderEmail <> "" Then
                [to] = SenderEmail '& " Comented by Ashish on 2nd Feb," & RaisedBy_Email
            Else
                [to] = RaisedBy_Email
            End If
            If CurrentLevel = MaxLevel And CurrentLevel > 0 And Action = "Authorize" Then
                [to] = NotifyAllList
                If Trim(AreaName) = "Excess Stock Sell Request" Then
                    [to] = [to] & ",william@jctltd.com,kaushal@jctltd.com"

                ElseIf Trim(AreaName) = "Excess Stock Transfer" Then
                    [to] = [to] & ",william@jctltd.com,kaushal@jctltd.com"
                End If
            End If

            If Trim(AreaName) = "Excess Stock Sell Request" Then
                [to] = [to] & ",william@jctltd.com,kaushal@jctltd.com"

            ElseIf Trim(AreaName) = "Excess Stock Transfer" Then
                [to] = [to] & ",william@jctltd.com,kaushal@jctltd.com"
            End If



            If CurrentLevel = MaxLevel And CurrentLevel > 0 And Action = "Authorize" Then
                [to] = NotifyAllList & ",william@jctltd.com,kaushal@jctltd.com"
                
            End If

            'If Trim(GridView1.SelectedRow.Cells(4).Text) = "Excess Stock Sell Request" Then
            '    [to] = [to] & ",william@jctltd.com,kaushal@jctltd.com"

            'ElseIf Trim(GridView1.SelectedRow.Cells(4).Text) = "Excess Stock Transfer" Then
            '    [to] = [to] & ",william@jctltd.com,kaushal@jctltd.com"
            'End If



            bcc = "ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com"


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
            mail.Body = Body__1 & " " & Body2 & " " & BodyAuthorizationGird & " " & body3
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






            Dim SmtpMail As New SmtpClient("exchange2007")
            '[to] = "ashish@jctltd.com"

            '
            SmtpMail.Send(mail)
        Catch ex As Exception
            Dim Scrpt As String = "alert('" + ex.Message + "');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
        End Try
    End Sub



    Protected Sub LinkButton1_Click(sender As Object, e As System.EventArgs) Handles LinkButton1.Click
        ' SendMail()
    End Sub

    Protected Sub DataList1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DataList1.SelectedIndexChanged

    End Sub

    Protected Sub grdRequestDetail_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRequestDetail.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Left(e.Row.Cells(6).Text, 5) = "Total" Then
                e.Row.CssClass = "GridAI"
            End If
        End If
    End Sub

    Protected Sub ChkAsPerReq_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim GrdRow As GridViewRow
        'Dim GrdRowIndex As Int16 = 0
        Dim Chk As CheckBox
        Chk = sender
        GrdRow = CType(Chk.Parent.Parent, GridViewRow)
        qry = "SELECT SellingPrice FROM Jct_Ops_SanctionNote_CostDetail WHERE SanctionNoteID='" & Trim(GridView1.SelectedRow.Cells(2).Text) & "' and ItemNo='" & GrdPricingDetail.Rows(GrdRow.RowIndex).Cells(0).Text & "'"
        If Chk.Checked = True Then
            CType(GrdPricingDetail.Rows(GrdRow.RowIndex).FindControl("NewPrice"), Telerik.Web.UI.RadNumericTextBox).Text = objFun.FetchValue(qry)
        Else
            CType(GrdPricingDetail.Rows(GrdRow.RowIndex).FindControl("NewPrice"), Telerik.Web.UI.RadNumericTextBox).Text = ""
        End If

    End Sub
End Class
