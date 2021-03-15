Imports System
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Net.Mail
Imports System.IO
Imports System.Data
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Partial Class OPS_AuthorizeSanction_Note
    Inherits System.Web.UI.Page
    Dim objFun As Functions = New Functions
    Dim obj As Connection = New Connection
    Dim obj3 As Connection = New Connection
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
            Dim AreaName As String = ""
            'If (String.IsNullOrEmpty(Request.QueryString("AreaName")) = False) Then

            '    AreaName = Request.QueryString("AreaName")
            AreaName = "Material Return"
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


        'End If





        'If Session("empcode") = "A-00098" Or Session("empcode") = "P-03055" Then
        '    Panel2.Visible = True
        'Else
        '    Panel2.Visible = False
        'End If
    End Sub

    Protected Sub DataList1_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.ItemCommand
        Try
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


                GrdAuthHistory.DataSource = Nothing
                GrdAuthHistory.DataBind()

                Request.QueryString.Clear()
            Else

                If e.CommandName = "Select" Then
                    AreaName = CType(e.Item.FindControl("cmdArea"), LinkButton).Text
                    If AreaName <> "" And AreaName <> "Greigh Transfer" And AreaName <> "ODS Request" And AreaName <> "Outsourced Yarn" And AreaName <> "Outsourced Fabric" And AreaName <> "JobWork" Then
                        GridView1.DataSource = Nothing
                        GridView1.DataBind()
                        GridView1.SelectedIndex = -1
                        GrdSanctionNoteDetail.DataSource = Nothing
                        GrdSanctionNoteDetail.DataBind()
                        'qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' and b.areaName='" & AreaName & "'"
                        'Comented on 31-Dec-2012 qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c,Jct_Ops_SanctioNote_Area_Emp_Auth_Listing d WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' AND a.authFlag='P' AND a.PendingAt=d.UserLevel and b.areaName='" & AreaName & "' AND ( 1 = ( SELECT TOP 1 1 FROM    production..role_user_mapping WHERE   role = '100' AND uname = '" & Session("Empcode") & "') OR d.EmpCode = '" & Session("Empcode") & "') AND b.AreaCode = d.AreaCode "
                        qry = "Jct_Ops_Pending_Authorization_Fetch '" & Session("Empcode") & "','" & AreaName & "'"
                        objFun.FillGrid(qry, GridView1)
                    ElseIf AreaName = "ODS Request" Then
                        Response.Redirect("ODS_Costing_Auth.aspx")

                    ElseIf AreaName = "Outsourced Yarn" OrElse AreaName = "Outsourced Fabric" OrElse AreaName = "JobWork" Then

                        Response.Redirect("outsourced_req_authorize.aspx?AreaName=" + AreaName.Replace(" ", "%20"))

                    Else
                        Response.Redirect("AuthorizeSanctionNote10.aspx")
                    End If
                End If

            End If
        Catch ex As Exception

        End Try


    End Sub


    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        'Comented on 31-Dec-2012   qry = "SELECT b.ParmName,b.ParmDesc,a.Val as [Values] FROM dbo.Jct_Ops_SanctionNote_Dtl a,dbo.Jct_Ops_SanctionNote_Parameters b WHERE SanctionNoteID='" & Trim(GridView1.SelectedRow.Cells(1).Text) & "' AND b.STATUS='A' AND GETDATE() BETWEEN b.Eff_From AND b.Eff_To  AND a.ParamCode=b.ParamCode"
        Try

            ' Added to add costing re-processing cost authorization by sunil jain on 4 june 2013
            If (GridView1.SelectedRow.Cells(3).Text = "1014") Then


                Dim sql As String = "SELECT distinct  b.EmpCode FROM dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a INNER JOIN Jct_Ops_SanctioNote_Area_Emp_Auth_Listing b ON a.EMPCODE = b.EmpCode WHERE   ID = '" + Trim(GridView1.SelectedRow.Cells(2).Text) + "' AND a.AUTH_DATETIME IS NULL AND a.Remarks IS NULL AND b.AreaCode = 1031  "

                If (objFun.CheckRecordExistInTransaction(sql)) Then

                    If (Session("EmpCode") = objFun.FetchValue(sql)) Then

                        pnlReProcessingCost.Visible = True
                        ViewState("Cst_Cost") = "1"
                    End If

                End If

                qry = "Exec Jct_Ops_Pending_Authorization_Fetch_Detail '" & Trim(GridView1.SelectedRow.Cells(2).Text) & "','" & Trim(GridView1.SelectedRow.Cells(3).Text) & "'"
                objFun.FillGrid(qry, GrdSanctionNoteDetail)
                qry = "exec Jct_Ops_SanctionNote_Authrization_Detail '" & Trim(GridView1.SelectedRow.Cells(2).Text) & "'"
                objFun.FillGrid(qry, GrdAuthHistory)
                qry = "SELECT  'Attachments' AS Attachment , ImgName AS AttachedFile FROM    dbo.Jct_Ops_SanctionNote_Attachments  WHERE   SanctionNoteID = '" + Trim(GridView1.SelectedRow.Cells(2).Text) + "'"
                Dim cmd As SqlCommand = New SqlCommand(qry, obj.Connection())
                Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim ds As DataSet = New DataSet()
                da.Fill(ds)
                dtlAttachment.DataSource = ds.Tables(0)
                dtlAttachment.DataBind()

            Else
                If (pnlReProcessingCost.Visible = True) Then

                    pnlReProcessingCost.Visible = False

                End If

                'qry = "Exec Jct_Ops_Pending_Authorization_Fetch_Detail '" & Trim(GridView1.SelectedRow.Cells(2).Text) & "','" & Trim(GridView1.SelectedRow.Cells(3).Text) & "'"
                'objFun.FillGrid(qry, GrdSanctionNoteDetail)

                If Trim(GridView1.SelectedRow.Cells(4).Text) = "ReInvoicing Sanction" Then
                    qry = "Exec Jct_Ops_ReInvoicing_SanctionNote_Detail_Fetch '" & Trim(GridView1.SelectedRow.Cells(2).Text) & "'" ','" & Trim(GridView1.SelectedRow.Cells(2).Text) & "'"
                    objFun.FillGrid(qry, GrdSanctionNoteDetail)
                Else

                    qry = "Exec Jct_Ops_Pending_Authorization_Fetch_Detail '" & Trim(GridView1.SelectedRow.Cells(2).Text) & "','" & Trim(GridView1.SelectedRow.Cells(3).Text) & "'"
                    objFun.FillGrid(qry, GrdSanctionNoteDetail)
                End If

                qry = "exec Jct_Ops_SanctionNote_Authrization_Detail '" & Trim(GridView1.SelectedRow.Cells(2).Text) & "'"
                objFun.FillGrid(qry, GrdAuthHistory)
                qry = "   SELECT  'Attachments' AS Attachment , ImgName AS AttachedFile FROM    dbo.Jct_Ops_SanctionNote_Attachments  WHERE   SanctionNoteID = '" + Trim(GridView1.SelectedRow.Cells(2).Text) + "'"
                Dim cmd As SqlCommand = New SqlCommand(qry, obj.Connection())
                Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim ds As DataSet = New DataSet()
                da.Fill(ds)
                dtlAttachment.DataSource = ds.Tables(0)
                dtlAttachment.DataBind()

            End If
            'qry = "Exec Jct_Ops_Pending_Authorization_Fetch_Detail '" & Trim(GridView1.SelectedRow.Cells(2).Text) & "','" & Trim(GridView1.SelectedRow.Cells(3).Text) & "'"
            'objFun.FillGrid(qry, GrdSanctionNoteDetail)
            'qry = "exec Jct_Ops_SanctionNote_Authrization_Detail '" & Trim(GridView1.SelectedRow.Cells(2).Text) & "'"
            'objFun.FillGrid(qry, GrdAuthHistory)
            'qry = "   SELECT  'Attachments' AS Attachment , ImgName AS AttachedFile FROM    dbo.Jct_Ops_SanctionNote_Attachments  WHERE   SanctionNoteID = '" + Trim(GridView1.SelectedRow.Cells(2).Text) + "'"
            'Dim cmd As SqlCommand = New SqlCommand(qry, obj.Connection())
            'Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            'Dim ds As DataSet = New DataSet()
            'da.Fill(ds)
            'dtlAttachment.DataSource = ds.Tables(0)
            'dtlAttachment.DataBind()
        Catch ex As Exception
            MsgBox("" & ex.ToString)

        End Try

        'If Trim(GridView1.SelectedRow.Cells(3).Text) = "Exception" Then
        '    Panel1.Visible = True
        'Else
        '    Panel1.Visible = False
        'End If
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
            Dim CurrentUserName As String = ""
            Dim RaisedByUserName As String = ""
            Dim Scrpt As String = ""
            Dim AuthMob As String = ""
            Dim OutOfOffice As Boolean = False

            txtRemarks.Text = txtRemarks.Text.Replace("'", "''")

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
                            RaisedByUserName = objFun.FetchValue("SELECT b.empname FROM Jct_Ops_SanctionNote_HDR a,dbo.JCT_EmpMast_Base b WHERE a.UserCode=b.empcode AND a.SanctionNoteID='" & SanctionNote & "'")
                            AreaCode = Trim(.SelectedRow.Cells(3).Text)
                            Subject = Trim(.SelectedRow.Cells(6).Text)
                            qry = "SELECT AreaName FROM dbo.Jct_Ops_SanctioNote_Area_Master WHERE Status='A' AND ParentArea='1015' AND AreaCode='" & AreaCode & "'"
                            Area = objFun.FetchValue(qry)
                            ViewState("ID") = SanctionNote



                            Tran = obj.Connection.BeginTransaction
                            con = obj.Connection
                            If AreaCode = 9999 Then
                                Area = Trim(.SelectedRow.Cells(6).Text)
                                Area = Area.Substring(Area.IndexOf("~ ") + 2, Area.IndexOf(" -") - Area.IndexOf("~ ") - 2)

                                'OrderNo = GrdSanctionNoteDetail.Rows(0).Cells(1).Text
                                'Sort = GrdSanctionNoteDetail.Rows(0).Cells(2).Text
                                Shade = GrdSanctionNoteDetail.Rows(0).Cells(4).Text
                                Lineno = GrdSanctionNoteDetail.Rows(0).Cells(5).Text
                                Qty = GrdSanctionNoteDetail.Rows(0).Cells(6).Text
                                Reqd_Date = GrdSanctionNoteDetail.Rows(0).Cells(7).Text
                            End If
                            If AreaCode <> 9999 Then

                                If AreaCode = 1014 Then
                                    qry = "SELECT e_mailid  from jct_ops_material_request a inner join mistel b on a.userid=b.empcode  where requestid=" + ViewState("ID") + ""
                                    FinalNotify = objFun.FetchValue(qry, con, Tran)
                                Else
                                    'qry = "SELECT STUFF((SELECT ',' + s.E_MailID FROM (SELECT 1 ID,E_MailID from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,MISTEL c  WHERE id='" & SanctionNote & "' AND a.EMPCODE=c.empcode  UNION SELECT  1 ID,E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,MISTEL c  WHERE SanctionID='" & SanctionNote & "' AND a.NotifyUser=c.empcode UNION  SELECT  1 ID ,E_MailID FROM    dbo.Jct_Ops_SanctionNote_Notify a ,MISTEL c WHERE   SanctionID = '" & SanctionNote & "' AND a.Usercode = c.empcode UNION SELECT    1 ID ,         E_MailID    FROM      MISTEL c WHERE     c.empcode = 'P-03055' ) s WHERE s.id = t.id FOR XML PATH('')),1,1,'') AS CSV FROM (SELECT 1 ID,E_MailID FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,MISTEL c  WHERE id='" & SanctionNote & "' AND a.EMPCODE=c.empcode  UNION SELECT  1 ID,E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,MISTEL c  WHERE SanctionID='" & SanctionNote & "' AND a.NotifyUser=c.empcode ) AS t GROUP BY t.id"
                                    qry = "SELECT STUFF((SELECT ',' + s.E_MailID FROM (SELECT 1 ID,E_MailID from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,MISTEL c  WHERE id='" & SanctionNote & "' AND a.EMPCODE=c.empcode  and a.status is null UNION SELECT  1 ID,E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,MISTEL c  WHERE SanctionID='" & SanctionNote & "' AND a.NotifyUser=c.empcode UNION  SELECT  1 ID ,E_MailID FROM  dbo.Jct_Ops_SanctionNote_HDR a , MISTEL c WHERE     SanctionNoteID = '" & SanctionNote & "' AND a.Usercode = c.empcode ) s WHERE s.id = t.id FOR XML PATH('')),1,1,'') AS CSV FROM (SELECT 1 ID,E_MailID FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,MISTEL c  WHERE id='" & SanctionNote & "' AND a.EMPCODE=c.empcode  and a.status is null  UNION SELECT  1 ID,E_MailID FROM dbo.Jct_Ops_SanctionNote_HDR a,MISTEL c  WHERE SanctionNoteID='" & SanctionNote & "' AND a.UserCode=c.empcode ) AS t GROUP BY t.id"
                                    FinalNotify = objFun.FetchValue(qry, con, Tran)
                                End If

                                qry = "Select isnull(convert(varchar,UserLevel),'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE AreaCode='" & AreaCode & "' and id='" & SanctionNote & "' and empcode='" & Session("Empcode") & "'   and status is null"
                                CurrentUserLevel = objFun.FetchValue(qry, con, Tran)

                                If CurrentUserLevel Is Nothing Then CurrentUserLevel = "None"


                                If CurrentUserLevel <> "None" Then
                                    qry = "Select top 1 isnull(convert(varchar,UserLevel),'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE AreaCode='" & AreaCode & "'  and id='" & SanctionNote & "' and empcode<>'" & Session("Empcode") & "' and userlevel>'" & Val(CurrentUserLevel) & "'  and status is null order by userlevel"
                                    NextAuthLevel = objFun.FetchValue(qry, con, Tran)
                                Else
                                    objFun.Alert("Unable to Your Authoirze...!!!")

                                    Tran.Rollback()
                                    Exit Sub
                                End If

                                qry = "Select top 1 isnull(E_MailID,'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,mistel b WHERE AreaCode='" & AreaCode & "'  and id='" & SanctionNote & "' and a.empcode<>'" & Session("Empcode") & "' and userlevel>='" & Val(CurrentUserLevel) & "' and a.empcode=b.empcode  and a.status is null order by userlevel"
                                SendMailTo = objFun.FetchValue(qry, obj.Connection, Tran)


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
                                    Dim NxtAuthEmp As String = ""

                                    qry = "SELECT isnull(EMPCODE,'') FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE id='" & SanctionNote & "' AND USERLEVEL=" & NextAuthLevel & " AND STATUS IS null "
                                    NxtAuthEmp = objFun.FetchValue(qry)
                                    'If (NxtAuthEmp = Nothing Or NxtAuthEmp = "") And LCase(NxtAuthEmp) = "m-00063" Then
                                    '    qry = "SELECT 'True' FROM JCT_OPS_SANCTIONNOTE_OUT_OF_OFFICE WHERE STATUS='A' AND GETDATE() BETWEEN DateFrom AND DateTo and USERCode='m-00063'"
                                    '    OutOfOffice = objFun.CheckRecordExistInTransaction(qry)
                                    'End If
                                    If (NxtAuthEmp = Nothing Or NxtAuthEmp = "") Then
                                        OutOfOffice = False
                                    End If
                                    If LCase(NxtAuthEmp) = "m-00063" Then
                                        qry = "SELECT 'True' FROM JCT_OPS_SANCTIONNOTE_OUT_OF_OFFICE WHERE STATUS='A' AND GETDATE() BETWEEN DateFrom AND DateTo and USERCode='m-00063'"
                                        OutOfOffice = objFun.CheckRecordExistInTransaction(qry)
                                    End If


                                    qry = "Update Jct_Ops_SanctionNote_HDR set AuthFlag='P',PendingAt='" & NextAuthLevel & "',LastAuthBy='" & CurrentUserLevel & "',LastAuthOn=getdate() where SanctionNoteID='" & SanctionNote & "' and status='A' and AuthFlag='P'"
                                    objFun.UpdateRecord(qry, Tran, con)


                                    qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set AUTH_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "' and status is null"
                                    objFun.UpdateRecord(qry, Tran, con)


                                    If OutOfOffice = Nothing Then OutOfOffice = False
                                    If OutOfOffice = True Then
                                        qry = "Update Jct_Ops_SanctionNote_HDR set AuthFlag='A',PendingAt='',LastAuthBy='" & MaxAuthLevel & "',LastAuthOn=getdate(),Spl_Remarks='Authorized--COO Out of Office!!Auto Update Applied' where SanctionNoteID='" & SanctionNote & "' and status='A' and AuthFlag='P'"
                                        objFun.UpdateRecord(qry, Tran, con)
                                        qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set AUTH_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='Authorized--COO Out of Office!!Auto Update Applied' WHERE ID='" & SanctionNote & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & MaxAuthLevel & "' and status is null"
                                        objFun.UpdateRecord(qry, Tran, con)
                                        CurrentUserLevel = MaxAuthLevel 'This is assigned in case Mike Out of office and to send final mail to every one....
                                    End If

                                    If CurrentUserLevel = MaxAuthLevel Then
                                        Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & SanctionNote & " Is " & ddlAction.SelectedItem.Text & " </h3></b> By <b> " & CurrentUserName & " " ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                                    Else
                                        Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & SanctionNote & " Is " & ddlAction.SelectedItem.Text & " </h3></b> By <b> " & CurrentUserName & " and is now Pending for your Approval" ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                                    End If
                                Else ' Else part will be executed in case when either maxauthlevel is achevied or some one wants to cancel any sanctionnote
                                    qry = "Update Jct_Ops_SanctionNote_HDR set AuthFlag='" & Left(ddlAction.SelectedItem.Text, 1) & "',PendingAt='',LastAuthBy='" & CurrentUserLevel & "',LastAuthOn=getdate() where SanctionNoteID='" & SanctionNote & "' and status='A'  and AuthFlag='P'"
                                    objFun.UpdateRecord(qry, Tran, con)

                                    'If Left(ddlAction.SelectedItem.Text, 1) = "A" Then
                                    '    qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL ,AUTH_DATETIME,CREATED_ONHOST ,Remarks) values('" & SanctionNote & "','" & Session("Empcode") & "','" & AreaCode & "','" & Session("Empcode") & "','" & CurrentUserLevel & "',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "')"
                                    'Else
                                    '    qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL ,CANCEL_DATETIME,CREATED_ONHOST ,Remarks) values('" & SanctionNote & "','" & Session("Empcode") & "','" & AreaCode & "','" & Session("Empcode") & "','" & CurrentUserLevel & "',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "')"
                                    'End If


                                    If Left(ddlAction.SelectedItem.Text, 1) = "A" Then
                                        qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set AUTH_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "' and status is null"
                                        objFun.InsertRecord(qry, Tran, con)

                                        If (AreaCode = 1014) Then

                                            ' Added to add costing re-processing cost authorization by sunil jain on 4 june 2013

                                            If (ViewState("Cst_Cost") = 1) Then

                                                If (txtReprocessingCost.Text = "") Then

                                                    objFun.Alert("Please enter re-processing cost..!!")

                                                Else

                                                    qry = "update jct_ops_material_request set Cst_Cost='" + txtReprocessingCost.Text + "', AuthStatus='" & Left(ddlAction.SelectedItem.Text, 1) & "',Auth_By='" & Session("Empcode") & "'  WHERE  RequestID=" & SanctionNote & ""
                                                    objFun.UpdateRecord(qry, Tran, con)
                                                End If


                                            Else

                                                qry = "update jct_ops_material_request set   AuthStatus='" & Left(ddlAction.SelectedItem.Text, 1) & "',Auth_By='" & Session("Empcode") & "'  WHERE  RequestID=" & SanctionNote & ""
                                                objFun.UpdateRecord(qry, Tran, con)
                                            End If

                                            'qry = "update jct_ops_material_request set AuthStatus='" & Left(ddlAction.SelectedItem.Text, 1) & "',Auth_By='" & Session("Empcode") & "'  WHERE  RequestID=" & SanctionNote & ""
                                            'objFun.UpdateRecord(qry, Tran, con)
                                        End If
                                    Else

                                        If SendMailTo <> "" Then
                                            Dim Sp As String
                                            Sp = ""
                                            qry = "Select top 1 isnull(E_MailID,'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,mistel b WHERE AreaCode='" & AreaCode & "'  and id='" & SanctionNote & "' and a.status is null and a.Usercode=b.empcode order by userlevel"
                                            Sp = objFun.FetchValue(qry, obj.Connection, Tran)
                                            If Sp Is Nothing Then Sp = ""
                                            If Sp <> "" Then SendMailTo = SendMailTo & "," & Sp
                                        End If
                                        qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set CANCEL_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "' and status is null"
                                        objFun.InsertRecord(qry, Tran, con)
                                        If (AreaCode = 1014) Then
                                            qry = "update jct_ops_material_request set AuthStatus='" & Left(ddlAction.SelectedItem.Text, 1) & "',cancelled_date=getdate(),Cancelled_by='" & Session("Empcode") & "',mr_status='C'  WHERE  RequestID=" & SanctionNote & ""
                                            objFun.UpdateRecord(qry, Tran, con)
                                        End If
                                    End If


                                    '  If CurrentUserLevel = MaxAuthLevel Then
                                    'Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & SanctionNote & " Is " & ddlAction.SelectedItem.Text & " </h3></b> By <b> " & CurrentUserName & " " ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                                    'Else
                                    Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & SanctionNote & " Is " & ddlAction.SelectedItem.Text & " </h3></b> By <b> " & CurrentUserName & " " ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                                    ' End If
                                End If
                            Else '-----Will be executed when Exceptions are ment to be authorised or Unauthorized
                                qry = "update Jct_Ops_Process_Plan_Exception set PendingAt='',LastAuthBy='" & Session("Empcode") & "',LastAuthOn=getdate(),AuthFlag='" & Left(ddlAction.SelectedItem.Text, 1) & "',IntialAuthRemarks='" & txtRemarks.Text & "'  WHERE STATUS='A' AND LastAuthBy IS NULL and ExceptionID=" & SanctionNote & ""
                                objFun.InsertRecord(qry, Tran, con)
                                ''Body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b> " '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Line & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>Finishing</P> <b>Meters :-" & DyngQty & "</b> was Planned to be <b>Dyed on :-</b> '" & ReqDyngDate & "' <br><hr><br><br><P>Finishing</P> Meter Planned for Finishing are :-</b> '" & FinsihQty & "' <b>On Date </b> '" & ReqFinishDate & "'  <h3>This Order Has been Removed from Dyeing and Finish (Processing) Plan by '" & Removedby & "' </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"

                                Body = "<p>Hello.....,</p>This Order has been approved for re-scheduling in " & Area & " is <B>Pending At Planning's Approval </b><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)", obj.Connection, Tran)) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & CurrentUserName & "  </h3>  <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"


                            End If

                            Tran.Commit()
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

                            'Scrpt = "alert('SanctionNote ' + '" + ddlAction.SelectedItem.Text + "'+'ed...!!!');"
                            'ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
                            'objFun.Alert("SanctionNote " & ddlAction.SelectedItem.Text & "ed...!!!")
                            Try
                                Dim sm As New SendMail
                                If CurrentUserLevel = MaxAuthLevel Then
                                    'Code To Send SMS to SalePerson Raising the Sanction Note
                                    AuthMob = objFun.FetchValue("SELECT b.mobile,b.name FROM mistel b,dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a WHERE a.Usercode=b.empcode  AND a.ID='" & SanctionNote & "' and a.status is null")
                                Else

                                    AuthMob = objFun.FetchValue("SELECT b.mobile,b.name FROM mistel b,dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a WHERE a.EMPCODE=b.empcode AND a.userlevel=" & NextAuthLevel & " AND a.ID='" & SanctionNote & "'  and a.status is null")
                                End If

                                Dim msg As String = "Sanction Note " & SanctionNote & " is due for approval. It was last approved by " & CurrentUserName & " and raised by " & RaisedByUserName

                                If Len(AuthMob) >= 10 Then
                                    sm.SendSMS(Session("CompanyCode"), Session("EmpCode"), AuthMob, msg, "SanctionNote " & ddlAction.SelectedItem.Text & "ation Sent")
                                End If
                            Catch
                                Scrpt = "alert('Unable to Send SMS Alert...!!!');"
                                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
                            End Try

                            If AreaCode = 9999 Then
                                ' objFun.SendMailOPS(Body, "", SalePersonEmail, Session("Empcode"), "ashish@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,manishk@jctltd.com", "Your orderNO :-""  SortNo :-  ""' Shade :-  " & Shade & " was Reequested be Re-Planned in " & Area & " section and the request was generated by  " & UserName)
                            Else ' Else part executed for all sanction note other than Exceptions
                                Try
                                    qry = "SELECT DESCRIPTION FROM dbo.Jct_Ops_SanctionNote_HDR WHERE SanctionNoteID='" & SanctionNote & "' AND STATUS='A'"
                                    Dim Body1 As String = "Subject Mentioned :- " & Subject & " <hr><br><br> Under Area :-" & Area & " <BR> <HR> <b>With below detailed Info :-</b>" & objFun.FetchValue(qry) & " <hr>"
                                    Dim Val1 As String = ""
                                    Dim ParmName As String = ""
                                    For i = 0 To GrdSanctionNoteDetail.Rows.Count - 1
                                        ParmName = GrdSanctionNoteDetail.Rows(i).Cells(0).Text
                                        Val1 = GrdSanctionNoteDetail.Rows(i).Cells(1).Text
                                        Body1 = Body1 & "<p> <b>" & ParmName & " :-</b> " & Val1 & " </p> "
                                    Next
                                    Body3 = "<br/><a href='http://testerp/fusionapps/OPS/AuthorizeSanction_Note.aspx'> Click here to view details... </a><br /><br /> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"

                                    If (AreaCode = 1014) Then
                                        SendMail("", SendMailTo, AuthorizedBy, "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,manishk@jctltd.com", "SanctionNote :-" & SanctionNote & "  has been " & ddlAction.SelectedItem.Text & "", SanctionNote, CurrentUserLevel, MaxAuthLevel, FinalNotify, ddlAction.SelectedItem.Text)
                                    Else
                                        SendMail(Body, Body1, Body3, "", SendMailTo, AuthorizedBy, "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,manishk@jctltd.com", "SanctionNote :-" & SanctionNote & "  has been " & ddlAction.SelectedItem.Text & "", SanctionNote, CurrentUserLevel, MaxAuthLevel, FinalNotify, ddlAction.SelectedItem.Text)
                                    End If

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
                ' ObjSendMail.SendMail("Ashish@jctltd.com", "noreply@jctltd.com", "Error in Authorizing SanctionNote !!!", "The sanction note no " & SanctionNote & "was under authorization process but some error was genrated.....<br> " & ex.ToString)
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

        GrdSanctionNoteDetail.DataSource = Nothing
        GrdSanctionNoteDetail.DataBind()
    End Sub



    Private Sub SendMail(Body__1 As String, Body2 As String, body3 As String, RaisedBy_Email As String, [to] As String, cc As String, bcc As String, Subject As String, SanctionNote As String, CurrentLevel As Int16, MaxLevel As Int16, NotifyAllList As String, Action As String)
        Try
            Dim from As String
            Dim sb As New StringBuilder()
            from = "noreply@jctltd.com"
            Dim query As String = ""
            Dim SenderEmail As String = ""
            Dim da As SqlDataAdapter
            Dim Dt As DataTable = New DataTable
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

            bcc = "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,manishk@jctltd.com"
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
            If [to] = "rohits@jctltd.com" Or [to] = "Ashish@jctltd.com" Then
                'from = "approvals@jctltd.com"
                'cc = NotifyAllList
                'sb.AppendLine("<html>")
                'sb.AppendLine("<br/><br/>")
                'sb.AppendLine(Body__1)

                'sb.AppendLine("Please reply this email with 'YES'  to authorise and  'NO' to cancel and 'REMARKS'.<br/> <br/>")

                Dim Desc As String
                Desc = objFun.FetchValue("SELECT DESCRIPTION FROM dbo.Jct_Ops_SanctionNote_HDR WHERE SanctionNoteID='" & SanctionNote & "'")
                If Desc Is Nothing Then Desc = ""


                Dim Area As String
                Area = objFun.FetchValue("SELECT AreaCode FROM dbo.Jct_Ops_SanctionNote_HDR WHERE SanctionNoteID='" & SanctionNote & "'")
                If Area Is Nothing Then Area = ""





                from = "approvals@jctltd.com"
                If Area = "1014" Then
                    cc = NotifyAllList & ",ashish@jctltd.com,william@jctltd.com,manishk@jctltd.com,skj@jctltd.com"
                ElseIf Area <> "1059" Then
                    cc = NotifyAllList & ",ashish@jctltd.com,manishk@jctltd.com"
                ElseIf Area = "1059" Then
                    cc = NotifyAllList & ",ashish@jctltd.com,william@jctltd.com,manishk@jctltd.com,skj@jctltd.com"
                End If

                sb.AppendLine("<html>")
                sb.AppendLine("<br/><br/>")
                sb.AppendLine("Please reply this email with 'YES'  to authorise and  'NO' to cancel and 'REMARKS'.<br/> <br/>")
                sb.AppendLine(Body__1 & " <br/>")

                If Desc <> "" Then sb.AppendLine("<hr><br/><b>Description :-</b>" & Desc & "<br/> <hr><br/>")



                sb.AppendLine("Sanction Note was Genrated with the follwing parameters: <br/><br/>")
                sb.AppendLine("<head>")
                sb.AppendLine("<style type=""text/css"">")
                sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}")
                sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}")
                sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}")
                sb.AppendLine("</style>")
                sb.AppendLine("</head>")









                sb.AppendLine("<table class=gridtable>")
                Dim GridHeader As String = ""
                Dim Q As String = ""
                Dim J As Int16 = 0
                Dim body1 As String = ""
                With GrdSanctionNoteDetail


                    For i = 0 To GrdSanctionNoteDetail.Rows.Count - 1

                        Q = "<tr>"
                        'This if is used to Fetch Header from Gridview
                        If i = 0 Then
                            For J = 0 To 1 '.Columns.Count

                                GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"

                            Next
                            body1 = body1 & GridHeader & " </tr>"
                        End If

                        'This loops feteches data from each cell of grid
                        For J = 0 To 1 '.Columns.Count
                            If i = 0 Then
                                'query += "<th>" & .Rows(i).Cells(J).Text & "</th>"
                                GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"
                            End If
                            Q += "<td>" & .Rows(i).Cells(J).Text & "</td>"
                        Next
                        body1 = body1 & Q & " </tr>"

                    Next
                End With
                sb.AppendLine("" & body1)
                'Sb.AppendLine("<table class=gridtable>")
                'Sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th> Auth. Pending At</th> </tr>")



                sb.AppendLine("</table>")
                sb.AppendLine("<br />")


                sb.AppendLine("</table><br />")





                sb.AppendLine("Authorization Remarks are Shown below: <br/><br/>")
                sb.AppendLine("<head>")
                sb.AppendLine("<style type=""text/css"">")
                sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}")
                sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}")
                sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}")
                sb.AppendLine("</style>")
                sb.AppendLine("</head>")


                sb.AppendLine("<table class=gridtable>")

                GridHeader = ""
                Q = ""
                J = 0
                body1 = ""
                With GrdAuthHistory


                    For i = 0 To GrdAuthHistory.Rows.Count - 2

                        ''''''''''Q = "<tr>"
                        Q = ""
                        'This if is used to Fetch Header from Gridview
                        If i = 0 Then
                            For J = 1 To 5 '.Columns.Count

                                GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"

                            Next
                            body1 = body1 & GridHeader & " </tr>"
                        End If

                        'This loops feteches data from each cell of grid
                        '''''''''''''''For J = 1 To 5 '.Columns.Count
                        '''''''''''''''    If i = 0 Then
                        '''''''''''''''        'query += "<th>" & .Rows(i).Cells(J).Text & "</th>"
                        '''''''''''''''        GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"
                        '''''''''''''''    End If
                        '''''''''''''''    Q += "<td>" & .Rows(i).Cells(J).Text & "</td>"
                        '''''''''''''''Next
                        '''''''''''''''body1 = body1 & Q & " </tr>"


                    Next
                    qry = "exec Jct_Ops_SanctionNote_Authrization_Detail '" & Trim(GridView1.SelectedRow.Cells(2).Text) & "'"
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
                    body1 = body1 & Q
                End With
                sb.AppendLine("" & body1)
                'Sb.AppendLine("<table class=gridtable>")
                'Sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th> Auth. Pending At</th> </tr>")



                sb.AppendLine("</table>")
                sb.AppendLine("<br />")


                sb.AppendLine("</table><br />")
                sb.AppendLine("<br/><a href='http://testerp/fusionapps/OPS/AuthorizeSanction_Note.aspx'> Click here to view details... </a><br /><br /> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p><br>")
                ' Sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>")
                sb.AppendLine("Thank you<br />")
                sb.AppendLine("</html>")
                mail.Body = sb.ToString




                '''''''''''''''''''''sb.AppendLine("<table class=gridtable>")
                '''''''''''''''''''''Dim GridHeader As String = ""
                '''''''''''''''''''''Dim Q As String = ""
                '''''''''''''''''''''Dim J As Int16 = 0
                '''''''''''''''''''''Dim body1 As String = ""
                '''''''''''''''''''''With GrdSanctionNoteDetail


                '''''''''''''''''''''    For i = 0 To GrdSanctionNoteDetail.Rows.Count - 1

                '''''''''''''''''''''        Q = "<tr>"
                '''''''''''''''''''''        'This if is used to Fetch Header from Gridview
                '''''''''''''''''''''        If i = 0 Then
                '''''''''''''''''''''            For J = 0 To 1 '.Columns.Count

                '''''''''''''''''''''                GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"

                '''''''''''''''''''''            Next
                '''''''''''''''''''''            body1 = body1 & GridHeader & " </tr>"
                '''''''''''''''''''''        End If

                '''''''''''''''''''''        'This loops feteches data from each cell of grid
                '''''''''''''''''''''        For J = 0 To 1 '.Columns.Count
                '''''''''''''''''''''            If i = 0 Then
                '''''''''''''''''''''                'query += "<th>" & .Rows(i).Cells(J).Text & "</th>"
                '''''''''''''''''''''                GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"
                '''''''''''''''''''''            End If
                '''''''''''''''''''''            Q += "<td>" & .Rows(i).Cells(J).Text & "</td>"
                '''''''''''''''''''''        Next
                '''''''''''''''''''''        body1 = body1 & Q & " </tr>"

                '''''''''''''''''''''    Next
                '''''''''''''''''''''End With
                '''''''''''''''''''''sb.AppendLine("" & body1)
                ''''''''''''''''''''''Sb.AppendLine("<table class=gridtable>")
                ''''''''''''''''''''''Sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th> Auth. Pending At</th> </tr>")



                '''''''''''''''''''''sb.AppendLine("</table>")
                '''''''''''''''''''''sb.AppendLine("<br />")


                '''''''''''''''''''''sb.AppendLine("</table><br />")





                '''''''''''''''''''''sb.AppendLine("Authorization Remarks are Shown below: <br/><br/>")
                '''''''''''''''''''''sb.AppendLine("<head>")
                '''''''''''''''''''''sb.AppendLine("<style type=""text/css"">")
                '''''''''''''''''''''sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}")
                '''''''''''''''''''''sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}")
                '''''''''''''''''''''sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}")
                '''''''''''''''''''''sb.AppendLine("</style>")
                '''''''''''''''''''''sb.AppendLine("</head>")


                '''''''''''''''''''''sb.AppendLine("<table class=gridtable>")

                '''''''''''''''''''''GridHeader = ""
                '''''''''''''''''''''Q = ""
                '''''''''''''''''''''J = 0
                '''''''''''''''''''''body1 = ""
                '''''''''''''''''''''With GrdAuthHistory

                '''''''''''''''''''''    qry = "SELECT id AS SanctionID,AUTH_DATETIME AS AuthorizedOn,UserLevel,EmpName,Remarks FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,dbo.JCT_EmpMast_Base b WHERE a.EMPCODE=b.empcode and id='" & SanctionNote & "' AND USERLEVEL<=" & CurrentLevel & "  ORDER BY USERLEVEL"
                '''''''''''''''''''''    cmd = New SqlCommand(qry, obj.Connection)

                '''''''''''''''''''''    da = New SqlDataAdapter(cmd)
                '''''''''''''''''''''    obj.ConOpen()
                '''''''''''''''''''''    da.Fill(Dt)
                '''''''''''''''''''''    obj.ConClose()
                '''''''''''''''''''''    da.Dispose()
                '''''''''''''''''''''    'dr = cmd.ExecuteReader
                '''''''''''''''''''''    'dr.Read()
                '''''''''''''''''''''    'If dr.HasRows = True Then

                '''''''''''''''''''''    'End If

                '''''''''''''''''''''    For Each dc As DataColumn In Dt.Columns
                '''''''''''''''''''''        Q = "<tr>"
                '''''''''''''''''''''        GridHeader += "<th> " & dc.ColumnName.ToString() & "</th>"

                '''''''''''''''''''''    Next
                '''''''''''''''''''''    body1 = body1 & GridHeader & " </tr>"






                '''''''''''''''''''''    For i As Integer = 0 To Dt.Rows.Count - 1

                '''''''''''''''''''''        For jk As Integer = 0 To Dt.Columns.Count - 1


                '''''''''''''''''''''            Q += "<td>" & Dt.Rows(i)(jk).ToString() & "</td>"

                '''''''''''''''''''''        Next
                '''''''''''''''''''''        body1 = body1 & Q & " </tr>"
                '''''''''''''''''''''    Next





                '''''''''''''''''''''    'For i = 0 To GrdAuthHistory.Rows.Count - 1

                '''''''''''''''''''''    '    Q = "<tr>"
                '''''''''''''''''''''    '    'This if is used to Fetch Header from Gridview
                '''''''''''''''''''''    '    If i = 0 Then
                '''''''''''''''''''''    '        For J = 1 To 5 '.Columns.Count

                '''''''''''''''''''''    '            GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"

                '''''''''''''''''''''    '        Next
                '''''''''''''''''''''    '        body1 = body1 & GridHeader & " </tr>"
                '''''''''''''''''''''    '    End If

                '''''''''''''''''''''    '    'This loops feteches data from each cell of grid
                '''''''''''''''''''''    '    For J = 1 To 5 '.Columns.Count
                '''''''''''''''''''''    '        If i = 0 Then
                '''''''''''''''''''''    '            'query += "<th>" & .Rows(i).Cells(J).Text & "</th>"
                '''''''''''''''''''''    '            GridHeader += "<th> " & .HeaderRow.Cells(J).Text & "</th>"
                '''''''''''''''''''''    '        End If
                '''''''''''''''''''''    '        Q += "<td>" & .Rows(i).Cells(J).Text & "</td>"
                '''''''''''''''''''''    '    Next
                '''''''''''''''''''''    '    body1 = body1 & Q & " </tr>"

                '''''''''''''''''''''    'Next
                '''''''''''''''''''''End With
                '''''''''''''''''''''sb.AppendLine("" & body1)
                ''''''''''''''''''''''Sb.AppendLine("<table class=gridtable>")
                ''''''''''''''''''''''Sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th> Auth. Pending At</th> </tr>")



                '''''''''''''''''''''sb.AppendLine("</table>")
                '''''''''''''''''''''sb.AppendLine("<br />")


                '''''''''''''''''''''sb.AppendLine("</table><br />")
                '''''''''''''''''''''sb.AppendLine("<br/><a href='http://testerp/fusionapps/OPS/AuthorizeSanction_Note.aspx'> Click here to view details... </a><br /><br /> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p><br>")
                '''''''''''''''''''''' Sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>")
                '''''''''''''''''''''sb.AppendLine("Thank you<br />")
                '''''''''''''''''''''sb.AppendLine("</html>")
                '''''''''''''''''''''mail.Body = sb.ToString
                cc = cc & ",rbaksshi@jctltd.com"
            Else
                mail.Body = Body__1 & " " & Body2 & " " & body3

            End If


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

            'Sb.a()
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

    Protected Sub CmdCancel_Click(sender As Object, e As System.EventArgs) Handles CmdCancel.Click
        RefreshLists()

    End Sub

    Private Sub SendMail(RaisedBy_Email As String, [to] As String, cc As String, bcc As String, Subject As String, SanctionNote As String, CurrentLevel As Int16, MaxLevel As Int16, NotifyAllList As String, Action As String)
        Dim from As String, body As String, Reason As String
        Dim sql As String
        Dim Auth As String
        Dim sb As New StringBuilder()
        Dim SenderEmail As String = ""
        If RaisedBy_Email Is Nothing Then
            RaisedBy_Email = ""
        End If
        Dim Description As String
        Dim FreightValue As String = String.Empty

        'query = "SELECT isnull(E_MailID,'') FROM dbo.MISTEL WHERE empcode='" & [to] & "' "
        SenderEmail = [to] 'objFun.FetchValue(query)
        sql = "Select Name from mistel where e_mailid='" + SenderEmail + "'"
        Dim Pending As String = objFun.FetchValue(sql)

        If (SenderEmail = "rohits@jctltd.com") Then

            EMail(SanctionNote)
            Exit Sub
        End If

        sql = "Select empname from jct_empmast_base where empcode='" + Session("EmpCode") + "'"
        Dim EmpName As String = objFun.FetchValue(sql)
        sql = "Select e_mailid from mistel where empcode='" + Session("EmpCode") + "'"
        Dim E_MailID As String = objFun.FetchValue(sql)

        sql = "SELECT b.E_MailID FROM dbo.jct_ops_material_request a INNER JOIN dbo.MISTEL b ON a.userid=b.empcode WHERE RequestID=" + SanctionNote
        Dim Request_by As String = objFun.FetchValue(sql).ToString()



        If (Left(Action, 1) = "A") Then

            If SenderEmail Is Nothing Then SenderEmail = ""

            If SenderEmail <> "" Then

                If (Not String.IsNullOrEmpty(E_MailID)) Then

                    If (Not String.IsNullOrEmpty(Request_by)) Then

                        [to] = SenderEmail + "," + E_MailID + "," + Request_by
                    Else
                        [to] = SenderEmail + "," + E_MailID

                    End If


                Else

                    [to] = SenderEmail

                End If

            Else
                [to] = RaisedBy_Email
                '[to] = "jatindutta@jctltd.com"
            End If
            If CurrentLevel = MaxLevel And CurrentLevel > 0 And Action = "Authorize" Then
                [to] = NotifyAllList
                '[to] = "jatindutta@jctltd.com"
            End If



            sb.AppendLine("<html>")
            sb.AppendLine("<head>")
            sb.AppendLine("<style type=""text/css"">")
            sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}")
            sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}")
            sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}")
            sb.AppendLine("</style>")
            sb.AppendLine("</head>")

            sb.AppendLine("Hi,<br/><br/>")
            sb.AppendLine("Material Return Request has been " + Action + " by " + EmpName + ".<br/><br/>")
            sb.AppendLine("RequestID for your request is : " + SanctionNote + " <br/><br/>")
            sb.AppendLine("Details are Shown below : <br/><br/>")
            sb.AppendLine("<table class=gridtable>")

            'sql = "SELECT isnull(a.invoice_no,'') as invoice_no,isnull(a.item_no,'') as item_no,isnull(a.customer,'') as customer,isnull(b.empname,'') as sales_person,isnull(Convert(numeric(12,2),a.invoice_qty),0) as invoice_qty,isnull(Convert(Numeric(12,2),a.ret_qty),0) as ret_qty ,isnull(Substring(a.FlagAuth,2,999),'') as FlagAuth,AuthStatus ,reason,isnull(description,'') as description ,FreightValue,a.Freight_by as FreightPaidBy,CONVERT(VARCHAR,a.invoice_date,103) AS invoice_date FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') WHERE a.RequestID=" + SanctionNote

            'Dim Dr As SqlDataReader = objFun.FetchReader(sql)
            'If (Dr.HasRows) Then
            '    While (Dr.Read())

            '        Reason = Dr(8).ToString
            '        Description = Dr(9).ToString()
            '        FreightValue = Dr(10).ToString()
            '        If (Dr(7).ToString() = "P") Then
            '            sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Invoice Date </th>  <th> Return Qty</th>  <th> Auth. Pending At</th><th>Freight Paid By</th></tr>")
            '            sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td>  <td> " & Dr("invoice_date").ToString() & " </td> <td>" & Dr(5).ToString & "</td>  <td>" & Pending & "</td> <td>" & Dr("FreightPaidBy").ToString() & "</td></tr> ")
            '        ElseIf (Dr(7).ToString() = "A") Then
            '            sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th>Status</th> </tr>")
            '            sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td>  <td> " & Dr("invoice_date").ToString() & " </td> <td>" & Dr(5).ToString & "</td>  <td>Authorized</td><td>" & Dr("FreightPaidBy").ToString() & "</td> </tr> ")
            '        End If


            '    End While

            'End If
            'Dr.Close()

            sql = "SELECT isnull(a.invoice_no,'') as invoice_no,isnull(a.item_no,'') as item_no,isnull(a.customer,'') as customer,isnull(b.empname,'') as sales_person,isnull(Convert(numeric(12,2),a.invoice_qty),0) as invoice_qty,isnull(Convert(Numeric(12,2),a.ret_qty),0) as ret_qty ,isnull(Substring(a.FlagAuth,2,999),'') as FlagAuth,AuthStatus ,reason,isnull(description,'') as description ,FreightValue,a.Freight_by as FreightPaidBy,CONVERT(VARCHAR,a.invoice_date,103) AS invoice_date FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') WHERE a.AuthStatus ='P' and a.RequestID=" + SanctionNote
            Dim Dr As SqlDataReader = objFun.FetchReader(sql)
            If (Dr.HasRows) Then

                sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Invoice Date </th>  <th> Return Qty</th>  <th> Auth. Pending At</th><th>Freight Paid By</th></tr>")
                While (Dr.Read())

                    Reason = Dr(8).ToString
                    Description = Dr(9).ToString()
                    FreightValue = Dr(10).ToString()
                    If (Dr(7).ToString() = "P") Then

                        sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td>  <td> " & Dr("invoice_date").ToString() & " </td> <td>" & Dr(5).ToString & "</td>  <td>" & Pending & "</td> <td>" & Dr("FreightPaidBy").ToString() & "</td></tr> ")
                        'ElseIf (Dr(7).ToString() = "A") Then
                        '    sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th>Status</th> </tr>")
                        '    sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td>  <td> " & Dr("invoice_date").ToString() & " </td> <td>" & Dr(5).ToString & "</td>  <td>Authorized</td><td>" & Dr("FreightPaidBy").ToString() & "</td> </tr> ")
                    End If


                End While

            End If
            Dr.Close()

            sql = "SELECT isnull(a.invoice_no,'') as invoice_no,isnull(a.item_no,'') as item_no,isnull(a.customer,'') as customer,isnull(b.empname,'') as sales_person,isnull(Convert(numeric(12,2),a.invoice_qty),0) as invoice_qty,isnull(Convert(Numeric(12,2),a.ret_qty),0) as ret_qty ,isnull(Substring(a.FlagAuth,2,999),'') as FlagAuth,AuthStatus ,reason,isnull(description,'') as description ,FreightValue,a.Freight_by as FreightPaidBy,CONVERT(VARCHAR,a.invoice_date,103) AS invoice_date FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') WHERE a.AuthStatus ='A' and a.RequestID=" + SanctionNote

            Dr = objFun.FetchReader(sql)
            If (Dr.HasRows) Then

                sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Invoice Date </th> <th> Return Qty</th>  <th>Status</th><th>Freight Paid By</th> </tr>")

                While (Dr.Read())

                    Reason = Dr(8).ToString
                    Description = Dr(9).ToString()
                    FreightValue = Dr(10).ToString()
                    If (Dr(7).ToString() = "P") Then
                        'sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Invoice Date </th>  <th> Return Qty</th>  <th> Auth. Pending At</th><th>Freight Paid By</th></tr>")
                        'sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td>  <td> " & Dr("invoice_date").ToString() & " </td> <td>" & Dr(5).ToString & "</td>  <td>" & Pending & "</td> <td>" & Dr("FreightPaidBy").ToString() & "</td></tr> ")
                    ElseIf (Dr(7).ToString() = "A") Then
                        sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td>  <td> " & Dr("invoice_date").ToString() & " </td> <td>" & Dr(5).ToString & "</td>  <td>Authorized</td><td>" & Dr("FreightPaidBy").ToString() & "</td> </tr> ")
                    End If


                End While

            End If
            Dr.Close()

            sb.AppendLine("</table>")
            sb.AppendLine("<br />")


            sb.AppendLine("</table><br />")

            sb.AppendLine("<br/><br />")
            sb.AppendLine("Reason For Qty Return : " + Reason + "<br /><br/>")
            sb.AppendLine("Freight Charges : " + FreightValue + "<br /><br/>")
            sb.AppendLine("Details provided by Marketing  : " + Description + "<br /><br/>")

            sb.AppendLine("Last Authorized by : " + EmpName + "<br /><br/>")

            sb.AppendLine("Last Authorization Remarks : " + txtRemarks.Text)
            sb.AppendLine("<br/><br />")
            sb.Append("<a href='http://testerp/fusionapps/OPS/AuthorizeSanction_Note.aspx'> Click here to view details... </a><br /><br />")
            sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>")
            sb.AppendLine("Thank you<br />")
            sb.AppendLine("</html>")


            body = sb.ToString()
            from = "noreply@jctltd.com"


            bcc = "ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,manishk@jctltd.com"

            If (Left(Action, 1) = "A") Then

                Subject = " Material Return Request :- Authorized"

            ElseIf (Left(Action, 1) = "C") Then

                Subject = " Material Return Request :- Cancelled"

            Else

                Subject = " Material Return Request :- " + Action

            End If

        ElseIf (Left(Action, 1) = "C") Then





            If (Not String.IsNullOrEmpty(E_MailID)) Then

                If (Not String.IsNullOrEmpty(Request_by)) Then

                    [to] = E_MailID + "," + Request_by
                Else

                    [to] = E_MailID
                End If


            Else
                [to] = RaisedBy_Email
                '[to] = "jatindutta@jctltd.com"
            End If
            If CurrentLevel = MaxLevel And CurrentLevel > 0 And Action = "Authorize" Then
                [to] = NotifyAllList
                '[to] = "jatindutta@jctltd.com"
            End If



            sb.AppendLine("<html>")
            sb.AppendLine("<head>")
            sb.AppendLine("<style type=""text/css"">")
            sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}")
            sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}")
            sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}")
            sb.AppendLine("</style>")
            sb.AppendLine("</head>")

            sb.AppendLine("Hi,<br/><br/>")
            sb.AppendLine("Material Return Request has been " + Action + " by " + EmpName + ".<br/><br/>")
            sb.AppendLine("RequestID for your request is : " + SanctionNote + " <br/><br/>")
            sb.AppendLine("Details are Shown below : <br/><br/>")
            sb.AppendLine("<table class=gridtable>")

            'sql = "SELECT isnull(a.invoice_no,'') as invoice_no,isnull(a.item_no,'') as item_no,isnull(a.customer,'') as customer,isnull(b.empname,'') as sales_person,isnull(Convert(numeric(12,2),a.invoice_qty),0) as invoice_qty,isnull(Convert(Numeric(12,2),a.ret_qty),0) as ret_qty ,isnull(Substring(a.FlagAuth,2,999),'') as FlagAuth,AuthStatus ,reason,isnull(description,'') as description,FreightValue,a.Freight_by as FreightPaidBy,CONVERT(VARCHAR,a.invoice_date,103) AS invoice_date FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') WHERE a.RequestID=" + SanctionNote

            'Dim Dr As SqlDataReader = objFun.FetchReader(sql)
            'If (Dr.HasRows) Then
            '    While (Dr.Read())

            '        Reason = Dr(8).ToString
            '        Description = Dr(9).ToString()
            '        FreightValue = Dr(10).ToString()
            '        If (Dr(7).ToString() = "P") Then
            '            sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Invoice Date</th> <th> Return Qty</th>  <th> Auth. Pending At</th><th> Freight Paid By</th> </tr>")
            '            sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td>  <td> " & Dr("invoice_date").ToString() & " </td> <td>" & Dr(5).ToString & "</td>  <td>" & Pending & "</td><td>" & Dr("FreightPaidBy").ToString & "</td> </tr> ")
            '        ElseIf (Dr(7).ToString() = "A") Then
            '            sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th> Status</th> </tr>")
            '            sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td>  <td> " & Dr("invoice_date").ToString() & " </td>  <td>" & Dr(5).ToString & "</td>  <td>Authorized</td> <td>" & Dr("FreightPaidBy").ToString & "</td></tr> ")
            '        ElseIf (Dr(7).ToString() = "C") Then
            '            sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th> Status</th> </tr>")
            '            sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td>  <td> " & Dr("invoice_date").ToString() & " </td> <td>" & Dr(5).ToString & "</td>  <td>Cancelled</td> <td>" & Dr("FreightPaidBy").ToString & "</td></tr> ")
            '        End If


            '    End While

            'End If
            'Dr.Close()

            sql = "SELECT isnull(a.invoice_no,'') as invoice_no,isnull(a.item_no,'') as item_no,isnull(a.customer,'') as customer,isnull(b.empname,'') as sales_person,isnull(Convert(numeric(12,2),a.invoice_qty),0) as invoice_qty,isnull(Convert(Numeric(12,2),a.ret_qty),0) as ret_qty ,isnull(Substring(a.FlagAuth,2,999),'') as FlagAuth,AuthStatus ,reason,isnull(description,'') as description,FreightValue,a.Freight_by as FreightPaidBy,CONVERT(VARCHAR,a.invoice_date,103) AS invoice_date FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') WHERE a.AuthStatus='C' and a.RequestID=" + SanctionNote

            Dim Dr As SqlDataReader = objFun.FetchReader(sql)
            If (Dr.HasRows) Then

                sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th>Invoice Date</th> <th> Return Qty</th>  <th> Status</th><th>FreightPaid By</th> </tr>")

                While (Dr.Read())

                    Reason = Dr(8).ToString
                    Description = Dr(9).ToString()
                    FreightValue = Dr(10).ToString()
                    If (Dr(7).ToString() = "P") Then
                        'sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Invoice Date</th> <th> Return Qty</th>  <th> Auth. Pending At</th><th> Freight Paid By</th> </tr>")
                        'sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td>  <td> " & Dr("invoice_date").ToString() & " </td> <td>" & Dr(5).ToString & "</td>  <td>" & Pending & "</td><td>" & Dr("FreightPaidBy").ToString & "</td> </tr> ")
                    ElseIf (Dr(7).ToString() = "A") Then
                        'sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th> Status</th> </tr>")
                        'sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td>  <td> " & Dr("invoice_date").ToString() & " </td>  <td>" & Dr(5).ToString & "</td>  <td>Authorized</td> <td>" & Dr("FreightPaidBy").ToString & "</td></tr> ")
                    ElseIf (Dr(7).ToString() = "C") Then
                        'sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th> Status</th> </tr>")
                        sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td>  <td> " & Dr("invoice_date").ToString() & " </td> <td>" & Dr(5).ToString & "</td>  <td>Cancelled</td> <td>" & Dr("FreightPaidBy").ToString & "</td></tr> ")
                    End If


                End While

            End If
            Dr.Close()


            sb.AppendLine("</table>")
            sb.AppendLine("<br />")


            sb.AppendLine("</table><br />")

            sb.AppendLine("<br/><br />")
            sb.AppendLine("Reason For Qty Return : " + Reason + "<br /><br/>")
            sb.AppendLine("Freight Charges : " + FreightValue + "<br /><br/>")
            sb.AppendLine("Details provided by Marketing  : " + Description + "<br /><br/>")

            sb.AppendLine("Last Authorized by : " + EmpName + "<br /><br/>")

            sb.AppendLine("Last Authorization Remarks : " + txtRemarks.Text)
            sb.AppendLine("<br/><br />")
            sb.Append("<a href='http://testerp/fusionapps/OPS/AuthorizeSanction_Note.aspx'> Click here to view details... </a><br /><br />")
            sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>")
            sb.AppendLine("Thank you<br />")
            sb.AppendLine("</html>")


            body = sb.ToString()
            from = "noreply@jctltd.com"

            bcc = "manishk@jctltd.com,ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com"

            If (Left(Action, 1) = "A") Then

                Subject = " Material Return Request :- Authorized"

            ElseIf (Left(Action, 1) = "C") Then

                Subject = " Material Return Request :- Cancelled"

            Else

                Subject = " Material Return Request :- " + Action

            End If



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

        mail.Subject = Subject
        mail.Body = body
        mail.IsBodyHtml = True
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
        Dim SmtpMail As New SmtpClient("exchange2k7")

        'SmtpMail.SmtpServer = "exchange2007";
        SmtpMail.Send(mail)
        'return mail;
    End Sub

    Private Sub EMail(ByVal SanctionNote As String)

        Try
            Dim sql As String
            Dim from As String, [to] As String, bcc As String, cc As String, subject As String, body As String




            'sql = "  SELECT  DISTINCT SanctionNoteID " & _
            '      "FROM    dbo.jct_ops_material_request  a " & _
            '      "INNER JOIN dbo.Jct_Ops_SanctionNote_HDR  b ON CONVERT(VARCHAR, a.RequestID) = b.SanctionNoteID " & _
            '      "INNER JOIN dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING  c ON CONVERT(VARCHAR, a.RequestID) = c.ID " & _
            '                                                      " AND b.PendingAt = c.USERLEVEL " & _
            '      "WHERE   b.STATUS = 'A' " & _
            '      "AND b.AuthFlag = 'P' " & _
            '      "AND c.EMPCODE = 'R-01111' and a.requestid=" + SanctionNote

            'Dim cmd As SqlCommand = New SqlCommand(sql, obj.Connection())
            'Dim dr As SqlDataReader = cmd.ExecuteReader()
            'If (dr.HasRows) Then
            '    While dr.Read()


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
            sb.AppendLine("RequestID for your request is : " + SanctionNote + " <br/><br/>")


            sb.AppendLine("Please reply this email with 'YES'  to authorise and  'NO' to cancel with 'REMARKS'.<br/> <br/>")


            sb.AppendLine("Details are Shown below : <br/><br/>")
            sb.AppendLine("<table class=gridtable>")
            sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th>Invoice Date</th> <th> Return Qty</th>  <th> Auth. Pending At</th><th> Freight Paid By</th> </tr>")

            sql = "JCT_OPS_SANCTION_PENDING_AT_MATERIAL_RETURN"
            Dim cmd3 As SqlCommand = New SqlCommand(sql, obj3.Connection())
            cmd3.CommandType = CommandType.StoredProcedure
            cmd3.Parameters.Add("@RequestID", SqlDbType.Int).Value = Convert.ToInt16(SanctionNote)
            Dim Dr3 As SqlDataReader = cmd3.ExecuteReader()
            If (Dr3.HasRows) Then
                While (Dr3.Read())

                    ViewState("Customer") = Dr3(2).ToString()

                    sb.AppendLine("<tr> <td> " & Dr3(0).ToString & " </td> <td> " & Dr3(1).ToString & "  </td>  <td> " & Dr3(2).ToString & "</td>  <td>" & Dr3(3).ToString & " </td>  <td>" & Dr3(4).ToString & " </td> <td>" & Dr3("invoice_date").ToString() & "</td>  <td>" & Dr3(5).ToString & "</td>  <td>ROHIT SERU</td><td>" & Dr3(7).ToString & "</td> </tr> ")


                End While

            End If
            Dr3.Close()
            obj3.ConClose()
            sb.AppendLine("</table>")


            sb.AppendLine("<br /><br/>")
            sql = "SELECT distinct DESCRIPTION,reason,FreightValue FROM dbo.jct_ops_material_request  WHERE RequestID=" + SanctionNote
            cmd3 = New SqlCommand(sql, obj3.Connection())
            Dr3 = cmd3.ExecuteReader()
            If (Dr3.HasRows) Then

                While (Dr3.Read())

                    sb.AppendLine("Detailed Description (Entered by Marketing Executive) : " + Dr3(0).ToString().ToUpper())
                    sb.AppendLine("<br /><br />")
                    sb.AppendLine("Reason : " + Dr3(1).ToString().ToUpper())
                    sb.AppendLine("<br /><br />")
                    sb.AppendLine("FreightValue : " + Dr3(2).ToString())
                    sb.AppendLine("<br /><br />")
                End While

            End If
            Dr3.Close()
            obj3.ConClose()

            sb.AppendLine("Authorisation History : ")
            sb.AppendLine("<table class=gridtable>")
            sb.AppendLine("<tr><th> UserLevel</th> <th> Authorised By</th> <th> Remarks</th> <th>Authorisation Date </th> </tr>")

            sql = "  SELECT USERLEVEL,b.empname AS AuthorisedBy,Remarks,AUTH_DATETIME AS  AuthorisationDate FROM dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING  a INNER JOIN dbo.JCT_EmpMast_Base b ON a.EMPCODE=b.empcode WHERE ID IN ('" + SanctionNote + "') order by userlevel asc"
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

            sql = "SELECT b.E_MailID FROM dbo.jct_ops_material_request  a INNER JOIN dbo.MISTEL b ON a.userid=b.empcode WHERE RequestID='" + SanctionNote + "' "
            If (objFun.CheckRecordExistInTransaction(sql)) Then
                cc = objFun.FetchValue(sql).ToString()
                '  cc = "jagdeep@jctltd.com"
            Else

                cc = "It.helpdesk@jctltd.com"

            End If



            [to] = ("rohits@jctltd.com")
            '[to] = "jatindutta@jctltd.com"

            sql = "Select empname from jct_empmast_base where empcode='" + Session("EmpCode") + "'"
            Dim EmpName As String = objFun.FetchValue(sql)
            sql = "Select e_mailid from mistel where empcode='" + Session("EmpCode") + "'"
            Dim E_MailID As String = objFun.FetchValue(sql)

            subject = " Material Return Request  :- " + ViewState("Customer") + " with ID - " + SanctionNote
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
            mail.CC.Add(E_MailID)
            mail.CC.Add("rbaksshi@jctltd.com")
            mail.CC.Add("ashish@jctltd.com")
            mail.CC.Add("manishk@jctltd.com")


            mail.CC.Add("william@jctltd.com")
 		mail.CC.Add("skj@jctltd.com")

            mail.Subject = subject
            mail.Body = body
            mail.IsBodyHtml = True
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            Dim SmtpMail As New SmtpClient("exchange2k7")
            SmtpMail.Send(mail)


            '    End While
            'End If
            'dr.Close()

            'obj.ConClose()

            body = ""


        Catch ex As Exception


            Dim Scrpt As String = "alert('Error while sending mail..!!');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)

        End Try


    End Sub


    Protected Sub dtlAttachment_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlAttachment.ItemCommand

        If e.CommandName = "Download" Then

            Dim filepath As String = Server.MapPath("~\Ops\Upload\" + e.CommandArgument.ToString())

            If (File.Exists(filepath) = False) Then

                Dim Scrpt As String = "alert('File Not Found. Please contact IT-HelpDesk @4212');"
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
            Else


                Dim strFileName As String = ""
                strFileName = e.CommandArgument
                'strFileName = strFileName.Replace(" ", "%20")
                'HttpContext.Current.Response.ContentType = "application/octet-stream"
                'HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" & strFileName) ' System.IO.Path.GetFileName(HttpContext.Current.Server.MapPath(filePath)))
                'HttpContext.Current.Response.Clear()
                'HttpContext.Current.Response.WriteFile(filepath)
                'HttpContext.Current.Response.End()
                'ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'DownloadFile.aspx?filepath='" + filepath + ",FileName=" + strFileName + ", null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top='+Mtop+', left='+Mleft+'' );", True)
                Response.Redirect("DownloadFile.aspx?filepath=" + filepath + "&FileName=" + strFileName)
                'Response.ClearContent()
                'Response.ContentType = "application/octet-stream"
                'Response.AddHeader("Content-Disposition", String.Format("attachment; filename = {0}", System.IO.Path.GetFileName(e.CommandArgument.ToString())))
                'Response.AppendHeader("Content-Disposition", "attachment; filename=" + e.CommandArgument.ToString() + "")
                'Response.TransmitFile(Server.MapPath("~\Ops\Upload\" + e.CommandArgument.ToString()))
                'Response.End()




            End If

        End If

    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        'If e.Row.RowType = DataControlRowType.DataRow Then

        '    GridView1.DataKeyNames.Equals("SanctionNoteID")
        '    Dim SanctionID As [String] = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SanctionNoteID"))

        '    Dim GridViewNested As GridView = DirectCast(e.Row.FindControl("nestedGridView"), GridView)
        '    GridViewNested.DataKeyNames.Equals("Description")
        '    qry = "Select Description from Jct_Ops_SanctionNote_HDR where sanctionNoteID ='" & SanctionID & "'"
        '    Dim cmd As New SqlCommand(qry, obj.Connection())
        '    Dim da As New SqlDataAdapter(cmd)
        '    Dim ds As New DataSet()
        '    da.Fill(ds)
        '    GridViewNested.DataSource = ds.Tables(0)
        '    GridViewNested.DataBind()

        '    Dim GridViewNested_MultipleID As GridView = DirectCast(e.Row.FindControl("nestedGridView_MultipleID"), GridView)
        '    GridViewNested_MultipleID.DataKeyNames.Equals("SanctionNoteID")
        '    qry = "SELECT COUNT(*) AS count FROM dbo.jct_ops_material_request WHERE RequestID='" & SanctionID & "'"
        '    Dim i As Int16 = objFun.FetchValue(qry)

        '    If i > 1 Then
        '        qry = " SELECT invoice_no AS Invoice,item_no AS Sort,customer AS Customer,b.empname AS SalesPerson,invoice_qty AS InvoiceQty,ret_qty AS ReturnQty,reason AS Reason FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person = REPLACE(b.empcode, '-', '')   WHERE RequestID='" & SanctionID & "' "
        '        cmd = New SqlCommand(qry, obj.Connection())
        '        da = New SqlDataAdapter(cmd)
        '        ds = New DataSet()
        '        da.Fill(ds)
        '        GridViewNested_MultipleID.DataSource = ds.Tables(0)
        '        GridViewNested_MultipleID.DataBind()
        '    Else
        '        GridViewNested_MultipleID.DataSource = Nothing
        '        GridViewNested_MultipleID.DataBind()
        '    End If
        'End If

        If e.Row.RowType = DataControlRowType.DataRow Then

            GridView1.DataKeyNames.Equals("SanctionNoteID")
            Dim SanctionID As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SanctionNoteID"))

            Dim GridViewNested As GridView = DirectCast(e.Row.FindControl("nestedGridView"), GridView)
            GridViewNested.DataKeyNames.Equals("Description")
            qry = "Select Description from Jct_Ops_SanctionNote_HDR where status='A' and AuthFlag='P' and  sanctionNoteID ='" & SanctionID & "'"
            Dim cmd As New SqlCommand(qry, obj.Connection())
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            GridViewNested.DataSource = ds.Tables(0)
            GridViewNested.DataBind()


            Dim GridViewNested_MultipleID As GridView = DirectCast(e.Row.FindControl("nestedGridView_MultipleID"), GridView)
            GridViewNested_MultipleID.DataKeyNames.Equals("SanctionNoteID")
            qry = "SELECT COUNT(*) AS count FROM dbo.jct_ops_material_request WHERE RequestID='" & SanctionID & "'"
            Dim i As Int16 = objFun.FetchValue(qry)

            If i > 1 Then
                Dim lbl As Label = DirectCast(e.Row.FindControl("lbl"), Label)
                lbl.Visible = True
                lbl.ToolTip = "More than one invoices are in this request number. Expand to view Details..!!"
                qry = " SELECT invoice_no AS Invoice,item_no AS Sort,customer AS Customer,b.empname AS SalesPerson,invoice_qty AS InvoiceQty,ret_qty AS ReturnQty,reason AS Reason FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person = REPLACE(b.empcode, '-', '')   WHERE RequestID='" & SanctionID & "' "
                cmd = New SqlCommand(qry, obj.Connection())
                da = New SqlDataAdapter(cmd)
                ds = New DataSet()
                da.Fill(ds)
                GridViewNested_MultipleID.DataSource = ds.Tables(0)
                GridViewNested_MultipleID.DataBind()
            Else
                GridViewNested_MultipleID.DataSource = Nothing
                GridViewNested_MultipleID.DataBind()
            End If


        End If
    End Sub

    Protected Sub GrdAuthHistory_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdAuthHistory.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            GridView1.DataKeyNames.Equals("SanctionID")
            Dim SanctionID As [String] = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SanctionID"))
            Dim UserLevel As [String] = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserLevel"))

            Dim GridViewNested As GridView = DirectCast(e.Row.FindControl("nestedRemarks"), GridView)
            GridViewNested.DataKeyNames.Equals("Remarks")
            qry = "SELECT ISNULL(Remarks,'No Remarks Given..!! or it may be pending for approval') as Remarks FROM dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE ID='" + SanctionID + "' AND USERLEVEL=" + UserLevel + "  and status is null"
            Dim cmd As New SqlCommand(qry, obj.Connection())
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            GridViewNested.DataSource = ds.Tables(0)

            GridViewNested.DataBind()
        End If

    End Sub

