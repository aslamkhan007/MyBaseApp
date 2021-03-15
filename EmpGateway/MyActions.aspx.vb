Imports System.Data.SqlClient
Partial Class Default6
    Inherits System.Web.UI.Page
    Public ob As New HelpDeskClass
    Public cmd As New SqlCommand
    Public qry As String
    Dim i As Integer
    Public dr As SqlDataReader
    Dim cl(70) As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("Empcode").ToString <> "") Then
            'empcode = Session("Empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If
        If IsPostBack = False Then
            Me.PnlExtTasks.Collapsed = True
            Me.PnlIntTasks.Collapsed = True
            Me.PnlAssgnBy.Collapsed = True
            MyTasks()
            MyIntTasks()
            AssgnByMe()
        End If
    End Sub
    Public Sub MyTasks()
        Dim ds As New Data.DataSet
        Dim drow As Data.DataRow
        Dim dt As New Data.DataTable

        Dim cust As String = ""
        Dim sp As String = ""
        ob.opencn()
        If Trim(Me.DrpLvStatus.Text) = "Pending" Then
            qry = "select distinct a.Task_No,SubArea,c.empname,a.subject, a.task_status,a.task_priority, case when a.due_date='01/01/1900' then '' else convert(varchar(10),a.due_date,103) end as duedate from jct_task_log a, JCT_Task_Recepients b, jct_empmast_base c, jct_empmast_base d where a.task_no=b.task_no and rtrim(a.emp_code)=rtrim(c.empcode)and rtrim(b.recp_code)=rtrim(d.empcode) and c.deptcode<>d.deptcode and status in ('','R') and b.flag in('T') and b.recp_code='" & Session("Empcode") & "' and authorize<>'y' and task_status not in ('Closed','Completed','Re Assigned') order by a.task_no desc"
        ElseIf Trim(Me.DrpLvStatus.Text) = "ReAssigned" Then
            qry = "select distinct a.Task_No,SubArea,c.empname,a.subject, a.task_status,a.task_priority, case when a.due_date='01/01/1900' then '' else convert(varchar(10),a.due_date,103) end as duedate from jct_task_log a, JCT_Task_Recepients b, jct_empmast_base c, jct_empmast_base d where a.task_no=b.task_no and rtrim(a.emp_code)=rtrim(c.empcode)and rtrim(b.recp_code)=rtrim(d.empcode) and c.deptcode<>d.deptcode and status in ('') and b.flag in('T') and b.recp_code='" & Session("Empcode") & "' and authorize<>'y' and task_status='Re Assigned' order by a.task_no desc"
        ElseIf Trim(Me.DrpLvStatus.Text) = "Completed" Then
            qry = "select distinct a.Task_No,SubArea,c.empname,a.subject, a.task_status,a.task_priority, case when a.due_date='01/01/1900' then '' else convert(varchar(10),a.due_date,103) end as duedate from jct_task_log a, JCT_Task_Recepients b, jct_empmast_base c, jct_empmast_base d where a.task_no=b.task_no and rtrim(a.emp_code)=rtrim(c.empcode)and rtrim(b.recp_code)=rtrim(d.empcode) and c.deptcode<>d.deptcode and status in ('','R') and b.flag in('T') and b.recp_code='" & Session("Empcode") & "' and authorize<>'y' and task_status in ('Closed','Completed') order by a.task_no desc"
        ElseIf Trim(Me.DrpLvStatus.Text) = "Closed" Then
            qry = "select distinct a.Task_No,SubArea,c.empname,a.subject, a.task_status,a.task_priority, case when a.due_date='01/01/1900' then '' else convert(varchar(10),a.due_date,103) end as duedate from jct_task_log a, JCT_Task_Recepients b, jct_empmast_base c, jct_empmast_base d where a.task_no=b.task_no and rtrim(a.emp_code)=rtrim(c.empcode)and rtrim(b.recp_code)=rtrim(d.empcode) and c.deptcode<>d.deptcode and status in ('','R','C') and b.flag in('T') and b.recp_code='" & Session("Empcode") & "' and  authorize='y' order by a.task_no desc"
        Else
            qry = "select distinct a.Task_No,SubArea,c.empname,a.subject, a.task_status,a.task_priority, case when a.due_date='01/01/1900' then '' else convert(varchar(10),a.due_date,103) end as duedate from jct_task_log a, JCT_Task_Recepients b, jct_empmast_base c, jct_empmast_base d where a.task_no=b.task_no and rtrim(a.emp_code)=rtrim(c.empcode)and rtrim(b.recp_code)=rtrim(d.empcode) and c.deptcode<>d.deptcode and status in ('','R') and b.flag in('T') and b.recp_code='" & Session("Empcode") & "' order by a.task_no desc"
        End If

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
        GridExtTask.DataSource = dt
        GridExtTask.DataBind()
        dr.Close()
        ob.closecn()
    End Sub

    Public Sub MyIntTasks()
        Dim ds As New Data.DataSet
        Dim drow As Data.DataRow
        Dim dt As New Data.DataTable

        Dim cust As String = ""
        Dim sp As String = ""
        ob.opencn()
        If Trim(Me.DrpLvStatus.Text) = "Pending" Then
            qry = "select distinct a.Task_No,SubArea,c.empname,a.subject, a.task_status,a.task_priority, case when a.due_date='01/01/1900' then '' else convert(varchar(10),a.due_date,103) end as duedate from jct_task_log a, JCT_Task_Recepients b, jct_empmast_base c, jct_empmast_base d where a.task_no=b.task_no and rtrim(a.emp_code)=rtrim(c.empcode)and rtrim(b.recp_code)=rtrim(d.empcode) and c.deptcode=d.deptcode and b.flag in('T') and b.recp_code='" & Session("Empcode") & "' and status in ('','R') and authorize <> 'y' and task_status not in ('Closed','Completed','Re Assigned') order by a.task_no desc"
        ElseIf Trim(Me.DrpLvStatus.Text) = "ReAssigned" Then
            qry = "select distinct a.Task_No,SubArea,c.empname,a.subject, a.task_status,a.task_priority, case when a.due_date='01/01/1900' then '' else convert(varchar(10),a.due_date,103) end as duedate from jct_task_log a, JCT_Task_Recepients b, jct_empmast_base c, jct_empmast_base d where a.task_no=b.task_no and rtrim(a.emp_code)=rtrim(c.empcode)and rtrim(b.recp_code)=rtrim(d.empcode) and c.deptcode=d.deptcode and status in ('') and b.flag in('T') and b.recp_code='" & Session("Empcode") & "' and authorize<>'y' and task_status='Re Assigned'  order by a.task_no desc"
        ElseIf Trim(Me.DrpLvStatus.Text) = "Completed" Then
            qry = "select distinct a.Task_No,SubArea,c.empname,a.subject, a.task_status,a.task_priority, case when a.due_date='01/01/1900' then '' else convert(varchar(10),a.due_date,103) end as duedate from jct_task_log a, JCT_Task_Recepients b, jct_empmast_base c, jct_empmast_base d where a.task_no=b.task_no and rtrim(a.emp_code)=rtrim(c.empcode)and rtrim(b.recp_code)=rtrim(d.empcode) and c.deptcode=d.deptcode and status in ('','R') and b.flag in('T') and b.recp_code='" & Session("Empcode") & "' and authorize<>'y' and task_status in ('Closed','Completed')  order by a.task_no desc"
        ElseIf Trim(Me.DrpLvStatus.Text) = "Closed" Then
            qry = "select distinct a.Task_No,SubArea,c.empname,a.subject, a.task_status,a.task_priority, case when a.due_date='01/01/1900' then '' else convert(varchar(10),a.due_date,103) end as duedate from jct_task_log a, JCT_Task_Recepients b, jct_empmast_base c, jct_empmast_base d where a.task_no=b.task_no and rtrim(a.emp_code)=rtrim(c.empcode)and rtrim(b.recp_code)=rtrim(d.empcode) and c.deptcode=d.deptcode and status in ('C','','R') and b.flag in('T') and b.recp_code='" & Session("Empcode") & "' and  authorize='y'  order by a.task_no desc"
        Else
            qry = "select distinct a.Task_No,SubArea,c.empname,a.subject, a.task_status,a.task_priority, case when a.due_date='01/01/1900' then '' else convert(varchar(10),a.due_date,103) end as duedate from jct_task_log a, JCT_Task_Recepients b, jct_empmast_base c, jct_empmast_base d where a.task_no=b.task_no and rtrim(a.emp_code)=rtrim(c.empcode)and rtrim(b.recp_code)=rtrim(d.empcode) and c.deptcode=d.deptcode and status in ('','R') and b.flag in('T') and b.recp_code='" & Session("Empcode") & "'  order by a.task_no desc"
        End If


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
        GridIntTask.DataSource = dt
        GridIntTask.DataBind()
        dr.Close()
        ob.closecn()
    End Sub


    Public Sub AssgnByMe()
        Dim ds As New Data.DataSet
        Dim drow As Data.DataRow
        Dim dt As New Data.DataTable

        Dim cust As String = ""
        Dim sp As String = ""
        ob.opencn()

        ' qry = "select distinct a.Task_No,SubArea,c.empname,a.subject, a.task_status,a.task_priority, case when a.due_date='01/01/1900' then '' else convert(varchar(10),a.due_date,103) end as duedate from jct_task_log a, JCT_Task_Recepients b, jct_empmast_base c where a.task_no=b.task_no and rtrim(b.recp_code)=rtrim(c.empcode) and status in ('','R') and b.flag in('T') and rtrim(a.emp_code)='" & Session("Empcode") & "' and task_status not in ('Closed','Completed')"
        qry = "exec JCT_Task_AssgnByMe '" & Trim(Session("Empcode")) & "','" & Trim(Me.DrpLvStatus.Text) & "'"
        cmd = New SqlCommand(qry, ob.cn)
        cmd.CommandTimeout = 0
        dr = cmd.ExecuteReader

        Dim i As Integer
        cl(0) = "Task No"
        cl(1) = "Category"
        cl(2) = "Assigned To"
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
        GrdAssBy.DataSource = dt
        GrdAssBy.DataBind()
        dr.Close()
        ob.closecn()
    End Sub

    Protected Sub GridMyTasks_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridExtTask.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'e.Row.Cells[1].Text = "<a href='www.yahoo.com'>" + ((DataRowView)e.Row.DataItem)["Name"] + "</a>";
            e.Row.Cells(0).Text = "<a href='taskmanagement.aspx?reply=1&task=" & e.Row.DataItem(0) & "'>" & e.Row.DataItem(0) & "</a>"
            ' e.Row.Cells(0).Text = "<a href='taskmanagement.aspx>" & e.Row.DataItem(0) & "</a>"
            ' e.Row.Cells(1).Text = "<a href='TaskManagement.aspx'>" & CType(e.Row.DataItem, DataRowView)(1) & "</a>"

        End If


    End Sub

    Protected Sub GrdAssBy_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdAssBy.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'e.Row.Cells[1].Text = "<a href='www.yahoo.com'>" + ((DataRowView)e.Row.DataItem)["Name"] + "</a>";
            e.Row.Cells(0).Text = "<a href='taskmanagement.aspx?reply=2&task=" & e.Row.DataItem(0) & "'>" & e.Row.DataItem(0) & "</a>"
            ' e.Row.Cells(0).Text = "<a href='taskmanagement.aspx>" & e.Row.DataItem(0) & "</a>"
            ' e.Row.Cells(1).Text = "<a href='TaskManagement.aspx'>" & CType(e.Row.DataItem, DataRowView)(1) & "</a>"

        End If
    End Sub

    Protected Sub GridIntTask_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridIntTask.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Text = "<a href='taskmanagement.aspx?reply=1&task=" & e.Row.DataItem(0) & "'>" & e.Row.DataItem(0) & "</a>"
        End If
    End Sub

    Protected Sub DrpLvStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpLvStatus.SelectedIndexChanged
        MyTasks()
        MyIntTasks()
        AssgnByMe()
    End Sub
End Class
