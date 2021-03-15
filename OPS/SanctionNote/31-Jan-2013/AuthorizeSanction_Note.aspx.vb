Imports System
Imports System.Data.SqlClient
Imports System.Reflection

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
        Dim OrderNo As String, Sort As String, Shade As String, Lineno As Int16 = 0
        Dim Qty As Int32 = 0
        Dim Reqd_Date As String = ""
        Dim Area As String = ""
        Dim UserName As String = ""
        UserName = objFun.FetchValue("Select empname from jct_empmast_base where empcode='" & Session("Empcode") & "'")
        OrderNo = ""
        Sort = ""
        Shade = ""
        Lineno = 0
        Try

            With GridView1

                If .SelectedIndex > -1 Then
                    If GridView1.SelectedRow.Cells(1).Text <> "" Or GridView1.Rows.Count >= 1 Then
                        SanctionNote = Trim(.SelectedRow.Cells(1).Text)
                        AreaCode = Trim(.SelectedRow.Cells(2).Text)
                        Tran = obj.Connection.BeginTransaction
                        con = obj.Connection
                        If AreaCode = 9999 Then
                            Area = Trim(.SelectedRow.Cells(5).Text)
                            Area = Area.Substring(Area.IndexOf("~ ") + 2, Area.IndexOf(" -") - Area.IndexOf("~ ") - 2)

                            OrderNo = GrdSanctionNoteDetail.Rows(0).Cells(1).Text
                            Sort = GrdSanctionNoteDetail.Rows(0).Cells(2).Text
                            Shade = GrdSanctionNoteDetail.Rows(0).Cells(3).Text
                            Lineno = GrdSanctionNoteDetail.Rows(0).Cells(4).Text
                            Qty = GrdSanctionNoteDetail.Rows(0).Cells(5).Text
                            Reqd_Date = GrdSanctionNoteDetail.Rows(0).Cells(5).Text
                        End If
                        If AreaCode <> 9999 Then
                            qry = "Select isnull(convert(varchar,UserLevel),'None') from Jct_Ops_SanctioNote_Area_Emp_Auth_Listing WHERE AreaCode='" & AreaCode & "' and  GETDATE() BETWEEN Eff_From AND Eff_To and empcode='" & Session("Empcode") & "'"
                            CurrentUserLevel = objFun.FetchValue(qry, con, Tran)

                            If CurrentUserLevel Is Nothing Then CurrentUserLevel = "None"

                            If CurrentUserLevel <> "None" Then
                                qry = "Select top 1 isnull(convert(varchar,UserLevel),'None') from Jct_Ops_SanctioNote_Area_Emp_Auth_Listing WHERE AreaCode='" & AreaCode & "' and GETDATE() BETWEEN Eff_From AND Eff_To and empcode<>'" & Session("Empcode") & "' and userlevel>'" & Val(CurrentUserLevel) & "' order by userlevel"
                                NextAuthLevel = objFun.FetchValue(qry, con, Tran)
                            Else
                                objFun.Alert("Unable to Your Authoirze...!!!")

                                Tran.Rollback()
                                Exit Sub
                            End If

                            qry = "Select top 1 isnull(convert(varchar,max(UserLevel)),'None') from Jct_Ops_SanctioNote_Area_Emp_Auth_Listing WHERE AreaCode='" & AreaCode & "' and  GETDATE() BETWEEN Eff_From AND Eff_To AND STATUS='a'"
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

                                If Left(ddlAction.SelectedItem.Text, 1) = "A" Then
                                    qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL ,AUTH_DATETIME,CREATED_ONHOST ,Remarks) values('" & SanctionNote & "','" & Session("Empcode") & "','" & AreaCode & "','" & Session("Empcode") & "','" & CurrentUserLevel & "',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "')"
                                Else
                                    qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL ,CANCEL_DATETIME,CREATED_ONHOST ,Remarks) values('" & SanctionNote & "','" & Session("Empcode") & "','" & AreaCode & "','" & Session("Empcode") & "','" & CurrentUserLevel & "',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "')"
                                End If
                                objFun.InsertRecord(qry, Tran, con)

                                Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This Order Is requested to be Re-Planned.</h3></b> Your <br><b>orderNO :-</b>  ''" & OrderNo & "'</br><br><b>SortNo :-</b>'" & Sort & "' <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"

                                Else
                                qry = "Update Jct_Ops_SanctionNote_HDR set AuthFlag='" & Left(ddlAction.SelectedItem.Text, 1) & "',PendingAt='',LastAuthBy='" & CurrentUserLevel & "',LastAuthOn=getdate() where SanctionNoteID='" & SanctionNote & "' and status='A'  and AuthFlag='P'"
                                objFun.UpdateRecord(qry, Tran, con)

                                If Left(ddlAction.SelectedItem.Text, 1) = "A" Then
                                    qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL ,AUTH_DATETIME,CREATED_ONHOST ,Remarks) values('" & SanctionNote & "','" & Session("Empcode") & "','" & AreaCode & "','" & Session("Empcode") & "','" & CurrentUserLevel & "',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "')"
                                ElseIf Left(ddlAction.SelectedItem.Text, 1) = "C" Then
                                    qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL ,CANCEL_DATETIME,CREATED_ONHOST ,Remarks) values('" & SanctionNote & "','" & Session("Empcode") & "','" & AreaCode & "','" & Session("Empcode") & "','" & CurrentUserLevel & "',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "')"
                                End If

                                objFun.InsertRecord(qry, Tran, con)
                                Body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b> " ''" & OrderNo & "'</br><br><b>SortNo :-</b>'" & Sort & "' <br><b>LineNo :-</b>'" & Line & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>Finishing</P> <b>Meters :-" & DyngQty & "</b> was Planned to be <b>Dyed on :-</b> '" & ReqDyngDate & "' <br><hr><br><br><P>Finishing</P> Meter Planned for Finishing are :-</b> '" & FinsihQty & "' <b>On Date </b> '" & ReqFinishDate & "'  <h3>This Order Has been Removed from Dyeing and Finish (Processing) Plan by '" & Removedby & "' </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                            End If
                        Else '-----Will be executed when Exceptions are ment to be authorised or Unauthorized
                            qry = "update Jct_Ops_Process_Plan_Exception set PendingAt='',LastAuthBy='" & Session("Empcode") & "',LastAuthOn=getdate(),AuthFlag='" & Left(ddlAction.SelectedItem.Text, 1) & "',IntialAuthRemarks='" & txtRemarks.Text & "'  WHERE STATUS='A' AND LastAuthBy IS NULL and ExceptionID=" & SanctionNote & ""
                            objFun.InsertRecord(qry, Tran, con)
                            ''Body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b> " ''" & OrderNo & "'</br><br><b>SortNo :-</b>'" & Sort & "' <br><b>LineNo :-</b>'" & Line & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>Finishing</P> <b>Meters :-" & DyngQty & "</b> was Planned to be <b>Dyed on :-</b> '" & ReqDyngDate & "' <br><hr><br><br><P>Finishing</P> Meter Planned for Finishing are :-</b> '" & FinsihQty & "' <b>On Date </b> '" & ReqFinishDate & "'  <h3>This Order Has been Removed from Dyeing and Finish (Processing) Plan by '" & Removedby & "' </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                            Body = "<p>Hello.....,</p>This Order has been approved for re-scheduling in " & Area & " is <B>Pending At Planning's Approval </b><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b>  ''" & OrderNo & "'</br><br><b>SortNo :-</b>'" & Sort & "' <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)", obj.Connection, Tran)) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3>  <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                        End If


                        'qry = "SELECT isnull(MAX(USERLEVEL)+1,999) FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING  WHERE id='" & SanctionNote & "' AND AREACODE='" & AreaCode & "' AND STATUS IS null"
                        'CurrentUserLevel = objFun.FetchValue(qry, con, Tran)
                        If AreaCode = 9999 Then
                            objFun.SendMailOPS(Body, OrderNo, SalePersonEmail, Session("Empcode"), "ashish@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your orderNO :-" & OrderNo & "  SortNo :-  " & Sort & "' Shade :-  " & Shade & " was Reequested be Re-Planned in " & Area & " section and the request was generated by  " & UserName)
                        Else
                            'objFun.SendMailOPS(Body, OrderNo, SalePersonEmail, Session("Empcode"), "rahuljindal@jctltd.com,rashpal@jctltd.com,karunarora@jctltd.com,khushwinder@jctltd.com,neeraj@jctltd.com,sobti@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your orderNO :-" & OrderNo & "  SortNo :-  " & Item & "' Shade :-  " & Shade & " was Removed from  Dyeing & Finishing Plan")
                        End If
                        Tran.rollback()
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

    Protected Sub CmdCancel_Click(sender As Object, e As System.EventArgs) Handles CmdCancel.Click
        Dim NextAuthLevel As String = "None"
        Dim MaxAuthLevel As String = "None"
        Dim CurrentUserLevel As String = ""
        Dim AreaCode As String = ""
        Dim SanctionNote As String = ""
        Dim SalePersonCode As String = ""
        Dim SalePersonEmail As String = "ashish@jctltd.com"
        Dim Body As String = ""
        Dim OrderNo As String, Sort As String, Shade As String, Lineno As Int16 = 0
        Dim Qty As Int32 = 0
        Dim Reqd_Date As String = ""
        Dim Area As String = ""
        Dim UserName As String = ""
        UserName = objFun.FetchValue("Select empname from jct_empmast_base where empcode='" & Session("Empcode") & "'")
        OrderNo = ""
        Sort = ""
        Shade = ""
        Lineno = 0
        Try

            With GridView1

                If .SelectedIndex > -1 Then
                    If GridView1.SelectedRow.Cells(1).Text <> "" Or GridView1.Rows.Count >= 1 Then
                        SanctionNote = Trim(.SelectedRow.Cells(1).Text)
                        AreaCode = Trim(.SelectedRow.Cells(2).Text)
                        Tran = obj.Connection.BeginTransaction
                        con = obj.Connection
                        If AreaCode = 9999 Then
                            Area = Trim(.SelectedRow.Cells(5).Text)
                            Area = Area.Substring(Area.IndexOf("~ ") + 2, Area.IndexOf(" -") - Area.IndexOf("~ ") - 2)
                        End If
                        OrderNo = GrdSanctionNoteDetail.Rows(0).Cells(1).Text
                        'Sort = GrdSanctionNoteDetail.Rows(0).Cells(2).Text
                        'Shade = GrdSanctionNoteDetail.Rows(0).Cells(3).Text
                        'Lineno = GrdSanctionNoteDetail.Rows(0).Cells(4).Text
                        'Qty = GrdSanctionNoteDetail.Rows(0).Cells(5).Text
                        Reqd_Date = GrdSanctionNoteDetail.Rows(0).Cells(5).Text

                        If AreaCode <> 9999 Then
                            qry = "Select isnull(convert(varchar,UserLevel),'None') from Jct_Ops_SanctioNote_Area_Emp_Auth_Listing WHERE AreaCode='" & AreaCode & "' and  GETDATE() BETWEEN Eff_From AND Eff_To and empcode='" & Session("Empcode") & "'"
                            CurrentUserLevel = objFun.FetchValue(qry, con, Tran)

                            If CurrentUserLevel Is Nothing Then CurrentUserLevel = "None"

                            If CurrentUserLevel <> "None" Then
                                qry = "Select top 1 isnull(convert(varchar,UserLevel),'None') from Jct_Ops_SanctioNote_Area_Emp_Auth_Listing WHERE AreaCode='" & AreaCode & "' and GETDATE() BETWEEN Eff_From AND Eff_To and empcode<>'" & Session("Empcode") & "' and userlevel>'" & Val(CurrentUserLevel) & "' order by userlevel"
                                NextAuthLevel = objFun.FetchValue(qry, con, Tran)
                            Else
                                objFun.Alert("Unable to Your Authoirze...!!!")

                                Tran.Rollback()
                                Exit Sub
                            End If

                            qry = "Select top 1 isnull(convert(varchar,max(UserLevel)),'None') from Jct_Ops_SanctioNote_Area_Emp_Auth_Listing WHERE AreaCode='" & AreaCode & "' and  GETDATE() BETWEEN Eff_From AND Eff_To AND STATUS='a'"
                            MaxAuthLevel = objFun.FetchValue(qry, con, Tran)

                            ''Added on  Jan -8 to include  P.G Mohan authorization 
                            'If CurrentUserLevel = MaxAuthLevel And LCase(Session("Empcode").ToString.ToLower) = "p-03055" Then
                            '    qry = "INSERT INTO Jct_Ops_SanctionNote_FinalAuthrization_Details(SanctionNoteID ,UserCode ,ParmCode ,ParmName ,Val ,Created_Date ,STATUS ,CreatedOnHost) values('" & SanctionNote & "','" & Session("Empcode") & "','','" & lblTransport.Text & "','" & ddlFinalMode.SelectedItem.Value & "',getdate(),'A','" & Request.ServerVariables("REMOTE_ADDR") & "')"
                            '    objFun.InsertRecord(qry, Tran, obj.Connection)
                            '    qry = "INSERT INTO Jct_Ops_SanctionNote_FinalAuthrization_Details(SanctionNoteID ,UserCode ,ParmCode ,ParmName ,Val ,Created_Date ,STATUS ,CreatedOnHost) values('" & SanctionNote & "','" & Session("Empcode") & "','','" & lblFreightVal.Text & "','" & txtFinalFreightVal.Text & "',getdate(),'A','" & Request.ServerVariables("REMOTE_ADDR") & "')"
                            '    objFun.InsertRecord(qry, Tran, obj.Connection)
                            'End If

                            If NextAuthLevel Is Nothing And MaxAuthLevel Is Nothing Then
                                NextAuthLevel = "None"
                                objFun.Alert("Unable to Your Authoirze...!!!")
                                Tran.Rollback()
                                Exit Sub

                            Else
                                qry = "Update Jct_Ops_SanctionNote_HDR set AuthFlag='" & Left(ddlAction.SelectedItem.Text, 1) & "',PendingAt='',LastAuthBy='" & CurrentUserLevel & "',LastAuthOn=getdate() where SanctionNoteID='" & SanctionNote & "' and status='A'  and AuthFlag='P'"
                                objFun.UpdateRecord(qry, Tran, con)
                                qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL ,CANCEL_DATETIME,CREATED_ONHOST ,Remarks) values('" & SanctionNote & "','" & Session("Empcode") & "','" & AreaCode & "','" & Session("Empcode") & "','" & CurrentUserLevel & "',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "')"
                                objFun.InsertRecord(qry, Tran, con)
                                Body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b> " ''" & OrderNo & "'</br><br><b>SortNo :-</b>'" & Sort & "' <br><b>LineNo :-</b>'" & Line & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>Finishing</P> <b>Meters :-" & DyngQty & "</b> was Planned to be <b>Dyed on :-</b> '" & ReqDyngDate & "' <br><hr><br><br><P>Finishing</P> Meter Planned for Finishing are :-</b> '" & FinsihQty & "' <b>On Date </b> '" & ReqFinishDate & "'  <h3>This Order Has been Removed from Dyeing and Finish (Processing) Plan by '" & Removedby & "' </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                            End If
                        Else '-----Will be executed when Exceptions are ment to be authorised or Unauthorized
                            qry = "update Jct_Ops_Process_Plan_Exception set PendingAt='',LastAuthBy='" & Session("Empcode") & "',LastAuthOn=getdate(),AuthFlag='" & Left(ddlAction.SelectedItem.Text, 1) & "',IntialAuthRemarks='" & txtRemarks.Text & "'  WHERE STATUS='A' AND LastAuthBy IS NULL and ExceptionID=" & SanctionNote & ""
                            objFun.InsertRecord(qry, Tran, con)
                            ''Body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b> " ''" & OrderNo & "'</br><br><b>SortNo :-</b>'" & Sort & "' <br><b>LineNo :-</b>'" & Line & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>Finishing</P> <b>Meters :-" & DyngQty & "</b> was Planned to be <b>Dyed on :-</b> '" & ReqDyngDate & "' <br><hr><br><br><P>Finishing</P> Meter Planned for Finishing are :-</b> '" & FinsihQty & "' <b>On Date </b> '" & ReqFinishDate & "'  <h3>This Order Has been Removed from Dyeing and Finish (Processing) Plan by '" & Removedby & "' </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                            Body = "<p>Hello.....,</p>This Order has been approved for re-scheduling in " & Area & " is <B>Pending At Planning's Approval </b><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b>  ''" & OrderNo & "'</br><br><b>SortNo :-</b>'" & Sort & "' <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)", obj.Connection, Tran)) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3>  <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                        End If


                        'qry = "SELECT isnull(MAX(USERLEVEL)+1,999) FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING  WHERE id='" & SanctionNote & "' AND AREACODE='" & AreaCode & "' AND STATUS IS null"
                        'CurrentUserLevel = objFun.FetchValue(qry, con, Tran)
                        If AreaCode = 9999 Then
                            objFun.SendMailOPS(Body, OrderNo, SalePersonEmail, Session("Empcode"), "ashish@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your orderNO :-" & OrderNo & "  SortNo :-  " & Sort & "' Shade :-  " & Shade & " was Reequested be Re-Planned in " & Area & " section and the request was generated by  " & UserName)
                        Else
                            'objFun.SendMailOPS(Body, OrderNo, SalePersonEmail, Session("Empcode"), "rahuljindal@jctltd.com,rashpal@jctltd.com,karunarora@jctltd.com,khushwinder@jctltd.com,neeraj@jctltd.com,sobti@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com", "Your orderNO :-" & OrderNo & "  SortNo :-  " & Item & "' Shade :-  " & Shade & " was Removed from  Dyeing & Finishing Plan")
                        End If
                        Tran.Commit()
                        RefreshLists()
                        objFun.Alert("SanctionNote Authorized...!!!")

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


    Protected Sub DataList1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DataList1.SelectedIndexChanged
        GrdSanctionNoteDetail.DataSource = Nothing
        GrdSanctionNoteDetail.DataBind()
    End Sub
End Class