End Class

'Imports System
'Imports System.Data.SqlClient
'Imports System.Reflection
'Imports System.Net.Mail
'Imports System.IO
'Imports System.Data


''Imports System.Collections
''Imports System.ComponentModel

''Imports System.Drawing

'Imports System.Web
''Imports System.Web.Mail
'Imports System.Web.SessionState
'Imports System.Web.UI
'Imports System.Web.UI.WebControls
'Imports System.Web.UI.HtmlControls

'Partial Class OPS_AuthorizeSanction_Note
'    Inherits System.Web.UI.Page
'    Dim objFun As Functions = New Functions
'    Dim obj As Connection = New Connection
'    Dim qry As String
'    Dim dr As SqlDataReader
'    Dim cmd As SqlCommand = New SqlCommand
'    Dim con As SqlConnection = New SqlConnection
'    Dim Tran As SqlTransaction
'    Dim ObjSendMail As SendMail

'    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
'        If (Session("empcode").ToString = "") Then
'            Response.Redirect("~/login.aspx")
'        End If
'        If Not IsPostBack Then
'        End If
'        Dim AreaName As String = ""
'        If (String.IsNullOrEmpty(Request.QueryString("AreaName")) = False) Then

'            AreaName = Request.QueryString("AreaName")
'            GrdSanctionNoteDetail.DataSource = Nothing
'            GrdSanctionNoteDetail.DataBind()
'            'qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' and b.areaName='" & AreaName & "' and a.UserCode='" & Session("Empcode") & "'"
'            qry = "Jct_Ops_Pending_Authorization_Fetch '" & Session("Empcode") & "','" & AreaName & "'"
'            objFun.FillGrid(qry, GridView1)

