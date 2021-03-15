Imports System
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Net.Mail
Imports System.Data

Partial Class OPS_AuthorizeSanction_Note
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
        If (Session("empcode").ToString = "") Then
            Response.Redirect("~/login.aspx")
        End If
        If Not IsPostBack Then

        End If

        Dim AreaName As String = ""
        If (String.IsNullOrEmpty(Request.QueryString("AreaName")) = False) Then

            AreaName = Request.QueryString("AreaName")
            GrdSanctionNoteDetail.DataSource = Nothing
            GrdSanctionNoteDetail.DataBind()
            'qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' and b.areaName='" & AreaName & "' and a.UserCode='" & Session("Empcode") & "'"
            qry = "Jct_Ops_Pending_Authorization_Fetch '" & Session("Empcode") & "','" & AreaName & "'"
            objFun.FillGrid(qry, GridView1)

            ' remove query string
            Dim isreadonly As PropertyInfo = _
            GetType(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance Or BindingFlags.NonPublic)

            ' make collection editable
            isreadonly.SetValue(Me.Request.QueryString, False, Nothing)

            ' remove
            Me.Request.QueryString.Remove("AreaName")


        End If
        'If Session("empcode") = "A-00098" Or Session("empcode") = "P-03055" Then
        '    Panel2.Visible = True
        'Else
        '    Panel2.Visible = False
        'End If
    End Sub

    Protected Sub DataList1_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.ItemCommand
        Dim AreaName As String = ""
        GrdSanctionNoteDetail.DataSource = Nothing
        GrdSanctionNoteDetail.DataBind()
        If (String.IsNullOrEmpty(Request.QueryString("AreaName")) = False) Then

            AreaName = Request.QueryString("AreaName")
            GrdSanctionNoteDetail.DataSource = Nothing
            GrdSanctionNoteDetail.DataBind()
            'qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' and b.areaName='" & AreaName & "'"
            'Comented on 31-Dec-2012 qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c,Jct_Ops_SanctioNote_Area_Emp_Auth_Listing d WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' AND a.authFlag='P' AND a.PendingAt=d.UserLevel and b.areaName='" & AreaName & "' AND ( 1 = ( SELECT TOP 1 1 FROM    production..role_user_mapping WHERE   role = '100' AND uname = '" & Session("Empcode") & "') OR d.EmpCode = '" & Session("Empcode") & "') AND b.AreaCode = d.AreaCode "
            qry = "Jct_Ops_Pending_Authorization_Fetch '" & Session("Empcode") & "','" & AreaName & "'"

            objFun.FillGrid(qry, GridView1)
            objFun.FillGrid(qry, GridView1)
            Request.QueryString.Clear()
        Else

            If e.CommandName = "Select" Then
                AreaName = CType(e.Item.FindControl("cmdArea"), LinkButton).Text
                If AreaName <> "" And AreaName <> "Greigh Transfer" Then
                    GridView1.DataSource = Nothing
                    GridView1.DataBind()
                    GridView1.SelectedIndex = -1
                    GrdSanctionNoteDetail.DataSource = Nothing
                    GrdSanctionNoteDetail.DataBind()
                    'qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' and b.areaName='" & AreaName & "'"
                    'Comented on 31-Dec-2012 qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c,Jct_Ops_SanctioNote_Area_Emp_Auth_Listing d WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' AND a.authFlag='P' AND a.PendingAt=d.UserLevel and b.areaName='" & AreaName & "' AND ( 1 = ( SELECT TOP 1 1 FROM    production..role_user_mapping WHERE   role = '100' AND uname = '" & Session("Empcode") & "') OR d.EmpCode = '" & Session("Empcode") & "') AND b.AreaCode = d.AreaCode "
                    qry = "Jct_Ops_Pending_Authorization_Fetch '" & Session("Empcode") & "','" & AreaName & "'"
                    objFun.FillGrid(qry, GridView1)

                Else
                    Response.Redirect("AuthorizeSanctionNote10.aspx")
                End If
            End If

        End If



    End Sub


    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        'Comented on 31-Dec-2012   qry = "SELECT b.ParmName,b.ParmDesc,a.Val as [Values] FROM dbo.Jct_Ops_SanctionNote_Dtl a,dbo.Jct_Ops_SanctionNote_Parameters b WHERE SanctionNoteID='" & Trim(GridView1.SelectedRow.Cells(1).Text) & "' AND b.STATUS='A' AND GETDATE() BETWEEN b.Eff_From AND b.Eff_To  AND a.ParamCode=b.ParamCode"
        qry = "Exec Jct_Ops_Pending_Authorization_Fetch_Detail '" & Trim(GridView1.SelectedRow.Cells(1).Text) & "','" & Trim(GridView1.SelectedRow.Cells(2).Text) & "'"
        objFun.FillGrid(qry, GrdSanctionNoteDetail)
        qry = "exec Jct_Ops_SanctionNote_Authrization_Detail '" & Trim(GridView1.SelectedRow.Cells(1).Text) & "'"
        objFun.FillGrid(qry, GrdAuthHistory)
        'If Trim(GridView1.SelectedRow.Cells(3).Text) = "Exception" Then
        '    Panel1.Visible = True
        'Else
        '    Panel1.Visible = False
        'End If
    End Sub

    Protected Sub CmdAuthorize_Click(sender As Object, e As System.EventArgs) Handles CmdAuthorize.Click
        Dim NextAuthLevel As String = "None"
        Dim MaxAuthLevel As String = "None"
        Dim CurrentUserLevel As String = ""
        Dim AreaCode As String = ""
        Dim SanctionNote As String = ""
        Dim SalePersonCode As String = ""
        Dim SalePersonEmail As String = "ashish@jctltd.com"
        Dim Body As String = ""
        Dim Body3 As String = ""
        Dim RaisedBy As String, SendMailTo As String, Shade As String, Lineno As Int16 = 0
        Dim Qty As Int32 = 0
        Dim Reqd_Date As String = ""
        Dim Area As String = ""
        Dim UserName As String = ""
        UserName = objFun.FetchValue("Select empname from jct_empmast_base where empcode='" & Session("Empcode") & "'")
        RaisedBy = objFun.FetchValue("SELECT E_MailID FROM MISTEL WHERE empcode='" & Session("Empcode") & "'")
        SendMailTo = ""
        Shade = ""
        Lineno = 0
        Try

            With GridView1

                If .SelectedIndex > -1 Then
                    If GridView1.SelectedRow.Cells(1).Text <> "" Or GridView1.Rows.Count >= 1 Then
                        SanctionNote = Trim(.SelectedRow.Cells(1).Text)
                        AreaCode = Trim(.SelectedRow.Cells(2).Text)

                        If AreaCode = 1014 Then

                            Try
                                ViewState("ID") = SanctionNote
                                qry = "JCT_OPS_SANCTION_NOTE_MATERIAL_RETURN_REASONS_AUTHORIZATION"
                                Dim cmd As SqlCommand = New SqlCommand(qry, obj.Connection())
                                cmd.CommandType = Data.CommandType.StoredProcedure
                                cmd.Parameters.Add("@AreaCode", SqlDbType.Int).Value = 1014
                                cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 10).Value = Session("EmpCode")
                                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = SanctionNote
                                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 100).Value = txtRemarks.Text
                                cmd.ExecuteNonQuery()
                                Dim Script As String = "alert('Record Authorized Successfully..!!');"
                                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", Script, True)
                                SendMail()
                            Catch ex As Exception
                                Dim Script As String = "alert('Some Error Occured..!!');"
                                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", Script, True)
                                Exit Sub
                            End Try
                            Exit Sub
                        End If

                        Tran = obj.Connection.BeginTransaction
                        con = obj.Connection
                        If AreaCode = 9999 Then
                            Area = Trim(.SelectedRow.Cells(5).Text)
                            Area = Area.Substring(Area.IndexOf("~ ") + 2, Area.IndexOf(" -") - Area.IndexOf("~ ") - 2)

                            'OrderNo = GrdSanctionNoteDetail.Rows(0).Cells(1).Text
                            'Sort = GrdSanctionNoteDetail.Rows(0).Cells(2).Text
                            Shade = GrdSanctionNoteDetail.Rows(0).Cells(3).Text
                            Lineno = GrdSanctionNoteDetail.Rows(0).Cells(4).Text
                            Qty = GrdSanctionNoteDetail.Rows(0).Cells(5).Text
                            Reqd_Date = GrdSanctionNoteDetail.Rows(0).Cells(5).Text
                        End If
                        If AreaCode <> 9999 Then
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

                            qry = "Select top 1 isnull(convert(varchar,max(UserLevel)),'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE AreaCode='" & AreaCode & "' and  id='" & SanctionNote & "'  AND STATUS is NULL"
                            MaxAuthLevel = objFun.FetchValue(qry, con, Tran)

                            'Added on  Jan -8 to include  P.G Mohan authorization 

                            'If CurrentUserLevel = MaxAuthLevel And "a" = "p-03055" Then
                            '    qry = "INSERT INTO Jct_Ops_SanctionNote_FinalAuthrization_Details(SanctionNoteID ,UserCode ,ParmCode ,ParmName ,Val ,Created_Date ,STATUS ,CreatedOnHost) values('" & SanctionNote & "','" & Session("Empcode") & "','','" & lblTransport.Text & "','" & ddlFinalMode.SelectedItem.Value & "',getdate(),'A','" & Request.ServerVariables("REMOTE_ADDR") & "')"
                            '    objFun.InsertRecord(qry, Tran, obj.Connection)
                            '    qry = "INSERT INTO Jct_Ops_SanctionNote_FinalAuthrization_Details(SanctionNoteID ,UserCode ,ParmCode ,ParmName ,Val ,Created_Date ,STATUS ,CreatedOnHost) values('" & SanctionNote & "','" & Session("Empcode") & "','','" & lblFreightVal.Text & "','" & txtFinalFreightVal.Text & "',getdate(),'A','" & Request.ServerVariables("REMOTE_ADDR") & "')"
                            '    objFun.InsertRecord(qry, Tran, obj.Connection)
                            'End If Removed on 30-jan-2013

                            If NextAuthLevel Is Nothing And MaxAuthLevel Is Nothing Then
                                NextAuthLevel = "None"
                                objFun.Alert("Unable to Your Peform Action...!!!")
                                Tran.Rollback()
                                Exit Sub

                            ElseIf NextAuthLevel <> "None" And CurrentUserLevel <> MaxAuthLevel And Left(ddlAction.SelectedItem.Text, 1) = "A" Then

                                qry = "Update Jct_Ops_SanctionNote_HDR set AuthFlag='P',PendingAt='" & NextAuthLevel & "',LastAuthBy='" & CurrentUserLevel & "',LastAuthOn=getdate() where SanctionNoteID='" & SanctionNote & "' and status='A' and AuthFlag='P'"
                                objFun.UpdateRecord(qry, Tran, con)

                                'If Left(ddlAction.SelectedItem.Text, 1) = "A" Then
                                qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set AUTH_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "'"
                                'Else
                                '    qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set CANCEL_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "'"
                                'End If
                                objFun.UpdateRecord(qry, Tran, con)

                                Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & SanctionNote & " Is " & ddlAction.SelectedItem.Text & " </h3></b> By <b> " & UserName & " and is now Pending for your Approval" ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"

                            Else ' Else part will be executed in case when either maxauthlevel is achevied or some one wants to cancel any sanctionnote
                                qry = "Update Jct_Ops_SanctionNote_HDR set AuthFlag='" & Left(ddlAction.SelectedItem.Text, 1) & "',PendingAt='',LastAuthBy='" & CurrentUserLevel & "',LastAuthOn=getdate() where SanctionNoteID='" & SanctionNote & "' and status='A'  and AuthFlag='P'"
                                objFun.UpdateRecord(qry, Tran, con)

                                'If Left(ddlAction.SelectedItem.Text, 1) = "A" Then
                                '    qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL ,AUTH_DATETIME,CREATED_ONHOST ,Remarks) values('" & SanctionNote & "','" & Session("Empcode") & "','" & AreaCode & "','" & Session("Empcode") & "','" & CurrentUserLevel & "',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "')"
                                'Else
                                '    qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL ,CANCEL_DATETIME,CREATED_ONHOST ,Remarks) values('" & SanctionNote & "','" & Session("Empcode") & "','" & AreaCode & "','" & Session("Empcode") & "','" & CurrentUserLevel & "',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "')"
                                'End If
                                'If Left(ddlAction.SelectedItem.Text, 1) = "A" Then
                                '    qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set AUTH_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "'"
                                'Else
                                qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set CANCEL_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "'"
                                'End If
                                objFun.InsertRecord(qry, Tran, con)

                                Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & SanctionNote & " Is " & ddlAction.SelectedItem.Text & " </h3></b> By <b> " & UserName & " and is now Pending for your Approval" ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                            End If
                        Else '-----Will be executed when Exceptions are ment to be authorised or Unauthorized
                            qry = "update Jct_Ops_Process_Plan_Exception set PendingAt='',LastAuthBy='" & Session("Empcode") & "',LastAuthOn=getdate(),AuthFlag='" & Left(ddlAction.SelectedItem.Text, 1) & "',IntialAuthRemarks='" & txtRemarks.Text & "'  WHERE STATUS='A' AND LastAuthBy IS NULL and ExceptionID=" & SanctionNote & ""
                            objFun.InsertRecord(qry, Tran, con)
                            ''Body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b> " '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Line & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>Finishing</P> <b>Meters :-" & DyngQty & "</b> was Planned to be <b>Dyed on :-</b> '" & ReqDyngDate & "' <br><hr><br><br><P>Finishing</P> Meter Planned for Finishing are :-</b> '" & FinsihQty & "' <b>On Date </b> '" & ReqFinishDate & "'  <h3>This Order Has been Removed from Dyeing and Finish (Processing) Plan by '" & Removedby & "' </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                            Body = "<p>Hello.....,</p>This Order has been approved for re-scheduling in " & Area & " is <B>Pending At Planning's Approval </b><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)", obj.Connection, Tran)) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3>  <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                        End If


                        'qry = "SELECT isnull(MAX(USERLEVEL)+1,999) FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING  WHERE id='" & SanctionNote & "' AND AREACODE='" & AreaCode & "' AND STATUS IS null"
                        'CurrentUserLevel = objFun.FetchValue(qry, con, Tran)
                        If AreaCode = 9999 Then
                            objFun.SendMailOPS(Body, "", SalePersonEmail, Session("Empcode"), "ashish@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your orderNO :-""  SortNo :-  ""' Shade :-  " & Shade & " was Reequested be Re-Planned in " & Area & " section and the request was generated by  " & UserName)
                        Else ' Else part executed for all sanction note other than Exceptions
                            qry = "Select top 1 isnull(E_MailID,'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,mistel b WHERE AreaCode='" & AreaCode & "'  and id='" & SanctionNote & "' and a.empcode<>'" & Session("Empcode") & "' and userlevel>'" & Val(CurrentUserLevel) & "' and a.empcode=b.empcode order by userlevel"
                            SendMailTo = objFun.FetchValue(qry, obj.Connection, Tran)
                            Dim Body1 As String = ""
                            Dim Val1 As String = ""
                            Dim ParmName As String = ""
                            For i = 0 To GrdSanctionNoteDetail.Rows.Count - 1
                                ParmName = GrdSanctionNoteDetail.Rows(i).Cells(0).Text
                                Val1 = GrdSanctionNoteDetail.Rows(i).Cells(1).Text
                                Body1 = Body1 & "<p> <b>" & ParmName & " :-</b> " & Val1 & " </p> "
                            Next
                            Body3 = " <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"

                            SendMail(Body, Body1, "", RaisedBy, SendMailTo, "ashish@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "This SanctionNote :-" & SanctionNote & "  has been " & ddlAction.SelectedItem.Text & "")
                        End If
                        Tran.Commit()
                        RefreshLists()
                        objFun.Alert("SanctionNote " & ddlAction.SelectedItem.Text & "ed...!!!")

                    Else
                        objFun.Alert("Please Select any SanctionNote from the List and then Proceed !!!")
                        Exit Sub
                    End If
                Else
                    objFun.Alert("Please Select any SanctionNote from the List and then Proceed !!!")
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            objFun.Alert("Unable to Complete Transaction...")
            ' ObjSendMail.SendMail("Ashish@jctltd.com", "noreply@jctltd.com", "Error in Authorizing SanctionNote !!!", "The sanction note no " & SanctionNote & "was under authorization process but some error was genrated.....<br> " & ex.ToString)
            Tran.Rollback()
        End Try

    End Sub

    Private Sub RefreshLists()
        DataList1.DataSource = Nothing
        DataBind()

        DataList1.DataSourceID = "SqlDataSource2"
        DataBind()

        GridView1.DataSource = Nothing
        GridView1.DataBind()

        GrdSanctionNoteDetail.DataSource = Nothing
        GrdSanctionNoteDetail.DataBind()
    End Sub




    Protected Sub DataList1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DataList1.SelectedIndexChanged
        GrdSanctionNoteDetail.DataSource = Nothing
        GrdSanctionNoteDetail.DataBind()
    End Sub

    Private Sub SendMail(Body__1 As String, Body2 As String, body3 As String, RaisedBy_Email As String, [to] As String, cc As String, bcc As String, Subject As String)

        Dim from As String
        from = "noreply@jctltd.com"
        Dim query As String = ""
        Dim SenderEmail As String = ""

        If RaisedBy_Email Is Nothing Then
            RaisedBy_Email = ""
        End If

        'query = "SELECT isnull(E_MailID,'') FROM dbo.MISTEL WHERE empcode='" & [to] & "' "
        'SenderEmail = objFun.FetchValue(query)
        If SenderEmail Is Nothing Then SenderEmail = ""

        If SenderEmail <> "" Then

            'Email Address of Receiver
            [to] = SenderEmail & "," & RaisedBy_Email ' "neeraj@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,rahuljindal@jctltd.com,karunarora@jctltd.com,lakhbir@jctltd.com,ramanjot@jctltd.com,WeavingGroup@jctltd.com"
            'Else
            '    'Email Address of Receiver
            '    [to] = "neeraj@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,rahuljindal@jctltd.com,karunarora@jctltd.com,lakhbir@jctltd.com,ramanjot@jctltd.com,WeavingGroup@jctltd.com," & Convert.ToString(SalesPerson_Email)
        Else
            [to] = RaisedBy_Email
        End If


        'bcc = "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com"
        'cc = "arwinder@jctltd.com"
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
        mail.Body = Body__1 & " " & Body2 & " " & body3
        mail.IsBodyHtml = True
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
        Dim SmtpMail As New SmtpClient("exchange2007")


        SmtpMail.Send(mail)

    End Sub
    Protected Sub CmdCancel_Click(sender As Object, e As System.EventArgs) Handles CmdCancel.Click
        RefreshLists()
        'Dim NextAuthLevel As String = "None"
        'Dim MaxAuthLevel As String = "None"
        'Dim CurrentUserLevel As String = ""
        'Dim AreaCode As String = ""
        'Dim SanctionNote As String = ""
        'Dim SalePersonCode As String = ""
        'Dim SalePersonEmail As String = "ashish@jctltd.com"
        'Dim Body As String = ""
        'Dim OrderNo As String, Sort As String, Shade As String, Lineno As Int16 = 0
        'Dim Qty As Int32 = 0
        'Dim Reqd_Date As String = ""
        'Dim Area As String = ""
        'Dim UserName As String = ""
        'UserName = objFun.FetchValue("Select empname from jct_empmast_base where empcode='" & Session("Empcode") & "'")
        'OrderNo = ""
        'Sort = ""
        'Shade = ""
        'Lineno = 0
        'Try

        '    With GridView1

        '        If .SelectedIndex > -1 Then
        '            If GridView1.SelectedRow.Cells(1).Text <> "" Or GridView1.Rows.Count >= 1 Then
        '                SanctionNote = Trim(.SelectedRow.Cells(1).Text)
        '                AreaCode = Trim(.SelectedRow.Cells(2).Text)
        '                Tran = obj.Connection.BeginTransaction
        '                con = obj.Connection
        '                If AreaCode = 9999 Then
        '                    Area = Trim(.SelectedRow.Cells(5).Text)
        '                    Area = Area.Substring(Area.IndexOf("~ ") + 2, Area.IndexOf(" -") - Area.IndexOf("~ ") - 2)
        '                End If
        '                OrderNo = GrdSanctionNoteDetail.Rows(0).Cells(1).Text
        '                'Sort = GrdSanctionNoteDetail.Rows(0).Cells(2).Text
        '                'Shade = GrdSanctionNoteDetail.Rows(0).Cells(3).Text
        '                'Lineno = GrdSanctionNoteDetail.Rows(0).Cells(4).Text
        '                'Qty = GrdSanctionNoteDetail.Rows(0).Cells(5).Text
        '                Reqd_Date = GrdSanctionNoteDetail.Rows(0).Cells(5).Text

        '                If AreaCode <> 9999 Then
        '                    qry = "Select isnull(convert(varchar,UserLevel),'None') from Jct_Ops_SanctioNote_Area_Emp_Auth_Listing WHERE AreaCode='" & AreaCode & "' and  GETDATE() BETWEEN Eff_From AND Eff_To and empcode='" & Session("Empcode") & "'"
        '                    CurrentUserLevel = objFun.FetchValue(qry, con, Tran)

        '                    If CurrentUserLevel Is Nothing Then CurrentUserLevel = "None"

        '                    If CurrentUserLevel <> "None" Then
        '                        qry = "Select top 1 isnull(convert(varchar,UserLevel),'None') from Jct_Ops_SanctioNote_Area_Emp_Auth_Listing WHERE AreaCode='" & AreaCode & "' and GETDATE() BETWEEN Eff_From AND Eff_To and empcode<>'" & Session("Empcode") & "' and userlevel>'" & Val(CurrentUserLevel) & "' order by userlevel"
        '                        NextAuthLevel = objFun.FetchValue(qry, con, Tran)
        '                    Else
        '                        objFun.Alert("Unable to Your Authoirze...!!!")

        '                        Tran.Rollback()
        '                        Exit Sub
        '                    End If

        '                    qry = "Select top 1 isnull(convert(varchar,max(UserLevel)),'None') from Jct_Ops_SanctioNote_Area_Emp_Auth_Listing WHERE AreaCode='" & AreaCode & "' and  GETDATE() BETWEEN Eff_From AND Eff_To AND STATUS='a'"
        '                    MaxAuthLevel = objFun.FetchValue(qry, con, Tran)

        '                    ''Added on  Jan -8 to include  P.G Mohan authorization 
        '                    'If CurrentUserLevel = MaxAuthLevel And LCase(Session("Empcode").ToString.ToLower) = "p-03055" Then
        '                    '    qry = "INSERT INTO Jct_Ops_SanctionNote_FinalAuthrization_Details(SanctionNoteID ,UserCode ,ParmCode ,ParmName ,Val ,Created_Date ,STATUS ,CreatedOnHost) values('" & SanctionNote & "','" & Session("Empcode") & "','','" & lblTransport.Text & "','" & ddlFinalMode.SelectedItem.Value & "',getdate(),'A','" & Request.ServerVariables("REMOTE_ADDR") & "')"
        '                    '    objFun.InsertRecord(qry, Tran, obj.Connection)
        '                    '    qry = "INSERT INTO Jct_Ops_SanctionNote_FinalAuthrization_Details(SanctionNoteID ,UserCode ,ParmCode ,ParmName ,Val ,Created_Date ,STATUS ,CreatedOnHost) values('" & SanctionNote & "','" & Session("Empcode") & "','','" & lblFreightVal.Text & "','" & txtFinalFreightVal.Text & "',getdate(),'A','" & Request.ServerVariables("REMOTE_ADDR") & "')"
        '                    '    objFun.InsertRecord(qry, Tran, obj.Connection)
        '                    'End If

        '                    If NextAuthLevel Is Nothing And MaxAuthLevel Is Nothing Then
        '                        NextAuthLevel = "None"
        '                        objFun.Alert("Unable to Your Authoirze...!!!")
        '                        Tran.Rollback()
        '                        Exit Sub

        '                    Else
        '                        qry = "Update Jct_Ops_SanctionNote_HDR set AuthFlag='" & Left(ddlAction.SelectedItem.Text, 1) & "',PendingAt='',LastAuthBy='" & CurrentUserLevel & "',LastAuthOn=getdate() where SanctionNoteID='" & SanctionNote & "' and status='A'  and AuthFlag='P'"
        '                        objFun.UpdateRecord(qry, Tran, con)
        '                        qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL ,CANCEL_DATETIME,CREATED_ONHOST ,Remarks) values('" & SanctionNote & "','" & Session("Empcode") & "','" & AreaCode & "','" & Session("Empcode") & "','" & CurrentUserLevel & "',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "')"
        '                        objFun.InsertRecord(qry, Tran, con)
        '                        Body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b> " '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Line & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>Finishing</P> <b>Meters :-" & DyngQty & "</b> was Planned to be <b>Dyed on :-</b> '" & ReqDyngDate & "' <br><hr><br><br><P>Finishing</P> Meter Planned for Finishing are :-</b> '" & FinsihQty & "' <b>On Date </b> '" & ReqFinishDate & "'  <h3>This Order Has been Removed from Dyeing and Finish (Processing) Plan by '" & Removedby & "' </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
        '                    End If
        '                Else '-----Will be executed when Exceptions are ment to be authorised or Unauthorized
        '                    qry = "update Jct_Ops_Process_Plan_Exception set PendingAt='',LastAuthBy='" & Session("Empcode") & "',LastAuthOn=getdate(),AuthFlag='" & Left(ddlAction.SelectedItem.Text, 1) & "',IntialAuthRemarks='" & txtRemarks.Text & "'  WHERE STATUS='A' AND LastAuthBy IS NULL and ExceptionID=" & SanctionNote & ""
        '                    objFun.InsertRecord(qry, Tran, con)
        '                    ''Body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b> " '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Line & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>Finishing</P> <b>Meters :-" & DyngQty & "</b> was Planned to be <b>Dyed on :-</b> '" & ReqDyngDate & "' <br><hr><br><br><P>Finishing</P> Meter Planned for Finishing are :-</b> '" & FinsihQty & "' <b>On Date </b> '" & ReqFinishDate & "'  <h3>This Order Has been Removed from Dyeing and Finish (Processing) Plan by '" & Removedby & "' </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
        '                    Body = "<p>Hello.....,</p>This Order has been approved for re-scheduling in " & Area & " is <B>Pending At Planning's Approval </b><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)", obj.Connection, Tran)) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3>  <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
        '                End If


        '                'qry = "SELECT isnull(MAX(USERLEVEL)+1,999) FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING  WHERE id='" & SanctionNote & "' AND AREACODE='" & AreaCode & "' AND STATUS IS null"
        '                'CurrentUserLevel = objFun.FetchValue(qry, con, Tran)
        '                If AreaCode = 9999 Then
        '                    objFun.SendMailOPS(Body, OrderNo, SalePersonEmail, Session("Empcode"), "ashish@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your orderNO :-""  SortNo :-  ""' Shade :-  " & Shade & " was Reequested be Re-Planned in " & Area & " section and the request was generated by  " & UserName)
        '                Else
        '                    'objFun.SendMailOPS(Body, OrderNo, SalePersonEmail, Session("Empcode"), "rahuljindal@jctltd.com,rashpal@jctltd.com,karunarora@jctltd.com,khushwinder@jctltd.com,neeraj@jctltd.com,sobti@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your orderNO :-""  SortNo :-  " & Item & "' Shade :-  " & Shade & " was Removed from  Dyeing & Finishing Plan")
        '                End If
        '                Tran.Commit()
        '                RefreshLists()
        '                objFun.Alert("SanctionNote Authorized...!!!")

        '            Else
        '                objFun.Alert("Please Select any SanctionNote from the List and then Proceed !!!")
        '                Exit Sub
        '            End If
        '        Else
        '            objFun.Alert("Please Select any SanctionNote from the List and then Proceed !!!")
        '            Exit Sub
        '        End If
        '    End With
        'Catch ex As Exception
        '    objFun.Alert("Unable to Complete Transaction...")
        '    ' ObjSendMail.SendMail("Ashish@jctltd.com", "noreply@jctltd.com", "Error in Authorizing SanctionNote !!!", "The sanction note no " & SanctionNote & "was under authorization process but some error was genrated.....<br> " & ex.ToString)
        '    Tran.Rollback()
        'End Try
    End Sub
    Private Sub SendMail()

        Dim from As String, [to] As String, bcc As String, cc As String, subject As String, body As String, Reason As String
        Dim sql As String
        Dim Auth As String
        Dim sb As New StringBuilder()

        sql = "Select * from jct_ops_material_request where AuthStatus='P' and requestid=" + ViewState("ID")
        If (objFun.CheckRecordExistInTransaction(sql)) Then

            ' sql = "Select LEFT(FlagAuth + ',',CHARINDEX(',', FlagAuth + ',') - 1) as FlagAuth from jct_ops_material_request where AuthStatus='P' and requestid=" + ViewState("ID") + " "
            'sql = "Select  LEFT(SUBSTRING(FlagAuth,2,999) ,CHARINDEX(',', SUBSTRING(FlagAuth,2,999)) - 1)  as FlagAuth from jct_ops_material_request where AuthStatus='P' and requestid=" + ViewState("ID") + " "
            sql = "JCT_OPS_SANCTION_NOTE_MATERIAL_RETURN_REASON_MAIL_AUTHORIZATION"
            Dim cmd As SqlCommand = New SqlCommand(sql, obj.Connection())
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ViewState("ID")
            Dim dr1 As SqlDataReader = cmd.ExecuteReader()
            If (dr1.HasRows()) Then
                While (dr1.Read())

                    Auth = dr1(0).ToString()
                End While
            End If


        End If
        sql = "Select * from jct_ops_material_request where AuthStatus='A' and requestid=" + ViewState("ID")
        If (objFun.CheckRecordExistInTransaction(sql)) Then

            'sql = "Select LEFT(FlagAuth + ',',CHARINDEX(',', FlagAuth + ',') - 1) as FlagAuth from jct_ops_material_return where AuthStatus='A' and requestid=" + ViewState("ID") + " "
            Auth = "charanamrit.singh@jctltd.com,mikeops@jctltd.com"

        End If



        sb.AppendLine("<html>")
        sb.AppendLine("<head>")
        sb.AppendLine("<style type=""text/css"">")
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}")
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}")
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}")
        sb.AppendLine("</style>")
        sb.AppendLine("</head>")



        ' sb.Append("<head>");
        sb.AppendLine("Hi,<br/><br/>")
        sb.AppendLine("Material Return Request has been generated in OPS.<br/><br/>")
        sb.AppendLine("RequestID for your request is : " + ViewState("RequestID") + " <br/><br/>")
        sb.AppendLine("Details are Shown below : <br/><br/>")
        sb.AppendLine("<table class=gridtable>")
        sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th> Auth. Pending At</th> </tr>")
        sql = "SELECT isnull(a.invoice_no,'') as invoice_no,isnull(a.item_no,'') as item_no,isnull(a.customer,'') as customer,isnull(b.empname,'') as sales_person,isnull(Convert(numeric(12,2),a.invoice_qty),0) as invoice_qty,isnull(Convert(Numeric(12,2),a.ret_qty),0) as ret_qty ,isnull(Substring(a.FlagAuth,2,999),'') as FlagAuth,AuthStatus ,reason FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') WHERE a.RequestID=" + ViewState("ID")

        Dim Dr As SqlDataReader = objFun.FetchReader(sql)
        If (Dr.HasRows) Then
            While (Dr.Read())

                Reason = Dr(8).ToString
                If (Dr(7).ToString = "A") Then
                    sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td>  <td>" & Dr(5).ToString & "</td>  <td> CEO </td> </tr> ")
                Else
                    sql = "Select empname from jct_empmast_base where active='Y' and  empcode='" + Dr(6).ToString().Split(",")(0) + "'"
                    Dim empname As String = ""
                    Dim obj2 As Connection = New Connection
                    Dim cmd As SqlCommand = New SqlCommand(sql, obj2.Connection())
                    Dim dr1 As SqlDataReader = cmd.ExecuteReader
                    If (dr1.HasRows()) Then

                        While (dr1.Read)

                            empname = dr1(0).ToString

                        End While

                    End If
                    dr1.Close()
                    obj2.ConClose()
                    sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td>  <td>" & Dr(5).ToString & "</td>  <td>" & empname & "</td> </tr> ")
                End If
            End While

        End If
        Dr.Close()
        sb.AppendLine("</table>")
        sb.AppendLine("<br />")
        sb.Append("<a href='http://misdev/fusionapps/OPS/AuthorizeSanctionNote10.aspx'> Click here to view details... </a><br />")

        sb.AppendLine("</table><br />")

        sb.AppendLine("<br/><br />")
        sb.AppendLine("Reason For Qty Return : " + Reason + "<br /><br/>")
        sql = "Select empname from jct_empmast_base where empcode='" + Session("EmpCode") + "'"
        sb.AppendLine("Last Authorized by : " + objFun.FetchValue(sql) + "<br /><br/>")
        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>")
        sb.AppendLine("Thank you<br />")
        sb.AppendLine("</html>")


        body = sb.ToString()
        from = "noreply@jctltd.com"

        '[to] = email1 + "," + email2
        [to] = IIf(String.IsNullOrEmpty(Auth), "it.helpdesk@jctltd.com", Auth)
        bcc = "jatindutta@jctltd.com,ashish@jctltd.com"
        ' [to] = ("jatindutta@jctltd.com")
        'Email Address of Receiver
        'cc = "jatindutta@jctltd.com,jagdeep@jctltd.com,hitesh@jctltd.com"
        subject = " Material Return Request"
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
        'If Not String.IsNullOrEmpty(cc) Then
        '    If cc.Contains(",") Then
        '        Dim ccs As String() = cc.Split(","c)
        '        For i As Integer = 0 To ccs.Length - 1
        '            mail.CC.Add(New MailAddress(ccs(i)))
        '        Next
        '    Else
        '        mail.CC.Add(New MailAddress(bcc))
        '    End If
        '    mail.CC.Add(New MailAddress(cc))
        'End If

        mail.Subject = subject
        mail.Body = body
        mail.IsBodyHtml = True
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
        Dim SmtpMail As New SmtpClient("exchange2007")

        'SmtpMail.SmtpServer = "exchange2007";
        SmtpMail.Send(mail)
        'return mail;
    End Sub
End Class
