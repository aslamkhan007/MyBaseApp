Imports System.Data
Imports System.Data.SqlClient
Partial Class Login
    Inherits System.Web.UI.Page
    Public Name, Login As String
    Dim Obj As Connection = New Connection
    Dim Fun As Functions = New Functions
    Dim sqlpass As String
    Dim SqlPass1 As String
    Public cmd As New SqlCommand
    Public ob As New HelpDeskClass
    Public qry As String
    Dim PageL As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fun.FillList(ddlCompany, "select CompanyName, CompanyName from jctgen..jct_company_master")
        fun.FillList(ddlLocation, "select Location, Location from jctgen..jct_company_master")

        txtPassword.Attributes.Add("onkeypress", "return clickButton(event,'" + lnkLogin.ClientID + "')")
        txtUserName.Focus()
    End Sub


    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLogin.Click

        'User Authentication Code

        'Dim cookie As New HttpCookie("UserName")
        'cookie.Value = Trim(txtUserName.Text)
        'cookie.Expires = Now.AddHours(1)
        'Response.Cookies.Add(cookie)
        'Dim dt As DataTable = New DataTable

        Dim auth As Integer = Fun.AuthenticateUserAtLogin(Trim(txtUserName.Text), Trim(txtPassword.Text))

        'Fetch Company Code
        Dim sql As String = "select companycode from jctgen..jct_company_master where companyname = '" & _
                          ddlCompany.SelectedValue & "' and Location = '" & ddlLocation.SelectedValue & "'"
        Dim comp_code As String = ""
        If Not Fun.FetchValue(sql) Is Nothing Then
            'Dim comp_code As String = IIf(FetchValue(sql) Is DBNull.Value, "", FetchValue(sql).ToString)
            comp_code = Fun.FetchValue(sql)
            Session("Companycode") = Fun.FetchValue(sql)
            Session("Loc") = Me.ddlLocation.Text
        Else
            lblError.Text = "Please Select Valid Company & Location"

        End If

        Dim Host_IP As String = Request.ServerVariables("REMOTE_ADDR")

        If auth = 2 Then
            sql = "Select empcode from jct_login_emp where empcode='" + txtUserName.Text + "' union  Select oldEmpcode FROM Jct_Payroll_Empcode_SapCode_Mapping WHERE newcode='" + txtUserName.Text + "'   "
            ' sql = "Select empcode from jct_login_emp_PayrollPortal where empcode='" + txtUserName.Text + "' "
            'sql = "Select empcode from jct_login_emp where empcode='" + txtUserName.Text + "' "
            Session("Empcode") = Fun.FetchValue(sql)
            Fun.RegAppHit(comp_code, txtUserName.Text, "FusionApps", Host_IP)
            'Dim Host_IP As String = Request.UserHostName
            ' CheckSystem()
            'Get_Popup_Pages()
            Response.Redirect("emp_home.aspx")
        ElseIf auth = 1 Then
            'ClientScript.RegisterClientScriptBlock(Me.GetType, "src", "<script language = 'javascript'> alert('Error occured in Login')</script>")
            lblError.Text = "Invalid Password"
            txtPassword.Focus()
        ElseIf auth = 0 Then
            lblError.Text = "Invalid Username"
            txtUserName.Focus()
        End If

    End Sub

    'Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate, CustomValidator2.ServerValidate

    '    If AuthenticateUserAtLogin(Trim(txtUserName.Text), Trim(txtPassword.Text)) Then
    '        args.IsValid = True
    '    Else
    '        args.IsValid = False
    '    End If

    'End Sub

    Protected Sub Get_Popup_Pages()
        '----------------------------Salary pages----------------------
        Dim SqlPass = "select * from jct_login_emp where empcode='" & Trim(Me.txtUserName.Text) & "' and active = 'Y' and new_pass is null  and  Company_Code='" & Session("Companycode") & " '"
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = False Then
                Dr.Close()
                Obj.ConClose()
                PageL = 1
                Exit Try
            Else
                Dr.Read()
                If Dr.Item(0) Is System.DBNull.Value Then
                    PageL = 1
                Else
                    PageL = 2
                End If
            End If
            Dr.Close()
        Catch ex As Exception
            Response.Write("<script>alert(ex.ToString())</script>")
        Finally
            Obj.ConClose()
        End Try
        '----------------------------------------------------------------------------------------------------
        SqlPass = "Select * from jct_emp_Salary_Update  where (convert(varchar(10),upddate,102)=convert(varchar(10),getdate(),102) or convert(varchar(10),upddate,102)=convert(varchar(10),getdate()-1,102)) and (flag1 is null or flag2 is null) and type='ALL' and emp_code='" & Session("Empcode") & "' and  Company_Code='" & Session("Companycode") & " '"
        Dim Dr1 As SqlDataReader = Obj.FetchReader(SqlPass)

        If Dr1.HasRows = True Then
            Session("Allowance") = 1
            Dr1.Read()
            Session("MonthYear") = Dr1.Item("MonthYear")
            Session("Catg") = Dr1.Item("Catg")
            If Dr1.Item("flag1") Is System.DBNull.Value Then
                Session("AllFlag1") = 1
                Session("AllFlag2") = 0
            ElseIf Dr1.Item("flag2") Is System.DBNull.Value Then
                Session("AllFlag2") = 1
                Session("AllFlag1") = 0
            End If
        Else
            Session("Allowance") = 0
        End If
        Dr1.Close()
        Obj.ConClose()
        '----------------------------------------------------------------------------------------------------------
        ob.opencn()
        qry = "select * from jct_emp_Salary_Update  where (convert(varchar(10),upddate,102)=convert(varchar(10),getdate(),102) or convert(varchar(10),upddate,102)=convert(varchar(10),getdate()-1,102)) and (flag1 is null or flag2 is null) and type='sal' and emp_code='" & Session("Empcode") & "' and  Company_Code='" & Session("Companycode") & " '"
        cmd = New SqlCommand(qry, ob.cn)
        Dr = cmd.ExecuteReader
        If Dr.HasRows = True Then
            Session("Sal_Flag") = 1
            Dr.Read()
            If Dr.Item("flag1") Is System.DBNull.Value Then
                Session("flag1") = 1
                Session("flag2") = 0
            ElseIf Dr.Item("flag2") Is System.DBNull.Value Then
                Session("flag2") = 1
                Session("flag1") = 0
            End If
        Else
            Session("Sal_Flag") = 0
        End If
        Dr.Close()
        ob.closecn()
        ob.opencn()
        qry = "select *, case when byear_flag1 <> year(getdate()) and byear_flag2 <> year(getdate()) then 1 when byear_flag1 = year(getdate()) and byear_flag2 <> year(getdate()) then 2 else 0 end as Bflag from jct_empmast_base  where  ((Month(dob) = Month(getdate()) and day(dob)=day(getdate())) or (Month(dob) = Month(getdate()-1) and day(dob)=day(getdate()-1)))  and empcode='" & Session("Empcode") & "' and active='y' and (BYear_Flag1 <> year(getdate()) or BYear_Flag2 <> year(getdate())) and  Company_Code='" & Session("Companycode") & " '"
        cmd = New SqlCommand(qry, ob.cn)
        Dr = cmd.ExecuteReader
        If Dr.HasRows = True Then
            Session("Birth_Flag") = 1
            Dr.Read()
            Session("Bflag") = Dr.Item("bflag")
        Else
            Session("Birth_Flag") = 0
        End If
        Dr.Close()
        ob.closecn()

        'If PageL = 1 Then
        '    ob.opencn()
        '    'Session("Task") = Session("Task") + 1
        '    qry = "insert into JCT_Emp_Login_Hit values ('JCT00LTD','" & Session("Empcode") & "',getdate())"
        '    cmd = New SqlCommand(qry, ob.cn)
        '    cmd.ExecuteNonQuery()
        '    ob.closecn()

        '    If Session("Allowance") = 1 Then
        '        Response.Redirect("ScooterMsg.aspx")
        '    ElseIf Session("Sal_Flag") = 1 Then
        '        Response.Redirect("SalaryMsg.aspx")
        '    ElseIf Session("Birth_Flag") = 1 Then
        '        Response.Redirect("Birthday_Card.aspx")
        '    Else
        '        Response.Redirect("default.aspx")
        '    End If


        'ElseIf PageL = 2 Then
        '    ob.opencn()
        '    'Session("Task") = Session("Task") + 1
        '    qry = "insert into JCT_Emp_Login_Hit values ('JCT00LTD','" & Session("Empcode") & "',getdate())"
        '    cmd = New SqlCommand(qry, ob.cn)
        '    cmd.ExecuteNonQuery()
        '    ob.closecn()
        '    If Session("Allowance") = 1 Then
        '        Response.Redirect("ScooterMsg.aspx")
        '    ElseIf Session("Sal_Flag") = 1 Then
        '        Response.Redirect("SalaryMsg.aspx")
        '    ElseIf Session("Birth_Flag") = 1 Then
        '        Response.Redirect("Birthday_Card.aspx")
        '    Else
        '        Response.Redirect("ChangePassword.aspx")
        '    End If
        'End If
        If PageL = 1 Then
            If Session("Allowance") = 1 Then
                Response.Redirect("ScooterMsg.aspx")
                'Response.Redirect("frminternet_connection.aspx")
            ElseIf Session("Sal_Flag") = 1 Then
                Response.Redirect("SalaryMsg.aspx")
                'Response.Redirect("frminternet_connection.aspx")
            ElseIf Session("Birth_Flag") = 1 Then
                Response.Redirect("Birthday_Card.aspx")
            Else
                'Response.Redirect("frminternet_connection.aspx")
                Response.Redirect("emp_home.aspx")
            End If
        ElseIf PageL = 2 Then
            If Session("Allowance") = 1 Then
                Response.Redirect("ScooterMsg.aspx")
                'Response.Redirect("frminternet_connection.aspx")
            ElseIf Session("Sal_Flag") = 1 Then
                Response.Redirect("SalaryMsg.aspx")
                'Response.Redirect("frminternet_connection.aspx")
            ElseIf Session("Birth_Flag") = 1 Then
                Response.Redirect("Birthday_Card.aspx")
                'Response.Redirect("frminternet_connection.aspx")
            End If
        End If
    End Sub
Protected Sub CheckSystem()

        Dim ofn As Functions = New Functions

        Dim Host_IP As String = Request.ServerVariables("REMOTE_ADDR")


        Dim sql As String = "select HOST_NAME() "
        Dim Host_name As String = ofn.FetchValue(sql)

        Dim sqlstr As String = "JCT_LOGIN_ALERT"
        Dim cn As New Connection
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 16)
        cmd.Parameters("@UserCode").Value = Session("Empcode")

        cmd.Parameters.Add("@HName", SqlDbType.VarChar, 16)
        cmd.Parameters("@HName").Value = Host_name

        cmd.Parameters.Add("@HIp", SqlDbType.VarChar, 16)
        cmd.Parameters("@HIp").Value = Host_IP

        cn.ConOpen()
        cmd.ExecuteNonQuery()
        cn.ConClose()

    End Sub


End Class