'            ' remove query string
'            Dim isreadonly As PropertyInfo = _
'            GetType(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance Or BindingFlags.NonPublic)

'            ' make collection editable
'            isreadonly.SetValue(Me.Request.QueryString, False, Nothing)

'            ' remove
'            Me.Request.QueryString.Remove("AreaName")


'        End If





'        'If Session("empcode") = "A-00098" Or Session("empcode") = "P-03055" Then
'        '    Panel2.Visible = True
'        'Else
'        '    Panel2.Visible = False
'        'End If
'    End Sub

'    Protected Sub DataList1_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.ItemCommand
'        Try
'            Dim AreaName As String = ""
'            GrdSanctionNoteDetail.DataSource = Nothing
'            GrdSanctionNoteDetail.DataBind()
'            If (String.IsNullOrEmpty(Request.QueryString("AreaName")) = False) Then

'                AreaName = Request.QueryString("AreaName")

'                GrdSanctionNoteDetail.DataSource = Nothing
'                GrdSanctionNoteDetail.DataBind()

'                'qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' and b.areaName='" & AreaName & "'"
'                'Comented on 31-Dec-2012 qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c,Jct_Ops_SanctioNote_Area_Emp_Auth_Listing d WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' AND a.authFlag='P' AND a.PendingAt=d.UserLevel and b.areaName='" & AreaName & "' AND ( 1 = ( SELECT TOP 1 1 FROM    production..role_user_mapping WHERE   role = '100' AND uname = '" & Session("Empcode") & "') OR d.EmpCode = '" & Session("Empcode") & "') AND b.AreaCode = d.AreaCode "
'                qry = "Jct_Ops_Pending_Authorization_Fetch '" & Session("Empcode") & "','" & AreaName & "'"

