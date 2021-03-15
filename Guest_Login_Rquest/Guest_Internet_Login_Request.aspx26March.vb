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
        End If
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
    '                Sql = "Insert into jct_Guest_Internet_Request(IP,Name,Email,mobile,Company,Visiting_Department,Visiting_Employee,DateofVisiting,StayDays,PurposeOfVisit,SubmitTime,RequestID,Status)values('" & Request.ServerVariables("REMOTE_ADDR") & "' , " & _
    '                            " '" & txtName.Text & "','" & txtEmail.Text & "' ,'" & txtMobile.Text & "','" & txtCompany.Text & "' ," & Department & "," & Employee & " ,'" & txtDate.Text & "'," & txtStay.Text & ",'" & txtPurpose.Text & "',getdate()," & RequestID & " ,'A' )"
    '                If obj1.InsertRecord(Sql) = True Then
    '                    lblerror.Text = "Your Request ID is : " & RequestID
    '                    Dim msg As String = "Please note down your Request ID  : " & RequestID
    '                    ShowAlertMsg(msg)
    '                    Panel2.Visible = True
    '                    Generate_SecurityCode()
    '              
    '                    Dim msg1 As String = "Your " & SecurityCode & " for the Month of " & SecurityCode & " has been transferred to your bank account."
    '                    Dim mobile As String = txtMobile.Text
    '                    lblerror.Text = SecurityCode
    '                    Sql = "Select distinct a.empcode from jct_empmast_base a inner join deptmast b on a.deptcode=b.deptcode where a.active='Y' and a.empname =(Select Visiting_Employee from jct_Guest_Internet_Request where RequestID =" & RequestID & ") and b.Deptname = (Select Visiting_Department from jct_Guest_Internet_Request where RequestID =" & RequestID & ")"
    '                    Dim empcode As String = obj1.FetchValue(Sql)
    '                End If
    '            End If
    '        ElseIf Button1.Text = "Get Password" Then

    '            Sql = "Insert into jct_Guest_Internet_Request(IP,Name,Email,mobile,Company,Visiting_Department,Visiting_Employee,DateofVisiting,StayDays,PurposeOfVisit,SubmitTime,RequestID,Status)values('" & Request.ServerVariables("REMOTE_ADDR") & "' , " & _
    '                             " '" & txtName.Text & "','" & txtEmail.Text & "' ,'" & txtMobile.Text & "','" & txtCompany.Text & "' ," & Department & "," & Employee & ",'" & txtDate.Text & "'," & txtStay.Text & ",'" & txtPurpose.Text & "',getdate()," & RequestID & " ,'A' )"
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
        Sql = "select charindex(':','" & txtEmployee.Text & "')"
        If obj1.FetchValue(Sql) = 0 Then
            panel4.visible = False
            Dim error2 As String = "Please Select Employee and Do not delete any detail from Employee TextBox."
            ShowAlertMsg(error2)
            txtEmployee.Focus()
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
                        Sql = "Insert into jct_Guest_Internet_Request(IP,Name,Email,mobile,Company,Visiting_Department,Visiting_Employee,DateofVisiting,StayDays,PurposeOfVisit,SubmitTime,RequestID,Status)values('" & Request.ServerVariables("REMOTE_ADDR") & "' , " & _
                                    " '" & txtName.Text & "','" & txtEmail.Text & "' ,'" & txtMobile.Text & "','" & txtCompany.Text & "' ," & Department & "," & Employee & " ,'" & txtDate.Text & "'," & txtStay.Text & ",'" & txtPurpose.Text & "',getdate()," & RequestID & " ,'A' )"
                        If obj1.InsertRecord(Sql) = True Then
                            lblerror.Text = "Your Request ID is : " & RequestID
                            Dim msg As String = "Please note down your Request ID  : " & RequestID
                            ShowAlertMsg(msg)
                            Panel2.Visible = True
                            Generate_SecurityCode()

                            Dim msg1 As String = "Your Security Code is " & SecurityCode & " with reference ID " & RequestID & ". Please enter security code to receive the login details"
                            Dim mobile As String = txtMobile.Text
                            sm.SendMail("jatindutta@jctltd.com", "it.helpdesk@jctltd.com", "Request For Internet Access", "This message is to info during your stay here. This password will be available only for your stay here and not for future. For any problem regarding same issue please contact us with RequestID=" & ViewState("RequestID") & " . This RequestID is important for any future queries. Thanks for your time and Welcome To JCT Family..!!")
                            'sm.SendMail("harendra@jctltd.com", "it.helpdesk@jctltd.com", "Request For Internet Access", "This message is to inform you that your request to access the internet service of JCT Mills has been accepted and you can login with username ='" & dr1(1) & "' and Password='" & dr1(2) & "' during your stay here. This password will be available only for your stay here and not for future. For any problem regarding same issue please contact us with RequestID=" & RequestID & " . This RequestID is important for any future queries. Thanks for your time and Welcome To JCT Family..!!")
                            Dim email As String = txtEmail.Text
                            lblerror.Text = msg
                            ' lblerror.Text = SecurityCode
                            sm.SendSMS("JCTLTD", "IT-Help", mobile, msg1, "Security Code ")

                            Sql = "Select distinct a.empcode from jct_empmast_base a inner join deptmast b on a.deptcode=b.deptcode where a.active='Y' and a.empname =(Select Visiting_Employee from jct_Guest_Internet_Request where RequestID =" & ViewState("RequestID") & ") and b.Deptname = (Select Visiting_Department from jct_Guest_Internet_Request where RequestID =" & ViewState("RequestID") & ")"
                            Dim empcode As String = obj1.FetchValue(Sql)
                        End If
                    End If
                ElseIf Button1.Text = "Get Password" Then

                    Sql = "Insert into jct_Guest_Internet_Request(IP,Name,Email,mobile,Company,Visiting_Department,Visiting_Employee,DateofVisiting,StayDays,PurposeOfVisit,SubmitTime,RequestID,Status)values('" & Request.ServerVariables("REMOTE_ADDR") & "' , " & _
                                     " '" & txtName.Text & "','" & txtEmail.Text & "' ,'" & txtMobile.Text & "','" & txtCompany.Text & "' ," & Department & "," & Employee & ",'" & txtDate.Text & "'," & txtStay.Text & ",'" & txtPurpose.Text & "',getdate()," & RequestID & " ,'A' )"
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
            '                Sql = "Insert into jct_Guest_Internet_Request(IP,Name,Email,mobile,Company,Visiting_Department,Visiting_Employee,DateofVisiting,StayDays,PurposeOfVisit,SubmitTime,RequestID,Status)values('" & Request.ServerVariables("REMOTE_ADDR") & "' , " & _
            '                            " '" & txtName.Text & "','" & txtEmail.Text & "' ,'" & txtMobile.Text & "','" & txtCompany.Text & "' ," & Department & "," & Employee & " ,'" & txtDate.Text & "'," & txtStay.Text & ",'" & txtPurpose.Text & "',getdate()," & RequestID & " ,'A' )"
            '                If obj1.InsertRecord(Sql) = True Then
            '                    lblerror.Text = "Your Request ID is : " & RequestID
            '                    Dim msg As String = "Please note down your Request ID  : " & RequestID & " And Contact IT-HelpDesk @ 4212"
            '                    ShowAlertMsg(msg)
            '                    Panel2.Visible = False
            '                    ' Generate_SecurityCode()
            '              
            '                    ' Dim msg1 As String = "Your Security Code is " & SecurityCode & " with reference ID " & RequestID & ". Please enter security code in the form to receive the login details"
            '                    ' Dim mobile As String = txtMobile.Text
            '                    ' lblerror.Text = SecurityCode
            '                    Sql = "Select distinct a.empcode from jct_empmast_base a inner join deptmast b on a.deptcode=b.deptcode where a.active='Y' and a.empname =(Select Visiting_Employee from jct_Guest_Internet_Request where RequestID =" & RequestID & ") and b.Deptname = (Select Visiting_Department from jct_Guest_Internet_Request where RequestID =" & RequestID & ")"
            '                    Dim empcode As String = obj1.FetchValue(Sql)
            '                End If
            '            End If
            '        ElseIf Button1.Text = "Get Password" Then

            '            Sql = "Insert into jct_Guest_Internet_Request(IP,Name,Email,mobile,Company,Visiting_Department,Visiting_Employee,DateofVisiting,StayDays,PurposeOfVisit,SubmitTime,RequestID,Status)values('" & Request.ServerVariables("REMOTE_ADDR") & "' , " & _
            '                             " '" & txtName.Text & "','" & txtEmail.Text & "' ,'" & txtMobile.Text & "','" & txtCompany.Text & "' ," & Department & "," & Employee & ",'" & txtDate.Text & "'," & txtStay.Text & ",'" & txtPurpose.Text & "',getdate()," & RequestID & " ,'A' )"
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
                        'sm.SendMail("it.helpdesk@jctltd.com", "it.helpdesk@jctltd.com", "Guest Login Request", "  '" & txtName.Text & "' is a new guest in JCT which has applied for the internet connection and has been alloted a new username = '" & dr(1) & "' and password='" & dr(2) & "' under RequestID=" & RequestID & " .This msg is just to inform you. ")
                        sm.SendMail("jatindutta@jctltd.com", "it.helpdesk@jctltd.com", "Guest Login Request", "This message is to info during your stay here. This password will be available only for your stay here and not for future. For any problem regarding same issue please contact us with RequestID=" & ViewState("RequestID") & " . This RequestID is important for any future queries. Thanks for your time and Welcome To JCT Family..!!")
                        ' sm.SendMail("harendra@jctltd.com", "it.helpdesk@jctltd.com", "Guest Login Request", "This message is to info during your stay here. This password will be available only for your stay here and not for future. For any problem regarding same issue please contact us with RequestID=" & ViewState("RequestID") & " . This RequestID is important for any future queries. Thanks for your time and Welcome To JCT Family..!!")
                        ' sm.SendMail("jatindutta@jctltd.com", "it.helpdesk@jctltd.com", "Guest Login Request", "  '" & txtName.Text & "' is a new guest in JCT which has applied for the internet connection and has been alloted a new username = '" & lblUserName.Text & "' and password='" & lblPassword.Text & "' under RequestID=" & ViewState("RequestID") & " .This msg is just to inform you. ")
                        Dim email As String = txtEmail.Text
                        Dim mobile As String = txtMobile.Text
                        Dim msg As String = "Account successfully created. Your username is " & lblUserName.Text & " and password is " & lblPassword.Text & ". Please login with above details."

                        ' "Your " & dr1(1) & " for the Month of " & dr1(2) & " has been transferred to your bank account."
                        ' sm.SendMail(email, "it.helpdesk@jctltd.com", "Request For Internet Access", "This message is to inform you that your request to access the internet service of JCT Mills has been accepted and you can login with username ='" & lblUserName.Text & "' and Password='" & lblPassword.Text & "' during your stay here. This password will be available only for your stay here and not for future. For any problem regarding same issue please contact us with RequestID=" & ViewState("RequestID") & " . This RequestID is important for any future queries. Thanks for your time and Welcome To JCT Family..!!")
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
                lblerror.Text = "Wrong Security Code enetered. Please Try again..!!"
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

                    '  sm.SendMail("it.helpdesk@jctltd.com", "it.helpdesk@jctltd.com", "Guest Login Request", "  '" & txtName.Text & "' is a new guest in JCT which has applied for the internet connection and has been alloted a new username = '" & lblUserName.Text & "' and password='" & lblPassword.Text & "' under RequestID=" & ViewState("RequestID") & " .This msg is just to inform you. ")
                    '   sm.SendMail("harendra@jctltd.com", "it.helpdesk@jctltd.com", "Guest Login Request", "This message is to info during your stay here. This password will be available only for your stay here and not for future. For any problem regarding same issue please contact us with RequestID=" & ViewState("RequestID") & " . This RequestID is important for any future queries. Thanks for your time and Welcome To JCT Family..!!")
                    sm.SendMail("jatindutta@jctltd.com", "it.helpdesk@jctltd.com", "Guest Login Request", "  '" & txtName.Text & "' is a new guest in JCT which has applied for the internet connection and has been alloted a new username = '" & lblUserName.Text & "' and password='" & lblPassword.Text & "' under RequestID=" & ViewState("RequestID") & " .This msg is just to inform you. ")
                    Dim email As String = txtEmail.Text
                    Dim mobile As String = txtMobile.Text
                    Dim msg As String = "Account successfully created. Your username is " & dr1(1) & " and password is " & dr1(2) & " .Please login with above details."
                    '  sm.SendMail(email, "it.helpdesk@jctltd.com", "Request For Internet Access", "This message is to inform you that your request to access the internet service of JCT Mill has been accepted and you can login with username ='" & dr1(1) & "' and Password='" & dr1(2) & "' during your stay here. This password will be available only for your stay here and not for future. For any problem regarding same issue please contact us with RequestID=" & RequestID & " . This RequestID is important for any future queries. Thanks for your time and Welcome To JCT Family..!!")
                    sm.SendSMS("JCTLTD", "IT-Help", mobile, msg, "Login Details")
                End While
                dr1.Close()
                Panel1.Visible = True
                Sql = "Update Jct_Guest_Internet_LoginDetail set Status='A', UsedBy_Guest ='" & txtName.Text & "' , UsedDate ='" & txtDate.Text & "' ,RequestID=" & ViewState("RequestID") & " where Status='A' and trans_no =" & trans_no.Text & ""
                obj1.UpdateRecord(Sql)
                Sql = "Update Jct_Guest_Internet_LoginDetail set SecurityCode = " & ViewState("RequestID") & " where Trans_no=" & trans_no.Text & ""
                obj1.UpdateRecord(Sql)
            Else
                lblerror.Visible = True
                lblEnquiry.Visible = True
            End If
        End If

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtRegMobile.Text <> "" Then
            Sql = "Select Name,Email,Mobile,Company from  jct_Guest_Internet_Request where mobile=" & txtRegMobile.Text & ""
            If obj1.CheckRecordExistInTransaction(Sql) = True Then
                dr = obj1.FetchReader(Sql)
                While dr.Read
                    txtName.Text = dr(0)
                    txtEmail.Text = dr(1)
                    txtMobile.Text = dr(2)
                    txtCompany.Text = dr(3)
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










