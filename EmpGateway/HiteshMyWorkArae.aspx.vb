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
        If (Session("empcode").ToString <> "") Then
            'empcode = Session("empcode")
        Else
            Response.Redirect("login.aspx")
        End If

        If Not Page.IsPostBack Then
            If DrpLvStatus.Text = "Pending" Then
                '--------------------------------------------------------------------

                BindData()
                BindDataView()
                '--------------------------------------------------------------------
                MyTasks()
                Me.PnlLv.Collapsed = True
                Me.PnlTasks.Collapsed = True
                Me.CPforCc.Collapsed = True
                If Trim(Me.DrpLvStatus.Text) = "Pending" And Session("empcode") = "R-03339" Then
                    'If Session("empcode") = "R-03339" Then
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

        Dim Sqlpass = "select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code   and flag=left(FlagHC,2) and  DateDiff(day,getdate(),leavefrom) >=-45 and Resp_emp='" & Trim(ECode) & "' and auth_req='Y' order by AutoId "
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
        ECode = Session("EmpCode")

        Dim Sqlpass = "select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  AuthFlag='A' and flag='1H' and DateDiff(day,getdate(),leavefrom) >=-45 and Resp_emp='" & Trim(ECode) & "' and auth_req='Y' order by AutoId "
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

    Public Sub SubAuthorize()
        ECode = Session("Empcode")

        Dim Sqlpass = "select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  SubAuthFlag='A' and flag='2T' and DateDiff(day,getdate(),leavefrom) >=-45 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' order by AutoId "
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
    Public Sub SubAuthorizeForC()
        ECode = Session("Empcode")

        Dim Sqlpass = "Select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  CFlag='A' and flag='3C' and DateDiff(day,getdate(),leavefrom) >=-45 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' order by AutoId "
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
    Public Sub SubAuthorizeForB1()
        ECode = Session("Empcode")

        Dim Sqlpass = "Select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  B1Flag='A' and flag='B1' and DateDiff(day,getdate(),leavefrom) >=-45 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' order by AutoId "
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
    Public Sub SubAuthorizeForB2()
        ECode = Session("Empcode")

        Dim Sqlpass = "Select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  B2Flag='A' and flag='B2' and DateDiff(day,getdate(),leavefrom) >=-45 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' order by AutoId "
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
    Public Sub SubAuthorizeForB3()
        ECode = Session("Empcode")

        Dim Sqlpass = "Select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  B3Flag='A' and flag='B3' and DateDiff(day,getdate(),leavefrom) >=-45 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' order by AutoId "
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
    Public Sub SubAuthorizeForB4()
        ECode = Session("Empcode")

        Dim Sqlpass = "Select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  B4Flag='A' and flag='B4' and DateDiff(day,getdate(),leavefrom) >=-45 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' order by AutoId "
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

        Dim Sqlpass = "select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ]  from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  AuthFlag='C' and flag='1H' and DateDiff(day,getdate(),leavefrom) >=-45 and Resp_emp='" & Trim(ECode) & "' and auth_req='Y' order by AutoId "
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

    Public Sub SubCancle()
        ECode = Session("Empcode")

        Dim Sqlpass = "select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ]  from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  SubAuthFlag='C' and flag='2T' and  DateDiff(day,getdate(),leavefrom)>=-45 and Resp_emp='" & Trim(ECode) & "' and auth_req='Y' order by AutoId "
        Dim Dr As SqlDataReader = Obj.FetchReader(Sqlpass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Sqlpass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds1 As DataSet = New DataSet()
                Session("Authorize") = 1
                ds1.Clear()
                Da.Fill(ds1)
                GridView1.DataSource = ds1
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
    Public Sub SubCancleC()
        ECode = Session("Empcode")

        Dim Sqlpass = "select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ]  from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  CFlag='C' and flag='3C' and  DateDiff(day,getdate(),leavefrom)>=-45 and Resp_emp='" & Trim(ECode) & "' and auth_req='Y' order by AutoId "
        Dim Dr As SqlDataReader = Obj.FetchReader(Sqlpass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Sqlpass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds1 As DataSet = New DataSet()
                Session("Authorize") = 1
                ds1.Clear()
                Da.Fill(ds1)
                GridView1.DataSource = ds1
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

        Dim Sqlpass = "select AutoId as ID ,NatureLeave as Nature,Empcode as EmployeeCode,Name,Desgination,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code   and flag='B' and  DateDiff(day,getdate(),leavefrom) >=-45 and Resp_emp='" & Trim(ECode) & "' and auth_req='Y' order by AutoId "
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
            SubAuthorize()
            SubAuthorizeForC()
            SubAuthorizeForB1()
            SubAuthorizeForB2()
            SubAuthorizeForB3()
            SubAuthorizeForB4()
        ElseIf DrpLvStatus.Text = "Cancelled" Then
            Cancle()
            SubCancle()
            SubCancleC()

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
            SubAuthorize()
            SubAuthorizeForC()
            SubAuthorizeForB1()
            SubAuthorizeForB2()
            SubAuthorizeForB3()
            SubAuthorizeForB4()
            GridView1.Enabled = True
            GridView2.Enabled = True

        ElseIf DrpLvStatus.Text = "Cancelled" Then

            Cancle()
            SubCancle()
            SubCancleC()

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

        qry = "select distinct a.Task_No,SubArea,c.empname,a.subject, a.task_status,a.task_priority, case when a.due_date='01/01/1900' then '' else convert(varchar(10),a.due_date,103) end as duedate from jct_task_log a, JCT_Task_Recepients b, jct_empmast_base c where a.task_no=b.task_no and rtrim(a.emp_code)=rtrim(c.empcode) and status='' and b.flag in('c') and b.recp_code='" & Session("empcode") & "' and task_status not in ('Closed','Completed')"
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
        'Dim Sqlpass = "select Survey_No ,Subject,user_Code PostedBy,Dept_code,Last_Date from jct_emp_survey_Master where  Last_Date>getdate()" ' a.empcode=b.Emp_Code and  SubAuthFlag='OK' and flag='C' and DateDiff(day,getdate(),leavefrom) >=-45 and  Resp_emp='" & Trim(ECode) & "' order by AutoId "
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

    Protected Sub GrdSurAuthrised_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdSurAuthrised.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Text = "<a href='SurveyMaster.aspx?reply=1&SurveyNo=" & e.Row.DataItem(0) & "'>" & e.Row.DataItem(0) & " </a>"
        End If
    End Sub
    Public Sub Comments()
        'Dim Sqlpass = "select a.Comment_No as [No.], empname As [Comment By],convert(varchar(10),a.created_dt,103) as [On Date], Topic, Point from jct_emp_guestbook a, jct_emp_guestbook_trans b, jct_empmast_base c where a.comment_no=b.comment_no and a.user_code=c.empcode and c.active='y' and address_to='" & Session("empcode") & "' order by a.comment_no"
        Dim Sqlpass = "select empname As [Comment By],convert(varchar(10),a.created_dt,103) as [On Date], Topic, Point, Remarks from jct_emp_guestbook a, jct_emp_guestbook_trans b, jct_empmast_base c where a.comment_no=b.comment_no and a.user_code=c.empcode and c.active='y' and address_to='" & Session("empcode") & "' order by a.created_dt"
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
End Class
