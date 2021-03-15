Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports Telerik.Web.UI
Imports System.Net.Mail

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
    Public objClassFunction As New Functions
    Public cmd As New SqlCommand
    Public qry, CheckFlag As String
    Dim i As Integer
    Public dr As SqlDataReader
    Dim cl(70) As String
    Dim ShowAuth As Boolean = False, ShowCan As Boolean = False
    Public AutoStr As String
    Dim AId As Integer, Tot, empcode_to, EmailTO, EmailFrom, Mr_Mrs, empname, designation, Emailcc, EmailBcc, to_name, Mr_Mrs_to As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("Empcode").ToString <> "") Then
        Else
            Response.Redirect("~/login.aspx")
        End If

        If Not Page.IsPostBack Then
            GetTransportationRequisitions()
            If DrpLvStatus.Text = "Pending" Then
                '--------------------------------------------------------------------

                BindData()
                BindDataView()
                '--------------------------------------------------------------------
                MyTasks()
                Guest()
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

        ' Dim Sqlpass = "select AutoId as ID ,NatureLeave as Nature, Name,Department, Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code   and flag=left(FlagHC,2) and  DateDiff(day,getdate(),CurLeaveTime)>=-75 and Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "' order by AutoId "
        Dim sqlpass = "exec jct_empg_authorize_leave  '" & ECode & "'"
        Dim cmd As SqlCommand = New SqlCommand(sqlpass, Obj.Connection())
        cmd.CommandTimeout = 0
        Dim Dr As SqlDataReader = cmd.ExecuteReader() 'objClassFunction.FetchReader(sqlpass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                Session("Authorize") = 1
                ds.Clear()
                objClassFunction.FillGrid(sqlpass, GridView1)
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

        'Dim Sqlpass = "select AutoId as ID ,NatureLeave as Nature,Name,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  AuthFlag='A' and flag='1H' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "' " & _
        '             "union select AutoId as ID ,NatureLeave as Nature,Name,Department, Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  SubAuthFlag='A' and flag='2T' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and  b.Company_Code='" & Session("Companycode") & "' " & _
        '             "Union Select AutoId as ID ,NatureLeave as Nature,Name,Department,Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  CFlag='A' and flag='3C' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and  b.Company_Code='" & Session("Companycode") & "'  " & _
        '             "Union Select AutoId as ID ,NatureLeave as Nature,Name,Department, Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  B1Flag='A' and flag='B1' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "'  " & _
        '             "Union Select AutoId as ID ,NatureLeave as Nature,Name,Department, Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  B2Flag='A' and flag='B2' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "' " & _
        '            "Union Select AutoId as ID ,NatureLeave as Nature,Name,Department, Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  B3Flag='A' and flag='B3' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "'  " & _
        '            "Union Select AutoId as ID ,NatureLeave as Nature,Name,Department, Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  B4Flag='A' and flag='B4' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "'  order by autoid desc " & _
        '            "Union SELECT  ID ,Leave AS Nature ,empname AS NAME , Dept AS Department ,CONVERT(CHAR(10), leavedate, 103) AS [ FROM ] ,CONVERT(CHAR(10), leavedate, 103) AS [ TO ] ,CONVERT(CHAR(10), applied_on, 103) AS [ APPLIED ON ]FROM    dbo.[jct_empg_compensatory_leave]WHERE   STATUS = 'A' AND authHod = 'A' AND ( Hod = '" & Trim(ECode) & "' OR cc ='" & Trim(ECode) & "')"

        Dim Sqlpass = "select AutoId as ID ,NatureLeave as Nature,Name,Department,a.DAYS,Convert( char(10),LeaveFrom,103) as [From] , Convert( char(10),LeaveTo,103) as [To], Convert( char(10),curleavetime,103) as [Applied On] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  AuthFlag='A' and flag='1H' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "' " & _
                    "union select AutoId as ID ,NatureLeave as Nature,Name,Department,a.DAYS, Convert( char(10),LeaveFrom,103) as [From] , Convert( char(10),LeaveTo,103) as [To], Convert( char(10),curleavetime,103) as [Applied On] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  SubAuthFlag='A' and flag='2T' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and  b.Company_Code='" & Session("Companycode") & "' " & _
                    "Union Select AutoId as ID ,NatureLeave as Nature,Name,Department,a.DAYS,Convert( char(10),LeaveFrom,103) as [From] , Convert( char(10),LeaveTo,103) as [To], Convert( char(10),curleavetime,103) as [Applied On] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  CFlag='A' and flag='3C' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and  b.Company_Code='" & Session("Companycode") & "'  " & _
                    "Union Select AutoId as ID ,NatureLeave as Nature,Name,Department,a.DAYS, Convert( char(10),LeaveFrom,103) as [From] , Convert( char(10),LeaveTo,103) as [To], Convert( char(10),curleavetime,103) as [Applied On] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  B1Flag='A' and flag='B1' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "'  " & _
                    "Union Select AutoId as ID ,NatureLeave as Nature,Name,Department,a.DAYS, Convert( char(10),LeaveFrom,103) as [From] , Convert( char(10),LeaveTo,103) as [To], Convert( char(10),curleavetime,103) as [Applied On] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  B2Flag='A' and flag='B2' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "' " & _
                   "Union Select AutoId as ID ,NatureLeave as Nature,Name,Department,a.DAYS, Convert( char(10),LeaveFrom,103) as [From] , Convert( char(10),LeaveTo,103) as [To], Convert( char(10),curleavetime,103) as [Applied On] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  B3Flag='A' and flag='B3' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "'  " & _
                   "Union Select AutoId as ID ,NatureLeave as Nature,Name,Department,a.DAYS, Convert( char(10),LeaveFrom,103) as [From] , Convert( char(10),LeaveTo,103) as [To], Convert( char(10),curleavetime,103) as [Applied On] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  B4Flag='A' and flag='B4' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and  Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "'  " & _
                   "Union SELECT  ID ,Leave AS Nature ,empname AS NAME , Dept AS Department,DAYS ,CONVERT(CHAR(10), leavedate, 103) AS [FROM] ,CONVERT(CHAR(10), leavedate, 103) AS [TO] ,CONVERT(CHAR(10), applied_on, 103) AS [Applied On] FROM    dbo.[jct_empg_compensatory_leave]WHERE   STATUS = 'A' AND authHod = 'A' AND ( Hod = '" & Trim(ECode) & "' OR cc ='" & Trim(ECode) & "')"



        Dim Dr As SqlDataReader = objClassFunction.FetchReader(Sqlpass)
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

        'Dim Sqlpass = "select AutoId as ID ,NatureLeave as Nature,Name,Department, Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ]  from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  AuthFlag='C' and flag='1H' and DateDiff(day,getdate(),CurLeaveTime)>=-20 and Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "'  " & _
        '              "Union select AutoId as ID ,NatureLeave as Nature,Name,Department, Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ]  from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  SubAuthFlag='C' and flag='2T' and  DateDiff(day,getdate(),leavefrom)>=-20 and Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "'  " & _
        '              " Union select AutoId as ID ,NatureLeave as Nature,Name,Department, Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ]  from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and  CFlag='C' and flag='3C' and  DateDiff(day,getdate(),leavefrom)>=-20 and Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null and b.Company_Code='" & Session("Companycode") & "'  order by autoid desc"

        Dim Sqlpass = "Exec jct_empg_leave_cancelled '" + Trim(ECode) + "','" + Session("Companycode") + "'"
        Dim Dr As SqlDataReader = objClassFunction.FetchReader(Sqlpass)
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

        Dim Sqlpass = "select AutoId as ID ,NatureLeave as Nature,Name,Department, Convert( char(10),LeaveFrom,103) as [ From ] , Convert( char(10),LeaveTo,103) as [ To ], Convert( char(10),curleavetime,103) as [ Applied On ] from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b where a.empcode=b.Emp_Code   and flag='B' and  DateDiff(day,getdate(),CurLeaveTime)>=-20 and Resp_emp='" & Trim(ECode) & "' and auth_req='Y' and status is null  and b.Company_Code='" & Session("Companycode") & "'  order by AutoId "
        Dim Dr As SqlDataReader = objClassFunction.FetchReader(Sqlpass)
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
                'e.Row.Cells(1).Text = "<a href='default11.aspx?ID=" & e.Row.DataItem(0) & "'>" & e.Row.DataItem(0) & "</a>"
                'e.Row.Cells(1).Visible = False

                Dim lnkpunch As LinkButton = DirectCast(e.Row.FindControl("lnkPunch"), LinkButton)
                Dim lnkdetail As LinkButton = DirectCast(e.Row.FindControl("lnkDetail"), LinkButton)
                Dim leaveid As String = e.Row.Cells(2).Text
                Dim leavetype As String = e.Row.Cells(3).Text


                If leavetype = "Earned Compensatory Leave" Then
                    lnkpunch.Visible = True
                    lnkdetail.Visible = False
                Else
                    lnkpunch.Visible = False
                    lnkdetail.Visible = True
                End If

            End If

        End If

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lnkpunch As LinkButton = DirectCast(e.Row.FindControl("lnkPunch"), LinkButton)
            Dim lnkdetail As LinkButton = DirectCast(e.Row.FindControl("lnkDetail"), LinkButton)
            Dim leaveid As String = e.Row.Cells(2).Text
            Dim leavetype As String = e.Row.Cells(3).Text


            If leavetype = "Earned Compensatory Leave" Then
                lnkpunch.Visible = True
                lnkdetail.Visible = False
            Else
                lnkpunch.Visible = False
                lnkdetail.Visible = True
            End If

            If DrpLvStatus.Text = "Authorized" Then
                GridView1.HeaderRow.Cells(0).Visible = False
                e.Row.Cells(0).Visible = False
                SqlPass = "Exec jct_empg_leaves_authorized '" + e.Row.DataItem(0).ToString() + "'"
                OnRowDataBind(SqlPass)

            ElseIf DrpLvStatus.Text = "Cancelled" Then

                GridView1.HeaderRow.Cells(0).Visible = False
                e.Row.Cells(0).Visible = False

            End If

            Dim toolTip As String = ""
            toolTip = "<div align=center><IMG width = 90px height = 120px  SRC=" + "../EmployeePortal/EmpImages/" + Trim(Session("Cd")) + ".JPG><br/><font face=verdana  color=red size=0.5>  " & Session("Dg") & " </font></div>"
            e.Row.Attributes.Add("onmouseover", "DisplayTooltip('" + toolTip + "');")
            e.Row.Attributes.Add("onmouseout", "DisplayTooltip('');")

            'e.Row.Attributes.Add("onclick", "ShowEditForm('" + e.Row.DataItem(0) + "');")

            Session("N") = ""
            Session("Dg") = ""
            Session("Dt") = ""
            Session("Cd") = ""

        End If

    End Sub


    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            SqlPass = " select * from jctdev..jct_empg_leave where Autoid='" & e.Row.DataItem(0) & "'"
            OnRowDataBind(SqlPass)
            Dim toolTip As String = ""
            toolTip = "<div align=center><IMG width = 90px height = 120px  SRC=" + "../EmployeePortal/EmpImages/" + Trim(Session("Cd")) + ".JPG><br/><font face=verdana  color=red size=0.5>  " & Session("N") & " <br/>   " & Session("Dt") & " <br/>   " & Session("Dg") & " </font></div>"
            e.Row.Attributes.Add("onmouseover", "DisplayTooltip('" + toolTip + "');")
            e.Row.Attributes.Add("onmouseout", "DisplayTooltip('');")



            Session("N") = ""
            Session("Dg") = ""
            Session("Dt") = ""
            Session("Cd") = ""

        End If
    End Sub
    '---------------------------------------------------------------------------------------
    'With HyperLink Move On Page Default11.azpx for Authorize or Cancel Leave Option
    '---------------------------------------------------------------------------------------
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        If DrpLvStatus.Text = "Pending" Then
            Session("Store") = GridView1.SelectedRow.Cells(2).Text
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
            Mail.SmtpMail.SmtpServer = "EXCHANGE2K7"
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
        Dim Dr As SqlDataReader = objClassFunction.FetchReader(Sqlpass)
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
        Dim Dr As SqlDataReader = objClassFunction.FetchReader(Sqlpass)
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
            objClassFunction.UpdateRecord(sqlpass3)
        ElseIf type = "Office Order" Then
            sqlpass3 = "update jct_empg_order set Auth_flag='A' where usercode='" & user & "' and DeptCode='" & dept & "' and filename='" & filename & "' and FileExt='" & fileext & "' and companycode='JCT00LTD'"
            'Obj.ExecQry(sqlpass3)
            objClassFunction.UpdateRecord(sqlpass3)
        ElseIf type = "Training Material" Then
            sqlpass3 = "update jct_empg_trainee set Auth_flag='A' where usercode='" & user & "' and DeptCode='" & dept & "' and filename='" & filename & "' and FileExt='" & fileext & "' and companycode='JCT00LTD'"
            'Obj.ExecQry(sqlpass3)
            objClassFunction.UpdateRecord(sqlpass3)
        End If

        sqlpass4 = "select e_mailid from mistel where empcode='" & user & "'"
        Dim dr As SqlDataReader = objClassFunction.FetchReader(sqlpass4)
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
            Dim dr As SqlDataReader = objClassFunction.FetchReader(SqlPass)
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

            Mail.SmtpMail.SmtpServer = "EXCHANGE2K7"
            If Too <> "" Then
                Mail.SmtpMail.Send(MailSmpt)
                MailSmpt = Nothing
            End If
        End With

    End Sub
    '-------------------------------------------------------------------Hitesh 28/DEC/2009-------------------------------------------------------
    Public Sub Position()
        Dim Sqlpass = "select Flag,FlagHC  from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and Resp_emp='" & Trim(Session("Empcode")) & "' and auth_req='Y' and AutoId='" & Session("AID") & "' and status is null "
        Dim Dr1 As SqlDataReader = objClassFunction.FetchReader(Sqlpass)
        If Dr1.HasRows = True Then
            While Dr1.Read()
                Session("To") = Dr1.Item("Flag")
                Session("StoreFlag") = Dr1.Item("FlagHC")
            End While
            Dr1.Close()
            Obj.ConClose()
        End If

    End Sub

    Protected Sub cmdauthorize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdauthorize.Click

        If DrpLvStatus.Text = "Pending" Then
            Dim atLeastOneRowDeleted As Boolean = False
            Dim K As Long = 1
            For Each row As GridViewRow In GridView1.Rows

                Dim cb As CheckBox = row.FindControl("CheckBox1")
                If cb IsNot Nothing AndAlso cb.Checked Then
                    atLeastOneRowDeleted = True

                    Dim ID As String = Trim(Replace(Replace(Replace(GridView1.Rows(row.RowIndex).Cells(2).Text, "'", ""), "<a href=default11.aspx?ID=", ""), "</a>", ""))
                    Dim LeaveType As String = GridView1.Rows(row.RowIndex).Cells(3).Text
                    'Dim chk As String

                    'chk = ID.Substring(0, 1)
                    If LeaveType = "Earned Compensatory Leave" Then

                        'chk = ID.Split(">")(0)
                        SqlPass = " exec jct_empg_compL_auth '" + ID + "'"
                        Try
                            Dim cmd As SqlCommand = New SqlCommand(SqlPass, Obj.Connection())
                            cmd.ExecuteNonQuery()
                            'objClassFunction.UpdateRecord(SqlPass)
                        Catch ex As SqlException
                            Dim script2 As String = "alert('" + ex.Message + "');"
                            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script2, True)
                            Return
                        End Try


                    Else

                        SqlPass = " select * from jctdev..jct_empg_leave where Autoid='" & ID & "' " 'Left('" & ID & " ',CharIndex('>','" & ID & " ')-1) "
                        Me.GetFlag(SqlPass)
                        Tot = Session("Check")

                        If Session("Check") <> "" Then
                            Tot = Mid(Session("Check"), Tot.Length - 1, Tot.Length)
                        End If

                        Position()
                        H()
                        T()
                        C()
                        B1()
                        B2()
                        B3()
                        B4()
                        If Tot = Session("To") Then
                            MainFlag()
                        End If

                        FlagUpdate()
                        K = K + 1
                    End If
                End If


            Next
            BindData()
        End If


        'If DrpLvStatus.Text = "Pending" Then
        '    Dim atLeastOneRowDeleted As Boolean = False
        '    Dim K As Long = 1
        '    For Each row As GridViewRow In GridView1.Rows

        '        Dim cb As CheckBox = row.FindControl("CheckBox1")
        '        If cb IsNot Nothing AndAlso cb.Checked Then
        '            atLeastOneRowDeleted = True

        '            Dim ID As String = Trim(Replace(Replace(Replace(GridView1.Rows(row.RowIndex).Cells(1).Text, "'", ""), "<a href=default11.aspx?ID=", ""), "</a>", ""))

        '            SqlPass = " select * from jctdev..jct_empg_leave where Autoid=Left('" & ID & " ',CharIndex('>','" & ID & " ')-1) "
        '            Me.GetFlag(SqlPass)
        '            Tot = Session("Check")

        '            If Session("Check") <> "" Then
        '                Tot = Mid(Session("Check"), Tot.Length - 1, Tot.Length)
        '            End If

        '            Position()
        '            H()
        '            T()
        '            C()
        '            B1()
        '            B2()
        '            B3()
        '            B4()
        '            If Tot = Session("To") Then
        '                MainFlag()
        '            End If

        '            FlagUpdate()



        '            K = K + 1
        '        End If
        '    Next
        '    BindData()
        'End If

    End Sub

    Protected Sub cmdcancle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdcancle.Click
        If DrpLvStatus.Text = "Pending" Then
            Dim atLeastOneRowDeleted As Boolean = False
            Dim K As Long = 1
            For Each row As GridViewRow In GridView1.Rows

                Dim cb As CheckBox = row.FindControl("CheckBox1")
                If cb IsNot Nothing AndAlso cb.Checked Then
                    atLeastOneRowDeleted = True

                    Dim ID As String = Trim(Replace(Replace(Replace(GridView1.Rows(row.RowIndex).Cells(2).Text, "'", ""), "<a href=default11.aspx?ID=", ""), "</a>", ""))
                    Dim LeaveType As String = GridView1.Rows(row.RowIndex).Cells(3).Text
                    'Dim chk As String

                    'chk = ID.Substring(0, 1)
                    If LeaveType = "Earned Compensatory Leave" Then

                        'chk = ID.Split(">")(0)
                        SqlPass = "exec jct_empg_compL_cancel  '" + ID + "','" + Session("Empcode") + "'"
                        objClassFunction.UpdateRecord(SqlPass)
                    Else

                        SqlPass = " select * from jctdev..jct_empg_leave where Autoid= '" + ID + "'" 'Left('" & ID & " ',CharIndex('>','" & ID & " ')-1) "
                        GetFlag(SqlPass)
                        Tot = Session("Check")

                        If Session("Check") <> "" Then
                            Tot = Mid(Session("Check"), Tot.Length - 1, Tot.Length)
                        End If

                        Position()
                        HCancle()
                        TCancle()
                        CCancle()
                        B1Cancle()
                        B2Cancle()
                        B3Cancle()
                        B4Cancle()

                        CancelMail()


                        K = K + 1
                    End If
                End If

            Next
            BindData()
        End If

    End Sub
    Public Sub H()
        If Session("To") = "1H" Then
            SqlPass = "update  jctdev..jct_empg_leave set AutHodTime= getdate() ,AuthFlag='A' where  autoid= " & Session("AID")
            objClassFunction.UpdateRecord(SqlPass)
            'Response.Redirect("MyWorkArae.aspx")
        End If
    End Sub

    Public Sub T()
        If Session("To") = "2T" Then
            SqlPass = "update  jctdev..jct_empg_leave set SubAutHodTime= getdate() ,SubAuthFlag='A'  where  autoid= " & Session("AID")
            objClassFunction.UpdateRecord(SqlPass)
            'Response.Redirect("MyWorkArae.aspx")
        End If
    End Sub
    Public Sub C()
        If Session("To") = "3C" Then
            SqlPass = "update  jctdev..jct_empg_leave set CTime= getdate() ,CFlag='A'  where  autoid= " & Session("AID")
            objClassFunction.UpdateRecord(SqlPass)
            'Response.Redirect("MyWorkArae.aspx")
        End If
    End Sub
    Public Sub B1()
        If Session("To") = "B1" Then
            SqlPass = "update  jctdev..jct_empg_leave set B1Time= getdate() ,B1Flag='A'  where  autoid= " & Session("AID")
            objClassFunction.UpdateRecord(SqlPass)
        End If
    End Sub
    Public Sub B2()
        If Session("To") = "B2" Then
            SqlPass = "update  jctdev..jct_empg_leave set B2Time= getdate() ,B2Flag='A' where  autoid= " & Session("AID")
            objClassFunction.UpdateRecord(SqlPass)
            '  Response.Redirect("MyWorkArae.aspx")
        End If
    End Sub
    Public Sub B3()
        If Session("To") = "B3" Then
            SqlPass = "update  jctdev..jct_empg_leave set B3Time= getdate() ,B3Flag='A' where  autoid= " & Session("AID")
            objClassFunction.UpdateRecord(SqlPass)
            ' Response.Redirect("MyWorkArae.aspx")
        End If
    End Sub

    Public Sub B4()
        If Session("To") = "B4" Then
            SqlPass = "update  jctdev..jct_empg_leave set B4Time= getdate() ,B4Flag='A' where  autoid= " & Session("AID")
            objClassFunction.UpdateRecord(SqlPass)
            ' Response.Redirect("MyWorkArae.aspx")
        End If
    End Sub

    Public Sub MainFlag()
        SqlPass = "update  jctdev..jct_empg_leave set Mainflag='A' , LastTime=getdate() where  autoid= " & Session("AID")
        objClassFunction.UpdateRecord(SqlPass)
    End Sub

    Public Sub FlagUpdate()

        Dim sm As New SendMail

        If Session("StoreFlag") <> "" Then
            If Len(Session("StoreFlag")) > 2 Then
                SqlPass = "update jctdev..jct_empg_leave set FlagHC='" & Right(Session("StoreFlag"), Len(Session("StoreFlag")) - 3) & "' where  autoid= " & Session("AID")
                objClassFunction.UpdateRecord(SqlPass)
            Else
                SqlPass = "update jctdev..jct_empg_leave set FlagHC='" & Right(Session("StoreFlag"), Len(Session("StoreFlag")) - 2) & "' where  autoid= " & Session("AID")
                objClassFunction.UpdateRecord(SqlPass)

                '''''' To Send SMS to the employee to intimate him/her about the leave authorised by his/her top level HOD

                SqlPass = "select a.empcode, c.empname, b.mobile, a.natureleave, a.days, replace(convert(varchar(11),a.leavefrom,106),' ','-') as [leavefrom], " & _
                            "replace(convert(varchar(11), a.leaveto,106),' ','-') as [leaveto] from jct_empg_leave a inner join mistel b on a.empcode = b.empcode " & _
                            "inner join jct_empmast_base c on b.empcode = c.empcode where a.autoid = " & Session("AID") & " And b.mobile Is Not null And Len(b.mobile) = 10"
                Dim dr As SqlDataReader = objClassFunction.FetchReader(SqlPass)
                Try

                    If dr.HasRows Then
                        dr.Read()

                        Dim msg As String = ""
                        If dr("leavefrom").ToString <> dr("leaveto").ToString Then
                            msg = "Dear " & dr("empname") & ", your " & dr("natureleave") & " for " & dr("days") & " day(s) dated from " & dr("leavefrom") & " to " & dr("leaveto") & " has been authorised."
                        ElseIf dr("leavefrom").ToString = dr("leaveto").ToString Then
                            msg = "Dear " & dr("empname") & ", your " & dr("natureleave") & " for " & dr("days") & " day(s) dated " & dr("leavefrom") & " has been authorised."
                        End If
                        '   Dim sm As New SendMail
                        sm.SendSMS(Session("CompanyCode"), "Sys", dr("mobile"), msg, "Leave Authorisation")



                    End If

                Catch ex As Exception
                Finally
                    dr.Close()
                    Obj.ConClose()
                End Try
                ''''''

            End If
        Else

            ClientScript.RegisterClientScriptBlock(Me.GetType, "Potttr", "<script language = javascript>alert('Session Expired ,Please Login again to apply leave.!!')</script>")
        End If

    End Sub

    Public Sub HCancle()
        If Session("To") = "1H" Then
            SqlPass = "update  jctdev..jct_empg_leave set AutHodTime= getdate() ,AuthFlag='C',MainFlag='C',FlagHC='', LastTime=getdate() where  autoid= " & Session("AID")
            objClassFunction.UpdateRecord(SqlPass)
            'Response.Redirect("MyWorkArae.aspx")
        End If

    End Sub

    Public Sub TCancle()
        If Session("To") = "2T" Then
            SqlPass = "update jctdev..jct_empg_leave set SubAutHodTime= getdate() ,SubAuthFlag='C',MainFlag='C',FlagHC='' , LastTime=getdate() where  autoid= " & Session("AID")
            objClassFunction.UpdateRecord(SqlPass)
            ' Response.Redirect("MyWorkArae.aspx")
        End If
    End Sub
    Public Sub CCancle()
        If Session("To") = "3C" Then
            SqlPass = "update  jctdev..jct_empg_leave set CTime= getdate() ,CFlag='C',MainFlag='C',FlagHC='' , LastTime=getdate() where  autoid= " & Session("AID")
            objClassFunction.UpdateRecord(SqlPass)
            'Response.Redirect("MyWorkArae.aspx")
        End If
    End Sub
    Public Sub B1Cancle()
        If Session("To") = "B1" Then
            SqlPass = "update  jctdev..jct_empg_leave set CTime= getdate() ,CFlag='C',MainFlag='C',FlagHC='' , LastTime=getdate() where  autoid= " & Session("AID")
            objClassFunction.UpdateRecord(SqlPass)
            'Response.Redirect("MyWorkArae.aspx")
        End If
    End Sub
    Public Sub B2Cancle()
        If Session("To") = "B2" Then
            SqlPass = "update  jctdev..jct_empg_leave set CTime= getdate() ,CFlag='C',MainFlag='C',FlagHC='' , LastTime=getdate() where  autoid= " & Session("AID")
            objClassFunction.UpdateRecord(SqlPass)
            'Response.Redirect("MyWorkArae.aspx")
        End If
    End Sub
    Public Sub B3Cancle()
        If Session("To") = "B3" Then
            SqlPass = "update  jctdev..jct_empg_leave set CTime= getdate() ,CFlag='C',MainFlag='C',FlagHC='' , LastTime=getdate() where  autoid= " & Session("AID")
            objClassFunction.UpdateRecord(SqlPass)
            'Response.Redirect("MyWorkArae.aspx")
        End If
    End Sub
    Public Sub B4Cancle()
        If Session("To") = "B4" Then
            SqlPass = "update  jctdev..jct_empg_leave set CTime= getdate() ,CFlag='C',MainFlag='C',FlagHC='' , LastTime=getdate() where  autoid= " & Session("AID")
            objClassFunction.UpdateRecord(SqlPass)
            'Response.Redirect("MyWorkArae.aspx")
        End If
    End Sub

    Public Sub CancelMail()
        'Code of cancelmail()  has been  updated by Mr.Ramandeep singh
        'Date:4th may 2009
        'Reason:Mail of canceled leave is not going to persons added in bcc and cc.
        'Result:Mail of canceled leave will send to persons added in bcc ,cc and to
        Dim Client As New Net.Mail.SmtpClient
        Dim Message As New Net.Mail.MailMessage
        Message.IsBodyHtml = True
        '------------------------------------
        ob.opencn()
        SqlPass = "select empcode from jct_empg_leave where Autoid='" & Session("AID") & "' and companycode='" & Session("Companycode") & "' "
        cmd = New SqlCommand(SqlPass, ob.cn)
        cmd.CommandTimeout = 0
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()
            empcode_to = dr(0)
        End If
        dr.Close()

        '-------------------Mr_mrs From-------------------

        SqlPass = "select mr_mrs,empname,desg from jct_empmast_base where empcode='" & Session("Empcode") & "' and company_code='" & Session("Companycode") & "'"
        cmd = New SqlCommand(SqlPass, ob.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()
            Mr_Mrs = dr(0)
            empname = dr(1)
            designation = dr(2)
        End If
        dr.Close()
        '---------------------------------
        With Message

            '-------------------------email id for To'---------------------------------------------
            SqlPass = "select e_mailid,name from mistel where empcode='" & empcode_to & "' and company_code='" & Session("Companycode") & "'"
            '
            cmd = New SqlCommand(SqlPass, ob.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                EmailTO = dr.Item(0)
                to_name = dr.Item(1)
                Message.To.Add(EmailTO)
            Else
                EmailTO = "dummy@jctltd.com"
                Message.To.Add(EmailTO)
            End If


            dr.Close()

            '--------------------------------------------------------------------------

            '-------------------Mr_mrs To-------------------

            SqlPass = "select mr_mrs,empname,desg from jct_empmast_base where empcode='" & empcode_to & "' and company_code='" & Session("Companycode") & "'"
            cmd = New SqlCommand(SqlPass, ob.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                Mr_Mrs_to = dr(0)
            End If
            dr.Close()
            '---------------------------------

            'Send message for CC
            '------------------------------------------------------------------------------------------------------------------------------

            Dim SqlPass1 = "SELECT e_mailid from JCTDEV..JCT_EMP_HOD a, JCTDEV..MISTEL b WHERE b.EmpCode= a.Resp_Emp and  emp_code='" & empcode_to & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') and status is null AND Auth_Req='Y'and Days=0 and a.company_code='" & Session("Companycode") & "' and b.company_code='" & Session("Companycode") & "'  UNION SELECT e_mailid from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & empcode_to & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') and status is null AND Auth_Req='Y'and days between 0 and '" & Session("Days") & "' and a.company_code='" & Session("Companycode") & "' and b.company_code='" & Session("Companycode") & "'  "
            Dim Dr1 As SqlDataReader = objClassFunction.FetchReader(SqlPass1)

            If Dr1.HasRows = True Then
                While Dr1.Read()
                    If Not (Dr1.Item(0) Is System.DBNull.Value) Then
                        Emailcc = Dr1.Item(0)
                        Message.CC.Add(Emailcc)
                    End If
                End While
                Dr1.Close()
                'Else
                '    ClientScript.RegisterClientScriptBlock(Me.GetType, "Potttr", "<script language = javascript>alert('No any Email Id, Please Contact With IT')</script>")
                '    Dr.Close()
                '    Obj.ConClose()
                '    Exit Sub
            End If


            '------------------------------------------------------------------------------------------------------------------------------

            'Send the Bcc
            '------------------------------------------------------------------------------------------------------------------------------

            Dim SqlPass2 = "SELECT e_mailid from jctdev..jct_emp_hod a,JCTDEV..mistel b WHERE  b.empcode=a.resp_emp AND emp_code='" & empcode_to & "' and flag in('B') AND Auth_Req='Y' and status is null and a.company_code='" & Session("Companycode") & "' and b.company_code='" & Session("Companycode") & "'"
            Dim Dr2 As SqlDataReader = objClassFunction.FetchReader(SqlPass2)

            If Dr2.HasRows = True Then
                While Dr2.Read()
                    If Not (Dr2.Item(0) Is System.DBNull.Value) Then
                        EmailBcc = Dr2.Item(0)
                        Message.Bcc.Add(EmailBcc)
                    End If
                End While
                Dr2.Close()
            End If

            '----------------------------------------------------------------------------------------------------------------------

            'Send message for From
            '------------------------------------------------------------------------------------------------------------------------------


            SqlPass = "SELECT e_mailid from MISTEL  WHERE empcode='" & Session("Empcode") & "' and company_code='" & Session("Companycode") & "' "
            cmd = New SqlCommand(SqlPass, ob.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                EmailFrom = dr.Item(0)

            Else
                EmailFrom = "dummy@jctltd.com"

            End If
            dr.Close()
            Dim From As New Net.Mail.MailAddress(EmailFrom)
            Message.From = From

            '------------------------------------------------------------------------------------------------------------------------------
            '--------------------------------------------------------------------------
            '.Body = "Your leave has been canceled by " & Session("Empcode") & ".Autoid of leave is " & Request.QueryString.Get("ID")
            .Body = "Leave of " & Mr_Mrs_to & " " & to_name & " has been canceled by " & Mr_Mrs & " " & empname & " Emp code:-" & Session("Empcode") & ".Autoid of leave is " & Session("AID") & "." & "<br/><br/><br/><br/><br/><br/><br/>  DISCLAIMER: This email has been generated through Employee Gateway Package. <br/>Kindly do not reply as you will not receive a response. "
            .Subject = "Leave of " & Mr_Mrs_to & " " & to_name & " has been  canceled by " & Mr_Mrs & " " & empname & " Emp code=" & Session("Empcode")

            Client.Host = "EXCHANGE2K7"
            Client.Port = 25
            Client.Send(Message)
            Dim sm As New SendMail

            '------------------ To Send SMS for leave cance-----------------

            SqlPass = "select a.empcode, c.empname, b.mobile, a.natureleave, a.days, replace(convert(varchar(11),a.leavefrom,106),' ','-') as [leavefrom], " & _
                            "replace(convert(varchar(11), a.leaveto,106),' ','-') as [leaveto] from jct_empg_leave a inner join mistel b on a.empcode = b.empcode " & _
                            "inner join jct_empmast_base c on b.empcode = c.empcode where a.autoid = " & Session("AID") & " And b.mobile Is Not null And Len(b.mobile) = 10"
            Dim dr3 As SqlDataReader
            Try
                dr3 = objClassFunction.FetchReader(SqlPass)
                If dr3.HasRows Then
                    dr3.Read()

                    Dim msg As String = ""
                    If dr3("leavefrom").ToString <> dr3("leaveto").ToString Then
                        msg = "Dear " & dr3("empname") & ", your " & dr3("natureleave") & " for " & dr3("days") & " day(s) dated from " & dr3("leavefrom") & " to " & dr3("leaveto") & " has been cancelled."
                    ElseIf dr3("leavefrom").ToString = dr3("leaveto").ToString Then
                        msg = "Dear " & dr3("empname") & ", your " & dr3("natureleave") & " for " & dr3("days") & " day(s) dated " & dr3("leavefrom") & " has been cancelled."
                    End If

                    sm.SendSMS(Session("CompanyCode"), "Sys", dr3("mobile"), msg, "Leave Cancellation")

                End If

            Catch ex As Exception
            Finally
                dr3.Close()

            End Try

            '----------------------

        End With
        ob.closecn()

    End Sub
    '--------------------------------------------------------------------------------------------------------------------------------------------
    'Check/Uncheck/Authorized

    Private Sub ToggleCheckState(ByVal checkState As Boolean)

        For Each row As GridViewRow In GridView1.Rows
            Dim cb As CheckBox = row.FindControl("Checkbox1")
            If cb IsNot Nothing Then
                cb.Checked = checkState
            End If
        Next

    End Sub

    Protected Sub CmdCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdCheck.Click
        If DrpLvStatus.Text = "Pending" Then
            ToggleCheckState(True)
        End If
    End Sub


    Protected Sub UnCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UnCheck.Click
        If DrpLvStatus.Text = "Pending" Then
            ToggleCheckState(False)
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------------

    Public Sub GetFlag(ByVal SqlPass As String)
        Dim Dr2 As SqlDataReader
        Dr2 = objClassFunction.FetchReader(SqlPass)
        If Dr2.HasRows = True Then
            While Dr2.Read()
                AId = Dr2.Item("AutoId")
                Session("Check") = Trim(Dr2.Item("FlagHC"))
                Session("AID") = AId
                Session("Days") = Trim(Dr2.Item("Days"))
            End While
            Dr2.Close()
            Obj.ConClose()
        End If

    End Sub

    Public Sub OnRowDataBind(ByVal SqlPass As String)
        Dim Dr As SqlDataReader = objClassFunction.FetchReader(SqlPass)
        If Dr.HasRows = True Then

            While Dr.Read()
                Session("N") = Dr.Item("Name")
                Session("Dg") = Dr.Item("Designation")
                Session("Dt") = Dr.Item("Department")
                Session("Cd") = Dr.Item("Cardno")
            End While
            Dr.Close()
            Obj.ConClose()
        End If

    End Sub

    Public Sub Guest()
        ob.opencn()
        If Me.ddlGuest.Text = "P" Then
            qry = "select TRANSACTIONNO as ID ,EMPCODE as EMPCODE, employeee_name AS [Employee Name],CONVERT(VARCHAR(12),CREATEDDT,101) AS [Applied on] from JCT_EMP_GUESTHOUSE a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code   and flag=left(FlagHC,2) and Resp_emp='" & Trim(ECode) & "' and authFLAG='P' and a.status is null and b.Company_Code='" & Session("Companycode") & "'  and b.status is null order by transactionno "
        ElseIf ddlGuest.SelectedValue = "A" Then
            qry = "select TRANSACTIONNO as ID ,EMPCODE as EMPCODE, employeee_name AS [Employee Name],CONVERT(VARCHAR(12),CREATEDDT,101) as [Applied on] from JCT_EMP_GUESTHOUSE a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code   and flag='1H' and Resp_emp='" & Session("Empcode") & "' and authFLAG='A' and a.status is null and b.Company_Code='" & Session("Companycode") & "' and b.status is null order by transactionno "
        ElseIf (ddlGuest.SelectedValue = "C") Then
            qry = "select TRANSACTIONNO as ID ,EMPCODE as EMPCODE, employeee_name AS [Employee Name],CONVERT(VARCHAR(12),CREATEDDT,101) as [Applied on] from JCT_EMP_GUESTHOUSE a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code   and flag='1H' and Resp_emp='" & Session("Empcode") & "' and authFLAG='C' and a.status is null and b.Company_Code='" & Session("Companycode") & "' and b.status is null order by transactionno "
        End If

        Dim Dr As SqlDataReader = objClassFunction.FetchReader(qry)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(qry, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                Session("Authorize") = 1
                ds.Clear()
                Da.Fill(ds)
                GridGuest.DataSource = ds
                GridGuest.DataBind()
                Dr.Close()
            Else
                GridGuest.DataSource = Nothing
                GridGuest.DataBind()
            End If
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try
    End Sub

    Protected Sub GridGuest_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridGuest.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Me.ddlGuest.Text = "P" Then
                e.Row.Cells(0).Text = "<a href='GuestHouseReq.aspx?Reply=1&Guest=" & e.Row.DataItem(0) & "'>" & e.Row.DataItem(0) & "</a>"
            ElseIf ddlGuest.SelectedValue = "A" Then
                e.Row.Cells(0).Text = "<a href='GuestHouseReq.aspx?Reply=2&Guest=" & e.Row.DataItem(0) & "'>" & e.Row.DataItem(0) & "</a>"
            ElseIf (ddlGuest.SelectedValue = "C") Then
                e.Row.Cells(0).Text = "<a href='GuestHouseReq.aspx?Reply=2&Guest=" & e.Row.DataItem(0) & "'>" & e.Row.DataItem(0) & "</a>"
            End If
            'e.Row.Cells[1].Text = "<a href='www.yahoo.com'>" + ((DataRowView)e.Row.DataItem)["Name"] + "</a>";
            ' e.Row.Cells(0).Text = "<a href='taskmanagement.aspx>" & e.Row.DataItem(0) & "</a>"
            ' e.Row.Cells(1).Text = "<a href='TaskManagement.aspx'>" & CType(e.Row.DataItem, DataRowView)(1) & "</a>"
        End If
    End Sub

    Protected Sub ddlGuest_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGuest.SelectedIndexChanged
        Guest()
    End Sub


    Public Sub GetTransportationRequisitions()
        'Dim Sqlpass = "select Survey_No ,Subject,user_Code PostedBy,Dept_code,Last_Date from jct_emp_survey_Master where  Last_Date>getdate()" ' a.empcode=b.Emp_Code and  SubAuthFlag='OK' and flag='C' and DateDiff(day,getdate(),CurLeaveTime)>=-45 and  Resp_emp='" & Trim(ECode) & "' order by AutoId "
        Dim Sqlpass As String = ""
        If UCase(Session("Empcode")) = "R-03339" Then
            If ddlTransPortation.SelectedItem.Value = "P" Then
                Sqlpass = "SELECT AutoID,b.FullName AS RequestBy,Place AS PlaceToVisit,Purpose,No_of_Persons,Vehicle_Prefrence AS Requested_Vehicle,Convert(varchar,OnDate,101) as OnDate,OnTime AS At,ReportPlace AS MadeAvailableAt ,convert(varchar,ReturnDate,101) as ReturnDate,ReturnTime FROM jct_emp_transport_request a,dbo.Jct_Epor_Master_Employee b WHERE a.Status<>'D'  AND b.Status='A' and a.UserCode=b.Emp_Code AND GETDATE() BETWEEN Eff_From AND Eff_To and a.companycode=b.company_code and a.companycode='" & Session("Companycode") & "' and AuthFlag='P'  ORDER BY AutoID"
                'Dim Dr As SqlDataReader = Obj.FetchReader(Sqlpass)
                'Dim Da As SqlDataAdapter = New SqlDataAdapter(Sqlpass, Obj.Connection())

                'Try
                '    If Dr.HasRows = True Then
                '        Dr.Close()
                '        Dim ds As DataSet = New DataSet()
                '        ds.Clear()
                '        Da.Fill(ds)
                '        GrdTransport.DataSource = ds
                '        GrdTransport.DataBind()
                '        Dr.Close()
                '    Else
                '        GrdTransport.DataSource = Nothing
                '        GrdTransport.DataBind()
                '    End If
                'Catch ex As Exception
                'Finally
                '    Obj.ConClose()
                'End Try
            ElseIf ddlTransPortation.SelectedItem.Value = "A" Then
                Sqlpass = "SELECT AutoID,b.FullName AS RequestBy,Place AS PlaceToVisit,Purpose,No_of_Persons,Vehicle_Prefrence AS Requested_Vehicle,Convert(varchar,OnDate,101) as OnDate,OnTime AS At,ReportPlace AS MadeAvailableAt ,convert(varchar,ReturnDate,101) as ReturnDate,ReturnTime FROM jct_emp_transport_request a,dbo.Jct_Epor_Master_Employee b WHERE a.Status<>'D' AND AuthFLAG='A' AND b.Status='A' and a.UserCode=b.Emp_Code AND GETDATE() BETWEEN Eff_From AND Eff_To and a.companycode=b.company_code and a.companycode='" & Session("Companycode") & "' ORDER BY AutoID"
            End If
            Dim Dr As SqlDataReader = objClassFunction.FetchReader(Sqlpass)
            Dim Da As SqlDataAdapter = New SqlDataAdapter(Sqlpass, Obj.Connection())
            Try
                If Dr.HasRows = True Then
                    Dr.Close()
                    Dim ds As DataSet = New DataSet()
                    ds.Clear()
                    Da.Fill(ds)
                    GrdTransport.DataSource = ds
                    GrdTransport.DataBind()
                    Dr.Close()
                Else
                    GrdTransport.DataSource = Nothing
                    GrdTransport.DataBind()
                End If
            Catch ex As Exception
            Finally
                Obj.ConClose()
            End Try
        End If
    End Sub


    Protected Sub GrdTransport_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdTransport.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Text = "<a href='TransportRequisition.aspx?AutoID=" & e.Row.DataItem(0) & "'>" & e.Row.DataItem(0) & " </a>"
        End If
    End Sub

    Protected Sub ddlTransPortation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTransPortation.SelectedIndexChanged
        GetTransportationRequisitions()
    End Sub


    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim Checkbox1 As CheckBox = DirectCast(sender, CheckBox)
        'Dim GridView1 As GridViewRow = DirectCast(Checkbox1.Parent.Parent, GridViewRow)
        'If Checkbox1.Checked Then
        '    GridView1.Attributes.Remove("OnClick")
        'End If


    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand

        'Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, LinkButton).NamingContainer, GridViewRow)

        'Dim index As Integer = row.RowIndex

        ''Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        'Dim lnkpunch As LinkButton = DirectCast(GridView1.Rows(index).FindControl("lnkPunch"), LinkButton)
        'Dim lnkdetail As LinkButton = DirectCast(GridView1.Rows(index).FindControl("lnkDetail"), LinkButton)
        'Dim leaveid As String = GridView1.Rows(index).Cells(2).Text

        'If (e.CommandName = "popup") Then

        '    lnkpunch.Attributes.Add("onclick", "ShowEditForm('" + leaveid + "');return false;")

        'ElseIf (e.CommandName = "detail") Then

        '    Response.Redirect("default11.aspx?ID=" + leaveid)

        'End If
    End Sub

    Private Sub sendmail(ByVal ID As String)

        Dim from As String = Nothing
        Dim [to] As String = Nothing
        Dim bcc As String = Nothing
        Dim cc As String = Nothing
        Dim subject As String = Nothing
        Dim body As String = Nothing
        Dim sql As String = Nothing


        sql = "Select a.empname,b.e_mailid as email from jct_empmast_base a ( NOLOCK ) left outer join mistel b  ( NOLOCK ) on a.empcode=b.empcode where a.empcode='" + Session("Empcode").ToString() + "'"
        Dim cmd As New SqlCommand(sql, Obj.Connection)


        Dim Dr As SqlDataReader = cmd.ExecuteReader()
        If Dr.HasRows Then
            While Dr.Read()
                ViewState("lastAuthby") = Dr("empname").ToString()
                ViewState("lastauthEmail") = Dr("email").ToString()
            End While
        Else
            ViewState("RequestBy") = ""
            ViewState("RequestByEmail") = "jatindutta@jctltd.com"
        End If

        Dr.Close()
        Obj.ConClose()

        Dim sb As New StringBuilder()

        sb.AppendLine("<html>")
        sb.AppendLine("<head>")
        sb.AppendLine("<style type=""text/css"">")
        sb.AppendLine("table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}")
        sb.AppendLine("table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}")
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}")
        sb.AppendLine("</style>")
        sb.AppendLine("</head>")

        sb.AppendLine("Hi,<br/>")
        sb.AppendLine("Compensatory leave has been authorized by : " + ViewState("lastAuthby") + "  and is now pending at your end.<br/><br/>")

        'sb.AppendLine("RequestID for your request is : " + ViewState("RequestID") + " <br/><br/>")
        'sb.AppendLine("Request is Pending at R&D Dept <br/><br/>")


        sb.AppendLine("Details are Shown below : <br/><br/>")
        sb.AppendLine("<table class=gridtable>")

        sql = "jct_empg_mail_content"
        cmd = New SqlCommand(sql, Obj.Connection)
        Obj.ConOpen()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("ID", SqlDbType.Int).Value = ID
        Dr = cmd.ExecuteReader()
        If (Dr.HasRows) Then
            While (Dr.Read())
                sb.AppendLine("<tr><td colspan='2'><b>LeaveID</b></td> <td colspan='2'>" + ID + "</td></tr>")
                sb.AppendLine("<tr><td colspan='2'> <b>Applied By</b></td> <td colspan='2'>" + Dr("applied by").ToString() + "</td></tr>")
                sb.AppendLine("<tr><td colspan='2'><b> Department</b> </td> <td colspan='2'>" + Dr("Dept").ToString() + "</td></tr>")
                sb.AppendLine("<tr><td colspan='2'><b> Leave</b> </td> <td colspan='2'>" + Dr("leave").ToString() + "</td></tr>")
                sb.AppendLine("<tr><td colspan='2'> <b>Leave Date</b> </td> <td colspan='2'>" + Dr("leavedate").ToString() + "</td></tr>")
                sb.AppendLine("<tr><td colspan='2'><b> Days </b></td> <td colspan='2'>" + Dr("Days").ToString() + "</td></tr>")


            End While
        End If

        Dr.Close()
        Obj.ConClose()
        sb.AppendLine("</table>")

        sb.AppendLine("<br /><br/>")





        sb.AppendLine("</table><br />")

        sb.AppendLine("This is a system generated mail and sent through OPS online mail management system. Please donot reply.<br/> <br/>")
        sb.AppendLine("Thank you<br />")
        sb.AppendLine("</html>")


        body = sb.ToString()
        from = "noreply@jctltd.com"

        '[to] = "shwetalorai@jctltd.com"
        [to] = ViewState("PendingAtEmail").ToString() + "," + ViewState("RequestByEmail").ToString()

        'bcc = "rajan@jctltd.com,rbaksshi@jctltd.com,shwetaloria@jctltd.com"
        bcc = "shwetaloria@jctltd.com,jatindutta@jctltd.com"
        subject = "Pending Leave Approval -  " + ID
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

        mail.Subject = subject
        mail.Body = body
        mail.IsBodyHtml = True
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
        Dim SmtpMail As New SmtpClient("EXCHANGE2K7")


        SmtpMail.Send(mail)


    End Sub

    Protected Sub lnkPunch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim lnkPunch As LinkButton = DirectCast(sender, LinkButton)
        Dim gridviewrow As GridViewRow = DirectCast(lnkPunch.Parent.Parent, GridViewRow)


        Dim ID As String = gridviewrow.Cells(2).Text
        Dim Nature As String = gridviewrow.Cells(3).Text
        Dim Name As String = gridviewrow.Cells(4).Text
        Dim Department As String = gridviewrow.Cells(5).Text
        Dim Days As String = gridviewrow.Cells(6).Text
        Dim Fromdate As DateTime = DateTime.ParseExact(gridviewrow.Cells(7).Text, "dd/MM/yyyy", Nothing) 'Convert.ToDateTime(gridviewrow.Cells(7).Text)
        Dim Todate As DateTime = DateTime.ParseExact(gridviewrow.Cells(8).Text, "dd/MM/yyyy", Nothing) 'Convert.ToDateTime(gridviewrow.Cells(8).Text)
        Dim AppliedOn As String = DateTime.ParseExact(gridviewrow.Cells(9).Text, "dd/MM/yyyy", Nothing) 'Convert.ToDateTime(gridviewrow.Cells(9).Text)

        lnkPunch.Attributes.Add("onclick", "ShowEditForm('" + ID + "');return false;")
    End Sub


    Protected Sub lnkDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim lnkDetail As LinkButton = DirectCast(sender, LinkButton)
        Dim gridRow As GridViewRow = DirectCast(lnkDetail.Parent.Parent, GridViewRow)

        Dim ID As String = gridRow.Cells(2).Text
        Response.Redirect("default11.aspx?ID=" + ID)

    End Sub


End Class
'\\test2k\webapplication old 16/Sep/2008 old code have not with satus
' now with status