'                objFun.FillGrid(qry, GridView1)
'                objFun.FillGrid(qry, GridView1)


'                GrdAuthHistory.DataSource = Nothing
'                GrdAuthHistory.DataBind()

'                Request.QueryString.Clear()
'            Else

'                If e.CommandName = "Select" Then
'                    AreaName = CType(e.Item.FindControl("cmdArea"), LinkButton).Text
'                    If AreaName <> "" And AreaName <> "Greigh Transfer" Then
'                        GridView1.DataSource = Nothing
'                        GridView1.DataBind()
'                        GridView1.SelectedIndex = -1
'                        GrdSanctionNoteDetail.DataSource = Nothing
'                        GrdSanctionNoteDetail.DataBind()
'                        'qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' and b.areaName='" & AreaName & "'"
'                        'Comented on 31-Dec-2012 qry = "SELECT a.SanctionNoteID,a.AreaCode,b.AreaName,c.empname RaisedBy,a.SUBJECT WithSubject,CONVERT(VARCHAR(10),CreatedDate,101) CreatedOn FROM dbo.Jct_Ops_SanctionNote_HDR a,dbo.Jct_Ops_SanctioNote_Area_Master b,JCT_EmpMast_Base c,Jct_Ops_SanctioNote_Area_Emp_Auth_Listing d WHERE a.AreaCode=b.AreaCode AND a.STATUS=b.STATUS AND a.STATUS='A' AND GETDATE() BETWEEN Eff_From AND Eff_To AND a.UserCode=c.empcode AND c.active='Y' AND c.Company_Code='JCT00LTD' AND a.authFlag='P' AND a.PendingAt=d.UserLevel and b.areaName='" & AreaName & "' AND ( 1 = ( SELECT TOP 1 1 FROM    production..role_user_mapping WHERE   role = '100' AND uname = '" & Session("Empcode") & "') OR d.EmpCode = '" & Session("Empcode") & "') AND b.AreaCode = d.AreaCode "
'                        qry = "Jct_Ops_Pending_Authorization_Fetch '" & Session("Empcode") & "','" & AreaName & "'"
'                        objFun.FillGrid(qry, GridView1)

