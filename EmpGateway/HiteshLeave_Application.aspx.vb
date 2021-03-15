Imports System.Data.SqlClient
Imports System.net.Mail.MailMessage
Imports System.net.Mail.SmtpClient
Imports System.Data

Partial Class Default9
    Inherits System.Web.UI.Page
    Dim strTo As String
    Dim strFrom As String
    Dim strSubject As String
    Dim Obj As New Connection
    Dim SqlPass As String, Sqlpass1 As String
    Dim Auto1 As Int64
    Dim EmailTO, EmailTO1, EmailFrom, EmailCc, EmailBcc, EmailBcc1, Checkflag, Checkflag1 As String
    Dim Difference As Integer
    Dim con As String
    Dim Cmd As New SqlCommand
    Dim CountMail As Integer = 0


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdapply.Click

        '------------------------------------------------------------------------------------------------------------------------------
        If Txtdays.Text = "" Then
            ClientScript.RegisterClientScriptBlock(Me.GetType, "Day", "<script language = javascript>alert('Please fill the leave days')</script>")
            Txtdays.Focus()
            Exit Sub
        End If
        '------------------------------------------------------------------------------------------------------------------------------
        EmailIDFrom()

        '------------------------------------------------------------------------------------------------------------------------------
        'Define the Class
        '------------------------------------------------------------------------------------------------------------------------------
        Dim Client As New Net.Mail.SmtpClient
        Dim Message As New Net.Mail.MailMessage
        Dim From As New Net.Mail.MailAddress(EmailFrom)
        '------------------------------------------------------------------------------------------------------------------------------


        '------------------------------------------------------------------------------------------------------------------------------
        'Severe Name & Prot number
        '------------------------------------------------------------------------------------------------------------------------------
        Client.Host = "EXCHANGE2003"
        Client.Port = 25
        '------------------------------------------------------------------------------------------------------------------------------


        If EmailFrom <> "" Then
            Message.From = From
        End If


        '------------------------------------------------------------------------------------------------------------------------------
        'Send message for To
        '------------------------------------------------------------------------------------------------------------------------------

        Dim SqlPass = "SELECT e_mailid from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & Session("Empcode") & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') AND Auth_Req='Y'and Days=0 UNION SELECT e_mailid from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & Session("Empcode") & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') AND Auth_Req='Y'and days between 0 and " & Txtdays.Text & " "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        EmailTO = Dr.Item(0)
                        Message.To.Add(EmailTO)
                    End If
                End While
                Dr.Close()
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType, "Potttr", "<script language = javascript>alert('No any Email Id, Please Contact With IT')</script>")
                Dr.Close()
                Obj.ConClose()
                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try
        '------------------------------------------------------------------------------------------------------------------------------


        '------------------------------------------------------------------------------------------------------------------------------
        Message.Subject = "Application for leave"
        '------------------------------------------------------------------------------------------------------------------------------

        '------------------------------------------------------------------------------------------------------------------------------
        'Send the Bcc
        '------------------------------------------------------------------------------------------------------------------------------

        Dim SqlPass1 = "SELECT e_mailid from jctdev..jct_emp_hod a,JCTDEV..mistel b WHERE  b.empcode=a.resp_emp AND emp_code='" & Session("Empcode") & "' and flag in('B') AND Auth_Req='Y'"
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

        If ddlleave.Text = "Short Leave" Then
            Message.Body = Session("Mr_Mrs") + " " + StrConv(txtname.Text, VbStrConv.ProperCase) + "," + " " + StrConv(TextBox6.Text, VbStrConv.ProperCase) + "," + " " + "has applied for" + " " + StrConv(ddlleave.Text, VbStrConv.ProperCase) + " " + "," + " " + "from" + " " + Trim(txttimefrom.SelectedValue) + " " + "to" + " " + Trim(TxtTimeTo.SelectedValue)
        Else
            Message.Body = Session("Mr_Mrs") + " " + StrConv(txtname.Text, VbStrConv.ProperCase) + "," + " " + StrConv(TextBox6.Text, VbStrConv.ProperCase) + "," + " " + "has applied for" + " " + StrConv(ddlleave.Text, VbStrConv.ProperCase) + " " + "," + " " + "from" + " " + Trim(TxtLeaveFrom.SelectedDate) + " " + "to" + " " + Trim(TxtLeaveTo.SelectedDate) + ", " + " " + "for" + " " + Trim(Txtdays.Text) + " " + "day"
        End If

        Client.Send(Message)

        AutoGenrate()
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
        Txtdays.Enabled = True

        '--------------------------------------------------------------------
        ClientScript.RegisterClientScriptBlock(Me.GetType, "Por", "<script language = javascript>alert('Leave Applied Successfully')</script>")



    End Sub

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad

        txtname.Text = Session("Empname")
        TextBox6.Text = Session("Desg")
        txtdept.Text = Session("Deptname")

    End Sub

    Public Sub AutoGenrate()
        Dim SqlPass = "SELECT MAX(autoid) FROM jctdev..jct_empg_leave"
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Auto1 = Dr.Item(0) + 1
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
                SqlPass = "INSERT INTO  jctdev..jct_empg_leave(Usercode,CompanyCode,Cardno,autoid,empcode,natureleave,leavetype,name,desgination,department,shift,days,leavefrom,leaveto,compleave,purpleave,addleave,phoneleave,authflag,CurLeaveTime,CompAgainTime,FlagHC,mainflag )  VALUES('" & Trim(Session("Empcode")) & "','JCT00LTD','" & Trim(Session("CardNo")) & "'," & Auto1 & ",'" & Trim(Session("Empcode")) & "', '" & Trim(ddlleave.Text) & "','" & Trim(dlleavetype.Text) & "','" & Trim(txtname.Text) & "','" & Trim(TextBox6.Text) & "','" & Trim(txtdept.Text) & "','" & Trim(ddlshift.Text) & "'," & Txtdays.Text & " ,'" & Trim(TxtLeaveFrom.SelectedDate) & "','" & Trim(TxtLeaveTo.SelectedDate) & "','" & Trim(txtcompleave.Text) & "','" & Trim(txtpurleave.Text) & "','" & Trim(txtaddleave.Text) & "','" & Trim(txtphoneleave.Text) & "','U', getdate(),'" & Trim(TxtCoDtAgian.SelectedDate) & "','" & Checkflag & "','P')"

            ElseIf ddlleave.Text = "Short Leave" Then
                SqlPass = "INSERT INTO jctdev..jct_empg_leave(Usercode,CompanyCode,autoid,Cardno,empcode,natureleave,leavetype,name,desgination,department,shift,days,leavefrom,leaveto,timefrom,timeto,compleave,purpleave,addleave,phoneleave,authflag,CurLeaveTime,FlagHC,mainflag)  VALUES('" & Trim(Session("Empcode")) & "','JCT00LTD'," & Auto1 & ",'" & Trim(Session("CardNo")) & "','" & Trim(Session("Empcode")) & "', '" & Trim(ddlleave.Text) & "','" & Trim(dlleavetype.Text) & "','" & Trim(txtname.Text) & "','" & Trim(TextBox6.Text) & "','" & Trim(txtdept.Text) & "','" & Trim(ddlshift.Text) & "'," & Txtdays.Text & " ,'" & Trim(TxtLeaveFrom.SelectedDate) & "','" & Trim(TxtLeaveTo.SelectedDate) & "','" & Right(Trim(txttimefrom.SelectedValue), 10) & "','" & Right(Trim(TxtTimeTo.SelectedValue), 10) & "','" & Trim(txtcompleave.Text) & "','" & Trim(txtpurleave.Text) & "','" & Trim(txtaddleave.Text) & "','" & Trim(txtphoneleave.Text) & "','U', getdate(),'" & Checkflag & "','P')"

            Else
                SqlPass = "INSERT INTO jctdev..jct_empg_leave(Usercode,CompanyCode,Cardno,autoid,empcode,natureleave,leavetype,name,desgination,department,shift,days,leavefrom,leaveto,compleave,purpleave,addleave,phoneleave,authflag,CurLeaveTime,FlagHC,mainflag )  VALUES('" & Trim(Session("Empcode")) & "','JCT00LTD','" & Trim(Session("CardNo")) & "'," & Auto1 & ",'" & Trim(Session("Empcode")) & "', '" & Trim(ddlleave.Text) & "','" & Trim(dlleavetype.Text) & "','" & Trim(txtname.Text) & "','" & Trim(TextBox6.Text) & "','" & Trim(txtdept.Text) & "','" & Trim(ddlshift.Text) & "'," & Txtdays.Text & " ,'" & Trim(TxtLeaveFrom.SelectedDate) & "','" & Trim(TxtLeaveTo.SelectedDate) & "','" & Trim(txtcompleave.Text) & "','" & Trim(txtpurleave.Text) & "','" & Trim(txtaddleave.Text) & "','" & Trim(txtphoneleave.Text) & "','U', getdate(),'" & Checkflag & "','P')"
            End If


            Cmd = New SqlCommand(SqlPass, Obj.Connection)
            Cmd.Transaction = Tran
            Cmd.ExecuteNonQuery()
            Tran.Commit()

        Catch ex As Exception
            Tran.Rollback()
            ClientScript.RegisterClientScriptBlock(Me.GetType, "Por", "<script language = javascript>alert('Please Insert Proper data')</script>")
            Exit Sub
        Finally
            Obj.ConClose()
        End Try
        Dr.Close()
    End Sub

    Public Sub EmailIDFrom()
        Dim SqlPass = "SELECT E_mailID FROM  JCTDEV..Mistel b  WHERE b.empcode='" & Session("Empcode") & "'  "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        EmailFrom = Dr.Item(0)
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

        If ddlleave.Text = "Short Leave" Then
            txttimefrom.Enabled = True
            TxtTimeTo.Enabled = True
            Txtdays.Text = "0"
            Txtdays.Enabled = False

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
        Dim SqlPass = "SELECT FLAG from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & Session("Empcode") & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') AND Auth_Req='Y'and Days=0 UNION SELECT FLAG from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & Session("Empcode") & "' and flag in('1H','2T','3C','B1','B2','B3','B4','B5') AND Auth_Req='Y'and days between 0 and " & Txtdays.Text & "  "
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
        Txtdays.Enabled = True

    End Sub
End Class
'Leave Application Code File Also Available E:\c backup 30 july 08\hitesh\Desktop\master