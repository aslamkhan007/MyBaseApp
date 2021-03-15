Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Partial Class EmpGateway_New_Joinee_Login
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim obj As Connection = New Connection
    Dim obj1 As Functions = New Functions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            sql = "Select deptcode,deptname from deptmast "
            obj1.FillList(ddlDepartment, sql)
        End If
    End Sub

    Protected Sub lnkSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSubmit.Click
        ' exec jct_emp_login_new_joininee 'empcode','cardno','empname','gender','fathername','dept','desg','doj','dob'
        sql = "Exec jct_emp_login_new_joinee '" & txtempcode.Text & "','" & txtcardno.Text & "','" & txtname.Text & "','" & ddlGender.SelectedItem.Value & "','" & txtfathername.Text & "','" & ddlDepartment.SelectedItem.Value & "','" & txtdesignation.Text & "','" & txtdoj.Text & "','" & txtdob.Text & "'"
        If obj1.InsertRecord(sql) Then
            Dim msg = "Your Username is  : " & txtempcode.Text & " and Password : " & txtdob.Text & ""
            ShowAlertMsg(msg)
        Else
            Dim msg = "Some error occured contact IT-HelpDesk at 4212"
            ShowAlertMsg(msg)
        End If

    End Sub
    Public Sub ShowAlertMsg(ByVal msg As String)
        Dim page As Page = TryCast(HttpContext.Current.Handler, Page)
        If page IsNot Nothing Then
            ' error1 = error1.Replace("'", "'")
            ScriptManager.RegisterStartupScript(page, page.[GetType](), "err_msg", "alert('" & msg & "');", True)
        End If
    End Sub

    Protected Sub lnkReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkReset.Click
        txtcardno.Text = ""
        txtdesignation.Text = ""
        txtdob.Text = ""
        txtdoj.Text = ""
        txtempcode.Text = ""
        txtfathername.Text = ""
        txtname.Text = ""
    End Sub
End Class