'                    Else
'                        Response.Redirect("AuthorizeSanctionNote10.aspx")
'                    End If
'                End If

'            End If
'        Catch ex As Exception

'        End Try


'    End Sub


'    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
'        'Comented on 31-Dec-2012   qry = "SELECT b.ParmName,b.ParmDesc,a.Val as [Values] FROM dbo.Jct_Ops_SanctionNote_Dtl a,dbo.Jct_Ops_SanctionNote_Parameters b WHERE SanctionNoteID='" & Trim(GridView1.SelectedRow.Cells(1).Text) & "' AND b.STATUS='A' AND GETDATE() BETWEEN b.Eff_From AND b.Eff_To  AND a.ParamCode=b.ParamCode"
'        Try
'            qry = "Exec Jct_Ops_Pending_Authorization_Fetch_Detail '" & Trim(GridView1.SelectedRow.Cells(1).Text) & "','" & Trim(GridView1.SelectedRow.Cells(2).Text) & "'"
'            objFun.FillGrid(qry, GrdSanctionNoteDetail)
'            qry = "exec Jct_Ops_SanctionNote_Authrization_Detail '" & Trim(GridView1.SelectedRow.Cells(1).Text) & "'"
'            objFun.FillGrid(qry, GrdAuthHistory)
'        Catch ex As Exception
'            MsgBox("" & ex.ToString)

