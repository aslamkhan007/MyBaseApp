Imports System.Data
Imports System.Data.SqlClient

Partial Class _Login
    Inherits System.Web.UI.Page
    Public Name, Login As String
    Dim Obj As Connection = New Connection
    Dim SqlPass As String
    Public Cmd As New SqlCommand

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label1.Visible = False
        Label2.Visible = False
        Dim Pass As New MsgBoxResult

        If CheckUser() = 1 Then
            Exit Sub
        End If

        If CheckPassword() = 1 Then
            Exit Sub
        End If

        Me.Page.Visible = False
        Session("Authorised") = True


        If CheckUser() = 1 Or CheckPassword() = 1 Then
        Else
            Response.Redirect("Default.aspx")
        End If

    End Sub

    Public Function CheckUser() As Integer
        Dim SqlPass = "select empname from jct_login_emp where empcode='" & Trim(Me.txtusername.Text) & "' and active = 'Y' and  Company_Code='" & Session("Location") & " '"
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)

        Try
            If Dr.HasRows = False Then
                Label1.Visible = True
                Label1.Text = "*"
                txtusername.Focus()
                Message.Text = "Enter Correct Salary Code"
                CheckUser = 1
            Else
                While Dr.Read()
                    Name = Dr.Item("Empname")
                End While
            End If
        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try

    End Function

    Public Function CheckPassword() As Integer
        Dim SqlPass = "select empname  from jct_login_emp where empcode='" & Trim(Me.txtusername.Text) & "' and active = 'Y' and ((convert(varchar(8),dateofbirth,112)='" & Trim(Me.txtpassword.Text) & " ' and  new_pass is null)  or (new_pass is not null and new_pass=convert(varchar(30),convert(varbinary,'" & Trim(Me.txtpassword.Text) & "')))) and  Company_Code='" & Session("Location") & " '"
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)

        Try
            If Dr.HasRows = False Then

                Label2.Visible = True
                Label2.Text = "*"
                txtpassword.Focus()
                Message.Text = "Enter Correct Password"
                CheckPassword = 1
            Else
                Login = Me.txtusername.Text
                Dr.Close()

                  Dim SqlPass1 = "select top 1 a.deptcode,house_no,cardno,b.deptname,a.Empcode,empname,dob,replace(replace(desg,'<',''),'>','') as desg,Mr_Mrs  from jctdev..jct_empmast_base a, jctdev..deptmast b  where a.deptcode=b.deptcode and  a.empcode='" & Trim(Me.txtusername.Text) & "' and  a.Company_Code='" & Session("Location") & " ' and b.Company_Code='" & Session("Location") & " '"
                Dim Dr1 As SqlDataReader = Obj.FetchReader(SqlPass1)

                If Dr1.HasRows = True Then
                    While Dr1.Read()
                        Session("cardno") = Dr1.Item("cardno")
                        Session("Empname") = Dr1.Item("EmpName")
                        Session("Empcode") = Dr1.Item("Empcode")
                        Session("Desg") = Dr1.Item("Desg")
                        Session("Dob") = Dr1.Item("Dob")
                        Session("Deptname") = Dr1.Item("DeptName")
                        Session("Company") = ddlCompany.SelectedValue
                        Session("Loc") = Me.ddlLocation.Text

                        If Dr1.Item("Mr_Mrs") Is System.DBNull.Value Then
                            Session("Mr_Mrs") = ""
                        Else
                            Session("Mr_Mrs") = Dr1.Item("Mr_Mrs")
                        End If

                        If Dr1.Item("house_no") Is System.DBNull.Value Then
                            Session("housetype") = ""
                        Else
                            Session("housetype") = Dr1.Item("house_no")
                        End If

                        Session("deptcode") = Dr1.Item("deptcode")
                    End While
                End If

            End If
        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        txtpassword.Attributes.Add("onFocus", "DoFocus(this);")
        txtpassword.Attributes.Add("onBlur", "DoBlur(this);")
        txtusername.Attributes.Add("onFocus", "DoFocus(this);")
        txtusername.Attributes.Add("onBlur", "DoBlur(this);")
        'Me.ddlCompany.Attributes.Add("onFocus", "DoFocus(this);")
        'Me.ddlCompany.Attributes.Add("onBlur", "DoBlur(this);")
        'Me.ddlLocation.Attributes.Add("onFocus", "DoFocus(this);")
        'Me.ddlLocation.Attributes.Add("onBlur", "DoBlur(this);")
        txtpassword.Attributes.Add("onkeypress", "return clickButton(event,'" + Button1.ClientID + "')")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(Now.AddSeconds(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")
        Session("empcode") = ""
        If Not IsPostBack Then
            ddlCompany.Items.Clear()
            SqlPass = "select CompanyCode,CompanyName from jctgen..JCT_Company_Master where getdate() between Eff_From and Eff_To and status<>'D' order by CompanyName"
            FillList(ddlCompany, SqlPass)
            ddlCompany.SelectedIndex = 0
        End If
        '----------------
        CheckLocation()
        '----------------
        If IsPostBack = False Then
            Me.txtusername.Focus()
        End If
    End Sub
    Public Sub CheckLocation()

        Dim SqlPass = "SELECT company_code FROM  company_master WHERE Location='" & Trim(Me.ddlLocation.Text) & "' "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)

        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    Session("Location") = Dr.Item("company_code")
                End While
            End If
        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try

    End Sub

End Class
