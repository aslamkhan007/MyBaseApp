Imports System.Data.SqlClient
Imports System.Net.Mail.MailMessage
Imports System.Net.Mail.SmtpClient
Imports System.Data
Imports System.Net.Mail

Partial Class Default9
    Inherits System.Web.UI.Page
    Dim strTo As String, strFrom As String, strSubject As String, SqlPass As String, Sqlpass1 As String, con As String
    Dim EmailTO, EmailTO1, EmailFrom, EmailCc, EmailBcc, EmailBcc1, Checkflag, Checkflag1 As String
    Dim CheckError As Boolean = False, CheckRecord As Boolean = False, CheckDate As Boolean = False
    Dim Auto1 As Int64, Difference As Integer, CountMail As Integer = 0
    Dim Obj As New Connection
    Dim Cmd As New SqlCommand
    Dim obj1 As Functions = New Functions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Response.Cache.SetExpires(Now.AddSeconds(-1))
        'Response.Cache.SetNoStore()
        'Response.AppendHeader("Pragma", "no-cache")
        If (Session("Empcode").ToString <> "") Then
        Else
            Response.Redirect("~/login.aspx")
        End If
        If IsPostBack = False Then
            'If Session("Empcode") = "r-03348" Then
            '    Dim mytext As String = "Leaves"
            '    mytext = "<DIV style = filter:shadow(color:black,strength:2,direction:135);><nobr>" & mytext & "</nobr></DIV>"
            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "m", "marqueecontent='" & mytext & "'", True)
            'End If

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
        Dim s1 As String = "select * from jct_emp_hod where emp_code='" & Trim(Session("Empcode")) & "' and status is null"
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
    Public Function Check_Is_Empty_Flag_Inserted() As Boolean
        Obj.ConOpen()
        Dim s2 As String = "select * from jct_empg_leave where mainflag='p' and flaghc='' and empcode='" & Trim(Session("Empcode")) & "'"
        Cmd = New SqlCommand(s2, Obj.Connection())
        Dim dr As SqlDataReader = Cmd.ExecuteReader()
        dr.Read()
        If dr.HasRows = True Then
            Check_Is_Empty_Flag_Inserted = True
        Else
            Check_Is_Empty_Flag_Inserted = False
        End If
        dr.Close()
        Obj.ConClose()
        Return Check_Is_Empty_Flag_Inserted

    End Function

    Public Function OtherLeaveChecking() As Boolean
        If Trim(ddlleave.Text) = "Short Leave" Or Trim(ddlleave.Text) = "Sick Leave" Or Trim(ddlleave.Text) = "Priviledge Leave" Or Trim(ddlleave.Text) = "Casual Leave" Or Trim(ddlleave.Text) = "Compensatry Leave" Then

            Dim SqlPass4 As String = "SELECT  COUNT(*) FROM    JCTDEV..jct_empg_leave  WHERE   EmpCode ='" & Session("Empcode") & "'  AND NatureLeave =   '" & Trim(ddlleave.Text) & "' AND  ( ( LeaveFrom = '" & Trim(TxtLeaveFrom.SelectedDate) & "' AND LeaveTo ='" & Trim(TxtLeaveTo.SelectedDate) & "'  ) OR LeaveFrom = '" & Trim(TxtLeaveFrom.SelectedDate) & "'  OR LeaveTo ='" & Trim(TxtLeaveTo.SelectedDate) & "')    AND ISNULL(MainFlag, '') IN ( 'A', 'P', '' )"
            Dim Dr4 As SqlDataReader = Obj.FetchReader(SqlPass4)
            Try
                If Dr4.HasRows = True Then
                    While Dr4.Read()
                        If Dr4.Item(0) > 0 Then
                            ClientScript.RegisterClientScriptBlock(Me.GetType, "ComLeaveAlreExist2", "<script language = javascript>alert('Leave already apply for same day ')</script>")
                            OtherLeaveChecking = False
                        Else
                            OtherLeaveChecking = True
                        End If
                    End While

                End If
                Dr4.Close()
            Catch ex As Exception
            Finally
                Obj.ConClose()
            End Try
        End If
    End Function

    Public Function ShortLeaveChecking() As Boolean

        If Trim(ddlleave.Text) = "Short Leave" Then

            Dim SqlPass5 As String = "SELECT  COUNT(*) FROM    JCTDEV..jct_empg_leave  WHERE   EmpCode ='" & Session("Empcode") & "'  AND NatureLeave =   '" & Trim(ddlleave.Text) & "' AND   MONTH( LeaveFrom) = MONTH('" & Trim(TxtLeaveFrom.SelectedDate) & "')  AND   YEAR( LeaveFrom) = YEAR  ('" & Trim(TxtLeaveFrom.SelectedDate) & "')   AND ISNULL(MainFlag, '') IN ( 'A', 'P', '' )"
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

    Public Function CompensatoryChecking() As Boolean
        '------------------------------------------------------------------------------------------------------------------------------
        'Check Compensatory is exists ot not
        '------------------------------------------------------------------------------------------------------------------------------
        Dim comTrueFalse As Boolean = False
        If Trim(ddlleave.Text) = "Compensatry Leave" Then
            Dim SqlPass2 As String = "SELECT leave_earned_date FROM savior..Jct_comp_leave  WHERE paycode='" & Trim(obj1.Get_CardNumber(Session("Empcode"), Session("Companycode"))) & "' AND leave_earned_date= '" & Trim(TxtCoDtAgian.SelectedDate) & "' AND status IS NULL "
            Dim Dr2 As SqlDataReader = Obj.FetchReader(SqlPass2)
            Try
                If Dr2.HasRows = True Then

                    comTrueFalse = True

                Else
                    ClientScript.RegisterClientScriptBlock(Me.GetType, "Leavenotavailabled", "<script language = javascript>alert('Compensatry leave has not credited in your account please check your Leave')</script>")
                    comTrueFalse = False

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
                Dim SqlPass3 As String = "SELECT  COUNT(*) FROM    JCTDEV..jct_empg_leave  WHERE   EmpCode ='" & Session("Empcode") & "'    AND CompAgainTime ='" & Trim(TxtCoDtAgian.SelectedDate) & "'      AND ISNULL(MainFlag, '') IN ( 'A', 'P', '' )"
                Dim Dr3 As SqlDataReader = Obj.FetchReader(SqlPass2)
                Try
                    If Dr3.HasRows = True Then
                        While Dr3.Read()
                            If Dr3.Item(0) > 0 Then
                                ClientScript.RegisterClientScriptBlock(Me.GetType, "ComLeaveAlreExist1", "<script language = javascript>alert('Compensatry  already availed  ')</script>")
                                comTrueFalse = False
                            Else
                                comTrueFalse = True
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




        '------------------------------------------------------------------------------------------------------------------------------


    End Function


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdapply.Click
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


            If CompensatoryChecking() = False Then
                Exit Sub
            End If


        End If

        If ddlleave.Text <> "Official Duty" Then

            If OtherLeaveChecking() = False Then
                Exit Sub
            Else
                If Trim(ddlleave.Text) = "Short Leave" Then
                    If ShortLeaveChecking() = False Then
                        Exit Sub
                    End If
                End If

            End If
        End If


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

        Dim SqlPass = "SELECT e_mailid from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & Session("Empcode") & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') and status is null AND Auth_Req='Y'and Days=0 and a.Company_Code='" & Session("Companycode") & "'  UNION SELECT e_mailid from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & Session("Empcode") & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') and status is null AND Auth_Req='Y'and days between 0 and " & Txtdays.Text & " and a.Company_Code='" & Session("Companycode") & "' "

        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then

                While Dr.Read()

                    If Not (Dr.Item(0) Is System.DBNull.Value) Then

                        EmailTO = Dr.Item(0)

                        Dim qry As String = "SELECT * FROM dbo.JCT_OPS_EMAIL_APPROVAL_AUTHORITY_LIST WHERE EmailID='" + EmailTO + "' AND STATUS='A' AND EMAILAPPROVAL='Y'"
                        Dim ConStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
                        Dim conn As SqlConnection = New SqlConnection(ConStr)

                        conn.Open()

                        Dim cmd As SqlCommand = New SqlCommand(qry, conn)
                        Dim sqldr As SqlDataReader = cmd.ExecuteReader()
                        If (sqldr.HasRows) Then

                            Message.From = New Net.Mail.MailAddress("approvals@jctltd.com")

                        End If
                        sqldr.Close()
                        conn.Close()
                        EmailFrom = Dr.Item(0)

                        Message.CC.Add(ViewState("EmployeeFrom"))

                        Message.To.Add(EmailTO)

                    End If
                End While

                If Val(Txtdays.Text) > 3 And ddlleave.Text = "Sick Leave" Then
                    Message.To.Add("saini@jctltd.com")
                    Message.To.Add("reception@jctltd.com")
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

        Dim SqlPass1 = "SELECT e_mailid from jctdev..jct_emp_hod a,JCTDEV..mistel b WHERE  b.empcode=a.resp_emp AND emp_code='" & Session("Empcode") & "' and flag in('B') AND Auth_Req='Y' and status is null and a.Company_Code='" & Session("Companycode") & "' "
        Dim Dr1 As SqlDataReader = Obj.FetchReader(SqlPass1)
        Try
            If Dr1.HasRows = True Then
                While Dr1.Read()
                    If Not (Dr1.Item(0) Is System.DBNull.Value) Then
                        EmailBcc1 = Dr1.Item(0)
                        Message.Bcc.Add(EmailBcc1)
                    End If
                End While
                Dr.Close()
            End If
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try
        '------------------------------------------------------------------------------------------------------------------------------




        Message.IsBodyHtml = True
        Message.Priority = Net.Mail.MailPriority.High

        'Modify-Ramandeep Singh  Date 4-May-2009
        'Add Disclaimer in Mail

        If ddlleave.Text = "Short Leave" Then
            Message.Body = Session("Mr_Mrs") + " " + StrConv(txtname.Text, VbStrConv.ProperCase) + "," + " " + StrConv(TextBox6.Text, VbStrConv.ProperCase) + "," + " " + "has applied for" + " " + StrConv(ddlleave.Text, VbStrConv.ProperCase) + " " + "," + " " + "from" + " " + Format(TxtLeaveFrom.SelectedDate, "dd/MM/yyyy") + " " + Right(Trim(txttimefrom.SelectedValue), 11) + " " + "to day time" + " " + Format(TxtLeaveTo.SelectedDate, "dd/MM/yyyy") + " " + Right(Trim(TxtTimeTo.SelectedValue), 11) & "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email has been generated through Employee Gateway Package. <br/> <br />Kindly do not reply as you will not receive a response. <br /><br /> Thank You..!!"
        ElseIf ddlleave.Text = "Official Duty" Then
            Message.Body = Session("Mr_Mrs") + " " + StrConv(txtname.Text, VbStrConv.ProperCase) + "," + " " + StrConv(TextBox6.Text, VbStrConv.ProperCase) + "," + " " + "has applied for" + " " + StrConv(ddlleave.Text, VbStrConv.ProperCase) + " " + "," + " " + "from day time " + " " + Format(TxtLeaveFrom.SelectedDate, "dd/MM/yyyy") + " " + Right(Trim(txttimefrom.SelectedValue), 11) + " " + "to day time" + " " + Format(TxtLeaveTo.SelectedDate, "dd/MM/yyyy") + " " + Right(Trim(TxtTimeTo.SelectedValue), 11) + " " + "for" + " " + Trim(Txtdays.Text) + " " + "day" + "(" + dlleavetype.Text + ")" & "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email has been generated through Employee Gateway Package.<br /> <br/>Kindly do not reply as you will not receive a response. <br /> Thank You..!!"
        Else
            Message.Body = Session("Mr_Mrs") + " " + StrConv(txtname.Text, VbStrConv.ProperCase) + "," + " " + StrConv(TextBox6.Text, VbStrConv.ProperCase) + "," + " " + "has applied for" + " " + StrConv(ddlleave.Text, VbStrConv.ProperCase) + " " + "," + " " + "from" + " " + Format(TxtLeaveFrom.SelectedDate, "dd/MM/yyyy") + " " + "to" + " " + Format(TxtLeaveTo.SelectedDate, "dd/MM/yyyy") + ", " + " " + "for" + " " + Trim(Txtdays.Text) + " " + "day" + "(" + dlleavetype.Text + ")" & "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email has been generated through Employee Gateway Package. <br/><br />Kindly do not reply as you will not receive a response. <br /> Thank You..!!"
        End If

        AutoGenrate()

        Message.Subject = "Application for Leave :- " & ViewState("AutoID")

        If EmailTO <> "" And EmailFrom <> "" And CheckError = False Then
            Client.Send(Message)
        End If


        '--------------------------------------------------------------------
        Me.Txtdays.Text = ""
        Me.txtcompleave.Text = ""
        Me.txtphoneleave.Text = ""
        Me.txtpurleave.Text = ""
        Me.txtaddleave.Text = ""
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
        If Check_Is_Empty_Flag_Inserted() = True Then
            Me.ModalPopupExtender1.Enabled = True
            Panel1.Visible = True
            Me.ModalPopupExtender1.TargetControlID = "cmdapply"
            Me.ModalPopupExtender1.PopupControlID = "Panel1"
            ModalPopupExtender1.Show()
            Exit Sub
        End If


        ClientScript.RegisterClientScriptBlock(Me.GetType, "Por", "<script language = javascript>alert('Leave Applied Successfully, Please check your leave status.')</script>")

        LeaveMsg()

    End Sub




    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        txtname.Text = obj1.Get_empname(Session("Empcode"), Session("Companycode"))
        TextBox6.Text = obj1.Get_Desg(Session("Empcode"), Session("Companycode"))
        txtdept.Text = obj1.Get_dept(Session("Empcode"), Session("Companycode"))
    End Sub

    Public Sub AutoGenrate()
        Dim SqlPass = "SELECT MAX(autoid) FROM jctdev..jct_empg_leave"
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Auto1 = Dr.Item(0) + 1
                        ViewState("AutoID") = Auto1
                    Else
                        Auto1 = 1001
                    End If
                End While
                Dr.Close()
            End If
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try
        '---------------------
        'Dim SqlPass1 = "select cardno FROM jct_epor_master_employee WHERE Emp_Code=@empcode AND Status='A' AND GETDATE() BETWEEN eff_from AND Eff_To  "
        'Dim SqlPass1 = "select cardno FROM jct_epor_master_employee WHERE Emp_Code='" & Session("Empcode") & "' AND Status='A' AND GETDATE() BETWEEN eff_from AND Eff_To  "
        Dim SqlPass1 = "select cardno FROM jct_empmast_base WHERE empcode='" & Session("Empcode") & "' AND active='Y' "
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

        CheckHC()

        Dim Tran As SqlTransaction
        If Obj.Connection.State = ConnectionState.Closed Then
            Obj.Connection.Open()
        End If
        Tran = Obj.Connection.BeginTransaction
        Try

            If ddlleave.Text = "Compensatry Leave" Then
                SqlPass = "INSERT INTO  jctdev..jct_empg_leave(Usercode,CompanyCode,Cardno,autoid,empcode,natureleave,leavetype,name,desgination,department,shift,days,leavefrom,leaveto,compleave,purpleave,addleave,phoneleave,authflag,CurLeaveTime,CompAgainTime,FlagHC,mainflag )  VALUES('" & Trim(Session("Empcode")) & "','" & Session("Companycode") & "' ,'" & Trim(obj1.Get_CardNumber(Session("Empcode"), Session("Companycode"))) & "'," & Auto1 & ",'" & Trim(Session("Empcode")) & "', '" & Trim(ddlleave.Text) & "','" & Trim(dlleavetype.Text) & "','" & Trim(txtname.Text) & "','" & Trim(TextBox6.Text) & "','" & Trim(txtdept.Text) & "','" & Trim(ddlshift.Text) & "'," & Txtdays.Text & " ,'" & Trim(TxtLeaveFrom.SelectedDate) & "','" & Trim(TxtLeaveTo.SelectedDate) & "','" & Trim(txtcompleave.Text) & "','" & Trim(txtpurleave.Text) & "','" & Trim(txtaddleave.Text) & "','" & Trim(txtphoneleave.Text) & "','U', getdate(),'" & Trim(TxtCoDtAgian.SelectedDate) & "','" & Checkflag & "','P')"
            ElseIf ddlleave.Text = "Short Leave" Or ddlleave.Text = "Official Duty" Then
                SqlPass = "INSERT INTO jctdev..jct_empg_leave(Usercode,CompanyCode,autoid,Cardno,empcode,natureleave,leavetype,name,desgination,department,shift,days,leavefrom,leaveto,timefrom,timeto,compleave,purpleave,addleave,phoneleave,authflag,CurLeaveTime,FlagHC,mainflag)  VALUES('" & Trim(Session("Empcode")) & "', '" & Session("Companycode") & "' ," & Auto1 & ",'" & Trim(obj1.Get_CardNumber(Session("Empcode"), Session("Companycode"))) & "','" & Trim(Session("Empcode")) & "', '" & Trim(ddlleave.Text) & "','" & Trim(dlleavetype.Text) & "','" & Trim(txtname.Text) & "','" & Trim(TextBox6.Text) & "','" & Trim(txtdept.Text) & "','" & Trim(ddlshift.Text) & "'," & Txtdays.Text & " ,'" & Trim(TxtLeaveFrom.SelectedDate) & "','" & Trim(TxtLeaveTo.SelectedDate) & "','" & Right(Trim(txttimefrom.SelectedValue), 11) & "','" & Right(Trim(TxtTimeTo.SelectedValue), 11) & "','" & Trim(txtcompleave.Text) & "','" & Trim(txtpurleave.Text) & "','" & Trim(txtaddleave.Text) & "','" & Trim(txtphoneleave.Text) & "','U', getdate(),'" & Checkflag & "','P')"

            Else
                SqlPass = "INSERT INTO jctdev..jct_empg_leave(Usercode,CompanyCode,Cardno,autoid,empcode,natureleave,leavetype,name,desgination,department,shift,days,leavefrom,leaveto,compleave,purpleave,addleave,phoneleave,authflag,CurLeaveTime,FlagHC,mainflag )  VALUES('" & Trim(Session("Empcode")) & "', '" & Session("Companycode") & "' ,'" & Trim(obj1.Get_CardNumber(Session("Empcode"), Session("Companycode"))) & "'," & Auto1 & ",'" & Trim(Session("Empcode")) & "', '" & Trim(ddlleave.Text) & "','" & Trim(dlleavetype.Text) & "','" & Trim(txtname.Text) & "','" & Trim(TextBox6.Text) & "','" & Trim(txtdept.Text) & "','" & Trim(ddlshift.Text) & "'," & Txtdays.Text & " ,'" & Trim(TxtLeaveFrom.SelectedDate) & "','" & Trim(TxtLeaveTo.SelectedDate) & "','" & Trim(txtcompleave.Text) & "','" & Trim(txtpurleave.Text) & "','" & Trim(txtaddleave.Text) & "','" & Trim(txtphoneleave.Text) & "','U', getdate(),'" & Checkflag & "','P')"
            End If


            Cmd = New SqlCommand(SqlPass, Obj.Connection)
            Cmd.Transaction = Tran
            Cmd.ExecuteNonQuery()
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
        Dim SqlPass = "SELECT E_mailID FROM  JCTDEV..Mistel b  WHERE b.empcode='" & Session("Empcode") & "' and Company_Code='" & Session("Companycode") & "'  "
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

    Public Sub CheckHC()

        'Dim SqlPass = "SELECT flag FROM jctdev..jct_emp_hod  WHERE emp_code='" & Session("Empcode") & "' AND Flag in ('H','T','C','B1','B2','B3','B4','B5') AND Auth_Req='Y' and " & Txtdays.Text & " =0 and " & Txtdays.Text & " >=days  "
        Dim SqlPass = "SELECT FLAG from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & Session("Empcode") & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') AND  status is null AND Auth_Req='Y'and Days=0 and a.Company_Code='" & Session("Companycode") & "' UNION SELECT FLAG from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & Session("Empcode") & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') and status is null AND Auth_Req='Y'and days between 0 and " & Txtdays.Text & " and a.Company_Code='" & Session("Companycode") & "'  "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Checkflag1 = Dr.Item(0)
                    End If
                    Checkflag += Trim(Checkflag1) + "-"
                End While
                Checkflag = Mid(Checkflag, 1, Checkflag.Length - 1)
                Dr.Close()
            End If
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try

    End Sub
    Public Sub SameDate()

        Dim SqlPass = "SELECT *  from JCTDEV..jct_empg_leave WHERE EmpCode='" & Session("Empcode") & "' and NATURELEAVE='" & ddlleave.Text & "' AND LEAVETYPE='" & Me.dlleavetype.Text & "' AND convert(smalldatetime,convert(char(12),LEAVEFROM )) = '" & Format(TxtLeaveFrom.SelectedDate, "MM/dd/yyyy") & "'  AND convert(smalldatetime,convert(char(12),LEAVETO )) = '" & Format(TxtLeaveTo.SelectedDate, "MM/dd/yyyy") & "' and mainflag not in('C')  and CompanyCode='" & Session("Companycode") & "' "
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
        Me.txtphoneleave.Text = ""
        Me.txtpurleave.Text = ""
        Me.txtaddleave.Text = ""
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
        SqlPass = "select count(*) from jct_empg_leave where empcode='" & Session("Empcode") & "' and mainflag='p'"
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


End Class
'Leave Application Code File Also Available E:\c backup 30 july 08\hitesh\Desktop\master
'Leave Application Code File update 16/sep.2006 in \\test2k\webapplication with hiteshLeave