'        End Try

'        'If Trim(GridView1.SelectedRow.Cells(3).Text) = "Exception" Then
'        '    Panel1.Visible = True
'        'Else
'        '    Panel1.Visible = False
'        'End If
'    End Sub

'    Protected Sub CmdAuthorize_Click(sender As Object, e As System.EventArgs) Handles CmdAuthorize.Click

'        Try


'            Dim NextAuthLevel As String = "None"
'            Dim MaxAuthLevel As String = "None"
'            Dim CurrentUserLevel As String = ""
'            Dim AreaCode As String = ""
'            Dim SanctionNote As String = ""
'            Dim SalePersonCode As String = ""
'            Dim SalePersonEmail As String = "ashish@jctltd.com"
'            Dim Body As String = ""
'            Dim Body3 As String = ""
'            Dim RaisedBy As String, SendMailTo As String, Shade As String, Lineno As Int16 = 0
'            Dim Qty As Int32 = 0
'            Dim Reqd_Date As String = ""
'            Dim Area As String = ""
'            Dim UserName As String = ""
'            Dim Scrpt As String = ""

'            UserName = objFun.FetchValue("Select empname from jct_empmast_base where empcode='" & Session("Empcode") & "'")
'            RaisedBy = objFun.FetchValue("SELECT E_MailID FROM MISTEL WHERE empcode='" & Session("Empcode") & "'")
'            Dim FinalNotify As String = ""
'            SendMailTo = ""
'            Shade = ""
'            Lineno = 0
'            Try

'                With GridView1

'                    If .SelectedIndex > -1 Then
'                        If GridView1.SelectedRow.Cells(1).Text <> "" Or GridView1.Rows.Count >= 1 Then
'                            SanctionNote = Trim(.SelectedRow.Cells(1).Text)
'                            AreaCode = Trim(.SelectedRow.Cells(2).Text)


'                            If AreaCode = 1014 Then

'                                Try
'                                    ViewState("ID") = SanctionNote
'                                    qry = "JCT_OPS_SANCTION_NOTE_MATERIAL_RETURN_REASONS_AUTHORIZATION"
'                                    Dim cmd As SqlCommand = New SqlCommand(qry, obj.Connection())
'                                    cmd.CommandType = Data.CommandType.StoredProcedure
'                                    cmd.Parameters.Add("@AreaCode", SqlDbType.Int).Value = 1014
'                                    cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 10).Value = Session("EmpCode")
'                                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = SanctionNote
'                                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 100).Value = txtRemarks.Text
'                                    cmd.ExecuteNonQuery()
'                                    Scrpt = "alert('Record Authorized Successfully..!!');"
'                                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", Scrpt, True)
'                                    SendMail()
'                                Catch ex As Exception
'                                    Scrpt = "alert('Some Error Occured..!!');"
'                                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", Scrpt, True)
'                                    Exit Sub
'                                End Try
'                                Exit Sub
'                            End If

'                            Tran = obj.Connection.BeginTransaction
'                            con = obj.Connection
'                            If AreaCode = 9999 Then
'                                Area = Trim(.SelectedRow.Cells(5).Text)
'                                Area = Area.Substring(Area.IndexOf("~ ") + 2, Area.IndexOf(" -") - Area.IndexOf("~ ") - 2)

'                                'OrderNo = GrdSanctionNoteDetail.Rows(0).Cells(1).Text
'                                'Sort = GrdSanctionNoteDetail.Rows(0).Cells(2).Text
'                                Shade = GrdSanctionNoteDetail.Rows(0).Cells(3).Text
'                                Lineno = GrdSanctionNoteDetail.Rows(0).Cells(4).Text
'                                Qty = GrdSanctionNoteDetail.Rows(0).Cells(5).Text
'                                Reqd_Date = GrdSanctionNoteDetail.Rows(0).Cells(5).Text
'                            End If
'                            If AreaCode <> 9999 Then


'                                qry = "SELECT STUFF((SELECT ',' + s.E_MailID FROM (SELECT 1 ID,E_MailID from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,MISTEL c  WHERE id='" & SanctionNote & "' AND a.EMPCODE=c.empcode  UNION SELECT  1 ID,E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,MISTEL c  WHERE SanctionID='" & SanctionNote & "' AND a.NotifyUser=c.empcode ) s WHERE s.id = t.id FOR XML PATH('')),1,1,'') AS CSV FROM (SELECT 1 ID,E_MailID FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,MISTEL c  WHERE id='" & SanctionNote & "' AND a.EMPCODE=c.empcode  UNION SELECT  1 ID,E_MailID FROM dbo.Jct_Ops_SanctionNote_Notify a,MISTEL c  WHERE SanctionID='" & SanctionNote & "' AND a.NotifyUser=c.empcode ) AS t GROUP BY t.id"
'                                FinalNotify = objFun.FetchValue(qry, con, Tran)
'                                qry = "Select isnull(convert(varchar,UserLevel),'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE AreaCode='" & AreaCode & "' and id='" & SanctionNote & "' and empcode='" & Session("Empcode") & "'"
'                                CurrentUserLevel = objFun.FetchValue(qry, con, Tran)

'                                If CurrentUserLevel Is Nothing Then CurrentUserLevel = "None"


'                                If CurrentUserLevel <> "None" Then
'                                    qry = "Select top 1 isnull(convert(varchar,UserLevel),'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE AreaCode='" & AreaCode & "'  and id='" & SanctionNote & "' and empcode<>'" & Session("Empcode") & "' and userlevel>'" & Val(CurrentUserLevel) & "' order by userlevel"
'                                    NextAuthLevel = objFun.FetchValue(qry, con, Tran)
'                                Else
'                                    objFun.Alert("Unable to Your Authoirze...!!!")

'                                    Tran.Rollback()
'                                    Exit Sub
'                                End If

'                                qry = "Select top 1 isnull(E_MailID,'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a,mistel b WHERE AreaCode='" & AreaCode & "'  and id='" & SanctionNote & "' and a.empcode<>'" & Session("Empcode") & "' and userlevel>'" & Val(CurrentUserLevel) & "' and a.empcode=b.empcode order by userlevel"
'                                SendMailTo = objFun.FetchValue(qry, obj.Connection, Tran)


'                                qry = "Select top 1 isnull(convert(varchar,max(UserLevel)),'None') from JCT_OPS_SanctionNote_AUTHORIZATION_LISTING WHERE AreaCode='" & AreaCode & "' and  id='" & SanctionNote & "'  AND STATUS is NULL"
'                                MaxAuthLevel = objFun.FetchValue(qry, con, Tran)


'                                'Added on  Jan -8 to include  P.G Mohan authorization 

'                                'If CurrentUserLevel = MaxAuthLevel And "a" = "p-03055" Then
'                                '    qry = "INSERT INTO Jct_Ops_SanctionNote_FinalAuthrization_Details(SanctionNoteID ,UserCode ,ParmCode ,ParmName ,Val ,Created_Date ,STATUS ,CreatedOnHost) values('" & SanctionNote & "','" & Session("Empcode") & "','','" & lblTransport.Text & "','" & ddlFinalMode.SelectedItem.Value & "',getdate(),'A','" & Request.ServerVariables("REMOTE_ADDR") & "')"
'                                '    objFun.InsertRecord(qry, Tran, obj.Connection)
'                                '    qry = "INSERT INTO Jct_Ops_SanctionNote_FinalAuthrization_Details(SanctionNoteID ,UserCode ,ParmCode ,ParmName ,Val ,Created_Date ,STATUS ,CreatedOnHost) values('" & SanctionNote & "','" & Session("Empcode") & "','','" & lblFreightVal.Text & "','" & txtFinalFreightVal.Text & "',getdate(),'A','" & Request.ServerVariables("REMOTE_ADDR") & "')"
'                                '    objFun.InsertRecord(qry, Tran, obj.Connection)
'                                'End If Removed on 30-jan-2013

'                                If NextAuthLevel Is Nothing And MaxAuthLevel Is Nothing Then
'                                    NextAuthLevel = "None"
'                                    objFun.Alert("Unable to Your Peform Action...!!!")
'                                    Tran.Rollback()
'                                    Exit Sub

'                                ElseIf NextAuthLevel <> "None" And CurrentUserLevel <> MaxAuthLevel And Left(ddlAction.SelectedItem.Text, 1) = "A" Then

'                                    qry = "Update Jct_Ops_SanctionNote_HDR set AuthFlag='P',PendingAt='" & NextAuthLevel & "',LastAuthBy='" & CurrentUserLevel & "',LastAuthOn=getdate() where SanctionNoteID='" & SanctionNote & "' and status='A' and AuthFlag='P'"
'                                    objFun.UpdateRecord(qry, Tran, con)

'                                    'If Left(ddlAction.SelectedItem.Text, 1) = "A" Then
'                                    qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set AUTH_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "'"
'                                    'Else
'                                    '    qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set CANCEL_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "'"
'                                    'End If
'                                    objFun.UpdateRecord(qry, Tran, con)

'                                    Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & SanctionNote & " Is " & ddlAction.SelectedItem.Text & " </h3></b> By <b> " & UserName & " and is now Pending for your Approval" ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"

'                                Else ' Else part will be executed in case when either maxauthlevel is achevied or some one wants to cancel any sanctionnote
'                                    qry = "Update Jct_Ops_SanctionNote_HDR set AuthFlag='" & Left(ddlAction.SelectedItem.Text, 1) & "',PendingAt='',LastAuthBy='" & CurrentUserLevel & "',LastAuthOn=getdate() where SanctionNoteID='" & SanctionNote & "' and status='A'  and AuthFlag='P'"
'                                    objFun.UpdateRecord(qry, Tran, con)

'                                    'If Left(ddlAction.SelectedItem.Text, 1) = "A" Then
'                                    '    qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL ,AUTH_DATETIME,CREATED_ONHOST ,Remarks) values('" & SanctionNote & "','" & Session("Empcode") & "','" & AreaCode & "','" & Session("Empcode") & "','" & CurrentUserLevel & "',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "')"
'                                    'Else
'                                    '    qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL ,CANCEL_DATETIME,CREATED_ONHOST ,Remarks) values('" & SanctionNote & "','" & Session("Empcode") & "','" & AreaCode & "','" & Session("Empcode") & "','" & CurrentUserLevel & "',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "')"
'                                    'End If
'                                    'If Left(ddlAction.SelectedItem.Text, 1) = "A" Then
'                                    '    qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set AUTH_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "'"
'                                    'Else
'                                    qry = "Update JCT_OPS_SanctionNote_AUTHORIZATION_LISTING Set CANCEL_DATETIME=getdate(),CREATED_ONHOST='" & Request.ServerVariables("REMOTE_ADDR") & "',remarks='" & txtRemarks.Text & "' WHERE ID='" & SanctionNote & "' AND EMPCODE='" & Session("Empcode") & "' AND AREACODE='" & AreaCode & "' AND USERLEVEL= '" & CurrentUserLevel & "'"
'                                    'End If
'                                    objFun.InsertRecord(qry, Tran, con)

'                                    Body = "<p>Hello.....,</p><p><h3>You are receiving this email on the behalf of Automated E-Mail Alert System.<b>This SanctionNote No. " & SanctionNote & " Is " & ddlAction.SelectedItem.Text & " </h3></b> By <b> " & UserName & " and is now Pending for your Approval" ':-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)")) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
'                                End If
'                            Else '-----Will be executed when Exceptions are ment to be authorised or Unauthorized
'                                qry = "update Jct_Ops_Process_Plan_Exception set PendingAt='',LastAuthBy='" & Session("Empcode") & "',LastAuthOn=getdate(),AuthFlag='" & Left(ddlAction.SelectedItem.Text, 1) & "',IntialAuthRemarks='" & txtRemarks.Text & "'  WHERE STATUS='A' AND LastAuthBy IS NULL and ExceptionID=" & SanctionNote & ""
'                                objFun.InsertRecord(qry, Tran, con)
'                                ''Body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b> " '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Line & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>Finishing</P> <b>Meters :-" & DyngQty & "</b> was Planned to be <b>Dyed on :-</b> '" & ReqDyngDate & "' <br><hr><br><br><P>Finishing</P> Meter Planned for Finishing are :-</b> '" & FinsihQty & "' <b>On Date </b> '" & ReqFinishDate & "'  <h3>This Order Has been Removed from Dyeing and Finish (Processing) Plan by '" & Removedby & "' </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
'                                Body = "<p>Hello.....,</p>This Order has been approved for re-scheduling in " & Area & " is <B>Pending At Planning's Approval </b><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)", obj.Connection, Tran)) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3>  <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
'                            End If


'                            Tran.Commit()
'                            Scrpt = "alert('SanctionNote ' + '" + ddlAction.SelectedItem.Text + "'+'ed...!!!');"
'                            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
'                            objFun.Alert("SanctionNote " & ddlAction.SelectedItem.Text & "ed...!!!")

'                            If AreaCode = 9999 Then
'                                ' objFun.SendMailOPS(Body, "", SalePersonEmail, Session("Empcode"), "ashish@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,manishk@jctltd.com", "Your orderNO :-""  SortNo :-  ""' Shade :-  " & Shade & " was Reequested be Re-Planned in " & Area & " section and the request was generated by  " & UserName)
'                            Else ' Else part executed for all sanction note other than Exceptions

