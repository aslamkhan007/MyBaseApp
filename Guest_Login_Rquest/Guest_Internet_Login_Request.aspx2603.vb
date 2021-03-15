Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql

Partial Class Guest_Login_Rquest_Guest_Internet_Login_Request
    Inherits System.Web.UI.Page
    Dim Sql As String
    Dim Conn As Connection = New Connection()
    Dim obj1 As Functions = New Functions
    Dim RequestID As Integer
    Dim dr As SqlDataReader
    Dim Tran As SqlTransaction
    Dim SecurityCode As Integer
    Dim Ran As Random = New Random()
    Dim cmd As SqlCommand
    Dim sm As New SendMail()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            'Sql = "select DeptCode,DeptName from deptmast where company_code='JCT00LTD' order by DeptName"
            'obj1.FillList(ddlDepartment, Sql)
            'Sql = "Select empcode,empname from jct_empmast_base where active='Y' and deptcode='" & ddlDepartment.SelectedItem.Value & "' and Assosc_Flag='E'"
            'obj1.FillList(ddlEmployee, Sql)
            If Panel1.Visible = True Then
                Panel1.Visible = False
            End If
            If lblerror.Visible = True Then
                lblerror.Visible = False
                lblEnquiry.Visible = False
            End If
            txtDate_CalendarExtender.SelectedDate = DateTime.Today
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "setMinDateOnSecondControl", "function setMinDateOnSecondControl(e) { document.getElementById('" + txtDate.ClientID + "').dateSelectionChanged += function x(e) { alert(e);} ; }", True)
        End If
        Button1.Enabled = True
    End Sub
    ' Modified by jatin on 23 feb 2012
    'Protected Sub ddlDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepartment.SelectedIndexChanged
    '    Sql = "Select empcode,empname from jct_empmast_base where active='Y' and deptcode='" & ddlDepartment.SelectedItem.Value & "' and Assosc_Flag='E'"
    '    obj1.FillList(ddlEmployee, Sql)
    'End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Generate_RequestID()
    '    Conn.ConOpen()
    '    Panel3.Visible = True
    '    Panel4.Visible = False
    '    Dim Department As String = "Right(right('" & txtEmployee.Text & "',charindex(':',reverse('" & txtEmployee.Text & "'),-1)),Len(right('" & txtEmployee.Text & "',charindex(':',reverse('" & txtEmployee.Text & "'),-1))) -1  )"
    '    Dim Employee As String = "Left(Substring('" & txtEmployee.Text & "',1,charindex(':','" & txtEmployee.Text & "')),Len(Substring('" & txtEmployee.Text & "',1,charindex(':','" & txtEmployee.Text & "')))-1)"

    '    Try
    '        If Button1.Text = "Submit" Then

    '            Sql = "Select * from jct_Guest_Internet_Request where name ='" & txtName.Text & "' and company = '" & txtCompany.Text & "' and mobile=" & txtMobile.Text & " "
    '            If obj1.CheckRecordExistInTransaction(Sql) = True Then
    '                lblerror.Text = "User already exists..!!"
    '                lblerror.Visible = True
    '                lblEnquiry.Visible = True
    '            Else
    '                'Tran = Conn.Connection.BeginTransaction
    '                Sql = "Insert into jct_Guest_Internet_Request(IP,Name,Email,mobile,Company,Visiting_Department,Visiting_Employee,Stay_Upto,StayDays,PurposeOfVisit,SubmitTime,RequestID,Status)values('" & Request.ServerVariables("REMOTE_ADDR") & "' , " & _
    '                            " '" & txtName.Text & "','" & txtEmail.Text & "' ,'" & txtMobile.Text & "','" & txtCompany.Text & "' ," & Department & "," & Employee & " ,'" & txtDate.Text & "'," & txtDate.Text & "  -  " & DateTime.Today & " ,'" & txtPurpose.Text & "',getdate()," & RequestID & " ,'A' )"
    '                If obj1.InsertRecord(Sql) = True Then
    '                    lblerror.Text = "Your Request ID is : " & RequestID
    '                    Dim msg As String = "Please note down your Request ID  : " & RequestID
    '                    ShowAlertMsg(msg)
    '                    Panel2.Visible = True
    '                    Generate_SecurityCode()
    '               
    '                   Dim msg1 As String = "Your Security Code is " & SecurityCode & " with reference ID " & RequestID & ". Please enter security code in the form so as to receive the login details"
    '                    Dim mobile As String = txtMobile.Text
    '                    lblerror.Text = SecurityCode
    '                    Sql = "Select distinct a.empcode from jct_empmast_base a inner join deptmast b on a.deptcode=b.deptcode where a.active='Y' and a.empname =(Select Visiting_Employee from jct_Guest_Internet_Request where RequestID =" & RequestID & ") and b.Deptname = (Select Visiting_Department from jct_Guest_Internet_Request where RequestID =" & RequestID & ")"
    '                    Dim empcode As String = obj1.FetchValue(Sql)
    '                End If
    '            End If
    '        ElseIf Button1.Text = "Get Password" Then

    '            Sql = "Insert into jct_Guest_Internet_Request(IP,Name,Email,mobile,Company,Visiting_Department,Visiting_Employee,Stay_Upto,StayDays,PurposeOfVisit,SubmitTime,RequestID,Status)values('" & Request.ServerVariables("REMOTE_ADDR") & "' , " & _
    '                             " '" & txtName.Text & "','" & txtEmail.Text & "' ,'" & txtMobile.Text & "','" & txtCompany.Text & "' ," & Department & "," & Employee & ",'" & txtDate.Text & "'," & txtDate.Text & "  -  " & DateTime.Today & " ,'" & txtPurpose.Text & "',getdate()," & RequestID & " ,'A' )"
    '            If obj1.InsertRecord(Sql) = True Then
    '                lblerror.Text = "Your Request ID is : " & RequestID
    '                Dim msg As String = "Please note down your Request ID  : " & RequestID
    '                ShowAlertMsg(msg)
    '                btnSubmitCode_Click(sender, e)
    '            End If
    '            End If

    '    Catch ex As Exception
    '        lblerror.Text = "error"
    '    Finally
    '        Conn.ConClose()
    '    End Try
    'End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Button1.Enabled = False
        '  Sql = "select *  from jct_Guest_Internet_Request where   Convert(datetime,Convert(varchar(15),getdate(),103),103) <= Convert(datetime,Convert(varchar(15),stay_upto,103),103)  and trans_no=(select max(trans_no) from jct_Guest_Internet_Request where mobile=" & txtMobile.Text & " ) and status='A' "
        Sql = "select b.username,b.password  from jct_Guest_Internet_Request a inner join Jct_Guest_Internet_LoginDetail b on Convert(datetime,Convert(varchar(15),getdate(),103),103) <= Convert(datetime,Convert(varchar(15),a.stay_upto,103),103) and a.status=b.status and a.requestid=b.requestid where  a.trans_no=(select max(trans_no) from jct_Guest_Internet_Request where mobile=" & txtMobile.Text & " ) and a.status='A'"
        If obj1.CheckRecordExistInTransaction(Sql) = False Then
            Sql = "select charindex(':','" & txtEmployee.Text & "')"
            If obj1.FetchValue(Sql) = 0 Then
                Panel4.Visible = False
                Dim error2 As String = "Please Select Employee and Do not delete any detail from Employee TextBox."
                ShowAlertMsg(error2)
                txtEmployee.Focus()
                Button1.Enabled = True
            Else

                Sql = "select substring ('" & ViewState("IPAddress") & "',8,charindex('.',Reverse('" & ViewState("IPAddress") & "'),-1))"
                Dim IP As String = obj1.FetchValue(Sql)
                ' If IP = ".22" Then
                Generate_RequestID()
                Conn.ConOpen()
                Panel3.Visible = True
                Panel4.Visible = False

                Dim Department As String = "Right(right('" & txtEmployee.Text & "',charindex(':',reverse('" & txtEmployee.Text & "'),-1)),Len(right('" & txtEmployee.Text & "',charindex(':',reverse('" & txtEmployee.Text & "'),-1))) -1  )"
                Dim Employee As String = "Left(Substring('" & txtEmployee.Text & "',1,charindex(':','" & txtEmployee.Text & "')),Len(Substring('" & txtEmployee.Text & "',1,charindex(':','" & txtEmployee.Text & "')))-1)"

                Try
                    If Button1.Text = "Submit" Then

                        Sql = "Select * from jct_Guest_Internet_Request where name ='" & txtName.Text & "' and company = '" & txtCompany.Text & "' and mobile=" & txtMobile.Text & " "
                        If obj1.CheckRecordExistInTransaction(Sql) = True Then
                            lblerror.Text = "User already exists..!!"
                            lblerror.Visible = True
                            lblEnquiry.Visible = True
                        Else
                            'Tran = Conn.Connection.BeginTransaction
                            Sql = "Insert into jct_Guest_Internet_Request(IP,Name,Email,mobile,Company,Visiting_Department,Visiting_Employee,Stay_Upto,StayDays,PurposeOfVisit,SubmitTime,RequestID,Status,CountryCode)values('" & Request.ServerVariables("REMOTE_ADDR") & "' , " & _
                                        " '" & txtName.Text & "','" & txtEmail.Text & "' ,'" & txtMobile.Text & "','" & txtCompany.Text & "' ," & Department & "," & Employee & " ,'" & txtDate.Text & "'," & txtDate.Text & "  -  " & DateTime.Today & " ,'" & txtPurpose.Text & "',getdate()," & RequestID & " ,'A','" & txtCountryCode.Text & "' )"
                            If obj1.InsertRecord(Sql) = True Then
                                lblerror.Text = "Your Request ID is : " & RequestID
                                Dim msg As String = "Please note down your Request ID  : " & RequestID
                                ShowAlertMsg(msg)
                                Panel2.Visible = True
                                lblmsgError.Text = "Please wait for 2-3 minutes to recieve Security Code in your mobile number."
                                Generate_SecurityCode()
                                Dim msg1 As String = "Your Security Code is " & SecurityCode & " with reference ID " & RequestID & ". Please enter security code to receive the login details"
                                Dim mobile As String = txtMobile.Text
                                ' sm.SendMail_ITHelpdesk(txtEmail.Text, "it.helpdesk@jctltd.com", "Request For Internet Access", "For any problem regarding same issue please contact us with RequestID=" & ViewState("RequestID") & " . This RequestID is important for any future queries. Thanks for your time and Welcome To JCT Family..!!")
                                Dim email As String = txtEmail.Text
                                lblerror.Text = msg
                                '  lblerror.Text = SecurityCode
                                sm.SendSMS("JCTLTD", "IT-Help", mobile, msg1, "Security Code ")
                                Sql = "Select distinct a.empcode from jct_empmast_base a inner join deptmast b on a.deptcode=b.deptcode where a.active='Y' and a.empname =(Select Visiting_Employee from jct_Guest_Internet_Request where RequestID =" & ViewState("RequestID") & ") and b.Deptname = (Select Visiting_Department from jct_Guest_Internet_Request where RequestID =" & ViewState("RequestID") & ")"
                                Dim empcode As String = obj1.FetchValue(Sql)
                            End If
                        End If
                    ElseIf Button1.Text = "Get Password" Then
                        Sql = "Insert into jct_Guest_Internet_Request(IP,Name,Email,mobile,Company,Visiting_Department,Visiting_Employee,Stay_Upto,StayDays,PurposeOfVisit,SubmitTime,RequestID,Status,CountryCode)values('" & Request.ServerVariables("REMOTE_ADDR") & "' , " & _
                                         " '" & txtName.Text & "','" & txtEmail.Text & "' ,'" & txtMobile.Text & "','" & txtCompany.Text & "' ," & Department & "," & Employee & ",'" & txtDate.Text & "'," & txtDate.Text & "  -  " & DateTime.Today & " ,'" & txtPurpose.Text & "',getdate()," & RequestID & " ,'A','" & txtCountryCode.Text & "' )"
                        If obj1.InsertRecord(Sql) = True Then
                            lblerror.Text = "Your Request ID is : " & RequestID
                            Dim msg As String = "Please note down your Request ID  : " & RequestID
                            ShowAlertMsg(msg)
                            btnSubmitCode_Click(sender, e)
                        End If
                    End If

                Catch ex As Exception
                    lblerror.Text = "error"
                Finally
                    Conn.ConClose()
                End Try

                'Else
                '    Generate_RequestID()
                '    Conn.ConOpen()
                '    Panel3.Visible = True
                '    Panel4.Visible = False

                '    Dim Department As String = "Right(right('" & txtEmployee.Text & "',charindex(':',reverse('" & txtEmployee.Text & "'),-1)),Len(right('" & txtEmployee.Text & "',charindex(':',reverse('" & txtEmployee.Text & "'),-1))) -1  )"
                '    Dim Employee As String = "Left(Substring('" & txtEmployee.Text & "',1,charindex(':','" & txtEmployee.Text & "')),Len(Substring('" & txtEmployee.Text & "',1,charindex(':','" & txtEmployee.Text & "')))-1)"

                '    Try
                '        If Button1.Text = "Submit" Then

                '            Sql = "Select * from jct_Guest_Internet_Request where name ='" & txtName.Text & "' and company = '" & txtCompany.Text & "' and mobile=" & txtMobile.Text & " "
                '            If obj1.CheckRecordExistInTransaction(Sql) = True Then
                '                lblerror.Text = "User already exists..!!"
                '                lblerror.Visible = True
                '                lblEnquiry.Visible = True
                '            Else
                '                'Tran = Conn.Connection.BeginTransaction
                '                Sql = "Insert into jct_Guest_Internet_Request(IP,Name,Email,mobile,Company,Visiting_Department,Visiting_Employee,Stay_Upto,StayDays,PurposeOfVisit,SubmitTime,RequestID,Status)values('" & Request.ServerVariables("REMOTE_ADDR") & "' , " & _
                '                            " '" & txtName.Text & "','" & txtEmail.Text & "' ,'" & txtMobile.Text & "','" & txtCompany.Text & "' ," & Department & "," & Employee & " ,'" & txtDate.Text & "'," & txtDate.Text & "  -  " & DateTime.Today & " ,'" & txtPurpose.Text & "',getdate()," & RequestID & " ,'A' )"
                '                If obj1.InsertRecord(Sql) = True Then
                '                    lblerror.Text = "Your Request ID is : " & RequestID
                '                    Dim msg As String = "Please note down your Request ID  : " & RequestID & " And Contact IT-HelpDesk @ 4212"
                '                    ShowAlertMsg(msg)
                '                    Panel2.Visible = False
                '                    Generate_SecurityCode()
                '                  
                '                    Dim msg1 As String = "Your Security Code is " & SecurityCode & " with referece ID " & RequestID & ". Please enter security code in the form so as to receive the login details."
                '                    ' "Your " & SecurityCode & " for the Month of " & SecurityCode & " has been transferred to your bank account."
                '                    Dim mobile As String = txtMobile.Text
                '                    lblerror.Text = SecurityCode
                '                    Sql = "Select distinct a.empcode from jct_empmast_base a inner join deptmast b on a.deptcode=b.deptcode where a.active='Y' and a.empname =(Select Visiting_Employee from jct_Guest_Internet_Request where RequestID =" & RequestID & ") and b.Deptname = (Select Visiting_Department from jct_Guest_Internet_Request where RequestID =" & RequestID & ")"
                '                    Dim empcode As String = obj1.FetchValue(Sql)
                '                End If
                '            End If
                '        ElseIf Button1.Text = "Get Password" Then

                '            Sql = "Insert into jct_Guest_Internet_Request(IP,Name,Email,mobile,Company,Visiting_Department,Visiting_Employee,Stay_Upto,StayDays,PurposeOfVisit,SubmitTime,RequestID,Status)values('" & Request.ServerVariables("REMOTE_ADDR") & "' , " & _
                '                             " '" & txtName.Text & "','" & txtEmail.Text & "' ,'" & txtMobile.Text & "','" & txtCompany.Text & "' ," & Department & "," & Employee & ",'" & txtDate.Text & "'," & txtDate.Text & "  -  " & DateTime.Today & " ,'" & txtPurpose.Text & "',getdate()," & RequestID & " ,'A' )"
                '            If obj1.InsertRecord(Sql) = True Then
                '                lblerror.Text = "Your Request ID is : " & RequestID
                '                Dim msg As String = "Please note down your Request ID  : " & RequestID
                '                ShowAlertMsg(msg)
                '                'btnSubmitCode_Click(sender, e)
                '            End If
                '        End If

                '    Catch ex As Exception
                '        lblerror.Text = "error"
                '    Finally
                '        Conn.ConClose()
                '    End Try
                'End If
            End If
        Else
            Panel1.Visible = True
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "error_msg", "alert('Only once login details can be issued to you .');", True)
            Sql = "select a.username,a.password,a.requestid  from Jct_Guest_Internet_LoginDetail a inner join jct_Guest_Internet_Request b on a.requestid=b.requestid and a.status=b.status  where a.status='A' and b.trans_no = (select max(trans_no) from jct_Guest_Internet_Request where mobile=" & txtMobile.Text & " and status='A')  "
            If obj1.CheckRecordExistInTransaction(Sql) = True Then
                Dim dr As SqlDataReader = obj1.FetchReader(Sql)
                While dr.Read()
                    lblUserName.Text = dr(0)
                    lblPassword.Text = dr(1)
                    lblRequestID.Text = dr(2)
                End While
            End If

        End If

    End Sub
    Public Sub ShowAlertMsg(ByVal error1 As String)
        Dim page As Page = TryCast(HttpContext.Current.Handler, Page)
        If page IsNot Nothing Then
            ' error1 = error1.Replace("'", "'")
            ScriptManager.RegisterStartupScript(page, page.[GetType](), "err_msg", "alert('" & error1 & "');", True)
        End If
    End Sub
    Public Function Generate_SecurityCode() As Integer
        SecurityCode = Ran.Next().ToString
        ViewState.Add("SecurityCode", SecurityCode)
        Return SecurityCode
    End Function
    Public Function Generate_RequestID() As Integer
        Sql = "Select isnull(max(requestId),0) from jct_Guest_Internet_Request where status='A' "
        If obj1.FetchValue(Sql) = 0 Then
            RequestID = 1000
            ViewState.Add("RequestID", RequestID)
        Else
            RequestID = obj1.FetchValue(Sql) + 1
            ViewState.Add("RequestID", RequestID)
        End If
        Return RequestID
    End Function

    Protected Sub btnSubmitCode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmitCode.Click


        Dim trans_no As Label = New Label
        If Button1.Text = "Submit" Then
            Dim code As Integer = txtCode.Text
            If ViewState("SecurityCode") = code Then
                Panel2.Visible = False
                Panel3.Visible = False
                Panel1.Visible = True
                Sql = "Select Top 1 Trans_no,username,Password from Jct_Guest_Internet_LoginDetail where status='A' and UsedBy_Guest is null and UsedDate is null and DeactivationDate is null "
                If obj1.CheckRecordExistInTransaction(Sql) = True Then
                    Dim dr1 As SqlDataReader
                    dr1 = obj1.FetchReader(Sql)
                    While dr1.Read()
                        lblRequestID.Text = ViewState("RequestID")
                        lblUserName.Text = dr1(1)
                        lblPassword.Text = dr1(2)
                        trans_no.Text = dr1(0)
                        sm.SendMail_ITHelpdesk(txtEmail.Text, "it.helpdesk@jctltd.com", "Guest Login Request", "  '" & txtName.Text & "' is a new guest in JCT which has applied for the internet connection and has been alloted a new username = '" & lblUserName.Text & "' and password='" & lblPassword.Text & "' under RequestID=" & ViewState("RequestID") & " .This msg is just to inform you. ")
                        Dim email As String = txtEmail.Text
                        Dim mobile As String = txtMobile.Text
                        Dim msg As String = "Account successfully created. Your username is " & lblUserName.Text & " and password is " & lblPassword.Text & ". Please login with above details."
                        sm.SendSMS("JCTLTD", "IT-Help", mobile, msg, "Login Details")

                    End While
                    dr1.Close()
                    Sql = "Update Jct_Guest_Internet_LoginDetail set Status='A', UsedBy_Guest ='" & txtName.Text & "' , UsedDate ='" & txtDate.Text & "' ,RequestID=" & ViewState("RequestID") & " where Status='A' and trans_no =" & trans_no.Text & ""
                    obj1.UpdateRecord(Sql)
                    Sql = "Update Jct_Guest_Internet_LoginDetail set SecurityCode = " & ViewState("SecurityCode") & " where Trans_no=" & trans_no.Text & ""
                    obj1.UpdateRecord(Sql)
                    Panel1.Visible = True

                Else
                    lblerror.Visible = True
                    lblEnquiry.Visible = True
                End If
            Else
                lblmsgError.Text = "Wrong Security Code entered. Please Try again..!!"
            End If
        ElseIf Button1.Text = "Get Password" Then
            Panel2.Visible = False
            Panel3.Visible = False
            Panel1.Visible = True
            Sql = "Select top 1 Trans_no,username,Password from Jct_Guest_Internet_LoginDetail where status='A' and UsedBy_Guest is null and UsedDate is null and DeactivationDate is null "
            If obj1.CheckRecordExistInTransaction(Sql) = True Then
                Dim dr1 As SqlDataReader
                dr1 = obj1.FetchReader(Sql)
                While dr1.Read()
                    lblRequestID.Text = ViewState("RequestID")
                    lblUserName.Text = dr1(1)
                    lblPassword.Text = dr1(2)
                    trans_no.Text = dr1(0)
                    sm.SendMail_ITHelpdesk(txtEmail.Text, "it.helpdesk@jctltd.com", "Guest Login Request", "  '" & txtName.Text & "' is a new guest in JCT which has applied for the internet connection and has been alloted a new username = '" & lblUserName.Text & "' and password='" & lblPassword.Text & "' under RequestID=" & ViewState("RequestID") & " .This msg is just to inform you. ")
                    Dim email As String = txtEmail.Text
                    Dim mobile As String = txtMobile.Text
                    Dim msg As String = "Account successfully created. Your username is " & dr1(1) & " and password is " & dr1(2) & ". Please login with above details."
                    sm.SendSMS("JCTLTD", "IT-Help", mobile, msg, "Login Details")
                End While
                dr1.Close()
                Sql = "Update Jct_Guest_Internet_LoginDetail set Status='A', UsedBy_Guest ='" & txtName.Text & "' , UsedDate ='" & txtDate.Text & "' ,RequestID=" & ViewState("RequestID") & " where Status='A' and trans_no =" & trans_no.Text & ""
                obj1.UpdateRecord(Sql)
                Sql = "Update Jct_Guest_Internet_LoginDetail set SecurityCode = " & ViewState("RequestID") & " where Trans_no=" & trans_no.Text & ""
                obj1.UpdateRecord(Sql)
                Panel1.Visible = True

            Else
                lblerror.Visible = True
                lblEnquiry.Visible = True
            End If
        End If

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtRegMobile.Text <> "" Then
            Sql = "Select Name,Email,Mobile,Company,Isnull(CountryCode,91) as CountryCode from  jct_Guest_Internet_Request where mobile=" & txtRegMobile.Text & " and trans_no = (select max(trans_no) from jct_Guest_Internet_Request where mobile=" & txtRegMobile.Text & ")"
            If obj1.CheckRecordExistInTransaction(Sql) = True Then
                dr = obj1.FetchReader(Sql)
                While dr.Read
                    txtName.Text = dr(0)
                    txtEmail.Text = dr(1)
                    txtMobile.Text = dr(2)
                    txtCompany.Text = dr(3)
                    txtCountryCode.Text = dr(4)
                    Button1.Text = "Get Password"
                    Panel4.Visible = False
                End While
            Else
                Panel4.Visible = False
                lblerror.Text = "No record Found."
                Panel3.Visible = True
            End If

        Else
            lblerror.Text = "No record Found."
            Panel3.Visible = True
            Panel4.Visible = False
        End If
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Response.Redirect("Guest_Internet_Login_Request.aspx")
    End Sub
End Class










