Imports System.Data.SqlClient
Imports System.Net.Mail.MailMessage
Imports System.Net.Mail.SmtpClient
Imports System.Data
Imports System.Net.Mail

Partial Class Payroll_Jct_Payroll_Leave_Application
    Inherits System.Web.UI.Page
    Dim strTo As String, strFrom As String, strSubject As String, SqlPass As String, Sqlpass1 As String, con As String
    Dim EmailTO, EmailTO1, EmailFrom, EmailCc, EmailBcc, EmailBcc1, Checkflag, Checkflag1 As String
    Dim CheckError As Boolean = False, CheckRecord As Boolean = False, CheckDate As Boolean = False
    Dim Auto1 As Int64, Difference As Integer, CountMail As Integer = 0
    Dim Obj As New Connection
    Dim Cmd As New SqlCommand
    Dim obj1 As Functions = New Functions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load        
        If (Session("Empcode").ToString <> "") Then
        Else
            Response.Redirect("~/login.aspx")
        End If
        If IsPostBack = False Then

            ModalPopupExtender1.Enabled = False
            ModalPopupExtender1.Hide()

            If mapping_check() = False Then

                ClientScript.RegisterClientScriptBlock(Me.GetType, "Day", "<script language = javascript>alert('Dear User ,You are not mapped under your concerned Head.As per Employee Gateway Leave requirements, our employee gateway system requires mapping of employee with his/her concerned Head for leave authorization. So please forward a mail to IT Help Desk from your concerned Head to map you under him/her . Also, this mail would include yours and your Head’s salary codes. The CC of that mail should be done through your Head Of Department. Incase of any problem, please contact 4226')</script>")
                Me.Label16.Visible = True
                Me.LinkButton4.Visible = True
                LinkButton4.PostBackUrl = "Guest_Book.aspx?trans1=y"

            Else

                Me.LinkButton4.Visible = False
                Me.Label16.Visible = False


                '------------------------------------Punch-----------------------

                If Request.QueryString.Get("trans1") = Nothing Then
                    LinkButton3.Visible = False
                    LinkButton3.PostBackUrl = "Punch.aspx"
                Else

                    LinkButton3.Visible = True
                    Dim a As String = Left(Request.QueryString.Get("trans1"), 12)
                    a = Right(a, 10)
                    Me.TxtLeaveFrom.SelectedDate = a
                    Me.TxtLeaveTo.SelectedDate = a
                    LinkButton3.Text = "Back"
                    LinkButton3.PostBackUrl = Nothing
                    LinkButton3.OnClientClick = "javascript:window.history.go(-1);return false;"

                End If


                '------------------------------End Punch-------------------------



            End If

            LeaveMsg()

        End If
    End Sub
    Public Function mapping_check() As Boolean
        Obj.ConOpen()
        'Dim s1 As String = "select * from jct_emp_hod where emp_code='" & Trim(Session("Empcode")) & "' and status is null"
        Dim s1 As String = "SELECT * FROM Jct_Payroll_WorkFlow_Request WHERE RequsterCode = '" & Trim(Session("Empcode")) & "' AND Status = 'A'"

        Cmd = New SqlCommand(s1, Obj.Connection())
        Dim dr As SqlDataReader = Cmd.ExecuteReader()
        dr.Read()
        If dr.HasRows = True Then
            mapping_check = True
        Else
            mapping_check = False
        End If
        dr.Close()
        Obj.ConClose()
        Return mapping_check
    End Function


    Public Function ShortLeaveChecking() As Boolean

        If Trim(ddlleave.Text) = "Short Leave" Then

            ' Dim SqlPass5 As String = "SELECT  COUNT(*) FROM    JCTDEV..jct_empg_leave  WHERE   EmpCode ='" & Session("Empcode") & "'  AND NatureLeave =   '" & Trim(ddlleave.Text) & "' AND   MONTH( LeaveFrom) = MONTH('" & Trim(TxtLeaveFrom.SelectedDate) & "')  AND   YEAR( LeaveFrom) = YEAR  ('" & Trim(TxtLeaveFrom.SelectedDate) & "')   AND ISNULL(MainFlag, '') IN ( 'A', 'P', '' )"
            Dim SqlPass5 As String = "SELECT  COUNT(EmployeeCode) FROM    Jct_Payroll_OnLine_Request  WHERE   EmployeeCode ='" & Session("Empcode") & "'  AND NatureLeave =   '" & Trim(ddlleave.Text) & "' AND   MONTH( FromDate) = MONTH('" & Trim(TxtLeaveFrom.SelectedDate) & "')  AND   YEAR( FromDate) = YEAR  ('" & Trim(TxtLeaveFrom.SelectedDate) & "')   AND ISNULL(Status, '') IN ( 'A', 'P', '' )"
            Dim Dr5 As SqlDataReader = Obj.FetchReader(SqlPass5)
            Try
                If Dr5.HasRows = True Then
                    While Dr5.Read()
                        If Dr5.Item(0) > 0 Then
                            ClientScript.RegisterClientScriptBlock(Me.GetType, "ComLeaveAlreExist2", "<script language = javascript>alert('One Short Leave already apply for month ')</script>")
                            ShortLeaveChecking = False
                        Else
                            ShortLeaveChecking = True
                        End If
                    End While

                End If
                Dr5.Close()
            Catch ex As Exception
            Finally
                Obj.ConClose()
            End Try
        End If

    End Function

    Public Function LeaveFromToDaysDiffeChecking() As Boolean

        If Trim(TxtLeaveFrom.SelectedDate) <> Trim(TxtLeaveTo.SelectedDate) Then

            Dim SqlPass55 As String = "SELECT    DATEDIFF(dd,'" & Trim(TxtLeaveFrom.SelectedDate) & "','" & Trim(TxtLeaveTo.SelectedDate) & "') + 1  "
            Dim Dr55 As SqlDataReader = Obj.FetchReader(SqlPass55)
            Try
                If Dr55.HasRows = True Then
                    While Dr55.Read()
                        If Dr55.Item(0) <> Val(Txtdays.Text) Then
                            ClientScript.RegisterClientScriptBlock(Me.GetType, "EnterDays", "<script language = javascript>alert('Please Check the enter days ')</script>")
                            LeaveFromToDaysDiffeChecking = False
                        Else
                            LeaveFromToDaysDiffeChecking = True
                        End If
                    End While

                End If
                Dr55.Close()
            Catch ex As Exception
            Finally
                Obj.ConClose()
            End Try


        Else
            LeaveFromToDaysDiffeChecking = True

        End If
    End Function


    Public Function CasualLeaveChecking() As Boolean

        If Trim(ddlleave.Text) = "Casual Leave" Then

            'Dim SqlPass6 As String = "SELECT  COUNT(*) FROM    JCTDEV..jct_empg_leave  WHERE   EmpCode ='" & Session("Empcode") & "'  AND NatureLeave =   '" & Trim(ddlleave.Text) & "' AND  MONTH( LeaveFrom) = MONTH('" & Trim(TxtLeaveFrom.SelectedDate) & "')  AND  YEAR( LeaveFrom) = YEAR('" & Trim(TxtLeaveFrom.SelectedDate) & "')     AND ISNULL(MainFlag, '') IN ( 'A', 'P', '' )  AND Days IN ( '0.5', '1.5', '.5', '2.5' )"
            Dim SqlPass6 As String = "SELECT  COUNT(EmployeeCode) FROM    Jct_Payroll_OnLine_Request  WHERE   EmployeeCode ='" & Session("Empcode") & "'  AND NatureLeave =   '" & Trim(ddlleave.Text) & "' AND  MONTH( FromDate) = MONTH('" & Trim(TxtLeaveFrom.SelectedDate) & "')  AND  YEAR( FromDate) = YEAR('" & Trim(TxtLeaveFrom.SelectedDate) & "')     AND ISNULL(Status, '') IN ( 'A', 'P', '' )  AND Days IN ( '0.5', '1.5', '.5', '2.5' )"
            Dim Dr6 As SqlDataReader = Obj.FetchReader(SqlPass6)
            Try
                If Dr6.HasRows = True Then
                    While Dr6.Read()
                        If Dr6.Item(0) >= 2 Then
                            ClientScript.RegisterClientScriptBlock(Me.GetType, "CasualLeaveeAlreExist2", "<script language = javascript>alert('2 Half Casual Leave already apply for this month  ')</script>")
                            CasualLeaveChecking = False
                        Else
                            CasualLeaveChecking = True
                        End If
                    End While

                End If
                Dr6.Close()
            Catch ex As Exception
            Finally
                Obj.ConClose()
            End Try
        End If

    End Function

    Public Function SameDayMultipleLeaveChecking() As Boolean
        'If Trim(ddlleave.Text) = "Casual Leave" Then
        Dim SqlPass6 As String = "SELECT  count(EmployeeCode) From Jct_Payroll_OnLine_Request WHERE   EmployeeCode = '" & Session("Empcode") & "' AND     FromDate   = '" & Trim(TxtLeaveFrom.SelectedDate) & "'"
        Dim Dr6 As SqlDataReader = Obj.FetchReader(SqlPass6)
        Try
            If Dr6.HasRows = True Then
                While Dr6.Read()
                    If Dr6.Item(0) >= 1 Then
                        ClientScript.RegisterClientScriptBlock(Me.GetType, "CasualLeaveeAlreExist2", "<script language = javascript>alert('Leave already apply for this Date.Pls Contact Administrator')</script>")
                        SameDayMultipleLeaveChecking = False
                    Else
                        SameDayMultipleLeaveChecking = True
                    End If
                End While

            End If
            Dr6.Close()
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try
        'End If
    End Function


    Public Function LeaveApplyForOctOnwards() As Boolean
        'If Trim(TxtLeaveFrom.SelectedDate) <= "09/30/2018" Then        
        If TxtLeaveFrom.SelectedValue <= Convert.ToDateTime("09/30/2018") Then

            Try
                ClientScript.RegisterClientScriptBlock(Me.GetType, "CasualLeaveeAlreExist2", "<script language = javascript>alert('Leave Should be > 30Sep18')</script>")
                LeaveApplyForOctOnwards = False                
            Catch ex As Exception
            Finally
                Obj.ConClose()
            End Try
            'End If
        Else
            LeaveApplyForOctOnwards = True
        End If

    End Function

    Public Function WeeklyOffCheck() As Boolean
        'If Trim(ddlleave.Text) = "Casual Leave" Then
        'Dim SqlPass6 As String = "SELECT  COUNT(*) From Jct_Payroll_OnLine_Request WHERE   EmployeeCode = '" & Session("Empcode") & "' AND     FromDate   = '" & Trim(TxtLeaveFrom.SelectedDate) & "'"
        Dim SqlPass6 As String = "SELECT  COUNT(b.CardNo) FROM    Jct_Payroll_Employee_Wo AS a INNER JOIN dbo.JCT_payroll_employees_master AS b ON a.paycode = b.CardNo INNER JOIN Jct_Payroll_OnLine_Request AS c ON a.paycode = b.CardNo WHERE   a.NexttoWO = '" & Trim(TxtLeaveFrom.SelectedDate) & "' AND b.STATUS = 'A' AND b.Active = 'Y' AND b.NewEmployeeCode = '" & Session("Empcode") & "' AND a.PrvDay = c.FromDate"
        Dim Dr6 As SqlDataReader = Obj.FetchReader(SqlPass6)
        Try
            If Dr6.HasRows = True Then
                While Dr6.Read()
                    If Dr6.Item(0) >= 1 Then
                        ClientScript.RegisterClientScriptBlock(Me.GetType, "CasualLeaveeAlreExist2", "<script language = javascript>alert('Due to on Leave Before WO fill leave on WO also')</script>")
                        WeeklyOffCheck = False
                    Else
                        WeeklyOffCheck = True
                    End If
                End While

            End If
            Dr6.Close()
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try
        'End If

    End Function




    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdapply.Click
        Try

            '------------------------------------------------------------------------------------------------------------------------------
            If Txtdays.Text = "" Then
                ClientScript.RegisterClientScriptBlock(Me.GetType, "Day", "<script language = javascript>alert('Please fill the leave days')</script>")
                Txtdays.Focus()
                Exit Sub
            End If
            'hITESH  30/JUNE
            'SameDate()
            'If CheckRecord = True Then
            '    ClientScript.RegisterClientScriptBlock(Me.GetType, "Reocrd", "<script language = javascript>alert('Record Already Exists')</script>")
            '    Exit Sub
            'End If
            '----


            If Val(Txtdays.Text) > 1 And ddlleave.Text = "Compensatry Leave" Then
                ClientScript.RegisterClientScriptBlock(Me.GetType, "Leave", "<script language = javascript>alert('More than 1  Compensatry leave is not allowed')</script>")
                Txtdays.Focus()
                Exit Sub

            End If


            If ddlleave.Text = "Compensatry Leave" Then
                'Done pending
                If CompensatoryChecking() = False Then
                    Exit Sub
                End If


            End If


            'If ddlleave.Text <> "Tour" Then
            '    If ddlleave.Text <> "Official Duty" Then

            '        If OtherLeaveChecking() = False Then
            '            Exit Sub
            '        Else
            '            If Trim(ddlleave.Text) = "Short Leave" Then
            '                If ShortLeaveChecking() = False Then
            '                    Exit Sub
            '                End If
            '            End If

            '        End If
            '    End If
            'End If



            If ddlleave.Text = "Casual Leave" And (Txtdays.Text = "0.5" Or Txtdays.Text = ".5" Or Txtdays.Text = "1.5") Then


                If CasualLeaveChecking() = False Then
                    Exit Sub
                End If


            End If


            If LeaveFromToDaysDiffeChecking() = False Then
                Exit Sub
            End If

            'Added Aslam 24 sep 2018
            If SameDayMultipleLeaveChecking() = False Then
                Exit Sub
            End If


            'Added Aslam 24 sep 2018
            If WeeklyOffCheck() = False Then
                Exit Sub
            End If


            'Added Aslam 24 sep 2018
            If LeaveApplyForOctOnwards() = False Then
                Exit Sub
            End If

            If ddlleave.Text <> "Tour" Then

                If ddlleave.Text <> "Official Duty" Then

                    If ddlleave.Text = "Short Leave" And dlleavetype.Text <> "Hours" Then
                        ClientScript.RegisterClientScriptBlock(Me.GetType, "Hours", "<script language = javascript>alert('Please choose hours')</script>")
                        Exit Sub
                    End If

                    If ddlleave.Text <> "Short Leave" And dlleavetype.Text.Contains("Half") = True And Trim(Txtdays.Text) >= "1" Then
                        ClientScript.RegisterClientScriptBlock(Me.GetType, "Full", "<script language = javascript>alert('Please fill 0.5 day agaisnt Half Day')</script>")
                        Exit Sub
                    End If


                    If ddlleave.Text <> "Short Leave" And dlleavetype.Text = "Multiple Days" And Trim(Txtdays.Text) <= "1" Then
                        ClientScript.RegisterClientScriptBlock(Me.GetType, "Full", "<script language = javascript>alert('Please fill more than 1 day')</script>")
                        Exit Sub
                    End If

                    If ddlleave.Text <> "Short Leave" And dlleavetype.Text = "Hours" Then
                        ClientScript.RegisterClientScriptBlock(Me.GetType, "Sh", "<script language = javascript>alert('Please hours leave not allowed')</script>")
                        Exit Sub
                    End If

                End If
            End If


            CheckDateGreater()
            If CheckDate = True Then
                ClientScript.RegisterClientScriptBlock(Me.GetType, "R4", "<script language = javascript>alert('LeaveFrom Date should be less than LeaveTo')</script>")
                Exit Sub
            End If
            '------------------------------------------------------------------------------------------------------------------------------
            EmailIDFrom()

            '------------------------------------------------------------------------------------------------------------------------------
            'Define the Class
            '------------------------------------------------------------------------------------------------------------------------------

            Dim Client As New Net.Mail.SmtpClient
            Dim Message As New Net.Mail.MailMessage

            '------------------------------------------------------------------------------------------------------------------------------


            '------------------------------------------------------------------------------------------------------------------------------
            'Severe Name & Prot number
            '------------------------------------------------------------------------------------------------------------------------------
            Client.Host = "EXCHANGE2k7"
            Client.Port = 25
            '------------------------------------------------------------------------------------------------------------------------------


            If EmailFrom <> "" Then
                Dim From As New Net.Mail.MailAddress(EmailFrom)
                Message.From = From
            End If


            '------------------------------------------------------------------------------------------------------------------------------
            'Send message for To
            '------------------------------------------------------------------------------------------------------------------------------

            'Dim SqlPass = "SELECT e_mailid from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & Session("Empcode") & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') and status is null AND Auth_Req='Y'and Days=0 and a.Company_Code='" & Session("Companycode") & "'  UNION SELECT e_mailid from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & Session("Empcode") & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') and status is null AND Auth_Req='Y'and days between 0 and " & Txtdays.Text & " and a.Company_Code='" & Session("Companycode") & "' "
            Dim SqlPass = "SELECT TOP ( 1 ) c.EmailID FROM  Jct_Payroll_WorkFlow_Request a, JCT_payroll_employees_master b,Jct_Payroll_Emp_Address_Detail c WHERE a.RequsterCode = '" & Session("Empcode") & "' AND   a.Status   ='A'  AND   a.ActionFlag = '1' AND   a.ActionTakenBy = b.NewEmployeeCode AND   b.Active = 'Y' AND   b.STATUS  ='A' AND   b.EmployeeCode  = c.EmployeeCode  AND   c.Status  ='A'"
            Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
            Try
                If Dr.HasRows = True Then

                    While Dr.Read()

                        If Not (Dr.Item(0) Is System.DBNull.Value) Then

                            EmailTO = Dr.Item(0)

                            'Dim qry As String = "SELECT * FROM dbo.JCT_OPS_EMAIL_APPROVAL_AUTHORITY_LIST WHERE EmailID='" + EmailTO + "' AND STATUS='A' AND EMAILAPPROVAL='Y'"
                            'Dim ConStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
                            'Dim conn As SqlConnection = New SqlConnection(ConStr)

                            'conn.Open()

                            'Dim cmd As SqlCommand = New SqlCommand(qry, conn)
                            'Dim sqldr As SqlDataReader = cmd.ExecuteReader()
                            'If (sqldr.HasRows) Then

                            '    Message.From = New Net.Mail.MailAddress("approvals@jctltd.com")

                            'End If
                            'sqldr.Close()
                            'conn.Close()
                            'EmailFrom = Dr.Item(0)

                            Message.CC.Add(ViewState("EmployeeFrom"))

                            Message.To.Add(EmailTO)

                        End If
                    End While

                    If Val(Txtdays.Text) > 3 And ddlleave.Text = "Sick Leave" Then
                        Message.To.Add("aslam@jctltd.com")
                        Message.To.Add("rajan@jctltd.com")
                        'plantwise
                    End If

                    Dr.Close()

                    'Else
                    '    ClientScript.RegisterClientScriptBlock(Me.GetType, "Potttr", "<script language = javascript>alert('No any Email Id, Please Contact With IT')</script>")
                    '    Dr.Close()
                    '    Obj.ConClose()
                    '    Exit Sub

                End If

            Catch ex As Exception
            Finally
                Obj.ConClose()
            End Try
            '------------------------------------------------------------------------------------------------------------------------------


            '------------------------------------------------------------------------------------------------------------------------------

            '------------------------------------------------------------------------------------------------------------------------------

            '------------------------------------------------------------------------------------------------------------------------------
            'Send the Bcc
            '------------------------------------------------------------------------------------------------------------------------------
            'Dim SqlPass1 = "SELECT e_mailid from jctdev..jct_emp_hod a,JCTDEV..mistel b WHERE  b.empcode=a.resp_emp AND emp_code='" & Session("Empcode") & "' and flag in('B') AND Auth_Req='Y' and status is null and a.Company_Code='" & Session("Companycode") & "' "
            'Dim Dr1 As SqlDataReader = Obj.FetchReader(SqlPass1)
            'Try
            '    If Dr1.HasRows = True Then
            '        While Dr1.Read()
            '            If Not (Dr1.Item(0) Is System.DBNull.Value) Then
            '                EmailBcc1 = Dr1.Item(0)
            '                Message.Bcc.Add(EmailBcc1)
            '            End If
            '        End While
            '        Dr.Close()
            '    End If
            'Catch ex As Exception
            'Finally
            '    Obj.ConClose()
            'End Try
            '------------------------------------------------------------------------------------------------------------------------------




            Message.IsBodyHtml = True
            Message.Priority = Net.Mail.MailPriority.High

            'Modify-Ramandeep Singh  Date 4-May-2009
            'Add Disclaimer in Mail

            If ddlleave.Text = "Short Leave" Then
                Message.Body = Session("Mr_Mrs") + " " + StrConv(txtname.Text, VbStrConv.ProperCase) + "," + " " + StrConv(TextBox6.Text, VbStrConv.ProperCase) + "," + " " + "has applied for" + " " + StrConv(ddlleave.Text, VbStrConv.ProperCase) + " " + "," + " " + "from" + " " + Format(TxtLeaveFrom.SelectedDate, "dd/MM/yyyy") + " " + Right(Trim(txttimefrom.SelectedValue), 11) + " " + "to day time" + " " + Format(TxtLeaveTo.SelectedDate, "dd/MM/yyyy") + " " + Right(Trim(TxtTimeTo.SelectedValue), 11) & "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email is generated through Employee Portal. <br/> <br />Kindly do not reply . <br /><br /> Thank You..!!"
            ElseIf ddlleave.Text = "Official Duty" Then
                Message.Body = Session("Mr_Mrs") + " " + StrConv(txtname.Text, VbStrConv.ProperCase) + "," + " " + StrConv(TextBox6.Text, VbStrConv.ProperCase) + "," + " " + "has applied for" + " " + StrConv(ddlleave.Text, VbStrConv.ProperCase) + " " + "," + " " + "from day time " + " " + Format(TxtLeaveFrom.SelectedDate, "dd/MM/yyyy") + " " + Right(Trim(txttimefrom.SelectedValue), 11) + " " + "to day time" + " " + Format(TxtLeaveTo.SelectedDate, "dd/MM/yyyy") + " " + Right(Trim(TxtTimeTo.SelectedValue), 11) + " " + "for" + " " + Trim(Txtdays.Text) + " " + "day" + "(" + dlleavetype.Text + ")" & "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email is generated through Employee Portal.<br /> <br/>Kindly do not reply . <br /> Thank You..!!"
            Else
                Message.Body = Session("Mr_Mrs") + " " + StrConv(txtname.Text, VbStrConv.ProperCase) + "," + " " + StrConv(TextBox6.Text, VbStrConv.ProperCase) + "," + " " + "has applied for" + " " + StrConv(ddlleave.Text, VbStrConv.ProperCase) + " " + "," + " " + "from" + " " + Format(TxtLeaveFrom.SelectedDate, "dd/MM/yyyy") + " " + "to" + " " + Format(TxtLeaveTo.SelectedDate, "dd/MM/yyyy") + ", " + " " + "for" + " " + Trim(Txtdays.Text) + " " + "day" + "(" + dlleavetype.Text + ")" & "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email is generated through Employee Portal. <br/><br />Kindly do not reply . <br /> Thank You..!!"
            End If

            AutoGenrate()

            Message.Subject = "Application for Leave :- " & ViewState("AutoID")



            If EmailTO <> "" And EmailFrom <> "" And CheckError = False Then
                'Client.Send(Message)
            End If


            '--------------------------------------------------------------------
            Me.Txtdays.Text = ""
            Me.txtcompleave.Text = ""

            Me.txtpurleave.Text = ""

            Me.ddlleave.Text = "Casual Leave"
            Me.ddlshift.Text = "Genral Shift"
            Me.dlleavetype.Text = "Full Day"
            Me.TxtCoDtAgian.SelectedValue = Now()
            Me.TxtLeaveFrom.SelectedValue = Now()
            Me.TxtLeaveTo.SelectedValue = Now()
            Me.txttimefrom.SelectedValue = Now()
            Me.TxtTimeTo.SelectedValue = Now()
            txttimefrom.Enabled = False
            TxtTimeTo.Enabled = False


            If mapping_check() = False Then
                Me.ModalPopupExtender1.Enabled = True
                Panel1.Visible = True
                Me.ModalPopupExtender1.TargetControlID = "cmdapply"
                Me.ModalPopupExtender1.PopupControlID = "Panel1"
                ModalPopupExtender1.Show()
                Exit Sub
            End If
            'If Check_Is_Empty_Flag_Inserted() = True Then
            'Me.ModalPopupExtender1.Enabled = True
            'Panel1.Visible = True
            'Me.ModalPopupExtender1.TargetControlID = "cmdapply"
            'Me.ModalPopupExtender1.PopupControlID = "Panel1"
            'ModalPopupExtender1.Show()
            'Exit Sub
            'End If


            ClientScript.RegisterClientScriptBlock(Me.GetType, "Por", "<script language = javascript>alert('Leave Applied Successfully.')</script>")

            LeaveMsg()



        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(Me.GetType, "hhh", "<script language = javascript>alert('Error Coming.')</script>")


        Finally

        End Try

    End Sub

    'done
    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        'txtname.Text = obj1.Get_empname(Session("Empcode"), Session("Companycode"))
        'TextBox6.Text = obj1.Get_Desg(Session("Empcode"), Session("Companycode"))
        'txtdept.Text = obj1.Get_dept(Session("Empcode"), Session("Companycode"))

        txtname.Text = obj1.Get_empname1(Session("Empcode"))
        TextBox6.Text = obj1.Get_Desg1(Session("Empcode"))
        txtdept.Text = obj1.Get_dept1(Session("Empcode"))

    End Sub
    'done
    Public Sub AutoGenrate()
        'Dim SqlPass = "SELECT MAX(autoid) FROM Jct_Payroll_OnLine_Request"
        Dim SqlPass = "SELECT ISNULL(MAX(autoid),500) AS autoid FROM Jct_Payroll_OnLine_Request"
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Auto1 = Dr.Item(0) + 1
                        ViewState("AutoID") = Auto1
                    Else
                        Auto1 = 501
                    End If
                End While
                Dr.Close()
            End If
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try

        '---------------------        
        Dim SqlPass1 = "select cardno FROM JCT_payroll_employees_master WHERE NewEmployeeCode='" & Session("Empcode") & "' AND active='Y' and status = 'A' "
        Dim Dr1 As SqlDataReader = Obj.FetchReader(SqlPass1)
        Try
            If Dr1.HasRows = True Then
                While Dr1.Read()
                    Session("CardNo") = Dr1(0)
                End While
                Dr1.Close()
            End If
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try
        '------------------------

        If Txtdays.Text = "" Then
            Txtdays.Text = 0
        End If
        'CheckHC()

        Dim Tran As SqlTransaction
        If Obj.Connection.State = ConnectionState.Closed Then
            Obj.Connection.Open()
        End If
        Tran = Obj.Connection.BeginTransaction
        Try
            If ddlleave.Text = "Compensatry Leave" Then
                'SqlPass = "INSERT INTO  jctdev..jct_empg_leave(Usercode,CompanyCode,Cardno,autoid,empcode,natureleave,leavetype,name,desgination,department,shift,days,leavefrom,leaveto,compleave,purpleave,addleave,phoneleave,authflag,CurLeaveTime,CompAgainTime,FlagHC,mainflag )  VALUES('" & Trim(Session("Empcode")) & "','" & Session("Companycode") & "' ,'" & Trim(obj1.Get_CardNumber(Session("Empcode"), Session("Companycode"))) & "'," & Auto1 & ",'" & Trim(Session("Empcode")) & "', '" & Trim(ddlleave.Text) & "','" & Trim(dlleavetype.Text) & "','" & Trim(txtname.Text) & "','" & Trim(TextBox6.Text) & "','" & Trim(txtdept.Text) & "','" & Trim(ddlshift.Text) & "'," & Txtdays.Text & " ,'" & Trim(TxtLeaveFrom.SelectedDate) & "','" & Trim(TxtLeaveTo.SelectedDate) & "','" & Trim(txtcompleave.Text) & "','" & Trim(txtpurleave.Text) & "','" & Trim(txtaddleave.Text) & "','" & Trim(txtphoneleave.Text) & "','U', getdate(),'" & Trim(TxtCoDtAgian.SelectedDate) & "','" & Checkflag & "','P')"
                SqlPass = "JCT_Payroll_Leave_Apply"
                Cmd = New SqlCommand(SqlPass, Obj.Connection)
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.Add("@autoid", SqlDbType.Int).Value = Auto1
                Cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session("EmpCode")
                Cmd.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = Trim(TxtLeaveFrom.SelectedDate)
                Cmd.Parameters.Add("@todate", SqlDbType.DateTime).Value = Trim(TxtLeaveTo.SelectedDate)
                Cmd.Parameters.Add("@LeaveNature", SqlDbType.VarChar, 50).Value = Trim(ddlleave.Text)
                Cmd.Parameters.Add("@LeaveType", SqlDbType.VarChar, 12).Value = Trim(dlleavetype.Text)
                Cmd.Parameters.Add("@LeaveDays", SqlDbType.VarChar, 5).Value = Txtdays.Text
                Cmd.Parameters.Add("@LeaveFromHrs", SqlDbType.VarChar, 12).Value = ""
                Cmd.Parameters.Add("@LeaveToHrs", SqlDbType.VarChar, 12).Value = ""
                Cmd.Parameters.Add("@LvcompAdainDt", SqlDbType.VarChar, 12).Value = Trim(TxtCoDtAgian.SelectedDate)
                Cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 80).Value = Trim(txtpurleave.Text)
                Cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables("REMOTE_ADDR")
                Cmd.Transaction = Tran
                'Cmd.ExecuteNonQuery()

            ElseIf ddlleave.Text = "Short Leave" Or ddlleave.Text = "Official Duty" Then
                'SqlPass = "INSERT INTO jctdev..jct_empg_leave(Usercode,CompanyCode,autoid,Cardno,empcode,natureleave,leavetype,name,desgination,department,shift,days,leavefrom,leaveto,timefrom,timeto,compleave,purpleave,addleave,phoneleave,authflag,CurLeaveTime,FlagHC,mainflag)  VALUES('" & Trim(Session("Empcode")) & "', '" & Session("Companycode") & "' ," & Auto1 & ",'" & Trim(obj1.Get_CardNumber(Session("Empcode"), Session("Companycode"))) & "','" & Trim(Session("Empcode")) & "', '" & Trim(ddlleave.Text) & "','" & Trim(dlleavetype.Text) & "','" & Trim(txtname.Text) & "','" & Trim(TextBox6.Text) & "','" & Trim(txtdept.Text) & "','" & Trim(ddlshift.Text) & "'," & Txtdays.Text & " ,'" & Trim(TxtLeaveFrom.SelectedDate) & "','" & Trim(TxtLeaveTo.SelectedDate) & "','" & Right(Trim(txttimefrom.SelectedValue), 11) & "','" & Right(Trim(TxtTimeTo.SelectedValue), 11) & "','" & Trim(txtcompleave.Text) & "','" & Trim(txtpurleave.Text) & "','" & Trim(txtaddleave.Text) & "','" & Trim(txtphoneleave.Text) & "','U', getdate(),'" & Checkflag & "','P')"

                SqlPass = "JCT_Payroll_Leave_Apply"
                Cmd = New SqlCommand(SqlPass, Obj.Connection)
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.Add("@autoid", SqlDbType.Int).Value = Auto1
                Cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session("EmpCode")
                Cmd.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = Trim(TxtLeaveFrom.SelectedDate)
                Cmd.Parameters.Add("@todate", SqlDbType.DateTime).Value = Trim(TxtLeaveTo.SelectedDate)
                Cmd.Parameters.Add("@LeaveNature", SqlDbType.VarChar, 50).Value = Trim(ddlleave.Text)
                Cmd.Parameters.Add("@LeaveType", SqlDbType.VarChar, 12).Value = Trim(dlleavetype.Text)
                Cmd.Parameters.Add("@LeaveDays", SqlDbType.VarChar, 5).Value = Txtdays.Text
                Cmd.Parameters.Add("@LeaveFromHrs", SqlDbType.VarChar, 12).Value = Right(Trim(txttimefrom.SelectedValue), 11)
                Cmd.Parameters.Add("@LeaveToHrs", SqlDbType.VarChar, 12).Value = Right(Trim(TxtTimeTo.SelectedValue), 11)
                If ddlleave.Text = "Compensatry Leave" Then
                    Cmd.Parameters.Add("@LvcompAdainDt", SqlDbType.VarChar, 12).Value = Trim(TxtCoDtAgian.SelectedDate)
                End If
                Cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 80).Value = Trim(txtpurleave.Text)
                Cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables("REMOTE_ADDR")
                Cmd.Transaction = Tran
                'Cmd.ExecuteNonQuery()
            Else
                'SqlPass = "INSERT INTO jctdev..jct_empg_leave(Usercode,CompanyCode,Cardno,autoid,empcode,natureleave,leavetype,name,desgination,department,shift,days,leavefrom,leaveto,compleave,purpleave,addleave,phoneleave,authflag,CurLeaveTime,FlagHC,mainflag )  VALUES('" & Trim(Session("Empcode")) & "', '" & Session("Companycode") & "' ,'" & Trim(obj1.Get_CardNumber(Session("Empcode"), Session("Companycode"))) & "'," & Auto1 & ",'" & Trim(Session("Empcode")) & "', '" & Trim(ddlleave.Text) & "','" & Trim(dlleavetype.Text) & "','" & Trim(txtname.Text) & "','" & Trim(TextBox6.Text) & "','" & Trim(txtdept.Text) & "','" & Trim(ddlshift.Text) & "'," & Txtdays.Text & " ,'" & Trim(TxtLeaveFrom.SelectedDate) & "','" & Trim(TxtLeaveTo.SelectedDate) & "','" & Trim(txtcompleave.Text) & "','" & Trim(txtpurleave.Text) & "','" & Trim(txtaddleave.Text) & "','" & Trim(txtphoneleave.Text) & "','U', getdate(),'" & Checkflag & "','P')"
                SqlPass = "JCT_Payroll_Leave_Apply"
                Cmd = New SqlCommand(SqlPass, Obj.Connection)
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.Add("@autoid", SqlDbType.Int).Value = Auto1
                Cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session("EmpCode")
                Cmd.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = Trim(TxtLeaveFrom.SelectedDate)
                Cmd.Parameters.Add("@todate", SqlDbType.DateTime).Value = Trim(TxtLeaveTo.SelectedDate)
                Cmd.Parameters.Add("@LeaveNature", SqlDbType.VarChar, 50).Value = Trim(ddlleave.Text)
                Cmd.Parameters.Add("@LeaveType", SqlDbType.VarChar, 12).Value = Trim(dlleavetype.Text)
                Cmd.Parameters.Add("@LeaveDays", SqlDbType.VarChar, 5).Value = Txtdays.Text
                Cmd.Parameters.Add("@LeaveFromHrs", SqlDbType.VarChar, 12).Value = ""
                Cmd.Parameters.Add("@LeaveToHrs", SqlDbType.VarChar, 12).Value = ""
                If ddlleave.Text = "Compensatry Leave" Then
                    Cmd.Parameters.Add("@LvcompAdainDt", SqlDbType.VarChar, 12).Value = Trim(TxtCoDtAgian.SelectedDate)
                End If
                'Cmd.Parameters.Add("@LvcompAdainDt", SqlDbType.VarChar, 12).Value = "Null"
                Cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 80).Value = Trim(txtpurleave.Text)
                Cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables("REMOTE_ADDR")
                Cmd.Transaction = Tran
                'Cmd.ExecuteNonQuery()
            End If
            Tran.Commit()

        Catch ex As Exception
            Tran.Rollback()
            CheckError = True
            ClientScript.RegisterClientScriptBlock(Me.GetType, "Por", "<script language = javascript>alert('Please Insert Proper data')</script>")
            Exit Sub
        Finally
            Obj.ConClose()
        End Try
        Dr.Close()
    End Sub

    Public Sub EmailIDFrom()
        Dim SqlPass = "SELECT TOP ( 1 ) a.EmailID FROM    Jct_Payroll_Emp_Address_Detail AS a INNER JOIN dbo.JCT_payroll_employees_master AS b ON a.EmployeeCode = b.EmployeeCode WHERE   b.NewEmployeeCode = '" & Session("Empcode") & "' AND b.STATUS = 'A' AND b.Active = 'Y' "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        EmailFrom = Dr.Item(0)
                        ViewState("EmployeeFrom") = EmailFrom
                    Else
                        EmailFrom = "dummy@jctltd.com"
                    End If
                End While
                Dr.Close()
            End If
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try

    End Sub

    Public Sub DisComp()
        If ddlleave.Text = "Compensatry Leave" Then
            txtcompleave.Enabled = True
            TxtCoDtAgian.Enabled = True
        Else
            txtcompleave.Enabled = False
            TxtCoDtAgian.Enabled = False
            TxtCoDtAgian.Text = ""
        End If

        If ddlleave.Text = "Short Leave" Or ddlleave.Text = "Official Duty" Then

            txttimefrom.Enabled = True
            TxtTimeTo.Enabled = True

            If ddlleave.Text = "Short Leave" Then
                Txtdays.Text = "0"
                Txtdays.Enabled = False
            ElseIf ddlleave.Text = "Official Duty" Then
                Txtdays.Text = "0"
                Txtdays.Enabled = True
            Else
                Txtdays.Text = ""
                Txtdays.Enabled = True
            End If

        Else
            txttimefrom.Enabled = False
            TxtTimeTo.Enabled = False
            Txtdays.Text = ""
            Txtdays.Enabled = True
        End If

    End Sub

    Protected Sub ddlleave_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlleave.SelectedIndexChanged
        DisComp()
    End Sub

    'Public Sub CheckHC()

    '    'Dim SqlPass = "SELECT flag FROM jctdev..jct_emp_hod  WHERE emp_code='" & Session("Empcode") & "' AND Flag in ('H','T','C','B1','B2','B3','B4','B5') AND Auth_Req='Y' and " & Txtdays.Text & " =0 and " & Txtdays.Text & " >=days  "
    '    Dim SqlPass = "SELECT FLAG from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & Session("Empcode") & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') AND  status is null AND Auth_Req='Y'and Days=0 and a.Company_Code='" & Session("Companycode") & "' UNION SELECT FLAG from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & Session("Empcode") & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') and status is null AND Auth_Req='Y'and days between 0 and " & Txtdays.Text & " and a.Company_Code='" & Session("Companycode") & "'  "
    '    Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
    '    Try
    '        If Dr.HasRows = True Then
    '            While Dr.Read()
    '                If Not (Dr.Item(0) Is System.DBNull.Value) Then
    '                    Checkflag1 = Dr.Item(0)
    '                End If
    '                Checkflag += Trim(Checkflag1) + "-"
    '            End While
    '            Checkflag = Mid(Checkflag, 1, Checkflag.Length - 1)
    '            Dr.Close()
    '        End If
    '    Catch ex As Exception
    '    Finally
    '        Obj.ConClose()
    '    End Try
    'End Sub

    Public Sub SameDate()
        'Dim SqlPass = "SELECT *  from JCTDEV..jct_empg_leave WHERE EmpCode='" & Session("Empcode") & "' and NATURELEAVE='" & ddlleave.Text & "' AND LEAVETYPE='" & Me.dlleavetype.Text & "' AND convert(smalldatetime,convert(char(12),LEAVEFROM )) = '" & Format(TxtLeaveFrom.SelectedDate, "MM/dd/yyyy") & "'  AND convert(smalldatetime,convert(char(12),LEAVETO )) = '" & Format(TxtLeaveTo.SelectedDate, "MM/dd/yyyy") & "' and mainflag not in('C')  and CompanyCode='" & Session("Companycode") & "' "
        Dim SqlPass = "SELECT 'X'  from JCTDEV..Jct_Payroll_OnLine_Request WHERE EmpCode='" & Session("Empcode") & "' and NATURELEAVE='" & ddlleave.Text & "' AND LEAVETYPE='" & Me.dlleavetype.Text & "' AND convert(smalldatetime,convert(char(12),LEAVEFROM )) = '" & Format(TxtLeaveFrom.SelectedDate, "MM/dd/yyyy") & "'  AND convert(smalldatetime,convert(char(12),LEAVETO )) = '" & Format(TxtLeaveTo.SelectedDate, "MM/dd/yyyy") & "' and mainflag not in('C')  and CompanyCode='" & Session("Companycode") & "' "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    CheckRecord = True
                End While
                Dr.Close()
            End If
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try
    End Sub

    Public Sub CheckDateGreater()
        Dim SqlPass = "SELECT  DateDiff(DD,'" & TxtLeaveFrom.SelectedDate & "','" & TxtLeaveTo.SelectedDate & "') as Difference"
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Dr.Item(0) < 0 Then
                        CheckDate = True
                    End If
                End While
                Dr.Close()
            End If
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try

    End Sub
    Protected Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        Me.Txtdays.Text = ""
        Me.txtcompleave.Text = ""

        Me.txtpurleave.Text = ""

        Me.ddlleave.Text = "Casual Leave"
        Me.ddlshift.Text = "Genral Shift"
        Me.dlleavetype.Text = "Full Day"
        Me.TxtCoDtAgian.SelectedValue = Now()
        Me.TxtLeaveFrom.SelectedValue = Now()
        Me.TxtLeaveTo.SelectedValue = Now()
        Me.txttimefrom.SelectedValue = Now()
        Me.TxtTimeTo.SelectedValue = Now()

    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("Default2.aspx")
    End Sub
    Public Sub LeaveMsg()
        Obj.ConOpen()
        SqlPass = "select Count(EmployeeCode) from Jct_Payroll_OnLine_Request where EmployeeCode='" & Session("Empcode") & "' and Status ='p'"
        'SqlPass = "select count(*) from jct_empg_leave where empcode='" & Session("Empcode") & "' and mainflag='p'"
        Cmd = New SqlCommand(SqlPass, Obj.Connection())

        Dim count As Integer = Cmd.ExecuteScalar()
        If count <> 0 Then
            Me.lblmsg.Visible = True
            Me.lblmsg.Text = "The number of leave applications pending in your account:  " & count & " .  For more detail, please check your Leave Status."
        Else
            Me.lblmsg.Visible = False
        End If
        Obj.ConOpen()
    End Sub

    Protected Sub lnkcomp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkcomp.Click
        Response.Redirect("applycompensatoryleave.aspx")
    End Sub

    Public Function CompensatoryChecking() As Boolean
        '------------------------------------------------------------------------------------------------------------------------------
        'Check Compensatory is exists ot not
        '------------------------------------------------------------------------------------------------------------------------------
        Dim comTrueFalse As Boolean = False
        If Trim(ddlleave.Text) = "Compensatry Leave" Then
            'Dim SqlPass2 As String = "SELECT  LeaveDate From Jct_Payroll_Employee_Compensatory WHERE   EmployeeCode = '" & Trim(obj1.Get_CardNumber(Session("Empcode"), Session("Companycode"))) & "' AND LeaveDate = '" & Trim(TxtCoDtAgian.SelectedDate) & "' AND status = 'A' AND consumed > 0 OR consumed IS NULL"
            Dim SqlPass2 As String = "SELECT  LeaveDate From Jct_Payroll_Employee_Compensatory WHERE   EmployeeCode = '" & Session("Empcode") & "' AND LeaveDate = '" & Trim(TxtCoDtAgian.SelectedDate) & "' AND status = 'A' AND consumed > 0 OR consumed IS NULL"
            Dim Dr2 As SqlDataReader = Obj.FetchReader(SqlPass2)
            Try
                If Dr2.HasRows = True Then
                    comTrueFalse = True
                    CompensatoryChecking = True
                Else
                    ClientScript.RegisterClientScriptBlock(Me.GetType, "Leavenotavailabled", "<script language = javascript>alert('No Sufficient Compensatry leave Balance,Check your account please')</script>")
                    comTrueFalse = False
                    CompensatoryChecking = False
                End If
                Dr2.Close()
            Catch ex As Exception
            Finally
                Obj.ConClose()
            End Try


            If comTrueFalse = True Then
                Dim SqlPass1 As String = "SELECT  DateDiff(DD,'" & TxtCoDtAgian.SelectedDate & "', CAST(GETDATE() AS SMALLDATETIME)) as Difference"
                Dim Dr1 As SqlDataReader = Obj.FetchReader(SqlPass1)
                Try
                    If Dr1.HasRows = True Then
                        While Dr1.Read()
                            If Dr1.Item(0) >= 91 Then
                                ClientScript.RegisterClientScriptBlock(Me.GetType, "ComLeaveExist", "<script language = javascript>alert('Compensatry leave More than 90 days old')</script>")
                                CompensatoryChecking = False
                            Else
                                CompensatoryChecking = True
                            End If
                        End While
                        Dr1.Close()
                    End If
                Catch ex As Exception
                Finally
                    Obj.ConClose()
                End Try
            End If

            If comTrueFalse = True Then
                Dim SqlPass3 As String = "SELECT a.EmployeeCode FROM Jct_Payroll_OnLine_Request  AS a INNER JOIN Jct_Payroll_Employee_Compensatory       AS b ON a.LvcompAdainDt = '" & Trim(TxtCoDtAgian.SelectedDate) & "' AND a.LeaveNature = 'Compensatry Leave' AND b.EmployeeCode = '" & Session("Empcode") & "' AND b.LeaveDate  =  '" & Trim(TxtCoDtAgian.SelectedDate) & "' AND  CONVERT(NUMERIC(1),ISNULL(b.LeaveDays,0)) - ISNULL(b.Consumed,0) =  0 "
                Dim Dr3 As SqlDataReader = Obj.FetchReader(SqlPass3)
                Try
                    If Dr3.HasRows = True Then
                        While Dr3.Read()
                            If Dr3.Item(0) > 0 Then
                                ClientScript.RegisterClientScriptBlock(Me.GetType, "ComLeaveAlreExist1", "<script language = javascript>alert('Compensatry  already availed  ')</script>")
                                comTrueFalse = False
                                CompensatoryChecking = False
                            Else
                                comTrueFalse = True
                                CompensatoryChecking = True
                            End If
                        End While

                    End If
                    Dr3.Close()
                Catch ex As Exception
                Finally
                    Obj.ConClose()
                End Try
            End If

        End If

    End Function

End Class