'                                Dim Body1 As String = ""
'                                Dim Val1 As String = ""
'                                Dim ParmName As String = ""
'                                For i = 0 To GrdSanctionNoteDetail.Rows.Count - 1
'                                    ParmName = GrdSanctionNoteDetail.Rows(i).Cells(0).Text
'                                    Val1 = GrdSanctionNoteDetail.Rows(i).Cells(1).Text
'                                    Body1 = Body1 & "<p> <b>" & ParmName & " :-</b> " & Val1 & " </p> "
'                                Next
'                                Body3 = " <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"

'                                SendMail(Body, Body1, Body3, RaisedBy, SendMailTo, "ashish@jctltd.com,manishk@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,manishk@jctltd.com", "This SanctionNote :-" & SanctionNote & "  has been " & ddlAction.SelectedItem.Text & "", SanctionNote, CurrentUserLevel, MaxAuthLevel, FinalNotify, ddlAction.SelectedItem.Text)
'                            End If
'                            RefreshLists()

'                        Else
'                            Scrpt = "alert('Please Select any SanctionNote from the List and then Proceed !!!');"
'                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", Scrpt, True)
'                            objFun.Alert("Please Select any SanctionNote from the List and then Proceed !!!")
'                            Exit Sub
'                        End If
'                    Else
'                        Scrpt = "alert('Please Select any SanctionNote from the List and then Proceed !!!');"
'                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", Scrpt, True)
'                        objFun.Alert("Please Select any SanctionNote from the List and then Proceed !!!")
'                        Exit Sub
'                    End If
'                End With
'            Catch ex As Exception
'                Scrpt = "alert('Unable to Complete Transaction...');"
'                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", Scrpt, True)
'                objFun.Alert("Unable to Complete Transaction...")
'                ' ObjSendMail.SendMail("Ashish@jctltd.com", "noreply@jctltd.com", "Error in Authorizing SanctionNote !!!", "The sanction note no " & SanctionNote & "was under authorization process but some error was genrated.....<br> " & ex.ToString)
'                Tran.Rollback()
'            End Try

'        Catch ex As Exception

'            Dim Scrpt As String = "alert('" + ex.Message + "');"
'            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)

'        End Try

'    End Sub

'    Private Sub RefreshLists()
'        DataList1.DataSource = Nothing
'        DataBind()

'        DataList1.DataSourceID = "SqlDataSource2"
'        DataBind()

'        GridView1.DataSource = Nothing
'        GridView1.DataBind()

'        GrdSanctionNoteDetail.DataSource = Nothing
'        GrdSanctionNoteDetail.DataBind()
'    End Sub




'    'Protected Sub DataList1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DataList1.SelectedIndexChanged
'    '    GrdSanctionNoteDetail.DataSource = Nothing
'    '    GrdSanctionNoteDetail.DataBind()
'    'End Sub

'    Private Sub SendMail(Body__1 As String, Body2 As String, body3 As String, RaisedBy_Email As String, [to] As String, cc As String, bcc As String, Subject As String, SanctionNote As String, CurrentLevel As Int16, MaxLevel As Int16, NotifyAllList As String, Action As String)
'        Try
'            Dim from As String
'            from = "noreply@jctltd.com"
'            Dim query As String = ""
'            Dim SenderEmail As String = ""

'            If RaisedBy_Email Is Nothing Then
'                RaisedBy_Email = ""
'            End If

'            'query = "SELECT isnull(E_MailID,'') FROM dbo.MISTEL WHERE empcode='" & [to] & "' "
'            SenderEmail = [to] 'objFun.FetchValue(query)
'            If SenderEmail Is Nothing Then SenderEmail = ""

'            If SenderEmail <> "" Then

'                'Email Address of Receiver
'                [to] = SenderEmail & "," & RaisedBy_Email ' "neeraj@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,rahuljindal@jctltd.com,karunarora@jctltd.com,lakhbir@jctltd.com,ramanjot@jctltd.com,WeavingGroup@jctltd.com"
'                'Else
'                '    'Email Address of Receiver
'                '    [to] = "neeraj@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,rahuljindal@jctltd.com,karunarora@jctltd.com,lakhbir@jctltd.com,ramanjot@jctltd.com,WeavingGroup@jctltd.com," & Convert.ToString(SalesPerson_Email)
'            Else
'                [to] = RaisedBy_Email

'            End If
'            If CurrentLevel = MaxLevel And CurrentLevel > 0 And Action = "Authorize" Then
'                [to] = NotifyAllList
'            End If

'            'bcc = "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com"
'            'cc = "arwinder@jctltd.com"
'            '    subject = "Authorized Shortfall Request - " & Convert.ToString(OrderNo)

'            'StringBuilder sb = new StringBuilder();
'            'sb.Append("Hi,<br/>");
'            'sb.Append("This is a test email. We are testing out email client. Please don't mind.<br/>");
'            'sb.Append("We are sorry for this unexpected mail to your mail box.<br/>");
'            'sb.Append("<br/>");
'            'sb.Append("Thanking you<br/>");
'            'sb.Append("IT");

'            'body__2 = Body__1 

'            Dim mail As New MailMessage()
'            mail.From = New MailAddress(from)
'            If [to].Contains(",") Then
'                Dim tos As String() = [to].Split(","c)
'                For i As Integer = 0 To tos.Length - 1
'                    mail.[To].Add(New MailAddress(tos(i)))
'                Next
'            Else
'                mail.[To].Add(New MailAddress([to]))
'            End If

'            If Not String.IsNullOrEmpty(bcc) Then
'                If bcc.Contains(",") Then
'                    Dim bccs As String() = bcc.Split(","c)
'                    For i As Integer = 0 To bccs.Length - 1
'                        mail.Bcc.Add(New MailAddress(bccs(i)))
'                    Next
'                Else
'                    mail.Bcc.Add(New MailAddress(bcc))
'                End If
'            End If
'            If Not String.IsNullOrEmpty(cc) Then
'                If cc.Contains(",") Then
'                    Dim ccs As String() = cc.Split(","c)
'                    For i As Integer = 0 To ccs.Length - 1
'                        mail.CC.Add(New MailAddress(ccs(i)))
'                    Next
'                    'Else
'                    '    mail.CC.Add(New MailAddress(bcc))
'                End If
'                mail.CC.Add(New MailAddress(cc))
'            End If

'            mail.Subject = Subject
'            mail.Body = Body__1 & " " & Body2 & " " & body3
'            mail.IsBodyHtml = True
'            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
'            '       MailAttachment attach = new MailAttachment(Server.MapPath(strFileName));
'            '/* Attach the newly created email attachment */      
'            'mailMessage.Attachments.Add(attach);
'            If CurrentLevel = MaxLevel And CurrentLevel > 0 And Action = "Authorize" Then
'                qry = "SELECT ImgName FROM Jct_Ops_SanctionNote_Attachments WHERE STATUS='A' AND SanctionNoteID='" & SanctionNote & "'"
'                cmd = New SqlCommand(qry, obj.Connection)
'                dr = cmd.ExecuteReader
'                If dr.HasRows = True Then
'                    While dr.Read
'                        Dim Atchment As Attachment = New Attachment(Server.MapPath("~\OPS\Upload\") & dr.Item(0))
'                        mail.Attachments.Add(Atchment)
'                    End While
'                End If
'                dr.Close()

'            End If






'            Dim SmtpMail As New SmtpClient("exchange2007")


'            SmtpMail.Send(mail)
'        Catch ex As Exception
'            Dim Scrpt As String = "alert('" + ex.Message + "');"
'            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
'        End Try
'    End Sub






'    'Private Sub SendMailNew(Body__1 As String, Body2 As String, body3 As String, RaisedBy_Email As String, [to] As String, cc As String, bcc As String, Subject As String, SanctionNote As String)

'    '    Dim from As String
'    '    from = "noreply@jctltd.com"
'    '    Dim query As String = ""
'    '    Dim SenderEmail As String = ""

'    '    If RaisedBy_Email Is Nothing Then
'    '        RaisedBy_Email = ""
'    '    End If

'    '    'query = "SELECT isnull(E_MailID,'') FROM dbo.MISTEL WHERE empcode='" & [to] & "' "
'    '    SenderEmail = [to] 'objFun.FetchValue(query)
'    '    If SenderEmail Is Nothing Then SenderEmail = ""

'    '    If SenderEmail <> "" Then

'    '        'Email Address of Receiver
'    '        [to] = SenderEmail & "," & RaisedBy_Email ' "neeraj@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,rahuljindal@jctltd.com,karunarora@jctltd.com,lakhbir@jctltd.com,ramanjot@jctltd.com,WeavingGroup@jctltd.com"
'    '        'Else
'    '        '    'Email Address of Receiver
'    '        '    [to] = "neeraj@jctltd.com,karanjitsaini@jctltd.com,rashpal@jctltd.com,rahuljindal@jctltd.com,karunarora@jctltd.com,lakhbir@jctltd.com,ramanjot@jctltd.com,WeavingGroup@jctltd.com," & Convert.ToString(SalesPerson_Email)
'    '    Else
'    '        [to] = RaisedBy_Email
'    '    End If


'    '    'bcc = "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com"
'    '    'cc = "arwinder@jctltd.com"
'    '    '    subject = "Authorized Shortfall Request - " & Convert.ToString(OrderNo)

'    '    'StringBuilder sb = new StringBuilder();
'    '    'sb.Append("Hi,<br/>");
'    '    'sb.Append("This is a test email. We are testing out email client. Please don't mind.<br/>");
'    '    'sb.Append("We are sorry for this unexpected mail to your mail box.<br/>");
'    '    'sb.Append("<br/>");
'    '    'sb.Append("Thanking you<br/>");
'    '    'sb.Append("IT");

'    '    'body__2 = Body__1 

'    '    Dim mail As New MailMessage()
'    '    mail.From = New MailAddress(from)
'    '    If [to].Contains(",") Then
'    '        Dim tos As String() = [to].Split(","c)
'    '        For i As Integer = 0 To tos.Length - 1
'    '            mail.[To].Add(New MailAddress(tos(i)))
'    '        Next
'    '    Else
'    '        mail.[To].Add(New MailAddress([to]))
'    '    End If

'    '    If Not String.IsNullOrEmpty(bcc) Then
'    '        If bcc.Contains(",") Then
'    '            Dim bccs As String() = bcc.Split(","c)
'    '            For i As Integer = 0 To bccs.Length - 1
'    '                mail.Bcc.Add(New MailAddress(bccs(i)))
'    '            Next
'    '        Else
'    '            mail.Bcc.Add(New MailAddress(bcc))
'    '        End If
'    '    End If
'    '    If Not String.IsNullOrEmpty(cc) Then
'    '        If cc.Contains(",") Then
'    '            Dim ccs As String() = cc.Split(","c)
'    '            For i As Integer = 0 To ccs.Length - 1
'    '                mail.CC.Add(New MailAddress(ccs(i)))
'    '            Next
'    '            'Else
'    '            '    mail.CC.Add(New MailAddress(bcc))
'    '        End If
'    '        mail.CC.Add(New MailAddress(cc))
'    '    End If

