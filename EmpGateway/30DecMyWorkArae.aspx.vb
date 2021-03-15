Imports System.Data.SqlClient
Imports System.Data
Imports system.Math
Partial Class MyWorkArae
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String
    Dim ECode, CurLeaTime As String
    'Store means Autoid Number
    Dim Store As String
    Dim DateVar As DateTime
    Dim DateMinus As Integer
    Public ob As New HelpDeskClass
    Public cmd As New SqlCommand
    Public qry, CheckFlag As String
    Dim i As Integer
    Public dr As SqlDataReader
    Dim cl(70) As String
    Dim ShowAuth As Boolean = False, ShowCan As Boolean = False
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("Empcode").ToString <> "") Then
        Else
            Response.Redirect("~/login.aspx")
        End If

        If Not Page.IsPostBack Then
            If DrpLvStatus.Text = "Pending" Then
                '--------------------------------------------------------------------

                BindData()
                BindDataView()
                '--------------------------------------------------------------------
                MyTasks()

                'Hitesh 29 Oct 2008
                'Me.PnlLv.Collapsed = True
                Me.PnlTasks.Collapsed = True
                Me.CPforCc.Collapsed = True
                Me.CPNews.Collapsed = True
                Me.CPDoc.Collapsable = True
                Gridnewsbind()
                GrdDocBind()

                If Trim(Me.DrpLvStatus.Text) = "Pending" And Session("Empcode") = "R-03339" Then
                    'If Session("Empcode") = "R-03339" Then
                    GetDataForGrid()


                    'Else
                    '    Pannel1.Visible = False
                    '    LblSurveyCaption.Visible = False
                    'End If
                End If
            End If
            Me.CollapsablePanel1.Collapsed = True
            Comments()


        End If

    End Sub
    '---------------------------------------------------------------------------------------
    'Pending Leave
    '---------------------------------------------------------------------------------------
    Public Sub BindData()
        ECode = Session("Empcode")

        Dim Sqlpass = "select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code   and flag=left(FlagHC,2) and  DateDiff(day,getdate(),CurLeaveTime)>=-45 and Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "' order by AutoId "
        Dim Dr As SqlDataReader = Obj.FetchReader(Sqlpass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Sqlpass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                Session("Authorize") = 1
                ds.Clear()
                Da.Fill(ds)
                GridView1.DataSource = ds
                GridView1.DataBind()
                Dr.Close()
            Else
                GridView1.DataSource = Nothing
                GridView1.DataBind()
            End If
        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try
    End Sub
    '---------------------------------------------------------------------------------------
    'Authorize Leave
    '---------------------------------------------------------------------------------------
    Public Sub Authorize()
        ECode = Session("Empcode")

        Dim Sqlpass = "select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  AuthFlag='A' and flag='1H' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "' " & _
                     "union select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  SubAuthFlag='A' and flag='2T' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and  b.Company_Code='" & Session("Companycode") & "' " & _
                     "Union Select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  CFlag='A' and flag='3C' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and  b.Company_Code='" & Session("Companycode") & "'  " & _
                     "Union Select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  B1Flag='A' and flag='B1' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "'  " & _
                     "Union Select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  B2Flag='A' and flag='B2' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "' " & _
                    "Union Select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  B3Flag='A' and flag='B3' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "'  " & _
                    "Union Select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  B4Flag='A' and flag='B4' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "'  order by autoid desc "


        Dim Dr As SqlDataReader = Obj.FetchReader(Sqlpass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Sqlpass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                Session("Authorize") = 1
                ds.Clear()
                Da.Fill(ds)
                GridView1.DataSource = ds
                GridView1.DataBind()
                Dr.Close()
                ShowAuth = True
            Else
                If ShowAuth = False Then
                    GridView1.DataSource = Nothing
                    GridView1.DataBind()
                End If
            End If
        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try

    End Sub


    '---------------------------------------------------------------------------------------
    'Cancel Leave
    '---------------------------------------------------------------------------------------
    Public Sub Cancle()
        ECode = Session("Empcode")

        Dim Sqlpass = "select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ]  from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  AuthFlag='C' and flag='1H' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "'  " & _
                      "Union select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ]  from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  SubAuthFlag='C' and flag='2T' and  DateDiff(day,getdate(),leavefrom)>=-20 and Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "'  " & _
                      " Union select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ]  from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  CFlag='C' and flag='3C' and  DateDiff(day,getdate(),leavefrom)>=-20 and Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "'  order by autoid desc"
        Dim Dr As SqlDataReader = Obj.FetchReader(Sqlpass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Sqlpass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                Session("Authorize") = 1
                ds.Clear()
                Da.Fill(ds)
                GridView1.DataSource = ds
                GridView1.DataBind()
                Dr.Close()
                ShowCan = True
            Else
                If ShowCan = False Then
                    GridView1.DataSource = Nothing
                    GridView1.DataBind()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try

    End Sub

    '---------------------------------------------------------------------------------------
    'For Bcc leave Only For View
    '---------------------------------------------------------------------------------------
    Public Sub BindDataView()
        ECode = Session("Empcode")

        Dim Sqlpass = "select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b where a.empcode=b.Emp_Code   and flag='B' and  DateDiff(day,getdate(),CurLeaveTime)>=-20 and Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null  and b.Company_Code='" & Session("Companycode") & "'  order by AutoId "
        Dim Dr As SqlDataReader = Obj.FetchReader(Sqlpass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Sqlpass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                Session("Authorize") = 1
                ds.Clear()
                Da.Fill(ds)
                GridView2.DataSource = ds
                GridView2.DataBind()
                Dr.Close()
            Else
                GridView2.DataSource = Nothing
                GridView2.DataBind()
            End If
        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try

    End Sub
    '---------------------------------------------------------------------------------------
    'Paging for To Inbox
    '---------------------------------------------------------------------------------------
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        If DrpLvStatus.Text = "Pending" Then
            BindData()
        ElseIf DrpLvStatus.Text = "Authorized" Then
            Authorize()
        ElseIf DrpLvStatus.Text = "Cancelled" Then
            Cancle()

        End If
    End Sub
    '---------------------------------------------------------------------------------------
    'Paging for BCC Inbox
    '---------------------------------------------------------------------------------------
    Protected Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        GridView2.PageIndex = e.NewPageIndex
        BindDataView()
    End Sub
    '---------------------------------------------------------------------------------------
    'Drop Down Option For Checking Auth,Pending,Cancle Leave
    '---------------------------------------------------------------------------------------
    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpLvStatus.SelectedIndexChanged

        If DrpLvStatus.Text = "Authorized" Then

            Authorize()

            GridView1.Enabled = True
            GridView2.Enabled = True

        ElseIf DrpLvStatus.Text = "Cancelled" Then

            Cancle()


            GridView1.Enabled = True
            GridView2.Enabled = True

        ElseIf DrpLvStatus.Text = "Pending" Then

            BindData()
            GridView2.Enabled = True
            GridView1.Enabled = True
        Else

        End If

    End Sub
    '---------------------------------------------------------------------------------------
    'For Hyperlink on Auto ID
    '---------------------------------------------------------------------------------------
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If DrpLvStatus.Text = "Pending" Then

            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Cells(0).Text = "<a href='default11.aspx?ID=" & e.Row.DataItem(0) & "'>" & e.Row.DataItem(0) & "</a>"
            End If

        End If
    End Sub
    '---------------------------------------------------------------------------------------
    'With HyperLink Move On Page Default11.azpx for Authorize or Cancel Leave Option
    '---------------------------------------------------------------------------------------
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        If DrpLvStatus.Text = "Pending" Then
            Session("Store") = GridView1.SelectedRow.Cells(1).Text
            Me.Page.Visible = False
            Response.Redirect("default11.aspx")
            GridView1.Enabled = True
        End If
    End Sub


    Private Sub mail48()
        Dim ObjMail As New Mail.MailMessage
        With ObjMail
            ObjMail.From = "hitesh@jctltd.com"
            ObjMail.To = "kakhan@jctltd.com"

            ObjMail.Body = "Please Intimate for authorize pending leave !"
            Mail.SmtpMail.SmtpServer = "exchange2003"
            Mail.SmtpMail.Send(ObjMail)
        End With
    End Sub

    Protected Sub GridMyTasks_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridMyTasks.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'e.Row.Cells[1].Text = "<a href='www.yahoo.com'>" + ((DataRowView)e.Row.DataItem)["Name"] + "</a>";
            e.Row.Cells(0).Text = "<a href='taskmanagement.aspx?reply=1&task=" & e.Row.DataItem(0) & "'>" & e.Row.DataItem(0) & "</a>"
            ' e.Row.Cells(0).Text = "<a href='taskmanagement.aspx>" & e.Row.DataItem(0) & "</a>"
            ' e.Row.Cells(1).Text = "<a href='TaskManagement.aspx'>" & CType(e.Row.DataItem, DataRowView)(1) & "</a>"

        End If
    End Sub

    Public Sub MyTasks()
        Dim ds As New Data.DataSet
        Dim drow As Data.DataRow
        Dim dt As New Data.DataTable

        Dim cust As String = ""
        Dim sp As String = ""
        ob.opencn()

        qry = "select distinct a.Task_No,SubArea,c.empname,a.subject, a.task_status,a.task_priority, case when a.due_date='01/01/1900' then '' else convert(varchar(10),a.due_date,103) end as duedate from jct_task_log a, JCT_Task_Recepients b, jct_empmast_base c where a.task_no=b.task_no and rtrim(a.emp_code)=rtrim(c.empcode) and status='' and b.flag in('c') and b.recp_code='" & Session("Empcode") & "' and task_status not in ('Closed','Completed')"
        cmd = New SqlCommand(qry, ob.cn)
        cmd.CommandTimeout = 0
        dr = cmd.ExecuteReader

        Dim i As Integer
        cl(0) = "Task No"
        cl(1) = "Category"
        cl(2) = "Assigned By"
        cl(3) = "Subject"
        cl(4) = "Status"
        cl(5) = "Priority"
        cl(6) = "Due Date"
        For i = 0 To 6
            Dim dc As New Data.DataColumn
            dc.ColumnName = cl(i)
            dt.Columns.Add(dc)
        Next
        i = 0
        If dr.HasRows = True Then
            While dr.Read()
                drow = dt.NewRow()
                dt.Rows.Add(drow)
                For i = 0 To 6
                    drow(i) = Trim(dr.Item(i))
                Next
            End While
        End If
        GridMyTasks.DataSource = dt
        GridMyTasks.DataBind()
        dr.Close()
        ob.closecn()
    End Sub
    Public Sub GetDataForGrid()
        'Dim Sqlpass = "select Survey_No ,Subject,user_Code PostedBy,Dept_code,Last_Date from jct_emp_survey_Master where  Last_Date>getdate()" ' a.empcode=b.Emp_Code and  SubAuthFlag='OK' and flag='C' and DateDiff(day,getdate(),CurLeaveTime)>=-45 and  Resp_emp='" & Trim(ECode) & "' order by AutoId "
        Dim Sqlpass = "select a.Survey_No,a.Subject,b.empname PostedBy,c.Deptname,a.Last_Date from jct_emp_survey_Master a, jct_empmast_base b, deptmast c where a.user_code=b.empcode and a.dept_code = c.deptcode and a.auth_Flag='U'"
        Dim Dr As SqlDataReader = Obj.FetchReader(Sqlpass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Sqlpass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                Session("Authorize") = 1
                ds.Clear()
                Da.Fill(ds)
                GrdSurAuthrised.DataSource = ds
                GrdSurAuthrised.DataBind()
                Dr.Close()
            Else
                GrdSurAuthrised.DataSource = Nothing
                GrdSurAuthrised.DataBind()
            End If
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try
    End Sub
    '............gridview to display pending/authorized news......
    Public Sub Gridnewsbind()

        Obj.ConOpen()
        If Session("Empcode") = "R-03339" Then
            Try
                SqlPass = "select a.transaction_no as trans,a.headline as head,convert(Varchar(12),a.news_start_date,103) as date,b.empname as empname,c.deptname as dept from jct_empg_news a,jct_empmast_base b,deptmast c where a.UserCode=b.empcode and a.department=c.deptcode and a.Auth_Flag='" & ddlnews.SelectedValue & "' and a.outdatedflag='N' and companycode='" & Session("Companycode") & "'"
                Dim ds As New DataSet
                Dim adp As New SqlDataAdapter(SqlPass, Obj.Connection)
                adp.Fill(ds)
                GridNews.DataSource = ds
                GridNews.DataBind()
            Catch ex As Exception

            Finally
                Obj.ConClose()
            End Try
        End If
    End Sub

    Protected Sub GrdSurAuthrised_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdSurAuthrised.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Text = "<a href='SurveyMaster.aspx?reply=1&SurveyNo=" & e.Row.DataItem(0) & "'>" & e.Row.DataItem(0) & " </a>"
        End If
    End Sub
    Public Sub Comments()
        'Dim Sqlpass = "select a.Comment_No as [No.], empname As [Comment By],convert(varchar(10),a.created_dt,103) as [On Date], Topic, Point from jct_emp_guestbook a, jct_emp_guestbook_trans b, jct_empmast_base c where a.comment_no=b.comment_no and a.user_code=c.empcode and c.active='y' and address_to='" & Session("Empcode") & "' order by a.comment_no"
        Dim Sqlpass = "select empname As [Comment By],convert(varchar(10),a.created_dt,103) as [On Date], Topic, Point, Remarks from jct_emp_guestbook a, jct_emp_guestbook_trans b, jct_empmast_base c where a.comment_no=b.comment_no and a.user_code=c.empcode and c.active='y' and address_to='" & Session("Empcode") & "' order by a.created_dt"
        Dim Dr As SqlDataReader = Obj.FetchReader(Sqlpass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Sqlpass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                '                Session("Authorize") = 1
                ds.Clear()
                Da.Fill(ds)
                GrdComments.DataSource = ds
                GrdComments.DataBind()
                Dr.Close()
            Else
                GrdComments.DataSource = Nothing
                GrdComments.DataBind()
            End If
        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try

    End Sub
    '.................dropdown to display pending/authorized options for displaying news.............
    Protected Sub ddlnews_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlnews.SelectedIndexChanged
        Gridnewsbind()
    End Sub
    '............redirects to news master page when clicked on news number linkbutton.....................
    Protected Sub GridNews_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridNews.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim trans As LinkButton = CType(e.Row.FindControl("lnknews"), LinkButton)
            Dim transno As String = trans.Text
            trans.PostBackUrl = "~/NewsMaster.aspx?trans=" & transno & "&act=A"
        End If
    End Sub
    '...........Gridview which shows pending/authorized documents............... 
    Protected Sub GrdDocBind()
        If Session("Empcode") = "R-03339" Then
            Obj.ConOpen()
            SqlPass = "jct_empg_doc '" & ddldoc.SelectedValue & "','" & Session("Companycode") & "'"
            Dim ds As New DataSet
            Dim adp As New SqlDataAdapter(SqlPass, Obj.Connection)
            adp.Fill(ds)
            GrdDoc.DataSource = ds
            GrdDoc.DataBind()
            Obj.ConClose()
            If ddldoc.SelectedValue = "A" Then
                GrdDoc.Columns(4).Visible = False
            End If
        End If
    End Sub
    '.................dropdown to display pending/authorized options for displaying documents.............
    Protected Sub ddldoc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddldoc.SelectedIndexChanged
        GrdDocBind()
    End Sub
    '..................updates authorization flag when clicked on authorize linkbutton.................
    Protected Sub GrdDoc_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GrdDoc.RowUpdating
        Dim sqlpass1, sqlpass2, sqlpass3, sqlpass4, type, dept, user, file, filename, fileext, email As String
        type = CType(GrdDoc.Rows(e.RowIndex).FindControl("lbltype"), Label).Text
        dept = CType(GrdDoc.Rows(e.RowIndex).FindControl("lbldept"), Label).Text
        user = CType(GrdDoc.Rows(e.RowIndex).FindControl("lbluser"), Label).Text
        file = CType(GrdDoc.Rows(e.RowIndex).FindControl("lnkfile"), LinkButton).Text
        filename = StrReverse(Mid(StrReverse(file), 5, StrReverse(file).Length))
        fileext = StrReverse(Mid(StrReverse(file), 1, 4))

        Obj.ConOpen()
        sqlpass1 = "select distinct deptcode from deptmast where deptname='" & dept & "'"
        Dim cmd1 As New SqlCommand(sqlpass1, Obj.Connection)
        dept = cmd1.ExecuteScalar
        cmd1.Dispose()

        sqlpass2 = "select distinct empcode from jct_empmast_base where empname='" & user & "'"
        Dim cmd2 As New SqlCommand(sqlpass2, Obj.Connection)
        user = cmd2.ExecuteScalar
        cmd2.Dispose()

        If type = "Forms" Then
            sqlpass3 = "update jct_empg_forms set Auth_flag='A' where usercode='" & user & "' and DeptCode='" & dept & "' and filename='" & filename & "' and FileExt='" & fileext & "' and companycode='JCT00LTD'"
            'Obj.ExecQry(sqlpass3)
            UpdateRecord(sqlpass3)
        ElseIf type = "Office Order" Then
            sqlpass3 = "update jct_empg_order set Auth_flag='A' where usercode='" & user & "' and DeptCode='" & dept & "' and filename='" & filename & "' and FileExt='" & fileext & "' and companycode='JCT00LTD'"
            'Obj.ExecQry(sqlpass3)
            UpdateRecord(sqlpass3)
        ElseIf type = "Training Material" Then
            sqlpass3 = "update jct_empg_trainee set Auth_flag='A' where usercode='" & user & "' and DeptCode='" & dept & "' and filename='" & filename & "' and FileExt='" & fileext & "' and companycode='JCT00LTD'"
            'Obj.ExecQry(sqlpass3)
            UpdateRecord(sqlpass3)
        End If

        sqlpass4 = "select e_mailid from mistel where empcode='" & user & "'"
        Dim dr As SqlDataReader = Obj.FetchReader(sqlpass4)
        If dr.HasRows Then
            dr.Read()
            If dr.Item(0) Is System.DBNull.Value Then
                email = ""
            Else
                email = dr(0).ToString

            End If
        Else
            email = ""
        End If
        dr.Close()
        GrdDocBind()
        sendmail("rbaksshi@jctltd.com", email, type)
        Response.Write("<script>alert('Document Authorized!!')</script>")
        Obj.ConClose()

    End Sub
    '..........opens the file when clicked on filename linkbutton...............
    Protected Sub GrdDoc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdDoc.SelectedIndexChanged

        Dim type, file, filepth As String
        type = CType(GrdDoc.SelectedRow.FindControl("lbltype"), Label).Text
        file = CType(GrdDoc.SelectedRow.FindControl("lnkfile"), LinkButton).Text

        Obj.ConOpen()
        If type = "Forms" Then
            filepth = "D:\WebApplications\EmpGateway\Leave\" & file
        ElseIf type = "Office Order" Then
            filepth = "D:\WebApplications\EmpGateway\Order\" & file
        ElseIf type = "Training Material" Then
            filepth = "D:\WebApplications\EmpGateway\Training\" & file
        End If
        Response.Redirect("DownloadFile.aspx?filepth=" & filepth)

    End Sub
    'Modified By:- Kulwinder Date:-5/May/2009 
    'Added mail function for authorization of documents
    Private Sub sendmail(ByVal From As String, ByVal Too As String, ByVal type As String)
        Dim MailSmpt As New Mail.MailMessage

        With MailSmpt
            Obj.ConOpen()
            SqlPass = "select e_mailid from mistel where empcode='" & Session("Empcode") & "'"
            Dim dr As SqlDataReader = Obj.FetchReader(SqlPass)
            If dr.HasRows = True Then
                dr.Read()
                If dr.Item(0) Is System.DBNull.Value Then
                    .From = From '"dummy@jctltd.com"
                Else
                    .From = dr.Item(0)
                End If
            Else
                .From = From '"dummy@jctltd.com"
            End If
            dr.Close()
            Obj.ConOpen()
            .To = Trim(Too)

            .Body = Session("empname") & " has authorized document of type : " & type & " submitted by you" & "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email has been generated through Employee Gateway Package. <br/>Kindly do not reply as you will not receive a response."
            .Subject = "Document Authorized "

            Mail.SmtpMail.SmtpServer = "exchange2003"
            If Too <> "" Then
                Mail.SmtpMail.Send(MailSmpt)
                MailSmpt = Nothing
            End If
        End With

    End Sub
End Class
'\\test2k\webapplication old 16/Sep/2008 old code have not with satus
' now with status