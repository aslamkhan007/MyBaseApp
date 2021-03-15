Imports System.Data.SqlClient
Imports system.Data
Partial Class Emp_HOD_Relationship
    Inherits System.Web.UI.Page
    Dim db As Connection = New Connection
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim hod_ecode As String
    Dim emp_code As String
    Dim dept_no As String
    Dim comp_code As String = "JCT00LTD"
    Dim empcode As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("Empcode").ToString <> "") Then
            empcode = Session("Empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If

        If Not IsPostBack Then
            Try
                sql = "select deptname, deptcode from deptmast where company_code = '" & Session("Companycode") & "' order by 1"
                dr = db.FetchReader(sql)
                If dr.HasRows Then
                    While dr.Read()
                        If (Not dr.Item(0) Is DBNull.Value And Not dr.Item(1) Is DBNull.Value) Then
                            cblDeptList.Items.Add(dr.Item(0).ToString() & " | " & dr.Item(1).ToString())
                        End If
                    End While
                End If
                ddlHOD.SelectedIndex = -1
            Catch ex As Exception
                lblError.Text = ex.Message
            Finally
                dr.Close()
            End Try

            'Try
            '    sql = "select empname, empcode from empmast order by 1"
            '    dr = db.FetchReader(sql)

            '    If dr.HasRows Then
            '        While dr.Read()
            '            If (Not dr.Item(0) Is DBNull.Value And Not dr.Item(1) Is DBNull.Value) Then
            '                ddlHOD.Items.Add(dr.Item(0).ToString() & " | " & dr.Item(1).ToString())
            '            End If
            '        End While
            '    End If
            '    ddlHOD.SelectedIndex = -1
            'Catch ex As Exception
            '    lblError.Text = ex.Message
            'Finally
            '    dr.Close()
            'End Try
        End If
    End Sub

    Protected Sub ddlHOD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlHOD.SelectedIndexChanged
        cblEmpList.Items.Clear()

        Dim i As Integer
        Dim dept_sel As Boolean = False
        Try
            emp_code = ddlHOD.Text
            emp_code = emp_code.Substring(emp_code.IndexOf("|"), 9)
            emp_code = emp_code.Substring(2, 7)
            emp_code = Trim(emp_code)

            sql = "select emp.empname, emp.empcode, dept.deptname from " & _
                "jct_empmast_base emp, deptmast dept where " & _
                "dept.deptno = emp.deptno and emp.empcode <> '" & _
                emp_code & "' and emp.Active = 'Y' and emp.Assosc_Flag = 'E' and emp.empcode not in(" & _
                "select distinct emp_code from jct_emp_hod where status is null) and dept.company_code='" & Session("Companycode") & "' and dept.company_code=emp.company_code and emp.deptno in ("
            For i = 0 To cblDeptList.Items.Count - 1
                If cblDeptList.Items(i).Selected Then
                    dept_sel = True
                    Dim dept_no As String = cblDeptList.Items(i).Value.ToString()
                    dept_no = dept_no.Substring(dept_no.IndexOf("|"))
                    dept_no = dept_no.Substring(2)
                    dept_no = Trim(dept_no)
                    'arr.Add(s)
                    sql += "'" & dept_no & "',"
                End If
            Next
            If dept_sel Then
                sql = Left(sql, Len(sql) - 1)
                sql += ")"
                sql += "order by emp.empname"
            End If

            dr = db.FetchReader(sql)
            If dr.HasRows Then
                While dr.Read()
                    If (Not dr.Item(0) Is DBNull.Value And Not dr.Item(1) Is DBNull.Value) Then
                        cblEmpList.Items.Add(dr.Item(0).ToString() & " | " & dr.Item(1).ToString() & " | " & dr.Item(2).ToString())
                        'cblEmailAddress.Items.Add(dr.Item(0).ToString() & " | " & dr.Item(1).ToString())
                    End If
                End While
                dr.Close()
            End If

            ' To Show Mapped Employees
            cblMappedEmpList.Items.Clear()
            rdoMappedEmp.Items.Clear()
            sql = "select emp.empname, emp.empcode, dept.deptname from " & _
                    "jct_empmast_base emp, deptmast dept, jct_emp_hod hod where " & _
                    "dept.deptno = emp.deptno and hod.emp_code = emp.empcode and hod.resp_emp = '" & emp_code & "' " & _
                    "and hod.flag = '1H' and hod.status is null and dept.company_code='" & Session("Companycode") & "' and dept.company_code=emp.company_code and hod.company_code=emp.company_code order by emp.empname"
            i = 0
            dr.Close()
            dr = db.FetchReader(sql)
            If dr.HasRows Then
                While dr.Read()
                    If (Not dr.Item(0) Is DBNull.Value And Not dr.Item(1) Is DBNull.Value) Then
                        cblMappedEmpList.Items.Add(dr.Item(0).ToString() & " | " & dr.Item(1).ToString() & " | " & dr.Item(2).ToString())
                        rdoMappedEmp.Items.Add(dr.Item(0).ToString() & " | " & dr.Item(1).ToString() & " | " & dr.Item(2).ToString())
                        cblMappedEmpList.Items(i).Selected = True

                        i += 1
                    End If
                End While
                dr.Close()
            End If


        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            If (Not dr.IsClosed) Then
                dr.Close()
            End If
        End Try


        Try
            cblEmailAddress.Items.Clear()
            'dr = db.FetchReader("select upper(b.empname), a.e_mailid  from savior..mistel a, savior..empmast b where a.empcode =b.empcode and b.empcode = '" & emp_code & "'")
            dr = db.FetchReader("select empname, deptno from jctdev..jct_empmast_base where company_code = '" & Session("Companycode") & "' and deptno = '" & dept_no & "' order by empname")
            If (dr.HasRows) Then
                While dr.Read
                    If (Not (dr.Item(1) Is DBNull.Value Or dr.Item(1) Is DBNull.Value)) Then
                        cblEmailAddress.Items.Add(dr.Item(0) & " | " & dr.Item(1))
                    End If
                End While
            End If
            dr.Close()

            'dr = db.FetchReader("select b.empname, a.e_mailid from savior..mistel a, savior..empmast b where a.empcode = b.empcode and b.deptcode = (select deptcode from empmast where empcode = '" & emp_code & "') and b.empcode <> '" & emp_code & "'")
            'If (dr.HasRows) Then
            '    While dr.Read
            '        If (Not dr.Item(0) Is DBNull.Value) Then
            '            cblEmailAddress.Items.Add(dr.Item(0) & " | " & dr.Item(1))
            '        End If
            '    End While
            'End If

            'For i = 0 To cblEmailAddress.Items.Count - 1
            '    cblEmailAddress.Items(i).Selected = True
            'Next

        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            dr.Close()
        End Try

        Try
            'dr = db.FetchReader("select a.name, a.e_mailid from savior..mistel a, savior..empmast b where a.empcode = b.empcode and b.deptcode = '" & dept_no & "'")
            'If (dr.HasRows) Then
            '    While dr.Read
            '        If (Not dr.Item(1) Is DBNull.Value) Then
            '            cblEmailAddress.Items.Add(dr.Item(0) & " | " & dr.Item(1))
            '        End If
            '    End While
            'End If
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            dr.Close()
        End Try

    End Sub

    Protected Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim i, j As Integer
        Dim auth As String
        hod_ecode = ddlHOD.Text
        Dim selected_emp As String = ""
        'deptsel = True
        hod_ecode = hod_ecode.Substring(hod_ecode.IndexOf("|"))
        hod_ecode = hod_ecode.Substring(2, 7)
        hod_ecode = Trim(hod_ecode)
        'lblError.Text = hod_ecode
        'MsgBox(hod_ecode)
        'Dim emails As String = ""
        'For i = 0 To cblEmailAddress.Items.Count - 1
        '    If (cblEmailAddress.Items(i).Selected) Then
        '        Dim email As String
        '        email = cblEmailAddress.Items(i).Text
        '        email = email.Substring(email.IndexOf("|"))
        '        email = email.Substring(2)
        '        email = Trim(email)
        '        emails += email & ";"
        '    End If
        'Next
        'MsgBox(emails)
        'lblError.Text = emails

        Dim cn As SqlConnection = db.Connection
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        Dim tran As SqlTransaction = cn.BeginTransaction
        Dim sql_insert As String
        'Dim sql_update As String = "update jctdev..jct_emp_hod set flag = '" & hod_ecode & "', to_email = '" & emails & "' where empcode in("

        Try

            For i = 0 To cblEmpList.Items.Count - 1

                If cblEmpList.Items(i).Selected Then

                    selected_emp = cblEmpList.Items(i).Text
                    selected_emp = selected_emp.Substring(selected_emp.IndexOf("|"))
                    selected_emp = selected_emp.Substring(2, 7)
                    selected_emp = Trim(selected_emp)

                    sql_insert = "insert into jctdev..jct_emp_hod (company_code,user_code,emp_code,flag,resp_emp,eff_from,days,auth_req) values('" & Session("Companycode") & "','" & Session("Empcode").ToString & "','" & selected_emp & "','1H','" & hod_ecode & "',getdate(),0,'Y')"
                    Dim cmd_ins As SqlCommand = New SqlCommand(sql_insert, cn)
                    cmd_ins.Transaction = tran
                    cmd_ins.ExecuteNonQuery()
                    Dim resp_emp_to As String = ""
                    Dim resp_emp_cc As String = ""

                    For j = 0 To cblTo.Items.Count - 1
                        resp_emp_to = cblTo.Items(j).Text
                        resp_emp_to = resp_emp_to.Substring(resp_emp_to.IndexOf("|"))
                        resp_emp_to = resp_emp_to.Substring(2, 7)
                        resp_emp_to = Trim(resp_emp_to)

                        If txtToDays.Text = "" Then
                            txtToDays.Text = "0"
                        End If
                        If chkTo.Checked Then
                            auth = "Y"
                        Else
                            auth = "N"
                        End If
                        sql_insert = "insert into jctdev..jct_emp_hod (company_code,user_code,emp_code,flag,resp_emp,eff_from,days,auth_req) values('" & Session("Companycode") & "','" & Session("Empcode").ToString & "','" & selected_emp & "','2T','" & resp_emp_to & "',getdate()," & txtToDays.Text & ",'" & auth & "')"
                        cmd_ins = New SqlCommand(sql_insert, cn)
                        cmd_ins.Transaction = tran
                        cmd_ins.ExecuteNonQuery()
                    Next

                    For j = 0 To cblCC.Items.Count - 1
                        resp_emp_cc = cblCC.Items(j).Text
                        resp_emp_cc = resp_emp_cc.Substring(resp_emp_cc.IndexOf("|"))
                        resp_emp_cc = resp_emp_cc.Substring(2, 7)
                        resp_emp_cc = Trim(resp_emp_cc)
                        If txtCCDays.Text = "" Then
                            txtCCDays.Text = "0"
                        End If
                        If chkCC.Checked Then
                            auth = "Y"
                        Else
                            auth = "N"
                        End If
                        sql_insert = "insert into jctdev..jct_emp_hod (company_code,user_code,emp_code,flag,resp_emp,eff_from,days,auth_req) values('" & Session("Companycode") & "','" & Session("Empcode").ToString & "','" & selected_emp & "','3C','" & resp_emp_cc & "',getdate()," & txtCCDays.Text & ",'" & auth & "')"
                        cmd_ins = New SqlCommand(sql_insert, cn)
                        cmd_ins.Transaction = tran
                        cmd_ins.ExecuteNonQuery()
                    Next
                    resp_emp_cc = ""
                    For j = 0 To cblBCC.Items.Count - 1
                        resp_emp_cc = cblBCC.Items(j).Text
                        resp_emp_cc = resp_emp_cc.Substring(resp_emp_cc.IndexOf("|"))
                        resp_emp_cc = resp_emp_cc.Substring(2, 7)
                        resp_emp_cc = Trim(resp_emp_cc)
                        If txtBCCDays.Text = "" Then
                            txtBCCDays.Text = "0"
                        End If
                        If chkBCC.Checked Then
                            auth = "Y"
                        Else
                            auth = "N"
                        End If
                        sql_insert = "insert into jctdev..jct_emp_hod (company_code,user_code,emp_code,flag,resp_emp,eff_from,days,auth_req) values('" & Session("Companycode") & "','" & Session("Empcode").ToString & "','" & selected_emp & "','B','" & resp_emp_cc & "',getdate()," & txtBCCDays.Text & ",'" & auth & "')"
                        cmd_ins = New SqlCommand(sql_insert, cn)
                        cmd_ins.Transaction = tran
                        cmd_ins.ExecuteNonQuery()
                    Next
                    resp_emp_cc = ""
                    For j = 0 To cblBCC1.Items.Count - 1
                        resp_emp_cc = cblBCC1.Items(j).Text
                        resp_emp_cc = resp_emp_cc.Substring(resp_emp_cc.IndexOf("|"))
                        resp_emp_cc = resp_emp_cc.Substring(2, 7)
                        resp_emp_cc = Trim(resp_emp_cc)
                        If txtBCC1Days.Text = "" Then
                            txtBCC1Days.Text = "0"
                        End If
                        If chkBCC1.Checked Then
                            auth = "Y"
                        Else
                            auth = "N"
                        End If
                        sql_insert = "insert into jctdev..jct_emp_hod (company_code,user_code,emp_code,flag,resp_emp,eff_from,days,auth_req) values('" & Session("Companycode") & "','" & Session("Empcode").ToString & "','" & selected_emp & "','B1','" & resp_emp_cc & "',getdate()," & txtBCC1Days.Text & ",'" & auth & "')"
                        cmd_ins = New SqlCommand(sql_insert, cn)
                        cmd_ins.Transaction = tran
                        cmd_ins.ExecuteNonQuery()
                    Next
                    resp_emp_cc = ""
                    For j = 0 To cblBCC2.Items.Count - 1
                        resp_emp_cc = cblBCC2.Items(j).Text
                        resp_emp_cc = resp_emp_cc.Substring(resp_emp_cc.IndexOf("|"))
                        resp_emp_cc = resp_emp_cc.Substring(2, 7)
                        resp_emp_cc = Trim(resp_emp_cc)
                        If txtBCC2Days.Text = "" Then
                            txtBCC2Days.Text = "0"
                        End If
                        If chkBCC2.Checked Then
                            auth = "Y"
                        Else
                            auth = "N"
                        End If
                        sql_insert = "insert into jctdev..jct_emp_hod (company_code,user_code,emp_code,flag,resp_emp,eff_from,days,auth_req) values('" & Session("Companycode") & "','" & Session("Empcode").ToString & "','" & selected_emp & "','B2','" & resp_emp_cc & "',getdate()," & txtBCC2Days.Text & ",'" & auth & "')"
                        cmd_ins = New SqlCommand(sql_insert, cn)
                        cmd_ins.Transaction = tran
                        cmd_ins.ExecuteNonQuery()
                    Next
                    resp_emp_cc = ""
                    For j = 0 To cblBCC3.Items.Count - 1
                        resp_emp_cc = cblBCC3.Items(j).Text
                        resp_emp_cc = resp_emp_cc.Substring(resp_emp_cc.IndexOf("|"))
                        resp_emp_cc = resp_emp_cc.Substring(2, 7)
                        resp_emp_cc = Trim(resp_emp_cc)
                        If txtBCC3Days.Text = "" Then
                            txtBCC3Days.Text = "0"
                        End If
                        If chkBCC3.Checked Then
                            auth = "Y"
                        Else
                            auth = "N"
                        End If
                        sql_insert = "insert into jctdev..jct_emp_hod (company_code,user_code,emp_code,flag,resp_emp,eff_from,days,auth_req) values('" & Session("Companycode") & "','" & Session("Empcode").ToString & "','" & selected_emp & "','B3','" & resp_emp_cc & "',getdate()," & txtBCC3Days.Text & ",'" & auth & "')"
                        cmd_ins = New SqlCommand(sql_insert, cn)
                        cmd_ins.Transaction = tran
                        cmd_ins.ExecuteNonQuery()
                    Next

                    resp_emp_cc = ""
                    For j = 0 To cblBCC4.Items.Count - 1
                        resp_emp_cc = cblBCC4.Items(j).Text
                        resp_emp_cc = resp_emp_cc.Substring(resp_emp_cc.IndexOf("|"))
                        resp_emp_cc = resp_emp_cc.Substring(2, 7)
                        resp_emp_cc = Trim(resp_emp_cc)
                        If txtBCC4Days.Text = "" Then
                            txtBCC4Days.Text = "0"
                        End If
                        If chkBCC4.Checked Then
                            auth = "Y"
                        Else
                            auth = "N"
                        End If
                        sql_insert = "insert into jctdev..jct_emp_hod (company_code,user_code,emp_code,flag,resp_emp,eff_from,days,auth_req) values('" & Session("Companycode") & "','" & Session("Empcode").ToString & "','" & selected_emp & "','B4','" & resp_emp_cc & "',getdate()," & txtBCC4Days.Text & ",'" & auth & "')"
                        cmd_ins = New SqlCommand(sql_insert, cn)
                        cmd_ins.Transaction = tran
                        cmd_ins.ExecuteNonQuery()
                    Next

                    resp_emp_cc = ""
                    For j = 0 To cblBCC5.Items.Count - 1
                        resp_emp_cc = cblBCC5.Items(j).Text
                        resp_emp_cc = resp_emp_cc.Substring(resp_emp_cc.IndexOf("|"))
                        resp_emp_cc = resp_emp_cc.Substring(2, 7)
                        resp_emp_cc = Trim(resp_emp_cc)
                        If txtBCC5Days.Text = "" Then
                            txtBCC5Days.Text = "0"
                        End If
                        If chkBCC5.Checked Then
                            auth = "Y"
                        Else
                            auth = "N"
                        End If
                        sql_insert = "insert into jctdev..jct_emp_hod (company_code,user_code,emp_code,flag,resp_emp,eff_from,days,auth_req) values('" & Session("Companycode") & "','" & Session("Empcode").ToString & "','" & selected_emp & "','B5','" & resp_emp_cc & "',getdate()," & txtBCC5Days.Text & ",'" & auth & "')"
                        cmd_ins = New SqlCommand(sql_insert, cn)
                        cmd_ins.Transaction = tran
                        cmd_ins.ExecuteNonQuery()
                    Next
                End If
            Next
            tran.Commit()
            'MsgBox("Employee - HOD Relation Saved Successfully")
            lblError.Text = "Employee - HOD Relation Saved Successfully"
            cmdDeselect_Click(sender, e)

        Catch ex As Exception
            tran.Rollback()
            lblError.Text = "No Relation was Saved due to an Error!!" & Environment.NewLine & ex.Message

        End Try

    End Sub
    Protected Sub Retrieve_Employees()
        ddlHOD.Items.Clear()
        cblEmpList.Items.Clear()
        cblEmailAddress.Items.Clear()
        cblMappedEmpList.Items.Clear()
        rdoMappedEmp.Items.Clear()
        Dim i As Integer = 0

        Dim sql As String = "select empname,empcode,deptcode from jct_empmast_base where company_code='" & Session("Companycode") & "' and active = 'Y' and assosc_flag = 'E' and deptcode in("
        Dim deptsel As Boolean = False

        For i = 0 To cblDeptList.Items.Count - 1
            If cblDeptList.Items(i).Selected Then
                deptsel = True
                dept_no = cblDeptList.Items(i).Value.ToString()
                dept_no = dept_no.Substring(dept_no.IndexOf("|"))
                dept_no = dept_no.Substring(2)
                dept_no = Trim(dept_no)
                'arr.Add(s)
                sql += "'" & dept_no & "',"
            End If
        Next

        If deptsel Then
            sql = Left(sql, Len(sql) - 1)
            sql += ")"
            sql += " order by empname"

            Try
                dr = db.FetchReader(sql)

                'If Not dr Is DBNull.Value Then
                If dr.HasRows Then
                    While dr.Read()
                        If (Not dr.Item(0) Is DBNull.Value And Not dr.Item(1) Is DBNull.Value And Not dr.Item(2) Is DBNull.Value) Then
                            ddlHOD.Items.Add(dr.Item(0).ToString() & " | " & dr.Item(1).ToString() & " | " & dr.Item(2).ToString())
                            'cblEmpList.Items.Add(dr.Item(0).ToString() & " | " & dr.Item(1).ToString() & " | " & dr.Item(2).ToString())
                        End If
                    End While
                Else
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "scr", "<script language = javascript>alert('No Data Present')</script>")
                    'Response.Write("<script language = javascript>alert('No Data Present')</script>")
                End If
                'End If
            Catch ex As Exception
                lblError.Text = ex.Message
            Finally
                dr.Close()
            End Try
        Else
            'sql = "select empname,empcode,deptcode from empmast order by empname"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "scr", "<script language = javascript>alert('No Department Selected')</script>")
        End If
        'lblError.Text = sql
        'cblEmpList.Items.Clear()
        'For i = 0 To arr.Count - 1
        '    cblEmpList.Items.Add(arr.Item(i))
        'Next

    End Sub

    Protected Sub Retrieve_Employees(ByVal opt As String)
        ddlHOD.Items.Clear()
        cblEmpList.Items.Clear()
        cblEmailAddress.Items.Clear()
        Dim i As Integer = 0

        Dim sql As String = "select empname,empcode,deptcode from jct_empmast_base where company_code='" & Session("Companycode") & "' and active = 'Y' and assosc_flag = 'E'"

        Try
            dr = db.FetchReader(sql)

            'If Not dr Is DBNull.Value Then
            If dr.HasRows Then
                While dr.Read()
                    If (Not dr.Item(0) Is DBNull.Value And Not dr.Item(1) Is DBNull.Value And Not dr.Item(2) Is DBNull.Value) Then
                        ddlHOD.Items.Add(dr.Item(0).ToString() & " | " & dr.Item(1).ToString() & " | " & dr.Item(2).ToString())
                        'cblEmpList.Items.Add(dr.Item(0).ToString() & " | " & dr.Item(1).ToString() & " | " & dr.Item(2).ToString())
                    End If
                End While
            Else
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "scr", "<script language = javascript>alert('No Data Present')</script>")
                'Response.Write("<script language = javascript>alert('No Data Present')</script>")
            End If
            'End If
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            dr.Close()
        End Try
        ''Else
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "scr", "<script language = javascript>alert('No Department Selected')</script>")
        ''End If

    End Sub


    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        'If (IsPostBack) Then
        'MasterPageFile = Session("MasterPg")
        'End If
    End Sub

    Protected Sub cmdDeselect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDeselectDept.Click
        cblDeptList.ClearSelection()
        ddlHOD.Items.Clear()
        cblEmpList.Items.Clear()
        cblEmailAddress.Items.Clear()
        cblMappedEmpList.Items.Clear()
        cblTo.Items.Clear()
        cblCC.Items.Clear()
        cblBCC.Items.Clear()
        cblBCC1.Items.Clear()
        cblBCC2.Items.Clear()
        cblBCC3.Items.Clear()
        cblBCC4.Items.Clear()
        cblBCC5.Items.Clear()
        rdoMappedEmp.Items.Clear()
        txtBCC1Days.Text = ""
        txtBCC2Days.Text = ""
        txtBCC3Days.Text = ""
        txtBCC4Days.Text = ""
        txtBCC5Days.Text = ""
        txtBCCDays.Text = ""
        txtCCDays.Text = ""
        txtToDays.Text = ""

        chkTo.Checked = True
        chkCC.Checked = True
        chkBCC.Checked = True
        chkBCC1.Checked = True
        chkBCC2.Checked = True
        chkBCC3.Checked = True
        chkBCC4.Checked = True
        chkBCC5.Checked = True

        Panel3.Enabled = False
        Panel4.Enabled = False
        Panel5.Enabled = False
        Panel6.Enabled = False
        Panel8.Enabled = False
        Panel9.Enabled = False
        Panel10.Enabled = False
        Panel11.Enabled = False
        Panel12.Enabled = False

        cmdTo.Enabled = False
        cmdCC.Enabled = False
        cmdBCC.Enabled = False
        cmdBCC1.Enabled = False
        cmdBCC2.Enabled = False
        cmdBCC3.Enabled = False
        cmdBCC4.Enabled = False
        cmdBCC5.Enabled = False

        cmdRemove.Enabled = False

    End Sub

    Protected Sub cmdDeselectEmp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDeselectEmp.Click
        cblEmpList.ClearSelection()
        cblEmailAddress.Items.Clear()
        cblTo.Items.Clear()
        cblCC.Items.Clear()
        cblBCC.Items.Clear()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSelectAllEmp.Click
        Dim i As Integer
        For i = 0 To cblEmpList.Items.Count - 1
            cblEmpList.Items(i).Selected = True
        Next
    End Sub

    Protected Function DoEmpExists(ByVal empcode As String, ByVal tran As SqlTransaction) As Boolean
        Dim sql As String = "select emp_code from jctdev..jct_emp_hod where company_code='" & Session("Companycode") & "' and emp_code = '" & empcode & "' and flag = 'H' and status = ''"
        Try
            Dim cn As SqlConnection = db.Connection
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            cmd.Transaction = tran
            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            If dr.HasRows() Then
                dr.Close()
                Return True
            Else
                dr.Close()
                Return False
            End If
        Catch ex As Exception
            lblError.Text = ex.Message
            MsgBox(ex.Message)
        End Try

    End Function

    Protected Sub cblDeptList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cblDeptList.SelectedIndexChanged
        Retrieve_Employees()
    End Sub

    Protected Sub cmdSelectAllDept_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSelectAllDept.Click
        Dim i As Integer
        For i = 0 To cblDeptList.Items.Count - 1
            cblDeptList.Items(i).Selected = True
        Next
        Retrieve_Employees()
    End Sub

    Protected Sub cmdTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTo.Click
        Dim i As Integer

        For i = 0 To cblEmailAddress.Items.Count - 1
            If i <= cblEmailAddress.Items.Count - 1 Then
                If cblEmailAddress.Items(i).Selected Then
                    cblTo.Items.Add(cblEmailAddress.Items(i))
                    cblEmailAddress.Items.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next
        cmdTo.Enabled = False
    End Sub

    Protected Sub cmdCC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCC.Click
        Dim i As Integer

        For i = 0 To cblEmailAddress.Items.Count - 1
            If i <= cblEmailAddress.Items.Count - 1 Then
                If cblEmailAddress.Items(i).Selected Then
                    cblCC.Items.Add(cblEmailAddress.Items(i))
                    cblEmailAddress.Items.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next
        cmdCC.Enabled = False
    End Sub

    Protected Sub cmdRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        Dim i As Integer

        For i = 0 To cblTo.Items.Count - 1
            If i <= cblTo.Items.Count - 1 Then
                If cblTo.Items(i).Selected Then
                    cblEmailAddress.Items.Add(cblTo.Items(i))
                    cblTo.Items.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next
        If cblTo.Items.Count = 0 Then
            txtToDays.Text = ""
            cmdTo.Enabled = True
        End If

        For i = 0 To cblCC.Items.Count - 1
            If i <= cblCC.Items.Count - 1 Then
                If cblCC.Items(i).Selected Then
                    cblEmailAddress.Items.Add(cblCC.Items(i))
                    cblCC.Items.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next
        If cblCC.Items.Count = 0 Then
            txtCCDays.Text = ""
            cmdCC.Enabled = True
        End If

        For i = 0 To cblBCC.Items.Count - 1
            If i <= cblBCC.Items.Count - 1 Then
                If cblBCC.Items(i).Selected Then
                    cblEmailAddress.Items.Add(cblBCC.Items(i))
                    cblBCC.Items.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next
        If cblBCC.Items.Count = 0 Then
            txtBCCDays.Text = ""
            cmdBCC.Enabled = True
        End If

        For i = 0 To cblBCC1.Items.Count - 1
            If i <= cblBCC1.Items.Count - 1 Then
                If cblBCC1.Items(i).Selected Then
                    cblEmailAddress.Items.Add(cblBCC1.Items(i))
                    cblBCC1.Items.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next
        If cblBCC1.Items.Count = 0 Then
            txtBCC1Days.Text = ""
            cmdBCC1.Enabled = True
        End If

        For i = 0 To cblBCC2.Items.Count - 1
            If i <= cblBCC2.Items.Count - 1 Then
                If cblBCC2.Items(i).Selected Then
                    cblEmailAddress.Items.Add(cblBCC2.Items(i))
                    cblBCC2.Items.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next
        If cblBCC2.Items.Count = 0 Then
            txtBCC2Days.Text = ""
            cmdBCC2.Enabled = True
        End If

        For i = 0 To cblBCC3.Items.Count - 1
            If i <= cblBCC3.Items.Count - 1 Then
                If cblBCC3.Items(i).Selected Then
                    cblEmailAddress.Items.Add(cblBCC3.Items(i))
                    cblBCC3.Items.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next
        If cblBCC3.Items.Count = 0 Then
            txtBCC3Days.Text = ""
            cmdBCC3.Enabled = True
        End If

        For i = 0 To cblBCC4.Items.Count - 1
            If i <= cblBCC4.Items.Count - 1 Then
                If cblBCC4.Items(i).Selected Then
                    cblEmailAddress.Items.Add(cblBCC4.Items(i))
                    cblBCC4.Items.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next
        If cblBCC4.Items.Count = 0 Then
            txtBCC4Days.Text = ""
            cmdBCC4.Enabled = True
        End If

        For i = 0 To cblBCC5.Items.Count - 1
            If i <= cblBCC5.Items.Count - 1 Then
                If cblBCC5.Items(i).Selected Then
                    cblEmailAddress.Items.Add(cblBCC5.Items(i))
                    cblBCC5.Items.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next
        If cblBCC5.Items.Count = 0 Then
            txtBCC5Days.Text = ""
            cmdBCC5.Enabled = True
        End If


    End Sub

    Protected Sub Button1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer
        Dim sel As Boolean = False
        For i = 0 To cblEmpList.Items.Count - 1
            If cblEmpList.Items(i).Selected = True Then
                sel = True
            End If

        Next

        If sel = False Then
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "scr", "<script language = javascript>alert('No Employee Selected to Add Details')</script>")
            Exit Sub
        End If

        'Dim str As String = ""

        'For i = 0 To cblEmpList.Items.Count - 1
        '    If i <= cblEmpList.Items.Count - 1 Then
        '        If Not cblEmpList.Items(i).Selected Then
        '            str = cblEmpList.Items(i).Text
        '            str = str.Substring(0, str.LastIndexOf("|"))
        '            cblEmailAddress.Items.Add(Trim(str))
        '            cblEmpList.Items.RemoveAt(i)
        '            i -= 1
        '        End If
        '    End If
        'Next

        '__________________________________________________________________

        'CheckBox1.Checked = False

        'Retrieve_Employees()
        cblEmailAddress.Items.Clear()
        Dim sql As String = "select empname,empcode,deptcode from jct_empmast_base where company_code='" & Session("Companycode") & "' and active = 'Y' and assosc_flag = 'E' and deptcode in("
        Dim deptsel As Boolean = False

        For i = 0 To cblDeptList.Items.Count - 1
            If cblDeptList.Items(i).Selected Then
                deptsel = True
                dept_no = cblDeptList.Items(i).Value.ToString()
                dept_no = dept_no.Substring(dept_no.IndexOf("|"))
                dept_no = dept_no.Substring(2)
                dept_no = Trim(dept_no)
                'arr.Add(s)
                sql += "'" & dept_no & "',"
            End If
        Next

        If deptsel Then
            sql = Left(sql, Len(sql) - 1)
            sql += ")"
            sql += " order by empname"

            Try
                dr = db.FetchReader(sql)

                'If Not dr Is DBNull.Value Then
                If dr.HasRows Then
                    While dr.Read()
                        If (Not dr.Item(0) Is DBNull.Value And Not dr.Item(1) Is DBNull.Value And Not dr.Item(2) Is DBNull.Value) Then
                            cblEmailAddress.Items.Add(dr.Item(0).ToString() & " | " & dr.Item(1).ToString() & " | " & dr.Item(2).ToString())
                            'cblEmpList.Items.Add(dr.Item(0).ToString() & " | " & dr.Item(1).ToString() & " | " & dr.Item(2).ToString())
                        End If
                    End While
                Else
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "scr", "<script language = javascript>alert('No Data Present')</script>")
                    'Response.Write("<script language = javascript>alert('No Data Present')</script>")
                End If
                'End If
            Catch ex As Exception
                lblError.Text = ex.Message
            Finally
                dr.Close()
            End Try
        Else
            'sql = "select empname,empcode,deptcode from empmast order by empname"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "scr", "<script language = javascript>alert('No Department Selected')</script>")
        End If


        '__________________________________________________________________

        Panel3.Enabled = True
        Panel4.Enabled = True
        Panel5.Enabled = True
        Panel6.Enabled = True
        Panel8.Enabled = True
        Panel9.Enabled = True
        Panel10.Enabled = True
        Panel11.Enabled = True
        Panel12.Enabled = True

        cmdTo.Enabled = True
        cmdCC.Enabled = True
        cmdBCC.Enabled = True
        cmdBCC1.Enabled = True
        cmdBCC2.Enabled = True
        cmdBCC3.Enabled = True
        cmdBCC4.Enabled = True
        cmdBCC5.Enabled = True

        cmdRemove.Enabled = True

    End Sub

    Protected Sub cblMappedEmpList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cblMappedEmpList.SelectedIndexChanged

        Dim cn As SqlConnection = db.Connection
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Dim cmd As SqlCommand
        Dim i As Integer = 0
        Try
            cn.Open()
            For i = 0 To cblMappedEmpList.Items.Count - 1
                If cblMappedEmpList.Items(i).Selected = False Then
                    emp_code = cblMappedEmpList.Items(i).Text
                    emp_code = emp_code.Substring(emp_code.IndexOf("|"), 9)
                    emp_code = emp_code.Substring(2, 7)
                    emp_code = Trim(emp_code)
                    sql = "update jct_emp_hod set user_code = '" & Session("Empcode") & "', status = 'D', eff_to = getdate() where company_code='" & Session("Companycode") & "' and emp_code = '" & emp_code & "' AND eff_to IS NULL AND status IS NULL "
                    cmd = New SqlCommand(sql, cn)
                    Try
                        cmd.ExecuteNonQuery()
                        cblEmpList.Items.Add(cblMappedEmpList.Items(i).Text)
                        cblMappedEmpList.Items.RemoveAt(i)
                        rdoMappedEmp.Items.RemoveAt(i)
                        i -= 1
                    Catch ex As Exception

                    End Try

                End If
            Next
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            cn.Close()
        End Try

    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            'Retrieve_Employees("All")

            Dim sql As String = "select empname,empcode,deptcode from jct_empmast_base where company_code='" & Session("Companycode") & "' and active = 'Y' and assosc_flag = 'E' order by empname"

            Try
                dr = db.FetchReader(sql)

                'If Not dr Is DBNull.Value Then
                If dr.HasRows Then
                    While dr.Read()
                        If (Not dr.Item(0) Is DBNull.Value And Not dr.Item(1) Is DBNull.Value And Not dr.Item(2) Is DBNull.Value) Then
                            cblEmailAddress.Items.Add(dr.Item(0).ToString() & " | " & dr.Item(1).ToString() & " | " & dr.Item(2).ToString())
                            'cblEmpList.Items.Add(dr.Item(0).ToString() & " | " & dr.Item(1).ToString() & " | " & dr.Item(2).ToString())
                        End If
                    End While
                Else
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "scr", "<script language = javascript>alert('No Data Present')</script>", False)
                    'Response.Write("<script language = javascript>alert('No Data Present')</script>")
                End If
                'End If
            Catch ex As Exception
                lblError.Text = ex.Message
            Finally
                dr.Close()
            End Try

        Else
            'Retrieve_Employees()
            cblEmailAddress.Items.Clear()
            Dim sql As String = "select empname,empcode,deptcode from jct_empmast_base where company_code='" & Session("Companycode") & "' and active = 'Y' and assosc_flag = 'E' and deptcode in("
            Dim deptsel As Boolean = False
            Dim i As Integer
            For i = 0 To cblDeptList.Items.Count - 1
                If cblDeptList.Items(i).Selected Then
                    deptsel = True
                    dept_no = cblDeptList.Items(i).Value.ToString()
                    dept_no = dept_no.Substring(dept_no.IndexOf("|"))
                    dept_no = dept_no.Substring(2)
                    dept_no = Trim(dept_no)
                    'arr.Add(s)
                    sql += "'" & dept_no & "',"
                End If
            Next

            If deptsel Then
                sql = Left(sql, Len(sql) - 1)
                sql += ")"
                sql += " order by empname"

                Try
                    dr = db.FetchReader(sql)

                    If dr.HasRows Then
                        While dr.Read()
                            If (Not dr.Item(0) Is DBNull.Value And Not dr.Item(1) Is DBNull.Value And Not dr.Item(2) Is DBNull.Value) Then
                                cblEmailAddress.Items.Add(dr.Item(0).ToString() & " | " & dr.Item(1).ToString() & " | " & dr.Item(2).ToString())
                                'cblEmpList.Items.Add(dr.Item(0).ToString() & " | " & dr.Item(1).ToString() & " | " & dr.Item(2).ToString())
                            End If
                        End While
                    Else
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "scr", "<script language = javascript>alert('No Data Present')</script>")
                        'Response.Write("<script language = javascript>alert('No Data Present')</script>")
                    End If

                Catch ex As Exception
                    lblError.Text = ex.Message
                Finally
                    dr.Close()
                End Try
            Else
                'sql = "select empname,empcode,deptcode from empmast order by empname"
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "scr", "<script language = javascript>alert('No Department Selected')</script>")
            End If
        End If
    End Sub

    Protected Sub cmdBCC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBCC.Click
        Dim i As Integer

        For i = 0 To cblEmailAddress.Items.Count - 1
            If i <= cblEmailAddress.Items.Count - 1 Then
                If cblEmailAddress.Items(i).Selected Then
                    cblBCC.Items.Add(cblEmailAddress.Items(i))
                    cblEmailAddress.Items.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next
        'cmdBCC.Enabled = False
    End Sub

    Protected Sub rdoMappedEmp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoMappedEmp.SelectedIndexChanged
        ena_dis(True)

        If rdoMappedEmp.SelectedIndex >= 0 Then
            'Try
            Dim cn As SqlConnection = db.Connection
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            emp_code = rdoMappedEmp.SelectedItem.Text
            emp_code = emp_code.Substring(emp_code.IndexOf("|"), 9)
            emp_code = emp_code.Substring(2, 7)
            emp_code = Trim(emp_code)

            sql = "select b.empname,a.resp_emp,isnull(a.days,0),a.auth_req from jct_emp_hod a,jct_empmast_base b where a.company_code = b.company_code and a.company_code = '" & Session("Companycode") & "' and a.resp_emp = b.empcode and a.emp_code = '" & emp_code & "' and a.flag = '2T' and a.status is null "
            EmptyList(cblTo, txtToDays, chkTo)
            fillCheckBoxList(sql, cblTo, txtToDays, chkTo)

            sql = "select b.empname,a.resp_emp,isnull(a.days,0),a.auth_req from jct_emp_hod a,jct_empmast_base b where a.company_code = b.company_code and a.company_code = '" & Session("Companycode") & "' and a.resp_emp = b.empcode and a.emp_code = '" & emp_code & "' and a.flag = '3C' and a.status is null "
            EmptyList(cblCC, txtCCDays, chkCC)
            fillCheckBoxList(sql, cblCC, txtCCDays, chkCC)

            sql = "select b.empname,a.resp_emp,isnull(a.days,0),a.auth_req from jct_emp_hod a,jct_empmast_base b where a.company_code = b.company_code and a.company_code = '" & Session("Companycode") & "' and a.resp_emp = b.empcode and a.emp_code = '" & emp_code & "' and a.flag = 'B' and a.status is null "
            EmptyList(cblBCC, txtBCCDays, chkBCC)
            fillCheckBoxList(sql, cblBCC, txtBCCDays, chkBCC)

            sql = "select b.empname,a.resp_emp,isnull(a.days,0),a.auth_req from jct_emp_hod a,jct_empmast_base b where a.company_code = b.company_code and a.company_code = '" & Session("Companycode") & "' and a.resp_emp = b.empcode and a.emp_code = '" & emp_code & "' and a.flag = 'B1' and a.status is null "
            EmptyList(cblBCC1, txtBCC1Days, chkBCC1)
            fillCheckBoxList(sql, cblBCC1, txtBCC1Days, chkBCC1)

            sql = "select b.empname,a.resp_emp,isnull(a.days,0),a.auth_req from jct_emp_hod a,jct_empmast_base b where a.company_code = b.company_code and a.company_code = '" & Session("Companycode") & "' and a.resp_emp = b.empcode and a.emp_code = '" & emp_code & "' and a.flag = 'B2' and a.status is null "
            EmptyList(cblBCC2, txtBCC2Days, chkBCC2)
            fillCheckBoxList(sql, cblBCC2, txtBCC2Days, chkBCC2)

            sql = "select b.empname,a.resp_emp,isnull(a.days,0),a.auth_req from jct_emp_hod a,jct_empmast_base b where a.company_code = b.company_code and a.company_code = '" & Session("Companycode") & "' and a.resp_emp = b.empcode and a.emp_code = '" & emp_code & "' and a.flag = 'B3' and a.status is null "
            EmptyList(cblBCC3, txtBCC3Days, chkBCC3)
            fillCheckBoxList(sql, cblBCC3, txtBCC3Days, chkBCC3)

            sql = "select b.empname,a.resp_emp,isnull(a.days,0),a.auth_req from jct_emp_hod a,jct_empmast_base b where a.company_code = b.company_code and a.company_code = '" & Session("Companycode") & "' and a.resp_emp = b.empcode and a.emp_code = '" & emp_code & "' and a.flag = 'B4' and a.status is null "
            EmptyList(cblBCC4, txtBCC4Days, chkBCC4)
            fillCheckBoxList(sql, cblBCC4, txtBCC4Days, chkBCC4)

            sql = "select b.empname,a.resp_emp,isnull(a.days,0),a.auth_req from jct_emp_hod a,jct_empmast_base b where a.company_code = b.company_code and a.company_code = '" & Session("Companycode") & "' and a.resp_emp = b.empcode and a.emp_code = '" & emp_code & "' and a.flag = 'B5' and a.status is null "
            EmptyList(cblBCC5, txtBCC5Days, chkBCC5)
            fillCheckBoxList(sql, cblBCC5, txtBCC5Days, chkBCC5)
            'Catch ex As Exception

            'Finally

            'End Try



            'sql = "update jct_emp_hod set user_code = '" & Session("Empcode") & "', status = 'D', eff_to = getdate() where emp_code = '" & emp_code & "'"

            'cmd = New SqlCommand(sql, cn)
            'Try
            '    cmd.ExecuteNonQuery()
            'Catch ex As Exception

            'Finally
            '    cn.Close()
            'End Try

        End If
    End Sub

    Protected Sub cmdBCC1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBCC1.Click
        Dim i As Integer

        For i = 0 To cblEmailAddress.Items.Count - 1
            If i <= cblEmailAddress.Items.Count - 1 Then
                If cblEmailAddress.Items(i).Selected Then
                    cblBCC1.Items.Add(cblEmailAddress.Items(i))
                    cblEmailAddress.Items.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next
        cmdBCC1.Enabled = False

    End Sub

    Protected Sub cmdBCC2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBCC2.Click
        Dim i As Integer

        For i = 0 To cblEmailAddress.Items.Count - 1
            If i <= cblEmailAddress.Items.Count - 1 Then
                If cblEmailAddress.Items(i).Selected Then
                    cblBCC2.Items.Add(cblEmailAddress.Items(i))
                    cblEmailAddress.Items.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next
        cmdBCC2.Enabled = False
    End Sub

    Protected Sub cmdBCC3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBCC3.Click
        Dim i As Integer

        For i = 0 To cblEmailAddress.Items.Count - 1
            If i <= cblEmailAddress.Items.Count - 1 Then
                If cblEmailAddress.Items(i).Selected Then
                    cblBCC3.Items.Add(cblEmailAddress.Items(i))
                    cblEmailAddress.Items.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next
        cmdBCC3.Enabled = False
    End Sub

    Protected Sub cmdBCC4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBCC4.Click
        Dim i As Integer

        For i = 0 To cblEmailAddress.Items.Count - 1
            If i <= cblEmailAddress.Items.Count - 1 Then
                If cblEmailAddress.Items(i).Selected Then
                    cblBCC4.Items.Add(cblEmailAddress.Items(i))
                    cblEmailAddress.Items.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next

        cmdBCC4.Enabled = False
    End Sub

    Protected Sub cmdBCC5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBCC5.Click
        Dim i As Integer
        For i = 0 To cblEmailAddress.Items.Count - 1
            If i <= cblEmailAddress.Items.Count - 1 Then
                If cblEmailAddress.Items(i).Selected Then
                    cblBCC5.Items.Add(cblEmailAddress.Items(i))
                    cblEmailAddress.Items.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next
        cmdBCC5.Enabled = False
    End Sub

    Protected Sub fillCheckBoxList(ByVal sql As String, ByVal ListCtrl As CheckBoxList, ByVal txt As TextBox, ByVal chk As CheckBox)

        dr = db.FetchReader(sql)
        If dr.HasRows Then
            While dr.Read()
                ListCtrl.Items.Add(dr.Item(0) & " | " & dr.Item(1))
                txt.Text = dr.Item(2).ToString
                chk.Checked = IIf(dr.Item(3) = "Y", True, False)
            End While


        End If
        dr.Close()
    End Sub

    Protected Sub EmptyList(ByVal ListCtrl As CheckBoxList, ByVal txt As TextBox, ByVal chk As CheckBox)
        ListCtrl.Items.Clear()
        txt.Text = ""
        chk.Enabled = True
    End Sub

    Protected Sub ena_dis(ByVal flag As Boolean)
        Panel3.Enabled = flag
        Panel4.Enabled = flag
        Panel5.Enabled = flag
        Panel6.Enabled = flag
        Panel8.Enabled = flag
        Panel9.Enabled = flag
        Panel10.Enabled = flag
        Panel11.Enabled = flag
        Panel12.Enabled = flag
    End Sub


End Class