'    '    mail.Subject = Subject
'    '    mail.Body = Body__1 & " " & Body2 & " " & body3
'    '    mail.IsBodyHtml = True
'    '    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
'    '    '       MailAttachment attach = new MailAttachment(Server.MapPath(strFileName));
'    '    '/* Attach the newly created email attachment */      
'    '    'mailMessage.Attachments.Add(attach);
'    '    qry = "SELECT ImgName FROM Jct_Ops_SanctionNote_Attachments WHERE STATUS='A' AND SanctionNoteID='" & SanctionNote & "'"
'    '    cmd = New SqlCommand(qry, obj.Connection)
'    '    dr = cmd.ExecuteReader
'    '    If dr.HasRows = True Then
'    '        While dr.Read
'    '            Dim Atchment As Attachment = New Attachment(Server.MapPath("~\OPS\Upload\") & dr.Item(0))
'    '            mail.Attachments.Add(Atchment)
'    '        End While
'    '    End If
'    '    dr.Close()






'    '    Dim SmtpMail As New SmtpClient("exchange2007")


'    '    SmtpMail.Send(mail)

'    'End Sub


'    Protected Sub CmdCancel_Click(sender As Object, e As System.EventArgs) Handles CmdCancel.Click
'        RefreshLists()
'        'Dim NextAuthLevel As String = "None"
'        'Dim MaxAuthLevel As String = "None"
'        'Dim CurrentUserLevel As String = ""
'        'Dim AreaCode As String = ""
'        'Dim SanctionNote As String = ""
'        'Dim SalePersonCode As String = ""
'        'Dim SalePersonEmail As String = "ashish@jctltd.com"
'        'Dim Body As String = ""
'        'Dim OrderNo As String, Sort As String, Shade As String, Lineno As Int16 = 0
'        'Dim Qty As Int32 = 0
'        'Dim Reqd_Date As String = ""
'        'Dim Area As String = ""
'        'Dim UserName As String = ""
'        'UserName = objFun.FetchValue("Select empname from jct_empmast_base where empcode='" & Session("Empcode") & "'")
'        'OrderNo = ""
'        'Sort = ""
'        'Shade = ""
'        'Lineno = 0
'        'Try

'        '    With GridView1

'        '        If .SelectedIndex > -1 Then
'        '            If GridView1.SelectedRow.Cells(1).Text <> "" Or GridView1.Rows.Count >= 1 Then
'        '                SanctionNote = Trim(.SelectedRow.Cells(1).Text)
'        '                AreaCode = Trim(.SelectedRow.Cells(2).Text)
'        '                Tran = obj.Connection.BeginTransaction
'        '                con = obj.Connection
'        '                If AreaCode = 9999 Then
'        '                    Area = Trim(.SelectedRow.Cells(5).Text)
'        '                    Area = Area.Substring(Area.IndexOf("~ ") + 2, Area.IndexOf(" -") - Area.IndexOf("~ ") - 2)
'        '                End If
'        '                OrderNo = GrdSanctionNoteDetail.Rows(0).Cells(1).Text
'        '                'Sort = GrdSanctionNoteDetail.Rows(0).Cells(2).Text
'        '                'Shade = GrdSanctionNoteDetail.Rows(0).Cells(3).Text
'        '                'Lineno = GrdSanctionNoteDetail.Rows(0).Cells(4).Text
'        '                'Qty = GrdSanctionNoteDetail.Rows(0).Cells(5).Text
'        '                Reqd_Date = GrdSanctionNoteDetail.Rows(0).Cells(5).Text

'        '                If AreaCode <> 9999 Then
'        '                    qry = "Select isnull(convert(varchar,UserLevel),'None') from Jct_Ops_SanctioNote_Area_Emp_Auth_Listing WHERE AreaCode='" & AreaCode & "' and  GETDATE() BETWEEN Eff_From AND Eff_To and empcode='" & Session("Empcode") & "'"
'        '                    CurrentUserLevel = objFun.FetchValue(qry, con, Tran)

'        '                    If CurrentUserLevel Is Nothing Then CurrentUserLevel = "None"

'        '                    If CurrentUserLevel <> "None" Then
'        '                        qry = "Select top 1 isnull(convert(varchar,UserLevel),'None') from Jct_Ops_SanctioNote_Area_Emp_Auth_Listing WHERE AreaCode='" & AreaCode & "' and GETDATE() BETWEEN Eff_From AND Eff_To and empcode<>'" & Session("Empcode") & "' and userlevel>'" & Val(CurrentUserLevel) & "' order by userlevel"
'        '                        NextAuthLevel = objFun.FetchValue(qry, con, Tran)
'        '                    Else
'        '                        objFun.Alert("Unable to Your Authoirze...!!!")

'        '                        Tran.Rollback()
'        '                        Exit Sub
'        '                    End If

'        '                    qry = "Select top 1 isnull(convert(varchar,max(UserLevel)),'None') from Jct_Ops_SanctioNote_Area_Emp_Auth_Listing WHERE AreaCode='" & AreaCode & "' and  GETDATE() BETWEEN Eff_From AND Eff_To AND STATUS='a'"
'        '                    MaxAuthLevel = objFun.FetchValue(qry, con, Tran)

'        '                    ''Added on  Jan -8 to include  P.G Mohan authorization 
'        '                    'If CurrentUserLevel = MaxAuthLevel And LCase(Session("Empcode").ToString.ToLower) = "p-03055" Then
'        '                    '    qry = "INSERT INTO Jct_Ops_SanctionNote_FinalAuthrization_Details(SanctionNoteID ,UserCode ,ParmCode ,ParmName ,Val ,Created_Date ,STATUS ,CreatedOnHost) values('" & SanctionNote & "','" & Session("Empcode") & "','','" & lblTransport.Text & "','" & ddlFinalMode.SelectedItem.Value & "',getdate(),'A','" & Request.ServerVariables("REMOTE_ADDR") & "')"
'        '                    '    objFun.InsertRecord(qry, Tran, obj.Connection)
'        '                    '    qry = "INSERT INTO Jct_Ops_SanctionNote_FinalAuthrization_Details(SanctionNoteID ,UserCode ,ParmCode ,ParmName ,Val ,Created_Date ,STATUS ,CreatedOnHost) values('" & SanctionNote & "','" & Session("Empcode") & "','','" & lblFreightVal.Text & "','" & txtFinalFreightVal.Text & "',getdate(),'A','" & Request.ServerVariables("REMOTE_ADDR") & "')"
'        '                    '    objFun.InsertRecord(qry, Tran, obj.Connection)
'        '                    'End If

'        '                    If NextAuthLevel Is Nothing And MaxAuthLevel Is Nothing Then
'        '                        NextAuthLevel = "None"
'        '                        objFun.Alert("Unable to Your Authoirze...!!!")
'        '                        Tran.Rollback()
'        '                        Exit Sub

'        '                    Else
'        '                        qry = "Update Jct_Ops_SanctionNote_HDR set AuthFlag='" & Left(ddlAction.SelectedItem.Text, 1) & "',PendingAt='',LastAuthBy='" & CurrentUserLevel & "',LastAuthOn=getdate() where SanctionNoteID='" & SanctionNote & "' and status='A'  and AuthFlag='P'"
'        '                        objFun.UpdateRecord(qry, Tran, con)
'        '                        qry = "Insert into JCT_OPS_SanctionNote_AUTHORIZATION_LISTING(ID ,USERCODE ,AREACODE ,EMPCODE ,USERLEVEL ,CANCEL_DATETIME,CREATED_ONHOST ,Remarks) values('" & SanctionNote & "','" & Session("Empcode") & "','" & AreaCode & "','" & Session("Empcode") & "','" & CurrentUserLevel & "',getdate(),'" & Request.ServerVariables("REMOTE_ADDR") & "','" & txtRemarks.Text & "')"
'        '                        objFun.InsertRecord(qry, Tran, con)
'        '                        Body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b> " '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Line & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>Finishing</P> <b>Meters :-" & DyngQty & "</b> was Planned to be <b>Dyed on :-</b> '" & ReqDyngDate & "' <br><hr><br><br><P>Finishing</P> Meter Planned for Finishing are :-</b> '" & FinsihQty & "' <b>On Date </b> '" & ReqFinishDate & "'  <h3>This Order Has been Removed from Dyeing and Finish (Processing) Plan by '" & Removedby & "' </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
'        '                    End If
'        '                Else '-----Will be executed when Exceptions are ment to be authorised or Unauthorized
'        '                    qry = "update Jct_Ops_Process_Plan_Exception set PendingAt='',LastAuthBy='" & Session("Empcode") & "',LastAuthOn=getdate(),AuthFlag='" & Left(ddlAction.SelectedItem.Text, 1) & "',IntialAuthRemarks='" & txtRemarks.Text & "'  WHERE STATUS='A' AND LastAuthBy IS NULL and ExceptionID=" & SanctionNote & ""
'        '                    objFun.InsertRecord(qry, Tran, con)
'        '                    ''Body = "<p>Hello.....,</p><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b> " '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Line & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>Finishing</P> <b>Meters :-" & DyngQty & "</b> was Planned to be <b>Dyed on :-</b> '" & ReqDyngDate & "' <br><hr><br><br><P>Finishing</P> Meter Planned for Finishing are :-</b> '" & FinsihQty & "' <b>On Date </b> '" & ReqFinishDate & "'  <h3>This Order Has been Removed from Dyeing and Finish (Processing) Plan by '" & Removedby & "' </h3> <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
'        '                    Body = "<p>Hello.....,</p>This Order has been approved for re-scheduling in " & Area & " is <B>Pending At Planning's Approval </b><p>You are receiving this email on the behalf of Automated E-Mail Alert System. Your <br><b>orderNO :-</b>  '""'</br><br><b>SortNo :-</b>"" <br><b>LineNo :-</b>'" & Lineno & "' <br><b>Shade :-</b> '" & Shade & "' <br><br><P>" & Area & "</P> <b>Meters :-" & Qty & "</b> was Planned to be <b>Area on :-</b> '" & Reqd_Date & "' <br><hr><br><br> This request was :-</b> '" & ddlAction.SelectedItem.Text & "' <b>On Date </b> " & (objFun.FetchValue("Select convert(varchar(10),getdate(),101)", obj.Connection, Tran)) & "  <h3>This Order Has been " & ddlAction.SelectedItem.Text & "ed  by " & UserName & "  </h3>  <p>This mail is a system generated mail and sent to you just for your information.Please do not reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
'        '                End If


'        '                'qry = "SELECT isnull(MAX(USERLEVEL)+1,999) FROM JCT_OPS_SanctionNote_AUTHORIZATION_LISTING  WHERE id='" & SanctionNote & "' AND AREACODE='" & AreaCode & "' AND STATUS IS null"
'        '                'CurrentUserLevel = objFun.FetchValue(qry, con, Tran)
'        '                If AreaCode = 9999 Then
'        '                    objFun.SendMailOPS(Body, OrderNo, SalePersonEmail, Session("Empcode"), "ashish@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,manishk@jctltd.com", "Your orderNO :-""  SortNo :-  ""' Shade :-  " & Shade & " was Reequested be Re-Planned in " & Area & " section and the request was generated by  " & UserName)
'        '                Else
'        '                    'objFun.SendMailOPS(Body, OrderNo, SalePersonEmail, Session("Empcode"), "rahuljindal@jctltd.com,rashpal@jctltd.com,karunarora@jctltd.com,khushwinder@jctltd.com,neeraj@jctltd.com,sobti@jctltd.com", "Ashish@jctltd.com,harendra@jctltd.com,rbaksshi@jctltd.com,manishk@jctltd.com", "Your orderNO :-""  SortNo :-  " & Item & "' Shade :-  " & Shade & " was Removed from  Dyeing & Finishing Plan")
'        '                End If
'        '                Tran.Commit()
'        '                RefreshLists()
'        '                objFun.Alert("SanctionNote Authorized...!!!")

'        '            Else
'        '                objFun.Alert("Please Select any SanctionNote from the List and then Proceed !!!")
'        '                Exit Sub
'        '            End If
'        '        Else
'        '            objFun.Alert("Please Select any SanctionNote from the List and then Proceed !!!")
'        '            Exit Sub
'        '        End If
'        '    End With
'        'Catch ex As Exception
'        '    objFun.Alert("Unable to Complete Transaction...")
'        '    ' ObjSendMail.SendMail("Ashish@jctltd.com", "noreply@jctltd.com", "Error in Authorizing SanctionNote !!!", "The sanction note no " & SanctionNote & "was under authorization process but some error was genrated.....<br> " & ex.ToString)
'        '    Tran.Rollback()
'        'End Try
'    End Sub

'    Private Sub SendMail()

'        Dim from As String, [to] As String, bcc As String, cc As String, subject As String, body As String, Reason As String
'        Dim sql As String
'        Dim Auth As String
'        Dim sb As New StringBuilder()

'        sql = "Select * from jct_ops_material_request where AuthStatus='P' and requestid=" + ViewState("ID")
'        If (objFun.CheckRecordExistInTransaction(sql)) Then

'            ' sql = "Select LEFT(FlagAuth + ',',CHARINDEX(',', FlagAuth + ',') - 1) as FlagAuth from jct_ops_material_request where AuthStatus='P' and requestid=" + ViewState("ID") + " "
'            'sql = "Select  LEFT(SUBSTRING(FlagAuth,2,999) ,CHARINDEX(',', SUBSTRING(FlagAuth,2,999)) - 1)  as FlagAuth from jct_ops_material_request where AuthStatus='P' and requestid=" + ViewState("ID") + " "
'            sql = "JCT_OPS_SANCTION_NOTE_MATERIAL_RETURN_REASON_MAIL_AUTHORIZATION"
'            Dim cmd As SqlCommand = New SqlCommand(sql, obj.Connection())
'            cmd.CommandType = CommandType.StoredProcedure
'            cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ViewState("ID")
'            Dim dr1 As SqlDataReader = cmd.ExecuteReader()
'            If (dr1.HasRows()) Then
'                While (dr1.Read())

'                    Auth = dr1(0).ToString()
'                End While
'            End If


'        End If
'        sql = "Select * from jct_ops_material_request where AuthStatus='A' and requestid=" + ViewState("ID")
'        If (objFun.CheckRecordExistInTransaction(sql)) Then

'            'sql = "Select LEFT(FlagAuth + ',',CHARINDEX(',', FlagAuth + ',') - 1) as FlagAuth from jct_ops_material_return where AuthStatus='A' and requestid=" + ViewState("ID") + " "
'            'Auth = "charanamrit.singh@jctltd.com,mikeops@jctltd.com"

'        End If



'        sb.AppendLine("<html>")
'        sb.AppendLine("<head>")
'        sb.AppendLine("<style type=""text/css"">")
'        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}")
'        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}")
'        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}")
'        sb.AppendLine("</style>")
'        sb.AppendLine("</head>")



'        ' sb.Append("<head>");
'        sb.AppendLine("Hi,<br/><br/>")
'        sb.AppendLine("Material Return Request has been generated in OPS.<br/><br/>")
'        sb.AppendLine("RequestID for your request is : " + ViewState("RequestID") + " <br/><br/>")
'        sb.AppendLine("Details are Shown below : <br/><br/>")
'        sb.AppendLine("<table class=gridtable>")
'        sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th> Auth. Pending At</th> </tr>")
'        sql = "SELECT isnull(a.invoice_no,'') as invoice_no,isnull(a.item_no,'') as item_no,isnull(a.customer,'') as customer,isnull(b.empname,'') as sales_person,isnull(Convert(numeric(12,2),a.invoice_qty),0) as invoice_qty,isnull(Convert(Numeric(12,2),a.ret_qty),0) as ret_qty ,isnull(Substring(a.FlagAuth,2,999),'') as FlagAuth,AuthStatus ,reason FROM dbo.jct_ops_material_request a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') WHERE a.RequestID=" + ViewState("ID")

'        Dim Dr As SqlDataReader = objFun.FetchReader(sql)
'        If (Dr.HasRows) Then
'            While (Dr.Read())

'                Reason = Dr(8).ToString
'                If (Dr(7).ToString = "A") Then
'                    sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td>  <td>" & Dr(5).ToString & "</td>  <td> CEO </td> </tr> ")
'                Else
'                    sql = "Select empname from jct_empmast_base where active='Y' and  empcode='" + Dr(6).ToString().Split(",")(0) + "'"
'                    Dim empname As String = ""
'                    Dim obj2 As Connection = New Connection
'                    Dim cmd As SqlCommand = New SqlCommand(sql, obj2.Connection())
'                    Dim dr1 As SqlDataReader = cmd.ExecuteReader
'                    If (dr1.HasRows()) Then

'                        While (dr1.Read)

'                            empname = dr1(0).ToString

'                        End While

'                    End If
'                    dr1.Close()
'                    obj2.ConClose()
'                    sb.AppendLine("<tr> <td> " & Dr(0).ToString & " </td> <td> " & Dr(1).ToString & "  </td>  <td> " & Dr(2).ToString & "</td>  <td>" & Dr(3).ToString & " </td>  <td>" & Dr(4).ToString & " </td>  <td>" & Dr(5).ToString & "</td>  <td>" & empname & "</td> </tr> ")
'                End If
'            End While

'        End If
'        Dr.Close()
'        sb.AppendLine("</table>")
'        sb.AppendLine("<br />")
'        sb.Append("<a href='http://testerp/fusionapps/OPS/AuthorizeSanctionNote10.aspx'> Click here to view details... </a><br />")

'        sb.AppendLine("</table><br />")

'        sb.AppendLine("<br/><br />")
'        sb.AppendLine("Reason For Qty Return : " + Reason + "<br /><br/>")
'        sql = "Select empname from jct_empmast_base where empcode='" + Session("EmpCode") + "'"
'        sb.AppendLine("Last Authorized by : " + objFun.FetchValue(sql) + "<br /><br/>")
'        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>")
'        sb.AppendLine("Thank you<br />")
'        sb.AppendLine("</html>")


'        body = sb.ToString()
'        from = "noreply@jctltd.com"

'        '[to] = email1 + "," + email2
'        [to] = IIf(String.IsNullOrEmpty(Auth), "it.helpdesk@jctltd.com", Auth)
'        bcc = "manishk@jctltd.com,ashish@jctltd.com"
'        ' [to] = ("jatindutta@jctltd.com")
'        'Email Address of Receiver
'        'cc = "jatindutta@jctltd.com,jagdeep@jctltd.com,hitesh@jctltd.com"
'        subject = " Material Return Request"
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
'        'If Not String.IsNullOrEmpty(cc) Then
'        '    If cc.Contains(",") Then
'        '        Dim ccs As String() = cc.Split(","c)
'        '        For i As Integer = 0 To ccs.Length - 1
'        '            mail.CC.Add(New MailAddress(ccs(i)))
'        '        Next
'        '    Else
'        '        mail.CC.Add(New MailAddress(bcc))
'        '    End If
'        '    mail.CC.Add(New MailAddress(cc))
'        'End If

'        mail.Subject = subject
'        mail.Body = body
'        mail.IsBodyHtml = True
'        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
'        Dim SmtpMail As New SmtpClient("exchange2007")

'        'SmtpMail.SmtpServer = "exchange2007";
'        SmtpMail.Send(mail)
'        'return mail;
'    End Sub

'End Class
