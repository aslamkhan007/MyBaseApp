Imports System.Data
Imports System.Data.SqlClient
Imports System.net.Mail.MailMessage
Imports System.net.Mail.SmtpClient
Partial Class Default11
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim ObjFun As Functions = New Functions
    Dim SqlPass As String, Concat As String
    Dim AId As Integer, I As Integer, Tot, empcode_to, EmailTO, EmailFrom, Mr_Mrs, empname, designation, Emailcc, EmailBcc, to_name, Mr_Mrs_to As String
    Public ob As New HelpDeskClass
    Public cmd As New SqlCommand
    Dim dr As SqlDataReader


    Public Sub BindData()

        SqlPass = " select * from jctdev..jct_empg_leave where Autoid='" & Request.QueryString.Get("ID") & "' "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)

        If Dr.HasRows = True Then

            While Dr.Read()
                Me.ddlleave.Text = Dr.Item("NatureLeave")
                Me.dlleavetype.Text = Dr.Item("LeaveType")
                Me.txtname.Text = Dr.Item("Name")
                Me.TextBox6.Text = Dr.Item("Desgination")
                Me.txtdept.Text = Dr.Item("Department")
                Me.ddlshift.Text = Dr.Item("Shift")
                Me.txtdays.Text = Dr.Item("Days")
                '----
                Me.txtleavefrom.Text = Format(Dr.Item("LeaveFrom"), "dd/MM/yyyy")
                Me.txtleaveto.Text = Format(IIf(Dr.Item("leaveTo") Is System.DBNull.Value, "", Dr.Item("LeaveTo")), "dd/MM/yyyy")
                If Dr.Item("CompAgainTime") Is System.DBNull.Value Then
                    Me.TxtCoDtAgian.Text = ""
                Else
                    Me.TxtCoDtAgian.Text = Format(IIf(Dr.Item("CompAgainTime") Is System.DBNull.Value, "", Dr.Item("CompAgainTime")), "dd/MM/yyyy")
                End If
                '----
                ' Me.txtleavefrom.Text = Dr.Item("LeaveFrom")
                ' Me.txtleaveto.Text = IIf(Dr.Item("leaveTo") Is System.DBNull.Value, "", Dr.Item("LeaveTo"))
                ' Me.TxtCoDtAgian.Text = IIf(Dr.Item("CompAgainTime") Is System.DBNull.Value, "", Dr.Item("CompAgainTime"))
                Me.txttimefrom.Text = IIf(Dr.Item("TimeFrom") Is System.DBNull.Value, "", Dr.Item("TimeFrom"))
                Me.txttimeto.Text = IIf(Dr.Item("TimeTo") Is System.DBNull.Value, "", Dr.Item("TimeTo"))
                Me.txtcompleave.Text = IIf(Dr.Item("CompLeave") Is System.DBNull.Value, "", Dr.Item("CompLeave"))
                Me.txtpurleave.Text = IIf(Dr.Item("PurpLeave") Is System.DBNull.Value, "", Dr.Item("PurpLeave"))
                Me.txtaddleave.Text = IIf(Dr.Item("AddLeave") Is System.DBNull.Value, "", Dr.Item("AddLeave"))
                Me.txtphoneleave.Text = IIf(Dr.Item("PhoneLeave") Is System.DBNull.Value, "", Dr.Item("PhoneLeave"))
                Me.txtremarks.Text = IIf(Dr.Item("Remarks") Is System.DBNull.Value, "", Dr.Item("Remarks"))
                AId = Dr.Item("AutoId")
                Session("Check") = Trim(Dr.Item("FlagHC"))
                Session("AID") = AId

                'If Mid(Session("Check"), 1, 2) = "B1" Or Mid(Session("Check"), 1, 2) = "B2" Or Mid(Session("Check"), 1, 2) = "B3" Or Mid(Session("Check"), 1, 2) = "B4" Then
                '    cmdcancle.Visible = False
                'Else
                '    cmdcancle.Visible = True
                'End If
                cmdcancle.Visible = True
            End While
        End If

    End Sub
    Public Sub Position()
        Dim Sqlpass = "select Flag,FlagHC  from jctdev..jct_empg_leave a ,jctdev..jct_emp_hod b  where  a.empcode=b.Emp_Code and Resp_emp='" & Trim(Session("Empcode")) & "' and auth_req='Y' and AutoId='" & Session("AID") & "' and status is null "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        If Dr.HasRows = True Then
            While Dr.Read()
                Session("To") = Dr.Item("Flag")
                Session("StoreFlag") = Dr.Item("FlagHC")
            End While
            Dr.Close()
            Obj.ConClose()

        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("Empcode").ToString <> "") Then
            'empcode = Session("Empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If
        If Not (Page.IsPostBack) Then

            'If Session("Authorize") = 1 Then
            Me.cmdauthorize.Enabled = True
            'Else
            ' Me.cmdauthorize.Enabled = False
            'End If
            BindData()
        End If

    End Sub

    Protected Sub cmdauthorize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdauthorize.Click
        Tot = Session("Check")
        Tot = Mid(Session("Check"), Tot.Length - 1, Tot.Length)

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

        If txtremarks.Text <> "" Then
            Response.Redirect("MyWorkArae.aspx")
        Else
            ClientScript.RegisterClientScriptBlock(Me.GetType, "y", "<script language = javascript>alert('Please fill the remarks')</script>")
            txtremarks.Focus()
        End If
    End Sub

    Protected Sub cmdcancle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdcancle.Click
        Tot = Session("Check")
        Tot = Mid(Session("Check"), Tot.Length - 1, Tot.Length)
        Position()
        HCancle()
        TCancle()
        CCancle()
        B1Cancle()
        B2Cancle()
        B3Cancle()
        B4Cancle()
        If txtremarks.Text <> "" Then
            CancelMail()
            Response.Redirect("MyWorkArae.aspx")
        Else
            ClientScript.RegisterClientScriptBlock(Me.GetType, "y", "<script language = javascript>alert('Please fill the remarks')</script>")
            txtremarks.Focus()
            Exit Sub
        End If



    End Sub


    Public Sub H()
        If Session("To") = "1H" Then

            If txtremarks.Text <> "" Then
                SqlPass = "update  jctdev..jct_empg_leave set AutHodTime= getdate() ,AuthFlag='A' where  autoid= " & Session("AID")
                ObjFun.UpdateRecord(SqlPass)
                'Response.Redirect("MyWorkArae.aspx")
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType, "abc", "<script language = javascript>alert('Please fill the remarks')</script>")
                txtremarks.Focus()
            End If

        End If

    End Sub

    Public Sub T()

        If Session("To") = "2T" Then

            If txtremarks.Text <> "" Then
                SqlPass = "update  jctdev..jct_empg_leave set SubAutHodTime= getdate() ,SubAuthFlag='A'  where  autoid= " & Session("AID")
                ObjFun.UpdateRecord(SqlPass)
                'Response.Redirect("MyWorkArae.aspx")
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType, "a", "<script language = javascript>alert('Please fill the remarks')</script>")
                txtremarks.Focus()
            End If

        End If
    End Sub
    Public Sub C()

        If Session("To") = "3C" Then

            If txtremarks.Text <> "" Then
                SqlPass = "update  jctdev..jct_empg_leave set CTime= getdate() ,CFlag='A'  where  autoid= " & Session("AID")
                ObjFun.UpdateRecord(SqlPass)
                'Response.Redirect("MyWorkArae.aspx")
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType, "b", "<script language = javascript>alert('Please fill the remarks')</script>")
                txtremarks.Focus()
            End If

        End If
    End Sub
    Public Sub B1()
        If Session("To") = "B1" Then

            If txtremarks.Text <> "" Then
                SqlPass = "update  jctdev..jct_empg_leave set B1Time= getdate() ,B1Flag='A'  where  autoid= " & Session("AID")
                ObjFun.UpdateRecord(SqlPass)
                '  Response.Redirect("MyWorkArae.aspx")
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType, "c", "<script language = javascript>alert('Please fill the remarks')</script>")
                txtremarks.Focus()
            End If

        End If
    End Sub
    Public Sub B2()
        If Session("To") = "B2" Then

            If txtremarks.Text <> "" Then
                SqlPass = "update  jctdev..jct_empg_leave set B2Time= getdate() ,B2Flag='A' where  autoid= " & Session("AID")
                ObjFun.UpdateRecord(SqlPass)
                '  Response.Redirect("MyWorkArae.aspx")
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType, "d", "<script language = javascript>alert('Please fill the remarks')</script>")
                txtremarks.Focus()
            End If

        End If
    End Sub
    Public Sub B3()
        If Session("To") = "B3" Then

            If txtremarks.Text <> "" Then
                SqlPass = "update  jctdev..jct_empg_leave set B3Time= getdate() ,B3Flag='A' where  autoid= " & Session("AID")
                ObjFun.UpdateRecord(SqlPass)
                ' Response.Redirect("MyWorkArae.aspx")
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType, "e", "<script language = javascript>alert('Please fill the remarks')</script>")
                txtremarks.Focus()
            End If

        End If
    End Sub
    Public Sub B4()
        If Session("To") = "B4" Then

            If txtremarks.Text <> "" Then
                SqlPass = "update  jctdev..jct_empg_leave set B4Time= getdate() ,B4Flag='A' where  autoid= " & Session("AID")
                ObjFun.UpdateRecord(SqlPass)
                ' Response.Redirect("MyWorkArae.aspx")
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType, "f", "<script language = javascript>alert('Please fill the remarks')</script>")
                txtremarks.Focus()
            End If

        End If
    End Sub
    Public Sub MainFlag()
        If txtremarks.Text <> "" Then
            SqlPass = "update  jctdev..jct_empg_leave set Mainflag='A' , LastTime=getdate() where  autoid= " & Session("AID")
            ObjFun.UpdateRecord(SqlPass)
        Else
            ClientScript.RegisterClientScriptBlock(Me.GetType, "k", "<script language = javascript>alert('Please fill the remarks')</script>")
            txtremarks.Focus()
        End If

    End Sub
    Public Sub FlagUpdate()

        If txtremarks.Text <> "" Then
            If Len(Session("StoreFlag")) > 2 Then
                SqlPass = "update  jctdev..jct_empg_leave set FlagHC='" & Right(Session("StoreFlag"), Len(Session("StoreFlag")) - 3) & "' where  autoid= " & Session("AID")
                ObjFun.UpdateRecord(SqlPass)
            Else
                SqlPass = "update  jctdev..jct_empg_leave set FlagHC='" & Right(Session("StoreFlag"), Len(Session("StoreFlag")) - 2) & "' where  autoid= " & Session("AID")
                ObjFun.UpdateRecord(SqlPass)
            End If

        Else
            ClientScript.RegisterClientScriptBlock(Me.GetType, "ba", "<script language = javascript>alert('Please fill the remarks')</script>")
            txtremarks.Focus()
        End If


    End Sub
    Public Sub HCancle()
        If Session("To") = "1H" Then

            If txtremarks.Text <> "" Then
                SqlPass = "update  jctdev..jct_empg_leave set AutHodTime= getdate() ,AuthFlag='C',MainFlag='C',FlagHC='', LastTime=getdate(),Remarks='" & txtremarks.Text & "' where  autoid= " & Session("AID")
                ObjFun.UpdateRecord(SqlPass)
                'Response.Redirect("MyWorkArae.aspx")
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType, "affbc", "<script language = javascript>alert('Please fill the remarks')</script>")
                txtremarks.Focus()
            End If

        End If

    End Sub

    Public Sub TCancle()

        If Session("To") = "2T" Then

            If txtremarks.Text <> "" Then
                SqlPass = "update  jctdev..jct_empg_leave set SubAutHodTime= getdate() ,SubAuthFlag='C',MainFlag='C',FlagHC='' , LastTime=getdate(),Remarks='" & txtremarks.Text & "' where  autoid= " & Session("AID")
                ObjFun.UpdateRecord(SqlPass)
                ' Response.Redirect("MyWorkArae.aspx")
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType, "dfdfa", "<script language = javascript>alert('Please fill the remarks')</script>")
                txtremarks.Focus()
            End If

        End If
    End Sub
    Public Sub CCancle()

        If Session("To") = "3C" Then

            If txtremarks.Text <> "" Then
                SqlPass = "update  jctdev..jct_empg_leave set CTime= getdate() ,CFlag='C',MainFlag='C',FlagHC='' , LastTime=getdate(),Remarks='" & txtremarks.Text & "' where  autoid= " & Session("AID")
                ObjFun.UpdateRecord(SqlPass)
                'Response.Redirect("MyWorkArae.aspx")
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType, "sdfb", "<script language = javascript>alert('Please fill the remarks')</script>")
                txtremarks.Focus()
            End If

        End If
    End Sub
    Public Sub B1Cancle()

        If Session("To") = "B1" Then

            If txtremarks.Text <> "" Then
                SqlPass = "update  jctdev..jct_empg_leave set CTime= getdate() ,CFlag='C',MainFlag='C',FlagHC='' , LastTime=getdate(),Remarks='" & txtremarks.Text & "' where  autoid= " & Session("AID")
                ObjFun.UpdateRecord(SqlPass)
                'Response.Redirect("MyWorkArae.aspx")
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType, "sswe", "<script language = javascript>alert('Please fill the remarks')</script>")
                txtremarks.Focus()
            End If

        End If
    End Sub
    Public Sub B2Cancle()

        If Session("To") = "B2" Then

            If txtremarks.Text <> "" Then
                SqlPass = "update  jctdev..jct_empg_leave set CTime= getdate() ,CFlag='C',MainFlag='C',FlagHC='' , LastTime=getdate(),Remarks='" & txtremarks.Text & "' where  autoid= " & Session("AID")
                ObjFun.UpdateRecord(SqlPass)
                'Response.Redirect("MyWorkArae.aspx")
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType, "sre", "<script language = javascript>alert('Please fill the remarks')</script>")
                txtremarks.Focus()
            End If

        End If
    End Sub
    Public Sub B3Cancle()

        If Session("To") = "B3" Then

            If txtremarks.Text <> "" Then
                SqlPass = "update  jctdev..jct_empg_leave set CTime= getdate() ,CFlag='C',MainFlag='C',FlagHC='' , LastTime=getdate(),Remarks='" & txtremarks.Text & "' where  autoid= " & Session("AID")
                ObjFun.UpdateRecord(SqlPass)
                'Response.Redirect("MyWorkArae.aspx")
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType, "styue", "<script language = javascript>alert('Please fill the remarks')</script>")
                txtremarks.Focus()
            End If

        End If
    End Sub
    Public Sub B4Cancle()

        If Session("To") = "B4" Then

            If txtremarks.Text <> "" Then
                SqlPass = "update  jctdev..jct_empg_leave set CTime= getdate() ,CFlag='C',MainFlag='C',FlagHC='' , LastTime=getdate(),Remarks='" & txtremarks.Text & "' where  autoid= " & Session("AID")
                ObjFun.UpdateRecord(SqlPass)
                'Response.Redirect("MyWorkArae.aspx")
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType, "lop", "<script language = javascript>alert('Please fill the remarks')</script>")
                txtremarks.Focus()
            End If

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

            Dim SqlPass1 = "SELECT e_mailid from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & empcode_to & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') and status is null AND Auth_Req='Y'and Days=0 and a.company_code='" & Session("Companycode") & "' and b.company_code='" & Session("Companycode") & "'  UNION SELECT e_mailid from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & empcode_to & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') and status is null AND Auth_Req='Y'and days between 0 and " & txtdays.Text & " and a.company_code='" & Session("Companycode") & "' and b.company_code='" & Session("Companycode") & "'  "
            Dim Dr1 As SqlDataReader = Obj.FetchReader(SqlPass1)

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
            Dim Dr2 As SqlDataReader = Obj.FetchReader(SqlPass2)

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
            .Body = "Leave of " & Mr_Mrs_to & " " & to_name & " has been canceled by " & Mr_Mrs & " " & empname & " Emp code:-" & Session("Empcode") & ".Autoid of leave is " & Request.QueryString.Get("ID") & "." & "<br/><br/><br/><br/><br/><br/><br/>  DISCLAIMER: This email has been generated through Employee Gateway Package. <br/>Kindly do not reply as you will not receive a response. "
            .Subject = "Leave of " & Mr_Mrs_to & " " & to_name & " has been  canceled by " & Mr_Mrs & " " & empname & " Emp code=" & Session("Empcode")
            Client.Host = "EXCHANGE2k7"
            Client.Port = 25
            Client.Send(Message)
        End With
        ob.closecn()
    End Sub
End Class
